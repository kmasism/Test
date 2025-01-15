
namespace JETNET_Homebase
{
	partial class frm_aircraft
	{

		#region "Upgrade Support "
		private static frm_aircraft m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_aircraft DefInstance
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
		public static frm_aircraft CreateInstance()
		{
			frm_aircraft theInstance = new frm_aircraft();
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
		private void Ctx_mnuHistoricalTransaction_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			Ctx_mnuHistoricalTransaction.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach (System.Windows.Forms.ToolStripItem item in ((System.Windows.Forms.ToolStripMenuItem) mnuHistoricalTransaction).DropDownItems)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				Ctx_mnuHistoricalTransaction.Items.Add(item);
			}
			e.Cancel = false;
		}
		private void Ctx_mnuHistoricalTransaction_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach (System.Windows.Forms.ToolStripItem item in Ctx_mnuHistoricalTransaction.Items)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				((System.Windows.Forms.ToolStripMenuItem) mnuHistoricalTransaction).DropDownItems.Add(item);
			}
		}
		private void Ctx_mnuCompTransmits_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			Ctx_mnuCompTransmits.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach (System.Windows.Forms.ToolStripItem item in ((System.Windows.Forms.ToolStripMenuItem) mnuCompTransmits).DropDownItems)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				Ctx_mnuCompTransmits.Items.Add(item);
			}
			e.Cancel = false;
		}
		private void Ctx_mnuCompTransmits_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach (System.Windows.Forms.ToolStripItem item in Ctx_mnuCompTransmits.Items)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				((System.Windows.Forms.ToolStripMenuItem) mnuCompTransmits).DropDownItems.Add(item);
			}
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileClose", "mnuFileLogout", "mnu_File", "mnuSendAsOwner", "mnuSendAsOperator", "mnuSendAsChiefPilot", "mnuSendAsExclusiveBroker", "mnuSendAsExclusiveRepresentative", "mnuSendAsAdditional1", "mnuSendAsAdditional2", "mnuSendAsAdditional3", "mnuSendAsRegisteredAsOwner", "mnuSendAsPurchaser", "mnuSendAsRegisteredAsPurchaser", "mnuDoNotSend", "mnuChangePercentage", "mnuChangeBusinessType", "mnuChangeOperator", "mnuCompTransmits", "mnuEditNewJournal", "mnuEditAddNote", "mnuUpdateAwaitingDocs", "mnuAddExclusiveBroker", "mnuRemoveExclusive", "mnuDeleteHistoricalRecord", "mnuDocumentJournal", "mnuAddAircraftDeliveryNote", "mnuEditRegNbrRequestToFAA", "mnuenterprice", "mnuremoveprice", "mnuAddIDNote", "cmdaddnote", "mnu_Edit", "mnuViewAircraftLookup", "mnuEvents", "mnuFAAFlightData", "mnuSalePrices", "mnuhomebase", "mnuView", "mnueditchange", "mnueditchangeFractional", "mnueditchangeShare", "mnueditchangeSieze", "mnueditchangeForeclosure", "mnueditchangeDelivery", "mnueditchangeLease", "mnuTransmit", "_mnuChangeContactType_0", "_mnuChangeContactType_8", "_mnuChangeContactType_12", "_mnuChangeContactType_13", "_mnuChangeContactType_27", "_mnuChangeContactType_39", "_mnuChangeContactType_51", "_mnuChangeContactType_52", "_mnuChangeContactType_53", "_mnuChangeContactType_54", "_mnuChangeContactType_56", "_mnuChangeContactType_60", "_mnuChangeContactType_61", "_mnuChangeContactType_62", "_mnuChangeContactType_69", "_mnuChangeContactType_70", "_mnuChangeContactType_91", "_mnuChangeContactType_95", "_mnuChangeContactType_96", "mnuConvertFSPEND", "mnuChangeHistPercentage", "mnuHistoricalTransaction", "mnuTransactions", "mnureport", "mnuPubs", "mnuAttachedSpecs", "mnu_Help", "cmdAircraftSearch", "mnuAircraftShowUserHistory", "mnurestoreacavailable", "mnuTools", "MainMenu1", "_lbl_gen_44", "_lbl_gen_34", "_lbl_gen_238", "_lbl_gen_239", "_lbl_gen_231", "_lbl_gen_230", "_lbl_gen_54", "_lbl_gen_20", "_lbl_gen_19", "_lbl_gen_262", "_lbl_gen_261", "_lbl_gen_260", "_lbl_gen_263", "_lbl_gen_103", "_lbl_gen_104", "_lbl_gen_72", "_lbl_gen_73", "_lbl_gen_105", "_lbl_gen_106", "_lbl_gen_107", "_lbl_gen_40", "_lbl_gen_58", "_lbl_gen_28", "_lbl_gen_70", "_lbl_gen_71", "_lbl_gen_59", "_lbl_gen_60", "_lbl_gen_61", "_lbl_gen_62", "_lbl_gen_57", "_lbl_gen_92", "_Label1_1", "_lbl_gen_89", "_lbl_gen_90", "_lbl_gen_26", "_lbl_gen_25", "_lbl_gen_24", "_lbl_gen_23", "_lbl_gen_18", "_lbl_gen_35", "_lbl_gen_117", "_lbl_gen_51", "_grd_Features_4", "_txt_ac_prop_soh_hrs_1", "_txt_ac_prop_soh_hrs_0", "_txt_ac_prop_soh_hrs_2", "_txt_ac_prop_soh_hrs_3", "_txt_ac_prop_soh_year_2", "_txt_ac_prop_soh_year_3", "_txt_ac_prop_soh_year_1", "_txt_ac_prop_soh_year_0", "_txt_ac_prop_snew_hrs_1", "_txt_ac_prop_snew_hrs_0", "_txt_ac_prop_snew_hrs_2", "_txt_ac_prop_snew_hrs_3", "_txt_ac_prop_ser_no_3", "_txt_ac_prop_ser_no_2", "_txt_ac_prop_soh_mo_3", "_txt_ac_prop_soh_mo_2", "_txt_ac_prop_soh_mo_0", "_txt_ac_prop_soh_mo_1", "_txt_ac_prop_ser_no_0", "_txt_ac_prop_ser_no_1", "txt_ac_confidential_notes", "cbo_ac_apu_maint_prog", "_txt_ac_apu_0", "_txt_ac_apu_1", "_txt_ac_apu_2", "cbo_ac_apu_model_name", "_txt_ac_engine_shs_cycles_3", "_txt_ac_engine_shs_cycles_2", "_txt_ac_engine_shs_cycles_1", "_txt_ac_engine_shs_cycles_0", "_txt_ac_engine_tot_hrs_0", "_txt_ac_engine_tot_hrs_1", "_txt_ac_engine_tot_hrs_2", "_txt_ac_engine_tot_hrs_3", "_txt_ac_engine_soh_hrs_0", "_txt_ac_engine_soh_hrs_1", "_txt_ac_engine_soh_hrs_2", "_txt_ac_engine_soh_hrs_3", "_txt_ac_engine_shi_hrs_0", "_txt_ac_engine_shi_hrs_1", "_txt_ac_engine_shi_hrs_2", "_txt_ac_engine_shi_hrs_3", "_txt_ac_engine_tbo_hrs_0", "_txt_ac_engine_tbo_hrs_1", "_txt_ac_engine_tbo_hrs_2", "_txt_ac_engine_tbo_hrs_3", "cbo_ac_engine_name", "cbo_ac_engine_maint_prog", "_txt_ac_engine_snew_cycles_3", "_txt_ac_engine_snew_cycles_2", "_txt_ac_engine_snew_cycles_1", "_txt_ac_engine_snew_cycles_0", "_txt_ac_engine_soh_cycles_3", "_txt_ac_engine_soh_cycles_2", "_txt_ac_engine_soh_cycles_1", "_txt_ac_engine_soh_cycles_0", "txt_ac_times_as_of_date", "txt_ac_airframe_tot_landings", "txt_ac_airframe_tot_hrs", "cbo_ac_engine_management_prog_EMGP", "_cmdHelicopter_0", "_cmdHelicopter_1", "txt_ac_engine_noise_rating", "_txt_ac_engine_ser_no_3", "_txt_ac_engine_ser_no_2", "_txt_ac_engine_ser_no_1", "_txt_ac_engine_ser_no_0", "GrdHelicopter", "cbo_edit_heli", "txt_edit_heli", "txt_ac_hidden_asking_price", "chk_oncondtbo", "_tab_aircraft_details_TabPage0", "_lbl_gen_120", "_lbl_gen_114", "_lbl_gen_115", "_lbl_gen_116", "_lbl_gen_118", "_lbl_gen_130", "_lbl_gen_64", "_lbl_gen_65", "_lbl_gen_76", "_lbl_gen_87", "_grd_Features_0", "grd_aircraftdamage", "grd_Maintenance", "cbo_accert_name", "_cmd_Add_Cert_2", "_cmd_Add_Cert_0", "grd_Aircraft_Certified", "_lbl_gen_101", "pnl_certifications", "txt_ac_maint_eoh_mo", "txt_ac_maint_hots_mo", "txt_ac_maint_hots_by_name", "txt_ac_maint_eoh_by_name", "txt_ac_damage_history_notes", "txt_ac_maint_eoh_year", "txt_ac_maint_hots_year", "cbo_ac_warranty_notes", "cbo_ac_airframe_maintenance_prog_AMP", "cbo_ac_airframe_maint_tracking_prog_AMTP", "_cmdAddACDetail_6", "grd_maint", "_cmdAddACDetail_3", "cbo_dam", "_cmd_Add_Cert_1", "_tab_aircraft_details_TabPage1", "_lbl_gen_27", "_lbl_gen_53", "_lbl_gen_49", "_lbl_gen_46", "_lbl_gen_234", "_lbl_gen_200", "_lbl_gen_236", "_lbl_gen_78", "_lbl_gen_79", "_grd_Features_1", "grd_Exterior", "txt_ac_exterior_rating", "txt_ac_interior_rating", "cbo_ac_interior_config_name", "txt_ac_passenger_count", "txt_ac_interior_mo", "txt_ac_exterior_mo", "txt_ac_interior_doneby_name", "txt_ac_exterior_doneby_name", "txt_ac_exterior_year", "txt_ac_interior_year", "grd_Interior", "_cmdAddACDetail_0", "_cmdAddACDetail_1", "_tab_aircraft_details_TabPage2", "_lbl_gen_52", "_lbl_gen_32", "_grd_Features_2", "grd_Equipment", "_cmdAddACDetail_2", "_tab_aircraft_details_TabPage3", "_cmdAddACDetail_4", "_cmd_Av_Add_0", "lst_Avionics", "_cmd_Av_Add_2", "_cmd_Av_Add_3", "_cmd_Av_Add_1", "cbo_av_description", "pnl_Av", "grd_AircraftAvionics", "grd_Cockpit", "_grd_Features_3", "_lbl_gen_48", "pnl_Cockpit", "_tab_aircraft_details_TabPage4", "chk_verified", "_cmdAddACDetail_10", "cbo_company_research_contact", "_cmdAddACDetail_8", "cbo_change_rel", "_cmdAddACDetail_7", "cmd_Primary", "cmd_Confirm_Company", "cmd_AssociateCompany", "cmd_Remove_Association", "cmd_Set_As_Exclusive", "cmd_Clear_Exclusive_Confirmation_Company", "_pnl_gen_1", "chkShowAllContactInfo", "_cmdAddACDetail_5", "lst_Company", "lst_Contact", "_txt_gen_4", "cbo_ac_purchase_question", "_txt_gen_3", "_txt_gen_2", "_txt_gen_1", "_txt_gen_0", "grd_AircraftContacts", "_lbl_gen_16", "_pnl_gen_4", "_txt_ac_lease_type_2", "_txt_ac_lease_type_1", "txtLeaseExpireConfirmDate", "chkConfirmLeaseExpired", "txt_ac_lease_expire_date", "_txt_ac_lease_type_0", "_cmdSaveLease_0", "_cmdSaveLease_1", "_lbl_gen_82", "_lbl_gen_224", "_lbl_gen_218", "_lbl_gen_190", "_lbl_gen_217", "pnl_LeaseEntry", "chkConfirmedOnly", "grdLeaseInfo", "_lbl_gen_38", "_lbl_gen_37", "_lbl_gen_36", "_lbl_gen_29", "_lbl_gen_21", "_lbl_gen_39", "_lbl_gen_43", "pnl_LeaseList", "_lbl_gen_55", "_tab_aircraft_details_TabPage5", "txtACJournalSearch", "txt_ac_common_notes", "cbo_jcat_subcategory_code", "cbo_jcat_category_code", "cbo_jcat_account_rep", "txt_journal_category_start_date", "txt_journal_category_end_date", "cmd_jcat_Redisplay_Journal_List", "_chkArray_1", "txtHowManyJournal", "grd_Aircraft_Journal", "_lbl_gen_125", "_lbl_gen_233", "_lbl_gen_91", "_lbl_gen_96", "_lbl_gen_99", "_tab_aircraft_details_TabPage6", "web_OpCosts", "_tab_aircraft_details_TabPage7", "web_Specs", "_tab_aircraft_details_TabPage8", "_lbl_gen_228", "_lbl_gen_227", "_lbl_gen_45", "_lbl_gen_47", "txt_acfaa_notes", "_txt_acfaa_reg_status_3", "_txt_acfaa_reg_no_3", "_txt_acfaa_reg_status_2", "_txt_acfaa_reg_no_2", "_txt_acfaa_reg_status_1", "_txt_acfaa_reg_no_1", "_txt_acfaa_reg_status_0", "_txt_acfaa_reg_no_0", "_txt_acfaa_party_comp_name_9", "_txt_acfaa_party_comp_name_8", "_txt_acfaa_party_comp_name_7", "_txt_acfaa_party_comp_name_6", "_txt_acfaa_party_comp_name_5", "_txt_acfaa_party_comp_name_4", "_txt_acfaa_party_comp_name_3", "_txt_acfaa_party_comp_name_2", "_txt_acfaa_party_comp_name_1", "_txt_acfaa_party_comp_name_0", "_grd_pubs_1", "_tab_aircraft_details_TabPage9", "_cmdSaveDocNotes_4", "_cbo_drop_array_1", "web_Browser", "_txtDocNotes_0", "_txtDocNotes_3", "grd_DocumentLog", "_cmdSaveDocNotes_3", "_txtDocNotes_2", "_cmdSaveDocNotes_2", "cmd_DocsInProcessRefresh", "cmdViewDocumentInSeparateWindow", "_cmdSaveDocNotes_0", "_cboAcctRep_0", "txt_customer_notes", "txt_internal_notes", "cmdFinancialDocuments", "grdTransactionDocuments", "_lbl_gen_81", "_lbl_gen_80", "pnl_TransactionNotes", "_lbl_gen_124", "_lbl_gen_122", "_lbl_gen_94", "_lbl_gen_93", "_lbl_gen_63", "_tab_aircraft_details_TabPage10", "_txtDocNotes_1", "_cboAcctRep_1", "grdAircraftDocuments", "_tab_aircraft_details_TabPage11", "web_Ac1", "_cmdSaveDocNotes_6", "_cmdSaveDocNotes_5", "_cmdSaveDocNotes_1", "lstAcPictures", "_lbl_gen_88", "imgACPicture", "_tab_aircraft_details_TabPage12", "_cbo_drop_array_0", "_grd_pubs_0", "_tab_aircraft_details_TabPage13", "cbo_Feature_Options", "txt_Kfeat_Update_Code", "grd_AircraftKeyFeatures", "_tab_aircraft_details_TabPage14", "tab_aircraft_details", "ac_mapping_list", "ac_mapping_id", "cmd_set_mapping_flag", "Shape1", "_lbl_gen_110", "_lbl_gen_111", "_lbl_gen_8", "_lbl_gen_7", "_lbl_gen_11", "_lbl_gen_1", "_lbl_gen_2", "_cmdAddACDetail_9", "_chkArray_2", "txt_ac_sale_price", "txt_ac_foreign_currency_price", "cbo_ac_foreign_currency_name", "cbo_ac_asking", "txt_ac_asking_price", "txt_ac_list_date", "cbo_ac_delivery", "_lbl_gen_75", "_lbl_gen_98", "_lbl_gen_33", "_lbl_gen_31", "_lbl_gen_9", "_lbl_gen_10", "_lbl_gen_6", "pnl_Sale_Data", "cbo_ac_status", "_chkArray_6", "txt_ac_purchase_date", "_chkArray_5", "txt_exclusive_verify_date", "_chkArray_4", "cbo_ac_stage", "cbo_ac_owner_type", "_chkArray_3", "_tab_ACMain_TabPage0",  
 			"cmdModifyTransaction", "cmdRetrieveSpecs", "_chkArray_0", "cmd_Active", "grd_AircraftHistory", "_lbl_gen_86", "_tab_ACMain_TabPage1", "_chkArray_7", "_chk_ac_aport_private_1", "_lbl_gen_50", "_lbl_gen_22", "_lbl_gen_256", "_lbl_gen_245", "_lbl_gen_15", "_lbl_gen_13", "_lbl_gen_14", "_lbl_gen_12", "_lbl_gen_257", "_tab_ACMain_TabPage2", "txtAddlHotBoxNotes", "cmdClearResearchAction", "cmd_Cancel", "lst_Research_Action", "_lbl_gen_77", "_lbl_gen_83", "pnl_Research_Action", "txt_journal_note", "cmd_Journal_Note_Cancel", "cmd_Journal_Note_Save", "pnl_Journal", "_tab_ACMain_TabPage3", "_lbl_gen_74", "_lbl_gen_69", "_lbl_gen_68", "_lbl_gen_67", "_lbl_gen_66", "_lbl_gen_41", "_lbl_gen_109", "_lbl_gen_112", "_lbl_gen_121", "_lbl_gen_123", "txtBaseCity", "txtBaseAirportName", "txtICAOCode", "txtIATACode", "cboBaseState", "cboBaseCountry", "_chk_ac_aport_private_0", "txtFAAIDCode", "_chk_ac_aport_private_2", "_tab_ACMain_TabPage4", "_chk_ac_product_3", "_chk_ac_product_5", "_chk_ac_product_4", "_chk_ac_product_2", "_chk_ac_product_1", "_chk_ac_product_0", "_lbl_gen_113", "frm_aircraft_products", "_tab_ACMain_TabPage5", "tab_ACMain", "_txt_ac_reg_no_1", "_txt_ac_year_2", "_txt_ac_year_0", "cbo_ac_country_of_registration", "txt_ac_delivery_date", "cbo_ac_use_code", "_txt_ac_alt_ser_no_2", "_txt_ac_alt_ser_no_1", "_txt_ac_alt_ser_no_0", "_txt_ac_ser_no_2", "_txt_ac_ser_no_1", "txt_ac_id", "_txt_ac_ser_no_0", "_txt_ac_reg_no_0", "_txt_ac_year_1", "_lbl_gen_241", "_lbl_gen_5", "_lbl_gen_119", "_lbl_gen_108", "_lbl_gen_17", "_lbl_gen_95", "_lbl_gen_97", "_lbl_gen_30", "_lbl_gen_3", "_lbl_gen_4", "_lbl_gen_240", "_pnl_gen_0", "cmd_Save", "txt_ac_model_config", "txtHistoryDate", "txt_amod_type_code", "cbo_amod_make_name", "_lbl_gen_56", "_Label1_0", "_lbl_gen_102", "_lbl_gen_42", "_lbl_gen_84", "_lbl_gen_0", "_lbl_gen_199", "_pnl_gen_5", "acTimer1", "tbr_ToolBar_Buttons_Button1", "tbr_ToolBar_Buttons_Button2", "tbr_ToolBar_Buttons_Button3", "tbr_ToolBar_Buttons_Button4", "tbr_ToolBar_Buttons_Button5", "tbr_ToolBar_Buttons_Button6", "tbr_ToolBar_Buttons_Button7", "tbr_ToolBar_Buttons_Button8", "tbr_ToolBar", "_lbl_gen_85", "pnl_Please_Wait", "Label1", "cboAcctRep", "cbo_drop_array", "chkArray", "chk_ac_aport_private", "chk_ac_product", "cmdAddACDetail", "cmdHelicopter", "cmdSaveDocNotes", "cmdSaveLease", "cmd_Add_Cert", "cmd_Av_Add", "grd_Features", "grd_pubs", "lbl_gen", "mnuChangeContactType", "pnl_gen", "txtDocNotes", "txt_ac_alt_ser_no", "txt_ac_apu", "txt_ac_engine_ser_no", "txt_ac_engine_shi_hrs", "txt_ac_engine_shs_cycles", "txt_ac_engine_snew_cycles", "txt_ac_engine_soh_cycles", "txt_ac_engine_soh_hrs", "txt_ac_engine_tbo_hrs", "txt_ac_engine_tot_hrs", "txt_ac_lease_type", "txt_ac_prop_ser_no", "txt_ac_prop_snew_hrs", "txt_ac_prop_soh_hrs", "txt_ac_prop_soh_mo", "txt_ac_prop_soh_year", "txt_ac_reg_no", "txt_ac_ser_no", "txt_ac_year", "txt_acfaa_party_comp_name", "txt_acfaa_reg_no", "txt_acfaa_reg_status", "txt_gen", "Ctx_mnuHistoricalTransaction", "Ctx_mnuCompTransmits", "listBoxComboBoxHelper1", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFileLogout;
		public System.Windows.Forms.ToolStripMenuItem mnu_File;
		public System.Windows.Forms.ToolStripMenuItem mnuSendAsOwner;
		public System.Windows.Forms.ToolStripMenuItem mnuSendAsOperator;
		public System.Windows.Forms.ToolStripMenuItem mnuSendAsChiefPilot;
		public System.Windows.Forms.ToolStripMenuItem mnuSendAsExclusiveBroker;
		public System.Windows.Forms.ToolStripMenuItem mnuSendAsExclusiveRepresentative;
		public System.Windows.Forms.ToolStripMenuItem mnuSendAsAdditional1;
		public System.Windows.Forms.ToolStripMenuItem mnuSendAsAdditional2;
		public System.Windows.Forms.ToolStripMenuItem mnuSendAsAdditional3;
		public System.Windows.Forms.ToolStripMenuItem mnuSendAsRegisteredAsOwner;
		public System.Windows.Forms.ToolStripMenuItem mnuSendAsPurchaser;
		public System.Windows.Forms.ToolStripMenuItem mnuSendAsRegisteredAsPurchaser;
		public System.Windows.Forms.ToolStripMenuItem mnuDoNotSend;
		public System.Windows.Forms.ToolStripMenuItem mnuChangePercentage;
		public System.Windows.Forms.ToolStripMenuItem mnuChangeBusinessType;
		public System.Windows.Forms.ToolStripMenuItem mnuChangeOperator;
		public System.Windows.Forms.ToolStripMenuItem mnuCompTransmits;
		public System.Windows.Forms.ToolStripMenuItem mnuEditNewJournal;
		public System.Windows.Forms.ToolStripMenuItem mnuEditAddNote;
		public System.Windows.Forms.ToolStripMenuItem mnuUpdateAwaitingDocs;
		public System.Windows.Forms.ToolStripMenuItem mnuAddExclusiveBroker;
		public System.Windows.Forms.ToolStripMenuItem mnuRemoveExclusive;
		public System.Windows.Forms.ToolStripMenuItem mnuDeleteHistoricalRecord;
		public System.Windows.Forms.ToolStripMenuItem mnuDocumentJournal;
		public System.Windows.Forms.ToolStripMenuItem mnuAddAircraftDeliveryNote;
		public System.Windows.Forms.ToolStripMenuItem mnuEditRegNbrRequestToFAA;
		public System.Windows.Forms.ToolStripMenuItem mnuenterprice;
		public System.Windows.Forms.ToolStripMenuItem mnuremoveprice;
		public System.Windows.Forms.ToolStripMenuItem mnuAddIDNote;
		public System.Windows.Forms.ToolStripMenuItem cmdaddnote;
		public System.Windows.Forms.ToolStripMenuItem mnu_Edit;
		public System.Windows.Forms.ToolStripMenuItem mnuViewAircraftLookup;
		public System.Windows.Forms.ToolStripMenuItem mnuEvents;
		public System.Windows.Forms.ToolStripMenuItem mnuFAAFlightData;
		public System.Windows.Forms.ToolStripMenuItem mnuSalePrices;
		public System.Windows.Forms.ToolStripMenuItem mnuhomebase;
		public System.Windows.Forms.ToolStripMenuItem mnuView;
		public System.Windows.Forms.ToolStripMenuItem mnueditchange;
		public System.Windows.Forms.ToolStripMenuItem mnueditchangeFractional;
		public System.Windows.Forms.ToolStripMenuItem mnueditchangeShare;
		public System.Windows.Forms.ToolStripMenuItem mnueditchangeSieze;
		public System.Windows.Forms.ToolStripMenuItem mnueditchangeForeclosure;
		public System.Windows.Forms.ToolStripMenuItem mnueditchangeDelivery;
		public System.Windows.Forms.ToolStripMenuItem mnueditchangeLease;
		public System.Windows.Forms.ToolStripMenuItem mnuTransmit;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_0;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_8;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_12;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_13;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_27;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_39;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_51;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_52;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_53;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_54;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_56;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_60;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_61;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_62;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_69;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_70;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_91;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_95;
		private System.Windows.Forms.ToolStripMenuItem _mnuChangeContactType_96;
		public System.Windows.Forms.ToolStripMenuItem mnuConvertFSPEND;
		public System.Windows.Forms.ToolStripMenuItem mnuChangeHistPercentage;
		public System.Windows.Forms.ToolStripMenuItem mnuHistoricalTransaction;
		public System.Windows.Forms.ToolStripMenuItem mnuTransactions;
		public System.Windows.Forms.ToolStripMenuItem mnureport;
		public System.Windows.Forms.ToolStripMenuItem mnuPubs;
		public System.Windows.Forms.ToolStripMenuItem mnuAttachedSpecs;
		public System.Windows.Forms.ToolStripMenuItem mnu_Help;
		public System.Windows.Forms.ToolStripMenuItem cmdAircraftSearch;
		public System.Windows.Forms.ToolStripMenuItem mnuAircraftShowUserHistory;
		public System.Windows.Forms.ToolStripMenuItem mnurestoreacavailable;
		public System.Windows.Forms.ToolStripMenuItem mnuTools;
		public System.Windows.Forms.MenuStrip MainMenu1;
		private System.Windows.Forms.Label _lbl_gen_44;
		private System.Windows.Forms.Label _lbl_gen_34;
		private System.Windows.Forms.Label _lbl_gen_238;
		private System.Windows.Forms.Label _lbl_gen_239;
		private System.Windows.Forms.Label _lbl_gen_231;
		private System.Windows.Forms.Label _lbl_gen_230;
		private System.Windows.Forms.Label _lbl_gen_54;
		private System.Windows.Forms.Label _lbl_gen_20;
		private System.Windows.Forms.Label _lbl_gen_19;
		private System.Windows.Forms.Label _lbl_gen_262;
		private System.Windows.Forms.Label _lbl_gen_261;
		private System.Windows.Forms.Label _lbl_gen_260;
		private System.Windows.Forms.Label _lbl_gen_263;
		private System.Windows.Forms.Label _lbl_gen_103;
		private System.Windows.Forms.Label _lbl_gen_104;
		private System.Windows.Forms.Label _lbl_gen_72;
		private System.Windows.Forms.Label _lbl_gen_73;
		private System.Windows.Forms.Label _lbl_gen_105;
		private System.Windows.Forms.Label _lbl_gen_106;
		private System.Windows.Forms.Label _lbl_gen_107;
		private System.Windows.Forms.Label _lbl_gen_40;
		private System.Windows.Forms.Label _lbl_gen_58;
		private System.Windows.Forms.Label _lbl_gen_28;
		private System.Windows.Forms.Label _lbl_gen_70;
		private System.Windows.Forms.Label _lbl_gen_71;
		private System.Windows.Forms.Label _lbl_gen_59;
		private System.Windows.Forms.Label _lbl_gen_60;
		private System.Windows.Forms.Label _lbl_gen_61;
		private System.Windows.Forms.Label _lbl_gen_62;
		private System.Windows.Forms.Label _lbl_gen_57;
		private System.Windows.Forms.Label _lbl_gen_92;
		private System.Windows.Forms.Label _Label1_1;
		private System.Windows.Forms.Label _lbl_gen_89;
		private System.Windows.Forms.Label _lbl_gen_90;
		private System.Windows.Forms.Label _lbl_gen_26;
		private System.Windows.Forms.Label _lbl_gen_25;
		private System.Windows.Forms.Label _lbl_gen_24;
		private System.Windows.Forms.Label _lbl_gen_23;
		private System.Windows.Forms.Label _lbl_gen_18;
		private System.Windows.Forms.Label _lbl_gen_35;
		private System.Windows.Forms.Label _lbl_gen_117;
		private System.Windows.Forms.Label _lbl_gen_51;
		private UpgradeHelpers.DataGridViewFlex _grd_Features_4;
		private System.Windows.Forms.TextBox _txt_ac_prop_soh_hrs_1;
		private System.Windows.Forms.TextBox _txt_ac_prop_soh_hrs_0;
		private System.Windows.Forms.TextBox _txt_ac_prop_soh_hrs_2;
		private System.Windows.Forms.TextBox _txt_ac_prop_soh_hrs_3;
		private System.Windows.Forms.TextBox _txt_ac_prop_soh_year_2;
		private System.Windows.Forms.TextBox _txt_ac_prop_soh_year_3;
		private System.Windows.Forms.TextBox _txt_ac_prop_soh_year_1;
		private System.Windows.Forms.TextBox _txt_ac_prop_soh_year_0;
		private System.Windows.Forms.TextBox _txt_ac_prop_snew_hrs_1;
		private System.Windows.Forms.TextBox _txt_ac_prop_snew_hrs_0;
		private System.Windows.Forms.TextBox _txt_ac_prop_snew_hrs_2;
		private System.Windows.Forms.TextBox _txt_ac_prop_snew_hrs_3;
		private System.Windows.Forms.TextBox _txt_ac_prop_ser_no_3;
		private System.Windows.Forms.TextBox _txt_ac_prop_ser_no_2;
		private System.Windows.Forms.TextBox _txt_ac_prop_soh_mo_3;
		private System.Windows.Forms.TextBox _txt_ac_prop_soh_mo_2;
		private System.Windows.Forms.TextBox _txt_ac_prop_soh_mo_0;
		private System.Windows.Forms.TextBox _txt_ac_prop_soh_mo_1;
		private System.Windows.Forms.TextBox _txt_ac_prop_ser_no_0;
		private System.Windows.Forms.TextBox _txt_ac_prop_ser_no_1;
		public System.Windows.Forms.TextBox txt_ac_confidential_notes;
		public System.Windows.Forms.ComboBox cbo_ac_apu_maint_prog;
		private System.Windows.Forms.TextBox _txt_ac_apu_0;
		private System.Windows.Forms.TextBox _txt_ac_apu_1;
		private System.Windows.Forms.TextBox _txt_ac_apu_2;
		public System.Windows.Forms.ComboBox cbo_ac_apu_model_name;
		private System.Windows.Forms.TextBox _txt_ac_engine_shs_cycles_3;
		private System.Windows.Forms.TextBox _txt_ac_engine_shs_cycles_2;
		private System.Windows.Forms.TextBox _txt_ac_engine_shs_cycles_1;
		private System.Windows.Forms.TextBox _txt_ac_engine_shs_cycles_0;
		private System.Windows.Forms.TextBox _txt_ac_engine_tot_hrs_0;
		private System.Windows.Forms.TextBox _txt_ac_engine_tot_hrs_1;
		private System.Windows.Forms.TextBox _txt_ac_engine_tot_hrs_2;
		private System.Windows.Forms.TextBox _txt_ac_engine_tot_hrs_3;
		private System.Windows.Forms.TextBox _txt_ac_engine_soh_hrs_0;
		private System.Windows.Forms.TextBox _txt_ac_engine_soh_hrs_1;
		private System.Windows.Forms.TextBox _txt_ac_engine_soh_hrs_2;
		private System.Windows.Forms.TextBox _txt_ac_engine_soh_hrs_3;
		private System.Windows.Forms.TextBox _txt_ac_engine_shi_hrs_0;
		private System.Windows.Forms.TextBox _txt_ac_engine_shi_hrs_1;
		private System.Windows.Forms.TextBox _txt_ac_engine_shi_hrs_2;
		private System.Windows.Forms.TextBox _txt_ac_engine_shi_hrs_3;
		private System.Windows.Forms.TextBox _txt_ac_engine_tbo_hrs_0;
		private System.Windows.Forms.TextBox _txt_ac_engine_tbo_hrs_1;
		private System.Windows.Forms.TextBox _txt_ac_engine_tbo_hrs_2;
		private System.Windows.Forms.TextBox _txt_ac_engine_tbo_hrs_3;
		public System.Windows.Forms.ComboBox cbo_ac_engine_name;
		public System.Windows.Forms.ComboBox cbo_ac_engine_maint_prog;
		private System.Windows.Forms.TextBox _txt_ac_engine_snew_cycles_3;
		private System.Windows.Forms.TextBox _txt_ac_engine_snew_cycles_2;
		private System.Windows.Forms.TextBox _txt_ac_engine_snew_cycles_1;
		private System.Windows.Forms.TextBox _txt_ac_engine_snew_cycles_0;
		private System.Windows.Forms.TextBox _txt_ac_engine_soh_cycles_3;
		private System.Windows.Forms.TextBox _txt_ac_engine_soh_cycles_2;
		private System.Windows.Forms.TextBox _txt_ac_engine_soh_cycles_1;
		private System.Windows.Forms.TextBox _txt_ac_engine_soh_cycles_0;
		public System.Windows.Forms.TextBox txt_ac_times_as_of_date;
		public System.Windows.Forms.TextBox txt_ac_airframe_tot_landings;
		public System.Windows.Forms.TextBox txt_ac_airframe_tot_hrs;
		public System.Windows.Forms.ComboBox cbo_ac_engine_management_prog_EMGP;
		private System.Windows.Forms.Button _cmdHelicopter_0;
		private System.Windows.Forms.Button _cmdHelicopter_1;
		public System.Windows.Forms.TextBox txt_ac_engine_noise_rating;
		private System.Windows.Forms.TextBox _txt_ac_engine_ser_no_3;
		private System.Windows.Forms.TextBox _txt_ac_engine_ser_no_2;
		private System.Windows.Forms.TextBox _txt_ac_engine_ser_no_1;
		private System.Windows.Forms.TextBox _txt_ac_engine_ser_no_0;
		public UpgradeHelpers.DataGridViewFlex GrdHelicopter;
		public System.Windows.Forms.ComboBox cbo_edit_heli;
		public System.Windows.Forms.TextBox txt_edit_heli;
		public System.Windows.Forms.TextBox txt_ac_hidden_asking_price;
		public System.Windows.Forms.CheckBox chk_oncondtbo;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage0;
		private System.Windows.Forms.Label _lbl_gen_120;
		private System.Windows.Forms.Label _lbl_gen_114;
		private System.Windows.Forms.Label _lbl_gen_115;
		private System.Windows.Forms.Label _lbl_gen_116;
		private System.Windows.Forms.Label _lbl_gen_118;
		private System.Windows.Forms.Label _lbl_gen_130;
		private System.Windows.Forms.Label _lbl_gen_64;
		private System.Windows.Forms.Label _lbl_gen_65;
		private System.Windows.Forms.Label _lbl_gen_76;
		private System.Windows.Forms.Label _lbl_gen_87;
		private UpgradeHelpers.DataGridViewFlex _grd_Features_0;
		public UpgradeHelpers.DataGridViewFlex grd_aircraftdamage;
		public UpgradeHelpers.DataGridViewFlex grd_Maintenance;
		public System.Windows.Forms.ComboBox cbo_accert_name;
		private System.Windows.Forms.Button _cmd_Add_Cert_2;
		private System.Windows.Forms.Button _cmd_Add_Cert_0;
		public UpgradeHelpers.DataGridViewFlex grd_Aircraft_Certified;
		private System.Windows.Forms.Label _lbl_gen_101;
		public System.Windows.Forms.Panel pnl_certifications;
		public System.Windows.Forms.TextBox txt_ac_maint_eoh_mo;
		public System.Windows.Forms.TextBox txt_ac_maint_hots_mo;
		public System.Windows.Forms.TextBox txt_ac_maint_hots_by_name;
		public System.Windows.Forms.TextBox txt_ac_maint_eoh_by_name;
		public System.Windows.Forms.TextBox txt_ac_damage_history_notes;
		public System.Windows.Forms.TextBox txt_ac_maint_eoh_year;
		public System.Windows.Forms.TextBox txt_ac_maint_hots_year;
		public System.Windows.Forms.ComboBox cbo_ac_warranty_notes;
		public System.Windows.Forms.ComboBox cbo_ac_airframe_maintenance_prog_AMP;
		public System.Windows.Forms.ComboBox cbo_ac_airframe_maint_tracking_prog_AMTP;
		private System.Windows.Forms.Button _cmdAddACDetail_6;
		public UpgradeHelpers.DataGridViewFlex grd_maint;
		private System.Windows.Forms.Button _cmdAddACDetail_3;
		public System.Windows.Forms.ComboBox cbo_dam;
		private System.Windows.Forms.Button _cmd_Add_Cert_1;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage1;
		private System.Windows.Forms.Label _lbl_gen_27;
		private System.Windows.Forms.Label _lbl_gen_53;
		private System.Windows.Forms.Label _lbl_gen_49;
		private System.Windows.Forms.Label _lbl_gen_46;
		private System.Windows.Forms.Label _lbl_gen_234;
		private System.Windows.Forms.Label _lbl_gen_200;
		private System.Windows.Forms.Label _lbl_gen_236;
		private System.Windows.Forms.Label _lbl_gen_78;
		private System.Windows.Forms.Label _lbl_gen_79;
		private UpgradeHelpers.DataGridViewFlex _grd_Features_1;
		public UpgradeHelpers.DataGridViewFlex grd_Exterior;
		public System.Windows.Forms.TextBox txt_ac_exterior_rating;
		public System.Windows.Forms.TextBox txt_ac_interior_rating;
		public System.Windows.Forms.ComboBox cbo_ac_interior_config_name;
		public System.Windows.Forms.TextBox txt_ac_passenger_count;
		public System.Windows.Forms.TextBox txt_ac_interior_mo;
		public System.Windows.Forms.TextBox txt_ac_exterior_mo;
		public System.Windows.Forms.TextBox txt_ac_interior_doneby_name;
		public System.Windows.Forms.TextBox txt_ac_exterior_doneby_name;
		public System.Windows.Forms.TextBox txt_ac_exterior_year;
		public System.Windows.Forms.TextBox txt_ac_interior_year;
		public UpgradeHelpers.DataGridViewFlex grd_Interior;
		private System.Windows.Forms.Button _cmdAddACDetail_0;
		private System.Windows.Forms.Button _cmdAddACDetail_1;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage2;
		private System.Windows.Forms.Label _lbl_gen_52;
		private System.Windows.Forms.Label _lbl_gen_32;
		private UpgradeHelpers.DataGridViewFlex _grd_Features_2;
		public UpgradeHelpers.DataGridViewFlex grd_Equipment;
		private System.Windows.Forms.Button _cmdAddACDetail_2;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage3;
		private System.Windows.Forms.Button _cmdAddACDetail_4;
		private System.Windows.Forms.Button _cmd_Av_Add_0;
		public System.Windows.Forms.ListBox lst_Avionics;
		private System.Windows.Forms.Button _cmd_Av_Add_2;
		private System.Windows.Forms.Button _cmd_Av_Add_3;
		private System.Windows.Forms.Button _cmd_Av_Add_1;
		public System.Windows.Forms.ComboBox cbo_av_description;
		public System.Windows.Forms.Panel pnl_Av;
		public UpgradeHelpers.DataGridViewFlex grd_AircraftAvionics;
		public UpgradeHelpers.DataGridViewFlex grd_Cockpit;
		private UpgradeHelpers.DataGridViewFlex _grd_Features_3;
		private System.Windows.Forms.Label _lbl_gen_48;
		public System.Windows.Forms.Panel pnl_Cockpit;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage4;
		public System.Windows.Forms.CheckBox chk_verified;
		private System.Windows.Forms.Button _cmdAddACDetail_10;
		public System.Windows.Forms.ComboBox cbo_company_research_contact;
		private System.Windows.Forms.Button _cmdAddACDetail_8;
		public System.Windows.Forms.ComboBox cbo_change_rel;
		private System.Windows.Forms.Button _cmdAddACDetail_7;
		public System.Windows.Forms.Button cmd_Primary;
		public System.Windows.Forms.Button cmd_Confirm_Company;
		public System.Windows.Forms.Button cmd_AssociateCompany;
		public System.Windows.Forms.Button cmd_Remove_Association;
		public System.Windows.Forms.Button cmd_Set_As_Exclusive;
		public System.Windows.Forms.Button cmd_Clear_Exclusive_Confirmation_Company;
		private System.Windows.Forms.Panel _pnl_gen_1;
		public System.Windows.Forms.CheckBox chkShowAllContactInfo;
		private System.Windows.Forms.Button _cmdAddACDetail_5;
		public System.Windows.Forms.ListBox lst_Company;
		public System.Windows.Forms.ListBox lst_Contact;
		private System.Windows.Forms.TextBox _txt_gen_4;
		public System.Windows.Forms.ComboBox cbo_ac_purchase_question;
		private System.Windows.Forms.TextBox _txt_gen_3;
		private System.Windows.Forms.TextBox _txt_gen_2;
		private System.Windows.Forms.TextBox _txt_gen_1;
		private System.Windows.Forms.TextBox _txt_gen_0;
		public UpgradeHelpers.DataGridViewFlex grd_AircraftContacts;
		private System.Windows.Forms.Label _lbl_gen_16;
		private System.Windows.Forms.Panel _pnl_gen_4;
		private System.Windows.Forms.TextBox _txt_ac_lease_type_2;
		private System.Windows.Forms.TextBox _txt_ac_lease_type_1;
		public System.Windows.Forms.TextBox txtLeaseExpireConfirmDate;
		public System.Windows.Forms.CheckBox chkConfirmLeaseExpired;
		public System.Windows.Forms.TextBox txt_ac_lease_expire_date;
		private System.Windows.Forms.TextBox _txt_ac_lease_type_0;
		private System.Windows.Forms.Button _cmdSaveLease_0;
		private System.Windows.Forms.Button _cmdSaveLease_1;
		private System.Windows.Forms.Label _lbl_gen_82;
		private System.Windows.Forms.Label _lbl_gen_224;
		private System.Windows.Forms.Label _lbl_gen_218;
		private System.Windows.Forms.Label _lbl_gen_190;
		private System.Windows.Forms.Label _lbl_gen_217;
		public System.Windows.Forms.Panel pnl_LeaseEntry;
		public System.Windows.Forms.CheckBox chkConfirmedOnly;
		public UpgradeHelpers.DataGridViewFlex grdLeaseInfo;
		private System.Windows.Forms.Label _lbl_gen_38;
		private System.Windows.Forms.Label _lbl_gen_37;
		private System.Windows.Forms.Label _lbl_gen_36;
		private System.Windows.Forms.Label _lbl_gen_29;
		private System.Windows.Forms.Label _lbl_gen_21;
		private System.Windows.Forms.Label _lbl_gen_39;
		private System.Windows.Forms.Label _lbl_gen_43;
		public System.Windows.Forms.Panel pnl_LeaseList;
		private System.Windows.Forms.Label _lbl_gen_55;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage5;
		public System.Windows.Forms.TextBox txtACJournalSearch;
		public System.Windows.Forms.TextBox txt_ac_common_notes;
		public System.Windows.Forms.ComboBox cbo_jcat_subcategory_code;
		public System.Windows.Forms.ComboBox cbo_jcat_category_code;
		public System.Windows.Forms.ComboBox cbo_jcat_account_rep;
		public System.Windows.Forms.TextBox txt_journal_category_start_date;
		public System.Windows.Forms.TextBox txt_journal_category_end_date;
		public System.Windows.Forms.Button cmd_jcat_Redisplay_Journal_List;
		private System.Windows.Forms.CheckBox _chkArray_1;
		public System.Windows.Forms.TextBox txtHowManyJournal;
		public UpgradeHelpers.DataGridViewFlex grd_Aircraft_Journal;
		private System.Windows.Forms.Label _lbl_gen_125;
		private System.Windows.Forms.Label _lbl_gen_233;
		private System.Windows.Forms.Label _lbl_gen_91;
		private System.Windows.Forms.Label _lbl_gen_96;
		private System.Windows.Forms.Label _lbl_gen_99;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage6;
		public System.Windows.Forms.WebBrowser web_OpCosts;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage7;
		public System.Windows.Forms.WebBrowser web_Specs;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage8;
		private System.Windows.Forms.Label _lbl_gen_228;
		private System.Windows.Forms.Label _lbl_gen_227;
		private System.Windows.Forms.Label _lbl_gen_45;
		private System.Windows.Forms.Label _lbl_gen_47;
		public System.Windows.Forms.TextBox txt_acfaa_notes;
		private System.Windows.Forms.TextBox _txt_acfaa_reg_status_3;
		private System.Windows.Forms.TextBox _txt_acfaa_reg_no_3;
		private System.Windows.Forms.TextBox _txt_acfaa_reg_status_2;
		private System.Windows.Forms.TextBox _txt_acfaa_reg_no_2;
		private System.Windows.Forms.TextBox _txt_acfaa_reg_status_1;
		private System.Windows.Forms.TextBox _txt_acfaa_reg_no_1;
		private System.Windows.Forms.TextBox _txt_acfaa_reg_status_0;
		private System.Windows.Forms.TextBox _txt_acfaa_reg_no_0;
		private System.Windows.Forms.TextBox _txt_acfaa_party_comp_name_9;
		private System.Windows.Forms.TextBox _txt_acfaa_party_comp_name_8;
		private System.Windows.Forms.TextBox _txt_acfaa_party_comp_name_7;
		private System.Windows.Forms.TextBox _txt_acfaa_party_comp_name_6;
		private System.Windows.Forms.TextBox _txt_acfaa_party_comp_name_5;
		private System.Windows.Forms.TextBox _txt_acfaa_party_comp_name_4;
		private System.Windows.Forms.TextBox _txt_acfaa_party_comp_name_3;
		private System.Windows.Forms.TextBox _txt_acfaa_party_comp_name_2;
		private System.Windows.Forms.TextBox _txt_acfaa_party_comp_name_1;
		private System.Windows.Forms.TextBox _txt_acfaa_party_comp_name_0;
		private UpgradeHelpers.DataGridViewFlex _grd_pubs_1;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage9;
		private System.Windows.Forms.Button _cmdSaveDocNotes_4;
		private System.Windows.Forms.ComboBox _cbo_drop_array_1;
		public System.Windows.Forms.WebBrowser web_Browser;
		private System.Windows.Forms.TextBox _txtDocNotes_0;
		private System.Windows.Forms.TextBox _txtDocNotes_3;
		public UpgradeHelpers.DataGridViewFlex grd_DocumentLog;
		private System.Windows.Forms.Button _cmdSaveDocNotes_3;
		private System.Windows.Forms.TextBox _txtDocNotes_2;
		private System.Windows.Forms.Button _cmdSaveDocNotes_2;
		public System.Windows.Forms.Button cmd_DocsInProcessRefresh;
		public System.Windows.Forms.Button cmdViewDocumentInSeparateWindow;
		private System.Windows.Forms.Button _cmdSaveDocNotes_0;
		private System.Windows.Forms.ComboBox _cboAcctRep_0;
		public System.Windows.Forms.TextBox txt_customer_notes;
		public System.Windows.Forms.TextBox txt_internal_notes;
		public System.Windows.Forms.Button cmdFinancialDocuments;
		public UpgradeHelpers.DataGridViewFlex grdTransactionDocuments;
		private System.Windows.Forms.Label _lbl_gen_81;
		private System.Windows.Forms.Label _lbl_gen_80;
		public System.Windows.Forms.Panel pnl_TransactionNotes;
		private System.Windows.Forms.Label _lbl_gen_124;
		private System.Windows.Forms.Label _lbl_gen_122;
		private System.Windows.Forms.Label _lbl_gen_94;
		private System.Windows.Forms.Label _lbl_gen_93;
		private System.Windows.Forms.Label _lbl_gen_63;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage10;
		private System.Windows.Forms.TextBox _txtDocNotes_1;
		private System.Windows.Forms.ComboBox _cboAcctRep_1;
		public UpgradeHelpers.DataGridViewFlex grdAircraftDocuments;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage11;
		public System.Windows.Forms.WebBrowser web_Ac1;
		private System.Windows.Forms.Button _cmdSaveDocNotes_6;
		private System.Windows.Forms.Button _cmdSaveDocNotes_5;
		private System.Windows.Forms.Button _cmdSaveDocNotes_1;
		public System.Windows.Forms.ListBox lstAcPictures;
		private System.Windows.Forms.Label _lbl_gen_88;
		public System.Windows.Forms.PictureBox imgACPicture;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage12;
		private System.Windows.Forms.ComboBox _cbo_drop_array_0;
		private UpgradeHelpers.DataGridViewFlex _grd_pubs_0;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage13;
		public System.Windows.Forms.ComboBox cbo_Feature_Options;
		public System.Windows.Forms.TextBox txt_Kfeat_Update_Code;
		public UpgradeHelpers.DataGridViewFlex grd_AircraftKeyFeatures;
		private System.Windows.Forms.TabPage _tab_aircraft_details_TabPage14;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_aircraft_details;
		public System.Windows.Forms.ListBox ac_mapping_list;
		public System.Windows.Forms.TextBox ac_mapping_id;
		public System.Windows.Forms.Button cmd_set_mapping_flag;
		public UpgradeHelpers.Gui.ShapeHelper Shape1;
		private System.Windows.Forms.Label _lbl_gen_110;
		private System.Windows.Forms.Label _lbl_gen_111;
		private System.Windows.Forms.Label _lbl_gen_8;
		private System.Windows.Forms.Label _lbl_gen_7;
		private System.Windows.Forms.Label _lbl_gen_11;
		private System.Windows.Forms.Label _lbl_gen_1;
		private System.Windows.Forms.Label _lbl_gen_2;
		private System.Windows.Forms.Button _cmdAddACDetail_9;
		private System.Windows.Forms.CheckBox _chkArray_2;
		public System.Windows.Forms.TextBox txt_ac_sale_price;
		public System.Windows.Forms.TextBox txt_ac_foreign_currency_price;
		public System.Windows.Forms.ComboBox cbo_ac_foreign_currency_name;
		public System.Windows.Forms.ComboBox cbo_ac_asking;
		public System.Windows.Forms.TextBox txt_ac_asking_price;
		public System.Windows.Forms.TextBox txt_ac_list_date;
		public System.Windows.Forms.ComboBox cbo_ac_delivery;
		private System.Windows.Forms.Label _lbl_gen_75;
		private System.Windows.Forms.Label _lbl_gen_98;
		private System.Windows.Forms.Label _lbl_gen_33;
		private System.Windows.Forms.Label _lbl_gen_31;
		private System.Windows.Forms.Label _lbl_gen_9;
		private System.Windows.Forms.Label _lbl_gen_10;
		private System.Windows.Forms.Label _lbl_gen_6;
		public System.Windows.Forms.Panel pnl_Sale_Data;
		public System.Windows.Forms.ComboBox cbo_ac_status;
		private System.Windows.Forms.CheckBox _chkArray_6;
		public System.Windows.Forms.TextBox txt_ac_purchase_date;
		private System.Windows.Forms.CheckBox _chkArray_5;
		public System.Windows.Forms.TextBox txt_exclusive_verify_date;
		private System.Windows.Forms.CheckBox _chkArray_4;
		public System.Windows.Forms.ComboBox cbo_ac_stage;
		public System.Windows.Forms.ComboBox cbo_ac_owner_type;
		private System.Windows.Forms.CheckBox _chkArray_3;
		private System.Windows.Forms.TabPage _tab_ACMain_TabPage0;
		public System.Windows.Forms.Button cmdModifyTransaction;
		public System.Windows.Forms.Button cmdRetrieveSpecs;
		private System.Windows.Forms.CheckBox _chkArray_0;
		public System.Windows.Forms.Button cmd_Active;
		public UpgradeHelpers.DataGridViewFlex grd_AircraftHistory;
		private System.Windows.Forms.Label _lbl_gen_86;
		private System.Windows.Forms.TabPage _tab_ACMain_TabPage1;
		private System.Windows.Forms.CheckBox _chkArray_7;
		private System.Windows.Forms.CheckBox _chk_ac_aport_private_1;
		private System.Windows.Forms.Label _lbl_gen_50;
		private System.Windows.Forms.Label _lbl_gen_22;
		private System.Windows.Forms.Label _lbl_gen_256;
		private System.Windows.Forms.Label _lbl_gen_245;
		private System.Windows.Forms.Label _lbl_gen_15;
		private System.Windows.Forms.Label _lbl_gen_13;
		private System.Windows.Forms.Label _lbl_gen_14;
		private System.Windows.Forms.Label _lbl_gen_12;
		private System.Windows.Forms.Label _lbl_gen_257;
		private System.Windows.Forms.TabPage _tab_ACMain_TabPage2;
		public System.Windows.Forms.TextBox txtAddlHotBoxNotes;
		public System.Windows.Forms.Button cmdClearResearchAction;
		public System.Windows.Forms.Button cmd_Cancel;
		public System.Windows.Forms.ListBox lst_Research_Action;
		private System.Windows.Forms.Label _lbl_gen_77;
		private System.Windows.Forms.Label _lbl_gen_83;
		public System.Windows.Forms.Panel pnl_Research_Action;
		public System.Windows.Forms.TextBox txt_journal_note;
		public System.Windows.Forms.Button cmd_Journal_Note_Cancel;
		public System.Windows.Forms.Button cmd_Journal_Note_Save;
		public System.Windows.Forms.Panel pnl_Journal;
		private System.Windows.Forms.TabPage _tab_ACMain_TabPage3;
		private System.Windows.Forms.Label _lbl_gen_74;
		private System.Windows.Forms.Label _lbl_gen_69;
		private System.Windows.Forms.Label _lbl_gen_68;
		private System.Windows.Forms.Label _lbl_gen_67;
		private System.Windows.Forms.Label _lbl_gen_66;
		private System.Windows.Forms.Label _lbl_gen_41;
		private System.Windows.Forms.Label _lbl_gen_109;
		private System.Windows.Forms.Label _lbl_gen_112;
		private System.Windows.Forms.Label _lbl_gen_121;
		private System.Windows.Forms.Label _lbl_gen_123;
		public System.Windows.Forms.TextBox txtBaseCity;
		public System.Windows.Forms.TextBox txtBaseAirportName;
		public System.Windows.Forms.TextBox txtICAOCode;
		public System.Windows.Forms.TextBox txtIATACode;
		public System.Windows.Forms.ComboBox cboBaseState;
		public System.Windows.Forms.ComboBox cboBaseCountry;
		private System.Windows.Forms.CheckBox _chk_ac_aport_private_0;
		public System.Windows.Forms.TextBox txtFAAIDCode;
		private System.Windows.Forms.CheckBox _chk_ac_aport_private_2;
		private System.Windows.Forms.TabPage _tab_ACMain_TabPage4;
		private System.Windows.Forms.CheckBox _chk_ac_product_3;
		private System.Windows.Forms.CheckBox _chk_ac_product_5;
		private System.Windows.Forms.CheckBox _chk_ac_product_4;
		private System.Windows.Forms.CheckBox _chk_ac_product_2;
		private System.Windows.Forms.CheckBox _chk_ac_product_1;
		private System.Windows.Forms.CheckBox _chk_ac_product_0;
		private System.Windows.Forms.Label _lbl_gen_113;
		public System.Windows.Forms.GroupBox frm_aircraft_products;
		private System.Windows.Forms.TabPage _tab_ACMain_TabPage5;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_ACMain;
		private System.Windows.Forms.TextBox _txt_ac_reg_no_1;
		private System.Windows.Forms.TextBox _txt_ac_year_2;
		private System.Windows.Forms.TextBox _txt_ac_year_0;
		public System.Windows.Forms.ComboBox cbo_ac_country_of_registration;
		public System.Windows.Forms.TextBox txt_ac_delivery_date;
		public System.Windows.Forms.ComboBox cbo_ac_use_code;
		private System.Windows.Forms.TextBox _txt_ac_alt_ser_no_2;
		private System.Windows.Forms.TextBox _txt_ac_alt_ser_no_1;
		private System.Windows.Forms.TextBox _txt_ac_alt_ser_no_0;
		private System.Windows.Forms.TextBox _txt_ac_ser_no_2;
		private System.Windows.Forms.TextBox _txt_ac_ser_no_1;
		public System.Windows.Forms.TextBox txt_ac_id;
		private System.Windows.Forms.TextBox _txt_ac_ser_no_0;
		private System.Windows.Forms.TextBox _txt_ac_reg_no_0;
		private System.Windows.Forms.TextBox _txt_ac_year_1;
		private System.Windows.Forms.Label _lbl_gen_241;
		private System.Windows.Forms.Label _lbl_gen_5;
		private System.Windows.Forms.Label _lbl_gen_119;
		private System.Windows.Forms.Label _lbl_gen_108;
		private System.Windows.Forms.Label _lbl_gen_17;
		private System.Windows.Forms.Label _lbl_gen_95;
		private System.Windows.Forms.Label _lbl_gen_97;
		private System.Windows.Forms.Label _lbl_gen_30;
		private System.Windows.Forms.Label _lbl_gen_3;
		private System.Windows.Forms.Label _lbl_gen_4;
		private System.Windows.Forms.Label _lbl_gen_240;
		private System.Windows.Forms.Panel _pnl_gen_0;
		public System.Windows.Forms.Button cmd_Save;
		public System.Windows.Forms.TextBox txt_ac_model_config;
		public System.Windows.Forms.TextBox txtHistoryDate;
		public System.Windows.Forms.TextBox txt_amod_type_code;
		public System.Windows.Forms.ComboBox cbo_amod_make_name;
		private System.Windows.Forms.Label _lbl_gen_56;
		private System.Windows.Forms.Label _Label1_0;
		private System.Windows.Forms.Label _lbl_gen_102;
		private System.Windows.Forms.Label _lbl_gen_42;
		private System.Windows.Forms.Label _lbl_gen_84;
		private System.Windows.Forms.Label _lbl_gen_0;
		private System.Windows.Forms.Label _lbl_gen_199;
		private System.Windows.Forms.Panel _pnl_gen_5;
		public System.Windows.Forms.Timer acTimer1;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button1;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button2;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button3;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button4;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button5;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button6;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button7;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button8;
		public System.Windows.Forms.ToolStrip tbr_ToolBar;
		private System.Windows.Forms.Label _lbl_gen_85;
		public System.Windows.Forms.Panel pnl_Please_Wait;
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.ComboBox[] cboAcctRep = new System.Windows.Forms.ComboBox[2];
		public System.Windows.Forms.ComboBox[] cbo_drop_array = new System.Windows.Forms.ComboBox[2];
		public System.Windows.Forms.CheckBox[] chkArray = new System.Windows.Forms.CheckBox[8];
		public System.Windows.Forms.CheckBox[] chk_ac_aport_private = new System.Windows.Forms.CheckBox[3];
		public System.Windows.Forms.CheckBox[] chk_ac_product = new System.Windows.Forms.CheckBox[6];
		public System.Windows.Forms.Button[] cmdAddACDetail = new System.Windows.Forms.Button[11];
		public System.Windows.Forms.Button[] cmdHelicopter = new System.Windows.Forms.Button[2];
		public System.Windows.Forms.Button[] cmdSaveDocNotes = new System.Windows.Forms.Button[7];
		public System.Windows.Forms.Button[] cmdSaveLease = new System.Windows.Forms.Button[2];
		public System.Windows.Forms.Button[] cmd_Add_Cert = new System.Windows.Forms.Button[3];
		public System.Windows.Forms.Button[] cmd_Av_Add = new System.Windows.Forms.Button[4];
		public UpgradeHelpers.DataGridViewFlex[] grd_Features = new UpgradeHelpers.DataGridViewFlex[5];
		public UpgradeHelpers.DataGridViewFlex[] grd_pubs = new UpgradeHelpers.DataGridViewFlex[2];
		public System.Windows.Forms.Label[] lbl_gen = new System.Windows.Forms.Label[264];
		public System.Windows.Forms.ToolStripItem[] mnuChangeContactType = new System.Windows.Forms.ToolStripItem[97];
		public System.Windows.Forms.Panel[] pnl_gen = new System.Windows.Forms.Panel[6];
		public System.Windows.Forms.TextBox[] txtDocNotes = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_alt_ser_no = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] txt_ac_apu = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] txt_ac_engine_ser_no = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_engine_shi_hrs = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_engine_shs_cycles = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_engine_snew_cycles = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_engine_soh_cycles = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_engine_soh_hrs = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_engine_tbo_hrs = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_engine_tot_hrs = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_lease_type = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] txt_ac_prop_ser_no = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_prop_snew_hrs = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_prop_soh_hrs = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_prop_soh_mo = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_prop_soh_year = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_ac_reg_no = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.TextBox[] txt_ac_ser_no = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] txt_ac_year = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] txt_acfaa_party_comp_name = new System.Windows.Forms.TextBox[10];
		public System.Windows.Forms.TextBox[] txt_acfaa_reg_no = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_acfaa_reg_status = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_gen = new System.Windows.Forms.TextBox[5];
		public System.Windows.Forms.ContextMenuStrip Ctx_mnuHistoricalTransaction;
		public System.Windows.Forms.ContextMenuStrip Ctx_mnuCompTransmits;
		public UpgradeHelpers.Gui.Controls.ListControlHelper listBoxComboBoxHelper1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		private int tab_Aircraft_DetailsPreviousTab;
		private int tab_ACMainPreviousTab;
		public System.ComponentModel.ComponentResourceManager resources;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_aircraft));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnu_File = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileLogout = new System.Windows.Forms.ToolStripMenuItem();
			mnu_Edit = new System.Windows.Forms.ToolStripMenuItem();
			mnuCompTransmits = new System.Windows.Forms.ToolStripMenuItem();
			mnuSendAsOwner = new System.Windows.Forms.ToolStripMenuItem();
			mnuSendAsOperator = new System.Windows.Forms.ToolStripMenuItem();
			mnuSendAsChiefPilot = new System.Windows.Forms.ToolStripMenuItem();
			mnuSendAsExclusiveBroker = new System.Windows.Forms.ToolStripMenuItem();
			mnuSendAsExclusiveRepresentative = new System.Windows.Forms.ToolStripMenuItem();
			mnuSendAsAdditional1 = new System.Windows.Forms.ToolStripMenuItem();
			mnuSendAsAdditional2 = new System.Windows.Forms.ToolStripMenuItem();
			mnuSendAsAdditional3 = new System.Windows.Forms.ToolStripMenuItem();
			mnuSendAsRegisteredAsOwner = new System.Windows.Forms.ToolStripMenuItem();
			mnuSendAsPurchaser = new System.Windows.Forms.ToolStripMenuItem();
			mnuSendAsRegisteredAsPurchaser = new System.Windows.Forms.ToolStripMenuItem();
			mnuDoNotSend = new System.Windows.Forms.ToolStripMenuItem();
			mnuChangePercentage = new System.Windows.Forms.ToolStripMenuItem();
			mnuChangeBusinessType = new System.Windows.Forms.ToolStripMenuItem();
			mnuChangeOperator = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditNewJournal = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditAddNote = new System.Windows.Forms.ToolStripMenuItem();
			mnuUpdateAwaitingDocs = new System.Windows.Forms.ToolStripMenuItem();
			mnuAddExclusiveBroker = new System.Windows.Forms.ToolStripMenuItem();
			mnuRemoveExclusive = new System.Windows.Forms.ToolStripMenuItem();
			mnuDeleteHistoricalRecord = new System.Windows.Forms.ToolStripMenuItem();
			mnuDocumentJournal = new System.Windows.Forms.ToolStripMenuItem();
			mnuAddAircraftDeliveryNote = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditRegNbrRequestToFAA = new System.Windows.Forms.ToolStripMenuItem();
			mnuenterprice = new System.Windows.Forms.ToolStripMenuItem();
			mnuremoveprice = new System.Windows.Forms.ToolStripMenuItem();
			mnuAddIDNote = new System.Windows.Forms.ToolStripMenuItem();
			cmdaddnote = new System.Windows.Forms.ToolStripMenuItem();
			mnuView = new System.Windows.Forms.ToolStripMenuItem();
			mnuViewAircraftLookup = new System.Windows.Forms.ToolStripMenuItem();
			mnuEvents = new System.Windows.Forms.ToolStripMenuItem();
			mnuFAAFlightData = new System.Windows.Forms.ToolStripMenuItem();
			mnuSalePrices = new System.Windows.Forms.ToolStripMenuItem();
			mnuhomebase = new System.Windows.Forms.ToolStripMenuItem();
			mnuTransactions = new System.Windows.Forms.ToolStripMenuItem();
			mnueditchange = new System.Windows.Forms.ToolStripMenuItem();
			mnueditchangeFractional = new System.Windows.Forms.ToolStripMenuItem();
			mnueditchangeShare = new System.Windows.Forms.ToolStripMenuItem();
			mnueditchangeSieze = new System.Windows.Forms.ToolStripMenuItem();
			mnueditchangeForeclosure = new System.Windows.Forms.ToolStripMenuItem();
			mnueditchangeDelivery = new System.Windows.Forms.ToolStripMenuItem();
			mnueditchangeLease = new System.Windows.Forms.ToolStripMenuItem();
			mnuTransmit = new System.Windows.Forms.ToolStripMenuItem();
			mnuHistoricalTransaction = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_0 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_8 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_12 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_13 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_27 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_39 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_51 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_52 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_53 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_54 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_56 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_60 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_61 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_62 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_69 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_70 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_91 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_95 = new System.Windows.Forms.ToolStripMenuItem();
			_mnuChangeContactType_96 = new System.Windows.Forms.ToolStripMenuItem();
			mnuConvertFSPEND = new System.Windows.Forms.ToolStripMenuItem();
			mnuChangeHistPercentage = new System.Windows.Forms.ToolStripMenuItem();
			mnureport = new System.Windows.Forms.ToolStripMenuItem();
			mnuPubs = new System.Windows.Forms.ToolStripMenuItem();
			mnuAttachedSpecs = new System.Windows.Forms.ToolStripMenuItem();
			mnu_Help = new System.Windows.Forms.ToolStripMenuItem();
			cmdAircraftSearch = new System.Windows.Forms.ToolStripMenuItem();
			mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			mnuAircraftShowUserHistory = new System.Windows.Forms.ToolStripMenuItem();
			mnurestoreacavailable = new System.Windows.Forms.ToolStripMenuItem();
			tab_aircraft_details = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_aircraft_details_TabPage0 = new System.Windows.Forms.TabPage();
			_lbl_gen_44 = new System.Windows.Forms.Label();
			_lbl_gen_34 = new System.Windows.Forms.Label();
			_lbl_gen_238 = new System.Windows.Forms.Label();
			_lbl_gen_239 = new System.Windows.Forms.Label();
			_lbl_gen_231 = new System.Windows.Forms.Label();
			_lbl_gen_230 = new System.Windows.Forms.Label();
			_lbl_gen_54 = new System.Windows.Forms.Label();
			_lbl_gen_20 = new System.Windows.Forms.Label();
			_lbl_gen_19 = new System.Windows.Forms.Label();
			_lbl_gen_262 = new System.Windows.Forms.Label();
			_lbl_gen_261 = new System.Windows.Forms.Label();
			_lbl_gen_260 = new System.Windows.Forms.Label();
			_lbl_gen_263 = new System.Windows.Forms.Label();
			_lbl_gen_103 = new System.Windows.Forms.Label();
			_lbl_gen_104 = new System.Windows.Forms.Label();
			_lbl_gen_72 = new System.Windows.Forms.Label();
			_lbl_gen_73 = new System.Windows.Forms.Label();
			_lbl_gen_105 = new System.Windows.Forms.Label();
			_lbl_gen_106 = new System.Windows.Forms.Label();
			_lbl_gen_107 = new System.Windows.Forms.Label();
			_lbl_gen_40 = new System.Windows.Forms.Label();
			_lbl_gen_58 = new System.Windows.Forms.Label();
			_lbl_gen_28 = new System.Windows.Forms.Label();
			_lbl_gen_70 = new System.Windows.Forms.Label();
			_lbl_gen_71 = new System.Windows.Forms.Label();
			_lbl_gen_59 = new System.Windows.Forms.Label();
			_lbl_gen_60 = new System.Windows.Forms.Label();
			_lbl_gen_61 = new System.Windows.Forms.Label();
			_lbl_gen_62 = new System.Windows.Forms.Label();
			_lbl_gen_57 = new System.Windows.Forms.Label();
			_lbl_gen_92 = new System.Windows.Forms.Label();
			_Label1_1 = new System.Windows.Forms.Label();
			_lbl_gen_89 = new System.Windows.Forms.Label();
			_lbl_gen_90 = new System.Windows.Forms.Label();
			_lbl_gen_26 = new System.Windows.Forms.Label();
			_lbl_gen_25 = new System.Windows.Forms.Label();
			_lbl_gen_24 = new System.Windows.Forms.Label();
			_lbl_gen_23 = new System.Windows.Forms.Label();
			_lbl_gen_18 = new System.Windows.Forms.Label();
			_lbl_gen_35 = new System.Windows.Forms.Label();
			_lbl_gen_117 = new System.Windows.Forms.Label();
			_lbl_gen_51 = new System.Windows.Forms.Label();
			_grd_Features_4 = new UpgradeHelpers.DataGridViewFlex(components);
			_txt_ac_prop_soh_hrs_1 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_soh_hrs_0 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_soh_hrs_2 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_soh_hrs_3 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_soh_year_2 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_soh_year_3 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_soh_year_1 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_soh_year_0 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_snew_hrs_1 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_snew_hrs_0 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_snew_hrs_2 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_snew_hrs_3 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_ser_no_3 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_ser_no_2 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_soh_mo_3 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_soh_mo_2 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_soh_mo_0 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_soh_mo_1 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_ser_no_0 = new System.Windows.Forms.TextBox();
			_txt_ac_prop_ser_no_1 = new System.Windows.Forms.TextBox();
			txt_ac_confidential_notes = new System.Windows.Forms.TextBox();
			cbo_ac_apu_maint_prog = new System.Windows.Forms.ComboBox();
			_txt_ac_apu_0 = new System.Windows.Forms.TextBox();
			_txt_ac_apu_1 = new System.Windows.Forms.TextBox();
			_txt_ac_apu_2 = new System.Windows.Forms.TextBox();
			cbo_ac_apu_model_name = new System.Windows.Forms.ComboBox();
			_txt_ac_engine_shs_cycles_3 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_shs_cycles_2 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_shs_cycles_1 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_shs_cycles_0 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_tot_hrs_0 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_tot_hrs_1 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_tot_hrs_2 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_tot_hrs_3 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_soh_hrs_0 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_soh_hrs_1 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_soh_hrs_2 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_soh_hrs_3 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_shi_hrs_0 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_shi_hrs_1 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_shi_hrs_2 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_shi_hrs_3 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_tbo_hrs_0 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_tbo_hrs_1 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_tbo_hrs_2 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_tbo_hrs_3 = new System.Windows.Forms.TextBox();
			cbo_ac_engine_name = new System.Windows.Forms.ComboBox();
			cbo_ac_engine_maint_prog = new System.Windows.Forms.ComboBox();
			_txt_ac_engine_snew_cycles_3 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_snew_cycles_2 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_snew_cycles_1 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_snew_cycles_0 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_soh_cycles_3 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_soh_cycles_2 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_soh_cycles_1 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_soh_cycles_0 = new System.Windows.Forms.TextBox();
			txt_ac_times_as_of_date = new System.Windows.Forms.TextBox();
			txt_ac_airframe_tot_landings = new System.Windows.Forms.TextBox();
			txt_ac_airframe_tot_hrs = new System.Windows.Forms.TextBox();
			cbo_ac_engine_management_prog_EMGP = new System.Windows.Forms.ComboBox();
			_cmdHelicopter_0 = new System.Windows.Forms.Button();
			_cmdHelicopter_1 = new System.Windows.Forms.Button();
			txt_ac_engine_noise_rating = new System.Windows.Forms.TextBox();
			_txt_ac_engine_ser_no_3 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_ser_no_2 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_ser_no_1 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_ser_no_0 = new System.Windows.Forms.TextBox();
			GrdHelicopter = new UpgradeHelpers.DataGridViewFlex(components);
			cbo_edit_heli = new System.Windows.Forms.ComboBox();
			txt_edit_heli = new System.Windows.Forms.TextBox();
			txt_ac_hidden_asking_price = new System.Windows.Forms.TextBox();
			chk_oncondtbo = new System.Windows.Forms.CheckBox();
			_tab_aircraft_details_TabPage1 = new System.Windows.Forms.TabPage();
			_lbl_gen_120 = new System.Windows.Forms.Label();
			_lbl_gen_114 = new System.Windows.Forms.Label();
			_lbl_gen_115 = new System.Windows.Forms.Label();
			_lbl_gen_116 = new System.Windows.Forms.Label();
			_lbl_gen_118 = new System.Windows.Forms.Label();
			_lbl_gen_130 = new System.Windows.Forms.Label();
			_lbl_gen_64 = new System.Windows.Forms.Label();
			_lbl_gen_65 = new System.Windows.Forms.Label();
			_lbl_gen_76 = new System.Windows.Forms.Label();
			_lbl_gen_87 = new System.Windows.Forms.Label();
			_grd_Features_0 = new UpgradeHelpers.DataGridViewFlex(components);
			grd_aircraftdamage = new UpgradeHelpers.DataGridViewFlex(components);
			grd_Maintenance = new UpgradeHelpers.DataGridViewFlex(components);
			pnl_certifications = new System.Windows.Forms.Panel();
			cbo_accert_name = new System.Windows.Forms.ComboBox();
			_cmd_Add_Cert_2 = new System.Windows.Forms.Button();
			_cmd_Add_Cert_0 = new System.Windows.Forms.Button();
			grd_Aircraft_Certified = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_101 = new System.Windows.Forms.Label();
			txt_ac_maint_eoh_mo = new System.Windows.Forms.TextBox();
			txt_ac_maint_hots_mo = new System.Windows.Forms.TextBox();
			txt_ac_maint_hots_by_name = new System.Windows.Forms.TextBox();
			txt_ac_maint_eoh_by_name = new System.Windows.Forms.TextBox();
			txt_ac_damage_history_notes = new System.Windows.Forms.TextBox();
			txt_ac_maint_eoh_year = new System.Windows.Forms.TextBox();
			txt_ac_maint_hots_year = new System.Windows.Forms.TextBox();
			cbo_ac_warranty_notes = new System.Windows.Forms.ComboBox();
			cbo_ac_airframe_maintenance_prog_AMP = new System.Windows.Forms.ComboBox();
			cbo_ac_airframe_maint_tracking_prog_AMTP = new System.Windows.Forms.ComboBox();
			_cmdAddACDetail_6 = new System.Windows.Forms.Button();
			grd_maint = new UpgradeHelpers.DataGridViewFlex(components);
			_cmdAddACDetail_3 = new System.Windows.Forms.Button();
			cbo_dam = new System.Windows.Forms.ComboBox();
			_cmd_Add_Cert_1 = new System.Windows.Forms.Button();
			_tab_aircraft_details_TabPage2 = new System.Windows.Forms.TabPage();
			_lbl_gen_27 = new System.Windows.Forms.Label();
			_lbl_gen_53 = new System.Windows.Forms.Label();
			_lbl_gen_49 = new System.Windows.Forms.Label();
			_lbl_gen_46 = new System.Windows.Forms.Label();
			_lbl_gen_234 = new System.Windows.Forms.Label();
			_lbl_gen_200 = new System.Windows.Forms.Label();
			_lbl_gen_236 = new System.Windows.Forms.Label();
			_lbl_gen_78 = new System.Windows.Forms.Label();
			_lbl_gen_79 = new System.Windows.Forms.Label();
			_grd_Features_1 = new UpgradeHelpers.DataGridViewFlex(components);
			grd_Exterior = new UpgradeHelpers.DataGridViewFlex(components);
			txt_ac_exterior_rating = new System.Windows.Forms.TextBox();
			txt_ac_interior_rating = new System.Windows.Forms.TextBox();
			cbo_ac_interior_config_name = new System.Windows.Forms.ComboBox();
			txt_ac_passenger_count = new System.Windows.Forms.TextBox();
			txt_ac_interior_mo = new System.Windows.Forms.TextBox();
			txt_ac_exterior_mo = new System.Windows.Forms.TextBox();
			txt_ac_interior_doneby_name = new System.Windows.Forms.TextBox();
			txt_ac_exterior_doneby_name = new System.Windows.Forms.TextBox();
			txt_ac_exterior_year = new System.Windows.Forms.TextBox();
			txt_ac_interior_year = new System.Windows.Forms.TextBox();
			grd_Interior = new UpgradeHelpers.DataGridViewFlex(components);
			_cmdAddACDetail_0 = new System.Windows.Forms.Button();
			_cmdAddACDetail_1 = new System.Windows.Forms.Button();
			_tab_aircraft_details_TabPage3 = new System.Windows.Forms.TabPage();
			_lbl_gen_52 = new System.Windows.Forms.Label();
			_lbl_gen_32 = new System.Windows.Forms.Label();
			_grd_Features_2 = new UpgradeHelpers.DataGridViewFlex(components);
			grd_Equipment = new UpgradeHelpers.DataGridViewFlex(components);
			_cmdAddACDetail_2 = new System.Windows.Forms.Button();
			_tab_aircraft_details_TabPage4 = new System.Windows.Forms.TabPage();
			pnl_Cockpit = new System.Windows.Forms.Panel();
			_cmdAddACDetail_4 = new System.Windows.Forms.Button();
			_cmd_Av_Add_0 = new System.Windows.Forms.Button();
			pnl_Av = new System.Windows.Forms.Panel();
			lst_Avionics = new System.Windows.Forms.ListBox();
			_cmd_Av_Add_2 = new System.Windows.Forms.Button();
			_cmd_Av_Add_3 = new System.Windows.Forms.Button();
			_cmd_Av_Add_1 = new System.Windows.Forms.Button();
			cbo_av_description = new System.Windows.Forms.ComboBox();
			grd_AircraftAvionics = new UpgradeHelpers.DataGridViewFlex(components);
			grd_Cockpit = new UpgradeHelpers.DataGridViewFlex(components);
			_grd_Features_3 = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_48 = new System.Windows.Forms.Label();
			_tab_aircraft_details_TabPage5 = new System.Windows.Forms.TabPage();
			chk_verified = new System.Windows.Forms.CheckBox();
			_cmdAddACDetail_10 = new System.Windows.Forms.Button();
			cbo_company_research_contact = new System.Windows.Forms.ComboBox();
			_cmdAddACDetail_8 = new System.Windows.Forms.Button();
			cbo_change_rel = new System.Windows.Forms.ComboBox();
			_cmdAddACDetail_7 = new System.Windows.Forms.Button();
			_pnl_gen_1 = new System.Windows.Forms.Panel();
			cmd_Primary = new System.Windows.Forms.Button();
			cmd_Confirm_Company = new System.Windows.Forms.Button();
			cmd_AssociateCompany = new System.Windows.Forms.Button();
			cmd_Remove_Association = new System.Windows.Forms.Button();
			cmd_Set_As_Exclusive = new System.Windows.Forms.Button();
			cmd_Clear_Exclusive_Confirmation_Company = new System.Windows.Forms.Button();
			chkShowAllContactInfo = new System.Windows.Forms.CheckBox();
			_cmdAddACDetail_5 = new System.Windows.Forms.Button();
			lst_Company = new System.Windows.Forms.ListBox();
			lst_Contact = new System.Windows.Forms.ListBox();
			_pnl_gen_4 = new System.Windows.Forms.Panel();
			_txt_gen_4 = new System.Windows.Forms.TextBox();
			cbo_ac_purchase_question = new System.Windows.Forms.ComboBox();
			_txt_gen_3 = new System.Windows.Forms.TextBox();
			_txt_gen_2 = new System.Windows.Forms.TextBox();
			_txt_gen_1 = new System.Windows.Forms.TextBox();
			_txt_gen_0 = new System.Windows.Forms.TextBox();
			grd_AircraftContacts = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_16 = new System.Windows.Forms.Label();
			pnl_LeaseEntry = new System.Windows.Forms.Panel();
			_txt_ac_lease_type_2 = new System.Windows.Forms.TextBox();
			_txt_ac_lease_type_1 = new System.Windows.Forms.TextBox();
			txtLeaseExpireConfirmDate = new System.Windows.Forms.TextBox();
			chkConfirmLeaseExpired = new System.Windows.Forms.CheckBox();
			txt_ac_lease_expire_date = new System.Windows.Forms.TextBox();
			_txt_ac_lease_type_0 = new System.Windows.Forms.TextBox();
			_cmdSaveLease_0 = new System.Windows.Forms.Button();
			_cmdSaveLease_1 = new System.Windows.Forms.Button();
			_lbl_gen_82 = new System.Windows.Forms.Label();
			_lbl_gen_224 = new System.Windows.Forms.Label();
			_lbl_gen_218 = new System.Windows.Forms.Label();
			_lbl_gen_190 = new System.Windows.Forms.Label();
			_lbl_gen_217 = new System.Windows.Forms.Label();
			pnl_LeaseList = new System.Windows.Forms.Panel();
			chkConfirmedOnly = new System.Windows.Forms.CheckBox();
			grdLeaseInfo = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_38 = new System.Windows.Forms.Label();
			_lbl_gen_37 = new System.Windows.Forms.Label();
			_lbl_gen_36 = new System.Windows.Forms.Label();
			_lbl_gen_29 = new System.Windows.Forms.Label();
			_lbl_gen_21 = new System.Windows.Forms.Label();
			_lbl_gen_39 = new System.Windows.Forms.Label();
			_lbl_gen_43 = new System.Windows.Forms.Label();
			_lbl_gen_55 = new System.Windows.Forms.Label();
			_tab_aircraft_details_TabPage6 = new System.Windows.Forms.TabPage();
			txtACJournalSearch = new System.Windows.Forms.TextBox();
			txt_ac_common_notes = new System.Windows.Forms.TextBox();
			cbo_jcat_subcategory_code = new System.Windows.Forms.ComboBox();
			cbo_jcat_category_code = new System.Windows.Forms.ComboBox();
			cbo_jcat_account_rep = new System.Windows.Forms.ComboBox();
			txt_journal_category_start_date = new System.Windows.Forms.TextBox();
			txt_journal_category_end_date = new System.Windows.Forms.TextBox();
			cmd_jcat_Redisplay_Journal_List = new System.Windows.Forms.Button();
			_chkArray_1 = new System.Windows.Forms.CheckBox();
			txtHowManyJournal = new System.Windows.Forms.TextBox();
			grd_Aircraft_Journal = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_125 = new System.Windows.Forms.Label();
			_lbl_gen_233 = new System.Windows.Forms.Label();
			_lbl_gen_91 = new System.Windows.Forms.Label();
			_lbl_gen_96 = new System.Windows.Forms.Label();
			_lbl_gen_99 = new System.Windows.Forms.Label();
			_tab_aircraft_details_TabPage7 = new System.Windows.Forms.TabPage();
			web_OpCosts = new System.Windows.Forms.WebBrowser();
			_tab_aircraft_details_TabPage8 = new System.Windows.Forms.TabPage();
			web_Specs = new System.Windows.Forms.WebBrowser();
			_tab_aircraft_details_TabPage9 = new System.Windows.Forms.TabPage();
			_lbl_gen_228 = new System.Windows.Forms.Label();
			_lbl_gen_227 = new System.Windows.Forms.Label();
			_lbl_gen_45 = new System.Windows.Forms.Label();
			_lbl_gen_47 = new System.Windows.Forms.Label();
			txt_acfaa_notes = new System.Windows.Forms.TextBox();
			_txt_acfaa_reg_status_3 = new System.Windows.Forms.TextBox();
			_txt_acfaa_reg_no_3 = new System.Windows.Forms.TextBox();
			_txt_acfaa_reg_status_2 = new System.Windows.Forms.TextBox();
			_txt_acfaa_reg_no_2 = new System.Windows.Forms.TextBox();
			_txt_acfaa_reg_status_1 = new System.Windows.Forms.TextBox();
			_txt_acfaa_reg_no_1 = new System.Windows.Forms.TextBox();
			_txt_acfaa_reg_status_0 = new System.Windows.Forms.TextBox();
			_txt_acfaa_reg_no_0 = new System.Windows.Forms.TextBox();
			_txt_acfaa_party_comp_name_9 = new System.Windows.Forms.TextBox();
			_txt_acfaa_party_comp_name_8 = new System.Windows.Forms.TextBox();
			_txt_acfaa_party_comp_name_7 = new System.Windows.Forms.TextBox();
			_txt_acfaa_party_comp_name_6 = new System.Windows.Forms.TextBox();
			_txt_acfaa_party_comp_name_5 = new System.Windows.Forms.TextBox();
			_txt_acfaa_party_comp_name_4 = new System.Windows.Forms.TextBox();
			_txt_acfaa_party_comp_name_3 = new System.Windows.Forms.TextBox();
			_txt_acfaa_party_comp_name_2 = new System.Windows.Forms.TextBox();
			_txt_acfaa_party_comp_name_1 = new System.Windows.Forms.TextBox();
			_txt_acfaa_party_comp_name_0 = new System.Windows.Forms.TextBox();
			_grd_pubs_1 = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_aircraft_details_TabPage10 = new System.Windows.Forms.TabPage();
			_cmdSaveDocNotes_4 = new System.Windows.Forms.Button();
			_cbo_drop_array_1 = new System.Windows.Forms.ComboBox();
			web_Browser = new System.Windows.Forms.WebBrowser();
			_txtDocNotes_0 = new System.Windows.Forms.TextBox();
			_txtDocNotes_3 = new System.Windows.Forms.TextBox();
			grd_DocumentLog = new UpgradeHelpers.DataGridViewFlex(components);
			_cmdSaveDocNotes_3 = new System.Windows.Forms.Button();
			_txtDocNotes_2 = new System.Windows.Forms.TextBox();
			_cmdSaveDocNotes_2 = new System.Windows.Forms.Button();
			cmd_DocsInProcessRefresh = new System.Windows.Forms.Button();
			cmdViewDocumentInSeparateWindow = new System.Windows.Forms.Button();
			_cmdSaveDocNotes_0 = new System.Windows.Forms.Button();
			_cboAcctRep_0 = new System.Windows.Forms.ComboBox();
			pnl_TransactionNotes = new System.Windows.Forms.Panel();
			txt_customer_notes = new System.Windows.Forms.TextBox();
			txt_internal_notes = new System.Windows.Forms.TextBox();
			cmdFinancialDocuments = new System.Windows.Forms.Button();
			grdTransactionDocuments = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_81 = new System.Windows.Forms.Label();
			_lbl_gen_80 = new System.Windows.Forms.Label();
			_lbl_gen_124 = new System.Windows.Forms.Label();
			_lbl_gen_122 = new System.Windows.Forms.Label();
			_lbl_gen_94 = new System.Windows.Forms.Label();
			_lbl_gen_93 = new System.Windows.Forms.Label();
			_lbl_gen_63 = new System.Windows.Forms.Label();
			_tab_aircraft_details_TabPage11 = new System.Windows.Forms.TabPage();
			_txtDocNotes_1 = new System.Windows.Forms.TextBox();
			_cboAcctRep_1 = new System.Windows.Forms.ComboBox();
			grdAircraftDocuments = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_aircraft_details_TabPage12 = new System.Windows.Forms.TabPage();
			web_Ac1 = new System.Windows.Forms.WebBrowser();
			_cmdSaveDocNotes_6 = new System.Windows.Forms.Button();
			_cmdSaveDocNotes_5 = new System.Windows.Forms.Button();
			_cmdSaveDocNotes_1 = new System.Windows.Forms.Button();
			lstAcPictures = new System.Windows.Forms.ListBox();
			_lbl_gen_88 = new System.Windows.Forms.Label();
			imgACPicture = new System.Windows.Forms.PictureBox();
			_tab_aircraft_details_TabPage13 = new System.Windows.Forms.TabPage();
			_cbo_drop_array_0 = new System.Windows.Forms.ComboBox();
			_grd_pubs_0 = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_aircraft_details_TabPage14 = new System.Windows.Forms.TabPage();
			cbo_Feature_Options = new System.Windows.Forms.ComboBox();
			txt_Kfeat_Update_Code = new System.Windows.Forms.TextBox();
			grd_AircraftKeyFeatures = new UpgradeHelpers.DataGridViewFlex(components);
			tab_ACMain = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			ac_mapping_list = new System.Windows.Forms.ListBox();
			ac_mapping_id = new System.Windows.Forms.TextBox();
			cmd_set_mapping_flag = new System.Windows.Forms.Button();
			Shape1 = new UpgradeHelpers.Gui.ShapeHelper();
			_lbl_gen_110 = new System.Windows.Forms.Label();
			_lbl_gen_111 = new System.Windows.Forms.Label();
			_tab_ACMain_TabPage0 = new System.Windows.Forms.TabPage();
			_lbl_gen_8 = new System.Windows.Forms.Label();
			_lbl_gen_7 = new System.Windows.Forms.Label();
			_lbl_gen_11 = new System.Windows.Forms.Label();
			_lbl_gen_1 = new System.Windows.Forms.Label();
			_lbl_gen_2 = new System.Windows.Forms.Label();
			pnl_Sale_Data = new System.Windows.Forms.Panel();
			_cmdAddACDetail_9 = new System.Windows.Forms.Button();
			_chkArray_2 = new System.Windows.Forms.CheckBox();
			txt_ac_sale_price = new System.Windows.Forms.TextBox();
			txt_ac_foreign_currency_price = new System.Windows.Forms.TextBox();
			cbo_ac_foreign_currency_name = new System.Windows.Forms.ComboBox();
			cbo_ac_asking = new System.Windows.Forms.ComboBox();
			txt_ac_asking_price = new System.Windows.Forms.TextBox();
			txt_ac_list_date = new System.Windows.Forms.TextBox();
			cbo_ac_delivery = new System.Windows.Forms.ComboBox();
			_lbl_gen_75 = new System.Windows.Forms.Label();
			_lbl_gen_98 = new System.Windows.Forms.Label();
			_lbl_gen_33 = new System.Windows.Forms.Label();
			_lbl_gen_31 = new System.Windows.Forms.Label();
			_lbl_gen_9 = new System.Windows.Forms.Label();
			_lbl_gen_10 = new System.Windows.Forms.Label();
			_lbl_gen_6 = new System.Windows.Forms.Label();
			cbo_ac_status = new System.Windows.Forms.ComboBox();
			_chkArray_6 = new System.Windows.Forms.CheckBox();
			txt_ac_purchase_date = new System.Windows.Forms.TextBox();
			_chkArray_5 = new System.Windows.Forms.CheckBox();
			txt_exclusive_verify_date = new System.Windows.Forms.TextBox();
			_chkArray_4 = new System.Windows.Forms.CheckBox();
			cbo_ac_stage = new System.Windows.Forms.ComboBox();
			cbo_ac_owner_type = new System.Windows.Forms.ComboBox();
			_chkArray_3 = new System.Windows.Forms.CheckBox();
			_tab_ACMain_TabPage1 = new System.Windows.Forms.TabPage();
			cmdModifyTransaction = new System.Windows.Forms.Button();
			cmdRetrieveSpecs = new System.Windows.Forms.Button();
			_chkArray_0 = new System.Windows.Forms.CheckBox();
			cmd_Active = new System.Windows.Forms.Button();
			grd_AircraftHistory = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_86 = new System.Windows.Forms.Label();
			_tab_ACMain_TabPage2 = new System.Windows.Forms.TabPage();
			_chkArray_7 = new System.Windows.Forms.CheckBox();
			_chk_ac_aport_private_1 = new System.Windows.Forms.CheckBox();
			_lbl_gen_50 = new System.Windows.Forms.Label();
			_lbl_gen_22 = new System.Windows.Forms.Label();
			_lbl_gen_256 = new System.Windows.Forms.Label();
			_lbl_gen_245 = new System.Windows.Forms.Label();
			_lbl_gen_15 = new System.Windows.Forms.Label();
			_lbl_gen_13 = new System.Windows.Forms.Label();
			_lbl_gen_14 = new System.Windows.Forms.Label();
			_lbl_gen_12 = new System.Windows.Forms.Label();
			_lbl_gen_257 = new System.Windows.Forms.Label();
			_tab_ACMain_TabPage3 = new System.Windows.Forms.TabPage();
			pnl_Research_Action = new System.Windows.Forms.Panel();
			txtAddlHotBoxNotes = new System.Windows.Forms.TextBox();
			cmdClearResearchAction = new System.Windows.Forms.Button();
			cmd_Cancel = new System.Windows.Forms.Button();
			lst_Research_Action = new System.Windows.Forms.ListBox();
			_lbl_gen_77 = new System.Windows.Forms.Label();
			_lbl_gen_83 = new System.Windows.Forms.Label();
			pnl_Journal = new System.Windows.Forms.Panel();
			txt_journal_note = new System.Windows.Forms.TextBox();
			cmd_Journal_Note_Cancel = new System.Windows.Forms.Button();
			cmd_Journal_Note_Save = new System.Windows.Forms.Button();
			_tab_ACMain_TabPage4 = new System.Windows.Forms.TabPage();
			_lbl_gen_74 = new System.Windows.Forms.Label();
			_lbl_gen_69 = new System.Windows.Forms.Label();
			_lbl_gen_68 = new System.Windows.Forms.Label();
			_lbl_gen_67 = new System.Windows.Forms.Label();
			_lbl_gen_66 = new System.Windows.Forms.Label();
			_lbl_gen_41 = new System.Windows.Forms.Label();
			_lbl_gen_109 = new System.Windows.Forms.Label();
			_lbl_gen_112 = new System.Windows.Forms.Label();
			_lbl_gen_121 = new System.Windows.Forms.Label();
			_lbl_gen_123 = new System.Windows.Forms.Label();
			txtBaseCity = new System.Windows.Forms.TextBox();
			txtBaseAirportName = new System.Windows.Forms.TextBox();
			txtICAOCode = new System.Windows.Forms.TextBox();
			txtIATACode = new System.Windows.Forms.TextBox();
			cboBaseState = new System.Windows.Forms.ComboBox();
			cboBaseCountry = new System.Windows.Forms.ComboBox();
			_chk_ac_aport_private_0 = new System.Windows.Forms.CheckBox();
			txtFAAIDCode = new System.Windows.Forms.TextBox();
			_chk_ac_aport_private_2 = new System.Windows.Forms.CheckBox();
			_tab_ACMain_TabPage5 = new System.Windows.Forms.TabPage();
			frm_aircraft_products = new System.Windows.Forms.GroupBox();
			_chk_ac_product_3 = new System.Windows.Forms.CheckBox();
			_chk_ac_product_5 = new System.Windows.Forms.CheckBox();
			_chk_ac_product_4 = new System.Windows.Forms.CheckBox();
			_chk_ac_product_2 = new System.Windows.Forms.CheckBox();
			_chk_ac_product_1 = new System.Windows.Forms.CheckBox();
			_chk_ac_product_0 = new System.Windows.Forms.CheckBox();
			_lbl_gen_113 = new System.Windows.Forms.Label();
			_pnl_gen_0 = new System.Windows.Forms.Panel();
			_txt_ac_reg_no_1 = new System.Windows.Forms.TextBox();
			_txt_ac_year_2 = new System.Windows.Forms.TextBox();
			_txt_ac_year_0 = new System.Windows.Forms.TextBox();
			cbo_ac_country_of_registration = new System.Windows.Forms.ComboBox();
			txt_ac_delivery_date = new System.Windows.Forms.TextBox();
			cbo_ac_use_code = new System.Windows.Forms.ComboBox();
			_txt_ac_alt_ser_no_2 = new System.Windows.Forms.TextBox();
			_txt_ac_alt_ser_no_1 = new System.Windows.Forms.TextBox();
			_txt_ac_alt_ser_no_0 = new System.Windows.Forms.TextBox();
			_txt_ac_ser_no_2 = new System.Windows.Forms.TextBox();
			_txt_ac_ser_no_1 = new System.Windows.Forms.TextBox();
			txt_ac_id = new System.Windows.Forms.TextBox();
			_txt_ac_ser_no_0 = new System.Windows.Forms.TextBox();
			_txt_ac_reg_no_0 = new System.Windows.Forms.TextBox();
			_txt_ac_year_1 = new System.Windows.Forms.TextBox();
			_lbl_gen_241 = new System.Windows.Forms.Label();
			_lbl_gen_5 = new System.Windows.Forms.Label();
			_lbl_gen_119 = new System.Windows.Forms.Label();
			_lbl_gen_108 = new System.Windows.Forms.Label();
			_lbl_gen_17 = new System.Windows.Forms.Label();
			_lbl_gen_95 = new System.Windows.Forms.Label();
			_lbl_gen_97 = new System.Windows.Forms.Label();
			_lbl_gen_30 = new System.Windows.Forms.Label();
			_lbl_gen_3 = new System.Windows.Forms.Label();
			_lbl_gen_4 = new System.Windows.Forms.Label();
			_lbl_gen_240 = new System.Windows.Forms.Label();
			_pnl_gen_5 = new System.Windows.Forms.Panel();
			cmd_Save = new System.Windows.Forms.Button();
			txt_ac_model_config = new System.Windows.Forms.TextBox();
			txtHistoryDate = new System.Windows.Forms.TextBox();
			txt_amod_type_code = new System.Windows.Forms.TextBox();
			cbo_amod_make_name = new System.Windows.Forms.ComboBox();
			_lbl_gen_56 = new System.Windows.Forms.Label();
			_Label1_0 = new System.Windows.Forms.Label();
			_lbl_gen_102 = new System.Windows.Forms.Label();
			_lbl_gen_42 = new System.Windows.Forms.Label();
			_lbl_gen_84 = new System.Windows.Forms.Label();
			_lbl_gen_0 = new System.Windows.Forms.Label();
			_lbl_gen_199 = new System.Windows.Forms.Label();
			acTimer1 = new System.Windows.Forms.Timer(components);
			tbr_ToolBar = new System.Windows.Forms.ToolStrip();
			tbr_ToolBar_Buttons_Button1 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button2 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button3 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button4 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button5 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button6 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button7 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button8 = new System.Windows.Forms.ToolStripButton();
			pnl_Please_Wait = new System.Windows.Forms.Panel();
			_lbl_gen_85 = new System.Windows.Forms.Label();
			tab_aircraft_details.SuspendLayout();
			_tab_aircraft_details_TabPage0.SuspendLayout();
			_tab_aircraft_details_TabPage1.SuspendLayout();
			pnl_certifications.SuspendLayout();
			_tab_aircraft_details_TabPage2.SuspendLayout();
			_tab_aircraft_details_TabPage3.SuspendLayout();
			_tab_aircraft_details_TabPage4.SuspendLayout();
			pnl_Cockpit.SuspendLayout();
			pnl_Av.SuspendLayout();
			_tab_aircraft_details_TabPage5.SuspendLayout();
			_pnl_gen_1.SuspendLayout();
			_pnl_gen_4.SuspendLayout();
			pnl_LeaseEntry.SuspendLayout();
			pnl_LeaseList.SuspendLayout();
			_tab_aircraft_details_TabPage6.SuspendLayout();
			_tab_aircraft_details_TabPage7.SuspendLayout();
			_tab_aircraft_details_TabPage8.SuspendLayout();
			_tab_aircraft_details_TabPage9.SuspendLayout();
			_tab_aircraft_details_TabPage10.SuspendLayout();
			pnl_TransactionNotes.SuspendLayout();
			_tab_aircraft_details_TabPage11.SuspendLayout();
			_tab_aircraft_details_TabPage12.SuspendLayout();
			_tab_aircraft_details_TabPage13.SuspendLayout();
			_tab_aircraft_details_TabPage14.SuspendLayout();
			tab_ACMain.SuspendLayout();
			_tab_ACMain_TabPage0.SuspendLayout();
			pnl_Sale_Data.SuspendLayout();
			_tab_ACMain_TabPage1.SuspendLayout();
			_tab_ACMain_TabPage2.SuspendLayout();
			_tab_ACMain_TabPage3.SuspendLayout();
			pnl_Research_Action.SuspendLayout();
			pnl_Journal.SuspendLayout();
			_tab_ACMain_TabPage4.SuspendLayout();
			_tab_ACMain_TabPage5.SuspendLayout();
			frm_aircraft_products.SuspendLayout();
			_pnl_gen_0.SuspendLayout();
			_pnl_gen_5.SuspendLayout();
			tbr_ToolBar.SuspendLayout();
			pnl_Please_Wait.SuspendLayout();
			SuspendLayout();
			//Ctx_mnuHistoricalTransaction
			Ctx_mnuHistoricalTransaction = new System.Windows.Forms.ContextMenuStrip(components);
			Ctx_mnuHistoricalTransaction.Size = new System.Drawing.Size(153, 26);
			Ctx_mnuHistoricalTransaction.Opening += new System.ComponentModel.CancelEventHandler(Ctx_mnuHistoricalTransaction_Opening);
			Ctx_mnuHistoricalTransaction.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(Ctx_mnuHistoricalTransaction_Closed);
			//Ctx_mnuCompTransmits
			Ctx_mnuCompTransmits = new System.Windows.Forms.ContextMenuStrip(components);
			Ctx_mnuCompTransmits.Size = new System.Drawing.Size(153, 26);
			Ctx_mnuCompTransmits.Opening += new System.ComponentModel.CancelEventHandler(Ctx_mnuCompTransmits_Opening);
			Ctx_mnuCompTransmits.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(Ctx_mnuCompTransmits_Closed);
			listBoxComboBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListControlHelper(components);
			((System.ComponentModel.ISupportInitialize) listBoxComboBoxHelper1).BeginInit();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) _grd_Features_4).BeginInit();
			((System.ComponentModel.ISupportInitialize) GrdHelicopter).BeginInit();
			((System.ComponentModel.ISupportInitialize) _grd_Features_0).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_aircraftdamage).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Maintenance).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Aircraft_Certified).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_maint).BeginInit();
			((System.ComponentModel.ISupportInitialize) _grd_Features_1).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Exterior).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Interior).BeginInit();
			((System.ComponentModel.ISupportInitialize) _grd_Features_2).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Equipment).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_AircraftAvionics).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Cockpit).BeginInit();
			((System.ComponentModel.ISupportInitialize) _grd_Features_3).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_AircraftContacts).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdLeaseInfo).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Aircraft_Journal).BeginInit();
			((System.ComponentModel.ISupportInitialize) _grd_pubs_1).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_DocumentLog).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdTransactionDocuments).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdAircraftDocuments).BeginInit();
			((System.ComponentModel.ISupportInitialize) _grd_pubs_0).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_AircraftKeyFeatures).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_AircraftHistory).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnu_File, mnu_Edit, mnuView, mnuTransactions, mnureport, mnuPubs, mnuAttachedSpecs, mnu_Help, cmdAircraftSearch, mnuTools});
			// 
			// mnu_File
			// 
			mnu_File.Available = true;
			mnu_File.Checked = false;
			mnu_File.Enabled = true;
			mnu_File.Name = "mnu_File";
			mnu_File.Text = "File";
			mnu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFileClose, mnuFileLogout});
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
			// mnu_Edit
			// 
			mnu_Edit.Available = true;
			mnu_Edit.Checked = false;
			mnu_Edit.Enabled = true;
			mnu_Edit.Name = "mnu_Edit";
			mnu_Edit.Text = "Edit";
			mnu_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuCompTransmits, mnuEditNewJournal, mnuEditAddNote, mnuUpdateAwaitingDocs, mnuAddExclusiveBroker, mnuRemoveExclusive, mnuDeleteHistoricalRecord, mnuDocumentJournal, mnuAddAircraftDeliveryNote, mnuEditRegNbrRequestToFAA, mnuenterprice, mnuremoveprice, mnuAddIDNote, cmdaddnote});
			// 
			// mnuCompTransmits
			// 
			mnuCompTransmits.Available = true;
			mnuCompTransmits.Checked = false;
			mnuCompTransmits.Enabled = true;
			mnuCompTransmits.Name = "mnuCompTransmits";
			mnuCompTransmits.Text = "Company Transmits";
			mnuCompTransmits.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuSendAsOwner, mnuSendAsOperator, mnuSendAsChiefPilot, mnuSendAsExclusiveBroker, mnuSendAsExclusiveRepresentative, mnuSendAsAdditional1, mnuSendAsAdditional2, mnuSendAsAdditional3, mnuSendAsRegisteredAsOwner, mnuSendAsPurchaser, mnuSendAsRegisteredAsPurchaser, mnuDoNotSend, mnuChangePercentage, mnuChangeBusinessType, mnuChangeOperator});
			// 
			// mnuSendAsOwner
			// 
			mnuSendAsOwner.Available = true;
			mnuSendAsOwner.Checked = false;
			mnuSendAsOwner.Enabled = true;
			mnuSendAsOwner.Name = "mnuSendAsOwner";
			mnuSendAsOwner.Text = "&1 - Send as Owner / Seller";
			mnuSendAsOwner.Click += new System.EventHandler(mnuSendAsOwner_Click);
			// 
			// mnuSendAsOperator
			// 
			mnuSendAsOperator.Available = true;
			mnuSendAsOperator.Checked = false;
			mnuSendAsOperator.Enabled = true;
			mnuSendAsOperator.Name = "mnuSendAsOperator";
			mnuSendAsOperator.Text = "&2 - Send as Position 2";
			mnuSendAsOperator.Click += new System.EventHandler(mnuSendAsOperator_Click);
			// 
			// mnuSendAsChiefPilot
			// 
			mnuSendAsChiefPilot.Available = true;
			mnuSendAsChiefPilot.Checked = false;
			mnuSendAsChiefPilot.Enabled = true;
			mnuSendAsChiefPilot.Name = "mnuSendAsChiefPilot";
			mnuSendAsChiefPilot.Text = "&3 - Send as Chief Pilot";
			mnuSendAsChiefPilot.Click += new System.EventHandler(mnuSendAsChiefPilot_Click);
			// 
			// mnuSendAsExclusiveBroker
			// 
			mnuSendAsExclusiveBroker.Available = true;
			mnuSendAsExclusiveBroker.Checked = false;
			mnuSendAsExclusiveBroker.Enabled = true;
			mnuSendAsExclusiveBroker.Name = "mnuSendAsExclusiveBroker";
			mnuSendAsExclusiveBroker.Text = "&4 - Send as Exclusive Broker";
			mnuSendAsExclusiveBroker.Click += new System.EventHandler(mnuSendAsExclusiveBroker_Click);
			// 
			// mnuSendAsExclusiveRepresentative
			// 
			mnuSendAsExclusiveRepresentative.Available = true;
			mnuSendAsExclusiveRepresentative.Checked = false;
			mnuSendAsExclusiveRepresentative.Enabled = true;
			mnuSendAsExclusiveRepresentative.Name = "mnuSendAsExclusiveRepresentative";
			mnuSendAsExclusiveRepresentative.Text = "&5 - Send as Exclusive Representative";
			mnuSendAsExclusiveRepresentative.Click += new System.EventHandler(mnuSendAsExclusiveRepresentative_Click);
			// 
			// mnuSendAsAdditional1
			// 
			mnuSendAsAdditional1.Available = true;
			mnuSendAsAdditional1.Checked = false;
			mnuSendAsAdditional1.Enabled = true;
			mnuSendAsAdditional1.Name = "mnuSendAsAdditional1";
			mnuSendAsAdditional1.Text = "&6 - Send as Additional Contact 1";
			mnuSendAsAdditional1.Click += new System.EventHandler(mnuSendAsAdditional1_Click);
			// 
			// mnuSendAsAdditional2
			// 
			mnuSendAsAdditional2.Available = true;
			mnuSendAsAdditional2.Checked = false;
			mnuSendAsAdditional2.Enabled = true;
			mnuSendAsAdditional2.Name = "mnuSendAsAdditional2";
			mnuSendAsAdditional2.Text = "&7 - Send as Additional Contact 2";
			mnuSendAsAdditional2.Click += new System.EventHandler(mnuSendAsAdditional2_Click);
			// 
			// mnuSendAsAdditional3
			// 
			mnuSendAsAdditional3.Available = true;
			mnuSendAsAdditional3.Checked = false;
			mnuSendAsAdditional3.Enabled = true;
			mnuSendAsAdditional3.Name = "mnuSendAsAdditional3";
			mnuSendAsAdditional3.Text = "&8 - Send as Additional Contact 3";
			mnuSendAsAdditional3.Click += new System.EventHandler(mnuSendAsAdditional3_Click);
			// 
			// mnuSendAsRegisteredAsOwner
			// 
			mnuSendAsRegisteredAsOwner.Available = true;
			mnuSendAsRegisteredAsOwner.Checked = false;
			mnuSendAsRegisteredAsOwner.Enabled = true;
			mnuSendAsRegisteredAsOwner.Name = "mnuSendAsRegisteredAsOwner";
			mnuSendAsRegisteredAsOwner.Text = "&9 - Send as Registered As Owner / Registered as Seller";
			mnuSendAsRegisteredAsOwner.Click += new System.EventHandler(mnuSendAsRegisteredAsOwner_Click);
			// 
			// mnuSendAsPurchaser
			// 
			mnuSendAsPurchaser.Available = true;
			mnuSendAsPurchaser.Checked = false;
			mnuSendAsPurchaser.Enabled = true;
			mnuSendAsPurchaser.Name = "mnuSendAsPurchaser";
			mnuSendAsPurchaser.Text = "&10 - Send as Purchaser";
			mnuSendAsPurchaser.Click += new System.EventHandler(mnuSendAsPurchaser_Click);
			// 
			// mnuSendAsRegisteredAsPurchaser
			// 
			mnuSendAsRegisteredAsPurchaser.Available = true;
			mnuSendAsRegisteredAsPurchaser.Checked = false;
			mnuSendAsRegisteredAsPurchaser.Enabled = true;
			mnuSendAsRegisteredAsPurchaser.Name = "mnuSendAsRegisteredAsPurchaser";
			mnuSendAsRegisteredAsPurchaser.Text = "&11 - Send as Registered as Purchaser";
			mnuSendAsRegisteredAsPurchaser.Click += new System.EventHandler(mnuSendAsRegisteredAsPurchaser_Click);
			// 
			// mnuDoNotSend
			// 
			mnuDoNotSend.Available = true;
			mnuDoNotSend.Checked = false;
			mnuDoNotSend.Enabled = true;
			mnuDoNotSend.Name = "mnuDoNotSend";
			mnuDoNotSend.Text = "&99 - Do Not Send to Customer";
			mnuDoNotSend.Click += new System.EventHandler(mnuDoNotSend_Click);
			// 
			// mnuChangePercentage
			// 
			mnuChangePercentage.Available = true;
			mnuChangePercentage.Checked = false;
			mnuChangePercentage.Enabled = true;
			mnuChangePercentage.Name = "mnuChangePercentage";
			mnuChangePercentage.Text = "&Change Percentage";
			mnuChangePercentage.Click += new System.EventHandler(mnuChangePercentage_Click);
			// 
			// mnuChangeBusinessType
			// 
			mnuChangeBusinessType.Available = true;
			mnuChangeBusinessType.Checked = false;
			mnuChangeBusinessType.Enabled = true;
			mnuChangeBusinessType.Name = "mnuChangeBusinessType";
			mnuChangeBusinessType.Text = "Change Business Type";
			mnuChangeBusinessType.Click += new System.EventHandler(mnuChangeBusinessType_Click);
			// 
			// mnuChangeOperator
			// 
			mnuChangeOperator.Available = true;
			mnuChangeOperator.Checked = false;
			mnuChangeOperator.Enabled = true;
			mnuChangeOperator.Name = "mnuChangeOperator";
			mnuChangeOperator.Text = "Set/Remove Operating Company";
			mnuChangeOperator.Click += new System.EventHandler(mnuChangeOperator_Click);
			// 
			// mnuEditNewJournal
			// 
			mnuEditNewJournal.Available = true;
			mnuEditNewJournal.Checked = false;
			mnuEditNewJournal.Enabled = true;
			mnuEditNewJournal.Name = "mnuEditNewJournal";
			mnuEditNewJournal.ShortcutKeys = (System.Windows.Forms.Keys) (System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J);
			mnuEditNewJournal.Text = "Add Internal Journal Note";
			mnuEditNewJournal.Click += new System.EventHandler(mnuEditNewJournal_Click);
			// 
			// mnuEditAddNote
			// 
			mnuEditAddNote.Available = true;
			mnuEditAddNote.Checked = false;
			mnuEditAddNote.Enabled = true;
			mnuEditAddNote.Name = "mnuEditAddNote";
			mnuEditAddNote.Text = "Add Aircraft Research Action ";
			mnuEditAddNote.Click += new System.EventHandler(mnuEditAddNote_Click);
			// 
			// mnuUpdateAwaitingDocs
			// 
			mnuUpdateAwaitingDocs.Available = true;
			mnuUpdateAwaitingDocs.Checked = false;
			mnuUpdateAwaitingDocs.Enabled = true;
			mnuUpdateAwaitingDocs.Name = "mnuUpdateAwaitingDocs";
			mnuUpdateAwaitingDocs.Text = "&Update Awaiting Docs Info";
			mnuUpdateAwaitingDocs.Click += new System.EventHandler(mnuUpdateAwaitingDocs_Click);
			// 
			// mnuAddExclusiveBroker
			// 
			mnuAddExclusiveBroker.Available = true;
			mnuAddExclusiveBroker.Checked = false;
			mnuAddExclusiveBroker.Enabled = true;
			mnuAddExclusiveBroker.Name = "mnuAddExclusiveBroker";
			mnuAddExclusiveBroker.Text = "Add &Exclusive Broker or Representative";
			mnuAddExclusiveBroker.Click += new System.EventHandler(mnuAddExclusiveBroker_Click);
			// 
			// mnuRemoveExclusive
			// 
			mnuRemoveExclusive.Available = true;
			mnuRemoveExclusive.Checked = false;
			mnuRemoveExclusive.Enabled = true;
			mnuRemoveExclusive.Name = "mnuRemoveExclusive";
			mnuRemoveExclusive.Text = "&Remove Exclusive Status";
			mnuRemoveExclusive.Click += new System.EventHandler(mnuRemoveExclusive_Click);
			// 
			// mnuDeleteHistoricalRecord
			// 
			mnuDeleteHistoricalRecord.Available = true;
			mnuDeleteHistoricalRecord.Checked = false;
			mnuDeleteHistoricalRecord.Enabled = true;
			mnuDeleteHistoricalRecord.Name = "mnuDeleteHistoricalRecord";
			mnuDeleteHistoricalRecord.Text = "Delete This Historical Record";
			mnuDeleteHistoricalRecord.Click += new System.EventHandler(mnuDeleteHistoricalRecord_Click);
			// 
			// mnuDocumentJournal
			// 
			mnuDocumentJournal.Available = true;
			mnuDocumentJournal.Checked = false;
			mnuDocumentJournal.Enabled = true;
			mnuDocumentJournal.Name = "mnuDocumentJournal";
			mnuDocumentJournal.Text = "Add Journal Note for FAA Document";
			mnuDocumentJournal.Click += new System.EventHandler(mnuDocumentJournal_Click);
			// 
			// mnuAddAircraftDeliveryNote
			// 
			mnuAddAircraftDeliveryNote.Available = true;
			mnuAddAircraftDeliveryNote.Checked = false;
			mnuAddAircraftDeliveryNote.Enabled = true;
			mnuAddAircraftDeliveryNote.Name = "mnuAddAircraftDeliveryNote";
			mnuAddAircraftDeliveryNote.Text = "Add Aircraft Delivery Note";
			mnuAddAircraftDeliveryNote.Click += new System.EventHandler(mnuAddAircraftDeliveryNote_Click);
			// 
			// mnuEditRegNbrRequestToFAA
			// 
			mnuEditRegNbrRequestToFAA.Available = true;
			mnuEditRegNbrRequestToFAA.Checked = false;
			mnuEditRegNbrRequestToFAA.Enabled = true;
			mnuEditRegNbrRequestToFAA.Name = "mnuEditRegNbrRequestToFAA";
			mnuEditRegNbrRequestToFAA.Text = "EMail RegNbr Request To FAA";
			mnuEditRegNbrRequestToFAA.Click += new System.EventHandler(mnuEditRegNbrRequestToFAA_Click);
			// 
			// mnuenterprice
			// 
			mnuenterprice.Available = true;
			mnuenterprice.Checked = false;
			mnuenterprice.Enabled = true;
			mnuenterprice.Name = "mnuenterprice";
			mnuenterprice.Text = "Add New Displayable Sale Price";
			mnuenterprice.Click += new System.EventHandler(mnuenterprice_Click);
			// 
			// mnuremoveprice
			// 
			mnuremoveprice.Available = true;
			mnuremoveprice.Checked = false;
			mnuremoveprice.Enabled = true;
			mnuremoveprice.Name = "mnuremoveprice";
			mnuremoveprice.Text = "Remove Displayable Sale Price";
			mnuremoveprice.Click += new System.EventHandler(mnuremoveprice_Click);
			// 
			// mnuAddIDNote
			// 
			mnuAddIDNote.Available = true;
			mnuAddIDNote.Checked = false;
			mnuAddIDNote.Enabled = true;
			mnuAddIDNote.Name = "mnuAddIDNote";
			mnuAddIDNote.ShortcutKeys = (System.Windows.Forms.Keys) (System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I);
			mnuAddIDNote.Text = "Add ID Note";
			mnuAddIDNote.Click += new System.EventHandler(mnuAddIDNote_Click);
			// 
			// cmdaddnote
			// 
			cmdaddnote.Available = true;
			cmdaddnote.Checked = false;
			cmdaddnote.Enabled = true;
			cmdaddnote.Name = "cmdaddnote";
			cmdaddnote.Text = "Add Note";
			cmdaddnote.Click += new System.EventHandler(cmdaddnote_Click);
			// 
			// mnuView
			// 
			mnuView.Available = true;
			mnuView.Checked = false;
			mnuView.Enabled = true;
			mnuView.Name = "mnuView";
			mnuView.Text = "View";
			mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuViewAircraftLookup, mnuEvents, mnuFAAFlightData, mnuSalePrices, mnuhomebase});
			// 
			// mnuViewAircraftLookup
			// 
			mnuViewAircraftLookup.Available = false;
			mnuViewAircraftLookup.Checked = false;
			mnuViewAircraftLookup.Enabled = false;
			mnuViewAircraftLookup.Name = "mnuViewAircraftLookup";
			mnuViewAircraftLookup.Text = "Aircraft Lookups";
			// 
			// mnuEvents
			// 
			mnuEvents.Available = true;
			mnuEvents.Checked = false;
			mnuEvents.Enabled = true;
			mnuEvents.Name = "mnuEvents";
			mnuEvents.Text = "&Events";
			mnuEvents.Click += new System.EventHandler(mnuEvents_Click);
			// 
			// mnuFAAFlightData
			// 
			mnuFAAFlightData.Available = true;
			mnuFAAFlightData.Checked = false;
			mnuFAAFlightData.Enabled = true;
			mnuFAAFlightData.Name = "mnuFAAFlightData";
			mnuFAAFlightData.Text = "&FAA Flight Data";
			mnuFAAFlightData.Click += new System.EventHandler(mnuFAAFlightData_Click);
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
			// mnuhomebase
			// 
			mnuhomebase.Available = true;
			mnuhomebase.Checked = false;
			mnuhomebase.Enabled = true;
			mnuhomebase.Name = "mnuhomebase";
			mnuhomebase.Text = "Homebase.com Record";
			mnuhomebase.Click += new System.EventHandler(mnuhomebase_Click);
			// 
			// mnuTransactions
			// 
			mnuTransactions.Available = true;
			mnuTransactions.Checked = false;
			mnuTransactions.Enabled = true;
			mnuTransactions.Name = "mnuTransactions";
			mnuTransactions.Text = "Transactions";
			mnuTransactions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnueditchange, mnueditchangeFractional, mnueditchangeShare, mnueditchangeSieze, mnueditchangeForeclosure, mnueditchangeDelivery, mnueditchangeLease, mnuTransmit, mnuHistoricalTransaction});
			// 
			// mnueditchange
			// 
			mnueditchange.Available = true;
			mnueditchange.Checked = false;
			mnueditchange.Enabled = true;
			mnueditchange.Name = "mnueditchange";
			mnueditchange.Text = "Record Aircraft Sale";
			mnueditchange.Click += new System.EventHandler(mnueditchange_Click);
			// 
			// mnueditchangeFractional
			// 
			mnueditchangeFractional.Available = true;
			mnueditchangeFractional.Checked = false;
			mnueditchangeFractional.Enabled = true;
			mnueditchangeFractional.Name = "mnueditchangeFractional";
			mnueditchangeFractional.Text = "Record Fractional Aircraft Sale";
			mnueditchangeFractional.Click += new System.EventHandler(mnueditchangeFractional_Click);
			// 
			// mnueditchangeShare
			// 
			mnueditchangeShare.Available = true;
			mnueditchangeShare.Checked = false;
			mnueditchangeShare.Enabled = true;
			mnueditchangeShare.Name = "mnueditchangeShare";
			mnueditchangeShare.Text = "Record Aircraft Share Sale";
			mnueditchangeShare.Click += new System.EventHandler(mnueditchangeShare_Click);
			// 
			// mnueditchangeSieze
			// 
			mnueditchangeSieze.Available = true;
			mnueditchangeSieze.Checked = false;
			mnueditchangeSieze.Enabled = true;
			mnueditchangeSieze.Name = "mnueditchangeSieze";
			mnueditchangeSieze.Text = "Record Aircraft Seizure";
			mnueditchangeSieze.Click += new System.EventHandler(mnueditchangeSieze_Click);
			// 
			// mnueditchangeForeclosure
			// 
			mnueditchangeForeclosure.Available = true;
			mnueditchangeForeclosure.Checked = false;
			mnueditchangeForeclosure.Enabled = true;
			mnueditchangeForeclosure.Name = "mnueditchangeForeclosure";
			mnueditchangeForeclosure.Text = "Record Aircraft Foreclosure";
			mnueditchangeForeclosure.Click += new System.EventHandler(mnueditchangeForeclosure_Click);
			// 
			// mnueditchangeDelivery
			// 
			mnueditchangeDelivery.Available = true;
			mnueditchangeDelivery.Checked = false;
			mnueditchangeDelivery.Enabled = true;
			mnueditchangeDelivery.Name = "mnueditchangeDelivery";
			mnueditchangeDelivery.Text = "Record Delivery Position Sale";
			mnueditchangeDelivery.Click += new System.EventHandler(mnueditchangeDelivery_Click);
			// 
			// mnueditchangeLease
			// 
			mnueditchangeLease.Available = true;
			mnueditchangeLease.Checked = false;
			mnueditchangeLease.Enabled = false;
			mnueditchangeLease.Name = "mnueditchangeLease";
			mnueditchangeLease.Text = "Record Aircraft Lease";
			mnueditchangeLease.Click += new System.EventHandler(mnueditchangeLease_Click);
			// 
			// mnuTransmit
			// 
			mnuTransmit.Available = true;
			mnuTransmit.Checked = false;
			mnuTransmit.Enabled = true;
			mnuTransmit.Name = "mnuTransmit";
			mnuTransmit.Text = "Transmit this Aircraft";
			mnuTransmit.Click += new System.EventHandler(mnuTransmit_Click);
			// 
			// mnuHistoricalTransaction
			// 
			mnuHistoricalTransaction.Available = false;
			mnuHistoricalTransaction.Checked = false;
			mnuHistoricalTransaction.Enabled = true;
			mnuHistoricalTransaction.Name = "mnuHistoricalTransaction";
			mnuHistoricalTransaction.Text = "Historical";
			mnuHistoricalTransaction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{_mnuChangeContactType_0, _mnuChangeContactType_8, _mnuChangeContactType_12, _mnuChangeContactType_13, _mnuChangeContactType_27, _mnuChangeContactType_39, _mnuChangeContactType_51, _mnuChangeContactType_52, _mnuChangeContactType_53, _mnuChangeContactType_54, _mnuChangeContactType_56, _mnuChangeContactType_60, _mnuChangeContactType_61, _mnuChangeContactType_62, _mnuChangeContactType_69, _mnuChangeContactType_70, _mnuChangeContactType_91, _mnuChangeContactType_95, _mnuChangeContactType_96, mnuConvertFSPEND, mnuChangeHistPercentage});
			// 
			// _mnuChangeContactType_0
			// 
			_mnuChangeContactType_0.Available = true;
			_mnuChangeContactType_0.Checked = false;
			_mnuChangeContactType_0.Enabled = true;
			_mnuChangeContactType_0.Name = "_mnuChangeContactType_0";
			_mnuChangeContactType_0.Text = "Change Owner";
			_mnuChangeContactType_0.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_8
			// 
			_mnuChangeContactType_8.Available = true;
			_mnuChangeContactType_8.Checked = false;
			_mnuChangeContactType_8.Enabled = true;
			_mnuChangeContactType_8.Name = "_mnuChangeContactType_8";
			_mnuChangeContactType_8.Text = "Change Co-Owner";
			_mnuChangeContactType_8.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_12
			// 
			_mnuChangeContactType_12.Available = true;
			_mnuChangeContactType_12.Checked = false;
			_mnuChangeContactType_12.Enabled = true;
			_mnuChangeContactType_12.Name = "_mnuChangeContactType_12";
			_mnuChangeContactType_12.Text = "Change Lessee";
			_mnuChangeContactType_12.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_13
			// 
			_mnuChangeContactType_13.Available = true;
			_mnuChangeContactType_13.Checked = false;
			_mnuChangeContactType_13.Enabled = true;
			_mnuChangeContactType_13.Name = "_mnuChangeContactType_13";
			_mnuChangeContactType_13.Text = "Change Lessor";
			_mnuChangeContactType_13.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_27
			// 
			_mnuChangeContactType_27.Available = true;
			_mnuChangeContactType_27.Checked = false;
			_mnuChangeContactType_27.Enabled = true;
			_mnuChangeContactType_27.Name = "_mnuChangeContactType_27";
			_mnuChangeContactType_27.Text = "Change Trustee";
			_mnuChangeContactType_27.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_39
			// 
			_mnuChangeContactType_39.Available = true;
			_mnuChangeContactType_39.Checked = false;
			_mnuChangeContactType_39.Enabled = true;
			_mnuChangeContactType_39.Name = "_mnuChangeContactType_39";
			_mnuChangeContactType_39.Text = "Change Sub-Lessee";
			_mnuChangeContactType_39.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_51
			// 
			_mnuChangeContactType_51.Available = true;
			_mnuChangeContactType_51.Checked = false;
			_mnuChangeContactType_51.Enabled = true;
			_mnuChangeContactType_51.Name = "_mnuChangeContactType_51";
			_mnuChangeContactType_51.Text = "Change Seized By";
			_mnuChangeContactType_51.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_52
			// 
			_mnuChangeContactType_52.Available = true;
			_mnuChangeContactType_52.Checked = false;
			_mnuChangeContactType_52.Enabled = true;
			_mnuChangeContactType_52.Name = "_mnuChangeContactType_52";
			_mnuChangeContactType_52.Text = "Change Foreclosed By";
			_mnuChangeContactType_52.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_53
			// 
			_mnuChangeContactType_53.Available = true;
			_mnuChangeContactType_53.Checked = false;
			_mnuChangeContactType_53.Enabled = true;
			_mnuChangeContactType_53.Name = "_mnuChangeContactType_53";
			_mnuChangeContactType_53.Text = "Change Financials On Behalf Of";
			_mnuChangeContactType_53.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_54
			// 
			_mnuChangeContactType_54.Available = true;
			_mnuChangeContactType_54.Checked = false;
			_mnuChangeContactType_54.Enabled = true;
			_mnuChangeContactType_54.Name = "_mnuChangeContactType_54";
			_mnuChangeContactType_54.Text = "Change Financials In Favor Of";
			_mnuChangeContactType_54.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_56
			// 
			_mnuChangeContactType_56.Available = true;
			_mnuChangeContactType_56.Checked = false;
			_mnuChangeContactType_56.Enabled = true;
			_mnuChangeContactType_56.Name = "_mnuChangeContactType_56";
			_mnuChangeContactType_56.Text = "Change Previous Owner";
			_mnuChangeContactType_56.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_60
			// 
			_mnuChangeContactType_60.Available = true;
			_mnuChangeContactType_60.Checked = false;
			_mnuChangeContactType_60.Enabled = true;
			_mnuChangeContactType_60.Name = "_mnuChangeContactType_60";
			_mnuChangeContactType_60.Text = "Change Registered As Seller";
			_mnuChangeContactType_60.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_61
			// 
			_mnuChangeContactType_61.Available = true;
			_mnuChangeContactType_61.Checked = false;
			_mnuChangeContactType_61.Enabled = true;
			_mnuChangeContactType_61.Name = "_mnuChangeContactType_61";
			_mnuChangeContactType_61.Text = "Change Registered As Purchaser";
			_mnuChangeContactType_61.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_62
			// 
			_mnuChangeContactType_62.Available = true;
			_mnuChangeContactType_62.Checked = false;
			_mnuChangeContactType_62.Enabled = true;
			_mnuChangeContactType_62.Name = "_mnuChangeContactType_62";
			_mnuChangeContactType_62.Text = "Change Registered As Owner";
			_mnuChangeContactType_62.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_69
			// 
			_mnuChangeContactType_69.Available = true;
			_mnuChangeContactType_69.Checked = false;
			_mnuChangeContactType_69.Enabled = true;
			_mnuChangeContactType_69.Name = "_mnuChangeContactType_69";
			_mnuChangeContactType_69.Text = "Change Fraction Seller";
			_mnuChangeContactType_69.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_70
			// 
			_mnuChangeContactType_70.Available = true;
			_mnuChangeContactType_70.Checked = false;
			_mnuChangeContactType_70.Enabled = true;
			_mnuChangeContactType_70.Name = "_mnuChangeContactType_70";
			_mnuChangeContactType_70.Text = "Change Fraction Purchaser";
			_mnuChangeContactType_70.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_91
			// 
			_mnuChangeContactType_91.Available = true;
			_mnuChangeContactType_91.Checked = false;
			_mnuChangeContactType_91.Enabled = true;
			_mnuChangeContactType_91.Name = "_mnuChangeContactType_91";
			_mnuChangeContactType_91.Text = "Change Fractional Owner Pending Sale";
			_mnuChangeContactType_91.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_95
			// 
			_mnuChangeContactType_95.Available = true;
			_mnuChangeContactType_95.Checked = false;
			_mnuChangeContactType_95.Enabled = true;
			_mnuChangeContactType_95.Name = "_mnuChangeContactType_95";
			_mnuChangeContactType_95.Text = "Change Seller";
			_mnuChangeContactType_95.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// _mnuChangeContactType_96
			// 
			_mnuChangeContactType_96.Available = true;
			_mnuChangeContactType_96.Checked = false;
			_mnuChangeContactType_96.Enabled = true;
			_mnuChangeContactType_96.Name = "_mnuChangeContactType_96";
			_mnuChangeContactType_96.Text = "Change Purchaser";
			_mnuChangeContactType_96.Click += new System.EventHandler(mnuChangeContactType_Click);
			// 
			// mnuConvertFSPEND
			// 
			mnuConvertFSPEND.Available = true;
			mnuConvertFSPEND.Checked = false;
			mnuConvertFSPEND.Enabled = true;
			mnuConvertFSPEND.Name = "mnuConvertFSPEND";
			mnuConvertFSPEND.Text = "Convert from Pending Sale to Fractional Seller";
			mnuConvertFSPEND.Click += new System.EventHandler(mnuConvertFSPEND_Click);
			// 
			// mnuChangeHistPercentage
			// 
			mnuChangeHistPercentage.Available = true;
			mnuChangeHistPercentage.Checked = false;
			mnuChangeHistPercentage.Enabled = true;
			mnuChangeHistPercentage.Name = "mnuChangeHistPercentage";
			mnuChangeHistPercentage.Text = "Change Percentage";
			mnuChangeHistPercentage.Click += new System.EventHandler(mnuChangeHistPercentage_Click);
			// 
			// mnureport
			// 
			mnureport.Available = true;
			mnureport.Checked = false;
			mnureport.Enabled = true;
			mnureport.Name = "mnureport";
			mnureport.Text = "Report";
			mnureport.Click += new System.EventHandler(mnureport_Click);
			// 
			// mnuPubs
			// 
			mnuPubs.Available = true;
			mnuPubs.Checked = false;
			mnuPubs.Enabled = true;
			mnuPubs.Name = "mnuPubs";
			mnuPubs.Text = "Tasks";
			mnuPubs.Click += new System.EventHandler(mnuPubs_Click);
			// 
			// mnuAttachedSpecs
			// 
			mnuAttachedSpecs.Available = true;
			mnuAttachedSpecs.Checked = false;
			mnuAttachedSpecs.Enabled = true;
			mnuAttachedSpecs.Name = "mnuAttachedSpecs";
			mnuAttachedSpecs.Text = "Attached Specs";
			mnuAttachedSpecs.Click += new System.EventHandler(mnuAttachedSpecs_Click);
			// 
			// mnu_Help
			// 
			mnu_Help.Available = true;
			mnu_Help.Checked = false;
			mnu_Help.Enabled = true;
			mnu_Help.Name = "mnu_Help";
			mnu_Help.Text = "Help";
			mnu_Help.Click += new System.EventHandler(mnu_Help_Click);
			// 
			// cmdAircraftSearch
			// 
			cmdAircraftSearch.Available = true;
			cmdAircraftSearch.Checked = false;
			cmdAircraftSearch.Enabled = true;
			cmdAircraftSearch.Name = "cmdAircraftSearch";
			cmdAircraftSearch.Text = "Aircraft Search";
			cmdAircraftSearch.Click += new System.EventHandler(cmdAircraftSearch_Click);
			// 
			// mnuTools
			// 
			mnuTools.Available = true;
			mnuTools.Checked = false;
			mnuTools.Enabled = true;
			mnuTools.Name = "mnuTools";
			mnuTools.Text = "&Tools";
			mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuAircraftShowUserHistory, mnurestoreacavailable});
			// 
			// mnuAircraftShowUserHistory
			// 
			mnuAircraftShowUserHistory.Available = true;
			mnuAircraftShowUserHistory.Checked = false;
			mnuAircraftShowUserHistory.Enabled = true;
			mnuAircraftShowUserHistory.Name = "mnuAircraftShowUserHistory";
			mnuAircraftShowUserHistory.Text = "Show User History";
			mnuAircraftShowUserHistory.Click += new System.EventHandler(mnuAircraftShowUserHistory_Click);
			// 
			// mnurestoreacavailable
			// 
			mnurestoreacavailable.Available = true;
			mnurestoreacavailable.Checked = false;
			mnurestoreacavailable.Enabled = true;
			mnurestoreacavailable.Name = "mnurestoreacavailable";
			mnurestoreacavailable.Text = "Restore AC From Last Available";
			mnurestoreacavailable.Click += new System.EventHandler(mnurestoreacavailable_Click);
			// 
			// tab_aircraft_details
			// 
			tab_aircraft_details.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_aircraft_details.AllowDrop = true;
			tab_aircraft_details.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage0);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage1);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage2);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage3);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage4);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage5);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage6);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage7);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage8);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage9);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage10);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage11);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage12);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage13);
			tab_aircraft_details.Controls.Add(_tab_aircraft_details_TabPage14);
			tab_aircraft_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_aircraft_details.ItemSize = new System.Drawing.Size(65, 18);
			tab_aircraft_details.Location = new System.Drawing.Point(0, 224);
			tab_aircraft_details.Multiline = true;
			tab_aircraft_details.Name = "tab_aircraft_details";
			tab_aircraft_details.Size = new System.Drawing.Size(1005, 495);
			tab_aircraft_details.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_aircraft_details.TabIndex = 26;
			tab_aircraft_details.Visible = false;
			tab_aircraft_details.SelectedIndexChanged += new System.EventHandler(tab_aircraft_details_SelectedIndexChanged);
			// 
			// _tab_aircraft_details_TabPage0
			// 
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_44);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_34);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_238);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_239);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_231);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_230);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_54);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_20);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_19);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_262);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_261);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_260);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_263);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_103);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_104);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_72);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_73);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_105);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_106);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_107);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_40);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_58);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_28);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_70);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_71);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_59);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_60);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_61);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_62);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_57);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_92);
			_tab_aircraft_details_TabPage0.Controls.Add(_Label1_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_89);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_90);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_26);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_25);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_24);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_23);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_18);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_35);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_117);
			_tab_aircraft_details_TabPage0.Controls.Add(_lbl_gen_51);
			_tab_aircraft_details_TabPage0.Controls.Add(_grd_Features_4);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_soh_hrs_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_soh_hrs_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_soh_hrs_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_soh_hrs_3);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_soh_year_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_soh_year_3);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_soh_year_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_soh_year_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_snew_hrs_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_snew_hrs_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_snew_hrs_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_snew_hrs_3);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_ser_no_3);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_ser_no_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_soh_mo_3);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_soh_mo_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_soh_mo_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_soh_mo_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_ser_no_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_prop_ser_no_1);
			_tab_aircraft_details_TabPage0.Controls.Add(txt_ac_confidential_notes);
			_tab_aircraft_details_TabPage0.Controls.Add(cbo_ac_apu_maint_prog);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_apu_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_apu_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_apu_2);
			_tab_aircraft_details_TabPage0.Controls.Add(cbo_ac_apu_model_name);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_shs_cycles_3);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_shs_cycles_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_shs_cycles_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_shs_cycles_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_tot_hrs_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_tot_hrs_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_tot_hrs_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_tot_hrs_3);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_soh_hrs_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_soh_hrs_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_soh_hrs_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_soh_hrs_3);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_shi_hrs_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_shi_hrs_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_shi_hrs_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_shi_hrs_3);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_tbo_hrs_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_tbo_hrs_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_tbo_hrs_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_tbo_hrs_3);
			_tab_aircraft_details_TabPage0.Controls.Add(cbo_ac_engine_name);
			_tab_aircraft_details_TabPage0.Controls.Add(cbo_ac_engine_maint_prog);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_snew_cycles_3);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_snew_cycles_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_snew_cycles_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_snew_cycles_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_soh_cycles_3);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_soh_cycles_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_soh_cycles_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_soh_cycles_0);
			_tab_aircraft_details_TabPage0.Controls.Add(txt_ac_times_as_of_date);
			_tab_aircraft_details_TabPage0.Controls.Add(txt_ac_airframe_tot_landings);
			_tab_aircraft_details_TabPage0.Controls.Add(txt_ac_airframe_tot_hrs);
			_tab_aircraft_details_TabPage0.Controls.Add(cbo_ac_engine_management_prog_EMGP);
			_tab_aircraft_details_TabPage0.Controls.Add(_cmdHelicopter_0);
			_tab_aircraft_details_TabPage0.Controls.Add(_cmdHelicopter_1);
			_tab_aircraft_details_TabPage0.Controls.Add(txt_ac_engine_noise_rating);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_ser_no_3);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_ser_no_2);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_ser_no_1);
			_tab_aircraft_details_TabPage0.Controls.Add(_txt_ac_engine_ser_no_0);
			_tab_aircraft_details_TabPage0.Controls.Add(GrdHelicopter);
			_tab_aircraft_details_TabPage0.Controls.Add(cbo_edit_heli);
			_tab_aircraft_details_TabPage0.Controls.Add(txt_edit_heli);
			_tab_aircraft_details_TabPage0.Controls.Add(txt_ac_hidden_asking_price);
			_tab_aircraft_details_TabPage0.Controls.Add(chk_oncondtbo);
			_tab_aircraft_details_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage0.Text = "Main";
			// 
			// _lbl_gen_44
			// 
			_lbl_gen_44.AllowDrop = true;
			_lbl_gen_44.AutoSize = true;
			_lbl_gen_44.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_44.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_44.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_44.Location = new System.Drawing.Point(548, 50);
			_lbl_gen_44.MinimumSize = new System.Drawing.Size(64, 13);
			_lbl_gen_44.Name = "_lbl_gen_44";
			_lbl_gen_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_44.Size = new System.Drawing.Size(64, 13);
			_lbl_gen_44.TabIndex = 155;
			_lbl_gen_44.Text = "Status Notes:";
			_lbl_gen_44.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_44.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_34
			// 
			_lbl_gen_34.AllowDrop = true;
			_lbl_gen_34.AutoSize = true;
			_lbl_gen_34.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_34.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_34.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_34.Location = new System.Drawing.Point(551, 357);
			_lbl_gen_34.MinimumSize = new System.Drawing.Size(89, 13);
			_lbl_gen_34.Name = "_lbl_gen_34";
			_lbl_gen_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_34.Size = new System.Drawing.Size(89, 13);
			_lbl_gen_34.TabIndex = 199;
			_lbl_gen_34.Text = "Maintenance Plan:";
			_lbl_gen_34.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_34.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_238
			// 
			_lbl_gen_238.AllowDrop = true;
			_lbl_gen_238.AutoSize = true;
			_lbl_gen_238.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_238.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_238.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_238.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_238.Location = new System.Drawing.Point(551, 309);
			_lbl_gen_238.MinimumSize = new System.Drawing.Size(62, 13);
			_lbl_gen_238.Name = "_lbl_gen_238";
			_lbl_gen_238.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_238.Size = new System.Drawing.Size(62, 13);
			_lbl_gen_238.TabIndex = 200;
			_lbl_gen_238.Text = "Make Model:";
			_lbl_gen_238.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_238.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_239
			// 
			_lbl_gen_239.AllowDrop = true;
			_lbl_gen_239.AutoSize = true;
			_lbl_gen_239.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_239.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_239.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_239.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_239.Location = new System.Drawing.Point(551, 333);
			_lbl_gen_239.MinimumSize = new System.Drawing.Size(39, 13);
			_lbl_gen_239.Name = "_lbl_gen_239";
			_lbl_gen_239.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_239.Size = new System.Drawing.Size(39, 13);
			_lbl_gen_239.TabIndex = 201;
			_lbl_gen_239.Text = "Serial #:";
			_lbl_gen_239.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_239.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_231
			// 
			_lbl_gen_231.AllowDrop = true;
			_lbl_gen_231.AutoSize = true;
			_lbl_gen_231.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_231.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_231.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_231.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_231.Location = new System.Drawing.Point(551, 381);
			_lbl_gen_231.MinimumSize = new System.Drawing.Size(100, 13);
			_lbl_gen_231.Name = "_lbl_gen_231";
			_lbl_gen_231.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_231.Size = new System.Drawing.Size(100, 13);
			_lbl_gen_231.TabIndex = 202;
			_lbl_gen_231.Text = "Time Since New Hrs:";
			_lbl_gen_231.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_231.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_230
			// 
			_lbl_gen_230.AllowDrop = true;
			_lbl_gen_230.AutoSize = true;
			_lbl_gen_230.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_230.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_230.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_230.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_230.Location = new System.Drawing.Point(550, 405);
			_lbl_gen_230.MinimumSize = new System.Drawing.Size(127, 13);
			_lbl_gen_230.Name = "_lbl_gen_230";
			_lbl_gen_230.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_230.Size = new System.Drawing.Size(127, 13);
			_lbl_gen_230.TabIndex = 203;
			_lbl_gen_230.Text = "Since Overhaul (SOH) Hrs:";
			_lbl_gen_230.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_230.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_54
			// 
			_lbl_gen_54.AllowDrop = true;
			_lbl_gen_54.AutoSize = true;
			_lbl_gen_54.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_54.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_54.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_54.Location = new System.Drawing.Point(550, 294);
			_lbl_gen_54.MinimumSize = new System.Drawing.Size(187, 13);
			_lbl_gen_54.Name = "_lbl_gen_54";
			_lbl_gen_54.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_54.Size = new System.Drawing.Size(187, 13);
			_lbl_gen_54.TabIndex = 204;
			_lbl_gen_54.Text = "AUXILIARY POWER UNIT (APU)";
			_lbl_gen_54.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_54.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_20
			// 
			_lbl_gen_20.AllowDrop = true;
			_lbl_gen_20.AutoSize = true;
			_lbl_gen_20.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_20.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_20.Location = new System.Drawing.Point(13, 36);
			_lbl_gen_20.MinimumSize = new System.Drawing.Size(139, 13);
			_lbl_gen_20.Name = "_lbl_gen_20";
			_lbl_gen_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_20.Size = new System.Drawing.Size(139, 13);
			_lbl_gen_20.TabIndex = 213;
			_lbl_gen_20.Text = "Maintenance Program (EMP):";
			_lbl_gen_20.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_20.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_19
			// 
			_lbl_gen_19.AllowDrop = true;
			_lbl_gen_19.AutoSize = true;
			_lbl_gen_19.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_19.Location = new System.Drawing.Point(120, 13);
			_lbl_gen_19.MinimumSize = new System.Drawing.Size(32, 13);
			_lbl_gen_19.Name = "_lbl_gen_19";
			_lbl_gen_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_19.Size = new System.Drawing.Size(32, 13);
			_lbl_gen_19.TabIndex = 214;
			_lbl_gen_19.Text = "Model:";
			_lbl_gen_19.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_19.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_262
			// 
			_lbl_gen_262.AllowDrop = true;
			_lbl_gen_262.AutoSize = true;
			_lbl_gen_262.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_262.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_262.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_262.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_262.Location = new System.Drawing.Point(3, 198);
			_lbl_gen_262.MinimumSize = new System.Drawing.Size(45, 13);
			_lbl_gen_262.Name = "_lbl_gen_262";
			_lbl_gen_262.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_262.Size = new System.Drawing.Size(45, 13);
			_lbl_gen_262.TabIndex = 215;
			_lbl_gen_262.Text = "Engine 3:";
			_lbl_gen_262.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_262.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_261
			// 
			_lbl_gen_261.AllowDrop = true;
			_lbl_gen_261.AutoSize = true;
			_lbl_gen_261.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_261.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_261.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_261.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_261.Location = new System.Drawing.Point(3, 174);
			_lbl_gen_261.MinimumSize = new System.Drawing.Size(45, 13);
			_lbl_gen_261.Name = "_lbl_gen_261";
			_lbl_gen_261.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_261.Size = new System.Drawing.Size(45, 13);
			_lbl_gen_261.TabIndex = 216;
			_lbl_gen_261.Text = "Engine 2:";
			_lbl_gen_261.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_261.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_260
			// 
			_lbl_gen_260.AllowDrop = true;
			_lbl_gen_260.AutoSize = true;
			_lbl_gen_260.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_260.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_260.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_260.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_260.Location = new System.Drawing.Point(3, 151);
			_lbl_gen_260.MinimumSize = new System.Drawing.Size(45, 13);
			_lbl_gen_260.Name = "_lbl_gen_260";
			_lbl_gen_260.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_260.Size = new System.Drawing.Size(45, 13);
			_lbl_gen_260.TabIndex = 217;
			_lbl_gen_260.Text = "Engine 1:";
			_lbl_gen_260.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_260.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_263
			// 
			_lbl_gen_263.AllowDrop = true;
			_lbl_gen_263.AutoSize = true;
			_lbl_gen_263.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_263.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_263.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_263.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_263.Location = new System.Drawing.Point(3, 221);
			_lbl_gen_263.MinimumSize = new System.Drawing.Size(45, 13);
			_lbl_gen_263.Name = "_lbl_gen_263";
			_lbl_gen_263.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_263.Size = new System.Drawing.Size(45, 13);
			_lbl_gen_263.TabIndex = 218;
			_lbl_gen_263.Text = "Engine 4:";
			_lbl_gen_263.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_263.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_103
			// 
			_lbl_gen_103.AllowDrop = true;
			_lbl_gen_103.AutoSize = true;
			_lbl_gen_103.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_103.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_103.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_103.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_103.Location = new System.Drawing.Point(89, 331);
			_lbl_gen_103.MinimumSize = new System.Drawing.Size(34, 13);
			_lbl_gen_103.Name = "_lbl_gen_103";
			_lbl_gen_103.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_103.Size = new System.Drawing.Size(34, 13);
			_lbl_gen_103.TabIndex = 219;
			_lbl_gen_103.Text = "Prop 1:";
			_lbl_gen_103.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_103.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_104
			// 
			_lbl_gen_104.AllowDrop = true;
			_lbl_gen_104.AutoSize = true;
			_lbl_gen_104.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_104.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_104.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_104.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_104.Location = new System.Drawing.Point(89, 354);
			_lbl_gen_104.MinimumSize = new System.Drawing.Size(34, 13);
			_lbl_gen_104.Name = "_lbl_gen_104";
			_lbl_gen_104.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_104.Size = new System.Drawing.Size(34, 13);
			_lbl_gen_104.TabIndex = 220;
			_lbl_gen_104.Text = "Prop 2:";
			_lbl_gen_104.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_104.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_72
			// 
			_lbl_gen_72.AllowDrop = true;
			_lbl_gen_72.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_72.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_72.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_72.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_72.Location = new System.Drawing.Point(154, 288);
			_lbl_gen_72.MinimumSize = new System.Drawing.Size(49, 29);
			_lbl_gen_72.Name = "_lbl_gen_72";
			_lbl_gen_72.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_72.Size = new System.Drawing.Size(49, 29);
			_lbl_gen_72.TabIndex = 221;
			_lbl_gen_72.Text = "Serial Number";
			_lbl_gen_72.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_72.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_72.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_73
			// 
			_lbl_gen_73.AllowDrop = true;
			_lbl_gen_73.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_73.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_73.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_73.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_73.Location = new System.Drawing.Point(295, 270);
			_lbl_gen_73.MinimumSize = new System.Drawing.Size(65, 57);
			_lbl_gen_73.Name = "_lbl_gen_73";
			_lbl_gen_73.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_73.Size = new System.Drawing.Size(65, 57);
			_lbl_gen_73.TabIndex = 222;
			_lbl_gen_73.Text = "Since Prop Overhaul (SPOH) Hours";
			_lbl_gen_73.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_73.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_73.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_105
			// 
			_lbl_gen_105.AllowDrop = true;
			_lbl_gen_105.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_105.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_105.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_105.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_105.Location = new System.Drawing.Point(368, 270);
			_lbl_gen_105.MinimumSize = new System.Drawing.Size(65, 57);
			_lbl_gen_105.Name = "_lbl_gen_105";
			_lbl_gen_105.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_105.Size = new System.Drawing.Size(65, 57);
			_lbl_gen_105.TabIndex = 223;
			_lbl_gen_105.Text = "Month and Year of Prop Overhaul MM/YYYY";
			_lbl_gen_105.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_105.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_105.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_106
			// 
			_lbl_gen_106.AllowDrop = true;
			_lbl_gen_106.AutoSize = true;
			_lbl_gen_106.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_106.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_106.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_106.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_106.Location = new System.Drawing.Point(87, 391);
			_lbl_gen_106.MinimumSize = new System.Drawing.Size(34, 13);
			_lbl_gen_106.Name = "_lbl_gen_106";
			_lbl_gen_106.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_106.Size = new System.Drawing.Size(34, 13);
			_lbl_gen_106.TabIndex = 224;
			_lbl_gen_106.Text = "Prop 4:";
			_lbl_gen_106.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_106.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_107
			// 
			_lbl_gen_107.AllowDrop = true;
			_lbl_gen_107.AutoSize = true;
			_lbl_gen_107.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_107.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_107.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_107.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_107.Location = new System.Drawing.Point(89, 378);
			_lbl_gen_107.MinimumSize = new System.Drawing.Size(34, 13);
			_lbl_gen_107.Name = "_lbl_gen_107";
			_lbl_gen_107.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_107.Size = new System.Drawing.Size(34, 13);
			_lbl_gen_107.TabIndex = 225;
			_lbl_gen_107.Text = "Prop 3:";
			_lbl_gen_107.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_107.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_40
			// 
			_lbl_gen_40.AllowDrop = true;
			_lbl_gen_40.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_40.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_40.Location = new System.Drawing.Point(232, 283);
			_lbl_gen_40.MinimumSize = new System.Drawing.Size(65, 44);
			_lbl_gen_40.Name = "_lbl_gen_40";
			_lbl_gen_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_40.Size = new System.Drawing.Size(65, 44);
			_lbl_gen_40.TabIndex = 226;
			_lbl_gen_40.Text = "Total Time Since Prop New";
			_lbl_gen_40.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_40.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_40.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_58
			// 
			_lbl_gen_58.AllowDrop = true;
			_lbl_gen_58.AutoSize = true;
			_lbl_gen_58.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_58.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_58.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_58.Location = new System.Drawing.Point(58, 270);
			_lbl_gen_58.MinimumSize = new System.Drawing.Size(217, 13);
			_lbl_gen_58.Name = "_lbl_gen_58";
			_lbl_gen_58.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_58.Size = new System.Drawing.Size(217, 13);
			_lbl_gen_58.TabIndex = 227;
			_lbl_gen_58.Text = "HELICOPTER ROTOR INFORMATION";
			_lbl_gen_58.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_58.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_58.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_28
			// 
			_lbl_gen_28.AllowDrop = true;
			_lbl_gen_28.AutoSize = true;
			_lbl_gen_28.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_28.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_28.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_28.Location = new System.Drawing.Point(550, 8);
			_lbl_gen_28.MinimumSize = new System.Drawing.Size(170, 13);
			_lbl_gen_28.Name = "_lbl_gen_28";
			_lbl_gen_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_28.Size = new System.Drawing.Size(170, 13);
			_lbl_gen_28.TabIndex = 228;
			_lbl_gen_28.Text = "Times/Values As of: MM/DD/YYYY";
			_lbl_gen_28.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_28.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_70
			// 
			_lbl_gen_70.AllowDrop = true;
			_lbl_gen_70.AutoSize = true;
			_lbl_gen_70.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_70.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_70.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_70.Location = new System.Drawing.Point(549, 31);
			_lbl_gen_70.MinimumSize = new System.Drawing.Size(130, 13);
			_lbl_gen_70.Name = "_lbl_gen_70";
			_lbl_gen_70.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_70.Size = new System.Drawing.Size(130, 13);
			_lbl_gen_70.TabIndex = 229;
			_lbl_gen_70.Text = "Airframe Total Time (AFTT):";
			_lbl_gen_70.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_70.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_71
			// 
			_lbl_gen_71.AllowDrop = true;
			_lbl_gen_71.AutoSize = true;
			_lbl_gen_71.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_71.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_71.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_71.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_71.Location = new System.Drawing.Point(748, 31);
			_lbl_gen_71.MinimumSize = new System.Drawing.Size(82, 13);
			_lbl_gen_71.Name = "_lbl_gen_71";
			_lbl_gen_71.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_71.Size = new System.Drawing.Size(82, 13);
			_lbl_gen_71.TabIndex = 230;
			_lbl_gen_71.Text = "Landings/Cycles:";
			_lbl_gen_71.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_71.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_59
			// 
			_lbl_gen_59.AllowDrop = true;
			_lbl_gen_59.AutoSize = true;
			_lbl_gen_59.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_59.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_59.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_59.Location = new System.Drawing.Point(390, 331);
			_lbl_gen_59.MinimumSize = new System.Drawing.Size(5, 13);
			_lbl_gen_59.Name = "_lbl_gen_59";
			_lbl_gen_59.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_59.Size = new System.Drawing.Size(5, 13);
			_lbl_gen_59.TabIndex = 231;
			_lbl_gen_59.Text = "/";
			_lbl_gen_59.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_59.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_60
			// 
			_lbl_gen_60.AllowDrop = true;
			_lbl_gen_60.AutoSize = true;
			_lbl_gen_60.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_60.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_60.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_60.Location = new System.Drawing.Point(390, 354);
			_lbl_gen_60.MinimumSize = new System.Drawing.Size(5, 13);
			_lbl_gen_60.Name = "_lbl_gen_60";
			_lbl_gen_60.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_60.Size = new System.Drawing.Size(5, 13);
			_lbl_gen_60.TabIndex = 232;
			_lbl_gen_60.Text = "/";
			_lbl_gen_60.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_60.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_61
			// 
			_lbl_gen_61.AllowDrop = true;
			_lbl_gen_61.AutoSize = true;
			_lbl_gen_61.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_61.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_61.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_61.Location = new System.Drawing.Point(390, 378);
			_lbl_gen_61.MinimumSize = new System.Drawing.Size(5, 13);
			_lbl_gen_61.Name = "_lbl_gen_61";
			_lbl_gen_61.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_61.Size = new System.Drawing.Size(5, 13);
			_lbl_gen_61.TabIndex = 233;
			_lbl_gen_61.Text = "/";
			_lbl_gen_61.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_61.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_62
			// 
			_lbl_gen_62.AllowDrop = true;
			_lbl_gen_62.AutoSize = true;
			_lbl_gen_62.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_62.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_62.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_62.Location = new System.Drawing.Point(390, 401);
			_lbl_gen_62.MinimumSize = new System.Drawing.Size(5, 13);
			_lbl_gen_62.Name = "_lbl_gen_62";
			_lbl_gen_62.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_62.Size = new System.Drawing.Size(5, 13);
			_lbl_gen_62.TabIndex = 234;
			_lbl_gen_62.Text = "/";
			_lbl_gen_62.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_62.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_57
			// 
			_lbl_gen_57.AllowDrop = true;
			_lbl_gen_57.AutoSize = true;
			_lbl_gen_57.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_57.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_57.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_57.Location = new System.Drawing.Point(14, 14);
			_lbl_gen_57.MinimumSize = new System.Drawing.Size(48, 13);
			_lbl_gen_57.Name = "_lbl_gen_57";
			_lbl_gen_57.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_57.Size = new System.Drawing.Size(48, 13);
			_lbl_gen_57.TabIndex = 312;
			_lbl_gen_57.Text = "ENGINE";
			_lbl_gen_57.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_57.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_92
			// 
			_lbl_gen_92.AllowDrop = true;
			_lbl_gen_92.AutoSize = true;
			_lbl_gen_92.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_92.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_92.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_92.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_92.Location = new System.Drawing.Point(5, 62);
			_lbl_gen_92.MinimumSize = new System.Drawing.Size(147, 13);
			_lbl_gen_92.Name = "_lbl_gen_92";
			_lbl_gen_92.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_92.Size = new System.Drawing.Size(147, 13);
			_lbl_gen_92.TabIndex = 313;
			_lbl_gen_92.Text = "Management Program (EMGP):";
			_lbl_gen_92.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_92.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _Label1_1
			// 
			_Label1_1.AllowDrop = true;
			_Label1_1.BackColor = System.Drawing.SystemColors.Control;
			_Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_1.Location = new System.Drawing.Point(362, 12);
			_Label1_1.MinimumSize = new System.Drawing.Size(107, 33);
			_Label1_1.Name = "_Label1_1";
			_Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_1.Size = new System.Drawing.Size(107, 33);
			_Label1_1.TabIndex = 347;
			_Label1_1.Text = "Noise Rating:";
			// 
			// _lbl_gen_89
			// 
			_lbl_gen_89.AllowDrop = true;
			_lbl_gen_89.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_89.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_89.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_89.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_89.Location = new System.Drawing.Point(438, 91);
			_lbl_gen_89.MinimumSize = new System.Drawing.Size(45, 53);
			_lbl_gen_89.Name = "_lbl_gen_89";
			_lbl_gen_89.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_89.Size = new System.Drawing.Size(45, 53);
			_lbl_gen_89.TabIndex = 350;
			_lbl_gen_89.Text = "Total Cycles Since Overhaul";
			_lbl_gen_89.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_89.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_89.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_90
			// 
			_lbl_gen_90.AllowDrop = true;
			_lbl_gen_90.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_90.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_90.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_90.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_90.Location = new System.Drawing.Point(382, 91);
			_lbl_gen_90.MinimumSize = new System.Drawing.Size(35, 51);
			_lbl_gen_90.Name = "_lbl_gen_90";
			_lbl_gen_90.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_90.Size = new System.Drawing.Size(35, 51);
			_lbl_gen_90.TabIndex = 351;
			_lbl_gen_90.Text = "Total Cycles Since New";
			_lbl_gen_90.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_90.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_90.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_26
			// 
			_lbl_gen_26.AllowDrop = true;
			_lbl_gen_26.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_26.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_26.Location = new System.Drawing.Point(310, 80);
			_lbl_gen_26.MinimumSize = new System.Drawing.Size(57, 64);
			_lbl_gen_26.Name = "_lbl_gen_26";
			_lbl_gen_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_26.Size = new System.Drawing.Size(57, 64);
			_lbl_gen_26.TabIndex = 352;
			_lbl_gen_26.Text = "Time Between Overhaul (TBO/TBCI) Hours";
			_lbl_gen_26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_26.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_26.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_25
			// 
			_lbl_gen_25.AllowDrop = true;
			_lbl_gen_25.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_25.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_25.Location = new System.Drawing.Point(248, 93);
			_lbl_gen_25.MinimumSize = new System.Drawing.Size(60, 51);
			_lbl_gen_25.Name = "_lbl_gen_25";
			_lbl_gen_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_25.Size = new System.Drawing.Size(60, 51);
			_lbl_gen_25.TabIndex = 353;
			_lbl_gen_25.Text = "Since Hot Inspection (SHI/SMPI) Hours";
			_lbl_gen_25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_25.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_25.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_24
			// 
			_lbl_gen_24.AllowDrop = true;
			_lbl_gen_24.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_24.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_24.Location = new System.Drawing.Point(186, 93);
			_lbl_gen_24.MinimumSize = new System.Drawing.Size(63, 57);
			_lbl_gen_24.Name = "_lbl_gen_24";
			_lbl_gen_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_24.Size = new System.Drawing.Size(63, 57);
			_lbl_gen_24.TabIndex = 354;
			_lbl_gen_24.Text = "Since Overhaul (SOH/SCOR) Hours";
			_lbl_gen_24.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_24.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_24.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_23
			// 
			_lbl_gen_23.AllowDrop = true;
			_lbl_gen_23.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_23.Location = new System.Drawing.Point(63, 119);
			_lbl_gen_23.MinimumSize = new System.Drawing.Size(49, 31);
			_lbl_gen_23.Name = "_lbl_gen_23";
			_lbl_gen_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_23.Size = new System.Drawing.Size(49, 31);
			_lbl_gen_23.TabIndex = 355;
			_lbl_gen_23.Text = "Serial Number";
			_lbl_gen_23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_23.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_23.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_18
			// 
			_lbl_gen_18.AllowDrop = true;
			_lbl_gen_18.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_18.Location = new System.Drawing.Point(128, 93);
			_lbl_gen_18.MinimumSize = new System.Drawing.Size(57, 57);
			_lbl_gen_18.Name = "_lbl_gen_18";
			_lbl_gen_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_18.Size = new System.Drawing.Size(57, 57);
			_lbl_gen_18.TabIndex = 356;
			_lbl_gen_18.Text = "Total Time Since New (TTSNEW) Hours";
			_lbl_gen_18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_18.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_18.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_35
			// 
			_lbl_gen_35.AllowDrop = true;
			_lbl_gen_35.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_35.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_35.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_35.Location = new System.Drawing.Point(499, 90);
			_lbl_gen_35.MinimumSize = new System.Drawing.Size(36, 51);
			_lbl_gen_35.Name = "_lbl_gen_35";
			_lbl_gen_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_35.Size = new System.Drawing.Size(36, 51);
			_lbl_gen_35.TabIndex = 357;
			_lbl_gen_35.Text = "Total Cycles Since Hot";
			_lbl_gen_35.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_35.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_35.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_117
			// 
			_lbl_gen_117.AllowDrop = true;
			_lbl_gen_117.AutoSize = true;
			_lbl_gen_117.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_117.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_117.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_117.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_117.Location = new System.Drawing.Point(824, 6);
			_lbl_gen_117.MinimumSize = new System.Drawing.Size(64, 13);
			_lbl_gen_117.Name = "_lbl_gen_117";
			_lbl_gen_117.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_117.Size = new System.Drawing.Size(64, 13);
			_lbl_gen_117.TabIndex = 403;
			_lbl_gen_117.Text = "Hidden Price:";
			_lbl_gen_117.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_117.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_51
			// 
			_lbl_gen_51.AllowDrop = true;
			_lbl_gen_51.AutoSize = true;
			_lbl_gen_51.BackColor = System.Drawing.Color.Aqua;
			_lbl_gen_51.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_51.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_51.Location = new System.Drawing.Point(440, 436);
			_lbl_gen_51.MinimumSize = new System.Drawing.Size(131, 13);
			_lbl_gen_51.Name = "_lbl_gen_51";
			_lbl_gen_51.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_51.Size = new System.Drawing.Size(131, 13);
			_lbl_gen_51.TabIndex = 456;
			_lbl_gen_51.Text = "---- YOU ARE ON TEST ---- ";
			_lbl_gen_51.Visible = false;
			_lbl_gen_51.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_51.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _grd_Features_4
			// 
			_grd_Features_4.AllowDrop = true;
			_grd_Features_4.AllowUserToAddRows = false;
			_grd_Features_4.AllowUserToDeleteRows = false;
			_grd_Features_4.AllowUserToResizeColumns = false;
			_grd_Features_4.AllowUserToResizeColumns = _grd_Features_4.ColumnHeadersVisible;
			_grd_Features_4.AllowUserToResizeRows = false;
			_grd_Features_4.AllowUserToResizeRows = _grd_Features_4.RowHeadersVisible;
			_grd_Features_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_grd_Features_4.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			_grd_Features_4.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			_grd_Features_4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			_grd_Features_4.ColumnsCount = 2;
			_grd_Features_4.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			_grd_Features_4.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Control;
			_grd_Features_4.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			_grd_Features_4.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			_grd_Features_4.FixedColumns = 1;
			_grd_Features_4.FixedRows = 1;
			_grd_Features_4.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			_grd_Features_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_grd_Features_4.Location = new System.Drawing.Point(552, 108);
			_grd_Features_4.Name = "_grd_Features_4";
			_grd_Features_4.ReadOnly = true;
			_grd_Features_4.RowsCount = 2;
			_grd_Features_4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			_grd_Features_4.ShowCellToolTips = false;
			_grd_Features_4.Size = new System.Drawing.Size(442, 185);
			_grd_Features_4.StandardTab = true;
			_grd_Features_4.TabIndex = 439;
			_grd_Features_4.DoubleClick += new System.EventHandler(grd_Features_DoubleClick);
			// 
			// _txt_ac_prop_soh_hrs_1
			// 
			_txt_ac_prop_soh_hrs_1.AcceptsReturn = true;
			_txt_ac_prop_soh_hrs_1.AllowDrop = true;
			_txt_ac_prop_soh_hrs_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_soh_hrs_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_soh_hrs_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_soh_hrs_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_soh_hrs_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_soh_hrs_1.Location = new System.Drawing.Point(295, 351);
			_txt_ac_prop_soh_hrs_1.MaxLength = 0;
			_txt_ac_prop_soh_hrs_1.Name = "_txt_ac_prop_soh_hrs_1";
			_txt_ac_prop_soh_hrs_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_soh_hrs_1.Size = new System.Drawing.Size(57, 19);
			_txt_ac_prop_soh_hrs_1.TabIndex = 74;
			_txt_ac_prop_soh_hrs_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_soh_hrs_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_soh_hrs_KeyDown);
			// 
			// _txt_ac_prop_soh_hrs_0
			// 
			_txt_ac_prop_soh_hrs_0.AcceptsReturn = true;
			_txt_ac_prop_soh_hrs_0.AllowDrop = true;
			_txt_ac_prop_soh_hrs_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_soh_hrs_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_soh_hrs_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_soh_hrs_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_soh_hrs_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_soh_hrs_0.Location = new System.Drawing.Point(295, 328);
			_txt_ac_prop_soh_hrs_0.MaxLength = 0;
			_txt_ac_prop_soh_hrs_0.Name = "_txt_ac_prop_soh_hrs_0";
			_txt_ac_prop_soh_hrs_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_soh_hrs_0.Size = new System.Drawing.Size(57, 19);
			_txt_ac_prop_soh_hrs_0.TabIndex = 69;
			_txt_ac_prop_soh_hrs_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_soh_hrs_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_soh_hrs_KeyDown);
			// 
			// _txt_ac_prop_soh_hrs_2
			// 
			_txt_ac_prop_soh_hrs_2.AcceptsReturn = true;
			_txt_ac_prop_soh_hrs_2.AllowDrop = true;
			_txt_ac_prop_soh_hrs_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_soh_hrs_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_soh_hrs_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_soh_hrs_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_soh_hrs_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_soh_hrs_2.Location = new System.Drawing.Point(295, 375);
			_txt_ac_prop_soh_hrs_2.MaxLength = 0;
			_txt_ac_prop_soh_hrs_2.Name = "_txt_ac_prop_soh_hrs_2";
			_txt_ac_prop_soh_hrs_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_soh_hrs_2.Size = new System.Drawing.Size(57, 19);
			_txt_ac_prop_soh_hrs_2.TabIndex = 79;
			_txt_ac_prop_soh_hrs_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_soh_hrs_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_soh_hrs_KeyDown);
			// 
			// _txt_ac_prop_soh_hrs_3
			// 
			_txt_ac_prop_soh_hrs_3.AcceptsReturn = true;
			_txt_ac_prop_soh_hrs_3.AllowDrop = true;
			_txt_ac_prop_soh_hrs_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_soh_hrs_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_soh_hrs_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_soh_hrs_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_soh_hrs_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_soh_hrs_3.Location = new System.Drawing.Point(295, 398);
			_txt_ac_prop_soh_hrs_3.MaxLength = 0;
			_txt_ac_prop_soh_hrs_3.Name = "_txt_ac_prop_soh_hrs_3";
			_txt_ac_prop_soh_hrs_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_soh_hrs_3.Size = new System.Drawing.Size(57, 19);
			_txt_ac_prop_soh_hrs_3.TabIndex = 84;
			_txt_ac_prop_soh_hrs_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_soh_hrs_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_soh_hrs_KeyDown);
			// 
			// _txt_ac_prop_soh_year_2
			// 
			_txt_ac_prop_soh_year_2.AcceptsReturn = true;
			_txt_ac_prop_soh_year_2.AllowDrop = true;
			_txt_ac_prop_soh_year_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_soh_year_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_soh_year_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_soh_year_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_soh_year_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_soh_year_2.Location = new System.Drawing.Point(400, 375);
			_txt_ac_prop_soh_year_2.MaxLength = 4;
			_txt_ac_prop_soh_year_2.Name = "_txt_ac_prop_soh_year_2";
			_txt_ac_prop_soh_year_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_soh_year_2.Size = new System.Drawing.Size(39, 19);
			_txt_ac_prop_soh_year_2.TabIndex = 81;
			_txt_ac_prop_soh_year_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_soh_year_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_soh_year_KeyDown);
			// 
			// _txt_ac_prop_soh_year_3
			// 
			_txt_ac_prop_soh_year_3.AcceptsReturn = true;
			_txt_ac_prop_soh_year_3.AllowDrop = true;
			_txt_ac_prop_soh_year_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_soh_year_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_soh_year_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_soh_year_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_soh_year_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_soh_year_3.Location = new System.Drawing.Point(400, 398);
			_txt_ac_prop_soh_year_3.MaxLength = 4;
			_txt_ac_prop_soh_year_3.Name = "_txt_ac_prop_soh_year_3";
			_txt_ac_prop_soh_year_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_soh_year_3.Size = new System.Drawing.Size(39, 19);
			_txt_ac_prop_soh_year_3.TabIndex = 86;
			_txt_ac_prop_soh_year_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_soh_year_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_soh_year_KeyDown);
			// 
			// _txt_ac_prop_soh_year_1
			// 
			_txt_ac_prop_soh_year_1.AcceptsReturn = true;
			_txt_ac_prop_soh_year_1.AllowDrop = true;
			_txt_ac_prop_soh_year_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_soh_year_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_soh_year_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_soh_year_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_soh_year_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_soh_year_1.Location = new System.Drawing.Point(400, 351);
			_txt_ac_prop_soh_year_1.MaxLength = 4;
			_txt_ac_prop_soh_year_1.Name = "_txt_ac_prop_soh_year_1";
			_txt_ac_prop_soh_year_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_soh_year_1.Size = new System.Drawing.Size(39, 19);
			_txt_ac_prop_soh_year_1.TabIndex = 76;
			_txt_ac_prop_soh_year_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_soh_year_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_soh_year_KeyDown);
			// 
			// _txt_ac_prop_soh_year_0
			// 
			_txt_ac_prop_soh_year_0.AcceptsReturn = true;
			_txt_ac_prop_soh_year_0.AllowDrop = true;
			_txt_ac_prop_soh_year_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_soh_year_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_soh_year_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_soh_year_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_soh_year_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_soh_year_0.Location = new System.Drawing.Point(400, 328);
			_txt_ac_prop_soh_year_0.MaxLength = 4;
			_txt_ac_prop_soh_year_0.Name = "_txt_ac_prop_soh_year_0";
			_txt_ac_prop_soh_year_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_soh_year_0.Size = new System.Drawing.Size(39, 19);
			_txt_ac_prop_soh_year_0.TabIndex = 71;
			_txt_ac_prop_soh_year_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_soh_year_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_soh_year_KeyDown);
			// 
			// _txt_ac_prop_snew_hrs_1
			// 
			_txt_ac_prop_snew_hrs_1.AcceptsReturn = true;
			_txt_ac_prop_snew_hrs_1.AllowDrop = true;
			_txt_ac_prop_snew_hrs_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_snew_hrs_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_snew_hrs_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_snew_hrs_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_snew_hrs_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_snew_hrs_1.Location = new System.Drawing.Point(233, 351);
			_txt_ac_prop_snew_hrs_1.MaxLength = 0;
			_txt_ac_prop_snew_hrs_1.Name = "_txt_ac_prop_snew_hrs_1";
			_txt_ac_prop_snew_hrs_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_snew_hrs_1.Size = new System.Drawing.Size(57, 19);
			_txt_ac_prop_snew_hrs_1.TabIndex = 73;
			_txt_ac_prop_snew_hrs_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_snew_hrs_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_snew_hrs_KeyDown);
			// 
			// _txt_ac_prop_snew_hrs_0
			// 
			_txt_ac_prop_snew_hrs_0.AcceptsReturn = true;
			_txt_ac_prop_snew_hrs_0.AllowDrop = true;
			_txt_ac_prop_snew_hrs_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_snew_hrs_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_snew_hrs_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_snew_hrs_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_snew_hrs_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_snew_hrs_0.Location = new System.Drawing.Point(233, 328);
			_txt_ac_prop_snew_hrs_0.MaxLength = 0;
			_txt_ac_prop_snew_hrs_0.Name = "_txt_ac_prop_snew_hrs_0";
			_txt_ac_prop_snew_hrs_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_snew_hrs_0.Size = new System.Drawing.Size(57, 19);
			_txt_ac_prop_snew_hrs_0.TabIndex = 68;
			_txt_ac_prop_snew_hrs_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_snew_hrs_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_snew_hrs_KeyDown);
			// 
			// _txt_ac_prop_snew_hrs_2
			// 
			_txt_ac_prop_snew_hrs_2.AcceptsReturn = true;
			_txt_ac_prop_snew_hrs_2.AllowDrop = true;
			_txt_ac_prop_snew_hrs_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_snew_hrs_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_snew_hrs_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_snew_hrs_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_snew_hrs_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_snew_hrs_2.Location = new System.Drawing.Point(233, 375);
			_txt_ac_prop_snew_hrs_2.MaxLength = 0;
			_txt_ac_prop_snew_hrs_2.Name = "_txt_ac_prop_snew_hrs_2";
			_txt_ac_prop_snew_hrs_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_snew_hrs_2.Size = new System.Drawing.Size(57, 19);
			_txt_ac_prop_snew_hrs_2.TabIndex = 78;
			_txt_ac_prop_snew_hrs_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_snew_hrs_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_snew_hrs_KeyDown);
			// 
			// _txt_ac_prop_snew_hrs_3
			// 
			_txt_ac_prop_snew_hrs_3.AcceptsReturn = true;
			_txt_ac_prop_snew_hrs_3.AllowDrop = true;
			_txt_ac_prop_snew_hrs_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_snew_hrs_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_snew_hrs_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_snew_hrs_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_snew_hrs_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_snew_hrs_3.Location = new System.Drawing.Point(233, 398);
			_txt_ac_prop_snew_hrs_3.MaxLength = 0;
			_txt_ac_prop_snew_hrs_3.Name = "_txt_ac_prop_snew_hrs_3";
			_txt_ac_prop_snew_hrs_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_snew_hrs_3.Size = new System.Drawing.Size(57, 19);
			_txt_ac_prop_snew_hrs_3.TabIndex = 83;
			_txt_ac_prop_snew_hrs_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_snew_hrs_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_snew_hrs_KeyDown);
			// 
			// _txt_ac_prop_ser_no_3
			// 
			_txt_ac_prop_ser_no_3.AcceptsReturn = true;
			_txt_ac_prop_ser_no_3.AllowDrop = true;
			_txt_ac_prop_ser_no_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_ser_no_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_ser_no_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_ser_no_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_ser_no_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_ser_no_3.Location = new System.Drawing.Point(132, 398);
			_txt_ac_prop_ser_no_3.MaxLength = 14;
			_txt_ac_prop_ser_no_3.Name = "_txt_ac_prop_ser_no_3";
			_txt_ac_prop_ser_no_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_ser_no_3.Size = new System.Drawing.Size(97, 19);
			_txt_ac_prop_ser_no_3.TabIndex = 82;
			_txt_ac_prop_ser_no_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_ser_no_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_ser_no_KeyDown);
			// 
			// _txt_ac_prop_ser_no_2
			// 
			_txt_ac_prop_ser_no_2.AcceptsReturn = true;
			_txt_ac_prop_ser_no_2.AllowDrop = true;
			_txt_ac_prop_ser_no_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_ser_no_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_ser_no_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_ser_no_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_ser_no_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_ser_no_2.Location = new System.Drawing.Point(132, 375);
			_txt_ac_prop_ser_no_2.MaxLength = 14;
			_txt_ac_prop_ser_no_2.Name = "_txt_ac_prop_ser_no_2";
			_txt_ac_prop_ser_no_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_ser_no_2.Size = new System.Drawing.Size(97, 19);
			_txt_ac_prop_ser_no_2.TabIndex = 77;
			_txt_ac_prop_ser_no_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_ser_no_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_ser_no_KeyDown);
			// 
			// _txt_ac_prop_soh_mo_3
			// 
			_txt_ac_prop_soh_mo_3.AcceptsReturn = true;
			_txt_ac_prop_soh_mo_3.AllowDrop = true;
			_txt_ac_prop_soh_mo_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_soh_mo_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_soh_mo_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_soh_mo_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_soh_mo_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_soh_mo_3.Location = new System.Drawing.Point(357, 398);
			_txt_ac_prop_soh_mo_3.MaxLength = 2;
			_txt_ac_prop_soh_mo_3.Name = "_txt_ac_prop_soh_mo_3";
			_txt_ac_prop_soh_mo_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_soh_mo_3.Size = new System.Drawing.Size(28, 19);
			_txt_ac_prop_soh_mo_3.TabIndex = 85;
			_txt_ac_prop_soh_mo_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_soh_mo_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_soh_mo_KeyDown);
			// 
			// _txt_ac_prop_soh_mo_2
			// 
			_txt_ac_prop_soh_mo_2.AcceptsReturn = true;
			_txt_ac_prop_soh_mo_2.AllowDrop = true;
			_txt_ac_prop_soh_mo_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_soh_mo_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_soh_mo_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_soh_mo_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_soh_mo_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_soh_mo_2.Location = new System.Drawing.Point(357, 375);
			_txt_ac_prop_soh_mo_2.MaxLength = 2;
			_txt_ac_prop_soh_mo_2.Name = "_txt_ac_prop_soh_mo_2";
			_txt_ac_prop_soh_mo_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_soh_mo_2.Size = new System.Drawing.Size(28, 19);
			_txt_ac_prop_soh_mo_2.TabIndex = 80;
			_txt_ac_prop_soh_mo_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_soh_mo_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_soh_mo_KeyDown);
			// 
			// _txt_ac_prop_soh_mo_0
			// 
			_txt_ac_prop_soh_mo_0.AcceptsReturn = true;
			_txt_ac_prop_soh_mo_0.AllowDrop = true;
			_txt_ac_prop_soh_mo_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_soh_mo_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_soh_mo_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_soh_mo_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_soh_mo_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_soh_mo_0.Location = new System.Drawing.Point(357, 328);
			_txt_ac_prop_soh_mo_0.MaxLength = 2;
			_txt_ac_prop_soh_mo_0.Name = "_txt_ac_prop_soh_mo_0";
			_txt_ac_prop_soh_mo_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_soh_mo_0.Size = new System.Drawing.Size(28, 19);
			_txt_ac_prop_soh_mo_0.TabIndex = 70;
			_txt_ac_prop_soh_mo_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_soh_mo_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_soh_mo_KeyDown);
			// 
			// _txt_ac_prop_soh_mo_1
			// 
			_txt_ac_prop_soh_mo_1.AcceptsReturn = true;
			_txt_ac_prop_soh_mo_1.AllowDrop = true;
			_txt_ac_prop_soh_mo_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_soh_mo_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_soh_mo_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_soh_mo_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_soh_mo_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_soh_mo_1.Location = new System.Drawing.Point(357, 351);
			_txt_ac_prop_soh_mo_1.MaxLength = 2;
			_txt_ac_prop_soh_mo_1.Name = "_txt_ac_prop_soh_mo_1";
			_txt_ac_prop_soh_mo_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_soh_mo_1.Size = new System.Drawing.Size(28, 19);
			_txt_ac_prop_soh_mo_1.TabIndex = 75;
			_txt_ac_prop_soh_mo_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_soh_mo_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_soh_mo_KeyDown);
			// 
			// _txt_ac_prop_ser_no_0
			// 
			_txt_ac_prop_ser_no_0.AcceptsReturn = true;
			_txt_ac_prop_ser_no_0.AllowDrop = true;
			_txt_ac_prop_ser_no_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_ser_no_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_ser_no_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_ser_no_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_ser_no_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_ser_no_0.Location = new System.Drawing.Point(132, 328);
			_txt_ac_prop_ser_no_0.MaxLength = 14;
			_txt_ac_prop_ser_no_0.Name = "_txt_ac_prop_ser_no_0";
			_txt_ac_prop_ser_no_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_ser_no_0.Size = new System.Drawing.Size(97, 19);
			_txt_ac_prop_ser_no_0.TabIndex = 67;
			_txt_ac_prop_ser_no_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_ser_no_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_ser_no_KeyDown);
			// 
			// _txt_ac_prop_ser_no_1
			// 
			_txt_ac_prop_ser_no_1.AcceptsReturn = true;
			_txt_ac_prop_ser_no_1.AllowDrop = true;
			_txt_ac_prop_ser_no_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_prop_ser_no_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_prop_ser_no_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_prop_ser_no_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_prop_ser_no_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_prop_ser_no_1.Location = new System.Drawing.Point(132, 350);
			_txt_ac_prop_ser_no_1.MaxLength = 14;
			_txt_ac_prop_ser_no_1.Name = "_txt_ac_prop_ser_no_1";
			_txt_ac_prop_ser_no_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_prop_ser_no_1.Size = new System.Drawing.Size(97, 19);
			_txt_ac_prop_ser_no_1.TabIndex = 72;
			_txt_ac_prop_ser_no_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_prop_ser_no_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_prop_ser_no_KeyDown);
			// 
			// txt_ac_confidential_notes
			// 
			txt_ac_confidential_notes.AcceptsReturn = true;
			txt_ac_confidential_notes.AllowDrop = true;
			txt_ac_confidential_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_confidential_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_confidential_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_confidential_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_confidential_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_confidential_notes.Location = new System.Drawing.Point(548, 64);
			txt_ac_confidential_notes.MaxLength = 250;
			txt_ac_confidential_notes.Multiline = true;
			txt_ac_confidential_notes.Name = "txt_ac_confidential_notes";
			txt_ac_confidential_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_confidential_notes.Size = new System.Drawing.Size(447, 39);
			txt_ac_confidential_notes.TabIndex = 92;
			// 
			// cbo_ac_apu_maint_prog
			// 
			cbo_ac_apu_maint_prog.AllowDrop = true;
			cbo_ac_apu_maint_prog.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_apu_maint_prog.CausesValidation = true;
			cbo_ac_apu_maint_prog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_apu_maint_prog.Enabled = true;
			cbo_ac_apu_maint_prog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_apu_maint_prog.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_apu_maint_prog.IntegralHeight = true;
			cbo_ac_apu_maint_prog.Location = new System.Drawing.Point(696, 357);
			cbo_ac_apu_maint_prog.Name = "cbo_ac_apu_maint_prog";
			cbo_ac_apu_maint_prog.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_apu_maint_prog.Size = new System.Drawing.Size(297, 21);
			cbo_ac_apu_maint_prog.Sorted = false;
			cbo_ac_apu_maint_prog.TabIndex = 89;
			cbo_ac_apu_maint_prog.TabStop = true;
			cbo_ac_apu_maint_prog.Text = "cbo_ac_apu_maint_prog";
			cbo_ac_apu_maint_prog.Visible = true;
			// 
			// _txt_ac_apu_0
			// 
			_txt_ac_apu_0.AcceptsReturn = true;
			_txt_ac_apu_0.AllowDrop = true;
			_txt_ac_apu_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_apu_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_apu_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_apu_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_apu_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_apu_0.Location = new System.Drawing.Point(698, 334);
			_txt_ac_apu_0.MaxLength = 20;
			_txt_ac_apu_0.Name = "_txt_ac_apu_0";
			_txt_ac_apu_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_apu_0.Size = new System.Drawing.Size(109, 19);
			_txt_ac_apu_0.TabIndex = 88;
			_txt_ac_apu_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_ac_apu_1
			// 
			_txt_ac_apu_1.AcceptsReturn = true;
			_txt_ac_apu_1.AllowDrop = true;
			_txt_ac_apu_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_apu_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_apu_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_apu_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_apu_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_apu_1.Location = new System.Drawing.Point(699, 381);
			_txt_ac_apu_1.MaxLength = 0;
			_txt_ac_apu_1.Name = "_txt_ac_apu_1";
			_txt_ac_apu_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_apu_1.Size = new System.Drawing.Size(57, 19);
			_txt_ac_apu_1.TabIndex = 90;
			_txt_ac_apu_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_ac_apu_2
			// 
			_txt_ac_apu_2.AcceptsReturn = true;
			_txt_ac_apu_2.AllowDrop = true;
			_txt_ac_apu_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_apu_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_apu_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_apu_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_apu_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_apu_2.Location = new System.Drawing.Point(699, 405);
			_txt_ac_apu_2.MaxLength = 0;
			_txt_ac_apu_2.Name = "_txt_ac_apu_2";
			_txt_ac_apu_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_apu_2.Size = new System.Drawing.Size(57, 19);
			_txt_ac_apu_2.TabIndex = 91;
			_txt_ac_apu_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cbo_ac_apu_model_name
			// 
			cbo_ac_apu_model_name.AllowDrop = true;
			cbo_ac_apu_model_name.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_apu_model_name.CausesValidation = true;
			cbo_ac_apu_model_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_apu_model_name.Enabled = true;
			cbo_ac_apu_model_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_apu_model_name.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_apu_model_name.IntegralHeight = true;
			cbo_ac_apu_model_name.Location = new System.Drawing.Point(696, 308);
			cbo_ac_apu_model_name.Name = "cbo_ac_apu_model_name";
			cbo_ac_apu_model_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_apu_model_name.Size = new System.Drawing.Size(297, 21);
			cbo_ac_apu_model_name.Sorted = false;
			cbo_ac_apu_model_name.TabIndex = 87;
			cbo_ac_apu_model_name.TabStop = true;
			cbo_ac_apu_model_name.Visible = true;
			// 
			// _txt_ac_engine_shs_cycles_3
			// 
			_txt_ac_engine_shs_cycles_3.AcceptsReturn = true;
			_txt_ac_engine_shs_cycles_3.AllowDrop = true;
			_txt_ac_engine_shs_cycles_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_shs_cycles_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_shs_cycles_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_shs_cycles_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_shs_cycles_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_shs_cycles_3.Location = new System.Drawing.Point(493, 218);
			_txt_ac_engine_shs_cycles_3.MaxLength = 0;
			_txt_ac_engine_shs_cycles_3.Name = "_txt_ac_engine_shs_cycles_3";
			_txt_ac_engine_shs_cycles_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_shs_cycles_3.Size = new System.Drawing.Size(49, 19);
			_txt_ac_engine_shs_cycles_3.TabIndex = 63;
			_txt_ac_engine_shs_cycles_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_shs_cycles_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_shs_cycles_KeyDown);
			// 
			// _txt_ac_engine_shs_cycles_2
			// 
			_txt_ac_engine_shs_cycles_2.AcceptsReturn = true;
			_txt_ac_engine_shs_cycles_2.AllowDrop = true;
			_txt_ac_engine_shs_cycles_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_shs_cycles_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_shs_cycles_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_shs_cycles_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_shs_cycles_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_shs_cycles_2.Location = new System.Drawing.Point(493, 195);
			_txt_ac_engine_shs_cycles_2.MaxLength = 0;
			_txt_ac_engine_shs_cycles_2.Name = "_txt_ac_engine_shs_cycles_2";
			_txt_ac_engine_shs_cycles_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_shs_cycles_2.Size = new System.Drawing.Size(49, 19);
			_txt_ac_engine_shs_cycles_2.TabIndex = 55;
			_txt_ac_engine_shs_cycles_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_shs_cycles_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_shs_cycles_KeyDown);
			// 
			// _txt_ac_engine_shs_cycles_1
			// 
			_txt_ac_engine_shs_cycles_1.AcceptsReturn = true;
			_txt_ac_engine_shs_cycles_1.AllowDrop = true;
			_txt_ac_engine_shs_cycles_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_shs_cycles_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_shs_cycles_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_shs_cycles_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_shs_cycles_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_shs_cycles_1.Location = new System.Drawing.Point(493, 171);
			_txt_ac_engine_shs_cycles_1.MaxLength = 0;
			_txt_ac_engine_shs_cycles_1.Name = "_txt_ac_engine_shs_cycles_1";
			_txt_ac_engine_shs_cycles_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_shs_cycles_1.Size = new System.Drawing.Size(49, 19);
			_txt_ac_engine_shs_cycles_1.TabIndex = 47;
			_txt_ac_engine_shs_cycles_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_shs_cycles_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_shs_cycles_KeyDown);
			// 
			// _txt_ac_engine_shs_cycles_0
			// 
			_txt_ac_engine_shs_cycles_0.AcceptsReturn = true;
			_txt_ac_engine_shs_cycles_0.AllowDrop = true;
			_txt_ac_engine_shs_cycles_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_shs_cycles_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_shs_cycles_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_shs_cycles_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_shs_cycles_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_shs_cycles_0.Location = new System.Drawing.Point(493, 148);
			_txt_ac_engine_shs_cycles_0.MaxLength = 0;
			_txt_ac_engine_shs_cycles_0.Name = "_txt_ac_engine_shs_cycles_0";
			_txt_ac_engine_shs_cycles_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_shs_cycles_0.Size = new System.Drawing.Size(49, 19);
			_txt_ac_engine_shs_cycles_0.TabIndex = 39;
			_txt_ac_engine_shs_cycles_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_shs_cycles_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_shs_cycles_KeyDown);
			// 
			// _txt_ac_engine_tot_hrs_0
			// 
			_txt_ac_engine_tot_hrs_0.AcceptsReturn = true;
			_txt_ac_engine_tot_hrs_0.AllowDrop = true;
			_txt_ac_engine_tot_hrs_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_tot_hrs_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_tot_hrs_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_tot_hrs_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_tot_hrs_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_tot_hrs_0.Location = new System.Drawing.Point(128, 148);
			_txt_ac_engine_tot_hrs_0.MaxLength = 0;
			_txt_ac_engine_tot_hrs_0.Name = "_txt_ac_engine_tot_hrs_0";
			_txt_ac_engine_tot_hrs_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_tot_hrs_0.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_tot_hrs_0.TabIndex = 33;
			_txt_ac_engine_tot_hrs_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_tot_hrs_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_tot_hrs_KeyDown);
			// 
			// _txt_ac_engine_tot_hrs_1
			// 
			_txt_ac_engine_tot_hrs_1.AcceptsReturn = true;
			_txt_ac_engine_tot_hrs_1.AllowDrop = true;
			_txt_ac_engine_tot_hrs_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_tot_hrs_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_tot_hrs_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_tot_hrs_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_tot_hrs_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_tot_hrs_1.Location = new System.Drawing.Point(128, 171);
			_txt_ac_engine_tot_hrs_1.MaxLength = 0;
			_txt_ac_engine_tot_hrs_1.Name = "_txt_ac_engine_tot_hrs_1";
			_txt_ac_engine_tot_hrs_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_tot_hrs_1.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_tot_hrs_1.TabIndex = 41;
			_txt_ac_engine_tot_hrs_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_tot_hrs_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_tot_hrs_KeyDown);
			// 
			// _txt_ac_engine_tot_hrs_2
			// 
			_txt_ac_engine_tot_hrs_2.AcceptsReturn = true;
			_txt_ac_engine_tot_hrs_2.AllowDrop = true;
			_txt_ac_engine_tot_hrs_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_tot_hrs_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_tot_hrs_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_tot_hrs_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_tot_hrs_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_tot_hrs_2.Location = new System.Drawing.Point(128, 194);
			_txt_ac_engine_tot_hrs_2.MaxLength = 0;
			_txt_ac_engine_tot_hrs_2.Name = "_txt_ac_engine_tot_hrs_2";
			_txt_ac_engine_tot_hrs_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_tot_hrs_2.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_tot_hrs_2.TabIndex = 49;
			_txt_ac_engine_tot_hrs_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_tot_hrs_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_tot_hrs_KeyDown);
			// 
			// _txt_ac_engine_tot_hrs_3
			// 
			_txt_ac_engine_tot_hrs_3.AcceptsReturn = true;
			_txt_ac_engine_tot_hrs_3.AllowDrop = true;
			_txt_ac_engine_tot_hrs_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_tot_hrs_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_tot_hrs_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_tot_hrs_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_tot_hrs_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_tot_hrs_3.Location = new System.Drawing.Point(128, 218);
			_txt_ac_engine_tot_hrs_3.MaxLength = 0;
			_txt_ac_engine_tot_hrs_3.Name = "_txt_ac_engine_tot_hrs_3";
			_txt_ac_engine_tot_hrs_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_tot_hrs_3.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_tot_hrs_3.TabIndex = 57;
			_txt_ac_engine_tot_hrs_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_tot_hrs_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_tot_hrs_KeyDown);
			// 
			// _txt_ac_engine_soh_hrs_0
			// 
			_txt_ac_engine_soh_hrs_0.AcceptsReturn = true;
			_txt_ac_engine_soh_hrs_0.AllowDrop = true;
			_txt_ac_engine_soh_hrs_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_soh_hrs_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_soh_hrs_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_soh_hrs_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_soh_hrs_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_soh_hrs_0.Location = new System.Drawing.Point(189, 148);
			_txt_ac_engine_soh_hrs_0.MaxLength = 0;
			_txt_ac_engine_soh_hrs_0.Name = "_txt_ac_engine_soh_hrs_0";
			_txt_ac_engine_soh_hrs_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_soh_hrs_0.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_soh_hrs_0.TabIndex = 34;
			_txt_ac_engine_soh_hrs_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_soh_hrs_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_soh_hrs_KeyDown);
			// 
			// _txt_ac_engine_soh_hrs_1
			// 
			_txt_ac_engine_soh_hrs_1.AcceptsReturn = true;
			_txt_ac_engine_soh_hrs_1.AllowDrop = true;
			_txt_ac_engine_soh_hrs_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_soh_hrs_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_soh_hrs_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_soh_hrs_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_soh_hrs_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_soh_hrs_1.Location = new System.Drawing.Point(189, 171);
			_txt_ac_engine_soh_hrs_1.MaxLength = 0;
			_txt_ac_engine_soh_hrs_1.Name = "_txt_ac_engine_soh_hrs_1";
			_txt_ac_engine_soh_hrs_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_soh_hrs_1.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_soh_hrs_1.TabIndex = 42;
			_txt_ac_engine_soh_hrs_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_soh_hrs_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_soh_hrs_KeyDown);
			// 
			// _txt_ac_engine_soh_hrs_2
			// 
			_txt_ac_engine_soh_hrs_2.AcceptsReturn = true;
			_txt_ac_engine_soh_hrs_2.AllowDrop = true;
			_txt_ac_engine_soh_hrs_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_soh_hrs_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_soh_hrs_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_soh_hrs_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_soh_hrs_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_soh_hrs_2.Location = new System.Drawing.Point(189, 195);
			_txt_ac_engine_soh_hrs_2.MaxLength = 0;
			_txt_ac_engine_soh_hrs_2.Name = "_txt_ac_engine_soh_hrs_2";
			_txt_ac_engine_soh_hrs_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_soh_hrs_2.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_soh_hrs_2.TabIndex = 50;
			_txt_ac_engine_soh_hrs_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_soh_hrs_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_soh_hrs_KeyDown);
			// 
			// _txt_ac_engine_soh_hrs_3
			// 
			_txt_ac_engine_soh_hrs_3.AcceptsReturn = true;
			_txt_ac_engine_soh_hrs_3.AllowDrop = true;
			_txt_ac_engine_soh_hrs_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_soh_hrs_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_soh_hrs_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_soh_hrs_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_soh_hrs_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_soh_hrs_3.Location = new System.Drawing.Point(189, 218);
			_txt_ac_engine_soh_hrs_3.MaxLength = 0;
			_txt_ac_engine_soh_hrs_3.Name = "_txt_ac_engine_soh_hrs_3";
			_txt_ac_engine_soh_hrs_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_soh_hrs_3.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_soh_hrs_3.TabIndex = 58;
			_txt_ac_engine_soh_hrs_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_soh_hrs_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_soh_hrs_KeyDown);
			// 
			// _txt_ac_engine_shi_hrs_0
			// 
			_txt_ac_engine_shi_hrs_0.AcceptsReturn = true;
			_txt_ac_engine_shi_hrs_0.AllowDrop = true;
			_txt_ac_engine_shi_hrs_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_shi_hrs_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_shi_hrs_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_shi_hrs_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_shi_hrs_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_shi_hrs_0.Location = new System.Drawing.Point(250, 148);
			_txt_ac_engine_shi_hrs_0.MaxLength = 0;
			_txt_ac_engine_shi_hrs_0.Name = "_txt_ac_engine_shi_hrs_0";
			_txt_ac_engine_shi_hrs_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_shi_hrs_0.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_shi_hrs_0.TabIndex = 35;
			_txt_ac_engine_shi_hrs_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_shi_hrs_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_shi_hrs_KeyDown);
			// 
			// _txt_ac_engine_shi_hrs_1
			// 
			_txt_ac_engine_shi_hrs_1.AcceptsReturn = true;
			_txt_ac_engine_shi_hrs_1.AllowDrop = true;
			_txt_ac_engine_shi_hrs_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_shi_hrs_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_shi_hrs_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_shi_hrs_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_shi_hrs_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_shi_hrs_1.Location = new System.Drawing.Point(250, 171);
			_txt_ac_engine_shi_hrs_1.MaxLength = 0;
			_txt_ac_engine_shi_hrs_1.Name = "_txt_ac_engine_shi_hrs_1";
			_txt_ac_engine_shi_hrs_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_shi_hrs_1.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_shi_hrs_1.TabIndex = 43;
			_txt_ac_engine_shi_hrs_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_shi_hrs_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_shi_hrs_KeyDown);
			// 
			// _txt_ac_engine_shi_hrs_2
			// 
			_txt_ac_engine_shi_hrs_2.AcceptsReturn = true;
			_txt_ac_engine_shi_hrs_2.AllowDrop = true;
			_txt_ac_engine_shi_hrs_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_shi_hrs_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_shi_hrs_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_shi_hrs_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_shi_hrs_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_shi_hrs_2.Location = new System.Drawing.Point(250, 195);
			_txt_ac_engine_shi_hrs_2.MaxLength = 0;
			_txt_ac_engine_shi_hrs_2.Name = "_txt_ac_engine_shi_hrs_2";
			_txt_ac_engine_shi_hrs_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_shi_hrs_2.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_shi_hrs_2.TabIndex = 51;
			_txt_ac_engine_shi_hrs_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_shi_hrs_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_shi_hrs_KeyDown);
			// 
			// _txt_ac_engine_shi_hrs_3
			// 
			_txt_ac_engine_shi_hrs_3.AcceptsReturn = true;
			_txt_ac_engine_shi_hrs_3.AllowDrop = true;
			_txt_ac_engine_shi_hrs_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_shi_hrs_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_shi_hrs_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_shi_hrs_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_shi_hrs_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_shi_hrs_3.Location = new System.Drawing.Point(250, 218);
			_txt_ac_engine_shi_hrs_3.MaxLength = 0;
			_txt_ac_engine_shi_hrs_3.Name = "_txt_ac_engine_shi_hrs_3";
			_txt_ac_engine_shi_hrs_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_shi_hrs_3.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_shi_hrs_3.TabIndex = 59;
			_txt_ac_engine_shi_hrs_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_shi_hrs_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_shi_hrs_KeyDown);
			// 
			// _txt_ac_engine_tbo_hrs_0
			// 
			_txt_ac_engine_tbo_hrs_0.AcceptsReturn = true;
			_txt_ac_engine_tbo_hrs_0.AllowDrop = true;
			_txt_ac_engine_tbo_hrs_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_tbo_hrs_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_tbo_hrs_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_tbo_hrs_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_tbo_hrs_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_tbo_hrs_0.Location = new System.Drawing.Point(311, 148);
			_txt_ac_engine_tbo_hrs_0.MaxLength = 0;
			_txt_ac_engine_tbo_hrs_0.Name = "_txt_ac_engine_tbo_hrs_0";
			_txt_ac_engine_tbo_hrs_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_tbo_hrs_0.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_tbo_hrs_0.TabIndex = 36;
			_txt_ac_engine_tbo_hrs_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_tbo_hrs_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_tbo_hrs_KeyDown);
			// 
			// _txt_ac_engine_tbo_hrs_1
			// 
			_txt_ac_engine_tbo_hrs_1.AcceptsReturn = true;
			_txt_ac_engine_tbo_hrs_1.AllowDrop = true;
			_txt_ac_engine_tbo_hrs_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_tbo_hrs_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_tbo_hrs_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_tbo_hrs_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_tbo_hrs_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_tbo_hrs_1.Location = new System.Drawing.Point(311, 171);
			_txt_ac_engine_tbo_hrs_1.MaxLength = 0;
			_txt_ac_engine_tbo_hrs_1.Name = "_txt_ac_engine_tbo_hrs_1";
			_txt_ac_engine_tbo_hrs_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_tbo_hrs_1.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_tbo_hrs_1.TabIndex = 44;
			_txt_ac_engine_tbo_hrs_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_tbo_hrs_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_tbo_hrs_KeyDown);
			// 
			// _txt_ac_engine_tbo_hrs_2
			// 
			_txt_ac_engine_tbo_hrs_2.AcceptsReturn = true;
			_txt_ac_engine_tbo_hrs_2.AllowDrop = true;
			_txt_ac_engine_tbo_hrs_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_tbo_hrs_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_tbo_hrs_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_tbo_hrs_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_tbo_hrs_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_tbo_hrs_2.Location = new System.Drawing.Point(311, 195);
			_txt_ac_engine_tbo_hrs_2.MaxLength = 0;
			_txt_ac_engine_tbo_hrs_2.Name = "_txt_ac_engine_tbo_hrs_2";
			_txt_ac_engine_tbo_hrs_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_tbo_hrs_2.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_tbo_hrs_2.TabIndex = 52;
			_txt_ac_engine_tbo_hrs_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_tbo_hrs_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_tbo_hrs_KeyDown);
			// 
			// _txt_ac_engine_tbo_hrs_3
			// 
			_txt_ac_engine_tbo_hrs_3.AcceptsReturn = true;
			_txt_ac_engine_tbo_hrs_3.AllowDrop = true;
			_txt_ac_engine_tbo_hrs_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_tbo_hrs_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_tbo_hrs_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_tbo_hrs_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_tbo_hrs_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_tbo_hrs_3.Location = new System.Drawing.Point(311, 218);
			_txt_ac_engine_tbo_hrs_3.MaxLength = 0;
			_txt_ac_engine_tbo_hrs_3.Name = "_txt_ac_engine_tbo_hrs_3";
			_txt_ac_engine_tbo_hrs_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_tbo_hrs_3.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_tbo_hrs_3.TabIndex = 60;
			_txt_ac_engine_tbo_hrs_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_tbo_hrs_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_tbo_hrs_KeyDown);
			// 
			// cbo_ac_engine_name
			// 
			cbo_ac_engine_name.AllowDrop = true;
			cbo_ac_engine_name.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_engine_name.CausesValidation = true;
			cbo_ac_engine_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_engine_name.Enabled = true;
			cbo_ac_engine_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_engine_name.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_engine_name.IntegralHeight = true;
			cbo_ac_engine_name.Location = new System.Drawing.Point(155, 9);
			cbo_ac_engine_name.Name = "cbo_ac_engine_name";
			cbo_ac_engine_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_engine_name.Size = new System.Drawing.Size(201, 21);
			cbo_ac_engine_name.Sorted = false;
			cbo_ac_engine_name.TabIndex = 30;
			cbo_ac_engine_name.TabStop = true;
			cbo_ac_engine_name.Text = "cbo_ac_engine_name";
			cbo_ac_engine_name.Visible = true;
			cbo_ac_engine_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cbo_ac_engine_name_KeyPress);
			// 
			// cbo_ac_engine_maint_prog
			// 
			cbo_ac_engine_maint_prog.AllowDrop = true;
			cbo_ac_engine_maint_prog.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_engine_maint_prog.CausesValidation = true;
			cbo_ac_engine_maint_prog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_engine_maint_prog.Enabled = true;
			cbo_ac_engine_maint_prog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_engine_maint_prog.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_engine_maint_prog.IntegralHeight = true;
			cbo_ac_engine_maint_prog.Location = new System.Drawing.Point(155, 32);
			cbo_ac_engine_maint_prog.Name = "cbo_ac_engine_maint_prog";
			cbo_ac_engine_maint_prog.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_engine_maint_prog.Size = new System.Drawing.Size(321, 21);
			cbo_ac_engine_maint_prog.Sorted = false;
			cbo_ac_engine_maint_prog.TabIndex = 31;
			cbo_ac_engine_maint_prog.TabStop = true;
			cbo_ac_engine_maint_prog.Visible = true;
			cbo_ac_engine_maint_prog.TextChanged += new System.EventHandler(cbo_ac_engine_maint_prog_TextChanged);
			// 
			// _txt_ac_engine_snew_cycles_3
			// 
			_txt_ac_engine_snew_cycles_3.AcceptsReturn = true;
			_txt_ac_engine_snew_cycles_3.AllowDrop = true;
			_txt_ac_engine_snew_cycles_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_snew_cycles_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_snew_cycles_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_snew_cycles_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_snew_cycles_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_snew_cycles_3.Location = new System.Drawing.Point(371, 217);
			_txt_ac_engine_snew_cycles_3.MaxLength = 0;
			_txt_ac_engine_snew_cycles_3.Name = "_txt_ac_engine_snew_cycles_3";
			_txt_ac_engine_snew_cycles_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_snew_cycles_3.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_snew_cycles_3.TabIndex = 61;
			_txt_ac_engine_snew_cycles_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_snew_cycles_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_snew_cycles_KeyDown);
			// 
			// _txt_ac_engine_snew_cycles_2
			// 
			_txt_ac_engine_snew_cycles_2.AcceptsReturn = true;
			_txt_ac_engine_snew_cycles_2.AllowDrop = true;
			_txt_ac_engine_snew_cycles_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_snew_cycles_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_snew_cycles_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_snew_cycles_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_snew_cycles_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_snew_cycles_2.Location = new System.Drawing.Point(371, 193);
			_txt_ac_engine_snew_cycles_2.MaxLength = 0;
			_txt_ac_engine_snew_cycles_2.Name = "_txt_ac_engine_snew_cycles_2";
			_txt_ac_engine_snew_cycles_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_snew_cycles_2.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_snew_cycles_2.TabIndex = 53;
			_txt_ac_engine_snew_cycles_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_snew_cycles_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_snew_cycles_KeyDown);
			// 
			// _txt_ac_engine_snew_cycles_1
			// 
			_txt_ac_engine_snew_cycles_1.AcceptsReturn = true;
			_txt_ac_engine_snew_cycles_1.AllowDrop = true;
			_txt_ac_engine_snew_cycles_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_snew_cycles_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_snew_cycles_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_snew_cycles_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_snew_cycles_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_snew_cycles_1.Location = new System.Drawing.Point(371, 171);
			_txt_ac_engine_snew_cycles_1.MaxLength = 0;
			_txt_ac_engine_snew_cycles_1.Name = "_txt_ac_engine_snew_cycles_1";
			_txt_ac_engine_snew_cycles_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_snew_cycles_1.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_snew_cycles_1.TabIndex = 45;
			_txt_ac_engine_snew_cycles_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_snew_cycles_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_snew_cycles_KeyDown);
			// 
			// _txt_ac_engine_snew_cycles_0
			// 
			_txt_ac_engine_snew_cycles_0.AcceptsReturn = true;
			_txt_ac_engine_snew_cycles_0.AllowDrop = true;
			_txt_ac_engine_snew_cycles_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_snew_cycles_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_snew_cycles_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_snew_cycles_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_snew_cycles_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_snew_cycles_0.Location = new System.Drawing.Point(371, 148);
			_txt_ac_engine_snew_cycles_0.MaxLength = 0;
			_txt_ac_engine_snew_cycles_0.Name = "_txt_ac_engine_snew_cycles_0";
			_txt_ac_engine_snew_cycles_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_snew_cycles_0.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_snew_cycles_0.TabIndex = 37;
			_txt_ac_engine_snew_cycles_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_snew_cycles_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_snew_cycles_KeyDown);
			// 
			// _txt_ac_engine_soh_cycles_3
			// 
			_txt_ac_engine_soh_cycles_3.AcceptsReturn = true;
			_txt_ac_engine_soh_cycles_3.AllowDrop = true;
			_txt_ac_engine_soh_cycles_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_soh_cycles_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_soh_cycles_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_soh_cycles_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_soh_cycles_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_soh_cycles_3.Location = new System.Drawing.Point(432, 218);
			_txt_ac_engine_soh_cycles_3.MaxLength = 0;
			_txt_ac_engine_soh_cycles_3.Name = "_txt_ac_engine_soh_cycles_3";
			_txt_ac_engine_soh_cycles_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_soh_cycles_3.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_soh_cycles_3.TabIndex = 62;
			_txt_ac_engine_soh_cycles_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_soh_cycles_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_soh_cycles_KeyDown);
			// 
			// _txt_ac_engine_soh_cycles_2
			// 
			_txt_ac_engine_soh_cycles_2.AcceptsReturn = true;
			_txt_ac_engine_soh_cycles_2.AllowDrop = true;
			_txt_ac_engine_soh_cycles_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_soh_cycles_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_soh_cycles_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_soh_cycles_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_soh_cycles_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_soh_cycles_2.Location = new System.Drawing.Point(432, 195);
			_txt_ac_engine_soh_cycles_2.MaxLength = 0;
			_txt_ac_engine_soh_cycles_2.Name = "_txt_ac_engine_soh_cycles_2";
			_txt_ac_engine_soh_cycles_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_soh_cycles_2.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_soh_cycles_2.TabIndex = 54;
			_txt_ac_engine_soh_cycles_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_soh_cycles_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_soh_cycles_KeyDown);
			// 
			// _txt_ac_engine_soh_cycles_1
			// 
			_txt_ac_engine_soh_cycles_1.AcceptsReturn = true;
			_txt_ac_engine_soh_cycles_1.AllowDrop = true;
			_txt_ac_engine_soh_cycles_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_soh_cycles_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_soh_cycles_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_soh_cycles_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_soh_cycles_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_soh_cycles_1.Location = new System.Drawing.Point(432, 171);
			_txt_ac_engine_soh_cycles_1.MaxLength = 0;
			_txt_ac_engine_soh_cycles_1.Name = "_txt_ac_engine_soh_cycles_1";
			_txt_ac_engine_soh_cycles_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_soh_cycles_1.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_soh_cycles_1.TabIndex = 46;
			_txt_ac_engine_soh_cycles_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_soh_cycles_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_soh_cycles_KeyDown);
			// 
			// _txt_ac_engine_soh_cycles_0
			// 
			_txt_ac_engine_soh_cycles_0.AcceptsReturn = true;
			_txt_ac_engine_soh_cycles_0.AllowDrop = true;
			_txt_ac_engine_soh_cycles_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_soh_cycles_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_soh_cycles_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_soh_cycles_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_soh_cycles_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_soh_cycles_0.Location = new System.Drawing.Point(432, 148);
			_txt_ac_engine_soh_cycles_0.MaxLength = 0;
			_txt_ac_engine_soh_cycles_0.Name = "_txt_ac_engine_soh_cycles_0";
			_txt_ac_engine_soh_cycles_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_soh_cycles_0.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_soh_cycles_0.TabIndex = 38;
			_txt_ac_engine_soh_cycles_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_soh_cycles_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_soh_cycles_KeyDown);
			// 
			// txt_ac_times_as_of_date
			// 
			txt_ac_times_as_of_date.AcceptsReturn = true;
			txt_ac_times_as_of_date.AllowDrop = true;
			txt_ac_times_as_of_date.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_times_as_of_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_times_as_of_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_times_as_of_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_times_as_of_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_times_as_of_date.Location = new System.Drawing.Point(726, 4);
			txt_ac_times_as_of_date.MaxLength = 0;
			txt_ac_times_as_of_date.Name = "txt_ac_times_as_of_date";
			txt_ac_times_as_of_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_times_as_of_date.Size = new System.Drawing.Size(76, 19);
			txt_ac_times_as_of_date.TabIndex = 64;
			txt_ac_times_as_of_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_ac_airframe_tot_landings
			// 
			txt_ac_airframe_tot_landings.AcceptsReturn = true;
			txt_ac_airframe_tot_landings.AllowDrop = true;
			txt_ac_airframe_tot_landings.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_airframe_tot_landings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_airframe_tot_landings.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_airframe_tot_landings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_airframe_tot_landings.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_airframe_tot_landings.Location = new System.Drawing.Point(837, 28);
			txt_ac_airframe_tot_landings.MaxLength = 0;
			txt_ac_airframe_tot_landings.Name = "txt_ac_airframe_tot_landings";
			txt_ac_airframe_tot_landings.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_airframe_tot_landings.Size = new System.Drawing.Size(57, 19);
			txt_ac_airframe_tot_landings.TabIndex = 66;
			txt_ac_airframe_tot_landings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_ac_airframe_tot_hrs
			// 
			txt_ac_airframe_tot_hrs.AcceptsReturn = true;
			txt_ac_airframe_tot_hrs.AllowDrop = true;
			txt_ac_airframe_tot_hrs.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_airframe_tot_hrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_airframe_tot_hrs.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_airframe_tot_hrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_airframe_tot_hrs.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_airframe_tot_hrs.Location = new System.Drawing.Point(685, 28);
			txt_ac_airframe_tot_hrs.MaxLength = 0;
			txt_ac_airframe_tot_hrs.Name = "txt_ac_airframe_tot_hrs";
			txt_ac_airframe_tot_hrs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_airframe_tot_hrs.Size = new System.Drawing.Size(57, 19);
			txt_ac_airframe_tot_hrs.TabIndex = 65;
			txt_ac_airframe_tot_hrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cbo_ac_engine_management_prog_EMGP
			// 
			cbo_ac_engine_management_prog_EMGP.AllowDrop = true;
			cbo_ac_engine_management_prog_EMGP.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_engine_management_prog_EMGP.CausesValidation = true;
			cbo_ac_engine_management_prog_EMGP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_engine_management_prog_EMGP.Enabled = true;
			cbo_ac_engine_management_prog_EMGP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_engine_management_prog_EMGP.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_engine_management_prog_EMGP.IntegralHeight = true;
			cbo_ac_engine_management_prog_EMGP.Location = new System.Drawing.Point(155, 56);
			cbo_ac_engine_management_prog_EMGP.Name = "cbo_ac_engine_management_prog_EMGP";
			cbo_ac_engine_management_prog_EMGP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_engine_management_prog_EMGP.Size = new System.Drawing.Size(321, 21);
			cbo_ac_engine_management_prog_EMGP.Sorted = false;
			cbo_ac_engine_management_prog_EMGP.TabIndex = 314;
			cbo_ac_engine_management_prog_EMGP.TabStop = true;
			cbo_ac_engine_management_prog_EMGP.Visible = true;
			cbo_ac_engine_management_prog_EMGP.TextChanged += new System.EventHandler(cbo_ac_engine_management_prog_EMGP_TextChanged);
			// 
			// _cmdHelicopter_0
			// 
			_cmdHelicopter_0.AllowDrop = true;
			_cmdHelicopter_0.BackColor = System.Drawing.SystemColors.Control;
			_cmdHelicopter_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdHelicopter_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdHelicopter_0.Location = new System.Drawing.Point(52, 446);
			_cmdHelicopter_0.Name = "_cmdHelicopter_0";
			_cmdHelicopter_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdHelicopter_0.Size = new System.Drawing.Size(62, 17);
			_cmdHelicopter_0.TabIndex = 339;
			_cmdHelicopter_0.Text = "Add Row";
			_cmdHelicopter_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdHelicopter_0.UseVisualStyleBackColor = false;
			_cmdHelicopter_0.Visible = false;
			_cmdHelicopter_0.Click += new System.EventHandler(cmdHelicopter_Click);
			// 
			// _cmdHelicopter_1
			// 
			_cmdHelicopter_1.AllowDrop = true;
			_cmdHelicopter_1.BackColor = System.Drawing.SystemColors.Control;
			_cmdHelicopter_1.Enabled = false;
			_cmdHelicopter_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdHelicopter_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdHelicopter_1.Location = new System.Drawing.Point(120, 446);
			_cmdHelicopter_1.Name = "_cmdHelicopter_1";
			_cmdHelicopter_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdHelicopter_1.Size = new System.Drawing.Size(83, 17);
			_cmdHelicopter_1.TabIndex = 340;
			_cmdHelicopter_1.Text = "Delete Row";
			_cmdHelicopter_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdHelicopter_1.Visible = false;
			_cmdHelicopter_1.Click += new System.EventHandler(cmdHelicopter_Click);
			// 
			// txt_ac_engine_noise_rating
			// 
			txt_ac_engine_noise_rating.AcceptsReturn = true;
			txt_ac_engine_noise_rating.AllowDrop = true;
			txt_ac_engine_noise_rating.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_engine_noise_rating.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_engine_noise_rating.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_engine_noise_rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_engine_noise_rating.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_engine_noise_rating.Location = new System.Drawing.Point(452, 10);
			txt_ac_engine_noise_rating.MaxLength = 1;
			txt_ac_engine_noise_rating.Name = "txt_ac_engine_noise_rating";
			txt_ac_engine_noise_rating.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_engine_noise_rating.Size = new System.Drawing.Size(25, 19);
			txt_ac_engine_noise_rating.TabIndex = 348;
			txt_ac_engine_noise_rating.TabStop = false;
			txt_ac_engine_noise_rating.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_ac_engine_noise_rating_KeyPress);
			// 
			// _txt_ac_engine_ser_no_3
			// 
			_txt_ac_engine_ser_no_3.AcceptsReturn = true;
			_txt_ac_engine_ser_no_3.AllowDrop = true;
			_txt_ac_engine_ser_no_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_ser_no_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_ser_no_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_ser_no_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_ser_no_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_ser_no_3.Location = new System.Drawing.Point(51, 218);
			_txt_ac_engine_ser_no_3.MaxLength = 14;
			_txt_ac_engine_ser_no_3.Name = "_txt_ac_engine_ser_no_3";
			_txt_ac_engine_ser_no_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_ser_no_3.Size = new System.Drawing.Size(73, 19);
			_txt_ac_engine_ser_no_3.TabIndex = 56;
			_txt_ac_engine_ser_no_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_ser_no_3.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_ser_no_KeyDown);
			// 
			// _txt_ac_engine_ser_no_2
			// 
			_txt_ac_engine_ser_no_2.AcceptsReturn = true;
			_txt_ac_engine_ser_no_2.AllowDrop = true;
			_txt_ac_engine_ser_no_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_ser_no_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_ser_no_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_ser_no_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_ser_no_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_ser_no_2.Location = new System.Drawing.Point(51, 195);
			_txt_ac_engine_ser_no_2.MaxLength = 14;
			_txt_ac_engine_ser_no_2.Name = "_txt_ac_engine_ser_no_2";
			_txt_ac_engine_ser_no_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_ser_no_2.Size = new System.Drawing.Size(73, 19);
			_txt_ac_engine_ser_no_2.TabIndex = 48;
			_txt_ac_engine_ser_no_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_ser_no_2.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_ser_no_KeyDown);
			// 
			// _txt_ac_engine_ser_no_1
			// 
			_txt_ac_engine_ser_no_1.AcceptsReturn = true;
			_txt_ac_engine_ser_no_1.AllowDrop = true;
			_txt_ac_engine_ser_no_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_ser_no_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_ser_no_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_ser_no_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_ser_no_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_ser_no_1.Location = new System.Drawing.Point(51, 171);
			_txt_ac_engine_ser_no_1.MaxLength = 14;
			_txt_ac_engine_ser_no_1.Name = "_txt_ac_engine_ser_no_1";
			_txt_ac_engine_ser_no_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_ser_no_1.Size = new System.Drawing.Size(73, 19);
			_txt_ac_engine_ser_no_1.TabIndex = 40;
			_txt_ac_engine_ser_no_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_ser_no_1.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_ser_no_KeyDown);
			// 
			// _txt_ac_engine_ser_no_0
			// 
			_txt_ac_engine_ser_no_0.AcceptsReturn = true;
			_txt_ac_engine_ser_no_0.AllowDrop = true;
			_txt_ac_engine_ser_no_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_ser_no_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_ser_no_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_ser_no_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_ser_no_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_ser_no_0.Location = new System.Drawing.Point(51, 148);
			_txt_ac_engine_ser_no_0.MaxLength = 14;
			_txt_ac_engine_ser_no_0.Name = "_txt_ac_engine_ser_no_0";
			_txt_ac_engine_ser_no_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_ser_no_0.Size = new System.Drawing.Size(73, 19);
			_txt_ac_engine_ser_no_0.TabIndex = 32;
			_txt_ac_engine_ser_no_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_ac_engine_ser_no_0.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_ac_engine_ser_no_KeyDown);
			// 
			// GrdHelicopter
			// 
			GrdHelicopter.AllowBigSelection = false;
			GrdHelicopter.AllowDrop = true;
			GrdHelicopter.AllowUserToAddRows = false;
			GrdHelicopter.AllowUserToDeleteRows = false;
			GrdHelicopter.AllowUserToResizeColumns = false;
			GrdHelicopter.AllowUserToResizeColumns = GrdHelicopter.ColumnHeadersVisible;
			GrdHelicopter.AllowUserToResizeRows = false;
			GrdHelicopter.AllowUserToResizeRows = false;
			GrdHelicopter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			GrdHelicopter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			GrdHelicopter.ColumnsCount = 2;
			GrdHelicopter.FixedColumns = 0;
			GrdHelicopter.FixedRows = 1;
			GrdHelicopter.Location = new System.Drawing.Point(56, 268);
			GrdHelicopter.Name = "GrdHelicopter";
			GrdHelicopter.ReadOnly = true;
			GrdHelicopter.RowsCount = 2;
			GrdHelicopter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			GrdHelicopter.ShowCellToolTips = false;
			GrdHelicopter.Size = new System.Drawing.Size(445, 153);
			GrdHelicopter.StandardTab = true;
			GrdHelicopter.TabIndex = 338;
			GrdHelicopter.TabStop = false;
			GrdHelicopter.Visible = false;
			GrdHelicopter.Click += new System.EventHandler(GrdHelicopter_Click);
			GrdHelicopter.DoubleClick += new System.EventHandler(GrdHelicopter_DoubleClick);
			// 
			// cbo_edit_heli
			// 
			cbo_edit_heli.AllowDrop = true;
			cbo_edit_heli.BackColor = System.Drawing.Color.Yellow;
			cbo_edit_heli.CausesValidation = true;
			cbo_edit_heli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_edit_heli.Enabled = true;
			cbo_edit_heli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_edit_heli.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_edit_heli.IntegralHeight = true;
			cbo_edit_heli.Location = new System.Drawing.Point(106, 350);
			cbo_edit_heli.Name = "cbo_edit_heli";
			cbo_edit_heli.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_edit_heli.Size = new System.Drawing.Size(96, 21);
			cbo_edit_heli.Sorted = false;
			cbo_edit_heli.TabIndex = 341;
			cbo_edit_heli.TabStop = true;
			cbo_edit_heli.Visible = false;
			cbo_edit_heli.SelectedIndexChanged += new System.EventHandler(cbo_Edit_Heli_SelectedIndexChanged);
			// 
			// txt_edit_heli
			// 
			txt_edit_heli.AcceptsReturn = true;
			txt_edit_heli.AllowDrop = true;
			txt_edit_heli.BackColor = System.Drawing.Color.Yellow;
			txt_edit_heli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_edit_heli.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_edit_heli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_edit_heli.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_edit_heli.Location = new System.Drawing.Point(8, 350);
			txt_edit_heli.MaxLength = 0;
			txt_edit_heli.Name = "txt_edit_heli";
			txt_edit_heli.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_edit_heli.Size = new System.Drawing.Size(96, 21);
			txt_edit_heli.TabIndex = 342;
			txt_edit_heli.Visible = false;
			txt_edit_heli.Leave += new System.EventHandler(txt_Edit_Heli_Leave);
			// 
			// txt_ac_hidden_asking_price
			// 
			txt_ac_hidden_asking_price.AcceptsReturn = true;
			txt_ac_hidden_asking_price.AllowDrop = true;
			txt_ac_hidden_asking_price.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_hidden_asking_price.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_hidden_asking_price.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_hidden_asking_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_hidden_asking_price.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_hidden_asking_price.Location = new System.Drawing.Point(890, 3);
			txt_ac_hidden_asking_price.MaxLength = 0;
			txt_ac_hidden_asking_price.Name = "txt_ac_hidden_asking_price";
			txt_ac_hidden_asking_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_hidden_asking_price.Size = new System.Drawing.Size(98, 21);
			txt_ac_hidden_asking_price.TabIndex = 402;
			txt_ac_hidden_asking_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chk_oncondtbo
			// 
			chk_oncondtbo.AllowDrop = true;
			chk_oncondtbo.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_oncondtbo.BackColor = System.Drawing.SystemColors.Control;
			chk_oncondtbo.CausesValidation = true;
			chk_oncondtbo.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_oncondtbo.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_oncondtbo.Enabled = true;
			chk_oncondtbo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_oncondtbo.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_oncondtbo.Location = new System.Drawing.Point(430, 244);
			chk_oncondtbo.Name = "chk_oncondtbo";
			chk_oncondtbo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_oncondtbo.Size = new System.Drawing.Size(113, 17);
			chk_oncondtbo.TabIndex = 93;
			chk_oncondtbo.TabStop = true;
			chk_oncondtbo.Text = "On Condition TBO?";
			chk_oncondtbo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_oncondtbo.Visible = true;
			// 
			// _tab_aircraft_details_TabPage1
			// 
			_tab_aircraft_details_TabPage1.Controls.Add(_lbl_gen_120);
			_tab_aircraft_details_TabPage1.Controls.Add(_lbl_gen_114);
			_tab_aircraft_details_TabPage1.Controls.Add(_lbl_gen_115);
			_tab_aircraft_details_TabPage1.Controls.Add(_lbl_gen_116);
			_tab_aircraft_details_TabPage1.Controls.Add(_lbl_gen_118);
			_tab_aircraft_details_TabPage1.Controls.Add(_lbl_gen_130);
			_tab_aircraft_details_TabPage1.Controls.Add(_lbl_gen_64);
			_tab_aircraft_details_TabPage1.Controls.Add(_lbl_gen_65);
			_tab_aircraft_details_TabPage1.Controls.Add(_lbl_gen_76);
			_tab_aircraft_details_TabPage1.Controls.Add(_lbl_gen_87);
			_tab_aircraft_details_TabPage1.Controls.Add(_grd_Features_0);
			_tab_aircraft_details_TabPage1.Controls.Add(grd_aircraftdamage);
			_tab_aircraft_details_TabPage1.Controls.Add(grd_Maintenance);
			_tab_aircraft_details_TabPage1.Controls.Add(pnl_certifications);
			_tab_aircraft_details_TabPage1.Controls.Add(txt_ac_maint_eoh_mo);
			_tab_aircraft_details_TabPage1.Controls.Add(txt_ac_maint_hots_mo);
			_tab_aircraft_details_TabPage1.Controls.Add(txt_ac_maint_hots_by_name);
			_tab_aircraft_details_TabPage1.Controls.Add(txt_ac_maint_eoh_by_name);
			_tab_aircraft_details_TabPage1.Controls.Add(txt_ac_damage_history_notes);
			_tab_aircraft_details_TabPage1.Controls.Add(txt_ac_maint_eoh_year);
			_tab_aircraft_details_TabPage1.Controls.Add(txt_ac_maint_hots_year);
			_tab_aircraft_details_TabPage1.Controls.Add(cbo_ac_warranty_notes);
			_tab_aircraft_details_TabPage1.Controls.Add(cbo_ac_airframe_maintenance_prog_AMP);
			_tab_aircraft_details_TabPage1.Controls.Add(cbo_ac_airframe_maint_tracking_prog_AMTP);
			_tab_aircraft_details_TabPage1.Controls.Add(_cmdAddACDetail_6);
			_tab_aircraft_details_TabPage1.Controls.Add(grd_maint);
			_tab_aircraft_details_TabPage1.Controls.Add(_cmdAddACDetail_3);
			_tab_aircraft_details_TabPage1.Controls.Add(cbo_dam);
			_tab_aircraft_details_TabPage1.Controls.Add(_cmd_Add_Cert_1);
			_tab_aircraft_details_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage1.Text = "Maintenance";
			// 
			// _lbl_gen_120
			// 
			_lbl_gen_120.AllowDrop = true;
			_lbl_gen_120.AutoSize = true;
			_lbl_gen_120.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_120.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_120.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_120.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_120.Location = new System.Drawing.Point(320, 77);
			_lbl_gen_120.MinimumSize = new System.Drawing.Size(77, 13);
			_lbl_gen_120.Name = "_lbl_gen_120";
			_lbl_gen_120.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_120.Size = new System.Drawing.Size(77, 13);
			_lbl_gen_120.TabIndex = 236;
			_lbl_gen_120.Text = "Date:MM/YYYY";
			_lbl_gen_120.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_120.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_114
			// 
			_lbl_gen_114.AllowDrop = true;
			_lbl_gen_114.AutoSize = true;
			_lbl_gen_114.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_114.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_114.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_114.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_114.Location = new System.Drawing.Point(144, 4);
			_lbl_gen_114.MinimumSize = new System.Drawing.Size(112, 13);
			_lbl_gen_114.Name = "_lbl_gen_114";
			_lbl_gen_114.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_114.Size = new System.Drawing.Size(112, 13);
			_lbl_gen_114.TabIndex = 239;
			_lbl_gen_114.Text = "Airframe Maint Program:";
			_lbl_gen_114.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_114.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_114.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_115
			// 
			_lbl_gen_115.AllowDrop = true;
			_lbl_gen_115.AutoSize = true;
			_lbl_gen_115.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_115.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_115.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_115.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_115.Location = new System.Drawing.Point(6, 77);
			_lbl_gen_115.MinimumSize = new System.Drawing.Size(87, 13);
			_lbl_gen_115.Name = "_lbl_gen_115";
			_lbl_gen_115.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_115.Size = new System.Drawing.Size(87, 13);
			_lbl_gen_115.TabIndex = 240;
			_lbl_gen_115.Text = "Hot Inspection By:";
			_lbl_gen_115.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_115.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_116
			// 
			_lbl_gen_116.AllowDrop = true;
			_lbl_gen_116.AutoSize = true;
			_lbl_gen_116.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_116.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_116.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_116.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_116.Location = new System.Drawing.Point(6, 10);
			_lbl_gen_116.MinimumSize = new System.Drawing.Size(55, 13);
			_lbl_gen_116.Name = "_lbl_gen_116";
			_lbl_gen_116.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_116.Size = new System.Drawing.Size(55, 13);
			_lbl_gen_116.TabIndex = 244;
			_lbl_gen_116.Text = "Maintained:";
			_lbl_gen_116.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_116.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_118
			// 
			_lbl_gen_118.AllowDrop = true;
			_lbl_gen_118.AutoSize = true;
			_lbl_gen_118.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_118.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_118.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_118.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_118.Location = new System.Drawing.Point(522, 5);
			_lbl_gen_118.MinimumSize = new System.Drawing.Size(157, 13);
			_lbl_gen_118.Name = "_lbl_gen_118";
			_lbl_gen_118.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_118.Size = new System.Drawing.Size(157, 13);
			_lbl_gen_118.TabIndex = 246;
			_lbl_gen_118.Text = "Airframe Maint Tracking Program:";
			_lbl_gen_118.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_118.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_130
			// 
			_lbl_gen_130.AllowDrop = true;
			_lbl_gen_130.AutoSize = true;
			_lbl_gen_130.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_130.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_130.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_130.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_130.Location = new System.Drawing.Point(521, 342);
			_lbl_gen_130.MinimumSize = new System.Drawing.Size(78, 13);
			_lbl_gen_130.Name = "_lbl_gen_130";
			_lbl_gen_130.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_130.Size = new System.Drawing.Size(78, 13);
			_lbl_gen_130.TabIndex = 249;
			_lbl_gen_130.Text = "Damage History:";
			_lbl_gen_130.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_130.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_64
			// 
			_lbl_gen_64.AllowDrop = true;
			_lbl_gen_64.AutoSize = true;
			_lbl_gen_64.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_64.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_64.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_64.Location = new System.Drawing.Point(431, 55);
			_lbl_gen_64.MinimumSize = new System.Drawing.Size(5, 13);
			_lbl_gen_64.Name = "_lbl_gen_64";
			_lbl_gen_64.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_64.Size = new System.Drawing.Size(5, 13);
			_lbl_gen_64.TabIndex = 251;
			_lbl_gen_64.Text = "/";
			_lbl_gen_64.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_64.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_65
			// 
			_lbl_gen_65.AllowDrop = true;
			_lbl_gen_65.AutoSize = true;
			_lbl_gen_65.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_65.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_65.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_65.Location = new System.Drawing.Point(431, 77);
			_lbl_gen_65.MinimumSize = new System.Drawing.Size(5, 13);
			_lbl_gen_65.Name = "_lbl_gen_65";
			_lbl_gen_65.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_65.Size = new System.Drawing.Size(5, 13);
			_lbl_gen_65.TabIndex = 252;
			_lbl_gen_65.Text = "/";
			_lbl_gen_65.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_65.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_76
			// 
			_lbl_gen_76.AllowDrop = true;
			_lbl_gen_76.AutoSize = true;
			_lbl_gen_76.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_76.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_76.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_76.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_76.Location = new System.Drawing.Point(320, 55);
			_lbl_gen_76.MinimumSize = new System.Drawing.Size(77, 13);
			_lbl_gen_76.Name = "_lbl_gen_76";
			_lbl_gen_76.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_76.Size = new System.Drawing.Size(77, 13);
			_lbl_gen_76.TabIndex = 255;
			_lbl_gen_76.Text = "Date:MM/YYYY";
			_lbl_gen_76.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_76.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_87
			// 
			_lbl_gen_87.AllowDrop = true;
			_lbl_gen_87.AutoSize = true;
			_lbl_gen_87.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_87.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_87.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_87.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_87.Location = new System.Drawing.Point(6, 54);
			_lbl_gen_87.MinimumSize = new System.Drawing.Size(97, 13);
			_lbl_gen_87.Name = "_lbl_gen_87";
			_lbl_gen_87.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_87.Size = new System.Drawing.Size(97, 13);
			_lbl_gen_87.TabIndex = 309;
			_lbl_gen_87.Text = "Engine Overhaul By:";
			_lbl_gen_87.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_87.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _grd_Features_0
			// 
			_grd_Features_0.AllowDrop = true;
			_grd_Features_0.AllowUserToAddRows = false;
			_grd_Features_0.AllowUserToDeleteRows = false;
			_grd_Features_0.AllowUserToResizeColumns = false;
			_grd_Features_0.AllowUserToResizeColumns = _grd_Features_0.ColumnHeadersVisible;
			_grd_Features_0.AllowUserToResizeRows = false;
			_grd_Features_0.AllowUserToResizeRows = _grd_Features_0.RowHeadersVisible;
			_grd_Features_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_grd_Features_0.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			_grd_Features_0.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			_grd_Features_0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			_grd_Features_0.ColumnsCount = 2;
			_grd_Features_0.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			_grd_Features_0.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Control;
			_grd_Features_0.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			_grd_Features_0.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			_grd_Features_0.FixedColumns = 1;
			_grd_Features_0.FixedRows = 1;
			_grd_Features_0.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			_grd_Features_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_grd_Features_0.Location = new System.Drawing.Point(592, 98);
			_grd_Features_0.Name = "_grd_Features_0";
			_grd_Features_0.ReadOnly = true;
			_grd_Features_0.RowsCount = 2;
			_grd_Features_0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			_grd_Features_0.ShowCellToolTips = false;
			_grd_Features_0.Size = new System.Drawing.Size(384, 151);
			_grd_Features_0.StandardTab = true;
			_grd_Features_0.TabIndex = 432;
			_grd_Features_0.DoubleClick += new System.EventHandler(grd_Features_DoubleClick);
			// 
			// grd_aircraftdamage
			// 
			grd_aircraftdamage.AllowDrop = true;
			grd_aircraftdamage.AllowUserToAddRows = false;
			grd_aircraftdamage.AllowUserToDeleteRows = false;
			grd_aircraftdamage.AllowUserToResizeColumns = false;
			grd_aircraftdamage.AllowUserToResizeRows = false;
			grd_aircraftdamage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_aircraftdamage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_aircraftdamage.ColumnsCount = 3;
			grd_aircraftdamage.FixedColumns = 0;
			grd_aircraftdamage.FixedRows = 1;
			grd_aircraftdamage.Location = new System.Drawing.Point(520, 410);
			grd_aircraftdamage.Name = "grd_aircraftdamage";
			grd_aircraftdamage.ReadOnly = true;
			grd_aircraftdamage.RowsCount = 2;
			grd_aircraftdamage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_aircraftdamage.ShowCellToolTips = false;
			grd_aircraftdamage.Size = new System.Drawing.Size(476, 53);
			grd_aircraftdamage.StandardTab = true;
			grd_aircraftdamage.TabIndex = 414;
			grd_aircraftdamage.Visible = false;
			grd_aircraftdamage.DoubleClick += new System.EventHandler(grd_aircraftdamage_DoubleClick);
			// 
			// grd_Maintenance
			// 
			grd_Maintenance.AllowDrop = true;
			grd_Maintenance.AllowUserToAddRows = false;
			grd_Maintenance.AllowUserToDeleteRows = false;
			grd_Maintenance.AllowUserToResizeColumns = false;
			grd_Maintenance.AllowUserToResizeColumns = grd_Maintenance.ColumnHeadersVisible;
			grd_Maintenance.AllowUserToResizeRows = false;
			grd_Maintenance.AllowUserToResizeRows = grd_Maintenance.RowHeadersVisible;
			grd_Maintenance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Maintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Maintenance.ColumnsCount = 2;
			grd_Maintenance.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			grd_Maintenance.FixedColumns = 0;
			grd_Maintenance.FixedRows = 1;
			grd_Maintenance.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grd_Maintenance.Location = new System.Drawing.Point(6, 99);
			grd_Maintenance.Name = "grd_Maintenance";
			grd_Maintenance.ReadOnly = true;
			grd_Maintenance.RowsCount = 2;
			grd_Maintenance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Maintenance.ShowCellToolTips = false;
			grd_Maintenance.Size = new System.Drawing.Size(574, 145);
			grd_Maintenance.StandardTab = true;
			grd_Maintenance.TabIndex = 287;
			grd_Maintenance.DoubleClick += new System.EventHandler(grd_Maintenance_DoubleClick);
			// 
			// pnl_certifications
			// 
			pnl_certifications.AllowDrop = true;
			pnl_certifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_certifications.Controls.Add(cbo_accert_name);
			pnl_certifications.Controls.Add(_cmd_Add_Cert_2);
			pnl_certifications.Controls.Add(_cmd_Add_Cert_0);
			pnl_certifications.Controls.Add(grd_Aircraft_Certified);
			pnl_certifications.Controls.Add(_lbl_gen_101);
			pnl_certifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_certifications.Location = new System.Drawing.Point(528, 252);
			pnl_certifications.Name = "pnl_certifications";
			pnl_certifications.Size = new System.Drawing.Size(432, 79);
			pnl_certifications.TabIndex = 235;
			// 
			// cbo_accert_name
			// 
			cbo_accert_name.AllowDrop = true;
			cbo_accert_name.BackColor = System.Drawing.SystemColors.Window;
			cbo_accert_name.CausesValidation = true;
			cbo_accert_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_accert_name.Enabled = true;
			cbo_accert_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_accert_name.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_accert_name.IntegralHeight = true;
			cbo_accert_name.Location = new System.Drawing.Point(290, 19);
			cbo_accert_name.Name = "cbo_accert_name";
			cbo_accert_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_accert_name.Size = new System.Drawing.Size(129, 21);
			cbo_accert_name.Sorted = false;
			cbo_accert_name.TabIndex = 381;
			cbo_accert_name.TabStop = true;
			cbo_accert_name.Visible = true;
			cbo_accert_name.SelectionChangeCommitted += new System.EventHandler(cbo_accert_name_SelectionChangeCommitted);
			// 
			// _cmd_Add_Cert_2
			// 
			_cmd_Add_Cert_2.AllowDrop = true;
			_cmd_Add_Cert_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_Add_Cert_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_Add_Cert_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_Add_Cert_2.Location = new System.Drawing.Point(356, 48);
			_cmd_Add_Cert_2.Name = "_cmd_Add_Cert_2";
			_cmd_Add_Cert_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_Add_Cert_2.Size = new System.Drawing.Size(63, 25);
			_cmd_Add_Cert_2.TabIndex = 380;
			_cmd_Add_Cert_2.Tag = "cmd_Delete_Cert";
			_cmd_Add_Cert_2.Text = "&Remove";
			_cmd_Add_Cert_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_Add_Cert_2.UseVisualStyleBackColor = false;
			_cmd_Add_Cert_2.Click += new System.EventHandler(cmd_Add_Cert_Click);
			// 
			// _cmd_Add_Cert_0
			// 
			_cmd_Add_Cert_0.AllowDrop = true;
			_cmd_Add_Cert_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_Add_Cert_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_Add_Cert_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_Add_Cert_0.Location = new System.Drawing.Point(288, 48);
			_cmd_Add_Cert_0.Name = "_cmd_Add_Cert_0";
			_cmd_Add_Cert_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_Add_Cert_0.Size = new System.Drawing.Size(63, 25);
			_cmd_Add_Cert_0.TabIndex = 248;
			_cmd_Add_Cert_0.Tag = "cmd_Add_Cert";
			_cmd_Add_Cert_0.Text = "&Add";
			_cmd_Add_Cert_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_Add_Cert_0.UseVisualStyleBackColor = false;
			_cmd_Add_Cert_0.Click += new System.EventHandler(cmd_Add_Cert_Click);
			// 
			// grd_Aircraft_Certified
			// 
			grd_Aircraft_Certified.AllowDrop = true;
			grd_Aircraft_Certified.AllowUserToAddRows = false;
			grd_Aircraft_Certified.AllowUserToDeleteRows = false;
			grd_Aircraft_Certified.AllowUserToResizeColumns = false;
			grd_Aircraft_Certified.AllowUserToResizeRows = false;
			grd_Aircraft_Certified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Aircraft_Certified.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Aircraft_Certified.ColumnsCount = 1;
			grd_Aircraft_Certified.FixedColumns = 0;
			grd_Aircraft_Certified.FixedRows = 1;
			grd_Aircraft_Certified.Location = new System.Drawing.Point(6, 18);
			grd_Aircraft_Certified.Name = "grd_Aircraft_Certified";
			grd_Aircraft_Certified.ReadOnly = true;
			grd_Aircraft_Certified.RowsCount = 2;
			grd_Aircraft_Certified.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Aircraft_Certified.ShowCellToolTips = false;
			grd_Aircraft_Certified.Size = new System.Drawing.Size(248, 56);
			grd_Aircraft_Certified.StandardTab = true;
			grd_Aircraft_Certified.TabIndex = 247;
			grd_Aircraft_Certified.Click += new System.EventHandler(grd_Aircraft_Certified_Click);
			// 
			// _lbl_gen_101
			// 
			_lbl_gen_101.AllowDrop = true;
			_lbl_gen_101.AutoSize = true;
			_lbl_gen_101.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_101.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_101.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_101.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_101.Location = new System.Drawing.Point(288, 2);
			_lbl_gen_101.MinimumSize = new System.Drawing.Size(82, 13);
			_lbl_gen_101.Name = "_lbl_gen_101";
			_lbl_gen_101.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_101.Size = new System.Drawing.Size(82, 13);
			_lbl_gen_101.TabIndex = 382;
			_lbl_gen_101.Text = "Certifications List:";
			_lbl_gen_101.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_101.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// txt_ac_maint_eoh_mo
			// 
			txt_ac_maint_eoh_mo.AcceptsReturn = true;
			txt_ac_maint_eoh_mo.AllowDrop = true;
			txt_ac_maint_eoh_mo.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_maint_eoh_mo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_maint_eoh_mo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_maint_eoh_mo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_maint_eoh_mo.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_maint_eoh_mo.Location = new System.Drawing.Point(400, 52);
			txt_ac_maint_eoh_mo.MaxLength = 2;
			txt_ac_maint_eoh_mo.Name = "txt_ac_maint_eoh_mo";
			txt_ac_maint_eoh_mo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_maint_eoh_mo.Size = new System.Drawing.Size(28, 19);
			txt_ac_maint_eoh_mo.TabIndex = 238;
			txt_ac_maint_eoh_mo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_ac_maint_hots_mo
			// 
			txt_ac_maint_hots_mo.AcceptsReturn = true;
			txt_ac_maint_hots_mo.AllowDrop = true;
			txt_ac_maint_hots_mo.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_maint_hots_mo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_maint_hots_mo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_maint_hots_mo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_maint_hots_mo.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_maint_hots_mo.Location = new System.Drawing.Point(401, 74);
			txt_ac_maint_hots_mo.MaxLength = 2;
			txt_ac_maint_hots_mo.Name = "txt_ac_maint_hots_mo";
			txt_ac_maint_hots_mo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_maint_hots_mo.Size = new System.Drawing.Size(28, 19);
			txt_ac_maint_hots_mo.TabIndex = 243;
			txt_ac_maint_hots_mo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_ac_maint_hots_by_name
			// 
			txt_ac_maint_hots_by_name.AcceptsReturn = true;
			txt_ac_maint_hots_by_name.AllowDrop = true;
			txt_ac_maint_hots_by_name.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_maint_hots_by_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_maint_hots_by_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_maint_hots_by_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_maint_hots_by_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_maint_hots_by_name.Location = new System.Drawing.Point(107, 74);
			txt_ac_maint_hots_by_name.MaxLength = 50;
			txt_ac_maint_hots_by_name.Name = "txt_ac_maint_hots_by_name";
			txt_ac_maint_hots_by_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_maint_hots_by_name.Size = new System.Drawing.Size(208, 19);
			txt_ac_maint_hots_by_name.TabIndex = 242;
			// 
			// txt_ac_maint_eoh_by_name
			// 
			txt_ac_maint_eoh_by_name.AcceptsReturn = true;
			txt_ac_maint_eoh_by_name.AllowDrop = true;
			txt_ac_maint_eoh_by_name.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_maint_eoh_by_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_maint_eoh_by_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_maint_eoh_by_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_maint_eoh_by_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_maint_eoh_by_name.Location = new System.Drawing.Point(106, 52);
			txt_ac_maint_eoh_by_name.MaxLength = 50;
			txt_ac_maint_eoh_by_name.Name = "txt_ac_maint_eoh_by_name";
			txt_ac_maint_eoh_by_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_maint_eoh_by_name.Size = new System.Drawing.Size(208, 19);
			txt_ac_maint_eoh_by_name.TabIndex = 237;
			// 
			// txt_ac_damage_history_notes
			// 
			txt_ac_damage_history_notes.AcceptsReturn = true;
			txt_ac_damage_history_notes.AllowDrop = true;
			txt_ac_damage_history_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_damage_history_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_damage_history_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_damage_history_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_damage_history_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_damage_history_notes.Location = new System.Drawing.Point(528, 359);
			txt_ac_damage_history_notes.MaxLength = 1000;
			txt_ac_damage_history_notes.Multiline = true;
			txt_ac_damage_history_notes.Name = "txt_ac_damage_history_notes";
			txt_ac_damage_history_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_damage_history_notes.Size = new System.Drawing.Size(467, 50);
			txt_ac_damage_history_notes.TabIndex = 250;
			// 
			// txt_ac_maint_eoh_year
			// 
			txt_ac_maint_eoh_year.AcceptsReturn = true;
			txt_ac_maint_eoh_year.AllowDrop = true;
			txt_ac_maint_eoh_year.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_maint_eoh_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_maint_eoh_year.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_maint_eoh_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_maint_eoh_year.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_maint_eoh_year.Location = new System.Drawing.Point(439, 52);
			txt_ac_maint_eoh_year.MaxLength = 4;
			txt_ac_maint_eoh_year.Name = "txt_ac_maint_eoh_year";
			txt_ac_maint_eoh_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_maint_eoh_year.Size = new System.Drawing.Size(40, 19);
			txt_ac_maint_eoh_year.TabIndex = 241;
			// 
			// txt_ac_maint_hots_year
			// 
			txt_ac_maint_hots_year.AcceptsReturn = true;
			txt_ac_maint_hots_year.AllowDrop = true;
			txt_ac_maint_hots_year.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_maint_hots_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_maint_hots_year.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_maint_hots_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_maint_hots_year.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_maint_hots_year.Location = new System.Drawing.Point(439, 74);
			txt_ac_maint_hots_year.MaxLength = 4;
			txt_ac_maint_hots_year.Name = "txt_ac_maint_hots_year";
			txt_ac_maint_hots_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_maint_hots_year.Size = new System.Drawing.Size(40, 19);
			txt_ac_maint_hots_year.TabIndex = 245;
			// 
			// cbo_ac_warranty_notes
			// 
			cbo_ac_warranty_notes.AllowDrop = true;
			cbo_ac_warranty_notes.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_warranty_notes.CausesValidation = true;
			cbo_ac_warranty_notes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_warranty_notes.Enabled = true;
			cbo_ac_warranty_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_warranty_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_warranty_notes.IntegralHeight = true;
			cbo_ac_warranty_notes.Location = new System.Drawing.Point(6, 24);
			cbo_ac_warranty_notes.Name = "cbo_ac_warranty_notes";
			cbo_ac_warranty_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_warranty_notes.Size = new System.Drawing.Size(129, 21);
			cbo_ac_warranty_notes.Sorted = false;
			cbo_ac_warranty_notes.TabIndex = 271;
			cbo_ac_warranty_notes.TabStop = true;
			cbo_ac_warranty_notes.Visible = true;
			// 
			// cbo_ac_airframe_maintenance_prog_AMP
			// 
			cbo_ac_airframe_maintenance_prog_AMP.AllowDrop = true;
			cbo_ac_airframe_maintenance_prog_AMP.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_airframe_maintenance_prog_AMP.CausesValidation = true;
			cbo_ac_airframe_maintenance_prog_AMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_airframe_maintenance_prog_AMP.Enabled = true;
			cbo_ac_airframe_maintenance_prog_AMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_airframe_maintenance_prog_AMP.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_airframe_maintenance_prog_AMP.IntegralHeight = true;
			cbo_ac_airframe_maintenance_prog_AMP.Location = new System.Drawing.Point(138, 23);
			cbo_ac_airframe_maintenance_prog_AMP.Name = "cbo_ac_airframe_maintenance_prog_AMP";
			cbo_ac_airframe_maintenance_prog_AMP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_airframe_maintenance_prog_AMP.Size = new System.Drawing.Size(378, 21);
			cbo_ac_airframe_maintenance_prog_AMP.Sorted = false;
			cbo_ac_airframe_maintenance_prog_AMP.TabIndex = 315;
			cbo_ac_airframe_maintenance_prog_AMP.TabStop = true;
			cbo_ac_airframe_maintenance_prog_AMP.Visible = true;
			cbo_ac_airframe_maintenance_prog_AMP.TextChanged += new System.EventHandler(cbo_ac_airframe_maintenance_prog_AMP_TextChanged);
			// 
			// cbo_ac_airframe_maint_tracking_prog_AMTP
			// 
			cbo_ac_airframe_maint_tracking_prog_AMTP.AllowDrop = true;
			cbo_ac_airframe_maint_tracking_prog_AMTP.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_airframe_maint_tracking_prog_AMTP.CausesValidation = true;
			cbo_ac_airframe_maint_tracking_prog_AMTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_airframe_maint_tracking_prog_AMTP.Enabled = true;
			cbo_ac_airframe_maint_tracking_prog_AMTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_airframe_maint_tracking_prog_AMTP.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_airframe_maint_tracking_prog_AMTP.IntegralHeight = true;
			cbo_ac_airframe_maint_tracking_prog_AMTP.Location = new System.Drawing.Point(517, 21);
			cbo_ac_airframe_maint_tracking_prog_AMTP.Name = "cbo_ac_airframe_maint_tracking_prog_AMTP";
			cbo_ac_airframe_maint_tracking_prog_AMTP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_airframe_maint_tracking_prog_AMTP.Size = new System.Drawing.Size(477, 21);
			cbo_ac_airframe_maint_tracking_prog_AMTP.Sorted = false;
			cbo_ac_airframe_maint_tracking_prog_AMTP.TabIndex = 316;
			cbo_ac_airframe_maint_tracking_prog_AMTP.TabStop = true;
			cbo_ac_airframe_maint_tracking_prog_AMTP.Visible = true;
			cbo_ac_airframe_maint_tracking_prog_AMTP.TextChanged += new System.EventHandler(cbo_ac_airframe_maint_tracking_prog_AMTP_TextChanged);
			// 
			// _cmdAddACDetail_6
			// 
			_cmdAddACDetail_6.AllowDrop = true;
			_cmdAddACDetail_6.BackColor = System.Drawing.SystemColors.Control;
			_cmdAddACDetail_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAddACDetail_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAddACDetail_6.Location = new System.Drawing.Point(372, 252);
			_cmdAddACDetail_6.Name = "_cmdAddACDetail_6";
			_cmdAddACDetail_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAddACDetail_6.Size = new System.Drawing.Size(142, 25);
			_cmdAddACDetail_6.TabIndex = 413;
			_cmdAddACDetail_6.Text = "Edit Maintenance Details";
			_cmdAddACDetail_6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAddACDetail_6.UseVisualStyleBackColor = false;
			_cmdAddACDetail_6.Click += new System.EventHandler(cmdAddACDetail_Click);
			// 
			// grd_maint
			// 
			grd_maint.AllowDrop = true;
			grd_maint.AllowUserToAddRows = false;
			grd_maint.AllowUserToDeleteRows = false;
			grd_maint.AllowUserToResizeColumns = false;
			grd_maint.AllowUserToResizeRows = false;
			grd_maint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_maint.ColumnsCount = 2;
			grd_maint.FixedColumns = 1;
			grd_maint.FixedRows = 1;
			grd_maint.Location = new System.Drawing.Point(4, 278);
			grd_maint.Name = "grd_maint";
			grd_maint.ReadOnly = true;
			grd_maint.RowsCount = 2;
			grd_maint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_maint.ShowCellToolTips = false;
			grd_maint.Size = new System.Drawing.Size(503, 185);
			grd_maint.StandardTab = true;
			grd_maint.TabIndex = 415;
			grd_maint.DoubleClick += new System.EventHandler(grd_maint_DoubleClick);
			// 
			// _cmdAddACDetail_3
			// 
			_cmdAddACDetail_3.AllowDrop = true;
			_cmdAddACDetail_3.BackColor = System.Drawing.SystemColors.Control;
			_cmdAddACDetail_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAddACDetail_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAddACDetail_3.Location = new System.Drawing.Point(4, 250);
			_cmdAddACDetail_3.Name = "_cmdAddACDetail_3";
			_cmdAddACDetail_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAddACDetail_3.Size = new System.Drawing.Size(124, 25);
			_cmdAddACDetail_3.TabIndex = 288;
			_cmdAddACDetail_3.Text = "Add Maintenance Detail";
			_cmdAddACDetail_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAddACDetail_3.UseVisualStyleBackColor = false;
			_cmdAddACDetail_3.Click += new System.EventHandler(cmdAddACDetail_Click);
			// 
			// cbo_dam
			// 
			cbo_dam.AllowDrop = true;
			cbo_dam.BackColor = System.Drawing.SystemColors.Window;
			cbo_dam.CausesValidation = true;
			cbo_dam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_dam.Enabled = true;
			cbo_dam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_dam.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_dam.IntegralHeight = true;
			cbo_dam.Location = new System.Drawing.Point(600, 336);
			cbo_dam.Name = "cbo_dam";
			cbo_dam.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_dam.Size = new System.Drawing.Size(85, 21);
			cbo_dam.Sorted = false;
			cbo_dam.TabIndex = 440;
			cbo_dam.TabStop = true;
			cbo_dam.Visible = true;
			cbo_dam.SelectionChangeCommitted += new System.EventHandler(cbo_dam_SelectionChangeCommitted);
			// 
			// _cmd_Add_Cert_1
			// 
			_cmd_Add_Cert_1.AllowDrop = true;
			_cmd_Add_Cert_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_Add_Cert_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_Add_Cert_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_Add_Cert_1.Location = new System.Drawing.Point(872, 332);
			_cmd_Add_Cert_1.Name = "_cmd_Add_Cert_1";
			_cmd_Add_Cert_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_Add_Cert_1.Size = new System.Drawing.Size(103, 25);
			_cmd_Add_Cert_1.TabIndex = 445;
			_cmd_Add_Cert_1.Tag = "cmd_Delete_Cert";
			_cmd_Add_Cert_1.Text = "Add Damage Note";
			_cmd_Add_Cert_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_Add_Cert_1.UseVisualStyleBackColor = false;
			_cmd_Add_Cert_1.Click += new System.EventHandler(cmd_Add_Cert_Click);
			// 
			// _tab_aircraft_details_TabPage2
			// 
			_tab_aircraft_details_TabPage2.Controls.Add(_lbl_gen_27);
			_tab_aircraft_details_TabPage2.Controls.Add(_lbl_gen_53);
			_tab_aircraft_details_TabPage2.Controls.Add(_lbl_gen_49);
			_tab_aircraft_details_TabPage2.Controls.Add(_lbl_gen_46);
			_tab_aircraft_details_TabPage2.Controls.Add(_lbl_gen_234);
			_tab_aircraft_details_TabPage2.Controls.Add(_lbl_gen_200);
			_tab_aircraft_details_TabPage2.Controls.Add(_lbl_gen_236);
			_tab_aircraft_details_TabPage2.Controls.Add(_lbl_gen_78);
			_tab_aircraft_details_TabPage2.Controls.Add(_lbl_gen_79);
			_tab_aircraft_details_TabPage2.Controls.Add(_grd_Features_1);
			_tab_aircraft_details_TabPage2.Controls.Add(grd_Exterior);
			_tab_aircraft_details_TabPage2.Controls.Add(txt_ac_exterior_rating);
			_tab_aircraft_details_TabPage2.Controls.Add(txt_ac_interior_rating);
			_tab_aircraft_details_TabPage2.Controls.Add(cbo_ac_interior_config_name);
			_tab_aircraft_details_TabPage2.Controls.Add(txt_ac_passenger_count);
			_tab_aircraft_details_TabPage2.Controls.Add(txt_ac_interior_mo);
			_tab_aircraft_details_TabPage2.Controls.Add(txt_ac_exterior_mo);
			_tab_aircraft_details_TabPage2.Controls.Add(txt_ac_interior_doneby_name);
			_tab_aircraft_details_TabPage2.Controls.Add(txt_ac_exterior_doneby_name);
			_tab_aircraft_details_TabPage2.Controls.Add(txt_ac_exterior_year);
			_tab_aircraft_details_TabPage2.Controls.Add(txt_ac_interior_year);
			_tab_aircraft_details_TabPage2.Controls.Add(grd_Interior);
			_tab_aircraft_details_TabPage2.Controls.Add(_cmdAddACDetail_0);
			_tab_aircraft_details_TabPage2.Controls.Add(_cmdAddACDetail_1);
			_tab_aircraft_details_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage2.Text = "Int/Ext";
			// 
			// _lbl_gen_27
			// 
			_lbl_gen_27.AllowDrop = true;
			_lbl_gen_27.AutoSize = true;
			_lbl_gen_27.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_27.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_27.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_27.Location = new System.Drawing.Point(405, 8);
			_lbl_gen_27.MinimumSize = new System.Drawing.Size(100, 13);
			_lbl_gen_27.Name = "_lbl_gen_27";
			_lbl_gen_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_27.Size = new System.Drawing.Size(100, 13);
			_lbl_gen_27.TabIndex = 190;
			_lbl_gen_27.Text = "Interior Configuration:";
			_lbl_gen_27.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_27.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_53
			// 
			_lbl_gen_53.AllowDrop = true;
			_lbl_gen_53.AutoSize = true;
			_lbl_gen_53.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_53.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_53.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_53.Location = new System.Drawing.Point(56, 8);
			_lbl_gen_53.MinimumSize = new System.Drawing.Size(34, 13);
			_lbl_gen_53.Name = "_lbl_gen_53";
			_lbl_gen_53.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_53.Size = new System.Drawing.Size(34, 13);
			_lbl_gen_53.TabIndex = 191;
			_lbl_gen_53.Text = "Rating:";
			_lbl_gen_53.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_53.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_49
			// 
			_lbl_gen_49.AllowDrop = true;
			_lbl_gen_49.AutoSize = true;
			_lbl_gen_49.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_49.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_49.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_49.Location = new System.Drawing.Point(523, 8);
			_lbl_gen_49.MinimumSize = new System.Drawing.Size(30, 13);
			_lbl_gen_49.Name = "_lbl_gen_49";
			_lbl_gen_49.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_49.Size = new System.Drawing.Size(30, 13);
			_lbl_gen_49.TabIndex = 192;
			_lbl_gen_49.Text = "Seats:";
			_lbl_gen_49.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_49.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_46
			// 
			_lbl_gen_46.AllowDrop = true;
			_lbl_gen_46.AutoSize = true;
			_lbl_gen_46.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_46.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_46.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_46.Location = new System.Drawing.Point(113, 8);
			_lbl_gen_46.MinimumSize = new System.Drawing.Size(63, 13);
			_lbl_gen_46.Name = "_lbl_gen_46";
			_lbl_gen_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_46.Size = new System.Drawing.Size(63, 13);
			_lbl_gen_46.TabIndex = 193;
			_lbl_gen_46.Text = "(MM / YYYY)";
			_lbl_gen_46.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_46.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_234
			// 
			_lbl_gen_234.AllowDrop = true;
			_lbl_gen_234.AutoSize = true;
			_lbl_gen_234.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_234.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_234.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_234.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_234.Location = new System.Drawing.Point(191, 8);
			_lbl_gen_234.MinimumSize = new System.Drawing.Size(44, 13);
			_lbl_gen_234.Name = "_lbl_gen_234";
			_lbl_gen_234.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_234.Size = new System.Drawing.Size(44, 13);
			_lbl_gen_234.TabIndex = 194;
			_lbl_gen_234.Text = "Done By:";
			_lbl_gen_234.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_234.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_200
			// 
			_lbl_gen_200.AllowDrop = true;
			_lbl_gen_200.AutoSize = true;
			_lbl_gen_200.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_200.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_200.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_200.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_200.Location = new System.Drawing.Point(12, 28);
			_lbl_gen_200.MinimumSize = new System.Drawing.Size(35, 13);
			_lbl_gen_200.Name = "_lbl_gen_200";
			_lbl_gen_200.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_200.Size = new System.Drawing.Size(35, 13);
			_lbl_gen_200.TabIndex = 195;
			_lbl_gen_200.Text = "Interior:";
			_lbl_gen_200.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_200.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_236
			// 
			_lbl_gen_236.AllowDrop = true;
			_lbl_gen_236.AutoSize = true;
			_lbl_gen_236.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_236.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_236.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_236.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_236.Location = new System.Drawing.Point(9, 52);
			_lbl_gen_236.MinimumSize = new System.Drawing.Size(38, 13);
			_lbl_gen_236.Name = "_lbl_gen_236";
			_lbl_gen_236.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_236.Size = new System.Drawing.Size(38, 13);
			_lbl_gen_236.TabIndex = 196;
			_lbl_gen_236.Text = "Exterior:";
			_lbl_gen_236.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_236.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_78
			// 
			_lbl_gen_78.AllowDrop = true;
			_lbl_gen_78.AutoSize = true;
			_lbl_gen_78.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_78.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_78.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_78.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_78.Location = new System.Drawing.Point(136, 28);
			_lbl_gen_78.MinimumSize = new System.Drawing.Size(5, 13);
			_lbl_gen_78.Name = "_lbl_gen_78";
			_lbl_gen_78.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_78.Size = new System.Drawing.Size(5, 13);
			_lbl_gen_78.TabIndex = 272;
			_lbl_gen_78.Text = "/";
			_lbl_gen_78.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_78.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_79
			// 
			_lbl_gen_79.AllowDrop = true;
			_lbl_gen_79.AutoSize = true;
			_lbl_gen_79.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_79.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_79.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_79.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_79.Location = new System.Drawing.Point(136, 52);
			_lbl_gen_79.MinimumSize = new System.Drawing.Size(5, 13);
			_lbl_gen_79.Name = "_lbl_gen_79";
			_lbl_gen_79.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_79.Size = new System.Drawing.Size(5, 13);
			_lbl_gen_79.TabIndex = 273;
			_lbl_gen_79.Text = "/";
			_lbl_gen_79.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_79.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _grd_Features_1
			// 
			_grd_Features_1.AllowDrop = true;
			_grd_Features_1.AllowUserToAddRows = false;
			_grd_Features_1.AllowUserToDeleteRows = false;
			_grd_Features_1.AllowUserToResizeColumns = false;
			_grd_Features_1.AllowUserToResizeColumns = _grd_Features_1.ColumnHeadersVisible;
			_grd_Features_1.AllowUserToResizeRows = false;
			_grd_Features_1.AllowUserToResizeRows = _grd_Features_1.RowHeadersVisible;
			_grd_Features_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_grd_Features_1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			_grd_Features_1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			_grd_Features_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			_grd_Features_1.ColumnsCount = 2;
			_grd_Features_1.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			_grd_Features_1.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Control;
			_grd_Features_1.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			_grd_Features_1.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			_grd_Features_1.FixedColumns = 1;
			_grd_Features_1.FixedRows = 1;
			_grd_Features_1.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			_grd_Features_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_grd_Features_1.Location = new System.Drawing.Point(590, 74);
			_grd_Features_1.Name = "_grd_Features_1";
			_grd_Features_1.ReadOnly = true;
			_grd_Features_1.RowsCount = 2;
			_grd_Features_1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			_grd_Features_1.ShowCellToolTips = false;
			_grd_Features_1.Size = new System.Drawing.Size(398, 381);
			_grd_Features_1.StandardTab = true;
			_grd_Features_1.TabIndex = 433;
			_grd_Features_1.DoubleClick += new System.EventHandler(grd_Features_DoubleClick);
			// 
			// grd_Exterior
			// 
			grd_Exterior.AllowDrop = true;
			grd_Exterior.AllowUserToAddRows = false;
			grd_Exterior.AllowUserToDeleteRows = false;
			grd_Exterior.AllowUserToResizeColumns = false;
			grd_Exterior.AllowUserToResizeColumns = grd_Exterior.ColumnHeadersVisible;
			grd_Exterior.AllowUserToResizeRows = false;
			grd_Exterior.AllowUserToResizeRows = grd_Exterior.RowHeadersVisible;
			grd_Exterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Exterior.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Exterior.ColumnsCount = 2;
			grd_Exterior.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			grd_Exterior.FixedColumns = 1;
			grd_Exterior.FixedRows = 1;
			grd_Exterior.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grd_Exterior.Location = new System.Drawing.Point(10, 366);
			grd_Exterior.Name = "grd_Exterior";
			grd_Exterior.ReadOnly = true;
			grd_Exterior.RowsCount = 2;
			grd_Exterior.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Exterior.ShowCellToolTips = false;
			grd_Exterior.Size = new System.Drawing.Size(568, 91);
			grd_Exterior.StandardTab = true;
			grd_Exterior.TabIndex = 282;
			grd_Exterior.DoubleClick += new System.EventHandler(grd_Exterior_DoubleClick);
			// 
			// txt_ac_exterior_rating
			// 
			txt_ac_exterior_rating.AcceptsReturn = true;
			txt_ac_exterior_rating.AllowDrop = true;
			txt_ac_exterior_rating.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_exterior_rating.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_exterior_rating.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_exterior_rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_exterior_rating.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_exterior_rating.Location = new System.Drawing.Point(52, 48);
			txt_ac_exterior_rating.MaxLength = 2;
			txt_ac_exterior_rating.Name = "txt_ac_exterior_rating";
			txt_ac_exterior_rating.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_exterior_rating.Size = new System.Drawing.Size(41, 21);
			txt_ac_exterior_rating.TabIndex = 184;
			// 
			// txt_ac_interior_rating
			// 
			txt_ac_interior_rating.AcceptsReturn = true;
			txt_ac_interior_rating.AllowDrop = true;
			txt_ac_interior_rating.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_interior_rating.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_interior_rating.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_interior_rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_interior_rating.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_interior_rating.Location = new System.Drawing.Point(52, 24);
			txt_ac_interior_rating.MaxLength = 2;
			txt_ac_interior_rating.Name = "txt_ac_interior_rating";
			txt_ac_interior_rating.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_interior_rating.Size = new System.Drawing.Size(41, 21);
			txt_ac_interior_rating.TabIndex = 180;
			// 
			// cbo_ac_interior_config_name
			// 
			cbo_ac_interior_config_name.AllowDrop = true;
			cbo_ac_interior_config_name.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_interior_config_name.CausesValidation = true;
			cbo_ac_interior_config_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_interior_config_name.Enabled = true;
			cbo_ac_interior_config_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_interior_config_name.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_interior_config_name.IntegralHeight = true;
			cbo_ac_interior_config_name.Location = new System.Drawing.Point(402, 24);
			cbo_ac_interior_config_name.Name = "cbo_ac_interior_config_name";
			cbo_ac_interior_config_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_interior_config_name.Size = new System.Drawing.Size(113, 21);
			cbo_ac_interior_config_name.Sorted = false;
			cbo_ac_interior_config_name.TabIndex = 189;
			cbo_ac_interior_config_name.TabStop = true;
			cbo_ac_interior_config_name.Text = "cbo_ac_interior_config_name";
			cbo_ac_interior_config_name.Visible = true;
			// 
			// txt_ac_passenger_count
			// 
			txt_ac_passenger_count.AcceptsReturn = true;
			txt_ac_passenger_count.AllowDrop = true;
			txt_ac_passenger_count.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_passenger_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_passenger_count.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_passenger_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_passenger_count.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_passenger_count.Location = new System.Drawing.Point(522, 24);
			txt_ac_passenger_count.MaxLength = 3;
			txt_ac_passenger_count.Name = "txt_ac_passenger_count";
			txt_ac_passenger_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_passenger_count.Size = new System.Drawing.Size(33, 21);
			txt_ac_passenger_count.TabIndex = 188;
			// 
			// txt_ac_interior_mo
			// 
			txt_ac_interior_mo.AcceptsReturn = true;
			txt_ac_interior_mo.AllowDrop = true;
			txt_ac_interior_mo.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_interior_mo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_interior_mo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_interior_mo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_interior_mo.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_interior_mo.Location = new System.Drawing.Point(102, 24);
			txt_ac_interior_mo.MaxLength = 2;
			txt_ac_interior_mo.Name = "txt_ac_interior_mo";
			txt_ac_interior_mo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_interior_mo.Size = new System.Drawing.Size(32, 21);
			txt_ac_interior_mo.TabIndex = 181;
			// 
			// txt_ac_exterior_mo
			// 
			txt_ac_exterior_mo.AcceptsReturn = true;
			txt_ac_exterior_mo.AllowDrop = true;
			txt_ac_exterior_mo.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_exterior_mo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_exterior_mo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_exterior_mo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_exterior_mo.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_exterior_mo.Location = new System.Drawing.Point(102, 48);
			txt_ac_exterior_mo.MaxLength = 2;
			txt_ac_exterior_mo.Name = "txt_ac_exterior_mo";
			txt_ac_exterior_mo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_exterior_mo.Size = new System.Drawing.Size(32, 21);
			txt_ac_exterior_mo.TabIndex = 185;
			// 
			// txt_ac_interior_doneby_name
			// 
			txt_ac_interior_doneby_name.AcceptsReturn = true;
			txt_ac_interior_doneby_name.AllowDrop = true;
			txt_ac_interior_doneby_name.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_interior_doneby_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_interior_doneby_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_interior_doneby_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_interior_doneby_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_interior_doneby_name.Location = new System.Drawing.Point(190, 24);
			txt_ac_interior_doneby_name.MaxLength = 50;
			txt_ac_interior_doneby_name.Name = "txt_ac_interior_doneby_name";
			txt_ac_interior_doneby_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_interior_doneby_name.Size = new System.Drawing.Size(209, 21);
			txt_ac_interior_doneby_name.TabIndex = 183;
			// 
			// txt_ac_exterior_doneby_name
			// 
			txt_ac_exterior_doneby_name.AcceptsReturn = true;
			txt_ac_exterior_doneby_name.AllowDrop = true;
			txt_ac_exterior_doneby_name.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_exterior_doneby_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_exterior_doneby_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_exterior_doneby_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_exterior_doneby_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_exterior_doneby_name.Location = new System.Drawing.Point(190, 48);
			txt_ac_exterior_doneby_name.MaxLength = 50;
			txt_ac_exterior_doneby_name.Name = "txt_ac_exterior_doneby_name";
			txt_ac_exterior_doneby_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_exterior_doneby_name.Size = new System.Drawing.Size(209, 21);
			txt_ac_exterior_doneby_name.TabIndex = 187;
			// 
			// txt_ac_exterior_year
			// 
			txt_ac_exterior_year.AcceptsReturn = true;
			txt_ac_exterior_year.AllowDrop = true;
			txt_ac_exterior_year.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_exterior_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_exterior_year.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_exterior_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_exterior_year.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_exterior_year.Location = new System.Drawing.Point(144, 48);
			txt_ac_exterior_year.MaxLength = 4;
			txt_ac_exterior_year.Name = "txt_ac_exterior_year";
			txt_ac_exterior_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_exterior_year.Size = new System.Drawing.Size(41, 21);
			txt_ac_exterior_year.TabIndex = 186;
			// 
			// txt_ac_interior_year
			// 
			txt_ac_interior_year.AcceptsReturn = true;
			txt_ac_interior_year.AllowDrop = true;
			txt_ac_interior_year.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_interior_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_interior_year.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_interior_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_interior_year.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_interior_year.Location = new System.Drawing.Point(144, 24);
			txt_ac_interior_year.MaxLength = 4;
			txt_ac_interior_year.Name = "txt_ac_interior_year";
			txt_ac_interior_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_interior_year.Size = new System.Drawing.Size(41, 21);
			txt_ac_interior_year.TabIndex = 182;
			// 
			// grd_Interior
			// 
			grd_Interior.AllowDrop = true;
			grd_Interior.AllowUserToAddRows = false;
			grd_Interior.AllowUserToDeleteRows = false;
			grd_Interior.AllowUserToResizeColumns = false;
			grd_Interior.AllowUserToResizeColumns = grd_Interior.ColumnHeadersVisible;
			grd_Interior.AllowUserToResizeRows = false;
			grd_Interior.AllowUserToResizeRows = grd_Interior.RowHeadersVisible;
			grd_Interior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Interior.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Interior.ColumnsCount = 2;
			grd_Interior.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			grd_Interior.FixedColumns = 1;
			grd_Interior.FixedRows = 1;
			grd_Interior.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grd_Interior.Location = new System.Drawing.Point(12, 92);
			grd_Interior.Name = "grd_Interior";
			grd_Interior.ReadOnly = true;
			grd_Interior.RowsCount = 2;
			grd_Interior.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Interior.ShowCellToolTips = false;
			grd_Interior.Size = new System.Drawing.Size(566, 246);
			grd_Interior.StandardTab = true;
			grd_Interior.TabIndex = 281;
			grd_Interior.DoubleClick += new System.EventHandler(grd_Interior_DoubleClick);
			// 
			// _cmdAddACDetail_0
			// 
			_cmdAddACDetail_0.AllowDrop = true;
			_cmdAddACDetail_0.BackColor = System.Drawing.SystemColors.Control;
			_cmdAddACDetail_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAddACDetail_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAddACDetail_0.Location = new System.Drawing.Point(446, 66);
			_cmdAddACDetail_0.Name = "_cmdAddACDetail_0";
			_cmdAddACDetail_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAddACDetail_0.Size = new System.Drawing.Size(132, 22);
			_cmdAddACDetail_0.TabIndex = 283;
			_cmdAddACDetail_0.Tag = "cmdAddACDetail";
			_cmdAddACDetail_0.Text = "Add Interior Detail";
			_cmdAddACDetail_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAddACDetail_0.UseVisualStyleBackColor = false;
			_cmdAddACDetail_0.Click += new System.EventHandler(cmdAddACDetail_Click);
			// 
			// _cmdAddACDetail_1
			// 
			_cmdAddACDetail_1.AllowDrop = true;
			_cmdAddACDetail_1.BackColor = System.Drawing.SystemColors.Control;
			_cmdAddACDetail_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAddACDetail_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAddACDetail_1.Location = new System.Drawing.Point(446, 342);
			_cmdAddACDetail_1.Name = "_cmdAddACDetail_1";
			_cmdAddACDetail_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAddACDetail_1.Size = new System.Drawing.Size(132, 22);
			_cmdAddACDetail_1.TabIndex = 284;
			_cmdAddACDetail_1.Tag = "cmdAddACDetail";
			_cmdAddACDetail_1.Text = "Add Exterior Detail";
			_cmdAddACDetail_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAddACDetail_1.UseVisualStyleBackColor = false;
			_cmdAddACDetail_1.Click += new System.EventHandler(cmdAddACDetail_Click);
			// 
			// _tab_aircraft_details_TabPage3
			// 
			_tab_aircraft_details_TabPage3.Controls.Add(_lbl_gen_52);
			_tab_aircraft_details_TabPage3.Controls.Add(_lbl_gen_32);
			_tab_aircraft_details_TabPage3.Controls.Add(_grd_Features_2);
			_tab_aircraft_details_TabPage3.Controls.Add(grd_Equipment);
			_tab_aircraft_details_TabPage3.Controls.Add(_cmdAddACDetail_2);
			_tab_aircraft_details_TabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage3.Text = "Equip";
			// 
			// _lbl_gen_52
			// 
			_lbl_gen_52.AllowDrop = true;
			_lbl_gen_52.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_52.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_52.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_52.Location = new System.Drawing.Point(460, 4);
			_lbl_gen_52.MinimumSize = new System.Drawing.Size(201, 17);
			_lbl_gen_52.Name = "_lbl_gen_52";
			_lbl_gen_52.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_52.Size = new System.Drawing.Size(201, 17);
			_lbl_gen_52.TabIndex = 112;
			_lbl_gen_52.Text = "Equipment Description:";
			_lbl_gen_52.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_52.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_32
			// 
			_lbl_gen_32.AllowDrop = true;
			_lbl_gen_32.AutoSize = true;
			_lbl_gen_32.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_32.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_32.Location = new System.Drawing.Point(19, 37);
			_lbl_gen_32.MinimumSize = new System.Drawing.Size(85, 13);
			_lbl_gen_32.Name = "_lbl_gen_32";
			_lbl_gen_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_32.Size = new System.Drawing.Size(85, 13);
			_lbl_gen_32.TabIndex = 254;
			_lbl_gen_32.Text = "Equipment Details";
			_lbl_gen_32.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_32.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _grd_Features_2
			// 
			_grd_Features_2.AllowDrop = true;
			_grd_Features_2.AllowUserToAddRows = false;
			_grd_Features_2.AllowUserToDeleteRows = false;
			_grd_Features_2.AllowUserToResizeColumns = false;
			_grd_Features_2.AllowUserToResizeColumns = _grd_Features_2.ColumnHeadersVisible;
			_grd_Features_2.AllowUserToResizeRows = false;
			_grd_Features_2.AllowUserToResizeRows = _grd_Features_2.RowHeadersVisible;
			_grd_Features_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_grd_Features_2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			_grd_Features_2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			_grd_Features_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			_grd_Features_2.ColumnsCount = 2;
			_grd_Features_2.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			_grd_Features_2.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Control;
			_grd_Features_2.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			_grd_Features_2.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			_grd_Features_2.FixedColumns = 1;
			_grd_Features_2.FixedRows = 1;
			_grd_Features_2.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			_grd_Features_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_grd_Features_2.Location = new System.Drawing.Point(568, 52);
			_grd_Features_2.Name = "_grd_Features_2";
			_grd_Features_2.ReadOnly = true;
			_grd_Features_2.RowsCount = 2;
			_grd_Features_2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			_grd_Features_2.ShowCellToolTips = false;
			_grd_Features_2.Size = new System.Drawing.Size(428, 409);
			_grd_Features_2.StandardTab = true;
			_grd_Features_2.TabIndex = 434;
			_grd_Features_2.DoubleClick += new System.EventHandler(grd_Features_DoubleClick);
			// 
			// grd_Equipment
			// 
			grd_Equipment.AllowDrop = true;
			grd_Equipment.AllowUserToAddRows = false;
			grd_Equipment.AllowUserToDeleteRows = false;
			grd_Equipment.AllowUserToResizeColumns = false;
			grd_Equipment.AllowUserToResizeColumns = grd_Equipment.ColumnHeadersVisible;
			grd_Equipment.AllowUserToResizeRows = false;
			grd_Equipment.AllowUserToResizeRows = grd_Equipment.RowHeadersVisible;
			grd_Equipment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Equipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Equipment.ColumnsCount = 2;
			grd_Equipment.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			grd_Equipment.FixedColumns = 1;
			grd_Equipment.FixedRows = 1;
			grd_Equipment.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grd_Equipment.Location = new System.Drawing.Point(19, 52);
			grd_Equipment.Name = "grd_Equipment";
			grd_Equipment.ReadOnly = true;
			grd_Equipment.RowsCount = 2;
			grd_Equipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Equipment.ShowCellToolTips = false;
			grd_Equipment.Size = new System.Drawing.Size(538, 406);
			grd_Equipment.StandardTab = true;
			grd_Equipment.TabIndex = 286;
			grd_Equipment.DoubleClick += new System.EventHandler(grd_Equipment_DoubleClick);
			// 
			// _cmdAddACDetail_2
			// 
			_cmdAddACDetail_2.AllowDrop = true;
			_cmdAddACDetail_2.BackColor = System.Drawing.SystemColors.Control;
			_cmdAddACDetail_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAddACDetail_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAddACDetail_2.Location = new System.Drawing.Point(430, 30);
			_cmdAddACDetail_2.Name = "_cmdAddACDetail_2";
			_cmdAddACDetail_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAddACDetail_2.Size = new System.Drawing.Size(126, 22);
			_cmdAddACDetail_2.TabIndex = 285;
			_cmdAddACDetail_2.Text = "Add Equipment Detail";
			_cmdAddACDetail_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAddACDetail_2.UseVisualStyleBackColor = false;
			_cmdAddACDetail_2.Click += new System.EventHandler(cmdAddACDetail_Click);
			// 
			// _tab_aircraft_details_TabPage4
			// 
			_tab_aircraft_details_TabPage4.Controls.Add(pnl_Cockpit);
			_tab_aircraft_details_TabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage4.Text = "Cockpit";
			// 
			// pnl_Cockpit
			// 
			pnl_Cockpit.AllowDrop = true;
			pnl_Cockpit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Cockpit.Controls.Add(_cmdAddACDetail_4);
			pnl_Cockpit.Controls.Add(_cmd_Av_Add_0);
			pnl_Cockpit.Controls.Add(pnl_Av);
			pnl_Cockpit.Controls.Add(grd_AircraftAvionics);
			pnl_Cockpit.Controls.Add(grd_Cockpit);
			pnl_Cockpit.Controls.Add(_grd_Features_3);
			pnl_Cockpit.Controls.Add(_lbl_gen_48);
			pnl_Cockpit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Cockpit.Location = new System.Drawing.Point(6, 4);
			pnl_Cockpit.Name = "pnl_Cockpit";
			pnl_Cockpit.Size = new System.Drawing.Size(985, 457);
			pnl_Cockpit.TabIndex = 110;
			// 
			// _cmdAddACDetail_4
			// 
			_cmdAddACDetail_4.AllowDrop = true;
			_cmdAddACDetail_4.BackColor = System.Drawing.SystemColors.Control;
			_cmdAddACDetail_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAddACDetail_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAddACDetail_4.Location = new System.Drawing.Point(822, 348);
			_cmdAddACDetail_4.Name = "_cmdAddACDetail_4";
			_cmdAddACDetail_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAddACDetail_4.Size = new System.Drawing.Size(132, 22);
			_cmdAddACDetail_4.TabIndex = 289;
			_cmdAddACDetail_4.Text = "Add Cockpit Detail";
			_cmdAddACDetail_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAddACDetail_4.UseVisualStyleBackColor = false;
			_cmdAddACDetail_4.Click += new System.EventHandler(cmdAddACDetail_Click);
			// 
			// _cmd_Av_Add_0
			// 
			_cmd_Av_Add_0.AllowDrop = true;
			_cmd_Av_Add_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_Av_Add_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_Av_Add_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_Av_Add_0.Location = new System.Drawing.Point(312, 346);
			_cmd_Av_Add_0.Name = "_cmd_Av_Add_0";
			_cmd_Av_Add_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_Av_Add_0.Size = new System.Drawing.Size(97, 21);
			_cmd_Av_Add_0.TabIndex = 123;
			_cmd_Av_Add_0.Tag = "cmd_Av_Add";
			_cmd_Av_Add_0.Text = "&Add to Avionics";
			_cmd_Av_Add_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_Av_Add_0.UseVisualStyleBackColor = false;
			_cmd_Av_Add_0.Click += new System.EventHandler(cmd_Av_Add_Click);
			// 
			// pnl_Av
			// 
			pnl_Av.AllowDrop = true;
			pnl_Av.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Av.Controls.Add(lst_Avionics);
			pnl_Av.Controls.Add(_cmd_Av_Add_2);
			pnl_Av.Controls.Add(_cmd_Av_Add_3);
			pnl_Av.Controls.Add(_cmd_Av_Add_1);
			pnl_Av.Controls.Add(cbo_av_description);
			pnl_Av.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Av.Location = new System.Drawing.Point(520, 248);
			pnl_Av.Name = "pnl_Av";
			pnl_Av.Size = new System.Drawing.Size(455, 95);
			pnl_Av.TabIndex = 122;
			pnl_Av.Visible = false;
			// 
			// lst_Avionics
			// 
			lst_Avionics.AllowDrop = true;
			lst_Avionics.BackColor = System.Drawing.SystemColors.Window;
			lst_Avionics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Avionics.CausesValidation = true;
			lst_Avionics.Enabled = true;
			lst_Avionics.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Avionics.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Avionics.IntegralHeight = true;
			lst_Avionics.Location = new System.Drawing.Point(4, 4);
			lst_Avionics.MultiColumn = false;
			lst_Avionics.Name = "lst_Avionics";
			lst_Avionics.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Avionics.Size = new System.Drawing.Size(445, 50);
			lst_Avionics.Sorted = false;
			lst_Avionics.TabIndex = 130;
			lst_Avionics.TabStop = true;
			lst_Avionics.Visible = true;
			lst_Avionics.SelectedIndexChanged += new System.EventHandler(lst_Avionics_SelectedIndexChanged);
			// 
			// _cmd_Av_Add_2
			// 
			_cmd_Av_Add_2.AllowDrop = true;
			_cmd_Av_Add_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_Av_Add_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_Av_Add_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_Av_Add_2.Location = new System.Drawing.Point(88, 76);
			_cmd_Av_Add_2.Name = "_cmd_Av_Add_2";
			_cmd_Av_Add_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_Av_Add_2.Size = new System.Drawing.Size(107, 17);
			_cmd_Av_Add_2.TabIndex = 134;
			_cmd_Av_Add_2.Tag = "cmd_Av_Delete";
			_cmd_Av_Add_2.Text = "&Remove From List ";
			_cmd_Av_Add_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_Av_Add_2.UseVisualStyleBackColor = false;
			_cmd_Av_Add_2.Click += new System.EventHandler(cmd_Av_Add_Click);
			// 
			// _cmd_Av_Add_3
			// 
			_cmd_Av_Add_3.AllowDrop = true;
			_cmd_Av_Add_3.BackColor = System.Drawing.SystemColors.Control;
			_cmd_Av_Add_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_Av_Add_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_Av_Add_3.Location = new System.Drawing.Point(202, 76);
			_cmd_Av_Add_3.Name = "_cmd_Av_Add_3";
			_cmd_Av_Add_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_Av_Add_3.Size = new System.Drawing.Size(69, 17);
			_cmd_Av_Add_3.TabIndex = 136;
			_cmd_Av_Add_3.Tag = "cmd_Av_Cancel";
			_cmd_Av_Add_3.Text = "&Cancel";
			_cmd_Av_Add_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_Av_Add_3.UseVisualStyleBackColor = false;
			_cmd_Av_Add_3.Visible = false;
			_cmd_Av_Add_3.Click += new System.EventHandler(cmd_Av_Add_Click);
			// 
			// _cmd_Av_Add_1
			// 
			_cmd_Av_Add_1.AllowDrop = true;
			_cmd_Av_Add_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_Av_Add_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_Av_Add_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_Av_Add_1.Location = new System.Drawing.Point(0, 76);
			_cmd_Av_Add_1.Name = "_cmd_Av_Add_1";
			_cmd_Av_Add_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_Av_Add_1.Size = new System.Drawing.Size(77, 17);
			_cmd_Av_Add_1.TabIndex = 132;
			_cmd_Av_Add_1.Tag = "cmd_Av_Save";
			_cmd_Av_Add_1.Text = "&Update List";
			_cmd_Av_Add_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_Av_Add_1.UseVisualStyleBackColor = false;
			_cmd_Av_Add_1.Visible = false;
			_cmd_Av_Add_1.Click += new System.EventHandler(cmd_Av_Add_Click);
			// 
			// cbo_av_description
			// 
			cbo_av_description.AllowDrop = true;
			cbo_av_description.BackColor = System.Drawing.SystemColors.Window;
			cbo_av_description.CausesValidation = true;
			cbo_av_description.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_av_description.Enabled = true;
			cbo_av_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_av_description.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_av_description.IntegralHeight = true;
			cbo_av_description.Location = new System.Drawing.Point(2, 53);
			cbo_av_description.Name = "cbo_av_description";
			cbo_av_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_av_description.Size = new System.Drawing.Size(407, 21);
			cbo_av_description.Sorted = false;
			cbo_av_description.TabIndex = 131;
			cbo_av_description.TabStop = true;
			cbo_av_description.Visible = true;
			cbo_av_description.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cbo_av_description_KeyPress);
			cbo_av_description.Leave += new System.EventHandler(cbo_av_description_Leave);
			// 
			// grd_AircraftAvionics
			// 
			grd_AircraftAvionics.AllowDrop = true;
			grd_AircraftAvionics.AllowUserToAddRows = false;
			grd_AircraftAvionics.AllowUserToDeleteRows = false;
			grd_AircraftAvionics.AllowUserToResizeColumns = false;
			grd_AircraftAvionics.AllowUserToResizeRows = false;
			grd_AircraftAvionics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_AircraftAvionics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_AircraftAvionics.ColumnsCount = 2;
			grd_AircraftAvionics.FixedColumns = 1;
			grd_AircraftAvionics.FixedRows = 1;
			grd_AircraftAvionics.Location = new System.Drawing.Point(0, 0);
			grd_AircraftAvionics.Name = "grd_AircraftAvionics";
			grd_AircraftAvionics.ReadOnly = true;
			grd_AircraftAvionics.RowsCount = 2;
			grd_AircraftAvionics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_AircraftAvionics.ShowCellToolTips = false;
			grd_AircraftAvionics.Size = new System.Drawing.Size(509, 343);
			grd_AircraftAvionics.StandardTab = true;
			grd_AircraftAvionics.TabIndex = 121;
			grd_AircraftAvionics.Click += new System.EventHandler(grd_AircraftAvionics_Click);
			// 
			// grd_Cockpit
			// 
			grd_Cockpit.AllowDrop = true;
			grd_Cockpit.AllowUserToAddRows = false;
			grd_Cockpit.AllowUserToDeleteRows = false;
			grd_Cockpit.AllowUserToResizeColumns = false;
			grd_Cockpit.AllowUserToResizeColumns = grd_Cockpit.ColumnHeadersVisible;
			grd_Cockpit.AllowUserToResizeRows = false;
			grd_Cockpit.AllowUserToResizeRows = grd_Cockpit.RowHeadersVisible;
			grd_Cockpit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Cockpit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Cockpit.ColumnsCount = 2;
			grd_Cockpit.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			grd_Cockpit.FixedColumns = 1;
			grd_Cockpit.FixedRows = 1;
			grd_Cockpit.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grd_Cockpit.Location = new System.Drawing.Point(2, 372);
			grd_Cockpit.Name = "grd_Cockpit";
			grd_Cockpit.ReadOnly = true;
			grd_Cockpit.RowsCount = 2;
			grd_Cockpit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Cockpit.ShowCellToolTips = false;
			grd_Cockpit.Size = new System.Drawing.Size(954, 83);
			grd_Cockpit.StandardTab = true;
			grd_Cockpit.TabIndex = 290;
			grd_Cockpit.DoubleClick += new System.EventHandler(grd_Cockpit_DoubleClick);
			// 
			// _grd_Features_3
			// 
			_grd_Features_3.AllowDrop = true;
			_grd_Features_3.AllowUserToAddRows = false;
			_grd_Features_3.AllowUserToDeleteRows = false;
			_grd_Features_3.AllowUserToResizeColumns = false;
			_grd_Features_3.AllowUserToResizeColumns = _grd_Features_3.ColumnHeadersVisible;
			_grd_Features_3.AllowUserToResizeRows = false;
			_grd_Features_3.AllowUserToResizeRows = _grd_Features_3.RowHeadersVisible;
			_grd_Features_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_grd_Features_3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			_grd_Features_3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			_grd_Features_3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			_grd_Features_3.ColumnsCount = 2;
			_grd_Features_3.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			_grd_Features_3.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Control;
			_grd_Features_3.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			_grd_Features_3.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			_grd_Features_3.FixedColumns = 1;
			_grd_Features_3.FixedRows = 1;
			_grd_Features_3.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			_grd_Features_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_grd_Features_3.Location = new System.Drawing.Point(520, 0);
			_grd_Features_3.Name = "_grd_Features_3";
			_grd_Features_3.ReadOnly = true;
			_grd_Features_3.RowsCount = 2;
			_grd_Features_3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			_grd_Features_3.ShowCellToolTips = false;
			_grd_Features_3.Size = new System.Drawing.Size(456, 341);
			_grd_Features_3.StandardTab = true;
			_grd_Features_3.TabIndex = 435;
			_grd_Features_3.DoubleClick += new System.EventHandler(grd_Features_DoubleClick);
			// 
			// _lbl_gen_48
			// 
			_lbl_gen_48.AllowDrop = true;
			_lbl_gen_48.AutoSize = true;
			_lbl_gen_48.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_48.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_48.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_48.Location = new System.Drawing.Point(528, 144);
			_lbl_gen_48.MinimumSize = new System.Drawing.Size(441, 93);
			_lbl_gen_48.Name = "_lbl_gen_48";
			_lbl_gen_48.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_48.Size = new System.Drawing.Size(441, 93);
			_lbl_gen_48.TabIndex = 443;
			_lbl_gen_48.Text = "...";
			_lbl_gen_48.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_48.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _tab_aircraft_details_TabPage5
			// 
			_tab_aircraft_details_TabPage5.Controls.Add(chk_verified);
			_tab_aircraft_details_TabPage5.Controls.Add(_cmdAddACDetail_10);
			_tab_aircraft_details_TabPage5.Controls.Add(cbo_company_research_contact);
			_tab_aircraft_details_TabPage5.Controls.Add(_cmdAddACDetail_8);
			_tab_aircraft_details_TabPage5.Controls.Add(cbo_change_rel);
			_tab_aircraft_details_TabPage5.Controls.Add(_cmdAddACDetail_7);
			_tab_aircraft_details_TabPage5.Controls.Add(_pnl_gen_1);
			_tab_aircraft_details_TabPage5.Controls.Add(chkShowAllContactInfo);
			_tab_aircraft_details_TabPage5.Controls.Add(_cmdAddACDetail_5);
			_tab_aircraft_details_TabPage5.Controls.Add(lst_Company);
			_tab_aircraft_details_TabPage5.Controls.Add(lst_Contact);
			_tab_aircraft_details_TabPage5.Controls.Add(_pnl_gen_4);
			_tab_aircraft_details_TabPage5.Controls.Add(pnl_LeaseEntry);
			_tab_aircraft_details_TabPage5.Controls.Add(pnl_LeaseList);
			_tab_aircraft_details_TabPage5.Controls.Add(_lbl_gen_55);
			_tab_aircraft_details_TabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage5.Text = "Company";
			// 
			// chk_verified
			// 
			chk_verified.AllowDrop = true;
			chk_verified.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_verified.BackColor = System.Drawing.SystemColors.Control;
			chk_verified.CausesValidation = true;
			chk_verified.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_verified.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_verified.Enabled = true;
			chk_verified.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_verified.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_verified.Location = new System.Drawing.Point(504, 158);
			chk_verified.Name = "chk_verified";
			chk_verified.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_verified.Size = new System.Drawing.Size(81, 13);
			chk_verified.TabIndex = 444;
			chk_verified.TabStop = true;
			chk_verified.Text = "UnVerified";
			chk_verified.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_verified.Visible = true;
			// 
			// _cmdAddACDetail_10
			// 
			_cmdAddACDetail_10.AllowDrop = true;
			_cmdAddACDetail_10.BackColor = System.Drawing.SystemColors.Control;
			_cmdAddACDetail_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAddACDetail_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAddACDetail_10.Location = new System.Drawing.Point(800, 158);
			_cmdAddACDetail_10.Name = "_cmdAddACDetail_10";
			_cmdAddACDetail_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAddACDetail_10.Size = new System.Drawing.Size(99, 21);
			_cmdAddACDetail_10.TabIndex = 442;
			_cmdAddACDetail_10.Text = "Confirm";
			_cmdAddACDetail_10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAddACDetail_10.UseVisualStyleBackColor = false;
			_cmdAddACDetail_10.Visible = false;
			_cmdAddACDetail_10.Click += new System.EventHandler(cmdAddACDetail_Click);
			// 
			// cbo_company_research_contact
			// 
			cbo_company_research_contact.AllowDrop = true;
			cbo_company_research_contact.BackColor = System.Drawing.SystemColors.Window;
			cbo_company_research_contact.CausesValidation = true;
			cbo_company_research_contact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_company_research_contact.Enabled = true;
			cbo_company_research_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_company_research_contact.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_company_research_contact.IntegralHeight = true;
			cbo_company_research_contact.Location = new System.Drawing.Point(796, 310);
			cbo_company_research_contact.Name = "cbo_company_research_contact";
			cbo_company_research_contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_company_research_contact.Size = new System.Drawing.Size(185, 21);
			cbo_company_research_contact.Sorted = false;
			cbo_company_research_contact.TabIndex = 428;
			cbo_company_research_contact.TabStop = true;
			cbo_company_research_contact.Visible = false;
			// 
			// _cmdAddACDetail_8
			// 
			_cmdAddACDetail_8.AllowDrop = true;
			_cmdAddACDetail_8.BackColor = System.Drawing.SystemColors.Control;
			_cmdAddACDetail_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAddACDetail_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAddACDetail_8.Location = new System.Drawing.Point(898, 158);
			_cmdAddACDetail_8.Name = "_cmdAddACDetail_8";
			_cmdAddACDetail_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAddACDetail_8.Size = new System.Drawing.Size(99, 21);
			_cmdAddACDetail_8.TabIndex = 426;
			_cmdAddACDetail_8.Text = "Verify";
			_cmdAddACDetail_8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAddACDetail_8.UseVisualStyleBackColor = false;
			_cmdAddACDetail_8.Visible = false;
			_cmdAddACDetail_8.Click += new System.EventHandler(cmdAddACDetail_Click);
			// 
			// cbo_change_rel
			// 
			cbo_change_rel.AllowDrop = true;
			cbo_change_rel.BackColor = System.Drawing.SystemColors.Window;
			cbo_change_rel.CausesValidation = true;
			cbo_change_rel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_change_rel.Enabled = true;
			cbo_change_rel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_change_rel.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_change_rel.IntegralHeight = true;
			cbo_change_rel.Location = new System.Drawing.Point(554, 310);
			cbo_change_rel.Name = "cbo_change_rel";
			cbo_change_rel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_change_rel.Size = new System.Drawing.Size(225, 21);
			cbo_change_rel.Sorted = false;
			cbo_change_rel.TabIndex = 425;
			cbo_change_rel.TabStop = true;
			cbo_change_rel.Visible = false;
			// 
			// _cmdAddACDetail_7
			// 
			_cmdAddACDetail_7.AllowDrop = true;
			_cmdAddACDetail_7.BackColor = System.Drawing.SystemColors.Control;
			_cmdAddACDetail_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAddACDetail_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAddACDetail_7.Location = new System.Drawing.Point(392, 312);
			_cmdAddACDetail_7.Name = "_cmdAddACDetail_7";
			_cmdAddACDetail_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAddACDetail_7.Size = new System.Drawing.Size(141, 21);
			_cmdAddACDetail_7.TabIndex = 424;
			_cmdAddACDetail_7.Text = "Change Relationship";
			_cmdAddACDetail_7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAddACDetail_7.UseVisualStyleBackColor = false;
			_cmdAddACDetail_7.Click += new System.EventHandler(cmdAddACDetail_Click);
			// 
			// _pnl_gen_1
			// 
			_pnl_gen_1.AllowDrop = true;
			_pnl_gen_1.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			_pnl_gen_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_pnl_gen_1.Controls.Add(cmd_Primary);
			_pnl_gen_1.Controls.Add(cmd_Confirm_Company);
			_pnl_gen_1.Controls.Add(cmd_AssociateCompany);
			_pnl_gen_1.Controls.Add(cmd_Remove_Association);
			_pnl_gen_1.Controls.Add(cmd_Set_As_Exclusive);
			_pnl_gen_1.Controls.Add(cmd_Clear_Exclusive_Confirmation_Company);
			_pnl_gen_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pnl_gen_1.Location = new System.Drawing.Point(8, 159);
			_pnl_gen_1.Name = "_pnl_gen_1";
			_pnl_gen_1.Size = new System.Drawing.Size(204, 169);
			_pnl_gen_1.TabIndex = 358;
			_pnl_gen_1.Click += new System.EventHandler(pnl_gen_Click);
			_pnl_gen_1.DoubleClick += new System.EventHandler(pnl_gen_DoubleClick);
			// 
			// cmd_Primary
			// 
			cmd_Primary.AllowDrop = true;
			cmd_Primary.BackColor = System.Drawing.SystemColors.Control;
			cmd_Primary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Primary.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Primary.Location = new System.Drawing.Point(6, 4);
			cmd_Primary.Name = "cmd_Primary";
			cmd_Primary.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Primary.Size = new System.Drawing.Size(197, 25);
			cmd_Primary.TabIndex = 364;
			cmd_Primary.Text = "Set Company/Contact as Primary";
			cmd_Primary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Primary.UseVisualStyleBackColor = false;
			cmd_Primary.Click += new System.EventHandler(cmd_Primary_Click);
			// 
			// cmd_Confirm_Company
			// 
			cmd_Confirm_Company.AllowDrop = true;
			cmd_Confirm_Company.BackColor = System.Drawing.SystemColors.Control;
			cmd_Confirm_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Confirm_Company.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Confirm_Company.Location = new System.Drawing.Point(2, 86);
			cmd_Confirm_Company.Name = "cmd_Confirm_Company";
			cmd_Confirm_Company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Confirm_Company.Size = new System.Drawing.Size(197, 25);
			cmd_Confirm_Company.TabIndex = 363;
			cmd_Confirm_Company.Text = "Confirm Company";
			cmd_Confirm_Company.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Confirm_Company.UseVisualStyleBackColor = false;
			cmd_Confirm_Company.Visible = false;
			cmd_Confirm_Company.Click += new System.EventHandler(cmd_Confirm_Company_Click);
			// 
			// cmd_AssociateCompany
			// 
			cmd_AssociateCompany.AllowDrop = true;
			cmd_AssociateCompany.BackColor = System.Drawing.SystemColors.Control;
			cmd_AssociateCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_AssociateCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_AssociateCompany.Location = new System.Drawing.Point(3, 140);
			cmd_AssociateCompany.Name = "cmd_AssociateCompany";
			cmd_AssociateCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_AssociateCompany.Size = new System.Drawing.Size(197, 25);
			cmd_AssociateCompany.TabIndex = 362;
			cmd_AssociateCompany.Text = "Add Company/Contact Association";
			cmd_AssociateCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_AssociateCompany.UseVisualStyleBackColor = false;
			cmd_AssociateCompany.Click += new System.EventHandler(cmd_AssociateCompany_Click);
			// 
			// cmd_Remove_Association
			// 
			cmd_Remove_Association.AllowDrop = true;
			cmd_Remove_Association.BackColor = System.Drawing.SystemColors.Control;
			cmd_Remove_Association.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Remove_Association.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Remove_Association.Location = new System.Drawing.Point(4, 112);
			cmd_Remove_Association.Name = "cmd_Remove_Association";
			cmd_Remove_Association.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Remove_Association.Size = new System.Drawing.Size(197, 25);
			cmd_Remove_Association.TabIndex = 361;
			cmd_Remove_Association.Text = "Remove Company/Contact Association";
			cmd_Remove_Association.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Remove_Association.UseVisualStyleBackColor = false;
			cmd_Remove_Association.Click += new System.EventHandler(cmd_Remove_Association_Click);
			// 
			// cmd_Set_As_Exclusive
			// 
			cmd_Set_As_Exclusive.AllowDrop = true;
			cmd_Set_As_Exclusive.BackColor = System.Drawing.SystemColors.Control;
			cmd_Set_As_Exclusive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Set_As_Exclusive.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Set_As_Exclusive.Location = new System.Drawing.Point(3, 31);
			cmd_Set_As_Exclusive.Name = "cmd_Set_As_Exclusive";
			cmd_Set_As_Exclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Set_As_Exclusive.Size = new System.Drawing.Size(197, 25);
			cmd_Set_As_Exclusive.TabIndex = 360;
			cmd_Set_As_Exclusive.Text = "Set Exclusive Confirmation Company";
			cmd_Set_As_Exclusive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Set_As_Exclusive.UseVisualStyleBackColor = false;
			cmd_Set_As_Exclusive.Click += new System.EventHandler(cmd_Set_As_Exclusive_Click);
			// 
			// cmd_Clear_Exclusive_Confirmation_Company
			// 
			cmd_Clear_Exclusive_Confirmation_Company.AllowDrop = true;
			cmd_Clear_Exclusive_Confirmation_Company.BackColor = System.Drawing.SystemColors.Control;
			cmd_Clear_Exclusive_Confirmation_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Clear_Exclusive_Confirmation_Company.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Clear_Exclusive_Confirmation_Company.Location = new System.Drawing.Point(3, 58);
			cmd_Clear_Exclusive_Confirmation_Company.Name = "cmd_Clear_Exclusive_Confirmation_Company";
			cmd_Clear_Exclusive_Confirmation_Company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Clear_Exclusive_Confirmation_Company.Size = new System.Drawing.Size(197, 25);
			cmd_Clear_Exclusive_Confirmation_Company.TabIndex = 359;
			cmd_Clear_Exclusive_Confirmation_Company.Text = "Clear Exclusive Confirmation Company";
			cmd_Clear_Exclusive_Confirmation_Company.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Clear_Exclusive_Confirmation_Company.UseVisualStyleBackColor = false;
			cmd_Clear_Exclusive_Confirmation_Company.Click += new System.EventHandler(cmd_Clear_Exclusive_Confirmation_Company_Click);
			// 
			// chkShowAllContactInfo
			// 
			chkShowAllContactInfo.AllowDrop = true;
			chkShowAllContactInfo.Appearance = System.Windows.Forms.Appearance.Normal;
			chkShowAllContactInfo.BackColor = System.Drawing.SystemColors.Control;
			chkShowAllContactInfo.CausesValidation = true;
			chkShowAllContactInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkShowAllContactInfo.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkShowAllContactInfo.Enabled = true;
			chkShowAllContactInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkShowAllContactInfo.ForeColor = System.Drawing.SystemColors.WindowText;
			chkShowAllContactInfo.Location = new System.Drawing.Point(631, 158);
			chkShowAllContactInfo.Name = "chkShowAllContactInfo";
			chkShowAllContactInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkShowAllContactInfo.Size = new System.Drawing.Size(118, 14);
			chkShowAllContactInfo.TabIndex = 277;
			chkShowAllContactInfo.TabStop = true;
			chkShowAllContactInfo.Text = "Show All Contacts";
			chkShowAllContactInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkShowAllContactInfo.Visible = true;
			chkShowAllContactInfo.CheckStateChanged += new System.EventHandler(chkShowAllContactInfo_CheckStateChanged);
			// 
			// _cmdAddACDetail_5
			// 
			_cmdAddACDetail_5.AllowDrop = true;
			_cmdAddACDetail_5.BackColor = System.Drawing.SystemColors.Control;
			_cmdAddACDetail_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAddACDetail_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAddACDetail_5.Location = new System.Drawing.Point(220, 310);
			_cmdAddACDetail_5.Name = "_cmdAddACDetail_5";
			_cmdAddACDetail_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAddACDetail_5.Size = new System.Drawing.Size(141, 21);
			_cmdAddACDetail_5.TabIndex = 307;
			_cmdAddACDetail_5.Text = "View Share Relationships";
			_cmdAddACDetail_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAddACDetail_5.UseVisualStyleBackColor = false;
			_cmdAddACDetail_5.Click += new System.EventHandler(cmdAddACDetail_Click);
			// 
			// lst_Company
			// 
			lst_Company.AllowDrop = true;
			lst_Company.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Company.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Company.CausesValidation = true;
			lst_Company.Enabled = true;
			lst_Company.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Company.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Company.IntegralHeight = true;
			lst_Company.Location = new System.Drawing.Point(220, 180);
			lst_Company.MultiColumn = false;
			lst_Company.Name = "lst_Company";
			lst_Company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Company.Size = new System.Drawing.Size(376, 125);
			lst_Company.Sorted = false;
			lst_Company.TabIndex = 107;
			lst_Company.TabStop = true;
			lst_Company.Visible = true;
			lst_Company.DoubleClick += new System.EventHandler(lst_Company_DoubleClick);
			lst_Company.MouseDown += new System.Windows.Forms.MouseEventHandler(lst_Company_MouseDown);
			lst_Company.SelectedIndexChanged += new System.EventHandler(lst_Company_SelectedIndexChanged);
			// 
			// lst_Contact
			// 
			lst_Contact.AllowDrop = true;
			lst_Contact.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Contact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Contact.CausesValidation = true;
			lst_Contact.Enabled = true;
			lst_Contact.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Contact.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Contact.IntegralHeight = true;
			lst_Contact.Location = new System.Drawing.Point(605, 180);
			lst_Contact.MultiColumn = false;
			lst_Contact.Name = "lst_Contact";
			lst_Contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Contact.Size = new System.Drawing.Size(376, 125);
			lst_Contact.Sorted = false;
			lst_Contact.TabIndex = 106;
			lst_Contact.TabStop = true;
			lst_Contact.Visible = true;
			lst_Contact.DoubleClick += new System.EventHandler(lst_Contact_DoubleClick);
			lst_Contact.MouseDown += new System.Windows.Forms.MouseEventHandler(lst_Contact_MouseDown);
			lst_Contact.SelectedIndexChanged += new System.EventHandler(lst_Contact_SelectedIndexChanged);
			// 
			// _pnl_gen_4
			// 
			_pnl_gen_4.AllowDrop = true;
			_pnl_gen_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_pnl_gen_4.Controls.Add(_txt_gen_4);
			_pnl_gen_4.Controls.Add(cbo_ac_purchase_question);
			_pnl_gen_4.Controls.Add(_txt_gen_3);
			_pnl_gen_4.Controls.Add(_txt_gen_2);
			_pnl_gen_4.Controls.Add(_txt_gen_1);
			_pnl_gen_4.Controls.Add(_txt_gen_0);
			_pnl_gen_4.Controls.Add(grd_AircraftContacts);
			_pnl_gen_4.Controls.Add(_lbl_gen_16);
			_pnl_gen_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pnl_gen_4.Location = new System.Drawing.Point(4, 22);
			_pnl_gen_4.Name = "_pnl_gen_4";
			_pnl_gen_4.Size = new System.Drawing.Size(992, 131);
			_pnl_gen_4.TabIndex = 111;
			_pnl_gen_4.Click += new System.EventHandler(pnl_gen_Click);
			_pnl_gen_4.DoubleClick += new System.EventHandler(pnl_gen_DoubleClick);
			// 
			// _txt_gen_4
			// 
			_txt_gen_4.AcceptsReturn = true;
			_txt_gen_4.AllowDrop = true;
			_txt_gen_4.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
			_txt_gen_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_gen_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_4.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			_txt_gen_4.Location = new System.Drawing.Point(882, 105);
			_txt_gen_4.MaxLength = 0;
			_txt_gen_4.Name = "_txt_gen_4";
			_txt_gen_4.ReadOnly = true;
			_txt_gen_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_4.Size = new System.Drawing.Size(106, 19);
			_txt_gen_4.TabIndex = 336;
			_txt_gen_4.TabStop = false;
			_txt_gen_4.Text = "Operating Company";
			_txt_gen_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// cbo_ac_purchase_question
			// 
			cbo_ac_purchase_question.AllowDrop = true;
			cbo_ac_purchase_question.BackColor = System.Drawing.Color.Yellow;
			cbo_ac_purchase_question.CausesValidation = true;
			cbo_ac_purchase_question.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_purchase_question.Enabled = true;
			cbo_ac_purchase_question.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_purchase_question.ForeColor = System.Drawing.Color.Black;
			cbo_ac_purchase_question.IntegralHeight = true;
			cbo_ac_purchase_question.Location = new System.Drawing.Point(9, 43);
			cbo_ac_purchase_question.Name = "cbo_ac_purchase_question";
			cbo_ac_purchase_question.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_purchase_question.Size = new System.Drawing.Size(126, 21);
			cbo_ac_purchase_question.Sorted = false;
			cbo_ac_purchase_question.TabIndex = 324;
			cbo_ac_purchase_question.TabStop = true;
			cbo_ac_purchase_question.Visible = false;
			cbo_ac_purchase_question.SelectedIndexChanged += new System.EventHandler(cbo_ac_purchase_question_SelectedIndexChanged);
			// 
			// _txt_gen_3
			// 
			_txt_gen_3.AcceptsReturn = true;
			_txt_gen_3.AllowDrop = true;
			_txt_gen_3.BackColor = System.Drawing.Color.Red;
			_txt_gen_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_gen_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_3.ForeColor = System.Drawing.Color.White;
			_txt_gen_3.Location = new System.Drawing.Point(882, 42);
			_txt_gen_3.MaxLength = 0;
			_txt_gen_3.Name = "_txt_gen_3";
			_txt_gen_3.ReadOnly = true;
			_txt_gen_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_3.Size = new System.Drawing.Size(106, 19);
			_txt_gen_3.TabIndex = 280;
			_txt_gen_3.TabStop = false;
			_txt_gen_3.Text = "Hidden";
			_txt_gen_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _txt_gen_2
			// 
			_txt_gen_2.AcceptsReturn = true;
			_txt_gen_2.AllowDrop = true;
			_txt_gen_2.BackColor = System.Drawing.Color.Purple;
			_txt_gen_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_gen_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_2.ForeColor = System.Drawing.Color.White;
			_txt_gen_2.Location = new System.Drawing.Point(882, 21);
			_txt_gen_2.MaxLength = 0;
			_txt_gen_2.Name = "_txt_gen_2";
			_txt_gen_2.ReadOnly = true;
			_txt_gen_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_2.Size = new System.Drawing.Size(106, 19);
			_txt_gen_2.TabIndex = 274;
			_txt_gen_2.TabStop = false;
			_txt_gen_2.Text = "Transmit";
			_txt_gen_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _txt_gen_1
			// 
			_txt_gen_1.AcceptsReturn = true;
			_txt_gen_1.AllowDrop = true;
			_txt_gen_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			_txt_gen_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_gen_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_gen_1.Location = new System.Drawing.Point(882, 84);
			_txt_gen_1.MaxLength = 0;
			_txt_gen_1.Name = "_txt_gen_1";
			_txt_gen_1.ReadOnly = true;
			_txt_gen_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_1.Size = new System.Drawing.Size(106, 19);
			_txt_gen_1.TabIndex = 116;
			_txt_gen_1.TabStop = false;
			_txt_gen_1.Text = "Confirm Exclusive";
			_txt_gen_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _txt_gen_0
			// 
			_txt_gen_0.AcceptsReturn = true;
			_txt_gen_0.AllowDrop = true;
			_txt_gen_0.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			_txt_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_gen_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_gen_0.Location = new System.Drawing.Point(882, 63);
			_txt_gen_0.MaxLength = 0;
			_txt_gen_0.Name = "_txt_gen_0";
			_txt_gen_0.ReadOnly = true;
			_txt_gen_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_0.Size = new System.Drawing.Size(106, 19);
			_txt_gen_0.TabIndex = 115;
			_txt_gen_0.TabStop = false;
			_txt_gen_0.Text = "Primary Company";
			_txt_gen_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// grd_AircraftContacts
			// 
			grd_AircraftContacts.AllowDrop = true;
			grd_AircraftContacts.AllowUserToAddRows = false;
			grd_AircraftContacts.AllowUserToDeleteRows = false;
			grd_AircraftContacts.AllowUserToResizeColumns = false;
			grd_AircraftContacts.AllowUserToResizeColumns = grd_AircraftContacts.ColumnHeadersVisible;
			grd_AircraftContacts.AllowUserToResizeRows = false;
			grd_AircraftContacts.AllowUserToResizeRows = false;
			grd_AircraftContacts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_AircraftContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_AircraftContacts.ColumnsCount = 2;
			grd_AircraftContacts.FixedColumns = 0;
			grd_AircraftContacts.FixedRows = 1;
			grd_AircraftContacts.Location = new System.Drawing.Point(8, 4);
			grd_AircraftContacts.Name = "grd_AircraftContacts";
			grd_AircraftContacts.ReadOnly = true;
			grd_AircraftContacts.RowsCount = 2;
			grd_AircraftContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_AircraftContacts.ShowCellToolTips = false;
			grd_AircraftContacts.Size = new System.Drawing.Size(868, 118);
			grd_AircraftContacts.StandardTab = true;
			grd_AircraftContacts.TabIndex = 113;
			grd_AircraftContacts.Click += new System.EventHandler(grd_AircraftContacts_Click);
			grd_AircraftContacts.DoubleClick += new System.EventHandler(grd_AircraftContacts_DoubleClick);
			grd_AircraftContacts.MouseDown += new System.Windows.Forms.MouseEventHandler(grd_AircraftContacts_MouseDown);
			// 
			// _lbl_gen_16
			// 
			_lbl_gen_16.AllowDrop = true;
			_lbl_gen_16.AutoSize = true;
			_lbl_gen_16.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_16.Location = new System.Drawing.Point(923, 5);
			_lbl_gen_16.MinimumSize = new System.Drawing.Size(25, 13);
			_lbl_gen_16.Name = "_lbl_gen_16";
			_lbl_gen_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_16.Size = new System.Drawing.Size(25, 13);
			_lbl_gen_16.TabIndex = 117;
			_lbl_gen_16.Text = "Key:";
			_lbl_gen_16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_16.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_16.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// pnl_LeaseEntry
			// 
			pnl_LeaseEntry.AllowDrop = true;
			pnl_LeaseEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_LeaseEntry.Controls.Add(_txt_ac_lease_type_2);
			pnl_LeaseEntry.Controls.Add(_txt_ac_lease_type_1);
			pnl_LeaseEntry.Controls.Add(txtLeaseExpireConfirmDate);
			pnl_LeaseEntry.Controls.Add(chkConfirmLeaseExpired);
			pnl_LeaseEntry.Controls.Add(txt_ac_lease_expire_date);
			pnl_LeaseEntry.Controls.Add(_txt_ac_lease_type_0);
			pnl_LeaseEntry.Controls.Add(_cmdSaveLease_0);
			pnl_LeaseEntry.Controls.Add(_cmdSaveLease_1);
			pnl_LeaseEntry.Controls.Add(_lbl_gen_82);
			pnl_LeaseEntry.Controls.Add(_lbl_gen_224);
			pnl_LeaseEntry.Controls.Add(_lbl_gen_218);
			pnl_LeaseEntry.Controls.Add(_lbl_gen_190);
			pnl_LeaseEntry.Controls.Add(_lbl_gen_217);
			pnl_LeaseEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_LeaseEntry.Location = new System.Drawing.Point(6, 340);
			pnl_LeaseEntry.Name = "pnl_LeaseEntry";
			pnl_LeaseEntry.Size = new System.Drawing.Size(593, 132);
			pnl_LeaseEntry.TabIndex = 145;
			pnl_LeaseEntry.Visible = false;
			// 
			// _txt_ac_lease_type_2
			// 
			_txt_ac_lease_type_2.AcceptsReturn = true;
			_txt_ac_lease_type_2.AllowDrop = true;
			_txt_ac_lease_type_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_lease_type_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_lease_type_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_lease_type_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_lease_type_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_lease_type_2.Location = new System.Drawing.Point(48, 56);
			_txt_ac_lease_type_2.MaxLength = 400;
			_txt_ac_lease_type_2.Multiline = true;
			_txt_ac_lease_type_2.Name = "_txt_ac_lease_type_2";
			_txt_ac_lease_type_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_lease_type_2.Size = new System.Drawing.Size(529, 67);
			_txt_ac_lease_type_2.TabIndex = 454;
			// 
			// _txt_ac_lease_type_1
			// 
			_txt_ac_lease_type_1.AcceptsReturn = true;
			_txt_ac_lease_type_1.AllowDrop = true;
			_txt_ac_lease_type_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_lease_type_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_lease_type_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_lease_type_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_lease_type_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_lease_type_1.Location = new System.Drawing.Point(368, 32);
			_txt_ac_lease_type_1.MaxLength = 15;
			_txt_ac_lease_type_1.Name = "_txt_ac_lease_type_1";
			_txt_ac_lease_type_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_lease_type_1.Size = new System.Drawing.Size(89, 19);
			_txt_ac_lease_type_1.TabIndex = 447;
			// 
			// txtLeaseExpireConfirmDate
			// 
			txtLeaseExpireConfirmDate.AcceptsReturn = true;
			txtLeaseExpireConfirmDate.AllowDrop = true;
			txtLeaseExpireConfirmDate.BackColor = System.Drawing.SystemColors.Window;
			txtLeaseExpireConfirmDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtLeaseExpireConfirmDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtLeaseExpireConfirmDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtLeaseExpireConfirmDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtLeaseExpireConfirmDate.Location = new System.Drawing.Point(121, 32);
			txtLeaseExpireConfirmDate.MaxLength = 0;
			txtLeaseExpireConfirmDate.Name = "txtLeaseExpireConfirmDate";
			txtLeaseExpireConfirmDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtLeaseExpireConfirmDate.Size = new System.Drawing.Size(84, 19);
			txtLeaseExpireConfirmDate.TabIndex = 156;
			// 
			// chkConfirmLeaseExpired
			// 
			chkConfirmLeaseExpired.AllowDrop = true;
			chkConfirmLeaseExpired.Appearance = System.Windows.Forms.Appearance.Normal;
			chkConfirmLeaseExpired.BackColor = System.Drawing.SystemColors.Control;
			chkConfirmLeaseExpired.CausesValidation = true;
			chkConfirmLeaseExpired.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkConfirmLeaseExpired.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkConfirmLeaseExpired.Enabled = true;
			chkConfirmLeaseExpired.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkConfirmLeaseExpired.ForeColor = System.Drawing.SystemColors.WindowText;
			chkConfirmLeaseExpired.Location = new System.Drawing.Point(476, 11);
			chkConfirmLeaseExpired.Name = "chkConfirmLeaseExpired";
			chkConfirmLeaseExpired.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkConfirmLeaseExpired.Size = new System.Drawing.Size(104, 13);
			chkConfirmLeaseExpired.TabIndex = 154;
			chkConfirmLeaseExpired.TabStop = true;
			chkConfirmLeaseExpired.Text = "Check if Expired";
			chkConfirmLeaseExpired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkConfirmLeaseExpired.Visible = true;
			chkConfirmLeaseExpired.CheckStateChanged += new System.EventHandler(chkConfirmLeaseExpired_CheckStateChanged);
			// 
			// txt_ac_lease_expire_date
			// 
			txt_ac_lease_expire_date.AcceptsReturn = true;
			txt_ac_lease_expire_date.AllowDrop = true;
			txt_ac_lease_expire_date.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_lease_expire_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_lease_expire_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_lease_expire_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_lease_expire_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_lease_expire_date.Location = new System.Drawing.Point(121, 8);
			txt_ac_lease_expire_date.MaxLength = 0;
			txt_ac_lease_expire_date.Name = "txt_ac_lease_expire_date";
			txt_ac_lease_expire_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_lease_expire_date.Size = new System.Drawing.Size(84, 19);
			txt_ac_lease_expire_date.TabIndex = 149;
			// 
			// _txt_ac_lease_type_0
			// 
			_txt_ac_lease_type_0.AcceptsReturn = true;
			_txt_ac_lease_type_0.AllowDrop = true;
			_txt_ac_lease_type_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_lease_type_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_lease_type_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_lease_type_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_lease_type_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_lease_type_0.Location = new System.Drawing.Point(238, 32);
			_txt_ac_lease_type_0.MaxLength = 15;
			_txt_ac_lease_type_0.Name = "_txt_ac_lease_type_0";
			_txt_ac_lease_type_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_lease_type_0.Size = new System.Drawing.Size(89, 19);
			_txt_ac_lease_type_0.TabIndex = 148;
			// 
			// _cmdSaveLease_0
			// 
			_cmdSaveLease_0.AllowDrop = true;
			_cmdSaveLease_0.BackColor = System.Drawing.SystemColors.Control;
			_cmdSaveLease_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSaveLease_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSaveLease_0.Location = new System.Drawing.Point(460, 32);
			_cmdSaveLease_0.Name = "_cmdSaveLease_0";
			_cmdSaveLease_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSaveLease_0.Size = new System.Drawing.Size(59, 20);
			_cmdSaveLease_0.TabIndex = 147;
			_cmdSaveLease_0.Tag = "cmdSaveLease";
			_cmdSaveLease_0.Text = "Save";
			_cmdSaveLease_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSaveLease_0.UseVisualStyleBackColor = false;
			_cmdSaveLease_0.Click += new System.EventHandler(cmdSaveLease_Click);
			// 
			// _cmdSaveLease_1
			// 
			_cmdSaveLease_1.AllowDrop = true;
			_cmdSaveLease_1.BackColor = System.Drawing.SystemColors.Control;
			_cmdSaveLease_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSaveLease_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSaveLease_1.Location = new System.Drawing.Point(527, 33);
			_cmdSaveLease_1.Name = "_cmdSaveLease_1";
			_cmdSaveLease_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSaveLease_1.Size = new System.Drawing.Size(59, 20);
			_cmdSaveLease_1.TabIndex = 146;
			_cmdSaveLease_1.Tag = "cmdCancelLease";
			_cmdSaveLease_1.Text = "Cancel";
			_cmdSaveLease_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSaveLease_1.UseVisualStyleBackColor = false;
			_cmdSaveLease_1.Click += new System.EventHandler(cmdSaveLease_Click);
			// 
			// _lbl_gen_82
			// 
			_lbl_gen_82.AllowDrop = true;
			_lbl_gen_82.AutoSize = true;
			_lbl_gen_82.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_82.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_82.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_82.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_82.Location = new System.Drawing.Point(18, 36);
			_lbl_gen_82.MinimumSize = new System.Drawing.Size(97, 13);
			_lbl_gen_82.Name = "_lbl_gen_82";
			_lbl_gen_82.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_82.Size = new System.Drawing.Size(97, 13);
			_lbl_gen_82.TabIndex = 278;
			_lbl_gen_82.Text = "Actual Date Expired:";
			_lbl_gen_82.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_82.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_224
			// 
			_lbl_gen_224.AllowDrop = true;
			_lbl_gen_224.AutoSize = true;
			_lbl_gen_224.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_224.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_224.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_224.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_224.Location = new System.Drawing.Point(3, 10);
			_lbl_gen_224.MinimumSize = new System.Drawing.Size(112, 13);
			_lbl_gen_224.Name = "_lbl_gen_224";
			_lbl_gen_224.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_224.Size = new System.Drawing.Size(112, 13);
			_lbl_gen_224.TabIndex = 153;
			_lbl_gen_224.Text = "Scheduled Expire Date:";
			_lbl_gen_224.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_224.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_224.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_218
			// 
			_lbl_gen_218.AllowDrop = true;
			_lbl_gen_218.AutoSize = true;
			_lbl_gen_218.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_218.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_218.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_218.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_218.Location = new System.Drawing.Point(209, 34);
			_lbl_gen_218.MinimumSize = new System.Drawing.Size(27, 13);
			_lbl_gen_218.Name = "_lbl_gen_218";
			_lbl_gen_218.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_218.Size = new System.Drawing.Size(27, 13);
			_lbl_gen_218.TabIndex = 152;
			_lbl_gen_218.Text = "Type:";
			_lbl_gen_218.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_218.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_190
			// 
			_lbl_gen_190.AllowDrop = true;
			_lbl_gen_190.AutoSize = true;
			_lbl_gen_190.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_190.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_190.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_190.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_190.Location = new System.Drawing.Point(331, 34);
			_lbl_gen_190.MinimumSize = new System.Drawing.Size(27, 13);
			_lbl_gen_190.Name = "_lbl_gen_190";
			_lbl_gen_190.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_190.Size = new System.Drawing.Size(27, 13);
			_lbl_gen_190.TabIndex = 151;
			_lbl_gen_190.Text = "Term:";
			_lbl_gen_190.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_190.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_217
			// 
			_lbl_gen_217.AllowDrop = true;
			_lbl_gen_217.AutoSize = true;
			_lbl_gen_217.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_217.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_217.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_217.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_217.Location = new System.Drawing.Point(9, 57);
			_lbl_gen_217.MinimumSize = new System.Drawing.Size(32, 13);
			_lbl_gen_217.Name = "_lbl_gen_217";
			_lbl_gen_217.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_217.Size = new System.Drawing.Size(32, 13);
			_lbl_gen_217.TabIndex = 150;
			_lbl_gen_217.Text = "Notes:";
			_lbl_gen_217.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_217.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_217.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// pnl_LeaseList
			// 
			pnl_LeaseList.AllowDrop = true;
			pnl_LeaseList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_LeaseList.Controls.Add(chkConfirmedOnly);
			pnl_LeaseList.Controls.Add(grdLeaseInfo);
			pnl_LeaseList.Controls.Add(_lbl_gen_38);
			pnl_LeaseList.Controls.Add(_lbl_gen_37);
			pnl_LeaseList.Controls.Add(_lbl_gen_36);
			pnl_LeaseList.Controls.Add(_lbl_gen_29);
			pnl_LeaseList.Controls.Add(_lbl_gen_21);
			pnl_LeaseList.Controls.Add(_lbl_gen_39);
			pnl_LeaseList.Controls.Add(_lbl_gen_43);
			pnl_LeaseList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_LeaseList.Location = new System.Drawing.Point(7, 334);
			pnl_LeaseList.Name = "pnl_LeaseList";
			pnl_LeaseList.Size = new System.Drawing.Size(987, 132);
			pnl_LeaseList.TabIndex = 133;
			// 
			// chkConfirmedOnly
			// 
			chkConfirmedOnly.AllowDrop = true;
			chkConfirmedOnly.Appearance = System.Windows.Forms.Appearance.Normal;
			chkConfirmedOnly.BackColor = System.Drawing.SystemColors.Control;
			chkConfirmedOnly.CausesValidation = true;
			chkConfirmedOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkConfirmedOnly.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkConfirmedOnly.Enabled = true;
			chkConfirmedOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkConfirmedOnly.ForeColor = System.Drawing.SystemColors.WindowText;
			chkConfirmedOnly.Location = new System.Drawing.Point(776, 6);
			chkConfirmedOnly.Name = "chkConfirmedOnly";
			chkConfirmedOnly.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkConfirmedOnly.Size = new System.Drawing.Size(203, 13);
			chkConfirmedOnly.TabIndex = 135;
			chkConfirmedOnly.TabStop = true;
			chkConfirmedOnly.Text = "Show All Leases (Active and Expired)";
			chkConfirmedOnly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkConfirmedOnly.Visible = true;
			chkConfirmedOnly.CheckStateChanged += new System.EventHandler(chkConfirmedOnly_CheckStateChanged);
			// 
			// grdLeaseInfo
			// 
			grdLeaseInfo.AllowDrop = true;
			grdLeaseInfo.AllowUserToAddRows = false;
			grdLeaseInfo.AllowUserToDeleteRows = false;
			grdLeaseInfo.AllowUserToResizeColumns = false;
			grdLeaseInfo.AllowUserToResizeRows = false;
			grdLeaseInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdLeaseInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdLeaseInfo.ColumnsCount = 2;
			grdLeaseInfo.FixedColumns = 0;
			grdLeaseInfo.FixedRows = 0;
			grdLeaseInfo.Location = new System.Drawing.Point(5, 50);
			grdLeaseInfo.Name = "grdLeaseInfo";
			grdLeaseInfo.ReadOnly = true;
			grdLeaseInfo.RowsCount = 2;
			grdLeaseInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grdLeaseInfo.ShowCellToolTips = false;
			grdLeaseInfo.Size = new System.Drawing.Size(976, 76);
			grdLeaseInfo.StandardTab = true;
			grdLeaseInfo.TabIndex = 137;
			grdLeaseInfo.DoubleClick += new System.EventHandler(grdLeaseInfo_DoubleClick);
			// 
			// _lbl_gen_38
			// 
			_lbl_gen_38.AllowDrop = true;
			_lbl_gen_38.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_38.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_38.Location = new System.Drawing.Point(235, 7);
			_lbl_gen_38.MinimumSize = new System.Drawing.Size(51, 39);
			_lbl_gen_38.Name = "_lbl_gen_38";
			_lbl_gen_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_38.Size = new System.Drawing.Size(51, 39);
			_lbl_gen_38.TabIndex = 144;
			_lbl_gen_38.Text = "Actual Date Expired:";
			_lbl_gen_38.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_38.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_38.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_37
			// 
			_lbl_gen_37.AllowDrop = true;
			_lbl_gen_37.AutoSize = true;
			_lbl_gen_37.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_37.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_37.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_37.Location = new System.Drawing.Point(299, 31);
			_lbl_gen_37.MinimumSize = new System.Drawing.Size(34, 13);
			_lbl_gen_37.Name = "_lbl_gen_37";
			_lbl_gen_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_37.Size = new System.Drawing.Size(34, 13);
			_lbl_gen_37.TabIndex = 143;
			_lbl_gen_37.Text = "Lessor:";
			_lbl_gen_37.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_37.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_36
			// 
			_lbl_gen_36.AllowDrop = true;
			_lbl_gen_36.AutoSize = true;
			_lbl_gen_36.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_36.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_36.Location = new System.Drawing.Point(175, 31);
			_lbl_gen_36.MinimumSize = new System.Drawing.Size(27, 13);
			_lbl_gen_36.Name = "_lbl_gen_36";
			_lbl_gen_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_36.Size = new System.Drawing.Size(27, 13);
			_lbl_gen_36.TabIndex = 142;
			_lbl_gen_36.Text = "Term:";
			_lbl_gen_36.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_36.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_29
			// 
			_lbl_gen_29.AllowDrop = true;
			_lbl_gen_29.AutoSize = true;
			_lbl_gen_29.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_29.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_29.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_29.Location = new System.Drawing.Point(97, 31);
			_lbl_gen_29.MinimumSize = new System.Drawing.Size(27, 13);
			_lbl_gen_29.Name = "_lbl_gen_29";
			_lbl_gen_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_29.Size = new System.Drawing.Size(27, 13);
			_lbl_gen_29.TabIndex = 141;
			_lbl_gen_29.Text = "Type:";
			_lbl_gen_29.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_29.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_21
			// 
			_lbl_gen_21.AllowDrop = true;
			_lbl_gen_21.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_21.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_21.Location = new System.Drawing.Point(12, 7);
			_lbl_gen_21.MinimumSize = new System.Drawing.Size(51, 39);
			_lbl_gen_21.Name = "_lbl_gen_21";
			_lbl_gen_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_21.Size = new System.Drawing.Size(51, 39);
			_lbl_gen_21.TabIndex = 140;
			_lbl_gen_21.Text = "Scheduled Expire Date:";
			_lbl_gen_21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_21.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_21.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_39
			// 
			_lbl_gen_39.AllowDrop = true;
			_lbl_gen_39.AutoSize = true;
			_lbl_gen_39.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_39.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_39.Location = new System.Drawing.Point(702, 31);
			_lbl_gen_39.MinimumSize = new System.Drawing.Size(31, 13);
			_lbl_gen_39.Name = "_lbl_gen_39";
			_lbl_gen_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_39.Size = new System.Drawing.Size(31, 13);
			_lbl_gen_39.TabIndex = 139;
			_lbl_gen_39.Text = "Notes:";
			_lbl_gen_39.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_39.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_43
			// 
			_lbl_gen_43.AllowDrop = true;
			_lbl_gen_43.AutoSize = true;
			_lbl_gen_43.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_43.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_43.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_43.Location = new System.Drawing.Point(503, 31);
			_lbl_gen_43.MinimumSize = new System.Drawing.Size(37, 13);
			_lbl_gen_43.Name = "_lbl_gen_43";
			_lbl_gen_43.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_43.Size = new System.Drawing.Size(37, 13);
			_lbl_gen_43.TabIndex = 138;
			_lbl_gen_43.Text = "Lessee:";
			_lbl_gen_43.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_43.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_55
			// 
			_lbl_gen_55.AllowDrop = true;
			_lbl_gen_55.AutoSize = true;
			_lbl_gen_55.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_55.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_55.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_55.Location = new System.Drawing.Point(242, 159);
			_lbl_gen_55.MinimumSize = new System.Drawing.Size(85, 13);
			_lbl_gen_55.Name = "_lbl_gen_55";
			_lbl_gen_55.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_55.Size = new System.Drawing.Size(85, 13);
			_lbl_gen_55.TabIndex = 212;
			_lbl_gen_55.Text = "Percentage Total:";
			_lbl_gen_55.Visible = false;
			_lbl_gen_55.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_55.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _tab_aircraft_details_TabPage6
			// 
			_tab_aircraft_details_TabPage6.Controls.Add(txtACJournalSearch);
			_tab_aircraft_details_TabPage6.Controls.Add(txt_ac_common_notes);
			_tab_aircraft_details_TabPage6.Controls.Add(cbo_jcat_subcategory_code);
			_tab_aircraft_details_TabPage6.Controls.Add(cbo_jcat_category_code);
			_tab_aircraft_details_TabPage6.Controls.Add(cbo_jcat_account_rep);
			_tab_aircraft_details_TabPage6.Controls.Add(txt_journal_category_start_date);
			_tab_aircraft_details_TabPage6.Controls.Add(txt_journal_category_end_date);
			_tab_aircraft_details_TabPage6.Controls.Add(cmd_jcat_Redisplay_Journal_List);
			_tab_aircraft_details_TabPage6.Controls.Add(_chkArray_1);
			_tab_aircraft_details_TabPage6.Controls.Add(txtHowManyJournal);
			_tab_aircraft_details_TabPage6.Controls.Add(grd_Aircraft_Journal);
			_tab_aircraft_details_TabPage6.Controls.Add(_lbl_gen_125);
			_tab_aircraft_details_TabPage6.Controls.Add(_lbl_gen_233);
			_tab_aircraft_details_TabPage6.Controls.Add(_lbl_gen_91);
			_tab_aircraft_details_TabPage6.Controls.Add(_lbl_gen_96);
			_tab_aircraft_details_TabPage6.Controls.Add(_lbl_gen_99);
			_tab_aircraft_details_TabPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage6.Text = "Journal";
			// 
			// txtACJournalSearch
			// 
			txtACJournalSearch.AcceptsReturn = true;
			txtACJournalSearch.AllowDrop = true;
			txtACJournalSearch.BackColor = System.Drawing.SystemColors.Window;
			txtACJournalSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtACJournalSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtACJournalSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtACJournalSearch.ForeColor = System.Drawing.SystemColors.WindowText;
			txtACJournalSearch.Location = new System.Drawing.Point(173, 20);
			txtACJournalSearch.MaxLength = 0;
			txtACJournalSearch.Name = "txtACJournalSearch";
			txtACJournalSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtACJournalSearch.Size = new System.Drawing.Size(389, 19);
			txtACJournalSearch.TabIndex = 365;
			txtACJournalSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtACJournalSearch_KeyPress);
			// 
			// txt_ac_common_notes
			// 
			txt_ac_common_notes.AcceptsReturn = true;
			txt_ac_common_notes.AllowDrop = true;
			txt_ac_common_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_common_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_common_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_common_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_common_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_common_notes.Location = new System.Drawing.Point(619, 41);
			txt_ac_common_notes.MaxLength = 800;
			txt_ac_common_notes.Multiline = true;
			txt_ac_common_notes.Name = "txt_ac_common_notes";
			txt_ac_common_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_common_notes.Size = new System.Drawing.Size(370, 73);
			txt_ac_common_notes.TabIndex = 376;
			// 
			// cbo_jcat_subcategory_code
			// 
			cbo_jcat_subcategory_code.AllowDrop = true;
			cbo_jcat_subcategory_code.BackColor = System.Drawing.SystemColors.Window;
			cbo_jcat_subcategory_code.CausesValidation = true;
			cbo_jcat_subcategory_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_jcat_subcategory_code.Enabled = true;
			cbo_jcat_subcategory_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_jcat_subcategory_code.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_jcat_subcategory_code.IntegralHeight = true;
			cbo_jcat_subcategory_code.Location = new System.Drawing.Point(325, 44);
			cbo_jcat_subcategory_code.Name = "cbo_jcat_subcategory_code";
			cbo_jcat_subcategory_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_jcat_subcategory_code.Size = new System.Drawing.Size(239, 21);
			cbo_jcat_subcategory_code.Sorted = false;
			cbo_jcat_subcategory_code.TabIndex = 367;
			cbo_jcat_subcategory_code.TabStop = true;
			cbo_jcat_subcategory_code.Visible = true;
			// 
			// cbo_jcat_category_code
			// 
			cbo_jcat_category_code.AllowDrop = true;
			cbo_jcat_category_code.BackColor = System.Drawing.SystemColors.Window;
			cbo_jcat_category_code.CausesValidation = true;
			cbo_jcat_category_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_jcat_category_code.Enabled = true;
			cbo_jcat_category_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_jcat_category_code.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_jcat_category_code.IntegralHeight = true;
			cbo_jcat_category_code.Location = new System.Drawing.Point(173, 44);
			cbo_jcat_category_code.Name = "cbo_jcat_category_code";
			cbo_jcat_category_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_jcat_category_code.Size = new System.Drawing.Size(148, 21);
			cbo_jcat_category_code.Sorted = false;
			cbo_jcat_category_code.TabIndex = 366;
			cbo_jcat_category_code.TabStop = true;
			cbo_jcat_category_code.Visible = true;
			// 
			// cbo_jcat_account_rep
			// 
			cbo_jcat_account_rep.AllowDrop = true;
			cbo_jcat_account_rep.BackColor = System.Drawing.SystemColors.Window;
			cbo_jcat_account_rep.CausesValidation = true;
			cbo_jcat_account_rep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_jcat_account_rep.Enabled = true;
			cbo_jcat_account_rep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_jcat_account_rep.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_jcat_account_rep.IntegralHeight = true;
			cbo_jcat_account_rep.Location = new System.Drawing.Point(173, 69);
			cbo_jcat_account_rep.Name = "cbo_jcat_account_rep";
			cbo_jcat_account_rep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_jcat_account_rep.Size = new System.Drawing.Size(148, 21);
			cbo_jcat_account_rep.Sorted = false;
			cbo_jcat_account_rep.TabIndex = 368;
			cbo_jcat_account_rep.TabStop = true;
			cbo_jcat_account_rep.Visible = true;
			// 
			// txt_journal_category_start_date
			// 
			txt_journal_category_start_date.AcceptsReturn = true;
			txt_journal_category_start_date.AllowDrop = true;
			txt_journal_category_start_date.BackColor = System.Drawing.SystemColors.Window;
			txt_journal_category_start_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journal_category_start_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journal_category_start_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journal_category_start_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journal_category_start_date.Location = new System.Drawing.Point(174, 94);
			txt_journal_category_start_date.MaxLength = 0;
			txt_journal_category_start_date.Name = "txt_journal_category_start_date";
			txt_journal_category_start_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journal_category_start_date.Size = new System.Drawing.Size(65, 19);
			txt_journal_category_start_date.TabIndex = 369;
			// 
			// txt_journal_category_end_date
			// 
			txt_journal_category_end_date.AcceptsReturn = true;
			txt_journal_category_end_date.AllowDrop = true;
			txt_journal_category_end_date.BackColor = System.Drawing.SystemColors.Window;
			txt_journal_category_end_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journal_category_end_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journal_category_end_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journal_category_end_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journal_category_end_date.Location = new System.Drawing.Point(251, 95);
			txt_journal_category_end_date.MaxLength = 0;
			txt_journal_category_end_date.Name = "txt_journal_category_end_date";
			txt_journal_category_end_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journal_category_end_date.Size = new System.Drawing.Size(70, 19);
			txt_journal_category_end_date.TabIndex = 370;
			// 
			// cmd_jcat_Redisplay_Journal_List
			// 
			cmd_jcat_Redisplay_Journal_List.AllowDrop = true;
			cmd_jcat_Redisplay_Journal_List.BackColor = System.Drawing.SystemColors.Control;
			cmd_jcat_Redisplay_Journal_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_jcat_Redisplay_Journal_List.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_jcat_Redisplay_Journal_List.Location = new System.Drawing.Point(386, 68);
			cmd_jcat_Redisplay_Journal_List.Name = "cmd_jcat_Redisplay_Journal_List";
			cmd_jcat_Redisplay_Journal_List.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_jcat_Redisplay_Journal_List.Size = new System.Drawing.Size(121, 22);
			cmd_jcat_Redisplay_Journal_List.TabIndex = 375;
			cmd_jcat_Redisplay_Journal_List.Text = "Re-Display Journal List";
			cmd_jcat_Redisplay_Journal_List.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_jcat_Redisplay_Journal_List.UseVisualStyleBackColor = false;
			cmd_jcat_Redisplay_Journal_List.Click += new System.EventHandler(cmd_jcat_Redisplay_Journal_List_Click);
			// 
			// _chkArray_1
			// 
			_chkArray_1.AllowDrop = true;
			_chkArray_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkArray_1.BackColor = System.Drawing.SystemColors.Control;
			_chkArray_1.CausesValidation = true;
			_chkArray_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_1.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkArray_1.Enabled = true;
			_chkArray_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkArray_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_chkArray_1.Location = new System.Drawing.Point(376, 98);
			_chkArray_1.Name = "_chkArray_1";
			_chkArray_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkArray_1.Size = new System.Drawing.Size(93, 14);
			_chkArray_1.TabIndex = 371;
			_chkArray_1.TabStop = true;
			_chkArray_1.Text = "Only Show First";
			_chkArray_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_1.Visible = true;
			_chkArray_1.CheckStateChanged += new System.EventHandler(chkArray_CheckStateChanged);
			_chkArray_1.MouseDown += new System.Windows.Forms.MouseEventHandler(chkArray_MouseDown);
			// 
			// txtHowManyJournal
			// 
			txtHowManyJournal.AcceptsReturn = true;
			txtHowManyJournal.AllowDrop = true;
			txtHowManyJournal.BackColor = System.Drawing.SystemColors.Window;
			txtHowManyJournal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtHowManyJournal.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtHowManyJournal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtHowManyJournal.ForeColor = System.Drawing.SystemColors.WindowText;
			txtHowManyJournal.Location = new System.Drawing.Point(474, 96);
			txtHowManyJournal.MaxLength = 0;
			txtHowManyJournal.Name = "txtHowManyJournal";
			txtHowManyJournal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtHowManyJournal.Size = new System.Drawing.Size(41, 19);
			txtHowManyJournal.TabIndex = 373;
			txtHowManyJournal.Text = "20";
			// 
			// grd_Aircraft_Journal
			// 
			grd_Aircraft_Journal.AllowDrop = true;
			grd_Aircraft_Journal.AllowUserToAddRows = false;
			grd_Aircraft_Journal.AllowUserToDeleteRows = false;
			grd_Aircraft_Journal.AllowUserToResizeColumns = false;
			grd_Aircraft_Journal.AllowUserToResizeColumns = grd_Aircraft_Journal.ColumnHeadersVisible;
			grd_Aircraft_Journal.AllowUserToResizeRows = false;
			grd_Aircraft_Journal.AllowUserToResizeRows = grd_Aircraft_Journal.RowHeadersVisible;
			grd_Aircraft_Journal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Aircraft_Journal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Aircraft_Journal.ColumnsCount = 10;
			grd_Aircraft_Journal.FixedColumns = 0;
			grd_Aircraft_Journal.FixedRows = 1;
			grd_Aircraft_Journal.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grd_Aircraft_Journal.Location = new System.Drawing.Point(10, 132);
			grd_Aircraft_Journal.Name = "grd_Aircraft_Journal";
			grd_Aircraft_Journal.ReadOnly = true;
			grd_Aircraft_Journal.RowsCount = 2;
			grd_Aircraft_Journal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Aircraft_Journal.ShowCellToolTips = false;
			grd_Aircraft_Journal.Size = new System.Drawing.Size(984, 335);
			grd_Aircraft_Journal.StandardTab = true;
			grd_Aircraft_Journal.TabIndex = 372;
			grd_Aircraft_Journal.Click += new System.EventHandler(grd_Aircraft_Journal_Click);
			grd_Aircraft_Journal.DoubleClick += new System.EventHandler(grd_Aircraft_Journal_DoubleClick);
			// 
			// _lbl_gen_125
			// 
			_lbl_gen_125.AllowDrop = true;
			_lbl_gen_125.AutoSize = true;
			_lbl_gen_125.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_125.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_125.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_125.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_125.Location = new System.Drawing.Point(24, 20);
			_lbl_gen_125.MinimumSize = new System.Drawing.Size(130, 13);
			_lbl_gen_125.Name = "_lbl_gen_125";
			_lbl_gen_125.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_125.Size = new System.Drawing.Size(130, 13);
			_lbl_gen_125.TabIndex = 431;
			_lbl_gen_125.Text = "Search Subject/Desc/User";
			_lbl_gen_125.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_125.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_233
			// 
			_lbl_gen_233.AllowDrop = true;
			_lbl_gen_233.AutoSize = true;
			_lbl_gen_233.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_233.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_233.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_233.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_233.Location = new System.Drawing.Point(620, 26);
			_lbl_gen_233.MinimumSize = new System.Drawing.Size(108, 11);
			_lbl_gen_233.Name = "_lbl_gen_233";
			_lbl_gen_233.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_233.Size = new System.Drawing.Size(108, 11);
			_lbl_gen_233.TabIndex = 379;
			_lbl_gen_233.Text = "Aircraft Common Notes";
			_lbl_gen_233.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_233.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_91
			// 
			_lbl_gen_91.AllowDrop = true;
			_lbl_gen_91.AutoSize = true;
			_lbl_gen_91.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_91.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_91.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_91.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_91.Location = new System.Drawing.Point(22, 47);
			_lbl_gen_91.MinimumSize = new System.Drawing.Size(151, 15);
			_lbl_gen_91.Name = "_lbl_gen_91";
			_lbl_gen_91.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_91.Size = new System.Drawing.Size(151, 15);
			_lbl_gen_91.TabIndex = 378;
			_lbl_gen_91.Text = "Category (Primary/Sub):";
			_lbl_gen_91.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_91.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_96
			// 
			_lbl_gen_96.AllowDrop = true;
			_lbl_gen_96.AutoSize = true;
			_lbl_gen_96.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_96.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_96.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_96.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_96.Location = new System.Drawing.Point(22, 72);
			_lbl_gen_96.MinimumSize = new System.Drawing.Size(151, 15);
			_lbl_gen_96.Name = "_lbl_gen_96";
			_lbl_gen_96.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_96.Size = new System.Drawing.Size(151, 15);
			_lbl_gen_96.TabIndex = 377;
			_lbl_gen_96.Text = "Account Representative:";
			_lbl_gen_96.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_96.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_99
			// 
			_lbl_gen_99.AllowDrop = true;
			_lbl_gen_99.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_99.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_99.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_99.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_99.Location = new System.Drawing.Point(22, 96);
			_lbl_gen_99.MinimumSize = new System.Drawing.Size(151, 15);
			_lbl_gen_99.Name = "_lbl_gen_99";
			_lbl_gen_99.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_99.Size = new System.Drawing.Size(151, 15);
			_lbl_gen_99.TabIndex = 374;
			_lbl_gen_99.Text = "Start/End Date (DD/MM/YY):";
			_lbl_gen_99.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_99.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _tab_aircraft_details_TabPage7
			// 
			_tab_aircraft_details_TabPage7.Controls.Add(web_OpCosts);
			_tab_aircraft_details_TabPage7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage7.Text = "Operating Costs";
			// 
			// web_OpCosts
			// 
			web_OpCosts.AllowWebBrowserDrop = true;
			web_OpCosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			web_OpCosts.Location = new System.Drawing.Point(10, 28);
			web_OpCosts.Name = "web_OpCosts";
			web_OpCosts.Size = new System.Drawing.Size(988, 437);
			web_OpCosts.TabIndex = 109;
			// 
			// _tab_aircraft_details_TabPage8
			// 
			_tab_aircraft_details_TabPage8.Controls.Add(web_Specs);
			_tab_aircraft_details_TabPage8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage8.Text = "Performance Specs";
			// 
			// web_Specs
			// 
			web_Specs.AllowWebBrowserDrop = true;
			web_Specs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			web_Specs.Location = new System.Drawing.Point(8, 30);
			web_Specs.Name = "web_Specs";
			web_Specs.Size = new System.Drawing.Size(988, 437);
			web_Specs.TabIndex = 108;
			// 
			// _tab_aircraft_details_TabPage9
			// 
			_tab_aircraft_details_TabPage9.Controls.Add(_lbl_gen_228);
			_tab_aircraft_details_TabPage9.Controls.Add(_lbl_gen_227);
			_tab_aircraft_details_TabPage9.Controls.Add(_lbl_gen_45);
			_tab_aircraft_details_TabPage9.Controls.Add(_lbl_gen_47);
			_tab_aircraft_details_TabPage9.Controls.Add(txt_acfaa_notes);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_reg_status_3);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_reg_no_3);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_reg_status_2);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_reg_no_2);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_reg_status_1);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_reg_no_1);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_reg_status_0);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_reg_no_0);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_party_comp_name_9);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_party_comp_name_8);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_party_comp_name_7);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_party_comp_name_6);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_party_comp_name_5);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_party_comp_name_4);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_party_comp_name_3);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_party_comp_name_2);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_party_comp_name_1);
			_tab_aircraft_details_TabPage9.Controls.Add(_txt_acfaa_party_comp_name_0);
			_tab_aircraft_details_TabPage9.Controls.Add(_grd_pubs_1);
			_tab_aircraft_details_TabPage9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage9.Text = "FAA Docs";
			// 
			// _lbl_gen_228
			// 
			_lbl_gen_228.AllowDrop = true;
			_lbl_gen_228.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_228.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_228.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_228.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_228.Location = new System.Drawing.Point(842, 368);
			_lbl_gen_228.MinimumSize = new System.Drawing.Size(41, 17);
			_lbl_gen_228.Name = "_lbl_gen_228";
			_lbl_gen_228.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_228.Size = new System.Drawing.Size(41, 17);
			_lbl_gen_228.TabIndex = 157;
			_lbl_gen_228.Text = "Status:";
			_lbl_gen_228.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_228.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_227
			// 
			_lbl_gen_227.AllowDrop = true;
			_lbl_gen_227.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_227.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_227.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_227.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_227.Location = new System.Drawing.Point(658, 368);
			_lbl_gen_227.MinimumSize = new System.Drawing.Size(81, 17);
			_lbl_gen_227.Name = "_lbl_gen_227";
			_lbl_gen_227.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_227.Size = new System.Drawing.Size(81, 17);
			_lbl_gen_227.TabIndex = 158;
			_lbl_gen_227.Text = "Registration #:";
			_lbl_gen_227.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_227.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_45
			// 
			_lbl_gen_45.AllowDrop = true;
			_lbl_gen_45.AutoSize = true;
			_lbl_gen_45.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_45.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_45.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_45.Location = new System.Drawing.Point(759, 345);
			_lbl_gen_45.MinimumSize = new System.Drawing.Size(115, 13);
			_lbl_gen_45.Name = "_lbl_gen_45";
			_lbl_gen_45.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_45.Size = new System.Drawing.Size(115, 13);
			_lbl_gen_45.TabIndex = 159;
			_lbl_gen_45.Text = "Pending Registration #'s";
			_lbl_gen_45.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_45.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_47
			// 
			_lbl_gen_47.AllowDrop = true;
			_lbl_gen_47.AutoSize = true;
			_lbl_gen_47.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_47.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_47.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_47.Location = new System.Drawing.Point(422, 359);
			_lbl_gen_47.MinimumSize = new System.Drawing.Size(69, 13);
			_lbl_gen_47.Name = "_lbl_gen_47";
			_lbl_gen_47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_47.Size = new System.Drawing.Size(69, 13);
			_lbl_gen_47.TabIndex = 161;
			_lbl_gen_47.Text = "Parties Named";
			_lbl_gen_47.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_47.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// txt_acfaa_notes
			// 
			txt_acfaa_notes.AcceptsReturn = true;
			txt_acfaa_notes.AllowDrop = true;
			txt_acfaa_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_acfaa_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_acfaa_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_acfaa_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_acfaa_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_acfaa_notes.Location = new System.Drawing.Point(320, 412);
			txt_acfaa_notes.MaxLength = 250;
			txt_acfaa_notes.Multiline = true;
			txt_acfaa_notes.Name = "txt_acfaa_notes";
			txt_acfaa_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_acfaa_notes.Size = new System.Drawing.Size(661, 51);
			txt_acfaa_notes.TabIndex = 179;
			// 
			// _txt_acfaa_reg_status_3
			// 
			_txt_acfaa_reg_status_3.AcceptsReturn = true;
			_txt_acfaa_reg_status_3.AllowDrop = true;
			_txt_acfaa_reg_status_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_reg_status_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_reg_status_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_reg_status_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_reg_status_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_reg_status_3.Location = new System.Drawing.Point(722, 152);
			_txt_acfaa_reg_status_3.MaxLength = 22;
			_txt_acfaa_reg_status_3.Name = "_txt_acfaa_reg_status_3";
			_txt_acfaa_reg_status_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_reg_status_3.Size = new System.Drawing.Size(137, 19);
			_txt_acfaa_reg_status_3.TabIndex = 178;
			// 
			// _txt_acfaa_reg_no_3
			// 
			_txt_acfaa_reg_no_3.AcceptsReturn = true;
			_txt_acfaa_reg_no_3.AllowDrop = true;
			_txt_acfaa_reg_no_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_reg_no_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_reg_no_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_reg_no_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_reg_no_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_reg_no_3.Location = new System.Drawing.Point(538, 152);
			_txt_acfaa_reg_no_3.MaxLength = 12;
			_txt_acfaa_reg_no_3.Name = "_txt_acfaa_reg_no_3";
			_txt_acfaa_reg_no_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_reg_no_3.Size = new System.Drawing.Size(137, 19);
			_txt_acfaa_reg_no_3.TabIndex = 177;
			// 
			// _txt_acfaa_reg_status_2
			// 
			_txt_acfaa_reg_status_2.AcceptsReturn = true;
			_txt_acfaa_reg_status_2.AllowDrop = true;
			_txt_acfaa_reg_status_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_reg_status_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_reg_status_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_reg_status_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_reg_status_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_reg_status_2.Location = new System.Drawing.Point(722, 128);
			_txt_acfaa_reg_status_2.MaxLength = 22;
			_txt_acfaa_reg_status_2.Name = "_txt_acfaa_reg_status_2";
			_txt_acfaa_reg_status_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_reg_status_2.Size = new System.Drawing.Size(137, 19);
			_txt_acfaa_reg_status_2.TabIndex = 176;
			// 
			// _txt_acfaa_reg_no_2
			// 
			_txt_acfaa_reg_no_2.AcceptsReturn = true;
			_txt_acfaa_reg_no_2.AllowDrop = true;
			_txt_acfaa_reg_no_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_reg_no_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_reg_no_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_reg_no_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_reg_no_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_reg_no_2.Location = new System.Drawing.Point(538, 128);
			_txt_acfaa_reg_no_2.MaxLength = 12;
			_txt_acfaa_reg_no_2.Name = "_txt_acfaa_reg_no_2";
			_txt_acfaa_reg_no_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_reg_no_2.Size = new System.Drawing.Size(137, 19);
			_txt_acfaa_reg_no_2.TabIndex = 175;
			// 
			// _txt_acfaa_reg_status_1
			// 
			_txt_acfaa_reg_status_1.AcceptsReturn = true;
			_txt_acfaa_reg_status_1.AllowDrop = true;
			_txt_acfaa_reg_status_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_reg_status_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_reg_status_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_reg_status_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_reg_status_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_reg_status_1.Location = new System.Drawing.Point(722, 104);
			_txt_acfaa_reg_status_1.MaxLength = 22;
			_txt_acfaa_reg_status_1.Name = "_txt_acfaa_reg_status_1";
			_txt_acfaa_reg_status_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_reg_status_1.Size = new System.Drawing.Size(137, 19);
			_txt_acfaa_reg_status_1.TabIndex = 174;
			// 
			// _txt_acfaa_reg_no_1
			// 
			_txt_acfaa_reg_no_1.AcceptsReturn = true;
			_txt_acfaa_reg_no_1.AllowDrop = true;
			_txt_acfaa_reg_no_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_reg_no_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_reg_no_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_reg_no_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_reg_no_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_reg_no_1.Location = new System.Drawing.Point(538, 104);
			_txt_acfaa_reg_no_1.MaxLength = 12;
			_txt_acfaa_reg_no_1.Name = "_txt_acfaa_reg_no_1";
			_txt_acfaa_reg_no_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_reg_no_1.Size = new System.Drawing.Size(137, 19);
			_txt_acfaa_reg_no_1.TabIndex = 173;
			// 
			// _txt_acfaa_reg_status_0
			// 
			_txt_acfaa_reg_status_0.AcceptsReturn = true;
			_txt_acfaa_reg_status_0.AllowDrop = true;
			_txt_acfaa_reg_status_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_reg_status_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_reg_status_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_reg_status_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_reg_status_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_reg_status_0.Location = new System.Drawing.Point(842, 384);
			_txt_acfaa_reg_status_0.MaxLength = 22;
			_txt_acfaa_reg_status_0.Name = "_txt_acfaa_reg_status_0";
			_txt_acfaa_reg_status_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_reg_status_0.Size = new System.Drawing.Size(137, 19);
			_txt_acfaa_reg_status_0.TabIndex = 172;
			// 
			// _txt_acfaa_reg_no_0
			// 
			_txt_acfaa_reg_no_0.AcceptsReturn = true;
			_txt_acfaa_reg_no_0.AllowDrop = true;
			_txt_acfaa_reg_no_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_reg_no_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_reg_no_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_reg_no_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_reg_no_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_reg_no_0.Location = new System.Drawing.Point(658, 384);
			_txt_acfaa_reg_no_0.MaxLength = 12;
			_txt_acfaa_reg_no_0.Name = "_txt_acfaa_reg_no_0";
			_txt_acfaa_reg_no_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_reg_no_0.Size = new System.Drawing.Size(137, 19);
			_txt_acfaa_reg_no_0.TabIndex = 171;
			// 
			// _txt_acfaa_party_comp_name_9
			// 
			_txt_acfaa_party_comp_name_9.AcceptsReturn = true;
			_txt_acfaa_party_comp_name_9.AllowDrop = true;
			_txt_acfaa_party_comp_name_9.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_party_comp_name_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_party_comp_name_9.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_party_comp_name_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_party_comp_name_9.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_party_comp_name_9.Location = new System.Drawing.Point(204, 295);
			_txt_acfaa_party_comp_name_9.MaxLength = 50;
			_txt_acfaa_party_comp_name_9.Name = "_txt_acfaa_party_comp_name_9";
			_txt_acfaa_party_comp_name_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_party_comp_name_9.Size = new System.Drawing.Size(265, 19);
			_txt_acfaa_party_comp_name_9.TabIndex = 170;
			// 
			// _txt_acfaa_party_comp_name_8
			// 
			_txt_acfaa_party_comp_name_8.AcceptsReturn = true;
			_txt_acfaa_party_comp_name_8.AllowDrop = true;
			_txt_acfaa_party_comp_name_8.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_party_comp_name_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_party_comp_name_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_party_comp_name_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_party_comp_name_8.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_party_comp_name_8.Location = new System.Drawing.Point(204, 271);
			_txt_acfaa_party_comp_name_8.MaxLength = 50;
			_txt_acfaa_party_comp_name_8.Name = "_txt_acfaa_party_comp_name_8";
			_txt_acfaa_party_comp_name_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_party_comp_name_8.Size = new System.Drawing.Size(265, 19);
			_txt_acfaa_party_comp_name_8.TabIndex = 169;
			// 
			// _txt_acfaa_party_comp_name_7
			// 
			_txt_acfaa_party_comp_name_7.AcceptsReturn = true;
			_txt_acfaa_party_comp_name_7.AllowDrop = true;
			_txt_acfaa_party_comp_name_7.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_party_comp_name_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_party_comp_name_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_party_comp_name_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_party_comp_name_7.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_party_comp_name_7.Location = new System.Drawing.Point(204, 247);
			_txt_acfaa_party_comp_name_7.MaxLength = 50;
			_txt_acfaa_party_comp_name_7.Name = "_txt_acfaa_party_comp_name_7";
			_txt_acfaa_party_comp_name_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_party_comp_name_7.Size = new System.Drawing.Size(265, 19);
			_txt_acfaa_party_comp_name_7.TabIndex = 168;
			// 
			// _txt_acfaa_party_comp_name_6
			// 
			_txt_acfaa_party_comp_name_6.AcceptsReturn = true;
			_txt_acfaa_party_comp_name_6.AllowDrop = true;
			_txt_acfaa_party_comp_name_6.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_party_comp_name_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_party_comp_name_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_party_comp_name_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_party_comp_name_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_party_comp_name_6.Location = new System.Drawing.Point(204, 223);
			_txt_acfaa_party_comp_name_6.MaxLength = 50;
			_txt_acfaa_party_comp_name_6.Name = "_txt_acfaa_party_comp_name_6";
			_txt_acfaa_party_comp_name_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_party_comp_name_6.Size = new System.Drawing.Size(265, 19);
			_txt_acfaa_party_comp_name_6.TabIndex = 167;
			// 
			// _txt_acfaa_party_comp_name_5
			// 
			_txt_acfaa_party_comp_name_5.AcceptsReturn = true;
			_txt_acfaa_party_comp_name_5.AllowDrop = true;
			_txt_acfaa_party_comp_name_5.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_party_comp_name_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_party_comp_name_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_party_comp_name_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_party_comp_name_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_party_comp_name_5.Location = new System.Drawing.Point(204, 199);
			_txt_acfaa_party_comp_name_5.MaxLength = 50;
			_txt_acfaa_party_comp_name_5.Name = "_txt_acfaa_party_comp_name_5";
			_txt_acfaa_party_comp_name_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_party_comp_name_5.Size = new System.Drawing.Size(265, 19);
			_txt_acfaa_party_comp_name_5.TabIndex = 166;
			// 
			// _txt_acfaa_party_comp_name_4
			// 
			_txt_acfaa_party_comp_name_4.AcceptsReturn = true;
			_txt_acfaa_party_comp_name_4.AllowDrop = true;
			_txt_acfaa_party_comp_name_4.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_party_comp_name_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_party_comp_name_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_party_comp_name_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_party_comp_name_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_party_comp_name_4.Location = new System.Drawing.Point(204, 175);
			_txt_acfaa_party_comp_name_4.MaxLength = 50;
			_txt_acfaa_party_comp_name_4.Name = "_txt_acfaa_party_comp_name_4";
			_txt_acfaa_party_comp_name_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_party_comp_name_4.Size = new System.Drawing.Size(265, 19);
			_txt_acfaa_party_comp_name_4.TabIndex = 165;
			// 
			// _txt_acfaa_party_comp_name_3
			// 
			_txt_acfaa_party_comp_name_3.AcceptsReturn = true;
			_txt_acfaa_party_comp_name_3.AllowDrop = true;
			_txt_acfaa_party_comp_name_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_party_comp_name_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_party_comp_name_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_party_comp_name_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_party_comp_name_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_party_comp_name_3.Location = new System.Drawing.Point(204, 151);
			_txt_acfaa_party_comp_name_3.MaxLength = 50;
			_txt_acfaa_party_comp_name_3.Name = "_txt_acfaa_party_comp_name_3";
			_txt_acfaa_party_comp_name_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_party_comp_name_3.Size = new System.Drawing.Size(265, 19);
			_txt_acfaa_party_comp_name_3.TabIndex = 164;
			// 
			// _txt_acfaa_party_comp_name_2
			// 
			_txt_acfaa_party_comp_name_2.AcceptsReturn = true;
			_txt_acfaa_party_comp_name_2.AllowDrop = true;
			_txt_acfaa_party_comp_name_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_party_comp_name_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_party_comp_name_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_party_comp_name_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_party_comp_name_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_party_comp_name_2.Location = new System.Drawing.Point(204, 127);
			_txt_acfaa_party_comp_name_2.MaxLength = 50;
			_txt_acfaa_party_comp_name_2.Name = "_txt_acfaa_party_comp_name_2";
			_txt_acfaa_party_comp_name_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_party_comp_name_2.Size = new System.Drawing.Size(265, 19);
			_txt_acfaa_party_comp_name_2.TabIndex = 163;
			// 
			// _txt_acfaa_party_comp_name_1
			// 
			_txt_acfaa_party_comp_name_1.AcceptsReturn = true;
			_txt_acfaa_party_comp_name_1.AllowDrop = true;
			_txt_acfaa_party_comp_name_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_party_comp_name_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_party_comp_name_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_party_comp_name_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_party_comp_name_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_party_comp_name_1.Location = new System.Drawing.Point(204, 103);
			_txt_acfaa_party_comp_name_1.MaxLength = 50;
			_txt_acfaa_party_comp_name_1.Name = "_txt_acfaa_party_comp_name_1";
			_txt_acfaa_party_comp_name_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_party_comp_name_1.Size = new System.Drawing.Size(265, 19);
			_txt_acfaa_party_comp_name_1.TabIndex = 162;
			// 
			// _txt_acfaa_party_comp_name_0
			// 
			_txt_acfaa_party_comp_name_0.AcceptsReturn = true;
			_txt_acfaa_party_comp_name_0.AllowDrop = true;
			_txt_acfaa_party_comp_name_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_acfaa_party_comp_name_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_acfaa_party_comp_name_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_acfaa_party_comp_name_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_acfaa_party_comp_name_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_acfaa_party_comp_name_0.Location = new System.Drawing.Point(324, 383);
			_txt_acfaa_party_comp_name_0.MaxLength = 50;
			_txt_acfaa_party_comp_name_0.Name = "_txt_acfaa_party_comp_name_0";
			_txt_acfaa_party_comp_name_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_acfaa_party_comp_name_0.Size = new System.Drawing.Size(265, 19);
			_txt_acfaa_party_comp_name_0.TabIndex = 160;
			// 
			// _grd_pubs_1
			// 
			_grd_pubs_1.AllowDrop = true;
			_grd_pubs_1.AllowUserToAddRows = false;
			_grd_pubs_1.AllowUserToDeleteRows = false;
			_grd_pubs_1.AllowUserToResizeColumns = false;
			_grd_pubs_1.AllowUserToResizeRows = false;
			_grd_pubs_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			_grd_pubs_1.ColumnsCount = 2;
			_grd_pubs_1.FixedColumns = 1;
			_grd_pubs_1.FixedRows = 1;
			_grd_pubs_1.Location = new System.Drawing.Point(0, 20);
			_grd_pubs_1.Name = "_grd_pubs_1";
			_grd_pubs_1.ReadOnly = true;
			_grd_pubs_1.RowsCount = 2;
			_grd_pubs_1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			_grd_pubs_1.ShowCellToolTips = false;
			_grd_pubs_1.Size = new System.Drawing.Size(971, 317);
			_grd_pubs_1.StandardTab = true;
			_grd_pubs_1.TabIndex = 448;
			_grd_pubs_1.Click += new System.EventHandler(grd_pubs_Click);
			_grd_pubs_1.DoubleClick += new System.EventHandler(grd_pubs_DoubleClick);
			// 
			// _tab_aircraft_details_TabPage10
			// 
			_tab_aircraft_details_TabPage10.Controls.Add(_cmdSaveDocNotes_4);
			_tab_aircraft_details_TabPage10.Controls.Add(_cbo_drop_array_1);
			_tab_aircraft_details_TabPage10.Controls.Add(web_Browser);
			_tab_aircraft_details_TabPage10.Controls.Add(_txtDocNotes_0);
			_tab_aircraft_details_TabPage10.Controls.Add(_txtDocNotes_3);
			_tab_aircraft_details_TabPage10.Controls.Add(grd_DocumentLog);
			_tab_aircraft_details_TabPage10.Controls.Add(_cmdSaveDocNotes_3);
			_tab_aircraft_details_TabPage10.Controls.Add(_txtDocNotes_2);
			_tab_aircraft_details_TabPage10.Controls.Add(_cmdSaveDocNotes_2);
			_tab_aircraft_details_TabPage10.Controls.Add(cmd_DocsInProcessRefresh);
			_tab_aircraft_details_TabPage10.Controls.Add(cmdViewDocumentInSeparateWindow);
			_tab_aircraft_details_TabPage10.Controls.Add(_cmdSaveDocNotes_0);
			_tab_aircraft_details_TabPage10.Controls.Add(_cboAcctRep_0);
			_tab_aircraft_details_TabPage10.Controls.Add(pnl_TransactionNotes);
			_tab_aircraft_details_TabPage10.Controls.Add(_lbl_gen_124);
			_tab_aircraft_details_TabPage10.Controls.Add(_lbl_gen_122);
			_tab_aircraft_details_TabPage10.Controls.Add(_lbl_gen_94);
			_tab_aircraft_details_TabPage10.Controls.Add(_lbl_gen_93);
			_tab_aircraft_details_TabPage10.Controls.Add(_lbl_gen_63);
			_tab_aircraft_details_TabPage10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage10.Text = "Transaction Notes";
			// 
			// _cmdSaveDocNotes_4
			// 
			_cmdSaveDocNotes_4.AllowDrop = true;
			_cmdSaveDocNotes_4.BackColor = System.Drawing.SystemColors.Control;
			_cmdSaveDocNotes_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSaveDocNotes_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSaveDocNotes_4.Location = new System.Drawing.Point(160, 377);
			_cmdSaveDocNotes_4.Name = "_cmdSaveDocNotes_4";
			_cmdSaveDocNotes_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSaveDocNotes_4.Size = new System.Drawing.Size(41, 21);
			_cmdSaveDocNotes_4.TabIndex = 450;
			_cmdSaveDocNotes_4.Text = "Save";
			_cmdSaveDocNotes_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSaveDocNotes_4.UseVisualStyleBackColor = false;
			_cmdSaveDocNotes_4.Visible = false;
			_cmdSaveDocNotes_4.Click += new System.EventHandler(cmdSaveDocNotes_Click);
			// 
			// _cbo_drop_array_1
			// 
			_cbo_drop_array_1.AllowDrop = true;
			_cbo_drop_array_1.BackColor = System.Drawing.SystemColors.Window;
			_cbo_drop_array_1.CausesValidation = true;
			_cbo_drop_array_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_drop_array_1.Enabled = true;
			_cbo_drop_array_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_drop_array_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_drop_array_1.IntegralHeight = true;
			_cbo_drop_array_1.Location = new System.Drawing.Point(8, 377);
			_cbo_drop_array_1.Name = "_cbo_drop_array_1";
			_cbo_drop_array_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_drop_array_1.Size = new System.Drawing.Size(145, 21);
			_cbo_drop_array_1.Sorted = false;
			_cbo_drop_array_1.TabIndex = 449;
			_cbo_drop_array_1.TabStop = true;
			_cbo_drop_array_1.Visible = true;
			_cbo_drop_array_1.SelectionChangeCommitted += new System.EventHandler(cbo_drop_array_SelectionChangeCommitted);
			// 
			// web_Browser
			// 
			web_Browser.AllowWebBrowserDrop = true;
			web_Browser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			web_Browser.Location = new System.Drawing.Point(8, 108);
			web_Browser.Name = "web_Browser";
			web_Browser.Size = new System.Drawing.Size(985, 260);
			web_Browser.TabIndex = 319;
			web_Browser.Visible = false;
			// 
			// _txtDocNotes_0
			// 
			_txtDocNotes_0.AcceptsReturn = true;
			_txtDocNotes_0.AllowDrop = true;
			_txtDocNotes_0.BackColor = System.Drawing.SystemColors.Window;
			_txtDocNotes_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txtDocNotes_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtDocNotes_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtDocNotes_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtDocNotes_0.Location = new System.Drawing.Point(204, 388);
			_txtDocNotes_0.MaxLength = 350;
			_txtDocNotes_0.Multiline = true;
			_txtDocNotes_0.Name = "_txtDocNotes_0";
			_txtDocNotes_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtDocNotes_0.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			_txtDocNotes_0.Size = new System.Drawing.Size(509, 45);
			_txtDocNotes_0.TabIndex = 298;
			// 
			// _txtDocNotes_3
			// 
			_txtDocNotes_3.AcceptsReturn = true;
			_txtDocNotes_3.AllowDrop = true;
			_txtDocNotes_3.BackColor = System.Drawing.SystemColors.Window;
			_txtDocNotes_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txtDocNotes_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtDocNotes_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtDocNotes_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtDocNotes_3.Location = new System.Drawing.Point(204, 436);
			_txtDocNotes_3.MaxLength = 109;
			_txtDocNotes_3.Multiline = true;
			_txtDocNotes_3.Name = "_txtDocNotes_3";
			_txtDocNotes_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtDocNotes_3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			_txtDocNotes_3.Size = new System.Drawing.Size(509, 29);
			_txtDocNotes_3.TabIndex = 327;
			_txtDocNotes_3.Visible = false;
			// 
			// grd_DocumentLog
			// 
			grd_DocumentLog.AllowDrop = true;
			grd_DocumentLog.AllowUserToAddRows = false;
			grd_DocumentLog.AllowUserToDeleteRows = false;
			grd_DocumentLog.AllowUserToResizeColumns = false;
			grd_DocumentLog.AllowUserToResizeColumns = grd_DocumentLog.ColumnHeadersVisible;
			grd_DocumentLog.AllowUserToResizeRows = false;
			grd_DocumentLog.AllowUserToResizeRows = grd_DocumentLog.RowHeadersVisible;
			grd_DocumentLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_DocumentLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_DocumentLog.ColumnsCount = 2;
			grd_DocumentLog.FixedColumns = 0;
			grd_DocumentLog.FixedRows = 1;
			grd_DocumentLog.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grd_DocumentLog.Location = new System.Drawing.Point(8, 4);
			grd_DocumentLog.Name = "grd_DocumentLog";
			grd_DocumentLog.ReadOnly = true;
			grd_DocumentLog.RowsCount = 2;
			grd_DocumentLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_DocumentLog.ShowCellToolTips = false;
			grd_DocumentLog.Size = new System.Drawing.Size(980, 105);
			grd_DocumentLog.StandardTab = true;
			grd_DocumentLog.TabIndex = 326;
			grd_DocumentLog.Visible = false;
			grd_DocumentLog.Click += new System.EventHandler(grd_DocumentLog_Click);
			// 
			// _cmdSaveDocNotes_3
			// 
			_cmdSaveDocNotes_3.AllowDrop = true;
			_cmdSaveDocNotes_3.BackColor = System.Drawing.SystemColors.Control;
			_cmdSaveDocNotes_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSaveDocNotes_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSaveDocNotes_3.Location = new System.Drawing.Point(798, 438);
			_cmdSaveDocNotes_3.Name = "_cmdSaveDocNotes_3";
			_cmdSaveDocNotes_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSaveDocNotes_3.Size = new System.Drawing.Size(98, 25);
			_cmdSaveDocNotes_3.TabIndex = 323;
			_cmdSaveDocNotes_3.Text = "Delete Document";
			_cmdSaveDocNotes_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSaveDocNotes_3.UseVisualStyleBackColor = false;
			_cmdSaveDocNotes_3.Visible = false;
			_cmdSaveDocNotes_3.Click += new System.EventHandler(cmdSaveDocNotes_Click);
			// 
			// _txtDocNotes_2
			// 
			_txtDocNotes_2.AcceptsReturn = true;
			_txtDocNotes_2.AllowDrop = true;
			_txtDocNotes_2.BackColor = System.Drawing.SystemColors.Window;
			_txtDocNotes_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txtDocNotes_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtDocNotes_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtDocNotes_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtDocNotes_2.Location = new System.Drawing.Point(800, 400);
			_txtDocNotes_2.MaxLength = 0;
			_txtDocNotes_2.Name = "_txtDocNotes_2";
			_txtDocNotes_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtDocNotes_2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			_txtDocNotes_2.Size = new System.Drawing.Size(79, 21);
			_txtDocNotes_2.TabIndex = 321;
			_txtDocNotes_2.Visible = false;
			// 
			// _cmdSaveDocNotes_2
			// 
			_cmdSaveDocNotes_2.AllowDrop = true;
			_cmdSaveDocNotes_2.BackColor = System.Drawing.SystemColors.Control;
			_cmdSaveDocNotes_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSaveDocNotes_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSaveDocNotes_2.Location = new System.Drawing.Point(881, 398);
			_cmdSaveDocNotes_2.Name = "_cmdSaveDocNotes_2";
			_cmdSaveDocNotes_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSaveDocNotes_2.Size = new System.Drawing.Size(98, 25);
			_cmdSaveDocNotes_2.TabIndex = 320;
			_cmdSaveDocNotes_2.Text = "Move Document";
			_cmdSaveDocNotes_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSaveDocNotes_2.UseVisualStyleBackColor = false;
			_cmdSaveDocNotes_2.Visible = false;
			_cmdSaveDocNotes_2.Click += new System.EventHandler(cmdSaveDocNotes_Click);
			// 
			// cmd_DocsInProcessRefresh
			// 
			cmd_DocsInProcessRefresh.AllowDrop = true;
			cmd_DocsInProcessRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmd_DocsInProcessRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_DocsInProcessRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_DocsInProcessRefresh.Location = new System.Drawing.Point(48, 400);
			cmd_DocsInProcessRefresh.Name = "cmd_DocsInProcessRefresh";
			cmd_DocsInProcessRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_DocsInProcessRefresh.Size = new System.Drawing.Size(53, 20);
			cmd_DocsInProcessRefresh.TabIndex = 305;
			cmd_DocsInProcessRefresh.Text = "Refresh";
			cmd_DocsInProcessRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_DocsInProcessRefresh.UseVisualStyleBackColor = false;
			cmd_DocsInProcessRefresh.Visible = false;
			cmd_DocsInProcessRefresh.Click += new System.EventHandler(cmd_DocsInProcessRefresh_Click);
			// 
			// cmdViewDocumentInSeparateWindow
			// 
			cmdViewDocumentInSeparateWindow.AllowDrop = true;
			cmdViewDocumentInSeparateWindow.BackColor = System.Drawing.SystemColors.Control;
			cmdViewDocumentInSeparateWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdViewDocumentInSeparateWindow.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdViewDocumentInSeparateWindow.Location = new System.Drawing.Point(901, 438);
			cmdViewDocumentInSeparateWindow.Name = "cmdViewDocumentInSeparateWindow";
			cmdViewDocumentInSeparateWindow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdViewDocumentInSeparateWindow.Size = new System.Drawing.Size(97, 25);
			cmdViewDocumentInSeparateWindow.TabIndex = 301;
			cmdViewDocumentInSeparateWindow.Text = "Open Document";
			cmdViewDocumentInSeparateWindow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdViewDocumentInSeparateWindow.UseVisualStyleBackColor = false;
			cmdViewDocumentInSeparateWindow.Visible = false;
			cmdViewDocumentInSeparateWindow.Click += new System.EventHandler(cmdViewDocumentInSeparateWindow_Click);
			// 
			// _cmdSaveDocNotes_0
			// 
			_cmdSaveDocNotes_0.AllowDrop = true;
			_cmdSaveDocNotes_0.BackColor = System.Drawing.SystemColors.Control;
			_cmdSaveDocNotes_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSaveDocNotes_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSaveDocNotes_0.Location = new System.Drawing.Point(720, 438);
			_cmdSaveDocNotes_0.Name = "_cmdSaveDocNotes_0";
			_cmdSaveDocNotes_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSaveDocNotes_0.Size = new System.Drawing.Size(55, 25);
			_cmdSaveDocNotes_0.TabIndex = 300;
			_cmdSaveDocNotes_0.Text = "&Save";
			_cmdSaveDocNotes_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSaveDocNotes_0.UseVisualStyleBackColor = false;
			_cmdSaveDocNotes_0.Visible = false;
			_cmdSaveDocNotes_0.Click += new System.EventHandler(cmdSaveDocNotes_Click);
			// 
			// _cboAcctRep_0
			// 
			_cboAcctRep_0.AllowDrop = true;
			_cboAcctRep_0.BackColor = System.Drawing.SystemColors.Window;
			_cboAcctRep_0.CausesValidation = true;
			_cboAcctRep_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cboAcctRep_0.Enabled = true;
			_cboAcctRep_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboAcctRep_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboAcctRep_0.IntegralHeight = true;
			_cboAcctRep_0.Location = new System.Drawing.Point(31, 440);
			_cboAcctRep_0.Name = "_cboAcctRep_0";
			_cboAcctRep_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboAcctRep_0.Size = new System.Drawing.Size(81, 21);
			_cboAcctRep_0.Sorted = false;
			_cboAcctRep_0.TabIndex = 299;
			_cboAcctRep_0.TabStop = true;
			_cboAcctRep_0.Visible = false;
			// 
			// pnl_TransactionNotes
			// 
			pnl_TransactionNotes.AllowDrop = true;
			pnl_TransactionNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_TransactionNotes.Controls.Add(txt_customer_notes);
			pnl_TransactionNotes.Controls.Add(txt_internal_notes);
			pnl_TransactionNotes.Controls.Add(cmdFinancialDocuments);
			pnl_TransactionNotes.Controls.Add(grdTransactionDocuments);
			pnl_TransactionNotes.Controls.Add(_lbl_gen_81);
			pnl_TransactionNotes.Controls.Add(_lbl_gen_80);
			pnl_TransactionNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_TransactionNotes.Location = new System.Drawing.Point(160, 26);
			pnl_TransactionNotes.Name = "pnl_TransactionNotes";
			pnl_TransactionNotes.Size = new System.Drawing.Size(707, 432);
			pnl_TransactionNotes.TabIndex = 291;
			pnl_TransactionNotes.Visible = false;
			// 
			// txt_customer_notes
			// 
			txt_customer_notes.AcceptsReturn = true;
			txt_customer_notes.AllowDrop = true;
			txt_customer_notes.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_customer_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_customer_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_customer_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_customer_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_customer_notes.Location = new System.Drawing.Point(46, 204);
			txt_customer_notes.MaxLength = 0;
			txt_customer_notes.Multiline = true;
			txt_customer_notes.Name = "txt_customer_notes";
			txt_customer_notes.ReadOnly = true;
			txt_customer_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_customer_notes.Size = new System.Drawing.Size(357, 161);
			txt_customer_notes.TabIndex = 294;
			txt_customer_notes.MouseDown += new System.Windows.Forms.MouseEventHandler(txt_customer_notes_MouseDown);
			// 
			// txt_internal_notes
			// 
			txt_internal_notes.AcceptsReturn = true;
			txt_internal_notes.AllowDrop = true;
			txt_internal_notes.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_internal_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_internal_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_internal_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_internal_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_internal_notes.Location = new System.Drawing.Point(46, 25);
			txt_internal_notes.MaxLength = 0;
			txt_internal_notes.Multiline = true;
			txt_internal_notes.Name = "txt_internal_notes";
			txt_internal_notes.ReadOnly = true;
			txt_internal_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_internal_notes.Size = new System.Drawing.Size(357, 161);
			txt_internal_notes.TabIndex = 293;
			// 
			// cmdFinancialDocuments
			// 
			cmdFinancialDocuments.AllowDrop = true;
			cmdFinancialDocuments.BackColor = System.Drawing.SystemColors.Control;
			cmdFinancialDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFinancialDocuments.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFinancialDocuments.Location = new System.Drawing.Point(264, 382);
			cmdFinancialDocuments.Name = "cmdFinancialDocuments";
			cmdFinancialDocuments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFinancialDocuments.Size = new System.Drawing.Size(153, 25);
			cmdFinancialDocuments.TabIndex = 292;
			cmdFinancialDocuments.Text = "Transaction Documents";
			cmdFinancialDocuments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFinancialDocuments.UseVisualStyleBackColor = false;
			cmdFinancialDocuments.Click += new System.EventHandler(cmdFinancialDocuments_Click);
			// 
			// grdTransactionDocuments
			// 
			grdTransactionDocuments.AllowDrop = true;
			grdTransactionDocuments.AllowUserToAddRows = false;
			grdTransactionDocuments.AllowUserToDeleteRows = false;
			grdTransactionDocuments.AllowUserToResizeColumns = false;
			grdTransactionDocuments.AllowUserToResizeColumns = grdTransactionDocuments.ColumnHeadersVisible;
			grdTransactionDocuments.AllowUserToResizeRows = false;
			grdTransactionDocuments.AllowUserToResizeRows = grdTransactionDocuments.RowHeadersVisible;
			grdTransactionDocuments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdTransactionDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdTransactionDocuments.ColumnsCount = 2;
			grdTransactionDocuments.FixedColumns = 0;
			grdTransactionDocuments.FixedRows = 1;
			grdTransactionDocuments.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grdTransactionDocuments.Location = new System.Drawing.Point(448, 23);
			grdTransactionDocuments.Name = "grdTransactionDocuments";
			grdTransactionDocuments.ReadOnly = true;
			grdTransactionDocuments.RowsCount = 2;
			grdTransactionDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grdTransactionDocuments.ShowCellToolTips = false;
			grdTransactionDocuments.Size = new System.Drawing.Size(231, 342);
			grdTransactionDocuments.StandardTab = true;
			grdTransactionDocuments.TabIndex = 295;
			grdTransactionDocuments.Visible = false;
			grdTransactionDocuments.DoubleClick += new System.EventHandler(grdTransactionDocuments_DoubleClick);
			// 
			// _lbl_gen_81
			// 
			_lbl_gen_81.AllowDrop = true;
			_lbl_gen_81.AutoSize = true;
			_lbl_gen_81.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_81.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_81.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_81.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_81.Location = new System.Drawing.Point(46, 188);
			_lbl_gen_81.MinimumSize = new System.Drawing.Size(75, 13);
			_lbl_gen_81.Name = "_lbl_gen_81";
			_lbl_gen_81.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_81.Size = new System.Drawing.Size(75, 13);
			_lbl_gen_81.TabIndex = 297;
			_lbl_gen_81.Text = "Customer Notes";
			_lbl_gen_81.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_81.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_80
			// 
			_lbl_gen_80.AllowDrop = true;
			_lbl_gen_80.AutoSize = true;
			_lbl_gen_80.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_80.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_80.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_80.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_80.Location = new System.Drawing.Point(46, 9);
			_lbl_gen_80.MinimumSize = new System.Drawing.Size(66, 13);
			_lbl_gen_80.Name = "_lbl_gen_80";
			_lbl_gen_80.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_80.Size = new System.Drawing.Size(66, 13);
			_lbl_gen_80.TabIndex = 296;
			_lbl_gen_80.Text = "Internal Notes";
			_lbl_gen_80.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_80.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_124
			// 
			_lbl_gen_124.AllowDrop = true;
			_lbl_gen_124.AutoSize = true;
			_lbl_gen_124.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_124.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_124.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_124.ForeColor = System.Drawing.Color.Blue;
			_lbl_gen_124.Location = new System.Drawing.Point(19, 420);
			_lbl_gen_124.MinimumSize = new System.Drawing.Size(119, 13);
			_lbl_gen_124.Name = "_lbl_gen_124";
			_lbl_gen_124.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_124.Size = new System.Drawing.Size(119, 13);
			_lbl_gen_124.TabIndex = 429;
			_lbl_gen_124.Text = "Attach Doc To Company";
			_lbl_gen_124.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_124.Visible = false;
			_lbl_gen_124.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_124.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_122
			// 
			_lbl_gen_122.AllowDrop = true;
			_lbl_gen_122.AutoSize = true;
			_lbl_gen_122.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_122.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_122.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_122.ForeColor = System.Drawing.Color.Blue;
			_lbl_gen_122.Location = new System.Drawing.Point(909, 424);
			_lbl_gen_122.MinimumSize = new System.Drawing.Size(81, 13);
			_lbl_gen_122.Name = "_lbl_gen_122";
			_lbl_gen_122.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_122.Size = new System.Drawing.Size(81, 13);
			_lbl_gen_122.TabIndex = 411;
			_lbl_gen_122.Text = "Open In Browser";
			_lbl_gen_122.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_122.Visible = false;
			_lbl_gen_122.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_122.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_94
			// 
			_lbl_gen_94.AllowDrop = true;
			_lbl_gen_94.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_94.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_94.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_94.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_94.Location = new System.Drawing.Point(120, 400);
			_lbl_gen_94.MinimumSize = new System.Drawing.Size(74, 19);
			_lbl_gen_94.Name = "_lbl_gen_94";
			_lbl_gen_94.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_94.Size = new System.Drawing.Size(74, 19);
			_lbl_gen_94.TabIndex = 394;
			_lbl_gen_94.Text = "Current Note:";
			_lbl_gen_94.Visible = false;
			_lbl_gen_94.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_94.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_93
			// 
			_lbl_gen_93.AllowDrop = true;
			_lbl_gen_93.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_93.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_93.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_93.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_93.Location = new System.Drawing.Point(120, 441);
			_lbl_gen_93.MinimumSize = new System.Drawing.Size(74, 19);
			_lbl_gen_93.Name = "_lbl_gen_93";
			_lbl_gen_93.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_93.Size = new System.Drawing.Size(74, 19);
			_lbl_gen_93.TabIndex = 328;
			_lbl_gen_93.Text = "Add Response:";
			_lbl_gen_93.Visible = false;
			_lbl_gen_93.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_93.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_63
			// 
			_lbl_gen_63.AllowDrop = true;
			_lbl_gen_63.AutoSize = true;
			_lbl_gen_63.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_63.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_63.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_63.Location = new System.Drawing.Point(721, 405);
			_lbl_gen_63.MinimumSize = new System.Drawing.Size(72, 13);
			_lbl_gen_63.Name = "_lbl_gen_63";
			_lbl_gen_63.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_63.Size = new System.Drawing.Size(72, 13);
			_lbl_gen_63.TabIndex = 322;
			_lbl_gen_63.Text = "New Aircraft ID";
			_lbl_gen_63.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_63.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _tab_aircraft_details_TabPage11
			// 
			_tab_aircraft_details_TabPage11.Controls.Add(_txtDocNotes_1);
			_tab_aircraft_details_TabPage11.Controls.Add(_cboAcctRep_1);
			_tab_aircraft_details_TabPage11.Controls.Add(grdAircraftDocuments);
			_tab_aircraft_details_TabPage11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage11.Text = "Aircraft Docs";
			// 
			// _txtDocNotes_1
			// 
			_txtDocNotes_1.AcceptsReturn = true;
			_txtDocNotes_1.AllowDrop = true;
			_txtDocNotes_1.BackColor = System.Drawing.SystemColors.Window;
			_txtDocNotes_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txtDocNotes_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtDocNotes_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtDocNotes_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtDocNotes_1.Location = new System.Drawing.Point(99, 427);
			_txtDocNotes_1.MaxLength = 350;
			_txtDocNotes_1.Multiline = true;
			_txtDocNotes_1.Name = "_txtDocNotes_1";
			_txtDocNotes_1.ReadOnly = true;
			_txtDocNotes_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtDocNotes_1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			_txtDocNotes_1.Size = new System.Drawing.Size(689, 37);
			_txtDocNotes_1.TabIndex = 318;
			// 
			// _cboAcctRep_1
			// 
			_cboAcctRep_1.AllowDrop = true;
			_cboAcctRep_1.BackColor = System.Drawing.SystemColors.Window;
			_cboAcctRep_1.CausesValidation = true;
			_cboAcctRep_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cboAcctRep_1.Enabled = true;
			_cboAcctRep_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboAcctRep_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboAcctRep_1.IntegralHeight = true;
			_cboAcctRep_1.Location = new System.Drawing.Point(8, 435);
			_cboAcctRep_1.Name = "_cboAcctRep_1";
			_cboAcctRep_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboAcctRep_1.Size = new System.Drawing.Size(86, 21);
			_cboAcctRep_1.Sorted = false;
			_cboAcctRep_1.TabIndex = 317;
			_cboAcctRep_1.TabStop = true;
			_cboAcctRep_1.Visible = true;
			// 
			// grdAircraftDocuments
			// 
			grdAircraftDocuments.AllowDrop = true;
			grdAircraftDocuments.AllowUserToAddRows = false;
			grdAircraftDocuments.AllowUserToDeleteRows = false;
			grdAircraftDocuments.AllowUserToResizeColumns = false;
			grdAircraftDocuments.AllowUserToResizeColumns = grdAircraftDocuments.ColumnHeadersVisible;
			grdAircraftDocuments.AllowUserToResizeRows = false;
			grdAircraftDocuments.AllowUserToResizeRows = grdAircraftDocuments.RowHeadersVisible;
			grdAircraftDocuments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdAircraftDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdAircraftDocuments.ColumnsCount = 2;
			grdAircraftDocuments.FixedColumns = 0;
			grdAircraftDocuments.FixedRows = 1;
			grdAircraftDocuments.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grdAircraftDocuments.Location = new System.Drawing.Point(0, 28);
			grdAircraftDocuments.Name = "grdAircraftDocuments";
			grdAircraftDocuments.ReadOnly = true;
			grdAircraftDocuments.RowsCount = 2;
			grdAircraftDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdAircraftDocuments.ShowCellToolTips = false;
			grdAircraftDocuments.Size = new System.Drawing.Size(985, 393);
			grdAircraftDocuments.StandardTab = true;
			grdAircraftDocuments.TabIndex = 306;
			grdAircraftDocuments.Click += new System.EventHandler(grdAircraftDocuments_Click);
			grdAircraftDocuments.DoubleClick += new System.EventHandler(grdAircraftDocuments_DoubleClick);
			// 
			// _tab_aircraft_details_TabPage12
			// 
			_tab_aircraft_details_TabPage12.Controls.Add(web_Ac1);
			_tab_aircraft_details_TabPage12.Controls.Add(_cmdSaveDocNotes_6);
			_tab_aircraft_details_TabPage12.Controls.Add(_cmdSaveDocNotes_5);
			_tab_aircraft_details_TabPage12.Controls.Add(_cmdSaveDocNotes_1);
			_tab_aircraft_details_TabPage12.Controls.Add(lstAcPictures);
			_tab_aircraft_details_TabPage12.Controls.Add(_lbl_gen_88);
			_tab_aircraft_details_TabPage12.Controls.Add(imgACPicture);
			_tab_aircraft_details_TabPage12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage12.Text = "Pictures";
			// 
			// web_Ac1
			// 
			web_Ac1.AllowWebBrowserDrop = true;
			web_Ac1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			web_Ac1.Location = new System.Drawing.Point(8, 372);
			web_Ac1.Name = "web_Ac1";
			web_Ac1.Size = new System.Drawing.Size(121, 73);
			web_Ac1.TabIndex = 455;
			web_Ac1.Visible = false;
			// 
			// _cmdSaveDocNotes_6
			// 
			_cmdSaveDocNotes_6.AllowDrop = true;
			_cmdSaveDocNotes_6.BackColor = System.Drawing.SystemColors.Control;
			_cmdSaveDocNotes_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSaveDocNotes_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSaveDocNotes_6.Location = new System.Drawing.Point(16, 260);
			_cmdSaveDocNotes_6.Name = "_cmdSaveDocNotes_6";
			_cmdSaveDocNotes_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSaveDocNotes_6.Size = new System.Drawing.Size(102, 21);
			_cmdSaveDocNotes_6.TabIndex = 453;
			_cmdSaveDocNotes_6.Text = "Refresh";
			_cmdSaveDocNotes_6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSaveDocNotes_6.UseVisualStyleBackColor = false;
			_cmdSaveDocNotes_6.Click += new System.EventHandler(cmdSaveDocNotes_Click);
			// 
			// _cmdSaveDocNotes_5
			// 
			_cmdSaveDocNotes_5.AllowDrop = true;
			_cmdSaveDocNotes_5.BackColor = System.Drawing.SystemColors.Control;
			_cmdSaveDocNotes_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSaveDocNotes_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSaveDocNotes_5.Location = new System.Drawing.Point(168, 260);
			_cmdSaveDocNotes_5.Name = "_cmdSaveDocNotes_5";
			_cmdSaveDocNotes_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSaveDocNotes_5.Size = new System.Drawing.Size(102, 21);
			_cmdSaveDocNotes_5.TabIndex = 452;
			_cmdSaveDocNotes_5.Text = "&Edit Pictures";
			_cmdSaveDocNotes_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSaveDocNotes_5.UseVisualStyleBackColor = false;
			_cmdSaveDocNotes_5.Click += new System.EventHandler(cmdSaveDocNotes_Click);
			// 
			// _cmdSaveDocNotes_1
			// 
			_cmdSaveDocNotes_1.AllowDrop = true;
			_cmdSaveDocNotes_1.BackColor = System.Drawing.SystemColors.Control;
			_cmdSaveDocNotes_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSaveDocNotes_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSaveDocNotes_1.Location = new System.Drawing.Point(152, 412);
			_cmdSaveDocNotes_1.Name = "_cmdSaveDocNotes_1";
			_cmdSaveDocNotes_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSaveDocNotes_1.Size = new System.Drawing.Size(118, 21);
			_cmdSaveDocNotes_1.TabIndex = 310;
			_cmdSaveDocNotes_1.Text = "&Legacy Picture Editor";
			_cmdSaveDocNotes_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSaveDocNotes_1.UseVisualStyleBackColor = false;
			_cmdSaveDocNotes_1.Click += new System.EventHandler(cmdSaveDocNotes_Click);
			// 
			// lstAcPictures
			// 
			lstAcPictures.AllowDrop = true;
			lstAcPictures.BackColor = System.Drawing.SystemColors.Window;
			lstAcPictures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstAcPictures.CausesValidation = true;
			lstAcPictures.Enabled = true;
			lstAcPictures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstAcPictures.ForeColor = System.Drawing.SystemColors.WindowText;
			lstAcPictures.IntegralHeight = true;
			lstAcPictures.Location = new System.Drawing.Point(16, 44);
			lstAcPictures.MultiColumn = false;
			lstAcPictures.Name = "lstAcPictures";
			lstAcPictures.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstAcPictures.Size = new System.Drawing.Size(257, 213);
			lstAcPictures.Sorted = false;
			lstAcPictures.TabIndex = 308;
			lstAcPictures.TabStop = true;
			lstAcPictures.Visible = true;
			lstAcPictures.SelectedIndexChanged += new System.EventHandler(lstAcPictures_SelectedIndexChanged);
			// 
			// _lbl_gen_88
			// 
			_lbl_gen_88.AllowDrop = true;
			_lbl_gen_88.AutoSize = true;
			_lbl_gen_88.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_88.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_88.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_88.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_88.Location = new System.Drawing.Point(16, 29);
			_lbl_gen_88.MinimumSize = new System.Drawing.Size(96, 13);
			_lbl_gen_88.Name = "_lbl_gen_88";
			_lbl_gen_88.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_88.Size = new System.Drawing.Size(96, 13);
			_lbl_gen_88.TabIndex = 311;
			_lbl_gen_88.Text = "Seq - Date - Subject";
			_lbl_gen_88.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_88.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// imgACPicture
			// 
			imgACPicture.AllowDrop = true;
			imgACPicture.BorderStyle = System.Windows.Forms.BorderStyle.None;
			imgACPicture.Enabled = false;
			imgACPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			imgACPicture.Location = new System.Drawing.Point(300, 30);
			imgACPicture.Name = "imgACPicture";
			imgACPicture.Size = new System.Drawing.Size(687, 419);
			imgACPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			imgACPicture.Visible = true;
			// 
			// _tab_aircraft_details_TabPage13
			// 
			_tab_aircraft_details_TabPage13.Controls.Add(_cbo_drop_array_0);
			_tab_aircraft_details_TabPage13.Controls.Add(_grd_pubs_0);
			_tab_aircraft_details_TabPage13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage13.Text = "Tasks";
			// 
			// _cbo_drop_array_0
			// 
			_cbo_drop_array_0.AllowDrop = true;
			_cbo_drop_array_0.BackColor = System.Drawing.SystemColors.Window;
			_cbo_drop_array_0.CausesValidation = true;
			_cbo_drop_array_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_drop_array_0.Enabled = true;
			_cbo_drop_array_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_drop_array_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_drop_array_0.IntegralHeight = true;
			_cbo_drop_array_0.Location = new System.Drawing.Point(16, 28);
			_cbo_drop_array_0.Name = "_cbo_drop_array_0";
			_cbo_drop_array_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_drop_array_0.Size = new System.Drawing.Size(169, 21);
			_cbo_drop_array_0.Sorted = false;
			_cbo_drop_array_0.TabIndex = 446;
			_cbo_drop_array_0.TabStop = true;
			_cbo_drop_array_0.Visible = true;
			_cbo_drop_array_0.SelectionChangeCommitted += new System.EventHandler(cbo_drop_array_SelectionChangeCommitted);
			// 
			// _grd_pubs_0
			// 
			_grd_pubs_0.AllowDrop = true;
			_grd_pubs_0.AllowUserToAddRows = false;
			_grd_pubs_0.AllowUserToDeleteRows = false;
			_grd_pubs_0.AllowUserToResizeColumns = false;
			_grd_pubs_0.AllowUserToResizeRows = false;
			_grd_pubs_0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			_grd_pubs_0.ColumnsCount = 2;
			_grd_pubs_0.FixedColumns = 1;
			_grd_pubs_0.FixedRows = 1;
			_grd_pubs_0.Location = new System.Drawing.Point(16, 52);
			_grd_pubs_0.Name = "_grd_pubs_0";
			_grd_pubs_0.ReadOnly = true;
			_grd_pubs_0.RowsCount = 2;
			_grd_pubs_0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			_grd_pubs_0.ShowCellToolTips = false;
			_grd_pubs_0.Size = new System.Drawing.Size(971, 237);
			_grd_pubs_0.StandardTab = true;
			_grd_pubs_0.TabIndex = 430;
			_grd_pubs_0.Click += new System.EventHandler(grd_pubs_Click);
			_grd_pubs_0.DoubleClick += new System.EventHandler(grd_pubs_DoubleClick);
			// 
			// _tab_aircraft_details_TabPage14
			// 
			_tab_aircraft_details_TabPage14.Controls.Add(cbo_Feature_Options);
			_tab_aircraft_details_TabPage14.Controls.Add(txt_Kfeat_Update_Code);
			_tab_aircraft_details_TabPage14.Controls.Add(grd_AircraftKeyFeatures);
			_tab_aircraft_details_TabPage14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_aircraft_details_TabPage14.Text = "Features";
			// 
			// cbo_Feature_Options
			// 
			cbo_Feature_Options.AllowDrop = true;
			cbo_Feature_Options.BackColor = System.Drawing.SystemColors.Window;
			cbo_Feature_Options.CausesValidation = true;
			cbo_Feature_Options.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_Feature_Options.Enabled = true;
			cbo_Feature_Options.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Feature_Options.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Feature_Options.IntegralHeight = true;
			cbo_Feature_Options.Location = new System.Drawing.Point(10, 406);
			cbo_Feature_Options.Name = "cbo_Feature_Options";
			cbo_Feature_Options.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Feature_Options.Size = new System.Drawing.Size(116, 21);
			cbo_Feature_Options.Sorted = false;
			cbo_Feature_Options.TabIndex = 437;
			cbo_Feature_Options.TabStop = true;
			cbo_Feature_Options.Visible = false;
			cbo_Feature_Options.SelectionChangeCommitted += new System.EventHandler(cbo_Feature_Options_SelectionChangeCommitted);
			// 
			// txt_Kfeat_Update_Code
			// 
			txt_Kfeat_Update_Code.AcceptsReturn = true;
			txt_Kfeat_Update_Code.AllowDrop = true;
			txt_Kfeat_Update_Code.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_Kfeat_Update_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Kfeat_Update_Code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Kfeat_Update_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Kfeat_Update_Code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Kfeat_Update_Code.Location = new System.Drawing.Point(128, 408);
			txt_Kfeat_Update_Code.MaxLength = 0;
			txt_Kfeat_Update_Code.Name = "txt_Kfeat_Update_Code";
			txt_Kfeat_Update_Code.ReadOnly = true;
			txt_Kfeat_Update_Code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Kfeat_Update_Code.Size = new System.Drawing.Size(196, 21);
			txt_Kfeat_Update_Code.TabIndex = 436;
			txt_Kfeat_Update_Code.Visible = false;
			// 
			// grd_AircraftKeyFeatures
			// 
			grd_AircraftKeyFeatures.AllowDrop = true;
			grd_AircraftKeyFeatures.AllowUserToAddRows = false;
			grd_AircraftKeyFeatures.AllowUserToDeleteRows = false;
			grd_AircraftKeyFeatures.AllowUserToResizeColumns = false;
			grd_AircraftKeyFeatures.AllowUserToResizeColumns = grd_AircraftKeyFeatures.ColumnHeadersVisible;
			grd_AircraftKeyFeatures.AllowUserToResizeRows = false;
			grd_AircraftKeyFeatures.AllowUserToResizeRows = false;
			grd_AircraftKeyFeatures.BackColorFixed = System.Drawing.SystemColors.ActiveCaptionText;
			grd_AircraftKeyFeatures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_AircraftKeyFeatures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_AircraftKeyFeatures.ColumnsCount = 2;
			grd_AircraftKeyFeatures.FixedColumns = 0;
			grd_AircraftKeyFeatures.FixedRows = 1;
			grd_AircraftKeyFeatures.Location = new System.Drawing.Point(10, 20);
			grd_AircraftKeyFeatures.Name = "grd_AircraftKeyFeatures";
			grd_AircraftKeyFeatures.ReadOnly = true;
			grd_AircraftKeyFeatures.RowsCount = 2;
			grd_AircraftKeyFeatures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_AircraftKeyFeatures.ShowCellToolTips = false;
			grd_AircraftKeyFeatures.Size = new System.Drawing.Size(317, 380);
			grd_AircraftKeyFeatures.StandardTab = true;
			grd_AircraftKeyFeatures.TabIndex = 438;
			grd_AircraftKeyFeatures.Click += new System.EventHandler(grd_AircraftKeyFeatures_Click);
			// 
			// tab_ACMain
			// 
			tab_ACMain.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_ACMain.AllowDrop = true;
			tab_ACMain.Controls.Add(_tab_ACMain_TabPage0);
			tab_ACMain.Controls.Add(_tab_ACMain_TabPage1);
			tab_ACMain.Controls.Add(_tab_ACMain_TabPage2);
			tab_ACMain.Controls.Add(_tab_ACMain_TabPage3);
			tab_ACMain.Controls.Add(_tab_ACMain_TabPage4);
			tab_ACMain.Controls.Add(_tab_ACMain_TabPage5);
			tab_ACMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_ACMain.ItemSize = new System.Drawing.Size(81, 18);
			tab_ACMain.Location = new System.Drawing.Point(512, 54);
			tab_ACMain.Multiline = true;
			tab_ACMain.Name = "tab_ACMain";
			tab_ACMain.Size = new System.Drawing.Size(497, 165);
			tab_ACMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_ACMain.TabIndex = 99;
			tab_ACMain.SelectedIndexChanged += new System.EventHandler(tab_ACMain_SelectedIndexChanged);
			// 
			// ac_mapping_list
			// 
			ac_mapping_list.AllowDrop = true;
			ac_mapping_list.BackColor = System.Drawing.SystemColors.Window;
			ac_mapping_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			ac_mapping_list.CausesValidation = true;
			ac_mapping_list.Enabled = true;
			ac_mapping_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ac_mapping_list.ForeColor = System.Drawing.SystemColors.WindowText;
			ac_mapping_list.IntegralHeight = true;
			ac_mapping_list.Location = new System.Drawing.Point(-4626, 113);
			ac_mapping_list.MultiColumn = false;
			ac_mapping_list.Name = "ac_mapping_list";
			ac_mapping_list.RightToLeft = System.Windows.Forms.RightToLeft.No;
			ac_mapping_list.Size = new System.Drawing.Size(110, 44);
			ac_mapping_list.Sorted = false;
			ac_mapping_list.TabIndex = 399;
			ac_mapping_list.TabStop = true;
			ac_mapping_list.Visible = false;
			ac_mapping_list.Items.AddRange(new object[]{"L - Load AC", "D - Update AC", "N - Do Not Load"});
			ac_mapping_list.SelectedIndexChanged += new System.EventHandler(ac_mapping_list_SelectedIndexChanged);
			// 
			// ac_mapping_id
			// 
			ac_mapping_id.AcceptsReturn = true;
			ac_mapping_id.AllowDrop = true;
			ac_mapping_id.BackColor = System.Drawing.SystemColors.Window;
			ac_mapping_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			ac_mapping_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			ac_mapping_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ac_mapping_id.ForeColor = System.Drawing.SystemColors.WindowText;
			ac_mapping_id.Location = new System.Drawing.Point(-4818, 135);
			ac_mapping_id.MaxLength = 0;
			ac_mapping_id.Name = "ac_mapping_id";
			ac_mapping_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			ac_mapping_id.Size = new System.Drawing.Size(122, 19);
			ac_mapping_id.TabIndex = 398;
			ac_mapping_id.Visible = false;
			// 
			// cmd_set_mapping_flag
			// 
			cmd_set_mapping_flag.AllowDrop = true;
			cmd_set_mapping_flag.BackColor = System.Drawing.SystemColors.Control;
			cmd_set_mapping_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_set_mapping_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_set_mapping_flag.Location = new System.Drawing.Point(-4686, 113);
			cmd_set_mapping_flag.Name = "cmd_set_mapping_flag";
			cmd_set_mapping_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_set_mapping_flag.Size = new System.Drawing.Size(51, 41);
			cmd_set_mapping_flag.TabIndex = 397;
			cmd_set_mapping_flag.Text = "Set Mapping";
			cmd_set_mapping_flag.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_set_mapping_flag.UseVisualStyleBackColor = false;
			cmd_set_mapping_flag.Visible = false;
			cmd_set_mapping_flag.Click += new System.EventHandler(cmd_set_mapping_flag_Click);
			// 
			// Shape1
			// 
			Shape1.AllowDrop = true;
			Shape1.BackColor = System.Drawing.SystemColors.Window;
			Shape1.BackStyle = 0;
			Shape1.BorderStyle = 1;
			Shape1.Enabled = false;
			Shape1.FillColor = System.Drawing.Color.Black;
			Shape1.FillStyle = 1;
			Shape1.Location = new System.Drawing.Point(-4993, 27);
			Shape1.Name = "Shape1";
			Shape1.Size = new System.Drawing.Size(166, 127);
			Shape1.Visible = true;
			// 
			// _lbl_gen_110
			// 
			_lbl_gen_110.AllowDrop = true;
			_lbl_gen_110.BackColor = System.Drawing.SystemColors.Window;
			_lbl_gen_110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_gen_110.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_110.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_gen_110.Location = new System.Drawing.Point(-4822, 27);
			_lbl_gen_110.MinimumSize = new System.Drawing.Size(306, 82);
			_lbl_gen_110.Name = "_lbl_gen_110";
			_lbl_gen_110.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_110.Size = new System.Drawing.Size(306, 82);
			_lbl_gen_110.TabIndex = 401;
			_lbl_gen_110.Text = "Commercial to Hombase Aircraft Mapping : Aircraft Details";
			_lbl_gen_110.Visible = false;
			_lbl_gen_110.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_110.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_111
			// 
			_lbl_gen_111.AllowDrop = true;
			_lbl_gen_111.AutoSize = true;
			_lbl_gen_111.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_111.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_111.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_111.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_gen_111.Location = new System.Drawing.Point(-4813, 113);
			_lbl_gen_111.MinimumSize = new System.Drawing.Size(112, 13);
			_lbl_gen_111.Name = "_lbl_gen_111";
			_lbl_gen_111.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_111.Size = new System.Drawing.Size(112, 13);
			_lbl_gen_111.TabIndex = 400;
			_lbl_gen_111.Text = "Aircraft ID to Update";
			_lbl_gen_111.Visible = false;
			_lbl_gen_111.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_111.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _tab_ACMain_TabPage0
			// 
			_tab_ACMain_TabPage0.Controls.Add(_lbl_gen_8);
			_tab_ACMain_TabPage0.Controls.Add(_lbl_gen_7);
			_tab_ACMain_TabPage0.Controls.Add(_lbl_gen_11);
			_tab_ACMain_TabPage0.Controls.Add(_lbl_gen_1);
			_tab_ACMain_TabPage0.Controls.Add(_lbl_gen_2);
			_tab_ACMain_TabPage0.Controls.Add(pnl_Sale_Data);
			_tab_ACMain_TabPage0.Controls.Add(cbo_ac_status);
			_tab_ACMain_TabPage0.Controls.Add(_chkArray_6);
			_tab_ACMain_TabPage0.Controls.Add(txt_ac_purchase_date);
			_tab_ACMain_TabPage0.Controls.Add(_chkArray_5);
			_tab_ACMain_TabPage0.Controls.Add(txt_exclusive_verify_date);
			_tab_ACMain_TabPage0.Controls.Add(_chkArray_4);
			_tab_ACMain_TabPage0.Controls.Add(cbo_ac_stage);
			_tab_ACMain_TabPage0.Controls.Add(cbo_ac_owner_type);
			_tab_ACMain_TabPage0.Controls.Add(_chkArray_3);
			_tab_ACMain_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_ACMain_TabPage0.Text = "AC Status";
			// 
			// _lbl_gen_8
			// 
			_lbl_gen_8.AllowDrop = true;
			_lbl_gen_8.AutoSize = true;
			_lbl_gen_8.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_8.Location = new System.Drawing.Point(87, 7);
			_lbl_gen_8.MinimumSize = new System.Drawing.Size(33, 13);
			_lbl_gen_8.Name = "_lbl_gen_8";
			_lbl_gen_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_8.Size = new System.Drawing.Size(33, 13);
			_lbl_gen_8.TabIndex = 104;
			_lbl_gen_8.Text = "Status:";
			_lbl_gen_8.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_8.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_7
			// 
			_lbl_gen_7.AllowDrop = true;
			_lbl_gen_7.AutoSize = true;
			_lbl_gen_7.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_7.Location = new System.Drawing.Point(306, 9);
			_lbl_gen_7.MinimumSize = new System.Drawing.Size(80, 13);
			_lbl_gen_7.Name = "_lbl_gen_7";
			_lbl_gen_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_7.Size = new System.Drawing.Size(80, 13);
			_lbl_gen_7.TabIndex = 105;
			_lbl_gen_7.Text = "Date Purchased:";
			_lbl_gen_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_7.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_7.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_11
			// 
			_lbl_gen_11.AllowDrop = true;
			_lbl_gen_11.AutoSize = true;
			_lbl_gen_11.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_11.Location = new System.Drawing.Point(6, 63);
			_lbl_gen_11.MinimumSize = new System.Drawing.Size(73, 27);
			_lbl_gen_11.Name = "_lbl_gen_11";
			_lbl_gen_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_11.Size = new System.Drawing.Size(73, 27);
			_lbl_gen_11.TabIndex = 114;
			_lbl_gen_11.Text = "Next Exclusive Verify Date";
			_lbl_gen_11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_11.Visible = false;
			_lbl_gen_11.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_11.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_1
			// 
			_lbl_gen_1.AllowDrop = true;
			_lbl_gen_1.AutoSize = true;
			_lbl_gen_1.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_1.Location = new System.Drawing.Point(306, 26);
			_lbl_gen_1.MinimumSize = new System.Drawing.Size(80, 13);
			_lbl_gen_1.Name = "_lbl_gen_1";
			_lbl_gen_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_1.Size = new System.Drawing.Size(80, 13);
			_lbl_gen_1.TabIndex = 197;
			_lbl_gen_1.Text = "Ownership Type:";
			_lbl_gen_1.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_1.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_2
			// 
			_lbl_gen_2.AllowDrop = true;
			_lbl_gen_2.AutoSize = true;
			_lbl_gen_2.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_2.Location = new System.Drawing.Point(87, 26);
			_lbl_gen_2.MinimumSize = new System.Drawing.Size(76, 13);
			_lbl_gen_2.Name = "_lbl_gen_2";
			_lbl_gen_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_2.Size = new System.Drawing.Size(76, 13);
			_lbl_gen_2.TabIndex = 198;
			_lbl_gen_2.Text = "Lifecycle Stage:";
			_lbl_gen_2.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_2.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// pnl_Sale_Data
			// 
			pnl_Sale_Data.AllowDrop = true;
			pnl_Sale_Data.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			pnl_Sale_Data.BorderStyle = System.Windows.Forms.BorderStyle.None;
			pnl_Sale_Data.Controls.Add(_cmdAddACDetail_9);
			pnl_Sale_Data.Controls.Add(_chkArray_2);
			pnl_Sale_Data.Controls.Add(txt_ac_sale_price);
			pnl_Sale_Data.Controls.Add(txt_ac_foreign_currency_price);
			pnl_Sale_Data.Controls.Add(cbo_ac_foreign_currency_name);
			pnl_Sale_Data.Controls.Add(cbo_ac_asking);
			pnl_Sale_Data.Controls.Add(txt_ac_asking_price);
			pnl_Sale_Data.Controls.Add(txt_ac_list_date);
			pnl_Sale_Data.Controls.Add(cbo_ac_delivery);
			pnl_Sale_Data.Controls.Add(_lbl_gen_75);
			pnl_Sale_Data.Controls.Add(_lbl_gen_98);
			pnl_Sale_Data.Controls.Add(_lbl_gen_33);
			pnl_Sale_Data.Controls.Add(_lbl_gen_31);
			pnl_Sale_Data.Controls.Add(_lbl_gen_9);
			pnl_Sale_Data.Controls.Add(_lbl_gen_10);
			pnl_Sale_Data.Controls.Add(_lbl_gen_6);
			pnl_Sale_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Sale_Data.Location = new System.Drawing.Point(88, 64);
			pnl_Sale_Data.Name = "pnl_Sale_Data";
			pnl_Sale_Data.Size = new System.Drawing.Size(399, 76);
			pnl_Sale_Data.TabIndex = 100;
			pnl_Sale_Data.Visible = false;
			// 
			// _cmdAddACDetail_9
			// 
			_cmdAddACDetail_9.AllowDrop = true;
			_cmdAddACDetail_9.BackColor = System.Drawing.SystemColors.Control;
			_cmdAddACDetail_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAddACDetail_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAddACDetail_9.Location = new System.Drawing.Point(148, 0);
			_cmdAddACDetail_9.Name = "_cmdAddACDetail_9";
			_cmdAddACDetail_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAddACDetail_9.Size = new System.Drawing.Size(51, 21);
			_cmdAddACDetail_9.TabIndex = 441;
			_cmdAddACDetail_9.Text = "Convert";
			_cmdAddACDetail_9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAddACDetail_9.UseVisualStyleBackColor = false;
			_cmdAddACDetail_9.Click += new System.EventHandler(cmdAddACDetail_Click);
			// 
			// _chkArray_2
			// 
			_chkArray_2.AllowDrop = true;
			_chkArray_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkArray_2.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			_chkArray_2.CausesValidation = true;
			_chkArray_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkArray_2.Cursor = System.Windows.Forms.Cursors.Arrow;
			_chkArray_2.Enabled = true;
			_chkArray_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkArray_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkArray_2.Location = new System.Drawing.Point(204, 50);
			_chkArray_2.Name = "_chkArray_2";
			_chkArray_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkArray_2.Size = new System.Drawing.Size(63, 21);
			_chkArray_2.TabIndex = 412;
			_chkArray_2.TabStop = true;
			_chkArray_2.Text = "Display?";
			_chkArray_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_2.Visible = true;
			_chkArray_2.CheckStateChanged += new System.EventHandler(chkArray_CheckStateChanged);
			_chkArray_2.MouseDown += new System.Windows.Forms.MouseEventHandler(chkArray_MouseDown);
			// 
			// txt_ac_sale_price
			// 
			txt_ac_sale_price.AcceptsReturn = true;
			txt_ac_sale_price.AllowDrop = true;
			txt_ac_sale_price.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_sale_price.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_sale_price.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_sale_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_sale_price.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_sale_price.Location = new System.Drawing.Point(320, 52);
			txt_ac_sale_price.MaxLength = 0;
			txt_ac_sale_price.Name = "txt_ac_sale_price";
			txt_ac_sale_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_sale_price.Size = new System.Drawing.Size(75, 21);
			txt_ac_sale_price.TabIndex = 335;
			txt_ac_sale_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_ac_sale_price.Visible = false;
			txt_ac_sale_price.DoubleClick += new System.EventHandler(txt_ac_sale_price_DoubleClick);
			// 
			// txt_ac_foreign_currency_price
			// 
			txt_ac_foreign_currency_price.AcceptsReturn = true;
			txt_ac_foreign_currency_price.AllowDrop = true;
			txt_ac_foreign_currency_price.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_foreign_currency_price.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_foreign_currency_price.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_foreign_currency_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_foreign_currency_price.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_foreign_currency_price.Location = new System.Drawing.Point(320, 28);
			txt_ac_foreign_currency_price.MaxLength = 0;
			txt_ac_foreign_currency_price.Name = "txt_ac_foreign_currency_price";
			txt_ac_foreign_currency_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_foreign_currency_price.Size = new System.Drawing.Size(75, 21);
			txt_ac_foreign_currency_price.TabIndex = 27;
			txt_ac_foreign_currency_price.Tag = "txt_ac_foreign_currency_price";
			txt_ac_foreign_currency_price.Text = "99,000,0000";
			txt_ac_foreign_currency_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cbo_ac_foreign_currency_name
			// 
			cbo_ac_foreign_currency_name.AllowDrop = true;
			cbo_ac_foreign_currency_name.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_foreign_currency_name.CausesValidation = true;
			cbo_ac_foreign_currency_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_foreign_currency_name.Enabled = true;
			cbo_ac_foreign_currency_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_foreign_currency_name.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_foreign_currency_name.IntegralHeight = true;
			cbo_ac_foreign_currency_name.Location = new System.Drawing.Point(320, 3);
			cbo_ac_foreign_currency_name.Name = "cbo_ac_foreign_currency_name";
			cbo_ac_foreign_currency_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_foreign_currency_name.Size = new System.Drawing.Size(79, 21);
			cbo_ac_foreign_currency_name.Sorted = false;
			cbo_ac_foreign_currency_name.TabIndex = 25;
			cbo_ac_foreign_currency_name.TabStop = true;
			cbo_ac_foreign_currency_name.Visible = true;
			// 
			// cbo_ac_asking
			// 
			cbo_ac_asking.AllowDrop = true;
			cbo_ac_asking.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_asking.CausesValidation = true;
			cbo_ac_asking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_asking.Enabled = true;
			cbo_ac_asking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_asking.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_asking.IntegralHeight = true;
			cbo_ac_asking.Location = new System.Drawing.Point(43, 26);
			cbo_ac_asking.Name = "cbo_ac_asking";
			cbo_ac_asking.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_asking.Size = new System.Drawing.Size(81, 21);
			cbo_ac_asking.Sorted = false;
			cbo_ac_asking.TabIndex = 22;
			cbo_ac_asking.TabStop = true;
			cbo_ac_asking.Visible = true;
			cbo_ac_asking.SelectedIndexChanged += new System.EventHandler(cbo_ac_asking_SelectedIndexChanged);
			// 
			// txt_ac_asking_price
			// 
			txt_ac_asking_price.AcceptsReturn = true;
			txt_ac_asking_price.AllowDrop = true;
			txt_ac_asking_price.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_asking_price.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_asking_price.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_asking_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_asking_price.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_asking_price.Location = new System.Drawing.Point(124, 24);
			txt_ac_asking_price.MaxLength = 0;
			txt_ac_asking_price.Name = "txt_ac_asking_price";
			txt_ac_asking_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_asking_price.Size = new System.Drawing.Size(75, 21);
			txt_ac_asking_price.TabIndex = 23;
			txt_ac_asking_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_ac_list_date
			// 
			txt_ac_list_date.AcceptsReturn = true;
			txt_ac_list_date.AllowDrop = true;
			txt_ac_list_date.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_list_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_list_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_list_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_list_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_list_date.Location = new System.Drawing.Point(43, 50);
			txt_ac_list_date.MaxLength = 10;
			txt_ac_list_date.Name = "txt_ac_list_date";
			txt_ac_list_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_list_date.Size = new System.Drawing.Size(65, 21);
			txt_ac_list_date.TabIndex = 24;
			// 
			// cbo_ac_delivery
			// 
			cbo_ac_delivery.AllowDrop = true;
			cbo_ac_delivery.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_delivery.CausesValidation = true;
			cbo_ac_delivery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_delivery.Enabled = true;
			cbo_ac_delivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_delivery.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_delivery.IntegralHeight = true;
			cbo_ac_delivery.Location = new System.Drawing.Point(50, 0);
			cbo_ac_delivery.Name = "cbo_ac_delivery";
			cbo_ac_delivery.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_delivery.Size = new System.Drawing.Size(88, 21);
			cbo_ac_delivery.Sorted = false;
			cbo_ac_delivery.TabIndex = 21;
			cbo_ac_delivery.TabStop = true;
			cbo_ac_delivery.Visible = true;
			cbo_ac_delivery.SelectedIndexChanged += new System.EventHandler(cbo_ac_delivery_SelectedIndexChanged);
			// 
			// _lbl_gen_75
			// 
			_lbl_gen_75.AllowDrop = true;
			_lbl_gen_75.AutoSize = true;
			_lbl_gen_75.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_75.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_75.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_75.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_75.Location = new System.Drawing.Point(114, 54);
			_lbl_gen_75.MinimumSize = new System.Drawing.Size(28, 13);
			_lbl_gen_75.Name = "_lbl_gen_75";
			_lbl_gen_75.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_75.Size = new System.Drawing.Size(28, 13);
			_lbl_gen_75.TabIndex = 253;
			_lbl_gen_75.Text = "DOM:";
			_lbl_gen_75.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_75.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_98
			// 
			_lbl_gen_98.AllowDrop = true;
			_lbl_gen_98.AutoSize = true;
			_lbl_gen_98.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_98.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_98.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_98.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_98.Location = new System.Drawing.Point(266, 54);
			_lbl_gen_98.MinimumSize = new System.Drawing.Size(51, 13);
			_lbl_gen_98.Name = "_lbl_gen_98";
			_lbl_gen_98.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_98.Size = new System.Drawing.Size(51, 13);
			_lbl_gen_98.TabIndex = 334;
			_lbl_gen_98.Text = "Sale Price:";
			_lbl_gen_98.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_98.Visible = false;
			_lbl_gen_98.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_98.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_33
			// 
			_lbl_gen_33.AllowDrop = true;
			_lbl_gen_33.AutoSize = true;
			_lbl_gen_33.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_33.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_33.Location = new System.Drawing.Point(217, 31);
			_lbl_gen_33.MinimumSize = new System.Drawing.Size(100, 13);
			_lbl_gen_33.Name = "_lbl_gen_33";
			_lbl_gen_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_33.Size = new System.Drawing.Size(100, 13);
			_lbl_gen_33.TabIndex = 120;
			_lbl_gen_33.Text = "Foreign Asking Price:";
			_lbl_gen_33.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_33.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_33.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_31
			// 
			_lbl_gen_31.AllowDrop = true;
			_lbl_gen_31.AutoSize = true;
			_lbl_gen_31.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_31.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_31.Location = new System.Drawing.Point(234, 6);
			_lbl_gen_31.MinimumSize = new System.Drawing.Size(83, 13);
			_lbl_gen_31.Name = "_lbl_gen_31";
			_lbl_gen_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_31.Size = new System.Drawing.Size(83, 13);
			_lbl_gen_31.TabIndex = 119;
			_lbl_gen_31.Text = "Foreign Currency:";
			_lbl_gen_31.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_31.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_31.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_9
			// 
			_lbl_gen_9.AllowDrop = true;
			_lbl_gen_9.AutoSize = true;
			_lbl_gen_9.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_9.Location = new System.Drawing.Point(2, 31);
			_lbl_gen_9.MinimumSize = new System.Drawing.Size(35, 13);
			_lbl_gen_9.Name = "_lbl_gen_9";
			_lbl_gen_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_9.Size = new System.Drawing.Size(35, 13);
			_lbl_gen_9.TabIndex = 103;
			_lbl_gen_9.Text = "Asking:";
			_lbl_gen_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_9.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_9.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_10
			// 
			_lbl_gen_10.AllowDrop = true;
			_lbl_gen_10.AutoSize = true;
			_lbl_gen_10.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_10.Location = new System.Drawing.Point(2, 54);
			_lbl_gen_10.MinimumSize = new System.Drawing.Size(31, 13);
			_lbl_gen_10.Name = "_lbl_gen_10";
			_lbl_gen_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_10.Size = new System.Drawing.Size(31, 13);
			_lbl_gen_10.TabIndex = 102;
			_lbl_gen_10.Text = "Listed:";
			_lbl_gen_10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_10.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_10.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_6
			// 
			_lbl_gen_6.AllowDrop = true;
			_lbl_gen_6.AutoSize = true;
			_lbl_gen_6.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_6.Location = new System.Drawing.Point(2, 7);
			_lbl_gen_6.MinimumSize = new System.Drawing.Size(41, 13);
			_lbl_gen_6.Name = "_lbl_gen_6";
			_lbl_gen_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_6.Size = new System.Drawing.Size(41, 13);
			_lbl_gen_6.TabIndex = 101;
			_lbl_gen_6.Text = "Delivery:";
			_lbl_gen_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_6.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_6.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// cbo_ac_status
			// 
			cbo_ac_status.AllowDrop = true;
			cbo_ac_status.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_status.CausesValidation = true;
			cbo_ac_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_status.Enabled = true;
			cbo_ac_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_status.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_status.IntegralHeight = true;
			cbo_ac_status.Location = new System.Drawing.Point(125, 4);
			cbo_ac_status.Name = "cbo_ac_status";
			cbo_ac_status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_status.Size = new System.Drawing.Size(177, 21);
			cbo_ac_status.Sorted = false;
			cbo_ac_status.TabIndex = 15;
			cbo_ac_status.TabStop = true;
			cbo_ac_status.Visible = true;
			cbo_ac_status.SelectedIndexChanged += new System.EventHandler(cbo_ac_status_SelectedIndexChanged);
			// 
			// _chkArray_6
			// 
			_chkArray_6.AllowDrop = true;
			_chkArray_6.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkArray_6.BackColor = System.Drawing.SystemColors.Control;
			_chkArray_6.CausesValidation = true;
			_chkArray_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_6.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkArray_6.Enabled = true;
			_chkArray_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkArray_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_chkArray_6.Location = new System.Drawing.Point(6, 6);
			_chkArray_6.Name = "_chkArray_6";
			_chkArray_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkArray_6.Size = new System.Drawing.Size(73, 17);
			_chkArray_6.TabIndex = 12;
			_chkArray_6.TabStop = true;
			_chkArray_6.Text = "Available?";
			_chkArray_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_6.Visible = true;
			_chkArray_6.CheckStateChanged += new System.EventHandler(chkArray_CheckStateChanged);
			_chkArray_6.MouseDown += new System.Windows.Forms.MouseEventHandler(chkArray_MouseDown);
			// 
			// txt_ac_purchase_date
			// 
			txt_ac_purchase_date.AcceptsReturn = true;
			txt_ac_purchase_date.AllowDrop = true;
			txt_ac_purchase_date.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_purchase_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_purchase_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_purchase_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_purchase_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_purchase_date.Location = new System.Drawing.Point(394, 6);
			txt_ac_purchase_date.MaxLength = 0;
			txt_ac_purchase_date.Name = "txt_ac_purchase_date";
			txt_ac_purchase_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_purchase_date.Size = new System.Drawing.Size(73, 19);
			txt_ac_purchase_date.TabIndex = 16;
			txt_ac_purchase_date.Leave += new System.EventHandler(txt_ac_purchase_date_Leave);
			// 
			// _chkArray_5
			// 
			_chkArray_5.AllowDrop = true;
			_chkArray_5.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkArray_5.BackColor = System.Drawing.SystemColors.Control;
			_chkArray_5.CausesValidation = true;
			_chkArray_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkArray_5.Enabled = false;
			_chkArray_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkArray_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_chkArray_5.Location = new System.Drawing.Point(6, 27);
			_chkArray_5.Name = "_chkArray_5";
			_chkArray_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkArray_5.Size = new System.Drawing.Size(73, 13);
			_chkArray_5.TabIndex = 13;
			_chkArray_5.TabStop = true;
			_chkArray_5.Text = "Exclusive?";
			_chkArray_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_5.Visible = false;
			_chkArray_5.CheckStateChanged += new System.EventHandler(chkArray_CheckStateChanged);
			_chkArray_5.MouseDown += new System.Windows.Forms.MouseEventHandler(chkArray_MouseDown);
			// 
			// txt_exclusive_verify_date
			// 
			txt_exclusive_verify_date.AcceptsReturn = true;
			txt_exclusive_verify_date.AllowDrop = true;
			txt_exclusive_verify_date.BackColor = System.Drawing.SystemColors.Window;
			txt_exclusive_verify_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_exclusive_verify_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_exclusive_verify_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_exclusive_verify_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_exclusive_verify_date.Location = new System.Drawing.Point(6, 94);
			txt_exclusive_verify_date.MaxLength = 0;
			txt_exclusive_verify_date.Name = "txt_exclusive_verify_date";
			txt_exclusive_verify_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_exclusive_verify_date.Size = new System.Drawing.Size(73, 19);
			txt_exclusive_verify_date.TabIndex = 19;
			txt_exclusive_verify_date.Visible = false;
			txt_exclusive_verify_date.Leave += new System.EventHandler(txt_exclusive_verify_date_Leave);
			// 
			// _chkArray_4
			// 
			_chkArray_4.AllowDrop = true;
			_chkArray_4.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkArray_4.BackColor = System.Drawing.SystemColors.Control;
			_chkArray_4.CausesValidation = true;
			_chkArray_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkArray_4.Enabled = false;
			_chkArray_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkArray_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_chkArray_4.Location = new System.Drawing.Point(6, 46);
			_chkArray_4.Name = "_chkArray_4";
			_chkArray_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkArray_4.Size = new System.Drawing.Size(73, 13);
			_chkArray_4.TabIndex = 14;
			_chkArray_4.TabStop = true;
			_chkArray_4.Text = "Leased?";
			_chkArray_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_4.Visible = true;
			_chkArray_4.CheckStateChanged += new System.EventHandler(chkArray_CheckStateChanged);
			_chkArray_4.MouseDown += new System.Windows.Forms.MouseEventHandler(chkArray_MouseDown);
			// 
			// cbo_ac_stage
			// 
			cbo_ac_stage.AllowDrop = true;
			cbo_ac_stage.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_stage.CausesValidation = true;
			cbo_ac_stage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_stage.Enabled = true;
			cbo_ac_stage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_stage.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_stage.IntegralHeight = true;
			cbo_ac_stage.Location = new System.Drawing.Point(87, 40);
			cbo_ac_stage.Name = "cbo_ac_stage";
			cbo_ac_stage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_stage.Size = new System.Drawing.Size(217, 21);
			cbo_ac_stage.Sorted = false;
			cbo_ac_stage.TabIndex = 17;
			cbo_ac_stage.TabStop = true;
			cbo_ac_stage.Visible = true;
			cbo_ac_stage.SelectedIndexChanged += new System.EventHandler(cbo_ac_stage_SelectedIndexChanged);
			// 
			// cbo_ac_owner_type
			// 
			cbo_ac_owner_type.AllowDrop = true;
			cbo_ac_owner_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_owner_type.CausesValidation = true;
			cbo_ac_owner_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_owner_type.Enabled = false;
			cbo_ac_owner_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_owner_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_owner_type.IntegralHeight = true;
			cbo_ac_owner_type.Location = new System.Drawing.Point(303, 40);
			cbo_ac_owner_type.Name = "cbo_ac_owner_type";
			cbo_ac_owner_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_owner_type.Size = new System.Drawing.Size(188, 21);
			cbo_ac_owner_type.Sorted = false;
			cbo_ac_owner_type.TabIndex = 18;
			cbo_ac_owner_type.TabStop = true;
			cbo_ac_owner_type.Visible = true;
			cbo_ac_owner_type.SelectedIndexChanged += new System.EventHandler(cbo_ac_owner_type_SelectedIndexChanged);
			// 
			// _chkArray_3
			// 
			_chkArray_3.AllowDrop = true;
			_chkArray_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkArray_3.BackColor = System.Drawing.SystemColors.Control;
			_chkArray_3.CausesValidation = true;
			_chkArray_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkArray_3.Enabled = false;
			_chkArray_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkArray_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_chkArray_3.Location = new System.Drawing.Point(6, 119);
			_chkArray_3.Name = "_chkArray_3";
			_chkArray_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkArray_3.Size = new System.Drawing.Size(73, 13);
			_chkArray_3.TabIndex = 20;
			_chkArray_3.TabStop = true;
			_chkArray_3.Text = "Expiration?";
			_chkArray_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_3.Visible = false;
			_chkArray_3.CheckStateChanged += new System.EventHandler(chkArray_CheckStateChanged);
			_chkArray_3.MouseDown += new System.Windows.Forms.MouseEventHandler(chkArray_MouseDown);
			// 
			// _tab_ACMain_TabPage1
			// 
			_tab_ACMain_TabPage1.Controls.Add(cmdModifyTransaction);
			_tab_ACMain_TabPage1.Controls.Add(cmdRetrieveSpecs);
			_tab_ACMain_TabPage1.Controls.Add(_chkArray_0);
			_tab_ACMain_TabPage1.Controls.Add(cmd_Active);
			_tab_ACMain_TabPage1.Controls.Add(grd_AircraftHistory);
			_tab_ACMain_TabPage1.Controls.Add(_lbl_gen_86);
			_tab_ACMain_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_ACMain_TabPage1.Text = "AC History";
			// 
			// cmdModifyTransaction
			// 
			cmdModifyTransaction.AllowDrop = true;
			cmdModifyTransaction.BackColor = System.Drawing.SystemColors.Control;
			cmdModifyTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdModifyTransaction.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdModifyTransaction.Location = new System.Drawing.Point(4, 24);
			cmdModifyTransaction.Name = "cmdModifyTransaction";
			cmdModifyTransaction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdModifyTransaction.Size = new System.Drawing.Size(177, 21);
			cmdModifyTransaction.TabIndex = 29;
			cmdModifyTransaction.Text = "Modify Transaction";
			cmdModifyTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdModifyTransaction.UseVisualStyleBackColor = false;
			cmdModifyTransaction.Visible = false;
			cmdModifyTransaction.Click += new System.EventHandler(cmdModifyTransaction_Click);
			// 
			// cmdRetrieveSpecs
			// 
			cmdRetrieveSpecs.AllowDrop = true;
			cmdRetrieveSpecs.BackColor = System.Drawing.SystemColors.Control;
			cmdRetrieveSpecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRetrieveSpecs.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRetrieveSpecs.Location = new System.Drawing.Point(4, 24);
			cmdRetrieveSpecs.Name = "cmdRetrieveSpecs";
			cmdRetrieveSpecs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRetrieveSpecs.Size = new System.Drawing.Size(177, 21);
			cmdRetrieveSpecs.TabIndex = 304;
			cmdRetrieveSpecs.Text = "Apply Specs to Current Aircraft";
			cmdRetrieveSpecs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRetrieveSpecs.UseVisualStyleBackColor = false;
			cmdRetrieveSpecs.Click += new System.EventHandler(cmdRetrieveSpecs_Click);
			// 
			// _chkArray_0
			// 
			_chkArray_0.AllowDrop = true;
			_chkArray_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkArray_0.BackColor = System.Drawing.SystemColors.Control;
			_chkArray_0.CausesValidation = true;
			_chkArray_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkArray_0.Enabled = true;
			_chkArray_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkArray_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_chkArray_0.Location = new System.Drawing.Point(5, 124);
			_chkArray_0.Name = "_chkArray_0";
			_chkArray_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkArray_0.Size = new System.Drawing.Size(161, 13);
			_chkArray_0.TabIndex = 275;
			_chkArray_0.TabStop = true;
			_chkArray_0.Text = "Include Market Summaries";
			_chkArray_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_0.Visible = true;
			_chkArray_0.CheckStateChanged += new System.EventHandler(chkArray_CheckStateChanged);
			_chkArray_0.MouseDown += new System.Windows.Forms.MouseEventHandler(chkArray_MouseDown);
			// 
			// cmd_Active
			// 
			cmd_Active.AllowDrop = true;
			cmd_Active.BackColor = System.Drawing.SystemColors.Control;
			cmd_Active.Enabled = false;
			cmd_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Active.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Active.Location = new System.Drawing.Point(4, 3);
			cmd_Active.Name = "cmd_Active";
			cmd_Active.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Active.Size = new System.Drawing.Size(177, 21);
			cmd_Active.TabIndex = 28;
			cmd_Active.Text = "View Historical Aircraft Record";
			cmd_Active.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Active.Visible = false;
			cmd_Active.Click += new System.EventHandler(cmd_Active_Click);
			// 
			// grd_AircraftHistory
			// 
			grd_AircraftHistory.AllowDrop = true;
			grd_AircraftHistory.AllowUserToAddRows = false;
			grd_AircraftHistory.AllowUserToDeleteRows = false;
			grd_AircraftHistory.AllowUserToResizeColumns = false;
			grd_AircraftHistory.AllowUserToResizeColumns = grd_AircraftHistory.ColumnHeadersVisible;
			grd_AircraftHistory.AllowUserToResizeRows = false;
			grd_AircraftHistory.AllowUserToResizeRows = grd_AircraftHistory.RowHeadersVisible;
			grd_AircraftHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_AircraftHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_AircraftHistory.ColumnsCount = 2;
			grd_AircraftHistory.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			grd_AircraftHistory.FixedColumns = 0;
			grd_AircraftHistory.FixedRows = 1;
			grd_AircraftHistory.Location = new System.Drawing.Point(4, 50);
			grd_AircraftHistory.Name = "grd_AircraftHistory";
			grd_AircraftHistory.ReadOnly = true;
			grd_AircraftHistory.RowsCount = 2;
			grd_AircraftHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_AircraftHistory.ShowCellToolTips = false;
			grd_AircraftHistory.Size = new System.Drawing.Size(477, 75);
			grd_AircraftHistory.StandardTab = true;
			grd_AircraftHistory.TabIndex = 279;
			grd_AircraftHistory.Click += new System.EventHandler(grd_AircraftHistory_Click);
			grd_AircraftHistory.DoubleClick += new System.EventHandler(grd_AircraftHistory_DoubleClick);
			// 
			// _lbl_gen_86
			// 
			_lbl_gen_86.AllowDrop = true;
			_lbl_gen_86.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_gen_86.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_86.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_gen_86.Location = new System.Drawing.Point(184, 4);
			_lbl_gen_86.MinimumSize = new System.Drawing.Size(298, 39);
			_lbl_gen_86.Name = "_lbl_gen_86";
			_lbl_gen_86.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_86.Size = new System.Drawing.Size(298, 39);
			_lbl_gen_86.TabIndex = 129;
			_lbl_gen_86.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_86.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _tab_ACMain_TabPage2
			// 
			_tab_ACMain_TabPage2.Controls.Add(_chkArray_7);
			_tab_ACMain_TabPage2.Controls.Add(_chk_ac_aport_private_1);
			_tab_ACMain_TabPage2.Controls.Add(_lbl_gen_50);
			_tab_ACMain_TabPage2.Controls.Add(_lbl_gen_22);
			_tab_ACMain_TabPage2.Controls.Add(_lbl_gen_256);
			_tab_ACMain_TabPage2.Controls.Add(_lbl_gen_245);
			_tab_ACMain_TabPage2.Controls.Add(_lbl_gen_15);
			_tab_ACMain_TabPage2.Controls.Add(_lbl_gen_13);
			_tab_ACMain_TabPage2.Controls.Add(_lbl_gen_14);
			_tab_ACMain_TabPage2.Controls.Add(_lbl_gen_12);
			_tab_ACMain_TabPage2.Controls.Add(_lbl_gen_257);
			_tab_ACMain_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_ACMain_TabPage2.Text = "AC Admin";
			// 
			// _chkArray_7
			// 
			_chkArray_7.AllowDrop = true;
			_chkArray_7.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkArray_7.BackColor = System.Drawing.SystemColors.Control;
			_chkArray_7.CausesValidation = true;
			_chkArray_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_7.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkArray_7.Enabled = true;
			_chkArray_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkArray_7.ForeColor = System.Drawing.SystemColors.WindowText;
			_chkArray_7.Location = new System.Drawing.Point(38, 84);
			_chkArray_7.Name = "_chkArray_7";
			_chkArray_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkArray_7.Size = new System.Drawing.Size(73, 13);
			_chkArray_7.TabIndex = 451;
			_chkArray_7.TabStop = true;
			_chkArray_7.Text = "Restricted";
			_chkArray_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkArray_7.Visible = true;
			_chkArray_7.CheckStateChanged += new System.EventHandler(chkArray_CheckStateChanged);
			_chkArray_7.MouseDown += new System.Windows.Forms.MouseEventHandler(chkArray_MouseDown);
			// 
			// _chk_ac_aport_private_1
			// 
			_chk_ac_aport_private_1.AllowDrop = true;
			_chk_ac_aport_private_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_ac_aport_private_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_ac_aport_private_1.CausesValidation = true;
			_chk_ac_aport_private_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_aport_private_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_ac_aport_private_1.Enabled = true;
			_chk_ac_aport_private_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_ac_aport_private_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_ac_aport_private_1.Location = new System.Drawing.Point(38, 106);
			_chk_ac_aport_private_1.Name = "_chk_ac_aport_private_1";
			_chk_ac_aport_private_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_ac_aport_private_1.Size = new System.Drawing.Size(96, 13);
			_chk_ac_aport_private_1.TabIndex = 395;
			_chk_ac_aport_private_1.TabStop = true;
			_chk_ac_aport_private_1.Text = "Used Aircraft";
			_chk_ac_aport_private_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_aport_private_1.Visible = true;
			_chk_ac_aport_private_1.CheckStateChanged += new System.EventHandler(chk_ac_aport_private_CheckStateChanged);
			// 
			// _lbl_gen_50
			// 
			_lbl_gen_50.AllowDrop = true;
			_lbl_gen_50.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_50.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_50.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_50.Location = new System.Drawing.Point(248, 105);
			_lbl_gen_50.MinimumSize = new System.Drawing.Size(185, 17);
			_lbl_gen_50.Name = "_lbl_gen_50";
			_lbl_gen_50.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_50.Size = new System.Drawing.Size(185, 17);
			_lbl_gen_50.TabIndex = 303;
			_lbl_gen_50.Text = "PC Record Key:";
			_lbl_gen_50.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_50.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_22
			// 
			_lbl_gen_22.AllowDrop = true;
			_lbl_gen_22.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_22.Location = new System.Drawing.Point(248, 84);
			_lbl_gen_22.MinimumSize = new System.Drawing.Size(185, 17);
			_lbl_gen_22.Name = "_lbl_gen_22";
			_lbl_gen_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_22.Size = new System.Drawing.Size(185, 17);
			_lbl_gen_22.TabIndex = 302;
			_lbl_gen_22.Text = "Journal ID";
			_lbl_gen_22.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_22.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_256
			// 
			_lbl_gen_256.AllowDrop = true;
			_lbl_gen_256.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_256.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_256.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_256.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_256.Location = new System.Drawing.Point(248, 39);
			_lbl_gen_256.MinimumSize = new System.Drawing.Size(177, 17);
			_lbl_gen_256.Name = "_lbl_gen_256";
			_lbl_gen_256.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_256.Size = new System.Drawing.Size(177, 17);
			_lbl_gen_256.TabIndex = 211;
			_lbl_gen_256.Text = "Next verified Date:";
			_lbl_gen_256.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_256.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_245
			// 
			_lbl_gen_245.AllowDrop = true;
			_lbl_gen_245.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_245.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_245.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_245.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_245.Location = new System.Drawing.Point(248, 17);
			_lbl_gen_245.MinimumSize = new System.Drawing.Size(177, 17);
			_lbl_gen_245.Name = "_lbl_gen_245";
			_lbl_gen_245.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_245.Size = new System.Drawing.Size(177, 17);
			_lbl_gen_245.TabIndex = 210;
			_lbl_gen_245.Text = "Last Verified Date:";
			_lbl_gen_245.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_245.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_15
			// 
			_lbl_gen_15.AllowDrop = true;
			_lbl_gen_15.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_15.Location = new System.Drawing.Point(248, 62);
			_lbl_gen_15.MinimumSize = new System.Drawing.Size(185, 17);
			_lbl_gen_15.Name = "_lbl_gen_15";
			_lbl_gen_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_15.Size = new System.Drawing.Size(185, 17);
			_lbl_gen_15.TabIndex = 209;
			_lbl_gen_15.Text = "Current Account Rep";
			_lbl_gen_15.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_15.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_13
			// 
			_lbl_gen_13.AllowDrop = true;
			_lbl_gen_13.AutoSize = true;
			_lbl_gen_13.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_13.Location = new System.Drawing.Point(8, 32);
			_lbl_gen_13.MinimumSize = new System.Drawing.Size(40, 13);
			_lbl_gen_13.Name = "_lbl_gen_13";
			_lbl_gen_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_13.Size = new System.Drawing.Size(40, 13);
			_lbl_gen_13.TabIndex = 208;
			_lbl_gen_13.Text = "Entered:";
			_lbl_gen_13.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_13.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_14
			// 
			_lbl_gen_14.AllowDrop = true;
			_lbl_gen_14.AutoSize = true;
			_lbl_gen_14.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_14.Location = new System.Drawing.Point(4, 53);
			_lbl_gen_14.MinimumSize = new System.Drawing.Size(44, 13);
			_lbl_gen_14.Name = "_lbl_gen_14";
			_lbl_gen_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_14.Size = new System.Drawing.Size(44, 13);
			_lbl_gen_14.TabIndex = 207;
			_lbl_gen_14.Text = "Updated:";
			_lbl_gen_14.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_14.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_12
			// 
			_lbl_gen_12.AllowDrop = true;
			_lbl_gen_12.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_12.Location = new System.Drawing.Point(74, 16);
			_lbl_gen_12.MinimumSize = new System.Drawing.Size(41, 17);
			_lbl_gen_12.Name = "_lbl_gen_12";
			_lbl_gen_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_12.Size = new System.Drawing.Size(41, 17);
			_lbl_gen_12.TabIndex = 206;
			_lbl_gen_12.Text = "User";
			_lbl_gen_12.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_12.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_257
			// 
			_lbl_gen_257.AllowDrop = true;
			_lbl_gen_257.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_257.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_257.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_257.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_257.Location = new System.Drawing.Point(130, 16);
			_lbl_gen_257.MinimumSize = new System.Drawing.Size(41, 17);
			_lbl_gen_257.Name = "_lbl_gen_257";
			_lbl_gen_257.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_257.Size = new System.Drawing.Size(41, 17);
			_lbl_gen_257.TabIndex = 205;
			_lbl_gen_257.Text = "Date";
			_lbl_gen_257.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_257.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _tab_ACMain_TabPage3
			// 
			_tab_ACMain_TabPage3.Controls.Add(pnl_Research_Action);
			_tab_ACMain_TabPage3.Controls.Add(pnl_Journal);
			_tab_ACMain_TabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_ACMain_TabPage3.Text = "HOT BOX";
			// 
			// pnl_Research_Action
			// 
			pnl_Research_Action.AllowDrop = true;
			pnl_Research_Action.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Research_Action.Controls.Add(txtAddlHotBoxNotes);
			pnl_Research_Action.Controls.Add(cmdClearResearchAction);
			pnl_Research_Action.Controls.Add(cmd_Cancel);
			pnl_Research_Action.Controls.Add(lst_Research_Action);
			pnl_Research_Action.Controls.Add(_lbl_gen_77);
			pnl_Research_Action.Controls.Add(_lbl_gen_83);
			pnl_Research_Action.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Research_Action.Location = new System.Drawing.Point(8, 4);
			pnl_Research_Action.Name = "pnl_Research_Action";
			pnl_Research_Action.Size = new System.Drawing.Size(481, 132);
			pnl_Research_Action.TabIndex = 387;
			// 
			// txtAddlHotBoxNotes
			// 
			txtAddlHotBoxNotes.AcceptsReturn = true;
			txtAddlHotBoxNotes.AllowDrop = true;
			txtAddlHotBoxNotes.BackColor = System.Drawing.SystemColors.Window;
			txtAddlHotBoxNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtAddlHotBoxNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtAddlHotBoxNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtAddlHotBoxNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			txtAddlHotBoxNotes.Location = new System.Drawing.Point(179, 106);
			txtAddlHotBoxNotes.MaxLength = 4000;
			txtAddlHotBoxNotes.Multiline = true;
			txtAddlHotBoxNotes.Name = "txtAddlHotBoxNotes";
			txtAddlHotBoxNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtAddlHotBoxNotes.Size = new System.Drawing.Size(180, 22);
			txtAddlHotBoxNotes.TabIndex = 391;
			// 
			// cmdClearResearchAction
			// 
			cmdClearResearchAction.AllowDrop = true;
			cmdClearResearchAction.BackColor = System.Drawing.SystemColors.Control;
			cmdClearResearchAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClearResearchAction.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClearResearchAction.Location = new System.Drawing.Point(362, 104);
			cmdClearResearchAction.Name = "cmdClearResearchAction";
			cmdClearResearchAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClearResearchAction.Size = new System.Drawing.Size(114, 25);
			cmdClearResearchAction.TabIndex = 390;
			cmdClearResearchAction.Text = "Clear HOT BOX Item";
			cmdClearResearchAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClearResearchAction.UseVisualStyleBackColor = false;
			cmdClearResearchAction.Click += new System.EventHandler(cmdClearResearchAction_Click);
			// 
			// cmd_Cancel
			// 
			cmd_Cancel.AllowDrop = true;
			cmd_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel.Location = new System.Drawing.Point(5, 104);
			cmd_Cancel.Name = "cmd_Cancel";
			cmd_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel.Size = new System.Drawing.Size(114, 25);
			cmd_Cancel.TabIndex = 389;
			cmd_Cancel.Text = "&Add HOT BOX Item";
			cmd_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel.UseVisualStyleBackColor = false;
			cmd_Cancel.Click += new System.EventHandler(cmd_cancel_Click);
			// 
			// lst_Research_Action
			// 
			lst_Research_Action.AllowDrop = true;
			lst_Research_Action.BackColor = System.Drawing.SystemColors.Window;
			lst_Research_Action.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Research_Action.CausesValidation = true;
			lst_Research_Action.Enabled = true;
			lst_Research_Action.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Research_Action.ForeColor = System.Drawing.Color.Red;
			lst_Research_Action.IntegralHeight = true;
			lst_Research_Action.Location = new System.Drawing.Point(0, 32);
			lst_Research_Action.MultiColumn = false;
			lst_Research_Action.Name = "lst_Research_Action";
			lst_Research_Action.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Research_Action.Size = new System.Drawing.Size(471, 70);
			lst_Research_Action.Sorted = false;
			lst_Research_Action.TabIndex = 388;
			lst_Research_Action.TabStop = true;
			lst_Research_Action.Visible = true;
			lst_Research_Action.SelectedIndexChanged += new System.EventHandler(lst_Research_Action_SelectedIndexChanged);
			// 
			// _lbl_gen_77
			// 
			_lbl_gen_77.AllowDrop = true;
			_lbl_gen_77.AutoSize = true;
			_lbl_gen_77.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_77.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_77.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_77.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_77.Location = new System.Drawing.Point(122, 110);
			_lbl_gen_77.MinimumSize = new System.Drawing.Size(58, 13);
			_lbl_gen_77.Name = "_lbl_gen_77";
			_lbl_gen_77.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_77.Size = new System.Drawing.Size(58, 13);
			_lbl_gen_77.TabIndex = 393;
			_lbl_gen_77.Text = "Add'l Notes:";
			_lbl_gen_77.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_77.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_83
			// 
			_lbl_gen_83.AllowDrop = true;
			_lbl_gen_83.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_83.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_gen_83.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_83.ForeColor = System.Drawing.Color.Red;
			_lbl_gen_83.Location = new System.Drawing.Point(5, 4);
			_lbl_gen_83.MinimumSize = new System.Drawing.Size(471, 20);
			_lbl_gen_83.Name = "_lbl_gen_83";
			_lbl_gen_83.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_83.Size = new System.Drawing.Size(471, 20);
			_lbl_gen_83.TabIndex = 392;
			_lbl_gen_83.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_83.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_83.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// pnl_Journal
			// 
			pnl_Journal.AllowDrop = true;
			pnl_Journal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Journal.Controls.Add(txt_journal_note);
			pnl_Journal.Controls.Add(cmd_Journal_Note_Cancel);
			pnl_Journal.Controls.Add(cmd_Journal_Note_Save);
			pnl_Journal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Journal.Location = new System.Drawing.Point(4, 4);
			pnl_Journal.Name = "pnl_Journal";
			pnl_Journal.Size = new System.Drawing.Size(481, 132);
			pnl_Journal.TabIndex = 383;
			// 
			// txt_journal_note
			// 
			txt_journal_note.AcceptsReturn = true;
			txt_journal_note.AllowDrop = true;
			txt_journal_note.BackColor = System.Drawing.SystemColors.Window;
			txt_journal_note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journal_note.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journal_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journal_note.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journal_note.Location = new System.Drawing.Point(5, 22);
			txt_journal_note.MaxLength = 200;
			txt_journal_note.Multiline = true;
			txt_journal_note.Name = "txt_journal_note";
			txt_journal_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journal_note.Size = new System.Drawing.Size(415, 103);
			txt_journal_note.TabIndex = 384;
			// 
			// cmd_Journal_Note_Cancel
			// 
			cmd_Journal_Note_Cancel.AllowDrop = true;
			cmd_Journal_Note_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Journal_Note_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Journal_Note_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Journal_Note_Cancel.Location = new System.Drawing.Point(424, 75);
			cmd_Journal_Note_Cancel.Name = "cmd_Journal_Note_Cancel";
			cmd_Journal_Note_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Journal_Note_Cancel.Size = new System.Drawing.Size(49, 25);
			cmd_Journal_Note_Cancel.TabIndex = 386;
			cmd_Journal_Note_Cancel.Text = "Cancel";
			cmd_Journal_Note_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Journal_Note_Cancel.UseVisualStyleBackColor = false;
			cmd_Journal_Note_Cancel.Click += new System.EventHandler(cmd_Journal_Note_Cancel_Click);
			// 
			// cmd_Journal_Note_Save
			// 
			cmd_Journal_Note_Save.AllowDrop = true;
			cmd_Journal_Note_Save.BackColor = System.Drawing.SystemColors.Control;
			cmd_Journal_Note_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Journal_Note_Save.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Journal_Note_Save.Location = new System.Drawing.Point(424, 43);
			cmd_Journal_Note_Save.Name = "cmd_Journal_Note_Save";
			cmd_Journal_Note_Save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Journal_Note_Save.Size = new System.Drawing.Size(49, 25);
			cmd_Journal_Note_Save.TabIndex = 385;
			cmd_Journal_Note_Save.Text = "Save";
			cmd_Journal_Note_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Journal_Note_Save.UseVisualStyleBackColor = false;
			cmd_Journal_Note_Save.Click += new System.EventHandler(cmd_Journal_Note_Save_Click);
			// 
			// _tab_ACMain_TabPage4
			// 
			_tab_ACMain_TabPage4.Controls.Add(_lbl_gen_74);
			_tab_ACMain_TabPage4.Controls.Add(_lbl_gen_69);
			_tab_ACMain_TabPage4.Controls.Add(_lbl_gen_68);
			_tab_ACMain_TabPage4.Controls.Add(_lbl_gen_67);
			_tab_ACMain_TabPage4.Controls.Add(_lbl_gen_66);
			_tab_ACMain_TabPage4.Controls.Add(_lbl_gen_41);
			_tab_ACMain_TabPage4.Controls.Add(_lbl_gen_109);
			_tab_ACMain_TabPage4.Controls.Add(_lbl_gen_112);
			_tab_ACMain_TabPage4.Controls.Add(_lbl_gen_121);
			_tab_ACMain_TabPage4.Controls.Add(_lbl_gen_123);
			_tab_ACMain_TabPage4.Controls.Add(txtBaseCity);
			_tab_ACMain_TabPage4.Controls.Add(txtBaseAirportName);
			_tab_ACMain_TabPage4.Controls.Add(txtICAOCode);
			_tab_ACMain_TabPage4.Controls.Add(txtIATACode);
			_tab_ACMain_TabPage4.Controls.Add(cboBaseState);
			_tab_ACMain_TabPage4.Controls.Add(cboBaseCountry);
			_tab_ACMain_TabPage4.Controls.Add(_chk_ac_aport_private_0);
			_tab_ACMain_TabPage4.Controls.Add(txtFAAIDCode);
			_tab_ACMain_TabPage4.Controls.Add(_chk_ac_aport_private_2);
			_tab_ACMain_TabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_ACMain_TabPage4.Text = "AC Base";
			// 
			// _lbl_gen_74
			// 
			_lbl_gen_74.AllowDrop = true;
			_lbl_gen_74.AutoSize = true;
			_lbl_gen_74.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_74.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_74.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_74.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_74.Location = new System.Drawing.Point(21, 49);
			_lbl_gen_74.MinimumSize = new System.Drawing.Size(36, 14);
			_lbl_gen_74.Name = "_lbl_gen_74";
			_lbl_gen_74.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_74.Size = new System.Drawing.Size(36, 14);
			_lbl_gen_74.TabIndex = 263;
			_lbl_gen_74.Text = "Country";
			_lbl_gen_74.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_74.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_69
			// 
			_lbl_gen_69.AllowDrop = true;
			_lbl_gen_69.AutoSize = true;
			_lbl_gen_69.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_69.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_69.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_69.Location = new System.Drawing.Point(351, 12);
			_lbl_gen_69.MinimumSize = new System.Drawing.Size(25, 13);
			_lbl_gen_69.Name = "_lbl_gen_69";
			_lbl_gen_69.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_69.Size = new System.Drawing.Size(25, 13);
			_lbl_gen_69.TabIndex = 264;
			_lbl_gen_69.Text = "State";
			_lbl_gen_69.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_69.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_68
			// 
			_lbl_gen_68.AllowDrop = true;
			_lbl_gen_68.AutoSize = true;
			_lbl_gen_68.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_68.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_68.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_68.Location = new System.Drawing.Point(21, 88);
			_lbl_gen_68.MinimumSize = new System.Drawing.Size(28, 13);
			_lbl_gen_68.Name = "_lbl_gen_68";
			_lbl_gen_68.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_68.Size = new System.Drawing.Size(28, 13);
			_lbl_gen_68.TabIndex = 265;
			_lbl_gen_68.Text = "Name";
			_lbl_gen_68.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_68.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_67
			// 
			_lbl_gen_67.AllowDrop = true;
			_lbl_gen_67.AutoSize = true;
			_lbl_gen_67.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_67.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_67.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_67.Location = new System.Drawing.Point(74, 12);
			_lbl_gen_67.MinimumSize = new System.Drawing.Size(25, 13);
			_lbl_gen_67.Name = "_lbl_gen_67";
			_lbl_gen_67.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_67.Size = new System.Drawing.Size(25, 13);
			_lbl_gen_67.TabIndex = 266;
			_lbl_gen_67.Text = "ICAO";
			_lbl_gen_67.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_67.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_66
			// 
			_lbl_gen_66.AllowDrop = true;
			_lbl_gen_66.AutoSize = true;
			_lbl_gen_66.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_66.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_66.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_66.Location = new System.Drawing.Point(22, 12);
			_lbl_gen_66.MinimumSize = new System.Drawing.Size(24, 13);
			_lbl_gen_66.Name = "_lbl_gen_66";
			_lbl_gen_66.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_66.Size = new System.Drawing.Size(24, 13);
			_lbl_gen_66.TabIndex = 267;
			_lbl_gen_66.Text = "IATA";
			_lbl_gen_66.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_66.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_41
			// 
			_lbl_gen_41.AllowDrop = true;
			_lbl_gen_41.AutoSize = true;
			_lbl_gen_41.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_41.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_41.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_41.Location = new System.Drawing.Point(189, 12);
			_lbl_gen_41.MinimumSize = new System.Drawing.Size(17, 13);
			_lbl_gen_41.Name = "_lbl_gen_41";
			_lbl_gen_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_41.Size = new System.Drawing.Size(17, 13);
			_lbl_gen_41.TabIndex = 268;
			_lbl_gen_41.Text = "City";
			_lbl_gen_41.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_41.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_109
			// 
			_lbl_gen_109.AllowDrop = true;
			_lbl_gen_109.AutoSize = true;
			_lbl_gen_109.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_109.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_109.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_109.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_gen_109.Location = new System.Drawing.Point(335, 53);
			_lbl_gen_109.MinimumSize = new System.Drawing.Size(79, 13);
			_lbl_gen_109.Name = "_lbl_gen_109";
			_lbl_gen_109.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_109.Size = new System.Drawing.Size(79, 13);
			_lbl_gen_109.TabIndex = 349;
			_lbl_gen_109.Text = "Show Airport List";
			_lbl_gen_109.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_109.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_112
			// 
			_lbl_gen_112.AllowDrop = true;
			_lbl_gen_112.AutoSize = true;
			_lbl_gen_112.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_112.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_112.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_112.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_gen_112.Location = new System.Drawing.Point(339, 68);
			_lbl_gen_112.MinimumSize = new System.Drawing.Size(74, 13);
			_lbl_gen_112.Name = "_lbl_gen_112";
			_lbl_gen_112.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_112.Size = new System.Drawing.Size(74, 13);
			_lbl_gen_112.TabIndex = 396;
			_lbl_gen_112.Text = "Clear Base Info";
			_lbl_gen_112.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_112.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_121
			// 
			_lbl_gen_121.AllowDrop = true;
			_lbl_gen_121.AutoSize = true;
			_lbl_gen_121.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_121.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_121.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_121.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_121.Location = new System.Drawing.Point(127, 12);
			_lbl_gen_121.MinimumSize = new System.Drawing.Size(31, 13);
			_lbl_gen_121.Name = "_lbl_gen_121";
			_lbl_gen_121.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_121.Size = new System.Drawing.Size(31, 13);
			_lbl_gen_121.TabIndex = 410;
			_lbl_gen_121.Text = "FAAID";
			_lbl_gen_121.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_121.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_123
			// 
			_lbl_gen_123.AllowDrop = true;
			_lbl_gen_123.AutoSize = true;
			_lbl_gen_123.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_123.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_123.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_123.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_gen_123.Location = new System.Drawing.Point(326, 86);
			_lbl_gen_123.MinimumSize = new System.Drawing.Size(97, 13);
			_lbl_gen_123.Name = "_lbl_gen_123";
			_lbl_gen_123.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_123.Size = new System.Drawing.Size(97, 13);
			_lbl_gen_123.TabIndex = 427;
			_lbl_gen_123.Text = "Flight Data Summary";
			_lbl_gen_123.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_123.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// txtBaseCity
			// 
			txtBaseCity.AcceptsReturn = true;
			txtBaseCity.AllowDrop = true;
			txtBaseCity.BackColor = System.Drawing.SystemColors.Window;
			txtBaseCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtBaseCity.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtBaseCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtBaseCity.ForeColor = System.Drawing.SystemColors.WindowText;
			txtBaseCity.Location = new System.Drawing.Point(189, 27);
			txtBaseCity.MaxLength = 50;
			txtBaseCity.Name = "txtBaseCity";
			txtBaseCity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtBaseCity.Size = new System.Drawing.Size(149, 21);
			txtBaseCity.TabIndex = 259;
			txtBaseCity.DoubleClick += new System.EventHandler(txtBaseCity_DoubleClick);
			// 
			// txtBaseAirportName
			// 
			txtBaseAirportName.AcceptsReturn = true;
			txtBaseAirportName.AllowDrop = true;
			txtBaseAirportName.BackColor = System.Drawing.SystemColors.Window;
			txtBaseAirportName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtBaseAirportName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtBaseAirportName.Enabled = false;
			txtBaseAirportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtBaseAirportName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtBaseAirportName.Location = new System.Drawing.Point(21, 102);
			txtBaseAirportName.MaxLength = 100;
			txtBaseAirportName.Name = "txtBaseAirportName";
			txtBaseAirportName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtBaseAirportName.Size = new System.Drawing.Size(255, 21);
			txtBaseAirportName.TabIndex = 262;
			txtBaseAirportName.DoubleClick += new System.EventHandler(txtBaseAirportName_DoubleClick);
			// 
			// txtICAOCode
			// 
			txtICAOCode.AcceptsReturn = true;
			txtICAOCode.AllowDrop = true;
			txtICAOCode.BackColor = System.Drawing.SystemColors.Window;
			txtICAOCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtICAOCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtICAOCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtICAOCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtICAOCode.Location = new System.Drawing.Point(72, 27);
			txtICAOCode.MaxLength = 4;
			txtICAOCode.Name = "txtICAOCode";
			txtICAOCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtICAOCode.Size = new System.Drawing.Size(49, 21);
			txtICAOCode.TabIndex = 257;
			txtICAOCode.Enter += new System.EventHandler(txtICAOCode_Enter);
			txtICAOCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtICAOCode_KeyPress);
			txtICAOCode.Leave += new System.EventHandler(txtICAOCode_Leave);
			// 
			// txtIATACode
			// 
			txtIATACode.AcceptsReturn = true;
			txtIATACode.AllowDrop = true;
			txtIATACode.BackColor = System.Drawing.SystemColors.Window;
			txtIATACode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtIATACode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtIATACode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtIATACode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtIATACode.Location = new System.Drawing.Point(20, 27);
			txtIATACode.MaxLength = 4;
			txtIATACode.Name = "txtIATACode";
			txtIATACode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtIATACode.Size = new System.Drawing.Size(49, 21);
			txtIATACode.TabIndex = 256;
			txtIATACode.Enter += new System.EventHandler(txtIATACode_Enter);
			txtIATACode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtIATACode_KeyPress);
			txtIATACode.Leave += new System.EventHandler(txtIATACode_Leave);
			// 
			// cboBaseState
			// 
			cboBaseState.AllowDrop = true;
			cboBaseState.BackColor = System.Drawing.SystemColors.Window;
			cboBaseState.CausesValidation = true;
			cboBaseState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboBaseState.Enabled = true;
			cboBaseState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboBaseState.ForeColor = System.Drawing.SystemColors.WindowText;
			cboBaseState.IntegralHeight = true;
			cboBaseState.Location = new System.Drawing.Point(352, 27);
			cboBaseState.Name = "cboBaseState";
			cboBaseState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboBaseState.Size = new System.Drawing.Size(84, 21);
			cboBaseState.Sorted = false;
			cboBaseState.TabIndex = 260;
			cboBaseState.TabStop = true;
			cboBaseState.Visible = true;
			cboBaseState.Enter += new System.EventHandler(cboBaseState_Enter);
			cboBaseState.Leave += new System.EventHandler(cboBaseState_Leave);
			cboBaseState.SelectedIndexChanged += new System.EventHandler(cboBaseState_SelectedIndexChanged);
			// 
			// cboBaseCountry
			// 
			cboBaseCountry.AllowDrop = true;
			cboBaseCountry.BackColor = System.Drawing.SystemColors.Window;
			cboBaseCountry.CausesValidation = true;
			cboBaseCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboBaseCountry.Enabled = true;
			cboBaseCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboBaseCountry.ForeColor = System.Drawing.SystemColors.WindowText;
			cboBaseCountry.IntegralHeight = true;
			cboBaseCountry.Location = new System.Drawing.Point(21, 63);
			cboBaseCountry.Name = "cboBaseCountry";
			cboBaseCountry.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboBaseCountry.Size = new System.Drawing.Size(184, 21);
			cboBaseCountry.Sorted = false;
			cboBaseCountry.TabIndex = 261;
			cboBaseCountry.TabStop = true;
			cboBaseCountry.Visible = true;
			cboBaseCountry.Enter += new System.EventHandler(cboBaseCountry_Enter);
			cboBaseCountry.Leave += new System.EventHandler(cboBaseCountry_Leave);
			cboBaseCountry.SelectedIndexChanged += new System.EventHandler(cboBaseCountry_SelectedIndexChanged);
			// 
			// _chk_ac_aport_private_0
			// 
			_chk_ac_aport_private_0.AllowDrop = true;
			_chk_ac_aport_private_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_ac_aport_private_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_ac_aport_private_0.CausesValidation = true;
			_chk_ac_aport_private_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_aport_private_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_ac_aport_private_0.Enabled = true;
			_chk_ac_aport_private_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_ac_aport_private_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_ac_aport_private_0.Location = new System.Drawing.Point(312, 106);
			_chk_ac_aport_private_0.Name = "_chk_ac_aport_private_0";
			_chk_ac_aport_private_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_ac_aport_private_0.Size = new System.Drawing.Size(54, 14);
			_chk_ac_aport_private_0.TabIndex = 325;
			_chk_ac_aport_private_0.TabStop = true;
			_chk_ac_aport_private_0.Text = "Private";
			_chk_ac_aport_private_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_aport_private_0.Visible = true;
			_chk_ac_aport_private_0.CheckStateChanged += new System.EventHandler(chk_ac_aport_private_CheckStateChanged);
			// 
			// txtFAAIDCode
			// 
			txtFAAIDCode.AcceptsReturn = true;
			txtFAAIDCode.AllowDrop = true;
			txtFAAIDCode.BackColor = System.Drawing.SystemColors.Window;
			txtFAAIDCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtFAAIDCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtFAAIDCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtFAAIDCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtFAAIDCode.Location = new System.Drawing.Point(126, 27);
			txtFAAIDCode.MaxLength = 4;
			txtFAAIDCode.Name = "txtFAAIDCode";
			txtFAAIDCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtFAAIDCode.Size = new System.Drawing.Size(49, 21);
			txtFAAIDCode.TabIndex = 258;
			txtFAAIDCode.Enter += new System.EventHandler(txtFAAIDCode_Enter);
			txtFAAIDCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtFAAIDCode_KeyPress);
			txtFAAIDCode.Leave += new System.EventHandler(txtFAAIDCode_Leave);
			// 
			// _chk_ac_aport_private_2
			// 
			_chk_ac_aport_private_2.AllowDrop = true;
			_chk_ac_aport_private_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_ac_aport_private_2.BackColor = System.Drawing.SystemColors.Control;
			_chk_ac_aport_private_2.CausesValidation = true;
			_chk_ac_aport_private_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_aport_private_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_ac_aport_private_2.Enabled = true;
			_chk_ac_aport_private_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_ac_aport_private_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_ac_aport_private_2.Location = new System.Drawing.Point(376, 106);
			_chk_ac_aport_private_2.Name = "_chk_ac_aport_private_2";
			_chk_ac_aport_private_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_ac_aport_private_2.Size = new System.Drawing.Size(78, 14);
			_chk_ac_aport_private_2.TabIndex = 458;
			_chk_ac_aport_private_2.TabStop = true;
			_chk_ac_aport_private_2.Text = "Transient";
			_chk_ac_aport_private_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_aport_private_2.Visible = true;
			_chk_ac_aport_private_2.CheckStateChanged += new System.EventHandler(chk_ac_aport_private_CheckStateChanged);
			// 
			// _tab_ACMain_TabPage5
			// 
			_tab_ACMain_TabPage5.Controls.Add(frm_aircraft_products);
			_tab_ACMain_TabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_ACMain_TabPage5.Text = "AC Product";
			// 
			// frm_aircraft_products
			// 
			frm_aircraft_products.AllowDrop = true;
			frm_aircraft_products.BackColor = System.Drawing.SystemColors.Control;
			frm_aircraft_products.Controls.Add(_chk_ac_product_3);
			frm_aircraft_products.Controls.Add(_chk_ac_product_5);
			frm_aircraft_products.Controls.Add(_chk_ac_product_4);
			frm_aircraft_products.Controls.Add(_chk_ac_product_2);
			frm_aircraft_products.Controls.Add(_chk_ac_product_1);
			frm_aircraft_products.Controls.Add(_chk_ac_product_0);
			frm_aircraft_products.Controls.Add(_lbl_gen_113);
			frm_aircraft_products.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_aircraft_products.Enabled = true;
			frm_aircraft_products.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_aircraft_products.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_aircraft_products.Location = new System.Drawing.Point(18, 10);
			frm_aircraft_products.Name = "frm_aircraft_products";
			frm_aircraft_products.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_aircraft_products.Size = new System.Drawing.Size(295, 121);
			frm_aircraft_products.TabIndex = 416;
			frm_aircraft_products.Visible = true;
			// 
			// _chk_ac_product_3
			// 
			_chk_ac_product_3.AllowDrop = true;
			_chk_ac_product_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_ac_product_3.BackColor = System.Drawing.SystemColors.Control;
			_chk_ac_product_3.CausesValidation = true;
			_chk_ac_product_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_product_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_ac_product_3.Enabled = true;
			_chk_ac_product_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_ac_product_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_ac_product_3.Location = new System.Drawing.Point(114, 54);
			_chk_ac_product_3.Name = "_chk_ac_product_3";
			_chk_ac_product_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_ac_product_3.Size = new System.Drawing.Size(74, 21);
			_chk_ac_product_3.TabIndex = 422;
			_chk_ac_product_3.TabStop = true;
			_chk_ac_product_3.Text = "ABI";
			_chk_ac_product_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_product_3.Visible = true;
			// 
			// _chk_ac_product_5
			// 
			_chk_ac_product_5.AllowDrop = true;
			_chk_ac_product_5.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_ac_product_5.BackColor = System.Drawing.SystemColors.Control;
			_chk_ac_product_5.CausesValidation = true;
			_chk_ac_product_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_product_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_ac_product_5.Enabled = true;
			_chk_ac_product_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_ac_product_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_ac_product_5.Location = new System.Drawing.Point(114, 76);
			_chk_ac_product_5.Name = "_chk_ac_product_5";
			_chk_ac_product_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_ac_product_5.Size = new System.Drawing.Size(62, 21);
			_chk_ac_product_5.TabIndex = 421;
			_chk_ac_product_5.TabStop = true;
			_chk_ac_product_5.Text = "Regional";
			_chk_ac_product_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_product_5.Visible = true;
			// 
			// _chk_ac_product_4
			// 
			_chk_ac_product_4.AllowDrop = true;
			_chk_ac_product_4.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_ac_product_4.BackColor = System.Drawing.SystemColors.Control;
			_chk_ac_product_4.CausesValidation = true;
			_chk_ac_product_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_product_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_ac_product_4.Enabled = true;
			_chk_ac_product_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_ac_product_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_ac_product_4.Location = new System.Drawing.Point(20, 76);
			_chk_ac_product_4.Name = "_chk_ac_product_4";
			_chk_ac_product_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_ac_product_4.Size = new System.Drawing.Size(49, 21);
			_chk_ac_product_4.TabIndex = 420;
			_chk_ac_product_4.TabStop = true;
			_chk_ac_product_4.Text = "Air BP";
			_chk_ac_product_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_product_4.Visible = true;
			// 
			// _chk_ac_product_2
			// 
			_chk_ac_product_2.AllowDrop = true;
			_chk_ac_product_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_ac_product_2.BackColor = System.Drawing.SystemColors.Control;
			_chk_ac_product_2.CausesValidation = true;
			_chk_ac_product_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_product_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_ac_product_2.Enabled = true;
			_chk_ac_product_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_ac_product_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_ac_product_2.Location = new System.Drawing.Point(20, 54);
			_chk_ac_product_2.Name = "_chk_ac_product_2";
			_chk_ac_product_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_ac_product_2.Size = new System.Drawing.Size(74, 21);
			_chk_ac_product_2.TabIndex = 419;
			_chk_ac_product_2.TabStop = true;
			_chk_ac_product_2.Text = "Commercial";
			_chk_ac_product_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_product_2.Visible = true;
			// 
			// _chk_ac_product_1
			// 
			_chk_ac_product_1.AllowDrop = true;
			_chk_ac_product_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_ac_product_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_ac_product_1.CausesValidation = true;
			_chk_ac_product_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_product_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_ac_product_1.Enabled = true;
			_chk_ac_product_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_ac_product_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_ac_product_1.Location = new System.Drawing.Point(114, 32);
			_chk_ac_product_1.Name = "_chk_ac_product_1";
			_chk_ac_product_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_ac_product_1.Size = new System.Drawing.Size(74, 21);
			_chk_ac_product_1.TabIndex = 418;
			_chk_ac_product_1.TabStop = true;
			_chk_ac_product_1.Text = "Helicopters";
			_chk_ac_product_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_product_1.Visible = true;
			// 
			// _chk_ac_product_0
			// 
			_chk_ac_product_0.AllowDrop = true;
			_chk_ac_product_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_ac_product_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_ac_product_0.CausesValidation = true;
			_chk_ac_product_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_product_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_ac_product_0.Enabled = true;
			_chk_ac_product_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_ac_product_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_ac_product_0.Location = new System.Drawing.Point(20, 32);
			_chk_ac_product_0.Name = "_chk_ac_product_0";
			_chk_ac_product_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_ac_product_0.Size = new System.Drawing.Size(74, 21);
			_chk_ac_product_0.TabIndex = 417;
			_chk_ac_product_0.TabStop = true;
			_chk_ac_product_0.Text = "Business";
			_chk_ac_product_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_ac_product_0.Visible = true;
			// 
			// _lbl_gen_113
			// 
			_lbl_gen_113.AllowDrop = true;
			_lbl_gen_113.AutoSize = true;
			_lbl_gen_113.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_113.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_113.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_113.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_gen_113.Location = new System.Drawing.Point(10, 12);
			_lbl_gen_113.MinimumSize = new System.Drawing.Size(123, 13);
			_lbl_gen_113.Name = "_lbl_gen_113";
			_lbl_gen_113.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_113.Size = new System.Drawing.Size(123, 13);
			_lbl_gen_113.TabIndex = 423;
			_lbl_gen_113.Text = "Aircraft Product Code";
			_lbl_gen_113.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_113.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _pnl_gen_0
			// 
			_pnl_gen_0.AllowDrop = true;
			_pnl_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_pnl_gen_0.Controls.Add(_txt_ac_reg_no_1);
			_pnl_gen_0.Controls.Add(_txt_ac_year_2);
			_pnl_gen_0.Controls.Add(_txt_ac_year_0);
			_pnl_gen_0.Controls.Add(cbo_ac_country_of_registration);
			_pnl_gen_0.Controls.Add(txt_ac_delivery_date);
			_pnl_gen_0.Controls.Add(cbo_ac_use_code);
			_pnl_gen_0.Controls.Add(_txt_ac_alt_ser_no_2);
			_pnl_gen_0.Controls.Add(_txt_ac_alt_ser_no_1);
			_pnl_gen_0.Controls.Add(_txt_ac_alt_ser_no_0);
			_pnl_gen_0.Controls.Add(_txt_ac_ser_no_2);
			_pnl_gen_0.Controls.Add(_txt_ac_ser_no_1);
			_pnl_gen_0.Controls.Add(txt_ac_id);
			_pnl_gen_0.Controls.Add(_txt_ac_ser_no_0);
			_pnl_gen_0.Controls.Add(_txt_ac_reg_no_0);
			_pnl_gen_0.Controls.Add(_txt_ac_year_1);
			_pnl_gen_0.Controls.Add(_lbl_gen_241);
			_pnl_gen_0.Controls.Add(_lbl_gen_5);
			_pnl_gen_0.Controls.Add(_lbl_gen_119);
			_pnl_gen_0.Controls.Add(_lbl_gen_108);
			_pnl_gen_0.Controls.Add(_lbl_gen_17);
			_pnl_gen_0.Controls.Add(_lbl_gen_95);
			_pnl_gen_0.Controls.Add(_lbl_gen_97);
			_pnl_gen_0.Controls.Add(_lbl_gen_30);
			_pnl_gen_0.Controls.Add(_lbl_gen_3);
			_pnl_gen_0.Controls.Add(_lbl_gen_4);
			_pnl_gen_0.Controls.Add(_lbl_gen_240);
			_pnl_gen_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pnl_gen_0.Location = new System.Drawing.Point(206, 55);
			_pnl_gen_0.Name = "_pnl_gen_0";
			_pnl_gen_0.Size = new System.Drawing.Size(303, 161);
			_pnl_gen_0.TabIndex = 94;
			_pnl_gen_0.Click += new System.EventHandler(pnl_gen_Click);
			_pnl_gen_0.DoubleClick += new System.EventHandler(pnl_gen_DoubleClick);
			// 
			// _txt_ac_reg_no_1
			// 
			_txt_ac_reg_no_1.AcceptsReturn = true;
			_txt_ac_reg_no_1.AllowDrop = true;
			_txt_ac_reg_no_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_reg_no_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_ac_reg_no_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_reg_no_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_reg_no_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_reg_no_1.Location = new System.Drawing.Point(65, 89);
			_txt_ac_reg_no_1.MaxLength = 12;
			_txt_ac_reg_no_1.Name = "_txt_ac_reg_no_1";
			_txt_ac_reg_no_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_reg_no_1.Size = new System.Drawing.Size(68, 21);
			_txt_ac_reg_no_1.TabIndex = 407;
			_txt_ac_reg_no_1.Click += new System.EventHandler(txt_ac_reg_no_Click);
			_txt_ac_reg_no_1.DoubleClick += new System.EventHandler(txt_ac_reg_no_DoubleClick);
			// 
			// _txt_ac_year_2
			// 
			_txt_ac_year_2.AcceptsReturn = true;
			_txt_ac_year_2.AllowDrop = true;
			_txt_ac_year_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_year_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_ac_year_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_year_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_year_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_year_2.Location = new System.Drawing.Point(232, 64);
			_txt_ac_year_2.MaxLength = 0;
			_txt_ac_year_2.Name = "_txt_ac_year_2";
			_txt_ac_year_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_year_2.Size = new System.Drawing.Size(65, 19);
			_txt_ac_year_2.TabIndex = 405;
			// 
			// _txt_ac_year_0
			// 
			_txt_ac_year_0.AcceptsReturn = true;
			_txt_ac_year_0.AllowDrop = true;
			_txt_ac_year_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_year_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_ac_year_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_year_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_year_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_year_0.Location = new System.Drawing.Point(210, 90);
			_txt_ac_year_0.MaxLength = 0;
			_txt_ac_year_0.Name = "_txt_ac_year_0";
			_txt_ac_year_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_year_0.Size = new System.Drawing.Size(41, 19);
			_txt_ac_year_0.TabIndex = 404;
			// 
			// cbo_ac_country_of_registration
			// 
			cbo_ac_country_of_registration.AllowDrop = true;
			cbo_ac_country_of_registration.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_country_of_registration.CausesValidation = true;
			cbo_ac_country_of_registration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_country_of_registration.Enabled = true;
			cbo_ac_country_of_registration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_country_of_registration.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_country_of_registration.IntegralHeight = true;
			cbo_ac_country_of_registration.Location = new System.Drawing.Point(168, 136);
			cbo_ac_country_of_registration.Name = "cbo_ac_country_of_registration";
			cbo_ac_country_of_registration.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_country_of_registration.Size = new System.Drawing.Size(137, 21);
			cbo_ac_country_of_registration.Sorted = false;
			cbo_ac_country_of_registration.TabIndex = 344;
			cbo_ac_country_of_registration.TabStop = false;
			cbo_ac_country_of_registration.Visible = true;
			cbo_ac_country_of_registration.SelectedIndexChanged += new System.EventHandler(cbo_ac_country_of_registration_SelectedIndexChanged);
			// 
			// txt_ac_delivery_date
			// 
			txt_ac_delivery_date.AcceptsReturn = true;
			txt_ac_delivery_date.AllowDrop = true;
			txt_ac_delivery_date.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_delivery_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_delivery_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_delivery_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_delivery_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_delivery_date.Location = new System.Drawing.Point(235, 115);
			txt_ac_delivery_date.MaxLength = 0;
			txt_ac_delivery_date.Name = "txt_ac_delivery_date";
			txt_ac_delivery_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_delivery_date.Size = new System.Drawing.Size(65, 19);
			txt_ac_delivery_date.TabIndex = 332;
			txt_ac_delivery_date.Visible = false;
			txt_ac_delivery_date.Leave += new System.EventHandler(txt_ac_delivery_date_Leave);
			// 
			// cbo_ac_use_code
			// 
			cbo_ac_use_code.AllowDrop = true;
			cbo_ac_use_code.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_use_code.CausesValidation = true;
			cbo_ac_use_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_use_code.Enabled = true;
			cbo_ac_use_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_use_code.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_use_code.IntegralHeight = true;
			cbo_ac_use_code.Location = new System.Drawing.Point(64, 113);
			cbo_ac_use_code.Name = "cbo_ac_use_code";
			cbo_ac_use_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_use_code.Size = new System.Drawing.Size(99, 21);
			cbo_ac_use_code.Sorted = false;
			cbo_ac_use_code.TabIndex = 330;
			cbo_ac_use_code.TabStop = false;
			cbo_ac_use_code.Visible = true;
			cbo_ac_use_code.SelectedIndexChanged += new System.EventHandler(cbo_ac_use_code_SelectedIndexChanged);
			cbo_ac_use_code.TextChanged += new System.EventHandler(cbo_ac_use_code_TextChanged);
			// 
			// _txt_ac_alt_ser_no_2
			// 
			_txt_ac_alt_ser_no_2.AcceptsReturn = true;
			_txt_ac_alt_ser_no_2.AllowDrop = true;
			_txt_ac_alt_ser_no_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_alt_ser_no_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_ac_alt_ser_no_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_alt_ser_no_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_alt_ser_no_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_alt_ser_no_2.Location = new System.Drawing.Point(240, 16);
			_txt_ac_alt_ser_no_2.MaxLength = 0;
			_txt_ac_alt_ser_no_2.Name = "_txt_ac_alt_ser_no_2";
			_txt_ac_alt_ser_no_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_alt_ser_no_2.Size = new System.Drawing.Size(58, 21);
			_txt_ac_alt_ser_no_2.TabIndex = 6;
			_txt_ac_alt_ser_no_2.Click += new System.EventHandler(txt_ac_alt_ser_no_Click);
			// 
			// _txt_ac_alt_ser_no_1
			// 
			_txt_ac_alt_ser_no_1.AcceptsReturn = true;
			_txt_ac_alt_ser_no_1.AllowDrop = true;
			_txt_ac_alt_ser_no_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_alt_ser_no_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_ac_alt_ser_no_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_alt_ser_no_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_alt_ser_no_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_alt_ser_no_1.Location = new System.Drawing.Point(170, 16);
			_txt_ac_alt_ser_no_1.MaxLength = 0;
			_txt_ac_alt_ser_no_1.Name = "_txt_ac_alt_ser_no_1";
			_txt_ac_alt_ser_no_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_alt_ser_no_1.Size = new System.Drawing.Size(68, 21);
			_txt_ac_alt_ser_no_1.TabIndex = 5;
			_txt_ac_alt_ser_no_1.Click += new System.EventHandler(txt_ac_alt_ser_no_Click);
			// 
			// _txt_ac_alt_ser_no_0
			// 
			_txt_ac_alt_ser_no_0.AcceptsReturn = true;
			_txt_ac_alt_ser_no_0.AllowDrop = true;
			_txt_ac_alt_ser_no_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_alt_ser_no_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_ac_alt_ser_no_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_alt_ser_no_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_alt_ser_no_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_alt_ser_no_0.Location = new System.Drawing.Point(126, 16);
			_txt_ac_alt_ser_no_0.MaxLength = 0;
			_txt_ac_alt_ser_no_0.Name = "_txt_ac_alt_ser_no_0";
			_txt_ac_alt_ser_no_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_alt_ser_no_0.Size = new System.Drawing.Size(42, 21);
			_txt_ac_alt_ser_no_0.TabIndex = 4;
			_txt_ac_alt_ser_no_0.Click += new System.EventHandler(txt_ac_alt_ser_no_Click);
			// 
			// _txt_ac_ser_no_2
			// 
			_txt_ac_ser_no_2.AcceptsReturn = true;
			_txt_ac_ser_no_2.AllowDrop = true;
			_txt_ac_ser_no_2.BackColor = System.Drawing.SystemColors.Control;
			_txt_ac_ser_no_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_ac_ser_no_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_ser_no_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_ser_no_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_ser_no_2.Location = new System.Drawing.Point(250, 41);
			_txt_ac_ser_no_2.MaxLength = 7;
			_txt_ac_ser_no_2.Name = "_txt_ac_ser_no_2";
			_txt_ac_ser_no_2.ReadOnly = true;
			_txt_ac_ser_no_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_ser_no_2.Size = new System.Drawing.Size(48, 21);
			_txt_ac_ser_no_2.TabIndex = 9;
			_txt_ac_ser_no_2.TabStop = false;
			_txt_ac_ser_no_2.Click += new System.EventHandler(txt_ac_ser_no_Click);
			_txt_ac_ser_no_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_ac_ser_no_KeyPress);
			// 
			// _txt_ac_ser_no_1
			// 
			_txt_ac_ser_no_1.AcceptsReturn = true;
			_txt_ac_ser_no_1.AllowDrop = true;
			_txt_ac_ser_no_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_ser_no_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_ac_ser_no_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_ser_no_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_ser_no_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_ser_no_1.Location = new System.Drawing.Point(178, 41);
			_txt_ac_ser_no_1.MaxLength = 8;
			_txt_ac_ser_no_1.Name = "_txt_ac_ser_no_1";
			_txt_ac_ser_no_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_ser_no_1.Size = new System.Drawing.Size(71, 21);
			_txt_ac_ser_no_1.TabIndex = 8;
			_txt_ac_ser_no_1.Click += new System.EventHandler(txt_ac_ser_no_Click);
			_txt_ac_ser_no_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_ac_ser_no_KeyPress);
			// 
			// txt_ac_id
			// 
			txt_ac_id.AcceptsReturn = true;
			txt_ac_id.AllowDrop = true;
			txt_ac_id.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_ac_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_id.Enabled = false;
			txt_ac_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_id.Location = new System.Drawing.Point(18, 16);
			txt_ac_id.MaxLength = 0;
			txt_ac_id.Name = "txt_ac_id";
			txt_ac_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_id.Size = new System.Drawing.Size(58, 21);
			txt_ac_id.TabIndex = 3;
			txt_ac_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_ac_id.Click += new System.EventHandler(txt_ac_id_Click);
			// 
			// _txt_ac_ser_no_0
			// 
			_txt_ac_ser_no_0.AcceptsReturn = true;
			_txt_ac_ser_no_0.AllowDrop = true;
			_txt_ac_ser_no_0.BackColor = System.Drawing.SystemColors.Control;
			_txt_ac_ser_no_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_ac_ser_no_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_ser_no_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_ser_no_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_ser_no_0.Location = new System.Drawing.Point(119, 41);
			_txt_ac_ser_no_0.MaxLength = 7;
			_txt_ac_ser_no_0.Name = "_txt_ac_ser_no_0";
			_txt_ac_ser_no_0.ReadOnly = true;
			_txt_ac_ser_no_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_ser_no_0.Size = new System.Drawing.Size(53, 21);
			_txt_ac_ser_no_0.TabIndex = 7;
			_txt_ac_ser_no_0.TabStop = false;
			_txt_ac_ser_no_0.Click += new System.EventHandler(txt_ac_ser_no_Click);
			_txt_ac_ser_no_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_ac_ser_no_KeyPress);
			// 
			// _txt_ac_reg_no_0
			// 
			_txt_ac_reg_no_0.AcceptsReturn = true;
			_txt_ac_reg_no_0.AllowDrop = true;
			_txt_ac_reg_no_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_reg_no_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_ac_reg_no_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_reg_no_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_reg_no_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_reg_no_0.Location = new System.Drawing.Point(65, 64);
			_txt_ac_reg_no_0.MaxLength = 12;
			_txt_ac_reg_no_0.Name = "_txt_ac_reg_no_0";
			_txt_ac_reg_no_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_reg_no_0.Size = new System.Drawing.Size(68, 21);
			_txt_ac_reg_no_0.TabIndex = 10;
			_txt_ac_reg_no_0.Click += new System.EventHandler(txt_ac_reg_no_Click);
			_txt_ac_reg_no_0.DoubleClick += new System.EventHandler(txt_ac_reg_no_DoubleClick);
			// 
			// _txt_ac_year_1
			// 
			_txt_ac_year_1.AcceptsReturn = true;
			_txt_ac_year_1.AllowDrop = true;
			_txt_ac_year_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_year_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_ac_year_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_year_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_year_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_year_1.Location = new System.Drawing.Point(256, 89);
			_txt_ac_year_1.MaxLength = 0;
			_txt_ac_year_1.Name = "_txt_ac_year_1";
			_txt_ac_year_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_year_1.Size = new System.Drawing.Size(41, 19);
			_txt_ac_year_1.TabIndex = 11;
			// 
			// _lbl_gen_241
			// 
			_lbl_gen_241.AllowDrop = true;
			_lbl_gen_241.AutoSize = true;
			_lbl_gen_241.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_241.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_241.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_241.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_241.Location = new System.Drawing.Point(8, 91);
			_lbl_gen_241.MinimumSize = new System.Drawing.Size(57, 17);
			_lbl_gen_241.Name = "_lbl_gen_241";
			_lbl_gen_241.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_241.Size = new System.Drawing.Size(57, 17);
			_lbl_gen_241.TabIndex = 409;
			_lbl_gen_241.Text = "Prev Reg#:";
			_lbl_gen_241.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_241.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_5
			// 
			_lbl_gen_5.AllowDrop = true;
			_lbl_gen_5.AutoSize = true;
			_lbl_gen_5.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_5.Location = new System.Drawing.Point(136, 91);
			_lbl_gen_5.MinimumSize = new System.Drawing.Size(81, 17);
			_lbl_gen_5.Name = "_lbl_gen_5";
			_lbl_gen_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_5.Size = new System.Drawing.Size(81, 17);
			_lbl_gen_5.TabIndex = 408;
			_lbl_gen_5.Text = "Year Mfg/Deliv:";
			_lbl_gen_5.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_5.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_119
			// 
			_lbl_gen_119.AllowDrop = true;
			_lbl_gen_119.AutoSize = true;
			_lbl_gen_119.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_119.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_119.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_119.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_119.Location = new System.Drawing.Point(136, 66);
			_lbl_gen_119.MinimumSize = new System.Drawing.Size(104, 13);
			_lbl_gen_119.Name = "_lbl_gen_119";
			_lbl_gen_119.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_119.Size = new System.Drawing.Size(104, 13);
			_lbl_gen_119.TabIndex = 406;
			_lbl_gen_119.Text = "Reg Expiration Date:  ";
			_lbl_gen_119.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_119.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_108
			// 
			_lbl_gen_108.AllowDrop = true;
			_lbl_gen_108.AutoSize = true;
			_lbl_gen_108.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_108.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_108.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_108.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_108.Location = new System.Drawing.Point(5, 142);
			_lbl_gen_108.MinimumSize = new System.Drawing.Size(111, 15);
			_lbl_gen_108.Name = "_lbl_gen_108";
			_lbl_gen_108.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_108.Size = new System.Drawing.Size(111, 15);
			_lbl_gen_108.TabIndex = 343;
			_lbl_gen_108.Text = "Country of Registration:";
			_lbl_gen_108.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_108.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_17
			// 
			_lbl_gen_17.AllowDrop = true;
			_lbl_gen_17.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_17.Location = new System.Drawing.Point(168, 118);
			_lbl_gen_17.MinimumSize = new System.Drawing.Size(68, 13);
			_lbl_gen_17.Name = "_lbl_gen_17";
			_lbl_gen_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_17.Size = new System.Drawing.Size(68, 13);
			_lbl_gen_17.TabIndex = 333;
			_lbl_gen_17.Text = "Deliv. Date:";
			_lbl_gen_17.Visible = false;
			_lbl_gen_17.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_17.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_95
			// 
			_lbl_gen_95.AllowDrop = true;
			_lbl_gen_95.AutoSize = true;
			_lbl_gen_95.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_95.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_95.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_95.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_95.Location = new System.Drawing.Point(28, 117);
			_lbl_gen_95.MinimumSize = new System.Drawing.Size(35, 13);
			_lbl_gen_95.Name = "_lbl_gen_95";
			_lbl_gen_95.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_95.Size = new System.Drawing.Size(35, 13);
			_lbl_gen_95.TabIndex = 331;
			_lbl_gen_95.Text = "Usage:";
			_lbl_gen_95.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_95.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_95.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_97
			// 
			_lbl_gen_97.AllowDrop = true;
			_lbl_gen_97.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_97.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_97.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_97.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_97.Location = new System.Drawing.Point(173, 43);
			_lbl_gen_97.MinimumSize = new System.Drawing.Size(4, 17);
			_lbl_gen_97.Name = "_lbl_gen_97";
			_lbl_gen_97.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_97.Size = new System.Drawing.Size(4, 17);
			_lbl_gen_97.TabIndex = 329;
			_lbl_gen_97.Text = "-";
			_lbl_gen_97.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_97.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_30
			// 
			_lbl_gen_30.AllowDrop = true;
			_lbl_gen_30.AutoSize = true;
			_lbl_gen_30.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_30.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_30.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_30.Location = new System.Drawing.Point(82, 20);
			_lbl_gen_30.MinimumSize = new System.Drawing.Size(42, 13);
			_lbl_gen_30.Name = "_lbl_gen_30";
			_lbl_gen_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_30.Size = new System.Drawing.Size(42, 13);
			_lbl_gen_30.TabIndex = 118;
			_lbl_gen_30.Text = "Alt. S/N:";
			_lbl_gen_30.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_30.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_3
			// 
			_lbl_gen_3.AllowDrop = true;
			_lbl_gen_3.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_3.Location = new System.Drawing.Point(2, 19);
			_lbl_gen_3.MinimumSize = new System.Drawing.Size(15, 17);
			_lbl_gen_3.Name = "_lbl_gen_3";
			_lbl_gen_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_3.Size = new System.Drawing.Size(15, 17);
			_lbl_gen_3.TabIndex = 97;
			_lbl_gen_3.Text = "ID:";
			_lbl_gen_3.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_3.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_4
			// 
			_lbl_gen_4.AllowDrop = true;
			_lbl_gen_4.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_4.Location = new System.Drawing.Point(2, 45);
			_lbl_gen_4.MinimumSize = new System.Drawing.Size(115, 12);
			_lbl_gen_4.Name = "_lbl_gen_4";
			_lbl_gen_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_4.Size = new System.Drawing.Size(115, 12);
			_lbl_gen_4.TabIndex = 96;
			_lbl_gen_4.Text = "Serial# Prefix/No/Suffix:";
			_lbl_gen_4.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_4.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_240
			// 
			_lbl_gen_240.AllowDrop = true;
			_lbl_gen_240.AutoSize = true;
			_lbl_gen_240.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_240.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_240.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_240.ForeColor = System.Drawing.Color.Black;
			_lbl_gen_240.Location = new System.Drawing.Point(8, 68);
			_lbl_gen_240.MinimumSize = new System.Drawing.Size(30, 13);
			_lbl_gen_240.Name = "_lbl_gen_240";
			_lbl_gen_240.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_240.Size = new System.Drawing.Size(30, 13);
			_lbl_gen_240.TabIndex = 95;
			_lbl_gen_240.Text = "Reg#:";
			_lbl_gen_240.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_240.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _pnl_gen_5
			// 
			_pnl_gen_5.AllowDrop = true;
			_pnl_gen_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_pnl_gen_5.Controls.Add(cmd_Save);
			_pnl_gen_5.Controls.Add(txt_ac_model_config);
			_pnl_gen_5.Controls.Add(txtHistoryDate);
			_pnl_gen_5.Controls.Add(txt_amod_type_code);
			_pnl_gen_5.Controls.Add(cbo_amod_make_name);
			_pnl_gen_5.Controls.Add(_lbl_gen_56);
			_pnl_gen_5.Controls.Add(_Label1_0);
			_pnl_gen_5.Controls.Add(_lbl_gen_102);
			_pnl_gen_5.Controls.Add(_lbl_gen_42);
			_pnl_gen_5.Controls.Add(_lbl_gen_84);
			_pnl_gen_5.Controls.Add(_lbl_gen_0);
			_pnl_gen_5.Controls.Add(_lbl_gen_199);
			_pnl_gen_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pnl_gen_5.Location = new System.Drawing.Point(0, 56);
			_pnl_gen_5.Name = "_pnl_gen_5";
			_pnl_gen_5.Size = new System.Drawing.Size(203, 161);
			_pnl_gen_5.TabIndex = 124;
			_pnl_gen_5.Click += new System.EventHandler(pnl_gen_Click);
			_pnl_gen_5.DoubleClick += new System.EventHandler(pnl_gen_DoubleClick);
			// 
			// cmd_Save
			// 
			cmd_Save.AllowDrop = true;
			cmd_Save.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save.Location = new System.Drawing.Point(144, 96);
			cmd_Save.Name = "cmd_Save";
			cmd_Save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save.Size = new System.Drawing.Size(49, 25);
			cmd_Save.TabIndex = 2;
			cmd_Save.Text = "&Save";
			cmd_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save.UseVisualStyleBackColor = false;
			cmd_Save.Visible = false;
			cmd_Save.Click += new System.EventHandler(cmd_Save_Click);
			// 
			// txt_ac_model_config
			// 
			txt_ac_model_config.AcceptsReturn = true;
			txt_ac_model_config.AllowDrop = true;
			txt_ac_model_config.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_model_config.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_model_config.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_model_config.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_model_config.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_model_config.Location = new System.Drawing.Point(80, 98);
			txt_ac_model_config.MaxLength = 6;
			txt_ac_model_config.Name = "txt_ac_model_config";
			txt_ac_model_config.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_model_config.Size = new System.Drawing.Size(41, 19);
			txt_ac_model_config.TabIndex = 346;
			txt_ac_model_config.TabStop = false;
			// 
			// txtHistoryDate
			// 
			txtHistoryDate.AcceptsReturn = true;
			txtHistoryDate.AllowDrop = true;
			txtHistoryDate.BackColor = System.Drawing.SystemColors.Window;
			txtHistoryDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtHistoryDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtHistoryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtHistoryDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtHistoryDate.Location = new System.Drawing.Point(60, 139);
			txtHistoryDate.MaxLength = 0;
			txtHistoryDate.Name = "txtHistoryDate";
			txtHistoryDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtHistoryDate.Size = new System.Drawing.Size(76, 19);
			txtHistoryDate.TabIndex = 276;
			// 
			// txt_amod_type_code
			// 
			txt_amod_type_code.AcceptsReturn = true;
			txt_amod_type_code.AllowDrop = true;
			txt_amod_type_code.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_type_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_amod_type_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_type_code.Enabled = false;
			txt_amod_type_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_type_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_type_code.Location = new System.Drawing.Point(2, 32);
			txt_amod_type_code.MaxLength = 27;
			txt_amod_type_code.Name = "txt_amod_type_code";
			txt_amod_type_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_type_code.Size = new System.Drawing.Size(139, 19);
			txt_amod_type_code.TabIndex = 0;
			txt_amod_type_code.Click += new System.EventHandler(txt_amod_type_code_Click);
			// 
			// cbo_amod_make_name
			// 
			cbo_amod_make_name.AllowDrop = true;
			cbo_amod_make_name.BackColor = System.Drawing.SystemColors.Window;
			cbo_amod_make_name.CausesValidation = true;
			cbo_amod_make_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_amod_make_name.Enabled = false;
			cbo_amod_make_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_amod_make_name.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_amod_make_name.IntegralHeight = true;
			cbo_amod_make_name.Location = new System.Drawing.Point(2, 72);
			cbo_amod_make_name.Name = "cbo_amod_make_name";
			cbo_amod_make_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_amod_make_name.Size = new System.Drawing.Size(193, 21);
			cbo_amod_make_name.Sorted = false;
			cbo_amod_make_name.TabIndex = 1;
			cbo_amod_make_name.TabStop = true;
			cbo_amod_make_name.Visible = true;
			cbo_amod_make_name.SelectedIndexChanged += new System.EventHandler(cbo_amod_make_name_SelectedIndexChanged);
			// 
			// _lbl_gen_56
			// 
			_lbl_gen_56.AllowDrop = true;
			_lbl_gen_56.AutoSize = true;
			_lbl_gen_56.BackColor = System.Drawing.Color.Aqua;
			_lbl_gen_56.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_56.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_56.Location = new System.Drawing.Point(8, 144);
			_lbl_gen_56.MinimumSize = new System.Drawing.Size(182, 13);
			_lbl_gen_56.Name = "_lbl_gen_56";
			_lbl_gen_56.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_56.Size = new System.Drawing.Size(182, 13);
			_lbl_gen_56.TabIndex = 457;
			_lbl_gen_56.Text = "-YOU ARE                           ON TEST-";
			_lbl_gen_56.Visible = false;
			_lbl_gen_56.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_56.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _Label1_0
			// 
			_Label1_0.AllowDrop = true;
			_Label1_0.BackColor = System.Drawing.SystemColors.Control;
			_Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_0.Location = new System.Drawing.Point(2, 99);
			_Label1_0.MinimumSize = new System.Drawing.Size(73, 17);
			_Label1_0.Name = "_Label1_0";
			_Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_0.Size = new System.Drawing.Size(73, 17);
			_Label1_0.TabIndex = 345;
			_Label1_0.Text = "Model Config:";
			// 
			// _lbl_gen_102
			// 
			_lbl_gen_102.AllowDrop = true;
			_lbl_gen_102.AutoSize = true;
			_lbl_gen_102.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_102.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_102.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_102.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_102.Location = new System.Drawing.Point(97, 58);
			_lbl_gen_102.MinimumSize = new System.Drawing.Size(14, 13);
			_lbl_gen_102.Name = "_lbl_gen_102";
			_lbl_gen_102.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_102.Size = new System.Drawing.Size(14, 13);
			_lbl_gen_102.TabIndex = 337;
			_lbl_gen_102.Text = "TT";
			_lbl_gen_102.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_102.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_42
			// 
			_lbl_gen_42.AllowDrop = true;
			_lbl_gen_42.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_42.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_42.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_gen_42.Location = new System.Drawing.Point(140, 10);
			_lbl_gen_42.MinimumSize = new System.Drawing.Size(50, 57);
			_lbl_gen_42.Name = "_lbl_gen_42";
			_lbl_gen_42.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_42.Size = new System.Drawing.Size(50, 57);
			_lbl_gen_42.TabIndex = 125;
			_lbl_gen_42.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_42.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_42.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_84
			// 
			_lbl_gen_84.AllowDrop = true;
			_lbl_gen_84.AutoSize = true;
			_lbl_gen_84.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_84.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_84.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_84.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_84.Location = new System.Drawing.Point(2, 58);
			_lbl_gen_84.MinimumSize = new System.Drawing.Size(70, 13);
			_lbl_gen_84.Name = "_lbl_gen_84";
			_lbl_gen_84.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_84.Size = new System.Drawing.Size(70, 13);
			_lbl_gen_84.TabIndex = 128;
			_lbl_gen_84.Text = "Make / Model:";
			_lbl_gen_84.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_84.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_0
			// 
			_lbl_gen_0.AllowDrop = true;
			_lbl_gen_0.AutoSize = true;
			_lbl_gen_0.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_0.Location = new System.Drawing.Point(2, 16);
			_lbl_gen_0.MinimumSize = new System.Drawing.Size(30, 13);
			_lbl_gen_0.Name = "_lbl_gen_0";
			_lbl_gen_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_0.Size = new System.Drawing.Size(30, 13);
			_lbl_gen_0.TabIndex = 127;
			_lbl_gen_0.Text = "Type: ";
			_lbl_gen_0.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_0.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// _lbl_gen_199
			// 
			_lbl_gen_199.AllowDrop = true;
			_lbl_gen_199.AutoSize = true;
			_lbl_gen_199.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_199.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_199.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_199.ForeColor = System.Drawing.Color.Maroon;
			_lbl_gen_199.Location = new System.Drawing.Point(28, 122);
			_lbl_gen_199.MinimumSize = new System.Drawing.Size(155, 16);
			_lbl_gen_199.Name = "_lbl_gen_199";
			_lbl_gen_199.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_199.Size = new System.Drawing.Size(155, 16);
			_lbl_gen_199.TabIndex = 126;
			_lbl_gen_199.Text = "CURRENT AIRCRAFT";
			_lbl_gen_199.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_199.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_199.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// acTimer1
			// 
			acTimer1.Enabled = false;
			acTimer1.Interval = 1;
			acTimer1.Tick += new System.EventHandler(acTimer1_Tick);
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
			tbr_ToolBar.Size = new System.Drawing.Size(1011, 28);
			tbr_ToolBar.TabIndex = 98;
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
			// pnl_Please_Wait
			// 
			pnl_Please_Wait.AllowDrop = true;
			pnl_Please_Wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Please_Wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Please_Wait.Controls.Add(_lbl_gen_85);
			pnl_Please_Wait.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Please_Wait.Location = new System.Drawing.Point(242, 307);
			pnl_Please_Wait.Name = "pnl_Please_Wait";
			pnl_Please_Wait.Size = new System.Drawing.Size(521, 120);
			pnl_Please_Wait.TabIndex = 269;
			pnl_Please_Wait.Visible = false;
			// 
			// _lbl_gen_85
			// 
			_lbl_gen_85.AllowDrop = true;
			_lbl_gen_85.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_85.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_85.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_85.ForeColor = System.Drawing.Color.Maroon;
			_lbl_gen_85.Location = new System.Drawing.Point(187, 58);
			_lbl_gen_85.MinimumSize = new System.Drawing.Size(153, 27);
			_lbl_gen_85.Name = "_lbl_gen_85";
			_lbl_gen_85.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_85.Size = new System.Drawing.Size(153, 27);
			_lbl_gen_85.TabIndex = 270;
			_lbl_gen_85.Text = "PLEASE WAIT!";
			_lbl_gen_85.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_85.Click += new System.EventHandler(lbl_gen_Click);
			_lbl_gen_85.DoubleClick += new System.EventHandler(lbl_gen_DoubleClick);
			// 
			// frm_aircraft
			// 
			AcceptButton = _cmd_Av_Add_1;
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(1011, 711);
			ControlBox = false;
			Controls.Add(tab_aircraft_details);
			Controls.Add(tab_ACMain);
			Controls.Add(_pnl_gen_0);
			Controls.Add(_pnl_gen_5);
			Controls.Add(tbr_ToolBar);
			Controls.Add(pnl_Please_Wait);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			KeyPreview = true;
			Location = new System.Drawing.Point(318, 249);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_aircraft";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Aircraft Details";
			Visible = false;
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(_cmdHelicopter_0, 0);
			commandButtonHelper1.SetStyle(_cmdHelicopter_1, 0);
			commandButtonHelper1.SetStyle(_cmd_Add_Cert_2, 0);
			commandButtonHelper1.SetStyle(_cmd_Add_Cert_0, 0);
			commandButtonHelper1.SetStyle(_cmdAddACDetail_6, 0);
			commandButtonHelper1.SetStyle(_cmdAddACDetail_3, 0);
			commandButtonHelper1.SetStyle(_cmd_Add_Cert_1, 0);
			commandButtonHelper1.SetStyle(_cmdAddACDetail_0, 0);
			commandButtonHelper1.SetStyle(_cmdAddACDetail_1, 0);
			commandButtonHelper1.SetStyle(_cmdAddACDetail_2, 0);
			commandButtonHelper1.SetStyle(_cmdAddACDetail_4, 0);
			commandButtonHelper1.SetStyle(_cmd_Av_Add_0, 0);
			commandButtonHelper1.SetStyle(_cmd_Av_Add_2, 0);
			commandButtonHelper1.SetStyle(_cmd_Av_Add_3, 0);
			commandButtonHelper1.SetStyle(_cmd_Av_Add_1, 0);
			commandButtonHelper1.SetStyle(_cmdAddACDetail_10, 0);
			commandButtonHelper1.SetStyle(_cmdAddACDetail_8, 0);
			commandButtonHelper1.SetStyle(_cmdAddACDetail_7, 0);
			commandButtonHelper1.SetStyle(cmd_Primary, 0);
			commandButtonHelper1.SetStyle(cmd_Confirm_Company, 0);
			commandButtonHelper1.SetStyle(cmd_AssociateCompany, 0);
			commandButtonHelper1.SetStyle(cmd_Remove_Association, 0);
			commandButtonHelper1.SetStyle(cmd_Set_As_Exclusive, 0);
			commandButtonHelper1.SetStyle(cmd_Clear_Exclusive_Confirmation_Company, 0);
			commandButtonHelper1.SetStyle(_cmdAddACDetail_5, 0);
			commandButtonHelper1.SetStyle(_cmdSaveLease_0, 0);
			commandButtonHelper1.SetStyle(_cmdSaveLease_1, 0);
			commandButtonHelper1.SetStyle(cmd_jcat_Redisplay_Journal_List, 0);
			commandButtonHelper1.SetStyle(_cmdSaveDocNotes_4, 0);
			commandButtonHelper1.SetStyle(_cmdSaveDocNotes_3, 0);
			commandButtonHelper1.SetStyle(_cmdSaveDocNotes_2, 0);
			commandButtonHelper1.SetStyle(cmd_DocsInProcessRefresh, 0);
			commandButtonHelper1.SetStyle(cmdViewDocumentInSeparateWindow, 0);
			commandButtonHelper1.SetStyle(_cmdSaveDocNotes_0, 0);
			commandButtonHelper1.SetStyle(cmdFinancialDocuments, 0);
			commandButtonHelper1.SetStyle(_cmdSaveDocNotes_6, 0);
			commandButtonHelper1.SetStyle(_cmdSaveDocNotes_5, 0);
			commandButtonHelper1.SetStyle(_cmdSaveDocNotes_1, 0);
			commandButtonHelper1.SetStyle(cmd_set_mapping_flag, 0);
			commandButtonHelper1.SetStyle(_cmdAddACDetail_9, 0);
			commandButtonHelper1.SetStyle(cmdModifyTransaction, 0);
			commandButtonHelper1.SetStyle(cmdRetrieveSpecs, 0);
			commandButtonHelper1.SetStyle(cmd_Active, 0);
			commandButtonHelper1.SetStyle(cmdClearResearchAction, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel, 0);
			commandButtonHelper1.SetStyle(cmd_Journal_Note_Cancel, 0);
			commandButtonHelper1.SetStyle(cmd_Journal_Note_Save, 0);
			commandButtonHelper1.SetStyle(cmd_Save, 0);
			listBoxComboBoxHelper1.SetItemData(ac_mapping_list, new int[]{0, 0, 0});
			listBoxHelper1.SetSelectionMode(lst_Avionics, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Company, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Contact, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lstAcPictures, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(ac_mapping_list, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Research_Action, System.Windows.Forms.SelectionMode.One);
			ToolTipMain.SetToolTip(cmdViewDocumentInSeparateWindow, "Click To Open Document In Form");
			ToolTipMain.SetToolTip(_lbl_gen_124, "Click To Attach Document To A Company Record");
			ToolTipMain.SetToolTip(_lbl_gen_122, "Click To Open Document In Browser");
			ToolTipMain.SetToolTip(_lbl_gen_63, "Double Click to Find AC ID ");
			ToolTipMain.SetToolTip(_chkArray_2, "Check if JETNET is authorized to display this sale price by source.");
			ToolTipMain.SetToolTip(_lbl_gen_75, "Days on Market");
			ToolTipMain.SetToolTip(_lbl_gen_123, "Click To Show Flight Data Summary");
			ToolTipMain.SetToolTip(_txt_ac_reg_no_0, "Double Click To EMail RegNbr Request To FAA");
			ToolTipMain.SetToolTip(_lbl_gen_84, "Double Click to Activate the Make/Model Pull Down");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			Enter += new System.EventHandler(Form_Enter);
			KeyDown += new System.Windows.Forms.KeyEventHandler(Form_KeyDown);
			KeyPress += new System.Windows.Forms.KeyPressEventHandler(Form_KeyPress);
			((System.ComponentModel.ISupportInitialize) _grd_Features_4).EndInit();
			((System.ComponentModel.ISupportInitialize) GrdHelicopter).EndInit();
			((System.ComponentModel.ISupportInitialize) _grd_Features_0).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_aircraftdamage).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Maintenance).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Aircraft_Certified).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_maint).EndInit();
			((System.ComponentModel.ISupportInitialize) _grd_Features_1).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Exterior).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Interior).EndInit();
			((System.ComponentModel.ISupportInitialize) _grd_Features_2).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Equipment).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_AircraftAvionics).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Cockpit).EndInit();
			((System.ComponentModel.ISupportInitialize) _grd_Features_3).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_AircraftContacts).EndInit();
			((System.ComponentModel.ISupportInitialize) grdLeaseInfo).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Aircraft_Journal).EndInit();
			((System.ComponentModel.ISupportInitialize) _grd_pubs_1).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_DocumentLog).EndInit();
			((System.ComponentModel.ISupportInitialize) grdTransactionDocuments).EndInit();
			((System.ComponentModel.ISupportInitialize) grdAircraftDocuments).EndInit();
			((System.ComponentModel.ISupportInitialize) _grd_pubs_0).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_AircraftKeyFeatures).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_AircraftHistory).EndInit();
			((System.ComponentModel.ISupportInitialize) listBoxComboBoxHelper1).EndInit();
			tab_aircraft_details.ResumeLayout(false);
			tab_aircraft_details.PerformLayout();
			_tab_aircraft_details_TabPage0.ResumeLayout(false);
			_tab_aircraft_details_TabPage0.PerformLayout();
			_tab_aircraft_details_TabPage1.ResumeLayout(false);
			_tab_aircraft_details_TabPage1.PerformLayout();
			pnl_certifications.ResumeLayout(false);
			pnl_certifications.PerformLayout();
			_tab_aircraft_details_TabPage2.ResumeLayout(false);
			_tab_aircraft_details_TabPage2.PerformLayout();
			_tab_aircraft_details_TabPage3.ResumeLayout(false);
			_tab_aircraft_details_TabPage3.PerformLayout();
			_tab_aircraft_details_TabPage4.ResumeLayout(false);
			_tab_aircraft_details_TabPage4.PerformLayout();
			pnl_Cockpit.ResumeLayout(false);
			pnl_Cockpit.PerformLayout();
			pnl_Av.ResumeLayout(false);
			pnl_Av.PerformLayout();
			_tab_aircraft_details_TabPage5.ResumeLayout(false);
			_tab_aircraft_details_TabPage5.PerformLayout();
			_pnl_gen_1.ResumeLayout(false);
			_pnl_gen_1.PerformLayout();
			_pnl_gen_4.ResumeLayout(false);
			_pnl_gen_4.PerformLayout();
			pnl_LeaseEntry.ResumeLayout(false);
			pnl_LeaseEntry.PerformLayout();
			pnl_LeaseList.ResumeLayout(false);
			pnl_LeaseList.PerformLayout();
			_tab_aircraft_details_TabPage6.ResumeLayout(false);
			_tab_aircraft_details_TabPage6.PerformLayout();
			_tab_aircraft_details_TabPage7.ResumeLayout(false);
			_tab_aircraft_details_TabPage7.PerformLayout();
			_tab_aircraft_details_TabPage8.ResumeLayout(false);
			_tab_aircraft_details_TabPage8.PerformLayout();
			_tab_aircraft_details_TabPage9.ResumeLayout(false);
			_tab_aircraft_details_TabPage9.PerformLayout();
			_tab_aircraft_details_TabPage10.ResumeLayout(false);
			_tab_aircraft_details_TabPage10.PerformLayout();
			pnl_TransactionNotes.ResumeLayout(false);
			pnl_TransactionNotes.PerformLayout();
			_tab_aircraft_details_TabPage11.ResumeLayout(false);
			_tab_aircraft_details_TabPage11.PerformLayout();
			_tab_aircraft_details_TabPage12.ResumeLayout(false);
			_tab_aircraft_details_TabPage12.PerformLayout();
			_tab_aircraft_details_TabPage13.ResumeLayout(false);
			_tab_aircraft_details_TabPage13.PerformLayout();
			_tab_aircraft_details_TabPage14.ResumeLayout(false);
			_tab_aircraft_details_TabPage14.PerformLayout();
			tab_ACMain.ResumeLayout(false);
			tab_ACMain.PerformLayout();
			_tab_ACMain_TabPage0.ResumeLayout(false);
			_tab_ACMain_TabPage0.PerformLayout();
			pnl_Sale_Data.ResumeLayout(false);
			pnl_Sale_Data.PerformLayout();
			_tab_ACMain_TabPage1.ResumeLayout(false);
			_tab_ACMain_TabPage1.PerformLayout();
			_tab_ACMain_TabPage2.ResumeLayout(false);
			_tab_ACMain_TabPage2.PerformLayout();
			_tab_ACMain_TabPage3.ResumeLayout(false);
			_tab_ACMain_TabPage3.PerformLayout();
			pnl_Research_Action.ResumeLayout(false);
			pnl_Research_Action.PerformLayout();
			pnl_Journal.ResumeLayout(false);
			pnl_Journal.PerformLayout();
			_tab_ACMain_TabPage4.ResumeLayout(false);
			_tab_ACMain_TabPage4.PerformLayout();
			_tab_ACMain_TabPage5.ResumeLayout(false);
			_tab_ACMain_TabPage5.PerformLayout();
			frm_aircraft_products.ResumeLayout(false);
			frm_aircraft_products.PerformLayout();
			_pnl_gen_0.ResumeLayout(false);
			_pnl_gen_0.PerformLayout();
			_pnl_gen_5.ResumeLayout(false);
			_pnl_gen_5.PerformLayout();
			tbr_ToolBar.ResumeLayout(false);
			tbr_ToolBar.PerformLayout();
			pnl_Please_Wait.ResumeLayout(false);
			pnl_Please_Wait.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializetxt_gen();
			Initializetxt_acfaa_reg_status();
			Initializetxt_acfaa_reg_no();
			Initializetxt_acfaa_party_comp_name();
			Initializetxt_ac_year();
			Initializetxt_ac_ser_no();
			Initializetxt_ac_reg_no();
			Initializetxt_ac_prop_soh_year();
			Initializetxt_ac_prop_soh_mo();
			Initializetxt_ac_prop_soh_hrs();
			Initializetxt_ac_prop_snew_hrs();
			Initializetxt_ac_prop_ser_no();
			Initializetxt_ac_lease_type();
			Initializetxt_ac_engine_tot_hrs();
			Initializetxt_ac_engine_tbo_hrs();
			Initializetxt_ac_engine_soh_hrs();
			Initializetxt_ac_engine_soh_cycles();
			Initializetxt_ac_engine_snew_cycles();
			Initializetxt_ac_engine_shs_cycles();
			Initializetxt_ac_engine_shi_hrs();
			Initializetxt_ac_engine_ser_no();
			Initializetxt_ac_apu();
			Initializetxt_ac_alt_ser_no();
			InitializetxtDocNotes();
			Initializepnl_gen();
			InitializemnuChangeContactType();
			Initializelbl_gen();
			Initializegrd_pubs();
			Initializegrd_Features();
			Initializecmd_Av_Add();
			Initializecmd_Add_Cert();
			InitializecmdSaveLease();
			InitializecmdSaveDocNotes();
			InitializecmdHelicopter();
			InitializecmdAddACDetail();
			Initializechk_ac_product();
			Initializechk_ac_aport_private();
			InitializechkArray();
			Initializecbo_drop_array();
			InitializecboAcctRep();
			InitializeLabel1();
			tab_Aircraft_DetailsPreviousTab = tab_aircraft_details.SelectedIndex; // gap-note. Check if tab_aircraft_details is correct. Not sure if due to change the name changed and is pointing to other tab in other form.
			tab_ACMainPreviousTab = tab_ACMain.SelectedIndex;
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = JETNET_Homebase.mdi_ResearchAssistant.DefInstance;
			JETNET_Homebase.mdi_ResearchAssistant.DefInstance.Show();
			Form_Initialize();
		}
		void Initializetxt_gen()
		{
			txt_gen = new System.Windows.Forms.TextBox[5];
			txt_gen[4] = _txt_gen_4;
			txt_gen[3] = _txt_gen_3;
			txt_gen[2] = _txt_gen_2;
			txt_gen[1] = _txt_gen_1;
			txt_gen[0] = _txt_gen_0;
		}
		void Initializetxt_acfaa_reg_status()
		{
			txt_acfaa_reg_status = new System.Windows.Forms.TextBox[4];
			txt_acfaa_reg_status[0] = _txt_acfaa_reg_status_0;
			txt_acfaa_reg_status[1] = _txt_acfaa_reg_status_1;
			txt_acfaa_reg_status[2] = _txt_acfaa_reg_status_2;
			txt_acfaa_reg_status[3] = _txt_acfaa_reg_status_3;
		}
		void Initializetxt_acfaa_reg_no()
		{
			txt_acfaa_reg_no = new System.Windows.Forms.TextBox[4];
			txt_acfaa_reg_no[0] = _txt_acfaa_reg_no_0;
			txt_acfaa_reg_no[1] = _txt_acfaa_reg_no_1;
			txt_acfaa_reg_no[2] = _txt_acfaa_reg_no_2;
			txt_acfaa_reg_no[3] = _txt_acfaa_reg_no_3;
		}
		void Initializetxt_acfaa_party_comp_name()
		{
			txt_acfaa_party_comp_name = new System.Windows.Forms.TextBox[10];
			txt_acfaa_party_comp_name[0] = _txt_acfaa_party_comp_name_0;
			txt_acfaa_party_comp_name[1] = _txt_acfaa_party_comp_name_1;
			txt_acfaa_party_comp_name[2] = _txt_acfaa_party_comp_name_2;
			txt_acfaa_party_comp_name[3] = _txt_acfaa_party_comp_name_3;
			txt_acfaa_party_comp_name[4] = _txt_acfaa_party_comp_name_4;
			txt_acfaa_party_comp_name[5] = _txt_acfaa_party_comp_name_5;
			txt_acfaa_party_comp_name[6] = _txt_acfaa_party_comp_name_6;
			txt_acfaa_party_comp_name[7] = _txt_acfaa_party_comp_name_7;
			txt_acfaa_party_comp_name[8] = _txt_acfaa_party_comp_name_8;
			txt_acfaa_party_comp_name[9] = _txt_acfaa_party_comp_name_9;
		}
		void Initializetxt_ac_year()
		{
			txt_ac_year = new System.Windows.Forms.TextBox[3];
			txt_ac_year[2] = _txt_ac_year_2;
			txt_ac_year[0] = _txt_ac_year_0;
			txt_ac_year[1] = _txt_ac_year_1;
		}
		void Initializetxt_ac_ser_no()
		{
			txt_ac_ser_no = new System.Windows.Forms.TextBox[3];
			txt_ac_ser_no[2] = _txt_ac_ser_no_2;
			txt_ac_ser_no[1] = _txt_ac_ser_no_1;
			txt_ac_ser_no[0] = _txt_ac_ser_no_0;
		}
		void Initializetxt_ac_reg_no()
		{
			txt_ac_reg_no = new System.Windows.Forms.TextBox[2];
			txt_ac_reg_no[1] = _txt_ac_reg_no_1;
			txt_ac_reg_no[0] = _txt_ac_reg_no_0;
		}
		void Initializetxt_ac_prop_soh_year()
		{
			txt_ac_prop_soh_year = new System.Windows.Forms.TextBox[4];
			txt_ac_prop_soh_year[0] = _txt_ac_prop_soh_year_0;
			txt_ac_prop_soh_year[1] = _txt_ac_prop_soh_year_1;
			txt_ac_prop_soh_year[3] = _txt_ac_prop_soh_year_3;
			txt_ac_prop_soh_year[2] = _txt_ac_prop_soh_year_2;
		}
		void Initializetxt_ac_prop_soh_mo()
		{
			txt_ac_prop_soh_mo = new System.Windows.Forms.TextBox[4];
			txt_ac_prop_soh_mo[1] = _txt_ac_prop_soh_mo_1;
			txt_ac_prop_soh_mo[0] = _txt_ac_prop_soh_mo_0;
			txt_ac_prop_soh_mo[2] = _txt_ac_prop_soh_mo_2;
			txt_ac_prop_soh_mo[3] = _txt_ac_prop_soh_mo_3;
		}
		void Initializetxt_ac_prop_soh_hrs()
		{
			txt_ac_prop_soh_hrs = new System.Windows.Forms.TextBox[4];
			txt_ac_prop_soh_hrs[3] = _txt_ac_prop_soh_hrs_3;
			txt_ac_prop_soh_hrs[2] = _txt_ac_prop_soh_hrs_2;
			txt_ac_prop_soh_hrs[0] = _txt_ac_prop_soh_hrs_0;
			txt_ac_prop_soh_hrs[1] = _txt_ac_prop_soh_hrs_1;
		}
		void Initializetxt_ac_prop_snew_hrs()
		{
			txt_ac_prop_snew_hrs = new System.Windows.Forms.TextBox[4];
			txt_ac_prop_snew_hrs[3] = _txt_ac_prop_snew_hrs_3;
			txt_ac_prop_snew_hrs[2] = _txt_ac_prop_snew_hrs_2;
			txt_ac_prop_snew_hrs[0] = _txt_ac_prop_snew_hrs_0;
			txt_ac_prop_snew_hrs[1] = _txt_ac_prop_snew_hrs_1;
		}
		void Initializetxt_ac_prop_ser_no()
		{
			txt_ac_prop_ser_no = new System.Windows.Forms.TextBox[4];
			txt_ac_prop_ser_no[1] = _txt_ac_prop_ser_no_1;
			txt_ac_prop_ser_no[0] = _txt_ac_prop_ser_no_0;
			txt_ac_prop_ser_no[2] = _txt_ac_prop_ser_no_2;
			txt_ac_prop_ser_no[3] = _txt_ac_prop_ser_no_3;
		}
		void Initializetxt_ac_lease_type()
		{
			txt_ac_lease_type = new System.Windows.Forms.TextBox[3];
			txt_ac_lease_type[2] = _txt_ac_lease_type_2;
			txt_ac_lease_type[1] = _txt_ac_lease_type_1;
			txt_ac_lease_type[0] = _txt_ac_lease_type_0;
		}
		void Initializetxt_ac_engine_tot_hrs()
		{
			txt_ac_engine_tot_hrs = new System.Windows.Forms.TextBox[4];
			txt_ac_engine_tot_hrs[3] = _txt_ac_engine_tot_hrs_3;
			txt_ac_engine_tot_hrs[2] = _txt_ac_engine_tot_hrs_2;
			txt_ac_engine_tot_hrs[1] = _txt_ac_engine_tot_hrs_1;
			txt_ac_engine_tot_hrs[0] = _txt_ac_engine_tot_hrs_0;
		}
		void Initializetxt_ac_engine_tbo_hrs()
		{
			txt_ac_engine_tbo_hrs = new System.Windows.Forms.TextBox[4];
			txt_ac_engine_tbo_hrs[3] = _txt_ac_engine_tbo_hrs_3;
			txt_ac_engine_tbo_hrs[2] = _txt_ac_engine_tbo_hrs_2;
			txt_ac_engine_tbo_hrs[1] = _txt_ac_engine_tbo_hrs_1;
			txt_ac_engine_tbo_hrs[0] = _txt_ac_engine_tbo_hrs_0;
		}
		void Initializetxt_ac_engine_soh_hrs()
		{
			txt_ac_engine_soh_hrs = new System.Windows.Forms.TextBox[4];
			txt_ac_engine_soh_hrs[3] = _txt_ac_engine_soh_hrs_3;
			txt_ac_engine_soh_hrs[2] = _txt_ac_engine_soh_hrs_2;
			txt_ac_engine_soh_hrs[1] = _txt_ac_engine_soh_hrs_1;
			txt_ac_engine_soh_hrs[0] = _txt_ac_engine_soh_hrs_0;
		}
		void Initializetxt_ac_engine_soh_cycles()
		{
			txt_ac_engine_soh_cycles = new System.Windows.Forms.TextBox[4];
			txt_ac_engine_soh_cycles[0] = _txt_ac_engine_soh_cycles_0;
			txt_ac_engine_soh_cycles[1] = _txt_ac_engine_soh_cycles_1;
			txt_ac_engine_soh_cycles[2] = _txt_ac_engine_soh_cycles_2;
			txt_ac_engine_soh_cycles[3] = _txt_ac_engine_soh_cycles_3;
		}
		void Initializetxt_ac_engine_snew_cycles()
		{
			txt_ac_engine_snew_cycles = new System.Windows.Forms.TextBox[4];
			txt_ac_engine_snew_cycles[0] = _txt_ac_engine_snew_cycles_0;
			txt_ac_engine_snew_cycles[1] = _txt_ac_engine_snew_cycles_1;
			txt_ac_engine_snew_cycles[2] = _txt_ac_engine_snew_cycles_2;
			txt_ac_engine_snew_cycles[3] = _txt_ac_engine_snew_cycles_3;
		}
		void Initializetxt_ac_engine_shs_cycles()
		{
			txt_ac_engine_shs_cycles = new System.Windows.Forms.TextBox[4];
			txt_ac_engine_shs_cycles[0] = _txt_ac_engine_shs_cycles_0;
			txt_ac_engine_shs_cycles[1] = _txt_ac_engine_shs_cycles_1;
			txt_ac_engine_shs_cycles[2] = _txt_ac_engine_shs_cycles_2;
			txt_ac_engine_shs_cycles[3] = _txt_ac_engine_shs_cycles_3;
		}
		void Initializetxt_ac_engine_shi_hrs()
		{
			txt_ac_engine_shi_hrs = new System.Windows.Forms.TextBox[4];
			txt_ac_engine_shi_hrs[3] = _txt_ac_engine_shi_hrs_3;
			txt_ac_engine_shi_hrs[2] = _txt_ac_engine_shi_hrs_2;
			txt_ac_engine_shi_hrs[1] = _txt_ac_engine_shi_hrs_1;
			txt_ac_engine_shi_hrs[0] = _txt_ac_engine_shi_hrs_0;
		}
		void Initializetxt_ac_engine_ser_no()
		{
			txt_ac_engine_ser_no = new System.Windows.Forms.TextBox[4];
			txt_ac_engine_ser_no[0] = _txt_ac_engine_ser_no_0;
			txt_ac_engine_ser_no[1] = _txt_ac_engine_ser_no_1;
			txt_ac_engine_ser_no[2] = _txt_ac_engine_ser_no_2;
			txt_ac_engine_ser_no[3] = _txt_ac_engine_ser_no_3;
		}
		void Initializetxt_ac_apu()
		{
			txt_ac_apu = new System.Windows.Forms.TextBox[3];
			txt_ac_apu[2] = _txt_ac_apu_2;
			txt_ac_apu[1] = _txt_ac_apu_1;
			txt_ac_apu[0] = _txt_ac_apu_0;
		}
		void Initializetxt_ac_alt_ser_no()
		{
			txt_ac_alt_ser_no = new System.Windows.Forms.TextBox[3];
			txt_ac_alt_ser_no[2] = _txt_ac_alt_ser_no_2;
			txt_ac_alt_ser_no[1] = _txt_ac_alt_ser_no_1;
			txt_ac_alt_ser_no[0] = _txt_ac_alt_ser_no_0;
		}
		void InitializetxtDocNotes()
		{
			txtDocNotes = new System.Windows.Forms.TextBox[4];
			txtDocNotes[0] = _txtDocNotes_0;
			txtDocNotes[3] = _txtDocNotes_3;
			txtDocNotes[2] = _txtDocNotes_2;
			txtDocNotes[1] = _txtDocNotes_1;
		}
		void Initializepnl_gen()
		{
			pnl_gen = new System.Windows.Forms.Panel[6];
			pnl_gen[1] = _pnl_gen_1;
			pnl_gen[4] = _pnl_gen_4;
			pnl_gen[0] = _pnl_gen_0;
			pnl_gen[5] = _pnl_gen_5;
		}
		void InitializemnuChangeContactType()
		{
			mnuChangeContactType = new System.Windows.Forms.ToolStripItem[97];
			mnuChangeContactType[0] = _mnuChangeContactType_0;
			mnuChangeContactType[8] = _mnuChangeContactType_8;
			mnuChangeContactType[12] = _mnuChangeContactType_12;
			mnuChangeContactType[13] = _mnuChangeContactType_13;
			mnuChangeContactType[27] = _mnuChangeContactType_27;
			mnuChangeContactType[39] = _mnuChangeContactType_39;
			mnuChangeContactType[51] = _mnuChangeContactType_51;
			mnuChangeContactType[52] = _mnuChangeContactType_52;
			mnuChangeContactType[53] = _mnuChangeContactType_53;
			mnuChangeContactType[54] = _mnuChangeContactType_54;
			mnuChangeContactType[56] = _mnuChangeContactType_56;
			mnuChangeContactType[60] = _mnuChangeContactType_60;
			mnuChangeContactType[61] = _mnuChangeContactType_61;
			mnuChangeContactType[62] = _mnuChangeContactType_62;
			mnuChangeContactType[69] = _mnuChangeContactType_69;
			mnuChangeContactType[70] = _mnuChangeContactType_70;
			mnuChangeContactType[91] = _mnuChangeContactType_91;
			mnuChangeContactType[95] = _mnuChangeContactType_95;
			mnuChangeContactType[96] = _mnuChangeContactType_96;
		}
		void Initializelbl_gen()
		{
			lbl_gen = new System.Windows.Forms.Label[264];
			lbl_gen[48] = _lbl_gen_48;
			lbl_gen[16] = _lbl_gen_16;
			lbl_gen[101] = _lbl_gen_101;
			lbl_gen[82] = _lbl_gen_82;
			lbl_gen[224] = _lbl_gen_224;
			lbl_gen[218] = _lbl_gen_218;
			lbl_gen[190] = _lbl_gen_190;
			lbl_gen[217] = _lbl_gen_217;
			lbl_gen[38] = _lbl_gen_38;
			lbl_gen[37] = _lbl_gen_37;
			lbl_gen[36] = _lbl_gen_36;
			lbl_gen[29] = _lbl_gen_29;
			lbl_gen[21] = _lbl_gen_21;
			lbl_gen[39] = _lbl_gen_39;
			lbl_gen[43] = _lbl_gen_43;
			lbl_gen[81] = _lbl_gen_81;
			lbl_gen[80] = _lbl_gen_80;
			lbl_gen[51] = _lbl_gen_51;
			lbl_gen[125] = _lbl_gen_125;
			lbl_gen[124] = _lbl_gen_124;
			lbl_gen[122] = _lbl_gen_122;
			lbl_gen[117] = _lbl_gen_117;
			lbl_gen[94] = _lbl_gen_94;
			lbl_gen[93] = _lbl_gen_93;
			lbl_gen[233] = _lbl_gen_233;
			lbl_gen[91] = _lbl_gen_91;
			lbl_gen[96] = _lbl_gen_96;
			lbl_gen[99] = _lbl_gen_99;
			lbl_gen[35] = _lbl_gen_35;
			lbl_gen[18] = _lbl_gen_18;
			lbl_gen[23] = _lbl_gen_23;
			lbl_gen[24] = _lbl_gen_24;
			lbl_gen[25] = _lbl_gen_25;
			lbl_gen[26] = _lbl_gen_26;
			lbl_gen[90] = _lbl_gen_90;
			lbl_gen[89] = _lbl_gen_89;
			lbl_gen[63] = _lbl_gen_63;
			lbl_gen[92] = _lbl_gen_92;
			lbl_gen[57] = _lbl_gen_57;
			lbl_gen[88] = _lbl_gen_88;
			lbl_gen[87] = _lbl_gen_87;
			lbl_gen[79] = _lbl_gen_79;
			lbl_gen[78] = _lbl_gen_78;
			lbl_gen[76] = _lbl_gen_76;
			lbl_gen[32] = _lbl_gen_32;
			lbl_gen[65] = _lbl_gen_65;
			lbl_gen[64] = _lbl_gen_64;
			lbl_gen[130] = _lbl_gen_130;
			lbl_gen[118] = _lbl_gen_118;
			lbl_gen[116] = _lbl_gen_116;
			lbl_gen[115] = _lbl_gen_115;
			lbl_gen[114] = _lbl_gen_114;
			lbl_gen[120] = _lbl_gen_120;
			lbl_gen[62] = _lbl_gen_62;
			lbl_gen[61] = _lbl_gen_61;
			lbl_gen[60] = _lbl_gen_60;
			lbl_gen[59] = _lbl_gen_59;
			lbl_gen[71] = _lbl_gen_71;
			lbl_gen[70] = _lbl_gen_70;
			lbl_gen[28] = _lbl_gen_28;
			lbl_gen[58] = _lbl_gen_58;
			lbl_gen[40] = _lbl_gen_40;
			lbl_gen[107] = _lbl_gen_107;
			lbl_gen[106] = _lbl_gen_106;
			lbl_gen[105] = _lbl_gen_105;
			lbl_gen[73] = _lbl_gen_73;
			lbl_gen[72] = _lbl_gen_72;
			lbl_gen[104] = _lbl_gen_104;
			lbl_gen[103] = _lbl_gen_103;
			lbl_gen[263] = _lbl_gen_263;
			lbl_gen[260] = _lbl_gen_260;
			lbl_gen[261] = _lbl_gen_261;
			lbl_gen[262] = _lbl_gen_262;
			lbl_gen[19] = _lbl_gen_19;
			lbl_gen[20] = _lbl_gen_20;
			lbl_gen[55] = _lbl_gen_55;
			lbl_gen[54] = _lbl_gen_54;
			lbl_gen[230] = _lbl_gen_230;
			lbl_gen[231] = _lbl_gen_231;
			lbl_gen[239] = _lbl_gen_239;
			lbl_gen[238] = _lbl_gen_238;
			lbl_gen[34] = _lbl_gen_34;
			lbl_gen[236] = _lbl_gen_236;
			lbl_gen[200] = _lbl_gen_200;
			lbl_gen[234] = _lbl_gen_234;
			lbl_gen[46] = _lbl_gen_46;
			lbl_gen[49] = _lbl_gen_49;
			lbl_gen[53] = _lbl_gen_53;
			lbl_gen[27] = _lbl_gen_27;
			lbl_gen[47] = _lbl_gen_47;
			lbl_gen[45] = _lbl_gen_45;
			lbl_gen[227] = _lbl_gen_227;
			lbl_gen[228] = _lbl_gen_228;
			lbl_gen[44] = _lbl_gen_44;
			lbl_gen[52] = _lbl_gen_52;
			lbl_gen[113] = _lbl_gen_113;
			lbl_gen[75] = _lbl_gen_75;
			lbl_gen[98] = _lbl_gen_98;
			lbl_gen[33] = _lbl_gen_33;
			lbl_gen[31] = _lbl_gen_31;
			lbl_gen[9] = _lbl_gen_9;
			lbl_gen[10] = _lbl_gen_10;
			lbl_gen[6] = _lbl_gen_6;
			lbl_gen[77] = _lbl_gen_77;
			lbl_gen[83] = _lbl_gen_83;
			lbl_gen[123] = _lbl_gen_123;
			lbl_gen[121] = _lbl_gen_121;
			lbl_gen[110] = _lbl_gen_110;
			lbl_gen[111] = _lbl_gen_111;
			lbl_gen[112] = _lbl_gen_112;
			lbl_gen[109] = _lbl_gen_109;
			lbl_gen[50] = _lbl_gen_50;
			lbl_gen[22] = _lbl_gen_22;
			lbl_gen[86] = _lbl_gen_86;
			lbl_gen[41] = _lbl_gen_41;
			lbl_gen[66] = _lbl_gen_66;
			lbl_gen[67] = _lbl_gen_67;
			lbl_gen[68] = _lbl_gen_68;
			lbl_gen[69] = _lbl_gen_69;
			lbl_gen[74] = _lbl_gen_74;
			lbl_gen[256] = _lbl_gen_256;
			lbl_gen[245] = _lbl_gen_245;
			lbl_gen[15] = _lbl_gen_15;
			lbl_gen[13] = _lbl_gen_13;
			lbl_gen[14] = _lbl_gen_14;
			lbl_gen[12] = _lbl_gen_12;
			lbl_gen[257] = _lbl_gen_257;
			lbl_gen[2] = _lbl_gen_2;
			lbl_gen[1] = _lbl_gen_1;
			lbl_gen[11] = _lbl_gen_11;
			lbl_gen[7] = _lbl_gen_7;
			lbl_gen[8] = _lbl_gen_8;
			lbl_gen[241] = _lbl_gen_241;
			lbl_gen[5] = _lbl_gen_5;
			lbl_gen[119] = _lbl_gen_119;
			lbl_gen[108] = _lbl_gen_108;
			lbl_gen[17] = _lbl_gen_17;
			lbl_gen[95] = _lbl_gen_95;
			lbl_gen[97] = _lbl_gen_97;
			lbl_gen[30] = _lbl_gen_30;
			lbl_gen[3] = _lbl_gen_3;
			lbl_gen[4] = _lbl_gen_4;
			lbl_gen[240] = _lbl_gen_240;
			lbl_gen[56] = _lbl_gen_56;
			lbl_gen[102] = _lbl_gen_102;
			lbl_gen[42] = _lbl_gen_42;
			lbl_gen[84] = _lbl_gen_84;
			lbl_gen[0] = _lbl_gen_0;
			lbl_gen[199] = _lbl_gen_199;
			lbl_gen[85] = _lbl_gen_85;
		}
		void Initializegrd_pubs()
		{
			grd_pubs = new UpgradeHelpers.DataGridViewFlex[2];
			grd_pubs[1] = _grd_pubs_1;
			grd_pubs[0] = _grd_pubs_0;
		}
		void Initializegrd_Features()
		{
			grd_Features = new UpgradeHelpers.DataGridViewFlex[5];
			grd_Features[3] = _grd_Features_3;
			grd_Features[0] = _grd_Features_0;
			grd_Features[1] = _grd_Features_1;
			grd_Features[2] = _grd_Features_2;
			grd_Features[4] = _grd_Features_4;
		}
		void Initializecmd_Av_Add()
		{
			cmd_Av_Add = new System.Windows.Forms.Button[4];
			cmd_Av_Add[0] = _cmd_Av_Add_0;
			cmd_Av_Add[2] = _cmd_Av_Add_2;
			cmd_Av_Add[3] = _cmd_Av_Add_3;
			cmd_Av_Add[1] = _cmd_Av_Add_1;
		}
		void Initializecmd_Add_Cert()
		{
			cmd_Add_Cert = new System.Windows.Forms.Button[3];
			cmd_Add_Cert[1] = _cmd_Add_Cert_1;
			cmd_Add_Cert[2] = _cmd_Add_Cert_2;
			cmd_Add_Cert[0] = _cmd_Add_Cert_0;
		}
		void InitializecmdSaveLease()
		{
			cmdSaveLease = new System.Windows.Forms.Button[2];
			cmdSaveLease[0] = _cmdSaveLease_0;
			cmdSaveLease[1] = _cmdSaveLease_1;
		}
		void InitializecmdSaveDocNotes()
		{
			cmdSaveDocNotes = new System.Windows.Forms.Button[7];
			cmdSaveDocNotes[6] = _cmdSaveDocNotes_6;
			cmdSaveDocNotes[5] = _cmdSaveDocNotes_5;
			cmdSaveDocNotes[4] = _cmdSaveDocNotes_4;
			cmdSaveDocNotes[3] = _cmdSaveDocNotes_3;
			cmdSaveDocNotes[2] = _cmdSaveDocNotes_2;
			cmdSaveDocNotes[1] = _cmdSaveDocNotes_1;
			cmdSaveDocNotes[0] = _cmdSaveDocNotes_0;
		}
		void InitializecmdHelicopter()
		{
			cmdHelicopter = new System.Windows.Forms.Button[2];
			cmdHelicopter[1] = _cmdHelicopter_1;
			cmdHelicopter[0] = _cmdHelicopter_0;
		}
		void InitializecmdAddACDetail()
		{
			cmdAddACDetail = new System.Windows.Forms.Button[11];
			cmdAddACDetail[10] = _cmdAddACDetail_10;
			cmdAddACDetail[3] = _cmdAddACDetail_3;
			cmdAddACDetail[8] = _cmdAddACDetail_8;
			cmdAddACDetail[7] = _cmdAddACDetail_7;
			cmdAddACDetail[6] = _cmdAddACDetail_6;
			cmdAddACDetail[5] = _cmdAddACDetail_5;
			cmdAddACDetail[2] = _cmdAddACDetail_2;
			cmdAddACDetail[1] = _cmdAddACDetail_1;
			cmdAddACDetail[0] = _cmdAddACDetail_0;
			cmdAddACDetail[4] = _cmdAddACDetail_4;
			cmdAddACDetail[9] = _cmdAddACDetail_9;
		}
		void Initializechk_ac_product()
		{
			chk_ac_product = new System.Windows.Forms.CheckBox[6];
			chk_ac_product[3] = _chk_ac_product_3;
			chk_ac_product[5] = _chk_ac_product_5;
			chk_ac_product[4] = _chk_ac_product_4;
			chk_ac_product[2] = _chk_ac_product_2;
			chk_ac_product[1] = _chk_ac_product_1;
			chk_ac_product[0] = _chk_ac_product_0;
		}
		void Initializechk_ac_aport_private()
		{
			chk_ac_aport_private = new System.Windows.Forms.CheckBox[3];
			chk_ac_aport_private[2] = _chk_ac_aport_private_2;
			chk_ac_aport_private[1] = _chk_ac_aport_private_1;
			chk_ac_aport_private[0] = _chk_ac_aport_private_0;
		}
		void InitializechkArray()
		{
			chkArray = new System.Windows.Forms.CheckBox[8];
			chkArray[1] = _chkArray_1;
			chkArray[7] = _chkArray_7;
			chkArray[0] = _chkArray_0;
			chkArray[3] = _chkArray_3;
			chkArray[4] = _chkArray_4;
			chkArray[5] = _chkArray_5;
			chkArray[6] = _chkArray_6;
			chkArray[2] = _chkArray_2;
		}
		void Initializecbo_drop_array()
		{
			cbo_drop_array = new System.Windows.Forms.ComboBox[2];
			cbo_drop_array[1] = _cbo_drop_array_1;
			cbo_drop_array[0] = _cbo_drop_array_0;
		}
		void InitializecboAcctRep()
		{
			cboAcctRep = new System.Windows.Forms.ComboBox[2];
			cboAcctRep[1] = _cboAcctRep_1;
			cboAcctRep[0] = _cboAcctRep_0;
		}
		void InitializeLabel1()
		{
			Label1 = new System.Windows.Forms.Label[2];
			Label1[1] = _Label1_1;
			Label1[0] = _Label1_0;
		}
		#endregion
	}
}