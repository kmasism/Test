using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Xml;
using UpgradeHelpers.DB.ADO.Events;
using System.Reflection;
#if NET_CORE_APP || NET_STANDARD_APP
using Microsoft.Data.SqlClient;
#else
using System.Data.SqlClient;
#endif

namespace UpgradeHelpers.DB.ADO
{

	/// <summary>
	/// Extension methods for the DataColumnCollection.
	/// </summary>
	public static class DataColumnCollectionExtender
	{
		/// <summary>
		/// Creates and adds a DataColumn object that has the specified name, type, max length (for text fields), and attributes.
		/// </summary>
		/// <param name="collection">The collection that will be extended.</param>
		/// <param name="name">The name of the column to add.</param>
		/// <param name="type">The type of the column to add.</param>
		/// <param name="maxLength">In case of text fields, the maximum length of the column.</param>
		/// <param name="attrs">Attributes to specify different aspects of the DataColumn, such as AllowDbNull.</param>
		public static DataColumn Add(this DataColumnCollection collection, string name, Type type, int maxLength = int.MinValue, object attrs = null)
		{
			DataColumn column = new DataColumn(name, type);
			if (maxLength != int.MinValue)
				column.MaxLength = maxLength;
			// Process attrs here and add values to column.
			collection.Add(column);
			return column;
		}
	}

	/// <summary>
	///     Support class for the ADO.Recorset the object that represents the records in a base table or the records that result from running a query.
	/// </summary>
	[Serializable]
	public class ADORecordSetHelper : RecordSetHelper, ISerializable
	{
		#region Events declarations

		/// <summary>Occurs when EOF/BOF hit.</summary>
		public event EndOfRecordsetEventHandler EndOfRecordset;

		/// <summary>Occurs before a field change.</summary>
		public event FieldChangeEventHandler WillChangeField;

		/// <summary>Occurs after a field change.</summary>
		public event FieldChangeCompleteEventHandler FieldChangeComplete;

		/// <summary>Occurs before a record change.</summary>
		public event RecordChangeEventHandler WillChangeRecord;

		/// <summary>Occurs after a record change.</summary>
		public event RecordChangeCompleteEventHandler RecordChangeComplete;

		/// <summary>Occurs before a recordset change.</summary>
		public event RecordSetChangeEventHandler WillChangeRecordset;

		/// <summary>Occurs after a recordset change.</summary>
		public event RecordSetChangeCompleteEventHandler RecordsetChangeComplete;

		/// <summary>Occurs before a different row becomes the current row.</summary>
		public event MoveEventHandler WillMove;

		/// <summary>Occurs after a row becomes the current row.</summary>
		public event MoveCompleteEventHandler MoveComplete;

		#endregion
		
		#region constants

		private const string StringFullName = "System.String";
		
		#endregion

		#region Class Variables

		private CursorLocationEnum _cursorLocation = CursorLocationEnum.adUseClient;
		private CursorTypeEnum _cursorType = CursorTypeEnum.adOpenUnspecified;

		/// <summary>
		///     New Datarow view when adding to a sorted or filtered collection
		/// </summary>
		private DataRowView _dbvRow;

		private LockTypeEnum _lockType = LockTypeEnum.LockOptimistic;

		/// <summary>
		///     page size
		/// </summary>
		private int _pagesize;

		private String _sort = "";

		/// <summary>
		///     string for delete query
		/// </summary>
		public String SqlDeleteQuery
		{
			get
			{
				return _sqlDeleteQuery;
			}
			set
			{
				_sqlDeleteQuery = value;
			}
		}

		/// <summary>
		///     string for insert query
		/// </summary>
		public String SqlInsertQuery
		{
			get
			{
				return _sqlInsertQuery;
			}
			set
			{
				_sqlInsertQuery = value;
			}
		}

		/// <summary>
		///     string for select query
		/// </summary>
		public String SqlSelectQuery
		{
			get
			{
				return _sqlSelectQuery;
			}
			set
			{
				_sqlSelectQuery = value;
			}
		}

		/// <summary>
		///     string for update query
		/// </summary>
		public String SqlUpdateQuery
		{
			get
			{
				return _sqlUpdateQuery;
			}
			set
			{
				_sqlUpdateQuery = value;
			}
		}

        [JSonSerializeAttribute]
        private ConnectionState _state = ConnectionState.Closed;        
        internal Hashtable SerializationInfo;

		DataTable synonymsTable = null;

		private bool _currentRowDeleted = false;

		#endregion

		#region paging

		/// <summary>
		///     Gets/Sets the number of rows per page.
		/// </summary>
		public int PageSize
		{
			get { return _pagesize; }
			set { _pagesize = value; }
		}

		/// <summary>
		///     Gets the number of pages.
		/// </summary>
		public int PageCount
		{
			get
			{
				int pageCount = 0;
				if (Opened)
				{
					if (PageSize == 0)
					{
						pageCount = 0;
					}
					pageCount = (int)Math.Ceiling(RecordCount / (float)PageSize);
				}
				return pageCount;
			}
		}

		#endregion

		#region  properties

		/// <summary>
		///     This flag is used to stop the propagation of events while performing a delete.
		///     It was found that deleting a DataRow raised several events on the binding source
		///     and these events update the current row which must remain the same until the update logic is executed
		/// </summary>
		internal bool DisableEventsWhileDeleting = false;

        [JSonSerializeAttribute]
        private int _currentRecordSet = 0;
        /// <summary>
        /// Pointer to current recordset data table
        /// </summary>
        
        public override int CurrentRecordSet
		{
			get
			{
				return _currentRecordSet;
			}
			set
			{
				_currentRecordSet = value;
			}
		}

		/// <summary>
		/// To handle all extra attributes that couldn't be set by xml
		/// </summary>
		private Dictionary<string, List<XmlAttribute>> columnAttributes = new Dictionary<string, List<XmlAttribute>>();

		/// <summary>
		///     Gets a DataRow with the information of the current record on the RecordsetHelper.
		/// </summary>
		public override DataRow CurrentRow
		{
			get
			{
				DataRow theRow = null;
				if (UsingView)
				{
					if (!_newRow && _index >= 0 && _index < CurrentView.Count)
					{
						_dbvRow = CurrentView[_index];
					}
					else if (!_newRow)
					{
						_dbvRow = null;
					}

					theRow = _dbvRow != null? _dbvRow.Row : null;
				}
				else
				{
					if (_index >= 0 && _index < Tables[CurrentRecordSet].Rows.Count)
					{
						theRow = Tables[CurrentRecordSet].Rows[_index];
					}
				}
				return theRow;
			}
		}

		/// <summary>
		///     Gets or sets the connection string being use by this RecordsetHelper object.
		/// </summary>
		public override String ConnectionString
		{
			get { return _connectionString; }
			set
			{
				_connectionString = value;
				if (_providerFactory != null && _connectionString.Length > 0)
				{
					try
					{
						Validate();
#if DBTrace
                        DbConnection connection = DBTrace.CreateConnectionWithTrace(providerFactory);
#else
						DbConnection connection = _providerFactory.CreateConnection();
#endif
						Debug.Assert(connection != null, "connection != null");
						connection.ConnectionString = value;
						ActiveConnection = connection;
#if DBTrace
                        DBTrace.OpenWithTrace(ActiveConnection);
#else
						ActiveConnection.Open();
#endif
					} // try
					catch (Exception ex)
					{
						String message = string.Format(
							"Problem while trying to set the active connection. Please verify ConnectionString {0} and Factory {1} settings. Error details {2}",
							_connectionString,
							_providerFactory,
							ex.Message);
#if WINFORMS
                        if (Process.GetCurrentProcess().ProcessName == "devenv")
						{
							System.Windows.Forms.MessageBox.Show(message,TITLE_DIALOG_RecordSetError);
						} // if
#else
						Trace.TraceError(message);
#endif
						if (!Disconnected)
							throw;
					} // catch
				}
				else
				{
					_activeConnection = null;
				}
				_defaultValues = null;
			}
		}

		/// <summary>
		///     Return true if the recordsethelper is caching the adapters
		/// </summary>
		public bool IsCachingAdapter
		{
			get { return _cachingAdapter; }
		}

		/// <summary>
		///     Property to indicate the editing status of the current record
		/// </summary>
		public EditModeEnum EditMode
		{
			get
			{
				return _editMode;
			}
		}

		/// <summary>
		///     Property to handle the Status of the recordset
		/// </summary>
		public DataRowState Status
		{
			get
			{
				DataRowState state = DataRowState.Unchanged;
				if (FieldsValues != null)
				{
					state = FieldsValues.RowState;
				}
				return state;
			}
		}

		/// <summary>
		///     Gets a DataRow object containing the field values of the current record.
		/// </summary>
		public DataRow FieldsValues
		{
			get
			{
				DataRow row = null;
				if (UsingView)
				{
					if (CurrentView != null && _index >= 0)
					{
						row = CurrentView[_index].Row;
					}
				}
				else
				{
					if (Tables.Count > 0 && _index >= 0)
					{
						row = Tables[CurrentRecordSet].Rows[_index];
					}
				}
				return row;
			}
		}

		/// <summary>
		///     Property used to determine if the data needs to be get from a dataview or the table directly
		/// </summary>
		protected override bool UsingView
		{
			get { return _filtered || !String.IsNullOrEmpty(_sort); }
		}

		/// <summary>
		///     Property to get and set the order of the recordset
		/// </summary>
		[JSonSerializeAttribute]
		public String Sort
		{
			get { return _sort; }
			set
			{
				if (_isDefaultSerializationInProgress) return;
				_sort = value;
				if (_sort.Length > 0 && Tables.Count > 0)
				{
					_newRow = false;
					CurrentView.Sort = _sort;
					if (_opened)
					{
						MoveFirst(EventReasonEnum.adRsnRequery);
					}
				}
			}
		}

		/// <summary>
		///     Property to handle the state of the recordset
		/// </summary>
		public ConnectionState State
		{
			//Changes for remove memory leak
			get { return _state; }
			set { _state = value; }
		}

		/// <summary>
		///     This is an override to wire the event necesary to handle the proper state of the recordset
		/// </summary>
		public override DbConnection ActiveConnection
		{
			get { return _activeConnection; }
			set
			{
				//base.ActiveConnection = value;
				if (_activeCommand != null)
				{
					_activeCommand.Connection = value;
				}
				_activeConnection = value;

				//Validate provider
				ValidateProvider();

				_connectionString = ActiveConnection != null ? ActiveConnection.ConnectionString : _connectionString;
				_connectionStateAtEntry = ActiveConnection != null ? ActiveConnection.State : ConnectionState.Closed;
				// end of base class setter

			}
		}

		/// <summary>
		///     Returns a value that indicates whether the current record position is before the first record in an ADORecordsetHelper object. Read-only Boolean.
		/// </summary>
		public override bool BOF
		{
			get
			{
				if (Opened)
				{
					return (_index < 0 || RecordCount == 0);
				}
				else
				{
					throw new InvalidOperationException(NotAllowedOperation);
				}
			}
		}

        /// <summary>
        ///     Gets/Sets the LockType for this object.
        /// </summary>
        [JSonSerializeAttribute]
        public LockTypeEnum LockType
		{
			get { return _lockType; }
			set { _lockType = value; }
		}

		/// <summary>
		///     Gets/Sets the CursorType for this object.
		/// </summary>
		public CursorTypeEnum CursorType
		{
			get { return _cursorType; }
			set { _cursorType = value; }
		}

		/// <summary>
		///     Gets/Sets the CursorLocation for this object.
		/// </summary>
		public CursorLocationEnum CursorLocation
		{
			get { return _cursorLocation; }
			set { _cursorLocation = value; }
		}


		/// <summary>
		///     Gets and Sets the position of the current record on the recordset instance.
		/// </summary>
		public override int AbsolutePosition
		{
			get
			{
				int absolutePosition = 0;
				if (Opened)
				{
					if (_currentRowDeleted)
					{
						throw new Exception("Row has been deleted or is marked for deletion.");
					}
					else if (EOF)
					{
						absolutePosition = (int)PositionEnum.adPosEOF;
					}
					else if (BOF)
					{
						absolutePosition = (int)PositionEnum.adPosBOF;
					}
					else
					{
						absolutePosition = _index + 1;
					}

				}
				return absolutePosition;
			}
			set
			{
				BasicMove(value - 1, EventReasonEnum.adRsnMove);
			}
		}

		/// <summary>
		///     Gets the specified version of the column.
		/// </summary>
		/// <param name="columnName">Name of the column to look for.</param>
		/// <param name="rowVersion">The version of the row.</param>
		/// <returns>The value at the given index.</returns>
		public virtual Object this[String columnName, DataRowVersion rowVersion]
		{
			get
			{
				if (CurrentRow.HasVersion(rowVersion))
					return CurrentRow[columnName, rowVersion];
				else if (rowVersion == DataRowVersion.Original && CurrentRow.RowState == DataRowState.Added)
					return DBNull.Value;
				else
					return CurrentRow[columnName];
			}
		}

		/// <summary>
		///     Gets the specified version of the column.
		/// </summary>
		/// <param name="columnIndex">Index of the column to look for.</param>
		/// <param name="rowVersion">The version of the row.</param>
		/// <returns>The value at the given index.</returns>
		public virtual Object this[int columnIndex, DataRowVersion rowVersion]
		{
			get
			{
				if (CurrentRow.HasVersion(rowVersion))
					return CurrentRow[columnIndex, rowVersion];
				else if (rowVersion == DataRowVersion.Original && CurrentRow.RowState == DataRowState.Added)
					return DBNull.Value;
				else
					return CurrentRow[columnIndex];
			}
		}


