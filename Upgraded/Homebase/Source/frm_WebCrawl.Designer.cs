
namespace JETNET_Homebase
{
	partial class frm_WebCrawl
	{

		#region "Upgrade Support "
		private static frm_WebCrawl m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_WebCrawl DefInstance
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
		public static frm_WebCrawl CreateInstance()
		{
			frm_WebCrawl theInstance = new frm_WebCrawl();
			theInstance.Form_Load();
			return theInstance;
		}
		private void Ctx_mnuEditCompletedCustSubData1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			Ctx_mnuEditCompletedCustSubData1.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach (System.Windows.Forms.ToolStripItem item in ((System.Windows.Forms.ToolStripMenuItem) mnuEditCompletedCustSubData1).DropDownItems)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				Ctx_mnuEditCompletedCustSubData1.Items.Add(item);
			}
			e.Cancel = false;
		}
		private void Ctx_mnuEditCompletedCustSubData1_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach (System.Windows.Forms.ToolStripItem item in Ctx_mnuEditCompletedCustSubData1.Items)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				((System.Windows.Forms.ToolStripMenuItem) mnuEditCompletedCustSubData1).DropDownItems.Add(item);
			}
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuClose", "mnuFile", "mnuEditAdd", "mnuEdit", "mnuViewSelectedPub", "mnuView", "mnuEditCompletedCustSubData", "mnuEditCompletedCustSubData1", "MainMenu1", "_chk_include_23", "_txt_pub_14", "_cbo_pub_6", "_chk_include_6", "_cbo_pub_3", "_cbo_pub_5", "_txt_pub_5", "_txt_pub_4", "_txt_pub_9", "_cmd_pub_6", "_txt_pub_6", "_cmd_pub_5", "_txt_pub_10", "_cbo_pub_4", "_lbl_gen_7", "_lbl_gen_3", "pnl_add_pub", "_txt_pub_3", "_cmd_pub_3", "_cmd_pub_1", "_txt_pub_2", "_txt_pub_0", "_txt_pub_1", "_cbo_pub_1", "_cbo_pub_0", "_cmd_pub_0", "_lbl_gen_13", "_lbl_gen_12", "_lbl_gen_0", "_lbl_gen_8", "_lbl_gen_2", "_lbl_gen_1", "_lbl_gen_4", "_lbl_gen_47", "_lbl_gen_44", "_lbl_gen_43", "_lbl_gen_42", "_lbl_gen_41", "_lbl_gen_40", "_lbl_gen_39", "_lbl_gen_38", "pnl_update_pub", "lbl_Status", "grd_NewAvail", "cmdClear", "cmdAddPub", "cmd_Stop", "cmdSendVerifyEMail", "_tab_NewAvail_TabPage0", "Label1", "Label2", "Label14", "WbBrowser", "cmd_GetAvail", "cbo_WebSite", "txt_NumDays", "txt_EMailAddress", "Chk_Dups", "txt_years_diff", "txt_status", "_tab_NewAvail_TabPage1", "_cmd_pub_17", "_cbo_pub_11", "_cmd_pub_10", "_cmd_pub_16", "_cmd_pub_4", "_cmd_pub_7", "cmd_clear_pub", "_cmd_pub_9", "fgrdFindCustSubData", "opSubmitAircraft", "opSubmitCompany", "opSubmitBoth", "_chk_include_25", "_cbo_pub_10", "_chk_include_3", "_chk_include_2", "_chk_include_0", "_chk_include_1", "_cbo_pub_2", "_cmd_pub_2", "_txt_pub_7", "_chk_include_4", "_chk_include_5", "_chk_include_7", "_txt_pub_11", "_txt_pub_12", "_txt_pub_13", "_chk_include_8", "_cbo_pub_7", "_chk_include_9", "_chk_include_10", "_chk_include_11", "grd_pub", "_lbl_gen_21", "_lbl_gen_46", "_lbl_gen_5", "_lbl_gen_9", "_lbl_gen_10", "_lbl_gen_11", "frm_listing1", "_cmd_pub_8", "_txt_pub_8", "_lbl_gen_6", "pnl_add_model_exception", "_lbl_gen_23", "_lbl_gen_45", "pnl_pub_listing", "_tab_NewAvail_TabPage2", "_chk_include_24", "_chk_include_22", "_chk_include_21", "_chk_include_20", "_cbo_pub_9", "_chk_include_19", "_txt_pub_18", "_txt_pub_17", "_txt_pub_16", "_chk_include_18", "_chk_include_17", "_chk_include_16", "_txt_pub_15", "_cmd_pub_14", "_cbo_pub_8", "_chk_include_15", "_chk_include_14", "_chk_include_13", "_chk_include_12", "grd_pub2", "_lbl_gen_18", "_lbl_gen_17", "_lbl_gen_16", "_lbl_gen_15", "_lbl_gen_14", "Frame1", "_cmd_pub_13", "cmd_clear_pub2", "_cmd_pub_12", "_cmd_pub_11", "_txt_pub_19", "_cmd_pub_15", "_lbl_gen_19", "SSPanel2", "_lbl_gen_20", "SSPanel1", "_tab_NewAvail_TabPage3", "tab_NewAvail", "txt_Serialno_Search", "txt_Regno_Search", "cmd_ClearNoChange", "_pic_redx_1", "_pic_redx_2", "txt_publog_days", "chkShowCleared", "cmdRefresh", "cmd_ClearLeave", "cbo_publog_acct_rep", "txt_publog_entry_date", "txt_publog_update_date", "cmd_Cancel", "txt_publog_Ac_id", "txt_publog_url", "cmd_Save", "txt_publog_seller_info", "cmd_Identify_AC", "txt_publog_ser_no", "txt_publog_reg_no", "txt_publog_aftt", "txt_publog_price", "txt_publog_description", "cbo_publog_picture", "cbo_publog_source", "Label17", "Label16", "Label15", "Label13", "lblPubLink", "Label11", "Label10", "Label9", "Label8", "Label7", "Label6", "Label5", "Label4", "frame_Details", "cbo_ACREP", "inet_browse", "_lbl_gen_22", "_lbl_gen_57", "Label20", "Label19", "Label18", "Label3", "cbo_pub", "chk_include", "cmd_pub", "lbl_gen", "pic_redx", "txt_pub", "Ctx_mnuEditCompletedCustSubData1", "optionButtonHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.ToolStripMenuItem mnuEditAdd;
		public System.Windows.Forms.ToolStripMenuItem mnuEdit;
		public System.Windows.Forms.ToolStripMenuItem mnuViewSelectedPub;
		public System.Windows.Forms.ToolStripMenuItem mnuView;
		public System.Windows.Forms.ToolStripMenuItem mnuEditCompletedCustSubData;
		public System.Windows.Forms.ToolStripMenuItem mnuEditCompletedCustSubData1;
		public System.Windows.Forms.MenuStrip MainMenu1;
		private System.Windows.Forms.CheckBox _chk_include_23;
		private System.Windows.Forms.TextBox _txt_pub_14;
		private System.Windows.Forms.ComboBox _cbo_pub_6;
		private System.Windows.Forms.CheckBox _chk_include_6;
		private System.Windows.Forms.ComboBox _cbo_pub_3;
		private System.Windows.Forms.ComboBox _cbo_pub_5;
		private System.Windows.Forms.TextBox _txt_pub_5;
		private System.Windows.Forms.TextBox _txt_pub_4;
		private System.Windows.Forms.TextBox _txt_pub_9;
		private System.Windows.Forms.Button _cmd_pub_6;
		private System.Windows.Forms.TextBox _txt_pub_6;
		private System.Windows.Forms.Button _cmd_pub_5;
		private System.Windows.Forms.TextBox _txt_pub_10;
		private System.Windows.Forms.ComboBox _cbo_pub_4;
		private System.Windows.Forms.Label _lbl_gen_7;
		private System.Windows.Forms.Label _lbl_gen_3;
		public System.Windows.Forms.Panel pnl_add_pub;
		private System.Windows.Forms.TextBox _txt_pub_3;
		private System.Windows.Forms.Button _cmd_pub_3;
		private System.Windows.Forms.Button _cmd_pub_1;
		private System.Windows.Forms.TextBox _txt_pub_2;
		private System.Windows.Forms.TextBox _txt_pub_0;
		private System.Windows.Forms.TextBox _txt_pub_1;
		private System.Windows.Forms.ComboBox _cbo_pub_1;
		private System.Windows.Forms.ComboBox _cbo_pub_0;
		private System.Windows.Forms.Button _cmd_pub_0;
		private System.Windows.Forms.Label _lbl_gen_13;
		private System.Windows.Forms.Label _lbl_gen_12;
		private System.Windows.Forms.Label _lbl_gen_0;
		private System.Windows.Forms.Label _lbl_gen_8;
		private System.Windows.Forms.Label _lbl_gen_2;
		private System.Windows.Forms.Label _lbl_gen_1;
		private System.Windows.Forms.Label _lbl_gen_4;
		private System.Windows.Forms.Label _lbl_gen_47;
		private System.Windows.Forms.Label _lbl_gen_44;
		private System.Windows.Forms.Label _lbl_gen_43;
		private System.Windows.Forms.Label _lbl_gen_42;
		private System.Windows.Forms.Label _lbl_gen_41;
		private System.Windows.Forms.Label _lbl_gen_40;
		private System.Windows.Forms.Label _lbl_gen_39;
		private System.Windows.Forms.Label _lbl_gen_38;
		public System.Windows.Forms.Panel pnl_update_pub;
		public System.Windows.Forms.Label lbl_Status;
		public UpgradeHelpers.DataGridViewFlex grd_NewAvail;
		public System.Windows.Forms.Button cmdClear;
		public System.Windows.Forms.Button cmdAddPub;
		public System.Windows.Forms.Button cmd_Stop;
		public System.Windows.Forms.Button cmdSendVerifyEMail;
		private System.Windows.Forms.TabPage _tab_NewAvail_TabPage0;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label14;
		public System.Windows.Forms.WebBrowser WbBrowser;
		public System.Windows.Forms.Button cmd_GetAvail;
		public System.Windows.Forms.ComboBox cbo_WebSite;
		public System.Windows.Forms.TextBox txt_NumDays;
		public System.Windows.Forms.TextBox txt_EMailAddress;
		public System.Windows.Forms.CheckBox Chk_Dups;
		public System.Windows.Forms.TextBox txt_years_diff;
		public System.Windows.Forms.TextBox txt_status;
		private System.Windows.Forms.TabPage _tab_NewAvail_TabPage1;
		private System.Windows.Forms.Button _cmd_pub_17;
		private System.Windows.Forms.ComboBox _cbo_pub_11;
		private System.Windows.Forms.Button _cmd_pub_10;
		private System.Windows.Forms.Button _cmd_pub_16;
		private System.Windows.Forms.Button _cmd_pub_4;
		private System.Windows.Forms.Button _cmd_pub_7;
		public System.Windows.Forms.Button cmd_clear_pub;
		private System.Windows.Forms.Button _cmd_pub_9;
		public UpgradeHelpers.DataGridViewFlex fgrdFindCustSubData;
		public System.Windows.Forms.RadioButton opSubmitAircraft;
		public System.Windows.Forms.RadioButton opSubmitCompany;
		public System.Windows.Forms.RadioButton opSubmitBoth;
		private System.Windows.Forms.CheckBox _chk_include_25;
		private System.Windows.Forms.ComboBox _cbo_pub_10;
		private System.Windows.Forms.CheckBox _chk_include_3;
		private System.Windows.Forms.CheckBox _chk_include_2;
		private System.Windows.Forms.CheckBox _chk_include_0;
		private System.Windows.Forms.CheckBox _chk_include_1;
		private System.Windows.Forms.ComboBox _cbo_pub_2;
		private System.Windows.Forms.Button _cmd_pub_2;
		private System.Windows.Forms.TextBox _txt_pub_7;
		private System.Windows.Forms.CheckBox _chk_include_4;
		private System.Windows.Forms.CheckBox _chk_include_5;
		private System.Windows.Forms.CheckBox _chk_include_7;
		private System.Windows.Forms.TextBox _txt_pub_11;
		private System.Windows.Forms.TextBox _txt_pub_12;
		private System.Windows.Forms.TextBox _txt_pub_13;
		private System.Windows.Forms.CheckBox _chk_include_8;
		private System.Windows.Forms.ComboBox _cbo_pub_7;
		private System.Windows.Forms.CheckBox _chk_include_9;
		private System.Windows.Forms.CheckBox _chk_include_10;
		private System.Windows.Forms.CheckBox _chk_include_11;
		public UpgradeHelpers.DataGridViewFlex grd_pub;
		private System.Windows.Forms.Label _lbl_gen_21;
		private System.Windows.Forms.Label _lbl_gen_46;
		private System.Windows.Forms.Label _lbl_gen_5;
		private System.Windows.Forms.Label _lbl_gen_9;
		private System.Windows.Forms.Label _lbl_gen_10;
		private System.Windows.Forms.Label _lbl_gen_11;
		public System.Windows.Forms.GroupBox frm_listing1;
		private System.Windows.Forms.Button _cmd_pub_8;
		private System.Windows.Forms.TextBox _txt_pub_8;
		private System.Windows.Forms.Label _lbl_gen_6;
		public System.Windows.Forms.Panel pnl_add_model_exception;
		private System.Windows.Forms.Label _lbl_gen_23;
		private System.Windows.Forms.Label _lbl_gen_45;
		public System.Windows.Forms.Panel pnl_pub_listing;
		private System.Windows.Forms.TabPage _tab_NewAvail_TabPage2;
		private System.Windows.Forms.CheckBox _chk_include_24;
		private System.Windows.Forms.CheckBox _chk_include_22;
		private System.Windows.Forms.CheckBox _chk_include_21;
		private System.Windows.Forms.CheckBox _chk_include_20;
		private System.Windows.Forms.ComboBox _cbo_pub_9;
		private System.Windows.Forms.CheckBox _chk_include_19;
		private System.Windows.Forms.TextBox _txt_pub_18;
		private System.Windows.Forms.TextBox _txt_pub_17;
		private System.Windows.Forms.TextBox _txt_pub_16;
		private System.Windows.Forms.CheckBox _chk_include_18;
		private System.Windows.Forms.CheckBox _chk_include_17;
		private System.Windows.Forms.CheckBox _chk_include_16;
		private System.Windows.Forms.TextBox _txt_pub_15;
		private System.Windows.Forms.Button _cmd_pub_14;
		private System.Windows.Forms.ComboBox _cbo_pub_8;
		private System.Windows.Forms.CheckBox _chk_include_15;
		private System.Windows.Forms.CheckBox _chk_include_14;
		private System.Windows.Forms.CheckBox _chk_include_13;
		private System.Windows.Forms.CheckBox _chk_include_12;
		public UpgradeHelpers.DataGridViewFlex grd_pub2;
		private System.Windows.Forms.Label _lbl_gen_18;
		private System.Windows.Forms.Label _lbl_gen_17;
		private System.Windows.Forms.Label _lbl_gen_16;
		private System.Windows.Forms.Label _lbl_gen_15;
		private System.Windows.Forms.Label _lbl_gen_14;
		public System.Windows.Forms.GroupBox Frame1;
		private System.Windows.Forms.Button _cmd_pub_13;
		public System.Windows.Forms.Button cmd_clear_pub2;
		private System.Windows.Forms.Button _cmd_pub_12;
		private System.Windows.Forms.Button _cmd_pub_11;
		private System.Windows.Forms.TextBox _txt_pub_19;
		private System.Windows.Forms.Button _cmd_pub_15;
		private System.Windows.Forms.Label _lbl_gen_19;
		public System.Windows.Forms.Panel SSPanel2;
		private System.Windows.Forms.Label _lbl_gen_20;
		public System.Windows.Forms.Panel SSPanel1;
		private System.Windows.Forms.TabPage _tab_NewAvail_TabPage3;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_NewAvail;
		public System.Windows.Forms.TextBox txt_Serialno_Search;
		public System.Windows.Forms.TextBox txt_Regno_Search;
		public System.Windows.Forms.Button cmd_ClearNoChange;
		private System.Windows.Forms.PictureBox _pic_redx_1;
		private System.Windows.Forms.PictureBox _pic_redx_2;
		public System.Windows.Forms.TextBox txt_publog_days;
		public System.Windows.Forms.CheckBox chkShowCleared;
		public System.Windows.Forms.Button cmdRefresh;
		public System.Windows.Forms.Button cmd_ClearLeave;
		public System.Windows.Forms.ComboBox cbo_publog_acct_rep;
		public System.Windows.Forms.TextBox txt_publog_entry_date;
		public System.Windows.Forms.TextBox txt_publog_update_date;
		public System.Windows.Forms.Button cmd_Cancel;
		public System.Windows.Forms.TextBox txt_publog_Ac_id;
		public System.Windows.Forms.TextBox txt_publog_url;
		public System.Windows.Forms.Button cmd_Save;
		public System.Windows.Forms.TextBox txt_publog_seller_info;
		public System.Windows.Forms.Button cmd_Identify_AC;
		public System.Windows.Forms.TextBox txt_publog_ser_no;
		public System.Windows.Forms.TextBox txt_publog_reg_no;
		public System.Windows.Forms.TextBox txt_publog_aftt;
		public System.Windows.Forms.TextBox txt_publog_price;
		public System.Windows.Forms.TextBox txt_publog_description;
		public System.Windows.Forms.ComboBox cbo_publog_picture;
		public System.Windows.Forms.ComboBox cbo_publog_source;
		public System.Windows.Forms.Label Label17;
		public System.Windows.Forms.Label Label16;
		public System.Windows.Forms.Label Label15;
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.Label lblPubLink;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.GroupBox frame_Details;
		public System.Windows.Forms.ComboBox cbo_ACREP;
		public dynamic inet_browse; //gap-note this control must be defined during Blazor stabilization
		private System.Windows.Forms.Label _lbl_gen_22;
		private System.Windows.Forms.Label _lbl_gen_57;
		public System.Windows.Forms.Label Label20;
		public System.Windows.Forms.Label Label19;
		public System.Windows.Forms.Label Label18;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.ComboBox[] cbo_pub = new System.Windows.Forms.ComboBox[12];
		public System.Windows.Forms.CheckBox[] chk_include = new System.Windows.Forms.CheckBox[26];
		public System.Windows.Forms.Button[] cmd_pub = new System.Windows.Forms.Button[18];
		public System.Windows.Forms.Label[] lbl_gen = new System.Windows.Forms.Label[58];
		public System.Windows.Forms.PictureBox[] pic_redx = new System.Windows.Forms.PictureBox[3];
		public System.Windows.Forms.TextBox[] txt_pub = new System.Windows.Forms.TextBox[20];
		public System.Windows.Forms.ContextMenuStrip Ctx_mnuEditCompletedCustSubData1;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		private int tab_NewAvailPreviousTab;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WebCrawl));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditAdd = new System.Windows.Forms.ToolStripMenuItem();
			mnuView = new System.Windows.Forms.ToolStripMenuItem();
			mnuViewSelectedPub = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditCompletedCustSubData1 = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditCompletedCustSubData = new System.Windows.Forms.ToolStripMenuItem();
			_chk_include_23 = new System.Windows.Forms.CheckBox();
			pnl_update_pub = new System.Windows.Forms.Panel();
			_txt_pub_14 = new System.Windows.Forms.TextBox();
			_cbo_pub_6 = new System.Windows.Forms.ComboBox();
			_chk_include_6 = new System.Windows.Forms.CheckBox();
			_cbo_pub_3 = new System.Windows.Forms.ComboBox();
			_cbo_pub_5 = new System.Windows.Forms.ComboBox();
			_txt_pub_5 = new System.Windows.Forms.TextBox();
			_txt_pub_4 = new System.Windows.Forms.TextBox();
			_txt_pub_9 = new System.Windows.Forms.TextBox();
			_cmd_pub_6 = new System.Windows.Forms.Button();
			_txt_pub_6 = new System.Windows.Forms.TextBox();
			_cmd_pub_5 = new System.Windows.Forms.Button();
			pnl_add_pub = new System.Windows.Forms.Panel();
			_txt_pub_10 = new System.Windows.Forms.TextBox();
			_cbo_pub_4 = new System.Windows.Forms.ComboBox();
			_lbl_gen_7 = new System.Windows.Forms.Label();
			_lbl_gen_3 = new System.Windows.Forms.Label();
			_txt_pub_3 = new System.Windows.Forms.TextBox();
			_cmd_pub_3 = new System.Windows.Forms.Button();
			_cmd_pub_1 = new System.Windows.Forms.Button();
			_txt_pub_2 = new System.Windows.Forms.TextBox();
			_txt_pub_0 = new System.Windows.Forms.TextBox();
			_txt_pub_1 = new System.Windows.Forms.TextBox();
			_cbo_pub_1 = new System.Windows.Forms.ComboBox();
			_cbo_pub_0 = new System.Windows.Forms.ComboBox();
			_cmd_pub_0 = new System.Windows.Forms.Button();
			_lbl_gen_13 = new System.Windows.Forms.Label();
			_lbl_gen_12 = new System.Windows.Forms.Label();
			_lbl_gen_0 = new System.Windows.Forms.Label();
			_lbl_gen_8 = new System.Windows.Forms.Label();
			_lbl_gen_2 = new System.Windows.Forms.Label();
			_lbl_gen_1 = new System.Windows.Forms.Label();
			_lbl_gen_4 = new System.Windows.Forms.Label();
			_lbl_gen_47 = new System.Windows.Forms.Label();
			_lbl_gen_44 = new System.Windows.Forms.Label();
			_lbl_gen_43 = new System.Windows.Forms.Label();
			_lbl_gen_42 = new System.Windows.Forms.Label();
			_lbl_gen_41 = new System.Windows.Forms.Label();
			_lbl_gen_40 = new System.Windows.Forms.Label();
			_lbl_gen_39 = new System.Windows.Forms.Label();
			_lbl_gen_38 = new System.Windows.Forms.Label();
			tab_NewAvail = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_NewAvail_TabPage0 = new System.Windows.Forms.TabPage();
			lbl_Status = new System.Windows.Forms.Label();
			grd_NewAvail = new UpgradeHelpers.DataGridViewFlex(components);
			cmdClear = new System.Windows.Forms.Button();
			cmdAddPub = new System.Windows.Forms.Button();
			cmd_Stop = new System.Windows.Forms.Button();
			cmdSendVerifyEMail = new System.Windows.Forms.Button();
			_tab_NewAvail_TabPage1 = new System.Windows.Forms.TabPage();
			Label1 = new System.Windows.Forms.Label();
			Label2 = new System.Windows.Forms.Label();
			Label14 = new System.Windows.Forms.Label();
			WbBrowser = new System.Windows.Forms.WebBrowser();
			cmd_GetAvail = new System.Windows.Forms.Button();
			cbo_WebSite = new System.Windows.Forms.ComboBox();
			txt_NumDays = new System.Windows.Forms.TextBox();
			txt_EMailAddress = new System.Windows.Forms.TextBox();
			Chk_Dups = new System.Windows.Forms.CheckBox();
			txt_years_diff = new System.Windows.Forms.TextBox();
			txt_status = new System.Windows.Forms.TextBox();
			_tab_NewAvail_TabPage2 = new System.Windows.Forms.TabPage();
			pnl_pub_listing = new System.Windows.Forms.Panel();
			_cmd_pub_17 = new System.Windows.Forms.Button();
			_cbo_pub_11 = new System.Windows.Forms.ComboBox();
			_cmd_pub_10 = new System.Windows.Forms.Button();
			_cmd_pub_16 = new System.Windows.Forms.Button();
			_cmd_pub_4 = new System.Windows.Forms.Button();
			_cmd_pub_7 = new System.Windows.Forms.Button();
			cmd_clear_pub = new System.Windows.Forms.Button();
			_cmd_pub_9 = new System.Windows.Forms.Button();
			frm_listing1 = new System.Windows.Forms.GroupBox();
			fgrdFindCustSubData = new UpgradeHelpers.DataGridViewFlex(components);
			opSubmitAircraft = new System.Windows.Forms.RadioButton();
			opSubmitCompany = new System.Windows.Forms.RadioButton();
			opSubmitBoth = new System.Windows.Forms.RadioButton();
			_chk_include_25 = new System.Windows.Forms.CheckBox();
			_cbo_pub_10 = new System.Windows.Forms.ComboBox();
			_chk_include_3 = new System.Windows.Forms.CheckBox();
			_chk_include_2 = new System.Windows.Forms.CheckBox();
			_chk_include_0 = new System.Windows.Forms.CheckBox();
			_chk_include_1 = new System.Windows.Forms.CheckBox();
			_cbo_pub_2 = new System.Windows.Forms.ComboBox();
			_cmd_pub_2 = new System.Windows.Forms.Button();
			_txt_pub_7 = new System.Windows.Forms.TextBox();
			_chk_include_4 = new System.Windows.Forms.CheckBox();
			_chk_include_5 = new System.Windows.Forms.CheckBox();
			_chk_include_7 = new System.Windows.Forms.CheckBox();
			_txt_pub_11 = new System.Windows.Forms.TextBox();
			_txt_pub_12 = new System.Windows.Forms.TextBox();
			_txt_pub_13 = new System.Windows.Forms.TextBox();
			_chk_include_8 = new System.Windows.Forms.CheckBox();
			_cbo_pub_7 = new System.Windows.Forms.ComboBox();
			_chk_include_9 = new System.Windows.Forms.CheckBox();
			_chk_include_10 = new System.Windows.Forms.CheckBox();
			_chk_include_11 = new System.Windows.Forms.CheckBox();
			grd_pub = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_21 = new System.Windows.Forms.Label();
			_lbl_gen_46 = new System.Windows.Forms.Label();
			_lbl_gen_5 = new System.Windows.Forms.Label();
			_lbl_gen_9 = new System.Windows.Forms.Label();
			_lbl_gen_10 = new System.Windows.Forms.Label();
			_lbl_gen_11 = new System.Windows.Forms.Label();
			pnl_add_model_exception = new System.Windows.Forms.Panel();
			_cmd_pub_8 = new System.Windows.Forms.Button();
			_txt_pub_8 = new System.Windows.Forms.TextBox();
			_lbl_gen_6 = new System.Windows.Forms.Label();
			_lbl_gen_23 = new System.Windows.Forms.Label();
			_lbl_gen_45 = new System.Windows.Forms.Label();
			_tab_NewAvail_TabPage3 = new System.Windows.Forms.TabPage();
			SSPanel1 = new System.Windows.Forms.Panel();
			Frame1 = new System.Windows.Forms.GroupBox();
			_chk_include_24 = new System.Windows.Forms.CheckBox();
			_chk_include_22 = new System.Windows.Forms.CheckBox();
			_chk_include_21 = new System.Windows.Forms.CheckBox();
			_chk_include_20 = new System.Windows.Forms.CheckBox();
			_cbo_pub_9 = new System.Windows.Forms.ComboBox();
			_chk_include_19 = new System.Windows.Forms.CheckBox();
			_txt_pub_18 = new System.Windows.Forms.TextBox();
			_txt_pub_17 = new System.Windows.Forms.TextBox();
			_txt_pub_16 = new System.Windows.Forms.TextBox();
			_chk_include_18 = new System.Windows.Forms.CheckBox();
			_chk_include_17 = new System.Windows.Forms.CheckBox();
			_chk_include_16 = new System.Windows.Forms.CheckBox();
			_txt_pub_15 = new System.Windows.Forms.TextBox();
			_cmd_pub_14 = new System.Windows.Forms.Button();
			_cbo_pub_8 = new System.Windows.Forms.ComboBox();
			_chk_include_15 = new System.Windows.Forms.CheckBox();
			_chk_include_14 = new System.Windows.Forms.CheckBox();
			_chk_include_13 = new System.Windows.Forms.CheckBox();
			_chk_include_12 = new System.Windows.Forms.CheckBox();
			grd_pub2 = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_18 = new System.Windows.Forms.Label();
			_lbl_gen_17 = new System.Windows.Forms.Label();
			_lbl_gen_16 = new System.Windows.Forms.Label();
			_lbl_gen_15 = new System.Windows.Forms.Label();
			_lbl_gen_14 = new System.Windows.Forms.Label();
			_cmd_pub_13 = new System.Windows.Forms.Button();
			cmd_clear_pub2 = new System.Windows.Forms.Button();
			_cmd_pub_12 = new System.Windows.Forms.Button();
			_cmd_pub_11 = new System.Windows.Forms.Button();
			SSPanel2 = new System.Windows.Forms.Panel();
			_txt_pub_19 = new System.Windows.Forms.TextBox();
			_cmd_pub_15 = new System.Windows.Forms.Button();
			_lbl_gen_19 = new System.Windows.Forms.Label();
			_lbl_gen_20 = new System.Windows.Forms.Label();
			txt_Serialno_Search = new System.Windows.Forms.TextBox();
			txt_Regno_Search = new System.Windows.Forms.TextBox();
			cmd_ClearNoChange = new System.Windows.Forms.Button();
			_pic_redx_1 = new System.Windows.Forms.PictureBox();
			_pic_redx_2 = new System.Windows.Forms.PictureBox();
			txt_publog_days = new System.Windows.Forms.TextBox();
			chkShowCleared = new System.Windows.Forms.CheckBox();
			cmdRefresh = new System.Windows.Forms.Button();
			frame_Details = new System.Windows.Forms.GroupBox();
			cmd_ClearLeave = new System.Windows.Forms.Button();
			cbo_publog_acct_rep = new System.Windows.Forms.ComboBox();
			txt_publog_entry_date = new System.Windows.Forms.TextBox();
			txt_publog_update_date = new System.Windows.Forms.TextBox();
			cmd_Cancel = new System.Windows.Forms.Button();
			txt_publog_Ac_id = new System.Windows.Forms.TextBox();
			txt_publog_url = new System.Windows.Forms.TextBox();
			cmd_Save = new System.Windows.Forms.Button();
			txt_publog_seller_info = new System.Windows.Forms.TextBox();
			cmd_Identify_AC = new System.Windows.Forms.Button();
			txt_publog_ser_no = new System.Windows.Forms.TextBox();
			txt_publog_reg_no = new System.Windows.Forms.TextBox();
			txt_publog_aftt = new System.Windows.Forms.TextBox();
			txt_publog_price = new System.Windows.Forms.TextBox();
			txt_publog_description = new System.Windows.Forms.TextBox();
			cbo_publog_picture = new System.Windows.Forms.ComboBox();
			cbo_publog_source = new System.Windows.Forms.ComboBox();
			Label17 = new System.Windows.Forms.Label();
			Label16 = new System.Windows.Forms.Label();
			Label15 = new System.Windows.Forms.Label();
			Label13 = new System.Windows.Forms.Label();
			lblPubLink = new System.Windows.Forms.Label();
			Label11 = new System.Windows.Forms.Label();
			Label10 = new System.Windows.Forms.Label();
			Label9 = new System.Windows.Forms.Label();
			Label8 = new System.Windows.Forms.Label();
			Label7 = new System.Windows.Forms.Label();
			Label6 = new System.Windows.Forms.Label();
			Label5 = new System.Windows.Forms.Label();
			Label4 = new System.Windows.Forms.Label();
			cbo_ACREP = new System.Windows.Forms.ComboBox();
			//inet_browse = new AxInetCtlsObjects.AxInet();//gap-note this control must be defined during Blazor stabilization
			_lbl_gen_22 = new System.Windows.Forms.Label();
			_lbl_gen_57 = new System.Windows.Forms.Label();
			Label20 = new System.Windows.Forms.Label();
			Label19 = new System.Windows.Forms.Label();
			Label18 = new System.Windows.Forms.Label();
			Label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) inet_browse).BeginInit();
			pnl_update_pub.SuspendLayout();
			pnl_add_pub.SuspendLayout();
			tab_NewAvail.SuspendLayout();
			_tab_NewAvail_TabPage0.SuspendLayout();
			_tab_NewAvail_TabPage1.SuspendLayout();
			_tab_NewAvail_TabPage2.SuspendLayout();
			pnl_pub_listing.SuspendLayout();
			frm_listing1.SuspendLayout();
			pnl_add_model_exception.SuspendLayout();
			_tab_NewAvail_TabPage3.SuspendLayout();
			SSPanel1.SuspendLayout();
			Frame1.SuspendLayout();
			SSPanel2.SuspendLayout();
			frame_Details.SuspendLayout();
			SuspendLayout();
			//Ctx_mnuEditCompletedCustSubData1
			Ctx_mnuEditCompletedCustSubData1 = new System.Windows.Forms.ContextMenuStrip(components);
			Ctx_mnuEditCompletedCustSubData1.Size = new System.Drawing.Size(153, 26);
			Ctx_mnuEditCompletedCustSubData1.Opening += new System.ComponentModel.CancelEventHandler(Ctx_mnuEditCompletedCustSubData1_Opening);
			Ctx_mnuEditCompletedCustSubData1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(Ctx_mnuEditCompletedCustSubData1_Closed);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_NewAvail).BeginInit();
			((System.ComponentModel.ISupportInitialize) fgrdFindCustSubData).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_pub).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_pub2).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFile, mnuEdit, mnuView, mnuEditCompletedCustSubData1});
			// 
			// mnuFile
			// 
			mnuFile.Available = true;
			mnuFile.Checked = false;
			mnuFile.Enabled = true;
			mnuFile.Name = "mnuFile";
			mnuFile.Text = "File";
			mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuClose});
			// 
			// mnuClose
			// 
			mnuClose.Available = true;
			mnuClose.Checked = false;
			mnuClose.Enabled = true;
			mnuClose.Name = "mnuClose";
			mnuClose.Text = "Close";
			mnuClose.Click += new System.EventHandler(mnuClose_Click);
			// 
			// mnuEdit
			// 
			mnuEdit.Available = true;
			mnuEdit.Checked = false;
			mnuEdit.Enabled = true;
			mnuEdit.Name = "mnuEdit";
			mnuEdit.Text = "Edit";
			mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuEditAdd});
			// 
			// mnuEditAdd
			// 
			mnuEditAdd.Available = true;
			mnuEditAdd.Checked = false;
			mnuEditAdd.Enabled = true;
			mnuEditAdd.Name = "mnuEditAdd";
			mnuEditAdd.Text = "Add New Pub";
			mnuEditAdd.Click += new System.EventHandler(mnuEditAdd_Click);
			// 
			// mnuView
			// 
			mnuView.Available = true;
			mnuView.Checked = false;
			mnuView.Enabled = true;
			mnuView.Name = "mnuView";
			mnuView.Text = "View";
			mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuViewSelectedPub});
			// 
			// mnuViewSelectedPub
			// 
			mnuViewSelectedPub.Available = true;
			mnuViewSelectedPub.Checked = false;
			mnuViewSelectedPub.Enabled = true;
			mnuViewSelectedPub.Name = "mnuViewSelectedPub";
			mnuViewSelectedPub.Text = "Filter By Selected Pub";
			mnuViewSelectedPub.Click += new System.EventHandler(mnuViewSelectedPub_Click);
			// 
			// mnuEditCompletedCustSubData1
			// 
			mnuEditCompletedCustSubData1.Available = true;
			mnuEditCompletedCustSubData1.Checked = false;
			mnuEditCompletedCustSubData1.Enabled = true;
			mnuEditCompletedCustSubData1.Name = "mnuEditCompletedCustSubData1";
			mnuEditCompletedCustSubData1.Text = "EditCSD";
			mnuEditCompletedCustSubData1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuEditCompletedCustSubData});
			// 
			// mnuEditCompletedCustSubData
			// 
			mnuEditCompletedCustSubData.Available = true;
			mnuEditCompletedCustSubData.Checked = false;
			mnuEditCompletedCustSubData.Enabled = true;
			mnuEditCompletedCustSubData.Name = "mnuEditCompletedCustSubData";
			mnuEditCompletedCustSubData.Text = "CompleteCSD";
			mnuEditCompletedCustSubData.Click += new System.EventHandler(mnuEditCompletedCustSubData_Click);
			// 
			// _chk_include_23
			// 
			_chk_include_23.AllowDrop = true;
			_chk_include_23.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_23.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_23.CausesValidation = true;
			_chk_include_23.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_23.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_23.Enabled = true;
			_chk_include_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_23.Location = new System.Drawing.Point(232, 24);
			_chk_include_23.Name = "_chk_include_23";
			_chk_include_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_23.Size = new System.Drawing.Size(101, 20);
			_chk_include_23.TabIndex = 176;
			_chk_include_23.TabStop = true;
			_chk_include_23.Text = "Use Alt Rep";
			_chk_include_23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_23.Visible = true;
			_chk_include_23.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// pnl_update_pub
			// 
			pnl_update_pub.AllowDrop = true;
			pnl_update_pub.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			pnl_update_pub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_update_pub.Controls.Add(_txt_pub_14);
			pnl_update_pub.Controls.Add(_cbo_pub_6);
			pnl_update_pub.Controls.Add(_chk_include_6);
			pnl_update_pub.Controls.Add(_cbo_pub_3);
			pnl_update_pub.Controls.Add(_cbo_pub_5);
			pnl_update_pub.Controls.Add(_txt_pub_5);
			pnl_update_pub.Controls.Add(_txt_pub_4);
			pnl_update_pub.Controls.Add(_txt_pub_9);
			pnl_update_pub.Controls.Add(_cmd_pub_6);
			pnl_update_pub.Controls.Add(_txt_pub_6);
			pnl_update_pub.Controls.Add(_cmd_pub_5);
			pnl_update_pub.Controls.Add(pnl_add_pub);
			pnl_update_pub.Controls.Add(_txt_pub_3);
			pnl_update_pub.Controls.Add(_cmd_pub_3);
			pnl_update_pub.Controls.Add(_cmd_pub_1);
			pnl_update_pub.Controls.Add(_txt_pub_2);
			pnl_update_pub.Controls.Add(_txt_pub_0);
			pnl_update_pub.Controls.Add(_txt_pub_1);
			pnl_update_pub.Controls.Add(_cbo_pub_1);
			pnl_update_pub.Controls.Add(_cbo_pub_0);
			pnl_update_pub.Controls.Add(_cmd_pub_0);
			pnl_update_pub.Controls.Add(_lbl_gen_13);
			pnl_update_pub.Controls.Add(_lbl_gen_12);
			pnl_update_pub.Controls.Add(_lbl_gen_0);
			pnl_update_pub.Controls.Add(_lbl_gen_8);
			pnl_update_pub.Controls.Add(_lbl_gen_2);
			pnl_update_pub.Controls.Add(_lbl_gen_1);
			pnl_update_pub.Controls.Add(_lbl_gen_4);
			pnl_update_pub.Controls.Add(_lbl_gen_47);
			pnl_update_pub.Controls.Add(_lbl_gen_44);
			pnl_update_pub.Controls.Add(_lbl_gen_43);
			pnl_update_pub.Controls.Add(_lbl_gen_42);
			pnl_update_pub.Controls.Add(_lbl_gen_41);
			pnl_update_pub.Controls.Add(_lbl_gen_40);
			pnl_update_pub.Controls.Add(_lbl_gen_39);
			pnl_update_pub.Controls.Add(_lbl_gen_38);
			pnl_update_pub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_update_pub.Location = new System.Drawing.Point(8, 528);
			pnl_update_pub.Name = "pnl_update_pub";
			pnl_update_pub.Size = new System.Drawing.Size(979, 179);
			pnl_update_pub.TabIndex = 63;
			pnl_update_pub.Visible = false;
			// 
			// _txt_pub_14
			// 
			_txt_pub_14.AcceptsReturn = true;
			_txt_pub_14.AllowDrop = true;
			_txt_pub_14.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_14.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_14.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_14.Location = new System.Drawing.Point(432, 144);
			_txt_pub_14.MaxLength = 0;
			_txt_pub_14.Name = "_txt_pub_14";
			_txt_pub_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_14.Size = new System.Drawing.Size(115, 21);
			_txt_pub_14.TabIndex = 102;
			_txt_pub_14.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _cbo_pub_6
			// 
			_cbo_pub_6.AllowDrop = true;
			_cbo_pub_6.BackColor = System.Drawing.SystemColors.Window;
			_cbo_pub_6.CausesValidation = true;
			_cbo_pub_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_pub_6.Enabled = true;
			_cbo_pub_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_pub_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_pub_6.IntegralHeight = true;
			_cbo_pub_6.Location = new System.Drawing.Point(264, 96);
			_cbo_pub_6.Name = "_cbo_pub_6";
			_cbo_pub_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_pub_6.Size = new System.Drawing.Size(129, 21);
			_cbo_pub_6.Sorted = false;
			_cbo_pub_6.TabIndex = 100;
			_cbo_pub_6.TabStop = true;
			_cbo_pub_6.Visible = true;
			_cbo_pub_6.Enter += new System.EventHandler(cbo_pub_Enter);
			_cbo_pub_6.SelectionChangeCommitted += new System.EventHandler(cbo_pub_SelectionChangeCommitted);
			_cbo_pub_6.TextChanged += new System.EventHandler(cbo_pub_TextChanged);
			// 
			// _chk_include_6
			// 
			_chk_include_6.AllowDrop = true;
			_chk_include_6.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_6.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_6.CausesValidation = true;
			_chk_include_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_6.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_6.Enabled = true;
			_chk_include_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_6.Location = new System.Drawing.Point(432, 110);
			_chk_include_6.Name = "_chk_include_6";
			_chk_include_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_6.Size = new System.Drawing.Size(69, 20);
			_chk_include_6.TabIndex = 99;
			_chk_include_6.TabStop = true;
			_chk_include_6.Text = "Pictures";
			_chk_include_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_6.Visible = true;
			_chk_include_6.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _cbo_pub_3
			// 
			_cbo_pub_3.AllowDrop = true;
			_cbo_pub_3.BackColor = System.Drawing.SystemColors.Window;
			_cbo_pub_3.CausesValidation = true;
			_cbo_pub_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_pub_3.Enabled = true;
			_cbo_pub_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_pub_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_pub_3.IntegralHeight = true;
			_cbo_pub_3.Location = new System.Drawing.Point(168, 147);
			_cbo_pub_3.Name = "_cbo_pub_3";
			_cbo_pub_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_pub_3.Size = new System.Drawing.Size(153, 21);
			_cbo_pub_3.Sorted = false;
			_cbo_pub_3.TabIndex = 97;
			_cbo_pub_3.TabStop = true;
			_cbo_pub_3.Visible = true;
			_cbo_pub_3.Enter += new System.EventHandler(cbo_pub_Enter);
			_cbo_pub_3.SelectionChangeCommitted += new System.EventHandler(cbo_pub_SelectionChangeCommitted);
			_cbo_pub_3.TextChanged += new System.EventHandler(cbo_pub_TextChanged);
			// 
			// _cbo_pub_5
			// 
			_cbo_pub_5.AllowDrop = true;
			_cbo_pub_5.BackColor = System.Drawing.SystemColors.Window;
			_cbo_pub_5.CausesValidation = true;
			_cbo_pub_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_pub_5.Enabled = true;
			_cbo_pub_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_pub_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_pub_5.IntegralHeight = true;
			_cbo_pub_5.Location = new System.Drawing.Point(168, 120);
			_cbo_pub_5.Name = "_cbo_pub_5";
			_cbo_pub_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_pub_5.Size = new System.Drawing.Size(233, 21);
			_cbo_pub_5.Sorted = false;
			_cbo_pub_5.TabIndex = 95;
			_cbo_pub_5.TabStop = true;
			_cbo_pub_5.Visible = true;
			_cbo_pub_5.Enter += new System.EventHandler(cbo_pub_Enter);
			_cbo_pub_5.SelectionChangeCommitted += new System.EventHandler(cbo_pub_SelectionChangeCommitted);
			_cbo_pub_5.TextChanged += new System.EventHandler(cbo_pub_TextChanged);
			// 
			// _txt_pub_5
			// 
			_txt_pub_5.AcceptsReturn = true;
			_txt_pub_5.AllowDrop = true;
			_txt_pub_5.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_5.Location = new System.Drawing.Point(102, 18);
			_txt_pub_5.MaxLength = 0;
			_txt_pub_5.Name = "_txt_pub_5";
			_txt_pub_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_5.Size = new System.Drawing.Size(289, 21);
			_txt_pub_5.TabIndex = 93;
			_txt_pub_5.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _txt_pub_4
			// 
			_txt_pub_4.AcceptsReturn = true;
			_txt_pub_4.AllowDrop = true;
			_txt_pub_4.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_4.Location = new System.Drawing.Point(434, 86);
			_txt_pub_4.MaxLength = 0;
			_txt_pub_4.Name = "_txt_pub_4";
			_txt_pub_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_4.Size = new System.Drawing.Size(351, 21);
			_txt_pub_4.TabIndex = 91;
			_txt_pub_4.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _txt_pub_9
			// 
			_txt_pub_9.AcceptsReturn = true;
			_txt_pub_9.AllowDrop = true;
			_txt_pub_9.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_9.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_9.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_9.Location = new System.Drawing.Point(4, 116);
			_txt_pub_9.MaxLength = 0;
			_txt_pub_9.Name = "_txt_pub_9";
			_txt_pub_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_9.Size = new System.Drawing.Size(115, 21);
			_txt_pub_9.TabIndex = 88;
			_txt_pub_9.Visible = false;
			_txt_pub_9.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _cmd_pub_6
			// 
			_cmd_pub_6.AllowDrop = true;
			_cmd_pub_6.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_6.Location = new System.Drawing.Point(186, 94);
			_cmd_pub_6.Name = "_cmd_pub_6";
			_cmd_pub_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_6.Size = new System.Drawing.Size(47, 23);
			_cmd_pub_6.TabIndex = 87;
			_cmd_pub_6.Text = "Find";
			_cmd_pub_6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_6.UseVisualStyleBackColor = false;
			_cmd_pub_6.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _txt_pub_6
			// 
			_txt_pub_6.AcceptsReturn = true;
			_txt_pub_6.AllowDrop = true;
			_txt_pub_6.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_6.Location = new System.Drawing.Point(102, 94);
			_txt_pub_6.MaxLength = 0;
			_txt_pub_6.Name = "_txt_pub_6";
			_txt_pub_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_6.Size = new System.Drawing.Size(77, 21);
			_txt_pub_6.TabIndex = 85;
			_txt_pub_6.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _cmd_pub_5
			// 
			_cmd_pub_5.AllowDrop = true;
			_cmd_pub_5.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_5.Location = new System.Drawing.Point(848, 96);
			_cmd_pub_5.Name = "_cmd_pub_5";
			_cmd_pub_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_5.Size = new System.Drawing.Size(59, 25);
			_cmd_pub_5.TabIndex = 84;
			_cmd_pub_5.Text = "Delete";
			_cmd_pub_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_5.UseVisualStyleBackColor = false;
			_cmd_pub_5.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// pnl_add_pub
			// 
			pnl_add_pub.AllowDrop = true;
			pnl_add_pub.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			pnl_add_pub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_add_pub.Controls.Add(_txt_pub_10);
			pnl_add_pub.Controls.Add(_cbo_pub_4);
			pnl_add_pub.Controls.Add(_lbl_gen_7);
			pnl_add_pub.Controls.Add(_lbl_gen_3);
			pnl_add_pub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_add_pub.Location = new System.Drawing.Point(624, 104);
			pnl_add_pub.Name = "pnl_add_pub";
			pnl_add_pub.Size = new System.Drawing.Size(183, 65);
			pnl_add_pub.TabIndex = 81;
			pnl_add_pub.Visible = false;
			// 
			// _txt_pub_10
			// 
			_txt_pub_10.AcceptsReturn = true;
			_txt_pub_10.AllowDrop = true;
			_txt_pub_10.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_10.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_10.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_10.Location = new System.Drawing.Point(48, 36);
			_txt_pub_10.MaxLength = 0;
			_txt_pub_10.Name = "_txt_pub_10";
			_txt_pub_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_10.Size = new System.Drawing.Size(63, 21);
			_txt_pub_10.TabIndex = 90;
			_txt_pub_10.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _cbo_pub_4
			// 
			_cbo_pub_4.AllowDrop = true;
			_cbo_pub_4.BackColor = System.Drawing.SystemColors.Window;
			_cbo_pub_4.CausesValidation = true;
			_cbo_pub_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_pub_4.Enabled = true;
			_cbo_pub_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_pub_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_pub_4.IntegralHeight = true;
			_cbo_pub_4.Location = new System.Drawing.Point(38, 8);
			_cbo_pub_4.Name = "_cbo_pub_4";
			_cbo_pub_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_pub_4.Size = new System.Drawing.Size(139, 21);
			_cbo_pub_4.Sorted = false;
			_cbo_pub_4.TabIndex = 82;
			_cbo_pub_4.TabStop = true;
			_cbo_pub_4.Visible = true;
			_cbo_pub_4.Enter += new System.EventHandler(cbo_pub_Enter);
			_cbo_pub_4.SelectionChangeCommitted += new System.EventHandler(cbo_pub_SelectionChangeCommitted);
			_cbo_pub_4.TextChanged += new System.EventHandler(cbo_pub_TextChanged);
			// 
			// _lbl_gen_7
			// 
			_lbl_gen_7.AllowDrop = true;
			_lbl_gen_7.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_7.Location = new System.Drawing.Point(4, 38);
			_lbl_gen_7.MinimumSize = new System.Drawing.Size(36, 15);
			_lbl_gen_7.Name = "_lbl_gen_7";
			_lbl_gen_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_7.Size = new System.Drawing.Size(36, 15);
			_lbl_gen_7.TabIndex = 89;
			_lbl_gen_7.Text = "AFTT:";
			_lbl_gen_7.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_3
			// 
			_lbl_gen_3.AllowDrop = true;
			_lbl_gen_3.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_3.Location = new System.Drawing.Point(4, 12);
			_lbl_gen_3.MinimumSize = new System.Drawing.Size(36, 15);
			_lbl_gen_3.Name = "_lbl_gen_3";
			_lbl_gen_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_3.Size = new System.Drawing.Size(36, 15);
			_lbl_gen_3.TabIndex = 83;
			_lbl_gen_3.Text = "Type:";
			_lbl_gen_3.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _txt_pub_3
			// 
			_txt_pub_3.AcceptsReturn = true;
			_txt_pub_3.AllowDrop = true;
			_txt_pub_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_3.Location = new System.Drawing.Point(784, 20);
			_txt_pub_3.MaxLength = 899;
			_txt_pub_3.Multiline = true;
			_txt_pub_3.Name = "_txt_pub_3";
			_txt_pub_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			_txt_pub_3.Size = new System.Drawing.Size(185, 61);
			_txt_pub_3.TabIndex = 72;
			_txt_pub_3.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _cmd_pub_3
			// 
			_cmd_pub_3.AllowDrop = true;
			_cmd_pub_3.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_3.Location = new System.Drawing.Point(184, 70);
			_cmd_pub_3.Name = "_cmd_pub_3";
			_cmd_pub_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_3.Size = new System.Drawing.Size(47, 23);
			_cmd_pub_3.TabIndex = 71;
			_cmd_pub_3.Text = "Find";
			_cmd_pub_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_3.UseVisualStyleBackColor = false;
			_cmd_pub_3.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _cmd_pub_1
			// 
			_cmd_pub_1.AllowDrop = true;
			_cmd_pub_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_1.Location = new System.Drawing.Point(904, 128);
			_cmd_pub_1.Name = "_cmd_pub_1";
			_cmd_pub_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_1.Size = new System.Drawing.Size(71, 37);
			_cmd_pub_1.TabIndex = 70;
			_cmd_pub_1.Text = "Update";
			_cmd_pub_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_1.UseVisualStyleBackColor = false;
			_cmd_pub_1.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _txt_pub_2
			// 
			_txt_pub_2.AcceptsReturn = true;
			_txt_pub_2.AllowDrop = true;
			_txt_pub_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_2.Enabled = false;
			_txt_pub_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_2.Location = new System.Drawing.Point(392, 24);
			_txt_pub_2.MaxLength = 0;
			_txt_pub_2.Multiline = true;
			_txt_pub_2.Name = "_txt_pub_2";
			_txt_pub_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			_txt_pub_2.Size = new System.Drawing.Size(185, 61);
			_txt_pub_2.TabIndex = 69;
			_txt_pub_2.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _txt_pub_0
			// 
			_txt_pub_0.AcceptsReturn = true;
			_txt_pub_0.AllowDrop = true;
			_txt_pub_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_0.Location = new System.Drawing.Point(592, 22);
			_txt_pub_0.MaxLength = 0;
			_txt_pub_0.Multiline = true;
			_txt_pub_0.Name = "_txt_pub_0";
			_txt_pub_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_0.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			_txt_pub_0.Size = new System.Drawing.Size(185, 61);
			_txt_pub_0.TabIndex = 68;
			_txt_pub_0.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _txt_pub_1
			// 
			_txt_pub_1.AcceptsReturn = true;
			_txt_pub_1.AllowDrop = true;
			_txt_pub_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_1.Location = new System.Drawing.Point(56, 69);
			_txt_pub_1.MaxLength = 0;
			_txt_pub_1.Name = "_txt_pub_1";
			_txt_pub_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_1.Size = new System.Drawing.Size(123, 21);
			_txt_pub_1.TabIndex = 67;
			_txt_pub_1.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _cbo_pub_1
			// 
			_cbo_pub_1.AllowDrop = true;
			_cbo_pub_1.BackColor = System.Drawing.SystemColors.Window;
			_cbo_pub_1.CausesValidation = true;
			_cbo_pub_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_pub_1.Enabled = true;
			_cbo_pub_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_pub_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_pub_1.IntegralHeight = true;
			_cbo_pub_1.Location = new System.Drawing.Point(280, 72);
			_cbo_pub_1.Name = "_cbo_pub_1";
			_cbo_pub_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_pub_1.Size = new System.Drawing.Size(113, 21);
			_cbo_pub_1.Sorted = false;
			_cbo_pub_1.TabIndex = 66;
			_cbo_pub_1.TabStop = true;
			_cbo_pub_1.Visible = true;
			_cbo_pub_1.Enter += new System.EventHandler(cbo_pub_Enter);
			_cbo_pub_1.SelectionChangeCommitted += new System.EventHandler(cbo_pub_SelectionChangeCommitted);
			_cbo_pub_1.TextChanged += new System.EventHandler(cbo_pub_TextChanged);
			// 
			// _cbo_pub_0
			// 
			_cbo_pub_0.AllowDrop = true;
			_cbo_pub_0.BackColor = System.Drawing.SystemColors.Window;
			_cbo_pub_0.CausesValidation = true;
			_cbo_pub_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_pub_0.Enabled = true;
			_cbo_pub_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_pub_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_pub_0.IntegralHeight = true;
			_cbo_pub_0.Location = new System.Drawing.Point(104, 43);
			_cbo_pub_0.Name = "_cbo_pub_0";
			_cbo_pub_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_pub_0.Size = new System.Drawing.Size(123, 21);
			_cbo_pub_0.Sorted = false;
			_cbo_pub_0.TabIndex = 65;
			_cbo_pub_0.TabStop = true;
			_cbo_pub_0.Visible = true;
			_cbo_pub_0.Enter += new System.EventHandler(cbo_pub_Enter);
			_cbo_pub_0.SelectionChangeCommitted += new System.EventHandler(cbo_pub_SelectionChangeCommitted);
			_cbo_pub_0.TextChanged += new System.EventHandler(cbo_pub_TextChanged);
			// 
			// _cmd_pub_0
			// 
			_cmd_pub_0.AllowDrop = true;
			_cmd_pub_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_0.Location = new System.Drawing.Point(0, 152);
			_cmd_pub_0.Name = "_cmd_pub_0";
			_cmd_pub_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_0.Size = new System.Drawing.Size(71, 19);
			_cmd_pub_0.TabIndex = 64;
			_cmd_pub_0.Text = "Cancel";
			_cmd_pub_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_0.UseVisualStyleBackColor = false;
			_cmd_pub_0.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _lbl_gen_13
			// 
			_lbl_gen_13.AllowDrop = true;
			_lbl_gen_13.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_13.Location = new System.Drawing.Point(392, 144);
			_lbl_gen_13.MinimumSize = new System.Drawing.Size(30, 15);
			_lbl_gen_13.Name = "_lbl_gen_13";
			_lbl_gen_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_13.Size = new System.Drawing.Size(30, 15);
			_lbl_gen_13.TabIndex = 103;
			_lbl_gen_13.Text = "Date:";
			_lbl_gen_13.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_12
			// 
			_lbl_gen_12.AllowDrop = true;
			_lbl_gen_12.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_12.Location = new System.Drawing.Point(237, 104);
			_lbl_gen_12.MinimumSize = new System.Drawing.Size(50, 15);
			_lbl_gen_12.Name = "_lbl_gen_12";
			_lbl_gen_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_12.Size = new System.Drawing.Size(50, 15);
			_lbl_gen_12.TabIndex = 101;
			_lbl_gen_12.Text = "Cat:";
			_lbl_gen_12.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_0
			// 
			_lbl_gen_0.AllowDrop = true;
			_lbl_gen_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_0.Location = new System.Drawing.Point(138, 152);
			_lbl_gen_0.MinimumSize = new System.Drawing.Size(30, 15);
			_lbl_gen_0.Name = "_lbl_gen_0";
			_lbl_gen_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_0.Size = new System.Drawing.Size(30, 15);
			_lbl_gen_0.TabIndex = 98;
			_lbl_gen_0.Text = "Src:";
			_lbl_gen_0.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_8
			// 
			_lbl_gen_8.AllowDrop = true;
			_lbl_gen_8.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_8.Location = new System.Drawing.Point(124, 124);
			_lbl_gen_8.MinimumSize = new System.Drawing.Size(54, 15);
			_lbl_gen_8.Name = "_lbl_gen_8";
			_lbl_gen_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_8.Size = new System.Drawing.Size(54, 15);
			_lbl_gen_8.TabIndex = 96;
			_lbl_gen_8.Text = "Rating:";
			_lbl_gen_8.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_2
			// 
			_lbl_gen_2.AllowDrop = true;
			_lbl_gen_2.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_2.Location = new System.Drawing.Point(68, 20);
			_lbl_gen_2.MinimumSize = new System.Drawing.Size(66, 15);
			_lbl_gen_2.Name = "_lbl_gen_2";
			_lbl_gen_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_2.Size = new System.Drawing.Size(66, 15);
			_lbl_gen_2.TabIndex = 94;
			_lbl_gen_2.Text = "Title:";
			_lbl_gen_2.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_1
			// 
			_lbl_gen_1.AllowDrop = true;
			_lbl_gen_1.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_1.Location = new System.Drawing.Point(396, 88);
			_lbl_gen_1.MinimumSize = new System.Drawing.Size(66, 15);
			_lbl_gen_1.Name = "_lbl_gen_1";
			_lbl_gen_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_1.Size = new System.Drawing.Size(66, 15);
			_lbl_gen_1.TabIndex = 92;
			_lbl_gen_1.Text = "Url:";
			_lbl_gen_1.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_4
			// 
			_lbl_gen_4.AllowDrop = true;
			_lbl_gen_4.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_4.Location = new System.Drawing.Point(4, 94);
			_lbl_gen_4.MinimumSize = new System.Drawing.Size(66, 15);
			_lbl_gen_4.Name = "_lbl_gen_4";
			_lbl_gen_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_4.Size = new System.Drawing.Size(66, 15);
			_lbl_gen_4.TabIndex = 86;
			_lbl_gen_4.Text = "Comp ID:";
			_lbl_gen_4.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_47
			// 
			_lbl_gen_47.AllowDrop = true;
			_lbl_gen_47.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_47.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_47.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_47.Location = new System.Drawing.Point(784, 4);
			_lbl_gen_47.MinimumSize = new System.Drawing.Size(40, 15);
			_lbl_gen_47.Name = "_lbl_gen_47";
			_lbl_gen_47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_47.Size = new System.Drawing.Size(40, 15);
			_lbl_gen_47.TabIndex = 80;
			_lbl_gen_47.Text = "Notes";
			_lbl_gen_47.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_44
			// 
			_lbl_gen_44.AllowDrop = true;
			_lbl_gen_44.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_44.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_44.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_44.Location = new System.Drawing.Point(592, 8);
			_lbl_gen_44.MinimumSize = new System.Drawing.Size(74, 15);
			_lbl_gen_44.Name = "_lbl_gen_44";
			_lbl_gen_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_44.Size = new System.Drawing.Size(74, 15);
			_lbl_gen_44.TabIndex = 79;
			_lbl_gen_44.Text = "Advertiser";
			_lbl_gen_44.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_43
			// 
			_lbl_gen_43.AllowDrop = true;
			_lbl_gen_43.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_43.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_43.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_43.Location = new System.Drawing.Point(396, 8);
			_lbl_gen_43.MinimumSize = new System.Drawing.Size(102, 15);
			_lbl_gen_43.Name = "_lbl_gen_43";
			_lbl_gen_43.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_43.Size = new System.Drawing.Size(102, 15);
			_lbl_gen_43.TabIndex = 78;
			_lbl_gen_43.Text = "Description";
			_lbl_gen_43.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_42
			// 
			_lbl_gen_42.AllowDrop = true;
			_lbl_gen_42.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_42.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_42.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_42.Location = new System.Drawing.Point(28, 22);
			_lbl_gen_42.MinimumSize = new System.Drawing.Size(98, 15);
			_lbl_gen_42.Name = "_lbl_gen_42";
			_lbl_gen_42.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_42.Size = new System.Drawing.Size(98, 15);
			_lbl_gen_42.TabIndex = 77;
			_lbl_gen_42.Text = "ID";
			_lbl_gen_42.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_41
			// 
			_lbl_gen_41.AllowDrop = true;
			_lbl_gen_41.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_41.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_41.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_41.Location = new System.Drawing.Point(8, 22);
			_lbl_gen_41.MinimumSize = new System.Drawing.Size(98, 15);
			_lbl_gen_41.Name = "_lbl_gen_41";
			_lbl_gen_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_41.Size = new System.Drawing.Size(98, 15);
			_lbl_gen_41.TabIndex = 76;
			_lbl_gen_41.Text = "ID:";
			_lbl_gen_41.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_40
			// 
			_lbl_gen_40.AllowDrop = true;
			_lbl_gen_40.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_40.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_40.Location = new System.Drawing.Point(233, 75);
			_lbl_gen_40.MinimumSize = new System.Drawing.Size(50, 15);
			_lbl_gen_40.Name = "_lbl_gen_40";
			_lbl_gen_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_40.Size = new System.Drawing.Size(50, 15);
			_lbl_gen_40.TabIndex = 75;
			_lbl_gen_40.Text = "Status:";
			_lbl_gen_40.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_39
			// 
			_lbl_gen_39.AllowDrop = true;
			_lbl_gen_39.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_39.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_39.Location = new System.Drawing.Point(6, 72);
			_lbl_gen_39.MinimumSize = new System.Drawing.Size(98, 15);
			_lbl_gen_39.Name = "_lbl_gen_39";
			_lbl_gen_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_39.Size = new System.Drawing.Size(98, 15);
			_lbl_gen_39.TabIndex = 74;
			_lbl_gen_39.Text = "AC ID:";
			_lbl_gen_39.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_38
			// 
			_lbl_gen_38.AllowDrop = true;
			_lbl_gen_38.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_38.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_38.Location = new System.Drawing.Point(6, 46);
			_lbl_gen_38.MinimumSize = new System.Drawing.Size(98, 15);
			_lbl_gen_38.Name = "_lbl_gen_38";
			_lbl_gen_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_38.Size = new System.Drawing.Size(98, 15);
			_lbl_gen_38.TabIndex = 73;
			_lbl_gen_38.Text = "Account REP:";
			_lbl_gen_38.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// tab_NewAvail
			// 
			tab_NewAvail.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_NewAvail.AllowDrop = true;
			tab_NewAvail.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			tab_NewAvail.Controls.Add(_tab_NewAvail_TabPage0);
			tab_NewAvail.Controls.Add(_tab_NewAvail_TabPage1);
			tab_NewAvail.Controls.Add(_tab_NewAvail_TabPage2);
			tab_NewAvail.Controls.Add(_tab_NewAvail_TabPage3);
			tab_NewAvail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_NewAvail.ItemSize = new System.Drawing.Size(245, 18);
			tab_NewAvail.Location = new System.Drawing.Point(8, 58);
			tab_NewAvail.Multiline = true;
			tab_NewAvail.Name = "tab_NewAvail";
			tab_NewAvail.Size = new System.Drawing.Size(991, 474);
			tab_NewAvail.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_NewAvail.TabIndex = 5;
			tab_NewAvail.SelectedIndexChanged += new System.EventHandler(tab_NewAvail_SelectedIndexChanged);
			// 
			// _tab_NewAvail_TabPage0
			// 
			_tab_NewAvail_TabPage0.Controls.Add(lbl_Status);
			_tab_NewAvail_TabPage0.Controls.Add(grd_NewAvail);
			_tab_NewAvail_TabPage0.Controls.Add(cmdClear);
			_tab_NewAvail_TabPage0.Controls.Add(cmdAddPub);
			_tab_NewAvail_TabPage0.Controls.Add(cmd_Stop);
			_tab_NewAvail_TabPage0.Controls.Add(cmdSendVerifyEMail);
			_tab_NewAvail_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_NewAvail_TabPage0.Text = "New Tasks Available";
			// 
			// lbl_Status
			// 
			lbl_Status.AllowDrop = true;
			lbl_Status.AutoSize = true;
			lbl_Status.BackColor = System.Drawing.SystemColors.Control;
			lbl_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Status.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Status.Location = new System.Drawing.Point(10, 424);
			lbl_Status.MinimumSize = new System.Drawing.Size(57, 20);
			lbl_Status.Name = "lbl_Status";
			lbl_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Status.Size = new System.Drawing.Size(57, 20);
			lbl_Status.TabIndex = 32;
			lbl_Status.Text = "Loading";
			// 
			// grd_NewAvail
			// 
			grd_NewAvail.AllowBigSelection = false;
			grd_NewAvail.AllowDrop = true;
			grd_NewAvail.AllowUserToAddRows = false;
			grd_NewAvail.AllowUserToDeleteRows = false;
			grd_NewAvail.AllowUserToResizeColumns = false;
			grd_NewAvail.AllowUserToResizeColumns = grd_NewAvail.ColumnHeadersVisible;
			grd_NewAvail.AllowUserToResizeRows = false;
			grd_NewAvail.AllowUserToResizeRows = grd_NewAvail.RowHeadersVisible;
			grd_NewAvail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_NewAvail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_NewAvail.ColumnsCount = 2;
			grd_NewAvail.Enabled = false;
			grd_NewAvail.FixedColumns = 1;
			grd_NewAvail.FixedRows = 1;
			grd_NewAvail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grd_NewAvail.Location = new System.Drawing.Point(12, 40);
			grd_NewAvail.Name = "grd_NewAvail";
			grd_NewAvail.ReadOnly = true;
			grd_NewAvail.RowsCount = 2;
			grd_NewAvail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_NewAvail.ShowCellToolTips = false;
			grd_NewAvail.Size = new System.Drawing.Size(973, 374);
			grd_NewAvail.StandardTab = true;
			grd_NewAvail.TabIndex = 28;
			grd_NewAvail.Click += new System.EventHandler(grd_NewAvail_Click);
			grd_NewAvail.DoubleClick += new System.EventHandler(grd_NewAvail_DoubleClick);
			// 
			// cmdClear
			// 
			cmdClear.AllowDrop = true;
			cmdClear.BackColor = System.Drawing.SystemColors.Control;
			cmdClear.Enabled = false;
			cmdClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClear.Location = new System.Drawing.Point(889, 424);
			cmdClear.Name = "cmdClear";
			cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClear.Size = new System.Drawing.Size(88, 20);
			cmdClear.TabIndex = 7;
			cmdClear.Text = "Clear Pub";
			cmdClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClear.Click += new System.EventHandler(cmdClear_Click);
			// 
			// cmdAddPub
			// 
			cmdAddPub.AllowDrop = true;
			cmdAddPub.BackColor = System.Drawing.SystemColors.Control;
			cmdAddPub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAddPub.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAddPub.Location = new System.Drawing.Point(770, 424);
			cmdAddPub.Name = "cmdAddPub";
			cmdAddPub.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAddPub.Size = new System.Drawing.Size(116, 20);
			cmdAddPub.TabIndex = 6;
			cmdAddPub.Text = "Add New Pub";
			cmdAddPub.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAddPub.UseVisualStyleBackColor = false;
			cmdAddPub.Click += new System.EventHandler(cmdAddPub_Click);
			// 
			// cmd_Stop
			// 
			cmd_Stop.AllowDrop = true;
			cmd_Stop.BackColor = System.Drawing.SystemColors.Control;
			cmd_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Stop.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Stop.Location = new System.Drawing.Point(464, 424);
			cmd_Stop.Name = "cmd_Stop";
			cmd_Stop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Stop.Size = new System.Drawing.Size(70, 20);
			cmd_Stop.TabIndex = 49;
			cmd_Stop.Text = "Stop";
			cmd_Stop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Stop.UseVisualStyleBackColor = false;
			cmd_Stop.Click += new System.EventHandler(cmd_Stop_Click);
			// 
			// cmdSendVerifyEMail
			// 
			cmdSendVerifyEMail.AllowDrop = true;
			cmdSendVerifyEMail.BackColor = System.Drawing.SystemColors.Control;
			cmdSendVerifyEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSendVerifyEMail.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSendVerifyEMail.Location = new System.Drawing.Point(642, 424);
			cmdSendVerifyEMail.Name = "cmdSendVerifyEMail";
			cmdSendVerifyEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSendVerifyEMail.Size = new System.Drawing.Size(116, 20);
			cmdSendVerifyEMail.TabIndex = 4;
			cmdSendVerifyEMail.Text = "Send Verify EMail";
			cmdSendVerifyEMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSendVerifyEMail.UseVisualStyleBackColor = false;
			cmdSendVerifyEMail.Click += new System.EventHandler(cmdSendVerifyEMail_Click);
			// 
			// _tab_NewAvail_TabPage1
			// 
			_tab_NewAvail_TabPage1.Controls.Add(Label1);
			_tab_NewAvail_TabPage1.Controls.Add(Label2);
			_tab_NewAvail_TabPage1.Controls.Add(Label14);
			_tab_NewAvail_TabPage1.Controls.Add(WbBrowser);
			_tab_NewAvail_TabPage1.Controls.Add(cmd_GetAvail);
			_tab_NewAvail_TabPage1.Controls.Add(cbo_WebSite);
			_tab_NewAvail_TabPage1.Controls.Add(txt_NumDays);
			_tab_NewAvail_TabPage1.Controls.Add(txt_EMailAddress);
			_tab_NewAvail_TabPage1.Controls.Add(Chk_Dups);
			_tab_NewAvail_TabPage1.Controls.Add(txt_years_diff);
			_tab_NewAvail_TabPage1.Controls.Add(txt_status);
			_tab_NewAvail_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_NewAvail_TabPage1.Text = "Search for New Tasks Available";
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.AutoSize = true;
			Label1.BackColor = System.Drawing.Color.Transparent;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(122, 48);
			Label1.MinimumSize = new System.Drawing.Size(86, 13);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(86, 13);
			Label1.TabIndex = 29;
			Label1.Text = "Reporting Source:";
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.AutoSize = true;
			Label2.BackColor = System.Drawing.Color.Transparent;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			Label2.Location = new System.Drawing.Point(128, 72);
			Label2.MinimumSize = new System.Drawing.Size(79, 13);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(79, 13);
			Label2.TabIndex = 30;
			Label2.Text = "Number of Days:";
			// 
			// Label14
			// 
			Label14.AllowDrop = true;
			Label14.AutoSize = true;
			Label14.BackColor = System.Drawing.Color.Transparent;
			Label14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label14.ForeColor = System.Drawing.SystemColors.ControlText;
			Label14.Location = new System.Drawing.Point(125, 96);
			Label14.MinimumSize = new System.Drawing.Size(82, 13);
			Label14.Name = "Label14";
			Label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label14.Size = new System.Drawing.Size(82, 13);
			Label14.TabIndex = 44;
			Label14.Text = "Email Results To:";
			// 
			// WbBrowser
			// 
			WbBrowser.AllowWebBrowserDrop = true;
			WbBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			WbBrowser.Location = new System.Drawing.Point(10, 240);
			WbBrowser.Name = "WbBrowser";
			WbBrowser.Size = new System.Drawing.Size(967, 205);
			WbBrowser.TabIndex = 56;
			WbBrowser.Visible = false;
			// 
			// cmd_GetAvail
			// 
			cmd_GetAvail.AllowDrop = true;
			cmd_GetAvail.BackColor = System.Drawing.SystemColors.Control;
			cmd_GetAvail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_GetAvail.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_GetAvail.Location = new System.Drawing.Point(213, 115);
			cmd_GetAvail.Name = "cmd_GetAvail";
			cmd_GetAvail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_GetAvail.Size = new System.Drawing.Size(89, 25);
			cmd_GetAvail.TabIndex = 27;
			cmd_GetAvail.Text = "Get Availables";
			cmd_GetAvail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_GetAvail.UseVisualStyleBackColor = false;
			cmd_GetAvail.Click += new System.EventHandler(cmd_GetAvail_Click);
			// 
			// cbo_WebSite
			// 
			cbo_WebSite.AllowDrop = true;
			cbo_WebSite.BackColor = System.Drawing.SystemColors.Window;
			cbo_WebSite.CausesValidation = true;
			cbo_WebSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_WebSite.Enabled = true;
			cbo_WebSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_WebSite.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_WebSite.IntegralHeight = true;
			cbo_WebSite.Location = new System.Drawing.Point(211, 47);
			cbo_WebSite.Name = "cbo_WebSite";
			cbo_WebSite.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_WebSite.Size = new System.Drawing.Size(225, 21);
			cbo_WebSite.Sorted = false;
			cbo_WebSite.TabIndex = 24;
			cbo_WebSite.TabStop = true;
			cbo_WebSite.Visible = true;
			cbo_WebSite.SelectionChangeCommitted += new System.EventHandler(cbo_WebSite_SelectionChangeCommitted);
			// 
			// txt_NumDays
			// 
			txt_NumDays.AcceptsReturn = true;
			txt_NumDays.AllowDrop = true;
			txt_NumDays.BackColor = System.Drawing.SystemColors.Window;
			txt_NumDays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_NumDays.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_NumDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_NumDays.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_NumDays.Location = new System.Drawing.Point(212, 71);
			txt_NumDays.MaxLength = 0;
			txt_NumDays.Name = "txt_NumDays";
			txt_NumDays.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_NumDays.Size = new System.Drawing.Size(57, 19);
			txt_NumDays.TabIndex = 25;
			// 
			// txt_EMailAddress
			// 
			txt_EMailAddress.AcceptsReturn = true;
			txt_EMailAddress.AllowDrop = true;
			txt_EMailAddress.BackColor = System.Drawing.SystemColors.Window;
			txt_EMailAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_EMailAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_EMailAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_EMailAddress.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_EMailAddress.Location = new System.Drawing.Point(212, 93);
			txt_EMailAddress.MaxLength = 0;
			txt_EMailAddress.Name = "txt_EMailAddress";
			txt_EMailAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_EMailAddress.Size = new System.Drawing.Size(181, 19);
			txt_EMailAddress.TabIndex = 26;
			// 
			// Chk_Dups
			// 
			Chk_Dups.AllowDrop = true;
			Chk_Dups.Appearance = System.Windows.Forms.Appearance.Normal;
			Chk_Dups.BackColor = System.Drawing.SystemColors.Control;
			Chk_Dups.CausesValidation = true;
			Chk_Dups.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_Dups.CheckState = System.Windows.Forms.CheckState.Checked;
			Chk_Dups.Enabled = true;
			Chk_Dups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Chk_Dups.ForeColor = System.Drawing.SystemColors.ControlText;
			Chk_Dups.Location = new System.Drawing.Point(328, 119);
			Chk_Dups.Name = "Chk_Dups";
			Chk_Dups.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Chk_Dups.Size = new System.Drawing.Size(424, 20);
			Chk_Dups.TabIndex = 51;
			Chk_Dups.TabStop = true;
			Chk_Dups.Text = "Check to be prompted when Duplicates found, difference in years must be less than";
			Chk_Dups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_Dups.Visible = true;
			// 
			// txt_years_diff
			// 
			txt_years_diff.AcceptsReturn = true;
			txt_years_diff.AllowDrop = true;
			txt_years_diff.BackColor = System.Drawing.SystemColors.Window;
			txt_years_diff.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_years_diff.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_years_diff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_years_diff.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_years_diff.Location = new System.Drawing.Point(752, 116);
			txt_years_diff.MaxLength = 0;
			txt_years_diff.Name = "txt_years_diff";
			txt_years_diff.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_years_diff.Size = new System.Drawing.Size(28, 24);
			txt_years_diff.TabIndex = 54;
			txt_years_diff.Text = "3";
			txt_years_diff.Leave += new System.EventHandler(txt_years_diff_Leave);
			// 
			// txt_status
			// 
			txt_status.AcceptsReturn = true;
			txt_status.AllowDrop = true;
			txt_status.BackColor = System.Drawing.SystemColors.Window;
			txt_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_status.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_status.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_status.Location = new System.Drawing.Point(150, 143);
			txt_status.MaxLength = 0;
			txt_status.Name = "txt_status";
			txt_status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_status.Size = new System.Drawing.Size(688, 86);
			txt_status.TabIndex = 57;
			// 
			// _tab_NewAvail_TabPage2
			// 
			_tab_NewAvail_TabPage2.Controls.Add(pnl_pub_listing);
			_tab_NewAvail_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_NewAvail_TabPage2.Text = "New Task";
			// 
			// pnl_pub_listing
			// 
			pnl_pub_listing.AllowDrop = true;
			pnl_pub_listing.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			pnl_pub_listing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_pub_listing.Controls.Add(_cmd_pub_17);
			pnl_pub_listing.Controls.Add(_cbo_pub_11);
			pnl_pub_listing.Controls.Add(_cmd_pub_10);
			pnl_pub_listing.Controls.Add(_cmd_pub_16);
			pnl_pub_listing.Controls.Add(_cmd_pub_4);
			pnl_pub_listing.Controls.Add(_cmd_pub_7);
			pnl_pub_listing.Controls.Add(cmd_clear_pub);
			pnl_pub_listing.Controls.Add(_cmd_pub_9);
			pnl_pub_listing.Controls.Add(frm_listing1);
			pnl_pub_listing.Controls.Add(pnl_add_model_exception);
			pnl_pub_listing.Controls.Add(_lbl_gen_23);
			pnl_pub_listing.Controls.Add(_lbl_gen_45);
			pnl_pub_listing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_pub_listing.Location = new System.Drawing.Point(16, 12);
			pnl_pub_listing.Name = "pnl_pub_listing";
			pnl_pub_listing.Size = new System.Drawing.Size(979, 439);
			pnl_pub_listing.TabIndex = 62;
			// 
			// _cmd_pub_17
			// 
			_cmd_pub_17.AllowDrop = true;
			_cmd_pub_17.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_17.Location = new System.Drawing.Point(160, 408);
			_cmd_pub_17.Name = "_cmd_pub_17";
			_cmd_pub_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_17.Size = new System.Drawing.Size(81, 20);
			_cmd_pub_17.TabIndex = 188;
			_cmd_pub_17.Text = "Change Rep";
			_cmd_pub_17.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_17.UseVisualStyleBackColor = false;
			_cmd_pub_17.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _cbo_pub_11
			// 
			_cbo_pub_11.AllowDrop = true;
			_cbo_pub_11.BackColor = System.Drawing.SystemColors.Window;
			_cbo_pub_11.CausesValidation = true;
			_cbo_pub_11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_pub_11.Enabled = true;
			_cbo_pub_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_pub_11.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_pub_11.IntegralHeight = true;
			_cbo_pub_11.Location = new System.Drawing.Point(64, 408);
			_cbo_pub_11.Name = "_cbo_pub_11";
			_cbo_pub_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_pub_11.Size = new System.Drawing.Size(97, 21);
			_cbo_pub_11.Sorted = false;
			_cbo_pub_11.TabIndex = 186;
			_cbo_pub_11.TabStop = true;
			_cbo_pub_11.Visible = true;
			_cbo_pub_11.Enter += new System.EventHandler(cbo_pub_Enter);
			_cbo_pub_11.SelectionChangeCommitted += new System.EventHandler(cbo_pub_SelectionChangeCommitted);
			_cbo_pub_11.TextChanged += new System.EventHandler(cbo_pub_TextChanged);
			// 
			// _cmd_pub_10
			// 
			_cmd_pub_10.AllowDrop = true;
			_cmd_pub_10.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_10.Location = new System.Drawing.Point(584, 408);
			_cmd_pub_10.Name = "_cmd_pub_10";
			_cmd_pub_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_10.Size = new System.Drawing.Size(113, 21);
			_cmd_pub_10.TabIndex = 185;
			_cmd_pub_10.Text = "Send CSD Email";
			_cmd_pub_10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_10.UseVisualStyleBackColor = false;
			_cmd_pub_10.Visible = false;
			_cmd_pub_10.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _cmd_pub_16
			// 
			_cmd_pub_16.AllowDrop = true;
			_cmd_pub_16.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_16.Location = new System.Drawing.Point(584, 392);
			_cmd_pub_16.Name = "_cmd_pub_16";
			_cmd_pub_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_16.Size = new System.Drawing.Size(203, 15);
			_cmd_pub_16.TabIndex = 180;
			_cmd_pub_16.Text = "Complete CSD";
			_cmd_pub_16.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_16.UseVisualStyleBackColor = false;
			_cmd_pub_16.Visible = false;
			_cmd_pub_16.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _cmd_pub_4
			// 
			_cmd_pub_4.AllowDrop = true;
			_cmd_pub_4.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_4.Location = new System.Drawing.Point(872, 408);
			_cmd_pub_4.Name = "_cmd_pub_4";
			_cmd_pub_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_4.Size = new System.Drawing.Size(91, 21);
			_cmd_pub_4.TabIndex = 136;
			_cmd_pub_4.Text = "Add New";
			_cmd_pub_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_4.UseVisualStyleBackColor = false;
			_cmd_pub_4.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _cmd_pub_7
			// 
			_cmd_pub_7.AllowDrop = true;
			_cmd_pub_7.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_7.Location = new System.Drawing.Point(704, 408);
			_cmd_pub_7.Name = "_cmd_pub_7";
			_cmd_pub_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_7.Size = new System.Drawing.Size(159, 21);
			_cmd_pub_7.TabIndex = 135;
			_cmd_pub_7.Text = "Add New Model Exception";
			_cmd_pub_7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_7.UseVisualStyleBackColor = false;
			_cmd_pub_7.Visible = false;
			_cmd_pub_7.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// cmd_clear_pub
			// 
			cmd_clear_pub.AllowDrop = true;
			cmd_clear_pub.BackColor = System.Drawing.SystemColors.Control;
			cmd_clear_pub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_clear_pub.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_clear_pub.Location = new System.Drawing.Point(0, 376);
			cmd_clear_pub.Name = "cmd_clear_pub";
			cmd_clear_pub.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_clear_pub.Size = new System.Drawing.Size(115, 20);
			cmd_clear_pub.TabIndex = 130;
			cmd_clear_pub.Text = "Clear Pub ID";
			cmd_clear_pub.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_clear_pub.UseVisualStyleBackColor = false;
			cmd_clear_pub.Visible = false;
			cmd_clear_pub.Click += new System.EventHandler(cmd_clear_pub_Click);
			// 
			// _cmd_pub_9
			// 
			_cmd_pub_9.AllowDrop = true;
			_cmd_pub_9.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_9.Location = new System.Drawing.Point(128, 376);
			_cmd_pub_9.Name = "_cmd_pub_9";
			_cmd_pub_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_9.Size = new System.Drawing.Size(113, 20);
			_cmd_pub_9.TabIndex = 129;
			_cmd_pub_9.Text = "Send Verify Email";
			_cmd_pub_9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_9.UseVisualStyleBackColor = false;
			_cmd_pub_9.Visible = false;
			_cmd_pub_9.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// frm_listing1
			// 
			frm_listing1.AllowDrop = true;
			frm_listing1.BackColor = System.Drawing.SystemColors.Control;
			frm_listing1.Controls.Add(fgrdFindCustSubData);
			frm_listing1.Controls.Add(opSubmitAircraft);
			frm_listing1.Controls.Add(opSubmitCompany);
			frm_listing1.Controls.Add(opSubmitBoth);
			frm_listing1.Controls.Add(_chk_include_25);
			frm_listing1.Controls.Add(_cbo_pub_10);
			frm_listing1.Controls.Add(_chk_include_3);
			frm_listing1.Controls.Add(_chk_include_2);
			frm_listing1.Controls.Add(_chk_include_0);
			frm_listing1.Controls.Add(_chk_include_1);
			frm_listing1.Controls.Add(_cbo_pub_2);
			frm_listing1.Controls.Add(_cmd_pub_2);
			frm_listing1.Controls.Add(_txt_pub_7);
			frm_listing1.Controls.Add(_chk_include_4);
			frm_listing1.Controls.Add(_chk_include_5);
			frm_listing1.Controls.Add(_chk_include_7);
			frm_listing1.Controls.Add(_txt_pub_11);
			frm_listing1.Controls.Add(_txt_pub_12);
			frm_listing1.Controls.Add(_txt_pub_13);
			frm_listing1.Controls.Add(_chk_include_8);
			frm_listing1.Controls.Add(_cbo_pub_7);
			frm_listing1.Controls.Add(_chk_include_9);
			frm_listing1.Controls.Add(_chk_include_10);
			frm_listing1.Controls.Add(_chk_include_11);
			frm_listing1.Controls.Add(grd_pub);
			frm_listing1.Controls.Add(_lbl_gen_21);
			frm_listing1.Controls.Add(_lbl_gen_46);
			frm_listing1.Controls.Add(_lbl_gen_5);
			frm_listing1.Controls.Add(_lbl_gen_9);
			frm_listing1.Controls.Add(_lbl_gen_10);
			frm_listing1.Controls.Add(_lbl_gen_11);
			frm_listing1.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_listing1.Enabled = true;
			frm_listing1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_listing1.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_listing1.Location = new System.Drawing.Point(-8, -28);
			frm_listing1.Name = "frm_listing1";
			frm_listing1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_listing1.Size = new System.Drawing.Size(977, 401);
			frm_listing1.TabIndex = 104;
			frm_listing1.Visible = true;
			// 
			// fgrdFindCustSubData
			// 
			fgrdFindCustSubData.AllowDrop = true;
			fgrdFindCustSubData.AllowUserToAddRows = false;
			fgrdFindCustSubData.AllowUserToDeleteRows = false;
			fgrdFindCustSubData.AllowUserToResizeColumns = false;
			fgrdFindCustSubData.AllowUserToResizeColumns = fgrdFindCustSubData.ColumnHeadersVisible;
			fgrdFindCustSubData.AllowUserToResizeRows = false;
			fgrdFindCustSubData.AllowUserToResizeRows = false;
			fgrdFindCustSubData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			fgrdFindCustSubData.ColumnsCount = 2;
			fgrdFindCustSubData.FixedColumns = 1;
			fgrdFindCustSubData.FixedRows = 1;
			fgrdFindCustSubData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fgrdFindCustSubData.Location = new System.Drawing.Point(8, 277);
			fgrdFindCustSubData.Name = "fgrdFindCustSubData";
			fgrdFindCustSubData.ReadOnly = true;
			fgrdFindCustSubData.RowsCount = 2;
			fgrdFindCustSubData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			fgrdFindCustSubData.ShowCellToolTips = false;
			fgrdFindCustSubData.Size = new System.Drawing.Size(956, 129);
			fgrdFindCustSubData.StandardTab = true;
			fgrdFindCustSubData.TabIndex = 184;
			fgrdFindCustSubData.Click += new System.EventHandler(fgrdFindCustSubData_Click);
			fgrdFindCustSubData.DoubleClick += new System.EventHandler(fgrdFindCustSubData_DoubleClick);
			fgrdFindCustSubData.MouseDown += new System.Windows.Forms.MouseEventHandler(fgrdFindCustSubData_MouseDown);
			// 
			// opSubmitAircraft
			// 
			opSubmitAircraft.AllowDrop = true;
			opSubmitAircraft.BackColor = System.Drawing.SystemColors.Control;
			opSubmitAircraft.CausesValidation = true;
			opSubmitAircraft.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opSubmitAircraft.Checked = false;
			opSubmitAircraft.Enabled = true;
			opSubmitAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opSubmitAircraft.ForeColor = System.Drawing.SystemColors.ControlText;
			opSubmitAircraft.Location = new System.Drawing.Point(8, 384);
			opSubmitAircraft.Name = "opSubmitAircraft";
			opSubmitAircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opSubmitAircraft.Size = new System.Drawing.Size(85, 20);
			opSubmitAircraft.TabIndex = 183;
			opSubmitAircraft.TabStop = true;
			opSubmitAircraft.Text = "Aircraft";
			opSubmitAircraft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opSubmitAircraft.Visible = true;
			// 
			// opSubmitCompany
			// 
			opSubmitCompany.AllowDrop = true;
			opSubmitCompany.BackColor = System.Drawing.SystemColors.Control;
			opSubmitCompany.CausesValidation = true;
			opSubmitCompany.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opSubmitCompany.Checked = true;
			opSubmitCompany.Enabled = true;
			opSubmitCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opSubmitCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			opSubmitCompany.Location = new System.Drawing.Point(104, 384);
			opSubmitCompany.Name = "opSubmitCompany";
			opSubmitCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opSubmitCompany.Size = new System.Drawing.Size(109, 20);
			opSubmitCompany.TabIndex = 182;
			opSubmitCompany.TabStop = true;
			opSubmitCompany.Text = "Company";
			opSubmitCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opSubmitCompany.Visible = true;
			// 
			// opSubmitBoth
			// 
			opSubmitBoth.AllowDrop = true;
			opSubmitBoth.BackColor = System.Drawing.SystemColors.Control;
			opSubmitBoth.CausesValidation = true;
			opSubmitBoth.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opSubmitBoth.Checked = false;
			opSubmitBoth.Enabled = true;
			opSubmitBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opSubmitBoth.ForeColor = System.Drawing.SystemColors.ControlText;
			opSubmitBoth.Location = new System.Drawing.Point(224, 384);
			opSubmitBoth.Name = "opSubmitBoth";
			opSubmitBoth.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opSubmitBoth.Size = new System.Drawing.Size(69, 20);
			opSubmitBoth.TabIndex = 181;
			opSubmitBoth.TabStop = true;
			opSubmitBoth.Text = "Both";
			opSubmitBoth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opSubmitBoth.Visible = true;
			// 
			// _chk_include_25
			// 
			_chk_include_25.AllowDrop = true;
			_chk_include_25.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_25.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_25.CausesValidation = true;
			_chk_include_25.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_25.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_25.Enabled = true;
			_chk_include_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_25.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_25.Location = new System.Drawing.Point(26, 72);
			_chk_include_25.Name = "_chk_include_25";
			_chk_include_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_25.Size = new System.Drawing.Size(119, 20);
			_chk_include_25.TabIndex = 179;
			_chk_include_25.TabStop = true;
			_chk_include_25.Text = "Include Class E";
			_chk_include_25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_25.Visible = true;
			_chk_include_25.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _cbo_pub_10
			// 
			_cbo_pub_10.AllowDrop = true;
			_cbo_pub_10.BackColor = System.Drawing.SystemColors.Window;
			_cbo_pub_10.CausesValidation = true;
			_cbo_pub_10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_pub_10.Enabled = true;
			_cbo_pub_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_pub_10.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_pub_10.IntegralHeight = true;
			_cbo_pub_10.Location = new System.Drawing.Point(264, 54);
			_cbo_pub_10.Name = "_cbo_pub_10";
			_cbo_pub_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_pub_10.Size = new System.Drawing.Size(132, 21);
			_cbo_pub_10.Sorted = false;
			_cbo_pub_10.TabIndex = 173;
			_cbo_pub_10.TabStop = true;
			_cbo_pub_10.Visible = true;
			_cbo_pub_10.Enter += new System.EventHandler(cbo_pub_Enter);
			_cbo_pub_10.SelectionChangeCommitted += new System.EventHandler(cbo_pub_SelectionChangeCommitted);
			_cbo_pub_10.TextChanged += new System.EventHandler(cbo_pub_TextChanged);
			// 
			// _chk_include_3
			// 
			_chk_include_3.AllowDrop = true;
			_chk_include_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_3.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_3.CausesValidation = true;
			_chk_include_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_3.Enabled = true;
			_chk_include_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_3.Location = new System.Drawing.Point(524, 24);
			_chk_include_3.Name = "_chk_include_3";
			_chk_include_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_3.Size = new System.Drawing.Size(93, 20);
			_chk_include_3.TabIndex = 122;
			_chk_include_3.TabStop = true;
			_chk_include_3.Text = "2nd Attempt";
			_chk_include_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_3.Visible = true;
			_chk_include_3.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_2
			// 
			_chk_include_2.AllowDrop = true;
			_chk_include_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_2.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_2.CausesValidation = true;
			_chk_include_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_2.Enabled = true;
			_chk_include_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_2.Location = new System.Drawing.Point(620, 48);
			_chk_include_2.Name = "_chk_include_2";
			_chk_include_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_2.Size = new System.Drawing.Size(89, 20);
			_chk_include_2.TabIndex = 121;
			_chk_include_2.TabStop = true;
			_chk_include_2.Text = "Completed";
			_chk_include_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_2.Visible = true;
			_chk_include_2.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_0
			// 
			_chk_include_0.AllowDrop = true;
			_chk_include_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_0.CausesValidation = true;
			_chk_include_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_0.CheckState = System.Windows.Forms.CheckState.Checked;
			_chk_include_0.Enabled = true;
			_chk_include_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_0.Location = new System.Drawing.Point(724, 24);
			_chk_include_0.Name = "_chk_include_0";
			_chk_include_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_0.Size = new System.Drawing.Size(57, 20);
			_chk_include_0.TabIndex = 120;
			_chk_include_0.TabStop = true;
			_chk_include_0.Text = "Open";
			_chk_include_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_0.Visible = true;
			_chk_include_0.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_1
			// 
			_chk_include_1.AllowDrop = true;
			_chk_include_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_1.CausesValidation = true;
			_chk_include_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_1.Enabled = true;
			_chk_include_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_1.Location = new System.Drawing.Point(820, 24);
			_chk_include_1.Name = "_chk_include_1";
			_chk_include_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_1.Size = new System.Drawing.Size(65, 20);
			_chk_include_1.TabIndex = 119;
			_chk_include_1.TabStop = true;
			_chk_include_1.Text = "Cleared";
			_chk_include_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_1.Visible = true;
			_chk_include_1.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _cbo_pub_2
			// 
			_cbo_pub_2.AllowDrop = true;
			_cbo_pub_2.BackColor = System.Drawing.SystemColors.Window;
			_cbo_pub_2.CausesValidation = true;
			_cbo_pub_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_pub_2.Enabled = true;
			_cbo_pub_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_pub_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_pub_2.IntegralHeight = true;
			_cbo_pub_2.Location = new System.Drawing.Point(88, 30);
			_cbo_pub_2.Name = "_cbo_pub_2";
			_cbo_pub_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_pub_2.Size = new System.Drawing.Size(219, 21);
			_cbo_pub_2.Sorted = false;
			_cbo_pub_2.TabIndex = 118;
			_cbo_pub_2.TabStop = true;
			_cbo_pub_2.Visible = true;
			_cbo_pub_2.Enter += new System.EventHandler(cbo_pub_Enter);
			_cbo_pub_2.SelectionChangeCommitted += new System.EventHandler(cbo_pub_SelectionChangeCommitted);
			_cbo_pub_2.TextChanged += new System.EventHandler(cbo_pub_TextChanged);
			// 
			// _cmd_pub_2
			// 
			_cmd_pub_2.AllowDrop = true;
			_cmd_pub_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_2.Location = new System.Drawing.Point(904, 24);
			_cmd_pub_2.Name = "_cmd_pub_2";
			_cmd_pub_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_2.Size = new System.Drawing.Size(69, 31);
			_cmd_pub_2.TabIndex = 117;
			_cmd_pub_2.Text = "Search";
			_cmd_pub_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_2.UseVisualStyleBackColor = false;
			_cmd_pub_2.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _txt_pub_7
			// 
			_txt_pub_7.AcceptsReturn = true;
			_txt_pub_7.AllowDrop = true;
			_txt_pub_7.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_7.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_7.Location = new System.Drawing.Point(368, 30);
			_txt_pub_7.MaxLength = 0;
			_txt_pub_7.Name = "_txt_pub_7";
			_txt_pub_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_7.Size = new System.Drawing.Size(155, 21);
			_txt_pub_7.TabIndex = 116;
			_txt_pub_7.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _chk_include_4
			// 
			_chk_include_4.AllowDrop = true;
			_chk_include_4.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_4.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_4.CausesValidation = true;
			_chk_include_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_4.Enabled = true;
			_chk_include_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_4.Location = new System.Drawing.Point(26, 54);
			_chk_include_4.Name = "_chk_include_4";
			_chk_include_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_4.Size = new System.Drawing.Size(151, 20);
			_chk_include_4.TabIndex = 115;
			_chk_include_4.TabStop = true;
			_chk_include_4.Text = "Include PUB Groups";
			_chk_include_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_4.Visible = true;
			_chk_include_4.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_5
			// 
			_chk_include_5.AllowDrop = true;
			_chk_include_5.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_5.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_5.CausesValidation = true;
			_chk_include_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_5.CheckState = System.Windows.Forms.CheckState.Checked;
			_chk_include_5.Enabled = true;
			_chk_include_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_5.Location = new System.Drawing.Point(724, 46);
			_chk_include_5.Name = "_chk_include_5";
			_chk_include_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_5.Size = new System.Drawing.Size(91, 20);
			_chk_include_5.TabIndex = 114;
			_chk_include_5.TabStop = true;
			_chk_include_5.Text = "In Progress";
			_chk_include_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_5.Visible = true;
			_chk_include_5.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_7
			// 
			_chk_include_7.AllowDrop = true;
			_chk_include_7.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_7.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_7.CausesValidation = true;
			_chk_include_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_7.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_7.Enabled = true;
			_chk_include_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_7.Location = new System.Drawing.Point(820, 41);
			_chk_include_7.Name = "_chk_include_7";
			_chk_include_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_7.Size = new System.Drawing.Size(83, 26);
			_chk_include_7.TabIndex = 113;
			_chk_include_7.TabStop = true;
			_chk_include_7.Text = "No Action Required";
			_chk_include_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_7.Visible = true;
			_chk_include_7.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _txt_pub_11
			// 
			_txt_pub_11.AcceptsReturn = true;
			_txt_pub_11.AllowDrop = true;
			_txt_pub_11.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_11.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_11.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_11.Location = new System.Drawing.Point(268, 76);
			_txt_pub_11.MaxLength = 0;
			_txt_pub_11.Name = "_txt_pub_11";
			_txt_pub_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_11.Size = new System.Drawing.Size(197, 21);
			_txt_pub_11.TabIndex = 112;
			_txt_pub_11.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _txt_pub_12
			// 
			_txt_pub_12.AcceptsReturn = true;
			_txt_pub_12.AllowDrop = true;
			_txt_pub_12.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_12.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_12.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_12.Location = new System.Drawing.Point(540, 76);
			_txt_pub_12.MaxLength = 0;
			_txt_pub_12.Name = "_txt_pub_12";
			_txt_pub_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_12.Size = new System.Drawing.Size(69, 19);
			_txt_pub_12.TabIndex = 111;
			_txt_pub_12.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _txt_pub_13
			// 
			_txt_pub_13.AcceptsReturn = true;
			_txt_pub_13.AllowDrop = true;
			_txt_pub_13.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_13.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_13.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_13.Location = new System.Drawing.Point(636, 76);
			_txt_pub_13.MaxLength = 0;
			_txt_pub_13.Name = "_txt_pub_13";
			_txt_pub_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_13.Size = new System.Drawing.Size(69, 19);
			_txt_pub_13.TabIndex = 110;
			_txt_pub_13.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _chk_include_8
			// 
			_chk_include_8.AllowDrop = true;
			_chk_include_8.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_8.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_8.CausesValidation = true;
			_chk_include_8.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_8.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_8.Enabled = true;
			_chk_include_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_8.Location = new System.Drawing.Point(724, 64);
			_chk_include_8.Name = "_chk_include_8";
			_chk_include_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_8.Size = new System.Drawing.Size(91, 20);
			_chk_include_8.TabIndex = 109;
			_chk_include_8.TabStop = true;
			_chk_include_8.Text = "Blind";
			_chk_include_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_8.Visible = true;
			_chk_include_8.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _cbo_pub_7
			// 
			_cbo_pub_7.AllowDrop = true;
			_cbo_pub_7.BackColor = System.Drawing.SystemColors.Window;
			_cbo_pub_7.CausesValidation = true;
			_cbo_pub_7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_pub_7.Enabled = true;
			_cbo_pub_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_pub_7.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_pub_7.IntegralHeight = true;
			_cbo_pub_7.Location = new System.Drawing.Point(840, 72);
			_cbo_pub_7.Name = "_cbo_pub_7";
			_cbo_pub_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_pub_7.Size = new System.Drawing.Size(132, 21);
			_cbo_pub_7.Sorted = false;
			_cbo_pub_7.TabIndex = 108;
			_cbo_pub_7.TabStop = true;
			_cbo_pub_7.Visible = true;
			_cbo_pub_7.Enter += new System.EventHandler(cbo_pub_Enter);
			_cbo_pub_7.SelectionChangeCommitted += new System.EventHandler(cbo_pub_SelectionChangeCommitted);
			_cbo_pub_7.TextChanged += new System.EventHandler(cbo_pub_TextChanged);
			// 
			// _chk_include_9
			// 
			_chk_include_9.AllowDrop = true;
			_chk_include_9.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_9.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_9.CausesValidation = true;
			_chk_include_9.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_9.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_9.Enabled = true;
			_chk_include_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_9.Location = new System.Drawing.Point(524, 48);
			_chk_include_9.Name = "_chk_include_9";
			_chk_include_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_9.Size = new System.Drawing.Size(93, 20);
			_chk_include_9.TabIndex = 107;
			_chk_include_9.TabStop = true;
			_chk_include_9.Text = "3rd Attempt";
			_chk_include_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_9.Visible = true;
			_chk_include_9.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_10
			// 
			_chk_include_10.AllowDrop = true;
			_chk_include_10.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_10.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_10.CausesValidation = true;
			_chk_include_10.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_10.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_10.Enabled = true;
			_chk_include_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_10.Location = new System.Drawing.Point(620, 24);
			_chk_include_10.Name = "_chk_include_10";
			_chk_include_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_10.Size = new System.Drawing.Size(105, 20);
			_chk_include_10.TabIndex = 106;
			_chk_include_10.TabStop = true;
			_chk_include_10.Text = "Hold/Review";
			_chk_include_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_10.Visible = true;
			_chk_include_10.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_11
			// 
			_chk_include_11.AllowDrop = true;
			_chk_include_11.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_11.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_11.CausesValidation = true;
			_chk_include_11.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_11.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_11.Enabled = true;
			_chk_include_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_11.Location = new System.Drawing.Point(428, 48);
			_chk_include_11.Name = "_chk_include_11";
			_chk_include_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_11.Size = new System.Drawing.Size(93, 20);
			_chk_include_11.TabIndex = 105;
			_chk_include_11.TabStop = true;
			_chk_include_11.Text = "1st Attempt";
			_chk_include_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_11.Visible = true;
			_chk_include_11.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// grd_pub
			// 
			grd_pub.AllowDrop = true;
			grd_pub.AllowUserToAddRows = false;
			grd_pub.AllowUserToDeleteRows = false;
			grd_pub.AllowUserToResizeColumns = false;
			grd_pub.AllowUserToResizeColumns = grd_pub.ColumnHeadersVisible;
			grd_pub.AllowUserToResizeRows = false;
			grd_pub.AllowUserToResizeRows = false;
			grd_pub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_pub.ColumnsCount = 2;
			grd_pub.FixedColumns = 1;
			grd_pub.FixedRows = 1;
			grd_pub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grd_pub.Location = new System.Drawing.Point(8, 96);
			grd_pub.Name = "grd_pub";
			grd_pub.ReadOnly = true;
			grd_pub.RowsCount = 2;
			grd_pub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_pub.ShowCellToolTips = false;
			grd_pub.Size = new System.Drawing.Size(956, 179);
			grd_pub.StandardTab = true;
			grd_pub.TabIndex = 123;
			grd_pub.Click += new System.EventHandler(grd_pub_Click);
			grd_pub.DoubleClick += new System.EventHandler(grd_pub_DoubleClick);
			grd_pub.MouseDown += new System.Windows.Forms.MouseEventHandler(grd_pub_MouseDown);
			// 
			// _lbl_gen_21
			// 
			_lbl_gen_21.AllowDrop = true;
			_lbl_gen_21.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_21.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_21.Location = new System.Drawing.Point(208, 54);
			_lbl_gen_21.MinimumSize = new System.Drawing.Size(54, 15);
			_lbl_gen_21.Name = "_lbl_gen_21";
			_lbl_gen_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_21.Size = new System.Drawing.Size(54, 15);
			_lbl_gen_21.TabIndex = 174;
			_lbl_gen_21.Text = "Timezone";
			_lbl_gen_21.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_46
			// 
			_lbl_gen_46.AllowDrop = true;
			_lbl_gen_46.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_46.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_46.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_46.Location = new System.Drawing.Point(24, 30);
			_lbl_gen_46.MinimumSize = new System.Drawing.Size(98, 15);
			_lbl_gen_46.Name = "_lbl_gen_46";
			_lbl_gen_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_46.Size = new System.Drawing.Size(98, 15);
			_lbl_gen_46.TabIndex = 128;
			_lbl_gen_46.Text = "Status:";
			_lbl_gen_46.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_5
			// 
			_lbl_gen_5.AllowDrop = true;
			_lbl_gen_5.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_5.Location = new System.Drawing.Point(310, 30);
			_lbl_gen_5.MinimumSize = new System.Drawing.Size(54, 15);
			_lbl_gen_5.Name = "_lbl_gen_5";
			_lbl_gen_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_5.Size = new System.Drawing.Size(54, 15);
			_lbl_gen_5.TabIndex = 127;
			_lbl_gen_5.Text = "Company";
			_lbl_gen_5.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_9
			// 
			_lbl_gen_9.AllowDrop = true;
			_lbl_gen_9.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_9.Location = new System.Drawing.Point(180, 80);
			_lbl_gen_9.MinimumSize = new System.Drawing.Size(86, 15);
			_lbl_gen_9.Name = "_lbl_gen_9";
			_lbl_gen_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_9.Size = new System.Drawing.Size(86, 15);
			_lbl_gen_9.TabIndex = 126;
			_lbl_gen_9.Text = "ID/Title:";
			_lbl_gen_9.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_10
			// 
			_lbl_gen_10.AllowDrop = true;
			_lbl_gen_10.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_10.Location = new System.Drawing.Point(468, 78);
			_lbl_gen_10.MinimumSize = new System.Drawing.Size(78, 15);
			_lbl_gen_10.Name = "_lbl_gen_10";
			_lbl_gen_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_10.Size = new System.Drawing.Size(78, 15);
			_lbl_gen_10.TabIndex = 125;
			_lbl_gen_10.Text = "Date Range:";
			_lbl_gen_10.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_11
			// 
			_lbl_gen_11.AllowDrop = true;
			_lbl_gen_11.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_11.Location = new System.Drawing.Point(612, 80);
			_lbl_gen_11.MinimumSize = new System.Drawing.Size(38, 13);
			_lbl_gen_11.Name = "_lbl_gen_11";
			_lbl_gen_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_11.Size = new System.Drawing.Size(38, 13);
			_lbl_gen_11.TabIndex = 124;
			_lbl_gen_11.Text = "To";
			_lbl_gen_11.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// pnl_add_model_exception
			// 
			pnl_add_model_exception.AllowDrop = true;
			pnl_add_model_exception.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			pnl_add_model_exception.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_add_model_exception.Controls.Add(_cmd_pub_8);
			pnl_add_model_exception.Controls.Add(_txt_pub_8);
			pnl_add_model_exception.Controls.Add(_lbl_gen_6);
			pnl_add_model_exception.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_add_model_exception.Location = new System.Drawing.Point(248, 384);
			pnl_add_model_exception.Name = "pnl_add_model_exception";
			pnl_add_model_exception.Size = new System.Drawing.Size(331, 35);
			pnl_add_model_exception.TabIndex = 131;
			pnl_add_model_exception.Visible = false;
			// 
			// _cmd_pub_8
			// 
			_cmd_pub_8.AllowDrop = true;
			_cmd_pub_8.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_8.Location = new System.Drawing.Point(248, 8);
			_cmd_pub_8.Name = "_cmd_pub_8";
			_cmd_pub_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_8.Size = new System.Drawing.Size(77, 19);
			_cmd_pub_8.TabIndex = 133;
			_cmd_pub_8.Text = "Add";
			_cmd_pub_8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_8.UseVisualStyleBackColor = false;
			_cmd_pub_8.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _txt_pub_8
			// 
			_txt_pub_8.AcceptsReturn = true;
			_txt_pub_8.AllowDrop = true;
			_txt_pub_8.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_8.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_8.Location = new System.Drawing.Point(96, 8);
			_txt_pub_8.MaxLength = 0;
			_txt_pub_8.Name = "_txt_pub_8";
			_txt_pub_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_8.Size = new System.Drawing.Size(151, 19);
			_txt_pub_8.TabIndex = 132;
			_txt_pub_8.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _lbl_gen_6
			// 
			_lbl_gen_6.AllowDrop = true;
			_lbl_gen_6.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_6.ForeColor = System.Drawing.Color.Red;
			_lbl_gen_6.Location = new System.Drawing.Point(4, 8);
			_lbl_gen_6.MinimumSize = new System.Drawing.Size(101, 15);
			_lbl_gen_6.Name = "_lbl_gen_6";
			_lbl_gen_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_6.Size = new System.Drawing.Size(101, 15);
			_lbl_gen_6.TabIndex = 134;
			_lbl_gen_6.Text = "Record Entered";
			_lbl_gen_6.Visible = false;
			_lbl_gen_6.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_23
			// 
			_lbl_gen_23.AllowDrop = true;
			_lbl_gen_23.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_23.Location = new System.Drawing.Point(8, 408);
			_lbl_gen_23.MinimumSize = new System.Drawing.Size(57, 15);
			_lbl_gen_23.Name = "_lbl_gen_23";
			_lbl_gen_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_23.Size = new System.Drawing.Size(57, 15);
			_lbl_gen_23.TabIndex = 187;
			_lbl_gen_23.Text = "ACC Rep:";
			_lbl_gen_23.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_45
			// 
			_lbl_gen_45.AllowDrop = true;
			_lbl_gen_45.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_45.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_45.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_45.Location = new System.Drawing.Point(824, 390);
			_lbl_gen_45.MinimumSize = new System.Drawing.Size(134, 15);
			_lbl_gen_45.Name = "_lbl_gen_45";
			_lbl_gen_45.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_45.Size = new System.Drawing.Size(134, 15);
			_lbl_gen_45.TabIndex = 137;
			_lbl_gen_45.Text = "Records Found: 0 ";
			_lbl_gen_45.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _tab_NewAvail_TabPage3
			// 
			_tab_NewAvail_TabPage3.Controls.Add(SSPanel1);
			_tab_NewAvail_TabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_NewAvail_TabPage3.Text = "New Memo";
			// 
			// SSPanel1
			// 
			SSPanel1.AllowDrop = true;
			SSPanel1.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			SSPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel1.Controls.Add(Frame1);
			SSPanel1.Controls.Add(_cmd_pub_13);
			SSPanel1.Controls.Add(cmd_clear_pub2);
			SSPanel1.Controls.Add(_cmd_pub_12);
			SSPanel1.Controls.Add(_cmd_pub_11);
			SSPanel1.Controls.Add(SSPanel2);
			SSPanel1.Controls.Add(_lbl_gen_20);
			SSPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel1.Location = new System.Drawing.Point(0, 4);
			SSPanel1.Name = "SSPanel1";
			SSPanel1.Size = new System.Drawing.Size(979, 431);
			SSPanel1.TabIndex = 138;
			// 
			// Frame1
			// 
			Frame1.AllowDrop = true;
			Frame1.BackColor = System.Drawing.SystemColors.Control;
			Frame1.Controls.Add(_chk_include_24);
			Frame1.Controls.Add(_chk_include_22);
			Frame1.Controls.Add(_chk_include_21);
			Frame1.Controls.Add(_chk_include_20);
			Frame1.Controls.Add(_cbo_pub_9);
			Frame1.Controls.Add(_chk_include_19);
			Frame1.Controls.Add(_txt_pub_18);
			Frame1.Controls.Add(_txt_pub_17);
			Frame1.Controls.Add(_txt_pub_16);
			Frame1.Controls.Add(_chk_include_18);
			Frame1.Controls.Add(_chk_include_17);
			Frame1.Controls.Add(_chk_include_16);
			Frame1.Controls.Add(_txt_pub_15);
			Frame1.Controls.Add(_cmd_pub_14);
			Frame1.Controls.Add(_cbo_pub_8);
			Frame1.Controls.Add(_chk_include_15);
			Frame1.Controls.Add(_chk_include_14);
			Frame1.Controls.Add(_chk_include_13);
			Frame1.Controls.Add(_chk_include_12);
			Frame1.Controls.Add(grd_pub2);
			Frame1.Controls.Add(_lbl_gen_18);
			Frame1.Controls.Add(_lbl_gen_17);
			Frame1.Controls.Add(_lbl_gen_16);
			Frame1.Controls.Add(_lbl_gen_15);
			Frame1.Controls.Add(_lbl_gen_14);
			Frame1.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			Frame1.Enabled = true;
			Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			Frame1.Location = new System.Drawing.Point(0, -13);
			Frame1.Name = "Frame1";
			Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Frame1.Size = new System.Drawing.Size(977, 353);
			Frame1.TabIndex = 143;
			Frame1.Visible = true;
			// 
			// _chk_include_24
			// 
			_chk_include_24.AllowDrop = true;
			_chk_include_24.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_24.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_24.CausesValidation = true;
			_chk_include_24.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_24.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_24.Enabled = true;
			_chk_include_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_24.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_24.Location = new System.Drawing.Point(24, 80);
			_chk_include_24.Name = "_chk_include_24";
			_chk_include_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_24.Size = new System.Drawing.Size(119, 20);
			_chk_include_24.TabIndex = 178;
			_chk_include_24.TabStop = true;
			_chk_include_24.Text = "Include Class E";
			_chk_include_24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_24.Visible = true;
			_chk_include_24.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_22
			// 
			_chk_include_22.AllowDrop = true;
			_chk_include_22.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_22.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_22.CausesValidation = true;
			_chk_include_22.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_22.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_22.Enabled = true;
			_chk_include_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_22.Location = new System.Drawing.Point(428, 48);
			_chk_include_22.Name = "_chk_include_22";
			_chk_include_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_22.Size = new System.Drawing.Size(93, 20);
			_chk_include_22.TabIndex = 161;
			_chk_include_22.TabStop = true;
			_chk_include_22.Text = "1st Attempt";
			_chk_include_22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_22.Visible = true;
			_chk_include_22.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_21
			// 
			_chk_include_21.AllowDrop = true;
			_chk_include_21.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_21.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_21.CausesValidation = true;
			_chk_include_21.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_21.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_21.Enabled = true;
			_chk_include_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_21.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_21.Location = new System.Drawing.Point(620, 24);
			_chk_include_21.Name = "_chk_include_21";
			_chk_include_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_21.Size = new System.Drawing.Size(105, 20);
			_chk_include_21.TabIndex = 160;
			_chk_include_21.TabStop = true;
			_chk_include_21.Text = "Hold/Review";
			_chk_include_21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_21.Visible = true;
			_chk_include_21.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_20
			// 
			_chk_include_20.AllowDrop = true;
			_chk_include_20.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_20.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_20.CausesValidation = true;
			_chk_include_20.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_20.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_20.Enabled = true;
			_chk_include_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_20.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_20.Location = new System.Drawing.Point(524, 48);
			_chk_include_20.Name = "_chk_include_20";
			_chk_include_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_20.Size = new System.Drawing.Size(93, 20);
			_chk_include_20.TabIndex = 159;
			_chk_include_20.TabStop = true;
			_chk_include_20.Text = "3rd Attempt";
			_chk_include_20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_20.Visible = true;
			_chk_include_20.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _cbo_pub_9
			// 
			_cbo_pub_9.AllowDrop = true;
			_cbo_pub_9.BackColor = System.Drawing.SystemColors.Window;
			_cbo_pub_9.CausesValidation = true;
			_cbo_pub_9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_pub_9.Enabled = true;
			_cbo_pub_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_pub_9.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_pub_9.IntegralHeight = true;
			_cbo_pub_9.Location = new System.Drawing.Point(840, 72);
			_cbo_pub_9.Name = "_cbo_pub_9";
			_cbo_pub_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_pub_9.Size = new System.Drawing.Size(132, 21);
			_cbo_pub_9.Sorted = false;
			_cbo_pub_9.TabIndex = 158;
			_cbo_pub_9.TabStop = true;
			_cbo_pub_9.Visible = true;
			_cbo_pub_9.Enter += new System.EventHandler(cbo_pub_Enter);
			_cbo_pub_9.SelectionChangeCommitted += new System.EventHandler(cbo_pub_SelectionChangeCommitted);
			_cbo_pub_9.TextChanged += new System.EventHandler(cbo_pub_TextChanged);
			// 
			// _chk_include_19
			// 
			_chk_include_19.AllowDrop = true;
			_chk_include_19.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_19.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_19.CausesValidation = true;
			_chk_include_19.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_19.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_19.Enabled = true;
			_chk_include_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_19.Location = new System.Drawing.Point(724, 64);
			_chk_include_19.Name = "_chk_include_19";
			_chk_include_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_19.Size = new System.Drawing.Size(91, 20);
			_chk_include_19.TabIndex = 157;
			_chk_include_19.TabStop = true;
			_chk_include_19.Text = "Blind";
			_chk_include_19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_19.Visible = true;
			_chk_include_19.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _txt_pub_18
			// 
			_txt_pub_18.AcceptsReturn = true;
			_txt_pub_18.AllowDrop = true;
			_txt_pub_18.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_18.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_18.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_18.Location = new System.Drawing.Point(636, 76);
			_txt_pub_18.MaxLength = 0;
			_txt_pub_18.Name = "_txt_pub_18";
			_txt_pub_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_18.Size = new System.Drawing.Size(69, 19);
			_txt_pub_18.TabIndex = 156;
			_txt_pub_18.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _txt_pub_17
			// 
			_txt_pub_17.AcceptsReturn = true;
			_txt_pub_17.AllowDrop = true;
			_txt_pub_17.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_17.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_17.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_17.Location = new System.Drawing.Point(540, 76);
			_txt_pub_17.MaxLength = 0;
			_txt_pub_17.Name = "_txt_pub_17";
			_txt_pub_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_17.Size = new System.Drawing.Size(69, 19);
			_txt_pub_17.TabIndex = 155;
			_txt_pub_17.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _txt_pub_16
			// 
			_txt_pub_16.AcceptsReturn = true;
			_txt_pub_16.AllowDrop = true;
			_txt_pub_16.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_16.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_16.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_16.Location = new System.Drawing.Point(268, 76);
			_txt_pub_16.MaxLength = 0;
			_txt_pub_16.Name = "_txt_pub_16";
			_txt_pub_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_16.Size = new System.Drawing.Size(197, 21);
			_txt_pub_16.TabIndex = 154;
			_txt_pub_16.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _chk_include_18
			// 
			_chk_include_18.AllowDrop = true;
			_chk_include_18.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_18.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_18.CausesValidation = true;
			_chk_include_18.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_18.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_18.Enabled = true;
			_chk_include_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_18.Location = new System.Drawing.Point(824, 40);
			_chk_include_18.Name = "_chk_include_18";
			_chk_include_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_18.Size = new System.Drawing.Size(83, 26);
			_chk_include_18.TabIndex = 153;
			_chk_include_18.TabStop = true;
			_chk_include_18.Text = "No Action Required";
			_chk_include_18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_18.Visible = true;
			_chk_include_18.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_17
			// 
			_chk_include_17.AllowDrop = true;
			_chk_include_17.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_17.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_17.CausesValidation = true;
			_chk_include_17.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_17.CheckState = System.Windows.Forms.CheckState.Checked;
			_chk_include_17.Enabled = true;
			_chk_include_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_17.Location = new System.Drawing.Point(724, 46);
			_chk_include_17.Name = "_chk_include_17";
			_chk_include_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_17.Size = new System.Drawing.Size(91, 20);
			_chk_include_17.TabIndex = 152;
			_chk_include_17.TabStop = true;
			_chk_include_17.Text = "In Progress";
			_chk_include_17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_17.Visible = true;
			_chk_include_17.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_16
			// 
			_chk_include_16.AllowDrop = true;
			_chk_include_16.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_16.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_16.CausesValidation = true;
			_chk_include_16.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_16.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_16.Enabled = true;
			_chk_include_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_16.Location = new System.Drawing.Point(24, 54);
			_chk_include_16.Name = "_chk_include_16";
			_chk_include_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_16.Size = new System.Drawing.Size(151, 20);
			_chk_include_16.TabIndex = 151;
			_chk_include_16.TabStop = true;
			_chk_include_16.Text = "Include PUB Groups";
			_chk_include_16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_16.Visible = true;
			_chk_include_16.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _txt_pub_15
			// 
			_txt_pub_15.AcceptsReturn = true;
			_txt_pub_15.AllowDrop = true;
			_txt_pub_15.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_15.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_15.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_15.Location = new System.Drawing.Point(368, 30);
			_txt_pub_15.MaxLength = 0;
			_txt_pub_15.Name = "_txt_pub_15";
			_txt_pub_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_15.Size = new System.Drawing.Size(155, 21);
			_txt_pub_15.TabIndex = 150;
			_txt_pub_15.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _cmd_pub_14
			// 
			_cmd_pub_14.AllowDrop = true;
			_cmd_pub_14.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_14.Location = new System.Drawing.Point(904, 24);
			_cmd_pub_14.Name = "_cmd_pub_14";
			_cmd_pub_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_14.Size = new System.Drawing.Size(69, 31);
			_cmd_pub_14.TabIndex = 149;
			_cmd_pub_14.Text = "Search";
			_cmd_pub_14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_14.UseVisualStyleBackColor = false;
			_cmd_pub_14.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _cbo_pub_8
			// 
			_cbo_pub_8.AllowDrop = true;
			_cbo_pub_8.BackColor = System.Drawing.SystemColors.Window;
			_cbo_pub_8.CausesValidation = true;
			_cbo_pub_8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_pub_8.Enabled = true;
			_cbo_pub_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_pub_8.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_pub_8.IntegralHeight = true;
			_cbo_pub_8.Location = new System.Drawing.Point(88, 32);
			_cbo_pub_8.Name = "_cbo_pub_8";
			_cbo_pub_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_pub_8.Size = new System.Drawing.Size(219, 21);
			_cbo_pub_8.Sorted = false;
			_cbo_pub_8.TabIndex = 148;
			_cbo_pub_8.TabStop = true;
			_cbo_pub_8.Visible = true;
			_cbo_pub_8.Enter += new System.EventHandler(cbo_pub_Enter);
			_cbo_pub_8.SelectionChangeCommitted += new System.EventHandler(cbo_pub_SelectionChangeCommitted);
			_cbo_pub_8.TextChanged += new System.EventHandler(cbo_pub_TextChanged);
			// 
			// _chk_include_15
			// 
			_chk_include_15.AllowDrop = true;
			_chk_include_15.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_15.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_15.CausesValidation = true;
			_chk_include_15.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_15.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_15.Enabled = true;
			_chk_include_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_15.Location = new System.Drawing.Point(820, 24);
			_chk_include_15.Name = "_chk_include_15";
			_chk_include_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_15.Size = new System.Drawing.Size(65, 20);
			_chk_include_15.TabIndex = 147;
			_chk_include_15.TabStop = true;
			_chk_include_15.Text = "Cleared";
			_chk_include_15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_15.Visible = true;
			_chk_include_15.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_14
			// 
			_chk_include_14.AllowDrop = true;
			_chk_include_14.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_14.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_14.CausesValidation = true;
			_chk_include_14.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_14.CheckState = System.Windows.Forms.CheckState.Checked;
			_chk_include_14.Enabled = true;
			_chk_include_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_14.Location = new System.Drawing.Point(724, 24);
			_chk_include_14.Name = "_chk_include_14";
			_chk_include_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_14.Size = new System.Drawing.Size(57, 20);
			_chk_include_14.TabIndex = 146;
			_chk_include_14.TabStop = true;
			_chk_include_14.Text = "Open";
			_chk_include_14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_14.Visible = true;
			_chk_include_14.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_13
			// 
			_chk_include_13.AllowDrop = true;
			_chk_include_13.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_13.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_13.CausesValidation = true;
			_chk_include_13.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_13.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_13.Enabled = true;
			_chk_include_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_13.Location = new System.Drawing.Point(620, 48);
			_chk_include_13.Name = "_chk_include_13";
			_chk_include_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_13.Size = new System.Drawing.Size(89, 20);
			_chk_include_13.TabIndex = 145;
			_chk_include_13.TabStop = true;
			_chk_include_13.Text = "Completed";
			_chk_include_13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_13.Visible = true;
			_chk_include_13.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// _chk_include_12
			// 
			_chk_include_12.AllowDrop = true;
			_chk_include_12.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_include_12.BackColor = System.Drawing.SystemColors.Control;
			_chk_include_12.CausesValidation = true;
			_chk_include_12.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_12.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_include_12.Enabled = true;
			_chk_include_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_include_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_include_12.Location = new System.Drawing.Point(524, 24);
			_chk_include_12.Name = "_chk_include_12";
			_chk_include_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_include_12.Size = new System.Drawing.Size(93, 20);
			_chk_include_12.TabIndex = 144;
			_chk_include_12.TabStop = true;
			_chk_include_12.Text = "2nd Attempt";
			_chk_include_12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_include_12.Visible = true;
			_chk_include_12.CheckStateChanged += new System.EventHandler(chk_include_CheckStateChanged);
			// 
			// grd_pub2
			// 
			grd_pub2.AllowDrop = true;
			grd_pub2.AllowUserToAddRows = false;
			grd_pub2.AllowUserToDeleteRows = false;
			grd_pub2.AllowUserToResizeColumns = false;
			grd_pub2.AllowUserToResizeColumns = grd_pub2.ColumnHeadersVisible;
			grd_pub2.AllowUserToResizeRows = false;
			grd_pub2.AllowUserToResizeRows = false;
			grd_pub2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_pub2.ColumnsCount = 2;
			grd_pub2.FixedColumns = 1;
			grd_pub2.FixedRows = 1;
			grd_pub2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grd_pub2.Location = new System.Drawing.Point(8, 104);
			grd_pub2.Name = "grd_pub2";
			grd_pub2.ReadOnly = true;
			grd_pub2.RowsCount = 2;
			grd_pub2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_pub2.ShowCellToolTips = false;
			grd_pub2.Size = new System.Drawing.Size(957, 251);
			grd_pub2.StandardTab = true;
			grd_pub2.TabIndex = 162;
			grd_pub2.Visible = false;
			grd_pub2.DoubleClick += new System.EventHandler(grd_pub2_DoubleClick);
			grd_pub2.MouseDown += new System.Windows.Forms.MouseEventHandler(grd_pub2_MouseDown);
			// 
			// _lbl_gen_18
			// 
			_lbl_gen_18.AllowDrop = true;
			_lbl_gen_18.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_18.Location = new System.Drawing.Point(612, 80);
			_lbl_gen_18.MinimumSize = new System.Drawing.Size(38, 13);
			_lbl_gen_18.Name = "_lbl_gen_18";
			_lbl_gen_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_18.Size = new System.Drawing.Size(38, 13);
			_lbl_gen_18.TabIndex = 167;
			_lbl_gen_18.Text = "To";
			_lbl_gen_18.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_17
			// 
			_lbl_gen_17.AllowDrop = true;
			_lbl_gen_17.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_17.Location = new System.Drawing.Point(468, 78);
			_lbl_gen_17.MinimumSize = new System.Drawing.Size(78, 15);
			_lbl_gen_17.Name = "_lbl_gen_17";
			_lbl_gen_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_17.Size = new System.Drawing.Size(78, 15);
			_lbl_gen_17.TabIndex = 166;
			_lbl_gen_17.Text = "Date Range:";
			_lbl_gen_17.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_16
			// 
			_lbl_gen_16.AllowDrop = true;
			_lbl_gen_16.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_16.Location = new System.Drawing.Point(180, 80);
			_lbl_gen_16.MinimumSize = new System.Drawing.Size(86, 15);
			_lbl_gen_16.Name = "_lbl_gen_16";
			_lbl_gen_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_16.Size = new System.Drawing.Size(86, 15);
			_lbl_gen_16.TabIndex = 165;
			_lbl_gen_16.Text = "ID/Title:";
			_lbl_gen_16.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_15
			// 
			_lbl_gen_15.AllowDrop = true;
			_lbl_gen_15.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_15.Location = new System.Drawing.Point(310, 30);
			_lbl_gen_15.MinimumSize = new System.Drawing.Size(54, 15);
			_lbl_gen_15.Name = "_lbl_gen_15";
			_lbl_gen_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_15.Size = new System.Drawing.Size(54, 15);
			_lbl_gen_15.TabIndex = 164;
			_lbl_gen_15.Text = "Company";
			_lbl_gen_15.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_14
			// 
			_lbl_gen_14.AllowDrop = true;
			_lbl_gen_14.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_14.Location = new System.Drawing.Point(24, 30);
			_lbl_gen_14.MinimumSize = new System.Drawing.Size(98, 15);
			_lbl_gen_14.Name = "_lbl_gen_14";
			_lbl_gen_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_14.Size = new System.Drawing.Size(98, 15);
			_lbl_gen_14.TabIndex = 163;
			_lbl_gen_14.Text = "Status:";
			_lbl_gen_14.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _cmd_pub_13
			// 
			_cmd_pub_13.AllowDrop = true;
			_cmd_pub_13.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_13.Location = new System.Drawing.Point(280, 344);
			_cmd_pub_13.Name = "_cmd_pub_13";
			_cmd_pub_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_13.Size = new System.Drawing.Size(113, 25);
			_cmd_pub_13.TabIndex = 142;
			_cmd_pub_13.Text = "Send Verify Email";
			_cmd_pub_13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_13.UseVisualStyleBackColor = false;
			_cmd_pub_13.Visible = false;
			_cmd_pub_13.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// cmd_clear_pub2
			// 
			cmd_clear_pub2.AllowDrop = true;
			cmd_clear_pub2.BackColor = System.Drawing.SystemColors.Control;
			cmd_clear_pub2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_clear_pub2.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_clear_pub2.Location = new System.Drawing.Point(16, 344);
			cmd_clear_pub2.Name = "cmd_clear_pub2";
			cmd_clear_pub2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_clear_pub2.Size = new System.Drawing.Size(115, 20);
			cmd_clear_pub2.TabIndex = 141;
			cmd_clear_pub2.Text = "Clear Pub ID";
			cmd_clear_pub2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_clear_pub2.UseVisualStyleBackColor = false;
			cmd_clear_pub2.Visible = false;
			// 
			// _cmd_pub_12
			// 
			_cmd_pub_12.AllowDrop = true;
			_cmd_pub_12.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_12.Location = new System.Drawing.Point(780, 390);
			_cmd_pub_12.Name = "_cmd_pub_12";
			_cmd_pub_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_12.Size = new System.Drawing.Size(159, 21);
			_cmd_pub_12.TabIndex = 140;
			_cmd_pub_12.Text = "Add New Model Exception";
			_cmd_pub_12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_12.UseVisualStyleBackColor = false;
			_cmd_pub_12.Visible = false;
			_cmd_pub_12.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _cmd_pub_11
			// 
			_cmd_pub_11.AllowDrop = true;
			_cmd_pub_11.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_11.Location = new System.Drawing.Point(844, 360);
			_cmd_pub_11.Name = "_cmd_pub_11";
			_cmd_pub_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_11.Size = new System.Drawing.Size(91, 21);
			_cmd_pub_11.TabIndex = 139;
			_cmd_pub_11.Text = "Add New";
			_cmd_pub_11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_11.UseVisualStyleBackColor = false;
			_cmd_pub_11.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// SSPanel2
			// 
			SSPanel2.AllowDrop = true;
			SSPanel2.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			SSPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel2.Controls.Add(_txt_pub_19);
			SSPanel2.Controls.Add(_cmd_pub_15);
			SSPanel2.Controls.Add(_lbl_gen_19);
			SSPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel2.Location = new System.Drawing.Point(554, 344);
			SSPanel2.Name = "SSPanel2";
			SSPanel2.Size = new System.Drawing.Size(211, 67);
			SSPanel2.TabIndex = 168;
			SSPanel2.Visible = false;
			// 
			// _txt_pub_19
			// 
			_txt_pub_19.AcceptsReturn = true;
			_txt_pub_19.AllowDrop = true;
			_txt_pub_19.BackColor = System.Drawing.SystemColors.Window;
			_txt_pub_19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_pub_19.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_pub_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_pub_19.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_pub_19.Location = new System.Drawing.Point(6, 28);
			_txt_pub_19.MaxLength = 0;
			_txt_pub_19.Name = "_txt_pub_19";
			_txt_pub_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_pub_19.Size = new System.Drawing.Size(199, 19);
			_txt_pub_19.TabIndex = 170;
			_txt_pub_19.Leave += new System.EventHandler(txt_pub_Leave);
			// 
			// _cmd_pub_15
			// 
			_cmd_pub_15.AllowDrop = true;
			_cmd_pub_15.BackColor = System.Drawing.SystemColors.Control;
			_cmd_pub_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_pub_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_pub_15.Location = new System.Drawing.Point(128, 48);
			_cmd_pub_15.Name = "_cmd_pub_15";
			_cmd_pub_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_pub_15.Size = new System.Drawing.Size(77, 19);
			_cmd_pub_15.TabIndex = 169;
			_cmd_pub_15.Text = "Add";
			_cmd_pub_15.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_pub_15.UseVisualStyleBackColor = false;
			_cmd_pub_15.Click += new System.EventHandler(cmd_pub_Click);
			// 
			// _lbl_gen_19
			// 
			_lbl_gen_19.AllowDrop = true;
			_lbl_gen_19.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_19.ForeColor = System.Drawing.Color.Red;
			_lbl_gen_19.Location = new System.Drawing.Point(4, 8);
			_lbl_gen_19.MinimumSize = new System.Drawing.Size(134, 15);
			_lbl_gen_19.Name = "_lbl_gen_19";
			_lbl_gen_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_19.Size = new System.Drawing.Size(134, 15);
			_lbl_gen_19.TabIndex = 171;
			_lbl_gen_19.Text = "Record Entered";
			_lbl_gen_19.Visible = false;
			_lbl_gen_19.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_20
			// 
			_lbl_gen_20.AllowDrop = true;
			_lbl_gen_20.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_20.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_20.Location = new System.Drawing.Point(800, 344);
			_lbl_gen_20.MinimumSize = new System.Drawing.Size(134, 15);
			_lbl_gen_20.Name = "_lbl_gen_20";
			_lbl_gen_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_20.Size = new System.Drawing.Size(134, 15);
			_lbl_gen_20.TabIndex = 172;
			_lbl_gen_20.Text = "Records Found: 0 ";
			_lbl_gen_20.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// txt_Serialno_Search
			// 
			txt_Serialno_Search.AcceptsReturn = true;
			txt_Serialno_Search.AllowDrop = true;
			txt_Serialno_Search.BackColor = System.Drawing.SystemColors.Window;
			txt_Serialno_Search.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Serialno_Search.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Serialno_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Serialno_Search.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Serialno_Search.Location = new System.Drawing.Point(768, 40);
			txt_Serialno_Search.MaxLength = 15;
			txt_Serialno_Search.Name = "txt_Serialno_Search";
			txt_Serialno_Search.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Serialno_Search.Size = new System.Drawing.Size(85, 19);
			txt_Serialno_Search.TabIndex = 60;
			// 
			// txt_Regno_Search
			// 
			txt_Regno_Search.AcceptsReturn = true;
			txt_Regno_Search.AllowDrop = true;
			txt_Regno_Search.BackColor = System.Drawing.SystemColors.Window;
			txt_Regno_Search.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Regno_Search.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Regno_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Regno_Search.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Regno_Search.Location = new System.Drawing.Point(624, 40);
			txt_Regno_Search.MaxLength = 15;
			txt_Regno_Search.Name = "txt_Regno_Search";
			txt_Regno_Search.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Regno_Search.Size = new System.Drawing.Size(85, 19);
			txt_Regno_Search.TabIndex = 58;
			// 
			// cmd_ClearNoChange
			// 
			cmd_ClearNoChange.AllowDrop = true;
			cmd_ClearNoChange.BackColor = System.Drawing.SystemColors.Control;
			cmd_ClearNoChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_ClearNoChange.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_ClearNoChange.Location = new System.Drawing.Point(872, 31);
			cmd_ClearNoChange.Name = "cmd_ClearNoChange";
			cmd_ClearNoChange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_ClearNoChange.Size = new System.Drawing.Size(113, 25);
			cmd_ClearNoChange.TabIndex = 55;
			cmd_ClearNoChange.Text = "Clear Pubs with No Changes";
			cmd_ClearNoChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_ClearNoChange.UseVisualStyleBackColor = false;
			cmd_ClearNoChange.Click += new System.EventHandler(cmd_ClearNoChange_Click);
			// 
			// _pic_redx_1
			// 
			_pic_redx_1.AllowDrop = true;
			_pic_redx_1.BackColor = System.Drawing.SystemColors.Control;
			_pic_redx_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_pic_redx_1.CausesValidation = true;
			_pic_redx_1.Dock = System.Windows.Forms.DockStyle.None;
			_pic_redx_1.Enabled = true;
			_pic_redx_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_redx_1.Image = (System.Drawing.Image) resources.GetObject("_pic_redx_1.Image");
			_pic_redx_1.Location = new System.Drawing.Point(536, 34);
			_pic_redx_1.Name = "_pic_redx_1";
			_pic_redx_1.Size = new System.Drawing.Size(31, 24);
			_pic_redx_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_redx_1.TabIndex = 53;
			_pic_redx_1.TabStop = true;
			_pic_redx_1.Visible = false;
			// 
			// _pic_redx_2
			// 
			_pic_redx_2.AllowDrop = true;
			_pic_redx_2.BackColor = System.Drawing.SystemColors.Control;
			_pic_redx_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_pic_redx_2.CausesValidation = true;
			_pic_redx_2.Dock = System.Windows.Forms.DockStyle.None;
			_pic_redx_2.Enabled = true;
			_pic_redx_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_redx_2.Image = (System.Drawing.Image) resources.GetObject("_pic_redx_2.Image");
			_pic_redx_2.Location = new System.Drawing.Point(552, 33);
			_pic_redx_2.Name = "_pic_redx_2";
			_pic_redx_2.Size = new System.Drawing.Size(30, 26);
			_pic_redx_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_redx_2.TabIndex = 52;
			_pic_redx_2.TabStop = true;
			_pic_redx_2.Visible = false;
			// 
			// txt_publog_days
			// 
			txt_publog_days.AcceptsReturn = true;
			txt_publog_days.AllowDrop = true;
			txt_publog_days.BackColor = System.Drawing.SystemColors.Window;
			txt_publog_days.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_publog_days.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_publog_days.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_publog_days.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_publog_days.Location = new System.Drawing.Point(399, 37);
			txt_publog_days.MaxLength = 15;
			txt_publog_days.Name = "txt_publog_days";
			txt_publog_days.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_publog_days.Size = new System.Drawing.Size(29, 19);
			txt_publog_days.TabIndex = 2;
			// 
			// chkShowCleared
			// 
			chkShowCleared.AllowDrop = true;
			chkShowCleared.Appearance = System.Windows.Forms.Appearance.Normal;
			chkShowCleared.BackColor = System.Drawing.SystemColors.Control;
			chkShowCleared.CausesValidation = true;
			chkShowCleared.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkShowCleared.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkShowCleared.Enabled = true;
			chkShowCleared.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkShowCleared.ForeColor = System.Drawing.SystemColors.ControlText;
			chkShowCleared.Location = new System.Drawing.Point(233, 41);
			chkShowCleared.Name = "chkShowCleared";
			chkShowCleared.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkShowCleared.Size = new System.Drawing.Size(165, 20);
			chkShowCleared.TabIndex = 1;
			chkShowCleared.TabStop = true;
			chkShowCleared.Text = "Show Pubs Cleared in the Last ";
			chkShowCleared.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkShowCleared.Visible = true;
			// 
			// cmdRefresh
			// 
			cmdRefresh.AllowDrop = true;
			cmdRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRefresh.Location = new System.Drawing.Point(464, 36);
			cmdRefresh.Name = "cmdRefresh";
			cmdRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRefresh.Size = new System.Drawing.Size(70, 20);
			cmdRefresh.TabIndex = 3;
			cmdRefresh.Text = "Refresh";
			cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRefresh.UseVisualStyleBackColor = false;
			cmdRefresh.Click += new System.EventHandler(cmdRefresh_Click);
			// 
			// frame_Details
			// 
			frame_Details.AllowDrop = true;
			frame_Details.BackColor = System.Drawing.SystemColors.Control;
			frame_Details.Controls.Add(cmd_ClearLeave);
			frame_Details.Controls.Add(cbo_publog_acct_rep);
			frame_Details.Controls.Add(txt_publog_entry_date);
			frame_Details.Controls.Add(txt_publog_update_date);
			frame_Details.Controls.Add(cmd_Cancel);
			frame_Details.Controls.Add(txt_publog_Ac_id);
			frame_Details.Controls.Add(txt_publog_url);
			frame_Details.Controls.Add(cmd_Save);
			frame_Details.Controls.Add(txt_publog_seller_info);
			frame_Details.Controls.Add(cmd_Identify_AC);
			frame_Details.Controls.Add(txt_publog_ser_no);
			frame_Details.Controls.Add(txt_publog_reg_no);
			frame_Details.Controls.Add(txt_publog_aftt);
			frame_Details.Controls.Add(txt_publog_price);
			frame_Details.Controls.Add(txt_publog_description);
			frame_Details.Controls.Add(cbo_publog_picture);
			frame_Details.Controls.Add(cbo_publog_source);
			frame_Details.Controls.Add(Label17);
			frame_Details.Controls.Add(Label16);
			frame_Details.Controls.Add(Label15);
			frame_Details.Controls.Add(Label13);
			frame_Details.Controls.Add(lblPubLink);
			frame_Details.Controls.Add(Label11);
			frame_Details.Controls.Add(Label10);
			frame_Details.Controls.Add(Label9);
			frame_Details.Controls.Add(Label8);
			frame_Details.Controls.Add(Label7);
			frame_Details.Controls.Add(Label6);
			frame_Details.Controls.Add(Label5);
			frame_Details.Controls.Add(Label4);
			frame_Details.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_Details.Enabled = true;
			frame_Details.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_Details.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_Details.Location = new System.Drawing.Point(4, 534);
			frame_Details.Name = "frame_Details";
			frame_Details.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_Details.Size = new System.Drawing.Size(985, 145);
			frame_Details.TabIndex = 33;
			frame_Details.Text = "Pub Details";
			frame_Details.Visible = true;
			// 
			// cmd_ClearLeave
			// 
			cmd_ClearLeave.AllowDrop = true;
			cmd_ClearLeave.BackColor = System.Drawing.SystemColors.Control;
			cmd_ClearLeave.Enabled = false;
			cmd_ClearLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_ClearLeave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_ClearLeave.Location = new System.Drawing.Point(220, 50);
			cmd_ClearLeave.Name = "cmd_ClearLeave";
			cmd_ClearLeave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_ClearLeave.Size = new System.Drawing.Size(113, 20);
			cmd_ClearLeave.TabIndex = 50;
			cmd_ClearLeave.Text = "Clear Leave in List";
			cmd_ClearLeave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_ClearLeave.Click += new System.EventHandler(cmd_ClearLeave_Click);
			// 
			// cbo_publog_acct_rep
			// 
			cbo_publog_acct_rep.AllowDrop = true;
			cbo_publog_acct_rep.BackColor = System.Drawing.SystemColors.Window;
			cbo_publog_acct_rep.CausesValidation = true;
			cbo_publog_acct_rep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_publog_acct_rep.Enabled = true;
			cbo_publog_acct_rep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_publog_acct_rep.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_publog_acct_rep.IntegralHeight = true;
			cbo_publog_acct_rep.Location = new System.Drawing.Point(444, 88);
			cbo_publog_acct_rep.Name = "cbo_publog_acct_rep";
			cbo_publog_acct_rep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_publog_acct_rep.Size = new System.Drawing.Size(77, 21);
			cbo_publog_acct_rep.Sorted = false;
			cbo_publog_acct_rep.TabIndex = 18;
			cbo_publog_acct_rep.TabStop = true;
			cbo_publog_acct_rep.Visible = true;
			// 
			// txt_publog_entry_date
			// 
			txt_publog_entry_date.AcceptsReturn = true;
			txt_publog_entry_date.AllowDrop = true;
			txt_publog_entry_date.BackColor = System.Drawing.SystemColors.Window;
			txt_publog_entry_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_publog_entry_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_publog_entry_date.Enabled = false;
			txt_publog_entry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_publog_entry_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_publog_entry_date.Location = new System.Drawing.Point(444, 29);
			txt_publog_entry_date.MaxLength = 15;
			txt_publog_entry_date.Name = "txt_publog_entry_date";
			txt_publog_entry_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_publog_entry_date.Size = new System.Drawing.Size(76, 19);
			txt_publog_entry_date.TabIndex = 10;
			// 
			// txt_publog_update_date
			// 
			txt_publog_update_date.AcceptsReturn = true;
			txt_publog_update_date.AllowDrop = true;
			txt_publog_update_date.BackColor = System.Drawing.SystemColors.Window;
			txt_publog_update_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_publog_update_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_publog_update_date.Enabled = false;
			txt_publog_update_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_publog_update_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_publog_update_date.Location = new System.Drawing.Point(444, 63);
			txt_publog_update_date.MaxLength = 15;
			txt_publog_update_date.Name = "txt_publog_update_date";
			txt_publog_update_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_publog_update_date.Size = new System.Drawing.Size(76, 19);
			txt_publog_update_date.TabIndex = 16;
			// 
			// cmd_Cancel
			// 
			cmd_Cancel.AllowDrop = true;
			cmd_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel.Location = new System.Drawing.Point(898, 120);
			cmd_Cancel.Name = "cmd_Cancel";
			cmd_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel.Size = new System.Drawing.Size(50, 20);
			cmd_Cancel.TabIndex = 23;
			cmd_Cancel.Text = "Cancel";
			cmd_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel.UseVisualStyleBackColor = false;
			cmd_Cancel.Click += new System.EventHandler(cmd_cancel_Click);
			// 
			// txt_publog_Ac_id
			// 
			txt_publog_Ac_id.AcceptsReturn = true;
			txt_publog_Ac_id.AllowDrop = true;
			txt_publog_Ac_id.BackColor = System.Drawing.SystemColors.Window;
			txt_publog_Ac_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_publog_Ac_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_publog_Ac_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_publog_Ac_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_publog_Ac_id.Location = new System.Drawing.Point(148, 48);
			txt_publog_Ac_id.MaxLength = 15;
			txt_publog_Ac_id.Name = "txt_publog_Ac_id";
			txt_publog_Ac_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_publog_Ac_id.Size = new System.Drawing.Size(67, 19);
			txt_publog_Ac_id.TabIndex = 13;
			txt_publog_Ac_id.Leave += new System.EventHandler(txt_publog_Ac_id_Leave);
			// 
			// txt_publog_url
			// 
			txt_publog_url.AcceptsReturn = true;
			txt_publog_url.AllowDrop = true;
			txt_publog_url.BackColor = System.Drawing.SystemColors.Window;
			txt_publog_url.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_publog_url.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_publog_url.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_publog_url.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_publog_url.Location = new System.Drawing.Point(342, 115);
			txt_publog_url.MaxLength = 200;
			txt_publog_url.Name = "txt_publog_url";
			txt_publog_url.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_publog_url.Size = new System.Drawing.Size(477, 19);
			txt_publog_url.TabIndex = 21;
			// 
			// cmd_Save
			// 
			cmd_Save.AllowDrop = true;
			cmd_Save.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save.Location = new System.Drawing.Point(837, 120);
			cmd_Save.Name = "cmd_Save";
			cmd_Save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save.Size = new System.Drawing.Size(46, 20);
			cmd_Save.TabIndex = 22;
			cmd_Save.Text = "Save";
			cmd_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save.UseVisualStyleBackColor = false;
			cmd_Save.Click += new System.EventHandler(cmd_Save_Click);
			// 
			// txt_publog_seller_info
			// 
			txt_publog_seller_info.AcceptsReturn = true;
			txt_publog_seller_info.AllowDrop = true;
			txt_publog_seller_info.BackColor = System.Drawing.SystemColors.Window;
			txt_publog_seller_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_publog_seller_info.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_publog_seller_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_publog_seller_info.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_publog_seller_info.Location = new System.Drawing.Point(546, 24);
			txt_publog_seller_info.MaxLength = 800;
			txt_publog_seller_info.Multiline = true;
			txt_publog_seller_info.Name = "txt_publog_seller_info";
			txt_publog_seller_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_publog_seller_info.Size = new System.Drawing.Size(432, 87);
			txt_publog_seller_info.TabIndex = 11;
			// 
			// cmd_Identify_AC
			// 
			cmd_Identify_AC.AllowDrop = true;
			cmd_Identify_AC.BackColor = System.Drawing.SystemColors.Control;
			cmd_Identify_AC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Identify_AC.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Identify_AC.Location = new System.Drawing.Point(235, 49);
			cmd_Identify_AC.Name = "cmd_Identify_AC";
			cmd_Identify_AC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Identify_AC.Size = new System.Drawing.Size(94, 20);
			cmd_Identify_AC.TabIndex = 14;
			cmd_Identify_AC.Text = "Identify Aircraft";
			cmd_Identify_AC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Identify_AC.UseVisualStyleBackColor = false;
			cmd_Identify_AC.Visible = false;
			cmd_Identify_AC.Click += new System.EventHandler(cmd_Identify_AC_Click);
			// 
			// txt_publog_ser_no
			// 
			txt_publog_ser_no.AcceptsReturn = true;
			txt_publog_ser_no.AllowDrop = true;
			txt_publog_ser_no.BackColor = System.Drawing.SystemColors.Window;
			txt_publog_ser_no.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_publog_ser_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_publog_ser_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_publog_ser_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_publog_ser_no.Location = new System.Drawing.Point(188, 114);
			txt_publog_ser_no.MaxLength = 0;
			txt_publog_ser_no.Name = "txt_publog_ser_no";
			txt_publog_ser_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_publog_ser_no.Size = new System.Drawing.Size(96, 19);
			txt_publog_ser_no.TabIndex = 20;
			// 
			// txt_publog_reg_no
			// 
			txt_publog_reg_no.AcceptsReturn = true;
			txt_publog_reg_no.AllowDrop = true;
			txt_publog_reg_no.BackColor = System.Drawing.SystemColors.Window;
			txt_publog_reg_no.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_publog_reg_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_publog_reg_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_publog_reg_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_publog_reg_no.Location = new System.Drawing.Point(55, 114);
			txt_publog_reg_no.MaxLength = 0;
			txt_publog_reg_no.Name = "txt_publog_reg_no";
			txt_publog_reg_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_publog_reg_no.Size = new System.Drawing.Size(89, 19);
			txt_publog_reg_no.TabIndex = 19;
			// 
			// txt_publog_aftt
			// 
			txt_publog_aftt.AcceptsReturn = true;
			txt_publog_aftt.AllowDrop = true;
			txt_publog_aftt.BackColor = System.Drawing.SystemColors.Window;
			txt_publog_aftt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_publog_aftt.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_publog_aftt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_publog_aftt.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_publog_aftt.Location = new System.Drawing.Point(344, 63);
			txt_publog_aftt.MaxLength = 15;
			txt_publog_aftt.Name = "txt_publog_aftt";
			txt_publog_aftt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_publog_aftt.Size = new System.Drawing.Size(76, 19);
			txt_publog_aftt.TabIndex = 15;
			// 
			// txt_publog_price
			// 
			txt_publog_price.AcceptsReturn = true;
			txt_publog_price.AllowDrop = true;
			txt_publog_price.BackColor = System.Drawing.SystemColors.Window;
			txt_publog_price.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_publog_price.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_publog_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_publog_price.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_publog_price.Location = new System.Drawing.Point(344, 29);
			txt_publog_price.MaxLength = 15;
			txt_publog_price.Name = "txt_publog_price";
			txt_publog_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_publog_price.Size = new System.Drawing.Size(76, 19);
			txt_publog_price.TabIndex = 9;
			// 
			// txt_publog_description
			// 
			txt_publog_description.AcceptsReturn = true;
			txt_publog_description.AllowDrop = true;
			txt_publog_description.BackColor = System.Drawing.SystemColors.Window;
			txt_publog_description.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_publog_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_publog_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_publog_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_publog_description.Location = new System.Drawing.Point(7, 90);
			txt_publog_description.MaxLength = 0;
			txt_publog_description.Name = "txt_publog_description";
			txt_publog_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_publog_description.Size = new System.Drawing.Size(345, 19);
			txt_publog_description.TabIndex = 17;
			// 
			// cbo_publog_picture
			// 
			cbo_publog_picture.AllowDrop = true;
			cbo_publog_picture.BackColor = System.Drawing.SystemColors.Window;
			cbo_publog_picture.CausesValidation = true;
			cbo_publog_picture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_publog_picture.Enabled = true;
			cbo_publog_picture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_publog_picture.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_publog_picture.IntegralHeight = true;
			cbo_publog_picture.Location = new System.Drawing.Point(49, 47);
			cbo_publog_picture.Name = "cbo_publog_picture";
			cbo_publog_picture.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_publog_picture.Size = new System.Drawing.Size(81, 21);
			cbo_publog_picture.Sorted = false;
			cbo_publog_picture.TabIndex = 12;
			cbo_publog_picture.TabStop = true;
			cbo_publog_picture.Visible = true;
			// 
			// cbo_publog_source
			// 
			cbo_publog_source.AllowDrop = true;
			cbo_publog_source.BackColor = System.Drawing.SystemColors.Window;
			cbo_publog_source.CausesValidation = true;
			cbo_publog_source.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_publog_source.Enabled = true;
			cbo_publog_source.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_publog_source.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_publog_source.IntegralHeight = true;
			cbo_publog_source.Location = new System.Drawing.Point(49, 24);
			cbo_publog_source.Name = "cbo_publog_source";
			cbo_publog_source.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_publog_source.Size = new System.Drawing.Size(286, 21);
			cbo_publog_source.Sorted = false;
			cbo_publog_source.TabIndex = 8;
			cbo_publog_source.TabStop = true;
			cbo_publog_source.Visible = true;
			// 
			// Label17
			// 
			Label17.AllowDrop = true;
			Label17.AutoSize = true;
			Label17.BackColor = System.Drawing.SystemColors.Control;
			Label17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label17.ForeColor = System.Drawing.SystemColors.ControlText;
			Label17.Location = new System.Drawing.Point(394, 92);
			Label17.MinimumSize = new System.Drawing.Size(48, 13);
			Label17.Name = "Label17";
			Label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label17.Size = new System.Drawing.Size(48, 13);
			Label17.TabIndex = 47;
			Label17.Text = "Acct Rep:";
			// 
			// Label16
			// 
			Label16.AllowDrop = true;
			Label16.AutoSize = true;
			Label16.BackColor = System.Drawing.SystemColors.Control;
			Label16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label16.ForeColor = System.Drawing.SystemColors.ControlText;
			Label16.Location = new System.Drawing.Point(444, 15);
			Label16.MinimumSize = new System.Drawing.Size(60, 13);
			Label16.Name = "Label16";
			Label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label16.Size = new System.Drawing.Size(60, 13);
			Label16.TabIndex = 46;
			Label16.Text = "Date Added:";
			// 
			// Label15
			// 
			Label15.AllowDrop = true;
			Label15.AutoSize = true;
			Label15.BackColor = System.Drawing.SystemColors.Control;
			Label15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label15.ForeColor = System.Drawing.SystemColors.ControlText;
			Label15.Location = new System.Drawing.Point(445, 49);
			Label15.MinimumSize = new System.Drawing.Size(70, 13);
			Label15.Name = "Label15";
			Label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label15.Size = new System.Drawing.Size(70, 13);
			Label15.TabIndex = 45;
			Label15.Text = "Date Updated:";
			// 
			// Label13
			// 
			Label13.AllowDrop = true;
			Label13.AutoSize = true;
			Label13.BackColor = System.Drawing.SystemColors.Control;
			Label13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label13.ForeColor = System.Drawing.SystemColors.ControlText;
			Label13.Location = new System.Drawing.Point(133, 52);
			Label13.MinimumSize = new System.Drawing.Size(14, 13);
			Label13.Name = "Label13";
			Label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label13.Size = new System.Drawing.Size(14, 13);
			Label13.TabIndex = 43;
			Label13.Text = "ID:";
			// 
			// lblPubLink
			// 
			lblPubLink.AllowDrop = true;
			lblPubLink.AutoSize = true;
			lblPubLink.BackColor = System.Drawing.SystemColors.Control;
			lblPubLink.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblPubLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblPubLink.ForeColor = System.Drawing.Color.Blue;
			lblPubLink.Location = new System.Drawing.Point(315, 117);
			lblPubLink.MinimumSize = new System.Drawing.Size(23, 13);
			lblPubLink.Name = "lblPubLink";
			lblPubLink.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblPubLink.Size = new System.Drawing.Size(23, 13);
			lblPubLink.TabIndex = 42;
			lblPubLink.Text = "Link:";
			lblPubLink.Click += new System.EventHandler(lblPubLink_Click);
			// 
			// Label11
			// 
			Label11.AllowDrop = true;
			Label11.AutoSize = true;
			Label11.BackColor = System.Drawing.SystemColors.Control;
			Label11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label11.ForeColor = System.Drawing.SystemColors.ControlText;
			Label11.Location = new System.Drawing.Point(546, 11);
			Label11.MinimumSize = new System.Drawing.Size(46, 13);
			Label11.Name = "Label11";
			Label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label11.Size = new System.Drawing.Size(46, 13);
			Label11.TabIndex = 41;
			Label11.Text = "Listed By:";
			// 
			// Label10
			// 
			Label10.AllowDrop = true;
			Label10.AutoSize = true;
			Label10.BackColor = System.Drawing.SystemColors.Control;
			Label10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label10.ForeColor = System.Drawing.SystemColors.ControlText;
			Label10.Location = new System.Drawing.Point(147, 116);
			Label10.MinimumSize = new System.Drawing.Size(36, 13);
			Label10.Name = "Label10";
			Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label10.Size = new System.Drawing.Size(36, 13);
			Label10.TabIndex = 40;
			Label10.Text = "Ser No:";
			// 
			// Label9
			// 
			Label9.AllowDrop = true;
			Label9.AutoSize = true;
			Label9.BackColor = System.Drawing.SystemColors.Control;
			Label9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label9.ForeColor = System.Drawing.SystemColors.ControlText;
			Label9.Location = new System.Drawing.Point(11, 116);
			Label9.MinimumSize = new System.Drawing.Size(40, 13);
			Label9.Name = "Label9";
			Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label9.Size = new System.Drawing.Size(40, 13);
			Label9.TabIndex = 39;
			Label9.Text = "Reg No:";
			// 
			// Label8
			// 
			Label8.AllowDrop = true;
			Label8.AutoSize = true;
			Label8.BackColor = System.Drawing.SystemColors.Control;
			Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			Label8.Location = new System.Drawing.Point(345, 49);
			Label8.MinimumSize = new System.Drawing.Size(30, 13);
			Label8.Name = "Label8";
			Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label8.Size = new System.Drawing.Size(30, 13);
			Label8.TabIndex = 38;
			Label8.Text = "AFTT:";
			// 
			// Label7
			// 
			Label7.AllowDrop = true;
			Label7.AutoSize = true;
			Label7.BackColor = System.Drawing.SystemColors.Control;
			Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			Label7.Location = new System.Drawing.Point(344, 15);
			Label7.MinimumSize = new System.Drawing.Size(27, 14);
			Label7.Name = "Label7";
			Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label7.Size = new System.Drawing.Size(27, 14);
			Label7.TabIndex = 37;
			Label7.Text = "Price:";
			// 
			// Label6
			// 
			Label6.AllowDrop = true;
			Label6.AutoSize = true;
			Label6.BackColor = System.Drawing.SystemColors.Control;
			Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			Label6.Location = new System.Drawing.Point(7, 75);
			Label6.MinimumSize = new System.Drawing.Size(92, 13);
			Label6.Name = "Label6";
			Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label6.Size = new System.Drawing.Size(92, 13);
			Label6.TabIndex = 36;
			Label6.Text = "Aircraft Description:";
			// 
			// Label5
			// 
			Label5.AllowDrop = true;
			Label5.AutoSize = true;
			Label5.BackColor = System.Drawing.SystemColors.Control;
			Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			Label5.Location = new System.Drawing.Point(9, 50);
			Label5.MinimumSize = new System.Drawing.Size(36, 13);
			Label5.Name = "Label5";
			Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label5.Size = new System.Drawing.Size(36, 13);
			Label5.TabIndex = 35;
			Label5.Text = "Picture:";
			// 
			// Label4
			// 
			Label4.AllowDrop = true;
			Label4.AutoSize = true;
			Label4.BackColor = System.Drawing.SystemColors.Control;
			Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			Label4.Location = new System.Drawing.Point(22, 26);
			Label4.MinimumSize = new System.Drawing.Size(22, 13);
			Label4.Name = "Label4";
			Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label4.Size = new System.Drawing.Size(22, 13);
			Label4.TabIndex = 34;
			Label4.Text = "Pub:";
			// 
			// cbo_ACREP
			// 
			cbo_ACREP.AllowDrop = true;
			cbo_ACREP.BackColor = System.Drawing.SystemColors.Window;
			cbo_ACREP.CausesValidation = true;
			cbo_ACREP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ACREP.Enabled = true;
			cbo_ACREP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ACREP.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ACREP.IntegralHeight = true;
			cbo_ACREP.Location = new System.Drawing.Point(136, 36);
			cbo_ACREP.Name = "cbo_ACREP";
			cbo_ACREP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ACREP.Size = new System.Drawing.Size(83, 21);
			cbo_ACREP.Sorted = false;
			cbo_ACREP.TabIndex = 0;
			cbo_ACREP.TabStop = true;
			cbo_ACREP.Visible = true;
			cbo_ACREP.SelectionChangeCommitted += new System.EventHandler(cbo_ACREP_SelectionChangeCommitted);
			// 
			// inet_browse
			// 
			inet_browse.AllowDrop = true;
			inet_browse.Location = new System.Drawing.Point(861, 25);
			inet_browse.Name = "inet_browse";
			inet_browse.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("inet_browse.OcxState");
			// 
			// _lbl_gen_22
			// 
			_lbl_gen_22.AllowDrop = true;
			_lbl_gen_22.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_22.Location = new System.Drawing.Point(336, 29);
			_lbl_gen_22.MinimumSize = new System.Drawing.Size(57, 15);
			_lbl_gen_22.Name = "_lbl_gen_22";
			_lbl_gen_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_22.Size = new System.Drawing.Size(57, 15);
			_lbl_gen_22.TabIndex = 177;
			_lbl_gen_22.Text = "...";
			_lbl_gen_22.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_57
			// 
			_lbl_gen_57.AllowDrop = true;
			_lbl_gen_57.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_57.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_57.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_57.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_57.Location = new System.Drawing.Point(216, 21);
			_lbl_gen_57.MinimumSize = new System.Drawing.Size(57, 22);
			_lbl_gen_57.Name = "_lbl_gen_57";
			_lbl_gen_57.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_57.Size = new System.Drawing.Size(57, 22);
			_lbl_gen_57.TabIndex = 175;
			_lbl_gen_57.Text = ".....";
			_lbl_gen_57.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// Label20
			// 
			Label20.AllowDrop = true;
			Label20.AutoSize = true;
			Label20.BackColor = System.Drawing.Color.Transparent;
			Label20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label20.ForeColor = System.Drawing.SystemColors.ControlText;
			Label20.Location = new System.Drawing.Point(728, 40);
			Label20.MinimumSize = new System.Drawing.Size(36, 13);
			Label20.Name = "Label20";
			Label20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label20.Size = new System.Drawing.Size(36, 13);
			Label20.TabIndex = 61;
			Label20.Text = "Serial#:";
			// 
			// Label19
			// 
			Label19.AllowDrop = true;
			Label19.AutoSize = true;
			Label19.BackColor = System.Drawing.Color.Transparent;
			Label19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label19.ForeColor = System.Drawing.SystemColors.ControlText;
			Label19.Location = new System.Drawing.Point(584, 40);
			Label19.MinimumSize = new System.Drawing.Size(30, 13);
			Label19.Name = "Label19";
			Label19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label19.Size = new System.Drawing.Size(30, 13);
			Label19.TabIndex = 59;
			Label19.Text = "Reg#:";
			// 
			// Label18
			// 
			Label18.AllowDrop = true;
			Label18.AutoSize = true;
			Label18.BackColor = System.Drawing.SystemColors.Control;
			Label18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label18.ForeColor = System.Drawing.SystemColors.ControlText;
			Label18.Location = new System.Drawing.Point(432, 40);
			Label18.MinimumSize = new System.Drawing.Size(30, 13);
			Label18.Name = "Label18";
			Label18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label18.Size = new System.Drawing.Size(30, 13);
			Label18.TabIndex = 48;
			Label18.Text = "Day(s)";
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.AutoSize = true;
			Label3.BackColor = System.Drawing.Color.Transparent;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(11, 40);
			Label3.MinimumSize = new System.Drawing.Size(118, 13);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(118, 13);
			Label3.TabIndex = 31;
			Label3.Text = "Account Representative:";
			// 
			// frm_WebCrawl
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			CancelButton = cmd_Cancel;
			ClientSize = new System.Drawing.Size(989, 709);
			Controls.Add(_chk_include_23);
			Controls.Add(pnl_update_pub);
			Controls.Add(tab_NewAvail);
			Controls.Add(txt_Serialno_Search);
			Controls.Add(txt_Regno_Search);
			Controls.Add(cmd_ClearNoChange);
			Controls.Add(_pic_redx_1);
			Controls.Add(_pic_redx_2);
			Controls.Add(txt_publog_days);
			Controls.Add(chkShowCleared);
			Controls.Add(cmdRefresh);
			Controls.Add(frame_Details);
			Controls.Add(cbo_ACREP);
			Controls.Add(inet_browse);
			Controls.Add(_lbl_gen_22);
			Controls.Add(_lbl_gen_57);
			Controls.Add(Label20);
			Controls.Add(Label19);
			Controls.Add(Label18);
			Controls.Add(Label3);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Location = new System.Drawing.Point(327, 279);
			MaximizeBox = false;
			MinimizeBox = true;
			Name = "frm_WebCrawl";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Identify New Available Aircraft";
			commandButtonHelper1.SetStyle(_cmd_pub_6, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_5, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_3, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_1, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_0, 0);
			commandButtonHelper1.SetStyle(cmdClear, 0);
			commandButtonHelper1.SetStyle(cmdAddPub, 0);
			commandButtonHelper1.SetStyle(cmd_Stop, 0);
			commandButtonHelper1.SetStyle(cmdSendVerifyEMail, 0);
			commandButtonHelper1.SetStyle(cmd_GetAvail, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_17, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_10, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_16, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_4, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_7, 0);
			commandButtonHelper1.SetStyle(cmd_clear_pub, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_9, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_2, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_8, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_14, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_13, 0);
			commandButtonHelper1.SetStyle(cmd_clear_pub2, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_12, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_11, 0);
			commandButtonHelper1.SetStyle(_cmd_pub_15, 0);
			commandButtonHelper1.SetStyle(cmd_ClearNoChange, 0);
			commandButtonHelper1.SetStyle(cmdRefresh, 0);
			commandButtonHelper1.SetStyle(cmd_ClearLeave, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel, 0);
			commandButtonHelper1.SetStyle(cmd_Save, 0);
			commandButtonHelper1.SetStyle(cmd_Identify_AC, 0);
			optionButtonHelper1.SetStyle(opSubmitAircraft, 0);
			optionButtonHelper1.SetStyle(opSubmitCompany, 0);
			optionButtonHelper1.SetStyle(opSubmitBoth, 0);
			ToolTipMain.SetToolTip(cmdSendVerifyEMail, "Click to Send Verify EMail To Owner/Broker");
			ToolTipMain.SetToolTip(opSubmitAircraft, "Click To See Submitted Data on Aircraft");
			ToolTipMain.SetToolTip(opSubmitCompany, "Click To See Submitted Data on Company");
			ToolTipMain.SetToolTip(opSubmitBoth, "Click To See Submitted Data on Aircraft and Company");
			ToolTipMain.SetToolTip(lblPubLink, "Click To Open Pub in Browser");
			UpgradeHelpers.Gui.Controls.SSTabHelper.SetSelectedIndex(tab_NewAvail, 2);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_FormClosing);
			((System.ComponentModel.ISupportInitialize) grd_NewAvail).EndInit();
			((System.ComponentModel.ISupportInitialize) fgrdFindCustSubData).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_pub).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_pub2).EndInit();
			((System.ComponentModel.ISupportInitialize) inet_browse).EndInit();
			pnl_update_pub.ResumeLayout(false);
			pnl_update_pub.PerformLayout();
			pnl_add_pub.ResumeLayout(false);
			pnl_add_pub.PerformLayout();
			tab_NewAvail.ResumeLayout(false);
			tab_NewAvail.PerformLayout();
			_tab_NewAvail_TabPage0.ResumeLayout(false);
			_tab_NewAvail_TabPage0.PerformLayout();
			_tab_NewAvail_TabPage1.ResumeLayout(false);
			_tab_NewAvail_TabPage1.PerformLayout();
			_tab_NewAvail_TabPage2.ResumeLayout(false);
			_tab_NewAvail_TabPage2.PerformLayout();
			pnl_pub_listing.ResumeLayout(false);
			pnl_pub_listing.PerformLayout();
			frm_listing1.ResumeLayout(false);
			frm_listing1.PerformLayout();
			pnl_add_model_exception.ResumeLayout(false);
			pnl_add_model_exception.PerformLayout();
			_tab_NewAvail_TabPage3.ResumeLayout(false);
			_tab_NewAvail_TabPage3.PerformLayout();
			SSPanel1.ResumeLayout(false);
			SSPanel1.PerformLayout();
			Frame1.ResumeLayout(false);
			Frame1.PerformLayout();
			SSPanel2.ResumeLayout(false);
			SSPanel2.PerformLayout();
			frame_Details.ResumeLayout(false);
			frame_Details.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializetxt_pub();
			Initializepic_redx();
			Initializelbl_gen();
			Initializecmd_pub();
			Initializechk_include();
			Initializecbo_pub();
			tab_NewAvailPreviousTab = tab_NewAvail.SelectedIndex;
		}
		void Initializetxt_pub()
		{
			txt_pub = new System.Windows.Forms.TextBox[20];
			txt_pub[14] = _txt_pub_14;
			txt_pub[5] = _txt_pub_5;
			txt_pub[4] = _txt_pub_4;
			txt_pub[9] = _txt_pub_9;
			txt_pub[6] = _txt_pub_6;
			txt_pub[10] = _txt_pub_10;
			txt_pub[3] = _txt_pub_3;
			txt_pub[2] = _txt_pub_2;
			txt_pub[0] = _txt_pub_0;
			txt_pub[1] = _txt_pub_1;
			txt_pub[7] = _txt_pub_7;
			txt_pub[11] = _txt_pub_11;
			txt_pub[12] = _txt_pub_12;
			txt_pub[13] = _txt_pub_13;
			txt_pub[8] = _txt_pub_8;
			txt_pub[18] = _txt_pub_18;
			txt_pub[17] = _txt_pub_17;
			txt_pub[16] = _txt_pub_16;
			txt_pub[15] = _txt_pub_15;
			txt_pub[19] = _txt_pub_19;
		}
		void Initializepic_redx()
		{
			pic_redx = new System.Windows.Forms.PictureBox[3];
			pic_redx[1] = _pic_redx_1;
			pic_redx[2] = _pic_redx_2;
		}
		void Initializelbl_gen()
		{
			lbl_gen = new System.Windows.Forms.Label[58];
			lbl_gen[7] = _lbl_gen_7;
			lbl_gen[3] = _lbl_gen_3;
			lbl_gen[13] = _lbl_gen_13;
			lbl_gen[12] = _lbl_gen_12;
			lbl_gen[0] = _lbl_gen_0;
			lbl_gen[8] = _lbl_gen_8;
			lbl_gen[2] = _lbl_gen_2;
			lbl_gen[1] = _lbl_gen_1;
			lbl_gen[4] = _lbl_gen_4;
			lbl_gen[47] = _lbl_gen_47;
			lbl_gen[44] = _lbl_gen_44;
			lbl_gen[43] = _lbl_gen_43;
			lbl_gen[42] = _lbl_gen_42;
			lbl_gen[41] = _lbl_gen_41;
			lbl_gen[40] = _lbl_gen_40;
			lbl_gen[39] = _lbl_gen_39;
			lbl_gen[38] = _lbl_gen_38;
			lbl_gen[21] = _lbl_gen_21;
			lbl_gen[46] = _lbl_gen_46;
			lbl_gen[5] = _lbl_gen_5;
			lbl_gen[9] = _lbl_gen_9;
			lbl_gen[10] = _lbl_gen_10;
			lbl_gen[11] = _lbl_gen_11;
			lbl_gen[6] = _lbl_gen_6;
			lbl_gen[23] = _lbl_gen_23;
			lbl_gen[45] = _lbl_gen_45;
			lbl_gen[18] = _lbl_gen_18;
			lbl_gen[17] = _lbl_gen_17;
			lbl_gen[16] = _lbl_gen_16;
			lbl_gen[15] = _lbl_gen_15;
			lbl_gen[14] = _lbl_gen_14;
			lbl_gen[19] = _lbl_gen_19;
			lbl_gen[20] = _lbl_gen_20;
			lbl_gen[22] = _lbl_gen_22;
			lbl_gen[57] = _lbl_gen_57;
		}
		void Initializecmd_pub()
		{
			cmd_pub = new System.Windows.Forms.Button[18];
			cmd_pub[6] = _cmd_pub_6;
			cmd_pub[5] = _cmd_pub_5;
			cmd_pub[3] = _cmd_pub_3;
			cmd_pub[1] = _cmd_pub_1;
			cmd_pub[0] = _cmd_pub_0;
			cmd_pub[17] = _cmd_pub_17;
			cmd_pub[10] = _cmd_pub_10;
			cmd_pub[16] = _cmd_pub_16;
			cmd_pub[4] = _cmd_pub_4;
			cmd_pub[7] = _cmd_pub_7;
			cmd_pub[9] = _cmd_pub_9;
			cmd_pub[2] = _cmd_pub_2;
			cmd_pub[8] = _cmd_pub_8;
			cmd_pub[14] = _cmd_pub_14;
			cmd_pub[13] = _cmd_pub_13;
			cmd_pub[12] = _cmd_pub_12;
			cmd_pub[11] = _cmd_pub_11;
			cmd_pub[15] = _cmd_pub_15;
		}
		void Initializechk_include()
		{
			chk_include = new System.Windows.Forms.CheckBox[26];
			chk_include[23] = _chk_include_23;
			chk_include[6] = _chk_include_6;
			chk_include[25] = _chk_include_25;
			chk_include[3] = _chk_include_3;
			chk_include[2] = _chk_include_2;
			chk_include[0] = _chk_include_0;
			chk_include[1] = _chk_include_1;
			chk_include[4] = _chk_include_4;
			chk_include[5] = _chk_include_5;
			chk_include[7] = _chk_include_7;
			chk_include[8] = _chk_include_8;
			chk_include[9] = _chk_include_9;
			chk_include[10] = _chk_include_10;
			chk_include[11] = _chk_include_11;
			chk_include[24] = _chk_include_24;
			chk_include[22] = _chk_include_22;
			chk_include[21] = _chk_include_21;
			chk_include[20] = _chk_include_20;
			chk_include[19] = _chk_include_19;
			chk_include[18] = _chk_include_18;
			chk_include[17] = _chk_include_17;
			chk_include[16] = _chk_include_16;
			chk_include[15] = _chk_include_15;
			chk_include[14] = _chk_include_14;
			chk_include[13] = _chk_include_13;
			chk_include[12] = _chk_include_12;
		}
		void Initializecbo_pub()
		{
			cbo_pub = new System.Windows.Forms.ComboBox[12];
			cbo_pub[6] = _cbo_pub_6;
			cbo_pub[3] = _cbo_pub_3;
			cbo_pub[5] = _cbo_pub_5;
			cbo_pub[4] = _cbo_pub_4;
			cbo_pub[1] = _cbo_pub_1;
			cbo_pub[0] = _cbo_pub_0;
			cbo_pub[11] = _cbo_pub_11;
			cbo_pub[10] = _cbo_pub_10;
			cbo_pub[2] = _cbo_pub_2;
			cbo_pub[7] = _cbo_pub_7;
			cbo_pub[9] = _cbo_pub_9;
			cbo_pub[8] = _cbo_pub_8;
		}
		#endregion
	}
}