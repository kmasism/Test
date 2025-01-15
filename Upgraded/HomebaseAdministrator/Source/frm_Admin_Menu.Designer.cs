
namespace HomebaseAdministrator
{
	partial class frm_Admin_Menu
	{

		#region "Upgrade Support "
		private static frm_Admin_Menu m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Admin_Menu DefInstance
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
		public static frm_Admin_Menu CreateInstance()
		{
			frm_Admin_Menu theInstance = new frm_Admin_Menu();
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
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileDatabase", "mnuReLogin", "mnuFileLogout", "mnuFile", "mnuInstall", "mnuTomorrow", "mnuNewRelease", "mnuJunk", "mnuTools", "mnuHelp", "MainMenu1", "Lb_Common", "lb_contact", "lb_aircraft", "Command1", "cmd_Set_JETNET", "cmd_db_cancel", "opt_Server", "txt_db_password", "txt_db_login", "txt_ip_address", "Label5", "Label3", "Label1", "pnl_Database", "_OptDatabase_0", "_OptDatabase_1", "txt_database_name", "txt_login_ID", "txt_login_password", "cmd_login", "cmd_cancel", "Label2", "lbl_login_message", "lbl_login_ID", "lbl_login_password", "lbl_try_count", "pnl_Login", "cmd_Logout", "lbl_Message", "lbl_user_id", "lbl_User_Name", "lbl_user_type", "Label4", "lblDatabase", "pnl_Status", "lblServerLabel", "lblServer", "lblVersion", "lblVersionLable", "Lb_administrator", "lbl_DatabaseType", "lbl_Welcome", "lblDateLabel", "lblDate", "OptDatabase", "optionButtonHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileDatabase;
		public System.Windows.Forms.ToolStripMenuItem mnuReLogin;
		public System.Windows.Forms.ToolStripMenuItem mnuFileLogout;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.ToolStripMenuItem mnuInstall;
		public System.Windows.Forms.ToolStripMenuItem mnuTomorrow;
		public System.Windows.Forms.ToolStripMenuItem mnuNewRelease;
		public System.Windows.Forms.ToolStripMenuItem mnuJunk;
		public System.Windows.Forms.ToolStripMenuItem mnuTools;
		public System.Windows.Forms.ToolStripMenuItem mnuHelp;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.Button Lb_Common;
		public System.Windows.Forms.Button lb_contact;
		public System.Windows.Forms.Button lb_aircraft;
		public System.Windows.Forms.Button Command1;
		public System.Windows.Forms.Button cmd_Set_JETNET;
		public System.Windows.Forms.Button cmd_db_cancel;
		public System.Windows.Forms.RadioButton opt_Server;
		public System.Windows.Forms.TextBox txt_db_password;
		public System.Windows.Forms.TextBox txt_db_login;
		public System.Windows.Forms.TextBox txt_ip_address;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Panel pnl_Database;
		private System.Windows.Forms.RadioButton _OptDatabase_0;
		private System.Windows.Forms.RadioButton _OptDatabase_1;
		public System.Windows.Forms.TextBox txt_database_name;
		public System.Windows.Forms.TextBox txt_login_ID;
		public System.Windows.Forms.TextBox txt_login_password;
		public System.Windows.Forms.Button cmd_login;
		public System.Windows.Forms.Button cmd_cancel;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lbl_login_message;
		public System.Windows.Forms.Label lbl_login_ID;
		public System.Windows.Forms.Label lbl_login_password;
		public System.Windows.Forms.Label lbl_try_count;
		public System.Windows.Forms.Panel pnl_Login;
		public System.Windows.Forms.Button cmd_Logout;
		public System.Windows.Forms.Label lbl_Message;
		public System.Windows.Forms.Label lbl_user_id;
		public System.Windows.Forms.Label lbl_User_Name;
		public System.Windows.Forms.Label lbl_user_type;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label lblDatabase;
		public System.Windows.Forms.Panel pnl_Status;
		public System.Windows.Forms.Label lblServerLabel;
		public System.Windows.Forms.Label lblServer;
		public System.Windows.Forms.Label lblVersion;
		public System.Windows.Forms.Label lblVersionLable;
		public System.Windows.Forms.Label Lb_administrator;
		public System.Windows.Forms.Label lbl_DatabaseType;
		public System.Windows.Forms.Label lbl_Welcome;
		public System.Windows.Forms.Label lblDateLabel;
		public System.Windows.Forms.Label lblDate;
		public System.Windows.Forms.RadioButton[] OptDatabase = new System.Windows.Forms.RadioButton[2];
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Admin_Menu));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileDatabase = new System.Windows.Forms.ToolStripMenuItem();
			mnuReLogin = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileLogout = new System.Windows.Forms.ToolStripMenuItem();
			mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			mnuInstall = new System.Windows.Forms.ToolStripMenuItem();
			mnuTomorrow = new System.Windows.Forms.ToolStripMenuItem();
			mnuNewRelease = new System.Windows.Forms.ToolStripMenuItem();
			mnuJunk = new System.Windows.Forms.ToolStripMenuItem();
			mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			Lb_Common = new System.Windows.Forms.Button();
			lb_contact = new System.Windows.Forms.Button();
			lb_aircraft = new System.Windows.Forms.Button();
			Command1 = new System.Windows.Forms.Button();
			pnl_Database = new System.Windows.Forms.Panel();
			cmd_Set_JETNET = new System.Windows.Forms.Button();
			cmd_db_cancel = new System.Windows.Forms.Button();
			opt_Server = new System.Windows.Forms.RadioButton();
			txt_db_password = new System.Windows.Forms.TextBox();
			txt_db_login = new System.Windows.Forms.TextBox();
			txt_ip_address = new System.Windows.Forms.TextBox();
			Label5 = new System.Windows.Forms.Label();
			Label3 = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			pnl_Login = new System.Windows.Forms.Panel();
			_OptDatabase_0 = new System.Windows.Forms.RadioButton();
			_OptDatabase_1 = new System.Windows.Forms.RadioButton();
			txt_database_name = new System.Windows.Forms.TextBox();
			txt_login_ID = new System.Windows.Forms.TextBox();
			txt_login_password = new System.Windows.Forms.TextBox();
			cmd_login = new System.Windows.Forms.Button();
			cmd_cancel = new System.Windows.Forms.Button();
			Label2 = new System.Windows.Forms.Label();
			lbl_login_message = new System.Windows.Forms.Label();
			lbl_login_ID = new System.Windows.Forms.Label();
			lbl_login_password = new System.Windows.Forms.Label();
			lbl_try_count = new System.Windows.Forms.Label();
			pnl_Status = new System.Windows.Forms.Panel();
			cmd_Logout = new System.Windows.Forms.Button();
			lbl_Message = new System.Windows.Forms.Label();
			lbl_user_id = new System.Windows.Forms.Label();
			lbl_User_Name = new System.Windows.Forms.Label();
			lbl_user_type = new System.Windows.Forms.Label();
			Label4 = new System.Windows.Forms.Label();
			lblDatabase = new System.Windows.Forms.Label();
			lblServerLabel = new System.Windows.Forms.Label();
			lblServer = new System.Windows.Forms.Label();
			lblVersion = new System.Windows.Forms.Label();
			lblVersionLable = new System.Windows.Forms.Label();
			Lb_administrator = new System.Windows.Forms.Label();
			lbl_DatabaseType = new System.Windows.Forms.Label();
			lbl_Welcome = new System.Windows.Forms.Label();
			lblDateLabel = new System.Windows.Forms.Label();
			lblDate = new System.Windows.Forms.Label();
			pnl_Database.SuspendLayout();
			pnl_Login.SuspendLayout();
			pnl_Status.SuspendLayout();
			SuspendLayout();
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
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
			mnuFile.Text = "&File";
			mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFileDatabase, mnuReLogin, mnuFileLogout});
			// 
			// mnuFileDatabase
			// 
			mnuFileDatabase.Available = true;
			mnuFileDatabase.Checked = false;
			mnuFileDatabase.Enabled = true;
			mnuFileDatabase.Name = "mnuFileDatabase";
			mnuFileDatabase.Text = "Database &Settings";
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
			mnuFileLogout.Text = "&Logout";
			mnuFileLogout.Click += new System.EventHandler(mnuFileLogout_Click);
			// 
			// mnuTools
			// 
			mnuTools.Available = true;
			mnuTools.Checked = false;
			mnuTools.Enabled = true;
			mnuTools.Name = "mnuTools";
			mnuTools.Text = "&Tools";
			mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuInstall, mnuTomorrow, mnuNewRelease, mnuJunk});
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
			// mnuNewRelease
			// 
			mnuNewRelease.Available = false;
			mnuNewRelease.Checked = false;
			mnuNewRelease.Enabled = true;
			mnuNewRelease.Name = "mnuNewRelease";
			mnuNewRelease.Text = "Give Everyone New Release";
			mnuNewRelease.Click += new System.EventHandler(mnuNewRelease_Click);
			// 
			// mnuJunk
			// 
			mnuJunk.Available = false;
			mnuJunk.Checked = false;
			mnuJunk.Enabled = true;
			mnuJunk.Name = "mnuJunk";
			mnuJunk.Text = "&Junk Form";
			// 
			// mnuHelp
			// 
			mnuHelp.Available = true;
			mnuHelp.Checked = false;
			mnuHelp.Enabled = true;
			mnuHelp.Name = "mnuHelp";
			mnuHelp.Text = "&Help";
			mnuHelp.Click += new System.EventHandler(mnuHelp_Click);
			// 
			// Lb_Common
			// 
			Lb_Common.AllowDrop = true;
			Lb_Common.BackColor = System.Drawing.SystemColors.Control;
			Lb_Common.Font = new System.Drawing.Font("Arial", 18f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Lb_Common.ForeColor = System.Drawing.SystemColors.ControlText;
			Lb_Common.Location = new System.Drawing.Point(313, 320);
			Lb_Common.Name = "Lb_Common";
			Lb_Common.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Lb_Common.Size = new System.Drawing.Size(368, 50);
			Lb_Common.TabIndex = 37;
			Lb_Common.Text = "Common &Tables / Processes";
			Lb_Common.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			Lb_Common.UseVisualStyleBackColor = false;
			Lb_Common.Visible = false;
			Lb_Common.Click += new System.EventHandler(Lb_Common_Click);
			// 
			// lb_contact
			// 
			lb_contact.AllowDrop = true;
			lb_contact.BackColor = System.Drawing.SystemColors.Control;
			lb_contact.Font = new System.Drawing.Font("Arial", 18f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lb_contact.ForeColor = System.Drawing.SystemColors.ControlText;
			lb_contact.Location = new System.Drawing.Point(313, 248);
			lb_contact.Name = "lb_contact";
			lb_contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lb_contact.Size = new System.Drawing.Size(368, 50);
			lb_contact.TabIndex = 36;
			lb_contact.Text = "&Company / Contact";
			lb_contact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			lb_contact.UseVisualStyleBackColor = false;
			lb_contact.Visible = false;
			lb_contact.Click += new System.EventHandler(lb_contact_Click);
			// 
			// lb_aircraft
			// 
			lb_aircraft.AllowDrop = true;
			lb_aircraft.BackColor = System.Drawing.SystemColors.Control;
			lb_aircraft.Font = new System.Drawing.Font("Arial", 18f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lb_aircraft.ForeColor = System.Drawing.SystemColors.ControlText;
			lb_aircraft.Location = new System.Drawing.Point(313, 184);
			lb_aircraft.Name = "lb_aircraft";
			lb_aircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lb_aircraft.Size = new System.Drawing.Size(368, 50);
			lb_aircraft.TabIndex = 35;
			lb_aircraft.Text = "&Aircraft";
			lb_aircraft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			lb_aircraft.UseVisualStyleBackColor = false;
			lb_aircraft.Visible = false;
			lb_aircraft.Click += new System.EventHandler(lb_aircraft_Click);
			// 
			// Command1
			// 
			Command1.AllowDrop = true;
			Command1.BackColor = System.Drawing.SystemColors.Control;
			Command1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			Command1.Location = new System.Drawing.Point(35, 607);
			Command1.Name = "Command1";
			Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Command1.Size = new System.Drawing.Size(222, 28);
			Command1.TabIndex = 31;
			Command1.Text = "Update All Company Search Fields";
			Command1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			Command1.UseVisualStyleBackColor = false;
			Command1.Visible = false;
			// 
			// pnl_Database
			// 
			pnl_Database.AllowDrop = true;
			pnl_Database.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Database.Controls.Add(cmd_Set_JETNET);
			pnl_Database.Controls.Add(cmd_db_cancel);
			pnl_Database.Controls.Add(opt_Server);
			pnl_Database.Controls.Add(txt_db_password);
			pnl_Database.Controls.Add(txt_db_login);
			pnl_Database.Controls.Add(txt_ip_address);
			pnl_Database.Controls.Add(Label5);
			pnl_Database.Controls.Add(Label3);
			pnl_Database.Controls.Add(Label1);
			pnl_Database.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Database.Location = new System.Drawing.Point(713, 295);
			pnl_Database.Name = "pnl_Database";
			pnl_Database.Size = new System.Drawing.Size(289, 169);
			pnl_Database.TabIndex = 16;
			// 
			// cmd_Set_JETNET
			// 
			cmd_Set_JETNET.AllowDrop = true;
			cmd_Set_JETNET.BackColor = System.Drawing.SystemColors.Control;
			cmd_Set_JETNET.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Set_JETNET.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Set_JETNET.Location = new System.Drawing.Point(167, 144);
			cmd_Set_JETNET.Name = "cmd_Set_JETNET";
			cmd_Set_JETNET.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Set_JETNET.Size = new System.Drawing.Size(89, 17);
			cmd_Set_JETNET.TabIndex = 25;
			cmd_Set_JETNET.Text = "Set JETNET";
			cmd_Set_JETNET.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Set_JETNET.UseVisualStyleBackColor = false;
			cmd_Set_JETNET.Click += new System.EventHandler(cmd_Set_JETNET_Click);
			// 
			// cmd_db_cancel
			// 
			cmd_db_cancel.AllowDrop = true;
			cmd_db_cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_db_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_db_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_db_cancel.Location = new System.Drawing.Point(15, 144);
			cmd_db_cancel.Name = "cmd_db_cancel";
			cmd_db_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_db_cancel.Size = new System.Drawing.Size(65, 17);
			cmd_db_cancel.TabIndex = 24;
			cmd_db_cancel.Text = "Cancel";
			cmd_db_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_db_cancel.UseVisualStyleBackColor = false;
			cmd_db_cancel.Click += new System.EventHandler(cmd_db_cancel_Click);
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
			opt_Server.Location = new System.Drawing.Point(16, 112);
			opt_Server.Name = "opt_Server";
			opt_Server.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_Server.Size = new System.Drawing.Size(177, 25);
			opt_Server.TabIndex = 23;
			opt_Server.TabStop = true;
			opt_Server.Text = "Connect to Server Database";
			opt_Server.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Server.Visible = true;
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
			txt_db_password.Location = new System.Drawing.Point(72, 64);
			txt_db_password.MaxLength = 0;
			txt_db_password.Name = "txt_db_password";
			txt_db_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_db_password.Size = new System.Drawing.Size(153, 19);
			txt_db_password.TabIndex = 19;
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
			txt_db_login.Location = new System.Drawing.Point(72, 40);
			txt_db_login.MaxLength = 0;
			txt_db_login.Name = "txt_db_login";
			txt_db_login.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_db_login.Size = new System.Drawing.Size(129, 19);
			txt_db_login.TabIndex = 18;
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
			txt_ip_address.Location = new System.Drawing.Point(71, 16);
			txt_ip_address.MaxLength = 0;
			txt_ip_address.Name = "txt_ip_address";
			txt_ip_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ip_address.Size = new System.Drawing.Size(201, 19);
			txt_ip_address.TabIndex = 17;
			// 
			// Label5
			// 
			Label5.AllowDrop = true;
			Label5.BackColor = System.Drawing.Color.Transparent;
			Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			Label5.Location = new System.Drawing.Point(8, 64);
			Label5.MinimumSize = new System.Drawing.Size(73, 33);
			Label5.Name = "Label5";
			Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label5.Size = new System.Drawing.Size(73, 33);
			Label5.TabIndex = 22;
			Label5.Text = "Password:";
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.BackColor = System.Drawing.Color.Transparent;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(8, 40);
			Label3.MinimumSize = new System.Drawing.Size(73, 33);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(73, 33);
			Label3.TabIndex = 21;
			Label3.Text = "Login:";
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.AutoSize = true;
			Label1.BackColor = System.Drawing.Color.Transparent;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(8, 16);
			Label1.MinimumSize = new System.Drawing.Size(54, 13);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(54, 13);
			Label1.TabIndex = 20;
			Label1.Text = "IP Address:";
			// 
			// pnl_Login
			// 
			pnl_Login.AllowDrop = true;
			pnl_Login.BorderStyle = System.Windows.Forms.BorderStyle.None;
			pnl_Login.Controls.Add(_OptDatabase_0);
			pnl_Login.Controls.Add(_OptDatabase_1);
			pnl_Login.Controls.Add(txt_database_name);
			pnl_Login.Controls.Add(txt_login_ID);
			pnl_Login.Controls.Add(txt_login_password);
			pnl_Login.Controls.Add(cmd_login);
			pnl_Login.Controls.Add(cmd_cancel);
			pnl_Login.Controls.Add(Label2);
			pnl_Login.Controls.Add(lbl_login_message);
			pnl_Login.Controls.Add(lbl_login_ID);
			pnl_Login.Controls.Add(lbl_login_password);
			pnl_Login.Controls.Add(lbl_try_count);
			pnl_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Login.Location = new System.Drawing.Point(680, 511);
			pnl_Login.Name = "pnl_Login";
			pnl_Login.Size = new System.Drawing.Size(305, 195);
			pnl_Login.TabIndex = 2;
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
			_OptDatabase_0.Location = new System.Drawing.Point(195, 149);
			_OptDatabase_0.Name = "_OptDatabase_0";
			_OptDatabase_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_OptDatabase_0.Size = new System.Drawing.Size(64, 13);
			_OptDatabase_0.TabIndex = 39;
			_OptDatabase_0.TabStop = true;
			_OptDatabase_0.Text = "Aircraft";
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
			_OptDatabase_1.Location = new System.Drawing.Point(106, 149);
			_OptDatabase_1.Name = "_OptDatabase_1";
			_OptDatabase_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_OptDatabase_1.Size = new System.Drawing.Size(89, 14);
			_OptDatabase_1.TabIndex = 38;
			_OptDatabase_1.TabStop = true;
			_OptDatabase_1.Text = "Commerical";
			_OptDatabase_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_OptDatabase_1.Visible = false;
			_OptDatabase_1.CheckedChanged += new System.EventHandler(OptDatabase_CheckedChanged);
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
			txt_database_name.Location = new System.Drawing.Point(113, 78);
			txt_database_name.MaxLength = 0;
			txt_database_name.Name = "txt_database_name";
			txt_database_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_database_name.Size = new System.Drawing.Size(129, 19);
			txt_database_name.TabIndex = 29;
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
			txt_login_ID.Location = new System.Drawing.Point(112, 102);
			txt_login_ID.MaxLength = 0;
			txt_login_ID.Name = "txt_login_ID";
			txt_login_ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_login_ID.Size = new System.Drawing.Size(55, 19);
			txt_login_ID.TabIndex = 0;
			txt_login_ID.Leave += new System.EventHandler(txt_login_ID_Leave);
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
			txt_login_password.Location = new System.Drawing.Point(113, 126);
			txt_login_password.MaxLength = 0;
			txt_login_password.Name = "txt_login_password";
			txt_login_password.PasswordChar = (char) 42;
			txt_login_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_login_password.Size = new System.Drawing.Size(143, 19);
			txt_login_password.TabIndex = 1;
			txt_login_password.Visible = false;
			// 
			// cmd_login
			// 
			cmd_login.AllowDrop = true;
			cmd_login.BackColor = System.Drawing.SystemColors.Control;
			cmd_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_login.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_login.Location = new System.Drawing.Point(115, 163);
			cmd_login.Name = "cmd_login";
			cmd_login.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_login.Size = new System.Drawing.Size(69, 23);
			cmd_login.TabIndex = 3;
			cmd_login.Text = "&LOGIN";
			cmd_login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_login.UseVisualStyleBackColor = false;
			cmd_login.Click += new System.EventHandler(cmd_login_Click);
			// 
			// cmd_cancel
			// 
			cmd_cancel.AllowDrop = true;
			cmd_cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_cancel.Location = new System.Drawing.Point(196, 164);
			cmd_cancel.Name = "cmd_cancel";
			cmd_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_cancel.Size = new System.Drawing.Size(65, 23);
			cmd_cancel.TabIndex = 4;
			cmd_cancel.Text = "CANCEL";
			cmd_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_cancel.UseVisualStyleBackColor = false;
			cmd_cancel.Click += new System.EventHandler(cmd_Cancel_Click);
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.BackColor = System.Drawing.Color.Transparent;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			Label2.Location = new System.Drawing.Point(32, 78);
			Label2.MinimumSize = new System.Drawing.Size(73, 33);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(73, 33);
			Label2.TabIndex = 30;
			Label2.Text = "Database:";
			// 
			// lbl_login_message
			// 
			lbl_login_message.AllowDrop = true;
			lbl_login_message.BackColor = System.Drawing.Color.Transparent;
			lbl_login_message.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_login_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_login_message.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_login_message.Location = new System.Drawing.Point(11, 7);
			lbl_login_message.MinimumSize = new System.Drawing.Size(289, 59);
			lbl_login_message.Name = "lbl_login_message";
			lbl_login_message.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_login_message.Size = new System.Drawing.Size(289, 59);
			lbl_login_message.TabIndex = 8;
			lbl_login_message.Text = "Login Message";
			lbl_login_message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_login_ID
			// 
			lbl_login_ID.AllowDrop = true;
			lbl_login_ID.BackColor = System.Drawing.Color.Transparent;
			lbl_login_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_login_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_login_ID.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_login_ID.Location = new System.Drawing.Point(33, 106);
			lbl_login_ID.MinimumSize = new System.Drawing.Size(111, 13);
			lbl_login_ID.Name = "lbl_login_ID";
			lbl_login_ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_login_ID.Size = new System.Drawing.Size(111, 13);
			lbl_login_ID.TabIndex = 7;
			lbl_login_ID.Text = "User ID";
			// 
			// lbl_login_password
			// 
			lbl_login_password.AllowDrop = true;
			lbl_login_password.BackColor = System.Drawing.Color.Transparent;
			lbl_login_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_login_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_login_password.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_login_password.Location = new System.Drawing.Point(33, 126);
			lbl_login_password.MinimumSize = new System.Drawing.Size(111, 13);
			lbl_login_password.Name = "lbl_login_password";
			lbl_login_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_login_password.Size = new System.Drawing.Size(111, 13);
			lbl_login_password.TabIndex = 6;
			lbl_login_password.Text = "Password";
			lbl_login_password.Visible = false;
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
			lbl_try_count.TabIndex = 5;
			lbl_try_count.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pnl_Status
			// 
			pnl_Status.AllowDrop = true;
			pnl_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
			pnl_Status.Controls.Add(cmd_Logout);
			pnl_Status.Controls.Add(lbl_Message);
			pnl_Status.Controls.Add(lbl_user_id);
			pnl_Status.Controls.Add(lbl_User_Name);
			pnl_Status.Controls.Add(lbl_user_type);
			pnl_Status.Controls.Add(Label4);
			pnl_Status.Controls.Add(lblDatabase);
			pnl_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Status.Location = new System.Drawing.Point(684, 508);
			pnl_Status.Name = "pnl_Status";
			pnl_Status.Size = new System.Drawing.Size(305, 194);
			pnl_Status.TabIndex = 9;
			// 
			// cmd_Logout
			// 
			cmd_Logout.AllowDrop = true;
			cmd_Logout.BackColor = System.Drawing.SystemColors.Control;
			cmd_Logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Logout.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Logout.Location = new System.Drawing.Point(123, 6);
			cmd_Logout.Name = "cmd_Logout";
			cmd_Logout.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Logout.Size = new System.Drawing.Size(69, 23);
			cmd_Logout.TabIndex = 15;
			cmd_Logout.Text = "LOGOUT";
			cmd_Logout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Logout.UseVisualStyleBackColor = false;
			cmd_Logout.Click += new System.EventHandler(cmd_Logout_Click);
			// 
			// lbl_Message
			// 
			lbl_Message.AllowDrop = true;
			lbl_Message.BackColor = System.Drawing.Color.Transparent;
			lbl_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Message.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_Message.Location = new System.Drawing.Point(-35, 129);
			lbl_Message.MinimumSize = new System.Drawing.Size(337, 33);
			lbl_Message.Name = "lbl_Message";
			lbl_Message.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Message.Size = new System.Drawing.Size(337, 33);
			lbl_Message.TabIndex = 14;
			lbl_Message.Text = "Launch Notes";
			lbl_Message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_user_id
			// 
			lbl_user_id.AllowDrop = true;
			lbl_user_id.BackColor = System.Drawing.Color.Transparent;
			lbl_user_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_user_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_user_id.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_user_id.Location = new System.Drawing.Point(-13, 38);
			lbl_user_id.MinimumSize = new System.Drawing.Size(337, 25);
			lbl_user_id.Name = "lbl_user_id";
			lbl_user_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_user_id.Size = new System.Drawing.Size(337, 25);
			lbl_user_id.TabIndex = 13;
			lbl_user_id.Text = "USER ID";
			lbl_user_id.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_User_Name
			// 
			lbl_User_Name.AllowDrop = true;
			lbl_User_Name.BackColor = System.Drawing.Color.Transparent;
			lbl_User_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_User_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_User_Name.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_User_Name.Location = new System.Drawing.Point(-13, 62);
			lbl_User_Name.MinimumSize = new System.Drawing.Size(337, 25);
			lbl_User_Name.Name = "lbl_User_Name";
			lbl_User_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_User_Name.Size = new System.Drawing.Size(337, 25);
			lbl_User_Name.TabIndex = 12;
			lbl_User_Name.Text = "USER NAME";
			lbl_User_Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_user_type
			// 
			lbl_user_type.AllowDrop = true;
			lbl_user_type.BackColor = System.Drawing.Color.Transparent;
			lbl_user_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_user_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_user_type.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lbl_user_type.Location = new System.Drawing.Point(-13, 86);
			lbl_user_type.MinimumSize = new System.Drawing.Size(337, 25);
			lbl_user_type.Name = "lbl_user_type";
			lbl_user_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_user_type.Size = new System.Drawing.Size(337, 25);
			lbl_user_type.TabIndex = 11;
			lbl_user_type.Text = "USER TYPE";
			lbl_user_type.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
			Label4.TabIndex = 10;
			Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblDatabase
			// 
			lblDatabase.AllowDrop = true;
			lblDatabase.BackColor = System.Drawing.Color.Transparent;
			lblDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDatabase.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
			lblDatabase.Location = new System.Drawing.Point(-12, 109);
			lblDatabase.MinimumSize = new System.Drawing.Size(337, 25);
			lblDatabase.Name = "lblDatabase";
			lblDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDatabase.Size = new System.Drawing.Size(337, 25);
			lblDatabase.TabIndex = 27;
			lblDatabase.Text = "DATABASE";
			lblDatabase.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblServerLabel
			// 
			lblServerLabel.AllowDrop = true;
			lblServerLabel.AutoSize = true;
			lblServerLabel.BackColor = System.Drawing.Color.Transparent;
			lblServerLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblServerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblServerLabel.ForeColor = System.Drawing.Color.Black;
			lblServerLabel.Location = new System.Drawing.Point(26, 704);
			lblServerLabel.MinimumSize = new System.Drawing.Size(51, 16);
			lblServerLabel.Name = "lblServerLabel";
			lblServerLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblServerLabel.Size = new System.Drawing.Size(51, 16);
			lblServerLabel.TabIndex = 43;
			lblServerLabel.Text = "Server:";
			// 
			// lblServer
			// 
			lblServer.AllowDrop = true;
			lblServer.AutoSize = true;
			lblServer.BackColor = System.Drawing.Color.Transparent;
			lblServer.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblServer.ForeColor = System.Drawing.Color.Black;
			lblServer.Location = new System.Drawing.Point(131, 705);
			lblServer.MinimumSize = new System.Drawing.Size(156, 16);
			lblServer.Name = "lblServer";
			lblServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblServer.Size = new System.Drawing.Size(156, 16);
			lblServer.TabIndex = 42;
			lblServer.Text = "Version";
			// 
			// lblVersion
			// 
			lblVersion.AllowDrop = true;
			lblVersion.AutoSize = true;
			lblVersion.BackColor = System.Drawing.Color.Transparent;
			lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblVersion.ForeColor = System.Drawing.Color.Black;
			lblVersion.Location = new System.Drawing.Point(131, 687);
			lblVersion.MinimumSize = new System.Drawing.Size(156, 16);
			lblVersion.Name = "lblVersion";
			lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblVersion.Size = new System.Drawing.Size(156, 16);
			lblVersion.TabIndex = 41;
			lblVersion.Text = "Version";
			// 
			// lblVersionLable
			// 
			lblVersionLable.AllowDrop = true;
			lblVersionLable.AutoSize = true;
			lblVersionLable.BackColor = System.Drawing.Color.Transparent;
			lblVersionLable.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblVersionLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblVersionLable.ForeColor = System.Drawing.Color.Black;
			lblVersionLable.Location = new System.Drawing.Point(26, 686);
			lblVersionLable.MinimumSize = new System.Drawing.Size(58, 16);
			lblVersionLable.Name = "lblVersionLable";
			lblVersionLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblVersionLable.Size = new System.Drawing.Size(58, 16);
			lblVersionLable.TabIndex = 40;
			lblVersionLable.Text = "Version:";
			// 
			// Lb_administrator
			// 
			Lb_administrator.AllowDrop = true;
			Lb_administrator.BackColor = System.Drawing.Color.Transparent;
			Lb_administrator.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Lb_administrator.Font = new System.Drawing.Font("Arial", 48f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Lb_administrator.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			Lb_administrator.Location = new System.Drawing.Point(3, 51);
			Lb_administrator.MinimumSize = new System.Drawing.Size(1006, 86);
			Lb_administrator.Name = "Lb_administrator";
			Lb_administrator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Lb_administrator.Size = new System.Drawing.Size(1006, 86);
			Lb_administrator.TabIndex = 34;
			Lb_administrator.Text = "Homebase Administrator";
			Lb_administrator.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_DatabaseType
			// 
			lbl_DatabaseType.AllowDrop = true;
			lbl_DatabaseType.AutoSize = true;
			lbl_DatabaseType.BackColor = System.Drawing.Color.Transparent;
			lbl_DatabaseType.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_DatabaseType.Font = new System.Drawing.Font("Arial", 24f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_DatabaseType.ForeColor = System.Drawing.Color.Red;
			lbl_DatabaseType.Location = new System.Drawing.Point(311, 515);
			lbl_DatabaseType.MinimumSize = new System.Drawing.Size(187, 37);
			lbl_DatabaseType.Name = "lbl_DatabaseType";
			lbl_DatabaseType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_DatabaseType.Size = new System.Drawing.Size(187, 37);
			lbl_DatabaseType.TabIndex = 33;
			lbl_DatabaseType.Text = "Live System";
			// 
			// lbl_Welcome
			// 
			lbl_Welcome.AllowDrop = true;
			lbl_Welcome.AutoSize = true;
			lbl_Welcome.BackColor = System.Drawing.Color.Transparent;
			lbl_Welcome.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Welcome.Font = new System.Drawing.Font("Arial", 22.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Welcome.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			lbl_Welcome.Location = new System.Drawing.Point(308, 457);
			lbl_Welcome.MinimumSize = new System.Drawing.Size(134, 36);
			lbl_Welcome.Name = "lbl_Welcome";
			lbl_Welcome.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Welcome.Size = new System.Drawing.Size(134, 36);
			lbl_Welcome.TabIndex = 32;
			lbl_Welcome.Text = "Welcome";
			lbl_Welcome.Visible = false;
			// 
			// lblDateLabel
			// 
			lblDateLabel.AllowDrop = true;
			lblDateLabel.AutoSize = true;
			lblDateLabel.BackColor = System.Drawing.Color.Transparent;
			lblDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDateLabel.ForeColor = System.Drawing.Color.Black;
			lblDateLabel.Location = new System.Drawing.Point(26, 667);
			lblDateLabel.MinimumSize = new System.Drawing.Size(95, 16);
			lblDateLabel.Name = "lblDateLabel";
			lblDateLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDateLabel.Size = new System.Drawing.Size(95, 16);
			lblDateLabel.TabIndex = 28;
			lblDateLabel.Text = "Version Date:";
			// 
			// lblDate
			// 
			lblDate.AllowDrop = true;
			lblDate.AutoSize = true;
			lblDate.BackColor = System.Drawing.Color.Transparent;
			lblDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDate.ForeColor = System.Drawing.Color.Black;
			lblDate.Location = new System.Drawing.Point(131, 668);
			lblDate.MinimumSize = new System.Drawing.Size(156, 16);
			lblDate.Name = "lblDate";
			lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDate.Size = new System.Drawing.Size(156, 16);
			lblDate.TabIndex = 26;
			lblDate.Text = "Date";
			// 
			// frm_Admin_Menu
			// 
			AcceptButton = cmd_login;
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			CancelButton = cmd_cancel;
			ClientSize = new System.Drawing.Size(1086, 726);
			ControlBox = false;
			Controls.Add(Lb_Common);
			Controls.Add(lb_contact);
			Controls.Add(lb_aircraft);
			Controls.Add(Command1);
			Controls.Add(pnl_Database);
			Controls.Add(pnl_Login);
			Controls.Add(pnl_Status);
			Controls.Add(lblServerLabel);
			Controls.Add(lblServer);
			Controls.Add(lblVersion);
			Controls.Add(lblVersionLable);
			Controls.Add(Lb_administrator);
			Controls.Add(lbl_DatabaseType);
			Controls.Add(lbl_Welcome);
			Controls.Add(lblDateLabel);
			Controls.Add(lblDate);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Icon = (System.Drawing.Icon) resources.GetObject("frm_Admin_Menu.Icon");
			KeyPreview = true;
			Location = new System.Drawing.Point(602, 214);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Admin_Menu";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Main Menu";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(Lb_Common, 0);
			commandButtonHelper1.SetStyle(lb_contact, 0);
			commandButtonHelper1.SetStyle(lb_aircraft, 0);
			commandButtonHelper1.SetStyle(Command1, 0);
			commandButtonHelper1.SetStyle(cmd_Set_JETNET, 0);
			commandButtonHelper1.SetStyle(cmd_db_cancel, 0);
			commandButtonHelper1.SetStyle(cmd_login, 0);
			commandButtonHelper1.SetStyle(cmd_cancel, 0);
			commandButtonHelper1.SetStyle(cmd_Logout, 0);
			optionButtonHelper1.SetStyle(opt_Server, 0);
			optionButtonHelper1.SetStyle(_OptDatabase_0, 0);
			optionButtonHelper1.SetStyle(_OptDatabase_1, 0);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			KeyPress += new System.Windows.Forms.KeyPressEventHandler(Form_KeyPress);
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
			MdiParent = HomebaseAdministrator.mdi_AdminAssistant.DefInstance;
			HomebaseAdministrator.mdi_AdminAssistant.DefInstance.Show();
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