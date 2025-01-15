
namespace HomebaseAdministrator
{
	partial class frm_CommonLookup
	{

		#region "Upgrade Support "
		private static frm_CommonLookup m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_CommonLookup DefInstance
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
		public static frm_CommonLookup CreateInstance()
		{
			frm_CommonLookup theInstance = new frm_CommonLookup();
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
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileClose", "mnuFileLogout", "mnuFile", "MainMenu1", "cmd_AppConfig_save", "txt_aconfig_ac_pictures", "txt_aconfig_processing", "txt_aconfig_documents", "txt_aconfig_model", "txtColorConfirmDays", "txt_aconfig_fileserver", "txt_aconfig_website", "Label39", "Label38", "Label37", "Label34", "Label32", "Label23", "Label24", "pnl_website_Update_Change", "_tab_Lookup_TabPage0", "retail_check", "send_check", "txt_jcat_used_retail_sales_flag", "txt_jcat_send_to_website", "txt_jcat_subcategory_code", "txt_jcat_subcategory_name", "txt_jcat_category_name", "cmd_Delete_JC", "cmd_Cancel_JC", "cmd_Save_JC", "txt_jcat_category_code", "Label42", "Label41", "Label5", "Label4", "Label3", "Label2", "pnl_JC_Update_Change", "Update_Renamed", "drop_sales", "drop_evo", "drop_cat", "Label40", "Label21", "Label20", "SSPanel1", "fG_JournalCat", "cmd_Add_JC", "tot_number", "total_cat", "pnl_JC_List", "_tab_Lookup_TabPage1", "Label50", "txtUserCellNbr", "chkTeamLeaderReportActive", "cmdSaveTeam", "cmbTeamReports", "txtUserTeamLeaderTeam", "Label51", "lblUserTeamLeaderTeam", "frmTeamLeader", "txt_user_description", "chkUserMonitorActivityFlag", "default_browser", "chk_user_report_flag", "chk_user_team_leader_flag", "chk_user_hide_events_flag", "chk_user_delete_attached_ac_specs_flag", "txt_user_marketing_subids_allowed", "chk_user_manage_accounts_flags", "chk_user_subscription_contract_amount", "chk_user_open_multiple_homebase", "chk_user_edit_subscriptions", "chk_user_process_ntsb_reports_flag", "chk_user_process_canadian_reg_flag", "chk_user_process_pubs_flag", "chk_run_account_management_reports_flag", "chk_remove_journal_subject_flag", "Label6", "user_delete_attached_ac_specs_flag", "txt_user_email_address", "chk_user_logged_in", "cmbDefaultAirframe", "chkAutoCallback", "txt_user_id", "txt_user_contact_id", "txt_user_comp_id", "txt_user_default_account_id", "txt_user_phone_no_ext", "txt_user_phone_no", "cbo_user_type", "txt_user_middle_initial", "cmd_Save_User", "cmd_Cancel_User", "cmd_Delete_User", "txt_user_first_name", "txt_user_last_name", "txt_user_password", "Label52", "lbl_user_descrilption", "browser_label", "lbl_user_email_address", "Label1", "lbl_user_entered_by", "lbl_user_entry_date", "Label19", "Label18", "Label17", "Label16", "Label15", "Label14", "Label13", "Label12", "Label11", "Label10", "Label9", "Label8", "Label7", "pnl_User_Update_Change", "FG_Users", "cmd_Add_User", "chkIncludeInactive", "_tab_Lookup_TabPage2", "cmd_Add_Service", "FG_Service", "grd_Subscriptions", "_chk_service_5", "_chk_service_4", "_chk_service_3", "_chk_service_2", "_chk_service_1", "_chk_service_0", "txt_serv_description", "txt_serv_name", "cmd_Delete_Service", "cmd_Cancel_Service", "cmd_Save_Service", "txt_serv_code", "Label30", "Label29", "lbl_serv_upd_date", "lbl_serv_upd_user_id", "Label36", "Label35", "Label33", "Label26", "Label25", "lbl_serv_entry_date", "lbl_serv_entry_user_id", "pnl_Service_Update_Change", "lbl_Subscriptions", "_tab_Lookup_TabPage3", "cmdAddAccountRep", "FG_AccountRep", "cmdAcctRepSave", "cmdAccountRepCancel", "cmdAccountRepDelete", "txt_accrep_user_id", "txt_accrep_description", "txt_accrep_account_type", "txt_accrep_account_id", "Label31", "Label28", "Label27", "Label22", "pnlAcctRepUpdateChange", "_tab_Lookup_TabPage4", "txt_Total_Company_Locked", "txt_Total_Contact_Locked", "txt_Total_Aircraft_Locked", "cmd_Clear_Aircraft_Record_Locks", "cmd_Clear_Contact_Record_locks", "cmd_Clear_Company_Record_Locks", "lbl_locks", "_tab_Lookup_TabPage5", "lblTotalCompOrphanPhoneNbrs", "lblTotalContactOrphanPhoneNbrs", "cmdCheckCompOrphanPhoneNbrs", "cmdCheckContactOrphanPhoneNbrs", "cmdRemoveCompOrphanPhoneNbrs", "cmdRemoveContactOrphanPhoneNbrs", "_tab_Lookup_TabPage6", "cmd_Analyze_Emails", "grd_email", "_tab_Lookup_TabPage7", "txt_cef_list_select_query", "cbo_Help_Topic", "chk_cef_advanced_search_flag", "txt_cef_values", "txt_cef_definition", "cbo_tab", "cmd_run_summary_query", "cmd_delete", "btn_update_sub_group", "cbo_sub_number", "btn_test_query", "cbo_sort", "chk_summary_level", "txt_sub_group", "cbo_selected_group", "cbo_selected_sub_group", "txt_new_group", "chk_aero", "chk_yacht", "chk_comm", "chk_helicopter", "chk_business", "frame_products", "cbo_field_type", "btn_save", "txt_length", "txt_field_name", "txt_header_name", "txt_display_name", "lbl_client_field", "Label49", "Label48", "Label47", "Label46", "Label45", "lbl_tab", "lbl_sort", "lbl_updated", "lbl_id", "lbl_cef_id", "lbl_length", "lbl_field_mapping", "lbl_display", "lbl_header", "lbl_sup_gruop", "lbl_group", "frame_CustomField", "btn_new", "Label43", "Label44", "cbo_FieldGroups", "list_CustomFields", "cbo_area", "_tabstrip_data_TabPage0", "grid_details", "_tabstrip_data_TabPage1", "tabstrip_data", "btn_send", "cmd_refresh", "cmd_sort_up", "cmd_sort_down", "_tab_Lookup_TabPage8", "_cmd_av_button_5", "_txt_avionics_2", "_cmd_av_button_4", "_lst_av_names_2", "_lst_av_names_1", "_txt_avionics_0", "_cmd_av_button_2", "_cmd_av_button_1", "_lbl_avionics_8", "_lbl_avionics_5", "pnl_yes_no", "_cmd_av_button_0", "_lbl_avionics_7", "_lbl_avionics_3", "_pnl_avionics_1", "_cmd_av_button_3", "_txt_avionics_1", "_lst_av_names_0", "_cbo_avionics_2", "_cbo_avionics_1", "_cbo_avionics_0", "_lbl_avionics_6", "_lbl_avionics_4", "_lbl_avionics_2", "_lbl_avionics_1", "_lbl_avionics_0", "_pnl_avionics_0", "_tab_Lookup_TabPage9", "_cmd_apu_3", "_cmd_apu_2", "_lst_apu_0", "_txt_search_apu_1", "_cmd_apu_1", "_cmd_apu_0", "_txt_search_apu_0", "_lbl_apu_2", "_lbl_apu_1", "_lbl_apu_0", "_tab_Lookup_TabPage10", "_cmd_class_1", "_cmd_class_0", "_cbo_days_1", "_cbo_days_0", "_txt_class_1", "_txt_class_0", "_lbl_apu_8", "_lbl_apu_7", "_lbl_apu_6", "_lbl_apu_5", "frm_edit_class", "lst_class", "_lbl_apu_4", "_lbl_apu_3", "_tab_Lookup_TabPage11", "tab_Lookup", "tbr_ToolBar_Buttons_Button1", "tbr_ToolBar_Buttons_Button2", "tbr_ToolBar_Buttons_Button3", "tbr_ToolBar_Buttons_Button4", "tbr_ToolBar_Buttons_Button5", "tbr_ToolBar_Buttons_Button6", "tbr_ToolBar_Buttons_Button7", "tbr_ToolBar_Buttons_Button8", "tbr_ToolBar", "cbo_avionics", "cbo_days", "chk_service", "cmd_apu", "cmd_av_button", "cmd_class", "lbl_apu", "lbl_avionics", "lst_apu", "lst_av_names", "pnl_avionics", "txt_avionics", "txt_class", "txt_search_apu", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFileLogout;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.Button cmd_AppConfig_save;
		public System.Windows.Forms.TextBox txt_aconfig_ac_pictures;
		public System.Windows.Forms.TextBox txt_aconfig_processing;
		public System.Windows.Forms.TextBox txt_aconfig_documents;
		public System.Windows.Forms.TextBox txt_aconfig_model;
		public System.Windows.Forms.TextBox txtColorConfirmDays;
		public System.Windows.Forms.TextBox txt_aconfig_fileserver;
		public System.Windows.Forms.TextBox txt_aconfig_website;
		public System.Windows.Forms.Label Label39;
		public System.Windows.Forms.Label Label38;
		public System.Windows.Forms.Label Label37;
		public System.Windows.Forms.Label Label34;
		public System.Windows.Forms.Label Label32;
		public System.Windows.Forms.Label Label23;
		public System.Windows.Forms.Label Label24;
		public System.Windows.Forms.Panel pnl_website_Update_Change;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage0;
		public System.Windows.Forms.CheckBox retail_check;
		public System.Windows.Forms.CheckBox send_check;
		public System.Windows.Forms.TextBox txt_jcat_used_retail_sales_flag;
		public System.Windows.Forms.TextBox txt_jcat_send_to_website;
		public System.Windows.Forms.TextBox txt_jcat_subcategory_code;
		public System.Windows.Forms.TextBox txt_jcat_subcategory_name;
		public System.Windows.Forms.TextBox txt_jcat_category_name;
		public System.Windows.Forms.Button cmd_Delete_JC;
		public System.Windows.Forms.Button cmd_Cancel_JC;
		public System.Windows.Forms.Button cmd_Save_JC;
		public System.Windows.Forms.TextBox txt_jcat_category_code;
		public System.Windows.Forms.Label Label42;
		public System.Windows.Forms.Label Label41;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Panel pnl_JC_Update_Change;
		public System.Windows.Forms.Button Update_Renamed;
		public System.Windows.Forms.ComboBox drop_sales;
		public System.Windows.Forms.ComboBox drop_evo;
		public System.Windows.Forms.ComboBox drop_cat;
		public System.Windows.Forms.Label Label40;
		public System.Windows.Forms.Label Label21;
		public System.Windows.Forms.Label Label20;
		public System.Windows.Forms.Panel SSPanel1;
		public UpgradeHelpers.DataGridViewFlex fG_JournalCat;
		public System.Windows.Forms.Button cmd_Add_JC;
		public System.Windows.Forms.Label tot_number;
		public System.Windows.Forms.Label total_cat;
		public System.Windows.Forms.Panel pnl_JC_List;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage1;
		public System.Windows.Forms.Label Label50;
		public System.Windows.Forms.TextBox txtUserCellNbr;
		public System.Windows.Forms.CheckBox chkTeamLeaderReportActive;
		public System.Windows.Forms.Button cmdSaveTeam;
		public System.Windows.Forms.ComboBox cmbTeamReports;
		public System.Windows.Forms.TextBox txtUserTeamLeaderTeam;
		public System.Windows.Forms.Label Label51;
		public System.Windows.Forms.Label lblUserTeamLeaderTeam;
		public System.Windows.Forms.GroupBox frmTeamLeader;
		public System.Windows.Forms.TextBox txt_user_description;
		public System.Windows.Forms.CheckBox chkUserMonitorActivityFlag;
		public System.Windows.Forms.ComboBox default_browser;
		public System.Windows.Forms.CheckBox chk_user_report_flag;
		public System.Windows.Forms.CheckBox chk_user_team_leader_flag;
		public System.Windows.Forms.CheckBox chk_user_hide_events_flag;
		public System.Windows.Forms.CheckBox chk_user_delete_attached_ac_specs_flag;
		public System.Windows.Forms.TextBox txt_user_marketing_subids_allowed;
		public System.Windows.Forms.CheckBox chk_user_manage_accounts_flags;
		public System.Windows.Forms.CheckBox chk_user_subscription_contract_amount;
		public System.Windows.Forms.CheckBox chk_user_open_multiple_homebase;
		public System.Windows.Forms.CheckBox chk_user_edit_subscriptions;
		public System.Windows.Forms.CheckBox chk_user_process_ntsb_reports_flag;
		public System.Windows.Forms.CheckBox chk_user_process_canadian_reg_flag;
		public System.Windows.Forms.CheckBox chk_user_process_pubs_flag;
		public System.Windows.Forms.CheckBox chk_run_account_management_reports_flag;
		public System.Windows.Forms.CheckBox chk_remove_journal_subject_flag;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.GroupBox user_delete_attached_ac_specs_flag;
		public System.Windows.Forms.TextBox txt_user_email_address;
		public System.Windows.Forms.CheckBox chk_user_logged_in;
		public System.Windows.Forms.ComboBox cmbDefaultAirframe;
		public System.Windows.Forms.CheckBox chkAutoCallback;
		public System.Windows.Forms.TextBox txt_user_id;
		public System.Windows.Forms.TextBox txt_user_contact_id;
		public System.Windows.Forms.TextBox txt_user_comp_id;
		public System.Windows.Forms.TextBox txt_user_default_account_id;
		public System.Windows.Forms.TextBox txt_user_phone_no_ext;
		public System.Windows.Forms.TextBox txt_user_phone_no;
		public System.Windows.Forms.ComboBox cbo_user_type;
		public System.Windows.Forms.TextBox txt_user_middle_initial;
		public System.Windows.Forms.Button cmd_Save_User;
		public System.Windows.Forms.Button cmd_Cancel_User;
		public System.Windows.Forms.Button cmd_Delete_User;
		public System.Windows.Forms.TextBox txt_user_first_name;
		public System.Windows.Forms.TextBox txt_user_last_name;
		public System.Windows.Forms.TextBox txt_user_password;
		public System.Windows.Forms.Label Label52;
		public System.Windows.Forms.Label lbl_user_descrilption;
		public System.Windows.Forms.Label browser_label;
		public System.Windows.Forms.Label lbl_user_email_address;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lbl_user_entered_by;
		public System.Windows.Forms.Label lbl_user_entry_date;
		public System.Windows.Forms.Label Label19;
		public System.Windows.Forms.Label Label18;
		public System.Windows.Forms.Label Label17;
		public System.Windows.Forms.Label Label16;
		public System.Windows.Forms.Label Label15;
		public System.Windows.Forms.Label Label14;
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Panel pnl_User_Update_Change;
		public UpgradeHelpers.DataGridViewFlex FG_Users;
		public System.Windows.Forms.Button cmd_Add_User;
		public System.Windows.Forms.CheckBox chkIncludeInactive;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage2;
		public System.Windows.Forms.Button cmd_Add_Service;
		public UpgradeHelpers.DataGridViewFlex FG_Service;
		public UpgradeHelpers.DataGridViewFlex grd_Subscriptions;
		private System.Windows.Forms.CheckBox _chk_service_5;
		private System.Windows.Forms.CheckBox _chk_service_4;
		private System.Windows.Forms.CheckBox _chk_service_3;
		private System.Windows.Forms.CheckBox _chk_service_2;
		private System.Windows.Forms.CheckBox _chk_service_1;
		private System.Windows.Forms.CheckBox _chk_service_0;
		public System.Windows.Forms.TextBox txt_serv_description;
		public System.Windows.Forms.TextBox txt_serv_name;
		public System.Windows.Forms.Button cmd_Delete_Service;
		public System.Windows.Forms.Button cmd_Cancel_Service;
		public System.Windows.Forms.Button cmd_Save_Service;
		public System.Windows.Forms.TextBox txt_serv_code;
		public System.Windows.Forms.Label Label30;
		public System.Windows.Forms.Label Label29;
		public System.Windows.Forms.Label lbl_serv_upd_date;
		public System.Windows.Forms.Label lbl_serv_upd_user_id;
		public System.Windows.Forms.Label Label36;
		public System.Windows.Forms.Label Label35;
		public System.Windows.Forms.Label Label33;
		public System.Windows.Forms.Label Label26;
		public System.Windows.Forms.Label Label25;
		public System.Windows.Forms.Label lbl_serv_entry_date;
		public System.Windows.Forms.Label lbl_serv_entry_user_id;
		public System.Windows.Forms.Panel pnl_Service_Update_Change;
		public System.Windows.Forms.Label lbl_Subscriptions;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage3;
		public System.Windows.Forms.Button cmdAddAccountRep;
		public UpgradeHelpers.DataGridViewFlex FG_AccountRep;
		public System.Windows.Forms.Button cmdAcctRepSave;
		public System.Windows.Forms.Button cmdAccountRepCancel;
		public System.Windows.Forms.Button cmdAccountRepDelete;
		public System.Windows.Forms.TextBox txt_accrep_user_id;
		public System.Windows.Forms.TextBox txt_accrep_description;
		public System.Windows.Forms.TextBox txt_accrep_account_type;
		public System.Windows.Forms.TextBox txt_accrep_account_id;
		public System.Windows.Forms.Label Label31;
		public System.Windows.Forms.Label Label28;
		public System.Windows.Forms.Label Label27;
		public System.Windows.Forms.Label Label22;
		public System.Windows.Forms.Panel pnlAcctRepUpdateChange;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage4;
		public System.Windows.Forms.TextBox txt_Total_Company_Locked;
		public System.Windows.Forms.TextBox txt_Total_Contact_Locked;
		public System.Windows.Forms.TextBox txt_Total_Aircraft_Locked;
		public System.Windows.Forms.Button cmd_Clear_Aircraft_Record_Locks;
		public System.Windows.Forms.Button cmd_Clear_Contact_Record_locks;
		public System.Windows.Forms.Button cmd_Clear_Company_Record_Locks;
		public System.Windows.Forms.Label lbl_locks;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage5;
		public System.Windows.Forms.Label lblTotalCompOrphanPhoneNbrs;
		public System.Windows.Forms.Label lblTotalContactOrphanPhoneNbrs;
		public System.Windows.Forms.Button cmdCheckCompOrphanPhoneNbrs;
		public System.Windows.Forms.Button cmdCheckContactOrphanPhoneNbrs;
		public System.Windows.Forms.Button cmdRemoveCompOrphanPhoneNbrs;
		public System.Windows.Forms.Button cmdRemoveContactOrphanPhoneNbrs;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage6;
		public System.Windows.Forms.Button cmd_Analyze_Emails;
		public UpgradeHelpers.DataGridViewFlex grd_email;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage7;
		public System.Windows.Forms.TextBox txt_cef_list_select_query;
		public System.Windows.Forms.ComboBox cbo_Help_Topic;
		public System.Windows.Forms.CheckBox chk_cef_advanced_search_flag;
		public System.Windows.Forms.TextBox txt_cef_values;
		public System.Windows.Forms.TextBox txt_cef_definition;
		public System.Windows.Forms.ComboBox cbo_tab;
		public System.Windows.Forms.Button cmd_run_summary_query;
		public System.Windows.Forms.Button cmd_delete;
		public System.Windows.Forms.Button btn_update_sub_group;
		public System.Windows.Forms.ComboBox cbo_sub_number;
		public System.Windows.Forms.Button btn_test_query;
		public System.Windows.Forms.ComboBox cbo_sort;
		public System.Windows.Forms.CheckBox chk_summary_level;
		public System.Windows.Forms.TextBox txt_sub_group;
		public System.Windows.Forms.ComboBox cbo_selected_group;
		public System.Windows.Forms.ComboBox cbo_selected_sub_group;
		public System.Windows.Forms.TextBox txt_new_group;
		public System.Windows.Forms.CheckBox chk_aero;
		public System.Windows.Forms.CheckBox chk_yacht;
		public System.Windows.Forms.CheckBox chk_comm;
		public System.Windows.Forms.CheckBox chk_helicopter;
		public System.Windows.Forms.CheckBox chk_business;
		public System.Windows.Forms.GroupBox frame_products;
		public System.Windows.Forms.ComboBox cbo_field_type;
		public System.Windows.Forms.Button btn_save;
		public System.Windows.Forms.TextBox txt_length;
		public System.Windows.Forms.TextBox txt_field_name;
		public System.Windows.Forms.TextBox txt_header_name;
		public System.Windows.Forms.TextBox txt_display_name;
		public System.Windows.Forms.Label lbl_client_field;
		public System.Windows.Forms.Label Label49;
		public System.Windows.Forms.Label Label48;
		public System.Windows.Forms.Label Label47;
		public System.Windows.Forms.Label Label46;
		public System.Windows.Forms.Label Label45;
		public System.Windows.Forms.Label lbl_tab;
		public System.Windows.Forms.Label lbl_sort;
		public System.Windows.Forms.Label lbl_updated;
		public System.Windows.Forms.Label lbl_id;
		public System.Windows.Forms.Label lbl_cef_id;
		public System.Windows.Forms.Label lbl_length;
		public System.Windows.Forms.Label lbl_field_mapping;
		public System.Windows.Forms.Label lbl_display;
		public System.Windows.Forms.Label lbl_header;
		public System.Windows.Forms.Label lbl_sup_gruop;
		public System.Windows.Forms.Label lbl_group;
		public System.Windows.Forms.GroupBox frame_CustomField;
		public System.Windows.Forms.Button btn_new;
		public System.Windows.Forms.Label Label43;
		public System.Windows.Forms.Label Label44;
		public System.Windows.Forms.ComboBox cbo_FieldGroups;
		public System.Windows.Forms.ListBox list_CustomFields;
		public System.Windows.Forms.ComboBox cbo_area;
		private System.Windows.Forms.TabPage _tabstrip_data_TabPage0;
		public UpgradeHelpers.DataGridViewFlex grid_details;
		private System.Windows.Forms.TabPage _tabstrip_data_TabPage1;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tabstrip_data;
		public System.Windows.Forms.Button btn_send;
		public System.Windows.Forms.Button cmd_refresh;
		public System.Windows.Forms.Button cmd_sort_up;
		public System.Windows.Forms.Button cmd_sort_down;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage8;
		private System.Windows.Forms.Button _cmd_av_button_5;
		private System.Windows.Forms.TextBox _txt_avionics_2;
		private System.Windows.Forms.Button _cmd_av_button_4;
		private System.Windows.Forms.ListBox _lst_av_names_2;
		private System.Windows.Forms.ListBox _lst_av_names_1;
		private System.Windows.Forms.TextBox _txt_avionics_0;
		private System.Windows.Forms.Button _cmd_av_button_2;
		private System.Windows.Forms.Button _cmd_av_button_1;
		private System.Windows.Forms.Label _lbl_avionics_8;
		private System.Windows.Forms.Label _lbl_avionics_5;
		public System.Windows.Forms.Panel pnl_yes_no;
		private System.Windows.Forms.Button _cmd_av_button_0;
		private System.Windows.Forms.Label _lbl_avionics_7;
		private System.Windows.Forms.Label _lbl_avionics_3;
		private System.Windows.Forms.Panel _pnl_avionics_1;
		private System.Windows.Forms.Button _cmd_av_button_3;
		private System.Windows.Forms.TextBox _txt_avionics_1;
		private System.Windows.Forms.ListBox _lst_av_names_0;
		private System.Windows.Forms.ComboBox _cbo_avionics_2;
		private System.Windows.Forms.ComboBox _cbo_avionics_1;
		private System.Windows.Forms.ComboBox _cbo_avionics_0;
		private System.Windows.Forms.Label _lbl_avionics_6;
		private System.Windows.Forms.Label _lbl_avionics_4;
		private System.Windows.Forms.Label _lbl_avionics_2;
		private System.Windows.Forms.Label _lbl_avionics_1;
		private System.Windows.Forms.Label _lbl_avionics_0;
		private System.Windows.Forms.Panel _pnl_avionics_0;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage9;
		private System.Windows.Forms.Button _cmd_apu_3;
		private System.Windows.Forms.Button _cmd_apu_2;
		private System.Windows.Forms.ListBox _lst_apu_0;
		private System.Windows.Forms.TextBox _txt_search_apu_1;
		private System.Windows.Forms.Button _cmd_apu_1;
		private System.Windows.Forms.Button _cmd_apu_0;
		private System.Windows.Forms.TextBox _txt_search_apu_0;
		private System.Windows.Forms.Label _lbl_apu_2;
		private System.Windows.Forms.Label _lbl_apu_1;
		private System.Windows.Forms.Label _lbl_apu_0;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage10;
		private System.Windows.Forms.Button _cmd_class_1;
		private System.Windows.Forms.Button _cmd_class_0;
		private System.Windows.Forms.ComboBox _cbo_days_1;
		private System.Windows.Forms.ComboBox _cbo_days_0;
		private System.Windows.Forms.TextBox _txt_class_1;
		private System.Windows.Forms.TextBox _txt_class_0;
		private System.Windows.Forms.Label _lbl_apu_8;
		private System.Windows.Forms.Label _lbl_apu_7;
		private System.Windows.Forms.Label _lbl_apu_6;
		private System.Windows.Forms.Label _lbl_apu_5;
		public System.Windows.Forms.GroupBox frm_edit_class;
		public System.Windows.Forms.ListBox lst_class;
		private System.Windows.Forms.Label _lbl_apu_4;
		private System.Windows.Forms.Label _lbl_apu_3;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage11;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_Lookup;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button1;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button2;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button3;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button4;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button5;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button6;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button7;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button8;
		public System.Windows.Forms.ToolStrip tbr_ToolBar;
		public System.Windows.Forms.ComboBox[] cbo_avionics = new System.Windows.Forms.ComboBox[3];
		public System.Windows.Forms.ComboBox[] cbo_days = new System.Windows.Forms.ComboBox[2];
		public System.Windows.Forms.CheckBox[] chk_service = new System.Windows.Forms.CheckBox[6];
		public System.Windows.Forms.Button[] cmd_apu = new System.Windows.Forms.Button[4];
		public System.Windows.Forms.Button[] cmd_av_button = new System.Windows.Forms.Button[6];
		public System.Windows.Forms.Button[] cmd_class = new System.Windows.Forms.Button[2];
		public System.Windows.Forms.Label[] lbl_apu = new System.Windows.Forms.Label[9];
		public System.Windows.Forms.Label[] lbl_avionics = new System.Windows.Forms.Label[9];
		public System.Windows.Forms.ListBox[] lst_apu = new System.Windows.Forms.ListBox[1];
		public System.Windows.Forms.ListBox[] lst_av_names = new System.Windows.Forms.ListBox[3];
		public System.Windows.Forms.Panel[] pnl_avionics = new System.Windows.Forms.Panel[2];
		public System.Windows.Forms.TextBox[] txt_avionics = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] txt_class = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.TextBox[] txt_search_apu = new System.Windows.Forms.TextBox[2];
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		private int tab_LookupPreviousTab;
		public System.ComponentModel.ComponentResourceManager resources; //gap-note manual change to assign the toolbar images
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CommonLookup));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileLogout = new System.Windows.Forms.ToolStripMenuItem();
			tab_Lookup = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_Lookup_TabPage0 = new System.Windows.Forms.TabPage();
			pnl_website_Update_Change = new System.Windows.Forms.Panel();
			cmd_AppConfig_save = new System.Windows.Forms.Button();
			txt_aconfig_ac_pictures = new System.Windows.Forms.TextBox();
			txt_aconfig_processing = new System.Windows.Forms.TextBox();
			txt_aconfig_documents = new System.Windows.Forms.TextBox();
			txt_aconfig_model = new System.Windows.Forms.TextBox();
			txtColorConfirmDays = new System.Windows.Forms.TextBox();
			txt_aconfig_fileserver = new System.Windows.Forms.TextBox();
			txt_aconfig_website = new System.Windows.Forms.TextBox();
			Label39 = new System.Windows.Forms.Label();
			Label38 = new System.Windows.Forms.Label();
			Label37 = new System.Windows.Forms.Label();
			Label34 = new System.Windows.Forms.Label();
			Label32 = new System.Windows.Forms.Label();
			Label23 = new System.Windows.Forms.Label();
			Label24 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage1 = new System.Windows.Forms.TabPage();
			pnl_JC_Update_Change = new System.Windows.Forms.Panel();
			retail_check = new System.Windows.Forms.CheckBox();
			send_check = new System.Windows.Forms.CheckBox();
			txt_jcat_used_retail_sales_flag = new System.Windows.Forms.TextBox();
			txt_jcat_send_to_website = new System.Windows.Forms.TextBox();
			txt_jcat_subcategory_code = new System.Windows.Forms.TextBox();
			txt_jcat_subcategory_name = new System.Windows.Forms.TextBox();
			txt_jcat_category_name = new System.Windows.Forms.TextBox();
			cmd_Delete_JC = new System.Windows.Forms.Button();
			cmd_Cancel_JC = new System.Windows.Forms.Button();
			cmd_Save_JC = new System.Windows.Forms.Button();
			txt_jcat_category_code = new System.Windows.Forms.TextBox();
			Label42 = new System.Windows.Forms.Label();
			Label41 = new System.Windows.Forms.Label();
			Label5 = new System.Windows.Forms.Label();
			Label4 = new System.Windows.Forms.Label();
			Label3 = new System.Windows.Forms.Label();
			Label2 = new System.Windows.Forms.Label();
			pnl_JC_List = new System.Windows.Forms.Panel();
			SSPanel1 = new System.Windows.Forms.Panel();
			Update_Renamed = new System.Windows.Forms.Button();
			drop_sales = new System.Windows.Forms.ComboBox();
			drop_evo = new System.Windows.Forms.ComboBox();
			drop_cat = new System.Windows.Forms.ComboBox();
			Label40 = new System.Windows.Forms.Label();
			Label21 = new System.Windows.Forms.Label();
			Label20 = new System.Windows.Forms.Label();
			fG_JournalCat = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_JC = new System.Windows.Forms.Button();
			tot_number = new System.Windows.Forms.Label();
			total_cat = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage2 = new System.Windows.Forms.TabPage();
			Label50 = new System.Windows.Forms.Label();
			pnl_User_Update_Change = new System.Windows.Forms.Panel();
			txtUserCellNbr = new System.Windows.Forms.TextBox();
			frmTeamLeader = new System.Windows.Forms.GroupBox();
			chkTeamLeaderReportActive = new System.Windows.Forms.CheckBox();
			cmdSaveTeam = new System.Windows.Forms.Button();
			cmbTeamReports = new System.Windows.Forms.ComboBox();
			txtUserTeamLeaderTeam = new System.Windows.Forms.TextBox();
			Label51 = new System.Windows.Forms.Label();
			lblUserTeamLeaderTeam = new System.Windows.Forms.Label();
			txt_user_description = new System.Windows.Forms.TextBox();
			chkUserMonitorActivityFlag = new System.Windows.Forms.CheckBox();
			default_browser = new System.Windows.Forms.ComboBox();
			user_delete_attached_ac_specs_flag = new System.Windows.Forms.GroupBox();
			chk_user_report_flag = new System.Windows.Forms.CheckBox();
			chk_user_team_leader_flag = new System.Windows.Forms.CheckBox();
			chk_user_hide_events_flag = new System.Windows.Forms.CheckBox();
			chk_user_delete_attached_ac_specs_flag = new System.Windows.Forms.CheckBox();
			txt_user_marketing_subids_allowed = new System.Windows.Forms.TextBox();
			chk_user_manage_accounts_flags = new System.Windows.Forms.CheckBox();
			chk_user_subscription_contract_amount = new System.Windows.Forms.CheckBox();
			chk_user_open_multiple_homebase = new System.Windows.Forms.CheckBox();
			chk_user_edit_subscriptions = new System.Windows.Forms.CheckBox();
			chk_user_process_ntsb_reports_flag = new System.Windows.Forms.CheckBox();
			chk_user_process_canadian_reg_flag = new System.Windows.Forms.CheckBox();
			chk_user_process_pubs_flag = new System.Windows.Forms.CheckBox();
			chk_run_account_management_reports_flag = new System.Windows.Forms.CheckBox();
			chk_remove_journal_subject_flag = new System.Windows.Forms.CheckBox();
			Label6 = new System.Windows.Forms.Label();
			txt_user_email_address = new System.Windows.Forms.TextBox();
			chk_user_logged_in = new System.Windows.Forms.CheckBox();
			cmbDefaultAirframe = new System.Windows.Forms.ComboBox();
			chkAutoCallback = new System.Windows.Forms.CheckBox();
			txt_user_id = new System.Windows.Forms.TextBox();
			txt_user_contact_id = new System.Windows.Forms.TextBox();
			txt_user_comp_id = new System.Windows.Forms.TextBox();
			txt_user_default_account_id = new System.Windows.Forms.TextBox();
			txt_user_phone_no_ext = new System.Windows.Forms.TextBox();
			txt_user_phone_no = new System.Windows.Forms.TextBox();
			cbo_user_type = new System.Windows.Forms.ComboBox();
			txt_user_middle_initial = new System.Windows.Forms.TextBox();
			cmd_Save_User = new System.Windows.Forms.Button();
			cmd_Cancel_User = new System.Windows.Forms.Button();
			cmd_Delete_User = new System.Windows.Forms.Button();
			txt_user_first_name = new System.Windows.Forms.TextBox();
			txt_user_last_name = new System.Windows.Forms.TextBox();
			txt_user_password = new System.Windows.Forms.TextBox();
			Label52 = new System.Windows.Forms.Label();
			lbl_user_descrilption = new System.Windows.Forms.Label();
			browser_label = new System.Windows.Forms.Label();
			lbl_user_email_address = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			lbl_user_entered_by = new System.Windows.Forms.Label();
			lbl_user_entry_date = new System.Windows.Forms.Label();
			Label19 = new System.Windows.Forms.Label();
			Label18 = new System.Windows.Forms.Label();
			Label17 = new System.Windows.Forms.Label();
			Label16 = new System.Windows.Forms.Label();
			Label15 = new System.Windows.Forms.Label();
			Label14 = new System.Windows.Forms.Label();
			Label13 = new System.Windows.Forms.Label();
			Label12 = new System.Windows.Forms.Label();
			Label11 = new System.Windows.Forms.Label();
			Label10 = new System.Windows.Forms.Label();
			Label9 = new System.Windows.Forms.Label();
			Label8 = new System.Windows.Forms.Label();
			Label7 = new System.Windows.Forms.Label();
			FG_Users = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_User = new System.Windows.Forms.Button();
			chkIncludeInactive = new System.Windows.Forms.CheckBox();
			_tab_Lookup_TabPage3 = new System.Windows.Forms.TabPage();
			cmd_Add_Service = new System.Windows.Forms.Button();
			FG_Service = new UpgradeHelpers.DataGridViewFlex(components);
			grd_Subscriptions = new UpgradeHelpers.DataGridViewFlex(components);
			pnl_Service_Update_Change = new System.Windows.Forms.Panel();
			_chk_service_5 = new System.Windows.Forms.CheckBox();
			_chk_service_4 = new System.Windows.Forms.CheckBox();
			_chk_service_3 = new System.Windows.Forms.CheckBox();
			_chk_service_2 = new System.Windows.Forms.CheckBox();
			_chk_service_1 = new System.Windows.Forms.CheckBox();
			_chk_service_0 = new System.Windows.Forms.CheckBox();
			txt_serv_description = new System.Windows.Forms.TextBox();
			txt_serv_name = new System.Windows.Forms.TextBox();
			cmd_Delete_Service = new System.Windows.Forms.Button();
			cmd_Cancel_Service = new System.Windows.Forms.Button();
			cmd_Save_Service = new System.Windows.Forms.Button();
			txt_serv_code = new System.Windows.Forms.TextBox();
			Label30 = new System.Windows.Forms.Label();
			Label29 = new System.Windows.Forms.Label();
			lbl_serv_upd_date = new System.Windows.Forms.Label();
			lbl_serv_upd_user_id = new System.Windows.Forms.Label();
			Label36 = new System.Windows.Forms.Label();
			Label35 = new System.Windows.Forms.Label();
			Label33 = new System.Windows.Forms.Label();
			Label26 = new System.Windows.Forms.Label();
			Label25 = new System.Windows.Forms.Label();
			lbl_serv_entry_date = new System.Windows.Forms.Label();
			lbl_serv_entry_user_id = new System.Windows.Forms.Label();
			lbl_Subscriptions = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage4 = new System.Windows.Forms.TabPage();
			cmdAddAccountRep = new System.Windows.Forms.Button();
			FG_AccountRep = new UpgradeHelpers.DataGridViewFlex(components);
			pnlAcctRepUpdateChange = new System.Windows.Forms.Panel();
			cmdAcctRepSave = new System.Windows.Forms.Button();
			cmdAccountRepCancel = new System.Windows.Forms.Button();
			cmdAccountRepDelete = new System.Windows.Forms.Button();
			txt_accrep_user_id = new System.Windows.Forms.TextBox();
			txt_accrep_description = new System.Windows.Forms.TextBox();
			txt_accrep_account_type = new System.Windows.Forms.TextBox();
			txt_accrep_account_id = new System.Windows.Forms.TextBox();
			Label31 = new System.Windows.Forms.Label();
			Label28 = new System.Windows.Forms.Label();
			Label27 = new System.Windows.Forms.Label();
			Label22 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage5 = new System.Windows.Forms.TabPage();
			txt_Total_Company_Locked = new System.Windows.Forms.TextBox();
			txt_Total_Contact_Locked = new System.Windows.Forms.TextBox();
			txt_Total_Aircraft_Locked = new System.Windows.Forms.TextBox();
			cmd_Clear_Aircraft_Record_Locks = new System.Windows.Forms.Button();
			cmd_Clear_Contact_Record_locks = new System.Windows.Forms.Button();
			cmd_Clear_Company_Record_Locks = new System.Windows.Forms.Button();
			lbl_locks = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage6 = new System.Windows.Forms.TabPage();
			lblTotalCompOrphanPhoneNbrs = new System.Windows.Forms.Label();
			lblTotalContactOrphanPhoneNbrs = new System.Windows.Forms.Label();
			cmdCheckCompOrphanPhoneNbrs = new System.Windows.Forms.Button();
			cmdCheckContactOrphanPhoneNbrs = new System.Windows.Forms.Button();
			cmdRemoveCompOrphanPhoneNbrs = new System.Windows.Forms.Button();
			cmdRemoveContactOrphanPhoneNbrs = new System.Windows.Forms.Button();
			_tab_Lookup_TabPage7 = new System.Windows.Forms.TabPage();
			cmd_Analyze_Emails = new System.Windows.Forms.Button();
			grd_email = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_Lookup_TabPage8 = new System.Windows.Forms.TabPage();
			frame_CustomField = new System.Windows.Forms.GroupBox();
			txt_cef_list_select_query = new System.Windows.Forms.TextBox();
			cbo_Help_Topic = new System.Windows.Forms.ComboBox();
			chk_cef_advanced_search_flag = new System.Windows.Forms.CheckBox();
			txt_cef_values = new System.Windows.Forms.TextBox();
			txt_cef_definition = new System.Windows.Forms.TextBox();
			cbo_tab = new System.Windows.Forms.ComboBox();
			cmd_run_summary_query = new System.Windows.Forms.Button();
			cmd_delete = new System.Windows.Forms.Button();
			btn_update_sub_group = new System.Windows.Forms.Button();
			cbo_sub_number = new System.Windows.Forms.ComboBox();
			btn_test_query = new System.Windows.Forms.Button();
			cbo_sort = new System.Windows.Forms.ComboBox();
			chk_summary_level = new System.Windows.Forms.CheckBox();
			txt_sub_group = new System.Windows.Forms.TextBox();
			cbo_selected_group = new System.Windows.Forms.ComboBox();
			cbo_selected_sub_group = new System.Windows.Forms.ComboBox();
			txt_new_group = new System.Windows.Forms.TextBox();
			frame_products = new System.Windows.Forms.GroupBox();
			chk_aero = new System.Windows.Forms.CheckBox();
			chk_yacht = new System.Windows.Forms.CheckBox();
			chk_comm = new System.Windows.Forms.CheckBox();
			chk_helicopter = new System.Windows.Forms.CheckBox();
			chk_business = new System.Windows.Forms.CheckBox();
			cbo_field_type = new System.Windows.Forms.ComboBox();
			btn_save = new System.Windows.Forms.Button();
			txt_length = new System.Windows.Forms.TextBox();
			txt_field_name = new System.Windows.Forms.TextBox();
			txt_header_name = new System.Windows.Forms.TextBox();
			txt_display_name = new System.Windows.Forms.TextBox();
			lbl_client_field = new System.Windows.Forms.Label();
			Label49 = new System.Windows.Forms.Label();
			Label48 = new System.Windows.Forms.Label();
			Label47 = new System.Windows.Forms.Label();
			Label46 = new System.Windows.Forms.Label();
			Label45 = new System.Windows.Forms.Label();
			lbl_tab = new System.Windows.Forms.Label();
			lbl_sort = new System.Windows.Forms.Label();
			lbl_updated = new System.Windows.Forms.Label();
			lbl_id = new System.Windows.Forms.Label();
			lbl_cef_id = new System.Windows.Forms.Label();
			lbl_length = new System.Windows.Forms.Label();
			lbl_field_mapping = new System.Windows.Forms.Label();
			lbl_display = new System.Windows.Forms.Label();
			lbl_header = new System.Windows.Forms.Label();
			lbl_sup_gruop = new System.Windows.Forms.Label();
			lbl_group = new System.Windows.Forms.Label();
			btn_new = new System.Windows.Forms.Button();
			tabstrip_data = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tabstrip_data_TabPage0 = new System.Windows.Forms.TabPage();
			Label43 = new System.Windows.Forms.Label();
			Label44 = new System.Windows.Forms.Label();
			cbo_FieldGroups = new System.Windows.Forms.ComboBox();
			list_CustomFields = new System.Windows.Forms.ListBox();
			cbo_area = new System.Windows.Forms.ComboBox();
			_tabstrip_data_TabPage1 = new System.Windows.Forms.TabPage();
			grid_details = new UpgradeHelpers.DataGridViewFlex(components);
			btn_send = new System.Windows.Forms.Button();
			cmd_refresh = new System.Windows.Forms.Button();
			cmd_sort_up = new System.Windows.Forms.Button();
			cmd_sort_down = new System.Windows.Forms.Button();
			_tab_Lookup_TabPage9 = new System.Windows.Forms.TabPage();
			_pnl_avionics_1 = new System.Windows.Forms.Panel();
			_cmd_av_button_5 = new System.Windows.Forms.Button();
			_txt_avionics_2 = new System.Windows.Forms.TextBox();
			_cmd_av_button_4 = new System.Windows.Forms.Button();
			_lst_av_names_2 = new System.Windows.Forms.ListBox();
			_lst_av_names_1 = new System.Windows.Forms.ListBox();
			_txt_avionics_0 = new System.Windows.Forms.TextBox();
			pnl_yes_no = new System.Windows.Forms.Panel();
			_cmd_av_button_2 = new System.Windows.Forms.Button();
			_cmd_av_button_1 = new System.Windows.Forms.Button();
			_lbl_avionics_8 = new System.Windows.Forms.Label();
			_lbl_avionics_5 = new System.Windows.Forms.Label();
			_cmd_av_button_0 = new System.Windows.Forms.Button();
			_lbl_avionics_7 = new System.Windows.Forms.Label();
			_lbl_avionics_3 = new System.Windows.Forms.Label();
			_pnl_avionics_0 = new System.Windows.Forms.Panel();
			_cmd_av_button_3 = new System.Windows.Forms.Button();
			_txt_avionics_1 = new System.Windows.Forms.TextBox();
			_lst_av_names_0 = new System.Windows.Forms.ListBox();
			_cbo_avionics_2 = new System.Windows.Forms.ComboBox();
			_cbo_avionics_1 = new System.Windows.Forms.ComboBox();
			_cbo_avionics_0 = new System.Windows.Forms.ComboBox();
			_lbl_avionics_6 = new System.Windows.Forms.Label();
			_lbl_avionics_4 = new System.Windows.Forms.Label();
			_lbl_avionics_2 = new System.Windows.Forms.Label();
			_lbl_avionics_1 = new System.Windows.Forms.Label();
			_lbl_avionics_0 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage10 = new System.Windows.Forms.TabPage();
			_cmd_apu_3 = new System.Windows.Forms.Button();
			_cmd_apu_2 = new System.Windows.Forms.Button();
			_lst_apu_0 = new System.Windows.Forms.ListBox();
			_txt_search_apu_1 = new System.Windows.Forms.TextBox();
			_cmd_apu_1 = new System.Windows.Forms.Button();
			_cmd_apu_0 = new System.Windows.Forms.Button();
			_txt_search_apu_0 = new System.Windows.Forms.TextBox();
			_lbl_apu_2 = new System.Windows.Forms.Label();
			_lbl_apu_1 = new System.Windows.Forms.Label();
			_lbl_apu_0 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage11 = new System.Windows.Forms.TabPage();
			frm_edit_class = new System.Windows.Forms.GroupBox();
			_cmd_class_1 = new System.Windows.Forms.Button();
			_cmd_class_0 = new System.Windows.Forms.Button();
			_cbo_days_1 = new System.Windows.Forms.ComboBox();
			_cbo_days_0 = new System.Windows.Forms.ComboBox();
			_txt_class_1 = new System.Windows.Forms.TextBox();
			_txt_class_0 = new System.Windows.Forms.TextBox();
			_lbl_apu_8 = new System.Windows.Forms.Label();
			_lbl_apu_7 = new System.Windows.Forms.Label();
			_lbl_apu_6 = new System.Windows.Forms.Label();
			_lbl_apu_5 = new System.Windows.Forms.Label();
			lst_class = new System.Windows.Forms.ListBox();
			_lbl_apu_4 = new System.Windows.Forms.Label();
			_lbl_apu_3 = new System.Windows.Forms.Label();
			tbr_ToolBar = new System.Windows.Forms.ToolStrip();
			tbr_ToolBar_Buttons_Button1 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button2 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button3 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button4 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button5 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button6 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button7 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button8 = new System.Windows.Forms.ToolStripButton();
			tab_Lookup.SuspendLayout();
			_tab_Lookup_TabPage0.SuspendLayout();
			pnl_website_Update_Change.SuspendLayout();
			_tab_Lookup_TabPage1.SuspendLayout();
			pnl_JC_Update_Change.SuspendLayout();
			pnl_JC_List.SuspendLayout();
			SSPanel1.SuspendLayout();
			_tab_Lookup_TabPage2.SuspendLayout();
			pnl_User_Update_Change.SuspendLayout();
			frmTeamLeader.SuspendLayout();
			user_delete_attached_ac_specs_flag.SuspendLayout();
			_tab_Lookup_TabPage3.SuspendLayout();
			pnl_Service_Update_Change.SuspendLayout();
			_tab_Lookup_TabPage4.SuspendLayout();
			pnlAcctRepUpdateChange.SuspendLayout();
			_tab_Lookup_TabPage5.SuspendLayout();
			_tab_Lookup_TabPage6.SuspendLayout();
			_tab_Lookup_TabPage7.SuspendLayout();
			_tab_Lookup_TabPage8.SuspendLayout();
			frame_CustomField.SuspendLayout();
			frame_products.SuspendLayout();
			tabstrip_data.SuspendLayout();
			_tabstrip_data_TabPage0.SuspendLayout();
			_tabstrip_data_TabPage1.SuspendLayout();
			_tab_Lookup_TabPage9.SuspendLayout();
			_pnl_avionics_1.SuspendLayout();
			pnl_yes_no.SuspendLayout();
			_pnl_avionics_0.SuspendLayout();
			_tab_Lookup_TabPage10.SuspendLayout();
			_tab_Lookup_TabPage11.SuspendLayout();
			frm_edit_class.SuspendLayout();
			tbr_ToolBar.SuspendLayout();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) fG_JournalCat).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Users).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Service).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Subscriptions).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_AccountRep).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_email).BeginInit();
			((System.ComponentModel.ISupportInitialize) grid_details).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFile});
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
			mnuFileClose.Text = "&Close";
			mnuFileClose.Click += new System.EventHandler(mnuFileClose_Click);
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
			// tab_Lookup
			// 
			tab_Lookup.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_Lookup.AllowDrop = true;
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage0);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage1);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage2);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage3);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage4);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage5);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage6);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage7);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage8);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage9);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage10);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage11);
			tab_Lookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_Lookup.ItemSize = new System.Drawing.Size(252, 18);
			tab_Lookup.Location = new System.Drawing.Point(0, 56);
			tab_Lookup.Multiline = true;
			tab_Lookup.Name = "tab_Lookup";
			tab_Lookup.Size = new System.Drawing.Size(1019, 645);
			tab_Lookup.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_Lookup.TabIndex = 1;
			tab_Lookup.SelectedIndexChanged += new System.EventHandler(tab_Lookup_SelectedIndexChanged);
			// 
			// _tab_Lookup_TabPage0
			// 
			_tab_Lookup_TabPage0.Controls.Add(pnl_website_Update_Change);
			_tab_Lookup_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage0.Text = "Application Configuration";
			// 
			// pnl_website_Update_Change
			// 
			pnl_website_Update_Change.AllowDrop = true;
			pnl_website_Update_Change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_website_Update_Change.Controls.Add(cmd_AppConfig_save);
			pnl_website_Update_Change.Controls.Add(txt_aconfig_ac_pictures);
			pnl_website_Update_Change.Controls.Add(txt_aconfig_processing);
			pnl_website_Update_Change.Controls.Add(txt_aconfig_documents);
			pnl_website_Update_Change.Controls.Add(txt_aconfig_model);
			pnl_website_Update_Change.Controls.Add(txtColorConfirmDays);
			pnl_website_Update_Change.Controls.Add(txt_aconfig_fileserver);
			pnl_website_Update_Change.Controls.Add(txt_aconfig_website);
			pnl_website_Update_Change.Controls.Add(Label39);
			pnl_website_Update_Change.Controls.Add(Label38);
			pnl_website_Update_Change.Controls.Add(Label37);
			pnl_website_Update_Change.Controls.Add(Label34);
			pnl_website_Update_Change.Controls.Add(Label32);
			pnl_website_Update_Change.Controls.Add(Label23);
			pnl_website_Update_Change.Controls.Add(Label24);
			pnl_website_Update_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_website_Update_Change.Location = new System.Drawing.Point(32, 83);
			pnl_website_Update_Change.Name = "pnl_website_Update_Change";
			pnl_website_Update_Change.Size = new System.Drawing.Size(507, 344);
			pnl_website_Update_Change.TabIndex = 2;
			// 
			// cmd_AppConfig_save
			// 
			cmd_AppConfig_save.AllowDrop = true;
			cmd_AppConfig_save.BackColor = System.Drawing.SystemColors.Control;
			cmd_AppConfig_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_AppConfig_save.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_AppConfig_save.Location = new System.Drawing.Point(415, 12);
			cmd_AppConfig_save.Name = "cmd_AppConfig_save";
			cmd_AppConfig_save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_AppConfig_save.Size = new System.Drawing.Size(58, 27);
			cmd_AppConfig_save.TabIndex = 131;
			cmd_AppConfig_save.Text = "Save";
			cmd_AppConfig_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_AppConfig_save.UseVisualStyleBackColor = false;
			cmd_AppConfig_save.Visible = false;
			cmd_AppConfig_save.Click += new System.EventHandler(cmd_AppConfig_save_Click);
			// 
			// txt_aconfig_ac_pictures
			// 
			txt_aconfig_ac_pictures.AcceptsReturn = true;
			txt_aconfig_ac_pictures.AllowDrop = true;
			txt_aconfig_ac_pictures.BackColor = System.Drawing.SystemColors.Window;
			txt_aconfig_ac_pictures.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_aconfig_ac_pictures.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_aconfig_ac_pictures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_aconfig_ac_pictures.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_aconfig_ac_pictures.Location = new System.Drawing.Point(17, 159);
			txt_aconfig_ac_pictures.MaxLength = 80;
			txt_aconfig_ac_pictures.Name = "txt_aconfig_ac_pictures";
			txt_aconfig_ac_pictures.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_aconfig_ac_pictures.Size = new System.Drawing.Size(479, 19);
			txt_aconfig_ac_pictures.TabIndex = 126;
			txt_aconfig_ac_pictures.TextChanged += new System.EventHandler(txt_aconfig_ac_pictures_TextChanged);
			// 
			// txt_aconfig_processing
			// 
			txt_aconfig_processing.AcceptsReturn = true;
			txt_aconfig_processing.AllowDrop = true;
			txt_aconfig_processing.BackColor = System.Drawing.SystemColors.Window;
			txt_aconfig_processing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_aconfig_processing.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_aconfig_processing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_aconfig_processing.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_aconfig_processing.Location = new System.Drawing.Point(17, 236);
			txt_aconfig_processing.MaxLength = 80;
			txt_aconfig_processing.Name = "txt_aconfig_processing";
			txt_aconfig_processing.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_aconfig_processing.Size = new System.Drawing.Size(479, 19);
			txt_aconfig_processing.TabIndex = 124;
			txt_aconfig_processing.TextChanged += new System.EventHandler(txt_aconfig_processing_TextChanged);
			// 
			// txt_aconfig_documents
			// 
			txt_aconfig_documents.AcceptsReturn = true;
			txt_aconfig_documents.AllowDrop = true;
			txt_aconfig_documents.BackColor = System.Drawing.SystemColors.Window;
			txt_aconfig_documents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_aconfig_documents.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_aconfig_documents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_aconfig_documents.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_aconfig_documents.Location = new System.Drawing.Point(17, 198);
			txt_aconfig_documents.MaxLength = 80;
			txt_aconfig_documents.Name = "txt_aconfig_documents";
			txt_aconfig_documents.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_aconfig_documents.Size = new System.Drawing.Size(479, 19);
			txt_aconfig_documents.TabIndex = 122;
			txt_aconfig_documents.TextChanged += new System.EventHandler(txt_aconfig_documents_TextChanged);
			// 
			// txt_aconfig_model
			// 
			txt_aconfig_model.AcceptsReturn = true;
			txt_aconfig_model.AllowDrop = true;
			txt_aconfig_model.BackColor = System.Drawing.SystemColors.Window;
			txt_aconfig_model.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_aconfig_model.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_aconfig_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_aconfig_model.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_aconfig_model.Location = new System.Drawing.Point(17, 121);
			txt_aconfig_model.MaxLength = 80;
			txt_aconfig_model.Name = "txt_aconfig_model";
			txt_aconfig_model.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_aconfig_model.Size = new System.Drawing.Size(479, 19);
			txt_aconfig_model.TabIndex = 120;
			txt_aconfig_model.TextChanged += new System.EventHandler(txt_aconfig_model_TextChanged);
			// 
			// txtColorConfirmDays
			// 
			txtColorConfirmDays.AcceptsReturn = true;
			txtColorConfirmDays.AllowDrop = true;
			txtColorConfirmDays.BackColor = System.Drawing.SystemColors.Window;
			txtColorConfirmDays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtColorConfirmDays.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtColorConfirmDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtColorConfirmDays.ForeColor = System.Drawing.SystemColors.WindowText;
			txtColorConfirmDays.Location = new System.Drawing.Point(17, 273);
			txtColorConfirmDays.MaxLength = 80;
			txtColorConfirmDays.Name = "txtColorConfirmDays";
			txtColorConfirmDays.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtColorConfirmDays.Size = new System.Drawing.Size(44, 19);
			txtColorConfirmDays.TabIndex = 111;
			txtColorConfirmDays.TextChanged += new System.EventHandler(txtColorConfirmDays_TextChanged);
			// 
			// txt_aconfig_fileserver
			// 
			txt_aconfig_fileserver.AcceptsReturn = true;
			txt_aconfig_fileserver.AllowDrop = true;
			txt_aconfig_fileserver.BackColor = System.Drawing.SystemColors.Window;
			txt_aconfig_fileserver.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_aconfig_fileserver.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_aconfig_fileserver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_aconfig_fileserver.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_aconfig_fileserver.Location = new System.Drawing.Point(16, 84);
			txt_aconfig_fileserver.MaxLength = 80;
			txt_aconfig_fileserver.Name = "txt_aconfig_fileserver";
			txt_aconfig_fileserver.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_aconfig_fileserver.Size = new System.Drawing.Size(479, 19);
			txt_aconfig_fileserver.TabIndex = 4;
			txt_aconfig_fileserver.TextChanged += new System.EventHandler(txt_aconfig_fileserver_TextChanged);
			// 
			// txt_aconfig_website
			// 
			txt_aconfig_website.AcceptsReturn = true;
			txt_aconfig_website.AllowDrop = true;
			txt_aconfig_website.BackColor = System.Drawing.SystemColors.Window;
			txt_aconfig_website.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_aconfig_website.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_aconfig_website.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_aconfig_website.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_aconfig_website.Location = new System.Drawing.Point(16, 48);
			txt_aconfig_website.MaxLength = 80;
			txt_aconfig_website.Name = "txt_aconfig_website";
			txt_aconfig_website.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_aconfig_website.Size = new System.Drawing.Size(479, 19);
			txt_aconfig_website.TabIndex = 3;
			txt_aconfig_website.TabStop = false;
			txt_aconfig_website.TextChanged += new System.EventHandler(txt_aconfig_website_TextChanged);
			// 
			// Label39
			// 
			Label39.AllowDrop = true;
			Label39.AutoSize = true;
			Label39.BackColor = System.Drawing.SystemColors.Control;
			Label39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label39.ForeColor = System.Drawing.SystemColors.ControlText;
			Label39.Location = new System.Drawing.Point(17, 145);
			Label39.MinimumSize = new System.Drawing.Size(74, 13);
			Label39.Name = "Label39";
			Label39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label39.Size = new System.Drawing.Size(74, 13);
			Label39.TabIndex = 127;
			Label39.Text = "Aircraft Pictures";
			// 
			// Label38
			// 
			Label38.AllowDrop = true;
			Label38.AutoSize = true;
			Label38.BackColor = System.Drawing.SystemColors.Control;
			Label38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label38.ForeColor = System.Drawing.SystemColors.ControlText;
			Label38.Location = new System.Drawing.Point(17, 223);
			Label38.MinimumSize = new System.Drawing.Size(52, 13);
			Label38.Name = "Label38";
			Label38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label38.Size = new System.Drawing.Size(52, 13);
			Label38.TabIndex = 125;
			Label38.Text = "Processing";
			// 
			// Label37
			// 
			Label37.AllowDrop = true;
			Label37.AutoSize = true;
			Label37.BackColor = System.Drawing.SystemColors.Control;
			Label37.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label37.ForeColor = System.Drawing.SystemColors.ControlText;
			Label37.Location = new System.Drawing.Point(17, 185);
			Label37.MinimumSize = new System.Drawing.Size(54, 13);
			Label37.Name = "Label37";
			Label37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label37.Size = new System.Drawing.Size(54, 13);
			Label37.TabIndex = 123;
			Label37.Text = "Documents";
			// 
			// Label34
			// 
			Label34.AllowDrop = true;
			Label34.AutoSize = true;
			Label34.BackColor = System.Drawing.SystemColors.Control;
			Label34.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label34.ForeColor = System.Drawing.SystemColors.ControlText;
			Label34.Location = new System.Drawing.Point(17, 108);
			Label34.MinimumSize = new System.Drawing.Size(70, 13);
			Label34.Name = "Label34";
			Label34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label34.Size = new System.Drawing.Size(70, 13);
			Label34.TabIndex = 121;
			Label34.Text = "Model Pictures";
			// 
			// Label32
			// 
			Label32.AllowDrop = true;
			Label32.AutoSize = true;
			Label32.BackColor = System.Drawing.SystemColors.Control;
			Label32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label32.ForeColor = System.Drawing.SystemColors.ControlText;
			Label32.Location = new System.Drawing.Point(17, 258);
			Label32.MinimumSize = new System.Drawing.Size(89, 13);
			Label32.Name = "Label32";
			Label32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label32.Size = new System.Drawing.Size(89, 13);
			Label32.TabIndex = 112;
			Label32.Text = "Color Confirm Days";
			// 
			// Label23
			// 
			Label23.AllowDrop = true;
			Label23.AutoSize = true;
			Label23.BackColor = System.Drawing.SystemColors.Control;
			Label23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label23.ForeColor = System.Drawing.SystemColors.ControlText;
			Label23.Location = new System.Drawing.Point(16, 72);
			Label23.MinimumSize = new System.Drawing.Size(50, 13);
			Label23.Name = "Label23";
			Label23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label23.Size = new System.Drawing.Size(50, 13);
			Label23.TabIndex = 6;
			Label23.Text = "File Server";
			// 
			// Label24
			// 
			Label24.AllowDrop = true;
			Label24.AutoSize = true;
			Label24.BackColor = System.Drawing.SystemColors.Control;
			Label24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label24.ForeColor = System.Drawing.SystemColors.ControlText;
			Label24.Location = new System.Drawing.Point(16, 33);
			Label24.MinimumSize = new System.Drawing.Size(44, 13);
			Label24.Name = "Label24";
			Label24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label24.Size = new System.Drawing.Size(44, 13);
			Label24.TabIndex = 5;
			Label24.Text = "Web Site";
			// 
			// _tab_Lookup_TabPage1
			// 
			_tab_Lookup_TabPage1.Controls.Add(pnl_JC_Update_Change);
			_tab_Lookup_TabPage1.Controls.Add(pnl_JC_List);
			_tab_Lookup_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage1.Text = "Journal Category";
			// 
			// pnl_JC_Update_Change
			// 
			pnl_JC_Update_Change.AllowDrop = true;
			pnl_JC_Update_Change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_JC_Update_Change.Controls.Add(retail_check);
			pnl_JC_Update_Change.Controls.Add(send_check);
			pnl_JC_Update_Change.Controls.Add(txt_jcat_used_retail_sales_flag);
			pnl_JC_Update_Change.Controls.Add(txt_jcat_send_to_website);
			pnl_JC_Update_Change.Controls.Add(txt_jcat_subcategory_code);
			pnl_JC_Update_Change.Controls.Add(txt_jcat_subcategory_name);
			pnl_JC_Update_Change.Controls.Add(txt_jcat_category_name);
			pnl_JC_Update_Change.Controls.Add(cmd_Delete_JC);
			pnl_JC_Update_Change.Controls.Add(cmd_Cancel_JC);
			pnl_JC_Update_Change.Controls.Add(cmd_Save_JC);
			pnl_JC_Update_Change.Controls.Add(txt_jcat_category_code);
			pnl_JC_Update_Change.Controls.Add(Label42);
			pnl_JC_Update_Change.Controls.Add(Label41);
			pnl_JC_Update_Change.Controls.Add(Label5);
			pnl_JC_Update_Change.Controls.Add(Label4);
			pnl_JC_Update_Change.Controls.Add(Label3);
			pnl_JC_Update_Change.Controls.Add(Label2);
			pnl_JC_Update_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_JC_Update_Change.Location = new System.Drawing.Point(528, 136);
			pnl_JC_Update_Change.Name = "pnl_JC_Update_Change";
			pnl_JC_Update_Change.Size = new System.Drawing.Size(414, 279);
			pnl_JC_Update_Change.TabIndex = 9;
			pnl_JC_Update_Change.Visible = false;
			// 
			// retail_check
			// 
			retail_check.AllowDrop = true;
			retail_check.Appearance = System.Windows.Forms.Appearance.Normal;
			retail_check.BackColor = System.Drawing.SystemColors.Control;
			retail_check.CausesValidation = true;
			retail_check.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			retail_check.CheckState = System.Windows.Forms.CheckState.Unchecked;
			retail_check.Enabled = true;
			retail_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			retail_check.ForeColor = System.Drawing.SystemColors.ControlText;
			retail_check.Location = new System.Drawing.Point(312, 240);
			retail_check.Name = "retail_check";
			retail_check.RightToLeft = System.Windows.Forms.RightToLeft.No;
			retail_check.Size = new System.Drawing.Size(17, 17);
			retail_check.TabIndex = 153;
			retail_check.TabStop = true;
			retail_check.Text = "";
			retail_check.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			retail_check.Visible = true;
			// 
			// send_check
			// 
			send_check.AllowDrop = true;
			send_check.Appearance = System.Windows.Forms.Appearance.Normal;
			send_check.BackColor = System.Drawing.SystemColors.Control;
			send_check.CausesValidation = true;
			send_check.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			send_check.CheckState = System.Windows.Forms.CheckState.Unchecked;
			send_check.Enabled = true;
			send_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			send_check.ForeColor = System.Drawing.SystemColors.ControlText;
			send_check.Location = new System.Drawing.Point(208, 240);
			send_check.Name = "send_check";
			send_check.RightToLeft = System.Windows.Forms.RightToLeft.No;
			send_check.Size = new System.Drawing.Size(17, 17);
			send_check.TabIndex = 152;
			send_check.TabStop = true;
			send_check.Text = "";
			send_check.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			send_check.Visible = true;
			// 
			// txt_jcat_used_retail_sales_flag
			// 
			txt_jcat_used_retail_sales_flag.AcceptsReturn = true;
			txt_jcat_used_retail_sales_flag.AllowDrop = true;
			txt_jcat_used_retail_sales_flag.BackColor = System.Drawing.SystemColors.Window;
			txt_jcat_used_retail_sales_flag.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_jcat_used_retail_sales_flag.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_jcat_used_retail_sales_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_jcat_used_retail_sales_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_jcat_used_retail_sales_flag.Location = new System.Drawing.Point(328, 240);
			txt_jcat_used_retail_sales_flag.MaxLength = 0;
			txt_jcat_used_retail_sales_flag.Name = "txt_jcat_used_retail_sales_flag";
			txt_jcat_used_retail_sales_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_jcat_used_retail_sales_flag.Size = new System.Drawing.Size(10, 19);
			txt_jcat_used_retail_sales_flag.TabIndex = 149;
			txt_jcat_used_retail_sales_flag.Visible = false;
			// 
			// txt_jcat_send_to_website
			// 
			txt_jcat_send_to_website.AcceptsReturn = true;
			txt_jcat_send_to_website.AllowDrop = true;
			txt_jcat_send_to_website.BackColor = System.Drawing.SystemColors.Window;
			txt_jcat_send_to_website.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_jcat_send_to_website.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_jcat_send_to_website.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_jcat_send_to_website.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_jcat_send_to_website.Location = new System.Drawing.Point(224, 240);
			txt_jcat_send_to_website.MaxLength = 0;
			txt_jcat_send_to_website.Name = "txt_jcat_send_to_website";
			txt_jcat_send_to_website.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_jcat_send_to_website.Size = new System.Drawing.Size(10, 19);
			txt_jcat_send_to_website.TabIndex = 148;
			txt_jcat_send_to_website.Visible = false;
			// 
			// txt_jcat_subcategory_code
			// 
			txt_jcat_subcategory_code.AcceptsReturn = true;
			txt_jcat_subcategory_code.AllowDrop = true;
			txt_jcat_subcategory_code.BackColor = System.Drawing.SystemColors.Window;
			txt_jcat_subcategory_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_jcat_subcategory_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_jcat_subcategory_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_jcat_subcategory_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_jcat_subcategory_code.Location = new System.Drawing.Point(16, 240);
			txt_jcat_subcategory_code.MaxLength = 6;
			txt_jcat_subcategory_code.Name = "txt_jcat_subcategory_code";
			txt_jcat_subcategory_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_jcat_subcategory_code.Size = new System.Drawing.Size(77, 19);
			txt_jcat_subcategory_code.TabIndex = 14;
			// 
			// txt_jcat_subcategory_name
			// 
			txt_jcat_subcategory_name.AcceptsReturn = true;
			txt_jcat_subcategory_name.AllowDrop = true;
			txt_jcat_subcategory_name.BackColor = System.Drawing.SystemColors.Window;
			txt_jcat_subcategory_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_jcat_subcategory_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_jcat_subcategory_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_jcat_subcategory_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_jcat_subcategory_name.Location = new System.Drawing.Point(16, 194);
			txt_jcat_subcategory_name.MaxLength = 50;
			txt_jcat_subcategory_name.Name = "txt_jcat_subcategory_name";
			txt_jcat_subcategory_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_jcat_subcategory_name.Size = new System.Drawing.Size(395, 19);
			txt_jcat_subcategory_name.TabIndex = 13;
			// 
			// txt_jcat_category_name
			// 
			txt_jcat_category_name.AcceptsReturn = true;
			txt_jcat_category_name.AllowDrop = true;
			txt_jcat_category_name.BackColor = System.Drawing.SystemColors.Window;
			txt_jcat_category_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_jcat_category_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_jcat_category_name.Enabled = false;
			txt_jcat_category_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_jcat_category_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_jcat_category_name.Location = new System.Drawing.Point(12, 100);
			txt_jcat_category_name.MaxLength = 50;
			txt_jcat_category_name.Name = "txt_jcat_category_name";
			txt_jcat_category_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_jcat_category_name.Size = new System.Drawing.Size(391, 19);
			txt_jcat_category_name.TabIndex = 10;
			// 
			// cmd_Delete_JC
			// 
			cmd_Delete_JC.AllowDrop = true;
			cmd_Delete_JC.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_JC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_JC.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_JC.Location = new System.Drawing.Point(185, 24);
			cmd_Delete_JC.Name = "cmd_Delete_JC";
			cmd_Delete_JC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_JC.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_JC.TabIndex = 20;
			cmd_Delete_JC.Text = "&Delete";
			cmd_Delete_JC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_JC.UseVisualStyleBackColor = false;
			cmd_Delete_JC.Click += new System.EventHandler(cmd_Delete_JC_Click);
			// 
			// cmd_Cancel_JC
			// 
			cmd_Cancel_JC.AllowDrop = true;
			cmd_Cancel_JC.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_JC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_JC.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_JC.Location = new System.Drawing.Point(98, 24);
			cmd_Cancel_JC.Name = "cmd_Cancel_JC";
			cmd_Cancel_JC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_JC.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_JC.TabIndex = 18;
			cmd_Cancel_JC.Text = "&Cancel";
			cmd_Cancel_JC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_JC.UseVisualStyleBackColor = false;
			cmd_Cancel_JC.Click += new System.EventHandler(cmd_Cancel_JC_Click);
			// 
			// cmd_Save_JC
			// 
			cmd_Save_JC.AllowDrop = true;
			cmd_Save_JC.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_JC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_JC.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_JC.Location = new System.Drawing.Point(12, 24);
			cmd_Save_JC.Name = "cmd_Save_JC";
			cmd_Save_JC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_JC.Size = new System.Drawing.Size(57, 25);
			cmd_Save_JC.TabIndex = 16;
			cmd_Save_JC.Text = "&Save";
			cmd_Save_JC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_JC.UseVisualStyleBackColor = false;
			cmd_Save_JC.Click += new System.EventHandler(cmd_Save_JC_Click);
			// 
			// txt_jcat_category_code
			// 
			txt_jcat_category_code.AcceptsReturn = true;
			txt_jcat_category_code.AllowDrop = true;
			txt_jcat_category_code.BackColor = System.Drawing.SystemColors.Window;
			txt_jcat_category_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_jcat_category_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_jcat_category_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_jcat_category_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_jcat_category_code.Location = new System.Drawing.Point(16, 144);
			txt_jcat_category_code.MaxLength = 2;
			txt_jcat_category_code.Name = "txt_jcat_category_code";
			txt_jcat_category_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_jcat_category_code.Size = new System.Drawing.Size(29, 19);
			txt_jcat_category_code.TabIndex = 12;
			// 
			// Label42
			// 
			Label42.AllowDrop = true;
			Label42.BackColor = System.Drawing.SystemColors.Control;
			Label42.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label42.ForeColor = System.Drawing.SystemColors.ControlText;
			Label42.Location = new System.Drawing.Point(248, 240);
			Label42.MinimumSize = new System.Drawing.Size(65, 17);
			Label42.Name = "Label42";
			Label42.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label42.Size = new System.Drawing.Size(65, 17);
			Label42.TabIndex = 151;
			Label42.Text = "Retail Sales";
			// 
			// Label41
			// 
			Label41.AllowDrop = true;
			Label41.BackColor = System.Drawing.SystemColors.Control;
			Label41.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label41.ForeColor = System.Drawing.SystemColors.ControlText;
			Label41.Location = new System.Drawing.Point(112, 240);
			Label41.MinimumSize = new System.Drawing.Size(113, 25);
			Label41.Name = "Label41";
			Label41.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label41.Size = new System.Drawing.Size(113, 25);
			Label41.TabIndex = 150;
			Label41.Text = "Send To Evolution";
			// 
			// Label5
			// 
			Label5.AllowDrop = true;
			Label5.BackColor = System.Drawing.SystemColors.Control;
			Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			Label5.Location = new System.Drawing.Point(16, 224);
			Label5.MinimumSize = new System.Drawing.Size(143, 17);
			Label5.Name = "Label5";
			Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label5.Size = new System.Drawing.Size(143, 17);
			Label5.TabIndex = 19;
			Label5.Text = "Subcategory Code";
			// 
			// Label4
			// 
			Label4.AllowDrop = true;
			Label4.BackColor = System.Drawing.SystemColors.Control;
			Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			Label4.Location = new System.Drawing.Point(16, 178);
			Label4.MinimumSize = new System.Drawing.Size(139, 17);
			Label4.Name = "Label4";
			Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label4.Size = new System.Drawing.Size(139, 17);
			Label4.TabIndex = 17;
			Label4.Text = "Subcategory Name";
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.BackColor = System.Drawing.SystemColors.Control;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(16, 80);
			Label3.MinimumSize = new System.Drawing.Size(127, 17);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(127, 17);
			Label3.TabIndex = 15;
			Label3.Text = "Category Name";
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.BackColor = System.Drawing.SystemColors.Control;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			Label2.Location = new System.Drawing.Point(16, 130);
			Label2.MinimumSize = new System.Drawing.Size(127, 17);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(127, 17);
			Label2.TabIndex = 11;
			Label2.Text = "Category Code";
			// 
			// pnl_JC_List
			// 
			pnl_JC_List.AllowDrop = true;
			pnl_JC_List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_JC_List.Controls.Add(SSPanel1);
			pnl_JC_List.Controls.Add(fG_JournalCat);
			pnl_JC_List.Controls.Add(cmd_Add_JC);
			pnl_JC_List.Controls.Add(tot_number);
			pnl_JC_List.Controls.Add(total_cat);
			pnl_JC_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_JC_List.Location = new System.Drawing.Point(8, 24);
			pnl_JC_List.Name = "pnl_JC_List";
			pnl_JC_List.Size = new System.Drawing.Size(949, 451);
			pnl_JC_List.TabIndex = 7;
			// 
			// SSPanel1
			// 
			SSPanel1.AllowDrop = true;
			SSPanel1.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			SSPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel1.Controls.Add(Update_Renamed);
			SSPanel1.Controls.Add(drop_sales);
			SSPanel1.Controls.Add(drop_evo);
			SSPanel1.Controls.Add(drop_cat);
			SSPanel1.Controls.Add(Label40);
			SSPanel1.Controls.Add(Label21);
			SSPanel1.Controls.Add(Label20);
			SSPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel1.Location = new System.Drawing.Point(16, 8);
			SSPanel1.Name = "SSPanel1";
			SSPanel1.Size = new System.Drawing.Size(529, 33);
			SSPanel1.TabIndex = 140;
			// 
			// Update_Renamed
			// 
			Update_Renamed.AllowDrop = true;
			Update_Renamed.BackColor = System.Drawing.SystemColors.Control;
			Update_Renamed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Update_Renamed.ForeColor = System.Drawing.SystemColors.ControlText;
			Update_Renamed.Location = new System.Drawing.Point(464, 6);
			Update_Renamed.Name = "Update_Renamed";
			Update_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Update_Renamed.Size = new System.Drawing.Size(57, 25);
			Update_Renamed.TabIndex = 147;
			Update_Renamed.Text = "Search";
			Update_Renamed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			Update_Renamed.UseVisualStyleBackColor = false;
			Update_Renamed.Click += new System.EventHandler(Update_Click);
			// 
			// drop_sales
			// 
			drop_sales.AllowDrop = true;
			drop_sales.BackColor = System.Drawing.SystemColors.Window;
			drop_sales.CausesValidation = true;
			drop_sales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			drop_sales.Enabled = true;
			drop_sales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			drop_sales.ForeColor = System.Drawing.SystemColors.WindowText;
			drop_sales.IntegralHeight = true;
			drop_sales.Location = new System.Drawing.Point(408, 7);
			drop_sales.Name = "drop_sales";
			drop_sales.RightToLeft = System.Windows.Forms.RightToLeft.No;
			drop_sales.Size = new System.Drawing.Size(54, 21);
			drop_sales.Sorted = false;
			drop_sales.TabIndex = 146;
			drop_sales.TabStop = true;
			drop_sales.Visible = true;
			// 
			// drop_evo
			// 
			drop_evo.AllowDrop = true;
			drop_evo.BackColor = System.Drawing.SystemColors.Window;
			drop_evo.CausesValidation = true;
			drop_evo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			drop_evo.Enabled = true;
			drop_evo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			drop_evo.ForeColor = System.Drawing.SystemColors.WindowText;
			drop_evo.IntegralHeight = true;
			drop_evo.Location = new System.Drawing.Point(288, 7);
			drop_evo.Name = "drop_evo";
			drop_evo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			drop_evo.Size = new System.Drawing.Size(54, 21);
			drop_evo.Sorted = false;
			drop_evo.TabIndex = 145;
			drop_evo.TabStop = true;
			drop_evo.Visible = true;
			// 
			// drop_cat
			// 
			drop_cat.AllowDrop = true;
			drop_cat.BackColor = System.Drawing.SystemColors.Window;
			drop_cat.CausesValidation = true;
			drop_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			drop_cat.Enabled = true;
			drop_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			drop_cat.ForeColor = System.Drawing.SystemColors.WindowText;
			drop_cat.IntegralHeight = true;
			drop_cat.Location = new System.Drawing.Point(48, 7);
			drop_cat.Name = "drop_cat";
			drop_cat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			drop_cat.Size = new System.Drawing.Size(169, 21);
			drop_cat.Sorted = false;
			drop_cat.TabIndex = 141;
			drop_cat.TabStop = true;
			drop_cat.Visible = true;
			// 
			// Label40
			// 
			Label40.AllowDrop = true;
			Label40.BackColor = System.Drawing.SystemColors.Control;
			Label40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label40.ForeColor = System.Drawing.SystemColors.ControlText;
			Label40.Location = new System.Drawing.Point(344, 8);
			Label40.MinimumSize = new System.Drawing.Size(97, 17);
			Label40.Name = "Label40";
			Label40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label40.Size = new System.Drawing.Size(97, 17);
			Label40.TabIndex = 144;
			Label40.Text = "Retail Sales";
			// 
			// Label21
			// 
			Label21.AllowDrop = true;
			Label21.BackColor = System.Drawing.SystemColors.Control;
			Label21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label21.ForeColor = System.Drawing.SystemColors.ControlText;
			Label21.Location = new System.Drawing.Point(224, 9);
			Label21.MinimumSize = new System.Drawing.Size(73, 17);
			Label21.Name = "Label21";
			Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label21.Size = new System.Drawing.Size(73, 17);
			Label21.TabIndex = 143;
			Label21.Text = "Send To Evo";
			// 
			// Label20
			// 
			Label20.AllowDrop = true;
			Label20.BackColor = System.Drawing.SystemColors.Control;
			Label20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label20.ForeColor = System.Drawing.SystemColors.ControlText;
			Label20.Location = new System.Drawing.Point(2, 9);
			Label20.MinimumSize = new System.Drawing.Size(89, 17);
			Label20.Name = "Label20";
			Label20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label20.Size = new System.Drawing.Size(89, 17);
			Label20.TabIndex = 142;
			Label20.Text = "Category";
			// 
			// fG_JournalCat
			// 
			fG_JournalCat.AllowDrop = true;
			fG_JournalCat.AllowUserToAddRows = false;
			fG_JournalCat.AllowUserToDeleteRows = false;
			fG_JournalCat.AllowUserToResizeColumns = false;
			fG_JournalCat.AllowUserToResizeColumns = fG_JournalCat.ColumnHeadersVisible;
			fG_JournalCat.AllowUserToResizeRows = false;
			fG_JournalCat.AllowUserToResizeRows = false;
			fG_JournalCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			fG_JournalCat.ColumnsCount = 6;
			fG_JournalCat.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			fG_JournalCat.FixedColumns = 0;
			fG_JournalCat.FixedRows = 1;
			fG_JournalCat.Location = new System.Drawing.Point(16, 48);
			fG_JournalCat.Name = "fG_JournalCat";
			fG_JournalCat.ReadOnly = true;
			fG_JournalCat.RowsCount = 2;
			fG_JournalCat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			fG_JournalCat.ShowCellToolTips = false;
			fG_JournalCat.Size = new System.Drawing.Size(501, 377);
			fG_JournalCat.StandardTab = true;
			fG_JournalCat.TabIndex = 130;
			fG_JournalCat.Visible = false;
			fG_JournalCat.Click += new System.EventHandler(fG_JournalCat_Click);
			// 
			// cmd_Add_JC
			// 
			cmd_Add_JC.AllowDrop = true;
			cmd_Add_JC.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_JC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_JC.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_JC.Location = new System.Drawing.Point(624, 25);
			cmd_Add_JC.Name = "cmd_Add_JC";
			cmd_Add_JC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_JC.Size = new System.Drawing.Size(57, 25);
			cmd_Add_JC.TabIndex = 8;
			cmd_Add_JC.Text = "&Add";
			cmd_Add_JC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_JC.UseVisualStyleBackColor = false;
			cmd_Add_JC.Click += new System.EventHandler(cmd_Add_JC_Click);
			// 
			// tot_number
			// 
			tot_number.AllowDrop = true;
			tot_number.BackColor = System.Drawing.SystemColors.Control;
			tot_number.BorderStyle = System.Windows.Forms.BorderStyle.None;
			tot_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tot_number.ForeColor = System.Drawing.SystemColors.ControlText;
			tot_number.Location = new System.Drawing.Point(104, 432);
			tot_number.MinimumSize = new System.Drawing.Size(73, 17);
			tot_number.Name = "tot_number";
			tot_number.RightToLeft = System.Windows.Forms.RightToLeft.No;
			tot_number.Size = new System.Drawing.Size(73, 17);
			tot_number.TabIndex = 155;
			tot_number.Visible = false;
			// 
			// total_cat
			// 
			total_cat.AllowDrop = true;
			total_cat.BackColor = System.Drawing.SystemColors.Control;
			total_cat.BorderStyle = System.Windows.Forms.BorderStyle.None;
			total_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			total_cat.ForeColor = System.Drawing.SystemColors.ControlText;
			total_cat.Location = new System.Drawing.Point(24, 432);
			total_cat.MinimumSize = new System.Drawing.Size(65, 17);
			total_cat.Name = "total_cat";
			total_cat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			total_cat.Size = new System.Drawing.Size(65, 17);
			total_cat.TabIndex = 154;
			total_cat.Text = "Total Found: ";
			total_cat.Visible = false;
			// 
			// _tab_Lookup_TabPage2
			// 
			_tab_Lookup_TabPage2.Controls.Add(Label50);
			_tab_Lookup_TabPage2.Controls.Add(pnl_User_Update_Change);
			_tab_Lookup_TabPage2.Controls.Add(FG_Users);
			_tab_Lookup_TabPage2.Controls.Add(cmd_Add_User);
			_tab_Lookup_TabPage2.Controls.Add(chkIncludeInactive);
			_tab_Lookup_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage2.Text = "User";
			// 
			// Label50
			// 
			Label50.AllowDrop = true;
			Label50.BackColor = System.Drawing.SystemColors.Control;
			Label50.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label50.ForeColor = System.Drawing.Color.Red;
			Label50.Location = new System.Drawing.Point(24, 556);
			Label50.MinimumSize = new System.Drawing.Size(127, 17);
			Label50.Name = "Label50";
			Label50.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label50.Size = new System.Drawing.Size(127, 17);
			Label50.TabIndex = 224;
			Label50.Text = "* Red = Team Leader";
			// 
			// pnl_User_Update_Change
			// 
			pnl_User_Update_Change.AllowDrop = true;
			pnl_User_Update_Change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_User_Update_Change.Controls.Add(txtUserCellNbr);
			pnl_User_Update_Change.Controls.Add(frmTeamLeader);
			pnl_User_Update_Change.Controls.Add(txt_user_description);
			pnl_User_Update_Change.Controls.Add(chkUserMonitorActivityFlag);
			pnl_User_Update_Change.Controls.Add(default_browser);
			pnl_User_Update_Change.Controls.Add(user_delete_attached_ac_specs_flag);
			pnl_User_Update_Change.Controls.Add(txt_user_email_address);
			pnl_User_Update_Change.Controls.Add(chk_user_logged_in);
			pnl_User_Update_Change.Controls.Add(cmbDefaultAirframe);
			pnl_User_Update_Change.Controls.Add(chkAutoCallback);
			pnl_User_Update_Change.Controls.Add(txt_user_id);
			pnl_User_Update_Change.Controls.Add(txt_user_contact_id);
			pnl_User_Update_Change.Controls.Add(txt_user_comp_id);
			pnl_User_Update_Change.Controls.Add(txt_user_default_account_id);
			pnl_User_Update_Change.Controls.Add(txt_user_phone_no_ext);
			pnl_User_Update_Change.Controls.Add(txt_user_phone_no);
			pnl_User_Update_Change.Controls.Add(cbo_user_type);
			pnl_User_Update_Change.Controls.Add(txt_user_middle_initial);
			pnl_User_Update_Change.Controls.Add(cmd_Save_User);
			pnl_User_Update_Change.Controls.Add(cmd_Cancel_User);
			pnl_User_Update_Change.Controls.Add(cmd_Delete_User);
			pnl_User_Update_Change.Controls.Add(txt_user_first_name);
			pnl_User_Update_Change.Controls.Add(txt_user_last_name);
			pnl_User_Update_Change.Controls.Add(txt_user_password);
			pnl_User_Update_Change.Controls.Add(Label52);
			pnl_User_Update_Change.Controls.Add(lbl_user_descrilption);
			pnl_User_Update_Change.Controls.Add(browser_label);
			pnl_User_Update_Change.Controls.Add(lbl_user_email_address);
			pnl_User_Update_Change.Controls.Add(Label1);
			pnl_User_Update_Change.Controls.Add(lbl_user_entered_by);
			pnl_User_Update_Change.Controls.Add(lbl_user_entry_date);
			pnl_User_Update_Change.Controls.Add(Label19);
			pnl_User_Update_Change.Controls.Add(Label18);
			pnl_User_Update_Change.Controls.Add(Label17);
			pnl_User_Update_Change.Controls.Add(Label16);
			pnl_User_Update_Change.Controls.Add(Label15);
			pnl_User_Update_Change.Controls.Add(Label14);
			pnl_User_Update_Change.Controls.Add(Label13);
			pnl_User_Update_Change.Controls.Add(Label12);
			pnl_User_Update_Change.Controls.Add(Label11);
			pnl_User_Update_Change.Controls.Add(Label10);
			pnl_User_Update_Change.Controls.Add(Label9);
			pnl_User_Update_Change.Controls.Add(Label8);
			pnl_User_Update_Change.Controls.Add(Label7);
			pnl_User_Update_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_User_Update_Change.Location = new System.Drawing.Point(342, 65);
			pnl_User_Update_Change.Name = "pnl_User_Update_Change";
			pnl_User_Update_Change.Size = new System.Drawing.Size(605, 482);
			pnl_User_Update_Change.TabIndex = 21;
			pnl_User_Update_Change.Visible = false;
			// 
			// txtUserCellNbr
			// 
			txtUserCellNbr.AcceptsReturn = true;
			txtUserCellNbr.AllowDrop = true;
			txtUserCellNbr.BackColor = System.Drawing.SystemColors.Window;
			txtUserCellNbr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtUserCellNbr.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtUserCellNbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtUserCellNbr.ForeColor = System.Drawing.SystemColors.WindowText;
			txtUserCellNbr.Location = new System.Drawing.Point(396, 150);
			txtUserCellNbr.MaxLength = 15;
			txtUserCellNbr.Name = "txtUserCellNbr";
			txtUserCellNbr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtUserCellNbr.Size = new System.Drawing.Size(147, 19);
			txtUserCellNbr.TabIndex = 54;
			// 
			// frmTeamLeader
			// 
			frmTeamLeader.AllowDrop = true;
			frmTeamLeader.BackColor = System.Drawing.SystemColors.Control;
			frmTeamLeader.Controls.Add(chkTeamLeaderReportActive);
			frmTeamLeader.Controls.Add(cmdSaveTeam);
			frmTeamLeader.Controls.Add(cmbTeamReports);
			frmTeamLeader.Controls.Add(txtUserTeamLeaderTeam);
			frmTeamLeader.Controls.Add(Label51);
			frmTeamLeader.Controls.Add(lblUserTeamLeaderTeam);
			frmTeamLeader.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmTeamLeader.Enabled = true;
			frmTeamLeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmTeamLeader.ForeColor = System.Drawing.SystemColors.ControlText;
			frmTeamLeader.Location = new System.Drawing.Point(12, 412);
			frmTeamLeader.Name = "frmTeamLeader";
			frmTeamLeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmTeamLeader.Size = new System.Drawing.Size(583, 63);
			frmTeamLeader.TabIndex = 225;
			frmTeamLeader.Text = "Team Leader - Teams";
			frmTeamLeader.Visible = true;
			// 
			// chkTeamLeaderReportActive
			// 
			chkTeamLeaderReportActive.AllowDrop = true;
			chkTeamLeaderReportActive.Appearance = System.Windows.Forms.Appearance.Normal;
			chkTeamLeaderReportActive.BackColor = System.Drawing.SystemColors.Control;
			chkTeamLeaderReportActive.CausesValidation = true;
			chkTeamLeaderReportActive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkTeamLeaderReportActive.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkTeamLeaderReportActive.Enabled = true;
			chkTeamLeaderReportActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkTeamLeaderReportActive.ForeColor = System.Drawing.SystemColors.ControlText;
			chkTeamLeaderReportActive.Location = new System.Drawing.Point(474, 32);
			chkTeamLeaderReportActive.Name = "chkTeamLeaderReportActive";
			chkTeamLeaderReportActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkTeamLeaderReportActive.Size = new System.Drawing.Size(51, 21);
			chkTeamLeaderReportActive.TabIndex = 77;
			chkTeamLeaderReportActive.TabStop = true;
			chkTeamLeaderReportActive.Text = "Active";
			chkTeamLeaderReportActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkTeamLeaderReportActive.Visible = true;
			// 
			// cmdSaveTeam
			// 
			cmdSaveTeam.AllowDrop = true;
			cmdSaveTeam.BackColor = System.Drawing.SystemColors.Control;
			cmdSaveTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSaveTeam.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSaveTeam.Location = new System.Drawing.Point(530, 30);
			cmdSaveTeam.Name = "cmdSaveTeam";
			cmdSaveTeam.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSaveTeam.Size = new System.Drawing.Size(45, 25);
			cmdSaveTeam.TabIndex = 78;
			cmdSaveTeam.Text = "&Save";
			cmdSaveTeam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSaveTeam.UseVisualStyleBackColor = false;
			cmdSaveTeam.Click += new System.EventHandler(cmdSaveTeam_Click);
			// 
			// cmbTeamReports
			// 
			cmbTeamReports.AllowDrop = true;
			cmbTeamReports.BackColor = System.Drawing.SystemColors.Window;
			cmbTeamReports.CausesValidation = true;
			cmbTeamReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbTeamReports.Enabled = true;
			cmbTeamReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbTeamReports.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbTeamReports.IntegralHeight = true;
			cmbTeamReports.Location = new System.Drawing.Point(12, 34);
			cmbTeamReports.Name = "cmbTeamReports";
			cmbTeamReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbTeamReports.Size = new System.Drawing.Size(156, 21);
			cmbTeamReports.Sorted = false;
			cmbTeamReports.TabIndex = 75;
			cmbTeamReports.TabStop = true;
			cmbTeamReports.Visible = true;
			cmbTeamReports.SelectionChangeCommitted += new System.EventHandler(cmbTeamReports_SelectionChangeCommitted);
			// 
			// txtUserTeamLeaderTeam
			// 
			txtUserTeamLeaderTeam.AcceptsReturn = true;
			txtUserTeamLeaderTeam.AllowDrop = true;
			txtUserTeamLeaderTeam.BackColor = System.Drawing.SystemColors.Window;
			txtUserTeamLeaderTeam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtUserTeamLeaderTeam.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtUserTeamLeaderTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtUserTeamLeaderTeam.ForeColor = System.Drawing.SystemColors.WindowText;
			txtUserTeamLeaderTeam.Location = new System.Drawing.Point(170, 32);
			txtUserTeamLeaderTeam.MaxLength = 500;
			txtUserTeamLeaderTeam.Name = "txtUserTeamLeaderTeam";
			txtUserTeamLeaderTeam.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtUserTeamLeaderTeam.Size = new System.Drawing.Size(298, 19);
			txtUserTeamLeaderTeam.TabIndex = 76;
			// 
			// Label51
			// 
			Label51.AllowDrop = true;
			Label51.BackColor = System.Drawing.SystemColors.Control;
			Label51.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label51.ForeColor = System.Drawing.SystemColors.ControlText;
			Label51.Location = new System.Drawing.Point(20, 20);
			Label51.MinimumSize = new System.Drawing.Size(134, 17);
			Label51.Name = "Label51";
			Label51.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label51.Size = new System.Drawing.Size(134, 17);
			Label51.TabIndex = 227;
			Label51.Text = "Reports";
			Label51.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			Label51.Visible = false;
			// 
			// lblUserTeamLeaderTeam
			// 
			lblUserTeamLeaderTeam.AllowDrop = true;
			lblUserTeamLeaderTeam.BackColor = System.Drawing.SystemColors.Control;
			lblUserTeamLeaderTeam.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblUserTeamLeaderTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblUserTeamLeaderTeam.ForeColor = System.Drawing.SystemColors.ControlText;
			lblUserTeamLeaderTeam.Location = new System.Drawing.Point(259, 20);
			lblUserTeamLeaderTeam.MinimumSize = new System.Drawing.Size(134, 17);
			lblUserTeamLeaderTeam.Name = "lblUserTeamLeaderTeam";
			lblUserTeamLeaderTeam.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblUserTeamLeaderTeam.Size = new System.Drawing.Size(134, 17);
			lblUserTeamLeaderTeam.TabIndex = 226;
			lblUserTeamLeaderTeam.Text = "Team User Id's";
			lblUserTeamLeaderTeam.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txt_user_description
			// 
			txt_user_description.AcceptsReturn = true;
			txt_user_description.AllowDrop = true;
			txt_user_description.BackColor = System.Drawing.SystemColors.Window;
			txt_user_description.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_description.Location = new System.Drawing.Point(90, 176);
			txt_user_description.MaxLength = 250;
			txt_user_description.Name = "txt_user_description";
			txt_user_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_description.Size = new System.Drawing.Size(465, 19);
			txt_user_description.TabIndex = 55;
			// 
			// chkUserMonitorActivityFlag
			// 
			chkUserMonitorActivityFlag.AllowDrop = true;
			chkUserMonitorActivityFlag.Appearance = System.Windows.Forms.Appearance.Normal;
			chkUserMonitorActivityFlag.BackColor = System.Drawing.SystemColors.Control;
			chkUserMonitorActivityFlag.CausesValidation = true;
			chkUserMonitorActivityFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkUserMonitorActivityFlag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkUserMonitorActivityFlag.Enabled = true;
			chkUserMonitorActivityFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkUserMonitorActivityFlag.ForeColor = System.Drawing.SystemColors.ControlText;
			chkUserMonitorActivityFlag.Location = new System.Drawing.Point(471, 45);
			chkUserMonitorActivityFlag.Name = "chkUserMonitorActivityFlag";
			chkUserMonitorActivityFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkUserMonitorActivityFlag.Size = new System.Drawing.Size(103, 23);
			chkUserMonitorActivityFlag.TabIndex = 45;
			chkUserMonitorActivityFlag.TabStop = true;
			chkUserMonitorActivityFlag.Text = "Log User Access";
			chkUserMonitorActivityFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkUserMonitorActivityFlag.Visible = true;
			// 
			// default_browser
			// 
			default_browser.AllowDrop = true;
			default_browser.BackColor = System.Drawing.SystemColors.Window;
			default_browser.CausesValidation = true;
			default_browser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			default_browser.Enabled = true;
			default_browser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			default_browser.ForeColor = System.Drawing.SystemColors.WindowText;
			default_browser.IntegralHeight = true;
			default_browser.Location = new System.Drawing.Point(480, 215);
			default_browser.Name = "default_browser";
			default_browser.RightToLeft = System.Windows.Forms.RightToLeft.No;
			default_browser.Size = new System.Drawing.Size(121, 21);
			default_browser.Sorted = false;
			default_browser.TabIndex = 60;
			default_browser.TabStop = true;
			default_browser.Visible = true;
			// 
			// user_delete_attached_ac_specs_flag
			// 
			user_delete_attached_ac_specs_flag.AllowDrop = true;
			user_delete_attached_ac_specs_flag.BackColor = System.Drawing.SystemColors.Control;
			user_delete_attached_ac_specs_flag.Controls.Add(chk_user_report_flag);
			user_delete_attached_ac_specs_flag.Controls.Add(chk_user_team_leader_flag);
			user_delete_attached_ac_specs_flag.Controls.Add(chk_user_hide_events_flag);
			user_delete_attached_ac_specs_flag.Controls.Add(chk_user_delete_attached_ac_specs_flag);
			user_delete_attached_ac_specs_flag.Controls.Add(txt_user_marketing_subids_allowed);
			user_delete_attached_ac_specs_flag.Controls.Add(chk_user_manage_accounts_flags);
			user_delete_attached_ac_specs_flag.Controls.Add(chk_user_subscription_contract_amount);
			user_delete_attached_ac_specs_flag.Controls.Add(chk_user_open_multiple_homebase);
			user_delete_attached_ac_specs_flag.Controls.Add(chk_user_edit_subscriptions);
			user_delete_attached_ac_specs_flag.Controls.Add(chk_user_process_ntsb_reports_flag);
			user_delete_attached_ac_specs_flag.Controls.Add(chk_user_process_canadian_reg_flag);
			user_delete_attached_ac_specs_flag.Controls.Add(chk_user_process_pubs_flag);
			user_delete_attached_ac_specs_flag.Controls.Add(chk_run_account_management_reports_flag);
			user_delete_attached_ac_specs_flag.Controls.Add(chk_remove_journal_subject_flag);
			user_delete_attached_ac_specs_flag.Controls.Add(Label6);
			user_delete_attached_ac_specs_flag.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			user_delete_attached_ac_specs_flag.Enabled = true;
			user_delete_attached_ac_specs_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			user_delete_attached_ac_specs_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			user_delete_attached_ac_specs_flag.Location = new System.Drawing.Point(12, 282);
			user_delete_attached_ac_specs_flag.Name = "user_delete_attached_ac_specs_flag";
			user_delete_attached_ac_specs_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			user_delete_attached_ac_specs_flag.Size = new System.Drawing.Size(583, 129);
			user_delete_attached_ac_specs_flag.TabIndex = 138;
			user_delete_attached_ac_specs_flag.Text = "Is User Allowed To";
			user_delete_attached_ac_specs_flag.Visible = true;
			// 
			// chk_user_report_flag
			// 
			chk_user_report_flag.AllowDrop = true;
			chk_user_report_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_user_report_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_user_report_flag.CausesValidation = true;
			chk_user_report_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_report_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_user_report_flag.Enabled = true;
			chk_user_report_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_user_report_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_user_report_flag.Location = new System.Drawing.Point(419, 54);
			chk_user_report_flag.Name = "chk_user_report_flag";
			chk_user_report_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_user_report_flag.Size = new System.Drawing.Size(143, 23);
			chk_user_report_flag.TabIndex = 73;
			chk_user_report_flag.TabStop = true;
			chk_user_report_flag.Text = "User Reports";
			chk_user_report_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_report_flag.Visible = true;
			// 
			// chk_user_team_leader_flag
			// 
			chk_user_team_leader_flag.AllowDrop = true;
			chk_user_team_leader_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_user_team_leader_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_user_team_leader_flag.CausesValidation = true;
			chk_user_team_leader_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_team_leader_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_user_team_leader_flag.Enabled = true;
			chk_user_team_leader_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_user_team_leader_flag.ForeColor = System.Drawing.Color.Red;
			chk_user_team_leader_flag.Location = new System.Drawing.Point(419, 33);
			chk_user_team_leader_flag.Name = "chk_user_team_leader_flag";
			chk_user_team_leader_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_user_team_leader_flag.Size = new System.Drawing.Size(143, 23);
			chk_user_team_leader_flag.TabIndex = 72;
			chk_user_team_leader_flag.TabStop = true;
			chk_user_team_leader_flag.Text = "Team Leader";
			chk_user_team_leader_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_team_leader_flag.Visible = true;
			chk_user_team_leader_flag.CheckStateChanged += new System.EventHandler(chk_user_team_leader_flag_CheckStateChanged);
			// 
			// chk_user_hide_events_flag
			// 
			chk_user_hide_events_flag.AllowDrop = true;
			chk_user_hide_events_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_user_hide_events_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_user_hide_events_flag.CausesValidation = true;
			chk_user_hide_events_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_hide_events_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_user_hide_events_flag.Enabled = true;
			chk_user_hide_events_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_user_hide_events_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_user_hide_events_flag.Location = new System.Drawing.Point(419, 15);
			chk_user_hide_events_flag.Name = "chk_user_hide_events_flag";
			chk_user_hide_events_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_user_hide_events_flag.Size = new System.Drawing.Size(143, 23);
			chk_user_hide_events_flag.TabIndex = 71;
			chk_user_hide_events_flag.TabStop = true;
			chk_user_hide_events_flag.Text = "Hide Priority Events";
			chk_user_hide_events_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_hide_events_flag.Visible = true;
			// 
			// chk_user_delete_attached_ac_specs_flag
			// 
			chk_user_delete_attached_ac_specs_flag.AllowDrop = true;
			chk_user_delete_attached_ac_specs_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_user_delete_attached_ac_specs_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_user_delete_attached_ac_specs_flag.CausesValidation = true;
			chk_user_delete_attached_ac_specs_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_delete_attached_ac_specs_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_user_delete_attached_ac_specs_flag.Enabled = true;
			chk_user_delete_attached_ac_specs_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_user_delete_attached_ac_specs_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_user_delete_attached_ac_specs_flag.Location = new System.Drawing.Point(195, 96);
			chk_user_delete_attached_ac_specs_flag.Name = "chk_user_delete_attached_ac_specs_flag";
			chk_user_delete_attached_ac_specs_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_user_delete_attached_ac_specs_flag.Size = new System.Drawing.Size(185, 23);
			chk_user_delete_attached_ac_specs_flag.TabIndex = 70;
			chk_user_delete_attached_ac_specs_flag.TabStop = true;
			chk_user_delete_attached_ac_specs_flag.Text = "Delete Attached Aircraft Specs";
			chk_user_delete_attached_ac_specs_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_delete_attached_ac_specs_flag.Visible = true;
			// 
			// txt_user_marketing_subids_allowed
			// 
			txt_user_marketing_subids_allowed.AcceptsReturn = true;
			txt_user_marketing_subids_allowed.AllowDrop = true;
			txt_user_marketing_subids_allowed.BackColor = System.Drawing.SystemColors.Window;
			txt_user_marketing_subids_allowed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_marketing_subids_allowed.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_marketing_subids_allowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_marketing_subids_allowed.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_marketing_subids_allowed.Location = new System.Drawing.Point(417, 95);
			txt_user_marketing_subids_allowed.MaxLength = 50;
			txt_user_marketing_subids_allowed.Name = "txt_user_marketing_subids_allowed";
			txt_user_marketing_subids_allowed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_marketing_subids_allowed.Size = new System.Drawing.Size(136, 19);
			txt_user_marketing_subids_allowed.TabIndex = 74;
			// 
			// chk_user_manage_accounts_flags
			// 
			chk_user_manage_accounts_flags.AllowDrop = true;
			chk_user_manage_accounts_flags.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_user_manage_accounts_flags.BackColor = System.Drawing.SystemColors.Control;
			chk_user_manage_accounts_flags.CausesValidation = true;
			chk_user_manage_accounts_flags.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_manage_accounts_flags.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_user_manage_accounts_flags.Enabled = true;
			chk_user_manage_accounts_flags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_user_manage_accounts_flags.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_user_manage_accounts_flags.Location = new System.Drawing.Point(195, 75);
			chk_user_manage_accounts_flags.Name = "chk_user_manage_accounts_flags";
			chk_user_manage_accounts_flags.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_user_manage_accounts_flags.Size = new System.Drawing.Size(128, 23);
			chk_user_manage_accounts_flags.TabIndex = 69;
			chk_user_manage_accounts_flags.TabStop = true;
			chk_user_manage_accounts_flags.Text = "Manage Accounts";
			chk_user_manage_accounts_flags.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_manage_accounts_flags.Visible = true;
			// 
			// chk_user_subscription_contract_amount
			// 
			chk_user_subscription_contract_amount.AllowDrop = true;
			chk_user_subscription_contract_amount.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_user_subscription_contract_amount.BackColor = System.Drawing.SystemColors.Control;
			chk_user_subscription_contract_amount.CausesValidation = true;
			chk_user_subscription_contract_amount.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_subscription_contract_amount.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_user_subscription_contract_amount.Enabled = true;
			chk_user_subscription_contract_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_user_subscription_contract_amount.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_user_subscription_contract_amount.Location = new System.Drawing.Point(195, 54);
			chk_user_subscription_contract_amount.Name = "chk_user_subscription_contract_amount";
			chk_user_subscription_contract_amount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_user_subscription_contract_amount.Size = new System.Drawing.Size(203, 23);
			chk_user_subscription_contract_amount.TabIndex = 68;
			chk_user_subscription_contract_amount.TabStop = true;
			chk_user_subscription_contract_amount.Text = "View Subscription Contract Amounts";
			chk_user_subscription_contract_amount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_subscription_contract_amount.Visible = true;
			// 
			// chk_user_open_multiple_homebase
			// 
			chk_user_open_multiple_homebase.AllowDrop = true;
			chk_user_open_multiple_homebase.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_user_open_multiple_homebase.BackColor = System.Drawing.SystemColors.Control;
			chk_user_open_multiple_homebase.CausesValidation = true;
			chk_user_open_multiple_homebase.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_open_multiple_homebase.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_user_open_multiple_homebase.Enabled = true;
			chk_user_open_multiple_homebase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_user_open_multiple_homebase.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_user_open_multiple_homebase.Location = new System.Drawing.Point(195, 33);
			chk_user_open_multiple_homebase.Name = "chk_user_open_multiple_homebase";
			chk_user_open_multiple_homebase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_user_open_multiple_homebase.Size = new System.Drawing.Size(194, 23);
			chk_user_open_multiple_homebase.TabIndex = 67;
			chk_user_open_multiple_homebase.TabStop = true;
			chk_user_open_multiple_homebase.Text = "Open Multiple Copies of Homebase";
			chk_user_open_multiple_homebase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_open_multiple_homebase.Visible = true;
			// 
			// chk_user_edit_subscriptions
			// 
			chk_user_edit_subscriptions.AllowDrop = true;
			chk_user_edit_subscriptions.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_user_edit_subscriptions.BackColor = System.Drawing.SystemColors.Control;
			chk_user_edit_subscriptions.CausesValidation = true;
			chk_user_edit_subscriptions.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_edit_subscriptions.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_user_edit_subscriptions.Enabled = true;
			chk_user_edit_subscriptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_user_edit_subscriptions.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_user_edit_subscriptions.Location = new System.Drawing.Point(195, 12);
			chk_user_edit_subscriptions.Name = "chk_user_edit_subscriptions";
			chk_user_edit_subscriptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_user_edit_subscriptions.Size = new System.Drawing.Size(176, 23);
			chk_user_edit_subscriptions.TabIndex = 66;
			chk_user_edit_subscriptions.TabStop = true;
			chk_user_edit_subscriptions.Text = "Edit Subscriptions";
			chk_user_edit_subscriptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_edit_subscriptions.Visible = true;
			// 
			// chk_user_process_ntsb_reports_flag
			// 
			chk_user_process_ntsb_reports_flag.AllowDrop = true;
			chk_user_process_ntsb_reports_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_user_process_ntsb_reports_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_user_process_ntsb_reports_flag.CausesValidation = true;
			chk_user_process_ntsb_reports_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_process_ntsb_reports_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_user_process_ntsb_reports_flag.Enabled = true;
			chk_user_process_ntsb_reports_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_user_process_ntsb_reports_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_user_process_ntsb_reports_flag.Location = new System.Drawing.Point(9, 96);
			chk_user_process_ntsb_reports_flag.Name = "chk_user_process_ntsb_reports_flag";
			chk_user_process_ntsb_reports_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_user_process_ntsb_reports_flag.Size = new System.Drawing.Size(146, 23);
			chk_user_process_ntsb_reports_flag.TabIndex = 65;
			chk_user_process_ntsb_reports_flag.TabStop = true;
			chk_user_process_ntsb_reports_flag.Text = "Process NTSB Reports";
			chk_user_process_ntsb_reports_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_process_ntsb_reports_flag.Visible = true;
			// 
			// chk_user_process_canadian_reg_flag
			// 
			chk_user_process_canadian_reg_flag.AllowDrop = true;
			chk_user_process_canadian_reg_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_user_process_canadian_reg_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_user_process_canadian_reg_flag.CausesValidation = true;
			chk_user_process_canadian_reg_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_process_canadian_reg_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_user_process_canadian_reg_flag.Enabled = true;
			chk_user_process_canadian_reg_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_user_process_canadian_reg_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_user_process_canadian_reg_flag.Location = new System.Drawing.Point(9, 75);
			chk_user_process_canadian_reg_flag.Name = "chk_user_process_canadian_reg_flag";
			chk_user_process_canadian_reg_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_user_process_canadian_reg_flag.Size = new System.Drawing.Size(158, 23);
			chk_user_process_canadian_reg_flag.TabIndex = 64;
			chk_user_process_canadian_reg_flag.TabStop = true;
			chk_user_process_canadian_reg_flag.Text = "Process Canadian Registry";
			chk_user_process_canadian_reg_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_process_canadian_reg_flag.Visible = true;
			// 
			// chk_user_process_pubs_flag
			// 
			chk_user_process_pubs_flag.AllowDrop = true;
			chk_user_process_pubs_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_user_process_pubs_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_user_process_pubs_flag.CausesValidation = true;
			chk_user_process_pubs_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_process_pubs_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_user_process_pubs_flag.Enabled = true;
			chk_user_process_pubs_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_user_process_pubs_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_user_process_pubs_flag.Location = new System.Drawing.Point(9, 54);
			chk_user_process_pubs_flag.Name = "chk_user_process_pubs_flag";
			chk_user_process_pubs_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_user_process_pubs_flag.Size = new System.Drawing.Size(143, 23);
			chk_user_process_pubs_flag.TabIndex = 63;
			chk_user_process_pubs_flag.TabStop = true;
			chk_user_process_pubs_flag.Text = "Process Pubs";
			chk_user_process_pubs_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_process_pubs_flag.Visible = true;
			// 
			// chk_run_account_management_reports_flag
			// 
			chk_run_account_management_reports_flag.AllowDrop = true;
			chk_run_account_management_reports_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_run_account_management_reports_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_run_account_management_reports_flag.CausesValidation = true;
			chk_run_account_management_reports_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_run_account_management_reports_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_run_account_management_reports_flag.Enabled = true;
			chk_run_account_management_reports_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_run_account_management_reports_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_run_account_management_reports_flag.Location = new System.Drawing.Point(9, 15);
			chk_run_account_management_reports_flag.Name = "chk_run_account_management_reports_flag";
			chk_run_account_management_reports_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_run_account_management_reports_flag.Size = new System.Drawing.Size(157, 19);
			chk_run_account_management_reports_flag.TabIndex = 61;
			chk_run_account_management_reports_flag.TabStop = true;
			chk_run_account_management_reports_flag.Text = "View Managment Reports";
			chk_run_account_management_reports_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_run_account_management_reports_flag.Visible = true;
			// 
			// chk_remove_journal_subject_flag
			// 
			chk_remove_journal_subject_flag.AllowDrop = true;
			chk_remove_journal_subject_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_remove_journal_subject_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_remove_journal_subject_flag.CausesValidation = true;
			chk_remove_journal_subject_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_remove_journal_subject_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_remove_journal_subject_flag.Enabled = true;
			chk_remove_journal_subject_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_remove_journal_subject_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_remove_journal_subject_flag.Location = new System.Drawing.Point(9, 33);
			chk_remove_journal_subject_flag.Name = "chk_remove_journal_subject_flag";
			chk_remove_journal_subject_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_remove_journal_subject_flag.Size = new System.Drawing.Size(155, 23);
			chk_remove_journal_subject_flag.TabIndex = 62;
			chk_remove_journal_subject_flag.TabStop = true;
			chk_remove_journal_subject_flag.Text = "Delete any Journal Subject";
			chk_remove_journal_subject_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_remove_journal_subject_flag.Visible = true;
			// 
			// Label6
			// 
			Label6.AllowDrop = true;
			Label6.BackColor = System.Drawing.SystemColors.Control;
			Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			Label6.Location = new System.Drawing.Point(417, 79);
			Label6.MinimumSize = new System.Drawing.Size(134, 17);
			Label6.Name = "Label6";
			Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label6.Size = new System.Drawing.Size(134, 17);
			Label6.TabIndex = 139;
			Label6.Text = "Marketing Subscription Id's";
			Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txt_user_email_address
			// 
			txt_user_email_address.AcceptsReturn = true;
			txt_user_email_address.AllowDrop = true;
			txt_user_email_address.BackColor = System.Drawing.SystemColors.Window;
			txt_user_email_address.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_email_address.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_email_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_email_address.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_email_address.Location = new System.Drawing.Point(318, 123);
			txt_user_email_address.MaxLength = 70;
			txt_user_email_address.Name = "txt_user_email_address";
			txt_user_email_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_email_address.Size = new System.Drawing.Size(239, 19);
			txt_user_email_address.TabIndex = 51;
			// 
			// chk_user_logged_in
			// 
			chk_user_logged_in.AllowDrop = true;
			chk_user_logged_in.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_user_logged_in.BackColor = System.Drawing.SystemColors.Control;
			chk_user_logged_in.CausesValidation = true;
			chk_user_logged_in.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_logged_in.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_user_logged_in.Enabled = true;
			chk_user_logged_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_user_logged_in.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_user_logged_in.Location = new System.Drawing.Point(327, 45);
			chk_user_logged_in.Name = "chk_user_logged_in";
			chk_user_logged_in.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_user_logged_in.Size = new System.Drawing.Size(119, 23);
			chk_user_logged_in.TabIndex = 44;
			chk_user_logged_in.TabStop = true;
			chk_user_logged_in.Text = "User Logged In Flag";
			chk_user_logged_in.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_user_logged_in.Visible = true;
			// 
			// cmbDefaultAirframe
			// 
			cmbDefaultAirframe.AllowDrop = true;
			cmbDefaultAirframe.BackColor = System.Drawing.SystemColors.Window;
			cmbDefaultAirframe.CausesValidation = true;
			cmbDefaultAirframe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbDefaultAirframe.Enabled = true;
			cmbDefaultAirframe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbDefaultAirframe.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbDefaultAirframe.IntegralHeight = true;
			cmbDefaultAirframe.Location = new System.Drawing.Point(354, 215);
			cmbDefaultAirframe.Name = "cmbDefaultAirframe";
			cmbDefaultAirframe.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbDefaultAirframe.Size = new System.Drawing.Size(122, 21);
			cmbDefaultAirframe.Sorted = false;
			cmbDefaultAirframe.TabIndex = 59;
			cmbDefaultAirframe.TabStop = true;
			cmbDefaultAirframe.Visible = true;
			// 
			// chkAutoCallback
			// 
			chkAutoCallback.AllowDrop = true;
			chkAutoCallback.Appearance = System.Windows.Forms.Appearance.Normal;
			chkAutoCallback.BackColor = System.Drawing.SystemColors.Control;
			chkAutoCallback.CausesValidation = true;
			chkAutoCallback.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAutoCallback.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkAutoCallback.Enabled = true;
			chkAutoCallback.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkAutoCallback.ForeColor = System.Drawing.SystemColors.ControlText;
			chkAutoCallback.Location = new System.Drawing.Point(94, 51);
			chkAutoCallback.Name = "chkAutoCallback";
			chkAutoCallback.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkAutoCallback.Size = new System.Drawing.Size(214, 13);
			chkAutoCallback.TabIndex = 43;
			chkAutoCallback.TabStop = true;
			chkAutoCallback.Text = "Automatically go to callback list on login";
			chkAutoCallback.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAutoCallback.Visible = true;
			// 
			// txt_user_id
			// 
			txt_user_id.AcceptsReturn = true;
			txt_user_id.AllowDrop = true;
			txt_user_id.BackColor = System.Drawing.SystemColors.Window;
			txt_user_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_id.Location = new System.Drawing.Point(15, 46);
			txt_user_id.MaxLength = 4;
			txt_user_id.Name = "txt_user_id";
			txt_user_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_id.Size = new System.Drawing.Size(50, 19);
			txt_user_id.TabIndex = 42;
			// 
			// txt_user_contact_id
			// 
			txt_user_contact_id.AcceptsReturn = true;
			txt_user_contact_id.AllowDrop = true;
			txt_user_contact_id.BackColor = System.Drawing.SystemColors.Window;
			txt_user_contact_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_contact_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_contact_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_contact_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_contact_id.Location = new System.Drawing.Point(247, 217);
			txt_user_contact_id.MaxLength = 15;
			txt_user_contact_id.Name = "txt_user_contact_id";
			txt_user_contact_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_contact_id.Size = new System.Drawing.Size(79, 19);
			txt_user_contact_id.TabIndex = 58;
			// 
			// txt_user_comp_id
			// 
			txt_user_comp_id.AcceptsReturn = true;
			txt_user_comp_id.AllowDrop = true;
			txt_user_comp_id.BackColor = System.Drawing.SystemColors.Window;
			txt_user_comp_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_comp_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_comp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_comp_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_comp_id.Location = new System.Drawing.Point(130, 217);
			txt_user_comp_id.MaxLength = 15;
			txt_user_comp_id.Name = "txt_user_comp_id";
			txt_user_comp_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_comp_id.Size = new System.Drawing.Size(85, 19);
			txt_user_comp_id.TabIndex = 57;
			// 
			// txt_user_default_account_id
			// 
			txt_user_default_account_id.AcceptsReturn = true;
			txt_user_default_account_id.AllowDrop = true;
			txt_user_default_account_id.BackColor = System.Drawing.SystemColors.Window;
			txt_user_default_account_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_default_account_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_default_account_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_default_account_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_default_account_id.Location = new System.Drawing.Point(13, 217);
			txt_user_default_account_id.MaxLength = 4;
			txt_user_default_account_id.Name = "txt_user_default_account_id";
			txt_user_default_account_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_default_account_id.Size = new System.Drawing.Size(73, 19);
			txt_user_default_account_id.TabIndex = 56;
			// 
			// txt_user_phone_no_ext
			// 
			txt_user_phone_no_ext.AcceptsReturn = true;
			txt_user_phone_no_ext.AllowDrop = true;
			txt_user_phone_no_ext.BackColor = System.Drawing.SystemColors.Window;
			txt_user_phone_no_ext.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_phone_no_ext.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_phone_no_ext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_phone_no_ext.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_phone_no_ext.Location = new System.Drawing.Point(265, 151);
			txt_user_phone_no_ext.MaxLength = 5;
			txt_user_phone_no_ext.Name = "txt_user_phone_no_ext";
			txt_user_phone_no_ext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_phone_no_ext.Size = new System.Drawing.Size(46, 19);
			txt_user_phone_no_ext.TabIndex = 53;
			// 
			// txt_user_phone_no
			// 
			txt_user_phone_no.AcceptsReturn = true;
			txt_user_phone_no.AllowDrop = true;
			txt_user_phone_no.BackColor = System.Drawing.SystemColors.Window;
			txt_user_phone_no.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_phone_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_phone_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_phone_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_phone_no.Location = new System.Drawing.Point(91, 151);
			txt_user_phone_no.MaxLength = 15;
			txt_user_phone_no.Name = "txt_user_phone_no";
			txt_user_phone_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_phone_no.Size = new System.Drawing.Size(147, 19);
			txt_user_phone_no.TabIndex = 52;
			// 
			// cbo_user_type
			// 
			cbo_user_type.AllowDrop = true;
			cbo_user_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_user_type.CausesValidation = true;
			cbo_user_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_user_type.Enabled = true;
			cbo_user_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_user_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_user_type.IntegralHeight = true;
			cbo_user_type.Location = new System.Drawing.Point(117, 124);
			cbo_user_type.Name = "cbo_user_type";
			cbo_user_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_user_type.Size = new System.Drawing.Size(163, 21);
			cbo_user_type.Sorted = false;
			cbo_user_type.TabIndex = 50;
			cbo_user_type.TabStop = true;
			cbo_user_type.Visible = true;
			// 
			// txt_user_middle_initial
			// 
			txt_user_middle_initial.AcceptsReturn = true;
			txt_user_middle_initial.AllowDrop = true;
			txt_user_middle_initial.BackColor = System.Drawing.SystemColors.Window;
			txt_user_middle_initial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_middle_initial.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_middle_initial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_middle_initial.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_middle_initial.Location = new System.Drawing.Point(255, 88);
			txt_user_middle_initial.MaxLength = 1;
			txt_user_middle_initial.Name = "txt_user_middle_initial";
			txt_user_middle_initial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_middle_initial.Size = new System.Drawing.Size(29, 19);
			txt_user_middle_initial.TabIndex = 47;
			txt_user_middle_initial.Leave += new System.EventHandler(txt_user_middle_initial_Leave);
			// 
			// cmd_Save_User
			// 
			cmd_Save_User.AllowDrop = true;
			cmd_Save_User.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_User.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_User.Location = new System.Drawing.Point(144, 9);
			cmd_Save_User.Name = "cmd_Save_User";
			cmd_Save_User.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_User.Size = new System.Drawing.Size(57, 25);
			cmd_Save_User.TabIndex = 36;
			cmd_Save_User.Text = "&Save";
			cmd_Save_User.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_User.UseVisualStyleBackColor = false;
			cmd_Save_User.Click += new System.EventHandler(cmd_Save_User_Click);
			// 
			// cmd_Cancel_User
			// 
			cmd_Cancel_User.AllowDrop = true;
			cmd_Cancel_User.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_User.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_User.Location = new System.Drawing.Point(228, 9);
			cmd_Cancel_User.Name = "cmd_Cancel_User";
			cmd_Cancel_User.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_User.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_User.TabIndex = 38;
			cmd_Cancel_User.Text = "&Cancel";
			cmd_Cancel_User.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_User.UseVisualStyleBackColor = false;
			cmd_Cancel_User.Click += new System.EventHandler(cmd_Cancel_User_Click);
			// 
			// cmd_Delete_User
			// 
			cmd_Delete_User.AllowDrop = true;
			cmd_Delete_User.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_User.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_User.Location = new System.Drawing.Point(309, 10);
			cmd_Delete_User.Name = "cmd_Delete_User";
			cmd_Delete_User.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_User.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_User.TabIndex = 40;
			cmd_Delete_User.Text = "&Delete";
			cmd_Delete_User.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_User.UseVisualStyleBackColor = false;
			cmd_Delete_User.Click += new System.EventHandler(cmd_Delete_User_Click);
			// 
			// txt_user_first_name
			// 
			txt_user_first_name.AcceptsReturn = true;
			txt_user_first_name.AllowDrop = true;
			txt_user_first_name.BackColor = System.Drawing.SystemColors.Window;
			txt_user_first_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_first_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_first_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_first_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_first_name.Location = new System.Drawing.Point(13, 88);
			txt_user_first_name.MaxLength = 15;
			txt_user_first_name.Name = "txt_user_first_name";
			txt_user_first_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_first_name.Size = new System.Drawing.Size(216, 19);
			txt_user_first_name.TabIndex = 46;
			txt_user_first_name.TabStop = false;
			txt_user_first_name.Leave += new System.EventHandler(txt_user_first_name_Leave);
			// 
			// txt_user_last_name
			// 
			txt_user_last_name.AcceptsReturn = true;
			txt_user_last_name.AllowDrop = true;
			txt_user_last_name.BackColor = System.Drawing.SystemColors.Window;
			txt_user_last_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_last_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_last_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_last_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_last_name.Location = new System.Drawing.Point(317, 88);
			txt_user_last_name.MaxLength = 20;
			txt_user_last_name.Name = "txt_user_last_name";
			txt_user_last_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_last_name.Size = new System.Drawing.Size(239, 19);
			txt_user_last_name.TabIndex = 48;
			txt_user_last_name.Leave += new System.EventHandler(txt_user_last_name_Leave);
			// 
			// txt_user_password
			// 
			txt_user_password.AcceptsReturn = true;
			txt_user_password.AllowDrop = true;
			txt_user_password.BackColor = System.Drawing.SystemColors.Window;
			txt_user_password.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_user_password.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_user_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_user_password.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_user_password.Location = new System.Drawing.Point(13, 125);
			txt_user_password.MaxLength = 10;
			txt_user_password.Name = "txt_user_password";
			txt_user_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_user_password.Size = new System.Drawing.Size(90, 19);
			txt_user_password.TabIndex = 49;
			// 
			// Label52
			// 
			Label52.AllowDrop = true;
			Label52.BackColor = System.Drawing.SystemColors.Control;
			Label52.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label52.ForeColor = System.Drawing.SystemColors.ControlText;
			Label52.Location = new System.Drawing.Point(316, 152);
			Label52.MinimumSize = new System.Drawing.Size(73, 17);
			Label52.Name = "Label52";
			Label52.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label52.Size = new System.Drawing.Size(73, 17);
			Label52.TabIndex = 251;
			Label52.Text = "Cell Number";
			// 
			// lbl_user_descrilption
			// 
			lbl_user_descrilption.AllowDrop = true;
			lbl_user_descrilption.BackColor = System.Drawing.SystemColors.Control;
			lbl_user_descrilption.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_user_descrilption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_user_descrilption.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_user_descrilption.Location = new System.Drawing.Point(13, 176);
			lbl_user_descrilption.MinimumSize = new System.Drawing.Size(59, 17);
			lbl_user_descrilption.Name = "lbl_user_descrilption";
			lbl_user_descrilption.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_user_descrilption.Size = new System.Drawing.Size(59, 17);
			lbl_user_descrilption.TabIndex = 216;
			lbl_user_descrilption.Text = "Description";
			// 
			// browser_label
			// 
			browser_label.AllowDrop = true;
			browser_label.BackColor = System.Drawing.SystemColors.Control;
			browser_label.BorderStyle = System.Windows.Forms.BorderStyle.None;
			browser_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			browser_label.ForeColor = System.Drawing.SystemColors.ControlText;
			browser_label.Location = new System.Drawing.Point(480, 201);
			browser_label.MinimumSize = new System.Drawing.Size(89, 17);
			browser_label.Name = "browser_label";
			browser_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
			browser_label.Size = new System.Drawing.Size(89, 17);
			browser_label.TabIndex = 156;
			browser_label.Text = "Default Browser";
			// 
			// lbl_user_email_address
			// 
			lbl_user_email_address.AllowDrop = true;
			lbl_user_email_address.BackColor = System.Drawing.SystemColors.Control;
			lbl_user_email_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_user_email_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_user_email_address.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_user_email_address.Location = new System.Drawing.Point(318, 108);
			lbl_user_email_address.MinimumSize = new System.Drawing.Size(139, 17);
			lbl_user_email_address.Name = "lbl_user_email_address";
			lbl_user_email_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_user_email_address.Size = new System.Drawing.Size(139, 17);
			lbl_user_email_address.TabIndex = 137;
			lbl_user_email_address.Text = "EMail Address";
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.BackColor = System.Drawing.SystemColors.Control;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(354, 201);
			Label1.MinimumSize = new System.Drawing.Size(117, 14);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(117, 14);
			Label1.TabIndex = 136;
			Label1.Text = "Default Airframe Type";
			// 
			// lbl_user_entered_by
			// 
			lbl_user_entered_by.AllowDrop = true;
			lbl_user_entered_by.BackColor = System.Drawing.SystemColors.Control;
			lbl_user_entered_by.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lbl_user_entered_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_user_entered_by.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_user_entered_by.Location = new System.Drawing.Point(166, 256);
			lbl_user_entered_by.MinimumSize = new System.Drawing.Size(50, 19);
			lbl_user_entered_by.Name = "lbl_user_entered_by";
			lbl_user_entered_by.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_user_entered_by.Size = new System.Drawing.Size(50, 19);
			lbl_user_entered_by.TabIndex = 41;
			lbl_user_entered_by.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_user_entry_date
			// 
			lbl_user_entry_date.AllowDrop = true;
			lbl_user_entry_date.BackColor = System.Drawing.SystemColors.Control;
			lbl_user_entry_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lbl_user_entry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_user_entry_date.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_user_entry_date.Location = new System.Drawing.Point(14, 256);
			lbl_user_entry_date.MinimumSize = new System.Drawing.Size(143, 19);
			lbl_user_entry_date.Name = "lbl_user_entry_date";
			lbl_user_entry_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_user_entry_date.Size = new System.Drawing.Size(143, 19);
			lbl_user_entry_date.TabIndex = 39;
			lbl_user_entry_date.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Label19
			// 
			Label19.AllowDrop = true;
			Label19.BackColor = System.Drawing.SystemColors.Control;
			Label19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label19.ForeColor = System.Drawing.SystemColors.ControlText;
			Label19.Location = new System.Drawing.Point(166, 240);
			Label19.MinimumSize = new System.Drawing.Size(50, 17);
			Label19.Name = "Label19";
			Label19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label19.Size = new System.Drawing.Size(50, 17);
			Label19.TabIndex = 37;
			Label19.Text = "By";
			Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Label18
			// 
			Label18.AllowDrop = true;
			Label18.BackColor = System.Drawing.SystemColors.Control;
			Label18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label18.ForeColor = System.Drawing.SystemColors.ControlText;
			Label18.Location = new System.Drawing.Point(15, 238);
			Label18.MinimumSize = new System.Drawing.Size(142, 17);
			Label18.Name = "Label18";
			Label18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label18.Size = new System.Drawing.Size(142, 17);
			Label18.TabIndex = 35;
			Label18.Text = "Date Entered/Updated";
			// 
			// Label17
			// 
			Label17.AllowDrop = true;
			Label17.BackColor = System.Drawing.SystemColors.Control;
			Label17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label17.ForeColor = System.Drawing.SystemColors.ControlText;
			Label17.Location = new System.Drawing.Point(247, 201);
			Label17.MinimumSize = new System.Drawing.Size(103, 17);
			Label17.Name = "Label17";
			Label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label17.Size = new System.Drawing.Size(103, 17);
			Label17.TabIndex = 33;
			Label17.Text = "Customer Contact ID";
			// 
			// Label16
			// 
			Label16.AllowDrop = true;
			Label16.BackColor = System.Drawing.SystemColors.Control;
			Label16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label16.ForeColor = System.Drawing.SystemColors.ControlText;
			Label16.Location = new System.Drawing.Point(130, 201);
			Label16.MinimumSize = new System.Drawing.Size(117, 17);
			Label16.Name = "Label16";
			Label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label16.Size = new System.Drawing.Size(117, 17);
			Label16.TabIndex = 31;
			Label16.Text = "Customer Company ID";
			// 
			// Label15
			// 
			Label15.AllowDrop = true;
			Label15.BackColor = System.Drawing.SystemColors.Control;
			Label15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label15.ForeColor = System.Drawing.SystemColors.ControlText;
			Label15.Location = new System.Drawing.Point(13, 201);
			Label15.MinimumSize = new System.Drawing.Size(107, 17);
			Label15.Name = "Label15";
			Label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label15.Size = new System.Drawing.Size(107, 17);
			Label15.TabIndex = 30;
			Label15.Text = "Default Account ID";
			// 
			// Label14
			// 
			Label14.AllowDrop = true;
			Label14.BackColor = System.Drawing.SystemColors.Control;
			Label14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label14.ForeColor = System.Drawing.SystemColors.ControlText;
			Label14.Location = new System.Drawing.Point(243, 153);
			Label14.MinimumSize = new System.Drawing.Size(17, 17);
			Label14.Name = "Label14";
			Label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label14.Size = new System.Drawing.Size(17, 17);
			Label14.TabIndex = 29;
			Label14.Text = "Ext";
			// 
			// Label13
			// 
			Label13.AllowDrop = true;
			Label13.BackColor = System.Drawing.SystemColors.Control;
			Label13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label13.ForeColor = System.Drawing.SystemColors.ControlText;
			Label13.Location = new System.Drawing.Point(13, 151);
			Label13.MinimumSize = new System.Drawing.Size(73, 17);
			Label13.Name = "Label13";
			Label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label13.Size = new System.Drawing.Size(73, 17);
			Label13.TabIndex = 28;
			Label13.Text = "Phone Number";
			// 
			// Label12
			// 
			Label12.AllowDrop = true;
			Label12.BackColor = System.Drawing.SystemColors.Control;
			Label12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label12.ForeColor = System.Drawing.SystemColors.ControlText;
			Label12.Location = new System.Drawing.Point(121, 109);
			Label12.MinimumSize = new System.Drawing.Size(143, 17);
			Label12.Name = "Label12";
			Label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label12.Size = new System.Drawing.Size(143, 17);
			Label12.TabIndex = 27;
			Label12.Text = "User Type";
			// 
			// Label11
			// 
			Label11.AllowDrop = true;
			Label11.BackColor = System.Drawing.SystemColors.Control;
			Label11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label11.ForeColor = System.Drawing.SystemColors.ControlText;
			Label11.Location = new System.Drawing.Point(17, 26);
			Label11.MinimumSize = new System.Drawing.Size(127, 17);
			Label11.Name = "Label11";
			Label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label11.Size = new System.Drawing.Size(127, 17);
			Label11.TabIndex = 26;
			Label11.Text = "User ID";
			// 
			// Label10
			// 
			Label10.AllowDrop = true;
			Label10.BackColor = System.Drawing.SystemColors.Control;
			Label10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label10.ForeColor = System.Drawing.SystemColors.ControlText;
			Label10.Location = new System.Drawing.Point(255, 72);
			Label10.MinimumSize = new System.Drawing.Size(61, 17);
			Label10.Name = "Label10";
			Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label10.Size = new System.Drawing.Size(61, 17);
			Label10.TabIndex = 25;
			Label10.Text = "Middle Intial";
			// 
			// Label9
			// 
			Label9.AllowDrop = true;
			Label9.BackColor = System.Drawing.SystemColors.Control;
			Label9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label9.ForeColor = System.Drawing.SystemColors.ControlText;
			Label9.Location = new System.Drawing.Point(16, 72);
			Label9.MinimumSize = new System.Drawing.Size(127, 17);
			Label9.Name = "Label9";
			Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label9.Size = new System.Drawing.Size(127, 17);
			Label9.TabIndex = 24;
			Label9.Text = "First Name";
			// 
			// Label8
			// 
			Label8.AllowDrop = true;
			Label8.BackColor = System.Drawing.SystemColors.Control;
			Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			Label8.Location = new System.Drawing.Point(317, 72);
			Label8.MinimumSize = new System.Drawing.Size(139, 17);
			Label8.Name = "Label8";
			Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label8.Size = new System.Drawing.Size(139, 17);
			Label8.TabIndex = 23;
			Label8.Text = "Last Name";
			// 
			// Label7
			// 
			Label7.AllowDrop = true;
			Label7.BackColor = System.Drawing.SystemColors.Control;
			Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			Label7.Location = new System.Drawing.Point(13, 108);
			Label7.MinimumSize = new System.Drawing.Size(143, 17);
			Label7.Name = "Label7";
			Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label7.Size = new System.Drawing.Size(143, 17);
			Label7.TabIndex = 22;
			Label7.Text = "Password";
			// 
			// FG_Users
			// 
			FG_Users.AllowDrop = true;
			FG_Users.AllowUserToAddRows = false;
			FG_Users.AllowUserToDeleteRows = false;
			FG_Users.AllowUserToResizeColumns = false;
			FG_Users.AllowUserToResizeColumns = FG_Users.ColumnHeadersVisible;
			FG_Users.AllowUserToResizeRows = false;
			FG_Users.AllowUserToResizeRows = false;
			FG_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Users.ColumnsCount = 19;
			FG_Users.FixedColumns = 0;
			FG_Users.FixedRows = 1;
			FG_Users.Location = new System.Drawing.Point(14, 30);
			FG_Users.Name = "FG_Users";
			FG_Users.ReadOnly = true;
			FG_Users.RowsCount = 2;
			FG_Users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Users.ShowCellToolTips = false;
			FG_Users.Size = new System.Drawing.Size(308, 521);
			FG_Users.StandardTab = true;
			FG_Users.TabIndex = 32;
			FG_Users.Click += new System.EventHandler(FG_Users_Click);
			// 
			// cmd_Add_User
			// 
			cmd_Add_User.AllowDrop = true;
			cmd_Add_User.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_User.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_User.Location = new System.Drawing.Point(337, 30);
			cmd_Add_User.Name = "cmd_Add_User";
			cmd_Add_User.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_User.Size = new System.Drawing.Size(57, 25);
			cmd_Add_User.TabIndex = 34;
			cmd_Add_User.Text = "&Add";
			cmd_Add_User.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_User.UseVisualStyleBackColor = false;
			cmd_Add_User.Click += new System.EventHandler(cmd_Add_User_Click);
			// 
			// chkIncludeInactive
			// 
			chkIncludeInactive.AllowDrop = true;
			chkIncludeInactive.Appearance = System.Windows.Forms.Appearance.Normal;
			chkIncludeInactive.BackColor = System.Drawing.SystemColors.Control;
			chkIncludeInactive.CausesValidation = true;
			chkIncludeInactive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIncludeInactive.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkIncludeInactive.Enabled = true;
			chkIncludeInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkIncludeInactive.ForeColor = System.Drawing.SystemColors.ControlText;
			chkIncludeInactive.Location = new System.Drawing.Point(14, 4);
			chkIncludeInactive.Name = "chkIncludeInactive";
			chkIncludeInactive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkIncludeInactive.Size = new System.Drawing.Size(103, 23);
			chkIncludeInactive.TabIndex = 217;
			chkIncludeInactive.TabStop = true;
			chkIncludeInactive.Text = "Log User Access";
			chkIncludeInactive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIncludeInactive.Visible = true;
			chkIncludeInactive.CheckStateChanged += new System.EventHandler(chkIncludeInactive_CheckStateChanged);
			// 
			// _tab_Lookup_TabPage3
			// 
			_tab_Lookup_TabPage3.Controls.Add(cmd_Add_Service);
			_tab_Lookup_TabPage3.Controls.Add(FG_Service);
			_tab_Lookup_TabPage3.Controls.Add(grd_Subscriptions);
			_tab_Lookup_TabPage3.Controls.Add(pnl_Service_Update_Change);
			_tab_Lookup_TabPage3.Controls.Add(lbl_Subscriptions);
			_tab_Lookup_TabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage3.Text = "Service";
			// 
			// cmd_Add_Service
			// 
			cmd_Add_Service.AllowDrop = true;
			cmd_Add_Service.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Service.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Service.Location = new System.Drawing.Point(299, 15);
			cmd_Add_Service.Name = "cmd_Add_Service";
			cmd_Add_Service.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Service.Size = new System.Drawing.Size(57, 25);
			cmd_Add_Service.TabIndex = 134;
			cmd_Add_Service.Text = "&Add";
			cmd_Add_Service.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Service.UseVisualStyleBackColor = false;
			cmd_Add_Service.Click += new System.EventHandler(cmd_Add_Service_Click);
			// 
			// FG_Service
			// 
			FG_Service.AllowDrop = true;
			FG_Service.AllowUserToAddRows = false;
			FG_Service.AllowUserToDeleteRows = false;
			FG_Service.AllowUserToResizeColumns = false;
			FG_Service.AllowUserToResizeRows = false;
			FG_Service.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Service.ColumnsCount = 8;
			FG_Service.FixedColumns = 0;
			FG_Service.FixedRows = 1;
			FG_Service.Location = new System.Drawing.Point(19, 21);
			FG_Service.Name = "FG_Service";
			FG_Service.ReadOnly = true;
			FG_Service.RowsCount = 2;
			FG_Service.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Service.ShowCellToolTips = false;
			FG_Service.Size = new System.Drawing.Size(251, 453);
			FG_Service.StandardTab = true;
			FG_Service.TabIndex = 133;
			FG_Service.Visible = false;
			FG_Service.Click += new System.EventHandler(FG_Service_Click);
			// 
			// grd_Subscriptions
			// 
			grd_Subscriptions.AllowDrop = true;
			grd_Subscriptions.AllowUserToAddRows = false;
			grd_Subscriptions.AllowUserToDeleteRows = false;
			grd_Subscriptions.AllowUserToResizeColumns = false;
			grd_Subscriptions.AllowUserToResizeRows = false;
			grd_Subscriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Subscriptions.ColumnsCount = 2;
			grd_Subscriptions.FixedColumns = 1;
			grd_Subscriptions.FixedRows = 1;
			grd_Subscriptions.Location = new System.Drawing.Point(298, 370);
			grd_Subscriptions.Name = "grd_Subscriptions";
			grd_Subscriptions.ReadOnly = true;
			grd_Subscriptions.RowsCount = 2;
			grd_Subscriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_Subscriptions.ShowCellToolTips = false;
			grd_Subscriptions.Size = new System.Drawing.Size(477, 109);
			grd_Subscriptions.StandardTab = true;
			grd_Subscriptions.TabIndex = 97;
			// 
			// pnl_Service_Update_Change
			// 
			pnl_Service_Update_Change.AllowDrop = true;
			pnl_Service_Update_Change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Service_Update_Change.Controls.Add(_chk_service_5);
			pnl_Service_Update_Change.Controls.Add(_chk_service_4);
			pnl_Service_Update_Change.Controls.Add(_chk_service_3);
			pnl_Service_Update_Change.Controls.Add(_chk_service_2);
			pnl_Service_Update_Change.Controls.Add(_chk_service_1);
			pnl_Service_Update_Change.Controls.Add(_chk_service_0);
			pnl_Service_Update_Change.Controls.Add(txt_serv_description);
			pnl_Service_Update_Change.Controls.Add(txt_serv_name);
			pnl_Service_Update_Change.Controls.Add(cmd_Delete_Service);
			pnl_Service_Update_Change.Controls.Add(cmd_Cancel_Service);
			pnl_Service_Update_Change.Controls.Add(cmd_Save_Service);
			pnl_Service_Update_Change.Controls.Add(txt_serv_code);
			pnl_Service_Update_Change.Controls.Add(Label30);
			pnl_Service_Update_Change.Controls.Add(Label29);
			pnl_Service_Update_Change.Controls.Add(lbl_serv_upd_date);
			pnl_Service_Update_Change.Controls.Add(lbl_serv_upd_user_id);
			pnl_Service_Update_Change.Controls.Add(Label36);
			pnl_Service_Update_Change.Controls.Add(Label35);
			pnl_Service_Update_Change.Controls.Add(Label33);
			pnl_Service_Update_Change.Controls.Add(Label26);
			pnl_Service_Update_Change.Controls.Add(Label25);
			pnl_Service_Update_Change.Controls.Add(lbl_serv_entry_date);
			pnl_Service_Update_Change.Controls.Add(lbl_serv_entry_user_id);
			pnl_Service_Update_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Service_Update_Change.Location = new System.Drawing.Point(298, 43);
			pnl_Service_Update_Change.Name = "pnl_Service_Update_Change";
			pnl_Service_Update_Change.Size = new System.Drawing.Size(681, 315);
			pnl_Service_Update_Change.TabIndex = 79;
			pnl_Service_Update_Change.Visible = false;
			// 
			// _chk_service_5
			// 
			_chk_service_5.AllowDrop = true;
			_chk_service_5.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_service_5.BackColor = System.Drawing.SystemColors.Control;
			_chk_service_5.CausesValidation = true;
			_chk_service_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_service_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_service_5.Enabled = true;
			_chk_service_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_service_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_service_5.Location = new System.Drawing.Point(544, 64);
			_chk_service_5.Name = "_chk_service_5";
			_chk_service_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_service_5.Size = new System.Drawing.Size(89, 25);
			_chk_service_5.TabIndex = 257;
			_chk_service_5.TabStop = true;
			_chk_service_5.Text = "Custom Rep";
			_chk_service_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_service_5.Visible = true;
			_chk_service_5.MouseDown += new System.Windows.Forms.MouseEventHandler(chk_service_MouseDown);
			// 
			// _chk_service_4
			// 
			_chk_service_4.AllowDrop = true;
			_chk_service_4.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_service_4.BackColor = System.Drawing.SystemColors.Control;
			_chk_service_4.CausesValidation = true;
			_chk_service_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_service_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_service_4.Enabled = true;
			_chk_service_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_service_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_service_4.Location = new System.Drawing.Point(440, 64);
			_chk_service_4.Name = "_chk_service_4";
			_chk_service_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_service_4.Size = new System.Drawing.Size(89, 25);
			_chk_service_4.TabIndex = 256;
			_chk_service_4.TabStop = true;
			_chk_service_4.Text = "JETNET IQ";
			_chk_service_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_service_4.Visible = true;
			_chk_service_4.MouseDown += new System.Windows.Forms.MouseEventHandler(chk_service_MouseDown);
			// 
			// _chk_service_3
			// 
			_chk_service_3.AllowDrop = true;
			_chk_service_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_service_3.BackColor = System.Drawing.SystemColors.Control;
			_chk_service_3.CausesValidation = true;
			_chk_service_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_service_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_service_3.Enabled = true;
			_chk_service_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_service_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_service_3.Location = new System.Drawing.Point(544, 40);
			_chk_service_3.Name = "_chk_service_3";
			_chk_service_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_service_3.Size = new System.Drawing.Size(89, 25);
			_chk_service_3.TabIndex = 255;
			_chk_service_3.TabStop = true;
			_chk_service_3.Text = "Salesforce";
			_chk_service_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_service_3.Visible = true;
			_chk_service_3.MouseDown += new System.Windows.Forms.MouseEventHandler(chk_service_MouseDown);
			// 
			// _chk_service_2
			// 
			_chk_service_2.AllowDrop = true;
			_chk_service_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_service_2.BackColor = System.Drawing.SystemColors.Control;
			_chk_service_2.CausesValidation = true;
			_chk_service_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_service_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_service_2.Enabled = true;
			_chk_service_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_service_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_service_2.Location = new System.Drawing.Point(440, 36);
			_chk_service_2.Name = "_chk_service_2";
			_chk_service_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_service_2.Size = new System.Drawing.Size(89, 25);
			_chk_service_2.TabIndex = 254;
			_chk_service_2.TabStop = true;
			_chk_service_2.Text = "BI";
			_chk_service_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_service_2.Visible = true;
			_chk_service_2.MouseDown += new System.Windows.Forms.MouseEventHandler(chk_service_MouseDown);
			// 
			// _chk_service_1
			// 
			_chk_service_1.AllowDrop = true;
			_chk_service_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_service_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_service_1.CausesValidation = true;
			_chk_service_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_service_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_service_1.Enabled = true;
			_chk_service_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_service_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_service_1.Location = new System.Drawing.Point(544, 8);
			_chk_service_1.Name = "_chk_service_1";
			_chk_service_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_service_1.Size = new System.Drawing.Size(89, 25);
			_chk_service_1.TabIndex = 253;
			_chk_service_1.TabStop = true;
			_chk_service_1.Text = "API";
			_chk_service_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_service_1.Visible = true;
			_chk_service_1.MouseDown += new System.Windows.Forms.MouseEventHandler(chk_service_MouseDown);
			// 
			// _chk_service_0
			// 
			_chk_service_0.AllowDrop = true;
			_chk_service_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_service_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_service_0.CausesValidation = true;
			_chk_service_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_service_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_service_0.Enabled = true;
			_chk_service_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_service_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_service_0.Location = new System.Drawing.Point(440, 8);
			_chk_service_0.Name = "_chk_service_0";
			_chk_service_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_service_0.Size = new System.Drawing.Size(89, 25);
			_chk_service_0.TabIndex = 252;
			_chk_service_0.TabStop = true;
			_chk_service_0.Text = "Evo";
			_chk_service_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_service_0.Visible = true;
			_chk_service_0.MouseDown += new System.Windows.Forms.MouseEventHandler(chk_service_MouseDown);
			// 
			// txt_serv_description
			// 
			txt_serv_description.AcceptsReturn = true;
			txt_serv_description.AllowDrop = true;
			txt_serv_description.BackColor = System.Drawing.SystemColors.Window;
			txt_serv_description.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_serv_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_serv_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_serv_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_serv_description.Location = new System.Drawing.Point(16, 140);
			txt_serv_description.MaxLength = 250;
			txt_serv_description.Name = "txt_serv_description";
			txt_serv_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_serv_description.Size = new System.Drawing.Size(413, 119);
			txt_serv_description.TabIndex = 85;
			// 
			// txt_serv_name
			// 
			txt_serv_name.AcceptsReturn = true;
			txt_serv_name.AllowDrop = true;
			txt_serv_name.BackColor = System.Drawing.SystemColors.Window;
			txt_serv_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_serv_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_serv_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_serv_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_serv_name.Location = new System.Drawing.Point(16, 98);
			txt_serv_name.MaxLength = 70;
			txt_serv_name.Name = "txt_serv_name";
			txt_serv_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_serv_name.Size = new System.Drawing.Size(411, 19);
			txt_serv_name.TabIndex = 84;
			txt_serv_name.TabStop = false;
			// 
			// cmd_Delete_Service
			// 
			cmd_Delete_Service.AllowDrop = true;
			cmd_Delete_Service.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Service.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Service.Location = new System.Drawing.Point(246, 7);
			cmd_Delete_Service.Name = "cmd_Delete_Service";
			cmd_Delete_Service.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Service.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Service.TabIndex = 83;
			cmd_Delete_Service.Text = "&Delete";
			cmd_Delete_Service.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Service.UseVisualStyleBackColor = false;
			cmd_Delete_Service.Click += new System.EventHandler(cmd_Delete_Service_Click);
			// 
			// cmd_Cancel_Service
			// 
			cmd_Cancel_Service.AllowDrop = true;
			cmd_Cancel_Service.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Service.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Service.Location = new System.Drawing.Point(168, 7);
			cmd_Cancel_Service.Name = "cmd_Cancel_Service";
			cmd_Cancel_Service.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Service.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_Service.TabIndex = 82;
			cmd_Cancel_Service.Text = "&Cancel";
			cmd_Cancel_Service.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Service.UseVisualStyleBackColor = false;
			cmd_Cancel_Service.Visible = false;
			cmd_Cancel_Service.Click += new System.EventHandler(cmd_Cancel_Service_Click);
			// 
			// cmd_Save_Service
			// 
			cmd_Save_Service.AllowDrop = true;
			cmd_Save_Service.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Service.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Service.Location = new System.Drawing.Point(92, 7);
			cmd_Save_Service.Name = "cmd_Save_Service";
			cmd_Save_Service.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Service.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Service.TabIndex = 81;
			cmd_Save_Service.Text = "&Save";
			cmd_Save_Service.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Service.UseVisualStyleBackColor = false;
			cmd_Save_Service.Click += new System.EventHandler(cmd_Save_Service_Click);
			// 
			// txt_serv_code
			// 
			txt_serv_code.AcceptsReturn = true;
			txt_serv_code.AllowDrop = true;
			txt_serv_code.BackColor = System.Drawing.SystemColors.Window;
			txt_serv_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_serv_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_serv_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_serv_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_serv_code.Location = new System.Drawing.Point(18, 53);
			txt_serv_code.MaxLength = 8;
			txt_serv_code.Name = "txt_serv_code";
			txt_serv_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_serv_code.Size = new System.Drawing.Size(65, 19);
			txt_serv_code.TabIndex = 80;
			txt_serv_code.Leave += new System.EventHandler(txt_serv_code_Leave);
			// 
			// Label30
			// 
			Label30.AllowDrop = true;
			Label30.BackColor = System.Drawing.SystemColors.Control;
			Label30.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label30.ForeColor = System.Drawing.SystemColors.ControlText;
			Label30.Location = new System.Drawing.Point(252, 266);
			Label30.MinimumSize = new System.Drawing.Size(75, 17);
			Label30.Name = "Label30";
			Label30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label30.Size = new System.Drawing.Size(75, 17);
			Label30.TabIndex = 96;
			Label30.Text = "Updated";
			// 
			// Label29
			// 
			Label29.AllowDrop = true;
			Label29.BackColor = System.Drawing.SystemColors.Control;
			Label29.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label29.ForeColor = System.Drawing.SystemColors.ControlText;
			Label29.Location = new System.Drawing.Point(342, 268);
			Label29.MinimumSize = new System.Drawing.Size(81, 15);
			Label29.Name = "Label29";
			Label29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label29.Size = new System.Drawing.Size(81, 15);
			Label29.TabIndex = 95;
			Label29.Text = "By";
			// 
			// lbl_serv_upd_date
			// 
			lbl_serv_upd_date.AllowDrop = true;
			lbl_serv_upd_date.BackColor = System.Drawing.SystemColors.Control;
			lbl_serv_upd_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lbl_serv_upd_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_serv_upd_date.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_serv_upd_date.Location = new System.Drawing.Point(248, 284);
			lbl_serv_upd_date.MinimumSize = new System.Drawing.Size(83, 19);
			lbl_serv_upd_date.Name = "lbl_serv_upd_date";
			lbl_serv_upd_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_serv_upd_date.Size = new System.Drawing.Size(83, 19);
			lbl_serv_upd_date.TabIndex = 94;
			lbl_serv_upd_date.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_serv_upd_user_id
			// 
			lbl_serv_upd_user_id.AllowDrop = true;
			lbl_serv_upd_user_id.BackColor = System.Drawing.SystemColors.Control;
			lbl_serv_upd_user_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lbl_serv_upd_user_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_serv_upd_user_id.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_serv_upd_user_id.Location = new System.Drawing.Point(342, 284);
			lbl_serv_upd_user_id.MinimumSize = new System.Drawing.Size(83, 19);
			lbl_serv_upd_user_id.Name = "lbl_serv_upd_user_id";
			lbl_serv_upd_user_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_serv_upd_user_id.Size = new System.Drawing.Size(83, 19);
			lbl_serv_upd_user_id.TabIndex = 93;
			lbl_serv_upd_user_id.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Label36
			// 
			Label36.AllowDrop = true;
			Label36.BackColor = System.Drawing.SystemColors.Control;
			Label36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label36.ForeColor = System.Drawing.SystemColors.ControlText;
			Label36.Location = new System.Drawing.Point(14, 124);
			Label36.MinimumSize = new System.Drawing.Size(139, 17);
			Label36.Name = "Label36";
			Label36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label36.Size = new System.Drawing.Size(139, 17);
			Label36.TabIndex = 92;
			Label36.Text = "Description";
			// 
			// Label35
			// 
			Label35.AllowDrop = true;
			Label35.BackColor = System.Drawing.SystemColors.Control;
			Label35.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label35.ForeColor = System.Drawing.SystemColors.ControlText;
			Label35.Location = new System.Drawing.Point(16, 80);
			Label35.MinimumSize = new System.Drawing.Size(127, 17);
			Label35.Name = "Label35";
			Label35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label35.Size = new System.Drawing.Size(127, 17);
			Label35.TabIndex = 91;
			Label35.Text = "Name";
			// 
			// Label33
			// 
			Label33.AllowDrop = true;
			Label33.BackColor = System.Drawing.SystemColors.Control;
			Label33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label33.ForeColor = System.Drawing.SystemColors.ControlText;
			Label33.Location = new System.Drawing.Point(19, 36);
			Label33.MinimumSize = new System.Drawing.Size(127, 17);
			Label33.Name = "Label33";
			Label33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label33.Size = new System.Drawing.Size(127, 17);
			Label33.TabIndex = 90;
			Label33.Text = "Code";
			// 
			// Label26
			// 
			Label26.AllowDrop = true;
			Label26.BackColor = System.Drawing.SystemColors.Control;
			Label26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label26.ForeColor = System.Drawing.SystemColors.ControlText;
			Label26.Location = new System.Drawing.Point(18, 266);
			Label26.MinimumSize = new System.Drawing.Size(91, 17);
			Label26.Name = "Label26";
			Label26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label26.Size = new System.Drawing.Size(91, 17);
			Label26.TabIndex = 89;
			Label26.Text = "Entered";
			// 
			// Label25
			// 
			Label25.AllowDrop = true;
			Label25.BackColor = System.Drawing.SystemColors.Control;
			Label25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label25.ForeColor = System.Drawing.SystemColors.ControlText;
			Label25.Location = new System.Drawing.Point(112, 266);
			Label25.MinimumSize = new System.Drawing.Size(51, 15);
			Label25.Name = "Label25";
			Label25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label25.Size = new System.Drawing.Size(51, 15);
			Label25.TabIndex = 88;
			Label25.Text = "By";
			// 
			// lbl_serv_entry_date
			// 
			lbl_serv_entry_date.AllowDrop = true;
			lbl_serv_entry_date.BackColor = System.Drawing.SystemColors.Control;
			lbl_serv_entry_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lbl_serv_entry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_serv_entry_date.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_serv_entry_date.Location = new System.Drawing.Point(14, 284);
			lbl_serv_entry_date.MinimumSize = new System.Drawing.Size(83, 19);
			lbl_serv_entry_date.Name = "lbl_serv_entry_date";
			lbl_serv_entry_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_serv_entry_date.Size = new System.Drawing.Size(83, 19);
			lbl_serv_entry_date.TabIndex = 87;
			lbl_serv_entry_date.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_serv_entry_user_id
			// 
			lbl_serv_entry_user_id.AllowDrop = true;
			lbl_serv_entry_user_id.BackColor = System.Drawing.SystemColors.Control;
			lbl_serv_entry_user_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lbl_serv_entry_user_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_serv_entry_user_id.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_serv_entry_user_id.Location = new System.Drawing.Point(106, 284);
			lbl_serv_entry_user_id.MinimumSize = new System.Drawing.Size(83, 19);
			lbl_serv_entry_user_id.Name = "lbl_serv_entry_user_id";
			lbl_serv_entry_user_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_serv_entry_user_id.Size = new System.Drawing.Size(83, 19);
			lbl_serv_entry_user_id.TabIndex = 86;
			lbl_serv_entry_user_id.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_Subscriptions
			// 
			lbl_Subscriptions.AllowDrop = true;
			lbl_Subscriptions.BackColor = System.Drawing.SystemColors.Control;
			lbl_Subscriptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Subscriptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Subscriptions.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Subscriptions.Location = new System.Drawing.Point(303, 358);
			lbl_Subscriptions.MinimumSize = new System.Drawing.Size(123, 17);
			lbl_Subscriptions.Name = "lbl_Subscriptions";
			lbl_Subscriptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Subscriptions.Size = new System.Drawing.Size(123, 17);
			lbl_Subscriptions.TabIndex = 98;
			lbl_Subscriptions.Text = "Subscriptions";
			// 
			// _tab_Lookup_TabPage4
			// 
			_tab_Lookup_TabPage4.Controls.Add(cmdAddAccountRep);
			_tab_Lookup_TabPage4.Controls.Add(FG_AccountRep);
			_tab_Lookup_TabPage4.Controls.Add(pnlAcctRepUpdateChange);
			_tab_Lookup_TabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage4.Text = "Account Rep";
			// 
			// cmdAddAccountRep
			// 
			cmdAddAccountRep.AllowDrop = true;
			cmdAddAccountRep.BackColor = System.Drawing.SystemColors.Control;
			cmdAddAccountRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAddAccountRep.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAddAccountRep.Location = new System.Drawing.Point(473, 19);
			cmdAddAccountRep.Name = "cmdAddAccountRep";
			cmdAddAccountRep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAddAccountRep.Size = new System.Drawing.Size(62, 23);
			cmdAddAccountRep.TabIndex = 135;
			cmdAddAccountRep.Text = "Add";
			cmdAddAccountRep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAddAccountRep.UseVisualStyleBackColor = false;
			cmdAddAccountRep.Click += new System.EventHandler(cmdAddAccountRep_Click);
			// 
			// FG_AccountRep
			// 
			FG_AccountRep.AllowDrop = true;
			FG_AccountRep.AllowUserToAddRows = false;
			FG_AccountRep.AllowUserToDeleteRows = false;
			FG_AccountRep.AllowUserToResizeColumns = false;
			FG_AccountRep.AllowUserToResizeRows = false;
			FG_AccountRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_AccountRep.ColumnsCount = 4;
			FG_AccountRep.FixedColumns = 0;
			FG_AccountRep.FixedRows = 1;
			FG_AccountRep.Location = new System.Drawing.Point(24, 20);
			FG_AccountRep.Name = "FG_AccountRep";
			FG_AccountRep.ReadOnly = true;
			FG_AccountRep.RowsCount = 2;
			FG_AccountRep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_AccountRep.ShowCellToolTips = false;
			FG_AccountRep.Size = new System.Drawing.Size(434, 457);
			FG_AccountRep.StandardTab = true;
			FG_AccountRep.TabIndex = 132;
			FG_AccountRep.Click += new System.EventHandler(FG_AccountRep_Click);
			// 
			// pnlAcctRepUpdateChange
			// 
			pnlAcctRepUpdateChange.AllowDrop = true;
			pnlAcctRepUpdateChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlAcctRepUpdateChange.Controls.Add(cmdAcctRepSave);
			pnlAcctRepUpdateChange.Controls.Add(cmdAccountRepCancel);
			pnlAcctRepUpdateChange.Controls.Add(cmdAccountRepDelete);
			pnlAcctRepUpdateChange.Controls.Add(txt_accrep_user_id);
			pnlAcctRepUpdateChange.Controls.Add(txt_accrep_description);
			pnlAcctRepUpdateChange.Controls.Add(txt_accrep_account_type);
			pnlAcctRepUpdateChange.Controls.Add(txt_accrep_account_id);
			pnlAcctRepUpdateChange.Controls.Add(Label31);
			pnlAcctRepUpdateChange.Controls.Add(Label28);
			pnlAcctRepUpdateChange.Controls.Add(Label27);
			pnlAcctRepUpdateChange.Controls.Add(Label22);
			pnlAcctRepUpdateChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlAcctRepUpdateChange.Location = new System.Drawing.Point(469, 60);
			pnlAcctRepUpdateChange.Name = "pnlAcctRepUpdateChange";
			pnlAcctRepUpdateChange.Size = new System.Drawing.Size(343, 236);
			pnlAcctRepUpdateChange.TabIndex = 99;
			// 
			// cmdAcctRepSave
			// 
			cmdAcctRepSave.AllowDrop = true;
			cmdAcctRepSave.BackColor = System.Drawing.SystemColors.Control;
			cmdAcctRepSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAcctRepSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAcctRepSave.Location = new System.Drawing.Point(72, 14);
			cmdAcctRepSave.Name = "cmdAcctRepSave";
			cmdAcctRepSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAcctRepSave.Size = new System.Drawing.Size(57, 25);
			cmdAcctRepSave.TabIndex = 110;
			cmdAcctRepSave.Text = "&Save";
			cmdAcctRepSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAcctRepSave.UseVisualStyleBackColor = false;
			cmdAcctRepSave.Click += new System.EventHandler(cmdAcctRepSave_Click);
			// 
			// cmdAccountRepCancel
			// 
			cmdAccountRepCancel.AllowDrop = true;
			cmdAccountRepCancel.BackColor = System.Drawing.SystemColors.Control;
			cmdAccountRepCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAccountRepCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAccountRepCancel.Location = new System.Drawing.Point(135, 14);
			cmdAccountRepCancel.Name = "cmdAccountRepCancel";
			cmdAccountRepCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAccountRepCancel.Size = new System.Drawing.Size(57, 25);
			cmdAccountRepCancel.TabIndex = 109;
			cmdAccountRepCancel.Text = "&Cancel";
			cmdAccountRepCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAccountRepCancel.UseVisualStyleBackColor = false;
			cmdAccountRepCancel.Click += new System.EventHandler(cmdAccountRepCancel_Click);
			// 
			// cmdAccountRepDelete
			// 
			cmdAccountRepDelete.AllowDrop = true;
			cmdAccountRepDelete.BackColor = System.Drawing.SystemColors.Control;
			cmdAccountRepDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAccountRepDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAccountRepDelete.Location = new System.Drawing.Point(200, 12);
			cmdAccountRepDelete.Name = "cmdAccountRepDelete";
			cmdAccountRepDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAccountRepDelete.Size = new System.Drawing.Size(57, 25);
			cmdAccountRepDelete.TabIndex = 108;
			cmdAccountRepDelete.Text = "&Delete";
			cmdAccountRepDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAccountRepDelete.UseVisualStyleBackColor = false;
			cmdAccountRepDelete.Click += new System.EventHandler(cmdAccountRepDelete_Click);
			// 
			// txt_accrep_user_id
			// 
			txt_accrep_user_id.AcceptsReturn = true;
			txt_accrep_user_id.AllowDrop = true;
			txt_accrep_user_id.BackColor = System.Drawing.SystemColors.Window;
			txt_accrep_user_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_accrep_user_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_accrep_user_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_accrep_user_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_accrep_user_id.Location = new System.Drawing.Point(26, 205);
			txt_accrep_user_id.MaxLength = 4;
			txt_accrep_user_id.Name = "txt_accrep_user_id";
			txt_accrep_user_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_accrep_user_id.Size = new System.Drawing.Size(52, 19);
			txt_accrep_user_id.TabIndex = 106;
			// 
			// txt_accrep_description
			// 
			txt_accrep_description.AcceptsReturn = true;
			txt_accrep_description.AllowDrop = true;
			txt_accrep_description.BackColor = System.Drawing.SystemColors.Window;
			txt_accrep_description.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_accrep_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_accrep_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_accrep_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_accrep_description.Location = new System.Drawing.Point(26, 107);
			txt_accrep_description.MaxLength = 250;
			txt_accrep_description.Multiline = true;
			txt_accrep_description.Name = "txt_accrep_description";
			txt_accrep_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_accrep_description.Size = new System.Drawing.Size(294, 76);
			txt_accrep_description.TabIndex = 104;
			// 
			// txt_accrep_account_type
			// 
			txt_accrep_account_type.AcceptsReturn = true;
			txt_accrep_account_type.AllowDrop = true;
			txt_accrep_account_type.BackColor = System.Drawing.SystemColors.Window;
			txt_accrep_account_type.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_accrep_account_type.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_accrep_account_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_accrep_account_type.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_accrep_account_type.Location = new System.Drawing.Point(109, 66);
			txt_accrep_account_type.MaxLength = 2;
			txt_accrep_account_type.Name = "txt_accrep_account_type";
			txt_accrep_account_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_accrep_account_type.Size = new System.Drawing.Size(30, 19);
			txt_accrep_account_type.TabIndex = 102;
			txt_accrep_account_type.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_accrep_account_type_KeyPress);
			// 
			// txt_accrep_account_id
			// 
			txt_accrep_account_id.AcceptsReturn = true;
			txt_accrep_account_id.AllowDrop = true;
			txt_accrep_account_id.BackColor = System.Drawing.SystemColors.Window;
			txt_accrep_account_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_accrep_account_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_accrep_account_id.Enabled = false;
			txt_accrep_account_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_accrep_account_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_accrep_account_id.Location = new System.Drawing.Point(25, 65);
			txt_accrep_account_id.MaxLength = 4;
			txt_accrep_account_id.Name = "txt_accrep_account_id";
			txt_accrep_account_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_accrep_account_id.Size = new System.Drawing.Size(52, 19);
			txt_accrep_account_id.TabIndex = 100;
			txt_accrep_account_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_accrep_account_id_KeyPress);
			// 
			// Label31
			// 
			Label31.AllowDrop = true;
			Label31.AutoSize = true;
			Label31.BackColor = System.Drawing.SystemColors.Control;
			Label31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label31.ForeColor = System.Drawing.SystemColors.ControlText;
			Label31.Location = new System.Drawing.Point(26, 190);
			Label31.MinimumSize = new System.Drawing.Size(79, 13);
			Label31.Name = "Label31";
			Label31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label31.Size = new System.Drawing.Size(79, 13);
			Label31.TabIndex = 107;
			Label31.Text = "Account User ID";
			// 
			// Label28
			// 
			Label28.AllowDrop = true;
			Label28.AutoSize = true;
			Label28.BackColor = System.Drawing.SystemColors.Control;
			Label28.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label28.ForeColor = System.Drawing.SystemColors.ControlText;
			Label28.Location = new System.Drawing.Point(26, 92);
			Label28.MinimumSize = new System.Drawing.Size(53, 13);
			Label28.Name = "Label28";
			Label28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label28.Size = new System.Drawing.Size(53, 13);
			Label28.TabIndex = 105;
			Label28.Text = "Description";
			// 
			// Label27
			// 
			Label27.AllowDrop = true;
			Label27.AutoSize = true;
			Label27.BackColor = System.Drawing.SystemColors.Control;
			Label27.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label27.ForeColor = System.Drawing.SystemColors.ControlText;
			Label27.Location = new System.Drawing.Point(109, 51);
			Label27.MinimumSize = new System.Drawing.Size(67, 13);
			Label27.Name = "Label27";
			Label27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label27.Size = new System.Drawing.Size(67, 13);
			Label27.TabIndex = 103;
			Label27.Text = "Account Type";
			// 
			// Label22
			// 
			Label22.AllowDrop = true;
			Label22.AutoSize = true;
			Label22.BackColor = System.Drawing.SystemColors.Control;
			Label22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label22.ForeColor = System.Drawing.SystemColors.ControlText;
			Label22.Location = new System.Drawing.Point(26, 50);
			Label22.MinimumSize = new System.Drawing.Size(54, 13);
			Label22.Name = "Label22";
			Label22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label22.Size = new System.Drawing.Size(54, 13);
			Label22.TabIndex = 101;
			Label22.Text = "Account ID";
			// 
			// _tab_Lookup_TabPage5
			// 
			_tab_Lookup_TabPage5.Controls.Add(txt_Total_Company_Locked);
			_tab_Lookup_TabPage5.Controls.Add(txt_Total_Contact_Locked);
			_tab_Lookup_TabPage5.Controls.Add(txt_Total_Aircraft_Locked);
			_tab_Lookup_TabPage5.Controls.Add(cmd_Clear_Aircraft_Record_Locks);
			_tab_Lookup_TabPage5.Controls.Add(cmd_Clear_Contact_Record_locks);
			_tab_Lookup_TabPage5.Controls.Add(cmd_Clear_Company_Record_Locks);
			_tab_Lookup_TabPage5.Controls.Add(lbl_locks);
			_tab_Lookup_TabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage5.Text = "Table Locking";
			// 
			// txt_Total_Company_Locked
			// 
			txt_Total_Company_Locked.AcceptsReturn = true;
			txt_Total_Company_Locked.AllowDrop = true;
			txt_Total_Company_Locked.BackColor = System.Drawing.SystemColors.Window;
			txt_Total_Company_Locked.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Total_Company_Locked.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Total_Company_Locked.Enabled = false;
			txt_Total_Company_Locked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Total_Company_Locked.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Total_Company_Locked.Location = new System.Drawing.Point(305, 80);
			txt_Total_Company_Locked.MaxLength = 0;
			txt_Total_Company_Locked.Name = "txt_Total_Company_Locked";
			txt_Total_Company_Locked.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Total_Company_Locked.Size = new System.Drawing.Size(51, 19);
			txt_Total_Company_Locked.TabIndex = 119;
			txt_Total_Company_Locked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_Total_Contact_Locked
			// 
			txt_Total_Contact_Locked.AcceptsReturn = true;
			txt_Total_Contact_Locked.AllowDrop = true;
			txt_Total_Contact_Locked.BackColor = System.Drawing.SystemColors.Window;
			txt_Total_Contact_Locked.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Total_Contact_Locked.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Total_Contact_Locked.Enabled = false;
			txt_Total_Contact_Locked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Total_Contact_Locked.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Total_Contact_Locked.Location = new System.Drawing.Point(305, 166);
			txt_Total_Contact_Locked.MaxLength = 0;
			txt_Total_Contact_Locked.Name = "txt_Total_Contact_Locked";
			txt_Total_Contact_Locked.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Total_Contact_Locked.Size = new System.Drawing.Size(51, 19);
			txt_Total_Contact_Locked.TabIndex = 118;
			txt_Total_Contact_Locked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_Total_Aircraft_Locked
			// 
			txt_Total_Aircraft_Locked.AcceptsReturn = true;
			txt_Total_Aircraft_Locked.AllowDrop = true;
			txt_Total_Aircraft_Locked.BackColor = System.Drawing.SystemColors.Window;
			txt_Total_Aircraft_Locked.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Total_Aircraft_Locked.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Total_Aircraft_Locked.Enabled = false;
			txt_Total_Aircraft_Locked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Total_Aircraft_Locked.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Total_Aircraft_Locked.Location = new System.Drawing.Point(305, 242);
			txt_Total_Aircraft_Locked.MaxLength = 0;
			txt_Total_Aircraft_Locked.Name = "txt_Total_Aircraft_Locked";
			txt_Total_Aircraft_Locked.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Total_Aircraft_Locked.Size = new System.Drawing.Size(51, 19);
			txt_Total_Aircraft_Locked.TabIndex = 117;
			txt_Total_Aircraft_Locked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmd_Clear_Aircraft_Record_Locks
			// 
			cmd_Clear_Aircraft_Record_Locks.AllowDrop = true;
			cmd_Clear_Aircraft_Record_Locks.BackColor = System.Drawing.SystemColors.Control;
			cmd_Clear_Aircraft_Record_Locks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Clear_Aircraft_Record_Locks.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Clear_Aircraft_Record_Locks.Location = new System.Drawing.Point(73, 227);
			cmd_Clear_Aircraft_Record_Locks.Name = "cmd_Clear_Aircraft_Record_Locks";
			cmd_Clear_Aircraft_Record_Locks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Clear_Aircraft_Record_Locks.Size = new System.Drawing.Size(176, 45);
			cmd_Clear_Aircraft_Record_Locks.TabIndex = 115;
			cmd_Clear_Aircraft_Record_Locks.Text = "&Clear Aircraft Record Locks ";
			cmd_Clear_Aircraft_Record_Locks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Clear_Aircraft_Record_Locks.UseVisualStyleBackColor = false;
			cmd_Clear_Aircraft_Record_Locks.Click += new System.EventHandler(cmd_Clear_Aircraft_Record_Locks_Click);
			// 
			// cmd_Clear_Contact_Record_locks
			// 
			cmd_Clear_Contact_Record_locks.AllowDrop = true;
			cmd_Clear_Contact_Record_locks.BackColor = System.Drawing.SystemColors.Control;
			cmd_Clear_Contact_Record_locks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Clear_Contact_Record_locks.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Clear_Contact_Record_locks.Location = new System.Drawing.Point(74, 153);
			cmd_Clear_Contact_Record_locks.Name = "cmd_Clear_Contact_Record_locks";
			cmd_Clear_Contact_Record_locks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Clear_Contact_Record_locks.Size = new System.Drawing.Size(176, 45);
			cmd_Clear_Contact_Record_locks.TabIndex = 114;
			cmd_Clear_Contact_Record_locks.Text = "&Clear Contact Record Locks ";
			cmd_Clear_Contact_Record_locks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Clear_Contact_Record_locks.UseVisualStyleBackColor = false;
			cmd_Clear_Contact_Record_locks.Click += new System.EventHandler(cmd_Clear_Contact_Record_locks_Click);
			// 
			// cmd_Clear_Company_Record_Locks
			// 
			cmd_Clear_Company_Record_Locks.AllowDrop = true;
			cmd_Clear_Company_Record_Locks.BackColor = System.Drawing.SystemColors.Control;
			cmd_Clear_Company_Record_Locks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Clear_Company_Record_Locks.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Clear_Company_Record_Locks.Location = new System.Drawing.Point(71, 68);
			cmd_Clear_Company_Record_Locks.Name = "cmd_Clear_Company_Record_Locks";
			cmd_Clear_Company_Record_Locks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Clear_Company_Record_Locks.Size = new System.Drawing.Size(176, 45);
			cmd_Clear_Company_Record_Locks.TabIndex = 113;
			cmd_Clear_Company_Record_Locks.Text = "&Clear Company Record Locks ";
			cmd_Clear_Company_Record_Locks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Clear_Company_Record_Locks.UseVisualStyleBackColor = false;
			cmd_Clear_Company_Record_Locks.Click += new System.EventHandler(cmd_Clear_Company_Record_Locks_Click);
			// 
			// lbl_locks
			// 
			lbl_locks.AllowDrop = true;
			lbl_locks.BackColor = System.Drawing.SystemColors.Control;
			lbl_locks.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_locks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_locks.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_locks.Location = new System.Drawing.Point(287, 19);
			lbl_locks.MinimumSize = new System.Drawing.Size(125, 30);
			lbl_locks.Name = "lbl_locks";
			lbl_locks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_locks.Size = new System.Drawing.Size(125, 30);
			lbl_locks.TabIndex = 116;
			lbl_locks.Text = "# of Locked Records:";
			// 
			// _tab_Lookup_TabPage6
			// 
			_tab_Lookup_TabPage6.Controls.Add(lblTotalCompOrphanPhoneNbrs);
			_tab_Lookup_TabPage6.Controls.Add(lblTotalContactOrphanPhoneNbrs);
			_tab_Lookup_TabPage6.Controls.Add(cmdCheckCompOrphanPhoneNbrs);
			_tab_Lookup_TabPage6.Controls.Add(cmdCheckContactOrphanPhoneNbrs);
			_tab_Lookup_TabPage6.Controls.Add(cmdRemoveCompOrphanPhoneNbrs);
			_tab_Lookup_TabPage6.Controls.Add(cmdRemoveContactOrphanPhoneNbrs);
			_tab_Lookup_TabPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage6.Text = "Error Correction";
			// 
			// lblTotalCompOrphanPhoneNbrs
			// 
			lblTotalCompOrphanPhoneNbrs.AllowDrop = true;
			lblTotalCompOrphanPhoneNbrs.BackColor = System.Drawing.SystemColors.Control;
			lblTotalCompOrphanPhoneNbrs.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblTotalCompOrphanPhoneNbrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTotalCompOrphanPhoneNbrs.ForeColor = System.Drawing.SystemColors.ControlText;
			lblTotalCompOrphanPhoneNbrs.Location = new System.Drawing.Point(264, 64);
			lblTotalCompOrphanPhoneNbrs.MinimumSize = new System.Drawing.Size(263, 17);
			lblTotalCompOrphanPhoneNbrs.Name = "lblTotalCompOrphanPhoneNbrs";
			lblTotalCompOrphanPhoneNbrs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblTotalCompOrphanPhoneNbrs.Size = new System.Drawing.Size(263, 17);
			lblTotalCompOrphanPhoneNbrs.TabIndex = 222;
			lblTotalCompOrphanPhoneNbrs.Text = "Total Found: 0";
			// 
			// lblTotalContactOrphanPhoneNbrs
			// 
			lblTotalContactOrphanPhoneNbrs.AllowDrop = true;
			lblTotalContactOrphanPhoneNbrs.BackColor = System.Drawing.SystemColors.Control;
			lblTotalContactOrphanPhoneNbrs.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblTotalContactOrphanPhoneNbrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTotalContactOrphanPhoneNbrs.ForeColor = System.Drawing.SystemColors.ControlText;
			lblTotalContactOrphanPhoneNbrs.Location = new System.Drawing.Point(264, 154);
			lblTotalContactOrphanPhoneNbrs.MinimumSize = new System.Drawing.Size(263, 17);
			lblTotalContactOrphanPhoneNbrs.Name = "lblTotalContactOrphanPhoneNbrs";
			lblTotalContactOrphanPhoneNbrs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblTotalContactOrphanPhoneNbrs.Size = new System.Drawing.Size(263, 17);
			lblTotalContactOrphanPhoneNbrs.TabIndex = 223;
			lblTotalContactOrphanPhoneNbrs.Text = "Total Found: 0";
			// 
			// cmdCheckCompOrphanPhoneNbrs
			// 
			cmdCheckCompOrphanPhoneNbrs.AllowDrop = true;
			cmdCheckCompOrphanPhoneNbrs.BackColor = System.Drawing.SystemColors.Control;
			cmdCheckCompOrphanPhoneNbrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCheckCompOrphanPhoneNbrs.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCheckCompOrphanPhoneNbrs.Location = new System.Drawing.Point(32, 60);
			cmdCheckCompOrphanPhoneNbrs.Name = "cmdCheckCompOrphanPhoneNbrs";
			cmdCheckCompOrphanPhoneNbrs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCheckCompOrphanPhoneNbrs.Size = new System.Drawing.Size(209, 23);
			cmdCheckCompOrphanPhoneNbrs.TabIndex = 218;
			cmdCheckCompOrphanPhoneNbrs.Text = "Check Company Orphan Phone Nbrs";
			cmdCheckCompOrphanPhoneNbrs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCheckCompOrphanPhoneNbrs.UseVisualStyleBackColor = false;
			cmdCheckCompOrphanPhoneNbrs.Click += new System.EventHandler(cmdCheckCompOrphanPhoneNbrs_Click);
			// 
			// cmdCheckContactOrphanPhoneNbrs
			// 
			cmdCheckContactOrphanPhoneNbrs.AllowDrop = true;
			cmdCheckContactOrphanPhoneNbrs.BackColor = System.Drawing.SystemColors.Control;
			cmdCheckContactOrphanPhoneNbrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCheckContactOrphanPhoneNbrs.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCheckContactOrphanPhoneNbrs.Location = new System.Drawing.Point(32, 150);
			cmdCheckContactOrphanPhoneNbrs.Name = "cmdCheckContactOrphanPhoneNbrs";
			cmdCheckContactOrphanPhoneNbrs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCheckContactOrphanPhoneNbrs.Size = new System.Drawing.Size(209, 23);
			cmdCheckContactOrphanPhoneNbrs.TabIndex = 220;
			cmdCheckContactOrphanPhoneNbrs.Text = "Check Contact Orphan Phone Nbrs";
			cmdCheckContactOrphanPhoneNbrs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCheckContactOrphanPhoneNbrs.UseVisualStyleBackColor = false;
			cmdCheckContactOrphanPhoneNbrs.Click += new System.EventHandler(cmdCheckContactOrphanPhoneNbrs_Click);
			// 
			// cmdRemoveCompOrphanPhoneNbrs
			// 
			cmdRemoveCompOrphanPhoneNbrs.AllowDrop = true;
			cmdRemoveCompOrphanPhoneNbrs.BackColor = System.Drawing.SystemColors.Control;
			cmdRemoveCompOrphanPhoneNbrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRemoveCompOrphanPhoneNbrs.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRemoveCompOrphanPhoneNbrs.Location = new System.Drawing.Point(32, 86);
			cmdRemoveCompOrphanPhoneNbrs.Name = "cmdRemoveCompOrphanPhoneNbrs";
			cmdRemoveCompOrphanPhoneNbrs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRemoveCompOrphanPhoneNbrs.Size = new System.Drawing.Size(209, 23);
			cmdRemoveCompOrphanPhoneNbrs.TabIndex = 219;
			cmdRemoveCompOrphanPhoneNbrs.Text = "Remove Company Orphan Phone Nbrs";
			cmdRemoveCompOrphanPhoneNbrs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRemoveCompOrphanPhoneNbrs.UseVisualStyleBackColor = false;
			cmdRemoveCompOrphanPhoneNbrs.Visible = false;
			cmdRemoveCompOrphanPhoneNbrs.Click += new System.EventHandler(cmdRemoveCompOrphanPhoneNbrs_Click);
			// 
			// cmdRemoveContactOrphanPhoneNbrs
			// 
			cmdRemoveContactOrphanPhoneNbrs.AllowDrop = true;
			cmdRemoveContactOrphanPhoneNbrs.BackColor = System.Drawing.SystemColors.Control;
			cmdRemoveContactOrphanPhoneNbrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRemoveContactOrphanPhoneNbrs.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRemoveContactOrphanPhoneNbrs.Location = new System.Drawing.Point(32, 178);
			cmdRemoveContactOrphanPhoneNbrs.Name = "cmdRemoveContactOrphanPhoneNbrs";
			cmdRemoveContactOrphanPhoneNbrs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRemoveContactOrphanPhoneNbrs.Size = new System.Drawing.Size(209, 23);
			cmdRemoveContactOrphanPhoneNbrs.TabIndex = 221;
			cmdRemoveContactOrphanPhoneNbrs.Text = "Remove Contact Orphan Phone Nbrs";
			cmdRemoveContactOrphanPhoneNbrs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRemoveContactOrphanPhoneNbrs.UseVisualStyleBackColor = false;
			cmdRemoveContactOrphanPhoneNbrs.Visible = false;
			cmdRemoveContactOrphanPhoneNbrs.Click += new System.EventHandler(cmdRemoveContactOrphanPhoneNbrs_Click);
			// 
			// _tab_Lookup_TabPage7
			// 
			_tab_Lookup_TabPage7.Controls.Add(cmd_Analyze_Emails);
			_tab_Lookup_TabPage7.Controls.Add(grd_email);
			_tab_Lookup_TabPage7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage7.Text = "eMail Addresses";
			// 
			// cmd_Analyze_Emails
			// 
			cmd_Analyze_Emails.AllowDrop = true;
			cmd_Analyze_Emails.BackColor = System.Drawing.SystemColors.Control;
			cmd_Analyze_Emails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Analyze_Emails.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Analyze_Emails.Location = new System.Drawing.Point(75, 78);
			cmd_Analyze_Emails.Name = "cmd_Analyze_Emails";
			cmd_Analyze_Emails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Analyze_Emails.Size = new System.Drawing.Size(155, 22);
			cmd_Analyze_Emails.TabIndex = 128;
			cmd_Analyze_Emails.Text = "Analyze Emails";
			cmd_Analyze_Emails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Analyze_Emails.UseVisualStyleBackColor = false;
			cmd_Analyze_Emails.Click += new System.EventHandler(cmd_Analyze_Emails_Click);
			// 
			// grd_email
			// 
			grd_email.AllowDrop = true;
			grd_email.AllowUserToAddRows = false;
			grd_email.AllowUserToDeleteRows = false;
			grd_email.AllowUserToResizeColumns = false;
			grd_email.AllowUserToResizeRows = false;
			grd_email.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_email.ColumnsCount = 2;
			grd_email.FixedColumns = 1;
			grd_email.FixedRows = 1;
			grd_email.Location = new System.Drawing.Point(63, 115);
			grd_email.Name = "grd_email";
			grd_email.ReadOnly = true;
			grd_email.RowsCount = 2;
			grd_email.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_email.ShowCellToolTips = false;
			grd_email.Size = new System.Drawing.Size(394, 194);
			grd_email.StandardTab = true;
			grd_email.TabIndex = 129;
			grd_email.Visible = false;
			// 
			// _tab_Lookup_TabPage8
			// 
			_tab_Lookup_TabPage8.Controls.Add(frame_CustomField);
			_tab_Lookup_TabPage8.Controls.Add(btn_new);
			_tab_Lookup_TabPage8.Controls.Add(tabstrip_data);
			_tab_Lookup_TabPage8.Controls.Add(btn_send);
			_tab_Lookup_TabPage8.Controls.Add(cmd_refresh);
			_tab_Lookup_TabPage8.Controls.Add(cmd_sort_up);
			_tab_Lookup_TabPage8.Controls.Add(cmd_sort_down);
			_tab_Lookup_TabPage8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage8.Text = "Custom Export Fields";
			// 
			// frame_CustomField
			// 
			frame_CustomField.AllowDrop = true;
			frame_CustomField.BackColor = System.Drawing.SystemColors.Control;
			frame_CustomField.Controls.Add(txt_cef_list_select_query);
			frame_CustomField.Controls.Add(cbo_Help_Topic);
			frame_CustomField.Controls.Add(chk_cef_advanced_search_flag);
			frame_CustomField.Controls.Add(txt_cef_values);
			frame_CustomField.Controls.Add(txt_cef_definition);
			frame_CustomField.Controls.Add(cbo_tab);
			frame_CustomField.Controls.Add(cmd_run_summary_query);
			frame_CustomField.Controls.Add(cmd_delete);
			frame_CustomField.Controls.Add(btn_update_sub_group);
			frame_CustomField.Controls.Add(cbo_sub_number);
			frame_CustomField.Controls.Add(btn_test_query);
			frame_CustomField.Controls.Add(cbo_sort);
			frame_CustomField.Controls.Add(chk_summary_level);
			frame_CustomField.Controls.Add(txt_sub_group);
			frame_CustomField.Controls.Add(cbo_selected_group);
			frame_CustomField.Controls.Add(cbo_selected_sub_group);
			frame_CustomField.Controls.Add(txt_new_group);
			frame_CustomField.Controls.Add(frame_products);
			frame_CustomField.Controls.Add(cbo_field_type);
			frame_CustomField.Controls.Add(btn_save);
			frame_CustomField.Controls.Add(txt_length);
			frame_CustomField.Controls.Add(txt_field_name);
			frame_CustomField.Controls.Add(txt_header_name);
			frame_CustomField.Controls.Add(txt_display_name);
			frame_CustomField.Controls.Add(lbl_client_field);
			frame_CustomField.Controls.Add(Label49);
			frame_CustomField.Controls.Add(Label48);
			frame_CustomField.Controls.Add(Label47);
			frame_CustomField.Controls.Add(Label46);
			frame_CustomField.Controls.Add(Label45);
			frame_CustomField.Controls.Add(lbl_tab);
			frame_CustomField.Controls.Add(lbl_sort);
			frame_CustomField.Controls.Add(lbl_updated);
			frame_CustomField.Controls.Add(lbl_id);
			frame_CustomField.Controls.Add(lbl_cef_id);
			frame_CustomField.Controls.Add(lbl_length);
			frame_CustomField.Controls.Add(lbl_field_mapping);
			frame_CustomField.Controls.Add(lbl_display);
			frame_CustomField.Controls.Add(lbl_header);
			frame_CustomField.Controls.Add(lbl_sup_gruop);
			frame_CustomField.Controls.Add(lbl_group);
			frame_CustomField.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_CustomField.Enabled = true;
			frame_CustomField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_CustomField.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_CustomField.Location = new System.Drawing.Point(402, 6);
			frame_CustomField.Name = "frame_CustomField";
			frame_CustomField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_CustomField.Size = new System.Drawing.Size(585, 569);
			frame_CustomField.TabIndex = 157;
			frame_CustomField.Text = "Field Display & Update:";
			frame_CustomField.Visible = true;
			// 
			// txt_cef_list_select_query
			// 
			txt_cef_list_select_query.AcceptsReturn = true;
			txt_cef_list_select_query.AllowDrop = true;
			txt_cef_list_select_query.BackColor = System.Drawing.SystemColors.Window;
			txt_cef_list_select_query.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cef_list_select_query.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cef_list_select_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cef_list_select_query.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cef_list_select_query.Location = new System.Drawing.Point(8, 360);
			txt_cef_list_select_query.MaxLength = 0;
			txt_cef_list_select_query.Multiline = true;
			txt_cef_list_select_query.Name = "txt_cef_list_select_query";
			txt_cef_list_select_query.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cef_list_select_query.Size = new System.Drawing.Size(273, 49);
			txt_cef_list_select_query.TabIndex = 214;
			// 
			// cbo_Help_Topic
			// 
			cbo_Help_Topic.AllowDrop = true;
			cbo_Help_Topic.BackColor = System.Drawing.SystemColors.Window;
			cbo_Help_Topic.CausesValidation = true;
			cbo_Help_Topic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_Help_Topic.Enabled = true;
			cbo_Help_Topic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Help_Topic.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Help_Topic.IntegralHeight = true;
			cbo_Help_Topic.Location = new System.Drawing.Point(288, 400);
			cbo_Help_Topic.Name = "cbo_Help_Topic";
			cbo_Help_Topic.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Help_Topic.Size = new System.Drawing.Size(289, 21);
			cbo_Help_Topic.Sorted = false;
			cbo_Help_Topic.TabIndex = 211;
			cbo_Help_Topic.TabStop = true;
			cbo_Help_Topic.Visible = true;
			// 
			// chk_cef_advanced_search_flag
			// 
			chk_cef_advanced_search_flag.AllowDrop = true;
			chk_cef_advanced_search_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_cef_advanced_search_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_cef_advanced_search_flag.CausesValidation = true;
			chk_cef_advanced_search_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_cef_advanced_search_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_cef_advanced_search_flag.Enabled = true;
			chk_cef_advanced_search_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_cef_advanced_search_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_cef_advanced_search_flag.Location = new System.Drawing.Point(296, 352);
			chk_cef_advanced_search_flag.Name = "chk_cef_advanced_search_flag";
			chk_cef_advanced_search_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_cef_advanced_search_flag.Size = new System.Drawing.Size(241, 25);
			chk_cef_advanced_search_flag.TabIndex = 210;
			chk_cef_advanced_search_flag.TabStop = true;
			chk_cef_advanced_search_flag.Text = "Include Field on Advanced Search Tab?";
			chk_cef_advanced_search_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_cef_advanced_search_flag.Visible = true;
			// 
			// txt_cef_values
			// 
			txt_cef_values.AcceptsReturn = true;
			txt_cef_values.AllowDrop = true;
			txt_cef_values.BackColor = System.Drawing.SystemColors.Window;
			txt_cef_values.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cef_values.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cef_values.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cef_values.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cef_values.Location = new System.Drawing.Point(8, 424);
			txt_cef_values.MaxLength = 0;
			txt_cef_values.Multiline = true;
			txt_cef_values.Name = "txt_cef_values";
			txt_cef_values.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cef_values.Size = new System.Drawing.Size(273, 49);
			txt_cef_values.TabIndex = 208;
			// 
			// txt_cef_definition
			// 
			txt_cef_definition.AcceptsReturn = true;
			txt_cef_definition.AllowDrop = true;
			txt_cef_definition.BackColor = System.Drawing.SystemColors.Window;
			txt_cef_definition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cef_definition.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cef_definition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cef_definition.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cef_definition.Location = new System.Drawing.Point(8, 304);
			txt_cef_definition.MaxLength = 0;
			txt_cef_definition.Multiline = true;
			txt_cef_definition.Name = "txt_cef_definition";
			txt_cef_definition.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cef_definition.Size = new System.Drawing.Size(561, 41);
			txt_cef_definition.TabIndex = 205;
			// 
			// cbo_tab
			// 
			cbo_tab.AllowDrop = true;
			cbo_tab.BackColor = System.Drawing.SystemColors.Window;
			cbo_tab.CausesValidation = true;
			cbo_tab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_tab.Enabled = true;
			cbo_tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_tab.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_tab.IntegralHeight = true;
			cbo_tab.Location = new System.Drawing.Point(80, 32);
			cbo_tab.Name = "cbo_tab";
			cbo_tab.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_tab.Size = new System.Drawing.Size(177, 21);
			cbo_tab.Sorted = false;
			cbo_tab.TabIndex = 200;
			cbo_tab.TabStop = true;
			cbo_tab.Visible = true;
			cbo_tab.SelectionChangeCommitted += new System.EventHandler(cbo_tab_SelectionChangeCommitted);
			// 
			// cmd_run_summary_query
			// 
			cmd_run_summary_query.AllowDrop = true;
			cmd_run_summary_query.BackColor = System.Drawing.SystemColors.Control;
			cmd_run_summary_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_run_summary_query.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_run_summary_query.Location = new System.Drawing.Point(112, 536);
			cmd_run_summary_query.Name = "cmd_run_summary_query";
			cmd_run_summary_query.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_run_summary_query.Size = new System.Drawing.Size(89, 25);
			cmd_run_summary_query.TabIndex = 196;
			cmd_run_summary_query.Text = "Summary Test";
			cmd_run_summary_query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_run_summary_query.UseVisualStyleBackColor = false;
			cmd_run_summary_query.Visible = false;
			cmd_run_summary_query.Click += new System.EventHandler(cmd_run_summary_query_Click);
			// 
			// cmd_delete
			// 
			cmd_delete.AllowDrop = true;
			cmd_delete.BackColor = System.Drawing.SystemColors.Control;
			cmd_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_delete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_delete.Location = new System.Drawing.Point(232, 536);
			cmd_delete.Name = "cmd_delete";
			cmd_delete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_delete.Size = new System.Drawing.Size(73, 25);
			cmd_delete.TabIndex = 195;
			cmd_delete.Text = "Delete";
			cmd_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_delete.UseVisualStyleBackColor = false;
			cmd_delete.Click += new System.EventHandler(cmd_delete_Click);
			// 
			// btn_update_sub_group
			// 
			btn_update_sub_group.AllowDrop = true;
			btn_update_sub_group.BackColor = System.Drawing.SystemColors.Control;
			btn_update_sub_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_update_sub_group.ForeColor = System.Drawing.SystemColors.ControlText;
			btn_update_sub_group.Location = new System.Drawing.Point(432, 56);
			btn_update_sub_group.Name = "btn_update_sub_group";
			btn_update_sub_group.RightToLeft = System.Windows.Forms.RightToLeft.No;
			btn_update_sub_group.Size = new System.Drawing.Size(49, 17);
			btn_update_sub_group.TabIndex = 194;
			btn_update_sub_group.Text = "Set";
			btn_update_sub_group.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			btn_update_sub_group.UseVisualStyleBackColor = false;
			btn_update_sub_group.Click += new System.EventHandler(btn_update_sub_group_Click);
			// 
			// cbo_sub_number
			// 
			cbo_sub_number.AllowDrop = true;
			cbo_sub_number.BackColor = System.Drawing.SystemColors.Window;
			cbo_sub_number.CausesValidation = true;
			cbo_sub_number.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_sub_number.Enabled = true;
			cbo_sub_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_sub_number.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_sub_number.IntegralHeight = true;
			cbo_sub_number.Location = new System.Drawing.Point(376, 56);
			cbo_sub_number.Name = "cbo_sub_number";
			cbo_sub_number.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_sub_number.Size = new System.Drawing.Size(49, 21);
			cbo_sub_number.Sorted = false;
			cbo_sub_number.TabIndex = 193;
			cbo_sub_number.TabStop = true;
			cbo_sub_number.Visible = true;
			// 
			// btn_test_query
			// 
			btn_test_query.AllowDrop = true;
			btn_test_query.BackColor = System.Drawing.SystemColors.Control;
			btn_test_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_test_query.ForeColor = System.Drawing.SystemColors.ControlText;
			btn_test_query.Location = new System.Drawing.Point(24, 536);
			btn_test_query.Name = "btn_test_query";
			btn_test_query.RightToLeft = System.Windows.Forms.RightToLeft.No;
			btn_test_query.Size = new System.Drawing.Size(73, 25);
			btn_test_query.TabIndex = 187;
			btn_test_query.Text = "Test Query";
			btn_test_query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			btn_test_query.UseVisualStyleBackColor = false;
			btn_test_query.Visible = false;
			btn_test_query.Click += new System.EventHandler(btn_test_query_Click);
			// 
			// cbo_sort
			// 
			cbo_sort.AllowDrop = true;
			cbo_sort.BackColor = System.Drawing.SystemColors.Window;
			cbo_sort.CausesValidation = true;
			cbo_sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_sort.Enabled = true;
			cbo_sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_sort.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_sort.IntegralHeight = true;
			cbo_sort.Location = new System.Drawing.Point(472, 176);
			cbo_sort.Name = "cbo_sort";
			cbo_sort.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_sort.Size = new System.Drawing.Size(57, 21);
			cbo_sort.Sorted = false;
			cbo_sort.TabIndex = 185;
			cbo_sort.TabStop = true;
			cbo_sort.Visible = true;
			// 
			// chk_summary_level
			// 
			chk_summary_level.AllowDrop = true;
			chk_summary_level.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_summary_level.BackColor = System.Drawing.SystemColors.Control;
			chk_summary_level.CausesValidation = true;
			chk_summary_level.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_summary_level.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_summary_level.Enabled = true;
			chk_summary_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_summary_level.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_summary_level.Location = new System.Drawing.Point(472, 192);
			chk_summary_level.Name = "chk_summary_level";
			chk_summary_level.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_summary_level.Size = new System.Drawing.Size(113, 25);
			chk_summary_level.TabIndex = 184;
			chk_summary_level.TabStop = true;
			chk_summary_level.Text = "Summary Level?";
			chk_summary_level.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_summary_level.Visible = true;
			// 
			// txt_sub_group
			// 
			txt_sub_group.AcceptsReturn = true;
			txt_sub_group.AllowDrop = true;
			txt_sub_group.BackColor = System.Drawing.SystemColors.Window;
			txt_sub_group.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_sub_group.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_sub_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_sub_group.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_sub_group.Location = new System.Drawing.Point(80, 128);
			txt_sub_group.MaxLength = 0;
			txt_sub_group.Name = "txt_sub_group";
			txt_sub_group.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_sub_group.Size = new System.Drawing.Size(353, 19);
			txt_sub_group.TabIndex = 179;
			txt_sub_group.Visible = false;
			// 
			// cbo_selected_group
			// 
			cbo_selected_group.AllowDrop = true;
			cbo_selected_group.BackColor = System.Drawing.SystemColors.Window;
			cbo_selected_group.CausesValidation = true;
			cbo_selected_group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_selected_group.Enabled = true;
			cbo_selected_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_selected_group.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_selected_group.IntegralHeight = true;
			cbo_selected_group.Location = new System.Drawing.Point(80, 56);
			cbo_selected_group.Name = "cbo_selected_group";
			cbo_selected_group.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_selected_group.Size = new System.Drawing.Size(289, 21);
			cbo_selected_group.Sorted = false;
			cbo_selected_group.TabIndex = 178;
			cbo_selected_group.TabStop = true;
			cbo_selected_group.Visible = true;
			cbo_selected_group.SelectionChangeCommitted += new System.EventHandler(cbo_selected_group_SelectionChangeCommitted);
			// 
			// cbo_selected_sub_group
			// 
			cbo_selected_sub_group.AllowDrop = true;
			cbo_selected_sub_group.BackColor = System.Drawing.SystemColors.Window;
			cbo_selected_sub_group.CausesValidation = true;
			cbo_selected_sub_group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_selected_sub_group.Enabled = true;
			cbo_selected_sub_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_selected_sub_group.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_selected_sub_group.IntegralHeight = true;
			cbo_selected_sub_group.Location = new System.Drawing.Point(80, 104);
			cbo_selected_sub_group.Name = "cbo_selected_sub_group";
			cbo_selected_sub_group.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_selected_sub_group.Size = new System.Drawing.Size(289, 21);
			cbo_selected_sub_group.Sorted = false;
			cbo_selected_sub_group.TabIndex = 177;
			cbo_selected_sub_group.TabStop = true;
			cbo_selected_sub_group.Visible = true;
			cbo_selected_sub_group.SelectionChangeCommitted += new System.EventHandler(cbo_selected_sub_group_SelectionChangeCommitted);
			// 
			// txt_new_group
			// 
			txt_new_group.AcceptsReturn = true;
			txt_new_group.AllowDrop = true;
			txt_new_group.BackColor = System.Drawing.SystemColors.Window;
			txt_new_group.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_new_group.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_new_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_new_group.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_new_group.Location = new System.Drawing.Point(80, 80);
			txt_new_group.MaxLength = 0;
			txt_new_group.Name = "txt_new_group";
			txt_new_group.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_new_group.Size = new System.Drawing.Size(401, 19);
			txt_new_group.TabIndex = 176;
			txt_new_group.Visible = false;
			// 
			// frame_products
			// 
			frame_products.AllowDrop = true;
			frame_products.BackColor = System.Drawing.SystemColors.Control;
			frame_products.Controls.Add(chk_aero);
			frame_products.Controls.Add(chk_yacht);
			frame_products.Controls.Add(chk_comm);
			frame_products.Controls.Add(chk_helicopter);
			frame_products.Controls.Add(chk_business);
			frame_products.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_products.Enabled = true;
			frame_products.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_products.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_products.Location = new System.Drawing.Point(88, 480);
			frame_products.Name = "frame_products";
			frame_products.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_products.Size = new System.Drawing.Size(393, 49);
			frame_products.TabIndex = 171;
			frame_products.Text = "Product Codes";
			frame_products.Visible = true;
			// 
			// chk_aero
			// 
			chk_aero.AllowDrop = true;
			chk_aero.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_aero.BackColor = System.Drawing.SystemColors.Control;
			chk_aero.CausesValidation = true;
			chk_aero.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_aero.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_aero.Enabled = true;
			chk_aero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_aero.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_aero.Location = new System.Drawing.Point(312, 24);
			chk_aero.Name = "chk_aero";
			chk_aero.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_aero.Size = new System.Drawing.Size(73, 17);
			chk_aero.TabIndex = 180;
			chk_aero.TabStop = true;
			chk_aero.Text = "Aerodex";
			chk_aero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_aero.Visible = true;
			// 
			// chk_yacht
			// 
			chk_yacht.AllowDrop = true;
			chk_yacht.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_yacht.BackColor = System.Drawing.SystemColors.Control;
			chk_yacht.CausesValidation = true;
			chk_yacht.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_yacht.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_yacht.Enabled = true;
			chk_yacht.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_yacht.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_yacht.Location = new System.Drawing.Point(248, 24);
			chk_yacht.Name = "chk_yacht";
			chk_yacht.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_yacht.Size = new System.Drawing.Size(57, 17);
			chk_yacht.TabIndex = 175;
			chk_yacht.TabStop = true;
			chk_yacht.Text = "Yacht";
			chk_yacht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_yacht.Visible = true;
			// 
			// chk_comm
			// 
			chk_comm.AllowDrop = true;
			chk_comm.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_comm.BackColor = System.Drawing.SystemColors.Control;
			chk_comm.CausesValidation = true;
			chk_comm.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_comm.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_comm.Enabled = true;
			chk_comm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_comm.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_comm.Location = new System.Drawing.Point(168, 24);
			chk_comm.Name = "chk_comm";
			chk_comm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_comm.Size = new System.Drawing.Size(81, 17);
			chk_comm.TabIndex = 174;
			chk_comm.TabStop = true;
			chk_comm.Text = "Commercial";
			chk_comm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_comm.Visible = true;
			// 
			// chk_helicopter
			// 
			chk_helicopter.AllowDrop = true;
			chk_helicopter.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_helicopter.BackColor = System.Drawing.SystemColors.Control;
			chk_helicopter.CausesValidation = true;
			chk_helicopter.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_helicopter.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_helicopter.Enabled = true;
			chk_helicopter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_helicopter.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_helicopter.Location = new System.Drawing.Point(88, 24);
			chk_helicopter.Name = "chk_helicopter";
			chk_helicopter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_helicopter.Size = new System.Drawing.Size(73, 17);
			chk_helicopter.TabIndex = 173;
			chk_helicopter.TabStop = true;
			chk_helicopter.Text = "Helicopter";
			chk_helicopter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_helicopter.Visible = true;
			// 
			// chk_business
			// 
			chk_business.AllowDrop = true;
			chk_business.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_business.BackColor = System.Drawing.SystemColors.Control;
			chk_business.CausesValidation = true;
			chk_business.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_business.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_business.Enabled = true;
			chk_business.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_business.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_business.Location = new System.Drawing.Point(16, 24);
			chk_business.Name = "chk_business";
			chk_business.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_business.Size = new System.Drawing.Size(73, 17);
			chk_business.TabIndex = 172;
			chk_business.TabStop = true;
			chk_business.Text = "Business";
			chk_business.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_business.Visible = true;
			// 
			// cbo_field_type
			// 
			cbo_field_type.AllowDrop = true;
			cbo_field_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_field_type.CausesValidation = true;
			cbo_field_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_field_type.Enabled = true;
			cbo_field_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_field_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_field_type.IntegralHeight = true;
			cbo_field_type.Location = new System.Drawing.Point(200, 200);
			cbo_field_type.Name = "cbo_field_type";
			cbo_field_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_field_type.Size = new System.Drawing.Size(121, 21);
			cbo_field_type.Sorted = false;
			cbo_field_type.TabIndex = 170;
			cbo_field_type.TabStop = true;
			cbo_field_type.Visible = true;
			// 
			// btn_save
			// 
			btn_save.AllowDrop = true;
			btn_save.BackColor = System.Drawing.SystemColors.Control;
			btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_save.ForeColor = System.Drawing.SystemColors.ControlText;
			btn_save.Location = new System.Drawing.Point(498, 536);
			btn_save.Name = "btn_save";
			btn_save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			btn_save.Size = new System.Drawing.Size(81, 25);
			btn_save.TabIndex = 169;
			btn_save.Text = "Save";
			btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			btn_save.UseVisualStyleBackColor = false;
			btn_save.Click += new System.EventHandler(btn_save_Click);
			// 
			// txt_length
			// 
			txt_length.AcceptsReturn = true;
			txt_length.AllowDrop = true;
			txt_length.BackColor = System.Drawing.SystemColors.Window;
			txt_length.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_length.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_length.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_length.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_length.Location = new System.Drawing.Point(368, 200);
			txt_length.MaxLength = 0;
			txt_length.Name = "txt_length";
			txt_length.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_length.Size = new System.Drawing.Size(89, 19);
			txt_length.TabIndex = 166;
			// 
			// txt_field_name
			// 
			txt_field_name.AcceptsReturn = true;
			txt_field_name.AllowDrop = true;
			txt_field_name.BackColor = System.Drawing.SystemColors.Window;
			txt_field_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_field_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_field_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_field_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_field_name.Location = new System.Drawing.Point(8, 224);
			txt_field_name.MaxLength = 0;
			txt_field_name.Multiline = true;
			txt_field_name.Name = "txt_field_name";
			txt_field_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_field_name.Size = new System.Drawing.Size(561, 57);
			txt_field_name.TabIndex = 164;
			// 
			// txt_header_name
			// 
			txt_header_name.AcceptsReturn = true;
			txt_header_name.AllowDrop = true;
			txt_header_name.BackColor = System.Drawing.SystemColors.Window;
			txt_header_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_header_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_header_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_header_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_header_name.Location = new System.Drawing.Point(80, 152);
			txt_header_name.MaxLength = 0;
			txt_header_name.Name = "txt_header_name";
			txt_header_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_header_name.Size = new System.Drawing.Size(321, 19);
			txt_header_name.TabIndex = 159;
			// 
			// txt_display_name
			// 
			txt_display_name.AcceptsReturn = true;
			txt_display_name.AllowDrop = true;
			txt_display_name.BackColor = System.Drawing.SystemColors.Window;
			txt_display_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_display_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_display_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_display_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_display_name.Location = new System.Drawing.Point(80, 176);
			txt_display_name.MaxLength = 0;
			txt_display_name.Name = "txt_display_name";
			txt_display_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_display_name.Size = new System.Drawing.Size(321, 19);
			txt_display_name.TabIndex = 158;
			// 
			// lbl_client_field
			// 
			lbl_client_field.AllowDrop = true;
			lbl_client_field.BackColor = System.Drawing.SystemColors.Control;
			lbl_client_field.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_client_field.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_client_field.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_client_field.Location = new System.Drawing.Point(472, 16);
			lbl_client_field.MinimumSize = new System.Drawing.Size(49, 17);
			lbl_client_field.Name = "lbl_client_field";
			lbl_client_field.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_client_field.Size = new System.Drawing.Size(49, 17);
			lbl_client_field.TabIndex = 215;
			lbl_client_field.Text = "lbl_client_field";
			// 
			// Label49
			// 
			Label49.AllowDrop = true;
			Label49.BackColor = System.Drawing.Color.Transparent;
			Label49.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label49.ForeColor = System.Drawing.SystemColors.ControlText;
			Label49.Location = new System.Drawing.Point(8, 344);
			Label49.MinimumSize = new System.Drawing.Size(273, 25);
			Label49.Name = "Label49";
			Label49.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label49.Size = new System.Drawing.Size(273, 25);
			Label49.TabIndex = 213;
			Label49.Text = "Select Statement for List of Values:";
			// 
			// Label48
			// 
			Label48.AllowDrop = true;
			Label48.BackColor = System.Drawing.Color.Transparent;
			Label48.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label48.ForeColor = System.Drawing.SystemColors.ControlText;
			Label48.Location = new System.Drawing.Point(288, 384);
			Label48.MinimumSize = new System.Drawing.Size(97, 17);
			Label48.Name = "Label48";
			Label48.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label48.Size = new System.Drawing.Size(97, 17);
			Label48.TabIndex = 212;
			Label48.Text = "Help Topic:";
			// 
			// Label47
			// 
			Label47.AllowDrop = true;
			Label47.BackColor = System.Drawing.Color.Transparent;
			Label47.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label47.ForeColor = System.Drawing.SystemColors.ControlText;
			Label47.Location = new System.Drawing.Point(8, 408);
			Label47.MinimumSize = new System.Drawing.Size(273, 25);
			Label47.Name = "Label47";
			Label47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label47.Size = new System.Drawing.Size(273, 25);
			Label47.TabIndex = 209;
			Label47.Text = "Values (select list for customers, separated by commas):";
			// 
			// Label46
			// 
			Label46.AllowDrop = true;
			Label46.BackColor = System.Drawing.Color.Transparent;
			Label46.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label46.ForeColor = System.Drawing.SystemColors.ControlText;
			Label46.Location = new System.Drawing.Point(8, 288);
			Label46.MinimumSize = new System.Drawing.Size(289, 25);
			Label46.Name = "Label46";
			Label46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label46.Size = new System.Drawing.Size(289, 25);
			Label46.TabIndex = 207;
			Label46.Text = "Definition (for customer display):";
			// 
			// Label45
			// 
			Label45.AllowDrop = true;
			Label45.BackColor = System.Drawing.Color.Transparent;
			Label45.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label45.ForeColor = System.Drawing.SystemColors.ControlText;
			Label45.Location = new System.Drawing.Point(168, 200);
			Label45.MinimumSize = new System.Drawing.Size(33, 25);
			Label45.Name = "Label45";
			Label45.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label45.Size = new System.Drawing.Size(33, 25);
			Label45.TabIndex = 206;
			Label45.Text = "Type:";
			// 
			// lbl_tab
			// 
			lbl_tab.AllowDrop = true;
			lbl_tab.BackColor = System.Drawing.Color.Transparent;
			lbl_tab.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_tab.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_tab.Location = new System.Drawing.Point(8, 32);
			lbl_tab.MinimumSize = new System.Drawing.Size(113, 25);
			lbl_tab.Name = "lbl_tab";
			lbl_tab.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_tab.Size = new System.Drawing.Size(113, 25);
			lbl_tab.TabIndex = 201;
			lbl_tab.Text = "Export Tab:";
			// 
			// lbl_sort
			// 
			lbl_sort.AllowDrop = true;
			lbl_sort.BackColor = System.Drawing.SystemColors.Control;
			lbl_sort.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_sort.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_sort.Location = new System.Drawing.Point(416, 176);
			lbl_sort.MinimumSize = new System.Drawing.Size(65, 25);
			lbl_sort.Name = "lbl_sort";
			lbl_sort.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_sort.Size = new System.Drawing.Size(65, 25);
			lbl_sort.TabIndex = 186;
			lbl_sort.Text = "Field Order:";
			// 
			// lbl_updated
			// 
			lbl_updated.AllowDrop = true;
			lbl_updated.BackColor = System.Drawing.SystemColors.Control;
			lbl_updated.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_updated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_updated.ForeColor = System.Drawing.Color.Red;
			lbl_updated.Location = new System.Drawing.Point(328, 544);
			lbl_updated.MinimumSize = new System.Drawing.Size(169, 17);
			lbl_updated.Name = "lbl_updated";
			lbl_updated.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_updated.Size = new System.Drawing.Size(169, 17);
			lbl_updated.TabIndex = 183;
			lbl_updated.Text = "Your Details Have Been Updated";
			lbl_updated.Visible = false;
			// 
			// lbl_id
			// 
			lbl_id.AllowDrop = true;
			lbl_id.BackColor = System.Drawing.SystemColors.Control;
			lbl_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_id.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_id.Location = new System.Drawing.Point(8, 16);
			lbl_id.MinimumSize = new System.Drawing.Size(25, 17);
			lbl_id.Name = "lbl_id";
			lbl_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_id.Size = new System.Drawing.Size(25, 17);
			lbl_id.TabIndex = 182;
			lbl_id.Text = "ID: ";
			// 
			// lbl_cef_id
			// 
			lbl_cef_id.AllowDrop = true;
			lbl_cef_id.BackColor = System.Drawing.SystemColors.Control;
			lbl_cef_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_cef_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_cef_id.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_cef_id.Location = new System.Drawing.Point(80, 16);
			lbl_cef_id.MinimumSize = new System.Drawing.Size(33, 25);
			lbl_cef_id.Name = "lbl_cef_id";
			lbl_cef_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_cef_id.Size = new System.Drawing.Size(33, 25);
			lbl_cef_id.TabIndex = 181;
			lbl_cef_id.Text = "111";
			// 
			// lbl_length
			// 
			lbl_length.AllowDrop = true;
			lbl_length.BackColor = System.Drawing.SystemColors.Control;
			lbl_length.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_length.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_length.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_length.Location = new System.Drawing.Point(328, 200);
			lbl_length.MinimumSize = new System.Drawing.Size(41, 25);
			lbl_length.Name = "lbl_length";
			lbl_length.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_length.Size = new System.Drawing.Size(41, 25);
			lbl_length.TabIndex = 167;
			lbl_length.Text = "Length:";
			// 
			// lbl_field_mapping
			// 
			lbl_field_mapping.AllowDrop = true;
			lbl_field_mapping.BackColor = System.Drawing.SystemColors.Control;
			lbl_field_mapping.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_field_mapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_field_mapping.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_field_mapping.Location = new System.Drawing.Point(8, 200);
			lbl_field_mapping.MinimumSize = new System.Drawing.Size(81, 25);
			lbl_field_mapping.Name = "lbl_field_mapping";
			lbl_field_mapping.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_field_mapping.Size = new System.Drawing.Size(81, 25);
			lbl_field_mapping.TabIndex = 165;
			lbl_field_mapping.Text = "Evolution Field:";
			// 
			// lbl_display
			// 
			lbl_display.AllowDrop = true;
			lbl_display.BackColor = System.Drawing.SystemColors.Control;
			lbl_display.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_display.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_display.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_display.Location = new System.Drawing.Point(8, 176);
			lbl_display.MinimumSize = new System.Drawing.Size(73, 25);
			lbl_display.Name = "lbl_display";
			lbl_display.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_display.Size = new System.Drawing.Size(73, 25);
			lbl_display.TabIndex = 163;
			lbl_display.Text = "Display As:";
			// 
			// lbl_header
			// 
			lbl_header.AllowDrop = true;
			lbl_header.BackColor = System.Drawing.SystemColors.Control;
			lbl_header.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_header.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_header.Location = new System.Drawing.Point(8, 152);
			lbl_header.MinimumSize = new System.Drawing.Size(49, 25);
			lbl_header.Name = "lbl_header";
			lbl_header.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_header.Size = new System.Drawing.Size(49, 25);
			lbl_header.TabIndex = 162;
			lbl_header.Text = "Header:";
			// 
			// lbl_sup_gruop
			// 
			lbl_sup_gruop.AllowDrop = true;
			lbl_sup_gruop.BackColor = System.Drawing.SystemColors.Control;
			lbl_sup_gruop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_sup_gruop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_sup_gruop.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_sup_gruop.Location = new System.Drawing.Point(8, 104);
			lbl_sup_gruop.MinimumSize = new System.Drawing.Size(57, 25);
			lbl_sup_gruop.Name = "lbl_sup_gruop";
			lbl_sup_gruop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_sup_gruop.Size = new System.Drawing.Size(57, 25);
			lbl_sup_gruop.TabIndex = 161;
			lbl_sup_gruop.Text = "Block:";
			// 
			// lbl_group
			// 
			lbl_group.AllowDrop = true;
			lbl_group.BackColor = System.Drawing.Color.Transparent;
			lbl_group.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_group.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_group.Location = new System.Drawing.Point(8, 56);
			lbl_group.MinimumSize = new System.Drawing.Size(57, 25);
			lbl_group.Name = "lbl_group";
			lbl_group.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_group.Size = new System.Drawing.Size(57, 25);
			lbl_group.TabIndex = 160;
			lbl_group.Text = "Sub Tab:";
			// 
			// btn_new
			// 
			btn_new.AllowDrop = true;
			btn_new.BackColor = System.Drawing.SystemColors.Control;
			btn_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_new.ForeColor = System.Drawing.SystemColors.ControlText;
			btn_new.Location = new System.Drawing.Point(304, 460);
			btn_new.Name = "btn_new";
			btn_new.RightToLeft = System.Windows.Forms.RightToLeft.No;
			btn_new.Size = new System.Drawing.Size(65, 33);
			btn_new.TabIndex = 168;
			btn_new.Text = "New";
			btn_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			btn_new.UseVisualStyleBackColor = false;
			btn_new.Click += new System.EventHandler(btn_new_Click);
			// 
			// tabstrip_data
			// 
			tabstrip_data.Alignment = System.Windows.Forms.TabAlignment.Top;
			tabstrip_data.AllowDrop = true;
			tabstrip_data.Controls.Add(_tabstrip_data_TabPage0);
			tabstrip_data.Controls.Add(_tabstrip_data_TabPage1);
			tabstrip_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tabstrip_data.ItemSize = new System.Drawing.Size(179, 18);
			tabstrip_data.Location = new System.Drawing.Point(8, 44);
			tabstrip_data.Multiline = true;
			tabstrip_data.Name = "tabstrip_data";
			tabstrip_data.Size = new System.Drawing.Size(365, 405);
			tabstrip_data.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tabstrip_data.TabIndex = 188;
			// 
			// _tabstrip_data_TabPage0
			// 
			_tabstrip_data_TabPage0.Controls.Add(Label43);
			_tabstrip_data_TabPage0.Controls.Add(Label44);
			_tabstrip_data_TabPage0.Controls.Add(cbo_FieldGroups);
			_tabstrip_data_TabPage0.Controls.Add(list_CustomFields);
			_tabstrip_data_TabPage0.Controls.Add(cbo_area);
			_tabstrip_data_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tabstrip_data_TabPage0.Text = "Search";
			// 
			// Label43
			// 
			Label43.AllowDrop = true;
			Label43.BackColor = System.Drawing.SystemColors.Control;
			Label43.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label43.ForeColor = System.Drawing.SystemColors.ControlText;
			Label43.Location = new System.Drawing.Point(8, 4);
			Label43.MinimumSize = new System.Drawing.Size(73, 25);
			Label43.Name = "Label43";
			Label43.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label43.Size = new System.Drawing.Size(73, 25);
			Label43.TabIndex = 203;
			Label43.Text = "Export Tab:";
			// 
			// Label44
			// 
			Label44.AllowDrop = true;
			Label44.BackColor = System.Drawing.Color.Transparent;
			Label44.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label44.ForeColor = System.Drawing.SystemColors.ControlText;
			Label44.Location = new System.Drawing.Point(8, 28);
			Label44.MinimumSize = new System.Drawing.Size(97, 25);
			Label44.Name = "Label44";
			Label44.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label44.Size = new System.Drawing.Size(97, 25);
			Label44.TabIndex = 204;
			Label44.Text = "Sub Tab/Block:";
			// 
			// cbo_FieldGroups
			// 
			cbo_FieldGroups.AllowDrop = true;
			cbo_FieldGroups.BackColor = System.Drawing.SystemColors.Window;
			cbo_FieldGroups.CausesValidation = true;
			cbo_FieldGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_FieldGroups.Enabled = true;
			cbo_FieldGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_FieldGroups.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_FieldGroups.IntegralHeight = true;
			cbo_FieldGroups.Location = new System.Drawing.Point(88, 28);
			cbo_FieldGroups.Name = "cbo_FieldGroups";
			cbo_FieldGroups.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_FieldGroups.Size = new System.Drawing.Size(265, 21);
			cbo_FieldGroups.Sorted = false;
			cbo_FieldGroups.TabIndex = 189;
			cbo_FieldGroups.TabStop = true;
			cbo_FieldGroups.Text = "Combo1";
			cbo_FieldGroups.Visible = true;
			cbo_FieldGroups.SelectionChangeCommitted += new System.EventHandler(cbo_FieldGroups_SelectionChangeCommitted);
			// 
			// list_CustomFields
			// 
			list_CustomFields.AllowDrop = true;
			list_CustomFields.BackColor = System.Drawing.SystemColors.Window;
			list_CustomFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			list_CustomFields.CausesValidation = true;
			list_CustomFields.Enabled = true;
			list_CustomFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			list_CustomFields.ForeColor = System.Drawing.SystemColors.WindowText;
			list_CustomFields.IntegralHeight = true;
			list_CustomFields.Location = new System.Drawing.Point(8, 52);
			list_CustomFields.MultiColumn = false;
			list_CustomFields.Name = "list_CustomFields";
			list_CustomFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			list_CustomFields.Size = new System.Drawing.Size(345, 306);
			list_CustomFields.Sorted = false;
			list_CustomFields.TabIndex = 190;
			list_CustomFields.TabStop = true;
			list_CustomFields.Visible = true;
			list_CustomFields.SelectedIndexChanged += new System.EventHandler(list_CustomFields_SelectedIndexChanged);
			// 
			// cbo_area
			// 
			cbo_area.AllowDrop = true;
			cbo_area.BackColor = System.Drawing.SystemColors.Window;
			cbo_area.CausesValidation = true;
			cbo_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_area.Enabled = true;
			cbo_area.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_area.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_area.IntegralHeight = true;
			cbo_area.Location = new System.Drawing.Point(88, 4);
			cbo_area.Name = "cbo_area";
			cbo_area.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_area.Size = new System.Drawing.Size(169, 21);
			cbo_area.Sorted = false;
			cbo_area.TabIndex = 202;
			cbo_area.TabStop = true;
			cbo_area.Visible = true;
			cbo_area.SelectionChangeCommitted += new System.EventHandler(cbo_area_SelectionChangeCommitted);
			// 
			// _tabstrip_data_TabPage1
			// 
			_tabstrip_data_TabPage1.Controls.Add(grid_details);
			_tabstrip_data_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tabstrip_data_TabPage1.Text = "Listing";
			// 
			// grid_details
			// 
			grid_details.AllowDrop = true;
			grid_details.AllowUserToAddRows = false;
			grid_details.AllowUserToDeleteRows = false;
			grid_details.AllowUserToResizeColumns = false;
			grid_details.AllowUserToResizeRows = false;
			grid_details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grid_details.ColumnsCount = 2;
			grid_details.FixedColumns = 0;
			grid_details.FixedRows = 1;
			grid_details.Location = new System.Drawing.Point(8, 12);
			grid_details.Name = "grid_details";
			grid_details.ReadOnly = true;
			grid_details.RowsCount = 2;
			grid_details.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grid_details.ShowCellToolTips = false;
			grid_details.Size = new System.Drawing.Size(345, 369);
			grid_details.StandardTab = true;
			grid_details.TabIndex = 191;
			// 
			// btn_send
			// 
			btn_send.AllowDrop = true;
			btn_send.BackColor = System.Drawing.SystemColors.Control;
			btn_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_send.ForeColor = System.Drawing.SystemColors.ControlText;
			btn_send.Location = new System.Drawing.Point(16, 460);
			btn_send.Name = "btn_send";
			btn_send.RightToLeft = System.Windows.Forms.RightToLeft.No;
			btn_send.Size = new System.Drawing.Size(233, 33);
			btn_send.TabIndex = 192;
			btn_send.Text = "Send Changes To Evolution";
			btn_send.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			btn_send.UseVisualStyleBackColor = false;
			btn_send.Click += new System.EventHandler(btn_send_Click);
			// 
			// cmd_refresh
			// 
			cmd_refresh.AllowDrop = true;
			cmd_refresh.BackColor = System.Drawing.SystemColors.Control;
			cmd_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_refresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_refresh.Location = new System.Drawing.Point(16, 12);
			cmd_refresh.Name = "cmd_refresh";
			cmd_refresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_refresh.Size = new System.Drawing.Size(65, 25);
			cmd_refresh.TabIndex = 197;
			cmd_refresh.Text = "Refresh";
			cmd_refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_refresh.UseVisualStyleBackColor = false;
			cmd_refresh.Click += new System.EventHandler(cmd_refresh_Click);
			// 
			// cmd_sort_up
			// 
			cmd_sort_up.AllowDrop = true;
			cmd_sort_up.BackColor = System.Drawing.SystemColors.Control;
			cmd_sort_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_sort_up.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_sort_up.Location = new System.Drawing.Point(376, 196);
			cmd_sort_up.Name = "cmd_sort_up";
			cmd_sort_up.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_sort_up.Size = new System.Drawing.Size(17, 25);
			cmd_sort_up.TabIndex = 198;
			cmd_sort_up.Text = "^";
			cmd_sort_up.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_sort_up.UseVisualStyleBackColor = false;
			cmd_sort_up.Click += new System.EventHandler(cmd_sort_up_Click);
			// 
			// cmd_sort_down
			// 
			cmd_sort_down.AllowDrop = true;
			cmd_sort_down.BackColor = System.Drawing.SystemColors.Control;
			cmd_sort_down.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_sort_down.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_sort_down.Location = new System.Drawing.Point(376, 260);
			cmd_sort_down.Name = "cmd_sort_down";
			cmd_sort_down.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_sort_down.Size = new System.Drawing.Size(17, 25);
			cmd_sort_down.TabIndex = 199;
			cmd_sort_down.Text = "v";
			cmd_sort_down.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_sort_down.UseVisualStyleBackColor = false;
			cmd_sort_down.Click += new System.EventHandler(cmd_sort_down_Click);
			// 
			// _tab_Lookup_TabPage9
			// 
			_tab_Lookup_TabPage9.Controls.Add(_pnl_avionics_1);
			_tab_Lookup_TabPage9.Controls.Add(_pnl_avionics_0);
			_tab_Lookup_TabPage9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage9.Text = "Avionics";
			// 
			// _pnl_avionics_1
			// 
			_pnl_avionics_1.AllowDrop = true;
			_pnl_avionics_1.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			_pnl_avionics_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_pnl_avionics_1.Controls.Add(_cmd_av_button_5);
			_pnl_avionics_1.Controls.Add(_txt_avionics_2);
			_pnl_avionics_1.Controls.Add(_cmd_av_button_4);
			_pnl_avionics_1.Controls.Add(_lst_av_names_2);
			_pnl_avionics_1.Controls.Add(_lst_av_names_1);
			_pnl_avionics_1.Controls.Add(_txt_avionics_0);
			_pnl_avionics_1.Controls.Add(pnl_yes_no);
			_pnl_avionics_1.Controls.Add(_cmd_av_button_0);
			_pnl_avionics_1.Controls.Add(_lbl_avionics_7);
			_pnl_avionics_1.Controls.Add(_lbl_avionics_3);
			_pnl_avionics_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pnl_avionics_1.Location = new System.Drawing.Point(426, 16);
			_pnl_avionics_1.Name = "_pnl_avionics_1";
			_pnl_avionics_1.Size = new System.Drawing.Size(517, 559);
			_pnl_avionics_1.TabIndex = 229;
			// 
			// _cmd_av_button_5
			// 
			_cmd_av_button_5.AllowDrop = true;
			_cmd_av_button_5.BackColor = System.Drawing.SystemColors.Control;
			_cmd_av_button_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_av_button_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_av_button_5.Location = new System.Drawing.Point(112, 496);
			_cmd_av_button_5.Name = "_cmd_av_button_5";
			_cmd_av_button_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_av_button_5.Size = new System.Drawing.Size(61, 29);
			_cmd_av_button_5.TabIndex = 260;
			_cmd_av_button_5.Text = "FIX AL";
			_cmd_av_button_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_av_button_5.UseVisualStyleBackColor = false;
			_cmd_av_button_5.Visible = false;
			_cmd_av_button_5.Click += new System.EventHandler(cmd_av_button_Click);
			// 
			// _txt_avionics_2
			// 
			_txt_avionics_2.AcceptsReturn = true;
			_txt_avionics_2.AllowDrop = true;
			_txt_avionics_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_avionics_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_avionics_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_avionics_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_avionics_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_avionics_2.Location = new System.Drawing.Point(8, 528);
			_txt_avionics_2.MaxLength = 0;
			_txt_avionics_2.Name = "_txt_avionics_2";
			_txt_avionics_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_avionics_2.Size = new System.Drawing.Size(165, 21);
			_txt_avionics_2.TabIndex = 259;
			_txt_avionics_2.Visible = false;
			_txt_avionics_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_avionics_KeyDown);
			// 
			// _cmd_av_button_4
			// 
			_cmd_av_button_4.AllowDrop = true;
			_cmd_av_button_4.BackColor = System.Drawing.SystemColors.Control;
			_cmd_av_button_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_av_button_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_av_button_4.Location = new System.Drawing.Point(8, 496);
			_cmd_av_button_4.Name = "_cmd_av_button_4";
			_cmd_av_button_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_av_button_4.Size = new System.Drawing.Size(93, 29);
			_cmd_av_button_4.TabIndex = 258;
			_cmd_av_button_4.Text = "Phrase Change";
			_cmd_av_button_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_av_button_4.UseVisualStyleBackColor = false;
			_cmd_av_button_4.Visible = false;
			_cmd_av_button_4.Click += new System.EventHandler(cmd_av_button_Click);
			// 
			// _lst_av_names_2
			// 
			_lst_av_names_2.AllowDrop = true;
			_lst_av_names_2.BackColor = System.Drawing.SystemColors.Window;
			_lst_av_names_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_lst_av_names_2.CausesValidation = true;
			_lst_av_names_2.Enabled = true;
			_lst_av_names_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lst_av_names_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_lst_av_names_2.IntegralHeight = true;
			_lst_av_names_2.Location = new System.Drawing.Point(6, 326);
			_lst_av_names_2.MultiColumn = false;
			_lst_av_names_2.Name = "_lst_av_names_2";
			_lst_av_names_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lst_av_names_2.Size = new System.Drawing.Size(353, 137);
			_lst_av_names_2.Sorted = false;
			_lst_av_names_2.TabIndex = 249;
			_lst_av_names_2.TabStop = true;
			_lst_av_names_2.Visible = true;
			_lst_av_names_2.SelectedIndexChanged += new System.EventHandler(lst_av_names_SelectedIndexChanged);
			// 
			// _lst_av_names_1
			// 
			_lst_av_names_1.AllowDrop = true;
			_lst_av_names_1.BackColor = System.Drawing.SystemColors.Window;
			_lst_av_names_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_lst_av_names_1.CausesValidation = true;
			_lst_av_names_1.Enabled = true;
			_lst_av_names_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lst_av_names_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_lst_av_names_1.IntegralHeight = true;
			_lst_av_names_1.Location = new System.Drawing.Point(4, 26);
			_lst_av_names_1.MultiColumn = false;
			_lst_av_names_1.Name = "_lst_av_names_1";
			_lst_av_names_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lst_av_names_1.Size = new System.Drawing.Size(383, 241);
			_lst_av_names_1.Sorted = false;
			_lst_av_names_1.TabIndex = 244;
			_lst_av_names_1.TabStop = true;
			_lst_av_names_1.Visible = true;
			_lst_av_names_1.SelectedIndexChanged += new System.EventHandler(lst_av_names_SelectedIndexChanged);
			// 
			// _txt_avionics_0
			// 
			_txt_avionics_0.AcceptsReturn = true;
			_txt_avionics_0.AllowDrop = true;
			_txt_avionics_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_avionics_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_avionics_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_avionics_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_avionics_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_avionics_0.Location = new System.Drawing.Point(104, 276);
			_txt_avionics_0.MaxLength = 0;
			_txt_avionics_0.Name = "_txt_avionics_0";
			_txt_avionics_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_avionics_0.Size = new System.Drawing.Size(405, 25);
			_txt_avionics_0.TabIndex = 243;
			_txt_avionics_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_avionics_KeyDown);
			// 
			// pnl_yes_no
			// 
			pnl_yes_no.AllowDrop = true;
			pnl_yes_no.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			pnl_yes_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_yes_no.Controls.Add(_cmd_av_button_2);
			pnl_yes_no.Controls.Add(_cmd_av_button_1);
			pnl_yes_no.Controls.Add(_lbl_avionics_8);
			pnl_yes_no.Controls.Add(_lbl_avionics_5);
			pnl_yes_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_yes_no.Location = new System.Drawing.Point(180, 464);
			pnl_yes_no.Name = "pnl_yes_no";
			pnl_yes_no.Size = new System.Drawing.Size(331, 91);
			pnl_yes_no.TabIndex = 238;
			pnl_yes_no.Visible = false;
			// 
			// _cmd_av_button_2
			// 
			_cmd_av_button_2.AllowDrop = true;
			_cmd_av_button_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_av_button_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_av_button_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_av_button_2.Location = new System.Drawing.Point(262, 64);
			_cmd_av_button_2.Name = "_cmd_av_button_2";
			_cmd_av_button_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_av_button_2.Size = new System.Drawing.Size(55, 21);
			_cmd_av_button_2.TabIndex = 240;
			_cmd_av_button_2.Text = "No";
			_cmd_av_button_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_av_button_2.UseVisualStyleBackColor = false;
			_cmd_av_button_2.Click += new System.EventHandler(cmd_av_button_Click);
			// 
			// _cmd_av_button_1
			// 
			_cmd_av_button_1.AllowDrop = true;
			_cmd_av_button_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_av_button_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_av_button_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_av_button_1.Location = new System.Drawing.Point(186, 64);
			_cmd_av_button_1.Name = "_cmd_av_button_1";
			_cmd_av_button_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_av_button_1.Size = new System.Drawing.Size(55, 21);
			_cmd_av_button_1.TabIndex = 239;
			_cmd_av_button_1.Text = "Yes";
			_cmd_av_button_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_av_button_1.UseVisualStyleBackColor = false;
			_cmd_av_button_1.Click += new System.EventHandler(cmd_av_button_Click);
			// 
			// _lbl_avionics_8
			// 
			_lbl_avionics_8.AllowDrop = true;
			_lbl_avionics_8.BackColor = System.Drawing.SystemColors.Control;
			_lbl_avionics_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_avionics_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_avionics_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_avionics_8.Location = new System.Drawing.Point(8, 4);
			_lbl_avionics_8.MinimumSize = new System.Drawing.Size(313, 29);
			_lbl_avionics_8.Name = "_lbl_avionics_8";
			_lbl_avionics_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_avionics_8.Size = new System.Drawing.Size(313, 29);
			_lbl_avionics_8.TabIndex = 261;
			_lbl_avionics_8.Text = "....";
			_lbl_avionics_8.Visible = false;
			// 
			// _lbl_avionics_5
			// 
			_lbl_avionics_5.AllowDrop = true;
			_lbl_avionics_5.BackColor = System.Drawing.SystemColors.Control;
			_lbl_avionics_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_avionics_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_avionics_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_avionics_5.Location = new System.Drawing.Point(8, 34);
			_lbl_avionics_5.MinimumSize = new System.Drawing.Size(313, 27);
			_lbl_avionics_5.Name = "_lbl_avionics_5";
			_lbl_avionics_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_avionics_5.Size = new System.Drawing.Size(313, 27);
			_lbl_avionics_5.TabIndex = 241;
			_lbl_avionics_5.Text = "Are You Sure?";
			// 
			// _cmd_av_button_0
			// 
			_cmd_av_button_0.AllowDrop = true;
			_cmd_av_button_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_av_button_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_av_button_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_av_button_0.Location = new System.Drawing.Point(8, 276);
			_cmd_av_button_0.Name = "_cmd_av_button_0";
			_cmd_av_button_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_av_button_0.Size = new System.Drawing.Size(93, 29);
			_cmd_av_button_0.TabIndex = 236;
			_cmd_av_button_0.Text = "Update To-->>";
			_cmd_av_button_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_av_button_0.UseVisualStyleBackColor = false;
			_cmd_av_button_0.Click += new System.EventHandler(cmd_av_button_Click);
			// 
			// _lbl_avionics_7
			// 
			_lbl_avionics_7.AllowDrop = true;
			_lbl_avionics_7.BackColor = System.Drawing.SystemColors.Control;
			_lbl_avionics_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_avionics_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_avionics_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_avionics_7.Location = new System.Drawing.Point(6, 266);
			_lbl_avionics_7.MinimumSize = new System.Drawing.Size(381, 17);
			_lbl_avionics_7.Name = "_lbl_avionics_7";
			_lbl_avionics_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_avionics_7.Size = new System.Drawing.Size(381, 17);
			_lbl_avionics_7.TabIndex = 250;
			_lbl_avionics_7.Text = "-----------------";
			_lbl_avionics_7.Visible = false;
			// 
			// _lbl_avionics_3
			// 
			_lbl_avionics_3.AllowDrop = true;
			_lbl_avionics_3.BackColor = System.Drawing.SystemColors.Control;
			_lbl_avionics_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_avionics_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_avionics_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_avionics_3.Location = new System.Drawing.Point(6, 4);
			_lbl_avionics_3.MinimumSize = new System.Drawing.Size(385, 23);
			_lbl_avionics_3.Name = "_lbl_avionics_3";
			_lbl_avionics_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_avionics_3.Size = new System.Drawing.Size(385, 23);
			_lbl_avionics_3.TabIndex = 237;
			_lbl_avionics_3.Text = "-----------------";
			// 
			// _pnl_avionics_0
			// 
			_pnl_avionics_0.AllowDrop = true;
			_pnl_avionics_0.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			_pnl_avionics_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_pnl_avionics_0.Controls.Add(_cmd_av_button_3);
			_pnl_avionics_0.Controls.Add(_txt_avionics_1);
			_pnl_avionics_0.Controls.Add(_lst_av_names_0);
			_pnl_avionics_0.Controls.Add(_cbo_avionics_2);
			_pnl_avionics_0.Controls.Add(_cbo_avionics_1);
			_pnl_avionics_0.Controls.Add(_cbo_avionics_0);
			_pnl_avionics_0.Controls.Add(_lbl_avionics_6);
			_pnl_avionics_0.Controls.Add(_lbl_avionics_4);
			_pnl_avionics_0.Controls.Add(_lbl_avionics_2);
			_pnl_avionics_0.Controls.Add(_lbl_avionics_1);
			_pnl_avionics_0.Controls.Add(_lbl_avionics_0);
			_pnl_avionics_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pnl_avionics_0.Location = new System.Drawing.Point(8, 20);
			_pnl_avionics_0.Name = "_pnl_avionics_0";
			_pnl_avionics_0.Size = new System.Drawing.Size(399, 557);
			_pnl_avionics_0.TabIndex = 228;
			// 
			// _cmd_av_button_3
			// 
			_cmd_av_button_3.AllowDrop = true;
			_cmd_av_button_3.BackColor = System.Drawing.SystemColors.Control;
			_cmd_av_button_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_av_button_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_av_button_3.Location = new System.Drawing.Point(296, 102);
			_cmd_av_button_3.Name = "_cmd_av_button_3";
			_cmd_av_button_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_av_button_3.Size = new System.Drawing.Size(93, 29);
			_cmd_av_button_3.TabIndex = 247;
			_cmd_av_button_3.Text = "Search";
			_cmd_av_button_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_av_button_3.UseVisualStyleBackColor = false;
			_cmd_av_button_3.Click += new System.EventHandler(cmd_av_button_Click);
			// 
			// _txt_avionics_1
			// 
			_txt_avionics_1.AcceptsReturn = true;
			_txt_avionics_1.AllowDrop = true;
			_txt_avionics_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_avionics_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_avionics_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_avionics_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_avionics_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_avionics_1.Location = new System.Drawing.Point(80, 108);
			_txt_avionics_1.MaxLength = 0;
			_txt_avionics_1.Name = "_txt_avionics_1";
			_txt_avionics_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_avionics_1.Size = new System.Drawing.Size(165, 21);
			_txt_avionics_1.TabIndex = 246;
			_txt_avionics_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_avionics_KeyDown);
			// 
			// _lst_av_names_0
			// 
			_lst_av_names_0.AllowDrop = true;
			_lst_av_names_0.BackColor = System.Drawing.SystemColors.Window;
			_lst_av_names_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_lst_av_names_0.CausesValidation = true;
			_lst_av_names_0.Enabled = true;
			_lst_av_names_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lst_av_names_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_lst_av_names_0.IntegralHeight = true;
			_lst_av_names_0.Location = new System.Drawing.Point(4, 138);
			_lst_av_names_0.MultiColumn = false;
			_lst_av_names_0.Name = "_lst_av_names_0";
			_lst_av_names_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lst_av_names_0.Size = new System.Drawing.Size(383, 397);
			_lst_av_names_0.Sorted = false;
			_lst_av_names_0.TabIndex = 242;
			_lst_av_names_0.TabStop = true;
			_lst_av_names_0.Visible = true;
			_lst_av_names_0.SelectedIndexChanged += new System.EventHandler(lst_av_names_SelectedIndexChanged);
			// 
			// _cbo_avionics_2
			// 
			_cbo_avionics_2.AllowDrop = true;
			_cbo_avionics_2.BackColor = System.Drawing.SystemColors.Window;
			_cbo_avionics_2.CausesValidation = true;
			_cbo_avionics_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_avionics_2.Enabled = true;
			_cbo_avionics_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_avionics_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_avionics_2.IntegralHeight = true;
			_cbo_avionics_2.Location = new System.Drawing.Point(80, 75);
			_cbo_avionics_2.Name = "_cbo_avionics_2";
			_cbo_avionics_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_avionics_2.Size = new System.Drawing.Size(165, 21);
			_cbo_avionics_2.Sorted = false;
			_cbo_avionics_2.TabIndex = 235;
			_cbo_avionics_2.TabStop = true;
			_cbo_avionics_2.Visible = true;
			_cbo_avionics_2.SelectionChangeCommitted += new System.EventHandler(cbo_avionics_SelectionChangeCommitted);
			// 
			// _cbo_avionics_1
			// 
			_cbo_avionics_1.AllowDrop = true;
			_cbo_avionics_1.BackColor = System.Drawing.SystemColors.Window;
			_cbo_avionics_1.CausesValidation = true;
			_cbo_avionics_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_avionics_1.Enabled = true;
			_cbo_avionics_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_avionics_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_avionics_1.IntegralHeight = true;
			_cbo_avionics_1.Location = new System.Drawing.Point(80, 41);
			_cbo_avionics_1.Name = "_cbo_avionics_1";
			_cbo_avionics_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_avionics_1.Size = new System.Drawing.Size(165, 21);
			_cbo_avionics_1.Sorted = false;
			_cbo_avionics_1.TabIndex = 234;
			_cbo_avionics_1.TabStop = true;
			_cbo_avionics_1.Visible = true;
			_cbo_avionics_1.SelectionChangeCommitted += new System.EventHandler(cbo_avionics_SelectionChangeCommitted);
			// 
			// _cbo_avionics_0
			// 
			_cbo_avionics_0.AllowDrop = true;
			_cbo_avionics_0.BackColor = System.Drawing.SystemColors.Window;
			_cbo_avionics_0.CausesValidation = true;
			_cbo_avionics_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_avionics_0.Enabled = true;
			_cbo_avionics_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_avionics_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_avionics_0.IntegralHeight = true;
			_cbo_avionics_0.Location = new System.Drawing.Point(80, 8);
			_cbo_avionics_0.Name = "_cbo_avionics_0";
			_cbo_avionics_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_avionics_0.Size = new System.Drawing.Size(165, 21);
			_cbo_avionics_0.Sorted = false;
			_cbo_avionics_0.TabIndex = 230;
			_cbo_avionics_0.TabStop = true;
			_cbo_avionics_0.Visible = true;
			_cbo_avionics_0.SelectionChangeCommitted += new System.EventHandler(cbo_avionics_SelectionChangeCommitted);
			// 
			// _lbl_avionics_6
			// 
			_lbl_avionics_6.AllowDrop = true;
			_lbl_avionics_6.BackColor = System.Drawing.SystemColors.Control;
			_lbl_avionics_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_avionics_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_avionics_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_avionics_6.Location = new System.Drawing.Point(4, 536);
			_lbl_avionics_6.MinimumSize = new System.Drawing.Size(379, 15);
			_lbl_avionics_6.Name = "_lbl_avionics_6";
			_lbl_avionics_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_avionics_6.Size = new System.Drawing.Size(379, 15);
			_lbl_avionics_6.TabIndex = 248;
			_lbl_avionics_6.Text = "Records Found";
			// 
			// _lbl_avionics_4
			// 
			_lbl_avionics_4.AllowDrop = true;
			_lbl_avionics_4.BackColor = System.Drawing.SystemColors.Control;
			_lbl_avionics_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_avionics_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_avionics_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_avionics_4.Location = new System.Drawing.Point(12, 110);
			_lbl_avionics_4.MinimumSize = new System.Drawing.Size(69, 15);
			_lbl_avionics_4.Name = "_lbl_avionics_4";
			_lbl_avionics_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_avionics_4.Size = new System.Drawing.Size(69, 15);
			_lbl_avionics_4.TabIndex = 245;
			_lbl_avionics_4.Text = "Search Text:";
			// 
			// _lbl_avionics_2
			// 
			_lbl_avionics_2.AllowDrop = true;
			_lbl_avionics_2.BackColor = System.Drawing.SystemColors.Control;
			_lbl_avionics_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_avionics_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_avionics_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_avionics_2.Location = new System.Drawing.Point(12, 75);
			_lbl_avionics_2.MinimumSize = new System.Drawing.Size(51, 15);
			_lbl_avionics_2.Name = "_lbl_avionics_2";
			_lbl_avionics_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_avionics_2.Size = new System.Drawing.Size(51, 15);
			_lbl_avionics_2.TabIndex = 233;
			_lbl_avionics_2.Text = "Avionics:";
			// 
			// _lbl_avionics_1
			// 
			_lbl_avionics_1.AllowDrop = true;
			_lbl_avionics_1.BackColor = System.Drawing.SystemColors.Control;
			_lbl_avionics_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_avionics_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_avionics_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_avionics_1.Location = new System.Drawing.Point(12, 41);
			_lbl_avionics_1.MinimumSize = new System.Drawing.Size(51, 15);
			_lbl_avionics_1.Name = "_lbl_avionics_1";
			_lbl_avionics_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_avionics_1.Size = new System.Drawing.Size(51, 15);
			_lbl_avionics_1.TabIndex = 232;
			_lbl_avionics_1.Text = "Model:";
			// 
			// _lbl_avionics_0
			// 
			_lbl_avionics_0.AllowDrop = true;
			_lbl_avionics_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_avionics_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_avionics_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_avionics_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_avionics_0.Location = new System.Drawing.Point(12, 6);
			_lbl_avionics_0.MinimumSize = new System.Drawing.Size(51, 15);
			_lbl_avionics_0.Name = "_lbl_avionics_0";
			_lbl_avionics_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_avionics_0.Size = new System.Drawing.Size(51, 15);
			_lbl_avionics_0.TabIndex = 231;
			_lbl_avionics_0.Text = "Make:";
			// 
			// _tab_Lookup_TabPage10
			// 
			_tab_Lookup_TabPage10.Controls.Add(_cmd_apu_3);
			_tab_Lookup_TabPage10.Controls.Add(_cmd_apu_2);
			_tab_Lookup_TabPage10.Controls.Add(_lst_apu_0);
			_tab_Lookup_TabPage10.Controls.Add(_txt_search_apu_1);
			_tab_Lookup_TabPage10.Controls.Add(_cmd_apu_1);
			_tab_Lookup_TabPage10.Controls.Add(_cmd_apu_0);
			_tab_Lookup_TabPage10.Controls.Add(_txt_search_apu_0);
			_tab_Lookup_TabPage10.Controls.Add(_lbl_apu_2);
			_tab_Lookup_TabPage10.Controls.Add(_lbl_apu_1);
			_tab_Lookup_TabPage10.Controls.Add(_lbl_apu_0);
			_tab_Lookup_TabPage10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage10.Text = "APU ";
			// 
			// _cmd_apu_3
			// 
			_cmd_apu_3.AllowDrop = true;
			_cmd_apu_3.BackColor = System.Drawing.SystemColors.Control;
			_cmd_apu_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_apu_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_apu_3.Location = new System.Drawing.Point(520, 196);
			_cmd_apu_3.Name = "_cmd_apu_3";
			_cmd_apu_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_apu_3.Size = new System.Drawing.Size(49, 25);
			_cmd_apu_3.TabIndex = 270;
			_cmd_apu_3.Text = "No";
			_cmd_apu_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_apu_3.UseVisualStyleBackColor = false;
			_cmd_apu_3.Visible = false;
			_cmd_apu_3.Click += new System.EventHandler(cmd_apu_Click);
			// 
			// _cmd_apu_2
			// 
			_cmd_apu_2.AllowDrop = true;
			_cmd_apu_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_apu_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_apu_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_apu_2.Location = new System.Drawing.Point(448, 196);
			_cmd_apu_2.Name = "_cmd_apu_2";
			_cmd_apu_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_apu_2.Size = new System.Drawing.Size(49, 25);
			_cmd_apu_2.TabIndex = 269;
			_cmd_apu_2.Text = "Yes";
			_cmd_apu_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_apu_2.UseVisualStyleBackColor = false;
			_cmd_apu_2.Visible = false;
			_cmd_apu_2.Click += new System.EventHandler(cmd_apu_Click);
			// 
			// _lst_apu_0
			// 
			_lst_apu_0.AllowDrop = true;
			_lst_apu_0.BackColor = System.Drawing.SystemColors.Window;
			_lst_apu_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_lst_apu_0.CausesValidation = true;
			_lst_apu_0.Enabled = true;
			_lst_apu_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lst_apu_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_lst_apu_0.IntegralHeight = true;
			_lst_apu_0.Location = new System.Drawing.Point(32, 44);
			_lst_apu_0.MultiColumn = false;
			_lst_apu_0.Name = "_lst_apu_0";
			_lst_apu_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lst_apu_0.Size = new System.Drawing.Size(265, 358);
			_lst_apu_0.Sorted = false;
			_lst_apu_0.TabIndex = 266;
			_lst_apu_0.TabStop = true;
			_lst_apu_0.Visible = true;
			_lst_apu_0.SelectedIndexChanged += new System.EventHandler(lst_apu_SelectedIndexChanged);
			// 
			// _txt_search_apu_1
			// 
			_txt_search_apu_1.AcceptsReturn = true;
			_txt_search_apu_1.AllowDrop = true;
			_txt_search_apu_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_search_apu_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_search_apu_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_search_apu_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_search_apu_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_search_apu_1.Location = new System.Drawing.Point(456, 116);
			_txt_search_apu_1.MaxLength = 0;
			_txt_search_apu_1.Name = "_txt_search_apu_1";
			_txt_search_apu_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_search_apu_1.Size = new System.Drawing.Size(265, 21);
			_txt_search_apu_1.TabIndex = 265;
			// 
			// _cmd_apu_1
			// 
			_cmd_apu_1.AllowDrop = true;
			_cmd_apu_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_apu_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_apu_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_apu_1.Location = new System.Drawing.Point(752, 116);
			_cmd_apu_1.Name = "_cmd_apu_1";
			_cmd_apu_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_apu_1.Size = new System.Drawing.Size(49, 25);
			_cmd_apu_1.TabIndex = 264;
			_cmd_apu_1.Text = "Update";
			_cmd_apu_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_apu_1.UseVisualStyleBackColor = false;
			_cmd_apu_1.Visible = false;
			_cmd_apu_1.Click += new System.EventHandler(cmd_apu_Click);
			// 
			// _cmd_apu_0
			// 
			_cmd_apu_0.AllowDrop = true;
			_cmd_apu_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_apu_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_apu_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_apu_0.Location = new System.Drawing.Point(328, 20);
			_cmd_apu_0.Name = "_cmd_apu_0";
			_cmd_apu_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_apu_0.Size = new System.Drawing.Size(49, 25);
			_cmd_apu_0.TabIndex = 263;
			_cmd_apu_0.Text = "Search";
			_cmd_apu_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_apu_0.UseVisualStyleBackColor = false;
			_cmd_apu_0.Click += new System.EventHandler(cmd_apu_Click);
			// 
			// _txt_search_apu_0
			// 
			_txt_search_apu_0.AcceptsReturn = true;
			_txt_search_apu_0.AllowDrop = true;
			_txt_search_apu_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_search_apu_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_search_apu_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_search_apu_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_search_apu_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_search_apu_0.Location = new System.Drawing.Point(32, 20);
			_txt_search_apu_0.MaxLength = 0;
			_txt_search_apu_0.Name = "_txt_search_apu_0";
			_txt_search_apu_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_search_apu_0.Size = new System.Drawing.Size(265, 21);
			_txt_search_apu_0.TabIndex = 262;
			// 
			// _lbl_apu_2
			// 
			_lbl_apu_2.AllowDrop = true;
			_lbl_apu_2.BackColor = System.Drawing.SystemColors.Control;
			_lbl_apu_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_apu_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_apu_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_apu_2.Location = new System.Drawing.Point(32, 412);
			_lbl_apu_2.MinimumSize = new System.Drawing.Size(265, 25);
			_lbl_apu_2.Name = "_lbl_apu_2";
			_lbl_apu_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_apu_2.Size = new System.Drawing.Size(265, 25);
			_lbl_apu_2.TabIndex = 271;
			_lbl_apu_2.Text = "Records";
			// 
			// _lbl_apu_1
			// 
			_lbl_apu_1.AllowDrop = true;
			_lbl_apu_1.BackColor = System.Drawing.SystemColors.Control;
			_lbl_apu_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_apu_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_apu_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_apu_1.Location = new System.Drawing.Point(464, 92);
			_lbl_apu_1.MinimumSize = new System.Drawing.Size(273, 25);
			_lbl_apu_1.Name = "_lbl_apu_1";
			_lbl_apu_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_apu_1.Size = new System.Drawing.Size(273, 25);
			_lbl_apu_1.TabIndex = 268;
			_lbl_apu_1.Text = "Update To:";
			// 
			// _lbl_apu_0
			// 
			_lbl_apu_0.AllowDrop = true;
			_lbl_apu_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_apu_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_apu_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_apu_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_apu_0.Location = new System.Drawing.Point(456, 164);
			_lbl_apu_0.MinimumSize = new System.Drawing.Size(465, 25);
			_lbl_apu_0.Name = "_lbl_apu_0";
			_lbl_apu_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_apu_0.Size = new System.Drawing.Size(465, 25);
			_lbl_apu_0.TabIndex = 267;
			_lbl_apu_0.Text = ".....";
			_lbl_apu_0.Visible = false;
			// 
			// _tab_Lookup_TabPage11
			// 
			_tab_Lookup_TabPage11.Controls.Add(frm_edit_class);
			_tab_Lookup_TabPage11.Controls.Add(lst_class);
			_tab_Lookup_TabPage11.Controls.Add(_lbl_apu_4);
			_tab_Lookup_TabPage11.Controls.Add(_lbl_apu_3);
			_tab_Lookup_TabPage11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage11.Text = "Class";
			// 
			// frm_edit_class
			// 
			frm_edit_class.AllowDrop = true;
			frm_edit_class.BackColor = System.Drawing.SystemColors.Control;
			frm_edit_class.Controls.Add(_cmd_class_1);
			frm_edit_class.Controls.Add(_cmd_class_0);
			frm_edit_class.Controls.Add(_cbo_days_1);
			frm_edit_class.Controls.Add(_cbo_days_0);
			frm_edit_class.Controls.Add(_txt_class_1);
			frm_edit_class.Controls.Add(_txt_class_0);
			frm_edit_class.Controls.Add(_lbl_apu_8);
			frm_edit_class.Controls.Add(_lbl_apu_7);
			frm_edit_class.Controls.Add(_lbl_apu_6);
			frm_edit_class.Controls.Add(_lbl_apu_5);
			frm_edit_class.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_edit_class.Enabled = true;
			frm_edit_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_edit_class.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_edit_class.Location = new System.Drawing.Point(656, 36);
			frm_edit_class.Name = "frm_edit_class";
			frm_edit_class.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_edit_class.Size = new System.Drawing.Size(273, 177);
			frm_edit_class.TabIndex = 275;
			frm_edit_class.Text = "Edit Class";
			frm_edit_class.Visible = false;
			// 
			// _cmd_class_1
			// 
			_cmd_class_1.AllowDrop = true;
			_cmd_class_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_class_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_class_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_class_1.Location = new System.Drawing.Point(8, 152);
			_cmd_class_1.Name = "_cmd_class_1";
			_cmd_class_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_class_1.Size = new System.Drawing.Size(49, 17);
			_cmd_class_1.TabIndex = 285;
			_cmd_class_1.Text = "Cancel";
			_cmd_class_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_class_1.UseVisualStyleBackColor = false;
			_cmd_class_1.Click += new System.EventHandler(cmd_class_Click);
			// 
			// _cmd_class_0
			// 
			_cmd_class_0.AllowDrop = true;
			_cmd_class_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_class_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_class_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_class_0.Location = new System.Drawing.Point(200, 144);
			_cmd_class_0.Name = "_cmd_class_0";
			_cmd_class_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_class_0.Size = new System.Drawing.Size(65, 25);
			_cmd_class_0.TabIndex = 284;
			_cmd_class_0.Text = "Save";
			_cmd_class_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_class_0.UseVisualStyleBackColor = false;
			_cmd_class_0.Click += new System.EventHandler(cmd_class_Click);
			// 
			// _cbo_days_1
			// 
			_cbo_days_1.AllowDrop = true;
			_cbo_days_1.BackColor = System.Drawing.SystemColors.Window;
			_cbo_days_1.CausesValidation = true;
			_cbo_days_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_days_1.Enabled = true;
			_cbo_days_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_days_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_days_1.IntegralHeight = true;
			_cbo_days_1.Location = new System.Drawing.Point(160, 112);
			_cbo_days_1.Name = "_cbo_days_1";
			_cbo_days_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_days_1.Size = new System.Drawing.Size(105, 21);
			_cbo_days_1.Sorted = false;
			_cbo_days_1.TabIndex = 283;
			_cbo_days_1.TabStop = true;
			_cbo_days_1.Visible = true;
			// 
			// _cbo_days_0
			// 
			_cbo_days_0.AllowDrop = true;
			_cbo_days_0.BackColor = System.Drawing.SystemColors.Window;
			_cbo_days_0.CausesValidation = true;
			_cbo_days_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_days_0.Enabled = true;
			_cbo_days_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_days_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_days_0.IntegralHeight = true;
			_cbo_days_0.Location = new System.Drawing.Point(160, 80);
			_cbo_days_0.Name = "_cbo_days_0";
			_cbo_days_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_days_0.Size = new System.Drawing.Size(105, 21);
			_cbo_days_0.Sorted = false;
			_cbo_days_0.TabIndex = 282;
			_cbo_days_0.TabStop = true;
			_cbo_days_0.Visible = true;
			// 
			// _txt_class_1
			// 
			_txt_class_1.AcceptsReturn = true;
			_txt_class_1.AllowDrop = true;
			_txt_class_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_class_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_class_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_class_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_class_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_class_1.Location = new System.Drawing.Point(112, 48);
			_txt_class_1.MaxLength = 15;
			_txt_class_1.Name = "_txt_class_1";
			_txt_class_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_class_1.Size = new System.Drawing.Size(153, 19);
			_txt_class_1.TabIndex = 279;
			// 
			// _txt_class_0
			// 
			_txt_class_0.AcceptsReturn = true;
			_txt_class_0.AllowDrop = true;
			_txt_class_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_class_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_class_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_class_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_class_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_class_0.Location = new System.Drawing.Point(216, 16);
			_txt_class_0.MaxLength = 0;
			_txt_class_0.Name = "_txt_class_0";
			_txt_class_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_class_0.Size = new System.Drawing.Size(49, 19);
			_txt_class_0.TabIndex = 278;
			// 
			// _lbl_apu_8
			// 
			_lbl_apu_8.AllowDrop = true;
			_lbl_apu_8.BackColor = System.Drawing.SystemColors.Control;
			_lbl_apu_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_apu_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_apu_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_apu_8.Location = new System.Drawing.Point(16, 112);
			_lbl_apu_8.MinimumSize = new System.Drawing.Size(81, 17);
			_lbl_apu_8.Name = "_lbl_apu_8";
			_lbl_apu_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_apu_8.Size = new System.Drawing.Size(81, 17);
			_lbl_apu_8.TabIndex = 281;
			_lbl_apu_8.Text = "For Sale Days";
			// 
			// _lbl_apu_7
			// 
			_lbl_apu_7.AllowDrop = true;
			_lbl_apu_7.BackColor = System.Drawing.SystemColors.Control;
			_lbl_apu_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_apu_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_apu_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_apu_7.Location = new System.Drawing.Point(16, 80);
			_lbl_apu_7.MinimumSize = new System.Drawing.Size(65, 17);
			_lbl_apu_7.Name = "_lbl_apu_7";
			_lbl_apu_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_apu_7.Size = new System.Drawing.Size(65, 17);
			_lbl_apu_7.TabIndex = 280;
			_lbl_apu_7.Text = "Days";
			// 
			// _lbl_apu_6
			// 
			_lbl_apu_6.AllowDrop = true;
			_lbl_apu_6.BackColor = System.Drawing.SystemColors.Control;
			_lbl_apu_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_apu_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_apu_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_apu_6.Location = new System.Drawing.Point(16, 48);
			_lbl_apu_6.MinimumSize = new System.Drawing.Size(65, 17);
			_lbl_apu_6.Name = "_lbl_apu_6";
			_lbl_apu_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_apu_6.Size = new System.Drawing.Size(65, 17);
			_lbl_apu_6.TabIndex = 277;
			_lbl_apu_6.Text = "Name";
			// 
			// _lbl_apu_5
			// 
			_lbl_apu_5.AllowDrop = true;
			_lbl_apu_5.BackColor = System.Drawing.SystemColors.Control;
			_lbl_apu_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_apu_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_apu_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_apu_5.Location = new System.Drawing.Point(16, 24);
			_lbl_apu_5.MinimumSize = new System.Drawing.Size(65, 17);
			_lbl_apu_5.Name = "_lbl_apu_5";
			_lbl_apu_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_apu_5.Size = new System.Drawing.Size(65, 17);
			_lbl_apu_5.TabIndex = 276;
			_lbl_apu_5.Text = "Class";
			// 
			// lst_class
			// 
			lst_class.AllowDrop = true;
			lst_class.BackColor = System.Drawing.SystemColors.Window;
			lst_class.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lst_class.CausesValidation = true;
			lst_class.Enabled = true;
			lst_class.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_class.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_class.IntegralHeight = true;
			lst_class.Location = new System.Drawing.Point(24, 36);
			lst_class.MultiColumn = false;
			lst_class.Name = "lst_class";
			lst_class.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_class.Size = new System.Drawing.Size(553, 133);
			lst_class.Sorted = false;
			lst_class.TabIndex = 272;
			lst_class.TabStop = true;
			lst_class.Visible = true;
			lst_class.SelectedIndexChanged += new System.EventHandler(lst_class_SelectedIndexChanged);
			// 
			// _lbl_apu_4
			// 
			_lbl_apu_4.AllowDrop = true;
			_lbl_apu_4.BackColor = System.Drawing.SystemColors.Control;
			_lbl_apu_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_apu_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_apu_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_apu_4.Location = new System.Drawing.Point(24, 12);
			_lbl_apu_4.MinimumSize = new System.Drawing.Size(553, 25);
			_lbl_apu_4.Name = "_lbl_apu_4";
			_lbl_apu_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_apu_4.Size = new System.Drawing.Size(553, 25);
			_lbl_apu_4.TabIndex = 274;
			_lbl_apu_4.Text = "Class                           Name                           Days                 For Sale Days             Model Count            AC Count";
			// 
			// _lbl_apu_3
			// 
			_lbl_apu_3.AllowDrop = true;
			_lbl_apu_3.BackColor = System.Drawing.SystemColors.Control;
			_lbl_apu_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_apu_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_apu_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_apu_3.Location = new System.Drawing.Point(24, 188);
			_lbl_apu_3.MinimumSize = new System.Drawing.Size(265, 25);
			_lbl_apu_3.Name = "_lbl_apu_3";
			_lbl_apu_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_apu_3.Size = new System.Drawing.Size(265, 25);
			_lbl_apu_3.TabIndex = 273;
			_lbl_apu_3.Text = "Records";
			// 
			// tbr_ToolBar
			// 
			tbr_ToolBar.AllowDrop = true;
			tbr_ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
			tbr_ToolBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tbr_ToolBar.Location = new System.Drawing.Point(0, 24);
			tbr_ToolBar.Name = "tbr_ToolBar";
			tbr_ToolBar.ShowItemToolTips = true;
			tbr_ToolBar.Size = new System.Drawing.Size(1086, 28);
			tbr_ToolBar.TabIndex = 0;
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
			// frm_CommonLookup
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(1086, 704);
			ControlBox = false;
			Controls.Add(tab_Lookup);
			Controls.Add(tbr_ToolBar);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(235, 182);
			MaximizeBox = true;
			MinimizeBox = false;
			Name = "frm_CommonLookup";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Common Lookup Table Maintenance";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(cmd_AppConfig_save, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_JC, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_JC, 0);
			commandButtonHelper1.SetStyle(cmd_Save_JC, 0);
			commandButtonHelper1.SetStyle(Update_Renamed, 0);
			commandButtonHelper1.SetStyle(cmd_Add_JC, 0);
			commandButtonHelper1.SetStyle(cmdSaveTeam, 0);
			commandButtonHelper1.SetStyle(cmd_Save_User, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_User, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_User, 0);
			commandButtonHelper1.SetStyle(cmd_Add_User, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Service, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_Service, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Service, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Service, 0);
			commandButtonHelper1.SetStyle(cmdAddAccountRep, 0);
			commandButtonHelper1.SetStyle(cmdAcctRepSave, 0);
			commandButtonHelper1.SetStyle(cmdAccountRepCancel, 0);
			commandButtonHelper1.SetStyle(cmdAccountRepDelete, 0);
			commandButtonHelper1.SetStyle(cmd_Clear_Aircraft_Record_Locks, 0);
			commandButtonHelper1.SetStyle(cmd_Clear_Contact_Record_locks, 0);
			commandButtonHelper1.SetStyle(cmd_Clear_Company_Record_Locks, 0);
			commandButtonHelper1.SetStyle(cmdCheckCompOrphanPhoneNbrs, 0);
			commandButtonHelper1.SetStyle(cmdCheckContactOrphanPhoneNbrs, 0);
			commandButtonHelper1.SetStyle(cmdRemoveCompOrphanPhoneNbrs, 0);
			commandButtonHelper1.SetStyle(cmdRemoveContactOrphanPhoneNbrs, 0);
			commandButtonHelper1.SetStyle(cmd_Analyze_Emails, 0);
			commandButtonHelper1.SetStyle(cmd_run_summary_query, 0);
			commandButtonHelper1.SetStyle(cmd_delete, 0);
			commandButtonHelper1.SetStyle(btn_update_sub_group, 0);
			commandButtonHelper1.SetStyle(btn_test_query, 0);
			commandButtonHelper1.SetStyle(btn_save, 0);
			commandButtonHelper1.SetStyle(btn_new, 0);
			commandButtonHelper1.SetStyle(btn_send, 0);
			commandButtonHelper1.SetStyle(cmd_refresh, 0);
			commandButtonHelper1.SetStyle(cmd_sort_up, 0);
			commandButtonHelper1.SetStyle(cmd_sort_down, 0);
			commandButtonHelper1.SetStyle(_cmd_av_button_5, 0);
			commandButtonHelper1.SetStyle(_cmd_av_button_4, 0);
			commandButtonHelper1.SetStyle(_cmd_av_button_2, 0);
			commandButtonHelper1.SetStyle(_cmd_av_button_1, 0);
			commandButtonHelper1.SetStyle(_cmd_av_button_0, 0);
			commandButtonHelper1.SetStyle(_cmd_av_button_3, 0);
			commandButtonHelper1.SetStyle(_cmd_apu_3, 0);
			commandButtonHelper1.SetStyle(_cmd_apu_2, 0);
			commandButtonHelper1.SetStyle(_cmd_apu_1, 0);
			commandButtonHelper1.SetStyle(_cmd_apu_0, 0);
			commandButtonHelper1.SetStyle(_cmd_class_1, 0);
			commandButtonHelper1.SetStyle(_cmd_class_0, 0);
			listBoxHelper1.SetSelectionMode(list_CustomFields, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(_lst_av_names_2, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(_lst_av_names_1, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(_lst_av_names_0, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(_lst_apu_0, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_class, System.Windows.Forms.SelectionMode.One);
			ToolTipMain.SetToolTip(txtUserTeamLeaderTeam, "Enter User Id's Seperated by Comma's");
			ToolTipMain.SetToolTip(chkUserMonitorActivityFlag, "If This Is Checked User Activity Will Be Logged");
			ToolTipMain.SetToolTip(txt_user_marketing_subids_allowed, "Enter SubId's This User Is Allowed To Market ####,####");
			ToolTipMain.SetToolTip(chk_user_logged_in, "If the User is Currently Logged In This Flag Will Be Checked");
			ToolTipMain.SetToolTip(chkIncludeInactive, "If This Is Checked User Activity Will Be Logged");
			UpgradeHelpers.Gui.Controls.SSTabHelper.SetSelectedIndex(tab_Lookup, 8);
			Activated += new System.EventHandler(frm_CommonLookup_Activated);
			Closed += new System.EventHandler(Form_Closed);
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_FormClosing);
			((System.ComponentModel.ISupportInitialize) fG_JournalCat).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Users).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Service).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Subscriptions).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_AccountRep).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_email).EndInit();
			((System.ComponentModel.ISupportInitialize) grid_details).EndInit();
			tab_Lookup.ResumeLayout(false);
			tab_Lookup.PerformLayout();
			_tab_Lookup_TabPage0.ResumeLayout(false);
			_tab_Lookup_TabPage0.PerformLayout();
			pnl_website_Update_Change.ResumeLayout(false);
			pnl_website_Update_Change.PerformLayout();
			_tab_Lookup_TabPage1.ResumeLayout(false);
			_tab_Lookup_TabPage1.PerformLayout();
			pnl_JC_Update_Change.ResumeLayout(false);
			pnl_JC_Update_Change.PerformLayout();
			pnl_JC_List.ResumeLayout(false);
			pnl_JC_List.PerformLayout();
			SSPanel1.ResumeLayout(false);
			SSPanel1.PerformLayout();
			_tab_Lookup_TabPage2.ResumeLayout(false);
			_tab_Lookup_TabPage2.PerformLayout();
			pnl_User_Update_Change.ResumeLayout(false);
			pnl_User_Update_Change.PerformLayout();
			frmTeamLeader.ResumeLayout(false);
			frmTeamLeader.PerformLayout();
			user_delete_attached_ac_specs_flag.ResumeLayout(false);
			user_delete_attached_ac_specs_flag.PerformLayout();
			_tab_Lookup_TabPage3.ResumeLayout(false);
			_tab_Lookup_TabPage3.PerformLayout();
			pnl_Service_Update_Change.ResumeLayout(false);
			pnl_Service_Update_Change.PerformLayout();
			_tab_Lookup_TabPage4.ResumeLayout(false);
			_tab_Lookup_TabPage4.PerformLayout();
			pnlAcctRepUpdateChange.ResumeLayout(false);
			pnlAcctRepUpdateChange.PerformLayout();
			_tab_Lookup_TabPage5.ResumeLayout(false);
			_tab_Lookup_TabPage5.PerformLayout();
			_tab_Lookup_TabPage6.ResumeLayout(false);
			_tab_Lookup_TabPage6.PerformLayout();
			_tab_Lookup_TabPage7.ResumeLayout(false);
			_tab_Lookup_TabPage7.PerformLayout();
			_tab_Lookup_TabPage8.ResumeLayout(false);
			_tab_Lookup_TabPage8.PerformLayout();
			frame_CustomField.ResumeLayout(false);
			frame_CustomField.PerformLayout();
			frame_products.ResumeLayout(false);
			frame_products.PerformLayout();
			tabstrip_data.ResumeLayout(false);
			tabstrip_data.PerformLayout();
			_tabstrip_data_TabPage0.ResumeLayout(false);
			_tabstrip_data_TabPage0.PerformLayout();
			_tabstrip_data_TabPage1.ResumeLayout(false);
			_tabstrip_data_TabPage1.PerformLayout();
			_tab_Lookup_TabPage9.ResumeLayout(false);
			_tab_Lookup_TabPage9.PerformLayout();
			_pnl_avionics_1.ResumeLayout(false);
			_pnl_avionics_1.PerformLayout();
			pnl_yes_no.ResumeLayout(false);
			pnl_yes_no.PerformLayout();
			_pnl_avionics_0.ResumeLayout(false);
			_pnl_avionics_0.PerformLayout();
			_tab_Lookup_TabPage10.ResumeLayout(false);
			_tab_Lookup_TabPage10.PerformLayout();
			_tab_Lookup_TabPage11.ResumeLayout(false);
			_tab_Lookup_TabPage11.PerformLayout();
			frm_edit_class.ResumeLayout(false);
			frm_edit_class.PerformLayout();
			tbr_ToolBar.ResumeLayout(false);
			tbr_ToolBar.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializetxt_search_apu();
			Initializetxt_class();
			Initializetxt_avionics();
			Initializepnl_avionics();
			Initializelst_av_names();
			Initializelst_apu();
			Initializelbl_avionics();
			Initializelbl_apu();
			Initializecmd_class();
			Initializecmd_av_button();
			Initializecmd_apu();
			Initializechk_service();
			Initializecbo_days();
			Initializecbo_avionics();
			tab_LookupPreviousTab = tab_Lookup.SelectedIndex;
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = HomebaseAdministrator.mdi_AdminAssistant.DefInstance;
			HomebaseAdministrator.mdi_AdminAssistant.DefInstance.Show();
		}
		void Initializetxt_search_apu()
		{
			txt_search_apu = new System.Windows.Forms.TextBox[2];
			txt_search_apu[1] = _txt_search_apu_1;
			txt_search_apu[0] = _txt_search_apu_0;
		}
		void Initializetxt_class()
		{
			txt_class = new System.Windows.Forms.TextBox[2];
			txt_class[1] = _txt_class_1;
			txt_class[0] = _txt_class_0;
		}
		void Initializetxt_avionics()
		{
			txt_avionics = new System.Windows.Forms.TextBox[3];
			txt_avionics[1] = _txt_avionics_1;
			txt_avionics[2] = _txt_avionics_2;
			txt_avionics[0] = _txt_avionics_0;
		}
		void Initializepnl_avionics()
		{
			pnl_avionics = new System.Windows.Forms.Panel[2];
			pnl_avionics[0] = _pnl_avionics_0;
			pnl_avionics[1] = _pnl_avionics_1;
		}
		void Initializelst_av_names()
		{
			lst_av_names = new System.Windows.Forms.ListBox[3];
			lst_av_names[0] = _lst_av_names_0;
			lst_av_names[2] = _lst_av_names_2;
			lst_av_names[1] = _lst_av_names_1;
		}
		void Initializelst_apu()
		{
			lst_apu = new System.Windows.Forms.ListBox[1];
			lst_apu[0] = _lst_apu_0;
		}
		void Initializelbl_avionics()
		{
			lbl_avionics = new System.Windows.Forms.Label[9];
			lbl_avionics[6] = _lbl_avionics_6;
			lbl_avionics[4] = _lbl_avionics_4;
			lbl_avionics[2] = _lbl_avionics_2;
			lbl_avionics[1] = _lbl_avionics_1;
			lbl_avionics[0] = _lbl_avionics_0;
			lbl_avionics[8] = _lbl_avionics_8;
			lbl_avionics[5] = _lbl_avionics_5;
			lbl_avionics[7] = _lbl_avionics_7;
			lbl_avionics[3] = _lbl_avionics_3;
		}
		void Initializelbl_apu()
		{
			lbl_apu = new System.Windows.Forms.Label[9];
			lbl_apu[8] = _lbl_apu_8;
			lbl_apu[7] = _lbl_apu_7;
			lbl_apu[6] = _lbl_apu_6;
			lbl_apu[5] = _lbl_apu_5;
			lbl_apu[4] = _lbl_apu_4;
			lbl_apu[3] = _lbl_apu_3;
			lbl_apu[2] = _lbl_apu_2;
			lbl_apu[1] = _lbl_apu_1;
			lbl_apu[0] = _lbl_apu_0;
		}
		void Initializecmd_class()
		{
			cmd_class = new System.Windows.Forms.Button[2];
			cmd_class[1] = _cmd_class_1;
			cmd_class[0] = _cmd_class_0;
		}
		void Initializecmd_av_button()
		{
			cmd_av_button = new System.Windows.Forms.Button[6];
			cmd_av_button[3] = _cmd_av_button_3;
			cmd_av_button[5] = _cmd_av_button_5;
			cmd_av_button[4] = _cmd_av_button_4;
			cmd_av_button[2] = _cmd_av_button_2;
			cmd_av_button[1] = _cmd_av_button_1;
			cmd_av_button[0] = _cmd_av_button_0;
		}
		void Initializecmd_apu()
		{
			cmd_apu = new System.Windows.Forms.Button[4];
			cmd_apu[3] = _cmd_apu_3;
			cmd_apu[2] = _cmd_apu_2;
			cmd_apu[1] = _cmd_apu_1;
			cmd_apu[0] = _cmd_apu_0;
		}
		void Initializechk_service()
		{
			chk_service = new System.Windows.Forms.CheckBox[6];
			chk_service[5] = _chk_service_5;
			chk_service[4] = _chk_service_4;
			chk_service[3] = _chk_service_3;
			chk_service[2] = _chk_service_2;
			chk_service[1] = _chk_service_1;
			chk_service[0] = _chk_service_0;
		}
		void Initializecbo_days()
		{
			cbo_days = new System.Windows.Forms.ComboBox[2];
			cbo_days[1] = _cbo_days_1;
			cbo_days[0] = _cbo_days_0;
		}
		void Initializecbo_avionics()
		{
			cbo_avionics = new System.Windows.Forms.ComboBox[3];
			cbo_avionics[2] = _cbo_avionics_2;
			cbo_avionics[1] = _cbo_avionics_1;
			cbo_avionics[0] = _cbo_avionics_0;
		}
		#endregion
	}
}