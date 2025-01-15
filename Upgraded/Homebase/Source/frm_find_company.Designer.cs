
namespace JETNET_Homebase
{
	partial class frm_Find_Company
	{

		#region "Upgrade Support "
		private static frm_Find_Company m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Find_Company DefInstance
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
		public static frm_Find_Company CreateInstance()
		{
			frm_Find_Company theInstance = new frm_Find_Company();
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
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileClose", "mnuFileLogout", "mnuFile", "mnuEditBadListDates", "mnuEditRemoveDupPhones", "mnuEdit", "mnuViewDups20", "mnuUnHideDupGrid", "mnuFortune", "mnuView", "mnuReport", "mnuFindCompanyShowUserHistory", "mnuTools", "MainMenu1", "tbr_ToolBar_Buttons_Button1", "tbr_ToolBar_Buttons_Button2", "tbr_ToolBar_Buttons_Button3", "tbr_ToolBar_Buttons_Button4", "tbr_ToolBar_Buttons_Button5", "tbr_ToolBar_Buttons_Button6", "tbr_ToolBar_Buttons_Button7", "tbr_ToolBar_Buttons_Button8", "tbr_ToolBar", "_optSearchCust_0", "_optSearchCust_1", "_optSearchCust_2", "frmCustomers", "_chk_prod_code_3", "_chk_prod_code_2", "_chk_prod_code_1", "_chk_prod_code_0", "pnl_prod_code", "cbo_MailList", "_pic_redx_3", "_pic_redx_2", "compTimer1", "_pic_redx_1", "lst_country", "txt_comp_city", "txt_comp_zip_code", "_opt_continent_region_0", "_opt_continent_region_1", "lst_state", "lst_area", "_lbl_Label1_8", "_lbl_Label1_11", "_lbl_Label1_10", "_lbl_Label1_9", "pnl_company_demographics", "chkIncludeServices", "cmd_Find", "opt_companies", "opt_contacts", "cmd_Clear", "chk_history", "pnl_search", "_lbl_Label1_28", "pnl_wait_text", "chkCompRelHide", "cbo_contact2", "cbo_contact", "lst_company2", "lst_company1", "cbo_relationship", "_lbl_Label1_27", "pnl_company_relationships", "lst_contact_info", "cmd_Confirm_Contact", "pnl_contact_info", "cmd_awaiting_docsOK", "cbo_unknown_state", "cbo_unknown_country", "_lbl_Label1_25", "_lbl_Label1_26", "frame_awaiting_documentation", "lst_aircraft_info", "cbo_contact_type", "cmd_Associate", "_lbl_Label1_22", "pnl_associate_aircraft", "cmd_close_duplicates", "cmd_remove_duplicates", "lst_duplicates", "pnl_duplicates", "lst_company", "chk_include_history", "cmd_Confirm_Company", "txt_num_characters", "chk_match_city", "cmd_find_duplicate", "_lbl_Label1_23", "pnl_company_info", "cmd_Add_contact_trial", "cmd_sale_source", "cmd_add_to_pub", "chk_search", "cmdCompanyListExcelExport", "cmd_Refresh", "cmd_Add_Contact", "cmd_Stop", "grd_find_company", "lbl_test_omg", "lbl_total_found", "_lbl_Label1_24", "pnl_search_results", "pnl_display_results", "cmd_dup_hide_grid_frame", "cmd_dup_paste_to_clipboard", "cmd_dup_stop_grid_fill", "grd_potential_duplicates", "_lbl_Label1_33", "frame_potential_dups_grid", "cbo_dup_account_rep", "cmd_find_potential_dup", "chk_dup_sort", "_opt_dup_sortby_5", "_opt_dup_sortby_4", "_opt_dup_sortby_3", "_opt_dup_sortby_0", "_chk_dup_include_2", "_chk_dup_include_1", "_chk_dup_include_0", "txt_dup_num_chars", "cmd_hide_potential_dup_frame", "_opt_dup_sortby_1", "chk_dup_phone", "_opt_dup_sortby_6", "chk_exclude_comp_to_comp", "chk_dup_contacts", "_opt_dup_sortby_2", "chk_dup_confirm_non_dups", "_lbl_Label1_32", "_lbl_Label1_31", "_lbl_Label1_30", "_lbl_Label1_29", "frame_potential_dups", "cbo_cert_drop", "chk_inactives", "chk_primary", "chk_show_yacht_count", "chk_hide_zero", "chk_OR", "_txt_ac_value_1", "_cbo_compare_1", "_cbo_owner_type_1", "_cbo_product_1", "_cbo_product_0", "chk_share_relationships_withoutAC", "chk_share_relationships", "chk_aircraft_count", "_cbo_owner_type_0", "_cbo_compare_0", "_txt_ac_value_0", "_lbl_Label1_12", "_lbl_Label1_13", "_lbl_Label1_14", "pnl_aircraft_info", "lst_title_group", "cbo_contact_title", "txt_contact_email_address", "txt_pnum_number_full", "txt_contact_first_name", "txt_contact_last_name", "_lbl_Label1_20", "_lbl_Label1_17", "_lbl_Label1_19", "_lbl_Label1_18", "_lbl_Label1_16", "_lbl_Label1_15", "pnl_contact", "txt_airport_id_name", "txt_cert_search", "chkCompContactAddressFlag", "dba_check", "_txt_company_id_1", "txt_comp_name", "cbo_business_type", "cbo_account_rep", "cmd_Add_Company", "cmd_AcPros", "chk_ACPros", "txt_comp_phone", "txt_comp_email", "_txt_company_id_0", "txt_comp_web_address", "cbo_agency_type", "txt_comp_address", "_lbl_Label1_36", "_lbl_Label1_35", "lbl_dba", "_lbl_Label1_34", "_lbl_Label1_4", "_lbl_Label1_3", "_lbl_Label1_6", "_lbl_Label1_7", "_lbl_Label1_21", "_lbl_Label1_5", "_lbl_Label1_2", "_lbl_Label1_0", "_lbl_Label1_1", "pnl_company", "lbl_List", "ln_line1", "cbo_compare", "cbo_owner_type", "cbo_product", "chk_dup_include", "chk_prod_code", "lbl_Label1", "optSearchCust", "opt_continent_region", "opt_dup_sortby", "pic_redx", "txt_ac_value", "txt_company_id", "listBoxComboBoxHelper1", "commandButtonHelper1", "listBoxHelper1", "optionButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFileLogout;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.ToolStripMenuItem mnuEditBadListDates;
		public System.Windows.Forms.ToolStripMenuItem mnuEditRemoveDupPhones;
		public System.Windows.Forms.ToolStripMenuItem mnuEdit;
		public System.Windows.Forms.ToolStripMenuItem mnuViewDups20;
		public System.Windows.Forms.ToolStripMenuItem mnuUnHideDupGrid;
		public System.Windows.Forms.ToolStripMenuItem mnuFortune;
		public System.Windows.Forms.ToolStripMenuItem mnuView;
		public System.Windows.Forms.ToolStripMenuItem mnuReport;
		public System.Windows.Forms.ToolStripMenuItem mnuFindCompanyShowUserHistory;
		public System.Windows.Forms.ToolStripMenuItem mnuTools;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button1;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button2;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button3;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button4;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button5;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button6;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button7;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button8;
		public System.Windows.Forms.ToolStrip tbr_ToolBar;
		private System.Windows.Forms.RadioButton _optSearchCust_0;
		private System.Windows.Forms.RadioButton _optSearchCust_1;
		private System.Windows.Forms.RadioButton _optSearchCust_2;
		public System.Windows.Forms.GroupBox frmCustomers;
		private System.Windows.Forms.CheckBox _chk_prod_code_3;
		private System.Windows.Forms.CheckBox _chk_prod_code_2;
		private System.Windows.Forms.CheckBox _chk_prod_code_1;
		private System.Windows.Forms.CheckBox _chk_prod_code_0;
		public System.Windows.Forms.Panel pnl_prod_code;
		public System.Windows.Forms.ComboBox cbo_MailList;
		private System.Windows.Forms.PictureBox _pic_redx_3;
		private System.Windows.Forms.PictureBox _pic_redx_2;
		public System.Windows.Forms.Timer compTimer1;
		private System.Windows.Forms.PictureBox _pic_redx_1;
		public System.Windows.Forms.ListBox lst_country;
		public System.Windows.Forms.TextBox txt_comp_city;
		public System.Windows.Forms.TextBox txt_comp_zip_code;
		private System.Windows.Forms.RadioButton _opt_continent_region_0;
		private System.Windows.Forms.RadioButton _opt_continent_region_1;
		public System.Windows.Forms.ListBox lst_state;
		public System.Windows.Forms.ListBox lst_area;
		private System.Windows.Forms.Label _lbl_Label1_8;
		private System.Windows.Forms.Label _lbl_Label1_11;
		private System.Windows.Forms.Label _lbl_Label1_10;
		private System.Windows.Forms.Label _lbl_Label1_9;
		public System.Windows.Forms.Panel pnl_company_demographics;
		public System.Windows.Forms.CheckBox chkIncludeServices;
		public System.Windows.Forms.Button cmd_Find;
		public System.Windows.Forms.RadioButton opt_companies;
		public System.Windows.Forms.RadioButton opt_contacts;
		public System.Windows.Forms.Button cmd_Clear;
		public System.Windows.Forms.CheckBox chk_history;
		public System.Windows.Forms.Panel pnl_search;
		private System.Windows.Forms.Label _lbl_Label1_28;
		public System.Windows.Forms.Panel pnl_wait_text;
		public System.Windows.Forms.CheckBox chkCompRelHide;
		public System.Windows.Forms.ComboBox cbo_contact2;
		public System.Windows.Forms.ComboBox cbo_contact;
		public System.Windows.Forms.ListBox lst_company2;
		public System.Windows.Forms.ListBox lst_company1;
		public System.Windows.Forms.ComboBox cbo_relationship;
		private System.Windows.Forms.Label _lbl_Label1_27;
		public System.Windows.Forms.Panel pnl_company_relationships;
		public System.Windows.Forms.ListBox lst_contact_info;
		public System.Windows.Forms.Button cmd_Confirm_Contact;
		public System.Windows.Forms.Panel pnl_contact_info;
		public System.Windows.Forms.Button cmd_awaiting_docsOK;
		public System.Windows.Forms.ComboBox cbo_unknown_state;
		public System.Windows.Forms.ComboBox cbo_unknown_country;
		private System.Windows.Forms.Label _lbl_Label1_25;
		private System.Windows.Forms.Label _lbl_Label1_26;
		public System.Windows.Forms.GroupBox frame_awaiting_documentation;
		public System.Windows.Forms.ListBox lst_aircraft_info;
		public System.Windows.Forms.ComboBox cbo_contact_type;
		public System.Windows.Forms.Button cmd_Associate;
		private System.Windows.Forms.Label _lbl_Label1_22;
		public System.Windows.Forms.Panel pnl_associate_aircraft;
		public System.Windows.Forms.Button cmd_close_duplicates;
		public System.Windows.Forms.Button cmd_remove_duplicates;
		public System.Windows.Forms.ListBox lst_duplicates;
		public System.Windows.Forms.Panel pnl_duplicates;
		public System.Windows.Forms.ListBox lst_company;
		public System.Windows.Forms.CheckBox chk_include_history;
		public System.Windows.Forms.Button cmd_Confirm_Company;
		public System.Windows.Forms.TextBox txt_num_characters;
		public System.Windows.Forms.CheckBox chk_match_city;
		public System.Windows.Forms.Button cmd_find_duplicate;
		private System.Windows.Forms.Label _lbl_Label1_23;
		public System.Windows.Forms.Panel pnl_company_info;
		public System.Windows.Forms.Button cmd_Add_contact_trial;
		public System.Windows.Forms.Button cmd_sale_source;
		public System.Windows.Forms.Button cmd_add_to_pub;
		public System.Windows.Forms.CheckBox chk_search;
		public System.Windows.Forms.Button cmdCompanyListExcelExport;
		public System.Windows.Forms.Button cmd_Refresh;
		public System.Windows.Forms.Button cmd_Add_Contact;
		public System.Windows.Forms.Button cmd_Stop;
		public UpgradeHelpers.DataGridViewFlex grd_find_company;
		public System.Windows.Forms.Label lbl_test_omg;
		public System.Windows.Forms.Label lbl_total_found;
		private System.Windows.Forms.Label _lbl_Label1_24;
		public System.Windows.Forms.Panel pnl_search_results;
		public System.Windows.Forms.Panel pnl_display_results;
		public System.Windows.Forms.Button cmd_dup_hide_grid_frame;
		public System.Windows.Forms.Button cmd_dup_paste_to_clipboard;
		public System.Windows.Forms.Button cmd_dup_stop_grid_fill;
		public UpgradeHelpers.DataGridViewFlex grd_potential_duplicates;
		private System.Windows.Forms.Label _lbl_Label1_33;
		public System.Windows.Forms.GroupBox frame_potential_dups_grid;
		public System.Windows.Forms.ComboBox cbo_dup_account_rep;
		public System.Windows.Forms.Button cmd_find_potential_dup;
		public System.Windows.Forms.CheckBox chk_dup_sort;
		private System.Windows.Forms.RadioButton _opt_dup_sortby_5;
		private System.Windows.Forms.RadioButton _opt_dup_sortby_4;
		private System.Windows.Forms.RadioButton _opt_dup_sortby_3;
		private System.Windows.Forms.RadioButton _opt_dup_sortby_0;
		private System.Windows.Forms.CheckBox _chk_dup_include_2;
		private System.Windows.Forms.CheckBox _chk_dup_include_1;
		private System.Windows.Forms.CheckBox _chk_dup_include_0;
		public System.Windows.Forms.TextBox txt_dup_num_chars;
		public System.Windows.Forms.Button cmd_hide_potential_dup_frame;
		private System.Windows.Forms.RadioButton _opt_dup_sortby_1;
		public System.Windows.Forms.CheckBox chk_dup_phone;
		private System.Windows.Forms.RadioButton _opt_dup_sortby_6;
		public System.Windows.Forms.CheckBox chk_exclude_comp_to_comp;
		public System.Windows.Forms.CheckBox chk_dup_contacts;
		private System.Windows.Forms.RadioButton _opt_dup_sortby_2;
		public System.Windows.Forms.CheckBox chk_dup_confirm_non_dups;
		private System.Windows.Forms.Label _lbl_Label1_32;
		private System.Windows.Forms.Label _lbl_Label1_31;
		private System.Windows.Forms.Label _lbl_Label1_30;
		private System.Windows.Forms.Label _lbl_Label1_29;
		public System.Windows.Forms.GroupBox frame_potential_dups;
		public System.Windows.Forms.ComboBox cbo_cert_drop;
		public System.Windows.Forms.CheckBox chk_inactives;
		public System.Windows.Forms.CheckBox chk_primary;
		public System.Windows.Forms.CheckBox chk_show_yacht_count;
		public System.Windows.Forms.CheckBox chk_hide_zero;
		public System.Windows.Forms.CheckBox chk_OR;
		private System.Windows.Forms.TextBox _txt_ac_value_1;
		private System.Windows.Forms.ComboBox _cbo_compare_1;
		private System.Windows.Forms.ComboBox _cbo_owner_type_1;
		private System.Windows.Forms.ComboBox _cbo_product_1;
		private System.Windows.Forms.ComboBox _cbo_product_0;
		public System.Windows.Forms.CheckBox chk_share_relationships_withoutAC;
		public System.Windows.Forms.CheckBox chk_share_relationships;
		public System.Windows.Forms.CheckBox chk_aircraft_count;
		private System.Windows.Forms.ComboBox _cbo_owner_type_0;
		private System.Windows.Forms.ComboBox _cbo_compare_0;
		private System.Windows.Forms.TextBox _txt_ac_value_0;
		private System.Windows.Forms.Label _lbl_Label1_12;
		private System.Windows.Forms.Label _lbl_Label1_13;
		private System.Windows.Forms.Label _lbl_Label1_14;
		public System.Windows.Forms.Panel pnl_aircraft_info;
		public System.Windows.Forms.ListBox lst_title_group;
		public System.Windows.Forms.ComboBox cbo_contact_title;
		public System.Windows.Forms.TextBox txt_contact_email_address;
		public System.Windows.Forms.TextBox txt_pnum_number_full;
		public System.Windows.Forms.TextBox txt_contact_first_name;
		public System.Windows.Forms.TextBox txt_contact_last_name;
		private System.Windows.Forms.Label _lbl_Label1_20;
		private System.Windows.Forms.Label _lbl_Label1_17;
		private System.Windows.Forms.Label _lbl_Label1_19;
		private System.Windows.Forms.Label _lbl_Label1_18;
		private System.Windows.Forms.Label _lbl_Label1_16;
		private System.Windows.Forms.Label _lbl_Label1_15;
		public System.Windows.Forms.Panel pnl_contact;
		public System.Windows.Forms.TextBox txt_airport_id_name;
		public System.Windows.Forms.TextBox txt_cert_search;
		public System.Windows.Forms.CheckBox chkCompContactAddressFlag;
		public System.Windows.Forms.CheckBox dba_check;
		private System.Windows.Forms.TextBox _txt_company_id_1;
		public System.Windows.Forms.TextBox txt_comp_name;
		public System.Windows.Forms.ComboBox cbo_business_type;
		public System.Windows.Forms.ComboBox cbo_account_rep;
		public System.Windows.Forms.Button cmd_Add_Company;
		public System.Windows.Forms.Button cmd_AcPros;
		public System.Windows.Forms.CheckBox chk_ACPros;
		public System.Windows.Forms.TextBox txt_comp_phone;
		public System.Windows.Forms.TextBox txt_comp_email;
		private System.Windows.Forms.TextBox _txt_company_id_0;
		public System.Windows.Forms.TextBox txt_comp_web_address;
		public System.Windows.Forms.ComboBox cbo_agency_type;
		public System.Windows.Forms.TextBox txt_comp_address;
		private System.Windows.Forms.Label _lbl_Label1_36;
		private System.Windows.Forms.Label _lbl_Label1_35;
		public System.Windows.Forms.Label lbl_dba;
		private System.Windows.Forms.Label _lbl_Label1_34;
		private System.Windows.Forms.Label _lbl_Label1_4;
		private System.Windows.Forms.Label _lbl_Label1_3;
		private System.Windows.Forms.Label _lbl_Label1_6;
		private System.Windows.Forms.Label _lbl_Label1_7;
		private System.Windows.Forms.Label _lbl_Label1_21;
		private System.Windows.Forms.Label _lbl_Label1_5;
		private System.Windows.Forms.Label _lbl_Label1_2;
		private System.Windows.Forms.Label _lbl_Label1_0;
		private System.Windows.Forms.Label _lbl_Label1_1;
		public System.Windows.Forms.Panel pnl_company;
		public System.Windows.Forms.Label lbl_List;
		public System.Windows.Forms.Label ln_line1;
		public System.Windows.Forms.ComboBox[] cbo_compare = new System.Windows.Forms.ComboBox[2];
		public System.Windows.Forms.ComboBox[] cbo_owner_type = new System.Windows.Forms.ComboBox[2];
		public System.Windows.Forms.ComboBox[] cbo_product = new System.Windows.Forms.ComboBox[2];
		public System.Windows.Forms.CheckBox[] chk_dup_include = new System.Windows.Forms.CheckBox[3];
		public System.Windows.Forms.CheckBox[] chk_prod_code = new System.Windows.Forms.CheckBox[4];
		public System.Windows.Forms.Label[] lbl_Label1 = new System.Windows.Forms.Label[37];
		public System.Windows.Forms.RadioButton[] optSearchCust = new System.Windows.Forms.RadioButton[3];
		public System.Windows.Forms.RadioButton[] opt_continent_region = new System.Windows.Forms.RadioButton[2];
		public System.Windows.Forms.RadioButton[] opt_dup_sortby = new System.Windows.Forms.RadioButton[7];
		public System.Windows.Forms.PictureBox[] pic_redx = new System.Windows.Forms.PictureBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_value = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.TextBox[] txt_company_id = new System.Windows.Forms.TextBox[2];
		public UpgradeHelpers.Gui.Controls.ListControlHelper listBoxComboBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public System.ComponentModel.ComponentResourceManager resources;
	    //NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Find_Company));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileLogout = new System.Windows.Forms.ToolStripMenuItem();
			mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditBadListDates = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditRemoveDupPhones = new System.Windows.Forms.ToolStripMenuItem();
			mnuView = new System.Windows.Forms.ToolStripMenuItem();
			mnuViewDups20 = new System.Windows.Forms.ToolStripMenuItem();
			mnuUnHideDupGrid = new System.Windows.Forms.ToolStripMenuItem();
			mnuFortune = new System.Windows.Forms.ToolStripMenuItem();
			mnuReport = new System.Windows.Forms.ToolStripMenuItem();
			mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			mnuFindCompanyShowUserHistory = new System.Windows.Forms.ToolStripMenuItem();
			tbr_ToolBar = new System.Windows.Forms.ToolStrip();
			tbr_ToolBar_Buttons_Button1 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button2 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button3 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button4 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button5 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button6 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button7 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button8 = new System.Windows.Forms.ToolStripButton();
			pnl_prod_code = new System.Windows.Forms.Panel();
			frmCustomers = new System.Windows.Forms.GroupBox();
			_optSearchCust_0 = new System.Windows.Forms.RadioButton();
			_optSearchCust_1 = new System.Windows.Forms.RadioButton();
			_optSearchCust_2 = new System.Windows.Forms.RadioButton();
			_chk_prod_code_3 = new System.Windows.Forms.CheckBox();
			_chk_prod_code_2 = new System.Windows.Forms.CheckBox();
			_chk_prod_code_1 = new System.Windows.Forms.CheckBox();
			_chk_prod_code_0 = new System.Windows.Forms.CheckBox();
			cbo_MailList = new System.Windows.Forms.ComboBox();
			pnl_company_demographics = new System.Windows.Forms.Panel();
			_pic_redx_3 = new System.Windows.Forms.PictureBox();
			_pic_redx_2 = new System.Windows.Forms.PictureBox();
			compTimer1 = new System.Windows.Forms.Timer(components);
			_pic_redx_1 = new System.Windows.Forms.PictureBox();
			lst_country = new System.Windows.Forms.ListBox();
			txt_comp_city = new System.Windows.Forms.TextBox();
			txt_comp_zip_code = new System.Windows.Forms.TextBox();
			_opt_continent_region_0 = new System.Windows.Forms.RadioButton();
			_opt_continent_region_1 = new System.Windows.Forms.RadioButton();
			lst_state = new System.Windows.Forms.ListBox();
			lst_area = new System.Windows.Forms.ListBox();
			_lbl_Label1_8 = new System.Windows.Forms.Label();
			_lbl_Label1_11 = new System.Windows.Forms.Label();
			_lbl_Label1_10 = new System.Windows.Forms.Label();
			_lbl_Label1_9 = new System.Windows.Forms.Label();
			pnl_search = new System.Windows.Forms.Panel();
			chkIncludeServices = new System.Windows.Forms.CheckBox();
			cmd_Find = new System.Windows.Forms.Button();
			opt_companies = new System.Windows.Forms.RadioButton();
			opt_contacts = new System.Windows.Forms.RadioButton();
			cmd_Clear = new System.Windows.Forms.Button();
			chk_history = new System.Windows.Forms.CheckBox();
			pnl_wait_text = new System.Windows.Forms.Panel();
			_lbl_Label1_28 = new System.Windows.Forms.Label();
			pnl_display_results = new System.Windows.Forms.Panel();
			pnl_company_relationships = new System.Windows.Forms.Panel();
			chkCompRelHide = new System.Windows.Forms.CheckBox();
			cbo_contact2 = new System.Windows.Forms.ComboBox();
			cbo_contact = new System.Windows.Forms.ComboBox();
			lst_company2 = new System.Windows.Forms.ListBox();
			lst_company1 = new System.Windows.Forms.ListBox();
			cbo_relationship = new System.Windows.Forms.ComboBox();
			_lbl_Label1_27 = new System.Windows.Forms.Label();
			pnl_contact_info = new System.Windows.Forms.Panel();
			lst_contact_info = new System.Windows.Forms.ListBox();
			cmd_Confirm_Contact = new System.Windows.Forms.Button();
			frame_awaiting_documentation = new System.Windows.Forms.GroupBox();
			cmd_awaiting_docsOK = new System.Windows.Forms.Button();
			cbo_unknown_state = new System.Windows.Forms.ComboBox();
			cbo_unknown_country = new System.Windows.Forms.ComboBox();
			_lbl_Label1_25 = new System.Windows.Forms.Label();
			_lbl_Label1_26 = new System.Windows.Forms.Label();
			pnl_associate_aircraft = new System.Windows.Forms.Panel();
			lst_aircraft_info = new System.Windows.Forms.ListBox();
			cbo_contact_type = new System.Windows.Forms.ComboBox();
			cmd_Associate = new System.Windows.Forms.Button();
			_lbl_Label1_22 = new System.Windows.Forms.Label();
			pnl_duplicates = new System.Windows.Forms.Panel();
			cmd_close_duplicates = new System.Windows.Forms.Button();
			cmd_remove_duplicates = new System.Windows.Forms.Button();
			lst_duplicates = new System.Windows.Forms.ListBox();
			pnl_company_info = new System.Windows.Forms.Panel();
			lst_company = new System.Windows.Forms.ListBox();
			chk_include_history = new System.Windows.Forms.CheckBox();
			cmd_Confirm_Company = new System.Windows.Forms.Button();
			txt_num_characters = new System.Windows.Forms.TextBox();
			chk_match_city = new System.Windows.Forms.CheckBox();
			cmd_find_duplicate = new System.Windows.Forms.Button();
			_lbl_Label1_23 = new System.Windows.Forms.Label();
			pnl_search_results = new System.Windows.Forms.Panel();
			cmd_Add_contact_trial = new System.Windows.Forms.Button();
			cmd_sale_source = new System.Windows.Forms.Button();
			cmd_add_to_pub = new System.Windows.Forms.Button();
			chk_search = new System.Windows.Forms.CheckBox();
			cmdCompanyListExcelExport = new System.Windows.Forms.Button();
			cmd_Refresh = new System.Windows.Forms.Button();
			cmd_Add_Contact = new System.Windows.Forms.Button();
			cmd_Stop = new System.Windows.Forms.Button();
			grd_find_company = new UpgradeHelpers.DataGridViewFlex(components);
			lbl_test_omg = new System.Windows.Forms.Label();
			lbl_total_found = new System.Windows.Forms.Label();
			_lbl_Label1_24 = new System.Windows.Forms.Label();
			frame_potential_dups_grid = new System.Windows.Forms.GroupBox();
			cmd_dup_hide_grid_frame = new System.Windows.Forms.Button();
			cmd_dup_paste_to_clipboard = new System.Windows.Forms.Button();
			cmd_dup_stop_grid_fill = new System.Windows.Forms.Button();
			grd_potential_duplicates = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_Label1_33 = new System.Windows.Forms.Label();
			frame_potential_dups = new System.Windows.Forms.GroupBox();
			cbo_dup_account_rep = new System.Windows.Forms.ComboBox();
			cmd_find_potential_dup = new System.Windows.Forms.Button();
			chk_dup_sort = new System.Windows.Forms.CheckBox();
			_opt_dup_sortby_5 = new System.Windows.Forms.RadioButton();
			_opt_dup_sortby_4 = new System.Windows.Forms.RadioButton();
			_opt_dup_sortby_3 = new System.Windows.Forms.RadioButton();
			_opt_dup_sortby_0 = new System.Windows.Forms.RadioButton();
			_chk_dup_include_2 = new System.Windows.Forms.CheckBox();
			_chk_dup_include_1 = new System.Windows.Forms.CheckBox();
			_chk_dup_include_0 = new System.Windows.Forms.CheckBox();
			txt_dup_num_chars = new System.Windows.Forms.TextBox();
			cmd_hide_potential_dup_frame = new System.Windows.Forms.Button();
			_opt_dup_sortby_1 = new System.Windows.Forms.RadioButton();
			chk_dup_phone = new System.Windows.Forms.CheckBox();
			_opt_dup_sortby_6 = new System.Windows.Forms.RadioButton();
			chk_exclude_comp_to_comp = new System.Windows.Forms.CheckBox();
			chk_dup_contacts = new System.Windows.Forms.CheckBox();
			_opt_dup_sortby_2 = new System.Windows.Forms.RadioButton();
			chk_dup_confirm_non_dups = new System.Windows.Forms.CheckBox();
			_lbl_Label1_32 = new System.Windows.Forms.Label();
			_lbl_Label1_31 = new System.Windows.Forms.Label();
			_lbl_Label1_30 = new System.Windows.Forms.Label();
			_lbl_Label1_29 = new System.Windows.Forms.Label();
			pnl_aircraft_info = new System.Windows.Forms.Panel();
			cbo_cert_drop = new System.Windows.Forms.ComboBox();
			chk_inactives = new System.Windows.Forms.CheckBox();
			chk_primary = new System.Windows.Forms.CheckBox();
			chk_show_yacht_count = new System.Windows.Forms.CheckBox();
			chk_hide_zero = new System.Windows.Forms.CheckBox();
			chk_OR = new System.Windows.Forms.CheckBox();
			_txt_ac_value_1 = new System.Windows.Forms.TextBox();
			_cbo_compare_1 = new System.Windows.Forms.ComboBox();
			_cbo_owner_type_1 = new System.Windows.Forms.ComboBox();
			_cbo_product_1 = new System.Windows.Forms.ComboBox();
			_cbo_product_0 = new System.Windows.Forms.ComboBox();
			chk_share_relationships_withoutAC = new System.Windows.Forms.CheckBox();
			chk_share_relationships = new System.Windows.Forms.CheckBox();
			chk_aircraft_count = new System.Windows.Forms.CheckBox();
			_cbo_owner_type_0 = new System.Windows.Forms.ComboBox();
			_cbo_compare_0 = new System.Windows.Forms.ComboBox();
			_txt_ac_value_0 = new System.Windows.Forms.TextBox();
			_lbl_Label1_12 = new System.Windows.Forms.Label();
			_lbl_Label1_13 = new System.Windows.Forms.Label();
			_lbl_Label1_14 = new System.Windows.Forms.Label();
			pnl_contact = new System.Windows.Forms.Panel();
			lst_title_group = new System.Windows.Forms.ListBox();
			cbo_contact_title = new System.Windows.Forms.ComboBox();
			txt_contact_email_address = new System.Windows.Forms.TextBox();
			txt_pnum_number_full = new System.Windows.Forms.TextBox();
			txt_contact_first_name = new System.Windows.Forms.TextBox();
			txt_contact_last_name = new System.Windows.Forms.TextBox();
			_lbl_Label1_20 = new System.Windows.Forms.Label();
			_lbl_Label1_17 = new System.Windows.Forms.Label();
			_lbl_Label1_19 = new System.Windows.Forms.Label();
			_lbl_Label1_18 = new System.Windows.Forms.Label();
			_lbl_Label1_16 = new System.Windows.Forms.Label();
			_lbl_Label1_15 = new System.Windows.Forms.Label();
			pnl_company = new System.Windows.Forms.Panel();
			txt_airport_id_name = new System.Windows.Forms.TextBox();
			txt_cert_search = new System.Windows.Forms.TextBox();
			chkCompContactAddressFlag = new System.Windows.Forms.CheckBox();
			dba_check = new System.Windows.Forms.CheckBox();
			_txt_company_id_1 = new System.Windows.Forms.TextBox();
			txt_comp_name = new System.Windows.Forms.TextBox();
			cbo_business_type = new System.Windows.Forms.ComboBox();
			cbo_account_rep = new System.Windows.Forms.ComboBox();
			cmd_Add_Company = new System.Windows.Forms.Button();
			cmd_AcPros = new System.Windows.Forms.Button();
			chk_ACPros = new System.Windows.Forms.CheckBox();
			txt_comp_phone = new System.Windows.Forms.TextBox();
			txt_comp_email = new System.Windows.Forms.TextBox();
			_txt_company_id_0 = new System.Windows.Forms.TextBox();
			txt_comp_web_address = new System.Windows.Forms.TextBox();
			cbo_agency_type = new System.Windows.Forms.ComboBox();
			txt_comp_address = new System.Windows.Forms.TextBox();
			_lbl_Label1_36 = new System.Windows.Forms.Label();
			_lbl_Label1_35 = new System.Windows.Forms.Label();
			lbl_dba = new System.Windows.Forms.Label();
			_lbl_Label1_34 = new System.Windows.Forms.Label();
			_lbl_Label1_4 = new System.Windows.Forms.Label();
			_lbl_Label1_3 = new System.Windows.Forms.Label();
			_lbl_Label1_6 = new System.Windows.Forms.Label();
			_lbl_Label1_7 = new System.Windows.Forms.Label();
			_lbl_Label1_21 = new System.Windows.Forms.Label();
			_lbl_Label1_5 = new System.Windows.Forms.Label();
			_lbl_Label1_2 = new System.Windows.Forms.Label();
			_lbl_Label1_0 = new System.Windows.Forms.Label();
			_lbl_Label1_1 = new System.Windows.Forms.Label();
			lbl_List = new System.Windows.Forms.Label();
			ln_line1 = new System.Windows.Forms.Label();
			tbr_ToolBar.SuspendLayout();
			pnl_prod_code.SuspendLayout();
			frmCustomers.SuspendLayout();
			pnl_company_demographics.SuspendLayout();
			pnl_search.SuspendLayout();
			pnl_wait_text.SuspendLayout();
			pnl_display_results.SuspendLayout();
			pnl_company_relationships.SuspendLayout();
			pnl_contact_info.SuspendLayout();
			frame_awaiting_documentation.SuspendLayout();
			pnl_associate_aircraft.SuspendLayout();
			pnl_duplicates.SuspendLayout();
			pnl_company_info.SuspendLayout();
			pnl_search_results.SuspendLayout();
			frame_potential_dups_grid.SuspendLayout();
			frame_potential_dups.SuspendLayout();
			pnl_aircraft_info.SuspendLayout();
			pnl_contact.SuspendLayout();
			pnl_company.SuspendLayout();
			SuspendLayout();
			listBoxComboBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListControlHelper(components);
			((System.ComponentModel.ISupportInitialize) listBoxComboBoxHelper1).BeginInit();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_find_company).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_potential_duplicates).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFile, mnuEdit, mnuView, mnuReport, mnuTools});
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
			mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuEditBadListDates, mnuEditRemoveDupPhones});
			// 
			// mnuEditBadListDates
			// 
			mnuEditBadListDates.Available = true;
			mnuEditBadListDates.Checked = false;
			mnuEditBadListDates.Enabled = false;
			mnuEditBadListDates.Name = "mnuEditBadListDates";
			mnuEditBadListDates.Text = "Find List Date Problem";
			// 
			// mnuEditRemoveDupPhones
			// 
			mnuEditRemoveDupPhones.Available = true;
			mnuEditRemoveDupPhones.Checked = false;
			mnuEditRemoveDupPhones.Enabled = false;
			mnuEditRemoveDupPhones.Name = "mnuEditRemoveDupPhones";
			mnuEditRemoveDupPhones.Text = "Remove Duplicate Company Phone Numbers";
			mnuEditRemoveDupPhones.Click += new System.EventHandler(mnuEditRemoveDupPhones_Click);
			// 
			// mnuView
			// 
			mnuView.Available = true;
			mnuView.Checked = false;
			mnuView.Enabled = true;
			mnuView.Name = "mnuView";
			mnuView.Text = "&View";
			mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuViewDups20, mnuUnHideDupGrid, mnuFortune});
			// 
			// mnuViewDups20
			// 
			mnuViewDups20.Available = true;
			mnuViewDups20.Checked = false;
			mnuViewDups20.Enabled = true;
			mnuViewDups20.Name = "mnuViewDups20";
			mnuViewDups20.Text = "Potential Duplicates";
			mnuViewDups20.Click += new System.EventHandler(mnuViewDups20_Click);
			// 
			// mnuUnHideDupGrid
			// 
			mnuUnHideDupGrid.Available = false;
			mnuUnHideDupGrid.Checked = false;
			mnuUnHideDupGrid.Enabled = true;
			mnuUnHideDupGrid.Name = "mnuUnHideDupGrid";
			mnuUnHideDupGrid.Text = "UnHide Potential Duplicate Grid";
			mnuUnHideDupGrid.Click += new System.EventHandler(mnuUnHideDupGrid_Click);
			// 
			// mnuFortune
			// 
			mnuFortune.Available = true;
			mnuFortune.Checked = false;
			mnuFortune.Enabled = true;
			mnuFortune.Name = "mnuFortune";
			mnuFortune.Text = "Fortune 1000";
			// 
			// mnuReport
			// 
			mnuReport.Available = true;
			mnuReport.Checked = false;
			mnuReport.Enabled = true;
			mnuReport.Name = "mnuReport";
			mnuReport.Text = "&Report";
			mnuReport.Click += new System.EventHandler(mnureport_Click);
			// 
			// mnuTools
			// 
			mnuTools.Available = true;
			mnuTools.Checked = false;
			mnuTools.Enabled = true;
			mnuTools.Name = "mnuTools";
			mnuTools.Text = "&Tools";
			mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFindCompanyShowUserHistory});
			// 
			// mnuFindCompanyShowUserHistory
			// 
			mnuFindCompanyShowUserHistory.Available = true;
			mnuFindCompanyShowUserHistory.Checked = false;
			mnuFindCompanyShowUserHistory.Enabled = true;
			mnuFindCompanyShowUserHistory.Name = "mnuFindCompanyShowUserHistory";
			mnuFindCompanyShowUserHistory.Text = "Show User History";
			mnuFindCompanyShowUserHistory.Click += new System.EventHandler(mnuFindCompanyShowUserHistory_Click);
			// 
			// tbr_ToolBar
			// 
			tbr_ToolBar.AllowDrop = true;
			tbr_ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
			tbr_ToolBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tbr_ToolBar.Location = new System.Drawing.Point(0, 24);
			tbr_ToolBar.Name = "tbr_ToolBar";
			tbr_ToolBar.ShowItemToolTips = true;
			tbr_ToolBar.Size = new System.Drawing.Size(1000, 26);
			tbr_ToolBar.TabIndex = 1;
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
			// pnl_prod_code
			// 
			pnl_prod_code.AllowDrop = true;
			pnl_prod_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_prod_code.Controls.Add(frmCustomers);
			pnl_prod_code.Controls.Add(_chk_prod_code_3);
			pnl_prod_code.Controls.Add(_chk_prod_code_2);
			pnl_prod_code.Controls.Add(_chk_prod_code_1);
			pnl_prod_code.Controls.Add(_chk_prod_code_0);
			pnl_prod_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_prod_code.Location = new System.Drawing.Point(840, 168);
			pnl_prod_code.Name = "pnl_prod_code";
			pnl_prod_code.Size = new System.Drawing.Size(157, 89);
			pnl_prod_code.TabIndex = 155;
			// 
			// frmCustomers
			// 
			frmCustomers.AllowDrop = true;
			frmCustomers.BackColor = System.Drawing.SystemColors.Control;
			frmCustomers.Controls.Add(_optSearchCust_0);
			frmCustomers.Controls.Add(_optSearchCust_1);
			frmCustomers.Controls.Add(_optSearchCust_2);
			frmCustomers.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmCustomers.Enabled = true;
			frmCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmCustomers.ForeColor = System.Drawing.SystemColors.ControlText;
			frmCustomers.Location = new System.Drawing.Point(4, 50);
			frmCustomers.Name = "frmCustomers";
			frmCustomers.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmCustomers.Size = new System.Drawing.Size(149, 31);
			frmCustomers.TabIndex = 166;
			frmCustomers.Text = "Customers";
			frmCustomers.Visible = true;
			// 
			// _optSearchCust_0
			// 
			_optSearchCust_0.AllowDrop = true;
			_optSearchCust_0.BackColor = System.Drawing.SystemColors.Control;
			_optSearchCust_0.CausesValidation = true;
			_optSearchCust_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optSearchCust_0.Checked = true;
			_optSearchCust_0.Enabled = true;
			_optSearchCust_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_optSearchCust_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_optSearchCust_0.Location = new System.Drawing.Point(10, 14);
			_optSearchCust_0.Name = "_optSearchCust_0";
			_optSearchCust_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_optSearchCust_0.Size = new System.Drawing.Size(37, 13);
			_optSearchCust_0.TabIndex = 160;
			_optSearchCust_0.TabStop = true;
			_optSearchCust_0.Text = "All";
			_optSearchCust_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optSearchCust_0.Visible = true;
			// 
			// _optSearchCust_1
			// 
			_optSearchCust_1.AllowDrop = true;
			_optSearchCust_1.BackColor = System.Drawing.SystemColors.Control;
			_optSearchCust_1.CausesValidation = true;
			_optSearchCust_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optSearchCust_1.Checked = false;
			_optSearchCust_1.Enabled = true;
			_optSearchCust_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_optSearchCust_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_optSearchCust_1.Location = new System.Drawing.Point(54, 14);
			_optSearchCust_1.Name = "_optSearchCust_1";
			_optSearchCust_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_optSearchCust_1.Size = new System.Drawing.Size(41, 13);
			_optSearchCust_1.TabIndex = 161;
			_optSearchCust_1.TabStop = true;
			_optSearchCust_1.Text = "Yes";
			_optSearchCust_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optSearchCust_1.Visible = true;
			// 
			// _optSearchCust_2
			// 
			_optSearchCust_2.AllowDrop = true;
			_optSearchCust_2.BackColor = System.Drawing.SystemColors.Control;
			_optSearchCust_2.CausesValidation = true;
			_optSearchCust_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optSearchCust_2.Checked = false;
			_optSearchCust_2.Enabled = true;
			_optSearchCust_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_optSearchCust_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_optSearchCust_2.Location = new System.Drawing.Point(106, 14);
			_optSearchCust_2.Name = "_optSearchCust_2";
			_optSearchCust_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_optSearchCust_2.Size = new System.Drawing.Size(41, 13);
			_optSearchCust_2.TabIndex = 162;
			_optSearchCust_2.TabStop = true;
			_optSearchCust_2.Text = "No";
			_optSearchCust_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optSearchCust_2.Visible = true;
			// 
			// _chk_prod_code_3
			// 
			_chk_prod_code_3.AllowDrop = true;
			_chk_prod_code_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_prod_code_3.BackColor = System.Drawing.SystemColors.Control;
			_chk_prod_code_3.CausesValidation = true;
			_chk_prod_code_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_prod_code_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_prod_code_3.Enabled = true;
			_chk_prod_code_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_prod_code_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_prod_code_3.Location = new System.Drawing.Point(78, 8);
			_chk_prod_code_3.Name = "_chk_prod_code_3";
			_chk_prod_code_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_prod_code_3.Size = new System.Drawing.Size(55, 17);
			_chk_prod_code_3.TabIndex = 157;
			_chk_prod_code_3.TabStop = true;
			_chk_prod_code_3.Text = "Yacht";
			_chk_prod_code_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_prod_code_3.Visible = true;
			_chk_prod_code_3.CheckStateChanged += new System.EventHandler(chk_prod_code_CheckStateChanged);
			// 
			// _chk_prod_code_2
			// 
			_chk_prod_code_2.AllowDrop = true;
			_chk_prod_code_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_prod_code_2.BackColor = System.Drawing.SystemColors.Control;
			_chk_prod_code_2.CausesValidation = true;
			_chk_prod_code_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_prod_code_2.CheckState = System.Windows.Forms.CheckState.Checked;
			_chk_prod_code_2.Enabled = true;
			_chk_prod_code_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_prod_code_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_prod_code_2.Location = new System.Drawing.Point(78, 32);
			_chk_prod_code_2.Name = "_chk_prod_code_2";
			_chk_prod_code_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_prod_code_2.Size = new System.Drawing.Size(75, 17);
			_chk_prod_code_2.TabIndex = 159;
			_chk_prod_code_2.TabStop = true;
			_chk_prod_code_2.Text = "Commercial";
			_chk_prod_code_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_prod_code_2.Visible = true;
			_chk_prod_code_2.CheckStateChanged += new System.EventHandler(chk_prod_code_CheckStateChanged);
			// 
			// _chk_prod_code_1
			// 
			_chk_prod_code_1.AllowDrop = true;
			_chk_prod_code_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_prod_code_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_prod_code_1.CausesValidation = true;
			_chk_prod_code_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_prod_code_1.CheckState = System.Windows.Forms.CheckState.Checked;
			_chk_prod_code_1.Enabled = true;
			_chk_prod_code_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_prod_code_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_prod_code_1.Location = new System.Drawing.Point(6, 27);
			_chk_prod_code_1.Name = "_chk_prod_code_1";
			_chk_prod_code_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_prod_code_1.Size = new System.Drawing.Size(69, 17);
			_chk_prod_code_1.TabIndex = 158;
			_chk_prod_code_1.TabStop = true;
			_chk_prod_code_1.Text = "Helicopter";
			_chk_prod_code_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_prod_code_1.Visible = true;
			_chk_prod_code_1.CheckStateChanged += new System.EventHandler(chk_prod_code_CheckStateChanged);
			// 
			// _chk_prod_code_0
			// 
			_chk_prod_code_0.AllowDrop = true;
			_chk_prod_code_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_prod_code_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_prod_code_0.CausesValidation = true;
			_chk_prod_code_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_prod_code_0.CheckState = System.Windows.Forms.CheckState.Checked;
			_chk_prod_code_0.Enabled = true;
			_chk_prod_code_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_prod_code_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_prod_code_0.Location = new System.Drawing.Point(6, 8);
			_chk_prod_code_0.Name = "_chk_prod_code_0";
			_chk_prod_code_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_prod_code_0.Size = new System.Drawing.Size(65, 17);
			_chk_prod_code_0.TabIndex = 156;
			_chk_prod_code_0.TabStop = true;
			_chk_prod_code_0.Text = "Business";
			_chk_prod_code_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_prod_code_0.Visible = true;
			_chk_prod_code_0.CheckStateChanged += new System.EventHandler(chk_prod_code_CheckStateChanged);
			// 
			// cbo_MailList
			// 
			cbo_MailList.AllowDrop = true;
			cbo_MailList.BackColor = System.Drawing.SystemColors.Window;
			cbo_MailList.CausesValidation = true;
			cbo_MailList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_MailList.Enabled = true;
			cbo_MailList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_MailList.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_MailList.IntegralHeight = true;
			cbo_MailList.Location = new System.Drawing.Point(600, 232);
			cbo_MailList.Name = "cbo_MailList";
			cbo_MailList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_MailList.Size = new System.Drawing.Size(233, 21);
			cbo_MailList.Sorted = false;
			cbo_MailList.TabIndex = 149;
			cbo_MailList.TabStop = true;
			cbo_MailList.Visible = true;
			// 
			// pnl_company_demographics
			// 
			pnl_company_demographics.AllowDrop = true;
			pnl_company_demographics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_company_demographics.Controls.Add(_pic_redx_3);
			pnl_company_demographics.Controls.Add(_pic_redx_2);
			pnl_company_demographics.Controls.Add(_pic_redx_1);
			pnl_company_demographics.Controls.Add(lst_country);
			pnl_company_demographics.Controls.Add(txt_comp_city);
			pnl_company_demographics.Controls.Add(txt_comp_zip_code);
			pnl_company_demographics.Controls.Add(_opt_continent_region_0);
			pnl_company_demographics.Controls.Add(_opt_continent_region_1);
			pnl_company_demographics.Controls.Add(lst_state);
			pnl_company_demographics.Controls.Add(lst_area);
			pnl_company_demographics.Controls.Add(_lbl_Label1_8);
			pnl_company_demographics.Controls.Add(_lbl_Label1_11);
			pnl_company_demographics.Controls.Add(_lbl_Label1_10);
			pnl_company_demographics.Controls.Add(_lbl_Label1_9);
			pnl_company_demographics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_company_demographics.Location = new System.Drawing.Point(0, 187);
			pnl_company_demographics.Name = "pnl_company_demographics";
			pnl_company_demographics.Size = new System.Drawing.Size(573, 73);
			pnl_company_demographics.TabIndex = 62;
			// 
			// _pic_redx_3
			// 
			_pic_redx_3.AllowDrop = true;
			_pic_redx_3.BackColor = System.Drawing.SystemColors.Control;
			_pic_redx_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_pic_redx_3.CausesValidation = true;
			_pic_redx_3.Dock = System.Windows.Forms.DockStyle.None;
			_pic_redx_3.Enabled = true;
			_pic_redx_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_redx_3.Image = (System.Drawing.Image) resources.GetObject("_pic_redx_3.Image");
			_pic_redx_3.Location = new System.Drawing.Point(504, 5);
			_pic_redx_3.Name = "_pic_redx_3";
			_pic_redx_3.Size = new System.Drawing.Size(29, 25);
			_pic_redx_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_redx_3.TabIndex = 154;
			_pic_redx_3.TabStop = true;
			_pic_redx_3.Visible = false;
			// 
			// _pic_redx_2
			// 
			_pic_redx_2.AllowDrop = true;
			_pic_redx_2.BackColor = System.Drawing.SystemColors.Control;
			_pic_redx_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_pic_redx_2.CausesValidation = true;
			_pic_redx_2.Dock = System.Windows.Forms.DockStyle.None;
			_pic_redx_2.Enabled = true;
			_pic_redx_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_redx_2.Image = (System.Drawing.Image) resources.GetObject("_pic_redx_2.Image");
			_pic_redx_2.Location = new System.Drawing.Point(504, 5);
			_pic_redx_2.Name = "_pic_redx_2";
			_pic_redx_2.Size = new System.Drawing.Size(29, 25);
			_pic_redx_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_redx_2.TabIndex = 153;
			_pic_redx_2.TabStop = true;
			_pic_redx_2.Visible = false;
			// 
			// compTimer1
			// 
			compTimer1.Enabled = false;
			compTimer1.Interval = 1;
			compTimer1.Tick += new System.EventHandler(compTimer1_Tick);
			// 
			// _pic_redx_1
			// 
			_pic_redx_1.AllowDrop = true;
			_pic_redx_1.BackColor = System.Drawing.SystemColors.Control;
			_pic_redx_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_pic_redx_1.CausesValidation = true;
			_pic_redx_1.Dock = System.Windows.Forms.DockStyle.None;
			_pic_redx_1.Enabled = true;
			_pic_redx_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_redx_1.Image = (System.Drawing.Image) resources.GetObject("_pic_redx_1.Image");
			_pic_redx_1.Location = new System.Drawing.Point(504, 5);
			_pic_redx_1.Name = "_pic_redx_1";
			_pic_redx_1.Size = new System.Drawing.Size(29, 25);
			_pic_redx_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_redx_1.TabIndex = 152;
			_pic_redx_1.TabStop = true;
			_pic_redx_1.Visible = false;
			// 
			// lst_country
			// 
			lst_country.AllowDrop = true;
			lst_country.BackColor = System.Drawing.SystemColors.Window;
			lst_country.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_country.CausesValidation = true;
			lst_country.Enabled = true;
			lst_country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_country.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_country.IntegralHeight = true;
			lst_country.Location = new System.Drawing.Point(141, 15);
			lst_country.MultiColumn = false;
			lst_country.Name = "lst_country";
			lst_country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_country.Size = new System.Drawing.Size(127, 57);
			lst_country.Sorted = false;
			lst_country.TabIndex = 72;
			lst_country.TabStop = true;
			lst_country.Visible = true;
			lst_country.SelectedIndexChanged += new System.EventHandler(lst_Country_SelectedIndexChanged);
			// 
			// txt_comp_city
			// 
			txt_comp_city.AcceptsReturn = true;
			txt_comp_city.AllowDrop = true;
			txt_comp_city.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_city.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_city.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_city.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_city.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_city.Location = new System.Drawing.Point(427, 50);
			txt_comp_city.MaxLength = 0;
			txt_comp_city.Name = "txt_comp_city";
			txt_comp_city.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_city.Size = new System.Drawing.Size(142, 19);
			txt_comp_city.TabIndex = 68;
			txt_comp_city.TabStop = false;
			// 
			// txt_comp_zip_code
			// 
			txt_comp_zip_code.AcceptsReturn = true;
			txt_comp_zip_code.AllowDrop = true;
			txt_comp_zip_code.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_zip_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_zip_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_zip_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_zip_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_zip_code.Location = new System.Drawing.Point(424, 18);
			txt_comp_zip_code.MaxLength = 0;
			txt_comp_zip_code.Name = "txt_comp_zip_code";
			txt_comp_zip_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_zip_code.Size = new System.Drawing.Size(73, 19);
			txt_comp_zip_code.TabIndex = 67;
			txt_comp_zip_code.TabStop = false;
			// 
			// _opt_continent_region_0
			// 
			_opt_continent_region_0.AllowDrop = true;
			_opt_continent_region_0.BackColor = System.Drawing.SystemColors.Control;
			_opt_continent_region_0.CausesValidation = true;
			_opt_continent_region_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_continent_region_0.Checked = false;
			_opt_continent_region_0.Enabled = true;
			_opt_continent_region_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_continent_region_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_continent_region_0.Location = new System.Drawing.Point(4, 1);
			_opt_continent_region_0.Name = "_opt_continent_region_0";
			_opt_continent_region_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_continent_region_0.Size = new System.Drawing.Size(68, 13);
			_opt_continent_region_0.TabIndex = 66;
			_opt_continent_region_0.TabStop = true;
			_opt_continent_region_0.Text = "Continent";
			_opt_continent_region_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_continent_region_0.Visible = true;
			_opt_continent_region_0.CheckedChanged += new System.EventHandler(opt_continent_region_CheckedChanged);
			// 
			// _opt_continent_region_1
			// 
			_opt_continent_region_1.AllowDrop = true;
			_opt_continent_region_1.BackColor = System.Drawing.SystemColors.Control;
			_opt_continent_region_1.CausesValidation = true;
			_opt_continent_region_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_continent_region_1.Checked = false;
			_opt_continent_region_1.Enabled = true;
			_opt_continent_region_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_continent_region_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_continent_region_1.Location = new System.Drawing.Point(71, 1);
			_opt_continent_region_1.Name = "_opt_continent_region_1";
			_opt_continent_region_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_continent_region_1.Size = new System.Drawing.Size(68, 13);
			_opt_continent_region_1.TabIndex = 65;
			_opt_continent_region_1.TabStop = true;
			_opt_continent_region_1.Text = "Region";
			_opt_continent_region_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_continent_region_1.Visible = true;
			_opt_continent_region_1.CheckedChanged += new System.EventHandler(opt_continent_region_CheckedChanged);
			// 
			// lst_state
			// 
			lst_state.AllowDrop = true;
			lst_state.BackColor = System.Drawing.SystemColors.Window;
			lst_state.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_state.CausesValidation = true;
			lst_state.Enabled = true;
			lst_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_state.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_state.IntegralHeight = true;
			lst_state.Location = new System.Drawing.Point(271, 15);
			lst_state.MultiColumn = false;
			lst_state.Name = "lst_state";
			lst_state.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_state.Size = new System.Drawing.Size(153, 57);
			lst_state.Sorted = false;
			lst_state.TabIndex = 64;
			lst_state.TabStop = true;
			lst_state.Visible = true;
			// 
			// lst_area
			// 
			lst_area.AllowDrop = true;
			lst_area.BackColor = System.Drawing.SystemColors.Window;
			lst_area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_area.CausesValidation = true;
			lst_area.Enabled = true;
			lst_area.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_area.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_area.IntegralHeight = true;
			lst_area.Location = new System.Drawing.Point(0, 16);
			lst_area.MultiColumn = false;
			lst_area.Name = "lst_area";
			lst_area.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_area.Size = new System.Drawing.Size(135, 57);
			lst_area.Sorted = false;
			lst_area.TabIndex = 63;
			lst_area.TabStop = true;
			lst_area.Visible = true;
			lst_area.SelectedIndexChanged += new System.EventHandler(lst_Area_SelectedIndexChanged);
			// 
			// _lbl_Label1_8
			// 
			_lbl_Label1_8.AllowDrop = true;
			_lbl_Label1_8.AutoSize = true;
			_lbl_Label1_8.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_8.Location = new System.Drawing.Point(141, 1);
			_lbl_Label1_8.MinimumSize = new System.Drawing.Size(39, 13);
			_lbl_Label1_8.Name = "_lbl_Label1_8";
			_lbl_Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_8.Size = new System.Drawing.Size(39, 13);
			_lbl_Label1_8.TabIndex = 73;
			_lbl_Label1_8.Text = "Country:";
			// 
			// _lbl_Label1_11
			// 
			_lbl_Label1_11.AllowDrop = true;
			_lbl_Label1_11.AutoSize = true;
			_lbl_Label1_11.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_11.Location = new System.Drawing.Point(427, 36);
			_lbl_Label1_11.MinimumSize = new System.Drawing.Size(20, 13);
			_lbl_Label1_11.Name = "_lbl_Label1_11";
			_lbl_Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_11.Size = new System.Drawing.Size(20, 13);
			_lbl_Label1_11.TabIndex = 71;
			_lbl_Label1_11.Text = "City:";
			// 
			// _lbl_Label1_10
			// 
			_lbl_Label1_10.AllowDrop = true;
			_lbl_Label1_10.AutoSize = true;
			_lbl_Label1_10.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_10.Location = new System.Drawing.Point(427, 5);
			_lbl_Label1_10.MinimumSize = new System.Drawing.Size(60, 13);
			_lbl_Label1_10.Name = "_lbl_Label1_10";
			_lbl_Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_10.Size = new System.Drawing.Size(60, 13);
			_lbl_Label1_10.TabIndex = 70;
			_lbl_Label1_10.Text = "Postal Code:";
			// 
			// _lbl_Label1_9
			// 
			_lbl_Label1_9.AllowDrop = true;
			_lbl_Label1_9.AutoSize = true;
			_lbl_Label1_9.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_9.Location = new System.Drawing.Point(376, 1);
			_lbl_Label1_9.MinimumSize = new System.Drawing.Size(28, 13);
			_lbl_Label1_9.Name = "_lbl_Label1_9";
			_lbl_Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_9.Size = new System.Drawing.Size(28, 13);
			_lbl_Label1_9.TabIndex = 69;
			_lbl_Label1_9.Text = "State:";
			// 
			// pnl_search
			// 
			pnl_search.AllowDrop = true;
			pnl_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_search.Controls.Add(chkIncludeServices);
			pnl_search.Controls.Add(cmd_Find);
			pnl_search.Controls.Add(opt_companies);
			pnl_search.Controls.Add(opt_contacts);
			pnl_search.Controls.Add(cmd_Clear);
			pnl_search.Controls.Add(chk_history);
			pnl_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_search.Location = new System.Drawing.Point(840, 53);
			pnl_search.Name = "pnl_search";
			pnl_search.Size = new System.Drawing.Size(157, 116);
			pnl_search.TabIndex = 25;
			// 
			// chkIncludeServices
			// 
			chkIncludeServices.AllowDrop = true;
			chkIncludeServices.Appearance = System.Windows.Forms.Appearance.Normal;
			chkIncludeServices.BackColor = System.Drawing.SystemColors.Control;
			chkIncludeServices.CausesValidation = true;
			chkIncludeServices.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIncludeServices.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkIncludeServices.Enabled = true;
			chkIncludeServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkIncludeServices.ForeColor = System.Drawing.SystemColors.ControlText;
			chkIncludeServices.Location = new System.Drawing.Point(13, 76);
			chkIncludeServices.Name = "chkIncludeServices";
			chkIncludeServices.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkIncludeServices.Size = new System.Drawing.Size(128, 17);
			chkIncludeServices.TabIndex = 27;
			chkIncludeServices.TabStop = true;
			chkIncludeServices.Text = "Include Services Used";
			chkIncludeServices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIncludeServices.Visible = true;
			// 
			// cmd_Find
			// 
			cmd_Find.AllowDrop = true;
			cmd_Find.BackColor = System.Drawing.SystemColors.Control;
			cmd_Find.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Find.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Find.Location = new System.Drawing.Point(8, 16);
			cmd_Find.Name = "cmd_Find";
			cmd_Find.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Find.Size = new System.Drawing.Size(141, 22);
			cmd_Find.TabIndex = 31;
			cmd_Find.Text = "&Find Now";
			cmd_Find.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Find.UseVisualStyleBackColor = false;
			cmd_Find.Click += new System.EventHandler(cmd_find_Click);
			// 
			// opt_companies
			// 
			opt_companies.AllowDrop = true;
			opt_companies.BackColor = System.Drawing.SystemColors.Control;
			opt_companies.CausesValidation = true;
			opt_companies.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_companies.Checked = true;
			opt_companies.Enabled = true;
			opt_companies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_companies.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_companies.Location = new System.Drawing.Point(9, 40);
			opt_companies.Name = "opt_companies";
			opt_companies.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_companies.Size = new System.Drawing.Size(73, 23);
			opt_companies.TabIndex = 30;
			opt_companies.TabStop = true;
			opt_companies.Text = "Companies";
			opt_companies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_companies.Visible = true;
			opt_companies.CheckedChanged += new System.EventHandler(opt_Companies_CheckedChanged);
			// 
			// opt_contacts
			// 
			opt_contacts.AllowDrop = true;
			opt_contacts.BackColor = System.Drawing.SystemColors.Control;
			opt_contacts.CausesValidation = true;
			opt_contacts.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_contacts.Checked = false;
			opt_contacts.Enabled = true;
			opt_contacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_contacts.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_contacts.Location = new System.Drawing.Point(86, 38);
			opt_contacts.Name = "opt_contacts";
			opt_contacts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_contacts.Size = new System.Drawing.Size(63, 23);
			opt_contacts.TabIndex = 29;
			opt_contacts.TabStop = true;
			opt_contacts.Text = "Contacts";
			opt_contacts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_contacts.Visible = true;
			opt_contacts.CheckedChanged += new System.EventHandler(opt_contacts_CheckedChanged);
			// 
			// cmd_Clear
			// 
			cmd_Clear.AllowDrop = true;
			cmd_Clear.BackColor = System.Drawing.SystemColors.Control;
			cmd_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Clear.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Clear.Location = new System.Drawing.Point(8, 92);
			cmd_Clear.Name = "cmd_Clear";
			cmd_Clear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Clear.Size = new System.Drawing.Size(141, 22);
			cmd_Clear.TabIndex = 28;
			cmd_Clear.Text = "Clear &Search Criteria";
			cmd_Clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Clear.UseVisualStyleBackColor = false;
			cmd_Clear.Click += new System.EventHandler(cmd_Clear_Click);
			// 
			// chk_history
			// 
			chk_history.AllowDrop = true;
			chk_history.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_history.BackColor = System.Drawing.SystemColors.Control;
			chk_history.CausesValidation = true;
			chk_history.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_history.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_history.Enabled = true;
			chk_history.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_history.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_history.Location = new System.Drawing.Point(13, 60);
			chk_history.Name = "chk_history";
			chk_history.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_history.Size = new System.Drawing.Size(128, 17);
			chk_history.TabIndex = 26;
			chk_history.TabStop = true;
			chk_history.Text = "Include Archived &Data";
			chk_history.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_history.Visible = true;
			chk_history.CheckStateChanged += new System.EventHandler(chk_history_CheckStateChanged);
			// 
			// pnl_wait_text
			// 
			pnl_wait_text.AllowDrop = true;
			pnl_wait_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_wait_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_wait_text.Controls.Add(_lbl_Label1_28);
			pnl_wait_text.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_wait_text.ForeColor = System.Drawing.Color.Black;
			pnl_wait_text.Location = new System.Drawing.Point(242, 303);
			pnl_wait_text.Name = "pnl_wait_text";
			pnl_wait_text.Size = new System.Drawing.Size(521, 120);
			pnl_wait_text.TabIndex = 74;
			pnl_wait_text.Visible = false;
			// 
			// _lbl_Label1_28
			// 
			_lbl_Label1_28.AllowDrop = true;
			_lbl_Label1_28.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_28.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_28.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_28.ForeColor = System.Drawing.Color.Maroon;
			_lbl_Label1_28.Location = new System.Drawing.Point(187, 61);
			_lbl_Label1_28.MinimumSize = new System.Drawing.Size(153, 27);
			_lbl_Label1_28.Name = "_lbl_Label1_28";
			_lbl_Label1_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_28.Size = new System.Drawing.Size(153, 27);
			_lbl_Label1_28.TabIndex = 75;
			_lbl_Label1_28.Text = "PLEASE WAIT!";
			_lbl_Label1_28.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pnl_display_results
			// 
			pnl_display_results.AllowDrop = true;
			pnl_display_results.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_display_results.Controls.Add(pnl_company_relationships);
			pnl_display_results.Controls.Add(pnl_contact_info);
			pnl_display_results.Controls.Add(frame_awaiting_documentation);
			pnl_display_results.Controls.Add(pnl_associate_aircraft);
			pnl_display_results.Controls.Add(pnl_duplicates);
			pnl_display_results.Controls.Add(pnl_company_info);
			pnl_display_results.Controls.Add(pnl_search_results);
			pnl_display_results.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_display_results.Location = new System.Drawing.Point(0, 262);
			pnl_display_results.Name = "pnl_display_results";
			pnl_display_results.Size = new System.Drawing.Size(1000, 419);
			pnl_display_results.TabIndex = 76;
			// 
			// pnl_company_relationships
			// 
			pnl_company_relationships.AllowDrop = true;
			pnl_company_relationships.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_company_relationships.Controls.Add(chkCompRelHide);
			pnl_company_relationships.Controls.Add(cbo_contact2);
			pnl_company_relationships.Controls.Add(cbo_contact);
			pnl_company_relationships.Controls.Add(lst_company2);
			pnl_company_relationships.Controls.Add(lst_company1);
			pnl_company_relationships.Controls.Add(cbo_relationship);
			pnl_company_relationships.Controls.Add(_lbl_Label1_27);
			pnl_company_relationships.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_company_relationships.Location = new System.Drawing.Point(272, 256);
			pnl_company_relationships.Name = "pnl_company_relationships";
			pnl_company_relationships.Size = new System.Drawing.Size(723, 162);
			pnl_company_relationships.TabIndex = 106;
			pnl_company_relationships.Visible = false;
			// 
			// chkCompRelHide
			// 
			chkCompRelHide.AllowDrop = true;
			chkCompRelHide.Appearance = System.Windows.Forms.Appearance.Normal;
			chkCompRelHide.BackColor = System.Drawing.SystemColors.Control;
			chkCompRelHide.CausesValidation = true;
			chkCompRelHide.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCompRelHide.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkCompRelHide.Enabled = true;
			chkCompRelHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkCompRelHide.ForeColor = System.Drawing.SystemColors.ControlText;
			chkCompRelHide.Location = new System.Drawing.Point(10, 30);
			chkCompRelHide.Name = "chkCompRelHide";
			chkCompRelHide.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkCompRelHide.Size = new System.Drawing.Size(127, 17);
			chkCompRelHide.TabIndex = 108;
			chkCompRelHide.TabStop = true;
			chkCompRelHide.Text = "Hide Relationship";
			chkCompRelHide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCompRelHide.Visible = true;
			// 
			// cbo_contact2
			// 
			cbo_contact2.AllowDrop = true;
			cbo_contact2.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact2.CausesValidation = true;
			cbo_contact2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_contact2.Enabled = true;
			cbo_contact2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact2.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact2.IntegralHeight = true;
			cbo_contact2.Location = new System.Drawing.Point(369, 134);
			cbo_contact2.Name = "cbo_contact2";
			cbo_contact2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact2.Size = new System.Drawing.Size(218, 21);
			cbo_contact2.Sorted = false;
			cbo_contact2.TabIndex = 112;
			cbo_contact2.TabStop = true;
			cbo_contact2.Visible = true;
			// 
			// cbo_contact
			// 
			cbo_contact.AllowDrop = true;
			cbo_contact.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact.CausesValidation = true;
			cbo_contact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_contact.Enabled = true;
			cbo_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact.IntegralHeight = true;
			cbo_contact.Location = new System.Drawing.Point(24, 136);
			cbo_contact.Name = "cbo_contact";
			cbo_contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact.Size = new System.Drawing.Size(218, 21);
			cbo_contact.Sorted = false;
			cbo_contact.TabIndex = 111;
			cbo_contact.TabStop = true;
			cbo_contact.Visible = true;
			// 
			// lst_company2
			// 
			lst_company2.AllowDrop = true;
			lst_company2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_company2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_company2.CausesValidation = true;
			lst_company2.Enabled = true;
			lst_company2.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_company2.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_company2.IntegralHeight = true;
			lst_company2.Location = new System.Drawing.Point(369, 52);
			lst_company2.MultiColumn = false;
			lst_company2.Name = "lst_company2";
			lst_company2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_company2.Size = new System.Drawing.Size(345, 80);
			lst_company2.Sorted = false;
			lst_company2.TabIndex = 110;
			lst_company2.TabStop = true;
			lst_company2.Visible = true;
			// 
			// lst_company1
			// 
			lst_company1.AllowDrop = true;
			lst_company1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_company1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_company1.CausesValidation = true;
			lst_company1.Enabled = true;
			lst_company1.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_company1.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_company1.IntegralHeight = true;
			lst_company1.Location = new System.Drawing.Point(10, 52);
			lst_company1.MultiColumn = false;
			lst_company1.Name = "lst_company1";
			lst_company1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_company1.Size = new System.Drawing.Size(345, 80);
			lst_company1.Sorted = false;
			lst_company1.TabIndex = 109;
			lst_company1.TabStop = true;
			lst_company1.Visible = true;
			// 
			// cbo_relationship
			// 
			cbo_relationship.AllowDrop = true;
			cbo_relationship.BackColor = System.Drawing.SystemColors.Window;
			cbo_relationship.CausesValidation = true;
			cbo_relationship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_relationship.Enabled = true;
			cbo_relationship.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_relationship.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_relationship.IntegralHeight = true;
			cbo_relationship.Location = new System.Drawing.Point(8, 5);
			cbo_relationship.Name = "cbo_relationship";
			cbo_relationship.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_relationship.Size = new System.Drawing.Size(218, 21);
			cbo_relationship.Sorted = false;
			cbo_relationship.TabIndex = 107;
			cbo_relationship.TabStop = true;
			cbo_relationship.Visible = true;
			cbo_relationship.SelectedIndexChanged += new System.EventHandler(cbo_Relationship_SelectedIndexChanged);
			// 
			// _lbl_Label1_27
			// 
			_lbl_Label1_27.AllowDrop = true;
			_lbl_Label1_27.AutoSize = true;
			_lbl_Label1_27.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_27.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_27.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_27.Location = new System.Drawing.Point(369, 24);
			_lbl_Label1_27.MinimumSize = new System.Drawing.Size(99, 16);
			_lbl_Label1_27.Name = "_lbl_Label1_27";
			_lbl_Label1_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_27.Size = new System.Drawing.Size(99, 16);
			_lbl_Label1_27.TabIndex = 113;
			_lbl_Label1_27.Text = "lbl_Label1(27)";
			// 
			// pnl_contact_info
			// 
			pnl_contact_info.AllowDrop = true;
			pnl_contact_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_contact_info.Controls.Add(lst_contact_info);
			pnl_contact_info.Controls.Add(cmd_Confirm_Contact);
			pnl_contact_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_contact_info.Location = new System.Drawing.Point(640, 256);
			pnl_contact_info.Name = "pnl_contact_info";
			pnl_contact_info.Size = new System.Drawing.Size(361, 162);
			pnl_contact_info.TabIndex = 103;
			pnl_contact_info.Visible = false;
			// 
			// lst_contact_info
			// 
			lst_contact_info.AllowDrop = true;
			lst_contact_info.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_contact_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_contact_info.CausesValidation = true;
			lst_contact_info.Enabled = true;
			lst_contact_info.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_contact_info.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_contact_info.IntegralHeight = true;
			lst_contact_info.Location = new System.Drawing.Point(8, 20);
			lst_contact_info.MultiColumn = false;
			lst_contact_info.Name = "lst_contact_info";
			lst_contact_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_contact_info.Size = new System.Drawing.Size(344, 80);
			lst_contact_info.Sorted = false;
			lst_contact_info.TabIndex = 105;
			lst_contact_info.TabStop = true;
			lst_contact_info.Visible = true;
			// 
			// cmd_Confirm_Contact
			// 
			cmd_Confirm_Contact.AllowDrop = true;
			cmd_Confirm_Contact.BackColor = System.Drawing.SystemColors.Control;
			cmd_Confirm_Contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Confirm_Contact.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Confirm_Contact.Location = new System.Drawing.Point(104, 123);
			cmd_Confirm_Contact.Name = "cmd_Confirm_Contact";
			cmd_Confirm_Contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Confirm_Contact.Size = new System.Drawing.Size(153, 24);
			cmd_Confirm_Contact.TabIndex = 104;
			cmd_Confirm_Contact.Text = "Confirm Contact Information";
			cmd_Confirm_Contact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Confirm_Contact.UseVisualStyleBackColor = false;
			cmd_Confirm_Contact.Click += new System.EventHandler(cmd_Confirm_Contact_Click);
			// 
			// frame_awaiting_documentation
			// 
			frame_awaiting_documentation.AllowDrop = true;
			frame_awaiting_documentation.BackColor = System.Drawing.SystemColors.Control;
			frame_awaiting_documentation.Controls.Add(cmd_awaiting_docsOK);
			frame_awaiting_documentation.Controls.Add(cbo_unknown_state);
			frame_awaiting_documentation.Controls.Add(cbo_unknown_country);
			frame_awaiting_documentation.Controls.Add(_lbl_Label1_25);
			frame_awaiting_documentation.Controls.Add(_lbl_Label1_26);
			frame_awaiting_documentation.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_awaiting_documentation.Enabled = true;
			frame_awaiting_documentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_awaiting_documentation.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_awaiting_documentation.Location = new System.Drawing.Point(323, 277);
			frame_awaiting_documentation.Name = "frame_awaiting_documentation";
			frame_awaiting_documentation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_awaiting_documentation.Size = new System.Drawing.Size(271, 108);
			frame_awaiting_documentation.TabIndex = 77;
			frame_awaiting_documentation.Text = "   Location of Awaiting Docs Company   ";
			frame_awaiting_documentation.Visible = true;
			// 
			// cmd_awaiting_docsOK
			// 
			cmd_awaiting_docsOK.AllowDrop = true;
			cmd_awaiting_docsOK.BackColor = System.Drawing.SystemColors.Control;
			cmd_awaiting_docsOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_awaiting_docsOK.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_awaiting_docsOK.Location = new System.Drawing.Point(6, 76);
			cmd_awaiting_docsOK.Name = "cmd_awaiting_docsOK";
			cmd_awaiting_docsOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_awaiting_docsOK.Size = new System.Drawing.Size(257, 28);
			cmd_awaiting_docsOK.TabIndex = 80;
			cmd_awaiting_docsOK.TabStop = false;
			cmd_awaiting_docsOK.Text = "OK";
			cmd_awaiting_docsOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_awaiting_docsOK.UseVisualStyleBackColor = false;
			cmd_awaiting_docsOK.Click += new System.EventHandler(cmd_awaiting_docsOK_Click);
			// 
			// cbo_unknown_state
			// 
			cbo_unknown_state.AllowDrop = true;
			cbo_unknown_state.BackColor = System.Drawing.SystemColors.Window;
			cbo_unknown_state.CausesValidation = true;
			cbo_unknown_state.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_unknown_state.Enabled = true;
			cbo_unknown_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_unknown_state.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_unknown_state.IntegralHeight = true;
			cbo_unknown_state.Location = new System.Drawing.Point(70, 21);
			cbo_unknown_state.Name = "cbo_unknown_state";
			cbo_unknown_state.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_unknown_state.Size = new System.Drawing.Size(185, 21);
			cbo_unknown_state.Sorted = false;
			cbo_unknown_state.TabIndex = 79;
			cbo_unknown_state.TabStop = true;
			cbo_unknown_state.Visible = true;
			cbo_unknown_state.SelectedIndexChanged += new System.EventHandler(cbo_Unknown_State_SelectedIndexChanged);
			// 
			// cbo_unknown_country
			// 
			cbo_unknown_country.AllowDrop = true;
			cbo_unknown_country.BackColor = System.Drawing.SystemColors.Window;
			cbo_unknown_country.CausesValidation = true;
			cbo_unknown_country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_unknown_country.Enabled = true;
			cbo_unknown_country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_unknown_country.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_unknown_country.IntegralHeight = true;
			cbo_unknown_country.Location = new System.Drawing.Point(70, 44);
			cbo_unknown_country.Name = "cbo_unknown_country";
			cbo_unknown_country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_unknown_country.Size = new System.Drawing.Size(185, 21);
			cbo_unknown_country.Sorted = false;
			cbo_unknown_country.TabIndex = 78;
			cbo_unknown_country.TabStop = true;
			cbo_unknown_country.Visible = true;
			cbo_unknown_country.SelectedIndexChanged += new System.EventHandler(cbo_Unknown_Country_SelectedIndexChanged);
			// 
			// _lbl_Label1_25
			// 
			_lbl_Label1_25.AllowDrop = true;
			_lbl_Label1_25.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_25.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_25.Location = new System.Drawing.Point(21, 24);
			_lbl_Label1_25.MinimumSize = new System.Drawing.Size(47, 13);
			_lbl_Label1_25.Name = "_lbl_Label1_25";
			_lbl_Label1_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_25.Size = new System.Drawing.Size(47, 13);
			_lbl_Label1_25.TabIndex = 82;
			_lbl_Label1_25.Text = "State:";
			_lbl_Label1_25.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_26
			// 
			_lbl_Label1_26.AllowDrop = true;
			_lbl_Label1_26.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_26.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_26.Location = new System.Drawing.Point(21, 48);
			_lbl_Label1_26.MinimumSize = new System.Drawing.Size(47, 13);
			_lbl_Label1_26.Name = "_lbl_Label1_26";
			_lbl_Label1_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_26.Size = new System.Drawing.Size(47, 13);
			_lbl_Label1_26.TabIndex = 81;
			_lbl_Label1_26.Text = "Country:";
			_lbl_Label1_26.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// pnl_associate_aircraft
			// 
			pnl_associate_aircraft.AllowDrop = true;
			pnl_associate_aircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_associate_aircraft.Controls.Add(lst_aircraft_info);
			pnl_associate_aircraft.Controls.Add(cbo_contact_type);
			pnl_associate_aircraft.Controls.Add(cmd_Associate);
			pnl_associate_aircraft.Controls.Add(_lbl_Label1_22);
			pnl_associate_aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_associate_aircraft.Location = new System.Drawing.Point(0, 256);
			pnl_associate_aircraft.Name = "pnl_associate_aircraft";
			pnl_associate_aircraft.Size = new System.Drawing.Size(277, 162);
			pnl_associate_aircraft.TabIndex = 90;
			// 
			// lst_aircraft_info
			// 
			lst_aircraft_info.AllowDrop = true;
			lst_aircraft_info.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_aircraft_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_aircraft_info.CausesValidation = true;
			lst_aircraft_info.Enabled = true;
			lst_aircraft_info.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_aircraft_info.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_aircraft_info.IntegralHeight = true;
			lst_aircraft_info.Location = new System.Drawing.Point(6, 20);
			lst_aircraft_info.MultiColumn = false;
			lst_aircraft_info.Name = "lst_aircraft_info";
			lst_aircraft_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_aircraft_info.Size = new System.Drawing.Size(263, 65);
			lst_aircraft_info.Sorted = false;
			lst_aircraft_info.TabIndex = 93;
			lst_aircraft_info.TabStop = true;
			lst_aircraft_info.Visible = true;
			lst_aircraft_info.Items.AddRange(new object[]{"lst_aircraft_info"});
			// 
			// cbo_contact_type
			// 
			cbo_contact_type.AllowDrop = true;
			cbo_contact_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact_type.CausesValidation = true;
			cbo_contact_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_contact_type.Enabled = true;
			cbo_contact_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact_type.IntegralHeight = true;
			cbo_contact_type.Location = new System.Drawing.Point(8, 134);
			cbo_contact_type.Name = "cbo_contact_type";
			cbo_contact_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact_type.Size = new System.Drawing.Size(265, 21);
			cbo_contact_type.Sorted = false;
			cbo_contact_type.TabIndex = 92;
			cbo_contact_type.TabStop = true;
			cbo_contact_type.Visible = true;
			cbo_contact_type.SelectedIndexChanged += new System.EventHandler(cbo_contact_type_SelectedIndexChanged);
			// 
			// cmd_Associate
			// 
			cmd_Associate.AllowDrop = true;
			cmd_Associate.BackColor = System.Drawing.SystemColors.Control;
			cmd_Associate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Associate.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Associate.Location = new System.Drawing.Point(32, 88);
			cmd_Associate.Name = "cmd_Associate";
			cmd_Associate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Associate.Size = new System.Drawing.Size(216, 24);
			cmd_Associate.TabIndex = 91;
			cmd_Associate.Text = "Associate";
			cmd_Associate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Associate.UseVisualStyleBackColor = false;
			cmd_Associate.Click += new System.EventHandler(cmd_Associate_Click);
			// 
			// _lbl_Label1_22
			// 
			_lbl_Label1_22.AllowDrop = true;
			_lbl_Label1_22.AutoSize = true;
			_lbl_Label1_22.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_22.Location = new System.Drawing.Point(78, 116);
			_lbl_Label1_22.MinimumSize = new System.Drawing.Size(120, 13);
			_lbl_Label1_22.Name = "_lbl_Label1_22";
			_lbl_Label1_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_22.Size = new System.Drawing.Size(120, 13);
			_lbl_Label1_22.TabIndex = 94;
			_lbl_Label1_22.Text = "Aircraft Association Type:";
			// 
			// pnl_duplicates
			// 
			pnl_duplicates.AllowDrop = true;
			pnl_duplicates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_duplicates.Controls.Add(cmd_close_duplicates);
			pnl_duplicates.Controls.Add(cmd_remove_duplicates);
			pnl_duplicates.Controls.Add(lst_duplicates);
			pnl_duplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_duplicates.Location = new System.Drawing.Point(639, 257);
			pnl_duplicates.Name = "pnl_duplicates";
			pnl_duplicates.Size = new System.Drawing.Size(361, 162);
			pnl_duplicates.TabIndex = 114;
			// 
			// cmd_close_duplicates
			// 
			cmd_close_duplicates.AllowDrop = true;
			cmd_close_duplicates.BackColor = System.Drawing.SystemColors.Control;
			cmd_close_duplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_close_duplicates.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_close_duplicates.Location = new System.Drawing.Point(272, 123);
			cmd_close_duplicates.Name = "cmd_close_duplicates";
			cmd_close_duplicates.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_close_duplicates.Size = new System.Drawing.Size(81, 24);
			cmd_close_duplicates.TabIndex = 117;
			cmd_close_duplicates.Text = "&Close";
			cmd_close_duplicates.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_close_duplicates.UseVisualStyleBackColor = false;
			cmd_close_duplicates.Click += new System.EventHandler(cmd_close_duplicates_Click);
			// 
			// cmd_remove_duplicates
			// 
			cmd_remove_duplicates.AllowDrop = true;
			cmd_remove_duplicates.BackColor = System.Drawing.SystemColors.Control;
			cmd_remove_duplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_remove_duplicates.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_remove_duplicates.Location = new System.Drawing.Point(7, 123);
			cmd_remove_duplicates.Name = "cmd_remove_duplicates";
			cmd_remove_duplicates.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_remove_duplicates.Size = new System.Drawing.Size(167, 24);
			cmd_remove_duplicates.TabIndex = 116;
			cmd_remove_duplicates.Text = "Remove Duplicate Company";
			cmd_remove_duplicates.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_remove_duplicates.UseVisualStyleBackColor = false;
			cmd_remove_duplicates.Click += new System.EventHandler(cmd_remove_duplicates_Click);
			// 
			// lst_duplicates
			// 
			lst_duplicates.AllowDrop = true;
			lst_duplicates.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_duplicates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_duplicates.CausesValidation = true;
			lst_duplicates.Enabled = true;
			lst_duplicates.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_duplicates.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_duplicates.IntegralHeight = true;
			lst_duplicates.Location = new System.Drawing.Point(8, 20);
			lst_duplicates.MultiColumn = false;
			lst_duplicates.Name = "lst_duplicates";
			lst_duplicates.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_duplicates.Size = new System.Drawing.Size(344, 80);
			lst_duplicates.Sorted = false;
			lst_duplicates.TabIndex = 115;
			lst_duplicates.TabStop = true;
			lst_duplicates.Visible = true;
			lst_duplicates.SelectedIndexChanged += new System.EventHandler(lst_duplicates_SelectedIndexChanged);
			// 
			// pnl_company_info
			// 
			pnl_company_info.AllowDrop = true;
			pnl_company_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_company_info.Controls.Add(lst_company);
			pnl_company_info.Controls.Add(chk_include_history);
			pnl_company_info.Controls.Add(cmd_Confirm_Company);
			pnl_company_info.Controls.Add(txt_num_characters);
			pnl_company_info.Controls.Add(chk_match_city);
			pnl_company_info.Controls.Add(cmd_find_duplicate);
			pnl_company_info.Controls.Add(_lbl_Label1_23);
			pnl_company_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_company_info.Location = new System.Drawing.Point(277, 257);
			pnl_company_info.Name = "pnl_company_info";
			pnl_company_info.Size = new System.Drawing.Size(362, 162);
			pnl_company_info.TabIndex = 95;
			// 
			// lst_company
			// 
			lst_company.AllowDrop = true;
			lst_company.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_company.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_company.CausesValidation = true;
			lst_company.Enabled = true;
			lst_company.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_company.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_company.IntegralHeight = true;
			lst_company.Location = new System.Drawing.Point(9, 20);
			lst_company.MultiColumn = false;
			lst_company.Name = "lst_company";
			lst_company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_company.Size = new System.Drawing.Size(344, 80);
			lst_company.Sorted = false;
			lst_company.TabIndex = 101;
			lst_company.TabStop = true;
			lst_company.Visible = true;
			lst_company.SelectedIndexChanged += new System.EventHandler(lst_Company_SelectedIndexChanged);
			// 
			// chk_include_history
			// 
			chk_include_history.AllowDrop = true;
			chk_include_history.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_include_history.BackColor = System.Drawing.SystemColors.Control;
			chk_include_history.CausesValidation = true;
			chk_include_history.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_include_history.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_include_history.Enabled = true;
			chk_include_history.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_include_history.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_include_history.Location = new System.Drawing.Point(251, 112);
			chk_include_history.Name = "chk_include_history";
			chk_include_history.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_include_history.Size = new System.Drawing.Size(101, 21);
			chk_include_history.TabIndex = 100;
			chk_include_history.TabStop = true;
			chk_include_history.Text = "Include Historical";
			chk_include_history.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_include_history.Visible = true;
			// 
			// cmd_Confirm_Company
			// 
			cmd_Confirm_Company.AllowDrop = true;
			cmd_Confirm_Company.BackColor = System.Drawing.SystemColors.Control;
			cmd_Confirm_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Confirm_Company.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Confirm_Company.Location = new System.Drawing.Point(189, 135);
			cmd_Confirm_Company.Name = "cmd_Confirm_Company";
			cmd_Confirm_Company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Confirm_Company.Size = new System.Drawing.Size(148, 24);
			cmd_Confirm_Company.TabIndex = 99;
			cmd_Confirm_Company.Text = "Confirm Company Information";
			cmd_Confirm_Company.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Confirm_Company.UseVisualStyleBackColor = false;
			cmd_Confirm_Company.Visible = false;
			// 
			// txt_num_characters
			// 
			txt_num_characters.AcceptsReturn = true;
			txt_num_characters.AllowDrop = true;
			txt_num_characters.BackColor = System.Drawing.SystemColors.Window;
			txt_num_characters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_num_characters.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_num_characters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_num_characters.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_num_characters.Location = new System.Drawing.Point(142, 138);
			txt_num_characters.MaxLength = 0;
			txt_num_characters.Name = "txt_num_characters";
			txt_num_characters.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_num_characters.Size = new System.Drawing.Size(29, 19);
			txt_num_characters.TabIndex = 98;
			txt_num_characters.Text = "0";
			// 
			// chk_match_city
			// 
			chk_match_city.AllowDrop = true;
			chk_match_city.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_match_city.BackColor = System.Drawing.SystemColors.Control;
			chk_match_city.CausesValidation = true;
			chk_match_city.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_match_city.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_match_city.Enabled = true;
			chk_match_city.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_match_city.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_match_city.Location = new System.Drawing.Point(158, 114);
			chk_match_city.Name = "chk_match_city";
			chk_match_city.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_match_city.Size = new System.Drawing.Size(73, 17);
			chk_match_city.TabIndex = 97;
			chk_match_city.TabStop = true;
			chk_match_city.Text = "Match City";
			chk_match_city.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_match_city.Visible = true;
			// 
			// cmd_find_duplicate
			// 
			cmd_find_duplicate.AllowDrop = true;
			cmd_find_duplicate.BackColor = System.Drawing.SystemColors.Control;
			cmd_find_duplicate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_find_duplicate.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_find_duplicate.Location = new System.Drawing.Point(7, 111);
			cmd_find_duplicate.Name = "cmd_find_duplicate";
			cmd_find_duplicate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_find_duplicate.Size = new System.Drawing.Size(129, 24);
			cmd_find_duplicate.TabIndex = 96;
			cmd_find_duplicate.Text = "Find Potential Duplicates";
			cmd_find_duplicate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_find_duplicate.UseVisualStyleBackColor = false;
			cmd_find_duplicate.Click += new System.EventHandler(cmd_find_duplicate_Click);
			// 
			// _lbl_Label1_23
			// 
			_lbl_Label1_23.AllowDrop = true;
			_lbl_Label1_23.AutoSize = true;
			_lbl_Label1_23.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_23.Location = new System.Drawing.Point(8, 141);
			_lbl_Label1_23.MinimumSize = new System.Drawing.Size(130, 13);
			_lbl_Label1_23.Name = "_lbl_Label1_23";
			_lbl_Label1_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_23.Size = new System.Drawing.Size(130, 13);
			_lbl_Label1_23.TabIndex = 102;
			_lbl_Label1_23.Text = "# of Characters to Match ->";
			// 
			// pnl_search_results
			// 
			pnl_search_results.AllowDrop = true;
			pnl_search_results.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_search_results.Controls.Add(cmd_Add_contact_trial);
			pnl_search_results.Controls.Add(cmd_sale_source);
			pnl_search_results.Controls.Add(cmd_add_to_pub);
			pnl_search_results.Controls.Add(chk_search);
			pnl_search_results.Controls.Add(cmdCompanyListExcelExport);
			pnl_search_results.Controls.Add(cmd_Refresh);
			pnl_search_results.Controls.Add(cmd_Add_Contact);
			pnl_search_results.Controls.Add(cmd_Stop);
			pnl_search_results.Controls.Add(grd_find_company);
			pnl_search_results.Controls.Add(lbl_test_omg);
			pnl_search_results.Controls.Add(lbl_total_found);
			pnl_search_results.Controls.Add(_lbl_Label1_24);
			pnl_search_results.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_search_results.Location = new System.Drawing.Point(0, 0);
			pnl_search_results.Name = "pnl_search_results";
			pnl_search_results.Size = new System.Drawing.Size(1000, 257);
			pnl_search_results.TabIndex = 83;
			// 
			// cmd_Add_contact_trial
			// 
			cmd_Add_contact_trial.AllowDrop = true;
			cmd_Add_contact_trial.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_contact_trial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_contact_trial.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_contact_trial.Location = new System.Drawing.Point(752, 232);
			cmd_Add_contact_trial.Name = "cmd_Add_contact_trial";
			cmd_Add_contact_trial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_contact_trial.Size = new System.Drawing.Size(93, 23);
			cmd_Add_contact_trial.TabIndex = 177;
			cmd_Add_contact_trial.Text = "Add Contact Trial";
			cmd_Add_contact_trial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_contact_trial.UseVisualStyleBackColor = false;
			cmd_Add_contact_trial.Visible = false;
			cmd_Add_contact_trial.Click += new System.EventHandler(cmd_Add_contact_trial_Click);
			// 
			// cmd_sale_source
			// 
			cmd_sale_source.AllowDrop = true;
			cmd_sale_source.BackColor = System.Drawing.SystemColors.Control;
			cmd_sale_source.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_sale_source.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_sale_source.Location = new System.Drawing.Point(600, 232);
			cmd_sale_source.Name = "cmd_sale_source";
			cmd_sale_source.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_sale_source.Size = new System.Drawing.Size(93, 23);
			cmd_sale_source.TabIndex = 171;
			cmd_sale_source.Text = "Add Source";
			cmd_sale_source.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_sale_source.UseVisualStyleBackColor = false;
			cmd_sale_source.Visible = false;
			cmd_sale_source.Click += new System.EventHandler(cmd_sale_source_Click);
			// 
			// cmd_add_to_pub
			// 
			cmd_add_to_pub.AllowDrop = true;
			cmd_add_to_pub.BackColor = System.Drawing.SystemColors.Control;
			cmd_add_to_pub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_add_to_pub.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_add_to_pub.Location = new System.Drawing.Point(472, 232);
			cmd_add_to_pub.Name = "cmd_add_to_pub";
			cmd_add_to_pub.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_add_to_pub.Size = new System.Drawing.Size(119, 23);
			cmd_add_to_pub.TabIndex = 169;
			cmd_add_to_pub.Text = "Add Company To Pub";
			cmd_add_to_pub.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_add_to_pub.UseVisualStyleBackColor = false;
			cmd_add_to_pub.Visible = false;
			cmd_add_to_pub.Click += new System.EventHandler(cmd_add_to_pub_Click);
			// 
			// chk_search
			// 
			chk_search.AllowDrop = true;
			chk_search.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_search.BackColor = System.Drawing.SystemColors.Control;
			chk_search.CausesValidation = true;
			chk_search.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_search.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_search.Enabled = true;
			chk_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_search.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_search.Location = new System.Drawing.Point(8, 236);
			chk_search.Name = "chk_search";
			chk_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_search.Size = new System.Drawing.Size(123, 15);
			chk_search.TabIndex = 167;
			chk_search.TabStop = true;
			chk_search.Text = "Show Marketing Rep";
			chk_search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_search.Visible = true;
			// 
			// cmdCompanyListExcelExport
			// 
			cmdCompanyListExcelExport.AllowDrop = true;
			cmdCompanyListExcelExport.BackColor = System.Drawing.SystemColors.Control;
			cmdCompanyListExcelExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCompanyListExcelExport.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCompanyListExcelExport.Location = new System.Drawing.Point(142, 232);
			cmdCompanyListExcelExport.Name = "cmdCompanyListExcelExport";
			cmdCompanyListExcelExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCompanyListExcelExport.Size = new System.Drawing.Size(78, 21);
			cmdCompanyListExcelExport.TabIndex = 151;
			cmdCompanyListExcelExport.Text = "&Export";
			cmdCompanyListExcelExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCompanyListExcelExport.UseVisualStyleBackColor = false;
			cmdCompanyListExcelExport.Visible = false;
			cmdCompanyListExcelExport.Click += new System.EventHandler(cmdCompanyListExcelExport_Click);
			// 
			// cmd_Refresh
			// 
			cmd_Refresh.AllowDrop = true;
			cmd_Refresh.BackColor = System.Drawing.SystemColors.Control;
			cmd_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Refresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Refresh.Location = new System.Drawing.Point(304, 232);
			cmd_Refresh.Name = "cmd_Refresh";
			cmd_Refresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Refresh.Size = new System.Drawing.Size(67, 21);
			cmd_Refresh.TabIndex = 85;
			cmd_Refresh.Text = "&Refresh";
			cmd_Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Refresh.UseVisualStyleBackColor = false;
			cmd_Refresh.Click += new System.EventHandler(cmd_refresh_Click);
			// 
			// cmd_Add_Contact
			// 
			cmd_Add_Contact.AllowDrop = true;
			cmd_Add_Contact.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Contact.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Contact.Location = new System.Drawing.Point(384, 232);
			cmd_Add_Contact.Name = "cmd_Add_Contact";
			cmd_Add_Contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Contact.Size = new System.Drawing.Size(80, 21);
			cmd_Add_Contact.TabIndex = 86;
			cmd_Add_Contact.Text = "&Add Contact";
			cmd_Add_Contact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Contact.UseVisualStyleBackColor = false;
			cmd_Add_Contact.Visible = false;
			cmd_Add_Contact.Click += new System.EventHandler(cmd_Add_Contact_Click);
			// 
			// cmd_Stop
			// 
			cmd_Stop.AllowDrop = true;
			cmd_Stop.BackColor = System.Drawing.SystemColors.Control;
			cmd_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Stop.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Stop.Location = new System.Drawing.Point(224, 233);
			cmd_Stop.Name = "cmd_Stop";
			cmd_Stop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Stop.Size = new System.Drawing.Size(70, 21);
			cmd_Stop.TabIndex = 84;
			cmd_Stop.Text = "Stop";
			cmd_Stop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Stop.UseVisualStyleBackColor = false;
			cmd_Stop.Visible = false;
			cmd_Stop.Click += new System.EventHandler(cmd_Stop_Click);
			cmd_Stop.MouseMove += new System.Windows.Forms.MouseEventHandler(cmd_Stop_MouseMove);
			// 
			// grd_find_company
			// 
			grd_find_company.AllowDrop = true;
			grd_find_company.AllowUserToAddRows = false;
			grd_find_company.AllowUserToDeleteRows = false;
			grd_find_company.AllowUserToResizeColumns = false;
			grd_find_company.AllowUserToResizeColumns = grd_find_company.ColumnHeadersVisible;
			grd_find_company.AllowUserToResizeRows = false;
			grd_find_company.AllowUserToResizeRows = false;
			grd_find_company.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_find_company.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_find_company.ColumnsCount = 2;
			grd_find_company.FixedColumns = 0;
			grd_find_company.FixedRows = 0;
			grd_find_company.Location = new System.Drawing.Point(2, 24);
			grd_find_company.Name = "grd_find_company";
			grd_find_company.ReadOnly = true;
			grd_find_company.RowsCount = 2;
			grd_find_company.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_find_company.ShowCellToolTips = false;
			grd_find_company.Size = new System.Drawing.Size(995, 206);
			grd_find_company.StandardTab = true;
			grd_find_company.TabIndex = 87;
			grd_find_company.Click += new System.EventHandler(grd_find_company_Click);
			grd_find_company.DoubleClick += new System.EventHandler(grd_find_company_DoubleClick);
			grd_find_company.MouseDown += new System.Windows.Forms.MouseEventHandler(grd_find_company_MouseDown);
			// 
			// lbl_test_omg
			// 
			lbl_test_omg.AllowDrop = true;
			lbl_test_omg.BackColor = System.Drawing.Color.Aqua;
			lbl_test_omg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_test_omg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_test_omg.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_test_omg.Location = new System.Drawing.Point(584, 6);
			lbl_test_omg.MinimumSize = new System.Drawing.Size(97, 17);
			lbl_test_omg.Name = "lbl_test_omg";
			lbl_test_omg.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_test_omg.Size = new System.Drawing.Size(97, 17);
			lbl_test_omg.TabIndex = 178;
			lbl_test_omg.Text = "-- You Are On Test --";
			lbl_test_omg.Visible = false;
			// 
			// lbl_total_found
			// 
			lbl_total_found.AllowDrop = true;
			lbl_total_found.BackColor = System.Drawing.Color.Transparent;
			lbl_total_found.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_total_found.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_total_found.ForeColor = System.Drawing.Color.Maroon;
			lbl_total_found.Location = new System.Drawing.Point(558, 234);
			lbl_total_found.MinimumSize = new System.Drawing.Size(434, 17);
			lbl_total_found.Name = "lbl_total_found";
			lbl_total_found.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_total_found.Size = new System.Drawing.Size(434, 17);
			lbl_total_found.TabIndex = 89;
			lbl_total_found.Text = "Companies";
			lbl_total_found.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_24
			// 
			_lbl_Label1_24.AllowDrop = true;
			_lbl_Label1_24.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_24.ForeColor = System.Drawing.Color.Maroon;
			_lbl_Label1_24.Location = new System.Drawing.Point(177, 0);
			_lbl_Label1_24.MinimumSize = new System.Drawing.Size(609, 21);
			_lbl_Label1_24.Name = "_lbl_Label1_24";
			_lbl_Label1_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_24.Size = new System.Drawing.Size(609, 21);
			_lbl_Label1_24.TabIndex = 88;
			_lbl_Label1_24.Text = "Current Companies";
			_lbl_Label1_24.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frame_potential_dups_grid
			// 
			frame_potential_dups_grid.AllowDrop = true;
			frame_potential_dups_grid.BackColor = System.Drawing.SystemColors.Control;
			frame_potential_dups_grid.Controls.Add(cmd_dup_hide_grid_frame);
			frame_potential_dups_grid.Controls.Add(cmd_dup_paste_to_clipboard);
			frame_potential_dups_grid.Controls.Add(cmd_dup_stop_grid_fill);
			frame_potential_dups_grid.Controls.Add(grd_potential_duplicates);
			frame_potential_dups_grid.Controls.Add(_lbl_Label1_33);
			frame_potential_dups_grid.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_potential_dups_grid.Enabled = true;
			frame_potential_dups_grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_potential_dups_grid.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_potential_dups_grid.Location = new System.Drawing.Point(179, 457);
			frame_potential_dups_grid.Name = "frame_potential_dups_grid";
			frame_potential_dups_grid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_potential_dups_grid.Size = new System.Drawing.Size(643, 176);
			frame_potential_dups_grid.TabIndex = 142;
			frame_potential_dups_grid.Visible = false;
			// 
			// cmd_dup_hide_grid_frame
			// 
			cmd_dup_hide_grid_frame.AllowDrop = true;
			cmd_dup_hide_grid_frame.BackColor = System.Drawing.SystemColors.Control;
			cmd_dup_hide_grid_frame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_dup_hide_grid_frame.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_dup_hide_grid_frame.Location = new System.Drawing.Point(454, 14);
			cmd_dup_hide_grid_frame.Name = "cmd_dup_hide_grid_frame";
			cmd_dup_hide_grid_frame.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_dup_hide_grid_frame.Size = new System.Drawing.Size(41, 23);
			cmd_dup_hide_grid_frame.TabIndex = 145;
			cmd_dup_hide_grid_frame.Text = "Hide";
			cmd_dup_hide_grid_frame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_dup_hide_grid_frame.UseVisualStyleBackColor = false;
			cmd_dup_hide_grid_frame.Click += new System.EventHandler(cmd_dup_hide_grid_frame_Click);
			// 
			// cmd_dup_paste_to_clipboard
			// 
			cmd_dup_paste_to_clipboard.AllowDrop = true;
			cmd_dup_paste_to_clipboard.BackColor = System.Drawing.SystemColors.Control;
			cmd_dup_paste_to_clipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_dup_paste_to_clipboard.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_dup_paste_to_clipboard.Location = new System.Drawing.Point(523, 14);
			cmd_dup_paste_to_clipboard.Name = "cmd_dup_paste_to_clipboard";
			cmd_dup_paste_to_clipboard.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_dup_paste_to_clipboard.Size = new System.Drawing.Size(110, 23);
			cmd_dup_paste_to_clipboard.TabIndex = 144;
			cmd_dup_paste_to_clipboard.Text = "Paste to Clipboard";
			cmd_dup_paste_to_clipboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_dup_paste_to_clipboard.UseVisualStyleBackColor = false;
			cmd_dup_paste_to_clipboard.Click += new System.EventHandler(cmd_dup_paste_to_clipboard_Click);
			// 
			// cmd_dup_stop_grid_fill
			// 
			cmd_dup_stop_grid_fill.AllowDrop = true;
			cmd_dup_stop_grid_fill.BackColor = System.Drawing.SystemColors.Control;
			cmd_dup_stop_grid_fill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_dup_stop_grid_fill.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_dup_stop_grid_fill.Location = new System.Drawing.Point(9, 14);
			cmd_dup_stop_grid_fill.Name = "cmd_dup_stop_grid_fill";
			cmd_dup_stop_grid_fill.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_dup_stop_grid_fill.Size = new System.Drawing.Size(41, 23);
			cmd_dup_stop_grid_fill.TabIndex = 143;
			cmd_dup_stop_grid_fill.Text = "Stop";
			cmd_dup_stop_grid_fill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_dup_stop_grid_fill.UseVisualStyleBackColor = false;
			cmd_dup_stop_grid_fill.Click += new System.EventHandler(cmd_dup_stop_grid_fill_Click);
			cmd_dup_stop_grid_fill.MouseMove += new System.Windows.Forms.MouseEventHandler(cmd_dup_stop_grid_fill_MouseMove);
			// 
			// grd_potential_duplicates
			// 
			grd_potential_duplicates.AllowDrop = true;
			grd_potential_duplicates.AllowUserToAddRows = false;
			grd_potential_duplicates.AllowUserToDeleteRows = false;
			grd_potential_duplicates.AllowUserToResizeColumns = false;
			grd_potential_duplicates.AllowUserToResizeColumns = grd_potential_duplicates.ColumnHeadersVisible;
			grd_potential_duplicates.AllowUserToResizeRows = false;
			grd_potential_duplicates.AllowUserToResizeRows = false;
			grd_potential_duplicates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_potential_duplicates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_potential_duplicates.ColumnsCount = 2;
			grd_potential_duplicates.FixedColumns = 0;
			grd_potential_duplicates.FixedRows = 1;
			grd_potential_duplicates.Location = new System.Drawing.Point(9, 43);
			grd_potential_duplicates.Name = "grd_potential_duplicates";
			grd_potential_duplicates.ReadOnly = true;
			grd_potential_duplicates.RowsCount = 2;
			grd_potential_duplicates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_potential_duplicates.ShowCellToolTips = false;
			grd_potential_duplicates.Size = new System.Drawing.Size(624, 120);
			grd_potential_duplicates.StandardTab = true;
			grd_potential_duplicates.TabIndex = 146;
			grd_potential_duplicates.Click += new System.EventHandler(grd_potential_duplicates_Click);
			// 
			// _lbl_Label1_33
			// 
			_lbl_Label1_33.AllowDrop = true;
			_lbl_Label1_33.AutoSize = true;
			_lbl_Label1_33.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_33.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_33.Location = new System.Drawing.Point(66, 19);
			_lbl_Label1_33.MinimumSize = new System.Drawing.Size(66, 13);
			_lbl_Label1_33.Name = "_lbl_Label1_33";
			_lbl_Label1_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_33.Size = new System.Drawing.Size(66, 13);
			_lbl_Label1_33.TabIndex = 147;
			_lbl_Label1_33.Text = "lbl_Label1(33)";
			// 
			// frame_potential_dups
			// 
			frame_potential_dups.AllowDrop = true;
			frame_potential_dups.BackColor = System.Drawing.SystemColors.Control;
			frame_potential_dups.Controls.Add(cbo_dup_account_rep);
			frame_potential_dups.Controls.Add(cmd_find_potential_dup);
			frame_potential_dups.Controls.Add(chk_dup_sort);
			frame_potential_dups.Controls.Add(_opt_dup_sortby_5);
			frame_potential_dups.Controls.Add(_opt_dup_sortby_4);
			frame_potential_dups.Controls.Add(_opt_dup_sortby_3);
			frame_potential_dups.Controls.Add(_opt_dup_sortby_0);
			frame_potential_dups.Controls.Add(_chk_dup_include_2);
			frame_potential_dups.Controls.Add(_chk_dup_include_1);
			frame_potential_dups.Controls.Add(_chk_dup_include_0);
			frame_potential_dups.Controls.Add(txt_dup_num_chars);
			frame_potential_dups.Controls.Add(cmd_hide_potential_dup_frame);
			frame_potential_dups.Controls.Add(_opt_dup_sortby_1);
			frame_potential_dups.Controls.Add(chk_dup_phone);
			frame_potential_dups.Controls.Add(_opt_dup_sortby_6);
			frame_potential_dups.Controls.Add(chk_exclude_comp_to_comp);
			frame_potential_dups.Controls.Add(chk_dup_contacts);
			frame_potential_dups.Controls.Add(_opt_dup_sortby_2);
			frame_potential_dups.Controls.Add(chk_dup_confirm_non_dups);
			frame_potential_dups.Controls.Add(_lbl_Label1_32);
			frame_potential_dups.Controls.Add(_lbl_Label1_31);
			frame_potential_dups.Controls.Add(_lbl_Label1_30);
			frame_potential_dups.Controls.Add(_lbl_Label1_29);
			frame_potential_dups.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_potential_dups.Enabled = true;
			frame_potential_dups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_potential_dups.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			frame_potential_dups.Location = new System.Drawing.Point(304, 272);
			frame_potential_dups.Name = "frame_potential_dups";
			frame_potential_dups.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_potential_dups.Size = new System.Drawing.Size(418, 190);
			frame_potential_dups.TabIndex = 118;
			frame_potential_dups.Text = " Potential Duplicates ";
			frame_potential_dups.Visible = false;
			// 
			// cbo_dup_account_rep
			// 
			cbo_dup_account_rep.AllowDrop = true;
			cbo_dup_account_rep.BackColor = System.Drawing.SystemColors.Window;
			cbo_dup_account_rep.CausesValidation = true;
			cbo_dup_account_rep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_dup_account_rep.Enabled = true;
			cbo_dup_account_rep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_dup_account_rep.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_dup_account_rep.IntegralHeight = true;
			cbo_dup_account_rep.Location = new System.Drawing.Point(281, 35);
			cbo_dup_account_rep.Name = "cbo_dup_account_rep";
			cbo_dup_account_rep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_dup_account_rep.Size = new System.Drawing.Size(129, 21);
			cbo_dup_account_rep.Sorted = false;
			cbo_dup_account_rep.TabIndex = 137;
			cbo_dup_account_rep.TabStop = true;
			cbo_dup_account_rep.Visible = true;
			// 
			// cmd_find_potential_dup
			// 
			cmd_find_potential_dup.AllowDrop = true;
			cmd_find_potential_dup.BackColor = System.Drawing.SystemColors.Control;
			cmd_find_potential_dup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_find_potential_dup.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_find_potential_dup.Location = new System.Drawing.Point(365, 131);
			cmd_find_potential_dup.Name = "cmd_find_potential_dup";
			cmd_find_potential_dup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_find_potential_dup.Size = new System.Drawing.Size(45, 21);
			cmd_find_potential_dup.TabIndex = 136;
			cmd_find_potential_dup.Text = "Go";
			cmd_find_potential_dup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_find_potential_dup.UseVisualStyleBackColor = false;
			cmd_find_potential_dup.Click += new System.EventHandler(cmd_find_potential_dup_Click);
			// 
			// chk_dup_sort
			// 
			chk_dup_sort.AllowDrop = true;
			chk_dup_sort.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_dup_sort.BackColor = System.Drawing.SystemColors.Control;
			chk_dup_sort.CausesValidation = true;
			chk_dup_sort.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_dup_sort.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_dup_sort.Enabled = true;
			chk_dup_sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_dup_sort.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_dup_sort.Location = new System.Drawing.Point(9, 166);
			chk_dup_sort.Name = "chk_dup_sort";
			chk_dup_sort.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_dup_sort.Size = new System.Drawing.Size(140, 16);
			chk_dup_sort.TabIndex = 135;
			chk_dup_sort.TabStop = true;
			chk_dup_sort.Text = "Descending Sort Order";
			chk_dup_sort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_dup_sort.Visible = true;
			// 
			// _opt_dup_sortby_5
			// 
			_opt_dup_sortby_5.AllowDrop = true;
			_opt_dup_sortby_5.BackColor = System.Drawing.SystemColors.Control;
			_opt_dup_sortby_5.CausesValidation = true;
			_opt_dup_sortby_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_5.Checked = false;
			_opt_dup_sortby_5.Enabled = true;
			_opt_dup_sortby_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_dup_sortby_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_dup_sortby_5.Location = new System.Drawing.Point(206, 146);
			_opt_dup_sortby_5.Name = "_opt_dup_sortby_5";
			_opt_dup_sortby_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_dup_sortby_5.Size = new System.Drawing.Size(50, 15);
			_opt_dup_sortby_5.TabIndex = 134;
			_opt_dup_sortby_5.TabStop = true;
			_opt_dup_sortby_5.Text = "State";
			_opt_dup_sortby_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_5.Visible = true;
			// 
			// _opt_dup_sortby_4
			// 
			_opt_dup_sortby_4.AllowDrop = true;
			_opt_dup_sortby_4.BackColor = System.Drawing.SystemColors.Control;
			_opt_dup_sortby_4.CausesValidation = true;
			_opt_dup_sortby_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_4.Checked = false;
			_opt_dup_sortby_4.Enabled = true;
			_opt_dup_sortby_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_dup_sortby_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_dup_sortby_4.Location = new System.Drawing.Point(157, 146);
			_opt_dup_sortby_4.Name = "_opt_dup_sortby_4";
			_opt_dup_sortby_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_dup_sortby_4.Size = new System.Drawing.Size(43, 15);
			_opt_dup_sortby_4.TabIndex = 133;
			_opt_dup_sortby_4.TabStop = true;
			_opt_dup_sortby_4.Text = "City";
			_opt_dup_sortby_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_4.Visible = true;
			// 
			// _opt_dup_sortby_3
			// 
			_opt_dup_sortby_3.AllowDrop = true;
			_opt_dup_sortby_3.BackColor = System.Drawing.SystemColors.Control;
			_opt_dup_sortby_3.CausesValidation = true;
			_opt_dup_sortby_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_3.Checked = false;
			_opt_dup_sortby_3.Enabled = true;
			_opt_dup_sortby_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_dup_sortby_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_dup_sortby_3.Location = new System.Drawing.Point(54, 146);
			_opt_dup_sortby_3.Name = "_opt_dup_sortby_3";
			_opt_dup_sortby_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_dup_sortby_3.Size = new System.Drawing.Size(67, 15);
			_opt_dup_sortby_3.TabIndex = 132;
			_opt_dup_sortby_3.TabStop = true;
			_opt_dup_sortby_3.Text = "Address";
			_opt_dup_sortby_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_3.Visible = true;
			// 
			// _opt_dup_sortby_0
			// 
			_opt_dup_sortby_0.AllowDrop = true;
			_opt_dup_sortby_0.BackColor = System.Drawing.SystemColors.Control;
			_opt_dup_sortby_0.CausesValidation = true;
			_opt_dup_sortby_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_0.Checked = true;
			_opt_dup_sortby_0.Enabled = true;
			_opt_dup_sortby_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_dup_sortby_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_dup_sortby_0.Location = new System.Drawing.Point(54, 126);
			_opt_dup_sortby_0.Name = "_opt_dup_sortby_0";
			_opt_dup_sortby_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_dup_sortby_0.Size = new System.Drawing.Size(92, 15);
			_opt_dup_sortby_0.TabIndex = 131;
			_opt_dup_sortby_0.TabStop = true;
			_opt_dup_sortby_0.Text = "# of Duplicates";
			_opt_dup_sortby_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_0.Visible = true;
			// 
			// _chk_dup_include_2
			// 
			_chk_dup_include_2.AllowDrop = true;
			_chk_dup_include_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_dup_include_2.BackColor = System.Drawing.SystemColors.Control;
			_chk_dup_include_2.CausesValidation = true;
			_chk_dup_include_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_dup_include_2.CheckState = System.Windows.Forms.CheckState.Checked;
			_chk_dup_include_2.Enabled = true;
			_chk_dup_include_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_dup_include_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_dup_include_2.Location = new System.Drawing.Point(173, 106);
			_chk_dup_include_2.Name = "_chk_dup_include_2";
			_chk_dup_include_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_dup_include_2.Size = new System.Drawing.Size(52, 14);
			_chk_dup_include_2.TabIndex = 130;
			_chk_dup_include_2.TabStop = true;
			_chk_dup_include_2.Text = "State";
			_chk_dup_include_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_dup_include_2.Visible = true;
			_chk_dup_include_2.CheckStateChanged += new System.EventHandler(chk_dup_include_CheckStateChanged);
			// 
			// _chk_dup_include_1
			// 
			_chk_dup_include_1.AllowDrop = true;
			_chk_dup_include_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_dup_include_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_dup_include_1.CausesValidation = true;
			_chk_dup_include_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_dup_include_1.CheckState = System.Windows.Forms.CheckState.Checked;
			_chk_dup_include_1.Enabled = true;
			_chk_dup_include_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_dup_include_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_dup_include_1.Location = new System.Drawing.Point(124, 106);
			_chk_dup_include_1.Name = "_chk_dup_include_1";
			_chk_dup_include_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_dup_include_1.Size = new System.Drawing.Size(42, 14);
			_chk_dup_include_1.TabIndex = 129;
			_chk_dup_include_1.TabStop = true;
			_chk_dup_include_1.Text = "City";
			_chk_dup_include_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_dup_include_1.Visible = true;
			_chk_dup_include_1.CheckStateChanged += new System.EventHandler(chk_dup_include_CheckStateChanged);
			// 
			// _chk_dup_include_0
			// 
			_chk_dup_include_0.AllowDrop = true;
			_chk_dup_include_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_dup_include_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_dup_include_0.CausesValidation = true;
			_chk_dup_include_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_dup_include_0.CheckState = System.Windows.Forms.CheckState.Checked;
			_chk_dup_include_0.Enabled = true;
			_chk_dup_include_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_dup_include_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_dup_include_0.Location = new System.Drawing.Point(55, 106);
			_chk_dup_include_0.Name = "_chk_dup_include_0";
			_chk_dup_include_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_dup_include_0.Size = new System.Drawing.Size(67, 14);
			_chk_dup_include_0.TabIndex = 128;
			_chk_dup_include_0.TabStop = true;
			_chk_dup_include_0.Text = "Address";
			_chk_dup_include_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_dup_include_0.Visible = true;
			_chk_dup_include_0.CheckStateChanged += new System.EventHandler(chk_dup_include_CheckStateChanged);
			// 
			// txt_dup_num_chars
			// 
			txt_dup_num_chars.AcceptsReturn = true;
			txt_dup_num_chars.AllowDrop = true;
			txt_dup_num_chars.BackColor = System.Drawing.SystemColors.Window;
			txt_dup_num_chars.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_dup_num_chars.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_dup_num_chars.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_dup_num_chars.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_dup_num_chars.Location = new System.Drawing.Point(201, 82);
			txt_dup_num_chars.MaxLength = 0;
			txt_dup_num_chars.Name = "txt_dup_num_chars";
			txt_dup_num_chars.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_dup_num_chars.Size = new System.Drawing.Size(35, 19);
			txt_dup_num_chars.TabIndex = 127;
			txt_dup_num_chars.Text = "0";
			// 
			// cmd_hide_potential_dup_frame
			// 
			cmd_hide_potential_dup_frame.AllowDrop = true;
			cmd_hide_potential_dup_frame.BackColor = System.Drawing.SystemColors.Control;
			cmd_hide_potential_dup_frame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_hide_potential_dup_frame.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_hide_potential_dup_frame.Location = new System.Drawing.Point(365, 161);
			cmd_hide_potential_dup_frame.Name = "cmd_hide_potential_dup_frame";
			cmd_hide_potential_dup_frame.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_hide_potential_dup_frame.Size = new System.Drawing.Size(45, 21);
			cmd_hide_potential_dup_frame.TabIndex = 126;
			cmd_hide_potential_dup_frame.Text = "Hide";
			cmd_hide_potential_dup_frame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_hide_potential_dup_frame.UseVisualStyleBackColor = false;
			cmd_hide_potential_dup_frame.Click += new System.EventHandler(cmd_hide_potential_dup_frame_Click);
			// 
			// _opt_dup_sortby_1
			// 
			_opt_dup_sortby_1.AllowDrop = true;
			_opt_dup_sortby_1.BackColor = System.Drawing.SystemColors.Control;
			_opt_dup_sortby_1.CausesValidation = true;
			_opt_dup_sortby_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_1.Checked = false;
			_opt_dup_sortby_1.Enabled = true;
			_opt_dup_sortby_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_dup_sortby_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_dup_sortby_1.Location = new System.Drawing.Point(157, 126);
			_opt_dup_sortby_1.Name = "_opt_dup_sortby_1";
			_opt_dup_sortby_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_dup_sortby_1.Size = new System.Drawing.Size(95, 15);
			_opt_dup_sortby_1.TabIndex = 125;
			_opt_dup_sortby_1.TabStop = true;
			_opt_dup_sortby_1.Text = "Company Name";
			_opt_dup_sortby_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_1.Visible = true;
			// 
			// chk_dup_phone
			// 
			chk_dup_phone.AllowDrop = true;
			chk_dup_phone.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_dup_phone.BackColor = System.Drawing.SystemColors.Control;
			chk_dup_phone.CausesValidation = true;
			chk_dup_phone.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_dup_phone.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_dup_phone.Enabled = true;
			chk_dup_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_dup_phone.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_dup_phone.Location = new System.Drawing.Point(9, 18);
			chk_dup_phone.Name = "chk_dup_phone";
			chk_dup_phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_dup_phone.Size = new System.Drawing.Size(200, 16);
			chk_dup_phone.TabIndex = 124;
			chk_dup_phone.TabStop = true;
			chk_dup_phone.Text = "Look for Duplicate Phone Numbers";
			chk_dup_phone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_dup_phone.Visible = true;
			chk_dup_phone.CheckStateChanged += new System.EventHandler(chk_dup_phone_CheckStateChanged);
			// 
			// _opt_dup_sortby_6
			// 
			_opt_dup_sortby_6.AllowDrop = true;
			_opt_dup_sortby_6.BackColor = System.Drawing.SystemColors.Control;
			_opt_dup_sortby_6.CausesValidation = true;
			_opt_dup_sortby_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_6.Checked = false;
			_opt_dup_sortby_6.Enabled = true;
			_opt_dup_sortby_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_dup_sortby_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_dup_sortby_6.Location = new System.Drawing.Point(265, 146);
			_opt_dup_sortby_6.Name = "_opt_dup_sortby_6";
			_opt_dup_sortby_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_dup_sortby_6.Size = new System.Drawing.Size(67, 15);
			_opt_dup_sortby_6.TabIndex = 123;
			_opt_dup_sortby_6.TabStop = true;
			_opt_dup_sortby_6.Text = "Phone #";
			_opt_dup_sortby_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_6.Visible = false;
			// 
			// chk_exclude_comp_to_comp
			// 
			chk_exclude_comp_to_comp.AllowDrop = true;
			chk_exclude_comp_to_comp.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_exclude_comp_to_comp.BackColor = System.Drawing.SystemColors.Control;
			chk_exclude_comp_to_comp.CausesValidation = true;
			chk_exclude_comp_to_comp.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_exclude_comp_to_comp.CheckState = System.Windows.Forms.CheckState.Checked;
			chk_exclude_comp_to_comp.Enabled = true;
			chk_exclude_comp_to_comp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_exclude_comp_to_comp.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_exclude_comp_to_comp.Location = new System.Drawing.Point(9, 64);
			chk_exclude_comp_to_comp.Name = "chk_exclude_comp_to_comp";
			chk_exclude_comp_to_comp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_exclude_comp_to_comp.Size = new System.Drawing.Size(224, 16);
			chk_exclude_comp_to_comp.TabIndex = 122;
			chk_exclude_comp_to_comp.TabStop = true;
			chk_exclude_comp_to_comp.Text = "Exclude Company-to-Company Related";
			chk_exclude_comp_to_comp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_exclude_comp_to_comp.Visible = true;
			// 
			// chk_dup_contacts
			// 
			chk_dup_contacts.AllowDrop = true;
			chk_dup_contacts.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_dup_contacts.BackColor = System.Drawing.SystemColors.Control;
			chk_dup_contacts.CausesValidation = true;
			chk_dup_contacts.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_dup_contacts.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_dup_contacts.Enabled = true;
			chk_dup_contacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_dup_contacts.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_dup_contacts.Location = new System.Drawing.Point(9, 41);
			chk_dup_contacts.Name = "chk_dup_contacts";
			chk_dup_contacts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_dup_contacts.Size = new System.Drawing.Size(193, 16);
			chk_dup_contacts.TabIndex = 121;
			chk_dup_contacts.TabStop = true;
			chk_dup_contacts.Text = "Look for Duplicate Contacts";
			chk_dup_contacts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_dup_contacts.Visible = true;
			chk_dup_contacts.CheckStateChanged += new System.EventHandler(chk_dup_contacts_CheckStateChanged);
			// 
			// _opt_dup_sortby_2
			// 
			_opt_dup_sortby_2.AllowDrop = true;
			_opt_dup_sortby_2.BackColor = System.Drawing.SystemColors.Control;
			_opt_dup_sortby_2.CausesValidation = true;
			_opt_dup_sortby_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_2.Checked = false;
			_opt_dup_sortby_2.Enabled = true;
			_opt_dup_sortby_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_dup_sortby_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_dup_sortby_2.Location = new System.Drawing.Point(265, 126);
			_opt_dup_sortby_2.Name = "_opt_dup_sortby_2";
			_opt_dup_sortby_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_dup_sortby_2.Size = new System.Drawing.Size(91, 15);
			_opt_dup_sortby_2.TabIndex = 120;
			_opt_dup_sortby_2.TabStop = true;
			_opt_dup_sortby_2.Text = "Contact Name";
			_opt_dup_sortby_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_dup_sortby_2.Visible = false;
			// 
			// chk_dup_confirm_non_dups
			// 
			chk_dup_confirm_non_dups.AllowDrop = true;
			chk_dup_confirm_non_dups.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_dup_confirm_non_dups.BackColor = System.Drawing.SystemColors.Control;
			chk_dup_confirm_non_dups.CausesValidation = true;
			chk_dup_confirm_non_dups.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_dup_confirm_non_dups.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_dup_confirm_non_dups.Enabled = true;
			chk_dup_confirm_non_dups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_dup_confirm_non_dups.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
			chk_dup_confirm_non_dups.Location = new System.Drawing.Point(281, 75);
			chk_dup_confirm_non_dups.Name = "chk_dup_confirm_non_dups";
			chk_dup_confirm_non_dups.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_dup_confirm_non_dups.Size = new System.Drawing.Size(115, 35);
			chk_dup_confirm_non_dups.TabIndex = 119;
			chk_dup_confirm_non_dups.TabStop = true;
			chk_dup_confirm_non_dups.Text = "Flag Confirmed Non-Duplicates";
			chk_dup_confirm_non_dups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_dup_confirm_non_dups.Visible = true;
			// 
			// _lbl_Label1_32
			// 
			_lbl_Label1_32.AllowDrop = true;
			_lbl_Label1_32.AutoSize = true;
			_lbl_Label1_32.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_32.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_32.Location = new System.Drawing.Point(313, 16);
			_lbl_Label1_32.MinimumSize = new System.Drawing.Size(66, 13);
			_lbl_Label1_32.Name = "_lbl_Label1_32";
			_lbl_Label1_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_32.Size = new System.Drawing.Size(66, 13);
			_lbl_Label1_32.TabIndex = 141;
			_lbl_Label1_32.Text = "Account Rep:";
			// 
			// _lbl_Label1_31
			// 
			_lbl_Label1_31.AllowDrop = true;
			_lbl_Label1_31.AutoSize = true;
			_lbl_Label1_31.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_31.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_31.Location = new System.Drawing.Point(9, 127);
			_lbl_Label1_31.MinimumSize = new System.Drawing.Size(37, 13);
			_lbl_Label1_31.Name = "_lbl_Label1_31";
			_lbl_Label1_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_31.Size = new System.Drawing.Size(37, 13);
			_lbl_Label1_31.TabIndex = 140;
			_lbl_Label1_31.Text = "Sort By:";
			// 
			// _lbl_Label1_30
			// 
			_lbl_Label1_30.AllowDrop = true;
			_lbl_Label1_30.AutoSize = true;
			_lbl_Label1_30.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_30.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_30.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_30.Location = new System.Drawing.Point(9, 106);
			_lbl_Label1_30.MinimumSize = new System.Drawing.Size(38, 13);
			_lbl_Label1_30.Name = "_lbl_Label1_30";
			_lbl_Label1_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_30.Size = new System.Drawing.Size(38, 13);
			_lbl_Label1_30.TabIndex = 139;
			_lbl_Label1_30.Text = "Include:";
			// 
			// _lbl_Label1_29
			// 
			_lbl_Label1_29.AllowDrop = true;
			_lbl_Label1_29.AutoSize = true;
			_lbl_Label1_29.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_29.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_29.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_29.Location = new System.Drawing.Point(9, 85);
			_lbl_Label1_29.MinimumSize = new System.Drawing.Size(179, 13);
			_lbl_Label1_29.Name = "_lbl_Label1_29";
			_lbl_Label1_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_29.Size = new System.Drawing.Size(179, 13);
			_lbl_Label1_29.TabIndex = 138;
			_lbl_Label1_29.Text = "Company Search Name # Characters:";
			// 
			// pnl_aircraft_info
			// 
			pnl_aircraft_info.AllowDrop = true;
			pnl_aircraft_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_aircraft_info.Controls.Add(cbo_cert_drop);
			pnl_aircraft_info.Controls.Add(chk_inactives);
			pnl_aircraft_info.Controls.Add(chk_primary);
			pnl_aircraft_info.Controls.Add(chk_show_yacht_count);
			pnl_aircraft_info.Controls.Add(chk_hide_zero);
			pnl_aircraft_info.Controls.Add(chk_OR);
			pnl_aircraft_info.Controls.Add(_txt_ac_value_1);
			pnl_aircraft_info.Controls.Add(_cbo_compare_1);
			pnl_aircraft_info.Controls.Add(_cbo_owner_type_1);
			pnl_aircraft_info.Controls.Add(_cbo_product_1);
			pnl_aircraft_info.Controls.Add(_cbo_product_0);
			pnl_aircraft_info.Controls.Add(chk_share_relationships_withoutAC);
			pnl_aircraft_info.Controls.Add(chk_share_relationships);
			pnl_aircraft_info.Controls.Add(chk_aircraft_count);
			pnl_aircraft_info.Controls.Add(_cbo_owner_type_0);
			pnl_aircraft_info.Controls.Add(_cbo_compare_0);
			pnl_aircraft_info.Controls.Add(_txt_ac_value_0);
			pnl_aircraft_info.Controls.Add(_lbl_Label1_12);
			pnl_aircraft_info.Controls.Add(_lbl_Label1_13);
			pnl_aircraft_info.Controls.Add(_lbl_Label1_14);
			pnl_aircraft_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_aircraft_info.Location = new System.Drawing.Point(570, 52);
			pnl_aircraft_info.Name = "pnl_aircraft_info";
			pnl_aircraft_info.Size = new System.Drawing.Size(266, 173);
			pnl_aircraft_info.TabIndex = 32;
			// 
			// cbo_cert_drop
			// 
			cbo_cert_drop.AllowDrop = true;
			cbo_cert_drop.BackColor = System.Drawing.SystemColors.Window;
			cbo_cert_drop.CausesValidation = true;
			cbo_cert_drop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_cert_drop.Enabled = true;
			cbo_cert_drop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_cert_drop.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_cert_drop.IntegralHeight = true;
			cbo_cert_drop.Location = new System.Drawing.Point(176, 84);
			cbo_cert_drop.Name = "cbo_cert_drop";
			cbo_cert_drop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_cert_drop.Size = new System.Drawing.Size(89, 21);
			cbo_cert_drop.Sorted = false;
			cbo_cert_drop.TabIndex = 172;
			cbo_cert_drop.TabStop = true;
			cbo_cert_drop.Visible = true;
			// 
			// chk_inactives
			// 
			chk_inactives.AllowDrop = true;
			chk_inactives.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_inactives.BackColor = System.Drawing.SystemColors.Control;
			chk_inactives.CausesValidation = true;
			chk_inactives.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_inactives.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_inactives.Enabled = true;
			chk_inactives.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_inactives.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_inactives.Location = new System.Drawing.Point(8, 90);
			chk_inactives.Name = "chk_inactives";
			chk_inactives.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_inactives.Size = new System.Drawing.Size(203, 13);
			chk_inactives.TabIndex = 170;
			chk_inactives.TabStop = true;
			chk_inactives.Text = "Show Inactive Companies";
			chk_inactives.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_inactives.Visible = true;
			chk_inactives.CheckStateChanged += new System.EventHandler(chk_inactives_CheckStateChanged);
			// 
			// chk_primary
			// 
			chk_primary.AllowDrop = true;
			chk_primary.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_primary.BackColor = System.Drawing.SystemColors.Control;
			chk_primary.CausesValidation = true;
			chk_primary.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_primary.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_primary.Enabled = true;
			chk_primary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_primary.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_primary.Location = new System.Drawing.Point(206, 152);
			chk_primary.Name = "chk_primary";
			chk_primary.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_primary.Size = new System.Drawing.Size(55, 15);
			chk_primary.TabIndex = 168;
			chk_primary.TabStop = true;
			chk_primary.Text = "Primary";
			chk_primary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_primary.Visible = true;
			// 
			// chk_show_yacht_count
			// 
			chk_show_yacht_count.AllowDrop = true;
			chk_show_yacht_count.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_show_yacht_count.BackColor = System.Drawing.SystemColors.Control;
			chk_show_yacht_count.CausesValidation = true;
			chk_show_yacht_count.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_show_yacht_count.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_show_yacht_count.Enabled = true;
			chk_show_yacht_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_show_yacht_count.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_show_yacht_count.Location = new System.Drawing.Point(101, 152);
			chk_show_yacht_count.Name = "chk_show_yacht_count";
			chk_show_yacht_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_show_yacht_count.Size = new System.Drawing.Size(97, 17);
			chk_show_yacht_count.TabIndex = 165;
			chk_show_yacht_count.TabStop = true;
			chk_show_yacht_count.Text = "Show # Yachts";
			chk_show_yacht_count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_show_yacht_count.Visible = true;
			chk_show_yacht_count.CheckStateChanged += new System.EventHandler(chk_show_yacht_count_CheckStateChanged);
			// 
			// chk_hide_zero
			// 
			chk_hide_zero.AllowDrop = true;
			chk_hide_zero.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_hide_zero.BackColor = System.Drawing.SystemColors.Control;
			chk_hide_zero.CausesValidation = true;
			chk_hide_zero.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_hide_zero.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_hide_zero.Enabled = false;
			chk_hide_zero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_hide_zero.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_hide_zero.Location = new System.Drawing.Point(8, 152);
			chk_hide_zero.Name = "chk_hide_zero";
			chk_hide_zero.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_hide_zero.Size = new System.Drawing.Size(84, 15);
			chk_hide_zero.TabIndex = 45;
			chk_hide_zero.TabStop = true;
			chk_hide_zero.Text = "Hide Zero AC";
			chk_hide_zero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_hide_zero.Visible = true;
			chk_hide_zero.CheckStateChanged += new System.EventHandler(chk_hide_zero_CheckStateChanged);
			// 
			// chk_OR
			// 
			chk_OR.AllowDrop = true;
			chk_OR.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_OR.BackColor = System.Drawing.SystemColors.Control;
			chk_OR.CausesValidation = true;
			chk_OR.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_OR.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_OR.Enabled = true;
			chk_OR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_OR.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_OR.Location = new System.Drawing.Point(5, 47);
			chk_OR.Name = "chk_OR";
			chk_OR.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_OR.Size = new System.Drawing.Size(42, 13);
			chk_OR.TabIndex = 44;
			chk_OR.TabStop = true;
			chk_OR.Text = "OR";
			chk_OR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_OR.Visible = false;
			// 
			// _txt_ac_value_1
			// 
			_txt_ac_value_1.AcceptsReturn = true;
			_txt_ac_value_1.AllowDrop = true;
			_txt_ac_value_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_value_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_value_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_value_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_value_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_value_1.Location = new System.Drawing.Point(225, 58);
			_txt_ac_value_1.MaxLength = 0;
			_txt_ac_value_1.Name = "_txt_ac_value_1";
			_txt_ac_value_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_value_1.Size = new System.Drawing.Size(39, 21);
			_txt_ac_value_1.TabIndex = 43;
			_txt_ac_value_1.TabStop = false;
			_txt_ac_value_1.Visible = false;
			_txt_ac_value_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_ac_value_KeyPress);
			// 
			// _cbo_compare_1
			// 
			_cbo_compare_1.AllowDrop = true;
			_cbo_compare_1.BackColor = System.Drawing.SystemColors.Window;
			_cbo_compare_1.CausesValidation = true;
			_cbo_compare_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_compare_1.Enabled = true;
			_cbo_compare_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_compare_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_compare_1.IntegralHeight = true;
			_cbo_compare_1.Location = new System.Drawing.Point(190, 59);
			_cbo_compare_1.Name = "_cbo_compare_1";
			_cbo_compare_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_compare_1.Size = new System.Drawing.Size(33, 21);
			_cbo_compare_1.Sorted = false;
			_cbo_compare_1.TabIndex = 42;
			_cbo_compare_1.TabStop = false;
			_cbo_compare_1.Visible = false;
			// 
			// _cbo_owner_type_1
			// 
			_cbo_owner_type_1.AllowDrop = true;
			_cbo_owner_type_1.BackColor = System.Drawing.SystemColors.Window;
			_cbo_owner_type_1.CausesValidation = true;
			_cbo_owner_type_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_owner_type_1.Enabled = true;
			_cbo_owner_type_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_owner_type_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_owner_type_1.IntegralHeight = true;
			_cbo_owner_type_1.Location = new System.Drawing.Point(95, 59);
			_cbo_owner_type_1.Name = "_cbo_owner_type_1";
			_cbo_owner_type_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_owner_type_1.Size = new System.Drawing.Size(93, 21);
			_cbo_owner_type_1.Sorted = false;
			_cbo_owner_type_1.TabIndex = 41;
			_cbo_owner_type_1.TabStop = false;
			_cbo_owner_type_1.Visible = false;
			_cbo_owner_type_1.SelectionChangeCommitted += new System.EventHandler(cbo_owner_type_SelectionChangeCommitted);
			// 
			// _cbo_product_1
			// 
			_cbo_product_1.AllowDrop = true;
			_cbo_product_1.BackColor = System.Drawing.SystemColors.Window;
			_cbo_product_1.CausesValidation = true;
			_cbo_product_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_product_1.Enabled = true;
			_cbo_product_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_product_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_product_1.IntegralHeight = true;
			_cbo_product_1.Location = new System.Drawing.Point(5, 59);
			_cbo_product_1.Name = "_cbo_product_1";
			_cbo_product_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_product_1.Size = new System.Drawing.Size(88, 21);
			_cbo_product_1.Sorted = false;
			_cbo_product_1.TabIndex = 40;
			_cbo_product_1.TabStop = true;
			_cbo_product_1.Visible = false;
			_cbo_product_1.SelectionChangeCommitted += new System.EventHandler(cbo_product_SelectionChangeCommitted);
			// 
			// _cbo_product_0
			// 
			_cbo_product_0.AllowDrop = true;
			_cbo_product_0.BackColor = System.Drawing.SystemColors.Window;
			_cbo_product_0.CausesValidation = true;
			_cbo_product_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_product_0.Enabled = true;
			_cbo_product_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_product_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_product_0.IntegralHeight = true;
			_cbo_product_0.Location = new System.Drawing.Point(5, 26);
			_cbo_product_0.Name = "_cbo_product_0";
			_cbo_product_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_product_0.Size = new System.Drawing.Size(88, 21);
			_cbo_product_0.Sorted = false;
			_cbo_product_0.TabIndex = 39;
			_cbo_product_0.TabStop = true;
			_cbo_product_0.Visible = true;
			_cbo_product_0.SelectionChangeCommitted += new System.EventHandler(cbo_product_SelectionChangeCommitted);
			// 
			// chk_share_relationships_withoutAC
			// 
			chk_share_relationships_withoutAC.AllowDrop = true;
			chk_share_relationships_withoutAC.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_share_relationships_withoutAC.BackColor = System.Drawing.SystemColors.Control;
			chk_share_relationships_withoutAC.CausesValidation = true;
			chk_share_relationships_withoutAC.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_share_relationships_withoutAC.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_share_relationships_withoutAC.Enabled = true;
			chk_share_relationships_withoutAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_share_relationships_withoutAC.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_share_relationships_withoutAC.Location = new System.Drawing.Point(8, 120);
			chk_share_relationships_withoutAC.Name = "chk_share_relationships_withoutAC";
			chk_share_relationships_withoutAC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_share_relationships_withoutAC.Size = new System.Drawing.Size(226, 15);
			chk_share_relationships_withoutAC.TabIndex = 38;
			chk_share_relationships_withoutAC.TabStop = true;
			chk_share_relationships_withoutAC.Text = "Show Fractional Affiliates without Aircraft";
			chk_share_relationships_withoutAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_share_relationships_withoutAC.Visible = true;
			chk_share_relationships_withoutAC.CheckStateChanged += new System.EventHandler(chk_share_relationships_withoutAC_CheckStateChanged);
			// 
			// chk_share_relationships
			// 
			chk_share_relationships.AllowDrop = true;
			chk_share_relationships.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_share_relationships.BackColor = System.Drawing.SystemColors.Control;
			chk_share_relationships.CausesValidation = true;
			chk_share_relationships.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_share_relationships.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_share_relationships.Enabled = true;
			chk_share_relationships.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_share_relationships.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_share_relationships.Location = new System.Drawing.Point(8, 104);
			chk_share_relationships.Name = "chk_share_relationships";
			chk_share_relationships.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_share_relationships.Size = new System.Drawing.Size(226, 15);
			chk_share_relationships.TabIndex = 37;
			chk_share_relationships.TabStop = true;
			chk_share_relationships.Text = "Show Fractional Affiliates with Aircraft";
			chk_share_relationships.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_share_relationships.Visible = true;
			chk_share_relationships.CheckStateChanged += new System.EventHandler(chk_share_relationships_CheckStateChanged);
			// 
			// chk_aircraft_count
			// 
			chk_aircraft_count.AllowDrop = true;
			chk_aircraft_count.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_aircraft_count.BackColor = System.Drawing.SystemColors.Control;
			chk_aircraft_count.CausesValidation = true;
			chk_aircraft_count.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_aircraft_count.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_aircraft_count.Enabled = true;
			chk_aircraft_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_aircraft_count.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_aircraft_count.Location = new System.Drawing.Point(8, 136);
			chk_aircraft_count.Name = "chk_aircraft_count";
			chk_aircraft_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_aircraft_count.Size = new System.Drawing.Size(226, 15);
			chk_aircraft_count.TabIndex = 36;
			chk_aircraft_count.TabStop = false;
			chk_aircraft_count.Text = "Show Number of Aircraft Per Company";
			chk_aircraft_count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_aircraft_count.Visible = true;
			chk_aircraft_count.CheckStateChanged += new System.EventHandler(chk_aircraft_count_CheckStateChanged);
			// 
			// _cbo_owner_type_0
			// 
			_cbo_owner_type_0.AllowDrop = true;
			_cbo_owner_type_0.BackColor = System.Drawing.SystemColors.Window;
			_cbo_owner_type_0.CausesValidation = true;
			_cbo_owner_type_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_owner_type_0.Enabled = true;
			_cbo_owner_type_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_owner_type_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_owner_type_0.IntegralHeight = true;
			_cbo_owner_type_0.Location = new System.Drawing.Point(95, 26);
			_cbo_owner_type_0.Name = "_cbo_owner_type_0";
			_cbo_owner_type_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_owner_type_0.Size = new System.Drawing.Size(93, 21);
			_cbo_owner_type_0.Sorted = false;
			_cbo_owner_type_0.TabIndex = 35;
			_cbo_owner_type_0.TabStop = false;
			_cbo_owner_type_0.Visible = false;
			_cbo_owner_type_0.SelectionChangeCommitted += new System.EventHandler(cbo_owner_type_SelectionChangeCommitted);
			// 
			// _cbo_compare_0
			// 
			_cbo_compare_0.AllowDrop = true;
			_cbo_compare_0.BackColor = System.Drawing.SystemColors.Window;
			_cbo_compare_0.CausesValidation = true;
			_cbo_compare_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_compare_0.Enabled = true;
			_cbo_compare_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_compare_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_compare_0.IntegralHeight = true;
			_cbo_compare_0.Location = new System.Drawing.Point(190, 26);
			_cbo_compare_0.Name = "_cbo_compare_0";
			_cbo_compare_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_compare_0.Size = new System.Drawing.Size(33, 21);
			_cbo_compare_0.Sorted = false;
			_cbo_compare_0.TabIndex = 34;
			_cbo_compare_0.TabStop = false;
			_cbo_compare_0.Visible = false;
			// 
			// _txt_ac_value_0
			// 
			_txt_ac_value_0.AcceptsReturn = true;
			_txt_ac_value_0.AllowDrop = true;
			_txt_ac_value_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_value_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_value_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_value_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_value_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_value_0.Location = new System.Drawing.Point(225, 26);
			_txt_ac_value_0.MaxLength = 0;
			_txt_ac_value_0.Name = "_txt_ac_value_0";
			_txt_ac_value_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_value_0.Size = new System.Drawing.Size(39, 20);
			_txt_ac_value_0.TabIndex = 33;
			_txt_ac_value_0.TabStop = false;
			_txt_ac_value_0.Visible = false;
			_txt_ac_value_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_ac_value_KeyPress);
			// 
			// _lbl_Label1_12
			// 
			_lbl_Label1_12.AllowDrop = true;
			_lbl_Label1_12.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_12.Location = new System.Drawing.Point(5, 11);
			_lbl_Label1_12.MinimumSize = new System.Drawing.Size(41, 14);
			_lbl_Label1_12.Name = "_lbl_Label1_12";
			_lbl_Label1_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_12.Size = new System.Drawing.Size(41, 14);
			_lbl_Label1_12.TabIndex = 48;
			_lbl_Label1_12.Text = "Product";
			// 
			// _lbl_Label1_13
			// 
			_lbl_Label1_13.AllowDrop = true;
			_lbl_Label1_13.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_13.Location = new System.Drawing.Point(95, 11);
			_lbl_Label1_13.MinimumSize = new System.Drawing.Size(71, 14);
			_lbl_Label1_13.Name = "_lbl_Label1_13";
			_lbl_Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_13.Size = new System.Drawing.Size(71, 14);
			_lbl_Label1_13.TabIndex = 47;
			_lbl_Label1_13.Text = "Search Type";
			// 
			// _lbl_Label1_14
			// 
			_lbl_Label1_14.AllowDrop = true;
			_lbl_Label1_14.AutoSize = true;
			_lbl_Label1_14.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_14.Location = new System.Drawing.Point(225, 12);
			_lbl_Label1_14.MinimumSize = new System.Drawing.Size(27, 13);
			_lbl_Label1_14.Name = "_lbl_Label1_14";
			_lbl_Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_14.Size = new System.Drawing.Size(27, 13);
			_lbl_Label1_14.TabIndex = 46;
			_lbl_Label1_14.Text = "Value";
			// 
			// pnl_contact
			// 
			pnl_contact.AllowDrop = true;
			pnl_contact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_contact.Controls.Add(lst_title_group);
			pnl_contact.Controls.Add(cbo_contact_title);
			pnl_contact.Controls.Add(txt_contact_email_address);
			pnl_contact.Controls.Add(txt_pnum_number_full);
			pnl_contact.Controls.Add(txt_contact_first_name);
			pnl_contact.Controls.Add(txt_contact_last_name);
			pnl_contact.Controls.Add(_lbl_Label1_20);
			pnl_contact.Controls.Add(_lbl_Label1_17);
			pnl_contact.Controls.Add(_lbl_Label1_19);
			pnl_contact.Controls.Add(_lbl_Label1_18);
			pnl_contact.Controls.Add(_lbl_Label1_16);
			pnl_contact.Controls.Add(_lbl_Label1_15);
			pnl_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_contact.Location = new System.Drawing.Point(573, 53);
			pnl_contact.Name = "pnl_contact";
			pnl_contact.Size = new System.Drawing.Size(266, 173);
			pnl_contact.TabIndex = 49;
			// 
			// lst_title_group
			// 
			lst_title_group.AllowDrop = true;
			lst_title_group.BackColor = System.Drawing.SystemColors.Window;
			lst_title_group.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_title_group.CausesValidation = true;
			lst_title_group.Enabled = true;
			lst_title_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_title_group.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_title_group.IntegralHeight = true;
			lst_title_group.Location = new System.Drawing.Point(74, 60);
			lst_title_group.MultiColumn = false;
			lst_title_group.Name = "lst_title_group";
			lst_title_group.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_title_group.Size = new System.Drawing.Size(177, 44);
			lst_title_group.Sorted = false;
			lst_title_group.TabIndex = 55;
			lst_title_group.TabStop = true;
			lst_title_group.Visible = true;
			lst_title_group.SelectedIndexChanged += new System.EventHandler(lst_title_group_SelectedIndexChanged);
			// 
			// cbo_contact_title
			// 
			cbo_contact_title.AllowDrop = true;
			cbo_contact_title.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact_title.CausesValidation = true;
			cbo_contact_title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_contact_title.Enabled = true;
			cbo_contact_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact_title.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact_title.IntegralHeight = true;
			cbo_contact_title.Location = new System.Drawing.Point(75, 104);
			cbo_contact_title.Name = "cbo_contact_title";
			cbo_contact_title.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact_title.Size = new System.Drawing.Size(177, 21);
			cbo_contact_title.Sorted = false;
			cbo_contact_title.TabIndex = 54;
			cbo_contact_title.TabStop = true;
			cbo_contact_title.Visible = true;
			// 
			// txt_contact_email_address
			// 
			txt_contact_email_address.AcceptsReturn = true;
			txt_contact_email_address.AllowDrop = true;
			txt_contact_email_address.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_email_address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_email_address.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_email_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_email_address.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_email_address.Location = new System.Drawing.Point(74, 149);
			txt_contact_email_address.MaxLength = 0;
			txt_contact_email_address.Name = "txt_contact_email_address";
			txt_contact_email_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_email_address.Size = new System.Drawing.Size(177, 19);
			txt_contact_email_address.TabIndex = 53;
			// 
			// txt_pnum_number_full
			// 
			txt_pnum_number_full.AcceptsReturn = true;
			txt_pnum_number_full.AllowDrop = true;
			txt_pnum_number_full.BackColor = System.Drawing.SystemColors.Window;
			txt_pnum_number_full.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_pnum_number_full.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_pnum_number_full.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_pnum_number_full.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_pnum_number_full.Location = new System.Drawing.Point(74, 128);
			txt_pnum_number_full.MaxLength = 0;
			txt_pnum_number_full.Name = "txt_pnum_number_full";
			txt_pnum_number_full.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_pnum_number_full.Size = new System.Drawing.Size(128, 19);
			txt_pnum_number_full.TabIndex = 52;
			// 
			// txt_contact_first_name
			// 
			txt_contact_first_name.AcceptsReturn = true;
			txt_contact_first_name.AllowDrop = true;
			txt_contact_first_name.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_first_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_first_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_first_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_first_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_first_name.Location = new System.Drawing.Point(74, 39);
			txt_contact_first_name.MaxLength = 0;
			txt_contact_first_name.Name = "txt_contact_first_name";
			txt_contact_first_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_first_name.Size = new System.Drawing.Size(128, 19);
			txt_contact_first_name.TabIndex = 51;
			// 
			// txt_contact_last_name
			// 
			txt_contact_last_name.AcceptsReturn = true;
			txt_contact_last_name.AllowDrop = true;
			txt_contact_last_name.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_last_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_last_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_last_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_last_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_last_name.Location = new System.Drawing.Point(74, 17);
			txt_contact_last_name.MaxLength = 0;
			txt_contact_last_name.Name = "txt_contact_last_name";
			txt_contact_last_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_last_name.Size = new System.Drawing.Size(177, 19);
			txt_contact_last_name.TabIndex = 50;
			// 
			// _lbl_Label1_20
			// 
			_lbl_Label1_20.AllowDrop = true;
			_lbl_Label1_20.AutoSize = true;
			_lbl_Label1_20.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_20.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_20.Location = new System.Drawing.Point(37, 152);
			_lbl_Label1_20.MinimumSize = new System.Drawing.Size(28, 13);
			_lbl_Label1_20.Name = "_lbl_Label1_20";
			_lbl_Label1_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_20.Size = new System.Drawing.Size(28, 13);
			_lbl_Label1_20.TabIndex = 61;
			_lbl_Label1_20.Text = "Email:";
			_lbl_Label1_20.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_17
			// 
			_lbl_Label1_17.AllowDrop = true;
			_lbl_Label1_17.AutoSize = true;
			_lbl_Label1_17.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_17.Location = new System.Drawing.Point(10, 74);
			_lbl_Label1_17.MinimumSize = new System.Drawing.Size(55, 13);
			_lbl_Label1_17.Name = "_lbl_Label1_17";
			_lbl_Label1_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_17.Size = new System.Drawing.Size(55, 13);
			_lbl_Label1_17.TabIndex = 60;
			_lbl_Label1_17.Text = "Title Group:";
			_lbl_Label1_17.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_19
			// 
			_lbl_Label1_19.AllowDrop = true;
			_lbl_Label1_19.AutoSize = true;
			_lbl_Label1_19.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_19.Location = new System.Drawing.Point(31, 131);
			_lbl_Label1_19.MinimumSize = new System.Drawing.Size(34, 13);
			_lbl_Label1_19.Name = "_lbl_Label1_19";
			_lbl_Label1_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_19.Size = new System.Drawing.Size(34, 13);
			_lbl_Label1_19.TabIndex = 59;
			_lbl_Label1_19.Text = "Phone:";
			_lbl_Label1_19.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_18
			// 
			_lbl_Label1_18.AllowDrop = true;
			_lbl_Label1_18.AutoSize = true;
			_lbl_Label1_18.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_18.Location = new System.Drawing.Point(42, 108);
			_lbl_Label1_18.MinimumSize = new System.Drawing.Size(23, 13);
			_lbl_Label1_18.Name = "_lbl_Label1_18";
			_lbl_Label1_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_18.Size = new System.Drawing.Size(23, 13);
			_lbl_Label1_18.TabIndex = 58;
			_lbl_Label1_18.Text = "Title:";
			_lbl_Label1_18.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_16
			// 
			_lbl_Label1_16.AllowDrop = true;
			_lbl_Label1_16.AutoSize = true;
			_lbl_Label1_16.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_16.Location = new System.Drawing.Point(12, 42);
			_lbl_Label1_16.MinimumSize = new System.Drawing.Size(53, 13);
			_lbl_Label1_16.Name = "_lbl_Label1_16";
			_lbl_Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_16.Size = new System.Drawing.Size(53, 13);
			_lbl_Label1_16.TabIndex = 57;
			_lbl_Label1_16.Text = "First Name:";
			_lbl_Label1_16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_15
			// 
			_lbl_Label1_15.AllowDrop = true;
			_lbl_Label1_15.AutoSize = true;
			_lbl_Label1_15.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_15.Location = new System.Drawing.Point(11, 20);
			_lbl_Label1_15.MinimumSize = new System.Drawing.Size(54, 13);
			_lbl_Label1_15.Name = "_lbl_Label1_15";
			_lbl_Label1_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_15.Size = new System.Drawing.Size(54, 13);
			_lbl_Label1_15.TabIndex = 56;
			_lbl_Label1_15.Text = "Last Name:";
			_lbl_Label1_15.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// pnl_company
			// 
			pnl_company.AllowDrop = true;
			pnl_company.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_company.Controls.Add(txt_airport_id_name);
			pnl_company.Controls.Add(txt_cert_search);
			pnl_company.Controls.Add(chkCompContactAddressFlag);
			pnl_company.Controls.Add(dba_check);
			pnl_company.Controls.Add(_txt_company_id_1);
			pnl_company.Controls.Add(txt_comp_name);
			pnl_company.Controls.Add(cbo_business_type);
			pnl_company.Controls.Add(cbo_account_rep);
			pnl_company.Controls.Add(cmd_Add_Company);
			pnl_company.Controls.Add(cmd_AcPros);
			pnl_company.Controls.Add(chk_ACPros);
			pnl_company.Controls.Add(txt_comp_phone);
			pnl_company.Controls.Add(txt_comp_email);
			pnl_company.Controls.Add(_txt_company_id_0);
			pnl_company.Controls.Add(txt_comp_web_address);
			pnl_company.Controls.Add(cbo_agency_type);
			pnl_company.Controls.Add(txt_comp_address);
			pnl_company.Controls.Add(_lbl_Label1_36);
			pnl_company.Controls.Add(_lbl_Label1_35);
			pnl_company.Controls.Add(lbl_dba);
			pnl_company.Controls.Add(_lbl_Label1_34);
			pnl_company.Controls.Add(_lbl_Label1_4);
			pnl_company.Controls.Add(_lbl_Label1_3);
			pnl_company.Controls.Add(_lbl_Label1_6);
			pnl_company.Controls.Add(_lbl_Label1_7);
			pnl_company.Controls.Add(_lbl_Label1_21);
			pnl_company.Controls.Add(_lbl_Label1_5);
			pnl_company.Controls.Add(_lbl_Label1_2);
			pnl_company.Controls.Add(_lbl_Label1_0);
			pnl_company.Controls.Add(_lbl_Label1_1);
			pnl_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_company.Location = new System.Drawing.Point(0, 53);
			pnl_company.Name = "pnl_company";
			pnl_company.Size = new System.Drawing.Size(573, 139);
			pnl_company.TabIndex = 15;
			// 
			// txt_airport_id_name
			// 
			txt_airport_id_name.AcceptsReturn = true;
			txt_airport_id_name.AllowDrop = true;
			txt_airport_id_name.BackColor = System.Drawing.SystemColors.Window;
			txt_airport_id_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_airport_id_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_airport_id_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_airport_id_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_airport_id_name.Location = new System.Drawing.Point(48, 112);
			txt_airport_id_name.MaxLength = 0;
			txt_airport_id_name.Name = "txt_airport_id_name";
			txt_airport_id_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_airport_id_name.Size = new System.Drawing.Size(73, 19);
			txt_airport_id_name.TabIndex = 175;
			// 
			// txt_cert_search
			// 
			txt_cert_search.AcceptsReturn = true;
			txt_cert_search.AllowDrop = true;
			txt_cert_search.BackColor = System.Drawing.SystemColors.Window;
			txt_cert_search.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cert_search.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cert_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cert_search.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cert_search.Location = new System.Drawing.Point(390, 114);
			txt_cert_search.MaxLength = 0;
			txt_cert_search.Name = "txt_cert_search";
			txt_cert_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cert_search.Size = new System.Drawing.Size(179, 19);
			txt_cert_search.TabIndex = 173;
			// 
			// chkCompContactAddressFlag
			// 
			chkCompContactAddressFlag.AllowDrop = true;
			chkCompContactAddressFlag.Appearance = System.Windows.Forms.Appearance.Normal;
			chkCompContactAddressFlag.BackColor = System.Drawing.SystemColors.Control;
			chkCompContactAddressFlag.CausesValidation = true;
			chkCompContactAddressFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCompContactAddressFlag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkCompContactAddressFlag.Enabled = true;
			chkCompContactAddressFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkCompContactAddressFlag.ForeColor = System.Drawing.SystemColors.ControlText;
			chkCompContactAddressFlag.Location = new System.Drawing.Point(84, 94);
			chkCompContactAddressFlag.Name = "chkCompContactAddressFlag";
			chkCompContactAddressFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkCompContactAddressFlag.Size = new System.Drawing.Size(114, 17);
			chkCompContactAddressFlag.TabIndex = 12;
			chkCompContactAddressFlag.TabStop = true;
			chkCompContactAddressFlag.Text = "Individual/Company";
			chkCompContactAddressFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCompContactAddressFlag.Visible = true;
			// 
			// dba_check
			// 
			dba_check.AllowDrop = true;
			dba_check.Appearance = System.Windows.Forms.Appearance.Normal;
			dba_check.BackColor = System.Drawing.SystemColors.Control;
			dba_check.CausesValidation = true;
			dba_check.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			dba_check.CheckState = System.Windows.Forms.CheckState.Checked;
			dba_check.Enabled = true;
			dba_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dba_check.ForeColor = System.Drawing.SystemColors.ControlText;
			dba_check.Location = new System.Drawing.Point(296, 8);
			dba_check.Name = "dba_check";
			dba_check.RightToLeft = System.Windows.Forms.RightToLeft.No;
			dba_check.Size = new System.Drawing.Size(17, 17);
			dba_check.TabIndex = 163;
			dba_check.TabStop = true;
			dba_check.Text = "Check1";
			dba_check.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			dba_check.Visible = true;
			// 
			// _txt_company_id_1
			// 
			_txt_company_id_1.AcceptsReturn = true;
			_txt_company_id_1.AllowDrop = true;
			_txt_company_id_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_company_id_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_company_id_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_company_id_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_company_id_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_company_id_1.Location = new System.Drawing.Point(309, 72);
			_txt_company_id_1.MaxLength = 0;
			_txt_company_id_1.Name = "_txt_company_id_1";
			_txt_company_id_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_company_id_1.Size = new System.Drawing.Size(42, 19);
			_txt_company_id_1.TabIndex = 5;
			_txt_company_id_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_company_id_KeyPress);
			_txt_company_id_1.Leave += new System.EventHandler(txt_company_id_Leave);
			// 
			// txt_comp_name
			// 
			txt_comp_name.AcceptsReturn = true;
			txt_comp_name.AllowDrop = true;
			txt_comp_name.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_name.Location = new System.Drawing.Point(56, 26);
			txt_comp_name.MaxLength = 0;
			txt_comp_name.Name = "txt_comp_name";
			txt_comp_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_name.Size = new System.Drawing.Size(257, 19);
			txt_comp_name.TabIndex = 0;
			// 
			// cbo_business_type
			// 
			cbo_business_type.AllowDrop = true;
			cbo_business_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_business_type.CausesValidation = true;
			cbo_business_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_business_type.Enabled = true;
			cbo_business_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_business_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_business_type.IntegralHeight = true;
			cbo_business_type.Location = new System.Drawing.Point(391, 25);
			cbo_business_type.Name = "cbo_business_type";
			cbo_business_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_business_type.Size = new System.Drawing.Size(178, 21);
			cbo_business_type.Sorted = false;
			cbo_business_type.TabIndex = 7;
			cbo_business_type.TabStop = true;
			cbo_business_type.Text = "cbo_business_type";
			cbo_business_type.Visible = true;
			// 
			// cbo_account_rep
			// 
			cbo_account_rep.AllowDrop = true;
			cbo_account_rep.BackColor = System.Drawing.SystemColors.Window;
			cbo_account_rep.CausesValidation = true;
			cbo_account_rep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_account_rep.Enabled = true;
			cbo_account_rep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_account_rep.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_account_rep.IntegralHeight = true;
			cbo_account_rep.Location = new System.Drawing.Point(391, 1);
			cbo_account_rep.Name = "cbo_account_rep";
			cbo_account_rep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_account_rep.Size = new System.Drawing.Size(178, 21);
			cbo_account_rep.Sorted = false;
			cbo_account_rep.TabIndex = 6;
			cbo_account_rep.TabStop = true;
			cbo_account_rep.Text = "cbo_account_rep";
			cbo_account_rep.Visible = true;
			// 
			// cmd_Add_Company
			// 
			cmd_Add_Company.AllowDrop = true;
			cmd_Add_Company.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Company.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Company.Location = new System.Drawing.Point(274, 93);
			cmd_Add_Company.Name = "cmd_Add_Company";
			cmd_Add_Company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Company.Size = new System.Drawing.Size(80, 19);
			cmd_Add_Company.TabIndex = 14;
			cmd_Add_Company.Text = "&Add Company";
			cmd_Add_Company.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Company.UseVisualStyleBackColor = false;
			cmd_Add_Company.Click += new System.EventHandler(cmd_Add_Company_Click);
			// 
			// cmd_AcPros
			// 
			cmd_AcPros.AllowDrop = true;
			cmd_AcPros.BackColor = System.Drawing.SystemColors.Control;
			cmd_AcPros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_AcPros.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_AcPros.Location = new System.Drawing.Point(202, 93);
			cmd_AcPros.Name = "cmd_AcPros";
			cmd_AcPros.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_AcPros.Size = new System.Drawing.Size(67, 19);
			cmd_AcPros.TabIndex = 13;
			cmd_AcPros.Text = "Find ACPros ";
			cmd_AcPros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_AcPros.UseVisualStyleBackColor = false;
			cmd_AcPros.Visible = false;
			cmd_AcPros.Click += new System.EventHandler(cmd_AcPros_Click);
			// 
			// chk_ACPros
			// 
			chk_ACPros.AllowDrop = true;
			chk_ACPros.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_ACPros.BackColor = System.Drawing.SystemColors.Control;
			chk_ACPros.CausesValidation = true;
			chk_ACPros.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_ACPros.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_ACPros.Enabled = true;
			chk_ACPros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_ACPros.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_ACPros.Location = new System.Drawing.Point(2, 94);
			chk_ACPros.Name = "chk_ACPros";
			chk_ACPros.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_ACPros.Size = new System.Drawing.Size(76, 17);
			chk_ACPros.TabIndex = 11;
			chk_ACPros.TabStop = true;
			chk_ACPros.Text = "ACPros List";
			chk_ACPros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_ACPros.Visible = true;
			// 
			// txt_comp_phone
			// 
			txt_comp_phone.AcceptsReturn = true;
			txt_comp_phone.AllowDrop = true;
			txt_comp_phone.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_phone.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_phone.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_phone.Location = new System.Drawing.Point(56, 71);
			txt_comp_phone.MaxLength = 0;
			txt_comp_phone.Name = "txt_comp_phone";
			txt_comp_phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_phone.Size = new System.Drawing.Size(127, 19);
			txt_comp_phone.TabIndex = 3;
			// 
			// txt_comp_email
			// 
			txt_comp_email.AcceptsReturn = true;
			txt_comp_email.AllowDrop = true;
			txt_comp_email.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_email.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_email.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_email.Location = new System.Drawing.Point(390, 71);
			txt_comp_email.MaxLength = 0;
			txt_comp_email.Name = "txt_comp_email";
			txt_comp_email.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_email.Size = new System.Drawing.Size(179, 19);
			txt_comp_email.TabIndex = 9;
			// 
			// _txt_company_id_0
			// 
			_txt_company_id_0.AcceptsReturn = true;
			_txt_company_id_0.AllowDrop = true;
			_txt_company_id_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_company_id_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_company_id_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_company_id_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_company_id_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_company_id_0.Location = new System.Drawing.Point(208, 71);
			_txt_company_id_0.MaxLength = 0;
			_txt_company_id_0.Name = "_txt_company_id_0";
			_txt_company_id_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_company_id_0.Size = new System.Drawing.Size(57, 19);
			_txt_company_id_0.TabIndex = 4;
			_txt_company_id_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_company_id_KeyPress);
			_txt_company_id_0.Leave += new System.EventHandler(txt_company_id_Leave);
			// 
			// txt_comp_web_address
			// 
			txt_comp_web_address.AcceptsReturn = true;
			txt_comp_web_address.AllowDrop = true;
			txt_comp_web_address.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_web_address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_web_address.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_web_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_web_address.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_web_address.Location = new System.Drawing.Point(390, 92);
			txt_comp_web_address.MaxLength = 0;
			txt_comp_web_address.Name = "txt_comp_web_address";
			txt_comp_web_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_web_address.Size = new System.Drawing.Size(179, 19);
			txt_comp_web_address.TabIndex = 10;
			// 
			// cbo_agency_type
			// 
			cbo_agency_type.AllowDrop = true;
			cbo_agency_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_agency_type.CausesValidation = true;
			cbo_agency_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_agency_type.Enabled = true;
			cbo_agency_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_agency_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_agency_type.IntegralHeight = true;
			cbo_agency_type.Location = new System.Drawing.Point(391, 48);
			cbo_agency_type.Name = "cbo_agency_type";
			cbo_agency_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_agency_type.Size = new System.Drawing.Size(116, 21);
			cbo_agency_type.Sorted = false;
			cbo_agency_type.TabIndex = 8;
			cbo_agency_type.TabStop = true;
			cbo_agency_type.Visible = true;
			// 
			// txt_comp_address
			// 
			txt_comp_address.AcceptsReturn = true;
			txt_comp_address.AllowDrop = true;
			txt_comp_address.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_address.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_address.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_address.Location = new System.Drawing.Point(56, 49);
			txt_comp_address.MaxLength = 0;
			txt_comp_address.Name = "txt_comp_address";
			txt_comp_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_address.Size = new System.Drawing.Size(257, 19);
			txt_comp_address.TabIndex = 2;
			// 
			// _lbl_Label1_36
			// 
			_lbl_Label1_36.AllowDrop = true;
			_lbl_Label1_36.AutoSize = true;
			_lbl_Label1_36.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_36.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_36.Location = new System.Drawing.Point(8, 117);
			_lbl_Label1_36.MinimumSize = new System.Drawing.Size(33, 13);
			_lbl_Label1_36.Name = "_lbl_Label1_36";
			_lbl_Label1_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_36.Size = new System.Drawing.Size(33, 13);
			_lbl_Label1_36.TabIndex = 176;
			_lbl_Label1_36.Text = "Airport:";
			_lbl_Label1_36.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_35
			// 
			_lbl_Label1_35.AllowDrop = true;
			_lbl_Label1_35.AutoSize = true;
			_lbl_Label1_35.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_35.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_35.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_35.Location = new System.Drawing.Point(359, 113);
			_lbl_Label1_35.MinimumSize = new System.Drawing.Size(22, 13);
			_lbl_Label1_35.Name = "_lbl_Label1_35";
			_lbl_Label1_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_35.Size = new System.Drawing.Size(22, 13);
			_lbl_Label1_35.TabIndex = 174;
			_lbl_Label1_35.Text = "Cert:";
			// 
			// lbl_dba
			// 
			lbl_dba.AllowDrop = true;
			lbl_dba.BackColor = System.Drawing.SystemColors.Control;
			lbl_dba.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_dba.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_dba.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_dba.Location = new System.Drawing.Point(128, 8);
			lbl_dba.MinimumSize = new System.Drawing.Size(161, 17);
			lbl_dba.Name = "lbl_dba";
			lbl_dba.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_dba.Size = new System.Drawing.Size(161, 17);
			lbl_dba.TabIndex = 164;
			lbl_dba.Text = "Include DBA In Company Search";
			// 
			// _lbl_Label1_34
			// 
			_lbl_Label1_34.AllowDrop = true;
			_lbl_Label1_34.AutoSize = true;
			_lbl_Label1_34.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_34.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_34.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_34.Location = new System.Drawing.Point(273, 75);
			_lbl_Label1_34.MinimumSize = new System.Drawing.Size(33, 13);
			_lbl_Label1_34.Name = "_lbl_Label1_34";
			_lbl_Label1_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_34.Size = new System.Drawing.Size(33, 13);
			_lbl_Label1_34.TabIndex = 148;
			_lbl_Label1_34.Text = "SubID:";
			// 
			// _lbl_Label1_4
			// 
			_lbl_Label1_4.AllowDrop = true;
			_lbl_Label1_4.AutoSize = true;
			_lbl_Label1_4.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_4.Location = new System.Drawing.Point(317, 29);
			_lbl_Label1_4.MinimumSize = new System.Drawing.Size(72, 13);
			_lbl_Label1_4.Name = "_lbl_Label1_4";
			_lbl_Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_4.Size = new System.Drawing.Size(72, 13);
			_lbl_Label1_4.TabIndex = 24;
			_lbl_Label1_4.Text = "Business Type:";
			_lbl_Label1_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_3
			// 
			_lbl_Label1_3.AllowDrop = true;
			_lbl_Label1_3.AutoSize = true;
			_lbl_Label1_3.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_3.Location = new System.Drawing.Point(323, 5);
			_lbl_Label1_3.MinimumSize = new System.Drawing.Size(66, 13);
			_lbl_Label1_3.Name = "_lbl_Label1_3";
			_lbl_Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_3.Size = new System.Drawing.Size(66, 13);
			_lbl_Label1_3.TabIndex = 23;
			_lbl_Label1_3.Text = "Account Rep:";
			_lbl_Label1_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_6
			// 
			_lbl_Label1_6.AllowDrop = true;
			_lbl_Label1_6.AutoSize = true;
			_lbl_Label1_6.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_6.Location = new System.Drawing.Point(358, 74);
			_lbl_Label1_6.MinimumSize = new System.Drawing.Size(28, 13);
			_lbl_Label1_6.Name = "_lbl_Label1_6";
			_lbl_Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_6.Size = new System.Drawing.Size(28, 13);
			_lbl_Label1_6.TabIndex = 22;
			_lbl_Label1_6.Text = "Email:";
			// 
			// _lbl_Label1_7
			// 
			_lbl_Label1_7.AllowDrop = true;
			_lbl_Label1_7.AutoSize = true;
			_lbl_Label1_7.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_7.Location = new System.Drawing.Point(359, 95);
			_lbl_Label1_7.MinimumSize = new System.Drawing.Size(28, 13);
			_lbl_Label1_7.Name = "_lbl_Label1_7";
			_lbl_Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_7.Size = new System.Drawing.Size(28, 13);
			_lbl_Label1_7.TabIndex = 21;
			_lbl_Label1_7.Text = "Web:";
			// 
			// _lbl_Label1_21
			// 
			_lbl_Label1_21.AllowDrop = true;
			_lbl_Label1_21.AutoSize = true;
			_lbl_Label1_21.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_21.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_21.Location = new System.Drawing.Point(188, 74);
			_lbl_Label1_21.MinimumSize = new System.Drawing.Size(14, 13);
			_lbl_Label1_21.Name = "_lbl_Label1_21";
			_lbl_Label1_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_21.Size = new System.Drawing.Size(14, 13);
			_lbl_Label1_21.TabIndex = 20;
			_lbl_Label1_21.Text = "ID:";
			// 
			// _lbl_Label1_5
			// 
			_lbl_Label1_5.AllowDrop = true;
			_lbl_Label1_5.AutoSize = true;
			_lbl_Label1_5.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_5.Location = new System.Drawing.Point(323, 52);
			_lbl_Label1_5.MinimumSize = new System.Drawing.Size(66, 13);
			_lbl_Label1_5.Name = "_lbl_Label1_5";
			_lbl_Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_5.Size = new System.Drawing.Size(66, 13);
			_lbl_Label1_5.TabIndex = 19;
			_lbl_Label1_5.Text = "Agency Type:";
			_lbl_Label1_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_2
			// 
			_lbl_Label1_2.AllowDrop = true;
			_lbl_Label1_2.AutoSize = true;
			_lbl_Label1_2.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_2.Location = new System.Drawing.Point(19, 74);
			_lbl_Label1_2.MinimumSize = new System.Drawing.Size(34, 13);
			_lbl_Label1_2.Name = "_lbl_Label1_2";
			_lbl_Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_2.Size = new System.Drawing.Size(34, 13);
			_lbl_Label1_2.TabIndex = 18;
			_lbl_Label1_2.Text = "Phone:";
			_lbl_Label1_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_0
			// 
			_lbl_Label1_0.AllowDrop = true;
			_lbl_Label1_0.AutoSize = true;
			_lbl_Label1_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_0.Location = new System.Drawing.Point(6, 29);
			_lbl_Label1_0.MinimumSize = new System.Drawing.Size(47, 13);
			_lbl_Label1_0.Name = "_lbl_Label1_0";
			_lbl_Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_0.Size = new System.Drawing.Size(47, 13);
			_lbl_Label1_0.TabIndex = 17;
			_lbl_Label1_0.Text = "Company:";
			_lbl_Label1_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Label1_1
			// 
			_lbl_Label1_1.AllowDrop = true;
			_lbl_Label1_1.AutoSize = true;
			_lbl_Label1_1.BackColor = System.Drawing.Color.Transparent;
			_lbl_Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Label1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Label1_1.Location = new System.Drawing.Point(12, 52);
			_lbl_Label1_1.MinimumSize = new System.Drawing.Size(41, 13);
			_lbl_Label1_1.Name = "_lbl_Label1_1";
			_lbl_Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Label1_1.Size = new System.Drawing.Size(41, 13);
			_lbl_Label1_1.TabIndex = 16;
			_lbl_Label1_1.Text = "Address:";
			_lbl_Label1_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbl_List
			// 
			lbl_List.AllowDrop = true;
			lbl_List.BackColor = System.Drawing.Color.Transparent;
			lbl_List.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_List.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_List.Location = new System.Drawing.Point(576, 232);
			lbl_List.MinimumSize = new System.Drawing.Size(33, 25);
			lbl_List.Name = "lbl_List";
			lbl_List.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_List.Size = new System.Drawing.Size(33, 25);
			lbl_List.TabIndex = 150;
			lbl_List.Text = "List:";
			// 
			// ln_line1
			// 
			ln_line1.AllowDrop = true;
			ln_line1.BackColor = System.Drawing.SystemColors.WindowText;
			ln_line1.Enabled = false;
			ln_line1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ln_line1.Location = new System.Drawing.Point(-2, 259);
			ln_line1.Name = "ln_line1";
			ln_line1.Size = new System.Drawing.Size(1000, 1);
			ln_line1.Visible = true;
			// 
			// frm_Find_Company
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(1000, 702);
			ControlBox = false;
			Controls.Add(tbr_ToolBar);
			Controls.Add(pnl_prod_code);
			Controls.Add(cbo_MailList);
			Controls.Add(pnl_company_demographics);
			Controls.Add(pnl_search);
			Controls.Add(pnl_wait_text);
			Controls.Add(pnl_display_results);
			Controls.Add(frame_potential_dups_grid);
			Controls.Add(frame_potential_dups);
			Controls.Add(pnl_aircraft_info);
			Controls.Add(pnl_contact);
			Controls.Add(pnl_company);
			Controls.Add(lbl_List);
			Controls.Add(ln_line1);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			KeyPreview = true;
			Location = new System.Drawing.Point(379, 230);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Find_Company";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			ShowInTaskbar = false;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Find Company";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(cmd_Find, 0);
			commandButtonHelper1.SetStyle(cmd_Clear, 0);
			commandButtonHelper1.SetStyle(cmd_Confirm_Contact, 0);
			commandButtonHelper1.SetStyle(cmd_awaiting_docsOK, 0);
			commandButtonHelper1.SetStyle(cmd_Associate, 0);
			commandButtonHelper1.SetStyle(cmd_close_duplicates, 0);
			commandButtonHelper1.SetStyle(cmd_remove_duplicates, 0);
			commandButtonHelper1.SetStyle(cmd_Confirm_Company, 0);
			commandButtonHelper1.SetStyle(cmd_find_duplicate, 0);
			commandButtonHelper1.SetStyle(cmd_Add_contact_trial, 0);
			commandButtonHelper1.SetStyle(cmd_sale_source, 0);
			commandButtonHelper1.SetStyle(cmd_add_to_pub, 0);
			commandButtonHelper1.SetStyle(cmdCompanyListExcelExport, 0);
			commandButtonHelper1.SetStyle(cmd_Refresh, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Contact, 0);
			commandButtonHelper1.SetStyle(cmd_Stop, 0);
			commandButtonHelper1.SetStyle(cmd_dup_hide_grid_frame, 0);
			commandButtonHelper1.SetStyle(cmd_dup_paste_to_clipboard, 0);
			commandButtonHelper1.SetStyle(cmd_dup_stop_grid_fill, 0);
			commandButtonHelper1.SetStyle(cmd_find_potential_dup, 0);
			commandButtonHelper1.SetStyle(cmd_hide_potential_dup_frame, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Company, 0);
			commandButtonHelper1.SetStyle(cmd_AcPros, 0);
			listBoxComboBoxHelper1.SetItemData(lst_aircraft_info, new int[]{0});
			listBoxHelper1.SetSelectionMode(lst_country, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lst_state, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lst_area, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lst_company2, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_company1, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_contact_info, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_aircraft_info, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_duplicates, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_company, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_title_group, System.Windows.Forms.SelectionMode.MultiExtended);
			optionButtonHelper1.SetStyle(_optSearchCust_0, 0);
			optionButtonHelper1.SetStyle(_optSearchCust_1, 0);
			optionButtonHelper1.SetStyle(_optSearchCust_2, 0);
			optionButtonHelper1.SetStyle(_opt_continent_region_0, 0);
			optionButtonHelper1.SetStyle(_opt_continent_region_1, 0);
			optionButtonHelper1.SetStyle(opt_companies, 0);
			optionButtonHelper1.SetStyle(opt_contacts, 0);
			optionButtonHelper1.SetStyle(_opt_dup_sortby_5, 0);
			optionButtonHelper1.SetStyle(_opt_dup_sortby_4, 0);
			optionButtonHelper1.SetStyle(_opt_dup_sortby_3, 0);
			optionButtonHelper1.SetStyle(_opt_dup_sortby_0, 0);
			optionButtonHelper1.SetStyle(_opt_dup_sortby_1, 0);
			optionButtonHelper1.SetStyle(_opt_dup_sortby_6, 0);
			optionButtonHelper1.SetStyle(_opt_dup_sortby_2, 0);
			ToolTipMain.SetToolTip(frmCustomers, "Search for Non-Customers");
			ToolTipMain.SetToolTip(_optSearchCust_0, "Search for Both Customers and Non-Customers");
			ToolTipMain.SetToolTip(_optSearchCust_1, "Search for Customers Only");
			ToolTipMain.SetToolTip(_optSearchCust_2, "Search for Customers Only");
			ToolTipMain.SetToolTip(chkCompRelHide, "Hide Company Relationship.  Will NOT Display on Evolution");
			ToolTipMain.SetToolTip(cmdCompanyListExcelExport, "Click to Export Grid Data To Excel");
			ToolTipMain.SetToolTip(chkCompContactAddressFlag, "Check To Find Company Records Setup For Contact Address");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			KeyDown += new System.Windows.Forms.KeyEventHandler(Form_KeyDown);
			((System.ComponentModel.ISupportInitialize) grd_find_company).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_potential_duplicates).EndInit();
			((System.ComponentModel.ISupportInitialize) listBoxComboBoxHelper1).EndInit();
			tbr_ToolBar.ResumeLayout(false);
			tbr_ToolBar.PerformLayout();
			pnl_prod_code.ResumeLayout(false);
			pnl_prod_code.PerformLayout();
			frmCustomers.ResumeLayout(false);
			frmCustomers.PerformLayout();
			pnl_company_demographics.ResumeLayout(false);
			pnl_company_demographics.PerformLayout();
			pnl_search.ResumeLayout(false);
			pnl_search.PerformLayout();
			pnl_wait_text.ResumeLayout(false);
			pnl_wait_text.PerformLayout();
			pnl_display_results.ResumeLayout(false);
			pnl_display_results.PerformLayout();
			pnl_company_relationships.ResumeLayout(false);
			pnl_company_relationships.PerformLayout();
			pnl_contact_info.ResumeLayout(false);
			pnl_contact_info.PerformLayout();
			frame_awaiting_documentation.ResumeLayout(false);
			frame_awaiting_documentation.PerformLayout();
			pnl_associate_aircraft.ResumeLayout(false);
			pnl_associate_aircraft.PerformLayout();
			pnl_duplicates.ResumeLayout(false);
			pnl_duplicates.PerformLayout();
			pnl_company_info.ResumeLayout(false);
			pnl_company_info.PerformLayout();
			pnl_search_results.ResumeLayout(false);
			pnl_search_results.PerformLayout();
			frame_potential_dups_grid.ResumeLayout(false);
			frame_potential_dups_grid.PerformLayout();
			frame_potential_dups.ResumeLayout(false);
			frame_potential_dups.PerformLayout();
			pnl_aircraft_info.ResumeLayout(false);
			pnl_aircraft_info.PerformLayout();
			pnl_contact.ResumeLayout(false);
			pnl_contact.PerformLayout();
			pnl_company.ResumeLayout(false);
			pnl_company.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializetxt_company_id();
			Initializetxt_ac_value();
			Initializepic_redx();
			Initializeopt_dup_sortby();
			Initializeopt_continent_region();
			InitializeoptSearchCust();
			Initializelbl_Label1();
			Initializechk_prod_code();
			Initializechk_dup_include();
			Initializecbo_product();
			Initializecbo_owner_type();
			Initializecbo_compare();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = JETNET_Homebase.mdi_ResearchAssistant.DefInstance;
			JETNET_Homebase.mdi_ResearchAssistant.DefInstance.Show();
			Form_Initialize();
		}
		void Initializetxt_company_id()
		{
			txt_company_id = new System.Windows.Forms.TextBox[2];
			txt_company_id[1] = _txt_company_id_1;
			txt_company_id[0] = _txt_company_id_0;
		}
		void Initializetxt_ac_value()
		{
			txt_ac_value = new System.Windows.Forms.TextBox[2];
			txt_ac_value[1] = _txt_ac_value_1;
			txt_ac_value[0] = _txt_ac_value_0;
		}
		void Initializepic_redx()
		{
			pic_redx = new System.Windows.Forms.PictureBox[4];
			pic_redx[3] = _pic_redx_3;
			pic_redx[2] = _pic_redx_2;
			pic_redx[1] = _pic_redx_1;
		}
		void Initializeopt_dup_sortby()
		{
			opt_dup_sortby = new System.Windows.Forms.RadioButton[7];
			opt_dup_sortby[5] = _opt_dup_sortby_5;
			opt_dup_sortby[4] = _opt_dup_sortby_4;
			opt_dup_sortby[3] = _opt_dup_sortby_3;
			opt_dup_sortby[0] = _opt_dup_sortby_0;
			opt_dup_sortby[1] = _opt_dup_sortby_1;
			opt_dup_sortby[6] = _opt_dup_sortby_6;
			opt_dup_sortby[2] = _opt_dup_sortby_2;
		}
		void Initializeopt_continent_region()
		{
			opt_continent_region = new System.Windows.Forms.RadioButton[2];
			opt_continent_region[0] = _opt_continent_region_0;
			opt_continent_region[1] = _opt_continent_region_1;
		}
		void InitializeoptSearchCust()
		{
			optSearchCust = new System.Windows.Forms.RadioButton[3];
			optSearchCust[0] = _optSearchCust_0;
			optSearchCust[1] = _optSearchCust_1;
			optSearchCust[2] = _optSearchCust_2;
		}
		void Initializelbl_Label1()
		{
			lbl_Label1 = new System.Windows.Forms.Label[37];
			lbl_Label1[8] = _lbl_Label1_8;
			lbl_Label1[11] = _lbl_Label1_11;
			lbl_Label1[10] = _lbl_Label1_10;
			lbl_Label1[9] = _lbl_Label1_9;
			lbl_Label1[28] = _lbl_Label1_28;
			lbl_Label1[27] = _lbl_Label1_27;
			lbl_Label1[25] = _lbl_Label1_25;
			lbl_Label1[26] = _lbl_Label1_26;
			lbl_Label1[22] = _lbl_Label1_22;
			lbl_Label1[23] = _lbl_Label1_23;
			lbl_Label1[24] = _lbl_Label1_24;
			lbl_Label1[33] = _lbl_Label1_33;
			lbl_Label1[32] = _lbl_Label1_32;
			lbl_Label1[31] = _lbl_Label1_31;
			lbl_Label1[30] = _lbl_Label1_30;
			lbl_Label1[29] = _lbl_Label1_29;
			lbl_Label1[12] = _lbl_Label1_12;
			lbl_Label1[13] = _lbl_Label1_13;
			lbl_Label1[14] = _lbl_Label1_14;
			lbl_Label1[20] = _lbl_Label1_20;
			lbl_Label1[17] = _lbl_Label1_17;
			lbl_Label1[19] = _lbl_Label1_19;
			lbl_Label1[18] = _lbl_Label1_18;
			lbl_Label1[16] = _lbl_Label1_16;
			lbl_Label1[15] = _lbl_Label1_15;
			lbl_Label1[36] = _lbl_Label1_36;
			lbl_Label1[35] = _lbl_Label1_35;
			lbl_Label1[34] = _lbl_Label1_34;
			lbl_Label1[4] = _lbl_Label1_4;
			lbl_Label1[3] = _lbl_Label1_3;
			lbl_Label1[6] = _lbl_Label1_6;
			lbl_Label1[7] = _lbl_Label1_7;
			lbl_Label1[21] = _lbl_Label1_21;
			lbl_Label1[5] = _lbl_Label1_5;
			lbl_Label1[2] = _lbl_Label1_2;
			lbl_Label1[0] = _lbl_Label1_0;
			lbl_Label1[1] = _lbl_Label1_1;
		}
		void Initializechk_prod_code()
		{
			chk_prod_code = new System.Windows.Forms.CheckBox[4];
			chk_prod_code[3] = _chk_prod_code_3;
			chk_prod_code[2] = _chk_prod_code_2;
			chk_prod_code[1] = _chk_prod_code_1;
			chk_prod_code[0] = _chk_prod_code_0;
		}
		void Initializechk_dup_include()
		{
			chk_dup_include = new System.Windows.Forms.CheckBox[3];
			chk_dup_include[2] = _chk_dup_include_2;
			chk_dup_include[1] = _chk_dup_include_1;
			chk_dup_include[0] = _chk_dup_include_0;
		}
		void Initializecbo_product()
		{
			cbo_product = new System.Windows.Forms.ComboBox[2];
			cbo_product[1] = _cbo_product_1;
			cbo_product[0] = _cbo_product_0;
		}
		void Initializecbo_owner_type()
		{
			cbo_owner_type = new System.Windows.Forms.ComboBox[2];
			cbo_owner_type[1] = _cbo_owner_type_1;
			cbo_owner_type[0] = _cbo_owner_type_0;
		}
		void Initializecbo_compare()
		{
			cbo_compare = new System.Windows.Forms.ComboBox[2];
			cbo_compare[1] = _cbo_compare_1;
			cbo_compare[0] = _cbo_compare_0;
		}
		#endregion
	}
}