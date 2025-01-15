
namespace JETNET_Homebase
{
	partial class frm_PopUp
	{

		#region "Upgrade Support "
		private static frm_PopUp m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_PopUp DefInstance
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
		public static frm_PopUp CreateInstance()
		{
			frm_PopUp theInstance = new frm_PopUp();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "txt_id_box", "txt_make", "cmdSelect", "cmdClose", "cmdFind", "txt_RegNo", "txt_SerialNo", "grdSearch", "_Label3_1", "lbl_count", "Label1", "Lbl_notfound", "_Label3_0", "Label2", "pnlAircraftSearch", "cmdCancel", "txtExclusiveCallbackDate", "cmdExclusiveBrokerNo", "cmdExclusiveBrokerYes", "lblExclusiveCallbackDate", "lblExclusiveBroker", "pnlAddExclusiveBroker", "cmdAwaitingDocsSave", "cmdAwaitingDocsCancel", "cboCountry", "cboState", "lblState", "lblCountry", "pnlAwaitingDocs", "Label3", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txt_id_box;
		public System.Windows.Forms.TextBox txt_make;
		public System.Windows.Forms.Button cmdSelect;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Button cmdFind;
		public System.Windows.Forms.TextBox txt_RegNo;
		public System.Windows.Forms.TextBox txt_SerialNo;
		public UpgradeHelpers.DataGridViewFlex grdSearch;
		private System.Windows.Forms.Label _Label3_1;
		public System.Windows.Forms.Label lbl_count;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Lbl_notfound;
		private System.Windows.Forms.Label _Label3_0;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.GroupBox pnlAircraftSearch;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.TextBox txtExclusiveCallbackDate;
		public System.Windows.Forms.Button cmdExclusiveBrokerNo;
		public System.Windows.Forms.Button cmdExclusiveBrokerYes;
		public System.Windows.Forms.Label lblExclusiveCallbackDate;
		public System.Windows.Forms.Label lblExclusiveBroker;
		public System.Windows.Forms.Panel pnlAddExclusiveBroker;
		public System.Windows.Forms.Button cmdAwaitingDocsSave;
		public System.Windows.Forms.Button cmdAwaitingDocsCancel;
		public System.Windows.Forms.ComboBox cboCountry;
		public System.Windows.Forms.ComboBox cboState;
		public System.Windows.Forms.Label lblState;
		public System.Windows.Forms.Label lblCountry;
		public System.Windows.Forms.Panel pnlAwaitingDocs;
		public System.Windows.Forms.Label[] Label3 = new System.Windows.Forms.Label[2];
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PopUp));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			pnlAircraftSearch = new System.Windows.Forms.GroupBox();
			txt_id_box = new System.Windows.Forms.TextBox();
			txt_make = new System.Windows.Forms.TextBox();
			cmdSelect = new System.Windows.Forms.Button();
			cmdClose = new System.Windows.Forms.Button();
			cmdFind = new System.Windows.Forms.Button();
			txt_RegNo = new System.Windows.Forms.TextBox();
			txt_SerialNo = new System.Windows.Forms.TextBox();
			grdSearch = new UpgradeHelpers.DataGridViewFlex(components);
			_Label3_1 = new System.Windows.Forms.Label();
			lbl_count = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			Lbl_notfound = new System.Windows.Forms.Label();
			_Label3_0 = new System.Windows.Forms.Label();
			Label2 = new System.Windows.Forms.Label();
			pnlAddExclusiveBroker = new System.Windows.Forms.Panel();
			cmdCancel = new System.Windows.Forms.Button();
			txtExclusiveCallbackDate = new System.Windows.Forms.TextBox();
			cmdExclusiveBrokerNo = new System.Windows.Forms.Button();
			cmdExclusiveBrokerYes = new System.Windows.Forms.Button();
			lblExclusiveCallbackDate = new System.Windows.Forms.Label();
			lblExclusiveBroker = new System.Windows.Forms.Label();
			pnlAwaitingDocs = new System.Windows.Forms.Panel();
			cmdAwaitingDocsSave = new System.Windows.Forms.Button();
			cmdAwaitingDocsCancel = new System.Windows.Forms.Button();
			cboCountry = new System.Windows.Forms.ComboBox();
			cboState = new System.Windows.Forms.ComboBox();
			lblState = new System.Windows.Forms.Label();
			lblCountry = new System.Windows.Forms.Label();
			pnlAircraftSearch.SuspendLayout();
			pnlAddExclusiveBroker.SuspendLayout();
			pnlAwaitingDocs.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grdSearch).BeginInit();
			// 
			// pnlAircraftSearch
			// 
			pnlAircraftSearch.AllowDrop = true;
			pnlAircraftSearch.BackColor = System.Drawing.SystemColors.Control;
			pnlAircraftSearch.Controls.Add(txt_id_box);
			pnlAircraftSearch.Controls.Add(txt_make);
			pnlAircraftSearch.Controls.Add(cmdSelect);
			pnlAircraftSearch.Controls.Add(cmdClose);
			pnlAircraftSearch.Controls.Add(cmdFind);
			pnlAircraftSearch.Controls.Add(txt_RegNo);
			pnlAircraftSearch.Controls.Add(txt_SerialNo);
			pnlAircraftSearch.Controls.Add(grdSearch);
			pnlAircraftSearch.Controls.Add(_Label3_1);
			pnlAircraftSearch.Controls.Add(lbl_count);
			pnlAircraftSearch.Controls.Add(Label1);
			pnlAircraftSearch.Controls.Add(Lbl_notfound);
			pnlAircraftSearch.Controls.Add(_Label3_0);
			pnlAircraftSearch.Controls.Add(Label2);
			pnlAircraftSearch.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			pnlAircraftSearch.Enabled = true;
			pnlAircraftSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlAircraftSearch.ForeColor = System.Drawing.SystemColors.ControlText;
			pnlAircraftSearch.Location = new System.Drawing.Point(6, 8);
			pnlAircraftSearch.Name = "pnlAircraftSearch";
			pnlAircraftSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			pnlAircraftSearch.Size = new System.Drawing.Size(467, 200);
			pnlAircraftSearch.TabIndex = 14;
			pnlAircraftSearch.Text = "Aircraft Search";
			pnlAircraftSearch.Visible = false;
			// 
			// txt_id_box
			// 
			txt_id_box.AcceptsReturn = true;
			txt_id_box.AllowDrop = true;
			txt_id_box.BackColor = System.Drawing.SystemColors.Window;
			txt_id_box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_id_box.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_id_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_id_box.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_id_box.Location = new System.Drawing.Point(304, 29);
			txt_id_box.MaxLength = 0;
			txt_id_box.Name = "txt_id_box";
			txt_id_box.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_id_box.Size = new System.Drawing.Size(78, 22);
			txt_id_box.TabIndex = 27;
			txt_id_box.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_id_box_KeyDown);
			// 
			// txt_make
			// 
			txt_make.AcceptsReturn = true;
			txt_make.AllowDrop = true;
			txt_make.BackColor = System.Drawing.SystemColors.Window;
			txt_make.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_make.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_make.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_make.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_make.Location = new System.Drawing.Point(17, 29);
			txt_make.MaxLength = 0;
			txt_make.Name = "txt_make";
			txt_make.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_make.Size = new System.Drawing.Size(78, 22);
			txt_make.TabIndex = 17;
			txt_make.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_Make_KeyDown);
			// 
			// cmdSelect
			// 
			cmdSelect.AllowDrop = true;
			cmdSelect.BackColor = System.Drawing.SystemColors.Control;
			cmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSelect.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSelect.Location = new System.Drawing.Point(338, 172);
			cmdSelect.Name = "cmdSelect";
			cmdSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSelect.Size = new System.Drawing.Size(45, 22);
			cmdSelect.TabIndex = 23;
			cmdSelect.Text = "Select";
			cmdSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSelect.UseVisualStyleBackColor = false;
			cmdSelect.Visible = false;
			cmdSelect.Click += new System.EventHandler(CmdSelect_Click);
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(412, 172);
			cmdClose.Name = "cmdClose";
			cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClose.Size = new System.Drawing.Size(45, 22);
			cmdClose.TabIndex = 22;
			cmdClose.Text = "Close";
			cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClose.UseVisualStyleBackColor = false;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			// 
			// cmdFind
			// 
			cmdFind.AllowDrop = true;
			cmdFind.BackColor = System.Drawing.SystemColors.Control;
			cmdFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFind.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFind.Location = new System.Drawing.Point(412, 29);
			cmdFind.Name = "cmdFind";
			cmdFind.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFind.Size = new System.Drawing.Size(45, 22);
			cmdFind.TabIndex = 20;
			cmdFind.Text = "Find";
			cmdFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFind.UseVisualStyleBackColor = false;
			cmdFind.Click += new System.EventHandler(cmdFind_Click);
			// 
			// txt_RegNo
			// 
			txt_RegNo.AcceptsReturn = true;
			txt_RegNo.AllowDrop = true;
			txt_RegNo.BackColor = System.Drawing.SystemColors.Window;
			txt_RegNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_RegNo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_RegNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_RegNo.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_RegNo.Location = new System.Drawing.Point(209, 29);
			txt_RegNo.MaxLength = 0;
			txt_RegNo.Name = "txt_RegNo";
			txt_RegNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_RegNo.Size = new System.Drawing.Size(78, 22);
			txt_RegNo.TabIndex = 19;
			txt_RegNo.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_RegNo_KeyDown);
			// 
			// txt_SerialNo
			// 
			txt_SerialNo.AcceptsReturn = true;
			txt_SerialNo.AllowDrop = true;
			txt_SerialNo.BackColor = System.Drawing.SystemColors.Window;
			txt_SerialNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_SerialNo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_SerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_SerialNo.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_SerialNo.Location = new System.Drawing.Point(113, 29);
			txt_SerialNo.MaxLength = 0;
			txt_SerialNo.Name = "txt_SerialNo";
			txt_SerialNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_SerialNo.Size = new System.Drawing.Size(78, 22);
			txt_SerialNo.TabIndex = 18;
			txt_SerialNo.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_SerialNo_KeyDown);
			// 
			// grdSearch
			// 
			grdSearch.AllowDrop = true;
			grdSearch.AllowUserToAddRows = false;
			grdSearch.AllowUserToDeleteRows = false;
			grdSearch.AllowUserToResizeColumns = false;
			grdSearch.AllowUserToResizeColumns = false;
			grdSearch.AllowUserToResizeRows = false;
			grdSearch.AllowUserToResizeRows = grdSearch.RowHeadersVisible;
			grdSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdSearch.ColumnsCount = 2;
			grdSearch.FixedColumns = 0;
			grdSearch.FixedRows = 1;
			grdSearch.Location = new System.Drawing.Point(14, 60);
			grdSearch.Name = "grdSearch";
			grdSearch.ReadOnly = true;
			grdSearch.RowsCount = 2;
			grdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdSearch.ShowCellToolTips = false;
			grdSearch.Size = new System.Drawing.Size(443, 107);
			grdSearch.StandardTab = true;
			grdSearch.TabIndex = 21;
			grdSearch.Visible = false;
			grdSearch.Click += new System.EventHandler(grdSearch_Click);
			grdSearch.DoubleClick += new System.EventHandler(grdSearch_DoubleClick);
			// 
			// _Label3_1
			// 
			_Label3_1.AllowDrop = true;
			_Label3_1.AutoSize = true;
			_Label3_1.BackColor = System.Drawing.SystemColors.Control;
			_Label3_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label3_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label3_1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			_Label3_1.Location = new System.Drawing.Point(336, 16);
			_Label3_1.MinimumSize = new System.Drawing.Size(9, 14);
			_Label3_1.Name = "_Label3_1";
			_Label3_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label3_1.Size = new System.Drawing.Size(9, 14);
			_Label3_1.TabIndex = 28;
			_Label3_1.Text = "ID";
			// 
			// lbl_count
			// 
			lbl_count.AllowDrop = true;
			lbl_count.BackColor = System.Drawing.SystemColors.Control;
			lbl_count.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_count.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_count.Location = new System.Drawing.Point(27, 174);
			lbl_count.MinimumSize = new System.Drawing.Size(82, 18);
			lbl_count.Name = "lbl_count";
			lbl_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_count.Size = new System.Drawing.Size(82, 18);
			lbl_count.TabIndex = 26;
			lbl_count.Text = "0";
			lbl_count.Visible = false;
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.AutoSize = true;
			Label1.BackColor = System.Drawing.SystemColors.Control;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			Label1.Location = new System.Drawing.Point(44, 15);
			Label1.MinimumSize = new System.Drawing.Size(25, 14);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(25, 14);
			Label1.TabIndex = 25;
			Label1.Text = "Make";
			// 
			// Lbl_notfound
			// 
			Lbl_notfound.AllowDrop = true;
			Lbl_notfound.BackColor = System.Drawing.SystemColors.Control;
			Lbl_notfound.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Lbl_notfound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Lbl_notfound.ForeColor = System.Drawing.Color.Red;
			Lbl_notfound.Location = new System.Drawing.Point(42, 101);
			Lbl_notfound.MinimumSize = new System.Drawing.Size(254, 84);
			Lbl_notfound.Name = "Lbl_notfound";
			Lbl_notfound.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Lbl_notfound.Size = new System.Drawing.Size(254, 84);
			Lbl_notfound.TabIndex = 24;
			Lbl_notfound.Text = "No Matching Aircraft Found";
			Lbl_notfound.Visible = false;
			// 
			// _Label3_0
			// 
			_Label3_0.AllowDrop = true;
			_Label3_0.AutoSize = true;
			_Label3_0.BackColor = System.Drawing.SystemColors.Control;
			_Label3_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label3_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label3_0.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			_Label3_0.Location = new System.Drawing.Point(234, 15);
			_Label3_0.MinimumSize = new System.Drawing.Size(28, 14);
			_Label3_0.Name = "_Label3_0";
			_Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label3_0.Size = new System.Drawing.Size(28, 14);
			_Label3_0.TabIndex = 16;
			_Label3_0.Text = "Reg #";
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.AutoSize = true;
			Label2.BackColor = System.Drawing.SystemColors.Control;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			Label2.Location = new System.Drawing.Point(134, 15);
			Label2.MinimumSize = new System.Drawing.Size(36, 14);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(36, 14);
			Label2.TabIndex = 15;
			Label2.Text = "Serial #";
			// 
			// pnlAddExclusiveBroker
			// 
			pnlAddExclusiveBroker.AllowDrop = true;
			pnlAddExclusiveBroker.BorderStyle = System.Windows.Forms.BorderStyle.None;
			pnlAddExclusiveBroker.Controls.Add(cmdCancel);
			pnlAddExclusiveBroker.Controls.Add(txtExclusiveCallbackDate);
			pnlAddExclusiveBroker.Controls.Add(cmdExclusiveBrokerNo);
			pnlAddExclusiveBroker.Controls.Add(cmdExclusiveBrokerYes);
			pnlAddExclusiveBroker.Controls.Add(lblExclusiveCallbackDate);
			pnlAddExclusiveBroker.Controls.Add(lblExclusiveBroker);
			pnlAddExclusiveBroker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlAddExclusiveBroker.Location = new System.Drawing.Point(6, 8);
			pnlAddExclusiveBroker.Name = "pnlAddExclusiveBroker";
			pnlAddExclusiveBroker.Size = new System.Drawing.Size(364, 200);
			pnlAddExclusiveBroker.TabIndex = 7;
			// 
			// cmdCancel
			// 
			cmdCancel.AllowDrop = true;
			cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancel.Location = new System.Drawing.Point(220, 145);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancel.Size = new System.Drawing.Size(133, 22);
			cmdCancel.TabIndex = 13;
			cmdCancel.Text = "Cancel";
			cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancel.UseVisualStyleBackColor = false;
			cmdCancel.Visible = false;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			// 
			// txtExclusiveCallbackDate
			// 
			txtExclusiveCallbackDate.AcceptsReturn = true;
			txtExclusiveCallbackDate.AllowDrop = true;
			txtExclusiveCallbackDate.BackColor = System.Drawing.SystemColors.Window;
			txtExclusiveCallbackDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtExclusiveCallbackDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtExclusiveCallbackDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtExclusiveCallbackDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtExclusiveCallbackDate.Location = new System.Drawing.Point(133, 171);
			txtExclusiveCallbackDate.MaxLength = 0;
			txtExclusiveCallbackDate.Name = "txtExclusiveCallbackDate";
			txtExclusiveCallbackDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtExclusiveCallbackDate.Size = new System.Drawing.Size(74, 23);
			txtExclusiveCallbackDate.TabIndex = 11;
			// 
			// cmdExclusiveBrokerNo
			// 
			cmdExclusiveBrokerNo.AllowDrop = true;
			cmdExclusiveBrokerNo.BackColor = System.Drawing.SystemColors.Control;
			cmdExclusiveBrokerNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdExclusiveBrokerNo.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdExclusiveBrokerNo.Location = new System.Drawing.Point(294, 171);
			cmdExclusiveBrokerNo.Name = "cmdExclusiveBrokerNo";
			cmdExclusiveBrokerNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdExclusiveBrokerNo.Size = new System.Drawing.Size(59, 22);
			cmdExclusiveBrokerNo.TabIndex = 10;
			cmdExclusiveBrokerNo.Text = "No";
			cmdExclusiveBrokerNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdExclusiveBrokerNo.UseVisualStyleBackColor = false;
			cmdExclusiveBrokerNo.Click += new System.EventHandler(cmdExclusiveBrokerNo_Click);
			// 
			// cmdExclusiveBrokerYes
			// 
			cmdExclusiveBrokerYes.AllowDrop = true;
			cmdExclusiveBrokerYes.BackColor = System.Drawing.SystemColors.Control;
			cmdExclusiveBrokerYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdExclusiveBrokerYes.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdExclusiveBrokerYes.Location = new System.Drawing.Point(220, 171);
			cmdExclusiveBrokerYes.Name = "cmdExclusiveBrokerYes";
			cmdExclusiveBrokerYes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdExclusiveBrokerYes.Size = new System.Drawing.Size(60, 22);
			cmdExclusiveBrokerYes.TabIndex = 9;
			cmdExclusiveBrokerYes.Text = "Yes";
			cmdExclusiveBrokerYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdExclusiveBrokerYes.UseVisualStyleBackColor = false;
			cmdExclusiveBrokerYes.Click += new System.EventHandler(cmdExclusiveBrokerYes_Click);
			// 
			// lblExclusiveCallbackDate
			// 
			lblExclusiveCallbackDate.AllowDrop = true;
			lblExclusiveCallbackDate.AutoSize = true;
			lblExclusiveCallbackDate.BackColor = System.Drawing.SystemColors.Control;
			lblExclusiveCallbackDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblExclusiveCallbackDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblExclusiveCallbackDate.ForeColor = System.Drawing.SystemColors.ControlText;
			lblExclusiveCallbackDate.Location = new System.Drawing.Point(7, 176);
			lblExclusiveCallbackDate.MinimumSize = new System.Drawing.Size(117, 13);
			lblExclusiveCallbackDate.Name = "lblExclusiveCallbackDate";
			lblExclusiveCallbackDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblExclusiveCallbackDate.Size = new System.Drawing.Size(117, 13);
			lblExclusiveCallbackDate.TabIndex = 12;
			lblExclusiveCallbackDate.Text = "Exclusive Callback Date";
			lblExclusiveCallbackDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblExclusiveBroker
			// 
			lblExclusiveBroker.AllowDrop = true;
			lblExclusiveBroker.AutoSize = true;
			lblExclusiveBroker.BackColor = System.Drawing.SystemColors.Control;
			lblExclusiveBroker.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblExclusiveBroker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblExclusiveBroker.ForeColor = System.Drawing.SystemColors.ControlText;
			lblExclusiveBroker.Location = new System.Drawing.Point(8, 13);
			lblExclusiveBroker.MinimumSize = new System.Drawing.Size(21, 13);
			lblExclusiveBroker.Name = "lblExclusiveBroker";
			lblExclusiveBroker.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblExclusiveBroker.Size = new System.Drawing.Size(21, 13);
			lblExclusiveBroker.TabIndex = 8;
			lblExclusiveBroker.Text = "Test";
			// 
			// pnlAwaitingDocs
			// 
			pnlAwaitingDocs.AllowDrop = true;
			pnlAwaitingDocs.BorderStyle = System.Windows.Forms.BorderStyle.None;
			pnlAwaitingDocs.Controls.Add(cmdAwaitingDocsSave);
			pnlAwaitingDocs.Controls.Add(cmdAwaitingDocsCancel);
			pnlAwaitingDocs.Controls.Add(cboCountry);
			pnlAwaitingDocs.Controls.Add(cboState);
			pnlAwaitingDocs.Controls.Add(lblState);
			pnlAwaitingDocs.Controls.Add(lblCountry);
			pnlAwaitingDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlAwaitingDocs.Location = new System.Drawing.Point(6, 8);
			pnlAwaitingDocs.Name = "pnlAwaitingDocs";
			pnlAwaitingDocs.Size = new System.Drawing.Size(364, 77);
			pnlAwaitingDocs.TabIndex = 0;
			pnlAwaitingDocs.Visible = false;
			// 
			// cmdAwaitingDocsSave
			// 
			cmdAwaitingDocsSave.AllowDrop = true;
			cmdAwaitingDocsSave.BackColor = System.Drawing.SystemColors.Control;
			cmdAwaitingDocsSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAwaitingDocsSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAwaitingDocsSave.Location = new System.Drawing.Point(111, 49);
			cmdAwaitingDocsSave.Name = "cmdAwaitingDocsSave";
			cmdAwaitingDocsSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAwaitingDocsSave.Size = new System.Drawing.Size(68, 21);
			cmdAwaitingDocsSave.TabIndex = 6;
			cmdAwaitingDocsSave.Text = "Save";
			cmdAwaitingDocsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAwaitingDocsSave.UseVisualStyleBackColor = false;
			cmdAwaitingDocsSave.Click += new System.EventHandler(cmdAwaitingDocsSave_Click);
			// 
			// cmdAwaitingDocsCancel
			// 
			cmdAwaitingDocsCancel.AllowDrop = true;
			cmdAwaitingDocsCancel.BackColor = System.Drawing.SystemColors.Control;
			cmdAwaitingDocsCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAwaitingDocsCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAwaitingDocsCancel.Location = new System.Drawing.Point(184, 49);
			cmdAwaitingDocsCancel.Name = "cmdAwaitingDocsCancel";
			cmdAwaitingDocsCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAwaitingDocsCancel.Size = new System.Drawing.Size(68, 21);
			cmdAwaitingDocsCancel.TabIndex = 5;
			cmdAwaitingDocsCancel.Text = "Cancel";
			cmdAwaitingDocsCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAwaitingDocsCancel.UseVisualStyleBackColor = false;
			cmdAwaitingDocsCancel.Click += new System.EventHandler(cmdAwaitingDocsCancel_Click);
			// 
			// cboCountry
			// 
			cboCountry.AllowDrop = true;
			cboCountry.BackColor = System.Drawing.SystemColors.Window;
			cboCountry.CausesValidation = true;
			cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboCountry.Enabled = true;
			cboCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboCountry.ForeColor = System.Drawing.SystemColors.WindowText;
			cboCountry.IntegralHeight = true;
			cboCountry.Location = new System.Drawing.Point(6, 20);
			cboCountry.Name = "cboCountry";
			cboCountry.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboCountry.Size = new System.Drawing.Size(183, 21);
			cboCountry.Sorted = false;
			cboCountry.TabIndex = 2;
			cboCountry.TabStop = true;
			cboCountry.Visible = true;
			// 
			// cboState
			// 
			cboState.AllowDrop = true;
			cboState.BackColor = System.Drawing.SystemColors.Window;
			cboState.CausesValidation = true;
			cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboState.Enabled = true;
			cboState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboState.ForeColor = System.Drawing.SystemColors.WindowText;
			cboState.IntegralHeight = true;
			cboState.Location = new System.Drawing.Point(192, 20);
			cboState.Name = "cboState";
			cboState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboState.Size = new System.Drawing.Size(166, 21);
			cboState.Sorted = false;
			cboState.TabIndex = 1;
			cboState.TabStop = true;
			cboState.Visible = true;
			// 
			// lblState
			// 
			lblState.AllowDrop = true;
			lblState.AutoSize = true;
			lblState.BackColor = System.Drawing.SystemColors.Control;
			lblState.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblState.ForeColor = System.Drawing.SystemColors.ControlText;
			lblState.Location = new System.Drawing.Point(192, 5);
			lblState.MinimumSize = new System.Drawing.Size(25, 13);
			lblState.Name = "lblState";
			lblState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblState.Size = new System.Drawing.Size(25, 13);
			lblState.TabIndex = 3;
			lblState.Text = "State";
			// 
			// lblCountry
			// 
			lblCountry.AllowDrop = true;
			lblCountry.AutoSize = true;
			lblCountry.BackColor = System.Drawing.SystemColors.Control;
			lblCountry.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCountry.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCountry.Location = new System.Drawing.Point(6, 5);
			lblCountry.MinimumSize = new System.Drawing.Size(36, 13);
			lblCountry.Name = "lblCountry";
			lblCountry.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCountry.Size = new System.Drawing.Size(36, 13);
			lblCountry.TabIndex = 4;
			lblCountry.Text = "Country";
			// 
			// frm_PopUp
			// 
			AcceptButton = cmdExclusiveBrokerYes;
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			CancelButton = cmdExclusiveBrokerNo;
			ClientSize = new System.Drawing.Size(475, 218);
			ControlBox = false;
			Controls.Add(pnlAircraftSearch);
			Controls.Add(pnlAddExclusiveBroker);
			Controls.Add(pnlAwaitingDocs);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			KeyPreview = true;
			Location = new System.Drawing.Point(579, 226);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_PopUp";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			ShowInTaskbar = false;
			Text = "Awaiting Docs Info";
			commandButtonHelper1.SetStyle(cmdSelect, 0);
			commandButtonHelper1.SetStyle(cmdClose, 0);
			commandButtonHelper1.SetStyle(cmdFind, 0);
			commandButtonHelper1.SetStyle(cmdCancel, 0);
			commandButtonHelper1.SetStyle(cmdExclusiveBrokerNo, 0);
			commandButtonHelper1.SetStyle(cmdExclusiveBrokerYes, 0);
			commandButtonHelper1.SetStyle(cmdAwaitingDocsSave, 0);
			commandButtonHelper1.SetStyle(cmdAwaitingDocsCancel, 0);
			Activated += new System.EventHandler(frm_PopUp_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grdSearch).EndInit();
			pnlAircraftSearch.ResumeLayout(false);
			pnlAircraftSearch.PerformLayout();
			pnlAddExclusiveBroker.ResumeLayout(false);
			pnlAddExclusiveBroker.PerformLayout();
			pnlAwaitingDocs.ResumeLayout(false);
			pnlAwaitingDocs.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => InitializeLabel3();

		void InitializeLabel3()
		{
			Label3 = new System.Windows.Forms.Label[2];
			Label3[1] = _Label3_1;
			Label3[0] = _Label3_0;
		}
		#endregion
	}
}