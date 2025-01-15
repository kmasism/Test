// Author: mrojas
// Project: UpgradeHelpers.Windows.Forms
// Path: D:\VbcSPP\src\Helpers\UpgradeHelpers.Windows.Forms\ExtendedDataGridView
// Creation date: 8/6/2009 2:29 PM
// Last modified: 10/8/2009 10:32 AM

#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Data;
#endregion

namespace UpgradeHelpers
{
	/// <summary>
	/// This is class implements a component that extends the
	/// System.Windows.Forms.DataGridView control.  It adds new properties and also
	/// provides &quot;Compatibility&quot; support for some Grid controls commonly used
	/// in  VB6: MSFlexGrid and APEX TrueDBGrid
	/// </summary>
	public partial class DataGridViewFlex : DataGridViewCommon, System.ComponentModel.ISupportInitialize
	{
		private const int DEFAULT_NEW_CUSTOM_COLUMN_WIDTH = 66;
		private const int DEFAULT_GRIDLINEWIDTH = 1;
		private const int DEFAULT_CELL_PADDING = 2;
		private const int DEFAULT_COLUMN_SIZE_MULTIPLIER = 8;
		private const int DEFAULT_ROW_HEIGHT_PAD = 4;
		private const int DEFAULT_ROWSCOUNT = 2;
		private const int DEFAULT_COLUMNSCOUNT = 2;

		private int _gridLineWidth = DEFAULT_GRIDLINEWIDTH;
		private bool _suppressSelectionChanged = false;

