
namespace JETNET_Homebase
{
	partial class frm_Main_Menu
	{

		#region "Upgrade Support "
		private static frm_Main_Menu m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Main_Menu DefInstance
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
		public static frm_Main_Menu CreateInstance()
		{
			frm_Main_Menu theInstance = new frm_Main_Menu();
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
		bool fTerminateCalled_Form_Terminate;
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileDatabase", "mnuReLogin", "mnuFileLogout", "mnuFile", "mnutoolsNTSBDownload", "mnuTools337", "mnuInstall", "mnuTomorrow", "mnuToolsNewAvail", "mnuNewRelease", "mnuAdministration", "mnuCanRegistry", "mnuLoadJETNETiQSurveyResults", "mnuJunk", "mnuJunk1", "mnuShowUserHistory", "mnuSalePrices", "mnuMissingPrices", "mnuToolsEnterHoursWorked", "Cmd_Prospect", "mnuActionItems", "mnuhomebaselogin", "mnuSendEMailQueueHomebaseEMail", "mnuTools", "mnuHelpHomebase", "mnuHelpHomebaseRelease", "mnuHelp", "MainMenu1", "txt_ip_address", "txt_db_login", "txt_db_password", "opt_Server", "cmd_db_cancel", "cmd_Set_JETNET", "Label1", "Label3", "Label5", "pnl_Database", "cmd_cancel", "cmd_login", "txt_login_password", "txt_login_ID", "txt_database_name", "_OptDatabase_0", "_OptDatabase_1", "lbl_try_count", "lbl_login_password", "lbl_login_ID", "lbl_login_message", "Label2", "pnl_Login", "cmd_Logout", "lblDatabase", "lbl_user_type", "lbl_User_Name", "lbl_user_id", "lbl_Message", "Label4", "pnl_Status", "lbl_Email_Address", "lblServer", "lblServerLabel", "lblVersionLable", "lblVersion", "lblDate", "lbl_DatabaseType", "lbl_Welcome", "lblDateLabel", "img_Company", "img_Accounts", "img_Callbacks", "img_Administration", "img_Aircraft_Model", "img_Aircraft", "img_Main", "OptDatabase", "commandButtonHelper1", "optionButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileDatabase;
		public System.Windows.Forms.ToolStripMenuItem mnuReLogin;
		public System.Windows.Forms.ToolStripMenuItem mnuFileLogout;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.ToolStripMenuItem mnutoolsNTSBDownload;
		public System.Windows.Forms.ToolStripMenuItem mnuTools337;
		public System.Windows.Forms.ToolStripMenuItem mnuInstall;
		public System.Windows.Forms.ToolStripMenuItem mnuTomorrow;
		public System.Windows.Forms.ToolStripMenuItem mnuToolsNewAvail;
		public System.Windows.Forms.ToolStripMenuItem mnuNewRelease;
		public System.Windows.Forms.ToolStripMenuItem mnuAdministration;
		public System.Windows.Forms.ToolStripMenuItem mnuCanRegistry;
		public System.Windows.Forms.ToolStripMenuItem mnuLoadJETNETiQSurveyResults;
		public System.Windows.Forms.ToolStripMenuItem mnuJunk;
		public System.Windows.Forms.ToolStripMenuItem mnuJunk1;
		public System.Windows.Forms.ToolStripMenuItem mnuShowUserHistory;
		public System.Windows.Forms.ToolStripMenuItem mnuSalePrices;
		public System.Windows.Forms.ToolStripMenuItem mnuMissingPrices;
		public System.Windows.Forms.ToolStripMenuItem mnuToolsEnterHoursWorked;
		public System.Windows.Forms.ToolStripMenuItem Cmd_Prospect;
		public System.Windows.Forms.ToolStripMenuItem mnuActionItems;
		public System.Windows.Forms.ToolStripMenuItem mnuhomebaselogin;
		public System.Windows.Forms.ToolStripMenuItem mnuSendEMailQueueHomebaseEMail;
		public System.Windows.Forms.ToolStripMenuItem mnuTools;
		public System.Windows.Forms.ToolStripMenuItem mnuHelpHomebase;
		public System.Windows.Forms.ToolStripMenuItem mnuHelpHomebaseRelease;
		public System.Windows.Forms.ToolStripMenuItem mnuHelp;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.TextBox txt_ip_address;
		public System.Windows.Forms.TextBox txt_db_login;
		public System.Windows.Forms.TextBox txt_db_password;
		public System.Windows.Forms.RadioButton opt_Server;
		public System.Windows.Forms.Button cmd_db_cancel;
		public System.Windows.Forms.Button cmd_Set_JETNET;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Panel pnl_Database;
		public System.Windows.Forms.Button cmd_cancel;
		public System.Windows.Forms.Button cmd_login;
		public System.Windows.Forms.TextBox txt_login_password;
		public System.Windows.Forms.TextBox txt_login_ID;
		public System.Windows.Forms.TextBox txt_database_name;
		private System.Windows.Forms.RadioButton _OptDatabase_0;
		private System.Windows.Forms.RadioButton _OptDatabase_1;
		public System.Windows.Forms.Label lbl_try_count;
		public System.Windows.Forms.Label lbl_login_password;
		public System.Windows.Forms.Label lbl_login_ID;
		public System.Windows.Forms.Label lbl_login_message;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Panel pnl_Login;
		public System.Windows.Forms.Button cmd_Logout;
		public System.Windows.Forms.Label lblDatabase;
		public System.Windows.Forms.Label lbl_user_type;
		public System.Windows.Forms.Label lbl_User_Name;
		public System.Windows.Forms.Label lbl_user_id;
		public System.Windows.Forms.Label lbl_Message;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Panel pnl_Status;
		public System.Windows.Forms.Label lbl_Email_Address;
		public System.Windows.Forms.Label lblServer;
		public System.Windows.Forms.Label lblServerLabel;
		public System.Windows.Forms.Label lblVersionLable;
		public System.Windows.Forms.Label lblVersion;
		public System.Windows.Forms.Label lblDate;
		public System.Windows.Forms.Label lbl_DatabaseType;
		public System.Windows.Forms.Label lbl_Welcome;
		public System.Windows.Forms.Label lblDateLabel;
		public System.Windows.Forms.PictureBox img_Company;
		public System.Windows.Forms.PictureBox img_Accounts;
		public System.Windows.Forms.PictureBox img_Callbacks;
		public System.Windows.Forms.PictureBox img_Administration;
		public System.Windows.Forms.PictureBox img_Aircraft_Model;
		public System.Windows.Forms.PictureBox img_Aircraft;
		public System.Windows.Forms.PictureBox img_Main;
		public System.Windows.Forms.RadioButton[] OptDatabase = new System.Windows.Forms.RadioButton[2];
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main_Menu));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileDatabase = new System.Windows.Forms.ToolStripMenuItem();
			mnuReLogin = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileLogout = new System.Windows.Forms.ToolStripMenuItem();
			mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			mnutoolsNTSBDownload = new System.Windows.Forms.ToolStripMenuItem();
			mnuTools337 = new System.Windows.Forms.ToolStripMenuItem();
			mnuInstall = new System.Windows.Forms.ToolStripMenuItem();
			mnuTomorrow = new System.Windows.Forms.ToolStripMenuItem();
			mnuToolsNewAvail = new System.Windows.Forms.ToolStripMenuItem();
			mnuNewRelease = new System.Windows.Forms.ToolStripMenuItem();
			mnuAdministration = new System.Windows.Forms.ToolStripMenuItem();
			mnuCanRegistry = new System.Windows.Forms.ToolStripMenuItem();
			mnuLoadJETNETiQSurveyResults = new System.Windows.Forms.ToolStripMenuItem();
			mnuJunk = new System.Windows.Forms.ToolStripMenuItem();
			mnuJunk1 = new System.Windows.Forms.ToolStripMenuItem();
			mnuShowUserHistory = new System.Windows.Forms.ToolStripMenuItem();
			mnuSalePrices = new System.Windows.Forms.ToolStripMenuItem();
			mnuMissingPrices = new System.Windows.Forms.ToolStripMenuItem();
			mnuToolsEnterHoursWorked = new System.Windows.Forms.ToolStripMenuItem();
			Cmd_Prospect = new System.Windows.Forms.ToolStripMenuItem();
			mnuActionItems = new System.Windows.Forms.ToolStripMenuItem();
			mnuhomebaselogin = new System.Windows.Forms.ToolStripMenuItem();
			mnuSendEMailQueueHomebaseEMail = new System.Windows.Forms.ToolStripMenuItem();
			mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			mnuHelpHomebase = new System.Windows.Forms.ToolStripMenuItem();
			mnuHelpHomebaseRelease = new System.Windows.Forms.ToolStripMenuItem();
			pnl_Database = new System.Windows.Forms.Panel();
			txt_ip_address = new System.Windows.Forms.TextBox();
			txt_db_login = new System.Windows.Forms.TextBox();
			txt_db_password = new System.Windows.Forms.TextBox();
			opt_Server = new System.Windows.Forms.RadioButton();
			cmd_db_cancel = new System.Windows.Forms.Button();
			cmd_Set_JETNET = new System.Windows.Forms.Button();
			Label1 = new System.Windows.Forms.Label();
			Label3 = new System.Windows.Forms.Label();
			Label5 = new System.Windows.Forms.Label();
			pnl_Login = new System.Windows.Forms.Panel();
			cmd_cancel = new System.Windows.Forms.Button();
			cmd_login = new System.Windows.Forms.Button();
			txt_login_password = new System.Windows.Forms.TextBox();
			txt_login_ID = new System.Windows.Forms.TextBox();
			txt_database_name = new System.Windows.Forms.TextBox();
			_OptDatabase_0 = new System.Windows.Forms.RadioButton();
			_OptDatabase_1 = new System.Windows.Forms.RadioButton();
			lbl_try_count = new System.Windows.Forms.Label();
			lbl_login_password = new System.Windows.Forms.Label();
			lbl_login_ID = new System.Windows.Forms.Label();
			lbl_login_message = new System.Windows.Forms.Label();
			Label2 = new System.Windows.Forms.Label();
			pnl_Status = new System.Windows.Forms.Panel();
			cmd_Logout = new System.Windows.Forms.Button();
			lblDatabase = new System.Windows.Forms.Label();
			lbl_user_type = new System.Windows.Forms.Label();
			lbl_User_Name = new System.Windows.Forms.Label();
			lbl_user_id = new System.Windows.Forms.Label();
			lbl_Message = new System.Windows.Forms.Label();
			Label4 = new System.Windows.Forms.Label();
			lbl_Email_Address = new System.Windows.Forms.Label();
			lblServer = new System.Windows.Forms.Label();
			lblServerLabel = new System.Windows.Forms.Label();
			lblVersionLable = new System.Windows.Forms.Label();
			lblVersion = new System.Windows.Forms.Label();
			lblDate = new System.Windows.Forms.Label();
			lbl_DatabaseType = new System.Windows.Forms.Label();
			lbl_Welcome = new System.Windows.Forms.Label();
			lblDateLabel = new System.Windows.Forms.Label();
			img_Company = new System.Windows.Forms.PictureBox();
			img_Accounts = new System.Windows.Forms.PictureBox();
			img_Callbacks = new System.Windows.Forms.PictureBox();
			img_Administration = new System.Windows.Forms.PictureBox();
			img_Aircraft_Model = new System.Windows.Forms.PictureBox();
			img_Aircraft = new System.Windows.Forms.PictureBox();
			img_Main = new System.Windows.Forms.PictureBox();
			pnl_Database.SuspendLayout();
			pnl_Login.SuspendLayout();
			pnl_Status.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFile, mnuTools, mnuHelp});
			// 
			// mnuFile
			// 
			mnuFile.Available = true;
			mnuFile.Checked = false;
			mnuFile.Enabled = true;
			mnuFile.Name = "mnuFile";
			mnuFile.Text = "File";
			mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFileDatabase, mnuReLogin, mnuFileLogout});
			// 
			// mnuFileDatabase
			// 
			mnuFileDatabase.Available = true;
			mnuFileDatabase.Checked = false;
			mnuFileDatabase.Enabled = true;
			mnuFileDatabase.Name = "mnuFileDatabase";
			mnuFileDatabase.Text = "Database Settings";
			mnuFileDatabase.Click += new System.EventHandler(mnuFileDatabase_Click);
			// 
			// mnuReLogin
			// 
			mnuReLogin.Available = true;
			mnuReLogin.Checked = false;
			mnuReLogin.Enabled = true;
			mnuReLogin.Name = "mnuReLogin";
			mnuReLogin.Text = "Login as &Different User";
			mnuReLogin.Click += new System.EventHandler(mnuReLogin_Click);
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
			// mnuTools
			// 
			mnuTools.Available = true;
			mnuTools.Checked = false;
			mnuTools.Enabled = true;
			mnuTools.Name = "mnuTools";
			mnuTools.Text = "&Tools";
			mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnutoolsNTSBDownload, mnuTools337, mnuInstall, mnuTomorrow, mnuToolsNewAvail, mnuNewRelease, mnuAdministration, mnuCanRegistry, mnuLoadJETNETiQSurveyResults, mnuJunk, mnuJunk1, mnuShowUserHistory, mnuSalePrices, mnuMissingPrices, mnuToolsEnterHoursWorked, Cmd_Prospect, mnuActionItems, mnuhomebaselogin, mnuSendEMailQueueHomebaseEMail});
			// 
			// mnutoolsNTSBDownload
			// 
			mnutoolsNTSBDownload.Available = true;
			mnutoolsNTSBDownload.Checked = false;
			mnutoolsNTSBDownload.Enabled = false;
			mnutoolsNTSBDownload.Name = "mnutoolsNTSBDownload";
			mnutoolsNTSBDownload.Text = "NTSB Download";
			mnutoolsNTSBDownload.Click += new System.EventHandler(mnutoolsNTSBDownload_Click);
			// 
			// mnuTools337
			// 
			mnuTools337.Available = false;
			mnuTools337.Checked = false;
			mnuTools337.Enabled = false;
			mnuTools337.Name = "mnuTools337";
			mnuTools337.Text = "337 Maintenance Report Processing";
			// 
			// mnuInstall
			// 
			mnuInstall.Available = true;
			mnuInstall.Checked = false;
			mnuInstall.Enabled = false;
			mnuInstall.Name = "mnuInstall";
			mnuInstall.Text = "&Install Latest Version";
			mnuInstall.Click += new System.EventHandler(mnuInstall_Click);
			// 
			// mnuTomorrow
			// 
			mnuTomorrow.Available = false;
			mnuTomorrow.Checked = false;
			mnuTomorrow.Enabled = true;
			mnuTomorrow.Name = "mnuTomorrow";
			mnuTomorrow.Text = "&Get Tomorrows Release";
			mnuTomorrow.Click += new System.EventHandler(mnuTomorrow_Click);
			// 
			// mnuToolsNewAvail
			// 
			mnuToolsNewAvail.Available = true;
			mnuToolsNewAvail.Checked = false;
			mnuToolsNewAvail.Enabled = true;
			mnuToolsNewAvail.Name = "mnuToolsNewAvail";
			mnuToolsNewAvail.Text = "New Tasks Available";
			mnuToolsNewAvail.Click += new System.EventHandler(mnuToolsNewAvail_Click);
			// 
			// mnuNewRelease
			// 
			mnuNewRelease.Available = false;
			mnuNewRelease.Checked = false;
			mnuNewRelease.Enabled = true;
			mnuNewRelease.Name = "mnuNewRelease";
			mnuNewRelease.Text = "Give Everyone New Release";
			mnuNewRelease.Click += new System.EventHandler(mnuNewRelease_Click);
			// 
			// mnuAdministration
			// 
			mnuAdministration.Available = true;
			mnuAdministration.Checked = false;
			mnuAdministration.Enabled = true;
			mnuAdministration.Name = "mnuAdministration";
			mnuAdministration.Text = "Administration";
			// 
			// mnuCanRegistry
			// 
			mnuCanRegistry.Available = true;
			mnuCanRegistry.Checked = false;
			mnuCanRegistry.Enabled = true;
			mnuCanRegistry.Name = "mnuCanRegistry";
			mnuCanRegistry.Text = "Canadian Registry";
			mnuCanRegistry.Click += new System.EventHandler(mnuCanRegistry_Click);
			// 
			// mnuLoadJETNETiQSurveyResults
			// 
			mnuLoadJETNETiQSurveyResults.Available = true;
			mnuLoadJETNETiQSurveyResults.Checked = false;
			mnuLoadJETNETiQSurveyResults.Enabled = true;
			mnuLoadJETNETiQSurveyResults.Name = "mnuLoadJETNETiQSurveyResults";
			mnuLoadJETNETiQSurveyResults.Text = "Load JETNETiQ Survey Results";
			mnuLoadJETNETiQSurveyResults.Click += new System.EventHandler(mnuLoadJETNETiQSurveyResults_Click);
			// 
			// mnuJunk
			// 
			mnuJunk.Available = false;
			mnuJunk.Checked = false;
			mnuJunk.Enabled = true;
			mnuJunk.Name = "mnuJunk";
			mnuJunk.Text = "Test Add Company Form";
			mnuJunk.Click += new System.EventHandler(mnuJunk_Click);
			// 
			// mnuJunk1
			// 
			mnuJunk1.Available = false;
			mnuJunk1.Checked = false;
			mnuJunk1.Enabled = true;
			mnuJunk1.Name = "mnuJunk1";
			mnuJunk1.Text = "Test New Company Form";
			mnuJunk1.Click += new System.EventHandler(mnuJunk1_Click);
			// 
			// mnuShowUserHistory
			// 
			mnuShowUserHistory.Available = true;
			mnuShowUserHistory.Checked = false;
			mnuShowUserHistory.Enabled = false;
			mnuShowUserHistory.Name = "mnuShowUserHistory";
			mnuShowUserHistory.Text = "Show User History";
			mnuShowUserHistory.Click += new System.EventHandler(mnuShowUserHistory_Click);
			// 
			// mnuSalePrices
			// 
			mnuSalePrices.Available = true;
			mnuSalePrices.Checked = false;
			mnuSalePrices.Enabled = true;
			mnuSalePrices.Name = "mnuSalePrices";
			mnuSalePrices.Text = "Sale Prices Out of Range";
			mnuSalePrices.Click += new System.EventHandler(mnuSalePrices_Click);
			// 
			// mnuMissingPrices
			// 
			mnuMissingPrices.Available = true;
			mnuMissingPrices.Checked = false;
			mnuMissingPrices.Enabled = true;
			mnuMissingPrices.Name = "mnuMissingPrices";
			mnuMissingPrices.Text = "Missing Sale Prices";
			mnuMissingPrices.Click += new System.EventHandler(mnuMissingPrices_Click);
			// 
			// mnuToolsEnterHoursWorked
			// 
			mnuToolsEnterHoursWorked.Available = true;
			mnuToolsEnterHoursWorked.Checked = false;
			mnuToolsEnterHoursWorked.Enabled = true;
			mnuToolsEnterHoursWorked.Name = "mnuToolsEnterHoursWorked";
			mnuToolsEnterHoursWorked.Text = "Enter Hours Worked";
			mnuToolsEnterHoursWorked.Click += new System.EventHandler(mnuToolsEnterHoursWorked_Click);
			// 
			// Cmd_Prospect
			// 
			Cmd_Prospect.Available = true;
			Cmd_Prospect.Checked = false;
			Cmd_Prospect.Enabled = true;
			Cmd_Prospect.Name = "Cmd_Prospect";
			Cmd_Prospect.Text = "Prospect Manager";
			Cmd_Prospect.Click += new System.EventHandler(Cmd_Prospect_Click);
			// 
			// mnuActionItems
			// 
			mnuActionItems.Available = true;
			mnuActionItems.Checked = false;
			mnuActionItems.Enabled = true;
			mnuActionItems.Name = "mnuActionItems";
			mnuActionItems.Text = "Action Items";
			mnuActionItems.Click += new System.EventHandler(mnuActionItems_Click);
			// 
			// mnuhomebaselogin
			// 
			mnuhomebaselogin.Available = true;
			mnuhomebaselogin.Checked = false;
			mnuhomebaselogin.Enabled = true;
			mnuhomebaselogin.Name = "mnuhomebaselogin";
			mnuhomebaselogin.Text = "Homebase.com Login";
			mnuhomebaselogin.Click += new System.EventHandler(mnuhomebaselogin_Click);
			// 
			// mnuSendEMailQueueHomebaseEMail
			// 
			mnuSendEMailQueueHomebaseEMail.Available = true;
			mnuSendEMailQueueHomebaseEMail.Checked = false;
			mnuSendEMailQueueHomebaseEMail.Enabled = true;
			mnuSendEMailQueueHomebaseEMail.Name = "mnuSendEMailQueueHomebaseEMail";
			mnuSendEMailQueueHomebaseEMail.Text = "Send EMail Queue HomebaseEMail";
			mnuSendEMailQueueHomebaseEMail.Click += new System.EventHandler(mnuSendEMailQueueHomebaseEMail_Click);
			// 
			// mnuHelp
			// 
			mnuHelp.Available = true;
			mnuHelp.Checked = false;
			mnuHelp.Enabled = true;
			mnuHelp.Name = "mnuHelp";
			mnuHelp.Text = "&Help";
			mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuHelpHomebase, mnuHelpHomebaseRelease});
			// 
			// mnuHelpHomebase
			// 
			mnuHelpHomebase.Available = true;
			mnuHelpHomebase.Checked = false;
			mnuHelpHomebase.Enabled = true;
			mnuHelpHomebase.Name = "mnuHelpHomebase";
			mnuHelpHomebase.Text = "Homebase Main Help";
			mnuHelpHomebase.Click += new System.EventHandler(mnuHelpHomebase_Click);
			// 
			// mnuHelpHomebaseRelease
			// 
			mnuHelpHomebaseRelease.Available = true;
			mnuHelpHomebaseRelease.Checked = false;
			mnuHelpHomebaseRelease.Enabled = true;
			mnuHelpHomebaseRelease.Name = "mnuHelpHomebaseRelease";
			mnuHelpHomebaseRelease.Text = "Homebase Release Notes";
			mnuHelpHomebaseRelease.Click += new System.EventHandler(mnuHelpHomebaseRelease_Click);
			// 
			// pnl_Database
			// 
			pnl_Database.AllowDrop = true;
			pnl_Database.BackColor = System.Drawing.SystemColors.Control;
			pnl_Database.BorderStyle = System.Windows.Forms.BorderStyle.None;
			pnl_Database.Controls.Add(txt_ip_address);
			pnl_Database.Controls.Add(txt_db_login);
			pnl_Database.Controls.Add(txt_db_password);
			pnl_Database.Controls.Add(opt_Server);
			pnl_Database.Controls.Add(cmd_db_cancel);
			pnl_Database.Controls.Add(cmd_Set_JETNET);
			pnl_Database.Controls.Add(Label1);
			pnl_Database.Controls.Add(Label3);
			pnl_Database.Controls.Add(Label5);
			pnl_Database.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Database.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_Database.Location = new System.Drawing.Point(369, 243);
			pnl_Database.Name = "pnl_Database";
			pnl_Database.Size = new System.Drawing.Size(305, 180);
			pnl_Database.TabIndex = 10;
			// 
			// txt_ip_address
			// 
			txt_ip_address.AcceptsReturn = true;
			txt_ip_address.AllowDrop = true;
			txt_ip_address.BackColor = System.Drawing.SystemColors.Window;
			txt_ip_address.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ip_address.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ip_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ip_address.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ip_address.Location = new System.Drawing.Point(88, 32);
			txt_ip_address.MaxLength = 0;
			txt_ip_address.Name = "txt_ip_address";
			txt_ip_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ip_address.Size = new System.Drawing.Size(201, 19);
			txt_ip_address.TabIndex = 16;
			txt_ip_address.Text = "10.10.254.54";
			// 
			// txt_db_login
			// 
			txt_db_login.AcceptsReturn = true;
			txt_db_login.AllowDrop = true;
			txt_db_login.BackColor = System.Drawing.SystemColors.Window;
			txt_db_login.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_db_login.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_db_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_db_login.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_db_login.Location = new System.Drawing.Point(88, 56);
			txt_db_login.MaxLength = 0;
			txt_db_login.Name = "txt_db_login";
			txt_db_login.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_db_login.Size = new System.Drawing.Size(129, 19);
			txt_db_login.TabIndex = 15;
			txt_db_login.Text = "sa";
			// 
			// txt_db_password
			// 
			txt_db_password.AcceptsReturn = true;
			txt_db_password.AllowDrop = true;
			txt_db_password.BackColor = System.Drawing.SystemColors.Window;
			txt_db_password.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_db_password.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_db_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_db_password.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_db_password.ImeMode = System.Windows.Forms.ImeMode.Disable;
			txt_db_password.Location = new System.Drawing.Point(88, 80);
			txt_db_password.MaxLength = 0;
			txt_db_password.Name = "txt_db_password";
			txt_db_password.PasswordChar = (char) 42;
			txt_db_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_db_password.Size = new System.Drawing.Size(153, 19);
			txt_db_password.TabIndex = 14;
			txt_db_password.Text = "moejive";
			// 
			// opt_Server
			// 
			opt_Server.AllowDrop = true;
			opt_Server.BackColor = System.Drawing.SystemColors.Control;
			opt_Server.CausesValidation = true;
			opt_Server.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Server.Checked = false;
			opt_Server.Enabled = true;
			opt_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_Server.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_Server.Location = new System.Drawing.Point(65, 115);
			opt_Server.Name = "opt_Server";
			opt_Server.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_Server.Size = new System.Drawing.Size(177, 25);
			opt_Server.TabIndex = 13;
			opt_Server.TabStop = true;
			opt_Server.Text = "Connect to Server Database";
			opt_Server.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Server.Visible = true;
			// 
			// cmd_db_cancel
			// 
			cmd_db_cancel.AllowDrop = true;
			cmd_db_cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_db_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_db_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_db_cancel.Location = new System.Drawing.Point(34, 153);
			cmd_db_cancel.Name = "cmd_db_cancel";
			cmd_db_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_db_cancel.Size = new System.Drawing.Size(79, 17);
			cmd_db_cancel.TabIndex = 12;
			cmd_db_cancel.Text = "Cancel";
			cmd_db_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_db_cancel.UseVisualStyleBackColor = false;
			cmd_db_cancel.Click += new System.EventHandler(cmd_db_cancel_Click);
			// 
			// cmd_Set_JETNET
			// 
			cmd_Set_JETNET.AllowDrop = true;
			cmd_Set_JETNET.BackColor = System.Drawing.SystemColors.Control;
			cmd_Set_JETNET.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Set_JETNET.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Set_JETNET.Location = new System.Drawing.Point(204, 153);
			cmd_Set_JETNET.Name = "cmd_Set_JETNET";
			cmd_Set_JETNET.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Set_JETNET.Size = new System.Drawing.Size(79, 17);
			cmd_Set_JETNET.TabIndex = 11;
			cmd_Set_JETNET.Text = "Set JETNET";
			cmd_Set_JETNET.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Set_JETNET.UseVisualStyleBackColor = false;
			cmd_Set_JETNET.Click += new System.EventHandler(cmd_Set_JETNET_Click);
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.AutoSize = true;
			Label1.BackColor = System.Drawing.Color.Transparent;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(25, 35);
			Label1.MinimumSize = new System.Drawing.Size(54, 13);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(54, 13);
			Label1.TabIndex = 19;
			Label1.Text = "IP Address:";
			Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.BackColor = System.Drawing.Color.Transparent;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(25, 59);
			Label3.MinimumSize = new System.Drawing.Size(54, 13);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(54, 13);
			Label3.TabIndex = 18;
			Label3.Text = "Login:";
			Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// Label5
			// 
			Label5.AllowDrop = true;
			Label5.BackColor = System.Drawing.Color.Transparent;
			Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			Label5.Location = new System.Drawing.Point(25, 83);
			Label5.MinimumSize = new System.Drawing.Size(54, 13);
			Label5.Name = "Label5";
			Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label5.Size = new System.Drawing.Size(54, 13);
			Label5.TabIndex = 17;
			Label5.Text = "Password:";
			Label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// pnl_Login
			// 
			pnl_Login.AllowDrop = true;
			pnl_Login.BackColor = System.Drawing.SystemColors.Control;
			pnl_Login.BorderStyle = System.Windows.Forms.BorderStyle.None;
			pnl_Login.Controls.Add(cmd_cancel);
			pnl_Login.Controls.Add(cmd_login);
			pnl_Login.Controls.Add(txt_login_password);
			pnl_Login.Controls.Add(txt_login_ID);
			pnl_Login.Controls.Add(txt_database_name);
			pnl_Login.Controls.Add(_OptDatabase_0);
			pnl_Login.Controls.Add(_OptDatabase_1);
			pnl_Login.Controls.Add(lbl_try_count);
			pnl_Login.Controls.Add(lbl_login_password);
			pnl_Login.Controls.Add(lbl_login_ID);
			pnl_Login.Controls.Add(lbl_login_message);
			pnl_Login.Controls.Add(Label2);
			pnl_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Login.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_Login.Location = new System.Drawing.Point(696, 498);
			pnl_Login.Name = "pnl_Login";
			pnl_Login.Size = new System.Drawing.Size(305, 180);
			pnl_Login.TabIndex = 20;
			// 
			// cmd_cancel
			// 
			cmd_cancel.AllowDrop = true;
			cmd_cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_cancel.Location = new System.Drawing.Point(178, 149);
			cmd_cancel.Name = "cmd_cancel";
			cmd_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_cancel.Size = new System.Drawing.Size(65, 23);
			cmd_cancel.TabIndex = 5;
			cmd_cancel.Text = "CANCEL";
			cmd_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_cancel.UseVisualStyleBackColor = false;
			cmd_cancel.Click += new System.EventHandler(cmd_cancel_Click);
			// 
			// cmd_login
			// 
			cmd_login.AllowDrop = true;
			cmd_login.BackColor = System.Drawing.SystemColors.Control;
			cmd_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_login.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_login.Location = new System.Drawing.Point(64, 149);
			cmd_login.Name = "cmd_login";
			cmd_login.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_login.Size = new System.Drawing.Size(69, 23);
			cmd_login.TabIndex = 4;
			cmd_login.Text = "&LOGIN";
			cmd_login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_login.UseVisualStyleBackColor = false;
			cmd_login.Click += new System.EventHandler(cmd_login_Click);
			// 
			// txt_login_password
			// 
			txt_login_password.AcceptsReturn = true;
			txt_login_password.AllowDrop = true;
			txt_login_password.BackColor = System.Drawing.SystemColors.Window;
			txt_login_password.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_login_password.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_login_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_login_password.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_login_password.ImeMode = System.Windows.Forms.ImeMode.Disable;
			txt_login_password.Location = new System.Drawing.Point(135, 102);
			txt_login_password.MaxLength = 0;
			txt_login_password.Name = "txt_login_password";
			txt_login_password.PasswordChar = (char) 42;
			txt_login_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_login_password.Size = new System.Drawing.Size(143, 19);
			txt_login_password.TabIndex = 1;
			txt_login_password.Visible = false;
			// 
			// txt_login_ID
			// 
			txt_login_ID.AcceptsReturn = true;
			txt_login_ID.AllowDrop = true;
			txt_login_ID.BackColor = System.Drawing.SystemColors.Window;
			txt_login_ID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_login_ID.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_login_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_login_ID.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_login_ID.Location = new System.Drawing.Point(135, 78);
			txt_login_ID.MaxLength = 0;
			txt_login_ID.Name = "txt_login_ID";
			txt_login_ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_login_ID.Size = new System.Drawing.Size(58, 19);
			txt_login_ID.TabIndex = 0;
			txt_login_ID.Leave += new System.EventHandler(txt_login_ID_Leave);
			// 
			// txt_database_name
			// 
			txt_database_name.AcceptsReturn = true;
			txt_database_name.AllowDrop = true;
			txt_database_name.BackColor = System.Drawing.SystemColors.Window;
			txt_database_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_database_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_database_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_database_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_database_name.Location = new System.Drawing.Point(135, 54);
			txt_database_name.MaxLength = 0;
			txt_database_name.Name = "txt_database_name";
			txt_database_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_database_name.Size = new System.Drawing.Size(129, 19);
			txt_database_name.TabIndex = 6;
			txt_database_name.Text = "jetnet_ra";
			// 
			// _OptDatabase_0
			// 
			_OptDatabase_0.AllowDrop = true;
			_OptDatabase_0.BackColor = System.Drawing.SystemColors.Control;
			_OptDatabase_0.CausesValidation = true;
			_OptDatabase_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_OptDatabase_0.Checked = true;
			_OptDatabase_0.Enabled = true;
			_OptDatabase_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_OptDatabase_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_OptDatabase_0.Location = new System.Drawing.Point(33, 128);
			_OptDatabase_0.Name = "_OptDatabase_0";
			_OptDatabase_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_OptDatabase_0.Size = new System.Drawing.Size(113, 14);
			_OptDatabase_0.TabIndex = 2;
			_OptDatabase_0.TabStop = true;
			_OptDatabase_0.Text = "Business Aircraft";
			_OptDatabase_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_OptDatabase_0.Visible = false;
			_OptDatabase_0.CheckedChanged += new System.EventHandler(OptDatabase_CheckedChanged);
			// 
			// _OptDatabase_1
			// 
			_OptDatabase_1.AllowDrop = true;
			_OptDatabase_1.BackColor = System.Drawing.SystemColors.Control;
			_OptDatabase_1.CausesValidation = true;
			_OptDatabase_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_OptDatabase_1.Checked = false;
			_OptDatabase_1.Enabled = true;
			_OptDatabase_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_OptDatabase_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_OptDatabase_1.Location = new System.Drawing.Point(164, 128);
			_OptDatabase_1.Name = "_OptDatabase_1";
			_OptDatabase_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_OptDatabase_1.Size = new System.Drawing.Size(113, 14);
			_OptDatabase_1.TabIndex = 3;
			_OptDatabase_1.TabStop = true;
			_OptDatabase_1.Text = "Comericial Aircraft";
			_OptDatabase_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_OptDatabase_1.Visible = false;
			_OptDatabase_1.CheckedChanged += new System.EventHandler(OptDatabase_CheckedChanged);
			// 
			// lbl_try_count
			// 
			lbl_try_count.AllowDrop = true;
			lbl_try_count.BackColor = System.Drawing.Color.Transparent;
			lbl_try_count.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_try_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_try_count.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_try_count.Location = new System.Drawing.Point(86, 208);
			lbl_try_count.MinimumSize = new System.Drawing.Size(111, 13);
			lbl_try_count.Name = "lbl_try_count";
			lbl_try_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_try_count.Size = new System.Drawing.Size(111, 13);
			lbl_try_count.TabIndex = 25;
			lbl_try_count.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_login_password
			// 
			lbl_login_password.AllowDrop = true;
			lbl_login_password.BackColor = System.Drawing.Color.Transparent;
			lbl_login_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_login_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_login_password.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_login_password.Location = new System.Drawing.Point(36, 105);
			lbl_login_password.MinimumSize = new System.Drawing.Size(82, 13);
			lbl_login_password.Name = "lbl_login_password";
			lbl_login_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_login_password.Size = new System.Drawing.Size(82, 13);
			lbl_login_password.TabIndex = 24;
			lbl_login_password.Text = "Password:";
			lbl_login_password.TextAlign = System.Drawing.ContentAlignment.TopRight;
			lbl_login_password.Visible = false;
			// 
			// lbl_login_ID
			// 
			lbl_login_ID.AllowDrop = true;
			lbl_login_ID.BackColor = System.Drawing.Color.Transparent;
			lbl_login_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_login_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_login_ID.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_login_ID.Location = new System.Drawing.Point(37, 81);
			lbl_login_ID.MinimumSize = new System.Drawing.Size(82, 13);
			lbl_login_ID.Name = "lbl_login_ID";
			lbl_login_ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_login_ID.Size = new System.Drawing.Size(82, 13);
			lbl_login_ID.TabIndex = 23;
			lbl_login_ID.Text = "User ID:";
			lbl_login_ID.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbl_login_message
			// 
			lbl_login_message.AllowDrop = true;
			lbl_login_message.BackColor = System.Drawing.Color.Transparent;
			lbl_login_message.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_login_message.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_login_message.ForeColor = System.Drawing.SystemColors.WindowText;
			lbl_login_message.Location = new System.Drawing.Point(6, 2);
			lbl_login_message.MinimumSize = new System.Drawing.Size(293, 45);
			lbl_login_message.Name = "lbl_login_message";
			lbl_login_message.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_login_message.Size = new System.Drawing.Size(293, 45);
			lbl_login_message.TabIndex = 22;
			lbl_login_message.Text = "Login Message";
			lbl_login_message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.BackColor = System.Drawing.Color.Transparent;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			Label2.Location = new System.Drawing.Point(37, 57);
			Label2.MinimumSize = new System.Drawing.Size(82, 13);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(82, 13);
			Label2.TabIndex = 21;
			Label2.Text = "Database:";
			Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// pnl_Status
			// 
			pnl_Status.AllowDrop = true;
			pnl_Status.BackColor = System.Drawing.SystemColors.Control;
			pnl_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
			pnl_Status.Controls.Add(cmd_Logout);
			pnl_Status.Controls.Add(lblDatabase);
			pnl_Status.Controls.Add(lbl_user_type);
			pnl_Status.Controls.Add(lbl_User_Name);
			pnl_Status.Controls.Add(lbl_user_id);
			pnl_Status.Controls.Add(lbl_Message);
			pnl_Status.Controls.Add(Label4);
			pnl_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Status.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_Status.Location = new System.Drawing.Point(696, 498);
			pnl_Status.Name = "pnl_Status";
			pnl_Status.Size = new System.Drawing.Size(305, 180);
			pnl_Status.TabIndex = 26;
			// 
			// cmd_Logout
			// 
			cmd_Logout.AllowDrop = true;
			cmd_Logout.BackColor = System.Drawing.SystemColors.Control;
			cmd_Logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Logout.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Logout.Location = new System.Drawing.Point(118, 6);
			cmd_Logout.Name = "cmd_Logout";
			cmd_Logout.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Logout.Size = new System.Drawing.Size(69, 23);
			cmd_Logout.TabIndex = 28;
			cmd_Logout.Text = "LOGOUT";
			cmd_Logout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Logout.UseVisualStyleBackColor = false;
			cmd_Logout.Click += new System.EventHandler(cmd_Logout_Click);
			// 
			// lblDatabase
			// 
			lblDatabase.AllowDrop = true;
			lblDatabase.BackColor = System.Drawing.Color.Transparent;
			lblDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDatabase.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lblDatabase.Location = new System.Drawing.Point(11, 116);
			lblDatabase.MinimumSize = new System.Drawing.Size(283, 25);
			lblDatabase.Name = "lblDatabase";
			lblDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDatabase.Size = new System.Drawing.Size(283, 25);
			lblDatabase.TabIndex = 33;
			lblDatabase.Text = "DATABASE";
			// 
			// lbl_user_type
			// 
			lbl_user_type.AllowDrop = true;
			lbl_user_type.BackColor = System.Drawing.Color.Transparent;
			lbl_user_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_user_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_user_type.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_user_type.Location = new System.Drawing.Point(11, 87);
			lbl_user_type.MinimumSize = new System.Drawing.Size(283, 25);
			lbl_user_type.Name = "lbl_user_type";
			lbl_user_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_user_type.Size = new System.Drawing.Size(283, 25);
			lbl_user_type.TabIndex = 32;
			lbl_user_type.Text = "USER TYPE";
			// 
			// lbl_User_Name
			// 
			lbl_User_Name.AllowDrop = true;
			lbl_User_Name.BackColor = System.Drawing.Color.Transparent;
			lbl_User_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_User_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_User_Name.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_User_Name.Location = new System.Drawing.Point(11, 59);
			lbl_User_Name.MinimumSize = new System.Drawing.Size(283, 25);
			lbl_User_Name.Name = "lbl_User_Name";
			lbl_User_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_User_Name.Size = new System.Drawing.Size(283, 25);
			lbl_User_Name.TabIndex = 31;
			lbl_User_Name.Text = "USER NAME";
			// 
			// lbl_user_id
			// 
			lbl_user_id.AllowDrop = true;
			lbl_user_id.BackColor = System.Drawing.Color.Transparent;
			lbl_user_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_user_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_user_id.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_user_id.Location = new System.Drawing.Point(11, 30);
			lbl_user_id.MinimumSize = new System.Drawing.Size(283, 25);
			lbl_user_id.Name = "lbl_user_id";
			lbl_user_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_user_id.Size = new System.Drawing.Size(283, 25);
			lbl_user_id.TabIndex = 30;
			lbl_user_id.Text = "USER ID";
			// 
			// lbl_Message
			// 
			lbl_Message.AllowDrop = true;
			lbl_Message.BackColor = System.Drawing.Color.Transparent;
			lbl_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Message.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_Message.Location = new System.Drawing.Point(11, 144);
			lbl_Message.MinimumSize = new System.Drawing.Size(283, 25);
			lbl_Message.Name = "lbl_Message";
			lbl_Message.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Message.Size = new System.Drawing.Size(283, 25);
			lbl_Message.TabIndex = 29;
			lbl_Message.Text = "Launch Notes";
			// 
			// Label4
			// 
			Label4.AllowDrop = true;
			Label4.BackColor = System.Drawing.Color.Transparent;
			Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			Label4.Location = new System.Drawing.Point(86, 208);
			Label4.MinimumSize = new System.Drawing.Size(111, 13);
			Label4.Name = "Label4";
			Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label4.Size = new System.Drawing.Size(111, 13);
			Label4.TabIndex = 27;
			Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_Email_Address
			// 
			lbl_Email_Address.AllowDrop = true;
			lbl_Email_Address.AutoSize = true;
			lbl_Email_Address.BackColor = System.Drawing.Color.Transparent;
			lbl_Email_Address.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Email_Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Email_Address.ForeColor = System.Drawing.Color.White;
			lbl_Email_Address.Location = new System.Drawing.Point(128, 200);
			lbl_Email_Address.MinimumSize = new System.Drawing.Size(40, 16);
			lbl_Email_Address.Name = "lbl_Email_Address";
			lbl_Email_Address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Email_Address.Size = new System.Drawing.Size(40, 16);
			lbl_Email_Address.TabIndex = 39;
			lbl_Email_Address.Text = "Email :";
			// 
			// lblServer
			// 
			lblServer.AllowDrop = true;
			lblServer.AutoSize = true;
			lblServer.BackColor = System.Drawing.Color.Transparent;
			lblServer.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblServer.ForeColor = System.Drawing.Color.White;
			lblServer.Location = new System.Drawing.Point(176, 262);
			lblServer.MinimumSize = new System.Drawing.Size(40, 16);
			lblServer.Name = "lblServer";
			lblServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblServer.Size = new System.Drawing.Size(40, 16);
			lblServer.TabIndex = 38;
			lblServer.Text = "Server";
			// 
			// lblServerLabel
			// 
			lblServerLabel.AllowDrop = true;
			lblServerLabel.AutoSize = true;
			lblServerLabel.BackColor = System.Drawing.Color.Transparent;
			lblServerLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblServerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblServerLabel.ForeColor = System.Drawing.Color.White;
			lblServerLabel.Location = new System.Drawing.Point(124, 262);
			lblServerLabel.MinimumSize = new System.Drawing.Size(43, 16);
			lblServerLabel.Name = "lblServerLabel";
			lblServerLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblServerLabel.Size = new System.Drawing.Size(43, 16);
			lblServerLabel.TabIndex = 37;
			lblServerLabel.Text = "Server:";
			// 
			// lblVersionLable
			// 
			lblVersionLable.AllowDrop = true;
			lblVersionLable.AutoSize = true;
			lblVersionLable.BackColor = System.Drawing.Color.Transparent;
			lblVersionLable.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblVersionLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblVersionLable.ForeColor = System.Drawing.Color.White;
			lblVersionLable.Location = new System.Drawing.Point(120, 241);
			lblVersionLable.MinimumSize = new System.Drawing.Size(49, 16);
			lblVersionLable.Name = "lblVersionLable";
			lblVersionLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblVersionLable.Size = new System.Drawing.Size(49, 16);
			lblVersionLable.TabIndex = 36;
			lblVersionLable.Text = "Version:";
			// 
			// lblVersion
			// 
			lblVersion.AllowDrop = true;
			lblVersion.AutoSize = true;
			lblVersion.BackColor = System.Drawing.Color.Transparent;
			lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblVersion.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
			lblVersion.Location = new System.Drawing.Point(176, 242);
			lblVersion.MinimumSize = new System.Drawing.Size(46, 16);
			lblVersion.Name = "lblVersion";
			lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblVersion.Size = new System.Drawing.Size(46, 16);
			lblVersion.TabIndex = 35;
			lblVersion.Text = "Version";
			// 
			// lblDate
			// 
			lblDate.AllowDrop = true;
			lblDate.AutoSize = true;
			lblDate.BackColor = System.Drawing.Color.Transparent;
			lblDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDate.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lblDate.Location = new System.Drawing.Point(176, 221);
			lblDate.MinimumSize = new System.Drawing.Size(29, 16);
			lblDate.Name = "lblDate";
			lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDate.Size = new System.Drawing.Size(29, 16);
			lblDate.TabIndex = 34;
			lblDate.Text = "Date";
			// 
			// lbl_DatabaseType
			// 
			lbl_DatabaseType.AllowDrop = true;
			lbl_DatabaseType.AutoSize = true;
			lbl_DatabaseType.BackColor = System.Drawing.Color.Black;
			lbl_DatabaseType.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_DatabaseType.Font = new System.Drawing.Font("Verdana", 24f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_DatabaseType.ForeColor = System.Drawing.Color.Red;
			lbl_DatabaseType.Location = new System.Drawing.Point(100, 642);
			lbl_DatabaseType.MinimumSize = new System.Drawing.Size(572, 41);
			lbl_DatabaseType.Name = "lbl_DatabaseType";
			lbl_DatabaseType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_DatabaseType.Size = new System.Drawing.Size(572, 41);
			lbl_DatabaseType.TabIndex = 9;
			lbl_DatabaseType.Text = "Live System";
			lbl_DatabaseType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_Welcome
			// 
			lbl_Welcome.AllowDrop = true;
			lbl_Welcome.AutoSize = true;
			lbl_Welcome.BackColor = System.Drawing.Color.Transparent;
			lbl_Welcome.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Welcome.Font = new System.Drawing.Font("Arial", 22.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Welcome.ForeColor = System.Drawing.Color.White;
			lbl_Welcome.Location = new System.Drawing.Point(384, 451);
			lbl_Welcome.MinimumSize = new System.Drawing.Size(134, 35);
			lbl_Welcome.Name = "lbl_Welcome";
			lbl_Welcome.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Welcome.Size = new System.Drawing.Size(134, 35);
			lbl_Welcome.TabIndex = 8;
			lbl_Welcome.Text = "Welcome";
			lbl_Welcome.Visible = false;
			// 
			// lblDateLabel
			// 
			lblDateLabel.AllowDrop = true;
			lblDateLabel.AutoSize = true;
			lblDateLabel.BackColor = System.Drawing.Color.Transparent;
			lblDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDateLabel.ForeColor = System.Drawing.Color.White;
			lblDateLabel.Location = new System.Drawing.Point(88, 220);
			lblDateLabel.MinimumSize = new System.Drawing.Size(81, 16);
			lblDateLabel.Name = "lblDateLabel";
			lblDateLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDateLabel.Size = new System.Drawing.Size(81, 16);
			lblDateLabel.TabIndex = 7;
			lblDateLabel.Text = "Version Date:";
			// 
			// img_Company
			// 
			img_Company.AllowDrop = true;
			img_Company.BorderStyle = System.Windows.Forms.BorderStyle.None;
			img_Company.Enabled = true;
			img_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			img_Company.Image = (System.Drawing.Image) resources.GetObject("img_Company.Image");
			img_Company.Location = new System.Drawing.Point(656, 200);
			img_Company.Name = "img_Company";
			img_Company.Size = new System.Drawing.Size(211, 28);
			img_Company.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			img_Company.Visible = true;
			img_Company.Click += new System.EventHandler(img_Company_Click);
			// 
			// img_Accounts
			// 
			img_Accounts.AllowDrop = true;
			img_Accounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
			img_Accounts.Enabled = true;
			img_Accounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			img_Accounts.Image = (System.Drawing.Image) resources.GetObject("img_Accounts.Image");
			img_Accounts.Location = new System.Drawing.Point(680, 256);
			img_Accounts.Name = "img_Accounts";
			img_Accounts.Size = new System.Drawing.Size(222, 28);
			img_Accounts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			img_Accounts.Visible = true;
			img_Accounts.Click += new System.EventHandler(img_Accounts_Click);
			// 
			// img_Callbacks
			// 
			img_Callbacks.AllowDrop = true;
			img_Callbacks.BorderStyle = System.Windows.Forms.BorderStyle.None;
			img_Callbacks.Enabled = true;
			img_Callbacks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			img_Callbacks.Image = (System.Drawing.Image) resources.GetObject("img_Callbacks.Image");
			img_Callbacks.Location = new System.Drawing.Point(888, 56);
			img_Callbacks.Name = "img_Callbacks";
			img_Callbacks.Size = new System.Drawing.Size(104, 28);
			img_Callbacks.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			img_Callbacks.Visible = true;
			img_Callbacks.Click += new System.EventHandler(img_Callbacks_Click);
			// 
			// img_Administration
			// 
			img_Administration.AllowDrop = true;
			img_Administration.BorderStyle = System.Windows.Forms.BorderStyle.None;
			img_Administration.Enabled = true;
			img_Administration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			img_Administration.Image = (System.Drawing.Image) resources.GetObject("img_Administration.Image");
			img_Administration.Location = new System.Drawing.Point(834, 304);
			img_Administration.Name = "img_Administration";
			img_Administration.Size = new System.Drawing.Size(146, 28);
			img_Administration.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			img_Administration.Visible = false;
			img_Administration.Click += new System.EventHandler(img_Administration_Click);
			// 
			// img_Aircraft_Model
			// 
			img_Aircraft_Model.AllowDrop = true;
			img_Aircraft_Model.BorderStyle = System.Windows.Forms.BorderStyle.None;
			img_Aircraft_Model.Enabled = true;
			img_Aircraft_Model.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			img_Aircraft_Model.Image = (System.Drawing.Image) resources.GetObject("img_Aircraft_Model.Image");
			img_Aircraft_Model.Location = new System.Drawing.Point(728, 144);
			img_Aircraft_Model.Name = "img_Aircraft_Model";
			img_Aircraft_Model.Size = new System.Drawing.Size(148, 26);
			img_Aircraft_Model.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			img_Aircraft_Model.Visible = true;
			img_Aircraft_Model.Click += new System.EventHandler(img_Aircraft_Model_Click);
			// 
			// img_Aircraft
			// 
			img_Aircraft.AllowDrop = true;
			img_Aircraft.BorderStyle = System.Windows.Forms.BorderStyle.None;
			img_Aircraft.Enabled = true;
			img_Aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			img_Aircraft.Image = (System.Drawing.Image) resources.GetObject("img_Aircraft.Image");
			img_Aircraft.Location = new System.Drawing.Point(832, 96);
			img_Aircraft.Name = "img_Aircraft";
			img_Aircraft.Size = new System.Drawing.Size(87, 27);
			img_Aircraft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			img_Aircraft.Visible = true;
			img_Aircraft.Click += new System.EventHandler(img_Aircraft_Click);
			// 
			// img_Main
			// 
			img_Main.AllowDrop = true;
			img_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			img_Main.Enabled = true;
			img_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			img_Main.Image = (System.Drawing.Image) resources.GetObject("img_Main.Image");
			img_Main.Location = new System.Drawing.Point(2, 24);
			img_Main.Name = "img_Main";
			img_Main.Size = new System.Drawing.Size(1035, 752);
			img_Main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			img_Main.Visible = true;
			// 
			// frm_Main_Menu
			// 
			AcceptButton = cmd_login;
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Window;
			CancelButton = cmd_cancel;
			ClientSize = new System.Drawing.Size(1007, 704);
			ControlBox = false;
			Controls.Add(pnl_Database);
			Controls.Add(pnl_Login);
			Controls.Add(pnl_Status);
			Controls.Add(lbl_Email_Address);
			Controls.Add(lblServer);
			Controls.Add(lblServerLabel);
			Controls.Add(lblVersionLable);
			Controls.Add(lblVersion);
			Controls.Add(lblDate);
			Controls.Add(lbl_DatabaseType);
			Controls.Add(lbl_Welcome);
			Controls.Add(lblDateLabel);
			Controls.Add(img_Company);
			Controls.Add(img_Accounts);
			Controls.Add(img_Callbacks);
			Controls.Add(img_Administration);
			Controls.Add(img_Aircraft_Model);
			Controls.Add(img_Aircraft);
			Controls.Add(img_Main);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			Icon = (System.Drawing.Icon) resources.GetObject("frm_Main_Menu.Icon");
			KeyPreview = true;
			Location = new System.Drawing.Point(470, 220);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Main_Menu";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Main Menu";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(cmd_db_cancel, 0);
			commandButtonHelper1.SetStyle(cmd_Set_JETNET, 0);
			commandButtonHelper1.SetStyle(cmd_cancel, 0);
			commandButtonHelper1.SetStyle(cmd_login, 0);
			commandButtonHelper1.SetStyle(cmd_Logout, 0);
			optionButtonHelper1.SetStyle(opt_Server, 0);
			optionButtonHelper1.SetStyle(_OptDatabase_0, 0);
			optionButtonHelper1.SetStyle(_OptDatabase_1, 0);
			ToolTipMain.SetToolTip(img_Company, "Search for Companies and Contacts of Interest");
			ToolTipMain.SetToolTip(img_Accounts, "Review and Edit Account Representative Assignments");
			ToolTipMain.SetToolTip(img_Callbacks, "Review and Select Companies for Aircraft Research Callbacks");
			ToolTipMain.SetToolTip(img_Administration, "Review and Edit Research Assistant Lookup Tables and Administrative Files");
			ToolTipMain.SetToolTip(img_Aircraft_Model, "Review and Edit Aircraft Model Information - Including Data Comprising Reference Cards");
			ToolTipMain.SetToolTip(img_Aircraft, "Search for Aircraft of Interest");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			KeyPress += new System.Windows.Forms.KeyPressEventHandler(Form_KeyPress);
			KeyUp += new System.Windows.Forms.KeyEventHandler(Form_KeyUp);
			pnl_Database.ResumeLayout(false);
			pnl_Database.PerformLayout();
			pnl_Login.ResumeLayout(false);
			pnl_Login.PerformLayout();
			pnl_Status.ResumeLayout(false);
			pnl_Status.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			InitializeOptDatabase();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = JETNET_Homebase.mdi_ResearchAssistant.DefInstance;
			JETNET_Homebase.mdi_ResearchAssistant.DefInstance.Show();
			Form_Initialize();
		}
		void InitializeOptDatabase()
		{
			OptDatabase = new System.Windows.Forms.RadioButton[2];
			OptDatabase[0] = _OptDatabase_0;
			OptDatabase[1] = _OptDatabase_1;
		}
		#endregion
	}
}