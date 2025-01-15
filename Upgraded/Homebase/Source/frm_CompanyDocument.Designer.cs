
namespace JETNET_Homebase
{
	partial class frm_CompanyDocument
	{

		#region "Upgrade Support "
		private static frm_CompanyDocument m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_CompanyDocument DefInstance
		{
			get
			{
				if (m_vb6FormDefInstance is null || m_vb6FormDefInstance.IsDisposed)
				{
					m_InitializingDefInstance = true;
					m_vb6FormDefInstance = CreateInstance();
					m_InitializingDefInstance = false;
				}
				return m_vb6FormDefInstance;
			}
			set
			{
				m_vb6FormDefInstance = value;
			}
		}

		#endregion
		#region "Windows Form Designer generated code "
		public static frm_CompanyDocument CreateInstance()
		{
			frm_CompanyDocument theInstance = new frm_CompanyDocument();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "txtCompDocumentDescription", "txtCompDragDocument", "grd_CompDocument", "calCompDocumentDate", "_wbCompBrowser1_0", "txtCompDocumentId", "txtCompDocumentSubject", "cmdCompDocumentMove", "cmdCompDocumentDelete", "cmdCompDocumentView", "cmdCompDocumentSave", "cmdCompDocumentNew", "frmCompDocumentControl", "cmbCompDocumentType", "txtCompDocumentDate", "lblCompDocDate", "lblSubDocumentId", "_lblCompLabel_38", "_lblCompLabel_39", "_lblSubLabel_40", "frmCompDocument", "lblCompLabel", "lblSubLabel", "wbCompBrowser1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtCompDocumentDescription;
		public System.Windows.Forms.TextBox txtCompDragDocument;
		public UpgradeHelpers.DataGridViewFlex grd_CompDocument;
		public System.Windows.Forms.MonthCalendar calCompDocumentDate;
		private System.Windows.Forms.WebBrowser _wbCompBrowser1_0;
		public System.Windows.Forms.TextBox txtCompDocumentId;
		public System.Windows.Forms.TextBox txtCompDocumentSubject;
		public System.Windows.Forms.Button cmdCompDocumentMove;
		public System.Windows.Forms.Button cmdCompDocumentDelete;
		public System.Windows.Forms.Button cmdCompDocumentView;
		public System.Windows.Forms.Button cmdCompDocumentSave;
		public System.Windows.Forms.Button cmdCompDocumentNew;
		public System.Windows.Forms.GroupBox frmCompDocumentControl;
		public System.Windows.Forms.ComboBox cmbCompDocumentType;
		public System.Windows.Forms.TextBox txtCompDocumentDate;
		public System.Windows.Forms.Label lblCompDocDate;
		public System.Windows.Forms.Label lblSubDocumentId;
		private System.Windows.Forms.Label _lblCompLabel_38;
		private System.Windows.Forms.Label _lblCompLabel_39;
		private System.Windows.Forms.Label _lblSubLabel_40;
		public System.Windows.Forms.GroupBox frmCompDocument;
		public System.Windows.Forms.Label[] lblCompLabel = new System.Windows.Forms.Label[40];
		public System.Windows.Forms.Label[] lblSubLabel = new System.Windows.Forms.Label[41];
		public System.Windows.Forms.WebBrowser[] wbCompBrowser1 = new System.Windows.Forms.WebBrowser[1];
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CompanyDocument));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			txtCompDocumentDescription = new System.Windows.Forms.TextBox();
			txtCompDragDocument = new System.Windows.Forms.TextBox();
			grd_CompDocument = new UpgradeHelpers.DataGridViewFlex(components);
			calCompDocumentDate = new System.Windows.Forms.MonthCalendar();
			_wbCompBrowser1_0 = new System.Windows.Forms.WebBrowser();
			frmCompDocument = new System.Windows.Forms.GroupBox();
			txtCompDocumentId = new System.Windows.Forms.TextBox();
			txtCompDocumentSubject = new System.Windows.Forms.TextBox();
			frmCompDocumentControl = new System.Windows.Forms.GroupBox();
			cmdCompDocumentMove = new System.Windows.Forms.Button();
			cmdCompDocumentDelete = new System.Windows.Forms.Button();
			cmdCompDocumentView = new System.Windows.Forms.Button();
			cmdCompDocumentSave = new System.Windows.Forms.Button();
			cmdCompDocumentNew = new System.Windows.Forms.Button();
			cmbCompDocumentType = new System.Windows.Forms.ComboBox();
			txtCompDocumentDate = new System.Windows.Forms.TextBox();
			lblCompDocDate = new System.Windows.Forms.Label();
			lblSubDocumentId = new System.Windows.Forms.Label();
			_lblCompLabel_38 = new System.Windows.Forms.Label();
			_lblCompLabel_39 = new System.Windows.Forms.Label();
			_lblSubLabel_40 = new System.Windows.Forms.Label();
			frmCompDocument.SuspendLayout();
			frmCompDocumentControl.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_CompDocument).BeginInit();
			// 
			// txtCompDocumentDescription
			// 
			txtCompDocumentDescription.AcceptsReturn = true;
			txtCompDocumentDescription.AllowDrop = true;
			txtCompDocumentDescription.BackColor = System.Drawing.SystemColors.Window;
			txtCompDocumentDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtCompDocumentDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompDocumentDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompDocumentDescription.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompDocumentDescription.Location = new System.Drawing.Point(2, 132);
			txtCompDocumentDescription.MaxLength = 2000;
			txtCompDocumentDescription.Multiline = true;
			txtCompDocumentDescription.Name = "txtCompDocumentDescription";
			txtCompDocumentDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompDocumentDescription.Size = new System.Drawing.Size(475, 85);
			txtCompDocumentDescription.TabIndex = 10;
			// 
			// txtCompDragDocument
			// 
			txtCompDragDocument.AcceptsReturn = true;
			txtCompDragDocument.AllowDrop = true;
			txtCompDragDocument.BackColor = System.Drawing.SystemColors.Menu;
			txtCompDragDocument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtCompDragDocument.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompDragDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompDragDocument.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompDragDocument.Location = new System.Drawing.Point(481, 132);
			txtCompDragDocument.MaxLength = 2000;
			txtCompDragDocument.Multiline = true;
			txtCompDragDocument.Name = "txtCompDragDocument";
			txtCompDragDocument.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompDragDocument.Size = new System.Drawing.Size(177, 83);
			txtCompDragDocument.TabIndex = 0;
			txtCompDragDocument.TabStop = false;
			txtCompDragDocument.Text = "Drag Document Here\r\n";
			txtCompDragDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtCompDragDocument.DoubleClick += new System.EventHandler(txtCompDragDocument_DoubleClick);
			// 
			// grd_CompDocument
			// 
			grd_CompDocument.AllowDrop = true;
			grd_CompDocument.AllowUserToAddRows = false;
			grd_CompDocument.AllowUserToDeleteRows = false;
			grd_CompDocument.AllowUserToResizeColumns = false;
			grd_CompDocument.AllowUserToResizeRows = false;
			grd_CompDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_CompDocument.ColumnsCount = 2;
			grd_CompDocument.FixedColumns = 1;
			grd_CompDocument.FixedRows = 1;
			grd_CompDocument.Location = new System.Drawing.Point(2, 218);
			grd_CompDocument.Name = "grd_CompDocument";
			grd_CompDocument.ReadOnly = true;
			grd_CompDocument.RowsCount = 2;
			grd_CompDocument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_CompDocument.ShowCellToolTips = false;
			grd_CompDocument.Size = new System.Drawing.Size(839, 115);
			grd_CompDocument.StandardTab = true;
			grd_CompDocument.TabIndex = 11;
			grd_CompDocument.Click += new System.EventHandler(grd_CompDocument_Click);
			// 
			// calCompDocumentDate
			// 
			calCompDocumentDate.AllowDrop = true;
			calCompDocumentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			calCompDocumentDate.ForeColor = System.Drawing.SystemColors.ControlText;
			calCompDocumentDate.Location = new System.Drawing.Point(663, 63);
			calCompDocumentDate.Name = "calCompDocumentDate";
			calCompDocumentDate.Size = new System.Drawing.Size(178, 154);
			calCompDocumentDate.TabIndex = 9;
			calCompDocumentDate.TabStop = false;
			// 
			// _wbCompBrowser1_0
			// 
			_wbCompBrowser1_0.AllowWebBrowserDrop = true;
			_wbCompBrowser1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_wbCompBrowser1_0.Location = new System.Drawing.Point(2, 341);
			_wbCompBrowser1_0.Name = "_wbCompBrowser1_0";
			_wbCompBrowser1_0.Size = new System.Drawing.Size(841, 337);
			_wbCompBrowser1_0.TabIndex = 12;
			// 
			// frmCompDocument
			// 
			frmCompDocument.AllowDrop = true;
			frmCompDocument.BackColor = System.Drawing.SystemColors.Control;
			frmCompDocument.Controls.Add(txtCompDocumentId);
			frmCompDocument.Controls.Add(txtCompDocumentSubject);
			frmCompDocument.Controls.Add(frmCompDocumentControl);
			frmCompDocument.Controls.Add(cmbCompDocumentType);
			frmCompDocument.Controls.Add(txtCompDocumentDate);
			frmCompDocument.Controls.Add(lblCompDocDate);
			frmCompDocument.Controls.Add(lblSubDocumentId);
			frmCompDocument.Controls.Add(_lblCompLabel_38);
			frmCompDocument.Controls.Add(_lblCompLabel_39);
			frmCompDocument.Controls.Add(_lblSubLabel_40);
			frmCompDocument.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmCompDocument.Enabled = true;
			frmCompDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmCompDocument.ForeColor = System.Drawing.SystemColors.ControlText;
			frmCompDocument.Location = new System.Drawing.Point(2, 2);
			frmCompDocument.Name = "frmCompDocument";
			frmCompDocument.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmCompDocument.Size = new System.Drawing.Size(839, 127);
			frmCompDocument.TabIndex = 14;
			frmCompDocument.Visible = true;
			// 
			// txtCompDocumentId
			// 
			txtCompDocumentId.AcceptsReturn = true;
			txtCompDocumentId.AllowDrop = true;
			txtCompDocumentId.BackColor = System.Drawing.SystemColors.Window;
			txtCompDocumentId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtCompDocumentId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompDocumentId.Enabled = false;
			txtCompDocumentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompDocumentId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompDocumentId.Location = new System.Drawing.Point(550, 12);
			txtCompDocumentId.MaxLength = 120;
			txtCompDocumentId.Name = "txtCompDocumentId";
			txtCompDocumentId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompDocumentId.Size = new System.Drawing.Size(68, 21);
			txtCompDocumentId.TabIndex = 2;
			txtCompDocumentId.Text = "0";
			txtCompDocumentId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtCompDocumentSubject
			// 
			txtCompDocumentSubject.AcceptsReturn = true;
			txtCompDocumentSubject.AllowDrop = true;
			txtCompDocumentSubject.BackColor = System.Drawing.SystemColors.Window;
			txtCompDocumentSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtCompDocumentSubject.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompDocumentSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompDocumentSubject.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompDocumentSubject.Location = new System.Drawing.Point(92, 41);
			txtCompDocumentSubject.MaxLength = 120;
			txtCompDocumentSubject.Name = "txtCompDocumentSubject";
			txtCompDocumentSubject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompDocumentSubject.Size = new System.Drawing.Size(527, 21);
			txtCompDocumentSubject.TabIndex = 3;
			// 
			// frmCompDocumentControl
			// 
			frmCompDocumentControl.AllowDrop = true;
			frmCompDocumentControl.BackColor = System.Drawing.SystemColors.Control;
			frmCompDocumentControl.Controls.Add(cmdCompDocumentMove);
			frmCompDocumentControl.Controls.Add(cmdCompDocumentDelete);
			frmCompDocumentControl.Controls.Add(cmdCompDocumentView);
			frmCompDocumentControl.Controls.Add(cmdCompDocumentSave);
			frmCompDocumentControl.Controls.Add(cmdCompDocumentNew);
			frmCompDocumentControl.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmCompDocumentControl.Enabled = true;
			frmCompDocumentControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmCompDocumentControl.ForeColor = System.Drawing.SystemColors.ControlText;
			frmCompDocumentControl.Location = new System.Drawing.Point(90, 66);
			frmCompDocumentControl.Name = "frmCompDocumentControl";
			frmCompDocumentControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmCompDocumentControl.Size = new System.Drawing.Size(313, 49);
			frmCompDocumentControl.TabIndex = 15;
			frmCompDocumentControl.Visible = true;
			// 
			// cmdCompDocumentMove
			// 
			cmdCompDocumentMove.AllowDrop = true;
			cmdCompDocumentMove.BackColor = System.Drawing.SystemColors.Control;
			cmdCompDocumentMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCompDocumentMove.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCompDocumentMove.Location = new System.Drawing.Point(249, 15);
			cmdCompDocumentMove.Name = "cmdCompDocumentMove";
			cmdCompDocumentMove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCompDocumentMove.Size = new System.Drawing.Size(55, 25);
			cmdCompDocumentMove.TabIndex = 13;
			cmdCompDocumentMove.Text = "&Move";
			cmdCompDocumentMove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCompDocumentMove.UseVisualStyleBackColor = false;
			cmdCompDocumentMove.Click += new System.EventHandler(cmdCompDocumentMove_Click);
			// 
			// cmdCompDocumentDelete
			// 
			cmdCompDocumentDelete.AllowDrop = true;
			cmdCompDocumentDelete.BackColor = System.Drawing.SystemColors.Control;
			cmdCompDocumentDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCompDocumentDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCompDocumentDelete.Location = new System.Drawing.Point(189, 15);
			cmdCompDocumentDelete.Name = "cmdCompDocumentDelete";
			cmdCompDocumentDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCompDocumentDelete.Size = new System.Drawing.Size(55, 25);
			cmdCompDocumentDelete.TabIndex = 8;
			cmdCompDocumentDelete.Text = "&Delete";
			cmdCompDocumentDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCompDocumentDelete.UseVisualStyleBackColor = false;
			cmdCompDocumentDelete.Click += new System.EventHandler(cmdCompDocumentDelete_Click);
			// 
			// cmdCompDocumentView
			// 
			cmdCompDocumentView.AllowDrop = true;
			cmdCompDocumentView.BackColor = System.Drawing.SystemColors.Control;
			cmdCompDocumentView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCompDocumentView.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCompDocumentView.Location = new System.Drawing.Point(129, 15);
			cmdCompDocumentView.Name = "cmdCompDocumentView";
			cmdCompDocumentView.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCompDocumentView.Size = new System.Drawing.Size(55, 25);
			cmdCompDocumentView.TabIndex = 7;
			cmdCompDocumentView.Text = "&View";
			cmdCompDocumentView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCompDocumentView.UseVisualStyleBackColor = false;
			cmdCompDocumentView.Click += new System.EventHandler(cmdCompDocumentView_Click);
			// 
			// cmdCompDocumentSave
			// 
			cmdCompDocumentSave.AllowDrop = true;
			cmdCompDocumentSave.BackColor = System.Drawing.SystemColors.Control;
			cmdCompDocumentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCompDocumentSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCompDocumentSave.Location = new System.Drawing.Point(67, 15);
			cmdCompDocumentSave.Name = "cmdCompDocumentSave";
			cmdCompDocumentSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCompDocumentSave.Size = new System.Drawing.Size(55, 25);
			cmdCompDocumentSave.TabIndex = 6;
			cmdCompDocumentSave.Text = "&Save";
			cmdCompDocumentSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCompDocumentSave.UseVisualStyleBackColor = false;
			cmdCompDocumentSave.Click += new System.EventHandler(cmdCompDocumentSave_Click);
			// 
			// cmdCompDocumentNew
			// 
			cmdCompDocumentNew.AllowDrop = true;
			cmdCompDocumentNew.BackColor = System.Drawing.SystemColors.Control;
			cmdCompDocumentNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCompDocumentNew.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCompDocumentNew.Location = new System.Drawing.Point(6, 15);
			cmdCompDocumentNew.Name = "cmdCompDocumentNew";
			cmdCompDocumentNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCompDocumentNew.Size = new System.Drawing.Size(55, 25);
			cmdCompDocumentNew.TabIndex = 5;
			cmdCompDocumentNew.Text = "&New";
			cmdCompDocumentNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCompDocumentNew.UseVisualStyleBackColor = false;
			cmdCompDocumentNew.Click += new System.EventHandler(cmdCompDocumentNew_Click);
			// 
			// cmbCompDocumentType
			// 
			cmbCompDocumentType.AllowDrop = true;
			cmbCompDocumentType.BackColor = System.Drawing.SystemColors.Window;
			cmbCompDocumentType.CausesValidation = true;
			cmbCompDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbCompDocumentType.Enabled = true;
			cmbCompDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbCompDocumentType.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbCompDocumentType.IntegralHeight = true;
			cmbCompDocumentType.Location = new System.Drawing.Point(92, 14);
			cmbCompDocumentType.Name = "cmbCompDocumentType";
			cmbCompDocumentType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbCompDocumentType.Size = new System.Drawing.Size(246, 21);
			cmbCompDocumentType.Sorted = false;
			cmbCompDocumentType.TabIndex = 1;
			cmbCompDocumentType.TabStop = true;
			cmbCompDocumentType.Visible = true;
			cmbCompDocumentType.SelectionChangeCommitted += new System.EventHandler(cmbCompDocumentType_SelectionChangeCommitted);
			// 
			// txtCompDocumentDate
			// 
			txtCompDocumentDate.AcceptsReturn = true;
			txtCompDocumentDate.AllowDrop = true;
			txtCompDocumentDate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txtCompDocumentDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompDocumentDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompDocumentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompDocumentDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompDocumentDate.Location = new System.Drawing.Point(748, 36);
			txtCompDocumentDate.MaxLength = 0;
			txtCompDocumentDate.Name = "txtCompDocumentDate";
			txtCompDocumentDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompDocumentDate.Size = new System.Drawing.Size(82, 19);
			txtCompDocumentDate.TabIndex = 4;
			txtCompDocumentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtCompDocumentDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCompDocumentDate_KeyPress);
			// 
			// lblCompDocDate
			// 
			lblCompDocDate.AllowDrop = true;
			lblCompDocDate.BackColor = System.Drawing.SystemColors.Control;
			lblCompDocDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompDocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompDocDate.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompDocDate.Location = new System.Drawing.Point(664, 40);
			lblCompDocDate.MinimumSize = new System.Drawing.Size(78, 16);
			lblCompDocDate.Name = "lblCompDocDate";
			lblCompDocDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompDocDate.Size = new System.Drawing.Size(78, 16);
			lblCompDocDate.TabIndex = 20;
			lblCompDocDate.Text = "Document Date";
			// 
			// lblSubDocumentId
			// 
			lblSubDocumentId.AllowDrop = true;
			lblSubDocumentId.BackColor = System.Drawing.SystemColors.Control;
			lblSubDocumentId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubDocumentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubDocumentId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubDocumentId.Location = new System.Drawing.Point(474, 16);
			lblSubDocumentId.MinimumSize = new System.Drawing.Size(70, 16);
			lblSubDocumentId.Name = "lblSubDocumentId";
			lblSubDocumentId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubDocumentId.Size = new System.Drawing.Size(70, 16);
			lblSubDocumentId.TabIndex = 19;
			lblSubDocumentId.Text = "Document Id";
			lblSubDocumentId.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblCompLabel_38
			// 
			_lblCompLabel_38.AllowDrop = true;
			_lblCompLabel_38.AutoSize = true;
			_lblCompLabel_38.BackColor = System.Drawing.Color.Transparent;
			_lblCompLabel_38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompLabel_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompLabel_38.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompLabel_38.Location = new System.Drawing.Point(10, 18);
			_lblCompLabel_38.MinimumSize = new System.Drawing.Size(76, 13);
			_lblCompLabel_38.Name = "_lblCompLabel_38";
			_lblCompLabel_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompLabel_38.Size = new System.Drawing.Size(76, 13);
			_lblCompLabel_38.TabIndex = 18;
			_lblCompLabel_38.Text = "Document Type";
			// 
			// _lblCompLabel_39
			// 
			_lblCompLabel_39.AllowDrop = true;
			_lblCompLabel_39.AutoSize = true;
			_lblCompLabel_39.BackColor = System.Drawing.Color.Transparent;
			_lblCompLabel_39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompLabel_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompLabel_39.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompLabel_39.Location = new System.Drawing.Point(10, 44);
			_lblCompLabel_39.MinimumSize = new System.Drawing.Size(36, 13);
			_lblCompLabel_39.Name = "_lblCompLabel_39";
			_lblCompLabel_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompLabel_39.Size = new System.Drawing.Size(36, 13);
			_lblCompLabel_39.TabIndex = 17;
			_lblCompLabel_39.Text = "Subject";
			// 
			// _lblSubLabel_40
			// 
			_lblSubLabel_40.AllowDrop = true;
			_lblSubLabel_40.AutoSize = true;
			_lblSubLabel_40.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_40.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_40.Location = new System.Drawing.Point(6, 106);
			_lblSubLabel_40.MinimumSize = new System.Drawing.Size(53, 13);
			_lblSubLabel_40.Name = "_lblSubLabel_40";
			_lblSubLabel_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_40.Size = new System.Drawing.Size(53, 13);
			_lblSubLabel_40.TabIndex = 16;
			_lblSubLabel_40.Text = "Description";
			// 
			// frm_CompanyDocument
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(847, 685);
			Controls.Add(txtCompDocumentDescription);
			Controls.Add(txtCompDragDocument);
			Controls.Add(grd_CompDocument);
			Controls.Add(calCompDocumentDate);
			Controls.Add(_wbCompBrowser1_0);
			Controls.Add(frmCompDocument);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(277, 117);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_CompanyDocument";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Company Document";
			commandButtonHelper1.SetStyle(cmdCompDocumentMove, 0);
			commandButtonHelper1.SetStyle(cmdCompDocumentDelete, 0);
			commandButtonHelper1.SetStyle(cmdCompDocumentView, 0);
			commandButtonHelper1.SetStyle(cmdCompDocumentSave, 0);
			commandButtonHelper1.SetStyle(cmdCompDocumentNew, 0);
			ToolTipMain.SetToolTip(txtCompDragDocument, "Drag Document Here To Add or Double Click To Open Browse Window");
			ToolTipMain.SetToolTip(txtCompDocumentSubject, "Enter Subject of Document");
			ToolTipMain.SetToolTip(cmdCompDocumentMove, "Click To Move Selected Document To Another Company");
			ToolTipMain.SetToolTip(cmdCompDocumentDelete, "Click To Delete Selected Document");
			ToolTipMain.SetToolTip(cmdCompDocumentView, "Click To View Document In Seperate Window");
			ToolTipMain.SetToolTip(cmdCompDocumentSave, "Click To Save New or EditedDocument");
			ToolTipMain.SetToolTip(cmdCompDocumentNew, "Click To Clear Form And Enter New Document");
			Activated += new System.EventHandler(frm_CompanyDocument_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grd_CompDocument).EndInit();
			frmCompDocument.ResumeLayout(false);
			frmCompDocument.PerformLayout();
			frmCompDocumentControl.ResumeLayout(false);
			frmCompDocumentControl.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			InitializewbCompBrowser1();
			InitializelblSubLabel();
			InitializelblCompLabel();
		}
		void InitializewbCompBrowser1()
		{
			wbCompBrowser1 = new System.Windows.Forms.WebBrowser[1];
			wbCompBrowser1[0] = _wbCompBrowser1_0;
		}
		void InitializelblSubLabel()
		{
			lblSubLabel = new System.Windows.Forms.Label[41];
			lblSubLabel[40] = _lblSubLabel_40;
		}
		void InitializelblCompLabel()
		{
			lblCompLabel = new System.Windows.Forms.Label[40];
			lblCompLabel[38] = _lblCompLabel_38;
			lblCompLabel[39] = _lblCompLabel_39;
		}
		#endregion
	}
}