		/// <summary>
		/// Default Constructor to create a new instance of this class
		/// </summary>
		public DataGridViewFlex() : this(null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the UpgradeHelpers.Windows.Forms.ExtendedGridView class with the corresponding container
		/// </summary>
		/// <param name="container">The container where the Grid is going to be hosted</param>
		public DataGridViewFlex(IContainer container)
		{
			DoubleBuffered = true;
			InitializeComponent();
			_controlKeyDown = new KeyEventHandler(control_KeyDown);
			_controlKeyUp = new KeyEventHandler(control_KeyUp);
			_controlKeyPress = new KeyPressEventHandler(control_KeyPress);
			this.CellMouseEnter -= new DataGridViewCellEventHandler(ExtendedDataGridView_CellMouseEnter);
			this.CellMouseEnter += new DataGridViewCellEventHandler(ExtendedDataGridView_CellMouseEnter);
			this.RowHeaderMouseClick += ExtendedDataGridView_RowHeaderMouseClick;
			this.CellPainting += ExtendedDataGridView_CellPainting;
			isInitializing = false;
			Reset();
			#region Designer related code

			IServiceContainer serviceContainer = container as IServiceContainer;
			if (serviceContainer != null)
			{
				ExtendedDataGridViewPropertyFilter newMyFilter = new ExtendedDataGridViewPropertyFilter();
				DesignerActionService designerActionService = serviceContainer.GetService(typeof(DesignerActionService)) as DesignerActionService;
				//DesignerActionUIService designerActionUIService = serviceContainer.GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
				newMyFilter.oldService = (ITypeDescriptorFilterService)serviceContainer.GetService(typeof(ITypeDescriptorFilterService));
				newMyFilter.designerActionService = designerActionService;
				//newMyFilter.designerActionUIService = designerActionUIService;
				if (newMyFilter.oldService != null)
				{
					serviceContainer.RemoveService(typeof(ITypeDescriptorFilterService));
				}

				serviceContainer.AddService(typeof(ITypeDescriptorFilterService), newMyFilter);
			}

			// Acquire a reference to IComponentChangeService
			//This service is used during design to make sure that we do not allow the user
			//to edit Columns properties when the grid is in MSFlexGrid compatibility
			IComponentChangeService changeService = container as IComponentChangeService;
			if (changeService != null)
			{
				changeEventHandler = new ComponentChangingEventHandler(changeService_ComponentChanging);
				changeService.ComponentChanging -= changeEventHandler;
				changeService.ComponentChanging += changeEventHandler;
			}
			#endregion
		}

		private void InitializeComponent()
		{

		}

		class ExtendedDataGridViewPropertyFilter : ITypeDescriptorFilterService
		{

			public ITypeDescriptorFilterService oldService;
			public DesignerActionService designerActionService;
			//public DesignerActionUIService designerActionUIService;
			DesignerActionList columnEditing;
			bool columnEditingRemoved;

			#region ITypeDescriptorFilterService Members

			public bool FilterAttributes(IComponent component, System.Collections.IDictionary attributes)
			{
				if (oldService != null)
					oldService.FilterAttributes(component, attributes);
				return true;
			}

			public bool FilterEvents(IComponent component, System.Collections.IDictionary events)
			{
				if (oldService != null)
					oldService.FilterEvents(component, events);
				return true;
			}

			public bool FilterProperties(IComponent component, System.Collections.IDictionary properties)
			{
				DataGridViewFlex grid = component as DataGridViewFlex;
				if (grid != null)
				{
					//Initialize ColumnEditing actions
					CacheColumnEditingActionList(component);
					if (!grid.isInitializing)
					{
						SetPropertiesForFlexGrid(component, properties);
					}
					return false;
				}
				else
					if (oldService != null)
					return oldService.FilterProperties(component, properties);
				else
					return true;
			}
			#endregion

			//private void SetPropertiesForTrueDBGrid(IComponent component, System.Collections.IDictionary properties)
			//{
			//}

			private void SetPropertiesForFlexGrid(IComponent component, System.Collections.IDictionary properties)
			{
				properties.Remove("Columns");
				if (designerActionService != null && columnEditing != null && !columnEditingRemoved)
				{
					designerActionService.Remove(component, columnEditing);
					columnEditingRemoved = true;
				}
			}
			private void SetPropertiesForDataGridView(IComponent component, System.Collections.IDictionary properties)
			{
				//foreach (PropertyInfo propertyInfo in typeof(IFlexGridBehaviour).GetProperties())
				//{
				//    properties.Remove(propertyInfo.Name);
				//}
				if (designerActionService != null && columnEditing != null && columnEditingRemoved)
				{
					designerActionService.Add(component, columnEditing);
					columnEditingRemoved = false;

				}
			}
			private void CacheColumnEditingActionList(IComponent component)
			{
				if (designerActionService != null && columnEditing == null)
				{
					try
					{
#if NET_CORE_APP
                        DesignerActionListCollection designerActionList = designerActionService.GetComponentActions(component, System.Windows.Forms.Design.ComponentActionsType.Component);
#else
						DesignerActionListCollection designerActionList = designerActionService.GetComponentActions(component, System.ComponentModel.Design.ComponentActionsType.Component);
#endif
						foreach (System.ComponentModel.Design.DesignerActionList dList in designerActionList)
						{
							if (dList.GetType().Name.Equals("DataGridViewColumnEditingActionList"))
							{
								this.columnEditing = dList;
								break;
							}
						}
					}
					catch
					{
					}
				}
			}

		}

		/// <summary>
		/// ExtendedDataGridView destructor.
		/// Removes associations between the ComponentChanging event and its handler
		/// when the control is in design mode.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (DesignMode)
			{
				IComponentChangeService changeService =
					GetService(typeof(IComponentChangeService))
					as IComponentChangeService;
				if (changeService != null)
					changeService.ComponentChanging -= changeEventHandler;

			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Change handler used in the designer to intercept changes in certains properties
		/// </summary>
		private ComponentChangingEventHandler changeEventHandler;

		/// <summary>
		/// Gets Cell Style
		/// </summary>
		/// <returns></returns>
		public DataGridViewCellStyle GetCellStyleNonFixed()
		{
			DataGridViewCellStyle cellStyleNormal = new DataGridViewCellStyle();
			cellStyleNormal.BackColor = DefaultCellStyle.BackColor;
			cellStyleNormal.ForeColor = DefaultCellStyle.ForeColor;
			cellStyleNormal.SelectionBackColor = DefaultCellStyle.SelectionBackColor;
			cellStyleNormal.SelectionForeColor = DefaultCellStyle.SelectionForeColor;
			return cellStyleNormal;
		}

		/// <summary>
		/// Gets CellStyle
		/// </summary>
		/// <returns></returns>
		public DataGridViewCellStyle GetCellStyleFixed()
		{
			DataGridViewCellStyle cellStyleFixed = new DataGridViewCellStyle();
			cellStyleFixed.BackColor = BackColorFixed;
			cellStyleFixed.ForeColor = ForeColorFixed;
			cellStyleFixed.SelectionBackColor = BackColorFixed;
			cellStyleFixed.SelectionForeColor = ForeColor;
			return cellStyleFixed;
		}

		/// <summary>
		/// Called when the DataSource changes.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		protected override void OnDataSourceChanged(EventArgs e)
		{
			CopyDataFromDataSource();
		}

		private void CopyDataFromDataSource()
		{
			int numColumnsInDataSource = 0;
			if (DataSource is System.ComponentModel.ITypedList)
			{

				System.ComponentModel.PropertyDescriptorCollection columnInfo = ((System.ComponentModel.ITypedList)DataSource).GetItemProperties(null);
				numColumnsInDataSource = columnInfo.Count;
				ColumnsCount = FixedColumns + columnInfo.Count;
				if (RowHeadersVisible)
				{
					int colIndex = 0;
					foreach (System.ComponentModel.PropertyDescriptor columnData in columnInfo)
					{
						Columns[colIndex++].HeaderText = columnData.DisplayName;
					} // foreach
				} // if

			} // if
			if (DataSource is IList)
			{
				IList data = DataSource as IList;
				int _FixedRows = FixedRows;
				RowsCount = _FixedRows + data.Count;
				//First check if there is data
				if (data.Count > 0 && numColumnsInDataSource > 0)
				{
					int _FixedColumns = FixedColumns;
					int rowindex = _FixedRows;
					foreach (object rowObj in data)
					{
						DataRowView rowView = rowObj as DataRowView;
						if (rowObj != null)
						{
							for (int i = 0; i < numColumnsInDataSource; i++)
								this[_FixedColumns + i, rowindex].Value = rowView[i];
						} // if
						rowindex++;
					} // foreach

				} // if

			} // if
			if (DataSource is DataTable)
			{
				DataTable data = (DataTable)DataSource;
				if (data.Rows.Count > 0)
				{
					numColumnsInDataSource = data.Columns.Count;
					ColumnsCount = numColumnsInDataSource;
					//fill the first rowheader with the values.
					for (int j = 0; j < numColumnsInDataSource; j++)
					{
						Columns[j].HeaderText = data.Columns[j].ToString();
					}
				}
				if (data.Rows.Count > 0 && numColumnsInDataSource > 0)
				{
					//fill the grid with data.
					int rowIndex = 1;
					RowsCount = data.Rows.Count + 1;
					foreach (System.Data.DataRow rowObj in data.Rows)
					{
						System.Data.DataRow rowView = rowObj as System.Data.DataRow;

						if (rowObj != null)
						{

							for (int i = 0; i < numColumnsInDataSource; i++)
								this[rowIndex, i].Value = rowView[i];
						} // if
						rowIndex++;
					}
				}
			}
		}

		/// <summary>
		/// This overload is maded to provide another indexer that
		/// will eliminate the need for generating narrowing operator in expressions like
		/// grid(10 / ColumnsCount,10 mod ColumnsCount)
		/// </summary>
		/// <param name="rowindex"></param>
		/// <param name="columnindex"></param>
		/// <returns></returns>
		public DataGridViewCell this[Double rowindex, Double columnindex]
		{
			get
			{
				return this[(int)columnindex, (int)rowindex];
			}
			set
			{
				this[(int)columnindex, (int)rowindex] = value;
			}
		}

		/// <summary>
		/// Obtains a cell from the grid.
		/// </summary>
		/// <param name="columnindex">Index of the desired column.</param>
		/// <param name="rowindex">Index of the desired row.</param>
		/// <returns></returns>
		public new DataGridViewCell this[int rowindex, int columnindex]
		{
			get
			{
				return GetCell(rowindex, columnindex);
			}
			set
			{
				base[columnindex, rowindex] = value;
			}

		}

		#region ISupportInitialize Members and Behaviour Switching Management

		private bool isInitializing;



		/// <summary>
		/// Implements the ISupportInitialize.BeginInit method.
		/// It sets up a temporal ValueHolderBehavior during the component initialization to
		/// hold values until the EndInit is called.
		/// </summary>
		public virtual void BeginInit()
		{
			isInitializing = true;
		}
		/// <summary>
		/// Implements the ISupportInitialize.EndInit method.
		/// It sets the grid behavior according the Compatibility mode and delegates EndInit logic to the behaviour.
		/// </summary>
		public virtual void EndInit()
		{
			SetValuesFromInitializeComponents();
		}

		private void SetValuesFromInitializeComponents()
		{
			isInitializing = false;
			int rowHeight = (int)Font.GetHeight() + DEFAULT_ROW_HEIGHT_PAD;
			RowTemplate.Height = rowHeight;
			ColumnHeadersHeight = rowHeight;

			var _GridLineWidth = InitFromTempValues("GridLineWidth");
			GridLineWidth = (_GridLineWidth == UNSETVALUE) ? DEFAULT_GRIDLINEWIDTH : _GridLineWidth;
			// if
			if (myValues.ContainsKey("SelectionMode") && ((DataGridViewSelectionMode)myValues["SelectionMode"]) != DataGridViewSelectionMode.CellSelect)
			{
				SelectionMode = ((DataGridViewSelectionMode)myValues["SelectionMode"]);
			} // if
			int _RowsCount = InitFromTempValues("RowsCount");
			_RowsCount = (_RowsCount == UNSETVALUE) ? DEFAULT_ROWSCOUNT : _RowsCount;

			int _FixedRows = InitFromTempValues("FixedRows");
			_FixedRows = (_FixedRows == UNSETVALUE) ? DEFAULT_FIXED_ROWS : _FixedRows;

			int _ColumnsCount = InitFromTempValues("ColumnsCount");
			_ColumnsCount = (_ColumnsCount == UNSETVALUE) ? DEFAULT_COLUMNSCOUNT : _ColumnsCount;

			int _FixedColumns = InitFromTempValues("FixedColumns");
			_FixedColumns = (_FixedColumns == UNSETVALUE) ? DataGridViewFlex.DEFAULT_FIXED_COLUMNS : _FixedColumns;

			if (_FixedRows == -1 || _FixedColumns == -1 || _RowsCount < 0 ||
				_FixedRows > _RowsCount ||
				_FixedColumns > _ColumnsCount)
			{
				//If there is any invalid value, then reset to defaults
				FixedRows = DEFAULT_FIXED_ROWS;
				FixedColumns = DEFAULT_FIXED_COLUMNS;
				RowsCount = DEFAULT_ROWSCOUNT;
				ColumnsCount = DEFAULT_COLUMNSCOUNT;
			} // if
			else
			{
                if (_FixedColumns >= ColumnsCount)
                {
                    ColumnsCount = _ColumnsCount;
                    FixedColumns = _FixedColumns;
                }
                else
                {
                    FixedColumns = _FixedColumns;
                    ColumnsCount = _ColumnsCount;
                }

                if (_FixedRows >= RowsCount)
                {
                    RowsCount = _RowsCount;
                    FixedRows = _FixedRows;
                }
                else
                {
                    FixedRows = _FixedRows;
                    RowsCount = _RowsCount;
                }

                if (AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.None)
				{
					// Adjust column width after the fields FixedColumns and ColumnsCount are set
					AdjustColumnsSize();
				}
			} // else
			if (myValues.ContainsKey("RowHeightMin") && Convert.ToInt32(myValues["RowHeightMin"]) > 0)
			{
				RowHeightMin = Convert.ToInt32(myValues["RowHeightMin"]);
			} // if
			if (myValues.ContainsKey("AllowBigSelection"))
				AllowBigSelection = Convert.ToBoolean(myValues["AllowBigSelection"]);

			if (myValues.ContainsKey("BackColorFixed") && ((Color)myValues["BackColorFixed"]) != Color.Empty)
			{
				BackColorFixed = (Color)myValues["BackColorFixed"];
			} // if
			if (myValues.ContainsKey("FocusRect") && ((FocusRectSettings)myValues["FocusRect"]) != FocusRectSettings.FocusNone)
			{
				FocusRect = ((FocusRectSettings)myValues["FocusRect"]);
			} // if

			if (myValues.ContainsKey("HighLight") && ((HighLightSettings)myValues["HighLight"]) != HighLightSettings.HighlightNever)
			{
				HighLight = ((HighLightSettings)myValues["HighLight"]);
			} // if
			if (myValues.ContainsKey("DataSource"))
				DataSource = myValues["DataSource"];
		} // if

		/// <summary>
		/// Adjust each column size based on the property Font.Size
		/// </summary>
		private void AdjustColumnsSize()
		{
			int ColumnSize = DEFAULT_COLUMN_SIZE_MULTIPLIER * (int)Font.Size;
			foreach (DataGridViewColumn column in Columns)
			{
				column.Width = ColumnSize;
			}
			RowHeadersWidth = ColumnSize;
		}

		/// <summary>
		/// Adjust row height depending on font height
		/// </summary>
		private void AdjustRowHeight()
		{
			int rowHeight = (int)Font.GetHeight() + DEFAULT_ROW_HEIGHT_PAD;
			RowTemplate.Height = rowHeight;
			ColumnHeadersHeight = rowHeight;
		}

		private int InitFromTempValues(string key)
		{
			if (myValues.ContainsKey(key))
				return Convert.ToInt32(myValues[key]);
			return UNSETVALUE;
		}



		#endregion

		void ExtendedDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (AllowRowSelection)
			{
				ClearSelection();
				foreach (DataGridViewColumn col in Columns)
				{
					if (col.Visible)
					{
						CurrentCell = this[e.RowIndex, col.Index];
						break;
					}
					else
						continue;

				} // foreach
				DataGridViewRow currentRow = Rows[e.RowIndex];
				foreach (DataGridViewCell cell in currentRow.Cells)
				{
					cell.Selected = true;
				}
			}
		}

		/// <summary>
		/// Tries to get the left and top padding that the text should have so is properly align in the cell.
		/// </summary>
		/// <param name="e">The data grid view cell painting event args for the corresponding cell</param>
		/// <returns>A point with how much x-padding and y-padding (left, top) is needed</returns>
		private Point GetPaddingForCell(DataGridViewCellPaintingEventArgs e)
		{
			Point padding = new Point();
			string text = Convert.ToString(e.Value);
			SizeF textSize = e.Graphics.MeasureString(text, e.CellStyle.Font);

			// The default for left alignments
			padding.X = DEFAULT_CELL_PADDING;

			// first get the X padding
			switch (e.CellStyle.Alignment)
			{
				case DataGridViewContentAlignment.TopRight:
				case DataGridViewContentAlignment.MiddleRight:
				case DataGridViewContentAlignment.BottomRight:
					// if the text fits in the current cells, -2 so is not too close to border
					if (e.CellBounds.Width > textSize.Width)
					{
						padding.X = (int)(e.CellBounds.Width - textSize.Width - DEFAULT_CELL_PADDING);
					}
					// else leave the default X padding
					break;
				case DataGridViewContentAlignment.TopCenter:
				case DataGridViewContentAlignment.MiddleCenter:
				case DataGridViewContentAlignment.BottomCenter:
					// if the text fits in the current cells
					if (e.CellBounds.Width > textSize.Width)
					{
						int spaceRemaining = (int)(e.CellBounds.Width - textSize.Width);
						padding.X = spaceRemaining / 2;
					}
					break;
			}

			// now the the top padding, TODO take into account actual cell height
			switch (e.CellStyle.Alignment)
			{
				case DataGridViewContentAlignment.TopLeft:
				case DataGridViewContentAlignment.TopCenter:
				case DataGridViewContentAlignment.TopRight:
					padding.Y = 0;
					break;
				case DataGridViewContentAlignment.MiddleLeft:
				case DataGridViewContentAlignment.MiddleCenter:
				case DataGridViewContentAlignment.MiddleRight:
					padding.Y = 1;
					break;
				case DataGridViewContentAlignment.BottomLeft:
				case DataGridViewContentAlignment.BottomCenter:
				case DataGridViewContentAlignment.BottomRight:
					padding.Y = 2;
					break;
			}

			return padding;
		}

		/// <summary>
		/// Re-implementation of cell painting so the cell is more alike VB6.
		/// ** There might be properties we are not setting when drawing the cell
		/// </summary>
		/// <param name="sender">The grid</param>
		/// <param name="e">The data grid view cell painting event args for the corresponding cell</param>
		private void ExtendedDataGridView_CellPainting(Object sender, DataGridViewCellPaintingEventArgs e)
		{
			Brush gridBrush = new SolidBrush(this.GridColor);
#if (NET35)
			SolidBrush backColorBrush = new SolidBrush((e.State | DataGridViewElementStates.Selected) == e.State ?
                e.CellStyle.SelectionBackColor : e.CellStyle.BackColor);
#else
			SolidBrush backColorBrush = new SolidBrush(e.State.HasFlag(DataGridViewElementStates.Selected) ?
				e.CellStyle.SelectionBackColor : e.CellStyle.BackColor);
#endif
			Pen gridLinePen = new Pen(gridBrush);
			Point padding = GetPaddingForCell(e);

			// Erase the cell.
			e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

			//Draw the grid lines (only the right And bottom lines; DataGridView takes care of the others).
			e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
			e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

			//Draw the text content of the cell, ignoring alignment.
			if (e.Value != null)
			{
				e.Graphics.DrawString(Convert.ToString(e.Value), e.CellStyle.Font, Brushes.Black,
									   e.CellBounds.X + padding.X, e.CellBounds.Y + padding.Y,
									  StringFormat.GenericTypographic);
			}

			e.Handled = true;
		}

		/// <summary>
		/// Processes the Up and Down Keys to trigger KeyUp and KeyDown handlers
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			const int WM_KEYDOWN = 0x100;
			//            const int WM_KEYUP = 0x101;
			KeyEventArgs keyevent;
			if (msg.Msg == WM_KEYDOWN)
			{
				keyevent = GetKeyEventArgs(keyData);
				if (keyevent != null)
				{
					foreach (KeyEventHandler handler in keydownevents)
					{
						handler.Invoke(this, keyevent);
					} // foreach
					if (keyevent.Handled)
						return true;
					if (keyevent != null)
					{
						foreach (KeyEventHandler handler in keyupevents)
						{
							handler.Invoke(this, keyevent);
						} // foreach
						if (keyevent.Handled)
							return true;
					} // if
				} // if
			}
			return base.ProcessCmdKey(ref msg, keyData);

		}

