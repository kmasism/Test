
namespace JETNET_Homebase
{
	partial class frm_UserHoursWorked
	{

		#region "Upgrade Support "
		private static frm_UserHoursWorked m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_UserHoursWorked DefInstance
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
		public static frm_UserHoursWorked CreateInstance()
		{
			frm_UserHoursWorked theInstance = new frm_UserHoursWorked();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdSave", "lblStatus", "frmAction", "cmdRunReport", "cmbReport", "cmbTeamLeader", "cmdOverallTimeTracker", "pBar", "lblReport", "lblTeamLeader", "lblExportToExcel", "frmReports", "chkIncludeSatSun", "txtUserName", "txtUserId", "txtWeekOfStart", "txtWeekOfEnd", "lblUserName", "lblUserId", "lblWeekOf", "lblWeekOfTo", "frmUserInfo", "grdUserHours", "calWeekOf", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdSave;
		public System.Windows.Forms.Label lblStatus;
		public System.Windows.Forms.GroupBox frmAction;
		public System.Windows.Forms.Button cmdRunReport;
		public System.Windows.Forms.ComboBox cmbReport;
		public System.Windows.Forms.ComboBox cmbTeamLeader;
		public System.Windows.Forms.Button cmdOverallTimeTracker;
		public System.Windows.Forms.ProgressBar pBar;
		public System.Windows.Forms.Label lblReport;
		public System.Windows.Forms.Label lblTeamLeader;
		public System.Windows.Forms.Label lblExportToExcel;
		public System.Windows.Forms.GroupBox frmReports;
		public System.Windows.Forms.CheckBox chkIncludeSatSun;
		public System.Windows.Forms.TextBox txtUserName;
		public System.Windows.Forms.TextBox txtUserId;
		public System.Windows.Forms.TextBox txtWeekOfStart;
		public System.Windows.Forms.TextBox txtWeekOfEnd;
		public System.Windows.Forms.Label lblUserName;
		public System.Windows.Forms.Label lblUserId;
		public System.Windows.Forms.Label lblWeekOf;
		public System.Windows.Forms.Label lblWeekOfTo;
		public System.Windows.Forms.GroupBox frmUserInfo;
		public UpgradeHelpers.DataGridViewFlex grdUserHours;
		public System.Windows.Forms.MonthCalendar calWeekOf;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserHoursWorked));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			frmAction = new System.Windows.Forms.GroupBox();
			cmdSave = new System.Windows.Forms.Button();
			lblStatus = new System.Windows.Forms.Label();
			frmReports = new System.Windows.Forms.GroupBox();
			cmdRunReport = new System.Windows.Forms.Button();
			cmbReport = new System.Windows.Forms.ComboBox();
			cmbTeamLeader = new System.Windows.Forms.ComboBox();
			cmdOverallTimeTracker = new System.Windows.Forms.Button();
			pBar = new System.Windows.Forms.ProgressBar();
			lblReport = new System.Windows.Forms.Label();
			lblTeamLeader = new System.Windows.Forms.Label();
			lblExportToExcel = new System.Windows.Forms.Label();
			frmUserInfo = new System.Windows.Forms.GroupBox();
			chkIncludeSatSun = new System.Windows.Forms.CheckBox();
			txtUserName = new System.Windows.Forms.TextBox();
			txtUserId = new System.Windows.Forms.TextBox();
			txtWeekOfStart = new System.Windows.Forms.TextBox();
			txtWeekOfEnd = new System.Windows.Forms.TextBox();
			lblUserName = new System.Windows.Forms.Label();
			lblUserId = new System.Windows.Forms.Label();
			lblWeekOf = new System.Windows.Forms.Label();
			lblWeekOfTo = new System.Windows.Forms.Label();
			grdUserHours = new UpgradeHelpers.DataGridViewFlex(components);
			calWeekOf = new System.Windows.Forms.MonthCalendar();
			frmAction.SuspendLayout();
			frmReports.SuspendLayout();
			frmUserInfo.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grdUserHours).BeginInit();
			// 
			// frmAction
			// 
			frmAction.AllowDrop = true;
			frmAction.BackColor = System.Drawing.SystemColors.Control;
			frmAction.Controls.Add(cmdSave);
			frmAction.Controls.Add(lblStatus);
			frmAction.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmAction.Enabled = true;
			frmAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmAction.ForeColor = System.Drawing.SystemColors.ControlText;
			frmAction.Location = new System.Drawing.Point(12, 106);
			frmAction.Name = "frmAction";
			frmAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmAction.Size = new System.Drawing.Size(785, 51);
			frmAction.TabIndex = 20;
			frmAction.Text = "Action";
			frmAction.Visible = true;
			// 
			// cmdSave
			// 
			cmdSave.AllowDrop = true;
			cmdSave.BackColor = System.Drawing.SystemColors.Control;
			cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSave.Location = new System.Drawing.Point(24, 18);
			cmdSave.Name = "cmdSave";
			cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSave.Size = new System.Drawing.Size(59, 25);
			cmdSave.TabIndex = 11;
			cmdSave.Text = "&Save";
			cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSave.UseVisualStyleBackColor = false;
			cmdSave.Click += new System.EventHandler(cmdSave_Click);
			// 
			// lblStatus
			// 
			lblStatus.AllowDrop = true;
			lblStatus.BackColor = System.Drawing.SystemColors.Control;
			lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			lblStatus.Location = new System.Drawing.Point(102, 22);
			lblStatus.MinimumSize = new System.Drawing.Size(667, 15);
			lblStatus.Name = "lblStatus";
			lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblStatus.Size = new System.Drawing.Size(667, 15);
			lblStatus.TabIndex = 21;
			lblStatus.Text = "Status";
			// 
			// frmReports
			// 
			frmReports.AllowDrop = true;
			frmReports.BackColor = System.Drawing.SystemColors.Control;
			frmReports.Controls.Add(cmdRunReport);
			frmReports.Controls.Add(cmbReport);
			frmReports.Controls.Add(cmbTeamLeader);
			frmReports.Controls.Add(cmdOverallTimeTracker);
			frmReports.Controls.Add(pBar);
			frmReports.Controls.Add(lblReport);
			frmReports.Controls.Add(lblTeamLeader);
			frmReports.Controls.Add(lblExportToExcel);
			frmReports.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmReports.Enabled = true;
			frmReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmReports.ForeColor = System.Drawing.SystemColors.ControlText;
			frmReports.Location = new System.Drawing.Point(320, 6);
			frmReports.Name = "frmReports";
			frmReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmReports.Size = new System.Drawing.Size(477, 99);
			frmReports.TabIndex = 17;
			frmReports.Text = "Reports";
			frmReports.Visible = true;
			// 
			// cmdRunReport
			// 
			cmdRunReport.AllowDrop = true;
			cmdRunReport.BackColor = System.Drawing.SystemColors.Control;
			cmdRunReport.Enabled = false;
			cmdRunReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRunReport.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRunReport.Location = new System.Drawing.Point(350, 56);
			cmdRunReport.Name = "cmdRunReport";
			cmdRunReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRunReport.Size = new System.Drawing.Size(117, 23);
			cmdRunReport.TabIndex = 8;
			cmdRunReport.Text = "Run Report";
			cmdRunReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRunReport.Click += new System.EventHandler(cmdRunReport_Click);
			// 
			// cmbReport
			// 
			cmbReport.AllowDrop = true;
			cmbReport.BackColor = System.Drawing.SystemColors.Window;
			cmbReport.CausesValidation = true;
			cmbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbReport.Enabled = true;
			cmbReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbReport.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbReport.IntegralHeight = true;
			cmbReport.Location = new System.Drawing.Point(94, 48);
			cmbReport.Name = "cmbReport";
			cmbReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbReport.Size = new System.Drawing.Size(234, 21);
			cmbReport.Sorted = false;
			cmbReport.TabIndex = 6;
			cmbReport.TabStop = true;
			cmbReport.Visible = true;
			cmbReport.SelectionChangeCommitted += new System.EventHandler(cmbReport_SelectionChangeCommitted);
			// 
			// cmbTeamLeader
			// 
			cmbTeamLeader.AllowDrop = true;
			cmbTeamLeader.BackColor = System.Drawing.SystemColors.Window;
			cmbTeamLeader.CausesValidation = true;
			cmbTeamLeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbTeamLeader.Enabled = true;
			cmbTeamLeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbTeamLeader.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbTeamLeader.IntegralHeight = true;
			cmbTeamLeader.Location = new System.Drawing.Point(94, 26);
			cmbTeamLeader.Name = "cmbTeamLeader";
			cmbTeamLeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbTeamLeader.Size = new System.Drawing.Size(234, 21);
			cmbTeamLeader.Sorted = false;
			cmbTeamLeader.TabIndex = 5;
			cmbTeamLeader.TabStop = true;
			cmbTeamLeader.Visible = true;
			cmbTeamLeader.SelectionChangeCommitted += new System.EventHandler(cmbTeamLeader_SelectionChangeCommitted);
			// 
			// cmdOverallTimeTracker
			// 
			cmdOverallTimeTracker.AllowDrop = true;
			cmdOverallTimeTracker.BackColor = System.Drawing.SystemColors.Control;
			cmdOverallTimeTracker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdOverallTimeTracker.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdOverallTimeTracker.Location = new System.Drawing.Point(348, 14);
			cmdOverallTimeTracker.Name = "cmdOverallTimeTracker";
			cmdOverallTimeTracker.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdOverallTimeTracker.Size = new System.Drawing.Size(117, 23);
			cmdOverallTimeTracker.TabIndex = 7;
			cmdOverallTimeTracker.Text = "Overall Time Tracker";
			cmdOverallTimeTracker.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdOverallTimeTracker.UseVisualStyleBackColor = false;
			cmdOverallTimeTracker.Click += new System.EventHandler(cmdOverallTimeTracker_Click);
			// 
			// pBar
			// 
			pBar.AllowDrop = true;
			pBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pBar.Location = new System.Drawing.Point(10, 84);
			pBar.Name = "pBar";
			pBar.Size = new System.Drawing.Size(459, 11);
			pBar.TabIndex = 18;
			pBar.Visible = false;
			// 
			// lblReport
			// 
			lblReport.AllowDrop = true;
			lblReport.BackColor = System.Drawing.SystemColors.Control;
			lblReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblReport.ForeColor = System.Drawing.SystemColors.ControlText;
			lblReport.Location = new System.Drawing.Point(12, 52);
			lblReport.MinimumSize = new System.Drawing.Size(65, 15);
			lblReport.Name = "lblReport";
			lblReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblReport.Size = new System.Drawing.Size(65, 15);
			lblReport.TabIndex = 23;
			lblReport.Text = "Report";
			// 
			// lblTeamLeader
			// 
			lblTeamLeader.AllowDrop = true;
			lblTeamLeader.BackColor = System.Drawing.SystemColors.Control;
			lblTeamLeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblTeamLeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTeamLeader.ForeColor = System.Drawing.SystemColors.ControlText;
			lblTeamLeader.Location = new System.Drawing.Point(12, 30);
			lblTeamLeader.MinimumSize = new System.Drawing.Size(65, 15);
			lblTeamLeader.Name = "lblTeamLeader";
			lblTeamLeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblTeamLeader.Size = new System.Drawing.Size(65, 15);
			lblTeamLeader.TabIndex = 22;
			lblTeamLeader.Text = "Team Leader";
			// 
			// lblExportToExcel
			// 
			lblExportToExcel.AllowDrop = true;
			lblExportToExcel.BackColor = System.Drawing.SystemColors.Control;
			lblExportToExcel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblExportToExcel.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			lblExportToExcel.Location = new System.Drawing.Point(360, 40);
			lblExportToExcel.MinimumSize = new System.Drawing.Size(97, 15);
			lblExportToExcel.Name = "lblExportToExcel";
			lblExportToExcel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblExportToExcel.Size = new System.Drawing.Size(97, 15);
			lblExportToExcel.TabIndex = 19;
			lblExportToExcel.Text = "Export To Excel";
			lblExportToExcel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblExportToExcel.Visible = false;
			lblExportToExcel.Click += new System.EventHandler(lblExportToExcel_Click);
			// 
			// frmUserInfo
			// 
			frmUserInfo.AllowDrop = true;
			frmUserInfo.BackColor = System.Drawing.SystemColors.Control;
			frmUserInfo.Controls.Add(chkIncludeSatSun);
			frmUserInfo.Controls.Add(txtUserName);
			frmUserInfo.Controls.Add(txtUserId);
			frmUserInfo.Controls.Add(txtWeekOfStart);
			frmUserInfo.Controls.Add(txtWeekOfEnd);
			frmUserInfo.Controls.Add(lblUserName);
			frmUserInfo.Controls.Add(lblUserId);
			frmUserInfo.Controls.Add(lblWeekOf);
			frmUserInfo.Controls.Add(lblWeekOfTo);
			frmUserInfo.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmUserInfo.Enabled = true;
			frmUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmUserInfo.ForeColor = System.Drawing.SystemColors.ControlText;
			frmUserInfo.Location = new System.Drawing.Point(12, 6);
			frmUserInfo.Name = "frmUserInfo";
			frmUserInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmUserInfo.Size = new System.Drawing.Size(307, 99);
			frmUserInfo.TabIndex = 10;
			frmUserInfo.Text = "User Information";
			frmUserInfo.Visible = true;
			// 
			// chkIncludeSatSun
			// 
			chkIncludeSatSun.AllowDrop = true;
			chkIncludeSatSun.Appearance = System.Windows.Forms.Appearance.Normal;
			chkIncludeSatSun.BackColor = System.Drawing.SystemColors.Control;
			chkIncludeSatSun.CausesValidation = true;
			chkIncludeSatSun.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIncludeSatSun.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkIncludeSatSun.Enabled = true;
			chkIncludeSatSun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkIncludeSatSun.ForeColor = System.Drawing.SystemColors.ControlText;
			chkIncludeSatSun.Location = new System.Drawing.Point(192, 22);
			chkIncludeSatSun.Name = "chkIncludeSatSun";
			chkIncludeSatSun.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkIncludeSatSun.Size = new System.Drawing.Size(105, 13);
			chkIncludeSatSun.TabIndex = 1;
			chkIncludeSatSun.TabStop = true;
			chkIncludeSatSun.Text = "Include Sat/Sun";
			chkIncludeSatSun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIncludeSatSun.Visible = true;
			chkIncludeSatSun.CheckStateChanged += new System.EventHandler(chkIncludeSatSun_CheckStateChanged);
			// 
			// txtUserName
			// 
			txtUserName.AcceptsReturn = true;
			txtUserName.AllowDrop = true;
			txtUserName.BackColor = System.Drawing.SystemColors.Window;
			txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtUserName.Enabled = false;
			txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtUserName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtUserName.Location = new System.Drawing.Point(72, 44);
			txtUserName.MaxLength = 0;
			txtUserName.Name = "txtUserName";
			txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtUserName.Size = new System.Drawing.Size(227, 19);
			txtUserName.TabIndex = 2;
			// 
			// txtUserId
			// 
			txtUserId.AcceptsReturn = true;
			txtUserId.AllowDrop = true;
			txtUserId.BackColor = System.Drawing.SystemColors.Window;
			txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtUserId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtUserId.Enabled = false;
			txtUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtUserId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtUserId.Location = new System.Drawing.Point(72, 22);
			txtUserId.MaxLength = 0;
			txtUserId.Name = "txtUserId";
			txtUserId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtUserId.Size = new System.Drawing.Size(51, 19);
			txtUserId.TabIndex = 0;
			txtUserId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtUserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUserId_KeyPress);
			txtUserId.Leave += new System.EventHandler(txtUserId_Leave);
			// 
			// txtWeekOfStart
			// 
			txtWeekOfStart.AcceptsReturn = true;
			txtWeekOfStart.AllowDrop = true;
			txtWeekOfStart.BackColor = System.Drawing.SystemColors.Window;
			txtWeekOfStart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtWeekOfStart.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtWeekOfStart.Enabled = false;
			txtWeekOfStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtWeekOfStart.ForeColor = System.Drawing.SystemColors.WindowText;
			txtWeekOfStart.Location = new System.Drawing.Point(72, 66);
			txtWeekOfStart.MaxLength = 0;
			txtWeekOfStart.Name = "txtWeekOfStart";
			txtWeekOfStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtWeekOfStart.Size = new System.Drawing.Size(87, 19);
			txtWeekOfStart.TabIndex = 3;
			txtWeekOfStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtWeekOfStart.Leave += new System.EventHandler(txtWeekOfStart_Leave);
			// 
			// txtWeekOfEnd
			// 
			txtWeekOfEnd.AcceptsReturn = true;
			txtWeekOfEnd.AllowDrop = true;
			txtWeekOfEnd.BackColor = System.Drawing.SystemColors.Window;
			txtWeekOfEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtWeekOfEnd.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtWeekOfEnd.Enabled = false;
			txtWeekOfEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtWeekOfEnd.ForeColor = System.Drawing.SystemColors.WindowText;
			txtWeekOfEnd.Location = new System.Drawing.Point(212, 66);
			txtWeekOfEnd.MaxLength = 0;
			txtWeekOfEnd.Name = "txtWeekOfEnd";
			txtWeekOfEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtWeekOfEnd.Size = new System.Drawing.Size(87, 19);
			txtWeekOfEnd.TabIndex = 4;
			txtWeekOfEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtWeekOfEnd.Leave += new System.EventHandler(txtWeekOfEnd_Leave);
			// 
			// lblUserName
			// 
			lblUserName.AllowDrop = true;
			lblUserName.BackColor = System.Drawing.SystemColors.Control;
			lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblUserName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblUserName.Location = new System.Drawing.Point(8, 46);
			lblUserName.MinimumSize = new System.Drawing.Size(61, 15);
			lblUserName.Name = "lblUserName";
			lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblUserName.Size = new System.Drawing.Size(61, 15);
			lblUserName.TabIndex = 16;
			lblUserName.Text = "User Name:";
			// 
			// lblUserId
			// 
			lblUserId.AllowDrop = true;
			lblUserId.BackColor = System.Drawing.SystemColors.Control;
			lblUserId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblUserId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblUserId.Location = new System.Drawing.Point(8, 24);
			lblUserId.MinimumSize = new System.Drawing.Size(61, 15);
			lblUserId.Name = "lblUserId";
			lblUserId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblUserId.Size = new System.Drawing.Size(61, 15);
			lblUserId.TabIndex = 15;
			lblUserId.Text = "User Id:";
			// 
			// lblWeekOf
			// 
			lblWeekOf.AllowDrop = true;
			lblWeekOf.BackColor = System.Drawing.SystemColors.Control;
			lblWeekOf.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblWeekOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblWeekOf.ForeColor = System.Drawing.SystemColors.ControlText;
			lblWeekOf.Location = new System.Drawing.Point(8, 68);
			lblWeekOf.MinimumSize = new System.Drawing.Size(61, 15);
			lblWeekOf.Name = "lblWeekOf";
			lblWeekOf.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblWeekOf.Size = new System.Drawing.Size(61, 15);
			lblWeekOf.TabIndex = 14;
			lblWeekOf.Text = "Week Of";
			// 
			// lblWeekOfTo
			// 
			lblWeekOfTo.AllowDrop = true;
			lblWeekOfTo.BackColor = System.Drawing.SystemColors.Control;
			lblWeekOfTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblWeekOfTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblWeekOfTo.ForeColor = System.Drawing.SystemColors.ControlText;
			lblWeekOfTo.Location = new System.Drawing.Point(174, 68);
			lblWeekOfTo.MinimumSize = new System.Drawing.Size(23, 15);
			lblWeekOfTo.Name = "lblWeekOfTo";
			lblWeekOfTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblWeekOfTo.Size = new System.Drawing.Size(23, 15);
			lblWeekOfTo.TabIndex = 13;
			lblWeekOfTo.Text = "To";
			lblWeekOfTo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// grdUserHours
			// 
			grdUserHours.AllowBigSelection = false;
			grdUserHours.AllowDrop = true;
			grdUserHours.AllowUserToAddRows = false;
			grdUserHours.AllowUserToDeleteRows = false;
			grdUserHours.AllowUserToResizeColumns = false;
			grdUserHours.AllowUserToResizeRows = false;
			grdUserHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdUserHours.ColumnsCount = 2;
			grdUserHours.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			grdUserHours.FixedColumns = 1;
			grdUserHours.FixedRows = 1;
			grdUserHours.Location = new System.Drawing.Point(12, 158);
			grdUserHours.Name = "grdUserHours";
			grdUserHours.ReadOnly = true;
			grdUserHours.RowsCount = 2;
			grdUserHours.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grdUserHours.ShowCellToolTips = false;
			grdUserHours.Size = new System.Drawing.Size(969, 319);
			grdUserHours.StandardTab = true;
			grdUserHours.TabIndex = 12;
			grdUserHours.Click += new System.EventHandler(grdUserHours_Click);
			grdUserHours.KeyDown += new System.Windows.Forms.KeyEventHandler(grdUserHours_KeyDown);
			grdUserHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(grdUserHours_KeyPress);
			// 
			// calWeekOf
			// 
			calWeekOf.AllowDrop = true;
			calWeekOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			calWeekOf.ForeColor = System.Drawing.SystemColors.ControlText;
			calWeekOf.Location = new System.Drawing.Point(802, 0);
			calWeekOf.Name = "calWeekOf";
			calWeekOf.Size = new System.Drawing.Size(178, 154);
			calWeekOf.TabIndex = 9;
			calWeekOf.Tag = "No";
			// 
			// frm_UserHoursWorked
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(997, 490);
			Controls.Add(frmAction);
			Controls.Add(frmReports);
			Controls.Add(frmUserInfo);
			Controls.Add(grdUserHours);
			Controls.Add(calWeekOf);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(498, 146);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_UserHoursWorked";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "User - Hours Worked";
			commandButtonHelper1.SetStyle(cmdSave, 0);
			commandButtonHelper1.SetStyle(cmdRunReport, 0);
			commandButtonHelper1.SetStyle(cmdOverallTimeTracker, 0);
			ToolTipMain.SetToolTip(cmdSave, "Click To Save The Data In The Grid");
			ToolTipMain.SetToolTip(cmdRunReport, "Run Report Based On Team Leader and Report Selected");
			ToolTipMain.SetToolTip(cmbReport, "Select Report To Run");
			ToolTipMain.SetToolTip(cmbTeamLeader, "Select Team Leader");
			ToolTipMain.SetToolTip(cmdOverallTimeTracker, "Exports the Overall Time Tracker Report To Excel");
			Activated += new System.EventHandler(frm_UserHoursWorked_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grdUserHours).EndInit();
			frmAction.ResumeLayout(false);
			frmAction.PerformLayout();
			frmReports.ResumeLayout(false);
			frmReports.PerformLayout();
			frmUserInfo.ResumeLayout(false);
			frmUserInfo.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}