
namespace HomebaseAdministrator
{
	partial class frm_AircraftLookup
	{

		#region "Upgrade Support "
		private static frm_AircraftLookup m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_AircraftLookup DefInstance
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
		public static frm_AircraftLookup CreateInstance()
		{
			frm_AircraftLookup theInstance = new frm_AircraftLookup();
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
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileClose", "mnuFileLogout", "mnu_File", "MainMenu1", "lbl_kfeat_codename", "cbo_feat_area", "_chk_product_flags_3", "_chk_product_flags_2", "_chk_product_flags_1", "_chk_product_flags_0", "txt_InactiveDate", "chk_kfeat_donotclear", "txt_kfeat_wheretoenter", "txt_kfeat_howtoformat", "chk_Inactive_Feature_Code", "txt_kfeat_research_notes", "txt_kfeat_description", "txt_kfeat_name", "cmd_Delete_Kfeat", "cmd_Cancel_Kfeat", "cmd_Save_Kfeat", "txt_kfeat_code", "_Label24_44", "_Label24_19", "_Label24_18", "_Label24_17", "_Label24_16", "_Label24_15", "_lbl_kfeat_code_0", "pnl_kfeat_test", "cmd_Add_Kfeat", "FG_KeyFeature", "cmd_CloseAutoModel", "grd_AutoMod", "lbl_modeltext", "frame_automodels", "chk_show_inactive", "_tab_Lookup_TabPage0", "FG_Aircraft_Status", "cmd_Add_Aircraft_Status", "txt_astat_description", "txt_astat_name", "cmd_Delete_Aircraft_Status", "cmd_Cancel_Aircraft_Status", "cmd_Save_Aircraft_Status", "_Label24_21", "_Label24_20", "pnl_Update_Aircraft_Status", "_tab_Lookup_TabPage1", "FG_AirCraft_Asking", "cmd_Add_Asking", "cmd_Save_Asking", "cmd_Cancel_Asking", "cmd_Delete_Asking", "txt_aask_name", "txt_aask_description", "_Label24_23", "_Label24_22", "pnl_NameDesc_Asking", "_tab_Lookup_TabPage2", "txt_avion_notes", "txt_avion_name", "cmd_Delete_Avionics", "cmd_Cancel_Avionics", "cmd_Save_Avionics", "_Label24_25", "_Label24_24", "pnl_avionics_Update_Change", "cmd_Add_Avionics", "FG_Avionics", "_tab_Lookup_TabPage3", "FG_Aircraft_Class", "cmd_Add_Aircraft_Class", "cmd_Save_Aircraft_Class", "cmd_Cancel_Aircraft_Class", "cmd_Delete_Aircraft_Class", "txt_aclass_code", "txt_aclass_Name", "_Label24_27", "_Label24_26", "pnl_Aircraft_Class_AddUpdate", "_tab_Lookup_TabPage4", "FG_Aircraft_Type", "cmd_Add_Aircraft_type", "txt_atype_Name", "txt_atype_code", "cmd_Delete_Aircraft_Type", "cmd_Cancel_Aircraft_Type", "cmd_Save_Aircraft_Type", "_Label24_29", "_Label24_28", "pnl_Aircraft_Type_AddUpdate", "_tab_Lookup_TabPage5", "_Label24_45", "_lblExportToExcel_1", "txt_Program_Name", "txt_Provider_Name", "txt_Emp_ID", "cmd_Save_EMP", "cmd_Cancel_EMP", "cmd_Delete_EMP", "txt_emp_code", "txt_emp_name", "_Label24_33", "_Label24_32", "_Label24_31", "_Label24_30", "Label1", "pnl_EMP_AddUpdate", "cmd_Add_EMP", "FG_Engine_Maintenance", "_tab_Lookup_TabPage6", "FG_Interior_Configuration", "cmd_Add_IC", "cmd_Save_IC", "cmd_Cancel_IC", "cmd_Delete_IC", "txt_intconfig_name", "_Label24_34", "pnl_IC_Update_Change", "_tab_Lookup_TabPage7", "cmd_Add_Aircraft_Contact_type", "FGRD_AircraftContactType", "cboShow", "_Label24_39", "pnl_Aircraft_Contact_Type_List", "cmd_Delete_Aircraft_Contact_Type", "cmd_Cancel_Aircraft_Contact_Type", "cmd_Save_Aircraft_Contact_Type", "txt_actype_Name", "txt_actype_code", "txt_actype_abbrev", "txt_actype_use_flag", "_Label24_38", "_Label24_37", "_Label24_36", "_Label24_35", "pnl_Aircraft_Contact_Type_AddUpdate", "chk_actype_shareref_flag", "chk_actype_transref_flag", "chk_actype_acref_flag", "txt_compref_name2", "chk_compref_internal_flag", "chk_compref_twoway_flag", "chk_actype_compref_flag", "Label36", "pnl_CompanyRelationship", "pnl_ACTypeMain", "_tab_Lookup_TabPage8", "FG_Auxiliary_Power", "cmd_Add_APU", "cmd_Save_APU", "cmd_Cancel_APU", "cmd_Delete_APU", "txt_apu_make_name", "txt_apu_model_name", "_Label24_41", "_Label24_40", "pnl_APU_Update_Change", "_tab_Lookup_TabPage9", "FG_Operating_Certification", "cmd_Add_Certification", "chkCertActive", "cbo_Ops_Cert_usaFlag", "_txt_certification_name_2", "_txt_certification_name_0", "cmd_Delete_Certification", "cmd_Cancel_Certification", "cmd_Save_Certification", "_Label19_3", "_Label19_2", "_Label19_1", "_Label19_0", "pnl_Certification_Update_Change", "_tab_Lookup_TabPage10", "FG_Specification", "cmd_Add_Spec", "txt_spec_notes", "txt_spec_name", "cmd_Delete_Spec", "cmd_Cancel_Spec", "cmd_Save_Spec", "txt_spec_type", "_Label24_2", "_Label24_1", "_Label24_0", "pnl_Spec_Update_Change", "_tab_Lookup_TabPage11", "_lblAirport_10", "_cmdAirportPreviousNext_1", "_cmdAirportPreviousNext_0", "cmd_Airport_Add", "_txtAirport_9", "_txtAirport_10", "_txtAirport_11", "_txtAirport_12", "_txtAirport_13", "_txtAirport_17", "_txtAirport_16", "_txtAirport_8", "_txtAirport_7", "_txtAirport_6", "_txtAirport_5", "_txtAirport_4", "lblLatitudeGPS", "_lblAirport_24", "_lblAirport_19", "_lblAirport_8", "_lblAirport_7", "_lblAirport_6", "_lblAirport_5", "_lblAirport_4", "frmLatitudeLongatude", "cmd_Airport_Delete", "cmd_Airport_Cancel", "cmd_Airport_Save", "_txtAirport_19", "_txtAirport_18", "_txtAirport_15", "_txtAirport_14", "chk_aport_active_flag", "_txtAirport_3", "_txtAirport_2", "_txtAirport_1", "_txtAirport_0", "cbo_aport_state", "cbo_aport_country", "_lblAirport_20", "_lblAirport_13", "_lblAirport_12", "_lblAirport_11", "_lblAirport_9", "_lblAirport_26", "_lblAirport_23", "_lblAirport_22", "_lblAirport_18", "_lblAirport_21", "_lblAirport_17", "_lblAirport_16", "_lblAirport_15", "_lblAirport_14", "lbl_aircraft_count", "_lblAirport_3", "_lblAirport_2", "_lblAirport_1", "_lblAirport_0", "frmAirport", "pnl_airport_update", "txtGlobal", "cbo_Airport_Index", "cbo_faaid_index", "_chkAirportListOptions_8", "_chkAirportListOptions_7", "_chkAirportListOptions_6", "_chkAirportListOptions_4", "_chkAirportListOptions_5", "_chkAirportListOptions_3", "_chkAirportListOptions_2", "_chkAirportListOptions_1", "txt_AirportColor", "cbo_icao_index", "cbo_iata_index", "cmd_Refresh_Airports", "_chkAirportListOptions_0", "grd_Airport", "lblGlobal", "lblICAOIndex", "lblFAAIDIndex", "lbl_Airport_Count", "lblIATAIndex", "lblNameIndex", "_lbl_Airport_Message_1", "SSPanel3", "pnl_airport_Update_Change", "_tab_Lookup_TabPage12", "cmd_save_certified", "cmd_cancel_certified", "cmd_delete_certified", "txt_cert_name_cert", "_Label24_3", "pnl_Certified_Update_Change", "cmd_certified_add", "FGRD_Certifed", "_tab_Lookup_TabPage13", "_tab_Lookup_TabPage14", "cmdAddCREG", "grdCREG", "txt_crm_amod_list", "txt_crm_id", "cbo_CREG", "txt_crm_model", "cmdSaveCREG", "cmdCancelCREG", "cmdDeleteCREG", "txt_crm_Make", "_Label40_4", "_Label40_3", "_Label40_1", "_Label40_0", "pnl_CREG", "_tab_Lookup_TabPage15", "_cmd_button_2", "_Text1_0", "_cmd_button_1", "_cmd_button_0", "grd_ABI_Hide_AC", "_lbl_generic_7", "_lbl_generic_6", "_lbl_generic_5", "_lbl_generic_4", "_lbl_generic_3", "_lbl_generic_1", "_lbl_generic_0", "_tab_Lookup_TabPage16", "_txtFuelCost_3", "_txt_fuel_price_notes_3", "_txt_fuel_price_notes_2", "_txt_fuel_price_notes_1", "_txt_fuel_price_notes_0", "_cmd_button_3", "_txtFuelCost_2", "_txtFuelCost_1", "_txtFuelCost_0", "_lbl_generic_12", "_lbl_generic_9", "_lbl_generic_11", "_lbl_generic_10", "_lbl_generic_8", "frmFuelPrices", "_tab_Lookup_TabPage17", "acTopicsUpdateEvo", "acTopicArea", "acTopicAdd", "acTopicsGrid", "_check_prod_code_2", "_check_prod_code_1", "_check_prod_code_0", "acTopicParentTopic", "acTopicItemName", "acTopicItemQuery", "acTopicAerodexFlag", "acTopicAreaItem", "acTopicSave", "acTopicCancel", "acTopicDelete", "acTopicItemDescription", "_Label24_8", "_Label24_7", "_Label24_6", "_Label24_5", "_Label24_4", "acTopicIDLabel", "acTopicsPanel", "acTopicsListClose", "acTopicAircraftList", "acTopicAircraftListLabel", "acTopicsAircraftFrame", "acTopicErrorDisplay", "Label20", "_tab_Lookup_TabPage18", "_Label24_9", "_Label24_10", "_Label24_11", "_Label24_12", "_Label24_13", "_Label24_14", "_Label24_42", "_Label24_43", "grd_maint_items", "_txt_maint_0", "_txt_maint_1", "_txt_maint_2", "_chk_maint_0", "_chk_maint_1", "_txt_maint_3", "cbo_maint_type", "_cmd_maint_0", "_cmd_maint_1", "_cmd_maint_2", "_cmd_maint_3", "_cmd_maint_4", "cmd_post", "_txt_maint_4", "_cmd_maint_5", "_cmd_maint_6", "_tab_Lookup_TabPage19", "lblEngineModelsStop", "lblSearchEngineModelName", "lblLoading", "lblEMStatus", "_lblExportToExcel_0", "grdEngineModels", "_txtEngineModel_15", "_txtEngineModel_14", "_txtEngineModel_13", "_txtEngineModel_12", "_txtEngineModel_11", "cmdEngineModelsDelete", "cmdEngineModelsAdd", "cmdEngineModelsSave", "frmEngineModelsAction", "_txtEngineModel_10", "_txtEngineModel_9", "_txtEngineModel_8", "_txtEngineModel_7", "_txtEngineModel_6", "_txtEngineModel_5", "_txtEngineModel_4", "_txtEngineModel_3", "_txtEngineModel_2", "_txtEngineModel_1", "_chkEngineModel_1", "_chkEngineModel_0", "_txtEngineModel_0", "_lblEngMdl_14", "_lblEngMdl_13", "_lblEngMdl_12", "_lblEngMdl_11", "_lblEngMdl_10", "_lblEngMdl_9", "_lblEngMdl_8", "_lblEngMdl_7", "_lblEngMdl_6", "_lblEngMdl_5", "_lblEngMdl_4", "_lblEngMdl_3", "_lblEngMdl_2", "_lblEngMdl_1", "_lblEngMdl_0", "frmEngineModels", "cmdEngineModelsRefresh", "txtSearchEngineModelName", "chkEMFindDuplicate", "_tab_Lookup_TabPage20", "cmd_Launch_av_items", "_tab_Lookup_TabPage21", "_tab_Lookup_TabPage22", "_tab_Lookup_TabPage23", "tab_Lookup", "tbr_ToolBar_Buttons_Button1", "tbr_ToolBar_Buttons_Button2", "tbr_ToolBar_Buttons_Button3", "tbr_ToolBar_Buttons_Button4", "tbr_ToolBar_Buttons_Button5", "tbr_ToolBar_Buttons_Button6", "tbr_ToolBar_Buttons_Button7", "tbr_ToolBar_Buttons_Button8", "tbr_ToolBar", "chkShowCounts", "chk_AutoGen", "txt_kfeat_query", "lbl_rule_note", "_lblCount_2", "_lblCount_1", "_lblCount_0", "Label39", "lbl_kfeat_query", "pnlAdmin", "_lbl_generic_2", "Label19", "Label24", "Label40", "Text1", "check_prod_code", "chkAirportListOptions", "chkEngineModel", "chk_maint", "chk_product_flags", "cmdAirportPreviousNext", "cmd_button", "cmd_maint", "lblAirport", "lblCount", "lblEngMdl", "lblExportToExcel", "lbl_Airport_Message", "lbl_generic", "lbl_kfeat_code", "txtAirport", "txtEngineModel", "txtFuelCost", "txt_certification_name", "txt_fuel_price_notes", "txt_maint", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFileLogout;
		public System.Windows.Forms.ToolStripMenuItem mnu_File;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.Label lbl_kfeat_codename;
		public System.Windows.Forms.ComboBox cbo_feat_area;
		private System.Windows.Forms.CheckBox _chk_product_flags_3;
		private System.Windows.Forms.CheckBox _chk_product_flags_2;
		private System.Windows.Forms.CheckBox _chk_product_flags_1;
		private System.Windows.Forms.CheckBox _chk_product_flags_0;
		public System.Windows.Forms.TextBox txt_InactiveDate;
		public System.Windows.Forms.CheckBox chk_kfeat_donotclear;
		public System.Windows.Forms.TextBox txt_kfeat_wheretoenter;
		public System.Windows.Forms.TextBox txt_kfeat_howtoformat;
		public System.Windows.Forms.CheckBox chk_Inactive_Feature_Code;
		public System.Windows.Forms.TextBox txt_kfeat_research_notes;
		public System.Windows.Forms.TextBox txt_kfeat_description;
		public System.Windows.Forms.TextBox txt_kfeat_name;
		public System.Windows.Forms.Button cmd_Delete_Kfeat;
		public System.Windows.Forms.Button cmd_Cancel_Kfeat;
		public System.Windows.Forms.Button cmd_Save_Kfeat;
		public System.Windows.Forms.TextBox txt_kfeat_code;
		private System.Windows.Forms.Label _Label24_44;
		private System.Windows.Forms.Label _Label24_19;
		private System.Windows.Forms.Label _Label24_18;
		private System.Windows.Forms.Label _Label24_17;
		private System.Windows.Forms.Label _Label24_16;
		private System.Windows.Forms.Label _Label24_15;
		private System.Windows.Forms.Label _lbl_kfeat_code_0;
		public System.Windows.Forms.Panel pnl_kfeat_test;
		public System.Windows.Forms.Button cmd_Add_Kfeat;
		public UpgradeHelpers.DataGridViewFlex FG_KeyFeature;
		public System.Windows.Forms.Button cmd_CloseAutoModel;
		public UpgradeHelpers.DataGridViewFlex grd_AutoMod;
		public System.Windows.Forms.Label lbl_modeltext;
		public System.Windows.Forms.GroupBox frame_automodels;
		public System.Windows.Forms.CheckBox chk_show_inactive;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage0;
		public UpgradeHelpers.DataGridViewFlex FG_Aircraft_Status;
		public System.Windows.Forms.Button cmd_Add_Aircraft_Status;
		public System.Windows.Forms.TextBox txt_astat_description;
		public System.Windows.Forms.TextBox txt_astat_name;
		public System.Windows.Forms.Button cmd_Delete_Aircraft_Status;
		public System.Windows.Forms.Button cmd_Cancel_Aircraft_Status;
		public System.Windows.Forms.Button cmd_Save_Aircraft_Status;
		private System.Windows.Forms.Label _Label24_21;
		private System.Windows.Forms.Label _Label24_20;
		public System.Windows.Forms.Panel pnl_Update_Aircraft_Status;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage1;
		public UpgradeHelpers.DataGridViewFlex FG_AirCraft_Asking;
		public System.Windows.Forms.Button cmd_Add_Asking;
		public System.Windows.Forms.Button cmd_Save_Asking;
		public System.Windows.Forms.Button cmd_Cancel_Asking;
		public System.Windows.Forms.Button cmd_Delete_Asking;
		public System.Windows.Forms.TextBox txt_aask_name;
		public System.Windows.Forms.TextBox txt_aask_description;
		private System.Windows.Forms.Label _Label24_23;
		private System.Windows.Forms.Label _Label24_22;
		public System.Windows.Forms.Panel pnl_NameDesc_Asking;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage2;
		public System.Windows.Forms.TextBox txt_avion_notes;
		public System.Windows.Forms.TextBox txt_avion_name;
		public System.Windows.Forms.Button cmd_Delete_Avionics;
		public System.Windows.Forms.Button cmd_Cancel_Avionics;
		public System.Windows.Forms.Button cmd_Save_Avionics;
		private System.Windows.Forms.Label _Label24_25;
		private System.Windows.Forms.Label _Label24_24;
		public System.Windows.Forms.Panel pnl_avionics_Update_Change;
		public System.Windows.Forms.Button cmd_Add_Avionics;
		public UpgradeHelpers.DataGridViewFlex FG_Avionics;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage3;
		public UpgradeHelpers.DataGridViewFlex FG_Aircraft_Class;
		public System.Windows.Forms.Button cmd_Add_Aircraft_Class;
		public System.Windows.Forms.Button cmd_Save_Aircraft_Class;
		public System.Windows.Forms.Button cmd_Cancel_Aircraft_Class;
		public System.Windows.Forms.Button cmd_Delete_Aircraft_Class;
		public System.Windows.Forms.TextBox txt_aclass_code;
		public System.Windows.Forms.TextBox txt_aclass_Name;
		private System.Windows.Forms.Label _Label24_27;
		private System.Windows.Forms.Label _Label24_26;
		public System.Windows.Forms.Panel pnl_Aircraft_Class_AddUpdate;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage4;
		public UpgradeHelpers.DataGridViewFlex FG_Aircraft_Type;
		public System.Windows.Forms.Button cmd_Add_Aircraft_type;
		public System.Windows.Forms.TextBox txt_atype_Name;
		public System.Windows.Forms.TextBox txt_atype_code;
		public System.Windows.Forms.Button cmd_Delete_Aircraft_Type;
		public System.Windows.Forms.Button cmd_Cancel_Aircraft_Type;
		public System.Windows.Forms.Button cmd_Save_Aircraft_Type;
		private System.Windows.Forms.Label _Label24_29;
		private System.Windows.Forms.Label _Label24_28;
		public System.Windows.Forms.Panel pnl_Aircraft_Type_AddUpdate;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage5;
		private System.Windows.Forms.Label _Label24_45;
		private System.Windows.Forms.Label _lblExportToExcel_1;
		public System.Windows.Forms.TextBox txt_Program_Name;
		public System.Windows.Forms.TextBox txt_Provider_Name;
		public System.Windows.Forms.TextBox txt_Emp_ID;
		public System.Windows.Forms.Button cmd_Save_EMP;
		public System.Windows.Forms.Button cmd_Cancel_EMP;
		public System.Windows.Forms.Button cmd_Delete_EMP;
		public System.Windows.Forms.TextBox txt_emp_code;
		public System.Windows.Forms.TextBox txt_emp_name;
		private System.Windows.Forms.Label _Label24_33;
		private System.Windows.Forms.Label _Label24_32;
		private System.Windows.Forms.Label _Label24_31;
		private System.Windows.Forms.Label _Label24_30;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Panel pnl_EMP_AddUpdate;
		public System.Windows.Forms.Button cmd_Add_EMP;
		public UpgradeHelpers.DataGridViewFlex FG_Engine_Maintenance;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage6;
		public UpgradeHelpers.DataGridViewFlex FG_Interior_Configuration;
		public System.Windows.Forms.Button cmd_Add_IC;
		public System.Windows.Forms.Button cmd_Save_IC;
		public System.Windows.Forms.Button cmd_Cancel_IC;
		public System.Windows.Forms.Button cmd_Delete_IC;
		public System.Windows.Forms.TextBox txt_intconfig_name;
		private System.Windows.Forms.Label _Label24_34;
		public System.Windows.Forms.Panel pnl_IC_Update_Change;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage7;
		public System.Windows.Forms.Button cmd_Add_Aircraft_Contact_type;
		public UpgradeHelpers.DataGridViewFlex FGRD_AircraftContactType;
		public System.Windows.Forms.ComboBox cboShow;
		private System.Windows.Forms.Label _Label24_39;
		public System.Windows.Forms.Panel pnl_Aircraft_Contact_Type_List;
		public System.Windows.Forms.Button cmd_Delete_Aircraft_Contact_Type;
		public System.Windows.Forms.Button cmd_Cancel_Aircraft_Contact_Type;
		public System.Windows.Forms.Button cmd_Save_Aircraft_Contact_Type;
		public System.Windows.Forms.TextBox txt_actype_Name;
		public System.Windows.Forms.TextBox txt_actype_code;
		public System.Windows.Forms.TextBox txt_actype_abbrev;
		public System.Windows.Forms.TextBox txt_actype_use_flag;
		private System.Windows.Forms.Label _Label24_38;
		private System.Windows.Forms.Label _Label24_37;
		private System.Windows.Forms.Label _Label24_36;
		private System.Windows.Forms.Label _Label24_35;
		public System.Windows.Forms.Panel pnl_Aircraft_Contact_Type_AddUpdate;
		public System.Windows.Forms.CheckBox chk_actype_shareref_flag;
		public System.Windows.Forms.CheckBox chk_actype_transref_flag;
		public System.Windows.Forms.CheckBox chk_actype_acref_flag;
		public System.Windows.Forms.TextBox txt_compref_name2;
		public System.Windows.Forms.CheckBox chk_compref_internal_flag;
		public System.Windows.Forms.CheckBox chk_compref_twoway_flag;
		public System.Windows.Forms.CheckBox chk_actype_compref_flag;
		public System.Windows.Forms.Label Label36;
		public System.Windows.Forms.Panel pnl_CompanyRelationship;
		public System.Windows.Forms.Panel pnl_ACTypeMain;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage8;
		public UpgradeHelpers.DataGridViewFlex FG_Auxiliary_Power;
		public System.Windows.Forms.Button cmd_Add_APU;
		public System.Windows.Forms.Button cmd_Save_APU;
		public System.Windows.Forms.Button cmd_Cancel_APU;
		public System.Windows.Forms.Button cmd_Delete_APU;
		public System.Windows.Forms.TextBox txt_apu_make_name;
		public System.Windows.Forms.TextBox txt_apu_model_name;
		private System.Windows.Forms.Label _Label24_41;
		private System.Windows.Forms.Label _Label24_40;
		public System.Windows.Forms.Panel pnl_APU_Update_Change;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage9;
		public UpgradeHelpers.DataGridViewFlex FG_Operating_Certification;
		public System.Windows.Forms.Button cmd_Add_Certification;
		public System.Windows.Forms.CheckBox chkCertActive;
		public System.Windows.Forms.ComboBox cbo_Ops_Cert_usaFlag;
		private System.Windows.Forms.TextBox _txt_certification_name_2;
		private System.Windows.Forms.TextBox _txt_certification_name_0;
		public System.Windows.Forms.Button cmd_Delete_Certification;
		public System.Windows.Forms.Button cmd_Cancel_Certification;
		public System.Windows.Forms.Button cmd_Save_Certification;
		private System.Windows.Forms.Label _Label19_3;
		private System.Windows.Forms.Label _Label19_2;
		private System.Windows.Forms.Label _Label19_1;
		private System.Windows.Forms.Label _Label19_0;
		public System.Windows.Forms.Panel pnl_Certification_Update_Change;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage10;
		public UpgradeHelpers.DataGridViewFlex FG_Specification;
		public System.Windows.Forms.Button cmd_Add_Spec;
		public System.Windows.Forms.TextBox txt_spec_notes;
		public System.Windows.Forms.TextBox txt_spec_name;
		public System.Windows.Forms.Button cmd_Delete_Spec;
		public System.Windows.Forms.Button cmd_Cancel_Spec;
		public System.Windows.Forms.Button cmd_Save_Spec;
		public System.Windows.Forms.TextBox txt_spec_type;
		private System.Windows.Forms.Label _Label24_2;
		private System.Windows.Forms.Label _Label24_1;
		private System.Windows.Forms.Label _Label24_0;
		public System.Windows.Forms.Panel pnl_Spec_Update_Change;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage11;
		private System.Windows.Forms.Label _lblAirport_10;
		private System.Windows.Forms.Button _cmdAirportPreviousNext_1;
		private System.Windows.Forms.Button _cmdAirportPreviousNext_0;
		public System.Windows.Forms.Button cmd_Airport_Add;
		private System.Windows.Forms.TextBox _txtAirport_9;
		private System.Windows.Forms.TextBox _txtAirport_10;
		private System.Windows.Forms.TextBox _txtAirport_11;
		private System.Windows.Forms.TextBox _txtAirport_12;
		private System.Windows.Forms.TextBox _txtAirport_13;
		private System.Windows.Forms.TextBox _txtAirport_17;
		private System.Windows.Forms.TextBox _txtAirport_16;
		private System.Windows.Forms.TextBox _txtAirport_8;
		private System.Windows.Forms.TextBox _txtAirport_7;
		private System.Windows.Forms.TextBox _txtAirport_6;
		private System.Windows.Forms.TextBox _txtAirport_5;
		private System.Windows.Forms.TextBox _txtAirport_4;
		public System.Windows.Forms.Label lblLatitudeGPS;
		private System.Windows.Forms.Label _lblAirport_24;
		private System.Windows.Forms.Label _lblAirport_19;
		private System.Windows.Forms.Label _lblAirport_8;
		private System.Windows.Forms.Label _lblAirport_7;
		private System.Windows.Forms.Label _lblAirport_6;
		private System.Windows.Forms.Label _lblAirport_5;
		private System.Windows.Forms.Label _lblAirport_4;
		public System.Windows.Forms.GroupBox frmLatitudeLongatude;
		public System.Windows.Forms.Button cmd_Airport_Delete;
		public System.Windows.Forms.Button cmd_Airport_Cancel;
		public System.Windows.Forms.Button cmd_Airport_Save;
		private System.Windows.Forms.TextBox _txtAirport_19;
		private System.Windows.Forms.TextBox _txtAirport_18;
		private System.Windows.Forms.TextBox _txtAirport_15;
		private System.Windows.Forms.TextBox _txtAirport_14;
		public System.Windows.Forms.CheckBox chk_aport_active_flag;
		private System.Windows.Forms.TextBox _txtAirport_3;
		private System.Windows.Forms.TextBox _txtAirport_2;
		private System.Windows.Forms.TextBox _txtAirport_1;
		private System.Windows.Forms.TextBox _txtAirport_0;
		public System.Windows.Forms.ComboBox cbo_aport_state;
		public System.Windows.Forms.ComboBox cbo_aport_country;
		private System.Windows.Forms.Label _lblAirport_20;
		private System.Windows.Forms.Label _lblAirport_13;
		private System.Windows.Forms.Label _lblAirport_12;
		private System.Windows.Forms.Label _lblAirport_11;
		private System.Windows.Forms.Label _lblAirport_9;
		private System.Windows.Forms.Label _lblAirport_26;
		private System.Windows.Forms.Label _lblAirport_23;
		private System.Windows.Forms.Label _lblAirport_22;
		private System.Windows.Forms.Label _lblAirport_18;
		private System.Windows.Forms.Label _lblAirport_21;
		private System.Windows.Forms.Label _lblAirport_17;
		private System.Windows.Forms.Label _lblAirport_16;
		private System.Windows.Forms.Label _lblAirport_15;
		private System.Windows.Forms.Label _lblAirport_14;
		public System.Windows.Forms.Label lbl_aircraft_count;
		private System.Windows.Forms.Label _lblAirport_3;
		private System.Windows.Forms.Label _lblAirport_2;
		private System.Windows.Forms.Label _lblAirport_1;
		private System.Windows.Forms.Label _lblAirport_0;
		public System.Windows.Forms.GroupBox frmAirport;
		public System.Windows.Forms.Panel pnl_airport_update;
		public System.Windows.Forms.TextBox txtGlobal;
		public System.Windows.Forms.ComboBox cbo_Airport_Index;
		public System.Windows.Forms.ComboBox cbo_faaid_index;
		private System.Windows.Forms.CheckBox _chkAirportListOptions_8;
		private System.Windows.Forms.CheckBox _chkAirportListOptions_7;
		private System.Windows.Forms.CheckBox _chkAirportListOptions_6;
		private System.Windows.Forms.CheckBox _chkAirportListOptions_4;
		private System.Windows.Forms.CheckBox _chkAirportListOptions_5;
		private System.Windows.Forms.CheckBox _chkAirportListOptions_3;
		private System.Windows.Forms.CheckBox _chkAirportListOptions_2;
		private System.Windows.Forms.CheckBox _chkAirportListOptions_1;
		public System.Windows.Forms.TextBox txt_AirportColor;
		public System.Windows.Forms.ComboBox cbo_icao_index;
		public System.Windows.Forms.ComboBox cbo_iata_index;
		public System.Windows.Forms.Button cmd_Refresh_Airports;
		private System.Windows.Forms.CheckBox _chkAirportListOptions_0;
		public UpgradeHelpers.DataGridViewFlex grd_Airport;
		public System.Windows.Forms.Label lblGlobal;
		public System.Windows.Forms.Label lblICAOIndex;
		public System.Windows.Forms.Label lblFAAIDIndex;
		public System.Windows.Forms.Label lbl_Airport_Count;
		public System.Windows.Forms.Label lblIATAIndex;
		public System.Windows.Forms.Label lblNameIndex;
		private System.Windows.Forms.Label _lbl_Airport_Message_1;
		public System.Windows.Forms.Panel SSPanel3;
		public System.Windows.Forms.Panel pnl_airport_Update_Change;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage12;
		public System.Windows.Forms.Button cmd_save_certified;
		public System.Windows.Forms.Button cmd_cancel_certified;
		public System.Windows.Forms.Button cmd_delete_certified;
		public System.Windows.Forms.TextBox txt_cert_name_cert;
		private System.Windows.Forms.Label _Label24_3;
		public System.Windows.Forms.Panel pnl_Certified_Update_Change;
		public System.Windows.Forms.Button cmd_certified_add;
		public UpgradeHelpers.DataGridViewFlex FGRD_Certifed;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage13;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage14;
		public System.Windows.Forms.Button cmdAddCREG;
		public UpgradeHelpers.DataGridViewFlex grdCREG;
		public System.Windows.Forms.TextBox txt_crm_amod_list;
		public System.Windows.Forms.TextBox txt_crm_id;
		public System.Windows.Forms.ComboBox cbo_CREG;
		public System.Windows.Forms.TextBox txt_crm_model;
		public System.Windows.Forms.Button cmdSaveCREG;
		public System.Windows.Forms.Button cmdCancelCREG;
		public System.Windows.Forms.Button cmdDeleteCREG;
		public System.Windows.Forms.TextBox txt_crm_Make;
		private System.Windows.Forms.Label _Label40_4;
		private System.Windows.Forms.Label _Label40_3;
		private System.Windows.Forms.Label _Label40_1;
		private System.Windows.Forms.Label _Label40_0;
		public System.Windows.Forms.Panel pnl_CREG;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage15;
		private System.Windows.Forms.Button _cmd_button_2;
		private System.Windows.Forms.TextBox _Text1_0;
		private System.Windows.Forms.Button _cmd_button_1;
		private System.Windows.Forms.Button _cmd_button_0;
		public UpgradeHelpers.DataGridViewFlex grd_ABI_Hide_AC;
		private System.Windows.Forms.Label _lbl_generic_7;
		private System.Windows.Forms.Label _lbl_generic_6;
		private System.Windows.Forms.Label _lbl_generic_5;
		private System.Windows.Forms.Label _lbl_generic_4;
		private System.Windows.Forms.Label _lbl_generic_3;
		private System.Windows.Forms.Label _lbl_generic_1;
		private System.Windows.Forms.Label _lbl_generic_0;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage16;
		private System.Windows.Forms.TextBox _txtFuelCost_3;
		private System.Windows.Forms.TextBox _txt_fuel_price_notes_3;
		private System.Windows.Forms.TextBox _txt_fuel_price_notes_2;
		private System.Windows.Forms.TextBox _txt_fuel_price_notes_1;
		private System.Windows.Forms.TextBox _txt_fuel_price_notes_0;
		private System.Windows.Forms.Button _cmd_button_3;
		private System.Windows.Forms.TextBox _txtFuelCost_2;
		private System.Windows.Forms.TextBox _txtFuelCost_1;
		private System.Windows.Forms.TextBox _txtFuelCost_0;
		private System.Windows.Forms.Label _lbl_generic_12;
		private System.Windows.Forms.Label _lbl_generic_9;
		private System.Windows.Forms.Label _lbl_generic_11;
		private System.Windows.Forms.Label _lbl_generic_10;
		private System.Windows.Forms.Label _lbl_generic_8;
		public System.Windows.Forms.GroupBox frmFuelPrices;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage17;
		public System.Windows.Forms.Button acTopicsUpdateEvo;
		public System.Windows.Forms.ComboBox acTopicArea;
		public System.Windows.Forms.Button acTopicAdd;
		public UpgradeHelpers.DataGridViewFlex acTopicsGrid;
		private System.Windows.Forms.CheckBox _check_prod_code_2;
		private System.Windows.Forms.CheckBox _check_prod_code_1;
		private System.Windows.Forms.CheckBox _check_prod_code_0;
		public System.Windows.Forms.ComboBox acTopicParentTopic;
		public System.Windows.Forms.TextBox acTopicItemName;
		public System.Windows.Forms.TextBox acTopicItemQuery;
		public System.Windows.Forms.CheckBox acTopicAerodexFlag;
		public System.Windows.Forms.ComboBox acTopicAreaItem;
		public System.Windows.Forms.Button acTopicSave;
		public System.Windows.Forms.Button acTopicCancel;
		public System.Windows.Forms.Button acTopicDelete;
		public System.Windows.Forms.TextBox acTopicItemDescription;
		private System.Windows.Forms.Label _Label24_8;
		private System.Windows.Forms.Label _Label24_7;
		private System.Windows.Forms.Label _Label24_6;
		private System.Windows.Forms.Label _Label24_5;
		private System.Windows.Forms.Label _Label24_4;
		public System.Windows.Forms.Label acTopicIDLabel;
		public System.Windows.Forms.Panel acTopicsPanel;
		public System.Windows.Forms.Button acTopicsListClose;
		public UpgradeHelpers.DataGridViewFlex acTopicAircraftList;
		public System.Windows.Forms.Label acTopicAircraftListLabel;
		public System.Windows.Forms.GroupBox acTopicsAircraftFrame;
		public System.Windows.Forms.Label acTopicErrorDisplay;
		public System.Windows.Forms.Label Label20;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage18;
		private System.Windows.Forms.Label _Label24_9;
		private System.Windows.Forms.Label _Label24_10;
		private System.Windows.Forms.Label _Label24_11;
		private System.Windows.Forms.Label _Label24_12;
		private System.Windows.Forms.Label _Label24_13;
		private System.Windows.Forms.Label _Label24_14;
		private System.Windows.Forms.Label _Label24_42;
		private System.Windows.Forms.Label _Label24_43;
		public UpgradeHelpers.DataGridViewFlex grd_maint_items;
		private System.Windows.Forms.TextBox _txt_maint_0;
		private System.Windows.Forms.TextBox _txt_maint_1;
		private System.Windows.Forms.TextBox _txt_maint_2;
		private System.Windows.Forms.CheckBox _chk_maint_0;
		private System.Windows.Forms.CheckBox _chk_maint_1;
		private System.Windows.Forms.TextBox _txt_maint_3;
		public System.Windows.Forms.ComboBox cbo_maint_type;
		private System.Windows.Forms.Button _cmd_maint_0;
		private System.Windows.Forms.Button _cmd_maint_1;
		private System.Windows.Forms.Button _cmd_maint_2;
		private System.Windows.Forms.Button _cmd_maint_3;
		private System.Windows.Forms.Button _cmd_maint_4;
		public System.Windows.Forms.Button cmd_post;
		private System.Windows.Forms.TextBox _txt_maint_4;
		private System.Windows.Forms.Button _cmd_maint_5;
		private System.Windows.Forms.Button _cmd_maint_6;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage19;
		public System.Windows.Forms.Label lblEngineModelsStop;
		public System.Windows.Forms.Label lblSearchEngineModelName;
		public System.Windows.Forms.Label lblLoading;
		public System.Windows.Forms.Label lblEMStatus;
		private System.Windows.Forms.Label _lblExportToExcel_0;
		public UpgradeHelpers.DataGridViewFlex grdEngineModels;
		private System.Windows.Forms.TextBox _txtEngineModel_15;
		private System.Windows.Forms.TextBox _txtEngineModel_14;
		private System.Windows.Forms.TextBox _txtEngineModel_13;
		private System.Windows.Forms.TextBox _txtEngineModel_12;
		private System.Windows.Forms.TextBox _txtEngineModel_11;
		public System.Windows.Forms.Button cmdEngineModelsDelete;
		public System.Windows.Forms.Button cmdEngineModelsAdd;
		public System.Windows.Forms.Button cmdEngineModelsSave;
		public System.Windows.Forms.GroupBox frmEngineModelsAction;
		private System.Windows.Forms.TextBox _txtEngineModel_10;
		private System.Windows.Forms.TextBox _txtEngineModel_9;
		private System.Windows.Forms.TextBox _txtEngineModel_8;
		private System.Windows.Forms.TextBox _txtEngineModel_7;
		private System.Windows.Forms.TextBox _txtEngineModel_6;
		private System.Windows.Forms.TextBox _txtEngineModel_5;
		private System.Windows.Forms.TextBox _txtEngineModel_4;
		private System.Windows.Forms.TextBox _txtEngineModel_3;
		private System.Windows.Forms.TextBox _txtEngineModel_2;
		private System.Windows.Forms.TextBox _txtEngineModel_1;
		private System.Windows.Forms.CheckBox _chkEngineModel_1;
		private System.Windows.Forms.CheckBox _chkEngineModel_0;
		private System.Windows.Forms.TextBox _txtEngineModel_0;
		private System.Windows.Forms.Label _lblEngMdl_14;
		private System.Windows.Forms.Label _lblEngMdl_13;
		private System.Windows.Forms.Label _lblEngMdl_12;
		private System.Windows.Forms.Label _lblEngMdl_11;
		private System.Windows.Forms.Label _lblEngMdl_10;
		private System.Windows.Forms.Label _lblEngMdl_9;
		private System.Windows.Forms.Label _lblEngMdl_8;
		private System.Windows.Forms.Label _lblEngMdl_7;
		private System.Windows.Forms.Label _lblEngMdl_6;
		private System.Windows.Forms.Label _lblEngMdl_5;
		private System.Windows.Forms.Label _lblEngMdl_4;
		private System.Windows.Forms.Label _lblEngMdl_3;
		private System.Windows.Forms.Label _lblEngMdl_2;
		private System.Windows.Forms.Label _lblEngMdl_1;
		private System.Windows.Forms.Label _lblEngMdl_0;
		public System.Windows.Forms.GroupBox frmEngineModels;
		public System.Windows.Forms.Button cmdEngineModelsRefresh;
		public System.Windows.Forms.TextBox txtSearchEngineModelName;
		public System.Windows.Forms.CheckBox chkEMFindDuplicate;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage20;
		public System.Windows.Forms.Button cmd_Launch_av_items;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage21;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage22;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage23;
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
		public System.Windows.Forms.CheckBox chkShowCounts;
		public System.Windows.Forms.CheckBox chk_AutoGen;
		public System.Windows.Forms.TextBox txt_kfeat_query;
		public System.Windows.Forms.Label lbl_rule_note;
		private System.Windows.Forms.Label _lblCount_2;
		private System.Windows.Forms.Label _lblCount_1;
		private System.Windows.Forms.Label _lblCount_0;
		public System.Windows.Forms.Label Label39;
		public System.Windows.Forms.Label lbl_kfeat_query;
		public System.Windows.Forms.Panel pnlAdmin;
		private System.Windows.Forms.Label _lbl_generic_2;
		public System.Windows.Forms.Label[] Label19 = new System.Windows.Forms.Label[4];
		public System.Windows.Forms.Label[] Label24 = new System.Windows.Forms.Label[46];
		public System.Windows.Forms.Label[] Label40 = new System.Windows.Forms.Label[5];
		public System.Windows.Forms.TextBox[] Text1 = new System.Windows.Forms.TextBox[1];
		public System.Windows.Forms.CheckBox[] check_prod_code = new System.Windows.Forms.CheckBox[3];
		public System.Windows.Forms.CheckBox[] chkAirportListOptions = new System.Windows.Forms.CheckBox[9];
		public System.Windows.Forms.CheckBox[] chkEngineModel = new System.Windows.Forms.CheckBox[2];
		public System.Windows.Forms.CheckBox[] chk_maint = new System.Windows.Forms.CheckBox[2];
		public System.Windows.Forms.CheckBox[] chk_product_flags = new System.Windows.Forms.CheckBox[4];
		public System.Windows.Forms.Button[] cmdAirportPreviousNext = new System.Windows.Forms.Button[2];
		public System.Windows.Forms.Button[] cmd_button = new System.Windows.Forms.Button[4];
		public System.Windows.Forms.Button[] cmd_maint = new System.Windows.Forms.Button[7];
		public System.Windows.Forms.Label[] lblAirport = new System.Windows.Forms.Label[27];
		public System.Windows.Forms.Label[] lblCount = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.Label[] lblEngMdl = new System.Windows.Forms.Label[15];
		public System.Windows.Forms.Label[] lblExportToExcel = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] lbl_Airport_Message = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] lbl_generic = new System.Windows.Forms.Label[13];
		public System.Windows.Forms.Label[] lbl_kfeat_code = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.TextBox[] txtAirport = new System.Windows.Forms.TextBox[20];
		public System.Windows.Forms.TextBox[] txtEngineModel = new System.Windows.Forms.TextBox[16];
		public System.Windows.Forms.TextBox[] txtFuelCost = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_certification_name = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] txt_fuel_price_notes = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.TextBox[] txt_maint = new System.Windows.Forms.TextBox[5];
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
			resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AircraftLookup));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnu_File = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileLogout = new System.Windows.Forms.ToolStripMenuItem();
			tab_Lookup = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_Lookup_TabPage0 = new System.Windows.Forms.TabPage();
			lbl_kfeat_codename = new System.Windows.Forms.Label();
			pnl_kfeat_test = new System.Windows.Forms.Panel();
			cbo_feat_area = new System.Windows.Forms.ComboBox();
			_chk_product_flags_3 = new System.Windows.Forms.CheckBox();
			_chk_product_flags_2 = new System.Windows.Forms.CheckBox();
			_chk_product_flags_1 = new System.Windows.Forms.CheckBox();
			_chk_product_flags_0 = new System.Windows.Forms.CheckBox();
			txt_InactiveDate = new System.Windows.Forms.TextBox();
			chk_kfeat_donotclear = new System.Windows.Forms.CheckBox();
			txt_kfeat_wheretoenter = new System.Windows.Forms.TextBox();
			txt_kfeat_howtoformat = new System.Windows.Forms.TextBox();
			chk_Inactive_Feature_Code = new System.Windows.Forms.CheckBox();
			txt_kfeat_research_notes = new System.Windows.Forms.TextBox();
			txt_kfeat_description = new System.Windows.Forms.TextBox();
			txt_kfeat_name = new System.Windows.Forms.TextBox();
			cmd_Delete_Kfeat = new System.Windows.Forms.Button();
			cmd_Cancel_Kfeat = new System.Windows.Forms.Button();
			cmd_Save_Kfeat = new System.Windows.Forms.Button();
			txt_kfeat_code = new System.Windows.Forms.TextBox();
			_Label24_44 = new System.Windows.Forms.Label();
			_Label24_19 = new System.Windows.Forms.Label();
			_Label24_18 = new System.Windows.Forms.Label();
			_Label24_17 = new System.Windows.Forms.Label();
			_Label24_16 = new System.Windows.Forms.Label();
			_Label24_15 = new System.Windows.Forms.Label();
			_lbl_kfeat_code_0 = new System.Windows.Forms.Label();
			cmd_Add_Kfeat = new System.Windows.Forms.Button();
			FG_KeyFeature = new UpgradeHelpers.DataGridViewFlex(components);
			frame_automodels = new System.Windows.Forms.GroupBox();
			cmd_CloseAutoModel = new System.Windows.Forms.Button();
			grd_AutoMod = new UpgradeHelpers.DataGridViewFlex(components);
			lbl_modeltext = new System.Windows.Forms.Label();
			chk_show_inactive = new System.Windows.Forms.CheckBox();
			_tab_Lookup_TabPage1 = new System.Windows.Forms.TabPage();
			FG_Aircraft_Status = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_Aircraft_Status = new System.Windows.Forms.Button();
			pnl_Update_Aircraft_Status = new System.Windows.Forms.Panel();
			txt_astat_description = new System.Windows.Forms.TextBox();
			txt_astat_name = new System.Windows.Forms.TextBox();
			cmd_Delete_Aircraft_Status = new System.Windows.Forms.Button();
			cmd_Cancel_Aircraft_Status = new System.Windows.Forms.Button();
			cmd_Save_Aircraft_Status = new System.Windows.Forms.Button();
			_Label24_21 = new System.Windows.Forms.Label();
			_Label24_20 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage2 = new System.Windows.Forms.TabPage();
			FG_AirCraft_Asking = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_Asking = new System.Windows.Forms.Button();
			pnl_NameDesc_Asking = new System.Windows.Forms.Panel();
			cmd_Save_Asking = new System.Windows.Forms.Button();
			cmd_Cancel_Asking = new System.Windows.Forms.Button();
			cmd_Delete_Asking = new System.Windows.Forms.Button();
			txt_aask_name = new System.Windows.Forms.TextBox();
			txt_aask_description = new System.Windows.Forms.TextBox();
			_Label24_23 = new System.Windows.Forms.Label();
			_Label24_22 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage3 = new System.Windows.Forms.TabPage();
			pnl_avionics_Update_Change = new System.Windows.Forms.Panel();
			txt_avion_notes = new System.Windows.Forms.TextBox();
			txt_avion_name = new System.Windows.Forms.TextBox();
			cmd_Delete_Avionics = new System.Windows.Forms.Button();
			cmd_Cancel_Avionics = new System.Windows.Forms.Button();
			cmd_Save_Avionics = new System.Windows.Forms.Button();
			_Label24_25 = new System.Windows.Forms.Label();
			_Label24_24 = new System.Windows.Forms.Label();
			cmd_Add_Avionics = new System.Windows.Forms.Button();
			FG_Avionics = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_Lookup_TabPage4 = new System.Windows.Forms.TabPage();
			FG_Aircraft_Class = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_Aircraft_Class = new System.Windows.Forms.Button();
			pnl_Aircraft_Class_AddUpdate = new System.Windows.Forms.Panel();
			cmd_Save_Aircraft_Class = new System.Windows.Forms.Button();
			cmd_Cancel_Aircraft_Class = new System.Windows.Forms.Button();
			cmd_Delete_Aircraft_Class = new System.Windows.Forms.Button();
			txt_aclass_code = new System.Windows.Forms.TextBox();
			txt_aclass_Name = new System.Windows.Forms.TextBox();
			_Label24_27 = new System.Windows.Forms.Label();
			_Label24_26 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage5 = new System.Windows.Forms.TabPage();
			FG_Aircraft_Type = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_Aircraft_type = new System.Windows.Forms.Button();
			pnl_Aircraft_Type_AddUpdate = new System.Windows.Forms.Panel();
			txt_atype_Name = new System.Windows.Forms.TextBox();
			txt_atype_code = new System.Windows.Forms.TextBox();
			cmd_Delete_Aircraft_Type = new System.Windows.Forms.Button();
			cmd_Cancel_Aircraft_Type = new System.Windows.Forms.Button();
			cmd_Save_Aircraft_Type = new System.Windows.Forms.Button();
			_Label24_29 = new System.Windows.Forms.Label();
			_Label24_28 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage6 = new System.Windows.Forms.TabPage();
			_Label24_45 = new System.Windows.Forms.Label();
			_lblExportToExcel_1 = new System.Windows.Forms.Label();
			pnl_EMP_AddUpdate = new System.Windows.Forms.Panel();
			txt_Program_Name = new System.Windows.Forms.TextBox();
			txt_Provider_Name = new System.Windows.Forms.TextBox();
			txt_Emp_ID = new System.Windows.Forms.TextBox();
			cmd_Save_EMP = new System.Windows.Forms.Button();
			cmd_Cancel_EMP = new System.Windows.Forms.Button();
			cmd_Delete_EMP = new System.Windows.Forms.Button();
			txt_emp_code = new System.Windows.Forms.TextBox();
			txt_emp_name = new System.Windows.Forms.TextBox();
			_Label24_33 = new System.Windows.Forms.Label();
			_Label24_32 = new System.Windows.Forms.Label();
			_Label24_31 = new System.Windows.Forms.Label();
			_Label24_30 = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			cmd_Add_EMP = new System.Windows.Forms.Button();
			FG_Engine_Maintenance = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_Lookup_TabPage7 = new System.Windows.Forms.TabPage();
			FG_Interior_Configuration = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_IC = new System.Windows.Forms.Button();
			pnl_IC_Update_Change = new System.Windows.Forms.Panel();
			cmd_Save_IC = new System.Windows.Forms.Button();
			cmd_Cancel_IC = new System.Windows.Forms.Button();
			cmd_Delete_IC = new System.Windows.Forms.Button();
			txt_intconfig_name = new System.Windows.Forms.TextBox();
			_Label24_34 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage8 = new System.Windows.Forms.TabPage();
			cmd_Add_Aircraft_Contact_type = new System.Windows.Forms.Button();
			pnl_Aircraft_Contact_Type_List = new System.Windows.Forms.Panel();
			FGRD_AircraftContactType = new UpgradeHelpers.DataGridViewFlex(components);
			cboShow = new System.Windows.Forms.ComboBox();
			_Label24_39 = new System.Windows.Forms.Label();
			pnl_ACTypeMain = new System.Windows.Forms.Panel();
			cmd_Delete_Aircraft_Contact_Type = new System.Windows.Forms.Button();
			cmd_Cancel_Aircraft_Contact_Type = new System.Windows.Forms.Button();
			cmd_Save_Aircraft_Contact_Type = new System.Windows.Forms.Button();
			pnl_Aircraft_Contact_Type_AddUpdate = new System.Windows.Forms.Panel();
			txt_actype_Name = new System.Windows.Forms.TextBox();
			txt_actype_code = new System.Windows.Forms.TextBox();
			txt_actype_abbrev = new System.Windows.Forms.TextBox();
			txt_actype_use_flag = new System.Windows.Forms.TextBox();
			_Label24_38 = new System.Windows.Forms.Label();
			_Label24_37 = new System.Windows.Forms.Label();
			_Label24_36 = new System.Windows.Forms.Label();
			_Label24_35 = new System.Windows.Forms.Label();
			pnl_CompanyRelationship = new System.Windows.Forms.Panel();
			chk_actype_shareref_flag = new System.Windows.Forms.CheckBox();
			chk_actype_transref_flag = new System.Windows.Forms.CheckBox();
			chk_actype_acref_flag = new System.Windows.Forms.CheckBox();
			txt_compref_name2 = new System.Windows.Forms.TextBox();
			chk_compref_internal_flag = new System.Windows.Forms.CheckBox();
			chk_compref_twoway_flag = new System.Windows.Forms.CheckBox();
			chk_actype_compref_flag = new System.Windows.Forms.CheckBox();
			Label36 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage9 = new System.Windows.Forms.TabPage();
			FG_Auxiliary_Power = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_APU = new System.Windows.Forms.Button();
			pnl_APU_Update_Change = new System.Windows.Forms.Panel();
			cmd_Save_APU = new System.Windows.Forms.Button();
			cmd_Cancel_APU = new System.Windows.Forms.Button();
			cmd_Delete_APU = new System.Windows.Forms.Button();
			txt_apu_make_name = new System.Windows.Forms.TextBox();
			txt_apu_model_name = new System.Windows.Forms.TextBox();
			_Label24_41 = new System.Windows.Forms.Label();
			_Label24_40 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage10 = new System.Windows.Forms.TabPage();
			FG_Operating_Certification = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_Certification = new System.Windows.Forms.Button();
			pnl_Certification_Update_Change = new System.Windows.Forms.Panel();
			chkCertActive = new System.Windows.Forms.CheckBox();
			cbo_Ops_Cert_usaFlag = new System.Windows.Forms.ComboBox();
			_txt_certification_name_2 = new System.Windows.Forms.TextBox();
			_txt_certification_name_0 = new System.Windows.Forms.TextBox();
			cmd_Delete_Certification = new System.Windows.Forms.Button();
			cmd_Cancel_Certification = new System.Windows.Forms.Button();
			cmd_Save_Certification = new System.Windows.Forms.Button();
			_Label19_3 = new System.Windows.Forms.Label();
			_Label19_2 = new System.Windows.Forms.Label();
			_Label19_1 = new System.Windows.Forms.Label();
			_Label19_0 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage11 = new System.Windows.Forms.TabPage();
			FG_Specification = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_Spec = new System.Windows.Forms.Button();
			pnl_Spec_Update_Change = new System.Windows.Forms.Panel();
			txt_spec_notes = new System.Windows.Forms.TextBox();
			txt_spec_name = new System.Windows.Forms.TextBox();
			cmd_Delete_Spec = new System.Windows.Forms.Button();
			cmd_Cancel_Spec = new System.Windows.Forms.Button();
			cmd_Save_Spec = new System.Windows.Forms.Button();
			txt_spec_type = new System.Windows.Forms.TextBox();
			_Label24_2 = new System.Windows.Forms.Label();
			_Label24_1 = new System.Windows.Forms.Label();
			_Label24_0 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage12 = new System.Windows.Forms.TabPage();
			_lblAirport_10 = new System.Windows.Forms.Label();
			pnl_airport_Update_Change = new System.Windows.Forms.Panel();
			pnl_airport_update = new System.Windows.Forms.Panel();
			_cmdAirportPreviousNext_1 = new System.Windows.Forms.Button();
			_cmdAirportPreviousNext_0 = new System.Windows.Forms.Button();
			cmd_Airport_Add = new System.Windows.Forms.Button();
			frmLatitudeLongatude = new System.Windows.Forms.GroupBox();
			_txtAirport_9 = new System.Windows.Forms.TextBox();
			_txtAirport_10 = new System.Windows.Forms.TextBox();
			_txtAirport_11 = new System.Windows.Forms.TextBox();
			_txtAirport_12 = new System.Windows.Forms.TextBox();
			_txtAirport_13 = new System.Windows.Forms.TextBox();
			_txtAirport_17 = new System.Windows.Forms.TextBox();
			_txtAirport_16 = new System.Windows.Forms.TextBox();
			_txtAirport_8 = new System.Windows.Forms.TextBox();
			_txtAirport_7 = new System.Windows.Forms.TextBox();
			_txtAirport_6 = new System.Windows.Forms.TextBox();
			_txtAirport_5 = new System.Windows.Forms.TextBox();
			_txtAirport_4 = new System.Windows.Forms.TextBox();
			lblLatitudeGPS = new System.Windows.Forms.Label();
			_lblAirport_24 = new System.Windows.Forms.Label();
			_lblAirport_19 = new System.Windows.Forms.Label();
			_lblAirport_8 = new System.Windows.Forms.Label();
			_lblAirport_7 = new System.Windows.Forms.Label();
			_lblAirport_6 = new System.Windows.Forms.Label();
			_lblAirport_5 = new System.Windows.Forms.Label();
			_lblAirport_4 = new System.Windows.Forms.Label();
			cmd_Airport_Delete = new System.Windows.Forms.Button();
			cmd_Airport_Cancel = new System.Windows.Forms.Button();
			cmd_Airport_Save = new System.Windows.Forms.Button();
			frmAirport = new System.Windows.Forms.GroupBox();
			_txtAirport_19 = new System.Windows.Forms.TextBox();
			_txtAirport_18 = new System.Windows.Forms.TextBox();
			_txtAirport_15 = new System.Windows.Forms.TextBox();
			_txtAirport_14 = new System.Windows.Forms.TextBox();
			chk_aport_active_flag = new System.Windows.Forms.CheckBox();
			_txtAirport_3 = new System.Windows.Forms.TextBox();
			_txtAirport_2 = new System.Windows.Forms.TextBox();
			_txtAirport_1 = new System.Windows.Forms.TextBox();
			_txtAirport_0 = new System.Windows.Forms.TextBox();
			cbo_aport_state = new System.Windows.Forms.ComboBox();
			cbo_aport_country = new System.Windows.Forms.ComboBox();
			_lblAirport_20 = new System.Windows.Forms.Label();
			_lblAirport_13 = new System.Windows.Forms.Label();
			_lblAirport_12 = new System.Windows.Forms.Label();
			_lblAirport_11 = new System.Windows.Forms.Label();
			_lblAirport_9 = new System.Windows.Forms.Label();
			_lblAirport_26 = new System.Windows.Forms.Label();
			_lblAirport_23 = new System.Windows.Forms.Label();
			_lblAirport_22 = new System.Windows.Forms.Label();
			_lblAirport_18 = new System.Windows.Forms.Label();
			_lblAirport_21 = new System.Windows.Forms.Label();
			_lblAirport_17 = new System.Windows.Forms.Label();
			_lblAirport_16 = new System.Windows.Forms.Label();
			_lblAirport_15 = new System.Windows.Forms.Label();
			_lblAirport_14 = new System.Windows.Forms.Label();
			lbl_aircraft_count = new System.Windows.Forms.Label();
			_lblAirport_3 = new System.Windows.Forms.Label();
			_lblAirport_2 = new System.Windows.Forms.Label();
			_lblAirport_1 = new System.Windows.Forms.Label();
			_lblAirport_0 = new System.Windows.Forms.Label();
			SSPanel3 = new System.Windows.Forms.Panel();
			txtGlobal = new System.Windows.Forms.TextBox();
			cbo_Airport_Index = new System.Windows.Forms.ComboBox();
			cbo_faaid_index = new System.Windows.Forms.ComboBox();
			_chkAirportListOptions_8 = new System.Windows.Forms.CheckBox();
			_chkAirportListOptions_7 = new System.Windows.Forms.CheckBox();
			_chkAirportListOptions_6 = new System.Windows.Forms.CheckBox();
			_chkAirportListOptions_4 = new System.Windows.Forms.CheckBox();
			_chkAirportListOptions_5 = new System.Windows.Forms.CheckBox();
			_chkAirportListOptions_3 = new System.Windows.Forms.CheckBox();
			_chkAirportListOptions_2 = new System.Windows.Forms.CheckBox();
			_chkAirportListOptions_1 = new System.Windows.Forms.CheckBox();
			txt_AirportColor = new System.Windows.Forms.TextBox();
			cbo_icao_index = new System.Windows.Forms.ComboBox();
			cbo_iata_index = new System.Windows.Forms.ComboBox();
			cmd_Refresh_Airports = new System.Windows.Forms.Button();
			_chkAirportListOptions_0 = new System.Windows.Forms.CheckBox();
			grd_Airport = new UpgradeHelpers.DataGridViewFlex(components);
			lblGlobal = new System.Windows.Forms.Label();
			lblICAOIndex = new System.Windows.Forms.Label();
			lblFAAIDIndex = new System.Windows.Forms.Label();
			lbl_Airport_Count = new System.Windows.Forms.Label();
			lblIATAIndex = new System.Windows.Forms.Label();
			lblNameIndex = new System.Windows.Forms.Label();
			_lbl_Airport_Message_1 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage13 = new System.Windows.Forms.TabPage();
			pnl_Certified_Update_Change = new System.Windows.Forms.Panel();
			cmd_save_certified = new System.Windows.Forms.Button();
			cmd_cancel_certified = new System.Windows.Forms.Button();
			cmd_delete_certified = new System.Windows.Forms.Button();
			txt_cert_name_cert = new System.Windows.Forms.TextBox();
			_Label24_3 = new System.Windows.Forms.Label();
			cmd_certified_add = new System.Windows.Forms.Button();
			FGRD_Certifed = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_Lookup_TabPage14 = new System.Windows.Forms.TabPage();
			_tab_Lookup_TabPage15 = new System.Windows.Forms.TabPage();
			cmdAddCREG = new System.Windows.Forms.Button();
			grdCREG = new UpgradeHelpers.DataGridViewFlex(components);
			pnl_CREG = new System.Windows.Forms.Panel();
			txt_crm_amod_list = new System.Windows.Forms.TextBox();
			txt_crm_id = new System.Windows.Forms.TextBox();
			cbo_CREG = new System.Windows.Forms.ComboBox();
			txt_crm_model = new System.Windows.Forms.TextBox();
			cmdSaveCREG = new System.Windows.Forms.Button();
			cmdCancelCREG = new System.Windows.Forms.Button();
			cmdDeleteCREG = new System.Windows.Forms.Button();
			txt_crm_Make = new System.Windows.Forms.TextBox();
			_Label40_4 = new System.Windows.Forms.Label();
			_Label40_3 = new System.Windows.Forms.Label();
			_Label40_1 = new System.Windows.Forms.Label();
			_Label40_0 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage16 = new System.Windows.Forms.TabPage();
			_cmd_button_2 = new System.Windows.Forms.Button();
			_Text1_0 = new System.Windows.Forms.TextBox();
			_cmd_button_1 = new System.Windows.Forms.Button();
			_cmd_button_0 = new System.Windows.Forms.Button();
			grd_ABI_Hide_AC = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_generic_7 = new System.Windows.Forms.Label();
			_lbl_generic_6 = new System.Windows.Forms.Label();
			_lbl_generic_5 = new System.Windows.Forms.Label();
			_lbl_generic_4 = new System.Windows.Forms.Label();
			_lbl_generic_3 = new System.Windows.Forms.Label();
			_lbl_generic_1 = new System.Windows.Forms.Label();
			_lbl_generic_0 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage17 = new System.Windows.Forms.TabPage();
			frmFuelPrices = new System.Windows.Forms.GroupBox();
			_txtFuelCost_3 = new System.Windows.Forms.TextBox();
			_txt_fuel_price_notes_3 = new System.Windows.Forms.TextBox();
			_txt_fuel_price_notes_2 = new System.Windows.Forms.TextBox();
			_txt_fuel_price_notes_1 = new System.Windows.Forms.TextBox();
			_txt_fuel_price_notes_0 = new System.Windows.Forms.TextBox();
			_cmd_button_3 = new System.Windows.Forms.Button();
			_txtFuelCost_2 = new System.Windows.Forms.TextBox();
			_txtFuelCost_1 = new System.Windows.Forms.TextBox();
			_txtFuelCost_0 = new System.Windows.Forms.TextBox();
			_lbl_generic_12 = new System.Windows.Forms.Label();
			_lbl_generic_9 = new System.Windows.Forms.Label();
			_lbl_generic_11 = new System.Windows.Forms.Label();
			_lbl_generic_10 = new System.Windows.Forms.Label();
			_lbl_generic_8 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage18 = new System.Windows.Forms.TabPage();
			acTopicsUpdateEvo = new System.Windows.Forms.Button();
			acTopicArea = new System.Windows.Forms.ComboBox();
			acTopicAdd = new System.Windows.Forms.Button();
			acTopicsGrid = new UpgradeHelpers.DataGridViewFlex(components);
			acTopicsPanel = new System.Windows.Forms.Panel();
			_check_prod_code_2 = new System.Windows.Forms.CheckBox();
			_check_prod_code_1 = new System.Windows.Forms.CheckBox();
			_check_prod_code_0 = new System.Windows.Forms.CheckBox();
			acTopicParentTopic = new System.Windows.Forms.ComboBox();
			acTopicItemName = new System.Windows.Forms.TextBox();
			acTopicItemQuery = new System.Windows.Forms.TextBox();
			acTopicAerodexFlag = new System.Windows.Forms.CheckBox();
			acTopicAreaItem = new System.Windows.Forms.ComboBox();
			acTopicSave = new System.Windows.Forms.Button();
			acTopicCancel = new System.Windows.Forms.Button();
			acTopicDelete = new System.Windows.Forms.Button();
			acTopicItemDescription = new System.Windows.Forms.TextBox();
			_Label24_8 = new System.Windows.Forms.Label();
			_Label24_7 = new System.Windows.Forms.Label();
			_Label24_6 = new System.Windows.Forms.Label();
			_Label24_5 = new System.Windows.Forms.Label();
			_Label24_4 = new System.Windows.Forms.Label();
			acTopicIDLabel = new System.Windows.Forms.Label();
			acTopicsAircraftFrame = new System.Windows.Forms.GroupBox();
			acTopicsListClose = new System.Windows.Forms.Button();
			acTopicAircraftList = new UpgradeHelpers.DataGridViewFlex(components);
			acTopicAircraftListLabel = new System.Windows.Forms.Label();
			acTopicErrorDisplay = new System.Windows.Forms.Label();
			Label20 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage19 = new System.Windows.Forms.TabPage();
			_Label24_9 = new System.Windows.Forms.Label();
			_Label24_10 = new System.Windows.Forms.Label();
			_Label24_11 = new System.Windows.Forms.Label();
			_Label24_12 = new System.Windows.Forms.Label();
			_Label24_13 = new System.Windows.Forms.Label();
			_Label24_14 = new System.Windows.Forms.Label();
			_Label24_42 = new System.Windows.Forms.Label();
			_Label24_43 = new System.Windows.Forms.Label();
			grd_maint_items = new UpgradeHelpers.DataGridViewFlex(components);
			_txt_maint_0 = new System.Windows.Forms.TextBox();
			_txt_maint_1 = new System.Windows.Forms.TextBox();
			_txt_maint_2 = new System.Windows.Forms.TextBox();
			_chk_maint_0 = new System.Windows.Forms.CheckBox();
			_chk_maint_1 = new System.Windows.Forms.CheckBox();
			_txt_maint_3 = new System.Windows.Forms.TextBox();
			cbo_maint_type = new System.Windows.Forms.ComboBox();
			_cmd_maint_0 = new System.Windows.Forms.Button();
			_cmd_maint_1 = new System.Windows.Forms.Button();
			_cmd_maint_2 = new System.Windows.Forms.Button();
			_cmd_maint_3 = new System.Windows.Forms.Button();
			_cmd_maint_4 = new System.Windows.Forms.Button();
			cmd_post = new System.Windows.Forms.Button();
			_txt_maint_4 = new System.Windows.Forms.TextBox();
			_cmd_maint_5 = new System.Windows.Forms.Button();
			_cmd_maint_6 = new System.Windows.Forms.Button();
			_tab_Lookup_TabPage20 = new System.Windows.Forms.TabPage();
			lblEngineModelsStop = new System.Windows.Forms.Label();
			lblSearchEngineModelName = new System.Windows.Forms.Label();
			lblLoading = new System.Windows.Forms.Label();
			lblEMStatus = new System.Windows.Forms.Label();
			_lblExportToExcel_0 = new System.Windows.Forms.Label();
			grdEngineModels = new UpgradeHelpers.DataGridViewFlex(components);
			frmEngineModels = new System.Windows.Forms.GroupBox();
			_txtEngineModel_15 = new System.Windows.Forms.TextBox();
			_txtEngineModel_14 = new System.Windows.Forms.TextBox();
			_txtEngineModel_13 = new System.Windows.Forms.TextBox();
			_txtEngineModel_12 = new System.Windows.Forms.TextBox();
			_txtEngineModel_11 = new System.Windows.Forms.TextBox();
			frmEngineModelsAction = new System.Windows.Forms.GroupBox();
			cmdEngineModelsDelete = new System.Windows.Forms.Button();
			cmdEngineModelsAdd = new System.Windows.Forms.Button();
			cmdEngineModelsSave = new System.Windows.Forms.Button();
			_txtEngineModel_10 = new System.Windows.Forms.TextBox();
			_txtEngineModel_9 = new System.Windows.Forms.TextBox();
			_txtEngineModel_8 = new System.Windows.Forms.TextBox();
			_txtEngineModel_7 = new System.Windows.Forms.TextBox();
			_txtEngineModel_6 = new System.Windows.Forms.TextBox();
			_txtEngineModel_5 = new System.Windows.Forms.TextBox();
			_txtEngineModel_4 = new System.Windows.Forms.TextBox();
			_txtEngineModel_3 = new System.Windows.Forms.TextBox();
			_txtEngineModel_2 = new System.Windows.Forms.TextBox();
			_txtEngineModel_1 = new System.Windows.Forms.TextBox();
			_chkEngineModel_1 = new System.Windows.Forms.CheckBox();
			_chkEngineModel_0 = new System.Windows.Forms.CheckBox();
			_txtEngineModel_0 = new System.Windows.Forms.TextBox();
			_lblEngMdl_14 = new System.Windows.Forms.Label();
			_lblEngMdl_13 = new System.Windows.Forms.Label();
			_lblEngMdl_12 = new System.Windows.Forms.Label();
			_lblEngMdl_11 = new System.Windows.Forms.Label();
			_lblEngMdl_10 = new System.Windows.Forms.Label();
			_lblEngMdl_9 = new System.Windows.Forms.Label();
			_lblEngMdl_8 = new System.Windows.Forms.Label();
			_lblEngMdl_7 = new System.Windows.Forms.Label();
			_lblEngMdl_6 = new System.Windows.Forms.Label();
			_lblEngMdl_5 = new System.Windows.Forms.Label();
			_lblEngMdl_4 = new System.Windows.Forms.Label();
			_lblEngMdl_3 = new System.Windows.Forms.Label();
			_lblEngMdl_2 = new System.Windows.Forms.Label();
			_lblEngMdl_1 = new System.Windows.Forms.Label();
			_lblEngMdl_0 = new System.Windows.Forms.Label();
			cmdEngineModelsRefresh = new System.Windows.Forms.Button();
			txtSearchEngineModelName = new System.Windows.Forms.TextBox();
			chkEMFindDuplicate = new System.Windows.Forms.CheckBox();
			_tab_Lookup_TabPage21 = new System.Windows.Forms.TabPage();
			cmd_Launch_av_items = new System.Windows.Forms.Button();
			_tab_Lookup_TabPage22 = new System.Windows.Forms.TabPage();
			_tab_Lookup_TabPage23 = new System.Windows.Forms.TabPage();
			tbr_ToolBar = new System.Windows.Forms.ToolStrip();
			tbr_ToolBar_Buttons_Button1 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button2 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button3 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button4 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button5 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button6 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button7 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button8 = new System.Windows.Forms.ToolStripButton();
			pnlAdmin = new System.Windows.Forms.Panel();
			chkShowCounts = new System.Windows.Forms.CheckBox();
			chk_AutoGen = new System.Windows.Forms.CheckBox();
			txt_kfeat_query = new System.Windows.Forms.TextBox();
			lbl_rule_note = new System.Windows.Forms.Label();
			_lblCount_2 = new System.Windows.Forms.Label();
			_lblCount_1 = new System.Windows.Forms.Label();
			_lblCount_0 = new System.Windows.Forms.Label();
			Label39 = new System.Windows.Forms.Label();
			lbl_kfeat_query = new System.Windows.Forms.Label();
			_lbl_generic_2 = new System.Windows.Forms.Label();
			tab_Lookup.SuspendLayout();
			_tab_Lookup_TabPage0.SuspendLayout();
			pnl_kfeat_test.SuspendLayout();
			frame_automodels.SuspendLayout();
			_tab_Lookup_TabPage1.SuspendLayout();
			pnl_Update_Aircraft_Status.SuspendLayout();
			_tab_Lookup_TabPage2.SuspendLayout();
			pnl_NameDesc_Asking.SuspendLayout();
			_tab_Lookup_TabPage3.SuspendLayout();
			pnl_avionics_Update_Change.SuspendLayout();
			_tab_Lookup_TabPage4.SuspendLayout();
			pnl_Aircraft_Class_AddUpdate.SuspendLayout();
			_tab_Lookup_TabPage5.SuspendLayout();
			pnl_Aircraft_Type_AddUpdate.SuspendLayout();
			_tab_Lookup_TabPage6.SuspendLayout();
			pnl_EMP_AddUpdate.SuspendLayout();
			_tab_Lookup_TabPage7.SuspendLayout();
			pnl_IC_Update_Change.SuspendLayout();
			_tab_Lookup_TabPage8.SuspendLayout();
			pnl_Aircraft_Contact_Type_List.SuspendLayout();
			pnl_ACTypeMain.SuspendLayout();
			pnl_Aircraft_Contact_Type_AddUpdate.SuspendLayout();
			pnl_CompanyRelationship.SuspendLayout();
			_tab_Lookup_TabPage9.SuspendLayout();
			pnl_APU_Update_Change.SuspendLayout();
			_tab_Lookup_TabPage10.SuspendLayout();
			pnl_Certification_Update_Change.SuspendLayout();
			_tab_Lookup_TabPage11.SuspendLayout();
			pnl_Spec_Update_Change.SuspendLayout();
			_tab_Lookup_TabPage12.SuspendLayout();
			pnl_airport_Update_Change.SuspendLayout();
			pnl_airport_update.SuspendLayout();
			frmLatitudeLongatude.SuspendLayout();
			frmAirport.SuspendLayout();
			SSPanel3.SuspendLayout();
			_tab_Lookup_TabPage13.SuspendLayout();
			pnl_Certified_Update_Change.SuspendLayout();
			_tab_Lookup_TabPage15.SuspendLayout();
			pnl_CREG.SuspendLayout();
			_tab_Lookup_TabPage16.SuspendLayout();
			_tab_Lookup_TabPage17.SuspendLayout();
			frmFuelPrices.SuspendLayout();
			_tab_Lookup_TabPage18.SuspendLayout();
			acTopicsPanel.SuspendLayout();
			acTopicsAircraftFrame.SuspendLayout();
			_tab_Lookup_TabPage19.SuspendLayout();
			_tab_Lookup_TabPage20.SuspendLayout();
			frmEngineModels.SuspendLayout();
			frmEngineModelsAction.SuspendLayout();
			_tab_Lookup_TabPage21.SuspendLayout();
			tbr_ToolBar.SuspendLayout();
			pnlAdmin.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) FG_KeyFeature).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_AutoMod).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Aircraft_Status).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_AirCraft_Asking).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Avionics).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Aircraft_Class).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Aircraft_Type).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Engine_Maintenance).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Interior_Configuration).BeginInit();
			((System.ComponentModel.ISupportInitialize) FGRD_AircraftContactType).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Auxiliary_Power).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Operating_Certification).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Specification).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Airport).BeginInit();
			((System.ComponentModel.ISupportInitialize) FGRD_Certifed).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdCREG).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_ABI_Hide_AC).BeginInit();
			((System.ComponentModel.ISupportInitialize) acTopicsGrid).BeginInit();
			((System.ComponentModel.ISupportInitialize) acTopicAircraftList).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_maint_items).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdEngineModels).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnu_File});
			// 
			// mnu_File
			// 
			mnu_File.Available = true;
			mnu_File.Checked = false;
			mnu_File.Enabled = true;
			mnu_File.Name = "mnu_File";
			mnu_File.Text = "&File";
			mnu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFileClose, mnuFileLogout});
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
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage12);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage13);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage14);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage15);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage16);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage17);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage18);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage19);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage20);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage21);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage22);
			tab_Lookup.Controls.Add(_tab_Lookup_TabPage23);
			tab_Lookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_Lookup.ItemSize = new System.Drawing.Size(175, 18);
			tab_Lookup.Location = new System.Drawing.Point(0, 56);
			tab_Lookup.Multiline = true;
			tab_Lookup.Name = "tab_Lookup";
			tab_Lookup.Size = new System.Drawing.Size(1065, 550);
			tab_Lookup.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_Lookup.TabIndex = 2;
			tab_Lookup.SelectedIndexChanged += new System.EventHandler(tab_Lookup_SelectedIndexChanged);
			// 
			// _tab_Lookup_TabPage0
			// 
			_tab_Lookup_TabPage0.Controls.Add(lbl_kfeat_codename);
			_tab_Lookup_TabPage0.Controls.Add(pnl_kfeat_test);
			_tab_Lookup_TabPage0.Controls.Add(cmd_Add_Kfeat);
			_tab_Lookup_TabPage0.Controls.Add(FG_KeyFeature);
			_tab_Lookup_TabPage0.Controls.Add(frame_automodels);
			_tab_Lookup_TabPage0.Controls.Add(chk_show_inactive);
			_tab_Lookup_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage0.Text = "Key Features";
			// 
			// lbl_kfeat_codename
			// 
			lbl_kfeat_codename.AllowDrop = true;
			lbl_kfeat_codename.BackColor = System.Drawing.SystemColors.Control;
			lbl_kfeat_codename.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_kfeat_codename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_kfeat_codename.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_kfeat_codename.Location = new System.Drawing.Point(16, 32);
			lbl_kfeat_codename.MinimumSize = new System.Drawing.Size(153, 17);
			lbl_kfeat_codename.Name = "lbl_kfeat_codename";
			lbl_kfeat_codename.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_kfeat_codename.Size = new System.Drawing.Size(153, 17);
			lbl_kfeat_codename.TabIndex = 0;
			lbl_kfeat_codename.Visible = false;
			// 
			// pnl_kfeat_test
			// 
			pnl_kfeat_test.AllowDrop = true;
			pnl_kfeat_test.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_kfeat_test.Controls.Add(cbo_feat_area);
			pnl_kfeat_test.Controls.Add(_chk_product_flags_3);
			pnl_kfeat_test.Controls.Add(_chk_product_flags_2);
			pnl_kfeat_test.Controls.Add(_chk_product_flags_1);
			pnl_kfeat_test.Controls.Add(_chk_product_flags_0);
			pnl_kfeat_test.Controls.Add(txt_InactiveDate);
			pnl_kfeat_test.Controls.Add(chk_kfeat_donotclear);
			pnl_kfeat_test.Controls.Add(txt_kfeat_wheretoenter);
			pnl_kfeat_test.Controls.Add(txt_kfeat_howtoformat);
			pnl_kfeat_test.Controls.Add(chk_Inactive_Feature_Code);
			pnl_kfeat_test.Controls.Add(txt_kfeat_research_notes);
			pnl_kfeat_test.Controls.Add(txt_kfeat_description);
			pnl_kfeat_test.Controls.Add(txt_kfeat_name);
			pnl_kfeat_test.Controls.Add(cmd_Delete_Kfeat);
			pnl_kfeat_test.Controls.Add(cmd_Cancel_Kfeat);
			pnl_kfeat_test.Controls.Add(cmd_Save_Kfeat);
			pnl_kfeat_test.Controls.Add(txt_kfeat_code);
			pnl_kfeat_test.Controls.Add(_Label24_44);
			pnl_kfeat_test.Controls.Add(_Label24_19);
			pnl_kfeat_test.Controls.Add(_Label24_18);
			pnl_kfeat_test.Controls.Add(_Label24_17);
			pnl_kfeat_test.Controls.Add(_Label24_16);
			pnl_kfeat_test.Controls.Add(_Label24_15);
			pnl_kfeat_test.Controls.Add(_lbl_kfeat_code_0);
			pnl_kfeat_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_kfeat_test.Location = new System.Drawing.Point(512, 48);
			pnl_kfeat_test.Name = "pnl_kfeat_test";
			pnl_kfeat_test.Size = new System.Drawing.Size(501, 393);
			pnl_kfeat_test.TabIndex = 8;
			// 
			// cbo_feat_area
			// 
			cbo_feat_area.AllowDrop = true;
			cbo_feat_area.BackColor = System.Drawing.SystemColors.Window;
			cbo_feat_area.CausesValidation = true;
			cbo_feat_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_feat_area.Enabled = true;
			cbo_feat_area.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_feat_area.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_feat_area.IntegralHeight = true;
			cbo_feat_area.Location = new System.Drawing.Point(8, 266);
			cbo_feat_area.Name = "cbo_feat_area";
			cbo_feat_area.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_feat_area.Size = new System.Drawing.Size(215, 21);
			cbo_feat_area.Sorted = false;
			cbo_feat_area.TabIndex = 403;
			cbo_feat_area.TabStop = true;
			cbo_feat_area.Visible = true;
			// 
			// _chk_product_flags_3
			// 
			_chk_product_flags_3.AllowDrop = true;
			_chk_product_flags_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_product_flags_3.BackColor = System.Drawing.SystemColors.Control;
			_chk_product_flags_3.CausesValidation = true;
			_chk_product_flags_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_product_flags_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_product_flags_3.Enabled = true;
			_chk_product_flags_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_product_flags_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_product_flags_3.Location = new System.Drawing.Point(304, 42);
			_chk_product_flags_3.Name = "_chk_product_flags_3";
			_chk_product_flags_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_product_flags_3.Size = new System.Drawing.Size(111, 15);
			_chk_product_flags_3.TabIndex = 401;
			_chk_product_flags_3.TabStop = true;
			_chk_product_flags_3.Text = "Model Dependant";
			_chk_product_flags_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_product_flags_3.Visible = true;
			// 
			// _chk_product_flags_2
			// 
			_chk_product_flags_2.AllowDrop = true;
			_chk_product_flags_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_product_flags_2.BackColor = System.Drawing.SystemColors.Control;
			_chk_product_flags_2.CausesValidation = true;
			_chk_product_flags_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_product_flags_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_product_flags_2.Enabled = true;
			_chk_product_flags_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_product_flags_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_product_flags_2.Location = new System.Drawing.Point(224, 42);
			_chk_product_flags_2.Name = "_chk_product_flags_2";
			_chk_product_flags_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_product_flags_2.Size = new System.Drawing.Size(71, 15);
			_chk_product_flags_2.TabIndex = 400;
			_chk_product_flags_2.TabStop = true;
			_chk_product_flags_2.Text = "Helicopter";
			_chk_product_flags_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_product_flags_2.Visible = true;
			// 
			// _chk_product_flags_1
			// 
			_chk_product_flags_1.AllowDrop = true;
			_chk_product_flags_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_product_flags_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_product_flags_1.CausesValidation = true;
			_chk_product_flags_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_product_flags_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_product_flags_1.Enabled = true;
			_chk_product_flags_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_product_flags_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_product_flags_1.Location = new System.Drawing.Point(138, 42);
			_chk_product_flags_1.Name = "_chk_product_flags_1";
			_chk_product_flags_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_product_flags_1.Size = new System.Drawing.Size(75, 15);
			_chk_product_flags_1.TabIndex = 399;
			_chk_product_flags_1.TabStop = true;
			_chk_product_flags_1.Text = "Commercial";
			_chk_product_flags_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_product_flags_1.Visible = true;
			// 
			// _chk_product_flags_0
			// 
			_chk_product_flags_0.AllowDrop = true;
			_chk_product_flags_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_product_flags_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_product_flags_0.CausesValidation = true;
			_chk_product_flags_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_product_flags_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_product_flags_0.Enabled = true;
			_chk_product_flags_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_product_flags_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_product_flags_0.Location = new System.Drawing.Point(62, 42);
			_chk_product_flags_0.Name = "_chk_product_flags_0";
			_chk_product_flags_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_product_flags_0.Size = new System.Drawing.Size(65, 15);
			_chk_product_flags_0.TabIndex = 398;
			_chk_product_flags_0.TabStop = true;
			_chk_product_flags_0.Text = "Business";
			_chk_product_flags_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_product_flags_0.Visible = true;
			// 
			// txt_InactiveDate
			// 
			txt_InactiveDate.AcceptsReturn = true;
			txt_InactiveDate.AllowDrop = true;
			txt_InactiveDate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_InactiveDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_InactiveDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_InactiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_InactiveDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_InactiveDate.Location = new System.Drawing.Point(346, 64);
			txt_InactiveDate.MaxLength = 0;
			txt_InactiveDate.Name = "txt_InactiveDate";
			txt_InactiveDate.ReadOnly = true;
			txt_InactiveDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_InactiveDate.Size = new System.Drawing.Size(81, 21);
			txt_InactiveDate.TabIndex = 164;
			txt_InactiveDate.Visible = false;
			// 
			// chk_kfeat_donotclear
			// 
			chk_kfeat_donotclear.AllowDrop = true;
			chk_kfeat_donotclear.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_kfeat_donotclear.BackColor = System.Drawing.SystemColors.Control;
			chk_kfeat_donotclear.CausesValidation = true;
			chk_kfeat_donotclear.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_kfeat_donotclear.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_kfeat_donotclear.Enabled = true;
			chk_kfeat_donotclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_kfeat_donotclear.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_kfeat_donotclear.Location = new System.Drawing.Point(302, 5);
			chk_kfeat_donotclear.Name = "chk_kfeat_donotclear";
			chk_kfeat_donotclear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_kfeat_donotclear.Size = new System.Drawing.Size(196, 15);
			chk_kfeat_donotclear.TabIndex = 13;
			chk_kfeat_donotclear.TabStop = true;
			chk_kfeat_donotclear.Text = "Do Not Clear When Clearing Specs";
			chk_kfeat_donotclear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_kfeat_donotclear.Visible = true;
			// 
			// txt_kfeat_wheretoenter
			// 
			txt_kfeat_wheretoenter.AcceptsReturn = true;
			txt_kfeat_wheretoenter.AllowDrop = true;
			txt_kfeat_wheretoenter.BackColor = System.Drawing.SystemColors.Window;
			txt_kfeat_wheretoenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_kfeat_wheretoenter.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_kfeat_wheretoenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_kfeat_wheretoenter.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_kfeat_wheretoenter.Location = new System.Drawing.Point(8, 358);
			txt_kfeat_wheretoenter.MaxLength = 100;
			txt_kfeat_wheretoenter.Multiline = true;
			txt_kfeat_wheretoenter.Name = "txt_kfeat_wheretoenter";
			txt_kfeat_wheretoenter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_kfeat_wheretoenter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txt_kfeat_wheretoenter.Size = new System.Drawing.Size(476, 33);
			txt_kfeat_wheretoenter.TabIndex = 19;
			// 
			// txt_kfeat_howtoformat
			// 
			txt_kfeat_howtoformat.AcceptsReturn = true;
			txt_kfeat_howtoformat.AllowDrop = true;
			txt_kfeat_howtoformat.BackColor = System.Drawing.SystemColors.Window;
			txt_kfeat_howtoformat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_kfeat_howtoformat.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_kfeat_howtoformat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_kfeat_howtoformat.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_kfeat_howtoformat.Location = new System.Drawing.Point(8, 306);
			txt_kfeat_howtoformat.MaxLength = 100;
			txt_kfeat_howtoformat.Multiline = true;
			txt_kfeat_howtoformat.Name = "txt_kfeat_howtoformat";
			txt_kfeat_howtoformat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_kfeat_howtoformat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txt_kfeat_howtoformat.Size = new System.Drawing.Size(476, 33);
			txt_kfeat_howtoformat.TabIndex = 18;
			// 
			// chk_Inactive_Feature_Code
			// 
			chk_Inactive_Feature_Code.AllowDrop = true;
			chk_Inactive_Feature_Code.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Inactive_Feature_Code.BackColor = System.Drawing.SystemColors.Control;
			chk_Inactive_Feature_Code.CausesValidation = true;
			chk_Inactive_Feature_Code.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Inactive_Feature_Code.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Inactive_Feature_Code.Enabled = true;
			chk_Inactive_Feature_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Inactive_Feature_Code.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Inactive_Feature_Code.Location = new System.Drawing.Point(302, 23);
			chk_Inactive_Feature_Code.Name = "chk_Inactive_Feature_Code";
			chk_Inactive_Feature_Code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Inactive_Feature_Code.Size = new System.Drawing.Size(85, 15);
			chk_Inactive_Feature_Code.TabIndex = 14;
			chk_Inactive_Feature_Code.TabStop = true;
			chk_Inactive_Feature_Code.Text = "Inactive";
			chk_Inactive_Feature_Code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Inactive_Feature_Code.Visible = true;
			// 
			// txt_kfeat_research_notes
			// 
			txt_kfeat_research_notes.AcceptsReturn = true;
			txt_kfeat_research_notes.AllowDrop = true;
			txt_kfeat_research_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_kfeat_research_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_kfeat_research_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_kfeat_research_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_kfeat_research_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_kfeat_research_notes.Location = new System.Drawing.Point(8, 182);
			txt_kfeat_research_notes.MaxLength = 250;
			txt_kfeat_research_notes.Multiline = true;
			txt_kfeat_research_notes.Name = "txt_kfeat_research_notes";
			txt_kfeat_research_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_kfeat_research_notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txt_kfeat_research_notes.Size = new System.Drawing.Size(476, 61);
			txt_kfeat_research_notes.TabIndex = 17;
			// 
			// txt_kfeat_description
			// 
			txt_kfeat_description.AcceptsReturn = true;
			txt_kfeat_description.AllowDrop = true;
			txt_kfeat_description.BackColor = System.Drawing.SystemColors.Window;
			txt_kfeat_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_kfeat_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_kfeat_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_kfeat_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_kfeat_description.Location = new System.Drawing.Point(8, 103);
			txt_kfeat_description.MaxLength = 500;
			txt_kfeat_description.Multiline = true;
			txt_kfeat_description.Name = "txt_kfeat_description";
			txt_kfeat_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_kfeat_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txt_kfeat_description.Size = new System.Drawing.Size(476, 64);
			txt_kfeat_description.TabIndex = 16;
			// 
			// txt_kfeat_name
			// 
			txt_kfeat_name.AcceptsReturn = true;
			txt_kfeat_name.AllowDrop = true;
			txt_kfeat_name.BackColor = System.Drawing.SystemColors.Window;
			txt_kfeat_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_kfeat_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_kfeat_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_kfeat_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_kfeat_name.Location = new System.Drawing.Point(8, 64);
			txt_kfeat_name.MaxLength = 60;
			txt_kfeat_name.Name = "txt_kfeat_name";
			txt_kfeat_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_kfeat_name.Size = new System.Drawing.Size(318, 21);
			txt_kfeat_name.TabIndex = 15;
			// 
			// cmd_Delete_Kfeat
			// 
			cmd_Delete_Kfeat.AllowDrop = true;
			cmd_Delete_Kfeat.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Kfeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Kfeat.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Kfeat.Location = new System.Drawing.Point(189, 4);
			cmd_Delete_Kfeat.Name = "cmd_Delete_Kfeat";
			cmd_Delete_Kfeat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Kfeat.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Kfeat.TabIndex = 12;
			cmd_Delete_Kfeat.Text = "&Delete";
			cmd_Delete_Kfeat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Kfeat.UseVisualStyleBackColor = false;
			cmd_Delete_Kfeat.Click += new System.EventHandler(cmd_Delete_Kfeat_Click);
			// 
			// cmd_Cancel_Kfeat
			// 
			cmd_Cancel_Kfeat.AllowDrop = true;
			cmd_Cancel_Kfeat.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Kfeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Kfeat.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Kfeat.Location = new System.Drawing.Point(122, 4);
			cmd_Cancel_Kfeat.Name = "cmd_Cancel_Kfeat";
			cmd_Cancel_Kfeat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Kfeat.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_Kfeat.TabIndex = 11;
			cmd_Cancel_Kfeat.Text = "&Cancel";
			cmd_Cancel_Kfeat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Kfeat.UseVisualStyleBackColor = false;
			cmd_Cancel_Kfeat.Click += new System.EventHandler(cmd_Cancel_Kfeat_Click);
			// 
			// cmd_Save_Kfeat
			// 
			cmd_Save_Kfeat.AllowDrop = true;
			cmd_Save_Kfeat.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Kfeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Kfeat.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Kfeat.Location = new System.Drawing.Point(54, 4);
			cmd_Save_Kfeat.Name = "cmd_Save_Kfeat";
			cmd_Save_Kfeat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Kfeat.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Kfeat.TabIndex = 10;
			cmd_Save_Kfeat.Text = "&Save";
			cmd_Save_Kfeat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Kfeat.UseVisualStyleBackColor = false;
			cmd_Save_Kfeat.Click += new System.EventHandler(cmd_Save_Kfeat_Click);
			// 
			// txt_kfeat_code
			// 
			txt_kfeat_code.AcceptsReturn = true;
			txt_kfeat_code.AllowDrop = true;
			txt_kfeat_code.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_kfeat_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_kfeat_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_kfeat_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_kfeat_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_kfeat_code.Location = new System.Drawing.Point(8, 22);
			txt_kfeat_code.MaxLength = 3;
			txt_kfeat_code.Name = "txt_kfeat_code";
			txt_kfeat_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_kfeat_code.Size = new System.Drawing.Size(39, 21);
			txt_kfeat_code.TabIndex = 9;
			txt_kfeat_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_kfeat_code_KeyPress);
			// 
			// _Label24_44
			// 
			_Label24_44.AllowDrop = true;
			_Label24_44.BackColor = System.Drawing.SystemColors.Control;
			_Label24_44.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_44.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_44.Location = new System.Drawing.Point(8, 250);
			_Label24_44.MinimumSize = new System.Drawing.Size(61, 15);
			_Label24_44.Name = "_Label24_44";
			_Label24_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_44.Size = new System.Drawing.Size(61, 15);
			_Label24_44.TabIndex = 402;
			_Label24_44.Text = "Area";
			// 
			// _Label24_19
			// 
			_Label24_19.AllowDrop = true;
			_Label24_19.BackColor = System.Drawing.SystemColors.Control;
			_Label24_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_19.Location = new System.Drawing.Point(8, 342);
			_Label24_19.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_19.Name = "_Label24_19";
			_Label24_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_19.Size = new System.Drawing.Size(75, 17);
			_Label24_19.TabIndex = 308;
			_Label24_19.Text = "Where to Enter";
			// 
			// _Label24_18
			// 
			_Label24_18.AllowDrop = true;
			_Label24_18.BackColor = System.Drawing.SystemColors.Control;
			_Label24_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_18.Location = new System.Drawing.Point(8, 292);
			_Label24_18.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_18.Name = "_Label24_18";
			_Label24_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_18.Size = new System.Drawing.Size(75, 17);
			_Label24_18.TabIndex = 307;
			_Label24_18.Text = "How to Format";
			// 
			// _Label24_17
			// 
			_Label24_17.AllowDrop = true;
			_Label24_17.BackColor = System.Drawing.SystemColors.Control;
			_Label24_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_17.Location = new System.Drawing.Point(8, 168);
			_Label24_17.MinimumSize = new System.Drawing.Size(101, 17);
			_Label24_17.Name = "_Label24_17";
			_Label24_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_17.Size = new System.Drawing.Size(101, 17);
			_Label24_17.TabIndex = 306;
			_Label24_17.Text = "Research Notes";
			// 
			// _Label24_16
			// 
			_Label24_16.AllowDrop = true;
			_Label24_16.BackColor = System.Drawing.SystemColors.Control;
			_Label24_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_16.Location = new System.Drawing.Point(8, 90);
			_Label24_16.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_16.Name = "_Label24_16";
			_Label24_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_16.Size = new System.Drawing.Size(75, 17);
			_Label24_16.TabIndex = 305;
			_Label24_16.Text = "Description";
			// 
			// _Label24_15
			// 
			_Label24_15.AllowDrop = true;
			_Label24_15.BackColor = System.Drawing.SystemColors.Control;
			_Label24_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_15.Location = new System.Drawing.Point(8, 46);
			_Label24_15.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_15.Name = "_Label24_15";
			_Label24_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_15.Size = new System.Drawing.Size(75, 17);
			_Label24_15.TabIndex = 304;
			_Label24_15.Text = "Name";
			// 
			// _lbl_kfeat_code_0
			// 
			_lbl_kfeat_code_0.AllowDrop = true;
			_lbl_kfeat_code_0.AutoSize = true;
			_lbl_kfeat_code_0.BackColor = System.Drawing.Color.Transparent;
			_lbl_kfeat_code_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_kfeat_code_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_kfeat_code_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_kfeat_code_0.Location = new System.Drawing.Point(8, 6);
			_lbl_kfeat_code_0.MinimumSize = new System.Drawing.Size(25, 13);
			_lbl_kfeat_code_0.Name = "_lbl_kfeat_code_0";
			_lbl_kfeat_code_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_kfeat_code_0.Size = new System.Drawing.Size(25, 13);
			_lbl_kfeat_code_0.TabIndex = 21;
			_lbl_kfeat_code_0.Text = "Code";
			// 
			// cmd_Add_Kfeat
			// 
			cmd_Add_Kfeat.AllowDrop = true;
			cmd_Add_Kfeat.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Kfeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Kfeat.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Kfeat.Location = new System.Drawing.Point(512, 16);
			cmd_Add_Kfeat.Name = "cmd_Add_Kfeat";
			cmd_Add_Kfeat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Kfeat.Size = new System.Drawing.Size(57, 25);
			cmd_Add_Kfeat.TabIndex = 1;
			cmd_Add_Kfeat.Text = "&Add";
			cmd_Add_Kfeat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Kfeat.UseVisualStyleBackColor = false;
			cmd_Add_Kfeat.Click += new System.EventHandler(cmd_Add_Kfeat_Click);
			// 
			// FG_KeyFeature
			// 
			FG_KeyFeature.AllowDrop = true;
			FG_KeyFeature.AllowUserToAddRows = false;
			FG_KeyFeature.AllowUserToDeleteRows = false;
			FG_KeyFeature.AllowUserToResizeColumns = false;
			FG_KeyFeature.AllowUserToResizeColumns = FG_KeyFeature.ColumnHeadersVisible;
			FG_KeyFeature.AllowUserToResizeRows = false;
			FG_KeyFeature.AllowUserToResizeRows = false;
			FG_KeyFeature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_KeyFeature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_KeyFeature.ColumnsCount = 2;
			FG_KeyFeature.FixedColumns = 0;
			FG_KeyFeature.FixedRows = 1;
			FG_KeyFeature.Location = new System.Drawing.Point(18, 41);
			FG_KeyFeature.Name = "FG_KeyFeature";
			FG_KeyFeature.ReadOnly = true;
			FG_KeyFeature.RowsCount = 2;
			FG_KeyFeature.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_KeyFeature.ShowCellToolTips = false;
			FG_KeyFeature.Size = new System.Drawing.Size(460, 400);
			FG_KeyFeature.StandardTab = true;
			FG_KeyFeature.TabIndex = 168;
			FG_KeyFeature.Click += new System.EventHandler(FG_KeyFeature_Click);
			// 
			// frame_automodels
			// 
			frame_automodels.AllowDrop = true;
			frame_automodels.BackColor = System.Drawing.SystemColors.Control;
			frame_automodels.Controls.Add(cmd_CloseAutoModel);
			frame_automodels.Controls.Add(grd_AutoMod);
			frame_automodels.Controls.Add(lbl_modeltext);
			frame_automodels.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_automodels.Enabled = true;
			frame_automodels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_automodels.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_automodels.Location = new System.Drawing.Point(10, 20);
			frame_automodels.Name = "frame_automodels";
			frame_automodels.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_automodels.Size = new System.Drawing.Size(425, 393);
			frame_automodels.TabIndex = 197;
			frame_automodels.Text = "Automated Aircraft Models";
			frame_automodels.Visible = false;
			// 
			// cmd_CloseAutoModel
			// 
			cmd_CloseAutoModel.AllowDrop = true;
			cmd_CloseAutoModel.BackColor = System.Drawing.SystemColors.Control;
			cmd_CloseAutoModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_CloseAutoModel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_CloseAutoModel.Location = new System.Drawing.Point(344, 360);
			cmd_CloseAutoModel.Name = "cmd_CloseAutoModel";
			cmd_CloseAutoModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_CloseAutoModel.Size = new System.Drawing.Size(73, 25);
			cmd_CloseAutoModel.TabIndex = 198;
			cmd_CloseAutoModel.Text = "Close";
			cmd_CloseAutoModel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_CloseAutoModel.UseVisualStyleBackColor = false;
			cmd_CloseAutoModel.Click += new System.EventHandler(cmd_CloseAutoModel_Click);
			// 
			// grd_AutoMod
			// 
			grd_AutoMod.AllowDrop = true;
			grd_AutoMod.AllowUserToAddRows = false;
			grd_AutoMod.AllowUserToDeleteRows = false;
			grd_AutoMod.AllowUserToResizeColumns = false;
			grd_AutoMod.AllowUserToResizeRows = false;
			grd_AutoMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_AutoMod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_AutoMod.ColumnsCount = 2;
			grd_AutoMod.FixedColumns = 1;
			grd_AutoMod.FixedRows = 1;
			grd_AutoMod.Location = new System.Drawing.Point(8, 32);
			grd_AutoMod.Name = "grd_AutoMod";
			grd_AutoMod.ReadOnly = true;
			grd_AutoMod.RowsCount = 2;
			grd_AutoMod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_AutoMod.ShowCellToolTips = false;
			grd_AutoMod.Size = new System.Drawing.Size(409, 289);
			grd_AutoMod.StandardTab = true;
			grd_AutoMod.TabIndex = 199;
			// 
			// lbl_modeltext
			// 
			lbl_modeltext.AllowDrop = true;
			lbl_modeltext.BackColor = System.Drawing.SystemColors.Control;
			lbl_modeltext.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_modeltext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_modeltext.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_modeltext.Location = new System.Drawing.Point(7, 12);
			lbl_modeltext.MinimumSize = new System.Drawing.Size(361, 49);
			lbl_modeltext.Name = "lbl_modeltext";
			lbl_modeltext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_modeltext.Size = new System.Drawing.Size(361, 49);
			lbl_modeltext.TabIndex = 200;
			// 
			// chk_show_inactive
			// 
			chk_show_inactive.AllowDrop = true;
			chk_show_inactive.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_show_inactive.BackColor = System.Drawing.SystemColors.Control;
			chk_show_inactive.CausesValidation = true;
			chk_show_inactive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_show_inactive.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_show_inactive.Enabled = true;
			chk_show_inactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_show_inactive.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_show_inactive.Location = new System.Drawing.Point(12, 6);
			chk_show_inactive.Name = "chk_show_inactive";
			chk_show_inactive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_show_inactive.Size = new System.Drawing.Size(143, 15);
			chk_show_inactive.TabIndex = 350;
			chk_show_inactive.TabStop = true;
			chk_show_inactive.Text = "Display Inactive Features";
			chk_show_inactive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_show_inactive.Visible = true;
			chk_show_inactive.CheckStateChanged += new System.EventHandler(chk_show_inactive_CheckStateChanged);
			// 
			// _tab_Lookup_TabPage1
			// 
			_tab_Lookup_TabPage1.Controls.Add(FG_Aircraft_Status);
			_tab_Lookup_TabPage1.Controls.Add(cmd_Add_Aircraft_Status);
			_tab_Lookup_TabPage1.Controls.Add(pnl_Update_Aircraft_Status);
			_tab_Lookup_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage1.Text = "Aircraft Status";
			// 
			// FG_Aircraft_Status
			// 
			FG_Aircraft_Status.AllowDrop = true;
			FG_Aircraft_Status.AllowUserToAddRows = false;
			FG_Aircraft_Status.AllowUserToDeleteRows = false;
			FG_Aircraft_Status.AllowUserToResizeColumns = false;
			FG_Aircraft_Status.AllowUserToResizeColumns = FG_Aircraft_Status.ColumnHeadersVisible;
			FG_Aircraft_Status.AllowUserToResizeRows = false;
			FG_Aircraft_Status.AllowUserToResizeRows = false;
			FG_Aircraft_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_Aircraft_Status.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Aircraft_Status.ColumnsCount = 2;
			FG_Aircraft_Status.FixedColumns = 0;
			FG_Aircraft_Status.FixedRows = 1;
			FG_Aircraft_Status.Location = new System.Drawing.Point(18, 17);
			FG_Aircraft_Status.Name = "FG_Aircraft_Status";
			FG_Aircraft_Status.ReadOnly = true;
			FG_Aircraft_Status.RowsCount = 2;
			FG_Aircraft_Status.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Aircraft_Status.ShowCellToolTips = false;
			FG_Aircraft_Status.Size = new System.Drawing.Size(331, 429);
			FG_Aircraft_Status.StandardTab = true;
			FG_Aircraft_Status.TabIndex = 170;
			FG_Aircraft_Status.Click += new System.EventHandler(FG_Aircraft_Status_Click);
			// 
			// cmd_Add_Aircraft_Status
			// 
			cmd_Add_Aircraft_Status.AllowDrop = true;
			cmd_Add_Aircraft_Status.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Aircraft_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Aircraft_Status.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Aircraft_Status.Location = new System.Drawing.Point(402, 10);
			cmd_Add_Aircraft_Status.Name = "cmd_Add_Aircraft_Status";
			cmd_Add_Aircraft_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Aircraft_Status.Size = new System.Drawing.Size(57, 25);
			cmd_Add_Aircraft_Status.TabIndex = 169;
			cmd_Add_Aircraft_Status.Text = "&Add";
			cmd_Add_Aircraft_Status.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Aircraft_Status.UseVisualStyleBackColor = false;
			cmd_Add_Aircraft_Status.Click += new System.EventHandler(cmd_Add_aircraft_status_Click);
			// 
			// pnl_Update_Aircraft_Status
			// 
			pnl_Update_Aircraft_Status.AllowDrop = true;
			pnl_Update_Aircraft_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Update_Aircraft_Status.Controls.Add(txt_astat_description);
			pnl_Update_Aircraft_Status.Controls.Add(txt_astat_name);
			pnl_Update_Aircraft_Status.Controls.Add(cmd_Delete_Aircraft_Status);
			pnl_Update_Aircraft_Status.Controls.Add(cmd_Cancel_Aircraft_Status);
			pnl_Update_Aircraft_Status.Controls.Add(cmd_Save_Aircraft_Status);
			pnl_Update_Aircraft_Status.Controls.Add(_Label24_21);
			pnl_Update_Aircraft_Status.Controls.Add(_Label24_20);
			pnl_Update_Aircraft_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Update_Aircraft_Status.Location = new System.Drawing.Point(402, 44);
			pnl_Update_Aircraft_Status.Name = "pnl_Update_Aircraft_Status";
			pnl_Update_Aircraft_Status.Size = new System.Drawing.Size(345, 306);
			pnl_Update_Aircraft_Status.TabIndex = 3;
			pnl_Update_Aircraft_Status.Visible = false;
			// 
			// txt_astat_description
			// 
			txt_astat_description.AcceptsReturn = true;
			txt_astat_description.AllowDrop = true;
			txt_astat_description.BackColor = System.Drawing.SystemColors.Window;
			txt_astat_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_astat_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_astat_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_astat_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_astat_description.Location = new System.Drawing.Point(16, 137);
			txt_astat_description.MaxLength = 200;
			txt_astat_description.Multiline = true;
			txt_astat_description.Name = "txt_astat_description";
			txt_astat_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_astat_description.Size = new System.Drawing.Size(281, 121);
			txt_astat_description.TabIndex = 22;
			// 
			// txt_astat_name
			// 
			txt_astat_name.AcceptsReturn = true;
			txt_astat_name.AllowDrop = true;
			txt_astat_name.BackColor = System.Drawing.SystemColors.Window;
			txt_astat_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_astat_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_astat_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_astat_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_astat_name.Location = new System.Drawing.Point(15, 78);
			txt_astat_name.MaxLength = 15;
			txt_astat_name.Name = "txt_astat_name";
			txt_astat_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_astat_name.Size = new System.Drawing.Size(257, 19);
			txt_astat_name.TabIndex = 7;
			// 
			// cmd_Delete_Aircraft_Status
			// 
			cmd_Delete_Aircraft_Status.AllowDrop = true;
			cmd_Delete_Aircraft_Status.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Aircraft_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Aircraft_Status.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Aircraft_Status.Location = new System.Drawing.Point(175, 10);
			cmd_Delete_Aircraft_Status.Name = "cmd_Delete_Aircraft_Status";
			cmd_Delete_Aircraft_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Aircraft_Status.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Aircraft_Status.TabIndex = 6;
			cmd_Delete_Aircraft_Status.Text = "&Delete";
			cmd_Delete_Aircraft_Status.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Aircraft_Status.UseVisualStyleBackColor = false;
			cmd_Delete_Aircraft_Status.Click += new System.EventHandler(cmd_Delete_Aircraft_Status_Click);
			// 
			// cmd_Cancel_Aircraft_Status
			// 
			cmd_Cancel_Aircraft_Status.AllowDrop = true;
			cmd_Cancel_Aircraft_Status.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Aircraft_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Aircraft_Status.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Aircraft_Status.Location = new System.Drawing.Point(92, 9);
			cmd_Cancel_Aircraft_Status.Name = "cmd_Cancel_Aircraft_Status";
			cmd_Cancel_Aircraft_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Aircraft_Status.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_Aircraft_Status.TabIndex = 5;
			cmd_Cancel_Aircraft_Status.Text = "&Cancel";
			cmd_Cancel_Aircraft_Status.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Aircraft_Status.UseVisualStyleBackColor = false;
			cmd_Cancel_Aircraft_Status.Click += new System.EventHandler(cmd_Cancel_aircraft_status_Click);
			// 
			// cmd_Save_Aircraft_Status
			// 
			cmd_Save_Aircraft_Status.AllowDrop = true;
			cmd_Save_Aircraft_Status.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Aircraft_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Aircraft_Status.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Aircraft_Status.Location = new System.Drawing.Point(12, 10);
			cmd_Save_Aircraft_Status.Name = "cmd_Save_Aircraft_Status";
			cmd_Save_Aircraft_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Aircraft_Status.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Aircraft_Status.TabIndex = 4;
			cmd_Save_Aircraft_Status.Text = "&Save";
			cmd_Save_Aircraft_Status.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Aircraft_Status.UseVisualStyleBackColor = false;
			cmd_Save_Aircraft_Status.Click += new System.EventHandler(cmd_Save_aircraft_status_Click);
			// 
			// _Label24_21
			// 
			_Label24_21.AllowDrop = true;
			_Label24_21.BackColor = System.Drawing.SystemColors.Control;
			_Label24_21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_21.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_21.Location = new System.Drawing.Point(14, 112);
			_Label24_21.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_21.Name = "_Label24_21";
			_Label24_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_21.Size = new System.Drawing.Size(75, 17);
			_Label24_21.TabIndex = 310;
			_Label24_21.Text = "Description";
			// 
			// _Label24_20
			// 
			_Label24_20.AllowDrop = true;
			_Label24_20.BackColor = System.Drawing.SystemColors.Control;
			_Label24_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_20.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_20.Location = new System.Drawing.Point(16, 52);
			_Label24_20.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_20.Name = "_Label24_20";
			_Label24_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_20.Size = new System.Drawing.Size(75, 17);
			_Label24_20.TabIndex = 309;
			_Label24_20.Text = "Name";
			// 
			// _tab_Lookup_TabPage2
			// 
			_tab_Lookup_TabPage2.Controls.Add(FG_AirCraft_Asking);
			_tab_Lookup_TabPage2.Controls.Add(cmd_Add_Asking);
			_tab_Lookup_TabPage2.Controls.Add(pnl_NameDesc_Asking);
			_tab_Lookup_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage2.Text = "Aircraft Asking";
			// 
			// FG_AirCraft_Asking
			// 
			FG_AirCraft_Asking.AllowDrop = true;
			FG_AirCraft_Asking.AllowUserToAddRows = false;
			FG_AirCraft_Asking.AllowUserToDeleteRows = false;
			FG_AirCraft_Asking.AllowUserToResizeColumns = false;
			FG_AirCraft_Asking.AllowUserToResizeColumns = FG_AirCraft_Asking.ColumnHeadersVisible;
			FG_AirCraft_Asking.AllowUserToResizeRows = false;
			FG_AirCraft_Asking.AllowUserToResizeRows = false;
			FG_AirCraft_Asking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_AirCraft_Asking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_AirCraft_Asking.ColumnsCount = 2;
			FG_AirCraft_Asking.FixedColumns = 0;
			FG_AirCraft_Asking.FixedRows = 1;
			FG_AirCraft_Asking.Location = new System.Drawing.Point(22, 19);
			FG_AirCraft_Asking.Name = "FG_AirCraft_Asking";
			FG_AirCraft_Asking.ReadOnly = true;
			FG_AirCraft_Asking.RowsCount = 2;
			FG_AirCraft_Asking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_AirCraft_Asking.ShowCellToolTips = false;
			FG_AirCraft_Asking.Size = new System.Drawing.Size(258, 412);
			FG_AirCraft_Asking.StandardTab = true;
			FG_AirCraft_Asking.TabIndex = 172;
			FG_AirCraft_Asking.Click += new System.EventHandler(FG_AirCraft_Asking_Click);
			// 
			// cmd_Add_Asking
			// 
			cmd_Add_Asking.AllowDrop = true;
			cmd_Add_Asking.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Asking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Asking.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Asking.Location = new System.Drawing.Point(309, 15);
			cmd_Add_Asking.Name = "cmd_Add_Asking";
			cmd_Add_Asking.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Asking.Size = new System.Drawing.Size(57, 25);
			cmd_Add_Asking.TabIndex = 171;
			cmd_Add_Asking.Text = "&Add";
			cmd_Add_Asking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Asking.UseVisualStyleBackColor = false;
			cmd_Add_Asking.Click += new System.EventHandler(cmd_Add_Asking_Click);
			// 
			// pnl_NameDesc_Asking
			// 
			pnl_NameDesc_Asking.AllowDrop = true;
			pnl_NameDesc_Asking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_NameDesc_Asking.Controls.Add(cmd_Save_Asking);
			pnl_NameDesc_Asking.Controls.Add(cmd_Cancel_Asking);
			pnl_NameDesc_Asking.Controls.Add(cmd_Delete_Asking);
			pnl_NameDesc_Asking.Controls.Add(txt_aask_name);
			pnl_NameDesc_Asking.Controls.Add(txt_aask_description);
			pnl_NameDesc_Asking.Controls.Add(_Label24_23);
			pnl_NameDesc_Asking.Controls.Add(_Label24_22);
			pnl_NameDesc_Asking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_NameDesc_Asking.Location = new System.Drawing.Point(307, 43);
			pnl_NameDesc_Asking.Name = "pnl_NameDesc_Asking";
			pnl_NameDesc_Asking.Size = new System.Drawing.Size(345, 291);
			pnl_NameDesc_Asking.TabIndex = 23;
			pnl_NameDesc_Asking.Visible = false;
			// 
			// cmd_Save_Asking
			// 
			cmd_Save_Asking.AllowDrop = true;
			cmd_Save_Asking.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Asking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Asking.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Asking.Location = new System.Drawing.Point(8, 11);
			cmd_Save_Asking.Name = "cmd_Save_Asking";
			cmd_Save_Asking.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Asking.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Asking.TabIndex = 24;
			cmd_Save_Asking.Text = "&Save";
			cmd_Save_Asking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Asking.UseVisualStyleBackColor = false;
			cmd_Save_Asking.Click += new System.EventHandler(cmd_Save_Asking_Click);
			// 
			// cmd_Cancel_Asking
			// 
			cmd_Cancel_Asking.AllowDrop = true;
			cmd_Cancel_Asking.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Asking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Asking.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Asking.Location = new System.Drawing.Point(103, 11);
			cmd_Cancel_Asking.Name = "cmd_Cancel_Asking";
			cmd_Cancel_Asking.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Asking.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_Asking.TabIndex = 25;
			cmd_Cancel_Asking.Text = "&Cancel";
			cmd_Cancel_Asking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Asking.UseVisualStyleBackColor = false;
			cmd_Cancel_Asking.Click += new System.EventHandler(cmd_Cancel_Asking_Click);
			// 
			// cmd_Delete_Asking
			// 
			cmd_Delete_Asking.AllowDrop = true;
			cmd_Delete_Asking.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Asking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Asking.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Asking.Location = new System.Drawing.Point(197, 11);
			cmd_Delete_Asking.Name = "cmd_Delete_Asking";
			cmd_Delete_Asking.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Asking.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Asking.TabIndex = 26;
			cmd_Delete_Asking.Text = "&Delete";
			cmd_Delete_Asking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Asking.UseVisualStyleBackColor = false;
			cmd_Delete_Asking.Click += new System.EventHandler(cmd_Delete_Asking_Click);
			// 
			// txt_aask_name
			// 
			txt_aask_name.AcceptsReturn = true;
			txt_aask_name.AllowDrop = true;
			txt_aask_name.BackColor = System.Drawing.SystemColors.Window;
			txt_aask_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_aask_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_aask_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_aask_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_aask_name.Location = new System.Drawing.Point(13, 73);
			txt_aask_name.MaxLength = 10;
			txt_aask_name.Name = "txt_aask_name";
			txt_aask_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_aask_name.Size = new System.Drawing.Size(257, 19);
			txt_aask_name.TabIndex = 27;
			txt_aask_name.Leave += new System.EventHandler(txt_aask_name_Leave);
			// 
			// txt_aask_description
			// 
			txt_aask_description.AcceptsReturn = true;
			txt_aask_description.AllowDrop = true;
			txt_aask_description.BackColor = System.Drawing.SystemColors.Window;
			txt_aask_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_aask_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_aask_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_aask_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_aask_description.Location = new System.Drawing.Point(13, 116);
			txt_aask_description.MaxLength = 250;
			txt_aask_description.Multiline = true;
			txt_aask_description.Name = "txt_aask_description";
			txt_aask_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_aask_description.Size = new System.Drawing.Size(281, 121);
			txt_aask_description.TabIndex = 28;
			txt_aask_description.Leave += new System.EventHandler(txt_aask_description_Leave);
			// 
			// _Label24_23
			// 
			_Label24_23.AllowDrop = true;
			_Label24_23.BackColor = System.Drawing.SystemColors.Control;
			_Label24_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_23.Location = new System.Drawing.Point(14, 96);
			_Label24_23.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_23.Name = "_Label24_23";
			_Label24_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_23.Size = new System.Drawing.Size(75, 17);
			_Label24_23.TabIndex = 312;
			_Label24_23.Text = "Description";
			// 
			// _Label24_22
			// 
			_Label24_22.AllowDrop = true;
			_Label24_22.BackColor = System.Drawing.SystemColors.Control;
			_Label24_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_22.Location = new System.Drawing.Point(12, 54);
			_Label24_22.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_22.Name = "_Label24_22";
			_Label24_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_22.Size = new System.Drawing.Size(75, 17);
			_Label24_22.TabIndex = 311;
			_Label24_22.Text = "Name";
			// 
			// _tab_Lookup_TabPage3
			// 
			_tab_Lookup_TabPage3.Controls.Add(pnl_avionics_Update_Change);
			_tab_Lookup_TabPage3.Controls.Add(cmd_Add_Avionics);
			_tab_Lookup_TabPage3.Controls.Add(FG_Avionics);
			_tab_Lookup_TabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage3.Text = "Avionics";
			// 
			// pnl_avionics_Update_Change
			// 
			pnl_avionics_Update_Change.AllowDrop = true;
			pnl_avionics_Update_Change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_avionics_Update_Change.Controls.Add(txt_avion_notes);
			pnl_avionics_Update_Change.Controls.Add(txt_avion_name);
			pnl_avionics_Update_Change.Controls.Add(cmd_Delete_Avionics);
			pnl_avionics_Update_Change.Controls.Add(cmd_Cancel_Avionics);
			pnl_avionics_Update_Change.Controls.Add(cmd_Save_Avionics);
			pnl_avionics_Update_Change.Controls.Add(_Label24_25);
			pnl_avionics_Update_Change.Controls.Add(_Label24_24);
			pnl_avionics_Update_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_avionics_Update_Change.Location = new System.Drawing.Point(404, 60);
			pnl_avionics_Update_Change.Name = "pnl_avionics_Update_Change";
			pnl_avionics_Update_Change.Size = new System.Drawing.Size(345, 293);
			pnl_avionics_Update_Change.TabIndex = 29;
			pnl_avionics_Update_Change.Visible = false;
			// 
			// txt_avion_notes
			// 
			txt_avion_notes.AcceptsReturn = true;
			txt_avion_notes.AllowDrop = true;
			txt_avion_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_avion_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_avion_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_avion_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_avion_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_avion_notes.Location = new System.Drawing.Point(10, 133);
			txt_avion_notes.MaxLength = 75;
			txt_avion_notes.Multiline = true;
			txt_avion_notes.Name = "txt_avion_notes";
			txt_avion_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_avion_notes.Size = new System.Drawing.Size(281, 121);
			txt_avion_notes.TabIndex = 34;
			// 
			// txt_avion_name
			// 
			txt_avion_name.AcceptsReturn = true;
			txt_avion_name.AllowDrop = true;
			txt_avion_name.BackColor = System.Drawing.SystemColors.Window;
			txt_avion_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_avion_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_avion_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_avion_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_avion_name.Location = new System.Drawing.Point(12, 72);
			txt_avion_name.MaxLength = 45;
			txt_avion_name.Name = "txt_avion_name";
			txt_avion_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_avion_name.Size = new System.Drawing.Size(257, 19);
			txt_avion_name.TabIndex = 33;
			// 
			// cmd_Delete_Avionics
			// 
			cmd_Delete_Avionics.AllowDrop = true;
			cmd_Delete_Avionics.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Avionics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Avionics.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Avionics.Location = new System.Drawing.Point(181, 12);
			cmd_Delete_Avionics.Name = "cmd_Delete_Avionics";
			cmd_Delete_Avionics.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Avionics.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Avionics.TabIndex = 32;
			cmd_Delete_Avionics.Text = "&Delete";
			cmd_Delete_Avionics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Avionics.UseVisualStyleBackColor = false;
			cmd_Delete_Avionics.Click += new System.EventHandler(cmd_Delete_Avionics_Click);
			// 
			// cmd_Cancel_Avionics
			// 
			cmd_Cancel_Avionics.AllowDrop = true;
			cmd_Cancel_Avionics.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Avionics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Avionics.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Avionics.Location = new System.Drawing.Point(95, 12);
			cmd_Cancel_Avionics.Name = "cmd_Cancel_Avionics";
			cmd_Cancel_Avionics.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Avionics.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_Avionics.TabIndex = 31;
			cmd_Cancel_Avionics.Text = "&Cancel";
			cmd_Cancel_Avionics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Avionics.UseVisualStyleBackColor = false;
			cmd_Cancel_Avionics.Click += new System.EventHandler(cmd_Cancel_Avionics_Click);
			// 
			// cmd_Save_Avionics
			// 
			cmd_Save_Avionics.AllowDrop = true;
			cmd_Save_Avionics.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Avionics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Avionics.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Avionics.Location = new System.Drawing.Point(12, 11);
			cmd_Save_Avionics.Name = "cmd_Save_Avionics";
			cmd_Save_Avionics.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Avionics.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Avionics.TabIndex = 30;
			cmd_Save_Avionics.Text = "&Save";
			cmd_Save_Avionics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Avionics.UseVisualStyleBackColor = false;
			cmd_Save_Avionics.Click += new System.EventHandler(cmd_Save_Avionics_Click);
			// 
			// _Label24_25
			// 
			_Label24_25.AllowDrop = true;
			_Label24_25.BackColor = System.Drawing.SystemColors.Control;
			_Label24_25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_25.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_25.Location = new System.Drawing.Point(16, 108);
			_Label24_25.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_25.Name = "_Label24_25";
			_Label24_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_25.Size = new System.Drawing.Size(75, 17);
			_Label24_25.TabIndex = 314;
			_Label24_25.Text = "Notes";
			// 
			// _Label24_24
			// 
			_Label24_24.AllowDrop = true;
			_Label24_24.BackColor = System.Drawing.SystemColors.Control;
			_Label24_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_24.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_24.Location = new System.Drawing.Point(16, 52);
			_Label24_24.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_24.Name = "_Label24_24";
			_Label24_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_24.Size = new System.Drawing.Size(75, 17);
			_Label24_24.TabIndex = 313;
			_Label24_24.Text = "Name";
			// 
			// cmd_Add_Avionics
			// 
			cmd_Add_Avionics.AllowDrop = true;
			cmd_Add_Avionics.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Avionics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Avionics.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Avionics.Location = new System.Drawing.Point(411, 23);
			cmd_Add_Avionics.Name = "cmd_Add_Avionics";
			cmd_Add_Avionics.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Avionics.Size = new System.Drawing.Size(57, 25);
			cmd_Add_Avionics.TabIndex = 173;
			cmd_Add_Avionics.Text = "&Add";
			cmd_Add_Avionics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Avionics.UseVisualStyleBackColor = false;
			cmd_Add_Avionics.Click += new System.EventHandler(cmd_Add_avionics_Click);
			// 
			// FG_Avionics
			// 
			FG_Avionics.AllowDrop = true;
			FG_Avionics.AllowUserToAddRows = false;
			FG_Avionics.AllowUserToDeleteRows = false;
			FG_Avionics.AllowUserToResizeColumns = false;
			FG_Avionics.AllowUserToResizeRows = false;
			FG_Avionics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_Avionics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Avionics.ColumnsCount = 2;
			FG_Avionics.FixedColumns = 0;
			FG_Avionics.FixedRows = 1;
			FG_Avionics.Location = new System.Drawing.Point(19, 27);
			FG_Avionics.Name = "FG_Avionics";
			FG_Avionics.ReadOnly = true;
			FG_Avionics.RowsCount = 2;
			FG_Avionics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			FG_Avionics.ShowCellToolTips = false;
			FG_Avionics.Size = new System.Drawing.Size(363, 418);
			FG_Avionics.StandardTab = true;
			FG_Avionics.TabIndex = 174;
			FG_Avionics.Click += new System.EventHandler(FG_Avionics_Click);
			// 
			// _tab_Lookup_TabPage4
			// 
			_tab_Lookup_TabPage4.Controls.Add(FG_Aircraft_Class);
			_tab_Lookup_TabPage4.Controls.Add(cmd_Add_Aircraft_Class);
			_tab_Lookup_TabPage4.Controls.Add(pnl_Aircraft_Class_AddUpdate);
			_tab_Lookup_TabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage4.Text = "Aircraft Class";
			// 
			// FG_Aircraft_Class
			// 
			FG_Aircraft_Class.AllowDrop = true;
			FG_Aircraft_Class.AllowUserToAddRows = false;
			FG_Aircraft_Class.AllowUserToDeleteRows = false;
			FG_Aircraft_Class.AllowUserToResizeColumns = false;
			FG_Aircraft_Class.AllowUserToResizeColumns = FG_Aircraft_Class.ColumnHeadersVisible;
			FG_Aircraft_Class.AllowUserToResizeRows = false;
			FG_Aircraft_Class.AllowUserToResizeRows = false;
			FG_Aircraft_Class.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_Aircraft_Class.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Aircraft_Class.ColumnsCount = 2;
			FG_Aircraft_Class.FixedColumns = 0;
			FG_Aircraft_Class.FixedRows = 1;
			FG_Aircraft_Class.Location = new System.Drawing.Point(23, 44);
			FG_Aircraft_Class.Name = "FG_Aircraft_Class";
			FG_Aircraft_Class.ReadOnly = true;
			FG_Aircraft_Class.RowsCount = 2;
			FG_Aircraft_Class.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Aircraft_Class.ShowCellToolTips = false;
			FG_Aircraft_Class.Size = new System.Drawing.Size(274, 241);
			FG_Aircraft_Class.StandardTab = true;
			FG_Aircraft_Class.TabIndex = 176;
			FG_Aircraft_Class.Click += new System.EventHandler(FG_Aircraft_Class_Click);
			// 
			// cmd_Add_Aircraft_Class
			// 
			cmd_Add_Aircraft_Class.AllowDrop = true;
			cmd_Add_Aircraft_Class.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Aircraft_Class.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Aircraft_Class.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Aircraft_Class.Location = new System.Drawing.Point(312, 27);
			cmd_Add_Aircraft_Class.Name = "cmd_Add_Aircraft_Class";
			cmd_Add_Aircraft_Class.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Aircraft_Class.Size = new System.Drawing.Size(57, 25);
			cmd_Add_Aircraft_Class.TabIndex = 175;
			cmd_Add_Aircraft_Class.Text = "&Add";
			cmd_Add_Aircraft_Class.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Aircraft_Class.UseVisualStyleBackColor = false;
			cmd_Add_Aircraft_Class.Click += new System.EventHandler(cmd_Add_Aircraft_Class_Click);
			// 
			// pnl_Aircraft_Class_AddUpdate
			// 
			pnl_Aircraft_Class_AddUpdate.AllowDrop = true;
			pnl_Aircraft_Class_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Aircraft_Class_AddUpdate.Controls.Add(cmd_Save_Aircraft_Class);
			pnl_Aircraft_Class_AddUpdate.Controls.Add(cmd_Cancel_Aircraft_Class);
			pnl_Aircraft_Class_AddUpdate.Controls.Add(cmd_Delete_Aircraft_Class);
			pnl_Aircraft_Class_AddUpdate.Controls.Add(txt_aclass_code);
			pnl_Aircraft_Class_AddUpdate.Controls.Add(txt_aclass_Name);
			pnl_Aircraft_Class_AddUpdate.Controls.Add(_Label24_27);
			pnl_Aircraft_Class_AddUpdate.Controls.Add(_Label24_26);
			pnl_Aircraft_Class_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Aircraft_Class_AddUpdate.Location = new System.Drawing.Point(314, 66);
			pnl_Aircraft_Class_AddUpdate.Name = "pnl_Aircraft_Class_AddUpdate";
			pnl_Aircraft_Class_AddUpdate.Size = new System.Drawing.Size(345, 210);
			pnl_Aircraft_Class_AddUpdate.TabIndex = 35;
			pnl_Aircraft_Class_AddUpdate.Visible = false;
			// 
			// cmd_Save_Aircraft_Class
			// 
			cmd_Save_Aircraft_Class.AllowDrop = true;
			cmd_Save_Aircraft_Class.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Aircraft_Class.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Aircraft_Class.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Aircraft_Class.Location = new System.Drawing.Point(15, 10);
			cmd_Save_Aircraft_Class.Name = "cmd_Save_Aircraft_Class";
			cmd_Save_Aircraft_Class.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Aircraft_Class.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Aircraft_Class.TabIndex = 40;
			cmd_Save_Aircraft_Class.Text = "&Save";
			cmd_Save_Aircraft_Class.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Aircraft_Class.UseVisualStyleBackColor = false;
			cmd_Save_Aircraft_Class.Click += new System.EventHandler(cmd_Save_Aircraft_Class_Click);
			// 
			// cmd_Cancel_Aircraft_Class
			// 
			cmd_Cancel_Aircraft_Class.AllowDrop = true;
			cmd_Cancel_Aircraft_Class.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Aircraft_Class.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Aircraft_Class.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Aircraft_Class.Location = new System.Drawing.Point(103, 10);
			cmd_Cancel_Aircraft_Class.Name = "cmd_Cancel_Aircraft_Class";
			cmd_Cancel_Aircraft_Class.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Aircraft_Class.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_Aircraft_Class.TabIndex = 39;
			cmd_Cancel_Aircraft_Class.Text = "&Cancel";
			cmd_Cancel_Aircraft_Class.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Aircraft_Class.UseVisualStyleBackColor = false;
			cmd_Cancel_Aircraft_Class.Click += new System.EventHandler(cmd_Cancel_Aircraft_Class_Click);
			// 
			// cmd_Delete_Aircraft_Class
			// 
			cmd_Delete_Aircraft_Class.AllowDrop = true;
			cmd_Delete_Aircraft_Class.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Aircraft_Class.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Aircraft_Class.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Aircraft_Class.Location = new System.Drawing.Point(189, 10);
			cmd_Delete_Aircraft_Class.Name = "cmd_Delete_Aircraft_Class";
			cmd_Delete_Aircraft_Class.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Aircraft_Class.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Aircraft_Class.TabIndex = 38;
			cmd_Delete_Aircraft_Class.Text = "&Delete";
			cmd_Delete_Aircraft_Class.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Aircraft_Class.UseVisualStyleBackColor = false;
			cmd_Delete_Aircraft_Class.Click += new System.EventHandler(cmd_Delete_Aircraft_Class_Click);
			// 
			// txt_aclass_code
			// 
			txt_aclass_code.AcceptsReturn = true;
			txt_aclass_code.AllowDrop = true;
			txt_aclass_code.BackColor = System.Drawing.SystemColors.Window;
			txt_aclass_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_aclass_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_aclass_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_aclass_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_aclass_code.Location = new System.Drawing.Point(15, 70);
			txt_aclass_code.MaxLength = 1;
			txt_aclass_code.Name = "txt_aclass_code";
			txt_aclass_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_aclass_code.Size = new System.Drawing.Size(17, 19);
			txt_aclass_code.TabIndex = 37;
			txt_aclass_code.Leave += new System.EventHandler(txt_aclass_code_Leave);
			// 
			// txt_aclass_Name
			// 
			txt_aclass_Name.AcceptsReturn = true;
			txt_aclass_Name.AllowDrop = true;
			txt_aclass_Name.BackColor = System.Drawing.SystemColors.Window;
			txt_aclass_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_aclass_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_aclass_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_aclass_Name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_aclass_Name.Location = new System.Drawing.Point(12, 125);
			txt_aclass_Name.MaxLength = 15;
			txt_aclass_Name.Name = "txt_aclass_Name";
			txt_aclass_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_aclass_Name.Size = new System.Drawing.Size(209, 19);
			txt_aclass_Name.TabIndex = 36;
			// 
			// _Label24_27
			// 
			_Label24_27.AllowDrop = true;
			_Label24_27.BackColor = System.Drawing.SystemColors.Control;
			_Label24_27.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_27.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_27.Location = new System.Drawing.Point(12, 104);
			_Label24_27.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_27.Name = "_Label24_27";
			_Label24_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_27.Size = new System.Drawing.Size(75, 17);
			_Label24_27.TabIndex = 316;
			_Label24_27.Text = "Name";
			// 
			// _Label24_26
			// 
			_Label24_26.AllowDrop = true;
			_Label24_26.BackColor = System.Drawing.SystemColors.Control;
			_Label24_26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_26.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_26.Location = new System.Drawing.Point(16, 50);
			_Label24_26.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_26.Name = "_Label24_26";
			_Label24_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_26.Size = new System.Drawing.Size(75, 17);
			_Label24_26.TabIndex = 315;
			_Label24_26.Text = "Code";
			// 
			// _tab_Lookup_TabPage5
			// 
			_tab_Lookup_TabPage5.Controls.Add(FG_Aircraft_Type);
			_tab_Lookup_TabPage5.Controls.Add(cmd_Add_Aircraft_type);
			_tab_Lookup_TabPage5.Controls.Add(pnl_Aircraft_Type_AddUpdate);
			_tab_Lookup_TabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage5.Text = "Aircraft Type";
			// 
			// FG_Aircraft_Type
			// 
			FG_Aircraft_Type.AllowDrop = true;
			FG_Aircraft_Type.AllowUserToAddRows = false;
			FG_Aircraft_Type.AllowUserToDeleteRows = false;
			FG_Aircraft_Type.AllowUserToResizeColumns = false;
			FG_Aircraft_Type.AllowUserToResizeColumns = FG_Aircraft_Type.ColumnHeadersVisible;
			FG_Aircraft_Type.AllowUserToResizeRows = false;
			FG_Aircraft_Type.AllowUserToResizeRows = false;
			FG_Aircraft_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_Aircraft_Type.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Aircraft_Type.ColumnsCount = 2;
			FG_Aircraft_Type.FixedColumns = 0;
			FG_Aircraft_Type.FixedRows = 1;
			FG_Aircraft_Type.Location = new System.Drawing.Point(43, 41);
			FG_Aircraft_Type.Name = "FG_Aircraft_Type";
			FG_Aircraft_Type.ReadOnly = true;
			FG_Aircraft_Type.RowsCount = 2;
			FG_Aircraft_Type.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Aircraft_Type.ShowCellToolTips = false;
			FG_Aircraft_Type.Size = new System.Drawing.Size(238, 307);
			FG_Aircraft_Type.StandardTab = true;
			FG_Aircraft_Type.TabIndex = 178;
			FG_Aircraft_Type.Click += new System.EventHandler(FG_Aircraft_Type_Click);
			// 
			// cmd_Add_Aircraft_type
			// 
			cmd_Add_Aircraft_type.AllowDrop = true;
			cmd_Add_Aircraft_type.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Aircraft_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Aircraft_type.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Aircraft_type.Location = new System.Drawing.Point(314, 39);
			cmd_Add_Aircraft_type.Name = "cmd_Add_Aircraft_type";
			cmd_Add_Aircraft_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Aircraft_type.Size = new System.Drawing.Size(57, 25);
			cmd_Add_Aircraft_type.TabIndex = 177;
			cmd_Add_Aircraft_type.Text = "&Add";
			cmd_Add_Aircraft_type.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Aircraft_type.UseVisualStyleBackColor = false;
			cmd_Add_Aircraft_type.Click += new System.EventHandler(cmd_Add_Aircraft_type_Click);
			// 
			// pnl_Aircraft_Type_AddUpdate
			// 
			pnl_Aircraft_Type_AddUpdate.AllowDrop = true;
			pnl_Aircraft_Type_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Aircraft_Type_AddUpdate.Controls.Add(txt_atype_Name);
			pnl_Aircraft_Type_AddUpdate.Controls.Add(txt_atype_code);
			pnl_Aircraft_Type_AddUpdate.Controls.Add(cmd_Delete_Aircraft_Type);
			pnl_Aircraft_Type_AddUpdate.Controls.Add(cmd_Cancel_Aircraft_Type);
			pnl_Aircraft_Type_AddUpdate.Controls.Add(cmd_Save_Aircraft_Type);
			pnl_Aircraft_Type_AddUpdate.Controls.Add(_Label24_29);
			pnl_Aircraft_Type_AddUpdate.Controls.Add(_Label24_28);
			pnl_Aircraft_Type_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Aircraft_Type_AddUpdate.Location = new System.Drawing.Point(313, 76);
			pnl_Aircraft_Type_AddUpdate.Name = "pnl_Aircraft_Type_AddUpdate";
			pnl_Aircraft_Type_AddUpdate.Size = new System.Drawing.Size(241, 174);
			pnl_Aircraft_Type_AddUpdate.TabIndex = 41;
			pnl_Aircraft_Type_AddUpdate.Visible = false;
			// 
			// txt_atype_Name
			// 
			txt_atype_Name.AcceptsReturn = true;
			txt_atype_Name.AllowDrop = true;
			txt_atype_Name.BackColor = System.Drawing.SystemColors.Window;
			txt_atype_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_atype_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_atype_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_atype_Name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_atype_Name.Location = new System.Drawing.Point(13, 125);
			txt_atype_Name.MaxLength = 15;
			txt_atype_Name.Name = "txt_atype_Name";
			txt_atype_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_atype_Name.Size = new System.Drawing.Size(209, 19);
			txt_atype_Name.TabIndex = 43;
			// 
			// txt_atype_code
			// 
			txt_atype_code.AcceptsReturn = true;
			txt_atype_code.AllowDrop = true;
			txt_atype_code.BackColor = System.Drawing.SystemColors.Window;
			txt_atype_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_atype_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_atype_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_atype_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_atype_code.Location = new System.Drawing.Point(17, 71);
			txt_atype_code.MaxLength = 1;
			txt_atype_code.Name = "txt_atype_code";
			txt_atype_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_atype_code.Size = new System.Drawing.Size(17, 19);
			txt_atype_code.TabIndex = 42;
			txt_atype_code.TabStop = false;
			txt_atype_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Txt_atype_Code_KeyPress);
			// 
			// cmd_Delete_Aircraft_Type
			// 
			cmd_Delete_Aircraft_Type.AllowDrop = true;
			cmd_Delete_Aircraft_Type.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Aircraft_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Aircraft_Type.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Aircraft_Type.Location = new System.Drawing.Point(163, 10);
			cmd_Delete_Aircraft_Type.Name = "cmd_Delete_Aircraft_Type";
			cmd_Delete_Aircraft_Type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Aircraft_Type.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Aircraft_Type.TabIndex = 46;
			cmd_Delete_Aircraft_Type.Text = "&Delete";
			cmd_Delete_Aircraft_Type.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Aircraft_Type.UseVisualStyleBackColor = false;
			cmd_Delete_Aircraft_Type.Click += new System.EventHandler(cmd_Delete_Aircraft_Type_Click);
			// 
			// cmd_Cancel_Aircraft_Type
			// 
			cmd_Cancel_Aircraft_Type.AllowDrop = true;
			cmd_Cancel_Aircraft_Type.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Aircraft_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Aircraft_Type.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Aircraft_Type.Location = new System.Drawing.Point(88, 10);
			cmd_Cancel_Aircraft_Type.Name = "cmd_Cancel_Aircraft_Type";
			cmd_Cancel_Aircraft_Type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Aircraft_Type.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_Aircraft_Type.TabIndex = 45;
			cmd_Cancel_Aircraft_Type.Text = "&Cancel";
			cmd_Cancel_Aircraft_Type.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Aircraft_Type.UseVisualStyleBackColor = false;
			cmd_Cancel_Aircraft_Type.Click += new System.EventHandler(cmd_Cancel_Aircraft_Type_Click);
			// 
			// cmd_Save_Aircraft_Type
			// 
			cmd_Save_Aircraft_Type.AllowDrop = true;
			cmd_Save_Aircraft_Type.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Aircraft_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Aircraft_Type.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Aircraft_Type.Location = new System.Drawing.Point(14, 11);
			cmd_Save_Aircraft_Type.Name = "cmd_Save_Aircraft_Type";
			cmd_Save_Aircraft_Type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Aircraft_Type.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Aircraft_Type.TabIndex = 44;
			cmd_Save_Aircraft_Type.Text = "&Save";
			cmd_Save_Aircraft_Type.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Aircraft_Type.UseVisualStyleBackColor = false;
			cmd_Save_Aircraft_Type.Click += new System.EventHandler(cmd_Save_Aircraft_Type_Click);
			// 
			// _Label24_29
			// 
			_Label24_29.AllowDrop = true;
			_Label24_29.BackColor = System.Drawing.SystemColors.Control;
			_Label24_29.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_29.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_29.Location = new System.Drawing.Point(16, 102);
			_Label24_29.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_29.Name = "_Label24_29";
			_Label24_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_29.Size = new System.Drawing.Size(75, 17);
			_Label24_29.TabIndex = 318;
			_Label24_29.Text = "Name";
			// 
			// _Label24_28
			// 
			_Label24_28.AllowDrop = true;
			_Label24_28.BackColor = System.Drawing.SystemColors.Control;
			_Label24_28.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_28.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_28.Location = new System.Drawing.Point(14, 50);
			_Label24_28.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_28.Name = "_Label24_28";
			_Label24_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_28.Size = new System.Drawing.Size(75, 17);
			_Label24_28.TabIndex = 317;
			_Label24_28.Text = "Code";
			// 
			// _tab_Lookup_TabPage6
			// 
			_tab_Lookup_TabPage6.Controls.Add(_Label24_45);
			_tab_Lookup_TabPage6.Controls.Add(_lblExportToExcel_1);
			_tab_Lookup_TabPage6.Controls.Add(pnl_EMP_AddUpdate);
			_tab_Lookup_TabPage6.Controls.Add(cmd_Add_EMP);
			_tab_Lookup_TabPage6.Controls.Add(FG_Engine_Maintenance);
			_tab_Lookup_TabPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage6.Text = "Engine Maintenance Program";
			// 
			// _Label24_45
			// 
			_Label24_45.AllowDrop = true;
			_Label24_45.BackColor = System.Drawing.SystemColors.Control;
			_Label24_45.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_45.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_45.Location = new System.Drawing.Point(702, 432);
			_Label24_45.MinimumSize = new System.Drawing.Size(189, 17);
			_Label24_45.Name = "_Label24_45";
			_Label24_45.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_45.Size = new System.Drawing.Size(189, 17);
			_Label24_45.TabIndex = 414;
			_Label24_45.Text = "Status";
			// 
			// _lblExportToExcel_1
			// 
			_lblExportToExcel_1.AllowDrop = true;
			_lblExportToExcel_1.BackColor = System.Drawing.SystemColors.Control;
			_lblExportToExcel_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblExportToExcel_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblExportToExcel_1.ForeColor = System.Drawing.Color.Blue;
			_lblExportToExcel_1.Location = new System.Drawing.Point(504, 432);
			_lblExportToExcel_1.MinimumSize = new System.Drawing.Size(101, 17);
			_lblExportToExcel_1.Name = "_lblExportToExcel_1";
			_lblExportToExcel_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblExportToExcel_1.Size = new System.Drawing.Size(101, 17);
			_lblExportToExcel_1.TabIndex = 415;
			_lblExportToExcel_1.Text = "Export to Excel";
			_lblExportToExcel_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblExportToExcel_1.Click += new System.EventHandler(lblExportToExcel_Click);
			// 
			// pnl_EMP_AddUpdate
			// 
			pnl_EMP_AddUpdate.AllowDrop = true;
			pnl_EMP_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_EMP_AddUpdate.Controls.Add(txt_Program_Name);
			pnl_EMP_AddUpdate.Controls.Add(txt_Provider_Name);
			pnl_EMP_AddUpdate.Controls.Add(txt_Emp_ID);
			pnl_EMP_AddUpdate.Controls.Add(cmd_Save_EMP);
			pnl_EMP_AddUpdate.Controls.Add(cmd_Cancel_EMP);
			pnl_EMP_AddUpdate.Controls.Add(cmd_Delete_EMP);
			pnl_EMP_AddUpdate.Controls.Add(txt_emp_code);
			pnl_EMP_AddUpdate.Controls.Add(txt_emp_name);
			pnl_EMP_AddUpdate.Controls.Add(_Label24_33);
			pnl_EMP_AddUpdate.Controls.Add(_Label24_32);
			pnl_EMP_AddUpdate.Controls.Add(_Label24_31);
			pnl_EMP_AddUpdate.Controls.Add(_Label24_30);
			pnl_EMP_AddUpdate.Controls.Add(Label1);
			pnl_EMP_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_EMP_AddUpdate.Location = new System.Drawing.Point(506, 84);
			pnl_EMP_AddUpdate.Name = "pnl_EMP_AddUpdate";
			pnl_EMP_AddUpdate.Size = new System.Drawing.Size(392, 341);
			pnl_EMP_AddUpdate.TabIndex = 47;
			pnl_EMP_AddUpdate.Visible = false;
			// 
			// txt_Program_Name
			// 
			txt_Program_Name.AcceptsReturn = true;
			txt_Program_Name.AllowDrop = true;
			txt_Program_Name.BackColor = System.Drawing.SystemColors.Window;
			txt_Program_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Program_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Program_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Program_Name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Program_Name.Location = new System.Drawing.Point(15, 225);
			txt_Program_Name.MaxLength = 0;
			txt_Program_Name.Name = "txt_Program_Name";
			txt_Program_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Program_Name.Size = new System.Drawing.Size(368, 23);
			txt_Program_Name.TabIndex = 184;
			// 
			// txt_Provider_Name
			// 
			txt_Provider_Name.AcceptsReturn = true;
			txt_Provider_Name.AllowDrop = true;
			txt_Provider_Name.BackColor = System.Drawing.SystemColors.Window;
			txt_Provider_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Provider_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Provider_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Provider_Name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Provider_Name.Location = new System.Drawing.Point(15, 173);
			txt_Provider_Name.MaxLength = 0;
			txt_Provider_Name.Name = "txt_Provider_Name";
			txt_Provider_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Provider_Name.Size = new System.Drawing.Size(368, 23);
			txt_Provider_Name.TabIndex = 183;
			// 
			// txt_Emp_ID
			// 
			txt_Emp_ID.AcceptsReturn = true;
			txt_Emp_ID.AllowDrop = true;
			txt_Emp_ID.BackColor = System.Drawing.SystemColors.Window;
			txt_Emp_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Emp_ID.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Emp_ID.Enabled = false;
			txt_Emp_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Emp_ID.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Emp_ID.Location = new System.Drawing.Point(82, 69);
			txt_Emp_ID.MaxLength = 0;
			txt_Emp_ID.Name = "txt_Emp_ID";
			txt_Emp_ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Emp_ID.Size = new System.Drawing.Size(42, 23);
			txt_Emp_ID.TabIndex = 181;
			// 
			// cmd_Save_EMP
			// 
			cmd_Save_EMP.AllowDrop = true;
			cmd_Save_EMP.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_EMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_EMP.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_EMP.Location = new System.Drawing.Point(14, 12);
			cmd_Save_EMP.Name = "cmd_Save_EMP";
			cmd_Save_EMP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_EMP.Size = new System.Drawing.Size(57, 25);
			cmd_Save_EMP.TabIndex = 52;
			cmd_Save_EMP.Text = "&Save";
			cmd_Save_EMP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_EMP.UseVisualStyleBackColor = false;
			cmd_Save_EMP.Click += new System.EventHandler(cmd_Save_EMP_Click);
			// 
			// cmd_Cancel_EMP
			// 
			cmd_Cancel_EMP.AllowDrop = true;
			cmd_Cancel_EMP.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_EMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_EMP.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_EMP.Location = new System.Drawing.Point(79, 12);
			cmd_Cancel_EMP.Name = "cmd_Cancel_EMP";
			cmd_Cancel_EMP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_EMP.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_EMP.TabIndex = 51;
			cmd_Cancel_EMP.Text = "&Cancel";
			cmd_Cancel_EMP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_EMP.UseVisualStyleBackColor = false;
			cmd_Cancel_EMP.Click += new System.EventHandler(cmd_Cancel_EMP_Click);
			// 
			// cmd_Delete_EMP
			// 
			cmd_Delete_EMP.AllowDrop = true;
			cmd_Delete_EMP.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_EMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_EMP.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_EMP.Location = new System.Drawing.Point(143, 12);
			cmd_Delete_EMP.Name = "cmd_Delete_EMP";
			cmd_Delete_EMP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_EMP.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_EMP.TabIndex = 50;
			cmd_Delete_EMP.Text = "&Delete";
			cmd_Delete_EMP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_EMP.UseVisualStyleBackColor = false;
			cmd_Delete_EMP.Click += new System.EventHandler(cmd_Delete_EMP_Click);
			// 
			// txt_emp_code
			// 
			txt_emp_code.AcceptsReturn = true;
			txt_emp_code.AllowDrop = true;
			txt_emp_code.BackColor = System.Drawing.SystemColors.Window;
			txt_emp_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_emp_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_emp_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_emp_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_emp_code.Location = new System.Drawing.Point(16, 72);
			txt_emp_code.MaxLength = 1;
			txt_emp_code.Name = "txt_emp_code";
			txt_emp_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_emp_code.Size = new System.Drawing.Size(17, 19);
			txt_emp_code.TabIndex = 49;
			txt_emp_code.TabStop = false;
			txt_emp_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Txt_emp_Code_KeyPress);
			// 
			// txt_emp_name
			// 
			txt_emp_name.AcceptsReturn = true;
			txt_emp_name.AllowDrop = true;
			txt_emp_name.BackColor = System.Drawing.SystemColors.Window;
			txt_emp_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_emp_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_emp_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_emp_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_emp_name.Location = new System.Drawing.Point(15, 119);
			txt_emp_name.MaxLength = 60;
			txt_emp_name.Name = "txt_emp_name";
			txt_emp_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_emp_name.Size = new System.Drawing.Size(368, 23);
			txt_emp_name.TabIndex = 48;
			// 
			// _Label24_33
			// 
			_Label24_33.AllowDrop = true;
			_Label24_33.BackColor = System.Drawing.SystemColors.Control;
			_Label24_33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_33.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_33.Location = new System.Drawing.Point(16, 208);
			_Label24_33.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_33.Name = "_Label24_33";
			_Label24_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_33.Size = new System.Drawing.Size(75, 17);
			_Label24_33.TabIndex = 322;
			_Label24_33.Text = "Program Name";
			// 
			// _Label24_32
			// 
			_Label24_32.AllowDrop = true;
			_Label24_32.BackColor = System.Drawing.SystemColors.Control;
			_Label24_32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_32.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_32.Location = new System.Drawing.Point(16, 152);
			_Label24_32.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_32.Name = "_Label24_32";
			_Label24_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_32.Size = new System.Drawing.Size(75, 17);
			_Label24_32.TabIndex = 321;
			_Label24_32.Text = "Provider Name";
			// 
			// _Label24_31
			// 
			_Label24_31.AllowDrop = true;
			_Label24_31.BackColor = System.Drawing.SystemColors.Control;
			_Label24_31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_31.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_31.Location = new System.Drawing.Point(16, 98);
			_Label24_31.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_31.Name = "_Label24_31";
			_Label24_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_31.Size = new System.Drawing.Size(75, 17);
			_Label24_31.TabIndex = 320;
			_Label24_31.Text = "Name";
			// 
			// _Label24_30
			// 
			_Label24_30.AllowDrop = true;
			_Label24_30.BackColor = System.Drawing.SystemColors.Control;
			_Label24_30.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_30.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_30.Location = new System.Drawing.Point(12, 48);
			_Label24_30.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_30.Name = "_Label24_30";
			_Label24_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_30.Size = new System.Drawing.Size(75, 17);
			_Label24_30.TabIndex = 319;
			_Label24_30.Text = "Code";
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.BackColor = System.Drawing.SystemColors.Control;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Enabled = false;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(92, 49);
			Label1.MinimumSize = new System.Drawing.Size(27, 18);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(27, 18);
			Label1.TabIndex = 182;
			Label1.Text = "ID";
			// 
			// cmd_Add_EMP
			// 
			cmd_Add_EMP.AllowDrop = true;
			cmd_Add_EMP.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_EMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_EMP.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_EMP.Location = new System.Drawing.Point(508, 43);
			cmd_Add_EMP.Name = "cmd_Add_EMP";
			cmd_Add_EMP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_EMP.Size = new System.Drawing.Size(57, 25);
			cmd_Add_EMP.TabIndex = 179;
			cmd_Add_EMP.Text = "&Add";
			cmd_Add_EMP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_EMP.UseVisualStyleBackColor = false;
			cmd_Add_EMP.Click += new System.EventHandler(cmd_Add_EMP_Click);
			// 
			// FG_Engine_Maintenance
			// 
			FG_Engine_Maintenance.AllowDrop = true;
			FG_Engine_Maintenance.AllowUserToAddRows = false;
			FG_Engine_Maintenance.AllowUserToDeleteRows = false;
			FG_Engine_Maintenance.AllowUserToResizeColumns = false;
			FG_Engine_Maintenance.AllowUserToResizeColumns = FG_Engine_Maintenance.ColumnHeadersVisible;
			FG_Engine_Maintenance.AllowUserToResizeRows = false;
			FG_Engine_Maintenance.AllowUserToResizeRows = false;
			FG_Engine_Maintenance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_Engine_Maintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Engine_Maintenance.ColumnsCount = 5;
			FG_Engine_Maintenance.FixedColumns = 0;
			FG_Engine_Maintenance.FixedRows = 1;
			FG_Engine_Maintenance.Location = new System.Drawing.Point(13, 25);
			FG_Engine_Maintenance.Name = "FG_Engine_Maintenance";
			FG_Engine_Maintenance.ReadOnly = true;
			FG_Engine_Maintenance.RowsCount = 2;
			FG_Engine_Maintenance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Engine_Maintenance.ShowCellToolTips = false;
			FG_Engine_Maintenance.Size = new System.Drawing.Size(488, 419);
			FG_Engine_Maintenance.StandardTab = true;
			FG_Engine_Maintenance.TabIndex = 180;
			FG_Engine_Maintenance.Click += new System.EventHandler(FG_Engine_Maintenance_Click);
			// 
			// _tab_Lookup_TabPage7
			// 
			_tab_Lookup_TabPage7.Controls.Add(FG_Interior_Configuration);
			_tab_Lookup_TabPage7.Controls.Add(cmd_Add_IC);
			_tab_Lookup_TabPage7.Controls.Add(pnl_IC_Update_Change);
			_tab_Lookup_TabPage7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage7.Text = "Interior Configuration";
			// 
			// FG_Interior_Configuration
			// 
			FG_Interior_Configuration.AllowDrop = true;
			FG_Interior_Configuration.AllowUserToAddRows = false;
			FG_Interior_Configuration.AllowUserToDeleteRows = false;
			FG_Interior_Configuration.AllowUserToResizeColumns = false;
			FG_Interior_Configuration.AllowUserToResizeRows = false;
			FG_Interior_Configuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_Interior_Configuration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Interior_Configuration.ColumnsCount = 1;
			FG_Interior_Configuration.FixedColumns = 0;
			FG_Interior_Configuration.FixedRows = 1;
			FG_Interior_Configuration.Location = new System.Drawing.Point(35, 40);
			FG_Interior_Configuration.Name = "FG_Interior_Configuration";
			FG_Interior_Configuration.ReadOnly = true;
			FG_Interior_Configuration.RowsCount = 2;
			FG_Interior_Configuration.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Interior_Configuration.ShowCellToolTips = false;
			FG_Interior_Configuration.Size = new System.Drawing.Size(226, 185);
			FG_Interior_Configuration.StandardTab = true;
			FG_Interior_Configuration.TabIndex = 186;
			FG_Interior_Configuration.Click += new System.EventHandler(FG_Interior_Configuration_Click);
			// 
			// cmd_Add_IC
			// 
			cmd_Add_IC.AllowDrop = true;
			cmd_Add_IC.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_IC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_IC.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_IC.Location = new System.Drawing.Point(294, 28);
			cmd_Add_IC.Name = "cmd_Add_IC";
			cmd_Add_IC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_IC.Size = new System.Drawing.Size(57, 25);
			cmd_Add_IC.TabIndex = 185;
			cmd_Add_IC.Text = "&Add";
			cmd_Add_IC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_IC.UseVisualStyleBackColor = false;
			cmd_Add_IC.Click += new System.EventHandler(cmd_Add_IC_Click);
			// 
			// pnl_IC_Update_Change
			// 
			pnl_IC_Update_Change.AllowDrop = true;
			pnl_IC_Update_Change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_IC_Update_Change.Controls.Add(cmd_Save_IC);
			pnl_IC_Update_Change.Controls.Add(cmd_Cancel_IC);
			pnl_IC_Update_Change.Controls.Add(cmd_Delete_IC);
			pnl_IC_Update_Change.Controls.Add(txt_intconfig_name);
			pnl_IC_Update_Change.Controls.Add(_Label24_34);
			pnl_IC_Update_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_IC_Update_Change.Location = new System.Drawing.Point(283, 59);
			pnl_IC_Update_Change.Name = "pnl_IC_Update_Change";
			pnl_IC_Update_Change.Size = new System.Drawing.Size(345, 153);
			pnl_IC_Update_Change.TabIndex = 66;
			pnl_IC_Update_Change.Visible = false;
			// 
			// cmd_Save_IC
			// 
			cmd_Save_IC.AllowDrop = true;
			cmd_Save_IC.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_IC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_IC.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_IC.Location = new System.Drawing.Point(21, 7);
			cmd_Save_IC.Name = "cmd_Save_IC";
			cmd_Save_IC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_IC.Size = new System.Drawing.Size(57, 25);
			cmd_Save_IC.TabIndex = 70;
			cmd_Save_IC.Text = "&Save";
			cmd_Save_IC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_IC.UseVisualStyleBackColor = false;
			cmd_Save_IC.Click += new System.EventHandler(cmd_Save_IC_Click);
			// 
			// cmd_Cancel_IC
			// 
			cmd_Cancel_IC.AllowDrop = true;
			cmd_Cancel_IC.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_IC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_IC.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_IC.Location = new System.Drawing.Point(99, 7);
			cmd_Cancel_IC.Name = "cmd_Cancel_IC";
			cmd_Cancel_IC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_IC.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_IC.TabIndex = 69;
			cmd_Cancel_IC.Text = "&Cancel";
			cmd_Cancel_IC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_IC.UseVisualStyleBackColor = false;
			cmd_Cancel_IC.Click += new System.EventHandler(cmd_Cancel_IC_Click);
			// 
			// cmd_Delete_IC
			// 
			cmd_Delete_IC.AllowDrop = true;
			cmd_Delete_IC.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_IC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_IC.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_IC.Location = new System.Drawing.Point(175, 7);
			cmd_Delete_IC.Name = "cmd_Delete_IC";
			cmd_Delete_IC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_IC.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_IC.TabIndex = 68;
			cmd_Delete_IC.Text = "&Delete";
			cmd_Delete_IC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_IC.UseVisualStyleBackColor = false;
			cmd_Delete_IC.Click += new System.EventHandler(cmd_Delete_IC_Click);
			// 
			// txt_intconfig_name
			// 
			txt_intconfig_name.AcceptsReturn = true;
			txt_intconfig_name.AllowDrop = true;
			txt_intconfig_name.BackColor = System.Drawing.SystemColors.Window;
			txt_intconfig_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_intconfig_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_intconfig_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_intconfig_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_intconfig_name.Location = new System.Drawing.Point(16, 73);
			txt_intconfig_name.MaxLength = 15;
			txt_intconfig_name.Name = "txt_intconfig_name";
			txt_intconfig_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_intconfig_name.Size = new System.Drawing.Size(281, 19);
			txt_intconfig_name.TabIndex = 67;
			// 
			// _Label24_34
			// 
			_Label24_34.AllowDrop = true;
			_Label24_34.BackColor = System.Drawing.SystemColors.Control;
			_Label24_34.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_34.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_34.Location = new System.Drawing.Point(16, 54);
			_Label24_34.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_34.Name = "_Label24_34";
			_Label24_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_34.Size = new System.Drawing.Size(75, 17);
			_Label24_34.TabIndex = 323;
			_Label24_34.Text = "Name";
			// 
			// _tab_Lookup_TabPage8
			// 
			_tab_Lookup_TabPage8.Controls.Add(cmd_Add_Aircraft_Contact_type);
			_tab_Lookup_TabPage8.Controls.Add(pnl_Aircraft_Contact_Type_List);
			_tab_Lookup_TabPage8.Controls.Add(pnl_ACTypeMain);
			_tab_Lookup_TabPage8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage8.Text = "Aircraft Contact Type";
			// 
			// cmd_Add_Aircraft_Contact_type
			// 
			cmd_Add_Aircraft_Contact_type.AllowDrop = true;
			cmd_Add_Aircraft_Contact_type.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Aircraft_Contact_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Aircraft_Contact_type.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Aircraft_Contact_type.Location = new System.Drawing.Point(559, 42);
			cmd_Add_Aircraft_Contact_type.Name = "cmd_Add_Aircraft_Contact_type";
			cmd_Add_Aircraft_Contact_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Aircraft_Contact_type.Size = new System.Drawing.Size(57, 25);
			cmd_Add_Aircraft_Contact_type.TabIndex = 188;
			cmd_Add_Aircraft_Contact_type.Text = "&Add";
			cmd_Add_Aircraft_Contact_type.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Aircraft_Contact_type.UseVisualStyleBackColor = false;
			cmd_Add_Aircraft_Contact_type.Click += new System.EventHandler(cmd_Add_Aircraft_Contact_type_Click);
			// 
			// pnl_Aircraft_Contact_Type_List
			// 
			pnl_Aircraft_Contact_Type_List.AllowDrop = true;
			pnl_Aircraft_Contact_Type_List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Aircraft_Contact_Type_List.Controls.Add(FGRD_AircraftContactType);
			pnl_Aircraft_Contact_Type_List.Controls.Add(cboShow);
			pnl_Aircraft_Contact_Type_List.Controls.Add(_Label24_39);
			pnl_Aircraft_Contact_Type_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Aircraft_Contact_Type_List.Location = new System.Drawing.Point(6, 15);
			pnl_Aircraft_Contact_Type_List.Name = "pnl_Aircraft_Contact_Type_List";
			pnl_Aircraft_Contact_Type_List.Size = new System.Drawing.Size(648, 432);
			pnl_Aircraft_Contact_Type_List.TabIndex = 136;
			// 
			// FGRD_AircraftContactType
			// 
			FGRD_AircraftContactType.AllowDrop = true;
			FGRD_AircraftContactType.AllowUserToAddRows = false;
			FGRD_AircraftContactType.AllowUserToDeleteRows = false;
			FGRD_AircraftContactType.AllowUserToResizeColumns = false;
			FGRD_AircraftContactType.AllowUserToResizeColumns = FGRD_AircraftContactType.ColumnHeadersVisible;
			FGRD_AircraftContactType.AllowUserToResizeRows = false;
			FGRD_AircraftContactType.AllowUserToResizeRows = false;
			FGRD_AircraftContactType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FGRD_AircraftContactType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FGRD_AircraftContactType.ColumnsCount = 13;
			FGRD_AircraftContactType.FixedColumns = 0;
			FGRD_AircraftContactType.FixedRows = 1;
			FGRD_AircraftContactType.Location = new System.Drawing.Point(10, 54);
			FGRD_AircraftContactType.Name = "FGRD_AircraftContactType";
			FGRD_AircraftContactType.ReadOnly = true;
			FGRD_AircraftContactType.RowsCount = 2;
			FGRD_AircraftContactType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FGRD_AircraftContactType.ShowCellToolTips = false;
			FGRD_AircraftContactType.Size = new System.Drawing.Size(626, 364);
			FGRD_AircraftContactType.StandardTab = true;
			FGRD_AircraftContactType.TabIndex = 189;
			FGRD_AircraftContactType.Click += new System.EventHandler(FGRD_AircraftContactType_Click);
			// 
			// cboShow
			// 
			cboShow.AllowDrop = true;
			cboShow.BackColor = System.Drawing.SystemColors.Window;
			cboShow.CausesValidation = true;
			cboShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboShow.Enabled = true;
			cboShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboShow.ForeColor = System.Drawing.SystemColors.WindowText;
			cboShow.IntegralHeight = true;
			cboShow.Location = new System.Drawing.Point(118, 15);
			cboShow.Name = "cboShow";
			cboShow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboShow.Size = new System.Drawing.Size(207, 21);
			cboShow.Sorted = false;
			cboShow.TabIndex = 137;
			cboShow.TabStop = true;
			cboShow.Visible = true;
			cboShow.SelectionChangeCommitted += new System.EventHandler(cboShow_SelectionChangeCommitted);
			// 
			// _Label24_39
			// 
			_Label24_39.AllowDrop = true;
			_Label24_39.BackColor = System.Drawing.SystemColors.Control;
			_Label24_39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_39.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_39.Location = new System.Drawing.Point(78, 16);
			_Label24_39.MinimumSize = new System.Drawing.Size(35, 17);
			_Label24_39.Name = "_Label24_39";
			_Label24_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_39.Size = new System.Drawing.Size(35, 17);
			_Label24_39.TabIndex = 328;
			_Label24_39.Text = "Show";
			// 
			// pnl_ACTypeMain
			// 
			pnl_ACTypeMain.AllowDrop = true;
			pnl_ACTypeMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_ACTypeMain.Controls.Add(cmd_Delete_Aircraft_Contact_Type);
			pnl_ACTypeMain.Controls.Add(cmd_Cancel_Aircraft_Contact_Type);
			pnl_ACTypeMain.Controls.Add(cmd_Save_Aircraft_Contact_Type);
			pnl_ACTypeMain.Controls.Add(pnl_Aircraft_Contact_Type_AddUpdate);
			pnl_ACTypeMain.Controls.Add(pnl_CompanyRelationship);
			pnl_ACTypeMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_ACTypeMain.Location = new System.Drawing.Point(657, 32);
			pnl_ACTypeMain.Name = "pnl_ACTypeMain";
			pnl_ACTypeMain.Size = new System.Drawing.Size(240, 414);
			pnl_ACTypeMain.TabIndex = 119;
			pnl_ACTypeMain.Visible = false;
			// 
			// cmd_Delete_Aircraft_Contact_Type
			// 
			cmd_Delete_Aircraft_Contact_Type.AllowDrop = true;
			cmd_Delete_Aircraft_Contact_Type.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Aircraft_Contact_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Aircraft_Contact_Type.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Aircraft_Contact_Type.Location = new System.Drawing.Point(145, 351);
			cmd_Delete_Aircraft_Contact_Type.Name = "cmd_Delete_Aircraft_Contact_Type";
			cmd_Delete_Aircraft_Contact_Type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Aircraft_Contact_Type.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Aircraft_Contact_Type.TabIndex = 135;
			cmd_Delete_Aircraft_Contact_Type.Text = "&Delete";
			cmd_Delete_Aircraft_Contact_Type.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Aircraft_Contact_Type.UseVisualStyleBackColor = false;
			cmd_Delete_Aircraft_Contact_Type.Click += new System.EventHandler(cmd_Delete_Aircraft_Contact_Type_Click);
			// 
			// cmd_Cancel_Aircraft_Contact_Type
			// 
			cmd_Cancel_Aircraft_Contact_Type.AllowDrop = true;
			cmd_Cancel_Aircraft_Contact_Type.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Aircraft_Contact_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Aircraft_Contact_Type.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Aircraft_Contact_Type.Location = new System.Drawing.Point(81, 351);
			cmd_Cancel_Aircraft_Contact_Type.Name = "cmd_Cancel_Aircraft_Contact_Type";
			cmd_Cancel_Aircraft_Contact_Type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Aircraft_Contact_Type.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_Aircraft_Contact_Type.TabIndex = 134;
			cmd_Cancel_Aircraft_Contact_Type.Text = "&Cancel";
			cmd_Cancel_Aircraft_Contact_Type.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Aircraft_Contact_Type.UseVisualStyleBackColor = false;
			cmd_Cancel_Aircraft_Contact_Type.Click += new System.EventHandler(cmd_Cancel_Aircraft_Contact_Type_Click);
			// 
			// cmd_Save_Aircraft_Contact_Type
			// 
			cmd_Save_Aircraft_Contact_Type.AllowDrop = true;
			cmd_Save_Aircraft_Contact_Type.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Aircraft_Contact_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Aircraft_Contact_Type.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Aircraft_Contact_Type.Location = new System.Drawing.Point(16, 351);
			cmd_Save_Aircraft_Contact_Type.Name = "cmd_Save_Aircraft_Contact_Type";
			cmd_Save_Aircraft_Contact_Type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Aircraft_Contact_Type.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Aircraft_Contact_Type.TabIndex = 133;
			cmd_Save_Aircraft_Contact_Type.Text = "&Save";
			cmd_Save_Aircraft_Contact_Type.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Aircraft_Contact_Type.UseVisualStyleBackColor = false;
			cmd_Save_Aircraft_Contact_Type.Click += new System.EventHandler(cmd_Save_Aircraft_Contact_Type_Click);
			// 
			// pnl_Aircraft_Contact_Type_AddUpdate
			// 
			pnl_Aircraft_Contact_Type_AddUpdate.AllowDrop = true;
			pnl_Aircraft_Contact_Type_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Aircraft_Contact_Type_AddUpdate.Controls.Add(txt_actype_Name);
			pnl_Aircraft_Contact_Type_AddUpdate.Controls.Add(txt_actype_code);
			pnl_Aircraft_Contact_Type_AddUpdate.Controls.Add(txt_actype_abbrev);
			pnl_Aircraft_Contact_Type_AddUpdate.Controls.Add(txt_actype_use_flag);
			pnl_Aircraft_Contact_Type_AddUpdate.Controls.Add(_Label24_38);
			pnl_Aircraft_Contact_Type_AddUpdate.Controls.Add(_Label24_37);
			pnl_Aircraft_Contact_Type_AddUpdate.Controls.Add(_Label24_36);
			pnl_Aircraft_Contact_Type_AddUpdate.Controls.Add(_Label24_35);
			pnl_Aircraft_Contact_Type_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Aircraft_Contact_Type_AddUpdate.Location = new System.Drawing.Point(6, 3);
			pnl_Aircraft_Contact_Type_AddUpdate.Name = "pnl_Aircraft_Contact_Type_AddUpdate";
			pnl_Aircraft_Contact_Type_AddUpdate.Size = new System.Drawing.Size(231, 175);
			pnl_Aircraft_Contact_Type_AddUpdate.TabIndex = 120;
			pnl_Aircraft_Contact_Type_AddUpdate.Visible = false;
			// 
			// txt_actype_Name
			// 
			txt_actype_Name.AcceptsReturn = true;
			txt_actype_Name.AllowDrop = true;
			txt_actype_Name.BackColor = System.Drawing.SystemColors.Window;
			txt_actype_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_actype_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_actype_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_actype_Name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_actype_Name.Location = new System.Drawing.Point(16, 147);
			txt_actype_Name.MaxLength = 50;
			txt_actype_Name.Name = "txt_actype_Name";
			txt_actype_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_actype_Name.Size = new System.Drawing.Size(209, 19);
			txt_actype_Name.TabIndex = 124;
			// 
			// txt_actype_code
			// 
			txt_actype_code.AcceptsReturn = true;
			txt_actype_code.AllowDrop = true;
			txt_actype_code.BackColor = System.Drawing.SystemColors.Window;
			txt_actype_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_actype_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_actype_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_actype_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_actype_code.Location = new System.Drawing.Point(16, 35);
			txt_actype_code.MaxLength = 2;
			txt_actype_code.Name = "txt_actype_code";
			txt_actype_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_actype_code.Size = new System.Drawing.Size(27, 19);
			txt_actype_code.TabIndex = 121;
			// 
			// txt_actype_abbrev
			// 
			txt_actype_abbrev.AcceptsReturn = true;
			txt_actype_abbrev.AllowDrop = true;
			txt_actype_abbrev.BackColor = System.Drawing.SystemColors.Window;
			txt_actype_abbrev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_actype_abbrev.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_actype_abbrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_actype_abbrev.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_actype_abbrev.Location = new System.Drawing.Point(16, 73);
			txt_actype_abbrev.MaxLength = 5;
			txt_actype_abbrev.Name = "txt_actype_abbrev";
			txt_actype_abbrev.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_actype_abbrev.Size = new System.Drawing.Size(72, 19);
			txt_actype_abbrev.TabIndex = 122;
			// 
			// txt_actype_use_flag
			// 
			txt_actype_use_flag.AcceptsReturn = true;
			txt_actype_use_flag.AllowDrop = true;
			txt_actype_use_flag.BackColor = System.Drawing.SystemColors.Window;
			txt_actype_use_flag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_actype_use_flag.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_actype_use_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_actype_use_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_actype_use_flag.Location = new System.Drawing.Point(16, 109);
			txt_actype_use_flag.MaxLength = 1;
			txt_actype_use_flag.Name = "txt_actype_use_flag";
			txt_actype_use_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_actype_use_flag.Size = new System.Drawing.Size(27, 19);
			txt_actype_use_flag.TabIndex = 123;
			// 
			// _Label24_38
			// 
			_Label24_38.AllowDrop = true;
			_Label24_38.BackColor = System.Drawing.SystemColors.Control;
			_Label24_38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_38.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_38.Location = new System.Drawing.Point(14, 128);
			_Label24_38.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_38.Name = "_Label24_38";
			_Label24_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_38.Size = new System.Drawing.Size(75, 17);
			_Label24_38.TabIndex = 327;
			_Label24_38.Text = "Name";
			// 
			// _Label24_37
			// 
			_Label24_37.AllowDrop = true;
			_Label24_37.BackColor = System.Drawing.SystemColors.Control;
			_Label24_37.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_37.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_37.Location = new System.Drawing.Point(14, 94);
			_Label24_37.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_37.Name = "_Label24_37";
			_Label24_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_37.Size = new System.Drawing.Size(75, 17);
			_Label24_37.TabIndex = 326;
			_Label24_37.Text = "Usage Code";
			// 
			// _Label24_36
			// 
			_Label24_36.AllowDrop = true;
			_Label24_36.BackColor = System.Drawing.SystemColors.Control;
			_Label24_36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_36.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_36.Location = new System.Drawing.Point(14, 54);
			_Label24_36.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_36.Name = "_Label24_36";
			_Label24_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_36.Size = new System.Drawing.Size(75, 17);
			_Label24_36.TabIndex = 325;
			_Label24_36.Text = "Abbreviation";
			// 
			// _Label24_35
			// 
			_Label24_35.AllowDrop = true;
			_Label24_35.BackColor = System.Drawing.SystemColors.Control;
			_Label24_35.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_35.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_35.Location = new System.Drawing.Point(14, 18);
			_Label24_35.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_35.Name = "_Label24_35";
			_Label24_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_35.Size = new System.Drawing.Size(75, 17);
			_Label24_35.TabIndex = 324;
			_Label24_35.Text = "Code";
			// 
			// pnl_CompanyRelationship
			// 
			pnl_CompanyRelationship.AllowDrop = true;
			pnl_CompanyRelationship.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_CompanyRelationship.Controls.Add(chk_actype_shareref_flag);
			pnl_CompanyRelationship.Controls.Add(chk_actype_transref_flag);
			pnl_CompanyRelationship.Controls.Add(chk_actype_acref_flag);
			pnl_CompanyRelationship.Controls.Add(txt_compref_name2);
			pnl_CompanyRelationship.Controls.Add(chk_compref_internal_flag);
			pnl_CompanyRelationship.Controls.Add(chk_compref_twoway_flag);
			pnl_CompanyRelationship.Controls.Add(chk_actype_compref_flag);
			pnl_CompanyRelationship.Controls.Add(Label36);
			pnl_CompanyRelationship.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_CompanyRelationship.Location = new System.Drawing.Point(4, 179);
			pnl_CompanyRelationship.Name = "pnl_CompanyRelationship";
			pnl_CompanyRelationship.Size = new System.Drawing.Size(231, 164);
			pnl_CompanyRelationship.TabIndex = 131;
			// 
			// chk_actype_shareref_flag
			// 
			chk_actype_shareref_flag.AllowDrop = true;
			chk_actype_shareref_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_actype_shareref_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_actype_shareref_flag.CausesValidation = true;
			chk_actype_shareref_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_actype_shareref_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_actype_shareref_flag.Enabled = true;
			chk_actype_shareref_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_actype_shareref_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_actype_shareref_flag.Location = new System.Drawing.Point(13, 64);
			chk_actype_shareref_flag.Name = "chk_actype_shareref_flag";
			chk_actype_shareref_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_actype_shareref_flag.Size = new System.Drawing.Size(211, 13);
			chk_actype_shareref_flag.TabIndex = 138;
			chk_actype_shareref_flag.TabStop = true;
			chk_actype_shareref_flag.Text = "Fractional Share Reference";
			chk_actype_shareref_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_actype_shareref_flag.Visible = true;
			// 
			// chk_actype_transref_flag
			// 
			chk_actype_transref_flag.AllowDrop = true;
			chk_actype_transref_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_actype_transref_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_actype_transref_flag.CausesValidation = true;
			chk_actype_transref_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_actype_transref_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_actype_transref_flag.Enabled = true;
			chk_actype_transref_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_actype_transref_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_actype_transref_flag.Location = new System.Drawing.Point(13, 49);
			chk_actype_transref_flag.Name = "chk_actype_transref_flag";
			chk_actype_transref_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_actype_transref_flag.Size = new System.Drawing.Size(211, 13);
			chk_actype_transref_flag.TabIndex = 127;
			chk_actype_transref_flag.TabStop = true;
			chk_actype_transref_flag.Text = "Transaction Reference";
			chk_actype_transref_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_actype_transref_flag.Visible = true;
			// 
			// chk_actype_acref_flag
			// 
			chk_actype_acref_flag.AllowDrop = true;
			chk_actype_acref_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_actype_acref_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_actype_acref_flag.CausesValidation = true;
			chk_actype_acref_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_actype_acref_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_actype_acref_flag.Enabled = true;
			chk_actype_acref_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_actype_acref_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_actype_acref_flag.Location = new System.Drawing.Point(13, 19);
			chk_actype_acref_flag.Name = "chk_actype_acref_flag";
			chk_actype_acref_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_actype_acref_flag.Size = new System.Drawing.Size(211, 13);
			chk_actype_acref_flag.TabIndex = 125;
			chk_actype_acref_flag.TabStop = true;
			chk_actype_acref_flag.Text = "Aircraft to Company Reference";
			chk_actype_acref_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_actype_acref_flag.Visible = true;
			// 
			// txt_compref_name2
			// 
			txt_compref_name2.AcceptsReturn = true;
			txt_compref_name2.AllowDrop = true;
			txt_compref_name2.BackColor = System.Drawing.SystemColors.Window;
			txt_compref_name2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_compref_name2.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_compref_name2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_compref_name2.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_compref_name2.Location = new System.Drawing.Point(13, 141);
			txt_compref_name2.MaxLength = 50;
			txt_compref_name2.Name = "txt_compref_name2";
			txt_compref_name2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_compref_name2.Size = new System.Drawing.Size(217, 19);
			txt_compref_name2.TabIndex = 130;
			// 
			// chk_compref_internal_flag
			// 
			chk_compref_internal_flag.AllowDrop = true;
			chk_compref_internal_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_compref_internal_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_compref_internal_flag.CausesValidation = true;
			chk_compref_internal_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_compref_internal_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_compref_internal_flag.Enabled = true;
			chk_compref_internal_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_compref_internal_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_compref_internal_flag.Location = new System.Drawing.Point(13, 88);
			chk_compref_internal_flag.Name = "chk_compref_internal_flag";
			chk_compref_internal_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_compref_internal_flag.Size = new System.Drawing.Size(66, 13);
			chk_compref_internal_flag.TabIndex = 128;
			chk_compref_internal_flag.TabStop = true;
			chk_compref_internal_flag.Text = "Internal";
			chk_compref_internal_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_compref_internal_flag.Visible = true;
			// 
			// chk_compref_twoway_flag
			// 
			chk_compref_twoway_flag.AllowDrop = true;
			chk_compref_twoway_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_compref_twoway_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_compref_twoway_flag.CausesValidation = true;
			chk_compref_twoway_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_compref_twoway_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_compref_twoway_flag.Enabled = true;
			chk_compref_twoway_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_compref_twoway_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_compref_twoway_flag.Location = new System.Drawing.Point(13, 106);
			chk_compref_twoway_flag.Name = "chk_compref_twoway_flag";
			chk_compref_twoway_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_compref_twoway_flag.Size = new System.Drawing.Size(73, 13);
			chk_compref_twoway_flag.TabIndex = 129;
			chk_compref_twoway_flag.TabStop = true;
			chk_compref_twoway_flag.Text = "Two Way";
			chk_compref_twoway_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_compref_twoway_flag.Visible = true;
			// 
			// chk_actype_compref_flag
			// 
			chk_actype_compref_flag.AllowDrop = true;
			chk_actype_compref_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_actype_compref_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_actype_compref_flag.CausesValidation = true;
			chk_actype_compref_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_actype_compref_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_actype_compref_flag.Enabled = true;
			chk_actype_compref_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_actype_compref_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_actype_compref_flag.Location = new System.Drawing.Point(13, 34);
			chk_actype_compref_flag.Name = "chk_actype_compref_flag";
			chk_actype_compref_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_actype_compref_flag.Size = new System.Drawing.Size(211, 13);
			chk_actype_compref_flag.TabIndex = 126;
			chk_actype_compref_flag.TabStop = true;
			chk_actype_compref_flag.Text = "Company to Company Reference";
			chk_actype_compref_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_actype_compref_flag.Visible = true;
			chk_actype_compref_flag.CheckStateChanged += new System.EventHandler(chk_actype_compref_flag_CheckStateChanged);
			// 
			// Label36
			// 
			Label36.AllowDrop = true;
			Label36.AutoSize = true;
			Label36.BackColor = System.Drawing.SystemColors.Control;
			Label36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label36.ForeColor = System.Drawing.SystemColors.ControlText;
			Label36.Location = new System.Drawing.Point(13, 127);
			Label36.MinimumSize = new System.Drawing.Size(121, 13);
			Label36.Name = "Label36";
			Label36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label36.Size = new System.Drawing.Size(121, 13);
			Label36.TabIndex = 132;
			Label36.Text = "Reference Second Name";
			// 
			// _tab_Lookup_TabPage9
			// 
			_tab_Lookup_TabPage9.Controls.Add(FG_Auxiliary_Power);
			_tab_Lookup_TabPage9.Controls.Add(cmd_Add_APU);
			_tab_Lookup_TabPage9.Controls.Add(pnl_APU_Update_Change);
			_tab_Lookup_TabPage9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage9.Text = "Auxiliary Power Unit";
			// 
			// FG_Auxiliary_Power
			// 
			FG_Auxiliary_Power.AllowDrop = true;
			FG_Auxiliary_Power.AllowUserToAddRows = false;
			FG_Auxiliary_Power.AllowUserToDeleteRows = false;
			FG_Auxiliary_Power.AllowUserToResizeColumns = false;
			FG_Auxiliary_Power.AllowUserToResizeColumns = FG_Auxiliary_Power.ColumnHeadersVisible;
			FG_Auxiliary_Power.AllowUserToResizeRows = false;
			FG_Auxiliary_Power.AllowUserToResizeRows = false;
			FG_Auxiliary_Power.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_Auxiliary_Power.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Auxiliary_Power.ColumnsCount = 2;
			FG_Auxiliary_Power.FixedColumns = 0;
			FG_Auxiliary_Power.FixedRows = 1;
			FG_Auxiliary_Power.Location = new System.Drawing.Point(27, 50);
			FG_Auxiliary_Power.Name = "FG_Auxiliary_Power";
			FG_Auxiliary_Power.ReadOnly = true;
			FG_Auxiliary_Power.RowsCount = 2;
			FG_Auxiliary_Power.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Auxiliary_Power.ShowCellToolTips = false;
			FG_Auxiliary_Power.Size = new System.Drawing.Size(337, 398);
			FG_Auxiliary_Power.StandardTab = true;
			FG_Auxiliary_Power.TabIndex = 190;
			FG_Auxiliary_Power.Click += new System.EventHandler(FG_Auxiliary_Power_Click);
			// 
			// cmd_Add_APU
			// 
			cmd_Add_APU.AllowDrop = true;
			cmd_Add_APU.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_APU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_APU.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_APU.Location = new System.Drawing.Point(409, 19);
			cmd_Add_APU.Name = "cmd_Add_APU";
			cmd_Add_APU.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_APU.Size = new System.Drawing.Size(57, 25);
			cmd_Add_APU.TabIndex = 187;
			cmd_Add_APU.Text = "&Add";
			cmd_Add_APU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_APU.UseVisualStyleBackColor = false;
			cmd_Add_APU.Click += new System.EventHandler(cmd_Add_APU_Click);
			// 
			// pnl_APU_Update_Change
			// 
			pnl_APU_Update_Change.AllowDrop = true;
			pnl_APU_Update_Change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_APU_Update_Change.Controls.Add(cmd_Save_APU);
			pnl_APU_Update_Change.Controls.Add(cmd_Cancel_APU);
			pnl_APU_Update_Change.Controls.Add(cmd_Delete_APU);
			pnl_APU_Update_Change.Controls.Add(txt_apu_make_name);
			pnl_APU_Update_Change.Controls.Add(txt_apu_model_name);
			pnl_APU_Update_Change.Controls.Add(_Label24_41);
			pnl_APU_Update_Change.Controls.Add(_Label24_40);
			pnl_APU_Update_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_APU_Update_Change.Location = new System.Drawing.Point(406, 48);
			pnl_APU_Update_Change.Name = "pnl_APU_Update_Change";
			pnl_APU_Update_Change.Size = new System.Drawing.Size(345, 233);
			pnl_APU_Update_Change.TabIndex = 54;
			pnl_APU_Update_Change.Visible = false;
			// 
			// cmd_Save_APU
			// 
			cmd_Save_APU.AllowDrop = true;
			cmd_Save_APU.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_APU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_APU.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_APU.Location = new System.Drawing.Point(12, 10);
			cmd_Save_APU.Name = "cmd_Save_APU";
			cmd_Save_APU.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_APU.Size = new System.Drawing.Size(57, 25);
			cmd_Save_APU.TabIndex = 59;
			cmd_Save_APU.Text = "&Save";
			cmd_Save_APU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_APU.UseVisualStyleBackColor = false;
			cmd_Save_APU.Click += new System.EventHandler(cmd_Save_APU_Click);
			// 
			// cmd_Cancel_APU
			// 
			cmd_Cancel_APU.AllowDrop = true;
			cmd_Cancel_APU.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_APU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_APU.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_APU.Location = new System.Drawing.Point(100, 9);
			cmd_Cancel_APU.Name = "cmd_Cancel_APU";
			cmd_Cancel_APU.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_APU.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_APU.TabIndex = 58;
			cmd_Cancel_APU.Text = "&Cancel";
			cmd_Cancel_APU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_APU.UseVisualStyleBackColor = false;
			cmd_Cancel_APU.Click += new System.EventHandler(cmd_Cancel_APU_Click);
			// 
			// cmd_Delete_APU
			// 
			cmd_Delete_APU.AllowDrop = true;
			cmd_Delete_APU.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_APU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_APU.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_APU.Location = new System.Drawing.Point(192, 9);
			cmd_Delete_APU.Name = "cmd_Delete_APU";
			cmd_Delete_APU.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_APU.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_APU.TabIndex = 57;
			cmd_Delete_APU.Text = "&Delete";
			cmd_Delete_APU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_APU.UseVisualStyleBackColor = false;
			cmd_Delete_APU.Click += new System.EventHandler(cmd_Delete_APU_Click);
			// 
			// txt_apu_make_name
			// 
			txt_apu_make_name.AcceptsReturn = true;
			txt_apu_make_name.AllowDrop = true;
			txt_apu_make_name.BackColor = System.Drawing.SystemColors.Window;
			txt_apu_make_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_apu_make_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_apu_make_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_apu_make_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_apu_make_name.Location = new System.Drawing.Point(12, 76);
			txt_apu_make_name.MaxLength = 50;
			txt_apu_make_name.Name = "txt_apu_make_name";
			txt_apu_make_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_apu_make_name.Size = new System.Drawing.Size(281, 19);
			txt_apu_make_name.TabIndex = 56;
			// 
			// txt_apu_model_name
			// 
			txt_apu_model_name.AcceptsReturn = true;
			txt_apu_model_name.AllowDrop = true;
			txt_apu_model_name.BackColor = System.Drawing.SystemColors.Window;
			txt_apu_model_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_apu_model_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_apu_model_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_apu_model_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_apu_model_name.Location = new System.Drawing.Point(12, 125);
			txt_apu_model_name.MaxLength = 50;
			txt_apu_model_name.Name = "txt_apu_model_name";
			txt_apu_model_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_apu_model_name.Size = new System.Drawing.Size(281, 19);
			txt_apu_model_name.TabIndex = 55;
			// 
			// _Label24_41
			// 
			_Label24_41.AllowDrop = true;
			_Label24_41.BackColor = System.Drawing.SystemColors.Control;
			_Label24_41.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_41.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_41.Location = new System.Drawing.Point(12, 104);
			_Label24_41.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_41.Name = "_Label24_41";
			_Label24_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_41.Size = new System.Drawing.Size(75, 17);
			_Label24_41.TabIndex = 330;
			_Label24_41.Text = "Model Name";
			// 
			// _Label24_40
			// 
			_Label24_40.AllowDrop = true;
			_Label24_40.BackColor = System.Drawing.SystemColors.Control;
			_Label24_40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_40.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_40.Location = new System.Drawing.Point(12, 56);
			_Label24_40.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_40.Name = "_Label24_40";
			_Label24_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_40.Size = new System.Drawing.Size(75, 17);
			_Label24_40.TabIndex = 329;
			_Label24_40.Text = "Make Name";
			// 
			// _tab_Lookup_TabPage10
			// 
			_tab_Lookup_TabPage10.Controls.Add(FG_Operating_Certification);
			_tab_Lookup_TabPage10.Controls.Add(cmd_Add_Certification);
			_tab_Lookup_TabPage10.Controls.Add(pnl_Certification_Update_Change);
			_tab_Lookup_TabPage10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage10.Text = "Operating Certification";
			// 
			// FG_Operating_Certification
			// 
			FG_Operating_Certification.AllowDrop = true;
			FG_Operating_Certification.AllowUserToAddRows = false;
			FG_Operating_Certification.AllowUserToDeleteRows = false;
			FG_Operating_Certification.AllowUserToResizeColumns = false;
			FG_Operating_Certification.AllowUserToResizeColumns = FG_Operating_Certification.ColumnHeadersVisible;
			FG_Operating_Certification.AllowUserToResizeRows = false;
			FG_Operating_Certification.AllowUserToResizeRows = false;
			FG_Operating_Certification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_Operating_Certification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Operating_Certification.ColumnsCount = 3;
			FG_Operating_Certification.FixedColumns = 0;
			FG_Operating_Certification.FixedRows = 1;
			FG_Operating_Certification.Location = new System.Drawing.Point(25, 37);
			FG_Operating_Certification.Name = "FG_Operating_Certification";
			FG_Operating_Certification.ReadOnly = true;
			FG_Operating_Certification.RowsCount = 2;
			FG_Operating_Certification.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Operating_Certification.ShowCellToolTips = false;
			FG_Operating_Certification.Size = new System.Drawing.Size(610, 413);
			FG_Operating_Certification.StandardTab = true;
			FG_Operating_Certification.TabIndex = 192;
			FG_Operating_Certification.Click += new System.EventHandler(FG_Operating_Certification_Click);
			// 
			// cmd_Add_Certification
			// 
			cmd_Add_Certification.AllowDrop = true;
			cmd_Add_Certification.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Certification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Certification.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Certification.Location = new System.Drawing.Point(653, 42);
			cmd_Add_Certification.Name = "cmd_Add_Certification";
			cmd_Add_Certification.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Certification.Size = new System.Drawing.Size(53, 25);
			cmd_Add_Certification.TabIndex = 191;
			cmd_Add_Certification.Text = "&Add";
			cmd_Add_Certification.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Certification.UseVisualStyleBackColor = false;
			cmd_Add_Certification.Click += new System.EventHandler(cmd_Add_Certification_Click);
			// 
			// pnl_Certification_Update_Change
			// 
			pnl_Certification_Update_Change.AllowDrop = true;
			pnl_Certification_Update_Change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Certification_Update_Change.Controls.Add(chkCertActive);
			pnl_Certification_Update_Change.Controls.Add(cbo_Ops_Cert_usaFlag);
			pnl_Certification_Update_Change.Controls.Add(_txt_certification_name_2);
			pnl_Certification_Update_Change.Controls.Add(_txt_certification_name_0);
			pnl_Certification_Update_Change.Controls.Add(cmd_Delete_Certification);
			pnl_Certification_Update_Change.Controls.Add(cmd_Cancel_Certification);
			pnl_Certification_Update_Change.Controls.Add(cmd_Save_Certification);
			pnl_Certification_Update_Change.Controls.Add(_Label19_3);
			pnl_Certification_Update_Change.Controls.Add(_Label19_2);
			pnl_Certification_Update_Change.Controls.Add(_Label19_1);
			pnl_Certification_Update_Change.Controls.Add(_Label19_0);
			pnl_Certification_Update_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Certification_Update_Change.Location = new System.Drawing.Point(653, 77);
			pnl_Certification_Update_Change.Name = "pnl_Certification_Update_Change";
			pnl_Certification_Update_Change.Size = new System.Drawing.Size(341, 302);
			pnl_Certification_Update_Change.TabIndex = 60;
			pnl_Certification_Update_Change.Visible = false;
			// 
			// chkCertActive
			// 
			chkCertActive.AllowDrop = true;
			chkCertActive.Appearance = System.Windows.Forms.Appearance.Normal;
			chkCertActive.BackColor = System.Drawing.SystemColors.Control;
			chkCertActive.CausesValidation = true;
			chkCertActive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCertActive.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkCertActive.Enabled = true;
			chkCertActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkCertActive.ForeColor = System.Drawing.SystemColors.ControlText;
			chkCertActive.Location = new System.Drawing.Point(202, 108);
			chkCertActive.Name = "chkCertActive";
			chkCertActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkCertActive.Size = new System.Drawing.Size(55, 13);
			chkCertActive.TabIndex = 236;
			chkCertActive.TabStop = true;
			chkCertActive.Text = "Active";
			chkCertActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCertActive.Visible = true;
			// 
			// cbo_Ops_Cert_usaFlag
			// 
			cbo_Ops_Cert_usaFlag.AllowDrop = true;
			cbo_Ops_Cert_usaFlag.BackColor = System.Drawing.SystemColors.Window;
			cbo_Ops_Cert_usaFlag.CausesValidation = true;
			cbo_Ops_Cert_usaFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_Ops_Cert_usaFlag.Enabled = true;
			cbo_Ops_Cert_usaFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Ops_Cert_usaFlag.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Ops_Cert_usaFlag.IntegralHeight = true;
			cbo_Ops_Cert_usaFlag.Location = new System.Drawing.Point(18, 108);
			cbo_Ops_Cert_usaFlag.Name = "cbo_Ops_Cert_usaFlag";
			cbo_Ops_Cert_usaFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Ops_Cert_usaFlag.Size = new System.Drawing.Size(37, 21);
			cbo_Ops_Cert_usaFlag.Sorted = false;
			cbo_Ops_Cert_usaFlag.TabIndex = 235;
			cbo_Ops_Cert_usaFlag.TabStop = true;
			cbo_Ops_Cert_usaFlag.Visible = true;
			// 
			// _txt_certification_name_2
			// 
			_txt_certification_name_2.AcceptsReturn = true;
			_txt_certification_name_2.AllowDrop = true;
			_txt_certification_name_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_certification_name_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_certification_name_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_certification_name_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_certification_name_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_certification_name_2.Location = new System.Drawing.Point(17, 170);
			_txt_certification_name_2.MaxLength = 30;
			_txt_certification_name_2.Multiline = true;
			_txt_certification_name_2.Name = "_txt_certification_name_2";
			_txt_certification_name_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_certification_name_2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			_txt_certification_name_2.Size = new System.Drawing.Size(318, 127);
			_txt_certification_name_2.TabIndex = 233;
			// 
			// _txt_certification_name_0
			// 
			_txt_certification_name_0.AcceptsReturn = true;
			_txt_certification_name_0.AllowDrop = true;
			_txt_certification_name_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_certification_name_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_certification_name_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_certification_name_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_certification_name_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_certification_name_0.Location = new System.Drawing.Point(17, 69);
			_txt_certification_name_0.MaxLength = 30;
			_txt_certification_name_0.Name = "_txt_certification_name_0";
			_txt_certification_name_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_certification_name_0.Size = new System.Drawing.Size(281, 19);
			_txt_certification_name_0.TabIndex = 64;
			// 
			// cmd_Delete_Certification
			// 
			cmd_Delete_Certification.AllowDrop = true;
			cmd_Delete_Certification.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Certification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Certification.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Certification.Location = new System.Drawing.Point(186, 14);
			cmd_Delete_Certification.Name = "cmd_Delete_Certification";
			cmd_Delete_Certification.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Certification.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Certification.TabIndex = 63;
			cmd_Delete_Certification.Text = "&Delete";
			cmd_Delete_Certification.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Certification.UseVisualStyleBackColor = false;
			cmd_Delete_Certification.Click += new System.EventHandler(cmd_Delete_Certification_Click);
			// 
			// cmd_Cancel_Certification
			// 
			cmd_Cancel_Certification.AllowDrop = true;
			cmd_Cancel_Certification.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Certification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Certification.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Certification.Location = new System.Drawing.Point(100, 12);
			cmd_Cancel_Certification.Name = "cmd_Cancel_Certification";
			cmd_Cancel_Certification.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Certification.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_Certification.TabIndex = 62;
			cmd_Cancel_Certification.Text = "&Cancel";
			cmd_Cancel_Certification.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Certification.UseVisualStyleBackColor = false;
			cmd_Cancel_Certification.Click += new System.EventHandler(cmd_Cancel_Certification_Click);
			// 
			// cmd_Save_Certification
			// 
			cmd_Save_Certification.AllowDrop = true;
			cmd_Save_Certification.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Certification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Certification.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Certification.Location = new System.Drawing.Point(14, 11);
			cmd_Save_Certification.Name = "cmd_Save_Certification";
			cmd_Save_Certification.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Certification.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Certification.TabIndex = 61;
			cmd_Save_Certification.Text = "&Save";
			cmd_Save_Certification.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Certification.UseVisualStyleBackColor = false;
			cmd_Save_Certification.Click += new System.EventHandler(cmd_Save_Certification_Click);
			// 
			// _Label19_3
			// 
			_Label19_3.AllowDrop = true;
			_Label19_3.AutoSize = true;
			_Label19_3.BackColor = System.Drawing.Color.Transparent;
			_Label19_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label19_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label19_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label19_3.Location = new System.Drawing.Point(62, 108);
			_Label19_3.MinimumSize = new System.Drawing.Size(85, 39);
			_Label19_3.Name = "_Label19_3";
			_Label19_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label19_3.Size = new System.Drawing.Size(85, 39);
			_Label19_3.TabIndex = 237;
			_Label19_3.Text = "U - United States I - International    B - Both";
			// 
			// _Label19_2
			// 
			_Label19_2.AllowDrop = true;
			_Label19_2.AutoSize = true;
			_Label19_2.BackColor = System.Drawing.Color.Transparent;
			_Label19_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label19_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label19_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label19_2.Location = new System.Drawing.Point(16, 152);
			_Label19_2.MinimumSize = new System.Drawing.Size(45, 13);
			_Label19_2.Name = "_Label19_2";
			_Label19_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label19_2.Size = new System.Drawing.Size(45, 13);
			_Label19_2.TabIndex = 234;
			_Label19_2.Text = "USA Flag";
			// 
			// _Label19_1
			// 
			_Label19_1.AllowDrop = true;
			_Label19_1.AutoSize = true;
			_Label19_1.BackColor = System.Drawing.Color.Transparent;
			_Label19_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label19_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label19_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label19_1.Location = new System.Drawing.Point(17, 93);
			_Label19_1.MinimumSize = new System.Drawing.Size(79, 13);
			_Label19_1.Name = "_Label19_1";
			_Label19_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label19_1.Size = new System.Drawing.Size(79, 13);
			_Label19_1.TabIndex = 232;
			_Label19_1.Text = "Cetification Type";
			// 
			// _Label19_0
			// 
			_Label19_0.AllowDrop = true;
			_Label19_0.AutoSize = true;
			_Label19_0.BackColor = System.Drawing.Color.Transparent;
			_Label19_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label19_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label19_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label19_0.Location = new System.Drawing.Point(18, 52);
			_Label19_0.MinimumSize = new System.Drawing.Size(28, 13);
			_Label19_0.Name = "_Label19_0";
			_Label19_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label19_0.Size = new System.Drawing.Size(28, 13);
			_Label19_0.TabIndex = 65;
			_Label19_0.Text = "Name";
			// 
			// _tab_Lookup_TabPage11
			// 
			_tab_Lookup_TabPage11.Controls.Add(FG_Specification);
			_tab_Lookup_TabPage11.Controls.Add(cmd_Add_Spec);
			_tab_Lookup_TabPage11.Controls.Add(pnl_Spec_Update_Change);
			_tab_Lookup_TabPage11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage11.Text = "Specification";
			// 
			// FG_Specification
			// 
			FG_Specification.AllowDrop = true;
			FG_Specification.AllowUserToAddRows = false;
			FG_Specification.AllowUserToDeleteRows = false;
			FG_Specification.AllowUserToResizeColumns = false;
			FG_Specification.AllowUserToResizeColumns = FG_Specification.ColumnHeadersVisible;
			FG_Specification.AllowUserToResizeRows = false;
			FG_Specification.AllowUserToResizeRows = false;
			FG_Specification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_Specification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Specification.ColumnsCount = 3;
			FG_Specification.FixedColumns = 0;
			FG_Specification.FixedRows = 1;
			FG_Specification.Location = new System.Drawing.Point(22, 27);
			FG_Specification.Name = "FG_Specification";
			FG_Specification.ReadOnly = true;
			FG_Specification.RowsCount = 2;
			FG_Specification.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Specification.ShowCellToolTips = false;
			FG_Specification.Size = new System.Drawing.Size(351, 405);
			FG_Specification.StandardTab = true;
			FG_Specification.TabIndex = 194;
			FG_Specification.Click += new System.EventHandler(FG_Specification_Click);
			// 
			// cmd_Add_Spec
			// 
			cmd_Add_Spec.AllowDrop = true;
			cmd_Add_Spec.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Spec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Spec.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Spec.Location = new System.Drawing.Point(407, 20);
			cmd_Add_Spec.Name = "cmd_Add_Spec";
			cmd_Add_Spec.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Spec.Size = new System.Drawing.Size(57, 25);
			cmd_Add_Spec.TabIndex = 193;
			cmd_Add_Spec.Text = "&Add";
			cmd_Add_Spec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Spec.UseVisualStyleBackColor = false;
			cmd_Add_Spec.Click += new System.EventHandler(cmd_add_spec_Click);
			// 
			// pnl_Spec_Update_Change
			// 
			pnl_Spec_Update_Change.AllowDrop = true;
			pnl_Spec_Update_Change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Spec_Update_Change.Controls.Add(txt_spec_notes);
			pnl_Spec_Update_Change.Controls.Add(txt_spec_name);
			pnl_Spec_Update_Change.Controls.Add(cmd_Delete_Spec);
			pnl_Spec_Update_Change.Controls.Add(cmd_Cancel_Spec);
			pnl_Spec_Update_Change.Controls.Add(cmd_Save_Spec);
			pnl_Spec_Update_Change.Controls.Add(txt_spec_type);
			pnl_Spec_Update_Change.Controls.Add(_Label24_2);
			pnl_Spec_Update_Change.Controls.Add(_Label24_1);
			pnl_Spec_Update_Change.Controls.Add(_Label24_0);
			pnl_Spec_Update_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Spec_Update_Change.Location = new System.Drawing.Point(402, 62);
			pnl_Spec_Update_Change.Name = "pnl_Spec_Update_Change";
			pnl_Spec_Update_Change.Size = new System.Drawing.Size(375, 225);
			pnl_Spec_Update_Change.TabIndex = 71;
			pnl_Spec_Update_Change.Visible = false;
			// 
			// txt_spec_notes
			// 
			txt_spec_notes.AcceptsReturn = true;
			txt_spec_notes.AllowDrop = true;
			txt_spec_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_spec_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_spec_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_spec_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_spec_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_spec_notes.Location = new System.Drawing.Point(11, 172);
			txt_spec_notes.MaxLength = 50;
			txt_spec_notes.Name = "txt_spec_notes";
			txt_spec_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_spec_notes.Size = new System.Drawing.Size(347, 19);
			txt_spec_notes.TabIndex = 77;
			// 
			// txt_spec_name
			// 
			txt_spec_name.AcceptsReturn = true;
			txt_spec_name.AllowDrop = true;
			txt_spec_name.BackColor = System.Drawing.SystemColors.Window;
			txt_spec_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_spec_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_spec_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_spec_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_spec_name.Location = new System.Drawing.Point(12, 76);
			txt_spec_name.MaxLength = 40;
			txt_spec_name.Name = "txt_spec_name";
			txt_spec_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_spec_name.Size = new System.Drawing.Size(347, 19);
			txt_spec_name.TabIndex = 76;
			txt_spec_name.TabStop = false;
			// 
			// cmd_Delete_Spec
			// 
			cmd_Delete_Spec.AllowDrop = true;
			cmd_Delete_Spec.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Spec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Spec.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Spec.Location = new System.Drawing.Point(191, 7);
			cmd_Delete_Spec.Name = "cmd_Delete_Spec";
			cmd_Delete_Spec.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Spec.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Spec.TabIndex = 75;
			cmd_Delete_Spec.Text = "&Delete";
			cmd_Delete_Spec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Spec.UseVisualStyleBackColor = false;
			cmd_Delete_Spec.Click += new System.EventHandler(cmd_delete_spec_Click);
			// 
			// cmd_Cancel_Spec
			// 
			cmd_Cancel_Spec.AllowDrop = true;
			cmd_Cancel_Spec.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Spec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Spec.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Spec.Location = new System.Drawing.Point(103, 9);
			cmd_Cancel_Spec.Name = "cmd_Cancel_Spec";
			cmd_Cancel_Spec.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Spec.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_Spec.TabIndex = 74;
			cmd_Cancel_Spec.Text = "&Cancel";
			cmd_Cancel_Spec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Spec.UseVisualStyleBackColor = false;
			cmd_Cancel_Spec.Click += new System.EventHandler(cmd_cancel_spec_Click);
			// 
			// cmd_Save_Spec
			// 
			cmd_Save_Spec.AllowDrop = true;
			cmd_Save_Spec.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Spec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Spec.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Spec.Location = new System.Drawing.Point(16, 10);
			cmd_Save_Spec.Name = "cmd_Save_Spec";
			cmd_Save_Spec.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Spec.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Spec.TabIndex = 73;
			cmd_Save_Spec.Text = "&Save";
			cmd_Save_Spec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Spec.UseVisualStyleBackColor = false;
			cmd_Save_Spec.Click += new System.EventHandler(cmd_save_spec_Click);
			// 
			// txt_spec_type
			// 
			txt_spec_type.AcceptsReturn = true;
			txt_spec_type.AllowDrop = true;
			txt_spec_type.BackColor = System.Drawing.SystemColors.Window;
			txt_spec_type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_spec_type.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_spec_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_spec_type.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_spec_type.Location = new System.Drawing.Point(10, 124);
			txt_spec_type.MaxLength = 10;
			txt_spec_type.Name = "txt_spec_type";
			txt_spec_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_spec_type.Size = new System.Drawing.Size(135, 19);
			txt_spec_type.TabIndex = 72;
			// 
			// _Label24_2
			// 
			_Label24_2.AllowDrop = true;
			_Label24_2.BackColor = System.Drawing.SystemColors.Control;
			_Label24_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_2.Location = new System.Drawing.Point(12, 154);
			_Label24_2.MinimumSize = new System.Drawing.Size(41, 17);
			_Label24_2.Name = "_Label24_2";
			_Label24_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_2.Size = new System.Drawing.Size(41, 17);
			_Label24_2.TabIndex = 291;
			_Label24_2.Text = "Notes";
			// 
			// _Label24_1
			// 
			_Label24_1.AllowDrop = true;
			_Label24_1.BackColor = System.Drawing.SystemColors.Control;
			_Label24_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_1.Location = new System.Drawing.Point(12, 106);
			_Label24_1.MinimumSize = new System.Drawing.Size(41, 17);
			_Label24_1.Name = "_Label24_1";
			_Label24_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_1.Size = new System.Drawing.Size(41, 17);
			_Label24_1.TabIndex = 290;
			_Label24_1.Text = "Type";
			// 
			// _Label24_0
			// 
			_Label24_0.AllowDrop = true;
			_Label24_0.BackColor = System.Drawing.SystemColors.Control;
			_Label24_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_0.Location = new System.Drawing.Point(12, 55);
			_Label24_0.MinimumSize = new System.Drawing.Size(41, 17);
			_Label24_0.Name = "_Label24_0";
			_Label24_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_0.Size = new System.Drawing.Size(41, 17);
			_Label24_0.TabIndex = 78;
			_Label24_0.Text = "Name";
			// 
			// _tab_Lookup_TabPage12
			// 
			_tab_Lookup_TabPage12.Controls.Add(_lblAirport_10);
			_tab_Lookup_TabPage12.Controls.Add(pnl_airport_Update_Change);
			_tab_Lookup_TabPage12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage12.Text = "Aircraft Airport";
			// 
			// _lblAirport_10
			// 
			_lblAirport_10.AllowDrop = true;
			_lblAirport_10.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_10.Location = new System.Drawing.Point(536, 180);
			_lblAirport_10.MinimumSize = new System.Drawing.Size(51, 16);
			_lblAirport_10.Name = "_lblAirport_10";
			_lblAirport_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_10.Size = new System.Drawing.Size(51, 16);
			_lblAirport_10.TabIndex = 282;
			_lblAirport_10.Text = "City";
			_lblAirport_10.Click += new System.EventHandler(lblAirport_Click);
			// 
			// pnl_airport_Update_Change
			// 
			pnl_airport_Update_Change.AllowDrop = true;
			pnl_airport_Update_Change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_airport_Update_Change.Controls.Add(pnl_airport_update);
			pnl_airport_Update_Change.Controls.Add(SSPanel3);
			pnl_airport_Update_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_airport_Update_Change.Location = new System.Drawing.Point(10, 8);
			pnl_airport_Update_Change.Name = "pnl_airport_Update_Change";
			pnl_airport_Update_Change.Size = new System.Drawing.Size(1004, 451);
			pnl_airport_Update_Change.TabIndex = 79;
			// 
			// pnl_airport_update
			// 
			pnl_airport_update.AllowDrop = true;
			pnl_airport_update.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_airport_update.Controls.Add(_cmdAirportPreviousNext_1);
			pnl_airport_update.Controls.Add(_cmdAirportPreviousNext_0);
			pnl_airport_update.Controls.Add(cmd_Airport_Add);
			pnl_airport_update.Controls.Add(frmLatitudeLongatude);
			pnl_airport_update.Controls.Add(cmd_Airport_Delete);
			pnl_airport_update.Controls.Add(cmd_Airport_Cancel);
			pnl_airport_update.Controls.Add(cmd_Airport_Save);
			pnl_airport_update.Controls.Add(frmAirport);
			pnl_airport_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_airport_update.Location = new System.Drawing.Point(499, 8);
			pnl_airport_update.Name = "pnl_airport_update";
			pnl_airport_update.Size = new System.Drawing.Size(499, 437);
			pnl_airport_update.TabIndex = 80;
			// 
			// _cmdAirportPreviousNext_1
			// 
			_cmdAirportPreviousNext_1.AllowDrop = true;
			_cmdAirportPreviousNext_1.BackColor = System.Drawing.SystemColors.Control;
			_cmdAirportPreviousNext_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAirportPreviousNext_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAirportPreviousNext_1.Location = new System.Drawing.Point(3, 24);
			_cmdAirportPreviousNext_1.Name = "_cmdAirportPreviousNext_1";
			_cmdAirportPreviousNext_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAirportPreviousNext_1.Size = new System.Drawing.Size(27, 19);
			_cmdAirportPreviousNext_1.TabIndex = 252;
			_cmdAirportPreviousNext_1.Text = "&N";
			_cmdAirportPreviousNext_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAirportPreviousNext_1.UseVisualStyleBackColor = false;
			_cmdAirportPreviousNext_1.Click += new System.EventHandler(cmdAirportPreviousNext_Click);
			// 
			// _cmdAirportPreviousNext_0
			// 
			_cmdAirportPreviousNext_0.AllowDrop = true;
			_cmdAirportPreviousNext_0.BackColor = System.Drawing.SystemColors.Control;
			_cmdAirportPreviousNext_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdAirportPreviousNext_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdAirportPreviousNext_0.Location = new System.Drawing.Point(3, 3);
			_cmdAirportPreviousNext_0.Name = "_cmdAirportPreviousNext_0";
			_cmdAirportPreviousNext_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdAirportPreviousNext_0.Size = new System.Drawing.Size(27, 19);
			_cmdAirportPreviousNext_0.TabIndex = 251;
			_cmdAirportPreviousNext_0.Text = "&P";
			_cmdAirportPreviousNext_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdAirportPreviousNext_0.UseVisualStyleBackColor = false;
			_cmdAirportPreviousNext_0.Click += new System.EventHandler(cmdAirportPreviousNext_Click);
			// 
			// cmd_Airport_Add
			// 
			cmd_Airport_Add.AllowDrop = true;
			cmd_Airport_Add.BackColor = System.Drawing.SystemColors.Control;
			cmd_Airport_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Airport_Add.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Airport_Add.Location = new System.Drawing.Point(60, 13);
			cmd_Airport_Add.Name = "cmd_Airport_Add";
			cmd_Airport_Add.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Airport_Add.Size = new System.Drawing.Size(57, 25);
			cmd_Airport_Add.TabIndex = 81;
			cmd_Airport_Add.Text = "&Add";
			cmd_Airport_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Airport_Add.UseVisualStyleBackColor = false;
			cmd_Airport_Add.Click += new System.EventHandler(cmd_Airport_Add_Click);
			// 
			// frmLatitudeLongatude
			// 
			frmLatitudeLongatude.AllowDrop = true;
			frmLatitudeLongatude.BackColor = System.Drawing.SystemColors.Control;
			frmLatitudeLongatude.Controls.Add(_txtAirport_9);
			frmLatitudeLongatude.Controls.Add(_txtAirport_10);
			frmLatitudeLongatude.Controls.Add(_txtAirport_11);
			frmLatitudeLongatude.Controls.Add(_txtAirport_12);
			frmLatitudeLongatude.Controls.Add(_txtAirport_13);
			frmLatitudeLongatude.Controls.Add(_txtAirport_17);
			frmLatitudeLongatude.Controls.Add(_txtAirport_16);
			frmLatitudeLongatude.Controls.Add(_txtAirport_8);
			frmLatitudeLongatude.Controls.Add(_txtAirport_7);
			frmLatitudeLongatude.Controls.Add(_txtAirport_6);
			frmLatitudeLongatude.Controls.Add(_txtAirport_5);
			frmLatitudeLongatude.Controls.Add(_txtAirport_4);
			frmLatitudeLongatude.Controls.Add(lblLatitudeGPS);
			frmLatitudeLongatude.Controls.Add(_lblAirport_24);
			frmLatitudeLongatude.Controls.Add(_lblAirport_19);
			frmLatitudeLongatude.Controls.Add(_lblAirport_8);
			frmLatitudeLongatude.Controls.Add(_lblAirport_7);
			frmLatitudeLongatude.Controls.Add(_lblAirport_6);
			frmLatitudeLongatude.Controls.Add(_lblAirport_5);
			frmLatitudeLongatude.Controls.Add(_lblAirport_4);
			frmLatitudeLongatude.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmLatitudeLongatude.Enabled = true;
			frmLatitudeLongatude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmLatitudeLongatude.ForeColor = System.Drawing.SystemColors.ControlText;
			frmLatitudeLongatude.Location = new System.Drawing.Point(12, 264);
			frmLatitudeLongatude.Name = "frmLatitudeLongatude";
			frmLatitudeLongatude.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmLatitudeLongatude.Size = new System.Drawing.Size(344, 163);
			frmLatitudeLongatude.TabIndex = 242;
			frmLatitudeLongatude.Text = "Latitude                                                             Longitude";
			frmLatitudeLongatude.Visible = true;
			// 
			// _txtAirport_9
			// 
			_txtAirport_9.AcceptsReturn = true;
			_txtAirport_9.AllowDrop = true;
			_txtAirport_9.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_9.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_9.Enabled = false;
			_txtAirport_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_9.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_9.Location = new System.Drawing.Point(230, 16);
			_txtAirport_9.MaxLength = 15;
			_txtAirport_9.Name = "_txtAirport_9";
			_txtAirport_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_9.Size = new System.Drawing.Size(100, 22);
			_txtAirport_9.TabIndex = 102;
			_txtAirport_9.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_9.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_10
			// 
			_txtAirport_10.AcceptsReturn = true;
			_txtAirport_10.AllowDrop = true;
			_txtAirport_10.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_10.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_10.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_10.Location = new System.Drawing.Point(230, 64);
			_txtAirport_10.MaxLength = 1;
			_txtAirport_10.Name = "_txtAirport_10";
			_txtAirport_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_10.Size = new System.Drawing.Size(25, 22);
			_txtAirport_10.TabIndex = 104;
			_txtAirport_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			_txtAirport_10.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_10.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_11
			// 
			_txtAirport_11.AcceptsReturn = true;
			_txtAirport_11.AllowDrop = true;
			_txtAirport_11.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_11.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_11.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_11.Location = new System.Drawing.Point(230, 88);
			_txtAirport_11.MaxLength = 4;
			_txtAirport_11.Name = "_txtAirport_11";
			_txtAirport_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_11.Size = new System.Drawing.Size(37, 22);
			_txtAirport_11.TabIndex = 105;
			_txtAirport_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtAirport_11.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_11.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_12
			// 
			_txtAirport_12.AcceptsReturn = true;
			_txtAirport_12.AllowDrop = true;
			_txtAirport_12.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_12.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_12.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_12.Location = new System.Drawing.Point(230, 112);
			_txtAirport_12.MaxLength = 4;
			_txtAirport_12.Name = "_txtAirport_12";
			_txtAirport_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_12.Size = new System.Drawing.Size(37, 22);
			_txtAirport_12.TabIndex = 106;
			_txtAirport_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtAirport_12.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_12.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_13
			// 
			_txtAirport_13.AcceptsReturn = true;
			_txtAirport_13.AllowDrop = true;
			_txtAirport_13.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_13.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_13.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_13.Location = new System.Drawing.Point(230, 136);
			_txtAirport_13.MaxLength = 4;
			_txtAirport_13.Name = "_txtAirport_13";
			_txtAirport_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_13.Size = new System.Drawing.Size(37, 22);
			_txtAirport_13.TabIndex = 107;
			_txtAirport_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtAirport_13.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_13.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_17
			// 
			_txtAirport_17.AcceptsReturn = true;
			_txtAirport_17.AllowDrop = true;
			_txtAirport_17.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_17.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_17.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_17.Location = new System.Drawing.Point(230, 40);
			_txtAirport_17.MaxLength = 15;
			_txtAirport_17.Name = "_txtAirport_17";
			_txtAirport_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_17.Size = new System.Drawing.Size(73, 22);
			_txtAirport_17.TabIndex = 103;
			_txtAirport_17.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_17.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_16
			// 
			_txtAirport_16.AcceptsReturn = true;
			_txtAirport_16.AllowDrop = true;
			_txtAirport_16.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_16.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_16.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_16.Location = new System.Drawing.Point(10, 38);
			_txtAirport_16.MaxLength = 15;
			_txtAirport_16.Name = "_txtAirport_16";
			_txtAirport_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_16.Size = new System.Drawing.Size(73, 22);
			_txtAirport_16.TabIndex = 97;
			_txtAirport_16.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_16.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_8
			// 
			_txtAirport_8.AcceptsReturn = true;
			_txtAirport_8.AllowDrop = true;
			_txtAirport_8.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_8.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_8.Location = new System.Drawing.Point(10, 135);
			_txtAirport_8.MaxLength = 4;
			_txtAirport_8.Name = "_txtAirport_8";
			_txtAirport_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_8.Size = new System.Drawing.Size(37, 22);
			_txtAirport_8.TabIndex = 101;
			_txtAirport_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtAirport_8.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_8.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_7
			// 
			_txtAirport_7.AcceptsReturn = true;
			_txtAirport_7.AllowDrop = true;
			_txtAirport_7.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_7.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_7.Location = new System.Drawing.Point(10, 111);
			_txtAirport_7.MaxLength = 4;
			_txtAirport_7.Name = "_txtAirport_7";
			_txtAirport_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_7.Size = new System.Drawing.Size(37, 22);
			_txtAirport_7.TabIndex = 100;
			_txtAirport_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtAirport_7.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_7.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_6
			// 
			_txtAirport_6.AcceptsReturn = true;
			_txtAirport_6.AllowDrop = true;
			_txtAirport_6.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_6.Location = new System.Drawing.Point(10, 87);
			_txtAirport_6.MaxLength = 4;
			_txtAirport_6.Name = "_txtAirport_6";
			_txtAirport_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_6.Size = new System.Drawing.Size(37, 22);
			_txtAirport_6.TabIndex = 99;
			_txtAirport_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtAirport_6.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_6.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_5
			// 
			_txtAirport_5.AcceptsReturn = true;
			_txtAirport_5.AllowDrop = true;
			_txtAirport_5.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_5.Location = new System.Drawing.Point(10, 63);
			_txtAirport_5.MaxLength = 1;
			_txtAirport_5.Name = "_txtAirport_5";
			_txtAirport_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_5.Size = new System.Drawing.Size(25, 22);
			_txtAirport_5.TabIndex = 98;
			_txtAirport_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			_txtAirport_5.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_5.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_4
			// 
			_txtAirport_4.AcceptsReturn = true;
			_txtAirport_4.AllowDrop = true;
			_txtAirport_4.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_4.Enabled = false;
			_txtAirport_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_4.Location = new System.Drawing.Point(10, 15);
			_txtAirport_4.MaxLength = 15;
			_txtAirport_4.Name = "_txtAirport_4";
			_txtAirport_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_4.Size = new System.Drawing.Size(100, 22);
			_txtAirport_4.TabIndex = 96;
			_txtAirport_4.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_4.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// lblLatitudeGPS
			// 
			lblLatitudeGPS.AllowDrop = true;
			lblLatitudeGPS.BackColor = System.Drawing.SystemColors.Control;
			lblLatitudeGPS.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblLatitudeGPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLatitudeGPS.ForeColor = System.Drawing.Color.Blue;
			lblLatitudeGPS.Location = new System.Drawing.Point(278, 138);
			lblLatitudeGPS.MinimumSize = new System.Drawing.Size(23, 13);
			lblLatitudeGPS.Name = "lblLatitudeGPS";
			lblLatitudeGPS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLatitudeGPS.Size = new System.Drawing.Size(23, 13);
			lblLatitudeGPS.TabIndex = 258;
			lblLatitudeGPS.Text = "GPS";
			lblLatitudeGPS.Click += new System.EventHandler(lblLatitudeGPS_Click);
			// 
			// _lblAirport_24
			// 
			_lblAirport_24.AllowDrop = true;
			_lblAirport_24.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_24.ForeColor = System.Drawing.Color.Blue;
			_lblAirport_24.Location = new System.Drawing.Point(304, 138);
			_lblAirport_24.MinimumSize = new System.Drawing.Size(32, 16);
			_lblAirport_24.Name = "_lblAirport_24";
			_lblAirport_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_24.Size = new System.Drawing.Size(32, 16);
			_lblAirport_24.TabIndex = 257;
			_lblAirport_24.Text = "Clear";
			_lblAirport_24.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblAirport_24.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_19
			// 
			_lblAirport_19.AllowDrop = true;
			_lblAirport_19.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_19.ForeColor = System.Drawing.Color.Blue;
			_lblAirport_19.Location = new System.Drawing.Point(131, 44);
			_lblAirport_19.MinimumSize = new System.Drawing.Size(40, 16);
			_lblAirport_19.Name = "_lblAirport_19";
			_lblAirport_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_19.Size = new System.Drawing.Size(40, 16);
			_lblAirport_19.TabIndex = 111;
			_lblAirport_19.Text = "D&ecimal";
			_lblAirport_19.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_8
			// 
			_lblAirport_8.AllowDrop = true;
			_lblAirport_8.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_8.Location = new System.Drawing.Point(131, 138);
			_lblAirport_8.MinimumSize = new System.Drawing.Size(43, 16);
			_lblAirport_8.Name = "_lblAirport_8";
			_lblAirport_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_8.Size = new System.Drawing.Size(43, 16);
			_lblAirport_8.TabIndex = 247;
			_lblAirport_8.Text = "Seconds";
			_lblAirport_8.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_7
			// 
			_lblAirport_7.AllowDrop = true;
			_lblAirport_7.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_7.Location = new System.Drawing.Point(131, 114);
			_lblAirport_7.MinimumSize = new System.Drawing.Size(43, 16);
			_lblAirport_7.Name = "_lblAirport_7";
			_lblAirport_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_7.Size = new System.Drawing.Size(43, 16);
			_lblAirport_7.TabIndex = 246;
			_lblAirport_7.Text = "Minutes";
			_lblAirport_7.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_6
			// 
			_lblAirport_6.AllowDrop = true;
			_lblAirport_6.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_6.Location = new System.Drawing.Point(131, 90);
			_lblAirport_6.MinimumSize = new System.Drawing.Size(43, 16);
			_lblAirport_6.Name = "_lblAirport_6";
			_lblAirport_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_6.Size = new System.Drawing.Size(43, 16);
			_lblAirport_6.TabIndex = 245;
			_lblAirport_6.Text = "Degrees";
			_lblAirport_6.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_5
			// 
			_lblAirport_5.AllowDrop = true;
			_lblAirport_5.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_5.Location = new System.Drawing.Point(131, 66);
			_lblAirport_5.MinimumSize = new System.Drawing.Size(43, 16);
			_lblAirport_5.Name = "_lblAirport_5";
			_lblAirport_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_5.Size = new System.Drawing.Size(43, 16);
			_lblAirport_5.TabIndex = 244;
			_lblAirport_5.Text = "Direction";
			_lblAirport_5.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_4
			// 
			_lblAirport_4.AllowDrop = true;
			_lblAirport_4.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_4.ForeColor = System.Drawing.Color.Blue;
			_lblAirport_4.Location = new System.Drawing.Point(131, 18);
			_lblAirport_4.MinimumSize = new System.Drawing.Size(31, 16);
			_lblAirport_4.Name = "_lblAirport_4";
			_lblAirport_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_4.Size = new System.Drawing.Size(31, 16);
			_lblAirport_4.TabIndex = 243;
			_lblAirport_4.Text = "Full";
			_lblAirport_4.Click += new System.EventHandler(lblAirport_Click);
			// 
			// cmd_Airport_Delete
			// 
			cmd_Airport_Delete.AllowDrop = true;
			cmd_Airport_Delete.BackColor = System.Drawing.SystemColors.Control;
			cmd_Airport_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Airport_Delete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Airport_Delete.Location = new System.Drawing.Point(260, 13);
			cmd_Airport_Delete.Name = "cmd_Airport_Delete";
			cmd_Airport_Delete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Airport_Delete.Size = new System.Drawing.Size(57, 25);
			cmd_Airport_Delete.TabIndex = 84;
			cmd_Airport_Delete.Text = "&Delete";
			cmd_Airport_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Airport_Delete.UseVisualStyleBackColor = false;
			cmd_Airport_Delete.Click += new System.EventHandler(cmd_Airport_Delete_Click);
			// 
			// cmd_Airport_Cancel
			// 
			cmd_Airport_Cancel.AllowDrop = true;
			cmd_Airport_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Airport_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Airport_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Airport_Cancel.Location = new System.Drawing.Point(193, 13);
			cmd_Airport_Cancel.Name = "cmd_Airport_Cancel";
			cmd_Airport_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Airport_Cancel.Size = new System.Drawing.Size(57, 25);
			cmd_Airport_Cancel.TabIndex = 83;
			cmd_Airport_Cancel.Text = "&Cancel";
			cmd_Airport_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Airport_Cancel.UseVisualStyleBackColor = false;
			cmd_Airport_Cancel.Click += new System.EventHandler(cmd_Airport_Cancel_Click);
			// 
			// cmd_Airport_Save
			// 
			cmd_Airport_Save.AllowDrop = true;
			cmd_Airport_Save.BackColor = System.Drawing.SystemColors.Control;
			cmd_Airport_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Airport_Save.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Airport_Save.Location = new System.Drawing.Point(126, 13);
			cmd_Airport_Save.Name = "cmd_Airport_Save";
			cmd_Airport_Save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Airport_Save.Size = new System.Drawing.Size(57, 25);
			cmd_Airport_Save.TabIndex = 82;
			cmd_Airport_Save.Text = "&Save";
			cmd_Airport_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Airport_Save.UseVisualStyleBackColor = false;
			cmd_Airport_Save.Click += new System.EventHandler(cmd_Airport_Save_Click);
			// 
			// frmAirport
			// 
			frmAirport.AllowDrop = true;
			frmAirport.BackColor = System.Drawing.SystemColors.Control;
			frmAirport.Controls.Add(_txtAirport_19);
			frmAirport.Controls.Add(_txtAirport_18);
			frmAirport.Controls.Add(_txtAirport_15);
			frmAirport.Controls.Add(_txtAirport_14);
			frmAirport.Controls.Add(chk_aport_active_flag);
			frmAirport.Controls.Add(_txtAirport_3);
			frmAirport.Controls.Add(_txtAirport_2);
			frmAirport.Controls.Add(_txtAirport_1);
			frmAirport.Controls.Add(_txtAirport_0);
			frmAirport.Controls.Add(cbo_aport_state);
			frmAirport.Controls.Add(cbo_aport_country);
			frmAirport.Controls.Add(_lblAirport_20);
			frmAirport.Controls.Add(_lblAirport_13);
			frmAirport.Controls.Add(_lblAirport_12);
			frmAirport.Controls.Add(_lblAirport_11);
			frmAirport.Controls.Add(_lblAirport_9);
			frmAirport.Controls.Add(_lblAirport_26);
			frmAirport.Controls.Add(_lblAirport_23);
			frmAirport.Controls.Add(_lblAirport_22);
			frmAirport.Controls.Add(_lblAirport_18);
			frmAirport.Controls.Add(_lblAirport_21);
			frmAirport.Controls.Add(_lblAirport_17);
			frmAirport.Controls.Add(_lblAirport_16);
			frmAirport.Controls.Add(_lblAirport_15);
			frmAirport.Controls.Add(_lblAirport_14);
			frmAirport.Controls.Add(lbl_aircraft_count);
			frmAirport.Controls.Add(_lblAirport_3);
			frmAirport.Controls.Add(_lblAirport_2);
			frmAirport.Controls.Add(_lblAirport_1);
			frmAirport.Controls.Add(_lblAirport_0);
			frmAirport.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmAirport.Enabled = true;
			frmAirport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmAirport.ForeColor = System.Drawing.SystemColors.ControlText;
			frmAirport.Location = new System.Drawing.Point(12, 42);
			frmAirport.Name = "frmAirport";
			frmAirport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmAirport.Size = new System.Drawing.Size(346, 220);
			frmAirport.TabIndex = 238;
			frmAirport.Text = "Airport";
			frmAirport.Visible = true;
			// 
			// _txtAirport_19
			// 
			_txtAirport_19.AcceptsReturn = true;
			_txtAirport_19.AllowDrop = true;
			_txtAirport_19.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_19.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_19.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_19.Location = new System.Drawing.Point(176, 14);
			_txtAirport_19.MaxLength = 8;
			_txtAirport_19.Name = "_txtAirport_19";
			_txtAirport_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_19.Size = new System.Drawing.Size(77, 22);
			_txtAirport_19.TabIndex = 85;
			_txtAirport_19.Text = "0";
			_txtAirport_19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtAirport_19.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_19.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_18
			// 
			_txtAirport_18.AcceptsReturn = true;
			_txtAirport_18.AllowDrop = true;
			_txtAirport_18.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_18.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_18.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_18.Location = new System.Drawing.Point(284, 66);
			_txtAirport_18.MaxLength = 4;
			_txtAirport_18.Name = "_txtAirport_18";
			_txtAirport_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_18.Size = new System.Drawing.Size(49, 22);
			_txtAirport_18.TabIndex = 89;
			_txtAirport_18.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_18.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_15
			// 
			_txtAirport_15.AcceptsReturn = true;
			_txtAirport_15.AllowDrop = true;
			_txtAirport_15.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_15.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_15.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_15.Location = new System.Drawing.Point(200, 186);
			_txtAirport_15.MaxLength = 10;
			_txtAirport_15.Name = "_txtAirport_15";
			_txtAirport_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_15.Size = new System.Drawing.Size(56, 22);
			_txtAirport_15.TabIndex = 95;
			_txtAirport_15.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_15.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_14
			// 
			_txtAirport_14.AcceptsReturn = true;
			_txtAirport_14.AllowDrop = true;
			_txtAirport_14.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_14.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_14.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_14.Location = new System.Drawing.Point(117, 186);
			_txtAirport_14.MaxLength = 8;
			_txtAirport_14.Name = "_txtAirport_14";
			_txtAirport_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_14.Size = new System.Drawing.Size(52, 22);
			_txtAirport_14.TabIndex = 94;
			_txtAirport_14.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_14.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// chk_aport_active_flag
			// 
			chk_aport_active_flag.AllowDrop = true;
			chk_aport_active_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_aport_active_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_aport_active_flag.CausesValidation = true;
			chk_aport_active_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_aport_active_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_aport_active_flag.Enabled = true;
			chk_aport_active_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_aport_active_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_aport_active_flag.Location = new System.Drawing.Point(10, 165);
			chk_aport_active_flag.Name = "chk_aport_active_flag";
			chk_aport_active_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_aport_active_flag.Size = new System.Drawing.Size(100, 21);
			chk_aport_active_flag.TabIndex = 93;
			chk_aport_active_flag.TabStop = true;
			chk_aport_active_flag.Text = "Airport is Active?";
			chk_aport_active_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_aport_active_flag.Visible = true;
			// 
			// _txtAirport_3
			// 
			_txtAirport_3.AcceptsReturn = true;
			_txtAirport_3.AllowDrop = true;
			_txtAirport_3.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_3.Location = new System.Drawing.Point(72, 90);
			_txtAirport_3.MaxLength = 50;
			_txtAirport_3.Name = "_txtAirport_3";
			_txtAirport_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_3.Size = new System.Drawing.Size(157, 22);
			_txtAirport_3.TabIndex = 90;
			_txtAirport_3.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_3.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_2
			// 
			_txtAirport_2.AcceptsReturn = true;
			_txtAirport_2.AllowDrop = true;
			_txtAirport_2.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_2.Location = new System.Drawing.Point(180, 66);
			_txtAirport_2.MaxLength = 4;
			_txtAirport_2.Name = "_txtAirport_2";
			_txtAirport_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_2.Size = new System.Drawing.Size(49, 22);
			_txtAirport_2.TabIndex = 88;
			_txtAirport_2.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_2.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_1
			// 
			_txtAirport_1.AcceptsReturn = true;
			_txtAirport_1.AllowDrop = true;
			_txtAirport_1.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_1.Location = new System.Drawing.Point(72, 66);
			_txtAirport_1.MaxLength = 3;
			_txtAirport_1.Name = "_txtAirport_1";
			_txtAirport_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_1.Size = new System.Drawing.Size(40, 22);
			_txtAirport_1.TabIndex = 87;
			_txtAirport_1.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_1.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// _txtAirport_0
			// 
			_txtAirport_0.AcceptsReturn = true;
			_txtAirport_0.AllowDrop = true;
			_txtAirport_0.BackColor = System.Drawing.SystemColors.Window;
			_txtAirport_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtAirport_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtAirport_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtAirport_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtAirport_0.Location = new System.Drawing.Point(12, 39);
			_txtAirport_0.MaxLength = 100;
			_txtAirport_0.Name = "_txtAirport_0";
			_txtAirport_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtAirport_0.Size = new System.Drawing.Size(298, 22);
			_txtAirport_0.TabIndex = 86;
			_txtAirport_0.Leave += new System.EventHandler(txtAirport_Leave);
			_txtAirport_0.TextChanged += new System.EventHandler(txtAirport_TextChanged);
			// 
			// cbo_aport_state
			// 
			cbo_aport_state.AllowDrop = true;
			cbo_aport_state.BackColor = System.Drawing.SystemColors.Window;
			cbo_aport_state.CausesValidation = true;
			cbo_aport_state.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_aport_state.Enabled = true;
			cbo_aport_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_aport_state.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_aport_state.IntegralHeight = true;
			cbo_aport_state.Location = new System.Drawing.Point(72, 114);
			cbo_aport_state.Name = "cbo_aport_state";
			cbo_aport_state.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_aport_state.Size = new System.Drawing.Size(193, 21);
			cbo_aport_state.Sorted = false;
			cbo_aport_state.TabIndex = 91;
			cbo_aport_state.TabStop = true;
			cbo_aport_state.Visible = true;
			cbo_aport_state.SelectionChangeCommitted += new System.EventHandler(cbo_aport_state_SelectionChangeCommitted);
			// 
			// cbo_aport_country
			// 
			cbo_aport_country.AllowDrop = true;
			cbo_aport_country.BackColor = System.Drawing.SystemColors.Window;
			cbo_aport_country.CausesValidation = true;
			cbo_aport_country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_aport_country.Enabled = true;
			cbo_aport_country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_aport_country.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_aport_country.IntegralHeight = true;
			cbo_aport_country.Location = new System.Drawing.Point(72, 138);
			cbo_aport_country.Name = "cbo_aport_country";
			cbo_aport_country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_aport_country.Size = new System.Drawing.Size(193, 21);
			cbo_aport_country.Sorted = false;
			cbo_aport_country.TabIndex = 92;
			cbo_aport_country.TabStop = true;
			cbo_aport_country.Visible = true;
			cbo_aport_country.SelectionChangeCommitted += new System.EventHandler(cbo_aport_country_SelectionChangeCommitted);
			// 
			// _lblAirport_20
			// 
			_lblAirport_20.AllowDrop = true;
			_lblAirport_20.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_20.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_20.Location = new System.Drawing.Point(132, 18);
			_lblAirport_20.MinimumSize = new System.Drawing.Size(39, 16);
			_lblAirport_20.Name = "_lblAirport_20";
			_lblAirport_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_20.Size = new System.Drawing.Size(39, 16);
			_lblAirport_20.TabIndex = 416;
			_lblAirport_20.Text = "CompId";
			_lblAirport_20.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_13
			// 
			_lblAirport_13.AllowDrop = true;
			_lblAirport_13.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_13.ForeColor = System.Drawing.Color.Blue;
			_lblAirport_13.Location = new System.Drawing.Point(274, 192);
			_lblAirport_13.MinimumSize = new System.Drawing.Size(59, 16);
			_lblAirport_13.Name = "_lblAirport_13";
			_lblAirport_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_13.Size = new System.Drawing.Size(59, 16);
			_lblAirport_13.TabIndex = 285;
			_lblAirport_13.Text = "Airport IQ";
			_lblAirport_13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblAirport_13.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_12
			// 
			_lblAirport_12.AllowDrop = true;
			_lblAirport_12.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_12.Location = new System.Drawing.Point(12, 140);
			_lblAirport_12.MinimumSize = new System.Drawing.Size(51, 16);
			_lblAirport_12.Name = "_lblAirport_12";
			_lblAirport_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_12.Size = new System.Drawing.Size(51, 16);
			_lblAirport_12.TabIndex = 284;
			_lblAirport_12.Text = "Country";
			_lblAirport_12.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_11
			// 
			_lblAirport_11.AllowDrop = true;
			_lblAirport_11.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_11.Location = new System.Drawing.Point(12, 116);
			_lblAirport_11.MinimumSize = new System.Drawing.Size(51, 16);
			_lblAirport_11.Name = "_lblAirport_11";
			_lblAirport_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_11.Size = new System.Drawing.Size(51, 16);
			_lblAirport_11.TabIndex = 283;
			_lblAirport_11.Text = "State";
			_lblAirport_11.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_9
			// 
			_lblAirport_9.AllowDrop = true;
			_lblAirport_9.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_9.ForeColor = System.Drawing.Color.Blue;
			_lblAirport_9.Location = new System.Drawing.Point(274, 172);
			_lblAirport_9.MinimumSize = new System.Drawing.Size(59, 16);
			_lblAirport_9.Name = "_lblAirport_9";
			_lblAirport_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_9.Size = new System.Drawing.Size(59, 16);
			_lblAirport_9.TabIndex = 260;
			_lblAirport_9.Text = "FAA Id";
			_lblAirport_9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblAirport_9.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_26
			// 
			_lblAirport_26.AllowDrop = true;
			_lblAirport_26.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_26.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_26.Location = new System.Drawing.Point(242, 69);
			_lblAirport_26.MinimumSize = new System.Drawing.Size(35, 16);
			_lblAirport_26.Name = "_lblAirport_26";
			_lblAirport_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_26.Size = new System.Drawing.Size(35, 16);
			_lblAirport_26.TabIndex = 259;
			_lblAirport_26.Text = "&FAA ID";
			_lblAirport_26.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_23
			// 
			_lblAirport_23.AllowDrop = true;
			_lblAirport_23.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_23.ForeColor = System.Drawing.Color.Blue;
			_lblAirport_23.Location = new System.Drawing.Point(274, 152);
			_lblAirport_23.MinimumSize = new System.Drawing.Size(59, 16);
			_lblAirport_23.Name = "_lblAirport_23";
			_lblAirport_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_23.Size = new System.Drawing.Size(59, 16);
			_lblAirport_23.TabIndex = 256;
			_lblAirport_23.Text = "Great Circle";
			_lblAirport_23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblAirport_23.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_22
			// 
			_lblAirport_22.AllowDrop = true;
			_lblAirport_22.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_22.ForeColor = System.Drawing.Color.Blue;
			_lblAirport_22.Location = new System.Drawing.Point(274, 131);
			_lblAirport_22.MinimumSize = new System.Drawing.Size(59, 16);
			_lblAirport_22.Name = "_lblAirport_22";
			_lblAirport_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_22.Size = new System.Drawing.Size(59, 16);
			_lblAirport_22.TabIndex = 255;
			_lblAirport_22.Text = "Airport Nav";
			_lblAirport_22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblAirport_22.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_18
			// 
			_lblAirport_18.AllowDrop = true;
			_lblAirport_18.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_18.Location = new System.Drawing.Point(86, 19);
			_lblAirport_18.MinimumSize = new System.Drawing.Size(49, 16);
			_lblAirport_18.Name = "_lblAirport_18";
			_lblAirport_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_18.Size = new System.Drawing.Size(49, 16);
			_lblAirport_18.TabIndex = 254;
			_lblAirport_18.Text = "0";
			_lblAirport_18.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_21
			// 
			_lblAirport_21.AllowDrop = true;
			_lblAirport_21.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_21.ForeColor = System.Drawing.Color.Blue;
			_lblAirport_21.Location = new System.Drawing.Point(274, 113);
			_lblAirport_21.MinimumSize = new System.Drawing.Size(59, 16);
			_lblAirport_21.Name = "_lblAirport_21";
			_lblAirport_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_21.Size = new System.Drawing.Size(59, 16);
			_lblAirport_21.TabIndex = 253;
			_lblAirport_21.Text = "Acukwik";
			_lblAirport_21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblAirport_21.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_17
			// 
			_lblAirport_17.AllowDrop = true;
			_lblAirport_17.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_17.ForeColor = System.Drawing.Color.Blue;
			_lblAirport_17.Location = new System.Drawing.Point(274, 95);
			_lblAirport_17.MinimumSize = new System.Drawing.Size(59, 16);
			_lblAirport_17.Name = "_lblAirport_17";
			_lblAirport_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_17.Size = new System.Drawing.Size(59, 16);
			_lblAirport_17.TabIndex = 250;
			_lblAirport_17.Text = "AirNav";
			_lblAirport_17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblAirport_17.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_16
			// 
			_lblAirport_16.AllowDrop = true;
			_lblAirport_16.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_16.ForeColor = System.Drawing.Color.Blue;
			_lblAirport_16.Location = new System.Drawing.Point(267, 18);
			_lblAirport_16.MinimumSize = new System.Drawing.Size(69, 16);
			_lblAirport_16.Name = "_lblAirport_16";
			_lblAirport_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_16.Size = new System.Drawing.Size(69, 16);
			_lblAirport_16.TabIndex = 249;
			_lblAirport_16.Text = "Google Maps";
			_lblAirport_16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblAirport_16.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_15
			// 
			_lblAirport_15.AllowDrop = true;
			_lblAirport_15.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_15.Location = new System.Drawing.Point(173, 189);
			_lblAirport_15.MinimumSize = new System.Drawing.Size(21, 16);
			_lblAirport_15.Name = "_lblAirport_15";
			_lblAirport_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_15.Size = new System.Drawing.Size(21, 16);
			_lblAirport_15.TabIndex = 248;
			_lblAirport_15.Text = "Unit";
			_lblAirport_15.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_14
			// 
			_lblAirport_14.AllowDrop = true;
			_lblAirport_14.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_14.Location = new System.Drawing.Point(12, 189);
			_lblAirport_14.MinimumSize = new System.Drawing.Size(99, 16);
			_lblAirport_14.Name = "_lblAirport_14";
			_lblAirport_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_14.Size = new System.Drawing.Size(99, 16);
			_lblAirport_14.TabIndex = 110;
			_lblAirport_14.Text = "Ma&x Runway Length";
			_lblAirport_14.Click += new System.EventHandler(lblAirport_Click);
			// 
			// lbl_aircraft_count
			// 
			lbl_aircraft_count.AllowDrop = true;
			lbl_aircraft_count.BackColor = System.Drawing.SystemColors.Control;
			lbl_aircraft_count.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_aircraft_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_aircraft_count.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_aircraft_count.Location = new System.Drawing.Point(125, 168);
			lbl_aircraft_count.MinimumSize = new System.Drawing.Size(136, 15);
			lbl_aircraft_count.Name = "lbl_aircraft_count";
			lbl_aircraft_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_aircraft_count.Size = new System.Drawing.Size(136, 15);
			lbl_aircraft_count.TabIndex = 241;
			lbl_aircraft_count.Text = "count";
			// 
			// _lblAirport_3
			// 
			_lblAirport_3.AllowDrop = true;
			_lblAirport_3.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_3.Location = new System.Drawing.Point(12, 93);
			_lblAirport_3.MinimumSize = new System.Drawing.Size(51, 16);
			_lblAirport_3.Name = "_lblAirport_3";
			_lblAirport_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_3.Size = new System.Drawing.Size(51, 16);
			_lblAirport_3.TabIndex = 240;
			_lblAirport_3.Text = "City";
			_lblAirport_3.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_2
			// 
			_lblAirport_2.AllowDrop = true;
			_lblAirport_2.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_2.Location = new System.Drawing.Point(122, 69);
			_lblAirport_2.MinimumSize = new System.Drawing.Size(53, 16);
			_lblAirport_2.Name = "_lblAirport_2";
			_lblAirport_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_2.Size = new System.Drawing.Size(53, 16);
			_lblAirport_2.TabIndex = 109;
			_lblAirport_2.Text = "ICA&O Code";
			_lblAirport_2.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_1
			// 
			_lblAirport_1.AllowDrop = true;
			_lblAirport_1.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblAirport_1.Location = new System.Drawing.Point(12, 69);
			_lblAirport_1.MinimumSize = new System.Drawing.Size(55, 16);
			_lblAirport_1.Name = "_lblAirport_1";
			_lblAirport_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_1.Size = new System.Drawing.Size(55, 16);
			_lblAirport_1.TabIndex = 108;
			_lblAirport_1.Text = "&IATA Code";
			_lblAirport_1.Click += new System.EventHandler(lblAirport_Click);
			// 
			// _lblAirport_0
			// 
			_lblAirport_0.AllowDrop = true;
			_lblAirport_0.BackColor = System.Drawing.SystemColors.Control;
			_lblAirport_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblAirport_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblAirport_0.ForeColor = System.Drawing.Color.Blue;
			_lblAirport_0.Location = new System.Drawing.Point(12, 18);
			_lblAirport_0.MinimumSize = new System.Drawing.Size(67, 16);
			_lblAirport_0.Name = "_lblAirport_0";
			_lblAirport_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblAirport_0.Size = new System.Drawing.Size(67, 16);
			_lblAirport_0.TabIndex = 239;
			_lblAirport_0.Text = "Airport Name";
			_lblAirport_0.Click += new System.EventHandler(lblAirport_Click);
			// 
			// SSPanel3
			// 
			SSPanel3.AllowDrop = true;
			SSPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel3.Controls.Add(txtGlobal);
			SSPanel3.Controls.Add(cbo_Airport_Index);
			SSPanel3.Controls.Add(cbo_faaid_index);
			SSPanel3.Controls.Add(_chkAirportListOptions_8);
			SSPanel3.Controls.Add(_chkAirportListOptions_7);
			SSPanel3.Controls.Add(_chkAirportListOptions_6);
			SSPanel3.Controls.Add(_chkAirportListOptions_4);
			SSPanel3.Controls.Add(_chkAirportListOptions_5);
			SSPanel3.Controls.Add(_chkAirportListOptions_3);
			SSPanel3.Controls.Add(_chkAirportListOptions_2);
			SSPanel3.Controls.Add(_chkAirportListOptions_1);
			SSPanel3.Controls.Add(txt_AirportColor);
			SSPanel3.Controls.Add(cbo_icao_index);
			SSPanel3.Controls.Add(cbo_iata_index);
			SSPanel3.Controls.Add(cmd_Refresh_Airports);
			SSPanel3.Controls.Add(_chkAirportListOptions_0);
			SSPanel3.Controls.Add(grd_Airport);
			SSPanel3.Controls.Add(lblGlobal);
			SSPanel3.Controls.Add(lblICAOIndex);
			SSPanel3.Controls.Add(lblFAAIDIndex);
			SSPanel3.Controls.Add(lbl_Airport_Count);
			SSPanel3.Controls.Add(lblIATAIndex);
			SSPanel3.Controls.Add(lblNameIndex);
			SSPanel3.Controls.Add(_lbl_Airport_Message_1);
			SSPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel3.Location = new System.Drawing.Point(8, 8);
			SSPanel3.Name = "SSPanel3";
			SSPanel3.Size = new System.Drawing.Size(490, 437);
			SSPanel3.TabIndex = 112;
			// 
			// txtGlobal
			// 
			txtGlobal.AcceptsReturn = true;
			txtGlobal.AllowDrop = true;
			txtGlobal.BackColor = System.Drawing.SystemColors.Window;
			txtGlobal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtGlobal.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtGlobal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtGlobal.ForeColor = System.Drawing.SystemColors.WindowText;
			txtGlobal.Location = new System.Drawing.Point(44, 8);
			txtGlobal.MaxLength = 0;
			txtGlobal.Name = "txtGlobal";
			txtGlobal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtGlobal.Size = new System.Drawing.Size(235, 23);
			txtGlobal.TabIndex = 140;
			txtGlobal.KeyUp += new System.Windows.Forms.KeyEventHandler(txtGlobal_KeyUp);
			// 
			// cbo_Airport_Index
			// 
			cbo_Airport_Index.AllowDrop = true;
			cbo_Airport_Index.BackColor = System.Drawing.SystemColors.Window;
			cbo_Airport_Index.CausesValidation = true;
			cbo_Airport_Index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_Airport_Index.Enabled = true;
			cbo_Airport_Index.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Airport_Index.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Airport_Index.IntegralHeight = true;
			cbo_Airport_Index.Location = new System.Drawing.Point(142, 66);
			cbo_Airport_Index.Name = "cbo_Airport_Index";
			cbo_Airport_Index.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Airport_Index.Size = new System.Drawing.Size(60, 21);
			cbo_Airport_Index.Sorted = false;
			cbo_Airport_Index.TabIndex = 144;
			cbo_Airport_Index.TabStop = true;
			cbo_Airport_Index.Text = "Combo1";
			cbo_Airport_Index.Visible = true;
			cbo_Airport_Index.KeyUp += new System.Windows.Forms.KeyEventHandler(cbo_Airport_Index_KeyUp);
			cbo_Airport_Index.Leave += new System.EventHandler(cbo_Airport_Index_Leave);
			// 
			// cbo_faaid_index
			// 
			cbo_faaid_index.AllowDrop = true;
			cbo_faaid_index.BackColor = System.Drawing.SystemColors.Window;
			cbo_faaid_index.CausesValidation = true;
			cbo_faaid_index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_faaid_index.Enabled = true;
			cbo_faaid_index.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_faaid_index.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_faaid_index.IntegralHeight = true;
			cbo_faaid_index.Location = new System.Drawing.Point(142, 38);
			cbo_faaid_index.Name = "cbo_faaid_index";
			cbo_faaid_index.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_faaid_index.Size = new System.Drawing.Size(65, 21);
			cbo_faaid_index.Sorted = false;
			cbo_faaid_index.TabIndex = 142;
			cbo_faaid_index.TabStop = true;
			cbo_faaid_index.Text = "Combo1";
			cbo_faaid_index.Visible = true;
			cbo_faaid_index.KeyUp += new System.Windows.Forms.KeyEventHandler(cbo_faaid_index_KeyUp);
			cbo_faaid_index.Leave += new System.EventHandler(cbo_faaid_index_Leave);
			// 
			// _chkAirportListOptions_8
			// 
			_chkAirportListOptions_8.AllowDrop = true;
			_chkAirportListOptions_8.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkAirportListOptions_8.BackColor = System.Drawing.SystemColors.Control;
			_chkAirportListOptions_8.CausesValidation = true;
			_chkAirportListOptions_8.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_8.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkAirportListOptions_8.Enabled = true;
			_chkAirportListOptions_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkAirportListOptions_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkAirportListOptions_8.Location = new System.Drawing.Point(402, 70);
			_chkAirportListOptions_8.Name = "_chkAirportListOptions_8";
			_chkAirportListOptions_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkAirportListOptions_8.Size = new System.Drawing.Size(80, 20);
			_chkAirportListOptions_8.TabIndex = 153;
			_chkAirportListOptions_8.TabStop = true;
			_chkAirportListOptions_8.Text = "FAA Count";
			_chkAirportListOptions_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_8.Visible = true;
			_chkAirportListOptions_8.CheckStateChanged += new System.EventHandler(chkAirportListOptions_CheckStateChanged);
			// 
			// _chkAirportListOptions_7
			// 
			_chkAirportListOptions_7.AllowDrop = true;
			_chkAirportListOptions_7.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkAirportListOptions_7.BackColor = System.Drawing.SystemColors.Control;
			_chkAirportListOptions_7.CausesValidation = true;
			_chkAirportListOptions_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_7.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkAirportListOptions_7.Enabled = true;
			_chkAirportListOptions_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkAirportListOptions_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkAirportListOptions_7.Location = new System.Drawing.Point(312, 70);
			_chkAirportListOptions_7.Name = "_chkAirportListOptions_7";
			_chkAirportListOptions_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkAirportListOptions_7.Size = new System.Drawing.Size(87, 20);
			_chkAirportListOptions_7.TabIndex = 150;
			_chkAirportListOptions_7.TabStop = true;
			_chkAirportListOptions_7.Text = "Transmit A/C";
			_chkAirportListOptions_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_7.Visible = true;
			_chkAirportListOptions_7.CheckStateChanged += new System.EventHandler(chkAirportListOptions_CheckStateChanged);
			// 
			// _chkAirportListOptions_6
			// 
			_chkAirportListOptions_6.AllowDrop = true;
			_chkAirportListOptions_6.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkAirportListOptions_6.BackColor = System.Drawing.SystemColors.Control;
			_chkAirportListOptions_6.CausesValidation = true;
			_chkAirportListOptions_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_6.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkAirportListOptions_6.Enabled = true;
			_chkAirportListOptions_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkAirportListOptions_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkAirportListOptions_6.Location = new System.Drawing.Point(212, 70);
			_chkAirportListOptions_6.Name = "_chkAirportListOptions_6";
			_chkAirportListOptions_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkAirportListOptions_6.Size = new System.Drawing.Size(87, 20);
			_chkAirportListOptions_6.TabIndex = 147;
			_chkAirportListOptions_6.TabStop = true;
			_chkAirportListOptions_6.Text = "w/Flight Data";
			_chkAirportListOptions_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_6.Visible = true;
			_chkAirportListOptions_6.CheckStateChanged += new System.EventHandler(chkAirportListOptions_CheckStateChanged);
			// 
			// _chkAirportListOptions_4
			// 
			_chkAirportListOptions_4.AllowDrop = true;
			_chkAirportListOptions_4.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkAirportListOptions_4.BackColor = System.Drawing.SystemColors.Control;
			_chkAirportListOptions_4.CausesValidation = true;
			_chkAirportListOptions_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkAirportListOptions_4.Enabled = true;
			_chkAirportListOptions_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkAirportListOptions_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkAirportListOptions_4.Location = new System.Drawing.Point(402, 32);
			_chkAirportListOptions_4.Name = "_chkAirportListOptions_4";
			_chkAirportListOptions_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkAirportListOptions_4.Size = new System.Drawing.Size(78, 22);
			_chkAirportListOptions_4.TabIndex = 151;
			_chkAirportListOptions_4.TabStop = true;
			_chkAirportListOptions_4.Text = "w/Runway";
			_chkAirportListOptions_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_4.Visible = true;
			_chkAirportListOptions_4.CheckStateChanged += new System.EventHandler(chkAirportListOptions_CheckStateChanged);
			// 
			// _chkAirportListOptions_5
			// 
			_chkAirportListOptions_5.AllowDrop = true;
			_chkAirportListOptions_5.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkAirportListOptions_5.BackColor = System.Drawing.SystemColors.Control;
			_chkAirportListOptions_5.CausesValidation = true;
			_chkAirportListOptions_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkAirportListOptions_5.Enabled = true;
			_chkAirportListOptions_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkAirportListOptions_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkAirportListOptions_5.Location = new System.Drawing.Point(402, 51);
			_chkAirportListOptions_5.Name = "_chkAirportListOptions_5";
			_chkAirportListOptions_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkAirportListOptions_5.Size = new System.Drawing.Size(80, 20);
			_chkAirportListOptions_5.TabIndex = 152;
			_chkAirportListOptions_5.TabStop = true;
			_chkAirportListOptions_5.Text = "wo/Runway";
			_chkAirportListOptions_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_5.Visible = true;
			_chkAirportListOptions_5.CheckStateChanged += new System.EventHandler(chkAirportListOptions_CheckStateChanged);
			// 
			// _chkAirportListOptions_3
			// 
			_chkAirportListOptions_3.AllowDrop = true;
			_chkAirportListOptions_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkAirportListOptions_3.BackColor = System.Drawing.SystemColors.Control;
			_chkAirportListOptions_3.CausesValidation = true;
			_chkAirportListOptions_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkAirportListOptions_3.Enabled = true;
			_chkAirportListOptions_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkAirportListOptions_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkAirportListOptions_3.Location = new System.Drawing.Point(312, 50);
			_chkAirportListOptions_3.Name = "_chkAirportListOptions_3";
			_chkAirportListOptions_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkAirportListOptions_3.Size = new System.Drawing.Size(68, 20);
			_chkAirportListOptions_3.TabIndex = 149;
			_chkAirportListOptions_3.TabStop = true;
			_chkAirportListOptions_3.Text = "wo/Coord";
			_chkAirportListOptions_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_3.Visible = true;
			_chkAirportListOptions_3.CheckStateChanged += new System.EventHandler(chkAirportListOptions_CheckStateChanged);
			// 
			// _chkAirportListOptions_2
			// 
			_chkAirportListOptions_2.AllowDrop = true;
			_chkAirportListOptions_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkAirportListOptions_2.BackColor = System.Drawing.SystemColors.Control;
			_chkAirportListOptions_2.CausesValidation = true;
			_chkAirportListOptions_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkAirportListOptions_2.Enabled = true;
			_chkAirportListOptions_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkAirportListOptions_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkAirportListOptions_2.Location = new System.Drawing.Point(312, 31);
			_chkAirportListOptions_2.Name = "_chkAirportListOptions_2";
			_chkAirportListOptions_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkAirportListOptions_2.Size = new System.Drawing.Size(62, 22);
			_chkAirportListOptions_2.TabIndex = 148;
			_chkAirportListOptions_2.TabStop = true;
			_chkAirportListOptions_2.Text = "w/Coord";
			_chkAirportListOptions_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_2.Visible = true;
			_chkAirportListOptions_2.CheckStateChanged += new System.EventHandler(chkAirportListOptions_CheckStateChanged);
			// 
			// _chkAirportListOptions_1
			// 
			_chkAirportListOptions_1.AllowDrop = true;
			_chkAirportListOptions_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkAirportListOptions_1.BackColor = System.Drawing.SystemColors.Control;
			_chkAirportListOptions_1.CausesValidation = true;
			_chkAirportListOptions_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkAirportListOptions_1.Enabled = true;
			_chkAirportListOptions_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkAirportListOptions_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkAirportListOptions_1.Location = new System.Drawing.Point(212, 50);
			_chkAirportListOptions_1.Name = "_chkAirportListOptions_1";
			_chkAirportListOptions_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkAirportListOptions_1.Size = new System.Drawing.Size(75, 20);
			_chkAirportListOptions_1.TabIndex = 146;
			_chkAirportListOptions_1.TabStop = true;
			_chkAirportListOptions_1.Text = "A/C Counts";
			_chkAirportListOptions_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_1.Visible = true;
			_chkAirportListOptions_1.CheckStateChanged += new System.EventHandler(chkAirportListOptions_CheckStateChanged);
			// 
			// txt_AirportColor
			// 
			txt_AirportColor.AcceptsReturn = true;
			txt_AirportColor.AllowDrop = true;
			txt_AirportColor.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			txt_AirportColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_AirportColor.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_AirportColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_AirportColor.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_AirportColor.Location = new System.Drawing.Point(414, 409);
			txt_AirportColor.MaxLength = 0;
			txt_AirportColor.Name = "txt_AirportColor";
			txt_AirportColor.ReadOnly = true;
			txt_AirportColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_AirportColor.Size = new System.Drawing.Size(65, 19);
			txt_AirportColor.TabIndex = 203;
			txt_AirportColor.TabStop = false;
			txt_AirportColor.Text = "No Aircraft";
			txt_AirportColor.Visible = false;
			// 
			// cbo_icao_index
			// 
			cbo_icao_index.AllowDrop = true;
			cbo_icao_index.BackColor = System.Drawing.SystemColors.Window;
			cbo_icao_index.CausesValidation = true;
			cbo_icao_index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_icao_index.Enabled = true;
			cbo_icao_index.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_icao_index.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_icao_index.IntegralHeight = true;
			cbo_icao_index.Location = new System.Drawing.Point(36, 66);
			cbo_icao_index.Name = "cbo_icao_index";
			cbo_icao_index.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_icao_index.Size = new System.Drawing.Size(65, 21);
			cbo_icao_index.Sorted = false;
			cbo_icao_index.TabIndex = 143;
			cbo_icao_index.TabStop = true;
			cbo_icao_index.Text = "Combo1";
			cbo_icao_index.Visible = true;
			cbo_icao_index.KeyUp += new System.Windows.Forms.KeyEventHandler(cbo_icao_index_KeyUp);
			cbo_icao_index.Leave += new System.EventHandler(cbo_icao_index_Leave);
			// 
			// cbo_iata_index
			// 
			cbo_iata_index.AllowDrop = true;
			cbo_iata_index.BackColor = System.Drawing.SystemColors.Window;
			cbo_iata_index.CausesValidation = true;
			cbo_iata_index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_iata_index.Enabled = true;
			cbo_iata_index.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_iata_index.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_iata_index.IntegralHeight = true;
			cbo_iata_index.Location = new System.Drawing.Point(36, 38);
			cbo_iata_index.Name = "cbo_iata_index";
			cbo_iata_index.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_iata_index.Size = new System.Drawing.Size(65, 21);
			cbo_iata_index.Sorted = false;
			cbo_iata_index.TabIndex = 141;
			cbo_iata_index.TabStop = true;
			cbo_iata_index.Text = "Combo1";
			cbo_iata_index.Visible = true;
			cbo_iata_index.KeyUp += new System.Windows.Forms.KeyEventHandler(cbo_iata_index_KeyUp);
			cbo_iata_index.Leave += new System.EventHandler(cbo_iata_index_Leave);
			// 
			// cmd_Refresh_Airports
			// 
			cmd_Refresh_Airports.AllowDrop = true;
			cmd_Refresh_Airports.BackColor = System.Drawing.SystemColors.Control;
			cmd_Refresh_Airports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Refresh_Airports.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Refresh_Airports.Location = new System.Drawing.Point(366, 406);
			cmd_Refresh_Airports.Name = "cmd_Refresh_Airports";
			cmd_Refresh_Airports.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Refresh_Airports.Size = new System.Drawing.Size(47, 27);
			cmd_Refresh_Airports.TabIndex = 158;
			cmd_Refresh_Airports.Text = "&Refresh";
			cmd_Refresh_Airports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Refresh_Airports.UseVisualStyleBackColor = false;
			cmd_Refresh_Airports.Click += new System.EventHandler(cmd_Refresh_Airports_Click);
			// 
			// _chkAirportListOptions_0
			// 
			_chkAirportListOptions_0.AllowDrop = true;
			_chkAirportListOptions_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkAirportListOptions_0.BackColor = System.Drawing.SystemColors.Control;
			_chkAirportListOptions_0.CausesValidation = true;
			_chkAirportListOptions_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkAirportListOptions_0.Enabled = true;
			_chkAirportListOptions_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkAirportListOptions_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkAirportListOptions_0.Location = new System.Drawing.Point(212, 31);
			_chkAirportListOptions_0.Name = "_chkAirportListOptions_0";
			_chkAirportListOptions_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkAirportListOptions_0.Size = new System.Drawing.Size(75, 20);
			_chkAirportListOptions_0.TabIndex = 145;
			_chkAirportListOptions_0.TabStop = true;
			_chkAirportListOptions_0.Text = "Active Only";
			_chkAirportListOptions_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkAirportListOptions_0.Visible = true;
			_chkAirportListOptions_0.CheckStateChanged += new System.EventHandler(chkAirportListOptions_CheckStateChanged);
			// 
			// grd_Airport
			// 
			grd_Airport.AllowBigSelection = false;
			grd_Airport.AllowDrop = true;
			grd_Airport.AllowUserToAddRows = false;
			grd_Airport.AllowUserToDeleteRows = false;
			grd_Airport.AllowUserToResizeColumns = false;
			grd_Airport.AllowUserToResizeColumns = grd_Airport.ColumnHeadersVisible;
			grd_Airport.AllowUserToResizeRows = false;
			grd_Airport.AllowUserToResizeRows = false;
			grd_Airport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Airport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Airport.ColumnsCount = 2;
			grd_Airport.FixedColumns = 0;
			grd_Airport.FixedRows = 1;
			grd_Airport.Location = new System.Drawing.Point(16, 92);
			grd_Airport.Name = "grd_Airport";
			grd_Airport.ReadOnly = true;
			grd_Airport.RowsCount = 2;
			grd_Airport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Airport.ShowCellToolTips = false;
			grd_Airport.Size = new System.Drawing.Size(465, 310);
			grd_Airport.StandardTab = true;
			grd_Airport.TabIndex = 139;
			grd_Airport.Click += new System.EventHandler(grd_Airport_Click);
			// 
			// lblGlobal
			// 
			lblGlobal.AllowDrop = true;
			lblGlobal.BackColor = System.Drawing.Color.Transparent;
			lblGlobal.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblGlobal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblGlobal.ForeColor = System.Drawing.SystemColors.ControlText;
			lblGlobal.Location = new System.Drawing.Point(8, 12);
			lblGlobal.MinimumSize = new System.Drawing.Size(33, 17);
			lblGlobal.Name = "lblGlobal";
			lblGlobal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblGlobal.Size = new System.Drawing.Size(33, 17);
			lblGlobal.TabIndex = 349;
			lblGlobal.Text = "&Global";
			lblGlobal.Click += new System.EventHandler(lblGlobal_Click);
			// 
			// lblICAOIndex
			// 
			lblICAOIndex.AllowDrop = true;
			lblICAOIndex.BackColor = System.Drawing.Color.Transparent;
			lblICAOIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblICAOIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblICAOIndex.ForeColor = System.Drawing.SystemColors.ControlText;
			lblICAOIndex.Location = new System.Drawing.Point(8, 68);
			lblICAOIndex.MinimumSize = new System.Drawing.Size(25, 17);
			lblICAOIndex.Name = "lblICAOIndex";
			lblICAOIndex.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblICAOIndex.Size = new System.Drawing.Size(25, 17);
			lblICAOIndex.TabIndex = 156;
			lblICAOIndex.Text = "ICA&O";
			lblICAOIndex.Click += new System.EventHandler(lblICAOIndex_Click);
			// 
			// lblFAAIDIndex
			// 
			lblFAAIDIndex.AllowDrop = true;
			lblFAAIDIndex.BackColor = System.Drawing.Color.Transparent;
			lblFAAIDIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFAAIDIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFAAIDIndex.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFAAIDIndex.Location = new System.Drawing.Point(106, 40);
			lblFAAIDIndex.MinimumSize = new System.Drawing.Size(33, 17);
			lblFAAIDIndex.Name = "lblFAAIDIndex";
			lblFAAIDIndex.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFAAIDIndex.Size = new System.Drawing.Size(33, 17);
			lblFAAIDIndex.TabIndex = 155;
			lblFAAIDIndex.Text = "&FAAID";
			lblFAAIDIndex.Click += new System.EventHandler(lblFAAIdIndex_Click);
			// 
			// lbl_Airport_Count
			// 
			lbl_Airport_Count.AllowDrop = true;
			lbl_Airport_Count.BackColor = System.Drawing.SystemColors.Control;
			lbl_Airport_Count.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Airport_Count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Airport_Count.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Airport_Count.Location = new System.Drawing.Point(14, 404);
			lbl_Airport_Count.MinimumSize = new System.Drawing.Size(333, 14);
			lbl_Airport_Count.Name = "lbl_Airport_Count";
			lbl_Airport_Count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Airport_Count.Size = new System.Drawing.Size(333, 14);
			lbl_Airport_Count.TabIndex = 202;
			lbl_Airport_Count.Text = "Count:";
			// 
			// lblIATAIndex
			// 
			lblIATAIndex.AllowDrop = true;
			lblIATAIndex.BackColor = System.Drawing.Color.Transparent;
			lblIATAIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblIATAIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblIATAIndex.ForeColor = System.Drawing.SystemColors.ControlText;
			lblIATAIndex.Location = new System.Drawing.Point(8, 40);
			lblIATAIndex.MinimumSize = new System.Drawing.Size(27, 17);
			lblIATAIndex.Name = "lblIATAIndex";
			lblIATAIndex.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblIATAIndex.Size = new System.Drawing.Size(27, 17);
			lblIATAIndex.TabIndex = 154;
			lblIATAIndex.Text = "&IATA";
			lblIATAIndex.Click += new System.EventHandler(lblIATAIndex_Click);
			// 
			// lblNameIndex
			// 
			lblNameIndex.AllowDrop = true;
			lblNameIndex.BackColor = System.Drawing.Color.Transparent;
			lblNameIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblNameIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblNameIndex.ForeColor = System.Drawing.SystemColors.ControlText;
			lblNameIndex.Location = new System.Drawing.Point(106, 68);
			lblNameIndex.MinimumSize = new System.Drawing.Size(33, 17);
			lblNameIndex.Name = "lblNameIndex";
			lblNameIndex.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblNameIndex.Size = new System.Drawing.Size(33, 17);
			lblNameIndex.TabIndex = 157;
			lblNameIndex.Text = "Airport";
			lblNameIndex.Click += new System.EventHandler(lblNameIndex_Click);
			// 
			// _lbl_Airport_Message_1
			// 
			_lbl_Airport_Message_1.AllowDrop = true;
			_lbl_Airport_Message_1.AutoSize = true;
			_lbl_Airport_Message_1.BackColor = System.Drawing.Color.Transparent;
			_lbl_Airport_Message_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Airport_Message_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Airport_Message_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Airport_Message_1.Location = new System.Drawing.Point(14, 420);
			_lbl_Airport_Message_1.MinimumSize = new System.Drawing.Size(335, 13);
			_lbl_Airport_Message_1.Name = "_lbl_Airport_Message_1";
			_lbl_Airport_Message_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Airport_Message_1.Size = new System.Drawing.Size(335, 13);
			_lbl_Airport_Message_1.TabIndex = 118;
			_lbl_Airport_Message_1.Text = "ICAO";
			// 
			// _tab_Lookup_TabPage13
			// 
			_tab_Lookup_TabPage13.Controls.Add(pnl_Certified_Update_Change);
			_tab_Lookup_TabPage13.Controls.Add(cmd_certified_add);
			_tab_Lookup_TabPage13.Controls.Add(FGRD_Certifed);
			_tab_Lookup_TabPage13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage13.Text = "Certified";
			// 
			// pnl_Certified_Update_Change
			// 
			pnl_Certified_Update_Change.AllowDrop = true;
			pnl_Certified_Update_Change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Certified_Update_Change.Controls.Add(cmd_save_certified);
			pnl_Certified_Update_Change.Controls.Add(cmd_cancel_certified);
			pnl_Certified_Update_Change.Controls.Add(cmd_delete_certified);
			pnl_Certified_Update_Change.Controls.Add(txt_cert_name_cert);
			pnl_Certified_Update_Change.Controls.Add(_Label24_3);
			pnl_Certified_Update_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Certified_Update_Change.Location = new System.Drawing.Point(251, 80);
			pnl_Certified_Update_Change.Name = "pnl_Certified_Update_Change";
			pnl_Certified_Update_Change.Size = new System.Drawing.Size(423, 127);
			pnl_Certified_Update_Change.TabIndex = 113;
			pnl_Certified_Update_Change.Visible = false;
			// 
			// cmd_save_certified
			// 
			cmd_save_certified.AllowDrop = true;
			cmd_save_certified.BackColor = System.Drawing.SystemColors.Control;
			cmd_save_certified.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_save_certified.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_save_certified.Location = new System.Drawing.Point(11, 8);
			cmd_save_certified.Name = "cmd_save_certified";
			cmd_save_certified.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_save_certified.Size = new System.Drawing.Size(57, 25);
			cmd_save_certified.TabIndex = 117;
			cmd_save_certified.Text = "&Save";
			cmd_save_certified.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_save_certified.UseVisualStyleBackColor = false;
			cmd_save_certified.Click += new System.EventHandler(cmd_save_certified_Click);
			// 
			// cmd_cancel_certified
			// 
			cmd_cancel_certified.AllowDrop = true;
			cmd_cancel_certified.BackColor = System.Drawing.SystemColors.Control;
			cmd_cancel_certified.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_cancel_certified.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_cancel_certified.Location = new System.Drawing.Point(90, 8);
			cmd_cancel_certified.Name = "cmd_cancel_certified";
			cmd_cancel_certified.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_cancel_certified.Size = new System.Drawing.Size(57, 25);
			cmd_cancel_certified.TabIndex = 116;
			cmd_cancel_certified.Text = "&Cancel";
			cmd_cancel_certified.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_cancel_certified.UseVisualStyleBackColor = false;
			cmd_cancel_certified.Click += new System.EventHandler(cmd_cancel_certified_Click);
			// 
			// cmd_delete_certified
			// 
			cmd_delete_certified.AllowDrop = true;
			cmd_delete_certified.BackColor = System.Drawing.SystemColors.Control;
			cmd_delete_certified.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_delete_certified.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_delete_certified.Location = new System.Drawing.Point(165, 8);
			cmd_delete_certified.Name = "cmd_delete_certified";
			cmd_delete_certified.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_delete_certified.Size = new System.Drawing.Size(57, 25);
			cmd_delete_certified.TabIndex = 115;
			cmd_delete_certified.Text = "&Delete";
			cmd_delete_certified.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_delete_certified.UseVisualStyleBackColor = false;
			cmd_delete_certified.Click += new System.EventHandler(cmd_delete_certified_Click);
			// 
			// txt_cert_name_cert
			// 
			txt_cert_name_cert.AcceptsReturn = true;
			txt_cert_name_cert.AllowDrop = true;
			txt_cert_name_cert.BackColor = System.Drawing.SystemColors.Window;
			txt_cert_name_cert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_cert_name_cert.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cert_name_cert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cert_name_cert.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cert_name_cert.Location = new System.Drawing.Point(15, 72);
			txt_cert_name_cert.MaxLength = 30;
			txt_cert_name_cert.Name = "txt_cert_name_cert";
			txt_cert_name_cert.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cert_name_cert.Size = new System.Drawing.Size(358, 19);
			txt_cert_name_cert.TabIndex = 114;
			// 
			// _Label24_3
			// 
			_Label24_3.AllowDrop = true;
			_Label24_3.BackColor = System.Drawing.SystemColors.Control;
			_Label24_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_3.Location = new System.Drawing.Point(14, 50);
			_Label24_3.MinimumSize = new System.Drawing.Size(41, 17);
			_Label24_3.Name = "_Label24_3";
			_Label24_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_3.Size = new System.Drawing.Size(41, 17);
			_Label24_3.TabIndex = 292;
			_Label24_3.Text = "Name";
			// 
			// cmd_certified_add
			// 
			cmd_certified_add.AllowDrop = true;
			cmd_certified_add.BackColor = System.Drawing.SystemColors.Control;
			cmd_certified_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_certified_add.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_certified_add.Location = new System.Drawing.Point(253, 42);
			cmd_certified_add.Name = "cmd_certified_add";
			cmd_certified_add.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_certified_add.Size = new System.Drawing.Size(57, 25);
			cmd_certified_add.TabIndex = 195;
			cmd_certified_add.Text = "&Add";
			cmd_certified_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_certified_add.UseVisualStyleBackColor = false;
			cmd_certified_add.Click += new System.EventHandler(cmd_certified_add_Click);
			// 
			// FGRD_Certifed
			// 
			FGRD_Certifed.AllowDrop = true;
			FGRD_Certifed.AllowUserToAddRows = false;
			FGRD_Certifed.AllowUserToDeleteRows = false;
			FGRD_Certifed.AllowUserToResizeColumns = false;
			FGRD_Certifed.AllowUserToResizeColumns = FGRD_Certifed.ColumnHeadersVisible;
			FGRD_Certifed.AllowUserToResizeRows = false;
			FGRD_Certifed.AllowUserToResizeRows = false;
			FGRD_Certifed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FGRD_Certifed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FGRD_Certifed.ColumnsCount = 1;
			FGRD_Certifed.FixedColumns = 0;
			FGRD_Certifed.FixedRows = 1;
			FGRD_Certifed.Location = new System.Drawing.Point(24, 42);
			FGRD_Certifed.Name = "FGRD_Certifed";
			FGRD_Certifed.ReadOnly = true;
			FGRD_Certifed.RowsCount = 2;
			FGRD_Certifed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FGRD_Certifed.ShowCellToolTips = false;
			FGRD_Certifed.Size = new System.Drawing.Size(214, 342);
			FGRD_Certifed.StandardTab = true;
			FGRD_Certifed.TabIndex = 196;
			FGRD_Certifed.Click += new System.EventHandler(FGRD_Certifed_Click);
			// 
			// _tab_Lookup_TabPage14
			// 
			_tab_Lookup_TabPage14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage14.Text = "Airlines";
			// 
			// _tab_Lookup_TabPage15
			// 
			_tab_Lookup_TabPage15.Controls.Add(cmdAddCREG);
			_tab_Lookup_TabPage15.Controls.Add(grdCREG);
			_tab_Lookup_TabPage15.Controls.Add(pnl_CREG);
			_tab_Lookup_TabPage15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage15.Text = "Canadian Registry";
			// 
			// cmdAddCREG
			// 
			cmdAddCREG.AllowDrop = true;
			cmdAddCREG.BackColor = System.Drawing.SystemColors.Control;
			cmdAddCREG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAddCREG.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAddCREG.Location = new System.Drawing.Point(488, 7);
			cmdAddCREG.Name = "cmdAddCREG";
			cmdAddCREG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAddCREG.Size = new System.Drawing.Size(54, 25);
			cmdAddCREG.TabIndex = 205;
			cmdAddCREG.Text = "&Add";
			cmdAddCREG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAddCREG.UseVisualStyleBackColor = false;
			cmdAddCREG.Click += new System.EventHandler(cmdAddCREG_Click);
			// 
			// grdCREG
			// 
			grdCREG.AllowDrop = true;
			grdCREG.AllowUserToAddRows = false;
			grdCREG.AllowUserToDeleteRows = false;
			grdCREG.AllowUserToResizeColumns = false;
			grdCREG.AllowUserToResizeColumns = grdCREG.ColumnHeadersVisible;
			grdCREG.AllowUserToResizeRows = false;
			grdCREG.AllowUserToResizeRows = false;
			grdCREG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdCREG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdCREG.ColumnsCount = 4;
			grdCREG.FixedColumns = 0;
			grdCREG.FixedRows = 1;
			grdCREG.Location = new System.Drawing.Point(15, 23);
			grdCREG.Name = "grdCREG";
			grdCREG.ReadOnly = true;
			grdCREG.RowsCount = 2;
			grdCREG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdCREG.ShowCellToolTips = false;
			grdCREG.Size = new System.Drawing.Size(440, 413);
			grdCREG.StandardTab = true;
			grdCREG.TabIndex = 204;
			grdCREG.Click += new System.EventHandler(grdCREG_Click);
			// 
			// pnl_CREG
			// 
			pnl_CREG.AllowDrop = true;
			pnl_CREG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_CREG.Controls.Add(txt_crm_amod_list);
			pnl_CREG.Controls.Add(txt_crm_id);
			pnl_CREG.Controls.Add(cbo_CREG);
			pnl_CREG.Controls.Add(txt_crm_model);
			pnl_CREG.Controls.Add(cmdSaveCREG);
			pnl_CREG.Controls.Add(cmdCancelCREG);
			pnl_CREG.Controls.Add(cmdDeleteCREG);
			pnl_CREG.Controls.Add(txt_crm_Make);
			pnl_CREG.Controls.Add(_Label40_4);
			pnl_CREG.Controls.Add(_Label40_3);
			pnl_CREG.Controls.Add(_Label40_1);
			pnl_CREG.Controls.Add(_Label40_0);
			pnl_CREG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_CREG.Location = new System.Drawing.Point(479, 38);
			pnl_CREG.Name = "pnl_CREG";
			pnl_CREG.Size = new System.Drawing.Size(361, 286);
			pnl_CREG.TabIndex = 206;
			pnl_CREG.Visible = false;
			// 
			// txt_crm_amod_list
			// 
			txt_crm_amod_list.AcceptsReturn = true;
			txt_crm_amod_list.AllowDrop = true;
			txt_crm_amod_list.BackColor = System.Drawing.SystemColors.Window;
			txt_crm_amod_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_crm_amod_list.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_crm_amod_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_crm_amod_list.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_crm_amod_list.Location = new System.Drawing.Point(73, 132);
			txt_crm_amod_list.MaxLength = 0;
			txt_crm_amod_list.Name = "txt_crm_amod_list";
			txt_crm_amod_list.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_crm_amod_list.Size = new System.Drawing.Size(263, 37);
			txt_crm_amod_list.TabIndex = 218;
			txt_crm_amod_list.TextChanged += new System.EventHandler(txt_crm_amod_list_TextChanged);
			// 
			// txt_crm_id
			// 
			txt_crm_id.AcceptsReturn = true;
			txt_crm_id.AllowDrop = true;
			txt_crm_id.BackColor = System.Drawing.SystemColors.Window;
			txt_crm_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_crm_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_crm_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_crm_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_crm_id.Location = new System.Drawing.Point(256, 15);
			txt_crm_id.MaxLength = 0;
			txt_crm_id.Name = "txt_crm_id";
			txt_crm_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_crm_id.Size = new System.Drawing.Size(15, 19);
			txt_crm_id.TabIndex = 216;
			txt_crm_id.Visible = false;
			// 
			// cbo_CREG
			// 
			cbo_CREG.AllowDrop = true;
			cbo_CREG.BackColor = System.Drawing.SystemColors.Window;
			cbo_CREG.CausesValidation = true;
			cbo_CREG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_CREG.Enabled = true;
			cbo_CREG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_CREG.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_CREG.IntegralHeight = true;
			cbo_CREG.Location = new System.Drawing.Point(15, 236);
			cbo_CREG.Name = "cbo_CREG";
			cbo_CREG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_CREG.Size = new System.Drawing.Size(327, 21);
			cbo_CREG.Sorted = false;
			cbo_CREG.TabIndex = 215;
			cbo_CREG.TabStop = true;
			cbo_CREG.Visible = true;
			cbo_CREG.SelectionChangeCommitted += new System.EventHandler(cbo_CREG_SelectionChangeCommitted);
			// 
			// txt_crm_model
			// 
			txt_crm_model.AcceptsReturn = true;
			txt_crm_model.AllowDrop = true;
			txt_crm_model.BackColor = System.Drawing.SystemColors.Window;
			txt_crm_model.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_crm_model.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_crm_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_crm_model.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_crm_model.Location = new System.Drawing.Point(18, 104);
			txt_crm_model.MaxLength = 0;
			txt_crm_model.Name = "txt_crm_model";
			txt_crm_model.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_crm_model.Size = new System.Drawing.Size(318, 19);
			txt_crm_model.TabIndex = 214;
			// 
			// cmdSaveCREG
			// 
			cmdSaveCREG.AllowDrop = true;
			cmdSaveCREG.BackColor = System.Drawing.SystemColors.Control;
			cmdSaveCREG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSaveCREG.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSaveCREG.Location = new System.Drawing.Point(14, 12);
			cmdSaveCREG.Name = "cmdSaveCREG";
			cmdSaveCREG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSaveCREG.Size = new System.Drawing.Size(57, 25);
			cmdSaveCREG.TabIndex = 210;
			cmdSaveCREG.Text = "&Save";
			cmdSaveCREG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSaveCREG.UseVisualStyleBackColor = false;
			cmdSaveCREG.Click += new System.EventHandler(cmdSaveCREG_Click);
			// 
			// cmdCancelCREG
			// 
			cmdCancelCREG.AllowDrop = true;
			cmdCancelCREG.BackColor = System.Drawing.SystemColors.Control;
			cmdCancelCREG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancelCREG.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancelCREG.Location = new System.Drawing.Point(100, 12);
			cmdCancelCREG.Name = "cmdCancelCREG";
			cmdCancelCREG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancelCREG.Size = new System.Drawing.Size(57, 25);
			cmdCancelCREG.TabIndex = 209;
			cmdCancelCREG.Text = "&Cancel";
			cmdCancelCREG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancelCREG.UseVisualStyleBackColor = false;
			cmdCancelCREG.Click += new System.EventHandler(cmdCancelCREG_Click);
			// 
			// cmdDeleteCREG
			// 
			cmdDeleteCREG.AllowDrop = true;
			cmdDeleteCREG.BackColor = System.Drawing.SystemColors.Control;
			cmdDeleteCREG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDeleteCREG.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDeleteCREG.Location = new System.Drawing.Point(184, 12);
			cmdDeleteCREG.Name = "cmdDeleteCREG";
			cmdDeleteCREG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDeleteCREG.Size = new System.Drawing.Size(57, 25);
			cmdDeleteCREG.TabIndex = 208;
			cmdDeleteCREG.Text = "&Delete";
			cmdDeleteCREG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDeleteCREG.UseVisualStyleBackColor = false;
			cmdDeleteCREG.Click += new System.EventHandler(cmdDeleteCREG_Click);
			// 
			// txt_crm_Make
			// 
			txt_crm_Make.AcceptsReturn = true;
			txt_crm_Make.AllowDrop = true;
			txt_crm_Make.BackColor = System.Drawing.SystemColors.Window;
			txt_crm_Make.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_crm_Make.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_crm_Make.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_crm_Make.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_crm_Make.Location = new System.Drawing.Point(18, 66);
			txt_crm_Make.MaxLength = 30;
			txt_crm_Make.Name = "txt_crm_Make";
			txt_crm_Make.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_crm_Make.Size = new System.Drawing.Size(318, 19);
			txt_crm_Make.TabIndex = 207;
			// 
			// _Label40_4
			// 
			_Label40_4.AllowDrop = true;
			_Label40_4.AutoSize = true;
			_Label40_4.BackColor = System.Drawing.Color.Transparent;
			_Label40_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label40_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label40_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label40_4.Location = new System.Drawing.Point(15, 133);
			_Label40_4.MinimumSize = new System.Drawing.Size(56, 60);
			_Label40_4.Name = "_Label40_4";
			_Label40_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label40_4.Size = new System.Drawing.Size(56, 60);
			_Label40_4.TabIndex = 217;
			_Label40_4.Text = "Model Search List (comma separated)";
			// 
			// _Label40_3
			// 
			_Label40_3.AllowDrop = true;
			_Label40_3.AutoSize = true;
			_Label40_3.BackColor = System.Drawing.Color.Transparent;
			_Label40_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label40_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label40_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label40_3.Location = new System.Drawing.Point(14, 215);
			_Label40_3.MinimumSize = new System.Drawing.Size(89, 13);
			_Label40_3.Name = "_Label40_3";
			_Label40_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label40_3.Size = new System.Drawing.Size(89, 13);
			_Label40_3.TabIndex = 213;
			_Label40_3.Text = "Jetnet Model List";
			// 
			// _Label40_1
			// 
			_Label40_1.AllowDrop = true;
			_Label40_1.AutoSize = true;
			_Label40_1.BackColor = System.Drawing.Color.Transparent;
			_Label40_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label40_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label40_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label40_1.Location = new System.Drawing.Point(17, 90);
			_Label40_1.MinimumSize = new System.Drawing.Size(63, 13);
			_Label40_1.Name = "_Label40_1";
			_Label40_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label40_1.Size = new System.Drawing.Size(63, 13);
			_Label40_1.TabIndex = 212;
			_Label40_1.Text = "Model  Name";
			// 
			// _Label40_0
			// 
			_Label40_0.AllowDrop = true;
			_Label40_0.AutoSize = true;
			_Label40_0.BackColor = System.Drawing.Color.Transparent;
			_Label40_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label40_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label40_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label40_0.Location = new System.Drawing.Point(18, 50);
			_Label40_0.MinimumSize = new System.Drawing.Size(58, 13);
			_Label40_0.Name = "_Label40_0";
			_Label40_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label40_0.Size = new System.Drawing.Size(58, 13);
			_Label40_0.TabIndex = 211;
			_Label40_0.Text = "Make Name";
			// 
			// _tab_Lookup_TabPage16
			// 
			_tab_Lookup_TabPage16.Controls.Add(_cmd_button_2);
			_tab_Lookup_TabPage16.Controls.Add(_Text1_0);
			_tab_Lookup_TabPage16.Controls.Add(_cmd_button_1);
			_tab_Lookup_TabPage16.Controls.Add(_cmd_button_0);
			_tab_Lookup_TabPage16.Controls.Add(grd_ABI_Hide_AC);
			_tab_Lookup_TabPage16.Controls.Add(_lbl_generic_7);
			_tab_Lookup_TabPage16.Controls.Add(_lbl_generic_6);
			_tab_Lookup_TabPage16.Controls.Add(_lbl_generic_5);
			_tab_Lookup_TabPage16.Controls.Add(_lbl_generic_4);
			_tab_Lookup_TabPage16.Controls.Add(_lbl_generic_3);
			_tab_Lookup_TabPage16.Controls.Add(_lbl_generic_1);
			_tab_Lookup_TabPage16.Controls.Add(_lbl_generic_0);
			_tab_Lookup_TabPage16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage16.Text = "ABI Hide Aircraft";
			// 
			// _cmd_button_2
			// 
			_cmd_button_2.AllowDrop = true;
			_cmd_button_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_2.Location = new System.Drawing.Point(533, 135);
			_cmd_button_2.Name = "_cmd_button_2";
			_cmd_button_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_2.Size = new System.Drawing.Size(84, 23);
			_cmd_button_2.TabIndex = 231;
			_cmd_button_2.Text = "Cancel";
			_cmd_button_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_2.UseVisualStyleBackColor = false;
			_cmd_button_2.Click += new System.EventHandler(cmd_button_Click);
			// 
			// _Text1_0
			// 
			_Text1_0.AcceptsReturn = true;
			_Text1_0.AllowDrop = true;
			_Text1_0.BackColor = System.Drawing.SystemColors.Window;
			_Text1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_0.Location = new System.Drawing.Point(542, 16);
			_Text1_0.MaxLength = 0;
			_Text1_0.Name = "_Text1_0";
			_Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_0.Size = new System.Drawing.Size(95, 19);
			_Text1_0.TabIndex = 230;
			// 
			// _cmd_button_1
			// 
			_cmd_button_1.AllowDrop = true;
			_cmd_button_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_1.Location = new System.Drawing.Point(581, 103);
			_cmd_button_1.Name = "_cmd_button_1";
			_cmd_button_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_1.Size = new System.Drawing.Size(84, 23);
			_cmd_button_1.TabIndex = 221;
			_cmd_button_1.Text = "Delete";
			_cmd_button_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_1.UseVisualStyleBackColor = false;
			_cmd_button_1.Click += new System.EventHandler(cmd_button_Click);
			// 
			// _cmd_button_0
			// 
			_cmd_button_0.AllowDrop = true;
			_cmd_button_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_0.Location = new System.Drawing.Point(488, 102);
			_cmd_button_0.Name = "_cmd_button_0";
			_cmd_button_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_0.Size = new System.Drawing.Size(84, 23);
			_cmd_button_0.TabIndex = 220;
			_cmd_button_0.Text = "Add";
			_cmd_button_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_0.UseVisualStyleBackColor = false;
			_cmd_button_0.Click += new System.EventHandler(cmd_button_Click);
			// 
			// grd_ABI_Hide_AC
			// 
			grd_ABI_Hide_AC.AllowDrop = true;
			grd_ABI_Hide_AC.AllowUserToAddRows = false;
			grd_ABI_Hide_AC.AllowUserToDeleteRows = false;
			grd_ABI_Hide_AC.AllowUserToResizeColumns = false;
			grd_ABI_Hide_AC.AllowUserToResizeRows = false;
			grd_ABI_Hide_AC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_ABI_Hide_AC.ColumnsCount = 4;
			grd_ABI_Hide_AC.FixedColumns = 1;
			grd_ABI_Hide_AC.FixedRows = 1;
			grd_ABI_Hide_AC.Location = new System.Drawing.Point(20, 19);
			grd_ABI_Hide_AC.Name = "grd_ABI_Hide_AC";
			grd_ABI_Hide_AC.ReadOnly = true;
			grd_ABI_Hide_AC.RowsCount = 2;
			grd_ABI_Hide_AC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_ABI_Hide_AC.ShowCellToolTips = false;
			grd_ABI_Hide_AC.Size = new System.Drawing.Size(457, 428);
			grd_ABI_Hide_AC.StandardTab = true;
			grd_ABI_Hide_AC.TabIndex = 219;
			grd_ABI_Hide_AC.Click += new System.EventHandler(grd_ABI_Hide_AC_Click);
			// 
			// _lbl_generic_7
			// 
			_lbl_generic_7.AllowDrop = true;
			_lbl_generic_7.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_7.Location = new System.Drawing.Point(543, 77);
			_lbl_generic_7.MinimumSize = new System.Drawing.Size(116, 12);
			_lbl_generic_7.Name = "_lbl_generic_7";
			_lbl_generic_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_7.Size = new System.Drawing.Size(116, 12);
			_lbl_generic_7.TabIndex = 229;
			// 
			// _lbl_generic_6
			// 
			_lbl_generic_6.AllowDrop = true;
			_lbl_generic_6.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_6.Location = new System.Drawing.Point(542, 58);
			_lbl_generic_6.MinimumSize = new System.Drawing.Size(116, 12);
			_lbl_generic_6.Name = "_lbl_generic_6";
			_lbl_generic_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_6.Size = new System.Drawing.Size(116, 12);
			_lbl_generic_6.TabIndex = 228;
			// 
			// _lbl_generic_5
			// 
			_lbl_generic_5.AllowDrop = true;
			_lbl_generic_5.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_5.Location = new System.Drawing.Point(542, 39);
			_lbl_generic_5.MinimumSize = new System.Drawing.Size(116, 12);
			_lbl_generic_5.Name = "_lbl_generic_5";
			_lbl_generic_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_5.Size = new System.Drawing.Size(116, 12);
			_lbl_generic_5.TabIndex = 227;
			// 
			// _lbl_generic_4
			// 
			_lbl_generic_4.AllowDrop = true;
			_lbl_generic_4.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_4.Location = new System.Drawing.Point(487, 76);
			_lbl_generic_4.MinimumSize = new System.Drawing.Size(63, 12);
			_lbl_generic_4.Name = "_lbl_generic_4";
			_lbl_generic_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_4.Size = new System.Drawing.Size(63, 12);
			_lbl_generic_4.TabIndex = 226;
			_lbl_generic_4.Text = "Serial #:";
			// 
			// _lbl_generic_3
			// 
			_lbl_generic_3.AllowDrop = true;
			_lbl_generic_3.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_3.Location = new System.Drawing.Point(486, 57);
			_lbl_generic_3.MinimumSize = new System.Drawing.Size(63, 12);
			_lbl_generic_3.Name = "_lbl_generic_3";
			_lbl_generic_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_3.Size = new System.Drawing.Size(63, 12);
			_lbl_generic_3.TabIndex = 225;
			_lbl_generic_3.Text = "Model:";
			// 
			// _lbl_generic_1
			// 
			_lbl_generic_1.AllowDrop = true;
			_lbl_generic_1.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_1.Location = new System.Drawing.Point(487, 37);
			_lbl_generic_1.MinimumSize = new System.Drawing.Size(63, 12);
			_lbl_generic_1.Name = "_lbl_generic_1";
			_lbl_generic_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_1.Size = new System.Drawing.Size(63, 12);
			_lbl_generic_1.TabIndex = 223;
			_lbl_generic_1.Text = "Make:";
			// 
			// _lbl_generic_0
			// 
			_lbl_generic_0.AllowDrop = true;
			_lbl_generic_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_0.Location = new System.Drawing.Point(489, 20);
			_lbl_generic_0.MinimumSize = new System.Drawing.Size(23, 12);
			_lbl_generic_0.Name = "_lbl_generic_0";
			_lbl_generic_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_0.Size = new System.Drawing.Size(23, 12);
			_lbl_generic_0.TabIndex = 222;
			_lbl_generic_0.Text = "ID:";
			// 
			// _tab_Lookup_TabPage17
			// 
			_tab_Lookup_TabPage17.Controls.Add(frmFuelPrices);
			_tab_Lookup_TabPage17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage17.Text = "Fuel Price";
			// 
			// frmFuelPrices
			// 
			frmFuelPrices.AllowDrop = true;
			frmFuelPrices.BackColor = System.Drawing.SystemColors.Control;
			frmFuelPrices.Controls.Add(_txtFuelCost_3);
			frmFuelPrices.Controls.Add(_txt_fuel_price_notes_3);
			frmFuelPrices.Controls.Add(_txt_fuel_price_notes_2);
			frmFuelPrices.Controls.Add(_txt_fuel_price_notes_1);
			frmFuelPrices.Controls.Add(_txt_fuel_price_notes_0);
			frmFuelPrices.Controls.Add(_cmd_button_3);
			frmFuelPrices.Controls.Add(_txtFuelCost_2);
			frmFuelPrices.Controls.Add(_txtFuelCost_1);
			frmFuelPrices.Controls.Add(_txtFuelCost_0);
			frmFuelPrices.Controls.Add(_lbl_generic_12);
			frmFuelPrices.Controls.Add(_lbl_generic_9);
			frmFuelPrices.Controls.Add(_lbl_generic_11);
			frmFuelPrices.Controls.Add(_lbl_generic_10);
			frmFuelPrices.Controls.Add(_lbl_generic_8);
			frmFuelPrices.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmFuelPrices.Enabled = true;
			frmFuelPrices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmFuelPrices.ForeColor = System.Drawing.SystemColors.ControlText;
			frmFuelPrices.Location = new System.Drawing.Point(40, 20);
			frmFuelPrices.Name = "frmFuelPrices";
			frmFuelPrices.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmFuelPrices.Size = new System.Drawing.Size(627, 179);
			frmFuelPrices.TabIndex = 404;
			frmFuelPrices.Text = "Fuel Prices";
			frmFuelPrices.Visible = true;
			// 
			// _txtFuelCost_3
			// 
			_txtFuelCost_3.AcceptsReturn = true;
			_txtFuelCost_3.AllowDrop = true;
			_txtFuelCost_3.BackColor = System.Drawing.SystemColors.Window;
			_txtFuelCost_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtFuelCost_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtFuelCost_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtFuelCost_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtFuelCost_3.Location = new System.Drawing.Point(108, 88);
			_txtFuelCost_3.MaxLength = 0;
			_txtFuelCost_3.Name = "_txtFuelCost_3";
			_txtFuelCost_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtFuelCost_3.Size = new System.Drawing.Size(55, 19);
			_txtFuelCost_3.TabIndex = 421;
			_txtFuelCost_3.Text = "0";
			// 
			// _txt_fuel_price_notes_3
			// 
			_txt_fuel_price_notes_3.AcceptsReturn = true;
			_txt_fuel_price_notes_3.AllowDrop = true;
			_txt_fuel_price_notes_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_fuel_price_notes_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_fuel_price_notes_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_fuel_price_notes_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_fuel_price_notes_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_fuel_price_notes_3.Location = new System.Drawing.Point(176, 88);
			_txt_fuel_price_notes_3.MaxLength = 0;
			_txt_fuel_price_notes_3.Name = "_txt_fuel_price_notes_3";
			_txt_fuel_price_notes_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_fuel_price_notes_3.Size = new System.Drawing.Size(369, 19);
			_txt_fuel_price_notes_3.TabIndex = 420;
			// 
			// _txt_fuel_price_notes_2
			// 
			_txt_fuel_price_notes_2.AcceptsReturn = true;
			_txt_fuel_price_notes_2.AllowDrop = true;
			_txt_fuel_price_notes_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_fuel_price_notes_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_fuel_price_notes_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_fuel_price_notes_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_fuel_price_notes_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_fuel_price_notes_2.Location = new System.Drawing.Point(176, 66);
			_txt_fuel_price_notes_2.MaxLength = 0;
			_txt_fuel_price_notes_2.Name = "_txt_fuel_price_notes_2";
			_txt_fuel_price_notes_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_fuel_price_notes_2.Size = new System.Drawing.Size(369, 19);
			_txt_fuel_price_notes_2.TabIndex = 419;
			// 
			// _txt_fuel_price_notes_1
			// 
			_txt_fuel_price_notes_1.AcceptsReturn = true;
			_txt_fuel_price_notes_1.AllowDrop = true;
			_txt_fuel_price_notes_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_fuel_price_notes_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_fuel_price_notes_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_fuel_price_notes_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_fuel_price_notes_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_fuel_price_notes_1.Location = new System.Drawing.Point(176, 42);
			_txt_fuel_price_notes_1.MaxLength = 0;
			_txt_fuel_price_notes_1.Name = "_txt_fuel_price_notes_1";
			_txt_fuel_price_notes_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_fuel_price_notes_1.Size = new System.Drawing.Size(369, 19);
			_txt_fuel_price_notes_1.TabIndex = 418;
			// 
			// _txt_fuel_price_notes_0
			// 
			_txt_fuel_price_notes_0.AcceptsReturn = true;
			_txt_fuel_price_notes_0.AllowDrop = true;
			_txt_fuel_price_notes_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_fuel_price_notes_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_fuel_price_notes_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_fuel_price_notes_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_fuel_price_notes_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_fuel_price_notes_0.Location = new System.Drawing.Point(176, 18);
			_txt_fuel_price_notes_0.MaxLength = 0;
			_txt_fuel_price_notes_0.Name = "_txt_fuel_price_notes_0";
			_txt_fuel_price_notes_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_fuel_price_notes_0.Size = new System.Drawing.Size(369, 19);
			_txt_fuel_price_notes_0.TabIndex = 417;
			// 
			// _cmd_button_3
			// 
			_cmd_button_3.AllowDrop = true;
			_cmd_button_3.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_3.Location = new System.Drawing.Point(16, 122);
			_cmd_button_3.Name = "_cmd_button_3";
			_cmd_button_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_3.Size = new System.Drawing.Size(56, 23);
			_cmd_button_3.TabIndex = 411;
			_cmd_button_3.Text = "Update";
			_cmd_button_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_3.UseVisualStyleBackColor = false;
			_cmd_button_3.Click += new System.EventHandler(cmd_button_Click);
			// 
			// _txtFuelCost_2
			// 
			_txtFuelCost_2.AcceptsReturn = true;
			_txtFuelCost_2.AllowDrop = true;
			_txtFuelCost_2.BackColor = System.Drawing.SystemColors.Window;
			_txtFuelCost_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtFuelCost_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtFuelCost_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtFuelCost_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtFuelCost_2.Location = new System.Drawing.Point(108, 66);
			_txtFuelCost_2.MaxLength = 0;
			_txtFuelCost_2.Name = "_txtFuelCost_2";
			_txtFuelCost_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtFuelCost_2.Size = new System.Drawing.Size(55, 19);
			_txtFuelCost_2.TabIndex = 410;
			_txtFuelCost_2.Text = "0";
			// 
			// _txtFuelCost_1
			// 
			_txtFuelCost_1.AcceptsReturn = true;
			_txtFuelCost_1.AllowDrop = true;
			_txtFuelCost_1.BackColor = System.Drawing.SystemColors.Window;
			_txtFuelCost_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtFuelCost_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtFuelCost_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtFuelCost_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtFuelCost_1.Location = new System.Drawing.Point(108, 42);
			_txtFuelCost_1.MaxLength = 0;
			_txtFuelCost_1.Name = "_txtFuelCost_1";
			_txtFuelCost_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtFuelCost_1.Size = new System.Drawing.Size(55, 19);
			_txtFuelCost_1.TabIndex = 409;
			_txtFuelCost_1.Text = "0";
			// 
			// _txtFuelCost_0
			// 
			_txtFuelCost_0.AcceptsReturn = true;
			_txtFuelCost_0.AllowDrop = true;
			_txtFuelCost_0.BackColor = System.Drawing.SystemColors.Window;
			_txtFuelCost_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtFuelCost_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtFuelCost_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtFuelCost_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtFuelCost_0.Location = new System.Drawing.Point(108, 18);
			_txtFuelCost_0.MaxLength = 0;
			_txtFuelCost_0.Name = "_txtFuelCost_0";
			_txtFuelCost_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtFuelCost_0.Size = new System.Drawing.Size(55, 19);
			_txtFuelCost_0.TabIndex = 408;
			_txtFuelCost_0.Text = "0";
			// 
			// _lbl_generic_12
			// 
			_lbl_generic_12.AllowDrop = true;
			_lbl_generic_12.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_12.Location = new System.Drawing.Point(16, 92);
			_lbl_generic_12.MinimumSize = new System.Drawing.Size(83, 12);
			_lbl_generic_12.Name = "_lbl_generic_12";
			_lbl_generic_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_12.Size = new System.Drawing.Size(83, 12);
			_lbl_generic_12.TabIndex = 422;
			_lbl_generic_12.Text = "SAF Cost";
			// 
			// _lbl_generic_9
			// 
			_lbl_generic_9.AllowDrop = true;
			_lbl_generic_9.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_9.Location = new System.Drawing.Point(108, 126);
			_lbl_generic_9.MinimumSize = new System.Drawing.Size(135, 12);
			_lbl_generic_9.Name = "_lbl_generic_9";
			_lbl_generic_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_9.Size = new System.Drawing.Size(135, 12);
			_lbl_generic_9.TabIndex = 412;
			_lbl_generic_9.Text = "Evo_Config_ID:";
			_lbl_generic_9.Visible = false;
			// 
			// _lbl_generic_11
			// 
			_lbl_generic_11.AllowDrop = true;
			_lbl_generic_11.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_11.Location = new System.Drawing.Point(16, 72);
			_lbl_generic_11.MinimumSize = new System.Drawing.Size(83, 12);
			_lbl_generic_11.Name = "_lbl_generic_11";
			_lbl_generic_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_11.Size = new System.Drawing.Size(83, 12);
			_lbl_generic_11.TabIndex = 407;
			_lbl_generic_11.Text = "Commercial Cost";
			// 
			// _lbl_generic_10
			// 
			_lbl_generic_10.AllowDrop = true;
			_lbl_generic_10.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_10.Location = new System.Drawing.Point(16, 46);
			_lbl_generic_10.MinimumSize = new System.Drawing.Size(73, 12);
			_lbl_generic_10.Name = "_lbl_generic_10";
			_lbl_generic_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_10.Size = new System.Drawing.Size(73, 12);
			_lbl_generic_10.TabIndex = 406;
			_lbl_generic_10.Text = "Low Lead Cost";
			// 
			// _lbl_generic_8
			// 
			_lbl_generic_8.AllowDrop = true;
			_lbl_generic_8.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_8.Location = new System.Drawing.Point(16, 22);
			_lbl_generic_8.MinimumSize = new System.Drawing.Size(55, 12);
			_lbl_generic_8.Name = "_lbl_generic_8";
			_lbl_generic_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_8.Size = new System.Drawing.Size(55, 12);
			_lbl_generic_8.TabIndex = 405;
			_lbl_generic_8.Text = "JETA Cost";
			// 
			// _tab_Lookup_TabPage18
			// 
			_tab_Lookup_TabPage18.Controls.Add(acTopicsUpdateEvo);
			_tab_Lookup_TabPage18.Controls.Add(acTopicArea);
			_tab_Lookup_TabPage18.Controls.Add(acTopicAdd);
			_tab_Lookup_TabPage18.Controls.Add(acTopicsGrid);
			_tab_Lookup_TabPage18.Controls.Add(acTopicsPanel);
			_tab_Lookup_TabPage18.Controls.Add(acTopicsAircraftFrame);
			_tab_Lookup_TabPage18.Controls.Add(acTopicErrorDisplay);
			_tab_Lookup_TabPage18.Controls.Add(Label20);
			_tab_Lookup_TabPage18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage18.Text = "Aircraft Topics";
			// 
			// acTopicsUpdateEvo
			// 
			acTopicsUpdateEvo.AllowDrop = true;
			acTopicsUpdateEvo.BackColor = System.Drawing.SystemColors.Control;
			acTopicsUpdateEvo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicsUpdateEvo.ForeColor = System.Drawing.SystemColors.ControlText;
			acTopicsUpdateEvo.Location = new System.Drawing.Point(478, 40);
			acTopicsUpdateEvo.Name = "acTopicsUpdateEvo";
			acTopicsUpdateEvo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicsUpdateEvo.Size = new System.Drawing.Size(121, 25);
			acTopicsUpdateEvo.TabIndex = 270;
			acTopicsUpdateEvo.Text = "&Update Live Evo";
			acTopicsUpdateEvo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			acTopicsUpdateEvo.UseVisualStyleBackColor = false;
			acTopicsUpdateEvo.Click += new System.EventHandler(acTopicsUpdateEvo_Click);
			// 
			// acTopicArea
			// 
			acTopicArea.AllowDrop = true;
			acTopicArea.BackColor = System.Drawing.SystemColors.Window;
			acTopicArea.CausesValidation = true;
			acTopicArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			acTopicArea.Enabled = true;
			acTopicArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicArea.ForeColor = System.Drawing.SystemColors.WindowText;
			acTopicArea.IntegralHeight = true;
			acTopicArea.Location = new System.Drawing.Point(6, 42);
			acTopicArea.Name = "acTopicArea";
			acTopicArea.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicArea.Size = new System.Drawing.Size(335, 21);
			acTopicArea.Sorted = false;
			acTopicArea.TabIndex = 268;
			acTopicArea.TabStop = true;
			acTopicArea.Visible = true;
			acTopicArea.SelectionChangeCommitted += new System.EventHandler(acTopicArea_SelectionChangeCommitted);
			// 
			// acTopicAdd
			// 
			acTopicAdd.AllowDrop = true;
			acTopicAdd.BackColor = System.Drawing.SystemColors.Control;
			acTopicAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			acTopicAdd.Location = new System.Drawing.Point(348, 40);
			acTopicAdd.Name = "acTopicAdd";
			acTopicAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicAdd.Size = new System.Drawing.Size(121, 25);
			acTopicAdd.TabIndex = 262;
			acTopicAdd.Text = "&Add Aircraft Topic";
			acTopicAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			acTopicAdd.UseVisualStyleBackColor = false;
			acTopicAdd.Click += new System.EventHandler(acTopicAdd_Click);
			// 
			// acTopicsGrid
			// 
			acTopicsGrid.AllowDrop = true;
			acTopicsGrid.AllowUserToAddRows = false;
			acTopicsGrid.AllowUserToDeleteRows = false;
			acTopicsGrid.AllowUserToResizeColumns = false;
			acTopicsGrid.AllowUserToResizeColumns = acTopicsGrid.ColumnHeadersVisible;
			acTopicsGrid.AllowUserToResizeRows = false;
			acTopicsGrid.AllowUserToResizeRows = false;
			acTopicsGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			acTopicsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			acTopicsGrid.ColumnsCount = 2;
			acTopicsGrid.DefaultCellStyle.BackColor = System.Drawing.SystemColors.InactiveBorder;
			acTopicsGrid.Enabled = false;
			acTopicsGrid.FixedColumns = 0;
			acTopicsGrid.FixedRows = 1;
			acTopicsGrid.Location = new System.Drawing.Point(12, 72);
			acTopicsGrid.Name = "acTopicsGrid";
			acTopicsGrid.ReadOnly = true;
			acTopicsGrid.RowsCount = 2;
			acTopicsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			acTopicsGrid.ShowCellToolTips = false;
			acTopicsGrid.Size = new System.Drawing.Size(334, 387);
			acTopicsGrid.StandardTab = true;
			acTopicsGrid.TabIndex = 261;
			acTopicsGrid.Click += new System.EventHandler(acTopicsGrid_Click);
			// 
			// acTopicsPanel
			// 
			acTopicsPanel.AllowDrop = true;
			acTopicsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			acTopicsPanel.Controls.Add(_check_prod_code_2);
			acTopicsPanel.Controls.Add(_check_prod_code_1);
			acTopicsPanel.Controls.Add(_check_prod_code_0);
			acTopicsPanel.Controls.Add(acTopicParentTopic);
			acTopicsPanel.Controls.Add(acTopicItemName);
			acTopicsPanel.Controls.Add(acTopicItemQuery);
			acTopicsPanel.Controls.Add(acTopicAerodexFlag);
			acTopicsPanel.Controls.Add(acTopicAreaItem);
			acTopicsPanel.Controls.Add(acTopicSave);
			acTopicsPanel.Controls.Add(acTopicCancel);
			acTopicsPanel.Controls.Add(acTopicDelete);
			acTopicsPanel.Controls.Add(acTopicItemDescription);
			acTopicsPanel.Controls.Add(_Label24_8);
			acTopicsPanel.Controls.Add(_Label24_7);
			acTopicsPanel.Controls.Add(_Label24_6);
			acTopicsPanel.Controls.Add(_Label24_5);
			acTopicsPanel.Controls.Add(_Label24_4);
			acTopicsPanel.Controls.Add(acTopicIDLabel);
			acTopicsPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicsPanel.Location = new System.Drawing.Point(344, 70);
			acTopicsPanel.Name = "acTopicsPanel";
			acTopicsPanel.Size = new System.Drawing.Size(545, 382);
			acTopicsPanel.TabIndex = 263;
			acTopicsPanel.Visible = false;
			// 
			// _check_prod_code_2
			// 
			_check_prod_code_2.AllowDrop = true;
			_check_prod_code_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_check_prod_code_2.BackColor = System.Drawing.SystemColors.Control;
			_check_prod_code_2.CausesValidation = true;
			_check_prod_code_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_check_prod_code_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_check_prod_code_2.Enabled = true;
			_check_prod_code_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_check_prod_code_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_check_prod_code_2.Location = new System.Drawing.Point(324, 110);
			_check_prod_code_2.Name = "_check_prod_code_2";
			_check_prod_code_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_check_prod_code_2.Size = new System.Drawing.Size(69, 15);
			_check_prod_code_2.TabIndex = 288;
			_check_prod_code_2.TabStop = true;
			_check_prod_code_2.Text = "Helicopter";
			_check_prod_code_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_check_prod_code_2.Visible = true;
			// 
			// _check_prod_code_1
			// 
			_check_prod_code_1.AllowDrop = true;
			_check_prod_code_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_check_prod_code_1.BackColor = System.Drawing.SystemColors.Control;
			_check_prod_code_1.CausesValidation = true;
			_check_prod_code_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_check_prod_code_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_check_prod_code_1.Enabled = true;
			_check_prod_code_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_check_prod_code_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_check_prod_code_1.Location = new System.Drawing.Point(215, 110);
			_check_prod_code_1.Name = "_check_prod_code_1";
			_check_prod_code_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_check_prod_code_1.Size = new System.Drawing.Size(93, 15);
			_check_prod_code_1.TabIndex = 287;
			_check_prod_code_1.TabStop = true;
			_check_prod_code_1.Text = "Commercial";
			_check_prod_code_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_check_prod_code_1.Visible = true;
			// 
			// _check_prod_code_0
			// 
			_check_prod_code_0.AllowDrop = true;
			_check_prod_code_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_check_prod_code_0.BackColor = System.Drawing.SystemColors.Control;
			_check_prod_code_0.CausesValidation = true;
			_check_prod_code_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_check_prod_code_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_check_prod_code_0.Enabled = true;
			_check_prod_code_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_check_prod_code_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_check_prod_code_0.Location = new System.Drawing.Point(130, 110);
			_check_prod_code_0.Name = "_check_prod_code_0";
			_check_prod_code_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_check_prod_code_0.Size = new System.Drawing.Size(69, 15);
			_check_prod_code_0.TabIndex = 286;
			_check_prod_code_0.TabStop = true;
			_check_prod_code_0.Text = "Business";
			_check_prod_code_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_check_prod_code_0.Visible = true;
			// 
			// acTopicParentTopic
			// 
			acTopicParentTopic.AllowDrop = true;
			acTopicParentTopic.BackColor = System.Drawing.Color.White;
			acTopicParentTopic.CausesValidation = true;
			acTopicParentTopic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			acTopicParentTopic.Enabled = true;
			acTopicParentTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicParentTopic.ForeColor = System.Drawing.SystemColors.WindowText;
			acTopicParentTopic.IntegralHeight = true;
			acTopicParentTopic.Location = new System.Drawing.Point(220, 34);
			acTopicParentTopic.Name = "acTopicParentTopic";
			acTopicParentTopic.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicParentTopic.Size = new System.Drawing.Size(193, 21);
			acTopicParentTopic.Sorted = false;
			acTopicParentTopic.TabIndex = 279;
			acTopicParentTopic.TabStop = true;
			acTopicParentTopic.Visible = true;
			// 
			// acTopicItemName
			// 
			acTopicItemName.AcceptsReturn = true;
			acTopicItemName.AllowDrop = true;
			acTopicItemName.BackColor = System.Drawing.SystemColors.Window;
			acTopicItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			acTopicItemName.Cursor = System.Windows.Forms.Cursors.IBeam;
			acTopicItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicItemName.ForeColor = System.Drawing.SystemColors.WindowText;
			acTopicItemName.Location = new System.Drawing.Point(8, 84);
			acTopicItemName.MaxLength = 0;
			acTopicItemName.Name = "acTopicItemName";
			acTopicItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicItemName.Size = new System.Drawing.Size(265, 19);
			acTopicItemName.TabIndex = 274;
			// 
			// acTopicItemQuery
			// 
			acTopicItemQuery.AcceptsReturn = true;
			acTopicItemQuery.AllowDrop = true;
			acTopicItemQuery.BackColor = System.Drawing.SystemColors.Window;
			acTopicItemQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			acTopicItemQuery.Cursor = System.Windows.Forms.Cursors.IBeam;
			acTopicItemQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicItemQuery.ForeColor = System.Drawing.SystemColors.WindowText;
			acTopicItemQuery.Location = new System.Drawing.Point(10, 255);
			acTopicItemQuery.MaxLength = 0;
			acTopicItemQuery.Multiline = true;
			acTopicItemQuery.Name = "acTopicItemQuery";
			acTopicItemQuery.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicItemQuery.Size = new System.Drawing.Size(526, 121);
			acTopicItemQuery.TabIndex = 273;
			acTopicItemQuery.TabStop = false;
			// 
			// acTopicAerodexFlag
			// 
			acTopicAerodexFlag.AllowDrop = true;
			acTopicAerodexFlag.Appearance = System.Windows.Forms.Appearance.Normal;
			acTopicAerodexFlag.BackColor = System.Drawing.SystemColors.Control;
			acTopicAerodexFlag.CausesValidation = true;
			acTopicAerodexFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			acTopicAerodexFlag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			acTopicAerodexFlag.Enabled = true;
			acTopicAerodexFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicAerodexFlag.ForeColor = System.Drawing.SystemColors.WindowText;
			acTopicAerodexFlag.Location = new System.Drawing.Point(282, 84);
			acTopicAerodexFlag.Name = "acTopicAerodexFlag";
			acTopicAerodexFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicAerodexFlag.Size = new System.Drawing.Size(65, 19);
			acTopicAerodexFlag.TabIndex = 272;
			acTopicAerodexFlag.TabStop = true;
			acTopicAerodexFlag.Text = "Aerodex";
			acTopicAerodexFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			acTopicAerodexFlag.Visible = true;
			// 
			// acTopicAreaItem
			// 
			acTopicAreaItem.AllowDrop = true;
			acTopicAreaItem.BackColor = System.Drawing.Color.White;
			acTopicAreaItem.CausesValidation = true;
			acTopicAreaItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			acTopicAreaItem.Enabled = true;
			acTopicAreaItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicAreaItem.ForeColor = System.Drawing.SystemColors.WindowText;
			acTopicAreaItem.IntegralHeight = true;
			acTopicAreaItem.Location = new System.Drawing.Point(8, 34);
			acTopicAreaItem.Name = "acTopicAreaItem";
			acTopicAreaItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicAreaItem.Size = new System.Drawing.Size(193, 21);
			acTopicAreaItem.Sorted = false;
			acTopicAreaItem.TabIndex = 271;
			acTopicAreaItem.TabStop = true;
			acTopicAreaItem.Visible = true;
			// 
			// acTopicSave
			// 
			acTopicSave.AllowDrop = true;
			acTopicSave.BackColor = System.Drawing.SystemColors.Control;
			acTopicSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicSave.ForeColor = System.Drawing.SystemColors.ControlText;
			acTopicSave.Location = new System.Drawing.Point(466, 12);
			acTopicSave.Name = "acTopicSave";
			acTopicSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicSave.Size = new System.Drawing.Size(57, 25);
			acTopicSave.TabIndex = 267;
			acTopicSave.Text = "&Save";
			acTopicSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			acTopicSave.UseVisualStyleBackColor = false;
			acTopicSave.Click += new System.EventHandler(acTopicSave_Click);
			// 
			// acTopicCancel
			// 
			acTopicCancel.AllowDrop = true;
			acTopicCancel.BackColor = System.Drawing.SystemColors.Control;
			acTopicCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			acTopicCancel.Location = new System.Drawing.Point(466, 42);
			acTopicCancel.Name = "acTopicCancel";
			acTopicCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicCancel.Size = new System.Drawing.Size(57, 25);
			acTopicCancel.TabIndex = 266;
			acTopicCancel.Text = "&Cancel";
			acTopicCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			acTopicCancel.UseVisualStyleBackColor = false;
			acTopicCancel.Click += new System.EventHandler(acTopicCancel_Click);
			// 
			// acTopicDelete
			// 
			acTopicDelete.AllowDrop = true;
			acTopicDelete.BackColor = System.Drawing.SystemColors.Control;
			acTopicDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			acTopicDelete.Location = new System.Drawing.Point(464, 72);
			acTopicDelete.Name = "acTopicDelete";
			acTopicDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicDelete.Size = new System.Drawing.Size(57, 25);
			acTopicDelete.TabIndex = 265;
			acTopicDelete.Text = "&Delete";
			acTopicDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			acTopicDelete.UseVisualStyleBackColor = false;
			acTopicDelete.Click += new System.EventHandler(acTopicDelete_Click);
			// 
			// acTopicItemDescription
			// 
			acTopicItemDescription.AcceptsReturn = true;
			acTopicItemDescription.AllowDrop = true;
			acTopicItemDescription.BackColor = System.Drawing.SystemColors.Window;
			acTopicItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			acTopicItemDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
			acTopicItemDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicItemDescription.ForeColor = System.Drawing.SystemColors.WindowText;
			acTopicItemDescription.Location = new System.Drawing.Point(6, 136);
			acTopicItemDescription.MaxLength = 0;
			acTopicItemDescription.Multiline = true;
			acTopicItemDescription.Name = "acTopicItemDescription";
			acTopicItemDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicItemDescription.Size = new System.Drawing.Size(526, 91);
			acTopicItemDescription.TabIndex = 264;
			acTopicItemDescription.TabStop = false;
			// 
			// _Label24_8
			// 
			_Label24_8.AllowDrop = true;
			_Label24_8.BackColor = System.Drawing.SystemColors.Control;
			_Label24_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_8.Location = new System.Drawing.Point(10, 114);
			_Label24_8.MinimumSize = new System.Drawing.Size(131, 17);
			_Label24_8.Name = "_Label24_8";
			_Label24_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_8.Size = new System.Drawing.Size(131, 17);
			_Label24_8.TabIndex = 297;
			_Label24_8.Text = "Topic Description";
			// 
			// _Label24_7
			// 
			_Label24_7.AllowDrop = true;
			_Label24_7.BackColor = System.Drawing.SystemColors.Control;
			_Label24_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_7.ForeColor = System.Drawing.Color.Red;
			_Label24_7.Location = new System.Drawing.Point(8, 238);
			_Label24_7.MinimumSize = new System.Drawing.Size(253, 17);
			_Label24_7.Name = "_Label24_7";
			_Label24_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_7.Size = new System.Drawing.Size(253, 17);
			_Label24_7.TabIndex = 296;
			_Label24_7.Text = "Topic Query - double click to test query";
			// 
			// _Label24_6
			// 
			_Label24_6.AllowDrop = true;
			_Label24_6.BackColor = System.Drawing.SystemColors.Control;
			_Label24_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_6.Location = new System.Drawing.Point(8, 64);
			_Label24_6.MinimumSize = new System.Drawing.Size(97, 17);
			_Label24_6.Name = "_Label24_6";
			_Label24_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_6.Size = new System.Drawing.Size(97, 17);
			_Label24_6.TabIndex = 295;
			_Label24_6.Text = "Topic Name";
			// 
			// _Label24_5
			// 
			_Label24_5.AllowDrop = true;
			_Label24_5.BackColor = System.Drawing.SystemColors.Control;
			_Label24_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_5.Location = new System.Drawing.Point(222, 14);
			_Label24_5.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_5.Name = "_Label24_5";
			_Label24_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_5.Size = new System.Drawing.Size(75, 17);
			_Label24_5.TabIndex = 294;
			_Label24_5.Text = "Parent Topic";
			// 
			// _Label24_4
			// 
			_Label24_4.AllowDrop = true;
			_Label24_4.BackColor = System.Drawing.SystemColors.Control;
			_Label24_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_4.Location = new System.Drawing.Point(8, 14);
			_Label24_4.MinimumSize = new System.Drawing.Size(79, 17);
			_Label24_4.Name = "_Label24_4";
			_Label24_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_4.Size = new System.Drawing.Size(79, 17);
			_Label24_4.TabIndex = 293;
			_Label24_4.Text = "Topic Type";
			// 
			// acTopicIDLabel
			// 
			acTopicIDLabel.AllowDrop = true;
			acTopicIDLabel.BackColor = System.Drawing.SystemColors.Control;
			acTopicIDLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			acTopicIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicIDLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			acTopicIDLabel.Location = new System.Drawing.Point(350, 85);
			acTopicIDLabel.MinimumSize = new System.Drawing.Size(105, 15);
			acTopicIDLabel.Name = "acTopicIDLabel";
			acTopicIDLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicIDLabel.Size = new System.Drawing.Size(105, 15);
			acTopicIDLabel.TabIndex = 280;
			acTopicIDLabel.Text = "Topic ID :";
			// 
			// acTopicsAircraftFrame
			// 
			acTopicsAircraftFrame.AllowDrop = true;
			acTopicsAircraftFrame.BackColor = System.Drawing.SystemColors.Control;
			acTopicsAircraftFrame.Controls.Add(acTopicsListClose);
			acTopicsAircraftFrame.Controls.Add(acTopicAircraftList);
			acTopicsAircraftFrame.Controls.Add(acTopicAircraftListLabel);
			acTopicsAircraftFrame.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			acTopicsAircraftFrame.Enabled = true;
			acTopicsAircraftFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicsAircraftFrame.ForeColor = System.Drawing.SystemColors.ControlText;
			acTopicsAircraftFrame.Location = new System.Drawing.Point(6, 14);
			acTopicsAircraftFrame.Name = "acTopicsAircraftFrame";
			acTopicsAircraftFrame.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicsAircraftFrame.Size = new System.Drawing.Size(335, 393);
			acTopicsAircraftFrame.TabIndex = 275;
			acTopicsAircraftFrame.Text = "Aircraft Selected";
			acTopicsAircraftFrame.Visible = false;
			// 
			// acTopicsListClose
			// 
			acTopicsListClose.AllowDrop = true;
			acTopicsListClose.BackColor = System.Drawing.SystemColors.Control;
			acTopicsListClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicsListClose.ForeColor = System.Drawing.SystemColors.ControlText;
			acTopicsListClose.Location = new System.Drawing.Point(247, 360);
			acTopicsListClose.Name = "acTopicsListClose";
			acTopicsListClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicsListClose.Size = new System.Drawing.Size(73, 25);
			acTopicsListClose.TabIndex = 276;
			acTopicsListClose.Text = "Close";
			acTopicsListClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			acTopicsListClose.UseVisualStyleBackColor = false;
			acTopicsListClose.Click += new System.EventHandler(acTopicsListClose_Click);
			// 
			// acTopicAircraftList
			// 
			acTopicAircraftList.AllowBigSelection = false;
			acTopicAircraftList.AllowDrop = true;
			acTopicAircraftList.AllowUserToAddRows = false;
			acTopicAircraftList.AllowUserToDeleteRows = false;
			acTopicAircraftList.AllowUserToResizeColumns = false;
			acTopicAircraftList.AllowUserToResizeRows = false;
			acTopicAircraftList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			acTopicAircraftList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			acTopicAircraftList.ColumnsCount = 2;
			acTopicAircraftList.FixedColumns = 1;
			acTopicAircraftList.FixedRows = 1;
			acTopicAircraftList.Location = new System.Drawing.Point(7, 64);
			acTopicAircraftList.Name = "acTopicAircraftList";
			acTopicAircraftList.ReadOnly = true;
			acTopicAircraftList.RowsCount = 2;
			acTopicAircraftList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			acTopicAircraftList.ShowCellToolTips = false;
			acTopicAircraftList.Size = new System.Drawing.Size(313, 289);
			acTopicAircraftList.StandardTab = true;
			acTopicAircraftList.TabIndex = 277;
			// 
			// acTopicAircraftListLabel
			// 
			acTopicAircraftListLabel.AllowDrop = true;
			acTopicAircraftListLabel.BackColor = System.Drawing.SystemColors.Control;
			acTopicAircraftListLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			acTopicAircraftListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicAircraftListLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			acTopicAircraftListLabel.Location = new System.Drawing.Point(7, 16);
			acTopicAircraftListLabel.MinimumSize = new System.Drawing.Size(313, 49);
			acTopicAircraftListLabel.Name = "acTopicAircraftListLabel";
			acTopicAircraftListLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicAircraftListLabel.Size = new System.Drawing.Size(313, 49);
			acTopicAircraftListLabel.TabIndex = 278;
			// 
			// acTopicErrorDisplay
			// 
			acTopicErrorDisplay.AllowDrop = true;
			acTopicErrorDisplay.BackColor = System.Drawing.SystemColors.Control;
			acTopicErrorDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
			acTopicErrorDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			acTopicErrorDisplay.ForeColor = System.Drawing.Color.Red;
			acTopicErrorDisplay.Location = new System.Drawing.Point(602, 40);
			acTopicErrorDisplay.MinimumSize = new System.Drawing.Size(285, 25);
			acTopicErrorDisplay.Name = "acTopicErrorDisplay";
			acTopicErrorDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
			acTopicErrorDisplay.Size = new System.Drawing.Size(285, 25);
			acTopicErrorDisplay.TabIndex = 281;
			// 
			// Label20
			// 
			Label20.AllowDrop = true;
			Label20.BackColor = System.Drawing.SystemColors.Control;
			Label20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label20.ForeColor = System.Drawing.SystemColors.ControlText;
			Label20.Location = new System.Drawing.Point(6, 20);
			Label20.MinimumSize = new System.Drawing.Size(105, 17);
			Label20.Name = "Label20";
			Label20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label20.Size = new System.Drawing.Size(105, 17);
			Label20.TabIndex = 269;
			Label20.Text = "Aircraft Topic Areas";
			// 
			// _tab_Lookup_TabPage19
			// 
			_tab_Lookup_TabPage19.Controls.Add(_Label24_9);
			_tab_Lookup_TabPage19.Controls.Add(_Label24_10);
			_tab_Lookup_TabPage19.Controls.Add(_Label24_11);
			_tab_Lookup_TabPage19.Controls.Add(_Label24_12);
			_tab_Lookup_TabPage19.Controls.Add(_Label24_13);
			_tab_Lookup_TabPage19.Controls.Add(_Label24_14);
			_tab_Lookup_TabPage19.Controls.Add(_Label24_42);
			_tab_Lookup_TabPage19.Controls.Add(_Label24_43);
			_tab_Lookup_TabPage19.Controls.Add(grd_maint_items);
			_tab_Lookup_TabPage19.Controls.Add(_txt_maint_0);
			_tab_Lookup_TabPage19.Controls.Add(_txt_maint_1);
			_tab_Lookup_TabPage19.Controls.Add(_txt_maint_2);
			_tab_Lookup_TabPage19.Controls.Add(_chk_maint_0);
			_tab_Lookup_TabPage19.Controls.Add(_chk_maint_1);
			_tab_Lookup_TabPage19.Controls.Add(_txt_maint_3);
			_tab_Lookup_TabPage19.Controls.Add(cbo_maint_type);
			_tab_Lookup_TabPage19.Controls.Add(_cmd_maint_0);
			_tab_Lookup_TabPage19.Controls.Add(_cmd_maint_1);
			_tab_Lookup_TabPage19.Controls.Add(_cmd_maint_2);
			_tab_Lookup_TabPage19.Controls.Add(_cmd_maint_3);
			_tab_Lookup_TabPage19.Controls.Add(_cmd_maint_4);
			_tab_Lookup_TabPage19.Controls.Add(cmd_post);
			_tab_Lookup_TabPage19.Controls.Add(_txt_maint_4);
			_tab_Lookup_TabPage19.Controls.Add(_cmd_maint_5);
			_tab_Lookup_TabPage19.Controls.Add(_cmd_maint_6);
			_tab_Lookup_TabPage19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage19.Text = "Maintenance Items";
			// 
			// _Label24_9
			// 
			_Label24_9.AllowDrop = true;
			_Label24_9.BackColor = System.Drawing.SystemColors.Control;
			_Label24_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_9.Location = new System.Drawing.Point(430, 60);
			_Label24_9.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_9.Name = "_Label24_9";
			_Label24_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_9.Size = new System.Drawing.Size(75, 17);
			_Label24_9.TabIndex = 298;
			_Label24_9.Text = "ID";
			// 
			// _Label24_10
			// 
			_Label24_10.AllowDrop = true;
			_Label24_10.BackColor = System.Drawing.SystemColors.Control;
			_Label24_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_10.Location = new System.Drawing.Point(430, 94);
			_Label24_10.MinimumSize = new System.Drawing.Size(65, 17);
			_Label24_10.Name = "_Label24_10";
			_Label24_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_10.Size = new System.Drawing.Size(65, 17);
			_Label24_10.TabIndex = 299;
			_Label24_10.Text = "Item Name:";
			// 
			// _Label24_11
			// 
			_Label24_11.AllowDrop = true;
			_Label24_11.BackColor = System.Drawing.SystemColors.Control;
			_Label24_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_11.Location = new System.Drawing.Point(430, 128);
			_Label24_11.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_11.Name = "_Label24_11";
			_Label24_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_11.Size = new System.Drawing.Size(75, 17);
			_Label24_11.TabIndex = 300;
			_Label24_11.Text = "Item Type:";
			// 
			// _Label24_12
			// 
			_Label24_12.AllowDrop = true;
			_Label24_12.BackColor = System.Drawing.SystemColors.Control;
			_Label24_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_12.Location = new System.Drawing.Point(430, 162);
			_Label24_12.MinimumSize = new System.Drawing.Size(89, 17);
			_Label24_12.Name = "_Label24_12";
			_Label24_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_12.Size = new System.Drawing.Size(89, 17);
			_Label24_12.TabIndex = 301;
			_Label24_12.Text = "Item Description:";
			// 
			// _Label24_13
			// 
			_Label24_13.AllowDrop = true;
			_Label24_13.BackColor = System.Drawing.SystemColors.Control;
			_Label24_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_13.Location = new System.Drawing.Point(428, 262);
			_Label24_13.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_13.Name = "_Label24_13";
			_Label24_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_13.Size = new System.Drawing.Size(75, 17);
			_Label24_13.TabIndex = 302;
			_Label24_13.Text = "Month Duration";
			// 
			// _Label24_14
			// 
			_Label24_14.AllowDrop = true;
			_Label24_14.BackColor = System.Drawing.SystemColors.Control;
			_Label24_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_14.Location = new System.Drawing.Point(428, 330);
			_Label24_14.MinimumSize = new System.Drawing.Size(57, 17);
			_Label24_14.Name = "_Label24_14";
			_Label24_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_14.Size = new System.Drawing.Size(57, 17);
			_Label24_14.TabIndex = 303;
			_Label24_14.Text = "Load?";
			// 
			// _Label24_42
			// 
			_Label24_42.AllowDrop = true;
			_Label24_42.BackColor = System.Drawing.SystemColors.Control;
			_Label24_42.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_42.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_42.Location = new System.Drawing.Point(428, 296);
			_Label24_42.MinimumSize = new System.Drawing.Size(75, 17);
			_Label24_42.Name = "_Label24_42";
			_Label24_42.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_42.Size = new System.Drawing.Size(75, 17);
			_Label24_42.TabIndex = 331;
			_Label24_42.Text = "Active?";
			// 
			// _Label24_43
			// 
			_Label24_43.AllowDrop = true;
			_Label24_43.BackColor = System.Drawing.SystemColors.Control;
			_Label24_43.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label24_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label24_43.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label24_43.Location = new System.Drawing.Point(686, 60);
			_Label24_43.MinimumSize = new System.Drawing.Size(35, 17);
			_Label24_43.Name = "_Label24_43";
			_Label24_43.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label24_43.Size = new System.Drawing.Size(35, 17);
			_Label24_43.TabIndex = 346;
			_Label24_43.Text = "Sort";
			// 
			// grd_maint_items
			// 
			grd_maint_items.AllowDrop = true;
			grd_maint_items.AllowUserToAddRows = false;
			grd_maint_items.AllowUserToDeleteRows = false;
			grd_maint_items.AllowUserToResizeColumns = false;
			grd_maint_items.AllowUserToResizeColumns = grd_maint_items.ColumnHeadersVisible;
			grd_maint_items.AllowUserToResizeRows = false;
			grd_maint_items.AllowUserToResizeRows = false;
			grd_maint_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_maint_items.ColumnsCount = 2;
			grd_maint_items.FixedColumns = 0;
			grd_maint_items.FixedRows = 1;
			grd_maint_items.Location = new System.Drawing.Point(6, 44);
			grd_maint_items.Name = "grd_maint_items";
			grd_maint_items.ReadOnly = true;
			grd_maint_items.RowsCount = 2;
			grd_maint_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_maint_items.ShowCellToolTips = false;
			grd_maint_items.Size = new System.Drawing.Size(383, 413);
			grd_maint_items.StandardTab = true;
			grd_maint_items.TabIndex = 289;
			grd_maint_items.Click += new System.EventHandler(grd_maint_items_Click);
			grd_maint_items.DoubleClick += new System.EventHandler(grd_maint_items_DoubleClick);
			// 
			// _txt_maint_0
			// 
			_txt_maint_0.AcceptsReturn = true;
			_txt_maint_0.AllowDrop = true;
			_txt_maint_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_maint_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_maint_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_maint_0.Enabled = false;
			_txt_maint_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_maint_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_maint_0.Location = new System.Drawing.Point(536, 56);
			_txt_maint_0.MaxLength = 0;
			_txt_maint_0.Name = "_txt_maint_0";
			_txt_maint_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_maint_0.Size = new System.Drawing.Size(43, 23);
			_txt_maint_0.TabIndex = 332;
			// 
			// _txt_maint_1
			// 
			_txt_maint_1.AcceptsReturn = true;
			_txt_maint_1.AllowDrop = true;
			_txt_maint_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_maint_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_maint_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_maint_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_maint_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_maint_1.Location = new System.Drawing.Point(536, 90);
			_txt_maint_1.MaxLength = 0;
			_txt_maint_1.Name = "_txt_maint_1";
			_txt_maint_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_maint_1.Size = new System.Drawing.Size(301, 23);
			_txt_maint_1.TabIndex = 333;
			// 
			// _txt_maint_2
			// 
			_txt_maint_2.AcceptsReturn = true;
			_txt_maint_2.AllowDrop = true;
			_txt_maint_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_maint_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_maint_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_maint_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_maint_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_maint_2.Location = new System.Drawing.Point(536, 160);
			_txt_maint_2.MaxLength = 0;
			_txt_maint_2.Multiline = true;
			_txt_maint_2.Name = "_txt_maint_2";
			_txt_maint_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_maint_2.Size = new System.Drawing.Size(361, 93);
			_txt_maint_2.TabIndex = 334;
			// 
			// _chk_maint_0
			// 
			_chk_maint_0.AllowDrop = true;
			_chk_maint_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_maint_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_maint_0.CausesValidation = true;
			_chk_maint_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_maint_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_maint_0.Enabled = true;
			_chk_maint_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_maint_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_maint_0.Location = new System.Drawing.Point(534, 328);
			_chk_maint_0.Name = "_chk_maint_0";
			_chk_maint_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_maint_0.Size = new System.Drawing.Size(31, 17);
			_chk_maint_0.TabIndex = 335;
			_chk_maint_0.TabStop = true;
			_chk_maint_0.Text = "";
			_chk_maint_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_maint_0.Visible = true;
			// 
			// _chk_maint_1
			// 
			_chk_maint_1.AllowDrop = true;
			_chk_maint_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_maint_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_maint_1.CausesValidation = true;
			_chk_maint_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_maint_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_maint_1.Enabled = true;
			_chk_maint_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_maint_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_maint_1.Location = new System.Drawing.Point(534, 298);
			_chk_maint_1.Name = "_chk_maint_1";
			_chk_maint_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_maint_1.Size = new System.Drawing.Size(31, 17);
			_chk_maint_1.TabIndex = 336;
			_chk_maint_1.TabStop = true;
			_chk_maint_1.Text = "";
			_chk_maint_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_maint_1.Visible = true;
			// 
			// _txt_maint_3
			// 
			_txt_maint_3.AcceptsReturn = true;
			_txt_maint_3.AllowDrop = true;
			_txt_maint_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_maint_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_maint_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_maint_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_maint_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_maint_3.Location = new System.Drawing.Point(534, 262);
			_txt_maint_3.MaxLength = 0;
			_txt_maint_3.Name = "_txt_maint_3";
			_txt_maint_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_maint_3.Size = new System.Drawing.Size(41, 23);
			_txt_maint_3.TabIndex = 337;
			// 
			// cbo_maint_type
			// 
			cbo_maint_type.AllowDrop = true;
			cbo_maint_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_maint_type.CausesValidation = true;
			cbo_maint_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_maint_type.Enabled = true;
			cbo_maint_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_maint_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_maint_type.IntegralHeight = true;
			cbo_maint_type.Location = new System.Drawing.Point(536, 126);
			cbo_maint_type.Name = "cbo_maint_type";
			cbo_maint_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_maint_type.Size = new System.Drawing.Size(101, 21);
			cbo_maint_type.Sorted = false;
			cbo_maint_type.TabIndex = 338;
			cbo_maint_type.TabStop = true;
			cbo_maint_type.Visible = true;
			// 
			// _cmd_maint_0
			// 
			_cmd_maint_0.AllowDrop = true;
			_cmd_maint_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_maint_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_maint_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_maint_0.Location = new System.Drawing.Point(428, 362);
			_cmd_maint_0.Name = "_cmd_maint_0";
			_cmd_maint_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_maint_0.Size = new System.Drawing.Size(81, 23);
			_cmd_maint_0.TabIndex = 339;
			_cmd_maint_0.Text = "Cancel";
			_cmd_maint_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_maint_0.UseVisualStyleBackColor = false;
			_cmd_maint_0.Visible = false;
			_cmd_maint_0.Click += new System.EventHandler(cmd_maint_Click);
			// 
			// _cmd_maint_1
			// 
			_cmd_maint_1.AllowDrop = true;
			_cmd_maint_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_maint_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_maint_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_maint_1.Location = new System.Drawing.Point(794, 364);
			_cmd_maint_1.Name = "_cmd_maint_1";
			_cmd_maint_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_maint_1.Size = new System.Drawing.Size(81, 23);
			_cmd_maint_1.TabIndex = 340;
			_cmd_maint_1.Text = "Save";
			_cmd_maint_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_maint_1.UseVisualStyleBackColor = false;
			_cmd_maint_1.Visible = false;
			_cmd_maint_1.Click += new System.EventHandler(cmd_maint_Click);
			// 
			// _cmd_maint_2
			// 
			_cmd_maint_2.AllowDrop = true;
			_cmd_maint_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_maint_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_maint_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_maint_2.Location = new System.Drawing.Point(388, 12);
			_cmd_maint_2.Name = "_cmd_maint_2";
			_cmd_maint_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_maint_2.Size = new System.Drawing.Size(81, 23);
			_cmd_maint_2.TabIndex = 341;
			_cmd_maint_2.Text = "Add New";
			_cmd_maint_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_maint_2.UseVisualStyleBackColor = false;
			_cmd_maint_2.Click += new System.EventHandler(cmd_maint_Click);
			// 
			// _cmd_maint_3
			// 
			_cmd_maint_3.AllowDrop = true;
			_cmd_maint_3.BackColor = System.Drawing.SystemColors.Control;
			_cmd_maint_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_maint_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_maint_3.Location = new System.Drawing.Point(10, 18);
			_cmd_maint_3.Name = "_cmd_maint_3";
			_cmd_maint_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_maint_3.Size = new System.Drawing.Size(81, 23);
			_cmd_maint_3.TabIndex = 342;
			_cmd_maint_3.Text = "Refresh";
			_cmd_maint_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_maint_3.UseVisualStyleBackColor = false;
			_cmd_maint_3.Click += new System.EventHandler(cmd_maint_Click);
			// 
			// _cmd_maint_4
			// 
			_cmd_maint_4.AllowDrop = true;
			_cmd_maint_4.BackColor = System.Drawing.SystemColors.Control;
			_cmd_maint_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_maint_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_maint_4.Location = new System.Drawing.Point(596, 362);
			_cmd_maint_4.Name = "_cmd_maint_4";
			_cmd_maint_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_maint_4.Size = new System.Drawing.Size(81, 23);
			_cmd_maint_4.TabIndex = 343;
			_cmd_maint_4.Text = "Remove";
			_cmd_maint_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_maint_4.UseVisualStyleBackColor = false;
			_cmd_maint_4.Visible = false;
			_cmd_maint_4.Click += new System.EventHandler(cmd_maint_Click);
			// 
			// cmd_post
			// 
			cmd_post.AllowDrop = true;
			cmd_post.BackColor = System.Drawing.SystemColors.Control;
			cmd_post.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_post.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_post.Location = new System.Drawing.Point(426, 436);
			cmd_post.Name = "cmd_post";
			cmd_post.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_post.Size = new System.Drawing.Size(87, 27);
			cmd_post.TabIndex = 344;
			cmd_post.Text = "Post to Live";
			cmd_post.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_post.UseVisualStyleBackColor = false;
			cmd_post.Click += new System.EventHandler(cmd_post_Click);
			// 
			// _txt_maint_4
			// 
			_txt_maint_4.AcceptsReturn = true;
			_txt_maint_4.AllowDrop = true;
			_txt_maint_4.BackColor = System.Drawing.SystemColors.Window;
			_txt_maint_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_maint_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_maint_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_maint_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_maint_4.Location = new System.Drawing.Point(728, 54);
			_txt_maint_4.MaxLength = 0;
			_txt_maint_4.Name = "_txt_maint_4";
			_txt_maint_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_maint_4.Size = new System.Drawing.Size(43, 23);
			_txt_maint_4.TabIndex = 345;
			// 
			// _cmd_maint_5
			// 
			_cmd_maint_5.AllowDrop = true;
			_cmd_maint_5.BackColor = System.Drawing.SystemColors.Control;
			_cmd_maint_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_maint_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_maint_5.Location = new System.Drawing.Point(394, 154);
			_cmd_maint_5.Name = "_cmd_maint_5";
			_cmd_maint_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_maint_5.Size = new System.Drawing.Size(19, 23);
			_cmd_maint_5.TabIndex = 347;
			_cmd_maint_5.Text = "^";
			_cmd_maint_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_maint_5.UseVisualStyleBackColor = false;
			_cmd_maint_5.Click += new System.EventHandler(cmd_maint_Click);
			// 
			// _cmd_maint_6
			// 
			_cmd_maint_6.AllowDrop = true;
			_cmd_maint_6.BackColor = System.Drawing.SystemColors.Control;
			_cmd_maint_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_maint_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_maint_6.Location = new System.Drawing.Point(392, 210);
			_cmd_maint_6.Name = "_cmd_maint_6";
			_cmd_maint_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_maint_6.Size = new System.Drawing.Size(19, 23);
			_cmd_maint_6.TabIndex = 348;
			_cmd_maint_6.Text = "v";
			_cmd_maint_6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_maint_6.UseVisualStyleBackColor = false;
			_cmd_maint_6.Click += new System.EventHandler(cmd_maint_Click);
			// 
			// _tab_Lookup_TabPage20
			// 
			_tab_Lookup_TabPage20.Controls.Add(lblEngineModelsStop);
			_tab_Lookup_TabPage20.Controls.Add(lblSearchEngineModelName);
			_tab_Lookup_TabPage20.Controls.Add(lblLoading);
			_tab_Lookup_TabPage20.Controls.Add(lblEMStatus);
			_tab_Lookup_TabPage20.Controls.Add(_lblExportToExcel_0);
			_tab_Lookup_TabPage20.Controls.Add(grdEngineModels);
			_tab_Lookup_TabPage20.Controls.Add(frmEngineModels);
			_tab_Lookup_TabPage20.Controls.Add(cmdEngineModelsRefresh);
			_tab_Lookup_TabPage20.Controls.Add(txtSearchEngineModelName);
			_tab_Lookup_TabPage20.Controls.Add(chkEMFindDuplicate);
			_tab_Lookup_TabPage20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage20.Text = "Engine Models";
			// 
			// lblEngineModelsStop
			// 
			lblEngineModelsStop.AllowDrop = true;
			lblEngineModelsStop.BackColor = System.Drawing.SystemColors.Control;
			lblEngineModelsStop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblEngineModelsStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblEngineModelsStop.ForeColor = System.Drawing.Color.Blue;
			lblEngineModelsStop.Location = new System.Drawing.Point(804, 444);
			lblEngineModelsStop.MinimumSize = new System.Drawing.Size(85, 17);
			lblEngineModelsStop.Name = "lblEngineModelsStop";
			lblEngineModelsStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblEngineModelsStop.Size = new System.Drawing.Size(85, 17);
			lblEngineModelsStop.TabIndex = 353;
			lblEngineModelsStop.Text = "Stop Loading";
			lblEngineModelsStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblSearchEngineModelName
			// 
			lblSearchEngineModelName.AllowDrop = true;
			lblSearchEngineModelName.BackColor = System.Drawing.SystemColors.Control;
			lblSearchEngineModelName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSearchEngineModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSearchEngineModelName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSearchEngineModelName.Location = new System.Drawing.Point(14, 28);
			lblSearchEngineModelName.MinimumSize = new System.Drawing.Size(143, 15);
			lblSearchEngineModelName.Name = "lblSearchEngineModelName";
			lblSearchEngineModelName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSearchEngineModelName.Size = new System.Drawing.Size(143, 15);
			lblSearchEngineModelName.TabIndex = 355;
			lblSearchEngineModelName.Text = "Search Engine Model Name";
			// 
			// lblLoading
			// 
			lblLoading.AllowDrop = true;
			lblLoading.BackColor = System.Drawing.SystemColors.Control;
			lblLoading.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLoading.ForeColor = System.Drawing.SystemColors.ControlText;
			lblLoading.Location = new System.Drawing.Point(20, 444);
			lblLoading.MinimumSize = new System.Drawing.Size(253, 15);
			lblLoading.Name = "lblLoading";
			lblLoading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLoading.Size = new System.Drawing.Size(253, 15);
			lblLoading.TabIndex = 388;
			lblLoading.Text = "Loading ##,### of ##,### Records";
			// 
			// lblEMStatus
			// 
			lblEMStatus.AllowDrop = true;
			lblEMStatus.BackColor = System.Drawing.SystemColors.Control;
			lblEMStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblEMStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblEMStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			lblEMStatus.Location = new System.Drawing.Point(262, 440);
			lblEMStatus.MinimumSize = new System.Drawing.Size(441, 15);
			lblEMStatus.Name = "lblEMStatus";
			lblEMStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblEMStatus.Size = new System.Drawing.Size(441, 15);
			lblEMStatus.TabIndex = 389;
			lblEMStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblExportToExcel_0
			// 
			_lblExportToExcel_0.AllowDrop = true;
			_lblExportToExcel_0.BackColor = System.Drawing.SystemColors.Control;
			_lblExportToExcel_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblExportToExcel_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblExportToExcel_0.ForeColor = System.Drawing.Color.Blue;
			_lblExportToExcel_0.Location = new System.Drawing.Point(910, 322);
			_lblExportToExcel_0.MinimumSize = new System.Drawing.Size(95, 17);
			_lblExportToExcel_0.Name = "_lblExportToExcel_0";
			_lblExportToExcel_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblExportToExcel_0.Size = new System.Drawing.Size(95, 17);
			_lblExportToExcel_0.TabIndex = 413;
			_lblExportToExcel_0.Text = "Export to Excel";
			_lblExportToExcel_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblExportToExcel_0.Visible = false;
			_lblExportToExcel_0.Click += new System.EventHandler(lblExportToExcel_Click);
			// 
			// grdEngineModels
			// 
			grdEngineModels.AllowBigSelection = false;
			grdEngineModels.AllowDrop = true;
			grdEngineModels.AllowUserToAddRows = false;
			grdEngineModels.AllowUserToDeleteRows = false;
			grdEngineModels.AllowUserToResizeColumns = false;
			grdEngineModels.AllowUserToResizeColumns = grdEngineModels.ColumnHeadersVisible;
			grdEngineModels.AllowUserToResizeRows = false;
			grdEngineModels.AllowUserToResizeRows = false;
			grdEngineModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdEngineModels.ColumnsCount = 2;
			grdEngineModels.FixedColumns = 1;
			grdEngineModels.FixedRows = 1;
			grdEngineModels.Location = new System.Drawing.Point(12, 56);
			grdEngineModels.Name = "grdEngineModels";
			grdEngineModels.ReadOnly = true;
			grdEngineModels.RowsCount = 2;
			grdEngineModels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdEngineModels.ShowCellToolTips = false;
			grdEngineModels.Size = new System.Drawing.Size(1007, 261);
			grdEngineModels.StandardTab = true;
			grdEngineModels.TabIndex = 351;
			grdEngineModels.Click += new System.EventHandler(grdEngineModels_Click);
			// 
			// frmEngineModels
			// 
			frmEngineModels.AllowDrop = true;
			frmEngineModels.BackColor = System.Drawing.SystemColors.Control;
			frmEngineModels.Controls.Add(_txtEngineModel_15);
			frmEngineModels.Controls.Add(_txtEngineModel_14);
			frmEngineModels.Controls.Add(_txtEngineModel_13);
			frmEngineModels.Controls.Add(_txtEngineModel_12);
			frmEngineModels.Controls.Add(_txtEngineModel_11);
			frmEngineModels.Controls.Add(frmEngineModelsAction);
			frmEngineModels.Controls.Add(_txtEngineModel_10);
			frmEngineModels.Controls.Add(_txtEngineModel_9);
			frmEngineModels.Controls.Add(_txtEngineModel_8);
			frmEngineModels.Controls.Add(_txtEngineModel_7);
			frmEngineModels.Controls.Add(_txtEngineModel_6);
			frmEngineModels.Controls.Add(_txtEngineModel_5);
			frmEngineModels.Controls.Add(_txtEngineModel_4);
			frmEngineModels.Controls.Add(_txtEngineModel_3);
			frmEngineModels.Controls.Add(_txtEngineModel_2);
			frmEngineModels.Controls.Add(_txtEngineModel_1);
			frmEngineModels.Controls.Add(_chkEngineModel_1);
			frmEngineModels.Controls.Add(_chkEngineModel_0);
			frmEngineModels.Controls.Add(_txtEngineModel_0);
			frmEngineModels.Controls.Add(_lblEngMdl_14);
			frmEngineModels.Controls.Add(_lblEngMdl_13);
			frmEngineModels.Controls.Add(_lblEngMdl_12);
			frmEngineModels.Controls.Add(_lblEngMdl_11);
			frmEngineModels.Controls.Add(_lblEngMdl_10);
			frmEngineModels.Controls.Add(_lblEngMdl_9);
			frmEngineModels.Controls.Add(_lblEngMdl_8);
			frmEngineModels.Controls.Add(_lblEngMdl_7);
			frmEngineModels.Controls.Add(_lblEngMdl_6);
			frmEngineModels.Controls.Add(_lblEngMdl_5);
			frmEngineModels.Controls.Add(_lblEngMdl_4);
			frmEngineModels.Controls.Add(_lblEngMdl_3);
			frmEngineModels.Controls.Add(_lblEngMdl_2);
			frmEngineModels.Controls.Add(_lblEngMdl_1);
			frmEngineModels.Controls.Add(_lblEngMdl_0);
			frmEngineModels.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmEngineModels.Enabled = true;
			frmEngineModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmEngineModels.ForeColor = System.Drawing.SystemColors.ControlText;
			frmEngineModels.Location = new System.Drawing.Point(14, 316);
			frmEngineModels.Name = "frmEngineModels";
			frmEngineModels.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmEngineModels.Size = new System.Drawing.Size(879, 127);
			frmEngineModels.TabIndex = 352;
			frmEngineModels.Text = "Engine Model";
			frmEngineModels.Visible = true;
			// 
			// _txtEngineModel_15
			// 
			_txtEngineModel_15.AcceptsReturn = true;
			_txtEngineModel_15.AllowDrop = true;
			_txtEngineModel_15.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_15.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_15.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_15.Location = new System.Drawing.Point(212, 102);
			_txtEngineModel_15.MaxLength = 0;
			_txtEngineModel_15.Name = "_txtEngineModel_15";
			_txtEngineModel_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_15.Size = new System.Drawing.Size(571, 21);
			_txtEngineModel_15.TabIndex = 375;
			_txtEngineModel_15.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_14
			// 
			_txtEngineModel_14.AcceptsReturn = true;
			_txtEngineModel_14.AllowDrop = true;
			_txtEngineModel_14.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_14.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_14.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_14.Location = new System.Drawing.Point(730, 80);
			_txtEngineModel_14.MaxLength = 20;
			_txtEngineModel_14.Name = "_txtEngineModel_14";
			_txtEngineModel_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_14.Size = new System.Drawing.Size(53, 21);
			_txtEngineModel_14.TabIndex = 374;
			_txtEngineModel_14.Text = "0";
			_txtEngineModel_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtEngineModel_14.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_13
			// 
			_txtEngineModel_13.AcceptsReturn = true;
			_txtEngineModel_13.AllowDrop = true;
			_txtEngineModel_13.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_13.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_13.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_13.Location = new System.Drawing.Point(590, 80);
			_txtEngineModel_13.MaxLength = 20;
			_txtEngineModel_13.Name = "_txtEngineModel_13";
			_txtEngineModel_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_13.Size = new System.Drawing.Size(53, 21);
			_txtEngineModel_13.TabIndex = 373;
			_txtEngineModel_13.Text = "0";
			_txtEngineModel_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtEngineModel_13.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_12
			// 
			_txtEngineModel_12.AcceptsReturn = true;
			_txtEngineModel_12.AllowDrop = true;
			_txtEngineModel_12.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_12.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_12.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_12.Location = new System.Drawing.Point(414, 80);
			_txtEngineModel_12.MaxLength = 20;
			_txtEngineModel_12.Name = "_txtEngineModel_12";
			_txtEngineModel_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_12.Size = new System.Drawing.Size(53, 21);
			_txtEngineModel_12.TabIndex = 372;
			_txtEngineModel_12.Text = "0";
			_txtEngineModel_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtEngineModel_12.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_11
			// 
			_txtEngineModel_11.AcceptsReturn = true;
			_txtEngineModel_11.AllowDrop = true;
			_txtEngineModel_11.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_11.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_11.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_11.Location = new System.Drawing.Point(212, 80);
			_txtEngineModel_11.MaxLength = 20;
			_txtEngineModel_11.Name = "_txtEngineModel_11";
			_txtEngineModel_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_11.Size = new System.Drawing.Size(53, 21);
			_txtEngineModel_11.TabIndex = 371;
			_txtEngineModel_11.Text = "0";
			_txtEngineModel_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtEngineModel_11.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// frmEngineModelsAction
			// 
			frmEngineModelsAction.AllowDrop = true;
			frmEngineModelsAction.BackColor = System.Drawing.SystemColors.Control;
			frmEngineModelsAction.Controls.Add(cmdEngineModelsDelete);
			frmEngineModelsAction.Controls.Add(cmdEngineModelsAdd);
			frmEngineModelsAction.Controls.Add(cmdEngineModelsSave);
			frmEngineModelsAction.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmEngineModelsAction.Enabled = true;
			frmEngineModelsAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmEngineModelsAction.ForeColor = System.Drawing.SystemColors.ControlText;
			frmEngineModelsAction.Location = new System.Drawing.Point(798, 14);
			frmEngineModelsAction.Name = "frmEngineModelsAction";
			frmEngineModelsAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmEngineModelsAction.Size = new System.Drawing.Size(69, 103);
			frmEngineModelsAction.TabIndex = 354;
			frmEngineModelsAction.Text = "Action";
			frmEngineModelsAction.Visible = true;
			// 
			// cmdEngineModelsDelete
			// 
			cmdEngineModelsDelete.AllowDrop = true;
			cmdEngineModelsDelete.BackColor = System.Drawing.SystemColors.Control;
			cmdEngineModelsDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdEngineModelsDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdEngineModelsDelete.Location = new System.Drawing.Point(14, 72);
			cmdEngineModelsDelete.Name = "cmdEngineModelsDelete";
			cmdEngineModelsDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdEngineModelsDelete.Size = new System.Drawing.Size(43, 25);
			cmdEngineModelsDelete.TabIndex = 381;
			cmdEngineModelsDelete.Text = "Delete";
			cmdEngineModelsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdEngineModelsDelete.UseVisualStyleBackColor = false;
			cmdEngineModelsDelete.Click += new System.EventHandler(cmdEngineModelsDelete_Click);
			// 
			// cmdEngineModelsAdd
			// 
			cmdEngineModelsAdd.AllowDrop = true;
			cmdEngineModelsAdd.BackColor = System.Drawing.SystemColors.Control;
			cmdEngineModelsAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdEngineModelsAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdEngineModelsAdd.Location = new System.Drawing.Point(12, 44);
			cmdEngineModelsAdd.Name = "cmdEngineModelsAdd";
			cmdEngineModelsAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdEngineModelsAdd.Size = new System.Drawing.Size(43, 25);
			cmdEngineModelsAdd.TabIndex = 379;
			cmdEngineModelsAdd.Text = "Add";
			cmdEngineModelsAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdEngineModelsAdd.UseVisualStyleBackColor = false;
			cmdEngineModelsAdd.Click += new System.EventHandler(cmdEngineModelsAdd_Click);
			// 
			// cmdEngineModelsSave
			// 
			cmdEngineModelsSave.AllowDrop = true;
			cmdEngineModelsSave.BackColor = System.Drawing.SystemColors.Control;
			cmdEngineModelsSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdEngineModelsSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdEngineModelsSave.Location = new System.Drawing.Point(12, 16);
			cmdEngineModelsSave.Name = "cmdEngineModelsSave";
			cmdEngineModelsSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdEngineModelsSave.Size = new System.Drawing.Size(43, 25);
			cmdEngineModelsSave.TabIndex = 377;
			cmdEngineModelsSave.Text = "Save";
			cmdEngineModelsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdEngineModelsSave.UseVisualStyleBackColor = false;
			cmdEngineModelsSave.Click += new System.EventHandler(cmdEngineModelsSave_Click);
			// 
			// _txtEngineModel_10
			// 
			_txtEngineModel_10.AcceptsReturn = true;
			_txtEngineModel_10.AllowDrop = true;
			_txtEngineModel_10.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_10.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_10.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_10.Location = new System.Drawing.Point(414, 58);
			_txtEngineModel_10.MaxLength = 100;
			_txtEngineModel_10.Name = "_txtEngineModel_10";
			_txtEngineModel_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_10.Size = new System.Drawing.Size(371, 21);
			_txtEngineModel_10.TabIndex = 369;
			_txtEngineModel_10.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_9
			// 
			_txtEngineModel_9.AcceptsReturn = true;
			_txtEngineModel_9.AllowDrop = true;
			_txtEngineModel_9.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_9.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_9.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_9.Location = new System.Drawing.Point(212, 58);
			_txtEngineModel_9.MaxLength = 4;
			_txtEngineModel_9.Name = "_txtEngineModel_9";
			_txtEngineModel_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_9.Size = new System.Drawing.Size(53, 21);
			_txtEngineModel_9.TabIndex = 368;
			_txtEngineModel_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtEngineModel_9.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_8
			// 
			_txtEngineModel_8.AcceptsReturn = true;
			_txtEngineModel_8.AllowDrop = true;
			_txtEngineModel_8.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_8.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_8.Location = new System.Drawing.Point(74, 58);
			_txtEngineModel_8.MaxLength = 20;
			_txtEngineModel_8.Name = "_txtEngineModel_8";
			_txtEngineModel_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_8.Size = new System.Drawing.Size(53, 21);
			_txtEngineModel_8.TabIndex = 367;
			_txtEngineModel_8.Text = "0";
			_txtEngineModel_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtEngineModel_8.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_7
			// 
			_txtEngineModel_7.AcceptsReturn = true;
			_txtEngineModel_7.AllowDrop = true;
			_txtEngineModel_7.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_7.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_7.Location = new System.Drawing.Point(724, 36);
			_txtEngineModel_7.MaxLength = 10;
			_txtEngineModel_7.Name = "_txtEngineModel_7";
			_txtEngineModel_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_7.Size = new System.Drawing.Size(61, 21);
			_txtEngineModel_7.TabIndex = 366;
			_txtEngineModel_7.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_6
			// 
			_txtEngineModel_6.AcceptsReturn = true;
			_txtEngineModel_6.AllowDrop = true;
			_txtEngineModel_6.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_6.Location = new System.Drawing.Point(628, 36);
			_txtEngineModel_6.MaxLength = 10;
			_txtEngineModel_6.Name = "_txtEngineModel_6";
			_txtEngineModel_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_6.Size = new System.Drawing.Size(61, 21);
			_txtEngineModel_6.TabIndex = 365;
			_txtEngineModel_6.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_5
			// 
			_txtEngineModel_5.AcceptsReturn = true;
			_txtEngineModel_5.AllowDrop = true;
			_txtEngineModel_5.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_5.Location = new System.Drawing.Point(414, 36);
			_txtEngineModel_5.MaxLength = 20;
			_txtEngineModel_5.Name = "_txtEngineModel_5";
			_txtEngineModel_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_5.Size = new System.Drawing.Size(53, 21);
			_txtEngineModel_5.TabIndex = 364;
			_txtEngineModel_5.Text = "0";
			_txtEngineModel_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtEngineModel_5.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_4
			// 
			_txtEngineModel_4.AcceptsReturn = true;
			_txtEngineModel_4.AllowDrop = true;
			_txtEngineModel_4.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_4.Location = new System.Drawing.Point(212, 36);
			_txtEngineModel_4.MaxLength = 20;
			_txtEngineModel_4.Name = "_txtEngineModel_4";
			_txtEngineModel_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_4.Size = new System.Drawing.Size(53, 21);
			_txtEngineModel_4.TabIndex = 363;
			_txtEngineModel_4.Text = "0";
			_txtEngineModel_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtEngineModel_4.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_3
			// 
			_txtEngineModel_3.AcceptsReturn = true;
			_txtEngineModel_3.AllowDrop = true;
			_txtEngineModel_3.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_3.Location = new System.Drawing.Point(628, 14);
			_txtEngineModel_3.MaxLength = 30;
			_txtEngineModel_3.Name = "_txtEngineModel_3";
			_txtEngineModel_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_3.Size = new System.Drawing.Size(159, 21);
			_txtEngineModel_3.TabIndex = 361;
			_txtEngineModel_3.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_2
			// 
			_txtEngineModel_2.AcceptsReturn = true;
			_txtEngineModel_2.AllowDrop = true;
			_txtEngineModel_2.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_2.Location = new System.Drawing.Point(414, 14);
			_txtEngineModel_2.MaxLength = 30;
			_txtEngineModel_2.Name = "_txtEngineModel_2";
			_txtEngineModel_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_2.Size = new System.Drawing.Size(133, 21);
			_txtEngineModel_2.TabIndex = 360;
			_txtEngineModel_2.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _txtEngineModel_1
			// 
			_txtEngineModel_1.AcceptsReturn = true;
			_txtEngineModel_1.AllowDrop = true;
			_txtEngineModel_1.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_1.Enabled = false;
			_txtEngineModel_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_1.Location = new System.Drawing.Point(212, 14);
			_txtEngineModel_1.MaxLength = 30;
			_txtEngineModel_1.Name = "_txtEngineModel_1";
			_txtEngineModel_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_1.Size = new System.Drawing.Size(133, 21);
			_txtEngineModel_1.TabIndex = 359;
			_txtEngineModel_1.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _chkEngineModel_1
			// 
			_chkEngineModel_1.AllowDrop = true;
			_chkEngineModel_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkEngineModel_1.BackColor = System.Drawing.SystemColors.Control;
			_chkEngineModel_1.CausesValidation = true;
			_chkEngineModel_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkEngineModel_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkEngineModel_1.Enabled = true;
			_chkEngineModel_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkEngineModel_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkEngineModel_1.Location = new System.Drawing.Point(14, 84);
			_chkEngineModel_1.Name = "_chkEngineModel_1";
			_chkEngineModel_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkEngineModel_1.Size = new System.Drawing.Size(115, 13);
			_chkEngineModel_1.TabIndex = 370;
			_chkEngineModel_1.TabStop = true;
			_chkEngineModel_1.Text = "On Condition TBO";
			_chkEngineModel_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkEngineModel_1.Visible = true;
			// 
			// _chkEngineModel_0
			// 
			_chkEngineModel_0.AllowDrop = true;
			_chkEngineModel_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkEngineModel_0.BackColor = System.Drawing.SystemColors.Control;
			_chkEngineModel_0.CausesValidation = true;
			_chkEngineModel_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkEngineModel_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkEngineModel_0.Enabled = true;
			_chkEngineModel_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkEngineModel_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkEngineModel_0.Location = new System.Drawing.Point(14, 40);
			_chkEngineModel_0.Name = "_chkEngineModel_0";
			_chkEngineModel_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkEngineModel_0.Size = new System.Drawing.Size(73, 13);
			_chkEngineModel_0.TabIndex = 362;
			_chkEngineModel_0.TabStop = true;
			_chkEngineModel_0.Text = "Active";
			_chkEngineModel_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkEngineModel_0.Visible = true;
			// 
			// _txtEngineModel_0
			// 
			_txtEngineModel_0.AcceptsReturn = true;
			_txtEngineModel_0.AllowDrop = true;
			_txtEngineModel_0.BackColor = System.Drawing.SystemColors.Window;
			_txtEngineModel_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtEngineModel_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtEngineModel_0.Enabled = false;
			_txtEngineModel_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtEngineModel_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtEngineModel_0.Location = new System.Drawing.Point(74, 14);
			_txtEngineModel_0.MaxLength = 20;
			_txtEngineModel_0.Name = "_txtEngineModel_0";
			_txtEngineModel_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtEngineModel_0.Size = new System.Drawing.Size(53, 21);
			_txtEngineModel_0.TabIndex = 358;
			_txtEngineModel_0.Text = "0";
			_txtEngineModel_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txtEngineModel_0.Leave += new System.EventHandler(txtEngineModel_Leave);
			// 
			// _lblEngMdl_14
			// 
			_lblEngMdl_14.AllowDrop = true;
			_lblEngMdl_14.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_14.Location = new System.Drawing.Point(14, 104);
			_lblEngMdl_14.MinimumSize = new System.Drawing.Size(191, 15);
			_lblEngMdl_14.Name = "_lblEngMdl_14";
			_lblEngMdl_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_14.Size = new System.Drawing.Size(191, 15);
			_lblEngMdl_14.TabIndex = 396;
			_lblEngMdl_14.Text = "Make/Models Assigned This Engine";
			// 
			// _lblEngMdl_13
			// 
			_lblEngMdl_13.AllowDrop = true;
			_lblEngMdl_13.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_13.Location = new System.Drawing.Point(700, 84);
			_lblEngMdl_13.MinimumSize = new System.Drawing.Size(23, 13);
			_lblEngMdl_13.Name = "_lblEngMdl_13";
			_lblEngMdl_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_13.Size = new System.Drawing.Size(23, 13);
			_lblEngMdl_13.TabIndex = 395;
			_lblEngMdl_13.Text = "HSI";
			// 
			// _lblEngMdl_12
			// 
			_lblEngMdl_12.AllowDrop = true;
			_lblEngMdl_12.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_12.Location = new System.Drawing.Point(538, 84);
			_lblEngMdl_12.MinimumSize = new System.Drawing.Size(43, 13);
			_lblEngMdl_12.Name = "_lblEngMdl_12";
			_lblEngMdl_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_12.Size = new System.Drawing.Size(43, 13);
			_lblEngMdl_12.TabIndex = 394;
			_lblEngMdl_12.Text = "Shaft HP";
			// 
			// _lblEngMdl_11
			// 
			_lblEngMdl_11.AllowDrop = true;
			_lblEngMdl_11.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_11.Location = new System.Drawing.Point(352, 84);
			_lblEngMdl_11.MinimumSize = new System.Drawing.Size(55, 13);
			_lblEngMdl_11.Name = "_lblEngMdl_11";
			_lblEngMdl_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_11.Size = new System.Drawing.Size(55, 13);
			_lblEngMdl_11.TabIndex = 393;
			_lblEngMdl_11.Text = "TBO Hours";
			// 
			// _lblEngMdl_10
			// 
			_lblEngMdl_10.AllowDrop = true;
			_lblEngMdl_10.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_10.Location = new System.Drawing.Point(138, 84);
			_lblEngMdl_10.MinimumSize = new System.Drawing.Size(55, 13);
			_lblEngMdl_10.Name = "_lblEngMdl_10";
			_lblEngMdl_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_10.Size = new System.Drawing.Size(55, 13);
			_lblEngMdl_10.TabIndex = 392;
			_lblEngMdl_10.Text = "Thrust Lbs";
			// 
			// _lblEngMdl_9
			// 
			_lblEngMdl_9.AllowDrop = true;
			_lblEngMdl_9.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_9.Location = new System.Drawing.Point(352, 60);
			_lblEngMdl_9.MinimumSize = new System.Drawing.Size(55, 13);
			_lblEngMdl_9.Name = "_lblEngMdl_9";
			_lblEngMdl_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_9.Size = new System.Drawing.Size(55, 13);
			_lblEngMdl_9.TabIndex = 387;
			_lblEngMdl_9.Text = "Mfr Name";
			// 
			// _lblEngMdl_8
			// 
			_lblEngMdl_8.AllowDrop = true;
			_lblEngMdl_8.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_8.Location = new System.Drawing.Point(138, 60);
			_lblEngMdl_8.MinimumSize = new System.Drawing.Size(67, 13);
			_lblEngMdl_8.Name = "_lblEngMdl_8";
			_lblEngMdl_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_8.Size = new System.Drawing.Size(67, 13);
			_lblEngMdl_8.TabIndex = 386;
			_lblEngMdl_8.Text = "Mfr Abbrev";
			// 
			// _lblEngMdl_7
			// 
			_lblEngMdl_7.AllowDrop = true;
			_lblEngMdl_7.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_7.Location = new System.Drawing.Point(14, 60);
			_lblEngMdl_7.MinimumSize = new System.Drawing.Size(55, 13);
			_lblEngMdl_7.Name = "_lblEngMdl_7";
			_lblEngMdl_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_7.Size = new System.Drawing.Size(55, 13);
			_lblEngMdl_7.TabIndex = 385;
			_lblEngMdl_7.Text = "Mfr CompId";
			// 
			// _lblEngMdl_6
			// 
			_lblEngMdl_6.AllowDrop = true;
			_lblEngMdl_6.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_6.Location = new System.Drawing.Point(352, 40);
			_lblEngMdl_6.MinimumSize = new System.Drawing.Size(57, 13);
			_lblEngMdl_6.Name = "_lblEngMdl_6";
			_lblEngMdl_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_6.Size = new System.Drawing.Size(57, 13);
			_lblEngMdl_6.TabIndex = 384;
			_lblEngMdl_6.Text = "Max Power";
			// 
			// _lblEngMdl_5
			// 
			_lblEngMdl_5.AllowDrop = true;
			_lblEngMdl_5.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_5.Location = new System.Drawing.Point(138, 40);
			_lblEngMdl_5.MinimumSize = new System.Drawing.Size(71, 13);
			_lblEngMdl_5.Name = "_lblEngMdl_5";
			_lblEngMdl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_5.Size = new System.Drawing.Size(71, 13);
			_lblEngMdl_5.TabIndex = 383;
			_lblEngMdl_5.Text = "Takeoff Power";
			// 
			// _lblEngMdl_4
			// 
			_lblEngMdl_4.AllowDrop = true;
			_lblEngMdl_4.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_4.Location = new System.Drawing.Point(570, 40);
			_lblEngMdl_4.MinimumSize = new System.Drawing.Size(55, 13);
			_lblEngMdl_4.Name = "_lblEngMdl_4";
			_lblEngMdl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_4.Size = new System.Drawing.Size(55, 13);
			_lblEngMdl_4.TabIndex = 382;
			_lblEngMdl_4.Text = "Suffix 1 - 2";
			// 
			// _lblEngMdl_3
			// 
			_lblEngMdl_3.AllowDrop = true;
			_lblEngMdl_3.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_3.Location = new System.Drawing.Point(570, 16);
			_lblEngMdl_3.MinimumSize = new System.Drawing.Size(27, 13);
			_lblEngMdl_3.Name = "_lblEngMdl_3";
			_lblEngMdl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_3.Size = new System.Drawing.Size(27, 13);
			_lblEngMdl_3.TabIndex = 380;
			_lblEngMdl_3.Text = "Core";
			// 
			// _lblEngMdl_2
			// 
			_lblEngMdl_2.AllowDrop = true;
			_lblEngMdl_2.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_2.Location = new System.Drawing.Point(352, 16);
			_lblEngMdl_2.MinimumSize = new System.Drawing.Size(35, 13);
			_lblEngMdl_2.Name = "_lblEngMdl_2";
			_lblEngMdl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_2.Size = new System.Drawing.Size(35, 13);
			_lblEngMdl_2.TabIndex = 378;
			_lblEngMdl_2.Text = "Prefix";
			// 
			// _lblEngMdl_1
			// 
			_lblEngMdl_1.AllowDrop = true;
			_lblEngMdl_1.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_1.Location = new System.Drawing.Point(138, 16);
			_lblEngMdl_1.MinimumSize = new System.Drawing.Size(67, 13);
			_lblEngMdl_1.Name = "_lblEngMdl_1";
			_lblEngMdl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_1.Size = new System.Drawing.Size(67, 13);
			_lblEngMdl_1.TabIndex = 376;
			_lblEngMdl_1.Text = "Engine Name";
			// 
			// _lblEngMdl_0
			// 
			_lblEngMdl_0.AllowDrop = true;
			_lblEngMdl_0.BackColor = System.Drawing.SystemColors.Control;
			_lblEngMdl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblEngMdl_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblEngMdl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblEngMdl_0.Location = new System.Drawing.Point(14, 16);
			_lblEngMdl_0.MinimumSize = new System.Drawing.Size(37, 13);
			_lblEngMdl_0.Name = "_lblEngMdl_0";
			_lblEngMdl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblEngMdl_0.Size = new System.Drawing.Size(37, 13);
			_lblEngMdl_0.TabIndex = 356;
			_lblEngMdl_0.Text = "EM Id";
			// 
			// cmdEngineModelsRefresh
			// 
			cmdEngineModelsRefresh.AllowDrop = true;
			cmdEngineModelsRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdEngineModelsRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdEngineModelsRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdEngineModelsRefresh.Location = new System.Drawing.Point(790, 20);
			cmdEngineModelsRefresh.Name = "cmdEngineModelsRefresh";
			cmdEngineModelsRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdEngineModelsRefresh.Size = new System.Drawing.Size(81, 25);
			cmdEngineModelsRefresh.TabIndex = 357;
			cmdEngineModelsRefresh.Text = "Refresh";
			cmdEngineModelsRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdEngineModelsRefresh.UseVisualStyleBackColor = false;
			cmdEngineModelsRefresh.Click += new System.EventHandler(cmdEngineModelsRefresh_Click);
			// 
			// txtSearchEngineModelName
			// 
			txtSearchEngineModelName.AcceptsReturn = true;
			txtSearchEngineModelName.AllowDrop = true;
			txtSearchEngineModelName.BackColor = System.Drawing.SystemColors.Window;
			txtSearchEngineModelName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSearchEngineModelName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSearchEngineModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSearchEngineModelName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSearchEngineModelName.Location = new System.Drawing.Point(164, 24);
			txtSearchEngineModelName.MaxLength = 0;
			txtSearchEngineModelName.Name = "txtSearchEngineModelName";
			txtSearchEngineModelName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSearchEngineModelName.Size = new System.Drawing.Size(233, 23);
			txtSearchEngineModelName.TabIndex = 390;
			// 
			// chkEMFindDuplicate
			// 
			chkEMFindDuplicate.AllowDrop = true;
			chkEMFindDuplicate.Appearance = System.Windows.Forms.Appearance.Normal;
			chkEMFindDuplicate.BackColor = System.Drawing.SystemColors.Control;
			chkEMFindDuplicate.CausesValidation = true;
			chkEMFindDuplicate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkEMFindDuplicate.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkEMFindDuplicate.Enabled = true;
			chkEMFindDuplicate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkEMFindDuplicate.ForeColor = System.Drawing.SystemColors.ControlText;
			chkEMFindDuplicate.Location = new System.Drawing.Point(418, 28);
			chkEMFindDuplicate.Name = "chkEMFindDuplicate";
			chkEMFindDuplicate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkEMFindDuplicate.Size = new System.Drawing.Size(223, 13);
			chkEMFindDuplicate.TabIndex = 391;
			chkEMFindDuplicate.TabStop = true;
			chkEMFindDuplicate.Text = "Find Duplicate Engine Name Records";
			chkEMFindDuplicate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkEMFindDuplicate.Visible = true;
			// 
			// _tab_Lookup_TabPage21
			// 
			_tab_Lookup_TabPage21.Controls.Add(cmd_Launch_av_items);
			_tab_Lookup_TabPage21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage21.Text = "Avionics Items";
			// 
			// cmd_Launch_av_items
			// 
			cmd_Launch_av_items.AllowDrop = true;
			cmd_Launch_av_items.BackColor = System.Drawing.SystemColors.Control;
			cmd_Launch_av_items.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Launch_av_items.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Launch_av_items.Location = new System.Drawing.Point(30, 18);
			cmd_Launch_av_items.Name = "cmd_Launch_av_items";
			cmd_Launch_av_items.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Launch_av_items.Size = new System.Drawing.Size(331, 85);
			cmd_Launch_av_items.TabIndex = 397;
			cmd_Launch_av_items.Text = "Open Avionics Item Web Page";
			cmd_Launch_av_items.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Launch_av_items.UseVisualStyleBackColor = false;
			cmd_Launch_av_items.Click += new System.EventHandler(cmd_Launch_av_items_Click);
			// 
			// _tab_Lookup_TabPage22
			// 
			_tab_Lookup_TabPage22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage22.Text = "Open";
			// 
			// _tab_Lookup_TabPage23
			// 
			_tab_Lookup_TabPage23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage23.Text = "Open";
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
			tbr_ToolBar.TabIndex = 53;
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
			// pnlAdmin
			// 
			pnlAdmin.AllowDrop = true;
			pnlAdmin.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			pnlAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlAdmin.Controls.Add(chkShowCounts);
			pnlAdmin.Controls.Add(chk_AutoGen);
			pnlAdmin.Controls.Add(txt_kfeat_query);
			pnlAdmin.Controls.Add(lbl_rule_note);
			pnlAdmin.Controls.Add(_lblCount_2);
			pnlAdmin.Controls.Add(_lblCount_1);
			pnlAdmin.Controls.Add(_lblCount_0);
			pnlAdmin.Controls.Add(Label39);
			pnlAdmin.Controls.Add(lbl_kfeat_query);
			pnlAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlAdmin.Location = new System.Drawing.Point(16, 608);
			pnlAdmin.Name = "pnlAdmin";
			pnlAdmin.Size = new System.Drawing.Size(1021, 104);
			pnlAdmin.TabIndex = 159;
			pnlAdmin.Visible = false;
			// 
			// chkShowCounts
			// 
			chkShowCounts.AllowDrop = true;
			chkShowCounts.Appearance = System.Windows.Forms.Appearance.Normal;
			chkShowCounts.BackColor = System.Drawing.SystemColors.Control;
			chkShowCounts.CausesValidation = true;
			chkShowCounts.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkShowCounts.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkShowCounts.Enabled = true;
			chkShowCounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkShowCounts.ForeColor = System.Drawing.SystemColors.ControlText;
			chkShowCounts.Location = new System.Drawing.Point(7, 56);
			chkShowCounts.Name = "chkShowCounts";
			chkShowCounts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkShowCounts.Size = new System.Drawing.Size(89, 15);
			chkShowCounts.TabIndex = 162;
			chkShowCounts.TabStop = true;
			chkShowCounts.Text = "Show Counts";
			chkShowCounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkShowCounts.Visible = true;
			chkShowCounts.CheckStateChanged += new System.EventHandler(chkShowCounts_CheckStateChanged);
			// 
			// chk_AutoGen
			// 
			chk_AutoGen.AllowDrop = true;
			chk_AutoGen.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_AutoGen.BackColor = System.Drawing.SystemColors.Control;
			chk_AutoGen.CausesValidation = true;
			chk_AutoGen.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_AutoGen.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_AutoGen.Enabled = true;
			chk_AutoGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_AutoGen.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_AutoGen.Location = new System.Drawing.Point(8, 24);
			chk_AutoGen.Name = "chk_AutoGen";
			chk_AutoGen.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_AutoGen.Size = new System.Drawing.Size(201, 33);
			chk_AutoGen.TabIndex = 161;
			chk_AutoGen.TabStop = true;
			chk_AutoGen.Text = "Automatic Key Feature Maintenance";
			chk_AutoGen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_AutoGen.Visible = true;
			// 
			// txt_kfeat_query
			// 
			txt_kfeat_query.AcceptsReturn = true;
			txt_kfeat_query.AllowDrop = true;
			txt_kfeat_query.BackColor = System.Drawing.SystemColors.Window;
			txt_kfeat_query.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_kfeat_query.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_kfeat_query.Enabled = false;
			txt_kfeat_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_kfeat_query.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_kfeat_query.Location = new System.Drawing.Point(211, 25);
			txt_kfeat_query.MaxLength = 0;
			txt_kfeat_query.Multiline = true;
			txt_kfeat_query.Name = "txt_kfeat_query";
			txt_kfeat_query.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_kfeat_query.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txt_kfeat_query.Size = new System.Drawing.Size(801, 54);
			txt_kfeat_query.TabIndex = 20;
			// 
			// lbl_rule_note
			// 
			lbl_rule_note.AllowDrop = true;
			lbl_rule_note.BackColor = System.Drawing.SystemColors.Control;
			lbl_rule_note.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_rule_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_rule_note.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			lbl_rule_note.Location = new System.Drawing.Point(351, 7);
			lbl_rule_note.MinimumSize = new System.Drawing.Size(409, 17);
			lbl_rule_note.Name = "lbl_rule_note";
			lbl_rule_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_rule_note.Size = new System.Drawing.Size(409, 17);
			lbl_rule_note.TabIndex = 201;
			lbl_rule_note.Text = "double click on this text to select a list of aircraft models based on the query";
			lbl_rule_note.DoubleClick += new System.EventHandler(lbl_rule_note_DoubleClick);
			// 
			// _lblCount_2
			// 
			_lblCount_2.AllowDrop = true;
			_lblCount_2.AutoSize = true;
			_lblCount_2.BackColor = System.Drawing.Color.Transparent;
			_lblCount_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCount_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCount_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCount_2.Location = new System.Drawing.Point(112, 88);
			_lblCount_2.MinimumSize = new System.Drawing.Size(639, 13);
			_lblCount_2.Name = "_lblCount_2";
			_lblCount_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCount_2.Size = new System.Drawing.Size(639, 13);
			_lblCount_2.TabIndex = 167;
			_lblCount_2.Text = "Data";
			_lblCount_2.Visible = false;
			// 
			// _lblCount_1
			// 
			_lblCount_1.AllowDrop = true;
			_lblCount_1.AutoSize = true;
			_lblCount_1.BackColor = System.Drawing.Color.Transparent;
			_lblCount_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCount_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCount_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCount_1.Location = new System.Drawing.Point(112, 72);
			_lblCount_1.MinimumSize = new System.Drawing.Size(14, 13);
			_lblCount_1.Name = "_lblCount_1";
			_lblCount_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCount_1.Size = new System.Drawing.Size(14, 13);
			_lblCount_1.TabIndex = 166;
			_lblCount_1.Text = "No";
			_lblCount_1.Visible = false;
			// 
			// _lblCount_0
			// 
			_lblCount_0.AllowDrop = true;
			_lblCount_0.AutoSize = true;
			_lblCount_0.BackColor = System.Drawing.Color.Transparent;
			_lblCount_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCount_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCount_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCount_0.Location = new System.Drawing.Point(112, 56);
			_lblCount_0.MinimumSize = new System.Drawing.Size(18, 13);
			_lblCount_0.Name = "_lblCount_0";
			_lblCount_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCount_0.Size = new System.Drawing.Size(18, 13);
			_lblCount_0.TabIndex = 165;
			_lblCount_0.Text = "Yes";
			_lblCount_0.Visible = false;
			// 
			// Label39
			// 
			Label39.AllowDrop = true;
			Label39.BackColor = System.Drawing.SystemColors.Control;
			Label39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label39.ForeColor = System.Drawing.SystemColors.ControlText;
			Label39.Location = new System.Drawing.Point(8, 8);
			Label39.MinimumSize = new System.Drawing.Size(161, 17);
			Label39.Name = "Label39";
			Label39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label39.Size = new System.Drawing.Size(161, 17);
			Label39.TabIndex = 163;
			Label39.Text = "KEY FEATURE RULES";
			// 
			// lbl_kfeat_query
			// 
			lbl_kfeat_query.AllowDrop = true;
			lbl_kfeat_query.AutoSize = true;
			lbl_kfeat_query.BackColor = System.Drawing.Color.Transparent;
			lbl_kfeat_query.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_kfeat_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_kfeat_query.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_kfeat_query.Location = new System.Drawing.Point(216, 8);
			lbl_kfeat_query.MinimumSize = new System.Drawing.Size(113, 13);
			lbl_kfeat_query.Name = "lbl_kfeat_query";
			lbl_kfeat_query.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_kfeat_query.Size = new System.Drawing.Size(113, 13);
			lbl_kfeat_query.TabIndex = 160;
			lbl_kfeat_query.Text = "Key Feture Rule - Query";
			// 
			// _lbl_generic_2
			// 
			_lbl_generic_2.AllowDrop = true;
			_lbl_generic_2.BackColor = System.Drawing.SystemColors.Control;
			_lbl_generic_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_generic_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_generic_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_generic_2.Location = new System.Drawing.Point(0, 24);
			_lbl_generic_2.MinimumSize = new System.Drawing.Size(54, 12);
			_lbl_generic_2.Name = "_lbl_generic_2";
			_lbl_generic_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_generic_2.Size = new System.Drawing.Size(54, 12);
			_lbl_generic_2.TabIndex = 224;
			_lbl_generic_2.Text = "Journ ID:";
			// 
			// frm_AircraftLookup
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(1086, 713);
			ControlBox = false;
			Controls.Add(tab_Lookup);
			Controls.Add(tbr_ToolBar);
			Controls.Add(pnlAdmin);
			Controls.Add(_lbl_generic_2);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(735, 306);
			MaximizeBox = true;
			MinimizeBox = false;
			Name = "frm_AircraftLookup";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Aircraft Lookup Table Maintenance";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(cmd_Delete_Kfeat, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Kfeat, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Kfeat, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Kfeat, 0);
			commandButtonHelper1.SetStyle(cmd_CloseAutoModel, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Aircraft_Status, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_Aircraft_Status, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Aircraft_Status, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Aircraft_Status, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Asking, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Asking, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Asking, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_Asking, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_Avionics, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Avionics, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Avionics, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Avionics, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Aircraft_Class, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Aircraft_Class, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Aircraft_Class, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_Aircraft_Class, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Aircraft_type, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_Aircraft_Type, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Aircraft_Type, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Aircraft_Type, 0);
			commandButtonHelper1.SetStyle(cmd_Save_EMP, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_EMP, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_EMP, 0);
			commandButtonHelper1.SetStyle(cmd_Add_EMP, 0);
			commandButtonHelper1.SetStyle(cmd_Add_IC, 0);
			commandButtonHelper1.SetStyle(cmd_Save_IC, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_IC, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_IC, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Aircraft_Contact_type, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_Aircraft_Contact_Type, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Aircraft_Contact_Type, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Aircraft_Contact_Type, 0);
			commandButtonHelper1.SetStyle(cmd_Add_APU, 0);
			commandButtonHelper1.SetStyle(cmd_Save_APU, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_APU, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_APU, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Certification, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_Certification, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Certification, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Certification, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Spec, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_Spec, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Spec, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Spec, 0);
			commandButtonHelper1.SetStyle(_cmdAirportPreviousNext_1, 0);
			commandButtonHelper1.SetStyle(_cmdAirportPreviousNext_0, 0);
			commandButtonHelper1.SetStyle(cmd_Airport_Add, 0);
			commandButtonHelper1.SetStyle(cmd_Airport_Delete, 0);
			commandButtonHelper1.SetStyle(cmd_Airport_Cancel, 0);
			commandButtonHelper1.SetStyle(cmd_Airport_Save, 0);
			commandButtonHelper1.SetStyle(cmd_Refresh_Airports, 0);
			commandButtonHelper1.SetStyle(cmd_save_certified, 0);
			commandButtonHelper1.SetStyle(cmd_cancel_certified, 0);
			commandButtonHelper1.SetStyle(cmd_delete_certified, 0);
			commandButtonHelper1.SetStyle(cmd_certified_add, 0);
			commandButtonHelper1.SetStyle(cmdAddCREG, 0);
			commandButtonHelper1.SetStyle(cmdSaveCREG, 0);
			commandButtonHelper1.SetStyle(cmdCancelCREG, 0);
			commandButtonHelper1.SetStyle(cmdDeleteCREG, 0);
			commandButtonHelper1.SetStyle(_cmd_button_2, 0);
			commandButtonHelper1.SetStyle(_cmd_button_1, 0);
			commandButtonHelper1.SetStyle(_cmd_button_0, 0);
			commandButtonHelper1.SetStyle(_cmd_button_3, 0);
			commandButtonHelper1.SetStyle(acTopicsUpdateEvo, 0);
			commandButtonHelper1.SetStyle(acTopicAdd, 0);
			commandButtonHelper1.SetStyle(acTopicSave, 0);
			commandButtonHelper1.SetStyle(acTopicCancel, 0);
			commandButtonHelper1.SetStyle(acTopicDelete, 0);
			commandButtonHelper1.SetStyle(acTopicsListClose, 0);
			commandButtonHelper1.SetStyle(_cmd_maint_0, 0);
			commandButtonHelper1.SetStyle(_cmd_maint_1, 0);
			commandButtonHelper1.SetStyle(_cmd_maint_2, 0);
			commandButtonHelper1.SetStyle(_cmd_maint_3, 0);
			commandButtonHelper1.SetStyle(_cmd_maint_4, 0);
			commandButtonHelper1.SetStyle(cmd_post, 0);
			commandButtonHelper1.SetStyle(_cmd_maint_5, 0);
			commandButtonHelper1.SetStyle(_cmd_maint_6, 0);
			commandButtonHelper1.SetStyle(cmdEngineModelsDelete, 0);
			commandButtonHelper1.SetStyle(cmdEngineModelsAdd, 0);
			commandButtonHelper1.SetStyle(cmdEngineModelsSave, 0);
			commandButtonHelper1.SetStyle(cmdEngineModelsRefresh, 0);
			commandButtonHelper1.SetStyle(cmd_Launch_av_items, 0);
			ToolTipMain.SetToolTip(_cmdAirportPreviousNext_1, "Click For Next (Down) Airport In List");
			ToolTipMain.SetToolTip(_cmdAirportPreviousNext_0, "Click For Prevous (Up) Airport In List");
			ToolTipMain.SetToolTip(_txtAirport_9, "Degrees, Minutes & Seconds");
			ToolTipMain.SetToolTip(_txtAirport_17, "Longitude In Decmial Format");
			ToolTipMain.SetToolTip(_txtAirport_16, "Latitude In Decmial Format");
			ToolTipMain.SetToolTip(_txtAirport_4, "Degrees, Minutes & Seconds");
			ToolTipMain.SetToolTip(lblLatitudeGPS, "Click To Enter Coordinates in GPS Format");
			ToolTipMain.SetToolTip(_lblAirport_24, "Click To Clear Latitude/Longatude Fields");
			ToolTipMain.SetToolTip(_lblAirport_19, "Click To Enter Decimal Lat/Long Values From Google");
			ToolTipMain.SetToolTip(_lblAirport_4, "Click To Update Flight Data Records With New Lat/Long");
			ToolTipMain.SetToolTip(_txtAirport_19, "Company Id");
			ToolTipMain.SetToolTip(_txtAirport_15, "Enter Feet (FT), Mile (MI), Meter (MR) or Kilometer (KM)");
			ToolTipMain.SetToolTip(_lblAirport_13, "Click To View Airport Information From Airport IQ Website");
			ToolTipMain.SetToolTip(_lblAirport_9, "Click To View Airport Information From FAA Website");
			ToolTipMain.SetToolTip(_lblAirport_23, "Click To View Airport Great Circle Mapper Website");
			ToolTipMain.SetToolTip(_lblAirport_22, "Click To View Airport Nav Finder Website");
			ToolTipMain.SetToolTip(_lblAirport_21, "Click To View Acukwik Website");
			ToolTipMain.SetToolTip(_lblAirport_17, "Click To View AirNav Website");
			ToolTipMain.SetToolTip(_lblAirport_16, "Click To Find Airport Using Google Maps");
			ToolTipMain.SetToolTip(_lblAirport_0, "Click To View Next Airport In List Box");
			ToolTipMain.SetToolTip(_chkAirportListOptions_8, "List FAA Flight Data Count");
			ToolTipMain.SetToolTip(_chkAirportListOptions_4, "List Airports WithMax Runway Length");
			ToolTipMain.SetToolTip(_chkAirportListOptions_5, "List Airports Without Runway Length");
			ToolTipMain.SetToolTip(_chkAirportListOptions_3, "List Airports Without Latitude and Longitude Coordinates");
			ToolTipMain.SetToolTip(_chkAirportListOptions_2, "List Airports With Latitude and Longitude Coordinates");
			ToolTipMain.SetToolTip(lblGlobal, "Click To Clear");
			ToolTipMain.SetToolTip(lblICAOIndex, "Click To Clear");
			ToolTipMain.SetToolTip(lblFAAIDIndex, "Click To Clear");
			ToolTipMain.SetToolTip(lblIATAIndex, "Click To Clear");
			ToolTipMain.SetToolTip(acTopicErrorDisplay, "Double 'Click' to verify query");
			ToolTipMain.SetToolTip(cmdEngineModelsDelete, "Clear To Delete Current Engine Model");
			ToolTipMain.SetToolTip(cmdEngineModelsAdd, "Clear To Clear Data And Add New Engine Model");
			ToolTipMain.SetToolTip(cmdEngineModelsSave, "Click To Save Engine Model Information");
			Activated += new System.EventHandler(frm_AircraftLookup_Activated);
			Closed += new System.EventHandler(Form_Closed);
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_FormClosing);
			((System.ComponentModel.ISupportInitialize) FG_KeyFeature).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_AutoMod).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Aircraft_Status).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_AirCraft_Asking).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Avionics).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Aircraft_Class).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Aircraft_Type).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Engine_Maintenance).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Interior_Configuration).EndInit();
			((System.ComponentModel.ISupportInitialize) FGRD_AircraftContactType).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Auxiliary_Power).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Operating_Certification).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Specification).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Airport).EndInit();
			((System.ComponentModel.ISupportInitialize) FGRD_Certifed).EndInit();
			((System.ComponentModel.ISupportInitialize) grdCREG).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_ABI_Hide_AC).EndInit();
			((System.ComponentModel.ISupportInitialize) acTopicsGrid).EndInit();
			((System.ComponentModel.ISupportInitialize) acTopicAircraftList).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_maint_items).EndInit();
			((System.ComponentModel.ISupportInitialize) grdEngineModels).EndInit();
			tab_Lookup.ResumeLayout(false);
			tab_Lookup.PerformLayout();
			_tab_Lookup_TabPage0.ResumeLayout(false);
			_tab_Lookup_TabPage0.PerformLayout();
			pnl_kfeat_test.ResumeLayout(false);
			pnl_kfeat_test.PerformLayout();
			frame_automodels.ResumeLayout(false);
			frame_automodels.PerformLayout();
			_tab_Lookup_TabPage1.ResumeLayout(false);
			_tab_Lookup_TabPage1.PerformLayout();
			pnl_Update_Aircraft_Status.ResumeLayout(false);
			pnl_Update_Aircraft_Status.PerformLayout();
			_tab_Lookup_TabPage2.ResumeLayout(false);
			_tab_Lookup_TabPage2.PerformLayout();
			pnl_NameDesc_Asking.ResumeLayout(false);
			pnl_NameDesc_Asking.PerformLayout();
			_tab_Lookup_TabPage3.ResumeLayout(false);
			_tab_Lookup_TabPage3.PerformLayout();
			pnl_avionics_Update_Change.ResumeLayout(false);
			pnl_avionics_Update_Change.PerformLayout();
			_tab_Lookup_TabPage4.ResumeLayout(false);
			_tab_Lookup_TabPage4.PerformLayout();
			pnl_Aircraft_Class_AddUpdate.ResumeLayout(false);
			pnl_Aircraft_Class_AddUpdate.PerformLayout();
			_tab_Lookup_TabPage5.ResumeLayout(false);
			_tab_Lookup_TabPage5.PerformLayout();
			pnl_Aircraft_Type_AddUpdate.ResumeLayout(false);
			pnl_Aircraft_Type_AddUpdate.PerformLayout();
			_tab_Lookup_TabPage6.ResumeLayout(false);
			_tab_Lookup_TabPage6.PerformLayout();
			pnl_EMP_AddUpdate.ResumeLayout(false);
			pnl_EMP_AddUpdate.PerformLayout();
			_tab_Lookup_TabPage7.ResumeLayout(false);
			_tab_Lookup_TabPage7.PerformLayout();
			pnl_IC_Update_Change.ResumeLayout(false);
			pnl_IC_Update_Change.PerformLayout();
			_tab_Lookup_TabPage8.ResumeLayout(false);
			_tab_Lookup_TabPage8.PerformLayout();
			pnl_Aircraft_Contact_Type_List.ResumeLayout(false);
			pnl_Aircraft_Contact_Type_List.PerformLayout();
			pnl_ACTypeMain.ResumeLayout(false);
			pnl_ACTypeMain.PerformLayout();
			pnl_Aircraft_Contact_Type_AddUpdate.ResumeLayout(false);
			pnl_Aircraft_Contact_Type_AddUpdate.PerformLayout();
			pnl_CompanyRelationship.ResumeLayout(false);
			pnl_CompanyRelationship.PerformLayout();
			_tab_Lookup_TabPage9.ResumeLayout(false);
			_tab_Lookup_TabPage9.PerformLayout();
			pnl_APU_Update_Change.ResumeLayout(false);
			pnl_APU_Update_Change.PerformLayout();
			_tab_Lookup_TabPage10.ResumeLayout(false);
			_tab_Lookup_TabPage10.PerformLayout();
			pnl_Certification_Update_Change.ResumeLayout(false);
			pnl_Certification_Update_Change.PerformLayout();
			_tab_Lookup_TabPage11.ResumeLayout(false);
			_tab_Lookup_TabPage11.PerformLayout();
			pnl_Spec_Update_Change.ResumeLayout(false);
			pnl_Spec_Update_Change.PerformLayout();
			_tab_Lookup_TabPage12.ResumeLayout(false);
			_tab_Lookup_TabPage12.PerformLayout();
			pnl_airport_Update_Change.ResumeLayout(false);
			pnl_airport_Update_Change.PerformLayout();
			pnl_airport_update.ResumeLayout(false);
			pnl_airport_update.PerformLayout();
			frmLatitudeLongatude.ResumeLayout(false);
			frmLatitudeLongatude.PerformLayout();
			frmAirport.ResumeLayout(false);
			frmAirport.PerformLayout();
			SSPanel3.ResumeLayout(false);
			SSPanel3.PerformLayout();
			_tab_Lookup_TabPage13.ResumeLayout(false);
			_tab_Lookup_TabPage13.PerformLayout();
			pnl_Certified_Update_Change.ResumeLayout(false);
			pnl_Certified_Update_Change.PerformLayout();
			_tab_Lookup_TabPage15.ResumeLayout(false);
			_tab_Lookup_TabPage15.PerformLayout();
			pnl_CREG.ResumeLayout(false);
			pnl_CREG.PerformLayout();
			_tab_Lookup_TabPage16.ResumeLayout(false);
			_tab_Lookup_TabPage16.PerformLayout();
			_tab_Lookup_TabPage17.ResumeLayout(false);
			_tab_Lookup_TabPage17.PerformLayout();
			frmFuelPrices.ResumeLayout(false);
			frmFuelPrices.PerformLayout();
			_tab_Lookup_TabPage18.ResumeLayout(false);
			_tab_Lookup_TabPage18.PerformLayout();
			acTopicsPanel.ResumeLayout(false);
			acTopicsPanel.PerformLayout();
			acTopicsAircraftFrame.ResumeLayout(false);
			acTopicsAircraftFrame.PerformLayout();
			_tab_Lookup_TabPage19.ResumeLayout(false);
			_tab_Lookup_TabPage19.PerformLayout();
			_tab_Lookup_TabPage20.ResumeLayout(false);
			_tab_Lookup_TabPage20.PerformLayout();
			frmEngineModels.ResumeLayout(false);
			frmEngineModels.PerformLayout();
			frmEngineModelsAction.ResumeLayout(false);
			frmEngineModelsAction.PerformLayout();
			_tab_Lookup_TabPage21.ResumeLayout(false);
			_tab_Lookup_TabPage21.PerformLayout();
			tbr_ToolBar.ResumeLayout(false);
			tbr_ToolBar.PerformLayout();
			pnlAdmin.ResumeLayout(false);
			pnlAdmin.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializetxt_maint();
			Initializetxt_fuel_price_notes();
			Initializetxt_certification_name();
			InitializetxtFuelCost();
			InitializetxtEngineModel();
			InitializetxtAirport();
			Initializelbl_kfeat_code();
			Initializelbl_generic();
			Initializelbl_Airport_Message();
			InitializelblExportToExcel();
			InitializelblEngMdl();
			InitializelblCount();
			InitializelblAirport();
			Initializecmd_maint();
			Initializecmd_button();
			InitializecmdAirportPreviousNext();
			Initializechk_product_flags();
			Initializechk_maint();
			InitializechkEngineModel();
			InitializechkAirportListOptions();
			Initializecheck_prod_code();
			InitializeText1();
			InitializeLabel40();
			InitializeLabel24();
			InitializeLabel19();
			tab_LookupPreviousTab = tab_Lookup.SelectedIndex;
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = HomebaseAdministrator.mdi_AdminAssistant.DefInstance;
			HomebaseAdministrator.mdi_AdminAssistant.DefInstance.Show();
		}
		void Initializetxt_maint()
		{
			txt_maint = new System.Windows.Forms.TextBox[5];
			txt_maint[4] = _txt_maint_4;
			txt_maint[3] = _txt_maint_3;
			txt_maint[2] = _txt_maint_2;
			txt_maint[1] = _txt_maint_1;
			txt_maint[0] = _txt_maint_0;
		}
		void Initializetxt_fuel_price_notes()
		{
			txt_fuel_price_notes = new System.Windows.Forms.TextBox[4];
			txt_fuel_price_notes[3] = _txt_fuel_price_notes_3;
			txt_fuel_price_notes[2] = _txt_fuel_price_notes_2;
			txt_fuel_price_notes[1] = _txt_fuel_price_notes_1;
			txt_fuel_price_notes[0] = _txt_fuel_price_notes_0;
		}
		void Initializetxt_certification_name()
		{
			txt_certification_name = new System.Windows.Forms.TextBox[3];
			txt_certification_name[2] = _txt_certification_name_2;
			txt_certification_name[0] = _txt_certification_name_0;
		}
		void InitializetxtFuelCost()
		{
			txtFuelCost = new System.Windows.Forms.TextBox[4];
			txtFuelCost[3] = _txtFuelCost_3;
			txtFuelCost[2] = _txtFuelCost_2;
			txtFuelCost[1] = _txtFuelCost_1;
			txtFuelCost[0] = _txtFuelCost_0;
		}
		void InitializetxtEngineModel()
		{
			txtEngineModel = new System.Windows.Forms.TextBox[16];
			txtEngineModel[15] = _txtEngineModel_15;
			txtEngineModel[14] = _txtEngineModel_14;
			txtEngineModel[13] = _txtEngineModel_13;
			txtEngineModel[12] = _txtEngineModel_12;
			txtEngineModel[11] = _txtEngineModel_11;
			txtEngineModel[10] = _txtEngineModel_10;
			txtEngineModel[9] = _txtEngineModel_9;
			txtEngineModel[8] = _txtEngineModel_8;
			txtEngineModel[7] = _txtEngineModel_7;
			txtEngineModel[6] = _txtEngineModel_6;
			txtEngineModel[5] = _txtEngineModel_5;
			txtEngineModel[4] = _txtEngineModel_4;
			txtEngineModel[3] = _txtEngineModel_3;
			txtEngineModel[2] = _txtEngineModel_2;
			txtEngineModel[1] = _txtEngineModel_1;
			txtEngineModel[0] = _txtEngineModel_0;
		}
		void InitializetxtAirport()
		{
			txtAirport = new System.Windows.Forms.TextBox[20];
			txtAirport[9] = _txtAirport_9;
			txtAirport[10] = _txtAirport_10;
			txtAirport[11] = _txtAirport_11;
			txtAirport[12] = _txtAirport_12;
			txtAirport[13] = _txtAirport_13;
			txtAirport[17] = _txtAirport_17;
			txtAirport[16] = _txtAirport_16;
			txtAirport[8] = _txtAirport_8;
			txtAirport[7] = _txtAirport_7;
			txtAirport[6] = _txtAirport_6;
			txtAirport[5] = _txtAirport_5;
			txtAirport[4] = _txtAirport_4;
			txtAirport[19] = _txtAirport_19;
			txtAirport[18] = _txtAirport_18;
			txtAirport[15] = _txtAirport_15;
			txtAirport[14] = _txtAirport_14;
			txtAirport[3] = _txtAirport_3;
			txtAirport[2] = _txtAirport_2;
			txtAirport[1] = _txtAirport_1;
			txtAirport[0] = _txtAirport_0;
		}
		void Initializelbl_kfeat_code()
		{
			lbl_kfeat_code = new System.Windows.Forms.Label[1];
			lbl_kfeat_code[0] = _lbl_kfeat_code_0;
		}
		void Initializelbl_generic()
		{
			lbl_generic = new System.Windows.Forms.Label[13];
			lbl_generic[12] = _lbl_generic_12;
			lbl_generic[9] = _lbl_generic_9;
			lbl_generic[11] = _lbl_generic_11;
			lbl_generic[10] = _lbl_generic_10;
			lbl_generic[8] = _lbl_generic_8;
			lbl_generic[7] = _lbl_generic_7;
			lbl_generic[6] = _lbl_generic_6;
			lbl_generic[5] = _lbl_generic_5;
			lbl_generic[4] = _lbl_generic_4;
			lbl_generic[3] = _lbl_generic_3;
			lbl_generic[1] = _lbl_generic_1;
			lbl_generic[0] = _lbl_generic_0;
			lbl_generic[2] = _lbl_generic_2;
		}
		void Initializelbl_Airport_Message()
		{
			lbl_Airport_Message = new System.Windows.Forms.Label[2];
			lbl_Airport_Message[1] = _lbl_Airport_Message_1;
		}
		void InitializelblExportToExcel()
		{
			lblExportToExcel = new System.Windows.Forms.Label[2];
			lblExportToExcel[1] = _lblExportToExcel_1;
			lblExportToExcel[0] = _lblExportToExcel_0;
		}
		void InitializelblEngMdl()
		{
			lblEngMdl = new System.Windows.Forms.Label[15];
			lblEngMdl[14] = _lblEngMdl_14;
			lblEngMdl[13] = _lblEngMdl_13;
			lblEngMdl[12] = _lblEngMdl_12;
			lblEngMdl[11] = _lblEngMdl_11;
			lblEngMdl[10] = _lblEngMdl_10;
			lblEngMdl[9] = _lblEngMdl_9;
			lblEngMdl[8] = _lblEngMdl_8;
			lblEngMdl[7] = _lblEngMdl_7;
			lblEngMdl[6] = _lblEngMdl_6;
			lblEngMdl[5] = _lblEngMdl_5;
			lblEngMdl[4] = _lblEngMdl_4;
			lblEngMdl[3] = _lblEngMdl_3;
			lblEngMdl[2] = _lblEngMdl_2;
			lblEngMdl[1] = _lblEngMdl_1;
			lblEngMdl[0] = _lblEngMdl_0;
		}
		void InitializelblCount()
		{
			lblCount = new System.Windows.Forms.Label[3];
			lblCount[2] = _lblCount_2;
			lblCount[1] = _lblCount_1;
			lblCount[0] = _lblCount_0;
		}
		void InitializelblAirport()
		{
			lblAirport = new System.Windows.Forms.Label[27];
			lblAirport[24] = _lblAirport_24;
			lblAirport[19] = _lblAirport_19;
			lblAirport[8] = _lblAirport_8;
			lblAirport[7] = _lblAirport_7;
			lblAirport[6] = _lblAirport_6;
			lblAirport[5] = _lblAirport_5;
			lblAirport[4] = _lblAirport_4;
			lblAirport[20] = _lblAirport_20;
			lblAirport[13] = _lblAirport_13;
			lblAirport[12] = _lblAirport_12;
			lblAirport[11] = _lblAirport_11;
			lblAirport[9] = _lblAirport_9;
			lblAirport[26] = _lblAirport_26;
			lblAirport[23] = _lblAirport_23;
			lblAirport[22] = _lblAirport_22;
			lblAirport[18] = _lblAirport_18;
			lblAirport[21] = _lblAirport_21;
			lblAirport[17] = _lblAirport_17;
			lblAirport[16] = _lblAirport_16;
			lblAirport[15] = _lblAirport_15;
			lblAirport[14] = _lblAirport_14;
			lblAirport[3] = _lblAirport_3;
			lblAirport[2] = _lblAirport_2;
			lblAirport[1] = _lblAirport_1;
			lblAirport[0] = _lblAirport_0;
			lblAirport[10] = _lblAirport_10;
		}
		void Initializecmd_maint()
		{
			cmd_maint = new System.Windows.Forms.Button[7];
			cmd_maint[6] = _cmd_maint_6;
			cmd_maint[5] = _cmd_maint_5;
			cmd_maint[4] = _cmd_maint_4;
			cmd_maint[3] = _cmd_maint_3;
			cmd_maint[2] = _cmd_maint_2;
			cmd_maint[1] = _cmd_maint_1;
			cmd_maint[0] = _cmd_maint_0;
		}
		void Initializecmd_button()
		{
			cmd_button = new System.Windows.Forms.Button[4];
			cmd_button[3] = _cmd_button_3;
			cmd_button[2] = _cmd_button_2;
			cmd_button[1] = _cmd_button_1;
			cmd_button[0] = _cmd_button_0;
		}
		void InitializecmdAirportPreviousNext()
		{
			cmdAirportPreviousNext = new System.Windows.Forms.Button[2];
			cmdAirportPreviousNext[1] = _cmdAirportPreviousNext_1;
			cmdAirportPreviousNext[0] = _cmdAirportPreviousNext_0;
		}
		void Initializechk_product_flags()
		{
			chk_product_flags = new System.Windows.Forms.CheckBox[4];
			chk_product_flags[3] = _chk_product_flags_3;
			chk_product_flags[2] = _chk_product_flags_2;
			chk_product_flags[1] = _chk_product_flags_1;
			chk_product_flags[0] = _chk_product_flags_0;
		}
		void Initializechk_maint()
		{
			chk_maint = new System.Windows.Forms.CheckBox[2];
			chk_maint[1] = _chk_maint_1;
			chk_maint[0] = _chk_maint_0;
		}
		void InitializechkEngineModel()
		{
			chkEngineModel = new System.Windows.Forms.CheckBox[2];
			chkEngineModel[1] = _chkEngineModel_1;
			chkEngineModel[0] = _chkEngineModel_0;
		}
		void InitializechkAirportListOptions()
		{
			chkAirportListOptions = new System.Windows.Forms.CheckBox[9];
			chkAirportListOptions[8] = _chkAirportListOptions_8;
			chkAirportListOptions[7] = _chkAirportListOptions_7;
			chkAirportListOptions[6] = _chkAirportListOptions_6;
			chkAirportListOptions[4] = _chkAirportListOptions_4;
			chkAirportListOptions[5] = _chkAirportListOptions_5;
			chkAirportListOptions[3] = _chkAirportListOptions_3;
			chkAirportListOptions[2] = _chkAirportListOptions_2;
			chkAirportListOptions[1] = _chkAirportListOptions_1;
			chkAirportListOptions[0] = _chkAirportListOptions_0;
		}
		void Initializecheck_prod_code()
		{
			check_prod_code = new System.Windows.Forms.CheckBox[3];
			check_prod_code[2] = _check_prod_code_2;
			check_prod_code[1] = _check_prod_code_1;
			check_prod_code[0] = _check_prod_code_0;
		}
		void InitializeText1()
		{
			Text1 = new System.Windows.Forms.TextBox[1];
			Text1[0] = _Text1_0;
		}
		void InitializeLabel40()
		{
			Label40 = new System.Windows.Forms.Label[5];
			Label40[4] = _Label40_4;
			Label40[3] = _Label40_3;
			Label40[1] = _Label40_1;
			Label40[0] = _Label40_0;
		}
		void InitializeLabel24()
		{
			Label24 = new System.Windows.Forms.Label[46];
			Label24[39] = _Label24_39;
			Label24[44] = _Label24_44;
			Label24[19] = _Label24_19;
			Label24[18] = _Label24_18;
			Label24[17] = _Label24_17;
			Label24[16] = _Label24_16;
			Label24[15] = _Label24_15;
			Label24[21] = _Label24_21;
			Label24[20] = _Label24_20;
			Label24[23] = _Label24_23;
			Label24[22] = _Label24_22;
			Label24[25] = _Label24_25;
			Label24[24] = _Label24_24;
			Label24[27] = _Label24_27;
			Label24[26] = _Label24_26;
			Label24[29] = _Label24_29;
			Label24[28] = _Label24_28;
			Label24[33] = _Label24_33;
			Label24[32] = _Label24_32;
			Label24[31] = _Label24_31;
			Label24[30] = _Label24_30;
			Label24[41] = _Label24_41;
			Label24[40] = _Label24_40;
			Label24[34] = _Label24_34;
			Label24[2] = _Label24_2;
			Label24[1] = _Label24_1;
			Label24[0] = _Label24_0;
			Label24[3] = _Label24_3;
			Label24[38] = _Label24_38;
			Label24[37] = _Label24_37;
			Label24[36] = _Label24_36;
			Label24[35] = _Label24_35;
			Label24[8] = _Label24_8;
			Label24[7] = _Label24_7;
			Label24[6] = _Label24_6;
			Label24[5] = _Label24_5;
			Label24[4] = _Label24_4;
			Label24[45] = _Label24_45;
			Label24[43] = _Label24_43;
			Label24[42] = _Label24_42;
			Label24[14] = _Label24_14;
			Label24[13] = _Label24_13;
			Label24[12] = _Label24_12;
			Label24[11] = _Label24_11;
			Label24[10] = _Label24_10;
			Label24[9] = _Label24_9;
		}
		void InitializeLabel19()
		{
			Label19 = new System.Windows.Forms.Label[4];
			Label19[3] = _Label19_3;
			Label19[2] = _Label19_2;
			Label19[1] = _Label19_1;
			Label19[0] = _Label19_0;
		}
		#endregion
	}
}