		private static KeyEventArgs GetKeyEventArgs(Keys keyData)
		{
			KeyEventArgs keyevent = null;
			switch (keyData)
			{
				case Keys.Tab:
					keyevent = new KeyEventArgs(Keys.Tab);
					break;
				case Keys.Down:
					keyevent = new KeyEventArgs(Keys.Down);
					break;
				case Keys.Up:
					keyevent = new KeyEventArgs(Keys.Up);
					break;

			}
			return keyevent;
		}


		KeyEventHandler _controlKeyDown;
		KeyEventHandler _controlKeyUp;
		KeyPressEventHandler _controlKeyPress;


		List<KeyEventHandler> keydownevents = new List<KeyEventHandler>();


		/// <summary>
		/// Hides DataGridView KeyDown Implementation to provide a functionality closer to the
		/// KeyDown event in VB6
		/// </summary>
		public new event KeyEventHandler KeyDown
		{
			add
			{
				keydownevents.Add(value);
				base.KeyDown += value;
			}
			remove
			{
				try
				{
					keydownevents.Remove(value);
				}
				catch
				{
				} // catch
				base.KeyDown -= value;
			}
		}



		List<KeyEventHandler> keyupevents = new List<KeyEventHandler>();


		/// <summary>
		/// Hides DataGridView KeyUp Implementation to provide a functionality closer to the
		/// KeyUp event in VB6
		/// </summary>
		public new event KeyEventHandler KeyUp
		{
			add
			{
				keyupevents.Add(value);
				base.KeyUp += value;
			}
			remove
			{
				try
				{
					keyupevents.Remove(value);
				}
				catch
				{
				} // catch
				base.KeyUp -= value;
			}
		}

