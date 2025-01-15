
namespace JETNET_Homebase
{
	partial class frm_FAAFlightData
	{

		#region "Upgrade Support "
		private static frm_FAAFlightData m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_FAAFlightData DefInstance
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
		public static frm_FAAFlightData CreateInstance()
		{
			frm_FAAFlightData theInstance = new frm_FAAFlightData();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "rbDestFlights", "rbOriginFlights", "rbAllFlights", "grdFAAFlightDataSummary", "grdFAAFlightData", "lblStopExporting", "lblRecords", "lblStopLoading", "frmFAAFlightDataGrid", "cmdSave", "chkHideFlag", "txtEnteredDate", "txtACId", "txtDistance", "txtFlightTime", "txtDestDate", "txtOriginDate", "txtDestAPortId", "txtDestAPortCode", "txtOriginAPortId", "txtOriginAPortCode", "txtFlightDate", "txtRegNbr", "txtFAAFlightId", "lblEntryDateTime", "lblMakeModelSerNbr", "lblACIdMakeModelSerNbr", "lblDistance", "lblFlightTime", "lblOriginAPortName", "lblDestAPortName", "lblDestDate", "lblOriginDate", "lblDestAPortCode", "lblOriginAPortCode", "lblFlightDate", "lblRegNbr", "lblFAAFlightId", "frmFAAFlightData", "commandButtonHelper1", "optionButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.RadioButton rbDestFlights;
		public System.Windows.Forms.RadioButton rbOriginFlights;
		public System.Windows.Forms.RadioButton rbAllFlights;
		public UpgradeHelpers.DataGridViewFlex grdFAAFlightDataSummary;
		public UpgradeHelpers.DataGridViewFlex grdFAAFlightData;
		public System.Windows.Forms.Label lblStopExporting;
		public System.Windows.Forms.Label lblRecords;
		public System.Windows.Forms.Label lblStopLoading;
		public System.Windows.Forms.GroupBox frmFAAFlightDataGrid;
		public System.Windows.Forms.Button cmdSave;
		public System.Windows.Forms.CheckBox chkHideFlag;
		public System.Windows.Forms.TextBox txtEnteredDate;
		public System.Windows.Forms.TextBox txtACId;
		public System.Windows.Forms.TextBox txtDistance;
		public System.Windows.Forms.TextBox txtFlightTime;
		public System.Windows.Forms.TextBox txtDestDate;
		public System.Windows.Forms.TextBox txtOriginDate;
		public System.Windows.Forms.TextBox txtDestAPortId;
		public System.Windows.Forms.TextBox txtDestAPortCode;
		public System.Windows.Forms.TextBox txtOriginAPortId;
		public System.Windows.Forms.TextBox txtOriginAPortCode;
		public System.Windows.Forms.TextBox txtFlightDate;
		public System.Windows.Forms.TextBox txtRegNbr;
		public System.Windows.Forms.TextBox txtFAAFlightId;
		public System.Windows.Forms.Label lblEntryDateTime;
		public System.Windows.Forms.Label lblMakeModelSerNbr;
		public System.Windows.Forms.Label lblACIdMakeModelSerNbr;
		public System.Windows.Forms.Label lblDistance;
		public System.Windows.Forms.Label lblFlightTime;
		public System.Windows.Forms.Label lblOriginAPortName;
		public System.Windows.Forms.Label lblDestAPortName;
		public System.Windows.Forms.Label lblDestDate;
		public System.Windows.Forms.Label lblOriginDate;
		public System.Windows.Forms.Label lblDestAPortCode;
		public System.Windows.Forms.Label lblOriginAPortCode;
		public System.Windows.Forms.Label lblFlightDate;
		public System.Windows.Forms.Label lblRegNbr;
		public System.Windows.Forms.Label lblFAAFlightId;
		public System.Windows.Forms.GroupBox frmFAAFlightData;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_FAAFlightData));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			frmFAAFlightDataGrid = new System.Windows.Forms.GroupBox();
			rbDestFlights = new System.Windows.Forms.RadioButton();
			rbOriginFlights = new System.Windows.Forms.RadioButton();
			rbAllFlights = new System.Windows.Forms.RadioButton();
			grdFAAFlightDataSummary = new UpgradeHelpers.DataGridViewFlex(components);
			grdFAAFlightData = new UpgradeHelpers.DataGridViewFlex(components);
			lblStopExporting = new System.Windows.Forms.Label();
			lblRecords = new System.Windows.Forms.Label();
			lblStopLoading = new System.Windows.Forms.Label();
			frmFAAFlightData = new System.Windows.Forms.GroupBox();
			cmdSave = new System.Windows.Forms.Button();
			chkHideFlag = new System.Windows.Forms.CheckBox();
			txtEnteredDate = new System.Windows.Forms.TextBox();
			txtACId = new System.Windows.Forms.TextBox();
			txtDistance = new System.Windows.Forms.TextBox();
			txtFlightTime = new System.Windows.Forms.TextBox();
			txtDestDate = new System.Windows.Forms.TextBox();
			txtOriginDate = new System.Windows.Forms.TextBox();
			txtDestAPortId = new System.Windows.Forms.TextBox();
			txtDestAPortCode = new System.Windows.Forms.TextBox();
			txtOriginAPortId = new System.Windows.Forms.TextBox();
			txtOriginAPortCode = new System.Windows.Forms.TextBox();
			txtFlightDate = new System.Windows.Forms.TextBox();
			txtRegNbr = new System.Windows.Forms.TextBox();
			txtFAAFlightId = new System.Windows.Forms.TextBox();
			lblEntryDateTime = new System.Windows.Forms.Label();
			lblMakeModelSerNbr = new System.Windows.Forms.Label();
			lblACIdMakeModelSerNbr = new System.Windows.Forms.Label();
			lblDistance = new System.Windows.Forms.Label();
			lblFlightTime = new System.Windows.Forms.Label();
			lblOriginAPortName = new System.Windows.Forms.Label();
			lblDestAPortName = new System.Windows.Forms.Label();
			lblDestDate = new System.Windows.Forms.Label();
			lblOriginDate = new System.Windows.Forms.Label();
			lblDestAPortCode = new System.Windows.Forms.Label();
			lblOriginAPortCode = new System.Windows.Forms.Label();
			lblFlightDate = new System.Windows.Forms.Label();
			lblRegNbr = new System.Windows.Forms.Label();
			lblFAAFlightId = new System.Windows.Forms.Label();
			frmFAAFlightDataGrid.SuspendLayout();
			frmFAAFlightData.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grdFAAFlightDataSummary).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdFAAFlightData).BeginInit();
			// 
			// frmFAAFlightDataGrid
			// 
			frmFAAFlightDataGrid.AllowDrop = true;
			frmFAAFlightDataGrid.BackColor = System.Drawing.SystemColors.Control;
			frmFAAFlightDataGrid.Controls.Add(rbDestFlights);
			frmFAAFlightDataGrid.Controls.Add(rbOriginFlights);
			frmFAAFlightDataGrid.Controls.Add(rbAllFlights);
			frmFAAFlightDataGrid.Controls.Add(grdFAAFlightDataSummary);
			frmFAAFlightDataGrid.Controls.Add(grdFAAFlightData);
			frmFAAFlightDataGrid.Controls.Add(lblStopExporting);
			frmFAAFlightDataGrid.Controls.Add(lblRecords);
			frmFAAFlightDataGrid.Controls.Add(lblStopLoading);
			frmFAAFlightDataGrid.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmFAAFlightDataGrid.Enabled = true;
			frmFAAFlightDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmFAAFlightDataGrid.ForeColor = System.Drawing.Color.Blue;
			frmFAAFlightDataGrid.Location = new System.Drawing.Point(2, 120);
			frmFAAFlightDataGrid.Name = "frmFAAFlightDataGrid";
			frmFAAFlightDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmFAAFlightDataGrid.Size = new System.Drawing.Size(1069, 485);
			frmFAAFlightDataGrid.TabIndex = 16;
			frmFAAFlightDataGrid.Text = "FAA Flight Data";
			frmFAAFlightDataGrid.Visible = true;
			frmFAAFlightDataGrid.Click += new System.EventHandler(frmFAAFlightDataGrid_Click);
			// 
			// rbDestFlights
			// 
			rbDestFlights.AllowDrop = true;
			rbDestFlights.BackColor = System.Drawing.SystemColors.Control;
			rbDestFlights.CausesValidation = true;
			rbDestFlights.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbDestFlights.Checked = false;
			rbDestFlights.Enabled = true;
			rbDestFlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbDestFlights.ForeColor = System.Drawing.SystemColors.ControlText;
			rbDestFlights.Location = new System.Drawing.Point(646, 462);
			rbDestFlights.Name = "rbDestFlights";
			rbDestFlights.RightToLeft = System.Windows.Forms.RightToLeft.No;
			rbDestFlights.Size = new System.Drawing.Size(95, 13);
			rbDestFlights.TabIndex = 37;
			rbDestFlights.TabStop = true;
			rbDestFlights.Text = "Dest Flights";
			rbDestFlights.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbDestFlights.Visible = true;
			rbDestFlights.CheckedChanged += new System.EventHandler(rbDestFlights_CheckedChanged);
			// 
			// rbOriginFlights
			// 
			rbOriginFlights.AllowDrop = true;
			rbOriginFlights.BackColor = System.Drawing.SystemColors.Control;
			rbOriginFlights.CausesValidation = true;
			rbOriginFlights.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbOriginFlights.Checked = false;
			rbOriginFlights.Enabled = true;
			rbOriginFlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbOriginFlights.ForeColor = System.Drawing.SystemColors.ControlText;
			rbOriginFlights.Location = new System.Drawing.Point(520, 462);
			rbOriginFlights.Name = "rbOriginFlights";
			rbOriginFlights.RightToLeft = System.Windows.Forms.RightToLeft.No;
			rbOriginFlights.Size = new System.Drawing.Size(95, 13);
			rbOriginFlights.TabIndex = 36;
			rbOriginFlights.TabStop = true;
			rbOriginFlights.Text = "Origin Flights";
			rbOriginFlights.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbOriginFlights.Visible = true;
			rbOriginFlights.CheckedChanged += new System.EventHandler(rbOriginFlights_CheckedChanged);
			// 
			// rbAllFlights
			// 
			rbAllFlights.AllowDrop = true;
			rbAllFlights.BackColor = System.Drawing.SystemColors.Control;
			rbAllFlights.CausesValidation = true;
			rbAllFlights.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbAllFlights.Checked = true;
			rbAllFlights.Enabled = true;
			rbAllFlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbAllFlights.ForeColor = System.Drawing.SystemColors.ControlText;
			rbAllFlights.Location = new System.Drawing.Point(416, 462);
			rbAllFlights.Name = "rbAllFlights";
			rbAllFlights.RightToLeft = System.Windows.Forms.RightToLeft.No;
			rbAllFlights.Size = new System.Drawing.Size(79, 13);
			rbAllFlights.TabIndex = 35;
			rbAllFlights.TabStop = true;
			rbAllFlights.Text = "All Flights";
			rbAllFlights.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbAllFlights.Visible = true;
			rbAllFlights.CheckedChanged += new System.EventHandler(rbAllFlights_CheckedChanged);
			// 
			// grdFAAFlightDataSummary
			// 
			grdFAAFlightDataSummary.AllowBigSelection = false;
			grdFAAFlightDataSummary.AllowDrop = true;
			grdFAAFlightDataSummary.AllowUserToAddRows = false;
			grdFAAFlightDataSummary.AllowUserToDeleteRows = false;
			grdFAAFlightDataSummary.AllowUserToResizeColumns = false;
			grdFAAFlightDataSummary.AllowUserToResizeColumns = grdFAAFlightDataSummary.ColumnHeadersVisible;
			grdFAAFlightDataSummary.AllowUserToResizeRows = false;
			grdFAAFlightDataSummary.AllowUserToResizeRows = false;
			grdFAAFlightDataSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdFAAFlightDataSummary.ColumnsCount = 2;
			grdFAAFlightDataSummary.FixedColumns = 1;
			grdFAAFlightDataSummary.FixedRows = 1;
			grdFAAFlightDataSummary.Location = new System.Drawing.Point(112, 26);
			grdFAAFlightDataSummary.Name = "grdFAAFlightDataSummary";
			grdFAAFlightDataSummary.ReadOnly = true;
			grdFAAFlightDataSummary.RowsCount = 2;
			grdFAAFlightDataSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdFAAFlightDataSummary.ShowCellToolTips = false;
			grdFAAFlightDataSummary.Size = new System.Drawing.Size(833, 433);
			grdFAAFlightDataSummary.StandardTab = true;
			grdFAAFlightDataSummary.TabIndex = 38;
			grdFAAFlightDataSummary.DoubleClick += new System.EventHandler(grdFAAFlightDataSummary_DoubleClick);
			// 
			// grdFAAFlightData
			// 
			grdFAAFlightData.AllowBigSelection = false;
			grdFAAFlightData.AllowDrop = true;
			grdFAAFlightData.AllowUserToAddRows = false;
			grdFAAFlightData.AllowUserToDeleteRows = false;
			grdFAAFlightData.AllowUserToResizeColumns = false;
			grdFAAFlightData.AllowUserToResizeColumns = grdFAAFlightData.ColumnHeadersVisible;
			grdFAAFlightData.AllowUserToResizeRows = false;
			grdFAAFlightData.AllowUserToResizeRows = false;
			grdFAAFlightData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdFAAFlightData.ColumnsCount = 2;
			grdFAAFlightData.FixedColumns = 1;
			grdFAAFlightData.FixedRows = 1;
			grdFAAFlightData.Location = new System.Drawing.Point(8, 26);
			grdFAAFlightData.Name = "grdFAAFlightData";
			grdFAAFlightData.ReadOnly = true;
			grdFAAFlightData.RowsCount = 2;
			grdFAAFlightData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdFAAFlightData.ShowCellToolTips = false;
			grdFAAFlightData.Size = new System.Drawing.Size(1041, 433);
			grdFAAFlightData.StandardTab = true;
			grdFAAFlightData.TabIndex = 17;
			grdFAAFlightData.DoubleClick += new System.EventHandler(grdFAAFlightData_DoubleClick);
			// 
			// lblStopExporting
			// 
			lblStopExporting.AllowDrop = true;
			lblStopExporting.BackColor = System.Drawing.SystemColors.Control;
			lblStopExporting.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblStopExporting.Enabled = false;
			lblStopExporting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStopExporting.ForeColor = System.Drawing.Color.Blue;
			lblStopExporting.Location = new System.Drawing.Point(954, 10);
			lblStopExporting.MinimumSize = new System.Drawing.Size(101, 13);
			lblStopExporting.Name = "lblStopExporting";
			lblStopExporting.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblStopExporting.Size = new System.Drawing.Size(101, 13);
			lblStopExporting.TabIndex = 34;
			lblStopExporting.Text = "Stop Exporting";
			lblStopExporting.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblStopExporting.Visible = false;
			lblStopExporting.Click += new System.EventHandler(lblStopExporting_Click);
			// 
			// lblRecords
			// 
			lblRecords.AllowDrop = true;
			lblRecords.BackColor = System.Drawing.SystemColors.Control;
			lblRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblRecords.ForeColor = System.Drawing.SystemColors.ControlText;
			lblRecords.Location = new System.Drawing.Point(16, 464);
			lblRecords.MinimumSize = new System.Drawing.Size(225, 15);
			lblRecords.Name = "lblRecords";
			lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblRecords.Size = new System.Drawing.Size(225, 15);
			lblRecords.TabIndex = 19;
			lblRecords.Text = "Records Found: 0";
			// 
			// lblStopLoading
			// 
			lblStopLoading.AllowDrop = true;
			lblStopLoading.BackColor = System.Drawing.SystemColors.Control;
			lblStopLoading.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblStopLoading.Enabled = false;
			lblStopLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStopLoading.ForeColor = System.Drawing.Color.Blue;
			lblStopLoading.Location = new System.Drawing.Point(974, 466);
			lblStopLoading.MinimumSize = new System.Drawing.Size(81, 13);
			lblStopLoading.Name = "lblStopLoading";
			lblStopLoading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblStopLoading.Size = new System.Drawing.Size(81, 13);
			lblStopLoading.TabIndex = 18;
			lblStopLoading.Text = "Stop Loading";
			lblStopLoading.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblStopLoading.Visible = false;
			lblStopLoading.Click += new System.EventHandler(lblStopLoading_Click);
			// 
			// frmFAAFlightData
			// 
			frmFAAFlightData.AllowDrop = true;
			frmFAAFlightData.BackColor = System.Drawing.SystemColors.Control;
			frmFAAFlightData.Controls.Add(cmdSave);
			frmFAAFlightData.Controls.Add(chkHideFlag);
			frmFAAFlightData.Controls.Add(txtEnteredDate);
			frmFAAFlightData.Controls.Add(txtACId);
			frmFAAFlightData.Controls.Add(txtDistance);
			frmFAAFlightData.Controls.Add(txtFlightTime);
			frmFAAFlightData.Controls.Add(txtDestDate);
			frmFAAFlightData.Controls.Add(txtOriginDate);
			frmFAAFlightData.Controls.Add(txtDestAPortId);
			frmFAAFlightData.Controls.Add(txtDestAPortCode);
			frmFAAFlightData.Controls.Add(txtOriginAPortId);
			frmFAAFlightData.Controls.Add(txtOriginAPortCode);
			frmFAAFlightData.Controls.Add(txtFlightDate);
			frmFAAFlightData.Controls.Add(txtRegNbr);
			frmFAAFlightData.Controls.Add(txtFAAFlightId);
			frmFAAFlightData.Controls.Add(lblEntryDateTime);
			frmFAAFlightData.Controls.Add(lblMakeModelSerNbr);
			frmFAAFlightData.Controls.Add(lblACIdMakeModelSerNbr);
			frmFAAFlightData.Controls.Add(lblDistance);
			frmFAAFlightData.Controls.Add(lblFlightTime);
			frmFAAFlightData.Controls.Add(lblOriginAPortName);
			frmFAAFlightData.Controls.Add(lblDestAPortName);
			frmFAAFlightData.Controls.Add(lblDestDate);
			frmFAAFlightData.Controls.Add(lblOriginDate);
			frmFAAFlightData.Controls.Add(lblDestAPortCode);
			frmFAAFlightData.Controls.Add(lblOriginAPortCode);
			frmFAAFlightData.Controls.Add(lblFlightDate);
			frmFAAFlightData.Controls.Add(lblRegNbr);
			frmFAAFlightData.Controls.Add(lblFAAFlightId);
			frmFAAFlightData.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmFAAFlightData.Enabled = true;
			frmFAAFlightData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmFAAFlightData.ForeColor = System.Drawing.SystemColors.ControlText;
			frmFAAFlightData.Location = new System.Drawing.Point(2, 8);
			frmFAAFlightData.Name = "frmFAAFlightData";
			frmFAAFlightData.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmFAAFlightData.Size = new System.Drawing.Size(1067, 107);
			frmFAAFlightData.TabIndex = 0;
			frmFAAFlightData.Text = "FAA Flight Data";
			frmFAAFlightData.Visible = true;
			// 
			// cmdSave
			// 
			cmdSave.AllowDrop = true;
			cmdSave.BackColor = System.Drawing.SystemColors.Control;
			cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSave.Location = new System.Drawing.Point(998, 82);
			cmdSave.Name = "cmdSave";
			cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSave.Size = new System.Drawing.Size(59, 19);
			cmdSave.TabIndex = 15;
			cmdSave.Text = "&Save";
			cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSave.UseVisualStyleBackColor = false;
			cmdSave.Click += new System.EventHandler(cmdSave_Click);
			// 
			// chkHideFlag
			// 
			chkHideFlag.AllowDrop = true;
			chkHideFlag.Appearance = System.Windows.Forms.Appearance.Normal;
			chkHideFlag.BackColor = System.Drawing.SystemColors.Control;
			chkHideFlag.CausesValidation = true;
			chkHideFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chkHideFlag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkHideFlag.Enabled = true;
			chkHideFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkHideFlag.ForeColor = System.Drawing.SystemColors.ControlText;
			chkHideFlag.Location = new System.Drawing.Point(838, 84);
			chkHideFlag.Name = "chkHideFlag";
			chkHideFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkHideFlag.Size = new System.Drawing.Size(85, 15);
			chkHideFlag.TabIndex = 14;
			chkHideFlag.TabStop = true;
			chkHideFlag.Text = "Hide Flag";
			chkHideFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkHideFlag.Visible = true;
			// 
			// txtEnteredDate
			// 
			txtEnteredDate.AcceptsReturn = true;
			txtEnteredDate.AllowDrop = true;
			txtEnteredDate.BackColor = System.Drawing.SystemColors.Window;
			txtEnteredDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtEnteredDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEnteredDate.Enabled = false;
			txtEnteredDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEnteredDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtEnteredDate.Location = new System.Drawing.Point(910, 62);
			txtEnteredDate.MaxLength = 25;
			txtEnteredDate.Name = "txtEnteredDate";
			txtEnteredDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtEnteredDate.Size = new System.Drawing.Size(147, 19);
			txtEnteredDate.TabIndex = 12;
			// 
			// txtACId
			// 
			txtACId.AcceptsReturn = true;
			txtACId.AllowDrop = true;
			txtACId.BackColor = System.Drawing.SystemColors.Window;
			txtACId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtACId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtACId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtACId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtACId.Location = new System.Drawing.Point(366, 62);
			txtACId.MaxLength = 6;
			txtACId.Name = "txtACId";
			txtACId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtACId.Size = new System.Drawing.Size(55, 19);
			txtACId.TabIndex = 11;
			txtACId.Leave += new System.EventHandler(txtACID_Leave);
			// 
			// txtDistance
			// 
			txtDistance.AcceptsReturn = true;
			txtDistance.AllowDrop = true;
			txtDistance.BackColor = System.Drawing.SystemColors.Window;
			txtDistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtDistance.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtDistance.ForeColor = System.Drawing.SystemColors.WindowText;
			txtDistance.Location = new System.Drawing.Point(366, 82);
			txtDistance.MaxLength = 5;
			txtDistance.Name = "txtDistance";
			txtDistance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtDistance.Size = new System.Drawing.Size(53, 19);
			txtDistance.TabIndex = 13;
			// 
			// txtFlightTime
			// 
			txtFlightTime.AcceptsReturn = true;
			txtFlightTime.AllowDrop = true;
			txtFlightTime.BackColor = System.Drawing.SystemColors.Window;
			txtFlightTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtFlightTime.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtFlightTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtFlightTime.ForeColor = System.Drawing.SystemColors.WindowText;
			txtFlightTime.Location = new System.Drawing.Point(88, 82);
			txtFlightTime.MaxLength = 5;
			txtFlightTime.Name = "txtFlightTime";
			txtFlightTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtFlightTime.Size = new System.Drawing.Size(53, 19);
			txtFlightTime.TabIndex = 4;
			// 
			// txtDestDate
			// 
			txtDestDate.AcceptsReturn = true;
			txtDestDate.AllowDrop = true;
			txtDestDate.BackColor = System.Drawing.SystemColors.Window;
			txtDestDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtDestDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtDestDate.Enabled = false;
			txtDestDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtDestDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtDestDate.Location = new System.Drawing.Point(910, 42);
			txtDestDate.MaxLength = 25;
			txtDestDate.Name = "txtDestDate";
			txtDestDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtDestDate.Size = new System.Drawing.Size(147, 19);
			txtDestDate.TabIndex = 10;
			// 
			// txtOriginDate
			// 
			txtOriginDate.AcceptsReturn = true;
			txtOriginDate.AllowDrop = true;
			txtOriginDate.BackColor = System.Drawing.SystemColors.Window;
			txtOriginDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtOriginDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtOriginDate.Enabled = false;
			txtOriginDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtOriginDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtOriginDate.Location = new System.Drawing.Point(910, 22);
			txtOriginDate.MaxLength = 25;
			txtOriginDate.Name = "txtOriginDate";
			txtOriginDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtOriginDate.Size = new System.Drawing.Size(147, 19);
			txtOriginDate.TabIndex = 7;
			// 
			// txtDestAPortId
			// 
			txtDestAPortId.AcceptsReturn = true;
			txtDestAPortId.AllowDrop = true;
			txtDestAPortId.BackColor = System.Drawing.SystemColors.Window;
			txtDestAPortId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtDestAPortId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtDestAPortId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtDestAPortId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtDestAPortId.Location = new System.Drawing.Point(366, 42);
			txtDestAPortId.MaxLength = 6;
			txtDestAPortId.Name = "txtDestAPortId";
			txtDestAPortId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtDestAPortId.Size = new System.Drawing.Size(55, 19);
			txtDestAPortId.TabIndex = 8;
			txtDestAPortId.Leave += new System.EventHandler(txtDestAPortId_Leave);
			// 
			// txtDestAPortCode
			// 
			txtDestAPortCode.AcceptsReturn = true;
			txtDestAPortCode.AllowDrop = true;
			txtDestAPortCode.BackColor = System.Drawing.SystemColors.Window;
			txtDestAPortCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtDestAPortCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtDestAPortCode.Enabled = false;
			txtDestAPortCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtDestAPortCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtDestAPortCode.Location = new System.Drawing.Point(426, 42);
			txtDestAPortCode.MaxLength = 4;
			txtDestAPortCode.Name = "txtDestAPortCode";
			txtDestAPortCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtDestAPortCode.Size = new System.Drawing.Size(49, 19);
			txtDestAPortCode.TabIndex = 9;
			// 
			// txtOriginAPortId
			// 
			txtOriginAPortId.AcceptsReturn = true;
			txtOriginAPortId.AllowDrop = true;
			txtOriginAPortId.BackColor = System.Drawing.SystemColors.Window;
			txtOriginAPortId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtOriginAPortId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtOriginAPortId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtOriginAPortId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtOriginAPortId.Location = new System.Drawing.Point(366, 22);
			txtOriginAPortId.MaxLength = 6;
			txtOriginAPortId.Name = "txtOriginAPortId";
			txtOriginAPortId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtOriginAPortId.Size = new System.Drawing.Size(55, 19);
			txtOriginAPortId.TabIndex = 5;
			txtOriginAPortId.Leave += new System.EventHandler(txtOriginAPortId_Leave);
			// 
			// txtOriginAPortCode
			// 
			txtOriginAPortCode.AcceptsReturn = true;
			txtOriginAPortCode.AllowDrop = true;
			txtOriginAPortCode.BackColor = System.Drawing.SystemColors.Window;
			txtOriginAPortCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtOriginAPortCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtOriginAPortCode.Enabled = false;
			txtOriginAPortCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtOriginAPortCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtOriginAPortCode.Location = new System.Drawing.Point(426, 22);
			txtOriginAPortCode.MaxLength = 4;
			txtOriginAPortCode.Name = "txtOriginAPortCode";
			txtOriginAPortCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtOriginAPortCode.Size = new System.Drawing.Size(49, 19);
			txtOriginAPortCode.TabIndex = 6;
			// 
			// txtFlightDate
			// 
			txtFlightDate.AcceptsReturn = true;
			txtFlightDate.AllowDrop = true;
			txtFlightDate.BackColor = System.Drawing.SystemColors.Window;
			txtFlightDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtFlightDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtFlightDate.Enabled = false;
			txtFlightDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtFlightDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtFlightDate.Location = new System.Drawing.Point(88, 62);
			txtFlightDate.MaxLength = 10;
			txtFlightDate.Name = "txtFlightDate";
			txtFlightDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtFlightDate.Size = new System.Drawing.Size(83, 19);
			txtFlightDate.TabIndex = 3;
			// 
			// txtRegNbr
			// 
			txtRegNbr.AcceptsReturn = true;
			txtRegNbr.AllowDrop = true;
			txtRegNbr.BackColor = System.Drawing.SystemColors.Window;
			txtRegNbr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtRegNbr.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtRegNbr.Enabled = false;
			txtRegNbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtRegNbr.ForeColor = System.Drawing.SystemColors.WindowText;
			txtRegNbr.Location = new System.Drawing.Point(88, 42);
			txtRegNbr.MaxLength = 12;
			txtRegNbr.Name = "txtRegNbr";
			txtRegNbr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtRegNbr.Size = new System.Drawing.Size(83, 19);
			txtRegNbr.TabIndex = 2;
			// 
			// txtFAAFlightId
			// 
			txtFAAFlightId.AcceptsReturn = true;
			txtFAAFlightId.AllowDrop = true;
			txtFAAFlightId.BackColor = System.Drawing.SystemColors.Window;
			txtFAAFlightId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtFAAFlightId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtFAAFlightId.Enabled = false;
			txtFAAFlightId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtFAAFlightId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtFAAFlightId.Location = new System.Drawing.Point(88, 22);
			txtFAAFlightId.MaxLength = 20;
			txtFAAFlightId.Name = "txtFAAFlightId";
			txtFAAFlightId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtFAAFlightId.Size = new System.Drawing.Size(115, 19);
			txtFAAFlightId.TabIndex = 1;
			// 
			// lblEntryDateTime
			// 
			lblEntryDateTime.AllowDrop = true;
			lblEntryDateTime.BackColor = System.Drawing.SystemColors.Control;
			lblEntryDateTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblEntryDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblEntryDateTime.ForeColor = System.Drawing.SystemColors.ControlText;
			lblEntryDateTime.Location = new System.Drawing.Point(840, 64);
			lblEntryDateTime.MinimumSize = new System.Drawing.Size(63, 13);
			lblEntryDateTime.Name = "lblEntryDateTime";
			lblEntryDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblEntryDateTime.Size = new System.Drawing.Size(63, 13);
			lblEntryDateTime.TabIndex = 33;
			lblEntryDateTime.Text = "Entered Date";
			// 
			// lblMakeModelSerNbr
			// 
			lblMakeModelSerNbr.AllowDrop = true;
			lblMakeModelSerNbr.BackColor = System.Drawing.SystemColors.Control;
			lblMakeModelSerNbr.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblMakeModelSerNbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblMakeModelSerNbr.ForeColor = System.Drawing.Color.Blue;
			lblMakeModelSerNbr.Location = new System.Drawing.Point(430, 64);
			lblMakeModelSerNbr.MinimumSize = new System.Drawing.Size(409, 13);
			lblMakeModelSerNbr.Name = "lblMakeModelSerNbr";
			lblMakeModelSerNbr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblMakeModelSerNbr.Size = new System.Drawing.Size(409, 13);
			lblMakeModelSerNbr.TabIndex = 32;
			lblMakeModelSerNbr.Text = "Make, Model, SerNbr";
			// 
			// lblACIdMakeModelSerNbr
			// 
			lblACIdMakeModelSerNbr.AllowDrop = true;
			lblACIdMakeModelSerNbr.BackColor = System.Drawing.SystemColors.Control;
			lblACIdMakeModelSerNbr.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblACIdMakeModelSerNbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblACIdMakeModelSerNbr.ForeColor = System.Drawing.SystemColors.ControlText;
			lblACIdMakeModelSerNbr.Location = new System.Drawing.Point(214, 64);
			lblACIdMakeModelSerNbr.MinimumSize = new System.Drawing.Size(143, 13);
			lblACIdMakeModelSerNbr.Name = "lblACIdMakeModelSerNbr";
			lblACIdMakeModelSerNbr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblACIdMakeModelSerNbr.Size = new System.Drawing.Size(143, 13);
			lblACIdMakeModelSerNbr.TabIndex = 31;
			lblACIdMakeModelSerNbr.Text = "ACId Make Model SerNbr";
			// 
			// lblDistance
			// 
			lblDistance.AllowDrop = true;
			lblDistance.BackColor = System.Drawing.SystemColors.Control;
			lblDistance.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDistance.ForeColor = System.Drawing.SystemColors.ControlText;
			lblDistance.Location = new System.Drawing.Point(214, 84);
			lblDistance.MinimumSize = new System.Drawing.Size(93, 13);
			lblDistance.Name = "lblDistance";
			lblDistance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDistance.Size = new System.Drawing.Size(93, 13);
			lblDistance.TabIndex = 30;
			lblDistance.Text = "Flight Distance";
			// 
			// lblFlightTime
			// 
			lblFlightTime.AllowDrop = true;
			lblFlightTime.BackColor = System.Drawing.SystemColors.Control;
			lblFlightTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFlightTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFlightTime.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFlightTime.Location = new System.Drawing.Point(12, 84);
			lblFlightTime.MinimumSize = new System.Drawing.Size(69, 13);
			lblFlightTime.Name = "lblFlightTime";
			lblFlightTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFlightTime.Size = new System.Drawing.Size(69, 13);
			lblFlightTime.TabIndex = 29;
			lblFlightTime.Text = "Flight Time";
			// 
			// lblOriginAPortName
			// 
			lblOriginAPortName.AllowDrop = true;
			lblOriginAPortName.BackColor = System.Drawing.SystemColors.Control;
			lblOriginAPortName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblOriginAPortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblOriginAPortName.ForeColor = System.Drawing.Color.Blue;
			lblOriginAPortName.Location = new System.Drawing.Point(490, 24);
			lblOriginAPortName.MinimumSize = new System.Drawing.Size(349, 13);
			lblOriginAPortName.Name = "lblOriginAPortName";
			lblOriginAPortName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblOriginAPortName.Size = new System.Drawing.Size(349, 13);
			lblOriginAPortName.TabIndex = 28;
			lblOriginAPortName.Text = "Origin APort Name, City, State, Country";
			// 
			// lblDestAPortName
			// 
			lblDestAPortName.AllowDrop = true;
			lblDestAPortName.BackColor = System.Drawing.SystemColors.Control;
			lblDestAPortName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDestAPortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDestAPortName.ForeColor = System.Drawing.Color.Blue;
			lblDestAPortName.Location = new System.Drawing.Point(490, 44);
			lblDestAPortName.MinimumSize = new System.Drawing.Size(349, 13);
			lblDestAPortName.Name = "lblDestAPortName";
			lblDestAPortName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDestAPortName.Size = new System.Drawing.Size(349, 13);
			lblDestAPortName.TabIndex = 27;
			lblDestAPortName.Text = "Destination APort Name, City, State, Country";
			// 
			// lblDestDate
			// 
			lblDestDate.AllowDrop = true;
			lblDestDate.BackColor = System.Drawing.SystemColors.Control;
			lblDestDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDestDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDestDate.ForeColor = System.Drawing.SystemColors.ControlText;
			lblDestDate.Location = new System.Drawing.Point(840, 44);
			lblDestDate.MinimumSize = new System.Drawing.Size(55, 13);
			lblDestDate.Name = "lblDestDate";
			lblDestDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDestDate.Size = new System.Drawing.Size(55, 13);
			lblDestDate.TabIndex = 26;
			lblDestDate.Text = "Date/Time";
			// 
			// lblOriginDate
			// 
			lblOriginDate.AllowDrop = true;
			lblOriginDate.BackColor = System.Drawing.SystemColors.Control;
			lblOriginDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblOriginDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblOriginDate.ForeColor = System.Drawing.SystemColors.ControlText;
			lblOriginDate.Location = new System.Drawing.Point(840, 24);
			lblOriginDate.MinimumSize = new System.Drawing.Size(55, 13);
			lblOriginDate.Name = "lblOriginDate";
			lblOriginDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblOriginDate.Size = new System.Drawing.Size(55, 13);
			lblOriginDate.TabIndex = 25;
			lblOriginDate.Text = "Date/Time";
			// 
			// lblDestAPortCode
			// 
			lblDestAPortCode.AllowDrop = true;
			lblDestAPortCode.BackColor = System.Drawing.SystemColors.Control;
			lblDestAPortCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDestAPortCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDestAPortCode.ForeColor = System.Drawing.SystemColors.ControlText;
			lblDestAPortCode.Location = new System.Drawing.Point(214, 44);
			lblDestAPortCode.MinimumSize = new System.Drawing.Size(143, 13);
			lblDestAPortCode.Name = "lblDestAPortCode";
			lblDestAPortCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDestAPortCode.Size = new System.Drawing.Size(143, 13);
			lblDestAPortCode.TabIndex = 24;
			lblDestAPortCode.Text = "Dest APort Id / Code / Name";
			// 
			// lblOriginAPortCode
			// 
			lblOriginAPortCode.AllowDrop = true;
			lblOriginAPortCode.BackColor = System.Drawing.SystemColors.Control;
			lblOriginAPortCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblOriginAPortCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblOriginAPortCode.ForeColor = System.Drawing.SystemColors.ControlText;
			lblOriginAPortCode.Location = new System.Drawing.Point(214, 24);
			lblOriginAPortCode.MinimumSize = new System.Drawing.Size(143, 13);
			lblOriginAPortCode.Name = "lblOriginAPortCode";
			lblOriginAPortCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblOriginAPortCode.Size = new System.Drawing.Size(143, 13);
			lblOriginAPortCode.TabIndex = 23;
			lblOriginAPortCode.Text = "Origin APort Id / Code / Name";
			// 
			// lblFlightDate
			// 
			lblFlightDate.AllowDrop = true;
			lblFlightDate.BackColor = System.Drawing.SystemColors.Control;
			lblFlightDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFlightDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFlightDate.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFlightDate.Location = new System.Drawing.Point(12, 64);
			lblFlightDate.MinimumSize = new System.Drawing.Size(69, 13);
			lblFlightDate.Name = "lblFlightDate";
			lblFlightDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFlightDate.Size = new System.Drawing.Size(69, 13);
			lblFlightDate.TabIndex = 22;
			lblFlightDate.Text = "Flight Date";
			// 
			// lblRegNbr
			// 
			lblRegNbr.AllowDrop = true;
			lblRegNbr.BackColor = System.Drawing.SystemColors.Control;
			lblRegNbr.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblRegNbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblRegNbr.ForeColor = System.Drawing.SystemColors.ControlText;
			lblRegNbr.Location = new System.Drawing.Point(12, 44);
			lblRegNbr.MinimumSize = new System.Drawing.Size(69, 13);
			lblRegNbr.Name = "lblRegNbr";
			lblRegNbr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblRegNbr.Size = new System.Drawing.Size(69, 13);
			lblRegNbr.TabIndex = 21;
			lblRegNbr.Text = "RegNbr";
			// 
			// lblFAAFlightId
			// 
			lblFAAFlightId.AllowDrop = true;
			lblFAAFlightId.BackColor = System.Drawing.SystemColors.Control;
			lblFAAFlightId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFAAFlightId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFAAFlightId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFAAFlightId.Location = new System.Drawing.Point(12, 24);
			lblFAAFlightId.MinimumSize = new System.Drawing.Size(69, 13);
			lblFAAFlightId.Name = "lblFAAFlightId";
			lblFAAFlightId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFAAFlightId.Size = new System.Drawing.Size(69, 13);
			lblFAAFlightId.TabIndex = 20;
			lblFAAFlightId.Text = "FAA Flight Id";
			// 
			// frm_FAAFlightData
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(1076, 613);
			Controls.Add(frmFAAFlightDataGrid);
			Controls.Add(frmFAAFlightData);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(212, 293);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_FAAFlightData";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "FAA Flight Data";
			commandButtonHelper1.SetStyle(cmdSave, 0);
			optionButtonHelper1.SetStyle(rbDestFlights, 0);
			optionButtonHelper1.SetStyle(rbOriginFlights, 0);
			optionButtonHelper1.SetStyle(rbAllFlights, 0);
			ToolTipMain.SetToolTip(frmFAAFlightDataGrid, "Click To Export FAA Flight Data In Grid");
			ToolTipMain.SetToolTip(rbDestFlights, "Click To Show Summary Of Dest Flights");
			ToolTipMain.SetToolTip(rbOriginFlights, "Click To Show Summary Of Origin Flights");
			ToolTipMain.SetToolTip(lblStopExporting, "Click To Stop Exporting To Excel");
			Activated += new System.EventHandler(frm_FAAFlightData_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grdFAAFlightDataSummary).EndInit();
			((System.ComponentModel.ISupportInitialize) grdFAAFlightData).EndInit();
			frmFAAFlightDataGrid.ResumeLayout(false);
			frmFAAFlightDataGrid.PerformLayout();
			frmFAAFlightData.ResumeLayout(false);
			frmFAAFlightData.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}