
namespace JETNET_Homebase
{
	partial class frm_UserAccounts
	{

		#region "Upgrade Support "
		private static frm_UserAccounts m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_UserAccounts DefInstance
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
		public static frm_UserAccounts CreateInstance()
		{
			frm_UserAccounts theInstance = new frm_UserAccounts();
			theInstance.Form_Load();
			//The MDI form in the VB6 project had its
			//AutoShowChildren property set to True
			//To simulate the VB6 behavior, we need to
			//automatically Show the form whenever it
			//is loaded.  If you do not want this behavior
			//then delete the following line of code
			//UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-2018
			theInstance.Show();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileClose", "mnuFileLogout", "mnuFile", "mnuAddAccountID", "mnuResetAuto", "mnuFixSerNoSort", "mnuEdit", "MainMenu1", "cmdStop", "tbr_ToolBar_Buttons_Button1", "tbr_ToolBar_Buttons_Button2", "tbr_ToolBar_Buttons_Button3", "tbr_ToolBar_Buttons_Button4", "tbr_ToolBar_Buttons_Button5", "tbr_ToolBar_Buttons_Button6", "tbr_ToolBar_Buttons_Button7", "tbr_ToolBar_Buttons_Button8", "tbr_ToolBar", "txt_eu_prime_count", "txt_db_prime_count", "txt_assign_character", "cbo_assign_db_account_id", "cbo_assign_eu_account_id", "cmd_Save_Assignments", "txt_db_count", "txt_eu_count", "_lbl_account_16", "_lbl_account_15", "_lbl_account_0", "_lbl_account_7", "_lbl_account_8", "_lbl_account_9", "_lbl_account_10", "pnl_AutoAssign", "cbo_Account_ID", "lst_Assign", "lbl_account_character", "lbl_eu_account_id", "lbl_db_account_id", "SSPanel1", "cmbResearchType", "cboTeams", "ChkTeams", "cbo_Account_Scope", "txtAcctRep", "txt_tot_AC_unused", "txt_tot_prime_company", "txt_tot_prime_auto_company", "txt_tot_prime_man_company", "txt_tot_man_aircraft", "txt_tot_aut_aircraft", "txt_tot_aut_comp", "txt_tot_man_comp", "txt_tot_comp", "txt_tot_aircraft", "_lbl_account_18", "_lbl_account_17", "Label4", "_lbl_account_14", "_lbl_account_13", "_lbl_account_12", "_lbl_account_11", "_lbl_account_5", "_lbl_account_2", "_lbl_account_1", "Label1", "_lbl_account_6", "_lbl_account_4", "_lbl_account_3", "SSPanel2", "chkIncludeACCount", "cmdAccountAssignRefresh", "cmd_AircraftDetail", "GrdAircraftDetail", "lblTeam", "pnl_AircraftDetail", "grdACSummary", "txtNewAccountID", "cmdSaveNewAccountID", "cmdCancelNewAccountID", "cmdDeleteNewAccountID", "lblNewAccountID", "pnlAddNewAccountID", "frmAcctAssignments", "_tab_Accounts_TabPage0", "lblUnassigned", "Label2", "Label3", "txt_FoundCount", "txt_RecCount", "cmd_Analyze", "lst_Unassigned", "lst_dup", "cmd_FindDup", "txt_message", "txtTotalUnAssigned", "_tab_Accounts_TabPage1", "wbAcctRepActivity", "grdSchedule", "chkAllActivityReports", "txt_primaryneedconfirm", "txt_end_time", "txt_start_time", "cbo_days_confirm", "txt_primaryconfirmed", "txt_primarycompanies", "txt_totalnonconfirmedcompanies", "txt_totalconfirmedcompanies", "txt_totalactivecompanies", "cmd_SummarizeConfirms", "txtDate2", "txtDate1", "optAccountRepActivity", "optCallbackSchedule", "lstCompany", "chkIgnoreSchedDate2", "chkIgnoreSchedDate1", "lstAcctRep", "cmdScheduleGo", "MonthView2", "MonthView1", "Label6", "Label5", "lblGrandTotal", "lblCompany", "lblTo", "lblFrom", "_tab_Accounts_TabPage2", "tab_Accounts", "lbl_account", "optionButtonHelper1", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFileLogout;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.ToolStripMenuItem mnuAddAccountID;
		public System.Windows.Forms.ToolStripMenuItem mnuResetAuto;
		public System.Windows.Forms.ToolStripMenuItem mnuFixSerNoSort;
		public System.Windows.Forms.ToolStripMenuItem mnuEdit;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.Button cmdStop;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button1;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button2;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button3;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button4;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button5;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button6;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button7;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button8;
		public System.Windows.Forms.ToolStrip tbr_ToolBar;
		public System.Windows.Forms.TextBox txt_eu_prime_count;
		public System.Windows.Forms.TextBox txt_db_prime_count;
		public System.Windows.Forms.TextBox txt_assign_character;
		public System.Windows.Forms.ComboBox cbo_assign_db_account_id;
		public System.Windows.Forms.ComboBox cbo_assign_eu_account_id;
		public System.Windows.Forms.Button cmd_Save_Assignments;
		public System.Windows.Forms.TextBox txt_db_count;
		public System.Windows.Forms.TextBox txt_eu_count;
		private System.Windows.Forms.Label _lbl_account_16;
		private System.Windows.Forms.Label _lbl_account_15;
		private System.Windows.Forms.Label _lbl_account_0;
		private System.Windows.Forms.Label _lbl_account_7;
		private System.Windows.Forms.Label _lbl_account_8;
		private System.Windows.Forms.Label _lbl_account_9;
		private System.Windows.Forms.Label _lbl_account_10;
		public System.Windows.Forms.Panel pnl_AutoAssign;
		public System.Windows.Forms.ComboBox cbo_Account_ID;
		public System.Windows.Forms.ListBox lst_Assign;
		public System.Windows.Forms.Label lbl_account_character;
		public System.Windows.Forms.Label lbl_eu_account_id;
		public System.Windows.Forms.Label lbl_db_account_id;
		public System.Windows.Forms.Panel SSPanel1;
		public System.Windows.Forms.ComboBox cmbResearchType;
		public System.Windows.Forms.ComboBox cboTeams;
		public System.Windows.Forms.CheckBox ChkTeams;
		public System.Windows.Forms.ComboBox cbo_Account_Scope;
		public System.Windows.Forms.TextBox txtAcctRep;
		public System.Windows.Forms.TextBox txt_tot_AC_unused;
		public System.Windows.Forms.TextBox txt_tot_prime_company;
		public System.Windows.Forms.TextBox txt_tot_prime_auto_company;
		public System.Windows.Forms.TextBox txt_tot_prime_man_company;
		public System.Windows.Forms.TextBox txt_tot_man_aircraft;
		public System.Windows.Forms.TextBox txt_tot_aut_aircraft;
		public System.Windows.Forms.TextBox txt_tot_aut_comp;
		public System.Windows.Forms.TextBox txt_tot_man_comp;
		public System.Windows.Forms.TextBox txt_tot_comp;
		public System.Windows.Forms.TextBox txt_tot_aircraft;
		private System.Windows.Forms.Label _lbl_account_18;
		private System.Windows.Forms.Label _lbl_account_17;
		public System.Windows.Forms.Label Label4;
		private System.Windows.Forms.Label _lbl_account_14;
		private System.Windows.Forms.Label _lbl_account_13;
		private System.Windows.Forms.Label _lbl_account_12;
		private System.Windows.Forms.Label _lbl_account_11;
		private System.Windows.Forms.Label _lbl_account_5;
		private System.Windows.Forms.Label _lbl_account_2;
		private System.Windows.Forms.Label _lbl_account_1;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label _lbl_account_6;
		private System.Windows.Forms.Label _lbl_account_4;
		private System.Windows.Forms.Label _lbl_account_3;
		public System.Windows.Forms.Panel SSPanel2;
		public System.Windows.Forms.CheckBox chkIncludeACCount;
		public System.Windows.Forms.Button cmdAccountAssignRefresh;
		public System.Windows.Forms.Button cmd_AircraftDetail;
		public UpgradeHelpers.DataGridViewFlex GrdAircraftDetail;
		public System.Windows.Forms.Label lblTeam;
		public System.Windows.Forms.GroupBox pnl_AircraftDetail;
		public UpgradeHelpers.DataGridViewFlex grdACSummary;
		public System.Windows.Forms.TextBox txtNewAccountID;
		public System.Windows.Forms.Button cmdSaveNewAccountID;
		public System.Windows.Forms.Button cmdCancelNewAccountID;
		public System.Windows.Forms.Button cmdDeleteNewAccountID;
		public System.Windows.Forms.Label lblNewAccountID;
		public System.Windows.Forms.Panel pnlAddNewAccountID;
		public System.Windows.Forms.GroupBox frmAcctAssignments;
		private System.Windows.Forms.TabPage _tab_Accounts_TabPage0;
		public System.Windows.Forms.Label lblUnassigned;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.TextBox txt_FoundCount;
		public System.Windows.Forms.TextBox txt_RecCount;
		public System.Windows.Forms.Button cmd_Analyze;
		public System.Windows.Forms.ListBox lst_Unassigned;
		public System.Windows.Forms.ListBox lst_dup;
		public System.Windows.Forms.Button cmd_FindDup;
		public System.Windows.Forms.TextBox txt_message;
		public System.Windows.Forms.TextBox txtTotalUnAssigned;
		private System.Windows.Forms.TabPage _tab_Accounts_TabPage1;
		public System.Windows.Forms.WebBrowser wbAcctRepActivity;
		public UpgradeHelpers.DataGridViewFlex grdSchedule;
		public System.Windows.Forms.CheckBox chkAllActivityReports;
		public System.Windows.Forms.TextBox txt_primaryneedconfirm;
		public System.Windows.Forms.TextBox txt_end_time;
		public System.Windows.Forms.TextBox txt_start_time;
		public System.Windows.Forms.ComboBox cbo_days_confirm;
		public System.Windows.Forms.TextBox txt_primaryconfirmed;
		public System.Windows.Forms.TextBox txt_primarycompanies;
		public System.Windows.Forms.TextBox txt_totalnonconfirmedcompanies;
		public System.Windows.Forms.TextBox txt_totalconfirmedcompanies;
		public System.Windows.Forms.TextBox txt_totalactivecompanies;
		public System.Windows.Forms.Button cmd_SummarizeConfirms;
		public System.Windows.Forms.TextBox txtDate2;
		public System.Windows.Forms.TextBox txtDate1;
		public System.Windows.Forms.RadioButton optAccountRepActivity;
		public System.Windows.Forms.RadioButton optCallbackSchedule;
		public System.Windows.Forms.ListBox lstCompany;
		public System.Windows.Forms.CheckBox chkIgnoreSchedDate2;
		public System.Windows.Forms.CheckBox chkIgnoreSchedDate1;
		public System.Windows.Forms.ListBox lstAcctRep;
		public System.Windows.Forms.Button cmdScheduleGo;
		public System.Windows.Forms.MonthCalendar MonthView2;
		public System.Windows.Forms.MonthCalendar MonthView1;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label lblGrandTotal;
		public System.Windows.Forms.Label lblCompany;
		public System.Windows.Forms.Label lblTo;
		public System.Windows.Forms.Label lblFrom;
		private System.Windows.Forms.TabPage _tab_Accounts_TabPage2;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_Accounts;
		public System.Windows.Forms.Label[] lbl_account = new System.Windows.Forms.Label[19];
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		public System.ComponentModel.ComponentResourceManager resources;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserAccounts));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileLogout = new System.Windows.Forms.ToolStripMenuItem();
			mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
			mnuAddAccountID = new System.Windows.Forms.ToolStripMenuItem();
			mnuResetAuto = new System.Windows.Forms.ToolStripMenuItem();
			mnuFixSerNoSort = new System.Windows.Forms.ToolStripMenuItem();
			cmdStop = new System.Windows.Forms.Button();
			tbr_ToolBar = new System.Windows.Forms.ToolStrip();
			tbr_ToolBar_Buttons_Button1 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button2 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button3 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button4 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button5 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button6 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button7 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button8 = new System.Windows.Forms.ToolStripButton();
			tab_Accounts = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_Accounts_TabPage0 = new System.Windows.Forms.TabPage();
			pnl_AutoAssign = new System.Windows.Forms.Panel();
			txt_eu_prime_count = new System.Windows.Forms.TextBox();
			txt_db_prime_count = new System.Windows.Forms.TextBox();
			txt_assign_character = new System.Windows.Forms.TextBox();
			cbo_assign_db_account_id = new System.Windows.Forms.ComboBox();
			cbo_assign_eu_account_id = new System.Windows.Forms.ComboBox();
			cmd_Save_Assignments = new System.Windows.Forms.Button();
			txt_db_count = new System.Windows.Forms.TextBox();
			txt_eu_count = new System.Windows.Forms.TextBox();
			_lbl_account_16 = new System.Windows.Forms.Label();
			_lbl_account_15 = new System.Windows.Forms.Label();
			_lbl_account_0 = new System.Windows.Forms.Label();
			_lbl_account_7 = new System.Windows.Forms.Label();
			_lbl_account_8 = new System.Windows.Forms.Label();
			_lbl_account_9 = new System.Windows.Forms.Label();
			_lbl_account_10 = new System.Windows.Forms.Label();
			SSPanel1 = new System.Windows.Forms.Panel();
			cbo_Account_ID = new System.Windows.Forms.ComboBox();
			lst_Assign = new System.Windows.Forms.ListBox();
			lbl_account_character = new System.Windows.Forms.Label();
			lbl_eu_account_id = new System.Windows.Forms.Label();
			lbl_db_account_id = new System.Windows.Forms.Label();
			SSPanel2 = new System.Windows.Forms.Panel();
			cmbResearchType = new System.Windows.Forms.ComboBox();
			cboTeams = new System.Windows.Forms.ComboBox();
			ChkTeams = new System.Windows.Forms.CheckBox();
			cbo_Account_Scope = new System.Windows.Forms.ComboBox();
			txtAcctRep = new System.Windows.Forms.TextBox();
			txt_tot_AC_unused = new System.Windows.Forms.TextBox();
			txt_tot_prime_company = new System.Windows.Forms.TextBox();
			txt_tot_prime_auto_company = new System.Windows.Forms.TextBox();
			txt_tot_prime_man_company = new System.Windows.Forms.TextBox();
			txt_tot_man_aircraft = new System.Windows.Forms.TextBox();
			txt_tot_aut_aircraft = new System.Windows.Forms.TextBox();
			txt_tot_aut_comp = new System.Windows.Forms.TextBox();
			txt_tot_man_comp = new System.Windows.Forms.TextBox();
			txt_tot_comp = new System.Windows.Forms.TextBox();
			txt_tot_aircraft = new System.Windows.Forms.TextBox();
			_lbl_account_18 = new System.Windows.Forms.Label();
			_lbl_account_17 = new System.Windows.Forms.Label();
			Label4 = new System.Windows.Forms.Label();
			_lbl_account_14 = new System.Windows.Forms.Label();
			_lbl_account_13 = new System.Windows.Forms.Label();
			_lbl_account_12 = new System.Windows.Forms.Label();
			_lbl_account_11 = new System.Windows.Forms.Label();
			_lbl_account_5 = new System.Windows.Forms.Label();
			_lbl_account_2 = new System.Windows.Forms.Label();
			_lbl_account_1 = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			_lbl_account_6 = new System.Windows.Forms.Label();
			_lbl_account_4 = new System.Windows.Forms.Label();
			_lbl_account_3 = new System.Windows.Forms.Label();
			chkIncludeACCount = new System.Windows.Forms.CheckBox();
			cmdAccountAssignRefresh = new System.Windows.Forms.Button();
			frmAcctAssignments = new System.Windows.Forms.GroupBox();
			pnl_AircraftDetail = new System.Windows.Forms.GroupBox();
			cmd_AircraftDetail = new System.Windows.Forms.Button();
			GrdAircraftDetail = new UpgradeHelpers.DataGridViewFlex(components);
			lblTeam = new System.Windows.Forms.Label();
			grdACSummary = new UpgradeHelpers.DataGridViewFlex(components);
			pnlAddNewAccountID = new System.Windows.Forms.Panel();
			txtNewAccountID = new System.Windows.Forms.TextBox();
			cmdSaveNewAccountID = new System.Windows.Forms.Button();
			cmdCancelNewAccountID = new System.Windows.Forms.Button();
			cmdDeleteNewAccountID = new System.Windows.Forms.Button();
			lblNewAccountID = new System.Windows.Forms.Label();
			_tab_Accounts_TabPage1 = new System.Windows.Forms.TabPage();
			lblUnassigned = new System.Windows.Forms.Label();
			Label2 = new System.Windows.Forms.Label();
			Label3 = new System.Windows.Forms.Label();
			txt_FoundCount = new System.Windows.Forms.TextBox();
			txt_RecCount = new System.Windows.Forms.TextBox();
			cmd_Analyze = new System.Windows.Forms.Button();
			lst_Unassigned = new System.Windows.Forms.ListBox();
			lst_dup = new System.Windows.Forms.ListBox();
			cmd_FindDup = new System.Windows.Forms.Button();
			txt_message = new System.Windows.Forms.TextBox();
			txtTotalUnAssigned = new System.Windows.Forms.TextBox();
			_tab_Accounts_TabPage2 = new System.Windows.Forms.TabPage();
			wbAcctRepActivity = new System.Windows.Forms.WebBrowser();
			grdSchedule = new UpgradeHelpers.DataGridViewFlex(components);
			chkAllActivityReports = new System.Windows.Forms.CheckBox();
			txt_primaryneedconfirm = new System.Windows.Forms.TextBox();
			txt_end_time = new System.Windows.Forms.TextBox();
			txt_start_time = new System.Windows.Forms.TextBox();
			cbo_days_confirm = new System.Windows.Forms.ComboBox();
			txt_primaryconfirmed = new System.Windows.Forms.TextBox();
			txt_primarycompanies = new System.Windows.Forms.TextBox();
			txt_totalnonconfirmedcompanies = new System.Windows.Forms.TextBox();
			txt_totalconfirmedcompanies = new System.Windows.Forms.TextBox();
			txt_totalactivecompanies = new System.Windows.Forms.TextBox();
			cmd_SummarizeConfirms = new System.Windows.Forms.Button();
			txtDate2 = new System.Windows.Forms.TextBox();
			txtDate1 = new System.Windows.Forms.TextBox();
			optAccountRepActivity = new System.Windows.Forms.RadioButton();
			optCallbackSchedule = new System.Windows.Forms.RadioButton();
			lstCompany = new System.Windows.Forms.ListBox();
			chkIgnoreSchedDate2 = new System.Windows.Forms.CheckBox();
			chkIgnoreSchedDate1 = new System.Windows.Forms.CheckBox();
			lstAcctRep = new System.Windows.Forms.ListBox();
			cmdScheduleGo = new System.Windows.Forms.Button();
			MonthView2 = new System.Windows.Forms.MonthCalendar();
			MonthView1 = new System.Windows.Forms.MonthCalendar();
			Label6 = new System.Windows.Forms.Label();
			Label5 = new System.Windows.Forms.Label();
			lblGrandTotal = new System.Windows.Forms.Label();
			lblCompany = new System.Windows.Forms.Label();
			lblTo = new System.Windows.Forms.Label();
			lblFrom = new System.Windows.Forms.Label();
			tbr_ToolBar.SuspendLayout();
			tab_Accounts.SuspendLayout();
			_tab_Accounts_TabPage0.SuspendLayout();
			pnl_AutoAssign.SuspendLayout();
			SSPanel1.SuspendLayout();
			SSPanel2.SuspendLayout();
			frmAcctAssignments.SuspendLayout();
			pnl_AircraftDetail.SuspendLayout();
			pnlAddNewAccountID.SuspendLayout();
			_tab_Accounts_TabPage1.SuspendLayout();
			_tab_Accounts_TabPage2.SuspendLayout();
			SuspendLayout();
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) GrdAircraftDetail).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdACSummary).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdSchedule).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFile, mnuEdit});
			// 
			// mnuFile
			// 
			mnuFile.Available = true;
			mnuFile.Checked = false;
			mnuFile.Enabled = true;
			mnuFile.Name = "mnuFile";
			mnuFile.Text = "&File";
			mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFileClose, mnuFileLogout});
			// 
			// mnuFileClose
			// 
			mnuFileClose.Available = true;
			mnuFileClose.Checked = false;
			mnuFileClose.Enabled = true;
			mnuFileClose.Name = "mnuFileClose";
			mnuFileClose.Text = "Close";
			mnuFileClose.Click += new System.EventHandler(mnuFileClose_Click);
			// 
			// mnuFileLogout
			// 
			mnuFileLogout.Available = true;
			mnuFileLogout.Checked = false;
			mnuFileLogout.Enabled = true;
			mnuFileLogout.Name = "mnuFileLogout";
			mnuFileLogout.Text = "Logout";
			mnuFileLogout.Click += new System.EventHandler(mnuFileLogout_Click);
			// 
			// mnuEdit
			// 
			mnuEdit.Available = true;
			mnuEdit.Checked = false;
			mnuEdit.Enabled = true;
			mnuEdit.Name = "mnuEdit";
			mnuEdit.Text = "&Edit";
			mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuAddAccountID, mnuResetAuto, mnuFixSerNoSort});
			// 
			// mnuAddAccountID
			// 
			mnuAddAccountID.Available = true;
			mnuAddAccountID.Checked = false;
			mnuAddAccountID.Enabled = true;
			mnuAddAccountID.Name = "mnuAddAccountID";
			mnuAddAccountID.Text = "&Add New Account ID";
			mnuAddAccountID.Click += new System.EventHandler(mnuAddAccountID_Click);
			// 
			// mnuResetAuto
			// 
			mnuResetAuto.Available = true;
			mnuResetAuto.Checked = false;
			mnuResetAuto.Enabled = true;
			mnuResetAuto.Name = "mnuResetAuto";
			mnuResetAuto.Text = "&Reset All Auto-Assigned Account Reps";
			mnuResetAuto.Click += new System.EventHandler(mnuResetAuto_Click);
			// 
			// mnuFixSerNoSort
			// 
			mnuFixSerNoSort.Available = true;
			mnuFixSerNoSort.Checked = false;
			mnuFixSerNoSort.Enabled = true;
			mnuFixSerNoSort.Name = "mnuFixSerNoSort";
			mnuFixSerNoSort.Text = "Fix Ser_no_sort";
			mnuFixSerNoSort.Click += new System.EventHandler(mnuFixSerNoSort_Click);
			// 
			// cmdStop
			// 
			cmdStop.AllowDrop = true;
			cmdStop.BackColor = System.Drawing.SystemColors.Control;
			cmdStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdStop.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdStop.Location = new System.Drawing.Point(28, 658);
			cmdStop.Name = "cmdStop";
			cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdStop.Size = new System.Drawing.Size(72, 22);
			cmdStop.TabIndex = 48;
			cmdStop.Text = "Stop";
			cmdStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdStop.UseVisualStyleBackColor = false;
			cmdStop.Visible = false;
			cmdStop.Click += new System.EventHandler(cmdStop_Click);
			cmdStop.MouseMove += new System.Windows.Forms.MouseEventHandler(cmdStop_MouseMove);
			cmdStop.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdStop_MouseUp);
			// 
			// tbr_ToolBar
			// 
			tbr_ToolBar.AllowDrop = true;
			tbr_ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
			tbr_ToolBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tbr_ToolBar.Location = new System.Drawing.Point(0, 24);
			tbr_ToolBar.Name = "tbr_ToolBar";
			tbr_ToolBar.ShowItemToolTips = true;
			tbr_ToolBar.Size = new System.Drawing.Size(1004, 28);
			tbr_ToolBar.TabIndex = 30;
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button1);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button2);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button3);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button4);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button5);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button6);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button7);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button8);
			// 
			// tbr_ToolBar_Buttons_Button1
			// 
			tbr_ToolBar_Buttons_Button1.Size = new System.Drawing.Size(6, 22);
			tbr_ToolBar_Buttons_Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button1.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button2
			// 
			tbr_ToolBar_Buttons_Button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_ToolBar_Buttons_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_ToolBar_Buttons_Button2.Size = new System.Drawing.Size(24, 22);
			tbr_ToolBar_Buttons_Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button2.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button3
			// 
			tbr_ToolBar_Buttons_Button3.Size = new System.Drawing.Size(6, 22);
			tbr_ToolBar_Buttons_Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button3.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button4
			// 
			tbr_ToolBar_Buttons_Button4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_ToolBar_Buttons_Button4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_ToolBar_Buttons_Button4.Size = new System.Drawing.Size(24, 22);
			tbr_ToolBar_Buttons_Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button4.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button5
			// 
			tbr_ToolBar_Buttons_Button5.Size = new System.Drawing.Size(6, 22);
			tbr_ToolBar_Buttons_Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button5.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button6
			// 
			tbr_ToolBar_Buttons_Button6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_ToolBar_Buttons_Button6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_ToolBar_Buttons_Button6.Size = new System.Drawing.Size(24, 22);
			tbr_ToolBar_Buttons_Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button6.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button7
			// 
			tbr_ToolBar_Buttons_Button7.Size = new System.Drawing.Size(6, 22);
			tbr_ToolBar_Buttons_Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button7.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button8
			// 
			tbr_ToolBar_Buttons_Button8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_ToolBar_Buttons_Button8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_ToolBar_Buttons_Button8.Size = new System.Drawing.Size(24, 22);
			tbr_ToolBar_Buttons_Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button8.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tab_Accounts
			// 
			tab_Accounts.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_Accounts.AllowDrop = true;
			tab_Accounts.Controls.Add(_tab_Accounts_TabPage0);
			tab_Accounts.Controls.Add(_tab_Accounts_TabPage1);
			tab_Accounts.Controls.Add(_tab_Accounts_TabPage2);
			tab_Accounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_Accounts.ItemSize = new System.Drawing.Size(332, 18);
			tab_Accounts.Location = new System.Drawing.Point(-1, 58);
			tab_Accounts.Multiline = true;
			tab_Accounts.Name = "tab_Accounts";
			tab_Accounts.Size = new System.Drawing.Size(1005, 633);
			tab_Accounts.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_Accounts.TabIndex = 0;
			// 
			// _tab_Accounts_TabPage0
			// 
			_tab_Accounts_TabPage0.Controls.Add(pnl_AutoAssign);
			_tab_Accounts_TabPage0.Controls.Add(SSPanel1);
			_tab_Accounts_TabPage0.Controls.Add(SSPanel2);
			_tab_Accounts_TabPage0.Controls.Add(chkIncludeACCount);
			_tab_Accounts_TabPage0.Controls.Add(cmdAccountAssignRefresh);
			_tab_Accounts_TabPage0.Controls.Add(frmAcctAssignments);
			_tab_Accounts_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Accounts_TabPage0.Text = "Account Assignments";
			// 
			// pnl_AutoAssign
			// 
			pnl_AutoAssign.AllowDrop = true;
			pnl_AutoAssign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_AutoAssign.Controls.Add(txt_eu_prime_count);
			pnl_AutoAssign.Controls.Add(txt_db_prime_count);
			pnl_AutoAssign.Controls.Add(txt_assign_character);
			pnl_AutoAssign.Controls.Add(cbo_assign_db_account_id);
			pnl_AutoAssign.Controls.Add(cbo_assign_eu_account_id);
			pnl_AutoAssign.Controls.Add(cmd_Save_Assignments);
			pnl_AutoAssign.Controls.Add(txt_db_count);
			pnl_AutoAssign.Controls.Add(txt_eu_count);
			pnl_AutoAssign.Controls.Add(_lbl_account_16);
			pnl_AutoAssign.Controls.Add(_lbl_account_15);
			pnl_AutoAssign.Controls.Add(_lbl_account_0);
			pnl_AutoAssign.Controls.Add(_lbl_account_7);
			pnl_AutoAssign.Controls.Add(_lbl_account_8);
			pnl_AutoAssign.Controls.Add(_lbl_account_9);
			pnl_AutoAssign.Controls.Add(_lbl_account_10);
			pnl_AutoAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_AutoAssign.Location = new System.Drawing.Point(806, 5);
			pnl_AutoAssign.Name = "pnl_AutoAssign";
			pnl_AutoAssign.Size = new System.Drawing.Size(190, 264);
			pnl_AutoAssign.TabIndex = 13;
			// 
			// txt_eu_prime_count
			// 
			txt_eu_prime_count.AcceptsReturn = true;
			txt_eu_prime_count.AllowDrop = true;
			txt_eu_prime_count.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_eu_prime_count.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_eu_prime_count.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_eu_prime_count.Enabled = false;
			txt_eu_prime_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_eu_prime_count.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_eu_prime_count.Location = new System.Drawing.Point(136, 188);
			txt_eu_prime_count.MaxLength = 0;
			txt_eu_prime_count.Name = "txt_eu_prime_count";
			txt_eu_prime_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_eu_prime_count.Size = new System.Drawing.Size(49, 19);
			txt_eu_prime_count.TabIndex = 73;
			// 
			// txt_db_prime_count
			// 
			txt_db_prime_count.AcceptsReturn = true;
			txt_db_prime_count.AllowDrop = true;
			txt_db_prime_count.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_db_prime_count.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_db_prime_count.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_db_prime_count.Enabled = false;
			txt_db_prime_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_db_prime_count.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_db_prime_count.Location = new System.Drawing.Point(136, 137);
			txt_db_prime_count.MaxLength = 0;
			txt_db_prime_count.Name = "txt_db_prime_count";
			txt_db_prime_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_db_prime_count.Size = new System.Drawing.Size(49, 19);
			txt_db_prime_count.TabIndex = 72;
			// 
			// txt_assign_character
			// 
			txt_assign_character.AcceptsReturn = true;
			txt_assign_character.AllowDrop = true;
			txt_assign_character.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_assign_character.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_assign_character.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_assign_character.Enabled = false;
			txt_assign_character.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_assign_character.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_assign_character.Location = new System.Drawing.Point(88, 51);
			txt_assign_character.MaxLength = 0;
			txt_assign_character.Name = "txt_assign_character";
			txt_assign_character.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_assign_character.Size = new System.Drawing.Size(33, 19);
			txt_assign_character.TabIndex = 19;
			// 
			// cbo_assign_db_account_id
			// 
			cbo_assign_db_account_id.AllowDrop = true;
			cbo_assign_db_account_id.BackColor = System.Drawing.SystemColors.Window;
			cbo_assign_db_account_id.CausesValidation = true;
			cbo_assign_db_account_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_assign_db_account_id.Enabled = true;
			cbo_assign_db_account_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_assign_db_account_id.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_assign_db_account_id.IntegralHeight = true;
			cbo_assign_db_account_id.Location = new System.Drawing.Point(76, 115);
			cbo_assign_db_account_id.Name = "cbo_assign_db_account_id";
			cbo_assign_db_account_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_assign_db_account_id.Size = new System.Drawing.Size(59, 21);
			cbo_assign_db_account_id.Sorted = false;
			cbo_assign_db_account_id.TabIndex = 18;
			cbo_assign_db_account_id.TabStop = true;
			cbo_assign_db_account_id.Visible = true;
			cbo_assign_db_account_id.SelectionChangeCommitted += new System.EventHandler(cbo_assign_db_account_id_SelectionChangeCommitted);
			// 
			// cbo_assign_eu_account_id
			// 
			cbo_assign_eu_account_id.AllowDrop = true;
			cbo_assign_eu_account_id.BackColor = System.Drawing.SystemColors.Window;
			cbo_assign_eu_account_id.CausesValidation = true;
			cbo_assign_eu_account_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_assign_eu_account_id.Enabled = true;
			cbo_assign_eu_account_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_assign_eu_account_id.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_assign_eu_account_id.IntegralHeight = true;
			cbo_assign_eu_account_id.Location = new System.Drawing.Point(76, 166);
			cbo_assign_eu_account_id.Name = "cbo_assign_eu_account_id";
			cbo_assign_eu_account_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_assign_eu_account_id.Size = new System.Drawing.Size(60, 21);
			cbo_assign_eu_account_id.Sorted = false;
			cbo_assign_eu_account_id.TabIndex = 17;
			cbo_assign_eu_account_id.TabStop = true;
			cbo_assign_eu_account_id.Visible = true;
			cbo_assign_eu_account_id.SelectionChangeCommitted += new System.EventHandler(cbo_assign_eu_account_id_SelectionChangeCommitted);
			// 
			// cmd_Save_Assignments
			// 
			cmd_Save_Assignments.AllowDrop = true;
			cmd_Save_Assignments.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Assignments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Assignments.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Assignments.Location = new System.Drawing.Point(63, 238);
			cmd_Save_Assignments.Name = "cmd_Save_Assignments";
			cmd_Save_Assignments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Assignments.Size = new System.Drawing.Size(86, 22);
			cmd_Save_Assignments.TabIndex = 16;
			cmd_Save_Assignments.Text = "Save Changes";
			cmd_Save_Assignments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Assignments.UseVisualStyleBackColor = false;
			cmd_Save_Assignments.Click += new System.EventHandler(cmd_Save_Assignments_Click);
			cmd_Save_Assignments.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Save_Assignments_MouseUp);
			// 
			// txt_db_count
			// 
			txt_db_count.AcceptsReturn = true;
			txt_db_count.AllowDrop = true;
			txt_db_count.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_db_count.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_db_count.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_db_count.Enabled = false;
			txt_db_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_db_count.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_db_count.Location = new System.Drawing.Point(136, 115);
			txt_db_count.MaxLength = 0;
			txt_db_count.Name = "txt_db_count";
			txt_db_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_db_count.Size = new System.Drawing.Size(49, 19);
			txt_db_count.TabIndex = 15;
			// 
			// txt_eu_count
			// 
			txt_eu_count.AcceptsReturn = true;
			txt_eu_count.AllowDrop = true;
			txt_eu_count.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_eu_count.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_eu_count.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_eu_count.Enabled = false;
			txt_eu_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_eu_count.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_eu_count.Location = new System.Drawing.Point(136, 166);
			txt_eu_count.MaxLength = 0;
			txt_eu_count.Name = "txt_eu_count";
			txt_eu_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_eu_count.Size = new System.Drawing.Size(49, 19);
			txt_eu_count.TabIndex = 14;
			// 
			// _lbl_account_16
			// 
			_lbl_account_16.AllowDrop = true;
			_lbl_account_16.AutoSize = true;
			_lbl_account_16.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_16.Location = new System.Drawing.Point(88, 141);
			_lbl_account_16.MinimumSize = new System.Drawing.Size(44, 13);
			_lbl_account_16.Name = "_lbl_account_16";
			_lbl_account_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_16.Size = new System.Drawing.Size(44, 13);
			_lbl_account_16.TabIndex = 75;
			_lbl_account_16.Text = "Primary's:";
			_lbl_account_16.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_15
			// 
			_lbl_account_15.AllowDrop = true;
			_lbl_account_15.AutoSize = true;
			_lbl_account_15.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_15.Location = new System.Drawing.Point(88, 191);
			_lbl_account_15.MinimumSize = new System.Drawing.Size(44, 13);
			_lbl_account_15.Name = "_lbl_account_15";
			_lbl_account_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_15.Size = new System.Drawing.Size(44, 13);
			_lbl_account_15.TabIndex = 74;
			_lbl_account_15.Text = "Primary's:";
			_lbl_account_15.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_0
			// 
			_lbl_account_0.AllowDrop = true;
			_lbl_account_0.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_0.Location = new System.Drawing.Point(4, 115);
			_lbl_account_0.MinimumSize = new System.Drawing.Size(81, 17);
			_lbl_account_0.Name = "_lbl_account_0";
			_lbl_account_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_0.Size = new System.Drawing.Size(81, 17);
			_lbl_account_0.TabIndex = 24;
			_lbl_account_0.Text = "Dealer-Broker:";
			_lbl_account_0.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_7
			// 
			_lbl_account_7.AllowDrop = true;
			_lbl_account_7.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_7.Location = new System.Drawing.Point(80, 32);
			_lbl_account_7.MinimumSize = new System.Drawing.Size(57, 17);
			_lbl_account_7.Name = "_lbl_account_7";
			_lbl_account_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_7.Size = new System.Drawing.Size(57, 17);
			_lbl_account_7.TabIndex = 23;
			_lbl_account_7.Text = "Character:";
			_lbl_account_7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_7.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_8
			// 
			_lbl_account_8.AllowDrop = true;
			_lbl_account_8.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_8.Location = new System.Drawing.Point(75, 80);
			_lbl_account_8.MinimumSize = new System.Drawing.Size(62, 28);
			_lbl_account_8.Name = "_lbl_account_8";
			_lbl_account_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_8.Size = new System.Drawing.Size(62, 28);
			_lbl_account_8.TabIndex = 22;
			_lbl_account_8.Text = "Account Rep:";
			_lbl_account_8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_8.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_9
			// 
			_lbl_account_9.AllowDrop = true;
			_lbl_account_9.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_9.Location = new System.Drawing.Point(4, 166);
			_lbl_account_9.MinimumSize = new System.Drawing.Size(137, 17);
			_lbl_account_9.Name = "_lbl_account_9";
			_lbl_account_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_9.Size = new System.Drawing.Size(137, 17);
			_lbl_account_9.TabIndex = 21;
			_lbl_account_9.Text = "End User:";
			_lbl_account_9.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_10
			// 
			_lbl_account_10.AllowDrop = true;
			_lbl_account_10.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_10.Location = new System.Drawing.Point(128, 73);
			_lbl_account_10.MinimumSize = new System.Drawing.Size(65, 41);
			_lbl_account_10.Name = "_lbl_account_10";
			_lbl_account_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_10.Size = new System.Drawing.Size(65, 41);
			_lbl_account_10.TabIndex = 20;
			_lbl_account_10.Text = "# of Auto Assigned Companies";
			_lbl_account_10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_10.Click += new System.EventHandler(lbl_account_Click);
			// 
			// SSPanel1
			// 
			SSPanel1.AllowDrop = true;
			SSPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel1.Controls.Add(cbo_Account_ID);
			SSPanel1.Controls.Add(lst_Assign);
			SSPanel1.Controls.Add(lbl_account_character);
			SSPanel1.Controls.Add(lbl_eu_account_id);
			SSPanel1.Controls.Add(lbl_db_account_id);
			SSPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel1.Location = new System.Drawing.Point(598, 5);
			SSPanel1.Name = "SSPanel1";
			SSPanel1.Size = new System.Drawing.Size(206, 537);
			SSPanel1.TabIndex = 8;
			// 
			// cbo_Account_ID
			// 
			cbo_Account_ID.AllowDrop = true;
			cbo_Account_ID.BackColor = System.Drawing.SystemColors.Window;
			cbo_Account_ID.CausesValidation = true;
			cbo_Account_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_Account_ID.Enabled = true;
			cbo_Account_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Account_ID.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Account_ID.IntegralHeight = true;
			cbo_Account_ID.Location = new System.Drawing.Point(7, 512);
			cbo_Account_ID.Name = "cbo_Account_ID";
			cbo_Account_ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Account_ID.Size = new System.Drawing.Size(65, 21);
			cbo_Account_ID.Sorted = false;
			cbo_Account_ID.TabIndex = 29;
			cbo_Account_ID.TabStop = true;
			cbo_Account_ID.Visible = true;
			cbo_Account_ID.SelectionChangeCommitted += new System.EventHandler(cbo_account_id_SelectionChangeCommitted);
			// 
			// lst_Assign
			// 
			lst_Assign.AllowDrop = true;
			lst_Assign.BackColor = System.Drawing.SystemColors.Window;
			lst_Assign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Assign.CausesValidation = true;
			lst_Assign.Enabled = true;
			lst_Assign.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Assign.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Assign.IntegralHeight = true;
			lst_Assign.Location = new System.Drawing.Point(7, 73);
			lst_Assign.MultiColumn = false;
			lst_Assign.Name = "lst_Assign";
			lst_Assign.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Assign.Size = new System.Drawing.Size(193, 373);
			lst_Assign.Sorted = false;
			lst_Assign.TabIndex = 9;
			lst_Assign.TabStop = true;
			lst_Assign.Visible = true;
			lst_Assign.SelectedIndexChanged += new System.EventHandler(lst_Assign_SelectedIndexChanged);
			// 
			// lbl_account_character
			// 
			lbl_account_character.AllowDrop = true;
			lbl_account_character.BackColor = System.Drawing.Color.Transparent;
			lbl_account_character.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_account_character.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_account_character.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_account_character.Location = new System.Drawing.Point(7, 40);
			lbl_account_character.MinimumSize = new System.Drawing.Size(57, 33);
			lbl_account_character.Name = "lbl_account_character";
			lbl_account_character.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_account_character.Size = new System.Drawing.Size(57, 33);
			lbl_account_character.TabIndex = 12;
			lbl_account_character.Text = "Character Assignment";
			lbl_account_character.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lbl_account_character.Click += new System.EventHandler(lbl_account_character_Click);
			// 
			// lbl_eu_account_id
			// 
			lbl_eu_account_id.AllowDrop = true;
			lbl_eu_account_id.BackColor = System.Drawing.Color.Transparent;
			lbl_eu_account_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_eu_account_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_eu_account_id.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_eu_account_id.Location = new System.Drawing.Point(63, 32);
			lbl_eu_account_id.MinimumSize = new System.Drawing.Size(49, 41);
			lbl_eu_account_id.Name = "lbl_eu_account_id";
			lbl_eu_account_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_eu_account_id.Size = new System.Drawing.Size(49, 41);
			lbl_eu_account_id.TabIndex = 11;
			lbl_eu_account_id.Text = "End User Account ID";
			lbl_eu_account_id.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lbl_eu_account_id.Click += new System.EventHandler(lbl_eu_account_id_Click);
			// 
			// lbl_db_account_id
			// 
			lbl_db_account_id.AllowDrop = true;
			lbl_db_account_id.BackColor = System.Drawing.Color.Transparent;
			lbl_db_account_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_db_account_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_db_account_id.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_db_account_id.Location = new System.Drawing.Point(119, 16);
			lbl_db_account_id.MinimumSize = new System.Drawing.Size(49, 57);
			lbl_db_account_id.Name = "lbl_db_account_id";
			lbl_db_account_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_db_account_id.Size = new System.Drawing.Size(49, 57);
			lbl_db_account_id.TabIndex = 10;
			lbl_db_account_id.Text = "Dealer Broker Account ID";
			lbl_db_account_id.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lbl_db_account_id.Click += new System.EventHandler(lbl_db_account_id_Click);
			// 
			// SSPanel2
			// 
			SSPanel2.AllowDrop = true;
			SSPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel2.Controls.Add(cmbResearchType);
			SSPanel2.Controls.Add(cboTeams);
			SSPanel2.Controls.Add(ChkTeams);
			SSPanel2.Controls.Add(cbo_Account_Scope);
			SSPanel2.Controls.Add(txtAcctRep);
			SSPanel2.Controls.Add(txt_tot_AC_unused);
			SSPanel2.Controls.Add(txt_tot_prime_company);
			SSPanel2.Controls.Add(txt_tot_prime_auto_company);
			SSPanel2.Controls.Add(txt_tot_prime_man_company);
			SSPanel2.Controls.Add(txt_tot_man_aircraft);
			SSPanel2.Controls.Add(txt_tot_aut_aircraft);
			SSPanel2.Controls.Add(txt_tot_aut_comp);
			SSPanel2.Controls.Add(txt_tot_man_comp);
			SSPanel2.Controls.Add(txt_tot_comp);
			SSPanel2.Controls.Add(txt_tot_aircraft);
			SSPanel2.Controls.Add(_lbl_account_18);
			SSPanel2.Controls.Add(_lbl_account_17);
			SSPanel2.Controls.Add(Label4);
			SSPanel2.Controls.Add(_lbl_account_14);
			SSPanel2.Controls.Add(_lbl_account_13);
			SSPanel2.Controls.Add(_lbl_account_12);
			SSPanel2.Controls.Add(_lbl_account_11);
			SSPanel2.Controls.Add(_lbl_account_5);
			SSPanel2.Controls.Add(_lbl_account_2);
			SSPanel2.Controls.Add(_lbl_account_1);
			SSPanel2.Controls.Add(Label1);
			SSPanel2.Controls.Add(_lbl_account_6);
			SSPanel2.Controls.Add(_lbl_account_4);
			SSPanel2.Controls.Add(_lbl_account_3);
			SSPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel2.Location = new System.Drawing.Point(8, 5);
			SSPanel2.Name = "SSPanel2";
			SSPanel2.Size = new System.Drawing.Size(592, 555);
			SSPanel2.TabIndex = 1;
			// 
			// cmbResearchType
			// 
			cmbResearchType.AllowDrop = true;
			cmbResearchType.BackColor = System.Drawing.SystemColors.Window;
			cmbResearchType.CausesValidation = true;
			cmbResearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbResearchType.Enabled = true;
			cmbResearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbResearchType.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbResearchType.IntegralHeight = true;
			cmbResearchType.Location = new System.Drawing.Point(467, 51);
			cmbResearchType.Name = "cmbResearchType";
			cmbResearchType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbResearchType.Size = new System.Drawing.Size(121, 21);
			cmbResearchType.Sorted = false;
			cmbResearchType.TabIndex = 94;
			cmbResearchType.TabStop = true;
			cmbResearchType.Visible = false;
			cmbResearchType.SelectionChangeCommitted += new System.EventHandler(cmbResearchType_SelectionChangeCommitted);
			// 
			// cboTeams
			// 
			cboTeams.AllowDrop = true;
			cboTeams.BackColor = System.Drawing.SystemColors.Window;
			cboTeams.CausesValidation = true;
			cboTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboTeams.Enabled = true;
			cboTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboTeams.ForeColor = System.Drawing.SystemColors.WindowText;
			cboTeams.IntegralHeight = true;
			cboTeams.Location = new System.Drawing.Point(19, 3);
			cboTeams.Name = "cboTeams";
			cboTeams.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboTeams.Size = new System.Drawing.Size(53, 21);
			cboTeams.Sorted = false;
			cboTeams.TabIndex = 93;
			cboTeams.TabStop = true;
			cboTeams.Visible = false;
			// 
			// ChkTeams
			// 
			ChkTeams.AllowDrop = true;
			ChkTeams.Appearance = System.Windows.Forms.Appearance.Normal;
			ChkTeams.BackColor = System.Drawing.SystemColors.Control;
			ChkTeams.CausesValidation = true;
			ChkTeams.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ChkTeams.CheckState = System.Windows.Forms.CheckState.Unchecked;
			ChkTeams.Enabled = true;
			ChkTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ChkTeams.ForeColor = System.Drawing.SystemColors.ControlText;
			ChkTeams.Location = new System.Drawing.Point(81, 4);
			ChkTeams.Name = "ChkTeams";
			ChkTeams.RightToLeft = System.Windows.Forms.RightToLeft.No;
			ChkTeams.Size = new System.Drawing.Size(88, 13);
			ChkTeams.TabIndex = 92;
			ChkTeams.TabStop = true;
			ChkTeams.Text = "Show Teams";
			ChkTeams.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ChkTeams.Visible = true;
			ChkTeams.CheckStateChanged += new System.EventHandler(ChkTeams_CheckStateChanged);
			// 
			// cbo_Account_Scope
			// 
			cbo_Account_Scope.AllowDrop = true;
			cbo_Account_Scope.BackColor = System.Drawing.SystemColors.Window;
			cbo_Account_Scope.CausesValidation = true;
			cbo_Account_Scope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_Account_Scope.Enabled = true;
			cbo_Account_Scope.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Account_Scope.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Account_Scope.IntegralHeight = true;
			cbo_Account_Scope.Location = new System.Drawing.Point(468, 4);
			cbo_Account_Scope.Name = "cbo_Account_Scope";
			cbo_Account_Scope.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Account_Scope.Size = new System.Drawing.Size(119, 21);
			cbo_Account_Scope.Sorted = false;
			cbo_Account_Scope.TabIndex = 90;
			cbo_Account_Scope.TabStop = true;
			cbo_Account_Scope.Visible = false;
			cbo_Account_Scope.SelectionChangeCommitted += new System.EventHandler(cbo_Account_Scope_SelectionChangeCommitted);
			// 
			// txtAcctRep
			// 
			txtAcctRep.AcceptsReturn = true;
			txtAcctRep.AllowDrop = true;
			txtAcctRep.BackColor = System.Drawing.SystemColors.Window;
			txtAcctRep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtAcctRep.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtAcctRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtAcctRep.ForeColor = System.Drawing.SystemColors.WindowText;
			txtAcctRep.Location = new System.Drawing.Point(19, 3);
			txtAcctRep.MaxLength = 0;
			txtAcctRep.Name = "txtAcctRep";
			txtAcctRep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtAcctRep.Size = new System.Drawing.Size(53, 19);
			txtAcctRep.TabIndex = 83;
			txtAcctRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAcctRep_KeyPress);
			// 
			// txt_tot_AC_unused
			// 
			txt_tot_AC_unused.AcceptsReturn = true;
			txt_tot_AC_unused.AllowDrop = true;
			txt_tot_AC_unused.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_tot_AC_unused.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tot_AC_unused.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tot_AC_unused.Enabled = false;
			txt_tot_AC_unused.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tot_AC_unused.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tot_AC_unused.Location = new System.Drawing.Point(539, 516);
			txt_tot_AC_unused.MaxLength = 0;
			txt_tot_AC_unused.Name = "txt_tot_AC_unused";
			txt_tot_AC_unused.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tot_AC_unused.Size = new System.Drawing.Size(46, 19);
			txt_tot_AC_unused.TabIndex = 70;
			txt_tot_AC_unused.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_tot_prime_company
			// 
			txt_tot_prime_company.AcceptsReturn = true;
			txt_tot_prime_company.AllowDrop = true;
			txt_tot_prime_company.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_tot_prime_company.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tot_prime_company.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tot_prime_company.Enabled = false;
			txt_tot_prime_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tot_prime_company.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tot_prime_company.Location = new System.Drawing.Point(320, 516);
			txt_tot_prime_company.MaxLength = 0;
			txt_tot_prime_company.Name = "txt_tot_prime_company";
			txt_tot_prime_company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tot_prime_company.Size = new System.Drawing.Size(46, 19);
			txt_tot_prime_company.TabIndex = 66;
			txt_tot_prime_company.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_tot_prime_auto_company
			// 
			txt_tot_prime_auto_company.AcceptsReturn = true;
			txt_tot_prime_auto_company.AllowDrop = true;
			txt_tot_prime_auto_company.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_tot_prime_auto_company.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tot_prime_auto_company.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tot_prime_auto_company.Enabled = false;
			txt_tot_prime_auto_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tot_prime_auto_company.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tot_prime_auto_company.Location = new System.Drawing.Point(219, 516);
			txt_tot_prime_auto_company.MaxLength = 0;
			txt_tot_prime_auto_company.Name = "txt_tot_prime_auto_company";
			txt_tot_prime_auto_company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tot_prime_auto_company.Size = new System.Drawing.Size(49, 19);
			txt_tot_prime_auto_company.TabIndex = 65;
			txt_tot_prime_auto_company.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_tot_prime_man_company
			// 
			txt_tot_prime_man_company.AcceptsReturn = true;
			txt_tot_prime_man_company.AllowDrop = true;
			txt_tot_prime_man_company.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_tot_prime_man_company.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tot_prime_man_company.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tot_prime_man_company.Enabled = false;
			txt_tot_prime_man_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tot_prime_man_company.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tot_prime_man_company.Location = new System.Drawing.Point(271, 516);
			txt_tot_prime_man_company.MaxLength = 0;
			txt_tot_prime_man_company.Name = "txt_tot_prime_man_company";
			txt_tot_prime_man_company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tot_prime_man_company.Size = new System.Drawing.Size(48, 19);
			txt_tot_prime_man_company.TabIndex = 64;
			txt_tot_prime_man_company.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_tot_man_aircraft
			// 
			txt_tot_man_aircraft.AcceptsReturn = true;
			txt_tot_man_aircraft.AllowDrop = true;
			txt_tot_man_aircraft.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_tot_man_aircraft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tot_man_aircraft.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tot_man_aircraft.Enabled = false;
			txt_tot_man_aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tot_man_aircraft.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tot_man_aircraft.Location = new System.Drawing.Point(420, 516);
			txt_tot_man_aircraft.MaxLength = 0;
			txt_tot_man_aircraft.Name = "txt_tot_man_aircraft";
			txt_tot_man_aircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tot_man_aircraft.Size = new System.Drawing.Size(48, 19);
			txt_tot_man_aircraft.TabIndex = 47;
			txt_tot_man_aircraft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_tot_aut_aircraft
			// 
			txt_tot_aut_aircraft.AcceptsReturn = true;
			txt_tot_aut_aircraft.AllowDrop = true;
			txt_tot_aut_aircraft.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_tot_aut_aircraft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tot_aut_aircraft.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tot_aut_aircraft.Enabled = false;
			txt_tot_aut_aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tot_aut_aircraft.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tot_aut_aircraft.Location = new System.Drawing.Point(368, 516);
			txt_tot_aut_aircraft.MaxLength = 0;
			txt_tot_aut_aircraft.Name = "txt_tot_aut_aircraft";
			txt_tot_aut_aircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tot_aut_aircraft.Size = new System.Drawing.Size(49, 19);
			txt_tot_aut_aircraft.TabIndex = 46;
			txt_tot_aut_aircraft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_tot_aut_comp
			// 
			txt_tot_aut_comp.AcceptsReturn = true;
			txt_tot_aut_comp.AllowDrop = true;
			txt_tot_aut_comp.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_tot_aut_comp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tot_aut_comp.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tot_aut_comp.Enabled = false;
			txt_tot_aut_comp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tot_aut_comp.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tot_aut_comp.Location = new System.Drawing.Point(63, 516);
			txt_tot_aut_comp.MaxLength = 0;
			txt_tot_aut_comp.Name = "txt_tot_aut_comp";
			txt_tot_aut_comp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tot_aut_comp.Size = new System.Drawing.Size(50, 19);
			txt_tot_aut_comp.TabIndex = 43;
			txt_tot_aut_comp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_tot_man_comp
			// 
			txt_tot_man_comp.AcceptsReturn = true;
			txt_tot_man_comp.AllowDrop = true;
			txt_tot_man_comp.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_tot_man_comp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tot_man_comp.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tot_man_comp.Enabled = false;
			txt_tot_man_comp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tot_man_comp.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tot_man_comp.Location = new System.Drawing.Point(115, 516);
			txt_tot_man_comp.MaxLength = 0;
			txt_tot_man_comp.Name = "txt_tot_man_comp";
			txt_tot_man_comp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tot_man_comp.Size = new System.Drawing.Size(48, 19);
			txt_tot_man_comp.TabIndex = 42;
			txt_tot_man_comp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_tot_comp
			// 
			txt_tot_comp.AcceptsReturn = true;
			txt_tot_comp.AllowDrop = true;
			txt_tot_comp.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_tot_comp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tot_comp.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tot_comp.Enabled = false;
			txt_tot_comp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tot_comp.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tot_comp.Location = new System.Drawing.Point(166, 516);
			txt_tot_comp.MaxLength = 0;
			txt_tot_comp.Name = "txt_tot_comp";
			txt_tot_comp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tot_comp.Size = new System.Drawing.Size(52, 19);
			txt_tot_comp.TabIndex = 6;
			txt_tot_comp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_tot_aircraft
			// 
			txt_tot_aircraft.AcceptsReturn = true;
			txt_tot_aircraft.AllowDrop = true;
			txt_tot_aircraft.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_tot_aircraft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tot_aircraft.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tot_aircraft.Enabled = false;
			txt_tot_aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tot_aircraft.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tot_aircraft.Location = new System.Drawing.Point(471, 516);
			txt_tot_aircraft.MaxLength = 0;
			txt_tot_aircraft.Name = "txt_tot_aircraft";
			txt_tot_aircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tot_aircraft.Size = new System.Drawing.Size(46, 19);
			txt_tot_aircraft.TabIndex = 5;
			txt_tot_aircraft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _lbl_account_18
			// 
			_lbl_account_18.AllowDrop = true;
			_lbl_account_18.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_18.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			_lbl_account_18.Location = new System.Drawing.Point(375, 59);
			_lbl_account_18.MinimumSize = new System.Drawing.Size(88, 14);
			_lbl_account_18.Name = "_lbl_account_18";
			_lbl_account_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_18.Size = new System.Drawing.Size(88, 14);
			_lbl_account_18.TabIndex = 95;
			_lbl_account_18.Text = "Research Type:";
			_lbl_account_18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_18.Visible = false;
			_lbl_account_18.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_17
			// 
			_lbl_account_17.AllowDrop = true;
			_lbl_account_17.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_17.Location = new System.Drawing.Point(412, 7);
			_lbl_account_17.MinimumSize = new System.Drawing.Size(53, 14);
			_lbl_account_17.Name = "_lbl_account_17";
			_lbl_account_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_17.Size = new System.Drawing.Size(53, 14);
			_lbl_account_17.TabIndex = 91;
			_lbl_account_17.Text = "Scope:";
			_lbl_account_17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_17.Visible = false;
			_lbl_account_17.Click += new System.EventHandler(lbl_account_Click);
			// 
			// Label4
			// 
			Label4.AllowDrop = true;
			Label4.AutoSize = true;
			Label4.BackColor = System.Drawing.Color.Transparent;
			Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			Label4.Location = new System.Drawing.Point(524, 538);
			Label4.MinimumSize = new System.Drawing.Size(64, 13);
			Label4.Name = "Label4";
			Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label4.Size = new System.Drawing.Size(64, 13);
			Label4.TabIndex = 71;
			Label4.Text = "Not Used AC";
			Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lbl_account_14
			// 
			_lbl_account_14.AllowDrop = true;
			_lbl_account_14.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_14.Location = new System.Drawing.Point(321, 21);
			_lbl_account_14.MinimumSize = new System.Drawing.Size(37, 41);
			_lbl_account_14.Name = "_lbl_account_14";
			_lbl_account_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_14.Size = new System.Drawing.Size(37, 41);
			_lbl_account_14.TabIndex = 69;
			_lbl_account_14.Text = "Total Prime Comp";
			_lbl_account_14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_14.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_13
			// 
			_lbl_account_13.AllowDrop = true;
			_lbl_account_13.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_13.Location = new System.Drawing.Point(222, 21);
			_lbl_account_13.MinimumSize = new System.Drawing.Size(48, 52);
			_lbl_account_13.Name = "_lbl_account_13";
			_lbl_account_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_13.Size = new System.Drawing.Size(48, 52);
			_lbl_account_13.TabIndex = 68;
			_lbl_account_13.Text = "Total Prime Comp Auto";
			_lbl_account_13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_13.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_12
			// 
			_lbl_account_12.AllowDrop = true;
			_lbl_account_12.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_12.Location = new System.Drawing.Point(272, 21);
			_lbl_account_12.MinimumSize = new System.Drawing.Size(47, 54);
			_lbl_account_12.Name = "_lbl_account_12";
			_lbl_account_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_12.Size = new System.Drawing.Size(47, 54);
			_lbl_account_12.TabIndex = 67;
			_lbl_account_12.Text = "Total Prime Comp Manual";
			_lbl_account_12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_12.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_11
			// 
			_lbl_account_11.AllowDrop = true;
			_lbl_account_11.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_11.Location = new System.Drawing.Point(406, 26);
			_lbl_account_11.MinimumSize = new System.Drawing.Size(68, 33);
			_lbl_account_11.Name = "_lbl_account_11";
			_lbl_account_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_11.Size = new System.Drawing.Size(68, 33);
			_lbl_account_11.TabIndex = 45;
			_lbl_account_11.Text = "Total AC Manual";
			_lbl_account_11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_11.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_5
			// 
			_lbl_account_5.AllowDrop = true;
			_lbl_account_5.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_5.Location = new System.Drawing.Point(363, 29);
			_lbl_account_5.MinimumSize = new System.Drawing.Size(42, 32);
			_lbl_account_5.Name = "_lbl_account_5";
			_lbl_account_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_5.Size = new System.Drawing.Size(42, 32);
			_lbl_account_5.TabIndex = 44;
			_lbl_account_5.Text = "Total AC Auto";
			_lbl_account_5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_5.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_2
			// 
			_lbl_account_2.AllowDrop = true;
			_lbl_account_2.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_2.Location = new System.Drawing.Point(123, 20);
			_lbl_account_2.MinimumSize = new System.Drawing.Size(46, 53);
			_lbl_account_2.Name = "_lbl_account_2";
			_lbl_account_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_2.Size = new System.Drawing.Size(46, 53);
			_lbl_account_2.TabIndex = 41;
			_lbl_account_2.Text = "Total Comp Manual";
			_lbl_account_2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_2.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_1
			// 
			_lbl_account_1.AllowDrop = true;
			_lbl_account_1.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_1.Location = new System.Drawing.Point(73, 21);
			_lbl_account_1.MinimumSize = new System.Drawing.Size(48, 42);
			_lbl_account_1.Name = "_lbl_account_1";
			_lbl_account_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_1.Size = new System.Drawing.Size(48, 42);
			_lbl_account_1.TabIndex = 40;
			_lbl_account_1.Text = "Total Comp Auto";
			_lbl_account_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_1.Click += new System.EventHandler(lbl_account_Click);
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.AutoSize = true;
			Label1.BackColor = System.Drawing.Color.Transparent;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(20, 518);
			Label1.MinimumSize = new System.Drawing.Size(33, 13);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(33, 13);
			Label1.TabIndex = 7;
			Label1.Text = "Totals:";
			Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lbl_account_6
			// 
			_lbl_account_6.AllowDrop = true;
			_lbl_account_6.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_6.Location = new System.Drawing.Point(177, 21);
			_lbl_account_6.MinimumSize = new System.Drawing.Size(37, 41);
			_lbl_account_6.Name = "_lbl_account_6";
			_lbl_account_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_6.Size = new System.Drawing.Size(37, 41);
			_lbl_account_6.TabIndex = 4;
			_lbl_account_6.Text = "Total Comp";
			_lbl_account_6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_6.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_4
			// 
			_lbl_account_4.AllowDrop = true;
			_lbl_account_4.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_4.Location = new System.Drawing.Point(471, 27);
			_lbl_account_4.MinimumSize = new System.Drawing.Size(40, 33);
			_lbl_account_4.Name = "_lbl_account_4";
			_lbl_account_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_4.Size = new System.Drawing.Size(40, 33);
			_lbl_account_4.TabIndex = 3;
			_lbl_account_4.Text = "Total AC";
			_lbl_account_4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_4.Click += new System.EventHandler(lbl_account_Click);
			// 
			// _lbl_account_3
			// 
			_lbl_account_3.AllowDrop = true;
			_lbl_account_3.BackColor = System.Drawing.Color.Transparent;
			_lbl_account_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_account_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_account_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_account_3.Location = new System.Drawing.Point(21, 23);
			_lbl_account_3.MinimumSize = new System.Drawing.Size(49, 33);
			_lbl_account_3.Name = "_lbl_account_3";
			_lbl_account_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_account_3.Size = new System.Drawing.Size(49, 33);
			_lbl_account_3.TabIndex = 2;
			_lbl_account_3.Text = "Account ID";
			_lbl_account_3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_account_3.Click += new System.EventHandler(lbl_account_Click);
			// 
			// chkIncludeACCount
			// 
			chkIncludeACCount.AllowDrop = true;
			chkIncludeACCount.Appearance = System.Windows.Forms.Appearance.Normal;
			chkIncludeACCount.BackColor = System.Drawing.SystemColors.Control;
			chkIncludeACCount.CausesValidation = true;
			chkIncludeACCount.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIncludeACCount.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkIncludeACCount.Enabled = true;
			chkIncludeACCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkIncludeACCount.ForeColor = System.Drawing.SystemColors.ControlText;
			chkIncludeACCount.Location = new System.Drawing.Point(35, 561);
			chkIncludeACCount.Name = "chkIncludeACCount";
			chkIncludeACCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkIncludeACCount.Size = new System.Drawing.Size(229, 16);
			chkIncludeACCount.TabIndex = 58;
			chkIncludeACCount.TabStop = true;
			chkIncludeACCount.Text = "Include Aircraft Counts (Takes More Time)";
			chkIncludeACCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIncludeACCount.Visible = true;
			chkIncludeACCount.CheckStateChanged += new System.EventHandler(chkIncludeACCount_CheckStateChanged);
			// 
			// cmdAccountAssignRefresh
			// 
			cmdAccountAssignRefresh.AllowDrop = true;
			cmdAccountAssignRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdAccountAssignRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAccountAssignRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAccountAssignRefresh.Location = new System.Drawing.Point(267, 563);
			cmdAccountAssignRefresh.Name = "cmdAccountAssignRefresh";
			cmdAccountAssignRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAccountAssignRefresh.Size = new System.Drawing.Size(87, 20);
			cmdAccountAssignRefresh.TabIndex = 63;
			cmdAccountAssignRefresh.Text = "Refresh";
			cmdAccountAssignRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAccountAssignRefresh.UseVisualStyleBackColor = false;
			cmdAccountAssignRefresh.Click += new System.EventHandler(cmdAccountAssignRefresh_Click);
			cmdAccountAssignRefresh.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdAccountAssignRefresh_MouseUp);
			// 
			// frmAcctAssignments
			// 
			frmAcctAssignments.AllowDrop = true;
			frmAcctAssignments.BackColor = System.Drawing.SystemColors.Control;
			frmAcctAssignments.Controls.Add(pnl_AircraftDetail);
			frmAcctAssignments.Controls.Add(grdACSummary);
			frmAcctAssignments.Controls.Add(pnlAddNewAccountID);
			frmAcctAssignments.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmAcctAssignments.Enabled = true;
			frmAcctAssignments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmAcctAssignments.ForeColor = System.Drawing.SystemColors.ControlText;
			frmAcctAssignments.Location = new System.Drawing.Point(4, 76);
			frmAcctAssignments.Name = "frmAcctAssignments";
			frmAcctAssignments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmAcctAssignments.Size = new System.Drawing.Size(591, 441);
			frmAcctAssignments.TabIndex = 98;
			frmAcctAssignments.Visible = true;
			frmAcctAssignments.Click += new System.EventHandler(frmAcctAssignments_Click);
			// 
			// pnl_AircraftDetail
			// 
			pnl_AircraftDetail.AllowDrop = true;
			pnl_AircraftDetail.BackColor = System.Drawing.SystemColors.Control;
			pnl_AircraftDetail.Controls.Add(cmd_AircraftDetail);
			pnl_AircraftDetail.Controls.Add(GrdAircraftDetail);
			pnl_AircraftDetail.Controls.Add(lblTeam);
			pnl_AircraftDetail.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			pnl_AircraftDetail.Enabled = true;
			pnl_AircraftDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_AircraftDetail.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_AircraftDetail.Location = new System.Drawing.Point(202, 132);
			pnl_AircraftDetail.Name = "pnl_AircraftDetail";
			pnl_AircraftDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			pnl_AircraftDetail.Size = new System.Drawing.Size(223, 292);
			pnl_AircraftDetail.TabIndex = 100;
			pnl_AircraftDetail.Text = "Detail for Total Aircraft";
			pnl_AircraftDetail.Visible = false;
			pnl_AircraftDetail.Click += new System.EventHandler(pnl_AircraftDetail_Click);
			// 
			// cmd_AircraftDetail
			// 
			cmd_AircraftDetail.AllowDrop = true;
			cmd_AircraftDetail.BackColor = System.Drawing.SystemColors.Control;
			cmd_AircraftDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_AircraftDetail.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_AircraftDetail.Location = new System.Drawing.Point(174, 11);
			cmd_AircraftDetail.Name = "cmd_AircraftDetail";
			cmd_AircraftDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_AircraftDetail.Size = new System.Drawing.Size(36, 15);
			cmd_AircraftDetail.TabIndex = 101;
			cmd_AircraftDetail.Text = "Close";
			cmd_AircraftDetail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_AircraftDetail.UseVisualStyleBackColor = false;
			cmd_AircraftDetail.Click += new System.EventHandler(cmd_AircraftDetail_Click);
			cmd_AircraftDetail.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_AircraftDetail_MouseUp);
			// 
			// GrdAircraftDetail
			// 
			GrdAircraftDetail.AllowDrop = true;
			GrdAircraftDetail.AllowUserToAddRows = false;
			GrdAircraftDetail.AllowUserToDeleteRows = false;
			GrdAircraftDetail.AllowUserToResizeColumns = false;
			GrdAircraftDetail.AllowUserToResizeColumns = GrdAircraftDetail.ColumnHeadersVisible;
			GrdAircraftDetail.AllowUserToResizeRows = false;
			GrdAircraftDetail.AllowUserToResizeRows = false;
			GrdAircraftDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			GrdAircraftDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			GrdAircraftDetail.ColumnsCount = 2;
			GrdAircraftDetail.FixedColumns = 0;
			GrdAircraftDetail.FixedRows = 1;
			GrdAircraftDetail.Location = new System.Drawing.Point(10, 34);
			GrdAircraftDetail.Name = "GrdAircraftDetail";
			GrdAircraftDetail.ReadOnly = true;
			GrdAircraftDetail.RowsCount = 2;
			GrdAircraftDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			GrdAircraftDetail.ShowCellToolTips = false;
			GrdAircraftDetail.Size = new System.Drawing.Size(182, 249);
			GrdAircraftDetail.StandardTab = true;
			GrdAircraftDetail.TabIndex = 102;
			GrdAircraftDetail.DoubleClick += new System.EventHandler(GrdAircraftDetail_DoubleClick);
			// 
			// lblTeam
			// 
			lblTeam.AllowDrop = true;
			lblTeam.BackColor = System.Drawing.SystemColors.Control;
			lblTeam.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTeam.ForeColor = System.Drawing.SystemColors.ControlText;
			lblTeam.Location = new System.Drawing.Point(15, 17);
			lblTeam.MinimumSize = new System.Drawing.Size(114, 16);
			lblTeam.Name = "lblTeam";
			lblTeam.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblTeam.Size = new System.Drawing.Size(114, 16);
			lblTeam.TabIndex = 103;
			lblTeam.Text = "x";
			// 
			// grdACSummary
			// 
			grdACSummary.AllowDrop = true;
			grdACSummary.AllowUserToAddRows = false;
			grdACSummary.AllowUserToDeleteRows = false;
			grdACSummary.AllowUserToResizeColumns = false;
			grdACSummary.AllowUserToResizeRows = false;
			grdACSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdACSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdACSummary.ColumnsCount = 2;
			grdACSummary.FixedColumns = 1;
			grdACSummary.FixedRows = 1;
			grdACSummary.Location = new System.Drawing.Point(8, 12);
			grdACSummary.Name = "grdACSummary";
			grdACSummary.ReadOnly = true;
			grdACSummary.RowsCount = 2;
			grdACSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdACSummary.ShowCellToolTips = false;
			grdACSummary.Size = new System.Drawing.Size(576, 421);
			grdACSummary.StandardTab = true;
			grdACSummary.TabIndex = 99;
			grdACSummary.Click += new System.EventHandler(grdacsummary_Click);
			grdACSummary.DoubleClick += new System.EventHandler(grdacsummary_DoubleClick);
			// 
			// pnlAddNewAccountID
			// 
			pnlAddNewAccountID.AllowDrop = true;
			pnlAddNewAccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlAddNewAccountID.Controls.Add(txtNewAccountID);
			pnlAddNewAccountID.Controls.Add(cmdSaveNewAccountID);
			pnlAddNewAccountID.Controls.Add(cmdCancelNewAccountID);
			pnlAddNewAccountID.Controls.Add(cmdDeleteNewAccountID);
			pnlAddNewAccountID.Controls.Add(lblNewAccountID);
			pnlAddNewAccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlAddNewAccountID.Location = new System.Drawing.Point(338, 204);
			pnlAddNewAccountID.Name = "pnlAddNewAccountID";
			pnlAddNewAccountID.Size = new System.Drawing.Size(184, 96);
			pnlAddNewAccountID.TabIndex = 104;
			pnlAddNewAccountID.Visible = false;
			// 
			// txtNewAccountID
			// 
			txtNewAccountID.AcceptsReturn = true;
			txtNewAccountID.AllowDrop = true;
			txtNewAccountID.BackColor = System.Drawing.SystemColors.Window;
			txtNewAccountID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtNewAccountID.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtNewAccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtNewAccountID.ForeColor = System.Drawing.SystemColors.WindowText;
			txtNewAccountID.Location = new System.Drawing.Point(55, 24);
			txtNewAccountID.MaxLength = 4;
			txtNewAccountID.Name = "txtNewAccountID";
			txtNewAccountID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtNewAccountID.Size = new System.Drawing.Size(75, 19);
			txtNewAccountID.TabIndex = 108;
			txtNewAccountID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNewAccountID_KeyPress);
			// 
			// cmdSaveNewAccountID
			// 
			cmdSaveNewAccountID.AllowDrop = true;
			cmdSaveNewAccountID.BackColor = System.Drawing.SystemColors.Control;
			cmdSaveNewAccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSaveNewAccountID.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSaveNewAccountID.Location = new System.Drawing.Point(23, 47);
			cmdSaveNewAccountID.Name = "cmdSaveNewAccountID";
			cmdSaveNewAccountID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSaveNewAccountID.Size = new System.Drawing.Size(66, 19);
			cmdSaveNewAccountID.TabIndex = 107;
			cmdSaveNewAccountID.Text = "Save";
			cmdSaveNewAccountID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSaveNewAccountID.UseVisualStyleBackColor = false;
			cmdSaveNewAccountID.Click += new System.EventHandler(cmdSaveNewAccountID_Click);
			cmdSaveNewAccountID.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdSaveNewAccountID_MouseUp);
			// 
			// cmdCancelNewAccountID
			// 
			cmdCancelNewAccountID.AllowDrop = true;
			cmdCancelNewAccountID.BackColor = System.Drawing.SystemColors.Control;
			cmdCancelNewAccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancelNewAccountID.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancelNewAccountID.Location = new System.Drawing.Point(95, 47);
			cmdCancelNewAccountID.Name = "cmdCancelNewAccountID";
			cmdCancelNewAccountID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancelNewAccountID.Size = new System.Drawing.Size(66, 19);
			cmdCancelNewAccountID.TabIndex = 106;
			cmdCancelNewAccountID.Text = "Cancel";
			cmdCancelNewAccountID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancelNewAccountID.UseVisualStyleBackColor = false;
			cmdCancelNewAccountID.Click += new System.EventHandler(cmdCancelNewAccountID_Click);
			cmdCancelNewAccountID.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdCancelNewAccountID_MouseUp);
			// 
			// cmdDeleteNewAccountID
			// 
			cmdDeleteNewAccountID.AllowDrop = true;
			cmdDeleteNewAccountID.BackColor = System.Drawing.SystemColors.Control;
			cmdDeleteNewAccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDeleteNewAccountID.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDeleteNewAccountID.Location = new System.Drawing.Point(65, 68);
			cmdDeleteNewAccountID.Name = "cmdDeleteNewAccountID";
			cmdDeleteNewAccountID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDeleteNewAccountID.Size = new System.Drawing.Size(58, 21);
			cmdDeleteNewAccountID.TabIndex = 105;
			cmdDeleteNewAccountID.Text = "Delete";
			cmdDeleteNewAccountID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDeleteNewAccountID.UseVisualStyleBackColor = false;
			cmdDeleteNewAccountID.Click += new System.EventHandler(cmdDeleteNewAccountID_Click);
			cmdDeleteNewAccountID.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdDeleteNewAccountID_MouseUp);
			// 
			// lblNewAccountID
			// 
			lblNewAccountID.AllowDrop = true;
			lblNewAccountID.AutoSize = true;
			lblNewAccountID.BackColor = System.Drawing.SystemColors.Control;
			lblNewAccountID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblNewAccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblNewAccountID.ForeColor = System.Drawing.SystemColors.ControlText;
			lblNewAccountID.Location = new System.Drawing.Point(55, 11);
			lblNewAccountID.MinimumSize = new System.Drawing.Size(36, 13);
			lblNewAccountID.Name = "lblNewAccountID";
			lblNewAccountID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblNewAccountID.Size = new System.Drawing.Size(36, 13);
			lblNewAccountID.TabIndex = 109;
			lblNewAccountID.Text = "New ID";
			// 
			// _tab_Accounts_TabPage1
			// 
			_tab_Accounts_TabPage1.Controls.Add(lblUnassigned);
			_tab_Accounts_TabPage1.Controls.Add(Label2);
			_tab_Accounts_TabPage1.Controls.Add(Label3);
			_tab_Accounts_TabPage1.Controls.Add(txt_FoundCount);
			_tab_Accounts_TabPage1.Controls.Add(txt_RecCount);
			_tab_Accounts_TabPage1.Controls.Add(cmd_Analyze);
			_tab_Accounts_TabPage1.Controls.Add(lst_Unassigned);
			_tab_Accounts_TabPage1.Controls.Add(lst_dup);
			_tab_Accounts_TabPage1.Controls.Add(cmd_FindDup);
			_tab_Accounts_TabPage1.Controls.Add(txt_message);
			_tab_Accounts_TabPage1.Controls.Add(txtTotalUnAssigned);
			_tab_Accounts_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Accounts_TabPage1.Text = "Un Assigned Aircraft";
			// 
			// lblUnassigned
			// 
			lblUnassigned.AllowDrop = true;
			lblUnassigned.BackColor = System.Drawing.SystemColors.Control;
			lblUnassigned.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblUnassigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblUnassigned.ForeColor = System.Drawing.SystemColors.ControlText;
			lblUnassigned.Location = new System.Drawing.Point(335, 9);
			lblUnassigned.MinimumSize = new System.Drawing.Size(63, 27);
			lblUnassigned.Name = "lblUnassigned";
			lblUnassigned.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblUnassigned.Size = new System.Drawing.Size(63, 27);
			lblUnassigned.TabIndex = 34;
			lblUnassigned.Text = "UnAssigned        Total";
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.AutoSize = true;
			Label2.BackColor = System.Drawing.SystemColors.Control;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			Label2.Location = new System.Drawing.Point(418, 22);
			Label2.MinimumSize = new System.Drawing.Size(34, 13);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(34, 13);
			Label2.TabIndex = 36;
			Label2.Text = "Current";
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.AutoSize = true;
			Label3.BackColor = System.Drawing.SystemColors.Control;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(505, 22);
			Label3.MinimumSize = new System.Drawing.Size(24, 13);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(24, 13);
			Label3.TabIndex = 37;
			Label3.Text = "Total";
			// 
			// txt_FoundCount
			// 
			txt_FoundCount.AcceptsReturn = true;
			txt_FoundCount.AllowDrop = true;
			txt_FoundCount.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_FoundCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_FoundCount.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_FoundCount.Enabled = false;
			txt_FoundCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_FoundCount.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_FoundCount.Location = new System.Drawing.Point(335, 37);
			txt_FoundCount.MaxLength = 0;
			txt_FoundCount.Name = "txt_FoundCount";
			txt_FoundCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_FoundCount.Size = new System.Drawing.Size(57, 19);
			txt_FoundCount.TabIndex = 25;
			// 
			// txt_RecCount
			// 
			txt_RecCount.AcceptsReturn = true;
			txt_RecCount.AllowDrop = true;
			txt_RecCount.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_RecCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_RecCount.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_RecCount.Enabled = false;
			txt_RecCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_RecCount.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_RecCount.Location = new System.Drawing.Point(408, 37);
			txt_RecCount.MaxLength = 0;
			txt_RecCount.Name = "txt_RecCount";
			txt_RecCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_RecCount.Size = new System.Drawing.Size(57, 19);
			txt_RecCount.TabIndex = 26;
			// 
			// cmd_Analyze
			// 
			cmd_Analyze.AllowDrop = true;
			cmd_Analyze.BackColor = System.Drawing.SystemColors.Control;
			cmd_Analyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Analyze.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Analyze.Location = new System.Drawing.Point(32, 31);
			cmd_Analyze.Name = "cmd_Analyze";
			cmd_Analyze.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Analyze.Size = new System.Drawing.Size(249, 25);
			cmd_Analyze.TabIndex = 27;
			cmd_Analyze.Text = "Search for Unassigned Aircraft";
			cmd_Analyze.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Analyze.UseVisualStyleBackColor = false;
			cmd_Analyze.Click += new System.EventHandler(cmd_Analyze_Click);
			cmd_Analyze.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Analyze_MouseUp);
			// 
			// lst_Unassigned
			// 
			lst_Unassigned.AllowDrop = true;
			lst_Unassigned.BackColor = System.Drawing.SystemColors.Window;
			lst_Unassigned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Unassigned.CausesValidation = true;
			lst_Unassigned.Enabled = true;
			lst_Unassigned.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Unassigned.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Unassigned.IntegralHeight = true;
			lst_Unassigned.Location = new System.Drawing.Point(32, 67);
			lst_Unassigned.MultiColumn = false;
			lst_Unassigned.Name = "lst_Unassigned";
			lst_Unassigned.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Unassigned.Size = new System.Drawing.Size(521, 467);
			lst_Unassigned.Sorted = false;
			lst_Unassigned.TabIndex = 28;
			lst_Unassigned.TabStop = true;
			lst_Unassigned.Visible = true;
			lst_Unassigned.DoubleClick += new System.EventHandler(lst_Unassigned_DoubleClick);
			// 
			// lst_dup
			// 
			lst_dup.AllowDrop = true;
			lst_dup.BackColor = System.Drawing.SystemColors.Window;
			lst_dup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_dup.CausesValidation = true;
			lst_dup.Enabled = true;
			lst_dup.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_dup.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_dup.IntegralHeight = true;
			lst_dup.Location = new System.Drawing.Point(584, 67);
			lst_dup.MultiColumn = false;
			lst_dup.Name = "lst_dup";
			lst_dup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_dup.Size = new System.Drawing.Size(393, 467);
			lst_dup.Sorted = false;
			lst_dup.TabIndex = 31;
			lst_dup.TabStop = true;
			lst_dup.Visible = true;
			// 
			// cmd_FindDup
			// 
			cmd_FindDup.AllowDrop = true;
			cmd_FindDup.BackColor = System.Drawing.SystemColors.Control;
			cmd_FindDup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_FindDup.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_FindDup.Location = new System.Drawing.Point(584, 31);
			cmd_FindDup.Name = "cmd_FindDup";
			cmd_FindDup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_FindDup.Size = new System.Drawing.Size(249, 25);
			cmd_FindDup.TabIndex = 32;
			cmd_FindDup.Text = "Find Dup Aircraft POCS";
			cmd_FindDup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_FindDup.UseVisualStyleBackColor = false;
			cmd_FindDup.Click += new System.EventHandler(cmd_FindDup_Click);
			cmd_FindDup.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_FindDup_MouseUp);
			// 
			// txt_message
			// 
			txt_message.AcceptsReturn = true;
			txt_message.AllowDrop = true;
			txt_message.BackColor = System.Drawing.SystemColors.Window;
			txt_message.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_message.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_message.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_message.Location = new System.Drawing.Point(584, 8);
			txt_message.MaxLength = 0;
			txt_message.Name = "txt_message";
			txt_message.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_message.Size = new System.Drawing.Size(249, 19);
			txt_message.TabIndex = 33;
			// 
			// txtTotalUnAssigned
			// 
			txtTotalUnAssigned.AcceptsReturn = true;
			txtTotalUnAssigned.AllowDrop = true;
			txtTotalUnAssigned.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txtTotalUnAssigned.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtTotalUnAssigned.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtTotalUnAssigned.Enabled = false;
			txtTotalUnAssigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtTotalUnAssigned.ForeColor = System.Drawing.SystemColors.WindowText;
			txtTotalUnAssigned.Location = new System.Drawing.Point(492, 37);
			txtTotalUnAssigned.MaxLength = 0;
			txtTotalUnAssigned.Name = "txtTotalUnAssigned";
			txtTotalUnAssigned.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtTotalUnAssigned.Size = new System.Drawing.Size(57, 19);
			txtTotalUnAssigned.TabIndex = 35;
			// 
			// _tab_Accounts_TabPage2
			// 
			_tab_Accounts_TabPage2.Controls.Add(wbAcctRepActivity);
			_tab_Accounts_TabPage2.Controls.Add(grdSchedule);
			_tab_Accounts_TabPage2.Controls.Add(chkAllActivityReports);
			_tab_Accounts_TabPage2.Controls.Add(txt_primaryneedconfirm);
			_tab_Accounts_TabPage2.Controls.Add(txt_end_time);
			_tab_Accounts_TabPage2.Controls.Add(txt_start_time);
			_tab_Accounts_TabPage2.Controls.Add(cbo_days_confirm);
			_tab_Accounts_TabPage2.Controls.Add(txt_primaryconfirmed);
			_tab_Accounts_TabPage2.Controls.Add(txt_primarycompanies);
			_tab_Accounts_TabPage2.Controls.Add(txt_totalnonconfirmedcompanies);
			_tab_Accounts_TabPage2.Controls.Add(txt_totalconfirmedcompanies);
			_tab_Accounts_TabPage2.Controls.Add(txt_totalactivecompanies);
			_tab_Accounts_TabPage2.Controls.Add(cmd_SummarizeConfirms);
			_tab_Accounts_TabPage2.Controls.Add(txtDate2);
			_tab_Accounts_TabPage2.Controls.Add(txtDate1);
			_tab_Accounts_TabPage2.Controls.Add(optAccountRepActivity);
			_tab_Accounts_TabPage2.Controls.Add(optCallbackSchedule);
			_tab_Accounts_TabPage2.Controls.Add(lstCompany);
			_tab_Accounts_TabPage2.Controls.Add(chkIgnoreSchedDate2);
			_tab_Accounts_TabPage2.Controls.Add(chkIgnoreSchedDate1);
			_tab_Accounts_TabPage2.Controls.Add(lstAcctRep);
			_tab_Accounts_TabPage2.Controls.Add(cmdScheduleGo);
			_tab_Accounts_TabPage2.Controls.Add(MonthView2);
			_tab_Accounts_TabPage2.Controls.Add(MonthView1);
			_tab_Accounts_TabPage2.Controls.Add(Label6);
			_tab_Accounts_TabPage2.Controls.Add(Label5);
			_tab_Accounts_TabPage2.Controls.Add(lblGrandTotal);
			_tab_Accounts_TabPage2.Controls.Add(lblCompany);
			_tab_Accounts_TabPage2.Controls.Add(lblTo);
			_tab_Accounts_TabPage2.Controls.Add(lblFrom);
			_tab_Accounts_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Accounts_TabPage2.Text = "Account Schedule";
			// 
			// wbAcctRepActivity
			// 
			wbAcctRepActivity.AllowWebBrowserDrop = true;
			wbAcctRepActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			wbAcctRepActivity.Location = new System.Drawing.Point(128, 220);
			wbAcctRepActivity.Name = "wbAcctRepActivity";
			wbAcctRepActivity.Size = new System.Drawing.Size(865, 355);
			wbAcctRepActivity.TabIndex = 97;
			wbAcctRepActivity.Visible = false;
			// 
			// grdSchedule
			// 
			grdSchedule.AllowDrop = true;
			grdSchedule.AllowUserToAddRows = false;
			grdSchedule.AllowUserToDeleteRows = false;
			grdSchedule.AllowUserToResizeColumns = false;
			grdSchedule.AllowUserToResizeColumns = grdSchedule.ColumnHeadersVisible;
			grdSchedule.AllowUserToResizeRows = false;
			grdSchedule.AllowUserToResizeRows = grdSchedule.RowHeadersVisible;
			grdSchedule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdSchedule.ColumnsCount = 2;
			grdSchedule.FixedColumns = 1;
			grdSchedule.FixedRows = 1;
			grdSchedule.Location = new System.Drawing.Point(128, 222);
			grdSchedule.Name = "grdSchedule";
			grdSchedule.ReadOnly = true;
			grdSchedule.RowsCount = 2;
			grdSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grdSchedule.ShowCellToolTips = false;
			grdSchedule.Size = new System.Drawing.Size(864, 352);
			grdSchedule.StandardTab = true;
			grdSchedule.TabIndex = 49;
			grdSchedule.Click += new System.EventHandler(grdSchedule_Click);
			grdSchedule.DoubleClick += new System.EventHandler(grdSchedule_DoubleClick);
			// 
			// chkAllActivityReports
			// 
			chkAllActivityReports.AllowDrop = true;
			chkAllActivityReports.Appearance = System.Windows.Forms.Appearance.Normal;
			chkAllActivityReports.BackColor = System.Drawing.SystemColors.Control;
			chkAllActivityReports.CausesValidation = true;
			chkAllActivityReports.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAllActivityReports.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkAllActivityReports.Enabled = false;
			chkAllActivityReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkAllActivityReports.ForeColor = System.Drawing.SystemColors.ControlText;
			chkAllActivityReports.Location = new System.Drawing.Point(861, 196);
			chkAllActivityReports.Name = "chkAllActivityReports";
			chkAllActivityReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkAllActivityReports.Size = new System.Drawing.Size(84, 13);
			chkAllActivityReports.TabIndex = 96;
			chkAllActivityReports.TabStop = true;
			chkAllActivityReports.Text = "All Reports";
			chkAllActivityReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAllActivityReports.Visible = true;
			// 
			// txt_primaryneedconfirm
			// 
			txt_primaryneedconfirm.AcceptsReturn = true;
			txt_primaryneedconfirm.AllowDrop = true;
			txt_primaryneedconfirm.BackColor = System.Drawing.SystemColors.ScrollBar;
			txt_primaryneedconfirm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_primaryneedconfirm.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_primaryneedconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_primaryneedconfirm.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_primaryneedconfirm.Location = new System.Drawing.Point(472, 172);
			txt_primaryneedconfirm.MaxLength = 0;
			txt_primaryneedconfirm.Name = "txt_primaryneedconfirm";
			txt_primaryneedconfirm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_primaryneedconfirm.Size = new System.Drawing.Size(169, 19);
			txt_primaryneedconfirm.TabIndex = 89;
			// 
			// txt_end_time
			// 
			txt_end_time.AcceptsReturn = true;
			txt_end_time.AllowDrop = true;
			txt_end_time.BackColor = System.Drawing.SystemColors.Window;
			txt_end_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_end_time.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_end_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_end_time.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_end_time.Location = new System.Drawing.Point(344, 175);
			txt_end_time.MaxLength = 0;
			txt_end_time.Name = "txt_end_time";
			txt_end_time.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_end_time.Size = new System.Drawing.Size(57, 19);
			txt_end_time.TabIndex = 88;
			// 
			// txt_start_time
			// 
			txt_start_time.AcceptsReturn = true;
			txt_start_time.AllowDrop = true;
			txt_start_time.BackColor = System.Drawing.SystemColors.Window;
			txt_start_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_start_time.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_start_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_start_time.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_start_time.Location = new System.Drawing.Point(120, 175);
			txt_start_time.MaxLength = 0;
			txt_start_time.Name = "txt_start_time";
			txt_start_time.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_start_time.Size = new System.Drawing.Size(57, 19);
			txt_start_time.TabIndex = 87;
			// 
			// cbo_days_confirm
			// 
			cbo_days_confirm.AllowDrop = true;
			cbo_days_confirm.BackColor = System.Drawing.SystemColors.Window;
			cbo_days_confirm.CausesValidation = true;
			cbo_days_confirm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_days_confirm.Enabled = true;
			cbo_days_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_days_confirm.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_days_confirm.IntegralHeight = true;
			cbo_days_confirm.Location = new System.Drawing.Point(504, 28);
			cbo_days_confirm.Name = "cbo_days_confirm";
			cbo_days_confirm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_days_confirm.Size = new System.Drawing.Size(49, 21);
			cbo_days_confirm.Sorted = false;
			cbo_days_confirm.TabIndex = 84;
			cbo_days_confirm.TabStop = true;
			cbo_days_confirm.Text = "Combo1";
			cbo_days_confirm.Visible = true;
			// 
			// txt_primaryconfirmed
			// 
			txt_primaryconfirmed.AcceptsReturn = true;
			txt_primaryconfirmed.AllowDrop = true;
			txt_primaryconfirmed.BackColor = System.Drawing.SystemColors.ScrollBar;
			txt_primaryconfirmed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_primaryconfirmed.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_primaryconfirmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_primaryconfirmed.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_primaryconfirmed.Location = new System.Drawing.Point(472, 148);
			txt_primaryconfirmed.MaxLength = 0;
			txt_primaryconfirmed.Name = "txt_primaryconfirmed";
			txt_primaryconfirmed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_primaryconfirmed.Size = new System.Drawing.Size(169, 19);
			txt_primaryconfirmed.TabIndex = 82;
			// 
			// txt_primarycompanies
			// 
			txt_primarycompanies.AcceptsReturn = true;
			txt_primarycompanies.AllowDrop = true;
			txt_primarycompanies.BackColor = System.Drawing.SystemColors.ScrollBar;
			txt_primarycompanies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_primarycompanies.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_primarycompanies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_primarycompanies.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_primarycompanies.Location = new System.Drawing.Point(472, 124);
			txt_primarycompanies.MaxLength = 0;
			txt_primarycompanies.Name = "txt_primarycompanies";
			txt_primarycompanies.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_primarycompanies.Size = new System.Drawing.Size(169, 19);
			txt_primarycompanies.TabIndex = 81;
			// 
			// txt_totalnonconfirmedcompanies
			// 
			txt_totalnonconfirmedcompanies.AcceptsReturn = true;
			txt_totalnonconfirmedcompanies.AllowDrop = true;
			txt_totalnonconfirmedcompanies.BackColor = System.Drawing.SystemColors.ScrollBar;
			txt_totalnonconfirmedcompanies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_totalnonconfirmedcompanies.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_totalnonconfirmedcompanies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_totalnonconfirmedcompanies.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_totalnonconfirmedcompanies.Location = new System.Drawing.Point(472, 100);
			txt_totalnonconfirmedcompanies.MaxLength = 0;
			txt_totalnonconfirmedcompanies.Name = "txt_totalnonconfirmedcompanies";
			txt_totalnonconfirmedcompanies.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_totalnonconfirmedcompanies.Size = new System.Drawing.Size(169, 19);
			txt_totalnonconfirmedcompanies.TabIndex = 80;
			// 
			// txt_totalconfirmedcompanies
			// 
			txt_totalconfirmedcompanies.AcceptsReturn = true;
			txt_totalconfirmedcompanies.AllowDrop = true;
			txt_totalconfirmedcompanies.BackColor = System.Drawing.SystemColors.ScrollBar;
			txt_totalconfirmedcompanies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_totalconfirmedcompanies.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_totalconfirmedcompanies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_totalconfirmedcompanies.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_totalconfirmedcompanies.Location = new System.Drawing.Point(472, 76);
			txt_totalconfirmedcompanies.MaxLength = 0;
			txt_totalconfirmedcompanies.Name = "txt_totalconfirmedcompanies";
			txt_totalconfirmedcompanies.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_totalconfirmedcompanies.Size = new System.Drawing.Size(169, 19);
			txt_totalconfirmedcompanies.TabIndex = 79;
			// 
			// txt_totalactivecompanies
			// 
			txt_totalactivecompanies.AcceptsReturn = true;
			txt_totalactivecompanies.AllowDrop = true;
			txt_totalactivecompanies.BackColor = System.Drawing.SystemColors.ScrollBar;
			txt_totalactivecompanies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_totalactivecompanies.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_totalactivecompanies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_totalactivecompanies.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_totalactivecompanies.Location = new System.Drawing.Point(472, 52);
			txt_totalactivecompanies.MaxLength = 0;
			txt_totalactivecompanies.Name = "txt_totalactivecompanies";
			txt_totalactivecompanies.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_totalactivecompanies.Size = new System.Drawing.Size(169, 19);
			txt_totalactivecompanies.TabIndex = 78;
			// 
			// cmd_SummarizeConfirms
			// 
			cmd_SummarizeConfirms.AllowDrop = true;
			cmd_SummarizeConfirms.BackColor = System.Drawing.SystemColors.Control;
			cmd_SummarizeConfirms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_SummarizeConfirms.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_SummarizeConfirms.Location = new System.Drawing.Point(472, 4);
			cmd_SummarizeConfirms.Name = "cmd_SummarizeConfirms";
			cmd_SummarizeConfirms.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_SummarizeConfirms.Size = new System.Drawing.Size(117, 23);
			cmd_SummarizeConfirms.TabIndex = 77;
			cmd_SummarizeConfirms.Text = "Color Confirm Status";
			cmd_SummarizeConfirms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_SummarizeConfirms.UseVisualStyleBackColor = false;
			cmd_SummarizeConfirms.Click += new System.EventHandler(cmd_SummarizeConfirms_Click);
			cmd_SummarizeConfirms.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_SummarizeConfirms_MouseUp);
			// 
			// txtDate2
			// 
			txtDate2.AcceptsReturn = true;
			txtDate2.AllowDrop = true;
			txtDate2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txtDate2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtDate2.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtDate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtDate2.ForeColor = System.Drawing.SystemColors.WindowText;
			txtDate2.Location = new System.Drawing.Point(269, 175);
			txtDate2.MaxLength = 0;
			txtDate2.Name = "txtDate2";
			txtDate2.ReadOnly = true;
			txtDate2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtDate2.Size = new System.Drawing.Size(74, 19);
			txtDate2.TabIndex = 62;
			// 
			// txtDate1
			// 
			txtDate1.AcceptsReturn = true;
			txtDate1.AllowDrop = true;
			txtDate1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txtDate1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtDate1.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtDate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtDate1.ForeColor = System.Drawing.SystemColors.WindowText;
			txtDate1.Location = new System.Drawing.Point(44, 175);
			txtDate1.MaxLength = 0;
			txtDate1.Name = "txtDate1";
			txtDate1.ReadOnly = true;
			txtDate1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtDate1.Size = new System.Drawing.Size(71, 19);
			txtDate1.TabIndex = 61;
			// 
			// optAccountRepActivity
			// 
			optAccountRepActivity.AllowDrop = true;
			optAccountRepActivity.BackColor = System.Drawing.SystemColors.Control;
			optAccountRepActivity.CausesValidation = true;
			optAccountRepActivity.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optAccountRepActivity.Checked = false;
			optAccountRepActivity.Enabled = true;
			optAccountRepActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optAccountRepActivity.ForeColor = System.Drawing.SystemColors.ControlText;
			optAccountRepActivity.Location = new System.Drawing.Point(720, 196);
			optAccountRepActivity.Name = "optAccountRepActivity";
			optAccountRepActivity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optAccountRepActivity.Size = new System.Drawing.Size(124, 13);
			optAccountRepActivity.TabIndex = 60;
			optAccountRepActivity.TabStop = true;
			optAccountRepActivity.Text = "Account Rep Activity";
			optAccountRepActivity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optAccountRepActivity.Visible = true;
			optAccountRepActivity.CheckedChanged += new System.EventHandler(optAccountRepActivity_CheckedChanged);
			// 
			// optCallbackSchedule
			// 
			optCallbackSchedule.AllowDrop = true;
			optCallbackSchedule.BackColor = System.Drawing.SystemColors.Control;
			optCallbackSchedule.CausesValidation = true;
			optCallbackSchedule.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optCallbackSchedule.Checked = true;
			optCallbackSchedule.Enabled = true;
			optCallbackSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optCallbackSchedule.ForeColor = System.Drawing.SystemColors.ControlText;
			optCallbackSchedule.Location = new System.Drawing.Point(600, 196);
			optCallbackSchedule.Name = "optCallbackSchedule";
			optCallbackSchedule.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optCallbackSchedule.Size = new System.Drawing.Size(115, 13);
			optCallbackSchedule.TabIndex = 59;
			optCallbackSchedule.TabStop = true;
			optCallbackSchedule.Text = "Callback Schedule";
			optCallbackSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optCallbackSchedule.Visible = true;
			optCallbackSchedule.CheckedChanged += new System.EventHandler(optCallbackSchedule_CheckedChanged);
			// 
			// lstCompany
			// 
			lstCompany.AllowDrop = true;
			lstCompany.BackColor = System.Drawing.SystemColors.Window;
			lstCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstCompany.CausesValidation = true;
			lstCompany.Enabled = true;
			lstCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstCompany.ForeColor = System.Drawing.SystemColors.WindowText;
			lstCompany.IntegralHeight = true;
			lstCompany.Location = new System.Drawing.Point(649, 31);
			lstCompany.MultiColumn = false;
			lstCompany.Name = "lstCompany";
			lstCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstCompany.Size = new System.Drawing.Size(328, 109);
			lstCompany.Sorted = false;
			lstCompany.TabIndex = 56;
			lstCompany.TabStop = true;
			lstCompany.Visible = false;
			lstCompany.DoubleClick += new System.EventHandler(lstCompany_DoubleClick);
			// 
			// chkIgnoreSchedDate2
			// 
			chkIgnoreSchedDate2.AllowDrop = true;
			chkIgnoreSchedDate2.Appearance = System.Windows.Forms.Appearance.Normal;
			chkIgnoreSchedDate2.BackColor = System.Drawing.SystemColors.Control;
			chkIgnoreSchedDate2.CausesValidation = true;
			chkIgnoreSchedDate2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIgnoreSchedDate2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkIgnoreSchedDate2.Enabled = true;
			chkIgnoreSchedDate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkIgnoreSchedDate2.ForeColor = System.Drawing.SystemColors.ControlText;
			chkIgnoreSchedDate2.Location = new System.Drawing.Point(408, 178);
			chkIgnoreSchedDate2.Name = "chkIgnoreSchedDate2";
			chkIgnoreSchedDate2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkIgnoreSchedDate2.Size = new System.Drawing.Size(54, 13);
			chkIgnoreSchedDate2.TabIndex = 53;
			chkIgnoreSchedDate2.TabStop = true;
			chkIgnoreSchedDate2.Text = "Ignore";
			chkIgnoreSchedDate2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIgnoreSchedDate2.Visible = true;
			// 
			// chkIgnoreSchedDate1
			// 
			chkIgnoreSchedDate1.AllowDrop = true;
			chkIgnoreSchedDate1.Appearance = System.Windows.Forms.Appearance.Normal;
			chkIgnoreSchedDate1.BackColor = System.Drawing.SystemColors.Control;
			chkIgnoreSchedDate1.CausesValidation = true;
			chkIgnoreSchedDate1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIgnoreSchedDate1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkIgnoreSchedDate1.Enabled = true;
			chkIgnoreSchedDate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkIgnoreSchedDate1.ForeColor = System.Drawing.SystemColors.ControlText;
			chkIgnoreSchedDate1.Location = new System.Drawing.Point(183, 178);
			chkIgnoreSchedDate1.Name = "chkIgnoreSchedDate1";
			chkIgnoreSchedDate1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkIgnoreSchedDate1.Size = new System.Drawing.Size(50, 13);
			chkIgnoreSchedDate1.TabIndex = 52;
			chkIgnoreSchedDate1.TabStop = true;
			chkIgnoreSchedDate1.Text = "Ignore";
			chkIgnoreSchedDate1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIgnoreSchedDate1.Visible = true;
			// 
			// lstAcctRep
			// 
			lstAcctRep.AllowDrop = true;
			lstAcctRep.BackColor = System.Drawing.SystemColors.Window;
			lstAcctRep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstAcctRep.CausesValidation = true;
			lstAcctRep.Enabled = true;
			lstAcctRep.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstAcctRep.ForeColor = System.Drawing.SystemColors.WindowText;
			lstAcctRep.IntegralHeight = true;
			lstAcctRep.Location = new System.Drawing.Point(10, 222);
			lstAcctRep.MultiColumn = false;
			lstAcctRep.Name = "lstAcctRep";
			lstAcctRep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstAcctRep.Size = new System.Drawing.Size(113, 355);
			lstAcctRep.Sorted = false;
			lstAcctRep.TabIndex = 51;
			lstAcctRep.TabStop = true;
			lstAcctRep.Visible = true;
			// 
			// cmdScheduleGo
			// 
			cmdScheduleGo.AllowDrop = true;
			cmdScheduleGo.BackColor = System.Drawing.SystemColors.Control;
			cmdScheduleGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdScheduleGo.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdScheduleGo.Location = new System.Drawing.Point(471, 196);
			cmdScheduleGo.Name = "cmdScheduleGo";
			cmdScheduleGo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdScheduleGo.Size = new System.Drawing.Size(117, 23);
			cmdScheduleGo.TabIndex = 50;
			cmdScheduleGo.Text = "Refresh Schedule";
			cmdScheduleGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdScheduleGo.UseVisualStyleBackColor = false;
			cmdScheduleGo.Click += new System.EventHandler(cmdScheduleGo_Click);
			cmdScheduleGo.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdScheduleGo_MouseUp);
			// 
			// MonthView2
			// 
			MonthView2.AllowDrop = true;
			MonthView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			MonthView2.ForeColor = System.Drawing.SystemColors.ControlText;
			MonthView2.Location = new System.Drawing.Point(269, 13);
			MonthView2.Name = "MonthView2";
			MonthView2.Size = new System.Drawing.Size(178, 154);
			MonthView2.TabIndex = 39;
			MonthView2.Click += new System.EventHandler(MonthView2_Click);
			MonthView2.Enter += new System.EventHandler(MonthView2_Enter);
			// 
			// MonthView1
			// 
			MonthView1.AllowDrop = true;
			MonthView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			MonthView1.ForeColor = System.Drawing.SystemColors.ControlText;
			MonthView1.Location = new System.Drawing.Point(44, 12);
			MonthView1.Name = "MonthView1";
			MonthView1.Size = new System.Drawing.Size(178, 154);
			MonthView1.TabIndex = 38;
			MonthView1.Click += new System.EventHandler(MonthView1_Click);
			MonthView1.Enter += new System.EventHandler(MonthView1_Enter);
			// 
			// Label6
			// 
			Label6.AllowDrop = true;
			Label6.BackColor = System.Drawing.SystemColors.Control;
			Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			Label6.Location = new System.Drawing.Point(560, 36);
			Label6.MinimumSize = new System.Drawing.Size(105, 17);
			Label6.Name = "Label6";
			Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label6.Size = new System.Drawing.Size(105, 17);
			Label6.TabIndex = 86;
			Label6.Text = "days since conf.";
			// 
			// Label5
			// 
			Label5.AllowDrop = true;
			Label5.BackColor = System.Drawing.SystemColors.Control;
			Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			Label5.Location = new System.Drawing.Point(472, 36);
			Label5.MinimumSize = new System.Drawing.Size(81, 17);
			Label5.Name = "Label5";
			Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label5.Size = new System.Drawing.Size(81, 17);
			Label5.TabIndex = 85;
			Label5.Text = "Over";
			// 
			// lblGrandTotal
			// 
			lblGrandTotal.AllowDrop = true;
			lblGrandTotal.AutoSize = true;
			lblGrandTotal.BackColor = System.Drawing.SystemColors.Control;
			lblGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblGrandTotal.ForeColor = System.Drawing.SystemColors.ControlText;
			lblGrandTotal.Location = new System.Drawing.Point(648, 140);
			lblGrandTotal.MinimumSize = new System.Drawing.Size(59, 13);
			lblGrandTotal.Name = "lblGrandTotal";
			lblGrandTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblGrandTotal.Size = new System.Drawing.Size(59, 13);
			lblGrandTotal.TabIndex = 76;
			lblGrandTotal.Text = "Grand Total:";
			lblGrandTotal.Visible = false;
			// 
			// lblCompany
			// 
			lblCompany.AllowDrop = true;
			lblCompany.AutoSize = true;
			lblCompany.BackColor = System.Drawing.SystemColors.Control;
			lblCompany.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompany.Location = new System.Drawing.Point(648, 12);
			lblCompany.MinimumSize = new System.Drawing.Size(108, 16);
			lblCompany.Name = "lblCompany";
			lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompany.Size = new System.Drawing.Size(108, 16);
			lblCompany.TabIndex = 57;
			lblCompany.Text = "AC10 - 1/1/2001";
			lblCompany.Visible = false;
			// 
			// lblTo
			// 
			lblTo.AllowDrop = true;
			lblTo.AutoSize = true;
			lblTo.BackColor = System.Drawing.SystemColors.Control;
			lblTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTo.ForeColor = System.Drawing.SystemColors.ControlText;
			lblTo.Location = new System.Drawing.Point(245, 85);
			lblTo.MinimumSize = new System.Drawing.Size(21, 20);
			lblTo.Name = "lblTo";
			lblTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblTo.Size = new System.Drawing.Size(21, 20);
			lblTo.TabIndex = 55;
			lblTo.Text = "To";
			// 
			// lblFrom
			// 
			lblFrom.AllowDrop = true;
			lblFrom.AutoSize = true;
			lblFrom.BackColor = System.Drawing.SystemColors.Control;
			lblFrom.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFrom.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFrom.Location = new System.Drawing.Point(7, 85);
			lblFrom.MinimumSize = new System.Drawing.Size(34, 20);
			lblFrom.Name = "lblFrom";
			lblFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFrom.Size = new System.Drawing.Size(34, 20);
			lblFrom.TabIndex = 54;
			lblFrom.Text = "From";
			// 
			// frm_UserAccounts
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(1004, 719);
			ControlBox = false;
			Controls.Add(cmdStop);
			Controls.Add(tbr_ToolBar);
			Controls.Add(tab_Accounts);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(596, 229);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_UserAccounts";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "User Accounts";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(cmdStop, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Assignments, 0);
			commandButtonHelper1.SetStyle(cmdAccountAssignRefresh, 0);
			commandButtonHelper1.SetStyle(cmd_AircraftDetail, 0);
			commandButtonHelper1.SetStyle(cmdSaveNewAccountID, 0);
			commandButtonHelper1.SetStyle(cmdCancelNewAccountID, 0);
			commandButtonHelper1.SetStyle(cmdDeleteNewAccountID, 0);
			commandButtonHelper1.SetStyle(cmd_Analyze, 0);
			commandButtonHelper1.SetStyle(cmd_FindDup, 0);
			commandButtonHelper1.SetStyle(cmd_SummarizeConfirms, 0);
			commandButtonHelper1.SetStyle(cmdScheduleGo, 0);
			listBoxHelper1.SetSelectionMode(lst_Assign, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Unassigned, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_dup, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lstCompany, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lstAcctRep, System.Windows.Forms.SelectionMode.MultiExtended);
			optionButtonHelper1.SetStyle(optAccountRepActivity, 0);
			optionButtonHelper1.SetStyle(optCallbackSchedule, 0);
			ToolTipMain.SetToolTip(chkAllActivityReports, "View All Account Rep Activity Reports (SLOW)");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			MouseMove += new System.Windows.Forms.MouseEventHandler(Form_MouseMove);
			((System.ComponentModel.ISupportInitialize) GrdAircraftDetail).EndInit();
			((System.ComponentModel.ISupportInitialize) grdACSummary).EndInit();
			((System.ComponentModel.ISupportInitialize) grdSchedule).EndInit();
			tbr_ToolBar.ResumeLayout(false);
			tbr_ToolBar.PerformLayout();
			tab_Accounts.ResumeLayout(false);
			tab_Accounts.PerformLayout();
			_tab_Accounts_TabPage0.ResumeLayout(false);
			_tab_Accounts_TabPage0.PerformLayout();
			pnl_AutoAssign.ResumeLayout(false);
			pnl_AutoAssign.PerformLayout();
			SSPanel1.ResumeLayout(false);
			SSPanel1.PerformLayout();
			SSPanel2.ResumeLayout(false);
			SSPanel2.PerformLayout();
			frmAcctAssignments.ResumeLayout(false);
			frmAcctAssignments.PerformLayout();
			pnl_AircraftDetail.ResumeLayout(false);
			pnl_AircraftDetail.PerformLayout();
			pnlAddNewAccountID.ResumeLayout(false);
			pnlAddNewAccountID.PerformLayout();
			_tab_Accounts_TabPage1.ResumeLayout(false);
			_tab_Accounts_TabPage1.PerformLayout();
			_tab_Accounts_TabPage2.ResumeLayout(false);
			_tab_Accounts_TabPage2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializelbl_account();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = JETNET_Homebase.mdi_ResearchAssistant.DefInstance;
			JETNET_Homebase.mdi_ResearchAssistant.DefInstance.Show();
		}
		void Initializelbl_account()
		{
			lbl_account = new System.Windows.Forms.Label[19];
			lbl_account[18] = _lbl_account_18;
			lbl_account[17] = _lbl_account_17;
			lbl_account[14] = _lbl_account_14;
			lbl_account[13] = _lbl_account_13;
			lbl_account[12] = _lbl_account_12;
			lbl_account[11] = _lbl_account_11;
			lbl_account[5] = _lbl_account_5;
			lbl_account[2] = _lbl_account_2;
			lbl_account[1] = _lbl_account_1;
			lbl_account[6] = _lbl_account_6;
			lbl_account[4] = _lbl_account_4;
			lbl_account[3] = _lbl_account_3;
			lbl_account[16] = _lbl_account_16;
			lbl_account[15] = _lbl_account_15;
			lbl_account[0] = _lbl_account_0;
			lbl_account[7] = _lbl_account_7;
			lbl_account[8] = _lbl_account_8;
			lbl_account[9] = _lbl_account_9;
			lbl_account[10] = _lbl_account_10;
		}
		#endregion
	}
}