		/// <summary>
		/// Attaches Key Events to Control
		/// </summary>
		/// <param name="control">Control to be modified</param>
		public void AttachKeyEventsToControl(Control control)
		{
			control.KeyDown -= _controlKeyDown;
			control.KeyPress -= _controlKeyPress;
			control.KeyUp -= _controlKeyUp;


			control.KeyDown += _controlKeyDown;
			control.KeyPress += _controlKeyPress;
			control.KeyUp += _controlKeyUp;
		}

		void control_KeyUp(object sender, KeyEventArgs e)
		{
			foreach (KeyEventHandler handler in keyupevents)
			{
				handler.Invoke(sender, e);
			} // foreach

		}

		void control_KeyPress(object sender, KeyPressEventArgs e)
		{
			OnKeyPress(e);
		}

		void control_KeyDown(object sender, KeyEventArgs e)
		{
			foreach (KeyEventHandler handler in keydownevents)
			{
				handler.Invoke(sender, e);
			} // foreach
		}

		/// <summary>
		/// Overrides OnSelectionChanged.
		/// </summary>
		/// <param name="e">The EventArgs.</param>
		protected override void OnSelectionChanged(EventArgs e)
		{
			if (!_suppressSelectionChanged)
				base.OnSelectionChanged(e);
		}

		#region Not Implemented

		private bool redraw = true;

		/// <summary>
		/// Redraw
		/// </summary>
		public bool Redraw
		{
			get
			{
				return redraw;
			}
			set
			{
				if (value == redraw) return;
				redraw = value;
				if (value)
				{
					ResumeLayout();
				}
				else
				{
					SuspendLayout();
				}
			}
		}


		/// <summary>
		/// Gets of sets the font of the DataGrid
		/// </summary>
		public override Font Font
		{
			get { return base.Font; }

			set
			{
				base.Font = value;
				// Adjust columns width depending on font size
				if (AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.None)
				{
					this.AdjustColumnsSize();
				}

				// Adjust rows height depending on font size
				this.AdjustRowHeight();
			}
		}
		#endregion
	}
}
