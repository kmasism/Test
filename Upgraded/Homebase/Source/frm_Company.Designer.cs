
namespace JETNET_Homebase
{
	partial class frm_Company
	{

		#region "Upgrade Support "
		private static frm_Company m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Company DefInstance
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
		public static frm_Company CreateInstance()
		{
			frm_Company theInstance = new frm_Company();
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
		private void Ctx_mnuTools_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			Ctx_mnuTools.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach (System.Windows.Forms.ToolStripItem item in ((System.Windows.Forms.ToolStripMenuItem) mnuTools).DropDownItems)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				Ctx_mnuTools.Items.Add(item);
			}
			e.Cancel = false;
		}
		private void Ctx_mnuTools_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach (System.Windows.Forms.ToolStripItem item in Ctx_mnuTools.Items)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				((System.Windows.Forms.ToolStripMenuItem) mnuTools).DropDownItems.Add(item);
			}
		}
		private void Ctx_mnuRightClickAircraft_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			Ctx_mnuRightClickAircraft.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach (System.Windows.Forms.ToolStripItem item in ((System.Windows.Forms.ToolStripMenuItem) mnuRightClickAircraft).DropDownItems)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				Ctx_mnuRightClickAircraft.Items.Add(item);
			}
			e.Cancel = false;
		}
		private void Ctx_mnuRightClickAircraft_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach (System.Windows.Forms.ToolStripItem item in Ctx_mnuRightClickAircraft.Items)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				((System.Windows.Forms.ToolStripMenuItem) mnuRightClickAircraft).DropDownItems.Add(item);
			}
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnufileclose", "mnufilelogout", "mnufile", "mnueditaddcompany", "mnueditaddcompanyphone", "mnueditremovecompanyphone", "mnuRemoveDupContacts", "mnuEditAddFractional", "mnuRemoveFractional", "mnuSurveyResponse", "mnuEditCompMailingList", "mnuAddCompPub", "mnuAddCompanyDocument", "mnuEditTransmitCompanyRecord", "mnuEdit", "mnuViewBadEmails", "_mnuViewJournalSubType_1", "_mnuViewJournalSubType_2", "_mnuViewJournalSubType_3", "mnuViewJournalType", "ViewCompany", "mnusoldprices", "mnuView", "_mnuReportList_0", "_mnuReportList_1", "_mnuReportList_2", "_mnuReportList_3", "_mnuReportList_4", "_mnuReportList_5", "_mnuReportList_6", "_mnuReportList_7", "mnuReportDeliveryPositionReport", "mnuReportInOperationReport", "mnuReport", "mnuSubscriptions", "mnuACSearch", "mnuCompanyDialPhoneNumber", "mnuCompanyShowUserHistory", "mnuTools", "mnuConfirmACBase", "mnuMassConfirmACBase", "mnuConfirmACReg", "mnuMassConfirmACReg", "mnuChangeBusinessType", "mnuChangeBusinessTypeOnAllReferences", "mnuChangeBusinessTypeOnAllAircraft", "mnuShowExclusiveBroker", "mnuShowOwner", "mnuConfirmManagement", "mnuConfirmCharter", "mnuConfirnManCharter", "mnuShowExtra", "mnuRightClickAircraft", "mnuShowCentralAgent", "mnuRightClickYacht", "MainMenu1", "_lbl_test_omg3_1", "_lbl_comp_15", "_shp_Shape_1", "_lbl_comp_62", "_lbl_comp_51", "_lbl_comp_4", "_shp_dealer_background_7", "grd_company_aircraft", "chk_view_eu", "_cmd_ac_verify_7", "_cmd_ac_verify_6", "_cmd_ac_verify_5", "_cmd_ac_verify_4", "_cmd_ac_verify_3", "_cmd_ac_verify_2", "_cmd_ac_verify_1", "_cmd_ac_verify_0", "cbo_comp_purchase_question", "cbo_ac_delivery_position", "_txt_gen_7", "_txt_gen_6", "chk_change_same_ac_contact_type_only", "_txt_gen_0", "_txt_gen_5", "_txt_gen_2", "lst_aircraft_contact", "_txt_gen_4", "_txt_gen_1", "cbo_company_research_contact", "cmd_aircraft_all_contact_change", "cmd_aircraft_contact_change", "_txt_gen_3", "_txt_gen_8", "txt_only_show_first_aircraft_recs", "chk_limit_aircraft_list", "txt_total_aircraft", "_tab_company_details_TabPage0", "_lbl_comp_35", "_lbl_comp_97", "_lbl_comp_86", "_lbl_comp_85", "_shp_dealer_background_8", "_lbl_comp_109", "grd_company_contacts", "chk_contact_research_flag", "chk_contact_active_flag", "txt_contact_description", "cbo_contact_suffix", "txt_contact_last_name", "txt_contact_middle_initial", "txt_contact_first_name", "txt_contact_email_address", "cbo_contact_title", "cbo_contact_sirname", "txt_contact_id", "chk_contact_hide_flag", "cmd_EditMailList", "cmbContactEMail", "_btn_array_0", "_btn_array_1", "_txt_market_note_5", "grd_contact_phone_numbers", "_lbl_comp_68", "_lbl_comp_67", "_lbl_comp_69", "_lbl_comp_300", "_lbl_comp_77", "_lbl_comp_91", "_lbl_comp_1", "pnl_company_contact_details", "_txt_market_note_7", "_chk_array_5", "_btn_array_3", "_btn_array_2", "cbo_order_by", "cmd_contact_seq_down", "cmd_contact_seq_up", "_chk_array_0", "_tab_company_details_TabPage1", "_lbl_comp_102", "_lbl_comp_50", "_lbl_comp_70", "_lbl_comp_37", "_shp_dealer_background_9", "grd_company_journal", "txtCompJournalSearch", "cbo_journal_note_type", "cmd_company_fill_journal", "txt_only_show_first_journal_recs", "chk_limit_journal_list", "txt_journal_ac_selected", "_tab_company_details_TabPage2", "_lbl_comp_84", "_lbl_comp_83", "_shp_dealer_background_10", "txt_amwant_notes", "_lbl_comp_90", "pnl_company_wanted_notes", "grd_company_wanted", "txt_amwant_max_aftt", "_cmd_wanted_save_0", "txt_amwant_pricenote", "txt_amwant_yearnote", "txt_amwant_max_price", "txt_amwant_end_year", "txt_amwant_start_year", "txt_amwant_listed_date", "cbo_amwant_accept_damage_hist", "cbo_amwant_accept_damage_cur", "_lbl_comp_2", "_lbl_comp_36", "frame_wanted_accept_aircraft_with", "txt_amwant_date_verified", "chk_amwant_date_is_verified", "cbo_amwant_model", "frame_wanted_makemodel", "chk_amwant_auto_distribute_flag", "txt_amwant_auto_distribute_email", "txt_amwant_auto_unsuscribe_date", "txt_amwant_auto_distribute_replyname", "_cmd_wanted_save_1", "_cmd_wanted_save_2", "_cmd_wanted_save_3", "_lbl_comp_29", "_lbl_comp_32", "_lbl_comp_34", "_lbl_comp_33", "_lbl_comp_43", "_lbl_comp_9", "_lbl_comp_88", "_lbl_comp_89", "_lbl_comp_21", "_lbl_comp_81", "Shape3", "pnl_company_wanted", "chkShowAllWanted", "cmd_wanted_delete", "cmd_wanted_add", "_tab_company_details_TabPage3", "_shp_dealer_background_11", "grd_company_shares", "_tab_company_details_TabPage4", "_lbl_comp_101", "_shp_dealer_background_12", "grd_company_documents", "_txt_company_field_2", "_cmdCertCommand_5", "_cbo_comp_account_5", "_tab_company_details_TabPage5", "_lbl_comp_80", "_lbl_comp_79", "_shp_dealer_background_13", "grd_company_expired_leases", "_tab_company_details_TabPage6", "grd_marketing_crm_notes", "_cmd_verify_yacht_6", "_txt_market_note_0", "_tab_company_details_TabPage7", "_chk_comp_product_code_6", "_tab_company_details_TabPage8", "gdCompDocInProcess", "_tab_company_details_TabPage9", "grd_pubs", "_chk_comp_product_code_7", "_tab_company_details_TabPage10", "tab_company_details", "_chk_company_flag_1", "chkCompDoNotSendEMail", "txt_comp_name", "_chk_company_flag_0", "cbo_comp_name_alt_type", "txt_comp_email_address", "txt_comp_name_alt", "cmd_company_add_note", "txt_history_date", "cmd_company_save", "txt_comp_web_address", "cbo_comp_timezone", "txt_comp_city", "txt_comp_address1", "txt_comp_id", "txt_comp_zip_code", "cbo_comp_state", "txt_comp_address2", "cbo_comp_country", "chk_dont_color_confirm", "time_ac_timer", "time_cc_timer", "time_at_company", "cmd_company_name_change_cancel", "txt_comp_name_change_new", "txt_comp_name_current", "_lbl_comp_16", "_lbl_comp_14", "pnl_company_name_change", "grd_company_phone", "chk_comp_pnum_hide_customer", "cmd_company_phone_confirm", "txt_pnum_prefix", "cbo_comp_pnum_type", "cmd_company_phone_cancel", "txt_pnum_cntry_code", "txt_pnum_number", "txt_pnum_area_code", "cmd_company_phone_save", "_lbl_comp_45", "_lbl_comp_24", "_lbl_comp_52", "_lbl_comp_25", "_lbl_comp_53", "frame_comp_phone", "_lbl_test_omg3_3", "_lbl_comp_64", "lbl_Time", "lbl_message", "_lbl_comp_55", "_lbl_comp_63", "_lbl_comp_23", "_lbl_comp_26", "_lbl_comp_0", "_lbl_comp_66", "_lbl_comp_65", "_lbl_comp_76", "pnl_company_main", "tbr_ToolBar_Buttons_Button1", "tbr_ToolBar_Buttons_Button2", "tbr_ToolBar_Buttons_Button3", "tbr_ToolBar_Buttons_Button4", "tbr_ToolBar", "_shp_dealer_background_0", "_lbl_comp_6", "_lbl_comp_10", "_lbl_comp_39", "_lbl_comp_11", "_lbl_comp_13", "_lbl_comp_28", "_lbl_comp_44", "_lbl_comp_3", "_lbl_comp_22", "_lbl_comp_5", "_lbl_comp_7", "_shp_Shape_0", "Shape2", "_lbl_comp_87", "_lbl_comp_61", "cbo_comp_services_used", "lst_business_types", "cmd_edit_business_types", "cbo_comp_govsub_code", "cbo_comp_business_type", "cbo_comp_agency_type", "cbo_comp_language", "txt_comp_dunnandbrad", "txt_comp_sic_code", "_chk_comp_product_code_0", "_chk_comp_product_code_1", "_chk_comp_product_code_2", "_chk_comp_product_code_3", "_chk_comp_product_code_4", "_chk_comp_product_code_5", "_lbl_comp_115", "_lbl_comp_116", "_lbl_test_omg3_0", "chk_include_on_ac_pros", "txt_comp_description", "_txt_company_field_4", "_tab_comp_description_TabPage0", "cbo_comp_fractowr_contact_id", "txt_comp_fractowr_notes", "txt_comp_fractowr_id", "_lbl_comp_54", "pnl_fractional_owner", "_tab_comp_description_TabPage1", "cmd_Edit_Comp_Description", "_tab_comp_description_TabPage2", "company_logo", "cmd_delete_logo", "_tab_comp_description_TabPage3", "_lbl_comp_114", "_lbl_comp_18", "_tab_comp_description_TabPage4", "_txt_market_note_4", "_tab_comp_description_TabPage5", "_lbl_comp_12", "_txt_market_note_6", "_tab_comp_description_TabPage6", "tab_comp_description", "_cmd_company_button_0", "_cmd_company_button_1", "_tab_company_admin_TabPage0", "_shp_dealer_background_1", "_lbl_comp_38", "_lbl_comp_27", "_lbl_comp_57", "_lbl_comp_72", "_lbl_comp_71", "_lbl_comp_58", "_lbl_comp_60", "_lbl_comp_59", "_lbl_comp_8", "_lbl_comp_98", "_lbl_comp_103", "_lbl_comp_105", "_lbl_comp_112", "_lbl_comp_113", "cal_comp_callback_date", "_cmd_company_update_callback_date_0", "chk_company_assign_flag", "_cbo_comp_account_0", "cal_comp_yacht_callback_date", "_cbo_comp_account_1", "_cbo_comp_account_2", "chkCompContactAddressFlag", "_cmd_company_update_callback_date_1", "_cbo_comp_account_6", "_txt_company_field_0", "_txt_company_field_1", "_txt_company_field_3", "_chk_array_6", "_tab_company_admin_TabPage1", "txt_extra_research_note", "cmd_company_clear_research_note", "pnl_research_notes", "lst_research_notes", "_lbl_test_omg3_2", "_lbl_comp_78", "_lbl_comp_41", "_shp_dealer_background_2", "_tab_company_admin_TabPage2", "_shp_dealer_background_3", "_lbl_comp_31", "_lbl_comp_56", "_lbl_comp_20", "_lbl_comp_42", "_lbl_comp_82", "grd_company_history", "txt_historical_ac_description", "_cmdCompHistoryTab_0", "_cmdCompHistoryTab_1", "_tab_company_admin_TabPage3", "_cmd_relationship_buttons_4", "_cmd_relationship_buttons_3", "_cmd_relationship_buttons_2", "_cmd_relationship_buttons_1", "_cbo_comp_account_4", "_cbo_comp_account_3", "grd_company_relationships", "_tab_company_rel_TabPage0", "grd_company_contact_relationships", "_tab_company_rel_TabPage1", "grdCompDupByAdd", "_tab_company_rel_TabPage2", "tab_company_rel", "lst_related_contact", "cbo_related_company_contact", "chk_internal_relation", "lst_related_company", "_cmd_relationship_buttons_0", "_lbl_comp_100", "_lbl_comp_99", "_lbl_comp_74", "_shp_dealer_background_4", "_tab_company_admin_TabPage4", "lst_abi_services", "cmd_company_update_stats", "grd_company_stats", "_lbl_comp_19", "_shp_dealer_background_5", "_tab_company_admin_TabPage5", "_shp_dealer_background_6", "_lbl_comp_92", "grd_company_cert", "_cert_combo_drop_down_1", "_cert_combo_drop_down_0", "cert_number_textbox", "cert_name_textbox", "cert_note_textbox", "_cmdCertCommand_3", "_cmdCertCommand_2", "_cmdCertCommand_1", "_cmdCertCommand_0", "_lbl_comp_30", "_lbl_comp_73", "lbl_company_cert_id_label", "_lbl_comp_96", "_lbl_comp_94",  
 			"_lbl_comp_95", "_lbl_comp_93", "cert_edit_enter_frame", "_cmdCertCommand_4", "_tab_company_admin_TabPage6", "tab_company_admin", "_chk_array_4", "_chk_array_3", "_chk_array_2", "_chk_array_1", "_opt_journal_subject_1", "_opt_journal_subject_2", "_opt_journal_subject_3", "_opt_journal_subject_0", "_opt_journal_subject_4", "frame_options1", "_txt_market_note_3", "txt_marketing_notes", "frm_marketing_note", "lst_aircraft", "_opt_verify_aircraft_5", "cmd_verify_status_save", "_cmd_verify_yacht_2", "_opt_journal_subject_12", "_opt_journal_subject_13", "_opt_journal_subject_11", "_opt_journal_subject_10", "frame_verify_pnl", "cbo_yachts", "_opt_verify_aircraft_4", "cbo_verify_note_type", "_opt_verify_aircraft_3", "_opt_verify_aircraft_2", "_opt_verify_aircraft_1", "_opt_verify_aircraft_0", "cbo_verify_aircraft", "chk_verify_contact", "cmd_verify_status_cancel", "cbo_verify_other_contacts", "_pic_verify_ac_1", "_pic_verify_ac_0", "_pic_verify_ac_3", "_pic_verify_ac_2", "cbo_verify_journal_auto_subject", "cbo_verify_journal_subject", "_lbl_comp_104", "_Shape1_3", "_Shape1_2", "_Shape1_1", "_lbl_comp_49", "_lbl_comp_17", "_lbl_comp_46", "_lbl_comp_48", "_lbl_comp_47", "_lbl_comp_75", "_Shape1_0", "pnl_verify_aircraft_status", "_lbl_comp_40", "pnl_update_message", "Shape1", "btn_array", "cbo_comp_account", "cert_combo_drop_down", "chk_array", "chk_comp_product_code", "chk_company_flag", "cmdCertCommand", "cmdCompHistoryTab", "cmd_ac_verify", "cmd_company_button", "cmd_company_update_callback_date", "cmd_relationship_buttons", "cmd_verify_yacht", "cmd_wanted_save", "lbl_comp", "lbl_test_omg3", "mnuReportList", "mnuViewJournalSubType", "opt_journal_subject", "opt_verify_aircraft", "pic_verify_ac", "shp_Shape", "shp_dealer_background", "txt_company_field", "txt_gen", "txt_market_note", "Ctx_mnuTools", "Ctx_mnuRightClickAircraft", "optionButtonHelper1", "listBoxComboBoxHelper1", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnufileclose;
		public System.Windows.Forms.ToolStripMenuItem mnufilelogout;
		public System.Windows.Forms.ToolStripMenuItem mnufile;
		public System.Windows.Forms.ToolStripMenuItem mnueditaddcompany;
		public System.Windows.Forms.ToolStripMenuItem mnueditaddcompanyphone;
		public System.Windows.Forms.ToolStripMenuItem mnueditremovecompanyphone;
		public System.Windows.Forms.ToolStripMenuItem mnuRemoveDupContacts;
		public System.Windows.Forms.ToolStripMenuItem mnuEditAddFractional;
		public System.Windows.Forms.ToolStripMenuItem mnuRemoveFractional;
		public System.Windows.Forms.ToolStripMenuItem mnuSurveyResponse;
		public System.Windows.Forms.ToolStripMenuItem mnuEditCompMailingList;
		public System.Windows.Forms.ToolStripMenuItem mnuAddCompPub;
		public System.Windows.Forms.ToolStripMenuItem mnuAddCompanyDocument;
		public System.Windows.Forms.ToolStripMenuItem mnuEditTransmitCompanyRecord;
		public System.Windows.Forms.ToolStripMenuItem mnuEdit;
		public System.Windows.Forms.ToolStripMenuItem mnuViewBadEmails;
		private System.Windows.Forms.ToolStripMenuItem _mnuViewJournalSubType_1;
		private System.Windows.Forms.ToolStripMenuItem _mnuViewJournalSubType_2;
		private System.Windows.Forms.ToolStripMenuItem _mnuViewJournalSubType_3;
		public System.Windows.Forms.ToolStripMenuItem mnuViewJournalType;
		public System.Windows.Forms.ToolStripMenuItem ViewCompany;
		public System.Windows.Forms.ToolStripMenuItem mnusoldprices;
		public System.Windows.Forms.ToolStripMenuItem mnuView;
		private System.Windows.Forms.ToolStripMenuItem _mnuReportList_0;
		private System.Windows.Forms.ToolStripMenuItem _mnuReportList_1;
		private System.Windows.Forms.ToolStripMenuItem _mnuReportList_2;
		private System.Windows.Forms.ToolStripMenuItem _mnuReportList_3;
		private System.Windows.Forms.ToolStripMenuItem _mnuReportList_4;
		private System.Windows.Forms.ToolStripMenuItem _mnuReportList_5;
		private System.Windows.Forms.ToolStripMenuItem _mnuReportList_6;
		private System.Windows.Forms.ToolStripMenuItem _mnuReportList_7;
		public System.Windows.Forms.ToolStripMenuItem mnuReportDeliveryPositionReport;
		public System.Windows.Forms.ToolStripMenuItem mnuReportInOperationReport;
		public System.Windows.Forms.ToolStripMenuItem mnuReport;
		public System.Windows.Forms.ToolStripMenuItem mnuSubscriptions;
		public System.Windows.Forms.ToolStripMenuItem mnuACSearch;
		public System.Windows.Forms.ToolStripMenuItem mnuCompanyDialPhoneNumber;
		public System.Windows.Forms.ToolStripMenuItem mnuCompanyShowUserHistory;
		public System.Windows.Forms.ToolStripMenuItem mnuTools;
		public System.Windows.Forms.ToolStripMenuItem mnuConfirmACBase;
		public System.Windows.Forms.ToolStripMenuItem mnuMassConfirmACBase;
		public System.Windows.Forms.ToolStripMenuItem mnuConfirmACReg;
		public System.Windows.Forms.ToolStripMenuItem mnuMassConfirmACReg;
		public System.Windows.Forms.ToolStripMenuItem mnuChangeBusinessType;
		public System.Windows.Forms.ToolStripMenuItem mnuChangeBusinessTypeOnAllReferences;
		public System.Windows.Forms.ToolStripMenuItem mnuChangeBusinessTypeOnAllAircraft;
		public System.Windows.Forms.ToolStripMenuItem mnuShowExclusiveBroker;
		public System.Windows.Forms.ToolStripMenuItem mnuShowOwner;
		public System.Windows.Forms.ToolStripMenuItem mnuConfirmManagement;
		public System.Windows.Forms.ToolStripMenuItem mnuConfirmCharter;
		public System.Windows.Forms.ToolStripMenuItem mnuConfirnManCharter;
		public System.Windows.Forms.ToolStripMenuItem mnuShowExtra;
		public System.Windows.Forms.ToolStripMenuItem mnuRightClickAircraft;
		public System.Windows.Forms.ToolStripMenuItem mnuShowCentralAgent;
		public System.Windows.Forms.ToolStripMenuItem mnuRightClickYacht;
		public System.Windows.Forms.MenuStrip MainMenu1;
		private System.Windows.Forms.Label _lbl_test_omg3_1;
		private System.Windows.Forms.Label _lbl_comp_15;
		private UpgradeHelpers.Gui.ShapeHelper _shp_Shape_1;
		private System.Windows.Forms.Label _lbl_comp_62;
		private System.Windows.Forms.Label _lbl_comp_51;
		private System.Windows.Forms.Label _lbl_comp_4;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_7;
		public UpgradeHelpers.DataGridViewFlex grd_company_aircraft;
		public System.Windows.Forms.CheckBox chk_view_eu;
		private System.Windows.Forms.Button _cmd_ac_verify_7;
		private System.Windows.Forms.Button _cmd_ac_verify_6;
		private System.Windows.Forms.Button _cmd_ac_verify_5;
		private System.Windows.Forms.Button _cmd_ac_verify_4;
		private System.Windows.Forms.Button _cmd_ac_verify_3;
		private System.Windows.Forms.Button _cmd_ac_verify_2;
		private System.Windows.Forms.Button _cmd_ac_verify_1;
		private System.Windows.Forms.Button _cmd_ac_verify_0;
		public System.Windows.Forms.ComboBox cbo_comp_purchase_question;
		public System.Windows.Forms.ComboBox cbo_ac_delivery_position;
		private System.Windows.Forms.TextBox _txt_gen_7;
		private System.Windows.Forms.TextBox _txt_gen_6;
		public System.Windows.Forms.CheckBox chk_change_same_ac_contact_type_only;
		private System.Windows.Forms.TextBox _txt_gen_0;
		private System.Windows.Forms.TextBox _txt_gen_5;
		private System.Windows.Forms.TextBox _txt_gen_2;
		public System.Windows.Forms.ListBox lst_aircraft_contact;
		private System.Windows.Forms.TextBox _txt_gen_4;
		private System.Windows.Forms.TextBox _txt_gen_1;
		public System.Windows.Forms.ComboBox cbo_company_research_contact;
		public System.Windows.Forms.Button cmd_aircraft_all_contact_change;
		public System.Windows.Forms.Button cmd_aircraft_contact_change;
		private System.Windows.Forms.TextBox _txt_gen_3;
		private System.Windows.Forms.TextBox _txt_gen_8;
		public System.Windows.Forms.TextBox txt_only_show_first_aircraft_recs;
		public System.Windows.Forms.CheckBox chk_limit_aircraft_list;
		public System.Windows.Forms.TextBox txt_total_aircraft;
		private System.Windows.Forms.TabPage _tab_company_details_TabPage0;
		private System.Windows.Forms.Label _lbl_comp_35;
		private System.Windows.Forms.Label _lbl_comp_97;
		private System.Windows.Forms.Label _lbl_comp_86;
		private System.Windows.Forms.Label _lbl_comp_85;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_8;
		private System.Windows.Forms.Label _lbl_comp_109;
		public UpgradeHelpers.DataGridViewFlex grd_company_contacts;
		public System.Windows.Forms.CheckBox chk_contact_research_flag;
		public System.Windows.Forms.CheckBox chk_contact_active_flag;
		public System.Windows.Forms.TextBox txt_contact_description;
		public System.Windows.Forms.ComboBox cbo_contact_suffix;
		public System.Windows.Forms.TextBox txt_contact_last_name;
		public System.Windows.Forms.TextBox txt_contact_middle_initial;
		public System.Windows.Forms.TextBox txt_contact_first_name;
		public System.Windows.Forms.TextBox txt_contact_email_address;
		public System.Windows.Forms.ComboBox cbo_contact_title;
		public System.Windows.Forms.ComboBox cbo_contact_sirname;
		public System.Windows.Forms.TextBox txt_contact_id;
		public System.Windows.Forms.CheckBox chk_contact_hide_flag;
		public System.Windows.Forms.Button cmd_EditMailList;
		public System.Windows.Forms.ComboBox cmbContactEMail;
		private System.Windows.Forms.Button _btn_array_0;
		private System.Windows.Forms.Button _btn_array_1;
		private System.Windows.Forms.TextBox _txt_market_note_5;
		public UpgradeHelpers.DataGridViewFlex grd_contact_phone_numbers;
		private System.Windows.Forms.Label _lbl_comp_68;
		private System.Windows.Forms.Label _lbl_comp_67;
		private System.Windows.Forms.Label _lbl_comp_69;
		private System.Windows.Forms.Label _lbl_comp_300;
		private System.Windows.Forms.Label _lbl_comp_77;
		private System.Windows.Forms.Label _lbl_comp_91;
		private System.Windows.Forms.Label _lbl_comp_1;
		public System.Windows.Forms.Panel pnl_company_contact_details;
		private System.Windows.Forms.TextBox _txt_market_note_7;
		private System.Windows.Forms.CheckBox _chk_array_5;
		private System.Windows.Forms.Button _btn_array_3;
		private System.Windows.Forms.Button _btn_array_2;
		public System.Windows.Forms.ComboBox cbo_order_by;
		public System.Windows.Forms.Button cmd_contact_seq_down;
		public System.Windows.Forms.Button cmd_contact_seq_up;
		private System.Windows.Forms.CheckBox _chk_array_0;
		private System.Windows.Forms.TabPage _tab_company_details_TabPage1;
		private System.Windows.Forms.Label _lbl_comp_102;
		private System.Windows.Forms.Label _lbl_comp_50;
		private System.Windows.Forms.Label _lbl_comp_70;
		private System.Windows.Forms.Label _lbl_comp_37;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_9;
		public UpgradeHelpers.DataGridViewFlex grd_company_journal;
		public System.Windows.Forms.TextBox txtCompJournalSearch;
		public System.Windows.Forms.ComboBox cbo_journal_note_type;
		public System.Windows.Forms.Button cmd_company_fill_journal;
		public System.Windows.Forms.TextBox txt_only_show_first_journal_recs;
		public System.Windows.Forms.CheckBox chk_limit_journal_list;
		public System.Windows.Forms.TextBox txt_journal_ac_selected;
		private System.Windows.Forms.TabPage _tab_company_details_TabPage2;
		private System.Windows.Forms.Label _lbl_comp_84;
		private System.Windows.Forms.Label _lbl_comp_83;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_10;
		public System.Windows.Forms.TextBox txt_amwant_notes;
		private System.Windows.Forms.Label _lbl_comp_90;
		public System.Windows.Forms.Panel pnl_company_wanted_notes;
		public UpgradeHelpers.DataGridViewFlex grd_company_wanted;
		public System.Windows.Forms.TextBox txt_amwant_max_aftt;
		private System.Windows.Forms.Button _cmd_wanted_save_0;
		public System.Windows.Forms.TextBox txt_amwant_pricenote;
		public System.Windows.Forms.TextBox txt_amwant_yearnote;
		public System.Windows.Forms.TextBox txt_amwant_max_price;
		public System.Windows.Forms.TextBox txt_amwant_end_year;
		public System.Windows.Forms.TextBox txt_amwant_start_year;
		public System.Windows.Forms.TextBox txt_amwant_listed_date;
		public System.Windows.Forms.ComboBox cbo_amwant_accept_damage_hist;
		public System.Windows.Forms.ComboBox cbo_amwant_accept_damage_cur;
		private System.Windows.Forms.Label _lbl_comp_2;
		private System.Windows.Forms.Label _lbl_comp_36;
		public System.Windows.Forms.GroupBox frame_wanted_accept_aircraft_with;
		public System.Windows.Forms.TextBox txt_amwant_date_verified;
		public System.Windows.Forms.CheckBox chk_amwant_date_is_verified;
		public System.Windows.Forms.ComboBox cbo_amwant_model;
		public System.Windows.Forms.GroupBox frame_wanted_makemodel;
		public System.Windows.Forms.CheckBox chk_amwant_auto_distribute_flag;
		public System.Windows.Forms.TextBox txt_amwant_auto_distribute_email;
		public System.Windows.Forms.TextBox txt_amwant_auto_unsuscribe_date;
		public System.Windows.Forms.TextBox txt_amwant_auto_distribute_replyname;
		private System.Windows.Forms.Button _cmd_wanted_save_1;
		private System.Windows.Forms.Button _cmd_wanted_save_2;
		private System.Windows.Forms.Button _cmd_wanted_save_3;
		private System.Windows.Forms.Label _lbl_comp_29;
		private System.Windows.Forms.Label _lbl_comp_32;
		private System.Windows.Forms.Label _lbl_comp_34;
		private System.Windows.Forms.Label _lbl_comp_33;
		private System.Windows.Forms.Label _lbl_comp_43;
		private System.Windows.Forms.Label _lbl_comp_9;
		private System.Windows.Forms.Label _lbl_comp_88;
		private System.Windows.Forms.Label _lbl_comp_89;
		private System.Windows.Forms.Label _lbl_comp_21;
		private System.Windows.Forms.Label _lbl_comp_81;
		public UpgradeHelpers.Gui.ShapeHelper Shape3;
		public System.Windows.Forms.Panel pnl_company_wanted;
		public System.Windows.Forms.CheckBox chkShowAllWanted;
		public System.Windows.Forms.Button cmd_wanted_delete;
		public System.Windows.Forms.Button cmd_wanted_add;
		private System.Windows.Forms.TabPage _tab_company_details_TabPage3;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_11;
		public UpgradeHelpers.DataGridViewFlex grd_company_shares;
		private System.Windows.Forms.TabPage _tab_company_details_TabPage4;
		private System.Windows.Forms.Label _lbl_comp_101;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_12;
		public UpgradeHelpers.DataGridViewFlex grd_company_documents;
		private System.Windows.Forms.TextBox _txt_company_field_2;
		private System.Windows.Forms.Button _cmdCertCommand_5;
		private System.Windows.Forms.ComboBox _cbo_comp_account_5;
		private System.Windows.Forms.TabPage _tab_company_details_TabPage5;
		private System.Windows.Forms.Label _lbl_comp_80;
		private System.Windows.Forms.Label _lbl_comp_79;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_13;
		public UpgradeHelpers.DataGridViewFlex grd_company_expired_leases;
		private System.Windows.Forms.TabPage _tab_company_details_TabPage6;
		public UpgradeHelpers.DataGridViewFlex grd_marketing_crm_notes;
		private System.Windows.Forms.Button _cmd_verify_yacht_6;
		private System.Windows.Forms.TextBox _txt_market_note_0;
		private System.Windows.Forms.TabPage _tab_company_details_TabPage7;
		private System.Windows.Forms.CheckBox _chk_comp_product_code_6;
		private System.Windows.Forms.TabPage _tab_company_details_TabPage8;
		public UpgradeHelpers.DataGridViewFlex gdCompDocInProcess;
		private System.Windows.Forms.TabPage _tab_company_details_TabPage9;
		public UpgradeHelpers.DataGridViewFlex grd_pubs;
		private System.Windows.Forms.CheckBox _chk_comp_product_code_7;
		private System.Windows.Forms.TabPage _tab_company_details_TabPage10;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_company_details;
		private System.Windows.Forms.CheckBox _chk_company_flag_1;
		public System.Windows.Forms.CheckBox chkCompDoNotSendEMail;
		public System.Windows.Forms.TextBox txt_comp_name;
		private System.Windows.Forms.CheckBox _chk_company_flag_0;
		public System.Windows.Forms.ComboBox cbo_comp_name_alt_type;
		public System.Windows.Forms.TextBox txt_comp_email_address;
		public System.Windows.Forms.TextBox txt_comp_name_alt;
		public System.Windows.Forms.Button cmd_company_add_note;
		public System.Windows.Forms.TextBox txt_history_date;
		public System.Windows.Forms.Button cmd_company_save;
		public System.Windows.Forms.TextBox txt_comp_web_address;
		public System.Windows.Forms.ComboBox cbo_comp_timezone;
		public System.Windows.Forms.TextBox txt_comp_city;
		public System.Windows.Forms.TextBox txt_comp_address1;
		public System.Windows.Forms.TextBox txt_comp_id;
		public System.Windows.Forms.TextBox txt_comp_zip_code;
		public System.Windows.Forms.ComboBox cbo_comp_state;
		public System.Windows.Forms.TextBox txt_comp_address2;
		public System.Windows.Forms.ComboBox cbo_comp_country;
		public System.Windows.Forms.CheckBox chk_dont_color_confirm;
		public System.Windows.Forms.Timer time_ac_timer;
		public System.Windows.Forms.Timer time_cc_timer;
		public System.Windows.Forms.Timer time_at_company;
		public System.Windows.Forms.Button cmd_company_name_change_cancel;
		public System.Windows.Forms.TextBox txt_comp_name_change_new;
		public System.Windows.Forms.TextBox txt_comp_name_current;
		private System.Windows.Forms.Label _lbl_comp_16;
		private System.Windows.Forms.Label _lbl_comp_14;
		public System.Windows.Forms.Panel pnl_company_name_change;
		public UpgradeHelpers.DataGridViewFlex grd_company_phone;
		public System.Windows.Forms.CheckBox chk_comp_pnum_hide_customer;
		public System.Windows.Forms.Button cmd_company_phone_confirm;
		public System.Windows.Forms.TextBox txt_pnum_prefix;
		public System.Windows.Forms.ComboBox cbo_comp_pnum_type;
		public System.Windows.Forms.Button cmd_company_phone_cancel;
		public System.Windows.Forms.TextBox txt_pnum_cntry_code;
		public System.Windows.Forms.TextBox txt_pnum_number;
		public System.Windows.Forms.TextBox txt_pnum_area_code;
		public System.Windows.Forms.Button cmd_company_phone_save;
		private System.Windows.Forms.Label _lbl_comp_45;
		private System.Windows.Forms.Label _lbl_comp_24;
		private System.Windows.Forms.Label _lbl_comp_52;
		private System.Windows.Forms.Label _lbl_comp_25;
		private System.Windows.Forms.Label _lbl_comp_53;
		public System.Windows.Forms.GroupBox frame_comp_phone;
		private System.Windows.Forms.Label _lbl_test_omg3_3;
		private System.Windows.Forms.Label _lbl_comp_64;
		public System.Windows.Forms.Label lbl_Time;
		public System.Windows.Forms.Label lbl_message;
		private System.Windows.Forms.Label _lbl_comp_55;
		private System.Windows.Forms.Label _lbl_comp_63;
		private System.Windows.Forms.Label _lbl_comp_23;
		private System.Windows.Forms.Label _lbl_comp_26;
		private System.Windows.Forms.Label _lbl_comp_0;
		private System.Windows.Forms.Label _lbl_comp_66;
		private System.Windows.Forms.Label _lbl_comp_65;
		private System.Windows.Forms.Label _lbl_comp_76;
		public System.Windows.Forms.Panel pnl_company_main;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button1;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button2;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button3;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button4;
		public System.Windows.Forms.ToolStrip tbr_ToolBar;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_0;
		private System.Windows.Forms.Label _lbl_comp_6;
		private System.Windows.Forms.Label _lbl_comp_10;
		private System.Windows.Forms.Label _lbl_comp_39;
		private System.Windows.Forms.Label _lbl_comp_11;
		private System.Windows.Forms.Label _lbl_comp_13;
		private System.Windows.Forms.Label _lbl_comp_28;
		private System.Windows.Forms.Label _lbl_comp_44;
		private System.Windows.Forms.Label _lbl_comp_3;
		private System.Windows.Forms.Label _lbl_comp_22;
		private System.Windows.Forms.Label _lbl_comp_5;
		private System.Windows.Forms.Label _lbl_comp_7;
		private UpgradeHelpers.Gui.ShapeHelper _shp_Shape_0;
		public UpgradeHelpers.Gui.ShapeHelper Shape2;
		private System.Windows.Forms.Label _lbl_comp_87;
		private System.Windows.Forms.Label _lbl_comp_61;
		public System.Windows.Forms.ComboBox cbo_comp_services_used;
		public System.Windows.Forms.ListBox lst_business_types;
		public System.Windows.Forms.Button cmd_edit_business_types;
		public System.Windows.Forms.ComboBox cbo_comp_govsub_code;
		public System.Windows.Forms.ComboBox cbo_comp_business_type;
		public System.Windows.Forms.ComboBox cbo_comp_agency_type;
		public System.Windows.Forms.ComboBox cbo_comp_language;
		public System.Windows.Forms.TextBox txt_comp_dunnandbrad;
		public System.Windows.Forms.TextBox txt_comp_sic_code;
		private System.Windows.Forms.CheckBox _chk_comp_product_code_0;
		private System.Windows.Forms.CheckBox _chk_comp_product_code_1;
		private System.Windows.Forms.CheckBox _chk_comp_product_code_2;
		private System.Windows.Forms.CheckBox _chk_comp_product_code_3;
		private System.Windows.Forms.CheckBox _chk_comp_product_code_4;
		private System.Windows.Forms.CheckBox _chk_comp_product_code_5;
		private System.Windows.Forms.Label _lbl_comp_115;
		private System.Windows.Forms.Label _lbl_comp_116;
		private System.Windows.Forms.Label _lbl_test_omg3_0;
		public System.Windows.Forms.CheckBox chk_include_on_ac_pros;
		public System.Windows.Forms.TextBox txt_comp_description;
		private System.Windows.Forms.TextBox _txt_company_field_4;
		private System.Windows.Forms.TabPage _tab_comp_description_TabPage0;
		public System.Windows.Forms.ComboBox cbo_comp_fractowr_contact_id;
		public System.Windows.Forms.TextBox txt_comp_fractowr_notes;
		public System.Windows.Forms.TextBox txt_comp_fractowr_id;
		private System.Windows.Forms.Label _lbl_comp_54;
		public System.Windows.Forms.Panel pnl_fractional_owner;
		private System.Windows.Forms.TabPage _tab_comp_description_TabPage1;
		public System.Windows.Forms.Button cmd_Edit_Comp_Description;
		private System.Windows.Forms.TabPage _tab_comp_description_TabPage2;
		public System.Windows.Forms.PictureBox company_logo;
		public System.Windows.Forms.Button cmd_delete_logo;
		private System.Windows.Forms.TabPage _tab_comp_description_TabPage3;
		private System.Windows.Forms.Label _lbl_comp_114;
		private System.Windows.Forms.Label _lbl_comp_18;
		private System.Windows.Forms.TabPage _tab_comp_description_TabPage4;
		private System.Windows.Forms.TextBox _txt_market_note_4;
		private System.Windows.Forms.TabPage _tab_comp_description_TabPage5;
		private System.Windows.Forms.Label _lbl_comp_12;
		private System.Windows.Forms.TextBox _txt_market_note_6;
		private System.Windows.Forms.TabPage _tab_comp_description_TabPage6;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_comp_description;
		private System.Windows.Forms.Button _cmd_company_button_0;
		private System.Windows.Forms.Button _cmd_company_button_1;
		private System.Windows.Forms.TabPage _tab_company_admin_TabPage0;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_1;
		private System.Windows.Forms.Label _lbl_comp_38;
		private System.Windows.Forms.Label _lbl_comp_27;
		private System.Windows.Forms.Label _lbl_comp_57;
		private System.Windows.Forms.Label _lbl_comp_72;
		private System.Windows.Forms.Label _lbl_comp_71;
		private System.Windows.Forms.Label _lbl_comp_58;
		private System.Windows.Forms.Label _lbl_comp_60;
		private System.Windows.Forms.Label _lbl_comp_59;
		private System.Windows.Forms.Label _lbl_comp_8;
		private System.Windows.Forms.Label _lbl_comp_98;
		private System.Windows.Forms.Label _lbl_comp_103;
		private System.Windows.Forms.Label _lbl_comp_105;
		private System.Windows.Forms.Label _lbl_comp_112;
		private System.Windows.Forms.Label _lbl_comp_113;
		public System.Windows.Forms.MonthCalendar cal_comp_callback_date;
		private System.Windows.Forms.Button _cmd_company_update_callback_date_0;
		public System.Windows.Forms.CheckBox chk_company_assign_flag;
		private System.Windows.Forms.ComboBox _cbo_comp_account_0;
		public System.Windows.Forms.MonthCalendar cal_comp_yacht_callback_date;
		private System.Windows.Forms.ComboBox _cbo_comp_account_1;
		private System.Windows.Forms.ComboBox _cbo_comp_account_2;
		public System.Windows.Forms.CheckBox chkCompContactAddressFlag;
		private System.Windows.Forms.Button _cmd_company_update_callback_date_1;
		private System.Windows.Forms.ComboBox _cbo_comp_account_6;
		private System.Windows.Forms.TextBox _txt_company_field_0;
		private System.Windows.Forms.TextBox _txt_company_field_1;
		private System.Windows.Forms.TextBox _txt_company_field_3;
		private System.Windows.Forms.CheckBox _chk_array_6;
		private System.Windows.Forms.TabPage _tab_company_admin_TabPage1;
		public System.Windows.Forms.TextBox txt_extra_research_note;
		public System.Windows.Forms.Button cmd_company_clear_research_note;
		public System.Windows.Forms.Panel pnl_research_notes;
		public System.Windows.Forms.ListBox lst_research_notes;
		private System.Windows.Forms.Label _lbl_test_omg3_2;
		private System.Windows.Forms.Label _lbl_comp_78;
		private System.Windows.Forms.Label _lbl_comp_41;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_2;
		private System.Windows.Forms.TabPage _tab_company_admin_TabPage2;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_3;
		private System.Windows.Forms.Label _lbl_comp_31;
		private System.Windows.Forms.Label _lbl_comp_56;
		private System.Windows.Forms.Label _lbl_comp_20;
		private System.Windows.Forms.Label _lbl_comp_42;
		private System.Windows.Forms.Label _lbl_comp_82;
		public UpgradeHelpers.DataGridViewFlex grd_company_history;
		public System.Windows.Forms.TextBox txt_historical_ac_description;
		private System.Windows.Forms.Button _cmdCompHistoryTab_0;
		private System.Windows.Forms.Button _cmdCompHistoryTab_1;
		private System.Windows.Forms.TabPage _tab_company_admin_TabPage3;
		private System.Windows.Forms.Button _cmd_relationship_buttons_4;
		private System.Windows.Forms.Button _cmd_relationship_buttons_3;
		private System.Windows.Forms.Button _cmd_relationship_buttons_2;
		private System.Windows.Forms.Button _cmd_relationship_buttons_1;
		private System.Windows.Forms.ComboBox _cbo_comp_account_4;
		private System.Windows.Forms.ComboBox _cbo_comp_account_3;
		public UpgradeHelpers.DataGridViewFlex grd_company_relationships;
		private System.Windows.Forms.TabPage _tab_company_rel_TabPage0;
		public UpgradeHelpers.DataGridViewFlex grd_company_contact_relationships;
		private System.Windows.Forms.TabPage _tab_company_rel_TabPage1;
		public UpgradeHelpers.DataGridViewFlex grdCompDupByAdd;
		private System.Windows.Forms.TabPage _tab_company_rel_TabPage2;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_company_rel;
		public System.Windows.Forms.ListBox lst_related_contact;
		public System.Windows.Forms.ComboBox cbo_related_company_contact;
		public System.Windows.Forms.CheckBox chk_internal_relation;
		public System.Windows.Forms.ListBox lst_related_company;
		private System.Windows.Forms.Button _cmd_relationship_buttons_0;
		private System.Windows.Forms.Label _lbl_comp_100;
		private System.Windows.Forms.Label _lbl_comp_99;
		private System.Windows.Forms.Label _lbl_comp_74;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_4;
		private System.Windows.Forms.TabPage _tab_company_admin_TabPage4;
		public System.Windows.Forms.ListBox lst_abi_services;
		public System.Windows.Forms.Button cmd_company_update_stats;
		public UpgradeHelpers.DataGridViewFlex grd_company_stats;
		private System.Windows.Forms.Label _lbl_comp_19;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_5;
		private System.Windows.Forms.TabPage _tab_company_admin_TabPage5;
		private UpgradeHelpers.Gui.ShapeHelper _shp_dealer_background_6;
		private System.Windows.Forms.Label _lbl_comp_92;
		public UpgradeHelpers.DataGridViewFlex grd_company_cert;
		private System.Windows.Forms.ComboBox _cert_combo_drop_down_1;
		private System.Windows.Forms.ComboBox _cert_combo_drop_down_0;
		public System.Windows.Forms.TextBox cert_number_textbox;
		public System.Windows.Forms.TextBox cert_name_textbox;
		public System.Windows.Forms.TextBox cert_note_textbox;
		private System.Windows.Forms.Button _cmdCertCommand_3;
		private System.Windows.Forms.Button _cmdCertCommand_2;
		private System.Windows.Forms.Button _cmdCertCommand_1;
		private System.Windows.Forms.Button _cmdCertCommand_0;
		private System.Windows.Forms.Label _lbl_comp_30;
		private System.Windows.Forms.Label _lbl_comp_73;
		public System.Windows.Forms.Label lbl_company_cert_id_label;
		private System.Windows.Forms.Label _lbl_comp_96;
		private System.Windows.Forms.Label _lbl_comp_94;
		private System.Windows.Forms.Label _lbl_comp_95;
		private System.Windows.Forms.Label _lbl_comp_93;
		public System.Windows.Forms.GroupBox cert_edit_enter_frame;
		private System.Windows.Forms.Button _cmdCertCommand_4;
		private System.Windows.Forms.TabPage _tab_company_admin_TabPage6;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_company_admin;
		private System.Windows.Forms.CheckBox _chk_array_4;
		private System.Windows.Forms.CheckBox _chk_array_3;
		private System.Windows.Forms.CheckBox _chk_array_2;
		private System.Windows.Forms.CheckBox _chk_array_1;
		private System.Windows.Forms.RadioButton _opt_journal_subject_1;
		private System.Windows.Forms.RadioButton _opt_journal_subject_2;
		private System.Windows.Forms.RadioButton _opt_journal_subject_3;
		private System.Windows.Forms.RadioButton _opt_journal_subject_0;
		private System.Windows.Forms.RadioButton _opt_journal_subject_4;
		public System.Windows.Forms.GroupBox frame_options1;
		private System.Windows.Forms.TextBox _txt_market_note_3;
		public System.Windows.Forms.TextBox txt_marketing_notes;
		public System.Windows.Forms.GroupBox frm_marketing_note;
		public System.Windows.Forms.ListBox lst_aircraft;
		private System.Windows.Forms.RadioButton _opt_verify_aircraft_5;
		public System.Windows.Forms.Button cmd_verify_status_save;
		private System.Windows.Forms.Button _cmd_verify_yacht_2;
		private System.Windows.Forms.RadioButton _opt_journal_subject_12;
		private System.Windows.Forms.RadioButton _opt_journal_subject_13;
		private System.Windows.Forms.RadioButton _opt_journal_subject_11;
		private System.Windows.Forms.RadioButton _opt_journal_subject_10;
		public System.Windows.Forms.GroupBox frame_verify_pnl;
		public System.Windows.Forms.ComboBox cbo_yachts;
		private System.Windows.Forms.RadioButton _opt_verify_aircraft_4;
		public System.Windows.Forms.ComboBox cbo_verify_note_type;
		private System.Windows.Forms.RadioButton _opt_verify_aircraft_3;
		private System.Windows.Forms.RadioButton _opt_verify_aircraft_2;
		private System.Windows.Forms.RadioButton _opt_verify_aircraft_1;
		private System.Windows.Forms.RadioButton _opt_verify_aircraft_0;
		public System.Windows.Forms.ComboBox cbo_verify_aircraft;
		public System.Windows.Forms.CheckBox chk_verify_contact;
		public System.Windows.Forms.Button cmd_verify_status_cancel;
		public System.Windows.Forms.ComboBox cbo_verify_other_contacts;
		private System.Windows.Forms.PictureBox _pic_verify_ac_1;
		private System.Windows.Forms.PictureBox _pic_verify_ac_0;
		private System.Windows.Forms.PictureBox _pic_verify_ac_3;
		private System.Windows.Forms.PictureBox _pic_verify_ac_2;
		public System.Windows.Forms.ComboBox cbo_verify_journal_auto_subject;
		public System.Windows.Forms.ComboBox cbo_verify_journal_subject;
		private System.Windows.Forms.Label _lbl_comp_104;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_3;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_2;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_1;
		private System.Windows.Forms.Label _lbl_comp_49;
		private System.Windows.Forms.Label _lbl_comp_17;
		private System.Windows.Forms.Label _lbl_comp_46;
		private System.Windows.Forms.Label _lbl_comp_48;
		private System.Windows.Forms.Label _lbl_comp_47;
		private System.Windows.Forms.Label _lbl_comp_75;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_0;
		public System.Windows.Forms.Panel pnl_verify_aircraft_status;
		private System.Windows.Forms.Label _lbl_comp_40;
		public System.Windows.Forms.Panel pnl_update_message;
		public UpgradeHelpers.Gui.ShapeHelper[] Shape1 = new UpgradeHelpers.Gui.ShapeHelper[4];
		public System.Windows.Forms.Button[] btn_array = new System.Windows.Forms.Button[4];
		public System.Windows.Forms.ComboBox[] cbo_comp_account = new System.Windows.Forms.ComboBox[7];
		public System.Windows.Forms.ComboBox[] cert_combo_drop_down = new System.Windows.Forms.ComboBox[2];
		public System.Windows.Forms.CheckBox[] chk_array = new System.Windows.Forms.CheckBox[7];
		public System.Windows.Forms.CheckBox[] chk_comp_product_code = new System.Windows.Forms.CheckBox[8];
		public System.Windows.Forms.CheckBox[] chk_company_flag = new System.Windows.Forms.CheckBox[2];
		public System.Windows.Forms.Button[] cmdCertCommand = new System.Windows.Forms.Button[6];
		public System.Windows.Forms.Button[] cmdCompHistoryTab = new System.Windows.Forms.Button[2];
		public System.Windows.Forms.Button[] cmd_ac_verify = new System.Windows.Forms.Button[8];
		public System.Windows.Forms.Button[] cmd_company_button = new System.Windows.Forms.Button[2];
		public System.Windows.Forms.Button[] cmd_company_update_callback_date = new System.Windows.Forms.Button[2];
		public System.Windows.Forms.Button[] cmd_relationship_buttons = new System.Windows.Forms.Button[5];
		public System.Windows.Forms.Button[] cmd_verify_yacht = new System.Windows.Forms.Button[7];
		public System.Windows.Forms.Button[] cmd_wanted_save = new System.Windows.Forms.Button[4];
		public System.Windows.Forms.Label[] lbl_comp = new System.Windows.Forms.Label[301];
		public System.Windows.Forms.Label[] lbl_test_omg3 = new System.Windows.Forms.Label[4];
		public System.Windows.Forms.ToolStripItem[] mnuReportList = new System.Windows.Forms.ToolStripItem[8];
		public System.Windows.Forms.ToolStripItem[] mnuViewJournalSubType = new System.Windows.Forms.ToolStripItem[4];
		public System.Windows.Forms.RadioButton[] opt_journal_subject = new System.Windows.Forms.RadioButton[14];
		public System.Windows.Forms.RadioButton[] opt_verify_aircraft = new System.Windows.Forms.RadioButton[6];
		public System.Windows.Forms.PictureBox[] pic_verify_ac = new System.Windows.Forms.PictureBox[4];
		public UpgradeHelpers.Gui.ShapeHelper[] shp_Shape = new UpgradeHelpers.Gui.ShapeHelper[2];
		public UpgradeHelpers.Gui.ShapeHelper[] shp_dealer_background = new UpgradeHelpers.Gui.ShapeHelper[14];
		public System.Windows.Forms.TextBox[] txt_company_field = new System.Windows.Forms.TextBox[5];
		public System.Windows.Forms.TextBox[] txt_gen = new System.Windows.Forms.TextBox[9];
		public System.Windows.Forms.TextBox[] txt_market_note = new System.Windows.Forms.TextBox[8];
		public System.Windows.Forms.ContextMenuStrip Ctx_mnuTools;
		public System.Windows.Forms.ContextMenuStrip Ctx_mnuRightClickAircraft;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public UpgradeHelpers.Gui.Controls.ListControlHelper listBoxComboBoxHelper1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		private int tab_company_adminPreviousTab;
		private int tab_company_relPreviousTab;
		private int tab_company_detailsPreviousTab;
		private int tab_comp_descriptionPreviousTab;
		public System.ComponentModel.ComponentResourceManager resources;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Company));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnufile = new System.Windows.Forms.ToolStripMenuItem();
			mnufileclose = new System.Windows.Forms.ToolStripMenuItem();
			mnufilelogout = new System.Windows.Forms.ToolStripMenuItem();
			mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
			mnueditaddcompany = new System.Windows.Forms.ToolStripMenuItem();
			mnueditaddcompanyphone = new System.Windows.Forms.ToolStripMenuItem();
			mnueditremovecompanyphone = new System.Windows.Forms.ToolStripMenuItem();
			mnuRemoveDupContacts = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditAddFractional = new System.Windows.Forms.ToolStripMenuItem();
			mnuRemoveFractional = new System.Windows.Forms.ToolStripMenuItem();
			mnuSurveyResponse = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditCompMailingList = new System.Windows.Forms.ToolStripMenuItem();
			mnuAddCompPub = new System.Windows.Forms.ToolStripMenuItem();
			mnuAddCompanyDocument = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditTransmitCompanyRecord = new System.Windows.Forms.ToolStripMenuItem();
			mnuView = new System.Windows.Forms.ToolStripMenuItem();
			mnuViewBadEmails = new System.Windows.Forms.ToolStripMenuItem();
			mnuViewJournalType = new System.Windows.Forms.ToolStripMenuItem();
			_mnuViewJournalSubType_1 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuViewJournalSubType_2 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuViewJournalSubType_3 = new System.Windows.Forms.ToolStripMenuItem();
			ViewCompany = new System.Windows.Forms.ToolStripMenuItem();
			mnusoldprices = new System.Windows.Forms.ToolStripMenuItem();
			mnuReport = new System.Windows.Forms.ToolStripMenuItem();
			_mnuReportList_0 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuReportList_1 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuReportList_2 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuReportList_3 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuReportList_4 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuReportList_5 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuReportList_6 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuReportList_7 = new System.Windows.Forms.ToolStripMenuItem();
			mnuReportDeliveryPositionReport = new System.Windows.Forms.ToolStripMenuItem();
			mnuReportInOperationReport = new System.Windows.Forms.ToolStripMenuItem();
			mnuSubscriptions = new System.Windows.Forms.ToolStripMenuItem();
			mnuACSearch = new System.Windows.Forms.ToolStripMenuItem();
			mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			mnuCompanyDialPhoneNumber = new System.Windows.Forms.ToolStripMenuItem();
			mnuCompanyShowUserHistory = new System.Windows.Forms.ToolStripMenuItem();
			mnuRightClickAircraft = new System.Windows.Forms.ToolStripMenuItem();
			mnuConfirmACBase = new System.Windows.Forms.ToolStripMenuItem();
			mnuMassConfirmACBase = new System.Windows.Forms.ToolStripMenuItem();
			mnuConfirmACReg = new System.Windows.Forms.ToolStripMenuItem();
			mnuMassConfirmACReg = new System.Windows.Forms.ToolStripMenuItem();
			mnuChangeBusinessType = new System.Windows.Forms.ToolStripMenuItem();
			mnuChangeBusinessTypeOnAllReferences = new System.Windows.Forms.ToolStripMenuItem();
			mnuChangeBusinessTypeOnAllAircraft = new System.Windows.Forms.ToolStripMenuItem();
			mnuShowExclusiveBroker = new System.Windows.Forms.ToolStripMenuItem();
			mnuShowOwner = new System.Windows.Forms.ToolStripMenuItem();
			mnuConfirmManagement = new System.Windows.Forms.ToolStripMenuItem();
			mnuConfirmCharter = new System.Windows.Forms.ToolStripMenuItem();
			mnuConfirnManCharter = new System.Windows.Forms.ToolStripMenuItem();
			mnuShowExtra = new System.Windows.Forms.ToolStripMenuItem();
			mnuRightClickYacht = new System.Windows.Forms.ToolStripMenuItem();
			mnuShowCentralAgent = new System.Windows.Forms.ToolStripMenuItem();
			tab_company_details = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_company_details_TabPage0 = new System.Windows.Forms.TabPage();
			_lbl_test_omg3_1 = new System.Windows.Forms.Label();
			_lbl_comp_15 = new System.Windows.Forms.Label();
			_shp_Shape_1 = new UpgradeHelpers.Gui.ShapeHelper();
			_lbl_comp_62 = new System.Windows.Forms.Label();
			_lbl_comp_51 = new System.Windows.Forms.Label();
			_lbl_comp_4 = new System.Windows.Forms.Label();
			_shp_dealer_background_7 = new UpgradeHelpers.Gui.ShapeHelper();
			grd_company_aircraft = new UpgradeHelpers.DataGridViewFlex(components);
			chk_view_eu = new System.Windows.Forms.CheckBox();
			_cmd_ac_verify_7 = new System.Windows.Forms.Button();
			_cmd_ac_verify_6 = new System.Windows.Forms.Button();
			_cmd_ac_verify_5 = new System.Windows.Forms.Button();
			_cmd_ac_verify_4 = new System.Windows.Forms.Button();
			_cmd_ac_verify_3 = new System.Windows.Forms.Button();
			_cmd_ac_verify_2 = new System.Windows.Forms.Button();
			_cmd_ac_verify_1 = new System.Windows.Forms.Button();
			_cmd_ac_verify_0 = new System.Windows.Forms.Button();
			cbo_comp_purchase_question = new System.Windows.Forms.ComboBox();
			cbo_ac_delivery_position = new System.Windows.Forms.ComboBox();
			_txt_gen_7 = new System.Windows.Forms.TextBox();
			_txt_gen_6 = new System.Windows.Forms.TextBox();
			chk_change_same_ac_contact_type_only = new System.Windows.Forms.CheckBox();
			_txt_gen_0 = new System.Windows.Forms.TextBox();
			_txt_gen_5 = new System.Windows.Forms.TextBox();
			_txt_gen_2 = new System.Windows.Forms.TextBox();
			lst_aircraft_contact = new System.Windows.Forms.ListBox();
			_txt_gen_4 = new System.Windows.Forms.TextBox();
			_txt_gen_1 = new System.Windows.Forms.TextBox();
			cbo_company_research_contact = new System.Windows.Forms.ComboBox();
			cmd_aircraft_all_contact_change = new System.Windows.Forms.Button();
			cmd_aircraft_contact_change = new System.Windows.Forms.Button();
			_txt_gen_3 = new System.Windows.Forms.TextBox();
			_txt_gen_8 = new System.Windows.Forms.TextBox();
			txt_only_show_first_aircraft_recs = new System.Windows.Forms.TextBox();
			chk_limit_aircraft_list = new System.Windows.Forms.CheckBox();
			txt_total_aircraft = new System.Windows.Forms.TextBox();
			_tab_company_details_TabPage1 = new System.Windows.Forms.TabPage();
			_lbl_comp_35 = new System.Windows.Forms.Label();
			_lbl_comp_97 = new System.Windows.Forms.Label();
			_lbl_comp_86 = new System.Windows.Forms.Label();
			_lbl_comp_85 = new System.Windows.Forms.Label();
			_shp_dealer_background_8 = new UpgradeHelpers.Gui.ShapeHelper();
			_lbl_comp_109 = new System.Windows.Forms.Label();
			grd_company_contacts = new UpgradeHelpers.DataGridViewFlex(components);
			pnl_company_contact_details = new System.Windows.Forms.Panel();
			chk_contact_research_flag = new System.Windows.Forms.CheckBox();
			chk_contact_active_flag = new System.Windows.Forms.CheckBox();
			txt_contact_description = new System.Windows.Forms.TextBox();
			cbo_contact_suffix = new System.Windows.Forms.ComboBox();
			txt_contact_last_name = new System.Windows.Forms.TextBox();
			txt_contact_middle_initial = new System.Windows.Forms.TextBox();
			txt_contact_first_name = new System.Windows.Forms.TextBox();
			txt_contact_email_address = new System.Windows.Forms.TextBox();
			cbo_contact_title = new System.Windows.Forms.ComboBox();
			cbo_contact_sirname = new System.Windows.Forms.ComboBox();
			txt_contact_id = new System.Windows.Forms.TextBox();
			chk_contact_hide_flag = new System.Windows.Forms.CheckBox();
			cmd_EditMailList = new System.Windows.Forms.Button();
			cmbContactEMail = new System.Windows.Forms.ComboBox();
			_btn_array_0 = new System.Windows.Forms.Button();
			_btn_array_1 = new System.Windows.Forms.Button();
			_txt_market_note_5 = new System.Windows.Forms.TextBox();
			grd_contact_phone_numbers = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_comp_68 = new System.Windows.Forms.Label();
			_lbl_comp_67 = new System.Windows.Forms.Label();
			_lbl_comp_69 = new System.Windows.Forms.Label();
			_lbl_comp_300 = new System.Windows.Forms.Label();
			_lbl_comp_77 = new System.Windows.Forms.Label();
			_lbl_comp_91 = new System.Windows.Forms.Label();
			_lbl_comp_1 = new System.Windows.Forms.Label();
			_txt_market_note_7 = new System.Windows.Forms.TextBox();
			_chk_array_5 = new System.Windows.Forms.CheckBox();
			_btn_array_3 = new System.Windows.Forms.Button();
			_btn_array_2 = new System.Windows.Forms.Button();
			cbo_order_by = new System.Windows.Forms.ComboBox();
			cmd_contact_seq_down = new System.Windows.Forms.Button();
			cmd_contact_seq_up = new System.Windows.Forms.Button();
			_chk_array_0 = new System.Windows.Forms.CheckBox();
			_tab_company_details_TabPage2 = new System.Windows.Forms.TabPage();
			_lbl_comp_102 = new System.Windows.Forms.Label();
			_lbl_comp_50 = new System.Windows.Forms.Label();
			_lbl_comp_70 = new System.Windows.Forms.Label();
			_lbl_comp_37 = new System.Windows.Forms.Label();
			_shp_dealer_background_9 = new UpgradeHelpers.Gui.ShapeHelper();
			grd_company_journal = new UpgradeHelpers.DataGridViewFlex(components);
			txtCompJournalSearch = new System.Windows.Forms.TextBox();
			cbo_journal_note_type = new System.Windows.Forms.ComboBox();
			cmd_company_fill_journal = new System.Windows.Forms.Button();
			txt_only_show_first_journal_recs = new System.Windows.Forms.TextBox();
			chk_limit_journal_list = new System.Windows.Forms.CheckBox();
			txt_journal_ac_selected = new System.Windows.Forms.TextBox();
			_tab_company_details_TabPage3 = new System.Windows.Forms.TabPage();
			_lbl_comp_84 = new System.Windows.Forms.Label();
			_lbl_comp_83 = new System.Windows.Forms.Label();
			_shp_dealer_background_10 = new UpgradeHelpers.Gui.ShapeHelper();
			pnl_company_wanted_notes = new System.Windows.Forms.Panel();
			txt_amwant_notes = new System.Windows.Forms.TextBox();
			_lbl_comp_90 = new System.Windows.Forms.Label();
			grd_company_wanted = new UpgradeHelpers.DataGridViewFlex(components);
			pnl_company_wanted = new System.Windows.Forms.Panel();
			txt_amwant_max_aftt = new System.Windows.Forms.TextBox();
			_cmd_wanted_save_0 = new System.Windows.Forms.Button();
			txt_amwant_pricenote = new System.Windows.Forms.TextBox();
			txt_amwant_yearnote = new System.Windows.Forms.TextBox();
			txt_amwant_max_price = new System.Windows.Forms.TextBox();
			txt_amwant_end_year = new System.Windows.Forms.TextBox();
			txt_amwant_start_year = new System.Windows.Forms.TextBox();
			txt_amwant_listed_date = new System.Windows.Forms.TextBox();
			frame_wanted_accept_aircraft_with = new System.Windows.Forms.GroupBox();
			cbo_amwant_accept_damage_hist = new System.Windows.Forms.ComboBox();
			cbo_amwant_accept_damage_cur = new System.Windows.Forms.ComboBox();
			_lbl_comp_2 = new System.Windows.Forms.Label();
			_lbl_comp_36 = new System.Windows.Forms.Label();
			txt_amwant_date_verified = new System.Windows.Forms.TextBox();
			chk_amwant_date_is_verified = new System.Windows.Forms.CheckBox();
			frame_wanted_makemodel = new System.Windows.Forms.GroupBox();
			cbo_amwant_model = new System.Windows.Forms.ComboBox();
			chk_amwant_auto_distribute_flag = new System.Windows.Forms.CheckBox();
			txt_amwant_auto_distribute_email = new System.Windows.Forms.TextBox();
			txt_amwant_auto_unsuscribe_date = new System.Windows.Forms.TextBox();
			txt_amwant_auto_distribute_replyname = new System.Windows.Forms.TextBox();
			_cmd_wanted_save_1 = new System.Windows.Forms.Button();
			_cmd_wanted_save_2 = new System.Windows.Forms.Button();
			_cmd_wanted_save_3 = new System.Windows.Forms.Button();
			_lbl_comp_29 = new System.Windows.Forms.Label();
			_lbl_comp_32 = new System.Windows.Forms.Label();
			_lbl_comp_34 = new System.Windows.Forms.Label();
			_lbl_comp_33 = new System.Windows.Forms.Label();
			_lbl_comp_43 = new System.Windows.Forms.Label();
			_lbl_comp_9 = new System.Windows.Forms.Label();
			_lbl_comp_88 = new System.Windows.Forms.Label();
			_lbl_comp_89 = new System.Windows.Forms.Label();
			_lbl_comp_21 = new System.Windows.Forms.Label();
			_lbl_comp_81 = new System.Windows.Forms.Label();
			Shape3 = new UpgradeHelpers.Gui.ShapeHelper();
			chkShowAllWanted = new System.Windows.Forms.CheckBox();
			cmd_wanted_delete = new System.Windows.Forms.Button();
			cmd_wanted_add = new System.Windows.Forms.Button();
			_tab_company_details_TabPage4 = new System.Windows.Forms.TabPage();
			_shp_dealer_background_11 = new UpgradeHelpers.Gui.ShapeHelper();
			grd_company_shares = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_company_details_TabPage5 = new System.Windows.Forms.TabPage();
			_lbl_comp_101 = new System.Windows.Forms.Label();
			_shp_dealer_background_12 = new UpgradeHelpers.Gui.ShapeHelper();
			grd_company_documents = new UpgradeHelpers.DataGridViewFlex(components);
			_txt_company_field_2 = new System.Windows.Forms.TextBox();
			_cmdCertCommand_5 = new System.Windows.Forms.Button();
			_cbo_comp_account_5 = new System.Windows.Forms.ComboBox();
			_tab_company_details_TabPage6 = new System.Windows.Forms.TabPage();
			_lbl_comp_80 = new System.Windows.Forms.Label();
			_lbl_comp_79 = new System.Windows.Forms.Label();
			_shp_dealer_background_13 = new UpgradeHelpers.Gui.ShapeHelper();
			grd_company_expired_leases = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_company_details_TabPage7 = new System.Windows.Forms.TabPage();
			grd_marketing_crm_notes = new UpgradeHelpers.DataGridViewFlex(components);
			_cmd_verify_yacht_6 = new System.Windows.Forms.Button();
			_txt_market_note_0 = new System.Windows.Forms.TextBox();
			_tab_company_details_TabPage8 = new System.Windows.Forms.TabPage();
			_chk_comp_product_code_6 = new System.Windows.Forms.CheckBox();
			_tab_company_details_TabPage9 = new System.Windows.Forms.TabPage();
			gdCompDocInProcess = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_company_details_TabPage10 = new System.Windows.Forms.TabPage();
			grd_pubs = new UpgradeHelpers.DataGridViewFlex(components);
			_chk_comp_product_code_7 = new System.Windows.Forms.CheckBox();
			pnl_company_main = new System.Windows.Forms.Panel();
			_chk_company_flag_1 = new System.Windows.Forms.CheckBox();
			chkCompDoNotSendEMail = new System.Windows.Forms.CheckBox();
			txt_comp_name = new System.Windows.Forms.TextBox();
			_chk_company_flag_0 = new System.Windows.Forms.CheckBox();
			cbo_comp_name_alt_type = new System.Windows.Forms.ComboBox();
			txt_comp_email_address = new System.Windows.Forms.TextBox();
			txt_comp_name_alt = new System.Windows.Forms.TextBox();
			cmd_company_add_note = new System.Windows.Forms.Button();
			txt_history_date = new System.Windows.Forms.TextBox();
			cmd_company_save = new System.Windows.Forms.Button();
			txt_comp_web_address = new System.Windows.Forms.TextBox();
			cbo_comp_timezone = new System.Windows.Forms.ComboBox();
			txt_comp_city = new System.Windows.Forms.TextBox();
			txt_comp_address1 = new System.Windows.Forms.TextBox();
			txt_comp_id = new System.Windows.Forms.TextBox();
			txt_comp_zip_code = new System.Windows.Forms.TextBox();
			cbo_comp_state = new System.Windows.Forms.ComboBox();
			txt_comp_address2 = new System.Windows.Forms.TextBox();
			cbo_comp_country = new System.Windows.Forms.ComboBox();
			chk_dont_color_confirm = new System.Windows.Forms.CheckBox();
			time_ac_timer = new System.Windows.Forms.Timer(components);
			time_cc_timer = new System.Windows.Forms.Timer(components);
			time_at_company = new System.Windows.Forms.Timer(components);
			pnl_company_name_change = new System.Windows.Forms.Panel();
			cmd_company_name_change_cancel = new System.Windows.Forms.Button();
			txt_comp_name_change_new = new System.Windows.Forms.TextBox();
			txt_comp_name_current = new System.Windows.Forms.TextBox();
			_lbl_comp_16 = new System.Windows.Forms.Label();
			_lbl_comp_14 = new System.Windows.Forms.Label();
			grd_company_phone = new UpgradeHelpers.DataGridViewFlex(components);
			frame_comp_phone = new System.Windows.Forms.GroupBox();
			chk_comp_pnum_hide_customer = new System.Windows.Forms.CheckBox();
			cmd_company_phone_confirm = new System.Windows.Forms.Button();
			txt_pnum_prefix = new System.Windows.Forms.TextBox();
			cbo_comp_pnum_type = new System.Windows.Forms.ComboBox();
			cmd_company_phone_cancel = new System.Windows.Forms.Button();
			txt_pnum_cntry_code = new System.Windows.Forms.TextBox();
			txt_pnum_number = new System.Windows.Forms.TextBox();
			txt_pnum_area_code = new System.Windows.Forms.TextBox();
			cmd_company_phone_save = new System.Windows.Forms.Button();
			_lbl_comp_45 = new System.Windows.Forms.Label();
			_lbl_comp_24 = new System.Windows.Forms.Label();
			_lbl_comp_52 = new System.Windows.Forms.Label();
			_lbl_comp_25 = new System.Windows.Forms.Label();
			_lbl_comp_53 = new System.Windows.Forms.Label();
			_lbl_test_omg3_3 = new System.Windows.Forms.Label();
			_lbl_comp_64 = new System.Windows.Forms.Label();
			lbl_Time = new System.Windows.Forms.Label();
			lbl_message = new System.Windows.Forms.Label();
			_lbl_comp_55 = new System.Windows.Forms.Label();
			_lbl_comp_63 = new System.Windows.Forms.Label();
			_lbl_comp_23 = new System.Windows.Forms.Label();
			_lbl_comp_26 = new System.Windows.Forms.Label();
			_lbl_comp_0 = new System.Windows.Forms.Label();
			_lbl_comp_66 = new System.Windows.Forms.Label();
			_lbl_comp_65 = new System.Windows.Forms.Label();
			_lbl_comp_76 = new System.Windows.Forms.Label();
			tbr_ToolBar = new System.Windows.Forms.ToolStrip();
			tbr_ToolBar_Buttons_Button1 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button2 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button3 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button4 = new System.Windows.Forms.ToolStripButton();
			tab_company_admin = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_company_admin_TabPage0 = new System.Windows.Forms.TabPage();
			_shp_dealer_background_0 = new UpgradeHelpers.Gui.ShapeHelper();
			_lbl_comp_6 = new System.Windows.Forms.Label();
			_lbl_comp_10 = new System.Windows.Forms.Label();
			_lbl_comp_39 = new System.Windows.Forms.Label();
			_lbl_comp_11 = new System.Windows.Forms.Label();
			_lbl_comp_13 = new System.Windows.Forms.Label();
			_lbl_comp_28 = new System.Windows.Forms.Label();
			_lbl_comp_44 = new System.Windows.Forms.Label();
			_lbl_comp_3 = new System.Windows.Forms.Label();
			_lbl_comp_22 = new System.Windows.Forms.Label();
			_lbl_comp_5 = new System.Windows.Forms.Label();
			_lbl_comp_7 = new System.Windows.Forms.Label();
			_shp_Shape_0 = new UpgradeHelpers.Gui.ShapeHelper();
			Shape2 = new UpgradeHelpers.Gui.ShapeHelper();
			_lbl_comp_87 = new System.Windows.Forms.Label();
			_lbl_comp_61 = new System.Windows.Forms.Label();
			cbo_comp_services_used = new System.Windows.Forms.ComboBox();
			lst_business_types = new System.Windows.Forms.ListBox();
			cmd_edit_business_types = new System.Windows.Forms.Button();
			cbo_comp_govsub_code = new System.Windows.Forms.ComboBox();
			cbo_comp_business_type = new System.Windows.Forms.ComboBox();
			cbo_comp_agency_type = new System.Windows.Forms.ComboBox();
			cbo_comp_language = new System.Windows.Forms.ComboBox();
			txt_comp_dunnandbrad = new System.Windows.Forms.TextBox();
			txt_comp_sic_code = new System.Windows.Forms.TextBox();
			_chk_comp_product_code_0 = new System.Windows.Forms.CheckBox();
			_chk_comp_product_code_1 = new System.Windows.Forms.CheckBox();
			_chk_comp_product_code_2 = new System.Windows.Forms.CheckBox();
			_chk_comp_product_code_3 = new System.Windows.Forms.CheckBox();
			_chk_comp_product_code_4 = new System.Windows.Forms.CheckBox();
			_chk_comp_product_code_5 = new System.Windows.Forms.CheckBox();
			tab_comp_description = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_comp_description_TabPage0 = new System.Windows.Forms.TabPage();
			_lbl_comp_115 = new System.Windows.Forms.Label();
			_lbl_comp_116 = new System.Windows.Forms.Label();
			_lbl_test_omg3_0 = new System.Windows.Forms.Label();
			chk_include_on_ac_pros = new System.Windows.Forms.CheckBox();
			txt_comp_description = new System.Windows.Forms.TextBox();
			_txt_company_field_4 = new System.Windows.Forms.TextBox();
			_tab_comp_description_TabPage1 = new System.Windows.Forms.TabPage();
			pnl_fractional_owner = new System.Windows.Forms.Panel();
			cbo_comp_fractowr_contact_id = new System.Windows.Forms.ComboBox();
			txt_comp_fractowr_notes = new System.Windows.Forms.TextBox();
			txt_comp_fractowr_id = new System.Windows.Forms.TextBox();
			_lbl_comp_54 = new System.Windows.Forms.Label();
			_tab_comp_description_TabPage2 = new System.Windows.Forms.TabPage();
			cmd_Edit_Comp_Description = new System.Windows.Forms.Button();
			_tab_comp_description_TabPage3 = new System.Windows.Forms.TabPage();
			company_logo = new System.Windows.Forms.PictureBox();
			cmd_delete_logo = new System.Windows.Forms.Button();
			_tab_comp_description_TabPage4 = new System.Windows.Forms.TabPage();
			_lbl_comp_114 = new System.Windows.Forms.Label();
			_lbl_comp_18 = new System.Windows.Forms.Label();
			_tab_comp_description_TabPage5 = new System.Windows.Forms.TabPage();
			_txt_market_note_4 = new System.Windows.Forms.TextBox();
			_tab_comp_description_TabPage6 = new System.Windows.Forms.TabPage();
			_lbl_comp_12 = new System.Windows.Forms.Label();
			_txt_market_note_6 = new System.Windows.Forms.TextBox();
			_cmd_company_button_0 = new System.Windows.Forms.Button();
			_cmd_company_button_1 = new System.Windows.Forms.Button();
			_tab_company_admin_TabPage1 = new System.Windows.Forms.TabPage();
			_shp_dealer_background_1 = new UpgradeHelpers.Gui.ShapeHelper();
			_lbl_comp_38 = new System.Windows.Forms.Label();
			_lbl_comp_27 = new System.Windows.Forms.Label();
			_lbl_comp_57 = new System.Windows.Forms.Label();
			_lbl_comp_72 = new System.Windows.Forms.Label();
			_lbl_comp_71 = new System.Windows.Forms.Label();
			_lbl_comp_58 = new System.Windows.Forms.Label();
			_lbl_comp_60 = new System.Windows.Forms.Label();
			_lbl_comp_59 = new System.Windows.Forms.Label();
			_lbl_comp_8 = new System.Windows.Forms.Label();
			_lbl_comp_98 = new System.Windows.Forms.Label();
			_lbl_comp_103 = new System.Windows.Forms.Label();
			_lbl_comp_105 = new System.Windows.Forms.Label();
			_lbl_comp_112 = new System.Windows.Forms.Label();
			_lbl_comp_113 = new System.Windows.Forms.Label();
			cal_comp_callback_date = new System.Windows.Forms.MonthCalendar();
			_cmd_company_update_callback_date_0 = new System.Windows.Forms.Button();
			chk_company_assign_flag = new System.Windows.Forms.CheckBox();
			_cbo_comp_account_0 = new System.Windows.Forms.ComboBox();
			cal_comp_yacht_callback_date = new System.Windows.Forms.MonthCalendar();
			_cbo_comp_account_1 = new System.Windows.Forms.ComboBox();
			_cbo_comp_account_2 = new System.Windows.Forms.ComboBox();
			chkCompContactAddressFlag = new System.Windows.Forms.CheckBox();
			_cmd_company_update_callback_date_1 = new System.Windows.Forms.Button();
			_cbo_comp_account_6 = new System.Windows.Forms.ComboBox();
			_txt_company_field_0 = new System.Windows.Forms.TextBox();
			_txt_company_field_1 = new System.Windows.Forms.TextBox();
			_txt_company_field_3 = new System.Windows.Forms.TextBox();
			_chk_array_6 = new System.Windows.Forms.CheckBox();
			_tab_company_admin_TabPage2 = new System.Windows.Forms.TabPage();
			pnl_research_notes = new System.Windows.Forms.Panel();
			txt_extra_research_note = new System.Windows.Forms.TextBox();
			cmd_company_clear_research_note = new System.Windows.Forms.Button();
			lst_research_notes = new System.Windows.Forms.ListBox();
			_lbl_test_omg3_2 = new System.Windows.Forms.Label();
			_lbl_comp_78 = new System.Windows.Forms.Label();
			_lbl_comp_41 = new System.Windows.Forms.Label();
			_shp_dealer_background_2 = new UpgradeHelpers.Gui.ShapeHelper();
			_tab_company_admin_TabPage3 = new System.Windows.Forms.TabPage();
			_shp_dealer_background_3 = new UpgradeHelpers.Gui.ShapeHelper();
			_lbl_comp_31 = new System.Windows.Forms.Label();
			_lbl_comp_56 = new System.Windows.Forms.Label();
			_lbl_comp_20 = new System.Windows.Forms.Label();
			_lbl_comp_42 = new System.Windows.Forms.Label();
			_lbl_comp_82 = new System.Windows.Forms.Label();
			grd_company_history = new UpgradeHelpers.DataGridViewFlex(components);
			txt_historical_ac_description = new System.Windows.Forms.TextBox();
			_cmdCompHistoryTab_0 = new System.Windows.Forms.Button();
			_cmdCompHistoryTab_1 = new System.Windows.Forms.Button();
			_tab_company_admin_TabPage4 = new System.Windows.Forms.TabPage();
			_cmd_relationship_buttons_4 = new System.Windows.Forms.Button();
			_cmd_relationship_buttons_3 = new System.Windows.Forms.Button();
			_cmd_relationship_buttons_2 = new System.Windows.Forms.Button();
			_cmd_relationship_buttons_1 = new System.Windows.Forms.Button();
			_cbo_comp_account_4 = new System.Windows.Forms.ComboBox();
			_cbo_comp_account_3 = new System.Windows.Forms.ComboBox();
			tab_company_rel = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_company_rel_TabPage0 = new System.Windows.Forms.TabPage();
			grd_company_relationships = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_company_rel_TabPage1 = new System.Windows.Forms.TabPage();
			grd_company_contact_relationships = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_company_rel_TabPage2 = new System.Windows.Forms.TabPage();
			grdCompDupByAdd = new UpgradeHelpers.DataGridViewFlex(components);
			lst_related_contact = new System.Windows.Forms.ListBox();
			cbo_related_company_contact = new System.Windows.Forms.ComboBox();
			chk_internal_relation = new System.Windows.Forms.CheckBox();
			lst_related_company = new System.Windows.Forms.ListBox();
			_cmd_relationship_buttons_0 = new System.Windows.Forms.Button();
			_lbl_comp_100 = new System.Windows.Forms.Label();
			_lbl_comp_99 = new System.Windows.Forms.Label();
			_lbl_comp_74 = new System.Windows.Forms.Label();
			_shp_dealer_background_4 = new UpgradeHelpers.Gui.ShapeHelper();
			_tab_company_admin_TabPage5 = new System.Windows.Forms.TabPage();
			lst_abi_services = new System.Windows.Forms.ListBox();
			cmd_company_update_stats = new System.Windows.Forms.Button();
			grd_company_stats = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_comp_19 = new System.Windows.Forms.Label();
			_shp_dealer_background_5 = new UpgradeHelpers.Gui.ShapeHelper();
			_tab_company_admin_TabPage6 = new System.Windows.Forms.TabPage();
			_shp_dealer_background_6 = new UpgradeHelpers.Gui.ShapeHelper();
			_lbl_comp_92 = new System.Windows.Forms.Label();
			grd_company_cert = new UpgradeHelpers.DataGridViewFlex(components);
			cert_edit_enter_frame = new System.Windows.Forms.GroupBox();
			_cert_combo_drop_down_1 = new System.Windows.Forms.ComboBox();
			_cert_combo_drop_down_0 = new System.Windows.Forms.ComboBox();
			cert_number_textbox = new System.Windows.Forms.TextBox();
			cert_name_textbox = new System.Windows.Forms.TextBox();
			cert_note_textbox = new System.Windows.Forms.TextBox();
			_cmdCertCommand_3 = new System.Windows.Forms.Button();
			_cmdCertCommand_2 = new System.Windows.Forms.Button();
			_cmdCertCommand_1 = new System.Windows.Forms.Button();
			_cmdCertCommand_0 = new System.Windows.Forms.Button();
			_lbl_comp_30 = new System.Windows.Forms.Label();
			_lbl_comp_73 = new System.Windows.Forms.Label();
			lbl_company_cert_id_label = new System.Windows.Forms.Label();
			_lbl_comp_96 = new System.Windows.Forms.Label();
			_lbl_comp_94 = new System.Windows.Forms.Label();
			_lbl_comp_95 = new System.Windows.Forms.Label();
			_lbl_comp_93 = new System.Windows.Forms.Label();
			_cmdCertCommand_4 = new System.Windows.Forms.Button();
			pnl_verify_aircraft_status = new System.Windows.Forms.Panel();
			_chk_array_4 = new System.Windows.Forms.CheckBox();
			_chk_array_3 = new System.Windows.Forms.CheckBox();
			_chk_array_2 = new System.Windows.Forms.CheckBox();
			_chk_array_1 = new System.Windows.Forms.CheckBox();
			frame_options1 = new System.Windows.Forms.GroupBox();
			_opt_journal_subject_1 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_2 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_3 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_0 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_4 = new System.Windows.Forms.RadioButton();
			_txt_market_note_3 = new System.Windows.Forms.TextBox();
			frm_marketing_note = new System.Windows.Forms.GroupBox();
			txt_marketing_notes = new System.Windows.Forms.TextBox();
			lst_aircraft = new System.Windows.Forms.ListBox();
			_opt_verify_aircraft_5 = new System.Windows.Forms.RadioButton();
			cmd_verify_status_save = new System.Windows.Forms.Button();
			_cmd_verify_yacht_2 = new System.Windows.Forms.Button();
			frame_verify_pnl = new System.Windows.Forms.GroupBox();
			_opt_journal_subject_12 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_13 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_11 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_10 = new System.Windows.Forms.RadioButton();
			cbo_yachts = new System.Windows.Forms.ComboBox();
			_opt_verify_aircraft_4 = new System.Windows.Forms.RadioButton();
			cbo_verify_note_type = new System.Windows.Forms.ComboBox();
			_opt_verify_aircraft_3 = new System.Windows.Forms.RadioButton();
			_opt_verify_aircraft_2 = new System.Windows.Forms.RadioButton();
			_opt_verify_aircraft_1 = new System.Windows.Forms.RadioButton();
			_opt_verify_aircraft_0 = new System.Windows.Forms.RadioButton();
			cbo_verify_aircraft = new System.Windows.Forms.ComboBox();
			chk_verify_contact = new System.Windows.Forms.CheckBox();
			cmd_verify_status_cancel = new System.Windows.Forms.Button();
			cbo_verify_other_contacts = new System.Windows.Forms.ComboBox();
			_pic_verify_ac_1 = new System.Windows.Forms.PictureBox();
			_pic_verify_ac_0 = new System.Windows.Forms.PictureBox();
			_pic_verify_ac_3 = new System.Windows.Forms.PictureBox();
			_pic_verify_ac_2 = new System.Windows.Forms.PictureBox();
			cbo_verify_journal_auto_subject = new System.Windows.Forms.ComboBox();
			cbo_verify_journal_subject = new System.Windows.Forms.ComboBox();
			_lbl_comp_104 = new System.Windows.Forms.Label();
			_Shape1_3 = new UpgradeHelpers.Gui.ShapeHelper();
			_Shape1_2 = new UpgradeHelpers.Gui.ShapeHelper();
			_Shape1_1 = new UpgradeHelpers.Gui.ShapeHelper();
			_lbl_comp_49 = new System.Windows.Forms.Label();
			_lbl_comp_17 = new System.Windows.Forms.Label();
			_lbl_comp_46 = new System.Windows.Forms.Label();
			_lbl_comp_48 = new System.Windows.Forms.Label();
			_lbl_comp_47 = new System.Windows.Forms.Label();
			_lbl_comp_75 = new System.Windows.Forms.Label();
			_Shape1_0 = new UpgradeHelpers.Gui.ShapeHelper();
			pnl_update_message = new System.Windows.Forms.Panel();
			_lbl_comp_40 = new System.Windows.Forms.Label();
			tab_company_details.SuspendLayout();
			_tab_company_details_TabPage0.SuspendLayout();
			_tab_company_details_TabPage1.SuspendLayout();
			pnl_company_contact_details.SuspendLayout();
			_tab_company_details_TabPage2.SuspendLayout();
			_tab_company_details_TabPage3.SuspendLayout();
			pnl_company_wanted_notes.SuspendLayout();
			pnl_company_wanted.SuspendLayout();
			frame_wanted_accept_aircraft_with.SuspendLayout();
			frame_wanted_makemodel.SuspendLayout();
			_tab_company_details_TabPage4.SuspendLayout();
			_tab_company_details_TabPage5.SuspendLayout();
			_tab_company_details_TabPage6.SuspendLayout();
			_tab_company_details_TabPage7.SuspendLayout();
			_tab_company_details_TabPage8.SuspendLayout();
			_tab_company_details_TabPage9.SuspendLayout();
			_tab_company_details_TabPage10.SuspendLayout();
			pnl_company_main.SuspendLayout();
			pnl_company_name_change.SuspendLayout();
			frame_comp_phone.SuspendLayout();
			tbr_ToolBar.SuspendLayout();
			tab_company_admin.SuspendLayout();
			_tab_company_admin_TabPage0.SuspendLayout();
			tab_comp_description.SuspendLayout();
			_tab_comp_description_TabPage0.SuspendLayout();
			_tab_comp_description_TabPage1.SuspendLayout();
			pnl_fractional_owner.SuspendLayout();
			_tab_comp_description_TabPage2.SuspendLayout();
			_tab_comp_description_TabPage3.SuspendLayout();
			_tab_comp_description_TabPage4.SuspendLayout();
			_tab_comp_description_TabPage5.SuspendLayout();
			_tab_comp_description_TabPage6.SuspendLayout();
			_tab_company_admin_TabPage1.SuspendLayout();
			_tab_company_admin_TabPage2.SuspendLayout();
			pnl_research_notes.SuspendLayout();
			_tab_company_admin_TabPage3.SuspendLayout();
			_tab_company_admin_TabPage4.SuspendLayout();
			tab_company_rel.SuspendLayout();
			_tab_company_rel_TabPage0.SuspendLayout();
			_tab_company_rel_TabPage1.SuspendLayout();
			_tab_company_rel_TabPage2.SuspendLayout();
			_tab_company_admin_TabPage5.SuspendLayout();
			_tab_company_admin_TabPage6.SuspendLayout();
			cert_edit_enter_frame.SuspendLayout();
			pnl_verify_aircraft_status.SuspendLayout();
			frame_options1.SuspendLayout();
			frm_marketing_note.SuspendLayout();
			frame_verify_pnl.SuspendLayout();
			pnl_update_message.SuspendLayout();
			SuspendLayout();
			//Ctx_mnuTools
			Ctx_mnuTools = new System.Windows.Forms.ContextMenuStrip(components);
			Ctx_mnuTools.Size = new System.Drawing.Size(153, 26);
			Ctx_mnuTools.Opening += new System.ComponentModel.CancelEventHandler(Ctx_mnuTools_Opening);
			Ctx_mnuTools.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(Ctx_mnuTools_Closed);
			//Ctx_mnuRightClickAircraft
			Ctx_mnuRightClickAircraft = new System.Windows.Forms.ContextMenuStrip(components);
			Ctx_mnuRightClickAircraft.Size = new System.Drawing.Size(153, 26);
			Ctx_mnuRightClickAircraft.Opening += new System.ComponentModel.CancelEventHandler(Ctx_mnuRightClickAircraft_Opening);
			Ctx_mnuRightClickAircraft.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(Ctx_mnuRightClickAircraft_Closed);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			listBoxComboBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListControlHelper(components);
			((System.ComponentModel.ISupportInitialize) listBoxComboBoxHelper1).BeginInit();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_company_aircraft).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_company_contacts).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_contact_phone_numbers).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_company_journal).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_company_wanted).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_company_shares).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_company_documents).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_company_expired_leases).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_marketing_crm_notes).BeginInit();
			((System.ComponentModel.ISupportInitialize) gdCompDocInProcess).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_pubs).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_company_phone).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_company_history).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_company_relationships).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_company_contact_relationships).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdCompDupByAdd).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_company_stats).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_company_cert).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnufile, mnuEdit, mnuView, mnuReport, mnuSubscriptions, mnuACSearch, mnuTools, mnuRightClickAircraft, mnuRightClickYacht});
			// 
			// mnufile
			// 
			mnufile.Available = true;
			mnufile.Checked = false;
			mnufile.Enabled = true;
			mnufile.Name = "mnufile";
			mnufile.Text = "&File";
			mnufile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnufileclose, mnufilelogout});
			// 
			// mnufileclose
			// 
			mnufileclose.Available = true;
			mnufileclose.Checked = false;
			mnufileclose.Enabled = true;
			mnufileclose.Name = "mnufileclose";
			mnufileclose.Text = "Close";
			mnufileclose.Click += new System.EventHandler(mnuFileClose_Click);
			// 
			// mnufilelogout
			// 
			mnufilelogout.Available = true;
			mnufilelogout.Checked = false;
			mnufilelogout.Enabled = true;
			mnufilelogout.Name = "mnufilelogout";
			mnufilelogout.Text = "Logout";
			mnufilelogout.Click += new System.EventHandler(mnuFileLogout_Click);
			// 
			// mnuEdit
			// 
			mnuEdit.Available = true;
			mnuEdit.Checked = false;
			mnuEdit.Enabled = true;
			mnuEdit.Name = "mnuEdit";
			mnuEdit.Text = "&Edit";
			mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnueditaddcompany, mnueditaddcompanyphone, mnueditremovecompanyphone, mnuRemoveDupContacts, mnuEditAddFractional, mnuRemoveFractional, mnuSurveyResponse, mnuEditCompMailingList, mnuAddCompPub, mnuAddCompanyDocument, mnuEditTransmitCompanyRecord});
			// 
			// mnueditaddcompany
			// 
			mnueditaddcompany.Available = true;
			mnueditaddcompany.Checked = false;
			mnueditaddcompany.Enabled = true;
			mnueditaddcompany.Name = "mnueditaddcompany";
			mnueditaddcompany.Text = "Add New Company";
			mnueditaddcompany.Click += new System.EventHandler(mnueditaddcompany_Click);
			// 
			// mnueditaddcompanyphone
			// 
			mnueditaddcompanyphone.Available = true;
			mnueditaddcompanyphone.Checked = false;
			mnueditaddcompanyphone.Enabled = true;
			mnueditaddcompanyphone.Name = "mnueditaddcompanyphone";
			mnueditaddcompanyphone.Text = "Add Company Phone Number";
			mnueditaddcompanyphone.Click += new System.EventHandler(mnueditaddcompanyphone_Click);
			// 
			// mnueditremovecompanyphone
			// 
			mnueditremovecompanyphone.Available = true;
			mnueditremovecompanyphone.Checked = false;
			mnueditremovecompanyphone.Enabled = true;
			mnueditremovecompanyphone.Name = "mnueditremovecompanyphone";
			mnueditremovecompanyphone.Text = "Remove Company Phone Number";
			mnueditremovecompanyphone.Click += new System.EventHandler(mnueditremovecompanyphone_Click);
			// 
			// mnuRemoveDupContacts
			// 
			mnuRemoveDupContacts.Available = true;
			mnuRemoveDupContacts.Checked = false;
			mnuRemoveDupContacts.Enabled = true;
			mnuRemoveDupContacts.Name = "mnuRemoveDupContacts";
			mnuRemoveDupContacts.Text = "Remove Duplicate Contacts";
			mnuRemoveDupContacts.Click += new System.EventHandler(mnuRemoveDupContacts_Click);
			// 
			// mnuEditAddFractional
			// 
			mnuEditAddFractional.Available = true;
			mnuEditAddFractional.Checked = false;
			mnuEditAddFractional.Enabled = true;
			mnuEditAddFractional.Name = "mnuEditAddFractional";
			mnuEditAddFractional.Text = "Add to Fractional Owner List";
			mnuEditAddFractional.Click += new System.EventHandler(mnuEditAddFractional_Click);
			// 
			// mnuRemoveFractional
			// 
			mnuRemoveFractional.Available = true;
			mnuRemoveFractional.Checked = false;
			mnuRemoveFractional.Enabled = true;
			mnuRemoveFractional.Name = "mnuRemoveFractional";
			mnuRemoveFractional.Text = "Remove from Fractional Owner List";
			mnuRemoveFractional.Click += new System.EventHandler(mnuRemoveFractional_Click);
			// 
			// mnuSurveyResponse
			// 
			mnuSurveyResponse.Available = true;
			mnuSurveyResponse.Checked = false;
			mnuSurveyResponse.Enabled = true;
			mnuSurveyResponse.Name = "mnuSurveyResponse";
			mnuSurveyResponse.Text = "Add Eastman Survey Response";
			mnuSurveyResponse.Click += new System.EventHandler(mnuSurveyResponse_Click);
			// 
			// mnuEditCompMailingList
			// 
			mnuEditCompMailingList.Available = true;
			mnuEditCompMailingList.Checked = false;
			mnuEditCompMailingList.Enabled = true;
			mnuEditCompMailingList.Name = "mnuEditCompMailingList";
			mnuEditCompMailingList.Text = "Update Company Mailing Lists";
			mnuEditCompMailingList.Click += new System.EventHandler(mnuEditCompMailingList_Click);
			// 
			// mnuAddCompPub
			// 
			mnuAddCompPub.Available = true;
			mnuAddCompPub.Checked = false;
			mnuAddCompPub.Enabled = true;
			mnuAddCompPub.Name = "mnuAddCompPub";
			mnuAddCompPub.Text = "Add Company Memo";
			mnuAddCompPub.Click += new System.EventHandler(mnuAddCompPub_Click);
			// 
			// mnuAddCompanyDocument
			// 
			mnuAddCompanyDocument.Available = true;
			mnuAddCompanyDocument.Checked = false;
			mnuAddCompanyDocument.Enabled = true;
			mnuAddCompanyDocument.Name = "mnuAddCompanyDocument";
			mnuAddCompanyDocument.Text = "Add Company Document";
			mnuAddCompanyDocument.Click += new System.EventHandler(mnuAddCompanyDocument_Click);
			// 
			// mnuEditTransmitCompanyRecord
			// 
			mnuEditTransmitCompanyRecord.Available = true;
			mnuEditTransmitCompanyRecord.Checked = false;
			mnuEditTransmitCompanyRecord.Enabled = true;
			mnuEditTransmitCompanyRecord.Name = "mnuEditTransmitCompanyRecord";
			mnuEditTransmitCompanyRecord.Text = "Transmit Company Record";
			mnuEditTransmitCompanyRecord.Click += new System.EventHandler(mnuEditTransmitCompanyRecord_Click);
			// 
			// mnuView
			// 
			mnuView.Available = true;
			mnuView.Checked = false;
			mnuView.Enabled = true;
			mnuView.Name = "mnuView";
			mnuView.Text = "&View";
			mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuViewBadEmails, mnuViewJournalType, ViewCompany, mnusoldprices});
			// 
			// mnuViewBadEmails
			// 
			mnuViewBadEmails.Available = true;
			mnuViewBadEmails.Checked = false;
			mnuViewBadEmails.Enabled = true;
			mnuViewBadEmails.Name = "mnuViewBadEmails";
			mnuViewBadEmails.Text = "Bad Email Address's";
			// 
			// mnuViewJournalType
			// 
			mnuViewJournalType.Available = true;
			mnuViewJournalType.Checked = false;
			mnuViewJournalType.Enabled = true;
			mnuViewJournalType.Name = "mnuViewJournalType";
			mnuViewJournalType.Text = "Journal Type";
			mnuViewJournalType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{_mnuViewJournalSubType_1, _mnuViewJournalSubType_2, _mnuViewJournalSubType_3});
			// 
			// _mnuViewJournalSubType_1
			// 
			_mnuViewJournalSubType_1.Available = true;
			_mnuViewJournalSubType_1.Checked = true;
			_mnuViewJournalSubType_1.Enabled = true;
			_mnuViewJournalSubType_1.Name = "_mnuViewJournalSubType_1";
			_mnuViewJournalSubType_1.Text = "Company";
			_mnuViewJournalSubType_1.Click += new System.EventHandler(mnuViewJournalSubType_Click);
			// 
			// _mnuViewJournalSubType_2
			// 
			_mnuViewJournalSubType_2.Available = true;
			_mnuViewJournalSubType_2.Checked = true;
			_mnuViewJournalSubType_2.Enabled = true;
			_mnuViewJournalSubType_2.Name = "_mnuViewJournalSubType_2";
			_mnuViewJournalSubType_2.Text = "Contact";
			_mnuViewJournalSubType_2.Click += new System.EventHandler(mnuViewJournalSubType_Click);
			// 
			// _mnuViewJournalSubType_3
			// 
			_mnuViewJournalSubType_3.Available = true;
			_mnuViewJournalSubType_3.Checked = true;
			_mnuViewJournalSubType_3.Enabled = true;
			_mnuViewJournalSubType_3.Name = "_mnuViewJournalSubType_3";
			_mnuViewJournalSubType_3.Text = "Aircraft";
			_mnuViewJournalSubType_3.Click += new System.EventHandler(mnuViewJournalSubType_Click);
			// 
			// ViewCompany
			// 
			ViewCompany.Available = true;
			ViewCompany.Checked = false;
			ViewCompany.Enabled = true;
			ViewCompany.Name = "ViewCompany";
			ViewCompany.Text = "Company Record";
			ViewCompany.Click += new System.EventHandler(ViewCompany_Click);
			// 
			// mnusoldprices
			// 
			mnusoldprices.Available = true;
			mnusoldprices.Checked = false;
			mnusoldprices.Enabled = true;
			mnusoldprices.Name = "mnusoldprices";
			mnusoldprices.Text = "Submitted Sold Price Summary";
			mnusoldprices.Click += new System.EventHandler(mnusoldprices_Click);
			// 
			// mnuReport
			// 
			mnuReport.Available = true;
			mnuReport.Checked = false;
			mnuReport.Enabled = true;
			mnuReport.Name = "mnuReport";
			mnuReport.Text = "&Report";
			mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{_mnuReportList_0, _mnuReportList_1, _mnuReportList_2, _mnuReportList_3, _mnuReportList_4, _mnuReportList_5, _mnuReportList_6, _mnuReportList_7, mnuReportDeliveryPositionReport, mnuReportInOperationReport});
			// 
			// _mnuReportList_0
			// 
			_mnuReportList_0.Available = true;
			_mnuReportList_0.Checked = false;
			_mnuReportList_0.Enabled = true;
			_mnuReportList_0.Name = "_mnuReportList_0";
			_mnuReportList_0.Text = "Company Details Report";
			_mnuReportList_0.Click += new System.EventHandler(mnuReportList_Click);
			// 
			// _mnuReportList_1
			// 
			_mnuReportList_1.Available = true;
			_mnuReportList_1.Checked = false;
			_mnuReportList_1.Enabled = true;
			_mnuReportList_1.Name = "_mnuReportList_1";
			_mnuReportList_1.Text = "List of Fractional Programs";
			_mnuReportList_1.Click += new System.EventHandler(mnuReportList_Click);
			// 
			// _mnuReportList_2
			// 
			_mnuReportList_2.Available = true;
			_mnuReportList_2.Checked = false;
			_mnuReportList_2.Enabled = true;
			_mnuReportList_2.Name = "_mnuReportList_2";
			_mnuReportList_2.Text = "Technical Department Customer Record";
			_mnuReportList_2.Click += new System.EventHandler(mnuReportList_Click);
			// 
			// _mnuReportList_3
			// 
			_mnuReportList_3.Available = true;
			_mnuReportList_3.Checked = false;
			_mnuReportList_3.Enabled = true;
			_mnuReportList_3.Name = "_mnuReportList_3";
			_mnuReportList_3.Text = "Company Sold Transactions";
			_mnuReportList_3.Click += new System.EventHandler(mnuReportList_Click);
			// 
			// _mnuReportList_4
			// 
			_mnuReportList_4.Available = true;
			_mnuReportList_4.Checked = false;
			_mnuReportList_4.Enabled = true;
			_mnuReportList_4.Name = "_mnuReportList_4";
			_mnuReportList_4.Text = "List Survey Responses";
			_mnuReportList_4.Click += new System.EventHandler(mnuReportList_Click);
			// 
			// _mnuReportList_5
			// 
			_mnuReportList_5.Available = true;
			_mnuReportList_5.Checked = false;
			_mnuReportList_5.Enabled = true;
			_mnuReportList_5.Name = "_mnuReportList_5";
			_mnuReportList_5.Text = "Customer, CRM Mkt, Homebase Notes";
			_mnuReportList_5.Click += new System.EventHandler(mnuReportList_Click);
			// 
			// _mnuReportList_6
			// 
			_mnuReportList_6.Available = true;
			_mnuReportList_6.Checked = false;
			_mnuReportList_6.Enabled = true;
			_mnuReportList_6.Name = "_mnuReportList_6";
			_mnuReportList_6.Text = "Company Details Email Report";
			_mnuReportList_6.Click += new System.EventHandler(mnuReportList_Click);
			// 
			// _mnuReportList_7
			// 
			_mnuReportList_7.Available = true;
			_mnuReportList_7.Checked = false;
			_mnuReportList_7.Enabled = true;
			_mnuReportList_7.Name = "_mnuReportList_7";
			_mnuReportList_7.Text = "Company Details Report (API)";
			_mnuReportList_7.Click += new System.EventHandler(mnuReportList_Click);
			// 
			// mnuReportDeliveryPositionReport
			// 
			mnuReportDeliveryPositionReport.Available = true;
			mnuReportDeliveryPositionReport.Checked = false;
			mnuReportDeliveryPositionReport.Enabled = true;
			mnuReportDeliveryPositionReport.Name = "mnuReportDeliveryPositionReport";
			mnuReportDeliveryPositionReport.Text = "Aircraft Delivery Position Report";
			mnuReportDeliveryPositionReport.Click += new System.EventHandler(mnuReportDeliveryPositionReport_Click);
			// 
			// mnuReportInOperationReport
			// 
			mnuReportInOperationReport.Available = true;
			mnuReportInOperationReport.Checked = false;
			mnuReportInOperationReport.Enabled = true;
			mnuReportInOperationReport.Name = "mnuReportInOperationReport";
			mnuReportInOperationReport.Text = "Aircraft In Operation Report";
			mnuReportInOperationReport.Click += new System.EventHandler(mnuReportInOperationReport_Click);
			// 
			// mnuSubscriptions
			// 
			mnuSubscriptions.Available = true;
			mnuSubscriptions.Checked = false;
			mnuSubscriptions.Enabled = true;
			mnuSubscriptions.Name = "mnuSubscriptions";
			mnuSubscriptions.Text = "&Subscriptions";
			mnuSubscriptions.Click += new System.EventHandler(mnuSubscriptions_Click);
			// 
			// mnuACSearch
			// 
			mnuACSearch.Available = true;
			mnuACSearch.Checked = false;
			mnuACSearch.Enabled = true;
			mnuACSearch.Name = "mnuACSearch";
			mnuACSearch.Text = "&Aircraft Search";
			mnuACSearch.Click += new System.EventHandler(mnuACSearch_Click);
			// 
			// mnuTools
			// 
			mnuTools.Available = true;
			mnuTools.Checked = false;
			mnuTools.Enabled = true;
			mnuTools.Name = "mnuTools";
			mnuTools.Text = "&Tools";
			mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuCompanyDialPhoneNumber, mnuCompanyShowUserHistory});
			// 
			// mnuCompanyDialPhoneNumber
			// 
			mnuCompanyDialPhoneNumber.Available = false;
			mnuCompanyDialPhoneNumber.Checked = false;
			mnuCompanyDialPhoneNumber.Enabled = true;
			mnuCompanyDialPhoneNumber.Name = "mnuCompanyDialPhoneNumber";
			mnuCompanyDialPhoneNumber.Text = "Dial Phone Number";
			mnuCompanyDialPhoneNumber.Click += new System.EventHandler(mnuCompanyDialPhoneNumber_Click);
			// 
			// mnuCompanyShowUserHistory
			// 
			mnuCompanyShowUserHistory.Available = true;
			mnuCompanyShowUserHistory.Checked = false;
			mnuCompanyShowUserHistory.Enabled = true;
			mnuCompanyShowUserHistory.Name = "mnuCompanyShowUserHistory";
			mnuCompanyShowUserHistory.Text = "Show User History";
			mnuCompanyShowUserHistory.Click += new System.EventHandler(mnuCompanyShowUserHistory_Click);
			// 
			// mnuRightClickAircraft
			// 
			mnuRightClickAircraft.Available = false;
			mnuRightClickAircraft.Checked = false;
			mnuRightClickAircraft.Enabled = true;
			mnuRightClickAircraft.Name = "mnuRightClickAircraft";
			mnuRightClickAircraft.Text = "Right Click Aircraft";
			mnuRightClickAircraft.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuConfirmACBase, mnuMassConfirmACBase, mnuConfirmACReg, mnuMassConfirmACReg, mnuChangeBusinessType, mnuChangeBusinessTypeOnAllReferences, mnuChangeBusinessTypeOnAllAircraft, mnuShowExclusiveBroker, mnuShowOwner, mnuConfirmManagement, mnuConfirmCharter, mnuConfirnManCharter, mnuShowExtra});
			// 
			// mnuConfirmACBase
			// 
			mnuConfirmACBase.Available = true;
			mnuConfirmACBase.Checked = false;
			mnuConfirmACBase.Enabled = true;
			mnuConfirmACBase.Name = "mnuConfirmACBase";
			mnuConfirmACBase.Text = "Confirm Aircraft Base Info (This Aircraft)";
			mnuConfirmACBase.Click += new System.EventHandler(mnuConfirmACBase_Click);
			// 
			// mnuMassConfirmACBase
			// 
			mnuMassConfirmACBase.Available = true;
			mnuMassConfirmACBase.Checked = false;
			mnuMassConfirmACBase.Enabled = true;
			mnuMassConfirmACBase.Name = "mnuMassConfirmACBase";
			mnuMassConfirmACBase.Text = "Mass Confirm Aircraft Base Info (All Active Aircraft)";
			mnuMassConfirmACBase.Click += new System.EventHandler(mnuMassConfirmACBase_Click);
			// 
			// mnuConfirmACReg
			// 
			mnuConfirmACReg.Available = true;
			mnuConfirmACReg.Checked = false;
			mnuConfirmACReg.Enabled = true;
			mnuConfirmACReg.Name = "mnuConfirmACReg";
			mnuConfirmACReg.Text = "Confirm Aircraft Registration Number (This Aircraft)";
			mnuConfirmACReg.Click += new System.EventHandler(mnuConfirmACReg_Click);
			// 
			// mnuMassConfirmACReg
			// 
			mnuMassConfirmACReg.Available = true;
			mnuMassConfirmACReg.Checked = false;
			mnuMassConfirmACReg.Enabled = true;
			mnuMassConfirmACReg.Name = "mnuMassConfirmACReg";
			mnuMassConfirmACReg.Text = "Mass confirm Registration Number (All Active Aircraft)";
			mnuMassConfirmACReg.Click += new System.EventHandler(mnuMassConfirmACReg_Click);
			// 
			// mnuChangeBusinessType
			// 
			mnuChangeBusinessType.Available = true;
			mnuChangeBusinessType.Checked = false;
			mnuChangeBusinessType.Enabled = true;
			mnuChangeBusinessType.Name = "mnuChangeBusinessType";
			mnuChangeBusinessType.Text = "Change Business Type For This Reference";
			mnuChangeBusinessType.Click += new System.EventHandler(mnuChangeBusinessType_Click);
			// 
			// mnuChangeBusinessTypeOnAllReferences
			// 
			mnuChangeBusinessTypeOnAllReferences.Available = true;
			mnuChangeBusinessTypeOnAllReferences.Checked = false;
			mnuChangeBusinessTypeOnAllReferences.Enabled = true;
			mnuChangeBusinessTypeOnAllReferences.Name = "mnuChangeBusinessTypeOnAllReferences";
			mnuChangeBusinessTypeOnAllReferences.Text = "Change Business Type For All References";
			mnuChangeBusinessTypeOnAllReferences.Click += new System.EventHandler(mnuChangeBusinessTypeOnAllReferences_Click);
			// 
			// mnuChangeBusinessTypeOnAllAircraft
			// 
			mnuChangeBusinessTypeOnAllAircraft.Available = true;
			mnuChangeBusinessTypeOnAllAircraft.Checked = false;
			mnuChangeBusinessTypeOnAllAircraft.Enabled = true;
			mnuChangeBusinessTypeOnAllAircraft.Name = "mnuChangeBusinessTypeOnAllAircraft";
			mnuChangeBusinessTypeOnAllAircraft.Text = "Change Business Type For All References On All Aircraft";
			mnuChangeBusinessTypeOnAllAircraft.Click += new System.EventHandler(mnuChangeBusinessTypeOnAllAircraft_Click);
			// 
			// mnuShowExclusiveBroker
			// 
			mnuShowExclusiveBroker.Available = false;
			mnuShowExclusiveBroker.Checked = false;
			mnuShowExclusiveBroker.Enabled = true;
			mnuShowExclusiveBroker.Name = "mnuShowExclusiveBroker";
			mnuShowExclusiveBroker.Text = "Show Exclusive Broker / Sales Contact";
			mnuShowExclusiveBroker.Click += new System.EventHandler(mnuShowExclusiveBroker_Click);
			// 
			// mnuShowOwner
			// 
			mnuShowOwner.Available = true;
			mnuShowOwner.Checked = false;
			mnuShowOwner.Enabled = true;
			mnuShowOwner.Name = "mnuShowOwner";
			mnuShowOwner.Text = "Show Owner";
			mnuShowOwner.Click += new System.EventHandler(mnuShowOwner_Click);
			// 
			// mnuConfirmManagement
			// 
			mnuConfirmManagement.Available = true;
			mnuConfirmManagement.Checked = false;
			mnuConfirmManagement.Enabled = true;
			mnuConfirmManagement.Name = "mnuConfirmManagement";
			mnuConfirmManagement.Text = "Confirm Management Company";
			mnuConfirmManagement.Click += new System.EventHandler(mnuConfirmManagement_Click);
			// 
			// mnuConfirmCharter
			// 
			mnuConfirmCharter.Available = true;
			mnuConfirmCharter.Checked = false;
			mnuConfirmCharter.Enabled = true;
			mnuConfirmCharter.Name = "mnuConfirmCharter";
			mnuConfirmCharter.Text = "Confirm Charter Company";
			mnuConfirmCharter.Click += new System.EventHandler(mnuConfirmCharter_Click);
			// 
			// mnuConfirnManCharter
			// 
			mnuConfirnManCharter.Available = true;
			mnuConfirnManCharter.Checked = false;
			mnuConfirnManCharter.Enabled = true;
			mnuConfirnManCharter.Name = "mnuConfirnManCharter";
			mnuConfirnManCharter.Text = "Confirm Management and Charter Company";
			mnuConfirnManCharter.Click += new System.EventHandler(mnuConfirnManCharter_Click);
			// 
			// mnuShowExtra
			// 
			mnuShowExtra.Available = true;
			mnuShowExtra.Checked = false;
			mnuShowExtra.Enabled = true;
			mnuShowExtra.Name = "mnuShowExtra";
			mnuShowExtra.Text = "Show Available Details";
			mnuShowExtra.Click += new System.EventHandler(mnuShowExtra_Click);
			// 
			// mnuRightClickYacht
			// 
			mnuRightClickYacht.Available = false;
			mnuRightClickYacht.Checked = false;
			mnuRightClickYacht.Enabled = true;
			mnuRightClickYacht.Name = "mnuRightClickYacht";
			mnuRightClickYacht.Text = "Right Click Yacht";
			mnuRightClickYacht.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuShowCentralAgent});
			// 
			// mnuShowCentralAgent
			// 
			mnuShowCentralAgent.Available = true;
			mnuShowCentralAgent.Checked = false;
			mnuShowCentralAgent.Enabled = true;
			mnuShowCentralAgent.Name = "mnuShowCentralAgent";
			mnuShowCentralAgent.Text = "Show Central Agent / Joint Central Agent";
			// 
			// tab_company_details
			// 
			tab_company_details.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_company_details.AllowDrop = true;
			tab_company_details.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			tab_company_details.CausesValidation = false;
			tab_company_details.Controls.Add(_tab_company_details_TabPage0);
			tab_company_details.Controls.Add(_tab_company_details_TabPage1);
			tab_company_details.Controls.Add(_tab_company_details_TabPage2);
			tab_company_details.Controls.Add(_tab_company_details_TabPage3);
			tab_company_details.Controls.Add(_tab_company_details_TabPage4);
			tab_company_details.Controls.Add(_tab_company_details_TabPage5);
			tab_company_details.Controls.Add(_tab_company_details_TabPage6);
			tab_company_details.Controls.Add(_tab_company_details_TabPage7);
			tab_company_details.Controls.Add(_tab_company_details_TabPage8);
			tab_company_details.Controls.Add(_tab_company_details_TabPage9);
			tab_company_details.Controls.Add(_tab_company_details_TabPage10);
			tab_company_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_company_details.ItemSize = new System.Drawing.Size(90, 18);
			tab_company_details.Location = new System.Drawing.Point(0, 376);
			tab_company_details.Multiline = true;
			tab_company_details.Name = "tab_company_details";
			tab_company_details.Size = new System.Drawing.Size(1012, 374);
			tab_company_details.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_company_details.TabIndex = 241;
			tab_company_details.Visible = false;
			tab_company_details.DoubleClick += new System.EventHandler(tab_company_details_DoubleClick);
			tab_company_details.SelectedIndexChanged += new System.EventHandler(tab_company_details_SelectedIndexChanged);
			// 
			// _tab_company_details_TabPage0
			// 
			_tab_company_details_TabPage0.Controls.Add(_lbl_test_omg3_1);
			_tab_company_details_TabPage0.Controls.Add(_lbl_comp_15);
			_tab_company_details_TabPage0.Controls.Add(_shp_Shape_1);
			_tab_company_details_TabPage0.Controls.Add(_lbl_comp_62);
			_tab_company_details_TabPage0.Controls.Add(_lbl_comp_51);
			_tab_company_details_TabPage0.Controls.Add(_lbl_comp_4);
			_tab_company_details_TabPage0.Controls.Add(_shp_dealer_background_7);
			_tab_company_details_TabPage0.Controls.Add(grd_company_aircraft);
			_tab_company_details_TabPage0.Controls.Add(chk_view_eu);
			_tab_company_details_TabPage0.Controls.Add(_cmd_ac_verify_7);
			_tab_company_details_TabPage0.Controls.Add(_cmd_ac_verify_6);
			_tab_company_details_TabPage0.Controls.Add(_cmd_ac_verify_5);
			_tab_company_details_TabPage0.Controls.Add(_cmd_ac_verify_4);
			_tab_company_details_TabPage0.Controls.Add(_cmd_ac_verify_3);
			_tab_company_details_TabPage0.Controls.Add(_cmd_ac_verify_2);
			_tab_company_details_TabPage0.Controls.Add(_cmd_ac_verify_1);
			_tab_company_details_TabPage0.Controls.Add(_cmd_ac_verify_0);
			_tab_company_details_TabPage0.Controls.Add(cbo_comp_purchase_question);
			_tab_company_details_TabPage0.Controls.Add(cbo_ac_delivery_position);
			_tab_company_details_TabPage0.Controls.Add(_txt_gen_7);
			_tab_company_details_TabPage0.Controls.Add(_txt_gen_6);
			_tab_company_details_TabPage0.Controls.Add(chk_change_same_ac_contact_type_only);
			_tab_company_details_TabPage0.Controls.Add(_txt_gen_0);
			_tab_company_details_TabPage0.Controls.Add(_txt_gen_5);
			_tab_company_details_TabPage0.Controls.Add(_txt_gen_2);
			_tab_company_details_TabPage0.Controls.Add(lst_aircraft_contact);
			_tab_company_details_TabPage0.Controls.Add(_txt_gen_4);
			_tab_company_details_TabPage0.Controls.Add(_txt_gen_1);
			_tab_company_details_TabPage0.Controls.Add(cbo_company_research_contact);
			_tab_company_details_TabPage0.Controls.Add(cmd_aircraft_all_contact_change);
			_tab_company_details_TabPage0.Controls.Add(cmd_aircraft_contact_change);
			_tab_company_details_TabPage0.Controls.Add(_txt_gen_3);
			_tab_company_details_TabPage0.Controls.Add(_txt_gen_8);
			_tab_company_details_TabPage0.Controls.Add(txt_only_show_first_aircraft_recs);
			_tab_company_details_TabPage0.Controls.Add(chk_limit_aircraft_list);
			_tab_company_details_TabPage0.Controls.Add(txt_total_aircraft);
			_tab_company_details_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_details_TabPage0.Text = "Aircraft";
			// 
			// _lbl_test_omg3_1
			// 
			_lbl_test_omg3_1.AllowDrop = true;
			_lbl_test_omg3_1.BackColor = System.Drawing.Color.Aqua;
			_lbl_test_omg3_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_test_omg3_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_test_omg3_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_test_omg3_1.Location = new System.Drawing.Point(24, 3);
			_lbl_test_omg3_1.MinimumSize = new System.Drawing.Size(937, 17);
			_lbl_test_omg3_1.Name = "_lbl_test_omg3_1";
			_lbl_test_omg3_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_test_omg3_1.Size = new System.Drawing.Size(937, 17);
			_lbl_test_omg3_1.TabIndex = 368;
			_lbl_test_omg3_1.Text = "---->  ---------> -------->  --------------------------- >  ------------------- > You Are On Test --  >  -------------------- > -------------------- > ----------------------- > ----------------------- > --------------------- > ---------------------- > ";
			_lbl_test_omg3_1.Visible = false;
			// 
			// _lbl_comp_15
			// 
			_lbl_comp_15.AllowDrop = true;
			_lbl_comp_15.AutoSize = true;
			_lbl_comp_15.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_15.Location = new System.Drawing.Point(350, 44);
			_lbl_comp_15.MinimumSize = new System.Drawing.Size(9, 13);
			_lbl_comp_15.Name = "_lbl_comp_15";
			_lbl_comp_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_15.Size = new System.Drawing.Size(9, 13);
			_lbl_comp_15.TabIndex = 379;
			_lbl_comp_15.Text = "of";
			_lbl_comp_15.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_15.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_15.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _shp_Shape_1
			// 
			_shp_Shape_1.AllowDrop = true;
			_shp_Shape_1.BackColor = System.Drawing.SystemColors.Window;
			_shp_Shape_1.BackStyle = 0;
			_shp_Shape_1.BorderStyle = 1;
			_shp_Shape_1.Enabled = false;
			_shp_Shape_1.FillColor = System.Drawing.Color.Black;
			_shp_Shape_1.FillStyle = 1;
			_shp_Shape_1.Location = new System.Drawing.Point(6, 223);
			_shp_Shape_1.Name = "_shp_Shape_1";
			_shp_Shape_1.Size = new System.Drawing.Size(344, 79);
			_shp_Shape_1.Visible = true;
			// 
			// _lbl_comp_62
			// 
			_lbl_comp_62.AllowDrop = true;
			_lbl_comp_62.AutoSize = true;
			_lbl_comp_62.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_62.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_62.ForeColor = System.Drawing.Color.Black;
			_lbl_comp_62.Location = new System.Drawing.Point(2, 42);
			_lbl_comp_62.MinimumSize = new System.Drawing.Size(73, 13);
			_lbl_comp_62.Name = "_lbl_comp_62";
			_lbl_comp_62.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_62.Size = new System.Drawing.Size(73, 13);
			_lbl_comp_62.TabIndex = 381;
			_lbl_comp_62.Text = "A/C Listing:";
			_lbl_comp_62.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_62.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_62.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_62.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_51
			// 
			_lbl_comp_51.AllowDrop = true;
			_lbl_comp_51.AutoSize = true;
			_lbl_comp_51.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_51.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_51.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_51.Location = new System.Drawing.Point(717, 222);
			_lbl_comp_51.MinimumSize = new System.Drawing.Size(109, 12);
			_lbl_comp_51.Name = "_lbl_comp_51";
			_lbl_comp_51.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_51.Size = new System.Drawing.Size(109, 12);
			_lbl_comp_51.TabIndex = 384;
			_lbl_comp_51.Text = "Company Contact/Title";
			_lbl_comp_51.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_51.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_51.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_4
			// 
			_lbl_comp_4.AllowDrop = true;
			_lbl_comp_4.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_4.Location = new System.Drawing.Point(15, 241);
			_lbl_comp_4.MinimumSize = new System.Drawing.Size(10, 42);
			_lbl_comp_4.Name = "_lbl_comp_4";
			_lbl_comp_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_4.Size = new System.Drawing.Size(10, 42);
			_lbl_comp_4.TabIndex = 386;
			_lbl_comp_4.Text = "K E Y";
			_lbl_comp_4.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_4.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_4.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _shp_dealer_background_7
			// 
			_shp_dealer_background_7.AllowDrop = true;
			_shp_dealer_background_7.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_7.BackStyle = 1;
			_shp_dealer_background_7.BorderStyle = 0;
			_shp_dealer_background_7.Enabled = false;
			_shp_dealer_background_7.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_7.FillStyle = 1;
			_shp_dealer_background_7.Location = new System.Drawing.Point(8, 20);
			_shp_dealer_background_7.Name = "_shp_dealer_background_7";
			_shp_dealer_background_7.Size = new System.Drawing.Size(996, 300);
			_shp_dealer_background_7.Visible = false;
			// 
			// grd_company_aircraft
			// 
			grd_company_aircraft.AllowDrop = true;
			grd_company_aircraft.AllowUserToAddRows = false;
			grd_company_aircraft.AllowUserToDeleteRows = false;
			grd_company_aircraft.AllowUserToResizeColumns = false;
			grd_company_aircraft.AllowUserToResizeColumns = grd_company_aircraft.ColumnHeadersVisible;
			grd_company_aircraft.AllowUserToResizeRows = false;
			grd_company_aircraft.AllowUserToResizeRows = false;
			grd_company_aircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_aircraft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_aircraft.ColumnsCount = 2;
			grd_company_aircraft.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
			grd_company_aircraft.FixedColumns = 0;
			grd_company_aircraft.FixedRows = 1;
			grd_company_aircraft.Location = new System.Drawing.Point(8, 68);
			grd_company_aircraft.Name = "grd_company_aircraft";
			grd_company_aircraft.ReadOnly = true;
			grd_company_aircraft.RowsCount = 2;
			grd_company_aircraft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_company_aircraft.ShowCellToolTips = false;
			grd_company_aircraft.Size = new System.Drawing.Size(985, 155);
			grd_company_aircraft.StandardTab = true;
			grd_company_aircraft.TabIndex = 358;
			grd_company_aircraft.Click += new System.EventHandler(grd_company_aircraft_Click);
			grd_company_aircraft.DoubleClick += new System.EventHandler(grd_company_aircraft_DoubleClick);
			grd_company_aircraft.MouseDown += new System.Windows.Forms.MouseEventHandler(grd_company_aircraft_MouseDown);
			// 
			// chk_view_eu
			// 
			chk_view_eu.AllowDrop = true;
			chk_view_eu.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_view_eu.BackColor = System.Drawing.SystemColors.Control;
			chk_view_eu.CausesValidation = true;
			chk_view_eu.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_view_eu.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_view_eu.Enabled = true;
			chk_view_eu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_view_eu.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_view_eu.Location = new System.Drawing.Point(205, 20);
			chk_view_eu.Name = "chk_view_eu";
			chk_view_eu.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_view_eu.Size = new System.Drawing.Size(97, 13);
			chk_view_eu.TabIndex = 282;
			chk_view_eu.TabStop = true;
			chk_view_eu.Text = "Compact View";
			chk_view_eu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_view_eu.Visible = true;
			chk_view_eu.CheckStateChanged += new System.EventHandler(chk_view_eu_CheckStateChanged);
			// 
			// _cmd_ac_verify_7
			// 
			_cmd_ac_verify_7.AllowDrop = true;
			_cmd_ac_verify_7.BackColor = System.Drawing.SystemColors.Control;
			_cmd_ac_verify_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_ac_verify_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_ac_verify_7.Location = new System.Drawing.Point(898, 12);
			_cmd_ac_verify_7.Name = "_cmd_ac_verify_7";
			_cmd_ac_verify_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_ac_verify_7.Size = new System.Drawing.Size(95, 21);
			_cmd_ac_verify_7.TabIndex = 284;
			_cmd_ac_verify_7.Text = "Verify Ownership";
			_cmd_ac_verify_7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_ac_verify_7.UseVisualStyleBackColor = false;
			_cmd_ac_verify_7.Visible = false;
			_cmd_ac_verify_7.Click += new System.EventHandler(cmd_ac_verify_Click);
			// 
			// _cmd_ac_verify_6
			// 
			_cmd_ac_verify_6.AllowDrop = true;
			_cmd_ac_verify_6.BackColor = System.Drawing.SystemColors.Control;
			_cmd_ac_verify_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_ac_verify_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_ac_verify_6.Location = new System.Drawing.Point(460, 16);
			_cmd_ac_verify_6.Name = "_cmd_ac_verify_6";
			_cmd_ac_verify_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_ac_verify_6.Size = new System.Drawing.Size(123, 17);
			_cmd_ac_verify_6.TabIndex = 290;
			_cmd_ac_verify_6.Text = "X Missing Sale Prices X ";
			_cmd_ac_verify_6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_ac_verify_6.UseVisualStyleBackColor = false;
			_cmd_ac_verify_6.Click += new System.EventHandler(cmd_ac_verify_Click);
			// 
			// _cmd_ac_verify_5
			// 
			_cmd_ac_verify_5.AllowDrop = true;
			_cmd_ac_verify_5.BackColor = System.Drawing.SystemColors.Control;
			_cmd_ac_verify_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_ac_verify_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_ac_verify_5.Location = new System.Drawing.Point(416, 38);
			_cmd_ac_verify_5.Name = "_cmd_ac_verify_5";
			_cmd_ac_verify_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_ac_verify_5.Size = new System.Drawing.Size(49, 21);
			_cmd_ac_verify_5.TabIndex = 291;
			_cmd_ac_verify_5.Text = "Refresh";
			_cmd_ac_verify_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_ac_verify_5.UseVisualStyleBackColor = false;
			_cmd_ac_verify_5.Click += new System.EventHandler(cmd_ac_verify_Click);
			// 
			// _cmd_ac_verify_4
			// 
			_cmd_ac_verify_4.AllowDrop = true;
			_cmd_ac_verify_4.BackColor = System.Drawing.SystemColors.Control;
			_cmd_ac_verify_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_ac_verify_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_ac_verify_4.Location = new System.Drawing.Point(888, 38);
			_cmd_ac_verify_4.Name = "_cmd_ac_verify_4";
			_cmd_ac_verify_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_ac_verify_4.Size = new System.Drawing.Size(105, 21);
			_cmd_ac_verify_4.TabIndex = 293;
			_cmd_ac_verify_4.Text = "Verify Available A/C";
			_cmd_ac_verify_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_ac_verify_4.UseVisualStyleBackColor = false;
			_cmd_ac_verify_4.Click += new System.EventHandler(cmd_ac_verify_Click);
			// 
			// _cmd_ac_verify_3
			// 
			_cmd_ac_verify_3.AllowDrop = true;
			_cmd_ac_verify_3.BackColor = System.Drawing.SystemColors.Control;
			_cmd_ac_verify_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_ac_verify_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_ac_verify_3.Location = new System.Drawing.Point(772, 38);
			_cmd_ac_verify_3.Name = "_cmd_ac_verify_3";
			_cmd_ac_verify_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_ac_verify_3.Size = new System.Drawing.Size(107, 21);
			_cmd_ac_verify_3.TabIndex = 294;
			_cmd_ac_verify_3.Text = "Verify All Fixed Wing";
			_cmd_ac_verify_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_ac_verify_3.UseVisualStyleBackColor = false;
			_cmd_ac_verify_3.Click += new System.EventHandler(cmd_ac_verify_Click);
			// 
			// _cmd_ac_verify_2
			// 
			_cmd_ac_verify_2.AllowDrop = true;
			_cmd_ac_verify_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_ac_verify_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_ac_verify_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_ac_verify_2.Location = new System.Drawing.Point(682, 38);
			_cmd_ac_verify_2.Name = "_cmd_ac_verify_2";
			_cmd_ac_verify_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_ac_verify_2.Size = new System.Drawing.Size(81, 21);
			_cmd_ac_verify_2.TabIndex = 295;
			_cmd_ac_verify_2.Text = "Verify All Heli";
			_cmd_ac_verify_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_ac_verify_2.UseVisualStyleBackColor = false;
			_cmd_ac_verify_2.Click += new System.EventHandler(cmd_ac_verify_Click);
			// 
			// _cmd_ac_verify_1
			// 
			_cmd_ac_verify_1.AllowDrop = true;
			_cmd_ac_verify_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_ac_verify_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_ac_verify_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_ac_verify_1.Location = new System.Drawing.Point(595, 38);
			_cmd_ac_verify_1.Name = "_cmd_ac_verify_1";
			_cmd_ac_verify_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_ac_verify_1.Size = new System.Drawing.Size(79, 21);
			_cmd_ac_verify_1.TabIndex = 296;
			_cmd_ac_verify_1.Text = "Verify All A/C";
			_cmd_ac_verify_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_ac_verify_1.UseVisualStyleBackColor = false;
			_cmd_ac_verify_1.Click += new System.EventHandler(cmd_ac_verify_Click);
			// 
			// _cmd_ac_verify_0
			// 
			_cmd_ac_verify_0.AllowDrop = true;
			_cmd_ac_verify_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_ac_verify_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_ac_verify_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_ac_verify_0.Location = new System.Drawing.Point(494, 38);
			_cmd_ac_verify_0.Name = "_cmd_ac_verify_0";
			_cmd_ac_verify_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_ac_verify_0.Size = new System.Drawing.Size(95, 21);
			_cmd_ac_verify_0.TabIndex = 298;
			_cmd_ac_verify_0.Text = "Verify A/C Status";
			_cmd_ac_verify_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_ac_verify_0.UseVisualStyleBackColor = false;
			_cmd_ac_verify_0.Click += new System.EventHandler(cmd_ac_verify_Click);
			// 
			// cbo_comp_purchase_question
			// 
			cbo_comp_purchase_question.AllowDrop = true;
			cbo_comp_purchase_question.BackColor = System.Drawing.Color.Yellow;
			cbo_comp_purchase_question.CausesValidation = true;
			cbo_comp_purchase_question.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_comp_purchase_question.Enabled = true;
			cbo_comp_purchase_question.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_purchase_question.ForeColor = System.Drawing.Color.Black;
			cbo_comp_purchase_question.IntegralHeight = true;
			cbo_comp_purchase_question.Location = new System.Drawing.Point(12, 119);
			cbo_comp_purchase_question.Name = "cbo_comp_purchase_question";
			cbo_comp_purchase_question.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_purchase_question.Size = new System.Drawing.Size(123, 21);
			cbo_comp_purchase_question.Sorted = false;
			cbo_comp_purchase_question.TabIndex = 327;
			cbo_comp_purchase_question.TabStop = true;
			cbo_comp_purchase_question.Visible = false;
			cbo_comp_purchase_question.SelectedIndexChanged += new System.EventHandler(cbo_comp_purchase_question_SelectedIndexChanged);
			// 
			// cbo_ac_delivery_position
			// 
			cbo_ac_delivery_position.AllowDrop = true;
			cbo_ac_delivery_position.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_delivery_position.CausesValidation = true;
			cbo_ac_delivery_position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_delivery_position.Enabled = true;
			cbo_ac_delivery_position.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_delivery_position.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_delivery_position.IntegralHeight = true;
			cbo_ac_delivery_position.Location = new System.Drawing.Point(76, 38);
			cbo_ac_delivery_position.Name = "cbo_ac_delivery_position";
			cbo_ac_delivery_position.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_delivery_position.Size = new System.Drawing.Size(121, 21);
			cbo_ac_delivery_position.Sorted = false;
			cbo_ac_delivery_position.TabIndex = 328;
			cbo_ac_delivery_position.TabStop = true;
			cbo_ac_delivery_position.Visible = true;
			cbo_ac_delivery_position.SelectedIndexChanged += new System.EventHandler(cbo_ac_delivery_position_SelectedIndexChanged);
			// 
			// _txt_gen_7
			// 
			_txt_gen_7.AcceptsReturn = true;
			_txt_gen_7.AllowDrop = true;
			_txt_gen_7.BackColor = System.Drawing.Color.Red;
			_txt_gen_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_7.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_7.ForeColor = System.Drawing.Color.Black;
			_txt_gen_7.Location = new System.Drawing.Point(242, 284);
			_txt_gen_7.MaxLength = 0;
			_txt_gen_7.Name = "_txt_gen_7";
			_txt_gen_7.ReadOnly = true;
			_txt_gen_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_7.Size = new System.Drawing.Size(106, 16);
			_txt_gen_7.TabIndex = 329;
			_txt_gen_7.Tag = "N";
			_txt_gen_7.Text = " Class D Aircraft";
			_txt_gen_7.Visible = false;
			// 
			// _txt_gen_6
			// 
			_txt_gen_6.AcceptsReturn = true;
			_txt_gen_6.AllowDrop = true;
			_txt_gen_6.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			_txt_gen_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_6.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_6.ForeColor = System.Drawing.Color.Black;
			_txt_gen_6.Location = new System.Drawing.Point(198, 283);
			_txt_gen_6.MaxLength = 0;
			_txt_gen_6.Name = "_txt_gen_6";
			_txt_gen_6.ReadOnly = true;
			_txt_gen_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_6.Size = new System.Drawing.Size(41, 16);
			_txt_gen_6.TabIndex = 330;
			_txt_gen_6.Tag = "N";
			_txt_gen_6.Text = " WFU";
			// 
			// chk_change_same_ac_contact_type_only
			// 
			chk_change_same_ac_contact_type_only.AllowDrop = true;
			chk_change_same_ac_contact_type_only.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_change_same_ac_contact_type_only.BackColor = System.Drawing.SystemColors.Control;
			chk_change_same_ac_contact_type_only.CausesValidation = true;
			chk_change_same_ac_contact_type_only.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_change_same_ac_contact_type_only.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_change_same_ac_contact_type_only.Enabled = true;
			chk_change_same_ac_contact_type_only.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_change_same_ac_contact_type_only.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_change_same_ac_contact_type_only.Location = new System.Drawing.Point(373, 286);
			chk_change_same_ac_contact_type_only.Name = "chk_change_same_ac_contact_type_only";
			chk_change_same_ac_contact_type_only.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_change_same_ac_contact_type_only.Size = new System.Drawing.Size(196, 14);
			chk_change_same_ac_contact_type_only.TabIndex = 331;
			chk_change_same_ac_contact_type_only.TabStop = true;
			chk_change_same_ac_contact_type_only.Text = "Change Same Contact Type Only";
			chk_change_same_ac_contact_type_only.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_change_same_ac_contact_type_only.Visible = true;
			// 
			// _txt_gen_0
			// 
			_txt_gen_0.AcceptsReturn = true;
			_txt_gen_0.AllowDrop = true;
			_txt_gen_0.BackColor = System.Drawing.Color.Purple;
			_txt_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_0.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_0.ForeColor = System.Drawing.Color.White;
			_txt_gen_0.Location = new System.Drawing.Point(198, 264);
			_txt_gen_0.MaxLength = 0;
			_txt_gen_0.Name = "_txt_gen_0";
			_txt_gen_0.ReadOnly = true;
			_txt_gen_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_0.Size = new System.Drawing.Size(150, 16);
			_txt_gen_0.TabIndex = 339;
			_txt_gen_0.Tag = "N";
			_txt_gen_0.Text = " Dark Purple = Transmit";
			// 
			// _txt_gen_5
			// 
			_txt_gen_5.AcceptsReturn = true;
			_txt_gen_5.AllowDrop = true;
			_txt_gen_5.BackColor = System.Drawing.Color.White;
			_txt_gen_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_5.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_5.ForeColor = System.Drawing.Color.Black;
			_txt_gen_5.Location = new System.Drawing.Point(30, 283);
			_txt_gen_5.MaxLength = 0;
			_txt_gen_5.Name = "_txt_gen_5";
			_txt_gen_5.ReadOnly = true;
			_txt_gen_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_5.Size = new System.Drawing.Size(163, 16);
			_txt_gen_5.TabIndex = 341;
			_txt_gen_5.Tag = "N";
			_txt_gen_5.Text = " Bold = Confirm Reassign";
			// 
			// _txt_gen_2
			// 
			_txt_gen_2.AcceptsReturn = true;
			_txt_gen_2.AllowDrop = true;
			_txt_gen_2.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			_txt_gen_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_2.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_2.ForeColor = System.Drawing.Color.Black;
			_txt_gen_2.Location = new System.Drawing.Point(198, 226);
			_txt_gen_2.MaxLength = 0;
			_txt_gen_2.Name = "_txt_gen_2";
			_txt_gen_2.ReadOnly = true;
			_txt_gen_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_2.Size = new System.Drawing.Size(150, 16);
			_txt_gen_2.TabIndex = 342;
			_txt_gen_2.Tag = "N";
			_txt_gen_2.Text = " Pink = Color Confirm";
			// 
			// lst_aircraft_contact
			// 
			lst_aircraft_contact.AllowDrop = true;
			lst_aircraft_contact.BackColor = System.Drawing.SystemColors.Control;
			lst_aircraft_contact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_aircraft_contact.CausesValidation = true;
			lst_aircraft_contact.Enabled = true;
			lst_aircraft_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_aircraft_contact.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_aircraft_contact.IntegralHeight = true;
			lst_aircraft_contact.Location = new System.Drawing.Point(584, 258);
			lst_aircraft_contact.MultiColumn = false;
			lst_aircraft_contact.Name = "lst_aircraft_contact";
			lst_aircraft_contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_aircraft_contact.Size = new System.Drawing.Size(407, 44);
			lst_aircraft_contact.Sorted = false;
			lst_aircraft_contact.TabIndex = 343;
			lst_aircraft_contact.TabStop = true;
			lst_aircraft_contact.Visible = true;
			lst_aircraft_contact.DoubleClick += new System.EventHandler(lst_aircraft_contact_DoubleClick);
			// 
			// _txt_gen_4
			// 
			_txt_gen_4.AcceptsReturn = true;
			_txt_gen_4.AllowDrop = true;
			_txt_gen_4.BackColor = System.Drawing.Color.FromArgb(255, 173, 91);
			_txt_gen_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_4.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_4.ForeColor = System.Drawing.Color.Black;
			_txt_gen_4.Location = new System.Drawing.Point(30, 264);
			_txt_gen_4.MaxLength = 0;
			_txt_gen_4.Name = "_txt_gen_4";
			_txt_gen_4.ReadOnly = true;
			_txt_gen_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_4.Size = new System.Drawing.Size(163, 16);
			_txt_gen_4.TabIndex = 344;
			_txt_gen_4.Tag = "N";
			_txt_gen_4.Text = " Orange = On Lease";
			// 
			// _txt_gen_1
			// 
			_txt_gen_1.AcceptsReturn = true;
			_txt_gen_1.AllowDrop = true;
			_txt_gen_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			_txt_gen_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_1.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_1.ForeColor = System.Drawing.Color.Black;
			_txt_gen_1.Location = new System.Drawing.Point(198, 245);
			_txt_gen_1.MaxLength = 0;
			_txt_gen_1.Name = "_txt_gen_1";
			_txt_gen_1.ReadOnly = true;
			_txt_gen_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_1.Size = new System.Drawing.Size(150, 16);
			_txt_gen_1.TabIndex = 346;
			_txt_gen_1.Tag = "N";
			_txt_gen_1.Text = " Purple = Confirm Exclusive";
			// 
			// cbo_company_research_contact
			// 
			cbo_company_research_contact.AllowDrop = true;
			cbo_company_research_contact.BackColor = System.Drawing.SystemColors.Window;
			cbo_company_research_contact.CausesValidation = true;
			cbo_company_research_contact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_company_research_contact.Enabled = true;
			cbo_company_research_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_company_research_contact.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_company_research_contact.IntegralHeight = true;
			cbo_company_research_contact.Location = new System.Drawing.Point(584, 235);
			cbo_company_research_contact.Name = "cbo_company_research_contact";
			cbo_company_research_contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_company_research_contact.Size = new System.Drawing.Size(407, 21);
			cbo_company_research_contact.Sorted = false;
			cbo_company_research_contact.TabIndex = 347;
			cbo_company_research_contact.TabStop = true;
			cbo_company_research_contact.Visible = true;
			cbo_company_research_contact.SelectedIndexChanged += new System.EventHandler(cbo_company_research_contact_SelectedIndexChanged);
			// 
			// cmd_aircraft_all_contact_change
			// 
			cmd_aircraft_all_contact_change.AllowDrop = true;
			cmd_aircraft_all_contact_change.BackColor = System.Drawing.SystemColors.Control;
			cmd_aircraft_all_contact_change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_aircraft_all_contact_change.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_aircraft_all_contact_change.Location = new System.Drawing.Point(358, 257);
			cmd_aircraft_all_contact_change.Name = "cmd_aircraft_all_contact_change";
			cmd_aircraft_all_contact_change.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_aircraft_all_contact_change.Size = new System.Drawing.Size(214, 23);
			cmd_aircraft_all_contact_change.TabIndex = 348;
			cmd_aircraft_all_contact_change.Text = "Change All Contacts for All Aircraft";
			cmd_aircraft_all_contact_change.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_aircraft_all_contact_change.UseVisualStyleBackColor = false;
			cmd_aircraft_all_contact_change.Click += new System.EventHandler(cmd_aircraft_all_contact_change_Click);
			cmd_aircraft_all_contact_change.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_aircraft_all_contact_change_MouseUp);
			// 
			// cmd_aircraft_contact_change
			// 
			cmd_aircraft_contact_change.AllowDrop = true;
			cmd_aircraft_contact_change.BackColor = System.Drawing.SystemColors.Control;
			cmd_aircraft_contact_change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_aircraft_contact_change.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_aircraft_contact_change.Location = new System.Drawing.Point(360, 226);
			cmd_aircraft_contact_change.Name = "cmd_aircraft_contact_change";
			cmd_aircraft_contact_change.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_aircraft_contact_change.Size = new System.Drawing.Size(214, 25);
			cmd_aircraft_contact_change.TabIndex = 349;
			cmd_aircraft_contact_change.Text = "Change Selected Contact for This Aircraft";
			cmd_aircraft_contact_change.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_aircraft_contact_change.UseVisualStyleBackColor = false;
			cmd_aircraft_contact_change.Click += new System.EventHandler(cmd_aircraft_contact_change_Click);
			cmd_aircraft_contact_change.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_aircraft_contact_change_MouseUp);
			// 
			// _txt_gen_3
			// 
			_txt_gen_3.AcceptsReturn = true;
			_txt_gen_3.AllowDrop = true;
			_txt_gen_3.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			_txt_gen_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_3.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_3.ForeColor = System.Drawing.Color.Black;
			_txt_gen_3.Location = new System.Drawing.Point(30, 245);
			_txt_gen_3.MaxLength = 0;
			_txt_gen_3.Name = "_txt_gen_3";
			_txt_gen_3.ReadOnly = true;
			_txt_gen_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_3.Size = new System.Drawing.Size(163, 16);
			_txt_gen_3.TabIndex = 350;
			_txt_gen_3.Tag = "N";
			_txt_gen_3.Text = " Green = Available";
			// 
			// _txt_gen_8
			// 
			_txt_gen_8.AcceptsReturn = true;
			_txt_gen_8.AllowDrop = true;
			_txt_gen_8.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			_txt_gen_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_8.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_8.ForeColor = System.Drawing.Color.Black;
			_txt_gen_8.Location = new System.Drawing.Point(30, 226);
			_txt_gen_8.MaxLength = 0;
			_txt_gen_8.Name = "_txt_gen_8";
			_txt_gen_8.ReadOnly = true;
			_txt_gen_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_8.Size = new System.Drawing.Size(163, 16);
			_txt_gen_8.TabIndex = 351;
			_txt_gen_8.Tag = "N";
			_txt_gen_8.Text = " Yellow = Primary Company";
			// 
			// txt_only_show_first_aircraft_recs
			// 
			txt_only_show_first_aircraft_recs.AcceptsReturn = true;
			txt_only_show_first_aircraft_recs.AllowDrop = true;
			txt_only_show_first_aircraft_recs.BackColor = System.Drawing.SystemColors.Window;
			txt_only_show_first_aircraft_recs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_only_show_first_aircraft_recs.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_only_show_first_aircraft_recs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_only_show_first_aircraft_recs.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_only_show_first_aircraft_recs.Location = new System.Drawing.Point(308, 41);
			txt_only_show_first_aircraft_recs.MaxLength = 0;
			txt_only_show_first_aircraft_recs.Name = "txt_only_show_first_aircraft_recs";
			txt_only_show_first_aircraft_recs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_only_show_first_aircraft_recs.Size = new System.Drawing.Size(36, 19);
			txt_only_show_first_aircraft_recs.TabIndex = 359;
			txt_only_show_first_aircraft_recs.Text = "10";
			txt_only_show_first_aircraft_recs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// chk_limit_aircraft_list
			// 
			chk_limit_aircraft_list.AllowDrop = true;
			chk_limit_aircraft_list.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_limit_aircraft_list.BackColor = System.Drawing.SystemColors.Control;
			chk_limit_aircraft_list.CausesValidation = true;
			chk_limit_aircraft_list.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_limit_aircraft_list.CheckState = System.Windows.Forms.CheckState.Checked;
			chk_limit_aircraft_list.Enabled = true;
			chk_limit_aircraft_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_limit_aircraft_list.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_limit_aircraft_list.Location = new System.Drawing.Point(205, 44);
			chk_limit_aircraft_list.Name = "chk_limit_aircraft_list";
			chk_limit_aircraft_list.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_limit_aircraft_list.Size = new System.Drawing.Size(96, 13);
			chk_limit_aircraft_list.TabIndex = 360;
			chk_limit_aircraft_list.TabStop = true;
			chk_limit_aircraft_list.Text = "Only Show First";
			chk_limit_aircraft_list.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_limit_aircraft_list.Visible = true;
			// 
			// txt_total_aircraft
			// 
			txt_total_aircraft.AcceptsReturn = true;
			txt_total_aircraft.AllowDrop = true;
			txt_total_aircraft.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_total_aircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_total_aircraft.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_total_aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_total_aircraft.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_total_aircraft.Location = new System.Drawing.Point(366, 41);
			txt_total_aircraft.MaxLength = 0;
			txt_total_aircraft.Name = "txt_total_aircraft";
			txt_total_aircraft.ReadOnly = true;
			txt_total_aircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_total_aircraft.Size = new System.Drawing.Size(41, 19);
			txt_total_aircraft.TabIndex = 361;
			txt_total_aircraft.Tag = "N";
			txt_total_aircraft.Text = "1";
			txt_total_aircraft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _tab_company_details_TabPage1
			// 
			_tab_company_details_TabPage1.Controls.Add(_lbl_comp_35);
			_tab_company_details_TabPage1.Controls.Add(_lbl_comp_97);
			_tab_company_details_TabPage1.Controls.Add(_lbl_comp_86);
			_tab_company_details_TabPage1.Controls.Add(_lbl_comp_85);
			_tab_company_details_TabPage1.Controls.Add(_shp_dealer_background_8);
			_tab_company_details_TabPage1.Controls.Add(_lbl_comp_109);
			_tab_company_details_TabPage1.Controls.Add(grd_company_contacts);
			_tab_company_details_TabPage1.Controls.Add(pnl_company_contact_details);
			_tab_company_details_TabPage1.Controls.Add(_txt_market_note_7);
			_tab_company_details_TabPage1.Controls.Add(_chk_array_5);
			_tab_company_details_TabPage1.Controls.Add(_btn_array_3);
			_tab_company_details_TabPage1.Controls.Add(_btn_array_2);
			_tab_company_details_TabPage1.Controls.Add(cbo_order_by);
			_tab_company_details_TabPage1.Controls.Add(cmd_contact_seq_down);
			_tab_company_details_TabPage1.Controls.Add(cmd_contact_seq_up);
			_tab_company_details_TabPage1.Controls.Add(_chk_array_0);
			_tab_company_details_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_details_TabPage1.Text = "Contacts";
			// 
			// _lbl_comp_35
			// 
			_lbl_comp_35.AllowDrop = true;
			_lbl_comp_35.AutoSize = true;
			_lbl_comp_35.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_35.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_35.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_35.Location = new System.Drawing.Point(214, 292);
			_lbl_comp_35.MinimumSize = new System.Drawing.Size(28, 13);
			_lbl_comp_35.Name = "_lbl_comp_35";
			_lbl_comp_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_35.Size = new System.Drawing.Size(28, 13);
			_lbl_comp_35.TabIndex = 370;
			_lbl_comp_35.Text = "Email:";
			_lbl_comp_35.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_35.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_35.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_35.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_97
			// 
			_lbl_comp_97.AllowDrop = true;
			_lbl_comp_97.AutoSize = true;
			_lbl_comp_97.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_97.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_97.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_97.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_97.Location = new System.Drawing.Point(262, 40);
			_lbl_comp_97.MinimumSize = new System.Drawing.Size(44, 13);
			_lbl_comp_97.Name = "_lbl_comp_97";
			_lbl_comp_97.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_97.Size = new System.Drawing.Size(44, 13);
			_lbl_comp_97.TabIndex = 373;
			_lbl_comp_97.Text = "Order By:";
			_lbl_comp_97.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_97.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_97.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_97.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_86
			// 
			_lbl_comp_86.AllowDrop = true;
			_lbl_comp_86.AutoSize = true;
			_lbl_comp_86.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_86.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_86.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_86.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_86.Location = new System.Drawing.Point(391, 40);
			_lbl_comp_86.MinimumSize = new System.Drawing.Size(72, 13);
			_lbl_comp_86.Name = "_lbl_comp_86";
			_lbl_comp_86.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_86.Size = new System.Drawing.Size(72, 13);
			_lbl_comp_86.TabIndex = 374;
			_lbl_comp_86.Text = "Total Contacts:";
			_lbl_comp_86.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_86.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_86.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_86.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_85
			// 
			_lbl_comp_85.AllowDrop = true;
			_lbl_comp_85.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_85.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_comp_85.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_85.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_85.Location = new System.Drawing.Point(468, 37);
			_lbl_comp_85.MinimumSize = new System.Drawing.Size(76, 19);
			_lbl_comp_85.Name = "_lbl_comp_85";
			_lbl_comp_85.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_85.Size = new System.Drawing.Size(76, 19);
			_lbl_comp_85.TabIndex = 375;
			_lbl_comp_85.Text = "Label85";
			_lbl_comp_85.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_85.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_85.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _shp_dealer_background_8
			// 
			_shp_dealer_background_8.AllowDrop = true;
			_shp_dealer_background_8.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_8.BackStyle = 1;
			_shp_dealer_background_8.BorderStyle = 0;
			_shp_dealer_background_8.Enabled = false;
			_shp_dealer_background_8.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_8.FillStyle = 1;
			_shp_dealer_background_8.Location = new System.Drawing.Point(0, 24);
			_shp_dealer_background_8.Name = "_shp_dealer_background_8";
			_shp_dealer_background_8.Size = new System.Drawing.Size(1003, 298);
			_shp_dealer_background_8.Visible = false;
			// 
			// _lbl_comp_109
			// 
			_lbl_comp_109.AllowDrop = true;
			_lbl_comp_109.AutoSize = true;
			_lbl_comp_109.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_109.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_109.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_109.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_109.Location = new System.Drawing.Point(8, 300);
			_lbl_comp_109.MinimumSize = new System.Drawing.Size(148, 13);
			_lbl_comp_109.Name = "_lbl_comp_109";
			_lbl_comp_109.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_109.Size = new System.Drawing.Size(148, 13);
			_lbl_comp_109.TabIndex = 369;
			_lbl_comp_109.Text = "View Company/Contact Events";
			_lbl_comp_109.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_109.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_109.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_109.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// grd_company_contacts
			// 
			grd_company_contacts.AllowDrop = true;
			grd_company_contacts.AllowUserToAddRows = false;
			grd_company_contacts.AllowUserToDeleteRows = false;
			grd_company_contacts.AllowUserToResizeColumns = false;
			grd_company_contacts.AllowUserToResizeColumns = grd_company_contacts.ColumnHeadersVisible;
			grd_company_contacts.AllowUserToResizeRows = false;
			grd_company_contacts.AllowUserToResizeRows = false;
			grd_company_contacts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_contacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_contacts.ColumnsCount = 2;
			grd_company_contacts.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
			grd_company_contacts.FixedColumns = 0;
			grd_company_contacts.FixedRows = 1;
			grd_company_contacts.Location = new System.Drawing.Point(6, 68);
			grd_company_contacts.Name = "grd_company_contacts";
			grd_company_contacts.ReadOnly = true;
			grd_company_contacts.RowsCount = 2;
			grd_company_contacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_company_contacts.ShowCellToolTips = false;
			grd_company_contacts.Size = new System.Drawing.Size(596, 222);
			grd_company_contacts.StandardTab = true;
			grd_company_contacts.TabIndex = 356;
			grd_company_contacts.Click += new System.EventHandler(grd_company_contacts_Click);
			grd_company_contacts.DoubleClick += new System.EventHandler(grd_company_contacts_DoubleClick);
			// 
			// pnl_company_contact_details
			// 
			pnl_company_contact_details.AllowDrop = true;
			pnl_company_contact_details.BackColor = System.Drawing.SystemColors.Control;
			pnl_company_contact_details.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_company_contact_details.Controls.Add(chk_contact_research_flag);
			pnl_company_contact_details.Controls.Add(chk_contact_active_flag);
			pnl_company_contact_details.Controls.Add(txt_contact_description);
			pnl_company_contact_details.Controls.Add(cbo_contact_suffix);
			pnl_company_contact_details.Controls.Add(txt_contact_last_name);
			pnl_company_contact_details.Controls.Add(txt_contact_middle_initial);
			pnl_company_contact_details.Controls.Add(txt_contact_first_name);
			pnl_company_contact_details.Controls.Add(txt_contact_email_address);
			pnl_company_contact_details.Controls.Add(cbo_contact_title);
			pnl_company_contact_details.Controls.Add(cbo_contact_sirname);
			pnl_company_contact_details.Controls.Add(txt_contact_id);
			pnl_company_contact_details.Controls.Add(chk_contact_hide_flag);
			pnl_company_contact_details.Controls.Add(cmd_EditMailList);
			pnl_company_contact_details.Controls.Add(cmbContactEMail);
			pnl_company_contact_details.Controls.Add(_btn_array_0);
			pnl_company_contact_details.Controls.Add(_btn_array_1);
			pnl_company_contact_details.Controls.Add(_txt_market_note_5);
			pnl_company_contact_details.Controls.Add(grd_contact_phone_numbers);
			pnl_company_contact_details.Controls.Add(_lbl_comp_68);
			pnl_company_contact_details.Controls.Add(_lbl_comp_67);
			pnl_company_contact_details.Controls.Add(_lbl_comp_69);
			pnl_company_contact_details.Controls.Add(_lbl_comp_300);
			pnl_company_contact_details.Controls.Add(_lbl_comp_77);
			pnl_company_contact_details.Controls.Add(_lbl_comp_91);
			pnl_company_contact_details.Controls.Add(_lbl_comp_1);
			pnl_company_contact_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_company_contact_details.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_company_contact_details.Location = new System.Drawing.Point(656, 28);
			pnl_company_contact_details.Name = "pnl_company_contact_details";
			pnl_company_contact_details.Size = new System.Drawing.Size(355, 288);
			pnl_company_contact_details.TabIndex = 301;
			// 
			// chk_contact_research_flag
			// 
			chk_contact_research_flag.AllowDrop = true;
			chk_contact_research_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_contact_research_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_contact_research_flag.CausesValidation = true;
			chk_contact_research_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_contact_research_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_contact_research_flag.Enabled = true;
			chk_contact_research_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_contact_research_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_contact_research_flag.Location = new System.Drawing.Point(230, 32);
			chk_contact_research_flag.Name = "chk_contact_research_flag";
			chk_contact_research_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_contact_research_flag.Size = new System.Drawing.Size(115, 13);
			chk_contact_research_flag.TabIndex = 318;
			chk_contact_research_flag.TabStop = true;
			chk_contact_research_flag.Text = "Research Contact?";
			chk_contact_research_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_contact_research_flag.Visible = true;
			// 
			// chk_contact_active_flag
			// 
			chk_contact_active_flag.AllowDrop = true;
			chk_contact_active_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_contact_active_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_contact_active_flag.CausesValidation = true;
			chk_contact_active_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_contact_active_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_contact_active_flag.Enabled = true;
			chk_contact_active_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_contact_active_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_contact_active_flag.Location = new System.Drawing.Point(97, 8);
			chk_contact_active_flag.Name = "chk_contact_active_flag";
			chk_contact_active_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_contact_active_flag.Size = new System.Drawing.Size(56, 13);
			chk_contact_active_flag.TabIndex = 317;
			chk_contact_active_flag.TabStop = true;
			chk_contact_active_flag.Text = "Active?";
			chk_contact_active_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_contact_active_flag.Visible = true;
			// 
			// txt_contact_description
			// 
			txt_contact_description.AcceptsReturn = true;
			txt_contact_description.AllowDrop = true;
			txt_contact_description.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_description.Location = new System.Drawing.Point(6, 211);
			txt_contact_description.MaxLength = 0;
			txt_contact_description.Multiline = true;
			txt_contact_description.Name = "txt_contact_description";
			txt_contact_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_description.Size = new System.Drawing.Size(342, 45);
			txt_contact_description.TabIndex = 316;
			// 
			// cbo_contact_suffix
			// 
			cbo_contact_suffix.AllowDrop = true;
			cbo_contact_suffix.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact_suffix.CausesValidation = true;
			cbo_contact_suffix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			cbo_contact_suffix.Enabled = true;
			cbo_contact_suffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact_suffix.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact_suffix.IntegralHeight = true;
			cbo_contact_suffix.Location = new System.Drawing.Point(289, 65);
			cbo_contact_suffix.Name = "cbo_contact_suffix";
			cbo_contact_suffix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact_suffix.Size = new System.Drawing.Size(60, 21);
			cbo_contact_suffix.Sorted = false;
			cbo_contact_suffix.TabIndex = 315;
			cbo_contact_suffix.TabStop = true;
			cbo_contact_suffix.Text = "cbo_contact_suffix";
			cbo_contact_suffix.Visible = true;
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
			txt_contact_last_name.Location = new System.Drawing.Point(171, 65);
			txt_contact_last_name.MaxLength = 0;
			txt_contact_last_name.Name = "txt_contact_last_name";
			txt_contact_last_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_last_name.Size = new System.Drawing.Size(114, 21);
			txt_contact_last_name.TabIndex = 314;
			// 
			// txt_contact_middle_initial
			// 
			txt_contact_middle_initial.AcceptsReturn = true;
			txt_contact_middle_initial.AllowDrop = true;
			txt_contact_middle_initial.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_middle_initial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_middle_initial.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_middle_initial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_middle_initial.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_middle_initial.Location = new System.Drawing.Point(147, 65);
			txt_contact_middle_initial.MaxLength = 1;
			txt_contact_middle_initial.Name = "txt_contact_middle_initial";
			txt_contact_middle_initial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_middle_initial.Size = new System.Drawing.Size(20, 21);
			txt_contact_middle_initial.TabIndex = 313;
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
			txt_contact_first_name.Location = new System.Drawing.Point(78, 65);
			txt_contact_first_name.MaxLength = 0;
			txt_contact_first_name.Name = "txt_contact_first_name";
			txt_contact_first_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_first_name.Size = new System.Drawing.Size(65, 21);
			txt_contact_first_name.TabIndex = 312;
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
			txt_contact_email_address.Location = new System.Drawing.Point(43, 89);
			txt_contact_email_address.MaxLength = 0;
			txt_contact_email_address.Name = "txt_contact_email_address";
			txt_contact_email_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_email_address.Size = new System.Drawing.Size(214, 21);
			txt_contact_email_address.TabIndex = 311;
			txt_contact_email_address.DoubleClick += new System.EventHandler(txt_contact_email_address_DoubleClick);
			txt_contact_email_address.TextChanged += new System.EventHandler(txt_contact_email_address_TextChanged);
			// 
			// cbo_contact_title
			// 
			cbo_contact_title.AllowDrop = true;
			cbo_contact_title.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact_title.CausesValidation = true;
			cbo_contact_title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			cbo_contact_title.Enabled = true;
			cbo_contact_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact_title.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact_title.IntegralHeight = true;
			cbo_contact_title.Location = new System.Drawing.Point(36, 28);
			cbo_contact_title.Name = "cbo_contact_title";
			cbo_contact_title.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact_title.Size = new System.Drawing.Size(177, 21);
			cbo_contact_title.Sorted = false;
			cbo_contact_title.TabIndex = 310;
			cbo_contact_title.TabStop = true;
			cbo_contact_title.Text = "cbo_contact_title";
			cbo_contact_title.Visible = true;
			// 
			// cbo_contact_sirname
			// 
			cbo_contact_sirname.AllowDrop = true;
			cbo_contact_sirname.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact_sirname.CausesValidation = true;
			cbo_contact_sirname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			cbo_contact_sirname.Enabled = true;
			cbo_contact_sirname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact_sirname.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact_sirname.IntegralHeight = true;
			cbo_contact_sirname.Location = new System.Drawing.Point(9, 65);
			cbo_contact_sirname.Name = "cbo_contact_sirname";
			cbo_contact_sirname.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact_sirname.Size = new System.Drawing.Size(65, 21);
			cbo_contact_sirname.Sorted = false;
			cbo_contact_sirname.TabIndex = 309;
			cbo_contact_sirname.TabStop = true;
			cbo_contact_sirname.Text = "cbo_contact_sirname";
			cbo_contact_sirname.Visible = true;
			// 
			// txt_contact_id
			// 
			txt_contact_id.AcceptsReturn = true;
			txt_contact_id.AllowDrop = true;
			txt_contact_id.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_contact_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_id.Enabled = false;
			txt_contact_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_id.Location = new System.Drawing.Point(36, 5);
			txt_contact_id.MaxLength = 0;
			txt_contact_id.Name = "txt_contact_id";
			txt_contact_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_id.Size = new System.Drawing.Size(57, 19);
			txt_contact_id.TabIndex = 308;
			txt_contact_id.Tag = "N";
			txt_contact_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chk_contact_hide_flag
			// 
			chk_contact_hide_flag.AllowDrop = true;
			chk_contact_hide_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_contact_hide_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_contact_hide_flag.CausesValidation = true;
			chk_contact_hide_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_contact_hide_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_contact_hide_flag.Enabled = true;
			chk_contact_hide_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_contact_hide_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_contact_hide_flag.Location = new System.Drawing.Point(158, 8);
			chk_contact_hide_flag.Name = "chk_contact_hide_flag";
			chk_contact_hide_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_contact_hide_flag.Size = new System.Drawing.Size(187, 13);
			chk_contact_hide_flag.TabIndex = 307;
			chk_contact_hide_flag.TabStop = true;
			chk_contact_hide_flag.Text = "Internal Only (Hide from Customer)?";
			chk_contact_hide_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_contact_hide_flag.Visible = true;
			// 
			// cmd_EditMailList
			// 
			cmd_EditMailList.AllowDrop = true;
			cmd_EditMailList.BackColor = System.Drawing.SystemColors.Control;
			cmd_EditMailList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_EditMailList.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_EditMailList.Location = new System.Drawing.Point(262, 90);
			cmd_EditMailList.Name = "cmd_EditMailList";
			cmd_EditMailList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_EditMailList.Size = new System.Drawing.Size(89, 17);
			cmd_EditMailList.TabIndex = 306;
			cmd_EditMailList.Text = "Edit Mailing List";
			cmd_EditMailList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_EditMailList.UseVisualStyleBackColor = false;
			cmd_EditMailList.Click += new System.EventHandler(cmd_EditMailList_Click);
			// 
			// cmbContactEMail
			// 
			cmbContactEMail.AllowDrop = true;
			cmbContactEMail.BackColor = System.Drawing.SystemColors.Window;
			cmbContactEMail.CausesValidation = true;
			cmbContactEMail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmbContactEMail.Enabled = true;
			cmbContactEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbContactEMail.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbContactEMail.IntegralHeight = true;
			cmbContactEMail.Location = new System.Drawing.Point(172, 260);
			cmbContactEMail.Name = "cmbContactEMail";
			cmbContactEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbContactEMail.Size = new System.Drawing.Size(179, 21);
			cmbContactEMail.Sorted = false;
			cmbContactEMail.TabIndex = 305;
			cmbContactEMail.TabStop = true;
			cmbContactEMail.Visible = true;
			cmbContactEMail.SelectedIndexChanged += new System.EventHandler(cmbContactEMail_SelectedIndexChanged);
			// 
			// _btn_array_0
			// 
			_btn_array_0.AllowDrop = true;
			_btn_array_0.BackColor = System.Drawing.SystemColors.Control;
			_btn_array_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_btn_array_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_btn_array_0.Location = new System.Drawing.Point(50, 262);
			_btn_array_0.Name = "_btn_array_0";
			_btn_array_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_btn_array_0.Size = new System.Drawing.Size(45, 21);
			_btn_array_0.TabIndex = 304;
			_btn_array_0.Text = "Confirm";
			_btn_array_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_btn_array_0.UseVisualStyleBackColor = false;
			_btn_array_0.Click += new System.EventHandler(btn_array_Click);
			// 
			// _btn_array_1
			// 
			_btn_array_1.AllowDrop = true;
			_btn_array_1.BackColor = System.Drawing.SystemColors.Control;
			_btn_array_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_btn_array_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_btn_array_1.Location = new System.Drawing.Point(6, 262);
			_btn_array_1.Name = "_btn_array_1";
			_btn_array_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_btn_array_1.Size = new System.Drawing.Size(33, 21);
			_btn_array_1.TabIndex = 303;
			_btn_array_1.Text = "Edit";
			_btn_array_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_btn_array_1.UseVisualStyleBackColor = false;
			_btn_array_1.Click += new System.EventHandler(btn_array_Click);
			// 
			// _txt_market_note_5
			// 
			_txt_market_note_5.AcceptsReturn = true;
			_txt_market_note_5.AllowDrop = true;
			_txt_market_note_5.BackColor = System.Drawing.SystemColors.Window;
			_txt_market_note_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_market_note_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_market_note_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_market_note_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_market_note_5.Location = new System.Drawing.Point(96, 112);
			_txt_market_note_5.MaxLength = 0;
			_txt_market_note_5.Multiline = true;
			_txt_market_note_5.Name = "_txt_market_note_5";
			_txt_market_note_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_market_note_5.Size = new System.Drawing.Size(214, 21);
			_txt_market_note_5.TabIndex = 302;
			_txt_market_note_5.DoubleClick += new System.EventHandler(txt_market_note_DoubleClick);
			_txt_market_note_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_market_note_KeyPress);
			_txt_market_note_5.TextChanged += new System.EventHandler(txt_market_note_TextChanged);
			// 
			// grd_contact_phone_numbers
			// 
			grd_contact_phone_numbers.AllowDrop = true;
			grd_contact_phone_numbers.AllowUserToAddRows = false;
			grd_contact_phone_numbers.AllowUserToDeleteRows = false;
			grd_contact_phone_numbers.AllowUserToResizeColumns = false;
			grd_contact_phone_numbers.AllowUserToResizeColumns = grd_contact_phone_numbers.ColumnHeadersVisible;
			grd_contact_phone_numbers.AllowUserToResizeRows = false;
			grd_contact_phone_numbers.AllowUserToResizeRows = false;
			grd_contact_phone_numbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_contact_phone_numbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_contact_phone_numbers.ColumnsCount = 2;
			grd_contact_phone_numbers.FixedColumns = 0;
			grd_contact_phone_numbers.FixedRows = 1;
			grd_contact_phone_numbers.Location = new System.Drawing.Point(8, 136);
			grd_contact_phone_numbers.Name = "grd_contact_phone_numbers";
			grd_contact_phone_numbers.ReadOnly = true;
			grd_contact_phone_numbers.RowsCount = 2;
			grd_contact_phone_numbers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_contact_phone_numbers.ShowCellToolTips = false;
			grd_contact_phone_numbers.Size = new System.Drawing.Size(342, 65);
			grd_contact_phone_numbers.StandardTab = true;
			grd_contact_phone_numbers.TabIndex = 319;
			grd_contact_phone_numbers.DoubleClick += new System.EventHandler(grd_contact_phone_numbers_DoubleClick);
			grd_contact_phone_numbers.MouseDown += new System.Windows.Forms.MouseEventHandler(grd_Contact_Phone_Numbers_MouseDown);
			// 
			// _lbl_comp_68
			// 
			_lbl_comp_68.AllowDrop = true;
			_lbl_comp_68.AutoSize = true;
			_lbl_comp_68.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_68.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_68.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_68.Location = new System.Drawing.Point(26, 51);
			_lbl_comp_68.MinimumSize = new System.Drawing.Size(307, 13);
			_lbl_comp_68.Name = "_lbl_comp_68";
			_lbl_comp_68.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_68.Size = new System.Drawing.Size(307, 13);
			_lbl_comp_68.TabIndex = 326;
			_lbl_comp_68.Text = "Prefix:               First:          M.                 Last:                      Suffix:";
			_lbl_comp_68.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_68.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_68.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_67
			// 
			_lbl_comp_67.AllowDrop = true;
			_lbl_comp_67.AutoSize = true;
			_lbl_comp_67.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_67.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_67.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_67.Location = new System.Drawing.Point(9, 93);
			_lbl_comp_67.MinimumSize = new System.Drawing.Size(31, 13);
			_lbl_comp_67.Name = "_lbl_comp_67";
			_lbl_comp_67.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_67.Size = new System.Drawing.Size(31, 13);
			_lbl_comp_67.TabIndex = 325;
			_lbl_comp_67.Text = "E-mail:";
			_lbl_comp_67.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_67.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_67.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_69
			// 
			_lbl_comp_69.AllowDrop = true;
			_lbl_comp_69.AutoSize = true;
			_lbl_comp_69.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_69.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_69.ForeColor = System.Drawing.Color.Black;
			_lbl_comp_69.Location = new System.Drawing.Point(9, 32);
			_lbl_comp_69.MinimumSize = new System.Drawing.Size(23, 13);
			_lbl_comp_69.Name = "_lbl_comp_69";
			_lbl_comp_69.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_69.Size = new System.Drawing.Size(23, 13);
			_lbl_comp_69.TabIndex = 324;
			_lbl_comp_69.Text = "Title:";
			_lbl_comp_69.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_69.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_69.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_300
			// 
			_lbl_comp_300.AllowDrop = true;
			_lbl_comp_300.AutoSize = true;
			_lbl_comp_300.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_300.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_300.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_300.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_300.Location = new System.Drawing.Point(9, 8);
			_lbl_comp_300.MinimumSize = new System.Drawing.Size(21, 13);
			_lbl_comp_300.Name = "_lbl_comp_300";
			_lbl_comp_300.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_300.Size = new System.Drawing.Size(21, 13);
			_lbl_comp_300.TabIndex = 323;
			_lbl_comp_300.Text = "ID#:";
			_lbl_comp_300.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_300.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_300.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_77
			// 
			_lbl_comp_77.AllowDrop = true;
			_lbl_comp_77.AutoSize = true;
			_lbl_comp_77.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_77.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_77.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_77.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_77.Location = new System.Drawing.Point(8, 200);
			_lbl_comp_77.MinimumSize = new System.Drawing.Size(55, 11);
			_lbl_comp_77.Name = "_lbl_comp_77";
			_lbl_comp_77.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_77.Size = new System.Drawing.Size(55, 11);
			_lbl_comp_77.TabIndex = 322;
			_lbl_comp_77.Text = "Description:";
			_lbl_comp_77.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_77.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_77.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_91
			// 
			_lbl_comp_91.AllowDrop = true;
			_lbl_comp_91.AutoSize = true;
			_lbl_comp_91.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_91.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_91.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_91.ForeColor = System.Drawing.Color.Blue;
			_lbl_comp_91.Location = new System.Drawing.Point(104, 265);
			_lbl_comp_91.MinimumSize = new System.Drawing.Size(60, 13);
			_lbl_comp_91.Name = "_lbl_comp_91";
			_lbl_comp_91.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_91.Size = new System.Drawing.Size(60, 13);
			_lbl_comp_91.TabIndex = 321;
			_lbl_comp_91.Text = "EMail Notice";
			_lbl_comp_91.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_91.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_91.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_91.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_1
			// 
			_lbl_comp_1.AllowDrop = true;
			_lbl_comp_1.AutoSize = true;
			_lbl_comp_1.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_1.Location = new System.Drawing.Point(8, 117);
			_lbl_comp_1.MinimumSize = new System.Drawing.Size(80, 13);
			_lbl_comp_1.Name = "_lbl_comp_1";
			_lbl_comp_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_1.Size = new System.Drawing.Size(80, 13);
			_lbl_comp_1.TabIndex = 320;
			_lbl_comp_1.Text = "Research E-mail:";
			_lbl_comp_1.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_1.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_1.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _txt_market_note_7
			// 
			_txt_market_note_7.AcceptsReturn = true;
			_txt_market_note_7.AllowDrop = true;
			_txt_market_note_7.BackColor = System.Drawing.SystemColors.Window;
			_txt_market_note_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_market_note_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_market_note_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_market_note_7.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_market_note_7.Location = new System.Drawing.Point(248, 289);
			_txt_market_note_7.MaxLength = 0;
			_txt_market_note_7.Multiline = true;
			_txt_market_note_7.Name = "_txt_market_note_7";
			_txt_market_note_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_market_note_7.Size = new System.Drawing.Size(374, 21);
			_txt_market_note_7.TabIndex = 244;
			_txt_market_note_7.Visible = false;
			_txt_market_note_7.DoubleClick += new System.EventHandler(txt_market_note_DoubleClick);
			_txt_market_note_7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_market_note_KeyPress);
			_txt_market_note_7.TextChanged += new System.EventHandler(txt_market_note_TextChanged);
			// 
			// _chk_array_5
			// 
			_chk_array_5.AllowDrop = true;
			_chk_array_5.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_array_5.BackColor = System.Drawing.SystemColors.Control;
			_chk_array_5.CausesValidation = true;
			_chk_array_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_array_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_array_5.Enabled = false;
			_chk_array_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_array_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_array_5.Location = new System.Drawing.Point(584, 289);
			_chk_array_5.Name = "_chk_array_5";
			_chk_array_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_array_5.Size = new System.Drawing.Size(55, 21);
			_chk_array_5.TabIndex = 245;
			_chk_array_5.TabStop = true;
			_chk_array_5.Text = "IQ";
			_chk_array_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_array_5.Visible = false;
			_chk_array_5.CheckStateChanged += new System.EventHandler(chk_array_CheckStateChanged);
			// 
			// _btn_array_3
			// 
			_btn_array_3.AllowDrop = true;
			_btn_array_3.BackColor = System.Drawing.SystemColors.Control;
			_btn_array_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_btn_array_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_btn_array_3.Location = new System.Drawing.Point(8, 36);
			_btn_array_3.Name = "_btn_array_3";
			_btn_array_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_btn_array_3.Size = new System.Drawing.Size(95, 21);
			_btn_array_3.TabIndex = 286;
			_btn_array_3.Text = "Add Contact";
			_btn_array_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_btn_array_3.UseVisualStyleBackColor = false;
			_btn_array_3.Click += new System.EventHandler(btn_array_Click);
			// 
			// _btn_array_2
			// 
			_btn_array_2.AllowDrop = true;
			_btn_array_2.BackColor = System.Drawing.SystemColors.Control;
			_btn_array_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_btn_array_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_btn_array_2.Location = new System.Drawing.Point(550, 38);
			_btn_array_2.Name = "_btn_array_2";
			_btn_array_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_btn_array_2.Size = new System.Drawing.Size(95, 21);
			_btn_array_2.TabIndex = 287;
			_btn_array_2.Text = "Save SEQ Order";
			_btn_array_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_btn_array_2.UseVisualStyleBackColor = false;
			_btn_array_2.Click += new System.EventHandler(btn_array_Click);
			// 
			// cbo_order_by
			// 
			cbo_order_by.AllowDrop = true;
			cbo_order_by.BackColor = System.Drawing.SystemColors.Window;
			cbo_order_by.CausesValidation = true;
			cbo_order_by.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_order_by.Enabled = true;
			cbo_order_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_order_by.ForeColor = System.Drawing.Color.Black;
			cbo_order_by.IntegralHeight = true;
			cbo_order_by.Location = new System.Drawing.Point(310, 36);
			cbo_order_by.Name = "cbo_order_by";
			cbo_order_by.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_order_by.Size = new System.Drawing.Size(81, 21);
			cbo_order_by.Sorted = false;
			cbo_order_by.TabIndex = 299;
			cbo_order_by.TabStop = true;
			cbo_order_by.Visible = true;
			cbo_order_by.SelectionChangeCommitted += new System.EventHandler(cbo_order_by_SelectionChangeCommitted);
			// 
			// cmd_contact_seq_down
			// 
			cmd_contact_seq_down.AllowDrop = true;
			cmd_contact_seq_down.BackColor = System.Drawing.SystemColors.Control;
			cmd_contact_seq_down.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_contact_seq_down.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_contact_seq_down.Image = (System.Drawing.Image) resources.GetObject("cmd_contact_seq_down.Image");
			cmd_contact_seq_down.Location = new System.Drawing.Point(606, 127);
			cmd_contact_seq_down.Name = "cmd_contact_seq_down";
			cmd_contact_seq_down.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_contact_seq_down.Size = new System.Drawing.Size(31, 42);
			cmd_contact_seq_down.TabIndex = 334;
			cmd_contact_seq_down.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_contact_seq_down.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_contact_seq_down.UseVisualStyleBackColor = false;
			cmd_contact_seq_down.Click += new System.EventHandler(cmd_contact_seq_down_Click);
			cmd_contact_seq_down.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_contact_seq_down_MouseUp);
			// 
			// cmd_contact_seq_up
			// 
			cmd_contact_seq_up.AllowDrop = true;
			cmd_contact_seq_up.BackColor = System.Drawing.SystemColors.Control;
			cmd_contact_seq_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_contact_seq_up.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_contact_seq_up.Image = (System.Drawing.Image) resources.GetObject("cmd_contact_seq_up.Image");
			cmd_contact_seq_up.Location = new System.Drawing.Point(606, 75);
			cmd_contact_seq_up.Name = "cmd_contact_seq_up";
			cmd_contact_seq_up.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_contact_seq_up.Size = new System.Drawing.Size(31, 42);
			cmd_contact_seq_up.TabIndex = 335;
			cmd_contact_seq_up.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_contact_seq_up.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_contact_seq_up.UseVisualStyleBackColor = false;
			cmd_contact_seq_up.Click += new System.EventHandler(cmd_contact_seq_up_Click);
			cmd_contact_seq_up.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_contact_seq_up_MouseUp);
			// 
			// _chk_array_0
			// 
			_chk_array_0.AllowDrop = true;
			_chk_array_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_array_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_array_0.CausesValidation = true;
			_chk_array_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_array_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_array_0.Enabled = true;
			_chk_array_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_array_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_array_0.Location = new System.Drawing.Point(110, 40);
			_chk_array_0.Name = "_chk_array_0";
			_chk_array_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_array_0.Size = new System.Drawing.Size(143, 13);
			_chk_array_0.TabIndex = 340;
			_chk_array_0.TabStop = true;
			_chk_array_0.Text = "Show Inactive Contacts";
			_chk_array_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_array_0.Visible = true;
			_chk_array_0.CheckStateChanged += new System.EventHandler(chk_array_CheckStateChanged);
			// 
			// _tab_company_details_TabPage2
			// 
			_tab_company_details_TabPage2.Controls.Add(_lbl_comp_102);
			_tab_company_details_TabPage2.Controls.Add(_lbl_comp_50);
			_tab_company_details_TabPage2.Controls.Add(_lbl_comp_70);
			_tab_company_details_TabPage2.Controls.Add(_lbl_comp_37);
			_tab_company_details_TabPage2.Controls.Add(_shp_dealer_background_9);
			_tab_company_details_TabPage2.Controls.Add(grd_company_journal);
			_tab_company_details_TabPage2.Controls.Add(txtCompJournalSearch);
			_tab_company_details_TabPage2.Controls.Add(cbo_journal_note_type);
			_tab_company_details_TabPage2.Controls.Add(cmd_company_fill_journal);
			_tab_company_details_TabPage2.Controls.Add(txt_only_show_first_journal_recs);
			_tab_company_details_TabPage2.Controls.Add(chk_limit_journal_list);
			_tab_company_details_TabPage2.Controls.Add(txt_journal_ac_selected);
			_tab_company_details_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_details_TabPage2.Text = "Journal";
			// 
			// _lbl_comp_102
			// 
			_lbl_comp_102.AllowDrop = true;
			_lbl_comp_102.AutoSize = true;
			_lbl_comp_102.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_102.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_102.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_102.ForeColor = System.Drawing.Color.Black;
			_lbl_comp_102.Location = new System.Drawing.Point(12, 22);
			_lbl_comp_102.MinimumSize = new System.Drawing.Size(140, 13);
			_lbl_comp_102.Name = "_lbl_comp_102";
			_lbl_comp_102.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_102.Size = new System.Drawing.Size(140, 13);
			_lbl_comp_102.TabIndex = 371;
			_lbl_comp_102.Text = "Search Journal Subject/Desc";
			_lbl_comp_102.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_102.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_102.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_50
			// 
			_lbl_comp_50.AllowDrop = true;
			_lbl_comp_50.AutoSize = true;
			_lbl_comp_50.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_50.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_50.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_50.Location = new System.Drawing.Point(8, 55);
			_lbl_comp_50.MinimumSize = new System.Drawing.Size(144, 13);
			_lbl_comp_50.Name = "_lbl_comp_50";
			_lbl_comp_50.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_50.Size = new System.Drawing.Size(144, 13);
			_lbl_comp_50.TabIndex = 382;
			_lbl_comp_50.Text = "Type of Journal Entries Shown";
			_lbl_comp_50.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_50.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_50.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_70
			// 
			_lbl_comp_70.AllowDrop = true;
			_lbl_comp_70.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_comp_70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_70.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_70.Location = new System.Drawing.Point(926, 52);
			_lbl_comp_70.MinimumSize = new System.Drawing.Size(76, 19);
			_lbl_comp_70.Name = "_lbl_comp_70";
			_lbl_comp_70.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_70.Size = new System.Drawing.Size(76, 19);
			_lbl_comp_70.TabIndex = 383;
			_lbl_comp_70.Text = "Label70";
			_lbl_comp_70.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_70.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_70.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_37
			// 
			_lbl_comp_37.AllowDrop = true;
			_lbl_comp_37.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_37.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_37.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_37.Location = new System.Drawing.Point(399, 55);
			_lbl_comp_37.MinimumSize = new System.Drawing.Size(62, 13);
			_lbl_comp_37.Name = "_lbl_comp_37";
			_lbl_comp_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_37.Size = new System.Drawing.Size(62, 13);
			_lbl_comp_37.TabIndex = 385;
			_lbl_comp_37.Text = "Aircraft:";
			_lbl_comp_37.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_37.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_37.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_37.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _shp_dealer_background_9
			// 
			_shp_dealer_background_9.AllowDrop = true;
			_shp_dealer_background_9.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_9.BackStyle = 1;
			_shp_dealer_background_9.BorderStyle = 0;
			_shp_dealer_background_9.Enabled = false;
			_shp_dealer_background_9.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_9.FillStyle = 1;
			_shp_dealer_background_9.Location = new System.Drawing.Point(3, 47);
			_shp_dealer_background_9.Name = "_shp_dealer_background_9";
			_shp_dealer_background_9.Size = new System.Drawing.Size(1004, 270);
			_shp_dealer_background_9.Visible = false;
			// 
			// grd_company_journal
			// 
			grd_company_journal.AllowDrop = true;
			grd_company_journal.AllowUserToAddRows = false;
			grd_company_journal.AllowUserToDeleteRows = false;
			grd_company_journal.AllowUserToResizeColumns = false;
			grd_company_journal.AllowUserToResizeColumns = grd_company_journal.ColumnHeadersVisible;
			grd_company_journal.AllowUserToResizeRows = false;
			grd_company_journal.AllowUserToResizeRows = false;
			grd_company_journal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_journal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_journal.ColumnsCount = 2;
			grd_company_journal.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
			grd_company_journal.FixedColumns = 0;
			grd_company_journal.FixedRows = 1;
			grd_company_journal.Location = new System.Drawing.Point(7, 77);
			grd_company_journal.Name = "grd_company_journal";
			grd_company_journal.ReadOnly = true;
			grd_company_journal.RowsCount = 2;
			grd_company_journal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_company_journal.ShowCellToolTips = false;
			grd_company_journal.Size = new System.Drawing.Size(995, 235);
			grd_company_journal.StandardTab = true;
			grd_company_journal.TabIndex = 357;
			grd_company_journal.Click += new System.EventHandler(grd_company_journal_Click);
			grd_company_journal.DoubleClick += new System.EventHandler(grd_company_journal_DoubleClick);
			// 
			// txtCompJournalSearch
			// 
			txtCompJournalSearch.AcceptsReturn = true;
			txtCompJournalSearch.AllowDrop = true;
			txtCompJournalSearch.BackColor = System.Drawing.SystemColors.Window;
			txtCompJournalSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtCompJournalSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompJournalSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompJournalSearch.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompJournalSearch.Location = new System.Drawing.Point(160, 20);
			txtCompJournalSearch.MaxLength = 0;
			txtCompJournalSearch.Name = "txtCompJournalSearch";
			txtCompJournalSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompJournalSearch.Size = new System.Drawing.Size(389, 19);
			txtCompJournalSearch.TabIndex = 285;
			txtCompJournalSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCompJournalSearch_KeyPress);
			// 
			// cbo_journal_note_type
			// 
			cbo_journal_note_type.AllowDrop = true;
			cbo_journal_note_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_journal_note_type.CausesValidation = true;
			cbo_journal_note_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_journal_note_type.Enabled = false;
			cbo_journal_note_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_journal_note_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_journal_note_type.IntegralHeight = true;
			cbo_journal_note_type.Location = new System.Drawing.Point(158, 52);
			cbo_journal_note_type.Name = "cbo_journal_note_type";
			cbo_journal_note_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_journal_note_type.Size = new System.Drawing.Size(232, 21);
			cbo_journal_note_type.Sorted = false;
			cbo_journal_note_type.TabIndex = 333;
			cbo_journal_note_type.TabStop = true;
			cbo_journal_note_type.Visible = true;
			cbo_journal_note_type.SelectedIndexChanged += new System.EventHandler(cbo_journal_note_type_SelectedIndexChanged);
			// 
			// cmd_company_fill_journal
			// 
			cmd_company_fill_journal.AllowDrop = true;
			cmd_company_fill_journal.BackColor = System.Drawing.SystemColors.Control;
			cmd_company_fill_journal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_company_fill_journal.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_company_fill_journal.Location = new System.Drawing.Point(896, 52);
			cmd_company_fill_journal.Name = "cmd_company_fill_journal";
			cmd_company_fill_journal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_company_fill_journal.Size = new System.Drawing.Size(23, 19);
			cmd_company_fill_journal.TabIndex = 336;
			cmd_company_fill_journal.Text = "Go";
			cmd_company_fill_journal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_company_fill_journal.UseVisualStyleBackColor = false;
			cmd_company_fill_journal.Click += new System.EventHandler(cmd_company_fill_journal_Click);
			cmd_company_fill_journal.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_company_fill_journal_MouseUp);
			// 
			// txt_only_show_first_journal_recs
			// 
			txt_only_show_first_journal_recs.AcceptsReturn = true;
			txt_only_show_first_journal_recs.AllowDrop = true;
			txt_only_show_first_journal_recs.BackColor = System.Drawing.SystemColors.Window;
			txt_only_show_first_journal_recs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_only_show_first_journal_recs.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_only_show_first_journal_recs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_only_show_first_journal_recs.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_only_show_first_journal_recs.Location = new System.Drawing.Point(854, 52);
			txt_only_show_first_journal_recs.MaxLength = 0;
			txt_only_show_first_journal_recs.Name = "txt_only_show_first_journal_recs";
			txt_only_show_first_journal_recs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_only_show_first_journal_recs.Size = new System.Drawing.Size(31, 19);
			txt_only_show_first_journal_recs.TabIndex = 337;
			txt_only_show_first_journal_recs.Text = "20";
			txt_only_show_first_journal_recs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// chk_limit_journal_list
			// 
			chk_limit_journal_list.AllowDrop = true;
			chk_limit_journal_list.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_limit_journal_list.BackColor = System.Drawing.SystemColors.Control;
			chk_limit_journal_list.CausesValidation = true;
			chk_limit_journal_list.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_limit_journal_list.CheckState = System.Windows.Forms.CheckState.Checked;
			chk_limit_journal_list.Enabled = true;
			chk_limit_journal_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_limit_journal_list.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_limit_journal_list.Location = new System.Drawing.Point(753, 56);
			chk_limit_journal_list.Name = "chk_limit_journal_list";
			chk_limit_journal_list.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_limit_journal_list.Size = new System.Drawing.Size(98, 13);
			chk_limit_journal_list.TabIndex = 338;
			chk_limit_journal_list.TabStop = true;
			chk_limit_journal_list.Text = "Only Show First";
			chk_limit_journal_list.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_limit_journal_list.Visible = true;
			chk_limit_journal_list.CheckStateChanged += new System.EventHandler(chk_limit_journal_list_CheckStateChanged);
			// 
			// txt_journal_ac_selected
			// 
			txt_journal_ac_selected.AcceptsReturn = true;
			txt_journal_ac_selected.AllowDrop = true;
			txt_journal_ac_selected.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_journal_ac_selected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journal_ac_selected.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journal_ac_selected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journal_ac_selected.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journal_ac_selected.Location = new System.Drawing.Point(464, 52);
			txt_journal_ac_selected.MaxLength = 0;
			txt_journal_ac_selected.Name = "txt_journal_ac_selected";
			txt_journal_ac_selected.ReadOnly = true;
			txt_journal_ac_selected.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journal_ac_selected.Size = new System.Drawing.Size(281, 19);
			txt_journal_ac_selected.TabIndex = 353;
			txt_journal_ac_selected.Text = "NO AIRCRAFT SELECTED";
			txt_journal_ac_selected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _tab_company_details_TabPage3
			// 
			_tab_company_details_TabPage3.Controls.Add(_lbl_comp_84);
			_tab_company_details_TabPage3.Controls.Add(_lbl_comp_83);
			_tab_company_details_TabPage3.Controls.Add(_shp_dealer_background_10);
			_tab_company_details_TabPage3.Controls.Add(pnl_company_wanted_notes);
			_tab_company_details_TabPage3.Controls.Add(grd_company_wanted);
			_tab_company_details_TabPage3.Controls.Add(pnl_company_wanted);
			_tab_company_details_TabPage3.Controls.Add(chkShowAllWanted);
			_tab_company_details_TabPage3.Controls.Add(cmd_wanted_delete);
			_tab_company_details_TabPage3.Controls.Add(cmd_wanted_add);
			_tab_company_details_TabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_details_TabPage3.Text = "Wanted";
			// 
			// _lbl_comp_84
			// 
			_lbl_comp_84.AllowDrop = true;
			_lbl_comp_84.AutoSize = true;
			_lbl_comp_84.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_84.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_84.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_84.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_84.Location = new System.Drawing.Point(411, 280);
			_lbl_comp_84.MinimumSize = new System.Drawing.Size(104, 13);
			_lbl_comp_84.Name = "_lbl_comp_84";
			_lbl_comp_84.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_84.Size = new System.Drawing.Size(104, 13);
			_lbl_comp_84.TabIndex = 376;
			_lbl_comp_84.Text = "Total Wanted Aircraft:";
			_lbl_comp_84.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_84.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_84.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_84.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_83
			// 
			_lbl_comp_83.AllowDrop = true;
			_lbl_comp_83.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_83.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_comp_83.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_83.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_83.Location = new System.Drawing.Point(520, 278);
			_lbl_comp_83.MinimumSize = new System.Drawing.Size(76, 19);
			_lbl_comp_83.Name = "_lbl_comp_83";
			_lbl_comp_83.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_83.Size = new System.Drawing.Size(76, 19);
			_lbl_comp_83.TabIndex = 377;
			_lbl_comp_83.Text = "Label83";
			_lbl_comp_83.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_83.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_83.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _shp_dealer_background_10
			// 
			_shp_dealer_background_10.AllowDrop = true;
			_shp_dealer_background_10.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_10.BackStyle = 1;
			_shp_dealer_background_10.BorderStyle = 0;
			_shp_dealer_background_10.Enabled = false;
			_shp_dealer_background_10.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_10.FillStyle = 1;
			_shp_dealer_background_10.Location = new System.Drawing.Point(6, 30);
			_shp_dealer_background_10.Name = "_shp_dealer_background_10";
			_shp_dealer_background_10.Size = new System.Drawing.Size(1004, 270);
			_shp_dealer_background_10.Visible = false;
			// 
			// pnl_company_wanted_notes
			// 
			pnl_company_wanted_notes.AllowDrop = true;
			pnl_company_wanted_notes.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
			pnl_company_wanted_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_company_wanted_notes.Controls.Add(txt_amwant_notes);
			pnl_company_wanted_notes.Controls.Add(_lbl_comp_90);
			pnl_company_wanted_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_company_wanted_notes.Location = new System.Drawing.Point(604, 34);
			pnl_company_wanted_notes.Name = "pnl_company_wanted_notes";
			pnl_company_wanted_notes.Size = new System.Drawing.Size(341, 271);
			pnl_company_wanted_notes.TabIndex = 362;
			pnl_company_wanted_notes.Visible = false;
			// 
			// txt_amwant_notes
			// 
			txt_amwant_notes.AcceptsReturn = true;
			txt_amwant_notes.AllowDrop = true;
			txt_amwant_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_amwant_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amwant_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amwant_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amwant_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amwant_notes.Location = new System.Drawing.Point(8, 25);
			txt_amwant_notes.MaxLength = 250;
			txt_amwant_notes.Multiline = true;
			txt_amwant_notes.Name = "txt_amwant_notes";
			txt_amwant_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amwant_notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txt_amwant_notes.Size = new System.Drawing.Size(321, 223);
			txt_amwant_notes.TabIndex = 363;
			// 
			// _lbl_comp_90
			// 
			_lbl_comp_90.AllowDrop = true;
			_lbl_comp_90.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_comp_90.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_90.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_90.Location = new System.Drawing.Point(193, 3);
			_lbl_comp_90.MinimumSize = new System.Drawing.Size(139, 18);
			_lbl_comp_90.Name = "_lbl_comp_90";
			_lbl_comp_90.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_90.Size = new System.Drawing.Size(139, 18);
			_lbl_comp_90.TabIndex = 364;
			_lbl_comp_90.Text = "Click Here For Model Note";
			_lbl_comp_90.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_90.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_90.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_90.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// grd_company_wanted
			// 
			grd_company_wanted.AllowDrop = true;
			grd_company_wanted.AllowUserToAddRows = false;
			grd_company_wanted.AllowUserToDeleteRows = false;
			grd_company_wanted.AllowUserToResizeColumns = false;
			grd_company_wanted.AllowUserToResizeColumns = grd_company_wanted.ColumnHeadersVisible;
			grd_company_wanted.AllowUserToResizeRows = false;
			grd_company_wanted.AllowUserToResizeRows = false;
			grd_company_wanted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_wanted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_wanted.ColumnsCount = 2;
			grd_company_wanted.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
			grd_company_wanted.FixedColumns = 0;
			grd_company_wanted.FixedRows = 1;
			grd_company_wanted.Location = new System.Drawing.Point(8, 48);
			grd_company_wanted.Name = "grd_company_wanted";
			grd_company_wanted.ReadOnly = true;
			grd_company_wanted.RowsCount = 2;
			grd_company_wanted.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_company_wanted.ShowCellToolTips = false;
			grd_company_wanted.Size = new System.Drawing.Size(588, 224);
			grd_company_wanted.StandardTab = true;
			grd_company_wanted.TabIndex = 355;
			grd_company_wanted.Click += new System.EventHandler(grd_company_wanted_Click);
			// 
			// pnl_company_wanted
			// 
			pnl_company_wanted.AllowDrop = true;
			pnl_company_wanted.BackColor = System.Drawing.SystemColors.Control;
			pnl_company_wanted.BorderStyle = System.Windows.Forms.BorderStyle.None;
			pnl_company_wanted.Controls.Add(txt_amwant_max_aftt);
			pnl_company_wanted.Controls.Add(_cmd_wanted_save_0);
			pnl_company_wanted.Controls.Add(txt_amwant_pricenote);
			pnl_company_wanted.Controls.Add(txt_amwant_yearnote);
			pnl_company_wanted.Controls.Add(txt_amwant_max_price);
			pnl_company_wanted.Controls.Add(txt_amwant_end_year);
			pnl_company_wanted.Controls.Add(txt_amwant_start_year);
			pnl_company_wanted.Controls.Add(txt_amwant_listed_date);
			pnl_company_wanted.Controls.Add(frame_wanted_accept_aircraft_with);
			pnl_company_wanted.Controls.Add(txt_amwant_date_verified);
			pnl_company_wanted.Controls.Add(chk_amwant_date_is_verified);
			pnl_company_wanted.Controls.Add(frame_wanted_makemodel);
			pnl_company_wanted.Controls.Add(chk_amwant_auto_distribute_flag);
			pnl_company_wanted.Controls.Add(txt_amwant_auto_distribute_email);
			pnl_company_wanted.Controls.Add(txt_amwant_auto_unsuscribe_date);
			pnl_company_wanted.Controls.Add(txt_amwant_auto_distribute_replyname);
			pnl_company_wanted.Controls.Add(_cmd_wanted_save_1);
			pnl_company_wanted.Controls.Add(_cmd_wanted_save_2);
			pnl_company_wanted.Controls.Add(_cmd_wanted_save_3);
			pnl_company_wanted.Controls.Add(_lbl_comp_29);
			pnl_company_wanted.Controls.Add(_lbl_comp_32);
			pnl_company_wanted.Controls.Add(_lbl_comp_34);
			pnl_company_wanted.Controls.Add(_lbl_comp_33);
			pnl_company_wanted.Controls.Add(_lbl_comp_43);
			pnl_company_wanted.Controls.Add(_lbl_comp_9);
			pnl_company_wanted.Controls.Add(_lbl_comp_88);
			pnl_company_wanted.Controls.Add(_lbl_comp_89);
			pnl_company_wanted.Controls.Add(_lbl_comp_21);
			pnl_company_wanted.Controls.Add(_lbl_comp_81);
			pnl_company_wanted.Controls.Add(Shape3);
			pnl_company_wanted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_company_wanted.Location = new System.Drawing.Point(600, 36);
			pnl_company_wanted.Name = "pnl_company_wanted";
			pnl_company_wanted.Size = new System.Drawing.Size(406, 200);
			pnl_company_wanted.TabIndex = 247;
			// 
			// txt_amwant_max_aftt
			// 
			txt_amwant_max_aftt.AcceptsReturn = true;
			txt_amwant_max_aftt.AllowDrop = true;
			txt_amwant_max_aftt.BackColor = System.Drawing.SystemColors.Window;
			txt_amwant_max_aftt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amwant_max_aftt.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amwant_max_aftt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amwant_max_aftt.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amwant_max_aftt.Location = new System.Drawing.Point(257, 120);
			txt_amwant_max_aftt.MaxLength = 0;
			txt_amwant_max_aftt.Name = "txt_amwant_max_aftt";
			txt_amwant_max_aftt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amwant_max_aftt.Size = new System.Drawing.Size(85, 19);
			txt_amwant_max_aftt.TabIndex = 271;
			// 
			// _cmd_wanted_save_0
			// 
			_cmd_wanted_save_0.AllowDrop = true;
			_cmd_wanted_save_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_wanted_save_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_wanted_save_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_wanted_save_0.Location = new System.Drawing.Point(344, 0);
			_cmd_wanted_save_0.Name = "_cmd_wanted_save_0";
			_cmd_wanted_save_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_wanted_save_0.Size = new System.Drawing.Size(53, 27);
			_cmd_wanted_save_0.TabIndex = 270;
			_cmd_wanted_save_0.Text = "Save Wanted";
			_cmd_wanted_save_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_wanted_save_0.UseVisualStyleBackColor = false;
			_cmd_wanted_save_0.Click += new System.EventHandler(cmd_wanted_save_Click);
			// 
			// txt_amwant_pricenote
			// 
			txt_amwant_pricenote.AcceptsReturn = true;
			txt_amwant_pricenote.AllowDrop = true;
			txt_amwant_pricenote.BackColor = System.Drawing.SystemColors.Window;
			txt_amwant_pricenote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amwant_pricenote.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amwant_pricenote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amwant_pricenote.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amwant_pricenote.Location = new System.Drawing.Point(75, 142);
			txt_amwant_pricenote.MaxLength = 15;
			txt_amwant_pricenote.Name = "txt_amwant_pricenote";
			txt_amwant_pricenote.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amwant_pricenote.Size = new System.Drawing.Size(93, 20);
			txt_amwant_pricenote.TabIndex = 269;
			// 
			// txt_amwant_yearnote
			// 
			txt_amwant_yearnote.AcceptsReturn = true;
			txt_amwant_yearnote.AllowDrop = true;
			txt_amwant_yearnote.BackColor = System.Drawing.SystemColors.Window;
			txt_amwant_yearnote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amwant_yearnote.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amwant_yearnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amwant_yearnote.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amwant_yearnote.Location = new System.Drawing.Point(75, 99);
			txt_amwant_yearnote.MaxLength = 15;
			txt_amwant_yearnote.Name = "txt_amwant_yearnote";
			txt_amwant_yearnote.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amwant_yearnote.Size = new System.Drawing.Size(93, 20);
			txt_amwant_yearnote.TabIndex = 268;
			// 
			// txt_amwant_max_price
			// 
			txt_amwant_max_price.AcceptsReturn = true;
			txt_amwant_max_price.AllowDrop = true;
			txt_amwant_max_price.BackColor = System.Drawing.SystemColors.Window;
			txt_amwant_max_price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amwant_max_price.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amwant_max_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amwant_max_price.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amwant_max_price.Location = new System.Drawing.Point(75, 120);
			txt_amwant_max_price.MaxLength = 0;
			txt_amwant_max_price.Name = "txt_amwant_max_price";
			txt_amwant_max_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amwant_max_price.Size = new System.Drawing.Size(93, 19);
			txt_amwant_max_price.TabIndex = 267;
			// 
			// txt_amwant_end_year
			// 
			txt_amwant_end_year.AcceptsReturn = true;
			txt_amwant_end_year.AllowDrop = true;
			txt_amwant_end_year.BackColor = System.Drawing.SystemColors.Window;
			txt_amwant_end_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amwant_end_year.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amwant_end_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amwant_end_year.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amwant_end_year.Location = new System.Drawing.Point(123, 77);
			txt_amwant_end_year.MaxLength = 0;
			txt_amwant_end_year.Name = "txt_amwant_end_year";
			txt_amwant_end_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amwant_end_year.Size = new System.Drawing.Size(45, 19);
			txt_amwant_end_year.TabIndex = 266;
			// 
			// txt_amwant_start_year
			// 
			txt_amwant_start_year.AcceptsReturn = true;
			txt_amwant_start_year.AllowDrop = true;
			txt_amwant_start_year.BackColor = System.Drawing.SystemColors.Window;
			txt_amwant_start_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amwant_start_year.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amwant_start_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amwant_start_year.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amwant_start_year.Location = new System.Drawing.Point(75, 77);
			txt_amwant_start_year.MaxLength = 0;
			txt_amwant_start_year.Name = "txt_amwant_start_year";
			txt_amwant_start_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amwant_start_year.Size = new System.Drawing.Size(44, 19);
			txt_amwant_start_year.TabIndex = 265;
			// 
			// txt_amwant_listed_date
			// 
			txt_amwant_listed_date.AcceptsReturn = true;
			txt_amwant_listed_date.AllowDrop = true;
			txt_amwant_listed_date.BackColor = System.Drawing.SystemColors.Window;
			txt_amwant_listed_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amwant_listed_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amwant_listed_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amwant_listed_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amwant_listed_date.Location = new System.Drawing.Point(75, 56);
			txt_amwant_listed_date.MaxLength = 0;
			txt_amwant_listed_date.Name = "txt_amwant_listed_date";
			txt_amwant_listed_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amwant_listed_date.Size = new System.Drawing.Size(65, 19);
			txt_amwant_listed_date.TabIndex = 264;
			// 
			// frame_wanted_accept_aircraft_with
			// 
			frame_wanted_accept_aircraft_with.AllowDrop = true;
			frame_wanted_accept_aircraft_with.BackColor = System.Drawing.SystemColors.Control;
			frame_wanted_accept_aircraft_with.Controls.Add(cbo_amwant_accept_damage_hist);
			frame_wanted_accept_aircraft_with.Controls.Add(cbo_amwant_accept_damage_cur);
			frame_wanted_accept_aircraft_with.Controls.Add(_lbl_comp_2);
			frame_wanted_accept_aircraft_with.Controls.Add(_lbl_comp_36);
			frame_wanted_accept_aircraft_with.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_wanted_accept_aircraft_with.Enabled = true;
			frame_wanted_accept_aircraft_with.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_wanted_accept_aircraft_with.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_wanted_accept_aircraft_with.Location = new System.Drawing.Point(12, 161);
			frame_wanted_accept_aircraft_with.Name = "frame_wanted_accept_aircraft_with";
			frame_wanted_accept_aircraft_with.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_wanted_accept_aircraft_with.Size = new System.Drawing.Size(306, 39);
			frame_wanted_accept_aircraft_with.TabIndex = 259;
			frame_wanted_accept_aircraft_with.Text = " Accept Aircraft with ";
			frame_wanted_accept_aircraft_with.Visible = true;
			// 
			// cbo_amwant_accept_damage_hist
			// 
			cbo_amwant_accept_damage_hist.AllowDrop = true;
			cbo_amwant_accept_damage_hist.BackColor = System.Drawing.SystemColors.Window;
			cbo_amwant_accept_damage_hist.CausesValidation = true;
			cbo_amwant_accept_damage_hist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_amwant_accept_damage_hist.Enabled = true;
			cbo_amwant_accept_damage_hist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_amwant_accept_damage_hist.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_amwant_accept_damage_hist.IntegralHeight = true;
			cbo_amwant_accept_damage_hist.Location = new System.Drawing.Point(87, 13);
			cbo_amwant_accept_damage_hist.Name = "cbo_amwant_accept_damage_hist";
			cbo_amwant_accept_damage_hist.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_amwant_accept_damage_hist.Size = new System.Drawing.Size(65, 21);
			cbo_amwant_accept_damage_hist.Sorted = false;
			cbo_amwant_accept_damage_hist.TabIndex = 261;
			cbo_amwant_accept_damage_hist.TabStop = true;
			cbo_amwant_accept_damage_hist.Visible = true;
			// 
			// cbo_amwant_accept_damage_cur
			// 
			cbo_amwant_accept_damage_cur.AllowDrop = true;
			cbo_amwant_accept_damage_cur.BackColor = System.Drawing.SystemColors.Window;
			cbo_amwant_accept_damage_cur.CausesValidation = true;
			cbo_amwant_accept_damage_cur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_amwant_accept_damage_cur.Enabled = true;
			cbo_amwant_accept_damage_cur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_amwant_accept_damage_cur.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_amwant_accept_damage_cur.IntegralHeight = true;
			cbo_amwant_accept_damage_cur.Location = new System.Drawing.Point(238, 13);
			cbo_amwant_accept_damage_cur.Name = "cbo_amwant_accept_damage_cur";
			cbo_amwant_accept_damage_cur.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_amwant_accept_damage_cur.Size = new System.Drawing.Size(65, 21);
			cbo_amwant_accept_damage_cur.Sorted = false;
			cbo_amwant_accept_damage_cur.TabIndex = 260;
			cbo_amwant_accept_damage_cur.TabStop = true;
			cbo_amwant_accept_damage_cur.Visible = true;
			// 
			// _lbl_comp_2
			// 
			_lbl_comp_2.AllowDrop = true;
			_lbl_comp_2.AutoSize = true;
			_lbl_comp_2.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_2.Location = new System.Drawing.Point(154, 17);
			_lbl_comp_2.MinimumSize = new System.Drawing.Size(3, 13);
			_lbl_comp_2.Name = "_lbl_comp_2";
			_lbl_comp_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_2.Size = new System.Drawing.Size(3, 13);
			_lbl_comp_2.TabIndex = 263;
			_lbl_comp_2.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_2.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_2.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_36
			// 
			_lbl_comp_36.AllowDrop = true;
			_lbl_comp_36.AutoSize = true;
			_lbl_comp_36.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_36.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_36.Location = new System.Drawing.Point(5, 17);
			_lbl_comp_36.MinimumSize = new System.Drawing.Size(239, 13);
			_lbl_comp_36.Name = "_lbl_comp_36";
			_lbl_comp_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_36.Size = new System.Drawing.Size(239, 13);
			_lbl_comp_36.TabIndex = 262;
			_lbl_comp_36.Text = "Damage History:                          Current Damage: ";
			_lbl_comp_36.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_36.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_36.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// txt_amwant_date_verified
			// 
			txt_amwant_date_verified.AcceptsReturn = true;
			txt_amwant_date_verified.AllowDrop = true;
			txt_amwant_date_verified.BackColor = System.Drawing.SystemColors.Window;
			txt_amwant_date_verified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amwant_date_verified.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amwant_date_verified.Enabled = false;
			txt_amwant_date_verified.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amwant_date_verified.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amwant_date_verified.Location = new System.Drawing.Point(257, 77);
			txt_amwant_date_verified.MaxLength = 0;
			txt_amwant_date_verified.Name = "txt_amwant_date_verified";
			txt_amwant_date_verified.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amwant_date_verified.Size = new System.Drawing.Size(85, 19);
			txt_amwant_date_verified.TabIndex = 258;
			// 
			// chk_amwant_date_is_verified
			// 
			chk_amwant_date_is_verified.AllowDrop = true;
			chk_amwant_date_is_verified.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_amwant_date_is_verified.BackColor = System.Drawing.SystemColors.Control;
			chk_amwant_date_is_verified.CausesValidation = true;
			chk_amwant_date_is_verified.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_amwant_date_is_verified.CheckState = System.Windows.Forms.CheckState.Checked;
			chk_amwant_date_is_verified.Enabled = true;
			chk_amwant_date_is_verified.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_amwant_date_is_verified.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_amwant_date_is_verified.Location = new System.Drawing.Point(180, 102);
			chk_amwant_date_is_verified.Name = "chk_amwant_date_is_verified";
			chk_amwant_date_is_verified.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_amwant_date_is_verified.Size = new System.Drawing.Size(161, 13);
			chk_amwant_date_is_verified.TabIndex = 257;
			chk_amwant_date_is_verified.TabStop = true;
			chk_amwant_date_is_verified.Text = "Verified by Research?";
			chk_amwant_date_is_verified.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_amwant_date_is_verified.Visible = true;
			chk_amwant_date_is_verified.CheckStateChanged += new System.EventHandler(chk_amwant_date_is_verified_CheckStateChanged);
			// 
			// frame_wanted_makemodel
			// 
			frame_wanted_makemodel.AllowDrop = true;
			frame_wanted_makemodel.BackColor = System.Drawing.SystemColors.Control;
			frame_wanted_makemodel.Controls.Add(cbo_amwant_model);
			frame_wanted_makemodel.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_wanted_makemodel.Enabled = true;
			frame_wanted_makemodel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_wanted_makemodel.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_wanted_makemodel.Location = new System.Drawing.Point(9, 13);
			frame_wanted_makemodel.Name = "frame_wanted_makemodel";
			frame_wanted_makemodel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_wanted_makemodel.Size = new System.Drawing.Size(333, 41);
			frame_wanted_makemodel.TabIndex = 255;
			frame_wanted_makemodel.Text = " Make/Model ";
			frame_wanted_makemodel.Visible = true;
			// 
			// cbo_amwant_model
			// 
			cbo_amwant_model.AllowDrop = true;
			cbo_amwant_model.BackColor = System.Drawing.SystemColors.Window;
			cbo_amwant_model.CausesValidation = false;
			cbo_amwant_model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_amwant_model.Enabled = true;
			cbo_amwant_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_amwant_model.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_amwant_model.IntegralHeight = true;
			cbo_amwant_model.Location = new System.Drawing.Point(5, 14);
			cbo_amwant_model.Name = "cbo_amwant_model";
			cbo_amwant_model.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_amwant_model.Size = new System.Drawing.Size(323, 21);
			cbo_amwant_model.Sorted = false;
			cbo_amwant_model.TabIndex = 256;
			cbo_amwant_model.TabStop = true;
			cbo_amwant_model.Tag = "N";
			cbo_amwant_model.Visible = true;
			cbo_amwant_model.SelectedIndexChanged += new System.EventHandler(cbo_amwant_model_SelectedIndexChanged);
			// 
			// chk_amwant_auto_distribute_flag
			// 
			chk_amwant_auto_distribute_flag.AllowDrop = true;
			chk_amwant_auto_distribute_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_amwant_auto_distribute_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_amwant_auto_distribute_flag.CausesValidation = true;
			chk_amwant_auto_distribute_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_amwant_auto_distribute_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_amwant_auto_distribute_flag.Enabled = true;
			chk_amwant_auto_distribute_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_amwant_auto_distribute_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_amwant_auto_distribute_flag.Location = new System.Drawing.Point(21, 210);
			chk_amwant_auto_distribute_flag.Name = "chk_amwant_auto_distribute_flag";
			chk_amwant_auto_distribute_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_amwant_auto_distribute_flag.Size = new System.Drawing.Size(96, 13);
			chk_amwant_auto_distribute_flag.TabIndex = 254;
			chk_amwant_auto_distribute_flag.TabStop = true;
			chk_amwant_auto_distribute_flag.Text = "ABI Alert?";
			chk_amwant_auto_distribute_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_amwant_auto_distribute_flag.Visible = true;
			// 
			// txt_amwant_auto_distribute_email
			// 
			txt_amwant_auto_distribute_email.AcceptsReturn = true;
			txt_amwant_auto_distribute_email.AllowDrop = true;
			txt_amwant_auto_distribute_email.BackColor = System.Drawing.SystemColors.Window;
			txt_amwant_auto_distribute_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amwant_auto_distribute_email.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amwant_auto_distribute_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amwant_auto_distribute_email.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amwant_auto_distribute_email.Location = new System.Drawing.Point(104, 227);
			txt_amwant_auto_distribute_email.MaxLength = 250;
			txt_amwant_auto_distribute_email.Multiline = true;
			txt_amwant_auto_distribute_email.Name = "txt_amwant_auto_distribute_email";
			txt_amwant_auto_distribute_email.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amwant_auto_distribute_email.Size = new System.Drawing.Size(290, 19);
			txt_amwant_auto_distribute_email.TabIndex = 253;
			// 
			// txt_amwant_auto_unsuscribe_date
			// 
			txt_amwant_auto_unsuscribe_date.AcceptsReturn = true;
			txt_amwant_auto_unsuscribe_date.AllowDrop = true;
			txt_amwant_auto_unsuscribe_date.BackColor = System.Drawing.SystemColors.Window;
			txt_amwant_auto_unsuscribe_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amwant_auto_unsuscribe_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amwant_auto_unsuscribe_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amwant_auto_unsuscribe_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amwant_auto_unsuscribe_date.Location = new System.Drawing.Point(251, 207);
			txt_amwant_auto_unsuscribe_date.MaxLength = 250;
			txt_amwant_auto_unsuscribe_date.Multiline = true;
			txt_amwant_auto_unsuscribe_date.Name = "txt_amwant_auto_unsuscribe_date";
			txt_amwant_auto_unsuscribe_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amwant_auto_unsuscribe_date.Size = new System.Drawing.Size(142, 19);
			txt_amwant_auto_unsuscribe_date.TabIndex = 252;
			// 
			// txt_amwant_auto_distribute_replyname
			// 
			txt_amwant_auto_distribute_replyname.AcceptsReturn = true;
			txt_amwant_auto_distribute_replyname.AllowDrop = true;
			txt_amwant_auto_distribute_replyname.BackColor = System.Drawing.SystemColors.Window;
			txt_amwant_auto_distribute_replyname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amwant_auto_distribute_replyname.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amwant_auto_distribute_replyname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amwant_auto_distribute_replyname.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amwant_auto_distribute_replyname.Location = new System.Drawing.Point(103, 249);
			txt_amwant_auto_distribute_replyname.MaxLength = 250;
			txt_amwant_auto_distribute_replyname.Multiline = true;
			txt_amwant_auto_distribute_replyname.Name = "txt_amwant_auto_distribute_replyname";
			txt_amwant_auto_distribute_replyname.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amwant_auto_distribute_replyname.Size = new System.Drawing.Size(290, 19);
			txt_amwant_auto_distribute_replyname.TabIndex = 251;
			// 
			// _cmd_wanted_save_1
			// 
			_cmd_wanted_save_1.AllowDrop = true;
			_cmd_wanted_save_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_wanted_save_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_wanted_save_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_wanted_save_1.Location = new System.Drawing.Point(344, 80);
			_cmd_wanted_save_1.Name = "_cmd_wanted_save_1";
			_cmd_wanted_save_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_wanted_save_1.Size = new System.Drawing.Size(53, 27);
			_cmd_wanted_save_1.TabIndex = 250;
			_cmd_wanted_save_1.Text = "Verify Wanted";
			_cmd_wanted_save_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_wanted_save_1.UseVisualStyleBackColor = false;
			_cmd_wanted_save_1.Click += new System.EventHandler(cmd_wanted_save_Click);
			// 
			// _cmd_wanted_save_2
			// 
			_cmd_wanted_save_2.AllowDrop = true;
			_cmd_wanted_save_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_wanted_save_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_wanted_save_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_wanted_save_2.Location = new System.Drawing.Point(344, 112);
			_cmd_wanted_save_2.Name = "_cmd_wanted_save_2";
			_cmd_wanted_save_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_wanted_save_2.Size = new System.Drawing.Size(53, 27);
			_cmd_wanted_save_2.TabIndex = 249;
			_cmd_wanted_save_2.Text = "Cancel Wanted";
			_cmd_wanted_save_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_wanted_save_2.UseVisualStyleBackColor = false;
			_cmd_wanted_save_2.Click += new System.EventHandler(cmd_wanted_save_Click);
			// 
			// _cmd_wanted_save_3
			// 
			_cmd_wanted_save_3.AllowDrop = true;
			_cmd_wanted_save_3.BackColor = System.Drawing.SystemColors.Control;
			_cmd_wanted_save_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_wanted_save_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_wanted_save_3.Location = new System.Drawing.Point(344, 32);
			_cmd_wanted_save_3.Name = "_cmd_wanted_save_3";
			_cmd_wanted_save_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_wanted_save_3.Size = new System.Drawing.Size(53, 43);
			_cmd_wanted_save_3.TabIndex = 248;
			_cmd_wanted_save_3.Text = "Save Wanted (Keep)";
			_cmd_wanted_save_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_wanted_save_3.UseVisualStyleBackColor = false;
			_cmd_wanted_save_3.Click += new System.EventHandler(cmd_wanted_save_Click);
			// 
			// _lbl_comp_29
			// 
			_lbl_comp_29.AllowDrop = true;
			_lbl_comp_29.AutoSize = true;
			_lbl_comp_29.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_29.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_29.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_29.Location = new System.Drawing.Point(12, 102);
			_lbl_comp_29.MinimumSize = new System.Drawing.Size(51, 13);
			_lbl_comp_29.Name = "_lbl_comp_29";
			_lbl_comp_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_29.Size = new System.Drawing.Size(51, 13);
			_lbl_comp_29.TabIndex = 281;
			_lbl_comp_29.Text = "Year Note:";
			_lbl_comp_29.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_29.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_29.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_32
			// 
			_lbl_comp_32.AllowDrop = true;
			_lbl_comp_32.AutoSize = true;
			_lbl_comp_32.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_32.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_32.Location = new System.Drawing.Point(12, 80);
			_lbl_comp_32.MinimumSize = new System.Drawing.Size(241, 13);
			_lbl_comp_32.Name = "_lbl_comp_32";
			_lbl_comp_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_32.Size = new System.Drawing.Size(241, 13);
			_lbl_comp_32.TabIndex = 280;
			_lbl_comp_32.Text = "Year Range:                                       Date Verified:";
			_lbl_comp_32.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_32.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_32.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_34
			// 
			_lbl_comp_34.AllowDrop = true;
			_lbl_comp_34.AutoSize = true;
			_lbl_comp_34.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_34.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_34.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_34.Location = new System.Drawing.Point(12, 123);
			_lbl_comp_34.MinimumSize = new System.Drawing.Size(238, 13);
			_lbl_comp_34.Name = "_lbl_comp_34";
			_lbl_comp_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_34.Size = new System.Drawing.Size(238, 13);
			_lbl_comp_34.TabIndex = 279;
			_lbl_comp_34.Text = "Max. Price:                                           Max. AFTT:";
			_lbl_comp_34.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_34.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_34.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_33
			// 
			_lbl_comp_33.AllowDrop = true;
			_lbl_comp_33.AutoSize = true;
			_lbl_comp_33.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_33.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_33.Location = new System.Drawing.Point(12, 59);
			_lbl_comp_33.MinimumSize = new System.Drawing.Size(224, 13);
			_lbl_comp_33.Name = "_lbl_comp_33";
			_lbl_comp_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_33.Size = new System.Drawing.Size(224, 13);
			_lbl_comp_33.TabIndex = 278;
			_lbl_comp_33.Text = "Date Listed:                                      Years Built:";
			_lbl_comp_33.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_33.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_33.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_43
			// 
			_lbl_comp_43.AllowDrop = true;
			_lbl_comp_43.AutoSize = true;
			_lbl_comp_43.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_43.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_43.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_43.Location = new System.Drawing.Point(12, 145);
			_lbl_comp_43.MinimumSize = new System.Drawing.Size(240, 13);
			_lbl_comp_43.Name = "_lbl_comp_43";
			_lbl_comp_43.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_43.Size = new System.Drawing.Size(240, 13);
			_lbl_comp_43.TabIndex = 277;
			_lbl_comp_43.Text = "Price Note:                                        Wanted Note:";
			_lbl_comp_43.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_43.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_43.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_9
			// 
			_lbl_comp_9.AllowDrop = true;
			_lbl_comp_9.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_comp_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_9.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_9.Location = new System.Drawing.Point(243, 56);
			_lbl_comp_9.MinimumSize = new System.Drawing.Size(99, 18);
			_lbl_comp_9.Name = "_lbl_comp_9";
			_lbl_comp_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_9.Size = new System.Drawing.Size(99, 18);
			_lbl_comp_9.TabIndex = 276;
			_lbl_comp_9.Text = "Label9";
			_lbl_comp_9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_9.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_9.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_9.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_88
			// 
			_lbl_comp_88.AllowDrop = true;
			_lbl_comp_88.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_88.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_88.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_88.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_88.Location = new System.Drawing.Point(7, 232);
			_lbl_comp_88.MinimumSize = new System.Drawing.Size(93, 13);
			_lbl_comp_88.Name = "_lbl_comp_88";
			_lbl_comp_88.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_88.Size = new System.Drawing.Size(93, 13);
			_lbl_comp_88.TabIndex = 275;
			_lbl_comp_88.Text = "Alert Email:";
			_lbl_comp_88.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_88.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_88.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_88.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_89
			// 
			_lbl_comp_89.AllowDrop = true;
			_lbl_comp_89.AutoSize = true;
			_lbl_comp_89.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_89.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_89.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_89.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_89.Location = new System.Drawing.Point(164, 210);
			_lbl_comp_89.MinimumSize = new System.Drawing.Size(86, 26);
			_lbl_comp_89.Name = "_lbl_comp_89";
			_lbl_comp_89.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_89.Size = new System.Drawing.Size(86, 26);
			_lbl_comp_89.TabIndex = 274;
			_lbl_comp_89.Text = "UnSubscribe Date:";
			_lbl_comp_89.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_89.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_89.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_89.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_21
			// 
			_lbl_comp_21.AllowDrop = true;
			_lbl_comp_21.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_21.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_21.Location = new System.Drawing.Point(7, 252);
			_lbl_comp_21.MinimumSize = new System.Drawing.Size(93, 13);
			_lbl_comp_21.Name = "_lbl_comp_21";
			_lbl_comp_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_21.Size = new System.Drawing.Size(93, 13);
			_lbl_comp_21.TabIndex = 273;
			_lbl_comp_21.Text = "Alert Reply Name:";
			_lbl_comp_21.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_21.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_21.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_21.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_81
			// 
			_lbl_comp_81.AllowDrop = true;
			_lbl_comp_81.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_81.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_comp_81.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_81.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_81.Location = new System.Drawing.Point(258, 142);
			_lbl_comp_81.MinimumSize = new System.Drawing.Size(145, 18);
			_lbl_comp_81.Name = "_lbl_comp_81";
			_lbl_comp_81.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_81.Size = new System.Drawing.Size(145, 18);
			_lbl_comp_81.TabIndex = 272;
			_lbl_comp_81.Text = "Click Here For Wanted Note";
			_lbl_comp_81.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_81.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_81.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_81.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// Shape3
			// 
			Shape3.AllowDrop = true;
			Shape3.BackColor = System.Drawing.SystemColors.Window;
			Shape3.BackStyle = 0;
			Shape3.BorderStyle = 1;
			Shape3.Enabled = false;
			Shape3.FillColor = System.Drawing.Color.Black;
			Shape3.FillStyle = 1;
			Shape3.Location = new System.Drawing.Point(16, 200);
			Shape3.Name = "Shape3";
			Shape3.Size = new System.Drawing.Size(385, 68);
			Shape3.Visible = false;
			// 
			// chkShowAllWanted
			// 
			chkShowAllWanted.AllowDrop = true;
			chkShowAllWanted.Appearance = System.Windows.Forms.Appearance.Normal;
			chkShowAllWanted.BackColor = System.Drawing.SystemColors.Control;
			chkShowAllWanted.CausesValidation = true;
			chkShowAllWanted.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkShowAllWanted.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkShowAllWanted.Enabled = true;
			chkShowAllWanted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkShowAllWanted.ForeColor = System.Drawing.SystemColors.WindowText;
			chkShowAllWanted.Location = new System.Drawing.Point(8, 10);
			chkShowAllWanted.Name = "chkShowAllWanted";
			chkShowAllWanted.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkShowAllWanted.Size = new System.Drawing.Size(146, 13);
			chkShowAllWanted.TabIndex = 292;
			chkShowAllWanted.TabStop = true;
			chkShowAllWanted.Text = "Show All Wanted Records ";
			chkShowAllWanted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkShowAllWanted.Visible = true;
			chkShowAllWanted.CheckStateChanged += new System.EventHandler(chkShowAllWanted_CheckStateChanged);
			// 
			// cmd_wanted_delete
			// 
			cmd_wanted_delete.AllowDrop = true;
			cmd_wanted_delete.BackColor = System.Drawing.SystemColors.Control;
			cmd_wanted_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_wanted_delete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_wanted_delete.Location = new System.Drawing.Point(108, 274);
			cmd_wanted_delete.Name = "cmd_wanted_delete";
			cmd_wanted_delete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_wanted_delete.Size = new System.Drawing.Size(97, 24);
			cmd_wanted_delete.TabIndex = 345;
			cmd_wanted_delete.Text = "&Delete Wanted";
			cmd_wanted_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_wanted_delete.UseVisualStyleBackColor = false;
			cmd_wanted_delete.Click += new System.EventHandler(cmd_wanted_delete_Click);
			cmd_wanted_delete.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_wanted_delete_MouseUp);
			// 
			// cmd_wanted_add
			// 
			cmd_wanted_add.AllowDrop = true;
			cmd_wanted_add.BackColor = System.Drawing.SystemColors.Control;
			cmd_wanted_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_wanted_add.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_wanted_add.Location = new System.Drawing.Point(10, 274);
			cmd_wanted_add.Name = "cmd_wanted_add";
			cmd_wanted_add.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_wanted_add.Size = new System.Drawing.Size(96, 24);
			cmd_wanted_add.TabIndex = 352;
			cmd_wanted_add.Text = "&Add Wanted";
			cmd_wanted_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_wanted_add.UseVisualStyleBackColor = false;
			cmd_wanted_add.Click += new System.EventHandler(cmd_wanted_add_Click);
			cmd_wanted_add.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_wanted_add_MouseUp);
			// 
			// _tab_company_details_TabPage4
			// 
			_tab_company_details_TabPage4.Controls.Add(_shp_dealer_background_11);
			_tab_company_details_TabPage4.Controls.Add(grd_company_shares);
			_tab_company_details_TabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_details_TabPage4.Text = "Share Rel.";
			// 
			// _shp_dealer_background_11
			// 
			_shp_dealer_background_11.AllowDrop = true;
			_shp_dealer_background_11.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_11.BackStyle = 1;
			_shp_dealer_background_11.BorderStyle = 0;
			_shp_dealer_background_11.Enabled = false;
			_shp_dealer_background_11.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_11.FillStyle = 1;
			_shp_dealer_background_11.Location = new System.Drawing.Point(3, 46);
			_shp_dealer_background_11.Name = "_shp_dealer_background_11";
			_shp_dealer_background_11.Size = new System.Drawing.Size(1003, 270);
			_shp_dealer_background_11.Visible = false;
			// 
			// grd_company_shares
			// 
			grd_company_shares.AllowDrop = true;
			grd_company_shares.AllowUserToAddRows = false;
			grd_company_shares.AllowUserToDeleteRows = false;
			grd_company_shares.AllowUserToResizeColumns = false;
			grd_company_shares.AllowUserToResizeColumns = grd_company_shares.ColumnHeadersVisible;
			grd_company_shares.AllowUserToResizeRows = false;
			grd_company_shares.AllowUserToResizeRows = false;
			grd_company_shares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_shares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_shares.ColumnsCount = 2;
			grd_company_shares.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
			grd_company_shares.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			grd_company_shares.FixedColumns = 0;
			grd_company_shares.FixedRows = 1;
			grd_company_shares.Location = new System.Drawing.Point(4, 46);
			grd_company_shares.Name = "grd_company_shares";
			grd_company_shares.ReadOnly = true;
			grd_company_shares.RowsCount = 2;
			grd_company_shares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_company_shares.ShowCellToolTips = false;
			grd_company_shares.Size = new System.Drawing.Size(995, 255);
			grd_company_shares.StandardTab = true;
			grd_company_shares.TabIndex = 354;
			grd_company_shares.DoubleClick += new System.EventHandler(grd_company_shares_DoubleClick);
			// 
			// _tab_company_details_TabPage5
			// 
			_tab_company_details_TabPage5.Controls.Add(_lbl_comp_101);
			_tab_company_details_TabPage5.Controls.Add(_shp_dealer_background_12);
			_tab_company_details_TabPage5.Controls.Add(grd_company_documents);
			_tab_company_details_TabPage5.Controls.Add(_txt_company_field_2);
			_tab_company_details_TabPage5.Controls.Add(_cmdCertCommand_5);
			_tab_company_details_TabPage5.Controls.Add(_cbo_comp_account_5);
			_tab_company_details_TabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_details_TabPage5.Text = "Documents";
			// 
			// _lbl_comp_101
			// 
			_lbl_comp_101.AllowDrop = true;
			_lbl_comp_101.AutoSize = true;
			_lbl_comp_101.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_101.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_101.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_101.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_101.Location = new System.Drawing.Point(456, 30);
			_lbl_comp_101.MinimumSize = new System.Drawing.Size(411, 13);
			_lbl_comp_101.Name = "_lbl_comp_101";
			_lbl_comp_101.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_101.Size = new System.Drawing.Size(411, 13);
			_lbl_comp_101.TabIndex = 372;
			_lbl_comp_101.Text = "Financial Institution:";
			_lbl_comp_101.Visible = false;
			_lbl_comp_101.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_101.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_101.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _shp_dealer_background_12
			// 
			_shp_dealer_background_12.AllowDrop = true;
			_shp_dealer_background_12.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_12.BackStyle = 1;
			_shp_dealer_background_12.BorderStyle = 0;
			_shp_dealer_background_12.Enabled = false;
			_shp_dealer_background_12.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_12.FillStyle = 1;
			_shp_dealer_background_12.Location = new System.Drawing.Point(3, 46);
			_shp_dealer_background_12.Name = "_shp_dealer_background_12";
			_shp_dealer_background_12.Size = new System.Drawing.Size(1003, 270);
			_shp_dealer_background_12.Visible = false;
			// 
			// grd_company_documents
			// 
			grd_company_documents.AllowDrop = true;
			grd_company_documents.AllowUserToAddRows = false;
			grd_company_documents.AllowUserToDeleteRows = false;
			grd_company_documents.AllowUserToResizeColumns = false;
			grd_company_documents.AllowUserToResizeColumns = grd_company_documents.ColumnHeadersVisible;
			grd_company_documents.AllowUserToResizeRows = false;
			grd_company_documents.AllowUserToResizeRows = false;
			grd_company_documents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_documents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_documents.ColumnsCount = 2;
			grd_company_documents.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
			grd_company_documents.FixedColumns = 0;
			grd_company_documents.FixedRows = 1;
			grd_company_documents.Location = new System.Drawing.Point(8, 56);
			grd_company_documents.Name = "grd_company_documents";
			grd_company_documents.ReadOnly = true;
			grd_company_documents.RowsCount = 2;
			grd_company_documents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_company_documents.ShowCellToolTips = false;
			grd_company_documents.Size = new System.Drawing.Size(995, 255);
			grd_company_documents.StandardTab = true;
			grd_company_documents.TabIndex = 365;
			// 
			// _txt_company_field_2
			// 
			_txt_company_field_2.AcceptsReturn = true;
			_txt_company_field_2.AllowDrop = true;
			_txt_company_field_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_company_field_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_company_field_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_company_field_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_company_field_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_company_field_2.Location = new System.Drawing.Point(336, 28);
			_txt_company_field_2.MaxLength = 0;
			_txt_company_field_2.Name = "_txt_company_field_2";
			_txt_company_field_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_company_field_2.Size = new System.Drawing.Size(111, 21);
			_txt_company_field_2.TabIndex = 283;
			_txt_company_field_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_company_field_KeyDown);
			_txt_company_field_2.Leave += new System.EventHandler(txt_company_field_Leave);
			// 
			// _cmdCertCommand_5
			// 
			_cmdCertCommand_5.AllowDrop = true;
			_cmdCertCommand_5.BackColor = System.Drawing.SystemColors.Control;
			_cmdCertCommand_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdCertCommand_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdCertCommand_5.Location = new System.Drawing.Point(172, 26);
			_cmdCertCommand_5.Name = "_cmdCertCommand_5";
			_cmdCertCommand_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdCertCommand_5.Size = new System.Drawing.Size(129, 17);
			_cmdCertCommand_5.TabIndex = 288;
			_cmdCertCommand_5.Text = "Save Financial Group";
			_cmdCertCommand_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdCertCommand_5.UseVisualStyleBackColor = false;
			_cmdCertCommand_5.Visible = false;
			_cmdCertCommand_5.Click += new System.EventHandler(cmdCertCommand_Click);
			// 
			// _cbo_comp_account_5
			// 
			_cbo_comp_account_5.AllowDrop = true;
			_cbo_comp_account_5.BackColor = System.Drawing.SystemColors.Window;
			_cbo_comp_account_5.CausesValidation = true;
			_cbo_comp_account_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_comp_account_5.Enabled = true;
			_cbo_comp_account_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_comp_account_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_comp_account_5.IntegralHeight = true;
			_cbo_comp_account_5.Location = new System.Drawing.Point(6, 24);
			_cbo_comp_account_5.Name = "_cbo_comp_account_5";
			_cbo_comp_account_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_comp_account_5.Size = new System.Drawing.Size(164, 21);
			_cbo_comp_account_5.Sorted = false;
			_cbo_comp_account_5.TabIndex = 289;
			_cbo_comp_account_5.TabStop = true;
			_cbo_comp_account_5.Text = "cbo_comp_account";
			_cbo_comp_account_5.Visible = true;
			_cbo_comp_account_5.SelectedIndexChanged += new System.EventHandler(cbo_comp_account_SelectedIndexChanged);
			// 
			// _tab_company_details_TabPage6
			// 
			_tab_company_details_TabPage6.Controls.Add(_lbl_comp_80);
			_tab_company_details_TabPage6.Controls.Add(_lbl_comp_79);
			_tab_company_details_TabPage6.Controls.Add(_shp_dealer_background_13);
			_tab_company_details_TabPage6.Controls.Add(grd_company_expired_leases);
			_tab_company_details_TabPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_details_TabPage6.Text = "Past Due Leases";
			// 
			// _lbl_comp_80
			// 
			_lbl_comp_80.AllowDrop = true;
			_lbl_comp_80.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_comp_80.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_80.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_80.Location = new System.Drawing.Point(109, 258);
			_lbl_comp_80.MinimumSize = new System.Drawing.Size(76, 19);
			_lbl_comp_80.Name = "_lbl_comp_80";
			_lbl_comp_80.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_80.Size = new System.Drawing.Size(76, 19);
			_lbl_comp_80.TabIndex = 378;
			_lbl_comp_80.Text = "Label80";
			_lbl_comp_80.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_80.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_80.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_79
			// 
			_lbl_comp_79.AllowDrop = true;
			_lbl_comp_79.AutoSize = true;
			_lbl_comp_79.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_79.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_79.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_79.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_79.Location = new System.Drawing.Point(5, 261);
			_lbl_comp_79.MinimumSize = new System.Drawing.Size(101, 13);
			_lbl_comp_79.Name = "_lbl_comp_79";
			_lbl_comp_79.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_79.Size = new System.Drawing.Size(101, 13);
			_lbl_comp_79.TabIndex = 380;
			_lbl_comp_79.Text = "Total Leased Aircraft:";
			_lbl_comp_79.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_79.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_79.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_79.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _shp_dealer_background_13
			// 
			_shp_dealer_background_13.AllowDrop = true;
			_shp_dealer_background_13.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_13.BackStyle = 1;
			_shp_dealer_background_13.BorderStyle = 0;
			_shp_dealer_background_13.Enabled = false;
			_shp_dealer_background_13.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_13.FillStyle = 1;
			_shp_dealer_background_13.Location = new System.Drawing.Point(2, 12);
			_shp_dealer_background_13.Name = "_shp_dealer_background_13";
			_shp_dealer_background_13.Size = new System.Drawing.Size(1003, 270);
			_shp_dealer_background_13.Visible = false;
			// 
			// grd_company_expired_leases
			// 
			grd_company_expired_leases.AllowDrop = true;
			grd_company_expired_leases.AllowUserToAddRows = false;
			grd_company_expired_leases.AllowUserToDeleteRows = false;
			grd_company_expired_leases.AllowUserToResizeColumns = false;
			grd_company_expired_leases.AllowUserToResizeColumns = grd_company_expired_leases.ColumnHeadersVisible;
			grd_company_expired_leases.AllowUserToResizeRows = false;
			grd_company_expired_leases.AllowUserToResizeRows = false;
			grd_company_expired_leases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_expired_leases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_expired_leases.ColumnsCount = 2;
			grd_company_expired_leases.FixedColumns = 0;
			grd_company_expired_leases.FixedRows = 1;
			grd_company_expired_leases.Location = new System.Drawing.Point(4, 17);
			grd_company_expired_leases.Name = "grd_company_expired_leases";
			grd_company_expired_leases.ReadOnly = true;
			grd_company_expired_leases.RowsCount = 2;
			grd_company_expired_leases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_company_expired_leases.ShowCellToolTips = false;
			grd_company_expired_leases.Size = new System.Drawing.Size(994, 237);
			grd_company_expired_leases.StandardTab = true;
			grd_company_expired_leases.TabIndex = 332;
			grd_company_expired_leases.DoubleClick += new System.EventHandler(grd_company_expired_leases_DoubleClick);
			// 
			// _tab_company_details_TabPage7
			// 
			_tab_company_details_TabPage7.Controls.Add(grd_marketing_crm_notes);
			_tab_company_details_TabPage7.Controls.Add(_cmd_verify_yacht_6);
			_tab_company_details_TabPage7.Controls.Add(_txt_market_note_0);
			_tab_company_details_TabPage7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_details_TabPage7.Text = "Marketing CRM";
			// 
			// grd_marketing_crm_notes
			// 
			grd_marketing_crm_notes.AllowDrop = true;
			grd_marketing_crm_notes.AllowUserToAddRows = false;
			grd_marketing_crm_notes.AllowUserToDeleteRows = false;
			grd_marketing_crm_notes.AllowUserToResizeColumns = false;
			grd_marketing_crm_notes.AllowUserToResizeColumns = grd_marketing_crm_notes.ColumnHeadersVisible;
			grd_marketing_crm_notes.AllowUserToResizeRows = false;
			grd_marketing_crm_notes.AllowUserToResizeRows = false;
			grd_marketing_crm_notes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_marketing_crm_notes.ColumnsCount = 2;
			grd_marketing_crm_notes.FixedColumns = 1;
			grd_marketing_crm_notes.FixedRows = 1;
			grd_marketing_crm_notes.Location = new System.Drawing.Point(16, 36);
			grd_marketing_crm_notes.Name = "grd_marketing_crm_notes";
			grd_marketing_crm_notes.ReadOnly = true;
			grd_marketing_crm_notes.RowsCount = 2;
			grd_marketing_crm_notes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_marketing_crm_notes.ShowCellToolTips = false;
			grd_marketing_crm_notes.Size = new System.Drawing.Size(985, 305);
			grd_marketing_crm_notes.StandardTab = true;
			grd_marketing_crm_notes.TabIndex = 246;
			// 
			// _cmd_verify_yacht_6
			// 
			_cmd_verify_yacht_6.AllowDrop = true;
			_cmd_verify_yacht_6.BackColor = System.Drawing.SystemColors.Control;
			_cmd_verify_yacht_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_verify_yacht_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_verify_yacht_6.Location = new System.Drawing.Point(272, 4);
			_cmd_verify_yacht_6.Name = "_cmd_verify_yacht_6";
			_cmd_verify_yacht_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_verify_yacht_6.Size = new System.Drawing.Size(71, 25);
			_cmd_verify_yacht_6.TabIndex = 297;
			_cmd_verify_yacht_6.Text = "Refresh";
			_cmd_verify_yacht_6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_verify_yacht_6.UseVisualStyleBackColor = false;
			_cmd_verify_yacht_6.Click += new System.EventHandler(cmd_verify_yacht_Click);
			// 
			// _txt_market_note_0
			// 
			_txt_market_note_0.AcceptsReturn = true;
			_txt_market_note_0.AllowDrop = true;
			_txt_market_note_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_market_note_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_market_note_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_market_note_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_market_note_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_market_note_0.Location = new System.Drawing.Point(8, 12);
			_txt_market_note_0.MaxLength = 0;
			_txt_market_note_0.Name = "_txt_market_note_0";
			_txt_market_note_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_market_note_0.Size = new System.Drawing.Size(221, 19);
			_txt_market_note_0.TabIndex = 300;
			_txt_market_note_0.DoubleClick += new System.EventHandler(txt_market_note_DoubleClick);
			_txt_market_note_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_market_note_KeyPress);
			_txt_market_note_0.TextChanged += new System.EventHandler(txt_market_note_TextChanged);
			// 
			// _tab_company_details_TabPage8
			// 
			_tab_company_details_TabPage8.Controls.Add(_chk_comp_product_code_6);
			_tab_company_details_TabPage8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_details_TabPage8.Text = "Yachts";
			// 
			// _chk_comp_product_code_6
			// 
			_chk_comp_product_code_6.AllowDrop = true;
			_chk_comp_product_code_6.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_comp_product_code_6.BackColor = System.Drawing.SystemColors.Control;
			_chk_comp_product_code_6.CausesValidation = true;
			_chk_comp_product_code_6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_comp_product_code_6.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_comp_product_code_6.Enabled = true;
			_chk_comp_product_code_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_comp_product_code_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_comp_product_code_6.Location = new System.Drawing.Point(800, 308);
			_chk_comp_product_code_6.Name = "_chk_comp_product_code_6";
			_chk_comp_product_code_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_comp_product_code_6.Size = new System.Drawing.Size(97, 18);
			_chk_comp_product_code_6.TabIndex = 242;
			_chk_comp_product_code_6.TabStop = true;
			_chk_comp_product_code_6.Text = "Useless Check";
			_chk_comp_product_code_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_comp_product_code_6.Visible = true;
			// 
			// _tab_company_details_TabPage9
			// 
			_tab_company_details_TabPage9.Controls.Add(gdCompDocInProcess);
			_tab_company_details_TabPage9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_details_TabPage9.Text = "Docs In Process";
			// 
			// gdCompDocInProcess
			// 
			gdCompDocInProcess.AllowDrop = true;
			gdCompDocInProcess.AllowUserToAddRows = false;
			gdCompDocInProcess.AllowUserToDeleteRows = false;
			gdCompDocInProcess.AllowUserToResizeColumns = false;
			gdCompDocInProcess.AllowUserToResizeColumns = gdCompDocInProcess.ColumnHeadersVisible;
			gdCompDocInProcess.AllowUserToResizeRows = false;
			gdCompDocInProcess.AllowUserToResizeRows = false;
			gdCompDocInProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			gdCompDocInProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			gdCompDocInProcess.ColumnsCount = 2;
			gdCompDocInProcess.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
			gdCompDocInProcess.FixedColumns = 0;
			gdCompDocInProcess.FixedRows = 1;
			gdCompDocInProcess.Location = new System.Drawing.Point(6, 53);
			gdCompDocInProcess.Name = "gdCompDocInProcess";
			gdCompDocInProcess.ReadOnly = true;
			gdCompDocInProcess.RowsCount = 2;
			gdCompDocInProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			gdCompDocInProcess.ShowCellToolTips = false;
			gdCompDocInProcess.Size = new System.Drawing.Size(995, 255);
			gdCompDocInProcess.StandardTab = true;
			gdCompDocInProcess.TabIndex = 366;
			gdCompDocInProcess.DoubleClick += new System.EventHandler(gdCompDocInProcess_DoubleClick);
			// 
			// _tab_company_details_TabPage10
			// 
			_tab_company_details_TabPage10.Controls.Add(grd_pubs);
			_tab_company_details_TabPage10.Controls.Add(_chk_comp_product_code_7);
			_tab_company_details_TabPage10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_details_TabPage10.Text = "Tasks";
			// 
			// grd_pubs
			// 
			grd_pubs.AllowDrop = true;
			grd_pubs.AllowUserToAddRows = false;
			grd_pubs.AllowUserToDeleteRows = false;
			grd_pubs.AllowUserToResizeColumns = false;
			grd_pubs.AllowUserToResizeColumns = grd_pubs.ColumnHeadersVisible;
			grd_pubs.AllowUserToResizeRows = false;
			grd_pubs.AllowUserToResizeRows = false;
			grd_pubs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_pubs.ColumnsCount = 2;
			grd_pubs.FixedColumns = 1;
			grd_pubs.FixedRows = 1;
			grd_pubs.Location = new System.Drawing.Point(16, 12);
			grd_pubs.Name = "grd_pubs";
			grd_pubs.ReadOnly = true;
			grd_pubs.RowsCount = 2;
			grd_pubs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_pubs.ShowCellToolTips = false;
			grd_pubs.Size = new System.Drawing.Size(971, 237);
			grd_pubs.StandardTab = true;
			grd_pubs.TabIndex = 367;
			grd_pubs.DoubleClick += new System.EventHandler(grd_pubs_DoubleClick);
			// 
			// _chk_comp_product_code_7
			// 
			_chk_comp_product_code_7.AllowDrop = true;
			_chk_comp_product_code_7.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_comp_product_code_7.BackColor = System.Drawing.SystemColors.Control;
			_chk_comp_product_code_7.CausesValidation = true;
			_chk_comp_product_code_7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_comp_product_code_7.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_comp_product_code_7.Enabled = true;
			_chk_comp_product_code_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_comp_product_code_7.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_comp_product_code_7.Location = new System.Drawing.Point(888, 260);
			_chk_comp_product_code_7.Name = "_chk_comp_product_code_7";
			_chk_comp_product_code_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_comp_product_code_7.Size = new System.Drawing.Size(97, 18);
			_chk_comp_product_code_7.TabIndex = 243;
			_chk_comp_product_code_7.TabStop = true;
			_chk_comp_product_code_7.Text = "Include Class E";
			_chk_comp_product_code_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_comp_product_code_7.Visible = true;
			// 
			// pnl_company_main
			// 
			pnl_company_main.AllowDrop = true;
			pnl_company_main.BackColor = System.Drawing.SystemColors.Control;
			pnl_company_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_company_main.Controls.Add(_chk_company_flag_1);
			pnl_company_main.Controls.Add(chkCompDoNotSendEMail);
			pnl_company_main.Controls.Add(txt_comp_name);
			pnl_company_main.Controls.Add(_chk_company_flag_0);
			pnl_company_main.Controls.Add(cbo_comp_name_alt_type);
			pnl_company_main.Controls.Add(txt_comp_email_address);
			pnl_company_main.Controls.Add(txt_comp_name_alt);
			pnl_company_main.Controls.Add(cmd_company_add_note);
			pnl_company_main.Controls.Add(txt_history_date);
			pnl_company_main.Controls.Add(cmd_company_save);
			pnl_company_main.Controls.Add(txt_comp_web_address);
			pnl_company_main.Controls.Add(cbo_comp_timezone);
			pnl_company_main.Controls.Add(txt_comp_city);
			pnl_company_main.Controls.Add(txt_comp_address1);
			pnl_company_main.Controls.Add(txt_comp_id);
			pnl_company_main.Controls.Add(txt_comp_zip_code);
			pnl_company_main.Controls.Add(cbo_comp_state);
			pnl_company_main.Controls.Add(txt_comp_address2);
			pnl_company_main.Controls.Add(cbo_comp_country);
			pnl_company_main.Controls.Add(chk_dont_color_confirm);
			pnl_company_main.Controls.Add(pnl_company_name_change);
			pnl_company_main.Controls.Add(grd_company_phone);
			pnl_company_main.Controls.Add(frame_comp_phone);
			pnl_company_main.Controls.Add(_lbl_test_omg3_3);
			pnl_company_main.Controls.Add(_lbl_comp_64);
			pnl_company_main.Controls.Add(lbl_Time);
			pnl_company_main.Controls.Add(lbl_message);
			pnl_company_main.Controls.Add(_lbl_comp_55);
			pnl_company_main.Controls.Add(_lbl_comp_63);
			pnl_company_main.Controls.Add(_lbl_comp_23);
			pnl_company_main.Controls.Add(_lbl_comp_26);
			pnl_company_main.Controls.Add(_lbl_comp_0);
			pnl_company_main.Controls.Add(_lbl_comp_66);
			pnl_company_main.Controls.Add(_lbl_comp_65);
			pnl_company_main.Controls.Add(_lbl_comp_76);
			pnl_company_main.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_company_main.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_company_main.Location = new System.Drawing.Point(0, 48);
			pnl_company_main.Name = "pnl_company_main";
			pnl_company_main.Size = new System.Drawing.Size(357, 334);
			pnl_company_main.TabIndex = 20;
			// 
			// _chk_company_flag_1
			// 
			_chk_company_flag_1.AllowDrop = true;
			_chk_company_flag_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_company_flag_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_company_flag_1.CausesValidation = true;
			_chk_company_flag_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_company_flag_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_company_flag_1.Enabled = true;
			_chk_company_flag_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_company_flag_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_company_flag_1.Location = new System.Drawing.Point(286, 16);
			_chk_company_flag_1.Name = "_chk_company_flag_1";
			_chk_company_flag_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_company_flag_1.Size = new System.Drawing.Size(65, 13);
			_chk_company_flag_1.TabIndex = 82;
			_chk_company_flag_1.TabStop = true;
			_chk_company_flag_1.Text = "Hide?";
			_chk_company_flag_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_company_flag_1.Visible = true;
			_chk_company_flag_1.CheckStateChanged += new System.EventHandler(chk_company_flag_CheckStateChanged);
			// 
			// chkCompDoNotSendEMail
			// 
			chkCompDoNotSendEMail.AllowDrop = true;
			chkCompDoNotSendEMail.Appearance = System.Windows.Forms.Appearance.Normal;
			chkCompDoNotSendEMail.BackColor = System.Drawing.SystemColors.Control;
			chkCompDoNotSendEMail.CausesValidation = true;
			chkCompDoNotSendEMail.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCompDoNotSendEMail.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkCompDoNotSendEMail.Enabled = true;
			chkCompDoNotSendEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkCompDoNotSendEMail.ForeColor = System.Drawing.SystemColors.WindowText;
			chkCompDoNotSendEMail.Location = new System.Drawing.Point(8, 316);
			chkCompDoNotSendEMail.Name = "chkCompDoNotSendEMail";
			chkCompDoNotSendEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkCompDoNotSendEMail.Size = new System.Drawing.Size(118, 13);
			chkCompDoNotSendEMail.TabIndex = 16;
			chkCompDoNotSendEMail.TabStop = true;
			chkCompDoNotSendEMail.Text = "Do Not Send EMail";
			chkCompDoNotSendEMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCompDoNotSendEMail.Visible = true;
			chkCompDoNotSendEMail.CheckStateChanged += new System.EventHandler(chkCompDoNotSendEMail_CheckStateChanged);
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
			txt_comp_name.Location = new System.Drawing.Point(92, 31);
			txt_comp_name.MaxLength = 99;
			txt_comp_name.Name = "txt_comp_name";
			txt_comp_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_name.Size = new System.Drawing.Size(259, 21);
			txt_comp_name.TabIndex = 88;
			// 
			// _chk_company_flag_0
			// 
			_chk_company_flag_0.AllowDrop = true;
			_chk_company_flag_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_company_flag_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_company_flag_0.CausesValidation = true;
			_chk_company_flag_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_company_flag_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_company_flag_0.Enabled = true;
			_chk_company_flag_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_company_flag_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_company_flag_0.Location = new System.Drawing.Point(286, 1);
			_chk_company_flag_0.Name = "_chk_company_flag_0";
			_chk_company_flag_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_company_flag_0.Size = new System.Drawing.Size(65, 13);
			_chk_company_flag_0.TabIndex = 81;
			_chk_company_flag_0.TabStop = true;
			_chk_company_flag_0.Text = "Inactive?";
			_chk_company_flag_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_company_flag_0.Visible = true;
			_chk_company_flag_0.CheckStateChanged += new System.EventHandler(chk_company_flag_CheckStateChanged);
			// 
			// cbo_comp_name_alt_type
			// 
			cbo_comp_name_alt_type.AllowDrop = true;
			cbo_comp_name_alt_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_comp_name_alt_type.CausesValidation = true;
			cbo_comp_name_alt_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_comp_name_alt_type.Enabled = true;
			cbo_comp_name_alt_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_name_alt_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_comp_name_alt_type.IntegralHeight = true;
			cbo_comp_name_alt_type.Location = new System.Drawing.Point(9, 54);
			cbo_comp_name_alt_type.Name = "cbo_comp_name_alt_type";
			cbo_comp_name_alt_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_name_alt_type.Size = new System.Drawing.Size(81, 21);
			cbo_comp_name_alt_type.Sorted = false;
			cbo_comp_name_alt_type.TabIndex = 75;
			cbo_comp_name_alt_type.TabStop = true;
			cbo_comp_name_alt_type.Visible = true;
			cbo_comp_name_alt_type.Items.AddRange(new object[]{"", "C/O", "DBA", "AKA"});
			cbo_comp_name_alt_type.SelectionChangeCommitted += new System.EventHandler(cbo_comp_name_alt_type_SelectionChangeCommitted);
			// 
			// txt_comp_email_address
			// 
			txt_comp_email_address.AcceptsReturn = true;
			txt_comp_email_address.AllowDrop = true;
			txt_comp_email_address.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_email_address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_email_address.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_email_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_email_address.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_email_address.Location = new System.Drawing.Point(80, 290);
			txt_comp_email_address.MaxLength = 150;
			txt_comp_email_address.Name = "txt_comp_email_address";
			txt_comp_email_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_email_address.Size = new System.Drawing.Size(207, 19);
			txt_comp_email_address.TabIndex = 15;
			txt_comp_email_address.DoubleClick += new System.EventHandler(txt_comp_email_address_DoubleClick);
			// 
			// txt_comp_name_alt
			// 
			txt_comp_name_alt.AcceptsReturn = true;
			txt_comp_name_alt.AllowDrop = true;
			txt_comp_name_alt.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_name_alt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_name_alt.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_name_alt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_name_alt.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_name_alt.Location = new System.Drawing.Point(92, 54);
			txt_comp_name_alt.MaxLength = 100;
			txt_comp_name_alt.Name = "txt_comp_name_alt";
			txt_comp_name_alt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_name_alt.Size = new System.Drawing.Size(259, 21);
			txt_comp_name_alt.TabIndex = 0;
			// 
			// cmd_company_add_note
			// 
			cmd_company_add_note.AllowDrop = true;
			cmd_company_add_note.BackColor = System.Drawing.SystemColors.Control;
			cmd_company_add_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_company_add_note.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_company_add_note.Location = new System.Drawing.Point(293, 288);
			cmd_company_add_note.Name = "cmd_company_add_note";
			cmd_company_add_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_company_add_note.Size = new System.Drawing.Size(58, 20);
			cmd_company_add_note.TabIndex = 43;
			cmd_company_add_note.Text = "&Add Note";
			cmd_company_add_note.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_company_add_note.UseVisualStyleBackColor = false;
			cmd_company_add_note.Click += new System.EventHandler(cmd_company_add_note_Click);
			cmd_company_add_note.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_company_add_note_MouseUp);
			// 
			// txt_history_date
			// 
			txt_history_date.AcceptsReturn = true;
			txt_history_date.AllowDrop = true;
			txt_history_date.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_history_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_history_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_history_date.Enabled = false;
			txt_history_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_history_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_history_date.Location = new System.Drawing.Point(280, 168);
			txt_history_date.MaxLength = 0;
			txt_history_date.Name = "txt_history_date";
			txt_history_date.ReadOnly = true;
			txt_history_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_history_date.Size = new System.Drawing.Size(67, 19);
			txt_history_date.TabIndex = 36;
			txt_history_date.Tag = "N";
			// 
			// cmd_company_save
			// 
			cmd_company_save.AllowDrop = true;
			cmd_company_save.BackColor = System.Drawing.SystemColors.Control;
			cmd_company_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_company_save.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_company_save.Location = new System.Drawing.Point(136, 312);
			cmd_company_save.Name = "cmd_company_save";
			cmd_company_save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_company_save.Size = new System.Drawing.Size(99, 21);
			cmd_company_save.TabIndex = 26;
			cmd_company_save.Text = "&Save Company";
			cmd_company_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_company_save.UseVisualStyleBackColor = false;
			cmd_company_save.Click += new System.EventHandler(cmd_company_save_Click);
			// 
			// txt_comp_web_address
			// 
			txt_comp_web_address.AcceptsReturn = true;
			txt_comp_web_address.AllowDrop = true;
			txt_comp_web_address.BackColor = System.Drawing.Color.White;
			txt_comp_web_address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_web_address.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_web_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_web_address.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_web_address.Location = new System.Drawing.Point(80, 268);
			txt_comp_web_address.MaxLength = 0;
			txt_comp_web_address.Name = "txt_comp_web_address";
			txt_comp_web_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_web_address.Size = new System.Drawing.Size(271, 19);
			txt_comp_web_address.TabIndex = 14;
			txt_comp_web_address.DoubleClick += new System.EventHandler(txt_comp_web_address_DoubleClick);
			// 
			// cbo_comp_timezone
			// 
			cbo_comp_timezone.AllowDrop = true;
			cbo_comp_timezone.BackColor = System.Drawing.SystemColors.Window;
			cbo_comp_timezone.CausesValidation = true;
			cbo_comp_timezone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_comp_timezone.Enabled = false;
			cbo_comp_timezone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_timezone.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_comp_timezone.IntegralHeight = true;
			cbo_comp_timezone.Location = new System.Drawing.Point(260, 146);
			cbo_comp_timezone.Name = "cbo_comp_timezone";
			cbo_comp_timezone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_timezone.Size = new System.Drawing.Size(92, 21);
			cbo_comp_timezone.Sorted = false;
			cbo_comp_timezone.TabIndex = 7;
			cbo_comp_timezone.TabStop = true;
			cbo_comp_timezone.Visible = true;
			cbo_comp_timezone.SelectedIndexChanged += new System.EventHandler(cbo_comp_timezone_SelectedIndexChanged);
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
			txt_comp_city.Location = new System.Drawing.Point(92, 123);
			txt_comp_city.MaxLength = 0;
			txt_comp_city.Name = "txt_comp_city";
			txt_comp_city.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_city.Size = new System.Drawing.Size(95, 21);
			txt_comp_city.TabIndex = 3;
			txt_comp_city.Leave += new System.EventHandler(txt_comp_city_Leave);
			// 
			// txt_comp_address1
			// 
			txt_comp_address1.AcceptsReturn = true;
			txt_comp_address1.AllowDrop = true;
			txt_comp_address1.BackColor = System.Drawing.Color.White;
			txt_comp_address1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_address1.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_address1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_address1.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_address1.Location = new System.Drawing.Point(92, 77);
			txt_comp_address1.MaxLength = 50;
			txt_comp_address1.Name = "txt_comp_address1";
			txt_comp_address1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_address1.Size = new System.Drawing.Size(259, 21);
			txt_comp_address1.TabIndex = 1;
			// 
			// txt_comp_id
			// 
			txt_comp_id.AcceptsReturn = true;
			txt_comp_id.AllowDrop = true;
			txt_comp_id.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_comp_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_id.Enabled = false;
			txt_comp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_id.Location = new System.Drawing.Point(214, 6);
			txt_comp_id.MaxLength = 0;
			txt_comp_id.Name = "txt_comp_id";
			txt_comp_id.ReadOnly = true;
			txt_comp_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_id.Size = new System.Drawing.Size(63, 19);
			txt_comp_id.TabIndex = 21;
			txt_comp_id.Tag = "N";
			txt_comp_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
			txt_comp_zip_code.Location = new System.Drawing.Point(278, 123);
			txt_comp_zip_code.MaxLength = 10;
			txt_comp_zip_code.Name = "txt_comp_zip_code";
			txt_comp_zip_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_zip_code.Size = new System.Drawing.Size(73, 21);
			txt_comp_zip_code.TabIndex = 5;
			// 
			// cbo_comp_state
			// 
			cbo_comp_state.AllowDrop = true;
			cbo_comp_state.BackColor = System.Drawing.SystemColors.Window;
			cbo_comp_state.CausesValidation = true;
			cbo_comp_state.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_comp_state.Enabled = true;
			cbo_comp_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_state.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_comp_state.IntegralHeight = true;
			cbo_comp_state.Location = new System.Drawing.Point(189, 120);
			cbo_comp_state.Name = "cbo_comp_state";
			cbo_comp_state.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_state.Size = new System.Drawing.Size(86, 21);
			cbo_comp_state.Sorted = false;
			cbo_comp_state.TabIndex = 4;
			cbo_comp_state.TabStop = true;
			cbo_comp_state.Visible = true;
			cbo_comp_state.SelectedIndexChanged += new System.EventHandler(cbo_comp_state_SelectedIndexChanged);
			// 
			// txt_comp_address2
			// 
			txt_comp_address2.AcceptsReturn = true;
			txt_comp_address2.AllowDrop = true;
			txt_comp_address2.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_address2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_address2.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_address2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_address2.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_address2.Location = new System.Drawing.Point(92, 100);
			txt_comp_address2.MaxLength = 50;
			txt_comp_address2.Name = "txt_comp_address2";
			txt_comp_address2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_address2.Size = new System.Drawing.Size(259, 21);
			txt_comp_address2.TabIndex = 2;
			// 
			// cbo_comp_country
			// 
			cbo_comp_country.AllowDrop = true;
			cbo_comp_country.BackColor = System.Drawing.SystemColors.Window;
			cbo_comp_country.CausesValidation = true;
			cbo_comp_country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_comp_country.Enabled = true;
			cbo_comp_country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_country.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_comp_country.IntegralHeight = true;
			cbo_comp_country.Location = new System.Drawing.Point(92, 146);
			cbo_comp_country.Name = "cbo_comp_country";
			cbo_comp_country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_country.Size = new System.Drawing.Size(105, 21);
			cbo_comp_country.Sorted = false;
			cbo_comp_country.TabIndex = 6;
			cbo_comp_country.TabStop = true;
			cbo_comp_country.Visible = true;
			cbo_comp_country.DoubleClick += new System.EventHandler(cbo_comp_country_DoubleClick);
			cbo_comp_country.SelectedIndexChanged += new System.EventHandler(cbo_comp_country_SelectedIndexChanged);
			// 
			// chk_dont_color_confirm
			// 
			chk_dont_color_confirm.AllowDrop = true;
			chk_dont_color_confirm.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_dont_color_confirm.BackColor = System.Drawing.SystemColors.Control;
			chk_dont_color_confirm.CausesValidation = true;
			chk_dont_color_confirm.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_dont_color_confirm.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_dont_color_confirm.Enabled = true;
			chk_dont_color_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_dont_color_confirm.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_dont_color_confirm.Location = new System.Drawing.Point(255, 315);
			chk_dont_color_confirm.Name = "chk_dont_color_confirm";
			chk_dont_color_confirm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_dont_color_confirm.Size = new System.Drawing.Size(95, 13);
			chk_dont_color_confirm.TabIndex = 17;
			chk_dont_color_confirm.TabStop = true;
			chk_dont_color_confirm.Text = "Do Not Confirm";
			chk_dont_color_confirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_dont_color_confirm.Visible = true;
			// 
			// time_ac_timer
			// 
			time_ac_timer.Enabled = false;
			time_ac_timer.Interval = 1;
			time_ac_timer.Tick += new System.EventHandler(time_ac_timer_Tick);
			// 
			// time_cc_timer
			// 
			time_cc_timer.Enabled = false;
			time_cc_timer.Interval = 1;
			time_cc_timer.Tick += new System.EventHandler(time_cc_timer_Tick);
			// 
			// time_at_company
			// 
			time_at_company.Enabled = false;
			time_at_company.Interval = 1000;
			time_at_company.Tick += new System.EventHandler(time_at_company_Tick);
			// 
			// pnl_company_name_change
			// 
			pnl_company_name_change.AllowDrop = true;
			pnl_company_name_change.BackColor = System.Drawing.SystemColors.Control;
			pnl_company_name_change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_company_name_change.Controls.Add(cmd_company_name_change_cancel);
			pnl_company_name_change.Controls.Add(txt_comp_name_change_new);
			pnl_company_name_change.Controls.Add(txt_comp_name_current);
			pnl_company_name_change.Controls.Add(_lbl_comp_16);
			pnl_company_name_change.Controls.Add(_lbl_comp_14);
			pnl_company_name_change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_company_name_change.Location = new System.Drawing.Point(8, 32);
			pnl_company_name_change.Name = "pnl_company_name_change";
			pnl_company_name_change.Size = new System.Drawing.Size(355, 115);
			pnl_company_name_change.TabIndex = 37;
			pnl_company_name_change.Visible = false;
			// 
			// cmd_company_name_change_cancel
			// 
			cmd_company_name_change_cancel.AllowDrop = true;
			cmd_company_name_change_cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_company_name_change_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_company_name_change_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_company_name_change_cancel.Location = new System.Drawing.Point(277, 10);
			cmd_company_name_change_cancel.Name = "cmd_company_name_change_cancel";
			cmd_company_name_change_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_company_name_change_cancel.Size = new System.Drawing.Size(70, 22);
			cmd_company_name_change_cancel.TabIndex = 40;
			cmd_company_name_change_cancel.Text = "&Cancel";
			cmd_company_name_change_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_company_name_change_cancel.UseVisualStyleBackColor = false;
			cmd_company_name_change_cancel.Click += new System.EventHandler(cmd_company_name_change_cancel_Click);
			cmd_company_name_change_cancel.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_company_name_change_cancel_MouseUp);
			// 
			// txt_comp_name_change_new
			// 
			txt_comp_name_change_new.AcceptsReturn = true;
			txt_comp_name_change_new.AllowDrop = true;
			txt_comp_name_change_new.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_name_change_new.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_name_change_new.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_name_change_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_name_change_new.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_name_change_new.Location = new System.Drawing.Point(9, 83);
			txt_comp_name_change_new.MaxLength = 0;
			txt_comp_name_change_new.Name = "txt_comp_name_change_new";
			txt_comp_name_change_new.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_name_change_new.Size = new System.Drawing.Size(338, 23);
			txt_comp_name_change_new.TabIndex = 39;
			// 
			// txt_comp_name_current
			// 
			txt_comp_name_current.AcceptsReturn = true;
			txt_comp_name_current.AllowDrop = true;
			txt_comp_name_current.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_name_current.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_name_current.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_name_current.Enabled = false;
			txt_comp_name_current.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_name_current.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_name_current.Location = new System.Drawing.Point(8, 39);
			txt_comp_name_current.MaxLength = 0;
			txt_comp_name_current.Name = "txt_comp_name_current";
			txt_comp_name_current.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_name_current.Size = new System.Drawing.Size(338, 23);
			txt_comp_name_current.TabIndex = 38;
			// 
			// _lbl_comp_16
			// 
			_lbl_comp_16.AllowDrop = true;
			_lbl_comp_16.AutoSize = true;
			_lbl_comp_16.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_16.Location = new System.Drawing.Point(8, 68);
			_lbl_comp_16.MinimumSize = new System.Drawing.Size(56, 13);
			_lbl_comp_16.Name = "_lbl_comp_16";
			_lbl_comp_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_16.Size = new System.Drawing.Size(56, 13);
			_lbl_comp_16.TabIndex = 42;
			_lbl_comp_16.Text = "Change To:";
			_lbl_comp_16.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_16.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_16.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_14
			// 
			_lbl_comp_14.AllowDrop = true;
			_lbl_comp_14.AutoSize = true;
			_lbl_comp_14.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_14.Location = new System.Drawing.Point(9, 22);
			_lbl_comp_14.MinimumSize = new System.Drawing.Size(37, 13);
			_lbl_comp_14.Name = "_lbl_comp_14";
			_lbl_comp_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_14.Size = new System.Drawing.Size(37, 13);
			_lbl_comp_14.TabIndex = 41;
			_lbl_comp_14.Text = "Current:";
			_lbl_comp_14.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_14.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_14.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// grd_company_phone
			// 
			grd_company_phone.AllowDrop = true;
			grd_company_phone.AllowUserToAddRows = false;
			grd_company_phone.AllowUserToDeleteRows = false;
			grd_company_phone.AllowUserToResizeColumns = false;
			grd_company_phone.AllowUserToResizeColumns = grd_company_phone.ColumnHeadersVisible;
			grd_company_phone.AllowUserToResizeRows = false;
			grd_company_phone.AllowUserToResizeRows = false;
			grd_company_phone.BackgroundColor = System.Drawing.SystemColors.Window;
			grd_company_phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_phone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_phone.ColumnsCount = 2;
			grd_company_phone.FixedColumns = 0;
			grd_company_phone.FixedRows = 1;
			grd_company_phone.Location = new System.Drawing.Point(2, 192);
			grd_company_phone.Name = "grd_company_phone";
			grd_company_phone.ReadOnly = true;
			grd_company_phone.RowsCount = 2;
			grd_company_phone.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_company_phone.ShowCellToolTips = false;
			grd_company_phone.Size = new System.Drawing.Size(343, 73);
			grd_company_phone.StandardTab = true;
			grd_company_phone.TabIndex = 85;
			grd_company_phone.Click += new System.EventHandler(grd_company_phone_Click);
			grd_company_phone.DoubleClick += new System.EventHandler(grd_company_phone_DoubleClick);
			grd_company_phone.MouseDown += new System.Windows.Forms.MouseEventHandler(grd_company_phone_MouseDown);
			// 
			// frame_comp_phone
			// 
			frame_comp_phone.AllowDrop = true;
			frame_comp_phone.BackColor = System.Drawing.SystemColors.Control;
			frame_comp_phone.Controls.Add(chk_comp_pnum_hide_customer);
			frame_comp_phone.Controls.Add(cmd_company_phone_confirm);
			frame_comp_phone.Controls.Add(txt_pnum_prefix);
			frame_comp_phone.Controls.Add(cbo_comp_pnum_type);
			frame_comp_phone.Controls.Add(cmd_company_phone_cancel);
			frame_comp_phone.Controls.Add(txt_pnum_cntry_code);
			frame_comp_phone.Controls.Add(txt_pnum_number);
			frame_comp_phone.Controls.Add(txt_pnum_area_code);
			frame_comp_phone.Controls.Add(cmd_company_phone_save);
			frame_comp_phone.Controls.Add(_lbl_comp_45);
			frame_comp_phone.Controls.Add(_lbl_comp_24);
			frame_comp_phone.Controls.Add(_lbl_comp_52);
			frame_comp_phone.Controls.Add(_lbl_comp_25);
			frame_comp_phone.Controls.Add(_lbl_comp_53);
			frame_comp_phone.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_comp_phone.Enabled = true;
			frame_comp_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_comp_phone.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_comp_phone.Location = new System.Drawing.Point(8, 192);
			frame_comp_phone.Name = "frame_comp_phone";
			frame_comp_phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_comp_phone.Size = new System.Drawing.Size(340, 77);
			frame_comp_phone.TabIndex = 27;
			frame_comp_phone.Text = " Company Phone Number Details ";
			frame_comp_phone.Visible = true;
			// 
			// chk_comp_pnum_hide_customer
			// 
			chk_comp_pnum_hide_customer.AllowDrop = true;
			chk_comp_pnum_hide_customer.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_comp_pnum_hide_customer.BackColor = System.Drawing.SystemColors.Control;
			chk_comp_pnum_hide_customer.CausesValidation = true;
			chk_comp_pnum_hide_customer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_comp_pnum_hide_customer.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_comp_pnum_hide_customer.Enabled = true;
			chk_comp_pnum_hide_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_comp_pnum_hide_customer.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_comp_pnum_hide_customer.Location = new System.Drawing.Point(135, 56);
			chk_comp_pnum_hide_customer.Name = "chk_comp_pnum_hide_customer";
			chk_comp_pnum_hide_customer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_comp_pnum_hide_customer.Size = new System.Drawing.Size(128, 13);
			chk_comp_pnum_hide_customer.TabIndex = 13;
			chk_comp_pnum_hide_customer.TabStop = true;
			chk_comp_pnum_hide_customer.Text = "Hide From Customer";
			chk_comp_pnum_hide_customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_comp_pnum_hide_customer.Visible = true;
			// 
			// cmd_company_phone_confirm
			// 
			cmd_company_phone_confirm.AllowDrop = true;
			cmd_company_phone_confirm.BackColor = System.Drawing.SystemColors.Control;
			cmd_company_phone_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_company_phone_confirm.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_company_phone_confirm.Location = new System.Drawing.Point(8, 50);
			cmd_company_phone_confirm.Name = "cmd_company_phone_confirm";
			cmd_company_phone_confirm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_company_phone_confirm.Size = new System.Drawing.Size(111, 23);
			cmd_company_phone_confirm.TabIndex = 35;
			cmd_company_phone_confirm.Text = "&Confirm/Save";
			cmd_company_phone_confirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_company_phone_confirm.UseVisualStyleBackColor = false;
			cmd_company_phone_confirm.Click += new System.EventHandler(cmd_company_phone_confirm_Click);
			cmd_company_phone_confirm.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_company_phone_confirm_MouseUp);
			// 
			// txt_pnum_prefix
			// 
			txt_pnum_prefix.AcceptsReturn = true;
			txt_pnum_prefix.AllowDrop = true;
			txt_pnum_prefix.BackColor = System.Drawing.SystemColors.Window;
			txt_pnum_prefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_pnum_prefix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_pnum_prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_pnum_prefix.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_pnum_prefix.Location = new System.Drawing.Point(224, 28);
			txt_pnum_prefix.MaxLength = 6;
			txt_pnum_prefix.Name = "txt_pnum_prefix";
			txt_pnum_prefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_pnum_prefix.Size = new System.Drawing.Size(45, 21);
			txt_pnum_prefix.TabIndex = 11;
			txt_pnum_prefix.TextChanged += new System.EventHandler(txt_pnum_prefix_TextChanged);
			// 
			// cbo_comp_pnum_type
			// 
			cbo_comp_pnum_type.AllowDrop = true;
			cbo_comp_pnum_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_comp_pnum_type.CausesValidation = true;
			cbo_comp_pnum_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_comp_pnum_type.Enabled = true;
			cbo_comp_pnum_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_pnum_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_comp_pnum_type.IntegralHeight = true;
			cbo_comp_pnum_type.Location = new System.Drawing.Point(9, 28);
			cbo_comp_pnum_type.Name = "cbo_comp_pnum_type";
			cbo_comp_pnum_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_pnum_type.Size = new System.Drawing.Size(104, 21);
			cbo_comp_pnum_type.Sorted = false;
			cbo_comp_pnum_type.TabIndex = 8;
			cbo_comp_pnum_type.TabStop = true;
			cbo_comp_pnum_type.Visible = true;
			cbo_comp_pnum_type.SelectedIndexChanged += new System.EventHandler(cbo_comp_pnum_type_SelectedIndexChanged);
			cbo_comp_pnum_type.TextChanged += new System.EventHandler(cbo_comp_pnum_type_TextChanged);
			// 
			// cmd_company_phone_cancel
			// 
			cmd_company_phone_cancel.AllowDrop = true;
			cmd_company_phone_cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_company_phone_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_company_phone_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_company_phone_cancel.Location = new System.Drawing.Point(272, 52);
			cmd_company_phone_cancel.Name = "cmd_company_phone_cancel";
			cmd_company_phone_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_company_phone_cancel.Size = new System.Drawing.Size(65, 21);
			cmd_company_phone_cancel.TabIndex = 32;
			cmd_company_phone_cancel.Text = "&Cancel";
			cmd_company_phone_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_company_phone_cancel.UseVisualStyleBackColor = false;
			cmd_company_phone_cancel.Click += new System.EventHandler(cmd_company_phone_cancel_Click);
			cmd_company_phone_cancel.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_company_phone_cancel_MouseUp);
			// 
			// txt_pnum_cntry_code
			// 
			txt_pnum_cntry_code.AcceptsReturn = true;
			txt_pnum_cntry_code.AllowDrop = true;
			txt_pnum_cntry_code.BackColor = System.Drawing.SystemColors.Window;
			txt_pnum_cntry_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_pnum_cntry_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_pnum_cntry_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_pnum_cntry_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_pnum_cntry_code.Location = new System.Drawing.Point(131, 28);
			txt_pnum_cntry_code.MaxLength = 6;
			txt_pnum_cntry_code.Name = "txt_pnum_cntry_code";
			txt_pnum_cntry_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_pnum_cntry_code.Size = new System.Drawing.Size(45, 21);
			txt_pnum_cntry_code.TabIndex = 9;
			txt_pnum_cntry_code.TextChanged += new System.EventHandler(txt_pnum_cntry_code_TextChanged);
			// 
			// txt_pnum_number
			// 
			txt_pnum_number.AcceptsReturn = true;
			txt_pnum_number.AllowDrop = true;
			txt_pnum_number.BackColor = System.Drawing.SystemColors.Window;
			txt_pnum_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_pnum_number.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_pnum_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_pnum_number.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_pnum_number.Location = new System.Drawing.Point(272, 28);
			txt_pnum_number.MaxLength = 10;
			txt_pnum_number.Name = "txt_pnum_number";
			txt_pnum_number.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_pnum_number.Size = new System.Drawing.Size(64, 21);
			txt_pnum_number.TabIndex = 12;
			txt_pnum_number.TextChanged += new System.EventHandler(txt_pnum_number_TextChanged);
			// 
			// txt_pnum_area_code
			// 
			txt_pnum_area_code.AcceptsReturn = true;
			txt_pnum_area_code.AllowDrop = true;
			txt_pnum_area_code.BackColor = System.Drawing.SystemColors.Window;
			txt_pnum_area_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_pnum_area_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_pnum_area_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_pnum_area_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_pnum_area_code.Location = new System.Drawing.Point(180, 28);
			txt_pnum_area_code.MaxLength = 6;
			txt_pnum_area_code.Name = "txt_pnum_area_code";
			txt_pnum_area_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_pnum_area_code.Size = new System.Drawing.Size(45, 21);
			txt_pnum_area_code.TabIndex = 10;
			txt_pnum_area_code.TextChanged += new System.EventHandler(txt_pnum_area_code_TextChanged);
			// 
			// cmd_company_phone_save
			// 
			cmd_company_phone_save.AllowDrop = true;
			cmd_company_phone_save.BackColor = System.Drawing.SystemColors.Control;
			cmd_company_phone_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_company_phone_save.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_company_phone_save.Location = new System.Drawing.Point(8, 52);
			cmd_company_phone_save.Name = "cmd_company_phone_save";
			cmd_company_phone_save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_company_phone_save.Size = new System.Drawing.Size(25, 21);
			cmd_company_phone_save.TabIndex = 19;
			cmd_company_phone_save.Text = "&Update Phone List";
			cmd_company_phone_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_company_phone_save.UseVisualStyleBackColor = false;
			cmd_company_phone_save.Visible = false;
			cmd_company_phone_save.Click += new System.EventHandler(cmd_company_phone_save_Click);
			cmd_company_phone_save.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_company_phone_save_MouseUp);
			// 
			// _lbl_comp_45
			// 
			_lbl_comp_45.AllowDrop = true;
			_lbl_comp_45.AutoSize = true;
			_lbl_comp_45.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_45.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_45.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_45.Location = new System.Drawing.Point(238, 14);
			_lbl_comp_45.MinimumSize = new System.Drawing.Size(26, 13);
			_lbl_comp_45.Name = "_lbl_comp_45";
			_lbl_comp_45.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_45.Size = new System.Drawing.Size(26, 13);
			_lbl_comp_45.TabIndex = 34;
			_lbl_comp_45.Text = "Prefix";
			_lbl_comp_45.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_45.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_45.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_24
			// 
			_lbl_comp_24.AllowDrop = true;
			_lbl_comp_24.AutoSize = true;
			_lbl_comp_24.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_24.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_24.Location = new System.Drawing.Point(33, 14);
			_lbl_comp_24.MinimumSize = new System.Drawing.Size(24, 13);
			_lbl_comp_24.Name = "_lbl_comp_24";
			_lbl_comp_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_24.Size = new System.Drawing.Size(24, 13);
			_lbl_comp_24.TabIndex = 31;
			_lbl_comp_24.Tag = "lbl_type";
			_lbl_comp_24.Text = "Type";
			_lbl_comp_24.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_24.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_24.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_52
			// 
			_lbl_comp_52.AllowDrop = true;
			_lbl_comp_52.AutoSize = true;
			_lbl_comp_52.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_52.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_52.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_52.Location = new System.Drawing.Point(191, 14);
			_lbl_comp_52.MinimumSize = new System.Drawing.Size(22, 13);
			_lbl_comp_52.Name = "_lbl_comp_52";
			_lbl_comp_52.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_52.Size = new System.Drawing.Size(22, 13);
			_lbl_comp_52.TabIndex = 29;
			_lbl_comp_52.Text = "Area";
			_lbl_comp_52.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_52.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_52.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_25
			// 
			_lbl_comp_25.AllowDrop = true;
			_lbl_comp_25.AutoSize = true;
			_lbl_comp_25.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_25.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_25.Location = new System.Drawing.Point(135, 14);
			_lbl_comp_25.MinimumSize = new System.Drawing.Size(36, 13);
			_lbl_comp_25.Name = "_lbl_comp_25";
			_lbl_comp_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_25.Size = new System.Drawing.Size(36, 13);
			_lbl_comp_25.TabIndex = 28;
			_lbl_comp_25.Tag = "lbl_cntry_code";
			_lbl_comp_25.Text = "Country";
			_lbl_comp_25.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_25.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_25.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_53
			// 
			_lbl_comp_53.AllowDrop = true;
			_lbl_comp_53.AutoSize = true;
			_lbl_comp_53.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_53.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_53.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_53.Location = new System.Drawing.Point(295, 14);
			_lbl_comp_53.MinimumSize = new System.Drawing.Size(31, 13);
			_lbl_comp_53.Name = "_lbl_comp_53";
			_lbl_comp_53.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_53.Size = new System.Drawing.Size(31, 13);
			_lbl_comp_53.TabIndex = 30;
			_lbl_comp_53.Text = "Phone";
			_lbl_comp_53.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_53.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_53.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_test_omg3_3
			// 
			_lbl_test_omg3_3.AllowDrop = true;
			_lbl_test_omg3_3.BackColor = System.Drawing.Color.Aqua;
			_lbl_test_omg3_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_test_omg3_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_test_omg3_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_test_omg3_3.Location = new System.Drawing.Point(168, 168);
			_lbl_test_omg3_3.MinimumSize = new System.Drawing.Size(113, 17);
			_lbl_test_omg3_3.Name = "_lbl_test_omg3_3";
			_lbl_test_omg3_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_test_omg3_3.Size = new System.Drawing.Size(113, 17);
			_lbl_test_omg3_3.TabIndex = 240;
			_lbl_test_omg3_3.Text = "-- You Are On Test --";
			_lbl_test_omg3_3.Visible = false;
			// 
			// _lbl_comp_64
			// 
			_lbl_comp_64.AllowDrop = true;
			_lbl_comp_64.AutoSize = true;
			_lbl_comp_64.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_64.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_64.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_64.Location = new System.Drawing.Point(38, 104);
			_lbl_comp_64.MinimumSize = new System.Drawing.Size(47, 13);
			_lbl_comp_64.Name = "_lbl_comp_64";
			_lbl_comp_64.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_64.Size = new System.Drawing.Size(47, 13);
			_lbl_comp_64.TabIndex = 133;
			_lbl_comp_64.Text = "Address1:";
			_lbl_comp_64.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_64.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_64.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_64.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// lbl_Time
			// 
			lbl_Time.AllowDrop = true;
			lbl_Time.BackColor = System.Drawing.Color.Transparent;
			lbl_Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lbl_Time.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Time.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			lbl_Time.Location = new System.Drawing.Point(6, 6);
			lbl_Time.MinimumSize = new System.Drawing.Size(181, 19);
			lbl_Time.Name = "lbl_Time";
			lbl_Time.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Time.Size = new System.Drawing.Size(181, 19);
			lbl_Time.TabIndex = 95;
			lbl_Time.Tag = "N";
			lbl_Time.Text = "Local Time:";
			lbl_Time.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_message
			// 
			lbl_message.AllowDrop = true;
			lbl_message.BackColor = System.Drawing.Color.Transparent;
			lbl_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lbl_message.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_message.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			lbl_message.Location = new System.Drawing.Point(4, 169);
			lbl_message.MinimumSize = new System.Drawing.Size(267, 19);
			lbl_message.Name = "lbl_message";
			lbl_message.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_message.Size = new System.Drawing.Size(267, 19);
			lbl_message.TabIndex = 94;
			lbl_message.Tag = "N";
			lbl_message.Text = "Status:";
			lbl_message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lbl_comp_55
			// 
			_lbl_comp_55.AllowDrop = true;
			_lbl_comp_55.AutoSize = true;
			_lbl_comp_55.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_55.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_55.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_55.Location = new System.Drawing.Point(38, 35);
			_lbl_comp_55.MinimumSize = new System.Drawing.Size(47, 13);
			_lbl_comp_55.Name = "_lbl_comp_55";
			_lbl_comp_55.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_55.Size = new System.Drawing.Size(47, 13);
			_lbl_comp_55.TabIndex = 89;
			_lbl_comp_55.Text = "Company:";
			_lbl_comp_55.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_55.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_55.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_55.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_63
			// 
			_lbl_comp_63.AllowDrop = true;
			_lbl_comp_63.AutoSize = true;
			_lbl_comp_63.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_63.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_63.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_63.Location = new System.Drawing.Point(44, 81);
			_lbl_comp_63.MinimumSize = new System.Drawing.Size(41, 13);
			_lbl_comp_63.Name = "_lbl_comp_63";
			_lbl_comp_63.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_63.Size = new System.Drawing.Size(41, 13);
			_lbl_comp_63.TabIndex = 78;
			_lbl_comp_63.Text = "Address:";
			_lbl_comp_63.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_63.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_63.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_63.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_23
			// 
			_lbl_comp_23.AllowDrop = true;
			_lbl_comp_23.AutoSize = true;
			_lbl_comp_23.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_23.Location = new System.Drawing.Point(13, 127);
			_lbl_comp_23.MinimumSize = new System.Drawing.Size(72, 13);
			_lbl_comp_23.Name = "_lbl_comp_23";
			_lbl_comp_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_23.Size = new System.Drawing.Size(72, 13);
			_lbl_comp_23.TabIndex = 77;
			_lbl_comp_23.Tag = "lbl_comp_city";
			_lbl_comp_23.Text = "City/State/ZIP:";
			_lbl_comp_23.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_23.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_23.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_23.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_26
			// 
			_lbl_comp_26.AllowDrop = true;
			_lbl_comp_26.AutoSize = true;
			_lbl_comp_26.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_26.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_26.Location = new System.Drawing.Point(46, 150);
			_lbl_comp_26.MinimumSize = new System.Drawing.Size(39, 13);
			_lbl_comp_26.Name = "_lbl_comp_26";
			_lbl_comp_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_26.Size = new System.Drawing.Size(39, 13);
			_lbl_comp_26.TabIndex = 76;
			_lbl_comp_26.Text = "Country:";
			_lbl_comp_26.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_26.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_26.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_26.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_0
			// 
			_lbl_comp_0.AllowDrop = true;
			_lbl_comp_0.AutoSize = true;
			_lbl_comp_0.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_0.Location = new System.Drawing.Point(203, 152);
			_lbl_comp_0.MinimumSize = new System.Drawing.Size(55, 13);
			_lbl_comp_0.Name = "_lbl_comp_0";
			_lbl_comp_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_0.Size = new System.Drawing.Size(55, 13);
			_lbl_comp_0.TabIndex = 25;
			_lbl_comp_0.Text = "Time Zone:";
			_lbl_comp_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_comp_0.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_0.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_0.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_66
			// 
			_lbl_comp_66.AllowDrop = true;
			_lbl_comp_66.AutoSize = true;
			_lbl_comp_66.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_66.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_66.ForeColor = System.Drawing.Color.Black;
			_lbl_comp_66.Location = new System.Drawing.Point(6, 269);
			_lbl_comp_66.MinimumSize = new System.Drawing.Size(67, 13);
			_lbl_comp_66.Name = "_lbl_comp_66";
			_lbl_comp_66.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_66.Size = new System.Drawing.Size(67, 13);
			_lbl_comp_66.TabIndex = 24;
			_lbl_comp_66.Text = "Web Address:";
			_lbl_comp_66.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_66.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_66.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_65
			// 
			_lbl_comp_65.AllowDrop = true;
			_lbl_comp_65.AutoSize = true;
			_lbl_comp_65.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_65.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_65.ForeColor = System.Drawing.Color.Black;
			_lbl_comp_65.Location = new System.Drawing.Point(6, 291);
			_lbl_comp_65.MinimumSize = new System.Drawing.Size(72, 13);
			_lbl_comp_65.Name = "_lbl_comp_65";
			_lbl_comp_65.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_65.Size = new System.Drawing.Size(72, 13);
			_lbl_comp_65.TabIndex = 23;
			_lbl_comp_65.Text = "E-mail Address:";
			_lbl_comp_65.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_65.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_65.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_76
			// 
			_lbl_comp_76.AllowDrop = true;
			_lbl_comp_76.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_76.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_76.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_76.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_76.Location = new System.Drawing.Point(189, 9);
			_lbl_comp_76.MinimumSize = new System.Drawing.Size(25, 17);
			_lbl_comp_76.Name = "_lbl_comp_76";
			_lbl_comp_76.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_76.Size = new System.Drawing.Size(25, 17);
			_lbl_comp_76.TabIndex = 22;
			_lbl_comp_76.Text = "ID#:";
			_lbl_comp_76.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_76.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_76.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// tbr_ToolBar
			// 
			tbr_ToolBar.AllowDrop = true;
			tbr_ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
			tbr_ToolBar.Enabled = false;
			tbr_ToolBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tbr_ToolBar.Location = new System.Drawing.Point(0, 24);
			tbr_ToolBar.Name = "tbr_ToolBar";
			tbr_ToolBar.ShowItemToolTips = true;
			tbr_ToolBar.Size = new System.Drawing.Size(1020, 28);
			tbr_ToolBar.TabIndex = 33;
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button1);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button2);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button3);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button4);
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
			// tab_company_admin
			// 
			tab_company_admin.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_company_admin.AllowDrop = true;
			tab_company_admin.Controls.Add(_tab_company_admin_TabPage0);
			tab_company_admin.Controls.Add(_tab_company_admin_TabPage1);
			tab_company_admin.Controls.Add(_tab_company_admin_TabPage2);
			tab_company_admin.Controls.Add(_tab_company_admin_TabPage3);
			tab_company_admin.Controls.Add(_tab_company_admin_TabPage4);
			tab_company_admin.Controls.Add(_tab_company_admin_TabPage5);
			tab_company_admin.Controls.Add(_tab_company_admin_TabPage6);
			tab_company_admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_company_admin.ItemSize = new System.Drawing.Size(92, 18);
			tab_company_admin.Location = new System.Drawing.Point(356, 48);
			tab_company_admin.Multiline = true;
			tab_company_admin.Name = "tab_company_admin";
			tab_company_admin.Size = new System.Drawing.Size(658, 334);
			tab_company_admin.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_company_admin.TabIndex = 18;
			tab_company_admin.SelectedIndexChanged += new System.EventHandler(tab_company_admin_SelectedIndexChanged);
			// 
			// _tab_company_admin_TabPage0
			// 
			_tab_company_admin_TabPage0.Controls.Add(_shp_dealer_background_0);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_6);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_10);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_39);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_11);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_13);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_28);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_44);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_3);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_22);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_5);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_7);
			_tab_company_admin_TabPage0.Controls.Add(_shp_Shape_0);
			_tab_company_admin_TabPage0.Controls.Add(Shape2);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_87);
			_tab_company_admin_TabPage0.Controls.Add(_lbl_comp_61);
			_tab_company_admin_TabPage0.Controls.Add(cbo_comp_services_used);
			_tab_company_admin_TabPage0.Controls.Add(lst_business_types);
			_tab_company_admin_TabPage0.Controls.Add(cmd_edit_business_types);
			_tab_company_admin_TabPage0.Controls.Add(cbo_comp_govsub_code);
			_tab_company_admin_TabPage0.Controls.Add(cbo_comp_business_type);
			_tab_company_admin_TabPage0.Controls.Add(cbo_comp_agency_type);
			_tab_company_admin_TabPage0.Controls.Add(cbo_comp_language);
			_tab_company_admin_TabPage0.Controls.Add(txt_comp_dunnandbrad);
			_tab_company_admin_TabPage0.Controls.Add(txt_comp_sic_code);
			_tab_company_admin_TabPage0.Controls.Add(_chk_comp_product_code_0);
			_tab_company_admin_TabPage0.Controls.Add(_chk_comp_product_code_1);
			_tab_company_admin_TabPage0.Controls.Add(_chk_comp_product_code_2);
			_tab_company_admin_TabPage0.Controls.Add(_chk_comp_product_code_3);
			_tab_company_admin_TabPage0.Controls.Add(_chk_comp_product_code_4);
			_tab_company_admin_TabPage0.Controls.Add(_chk_comp_product_code_5);
			_tab_company_admin_TabPage0.Controls.Add(tab_comp_description);
			_tab_company_admin_TabPage0.Controls.Add(_cmd_company_button_0);
			_tab_company_admin_TabPage0.Controls.Add(_cmd_company_button_1);
			_tab_company_admin_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_admin_TabPage0.Text = "Profile";
			// 
			// _shp_dealer_background_0
			// 
			_shp_dealer_background_0.AllowDrop = true;
			_shp_dealer_background_0.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_0.BackStyle = 1;
			_shp_dealer_background_0.BorderStyle = 0;
			_shp_dealer_background_0.Enabled = false;
			_shp_dealer_background_0.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_0.FillStyle = 1;
			_shp_dealer_background_0.Location = new System.Drawing.Point(3, 3);
			_shp_dealer_background_0.Name = "_shp_dealer_background_0";
			_shp_dealer_background_0.Size = new System.Drawing.Size(648, 145);
			_shp_dealer_background_0.Visible = false;
			// 
			// _lbl_comp_6
			// 
			_lbl_comp_6.AllowDrop = true;
			_lbl_comp_6.BackColor = System.Drawing.Color.Yellow;
			_lbl_comp_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_comp_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_6.ForeColor = System.Drawing.Color.Maroon;
			_lbl_comp_6.Location = new System.Drawing.Point(443, 93);
			_lbl_comp_6.MinimumSize = new System.Drawing.Size(202, 17);
			_lbl_comp_6.Name = "_lbl_comp_6";
			_lbl_comp_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_6.Size = new System.Drawing.Size(202, 17);
			_lbl_comp_6.TabIndex = 87;
			_lbl_comp_6.Tag = "N";
			_lbl_comp_6.Text = "Label6";
			_lbl_comp_6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_6.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_6.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_6.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_10
			// 
			_lbl_comp_10.AllowDrop = true;
			_lbl_comp_10.AutoSize = true;
			_lbl_comp_10.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_10.Location = new System.Drawing.Point(282, 42);
			_lbl_comp_10.MinimumSize = new System.Drawing.Size(55, 26);
			_lbl_comp_10.Name = "_lbl_comp_10";
			_lbl_comp_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_10.Size = new System.Drawing.Size(55, 26);
			_lbl_comp_10.TabIndex = 90;
			_lbl_comp_10.Text = "Last ABI Called:";
			_lbl_comp_10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_10.Visible = false;
			_lbl_comp_10.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_10.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_10.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_39
			// 
			_lbl_comp_39.AllowDrop = true;
			_lbl_comp_39.AutoSize = true;
			_lbl_comp_39.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_39.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			_lbl_comp_39.Location = new System.Drawing.Point(290, 71);
			_lbl_comp_39.MinimumSize = new System.Drawing.Size(39, 13);
			_lbl_comp_39.Name = "_lbl_comp_39";
			_lbl_comp_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_39.Size = new System.Drawing.Size(39, 13);
			_lbl_comp_39.TabIndex = 91;
			_lbl_comp_39.Tag = "N";
			_lbl_comp_39.Text = "Label39";
			_lbl_comp_39.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_39.Visible = false;
			_lbl_comp_39.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_39.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_39.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_11
			// 
			_lbl_comp_11.AllowDrop = true;
			_lbl_comp_11.AutoSize = true;
			_lbl_comp_11.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_11.ForeColor = System.Drawing.Color.Blue;
			_lbl_comp_11.Location = new System.Drawing.Point(290, 21);
			_lbl_comp_11.MinimumSize = new System.Drawing.Size(39, 13);
			_lbl_comp_11.Name = "_lbl_comp_11";
			_lbl_comp_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_11.Size = new System.Drawing.Size(39, 13);
			_lbl_comp_11.TabIndex = 92;
			_lbl_comp_11.Tag = "N";
			_lbl_comp_11.Text = "Label11";
			_lbl_comp_11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_11.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_11.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_11.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_13
			// 
			_lbl_comp_13.AllowDrop = true;
			_lbl_comp_13.AutoSize = true;
			_lbl_comp_13.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_13.Location = new System.Drawing.Point(282, 5);
			_lbl_comp_13.MinimumSize = new System.Drawing.Size(55, 13);
			_lbl_comp_13.Name = "_lbl_comp_13";
			_lbl_comp_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_13.Size = new System.Drawing.Size(55, 13);
			_lbl_comp_13.TabIndex = 93;
			_lbl_comp_13.Text = "Last Called:";
			_lbl_comp_13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_13.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_13.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_13.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_28
			// 
			_lbl_comp_28.AllowDrop = true;
			_lbl_comp_28.AutoSize = true;
			_lbl_comp_28.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_28.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_28.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_28.Location = new System.Drawing.Point(12, 36);
			_lbl_comp_28.MinimumSize = new System.Drawing.Size(38, 13);
			_lbl_comp_28.Name = "_lbl_comp_28";
			_lbl_comp_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_28.Size = new System.Drawing.Size(38, 13);
			_lbl_comp_28.TabIndex = 127;
			_lbl_comp_28.Text = "Label28";
			_lbl_comp_28.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_28.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_28.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_44
			// 
			_lbl_comp_44.AllowDrop = true;
			_lbl_comp_44.AutoSize = true;
			_lbl_comp_44.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_44.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_44.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_44.Location = new System.Drawing.Point(12, 59);
			_lbl_comp_44.MinimumSize = new System.Drawing.Size(72, 13);
			_lbl_comp_44.Name = "_lbl_comp_44";
			_lbl_comp_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_44.Size = new System.Drawing.Size(72, 13);
			_lbl_comp_44.TabIndex = 128;
			_lbl_comp_44.Text = "Business Type:";
			_lbl_comp_44.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_44.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_44.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_3
			// 
			_lbl_comp_3.AllowDrop = true;
			_lbl_comp_3.AutoSize = true;
			_lbl_comp_3.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_3.Location = new System.Drawing.Point(12, 82);
			_lbl_comp_3.MinimumSize = new System.Drawing.Size(51, 13);
			_lbl_comp_3.Name = "_lbl_comp_3";
			_lbl_comp_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_3.Size = new System.Drawing.Size(51, 13);
			_lbl_comp_3.TabIndex = 129;
			_lbl_comp_3.Text = "Language:";
			_lbl_comp_3.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_3.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_3.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_22
			// 
			_lbl_comp_22.AllowDrop = true;
			_lbl_comp_22.AutoSize = true;
			_lbl_comp_22.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_22.Location = new System.Drawing.Point(12, 105);
			_lbl_comp_22.MinimumSize = new System.Drawing.Size(48, 13);
			_lbl_comp_22.Name = "_lbl_comp_22";
			_lbl_comp_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_22.Size = new System.Drawing.Size(48, 13);
			_lbl_comp_22.TabIndex = 130;
			_lbl_comp_22.Text = "JIC Code:";
			_lbl_comp_22.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_22.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_22.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_5
			// 
			_lbl_comp_5.AllowDrop = true;
			_lbl_comp_5.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_5.Location = new System.Drawing.Point(12, 12);
			_lbl_comp_5.MinimumSize = new System.Drawing.Size(70, 13);
			_lbl_comp_5.Name = "_lbl_comp_5";
			_lbl_comp_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_5.Size = new System.Drawing.Size(70, 13);
			_lbl_comp_5.TabIndex = 131;
			_lbl_comp_5.Text = "Agency Type:";
			_lbl_comp_5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_5.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_5.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_5.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_7
			// 
			_lbl_comp_7.AllowDrop = true;
			_lbl_comp_7.AutoSize = true;
			_lbl_comp_7.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_7.Location = new System.Drawing.Point(12, 126);
			_lbl_comp_7.MinimumSize = new System.Drawing.Size(101, 13);
			_lbl_comp_7.Name = "_lbl_comp_7";
			_lbl_comp_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_7.Size = new System.Drawing.Size(101, 13);
			_lbl_comp_7.TabIndex = 132;
			_lbl_comp_7.Text = "Dunn and Bradstreet:";
			_lbl_comp_7.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_7.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_7.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _shp_Shape_0
			// 
			_shp_Shape_0.AllowDrop = true;
			_shp_Shape_0.BackColor = System.Drawing.SystemColors.Window;
			_shp_Shape_0.BackStyle = 0;
			_shp_Shape_0.BorderStyle = 1;
			_shp_Shape_0.Enabled = false;
			_shp_Shape_0.FillColor = System.Drawing.Color.Black;
			_shp_Shape_0.FillStyle = 1;
			_shp_Shape_0.Location = new System.Drawing.Point(4, 4);
			_shp_Shape_0.Name = "_shp_Shape_0";
			_shp_Shape_0.Size = new System.Drawing.Size(270, 141);
			_shp_Shape_0.Visible = true;
			// 
			// Shape2
			// 
			Shape2.AllowDrop = true;
			Shape2.BackColor = System.Drawing.SystemColors.Window;
			Shape2.BackStyle = 0;
			Shape2.BorderStyle = 1;
			Shape2.Enabled = false;
			Shape2.FillColor = System.Drawing.Color.Black;
			Shape2.FillStyle = 1;
			Shape2.Location = new System.Drawing.Point(492, 4);
			Shape2.Name = "Shape2";
			Shape2.Size = new System.Drawing.Size(158, 81);
			Shape2.Visible = true;
			// 
			// _lbl_comp_87
			// 
			_lbl_comp_87.AllowDrop = true;
			_lbl_comp_87.AutoSize = true;
			_lbl_comp_87.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_87.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_87.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_87.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_87.Location = new System.Drawing.Point(498, 6);
			_lbl_comp_87.MinimumSize = new System.Drawing.Size(146, 13);
			_lbl_comp_87.Name = "_lbl_comp_87";
			_lbl_comp_87.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_87.Size = new System.Drawing.Size(146, 13);
			_lbl_comp_87.TabIndex = 149;
			_lbl_comp_87.Text = "Company Product Codes:";
			_lbl_comp_87.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_87.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_87.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_87.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_61
			// 
			_lbl_comp_61.AllowDrop = true;
			_lbl_comp_61.AutoSize = true;
			_lbl_comp_61.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_61.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_61.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_61.ForeColor = System.Drawing.Color.Green;
			_lbl_comp_61.Location = new System.Drawing.Point(616, 108);
			_lbl_comp_61.MinimumSize = new System.Drawing.Size(29, 14);
			_lbl_comp_61.Name = "_lbl_comp_61";
			_lbl_comp_61.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_61.Size = new System.Drawing.Size(29, 14);
			_lbl_comp_61.TabIndex = 175;
			_lbl_comp_61.Text = "ABI";
			_lbl_comp_61.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_61.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_61.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_61.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// cbo_comp_services_used
			// 
			cbo_comp_services_used.AllowDrop = true;
			cbo_comp_services_used.BackColor = System.Drawing.SystemColors.Window;
			cbo_comp_services_used.CausesValidation = true;
			cbo_comp_services_used.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_comp_services_used.Enabled = true;
			cbo_comp_services_used.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_services_used.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_comp_services_used.IntegralHeight = true;
			cbo_comp_services_used.Location = new System.Drawing.Point(440, 124);
			cbo_comp_services_used.Name = "cbo_comp_services_used";
			cbo_comp_services_used.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_services_used.Size = new System.Drawing.Size(209, 21);
			cbo_comp_services_used.Sorted = false;
			cbo_comp_services_used.TabIndex = 62;
			cbo_comp_services_used.TabStop = true;
			cbo_comp_services_used.Visible = true;
			// 
			// lst_business_types
			// 
			lst_business_types.AllowDrop = true;
			lst_business_types.BackColor = System.Drawing.SystemColors.Window;
			lst_business_types.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_business_types.CausesValidation = true;
			lst_business_types.Enabled = true;
			lst_business_types.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_business_types.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_business_types.IntegralHeight = true;
			lst_business_types.Location = new System.Drawing.Point(346, 4);
			lst_business_types.MultiColumn = false;
			lst_business_types.Name = "lst_business_types";
			lst_business_types.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_business_types.Size = new System.Drawing.Size(146, 57);
			lst_business_types.Sorted = false;
			lst_business_types.TabIndex = 63;
			lst_business_types.TabStop = true;
			lst_business_types.Visible = true;
			lst_business_types.SelectedIndexChanged += new System.EventHandler(lst_business_types_SelectedIndexChanged);
			// 
			// cmd_edit_business_types
			// 
			cmd_edit_business_types.AllowDrop = true;
			cmd_edit_business_types.BackColor = System.Drawing.SystemColors.Control;
			cmd_edit_business_types.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_edit_business_types.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_edit_business_types.Location = new System.Drawing.Point(346, 62);
			cmd_edit_business_types.Name = "cmd_edit_business_types";
			cmd_edit_business_types.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_edit_business_types.Size = new System.Drawing.Size(146, 22);
			cmd_edit_business_types.TabIndex = 64;
			cmd_edit_business_types.Text = "Edit Business Types";
			cmd_edit_business_types.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_edit_business_types.UseVisualStyleBackColor = false;
			cmd_edit_business_types.Click += new System.EventHandler(cmd_edit_business_types_Click);
			cmd_edit_business_types.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_edit_business_types_MouseUp);
			// 
			// cbo_comp_govsub_code
			// 
			cbo_comp_govsub_code.AllowDrop = true;
			cbo_comp_govsub_code.BackColor = System.Drawing.SystemColors.Window;
			cbo_comp_govsub_code.CausesValidation = true;
			cbo_comp_govsub_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_comp_govsub_code.Enabled = true;
			cbo_comp_govsub_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_govsub_code.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_comp_govsub_code.IntegralHeight = true;
			cbo_comp_govsub_code.Location = new System.Drawing.Point(123, 32);
			cbo_comp_govsub_code.Name = "cbo_comp_govsub_code";
			cbo_comp_govsub_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_govsub_code.Size = new System.Drawing.Size(148, 21);
			cbo_comp_govsub_code.Sorted = false;
			cbo_comp_govsub_code.TabIndex = 121;
			cbo_comp_govsub_code.TabStop = true;
			cbo_comp_govsub_code.Visible = true;
			cbo_comp_govsub_code.SelectedIndexChanged += new System.EventHandler(cbo_comp_govsub_code_SelectedIndexChanged);
			// 
			// cbo_comp_business_type
			// 
			cbo_comp_business_type.AllowDrop = true;
			cbo_comp_business_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_comp_business_type.CausesValidation = true;
			cbo_comp_business_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			cbo_comp_business_type.Enabled = false;
			cbo_comp_business_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_business_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_comp_business_type.IntegralHeight = true;
			cbo_comp_business_type.Location = new System.Drawing.Point(88, 55);
			cbo_comp_business_type.Name = "cbo_comp_business_type";
			cbo_comp_business_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_business_type.Size = new System.Drawing.Size(183, 21);
			cbo_comp_business_type.Sorted = false;
			cbo_comp_business_type.TabIndex = 122;
			cbo_comp_business_type.TabStop = true;
			cbo_comp_business_type.Visible = true;
			cbo_comp_business_type.SelectedIndexChanged += new System.EventHandler(cbo_comp_business_type_SelectedIndexChanged);
			// 
			// cbo_comp_agency_type
			// 
			cbo_comp_agency_type.AllowDrop = true;
			cbo_comp_agency_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_comp_agency_type.CausesValidation = true;
			cbo_comp_agency_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_comp_agency_type.Enabled = true;
			cbo_comp_agency_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_agency_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_comp_agency_type.IntegralHeight = true;
			cbo_comp_agency_type.Location = new System.Drawing.Point(88, 8);
			cbo_comp_agency_type.Name = "cbo_comp_agency_type";
			cbo_comp_agency_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_agency_type.Size = new System.Drawing.Size(183, 21);
			cbo_comp_agency_type.Sorted = false;
			cbo_comp_agency_type.TabIndex = 123;
			cbo_comp_agency_type.TabStop = true;
			cbo_comp_agency_type.Visible = true;
			cbo_comp_agency_type.SelectedIndexChanged += new System.EventHandler(cbo_comp_agency_type_SelectedIndexChanged);
			// 
			// cbo_comp_language
			// 
			cbo_comp_language.AllowDrop = true;
			cbo_comp_language.BackColor = System.Drawing.SystemColors.Window;
			cbo_comp_language.CausesValidation = true;
			cbo_comp_language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_comp_language.Enabled = true;
			cbo_comp_language.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_language.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_comp_language.IntegralHeight = true;
			cbo_comp_language.Location = new System.Drawing.Point(88, 78);
			cbo_comp_language.Name = "cbo_comp_language";
			cbo_comp_language.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_language.Size = new System.Drawing.Size(183, 21);
			cbo_comp_language.Sorted = false;
			cbo_comp_language.TabIndex = 124;
			cbo_comp_language.TabStop = true;
			cbo_comp_language.Visible = true;
			cbo_comp_language.SelectedIndexChanged += new System.EventHandler(cbo_comp_language_SelectedIndexChanged);
			// 
			// txt_comp_dunnandbrad
			// 
			txt_comp_dunnandbrad.AcceptsReturn = true;
			txt_comp_dunnandbrad.AllowDrop = true;
			txt_comp_dunnandbrad.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_dunnandbrad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_dunnandbrad.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_dunnandbrad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_dunnandbrad.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_dunnandbrad.Location = new System.Drawing.Point(153, 123);
			txt_comp_dunnandbrad.MaxLength = 14;
			txt_comp_dunnandbrad.Name = "txt_comp_dunnandbrad";
			txt_comp_dunnandbrad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_dunnandbrad.Size = new System.Drawing.Size(117, 19);
			txt_comp_dunnandbrad.TabIndex = 125;
			// 
			// txt_comp_sic_code
			// 
			txt_comp_sic_code.AcceptsReturn = true;
			txt_comp_sic_code.AllowDrop = true;
			txt_comp_sic_code.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_sic_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_sic_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_sic_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_sic_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_sic_code.Location = new System.Drawing.Point(153, 102);
			txt_comp_sic_code.MaxLength = 14;
			txt_comp_sic_code.Name = "txt_comp_sic_code";
			txt_comp_sic_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_sic_code.Size = new System.Drawing.Size(117, 19);
			txt_comp_sic_code.TabIndex = 126;
			// 
			// _chk_comp_product_code_0
			// 
			_chk_comp_product_code_0.AllowDrop = true;
			_chk_comp_product_code_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_comp_product_code_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_comp_product_code_0.CausesValidation = true;
			_chk_comp_product_code_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_comp_product_code_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_comp_product_code_0.Enabled = true;
			_chk_comp_product_code_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_comp_product_code_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_comp_product_code_0.Location = new System.Drawing.Point(495, 21);
			_chk_comp_product_code_0.Name = "_chk_comp_product_code_0";
			_chk_comp_product_code_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_comp_product_code_0.Size = new System.Drawing.Size(74, 17);
			_chk_comp_product_code_0.TabIndex = 143;
			_chk_comp_product_code_0.TabStop = true;
			_chk_comp_product_code_0.Text = "Business";
			_chk_comp_product_code_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_comp_product_code_0.Visible = true;
			// 
			// _chk_comp_product_code_1
			// 
			_chk_comp_product_code_1.AllowDrop = true;
			_chk_comp_product_code_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_comp_product_code_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_comp_product_code_1.CausesValidation = true;
			_chk_comp_product_code_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_comp_product_code_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_comp_product_code_1.Enabled = true;
			_chk_comp_product_code_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_comp_product_code_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_comp_product_code_1.Location = new System.Drawing.Point(572, 21);
			_chk_comp_product_code_1.Name = "_chk_comp_product_code_1";
			_chk_comp_product_code_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_comp_product_code_1.Size = new System.Drawing.Size(74, 17);
			_chk_comp_product_code_1.TabIndex = 144;
			_chk_comp_product_code_1.TabStop = true;
			_chk_comp_product_code_1.Text = "Helicopters";
			_chk_comp_product_code_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_comp_product_code_1.Visible = true;
			// 
			// _chk_comp_product_code_2
			// 
			_chk_comp_product_code_2.AllowDrop = true;
			_chk_comp_product_code_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_comp_product_code_2.BackColor = System.Drawing.SystemColors.Control;
			_chk_comp_product_code_2.CausesValidation = true;
			_chk_comp_product_code_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_comp_product_code_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_comp_product_code_2.Enabled = true;
			_chk_comp_product_code_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_comp_product_code_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_comp_product_code_2.Location = new System.Drawing.Point(495, 41);
			_chk_comp_product_code_2.Name = "_chk_comp_product_code_2";
			_chk_comp_product_code_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_comp_product_code_2.Size = new System.Drawing.Size(74, 18);
			_chk_comp_product_code_2.TabIndex = 145;
			_chk_comp_product_code_2.TabStop = true;
			_chk_comp_product_code_2.Text = "Commercial";
			_chk_comp_product_code_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_comp_product_code_2.Visible = true;
			// 
			// _chk_comp_product_code_3
			// 
			_chk_comp_product_code_3.AllowDrop = true;
			_chk_comp_product_code_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_comp_product_code_3.BackColor = System.Drawing.SystemColors.Control;
			_chk_comp_product_code_3.CausesValidation = true;
			_chk_comp_product_code_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_comp_product_code_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_comp_product_code_3.Enabled = true;
			_chk_comp_product_code_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_comp_product_code_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_comp_product_code_3.Location = new System.Drawing.Point(572, 41);
			_chk_comp_product_code_3.Name = "_chk_comp_product_code_3";
			_chk_comp_product_code_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_comp_product_code_3.Size = new System.Drawing.Size(73, 18);
			_chk_comp_product_code_3.TabIndex = 146;
			_chk_comp_product_code_3.TabStop = true;
			_chk_comp_product_code_3.Text = "ABI";
			_chk_comp_product_code_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_comp_product_code_3.Visible = false;
			// 
			// _chk_comp_product_code_4
			// 
			_chk_comp_product_code_4.AllowDrop = true;
			_chk_comp_product_code_4.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_comp_product_code_4.BackColor = System.Drawing.SystemColors.Control;
			_chk_comp_product_code_4.CausesValidation = true;
			_chk_comp_product_code_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_comp_product_code_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_comp_product_code_4.Enabled = true;
			_chk_comp_product_code_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_comp_product_code_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_comp_product_code_4.Location = new System.Drawing.Point(496, 63);
			_chk_comp_product_code_4.Name = "_chk_comp_product_code_4";
			_chk_comp_product_code_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_comp_product_code_4.Size = new System.Drawing.Size(73, 18);
			_chk_comp_product_code_4.TabIndex = 147;
			_chk_comp_product_code_4.TabStop = true;
			_chk_comp_product_code_4.Text = "AirBP";
			_chk_comp_product_code_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_comp_product_code_4.Visible = true;
			// 
			// _chk_comp_product_code_5
			// 
			_chk_comp_product_code_5.AllowDrop = true;
			_chk_comp_product_code_5.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_comp_product_code_5.BackColor = System.Drawing.SystemColors.Control;
			_chk_comp_product_code_5.CausesValidation = true;
			_chk_comp_product_code_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_comp_product_code_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_comp_product_code_5.Enabled = true;
			_chk_comp_product_code_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_comp_product_code_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_comp_product_code_5.Location = new System.Drawing.Point(572, 63);
			_chk_comp_product_code_5.Name = "_chk_comp_product_code_5";
			_chk_comp_product_code_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_comp_product_code_5.Size = new System.Drawing.Size(73, 18);
			_chk_comp_product_code_5.TabIndex = 148;
			_chk_comp_product_code_5.TabStop = true;
			_chk_comp_product_code_5.Text = "Yacht";
			_chk_comp_product_code_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_comp_product_code_5.Visible = true;
			// 
			// tab_comp_description
			// 
			tab_comp_description.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_comp_description.AllowDrop = true;
			tab_comp_description.Controls.Add(_tab_comp_description_TabPage0);
			tab_comp_description.Controls.Add(_tab_comp_description_TabPage1);
			tab_comp_description.Controls.Add(_tab_comp_description_TabPage2);
			tab_comp_description.Controls.Add(_tab_comp_description_TabPage3);
			tab_comp_description.Controls.Add(_tab_comp_description_TabPage4);
			tab_comp_description.Controls.Add(_tab_comp_description_TabPage5);
			tab_comp_description.Controls.Add(_tab_comp_description_TabPage6);
			tab_comp_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_comp_description.ItemSize = new System.Drawing.Size(90, 18);
			tab_comp_description.Location = new System.Drawing.Point(8, 148);
			tab_comp_description.Multiline = true;
			tab_comp_description.Name = "tab_comp_description";
			tab_comp_description.Size = new System.Drawing.Size(645, 160);
			tab_comp_description.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_comp_description.TabIndex = 162;
			tab_comp_description.SelectedIndexChanged += new System.EventHandler(tab_comp_description_SelectedIndexChanged);
			// 
			// _tab_comp_description_TabPage0
			// 
			_tab_comp_description_TabPage0.Controls.Add(_lbl_comp_115);
			_tab_comp_description_TabPage0.Controls.Add(_lbl_comp_116);
			_tab_comp_description_TabPage0.Controls.Add(_lbl_test_omg3_0);
			_tab_comp_description_TabPage0.Controls.Add(chk_include_on_ac_pros);
			_tab_comp_description_TabPage0.Controls.Add(txt_comp_description);
			_tab_comp_description_TabPage0.Controls.Add(_txt_company_field_4);
			_tab_comp_description_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_comp_description_TabPage0.Text = "Descrip(Int)";
			// 
			// _lbl_comp_115
			// 
			_lbl_comp_115.AllowDrop = true;
			_lbl_comp_115.AutoSize = true;
			_lbl_comp_115.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_115.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_115.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_115.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_115.Location = new System.Drawing.Point(304, 8);
			_lbl_comp_115.MinimumSize = new System.Drawing.Size(86, 13);
			_lbl_comp_115.Name = "_lbl_comp_115";
			_lbl_comp_115.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_115.Size = new System.Drawing.Size(86, 13);
			_lbl_comp_115.TabIndex = 235;
			_lbl_comp_115.Text = "TICKER SYMBOL";
			_lbl_comp_115.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_115.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_115.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_116
			// 
			_lbl_comp_116.AllowDrop = true;
			_lbl_comp_116.AutoSize = true;
			_lbl_comp_116.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_116.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_116.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_116.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_116.Location = new System.Drawing.Point(512, 8);
			_lbl_comp_116.MinimumSize = new System.Drawing.Size(73, 13);
			_lbl_comp_116.Name = "_lbl_comp_116";
			_lbl_comp_116.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_116.Size = new System.Drawing.Size(73, 13);
			_lbl_comp_116.TabIndex = 236;
			_lbl_comp_116.Text = "TICKER COMP";
			_lbl_comp_116.Visible = false;
			_lbl_comp_116.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_116.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_116.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_test_omg3_0
			// 
			_lbl_test_omg3_0.AllowDrop = true;
			_lbl_test_omg3_0.BackColor = System.Drawing.Color.Aqua;
			_lbl_test_omg3_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_test_omg3_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_test_omg3_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_test_omg3_0.Location = new System.Drawing.Point(136, 4);
			_lbl_test_omg3_0.MinimumSize = new System.Drawing.Size(145, 17);
			_lbl_test_omg3_0.Name = "_lbl_test_omg3_0";
			_lbl_test_omg3_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_test_omg3_0.Size = new System.Drawing.Size(145, 17);
			_lbl_test_omg3_0.TabIndex = 238;
			_lbl_test_omg3_0.Text = "--------- You Are On Test ----------";
			_lbl_test_omg3_0.Visible = false;
			// 
			// chk_include_on_ac_pros
			// 
			chk_include_on_ac_pros.AllowDrop = true;
			chk_include_on_ac_pros.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_include_on_ac_pros.BackColor = System.Drawing.SystemColors.Control;
			chk_include_on_ac_pros.CausesValidation = true;
			chk_include_on_ac_pros.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_include_on_ac_pros.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_include_on_ac_pros.Enabled = true;
			chk_include_on_ac_pros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_include_on_ac_pros.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_include_on_ac_pros.Location = new System.Drawing.Point(8, 12);
			chk_include_on_ac_pros.Name = "chk_include_on_ac_pros";
			chk_include_on_ac_pros.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_include_on_ac_pros.Size = new System.Drawing.Size(114, 13);
			chk_include_on_ac_pros.TabIndex = 163;
			chk_include_on_ac_pros.TabStop = true;
			chk_include_on_ac_pros.Text = "Include on ACPros?";
			chk_include_on_ac_pros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_include_on_ac_pros.Visible = false;
			chk_include_on_ac_pros.CheckStateChanged += new System.EventHandler(chk_include_on_ac_pros_CheckStateChanged);
			// 
			// txt_comp_description
			// 
			txt_comp_description.AcceptsReturn = true;
			txt_comp_description.AllowDrop = true;
			txt_comp_description.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_description.Location = new System.Drawing.Point(8, 28);
			txt_comp_description.MaxLength = 0;
			txt_comp_description.Multiline = true;
			txt_comp_description.Name = "txt_comp_description";
			txt_comp_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txt_comp_description.Size = new System.Drawing.Size(616, 95);
			txt_comp_description.TabIndex = 164;
			// 
			// _txt_company_field_4
			// 
			_txt_company_field_4.AcceptsReturn = true;
			_txt_company_field_4.AllowDrop = true;
			_txt_company_field_4.BackColor = System.Drawing.SystemColors.Window;
			_txt_company_field_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_company_field_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_company_field_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_company_field_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_company_field_4.Location = new System.Drawing.Point(392, 4);
			_txt_company_field_4.MaxLength = 0;
			_txt_company_field_4.Name = "_txt_company_field_4";
			_txt_company_field_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_company_field_4.Size = new System.Drawing.Size(111, 21);
			_txt_company_field_4.TabIndex = 234;
			_txt_company_field_4.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_company_field_KeyDown);
			_txt_company_field_4.Leave += new System.EventHandler(txt_company_field_Leave);
			// 
			// _tab_comp_description_TabPage1
			// 
			_tab_comp_description_TabPage1.Controls.Add(pnl_fractional_owner);
			_tab_comp_description_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_comp_description_TabPage1.Text = "Frac Owner";
			// 
			// pnl_fractional_owner
			// 
			pnl_fractional_owner.AllowDrop = true;
			pnl_fractional_owner.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			pnl_fractional_owner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_fractional_owner.Controls.Add(cbo_comp_fractowr_contact_id);
			pnl_fractional_owner.Controls.Add(txt_comp_fractowr_notes);
			pnl_fractional_owner.Controls.Add(txt_comp_fractowr_id);
			pnl_fractional_owner.Controls.Add(_lbl_comp_54);
			pnl_fractional_owner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_fractional_owner.Location = new System.Drawing.Point(8, 4);
			pnl_fractional_owner.Name = "pnl_fractional_owner";
			pnl_fractional_owner.Size = new System.Drawing.Size(617, 121);
			pnl_fractional_owner.TabIndex = 165;
			// 
			// cbo_comp_fractowr_contact_id
			// 
			cbo_comp_fractowr_contact_id.AllowDrop = true;
			cbo_comp_fractowr_contact_id.BackColor = System.Drawing.SystemColors.Window;
			cbo_comp_fractowr_contact_id.CausesValidation = true;
			cbo_comp_fractowr_contact_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_comp_fractowr_contact_id.Enabled = true;
			cbo_comp_fractowr_contact_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_fractowr_contact_id.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_comp_fractowr_contact_id.IntegralHeight = true;
			cbo_comp_fractowr_contact_id.Location = new System.Drawing.Point(133, 88);
			cbo_comp_fractowr_contact_id.Name = "cbo_comp_fractowr_contact_id";
			cbo_comp_fractowr_contact_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_fractowr_contact_id.Size = new System.Drawing.Size(263, 21);
			cbo_comp_fractowr_contact_id.Sorted = false;
			cbo_comp_fractowr_contact_id.TabIndex = 168;
			cbo_comp_fractowr_contact_id.TabStop = true;
			cbo_comp_fractowr_contact_id.Visible = true;
			cbo_comp_fractowr_contact_id.SelectedIndexChanged += new System.EventHandler(cbo_comp_fractowr_contact_id_SelectedIndexChanged);
			// 
			// txt_comp_fractowr_notes
			// 
			txt_comp_fractowr_notes.AcceptsReturn = true;
			txt_comp_fractowr_notes.AllowDrop = true;
			txt_comp_fractowr_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_fractowr_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_fractowr_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_fractowr_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_fractowr_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_fractowr_notes.Location = new System.Drawing.Point(8, 0);
			txt_comp_fractowr_notes.MaxLength = 0;
			txt_comp_fractowr_notes.Multiline = true;
			txt_comp_fractowr_notes.Name = "txt_comp_fractowr_notes";
			txt_comp_fractowr_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_fractowr_notes.Size = new System.Drawing.Size(518, 78);
			txt_comp_fractowr_notes.TabIndex = 167;
			// 
			// txt_comp_fractowr_id
			// 
			txt_comp_fractowr_id.AcceptsReturn = true;
			txt_comp_fractowr_id.AllowDrop = true;
			txt_comp_fractowr_id.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_comp_fractowr_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_comp_fractowr_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_fractowr_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_fractowr_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_fractowr_id.Location = new System.Drawing.Point(530, 0);
			txt_comp_fractowr_id.MaxLength = 0;
			txt_comp_fractowr_id.Name = "txt_comp_fractowr_id";
			txt_comp_fractowr_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_fractowr_id.Size = new System.Drawing.Size(81, 19);
			txt_comp_fractowr_id.TabIndex = 166;
			// 
			// _lbl_comp_54
			// 
			_lbl_comp_54.AllowDrop = true;
			_lbl_comp_54.AutoSize = true;
			_lbl_comp_54.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_54.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_54.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_54.Location = new System.Drawing.Point(0, 93);
			_lbl_comp_54.MinimumSize = new System.Drawing.Size(123, 13);
			_lbl_comp_54.Name = "_lbl_comp_54";
			_lbl_comp_54.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_54.Size = new System.Drawing.Size(123, 13);
			_lbl_comp_54.TabIndex = 169;
			_lbl_comp_54.Text = "Fractional Owner Contact:";
			_lbl_comp_54.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_54.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_54.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _tab_comp_description_TabPage2
			// 
			_tab_comp_description_TabPage2.Controls.Add(cmd_Edit_Comp_Description);
			_tab_comp_description_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_comp_description_TabPage2.Text = "Desc (Public)";
			// 
			// cmd_Edit_Comp_Description
			// 
			cmd_Edit_Comp_Description.AllowDrop = true;
			cmd_Edit_Comp_Description.BackColor = System.Drawing.SystemColors.Control;
			cmd_Edit_Comp_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Edit_Comp_Description.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Edit_Comp_Description.Location = new System.Drawing.Point(216, 38);
			cmd_Edit_Comp_Description.Name = "cmd_Edit_Comp_Description";
			cmd_Edit_Comp_Description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Edit_Comp_Description.Size = new System.Drawing.Size(201, 33);
			cmd_Edit_Comp_Description.TabIndex = 171;
			cmd_Edit_Comp_Description.Text = "View/Edit Public Description";
			cmd_Edit_Comp_Description.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Edit_Comp_Description.UseVisualStyleBackColor = false;
			cmd_Edit_Comp_Description.Click += new System.EventHandler(cmd_Edit_Comp_Description_Click);
			// 
			// _tab_comp_description_TabPage3
			// 
			_tab_comp_description_TabPage3.Controls.Add(company_logo);
			_tab_comp_description_TabPage3.Controls.Add(cmd_delete_logo);
			_tab_comp_description_TabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_comp_description_TabPage3.Text = "Logo";
			// 
			// company_logo
			// 
			company_logo.AllowDrop = true;
			company_logo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			company_logo.Enabled = true;
			company_logo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			company_logo.Location = new System.Drawing.Point(448, 14);
			company_logo.Name = "company_logo";
			company_logo.Size = new System.Drawing.Size(173, 107);
			company_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			company_logo.Visible = true;
			company_logo.Click += new System.EventHandler(company_logo_Click);
			// 
			// cmd_delete_logo
			// 
			cmd_delete_logo.AllowDrop = true;
			cmd_delete_logo.BackColor = System.Drawing.SystemColors.Control;
			cmd_delete_logo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_delete_logo.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_delete_logo.Location = new System.Drawing.Point(16, 92);
			cmd_delete_logo.Name = "cmd_delete_logo";
			cmd_delete_logo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_delete_logo.Size = new System.Drawing.Size(81, 25);
			cmd_delete_logo.TabIndex = 170;
			cmd_delete_logo.Text = "Delete Logo";
			cmd_delete_logo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_delete_logo.UseVisualStyleBackColor = false;
			cmd_delete_logo.Visible = false;
			cmd_delete_logo.Click += new System.EventHandler(cmd_delete_logo_Click);
			// 
			// _tab_comp_description_TabPage4
			// 
			_tab_comp_description_TabPage4.Controls.Add(_lbl_comp_114);
			_tab_comp_description_TabPage4.Controls.Add(_lbl_comp_18);
			_tab_comp_description_TabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_comp_description_TabPage4.Text = "Services";
			// 
			// _lbl_comp_114
			// 
			_lbl_comp_114.AllowDrop = true;
			_lbl_comp_114.AutoSize = true;
			_lbl_comp_114.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_114.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_114.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_114.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_114.Location = new System.Drawing.Point(8, 4);
			_lbl_comp_114.MinimumSize = new System.Drawing.Size(91, 14);
			_lbl_comp_114.Name = "_lbl_comp_114";
			_lbl_comp_114.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_114.Size = new System.Drawing.Size(91, 14);
			_lbl_comp_114.TabIndex = 210;
			_lbl_comp_114.Text = "Services Used";
			_lbl_comp_114.Visible = false;
			_lbl_comp_114.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_114.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_114.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_18
			// 
			_lbl_comp_18.AllowDrop = true;
			_lbl_comp_18.AutoSize = true;
			_lbl_comp_18.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_18.Location = new System.Drawing.Point(8, 116);
			_lbl_comp_18.MinimumSize = new System.Drawing.Size(185, 13);
			_lbl_comp_18.Name = "_lbl_comp_18";
			_lbl_comp_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_18.Size = new System.Drawing.Size(185, 13);
			_lbl_comp_18.TabIndex = 209;
			_lbl_comp_18.Text = "(Double Click on the List Above to Edit)";
			_lbl_comp_18.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_18.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_18.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _tab_comp_description_TabPage5
			// 
			_tab_comp_description_TabPage5.Controls.Add(_txt_market_note_4);
			_tab_comp_description_TabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_comp_description_TabPage5.Text = "Marketing";
			// 
			// _txt_market_note_4
			// 
			_txt_market_note_4.AcceptsReturn = true;
			_txt_market_note_4.AllowDrop = true;
			_txt_market_note_4.BackColor = System.Drawing.SystemColors.Window;
			_txt_market_note_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_market_note_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_market_note_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_market_note_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_market_note_4.Location = new System.Drawing.Point(8, 12);
			_txt_market_note_4.MaxLength = 0;
			_txt_market_note_4.Multiline = true;
			_txt_market_note_4.Name = "_txt_market_note_4";
			_txt_market_note_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_market_note_4.Size = new System.Drawing.Size(609, 109);
			_txt_market_note_4.TabIndex = 211;
			_txt_market_note_4.DoubleClick += new System.EventHandler(txt_market_note_DoubleClick);
			_txt_market_note_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_market_note_KeyPress);
			_txt_market_note_4.TextChanged += new System.EventHandler(txt_market_note_TextChanged);
			// 
			// _tab_comp_description_TabPage6
			// 
			_tab_comp_description_TabPage6.Controls.Add(_lbl_comp_12);
			_tab_comp_description_TabPage6.Controls.Add(_txt_market_note_6);
			_tab_comp_description_TabPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_comp_description_TabPage6.Text = "Accounting";
			// 
			// _lbl_comp_12
			// 
			_lbl_comp_12.AllowDrop = true;
			_lbl_comp_12.AutoSize = true;
			_lbl_comp_12.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_12.Location = new System.Drawing.Point(16, 116);
			_lbl_comp_12.MinimumSize = new System.Drawing.Size(243, 13);
			_lbl_comp_12.Name = "_lbl_comp_12";
			_lbl_comp_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_12.Size = new System.Drawing.Size(243, 13);
			_lbl_comp_12.TabIndex = 217;
			_lbl_comp_12.Text = "Double Click on the Accounting Note Above to Edit";
			_lbl_comp_12.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_12.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_12.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _txt_market_note_6
			// 
			_txt_market_note_6.AcceptsReturn = true;
			_txt_market_note_6.AllowDrop = true;
			_txt_market_note_6.BackColor = System.Drawing.SystemColors.Window;
			_txt_market_note_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_market_note_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_market_note_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_market_note_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_market_note_6.Location = new System.Drawing.Point(8, 12);
			_txt_market_note_6.MaxLength = 0;
			_txt_market_note_6.Multiline = true;
			_txt_market_note_6.Name = "_txt_market_note_6";
			_txt_market_note_6.ReadOnly = true;
			_txt_market_note_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_market_note_6.Size = new System.Drawing.Size(609, 101);
			_txt_market_note_6.TabIndex = 216;
			_txt_market_note_6.DoubleClick += new System.EventHandler(txt_market_note_DoubleClick);
			_txt_market_note_6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_market_note_KeyPress);
			_txt_market_note_6.TextChanged += new System.EventHandler(txt_market_note_TextChanged);
			// 
			// _cmd_company_button_0
			// 
			_cmd_company_button_0.AllowDrop = true;
			_cmd_company_button_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_company_button_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_company_button_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_company_button_0.Location = new System.Drawing.Point(280, 119);
			_cmd_company_button_0.Name = "_cmd_company_button_0";
			_cmd_company_button_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_company_button_0.Size = new System.Drawing.Size(149, 23);
			_cmd_company_button_0.TabIndex = 205;
			_cmd_company_button_0.Tag = "95";
			_cmd_company_button_0.Text = "No Inventory To Show";
			_cmd_company_button_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_company_button_0.UseVisualStyleBackColor = false;
			_cmd_company_button_0.Click += new System.EventHandler(cmd_company_button_Click);
			_cmd_company_button_0.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_company_button_MouseUp);
			// 
			// _cmd_company_button_1
			// 
			_cmd_company_button_1.AllowDrop = true;
			_cmd_company_button_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_company_button_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_company_button_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_company_button_1.Location = new System.Drawing.Point(280, 94);
			_cmd_company_button_1.Name = "_cmd_company_button_1";
			_cmd_company_button_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_company_button_1.Size = new System.Drawing.Size(149, 23);
			_cmd_company_button_1.TabIndex = 206;
			_cmd_company_button_1.Tag = "95";
			_cmd_company_button_1.Text = "Attempted to Contact";
			_cmd_company_button_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_company_button_1.UseVisualStyleBackColor = false;
			_cmd_company_button_1.Click += new System.EventHandler(cmd_company_button_Click);
			_cmd_company_button_1.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_company_button_MouseUp);
			// 
			// _tab_company_admin_TabPage1
			// 
			_tab_company_admin_TabPage1.Controls.Add(_shp_dealer_background_1);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_38);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_27);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_57);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_72);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_71);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_58);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_60);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_59);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_8);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_98);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_103);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_105);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_112);
			_tab_company_admin_TabPage1.Controls.Add(_lbl_comp_113);
			_tab_company_admin_TabPage1.Controls.Add(cal_comp_callback_date);
			_tab_company_admin_TabPage1.Controls.Add(_cmd_company_update_callback_date_0);
			_tab_company_admin_TabPage1.Controls.Add(chk_company_assign_flag);
			_tab_company_admin_TabPage1.Controls.Add(_cbo_comp_account_0);
			_tab_company_admin_TabPage1.Controls.Add(cal_comp_yacht_callback_date);
			_tab_company_admin_TabPage1.Controls.Add(_cbo_comp_account_1);
			_tab_company_admin_TabPage1.Controls.Add(_cbo_comp_account_2);
			_tab_company_admin_TabPage1.Controls.Add(chkCompContactAddressFlag);
			_tab_company_admin_TabPage1.Controls.Add(_cmd_company_update_callback_date_1);
			_tab_company_admin_TabPage1.Controls.Add(_cbo_comp_account_6);
			_tab_company_admin_TabPage1.Controls.Add(_txt_company_field_0);
			_tab_company_admin_TabPage1.Controls.Add(_txt_company_field_1);
			_tab_company_admin_TabPage1.Controls.Add(_txt_company_field_3);
			_tab_company_admin_TabPage1.Controls.Add(_chk_array_6);
			_tab_company_admin_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_admin_TabPage1.Text = "Account";
			// 
			// _shp_dealer_background_1
			// 
			_shp_dealer_background_1.AllowDrop = true;
			_shp_dealer_background_1.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_1.BackStyle = 1;
			_shp_dealer_background_1.BorderStyle = 0;
			_shp_dealer_background_1.Enabled = false;
			_shp_dealer_background_1.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_1.FillStyle = 1;
			_shp_dealer_background_1.Location = new System.Drawing.Point(0, 4);
			_shp_dealer_background_1.Name = "_shp_dealer_background_1";
			_shp_dealer_background_1.Size = new System.Drawing.Size(649, 309);
			_shp_dealer_background_1.Visible = false;
			// 
			// _lbl_comp_38
			// 
			_lbl_comp_38.AllowDrop = true;
			_lbl_comp_38.AutoSize = true;
			_lbl_comp_38.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_38.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_38.Location = new System.Drawing.Point(12, 126);
			_lbl_comp_38.MinimumSize = new System.Drawing.Size(130, 13);
			_lbl_comp_38.Name = "_lbl_comp_38";
			_lbl_comp_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_38.Size = new System.Drawing.Size(130, 13);
			_lbl_comp_38.TabIndex = 100;
			_lbl_comp_38.Text = "Reassign Procedures Date:";
			_lbl_comp_38.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_38.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_38.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_27
			// 
			_lbl_comp_27.AllowDrop = true;
			_lbl_comp_27.AutoSize = true;
			_lbl_comp_27.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_27.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_27.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_27.Location = new System.Drawing.Point(8, 48);
			_lbl_comp_27.MinimumSize = new System.Drawing.Size(70, 13);
			_lbl_comp_27.Name = "_lbl_comp_27";
			_lbl_comp_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_27.Size = new System.Drawing.Size(70, 13);
			_lbl_comp_27.TabIndex = 101;
			_lbl_comp_27.Text = "Account Type:";
			_lbl_comp_27.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_27.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_27.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_57
			// 
			_lbl_comp_57.AllowDrop = true;
			_lbl_comp_57.AutoSize = true;
			_lbl_comp_57.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_57.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_57.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_57.Location = new System.Drawing.Point(256, 20);
			_lbl_comp_57.MinimumSize = new System.Drawing.Size(105, 13);
			_lbl_comp_57.Name = "_lbl_comp_57";
			_lbl_comp_57.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_57.Size = new System.Drawing.Size(105, 13);
			_lbl_comp_57.TabIndex = 102;
			_lbl_comp_57.Text = "Aircraft Callback Date:";
			_lbl_comp_57.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_57.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_57.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_72
			// 
			_lbl_comp_72.AllowDrop = true;
			_lbl_comp_72.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_72.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_72.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_72.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_72.Location = new System.Drawing.Point(370, 20);
			_lbl_comp_72.MinimumSize = new System.Drawing.Size(61, 13);
			_lbl_comp_72.Name = "_lbl_comp_72";
			_lbl_comp_72.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_72.Size = new System.Drawing.Size(61, 13);
			_lbl_comp_72.TabIndex = 103;
			_lbl_comp_72.Text = "N/A";
			_lbl_comp_72.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_72.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_72.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_71
			// 
			_lbl_comp_71.AllowDrop = true;
			_lbl_comp_71.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_71.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_71.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_71.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_71.Location = new System.Drawing.Point(456, 20);
			_lbl_comp_71.MinimumSize = new System.Drawing.Size(103, 13);
			_lbl_comp_71.Name = "_lbl_comp_71";
			_lbl_comp_71.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_71.Size = new System.Drawing.Size(103, 13);
			_lbl_comp_71.TabIndex = 104;
			_lbl_comp_71.Text = "Yacht Callback Date:";
			_lbl_comp_71.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_71.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_71.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_58
			// 
			_lbl_comp_58.AllowDrop = true;
			_lbl_comp_58.AutoSize = true;
			_lbl_comp_58.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_58.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_58.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_58.Location = new System.Drawing.Point(240, 236);
			_lbl_comp_58.MinimumSize = new System.Drawing.Size(80, 13);
			_lbl_comp_58.Name = "_lbl_comp_58";
			_lbl_comp_58.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_58.Size = new System.Drawing.Size(80, 13);
			_lbl_comp_58.TabIndex = 105;
			_lbl_comp_58.Text = "Entry User/Date:";
			_lbl_comp_58.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_58.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_58.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_60
			// 
			_lbl_comp_60.AllowDrop = true;
			_lbl_comp_60.AutoSize = true;
			_lbl_comp_60.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_60.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_60.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_60.Location = new System.Drawing.Point(564, 20);
			_lbl_comp_60.MinimumSize = new System.Drawing.Size(61, 13);
			_lbl_comp_60.Name = "_lbl_comp_60";
			_lbl_comp_60.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_60.Size = new System.Drawing.Size(61, 13);
			_lbl_comp_60.TabIndex = 106;
			_lbl_comp_60.Text = "N/A";
			_lbl_comp_60.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_60.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_60.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_59
			// 
			_lbl_comp_59.AllowDrop = true;
			_lbl_comp_59.AutoSize = true;
			_lbl_comp_59.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_59.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_59.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_59.Location = new System.Drawing.Point(229, 256);
			_lbl_comp_59.MinimumSize = new System.Drawing.Size(91, 13);
			_lbl_comp_59.Name = "_lbl_comp_59";
			_lbl_comp_59.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_59.Size = new System.Drawing.Size(91, 13);
			_lbl_comp_59.TabIndex = 107;
			_lbl_comp_59.Text = "Update User/Date:";
			_lbl_comp_59.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_59.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_59.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_8
			// 
			_lbl_comp_8.AllowDrop = true;
			_lbl_comp_8.AutoSize = true;
			_lbl_comp_8.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_8.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_8.Location = new System.Drawing.Point(8, 97);
			_lbl_comp_8.MinimumSize = new System.Drawing.Size(66, 13);
			_lbl_comp_8.Name = "_lbl_comp_8";
			_lbl_comp_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_8.Size = new System.Drawing.Size(66, 13);
			_lbl_comp_8.TabIndex = 120;
			_lbl_comp_8.Text = "Account Rep:";
			_lbl_comp_8.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_8.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_8.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_98
			// 
			_lbl_comp_98.AllowDrop = true;
			_lbl_comp_98.AutoSize = true;
			_lbl_comp_98.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_98.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_98.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_98.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_98.Location = new System.Drawing.Point(8, 158);
			_lbl_comp_98.MinimumSize = new System.Drawing.Size(85, 13);
			_lbl_comp_98.Name = "_lbl_comp_98";
			_lbl_comp_98.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_98.Size = new System.Drawing.Size(85, 13);
			_lbl_comp_98.TabIndex = 182;
			_lbl_comp_98.Text = "Account Manager";
			_lbl_comp_98.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_98.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_98.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_103
			// 
			_lbl_comp_103.AllowDrop = true;
			_lbl_comp_103.AutoSize = true;
			_lbl_comp_103.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_103.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_103.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_103.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_103.Location = new System.Drawing.Point(8, 186);
			_lbl_comp_103.MinimumSize = new System.Drawing.Size(58, 13);
			_lbl_comp_103.Name = "_lbl_comp_103";
			_lbl_comp_103.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_103.Size = new System.Drawing.Size(58, 13);
			_lbl_comp_103.TabIndex = 197;
			_lbl_comp_103.Text = "Line Access";
			_lbl_comp_103.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_103.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_103.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_105
			// 
			_lbl_comp_105.AllowDrop = true;
			_lbl_comp_105.AutoSize = true;
			_lbl_comp_105.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_105.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_105.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_105.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_105.Location = new System.Drawing.Point(8, 236);
			_lbl_comp_105.MinimumSize = new System.Drawing.Size(124, 13);
			_lbl_comp_105.Name = "_lbl_comp_105";
			_lbl_comp_105.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_105.Size = new System.Drawing.Size(124, 13);
			_lbl_comp_105.TabIndex = 201;
			_lbl_comp_105.Text = "Secondary Callback Date:";
			_lbl_comp_105.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_105.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_105.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_112
			// 
			_lbl_comp_112.AllowDrop = true;
			_lbl_comp_112.AutoSize = true;
			_lbl_comp_112.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_112.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_112.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_112.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_112.Location = new System.Drawing.Point(8, 280);
			_lbl_comp_112.MinimumSize = new System.Drawing.Size(42, 13);
			_lbl_comp_112.Name = "_lbl_comp_112";
			_lbl_comp_112.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_112.Size = new System.Drawing.Size(42, 13);
			_lbl_comp_112.TabIndex = 207;
			_lbl_comp_112.Text = "Airport Id";
			_lbl_comp_112.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_112.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_112.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_113
			// 
			_lbl_comp_113.AllowDrop = true;
			_lbl_comp_113.AutoSize = true;
			_lbl_comp_113.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_113.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_113.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_113.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_113.Location = new System.Drawing.Point(136, 280);
			_lbl_comp_113.MinimumSize = new System.Drawing.Size(265, 13);
			_lbl_comp_113.Name = "_lbl_comp_113";
			_lbl_comp_113.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_113.Size = new System.Drawing.Size(265, 13);
			_lbl_comp_113.TabIndex = 208;
			_lbl_comp_113.Text = "{Airport Name}";
			_lbl_comp_113.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_113.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_113.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// cal_comp_callback_date
			// 
			cal_comp_callback_date.AllowDrop = true;
			cal_comp_callback_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cal_comp_callback_date.ForeColor = System.Drawing.SystemColors.ControlText;
			cal_comp_callback_date.Location = new System.Drawing.Point(256, 44);
			cal_comp_callback_date.MinDate = System.DateTime.FromOADate(2);
			cal_comp_callback_date.Name = "cal_comp_callback_date";
			cal_comp_callback_date.Size = new System.Drawing.Size(178, 154);
			cal_comp_callback_date.TabIndex = 99;
			cal_comp_callback_date.Enter += new System.EventHandler(cal_comp_callback_date_Enter);
			// 
			// _cmd_company_update_callback_date_0
			// 
			_cmd_company_update_callback_date_0.AllowDrop = true;
			_cmd_company_update_callback_date_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_company_update_callback_date_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_company_update_callback_date_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_company_update_callback_date_0.Location = new System.Drawing.Point(280, 206);
			_cmd_company_update_callback_date_0.Name = "_cmd_company_update_callback_date_0";
			_cmd_company_update_callback_date_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_company_update_callback_date_0.Size = new System.Drawing.Size(123, 23);
			_cmd_company_update_callback_date_0.TabIndex = 96;
			_cmd_company_update_callback_date_0.Text = "Update Callback Date";
			_cmd_company_update_callback_date_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_company_update_callback_date_0.UseVisualStyleBackColor = false;
			_cmd_company_update_callback_date_0.Click += new System.EventHandler(cmd_company_update_callback_date_Click);
			_cmd_company_update_callback_date_0.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_company_update_callback_date_MouseUp);
			// 
			// chk_company_assign_flag
			// 
			chk_company_assign_flag.AllowDrop = true;
			chk_company_assign_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_company_assign_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_company_assign_flag.CausesValidation = true;
			chk_company_assign_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_company_assign_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_company_assign_flag.Enabled = true;
			chk_company_assign_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_company_assign_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_company_assign_flag.Location = new System.Drawing.Point(8, 28);
			chk_company_assign_flag.Name = "chk_company_assign_flag";
			chk_company_assign_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_company_assign_flag.Size = new System.Drawing.Size(77, 17);
			chk_company_assign_flag.TabIndex = 97;
			chk_company_assign_flag.TabStop = true;
			chk_company_assign_flag.Text = "Automated?";
			chk_company_assign_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_company_assign_flag.Visible = true;
			chk_company_assign_flag.CheckStateChanged += new System.EventHandler(chk_company_assign_flag_CheckStateChanged);
			// 
			// _cbo_comp_account_0
			// 
			_cbo_comp_account_0.AllowDrop = true;
			_cbo_comp_account_0.BackColor = System.Drawing.SystemColors.Window;
			_cbo_comp_account_0.CausesValidation = true;
			_cbo_comp_account_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cbo_comp_account_0.Enabled = true;
			_cbo_comp_account_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_comp_account_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_comp_account_0.IntegralHeight = true;
			_cbo_comp_account_0.Location = new System.Drawing.Point(8, 66);
			_cbo_comp_account_0.Name = "_cbo_comp_account_0";
			_cbo_comp_account_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_comp_account_0.Size = new System.Drawing.Size(244, 21);
			_cbo_comp_account_0.Sorted = false;
			_cbo_comp_account_0.TabIndex = 98;
			_cbo_comp_account_0.TabStop = true;
			_cbo_comp_account_0.Visible = true;
			_cbo_comp_account_0.SelectedIndexChanged += new System.EventHandler(cbo_comp_account_SelectedIndexChanged);
			// 
			// cal_comp_yacht_callback_date
			// 
			cal_comp_yacht_callback_date.AllowDrop = true;
			cal_comp_yacht_callback_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cal_comp_yacht_callback_date.ForeColor = System.Drawing.Color.Black;
			cal_comp_yacht_callback_date.Location = new System.Drawing.Point(456, 44);
			cal_comp_yacht_callback_date.Name = "cal_comp_yacht_callback_date";
			cal_comp_yacht_callback_date.Size = new System.Drawing.Size(180, 158);
			cal_comp_yacht_callback_date.TabIndex = 172;
			// 
			// _cbo_comp_account_1
			// 
			_cbo_comp_account_1.AllowDrop = true;
			_cbo_comp_account_1.BackColor = System.Drawing.SystemColors.Window;
			_cbo_comp_account_1.CausesValidation = true;
			_cbo_comp_account_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cbo_comp_account_1.Enabled = true;
			_cbo_comp_account_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_comp_account_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_comp_account_1.IntegralHeight = true;
			_cbo_comp_account_1.Location = new System.Drawing.Point(90, 92);
			_cbo_comp_account_1.Name = "_cbo_comp_account_1";
			_cbo_comp_account_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_comp_account_1.Size = new System.Drawing.Size(162, 21);
			_cbo_comp_account_1.Sorted = false;
			_cbo_comp_account_1.TabIndex = 181;
			_cbo_comp_account_1.TabStop = true;
			_cbo_comp_account_1.Visible = true;
			_cbo_comp_account_1.SelectedIndexChanged += new System.EventHandler(cbo_comp_account_SelectedIndexChanged);
			// 
			// _cbo_comp_account_2
			// 
			_cbo_comp_account_2.AllowDrop = true;
			_cbo_comp_account_2.BackColor = System.Drawing.SystemColors.Window;
			_cbo_comp_account_2.CausesValidation = true;
			_cbo_comp_account_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cbo_comp_account_2.Enabled = true;
			_cbo_comp_account_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_comp_account_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_comp_account_2.IntegralHeight = true;
			_cbo_comp_account_2.Location = new System.Drawing.Point(98, 154);
			_cbo_comp_account_2.Name = "_cbo_comp_account_2";
			_cbo_comp_account_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_comp_account_2.Size = new System.Drawing.Size(154, 21);
			_cbo_comp_account_2.Sorted = false;
			_cbo_comp_account_2.TabIndex = 183;
			_cbo_comp_account_2.TabStop = true;
			_cbo_comp_account_2.Visible = true;
			_cbo_comp_account_2.SelectedIndexChanged += new System.EventHandler(cbo_comp_account_SelectedIndexChanged);
			// 
			// chkCompContactAddressFlag
			// 
			chkCompContactAddressFlag.AllowDrop = true;
			chkCompContactAddressFlag.Appearance = System.Windows.Forms.Appearance.Normal;
			chkCompContactAddressFlag.BackColor = System.Drawing.SystemColors.Control;
			chkCompContactAddressFlag.CausesValidation = true;
			chkCompContactAddressFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chkCompContactAddressFlag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkCompContactAddressFlag.Enabled = true;
			chkCompContactAddressFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkCompContactAddressFlag.ForeColor = System.Drawing.SystemColors.WindowText;
			chkCompContactAddressFlag.Location = new System.Drawing.Point(8, 208);
			chkCompContactAddressFlag.Name = "chkCompContactAddressFlag";
			chkCompContactAddressFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkCompContactAddressFlag.Size = new System.Drawing.Size(127, 17);
			chkCompContactAddressFlag.TabIndex = 188;
			chkCompContactAddressFlag.TabStop = true;
			chkCompContactAddressFlag.Text = "Individual/Company";
			chkCompContactAddressFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCompContactAddressFlag.Visible = true;
			// 
			// _cmd_company_update_callback_date_1
			// 
			_cmd_company_update_callback_date_1.AllowDrop = true;
			_cmd_company_update_callback_date_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_company_update_callback_date_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_company_update_callback_date_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_company_update_callback_date_1.Location = new System.Drawing.Point(456, 206);
			_cmd_company_update_callback_date_1.Name = "_cmd_company_update_callback_date_1";
			_cmd_company_update_callback_date_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_company_update_callback_date_1.Size = new System.Drawing.Size(171, 23);
			_cmd_company_update_callback_date_1.TabIndex = 196;
			_cmd_company_update_callback_date_1.Text = "Update Yacht Callback Date";
			_cmd_company_update_callback_date_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_company_update_callback_date_1.UseVisualStyleBackColor = false;
			_cmd_company_update_callback_date_1.Click += new System.EventHandler(cmd_company_update_callback_date_Click);
			_cmd_company_update_callback_date_1.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_company_update_callback_date_MouseUp);
			// 
			// _cbo_comp_account_6
			// 
			_cbo_comp_account_6.AllowDrop = true;
			_cbo_comp_account_6.BackColor = System.Drawing.SystemColors.Window;
			_cbo_comp_account_6.CausesValidation = true;
			_cbo_comp_account_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cbo_comp_account_6.Enabled = true;
			_cbo_comp_account_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_comp_account_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_comp_account_6.IntegralHeight = true;
			_cbo_comp_account_6.Location = new System.Drawing.Point(76, 182);
			_cbo_comp_account_6.Name = "_cbo_comp_account_6";
			_cbo_comp_account_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_comp_account_6.Size = new System.Drawing.Size(176, 21);
			_cbo_comp_account_6.Sorted = false;
			_cbo_comp_account_6.TabIndex = 198;
			_cbo_comp_account_6.TabStop = true;
			_cbo_comp_account_6.Visible = true;
			_cbo_comp_account_6.Items.AddRange(new object[]{"", "7 - Long Distance No Caller Id", "5 - Long Distance With Caller Id"});
			_cbo_comp_account_6.SelectedIndexChanged += new System.EventHandler(cbo_comp_account_SelectedIndexChanged);
			// 
			// _txt_company_field_0
			// 
			_txt_company_field_0.AcceptsReturn = true;
			_txt_company_field_0.AllowDrop = true;
			_txt_company_field_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_company_field_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_company_field_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_company_field_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_company_field_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_company_field_0.Location = new System.Drawing.Point(144, 236);
			_txt_company_field_0.MaxLength = 0;
			_txt_company_field_0.Name = "_txt_company_field_0";
			_txt_company_field_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_company_field_0.Size = new System.Drawing.Size(79, 21);
			_txt_company_field_0.TabIndex = 202;
			_txt_company_field_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_company_field_KeyDown);
			_txt_company_field_0.Leave += new System.EventHandler(txt_company_field_Leave);
			// 
			// _txt_company_field_1
			// 
			_txt_company_field_1.AcceptsReturn = true;
			_txt_company_field_1.AllowDrop = true;
			_txt_company_field_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_company_field_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_company_field_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_company_field_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_company_field_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_company_field_1.Location = new System.Drawing.Point(144, 124);
			_txt_company_field_1.MaxLength = 0;
			_txt_company_field_1.Name = "_txt_company_field_1";
			_txt_company_field_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_company_field_1.Size = new System.Drawing.Size(79, 21);
			_txt_company_field_1.TabIndex = 204;
			_txt_company_field_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_company_field_KeyDown);
			_txt_company_field_1.Leave += new System.EventHandler(txt_company_field_Leave);
			// 
			// _txt_company_field_3
			// 
			_txt_company_field_3.AcceptsReturn = true;
			_txt_company_field_3.AllowDrop = true;
			_txt_company_field_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_company_field_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_company_field_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_company_field_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_company_field_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_company_field_3.Location = new System.Drawing.Point(58, 276);
			_txt_company_field_3.MaxLength = 8;
			_txt_company_field_3.Name = "_txt_company_field_3";
			_txt_company_field_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_company_field_3.Size = new System.Drawing.Size(63, 21);
			_txt_company_field_3.TabIndex = 203;
			_txt_company_field_3.Text = "0";
			_txt_company_field_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_company_field_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_company_field_KeyDown);
			_txt_company_field_3.Leave += new System.EventHandler(txt_company_field_Leave);
			// 
			// _chk_array_6
			// 
			_chk_array_6.AllowDrop = true;
			_chk_array_6.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_array_6.BackColor = System.Drawing.SystemColors.Control;
			_chk_array_6.CausesValidation = true;
			_chk_array_6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_array_6.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_array_6.Enabled = true;
			_chk_array_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_array_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_array_6.Location = new System.Drawing.Point(544, 284);
			_chk_array_6.Name = "_chk_array_6";
			_chk_array_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_array_6.Size = new System.Drawing.Size(95, 13);
			_chk_array_6.TabIndex = 237;
			_chk_array_6.TabStop = true;
			_chk_array_6.Text = "Do Not Solicit";
			_chk_array_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_array_6.Visible = true;
			_chk_array_6.CheckStateChanged += new System.EventHandler(chk_array_CheckStateChanged);
			// 
			// _tab_company_admin_TabPage2
			// 
			_tab_company_admin_TabPage2.Controls.Add(pnl_research_notes);
			_tab_company_admin_TabPage2.Controls.Add(lst_research_notes);
			_tab_company_admin_TabPage2.Controls.Add(_lbl_test_omg3_2);
			_tab_company_admin_TabPage2.Controls.Add(_lbl_comp_78);
			_tab_company_admin_TabPage2.Controls.Add(_lbl_comp_41);
			_tab_company_admin_TabPage2.Controls.Add(_shp_dealer_background_2);
			_tab_company_admin_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_admin_TabPage2.Text = "HOT BOX";
			// 
			// pnl_research_notes
			// 
			pnl_research_notes.AllowDrop = true;
			pnl_research_notes.BackColor = System.Drawing.SystemColors.Control;
			pnl_research_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_research_notes.Controls.Add(txt_extra_research_note);
			pnl_research_notes.Controls.Add(cmd_company_clear_research_note);
			pnl_research_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_research_notes.Location = new System.Drawing.Point(9, 213);
			pnl_research_notes.Name = "pnl_research_notes";
			pnl_research_notes.Size = new System.Drawing.Size(634, 81);
			pnl_research_notes.TabIndex = 116;
			// 
			// txt_extra_research_note
			// 
			txt_extra_research_note.AcceptsReturn = true;
			txt_extra_research_note.AllowDrop = true;
			txt_extra_research_note.BackColor = System.Drawing.SystemColors.Window;
			txt_extra_research_note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_extra_research_note.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_extra_research_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_extra_research_note.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_extra_research_note.Location = new System.Drawing.Point(6, 18);
			txt_extra_research_note.MaxLength = 4000;
			txt_extra_research_note.Multiline = true;
			txt_extra_research_note.Name = "txt_extra_research_note";
			txt_extra_research_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_extra_research_note.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txt_extra_research_note.Size = new System.Drawing.Size(491, 58);
			txt_extra_research_note.TabIndex = 118;
			// 
			// cmd_company_clear_research_note
			// 
			cmd_company_clear_research_note.AllowDrop = true;
			cmd_company_clear_research_note.BackColor = System.Drawing.SystemColors.Control;
			cmd_company_clear_research_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_company_clear_research_note.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_company_clear_research_note.Location = new System.Drawing.Point(501, 10);
			cmd_company_clear_research_note.Name = "cmd_company_clear_research_note";
			cmd_company_clear_research_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_company_clear_research_note.Size = new System.Drawing.Size(121, 25);
			cmd_company_clear_research_note.TabIndex = 117;
			cmd_company_clear_research_note.Text = "Clear Research Action";
			cmd_company_clear_research_note.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_company_clear_research_note.UseVisualStyleBackColor = false;
			cmd_company_clear_research_note.Click += new System.EventHandler(cmd_company_clear_research_note_Click);
			cmd_company_clear_research_note.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_company_clear_research_note_MouseUp);
			// 
			// lst_research_notes
			// 
			lst_research_notes.AllowDrop = true;
			lst_research_notes.BackColor = System.Drawing.SystemColors.Window;
			lst_research_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_research_notes.CausesValidation = true;
			lst_research_notes.Enabled = true;
			lst_research_notes.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_research_notes.ForeColor = System.Drawing.Color.Red;
			lst_research_notes.IntegralHeight = true;
			lst_research_notes.Location = new System.Drawing.Point(8, 29);
			lst_research_notes.MultiColumn = false;
			lst_research_notes.Name = "lst_research_notes";
			lst_research_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_research_notes.Size = new System.Drawing.Size(634, 103);
			lst_research_notes.Sorted = false;
			lst_research_notes.TabIndex = 115;
			lst_research_notes.TabStop = true;
			lst_research_notes.Visible = true;
			lst_research_notes.SelectedIndexChanged += new System.EventHandler(lst_research_notes_SelectedIndexChanged);
			// 
			// _lbl_test_omg3_2
			// 
			_lbl_test_omg3_2.AllowDrop = true;
			_lbl_test_omg3_2.BackColor = System.Drawing.Color.Aqua;
			_lbl_test_omg3_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_test_omg3_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_test_omg3_2.ForeColor = System.Drawing.Color.Black;
			_lbl_test_omg3_2.Location = new System.Drawing.Point(360, 4);
			_lbl_test_omg3_2.MinimumSize = new System.Drawing.Size(113, 17);
			_lbl_test_omg3_2.Name = "_lbl_test_omg3_2";
			_lbl_test_omg3_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_test_omg3_2.Size = new System.Drawing.Size(113, 17);
			_lbl_test_omg3_2.TabIndex = 239;
			_lbl_test_omg3_2.Text = "-- You Are On Test --";
			_lbl_test_omg3_2.Visible = false;
			// 
			// _lbl_comp_78
			// 
			_lbl_comp_78.AllowDrop = true;
			_lbl_comp_78.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_comp_78.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_78.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_78.Location = new System.Drawing.Point(11, 138);
			_lbl_comp_78.MinimumSize = new System.Drawing.Size(631, 67);
			_lbl_comp_78.Name = "_lbl_comp_78";
			_lbl_comp_78.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_78.Size = new System.Drawing.Size(631, 67);
			_lbl_comp_78.TabIndex = 134;
			_lbl_comp_78.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_78.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_78.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_41
			// 
			_lbl_comp_41.AllowDrop = true;
			_lbl_comp_41.AutoSize = true;
			_lbl_comp_41.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_41.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_41.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_41.Location = new System.Drawing.Point(8, 11);
			_lbl_comp_41.MinimumSize = new System.Drawing.Size(284, 13);
			_lbl_comp_41.Name = "_lbl_comp_41";
			_lbl_comp_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_41.Size = new System.Drawing.Size(284, 13);
			_lbl_comp_41.TabIndex = 119;
			_lbl_comp_41.Text = "  Date                       Make/Model   [Ser#]   (Reg#)   Subject";
			_lbl_comp_41.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_41.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_41.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _shp_dealer_background_2
			// 
			_shp_dealer_background_2.AllowDrop = true;
			_shp_dealer_background_2.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_2.BackStyle = 1;
			_shp_dealer_background_2.BorderStyle = 0;
			_shp_dealer_background_2.Enabled = false;
			_shp_dealer_background_2.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_2.FillStyle = 1;
			_shp_dealer_background_2.Location = new System.Drawing.Point(0, 2);
			_shp_dealer_background_2.Name = "_shp_dealer_background_2";
			_shp_dealer_background_2.Size = new System.Drawing.Size(650, 310);
			_shp_dealer_background_2.Visible = false;
			// 
			// _tab_company_admin_TabPage3
			// 
			_tab_company_admin_TabPage3.Controls.Add(_shp_dealer_background_3);
			_tab_company_admin_TabPage3.Controls.Add(_lbl_comp_31);
			_tab_company_admin_TabPage3.Controls.Add(_lbl_comp_56);
			_tab_company_admin_TabPage3.Controls.Add(_lbl_comp_20);
			_tab_company_admin_TabPage3.Controls.Add(_lbl_comp_42);
			_tab_company_admin_TabPage3.Controls.Add(_lbl_comp_82);
			_tab_company_admin_TabPage3.Controls.Add(grd_company_history);
			_tab_company_admin_TabPage3.Controls.Add(txt_historical_ac_description);
			_tab_company_admin_TabPage3.Controls.Add(_cmdCompHistoryTab_0);
			_tab_company_admin_TabPage3.Controls.Add(_cmdCompHistoryTab_1);
			_tab_company_admin_TabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_admin_TabPage3.Text = "History";
			// 
			// _shp_dealer_background_3
			// 
			_shp_dealer_background_3.AllowDrop = true;
			_shp_dealer_background_3.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_3.BackStyle = 1;
			_shp_dealer_background_3.BorderStyle = 0;
			_shp_dealer_background_3.Enabled = false;
			_shp_dealer_background_3.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_3.FillStyle = 1;
			_shp_dealer_background_3.Location = new System.Drawing.Point(3, 3);
			_shp_dealer_background_3.Name = "_shp_dealer_background_3";
			_shp_dealer_background_3.Size = new System.Drawing.Size(648, 309);
			_shp_dealer_background_3.Visible = false;
			// 
			// _lbl_comp_31
			// 
			_lbl_comp_31.AllowDrop = true;
			_lbl_comp_31.AutoSize = true;
			_lbl_comp_31.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_31.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_31.Location = new System.Drawing.Point(500, 283);
			_lbl_comp_31.MinimumSize = new System.Drawing.Size(93, 13);
			_lbl_comp_31.Name = "_lbl_comp_31";
			_lbl_comp_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_31.Size = new System.Drawing.Size(93, 13);
			_lbl_comp_31.TabIndex = 112;
			_lbl_comp_31.Text = "Total History Count:";
			_lbl_comp_31.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_31.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_31.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_56
			// 
			_lbl_comp_56.AllowDrop = true;
			_lbl_comp_56.AutoSize = true;
			_lbl_comp_56.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_56.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_56.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_56.Location = new System.Drawing.Point(15, 64);
			_lbl_comp_56.MinimumSize = new System.Drawing.Size(96, 13);
			_lbl_comp_56.Name = "_lbl_comp_56";
			_lbl_comp_56.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_56.Size = new System.Drawing.Size(96, 13);
			_lbl_comp_56.TabIndex = 113;
			_lbl_comp_56.Text = "Selected Journal ID:";
			_lbl_comp_56.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_56.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_56.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_20
			// 
			_lbl_comp_20.AllowDrop = true;
			_lbl_comp_20.AutoSize = true;
			_lbl_comp_20.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_20.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_20.Location = new System.Drawing.Point(15, 283);
			_lbl_comp_20.MinimumSize = new System.Drawing.Size(387, 13);
			_lbl_comp_20.Name = "_lbl_comp_20";
			_lbl_comp_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_20.Size = new System.Drawing.Size(387, 13);
			_lbl_comp_20.TabIndex = 114;
			_lbl_comp_20.Text = "Only 25 records displayed. Click the \"Get All History Records\" for complete history.";
			_lbl_comp_20.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_20.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_20.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_42
			// 
			_lbl_comp_42.AllowDrop = true;
			_lbl_comp_42.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_comp_42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_42.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_42.Location = new System.Drawing.Point(594, 280);
			_lbl_comp_42.MinimumSize = new System.Drawing.Size(47, 19);
			_lbl_comp_42.Name = "_lbl_comp_42";
			_lbl_comp_42.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_42.Size = new System.Drawing.Size(47, 19);
			_lbl_comp_42.TabIndex = 141;
			_lbl_comp_42.Text = "Label42";
			_lbl_comp_42.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_42.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_42.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_82
			// 
			_lbl_comp_82.AllowDrop = true;
			_lbl_comp_82.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_82.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_comp_82.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_82.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_82.Location = new System.Drawing.Point(120, 61);
			_lbl_comp_82.MinimumSize = new System.Drawing.Size(69, 19);
			_lbl_comp_82.Name = "_lbl_comp_82";
			_lbl_comp_82.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_82.Size = new System.Drawing.Size(69, 19);
			_lbl_comp_82.TabIndex = 142;
			_lbl_comp_82.Text = "Label82";
			_lbl_comp_82.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_82.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_82.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// grd_company_history
			// 
			grd_company_history.AllowDrop = true;
			grd_company_history.AllowUserToAddRows = false;
			grd_company_history.AllowUserToDeleteRows = false;
			grd_company_history.AllowUserToResizeColumns = false;
			grd_company_history.AllowUserToResizeColumns = grd_company_history.ColumnHeadersVisible;
			grd_company_history.AllowUserToResizeRows = false;
			grd_company_history.AllowUserToResizeRows = false;
			grd_company_history.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_history.ColumnsCount = 2;
			grd_company_history.FixedColumns = 0;
			grd_company_history.FixedRows = 1;
			grd_company_history.Location = new System.Drawing.Point(13, 87);
			grd_company_history.Name = "grd_company_history";
			grd_company_history.ReadOnly = true;
			grd_company_history.RowsCount = 2;
			grd_company_history.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_company_history.ShowCellToolTips = false;
			grd_company_history.Size = new System.Drawing.Size(629, 185);
			grd_company_history.StandardTab = true;
			grd_company_history.TabIndex = 111;
			grd_company_history.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(grd_company_history_CellEnter);
			grd_company_history.Click += new System.EventHandler(grd_company_history_Click);
			grd_company_history.DoubleClick += new System.EventHandler(grd_company_history_DoubleClick);
			// 
			// txt_historical_ac_description
			// 
			txt_historical_ac_description.AcceptsReturn = true;
			txt_historical_ac_description.AllowDrop = true;
			txt_historical_ac_description.BackColor = System.Drawing.SystemColors.Window;
			txt_historical_ac_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_historical_ac_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_historical_ac_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_historical_ac_description.ForeColor = System.Drawing.SystemColors.GrayText;
			txt_historical_ac_description.Location = new System.Drawing.Point(13, 13);
			txt_historical_ac_description.MaxLength = 0;
			txt_historical_ac_description.Multiline = true;
			txt_historical_ac_description.Name = "txt_historical_ac_description";
			txt_historical_ac_description.ReadOnly = true;
			txt_historical_ac_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_historical_ac_description.Size = new System.Drawing.Size(629, 40);
			txt_historical_ac_description.TabIndex = 108;
			// 
			// _cmdCompHistoryTab_0
			// 
			_cmdCompHistoryTab_0.AllowDrop = true;
			_cmdCompHistoryTab_0.BackColor = System.Drawing.SystemColors.Control;
			_cmdCompHistoryTab_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdCompHistoryTab_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdCompHistoryTab_0.Location = new System.Drawing.Point(297, 58);
			_cmdCompHistoryTab_0.Name = "_cmdCompHistoryTab_0";
			_cmdCompHistoryTab_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdCompHistoryTab_0.Size = new System.Drawing.Size(167, 23);
			_cmdCompHistoryTab_0.TabIndex = 109;
			_cmdCompHistoryTab_0.Text = "View Current Company Record";
			_cmdCompHistoryTab_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdCompHistoryTab_0.UseVisualStyleBackColor = false;
			_cmdCompHistoryTab_0.Click += new System.EventHandler(cmdCompHistoryTab_Click);
			// 
			// _cmdCompHistoryTab_1
			// 
			_cmdCompHistoryTab_1.AllowDrop = true;
			_cmdCompHistoryTab_1.BackColor = System.Drawing.SystemColors.Control;
			_cmdCompHistoryTab_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdCompHistoryTab_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdCompHistoryTab_1.Location = new System.Drawing.Point(474, 58);
			_cmdCompHistoryTab_1.Name = "_cmdCompHistoryTab_1";
			_cmdCompHistoryTab_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdCompHistoryTab_1.Size = new System.Drawing.Size(167, 23);
			_cmdCompHistoryTab_1.TabIndex = 110;
			_cmdCompHistoryTab_1.Text = "Get All History Records";
			_cmdCompHistoryTab_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdCompHistoryTab_1.UseVisualStyleBackColor = false;
			_cmdCompHistoryTab_1.Click += new System.EventHandler(cmdCompHistoryTab_Click);
			// 
			// _tab_company_admin_TabPage4
			// 
			_tab_company_admin_TabPage4.Controls.Add(_cmd_relationship_buttons_4);
			_tab_company_admin_TabPage4.Controls.Add(_cmd_relationship_buttons_3);
			_tab_company_admin_TabPage4.Controls.Add(_cmd_relationship_buttons_2);
			_tab_company_admin_TabPage4.Controls.Add(_cmd_relationship_buttons_1);
			_tab_company_admin_TabPage4.Controls.Add(_cbo_comp_account_4);
			_tab_company_admin_TabPage4.Controls.Add(_cbo_comp_account_3);
			_tab_company_admin_TabPage4.Controls.Add(tab_company_rel);
			_tab_company_admin_TabPage4.Controls.Add(lst_related_contact);
			_tab_company_admin_TabPage4.Controls.Add(cbo_related_company_contact);
			_tab_company_admin_TabPage4.Controls.Add(chk_internal_relation);
			_tab_company_admin_TabPage4.Controls.Add(lst_related_company);
			_tab_company_admin_TabPage4.Controls.Add(_cmd_relationship_buttons_0);
			_tab_company_admin_TabPage4.Controls.Add(_lbl_comp_100);
			_tab_company_admin_TabPage4.Controls.Add(_lbl_comp_99);
			_tab_company_admin_TabPage4.Controls.Add(_lbl_comp_74);
			_tab_company_admin_TabPage4.Controls.Add(_shp_dealer_background_4);
			_tab_company_admin_TabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_admin_TabPage4.Text = "Relationships";
			// 
			// _cmd_relationship_buttons_4
			// 
			_cmd_relationship_buttons_4.AllowDrop = true;
			_cmd_relationship_buttons_4.BackColor = System.Drawing.SystemColors.Control;
			_cmd_relationship_buttons_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_relationship_buttons_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_relationship_buttons_4.Location = new System.Drawing.Point(8, 284);
			_cmd_relationship_buttons_4.Name = "_cmd_relationship_buttons_4";
			_cmd_relationship_buttons_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_relationship_buttons_4.Size = new System.Drawing.Size(165, 24);
			_cmd_relationship_buttons_4.TabIndex = 215;
			_cmd_relationship_buttons_4.Text = "Save Relationship";
			_cmd_relationship_buttons_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_relationship_buttons_4.UseVisualStyleBackColor = false;
			_cmd_relationship_buttons_4.Click += new System.EventHandler(cmd_relationship_buttons_Click);
			// 
			// _cmd_relationship_buttons_3
			// 
			_cmd_relationship_buttons_3.AllowDrop = true;
			_cmd_relationship_buttons_3.BackColor = System.Drawing.SystemColors.Control;
			_cmd_relationship_buttons_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_relationship_buttons_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_relationship_buttons_3.Location = new System.Drawing.Point(8, 257);
			_cmd_relationship_buttons_3.Name = "_cmd_relationship_buttons_3";
			_cmd_relationship_buttons_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_relationship_buttons_3.Size = new System.Drawing.Size(163, 24);
			_cmd_relationship_buttons_3.TabIndex = 214;
			_cmd_relationship_buttons_3.Text = "Confirm Contact";
			_cmd_relationship_buttons_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_relationship_buttons_3.UseVisualStyleBackColor = false;
			_cmd_relationship_buttons_3.Click += new System.EventHandler(cmd_relationship_buttons_Click);
			// 
			// _cmd_relationship_buttons_2
			// 
			_cmd_relationship_buttons_2.AllowDrop = true;
			_cmd_relationship_buttons_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_relationship_buttons_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_relationship_buttons_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_relationship_buttons_2.Location = new System.Drawing.Point(8, 230);
			_cmd_relationship_buttons_2.Name = "_cmd_relationship_buttons_2";
			_cmd_relationship_buttons_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_relationship_buttons_2.Size = new System.Drawing.Size(163, 24);
			_cmd_relationship_buttons_2.TabIndex = 213;
			_cmd_relationship_buttons_2.Text = "Confirm Company";
			_cmd_relationship_buttons_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_relationship_buttons_2.UseVisualStyleBackColor = false;
			_cmd_relationship_buttons_2.Click += new System.EventHandler(cmd_relationship_buttons_Click);
			// 
			// _cmd_relationship_buttons_1
			// 
			_cmd_relationship_buttons_1.AllowDrop = true;
			_cmd_relationship_buttons_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_relationship_buttons_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_relationship_buttons_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_relationship_buttons_1.Location = new System.Drawing.Point(8, 202);
			_cmd_relationship_buttons_1.Name = "_cmd_relationship_buttons_1";
			_cmd_relationship_buttons_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_relationship_buttons_1.Size = new System.Drawing.Size(163, 24);
			_cmd_relationship_buttons_1.TabIndex = 212;
			_cmd_relationship_buttons_1.Text = "Remove Company Relationship";
			_cmd_relationship_buttons_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_relationship_buttons_1.UseVisualStyleBackColor = false;
			_cmd_relationship_buttons_1.Click += new System.EventHandler(cmd_relationship_buttons_Click);
			// 
			// _cbo_comp_account_4
			// 
			_cbo_comp_account_4.AllowDrop = true;
			_cbo_comp_account_4.BackColor = System.Drawing.SystemColors.Window;
			_cbo_comp_account_4.CausesValidation = true;
			_cbo_comp_account_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cbo_comp_account_4.Enabled = true;
			_cbo_comp_account_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_comp_account_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_comp_account_4.IntegralHeight = true;
			_cbo_comp_account_4.Location = new System.Drawing.Point(518, 288);
			_cbo_comp_account_4.Name = "_cbo_comp_account_4";
			_cbo_comp_account_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_comp_account_4.Size = new System.Drawing.Size(126, 21);
			_cbo_comp_account_4.Sorted = false;
			_cbo_comp_account_4.TabIndex = 191;
			_cbo_comp_account_4.TabStop = true;
			_cbo_comp_account_4.Visible = false;
			_cbo_comp_account_4.SelectedIndexChanged += new System.EventHandler(cbo_comp_account_SelectedIndexChanged);
			// 
			// _cbo_comp_account_3
			// 
			_cbo_comp_account_3.AllowDrop = true;
			_cbo_comp_account_3.BackColor = System.Drawing.SystemColors.Window;
			_cbo_comp_account_3.CausesValidation = true;
			_cbo_comp_account_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cbo_comp_account_3.Enabled = true;
			_cbo_comp_account_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_comp_account_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_comp_account_3.IntegralHeight = true;
			_cbo_comp_account_3.Location = new System.Drawing.Point(296, 288);
			_cbo_comp_account_3.Name = "_cbo_comp_account_3";
			_cbo_comp_account_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_comp_account_3.Size = new System.Drawing.Size(204, 21);
			_cbo_comp_account_3.Sorted = false;
			_cbo_comp_account_3.TabIndex = 189;
			_cbo_comp_account_3.TabStop = true;
			_cbo_comp_account_3.Visible = false;
			_cbo_comp_account_3.SelectedIndexChanged += new System.EventHandler(cbo_comp_account_SelectedIndexChanged);
			// 
			// tab_company_rel
			// 
			tab_company_rel.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_company_rel.AllowDrop = true;
			tab_company_rel.Controls.Add(_tab_company_rel_TabPage0);
			tab_company_rel.Controls.Add(_tab_company_rel_TabPage1);
			tab_company_rel.Controls.Add(_tab_company_rel_TabPage2);
			tab_company_rel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_company_rel.ItemSize = new System.Drawing.Size(208, 18);
			tab_company_rel.Location = new System.Drawing.Point(8, 4);
			tab_company_rel.Multiline = true;
			tab_company_rel.Name = "tab_company_rel";
			tab_company_rel.Size = new System.Drawing.Size(631, 173);
			tab_company_rel.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_company_rel.TabIndex = 176;
			tab_company_rel.SelectedIndexChanged += new System.EventHandler(tab_company_rel_SelectedIndexChanged);
			// 
			// _tab_company_rel_TabPage0
			// 
			_tab_company_rel_TabPage0.Controls.Add(grd_company_relationships);
			_tab_company_rel_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_rel_TabPage0.Text = "Company Relationships";
			// 
			// grd_company_relationships
			// 
			grd_company_relationships.AllowDrop = true;
			grd_company_relationships.AllowUserToAddRows = false;
			grd_company_relationships.AllowUserToDeleteRows = false;
			grd_company_relationships.AllowUserToResizeColumns = false;
			grd_company_relationships.AllowUserToResizeColumns = grd_company_relationships.ColumnHeadersVisible;
			grd_company_relationships.AllowUserToResizeRows = false;
			grd_company_relationships.AllowUserToResizeRows = false;
			grd_company_relationships.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_relationships.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_relationships.ColumnsCount = 2;
			grd_company_relationships.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
			grd_company_relationships.FixedColumns = 0;
			grd_company_relationships.FixedRows = 1;
			grd_company_relationships.Location = new System.Drawing.Point(10, 4);
			grd_company_relationships.Name = "grd_company_relationships";
			grd_company_relationships.ReadOnly = true;
			grd_company_relationships.RowsCount = 2;
			grd_company_relationships.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_company_relationships.ShowCellToolTips = false;
			grd_company_relationships.Size = new System.Drawing.Size(613, 137);
			grd_company_relationships.StandardTab = true;
			grd_company_relationships.TabIndex = 177;
			grd_company_relationships.Click += new System.EventHandler(grd_company_relationships_Click);
			grd_company_relationships.DoubleClick += new System.EventHandler(grd_company_relationships_DoubleClick);
			// 
			// _tab_company_rel_TabPage1
			// 
			_tab_company_rel_TabPage1.Controls.Add(grd_company_contact_relationships);
			_tab_company_rel_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_rel_TabPage1.Text = "Contact Relationships";
			// 
			// grd_company_contact_relationships
			// 
			grd_company_contact_relationships.AllowDrop = true;
			grd_company_contact_relationships.AllowUserToAddRows = false;
			grd_company_contact_relationships.AllowUserToDeleteRows = false;
			grd_company_contact_relationships.AllowUserToResizeColumns = false;
			grd_company_contact_relationships.AllowUserToResizeColumns = grd_company_contact_relationships.ColumnHeadersVisible;
			grd_company_contact_relationships.AllowUserToResizeRows = false;
			grd_company_contact_relationships.AllowUserToResizeRows = false;
			grd_company_contact_relationships.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_contact_relationships.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_contact_relationships.ColumnsCount = 2;
			grd_company_contact_relationships.FixedColumns = 1;
			grd_company_contact_relationships.FixedRows = 1;
			grd_company_contact_relationships.Location = new System.Drawing.Point(6, 4);
			grd_company_contact_relationships.Name = "grd_company_contact_relationships";
			grd_company_contact_relationships.ReadOnly = true;
			grd_company_contact_relationships.RowsCount = 2;
			grd_company_contact_relationships.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_company_contact_relationships.ShowCellToolTips = false;
			grd_company_contact_relationships.Size = new System.Drawing.Size(613, 137);
			grd_company_contact_relationships.StandardTab = true;
			grd_company_contact_relationships.TabIndex = 178;
			grd_company_contact_relationships.Visible = false;
			grd_company_contact_relationships.Click += new System.EventHandler(grd_company_contact_relationships_Click);
			grd_company_contact_relationships.DoubleClick += new System.EventHandler(grd_company_contact_relationships_DoubleClick);
			// 
			// _tab_company_rel_TabPage2
			// 
			_tab_company_rel_TabPage2.Controls.Add(grdCompDupByAdd);
			_tab_company_rel_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_rel_TabPage2.Text = "Duplicate By Address/City";
			// 
			// grdCompDupByAdd
			// 
			grdCompDupByAdd.AllowDrop = true;
			grdCompDupByAdd.AllowUserToAddRows = false;
			grdCompDupByAdd.AllowUserToDeleteRows = false;
			grdCompDupByAdd.AllowUserToResizeColumns = false;
			grdCompDupByAdd.AllowUserToResizeColumns = grdCompDupByAdd.ColumnHeadersVisible;
			grdCompDupByAdd.AllowUserToResizeRows = false;
			grdCompDupByAdd.AllowUserToResizeRows = false;
			grdCompDupByAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdCompDupByAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdCompDupByAdd.ColumnsCount = 2;
			grdCompDupByAdd.FixedColumns = 1;
			grdCompDupByAdd.FixedRows = 1;
			grdCompDupByAdd.Location = new System.Drawing.Point(6, 4);
			grdCompDupByAdd.Name = "grdCompDupByAdd";
			grdCompDupByAdd.ReadOnly = true;
			grdCompDupByAdd.RowsCount = 2;
			grdCompDupByAdd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdCompDupByAdd.ShowCellToolTips = false;
			grdCompDupByAdd.Size = new System.Drawing.Size(613, 137);
			grdCompDupByAdd.StandardTab = true;
			grdCompDupByAdd.TabIndex = 184;
			grdCompDupByAdd.Visible = false;
			grdCompDupByAdd.Click += new System.EventHandler(grdCompDupByAdd_Click);
			grdCompDupByAdd.DoubleClick += new System.EventHandler(grdCompDupByAdd_DoubleClick);
			// 
			// lst_related_contact
			// 
			lst_related_contact.AllowDrop = true;
			lst_related_contact.BackColor = System.Drawing.SystemColors.Window;
			lst_related_contact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_related_contact.CausesValidation = true;
			lst_related_contact.Enabled = true;
			lst_related_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_related_contact.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_related_contact.IntegralHeight = true;
			lst_related_contact.Location = new System.Drawing.Point(408, 180);
			lst_related_contact.MultiColumn = false;
			lst_related_contact.Name = "lst_related_contact";
			lst_related_contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_related_contact.Size = new System.Drawing.Size(229, 83);
			lst_related_contact.Sorted = false;
			lst_related_contact.TabIndex = 80;
			lst_related_contact.TabStop = true;
			lst_related_contact.Visible = true;
			lst_related_contact.SelectedIndexChanged += new System.EventHandler(lst_Related_Contact_SelectedIndexChanged);
			// 
			// cbo_related_company_contact
			// 
			cbo_related_company_contact.AllowDrop = true;
			cbo_related_company_contact.BackColor = System.Drawing.SystemColors.Window;
			cbo_related_company_contact.CausesValidation = true;
			cbo_related_company_contact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_related_company_contact.Enabled = true;
			cbo_related_company_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_related_company_contact.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_related_company_contact.IntegralHeight = true;
			cbo_related_company_contact.Location = new System.Drawing.Point(408, 264);
			cbo_related_company_contact.Name = "cbo_related_company_contact";
			cbo_related_company_contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_related_company_contact.Size = new System.Drawing.Size(226, 21);
			cbo_related_company_contact.Sorted = false;
			cbo_related_company_contact.TabIndex = 79;
			cbo_related_company_contact.TabStop = true;
			cbo_related_company_contact.Visible = true;
			cbo_related_company_contact.SelectedIndexChanged += new System.EventHandler(cbo_related_company_contact_SelectedIndexChanged);
			// 
			// chk_internal_relation
			// 
			chk_internal_relation.AllowDrop = true;
			chk_internal_relation.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_internal_relation.BackColor = System.Drawing.Color.Yellow;
			chk_internal_relation.CausesValidation = true;
			chk_internal_relation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_internal_relation.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_internal_relation.Enabled = true;
			chk_internal_relation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_internal_relation.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_internal_relation.Location = new System.Drawing.Point(10, 44);
			chk_internal_relation.Name = "chk_internal_relation";
			chk_internal_relation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_internal_relation.Size = new System.Drawing.Size(58, 21);
			chk_internal_relation.TabIndex = 61;
			chk_internal_relation.TabStop = true;
			chk_internal_relation.Text = "Internal";
			chk_internal_relation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_internal_relation.Visible = false;
			chk_internal_relation.CheckStateChanged += new System.EventHandler(chk_internal_relation_CheckStateChanged);
			// 
			// lst_related_company
			// 
			lst_related_company.AllowDrop = true;
			lst_related_company.BackColor = System.Drawing.SystemColors.Window;
			lst_related_company.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_related_company.CausesValidation = true;
			lst_related_company.Enabled = true;
			lst_related_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_related_company.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_related_company.IntegralHeight = true;
			lst_related_company.Location = new System.Drawing.Point(176, 180);
			lst_related_company.MultiColumn = false;
			lst_related_company.Name = "lst_related_company";
			lst_related_company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_related_company.Size = new System.Drawing.Size(229, 109);
			lst_related_company.Sorted = false;
			lst_related_company.TabIndex = 60;
			lst_related_company.TabStop = true;
			lst_related_company.Visible = true;
			lst_related_company.SelectedIndexChanged += new System.EventHandler(lst_related_company_SelectedIndexChanged);
			// 
			// _cmd_relationship_buttons_0
			// 
			_cmd_relationship_buttons_0.AllowDrop = true;
			_cmd_relationship_buttons_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_relationship_buttons_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_relationship_buttons_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_relationship_buttons_0.Location = new System.Drawing.Point(8, 175);
			_cmd_relationship_buttons_0.Name = "_cmd_relationship_buttons_0";
			_cmd_relationship_buttons_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_relationship_buttons_0.Size = new System.Drawing.Size(163, 24);
			_cmd_relationship_buttons_0.TabIndex = 59;
			_cmd_relationship_buttons_0.Text = "Add Company Relationship";
			_cmd_relationship_buttons_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_relationship_buttons_0.UseVisualStyleBackColor = false;
			_cmd_relationship_buttons_0.Click += new System.EventHandler(cmd_relationship_buttons_Click);
			// 
			// _lbl_comp_100
			// 
			_lbl_comp_100.AllowDrop = true;
			_lbl_comp_100.AutoSize = true;
			_lbl_comp_100.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_100.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_100.ForeColor = System.Drawing.Color.Blue;
			_lbl_comp_100.Location = new System.Drawing.Point(504, 292);
			_lbl_comp_100.MinimumSize = new System.Drawing.Size(11, 13);
			_lbl_comp_100.Name = "_lbl_comp_100";
			_lbl_comp_100.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_100.Size = new System.Drawing.Size(11, 13);
			_lbl_comp_100.TabIndex = 192;
			_lbl_comp_100.Text = "!!!";
			_lbl_comp_100.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_100.Visible = false;
			_lbl_comp_100.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_100.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_100.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_99
			// 
			_lbl_comp_99.AllowDrop = true;
			_lbl_comp_99.AutoSize = true;
			_lbl_comp_99.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_99.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_99.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_99.ForeColor = System.Drawing.Color.Blue;
			_lbl_comp_99.Location = new System.Drawing.Point(278, 294);
			_lbl_comp_99.MinimumSize = new System.Drawing.Size(11, 13);
			_lbl_comp_99.Name = "_lbl_comp_99";
			_lbl_comp_99.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_99.Size = new System.Drawing.Size(11, 13);
			_lbl_comp_99.TabIndex = 190;
			_lbl_comp_99.Text = "lbl";
			_lbl_comp_99.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_99.Visible = false;
			_lbl_comp_99.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_99.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_99.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_74
			// 
			_lbl_comp_74.AllowDrop = true;
			_lbl_comp_74.AutoSize = true;
			_lbl_comp_74.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_74.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_74.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_74.ForeColor = System.Drawing.Color.Blue;
			_lbl_comp_74.Location = new System.Drawing.Point(184, 292);
			_lbl_comp_74.MinimumSize = new System.Drawing.Size(93, 13);
			_lbl_comp_74.Name = "_lbl_comp_74";
			_lbl_comp_74.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_74.Size = new System.Drawing.Size(93, 13);
			_lbl_comp_74.TabIndex = 180;
			_lbl_comp_74.Text = "Hide Relationship";
			_lbl_comp_74.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_74.Visible = false;
			_lbl_comp_74.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_74.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_74.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _shp_dealer_background_4
			// 
			_shp_dealer_background_4.AllowDrop = true;
			_shp_dealer_background_4.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_4.BackStyle = 1;
			_shp_dealer_background_4.BorderStyle = 0;
			_shp_dealer_background_4.Enabled = false;
			_shp_dealer_background_4.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_4.FillStyle = 1;
			_shp_dealer_background_4.Location = new System.Drawing.Point(2, 4);
			_shp_dealer_background_4.Name = "_shp_dealer_background_4";
			_shp_dealer_background_4.Size = new System.Drawing.Size(650, 310);
			_shp_dealer_background_4.Visible = false;
			// 
			// _tab_company_admin_TabPage5
			// 
			_tab_company_admin_TabPage5.Controls.Add(lst_abi_services);
			_tab_company_admin_TabPage5.Controls.Add(cmd_company_update_stats);
			_tab_company_admin_TabPage5.Controls.Add(grd_company_stats);
			_tab_company_admin_TabPage5.Controls.Add(_lbl_comp_19);
			_tab_company_admin_TabPage5.Controls.Add(_shp_dealer_background_5);
			_tab_company_admin_TabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_admin_TabPage5.Text = "Statistics";
			// 
			// lst_abi_services
			// 
			lst_abi_services.AllowDrop = true;
			lst_abi_services.BackColor = System.Drawing.SystemColors.Window;
			lst_abi_services.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_abi_services.CausesValidation = true;
			lst_abi_services.Enabled = true;
			lst_abi_services.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_abi_services.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			lst_abi_services.IntegralHeight = true;
			lst_abi_services.Location = new System.Drawing.Point(317, 208);
			lst_abi_services.MultiColumn = false;
			lst_abi_services.Name = "lst_abi_services";
			lst_abi_services.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_abi_services.Size = new System.Drawing.Size(298, 89);
			lst_abi_services.Sorted = false;
			lst_abi_services.TabIndex = 86;
			lst_abi_services.TabStop = true;
			lst_abi_services.Visible = true;
			// 
			// cmd_company_update_stats
			// 
			cmd_company_update_stats.AllowDrop = true;
			cmd_company_update_stats.BackColor = System.Drawing.SystemColors.Control;
			cmd_company_update_stats.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_company_update_stats.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_company_update_stats.Location = new System.Drawing.Point(210, 208);
			cmd_company_update_stats.Name = "cmd_company_update_stats";
			cmd_company_update_stats.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_company_update_stats.Size = new System.Drawing.Size(97, 25);
			cmd_company_update_stats.TabIndex = 68;
			cmd_company_update_stats.Text = "Update Statistics";
			cmd_company_update_stats.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_company_update_stats.UseVisualStyleBackColor = false;
			cmd_company_update_stats.Click += new System.EventHandler(cmd_company_update_stats_Click);
			cmd_company_update_stats.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_company_update_stats_MouseUp);
			// 
			// grd_company_stats
			// 
			grd_company_stats.AllowDrop = true;
			grd_company_stats.AllowUserToAddRows = false;
			grd_company_stats.AllowUserToDeleteRows = false;
			grd_company_stats.AllowUserToResizeColumns = false;
			grd_company_stats.AllowUserToResizeColumns = grd_company_stats.ColumnHeadersVisible;
			grd_company_stats.AllowUserToResizeRows = false;
			grd_company_stats.AllowUserToResizeRows = false;
			grd_company_stats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_stats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_stats.ColumnsCount = 8;
			grd_company_stats.FixedColumns = 0;
			grd_company_stats.FixedRows = 1;
			grd_company_stats.Location = new System.Drawing.Point(35, 58);
			grd_company_stats.Name = "grd_company_stats";
			grd_company_stats.ReadOnly = true;
			grd_company_stats.RowsCount = 2;
			grd_company_stats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_company_stats.ShowCellToolTips = false;
			grd_company_stats.Size = new System.Drawing.Size(581, 129);
			grd_company_stats.StandardTab = true;
			grd_company_stats.TabIndex = 67;
			// 
			// _lbl_comp_19
			// 
			_lbl_comp_19.AllowDrop = true;
			_lbl_comp_19.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_19.Location = new System.Drawing.Point(49, 14);
			_lbl_comp_19.MinimumSize = new System.Drawing.Size(545, 34);
			_lbl_comp_19.Name = "_lbl_comp_19";
			_lbl_comp_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_19.Size = new System.Drawing.Size(545, 34);
			_lbl_comp_19.TabIndex = 69;
			_lbl_comp_19.Text = "The following table summarizes active aircraft owned and/or operated by this company.  Note that fractional and co-owned aircraft percentages are summarized to identify a total aircraft value.";
			_lbl_comp_19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_19.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_19.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_19.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _shp_dealer_background_5
			// 
			_shp_dealer_background_5.AllowDrop = true;
			_shp_dealer_background_5.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_5.BackStyle = 1;
			_shp_dealer_background_5.BorderStyle = 0;
			_shp_dealer_background_5.Enabled = false;
			_shp_dealer_background_5.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_5.FillStyle = 1;
			_shp_dealer_background_5.Location = new System.Drawing.Point(2, 2);
			_shp_dealer_background_5.Name = "_shp_dealer_background_5";
			_shp_dealer_background_5.Size = new System.Drawing.Size(649, 310);
			_shp_dealer_background_5.Visible = false;
			// 
			// _tab_company_admin_TabPage6
			// 
			_tab_company_admin_TabPage6.Controls.Add(_shp_dealer_background_6);
			_tab_company_admin_TabPage6.Controls.Add(_lbl_comp_92);
			_tab_company_admin_TabPage6.Controls.Add(grd_company_cert);
			_tab_company_admin_TabPage6.Controls.Add(cert_edit_enter_frame);
			_tab_company_admin_TabPage6.Controls.Add(_cmdCertCommand_4);
			_tab_company_admin_TabPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_company_admin_TabPage6.Text = "Cert/Orgs";
			// 
			// _shp_dealer_background_6
			// 
			_shp_dealer_background_6.AllowDrop = true;
			_shp_dealer_background_6.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			_shp_dealer_background_6.BackStyle = 1;
			_shp_dealer_background_6.BorderStyle = 0;
			_shp_dealer_background_6.Enabled = false;
			_shp_dealer_background_6.FillColor = System.Drawing.Color.Black;
			_shp_dealer_background_6.FillStyle = 1;
			_shp_dealer_background_6.Location = new System.Drawing.Point(1, 2);
			_shp_dealer_background_6.Name = "_shp_dealer_background_6";
			_shp_dealer_background_6.Size = new System.Drawing.Size(651, 310);
			_shp_dealer_background_6.Visible = false;
			// 
			// _lbl_comp_92
			// 
			_lbl_comp_92.AllowDrop = true;
			_lbl_comp_92.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_92.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_92.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_92.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_92.Location = new System.Drawing.Point(8, 124);
			_lbl_comp_92.MinimumSize = new System.Drawing.Size(513, 33);
			_lbl_comp_92.Name = "_lbl_comp_92";
			_lbl_comp_92.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_92.Size = new System.Drawing.Size(513, 33);
			_lbl_comp_92.TabIndex = 156;
			_lbl_comp_92.Text = "There Are No Current Certifications For This Company";
			_lbl_comp_92.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_92.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_92.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// grd_company_cert
			// 
			grd_company_cert.AllowDrop = true;
			grd_company_cert.AllowUserToAddRows = false;
			grd_company_cert.AllowUserToDeleteRows = false;
			grd_company_cert.AllowUserToResizeColumns = false;
			grd_company_cert.AllowUserToResizeColumns = grd_company_cert.ColumnHeadersVisible;
			grd_company_cert.AllowUserToResizeRows = false;
			grd_company_cert.AllowUserToResizeRows = false;
			grd_company_cert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_company_cert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_cert.ColumnsCount = 2;
			grd_company_cert.FixedColumns = 0;
			grd_company_cert.FixedRows = 1;
			grd_company_cert.Location = new System.Drawing.Point(8, 12);
			grd_company_cert.Name = "grd_company_cert";
			grd_company_cert.ReadOnly = true;
			grd_company_cert.RowsCount = 2;
			grd_company_cert.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_company_cert.ShowCellToolTips = false;
			grd_company_cert.Size = new System.Drawing.Size(617, 115);
			grd_company_cert.StandardTab = true;
			grd_company_cert.TabIndex = 74;
			grd_company_cert.Click += new System.EventHandler(grd_company_cert_Click);
			// 
			// cert_edit_enter_frame
			// 
			cert_edit_enter_frame.AllowDrop = true;
			cert_edit_enter_frame.BackColor = System.Drawing.SystemColors.Control;
			cert_edit_enter_frame.Controls.Add(_cert_combo_drop_down_1);
			cert_edit_enter_frame.Controls.Add(_cert_combo_drop_down_0);
			cert_edit_enter_frame.Controls.Add(cert_number_textbox);
			cert_edit_enter_frame.Controls.Add(cert_name_textbox);
			cert_edit_enter_frame.Controls.Add(cert_note_textbox);
			cert_edit_enter_frame.Controls.Add(_cmdCertCommand_3);
			cert_edit_enter_frame.Controls.Add(_cmdCertCommand_2);
			cert_edit_enter_frame.Controls.Add(_cmdCertCommand_1);
			cert_edit_enter_frame.Controls.Add(_cmdCertCommand_0);
			cert_edit_enter_frame.Controls.Add(_lbl_comp_30);
			cert_edit_enter_frame.Controls.Add(_lbl_comp_73);
			cert_edit_enter_frame.Controls.Add(lbl_company_cert_id_label);
			cert_edit_enter_frame.Controls.Add(_lbl_comp_96);
			cert_edit_enter_frame.Controls.Add(_lbl_comp_94);
			cert_edit_enter_frame.Controls.Add(_lbl_comp_95);
			cert_edit_enter_frame.Controls.Add(_lbl_comp_93);
			cert_edit_enter_frame.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			cert_edit_enter_frame.Enabled = true;
			cert_edit_enter_frame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cert_edit_enter_frame.ForeColor = System.Drawing.SystemColors.ControlText;
			cert_edit_enter_frame.Location = new System.Drawing.Point(8, 156);
			cert_edit_enter_frame.Name = "cert_edit_enter_frame";
			cert_edit_enter_frame.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cert_edit_enter_frame.Size = new System.Drawing.Size(617, 153);
			cert_edit_enter_frame.TabIndex = 150;
			cert_edit_enter_frame.Visible = true;
			// 
			// _cert_combo_drop_down_1
			// 
			_cert_combo_drop_down_1.AllowDrop = true;
			_cert_combo_drop_down_1.BackColor = System.Drawing.SystemColors.Window;
			_cert_combo_drop_down_1.CausesValidation = true;
			_cert_combo_drop_down_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cert_combo_drop_down_1.Enabled = true;
			_cert_combo_drop_down_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cert_combo_drop_down_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cert_combo_drop_down_1.IntegralHeight = true;
			_cert_combo_drop_down_1.Location = new System.Drawing.Point(134, 39);
			_cert_combo_drop_down_1.Name = "_cert_combo_drop_down_1";
			_cert_combo_drop_down_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cert_combo_drop_down_1.Size = new System.Drawing.Size(134, 21);
			_cert_combo_drop_down_1.Sorted = false;
			_cert_combo_drop_down_1.TabIndex = 223;
			_cert_combo_drop_down_1.TabStop = true;
			_cert_combo_drop_down_1.Visible = false;
			_cert_combo_drop_down_1.SelectionChangeCommitted += new System.EventHandler(cert_combo_drop_down_SelectionChangeCommitted);
			// 
			// _cert_combo_drop_down_0
			// 
			_cert_combo_drop_down_0.AllowDrop = true;
			_cert_combo_drop_down_0.BackColor = System.Drawing.SystemColors.Window;
			_cert_combo_drop_down_0.CausesValidation = true;
			_cert_combo_drop_down_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cert_combo_drop_down_0.Enabled = true;
			_cert_combo_drop_down_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cert_combo_drop_down_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cert_combo_drop_down_0.IntegralHeight = true;
			_cert_combo_drop_down_0.Location = new System.Drawing.Point(134, 8);
			_cert_combo_drop_down_0.Name = "_cert_combo_drop_down_0";
			_cert_combo_drop_down_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cert_combo_drop_down_0.Size = new System.Drawing.Size(216, 21);
			_cert_combo_drop_down_0.Sorted = false;
			_cert_combo_drop_down_0.TabIndex = 222;
			_cert_combo_drop_down_0.TabStop = true;
			_cert_combo_drop_down_0.Text = "Combo1";
			_cert_combo_drop_down_0.Visible = true;
			_cert_combo_drop_down_0.SelectionChangeCommitted += new System.EventHandler(cert_combo_drop_down_SelectionChangeCommitted);
			// 
			// cert_number_textbox
			// 
			cert_number_textbox.AcceptsReturn = true;
			cert_number_textbox.AllowDrop = true;
			cert_number_textbox.BackColor = System.Drawing.SystemColors.Window;
			cert_number_textbox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			cert_number_textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			cert_number_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cert_number_textbox.ForeColor = System.Drawing.SystemColors.WindowText;
			cert_number_textbox.Location = new System.Drawing.Point(134, 70);
			cert_number_textbox.MaxLength = 50;
			cert_number_textbox.Name = "cert_number_textbox";
			cert_number_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cert_number_textbox.Size = new System.Drawing.Size(200, 19);
			cert_number_textbox.TabIndex = 221;
			// 
			// cert_name_textbox
			// 
			cert_name_textbox.AcceptsReturn = true;
			cert_name_textbox.AllowDrop = true;
			cert_name_textbox.BackColor = System.Drawing.SystemColors.Window;
			cert_name_textbox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			cert_name_textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			cert_name_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cert_name_textbox.ForeColor = System.Drawing.SystemColors.WindowText;
			cert_name_textbox.Location = new System.Drawing.Point(134, 99);
			cert_name_textbox.MaxLength = 40;
			cert_name_textbox.Name = "cert_name_textbox";
			cert_name_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cert_name_textbox.Size = new System.Drawing.Size(467, 19);
			cert_name_textbox.TabIndex = 220;
			// 
			// cert_note_textbox
			// 
			cert_note_textbox.AcceptsReturn = true;
			cert_note_textbox.AllowDrop = true;
			cert_note_textbox.BackColor = System.Drawing.SystemColors.Window;
			cert_note_textbox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			cert_note_textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			cert_note_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cert_note_textbox.ForeColor = System.Drawing.SystemColors.WindowText;
			cert_note_textbox.Location = new System.Drawing.Point(134, 128);
			cert_note_textbox.MaxLength = 500;
			cert_note_textbox.Name = "cert_note_textbox";
			cert_note_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cert_note_textbox.Size = new System.Drawing.Size(467, 19);
			cert_note_textbox.TabIndex = 219;
			// 
			// _cmdCertCommand_3
			// 
			_cmdCertCommand_3.AllowDrop = true;
			_cmdCertCommand_3.BackColor = System.Drawing.SystemColors.Control;
			_cmdCertCommand_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdCertCommand_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdCertCommand_3.Location = new System.Drawing.Point(492, 54);
			_cmdCertCommand_3.Name = "_cmdCertCommand_3";
			_cmdCertCommand_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdCertCommand_3.Size = new System.Drawing.Size(107, 34);
			_cmdCertCommand_3.TabIndex = 187;
			_cmdCertCommand_3.Text = "Cancel";
			_cmdCertCommand_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdCertCommand_3.UseVisualStyleBackColor = false;
			_cmdCertCommand_3.Click += new System.EventHandler(cmdCertCommand_Click);
			// 
			// _cmdCertCommand_2
			// 
			_cmdCertCommand_2.AllowDrop = true;
			_cmdCertCommand_2.BackColor = System.Drawing.SystemColors.Control;
			_cmdCertCommand_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdCertCommand_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdCertCommand_2.Location = new System.Drawing.Point(376, 54);
			_cmdCertCommand_2.Name = "_cmdCertCommand_2";
			_cmdCertCommand_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdCertCommand_2.Size = new System.Drawing.Size(107, 34);
			_cmdCertCommand_2.TabIndex = 186;
			_cmdCertCommand_2.Text = "Remove";
			_cmdCertCommand_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdCertCommand_2.UseVisualStyleBackColor = false;
			_cmdCertCommand_2.Click += new System.EventHandler(cmdCertCommand_Click);
			// 
			// _cmdCertCommand_1
			// 
			_cmdCertCommand_1.AllowDrop = true;
			_cmdCertCommand_1.BackColor = System.Drawing.SystemColors.Control;
			_cmdCertCommand_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdCertCommand_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdCertCommand_1.Location = new System.Drawing.Point(492, 16);
			_cmdCertCommand_1.Name = "_cmdCertCommand_1";
			_cmdCertCommand_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdCertCommand_1.Size = new System.Drawing.Size(107, 34);
			_cmdCertCommand_1.TabIndex = 185;
			_cmdCertCommand_1.Text = "Save";
			_cmdCertCommand_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdCertCommand_1.UseVisualStyleBackColor = false;
			_cmdCertCommand_1.Click += new System.EventHandler(cmdCertCommand_Click);
			// 
			// _cmdCertCommand_0
			// 
			_cmdCertCommand_0.AllowDrop = true;
			_cmdCertCommand_0.BackColor = System.Drawing.SystemColors.Control;
			_cmdCertCommand_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdCertCommand_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdCertCommand_0.Location = new System.Drawing.Point(376, 16);
			_cmdCertCommand_0.Name = "_cmdCertCommand_0";
			_cmdCertCommand_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdCertCommand_0.Size = new System.Drawing.Size(107, 34);
			_cmdCertCommand_0.TabIndex = 155;
			_cmdCertCommand_0.Text = "Update";
			_cmdCertCommand_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdCertCommand_0.UseVisualStyleBackColor = false;
			_cmdCertCommand_0.Click += new System.EventHandler(cmdCertCommand_Click);
			// 
			// _lbl_comp_30
			// 
			_lbl_comp_30.AllowDrop = true;
			_lbl_comp_30.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_30.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_30.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_30.Location = new System.Drawing.Point(7, 42);
			_lbl_comp_30.MinimumSize = new System.Drawing.Size(105, 25);
			_lbl_comp_30.Name = "_lbl_comp_30";
			_lbl_comp_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_30.Size = new System.Drawing.Size(105, 25);
			_lbl_comp_30.TabIndex = 218;
			_lbl_comp_30.Text = "Category: ";
			_lbl_comp_30.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_30.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_30.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_73
			// 
			_lbl_comp_73.AllowDrop = true;
			_lbl_comp_73.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_73.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_73.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_73.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_73.Location = new System.Drawing.Point(576, 16);
			_lbl_comp_73.MinimumSize = new System.Drawing.Size(33, 25);
			_lbl_comp_73.Name = "_lbl_comp_73";
			_lbl_comp_73.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_73.Size = new System.Drawing.Size(33, 25);
			_lbl_comp_73.TabIndex = 179;
			_lbl_comp_73.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_73.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_73.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// lbl_company_cert_id_label
			// 
			lbl_company_cert_id_label.AllowDrop = true;
			lbl_company_cert_id_label.BackColor = System.Drawing.SystemColors.Control;
			lbl_company_cert_id_label.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_company_cert_id_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_company_cert_id_label.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_company_cert_id_label.Location = new System.Drawing.Point(552, 16);
			lbl_company_cert_id_label.MinimumSize = new System.Drawing.Size(25, 25);
			lbl_company_cert_id_label.Name = "lbl_company_cert_id_label";
			lbl_company_cert_id_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_company_cert_id_label.Size = new System.Drawing.Size(25, 25);
			lbl_company_cert_id_label.TabIndex = 157;
			lbl_company_cert_id_label.Text = "ID: ";
			// 
			// _lbl_comp_96
			// 
			_lbl_comp_96.AllowDrop = true;
			_lbl_comp_96.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_96.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_96.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_96.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_96.Location = new System.Drawing.Point(7, 128);
			_lbl_comp_96.MinimumSize = new System.Drawing.Size(129, 17);
			_lbl_comp_96.Name = "_lbl_comp_96";
			_lbl_comp_96.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_96.Size = new System.Drawing.Size(129, 17);
			_lbl_comp_96.TabIndex = 154;
			_lbl_comp_96.Text = "Certification Note: ";
			_lbl_comp_96.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_96.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_96.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_94
			// 
			_lbl_comp_94.AllowDrop = true;
			_lbl_comp_94.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_94.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_94.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_94.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_94.Location = new System.Drawing.Point(7, 76);
			_lbl_comp_94.MinimumSize = new System.Drawing.Size(113, 17);
			_lbl_comp_94.Name = "_lbl_comp_94";
			_lbl_comp_94.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_94.Size = new System.Drawing.Size(113, 17);
			_lbl_comp_94.TabIndex = 153;
			_lbl_comp_94.Text = "Certification Number: ";
			_lbl_comp_94.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_94.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_94.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_95
			// 
			_lbl_comp_95.AllowDrop = true;
			_lbl_comp_95.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_95.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_95.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_95.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_95.Location = new System.Drawing.Point(7, 102);
			_lbl_comp_95.MinimumSize = new System.Drawing.Size(113, 17);
			_lbl_comp_95.Name = "_lbl_comp_95";
			_lbl_comp_95.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_95.Size = new System.Drawing.Size(113, 17);
			_lbl_comp_95.TabIndex = 152;
			_lbl_comp_95.Text = "Company Certified As: ";
			_lbl_comp_95.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_95.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_95.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_93
			// 
			_lbl_comp_93.AllowDrop = true;
			_lbl_comp_93.BackColor = System.Drawing.SystemColors.Control;
			_lbl_comp_93.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_93.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_93.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_93.Location = new System.Drawing.Point(7, 8);
			_lbl_comp_93.MinimumSize = new System.Drawing.Size(105, 25);
			_lbl_comp_93.Name = "_lbl_comp_93";
			_lbl_comp_93.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_93.Size = new System.Drawing.Size(105, 25);
			_lbl_comp_93.TabIndex = 151;
			_lbl_comp_93.Text = "Certification Type: ";
			_lbl_comp_93.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_93.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_93.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _cmdCertCommand_4
			// 
			_cmdCertCommand_4.AllowDrop = true;
			_cmdCertCommand_4.BackColor = System.Drawing.SystemColors.Control;
			_cmdCertCommand_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdCertCommand_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdCertCommand_4.Location = new System.Drawing.Point(532, 130);
			_cmdCertCommand_4.Name = "_cmdCertCommand_4";
			_cmdCertCommand_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdCertCommand_4.Size = new System.Drawing.Size(77, 25);
			_cmdCertCommand_4.TabIndex = 193;
			_cmdCertCommand_4.Text = "Add Certificate";
			_cmdCertCommand_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdCertCommand_4.UseVisualStyleBackColor = false;
			_cmdCertCommand_4.Click += new System.EventHandler(cmdCertCommand_Click);
			// 
			// pnl_verify_aircraft_status
			// 
			pnl_verify_aircraft_status.AllowDrop = true;
			pnl_verify_aircraft_status.BackColor = System.Drawing.SystemColors.Control;
			pnl_verify_aircraft_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_verify_aircraft_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_verify_aircraft_status.Controls.Add(_chk_array_4);
			pnl_verify_aircraft_status.Controls.Add(_chk_array_3);
			pnl_verify_aircraft_status.Controls.Add(_chk_array_2);
			pnl_verify_aircraft_status.Controls.Add(_chk_array_1);
			pnl_verify_aircraft_status.Controls.Add(frame_options1);
			pnl_verify_aircraft_status.Controls.Add(_txt_market_note_3);
			pnl_verify_aircraft_status.Controls.Add(frm_marketing_note);
			pnl_verify_aircraft_status.Controls.Add(lst_aircraft);
			pnl_verify_aircraft_status.Controls.Add(_opt_verify_aircraft_5);
			pnl_verify_aircraft_status.Controls.Add(cmd_verify_status_save);
			pnl_verify_aircraft_status.Controls.Add(_cmd_verify_yacht_2);
			pnl_verify_aircraft_status.Controls.Add(frame_verify_pnl);
			pnl_verify_aircraft_status.Controls.Add(cbo_yachts);
			pnl_verify_aircraft_status.Controls.Add(_opt_verify_aircraft_4);
			pnl_verify_aircraft_status.Controls.Add(cbo_verify_note_type);
			pnl_verify_aircraft_status.Controls.Add(_opt_verify_aircraft_3);
			pnl_verify_aircraft_status.Controls.Add(_opt_verify_aircraft_2);
			pnl_verify_aircraft_status.Controls.Add(_opt_verify_aircraft_1);
			pnl_verify_aircraft_status.Controls.Add(_opt_verify_aircraft_0);
			pnl_verify_aircraft_status.Controls.Add(cbo_verify_aircraft);
			pnl_verify_aircraft_status.Controls.Add(chk_verify_contact);
			pnl_verify_aircraft_status.Controls.Add(cmd_verify_status_cancel);
			pnl_verify_aircraft_status.Controls.Add(cbo_verify_other_contacts);
			pnl_verify_aircraft_status.Controls.Add(_pic_verify_ac_1);
			pnl_verify_aircraft_status.Controls.Add(_pic_verify_ac_0);
			pnl_verify_aircraft_status.Controls.Add(_pic_verify_ac_3);
			pnl_verify_aircraft_status.Controls.Add(_pic_verify_ac_2);
			pnl_verify_aircraft_status.Controls.Add(cbo_verify_journal_auto_subject);
			pnl_verify_aircraft_status.Controls.Add(cbo_verify_journal_subject);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_104);
			pnl_verify_aircraft_status.Controls.Add(_Shape1_3);
			pnl_verify_aircraft_status.Controls.Add(_Shape1_2);
			pnl_verify_aircraft_status.Controls.Add(_Shape1_1);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_49);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_17);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_46);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_48);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_47);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_75);
			pnl_verify_aircraft_status.Controls.Add(_Shape1_0);
			pnl_verify_aircraft_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_verify_aircraft_status.Location = new System.Drawing.Point(264, 136);
			pnl_verify_aircraft_status.Name = "pnl_verify_aircraft_status";
			pnl_verify_aircraft_status.Size = new System.Drawing.Size(487, 394);
			pnl_verify_aircraft_status.TabIndex = 44;
			pnl_verify_aircraft_status.Visible = false;
			// 
			// _chk_array_4
			// 
			_chk_array_4.AllowDrop = true;
			_chk_array_4.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_array_4.BackColor = System.Drawing.SystemColors.Control;
			_chk_array_4.CausesValidation = true;
			_chk_array_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_array_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_array_4.Enabled = true;
			_chk_array_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_array_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_array_4.Location = new System.Drawing.Point(416, 240);
			_chk_array_4.Name = "_chk_array_4";
			_chk_array_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_array_4.Size = new System.Drawing.Size(55, 13);
			_chk_array_4.TabIndex = 233;
			_chk_array_4.TabStop = true;
			_chk_array_4.Text = "4th Q";
			_chk_array_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_array_4.Visible = false;
			_chk_array_4.CheckStateChanged += new System.EventHandler(chk_array_CheckStateChanged);
			// 
			// _chk_array_3
			// 
			_chk_array_3.AllowDrop = true;
			_chk_array_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_array_3.BackColor = System.Drawing.SystemColors.Control;
			_chk_array_3.CausesValidation = true;
			_chk_array_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_array_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_array_3.Enabled = true;
			_chk_array_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_array_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_array_3.Location = new System.Drawing.Point(416, 222);
			_chk_array_3.Name = "_chk_array_3";
			_chk_array_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_array_3.Size = new System.Drawing.Size(55, 13);
			_chk_array_3.TabIndex = 232;
			_chk_array_3.TabStop = true;
			_chk_array_3.Text = "3rd Q";
			_chk_array_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_array_3.Visible = false;
			_chk_array_3.CheckStateChanged += new System.EventHandler(chk_array_CheckStateChanged);
			// 
			// _chk_array_2
			// 
			_chk_array_2.AllowDrop = true;
			_chk_array_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_array_2.BackColor = System.Drawing.SystemColors.Control;
			_chk_array_2.CausesValidation = true;
			_chk_array_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_array_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_array_2.Enabled = true;
			_chk_array_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_array_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_array_2.Location = new System.Drawing.Point(416, 203);
			_chk_array_2.Name = "_chk_array_2";
			_chk_array_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_array_2.Size = new System.Drawing.Size(55, 13);
			_chk_array_2.TabIndex = 231;
			_chk_array_2.TabStop = true;
			_chk_array_2.Text = "2nd Q";
			_chk_array_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_array_2.Visible = false;
			_chk_array_2.CheckStateChanged += new System.EventHandler(chk_array_CheckStateChanged);
			// 
			// _chk_array_1
			// 
			_chk_array_1.AllowDrop = true;
			_chk_array_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_array_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_array_1.CausesValidation = true;
			_chk_array_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_array_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_array_1.Enabled = true;
			_chk_array_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_array_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_array_1.Location = new System.Drawing.Point(416, 184);
			_chk_array_1.Name = "_chk_array_1";
			_chk_array_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_array_1.Size = new System.Drawing.Size(55, 13);
			_chk_array_1.TabIndex = 230;
			_chk_array_1.TabStop = true;
			_chk_array_1.Text = "IQ";
			_chk_array_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_array_1.Visible = false;
			_chk_array_1.CheckStateChanged += new System.EventHandler(chk_array_CheckStateChanged);
			// 
			// frame_options1
			// 
			frame_options1.AllowDrop = true;
			frame_options1.BackColor = System.Drawing.SystemColors.Control;
			frame_options1.Controls.Add(_opt_journal_subject_1);
			frame_options1.Controls.Add(_opt_journal_subject_2);
			frame_options1.Controls.Add(_opt_journal_subject_3);
			frame_options1.Controls.Add(_opt_journal_subject_0);
			frame_options1.Controls.Add(_opt_journal_subject_4);
			frame_options1.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_options1.Enabled = true;
			frame_options1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_options1.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_options1.Location = new System.Drawing.Point(8, 8);
			frame_options1.Name = "frame_options1";
			frame_options1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_options1.Size = new System.Drawing.Size(153, 113);
			frame_options1.TabIndex = 224;
			frame_options1.Text = "Options";
			frame_options1.Visible = true;
			// 
			// _opt_journal_subject_1
			// 
			_opt_journal_subject_1.AllowDrop = true;
			_opt_journal_subject_1.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_1.CausesValidation = true;
			_opt_journal_subject_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_1.Checked = false;
			_opt_journal_subject_1.Enabled = true;
			_opt_journal_subject_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_journal_subject_1.Location = new System.Drawing.Point(10, 52);
			_opt_journal_subject_1.Name = "_opt_journal_subject_1";
			_opt_journal_subject_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_1.Size = new System.Drawing.Size(133, 19);
			_opt_journal_subject_1.TabIndex = 229;
			_opt_journal_subject_1.TabStop = true;
			_opt_journal_subject_1.Text = "Email Sent";
			_opt_journal_subject_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_1.Visible = true;
			_opt_journal_subject_1.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_2
			// 
			_opt_journal_subject_2.AllowDrop = true;
			_opt_journal_subject_2.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_2.CausesValidation = true;
			_opt_journal_subject_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_2.Checked = false;
			_opt_journal_subject_2.Enabled = true;
			_opt_journal_subject_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_journal_subject_2.Location = new System.Drawing.Point(10, 70);
			_opt_journal_subject_2.Name = "_opt_journal_subject_2";
			_opt_journal_subject_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_2.Size = new System.Drawing.Size(133, 19);
			_opt_journal_subject_2.TabIndex = 228;
			_opt_journal_subject_2.TabStop = true;
			_opt_journal_subject_2.Text = "Left Message";
			_opt_journal_subject_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_2.Visible = true;
			_opt_journal_subject_2.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_3
			// 
			_opt_journal_subject_3.AllowDrop = true;
			_opt_journal_subject_3.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_3.CausesValidation = true;
			_opt_journal_subject_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_3.Checked = true;
			_opt_journal_subject_3.Enabled = true;
			_opt_journal_subject_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_journal_subject_3.Location = new System.Drawing.Point(10, 88);
			_opt_journal_subject_3.Name = "_opt_journal_subject_3";
			_opt_journal_subject_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_3.Size = new System.Drawing.Size(133, 19);
			_opt_journal_subject_3.TabIndex = 227;
			_opt_journal_subject_3.TabStop = true;
			_opt_journal_subject_3.Text = "Custom Note";
			_opt_journal_subject_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_3.Visible = true;
			_opt_journal_subject_3.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_0
			// 
			_opt_journal_subject_0.AllowDrop = true;
			_opt_journal_subject_0.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_0.CausesValidation = true;
			_opt_journal_subject_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_0.Checked = false;
			_opt_journal_subject_0.Enabled = true;
			_opt_journal_subject_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_journal_subject_0.Location = new System.Drawing.Point(10, 34);
			_opt_journal_subject_0.Name = "_opt_journal_subject_0";
			_opt_journal_subject_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_0.Size = new System.Drawing.Size(133, 19);
			_opt_journal_subject_0.TabIndex = 226;
			_opt_journal_subject_0.TabStop = true;
			_opt_journal_subject_0.Text = "Still has Shares Per";
			_opt_journal_subject_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_0.Visible = true;
			_opt_journal_subject_0.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_4
			// 
			_opt_journal_subject_4.AllowDrop = true;
			_opt_journal_subject_4.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_4.CausesValidation = true;
			_opt_journal_subject_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_4.Checked = false;
			_opt_journal_subject_4.Enabled = true;
			_opt_journal_subject_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_journal_subject_4.Location = new System.Drawing.Point(8, 16);
			_opt_journal_subject_4.Name = "_opt_journal_subject_4";
			_opt_journal_subject_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_4.Size = new System.Drawing.Size(133, 19);
			_opt_journal_subject_4.TabIndex = 225;
			_opt_journal_subject_4.TabStop = true;
			_opt_journal_subject_4.Text = "Confirmed info per";
			_opt_journal_subject_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_4.Visible = true;
			_opt_journal_subject_4.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _txt_market_note_3
			// 
			_txt_market_note_3.AcceptsReturn = true;
			_txt_market_note_3.AllowDrop = true;
			_txt_market_note_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_market_note_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_market_note_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_market_note_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_market_note_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_market_note_3.Location = new System.Drawing.Point(168, 80);
			_txt_market_note_3.MaxLength = 0;
			_txt_market_note_3.Multiline = true;
			_txt_market_note_3.Name = "_txt_market_note_3";
			_txt_market_note_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_market_note_3.Size = new System.Drawing.Size(303, 45);
			_txt_market_note_3.TabIndex = 199;
			_txt_market_note_3.DoubleClick += new System.EventHandler(txt_market_note_DoubleClick);
			_txt_market_note_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_market_note_KeyPress);
			_txt_market_note_3.TextChanged += new System.EventHandler(txt_market_note_TextChanged);
			// 
			// frm_marketing_note
			// 
			frm_marketing_note.AllowDrop = true;
			frm_marketing_note.BackColor = System.Drawing.SystemColors.Control;
			frm_marketing_note.Controls.Add(txt_marketing_notes);
			frm_marketing_note.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_marketing_note.Enabled = true;
			frm_marketing_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_marketing_note.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_marketing_note.Location = new System.Drawing.Point(8, 264);
			frm_marketing_note.Name = "frm_marketing_note";
			frm_marketing_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_marketing_note.Size = new System.Drawing.Size(473, 99);
			frm_marketing_note.TabIndex = 160;
			frm_marketing_note.Text = "Marketing Notes";
			frm_marketing_note.Visible = false;
			// 
			// txt_marketing_notes
			// 
			txt_marketing_notes.AcceptsReturn = true;
			txt_marketing_notes.AllowDrop = true;
			txt_marketing_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_marketing_notes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_marketing_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_marketing_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_marketing_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_marketing_notes.Location = new System.Drawing.Point(8, 16);
			txt_marketing_notes.MaxLength = 0;
			txt_marketing_notes.Multiline = true;
			txt_marketing_notes.Name = "txt_marketing_notes";
			txt_marketing_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_marketing_notes.Size = new System.Drawing.Size(463, 79);
			txt_marketing_notes.TabIndex = 161;
			// 
			// lst_aircraft
			// 
			lst_aircraft.AllowDrop = true;
			lst_aircraft.BackColor = System.Drawing.SystemColors.Window;
			lst_aircraft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lst_aircraft.CausesValidation = true;
			lst_aircraft.Enabled = true;
			lst_aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_aircraft.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_aircraft.IntegralHeight = true;
			lst_aircraft.Location = new System.Drawing.Point(14, 304);
			lst_aircraft.MultiColumn = false;
			lst_aircraft.Name = "lst_aircraft";
			lst_aircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_aircraft.Size = new System.Drawing.Size(457, 59);
			lst_aircraft.Sorted = false;
			lst_aircraft.TabIndex = 195;
			lst_aircraft.TabStop = true;
			lst_aircraft.Visible = false;
			lst_aircraft.MouseDown += new System.Windows.Forms.MouseEventHandler(lst_Aircraft_MouseDown);
			// 
			// _opt_verify_aircraft_5
			// 
			_opt_verify_aircraft_5.AllowDrop = true;
			_opt_verify_aircraft_5.BackColor = System.Drawing.SystemColors.Control;
			_opt_verify_aircraft_5.CausesValidation = true;
			_opt_verify_aircraft_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_verify_aircraft_5.Checked = false;
			_opt_verify_aircraft_5.Enabled = true;
			_opt_verify_aircraft_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_verify_aircraft_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_verify_aircraft_5.Location = new System.Drawing.Point(108, 272);
			_opt_verify_aircraft_5.Name = "_opt_verify_aircraft_5";
			_opt_verify_aircraft_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_verify_aircraft_5.Size = new System.Drawing.Size(67, 13);
			_opt_verify_aircraft_5.TabIndex = 194;
			_opt_verify_aircraft_5.TabStop = true;
			_opt_verify_aircraft_5.Text = "Select AC";
			_opt_verify_aircraft_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_verify_aircraft_5.Visible = false;
			_opt_verify_aircraft_5.CheckedChanged += new System.EventHandler(opt_verify_aircraft_CheckedChanged);
			// 
			// cmd_verify_status_save
			// 
			cmd_verify_status_save.AllowDrop = true;
			cmd_verify_status_save.BackColor = System.Drawing.SystemColors.Control;
			cmd_verify_status_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_verify_status_save.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_verify_status_save.Location = new System.Drawing.Point(328, 362);
			cmd_verify_status_save.Name = "cmd_verify_status_save";
			cmd_verify_status_save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_verify_status_save.Size = new System.Drawing.Size(64, 24);
			cmd_verify_status_save.TabIndex = 53;
			cmd_verify_status_save.Text = "&Save";
			cmd_verify_status_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_verify_status_save.UseVisualStyleBackColor = false;
			cmd_verify_status_save.Click += new System.EventHandler(cmd_verify_status_save_Click);
			cmd_verify_status_save.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_verify_status_save_MouseUp);
			// 
			// _cmd_verify_yacht_2
			// 
			_cmd_verify_yacht_2.AllowDrop = true;
			_cmd_verify_yacht_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_verify_yacht_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_verify_yacht_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_verify_yacht_2.Location = new System.Drawing.Point(336, 362);
			_cmd_verify_yacht_2.Name = "_cmd_verify_yacht_2";
			_cmd_verify_yacht_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_verify_yacht_2.Size = new System.Drawing.Size(64, 24);
			_cmd_verify_yacht_2.TabIndex = 173;
			_cmd_verify_yacht_2.Text = "Save";
			_cmd_verify_yacht_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_verify_yacht_2.UseVisualStyleBackColor = false;
			_cmd_verify_yacht_2.Visible = false;
			_cmd_verify_yacht_2.Click += new System.EventHandler(cmd_verify_yacht_Click);
			// 
			// frame_verify_pnl
			// 
			frame_verify_pnl.AllowDrop = true;
			frame_verify_pnl.BackColor = System.Drawing.SystemColors.Control;
			frame_verify_pnl.Controls.Add(_opt_journal_subject_12);
			frame_verify_pnl.Controls.Add(_opt_journal_subject_13);
			frame_verify_pnl.Controls.Add(_opt_journal_subject_11);
			frame_verify_pnl.Controls.Add(_opt_journal_subject_10);
			frame_verify_pnl.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_verify_pnl.Enabled = true;
			frame_verify_pnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_verify_pnl.ForeColor = System.Drawing.SystemColors.WindowText;
			frame_verify_pnl.Location = new System.Drawing.Point(-348, 64);
			frame_verify_pnl.Name = "frame_verify_pnl";
			frame_verify_pnl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_verify_pnl.Size = new System.Drawing.Size(144, 80);
			frame_verify_pnl.TabIndex = 136;
			frame_verify_pnl.Visible = true;
			// 
			// _opt_journal_subject_12
			// 
			_opt_journal_subject_12.AllowDrop = true;
			_opt_journal_subject_12.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_12.CausesValidation = true;
			_opt_journal_subject_12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_12.Checked = false;
			_opt_journal_subject_12.Enabled = true;
			_opt_journal_subject_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_12.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_journal_subject_12.Location = new System.Drawing.Point(4, 11);
			_opt_journal_subject_12.Name = "_opt_journal_subject_12";
			_opt_journal_subject_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_12.Size = new System.Drawing.Size(134, 13);
			_opt_journal_subject_12.TabIndex = 140;
			_opt_journal_subject_12.TabStop = true;
			_opt_journal_subject_12.Text = "Still has Shares Per ";
			_opt_journal_subject_12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_12.Visible = false;
			_opt_journal_subject_12.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_13
			// 
			_opt_journal_subject_13.AllowDrop = true;
			_opt_journal_subject_13.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_13.CausesValidation = true;
			_opt_journal_subject_13.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_13.Checked = true;
			_opt_journal_subject_13.Enabled = true;
			_opt_journal_subject_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_13.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_journal_subject_13.Location = new System.Drawing.Point(4, 62);
			_opt_journal_subject_13.Name = "_opt_journal_subject_13";
			_opt_journal_subject_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_13.Size = new System.Drawing.Size(134, 13);
			_opt_journal_subject_13.TabIndex = 139;
			_opt_journal_subject_13.TabStop = true;
			_opt_journal_subject_13.Text = "Custom Note";
			_opt_journal_subject_13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_13.Visible = true;
			_opt_journal_subject_13.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_11
			// 
			_opt_journal_subject_11.AllowDrop = true;
			_opt_journal_subject_11.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_11.CausesValidation = true;
			_opt_journal_subject_11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_11.Checked = false;
			_opt_journal_subject_11.Enabled = true;
			_opt_journal_subject_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_11.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_journal_subject_11.Location = new System.Drawing.Point(4, 45);
			_opt_journal_subject_11.Name = "_opt_journal_subject_11";
			_opt_journal_subject_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_11.Size = new System.Drawing.Size(134, 13);
			_opt_journal_subject_11.TabIndex = 138;
			_opt_journal_subject_11.TabStop = true;
			_opt_journal_subject_11.Text = "Left Message";
			_opt_journal_subject_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_11.Visible = true;
			_opt_journal_subject_11.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_10
			// 
			_opt_journal_subject_10.AllowDrop = true;
			_opt_journal_subject_10.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_10.CausesValidation = true;
			_opt_journal_subject_10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_10.Checked = false;
			_opt_journal_subject_10.Enabled = true;
			_opt_journal_subject_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_10.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_journal_subject_10.Location = new System.Drawing.Point(4, 28);
			_opt_journal_subject_10.Name = "_opt_journal_subject_10";
			_opt_journal_subject_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_10.Size = new System.Drawing.Size(134, 13);
			_opt_journal_subject_10.TabIndex = 137;
			_opt_journal_subject_10.TabStop = true;
			_opt_journal_subject_10.Text = "Letter Sent";
			_opt_journal_subject_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_10.Visible = true;
			_opt_journal_subject_10.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// cbo_yachts
			// 
			cbo_yachts.AllowDrop = true;
			cbo_yachts.BackColor = System.Drawing.SystemColors.Window;
			cbo_yachts.CausesValidation = true;
			cbo_yachts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_yachts.Enabled = true;
			cbo_yachts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_yachts.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_yachts.IntegralHeight = true;
			cbo_yachts.Location = new System.Drawing.Point(18, 328);
			cbo_yachts.Name = "cbo_yachts";
			cbo_yachts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_yachts.Size = new System.Drawing.Size(449, 21);
			cbo_yachts.Sorted = false;
			cbo_yachts.TabIndex = 159;
			cbo_yachts.TabStop = true;
			cbo_yachts.Text = "cbo_yachts";
			cbo_yachts.Visible = false;
			// 
			// _opt_verify_aircraft_4
			// 
			_opt_verify_aircraft_4.AllowDrop = true;
			_opt_verify_aircraft_4.BackColor = System.Drawing.SystemColors.Control;
			_opt_verify_aircraft_4.CausesValidation = true;
			_opt_verify_aircraft_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_verify_aircraft_4.Checked = false;
			_opt_verify_aircraft_4.Enabled = true;
			_opt_verify_aircraft_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_verify_aircraft_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_verify_aircraft_4.Location = new System.Drawing.Point(392, 292);
			_opt_verify_aircraft_4.Name = "_opt_verify_aircraft_4";
			_opt_verify_aircraft_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_verify_aircraft_4.Size = new System.Drawing.Size(55, 13);
			_opt_verify_aircraft_4.TabIndex = 158;
			_opt_verify_aircraft_4.TabStop = true;
			_opt_verify_aircraft_4.Text = "Yacht";
			_opt_verify_aircraft_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_verify_aircraft_4.Visible = false;
			_opt_verify_aircraft_4.CheckedChanged += new System.EventHandler(opt_verify_aircraft_CheckedChanged);
			// 
			// cbo_verify_note_type
			// 
			cbo_verify_note_type.AllowDrop = true;
			cbo_verify_note_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_verify_note_type.CausesValidation = true;
			cbo_verify_note_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_verify_note_type.Enabled = true;
			cbo_verify_note_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_verify_note_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_verify_note_type.IntegralHeight = true;
			cbo_verify_note_type.Location = new System.Drawing.Point(96, 152);
			cbo_verify_note_type.Name = "cbo_verify_note_type";
			cbo_verify_note_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_verify_note_type.Size = new System.Drawing.Size(376, 21);
			cbo_verify_note_type.Sorted = false;
			cbo_verify_note_type.TabIndex = 65;
			cbo_verify_note_type.TabStop = true;
			cbo_verify_note_type.Visible = true;
			cbo_verify_note_type.SelectedIndexChanged += new System.EventHandler(cbo_verify_note_type_SelectedIndexChanged);
			// 
			// _opt_verify_aircraft_3
			// 
			_opt_verify_aircraft_3.AllowDrop = true;
			_opt_verify_aircraft_3.BackColor = System.Drawing.SystemColors.Control;
			_opt_verify_aircraft_3.CausesValidation = true;
			_opt_verify_aircraft_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_verify_aircraft_3.Checked = false;
			_opt_verify_aircraft_3.Enabled = true;
			_opt_verify_aircraft_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_verify_aircraft_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_verify_aircraft_3.Location = new System.Drawing.Point(286, 292);
			_opt_verify_aircraft_3.Name = "_opt_verify_aircraft_3";
			_opt_verify_aircraft_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_verify_aircraft_3.Size = new System.Drawing.Size(79, 13);
			_opt_verify_aircraft_3.TabIndex = 50;
			_opt_verify_aircraft_3.TabStop = true;
			_opt_verify_aircraft_3.Text = "Primary Only";
			_opt_verify_aircraft_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_verify_aircraft_3.Visible = false;
			_opt_verify_aircraft_3.CheckedChanged += new System.EventHandler(opt_verify_aircraft_CheckedChanged);
			// 
			// _opt_verify_aircraft_2
			// 
			_opt_verify_aircraft_2.AllowDrop = true;
			_opt_verify_aircraft_2.BackColor = System.Drawing.SystemColors.Control;
			_opt_verify_aircraft_2.CausesValidation = true;
			_opt_verify_aircraft_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_verify_aircraft_2.Checked = false;
			_opt_verify_aircraft_2.Enabled = true;
			_opt_verify_aircraft_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_verify_aircraft_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_verify_aircraft_2.Location = new System.Drawing.Point(195, 292);
			_opt_verify_aircraft_2.Name = "_opt_verify_aircraft_2";
			_opt_verify_aircraft_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_verify_aircraft_2.Size = new System.Drawing.Size(71, 13);
			_opt_verify_aircraft_2.TabIndex = 49;
			_opt_verify_aircraft_2.TabStop = true;
			_opt_verify_aircraft_2.Text = "All Aircraft";
			_opt_verify_aircraft_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_verify_aircraft_2.Visible = false;
			_opt_verify_aircraft_2.CheckedChanged += new System.EventHandler(opt_verify_aircraft_CheckedChanged);
			// 
			// _opt_verify_aircraft_1
			// 
			_opt_verify_aircraft_1.AllowDrop = true;
			_opt_verify_aircraft_1.BackColor = System.Drawing.SystemColors.Control;
			_opt_verify_aircraft_1.CausesValidation = true;
			_opt_verify_aircraft_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_verify_aircraft_1.Checked = false;
			_opt_verify_aircraft_1.Enabled = true;
			_opt_verify_aircraft_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_verify_aircraft_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_verify_aircraft_1.Location = new System.Drawing.Point(105, 292);
			_opt_verify_aircraft_1.Name = "_opt_verify_aircraft_1";
			_opt_verify_aircraft_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_verify_aircraft_1.Size = new System.Drawing.Size(71, 13);
			_opt_verify_aircraft_1.TabIndex = 48;
			_opt_verify_aircraft_1.TabStop = true;
			_opt_verify_aircraft_1.Text = "Aircraft";
			_opt_verify_aircraft_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_verify_aircraft_1.Visible = false;
			_opt_verify_aircraft_1.CheckedChanged += new System.EventHandler(opt_verify_aircraft_CheckedChanged);
			// 
			// _opt_verify_aircraft_0
			// 
			_opt_verify_aircraft_0.AllowDrop = true;
			_opt_verify_aircraft_0.BackColor = System.Drawing.SystemColors.Control;
			_opt_verify_aircraft_0.CausesValidation = true;
			_opt_verify_aircraft_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_verify_aircraft_0.Checked = false;
			_opt_verify_aircraft_0.Enabled = true;
			_opt_verify_aircraft_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_verify_aircraft_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_verify_aircraft_0.Location = new System.Drawing.Point(14, 292);
			_opt_verify_aircraft_0.Name = "_opt_verify_aircraft_0";
			_opt_verify_aircraft_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_verify_aircraft_0.Size = new System.Drawing.Size(71, 13);
			_opt_verify_aircraft_0.TabIndex = 47;
			_opt_verify_aircraft_0.TabStop = true;
			_opt_verify_aircraft_0.Text = "No Aircraft";
			_opt_verify_aircraft_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_verify_aircraft_0.Visible = false;
			_opt_verify_aircraft_0.CheckedChanged += new System.EventHandler(opt_verify_aircraft_CheckedChanged);
			// 
			// cbo_verify_aircraft
			// 
			cbo_verify_aircraft.AllowDrop = true;
			cbo_verify_aircraft.BackColor = System.Drawing.SystemColors.Window;
			cbo_verify_aircraft.CausesValidation = true;
			cbo_verify_aircraft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_verify_aircraft.Enabled = true;
			cbo_verify_aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_verify_aircraft.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_verify_aircraft.IntegralHeight = true;
			cbo_verify_aircraft.Location = new System.Drawing.Point(16, 306);
			cbo_verify_aircraft.Name = "cbo_verify_aircraft";
			cbo_verify_aircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_verify_aircraft.Size = new System.Drawing.Size(455, 21);
			cbo_verify_aircraft.Sorted = false;
			cbo_verify_aircraft.TabIndex = 51;
			cbo_verify_aircraft.TabStop = true;
			cbo_verify_aircraft.Visible = false;
			cbo_verify_aircraft.SelectedIndexChanged += new System.EventHandler(cbo_verify_aircraft_SelectedIndexChanged);
			// 
			// chk_verify_contact
			// 
			chk_verify_contact.AllowDrop = true;
			chk_verify_contact.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_verify_contact.BackColor = System.Drawing.SystemColors.Control;
			chk_verify_contact.CausesValidation = true;
			chk_verify_contact.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_verify_contact.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_verify_contact.Enabled = true;
			chk_verify_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_verify_contact.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_verify_contact.Location = new System.Drawing.Point(98, 212);
			chk_verify_contact.Name = "chk_verify_contact";
			chk_verify_contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_verify_contact.Size = new System.Drawing.Size(77, 13);
			chk_verify_contact.TabIndex = 45;
			chk_verify_contact.TabStop = true;
			chk_verify_contact.Text = "Contact?";
			chk_verify_contact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_verify_contact.Visible = false;
			chk_verify_contact.CheckStateChanged += new System.EventHandler(chk_verify_contact_CheckStateChanged);
			// 
			// cmd_verify_status_cancel
			// 
			cmd_verify_status_cancel.AllowDrop = true;
			cmd_verify_status_cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_verify_status_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_verify_status_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_verify_status_cancel.Location = new System.Drawing.Point(411, 362);
			cmd_verify_status_cancel.Name = "cmd_verify_status_cancel";
			cmd_verify_status_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_verify_status_cancel.Size = new System.Drawing.Size(64, 24);
			cmd_verify_status_cancel.TabIndex = 54;
			cmd_verify_status_cancel.Text = "&Cancel";
			cmd_verify_status_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_verify_status_cancel.UseVisualStyleBackColor = false;
			cmd_verify_status_cancel.Click += new System.EventHandler(cmd_verify_status_cancel_Click);
			cmd_verify_status_cancel.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_verify_status_cancel_MouseUp);
			// 
			// cbo_verify_other_contacts
			// 
			cbo_verify_other_contacts.AllowDrop = true;
			cbo_verify_other_contacts.BackColor = System.Drawing.SystemColors.Window;
			cbo_verify_other_contacts.CausesValidation = true;
			cbo_verify_other_contacts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_verify_other_contacts.Enabled = true;
			cbo_verify_other_contacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_verify_other_contacts.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_verify_other_contacts.IntegralHeight = true;
			cbo_verify_other_contacts.Location = new System.Drawing.Point(150, 228);
			cbo_verify_other_contacts.Name = "cbo_verify_other_contacts";
			cbo_verify_other_contacts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_verify_other_contacts.Size = new System.Drawing.Size(245, 21);
			cbo_verify_other_contacts.Sorted = false;
			cbo_verify_other_contacts.TabIndex = 46;
			cbo_verify_other_contacts.TabStop = true;
			cbo_verify_other_contacts.Text = "cbo_verify_other_contacts";
			cbo_verify_other_contacts.Visible = true;
			cbo_verify_other_contacts.SelectionChangeCommitted += new System.EventHandler(cbo_verify_other_contacts_SelectionChangeCommitted);
			// 
			// _pic_verify_ac_1
			// 
			_pic_verify_ac_1.AllowDrop = true;
			_pic_verify_ac_1.BackColor = System.Drawing.SystemColors.Window;
			_pic_verify_ac_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_pic_verify_ac_1.CausesValidation = true;
			_pic_verify_ac_1.Dock = System.Windows.Forms.DockStyle.None;
			_pic_verify_ac_1.Enabled = true;
			_pic_verify_ac_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_verify_ac_1.Image = (System.Drawing.Image) resources.GetObject("_pic_verify_ac_1.Image");
			_pic_verify_ac_1.Location = new System.Drawing.Point(438, 8);
			_pic_verify_ac_1.Name = "_pic_verify_ac_1";
			_pic_verify_ac_1.Size = new System.Drawing.Size(31, 24);
			_pic_verify_ac_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_verify_ac_1.TabIndex = 71;
			_pic_verify_ac_1.TabStop = true;
			_pic_verify_ac_1.Visible = false;
			// 
			// _pic_verify_ac_0
			// 
			_pic_verify_ac_0.AllowDrop = true;
			_pic_verify_ac_0.BackColor = System.Drawing.SystemColors.Window;
			_pic_verify_ac_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_pic_verify_ac_0.CausesValidation = true;
			_pic_verify_ac_0.Dock = System.Windows.Forms.DockStyle.None;
			_pic_verify_ac_0.Enabled = true;
			_pic_verify_ac_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_verify_ac_0.Image = (System.Drawing.Image) resources.GetObject("_pic_verify_ac_0.Image");
			_pic_verify_ac_0.Location = new System.Drawing.Point(438, 8);
			_pic_verify_ac_0.Name = "_pic_verify_ac_0";
			_pic_verify_ac_0.Size = new System.Drawing.Size(31, 24);
			_pic_verify_ac_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_verify_ac_0.TabIndex = 70;
			_pic_verify_ac_0.TabStop = true;
			_pic_verify_ac_0.Visible = false;
			// 
			// _pic_verify_ac_3
			// 
			_pic_verify_ac_3.AllowDrop = true;
			_pic_verify_ac_3.BackColor = System.Drawing.SystemColors.Window;
			_pic_verify_ac_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_pic_verify_ac_3.CausesValidation = true;
			_pic_verify_ac_3.Dock = System.Windows.Forms.DockStyle.None;
			_pic_verify_ac_3.Enabled = true;
			_pic_verify_ac_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_verify_ac_3.Image = (System.Drawing.Image) resources.GetObject("_pic_verify_ac_3.Image");
			_pic_verify_ac_3.Location = new System.Drawing.Point(438, 8);
			_pic_verify_ac_3.Name = "_pic_verify_ac_3";
			_pic_verify_ac_3.Size = new System.Drawing.Size(31, 24);
			_pic_verify_ac_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_verify_ac_3.TabIndex = 73;
			_pic_verify_ac_3.TabStop = true;
			_pic_verify_ac_3.Visible = false;
			// 
			// _pic_verify_ac_2
			// 
			_pic_verify_ac_2.AllowDrop = true;
			_pic_verify_ac_2.BackColor = System.Drawing.SystemColors.Window;
			_pic_verify_ac_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_pic_verify_ac_2.CausesValidation = true;
			_pic_verify_ac_2.Dock = System.Windows.Forms.DockStyle.None;
			_pic_verify_ac_2.Enabled = true;
			_pic_verify_ac_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_verify_ac_2.Image = (System.Drawing.Image) resources.GetObject("_pic_verify_ac_2.Image");
			_pic_verify_ac_2.Location = new System.Drawing.Point(438, 8);
			_pic_verify_ac_2.Name = "_pic_verify_ac_2";
			_pic_verify_ac_2.Size = new System.Drawing.Size(31, 24);
			_pic_verify_ac_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_verify_ac_2.TabIndex = 72;
			_pic_verify_ac_2.TabStop = true;
			_pic_verify_ac_2.Visible = false;
			// 
			// cbo_verify_journal_auto_subject
			// 
			cbo_verify_journal_auto_subject.AllowDrop = true;
			cbo_verify_journal_auto_subject.BackColor = System.Drawing.SystemColors.Window;
			cbo_verify_journal_auto_subject.CausesValidation = true;
			cbo_verify_journal_auto_subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_verify_journal_auto_subject.Enabled = true;
			cbo_verify_journal_auto_subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_verify_journal_auto_subject.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_verify_journal_auto_subject.IntegralHeight = true;
			cbo_verify_journal_auto_subject.Location = new System.Drawing.Point(168, 40);
			cbo_verify_journal_auto_subject.Name = "cbo_verify_journal_auto_subject";
			cbo_verify_journal_auto_subject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_verify_journal_auto_subject.Size = new System.Drawing.Size(303, 21);
			cbo_verify_journal_auto_subject.Sorted = false;
			cbo_verify_journal_auto_subject.TabIndex = 174;
			cbo_verify_journal_auto_subject.TabStop = true;
			cbo_verify_journal_auto_subject.Text = "cbo_verify_journal_auto_subject";
			cbo_verify_journal_auto_subject.Visible = false;
			cbo_verify_journal_auto_subject.SelectionChangeCommitted += new System.EventHandler(cbo_verify_journal_auto_subject_SelectionChangeCommitted);
			// 
			// cbo_verify_journal_subject
			// 
			cbo_verify_journal_subject.AllowDrop = true;
			cbo_verify_journal_subject.BackColor = System.Drawing.SystemColors.Window;
			cbo_verify_journal_subject.CausesValidation = true;
			cbo_verify_journal_subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			cbo_verify_journal_subject.Enabled = true;
			cbo_verify_journal_subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_verify_journal_subject.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_verify_journal_subject.IntegralHeight = true;
			cbo_verify_journal_subject.Location = new System.Drawing.Point(168, 40);
			cbo_verify_journal_subject.Name = "cbo_verify_journal_subject";
			cbo_verify_journal_subject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_verify_journal_subject.Size = new System.Drawing.Size(303, 21);
			cbo_verify_journal_subject.Sorted = false;
			cbo_verify_journal_subject.TabIndex = 135;
			cbo_verify_journal_subject.TabStop = true;
			cbo_verify_journal_subject.Text = "cbo_verify_journal_subject";
			cbo_verify_journal_subject.Visible = true;
			cbo_verify_journal_subject.SelectedIndexChanged += new System.EventHandler(cbo_verify_journal_subject_SelectedIndexChanged);
			// 
			// _lbl_comp_104
			// 
			_lbl_comp_104.AllowDrop = true;
			_lbl_comp_104.AutoSize = true;
			_lbl_comp_104.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_104.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_104.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_104.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_104.Location = new System.Drawing.Point(168, 64);
			_lbl_comp_104.MinimumSize = new System.Drawing.Size(69, 13);
			_lbl_comp_104.Name = "_lbl_comp_104";
			_lbl_comp_104.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_104.Size = new System.Drawing.Size(69, 13);
			_lbl_comp_104.TabIndex = 200;
			_lbl_comp_104.Text = "Description:";
			_lbl_comp_104.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_104.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_104.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _Shape1_3
			// 
			_Shape1_3.AllowDrop = true;
			_Shape1_3.BackColor = System.Drawing.SystemColors.Window;
			_Shape1_3.BackStyle = 0;
			_Shape1_3.BorderStyle = 1;
			_Shape1_3.Enabled = false;
			_Shape1_3.FillColor = System.Drawing.Color.Black;
			_Shape1_3.FillStyle = 1;
			_Shape1_3.Location = new System.Drawing.Point(2, 6);
			_Shape1_3.Name = "_Shape1_3";
			_Shape1_3.Size = new System.Drawing.Size(161, 114);
			_Shape1_3.Visible = true;
			// 
			// _Shape1_2
			// 
			_Shape1_2.AllowDrop = true;
			_Shape1_2.BackColor = System.Drawing.SystemColors.Window;
			_Shape1_2.BackStyle = 0;
			_Shape1_2.BorderStyle = 1;
			_Shape1_2.Enabled = false;
			_Shape1_2.FillColor = System.Drawing.Color.Black;
			_Shape1_2.FillStyle = 1;
			_Shape1_2.Location = new System.Drawing.Point(8, 268);
			_Shape1_2.Name = "_Shape1_2";
			_Shape1_2.Size = new System.Drawing.Size(469, 92);
			_Shape1_2.Visible = true;
			// 
			// _Shape1_1
			// 
			_Shape1_1.AllowDrop = true;
			_Shape1_1.BackColor = System.Drawing.SystemColors.Window;
			_Shape1_1.BackStyle = 0;
			_Shape1_1.BorderStyle = 1;
			_Shape1_1.Enabled = false;
			_Shape1_1.FillColor = System.Drawing.Color.Black;
			_Shape1_1.FillStyle = 1;
			_Shape1_1.Location = new System.Drawing.Point(88, 184);
			_Shape1_1.Name = "_Shape1_1";
			_Shape1_1.Size = new System.Drawing.Size(312, 74);
			_Shape1_1.Visible = true;
			// 
			// _lbl_comp_49
			// 
			_lbl_comp_49.AllowDrop = true;
			_lbl_comp_49.AutoSize = true;
			_lbl_comp_49.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_49.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_49.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_49.Location = new System.Drawing.Point(168, 24);
			_lbl_comp_49.MinimumSize = new System.Drawing.Size(48, 13);
			_lbl_comp_49.Name = "_lbl_comp_49";
			_lbl_comp_49.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_49.Size = new System.Drawing.Size(48, 13);
			_lbl_comp_49.TabIndex = 84;
			_lbl_comp_49.Text = "Subject:";
			_lbl_comp_49.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_49.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_49.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_17
			// 
			_lbl_comp_17.AllowDrop = true;
			_lbl_comp_17.AutoSize = true;
			_lbl_comp_17.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_17.Location = new System.Drawing.Point(12, 158);
			_lbl_comp_17.MinimumSize = new System.Drawing.Size(81, 13);
			_lbl_comp_17.Name = "_lbl_comp_17";
			_lbl_comp_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_17.Size = new System.Drawing.Size(81, 13);
			_lbl_comp_17.TabIndex = 66;
			_lbl_comp_17.Text = "Type of Note:";
			_lbl_comp_17.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_17.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_17.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_46
			// 
			_lbl_comp_46.AllowDrop = true;
			_lbl_comp_46.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_46.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_46.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_46.Location = new System.Drawing.Point(16, 274);
			_lbl_comp_46.MinimumSize = new System.Drawing.Size(461, 13);
			_lbl_comp_46.Name = "_lbl_comp_46";
			_lbl_comp_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_46.Size = new System.Drawing.Size(461, 13);
			_lbl_comp_46.TabIndex = 57;
			_lbl_comp_46.Text = "Add this note to:";
			_lbl_comp_46.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_46.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_46.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_46.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_48
			// 
			_lbl_comp_48.AllowDrop = true;
			_lbl_comp_48.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_48.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_48.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_48.Location = new System.Drawing.Point(104, 200);
			_lbl_comp_48.MinimumSize = new System.Drawing.Size(297, 13);
			_lbl_comp_48.Name = "_lbl_comp_48";
			_lbl_comp_48.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_48.Size = new System.Drawing.Size(297, 13);
			_lbl_comp_48.TabIndex = 56;
			_lbl_comp_48.Tag = "lbl_AddThisNoteTo";
			_lbl_comp_48.Text = "Add this note to:";
			_lbl_comp_48.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_48.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_48.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_48.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_47
			// 
			_lbl_comp_47.AllowDrop = true;
			_lbl_comp_47.AutoSize = true;
			_lbl_comp_47.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_47.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_47.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_47.Location = new System.Drawing.Point(98, 232);
			_lbl_comp_47.MinimumSize = new System.Drawing.Size(49, 13);
			_lbl_comp_47.Name = "_lbl_comp_47";
			_lbl_comp_47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_47.Size = new System.Drawing.Size(49, 13);
			_lbl_comp_47.TabIndex = 55;
			_lbl_comp_47.Tag = "lbl_options";
			_lbl_comp_47.Text = "Contact:";
			_lbl_comp_47.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_47.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_47.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _lbl_comp_75
			// 
			_lbl_comp_75.AllowDrop = true;
			_lbl_comp_75.BackColor = System.Drawing.SystemColors.Window;
			_lbl_comp_75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_comp_75.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_75.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_comp_75.Location = new System.Drawing.Point(13, 132);
			_lbl_comp_75.MinimumSize = new System.Drawing.Size(460, 17);
			_lbl_comp_75.Name = "_lbl_comp_75";
			_lbl_comp_75.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_75.Size = new System.Drawing.Size(460, 17);
			_lbl_comp_75.TabIndex = 52;
			_lbl_comp_75.Tag = "N";
			_lbl_comp_75.Text = "Label75";
			_lbl_comp_75.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_75.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_75.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_75.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// _Shape1_0
			// 
			_Shape1_0.AllowDrop = true;
			_Shape1_0.BackColor = System.Drawing.SystemColors.Window;
			_Shape1_0.BackStyle = 0;
			_Shape1_0.BorderStyle = 1;
			_Shape1_0.Enabled = false;
			_Shape1_0.FillColor = System.Drawing.Color.Black;
			_Shape1_0.FillStyle = 1;
			_Shape1_0.Location = new System.Drawing.Point(8, 152);
			_Shape1_0.Name = "_Shape1_0";
			_Shape1_0.Size = new System.Drawing.Size(471, 110);
			_Shape1_0.Visible = true;
			// 
			// pnl_update_message
			// 
			pnl_update_message.AllowDrop = true;
			pnl_update_message.BackColor = System.Drawing.SystemColors.Control;
			pnl_update_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_update_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_update_message.Controls.Add(_lbl_comp_40);
			pnl_update_message.Font = new System.Drawing.Font("Tahoma", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_update_message.Location = new System.Drawing.Point(246, 291);
			pnl_update_message.Name = "pnl_update_message";
			pnl_update_message.Size = new System.Drawing.Size(521, 120);
			pnl_update_message.TabIndex = 58;
			pnl_update_message.Visible = false;
			// 
			// _lbl_comp_40
			// 
			_lbl_comp_40.AllowDrop = true;
			_lbl_comp_40.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_40.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_40.ForeColor = System.Drawing.Color.Maroon;
			_lbl_comp_40.Location = new System.Drawing.Point(183, 55);
			_lbl_comp_40.MinimumSize = new System.Drawing.Size(153, 27);
			_lbl_comp_40.Name = "_lbl_comp_40";
			_lbl_comp_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_40.Size = new System.Drawing.Size(153, 27);
			_lbl_comp_40.TabIndex = 83;
			_lbl_comp_40.Tag = "N";
			_lbl_comp_40.Text = "PLEASE WAIT!";
			_lbl_comp_40.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_40.Click += new System.EventHandler(lbl_comp_Click);
			_lbl_comp_40.DoubleClick += new System.EventHandler(lbl_comp_DoubleClick);
			_lbl_comp_40.MouseDown += new System.Windows.Forms.MouseEventHandler(lbl_comp_MouseDown);
			// 
			// frm_Company
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Window;
			ClientSize = new System.Drawing.Size(1020, 753);
			ControlBox = false;
			Controls.Add(tab_company_details);
			Controls.Add(pnl_company_main);
			Controls.Add(tbr_ToolBar);
			Controls.Add(tab_company_admin);
			Controls.Add(pnl_verify_aircraft_status);
			Controls.Add(pnl_update_message);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.Black;
			Location = new System.Drawing.Point(560, 213);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Company";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "View/Update Company";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(_cmd_ac_verify_7, 0);
			commandButtonHelper1.SetStyle(_cmd_ac_verify_6, 0);
			commandButtonHelper1.SetStyle(_cmd_ac_verify_5, 0);
			commandButtonHelper1.SetStyle(_cmd_ac_verify_4, 0);
			commandButtonHelper1.SetStyle(_cmd_ac_verify_3, 0);
			commandButtonHelper1.SetStyle(_cmd_ac_verify_2, 0);
			commandButtonHelper1.SetStyle(_cmd_ac_verify_1, 0);
			commandButtonHelper1.SetStyle(_cmd_ac_verify_0, 0);
			commandButtonHelper1.SetStyle(cmd_aircraft_all_contact_change, 0);
			commandButtonHelper1.SetStyle(cmd_aircraft_contact_change, 0);
			commandButtonHelper1.SetStyle(cmd_EditMailList, 0);
			commandButtonHelper1.SetStyle(_btn_array_0, 0);
			commandButtonHelper1.SetStyle(_btn_array_1, 0);
			commandButtonHelper1.SetStyle(_btn_array_3, 0);
			commandButtonHelper1.SetStyle(_btn_array_2, 0);
			commandButtonHelper1.SetStyle(cmd_contact_seq_down, 1);
			commandButtonHelper1.SetStyle(cmd_contact_seq_up, 1);
			commandButtonHelper1.SetStyle(cmd_company_fill_journal, 0);
			commandButtonHelper1.SetStyle(_cmd_wanted_save_0, 0);
			commandButtonHelper1.SetStyle(_cmd_wanted_save_1, 0);
			commandButtonHelper1.SetStyle(_cmd_wanted_save_2, 0);
			commandButtonHelper1.SetStyle(_cmd_wanted_save_3, 0);
			commandButtonHelper1.SetStyle(cmd_wanted_delete, 0);
			commandButtonHelper1.SetStyle(cmd_wanted_add, 0);
			commandButtonHelper1.SetStyle(_cmdCertCommand_5, 0);
			commandButtonHelper1.SetStyle(_cmd_verify_yacht_6, 0);
			commandButtonHelper1.SetStyle(cmd_company_add_note, 0);
			commandButtonHelper1.SetStyle(cmd_company_save, 0);
			commandButtonHelper1.SetStyle(cmd_company_name_change_cancel, 0);
			commandButtonHelper1.SetStyle(cmd_company_phone_confirm, 0);
			commandButtonHelper1.SetStyle(cmd_company_phone_cancel, 0);
			commandButtonHelper1.SetStyle(cmd_company_phone_save, 0);
			commandButtonHelper1.SetStyle(cmd_edit_business_types, 0);
			commandButtonHelper1.SetStyle(cmd_Edit_Comp_Description, 0);
			commandButtonHelper1.SetStyle(cmd_delete_logo, 0);
			commandButtonHelper1.SetStyle(_cmd_company_button_0, 0);
			commandButtonHelper1.SetStyle(_cmd_company_button_1, 0);
			commandButtonHelper1.SetStyle(_cmd_company_update_callback_date_0, 0);
			commandButtonHelper1.SetStyle(_cmd_company_update_callback_date_1, 0);
			commandButtonHelper1.SetStyle(cmd_company_clear_research_note, 0);
			commandButtonHelper1.SetStyle(_cmdCompHistoryTab_0, 0);
			commandButtonHelper1.SetStyle(_cmdCompHistoryTab_1, 0);
			commandButtonHelper1.SetStyle(_cmd_relationship_buttons_4, 0);
			commandButtonHelper1.SetStyle(_cmd_relationship_buttons_3, 0);
			commandButtonHelper1.SetStyle(_cmd_relationship_buttons_2, 0);
			commandButtonHelper1.SetStyle(_cmd_relationship_buttons_1, 0);
			commandButtonHelper1.SetStyle(_cmd_relationship_buttons_0, 0);
			commandButtonHelper1.SetStyle(cmd_company_update_stats, 0);
			commandButtonHelper1.SetStyle(_cmdCertCommand_3, 0);
			commandButtonHelper1.SetStyle(_cmdCertCommand_2, 0);
			commandButtonHelper1.SetStyle(_cmdCertCommand_1, 0);
			commandButtonHelper1.SetStyle(_cmdCertCommand_0, 0);
			commandButtonHelper1.SetStyle(_cmdCertCommand_4, 0);
			commandButtonHelper1.SetStyle(cmd_verify_status_save, 0);
			commandButtonHelper1.SetStyle(_cmd_verify_yacht_2, 0);
			commandButtonHelper1.SetStyle(cmd_verify_status_cancel, 0);
			listBoxComboBoxHelper1.SetItemData(cbo_comp_name_alt_type, new int[]{0, 1, 2, 0});
			listBoxComboBoxHelper1.SetItemData(_cbo_comp_account_6, new int[]{0, 0, 0});
			listBoxHelper1.SetSelectionMode(lst_aircraft_contact, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_business_types, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_research_notes, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_related_contact, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_related_company, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_abi_services, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_aircraft, System.Windows.Forms.SelectionMode.MultiExtended);
			optionButtonHelper1.SetStyle(_opt_journal_subject_1, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_2, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_3, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_0, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_4, 0);
			optionButtonHelper1.SetStyle(_opt_verify_aircraft_5, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_12, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_13, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_11, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_10, 0);
			optionButtonHelper1.SetStyle(_opt_verify_aircraft_4, 0);
			optionButtonHelper1.SetStyle(_opt_verify_aircraft_3, 0);
			optionButtonHelper1.SetStyle(_opt_verify_aircraft_2, 0);
			optionButtonHelper1.SetStyle(_opt_verify_aircraft_1, 0);
			optionButtonHelper1.SetStyle(_opt_verify_aircraft_0, 0);
			ToolTipMain.SetToolTip(txt_contact_email_address, "Double Click To Open Outlook  *Field Is NOT Editable*");
			ToolTipMain.SetToolTip(_lbl_comp_91, "Click To Send This Contact an EMail Notice");
			ToolTipMain.SetToolTip(chkShowAllWanted, "When checked this show all Wanted records including Class E");
			ToolTipMain.SetToolTip(_cbo_comp_account_5, "Account Type");
			ToolTipMain.SetToolTip(chkCompDoNotSendEMail, "When checked this Company's email is on JETNET's Do Not Send List");
			ToolTipMain.SetToolTip(txt_comp_email_address, "Double Click To Open Outlook");
			ToolTipMain.SetToolTip(company_logo, "Double Click To Open Browse Window");
			ToolTipMain.SetToolTip(_cbo_comp_account_0, "Account Type");
			ToolTipMain.SetToolTip(_cbo_comp_account_1, "Account Rep Id");
			ToolTipMain.SetToolTip(_cbo_comp_account_2, "Marketing Rep");
			ToolTipMain.SetToolTip(chkCompContactAddressFlag, "Check If This Company Record Is A Contact Address Record");
			ToolTipMain.SetToolTip(_cbo_comp_account_6, "Marketing Rep");
			ToolTipMain.SetToolTip(_txt_company_field_3, "Enter the Airport Id this Company is Related to");
			ToolTipMain.SetToolTip(_cbo_comp_account_4, "Account Type");
			ToolTipMain.SetToolTip(_cbo_comp_account_3, "Account Type");
			ToolTipMain.SetToolTip(_lbl_comp_100, "Click To Hide This Company Relationship");
			ToolTipMain.SetToolTip(_lbl_comp_99, "Click To Hide This Company Relationship");
			ToolTipMain.SetToolTip(_lbl_comp_74, "Click To Hide This Company Relationship");
			UpgradeHelpers.Gui.Controls.SSTabHelper.SetSelectedIndex(tab_company_admin, 1);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grd_company_aircraft).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_company_contacts).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_contact_phone_numbers).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_company_journal).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_company_wanted).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_company_shares).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_company_documents).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_company_expired_leases).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_marketing_crm_notes).EndInit();
			((System.ComponentModel.ISupportInitialize) gdCompDocInProcess).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_pubs).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_company_phone).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_company_history).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_company_relationships).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_company_contact_relationships).EndInit();
			((System.ComponentModel.ISupportInitialize) grdCompDupByAdd).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_company_stats).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_company_cert).EndInit();
			((System.ComponentModel.ISupportInitialize) listBoxComboBoxHelper1).EndInit();
			tab_company_details.ResumeLayout(false);
			tab_company_details.PerformLayout();
			_tab_company_details_TabPage0.ResumeLayout(false);
			_tab_company_details_TabPage0.PerformLayout();
			_tab_company_details_TabPage1.ResumeLayout(false);
			_tab_company_details_TabPage1.PerformLayout();
			pnl_company_contact_details.ResumeLayout(false);
			pnl_company_contact_details.PerformLayout();
			_tab_company_details_TabPage2.ResumeLayout(false);
			_tab_company_details_TabPage2.PerformLayout();
			_tab_company_details_TabPage3.ResumeLayout(false);
			_tab_company_details_TabPage3.PerformLayout();
			pnl_company_wanted_notes.ResumeLayout(false);
			pnl_company_wanted_notes.PerformLayout();
			pnl_company_wanted.ResumeLayout(false);
			pnl_company_wanted.PerformLayout();
			frame_wanted_accept_aircraft_with.ResumeLayout(false);
			frame_wanted_accept_aircraft_with.PerformLayout();
			frame_wanted_makemodel.ResumeLayout(false);
			frame_wanted_makemodel.PerformLayout();
			_tab_company_details_TabPage4.ResumeLayout(false);
			_tab_company_details_TabPage4.PerformLayout();
			_tab_company_details_TabPage5.ResumeLayout(false);
			_tab_company_details_TabPage5.PerformLayout();
			_tab_company_details_TabPage6.ResumeLayout(false);
			_tab_company_details_TabPage6.PerformLayout();
			_tab_company_details_TabPage7.ResumeLayout(false);
			_tab_company_details_TabPage7.PerformLayout();
			_tab_company_details_TabPage8.ResumeLayout(false);
			_tab_company_details_TabPage8.PerformLayout();
			_tab_company_details_TabPage9.ResumeLayout(false);
			_tab_company_details_TabPage9.PerformLayout();
			_tab_company_details_TabPage10.ResumeLayout(false);
			_tab_company_details_TabPage10.PerformLayout();
			pnl_company_main.ResumeLayout(false);
			pnl_company_main.PerformLayout();
			pnl_company_name_change.ResumeLayout(false);
			pnl_company_name_change.PerformLayout();
			frame_comp_phone.ResumeLayout(false);
			frame_comp_phone.PerformLayout();
			tbr_ToolBar.ResumeLayout(false);
			tbr_ToolBar.PerformLayout();
			tab_company_admin.ResumeLayout(false);
			tab_company_admin.PerformLayout();
			_tab_company_admin_TabPage0.ResumeLayout(false);
			_tab_company_admin_TabPage0.PerformLayout();
			tab_comp_description.ResumeLayout(false);
			tab_comp_description.PerformLayout();
			_tab_comp_description_TabPage0.ResumeLayout(false);
			_tab_comp_description_TabPage0.PerformLayout();
			_tab_comp_description_TabPage1.ResumeLayout(false);
			_tab_comp_description_TabPage1.PerformLayout();
			pnl_fractional_owner.ResumeLayout(false);
			pnl_fractional_owner.PerformLayout();
			_tab_comp_description_TabPage2.ResumeLayout(false);
			_tab_comp_description_TabPage2.PerformLayout();
			_tab_comp_description_TabPage3.ResumeLayout(false);
			_tab_comp_description_TabPage3.PerformLayout();
			_tab_comp_description_TabPage4.ResumeLayout(false);
			_tab_comp_description_TabPage4.PerformLayout();
			_tab_comp_description_TabPage5.ResumeLayout(false);
			_tab_comp_description_TabPage5.PerformLayout();
			_tab_comp_description_TabPage6.ResumeLayout(false);
			_tab_comp_description_TabPage6.PerformLayout();
			_tab_company_admin_TabPage1.ResumeLayout(false);
			_tab_company_admin_TabPage1.PerformLayout();
			_tab_company_admin_TabPage2.ResumeLayout(false);
			_tab_company_admin_TabPage2.PerformLayout();
			pnl_research_notes.ResumeLayout(false);
			pnl_research_notes.PerformLayout();
			_tab_company_admin_TabPage3.ResumeLayout(false);
			_tab_company_admin_TabPage3.PerformLayout();
			_tab_company_admin_TabPage4.ResumeLayout(false);
			_tab_company_admin_TabPage4.PerformLayout();
			tab_company_rel.ResumeLayout(false);
			tab_company_rel.PerformLayout();
			_tab_company_rel_TabPage0.ResumeLayout(false);
			_tab_company_rel_TabPage0.PerformLayout();
			_tab_company_rel_TabPage1.ResumeLayout(false);
			_tab_company_rel_TabPage1.PerformLayout();
			_tab_company_rel_TabPage2.ResumeLayout(false);
			_tab_company_rel_TabPage2.PerformLayout();
			_tab_company_admin_TabPage5.ResumeLayout(false);
			_tab_company_admin_TabPage5.PerformLayout();
			_tab_company_admin_TabPage6.ResumeLayout(false);
			_tab_company_admin_TabPage6.PerformLayout();
			cert_edit_enter_frame.ResumeLayout(false);
			cert_edit_enter_frame.PerformLayout();
			pnl_verify_aircraft_status.ResumeLayout(false);
			pnl_verify_aircraft_status.PerformLayout();
			frame_options1.ResumeLayout(false);
			frame_options1.PerformLayout();
			frm_marketing_note.ResumeLayout(false);
			frm_marketing_note.PerformLayout();
			frame_verify_pnl.ResumeLayout(false);
			frame_verify_pnl.PerformLayout();
			pnl_update_message.ResumeLayout(false);
			pnl_update_message.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializetxt_market_note();
			Initializetxt_gen();
			Initializetxt_company_field();
			Initializeshp_dealer_background();
			Initializeshp_Shape();
			Initializepic_verify_ac();
			Initializeopt_verify_aircraft();
			Initializeopt_journal_subject();
			InitializemnuViewJournalSubType();
			InitializemnuReportList();
			Initializelbl_test_omg3();
			Initializelbl_comp();
			Initializecmd_wanted_save();
			Initializecmd_verify_yacht();
			Initializecmd_relationship_buttons();
			Initializecmd_company_update_callback_date();
			Initializecmd_company_button();
			Initializecmd_ac_verify();
			InitializecmdCompHistoryTab();
			InitializecmdCertCommand();
			Initializechk_company_flag();
			Initializechk_comp_product_code();
			Initializechk_array();
			Initializecert_combo_drop_down();
			Initializecbo_comp_account();
			Initializebtn_array();
			InitializeShape1();
			tab_company_adminPreviousTab = tab_company_admin.SelectedIndex;
			tab_company_relPreviousTab = tab_company_rel.SelectedIndex;
			tab_company_detailsPreviousTab = tab_company_details.SelectedIndex;
			tab_comp_descriptionPreviousTab = tab_comp_description.SelectedIndex;
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = JETNET_Homebase.mdi_ResearchAssistant.DefInstance;
			JETNET_Homebase.mdi_ResearchAssistant.DefInstance.Show();
			Form_Initialize();
		}
		void Initializetxt_market_note()
		{
			txt_market_note = new System.Windows.Forms.TextBox[8];
			txt_market_note[0] = _txt_market_note_0;
			txt_market_note[7] = _txt_market_note_7;
			txt_market_note[5] = _txt_market_note_5;
			txt_market_note[6] = _txt_market_note_6;
			txt_market_note[4] = _txt_market_note_4;
			txt_market_note[3] = _txt_market_note_3;
		}
		void Initializetxt_gen()
		{
			txt_gen = new System.Windows.Forms.TextBox[9];
			txt_gen[8] = _txt_gen_8;
			txt_gen[3] = _txt_gen_3;
			txt_gen[1] = _txt_gen_1;
			txt_gen[4] = _txt_gen_4;
			txt_gen[2] = _txt_gen_2;
			txt_gen[5] = _txt_gen_5;
			txt_gen[0] = _txt_gen_0;
			txt_gen[6] = _txt_gen_6;
			txt_gen[7] = _txt_gen_7;
		}
		void Initializetxt_company_field()
		{
			txt_company_field = new System.Windows.Forms.TextBox[5];
			txt_company_field[2] = _txt_company_field_2;
			txt_company_field[3] = _txt_company_field_3;
			txt_company_field[1] = _txt_company_field_1;
			txt_company_field[0] = _txt_company_field_0;
			txt_company_field[4] = _txt_company_field_4;
		}
		void Initializeshp_dealer_background()
		{
			shp_dealer_background = new UpgradeHelpers.Gui.ShapeHelper[14];
			shp_dealer_background[7] = _shp_dealer_background_7;
			shp_dealer_background[11] = _shp_dealer_background_11;
			shp_dealer_background[12] = _shp_dealer_background_12;
			shp_dealer_background[10] = _shp_dealer_background_10;
			shp_dealer_background[8] = _shp_dealer_background_8;
			shp_dealer_background[9] = _shp_dealer_background_9;
			shp_dealer_background[13] = _shp_dealer_background_13;
			shp_dealer_background[0] = _shp_dealer_background_0;
			shp_dealer_background[2] = _shp_dealer_background_2;
			shp_dealer_background[3] = _shp_dealer_background_3;
			shp_dealer_background[4] = _shp_dealer_background_4;
			shp_dealer_background[5] = _shp_dealer_background_5;
			shp_dealer_background[6] = _shp_dealer_background_6;
			shp_dealer_background[1] = _shp_dealer_background_1;
		}
		void Initializeshp_Shape()
		{
			shp_Shape = new UpgradeHelpers.Gui.ShapeHelper[2];
			shp_Shape[1] = _shp_Shape_1;
			shp_Shape[0] = _shp_Shape_0;
		}
		void Initializepic_verify_ac()
		{
			pic_verify_ac = new System.Windows.Forms.PictureBox[4];
			pic_verify_ac[1] = _pic_verify_ac_1;
			pic_verify_ac[0] = _pic_verify_ac_0;
			pic_verify_ac[3] = _pic_verify_ac_3;
			pic_verify_ac[2] = _pic_verify_ac_2;
		}
		void Initializeopt_verify_aircraft()
		{
			opt_verify_aircraft = new System.Windows.Forms.RadioButton[6];
			opt_verify_aircraft[5] = _opt_verify_aircraft_5;
			opt_verify_aircraft[4] = _opt_verify_aircraft_4;
			opt_verify_aircraft[3] = _opt_verify_aircraft_3;
			opt_verify_aircraft[2] = _opt_verify_aircraft_2;
			opt_verify_aircraft[1] = _opt_verify_aircraft_1;
			opt_verify_aircraft[0] = _opt_verify_aircraft_0;
		}
		void Initializeopt_journal_subject()
		{
			opt_journal_subject = new System.Windows.Forms.RadioButton[14];
			opt_journal_subject[1] = _opt_journal_subject_1;
			opt_journal_subject[2] = _opt_journal_subject_2;
			opt_journal_subject[3] = _opt_journal_subject_3;
			opt_journal_subject[0] = _opt_journal_subject_0;
			opt_journal_subject[4] = _opt_journal_subject_4;
			opt_journal_subject[12] = _opt_journal_subject_12;
			opt_journal_subject[13] = _opt_journal_subject_13;
			opt_journal_subject[11] = _opt_journal_subject_11;
			opt_journal_subject[10] = _opt_journal_subject_10;
		}
		void InitializemnuViewJournalSubType()
		{
			mnuViewJournalSubType = new System.Windows.Forms.ToolStripItem[4];
			mnuViewJournalSubType[1] = _mnuViewJournalSubType_1;
			mnuViewJournalSubType[2] = _mnuViewJournalSubType_2;
			mnuViewJournalSubType[3] = _mnuViewJournalSubType_3;
		}
		void InitializemnuReportList()
		{
			mnuReportList = new System.Windows.Forms.ToolStripItem[8];
			mnuReportList[0] = _mnuReportList_0;
			mnuReportList[1] = _mnuReportList_1;
			mnuReportList[2] = _mnuReportList_2;
			mnuReportList[3] = _mnuReportList_3;
			mnuReportList[4] = _mnuReportList_4;
			mnuReportList[5] = _mnuReportList_5;
			mnuReportList[6] = _mnuReportList_6;
			mnuReportList[7] = _mnuReportList_7;
		}
		void Initializelbl_test_omg3()
		{
			lbl_test_omg3 = new System.Windows.Forms.Label[4];
			lbl_test_omg3[1] = _lbl_test_omg3_1;
			lbl_test_omg3[3] = _lbl_test_omg3_3;
			lbl_test_omg3[0] = _lbl_test_omg3_0;
			lbl_test_omg3[2] = _lbl_test_omg3_2;
		}
		void Initializelbl_comp()
		{
			lbl_comp = new System.Windows.Forms.Label[301];
			lbl_comp[2] = _lbl_comp_2;
			lbl_comp[36] = _lbl_comp_36;
			lbl_comp[29] = _lbl_comp_29;
			lbl_comp[32] = _lbl_comp_32;
			lbl_comp[34] = _lbl_comp_34;
			lbl_comp[33] = _lbl_comp_33;
			lbl_comp[43] = _lbl_comp_43;
			lbl_comp[9] = _lbl_comp_9;
			lbl_comp[88] = _lbl_comp_88;
			lbl_comp[89] = _lbl_comp_89;
			lbl_comp[21] = _lbl_comp_21;
			lbl_comp[81] = _lbl_comp_81;
			lbl_comp[68] = _lbl_comp_68;
			lbl_comp[67] = _lbl_comp_67;
			lbl_comp[69] = _lbl_comp_69;
			lbl_comp[300] = _lbl_comp_300;
			lbl_comp[77] = _lbl_comp_77;
			lbl_comp[91] = _lbl_comp_91;
			lbl_comp[1] = _lbl_comp_1;
			lbl_comp[90] = _lbl_comp_90;
			lbl_comp[109] = _lbl_comp_109;
			lbl_comp[4] = _lbl_comp_4;
			lbl_comp[37] = _lbl_comp_37;
			lbl_comp[51] = _lbl_comp_51;
			lbl_comp[70] = _lbl_comp_70;
			lbl_comp[50] = _lbl_comp_50;
			lbl_comp[62] = _lbl_comp_62;
			lbl_comp[79] = _lbl_comp_79;
			lbl_comp[15] = _lbl_comp_15;
			lbl_comp[80] = _lbl_comp_80;
			lbl_comp[83] = _lbl_comp_83;
			lbl_comp[84] = _lbl_comp_84;
			lbl_comp[85] = _lbl_comp_85;
			lbl_comp[86] = _lbl_comp_86;
			lbl_comp[97] = _lbl_comp_97;
			lbl_comp[101] = _lbl_comp_101;
			lbl_comp[102] = _lbl_comp_102;
			lbl_comp[35] = _lbl_comp_35;
			lbl_comp[16] = _lbl_comp_16;
			lbl_comp[14] = _lbl_comp_14;
			lbl_comp[45] = _lbl_comp_45;
			lbl_comp[24] = _lbl_comp_24;
			lbl_comp[52] = _lbl_comp_52;
			lbl_comp[25] = _lbl_comp_25;
			lbl_comp[53] = _lbl_comp_53;
			lbl_comp[64] = _lbl_comp_64;
			lbl_comp[55] = _lbl_comp_55;
			lbl_comp[63] = _lbl_comp_63;
			lbl_comp[23] = _lbl_comp_23;
			lbl_comp[26] = _lbl_comp_26;
			lbl_comp[0] = _lbl_comp_0;
			lbl_comp[66] = _lbl_comp_66;
			lbl_comp[65] = _lbl_comp_65;
			lbl_comp[76] = _lbl_comp_76;
			lbl_comp[54] = _lbl_comp_54;
			lbl_comp[116] = _lbl_comp_116;
			lbl_comp[115] = _lbl_comp_115;
			lbl_comp[12] = _lbl_comp_12;
			lbl_comp[114] = _lbl_comp_114;
			lbl_comp[18] = _lbl_comp_18;
			lbl_comp[30] = _lbl_comp_30;
			lbl_comp[73] = _lbl_comp_73;
			lbl_comp[96] = _lbl_comp_96;
			lbl_comp[94] = _lbl_comp_94;
			lbl_comp[95] = _lbl_comp_95;
			lbl_comp[93] = _lbl_comp_93;
			lbl_comp[113] = _lbl_comp_113;
			lbl_comp[112] = _lbl_comp_112;
			lbl_comp[105] = _lbl_comp_105;
			lbl_comp[103] = _lbl_comp_103;
			lbl_comp[100] = _lbl_comp_100;
			lbl_comp[99] = _lbl_comp_99;
			lbl_comp[98] = _lbl_comp_98;
			lbl_comp[74] = _lbl_comp_74;
			lbl_comp[61] = _lbl_comp_61;
			lbl_comp[92] = _lbl_comp_92;
			lbl_comp[87] = _lbl_comp_87;
			lbl_comp[82] = _lbl_comp_82;
			lbl_comp[42] = _lbl_comp_42;
			lbl_comp[78] = _lbl_comp_78;
			lbl_comp[7] = _lbl_comp_7;
			lbl_comp[5] = _lbl_comp_5;
			lbl_comp[22] = _lbl_comp_22;
			lbl_comp[3] = _lbl_comp_3;
			lbl_comp[44] = _lbl_comp_44;
			lbl_comp[28] = _lbl_comp_28;
			lbl_comp[8] = _lbl_comp_8;
			lbl_comp[41] = _lbl_comp_41;
			lbl_comp[20] = _lbl_comp_20;
			lbl_comp[56] = _lbl_comp_56;
			lbl_comp[31] = _lbl_comp_31;
			lbl_comp[59] = _lbl_comp_59;
			lbl_comp[60] = _lbl_comp_60;
			lbl_comp[58] = _lbl_comp_58;
			lbl_comp[71] = _lbl_comp_71;
			lbl_comp[72] = _lbl_comp_72;
			lbl_comp[57] = _lbl_comp_57;
			lbl_comp[27] = _lbl_comp_27;
			lbl_comp[38] = _lbl_comp_38;
			lbl_comp[13] = _lbl_comp_13;
			lbl_comp[11] = _lbl_comp_11;
			lbl_comp[39] = _lbl_comp_39;
			lbl_comp[10] = _lbl_comp_10;
			lbl_comp[6] = _lbl_comp_6;
			lbl_comp[19] = _lbl_comp_19;
			lbl_comp[104] = _lbl_comp_104;
			lbl_comp[49] = _lbl_comp_49;
			lbl_comp[17] = _lbl_comp_17;
			lbl_comp[46] = _lbl_comp_46;
			lbl_comp[48] = _lbl_comp_48;
			lbl_comp[47] = _lbl_comp_47;
			lbl_comp[75] = _lbl_comp_75;
			lbl_comp[40] = _lbl_comp_40;
		}
		void Initializecmd_wanted_save()
		{
			cmd_wanted_save = new System.Windows.Forms.Button[4];
			cmd_wanted_save[0] = _cmd_wanted_save_0;
			cmd_wanted_save[1] = _cmd_wanted_save_1;
			cmd_wanted_save[2] = _cmd_wanted_save_2;
			cmd_wanted_save[3] = _cmd_wanted_save_3;
		}
		void Initializecmd_verify_yacht()
		{
			cmd_verify_yacht = new System.Windows.Forms.Button[7];
			cmd_verify_yacht[6] = _cmd_verify_yacht_6;
			cmd_verify_yacht[2] = _cmd_verify_yacht_2;
		}
		void Initializecmd_relationship_buttons()
		{
			cmd_relationship_buttons = new System.Windows.Forms.Button[5];
			cmd_relationship_buttons[4] = _cmd_relationship_buttons_4;
			cmd_relationship_buttons[3] = _cmd_relationship_buttons_3;
			cmd_relationship_buttons[2] = _cmd_relationship_buttons_2;
			cmd_relationship_buttons[1] = _cmd_relationship_buttons_1;
			cmd_relationship_buttons[0] = _cmd_relationship_buttons_0;
		}
		void Initializecmd_company_update_callback_date()
		{
			cmd_company_update_callback_date = new System.Windows.Forms.Button[2];
			cmd_company_update_callback_date[1] = _cmd_company_update_callback_date_1;
			cmd_company_update_callback_date[0] = _cmd_company_update_callback_date_0;
		}
		void Initializecmd_company_button()
		{
			cmd_company_button = new System.Windows.Forms.Button[2];
			cmd_company_button[1] = _cmd_company_button_1;
			cmd_company_button[0] = _cmd_company_button_0;
		}
		void Initializecmd_ac_verify()
		{
			cmd_ac_verify = new System.Windows.Forms.Button[8];
			cmd_ac_verify[0] = _cmd_ac_verify_0;
			cmd_ac_verify[1] = _cmd_ac_verify_1;
			cmd_ac_verify[2] = _cmd_ac_verify_2;
			cmd_ac_verify[3] = _cmd_ac_verify_3;
			cmd_ac_verify[4] = _cmd_ac_verify_4;
			cmd_ac_verify[5] = _cmd_ac_verify_5;
			cmd_ac_verify[6] = _cmd_ac_verify_6;
			cmd_ac_verify[7] = _cmd_ac_verify_7;
		}
		void InitializecmdCompHistoryTab()
		{
			cmdCompHistoryTab = new System.Windows.Forms.Button[2];
			cmdCompHistoryTab[1] = _cmdCompHistoryTab_1;
			cmdCompHistoryTab[0] = _cmdCompHistoryTab_0;
		}
		void InitializecmdCertCommand()
		{
			cmdCertCommand = new System.Windows.Forms.Button[6];
			cmdCertCommand[5] = _cmdCertCommand_5;
			cmdCertCommand[4] = _cmdCertCommand_4;
			cmdCertCommand[3] = _cmdCertCommand_3;
			cmdCertCommand[2] = _cmdCertCommand_2;
			cmdCertCommand[1] = _cmdCertCommand_1;
			cmdCertCommand[0] = _cmdCertCommand_0;
		}
		void Initializechk_company_flag()
		{
			chk_company_flag = new System.Windows.Forms.CheckBox[2];
			chk_company_flag[1] = _chk_company_flag_1;
			chk_company_flag[0] = _chk_company_flag_0;
		}
		void Initializechk_comp_product_code()
		{
			chk_comp_product_code = new System.Windows.Forms.CheckBox[8];
			chk_comp_product_code[7] = _chk_comp_product_code_7;
			chk_comp_product_code[6] = _chk_comp_product_code_6;
			chk_comp_product_code[5] = _chk_comp_product_code_5;
			chk_comp_product_code[4] = _chk_comp_product_code_4;
			chk_comp_product_code[3] = _chk_comp_product_code_3;
			chk_comp_product_code[2] = _chk_comp_product_code_2;
			chk_comp_product_code[1] = _chk_comp_product_code_1;
			chk_comp_product_code[0] = _chk_comp_product_code_0;
		}
		void Initializechk_array()
		{
			chk_array = new System.Windows.Forms.CheckBox[7];
			chk_array[0] = _chk_array_0;
			chk_array[5] = _chk_array_5;
			chk_array[6] = _chk_array_6;
			chk_array[4] = _chk_array_4;
			chk_array[3] = _chk_array_3;
			chk_array[2] = _chk_array_2;
			chk_array[1] = _chk_array_1;
		}
		void Initializecert_combo_drop_down()
		{
			cert_combo_drop_down = new System.Windows.Forms.ComboBox[2];
			cert_combo_drop_down[1] = _cert_combo_drop_down_1;
			cert_combo_drop_down[0] = _cert_combo_drop_down_0;
		}
		void Initializecbo_comp_account()
		{
			cbo_comp_account = new System.Windows.Forms.ComboBox[7];
			cbo_comp_account[5] = _cbo_comp_account_5;
			cbo_comp_account[6] = _cbo_comp_account_6;
			cbo_comp_account[4] = _cbo_comp_account_4;
			cbo_comp_account[3] = _cbo_comp_account_3;
			cbo_comp_account[2] = _cbo_comp_account_2;
			cbo_comp_account[1] = _cbo_comp_account_1;
			cbo_comp_account[0] = _cbo_comp_account_0;
		}
		void Initializebtn_array()
		{
			btn_array = new System.Windows.Forms.Button[4];
			btn_array[2] = _btn_array_2;
			btn_array[3] = _btn_array_3;
			btn_array[0] = _btn_array_0;
			btn_array[1] = _btn_array_1;
		}
		void InitializeShape1()
		{
			Shape1 = new UpgradeHelpers.Gui.ShapeHelper[4];
			Shape1[3] = _Shape1_3;
			Shape1[2] = _Shape1_2;
			Shape1[1] = _Shape1_1;
			Shape1[0] = _Shape1_0;
		}
		#endregion
	}
}