		/// <summary>
		///     Sets a bookmark to an specific record inside the ADORecordsetHelper.
		/// </summary>
		public DataRow Bookmark
		{
			set
			{
				if (Opened)
				{
					_index = findBookmarkIndex(value);
					if (_index >= 0) BasicMove(_index, EventReasonEnum.adRsnMove);

					EventStatusEnum status = EventStatusEnum.adStatusOK;
					OnWillMove(EventReasonEnum.adRsnMove, ref status);
					string[] errors = null;
					try
					{
						if (!isBatchEnabled())
							Update();
					}
					catch (Exception e)
					{
						errors = new string[] { e.Message };
					}
					OnMoveComplete(EventReasonEnum.adRsnMove, ref status, errors);
				}
			}
			get
			{
				if (Opened)
				{
					return UsingView ? CurrentView[_index].Row : Tables[CurrentRecordSet].Rows[_index];
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		///     Gets/Sets the current page number.
		/// </summary>
		public int AbsolutePage
		{
			get
			{
				if (_isDefaultSerializationInProgress) return 0;
				if (Opened)
				{
					EventStatusEnum status = EventStatusEnum.adStatusOK;
					OnWillMove(EventReasonEnum.adRsnMove, ref status);
					OnMoveComplete(EventReasonEnum.adRsnMove, ref status, null);
					if (BOF)
					{
						return (int)PositionEnum.adPosBOF;
					}
					if (EOF)
					{
						return (int)PositionEnum.adPosEOF;
					}
					if (PageSize != 0)
					{
						return (int)Math.Ceiling((double)AbsolutePosition / PageSize);
					}
				}
				return 0;
			}
			set
			{
				if (_isDefaultSerializationInProgress) return;
				if (!Opened)
				{
					throw new InvalidOperationException(NotAllowedOperation);
				}
				if (value > 0)
				{
					_index = (value - 1) * PageSize;
				}
			}
		}

		/// <summary>
		/// Event that when the bindedsrouce moves this recordset also does.
		/// </summary>
		private void Source_PositionChanged(object sender, EventArgs e)
		{
#if NET_CORE_APP || NET_STANDARD_APP
			int newPosition = ((dynamic)sender).Position;
#else
			int newPosition = ((System.Windows.Forms.BindingSource)sender).Position;
#endif

			if (newPosition >= 0 && newPosition != this.CurrentPosition)
			{
				this.Move(newPosition - this.CurrentPosition);
			}
		}

		/// <summary>
		/// This property is used to create data-bound controls with the Data Environment.
		/// The Data Environment maintains collections of data (data sources) containing named objects (data members)
		/// that will be represented as a Recordset object*.*
		/// </summary>
		public object DataSource
		{
			get
			{
#if NET_CORE_APP || NET_STANDARD_APP
				Type bindingSourceType = System.Type.GetType(DbProviderFactories.BINDING_SOURCE_TYPE_NAME);
				dynamic source = Activator.CreateInstance(bindingSourceType);
#else
				System.Windows.Forms.BindingSource source = new System.Windows.Forms.BindingSource();
#endif
				object table = null;
				if (State != ConnectionState.Closed)
				{
					if (UsingView)
					{
						table = CurrentView;
					}
					else
					{
						table = Tables[CurrentRecordSet];
					}
				}
				source.DataSource = table;
#if NET_CORE_APP || NET_STANDARD_APP
				// all this code is equivalent to source.PositionChanged += Source_PositionChanged
				var eventInfo = bindingSourceType.GetEvent("PositionChanged");
				var methodInfo = typeof(ADORecordSetHelper).GetMethod("Source_PositionChanged",
					System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
				Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, methodInfo);
				eventInfo.AddEventHandler(source, handler);
#else
				source.PositionChanged += Source_PositionChanged;
#endif
				return source;
			}
		}

		/// <summary>
		/// </summary>
		public String DataMember
		{
			get
			{
				string result = string.Empty;
				if (State != ConnectionState.Closed)
				{
					result = UsingView ? CurrentView.Table.TableName : Tables[CurrentRecordSet].TableName;
				}
				return result;
			}
		}

		/// <summary>
		///     Gets a DataColumnCollection object that contains the information of all columns on the RecordsetHelper.
		/// </summary>
		public override DataColumnCollection FieldsMetadata
		{
			get
			{
				if (UsingView)
					return CurrentView.Table.Columns;
				else
					return base.FieldsMetadata;
			}
		}

		/// <summary>
		///     Makes sure that the current ADO.NET provider is set
		///     and if it is compatible with the current
		/// </summary>
		private void ValidateProvider()
		{
			if (_activeConnection == null) return;
			if (_providerFactory != null && _providerFactory.GetType().Namespace != _activeConnection.GetType().Namespace)
			{
				_providerFactory = null;
			}
			if (_providerFactory == null)
			{
				string nm = _activeConnection.GetType().Namespace;
				_providerFactory = DbProviderFactories.GetFactory(nm);
			}
		}

		/// <summary>
		///     Finds the index in the RecordsetHelper for the �value�.
		/// </summary>
		/// <param name="value">The DataRow to look for.</param>
		/// <returns>The index number if is found, otherwise -1.</returns>
		protected int findBookmarkIndex(DataRow value)
		{
			if (!UsingView)
			{
				return Tables[CurrentRecordSet].Rows.IndexOf(value);
			}
			int result = -1;
			for (int i = 0; i < CurrentView.Count; i++)
			{
				if (CurrentView[i].Row == value)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		/// <summary>
		/// Store the original command type before any modification
		/// </summary>
        private CommandType OriginalCommandType { get; set; }

        /// <summary>
        /// Store the original command text before any modification
        /// </summary>
        private string OrignalCommandText { get; set; }

        #endregion

        #region Global Flags
        private static bool _showWarnings = true;
		/// <summary>
		/// Turns on or off the following general debug warnings:
		///		- Attempting to autogenerate Update command based on Select command that does not include any primary keys.
		///		- Attempting to autogenerate Delete command based on Select command that does not include any primary keys.
		/// </summary>
		public static bool ShowWarnings
		{
			set
			{
				_showWarnings = value;
			}
			private get
			{
				return _showWarnings;
			}
		}
		#endregion

		#region constructors

		/// <summary>
		///     Creates a new ADORecordsetHelper instance using the default factory specified on the configuration xml.
		/// </summary>
		public ADORecordSetHelper()
		{
			_index = -1;
			_newRow = false;
			ProviderFactory = AdoFactoryManager.GetFactory("");
			DatabaseType = AdoFactoryManager.GetFactoryDbType(AdoFactoryManager.Default.Name);
		}

        [JSonSerializeAttribute]
        private string _factoryName = "";

		/// <summary>
		///     Creates a new ADORecordsetHelper
		/// </summary>
		/// <param name="factory"></param>
		protected ADORecordSetHelper(DbProviderFactory factory)
		{
			_providerFactory = factory;
		}

		/// <summary>
		///     Creates a new ADORecordsetHelper instance using the factory specified on the �factoryName� parameter.
		/// </summary>
		/// <param name="factoryName">The name of the factory to by use by this ADORecordsetHelper object (the name most exist on the configuration xml file).</param>
		public ADORecordSetHelper(String factoryName)
			: this(AdoFactoryManager.GetFactory(factoryName))
		{
			if (string.IsNullOrEmpty(factoryName))
			{
				_factoryName = AdoFactoryManager.Default.Name;
			}
			else
			{
				_factoryName = factoryName;
			}
			DatabaseType = AdoFactoryManager.GetFactoryDbType(_factoryName);
			_index = -1;
			_newRow = false;
		}

		/// <summary>
		///     Creates a new ADORecordsetHelper instance using provided parameters.
		/// </summary>
		/// <param name="factoryName">The name of the factory to by use by this ADORecordsetHelper object (the name most exist on the configuration xml file).</param>
		/// <param name="connString">The connection string to be used by this ADORecordsetHelper.</param>
		public ADORecordSetHelper(String factoryName, String connString)
			: this(factoryName)
		{
			_connectionString = connString;
		}

		/// <summary>
		///     Creates a new ADORecordsetHelper instance using provided parameters.
		/// </summary>
		/// <param name="factoryName">The name of the factory to by use by this ADORecordsetHelper object (the name most exist on the configuration xml file).</param>
		/// <param name="connString">The connection string to be used by this ADORecordsetHelper.</param>
		/// <param name="sqlSelectString">A string containing the SQL Query to be loaded on the ADORecordsetHelper.</param>
		public ADORecordSetHelper(String factoryName, String connString, String sqlSelectString)
			: this(factoryName, connString)
		{
			SqlSelectQuery = sqlSelectString;
			Open();
		}

		#endregion

		#region Serialization machinery

		/// <summary>
		///     Constructor.
		/// </summary>
		/// <param name="info">System.Runtime.Serialization.SerializationInfo, all the data needed to load and store an object.</param>
		/// <param name="context">
		///     System.Runtime.Serialization.StreamingContext, describes the source and destination of
		///     a given serialized stream , and provides an additional caller-defined context.
		/// </param>
		protected ADORecordSetHelper(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			Sort = info.GetString("Sort");
			LockType = (LockTypeEnum)info.GetInt32("LockType");
			_connectionString = info.GetString("ConnectionString");
			_index = info.GetInt16("Index");
			_factoryName = info.GetString("Factory");
			_newRow = info.GetBoolean("NewRow");
			_currentRecordSet = info.GetInt32("CurrentRecordSet");
			_eof = info.GetBoolean("Eof");
			_state = (ConnectionState)info.GetInt32("State");
			if (Tables.Count > 0)
			{
				CurrentView = Tables[CurrentRecordSet].DefaultView;
			}
		}

		/// <summary>
		///     Gets Object Data
		/// </summary>
		/// <param name="info">SerializationInfo</param>
		/// <param name="context">StreamingContext</param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("Sort", Sort);
			info.AddValue("LockType", (int)LockType);
			info.AddValue("ConnectionString", _connectionString);
			info.AddValue("Index", _index);
			info.AddValue("Factory", _factoryName);
			info.AddValue("NewRow", _newRow);
			info.AddValue("CurrentRecordSet", _currentRecordSet);
			info.AddValue("Eof", _eof);
			info.AddValue("State", _state);
		}

		#endregion

		#region Open Operations

		/// <summary>
		///     Performs a check to determine if the recordset is working disconnected
		/// </summary>
		/// <returns></returns>
		private bool SupportsDisconnectedRecordsetOperations
		{
			get
			{
				return (ActiveConnection == null && _activeCommand == null) ||
					   (ActiveConnection == null && _activeCommand != null &&
						_activeCommand.Connection == null);
			}
		}

		/// <summary>
		///     Opens the connection and initialize the RecordsetHelper object.
		/// </summary>
		public override void Open()
		{
			Open(false);
		}


		/// <summary>
		///     Opens the ADORecordsetHelper and requeries according to the value of �requery� parameter.
		/// </summary>
		/// <param name="requery">Indicates if a requery most be done.</param>
		public void Open(bool requery)
		{
			// This is done to support disconnected recordSet operations.
			if (SupportsDisconnectedRecordsetOperations)
			{
				//According to tests, in VB6 a disconnected recordset changes its state to LockBatchOptimistic when opened
				if (ActiveConnection == null && _activeCommand == null)
				{
					LockType = LockTypeEnum.LockBatchOptimistic;
				}
			}

			// base.Open(requery);

			if (!requery)
			{
				Validate();
			}
			if (_activeCommand == null && (_source is String))
			{
				List<DbParameter> parameters;
				CommandType commandType = getCommandType((string)_source, out parameters);
				_activeCommand = CreateCommand((string)_source, commandType, parameters);
			}
			if (ActiveConnection == null && _activeCommand != null)
			{
				if (_activeCommand.Connection == null)
					_activeCommand.Connection = GetConnection(ConnectionString);
				ActiveConnection = _activeCommand.Connection;
			}

			OpenRecordset(requery);
		}

		/// <summary>
		///     Opens the ADORecordsetHelper using an object Source.
		/// </summary>
		/// <param name="source">An object containing a Source of Data. It can be a DataSet, another ADORecordSetHelper or a string path.</param>
		public void Open(object source)
		{
			if (source is DataTable)
			{
				Tables.Clear();
				Tables.Add((DataTable)source);
				ResetVars();
			}
			else if (source is ADORecordSetHelper)
			{
				CloneIt((ADORecordSetHelper)source, this);
			}
			else if (source == null)
			{
				Tables.Clear();
				Tables.Add(new DataTable());
				ResetVars();
			}
			else if (source is string)
			{
				Tables.Clear();
				this.ReadXml((string)source, XmlReadMode.InferSchema);
			}
			else
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		///     Creates a DBCommand object using de provided parameters.
		/// </summary>
		/// <param name="commandText">A string containing the SQL query.</param>
		/// <param name="commandType">The desire type for the command.</param>
		/// <param name="parameters">A list with the parameters to be included on the DBCommand object.</param>
		/// <returns>A new DBCommand object.</returns>
		protected override DbCommand CreateCommand(String commandText, CommandType commandType, List<DbParameter> parameters)
		{
			Debug.Assert(_providerFactory != null, "Providerfactory must not be null");
			DbCommand command = _providerFactory.CreateCommand();
			switch (commandType)
			{
				case CommandType.StoredProcedure:
					string[] commandParts = commandText.Split(' ', ',');
					if (command != null)
					{
						command.CommandType = commandType;
						command.CommandText = commandParts[0];
						if (parameters != null && (parameters.Count == commandParts.Length - 1))
						{
							for (int i = 1; i < commandParts.Length; i++)
							{
								DbParameter parameter = parameters[i - 1];
								object value = commandParts[i];
								//conversions might be needed for various types
								//currently there is only a convertion for Guid types. New convertions will be added as needed
								if (parameter.DbType == DbType.Guid)
								{
									//Remove single quotes if present to avoid exception in Guid constructor
									string strValue = commandParts[i].Replace("'", "");
									value = new Guid(strValue);
								}
								parameter.Value = value;
							}
							command.Parameters.AddRange(parameters.ToArray());
						}
					}
					break;
				case CommandType.TableDirect:
					// Only OLEDB supports TableDirect
					// So we only ask for that type and on the rest of the cases
					// create a query
					string providerType = _providerFactory.GetType().ToString();
					if (providerType.StartsWith("System.Data.OleDb"))
					{

						goto default;
					}
					else
					{
						if (command != null)
						{
							command.CommandType = CommandType.Text;
							command.CommandText = "Select * from " + commandText;
						}
					}
					break;
				default:
					if (command != null)
					{
						command.CommandType = commandType;
						command.CommandText = commandText;
					}
					break;
			}
			return command;
		}

		/// <summary>
		///     Infers the command type from an SQL string getting the schema metadata from the database.
		/// </summary>
		/// <param name="sqlCommand">The sql string to be analyzed.</param>
		/// <param name="parameters">List of DbParameters</param>
		/// <returns>The command type</returns>
		protected override CommandType getCommandType(String sqlCommand, out List<DbParameter> parameters)
		{
			CommandType commandType = CommandType.Text;
			parameters = null;
			sqlCommand = sqlCommand.Trim();
			if (sqlCommand.StartsWith("select", StringComparison.InvariantCultureIgnoreCase) ||
				sqlCommand.StartsWith("insert", StringComparison.InvariantCultureIgnoreCase) ||
				sqlCommand.StartsWith("update", StringComparison.InvariantCultureIgnoreCase) ||
				sqlCommand.StartsWith("delete", StringComparison.InvariantCultureIgnoreCase) ||
				sqlCommand.StartsWith("exec", StringComparison.InvariantCultureIgnoreCase) ||
				sqlCommand.StartsWith("begin", StringComparison.InvariantCultureIgnoreCase) ||
				sqlCommand.StartsWith("set", StringComparison.InvariantCultureIgnoreCase) ||
				Regex.IsMatch(sqlCommand, @"^\s*\{\s*call ", RegexOptions.IgnoreCase))
			{
				commandType = CommandType.Text;
				return commandType;
			}
			String[] commandParts = sqlCommand.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			String objectQuery = String.Empty;
			DbConnection connection = GetConnection(_connectionString);
			if (connection.State != ConnectionState.Open)
			{
#if DBTrace
                    DBTrace.OpenWithTrace(connection);
#else
				connection.Open();
#endif
			}
			DataRow[] existingObjects;
			DataTable dbObjects = connection.GetSchema("Tables");
			try
			{
				if (dbObjects.Rows.Count > 0)
				{
					//this is an sql server connection
					if (dbObjects.Columns.Contains("table_catalog") && dbObjects.Columns.Contains("table_schema"))
					{
						if (commandParts.Length == 3)
						{
							objectQuery = "table_catalog = \'" + commandParts[0] + "\' AND table_schema = \'" + commandParts[1] +
										  "\' AND table_name = \'" + commandParts[2] + "\'";
						}
						else if (commandParts.Length == 2)
						{
							objectQuery = "table_schema = \'" + commandParts[0] + "\' AND table_name = \'" + commandParts[1] + "\'";
						}
						else
						{
							objectQuery = "table_name = \'" + commandParts[0] + "\'";
						}
					}
					else if (dbObjects.Columns.Contains("OWNER"))
					{
						if (commandParts.Length == 2)
						{
							objectQuery = "OWNER = \'" + commandParts[0] + "\' AND TABLE_NAME = \'" + commandParts[1] + "\'";
						}
						else
						{
							objectQuery = "TABLE_NAME = \'" + commandParts[0] + "\'";
						}
					}
					existingObjects = dbObjects.Select(objectQuery);
					if (existingObjects.Length > 0)
					{
						commandType = CommandType.TableDirect;
						return commandType;
					}
				}
				dbObjects = connection.GetSchema("Procedures");
			}
			catch (Exception ex)
			{
				Trace.TraceError("Provider error " + ex.Message);
				dbObjects = new DataTable();
			}
			// The query for looking for stored procedures information is version sensitive.
			// The database version can be verified in SQLServer using a query like "Select @@version"
			// That version can be mapped to the specific SQL Server Product Version with a table like the provided here: http://www.sqlsecurity.com/FAQs/SQLServerVersionDatabase/tabid/63/Default.aspx
			// The following code verifies columns for SQL Server version 2003, other versions might have a different schema and require changes
			if (dbObjects.Columns.Contains("procedure_catalog") && dbObjects.Columns.Contains("procedure_schema"))
			{
				if (commandParts.Length == 3)
				{
					objectQuery = "procedure_catalog = \'" + commandParts[0] + "\' AND procedure_schema = \'" + commandParts[1] +
								  " AND procedure_name = " + commandParts[2] +
								  "\'";
				}
				else if (commandParts.Length == 2)
				{
					objectQuery = "procedure_schema = \'" + commandParts[0] + "\' AND procedure_name = \'" + commandParts[1] + "\'";
				}
				else
				{
					objectQuery = "procedure_name = \'" + commandParts[0] + "\'";
				}
			}
			else if (dbObjects.Rows.Count > 0)
			{
				//this is an sql server connection
				if (dbObjects.Columns.Contains("specific_catalog") && dbObjects.Columns.Contains("specific_schema"))
				{
					if (commandParts.Length == 3)
					{
						objectQuery = "specific_catalog = \'" + commandParts[0] + "\' AND specific_schema = \'" + commandParts[1] +
									  " AND specific_name = " + commandParts[2] +
									  "\'";
					}
					else if (commandParts.Length == 2)
					{
						objectQuery = "specific_schema = \'" + commandParts[0] + "\' AND specific_name = \'" + commandParts[1] + "\'";
					}
					else
					{
						objectQuery = "specific_name = \'" + commandParts[0] + "\'";
					}
				}
				else if (dbObjects.Columns.Contains("OWNER"))
				{
					if (commandParts.Length == 2)
					{
						objectQuery = "OWNER = \'" + commandParts[0] + "\' AND OBJECT_NAME = \'" + commandParts[1] + "\'";
					}
					else
					{
						objectQuery = "OBJECT_NAME = \'" + commandParts[0] + "\'";
					}
				}
				existingObjects = dbObjects.Select(objectQuery);
				if (existingObjects.Length > 0)
				{
					commandType = CommandType.StoredProcedure;
					if (dbObjects.Columns.Contains("specific_catalog") && dbObjects.Columns.Contains("specific_schema"))
					{
						DataTable procedureParameters = connection.GetSchema("ProcedureParameters");
						DataRow[] theparameters =
							procedureParameters.Select(
								"specific_catalog = \'" + existingObjects[0]["specific_catalog"] + "\' AND specific_schema = \'" +
								existingObjects[0]["specific_schema"] +
								"' AND specific_name = '" + existingObjects[0]["specific_name"] + "\'",
								"ordinal_position ASC");
						if (theparameters.Length > 0)
						{
							parameters = new List<DbParameter>(theparameters.Length);
							foreach (DataRow paraminfo in theparameters)
							{
								DbParameter theParameter = _providerFactory.CreateParameter();
#if CLR_AT_LEAST_3_5
                                    theParameter.ParameterName = paraminfo.Field<string>("parameter_name");
                                    theParameter.DbType = MapToDbType(paraminfo.Field<string>("data_type"));
#else
								Debug.Assert(theParameter != null, "theParameter != null");
								theParameter.ParameterName = paraminfo["parameter_name"] as string;
								theParameter.DbType = MapToDbType(paraminfo["data_type"] as string);
#endif
								parameters.Add(theParameter);
							}
						}
					}
				}
			}
			try
			{
				if (synonymsTable == null)
				{
					DbCommand command = connection.CreateCommand();
					command.CommandText = "select base_object_name,name from sys.synonyms;";
					command.CommandType = CommandType.Text;
					DbDataReader reader = command.ExecuteReader();
					synonymsTable = new DataTable();
					synonymsTable.Load(reader);
				}

				DataRow dataRow = null;
				if (synonymsTable != null)
				{
					dataRow = synonymsTable.Select(string.Format("name = '{0}'", sqlCommand)).FirstOrDefault();
				}
				if (dataRow != null)
				{
					commandType = CommandType.TableDirect;
					return commandType;
				}
			}
			catch (Exception ex)
			{
				//Given scenario where sysnonyms is not accesible (Database different than SQLServer or database permissions) we are setting a default datatable.
				synonymsTable = new DataTable();
				Trace.TraceError("Sys.synonyms error " + ex.Message);
			}
			return commandType;
		}

		/// <summary>
		///     Opens this ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
		public void Open(LockTypeEnum lockType)
		{
			Validate();
			_lockType = lockType;
			Open();
		}

		/// <summary>
		///     Opens this ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="command">A command containing the query to be execute to load the ADORecordsetHelper object.</param>
		public void Open(DbCommand command)
		{
			Open(command, _lockType);
		}

		/// <summary>
		///     Opens this ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="connection">Connection object to be use by this ADORecordsetHelper</param>
		public void Open(DbConnection connection)
		{
			Open(connection, _lockType);
		}

		/// <summary>
		///     Opens this ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="str">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
		/// <param name="type">StringParameterType of the str.</param>
		public void Open(String str, StringParameterType type)
		{
			Validate();
			if (type == StringParameterType.Source)
			{
				if (File.Exists(str))
				{
					Open(str, PersistFormatEnum.adPersistBinary);
				}
				else
				{
					List<DbParameter> parameters;
					CommandType commandType = getCommandType(str, out parameters);
					Open(CreateCommand(str, commandType, parameters), _lockType);
				}
			}
			else
			{
				Open(GetConnection(str), _lockType);
			}
		}

		/// <summary>
		///     Open the information on the RecordsetHelper from a file.
		/// </summary>
		/// <param name="fullName">The full path name where to open the file.</param>
		/// <param name="persistFormat">The format type to open the file.</param>
		public void Open(string fullName, PersistFormatEnum persistFormat)
		{
			FileStream fs = new FileStream(fullName, FileMode.Open);
			Close();
			switch (persistFormat)
			{
				case (PersistFormatEnum.adPersistXML):
					{
						XmlReader xmlRead = XmlReader.Create(fs);
						XmlDocument xmlDoc = new XmlDocument();
						xmlDoc.ReadNode(xmlRead);
						break;
					}
				case (PersistFormatEnum.adPersistBinary):
					{
						DataTable loadedTable = new DataTable();
						using (System.IO.Compression.GZipStream zipStream = new System.IO.Compression.GZipStream(fs, System.IO.Compression.CompressionMode.Decompress))
						{
							loadedTable.ReadXml(zipStream);
						}
						Tables.Add(loadedTable);
						Tables[CurrentRecordSet].DataSet.RemotingFormat = SerializationFormat.Binary;
						Tables[CurrentRecordSet].RemotingFormat = SerializationFormat.Binary;
						break;
					}
			}
			ResetVars();
			fs.Close();
		}


		/// <summary>
		///     Opens this ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="command">A command containing the query to be execute to load the ADORecordsetHelper object.</param>
		/// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
		public void Open(DbCommand command, LockTypeEnum lockType)
		{
			Validate();
			_source = command;
			_activeCommand = command;
			Open(lockType);
		}

		/// <summary>
		///     Opens this ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
		/// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
		public void Open(DbConnection connection, LockTypeEnum lockType)
		{
			ActiveConnection = connection;
			Open(lockType);
		}

		/// <summary>
		///     Opens this ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="str">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
		/// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
		/// <param name="type">StringParameterType of the str.</param>
		public void Open(String str, LockTypeEnum lockType, StringParameterType type)
		{
			Validate();
			if (type == StringParameterType.Source)
			{
				List<DbParameter> parameters;
				CommandType commandType = getCommandType(str, out parameters);
				Open(CreateCommand(str, commandType, parameters), lockType);
			}
			else
			{
				Open(GetConnection(str), lockType);
			}
		}

		/// <summary>
		///     Opens this ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
		/// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
		public void Open(String sqLstr, DbConnection connection)
		{
			ActiveConnection = connection;
			List<DbParameter> parameters;
			CommandType commandType = getCommandType(sqLstr, out parameters);
			Open(CreateCommand(sqLstr, commandType, parameters));
		}

		/// <summary>
		///     Opens this ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
		/// <param name="connString">Strings that contains information about how to connect to the database.</param>
		/// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
		public void Open(String sqLstr, String connString, LockTypeEnum lockType)
		{
			Open(sqLstr, GetConnection(connString), lockType);
		}

		/// <summary>
		///     Opens this ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
		/// <param name="connString">Strings that contains information about how to connect to the database.</param>
		public void Open(String sqLstr, String connString)
		{
			Open(sqLstr, connString, LockTypeEnum.LockBatchOptimistic);
		}

		/// <summary>
		///     Opens this ADORecordsetHelper using the provided parameters.
		///     NOTE: It is better to provide the CommandType when executing the command
		///     If the command type is not given, performance would be affected due to several
		///     request to the DB schema
		/// </summary>
		/// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
		/// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
		/// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
		public void Open(String sqLstr, DbConnection connection, LockTypeEnum lockType)
		{
			ActiveConnection = connection;
			List<DbParameter> parameters;
			CommandType commandType = getCommandType(sqLstr, out parameters);
			Open(sqLstr, connection, lockType, commandType, parameters);
		}

		/// <summary>
		///     Opens this ADORecordsetHelper using the provided parameters.
		///     This is the preferred Open method for performance reasons. However this call might required
		///     some extra parameters like CommandType and ParameterList.
		///     For most scenerios just provide a null parameter for the parameter list;
		/// </summary>
		/// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
		/// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
		/// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
		/// <param name="commandType">The CommandType of this ADORecordsetHelper object.</param>
		/// <param name="parameters">The list of parameters.</param>
		public void Open(String sqLstr, DbConnection connection, LockTypeEnum lockType, CommandType commandType,
						 List<DbParameter> parameters)
		{
			// A RecordSet can be openned with a series of staments separated by ;. However each type an open is done, this collection is reseted */
			ActiveConnection = connection;
			Open(CreateCommand(sqLstr, commandType, parameters), lockType);
		}

		/// <summary>
		///     Creates a new ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
		/// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
		/// <param name="recordsAffected">Out parameter indicating the amount of records affected by the execution of the �SQLstr� query.</param>
		/// <param name="factoryName">The name of the factory to by use by this ADORecordsetHelper object (the name most exist on the configuration xml file).</param>
		/// <returns>The new ADORecordsetHelper object.</returns>
		public static ADORecordSetHelper Open(String sqLstr, DbConnection connection, out long recordsAffected,
											  String factoryName)
		{
			ADORecordSetHelper result = new ADORecordSetHelper(factoryName);
			result.Open(sqLstr, connection);
			recordsAffected = result.RecordCount;
			return result;
		}

		/// <summary>
		///     Creates a new ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
		/// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
		/// <param name="factoryName">The name of the factory to by use by this ADORecordsetHelper object (the name most exist on the configuration xml file).</param>
		/// <returns>The new ADORecordsetHelper object.</returns>
		public static ADORecordSetHelper Open(String sqLstr, DbConnection connection, String factoryName)
		{
			long recordsAffected;
			return Open(sqLstr, connection, out recordsAffected, factoryName);
		}

		/// <summary>
		///     Creates a new ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
		/// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
		/// <param name="factory">The DBProviderFactory to be used on the ADORecordsetHelper.</param>
		/// <returns>The new ADORecordsetHelper object.</returns>
		public static ADORecordSetHelper Open(String sqLstr, DbConnection connection, DbProviderFactory factory)
		{
			return Open(sqLstr, connection, factory);
		}

		/// <summary>
		///     Creates a new ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="command">A command containing the query to be execute to load the ADORecordsetHelper object.</param>
		/// <param name="factoryName">The name of the factory to by use by this ADORecordsetHelper object (the name most exist on the configuration xml file).</param>
		/// <returns></returns>
		public static ADORecordSetHelper Open(DbCommand command, String factoryName)
		{
			long recordsAffected;
			return Open(command, out recordsAffected, factoryName);
		}

		/// <summary>
		///     Creates a new ADORecordsetHelper using the provided parameters.
		/// </summary>
		/// <param name="command"></param>
		/// <param name="recordsAffected"></param>
		/// <param name="factoryName"></param>
		/// <returns></returns>
		public static ADORecordSetHelper Open(DbCommand command, out long recordsAffected, string factoryName)
		{
			ADORecordSetHelper recordSet = new ADORecordSetHelper(factoryName);
			recordSet.Open(command);
			recordsAffected = (recordSet.Tables.Count > 0) ? recordSet.RecordCount : 0;
			return recordSet;
		}


		/// <summary>
		/// Populates a recordsetHelper with the information defined in a XmlDocument.
		/// </summary>
		/// <param name="document">XmlDocument to load into the RecordsetHelper.</param>
		public void Open(XmlDocument document)
		{
			XmlStructure structure = XmlStructure.None;
			XmlDocument newXml = newDotNetXML(document);

			if (newXml.OuterXml.Contains("<xs:schema"))
			{
				structure = XmlStructure.Schema;
			}

			if (newXml.OuterXml.Contains("<Table>") && newXml.OuterXml.Contains("<row>"))
			{
				if (structure == XmlStructure.None)
				{
					structure = XmlStructure.Data;
				}
				else
				{
					structure = XmlStructure.Both;
				}
			}

			if (structure >= XmlStructure.Schema)
			{
				newXml = HandleConflictiveProperties(newXml);
			}

			StringReader sreader = null;
			XmlTextReader reader = null;
			try
			{
				_disconnected = true;
				sreader = new StringReader(newXml.OuterXml);
				reader = new XmlTextReader(sreader);

				_opened = true;

				switch (structure)
				{
					case XmlStructure.Data:
						ReadXml(reader, XmlReadMode.InferTypedSchema);
						break;

					case XmlStructure.Schema:
						ReadXml(reader, XmlReadMode.ReadSchema);
						LoadXMLData(document.GetElementsByTagName("rs:data")[0] as XmlElement);
						break;

					case XmlStructure.Both:
						ReadXml(reader, XmlReadMode.ReadSchema);
						ReadXml(reader, XmlReadMode.IgnoreSchema);
						LoadIgnoredColumns(); // it might be unneeded
						break;

					default:
						throw new Exception("unknown Xml structure.");
				}

				SetcolumnAttributes();
				ResetVars();
				MoveFirst();
				AcceptChanges();

			}
			catch
			{
			}
			finally
			{
				if (sreader != null)
				{
					sreader.Close();
				}
				if (reader != null)
				{
					reader.Close();
				}
			}
		}


        #endregion

        #region private Enums

		private enum ConflictivePropertiesEnum
		{
			Remove,
			positive,
			toString
		}

		private enum XmlStructure
		{
			None,
			Data,
			Schema,
			Both
		}
		#endregion
		#region private methods
		/// Removes all empty and conflictive properties from a XmlDocument
		/// </summary>
		/// <param name="newXml">an XmlDocument</param>
		/// <returns></returns>
		private XmlDocument HandleConflictiveProperties(XmlDocument newXml)
		{
			Dictionary<string, ConflictivePropertiesEnum> knownConflictiveProperties = new Dictionary<string, ConflictivePropertiesEnum>(){
													{ "msdata:AbsolutePosition",ConflictivePropertiesEnum.Remove },
													{ "msdata:AbsolutePage" , ConflictivePropertiesEnum.Remove},
													{ "msdata:SqlDeleteQuery" ,ConflictivePropertiesEnum.toString},
													{ "msdata:SqlSelectQuery" ,ConflictivePropertiesEnum.toString},
													{ "msdata:SqlQuery",ConflictivePropertiesEnum.toString },
													{ "msdata:Source",ConflictivePropertiesEnum.toString}
													};
			
			HandleXmlProperties(newXml.ChildNodes, knownConflictiveProperties);

			return newXml;
		}
		/// <summary>
		/// Removes properties names in filter and empty Xml properties
		/// </summary>
		/// <param name="nodelist"></param>
		/// <param name="filter"></param>
		private void HandleXmlProperties(XmlNodeList nodelist, Dictionary<string,ConflictivePropertiesEnum> filter)
		{

			foreach (XmlNode node in nodelist)
			{
                if (node.Attributes != null)
                {
					for (int i = 0; i < node.Attributes.Count;i++)
					{
						XmlAttribute prop = node.Attributes[i];

						if ((string.IsNullOrWhiteSpace(prop.Value) || filter.Keys.Contains(prop.Name)) && prop.Name != "xmlns")
						{
							ConflictivePropertiesEnum option = string.IsNullOrEmpty(prop.Value)? ConflictivePropertiesEnum.Remove: filter[prop.Name];

                            switch (option)
                            {
								case ConflictivePropertiesEnum.Remove:
									node.Attributes.Remove(prop);
									i--;
									break;
								case ConflictivePropertiesEnum.toString:
									PropertyInfo stringProp = this.GetType().GetProperty(prop.Name.Split(':')[1], BindingFlags.Public | BindingFlags.Instance);
									if (null != stringProp && stringProp.CanWrite)
									{
										stringProp.SetValue(this, prop.Value , null);
									}
									node.Attributes.Remove(prop);
									i--;
									break;
								case ConflictivePropertiesEnum.positive:
									//todo: positive number might solve this problem
									break;
                            }
							
						}
					}
				}

				HandleXmlProperties(node.ChildNodes, filter);
			}

		}
		/// <summary>
		/// Loads the ignored columns if schema and table were defined
		/// </summary>
		private void LoadIgnoredColumns()
		{
			foreach (KeyValuePair<string,List<XmlAttribute>> col in columnAttributes)
			{
				Type type = null;
				XmlAttribute AttType = col.Value.Find(att => att.Name == "type");
				if (AttType != null)
				{
					// target types taken from https://learn.microsoft.com/en-us/dotnet/api/system.data.datacolumn.datatype?view=net-7.0
					switch (AttType.Value)
					{
						// bool
						case "xs:boolean":
							type = typeof(bool);
							break;
						// byte
						case "xs:unsignedByte":
							type = typeof(byte);
							break;
						// char => pending to process
						/*
							<xs:element name="c3" minOccurs="0">
								<xs:simpleType>
									<xs:restriction base="xs:string">
										<xs:length value="1"/>
									</xs:restriction>
								</xs:simpleType>
							</xs:element>
						 */
						// DateTime
						case "xs:dateTime":
							type = typeof(DateTime);
							break;
						// decimal
						case "xs:decimal":
							type = typeof(decimal);
							break;
						// double
						case "xs:double":
							type = typeof(double);
							break;
						// guid => pending to process
						/*
							<xs:element name="c7" msdata:DataType="System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" type="xs:string" minOccurs="0"/>

						 */
						// Int16
						case "xs:short":
							type = typeof(Int16);
							break;
						// Int32
						case "xs:int":
							type = typeof(Int32);
							break;
						// Int64
						case "xs:long":
							type = typeof(Int64);
							break;
						// sbyte
						case "xs:byte":
							type = typeof(sbyte);
							break;
						// Single
						case "xs:float":
							type = typeof(Single);
							break;
						// string
						case "xs:string":
							type = typeof(string);
							break;
						// TimeSpan
						case "xs:duration":
							type = typeof(TimeSpan);
							break;
						// UInt16
						case "xs:unsignedShort":
							type = typeof(UInt16);
							break;
						// UInt32
						case "xs:unsignedInt":
							type = typeof(UInt32);
							break;
						// UInt64
						case "xs:unsignedLong":
							type = typeof(UInt64);
							break;
						// byte[]
						// case "xs:base64Binary":
						default:
							type = typeof(byte[]);
							break;
					}

				}

				DataColumn column = CurrentView.Table.Columns.Contains(col.Key) ? CurrentView.Table.Columns[col.Key] : CurrentView.Table.Columns.Add(col.Key, type);
				foreach (XmlAttribute att in col.Value)
				{
					switch (att.Name)
					{
						case "nillable":
							column.AllowDBNull = bool.Parse(att.Value);
							break;
					}
				}
			}
		}


		/// <summary>
		/// Handles all attributes gathered in newDotNetXML method that could't be transformed in an XML attribute.
		/// </summary>
		private void SetcolumnAttributes()
		{

			List<DataColumn> x = new List<DataColumn>();
			foreach (DataColumn column in FieldsMetadata)
			{
				if (columnAttributes.ContainsKey(column.ColumnName))
				{
					foreach (XmlAttribute xmlAtt in columnAttributes[column.ColumnName])
					{
						// Add any necessary case here 
						switch (xmlAtt.Name)
						{
							case "rs:hidden":
								column.ColumnMapping = MappingType.Hidden;
								break;
						}
					}
				}
			}


		}

		/// <summary>
		/// Recieves a XMLElement to add its childs in the current table rows.
		/// </summary>
		/// <param name="DataRows">xml element with row elements</param>
		private void LoadXMLData(XmlElement DataRows)
		{
			if (DataRows != null) 
			{ 
				foreach (XmlElement row in DataRows.ChildNodes)
				{
					DataRow newRow = CurrentView.Table.NewRow();
					List<object> itemArray = new List<object>();
					int columnsnulled = 0;
					for (int i = 0; i < FieldsMetadata.Count; i++)
					{
						object val = null;
						if (FieldsMetadata[i].ColumnName == row.Attributes[i - columnsnulled].Name)
						{
							val = row.Attributes[i - columnsnulled].Value;
						}
						else
						{ // it keeps each metadata aligned to its correspondent attribute
							FieldsMetadata[i].AllowDBNull = true;
							columnsnulled++;
						}
						itemArray.Add(val);
					}
					newRow.ItemArray = itemArray.ToArray();
					CurrentView.Table.Rows.Add(newRow);
				}
			}
		}

		/// <summary>
		/// returns a xml template of an XMLSchema
		/// URL: https://www.w3schools.com/xml/schema_intro.asp
		/// </summary>
		/// <returns></returns>
		private string XmlSchemaTemplate()
		{
			return "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">" +
					"	<xs:element name = \"root\"> " +
					"		<xs:complexType>" +
					"			<xs:sequence>" +
					"				<xs:element name = \"row\" maxOccurs = \"unbounded\">" +
					"					<xs:complexType>" +
					"						<xs:sequence>" +
					"						</xs:sequence>" +
					"					</xs:complexType>" +
					"				</xs:element>" +
					"			</xs:sequence>" +
					"		</xs:complexType>" +
					"	</xs:element>" +
					"</xs:schema>";

		}
		/// <summary>
		/// Tranforms a not valid xml into a valid if its needed.
		/// </summary>
		/// <param name="document">xml document to analyze</param>
		/// <returns>XmlDocument</returns>
		private XmlDocument newDotNetXML(XmlDocument document)
		{
			var xml = new XmlDocument();
			bool shouldBeTansformed = false;
			if (document.GetElementsByTagName("xml").Count > 0)
			{
				// it could be replace with contains method, however it usually has a few attributes and it doesn't take too much time
				foreach (XmlAttribute att in (document.GetElementsByTagName("xml")[0] as XmlElement).Attributes)
				{
					if (att.Value == "urn:schemas-microsoft-com:rowset")
					{
						shouldBeTansformed = true;
						break;
					}

				}
				// if there are other ways to initialize a database with a schema or data its important to update
				// this logic to work with a enum and make it able to infer what type of transformation it will need. 
				if (shouldBeTansformed)
				{
					xml.LoadXml(XmlSchemaTemplate());
					// we are interested in the second sequence, check the template.
					XmlElement sequence = (XmlElement)xml.GetElementsByTagName("xs:sequence").Item(1);

					foreach (XmlElement data in document.GetElementsByTagName("s:ElementType")[0].ChildNodes)
					{
						string name = "";
						XmlElement field = xml.CreateElement("xs", "element", "http://www.w3.org/2001/XMLSchema");

						foreach (XmlAttribute att in data.Attributes)
						{
							XmlAttribute tempAtt = null;
							switch (att.Name.ToLower())
							{

								case "name":
									tempAtt = xml.CreateAttribute(att.Name);
									tempAtt.Value = att.Value;
									name = att.Value;
									columnAttributes.Add(name, new List<XmlAttribute>());
									field.Attributes.Append(tempAtt);
									break;

								default:
									tempAtt = xml.CreateAttribute(att.Name);
									tempAtt.Value = att.Value;
									if (columnAttributes.ContainsKey(name))
										columnAttributes[name].Add(att);
									break;

							}
						}

						// Each element in a urn:schemas-microsoft-com:rowset has an internal child with more attributes.
						// The most important is "type" attribute because is mandatory in a xs:element.
						foreach (XmlElement child in data.ChildNodes)
						{
							foreach (XmlAttribute att in child.Attributes)
							{
								XmlAttribute tempAtt = null;
								switch (att.Name.ToLower())
								{
									case "dt:type":
										tempAtt = xml.CreateAttribute("type");
										switch (att.Value)
										{
											case "number":
												tempAtt.Value = "xs:decimal";
												break;
											default:
												tempAtt.Value = "xs:" + att.Value;
												break;
										}

										field.Attributes.Append(tempAtt);
										break;

									case "rs:maybenull":
										tempAtt = xml.CreateAttribute("nillable");
										tempAtt.Value = att.Value;
										field.Attributes.Append(tempAtt);
										break;
									default:
										tempAtt = xml.CreateAttribute(att.Name);
										tempAtt.Value = att.Value;
										if (columnAttributes.ContainsKey(name))
											columnAttributes[name].Add(att);
										break;
								}
							}
						}

						if (field.Attributes.Count > 0)
							sequence.AppendChild(field);
					}
				}
			}
			else
			{
				xml = document;

				//Let's just leave the necessary nodes
				XmlDocument cleanDocument = new XmlDocument();
				XmlNode newBody = xml.GetElementsByTagName("xs:schema")[0];
				if (newBody == null)
				{
					newBody = xml.GetElementsByTagName("Table")[0];
				}

				if (newBody.ParentNode != null)
				{
					cleanDocument.LoadXml(newBody.ParentNode.OuterXml);
					xml = cleanDocument;
				}				
			}

			return xml;
		}


		/// <summary>
		/// Determines if a command executes an stored procedure.
		/// If the command type is explicit or if its type is 'Text' and calls 'exec' or 'execute' the return value is true.
		/// </summary>
		/// <param name="command">Command.</param>
		/// <returns>Boolean value indicating if the command is a stored procedure.</returns>
		private bool IsStoredProcedure(DbCommand command)
		{
			return command.CommandType == CommandType.StoredProcedure || (command.CommandType == CommandType.Text && Regex.IsMatch(command.CommandText, @"(exec|execute)\s+", RegexOptions.IgnoreCase));
		}

		/// <summary>
		///     Sets the primary key to a DataTable object.
		/// </summary>
		/// <param name="dataTable">The DataTable that holds the currently loaded data.</param>
		private void FixAutoincrementColumns(DataTable dataTable)
		{
			if (ActiveConnection is SqlConnection)
			{
				foreach (DataColumn col in dataTable.Columns)
				{
					if (col.AutoIncrement)
					{
						col.AutoIncrementSeed = 0;
						col.AutoIncrementStep = -1;
						col.ReadOnly = false;
						_hasAutoincrementCols = true;
						// todo check multiple autoincrement cases
						_autoIncrementCol = col.ColumnName;
						break;
					}
				}
			}
		}

		/// <summary>
		///
		/// </summary>
		private void OnNewRecord()
		{
			if (NewRecord != null)
			{
				NewRecord(this, new EventArgs());
			}
		}

		/// <summary>
		///     Verifies that no more data is pending on the ADORecordsetHelper.
		/// </summary>
		private void EndOfRecordsetLogic()
		{
			bool moredata = false;
			OnEndOfRecordset(ref moredata, EventStatusEnum.adStatusOK);
			if (!moredata)
			{

				_index = -1;
			}
			else
			{
				_eof = false;
			}
		}

		/// <summary>
		///     Move the current record according to the value of �records�.
		/// </summary>
		/// <param name="records">The number of records to move forward (if positive), backwards (if negative).</param>
		/// <param name="reason">The reason of the change.</param>
		/// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
		private void Move(int records, EventReasonEnum reason, EventStatusEnum status)
		{
			OnWillMove(reason, ref status);
			if (BeforeMove != null)
				BeforeMove(this, new EventArgs());
			string[] errors = null;
			if (status != EventStatusEnum.adStatusCancel)
			{
				try
				{
					if (records != 0 && _index >= 0 && !isBatchEnabled())
					{
						Update(false);
					}
					int newIndex = _index + records;
					if (EOF && reason == EventReasonEnum.adRsnMovePrevious)
					{
						newIndex = GetTable().Rows.Count - 1;
					}
					BasicMove(newIndex, reason);
					if (_eof && reason != EventReasonEnum.adRsnMoveFirst && reason != EventReasonEnum.adRsnMovePrevious)
					{
						EndOfRecordsetLogic();
					}
					//else
					//{
					//    eof = false;
					//}
				}
				catch (Exception e)
				{
					errors = new string[] { e.Message };
					status = EventStatusEnum.adStatusErrorsOccurred;
				}
				OnMoveComplete(reason, ref status, errors);
			}
		}

		/// <summary>
		///     Move the current record to the beginning of the ADORecordsetHelper object.
		/// </summary>
		/// <param name="reason">The reason of the change.</param>
		private void MoveFirst(EventReasonEnum reason)
		{
			if (_index == -1)
			{
				_index = 0;
			}
			Move((-1 * _index), reason, EventStatusEnum.adStatusOK);
		}

		/// <summary>
		///     Saves the current content of the ADORecordsetHelper to the database.
		/// </summary>
		/// <param name="reportMove">Bool flag that indicates if this operation will notify others process raising an event or not.</param>
		private void Update(bool reportMove)
		{
			// This is done to support disconnected recordSet operations.
			if (SupportsDisconnectedRecordsetOperations)
			{
				if (UsingView && _dbvRow != null)
				{
					CurrentView.Table.DataSet.EnforceConstraints = true;
					_dbvRow.EndEdit();
					_index = findBookmarkIndex(_dbvRow.Row);
				}
				else
				{
					this.EnforceConstraints = true;
				}
				_newRow = false;
				AcceptChanges();
				return;
			}

			Exception exceptionToThrow = null;
			EventStatusEnum status = EventStatusEnum.adStatusOK;
			string[] errors = null;
			OnWillChangeRecordset(EventReasonEnum.adRsnMove, ref status);
			if (status != EventStatusEnum.adStatusCancel)
			{
				DataRow theRow = CurrentRow;
				_newRow = false;
				theRow.EndEdit();
				if (theRow.RowState != DataRowState.Unchanged)
				{
					if (!isBatchEnabled())
					{
						if (UsingView)
						{
							CurrentView.Table.DataSet.EnforceConstraints = true;
							_dbvRow.EndEdit();
							_index = findBookmarkIndex(_dbvRow.Row);
						}
						else
						{
							this.EnforceConstraints = true;
						}
						status = EventStatusEnum.adStatusOK;
						OnWillChangeRecord(EventReasonEnum.adRsnUpdate, ref status, 1);
						if (status != EventStatusEnum.adStatusCancel)
						{
							try
							{
								UpdateWithNoEvents(theRow);
								_editMode = EditModeEnum.EditNone;
							}
							catch (Exception e)
							{
								errors = new string[] { e.Message };
								exceptionToThrow = e;
							}
							OnRecordChangeComplete(EventReasonEnum.adRsnUpdate, ref status, 1, errors);
						}
					}
				}
				OnRecordsetChangeComplete(EventReasonEnum.adRsnMove, ref status, errors);
				if (exceptionToThrow != null)
				{
					throw exceptionToThrow;
				}
				if (reportMove)
				{
					Move(0, EventReasonEnum.adRsnMove, EventStatusEnum.adStatusOK);
				}
			}
		}

		/// <summary>
		///     Sets default values to a fields to avoid insert null in the DB when the field does not accept it.
		/// </summary>
		private void AssignDefaultValues(DataRow dbRow)
		{
			DbDataAdapter adapter = null;
			try
			{
				_requiresDefaultValues = false;
				if (_defaultValues == null) //no default values loaded for this table
				{
					DataTable schemaTable = null;
					try
					{
						adapter = CreateAdapter(GetConnection(ConnectionString), true);
                        if (adapter.SelectCommand == null) return;
                        string tablename = getTableName(adapter.SelectCommand.CommandText, true).Replace("dbo.", string.Empty);
                        if (TransactionManager.GetCurrentTransaction(ActiveConnection) == null)
						{
							schemaTable = ActiveConnection.GetSchema("Columns", new string[] { null, null, tablename, null });
						}
						else
						{
							string sqlSchema = string.Empty;
							if (ActiveConnection is System.Data.Odbc.OdbcConnection)
							{
								sqlSchema = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = ?;";
							}
							else if (ActiveConnection is SqlConnection)
							{
								sqlSchema = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @tablename;";
							}
							else
							{
								throw new Exception("GetShema not implemented for type of connection");
							}
							// We create a new command since we cannot use the method GetSchema while in a Transaction

							// Create the command.
							DbCommand command = ActiveConnection.CreateCommand();
							command.CommandText = sqlSchema;
							command.CommandType = CommandType.Text;
							command.Transaction = TransactionManager.GetCurrentTransaction(ActiveConnection);
							DbParameter dbParameter = command.CreateParameter();
							dbParameter.ParameterName = "@tablename";
							dbParameter.Value = tablename;
							dbParameter.DbType = DbType.String;
							command.Parameters.Add(dbParameter);

							// Open the connection.
							if (ActiveConnection.State == ConnectionState.Closed)
							{
								ActiveConnection.Open();
							}

							// Retrieve the data.
							DbDataReader reader = command.ExecuteReader();
							schemaTable = new DataTable();
							schemaTable.Load(reader);

						}
					}
					catch (Exception exc)
					{
						return;
						//throw e;
					}

					//Preloaded with the number  of elements required
					_defaultValues = new List<KeyValuePair<bool, object>>();
					DataColumnCollection columnInfo = UsingView ? CurrentView.Table.Columns : Tables[CurrentRecordSet].Columns;
					for (int i = 0; i < columnInfo.Count; i++)
					{
						object columnDefaultValue = columnInfo[i].DataType.IsValueType ? Activator.CreateInstance(columnInfo[i].DataType) : null;
						_defaultValues.Add(new KeyValuePair<bool, object>(false, columnDefaultValue));
					}
					string defaultValue = String.Empty;
					bool isComputed = false;
					bool isUnknown = false;
					for (int i = 0; i < schemaTable.Rows.Count; i++)
					{
						int thisColumnIndex = columnInfo.IndexOf(Convert.ToString(schemaTable.Rows[i]["COLUMN_NAME"]));
						if (thisColumnIndex < 0) continue;

						//13 Maximun length
						if (columnInfo[thisColumnIndex].DataType == typeof(string))
						{
							int maxLength = 255;
							string columnMaximumLengthName = this.GetColumnSizeAttributeNameOnSchema();
							if (schemaTable.Rows[i][columnMaximumLengthName] != DBNull.Value)
							{
								if (!int.TryParse(schemaTable.Rows[i][columnMaximumLengthName].ToString(), out maxLength))
								{
									maxLength = int.MaxValue;
								}
								if (maxLength == 0)
								{
									maxLength = int.MaxValue;
								}
							}
							columnInfo[thisColumnIndex].MaxLength = maxLength;
						}

						object originalValue = dbRow[thisColumnIndex];
						string columnDefaultSchemaName = this.GetColumnDefaultAttributeNameOnSchema();
						if (schemaTable.Rows[i][columnDefaultSchemaName] != DBNull.Value) //Has default value
						{
							defaultValue = (string)schemaTable.Rows[i][columnDefaultSchemaName]; //8 Default Value
							if (columnInfo[thisColumnIndex].DataType == typeof(bool))
							{
								defaultValue = defaultValue.Trim(new char[] { '=', '(', ')', '\'' });
								bool defaultvalue;
								bool.TryParse(defaultValue, out defaultvalue);
								dbRow[thisColumnIndex] = defaultvalue;
							}
							else
							{
								try
								{
									dbRow[thisColumnIndex] = ComputeValue(defaultValue);
									isComputed = true;

								}
								catch
								{
									try
									{
										string partialResult = (defaultValue.Trim(new char[] { '(', ')', '\'' }));
										if (columnInfo[thisColumnIndex].MaxLength != -1) //is string
											dbRow[thisColumnIndex] = partialResult.Length > columnInfo[thisColumnIndex].MaxLength
																		 ? partialResult.Substring(0, columnInfo[thisColumnIndex].MaxLength)
																		 : partialResult;
										else
											dbRow[thisColumnIndex] = partialResult;
									}
									catch
									{
										isUnknown = true;
									}
								}
							}
						}
						else
						{
							object isNullable = schemaTable.Rows[i]["IS_NULLABLE"];
							bool tmpRes;
							if (!columnInfo[thisColumnIndex].AllowDBNull ||
								(isNullable != null && (string.Equals(Convert.ToString(isNullable), "No", StringComparison.InvariantCultureIgnoreCase)
								|| (bool.TryParse(Convert.ToString(isNullable), out tmpRes) && !tmpRes))))
							//Not Allow Null and has not default value
							{
								//Add more if necesary
								if (columnInfo[thisColumnIndex].DataType == typeof(string))
									dbRow[thisColumnIndex] = string.Empty;
								else if (columnInfo[thisColumnIndex].DataType == typeof(Int16))
									dbRow[thisColumnIndex] = default(Int16);
								else if (columnInfo[thisColumnIndex].DataType == typeof(Int32))
									dbRow[thisColumnIndex] = default(Int32);
								else if (columnInfo[thisColumnIndex].DataType == typeof(bool))
									dbRow[thisColumnIndex] = default(bool);
								else if (columnInfo[thisColumnIndex].DataType == typeof(decimal))
									dbRow[thisColumnIndex] = default(decimal);
								else if (columnInfo[thisColumnIndex].DataType == typeof(byte))
									dbRow[thisColumnIndex] = default(byte);
								else if (columnInfo[thisColumnIndex].DataType == typeof(char))
									dbRow[thisColumnIndex] = default(char);
							}
							else
								dbRow[thisColumnIndex] = DBNull.Value;
						}
						if (isComputed)
						{
							_defaultValues[thisColumnIndex] = new KeyValuePair<bool, object>(true, defaultValue);
							isComputed = false;
						}
						else if (isUnknown)
						{
							_defaultValues[thisColumnIndex] = new KeyValuePair<bool, object>(false, DBNull.Value);
							isUnknown = false;
						}
						else
							_defaultValues[thisColumnIndex] = new KeyValuePair<bool, object>(false, dbRow[thisColumnIndex]);

						if (originalValue != DBNull.Value)
							dbRow[thisColumnIndex] = originalValue;
					}
				}
				else //already _defaultValues has been created
				{
					try
					{
						dbRow.BeginEdit();
						for (int i = 0; i < _defaultValues.Count; i++)
						{
							if (dbRow[i] == DBNull.Value)
							{
								if (!_defaultValues[i].Key)
									dbRow[i] = _defaultValues[i].Value;
								else
									dbRow[i] = ComputeValue((string)_defaultValues[i].Value);
							}
						}
					}
					finally
					{
						dbRow.EndEdit();
					}
				}
			}
			finally
			{
				if (!IsCachingAdapter && adapter != null)
				{
					this.Dispose(adapter);
				}
			}
		}
		/// <summary>
		/// Set a new default value if the primary key of a table is DBNull
		/// </summary>
		/// <param name="table">Table to analize</param>
		private void setDefaultValueToPrimaryKeys(DataTable table)
		{
			foreach (DataColumn key in table.PrimaryKey)
			{
				if (key.DefaultValue is DBNull)
				{
					switch (key.DataType.FullName)
					{
						case StringFullName:
							key.DefaultValue = string.Empty;
							break;
						default:
							key.DefaultValue = Activator.CreateInstance(key.DataType);
							break;
					}
				}
			}
		}

		/// <summary>
		/// Return the respective column value for the column character size depending on connection type
		/// </summary>
		public string GetColumnSizeAttributeNameOnSchema()
		{
			string connectionType = this.ActiveConnection.GetType().Name;

			switch (connectionType)
			{
				case "OdbcConnection":
					return "COLUMN_SIZE";
				default:
					return "CHARACTER_MAXIMUM_LENGTH";
			}
		}

		/// <summary>
		/// Return the respective column value for the column default value depending on connection type
		/// </summary>
		public string GetColumnDefaultAttributeNameOnSchema()
		{
			string connectionType = this.ActiveConnection.GetType().Name;

			switch (connectionType)
			{
				case "OdbcConnection":
					return "COLUMN_DEF";
				default:
					return "COLUMN_DEFAULT";
			}
		}

		#endregion

		#region protected methods

		/// <summary>
		///     iterate fields, to assign current row the values for each specific fields
		/// </summary>
		/// <param name="fields">array of fields</param>
		/// <param name="values">array of values</param>
		/// <param name="isString">is string the field items</param>
		/// <param name="currentValues">has the current values</param>
		/// <returns>the row with the assigned values on each field</returns>
		protected object[] iterateFields(object[] fields, object[] values, bool isString, bool currentValues)
		{
			object[] thevalues = values;
			for (int i = 0; i < fields.Length; i++)
			{
				if (!currentValues)
				{
					if (isString)
					{
						CurrentRow[(String)fields[i]] = values[i];
					}
					else
					{
						CurrentRow[(int)fields[i]] = values[i];
					}
				}
				else
				{
					thevalues = new object[fields.Length];
					if (isString)
					{
						thevalues[i] = CurrentRow[(String)fields[i]];
					}
					else
					{
						thevalues[i] = CurrentRow[(int)fields[i]];
					}
				}
			}
			return thevalues;
		}

		/// <summary>
		///     Indicates if the ADORecordsetHelper is in batch mode.
		/// </summary>
		/// <returns>True if the ADORecordsetHelper is in batch mode, otherwise false.</returns>
		protected override bool isBatchEnabled()
		{
			return _lockType == LockTypeEnum.LockBatchOptimistic && _cursorLocation == CursorLocationEnum.adUseClient;
		}

		/// <summary>
		///     Indicates if the ADORecordsetHelper is in Optimistic mode.
		/// </summary>
		/// <returns>True if the ADORecordsetHelper is in Optimistic mode, otherwise false.</returns>
		private bool isLockEnabled()
		{
			return _lockType == LockTypeEnum.LockOptimistic && _cursorLocation == CursorLocationEnum.adUseClient;
		}

		/// <summary>
		///     Verifies if the ADORecordset object have been open.
		/// </summary>
		protected void Validate()
		{
			if (_opened)
			{
				if (SupportsDisconnectedRecordsetOperations)
				{
					/* OK */
				}
				else if (!_isClone)
				{
					throw new InvalidOperationException("The recordSet is already open");
				}
			}
		}


		/// <summary>
		///     The EndOfRecordset event is called when there is an attempt to move to a row past the end of the Recordset.
		/// </summary>
		/// <param name="moredata">Bool value that indicates if more data have been added to the ADORecordsetHelper.</param>
		/// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
		protected void OnEndOfRecordset(ref bool moredata, EventStatusEnum status)
		{
			if (EndOfRecordset != null)
			{
				EndOfRecordsetEventArgs eor = new EndOfRecordsetEventArgs(moredata, status);
				EndOfRecordset(this, eor);
				moredata = eor.MoreData;
			}
		}

		/// <summary>
		///     The WillChangeField event is called before a pending operation changes the value of one or more Field objects in the ADORecordsetHelper.
		/// </summary>
		/// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
		/// <param name="numfields">Indicates the number of fields objects contained in the �fieldvalues� array.</param>
		/// <param name="fieldvalues">Array with the new values of the modified fields.</param>
		protected void OnWillChangeField(ref EventStatusEnum status, int numfields, object[] fieldvalues)
		{
			if (WillChangeField != null)
			{
				FieldChangeEventArgs args = new FieldChangeEventArgs(numfields, fieldvalues, status);
				WillChangeField(this, args);
				status = args.Status;
			}
		}

		/// <summary>
		///     The FieldChangeComplete event is called after the value of one or more Field objects has changed.
		/// </summary>
		/// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
		/// <param name="numfields">Indicates the number of fields objects contained in the �fieldvalues� array.</param>
		/// <param name="fieldvalues">Array with the new values of the modified fields.</param>
		/// <param name="errors">Array containing all the errors occurred during the field change.</param>
		protected void OnFieldChangeComplete(ref EventStatusEnum status, int numfields, object[] fieldvalues, string[] errors)
		{
			if (FieldChangeComplete != null)
			{
				FieldChangeCompleteEventArgs args = new FieldChangeCompleteEventArgs(numfields, fieldvalues, errors, status);
				FieldChangeComplete(this, args);
				status = args.Status;
			}
		}

		/// <summary>
		///     The OnWillChangeRecord event is called before one or more records (rows) in the Recordset change.
		/// </summary>
		/// <param name="reason">The reason of the change.</param>
		/// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
		/// <param name="numRecords">Value indicating the number of records changed (affected).</param>
		protected void OnWillChangeRecord(EventReasonEnum reason, ref EventStatusEnum status, int numRecords)
		{
			if (WillChangeRecord != null)
			{
				RecordChangeEventArgs args = new RecordChangeEventArgs(reason, numRecords, status);
				WillChangeRecord(this, args);
				status = args.Status;
			}
		}

		/// <summary>
		///     OnRecordChangeComplete event is called after one or more records change.
		/// </summary>
		/// <param name="reason">The reason of the change.</param>
		/// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
		/// <param name="numRecords">Value indicating the number of records changed (affected).</param>
		/// <param name="errors">Array containing all the errors occurred during the field change.</param>
		protected void OnRecordChangeComplete(EventReasonEnum reason, ref EventStatusEnum status, int numRecords,
											  string[] errors)
		{
			if (RecordChangeComplete != null)
			{
				RecordChangeCompleteEventArgs args = new RecordChangeCompleteEventArgs(reason, numRecords, errors, status);
				RecordChangeComplete(this, args);
				status = args.Status;
			}
		}

		/// <summary>
		///     OnWillChangeRecordset event is called before a pending operation changes the ADORecordsetHelper.
		/// </summary>
		/// <param name="reason">The reason of the change.</param>
		/// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
		protected void OnWillChangeRecordset(EventReasonEnum reason, ref EventStatusEnum status)
		{
			if (WillChangeRecordset != null)
			{
				RecordSetChangeEventArgs args = new RecordSetChangeEventArgs(reason, status);
				WillChangeRecordset(this, args);
				status = args.Status;
			}
		}

		/// <summary>
		///     OnRecordsetChangeComplete event is called after the ADORecordsetHelper has changed.
		/// </summary>
		/// <param name="reason">The reason of the change.</param>
		/// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
		/// <param name="errors">Array containing all the errors occurred during the field change.</param>
		protected void OnRecordsetChangeComplete(EventReasonEnum reason, ref EventStatusEnum status, string[] errors)
		{
			if (RecordsetChangeComplete != null)
			{
				RecordSetChangeCompleteEventArgs args = new RecordSetChangeCompleteEventArgs(reason, errors, status);
				RecordsetChangeComplete(this, args);
				status = args.Status;
			}
		}

		/// <summary>
		///     OnWillMove event is called before a pending operation changes the current position in the ADORecordsetHelper.
		/// </summary>
		/// <param name="reason">The reason of the change.</param>
		/// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
		protected void OnWillMove(EventReasonEnum reason, ref EventStatusEnum status)
		{
			_firstChange = true;
			if (WillMove != null)
			{
				MoveEventArgs args = new MoveEventArgs(reason, status);
				WillMove(this, args);
				status = args.Status;
				_firstChange = status != EventStatusEnum.adStatusCancel;
			}
		}

		/// <summary>
		///     OnMoveComplete event is called after the current position in the ADORecordsetHelper changes.
		/// </summary>
		/// <param name="reason">The reason of the change.</param>
		/// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
		/// <param name="errors">Array containing all the errors occurred during the field change.</param>
		protected void OnMoveComplete(EventReasonEnum reason, ref EventStatusEnum status, string[] errors)
		{
			if (MoveComplete != null)
			{
				MoveCompleteEventArgs args = new MoveCompleteEventArgs(reason, errors, status);
				MoveComplete(this, args);
				status = args.Status;
			}
		}


		/// <summary>
		///     Performs the basic move operation on the ADORecordsetHelper, moving the current record forward or backwards.
		/// </summary>
		/// <param name="newIndex">The index of the new position for the current record.</param>
		/// <param name="reason">The type of Move to perform.</param>
		protected void BasicMove(int newIndex, EventReasonEnum reason)
		{
			_currentRowDeleted = false;
			_index = newIndex;
			if (!BOF && !IsEof() && (CurrentRow.RowState == DataRowState.Deleted || CurrentRow.RowState == DataRowState.Detached))
			{
				bool rowFound = false;
				if (reason != EventReasonEnum.adRsnMovePrevious)
				{
					for (int i = _index + 1; i < Tables[CurrentRecordSet].Rows.Count; i++)
					{
						if (Tables[CurrentRecordSet].Rows[i].RowState != DataRowState.Deleted && Tables[CurrentRecordSet].Rows[i].RowState != DataRowState.Detached)
						{
							_index = i;
							rowFound = true;
							break;
						}
					}
					if (!rowFound) _index = Tables[CurrentRecordSet].Rows.Count;
				}
				else
				{
					for (int i = _index - 1; i >= 0; i--)
					{
						if (Tables[CurrentRecordSet].Rows[i].RowState != DataRowState.Deleted && Tables[CurrentRecordSet].Rows[i].RowState != DataRowState.Detached)
						{
							_index = i;
							rowFound = true;
							break;
						}
					}
					if (!rowFound) _index = -1;
				}
			}
			else
			{
				OnAfterMove();
			}
			_eof = IsEof();
		}

		/// <summary>
		///     Saves any changes made to the DataRow recieved as parameter.
		/// </summary>
		/// <param name="theRow">The row to be save on the Database.</param>
		protected void UpdateWithNoEvents(DataRow theRow)
		{
			if (theRow.RowState != DataRowState.Unchanged)
			{
				if (!isBatchEnabled())
				{
					DbConnection connection = GetConnection(ConnectionString);
					DbDataAdapter dbAdapter = null;
					try
					{
						bool isUpdateable = true;

						if (Filter != null && Filter is string)
						{
							DataRow[] tempRows = CurrentView.Table.Select(Filter as string);
							isUpdateable = tempRows.Contains(theRow);
						}


						if (isUpdateable)
						{
							dbAdapter = CreateAdapter(connection, true);
							if (_requiresDefaultValues)
								AssignDefaultValues(theRow);

							dbAdapter.Update(new DataRow[] { theRow });
						}
					}
					finally
					{
						if (!IsCachingAdapter)
						{
							this.Dispose(dbAdapter);
						}
					}
				}
			}
		}

        /// <summary>
        ///     Returns the ActiveConnection object if it has been initialized otherwise creates a new DBConnection object.
        /// </summary>
        /// <param name="connectionString">The connection string to be used by the connection.</param>
        /// <returns>A DBConnection containing with the connection string set. </returns>
        [Obsolete("This Method is Deprecated")]
        protected virtual DbConnection GetConnection(String connectionString)
		{
			if (ActiveConnection != null &&
				ActiveConnection.ConnectionString.Equals(connectionString, StringComparison.InvariantCultureIgnoreCase))
			{
				return ActiveConnection;
			}
#if DBTrace
            DbConnection connection = DBTrace.CreateConnectionWithTrace(providerFactory);
#else
			DbConnection connection = null;

			if (_providerFactory == null)
			{
				Debug.WriteLine("No provider factory was given, getting default");
				_providerFactory = AdoFactoryManager.GetFactory(null);
			}

			connection = _providerFactory.CreateConnection();
#endif
			if (connection != null)
			{
				connection.ConnectionString = connectionString;
				return connection;
			}
			return null;
		}

		/// <summary>
		/// Using connection parameter creates a Database Data Adapter
		/// </summary>
		/// <param name="connection">DbConnection parameter</param>
		/// <param name="updating">if updating creates all internal query strings</param>
		/// <returns></returns>
        [Obsolete("This Method is Deprecated")]
		protected virtual DbDataAdapter CreateAdapter(DbConnection connection, bool updating)
		{
			Debug.Assert(connection != null, "Error during CreateAdapter call. Connection String must never be null");
			DbDataAdapter realAdapter = ProviderFactory.CreateDataAdapter();
			DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();
			bool isOracleProvider = ProviderFactory.GetType().FullName.Equals("Oracle.DataAccess.Client.OracleClientFactory");
			DbCommandBuilder cmdBuilder = null;
			KeyValuePair<DbConnection, string> key = new KeyValuePair<DbConnection, string>();
            bool changeCommandType = false;
            try
			{
				cmdBuilder = ProviderFactory.CreateCommandBuilder();
				if (_activeCommand != null)
				{
					if (_activeCommand.Connection == null || _activeCommand.Connection.ConnectionString.Equals(""))
					{
						//What should we use here. ActiveConnection or the connection we are sending as parameter
						//it seams more valid to use the parameter
						_activeCommand.Connection = connection;
					}
					if (String.IsNullOrEmpty(_activeCommand.CommandText))
					{
						_activeCommand.CommandText = SqlSelectQuery;
					}

                    //Recordset was loaded from Store procedure with multiples tables, Asking if it's > 1 to be sure that it comes from multiples tables and create the command with the correct table  
                    if (this.Tables.Count > 1)
                    {
                        changeCommandType = true;
                        this.OriginalCommandType = _activeCommand.CommandType;
                        this.OrignalCommandText = _activeCommand.CommandText;
                        _activeCommand.CommandText = $"dbo.{this.Tables[CurrentRecordSet].TableName}";
                        _activeCommand.CommandType = CommandType.TableDirect;
                    }
                    DbTransaction transaction = TransactionManager.GetCurrentTransaction(connection);
					if (transaction != null)
					{
						_activeCommand.Transaction = transaction;
					}

					if (_cachingAdapter)
					{
						key = new KeyValuePair<DbConnection, string>(_activeCommand.Connection, _activeCommand.CommandText);
						if (_dataAdaptersCached.ContainsKey(key))
						{
							return _dataAdaptersCached[key];
						}
					}

					if (adapter != null)
					{
						adapter.SelectCommand = _activeCommand;
						realAdapter.SelectCommand = adapter.SelectCommand;
						cmdBuilder.DataAdapter = adapter;
						if (updating)
						{
							if (DatabaseType == DatabaseType.Access || DatabaseType == DatabaseType.SQLServer ||
								getTableName(_activeCommand.CommandText, false).Contains(" "))
							{
								cmdBuilder.QuotePrefix = "[";
								cmdBuilder.QuoteSuffix = "]";
							}
							CreateUpdateCommand(adapter, cmdBuilder);
							try
							{
								if (string.IsNullOrEmpty(SqlInsertQuery))
								{
									adapter.InsertCommand = cmdBuilder.GetInsertCommand(true);
								}
								else
								{
									adapter.InsertCommand = CreateCommand(SqlInsertQuery, CommandType.Text, null);
									adapter.InsertCommand.Connection = this.ActiveConnection;
									AddParametersToCommand(adapter.InsertCommand);
								}
							}
							catch (Exception)
							{
								adapter.InsertCommand = CreateInsertCommandFromMetaData();
							}
							try
							{
								if (string.IsNullOrEmpty(SqlDeleteQuery))
								{
									adapter.DeleteCommand = cmdBuilder.GetDeleteCommand(true);
								}
								else
								{
									adapter.DeleteCommand = CreateCommand(SqlDeleteQuery, CommandType.Text);
									adapter.DeleteCommand.Connection = this.ActiveConnection;
									AddParametersToCommand(adapter.DeleteCommand);
								}
							}
							catch (Exception ex)
							{
#if DEBUG && WINDOWS
								if (ShowWarnings && ex.Message.Equals("Dynamic SQL generation for the DeleteCommand is not supported against a SelectCommand that does not return any key column information."))
								{
									if (System.Windows.Forms.MessageBox.Show("There was a problem automatically generating the SQL Delete Command.  A Delete Command based on metadata will be generated, but it may not work as expected." + Environment.NewLine + Environment.NewLine + "Do you wish to debug to find out more?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
									{
										string problematicSelectCommand = adapter.SelectCommand.CommandText;
										System.Diagnostics.Debugger.Launch();
										System.Diagnostics.Debugger.Break();
										// In order to generate an Delete command based on a Select command,
										// the Select command must load the necessary key columns.  To fix this
										// issue, please check the Select command stored in the problematicSelectCommand
										// variable above and modify it so it loads the key columns as well.
									}
								}
#endif
								adapter.DeleteCommand = CreateDeleteCommandFromMetaData();
							}

#if SUPPORT_OBSOLETE_ORACLECLIENT
                        if ((ProviderFactory is SqlClientFactory) || isOracleProvider)
#else
							if ((ProviderFactory is SqlClientFactory))
#endif
							{
#if SUPPORT_OBSOLETE_ORACLECLIENT
	//EVG20080326: Oracle.DataAccess Version 10.102.2.20 Bug. It returns "::" instead ":" before each parameter name, wich is invalid.
			                if (isOracleProvider)
			                {
			                    adapter.InsertCommand.CommandText = adapter.InsertCommand.CommandText.Replace("::", ":");
			                    adapter.DeleteCommand.CommandText = adapter.DeleteCommand.CommandText.Replace("::", ":");
			                    adapter.UpdateCommand.CommandText = adapter.UpdateCommand.CommandText.Replace("::", ":");
			                }
#endif
								CompleteInsertCommand(adapter);
							}

							else if (ProviderFactory is OleDbFactory)
							{
								((OleDbDataAdapter)realAdapter).RowUpdated += RecordSetHelper_RowUpdatedOleDb;
							}
							realAdapter.InsertCommand = CloneCommand(adapter.InsertCommand);
							realAdapter.DeleteCommand = CloneCommand(adapter.DeleteCommand);
							realAdapter.UpdateCommand = CloneCommand(adapter.UpdateCommand);
							if (realAdapter.InsertCommand != null)
							{
								realAdapter.InsertCommand.Transaction = realAdapter.SelectCommand.Transaction;
							}
							if (realAdapter.DeleteCommand != null)
							{
								realAdapter.DeleteCommand.Transaction = realAdapter.SelectCommand.Transaction;
							}
							if (realAdapter.UpdateCommand != null)
							{
								realAdapter.UpdateCommand.Transaction = realAdapter.SelectCommand.Transaction;
							}
						}
					}

					if (_cachingAdapter)
					{
						_dataAdaptersCached.Add(key, realAdapter);
					}
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				if (cmdBuilder != null)
				{
					cmdBuilder.Dispose();
				}
                if (changeCommandType)
                {
                    _activeCommand.CommandType = this.OriginalCommandType;
                    _activeCommand.CommandText = this.OrignalCommandText;
                }
                this.Dispose(adapter);


			}
			return realAdapter;
		}


        /// <summary>
        ///     Opens the ADORecordsetHelper using the object public information.
        /// </summary>
        /// <param name="requery">Flag that indicates if a requery is necessary.</param>
        [Obsolete("This Method is Deprecated")]
        protected void OpenRecordset(bool requery)
		{
			EventStatusEnum status = requery ? EventStatusEnum.adStatusOK : EventStatusEnum.adStatusCantDeny;
			OnWillMove(requery ? EventReasonEnum.adRsnRequery : EventReasonEnum.adRsnMove, ref status);
			if (requery)
			{
				OnMoveComplete(EventReasonEnum.adRsnRequery, ref status, null);
			}
			string[] errors = null;
			if (status != EventStatusEnum.adStatusCancel)
			{
				try
				{
					//base.OpenRecordset(requery);
					// base declaration

					if (ActiveConnection != null && _activeCommand != null)
					{
						DbDataAdapter dbAdapter = null;
						try
						{
							dbAdapter = CreateAdapter(ActiveConnection, false);
							TryAddODBCParameters(_activeCommand);
							SqlSelectQuery = _activeCommand.CommandText;
							if (TransactionManager.GetCurrentTransaction(ActiveConnection) != null)
							{
								_activeCommand.Transaction = TransactionManager.GetCurrentTransaction(ActiveConnection);
							}
							_operationFinished = false;
							this.Tables.Clear();
							CurrentRecordSet = 0;
							if ((LoadSchema || LoadSchemaOnly) && !IsStoredProcedure(dbAdapter.SelectCommand))
							{
								FillSchema(dbAdapter);
							}
                            if (!LoadSchemaOnly)
                            {
								if(LoadSchema && IsStoredProcedure(dbAdapter.SelectCommand))
								{
									// Store procedures that return multiple tables (more than one SELECT)
									try
									{
                                        DataTable dt = null;
                                        using (DbDataReader read = _activeCommand.ExecuteReader(CommandBehavior.KeyInfo))
                                        {
                                            while (!read.IsClosed)
                                            {
                                                dt = new DataTable(GetTableFromSchema(read));
                                                dt.Load(read);
                                                this.Tables.Add(dt);
                                            }
                                        }
                                    }
									catch(Exception ex)
									{
                                        dbAdapter.Fill(this);
                                    }
                                }
								else
									dbAdapter.Fill(this);
                            }
                        }
						finally
						{
							if (!IsCachingAdapter)
							{
								this.Dispose(dbAdapter);
							}
						}
					}
					ResetVars();
					OnAfterQuery();
					status = EventStatusEnum.adStatusOK;
					if (UsingView && CurrentView != null)
					{
						CurrentView.ListChanged += DataView_ListChanged;
					}
				}
				catch (Exception e)
				{
					if (RecordsetChangeComplete != null || MoveComplete != null)
					{
						status = EventStatusEnum.adStatusErrorsOccurred;
						errors = new string[] { e.Message };
					}
					else
					{
						throw;
					}
				}
				MoveFirst(EventReasonEnum.adRsnMove);
			}
		}

        private string GetTableFromSchema(DbDataReader read)
        {
            string cTableName = string.Empty;
            string auxTableName = String.Empty;
            var schemaTable = read.GetSchemaTable();
            var colSchema = schemaTable?.Rows;
            var count = schemaTable == null ? 0 : colSchema.Count;
            for (int colIndex = 0; colIndex < count; colIndex++)
            {
                cTableName = colSchema[colIndex]["BaseTableName"].ToString();
                auxTableName = cTableName;
                if (cTableName != auxTableName)
                {
                    return String.Empty;
                }
            }
            return cTableName;
        }

        /// <summary>
        ///     Resets Vars according to current status
        /// </summary>
        private void ResetVars()
		{
			if (Tables.Count > 0)
			{
				FixAutoincrementColumns(UsingView ? CurrentView.Table : Tables[CurrentRecordSet]);
				_operationFinished = true;
				CurrentView = Tables[CurrentRecordSet].DefaultView;
				CurrentView.AllowDelete = AllowDelete;
				CurrentView.AllowEdit = AllowEdit;
				CurrentView.AllowNew = AllowNew;
				if ((UsingView ? CurrentView.Table : Tables[CurrentRecordSet]).Rows.Count == 0)
				{
					_index = -1;
					_eof = true;
				}
				else
				{
					_index = 0;
					_eof = false;
				}
			}
			else
			{
				_index = -1;
				_eof = true;
			}
			_newRow = false;
			_opened = true;
			_isClone = false;

			if (filter != null)
			{
				Filter = filter;
			}

			if ((UsingView && CurrentView.Table.Columns.Count > 0) ||
				(Tables.Count >= 1 && Tables[CurrentRecordSet].Columns.Count > 0))
			{
				State = ConnectionState.Open;
			}
		}

		/// <summary>
		/// When the RecordSet is Sorted and a value in the column(s) used in the sort criteria is changed, the rows in the
		/// DataView could be resorted making the index pointing to the CurrentRow invalid. This method handles rows moved
		/// to a new position and updates the index used for the CurrentRow.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		protected void DataView_ListChanged(Object sender, ListChangedEventArgs args)
		{
			if (args.ListChangedType == ListChangedType.ItemMoved && !String.IsNullOrEmpty(CurrentView.Sort))
			{
				if (args.OldIndex == this._index)
				{
					this._index = args.NewIndex;
				}
			}
			else if (args.ListChangedType == ListChangedType.ItemAdded)
			{
				this._index = args.NewIndex;
			}
		}

		/// <summary>
		///     Overrides the IDisposable.Dispose to cleanup
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (_opened)
			{
				Close();
			}
		}

        /// <summary>
        ///     Creates the update command for the database update operations of the recordset
        /// </summary>
        /// <param name="adapter">The data adapter that will contain the update command</param>
        /// <param name="cmdBuilder">The command builder to get the update command from.</param>
        [Obsolete("This Method is Deprecated")]
        protected void CreateUpdateCommand(DbDataAdapter adapter, DbCommandBuilder cmdBuilder)
		{
			try
			{
				if (string.IsNullOrEmpty(SqlUpdateQuery))
				{
					adapter.UpdateCommand = cmdBuilder.GetUpdateCommand(true);
				}
				else
				{
					adapter.UpdateCommand = CreateCommand(SqlUpdateQuery, CommandType.Text);
					adapter.UpdateCommand.Connection = this.ActiveConnection;
					AddParametersToCommand(adapter.UpdateCommand);
				}
			}
			catch (Exception ex)
			{
#if DEBUG && WINDOWS
				if (ShowWarnings && ex.Message.Equals("Dynamic SQL generation for the UpdateCommand is not supported against a SelectCommand that does not return any key column information."))
				{
					if (System.Windows.Forms.MessageBox.Show("There was a problem automatically generating the SQL Update Command.  An Update Command based on metadata will be generated, but it may not work as expected." + Environment.NewLine + Environment.NewLine + "Do you wish to debug to find out more?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
					{
						string problematicSelectCommand = adapter.SelectCommand.CommandText;
						System.Diagnostics.Debugger.Launch();
						System.Diagnostics.Debugger.Break();
						// In order to generate an Update command based on a Select command,
						// the Select command must load the necessary key columns.  To fix this
						// issue, please check the Select command stored in the problematicSelectCommand
						// variable above and modify it so it loads the key columns as well.
					}
				}
#endif
				adapter.UpdateCommand = CreateUpdateCommandFromMetaData();
			}
		}

		private void AddParametersToCommand(DbCommand command)
		{
			foreach (DataColumn col in this.Tables[CurrentRecordSet].Columns)
			{
				DbParameter param = command.CreateParameter();
				param.ParameterName = ":" + col.ColumnName;
				param.SourceColumn = col.ColumnName;
				command.Parameters.Add(param);
			}
		}

		/// <summary>
		///     Assigns the InsertCommand to the adaptar parameter
		/// </summary>
		/// <param name="adapter">DbDataAdapter</param>
		protected void CompleteInsertCommand(DbDataAdapter adapter)
		{
			String extraCommandText = "";
			String extraCommandText1 = "";

			string tablename = getTableName(_activeCommand.CommandText, false);
			Dictionary<String, String> identities = null;
			if (!LoadSchema && !LoadSchemaOnly)
			{
				identities = IdentityColumnsManager.GetIndentityInformation(tablename);
			}
			else if (DatabaseType != DB.DatabaseType.Oracle)
			{
				identities = new Dictionary<string, string>();
				foreach (DataColumn col in (SchemaTable ?? GetTable()).PrimaryKey)
				{
					if (col.Unique && col.AutoIncrement)
					{
						identities.Add(col.ColumnName, String.Empty);
					}
				}
			}

			if (identities != null)
			{
				foreach (KeyValuePair<String, String> identityInfo in identities)
				{
					adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
					//outPar.ParameterName = (isOracle ? ":" : "@") + identityInfo.Key;

					if (DatabaseType == DatabaseType.Oracle)
					{
						DbParameter outPar = adapter.InsertCommand.Parameters[":" + identityInfo.Key];
						//todo: check for null
						outPar.Direction = ParameterDirection.Output;
						outPar.DbType = GetDBType(GetTable().Columns[identityInfo.Key].DataType);

						if (String.IsNullOrEmpty(extraCommandText))
						{
							extraCommandText = " RETURNING " + identityInfo.Key;
							extraCommandText1 = " INTO :" + identityInfo.Key;
						}
						else
						{
							extraCommandText += ", " + identityInfo.Key;
							extraCommandText1 += ", :" + identityInfo.Key;
						}
					}
					else if (DatabaseType != DatabaseType.Undefined)
					{
						extraCommandText = MsInsertCommandCompletion(adapter, identityInfo.Key, extraCommandText);
					}
				}
			}
			else
			{
				extraCommandText = MsInsertCommandCompletion(adapter, _autoIncrementCol, extraCommandText);
			}
			adapter.InsertCommand.CommandText += extraCommandText + extraCommandText1;
		}

		/// <summary>
		///     SqlServer Identity value for last insert execution.
		/// </summary>
		/// <param name="adapter">DbDataAdapter to set</param>
		/// <param name="identityInfo">Name of Identity field</param>
		/// <param name="extraCommandText">used to set the query to get the identity value</param>
		/// <returns>returns the entire query in the adapter</returns>
		protected string MsInsertCommandCompletion(DbDataAdapter adapter, String identityInfo, string extraCommandText)
		{
			if (!String.IsNullOrEmpty(identityInfo))
			{
				DbParameter outPar = _providerFactory.CreateParameter();
				if (outPar != null)
				{
					outPar.ParameterName = "@" + identityInfo;
					outPar.DbType = GetDBType(GetTable().Columns[identityInfo].DataType);
					outPar.Direction = ParameterDirection.Output;
					outPar.SourceColumn = identityInfo;
				}
				extraCommandText += " SELECT @" + identityInfo + " = SCOPE_IDENTITY()";
				adapter.InsertCommand.Parameters.Add(outPar);
			}
			return extraCommandText;
		}

		/// <summary>
		///     Executes the atomic addNew Operation creating the new row and setting the newRow flag.
		/// </summary>
		protected void doAddNew()
		{
			if (UsingView)
			{
				setDefaultValueToPrimaryKeys(CurrentView.Table);
				DataRowView newRowView = CurrentView.AddNew();
				newRowView.EndEdit(); //move the row from the view to the table
				_requiresDefaultValues = true;
				AssignDefaultValues(newRowView.Row);
				CurrentView.Table.DataSet.EnforceConstraints = false;
				MoveLast(); //move from the current row to the new row
				_dbvRow = newRowView;
				_newRow = true;
				OnNewRecord();
			}
			else
			{
				this.EnforceConstraints = false;
				DataRow dbRow = GetTable().NewRow();
				_newRow = true;
				_requiresDefaultValues = true;
				AssignDefaultValues(dbRow);
				Tables[CurrentRecordSet].Rows.Add(dbRow);
				MoveLast();
				OnNewRecord();
			}
			_eof = false;
		}

		#endregion

		#region public methods

		/// <summary>
		///     This function use the protected method GetConnection to create a DBConnection based on a connection string.
		/// </summary>
		/// <param name="connectionString"> A string used to establish a connection </param>
		public static DbConnection CreateConnetion(string connectionString)
		{
			return new ADORecordSetHelper().GetConnection(connectionString);
		}

		/// <summary>
		///     Looks in all records for a field that matches the �criteria�.
		/// </summary>
		/// <param name="criteria">A String used to locate the record. It is like the WHERE clause in an SQL statement, but without the word WHERE.</param>
		public void Find(String criteria)
		{
			DataView result = Tables[CurrentRecordSet].DefaultView;
			string savedFilter = result.RowFilter;
			if (!(string.IsNullOrEmpty(savedFilter) || savedFilter.Trim().Length == 0))
			{
				savedFilter = "(" + savedFilter + ") AND (" + criteria + ")";
			}
			else
			{
				savedFilter = criteria;
			}

			DataRow[] drs = Tables[CurrentRecordSet].Select(savedFilter);

			if (drs.Length > 0)
			{
				int index = !UsingView ?
						Tables[CurrentRecordSet].Rows.IndexOf(drs[0])
					:	Array.IndexOf(Tables[CurrentRecordSet].Select(result.RowFilter), drs.FirstOrDefault());

				if (index != -1)
				{
					_index = index - 1;
					MoveNext();
					return;
				}
			}

			_eof = true;

		}

		/// <summary>
		///     Looks in all records for a field that matches the �criteria�.
		/// </summary>
		/// <param name="rowName">A String used to locate the row from the record.</param>
		/// <param name="pCriteria">A String used to locate the record. It is like the WHERE clause in an SQL statement, but without the word WHERE.</param>
		public void Find(String rowName, String pCriteria)
		{
			DataTable table = GetTable();
			if (table.Rows.Count > 0)
			{
				bool bfound = false;
				MoveFirst();
				int i = 0;
				while ((!bfound) && !EOF)
				{
					if (i < table.Rows.Count)
					{
						bfound = (table.Rows[i][rowName].Equals(pCriteria));
					}
					if (!bfound)
					{
						MoveNext();
					}
					i++;
				}
			}
		}

		/// <summary>
		///     Start caching the adapters used for connections. Use carefully because it needs an explicit call to StopCachingAdapter
		/// </summary>
		public void StartCachingAdapter()
		{
			ClearDataAdaptersCached();
			_cachingAdapter = true;
		}

		/// <summary>
		///     Stop caching the adapters used for connections
		/// </summary>
		public void StopCachingAdapter()
		{
			ClearDataAdaptersCached();
			_cachingAdapter = false;
		}

		/// <summary>
		///     Clear data adapters cached
		/// </summary>
		private void ClearDataAdaptersCached()
		{
			try
			{
				foreach (KeyValuePair<DbConnection, string> key in new List<KeyValuePair<DbConnection, string>>(_dataAdaptersCached.Keys))
				{
					try
					{
						DbDataAdapter dbDataAdapter = _dataAdaptersCached[key];
						this.Dispose(dbDataAdapter);
						_dataAdaptersCached[key] = null;
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				_dataAdaptersCached.Clear();
			}
		}

		/// <summary>
		///     Saves the information on the RecordsetHelper to a XML document.
		/// </summary>
		/// <param name="document">The XML document to save the data to.</param>
		public void Save(XmlDocument document)
		{
			using (StringWriter writer = new StringWriter())
			{
				DataTable dt = (UsingView
                    ? CurrentView.ToTable() // Call ToTable so filters are applied.
                    : Tables[CurrentRecordSet].Copy()); // Call Copy so information like ConnectionString is not serialized.
				dt.WriteXml(writer, XmlWriteMode.WriteSchema);

				document.LoadXml(writer.ToString());
				writer.Close();
			}
		}

		/// <summary>
		///     Saves the information on the RecordsetHelper to a file.
		/// </summary>
		/// <param name="fullName">The full path name where to save the file.</param>
		/// <param name="persistFormat">The format type to save the file.</param>
		public void Save(string fullName, PersistFormatEnum persistFormat)
		{
			FileStream fs = new FileStream(fullName, FileMode.Create);
			switch (persistFormat)
			{
				case (PersistFormatEnum.adPersistXML):
					{
						XmlDocument xmlDoc = new XmlDocument();
						Save(xmlDoc);
						xmlDoc.Save(fs);
						break;
					}
				case (PersistFormatEnum.adPersistBinary):
					{
						using (System.IO.Compression.GZipStream str = new System.IO.Compression.GZipStream(fs, System.IO.Compression.CompressionMode.Compress))
						{
							DataTable tableToSave = GetTable();
							tableToSave.WriteXml(str, XmlWriteMode.WriteSchema);
						}
						break;
					}
			}
			fs.Close();
		}

		/// <summary>
		///     Returns the ColumnCollection corresponding to this RecordSet.
		/// </summary>
		/// <returns>An collection containing a number of columns.</returns>
		public DataColumnCollection GetColumns()
		{
			if (UsingView)
			{
				return CurrentView.Table.Columns;
			}
			if (Tables.Count == 0)
			{
				Tables.Add(new DataTable());
			}
			return Tables[CurrentRecordSet].Columns;
		}

		/// <summary>
		///     Returns a two dimmension array representing 'n' rows in a result set.
		/// </summary>
		/// <returns>An array containing a number of rows.</returns>
		public object[,] GetRows()
		{
			return GetRows(-1, null, (int[])null);
		}

		/// <summary>
		///     Returns a two dimmension array representing 'n' rows in a result set.
		/// </summary>
		/// <param name="numrows">Number of rows to be retrieved.</param>
		/// <returns>An array containing a number of rows.</returns>
		public object[,] GetRows(int numrows)
		{
			return GetRows(numrows, null, (int[])null);
		}

		/// <summary>
		///     Returns a two dimmension array representing 'n' rows in a result set.
		/// </summary>
		/// <param name="numrows">Number of rows to be retrieved.</param>
		/// <param name="startfrom">A bookmark representing the row to begin from</param>
		/// <returns>An array containing a number of rows.</returns>
		public object[,] GetRows(int numrows, object startfrom)
		{
			return GetRows(numrows, startfrom, new int[] { });
		}

		/// <summary>
		///     Returns a two dimmension array representing 'n' rows in a result set.
		/// </summary>
		/// <param name="numrows">Number of rows to be retrieved.</param>
		/// <param name="startfrom">A bookmark representing the row to begin from</param>
		/// <param name="fieldname">The field name to be get from the row</param>
		/// <returns>An array containing a number of rows.</returns>
		public object[,] GetRows(int numrows, object startfrom, string fieldname)
		{
			return GetRows(numrows, startfrom, new string[] { fieldname });
		}

		/// <summary>
		///     Returns a two dimmension array representing 'n' rows in a result set.
		/// </summary>
		/// <param name="numrows">Number of rows to be r    etrieved.</param>
		/// <param name="startfrom">A bookmark representing the row to begin from</param>
		/// <param name="fieldnames">An array of field names to be get from the recordset</param>
		/// <returns>An array containing a number of rows.</returns>
		public object[,] GetRows(int numrows, object startfrom, string[] fieldnames)
		{
			DataTable table = GetTable();
			int[] fieldpositions = new int[fieldnames.Length];
			for (int i = 0; i < fieldnames.Length; i++)
			{
				fieldpositions[i] = table.Columns.IndexOf(fieldnames[i]);
			}
			return GetRows(numrows, startfrom, fieldpositions);
		}

		/// <summary>
		///     Returns a two dimmension array representing 'n' rows in a result set.
		/// </summary>
		/// <param name="numrows">Number of rows to be retrieved.</param>
		/// <param name="startfrom">A bookmark representing the row to begin from</param>
		/// <param name="fieldposition">The field index to be get from the recordset </param>
		/// <returns>An array containing a number of rows.</returns>
		public object[,] GetRows(int numrows, object startfrom, int fieldposition)
		{
			return GetRows(numrows, startfrom, new int[] { fieldposition });
		}

		/// <summary>
		///     Returns a two dimmension array representing 'n' rows in a result set.
		/// </summary>
		/// <param name="numrows">Number of rows to be retrieved.</param>
		/// <param name="startfrom">A bookmark representing the row to begin from</param>
		/// <param name="fieldpositions">The field indexes to be get from the recordset</param>
		/// <returns>An array containing a number of rows.</returns>
		public object[,] GetRows(int numrows, object startfrom, int[] fieldpositions)
		{
			object[,] buffer;
			if (startfrom != null)
			{
				DataRow row = startfrom as DataRow;
				if (row != null)
				{
					Bookmark = row;
				}
				else if (startfrom is BookmarkEnum)
				{
					switch ((BookmarkEnum)startfrom)
					{
						case BookmarkEnum.adBookmarkFirst:
							MoveFirst();
							break;
						case BookmarkEnum.adBookmarkLast:
							MoveLast();
							break;
					}
				}
				else if (startfrom is string)
				{
					throw new InvalidOperationException("String parameter not supported on the GetRows method");
				}
			}
			DataTable table = (UsingView ? CurrentView.Table : Tables[CurrentRecordSet]);
			numrows = numrows == -1 ? RecordCount - _index : numrows;
			if (!(fieldpositions == null || fieldpositions.Length <= 0))
			{
				buffer = new object[fieldpositions.Length, numrows];
			}
			else
			{
				buffer = new object[table.Columns.Count, numrows];
			}

			int i = _index, colindex = 0, rowindex = 0;
			for (; !EOF && rowindex < numrows; MoveNext())
			{
				if (!(fieldpositions == null || fieldpositions.Length <= 0))
				{
					foreach (int fieldposition in fieldpositions)
					{
						buffer[colindex, rowindex] = CurrentRow[fieldposition];
						colindex++;
					}
				}
				else
				{
					foreach (Object data in CurrentRow.ItemArray)
					{
						buffer[colindex, rowindex] = data;
						colindex++;
					}
				}
				colindex = 0;
				rowindex++;
			}
			_index = _eof ? (!UsingView ? table.Rows.Count - 1 : CurrentView.Count - 1) : _index;
			object[,] result = new object[buffer.GetLength(0), rowindex];
			for (int rindex = 0; rindex < rowindex; rindex++)
			{
				for (int cindex = 0; cindex < result.GetLength(0); cindex++)
				{
					result[cindex, rindex] = buffer[cindex, rindex];
				}
			}
			return result;
		}

		/// <summary>
		///     Moves the position of the currentRecord in a RecordSet.
		/// </summary>
		/// <param name="records">Amount of records positive or negative to move from the current record.</param>
		public override void Move(int records)
		{
			Move(records, EventReasonEnum.adRsnMove, EventStatusEnum.adStatusOK);
		}

		/// <summary>
		///     Moves the current record to the beginning of the ADORecordsetHelper.
		/// </summary>
		public override void MoveFirst()
		{
			MoveFirst(EventReasonEnum.adRsnMoveFirst);
		}

		/// <summary>
		///     Moves the current record to the end of the ADORecordsetHelper.
		/// </summary>
		/// <param name="options"></param>
		public void MoveLast(int options)
		{
			//TODO: ToBeImplemented where Options != 0
			if (options == 0)
			{
				MoveLast();
			}
		}

		/// <summary>
		///     Moves the current record to the end of the ADORecordsetHelper.
		/// </summary>
		public override void MoveLast()
		{
			Move((UsingView ? CurrentView.Count - 1 : Tables[CurrentRecordSet].Rows.Count - 1) - _index, EventReasonEnum.adRsnMoveLast,
				 EventStatusEnum.adStatusOK);
		}

		/// <summary>
		///     Moves the current record forward one position.
		/// </summary>
		public override void MoveNext()
		{
			Move(_currentRowDeleted?0:1, EventReasonEnum.adRsnMoveNext, EventStatusEnum.adStatusOK);
		}

		/// <summary>
		///     Moves the current record backwards one position.
		/// </summary>
		public override void MovePrevious()
		{
			Move(-1, EventReasonEnum.adRsnMovePrevious, EventStatusEnum.adStatusOK);
		}

		/// <summary>
		///     Creates a new record for an updatable Recordset.
		/// </summary>
		/// <param name="col">Name of the columns to be added to the ADORecordsetHelper.</param>
		/// <param name="value">Value for the row to be inserted on the ADORecordsetHelper.</param>
		public void AddNew(string col, string value)
		{
			AddNew(new object[] { col }, new object[] { value });
		}

		/// <summary>
		///     Creates a new record for an updatable Recordset.
		/// </summary>
		/// <param name="cols">Array containing the names of the columns to be added to the ADORecordsetHelper.</param>
		/// <param name="values">Array containing the values for the rows to be inserted on the ADORecordsetHelper.</param>
		public void AddNew(object[] cols, object[] values)
		{
			EventStatusEnum status = EventStatusEnum.adStatusOK;
			OnWillMove(EventReasonEnum.adRsnAddNew, ref status);
			if (status != EventStatusEnum.adStatusCancel)
			{
				OnWillChangeRecord(EventReasonEnum.adRsnAddNew, ref status, 1);
				if (status != EventStatusEnum.adStatusCancel)
				{
					if (cols != null && values != null)
					{
						doAddNew();
						OnRecordChangeComplete(EventReasonEnum.adRsnAddNew, ref status, 1, null);
						for (int i = 0; i < cols.Length; i++)
						{
							if (i == 0)
							{
								OnWillChangeRecord(EventReasonEnum.adRsnAddNew, ref status, 1);
							}
							CurrentRow[cols[i].ToString()] = values[i];
							if (i == 0)
							{
								OnRecordChangeComplete(EventReasonEnum.adRsnAddNew, ref status, 1, null);
							}
						}
						if (!isBatchEnabled())
							Update();
					}
				}
				OnMoveComplete(EventReasonEnum.adRsnAddNew, ref status, null);
			}
		}


		/// <summary>
		///     Creates a new record for an updatable Recordset.
		/// </summary>
		public override void AddNew()
		{
			//Validations. AddNew is not allowed for Recordset with ReadOnly LockType
			if (LockType == LockTypeEnum.LockReadOnly)
			{
				throw new NotSupportedException("AddNew is not supported for RecordSets with a LockType " + LockType);
			}
			EventStatusEnum status = EventStatusEnum.adStatusOK;
			OnWillMove(EventReasonEnum.adRsnMove, ref status);
			string[] errors = null;
			if (status != EventStatusEnum.adStatusCancel)
			{
				OnWillChangeRecord(EventReasonEnum.adRsnAddNew, ref status, 1);
				if (status != EventStatusEnum.adStatusCancel)
				{
					try
					{
						doAddNew();
						if (!isBatchEnabled() || _editMode != EditModeEnum.EditNone)
						{
							_editMode = EditModeEnum.EditAdd;
						}
					}
					catch (Exception e)
					{
						errors = (new string[] { e.Message });
						status = EventStatusEnum.adStatusErrorsOccurred;
					}
					OnRecordChangeComplete(EventReasonEnum.adRsnAddNew, ref status, 1, errors);
				}
				OnMoveComplete(EventReasonEnum.adRsnMove, ref status, errors);
			}
		}

		/// <summary>
		///     Deletes the current record or a group of records.
		/// </summary>
		/// <param name="deleteBehavior">AffectEnum value indicating if the deletion applies to the current group or a group.</param>
		public void Delete(int deleteBehavior)
		{
			Exception exceptionToThrow = null;
			EventStatusEnum status = EventStatusEnum.adStatusOK;
			OnWillChangeRecord(EventReasonEnum.adRsnDelete, ref status, 1);
			if (status != EventStatusEnum.adStatusCancel)
			{
				try
				{
					if (!isBatchEnabled() || _editMode != EditModeEnum.EditNone)
					{
						_editMode = EditModeEnum.EditDelete;
					}
					DataRow deletingRow;
					switch (deleteBehavior)
					{
						case (int)AffectEnum.adAffectCurrent:
							deletingRow = CurrentView[_index].Row;
							break;
						case (int)AffectEnum.adAffectGroup:
							deletingRow = GetTable().Rows[_index];
							break;
						default:
							throw new ArgumentException("Value not allowed to delete.");
					}
					deletingRow.Delete();
					_currentRowDeleted = true;
					// If your view has an incorrect EOF or BOF or index,
					// you can consider setting '_index' to -1 as long as 'UsingView' is set to true 
					if (!isBatchEnabled())
						Update();
				}
				catch (Exception e)
				{
					if (!isBatchEnabled() || _editMode != EditModeEnum.EditNone)
					{
						_editMode = EditModeEnum.EditInProgress;
					}
					exceptionToThrow = e;
				}
				if (exceptionToThrow != null)
				{
					throw exceptionToThrow;
				}
				OnRecordChangeComplete(EventReasonEnum.adRsnDelete, ref status, 1, null);
			}
		}

		/// <summary>
		///     Deletes the current record.
		/// </summary>
		public void Delete()
		{
			Delete((int)AffectEnum.adAffectCurrent);
		}

		/// <summary>
		///     Not implemented yet.
		/// </summary>
		public void Edit()
		{
			//TODO: ToBeImplemented
			//throw new System.Exception("Method or Property not implemented yet!");
		}

		/// <summary>
		///     Saves any changes you make to the current row of an ADORecordsetHelper object.
		/// </summary>
		public override void Update()
		{
			Update(true);
		}

		/// <summary>
		///     Saves the current content of the ADORecordsetHelper to the database.
		/// </summary>
		/// <param name="updateType">>The UpdateType to be use by this update.</param>
		/// <param name="force">A Boolean value indicating whether or not to force the changes into the database.</param>
		public void Update(int updateType, bool force)
		{
			//note: No case has been found to use the specialization parameters.
			//if (UpdateType == 1)
			Update();
		}

		/// <summary>
		///     Updates the provided �Fields� with the �values� received has parameter.
		/// </summary>
		/// <param name="fields">Array containing the fields to be updated.</param>
		/// <param name="values">Array containing the values to be used to update the fields.</param>
		public void Update(object[] fields, object[] values)
		{
			if (fields == null)
			{
				throw new ArgumentException("RecordSetHelper.Update fields parameter cannot be null ");
			}
			if (fields.Length == 0)
			{
				throw new ArgumentException("RecordSetHelper.Update fields parameter length cannot be zero ");
			}
			if (values == null)
			{
				throw new ArgumentException("RecordSetHelper.Update values parameter cannot be null ");
			}
			if (values.Length == 0)
			{
				throw new ArgumentException("RecordSetHelper.Update values parameter length cannot be zero ");
			}
			if (values.Length != fields.Length)
			{
				throw new ArgumentException("RecordSetHelper.Update fields and values arrays have to be of the same length");
			}

			Type elementType = fields[0].GetType();
			bool isString = elementType.Equals(Type.GetType("System.String"));
			EventStatusEnum status = EventStatusEnum.adStatusOK;
			OnWillChangeField(ref status, fields.Length, iterateFields(fields, values, isString, true));
			if (status != EventStatusEnum.adStatusCancel)
			{
				OnFieldChangeComplete(ref status, fields.Length, iterateFields(fields, values, isString, false), new string[] { });
				Update();
			}
		}


		/// <summary>
		///     Writes all pending batch updates to disk.
		/// </summary>
		public void UpdateBatch()
		{
			Exception exceptionToThrow = null;
			if (UsingView)
			{
				CurrentView.Table.DataSet.EnforceConstraints = true;

				if (_dbvRow != null)
				{
					_dbvRow.EndEdit();
					_index = findBookmarkIndex(_dbvRow.Row);
				}
			}
			else
			{
				this.EnforceConstraints = true;
			}
			if (isBatchEnabled())
			{
				DbConnection connection = GetConnection(_connectionString);
				using (DbDataAdapter dbAdapter = CreateAdapter(connection, true))
				{
					DataTable changes = UsingView ? CurrentView.Table.GetChanges() : Tables[CurrentRecordSet].GetChanges();
					if (changes != null)
					{
						EventStatusEnum status = EventStatusEnum.adStatusOK;
						string[] errors = null;
						OnWillChangeRecord(EventReasonEnum.adRsnUpdate, ref status, 1);
						if (status != EventStatusEnum.adStatusCancel)
						{
							try
							{
								UpdateByRowState(dbAdapter);
								_editMode = EditModeEnum.EditNone;
								_newRow = false;
							}
							catch (Exception e)
							{
								errors = (new string[] { e.Message });
								exceptionToThrow = e;
							}
							OnRecordChangeComplete(EventReasonEnum.adRsnUpdate, ref status, 1, errors);
							if (exceptionToThrow != null)
							{
								throw exceptionToThrow;
							}
						}
					}
				}
			}
			else if (isLockEnabled())
			{
				Update();
			}
		}

		private void UpdateByRowState(DbDataAdapter dbAdapter)
		{
			DataSet table = _isClone ? CurrentView.Table.DataSet : this.GetTable().DataSet;
			DataRow[] filterRows = null;

			if (UsingView && _filtered && filter is string)
            {
				filterRows = table.Tables[CurrentRecordSet].Select(Filter as string);
			}

			for (int j = table.Tables[CurrentRecordSet].Rows.Count - 1; j >= 0; j--)
			{
				if (table.Tables[CurrentRecordSet].Rows[j].RowState != DataRowState.Added &&
					table.Tables[CurrentRecordSet].Rows[j].RowState != DataRowState.Unchanged)
				{
					if (!_filtered 
						|| filterRows == null 
						|| table.Tables[CurrentRecordSet].Rows[j].RowState == DataRowState.Deleted
						|| filterRows.Contains(table.Tables[CurrentRecordSet].Rows[j]))
                    {
						dbAdapter.Update(new DataRow[] { table.Tables[CurrentRecordSet].Rows[j] });
					}
				}
			}

			for (int j = table.Tables[CurrentRecordSet].Rows.Count - 1; j >= 0; j--)
			{
				if (table.Tables[CurrentRecordSet].Rows[j].RowState == DataRowState.Added)
				{
					if (!_filtered || filterRows == null || filterRows.Contains(table.Tables[CurrentRecordSet].Rows[j]))
                    {
						dbAdapter.Update(new DataRow[] { table.Tables[CurrentRecordSet].Rows[j] });
					}
				}
			}
			return;
		}

		/// <summary>
		///     Cancels a pending batch update.
		/// </summary>
		public void CancelBatch()
		{
			bool wasNewRow = _newRow;
			EventStatusEnum status = EventStatusEnum.adStatusOK;
			string[] errors = null;
			OnWillChangeRecord(wasNewRow ? EventReasonEnum.adRsnUndoAddNew : EventReasonEnum.adRsnUndoUpdate, ref status, 1);
			if (status != EventStatusEnum.adStatusCancel)
			{
				try
				{
					//base.CancelBatch();
					GetTable().RejectChanges();
					_newRow = false;

					_index = -1;
					_editMode = EditModeEnum.EditNone;
				}
				catch (Exception e)
				{
					errors = (new string[] { e.Message });
				}
				OnRecordChangeComplete(wasNewRow ? EventReasonEnum.adRsnUndoAddNew : EventReasonEnum.adRsnUndoUpdate, ref status, 1,
									   errors);
			}
		}

		/// <summary>
		///     Updates the provided "field" with the "value" recieved has parameter.
		/// </summary>
		/// <param name="field">The field to be updated.</param>
		/// <param name="value">The value to update the field with.</param>
		public void Update(object field, object value)
		{
			if (field == null)
			{
				throw new ArgumentException("RecordSetHelper.Update field parameter cannot be null ");
			}
			if (value == null)
			{
				throw new ArgumentException("RecordSetHelper.Update value parameter cannot be null ");
			}
			Type elementType = field.GetType();
			bool isString = elementType == Type.GetType("System.String");
			bool isInt = elementType == Type.GetType("System.Int16") || elementType.Equals(Type.GetType("System.Int32")) ||
						 elementType == Type.GetType("System.Int64");
			if (isString)
			{
				this[(String)field] = value;
			}
			else if (isInt)
			{
				this[(int)field] = value;
			}
			try
			{
				UpdateWithNoEvents(CurrentRow);
			}
			catch
			{
			}
		}

		/// <summary>
		///     Cancels any changes made to the current or new row of a ADORecordsetHelper object.
		/// </summary>
		public void CancelUpdate()
		{
			EventStatusEnum status = EventStatusEnum.adStatusOK;
			string[] errors = null;
			OnWillChangeRecord(EventReasonEnum.adRsnUndoUpdate, ref status, 1);
			if (status != EventStatusEnum.adStatusCancel)
			{
				try
				{
					// base.CancelUpdate();
					DoCancelUpdate();
					_editMode = EditModeEnum.EditNone;
				}
				catch (Exception e)
				{
					errors = (new string[] { e.Message });
				}
				OnRecordChangeComplete(EventReasonEnum.adRsnUndoUpdate, ref status, 1, errors);
			}
		}

		/// <summary>
		///     Closes an open object and any dependent objects.
		/// </summary>
		public override void Close()
		{
			try
			{
				base.Close();
				_isClone = false;
				State = ConnectionState.Closed;
				EventStatusEnum status = EventStatusEnum.adStatusOK;
				OnRecordsetChangeComplete(EventReasonEnum.adRsnClose, ref status, null);
			}
			catch (Exception) { }

			finally
			{
				Dispose();
			}
		}

		/// <summary>
		///     This method clones the recordset instance
		/// </summary>
		/// <returns>The cloned recordset</returns>
		public ADORecordSetHelper Clone()
		{
			ADORecordSetHelper result = new ADORecordSetHelper();
			CloneIt(this, result);
			return result;
		}

		/// <summary>
		///     This method clones the recordset instance
		/// </summary>
		/// <param name="lockType">The lock type to be used by the cloned recorset</param>
		/// <returns>The cloned recordset</returns>
		public ADORecordSetHelper Clone(LockTypeEnum lockType)
		{
			ADORecordSetHelper result = new ADORecordSetHelper();
			CloneIt(this, result);
			result.LockType = lockType;
			return result;
		}

		/// <summary>
		///     Clone a source ADORecordSetHelper through a target ADORecordSetHelper
		/// </summary>
		/// <param name="source">The source ADORecordSetHelper</param>
		/// <param name="target">The target ADORecordSetHelper</param>
		/// <param name="copyTables">Indicate if the tables should be copied as well.</param>
		internal void CloneIt(ADORecordSetHelper source, ADORecordSetHelper target, bool copyTables = true)
		{
			base.CloneIt(source, target, copyTables);
			if (source.Tables.Count > 0)
			{
				target.CurrentView.ListChanged += DataView_ListChanged;
			}
			target.State = source.State;
			target.CursorLocation = source.CursorLocation;
			target.LockType = source.LockType;
			target._sort = source._sort;
			if (source.FieldChangeComplete != null)
			{
				target.FieldChangeComplete = source.FieldChangeComplete;
			}
			if (source.RecordChangeComplete != null)
			{
				target.RecordChangeComplete = source.RecordChangeComplete;
			}
			if (source.WillChangeField != null)
			{
				target.WillChangeField = source.WillChangeField;
			}
			if (source.WillChangeRecord != null)
			{
				target.WillChangeRecord = source.WillChangeRecord;
			}
		}

		/// <summary>
		///     Updates the data in a Recordset object by re-executing the query on which the object is based.
		/// </summary>
		public void Refresh()
		{
			Requery();
		}

		/// <summary>
		/// Store the parent position, to have the tracking for the current recordset
		/// </summary>
		private int Position { get; set;}

		/// <summary>
		///     Returns a new recordset according to the compound statement on the current recordset
		/// </summary>
		/// <returns>A new open recordset</returns>
		public ADORecordSetHelper NextRecordSet()
		{
			ADORecordSetHelper result = null;
			if (CurrentRecordSet < Tables.Count - 1)
			{
				result = new ADORecordSetHelperView(this);
				this.Position++;
				result.CurrentRecordSet = this.Position;
				result.Position = this.Position;
	 
				result.ResetVars();
			}
			return result;
		}


		/// <summary>
		///     Updates the data in a Recordset object by re-executing the query on which the object is based.
		/// </summary>
		public override void Requery()
		{
			Open(true);
		}


		/// <summary>
		///     Sets the �value� to the column at index �ColumnIndex�.
		/// </summary>
		/// <param name="columnIndex">Index of the column to update.</param>
		/// <param name="value">The new value for the column.</param>
		public override void SetNewValue(int columnIndex, object value)
		{
			EventStatusEnum status = EventStatusEnum.adStatusOK;
			string[] errors = null;
			if (_firstChange)
			{
				OnWillChangeRecord(EventReasonEnum.adRsnFirstChange, ref status, 1);
			}
			OnWillChangeField(ref status, 1, (new Object[] { CurrentRow[columnIndex] }));
			if (status != EventStatusEnum.adStatusCancel)
			{
				try
				{
					if (value == null)
						value = DBNull.Value;

					// base.SetNewValue(columnIndex, value);
					//When DBNull is not allowed, if we get a DBNull value, it gets converted to the default value
					if (!GetFieldMetadata(columnIndex).AllowDBNull && Convert.IsDBNull(value))
					{
						if (String.Equals(Convert.ToString(value), String.Empty))
						{
							value = GetADOFieldDefaultValue(GetDBType(GetFieldMetadata(columnIndex).DataType));
						}
					}
					CurrentRow[columnIndex] = value;
				}
				catch (Exception e)
				{
					status = EventStatusEnum.adStatusErrorsOccurred;
					errors = new string[] { e.Message };
				}
				OnFieldChangeComplete(ref status, 1, (new Object[] { CurrentRow[columnIndex] }), errors);
				if (_firstChange)
				{
					OnRecordChangeComplete(EventReasonEnum.adRsnFirstChange, ref status, 1, errors);
				}
			}
		}


		/// <summary>
		///     Returns the default value for a specific DBType
		/// </summary>
		/// <param name="type">DbType from where we want to get the default value</param>
		public object GetADOFieldDefaultValue(DbType type)
		{
			object value = DBNull.Value;
			switch (type)
			{
				case DbType.Int32:
					value = default(Int32);
					break;
				case DbType.DateTime:
					value = DateTime.Now;
					break;
				case DbType.Byte:
					value = default(Byte);
					break;
				case DbType.Binary:
					value = default(Object);
					break;
				case DbType.Boolean:
					value = default(Boolean);
					break;
				case DbType.Decimal:
					value = default(Decimal);
					break;
				case DbType.Double:
					value = default(Double);
					break;
				case DbType.Guid:
					value = default(Guid);
					break;
				case DbType.Int16:
					value = default(Int16);
					break;
				case DbType.Int64:
					value = default(Int64);
					break;
				case DbType.Object:
					value = default(Object);
					break;
				case DbType.SByte:
					value = default(SByte);
					break;
				case DbType.Single:
					value = default(Single);
					break;
				case DbType.String:
					value = string.Empty;
					break;
				case DbType.UInt16:
					value = default(UInt16);
					break;
				case DbType.UInt32:
					value = default(UInt32);
					break;
				case DbType.UInt64:
					value = default(UInt64);
					break;
				default:
					break;
			}
			return value;
		}

        /// <summary>
        /// Returns the string of the whole row concatenating all the columns
        /// </summary>
        /// <param name="numRows">[Optional] Row number</param>
        /// <param name="ColumnDelimeter">[Optional] Column Delimeter</param>
        /// <param name="RowDelimeter">[Optional] Row delimeter</param>
        /// <param name="NullExpr">[Optional] Null expresion</param>
        /// <returns></returns>
        public string GetString(int numRows = -1, string ColumnDelimeter = "\t", string RowDelimeter = "\r\n", string NullExpr = "")
        {
            string result = "";
            if (this.RecordCount == 0 || this.EOF)
                return result;
            object[,] rows;
            if (numRows == -1)
                rows = this.GetRows();
            else
                rows = this.GetRows(numRows);
            for (int row = 0; row < rows.GetLength(1); row++)
            {
                string newRowResult = "";
                for (int column = 0; column < rows.GetLength(0); column++)
                {
                    object value = rows[column, row];
                    if (value.GetType().FullName == "System.DBNull")
                        value = NullExpr;
                    if (value.GetType().FullName == "System.DateTime")
                        value = DateTime.Parse(value.ToString()).ToString("M/d/yyyy");
                    if (newRowResult != "")
                        newRowResult += ColumnDelimeter + value.ToString();
                    else
                        newRowResult = value.ToString();
                }
                result += newRowResult + RowDelimeter;
            }
            return result;
        }

        #endregion

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override RecordSetHelper CreateInstance()
		{
			return new ADORecordSetHelper();
		}

		/// <summary>
		///
		/// </summary>
		public override bool CanMovePrevious
		{
			get
			{
				return _index > 0;
			}
		}

		/// <summary>
		///
		/// </summary>
		public override bool CanMoveNext
		{
			get
			{
				bool res = false;
				if (this.Tables.Count > 0)
				{
					res = _index < this.Tables[CurrentRecordSet].Rows.Count - 1;
				}
				return res;
			}
		}

		/// <summary>
		/// Performs the move action after setting a filter
		/// </summary>
		protected override void MoveAfterFilter()
		{
			MoveFirst(EventReasonEnum.adRsnRequery);
		}

		/// <summary>
		/// Allows the correct syntax for ODBC stored procedures
		/// </summary>
		/// <param name="cmd"></param>
		public static void TryAddODBCParameters(DbCommand cmd)
		{
			if (cmd.CommandType == CommandType.StoredProcedure && cmd is System.Data.Odbc.OdbcCommand)
			{
				string commandText = cmd.CommandText;
				if (!Regex.IsMatch(commandText, @"^\s*\{\s*call ", RegexOptions.IgnoreCase))
				{
					int parameterCount = cmd.Parameters.Count;

					string parameters = "";
					//Adding structure when returnvalue appears on SP.
					string returnValue = "";
					if (parameterCount > 0)
					{
						for (int i = 0; i < parameterCount; i++)
						{
							if (!cmd.Parameters[i].ParameterName.StartsWith("@"))
							{
								cmd.Parameters[i].ParameterName = "@" + cmd.Parameters[i].ParameterName;
							}
							if (cmd.Parameters[i].Direction == ParameterDirection.ReturnValue)
							{
								returnValue = " ? = ";
							}
							else
							{
								if (i < (parameterCount - 1))
								{
									parameters += "?, ";
								}
								else
								{
									parameters += "?";
								}
							}
						}
						if (!string.IsNullOrEmpty(returnValue))
						{
							if (string.IsNullOrEmpty(parameters))
							{
								commandText = string.Format("{{ {0} call {1} }}", returnValue, commandText);
							}
							else
							{
								commandText = string.Format("{{ {0} call {1}({2}) }}", returnValue, commandText, parameters);
							}

						}
						else
						{
							commandText = string.Format("{{call {0}({1})}}", commandText, parameters);
						}
					}
					else
					{
						commandText = string.Format("{{call {0}}}", commandText);
					}

					cmd.CommandText = commandText;
				}
			}
		}

		/// <summary>
		/// A view for a specific table in the DataSet.
		/// </summary>
		public class ADORecordSetHelperView : ADORecordSetHelper
		{
			private ADORecordSetHelper Helper;

			/// <summary>
			/// Builds a view for the specified ADORecordSetHelper.
			/// </summary>
			/// <param name="source">The ADORecordSetHelper to view.</param>
			public ADORecordSetHelperView(ADORecordSetHelper source)
			{
				Helper = source;
				Helper.CloneIt(source, this, false);
			}

			/// <summary>
			/// Obtains the tables of the associated ADORecordSetHelper.
			/// </summary>
			public override DataTableCollection Tables
			{
				get
				{
					return Helper.Tables;
				}
			}


		}
	}
}
