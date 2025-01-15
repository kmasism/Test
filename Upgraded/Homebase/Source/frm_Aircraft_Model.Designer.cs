
namespace JETNET_Homebase
{
	partial class frm_Aircraft_Model
	{

		#region "Upgrade Support "
		private static frm_Aircraft_Model m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Aircraft_Model DefInstance
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
		public static frm_Aircraft_Model CreateInstance()
		{
			frm_Aircraft_Model theInstance = new frm_Aircraft_Model();
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
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnu_File_Close", "mnu_File_Logout", "mnu_File", "mnuAttachPicture", "mnu_EditAdd", "mnuAddAircraft", "mnuEditSummaries", "mnu_Edit", "ModelSpec", "GenericReport", "mnuReport", "mnuHelp", "mnuDeleteModel", "MainMenu1", "cmbBodyConfig", "_chk_amod_product_5", "_chk_amod_product_3", "_chk_amod_product_4", "_chk_amod_product_2", "_chk_amod_product_1", "_chk_amod_product_0", "_Label6_33", "Line1", "pnl_PriceRange", "txt_amod_ser_no_suffix", "chk_amod_hyphen_flag", "txt_amod_ser_no_start", "txt_amod_ser_no_end", "txt_amod_ser_no_prefix", "_Label6_15", "_Label6_14", "_Label6_13", "_Label6_12", "SSPanel1", "cmd_Update", "txt_amod_end_price", "txt_amod_start_price", "txt_amod_end_year", "txt_amod_start_year", "_Label6_8", "_Label6_26", "_Label6_5", "ponl_YearsBuilt", "tbr_ToolBar_Buttons_Button1", "tbr_ToolBar_Buttons_Button2", "tbr_ToolBar_Buttons_Button3", "tbr_ToolBar_Buttons_Button4", "tbr_ToolBar_Buttons_Button5", "tbr_ToolBar_Buttons_Button6", "tbr_ToolBar_Buttons_Button7", "tbr_ToolBar_Buttons_Button8", "tbr_ToolBar", "_lbl_spec_8", "_lbl_specs_55", "img_Model_Picture", "lbl_Description", "lbl_Message", "_Label6_11", "grd_Aircraft", "txt_TotalAircraft", "_Text1_1", "txt_amod_description", "cmdStop", "_Text1_0", "_Text1_2", "cmdTemp", "_tab_Aircraft_Model_TabPage0", "_cmd_button_array_2", "_cmd_button_array_5", "_cmd_button_array_1", "chkFeatCount", "_cmd_button_array_0", "grd_Keyfeature", "lblFeatureUnknown", "lblFeatureNo", "lblFeatureYes", "pnl_ModelFeatures", "_cmd_button_array_4", "_cmd_button_array_3", "lst_MasterKeyFeature", "pnl_MasterKeyFeatures", "_cmd_button_array_8", "_cmd_button_array_7", "_cmd_button_array_6", "txt_InactiveDate", "chk_Inactive_Feature_Code", "txtFeatEndSerNo", "txtFeatStartSerNo", "chkStandard", "_Label6_31", "_Label6_30", "lbl_FeatureMessage", "lbl_FeatureDescription", "pnl_FeatureDisplay", "_tab_Aircraft_Model_TabPage1", "grd_ModelTrend", "_tab_Aircraft_Model_TabPage2", "lst_aircraft_wanted", "_Label13_8", "_Label13_7", "_Label13_6", "_Label13_5", "_Label13_4", "_Lable13_2", "_Label13_1", "_Label13_0", "_tab_Aircraft_Model_TabPage3", "txt_amod_annual_hours", "txt_amod_annual_miles", "txt_amod_number_of_seats", "txt_amod_tot_direct_cost", "txt_amod_tot_fixed_cost2", "txt_amod_tot_df_seat_cost", "txt_amod_tot_df_statmile_cost", "txt_amod_tot_df_hour_cost", "txt_amod_tot_df_annual_cost", "txt_amod_tot_nd_seat_cost", "txt_amod_tot_nd_statmile_cost", "txt_amod_tot_nd_hour_cost", "txt_amod_tot_nd_annual_cost", "_Label18_6", "_Label17_4", "_Label16_7", "_Label16_8", "_Label16_9", "_Label18_7", "_Label17_5", "_Label16_10", "_Label16_11", "_Label18_8", "_Label17_6", "_Label16_12", "_Label16_13", "pnl_AnnualBudget", "txt_var_misc", "txt_amod_tot_variable_cost", "txt_amod_liability_insurance_cost", "txt_amod_hull_insurance_cost", "txt_amod_insurance_cost", "txt_amod_crew_benefit_cost", "txt_amod_cpilot_salary_cost", "txt_amod_capt_salary_cost", "txt_amod_tot_crew_salary_cost", "txt_amod_hangar_cost", "txt_amod_misc_naveq_cost", "txt_amod_misc_modern_cost", "txt_amod_misc_train_cost", "txt_amod_tot_misc_ovh_cost", "txt_amod_tot_fixed_cost", "txt_amod_deprec_cost", "_Label19_6", "_Label19_0", "_Label28_6", "_Label20_4", "_Label19_4", "_Label18_2", "_Label17_2", "_Label16_3", "_Label16_4", "_Label18_3", "_Label18_4", "_Label17_3", "_Label16_5", "_Label16_6", "_Label19_5", "_Label18_5", "pnl_FixedCosts", "txt_amod_maint_parts_man_hour_multiplier", "txt_amod_maint_labor_man_hour_multiplier", "txt_amod_maint_parts_cost", "txt_amod_maint_lab_cost", "txt_amod_maint_tot_cost", "txt_amod_fuel_burn_rate", "txt_amod_fuel_add_cost", "txt_amod_fuel_gal_cost", "txt_amod_fuel_tot_cost", "txt_amod_engine_ovh_cost", "txt_amod_thrust_rev_ovh_cost", "txt_amod_misc_flight_cost", "txt_amod_land_park_cost", "txt_amod_crew_exp_cost", "txt_amod_supplies_cost", "txt_amod_tot_hour_direct_cost", "txt_amod_avg_block_speed", "txt_amod_tot_stat_mile_cost", "_Label20_5", "_Label20_0", "_Label28_1", "_Label20_1", "_Label19_1", "_Label18_0", "_Label16_0", "_Label16_1", "_Label16_2", "_Label20_2", "_Label20_3", "_Label19_2", "_Label28_2", "_Label28_3", "_Label28_5", "_Label19_3", "_Label28_7", "_Label28_8", "pnl_DirectCost", "_tab_Aircraft_Model_TabPage4", "_txt_amod_fuselage_length_9", "_txt_amod_fuselage_length_8", "_txt_amod_fuselage_length_6", "_txt_amod_fuselage_length_5", "_txt_amod_fuselage_length_4", "_txt_amod_fuselage_length_3", "_txt_amod_fuselage_length_2", "_txt_amod_fuselage_length_1", "_lbl_specs_86", "_lbl_specs_85", "_lbl_specs_84", "_lbl_specs_83", "_lbl_specs_82", "_lbl_specs_81", "_lbl_specs_80", "_lbl_specs_79", "_lbl_specs_78", "_lbl_specs_76", "_lbl_specs_75", "_lbl_specs_74", "_lbl_specs_69", "pnlCabinDimension", "txt_amod_main_rotor_1_blade_count", "txt_amod_main_rotor_1_blade_diameter", "txt_amod_main_rotor_2_blade_count", "txt_amod_main_rotor_2_blade_diameter", "txt_amod_tail_rotor_blade_count", "txt_amod_tail_rotor_blade_diameter", "cmb_amod_rotor_anti_torque_system", "_lbl_specs_38", "_lbl_specs_39", "_lbl_specs_48", "_lbl_specs_49", "_lbl_specs_54", "_lbl_specs_56", "pnl_Rotors", "txt_amod_climb_engout_feet", "txt_amod_climb_normal_feet", "txt_amod_ceiling_feet", "txt_amod_climb_hoge", "txt_amod_climb_hige", "_lbl_specs_14", "_lbl_specs_13", "_lbl_specs_59", "_lbl_specs_62", "_lbl_specs_61", "_lbl_specs_60", "pnl_Climb", "_txt_amod_speed_7", "_txt_amod_speed_6", "_txt_amod_speed_5", "_txt_amod_speed_4", "_txt_amod_speed_0", "_txt_amod_speed_1", "_txt_amod_speed_2", "_txt_amod_speed_3", "_lbl_specs_92", "_lbl_specs_91", "_lbl_specs_90", "_lbl_specs_89", "_lbl_specs_40", "_lbl_specs_41", "_lbl_specs_42", "_lbl_specs_43", "pnl_Speed", "txt_amod_range_8_passenger", "txt_amod_range_4_passenger", "txt_amod_field_length", "txt_amod_takeoff_500", "txt_amod_takeoff_ali", "txt_amod_max_range_miles", "txt_amod_range_tanks_full", "txt_amod_range_seats_full", "cmb_amod_ifr_certification", "_lbl_specs_88", "_lbl_specs_87", "_lbl_specs_53", "_lbl_specs_51", "_lbl_specs_73", "_lbl_specs_37", "_lbl_specs_15", "_lbl_specs_3", "_lbl_specs_50", "_lbl_specs_52", "_lbl_specs_64", "_lbl_specs_65", "_lbl_specs_66", "pnl_OtherSpecs", "txt_amod_number_of_props", "txt_amod_prop_model_name", "txt_amod_prop_mfr_name", "txt_amod_prop_com_tbo_hrs", "txt_amod_prop_shaft", "txt_amod_prop_hsi", "_lbl_Prop_number_16", "_lbl_specs_45", "_lbl_specs_44", "_lbl_specs_46", "_lbl_specs_47", "_lbl_specs_36", "pnl_Props", "txt_amod_fuselage_wingspan", "txt_amod_fuselage_height", "_txt_amod_fuselage_length_0", "txt_amod_fuselage_width", "_lbl_specs_71", "_lbl_specs_72", "_lbl_specs_70", "_lbl_specs_2", "_lbl_specs_1", "_lbl_specs_0", "_lbl_specs_57", "_lbl_specs_58", "pnl_FuselageDimensions", "txt_amod_pressure", "txt_amod_number_of_passengers", "txt_amod_number_of_crew", "_lbl_specs_6", "_lbl_specs_5", "_lbl_specs_4", "pnl_Config", "txt_amod_max_landing_weight", "txt_amod_basic_op_weight", "txt_amod_zero_fuel_weight", "txt_amod_max_takeoff_weight", "txt_amod_max_ramp_weight", "txt_amod_weight_eow", "_lbl_specs_31", "_lbl_specs_30", "_lbl_specs_29", "_lbl_specs_28", "_lbl_specs_27", "_lbl_specs_63", "pnl_Weight", "txt_amod_fuel_cap_opt_gal", "txt_amod_fuel_cap_std_gal", "txt_amod_fuel_cap_opt_weight", "txt_amod_fuel_cap_std_weight", "_lbl_specs_12", "_lbl_specs_10", "_lbl_specs_11", "_lbl_specs_9", "_lbl_specs_8", "_lbl_specs_7", "pnl_FuelCapacity", "_cmd_button_0", "cbo_tbo_list", "chk_oncondtbox", "txt_amod_engine_hsi", "txt_amod_engine_shaft", "txt_amod_engine_thrust_lbs", "txt_amod_number_of_engines", "lst_Spec_Engines", "cmd_Add_Engine", "cmd_Remove_Engine", "_lbl_specs_34", "_lbl_specs_21", "_lbl_specs_19", "_lbl_specs_18", "_lbl_specs_17", "_lbl_specs_16", "_lbl_specs_35", "Label22", "Label21", "pnl_EngineData", "txt_amod_other_config_note", "pnl_ConfigNote", "cmdFindEngineModel", "txt_ameng_mfr_name_short", "txt_ameng_mfr_CompID", "txt_ameng_seq_no", "txt_ameng_max_continuous_power", "txt_ameng_takeoff_power", "Chk_ameng_active_flag", "cmd_Engine_Cancel", "txt_ameng_mfr_name", "txt_ameng_engine_prefix", "txt_ameng_engine_core", "txt_ameng_engine_suffix1", "txt_ameng_engine_suffix2", "cmd_Engine_Save", "_lbl_specs_93", "_Label6_25", "_lbl_specs_68", "_lbl_specs_67", "_lbl_specs_33", "_lbl_specs_32", "_lbl_specs_26", "_lbl_specs_20", "_lbl_specs_22", "_lbl_specs_23", "_lbl_specs_24", "_lbl_specs_25", "pnl_Aircraft_Model_Engine_Add", "_tab_Aircraft_Model_TabPage5", "txt_amod_maint_note", "txt_amod_inspection_note", "_Label6_16", "_Label6_17", "_tab_Aircraft_Model_TabPage6", "txt_amod_upd_user_id", "txt_amod_ent_user_id", "txt_amod_ent_date", "txt_amod_upd_date", "txt_amod_sale_verify_days", "txt_amod_common_verify_days", "chk_amod_customer_flag", "_Label6_21", "_Label6_20", "_Label6_18", "_Label6_19", "_Label6_22", "_Label6_23", "_Label6_24", "_tab_Aircraft_Model_TabPage7", "_cmdUseage_0", "_cmdUseage_1", "UsageList", "_cmdUseage_4", "cmbUsage", "_cmdUseage_3", "_cmdUseage_2", "pnl_Useage_Add", "_tab_Aircraft_Model_TabPage8", "_cmd_Make_Move1_2", "_cmd_Make_Move1_1", "_cmd_Make_Move1_0", "cbo_MakeSelect", "grd_MakeSort", "_tab_Aircraft_Model_TabPage9", "_CMDModelMap_2", "_CMDModelMap_1", "_CMDModelMap_0", "cmbHbaseModels", "_lbl_spec_2", "_lbl_spec_1", "frmodelMap", "grdModelMap", "grdAircraftMap", "_lbl_spec_3", "_lbl_spec_0", "_tab_Aircraft_Model_TabPage10", "txt_intel", "_tab_Aircraft_Model_TabPage11", "grd_eventlog", "cmd_new", "grd_amod_journal", "_Label6_36", "_tab_Aircraft_Model_TabPage12", "_tab_Aircraft_Model_TabPage13", "tab_Aircraft_Model", "txt_amod_icao", "cboJIQSize", "_txt_amod_fuselage_length_7", "cbo_amod_Airframe_Type_Code", "_txt_amod_manufacturer_2", "_txt_amod_manufacturer_1", "_txt_amod_manufacturer_0", "txt_amod_make_abbrev", "txt_amod_model_abbrev", "cboWeightClass", "cbo_amod_type_code", "txt_amod_make_name", "txt_amod_model_name", "cbo_amod_class", "CmbResearchType", "txt_amod_id", "scr_Models", "txt_model_number",  
 			"txt_model_total", "cbo_Model", "SSPanel3", "_Label6_9", "_Label6_10", "pnl_Model_Top", "_Label6_35", "_Label6_34", "_Label6_29", "_Label6_1", "_Label6_32", "_Label6_28", "_Label6_27", "_Label6_6", "_Label6_4", "_Label6_3", "_Label2_0", "_Label6_7", "_Label6_0", "_Label6_2", "pnl_ModelMain", "lbl_Status", "frame_Status", "_lbl_specs_77", "_Label13_2", "CMDModelMap", "Label13", "Label16", "Label17", "Label18", "Label19", "Label2", "Label20", "Label28", "Label6", "Lable13", "Text1", "chk_amod_product", "cmdUseage", "cmd_Make_Move1", "cmd_button", "cmd_button_array", "lbl_Prop_number", "lbl_spec", "lbl_specs", "txt_amod_fuselage_length", "txt_amod_manufacturer", "txt_amod_speed", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnu_File_Close;
		public System.Windows.Forms.ToolStripMenuItem mnu_File_Logout;
		public System.Windows.Forms.ToolStripMenuItem mnu_File;
		public System.Windows.Forms.ToolStripMenuItem mnuAttachPicture;
		public System.Windows.Forms.ToolStripMenuItem mnu_EditAdd;
		public System.Windows.Forms.ToolStripMenuItem mnuAddAircraft;
		public System.Windows.Forms.ToolStripMenuItem mnuEditSummaries;
		public System.Windows.Forms.ToolStripMenuItem mnu_Edit;
		public System.Windows.Forms.ToolStripMenuItem ModelSpec;
		public System.Windows.Forms.ToolStripMenuItem GenericReport;
		public System.Windows.Forms.ToolStripMenuItem mnuReport;
		public System.Windows.Forms.ToolStripMenuItem mnuHelp;
		public System.Windows.Forms.ToolStripMenuItem mnuDeleteModel;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.ComboBox cmbBodyConfig;
		private System.Windows.Forms.CheckBox _chk_amod_product_5;
		private System.Windows.Forms.CheckBox _chk_amod_product_3;
		private System.Windows.Forms.CheckBox _chk_amod_product_4;
		private System.Windows.Forms.CheckBox _chk_amod_product_2;
		private System.Windows.Forms.CheckBox _chk_amod_product_1;
		private System.Windows.Forms.CheckBox _chk_amod_product_0;
		private System.Windows.Forms.Label _Label6_33;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Panel pnl_PriceRange;
		public System.Windows.Forms.TextBox txt_amod_ser_no_suffix;
		public System.Windows.Forms.CheckBox chk_amod_hyphen_flag;
		public System.Windows.Forms.TextBox txt_amod_ser_no_start;
		public System.Windows.Forms.TextBox txt_amod_ser_no_end;
		public System.Windows.Forms.TextBox txt_amod_ser_no_prefix;
		private System.Windows.Forms.Label _Label6_15;
		private System.Windows.Forms.Label _Label6_14;
		private System.Windows.Forms.Label _Label6_13;
		private System.Windows.Forms.Label _Label6_12;
		public System.Windows.Forms.Panel SSPanel1;
		public System.Windows.Forms.Button cmd_Update;
		public System.Windows.Forms.TextBox txt_amod_end_price;
		public System.Windows.Forms.TextBox txt_amod_start_price;
		public System.Windows.Forms.TextBox txt_amod_end_year;
		public System.Windows.Forms.TextBox txt_amod_start_year;
		private System.Windows.Forms.Label _Label6_8;
		private System.Windows.Forms.Label _Label6_26;
		private System.Windows.Forms.Label _Label6_5;
		public System.Windows.Forms.Panel ponl_YearsBuilt;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button1;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button2;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button3;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button4;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button5;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button6;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button7;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button8;
		public System.Windows.Forms.ToolStrip tbr_ToolBar;
		private System.Windows.Forms.Label _lbl_spec_8;
		private System.Windows.Forms.Label _lbl_specs_55;
		public System.Windows.Forms.PictureBox img_Model_Picture;
		public System.Windows.Forms.Label lbl_Description;
		public System.Windows.Forms.Label lbl_Message;
		private System.Windows.Forms.Label _Label6_11;
		public UpgradeHelpers.DataGridViewFlex grd_Aircraft;
		public System.Windows.Forms.TextBox txt_TotalAircraft;
		private System.Windows.Forms.TextBox _Text1_1;
		public System.Windows.Forms.TextBox txt_amod_description;
		public System.Windows.Forms.Button cmdStop;
		private System.Windows.Forms.TextBox _Text1_0;
		private System.Windows.Forms.TextBox _Text1_2;
		public System.Windows.Forms.Button cmdTemp;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage0;
		private System.Windows.Forms.Button _cmd_button_array_2;
		private System.Windows.Forms.Button _cmd_button_array_5;
		private System.Windows.Forms.Button _cmd_button_array_1;
		public System.Windows.Forms.CheckBox chkFeatCount;
		private System.Windows.Forms.Button _cmd_button_array_0;
		public UpgradeHelpers.DataGridViewFlex grd_Keyfeature;
		public System.Windows.Forms.Label lblFeatureUnknown;
		public System.Windows.Forms.Label lblFeatureNo;
		public System.Windows.Forms.Label lblFeatureYes;
		public System.Windows.Forms.Panel pnl_ModelFeatures;
		private System.Windows.Forms.Button _cmd_button_array_4;
		private System.Windows.Forms.Button _cmd_button_array_3;
		public System.Windows.Forms.ListBox lst_MasterKeyFeature;
		public System.Windows.Forms.Panel pnl_MasterKeyFeatures;
		private System.Windows.Forms.Button _cmd_button_array_8;
		private System.Windows.Forms.Button _cmd_button_array_7;
		private System.Windows.Forms.Button _cmd_button_array_6;
		public System.Windows.Forms.TextBox txt_InactiveDate;
		public System.Windows.Forms.CheckBox chk_Inactive_Feature_Code;
		public System.Windows.Forms.TextBox txtFeatEndSerNo;
		public System.Windows.Forms.TextBox txtFeatStartSerNo;
		public System.Windows.Forms.CheckBox chkStandard;
		private System.Windows.Forms.Label _Label6_31;
		private System.Windows.Forms.Label _Label6_30;
		public System.Windows.Forms.Label lbl_FeatureMessage;
		public System.Windows.Forms.Label lbl_FeatureDescription;
		public System.Windows.Forms.Panel pnl_FeatureDisplay;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage1;
		public UpgradeHelpers.DataGridViewFlex grd_ModelTrend;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage2;
		public System.Windows.Forms.ListBox lst_aircraft_wanted;
		private System.Windows.Forms.Label _Label13_8;
		private System.Windows.Forms.Label _Label13_7;
		private System.Windows.Forms.Label _Label13_6;
		private System.Windows.Forms.Label _Label13_5;
		private System.Windows.Forms.Label _Label13_4;
		private System.Windows.Forms.Label _Lable13_2;
		private System.Windows.Forms.Label _Label13_1;
		private System.Windows.Forms.Label _Label13_0;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage3;
		public System.Windows.Forms.TextBox txt_amod_annual_hours;
		public System.Windows.Forms.TextBox txt_amod_annual_miles;
		public System.Windows.Forms.TextBox txt_amod_number_of_seats;
		public System.Windows.Forms.TextBox txt_amod_tot_direct_cost;
		public System.Windows.Forms.TextBox txt_amod_tot_fixed_cost2;
		public System.Windows.Forms.TextBox txt_amod_tot_df_seat_cost;
		public System.Windows.Forms.TextBox txt_amod_tot_df_statmile_cost;
		public System.Windows.Forms.TextBox txt_amod_tot_df_hour_cost;
		public System.Windows.Forms.TextBox txt_amod_tot_df_annual_cost;
		public System.Windows.Forms.TextBox txt_amod_tot_nd_seat_cost;
		public System.Windows.Forms.TextBox txt_amod_tot_nd_statmile_cost;
		public System.Windows.Forms.TextBox txt_amod_tot_nd_hour_cost;
		public System.Windows.Forms.TextBox txt_amod_tot_nd_annual_cost;
		private System.Windows.Forms.Label _Label18_6;
		private System.Windows.Forms.Label _Label17_4;
		private System.Windows.Forms.Label _Label16_7;
		private System.Windows.Forms.Label _Label16_8;
		private System.Windows.Forms.Label _Label16_9;
		private System.Windows.Forms.Label _Label18_7;
		private System.Windows.Forms.Label _Label17_5;
		private System.Windows.Forms.Label _Label16_10;
		private System.Windows.Forms.Label _Label16_11;
		private System.Windows.Forms.Label _Label18_8;
		private System.Windows.Forms.Label _Label17_6;
		private System.Windows.Forms.Label _Label16_12;
		private System.Windows.Forms.Label _Label16_13;
		public System.Windows.Forms.Panel pnl_AnnualBudget;
		public System.Windows.Forms.TextBox txt_var_misc;
		public System.Windows.Forms.TextBox txt_amod_tot_variable_cost;
		public System.Windows.Forms.TextBox txt_amod_liability_insurance_cost;
		public System.Windows.Forms.TextBox txt_amod_hull_insurance_cost;
		public System.Windows.Forms.TextBox txt_amod_insurance_cost;
		public System.Windows.Forms.TextBox txt_amod_crew_benefit_cost;
		public System.Windows.Forms.TextBox txt_amod_cpilot_salary_cost;
		public System.Windows.Forms.TextBox txt_amod_capt_salary_cost;
		public System.Windows.Forms.TextBox txt_amod_tot_crew_salary_cost;
		public System.Windows.Forms.TextBox txt_amod_hangar_cost;
		public System.Windows.Forms.TextBox txt_amod_misc_naveq_cost;
		public System.Windows.Forms.TextBox txt_amod_misc_modern_cost;
		public System.Windows.Forms.TextBox txt_amod_misc_train_cost;
		public System.Windows.Forms.TextBox txt_amod_tot_misc_ovh_cost;
		public System.Windows.Forms.TextBox txt_amod_tot_fixed_cost;
		public System.Windows.Forms.TextBox txt_amod_deprec_cost;
		private System.Windows.Forms.Label _Label19_6;
		private System.Windows.Forms.Label _Label19_0;
		private System.Windows.Forms.Label _Label28_6;
		private System.Windows.Forms.Label _Label20_4;
		private System.Windows.Forms.Label _Label19_4;
		private System.Windows.Forms.Label _Label18_2;
		private System.Windows.Forms.Label _Label17_2;
		private System.Windows.Forms.Label _Label16_3;
		private System.Windows.Forms.Label _Label16_4;
		private System.Windows.Forms.Label _Label18_3;
		private System.Windows.Forms.Label _Label18_4;
		private System.Windows.Forms.Label _Label17_3;
		private System.Windows.Forms.Label _Label16_5;
		private System.Windows.Forms.Label _Label16_6;
		private System.Windows.Forms.Label _Label19_5;
		private System.Windows.Forms.Label _Label18_5;
		public System.Windows.Forms.Panel pnl_FixedCosts;
		public System.Windows.Forms.TextBox txt_amod_maint_parts_man_hour_multiplier;
		public System.Windows.Forms.TextBox txt_amod_maint_labor_man_hour_multiplier;
		public System.Windows.Forms.TextBox txt_amod_maint_parts_cost;
		public System.Windows.Forms.TextBox txt_amod_maint_lab_cost;
		public System.Windows.Forms.TextBox txt_amod_maint_tot_cost;
		public System.Windows.Forms.TextBox txt_amod_fuel_burn_rate;
		public System.Windows.Forms.TextBox txt_amod_fuel_add_cost;
		public System.Windows.Forms.TextBox txt_amod_fuel_gal_cost;
		public System.Windows.Forms.TextBox txt_amod_fuel_tot_cost;
		public System.Windows.Forms.TextBox txt_amod_engine_ovh_cost;
		public System.Windows.Forms.TextBox txt_amod_thrust_rev_ovh_cost;
		public System.Windows.Forms.TextBox txt_amod_misc_flight_cost;
		public System.Windows.Forms.TextBox txt_amod_land_park_cost;
		public System.Windows.Forms.TextBox txt_amod_crew_exp_cost;
		public System.Windows.Forms.TextBox txt_amod_supplies_cost;
		public System.Windows.Forms.TextBox txt_amod_tot_hour_direct_cost;
		public System.Windows.Forms.TextBox txt_amod_avg_block_speed;
		public System.Windows.Forms.TextBox txt_amod_tot_stat_mile_cost;
		private System.Windows.Forms.Label _Label20_5;
		private System.Windows.Forms.Label _Label20_0;
		private System.Windows.Forms.Label _Label28_1;
		private System.Windows.Forms.Label _Label20_1;
		private System.Windows.Forms.Label _Label19_1;
		private System.Windows.Forms.Label _Label18_0;
		private System.Windows.Forms.Label _Label16_0;
		private System.Windows.Forms.Label _Label16_1;
		private System.Windows.Forms.Label _Label16_2;
		private System.Windows.Forms.Label _Label20_2;
		private System.Windows.Forms.Label _Label20_3;
		private System.Windows.Forms.Label _Label19_2;
		private System.Windows.Forms.Label _Label28_2;
		private System.Windows.Forms.Label _Label28_3;
		private System.Windows.Forms.Label _Label28_5;
		private System.Windows.Forms.Label _Label19_3;
		private System.Windows.Forms.Label _Label28_7;
		private System.Windows.Forms.Label _Label28_8;
		public System.Windows.Forms.Panel pnl_DirectCost;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage4;
		private System.Windows.Forms.TextBox _txt_amod_fuselage_length_9;
		private System.Windows.Forms.TextBox _txt_amod_fuselage_length_8;
		private System.Windows.Forms.TextBox _txt_amod_fuselage_length_6;
		private System.Windows.Forms.TextBox _txt_amod_fuselage_length_5;
		private System.Windows.Forms.TextBox _txt_amod_fuselage_length_4;
		private System.Windows.Forms.TextBox _txt_amod_fuselage_length_3;
		private System.Windows.Forms.TextBox _txt_amod_fuselage_length_2;
		private System.Windows.Forms.TextBox _txt_amod_fuselage_length_1;
		private System.Windows.Forms.Label _lbl_specs_86;
		private System.Windows.Forms.Label _lbl_specs_85;
		private System.Windows.Forms.Label _lbl_specs_84;
		private System.Windows.Forms.Label _lbl_specs_83;
		private System.Windows.Forms.Label _lbl_specs_82;
		private System.Windows.Forms.Label _lbl_specs_81;
		private System.Windows.Forms.Label _lbl_specs_80;
		private System.Windows.Forms.Label _lbl_specs_79;
		private System.Windows.Forms.Label _lbl_specs_78;
		private System.Windows.Forms.Label _lbl_specs_76;
		private System.Windows.Forms.Label _lbl_specs_75;
		private System.Windows.Forms.Label _lbl_specs_74;
		private System.Windows.Forms.Label _lbl_specs_69;
		public System.Windows.Forms.Panel pnlCabinDimension;
		public System.Windows.Forms.TextBox txt_amod_main_rotor_1_blade_count;
		public System.Windows.Forms.TextBox txt_amod_main_rotor_1_blade_diameter;
		public System.Windows.Forms.TextBox txt_amod_main_rotor_2_blade_count;
		public System.Windows.Forms.TextBox txt_amod_main_rotor_2_blade_diameter;
		public System.Windows.Forms.TextBox txt_amod_tail_rotor_blade_count;
		public System.Windows.Forms.TextBox txt_amod_tail_rotor_blade_diameter;
		public System.Windows.Forms.ComboBox cmb_amod_rotor_anti_torque_system;
		private System.Windows.Forms.Label _lbl_specs_38;
		private System.Windows.Forms.Label _lbl_specs_39;
		private System.Windows.Forms.Label _lbl_specs_48;
		private System.Windows.Forms.Label _lbl_specs_49;
		private System.Windows.Forms.Label _lbl_specs_54;
		private System.Windows.Forms.Label _lbl_specs_56;
		public System.Windows.Forms.Panel pnl_Rotors;
		public System.Windows.Forms.TextBox txt_amod_climb_engout_feet;
		public System.Windows.Forms.TextBox txt_amod_climb_normal_feet;
		public System.Windows.Forms.TextBox txt_amod_ceiling_feet;
		public System.Windows.Forms.TextBox txt_amod_climb_hoge;
		public System.Windows.Forms.TextBox txt_amod_climb_hige;
		private System.Windows.Forms.Label _lbl_specs_14;
		private System.Windows.Forms.Label _lbl_specs_13;
		private System.Windows.Forms.Label _lbl_specs_59;
		private System.Windows.Forms.Label _lbl_specs_62;
		private System.Windows.Forms.Label _lbl_specs_61;
		private System.Windows.Forms.Label _lbl_specs_60;
		public System.Windows.Forms.Panel pnl_Climb;
		private System.Windows.Forms.TextBox _txt_amod_speed_7;
		private System.Windows.Forms.TextBox _txt_amod_speed_6;
		private System.Windows.Forms.TextBox _txt_amod_speed_5;
		private System.Windows.Forms.TextBox _txt_amod_speed_4;
		private System.Windows.Forms.TextBox _txt_amod_speed_0;
		private System.Windows.Forms.TextBox _txt_amod_speed_1;
		private System.Windows.Forms.TextBox _txt_amod_speed_2;
		private System.Windows.Forms.TextBox _txt_amod_speed_3;
		private System.Windows.Forms.Label _lbl_specs_92;
		private System.Windows.Forms.Label _lbl_specs_91;
		private System.Windows.Forms.Label _lbl_specs_90;
		private System.Windows.Forms.Label _lbl_specs_89;
		private System.Windows.Forms.Label _lbl_specs_40;
		private System.Windows.Forms.Label _lbl_specs_41;
		private System.Windows.Forms.Label _lbl_specs_42;
		private System.Windows.Forms.Label _lbl_specs_43;
		public System.Windows.Forms.Panel pnl_Speed;
		public System.Windows.Forms.TextBox txt_amod_range_8_passenger;
		public System.Windows.Forms.TextBox txt_amod_range_4_passenger;
		public System.Windows.Forms.TextBox txt_amod_field_length;
		public System.Windows.Forms.TextBox txt_amod_takeoff_500;
		public System.Windows.Forms.TextBox txt_amod_takeoff_ali;
		public System.Windows.Forms.TextBox txt_amod_max_range_miles;
		public System.Windows.Forms.TextBox txt_amod_range_tanks_full;
		public System.Windows.Forms.TextBox txt_amod_range_seats_full;
		public System.Windows.Forms.ComboBox cmb_amod_ifr_certification;
		private System.Windows.Forms.Label _lbl_specs_88;
		private System.Windows.Forms.Label _lbl_specs_87;
		private System.Windows.Forms.Label _lbl_specs_53;
		private System.Windows.Forms.Label _lbl_specs_51;
		private System.Windows.Forms.Label _lbl_specs_73;
		private System.Windows.Forms.Label _lbl_specs_37;
		private System.Windows.Forms.Label _lbl_specs_15;
		private System.Windows.Forms.Label _lbl_specs_3;
		private System.Windows.Forms.Label _lbl_specs_50;
		private System.Windows.Forms.Label _lbl_specs_52;
		private System.Windows.Forms.Label _lbl_specs_64;
		private System.Windows.Forms.Label _lbl_specs_65;
		private System.Windows.Forms.Label _lbl_specs_66;
		public System.Windows.Forms.Panel pnl_OtherSpecs;
		public System.Windows.Forms.TextBox txt_amod_number_of_props;
		public System.Windows.Forms.TextBox txt_amod_prop_model_name;
		public System.Windows.Forms.TextBox txt_amod_prop_mfr_name;
		public System.Windows.Forms.TextBox txt_amod_prop_com_tbo_hrs;
		public System.Windows.Forms.TextBox txt_amod_prop_shaft;
		public System.Windows.Forms.TextBox txt_amod_prop_hsi;
		private System.Windows.Forms.Label _lbl_Prop_number_16;
		private System.Windows.Forms.Label _lbl_specs_45;
		private System.Windows.Forms.Label _lbl_specs_44;
		private System.Windows.Forms.Label _lbl_specs_46;
		private System.Windows.Forms.Label _lbl_specs_47;
		private System.Windows.Forms.Label _lbl_specs_36;
		public System.Windows.Forms.Panel pnl_Props;
		public System.Windows.Forms.TextBox txt_amod_fuselage_wingspan;
		public System.Windows.Forms.TextBox txt_amod_fuselage_height;
		private System.Windows.Forms.TextBox _txt_amod_fuselage_length_0;
		public System.Windows.Forms.TextBox txt_amod_fuselage_width;
		private System.Windows.Forms.Label _lbl_specs_71;
		private System.Windows.Forms.Label _lbl_specs_72;
		private System.Windows.Forms.Label _lbl_specs_70;
		private System.Windows.Forms.Label _lbl_specs_2;
		private System.Windows.Forms.Label _lbl_specs_1;
		private System.Windows.Forms.Label _lbl_specs_0;
		private System.Windows.Forms.Label _lbl_specs_57;
		private System.Windows.Forms.Label _lbl_specs_58;
		public System.Windows.Forms.Panel pnl_FuselageDimensions;
		public System.Windows.Forms.TextBox txt_amod_pressure;
		public System.Windows.Forms.TextBox txt_amod_number_of_passengers;
		public System.Windows.Forms.TextBox txt_amod_number_of_crew;
		private System.Windows.Forms.Label _lbl_specs_6;
		private System.Windows.Forms.Label _lbl_specs_5;
		private System.Windows.Forms.Label _lbl_specs_4;
		public System.Windows.Forms.Panel pnl_Config;
		public System.Windows.Forms.TextBox txt_amod_max_landing_weight;
		public System.Windows.Forms.TextBox txt_amod_basic_op_weight;
		public System.Windows.Forms.TextBox txt_amod_zero_fuel_weight;
		public System.Windows.Forms.TextBox txt_amod_max_takeoff_weight;
		public System.Windows.Forms.TextBox txt_amod_max_ramp_weight;
		public System.Windows.Forms.TextBox txt_amod_weight_eow;
		private System.Windows.Forms.Label _lbl_specs_31;
		private System.Windows.Forms.Label _lbl_specs_30;
		private System.Windows.Forms.Label _lbl_specs_29;
		private System.Windows.Forms.Label _lbl_specs_28;
		private System.Windows.Forms.Label _lbl_specs_27;
		private System.Windows.Forms.Label _lbl_specs_63;
		public System.Windows.Forms.Panel pnl_Weight;
		public System.Windows.Forms.TextBox txt_amod_fuel_cap_opt_gal;
		public System.Windows.Forms.TextBox txt_amod_fuel_cap_std_gal;
		public System.Windows.Forms.TextBox txt_amod_fuel_cap_opt_weight;
		public System.Windows.Forms.TextBox txt_amod_fuel_cap_std_weight;
		private System.Windows.Forms.Label _lbl_specs_12;
		private System.Windows.Forms.Label _lbl_specs_10;
		private System.Windows.Forms.Label _lbl_specs_11;
		private System.Windows.Forms.Label _lbl_specs_9;
		private System.Windows.Forms.Label _lbl_specs_8;
		private System.Windows.Forms.Label _lbl_specs_7;
		public System.Windows.Forms.Panel pnl_FuelCapacity;
		private System.Windows.Forms.Button _cmd_button_0;
		public System.Windows.Forms.ComboBox cbo_tbo_list;
		public System.Windows.Forms.CheckBox chk_oncondtbox;
		public System.Windows.Forms.TextBox txt_amod_engine_hsi;
		public System.Windows.Forms.TextBox txt_amod_engine_shaft;
		public System.Windows.Forms.TextBox txt_amod_engine_thrust_lbs;
		public System.Windows.Forms.TextBox txt_amod_number_of_engines;
		public System.Windows.Forms.ListBox lst_Spec_Engines;
		public System.Windows.Forms.Button cmd_Add_Engine;
		public System.Windows.Forms.Button cmd_Remove_Engine;
		private System.Windows.Forms.Label _lbl_specs_34;
		private System.Windows.Forms.Label _lbl_specs_21;
		private System.Windows.Forms.Label _lbl_specs_19;
		private System.Windows.Forms.Label _lbl_specs_18;
		private System.Windows.Forms.Label _lbl_specs_17;
		private System.Windows.Forms.Label _lbl_specs_16;
		private System.Windows.Forms.Label _lbl_specs_35;
		public System.Windows.Forms.Label Label22;
		public System.Windows.Forms.Label Label21;
		public System.Windows.Forms.Panel pnl_EngineData;
		public System.Windows.Forms.TextBox txt_amod_other_config_note;
		public System.Windows.Forms.Panel pnl_ConfigNote;
		public System.Windows.Forms.Button cmdFindEngineModel;
		public System.Windows.Forms.TextBox txt_ameng_mfr_name_short;
		public System.Windows.Forms.TextBox txt_ameng_mfr_CompID;
		public System.Windows.Forms.TextBox txt_ameng_seq_no;
		public System.Windows.Forms.TextBox txt_ameng_max_continuous_power;
		public System.Windows.Forms.TextBox txt_ameng_takeoff_power;
		public System.Windows.Forms.CheckBox Chk_ameng_active_flag;
		public System.Windows.Forms.Button cmd_Engine_Cancel;
		public System.Windows.Forms.TextBox txt_ameng_mfr_name;
		public System.Windows.Forms.TextBox txt_ameng_engine_prefix;
		public System.Windows.Forms.TextBox txt_ameng_engine_core;
		public System.Windows.Forms.TextBox txt_ameng_engine_suffix1;
		public System.Windows.Forms.TextBox txt_ameng_engine_suffix2;
		public System.Windows.Forms.Button cmd_Engine_Save;
		private System.Windows.Forms.Label _lbl_specs_93;
		private System.Windows.Forms.Label _Label6_25;
		private System.Windows.Forms.Label _lbl_specs_68;
		private System.Windows.Forms.Label _lbl_specs_67;
		private System.Windows.Forms.Label _lbl_specs_33;
		private System.Windows.Forms.Label _lbl_specs_32;
		private System.Windows.Forms.Label _lbl_specs_26;
		private System.Windows.Forms.Label _lbl_specs_20;
		private System.Windows.Forms.Label _lbl_specs_22;
		private System.Windows.Forms.Label _lbl_specs_23;
		private System.Windows.Forms.Label _lbl_specs_24;
		private System.Windows.Forms.Label _lbl_specs_25;
		public System.Windows.Forms.Panel pnl_Aircraft_Model_Engine_Add;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage5;
		public System.Windows.Forms.TextBox txt_amod_maint_note;
		public System.Windows.Forms.TextBox txt_amod_inspection_note;
		private System.Windows.Forms.Label _Label6_16;
		private System.Windows.Forms.Label _Label6_17;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage6;
		public System.Windows.Forms.TextBox txt_amod_upd_user_id;
		public System.Windows.Forms.TextBox txt_amod_ent_user_id;
		public System.Windows.Forms.TextBox txt_amod_ent_date;
		public System.Windows.Forms.TextBox txt_amod_upd_date;
		public System.Windows.Forms.TextBox txt_amod_sale_verify_days;
		public System.Windows.Forms.TextBox txt_amod_common_verify_days;
		public System.Windows.Forms.CheckBox chk_amod_customer_flag;
		private System.Windows.Forms.Label _Label6_21;
		private System.Windows.Forms.Label _Label6_20;
		private System.Windows.Forms.Label _Label6_18;
		private System.Windows.Forms.Label _Label6_19;
		private System.Windows.Forms.Label _Label6_22;
		private System.Windows.Forms.Label _Label6_23;
		private System.Windows.Forms.Label _Label6_24;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage7;
		private System.Windows.Forms.Button _cmdUseage_0;
		private System.Windows.Forms.Button _cmdUseage_1;
		public System.Windows.Forms.ListBox UsageList;
		private System.Windows.Forms.Button _cmdUseage_4;
		public System.Windows.Forms.ComboBox cmbUsage;
		private System.Windows.Forms.Button _cmdUseage_3;
		private System.Windows.Forms.Button _cmdUseage_2;
		public System.Windows.Forms.Panel pnl_Useage_Add;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage8;
		private System.Windows.Forms.Button _cmd_Make_Move1_2;
		private System.Windows.Forms.Button _cmd_Make_Move1_1;
		private System.Windows.Forms.Button _cmd_Make_Move1_0;
		public System.Windows.Forms.ComboBox cbo_MakeSelect;
		public UpgradeHelpers.DataGridViewFlex grd_MakeSort;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage9;
		private System.Windows.Forms.Button _CMDModelMap_2;
		private System.Windows.Forms.Button _CMDModelMap_1;
		private System.Windows.Forms.Button _CMDModelMap_0;
		public System.Windows.Forms.ComboBox cmbHbaseModels;
		private System.Windows.Forms.Label _lbl_spec_2;
		private System.Windows.Forms.Label _lbl_spec_1;
		public System.Windows.Forms.GroupBox frmodelMap;
		public UpgradeHelpers.DataGridViewFlex grdModelMap;
		public UpgradeHelpers.DataGridViewFlex grdAircraftMap;
		private System.Windows.Forms.Label _lbl_spec_3;
		private System.Windows.Forms.Label _lbl_spec_0;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage10;
		public System.Windows.Forms.TextBox txt_intel;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage11;
		public UpgradeHelpers.DataGridViewFlex grd_eventlog;
		public System.Windows.Forms.Button cmd_new;
		public UpgradeHelpers.DataGridViewFlex grd_amod_journal;
		private System.Windows.Forms.Label _Label6_36;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage12;
		private System.Windows.Forms.TabPage _tab_Aircraft_Model_TabPage13;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_Aircraft_Model;
		public System.Windows.Forms.TextBox txt_amod_icao;
		public System.Windows.Forms.ComboBox cboJIQSize;
		private System.Windows.Forms.TextBox _txt_amod_fuselage_length_7;
		public System.Windows.Forms.ComboBox cbo_amod_Airframe_Type_Code;
		private System.Windows.Forms.TextBox _txt_amod_manufacturer_2;
		private System.Windows.Forms.TextBox _txt_amod_manufacturer_1;
		private System.Windows.Forms.TextBox _txt_amod_manufacturer_0;
		public System.Windows.Forms.TextBox txt_amod_make_abbrev;
		public System.Windows.Forms.TextBox txt_amod_model_abbrev;
		public System.Windows.Forms.ComboBox cboWeightClass;
		public System.Windows.Forms.ComboBox cbo_amod_type_code;
		public System.Windows.Forms.TextBox txt_amod_make_name;
		public System.Windows.Forms.TextBox txt_amod_model_name;
		public System.Windows.Forms.ComboBox cbo_amod_class;
		public System.Windows.Forms.ComboBox CmbResearchType;
		public System.Windows.Forms.TextBox txt_amod_id;
		public System.Windows.Forms.HScrollBar scr_Models;
		public System.Windows.Forms.TextBox txt_model_number;
		public System.Windows.Forms.TextBox txt_model_total;
		public System.Windows.Forms.ComboBox cbo_Model;
		public System.Windows.Forms.Panel SSPanel3;
		private System.Windows.Forms.Label _Label6_9;
		private System.Windows.Forms.Label _Label6_10;
		public System.Windows.Forms.Panel pnl_Model_Top;
		private System.Windows.Forms.Label _Label6_35;
		private System.Windows.Forms.Label _Label6_34;
		private System.Windows.Forms.Label _Label6_29;
		private System.Windows.Forms.Label _Label6_1;
		private System.Windows.Forms.Label _Label6_32;
		private System.Windows.Forms.Label _Label6_28;
		private System.Windows.Forms.Label _Label6_27;
		private System.Windows.Forms.Label _Label6_6;
		private System.Windows.Forms.Label _Label6_4;
		private System.Windows.Forms.Label _Label6_3;
		private System.Windows.Forms.Label _Label2_0;
		private System.Windows.Forms.Label _Label6_7;
		private System.Windows.Forms.Label _Label6_0;
		private System.Windows.Forms.Label _Label6_2;
		public System.Windows.Forms.Panel pnl_ModelMain;
		public System.Windows.Forms.Label lbl_Status;
		public System.Windows.Forms.GroupBox frame_Status;
		private System.Windows.Forms.Label _lbl_specs_77;
		private System.Windows.Forms.Label _Label13_2;
		public System.Windows.Forms.Button[] CMDModelMap = new System.Windows.Forms.Button[3];
		public System.Windows.Forms.Label[] Label13 = new System.Windows.Forms.Label[9];
		public System.Windows.Forms.Label[] Label16 = new System.Windows.Forms.Label[14];
		public System.Windows.Forms.Label[] Label17 = new System.Windows.Forms.Label[7];
		public System.Windows.Forms.Label[] Label18 = new System.Windows.Forms.Label[9];
		public System.Windows.Forms.Label[] Label19 = new System.Windows.Forms.Label[7];
		public System.Windows.Forms.Label[] Label2 = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.Label[] Label20 = new System.Windows.Forms.Label[6];
		public System.Windows.Forms.Label[] Label28 = new System.Windows.Forms.Label[9];
		public System.Windows.Forms.Label[] Label6 = new System.Windows.Forms.Label[37];
		public System.Windows.Forms.Label[] Lable13 = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.TextBox[] Text1 = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.CheckBox[] chk_amod_product = new System.Windows.Forms.CheckBox[6];
		public System.Windows.Forms.Button[] cmdUseage = new System.Windows.Forms.Button[5];
		public System.Windows.Forms.Button[] cmd_Make_Move1 = new System.Windows.Forms.Button[3];
		public System.Windows.Forms.Button[] cmd_button = new System.Windows.Forms.Button[1];
		public System.Windows.Forms.Button[] cmd_button_array = new System.Windows.Forms.Button[9];
		public System.Windows.Forms.Label[] lbl_Prop_number = new System.Windows.Forms.Label[17];
		public System.Windows.Forms.Label[] lbl_spec = new System.Windows.Forms.Label[9];
		public System.Windows.Forms.Label[] lbl_specs = new System.Windows.Forms.Label[94];
		public System.Windows.Forms.TextBox[] txt_amod_fuselage_length = new System.Windows.Forms.TextBox[10];
		public System.Windows.Forms.TextBox[] txt_amod_manufacturer = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] txt_amod_speed = new System.Windows.Forms.TextBox[8];
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		private int tab_Aircraft_ModelPreviousTab;
		public System.ComponentModel.ComponentResourceManager resources;
	    //NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Aircraft_Model));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnu_File = new System.Windows.Forms.ToolStripMenuItem();
			mnu_File_Close = new System.Windows.Forms.ToolStripMenuItem();
			mnu_File_Logout = new System.Windows.Forms.ToolStripMenuItem();
			mnu_Edit = new System.Windows.Forms.ToolStripMenuItem();
			mnuAttachPicture = new System.Windows.Forms.ToolStripMenuItem();
			mnu_EditAdd = new System.Windows.Forms.ToolStripMenuItem();
			mnuAddAircraft = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditSummaries = new System.Windows.Forms.ToolStripMenuItem();
			mnuReport = new System.Windows.Forms.ToolStripMenuItem();
			ModelSpec = new System.Windows.Forms.ToolStripMenuItem();
			GenericReport = new System.Windows.Forms.ToolStripMenuItem();
			mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			mnuDeleteModel = new System.Windows.Forms.ToolStripMenuItem();
			pnl_PriceRange = new System.Windows.Forms.Panel();
			cmbBodyConfig = new System.Windows.Forms.ComboBox();
			_chk_amod_product_5 = new System.Windows.Forms.CheckBox();
			_chk_amod_product_3 = new System.Windows.Forms.CheckBox();
			_chk_amod_product_4 = new System.Windows.Forms.CheckBox();
			_chk_amod_product_2 = new System.Windows.Forms.CheckBox();
			_chk_amod_product_1 = new System.Windows.Forms.CheckBox();
			_chk_amod_product_0 = new System.Windows.Forms.CheckBox();
			_Label6_33 = new System.Windows.Forms.Label();
			Line1 = new System.Windows.Forms.Label();
			SSPanel1 = new System.Windows.Forms.Panel();
			txt_amod_ser_no_suffix = new System.Windows.Forms.TextBox();
			chk_amod_hyphen_flag = new System.Windows.Forms.CheckBox();
			txt_amod_ser_no_start = new System.Windows.Forms.TextBox();
			txt_amod_ser_no_end = new System.Windows.Forms.TextBox();
			txt_amod_ser_no_prefix = new System.Windows.Forms.TextBox();
			_Label6_15 = new System.Windows.Forms.Label();
			_Label6_14 = new System.Windows.Forms.Label();
			_Label6_13 = new System.Windows.Forms.Label();
			_Label6_12 = new System.Windows.Forms.Label();
			ponl_YearsBuilt = new System.Windows.Forms.Panel();
			cmd_Update = new System.Windows.Forms.Button();
			txt_amod_end_price = new System.Windows.Forms.TextBox();
			txt_amod_start_price = new System.Windows.Forms.TextBox();
			txt_amod_end_year = new System.Windows.Forms.TextBox();
			txt_amod_start_year = new System.Windows.Forms.TextBox();
			_Label6_8 = new System.Windows.Forms.Label();
			_Label6_26 = new System.Windows.Forms.Label();
			_Label6_5 = new System.Windows.Forms.Label();
			tbr_ToolBar = new System.Windows.Forms.ToolStrip();
			tbr_ToolBar_Buttons_Button1 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button2 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button3 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button4 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button5 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button6 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button7 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button8 = new System.Windows.Forms.ToolStripButton();
			tab_Aircraft_Model = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_Aircraft_Model_TabPage0 = new System.Windows.Forms.TabPage();
			_lbl_spec_8 = new System.Windows.Forms.Label();
			_lbl_specs_55 = new System.Windows.Forms.Label();
			img_Model_Picture = new System.Windows.Forms.PictureBox();
			lbl_Description = new System.Windows.Forms.Label();
			lbl_Message = new System.Windows.Forms.Label();
			_Label6_11 = new System.Windows.Forms.Label();
			grd_Aircraft = new UpgradeHelpers.DataGridViewFlex(components);
			txt_TotalAircraft = new System.Windows.Forms.TextBox();
			_Text1_1 = new System.Windows.Forms.TextBox();
			txt_amod_description = new System.Windows.Forms.TextBox();
			cmdStop = new System.Windows.Forms.Button();
			_Text1_0 = new System.Windows.Forms.TextBox();
			_Text1_2 = new System.Windows.Forms.TextBox();
			cmdTemp = new System.Windows.Forms.Button();
			_tab_Aircraft_Model_TabPage1 = new System.Windows.Forms.TabPage();
			_cmd_button_array_2 = new System.Windows.Forms.Button();
			pnl_ModelFeatures = new System.Windows.Forms.Panel();
			_cmd_button_array_5 = new System.Windows.Forms.Button();
			_cmd_button_array_1 = new System.Windows.Forms.Button();
			chkFeatCount = new System.Windows.Forms.CheckBox();
			_cmd_button_array_0 = new System.Windows.Forms.Button();
			grd_Keyfeature = new UpgradeHelpers.DataGridViewFlex(components);
			lblFeatureUnknown = new System.Windows.Forms.Label();
			lblFeatureNo = new System.Windows.Forms.Label();
			lblFeatureYes = new System.Windows.Forms.Label();
			pnl_MasterKeyFeatures = new System.Windows.Forms.Panel();
			_cmd_button_array_4 = new System.Windows.Forms.Button();
			_cmd_button_array_3 = new System.Windows.Forms.Button();
			lst_MasterKeyFeature = new System.Windows.Forms.ListBox();
			pnl_FeatureDisplay = new System.Windows.Forms.Panel();
			_cmd_button_array_8 = new System.Windows.Forms.Button();
			_cmd_button_array_7 = new System.Windows.Forms.Button();
			_cmd_button_array_6 = new System.Windows.Forms.Button();
			txt_InactiveDate = new System.Windows.Forms.TextBox();
			chk_Inactive_Feature_Code = new System.Windows.Forms.CheckBox();
			txtFeatEndSerNo = new System.Windows.Forms.TextBox();
			txtFeatStartSerNo = new System.Windows.Forms.TextBox();
			chkStandard = new System.Windows.Forms.CheckBox();
			_Label6_31 = new System.Windows.Forms.Label();
			_Label6_30 = new System.Windows.Forms.Label();
			lbl_FeatureMessage = new System.Windows.Forms.Label();
			lbl_FeatureDescription = new System.Windows.Forms.Label();
			_tab_Aircraft_Model_TabPage2 = new System.Windows.Forms.TabPage();
			grd_ModelTrend = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_Aircraft_Model_TabPage3 = new System.Windows.Forms.TabPage();
			lst_aircraft_wanted = new System.Windows.Forms.ListBox();
			_Label13_8 = new System.Windows.Forms.Label();
			_Label13_7 = new System.Windows.Forms.Label();
			_Label13_6 = new System.Windows.Forms.Label();
			_Label13_5 = new System.Windows.Forms.Label();
			_Label13_4 = new System.Windows.Forms.Label();
			_Lable13_2 = new System.Windows.Forms.Label();
			_Label13_1 = new System.Windows.Forms.Label();
			_Label13_0 = new System.Windows.Forms.Label();
			_tab_Aircraft_Model_TabPage4 = new System.Windows.Forms.TabPage();
			pnl_AnnualBudget = new System.Windows.Forms.Panel();
			txt_amod_annual_hours = new System.Windows.Forms.TextBox();
			txt_amod_annual_miles = new System.Windows.Forms.TextBox();
			txt_amod_number_of_seats = new System.Windows.Forms.TextBox();
			txt_amod_tot_direct_cost = new System.Windows.Forms.TextBox();
			txt_amod_tot_fixed_cost2 = new System.Windows.Forms.TextBox();
			txt_amod_tot_df_seat_cost = new System.Windows.Forms.TextBox();
			txt_amod_tot_df_statmile_cost = new System.Windows.Forms.TextBox();
			txt_amod_tot_df_hour_cost = new System.Windows.Forms.TextBox();
			txt_amod_tot_df_annual_cost = new System.Windows.Forms.TextBox();
			txt_amod_tot_nd_seat_cost = new System.Windows.Forms.TextBox();
			txt_amod_tot_nd_statmile_cost = new System.Windows.Forms.TextBox();
			txt_amod_tot_nd_hour_cost = new System.Windows.Forms.TextBox();
			txt_amod_tot_nd_annual_cost = new System.Windows.Forms.TextBox();
			_Label18_6 = new System.Windows.Forms.Label();
			_Label17_4 = new System.Windows.Forms.Label();
			_Label16_7 = new System.Windows.Forms.Label();
			_Label16_8 = new System.Windows.Forms.Label();
			_Label16_9 = new System.Windows.Forms.Label();
			_Label18_7 = new System.Windows.Forms.Label();
			_Label17_5 = new System.Windows.Forms.Label();
			_Label16_10 = new System.Windows.Forms.Label();
			_Label16_11 = new System.Windows.Forms.Label();
			_Label18_8 = new System.Windows.Forms.Label();
			_Label17_6 = new System.Windows.Forms.Label();
			_Label16_12 = new System.Windows.Forms.Label();
			_Label16_13 = new System.Windows.Forms.Label();
			pnl_FixedCosts = new System.Windows.Forms.Panel();
			txt_var_misc = new System.Windows.Forms.TextBox();
			txt_amod_tot_variable_cost = new System.Windows.Forms.TextBox();
			txt_amod_liability_insurance_cost = new System.Windows.Forms.TextBox();
			txt_amod_hull_insurance_cost = new System.Windows.Forms.TextBox();
			txt_amod_insurance_cost = new System.Windows.Forms.TextBox();
			txt_amod_crew_benefit_cost = new System.Windows.Forms.TextBox();
			txt_amod_cpilot_salary_cost = new System.Windows.Forms.TextBox();
			txt_amod_capt_salary_cost = new System.Windows.Forms.TextBox();
			txt_amod_tot_crew_salary_cost = new System.Windows.Forms.TextBox();
			txt_amod_hangar_cost = new System.Windows.Forms.TextBox();
			txt_amod_misc_naveq_cost = new System.Windows.Forms.TextBox();
			txt_amod_misc_modern_cost = new System.Windows.Forms.TextBox();
			txt_amod_misc_train_cost = new System.Windows.Forms.TextBox();
			txt_amod_tot_misc_ovh_cost = new System.Windows.Forms.TextBox();
			txt_amod_tot_fixed_cost = new System.Windows.Forms.TextBox();
			txt_amod_deprec_cost = new System.Windows.Forms.TextBox();
			_Label19_6 = new System.Windows.Forms.Label();
			_Label19_0 = new System.Windows.Forms.Label();
			_Label28_6 = new System.Windows.Forms.Label();
			_Label20_4 = new System.Windows.Forms.Label();
			_Label19_4 = new System.Windows.Forms.Label();
			_Label18_2 = new System.Windows.Forms.Label();
			_Label17_2 = new System.Windows.Forms.Label();
			_Label16_3 = new System.Windows.Forms.Label();
			_Label16_4 = new System.Windows.Forms.Label();
			_Label18_3 = new System.Windows.Forms.Label();
			_Label18_4 = new System.Windows.Forms.Label();
			_Label17_3 = new System.Windows.Forms.Label();
			_Label16_5 = new System.Windows.Forms.Label();
			_Label16_6 = new System.Windows.Forms.Label();
			_Label19_5 = new System.Windows.Forms.Label();
			_Label18_5 = new System.Windows.Forms.Label();
			pnl_DirectCost = new System.Windows.Forms.Panel();
			txt_amod_maint_parts_man_hour_multiplier = new System.Windows.Forms.TextBox();
			txt_amod_maint_labor_man_hour_multiplier = new System.Windows.Forms.TextBox();
			txt_amod_maint_parts_cost = new System.Windows.Forms.TextBox();
			txt_amod_maint_lab_cost = new System.Windows.Forms.TextBox();
			txt_amod_maint_tot_cost = new System.Windows.Forms.TextBox();
			txt_amod_fuel_burn_rate = new System.Windows.Forms.TextBox();
			txt_amod_fuel_add_cost = new System.Windows.Forms.TextBox();
			txt_amod_fuel_gal_cost = new System.Windows.Forms.TextBox();
			txt_amod_fuel_tot_cost = new System.Windows.Forms.TextBox();
			txt_amod_engine_ovh_cost = new System.Windows.Forms.TextBox();
			txt_amod_thrust_rev_ovh_cost = new System.Windows.Forms.TextBox();
			txt_amod_misc_flight_cost = new System.Windows.Forms.TextBox();
			txt_amod_land_park_cost = new System.Windows.Forms.TextBox();
			txt_amod_crew_exp_cost = new System.Windows.Forms.TextBox();
			txt_amod_supplies_cost = new System.Windows.Forms.TextBox();
			txt_amod_tot_hour_direct_cost = new System.Windows.Forms.TextBox();
			txt_amod_avg_block_speed = new System.Windows.Forms.TextBox();
			txt_amod_tot_stat_mile_cost = new System.Windows.Forms.TextBox();
			_Label20_5 = new System.Windows.Forms.Label();
			_Label20_0 = new System.Windows.Forms.Label();
			_Label28_1 = new System.Windows.Forms.Label();
			_Label20_1 = new System.Windows.Forms.Label();
			_Label19_1 = new System.Windows.Forms.Label();
			_Label18_0 = new System.Windows.Forms.Label();
			_Label16_0 = new System.Windows.Forms.Label();
			_Label16_1 = new System.Windows.Forms.Label();
			_Label16_2 = new System.Windows.Forms.Label();
			_Label20_2 = new System.Windows.Forms.Label();
			_Label20_3 = new System.Windows.Forms.Label();
			_Label19_2 = new System.Windows.Forms.Label();
			_Label28_2 = new System.Windows.Forms.Label();
			_Label28_3 = new System.Windows.Forms.Label();
			_Label28_5 = new System.Windows.Forms.Label();
			_Label19_3 = new System.Windows.Forms.Label();
			_Label28_7 = new System.Windows.Forms.Label();
			_Label28_8 = new System.Windows.Forms.Label();
			_tab_Aircraft_Model_TabPage5 = new System.Windows.Forms.TabPage();
			pnl_Rotors = new System.Windows.Forms.Panel();
			pnlCabinDimension = new System.Windows.Forms.Panel();
			_txt_amod_fuselage_length_9 = new System.Windows.Forms.TextBox();
			_txt_amod_fuselage_length_8 = new System.Windows.Forms.TextBox();
			_txt_amod_fuselage_length_6 = new System.Windows.Forms.TextBox();
			_txt_amod_fuselage_length_5 = new System.Windows.Forms.TextBox();
			_txt_amod_fuselage_length_4 = new System.Windows.Forms.TextBox();
			_txt_amod_fuselage_length_3 = new System.Windows.Forms.TextBox();
			_txt_amod_fuselage_length_2 = new System.Windows.Forms.TextBox();
			_txt_amod_fuselage_length_1 = new System.Windows.Forms.TextBox();
			_lbl_specs_86 = new System.Windows.Forms.Label();
			_lbl_specs_85 = new System.Windows.Forms.Label();
			_lbl_specs_84 = new System.Windows.Forms.Label();
			_lbl_specs_83 = new System.Windows.Forms.Label();
			_lbl_specs_82 = new System.Windows.Forms.Label();
			_lbl_specs_81 = new System.Windows.Forms.Label();
			_lbl_specs_80 = new System.Windows.Forms.Label();
			_lbl_specs_79 = new System.Windows.Forms.Label();
			_lbl_specs_78 = new System.Windows.Forms.Label();
			_lbl_specs_76 = new System.Windows.Forms.Label();
			_lbl_specs_75 = new System.Windows.Forms.Label();
			_lbl_specs_74 = new System.Windows.Forms.Label();
			_lbl_specs_69 = new System.Windows.Forms.Label();
			txt_amod_main_rotor_1_blade_count = new System.Windows.Forms.TextBox();
			txt_amod_main_rotor_1_blade_diameter = new System.Windows.Forms.TextBox();
			txt_amod_main_rotor_2_blade_count = new System.Windows.Forms.TextBox();
			txt_amod_main_rotor_2_blade_diameter = new System.Windows.Forms.TextBox();
			txt_amod_tail_rotor_blade_count = new System.Windows.Forms.TextBox();
			txt_amod_tail_rotor_blade_diameter = new System.Windows.Forms.TextBox();
			cmb_amod_rotor_anti_torque_system = new System.Windows.Forms.ComboBox();
			_lbl_specs_38 = new System.Windows.Forms.Label();
			_lbl_specs_39 = new System.Windows.Forms.Label();
			_lbl_specs_48 = new System.Windows.Forms.Label();
			_lbl_specs_49 = new System.Windows.Forms.Label();
			_lbl_specs_54 = new System.Windows.Forms.Label();
			_lbl_specs_56 = new System.Windows.Forms.Label();
			pnl_Climb = new System.Windows.Forms.Panel();
			txt_amod_climb_engout_feet = new System.Windows.Forms.TextBox();
			txt_amod_climb_normal_feet = new System.Windows.Forms.TextBox();
			txt_amod_ceiling_feet = new System.Windows.Forms.TextBox();
			txt_amod_climb_hoge = new System.Windows.Forms.TextBox();
			txt_amod_climb_hige = new System.Windows.Forms.TextBox();
			_lbl_specs_14 = new System.Windows.Forms.Label();
			_lbl_specs_13 = new System.Windows.Forms.Label();
			_lbl_specs_59 = new System.Windows.Forms.Label();
			_lbl_specs_62 = new System.Windows.Forms.Label();
			_lbl_specs_61 = new System.Windows.Forms.Label();
			_lbl_specs_60 = new System.Windows.Forms.Label();
			pnl_Speed = new System.Windows.Forms.Panel();
			_txt_amod_speed_7 = new System.Windows.Forms.TextBox();
			_txt_amod_speed_6 = new System.Windows.Forms.TextBox();
			_txt_amod_speed_5 = new System.Windows.Forms.TextBox();
			_txt_amod_speed_4 = new System.Windows.Forms.TextBox();
			_txt_amod_speed_0 = new System.Windows.Forms.TextBox();
			_txt_amod_speed_1 = new System.Windows.Forms.TextBox();
			_txt_amod_speed_2 = new System.Windows.Forms.TextBox();
			_txt_amod_speed_3 = new System.Windows.Forms.TextBox();
			_lbl_specs_92 = new System.Windows.Forms.Label();
			_lbl_specs_91 = new System.Windows.Forms.Label();
			_lbl_specs_90 = new System.Windows.Forms.Label();
			_lbl_specs_89 = new System.Windows.Forms.Label();
			_lbl_specs_40 = new System.Windows.Forms.Label();
			_lbl_specs_41 = new System.Windows.Forms.Label();
			_lbl_specs_42 = new System.Windows.Forms.Label();
			_lbl_specs_43 = new System.Windows.Forms.Label();
			pnl_OtherSpecs = new System.Windows.Forms.Panel();
			txt_amod_range_8_passenger = new System.Windows.Forms.TextBox();
			txt_amod_range_4_passenger = new System.Windows.Forms.TextBox();
			txt_amod_field_length = new System.Windows.Forms.TextBox();
			txt_amod_takeoff_500 = new System.Windows.Forms.TextBox();
			txt_amod_takeoff_ali = new System.Windows.Forms.TextBox();
			txt_amod_max_range_miles = new System.Windows.Forms.TextBox();
			txt_amod_range_tanks_full = new System.Windows.Forms.TextBox();
			txt_amod_range_seats_full = new System.Windows.Forms.TextBox();
			cmb_amod_ifr_certification = new System.Windows.Forms.ComboBox();
			_lbl_specs_88 = new System.Windows.Forms.Label();
			_lbl_specs_87 = new System.Windows.Forms.Label();
			_lbl_specs_53 = new System.Windows.Forms.Label();
			_lbl_specs_51 = new System.Windows.Forms.Label();
			_lbl_specs_73 = new System.Windows.Forms.Label();
			_lbl_specs_37 = new System.Windows.Forms.Label();
			_lbl_specs_15 = new System.Windows.Forms.Label();
			_lbl_specs_3 = new System.Windows.Forms.Label();
			_lbl_specs_50 = new System.Windows.Forms.Label();
			_lbl_specs_52 = new System.Windows.Forms.Label();
			_lbl_specs_64 = new System.Windows.Forms.Label();
			_lbl_specs_65 = new System.Windows.Forms.Label();
			_lbl_specs_66 = new System.Windows.Forms.Label();
			pnl_Props = new System.Windows.Forms.Panel();
			txt_amod_number_of_props = new System.Windows.Forms.TextBox();
			txt_amod_prop_model_name = new System.Windows.Forms.TextBox();
			txt_amod_prop_mfr_name = new System.Windows.Forms.TextBox();
			txt_amod_prop_com_tbo_hrs = new System.Windows.Forms.TextBox();
			txt_amod_prop_shaft = new System.Windows.Forms.TextBox();
			txt_amod_prop_hsi = new System.Windows.Forms.TextBox();
			_lbl_Prop_number_16 = new System.Windows.Forms.Label();
			_lbl_specs_45 = new System.Windows.Forms.Label();
			_lbl_specs_44 = new System.Windows.Forms.Label();
			_lbl_specs_46 = new System.Windows.Forms.Label();
			_lbl_specs_47 = new System.Windows.Forms.Label();
			_lbl_specs_36 = new System.Windows.Forms.Label();
			pnl_FuselageDimensions = new System.Windows.Forms.Panel();
			txt_amod_fuselage_wingspan = new System.Windows.Forms.TextBox();
			txt_amod_fuselage_height = new System.Windows.Forms.TextBox();
			_txt_amod_fuselage_length_0 = new System.Windows.Forms.TextBox();
			txt_amod_fuselage_width = new System.Windows.Forms.TextBox();
			_lbl_specs_71 = new System.Windows.Forms.Label();
			_lbl_specs_72 = new System.Windows.Forms.Label();
			_lbl_specs_70 = new System.Windows.Forms.Label();
			_lbl_specs_2 = new System.Windows.Forms.Label();
			_lbl_specs_1 = new System.Windows.Forms.Label();
			_lbl_specs_0 = new System.Windows.Forms.Label();
			_lbl_specs_57 = new System.Windows.Forms.Label();
			_lbl_specs_58 = new System.Windows.Forms.Label();
			pnl_Config = new System.Windows.Forms.Panel();
			txt_amod_pressure = new System.Windows.Forms.TextBox();
			txt_amod_number_of_passengers = new System.Windows.Forms.TextBox();
			txt_amod_number_of_crew = new System.Windows.Forms.TextBox();
			_lbl_specs_6 = new System.Windows.Forms.Label();
			_lbl_specs_5 = new System.Windows.Forms.Label();
			_lbl_specs_4 = new System.Windows.Forms.Label();
			pnl_Weight = new System.Windows.Forms.Panel();
			txt_amod_max_landing_weight = new System.Windows.Forms.TextBox();
			txt_amod_basic_op_weight = new System.Windows.Forms.TextBox();
			txt_amod_zero_fuel_weight = new System.Windows.Forms.TextBox();
			txt_amod_max_takeoff_weight = new System.Windows.Forms.TextBox();
			txt_amod_max_ramp_weight = new System.Windows.Forms.TextBox();
			txt_amod_weight_eow = new System.Windows.Forms.TextBox();
			_lbl_specs_31 = new System.Windows.Forms.Label();
			_lbl_specs_30 = new System.Windows.Forms.Label();
			_lbl_specs_29 = new System.Windows.Forms.Label();
			_lbl_specs_28 = new System.Windows.Forms.Label();
			_lbl_specs_27 = new System.Windows.Forms.Label();
			_lbl_specs_63 = new System.Windows.Forms.Label();
			pnl_FuelCapacity = new System.Windows.Forms.Panel();
			txt_amod_fuel_cap_opt_gal = new System.Windows.Forms.TextBox();
			txt_amod_fuel_cap_std_gal = new System.Windows.Forms.TextBox();
			txt_amod_fuel_cap_opt_weight = new System.Windows.Forms.TextBox();
			txt_amod_fuel_cap_std_weight = new System.Windows.Forms.TextBox();
			_lbl_specs_12 = new System.Windows.Forms.Label();
			_lbl_specs_10 = new System.Windows.Forms.Label();
			_lbl_specs_11 = new System.Windows.Forms.Label();
			_lbl_specs_9 = new System.Windows.Forms.Label();
			_lbl_specs_8 = new System.Windows.Forms.Label();
			_lbl_specs_7 = new System.Windows.Forms.Label();
			pnl_EngineData = new System.Windows.Forms.Panel();
			_cmd_button_0 = new System.Windows.Forms.Button();
			cbo_tbo_list = new System.Windows.Forms.ComboBox();
			chk_oncondtbox = new System.Windows.Forms.CheckBox();
			txt_amod_engine_hsi = new System.Windows.Forms.TextBox();
			txt_amod_engine_shaft = new System.Windows.Forms.TextBox();
			txt_amod_engine_thrust_lbs = new System.Windows.Forms.TextBox();
			txt_amod_number_of_engines = new System.Windows.Forms.TextBox();
			lst_Spec_Engines = new System.Windows.Forms.ListBox();
			cmd_Add_Engine = new System.Windows.Forms.Button();
			cmd_Remove_Engine = new System.Windows.Forms.Button();
			_lbl_specs_34 = new System.Windows.Forms.Label();
			_lbl_specs_21 = new System.Windows.Forms.Label();
			_lbl_specs_19 = new System.Windows.Forms.Label();
			_lbl_specs_18 = new System.Windows.Forms.Label();
			_lbl_specs_17 = new System.Windows.Forms.Label();
			_lbl_specs_16 = new System.Windows.Forms.Label();
			_lbl_specs_35 = new System.Windows.Forms.Label();
			Label22 = new System.Windows.Forms.Label();
			Label21 = new System.Windows.Forms.Label();
			pnl_ConfigNote = new System.Windows.Forms.Panel();
			txt_amod_other_config_note = new System.Windows.Forms.TextBox();
			pnl_Aircraft_Model_Engine_Add = new System.Windows.Forms.Panel();
			cmdFindEngineModel = new System.Windows.Forms.Button();
			txt_ameng_mfr_name_short = new System.Windows.Forms.TextBox();
			txt_ameng_mfr_CompID = new System.Windows.Forms.TextBox();
			txt_ameng_seq_no = new System.Windows.Forms.TextBox();
			txt_ameng_max_continuous_power = new System.Windows.Forms.TextBox();
			txt_ameng_takeoff_power = new System.Windows.Forms.TextBox();
			Chk_ameng_active_flag = new System.Windows.Forms.CheckBox();
			cmd_Engine_Cancel = new System.Windows.Forms.Button();
			txt_ameng_mfr_name = new System.Windows.Forms.TextBox();
			txt_ameng_engine_prefix = new System.Windows.Forms.TextBox();
			txt_ameng_engine_core = new System.Windows.Forms.TextBox();
			txt_ameng_engine_suffix1 = new System.Windows.Forms.TextBox();
			txt_ameng_engine_suffix2 = new System.Windows.Forms.TextBox();
			cmd_Engine_Save = new System.Windows.Forms.Button();
			_lbl_specs_93 = new System.Windows.Forms.Label();
			_Label6_25 = new System.Windows.Forms.Label();
			_lbl_specs_68 = new System.Windows.Forms.Label();
			_lbl_specs_67 = new System.Windows.Forms.Label();
			_lbl_specs_33 = new System.Windows.Forms.Label();
			_lbl_specs_32 = new System.Windows.Forms.Label();
			_lbl_specs_26 = new System.Windows.Forms.Label();
			_lbl_specs_20 = new System.Windows.Forms.Label();
			_lbl_specs_22 = new System.Windows.Forms.Label();
			_lbl_specs_23 = new System.Windows.Forms.Label();
			_lbl_specs_24 = new System.Windows.Forms.Label();
			_lbl_specs_25 = new System.Windows.Forms.Label();
			_tab_Aircraft_Model_TabPage6 = new System.Windows.Forms.TabPage();
			txt_amod_maint_note = new System.Windows.Forms.TextBox();
			txt_amod_inspection_note = new System.Windows.Forms.TextBox();
			_Label6_16 = new System.Windows.Forms.Label();
			_Label6_17 = new System.Windows.Forms.Label();
			_tab_Aircraft_Model_TabPage7 = new System.Windows.Forms.TabPage();
			txt_amod_upd_user_id = new System.Windows.Forms.TextBox();
			txt_amod_ent_user_id = new System.Windows.Forms.TextBox();
			txt_amod_ent_date = new System.Windows.Forms.TextBox();
			txt_amod_upd_date = new System.Windows.Forms.TextBox();
			txt_amod_sale_verify_days = new System.Windows.Forms.TextBox();
			txt_amod_common_verify_days = new System.Windows.Forms.TextBox();
			chk_amod_customer_flag = new System.Windows.Forms.CheckBox();
			_Label6_21 = new System.Windows.Forms.Label();
			_Label6_20 = new System.Windows.Forms.Label();
			_Label6_18 = new System.Windows.Forms.Label();
			_Label6_19 = new System.Windows.Forms.Label();
			_Label6_22 = new System.Windows.Forms.Label();
			_Label6_23 = new System.Windows.Forms.Label();
			_Label6_24 = new System.Windows.Forms.Label();
			_tab_Aircraft_Model_TabPage8 = new System.Windows.Forms.TabPage();
			_cmdUseage_0 = new System.Windows.Forms.Button();
			_cmdUseage_1 = new System.Windows.Forms.Button();
			UsageList = new System.Windows.Forms.ListBox();
			_cmdUseage_4 = new System.Windows.Forms.Button();
			pnl_Useage_Add = new System.Windows.Forms.Panel();
			cmbUsage = new System.Windows.Forms.ComboBox();
			_cmdUseage_3 = new System.Windows.Forms.Button();
			_cmdUseage_2 = new System.Windows.Forms.Button();
			_tab_Aircraft_Model_TabPage9 = new System.Windows.Forms.TabPage();
			_cmd_Make_Move1_2 = new System.Windows.Forms.Button();
			_cmd_Make_Move1_1 = new System.Windows.Forms.Button();
			_cmd_Make_Move1_0 = new System.Windows.Forms.Button();
			cbo_MakeSelect = new System.Windows.Forms.ComboBox();
			grd_MakeSort = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_Aircraft_Model_TabPage10 = new System.Windows.Forms.TabPage();
			frmodelMap = new System.Windows.Forms.GroupBox();
			_CMDModelMap_2 = new System.Windows.Forms.Button();
			_CMDModelMap_1 = new System.Windows.Forms.Button();
			_CMDModelMap_0 = new System.Windows.Forms.Button();
			cmbHbaseModels = new System.Windows.Forms.ComboBox();
			_lbl_spec_2 = new System.Windows.Forms.Label();
			_lbl_spec_1 = new System.Windows.Forms.Label();
			grdModelMap = new UpgradeHelpers.DataGridViewFlex(components);
			grdAircraftMap = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_spec_3 = new System.Windows.Forms.Label();
			_lbl_spec_0 = new System.Windows.Forms.Label();
			_tab_Aircraft_Model_TabPage11 = new System.Windows.Forms.TabPage();
			txt_intel = new System.Windows.Forms.TextBox();
			_tab_Aircraft_Model_TabPage12 = new System.Windows.Forms.TabPage();
			grd_eventlog = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_new = new System.Windows.Forms.Button();
			grd_amod_journal = new UpgradeHelpers.DataGridViewFlex(components);
			_Label6_36 = new System.Windows.Forms.Label();
			_tab_Aircraft_Model_TabPage13 = new System.Windows.Forms.TabPage();
			pnl_ModelMain = new System.Windows.Forms.Panel();
			txt_amod_icao = new System.Windows.Forms.TextBox();
			cboJIQSize = new System.Windows.Forms.ComboBox();
			_txt_amod_fuselage_length_7 = new System.Windows.Forms.TextBox();
			cbo_amod_Airframe_Type_Code = new System.Windows.Forms.ComboBox();
			_txt_amod_manufacturer_2 = new System.Windows.Forms.TextBox();
			_txt_amod_manufacturer_1 = new System.Windows.Forms.TextBox();
			_txt_amod_manufacturer_0 = new System.Windows.Forms.TextBox();
			txt_amod_make_abbrev = new System.Windows.Forms.TextBox();
			txt_amod_model_abbrev = new System.Windows.Forms.TextBox();
			cboWeightClass = new System.Windows.Forms.ComboBox();
			cbo_amod_type_code = new System.Windows.Forms.ComboBox();
			txt_amod_make_name = new System.Windows.Forms.TextBox();
			txt_amod_model_name = new System.Windows.Forms.TextBox();
			cbo_amod_class = new System.Windows.Forms.ComboBox();
			pnl_Model_Top = new System.Windows.Forms.Panel();
			CmbResearchType = new System.Windows.Forms.ComboBox();
			txt_amod_id = new System.Windows.Forms.TextBox();
			scr_Models = new System.Windows.Forms.HScrollBar();
			txt_model_number = new System.Windows.Forms.TextBox();
			txt_model_total = new System.Windows.Forms.TextBox();
			cbo_Model = new System.Windows.Forms.ComboBox();
			SSPanel3 = new System.Windows.Forms.Panel();
			_Label6_9 = new System.Windows.Forms.Label();
			_Label6_10 = new System.Windows.Forms.Label();
			_Label6_35 = new System.Windows.Forms.Label();
			_Label6_34 = new System.Windows.Forms.Label();
			_Label6_29 = new System.Windows.Forms.Label();
			_Label6_1 = new System.Windows.Forms.Label();
			_Label6_32 = new System.Windows.Forms.Label();
			_Label6_28 = new System.Windows.Forms.Label();
			_Label6_27 = new System.Windows.Forms.Label();
			_Label6_6 = new System.Windows.Forms.Label();
			_Label6_4 = new System.Windows.Forms.Label();
			_Label6_3 = new System.Windows.Forms.Label();
			_Label2_0 = new System.Windows.Forms.Label();
			_Label6_7 = new System.Windows.Forms.Label();
			_Label6_0 = new System.Windows.Forms.Label();
			_Label6_2 = new System.Windows.Forms.Label();
			frame_Status = new System.Windows.Forms.GroupBox();
			lbl_Status = new System.Windows.Forms.Label();
			_lbl_specs_77 = new System.Windows.Forms.Label();
			_Label13_2 = new System.Windows.Forms.Label();
			pnl_PriceRange.SuspendLayout();
			SSPanel1.SuspendLayout();
			ponl_YearsBuilt.SuspendLayout();
			tbr_ToolBar.SuspendLayout();
			tab_Aircraft_Model.SuspendLayout();
			_tab_Aircraft_Model_TabPage0.SuspendLayout();
			_tab_Aircraft_Model_TabPage1.SuspendLayout();
			pnl_ModelFeatures.SuspendLayout();
			pnl_MasterKeyFeatures.SuspendLayout();
			pnl_FeatureDisplay.SuspendLayout();
			_tab_Aircraft_Model_TabPage2.SuspendLayout();
			_tab_Aircraft_Model_TabPage3.SuspendLayout();
			_tab_Aircraft_Model_TabPage4.SuspendLayout();
			pnl_AnnualBudget.SuspendLayout();
			pnl_FixedCosts.SuspendLayout();
			pnl_DirectCost.SuspendLayout();
			_tab_Aircraft_Model_TabPage5.SuspendLayout();
			pnl_Rotors.SuspendLayout();
			pnlCabinDimension.SuspendLayout();
			pnl_Climb.SuspendLayout();
			pnl_Speed.SuspendLayout();
			pnl_OtherSpecs.SuspendLayout();
			pnl_Props.SuspendLayout();
			pnl_FuselageDimensions.SuspendLayout();
			pnl_Config.SuspendLayout();
			pnl_Weight.SuspendLayout();
			pnl_FuelCapacity.SuspendLayout();
			pnl_EngineData.SuspendLayout();
			pnl_ConfigNote.SuspendLayout();
			pnl_Aircraft_Model_Engine_Add.SuspendLayout();
			_tab_Aircraft_Model_TabPage6.SuspendLayout();
			_tab_Aircraft_Model_TabPage7.SuspendLayout();
			_tab_Aircraft_Model_TabPage8.SuspendLayout();
			pnl_Useage_Add.SuspendLayout();
			_tab_Aircraft_Model_TabPage9.SuspendLayout();
			_tab_Aircraft_Model_TabPage10.SuspendLayout();
			frmodelMap.SuspendLayout();
			_tab_Aircraft_Model_TabPage11.SuspendLayout();
			_tab_Aircraft_Model_TabPage12.SuspendLayout();
			pnl_ModelMain.SuspendLayout();
			pnl_Model_Top.SuspendLayout();
			frame_Status.SuspendLayout();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_Aircraft).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Keyfeature).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_ModelTrend).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_MakeSort).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdModelMap).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdAircraftMap).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_eventlog).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_amod_journal).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnu_File, mnu_Edit, mnuReport, mnuHelp, mnuDeleteModel});
			// 
			// mnu_File
			// 
			mnu_File.Available = true;
			mnu_File.Checked = false;
			mnu_File.Enabled = true;
			mnu_File.Name = "mnu_File";
			mnu_File.Text = "File";
			mnu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnu_File_Close, mnu_File_Logout});
			// 
			// mnu_File_Close
			// 
			mnu_File_Close.Available = true;
			mnu_File_Close.Checked = false;
			mnu_File_Close.Enabled = true;
			mnu_File_Close.Name = "mnu_File_Close";
			mnu_File_Close.Text = "Close";
			mnu_File_Close.Click += new System.EventHandler(mnu_File_Close_Click);
			// 
			// mnu_File_Logout
			// 
			mnu_File_Logout.Available = true;
			mnu_File_Logout.Checked = false;
			mnu_File_Logout.Enabled = true;
			mnu_File_Logout.Name = "mnu_File_Logout";
			mnu_File_Logout.Text = "Logout";
			mnu_File_Logout.Click += new System.EventHandler(mnu_File_Logout_Click);
			// 
			// mnu_Edit
			// 
			mnu_Edit.Available = true;
			mnu_Edit.Checked = false;
			mnu_Edit.Enabled = true;
			mnu_Edit.Name = "mnu_Edit";
			mnu_Edit.Text = "Edit";
			mnu_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuAttachPicture, mnu_EditAdd, mnuAddAircraft, mnuEditSummaries});
			// 
			// mnuAttachPicture
			// 
			mnuAttachPicture.Available = true;
			mnuAttachPicture.Checked = false;
			mnuAttachPicture.Enabled = true;
			mnuAttachPicture.Name = "mnuAttachPicture";
			mnuAttachPicture.Text = "Attach Picture";
			mnuAttachPicture.Click += new System.EventHandler(mnuAttachPicture_Click);
			// 
			// mnu_EditAdd
			// 
			mnu_EditAdd.Available = true;
			mnu_EditAdd.Checked = false;
			mnu_EditAdd.Enabled = true;
			mnu_EditAdd.Name = "mnu_EditAdd";
			mnu_EditAdd.Text = "Add New Aircraft Model";
			mnu_EditAdd.Click += new System.EventHandler(mnu_EditAdd_Click);
			// 
			// mnuAddAircraft
			// 
			mnuAddAircraft.Available = true;
			mnuAddAircraft.Checked = false;
			mnuAddAircraft.Enabled = true;
			mnuAddAircraft.Name = "mnuAddAircraft";
			mnuAddAircraft.Text = "Add New Aircraft";
			mnuAddAircraft.Click += new System.EventHandler(mnuAddAircraft_Click);
			// 
			// mnuEditSummaries
			// 
			mnuEditSummaries.Available = false;
			mnuEditSummaries.Checked = false;
			mnuEditSummaries.Enabled = false;
			mnuEditSummaries.Name = "mnuEditSummaries";
			mnuEditSummaries.Text = "Market Summaries";
			mnuEditSummaries.Click += new System.EventHandler(mnuEditSummaries_Click);
			// 
			// mnuReport
			// 
			mnuReport.Available = true;
			mnuReport.Checked = false;
			mnuReport.Enabled = true;
			mnuReport.Name = "mnuReport";
			mnuReport.Text = "&Reports";
			mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{ModelSpec, GenericReport});
			// 
			// ModelSpec
			// 
			ModelSpec.Available = true;
			ModelSpec.Checked = false;
			ModelSpec.Enabled = true;
			ModelSpec.Name = "ModelSpec";
			ModelSpec.Text = "Model Spec Report";
			ModelSpec.Click += new System.EventHandler(ModelSpec_Click);
			// 
			// GenericReport
			// 
			GenericReport.Available = true;
			GenericReport.Checked = false;
			GenericReport.Enabled = true;
			GenericReport.Name = "GenericReport";
			GenericReport.Text = "Generic Report";
			GenericReport.Click += new System.EventHandler(GenericReport_Click);
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
			// mnuDeleteModel
			// 
			mnuDeleteModel.Available = true;
			mnuDeleteModel.Checked = false;
			mnuDeleteModel.Enabled = true;
			mnuDeleteModel.Name = "mnuDeleteModel";
			mnuDeleteModel.Text = "&Delete Model";
			mnuDeleteModel.Click += new System.EventHandler(mnuDeleteModel_Click);
			// 
			// pnl_PriceRange
			// 
			pnl_PriceRange.AllowDrop = true;
			pnl_PriceRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_PriceRange.Controls.Add(cmbBodyConfig);
			pnl_PriceRange.Controls.Add(_chk_amod_product_5);
			pnl_PriceRange.Controls.Add(_chk_amod_product_3);
			pnl_PriceRange.Controls.Add(_chk_amod_product_4);
			pnl_PriceRange.Controls.Add(_chk_amod_product_2);
			pnl_PriceRange.Controls.Add(_chk_amod_product_1);
			pnl_PriceRange.Controls.Add(_chk_amod_product_0);
			pnl_PriceRange.Controls.Add(_Label6_33);
			pnl_PriceRange.Controls.Add(Line1);
			pnl_PriceRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_PriceRange.Location = new System.Drawing.Point(739, 52);
			pnl_PriceRange.Name = "pnl_PriceRange";
			pnl_PriceRange.Size = new System.Drawing.Size(163, 122);
			pnl_PriceRange.TabIndex = 132;
			// 
			// cmbBodyConfig
			// 
			cmbBodyConfig.AllowDrop = true;
			cmbBodyConfig.BackColor = System.Drawing.SystemColors.Window;
			cmbBodyConfig.CausesValidation = true;
			cmbBodyConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmbBodyConfig.Enabled = true;
			cmbBodyConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbBodyConfig.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbBodyConfig.IntegralHeight = true;
			cmbBodyConfig.Location = new System.Drawing.Point(6, 98);
			cmbBodyConfig.Name = "cmbBodyConfig";
			cmbBodyConfig.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbBodyConfig.Size = new System.Drawing.Size(149, 21);
			cmbBodyConfig.Sorted = false;
			cmbBodyConfig.TabIndex = 29;
			cmbBodyConfig.TabStop = true;
			cmbBodyConfig.Visible = true;
			// 
			// _chk_amod_product_5
			// 
			_chk_amod_product_5.AllowDrop = true;
			_chk_amod_product_5.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_amod_product_5.BackColor = System.Drawing.SystemColors.Control;
			_chk_amod_product_5.CausesValidation = true;
			_chk_amod_product_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_amod_product_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_amod_product_5.Enabled = true;
			_chk_amod_product_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_amod_product_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_amod_product_5.Location = new System.Drawing.Point(85, 58);
			_chk_amod_product_5.Name = "_chk_amod_product_5";
			_chk_amod_product_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_amod_product_5.Size = new System.Drawing.Size(74, 21);
			_chk_amod_product_5.TabIndex = 28;
			_chk_amod_product_5.TabStop = true;
			_chk_amod_product_5.Text = "Regional";
			_chk_amod_product_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_amod_product_5.Visible = true;
			_chk_amod_product_5.CheckStateChanged += new System.EventHandler(chk_amod_product_CheckStateChanged);
			// 
			// _chk_amod_product_3
			// 
			_chk_amod_product_3.AllowDrop = true;
			_chk_amod_product_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_amod_product_3.BackColor = System.Drawing.SystemColors.Control;
			_chk_amod_product_3.CausesValidation = true;
			_chk_amod_product_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_amod_product_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_amod_product_3.Enabled = true;
			_chk_amod_product_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_amod_product_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_amod_product_3.Location = new System.Drawing.Point(85, 38);
			_chk_amod_product_3.Name = "_chk_amod_product_3";
			_chk_amod_product_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_amod_product_3.Size = new System.Drawing.Size(49, 21);
			_chk_amod_product_3.TabIndex = 26;
			_chk_amod_product_3.TabStop = true;
			_chk_amod_product_3.Text = "ABI";
			_chk_amod_product_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_amod_product_3.Visible = true;
			_chk_amod_product_3.CheckStateChanged += new System.EventHandler(chk_amod_product_CheckStateChanged);
			// 
			// _chk_amod_product_4
			// 
			_chk_amod_product_4.AllowDrop = true;
			_chk_amod_product_4.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_amod_product_4.BackColor = System.Drawing.SystemColors.Control;
			_chk_amod_product_4.CausesValidation = true;
			_chk_amod_product_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_amod_product_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_amod_product_4.Enabled = true;
			_chk_amod_product_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_amod_product_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_amod_product_4.Location = new System.Drawing.Point(5, 58);
			_chk_amod_product_4.Name = "_chk_amod_product_4";
			_chk_amod_product_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_amod_product_4.Size = new System.Drawing.Size(49, 21);
			_chk_amod_product_4.TabIndex = 27;
			_chk_amod_product_4.TabStop = true;
			_chk_amod_product_4.Text = "Air BP";
			_chk_amod_product_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_amod_product_4.Visible = true;
			_chk_amod_product_4.CheckStateChanged += new System.EventHandler(chk_amod_product_CheckStateChanged);
			// 
			// _chk_amod_product_2
			// 
			_chk_amod_product_2.AllowDrop = true;
			_chk_amod_product_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_amod_product_2.BackColor = System.Drawing.SystemColors.Control;
			_chk_amod_product_2.CausesValidation = true;
			_chk_amod_product_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_amod_product_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_amod_product_2.Enabled = true;
			_chk_amod_product_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_amod_product_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_amod_product_2.Location = new System.Drawing.Point(5, 38);
			_chk_amod_product_2.Name = "_chk_amod_product_2";
			_chk_amod_product_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_amod_product_2.Size = new System.Drawing.Size(74, 21);
			_chk_amod_product_2.TabIndex = 25;
			_chk_amod_product_2.TabStop = true;
			_chk_amod_product_2.Text = "Commercial";
			_chk_amod_product_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_amod_product_2.Visible = true;
			_chk_amod_product_2.CheckStateChanged += new System.EventHandler(chk_amod_product_CheckStateChanged);
			// 
			// _chk_amod_product_1
			// 
			_chk_amod_product_1.AllowDrop = true;
			_chk_amod_product_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_amod_product_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_amod_product_1.CausesValidation = true;
			_chk_amod_product_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_amod_product_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_amod_product_1.Enabled = true;
			_chk_amod_product_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_amod_product_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_amod_product_1.Location = new System.Drawing.Point(85, 18);
			_chk_amod_product_1.Name = "_chk_amod_product_1";
			_chk_amod_product_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_amod_product_1.Size = new System.Drawing.Size(74, 21);
			_chk_amod_product_1.TabIndex = 24;
			_chk_amod_product_1.TabStop = true;
			_chk_amod_product_1.Text = "Helicopter";
			_chk_amod_product_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_amod_product_1.Visible = true;
			_chk_amod_product_1.CheckStateChanged += new System.EventHandler(chk_amod_product_CheckStateChanged);
			// 
			// _chk_amod_product_0
			// 
			_chk_amod_product_0.AllowDrop = true;
			_chk_amod_product_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_amod_product_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_amod_product_0.CausesValidation = true;
			_chk_amod_product_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_amod_product_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_amod_product_0.Enabled = true;
			_chk_amod_product_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_amod_product_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_chk_amod_product_0.Location = new System.Drawing.Point(5, 18);
			_chk_amod_product_0.Name = "_chk_amod_product_0";
			_chk_amod_product_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_amod_product_0.Size = new System.Drawing.Size(74, 21);
			_chk_amod_product_0.TabIndex = 23;
			_chk_amod_product_0.TabStop = true;
			_chk_amod_product_0.Text = "Business";
			_chk_amod_product_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_amod_product_0.Visible = true;
			_chk_amod_product_0.CheckStateChanged += new System.EventHandler(chk_amod_product_CheckStateChanged);
			// 
			// _Label6_33
			// 
			_Label6_33.AllowDrop = true;
			_Label6_33.AutoSize = true;
			_Label6_33.BackColor = System.Drawing.Color.Transparent;
			_Label6_33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_33.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_33.Location = new System.Drawing.Point(52, 84);
			_Label6_33.MinimumSize = new System.Drawing.Size(69, 13);
			_Label6_33.Name = "_Label6_33";
			_Label6_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_33.Size = new System.Drawing.Size(69, 13);
			_Label6_33.TabIndex = 422;
			_Label6_33.Text = "Body Config";
			// 
			// Line1
			// 
			Line1.AllowDrop = true;
			Line1.BackColor = System.Drawing.SystemColors.WindowText;
			Line1.Enabled = false;
			Line1.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Line1.Location = new System.Drawing.Point(4, 82);
			Line1.Name = "Line1";
			Line1.Size = new System.Drawing.Size(152, 1);
			Line1.Visible = true;
			// 
			// SSPanel1
			// 
			SSPanel1.AllowDrop = true;
			SSPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel1.Controls.Add(txt_amod_ser_no_suffix);
			SSPanel1.Controls.Add(chk_amod_hyphen_flag);
			SSPanel1.Controls.Add(txt_amod_ser_no_start);
			SSPanel1.Controls.Add(txt_amod_ser_no_end);
			SSPanel1.Controls.Add(txt_amod_ser_no_prefix);
			SSPanel1.Controls.Add(_Label6_15);
			SSPanel1.Controls.Add(_Label6_14);
			SSPanel1.Controls.Add(_Label6_13);
			SSPanel1.Controls.Add(_Label6_12);
			SSPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel1.Location = new System.Drawing.Point(902, 52);
			SSPanel1.Name = "SSPanel1";
			SSPanel1.Size = new System.Drawing.Size(109, 122);
			SSPanel1.TabIndex = 133;
			// 
			// txt_amod_ser_no_suffix
			// 
			txt_amod_ser_no_suffix.AcceptsReturn = true;
			txt_amod_ser_no_suffix.AllowDrop = true;
			txt_amod_ser_no_suffix.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_ser_no_suffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_ser_no_suffix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_ser_no_suffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_ser_no_suffix.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_ser_no_suffix.Location = new System.Drawing.Point(37, 99);
			txt_amod_ser_no_suffix.MaxLength = 5;
			txt_amod_ser_no_suffix.Name = "txt_amod_ser_no_suffix";
			txt_amod_ser_no_suffix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_ser_no_suffix.Size = new System.Drawing.Size(64, 19);
			txt_amod_ser_no_suffix.TabIndex = 34;
			txt_amod_ser_no_suffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_ser_no_suffix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_amod_ser_no_suffix_KeyPress);
			txt_amod_ser_no_suffix.Leave += new System.EventHandler(txt_amod_ser_no_suffix_Leave);
			// 
			// chk_amod_hyphen_flag
			// 
			chk_amod_hyphen_flag.AllowDrop = true;
			chk_amod_hyphen_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_amod_hyphen_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_amod_hyphen_flag.CausesValidation = true;
			chk_amod_hyphen_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_amod_hyphen_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_amod_hyphen_flag.Enabled = true;
			chk_amod_hyphen_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_amod_hyphen_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_amod_hyphen_flag.Location = new System.Drawing.Point(4, 19);
			chk_amod_hyphen_flag.Name = "chk_amod_hyphen_flag";
			chk_amod_hyphen_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_amod_hyphen_flag.Size = new System.Drawing.Size(94, 16);
			chk_amod_hyphen_flag.TabIndex = 30;
			chk_amod_hyphen_flag.TabStop = true;
			chk_amod_hyphen_flag.Text = "Hyphen ?";
			chk_amod_hyphen_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_amod_hyphen_flag.Visible = true;
			// 
			// txt_amod_ser_no_start
			// 
			txt_amod_ser_no_start.AcceptsReturn = true;
			txt_amod_ser_no_start.AllowDrop = true;
			txt_amod_ser_no_start.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_ser_no_start.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_ser_no_start.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_ser_no_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_ser_no_start.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_ser_no_start.Location = new System.Drawing.Point(37, 57);
			txt_amod_ser_no_start.MaxLength = 8;
			txt_amod_ser_no_start.Name = "txt_amod_ser_no_start";
			txt_amod_ser_no_start.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_ser_no_start.Size = new System.Drawing.Size(64, 19);
			txt_amod_ser_no_start.TabIndex = 32;
			txt_amod_ser_no_start.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_ser_no_end
			// 
			txt_amod_ser_no_end.AcceptsReturn = true;
			txt_amod_ser_no_end.AllowDrop = true;
			txt_amod_ser_no_end.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_ser_no_end.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_ser_no_end.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_ser_no_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_ser_no_end.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_ser_no_end.Location = new System.Drawing.Point(37, 78);
			txt_amod_ser_no_end.MaxLength = 8;
			txt_amod_ser_no_end.Name = "txt_amod_ser_no_end";
			txt_amod_ser_no_end.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_ser_no_end.Size = new System.Drawing.Size(64, 19);
			txt_amod_ser_no_end.TabIndex = 33;
			txt_amod_ser_no_end.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_ser_no_prefix
			// 
			txt_amod_ser_no_prefix.AcceptsReturn = true;
			txt_amod_ser_no_prefix.AllowDrop = true;
			txt_amod_ser_no_prefix.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_ser_no_prefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_ser_no_prefix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_ser_no_prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_ser_no_prefix.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_ser_no_prefix.Location = new System.Drawing.Point(37, 36);
			txt_amod_ser_no_prefix.MaxLength = 7;
			txt_amod_ser_no_prefix.Name = "txt_amod_ser_no_prefix";
			txt_amod_ser_no_prefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_ser_no_prefix.Size = new System.Drawing.Size(64, 19);
			txt_amod_ser_no_prefix.TabIndex = 31;
			txt_amod_ser_no_prefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_ser_no_prefix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_amod_ser_no_prefix_KeyPress);
			txt_amod_ser_no_prefix.Leave += new System.EventHandler(txt_amod_ser_no_prefix_Leave);
			txt_amod_ser_no_prefix.TextChanged += new System.EventHandler(txt_amod_ser_no_prefix_TextChanged);
			// 
			// _Label6_15
			// 
			_Label6_15.AllowDrop = true;
			_Label6_15.AutoSize = true;
			_Label6_15.BackColor = System.Drawing.Color.Transparent;
			_Label6_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_15.Location = new System.Drawing.Point(4, 102);
			_Label6_15.MinimumSize = new System.Drawing.Size(29, 13);
			_Label6_15.Name = "_Label6_15";
			_Label6_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_15.Size = new System.Drawing.Size(29, 13);
			_Label6_15.TabIndex = 396;
			_Label6_15.Text = "Suffix:";
			// 
			// _Label6_14
			// 
			_Label6_14.AllowDrop = true;
			_Label6_14.AutoSize = true;
			_Label6_14.BackColor = System.Drawing.Color.Transparent;
			_Label6_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_14.Location = new System.Drawing.Point(11, 81);
			_Label6_14.MinimumSize = new System.Drawing.Size(22, 13);
			_Label6_14.Name = "_Label6_14";
			_Label6_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_14.Size = new System.Drawing.Size(22, 13);
			_Label6_14.TabIndex = 188;
			_Label6_14.Text = "End:";
			// 
			// _Label6_13
			// 
			_Label6_13.AllowDrop = true;
			_Label6_13.AutoSize = true;
			_Label6_13.BackColor = System.Drawing.Color.Transparent;
			_Label6_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_13.Location = new System.Drawing.Point(8, 60);
			_Label6_13.MinimumSize = new System.Drawing.Size(25, 13);
			_Label6_13.Name = "_Label6_13";
			_Label6_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_13.Size = new System.Drawing.Size(25, 13);
			_Label6_13.TabIndex = 187;
			_Label6_13.Text = "Start:";
			// 
			// _Label6_12
			// 
			_Label6_12.AllowDrop = true;
			_Label6_12.AutoSize = true;
			_Label6_12.BackColor = System.Drawing.Color.Transparent;
			_Label6_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_12.Location = new System.Drawing.Point(4, 39);
			_Label6_12.MinimumSize = new System.Drawing.Size(29, 13);
			_Label6_12.Name = "_Label6_12";
			_Label6_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_12.Size = new System.Drawing.Size(29, 13);
			_Label6_12.TabIndex = 134;
			_Label6_12.Text = "Prefix:";
			// 
			// ponl_YearsBuilt
			// 
			ponl_YearsBuilt.AllowDrop = true;
			ponl_YearsBuilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			ponl_YearsBuilt.Controls.Add(cmd_Update);
			ponl_YearsBuilt.Controls.Add(txt_amod_end_price);
			ponl_YearsBuilt.Controls.Add(txt_amod_start_price);
			ponl_YearsBuilt.Controls.Add(txt_amod_end_year);
			ponl_YearsBuilt.Controls.Add(txt_amod_start_year);
			ponl_YearsBuilt.Controls.Add(_Label6_8);
			ponl_YearsBuilt.Controls.Add(_Label6_26);
			ponl_YearsBuilt.Controls.Add(_Label6_5);
			ponl_YearsBuilt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ponl_YearsBuilt.Location = new System.Drawing.Point(608, 52);
			ponl_YearsBuilt.Name = "ponl_YearsBuilt";
			ponl_YearsBuilt.Size = new System.Drawing.Size(132, 122);
			ponl_YearsBuilt.TabIndex = 130;
			// 
			// cmd_Update
			// 
			cmd_Update.AllowDrop = true;
			cmd_Update.BackColor = System.Drawing.SystemColors.Control;
			cmd_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Update.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Update.Location = new System.Drawing.Point(24, 98);
			cmd_Update.Name = "cmd_Update";
			cmd_Update.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Update.Size = new System.Drawing.Size(79, 21);
			cmd_Update.TabIndex = 436;
			cmd_Update.Text = "&Save Model";
			cmd_Update.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Update.UseVisualStyleBackColor = false;
			cmd_Update.Click += new System.EventHandler(cmd_Update_Click);
			// 
			// txt_amod_end_price
			// 
			txt_amod_end_price.AcceptsReturn = true;
			txt_amod_end_price.AllowDrop = true;
			txt_amod_end_price.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_end_price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_end_price.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_end_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_end_price.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_end_price.Location = new System.Drawing.Point(21, 76);
			txt_amod_end_price.MaxLength = 0;
			txt_amod_end_price.Name = "txt_amod_end_price";
			txt_amod_end_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_end_price.Size = new System.Drawing.Size(91, 19);
			txt_amod_end_price.TabIndex = 22;
			txt_amod_end_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_end_price.Leave += new System.EventHandler(txt_amod_end_price_Leave);
			// 
			// txt_amod_start_price
			// 
			txt_amod_start_price.AcceptsReturn = true;
			txt_amod_start_price.AllowDrop = true;
			txt_amod_start_price.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_start_price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_start_price.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_start_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_start_price.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_start_price.Location = new System.Drawing.Point(21, 56);
			txt_amod_start_price.MaxLength = 0;
			txt_amod_start_price.Name = "txt_amod_start_price";
			txt_amod_start_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_start_price.Size = new System.Drawing.Size(91, 19);
			txt_amod_start_price.TabIndex = 21;
			txt_amod_start_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_start_price.Leave += new System.EventHandler(txt_amod_start_price_Leave);
			// 
			// txt_amod_end_year
			// 
			txt_amod_end_year.AcceptsReturn = true;
			txt_amod_end_year.AllowDrop = true;
			txt_amod_end_year.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_end_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_end_year.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_end_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_end_year.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_end_year.Location = new System.Drawing.Point(92, 18);
			txt_amod_end_year.MaxLength = 4;
			txt_amod_end_year.Name = "txt_amod_end_year";
			txt_amod_end_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_end_year.Size = new System.Drawing.Size(33, 22);
			txt_amod_end_year.TabIndex = 20;
			// 
			// txt_amod_start_year
			// 
			txt_amod_start_year.AcceptsReturn = true;
			txt_amod_start_year.AllowDrop = true;
			txt_amod_start_year.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_start_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_start_year.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_start_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_start_year.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_start_year.Location = new System.Drawing.Point(30, 18);
			txt_amod_start_year.MaxLength = 4;
			txt_amod_start_year.Name = "txt_amod_start_year";
			txt_amod_start_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_start_year.Size = new System.Drawing.Size(33, 22);
			txt_amod_start_year.TabIndex = 19;
			// 
			// _Label6_8
			// 
			_Label6_8.AllowDrop = true;
			_Label6_8.AutoSize = true;
			_Label6_8.BackColor = System.Drawing.Color.Transparent;
			_Label6_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_8.Location = new System.Drawing.Point(64, 24);
			_Label6_8.MinimumSize = new System.Drawing.Size(22, 13);
			_Label6_8.Name = "_Label6_8";
			_Label6_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_8.Size = new System.Drawing.Size(22, 13);
			_Label6_8.TabIndex = 459;
			_Label6_8.Text = "End:";
			// 
			// _Label6_26
			// 
			_Label6_26.AllowDrop = true;
			_Label6_26.BackColor = System.Drawing.Color.Transparent;
			_Label6_26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_26.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_26.Location = new System.Drawing.Point(24, 41);
			_Label6_26.MinimumSize = new System.Drawing.Size(83, 13);
			_Label6_26.Name = "_Label6_26";
			_Label6_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_26.Size = new System.Drawing.Size(83, 13);
			_Label6_26.TabIndex = 387;
			_Label6_26.Text = "Price Range:";
			_Label6_26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _Label6_5
			// 
			_Label6_5.AllowDrop = true;
			_Label6_5.AutoSize = true;
			_Label6_5.BackColor = System.Drawing.Color.Transparent;
			_Label6_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_5.Location = new System.Drawing.Point(5, 23);
			_Label6_5.MinimumSize = new System.Drawing.Size(24, 13);
			_Label6_5.Name = "_Label6_5";
			_Label6_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_5.Size = new System.Drawing.Size(24, 13);
			_Label6_5.TabIndex = 131;
			_Label6_5.Text = "Start:";
			// 
			// tbr_ToolBar
			// 
			tbr_ToolBar.AllowDrop = true;
			tbr_ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
			tbr_ToolBar.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tbr_ToolBar.Location = new System.Drawing.Point(0, 24);
			tbr_ToolBar.Name = "tbr_ToolBar";
			tbr_ToolBar.ShowItemToolTips = true;
			tbr_ToolBar.Size = new System.Drawing.Size(1014, 28);
			tbr_ToolBar.TabIndex = 158;
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
			// tab_Aircraft_Model
			// 
			tab_Aircraft_Model.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_Aircraft_Model.AllowDrop = true;
			tab_Aircraft_Model.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage0);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage1);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage2);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage3);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage4);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage5);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage6);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage7);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage8);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage9);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage10);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage11);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage12);
			tab_Aircraft_Model.Controls.Add(_tab_Aircraft_Model_TabPage13);
			tab_Aircraft_Model.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_Aircraft_Model.ItemSize = new System.Drawing.Size(70, 18);
			tab_Aircraft_Model.Location = new System.Drawing.Point(4, 176);
			tab_Aircraft_Model.Multiline = true;
			tab_Aircraft_Model.Name = "tab_Aircraft_Model";
			tab_Aircraft_Model.Size = new System.Drawing.Size(1009, 527);
			tab_Aircraft_Model.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_Aircraft_Model.TabIndex = 51;
			tab_Aircraft_Model.Visible = false;
			tab_Aircraft_Model.SelectedIndexChanged += new System.EventHandler(tab_Aircraft_Model_SelectedIndexChanged);
			// 
			// _tab_Aircraft_Model_TabPage0
			// 
			_tab_Aircraft_Model_TabPage0.Controls.Add(_lbl_spec_8);
			_tab_Aircraft_Model_TabPage0.Controls.Add(_lbl_specs_55);
			_tab_Aircraft_Model_TabPage0.Controls.Add(img_Model_Picture);
			_tab_Aircraft_Model_TabPage0.Controls.Add(lbl_Description);
			_tab_Aircraft_Model_TabPage0.Controls.Add(lbl_Message);
			_tab_Aircraft_Model_TabPage0.Controls.Add(_Label6_11);
			_tab_Aircraft_Model_TabPage0.Controls.Add(grd_Aircraft);
			_tab_Aircraft_Model_TabPage0.Controls.Add(txt_TotalAircraft);
			_tab_Aircraft_Model_TabPage0.Controls.Add(_Text1_1);
			_tab_Aircraft_Model_TabPage0.Controls.Add(txt_amod_description);
			_tab_Aircraft_Model_TabPage0.Controls.Add(cmdStop);
			_tab_Aircraft_Model_TabPage0.Controls.Add(_Text1_0);
			_tab_Aircraft_Model_TabPage0.Controls.Add(_Text1_2);
			_tab_Aircraft_Model_TabPage0.Controls.Add(cmdTemp);
			_tab_Aircraft_Model_TabPage0.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage0.Text = "Aircraft List";
			// 
			// _lbl_spec_8
			// 
			_lbl_spec_8.AllowDrop = true;
			_lbl_spec_8.AutoSize = true;
			_lbl_spec_8.BackColor = System.Drawing.Color.Transparent;
			_lbl_spec_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_spec_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_spec_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_spec_8.Location = new System.Drawing.Point(16, 51);
			_lbl_spec_8.MinimumSize = new System.Drawing.Size(61, 13);
			_lbl_spec_8.Name = "_lbl_spec_8";
			_lbl_spec_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_spec_8.Size = new System.Drawing.Size(61, 13);
			_lbl_spec_8.TabIndex = 143;
			_lbl_spec_8.Text = "# of Aircraft: ";
			// 
			// _lbl_specs_55
			// 
			_lbl_specs_55.AllowDrop = true;
			_lbl_specs_55.AutoSize = true;
			_lbl_specs_55.BackColor = System.Drawing.Color.Transparent;
			_lbl_specs_55.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_55.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_55.Location = new System.Drawing.Point(384, 46);
			_lbl_specs_55.MinimumSize = new System.Drawing.Size(29, 13);
			_lbl_specs_55.Name = "_lbl_specs_55";
			_lbl_specs_55.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_55.Size = new System.Drawing.Size(29, 13);
			_lbl_specs_55.TabIndex = 173;
			_lbl_specs_55.Text = "KEY:";
			_lbl_specs_55.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_specs_55.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_55.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// img_Model_Picture
			// 
			img_Model_Picture.AllowDrop = true;
			img_Model_Picture.BorderStyle = System.Windows.Forms.BorderStyle.None;
			img_Model_Picture.Enabled = true;
			img_Model_Picture.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			img_Model_Picture.Location = new System.Drawing.Point(568, 31);
			img_Model_Picture.Name = "img_Model_Picture";
			img_Model_Picture.Size = new System.Drawing.Size(393, 323);
			img_Model_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			img_Model_Picture.Visible = true;
			// 
			// lbl_Description
			// 
			lbl_Description.AllowDrop = true;
			lbl_Description.AutoSize = true;
			lbl_Description.BackColor = System.Drawing.Color.Transparent;
			lbl_Description.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Description.ForeColor = System.Drawing.Color.Black;
			lbl_Description.Location = new System.Drawing.Point(703, 356);
			lbl_Description.MinimumSize = new System.Drawing.Size(69, 17);
			lbl_Description.Name = "lbl_Description";
			lbl_Description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Description.Size = new System.Drawing.Size(69, 17);
			lbl_Description.TabIndex = 175;
			lbl_Description.Text = "Description";
			lbl_Description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_Message
			// 
			lbl_Message.AllowDrop = true;
			lbl_Message.BackColor = System.Drawing.Color.Transparent;
			lbl_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Message.ForeColor = System.Drawing.Color.Maroon;
			lbl_Message.Location = new System.Drawing.Point(24, 136);
			lbl_Message.MinimumSize = new System.Drawing.Size(425, 49);
			lbl_Message.Name = "lbl_Message";
			lbl_Message.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Message.Size = new System.Drawing.Size(425, 49);
			lbl_Message.TabIndex = 176;
			lbl_Message.Text = "No Aircraft Selected.";
			// 
			// _Label6_11
			// 
			_Label6_11.AllowDrop = true;
			_Label6_11.AutoSize = true;
			_Label6_11.BackColor = System.Drawing.Color.Transparent;
			_Label6_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_11.ForeColor = System.Drawing.Color.Blue;
			_Label6_11.Location = new System.Drawing.Point(22, 28);
			_Label6_11.MinimumSize = new System.Drawing.Size(211, 13);
			_Label6_11.Name = "_Label6_11";
			_Label6_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_11.Size = new System.Drawing.Size(211, 13);
			_Label6_11.TabIndex = 227;
			_Label6_11.Text = "-";
			// 
			// grd_Aircraft
			// 
			grd_Aircraft.AllowDrop = true;
			grd_Aircraft.AllowUserToAddRows = false;
			grd_Aircraft.AllowUserToDeleteRows = false;
			grd_Aircraft.AllowUserToResizeColumns = false;
			grd_Aircraft.AllowUserToResizeColumns = grd_Aircraft.ColumnHeadersVisible;
			grd_Aircraft.AllowUserToResizeRows = false;
			grd_Aircraft.AllowUserToResizeRows = false;
			grd_Aircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Aircraft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Aircraft.ColumnsCount = 2;
			grd_Aircraft.FixedColumns = 1;
			grd_Aircraft.FixedRows = 1;
			grd_Aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grd_Aircraft.Location = new System.Drawing.Point(17, 84);
			grd_Aircraft.Name = "grd_Aircraft";
			grd_Aircraft.ReadOnly = true;
			grd_Aircraft.RowsCount = 2;
			grd_Aircraft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Aircraft.ShowCellToolTips = false;
			grd_Aircraft.Size = new System.Drawing.Size(543, 382);
			grd_Aircraft.StandardTab = true;
			grd_Aircraft.TabIndex = 170;
			grd_Aircraft.DoubleClick += new System.EventHandler(grd_Aircraft_DoubleClick);
			// 
			// txt_TotalAircraft
			// 
			txt_TotalAircraft.AcceptsReturn = true;
			txt_TotalAircraft.AllowDrop = true;
			txt_TotalAircraft.BackColor = System.Drawing.SystemColors.Window;
			txt_TotalAircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_TotalAircraft.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_TotalAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_TotalAircraft.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_TotalAircraft.Location = new System.Drawing.Point(87, 46);
			txt_TotalAircraft.MaxLength = 0;
			txt_TotalAircraft.Name = "txt_TotalAircraft";
			txt_TotalAircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_TotalAircraft.Size = new System.Drawing.Size(73, 22);
			txt_TotalAircraft.TabIndex = 142;
			txt_TotalAircraft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _Text1_1
			// 
			_Text1_1.AcceptsReturn = true;
			_Text1_1.AllowDrop = true;
			_Text1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			_Text1_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_1.Location = new System.Drawing.Point(422, 43);
			_Text1_1.MaxLength = 0;
			_Text1_1.Name = "_Text1_1";
			_Text1_1.ReadOnly = true;
			_Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_1.Size = new System.Drawing.Size(137, 19);
			_Text1_1.TabIndex = 172;
			_Text1_1.Text = "Purple = On Exclusive";
			_Text1_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txt_amod_description
			// 
			txt_amod_description.AcceptsReturn = true;
			txt_amod_description.AllowDrop = true;
			txt_amod_description.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_description.Location = new System.Drawing.Point(568, 373);
			txt_amod_description.MaxLength = 1500;
			txt_amod_description.Multiline = true;
			txt_amod_description.Name = "txt_amod_description";
			txt_amod_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txt_amod_description.Size = new System.Drawing.Size(393, 94);
			txt_amod_description.TabIndex = 174;
			// 
			// cmdStop
			// 
			cmdStop.AllowDrop = true;
			cmdStop.BackColor = System.Drawing.SystemColors.Control;
			cmdStop.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdStop.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdStop.Location = new System.Drawing.Point(16, 472);
			cmdStop.Name = "cmdStop";
			cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdStop.Size = new System.Drawing.Size(75, 20);
			cmdStop.TabIndex = 177;
			cmdStop.Text = "Stop";
			cmdStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdStop.UseVisualStyleBackColor = false;
			cmdStop.Click += new System.EventHandler(cmdStop_Click);
			// 
			// _Text1_0
			// 
			_Text1_0.AcceptsReturn = true;
			_Text1_0.AllowDrop = true;
			_Text1_0.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			_Text1_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_0.Location = new System.Drawing.Point(422, 22);
			_Text1_0.MaxLength = 0;
			_Text1_0.Name = "_Text1_0";
			_Text1_0.ReadOnly = true;
			_Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_0.Size = new System.Drawing.Size(137, 19);
			_Text1_0.TabIndex = 178;
			_Text1_0.Text = "Green = Available";
			_Text1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _Text1_2
			// 
			_Text1_2.AcceptsReturn = true;
			_Text1_2.AllowDrop = true;
			_Text1_2.BackColor = System.Drawing.Color.FromArgb(255, 173, 91);
			_Text1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_2.Location = new System.Drawing.Point(422, 64);
			_Text1_2.MaxLength = 0;
			_Text1_2.Name = "_Text1_2";
			_Text1_2.ReadOnly = true;
			_Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_2.Size = new System.Drawing.Size(137, 19);
			_Text1_2.TabIndex = 179;
			_Text1_2.Text = "Orange = Lease";
			_Text1_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// cmdTemp
			// 
			cmdTemp.AllowDrop = true;
			cmdTemp.BackColor = System.Drawing.SystemColors.Control;
			cmdTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdTemp.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdTemp.Location = new System.Drawing.Point(168, 46);
			cmdTemp.Name = "cmdTemp";
			cmdTemp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdTemp.Size = new System.Drawing.Size(84, 22);
			cmdTemp.TabIndex = 189;
			cmdTemp.Text = "Temp";
			cmdTemp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdTemp.UseVisualStyleBackColor = false;
			cmdTemp.Visible = false;
			cmdTemp.Click += new System.EventHandler(cmdTemp_Click);
			// 
			// _tab_Aircraft_Model_TabPage1
			// 
			_tab_Aircraft_Model_TabPage1.Controls.Add(_cmd_button_array_2);
			_tab_Aircraft_Model_TabPage1.Controls.Add(pnl_ModelFeatures);
			_tab_Aircraft_Model_TabPage1.Controls.Add(pnl_MasterKeyFeatures);
			_tab_Aircraft_Model_TabPage1.Controls.Add(pnl_FeatureDisplay);
			_tab_Aircraft_Model_TabPage1.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage1.Text = "Features";
			// 
			// _cmd_button_array_2
			// 
			_cmd_button_array_2.AllowDrop = true;
			_cmd_button_array_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_array_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_array_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_array_2.Location = new System.Drawing.Point(484, 30);
			_cmd_button_array_2.Name = "_cmd_button_array_2";
			_cmd_button_array_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_array_2.Size = new System.Drawing.Size(127, 23);
			_cmd_button_array_2.TabIndex = 426;
			_cmd_button_array_2.Text = "Get Master Feature List";
			_cmd_button_array_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_array_2.UseVisualStyleBackColor = false;
			_cmd_button_array_2.Click += new System.EventHandler(cmd_button_array_Click);
			// 
			// pnl_ModelFeatures
			// 
			pnl_ModelFeatures.AllowDrop = true;
			pnl_ModelFeatures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_ModelFeatures.Controls.Add(_cmd_button_array_5);
			pnl_ModelFeatures.Controls.Add(_cmd_button_array_1);
			pnl_ModelFeatures.Controls.Add(chkFeatCount);
			pnl_ModelFeatures.Controls.Add(_cmd_button_array_0);
			pnl_ModelFeatures.Controls.Add(grd_Keyfeature);
			pnl_ModelFeatures.Controls.Add(lblFeatureUnknown);
			pnl_ModelFeatures.Controls.Add(lblFeatureNo);
			pnl_ModelFeatures.Controls.Add(lblFeatureYes);
			pnl_ModelFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_ModelFeatures.Location = new System.Drawing.Point(5, 24);
			pnl_ModelFeatures.Name = "pnl_ModelFeatures";
			pnl_ModelFeatures.Size = new System.Drawing.Size(473, 286);
			pnl_ModelFeatures.TabIndex = 55;
			// 
			// _cmd_button_array_5
			// 
			_cmd_button_array_5.AllowDrop = true;
			_cmd_button_array_5.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_array_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_array_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_array_5.Location = new System.Drawing.Point(342, 258);
			_cmd_button_array_5.Name = "_cmd_button_array_5";
			_cmd_button_array_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_array_5.Size = new System.Drawing.Size(121, 25);
			_cmd_button_array_5.TabIndex = 429;
			_cmd_button_array_5.Text = "Save Feature Changes";
			_cmd_button_array_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_array_5.UseVisualStyleBackColor = false;
			_cmd_button_array_5.Click += new System.EventHandler(cmd_button_array_Click);
			// 
			// _cmd_button_array_1
			// 
			_cmd_button_array_1.AllowDrop = true;
			_cmd_button_array_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_array_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_array_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_array_1.Location = new System.Drawing.Point(16, 8);
			_cmd_button_array_1.Name = "_cmd_button_array_1";
			_cmd_button_array_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_array_1.Size = new System.Drawing.Size(127, 23);
			_cmd_button_array_1.TabIndex = 425;
			_cmd_button_array_1.Text = "Move Feature Up";
			_cmd_button_array_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_array_1.UseVisualStyleBackColor = false;
			_cmd_button_array_1.Click += new System.EventHandler(cmd_button_array_Click);
			// 
			// chkFeatCount
			// 
			chkFeatCount.AllowDrop = true;
			chkFeatCount.Appearance = System.Windows.Forms.Appearance.Normal;
			chkFeatCount.BackColor = System.Drawing.SystemColors.Control;
			chkFeatCount.CausesValidation = true;
			chkFeatCount.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkFeatCount.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkFeatCount.Enabled = true;
			chkFeatCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkFeatCount.ForeColor = System.Drawing.SystemColors.WindowText;
			chkFeatCount.Location = new System.Drawing.Point(10, 260);
			chkFeatCount.Name = "chkFeatCount";
			chkFeatCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkFeatCount.Size = new System.Drawing.Size(159, 15);
			chkFeatCount.TabIndex = 218;
			chkFeatCount.TabStop = true;
			chkFeatCount.Text = "Count Values On Aircraft";
			chkFeatCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkFeatCount.Visible = true;
			chkFeatCount.CheckStateChanged += new System.EventHandler(chkFeatCount_CheckStateChanged);
			// 
			// _cmd_button_array_0
			// 
			_cmd_button_array_0.AllowDrop = true;
			_cmd_button_array_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_array_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_array_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_array_0.Location = new System.Drawing.Point(335, 8);
			_cmd_button_array_0.Name = "_cmd_button_array_0";
			_cmd_button_array_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_array_0.Size = new System.Drawing.Size(127, 23);
			_cmd_button_array_0.TabIndex = 186;
			_cmd_button_array_0.Text = "Move Feature Down";
			_cmd_button_array_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_array_0.UseVisualStyleBackColor = false;
			_cmd_button_array_0.Click += new System.EventHandler(cmd_button_array_Click);
			// 
			// grd_Keyfeature
			// 
			grd_Keyfeature.AllowDrop = true;
			grd_Keyfeature.AllowUserToAddRows = false;
			grd_Keyfeature.AllowUserToDeleteRows = false;
			grd_Keyfeature.AllowUserToResizeColumns = false;
			grd_Keyfeature.AllowUserToResizeColumns = grd_Keyfeature.ColumnHeadersVisible;
			grd_Keyfeature.AllowUserToResizeRows = false;
			grd_Keyfeature.AllowUserToResizeRows = false;
			grd_Keyfeature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Keyfeature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Keyfeature.ColumnsCount = 2;
			grd_Keyfeature.FixedColumns = 1;
			grd_Keyfeature.FixedRows = 1;
			grd_Keyfeature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grd_Keyfeature.Location = new System.Drawing.Point(11, 37);
			grd_Keyfeature.Name = "grd_Keyfeature";
			grd_Keyfeature.ReadOnly = true;
			grd_Keyfeature.RowsCount = 2;
			grd_Keyfeature.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Keyfeature.ShowCellToolTips = false;
			grd_Keyfeature.Size = new System.Drawing.Size(450, 216);
			grd_Keyfeature.StandardTab = true;
			grd_Keyfeature.TabIndex = 185;
			grd_Keyfeature.Click += new System.EventHandler(grd_Keyfeature_Click);
			// 
			// lblFeatureUnknown
			// 
			lblFeatureUnknown.AllowDrop = true;
			lblFeatureUnknown.AutoSize = true;
			lblFeatureUnknown.BackColor = System.Drawing.Color.Transparent;
			lblFeatureUnknown.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFeatureUnknown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFeatureUnknown.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFeatureUnknown.Location = new System.Drawing.Point(272, 260);
			lblFeatureUnknown.MinimumSize = new System.Drawing.Size(46, 13);
			lblFeatureUnknown.Name = "lblFeatureUnknown";
			lblFeatureUnknown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFeatureUnknown.Size = new System.Drawing.Size(46, 13);
			lblFeatureUnknown.TabIndex = 212;
			lblFeatureUnknown.Text = "Unknown";
			lblFeatureUnknown.Visible = false;
			// 
			// lblFeatureNo
			// 
			lblFeatureNo.AllowDrop = true;
			lblFeatureNo.AutoSize = true;
			lblFeatureNo.BackColor = System.Drawing.Color.Transparent;
			lblFeatureNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFeatureNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFeatureNo.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFeatureNo.Location = new System.Drawing.Point(229, 260);
			lblFeatureNo.MinimumSize = new System.Drawing.Size(14, 13);
			lblFeatureNo.Name = "lblFeatureNo";
			lblFeatureNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFeatureNo.Size = new System.Drawing.Size(14, 13);
			lblFeatureNo.TabIndex = 211;
			lblFeatureNo.Text = "No";
			lblFeatureNo.Visible = false;
			// 
			// lblFeatureYes
			// 
			lblFeatureYes.AllowDrop = true;
			lblFeatureYes.AutoSize = true;
			lblFeatureYes.BackColor = System.Drawing.Color.Transparent;
			lblFeatureYes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFeatureYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFeatureYes.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFeatureYes.Location = new System.Drawing.Point(177, 259);
			lblFeatureYes.MinimumSize = new System.Drawing.Size(18, 13);
			lblFeatureYes.Name = "lblFeatureYes";
			lblFeatureYes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFeatureYes.Size = new System.Drawing.Size(18, 13);
			lblFeatureYes.TabIndex = 210;
			lblFeatureYes.Text = "Yes";
			lblFeatureYes.Visible = false;
			// 
			// pnl_MasterKeyFeatures
			// 
			pnl_MasterKeyFeatures.AllowDrop = true;
			pnl_MasterKeyFeatures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_MasterKeyFeatures.Controls.Add(_cmd_button_array_4);
			pnl_MasterKeyFeatures.Controls.Add(_cmd_button_array_3);
			pnl_MasterKeyFeatures.Controls.Add(lst_MasterKeyFeature);
			pnl_MasterKeyFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_MasterKeyFeatures.Location = new System.Drawing.Point(480, 57);
			pnl_MasterKeyFeatures.Name = "pnl_MasterKeyFeatures";
			pnl_MasterKeyFeatures.Size = new System.Drawing.Size(476, 438);
			pnl_MasterKeyFeatures.TabIndex = 52;
			pnl_MasterKeyFeatures.Click += new System.EventHandler(pnl_MasterKeyFeatures_Click);
			// 
			// _cmd_button_array_4
			// 
			_cmd_button_array_4.AllowDrop = true;
			_cmd_button_array_4.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_array_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_array_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_array_4.Location = new System.Drawing.Point(10, 56);
			_cmd_button_array_4.Name = "_cmd_button_array_4";
			_cmd_button_array_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_array_4.Size = new System.Drawing.Size(105, 25);
			_cmd_button_array_4.TabIndex = 428;
			_cmd_button_array_4.Text = "&Cancel";
			_cmd_button_array_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_array_4.UseVisualStyleBackColor = false;
			_cmd_button_array_4.Click += new System.EventHandler(cmd_button_array_Click);
			// 
			// _cmd_button_array_3
			// 
			_cmd_button_array_3.AllowDrop = true;
			_cmd_button_array_3.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_array_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_array_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_array_3.Location = new System.Drawing.Point(10, 24);
			_cmd_button_array_3.Name = "_cmd_button_array_3";
			_cmd_button_array_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_array_3.Size = new System.Drawing.Size(105, 25);
			_cmd_button_array_3.TabIndex = 427;
			_cmd_button_array_3.Text = "<< Add Feature";
			_cmd_button_array_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_array_3.UseVisualStyleBackColor = false;
			_cmd_button_array_3.Click += new System.EventHandler(cmd_button_array_Click);
			// 
			// lst_MasterKeyFeature
			// 
			lst_MasterKeyFeature.AllowDrop = true;
			lst_MasterKeyFeature.BackColor = System.Drawing.SystemColors.Window;
			lst_MasterKeyFeature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_MasterKeyFeature.CausesValidation = true;
			lst_MasterKeyFeature.Enabled = true;
			lst_MasterKeyFeature.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_MasterKeyFeature.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_MasterKeyFeature.IntegralHeight = true;
			lst_MasterKeyFeature.Location = new System.Drawing.Point(120, 20);
			lst_MasterKeyFeature.MultiColumn = false;
			lst_MasterKeyFeature.Name = "lst_MasterKeyFeature";
			lst_MasterKeyFeature.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_MasterKeyFeature.Size = new System.Drawing.Size(345, 410);
			lst_MasterKeyFeature.Sorted = false;
			lst_MasterKeyFeature.TabIndex = 53;
			lst_MasterKeyFeature.TabStop = true;
			lst_MasterKeyFeature.Visible = true;
			lst_MasterKeyFeature.SelectedIndexChanged += new System.EventHandler(lst_MasterKeyFeature_SelectedIndexChanged);
			// 
			// pnl_FeatureDisplay
			// 
			pnl_FeatureDisplay.AllowDrop = true;
			pnl_FeatureDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_FeatureDisplay.Controls.Add(_cmd_button_array_8);
			pnl_FeatureDisplay.Controls.Add(_cmd_button_array_7);
			pnl_FeatureDisplay.Controls.Add(_cmd_button_array_6);
			pnl_FeatureDisplay.Controls.Add(txt_InactiveDate);
			pnl_FeatureDisplay.Controls.Add(chk_Inactive_Feature_Code);
			pnl_FeatureDisplay.Controls.Add(txtFeatEndSerNo);
			pnl_FeatureDisplay.Controls.Add(txtFeatStartSerNo);
			pnl_FeatureDisplay.Controls.Add(chkStandard);
			pnl_FeatureDisplay.Controls.Add(_Label6_31);
			pnl_FeatureDisplay.Controls.Add(_Label6_30);
			pnl_FeatureDisplay.Controls.Add(lbl_FeatureMessage);
			pnl_FeatureDisplay.Controls.Add(lbl_FeatureDescription);
			pnl_FeatureDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_FeatureDisplay.Location = new System.Drawing.Point(5, 311);
			pnl_FeatureDisplay.Name = "pnl_FeatureDisplay";
			pnl_FeatureDisplay.Size = new System.Drawing.Size(473, 184);
			pnl_FeatureDisplay.TabIndex = 54;
			pnl_FeatureDisplay.Click += new System.EventHandler(pnl_FeatureDisplay_Click);
			// 
			// _cmd_button_array_8
			// 
			_cmd_button_array_8.AllowDrop = true;
			_cmd_button_array_8.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_array_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_array_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_array_8.Location = new System.Drawing.Point(8, 60);
			_cmd_button_array_8.Name = "_cmd_button_array_8";
			_cmd_button_array_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_array_8.Size = new System.Drawing.Size(51, 17);
			_cmd_button_array_8.TabIndex = 433;
			_cmd_button_array_8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_array_8.UseVisualStyleBackColor = false;
			_cmd_button_array_8.Visible = false;
			_cmd_button_array_8.Click += new System.EventHandler(cmd_button_array_Click);
			// 
			// _cmd_button_array_7
			// 
			_cmd_button_array_7.AllowDrop = true;
			_cmd_button_array_7.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_array_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_array_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_array_7.Location = new System.Drawing.Point(340, 52);
			_cmd_button_array_7.Name = "_cmd_button_array_7";
			_cmd_button_array_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_array_7.Size = new System.Drawing.Size(121, 25);
			_cmd_button_array_7.TabIndex = 431;
			_cmd_button_array_7.Text = "Remove Feature";
			_cmd_button_array_7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_array_7.UseVisualStyleBackColor = false;
			_cmd_button_array_7.Click += new System.EventHandler(cmd_button_array_Click);
			// 
			// _cmd_button_array_6
			// 
			_cmd_button_array_6.AllowDrop = true;
			_cmd_button_array_6.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_array_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_array_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_array_6.Location = new System.Drawing.Point(340, 20);
			_cmd_button_array_6.Name = "_cmd_button_array_6";
			_cmd_button_array_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_array_6.Size = new System.Drawing.Size(121, 25);
			_cmd_button_array_6.TabIndex = 430;
			_cmd_button_array_6.Text = "Update Feature";
			_cmd_button_array_6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_array_6.UseVisualStyleBackColor = false;
			_cmd_button_array_6.Click += new System.EventHandler(cmd_button_array_Click);
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
			txt_InactiveDate.Location = new System.Drawing.Point(87, 154);
			txt_InactiveDate.MaxLength = 0;
			txt_InactiveDate.Name = "txt_InactiveDate";
			txt_InactiveDate.ReadOnly = true;
			txt_InactiveDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_InactiveDate.Size = new System.Drawing.Size(117, 21);
			txt_InactiveDate.TabIndex = 220;
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
			chk_Inactive_Feature_Code.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_Inactive_Feature_Code.Location = new System.Drawing.Point(16, 156);
			chk_Inactive_Feature_Code.Name = "chk_Inactive_Feature_Code";
			chk_Inactive_Feature_Code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Inactive_Feature_Code.Size = new System.Drawing.Size(69, 15);
			chk_Inactive_Feature_Code.TabIndex = 219;
			chk_Inactive_Feature_Code.TabStop = true;
			chk_Inactive_Feature_Code.Text = "Inactive";
			chk_Inactive_Feature_Code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Inactive_Feature_Code.Visible = true;
			chk_Inactive_Feature_Code.CheckStateChanged += new System.EventHandler(chk_Inactive_Feature_Code_CheckStateChanged);
			// 
			// txtFeatEndSerNo
			// 
			txtFeatEndSerNo.AcceptsReturn = true;
			txtFeatEndSerNo.AllowDrop = true;
			txtFeatEndSerNo.BackColor = System.Drawing.SystemColors.Window;
			txtFeatEndSerNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtFeatEndSerNo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtFeatEndSerNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtFeatEndSerNo.ForeColor = System.Drawing.SystemColors.WindowText;
			txtFeatEndSerNo.Location = new System.Drawing.Point(336, 126);
			txtFeatEndSerNo.MaxLength = 0;
			txtFeatEndSerNo.Name = "txtFeatEndSerNo";
			txtFeatEndSerNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtFeatEndSerNo.Size = new System.Drawing.Size(69, 22);
			txtFeatEndSerNo.TabIndex = 215;
			// 
			// txtFeatStartSerNo
			// 
			txtFeatStartSerNo.AcceptsReturn = true;
			txtFeatStartSerNo.AllowDrop = true;
			txtFeatStartSerNo.BackColor = System.Drawing.SystemColors.Window;
			txtFeatStartSerNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtFeatStartSerNo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtFeatStartSerNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtFeatStartSerNo.ForeColor = System.Drawing.SystemColors.WindowText;
			txtFeatStartSerNo.Location = new System.Drawing.Point(238, 126);
			txtFeatStartSerNo.MaxLength = 0;
			txtFeatStartSerNo.Name = "txtFeatStartSerNo";
			txtFeatStartSerNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtFeatStartSerNo.Size = new System.Drawing.Size(69, 22);
			txtFeatStartSerNo.TabIndex = 214;
			// 
			// chkStandard
			// 
			chkStandard.AllowDrop = true;
			chkStandard.Appearance = System.Windows.Forms.Appearance.Normal;
			chkStandard.BackColor = System.Drawing.SystemColors.Control;
			chkStandard.CausesValidation = true;
			chkStandard.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkStandard.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkStandard.Enabled = true;
			chkStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkStandard.ForeColor = System.Drawing.SystemColors.WindowText;
			chkStandard.Location = new System.Drawing.Point(16, 130);
			chkStandard.Name = "chkStandard";
			chkStandard.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkStandard.Size = new System.Drawing.Size(142, 15);
			chkStandard.TabIndex = 213;
			chkStandard.TabStop = true;
			chkStandard.Text = "Standard Equipment";
			chkStandard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkStandard.Visible = true;
			// 
			// _Label6_31
			// 
			_Label6_31.AllowDrop = true;
			_Label6_31.AutoSize = true;
			_Label6_31.BackColor = System.Drawing.Color.Transparent;
			_Label6_31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_31.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_31.Location = new System.Drawing.Point(317, 130);
			_Label6_31.MinimumSize = new System.Drawing.Size(13, 13);
			_Label6_31.Name = "_Label6_31";
			_Label6_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_31.Size = new System.Drawing.Size(13, 13);
			_Label6_31.TabIndex = 217;
			_Label6_31.Text = "To";
			// 
			// _Label6_30
			// 
			_Label6_30.AllowDrop = true;
			_Label6_30.AutoSize = true;
			_Label6_30.BackColor = System.Drawing.Color.Transparent;
			_Label6_30.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_30.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_30.Location = new System.Drawing.Point(169, 130);
			_Label6_30.MinimumSize = new System.Drawing.Size(59, 13);
			_Label6_30.Name = "_Label6_30";
			_Label6_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_30.Size = new System.Drawing.Size(59, 13);
			_Label6_30.TabIndex = 216;
			_Label6_30.Text = "Ser No From";
			// 
			// lbl_FeatureMessage
			// 
			lbl_FeatureMessage.AllowDrop = true;
			lbl_FeatureMessage.BackColor = System.Drawing.Color.Transparent;
			lbl_FeatureMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_FeatureMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_FeatureMessage.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_FeatureMessage.Location = new System.Drawing.Point(72, 1);
			lbl_FeatureMessage.MinimumSize = new System.Drawing.Size(393, 25);
			lbl_FeatureMessage.Name = "lbl_FeatureMessage";
			lbl_FeatureMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_FeatureMessage.Size = new System.Drawing.Size(393, 25);
			lbl_FeatureMessage.TabIndex = 140;
			lbl_FeatureMessage.Text = "Feature Message Label";
			// 
			// lbl_FeatureDescription
			// 
			lbl_FeatureDescription.AllowDrop = true;
			lbl_FeatureDescription.BackColor = System.Drawing.Color.Transparent;
			lbl_FeatureDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_FeatureDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_FeatureDescription.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_FeatureDescription.Location = new System.Drawing.Point(4, 18);
			lbl_FeatureDescription.MinimumSize = new System.Drawing.Size(321, 105);
			lbl_FeatureDescription.Name = "lbl_FeatureDescription";
			lbl_FeatureDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_FeatureDescription.Size = new System.Drawing.Size(321, 105);
			lbl_FeatureDescription.TabIndex = 141;
			lbl_FeatureDescription.Text = "Feature Description Label";
			// 
			// _tab_Aircraft_Model_TabPage2
			// 
			_tab_Aircraft_Model_TabPage2.Controls.Add(grd_ModelTrend);
			_tab_Aircraft_Model_TabPage2.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage2.Text = "Market Summaries";
			// 
			// grd_ModelTrend
			// 
			grd_ModelTrend.AllowDrop = true;
			grd_ModelTrend.AllowUserToAddRows = false;
			grd_ModelTrend.AllowUserToDeleteRows = false;
			grd_ModelTrend.AllowUserToResizeColumns = false;
			grd_ModelTrend.AllowUserToResizeRows = false;
			grd_ModelTrend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_ModelTrend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_ModelTrend.ColumnsCount = 2;
			grd_ModelTrend.FixedColumns = 0;
			grd_ModelTrend.FixedRows = 0;
			grd_ModelTrend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grd_ModelTrend.Location = new System.Drawing.Point(10, 33);
			grd_ModelTrend.Name = "grd_ModelTrend";
			grd_ModelTrend.ReadOnly = true;
			grd_ModelTrend.RowsCount = 2;
			grd_ModelTrend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_ModelTrend.ShowCellToolTips = false;
			grd_ModelTrend.Size = new System.Drawing.Size(945, 447);
			grd_ModelTrend.StandardTab = true;
			grd_ModelTrend.TabIndex = 171;
			// 
			// _tab_Aircraft_Model_TabPage3
			// 
			_tab_Aircraft_Model_TabPage3.Controls.Add(lst_aircraft_wanted);
			_tab_Aircraft_Model_TabPage3.Controls.Add(_Label13_8);
			_tab_Aircraft_Model_TabPage3.Controls.Add(_Label13_7);
			_tab_Aircraft_Model_TabPage3.Controls.Add(_Label13_6);
			_tab_Aircraft_Model_TabPage3.Controls.Add(_Label13_5);
			_tab_Aircraft_Model_TabPage3.Controls.Add(_Label13_4);
			_tab_Aircraft_Model_TabPage3.Controls.Add(_Lable13_2);
			_tab_Aircraft_Model_TabPage3.Controls.Add(_Label13_1);
			_tab_Aircraft_Model_TabPage3.Controls.Add(_Label13_0);
			_tab_Aircraft_Model_TabPage3.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage3.Text = "Wanted";
			// 
			// lst_aircraft_wanted
			// 
			lst_aircraft_wanted.AllowDrop = true;
			lst_aircraft_wanted.BackColor = System.Drawing.SystemColors.Window;
			lst_aircraft_wanted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_aircraft_wanted.CausesValidation = true;
			lst_aircraft_wanted.Enabled = true;
			lst_aircraft_wanted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_aircraft_wanted.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_aircraft_wanted.IntegralHeight = true;
			lst_aircraft_wanted.Location = new System.Drawing.Point(40, 64);
			lst_aircraft_wanted.MultiColumn = false;
			lst_aircraft_wanted.Name = "lst_aircraft_wanted";
			lst_aircraft_wanted.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_aircraft_wanted.Size = new System.Drawing.Size(921, 395);
			lst_aircraft_wanted.Sorted = false;
			lst_aircraft_wanted.TabIndex = 160;
			lst_aircraft_wanted.TabStop = true;
			lst_aircraft_wanted.Visible = true;
			// 
			// _Label13_8
			// 
			_Label13_8.AllowDrop = true;
			_Label13_8.BackColor = System.Drawing.SystemColors.Control;
			_Label13_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label13_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label13_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label13_8.Location = new System.Drawing.Point(704, 40);
			_Label13_8.MinimumSize = new System.Drawing.Size(65, 17);
			_Label13_8.Name = "_Label13_8";
			_Label13_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label13_8.Size = new System.Drawing.Size(65, 17);
			_Label13_8.TabIndex = 169;
			_Label13_8.Text = "Max Price";
			// 
			// _Label13_7
			// 
			_Label13_7.AllowDrop = true;
			_Label13_7.BackColor = System.Drawing.SystemColors.Control;
			_Label13_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label13_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label13_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label13_7.Location = new System.Drawing.Point(896, 40);
			_Label13_7.MinimumSize = new System.Drawing.Size(65, 17);
			_Label13_7.Name = "_Label13_7";
			_Label13_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label13_7.Size = new System.Drawing.Size(65, 17);
			_Label13_7.TabIndex = 168;
			_Label13_7.Text = "Damage ?";
			_Label13_7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _Label13_6
			// 
			_Label13_6.AllowDrop = true;
			_Label13_6.BackColor = System.Drawing.SystemColors.Control;
			_Label13_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label13_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label13_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label13_6.Location = new System.Drawing.Point(823, 40);
			_Label13_6.MinimumSize = new System.Drawing.Size(65, 17);
			_Label13_6.Name = "_Label13_6";
			_Label13_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label13_6.Size = new System.Drawing.Size(65, 17);
			_Label13_6.TabIndex = 167;
			_Label13_6.Text = "Max AFTT";
			_Label13_6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _Label13_5
			// 
			_Label13_5.AllowDrop = true;
			_Label13_5.BackColor = System.Drawing.SystemColors.Control;
			_Label13_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label13_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label13_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label13_5.Location = new System.Drawing.Point(592, 40);
			_Label13_5.MinimumSize = new System.Drawing.Size(65, 17);
			_Label13_5.Name = "_Label13_5";
			_Label13_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label13_5.Size = new System.Drawing.Size(65, 17);
			_Label13_5.TabIndex = 166;
			_Label13_5.Text = "End Year";
			// 
			// _Label13_4
			// 
			_Label13_4.AllowDrop = true;
			_Label13_4.BackColor = System.Drawing.SystemColors.Control;
			_Label13_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label13_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label13_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label13_4.Location = new System.Drawing.Point(488, 40);
			_Label13_4.MinimumSize = new System.Drawing.Size(65, 17);
			_Label13_4.Name = "_Label13_4";
			_Label13_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label13_4.Size = new System.Drawing.Size(65, 17);
			_Label13_4.TabIndex = 164;
			_Label13_4.Text = "Start Year";
			// 
			// _Lable13_2
			// 
			_Lable13_2.AllowDrop = true;
			_Lable13_2.BackColor = System.Drawing.SystemColors.Control;
			_Lable13_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Lable13_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Lable13_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Lable13_2.Location = new System.Drawing.Point(360, 40);
			_Lable13_2.MinimumSize = new System.Drawing.Size(65, 17);
			_Lable13_2.Name = "_Lable13_2";
			_Lable13_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Lable13_2.Size = new System.Drawing.Size(65, 17);
			_Lable13_2.TabIndex = 163;
			_Lable13_2.Text = "Location";
			// 
			// _Label13_1
			// 
			_Label13_1.AllowDrop = true;
			_Label13_1.BackColor = System.Drawing.SystemColors.Control;
			_Label13_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label13_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label13_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label13_1.Location = new System.Drawing.Point(136, 40);
			_Label13_1.MinimumSize = new System.Drawing.Size(65, 17);
			_Label13_1.Name = "_Label13_1";
			_Label13_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label13_1.Size = new System.Drawing.Size(65, 17);
			_Label13_1.TabIndex = 162;
			_Label13_1.Text = "Company";
			// 
			// _Label13_0
			// 
			_Label13_0.AllowDrop = true;
			_Label13_0.BackColor = System.Drawing.SystemColors.Control;
			_Label13_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label13_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label13_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label13_0.Location = new System.Drawing.Point(48, 40);
			_Label13_0.MinimumSize = new System.Drawing.Size(65, 17);
			_Label13_0.Name = "_Label13_0";
			_Label13_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label13_0.Size = new System.Drawing.Size(65, 17);
			_Label13_0.TabIndex = 161;
			_Label13_0.Text = "List Date";
			// 
			// _tab_Aircraft_Model_TabPage4
			// 
			_tab_Aircraft_Model_TabPage4.Controls.Add(pnl_AnnualBudget);
			_tab_Aircraft_Model_TabPage4.Controls.Add(pnl_FixedCosts);
			_tab_Aircraft_Model_TabPage4.Controls.Add(pnl_DirectCost);
			_tab_Aircraft_Model_TabPage4.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage4.Text = "Op Costs";
			// 
			// pnl_AnnualBudget
			// 
			pnl_AnnualBudget.AllowDrop = true;
			pnl_AnnualBudget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_AnnualBudget.Controls.Add(txt_amod_annual_hours);
			pnl_AnnualBudget.Controls.Add(txt_amod_annual_miles);
			pnl_AnnualBudget.Controls.Add(txt_amod_number_of_seats);
			pnl_AnnualBudget.Controls.Add(txt_amod_tot_direct_cost);
			pnl_AnnualBudget.Controls.Add(txt_amod_tot_fixed_cost2);
			pnl_AnnualBudget.Controls.Add(txt_amod_tot_df_seat_cost);
			pnl_AnnualBudget.Controls.Add(txt_amod_tot_df_statmile_cost);
			pnl_AnnualBudget.Controls.Add(txt_amod_tot_df_hour_cost);
			pnl_AnnualBudget.Controls.Add(txt_amod_tot_df_annual_cost);
			pnl_AnnualBudget.Controls.Add(txt_amod_tot_nd_seat_cost);
			pnl_AnnualBudget.Controls.Add(txt_amod_tot_nd_statmile_cost);
			pnl_AnnualBudget.Controls.Add(txt_amod_tot_nd_hour_cost);
			pnl_AnnualBudget.Controls.Add(txt_amod_tot_nd_annual_cost);
			pnl_AnnualBudget.Controls.Add(_Label18_6);
			pnl_AnnualBudget.Controls.Add(_Label17_4);
			pnl_AnnualBudget.Controls.Add(_Label16_7);
			pnl_AnnualBudget.Controls.Add(_Label16_8);
			pnl_AnnualBudget.Controls.Add(_Label16_9);
			pnl_AnnualBudget.Controls.Add(_Label18_7);
			pnl_AnnualBudget.Controls.Add(_Label17_5);
			pnl_AnnualBudget.Controls.Add(_Label16_10);
			pnl_AnnualBudget.Controls.Add(_Label16_11);
			pnl_AnnualBudget.Controls.Add(_Label18_8);
			pnl_AnnualBudget.Controls.Add(_Label17_6);
			pnl_AnnualBudget.Controls.Add(_Label16_12);
			pnl_AnnualBudget.Controls.Add(_Label16_13);
			pnl_AnnualBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_AnnualBudget.Location = new System.Drawing.Point(496, 71);
			pnl_AnnualBudget.Name = "pnl_AnnualBudget";
			pnl_AnnualBudget.Size = new System.Drawing.Size(345, 377);
			pnl_AnnualBudget.TabIndex = 116;
			// 
			// txt_amod_annual_hours
			// 
			txt_amod_annual_hours.AcceptsReturn = true;
			txt_amod_annual_hours.AllowDrop = true;
			txt_amod_annual_hours.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_annual_hours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_annual_hours.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_annual_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_annual_hours.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_annual_hours.Location = new System.Drawing.Point(248, 87);
			txt_amod_annual_hours.MaxLength = 0;
			txt_amod_annual_hours.Name = "txt_amod_annual_hours";
			txt_amod_annual_hours.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_annual_hours.Size = new System.Drawing.Size(73, 19);
			txt_amod_annual_hours.TabIndex = 91;
			txt_amod_annual_hours.Text = "0";
			txt_amod_annual_hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_annual_hours.Leave += new System.EventHandler(txt_amod_annual_hours_Leave);
			// 
			// txt_amod_annual_miles
			// 
			txt_amod_annual_miles.AcceptsReturn = true;
			txt_amod_annual_miles.AllowDrop = true;
			txt_amod_annual_miles.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_annual_miles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_annual_miles.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_annual_miles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_annual_miles.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_annual_miles.Location = new System.Drawing.Point(248, 64);
			txt_amod_annual_miles.MaxLength = 0;
			txt_amod_annual_miles.Name = "txt_amod_annual_miles";
			txt_amod_annual_miles.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_annual_miles.Size = new System.Drawing.Size(73, 19);
			txt_amod_annual_miles.TabIndex = 90;
			txt_amod_annual_miles.Text = "0";
			txt_amod_annual_miles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_annual_miles.Leave += new System.EventHandler(txt_amod_annual_miles_Leave);
			// 
			// txt_amod_number_of_seats
			// 
			txt_amod_number_of_seats.AcceptsReturn = true;
			txt_amod_number_of_seats.AllowDrop = true;
			txt_amod_number_of_seats.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_number_of_seats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_number_of_seats.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_number_of_seats.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_number_of_seats.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_number_of_seats.Location = new System.Drawing.Point(248, 40);
			txt_amod_number_of_seats.MaxLength = 0;
			txt_amod_number_of_seats.Name = "txt_amod_number_of_seats";
			txt_amod_number_of_seats.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_number_of_seats.Size = new System.Drawing.Size(73, 19);
			txt_amod_number_of_seats.TabIndex = 89;
			txt_amod_number_of_seats.Text = "0";
			txt_amod_number_of_seats.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_number_of_seats.Leave += new System.EventHandler(txt_amod_number_of_seats_Leave);
			// 
			// txt_amod_tot_direct_cost
			// 
			txt_amod_tot_direct_cost.AcceptsReturn = true;
			txt_amod_tot_direct_cost.AllowDrop = true;
			txt_amod_tot_direct_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_direct_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_direct_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_direct_cost.Enabled = false;
			txt_amod_tot_direct_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_direct_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_direct_cost.Location = new System.Drawing.Point(248, 128);
			txt_amod_tot_direct_cost.MaxLength = 0;
			txt_amod_tot_direct_cost.Name = "txt_amod_tot_direct_cost";
			txt_amod_tot_direct_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_direct_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_direct_cost.TabIndex = 43;
			txt_amod_tot_direct_cost.Text = "0";
			txt_amod_tot_direct_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_direct_cost.TextChanged += new System.EventHandler(txt_amod_tot_direct_cost_TextChanged);
			// 
			// txt_amod_tot_fixed_cost2
			// 
			txt_amod_tot_fixed_cost2.AcceptsReturn = true;
			txt_amod_tot_fixed_cost2.AllowDrop = true;
			txt_amod_tot_fixed_cost2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_fixed_cost2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_fixed_cost2.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_fixed_cost2.Enabled = false;
			txt_amod_tot_fixed_cost2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_fixed_cost2.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_fixed_cost2.Location = new System.Drawing.Point(248, 152);
			txt_amod_tot_fixed_cost2.MaxLength = 0;
			txt_amod_tot_fixed_cost2.Name = "txt_amod_tot_fixed_cost2";
			txt_amod_tot_fixed_cost2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_fixed_cost2.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_fixed_cost2.TabIndex = 42;
			txt_amod_tot_fixed_cost2.Text = "0";
			txt_amod_tot_fixed_cost2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_fixed_cost2.TextChanged += new System.EventHandler(txt_amod_tot_fixed_cost2_TextChanged);
			// 
			// txt_amod_tot_df_seat_cost
			// 
			txt_amod_tot_df_seat_cost.AcceptsReturn = true;
			txt_amod_tot_df_seat_cost.AllowDrop = true;
			txt_amod_tot_df_seat_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_df_seat_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_df_seat_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_df_seat_cost.Enabled = false;
			txt_amod_tot_df_seat_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_df_seat_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_df_seat_cost.Location = new System.Drawing.Point(248, 248);
			txt_amod_tot_df_seat_cost.MaxLength = 0;
			txt_amod_tot_df_seat_cost.Name = "txt_amod_tot_df_seat_cost";
			txt_amod_tot_df_seat_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_df_seat_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_df_seat_cost.TabIndex = 38;
			txt_amod_tot_df_seat_cost.Text = "0";
			txt_amod_tot_df_seat_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_df_seat_cost.Leave += new System.EventHandler(txt_amod_tot_df_seat_cost_Leave);
			// 
			// txt_amod_tot_df_statmile_cost
			// 
			txt_amod_tot_df_statmile_cost.AcceptsReturn = true;
			txt_amod_tot_df_statmile_cost.AllowDrop = true;
			txt_amod_tot_df_statmile_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_df_statmile_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_df_statmile_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_df_statmile_cost.Enabled = false;
			txt_amod_tot_df_statmile_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_df_statmile_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_df_statmile_cost.Location = new System.Drawing.Point(248, 224);
			txt_amod_tot_df_statmile_cost.MaxLength = 0;
			txt_amod_tot_df_statmile_cost.Name = "txt_amod_tot_df_statmile_cost";
			txt_amod_tot_df_statmile_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_df_statmile_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_df_statmile_cost.TabIndex = 39;
			txt_amod_tot_df_statmile_cost.Text = "0";
			txt_amod_tot_df_statmile_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_df_statmile_cost.Leave += new System.EventHandler(txt_amod_tot_df_statmile_cost_Leave);
			// 
			// txt_amod_tot_df_hour_cost
			// 
			txt_amod_tot_df_hour_cost.AcceptsReturn = true;
			txt_amod_tot_df_hour_cost.AllowDrop = true;
			txt_amod_tot_df_hour_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_df_hour_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_df_hour_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_df_hour_cost.Enabled = false;
			txt_amod_tot_df_hour_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_df_hour_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_df_hour_cost.Location = new System.Drawing.Point(248, 200);
			txt_amod_tot_df_hour_cost.MaxLength = 0;
			txt_amod_tot_df_hour_cost.Name = "txt_amod_tot_df_hour_cost";
			txt_amod_tot_df_hour_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_df_hour_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_df_hour_cost.TabIndex = 40;
			txt_amod_tot_df_hour_cost.Text = "0";
			txt_amod_tot_df_hour_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_df_hour_cost.Leave += new System.EventHandler(txt_amod_tot_df_hour_cost_Leave);
			// 
			// txt_amod_tot_df_annual_cost
			// 
			txt_amod_tot_df_annual_cost.AcceptsReturn = true;
			txt_amod_tot_df_annual_cost.AllowDrop = true;
			txt_amod_tot_df_annual_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_df_annual_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_df_annual_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_df_annual_cost.Enabled = false;
			txt_amod_tot_df_annual_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_df_annual_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_df_annual_cost.Location = new System.Drawing.Point(248, 176);
			txt_amod_tot_df_annual_cost.MaxLength = 0;
			txt_amod_tot_df_annual_cost.Name = "txt_amod_tot_df_annual_cost";
			txt_amod_tot_df_annual_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_df_annual_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_df_annual_cost.TabIndex = 41;
			txt_amod_tot_df_annual_cost.Text = "0";
			txt_amod_tot_df_annual_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_df_annual_cost.Leave += new System.EventHandler(txt_amod_tot_df_annual_cost_Leave);
			// 
			// txt_amod_tot_nd_seat_cost
			// 
			txt_amod_tot_nd_seat_cost.AcceptsReturn = true;
			txt_amod_tot_nd_seat_cost.AllowDrop = true;
			txt_amod_tot_nd_seat_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_nd_seat_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_nd_seat_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_nd_seat_cost.Enabled = false;
			txt_amod_tot_nd_seat_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_nd_seat_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_nd_seat_cost.Location = new System.Drawing.Point(248, 344);
			txt_amod_tot_nd_seat_cost.MaxLength = 0;
			txt_amod_tot_nd_seat_cost.Name = "txt_amod_tot_nd_seat_cost";
			txt_amod_tot_nd_seat_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_nd_seat_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_nd_seat_cost.TabIndex = 0;
			txt_amod_tot_nd_seat_cost.Text = "0";
			txt_amod_tot_nd_seat_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_nd_seat_cost.Leave += new System.EventHandler(txt_amod_tot_nd_seat_cost_Leave);
			// 
			// txt_amod_tot_nd_statmile_cost
			// 
			txt_amod_tot_nd_statmile_cost.AcceptsReturn = true;
			txt_amod_tot_nd_statmile_cost.AllowDrop = true;
			txt_amod_tot_nd_statmile_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_nd_statmile_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_nd_statmile_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_nd_statmile_cost.Enabled = false;
			txt_amod_tot_nd_statmile_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_nd_statmile_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_nd_statmile_cost.Location = new System.Drawing.Point(248, 320);
			txt_amod_tot_nd_statmile_cost.MaxLength = 0;
			txt_amod_tot_nd_statmile_cost.Name = "txt_amod_tot_nd_statmile_cost";
			txt_amod_tot_nd_statmile_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_nd_statmile_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_nd_statmile_cost.TabIndex = 35;
			txt_amod_tot_nd_statmile_cost.Text = "0";
			txt_amod_tot_nd_statmile_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_nd_statmile_cost.Leave += new System.EventHandler(txt_amod_tot_nd_statmile_cost_Leave);
			// 
			// txt_amod_tot_nd_hour_cost
			// 
			txt_amod_tot_nd_hour_cost.AcceptsReturn = true;
			txt_amod_tot_nd_hour_cost.AllowDrop = true;
			txt_amod_tot_nd_hour_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_nd_hour_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_nd_hour_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_nd_hour_cost.Enabled = false;
			txt_amod_tot_nd_hour_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_nd_hour_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_nd_hour_cost.Location = new System.Drawing.Point(248, 296);
			txt_amod_tot_nd_hour_cost.MaxLength = 0;
			txt_amod_tot_nd_hour_cost.Name = "txt_amod_tot_nd_hour_cost";
			txt_amod_tot_nd_hour_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_nd_hour_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_nd_hour_cost.TabIndex = 36;
			txt_amod_tot_nd_hour_cost.Text = "0";
			txt_amod_tot_nd_hour_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_nd_hour_cost.Leave += new System.EventHandler(txt_amod_tot_nd_hour_cost_Leave);
			// 
			// txt_amod_tot_nd_annual_cost
			// 
			txt_amod_tot_nd_annual_cost.AcceptsReturn = true;
			txt_amod_tot_nd_annual_cost.AllowDrop = true;
			txt_amod_tot_nd_annual_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_nd_annual_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_nd_annual_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_nd_annual_cost.Enabled = false;
			txt_amod_tot_nd_annual_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_nd_annual_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_nd_annual_cost.Location = new System.Drawing.Point(248, 272);
			txt_amod_tot_nd_annual_cost.MaxLength = 0;
			txt_amod_tot_nd_annual_cost.Name = "txt_amod_tot_nd_annual_cost";
			txt_amod_tot_nd_annual_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_nd_annual_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_nd_annual_cost.TabIndex = 37;
			txt_amod_tot_nd_annual_cost.Text = "0";
			txt_amod_tot_nd_annual_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_nd_annual_cost.Leave += new System.EventHandler(txt_amod_tot_nd_annual_cost_Leave);
			// 
			// _Label18_6
			// 
			_Label18_6.AllowDrop = true;
			_Label18_6.BackColor = System.Drawing.SystemColors.Control;
			_Label18_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label18_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label18_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label18_6.Location = new System.Drawing.Point(16, 88);
			_Label18_6.MinimumSize = new System.Drawing.Size(145, 17);
			_Label18_6.Name = "_Label18_6";
			_Label18_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label18_6.Size = new System.Drawing.Size(145, 17);
			_Label18_6.TabIndex = 129;
			_Label18_6.Text = "Hours:";
			// 
			// _Label17_4
			// 
			_Label17_4.AllowDrop = true;
			_Label17_4.BackColor = System.Drawing.SystemColors.Control;
			_Label17_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_4.Location = new System.Drawing.Point(16, 64);
			_Label17_4.MinimumSize = new System.Drawing.Size(121, 17);
			_Label17_4.Name = "_Label17_4";
			_Label17_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_4.Size = new System.Drawing.Size(121, 17);
			_Label17_4.TabIndex = 128;
			_Label17_4.Text = "Miles:";
			// 
			// _Label16_7
			// 
			_Label16_7.AllowDrop = true;
			_Label16_7.BackColor = System.Drawing.SystemColors.Control;
			_Label16_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_7.Location = new System.Drawing.Point(16, 40);
			_Label16_7.MinimumSize = new System.Drawing.Size(129, 17);
			_Label16_7.Name = "_Label16_7";
			_Label16_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_7.Size = new System.Drawing.Size(129, 17);
			_Label16_7.TabIndex = 127;
			_Label16_7.Text = "Passengers";
			// 
			// _Label16_8
			// 
			_Label16_8.AllowDrop = true;
			_Label16_8.BackColor = System.Drawing.Color.Transparent;
			_Label16_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_8.Location = new System.Drawing.Point(16, 128);
			_Label16_8.MinimumSize = new System.Drawing.Size(105, 17);
			_Label16_8.Name = "_Label16_8";
			_Label16_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_8.Size = new System.Drawing.Size(105, 17);
			_Label16_8.TabIndex = 126;
			_Label16_8.Text = "Total Direct Costs";
			// 
			// _Label16_9
			// 
			_Label16_9.AllowDrop = true;
			_Label16_9.BackColor = System.Drawing.Color.Transparent;
			_Label16_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_9.Location = new System.Drawing.Point(16, 152);
			_Label16_9.MinimumSize = new System.Drawing.Size(105, 17);
			_Label16_9.Name = "_Label16_9";
			_Label16_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_9.Size = new System.Drawing.Size(105, 17);
			_Label16_9.TabIndex = 125;
			_Label16_9.Text = "Total Fixed Costs:";
			// 
			// _Label18_7
			// 
			_Label18_7.AllowDrop = true;
			_Label18_7.BackColor = System.Drawing.SystemColors.Control;
			_Label18_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label18_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label18_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label18_7.Location = new System.Drawing.Point(32, 248);
			_Label18_7.MinimumSize = new System.Drawing.Size(145, 17);
			_Label18_7.Name = "_Label18_7";
			_Label18_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label18_7.Size = new System.Drawing.Size(145, 17);
			_Label18_7.TabIndex = 124;
			_Label18_7.Text = "Cost/Seat Mile";
			// 
			// _Label17_5
			// 
			_Label17_5.AllowDrop = true;
			_Label17_5.BackColor = System.Drawing.SystemColors.Control;
			_Label17_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_5.Location = new System.Drawing.Point(32, 224);
			_Label17_5.MinimumSize = new System.Drawing.Size(121, 17);
			_Label17_5.Name = "_Label17_5";
			_Label17_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_5.Size = new System.Drawing.Size(121, 17);
			_Label17_5.TabIndex = 123;
			_Label17_5.Text = "Cost/Statute Mile";
			// 
			// _Label16_10
			// 
			_Label16_10.AllowDrop = true;
			_Label16_10.BackColor = System.Drawing.SystemColors.Control;
			_Label16_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_10.Location = new System.Drawing.Point(32, 200);
			_Label16_10.MinimumSize = new System.Drawing.Size(129, 17);
			_Label16_10.Name = "_Label16_10";
			_Label16_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_10.Size = new System.Drawing.Size(129, 17);
			_Label16_10.TabIndex = 122;
			_Label16_10.Text = "Cost/Hour:";
			// 
			// _Label16_11
			// 
			_Label16_11.AllowDrop = true;
			_Label16_11.BackColor = System.Drawing.Color.Transparent;
			_Label16_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_11.Location = new System.Drawing.Point(16, 176);
			_Label16_11.MinimumSize = new System.Drawing.Size(257, 17);
			_Label16_11.Name = "_Label16_11";
			_Label16_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_11.Size = new System.Drawing.Size(257, 17);
			_Label16_11.TabIndex = 121;
			_Label16_11.Text = "Total Cost (Fixed & Direct w/Depreciation)";
			// 
			// _Label18_8
			// 
			_Label18_8.AllowDrop = true;
			_Label18_8.BackColor = System.Drawing.SystemColors.Control;
			_Label18_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label18_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label18_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label18_8.Location = new System.Drawing.Point(32, 344);
			_Label18_8.MinimumSize = new System.Drawing.Size(145, 17);
			_Label18_8.Name = "_Label18_8";
			_Label18_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label18_8.Size = new System.Drawing.Size(145, 17);
			_Label18_8.TabIndex = 120;
			_Label18_8.Text = "Cost/Seat Mile";
			// 
			// _Label17_6
			// 
			_Label17_6.AllowDrop = true;
			_Label17_6.BackColor = System.Drawing.SystemColors.Control;
			_Label17_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_6.Location = new System.Drawing.Point(32, 320);
			_Label17_6.MinimumSize = new System.Drawing.Size(121, 17);
			_Label17_6.Name = "_Label17_6";
			_Label17_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_6.Size = new System.Drawing.Size(121, 17);
			_Label17_6.TabIndex = 119;
			_Label17_6.Text = "Cost/Statute Mile";
			// 
			// _Label16_12
			// 
			_Label16_12.AllowDrop = true;
			_Label16_12.BackColor = System.Drawing.SystemColors.Control;
			_Label16_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_12.Location = new System.Drawing.Point(32, 296);
			_Label16_12.MinimumSize = new System.Drawing.Size(129, 17);
			_Label16_12.Name = "_Label16_12";
			_Label16_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_12.Size = new System.Drawing.Size(129, 17);
			_Label16_12.TabIndex = 118;
			_Label16_12.Text = "Cost/Hour:";
			// 
			// _Label16_13
			// 
			_Label16_13.AllowDrop = true;
			_Label16_13.BackColor = System.Drawing.Color.Transparent;
			_Label16_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_13.Location = new System.Drawing.Point(16, 272);
			_Label16_13.MinimumSize = new System.Drawing.Size(177, 17);
			_Label16_13.Name = "_Label16_13";
			_Label16_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_13.Size = new System.Drawing.Size(177, 17);
			_Label16_13.TabIndex = 117;
			_Label16_13.Text = "Total Cost  (No Depreciation)";
			// 
			// pnl_FixedCosts
			// 
			pnl_FixedCosts.AllowDrop = true;
			pnl_FixedCosts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_FixedCosts.Controls.Add(txt_var_misc);
			pnl_FixedCosts.Controls.Add(txt_amod_tot_variable_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_liability_insurance_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_hull_insurance_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_insurance_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_crew_benefit_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_cpilot_salary_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_capt_salary_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_tot_crew_salary_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_hangar_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_misc_naveq_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_misc_modern_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_misc_train_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_tot_misc_ovh_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_tot_fixed_cost);
			pnl_FixedCosts.Controls.Add(txt_amod_deprec_cost);
			pnl_FixedCosts.Controls.Add(_Label19_6);
			pnl_FixedCosts.Controls.Add(_Label19_0);
			pnl_FixedCosts.Controls.Add(_Label28_6);
			pnl_FixedCosts.Controls.Add(_Label20_4);
			pnl_FixedCosts.Controls.Add(_Label19_4);
			pnl_FixedCosts.Controls.Add(_Label18_2);
			pnl_FixedCosts.Controls.Add(_Label17_2);
			pnl_FixedCosts.Controls.Add(_Label16_3);
			pnl_FixedCosts.Controls.Add(_Label16_4);
			pnl_FixedCosts.Controls.Add(_Label18_3);
			pnl_FixedCosts.Controls.Add(_Label18_4);
			pnl_FixedCosts.Controls.Add(_Label17_3);
			pnl_FixedCosts.Controls.Add(_Label16_5);
			pnl_FixedCosts.Controls.Add(_Label16_6);
			pnl_FixedCosts.Controls.Add(_Label19_5);
			pnl_FixedCosts.Controls.Add(_Label18_5);
			pnl_FixedCosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_FixedCosts.Location = new System.Drawing.Point(256, 52);
			pnl_FixedCosts.Name = "pnl_FixedCosts";
			pnl_FixedCosts.Size = new System.Drawing.Size(233, 443);
			pnl_FixedCosts.TabIndex = 101;
			// 
			// txt_var_misc
			// 
			txt_var_misc.AcceptsReturn = true;
			txt_var_misc.AllowDrop = true;
			txt_var_misc.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_var_misc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_var_misc.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_var_misc.Enabled = false;
			txt_var_misc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_var_misc.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_var_misc.Location = new System.Drawing.Point(144, 408);
			txt_var_misc.MaxLength = 0;
			txt_var_misc.Name = "txt_var_misc";
			txt_var_misc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_var_misc.Size = new System.Drawing.Size(73, 22);
			txt_var_misc.TabIndex = 458;
			txt_var_misc.Text = "0";
			txt_var_misc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_tot_variable_cost
			// 
			txt_amod_tot_variable_cost.AcceptsReturn = true;
			txt_amod_tot_variable_cost.AllowDrop = true;
			txt_amod_tot_variable_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_variable_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_variable_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_variable_cost.Enabled = false;
			txt_amod_tot_variable_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_variable_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_variable_cost.Location = new System.Drawing.Point(144, 376);
			txt_amod_tot_variable_cost.MaxLength = 0;
			txt_amod_tot_variable_cost.Name = "txt_amod_tot_variable_cost";
			txt_amod_tot_variable_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_variable_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_variable_cost.TabIndex = 457;
			txt_amod_tot_variable_cost.Text = "0";
			txt_amod_tot_variable_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_variable_cost.Visible = false;
			// 
			// txt_amod_liability_insurance_cost
			// 
			txt_amod_liability_insurance_cost.AcceptsReturn = true;
			txt_amod_liability_insurance_cost.AllowDrop = true;
			txt_amod_liability_insurance_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_liability_insurance_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_liability_insurance_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_liability_insurance_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_liability_insurance_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_liability_insurance_cost.Location = new System.Drawing.Point(144, 209);
			txt_amod_liability_insurance_cost.MaxLength = 0;
			txt_amod_liability_insurance_cost.Name = "txt_amod_liability_insurance_cost";
			txt_amod_liability_insurance_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_liability_insurance_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_liability_insurance_cost.TabIndex = 84;
			txt_amod_liability_insurance_cost.Text = "0";
			txt_amod_liability_insurance_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_liability_insurance_cost.Leave += new System.EventHandler(txt_amod_liability_insurance_cost_Leave);
			// 
			// txt_amod_hull_insurance_cost
			// 
			txt_amod_hull_insurance_cost.AcceptsReturn = true;
			txt_amod_hull_insurance_cost.AllowDrop = true;
			txt_amod_hull_insurance_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_hull_insurance_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_hull_insurance_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_hull_insurance_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_hull_insurance_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_hull_insurance_cost.Location = new System.Drawing.Point(144, 184);
			txt_amod_hull_insurance_cost.MaxLength = 0;
			txt_amod_hull_insurance_cost.Name = "txt_amod_hull_insurance_cost";
			txt_amod_hull_insurance_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_hull_insurance_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_hull_insurance_cost.TabIndex = 83;
			txt_amod_hull_insurance_cost.Text = "0";
			txt_amod_hull_insurance_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_hull_insurance_cost.Leave += new System.EventHandler(txt_amod_hull_insurance_cost_Leave);
			// 
			// txt_amod_insurance_cost
			// 
			txt_amod_insurance_cost.AcceptsReturn = true;
			txt_amod_insurance_cost.AllowDrop = true;
			txt_amod_insurance_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_insurance_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_insurance_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_insurance_cost.Enabled = false;
			txt_amod_insurance_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_insurance_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_insurance_cost.Location = new System.Drawing.Point(144, 160);
			txt_amod_insurance_cost.MaxLength = 0;
			txt_amod_insurance_cost.Name = "txt_amod_insurance_cost";
			txt_amod_insurance_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_insurance_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_insurance_cost.TabIndex = 46;
			txt_amod_insurance_cost.Text = "0";
			txt_amod_insurance_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_crew_benefit_cost
			// 
			txt_amod_crew_benefit_cost.AcceptsReturn = true;
			txt_amod_crew_benefit_cost.AllowDrop = true;
			txt_amod_crew_benefit_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_crew_benefit_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_crew_benefit_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_crew_benefit_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_crew_benefit_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_crew_benefit_cost.Location = new System.Drawing.Point(144, 112);
			txt_amod_crew_benefit_cost.MaxLength = 0;
			txt_amod_crew_benefit_cost.Name = "txt_amod_crew_benefit_cost";
			txt_amod_crew_benefit_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_crew_benefit_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_crew_benefit_cost.TabIndex = 81;
			txt_amod_crew_benefit_cost.Text = "0";
			txt_amod_crew_benefit_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_crew_benefit_cost.Leave += new System.EventHandler(txt_amod_crew_benefit_cost_Leave);
			// 
			// txt_amod_cpilot_salary_cost
			// 
			txt_amod_cpilot_salary_cost.AcceptsReturn = true;
			txt_amod_cpilot_salary_cost.AllowDrop = true;
			txt_amod_cpilot_salary_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_cpilot_salary_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_cpilot_salary_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_cpilot_salary_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_cpilot_salary_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_cpilot_salary_cost.Location = new System.Drawing.Point(144, 88);
			txt_amod_cpilot_salary_cost.MaxLength = 0;
			txt_amod_cpilot_salary_cost.Name = "txt_amod_cpilot_salary_cost";
			txt_amod_cpilot_salary_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_cpilot_salary_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_cpilot_salary_cost.TabIndex = 80;
			txt_amod_cpilot_salary_cost.Text = "0";
			txt_amod_cpilot_salary_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_cpilot_salary_cost.Leave += new System.EventHandler(txt_amod_cpilot_salary_cost_Leave);
			// 
			// txt_amod_capt_salary_cost
			// 
			txt_amod_capt_salary_cost.AcceptsReturn = true;
			txt_amod_capt_salary_cost.AllowDrop = true;
			txt_amod_capt_salary_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_capt_salary_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_capt_salary_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_capt_salary_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_capt_salary_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_capt_salary_cost.Location = new System.Drawing.Point(144, 64);
			txt_amod_capt_salary_cost.MaxLength = 0;
			txt_amod_capt_salary_cost.Name = "txt_amod_capt_salary_cost";
			txt_amod_capt_salary_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_capt_salary_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_capt_salary_cost.TabIndex = 79;
			txt_amod_capt_salary_cost.Text = "0";
			txt_amod_capt_salary_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_capt_salary_cost.Leave += new System.EventHandler(txt_amod_capt_salary_cost_Leave);
			// 
			// txt_amod_tot_crew_salary_cost
			// 
			txt_amod_tot_crew_salary_cost.AcceptsReturn = true;
			txt_amod_tot_crew_salary_cost.AllowDrop = true;
			txt_amod_tot_crew_salary_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_crew_salary_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_crew_salary_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_crew_salary_cost.Enabled = false;
			txt_amod_tot_crew_salary_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_crew_salary_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_crew_salary_cost.Location = new System.Drawing.Point(145, 40);
			txt_amod_tot_crew_salary_cost.MaxLength = 0;
			txt_amod_tot_crew_salary_cost.Name = "txt_amod_tot_crew_salary_cost";
			txt_amod_tot_crew_salary_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_crew_salary_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_crew_salary_cost.TabIndex = 47;
			txt_amod_tot_crew_salary_cost.Text = "0";
			txt_amod_tot_crew_salary_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_crew_salary_cost.Leave += new System.EventHandler(txt_amod_tot_crew_salary_cost_Leave);
			// 
			// txt_amod_hangar_cost
			// 
			txt_amod_hangar_cost.AcceptsReturn = true;
			txt_amod_hangar_cost.AllowDrop = true;
			txt_amod_hangar_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_hangar_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_hangar_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_hangar_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_hangar_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_hangar_cost.Location = new System.Drawing.Point(144, 136);
			txt_amod_hangar_cost.MaxLength = 0;
			txt_amod_hangar_cost.Name = "txt_amod_hangar_cost";
			txt_amod_hangar_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_hangar_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_hangar_cost.TabIndex = 82;
			txt_amod_hangar_cost.Text = "0";
			txt_amod_hangar_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_hangar_cost.Leave += new System.EventHandler(txt_amod_hangar_cost_Leave);
			// 
			// txt_amod_misc_naveq_cost
			// 
			txt_amod_misc_naveq_cost.AcceptsReturn = true;
			txt_amod_misc_naveq_cost.AllowDrop = true;
			txt_amod_misc_naveq_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_misc_naveq_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_misc_naveq_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_misc_naveq_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_misc_naveq_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_misc_naveq_cost.Location = new System.Drawing.Point(144, 304);
			txt_amod_misc_naveq_cost.MaxLength = 0;
			txt_amod_misc_naveq_cost.Name = "txt_amod_misc_naveq_cost";
			txt_amod_misc_naveq_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_misc_naveq_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_misc_naveq_cost.TabIndex = 87;
			txt_amod_misc_naveq_cost.Text = "0";
			txt_amod_misc_naveq_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_misc_naveq_cost.Leave += new System.EventHandler(txt_amod_misc_naveq_cost_Leave);
			// 
			// txt_amod_misc_modern_cost
			// 
			txt_amod_misc_modern_cost.AcceptsReturn = true;
			txt_amod_misc_modern_cost.AllowDrop = true;
			txt_amod_misc_modern_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_misc_modern_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_misc_modern_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_misc_modern_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_misc_modern_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_misc_modern_cost.Location = new System.Drawing.Point(144, 280);
			txt_amod_misc_modern_cost.MaxLength = 0;
			txt_amod_misc_modern_cost.Name = "txt_amod_misc_modern_cost";
			txt_amod_misc_modern_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_misc_modern_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_misc_modern_cost.TabIndex = 86;
			txt_amod_misc_modern_cost.Text = "0";
			txt_amod_misc_modern_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_misc_modern_cost.Leave += new System.EventHandler(txt_amod_misc_modern_cost_Leave);
			// 
			// txt_amod_misc_train_cost
			// 
			txt_amod_misc_train_cost.AcceptsReturn = true;
			txt_amod_misc_train_cost.AllowDrop = true;
			txt_amod_misc_train_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_misc_train_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_misc_train_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_misc_train_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_misc_train_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_misc_train_cost.Location = new System.Drawing.Point(144, 256);
			txt_amod_misc_train_cost.MaxLength = 0;
			txt_amod_misc_train_cost.Name = "txt_amod_misc_train_cost";
			txt_amod_misc_train_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_misc_train_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_misc_train_cost.TabIndex = 85;
			txt_amod_misc_train_cost.Text = "0";
			txt_amod_misc_train_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_misc_train_cost.Leave += new System.EventHandler(txt_amod_misc_train_cost_Leave);
			// 
			// txt_amod_tot_misc_ovh_cost
			// 
			txt_amod_tot_misc_ovh_cost.AcceptsReturn = true;
			txt_amod_tot_misc_ovh_cost.AllowDrop = true;
			txt_amod_tot_misc_ovh_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_misc_ovh_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_misc_ovh_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_misc_ovh_cost.Enabled = false;
			txt_amod_tot_misc_ovh_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_misc_ovh_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_misc_ovh_cost.Location = new System.Drawing.Point(144, 232);
			txt_amod_tot_misc_ovh_cost.MaxLength = 0;
			txt_amod_tot_misc_ovh_cost.Name = "txt_amod_tot_misc_ovh_cost";
			txt_amod_tot_misc_ovh_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_misc_ovh_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_misc_ovh_cost.TabIndex = 45;
			txt_amod_tot_misc_ovh_cost.Text = "0";
			txt_amod_tot_misc_ovh_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_tot_fixed_cost
			// 
			txt_amod_tot_fixed_cost.AcceptsReturn = true;
			txt_amod_tot_fixed_cost.AllowDrop = true;
			txt_amod_tot_fixed_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_fixed_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_fixed_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_fixed_cost.Enabled = false;
			txt_amod_tot_fixed_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_fixed_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_fixed_cost.Location = new System.Drawing.Point(144, 352);
			txt_amod_tot_fixed_cost.MaxLength = 0;
			txt_amod_tot_fixed_cost.Name = "txt_amod_tot_fixed_cost";
			txt_amod_tot_fixed_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_fixed_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_fixed_cost.TabIndex = 44;
			txt_amod_tot_fixed_cost.Text = "0";
			txt_amod_tot_fixed_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_deprec_cost
			// 
			txt_amod_deprec_cost.AcceptsReturn = true;
			txt_amod_deprec_cost.AllowDrop = true;
			txt_amod_deprec_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_deprec_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_deprec_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_deprec_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_deprec_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_deprec_cost.Location = new System.Drawing.Point(143, 328);
			txt_amod_deprec_cost.MaxLength = 0;
			txt_amod_deprec_cost.Name = "txt_amod_deprec_cost";
			txt_amod_deprec_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_deprec_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_deprec_cost.TabIndex = 88;
			txt_amod_deprec_cost.Text = "0";
			txt_amod_deprec_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_deprec_cost.Leave += new System.EventHandler(txt_amod_deprec_cost_Leave);
			// 
			// _Label19_6
			// 
			_Label19_6.AllowDrop = true;
			_Label19_6.BackColor = System.Drawing.SystemColors.Control;
			_Label19_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label19_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label19_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label19_6.Location = new System.Drawing.Point(16, 416);
			_Label19_6.MinimumSize = new System.Drawing.Size(129, 17);
			_Label19_6.Name = "_Label19_6";
			_Label19_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label19_6.Size = new System.Drawing.Size(129, 17);
			_Label19_6.TabIndex = 456;
			_Label19_6.Text = "Total Variable Costs:";
			// 
			// _Label19_0
			// 
			_Label19_0.AllowDrop = true;
			_Label19_0.BackColor = System.Drawing.SystemColors.Control;
			_Label19_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label19_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label19_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label19_0.Location = new System.Drawing.Point(16, 384);
			_Label19_0.MinimumSize = new System.Drawing.Size(129, 17);
			_Label19_0.Name = "_Label19_0";
			_Label19_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label19_0.Size = new System.Drawing.Size(129, 17);
			_Label19_0.TabIndex = 448;
			_Label19_0.Text = "Total Variable Costs:";
			_Label19_0.Visible = false;
			// 
			// _Label28_6
			// 
			_Label28_6.AllowDrop = true;
			_Label28_6.BackColor = System.Drawing.SystemColors.Control;
			_Label28_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label28_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label28_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label28_6.Location = new System.Drawing.Point(32, 208);
			_Label28_6.MinimumSize = new System.Drawing.Size(105, 17);
			_Label28_6.Name = "_Label28_6";
			_Label28_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label28_6.Size = new System.Drawing.Size(105, 17);
			_Label28_6.TabIndex = 115;
			_Label28_6.Text = "Legal Liability:";
			// 
			// _Label20_4
			// 
			_Label20_4.AllowDrop = true;
			_Label20_4.BackColor = System.Drawing.SystemColors.Control;
			_Label20_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label20_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label20_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label20_4.Location = new System.Drawing.Point(32, 184);
			_Label20_4.MinimumSize = new System.Drawing.Size(105, 17);
			_Label20_4.Name = "_Label20_4";
			_Label20_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label20_4.Size = new System.Drawing.Size(105, 17);
			_Label20_4.TabIndex = 114;
			_Label20_4.Text = "Hull:";
			// 
			// _Label19_4
			// 
			_Label19_4.AllowDrop = true;
			_Label19_4.BackColor = System.Drawing.SystemColors.Control;
			_Label19_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label19_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label19_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label19_4.Location = new System.Drawing.Point(16, 160);
			_Label19_4.MinimumSize = new System.Drawing.Size(129, 17);
			_Label19_4.Name = "_Label19_4";
			_Label19_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label19_4.Size = new System.Drawing.Size(129, 17);
			_Label19_4.TabIndex = 113;
			_Label19_4.Text = "Insurance:";
			// 
			// _Label18_2
			// 
			_Label18_2.AllowDrop = true;
			_Label18_2.BackColor = System.Drawing.SystemColors.Control;
			_Label18_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label18_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label18_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label18_2.Location = new System.Drawing.Point(32, 112);
			_Label18_2.MinimumSize = new System.Drawing.Size(145, 17);
			_Label18_2.Name = "_Label18_2";
			_Label18_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label18_2.Size = new System.Drawing.Size(145, 17);
			_Label18_2.TabIndex = 112;
			_Label18_2.Text = "Benefits:";
			// 
			// _Label17_2
			// 
			_Label17_2.AllowDrop = true;
			_Label17_2.BackColor = System.Drawing.SystemColors.Control;
			_Label17_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_2.Location = new System.Drawing.Point(32, 88);
			_Label17_2.MinimumSize = new System.Drawing.Size(121, 17);
			_Label17_2.Name = "_Label17_2";
			_Label17_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_2.Size = new System.Drawing.Size(121, 17);
			_Label17_2.TabIndex = 111;
			_Label17_2.Text = "Co-Pilot Salary:";
			// 
			// _Label16_3
			// 
			_Label16_3.AllowDrop = true;
			_Label16_3.BackColor = System.Drawing.SystemColors.Control;
			_Label16_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_3.Location = new System.Drawing.Point(32, 64);
			_Label16_3.MinimumSize = new System.Drawing.Size(129, 17);
			_Label16_3.Name = "_Label16_3";
			_Label16_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_3.Size = new System.Drawing.Size(129, 17);
			_Label16_3.TabIndex = 110;
			_Label16_3.Text = "Capt. Salary:";
			// 
			// _Label16_4
			// 
			_Label16_4.AllowDrop = true;
			_Label16_4.BackColor = System.Drawing.Color.Transparent;
			_Label16_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_4.Location = new System.Drawing.Point(16, 40);
			_Label16_4.MinimumSize = new System.Drawing.Size(105, 17);
			_Label16_4.Name = "_Label16_4";
			_Label16_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_4.Size = new System.Drawing.Size(105, 17);
			_Label16_4.TabIndex = 109;
			_Label16_4.Text = "Crew Salaries:";
			// 
			// _Label18_3
			// 
			_Label18_3.AllowDrop = true;
			_Label18_3.BackColor = System.Drawing.SystemColors.Control;
			_Label18_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label18_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label18_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label18_3.Location = new System.Drawing.Point(16, 136);
			_Label18_3.MinimumSize = new System.Drawing.Size(145, 17);
			_Label18_3.Name = "_Label18_3";
			_Label18_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label18_3.Size = new System.Drawing.Size(145, 17);
			_Label18_3.TabIndex = 108;
			_Label18_3.Text = "Hangar Cost:";
			// 
			// _Label18_4
			// 
			_Label18_4.AllowDrop = true;
			_Label18_4.BackColor = System.Drawing.SystemColors.Control;
			_Label18_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label18_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label18_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label18_4.Location = new System.Drawing.Point(32, 304);
			_Label18_4.MinimumSize = new System.Drawing.Size(145, 17);
			_Label18_4.Name = "_Label18_4";
			_Label18_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label18_4.Size = new System.Drawing.Size(145, 17);
			_Label18_4.TabIndex = 107;
			_Label18_4.Text = "Nav. Equipment:";
			// 
			// _Label17_3
			// 
			_Label17_3.AllowDrop = true;
			_Label17_3.BackColor = System.Drawing.SystemColors.Control;
			_Label17_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_3.Location = new System.Drawing.Point(32, 280);
			_Label17_3.MinimumSize = new System.Drawing.Size(121, 17);
			_Label17_3.Name = "_Label17_3";
			_Label17_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_3.Size = new System.Drawing.Size(121, 17);
			_Label17_3.TabIndex = 106;
			_Label17_3.Text = "Modernization:";
			// 
			// _Label16_5
			// 
			_Label16_5.AllowDrop = true;
			_Label16_5.BackColor = System.Drawing.SystemColors.Control;
			_Label16_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_5.Location = new System.Drawing.Point(32, 256);
			_Label16_5.MinimumSize = new System.Drawing.Size(129, 17);
			_Label16_5.Name = "_Label16_5";
			_Label16_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_5.Size = new System.Drawing.Size(129, 17);
			_Label16_5.TabIndex = 105;
			_Label16_5.Text = "Training:";
			// 
			// _Label16_6
			// 
			_Label16_6.AllowDrop = true;
			_Label16_6.BackColor = System.Drawing.Color.Transparent;
			_Label16_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_6.Location = new System.Drawing.Point(16, 232);
			_Label16_6.MinimumSize = new System.Drawing.Size(105, 17);
			_Label16_6.Name = "_Label16_6";
			_Label16_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_6.Size = new System.Drawing.Size(105, 17);
			_Label16_6.TabIndex = 104;
			_Label16_6.Text = "Misc. Overhead:";
			// 
			// _Label19_5
			// 
			_Label19_5.AllowDrop = true;
			_Label19_5.BackColor = System.Drawing.SystemColors.Control;
			_Label19_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label19_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label19_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label19_5.Location = new System.Drawing.Point(16, 352);
			_Label19_5.MinimumSize = new System.Drawing.Size(129, 17);
			_Label19_5.Name = "_Label19_5";
			_Label19_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label19_5.Size = new System.Drawing.Size(129, 17);
			_Label19_5.TabIndex = 103;
			_Label19_5.Text = "Total Fixed Costs:";
			// 
			// _Label18_5
			// 
			_Label18_5.AllowDrop = true;
			_Label18_5.BackColor = System.Drawing.SystemColors.Control;
			_Label18_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label18_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label18_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label18_5.Location = new System.Drawing.Point(32, 328);
			_Label18_5.MinimumSize = new System.Drawing.Size(145, 17);
			_Label18_5.Name = "_Label18_5";
			_Label18_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label18_5.Size = new System.Drawing.Size(145, 17);
			_Label18_5.TabIndex = 102;
			_Label18_5.Text = "Depreciation:";
			// 
			// pnl_DirectCost
			// 
			pnl_DirectCost.AllowDrop = true;
			pnl_DirectCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_DirectCost.Controls.Add(txt_amod_maint_parts_man_hour_multiplier);
			pnl_DirectCost.Controls.Add(txt_amod_maint_labor_man_hour_multiplier);
			pnl_DirectCost.Controls.Add(txt_amod_maint_parts_cost);
			pnl_DirectCost.Controls.Add(txt_amod_maint_lab_cost);
			pnl_DirectCost.Controls.Add(txt_amod_maint_tot_cost);
			pnl_DirectCost.Controls.Add(txt_amod_fuel_burn_rate);
			pnl_DirectCost.Controls.Add(txt_amod_fuel_add_cost);
			pnl_DirectCost.Controls.Add(txt_amod_fuel_gal_cost);
			pnl_DirectCost.Controls.Add(txt_amod_fuel_tot_cost);
			pnl_DirectCost.Controls.Add(txt_amod_engine_ovh_cost);
			pnl_DirectCost.Controls.Add(txt_amod_thrust_rev_ovh_cost);
			pnl_DirectCost.Controls.Add(txt_amod_misc_flight_cost);
			pnl_DirectCost.Controls.Add(txt_amod_land_park_cost);
			pnl_DirectCost.Controls.Add(txt_amod_crew_exp_cost);
			pnl_DirectCost.Controls.Add(txt_amod_supplies_cost);
			pnl_DirectCost.Controls.Add(txt_amod_tot_hour_direct_cost);
			pnl_DirectCost.Controls.Add(txt_amod_avg_block_speed);
			pnl_DirectCost.Controls.Add(txt_amod_tot_stat_mile_cost);
			pnl_DirectCost.Controls.Add(_Label20_5);
			pnl_DirectCost.Controls.Add(_Label20_0);
			pnl_DirectCost.Controls.Add(_Label28_1);
			pnl_DirectCost.Controls.Add(_Label20_1);
			pnl_DirectCost.Controls.Add(_Label19_1);
			pnl_DirectCost.Controls.Add(_Label18_0);
			pnl_DirectCost.Controls.Add(_Label16_0);
			pnl_DirectCost.Controls.Add(_Label16_1);
			pnl_DirectCost.Controls.Add(_Label16_2);
			pnl_DirectCost.Controls.Add(_Label20_2);
			pnl_DirectCost.Controls.Add(_Label20_3);
			pnl_DirectCost.Controls.Add(_Label19_2);
			pnl_DirectCost.Controls.Add(_Label28_2);
			pnl_DirectCost.Controls.Add(_Label28_3);
			pnl_DirectCost.Controls.Add(_Label28_5);
			pnl_DirectCost.Controls.Add(_Label19_3);
			pnl_DirectCost.Controls.Add(_Label28_7);
			pnl_DirectCost.Controls.Add(_Label28_8);
			pnl_DirectCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_DirectCost.Location = new System.Drawing.Point(16, 36);
			pnl_DirectCost.Name = "pnl_DirectCost";
			pnl_DirectCost.Size = new System.Drawing.Size(233, 461);
			pnl_DirectCost.TabIndex = 56;
			// 
			// txt_amod_maint_parts_man_hour_multiplier
			// 
			txt_amod_maint_parts_man_hour_multiplier.AcceptsReturn = true;
			txt_amod_maint_parts_man_hour_multiplier.AllowDrop = true;
			txt_amod_maint_parts_man_hour_multiplier.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_maint_parts_man_hour_multiplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_maint_parts_man_hour_multiplier.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_maint_parts_man_hour_multiplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_maint_parts_man_hour_multiplier.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_maint_parts_man_hour_multiplier.Location = new System.Drawing.Point(144, 216);
			txt_amod_maint_parts_man_hour_multiplier.MaxLength = 0;
			txt_amod_maint_parts_man_hour_multiplier.Name = "txt_amod_maint_parts_man_hour_multiplier";
			txt_amod_maint_parts_man_hour_multiplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_maint_parts_man_hour_multiplier.Size = new System.Drawing.Size(73, 19);
			txt_amod_maint_parts_man_hour_multiplier.TabIndex = 73;
			txt_amod_maint_parts_man_hour_multiplier.Text = "0.0";
			txt_amod_maint_parts_man_hour_multiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_maint_parts_man_hour_multiplier.Leave += new System.EventHandler(txt_amod_maint_parts_man_hour_multiplier_Leave);
			// 
			// txt_amod_maint_labor_man_hour_multiplier
			// 
			txt_amod_maint_labor_man_hour_multiplier.AcceptsReturn = true;
			txt_amod_maint_labor_man_hour_multiplier.AllowDrop = true;
			txt_amod_maint_labor_man_hour_multiplier.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_maint_labor_man_hour_multiplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_maint_labor_man_hour_multiplier.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_maint_labor_man_hour_multiplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_maint_labor_man_hour_multiplier.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_maint_labor_man_hour_multiplier.Location = new System.Drawing.Point(144, 168);
			txt_amod_maint_labor_man_hour_multiplier.MaxLength = 0;
			txt_amod_maint_labor_man_hour_multiplier.Name = "txt_amod_maint_labor_man_hour_multiplier";
			txt_amod_maint_labor_man_hour_multiplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_maint_labor_man_hour_multiplier.Size = new System.Drawing.Size(73, 19);
			txt_amod_maint_labor_man_hour_multiplier.TabIndex = 62;
			txt_amod_maint_labor_man_hour_multiplier.Text = "0.0";
			txt_amod_maint_labor_man_hour_multiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_maint_labor_man_hour_multiplier.Leave += new System.EventHandler(txt_amod_maint_labor_man_hour_multiplier_Leave);
			// 
			// txt_amod_maint_parts_cost
			// 
			txt_amod_maint_parts_cost.AcceptsReturn = true;
			txt_amod_maint_parts_cost.AllowDrop = true;
			txt_amod_maint_parts_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_maint_parts_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_maint_parts_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_maint_parts_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_maint_parts_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_maint_parts_cost.Location = new System.Drawing.Point(144, 192);
			txt_amod_maint_parts_cost.MaxLength = 0;
			txt_amod_maint_parts_cost.Name = "txt_amod_maint_parts_cost";
			txt_amod_maint_parts_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_maint_parts_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_maint_parts_cost.TabIndex = 63;
			txt_amod_maint_parts_cost.Text = "0";
			txt_amod_maint_parts_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_maint_parts_cost.Leave += new System.EventHandler(txt_amod_maint_parts_cost_Leave);
			// 
			// txt_amod_maint_lab_cost
			// 
			txt_amod_maint_lab_cost.AcceptsReturn = true;
			txt_amod_maint_lab_cost.AllowDrop = true;
			txt_amod_maint_lab_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_maint_lab_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_maint_lab_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_maint_lab_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_maint_lab_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_maint_lab_cost.Location = new System.Drawing.Point(146, 144);
			txt_amod_maint_lab_cost.MaxLength = 0;
			txt_amod_maint_lab_cost.Name = "txt_amod_maint_lab_cost";
			txt_amod_maint_lab_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_maint_lab_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_maint_lab_cost.TabIndex = 61;
			txt_amod_maint_lab_cost.Text = "0";
			txt_amod_maint_lab_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_maint_lab_cost.Leave += new System.EventHandler(txt_amod_maint_lab_cost_Leave);
			// 
			// txt_amod_maint_tot_cost
			// 
			txt_amod_maint_tot_cost.AcceptsReturn = true;
			txt_amod_maint_tot_cost.AllowDrop = true;
			txt_amod_maint_tot_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_maint_tot_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_maint_tot_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_maint_tot_cost.Enabled = false;
			txt_amod_maint_tot_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_maint_tot_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_maint_tot_cost.Location = new System.Drawing.Point(144, 120);
			txt_amod_maint_tot_cost.MaxLength = 0;
			txt_amod_maint_tot_cost.Name = "txt_amod_maint_tot_cost";
			txt_amod_maint_tot_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_maint_tot_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_maint_tot_cost.TabIndex = 49;
			txt_amod_maint_tot_cost.Text = "0";
			txt_amod_maint_tot_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_fuel_burn_rate
			// 
			txt_amod_fuel_burn_rate.AcceptsReturn = true;
			txt_amod_fuel_burn_rate.AllowDrop = true;
			txt_amod_fuel_burn_rate.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_fuel_burn_rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_fuel_burn_rate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_fuel_burn_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_fuel_burn_rate.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_fuel_burn_rate.Location = new System.Drawing.Point(144, 96);
			txt_amod_fuel_burn_rate.MaxLength = 0;
			txt_amod_fuel_burn_rate.Name = "txt_amod_fuel_burn_rate";
			txt_amod_fuel_burn_rate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_fuel_burn_rate.Size = new System.Drawing.Size(73, 19);
			txt_amod_fuel_burn_rate.TabIndex = 60;
			txt_amod_fuel_burn_rate.Text = "0";
			txt_amod_fuel_burn_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_fuel_burn_rate.Leave += new System.EventHandler(txt_amod_fuel_burn_rate_Leave);
			// 
			// txt_amod_fuel_add_cost
			// 
			txt_amod_fuel_add_cost.AcceptsReturn = true;
			txt_amod_fuel_add_cost.AllowDrop = true;
			txt_amod_fuel_add_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_fuel_add_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_fuel_add_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_fuel_add_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_fuel_add_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_fuel_add_cost.Location = new System.Drawing.Point(144, 72);
			txt_amod_fuel_add_cost.MaxLength = 0;
			txt_amod_fuel_add_cost.Name = "txt_amod_fuel_add_cost";
			txt_amod_fuel_add_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_fuel_add_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_fuel_add_cost.TabIndex = 59;
			txt_amod_fuel_add_cost.Text = "0";
			txt_amod_fuel_add_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_fuel_add_cost.Leave += new System.EventHandler(txt_amod_fuel_add_cost_Leave);
			// 
			// txt_amod_fuel_gal_cost
			// 
			txt_amod_fuel_gal_cost.AcceptsReturn = true;
			txt_amod_fuel_gal_cost.AllowDrop = true;
			txt_amod_fuel_gal_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_fuel_gal_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_fuel_gal_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_fuel_gal_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_fuel_gal_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_fuel_gal_cost.Location = new System.Drawing.Point(144, 48);
			txt_amod_fuel_gal_cost.MaxLength = 0;
			txt_amod_fuel_gal_cost.Name = "txt_amod_fuel_gal_cost";
			txt_amod_fuel_gal_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_fuel_gal_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_fuel_gal_cost.TabIndex = 58;
			txt_amod_fuel_gal_cost.Text = "0";
			txt_amod_fuel_gal_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_fuel_gal_cost.Leave += new System.EventHandler(txt_amod_fuel_gal_cost_Leave);
			// 
			// txt_amod_fuel_tot_cost
			// 
			txt_amod_fuel_tot_cost.AcceptsReturn = true;
			txt_amod_fuel_tot_cost.AllowDrop = true;
			txt_amod_fuel_tot_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_fuel_tot_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_fuel_tot_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_fuel_tot_cost.Enabled = false;
			txt_amod_fuel_tot_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_fuel_tot_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_fuel_tot_cost.Location = new System.Drawing.Point(144, 24);
			txt_amod_fuel_tot_cost.MaxLength = 0;
			txt_amod_fuel_tot_cost.Name = "txt_amod_fuel_tot_cost";
			txt_amod_fuel_tot_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_fuel_tot_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_fuel_tot_cost.TabIndex = 57;
			txt_amod_fuel_tot_cost.Text = "0";
			txt_amod_fuel_tot_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_engine_ovh_cost
			// 
			txt_amod_engine_ovh_cost.AcceptsReturn = true;
			txt_amod_engine_ovh_cost.AllowDrop = true;
			txt_amod_engine_ovh_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_engine_ovh_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_engine_ovh_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_engine_ovh_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_engine_ovh_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_engine_ovh_cost.Location = new System.Drawing.Point(144, 240);
			txt_amod_engine_ovh_cost.MaxLength = 0;
			txt_amod_engine_ovh_cost.Name = "txt_amod_engine_ovh_cost";
			txt_amod_engine_ovh_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_engine_ovh_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_engine_ovh_cost.TabIndex = 65;
			txt_amod_engine_ovh_cost.Text = "0";
			txt_amod_engine_ovh_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_engine_ovh_cost.Leave += new System.EventHandler(txt_amod_engine_ovh_cost_Leave);
			// 
			// txt_amod_thrust_rev_ovh_cost
			// 
			txt_amod_thrust_rev_ovh_cost.AcceptsReturn = true;
			txt_amod_thrust_rev_ovh_cost.AllowDrop = true;
			txt_amod_thrust_rev_ovh_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_thrust_rev_ovh_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_thrust_rev_ovh_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_thrust_rev_ovh_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_thrust_rev_ovh_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_thrust_rev_ovh_cost.Location = new System.Drawing.Point(144, 264);
			txt_amod_thrust_rev_ovh_cost.MaxLength = 0;
			txt_amod_thrust_rev_ovh_cost.Name = "txt_amod_thrust_rev_ovh_cost";
			txt_amod_thrust_rev_ovh_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_thrust_rev_ovh_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_thrust_rev_ovh_cost.TabIndex = 67;
			txt_amod_thrust_rev_ovh_cost.Text = "0";
			txt_amod_thrust_rev_ovh_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_thrust_rev_ovh_cost.Leave += new System.EventHandler(txt_amod_thrust_rev_ovh_cost_Leave);
			// 
			// txt_amod_misc_flight_cost
			// 
			txt_amod_misc_flight_cost.AcceptsReturn = true;
			txt_amod_misc_flight_cost.AllowDrop = true;
			txt_amod_misc_flight_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_misc_flight_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_misc_flight_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_misc_flight_cost.Enabled = false;
			txt_amod_misc_flight_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_misc_flight_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_misc_flight_cost.Location = new System.Drawing.Point(144, 288);
			txt_amod_misc_flight_cost.MaxLength = 0;
			txt_amod_misc_flight_cost.Name = "txt_amod_misc_flight_cost";
			txt_amod_misc_flight_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_misc_flight_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_misc_flight_cost.TabIndex = 50;
			txt_amod_misc_flight_cost.Text = "0";
			txt_amod_misc_flight_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_land_park_cost
			// 
			txt_amod_land_park_cost.AcceptsReturn = true;
			txt_amod_land_park_cost.AllowDrop = true;
			txt_amod_land_park_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_land_park_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_land_park_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_land_park_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_land_park_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_land_park_cost.Location = new System.Drawing.Point(144, 312);
			txt_amod_land_park_cost.MaxLength = 0;
			txt_amod_land_park_cost.Name = "txt_amod_land_park_cost";
			txt_amod_land_park_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_land_park_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_land_park_cost.TabIndex = 69;
			txt_amod_land_park_cost.Text = "0";
			txt_amod_land_park_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_land_park_cost.Leave += new System.EventHandler(txt_amod_land_park_cost_Leave);
			// 
			// txt_amod_crew_exp_cost
			// 
			txt_amod_crew_exp_cost.AcceptsReturn = true;
			txt_amod_crew_exp_cost.AllowDrop = true;
			txt_amod_crew_exp_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_crew_exp_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_crew_exp_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_crew_exp_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_crew_exp_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_crew_exp_cost.Location = new System.Drawing.Point(144, 336);
			txt_amod_crew_exp_cost.MaxLength = 0;
			txt_amod_crew_exp_cost.Name = "txt_amod_crew_exp_cost";
			txt_amod_crew_exp_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_crew_exp_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_crew_exp_cost.TabIndex = 71;
			txt_amod_crew_exp_cost.Text = "0";
			txt_amod_crew_exp_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_crew_exp_cost.Leave += new System.EventHandler(txt_amod_crew_exp_cost_Leave);
			// 
			// txt_amod_supplies_cost
			// 
			txt_amod_supplies_cost.AcceptsReturn = true;
			txt_amod_supplies_cost.AllowDrop = true;
			txt_amod_supplies_cost.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_supplies_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_supplies_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_supplies_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_supplies_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_supplies_cost.Location = new System.Drawing.Point(144, 360);
			txt_amod_supplies_cost.MaxLength = 0;
			txt_amod_supplies_cost.Name = "txt_amod_supplies_cost";
			txt_amod_supplies_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_supplies_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_supplies_cost.TabIndex = 74;
			txt_amod_supplies_cost.Text = "0";
			txt_amod_supplies_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_supplies_cost.Leave += new System.EventHandler(txt_amod_supplies_cost_Leave);
			// 
			// txt_amod_tot_hour_direct_cost
			// 
			txt_amod_tot_hour_direct_cost.AcceptsReturn = true;
			txt_amod_tot_hour_direct_cost.AllowDrop = true;
			txt_amod_tot_hour_direct_cost.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_tot_hour_direct_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_hour_direct_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_hour_direct_cost.Enabled = false;
			txt_amod_tot_hour_direct_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_hour_direct_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_hour_direct_cost.Location = new System.Drawing.Point(144, 385);
			txt_amod_tot_hour_direct_cost.MaxLength = 0;
			txt_amod_tot_hour_direct_cost.Name = "txt_amod_tot_hour_direct_cost";
			txt_amod_tot_hour_direct_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_hour_direct_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_hour_direct_cost.TabIndex = 48;
			txt_amod_tot_hour_direct_cost.Text = "0";
			txt_amod_tot_hour_direct_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_avg_block_speed
			// 
			txt_amod_avg_block_speed.AcceptsReturn = true;
			txt_amod_avg_block_speed.AllowDrop = true;
			txt_amod_avg_block_speed.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_avg_block_speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_avg_block_speed.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_avg_block_speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_avg_block_speed.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_avg_block_speed.Location = new System.Drawing.Point(144, 408);
			txt_amod_avg_block_speed.MaxLength = 0;
			txt_amod_avg_block_speed.Name = "txt_amod_avg_block_speed";
			txt_amod_avg_block_speed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_avg_block_speed.Size = new System.Drawing.Size(73, 19);
			txt_amod_avg_block_speed.TabIndex = 76;
			txt_amod_avg_block_speed.Text = "0";
			txt_amod_avg_block_speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_avg_block_speed.Leave += new System.EventHandler(txt_amod_avg_block_speed_Leave);
			// 
			// txt_amod_tot_stat_mile_cost
			// 
			txt_amod_tot_stat_mile_cost.AcceptsReturn = true;
			txt_amod_tot_stat_mile_cost.AllowDrop = true;
			txt_amod_tot_stat_mile_cost.BackColor = System.Drawing.SystemColors.Menu;
			txt_amod_tot_stat_mile_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tot_stat_mile_cost.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tot_stat_mile_cost.Enabled = false;
			txt_amod_tot_stat_mile_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tot_stat_mile_cost.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tot_stat_mile_cost.Location = new System.Drawing.Point(144, 432);
			txt_amod_tot_stat_mile_cost.MaxLength = 0;
			txt_amod_tot_stat_mile_cost.Name = "txt_amod_tot_stat_mile_cost";
			txt_amod_tot_stat_mile_cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tot_stat_mile_cost.Size = new System.Drawing.Size(73, 19);
			txt_amod_tot_stat_mile_cost.TabIndex = 78;
			txt_amod_tot_stat_mile_cost.Text = "0";
			txt_amod_tot_stat_mile_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_tot_stat_mile_cost.Leave += new System.EventHandler(txt_amod_tot_stat_mile_cost_Leave);
			// 
			// _Label20_5
			// 
			_Label20_5.AllowDrop = true;
			_Label20_5.BackColor = System.Drawing.SystemColors.Control;
			_Label20_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label20_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label20_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label20_5.Location = new System.Drawing.Point(32, 216);
			_Label20_5.MinimumSize = new System.Drawing.Size(105, 17);
			_Label20_5.Name = "_Label20_5";
			_Label20_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label20_5.Size = new System.Drawing.Size(105, 17);
			_Label20_5.TabIndex = 424;
			_Label20_5.Text = "Man Hour Multiplier";
			// 
			// _Label20_0
			// 
			_Label20_0.AllowDrop = true;
			_Label20_0.BackColor = System.Drawing.SystemColors.Control;
			_Label20_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label20_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label20_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label20_0.Location = new System.Drawing.Point(32, 168);
			_Label20_0.MinimumSize = new System.Drawing.Size(105, 17);
			_Label20_0.Name = "_Label20_0";
			_Label20_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label20_0.Size = new System.Drawing.Size(105, 17);
			_Label20_0.TabIndex = 423;
			_Label20_0.Text = "Man Hour Multiplier";
			// 
			// _Label28_1
			// 
			_Label28_1.AllowDrop = true;
			_Label28_1.BackColor = System.Drawing.SystemColors.Control;
			_Label28_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label28_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label28_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label28_1.Location = new System.Drawing.Point(32, 192);
			_Label28_1.MinimumSize = new System.Drawing.Size(105, 17);
			_Label28_1.Name = "_Label28_1";
			_Label28_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label28_1.Size = new System.Drawing.Size(105, 17);
			_Label28_1.TabIndex = 100;
			_Label28_1.Text = "Parts/Hour:";
			// 
			// _Label20_1
			// 
			_Label20_1.AllowDrop = true;
			_Label20_1.BackColor = System.Drawing.SystemColors.Control;
			_Label20_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label20_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label20_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label20_1.Location = new System.Drawing.Point(32, 144);
			_Label20_1.MinimumSize = new System.Drawing.Size(105, 17);
			_Label20_1.Name = "_Label20_1";
			_Label20_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label20_1.Size = new System.Drawing.Size(105, 17);
			_Label20_1.TabIndex = 99;
			_Label20_1.Text = "Labor/Hour:";
			// 
			// _Label19_1
			// 
			_Label19_1.AllowDrop = true;
			_Label19_1.BackColor = System.Drawing.SystemColors.Control;
			_Label19_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label19_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label19_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label19_1.Location = new System.Drawing.Point(16, 120);
			_Label19_1.MinimumSize = new System.Drawing.Size(129, 17);
			_Label19_1.Name = "_Label19_1";
			_Label19_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label19_1.Size = new System.Drawing.Size(129, 17);
			_Label19_1.TabIndex = 98;
			_Label19_1.Text = "Maintenance:";
			// 
			// _Label18_0
			// 
			_Label18_0.AllowDrop = true;
			_Label18_0.BackColor = System.Drawing.SystemColors.Control;
			_Label18_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label18_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label18_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label18_0.Location = new System.Drawing.Point(32, 96);
			_Label18_0.MinimumSize = new System.Drawing.Size(145, 17);
			_Label18_0.Name = "_Label18_0";
			_Label18_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label18_0.Size = new System.Drawing.Size(145, 17);
			_Label18_0.TabIndex = 97;
			_Label18_0.Text = "Burn/Hour:";
			// 
			// _Label16_0
			// 
			_Label16_0.AllowDrop = true;
			_Label16_0.BackColor = System.Drawing.SystemColors.Control;
			_Label16_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_0.Location = new System.Drawing.Point(32, 72);
			_Label16_0.MinimumSize = new System.Drawing.Size(121, 17);
			_Label16_0.Name = "_Label16_0";
			_Label16_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_0.Size = new System.Drawing.Size(121, 17);
			_Label16_0.TabIndex = 96;
			_Label16_0.Text = "Additive/Gallon:";
			// 
			// _Label16_1
			// 
			_Label16_1.AllowDrop = true;
			_Label16_1.BackColor = System.Drawing.SystemColors.Control;
			_Label16_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_1.Location = new System.Drawing.Point(32, 48);
			_Label16_1.MinimumSize = new System.Drawing.Size(129, 17);
			_Label16_1.Name = "_Label16_1";
			_Label16_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_1.Size = new System.Drawing.Size(129, 17);
			_Label16_1.TabIndex = 95;
			_Label16_1.Text = "Cost/Gallon:";
			// 
			// _Label16_2
			// 
			_Label16_2.AllowDrop = true;
			_Label16_2.BackColor = System.Drawing.Color.Transparent;
			_Label16_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label16_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label16_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label16_2.Location = new System.Drawing.Point(16, 24);
			_Label16_2.MinimumSize = new System.Drawing.Size(49, 17);
			_Label16_2.Name = "_Label16_2";
			_Label16_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label16_2.Size = new System.Drawing.Size(49, 17);
			_Label16_2.TabIndex = 94;
			_Label16_2.Text = "Fuel:";
			// 
			// _Label20_2
			// 
			_Label20_2.AllowDrop = true;
			_Label20_2.BackColor = System.Drawing.SystemColors.Control;
			_Label20_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label20_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label20_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label20_2.Location = new System.Drawing.Point(16, 240);
			_Label20_2.MinimumSize = new System.Drawing.Size(105, 17);
			_Label20_2.Name = "_Label20_2";
			_Label20_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label20_2.Size = new System.Drawing.Size(105, 17);
			_Label20_2.TabIndex = 93;
			_Label20_2.Text = "Engine Overhaul:";
			// 
			// _Label20_3
			// 
			_Label20_3.AllowDrop = true;
			_Label20_3.BackColor = System.Drawing.SystemColors.Control;
			_Label20_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label20_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label20_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label20_3.Location = new System.Drawing.Point(16, 264);
			_Label20_3.MinimumSize = new System.Drawing.Size(137, 17);
			_Label20_3.Name = "_Label20_3";
			_Label20_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label20_3.Size = new System.Drawing.Size(137, 17);
			_Label20_3.TabIndex = 92;
			_Label20_3.Text = "Thrust Reverse Overhaul:";
			// 
			// _Label19_2
			// 
			_Label19_2.AllowDrop = true;
			_Label19_2.BackColor = System.Drawing.SystemColors.Control;
			_Label19_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label19_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label19_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label19_2.Location = new System.Drawing.Point(15, 288);
			_Label19_2.MinimumSize = new System.Drawing.Size(129, 17);
			_Label19_2.Name = "_Label19_2";
			_Label19_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label19_2.Size = new System.Drawing.Size(129, 17);
			_Label19_2.TabIndex = 77;
			_Label19_2.Text = "Misc. Flight Expenses:";
			// 
			// _Label28_2
			// 
			_Label28_2.AllowDrop = true;
			_Label28_2.BackColor = System.Drawing.SystemColors.Control;
			_Label28_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label28_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label28_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label28_2.Location = new System.Drawing.Point(32, 312);
			_Label28_2.MinimumSize = new System.Drawing.Size(105, 17);
			_Label28_2.Name = "_Label28_2";
			_Label28_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label28_2.Size = new System.Drawing.Size(105, 17);
			_Label28_2.TabIndex = 75;
			_Label28_2.Text = "Landing/Parking Fee:";
			// 
			// _Label28_3
			// 
			_Label28_3.AllowDrop = true;
			_Label28_3.BackColor = System.Drawing.SystemColors.Control;
			_Label28_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label28_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label28_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label28_3.Location = new System.Drawing.Point(32, 336);
			_Label28_3.MinimumSize = new System.Drawing.Size(105, 17);
			_Label28_3.Name = "_Label28_3";
			_Label28_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label28_3.Size = new System.Drawing.Size(105, 17);
			_Label28_3.TabIndex = 72;
			_Label28_3.Text = "Crew Expenses:";
			// 
			// _Label28_5
			// 
			_Label28_5.AllowDrop = true;
			_Label28_5.BackColor = System.Drawing.SystemColors.Control;
			_Label28_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label28_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label28_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label28_5.Location = new System.Drawing.Point(32, 360);
			_Label28_5.MinimumSize = new System.Drawing.Size(105, 17);
			_Label28_5.Name = "_Label28_5";
			_Label28_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label28_5.Size = new System.Drawing.Size(105, 17);
			_Label28_5.TabIndex = 70;
			_Label28_5.Text = "Supplies/Catering:";
			// 
			// _Label19_3
			// 
			_Label19_3.AllowDrop = true;
			_Label19_3.BackColor = System.Drawing.SystemColors.Control;
			_Label19_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label19_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label19_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label19_3.Location = new System.Drawing.Point(16, 384);
			_Label19_3.MinimumSize = new System.Drawing.Size(129, 17);
			_Label19_3.Name = "_Label19_3";
			_Label19_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label19_3.Size = new System.Drawing.Size(129, 17);
			_Label19_3.TabIndex = 68;
			_Label19_3.Text = "Total Direct Costs:";
			// 
			// _Label28_7
			// 
			_Label28_7.AllowDrop = true;
			_Label28_7.BackColor = System.Drawing.SystemColors.Control;
			_Label28_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label28_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label28_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label28_7.Location = new System.Drawing.Point(16, 408);
			_Label28_7.MinimumSize = new System.Drawing.Size(161, 17);
			_Label28_7.Name = "_Label28_7";
			_Label28_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label28_7.Size = new System.Drawing.Size(161, 17);
			_Label28_7.TabIndex = 66;
			_Label28_7.Text = "Block Speed Statute MPH";
			// 
			// _Label28_8
			// 
			_Label28_8.AllowDrop = true;
			_Label28_8.BackColor = System.Drawing.SystemColors.Control;
			_Label28_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label28_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label28_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label28_8.Location = new System.Drawing.Point(16, 432);
			_Label28_8.MinimumSize = new System.Drawing.Size(161, 17);
			_Label28_8.Name = "_Label28_8";
			_Label28_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label28_8.Size = new System.Drawing.Size(161, 17);
			_Label28_8.TabIndex = 64;
			_Label28_8.Text = "Total Cost/Statute Mile:";
			// 
			// _tab_Aircraft_Model_TabPage5
			// 
			_tab_Aircraft_Model_TabPage5.Controls.Add(pnl_Rotors);
			_tab_Aircraft_Model_TabPage5.Controls.Add(pnl_Climb);
			_tab_Aircraft_Model_TabPage5.Controls.Add(pnl_Speed);
			_tab_Aircraft_Model_TabPage5.Controls.Add(pnl_OtherSpecs);
			_tab_Aircraft_Model_TabPage5.Controls.Add(pnl_Props);
			_tab_Aircraft_Model_TabPage5.Controls.Add(pnl_FuselageDimensions);
			_tab_Aircraft_Model_TabPage5.Controls.Add(pnl_Config);
			_tab_Aircraft_Model_TabPage5.Controls.Add(pnl_Weight);
			_tab_Aircraft_Model_TabPage5.Controls.Add(pnl_FuelCapacity);
			_tab_Aircraft_Model_TabPage5.Controls.Add(pnl_EngineData);
			_tab_Aircraft_Model_TabPage5.Controls.Add(pnl_ConfigNote);
			_tab_Aircraft_Model_TabPage5.Controls.Add(pnl_Aircraft_Model_Engine_Add);
			_tab_Aircraft_Model_TabPage5.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage5.Text = "Specs";
			// 
			// pnl_Rotors
			// 
			pnl_Rotors.AllowDrop = true;
			pnl_Rotors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Rotors.Controls.Add(pnlCabinDimension);
			pnl_Rotors.Controls.Add(txt_amod_main_rotor_1_blade_count);
			pnl_Rotors.Controls.Add(txt_amod_main_rotor_1_blade_diameter);
			pnl_Rotors.Controls.Add(txt_amod_main_rotor_2_blade_count);
			pnl_Rotors.Controls.Add(txt_amod_main_rotor_2_blade_diameter);
			pnl_Rotors.Controls.Add(txt_amod_tail_rotor_blade_count);
			pnl_Rotors.Controls.Add(txt_amod_tail_rotor_blade_diameter);
			pnl_Rotors.Controls.Add(cmb_amod_rotor_anti_torque_system);
			pnl_Rotors.Controls.Add(_lbl_specs_38);
			pnl_Rotors.Controls.Add(_lbl_specs_39);
			pnl_Rotors.Controls.Add(_lbl_specs_48);
			pnl_Rotors.Controls.Add(_lbl_specs_49);
			pnl_Rotors.Controls.Add(_lbl_specs_54);
			pnl_Rotors.Controls.Add(_lbl_specs_56);
			pnl_Rotors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Rotors.Location = new System.Drawing.Point(276, 130);
			pnl_Rotors.Name = "pnl_Rotors";
			pnl_Rotors.Size = new System.Drawing.Size(281, 152);
			pnl_Rotors.TabIndex = 289;
			// 
			// pnlCabinDimension
			// 
			pnlCabinDimension.AllowDrop = true;
			pnlCabinDimension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlCabinDimension.Controls.Add(_txt_amod_fuselage_length_9);
			pnlCabinDimension.Controls.Add(_txt_amod_fuselage_length_8);
			pnlCabinDimension.Controls.Add(_txt_amod_fuselage_length_6);
			pnlCabinDimension.Controls.Add(_txt_amod_fuselage_length_5);
			pnlCabinDimension.Controls.Add(_txt_amod_fuselage_length_4);
			pnlCabinDimension.Controls.Add(_txt_amod_fuselage_length_3);
			pnlCabinDimension.Controls.Add(_txt_amod_fuselage_length_2);
			pnlCabinDimension.Controls.Add(_txt_amod_fuselage_length_1);
			pnlCabinDimension.Controls.Add(_lbl_specs_86);
			pnlCabinDimension.Controls.Add(_lbl_specs_85);
			pnlCabinDimension.Controls.Add(_lbl_specs_84);
			pnlCabinDimension.Controls.Add(_lbl_specs_83);
			pnlCabinDimension.Controls.Add(_lbl_specs_82);
			pnlCabinDimension.Controls.Add(_lbl_specs_81);
			pnlCabinDimension.Controls.Add(_lbl_specs_80);
			pnlCabinDimension.Controls.Add(_lbl_specs_79);
			pnlCabinDimension.Controls.Add(_lbl_specs_78);
			pnlCabinDimension.Controls.Add(_lbl_specs_76);
			pnlCabinDimension.Controls.Add(_lbl_specs_75);
			pnlCabinDimension.Controls.Add(_lbl_specs_74);
			pnlCabinDimension.Controls.Add(_lbl_specs_69);
			pnlCabinDimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlCabinDimension.Location = new System.Drawing.Point(0, 0);
			pnlCabinDimension.Name = "pnlCabinDimension";
			pnlCabinDimension.Size = new System.Drawing.Size(281, 152);
			pnlCabinDimension.TabIndex = 398;
			pnlCabinDimension.Visible = false;
			// 
			// _txt_amod_fuselage_length_9
			// 
			_txt_amod_fuselage_length_9.AcceptsReturn = true;
			_txt_amod_fuselage_length_9.AllowDrop = true;
			_txt_amod_fuselage_length_9.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_fuselage_length_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_fuselage_length_9.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_fuselage_length_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_fuselage_length_9.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_fuselage_length_9.Location = new System.Drawing.Point(146, 118);
			_txt_amod_fuselage_length_9.MaxLength = 0;
			_txt_amod_fuselage_length_9.Name = "_txt_amod_fuselage_length_9";
			_txt_amod_fuselage_length_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_fuselage_length_9.Size = new System.Drawing.Size(49, 19);
			_txt_amod_fuselage_length_9.TabIndex = 407;
			_txt_amod_fuselage_length_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_amod_fuselage_length_9.Leave += new System.EventHandler(txt_amod_fuselage_length_Leave);
			// 
			// _txt_amod_fuselage_length_8
			// 
			_txt_amod_fuselage_length_8.AcceptsReturn = true;
			_txt_amod_fuselage_length_8.AllowDrop = true;
			_txt_amod_fuselage_length_8.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_fuselage_length_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_fuselage_length_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_fuselage_length_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_fuselage_length_8.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_fuselage_length_8.Location = new System.Drawing.Point(146, 94);
			_txt_amod_fuselage_length_8.MaxLength = 0;
			_txt_amod_fuselage_length_8.Name = "_txt_amod_fuselage_length_8";
			_txt_amod_fuselage_length_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_fuselage_length_8.Size = new System.Drawing.Size(49, 19);
			_txt_amod_fuselage_length_8.TabIndex = 406;
			_txt_amod_fuselage_length_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_amod_fuselage_length_8.Leave += new System.EventHandler(txt_amod_fuselage_length_Leave);
			// 
			// _txt_amod_fuselage_length_6
			// 
			_txt_amod_fuselage_length_6.AcceptsReturn = true;
			_txt_amod_fuselage_length_6.AllowDrop = true;
			_txt_amod_fuselage_length_6.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_fuselage_length_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_fuselage_length_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_fuselage_length_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_fuselage_length_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_fuselage_length_6.Location = new System.Drawing.Point(147, 66);
			_txt_amod_fuselage_length_6.MaxLength = 0;
			_txt_amod_fuselage_length_6.Name = "_txt_amod_fuselage_length_6";
			_txt_amod_fuselage_length_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_fuselage_length_6.Size = new System.Drawing.Size(49, 19);
			_txt_amod_fuselage_length_6.TabIndex = 405;
			_txt_amod_fuselage_length_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_amod_fuselage_length_6.Leave += new System.EventHandler(txt_amod_fuselage_length_Leave);
			// 
			// _txt_amod_fuselage_length_5
			// 
			_txt_amod_fuselage_length_5.AcceptsReturn = true;
			_txt_amod_fuselage_length_5.AllowDrop = true;
			_txt_amod_fuselage_length_5.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_fuselage_length_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_fuselage_length_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_fuselage_length_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_fuselage_length_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_fuselage_length_5.Location = new System.Drawing.Point(76, 66);
			_txt_amod_fuselage_length_5.MaxLength = 0;
			_txt_amod_fuselage_length_5.Name = "_txt_amod_fuselage_length_5";
			_txt_amod_fuselage_length_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_fuselage_length_5.Size = new System.Drawing.Size(49, 19);
			_txt_amod_fuselage_length_5.TabIndex = 404;
			_txt_amod_fuselage_length_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_amod_fuselage_length_5.Leave += new System.EventHandler(txt_amod_fuselage_length_Leave);
			// 
			// _txt_amod_fuselage_length_4
			// 
			_txt_amod_fuselage_length_4.AcceptsReturn = true;
			_txt_amod_fuselage_length_4.AllowDrop = true;
			_txt_amod_fuselage_length_4.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_fuselage_length_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_fuselage_length_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_fuselage_length_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_fuselage_length_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_fuselage_length_4.Location = new System.Drawing.Point(147, 42);
			_txt_amod_fuselage_length_4.MaxLength = 0;
			_txt_amod_fuselage_length_4.Name = "_txt_amod_fuselage_length_4";
			_txt_amod_fuselage_length_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_fuselage_length_4.Size = new System.Drawing.Size(49, 19);
			_txt_amod_fuselage_length_4.TabIndex = 403;
			_txt_amod_fuselage_length_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_amod_fuselage_length_4.Leave += new System.EventHandler(txt_amod_fuselage_length_Leave);
			// 
			// _txt_amod_fuselage_length_3
			// 
			_txt_amod_fuselage_length_3.AcceptsReturn = true;
			_txt_amod_fuselage_length_3.AllowDrop = true;
			_txt_amod_fuselage_length_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_fuselage_length_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_fuselage_length_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_fuselage_length_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_fuselage_length_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_fuselage_length_3.Location = new System.Drawing.Point(76, 41);
			_txt_amod_fuselage_length_3.MaxLength = 0;
			_txt_amod_fuselage_length_3.Name = "_txt_amod_fuselage_length_3";
			_txt_amod_fuselage_length_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_fuselage_length_3.Size = new System.Drawing.Size(49, 19);
			_txt_amod_fuselage_length_3.TabIndex = 402;
			_txt_amod_fuselage_length_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_amod_fuselage_length_3.Leave += new System.EventHandler(txt_amod_fuselage_length_Leave);
			// 
			// _txt_amod_fuselage_length_2
			// 
			_txt_amod_fuselage_length_2.AcceptsReturn = true;
			_txt_amod_fuselage_length_2.AllowDrop = true;
			_txt_amod_fuselage_length_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_fuselage_length_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_fuselage_length_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_fuselage_length_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_fuselage_length_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_fuselage_length_2.Location = new System.Drawing.Point(145, 17);
			_txt_amod_fuselage_length_2.MaxLength = 0;
			_txt_amod_fuselage_length_2.Name = "_txt_amod_fuselage_length_2";
			_txt_amod_fuselage_length_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_fuselage_length_2.Size = new System.Drawing.Size(49, 19);
			_txt_amod_fuselage_length_2.TabIndex = 401;
			_txt_amod_fuselage_length_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_amod_fuselage_length_2.Leave += new System.EventHandler(txt_amod_fuselage_length_Leave);
			// 
			// _txt_amod_fuselage_length_1
			// 
			_txt_amod_fuselage_length_1.AcceptsReturn = true;
			_txt_amod_fuselage_length_1.AllowDrop = true;
			_txt_amod_fuselage_length_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_fuselage_length_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_fuselage_length_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_fuselage_length_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_fuselage_length_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_fuselage_length_1.Location = new System.Drawing.Point(77, 18);
			_txt_amod_fuselage_length_1.MaxLength = 0;
			_txt_amod_fuselage_length_1.Name = "_txt_amod_fuselage_length_1";
			_txt_amod_fuselage_length_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_fuselage_length_1.Size = new System.Drawing.Size(49, 19);
			_txt_amod_fuselage_length_1.TabIndex = 400;
			_txt_amod_fuselage_length_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_amod_fuselage_length_1.Leave += new System.EventHandler(txt_amod_fuselage_length_Leave);
			// 
			// _lbl_specs_86
			// 
			_lbl_specs_86.AllowDrop = true;
			_lbl_specs_86.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_86.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_86.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_86.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_86.Location = new System.Drawing.Point(40, 120);
			_lbl_specs_86.MinimumSize = new System.Drawing.Size(85, 17);
			_lbl_specs_86.Name = "_lbl_specs_86";
			_lbl_specs_86.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_86.Size = new System.Drawing.Size(85, 17);
			_lbl_specs_86.TabIndex = 440;
			_lbl_specs_86.Text = "Baggage Volume";
			_lbl_specs_86.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_86.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_85
			// 
			_lbl_specs_85.AllowDrop = true;
			_lbl_specs_85.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_85.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_85.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_85.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_85.Location = new System.Drawing.Point(201, 120);
			_lbl_specs_85.MinimumSize = new System.Drawing.Size(56, 17);
			_lbl_specs_85.Name = "_lbl_specs_85";
			_lbl_specs_85.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_85.Size = new System.Drawing.Size(56, 17);
			_lbl_specs_85.TabIndex = 439;
			_lbl_specs_85.Text = "cubic feet";
			_lbl_specs_85.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_85.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_84
			// 
			_lbl_specs_84.AllowDrop = true;
			_lbl_specs_84.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_84.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_84.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_84.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_84.Location = new System.Drawing.Point(40, 96);
			_lbl_specs_84.MinimumSize = new System.Drawing.Size(69, 17);
			_lbl_specs_84.Name = "_lbl_specs_84";
			_lbl_specs_84.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_84.Size = new System.Drawing.Size(69, 17);
			_lbl_specs_84.TabIndex = 438;
			_lbl_specs_84.Text = "Cabin Volume";
			_lbl_specs_84.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_84.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_83
			// 
			_lbl_specs_83.AllowDrop = true;
			_lbl_specs_83.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_83.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_83.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_83.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_83.Location = new System.Drawing.Point(201, 96);
			_lbl_specs_83.MinimumSize = new System.Drawing.Size(56, 17);
			_lbl_specs_83.Name = "_lbl_specs_83";
			_lbl_specs_83.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_83.Size = new System.Drawing.Size(56, 17);
			_lbl_specs_83.TabIndex = 437;
			_lbl_specs_83.Text = "cubic feet";
			_lbl_specs_83.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_83.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_82
			// 
			_lbl_specs_82.AllowDrop = true;
			_lbl_specs_82.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_82.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_82.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_82.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_82.Location = new System.Drawing.Point(199, 67);
			_lbl_specs_82.MinimumSize = new System.Drawing.Size(14, 17);
			_lbl_specs_82.Name = "_lbl_specs_82";
			_lbl_specs_82.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_82.Size = new System.Drawing.Size(14, 17);
			_lbl_specs_82.TabIndex = 416;
			_lbl_specs_82.Text = "in:";
			_lbl_specs_82.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_82.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_81
			// 
			_lbl_specs_81.AllowDrop = true;
			_lbl_specs_81.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_81.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_81.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_81.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_81.Location = new System.Drawing.Point(198, 46);
			_lbl_specs_81.MinimumSize = new System.Drawing.Size(14, 17);
			_lbl_specs_81.Name = "_lbl_specs_81";
			_lbl_specs_81.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_81.Size = new System.Drawing.Size(14, 17);
			_lbl_specs_81.TabIndex = 415;
			_lbl_specs_81.Text = "in:";
			_lbl_specs_81.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_81.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_80
			// 
			_lbl_specs_80.AllowDrop = true;
			_lbl_specs_80.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_80.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_80.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_80.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_80.Location = new System.Drawing.Point(198, 20);
			_lbl_specs_80.MinimumSize = new System.Drawing.Size(14, 17);
			_lbl_specs_80.Name = "_lbl_specs_80";
			_lbl_specs_80.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_80.Size = new System.Drawing.Size(14, 17);
			_lbl_specs_80.TabIndex = 414;
			_lbl_specs_80.Text = "in:";
			_lbl_specs_80.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_80.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_79
			// 
			_lbl_specs_79.AllowDrop = true;
			_lbl_specs_79.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_79.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_79.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_79.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_79.Location = new System.Drawing.Point(127, 68);
			_lbl_specs_79.MinimumSize = new System.Drawing.Size(14, 17);
			_lbl_specs_79.Name = "_lbl_specs_79";
			_lbl_specs_79.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_79.Size = new System.Drawing.Size(14, 17);
			_lbl_specs_79.TabIndex = 413;
			_lbl_specs_79.Text = "ft:";
			_lbl_specs_79.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_79.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_78
			// 
			_lbl_specs_78.AllowDrop = true;
			_lbl_specs_78.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_78.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_78.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_78.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_78.Location = new System.Drawing.Point(126, 44);
			_lbl_specs_78.MinimumSize = new System.Drawing.Size(14, 17);
			_lbl_specs_78.Name = "_lbl_specs_78";
			_lbl_specs_78.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_78.Size = new System.Drawing.Size(14, 17);
			_lbl_specs_78.TabIndex = 412;
			_lbl_specs_78.Text = "ft:";
			_lbl_specs_78.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_78.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_76
			// 
			_lbl_specs_76.AllowDrop = true;
			_lbl_specs_76.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_76.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_76.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_76.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_76.Location = new System.Drawing.Point(127, 19);
			_lbl_specs_76.MinimumSize = new System.Drawing.Size(14, 17);
			_lbl_specs_76.Name = "_lbl_specs_76";
			_lbl_specs_76.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_76.Size = new System.Drawing.Size(14, 17);
			_lbl_specs_76.TabIndex = 410;
			_lbl_specs_76.Text = "ft:";
			_lbl_specs_76.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_76.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_75
			// 
			_lbl_specs_75.AllowDrop = true;
			_lbl_specs_75.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_75.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_75.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_75.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_75.Location = new System.Drawing.Point(40, 68);
			_lbl_specs_75.MinimumSize = new System.Drawing.Size(33, 17);
			_lbl_specs_75.Name = "_lbl_specs_75";
			_lbl_specs_75.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_75.Size = new System.Drawing.Size(33, 17);
			_lbl_specs_75.TabIndex = 409;
			_lbl_specs_75.Text = "Width:";
			_lbl_specs_75.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_75.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_74
			// 
			_lbl_specs_74.AllowDrop = true;
			_lbl_specs_74.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_74.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_74.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_74.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_74.Location = new System.Drawing.Point(37, 41);
			_lbl_specs_74.MinimumSize = new System.Drawing.Size(35, 17);
			_lbl_specs_74.Name = "_lbl_specs_74";
			_lbl_specs_74.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_74.Size = new System.Drawing.Size(35, 17);
			_lbl_specs_74.TabIndex = 408;
			_lbl_specs_74.Text = "Length:";
			_lbl_specs_74.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_74.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_69
			// 
			_lbl_specs_69.AllowDrop = true;
			_lbl_specs_69.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_69.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_69.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_69.Location = new System.Drawing.Point(39, 18);
			_lbl_specs_69.MinimumSize = new System.Drawing.Size(33, 17);
			_lbl_specs_69.Name = "_lbl_specs_69";
			_lbl_specs_69.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_69.Size = new System.Drawing.Size(33, 17);
			_lbl_specs_69.TabIndex = 399;
			_lbl_specs_69.Text = "Height:";
			_lbl_specs_69.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_69.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// txt_amod_main_rotor_1_blade_count
			// 
			txt_amod_main_rotor_1_blade_count.AcceptsReturn = true;
			txt_amod_main_rotor_1_blade_count.AllowDrop = true;
			txt_amod_main_rotor_1_blade_count.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_main_rotor_1_blade_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_main_rotor_1_blade_count.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_main_rotor_1_blade_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_main_rotor_1_blade_count.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_main_rotor_1_blade_count.Location = new System.Drawing.Point(87, 47);
			txt_amod_main_rotor_1_blade_count.MaxLength = 0;
			txt_amod_main_rotor_1_blade_count.Name = "txt_amod_main_rotor_1_blade_count";
			txt_amod_main_rotor_1_blade_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_main_rotor_1_blade_count.Size = new System.Drawing.Size(46, 22);
			txt_amod_main_rotor_1_blade_count.TabIndex = 296;
			txt_amod_main_rotor_1_blade_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_main_rotor_1_blade_diameter
			// 
			txt_amod_main_rotor_1_blade_diameter.AcceptsReturn = true;
			txt_amod_main_rotor_1_blade_diameter.AllowDrop = true;
			txt_amod_main_rotor_1_blade_diameter.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_main_rotor_1_blade_diameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_main_rotor_1_blade_diameter.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_main_rotor_1_blade_diameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_main_rotor_1_blade_diameter.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_main_rotor_1_blade_diameter.Location = new System.Drawing.Point(148, 47);
			txt_amod_main_rotor_1_blade_diameter.MaxLength = 0;
			txt_amod_main_rotor_1_blade_diameter.Name = "txt_amod_main_rotor_1_blade_diameter";
			txt_amod_main_rotor_1_blade_diameter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_main_rotor_1_blade_diameter.Size = new System.Drawing.Size(47, 22);
			txt_amod_main_rotor_1_blade_diameter.TabIndex = 295;
			txt_amod_main_rotor_1_blade_diameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_main_rotor_2_blade_count
			// 
			txt_amod_main_rotor_2_blade_count.AcceptsReturn = true;
			txt_amod_main_rotor_2_blade_count.AllowDrop = true;
			txt_amod_main_rotor_2_blade_count.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_main_rotor_2_blade_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_main_rotor_2_blade_count.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_main_rotor_2_blade_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_main_rotor_2_blade_count.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_main_rotor_2_blade_count.Location = new System.Drawing.Point(87, 72);
			txt_amod_main_rotor_2_blade_count.MaxLength = 0;
			txt_amod_main_rotor_2_blade_count.Name = "txt_amod_main_rotor_2_blade_count";
			txt_amod_main_rotor_2_blade_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_main_rotor_2_blade_count.Size = new System.Drawing.Size(46, 22);
			txt_amod_main_rotor_2_blade_count.TabIndex = 294;
			txt_amod_main_rotor_2_blade_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_main_rotor_2_blade_diameter
			// 
			txt_amod_main_rotor_2_blade_diameter.AcceptsReturn = true;
			txt_amod_main_rotor_2_blade_diameter.AllowDrop = true;
			txt_amod_main_rotor_2_blade_diameter.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_main_rotor_2_blade_diameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_main_rotor_2_blade_diameter.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_main_rotor_2_blade_diameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_main_rotor_2_blade_diameter.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_main_rotor_2_blade_diameter.Location = new System.Drawing.Point(148, 72);
			txt_amod_main_rotor_2_blade_diameter.MaxLength = 0;
			txt_amod_main_rotor_2_blade_diameter.Name = "txt_amod_main_rotor_2_blade_diameter";
			txt_amod_main_rotor_2_blade_diameter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_main_rotor_2_blade_diameter.Size = new System.Drawing.Size(47, 22);
			txt_amod_main_rotor_2_blade_diameter.TabIndex = 293;
			txt_amod_main_rotor_2_blade_diameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_tail_rotor_blade_count
			// 
			txt_amod_tail_rotor_blade_count.AcceptsReturn = true;
			txt_amod_tail_rotor_blade_count.AllowDrop = true;
			txt_amod_tail_rotor_blade_count.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_tail_rotor_blade_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tail_rotor_blade_count.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tail_rotor_blade_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tail_rotor_blade_count.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tail_rotor_blade_count.Location = new System.Drawing.Point(87, 96);
			txt_amod_tail_rotor_blade_count.MaxLength = 0;
			txt_amod_tail_rotor_blade_count.Name = "txt_amod_tail_rotor_blade_count";
			txt_amod_tail_rotor_blade_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tail_rotor_blade_count.Size = new System.Drawing.Size(46, 22);
			txt_amod_tail_rotor_blade_count.TabIndex = 292;
			txt_amod_tail_rotor_blade_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_tail_rotor_blade_diameter
			// 
			txt_amod_tail_rotor_blade_diameter.AcceptsReturn = true;
			txt_amod_tail_rotor_blade_diameter.AllowDrop = true;
			txt_amod_tail_rotor_blade_diameter.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_tail_rotor_blade_diameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_tail_rotor_blade_diameter.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_tail_rotor_blade_diameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_tail_rotor_blade_diameter.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_tail_rotor_blade_diameter.Location = new System.Drawing.Point(148, 96);
			txt_amod_tail_rotor_blade_diameter.MaxLength = 0;
			txt_amod_tail_rotor_blade_diameter.Name = "txt_amod_tail_rotor_blade_diameter";
			txt_amod_tail_rotor_blade_diameter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_tail_rotor_blade_diameter.Size = new System.Drawing.Size(47, 22);
			txt_amod_tail_rotor_blade_diameter.TabIndex = 291;
			txt_amod_tail_rotor_blade_diameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmb_amod_rotor_anti_torque_system
			// 
			cmb_amod_rotor_anti_torque_system.AllowDrop = true;
			cmb_amod_rotor_anti_torque_system.BackColor = System.Drawing.SystemColors.Window;
			cmb_amod_rotor_anti_torque_system.CausesValidation = true;
			cmb_amod_rotor_anti_torque_system.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmb_amod_rotor_anti_torque_system.Enabled = true;
			cmb_amod_rotor_anti_torque_system.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_amod_rotor_anti_torque_system.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_amod_rotor_anti_torque_system.IntegralHeight = true;
			cmb_amod_rotor_anti_torque_system.Location = new System.Drawing.Point(119, 125);
			cmb_amod_rotor_anti_torque_system.Name = "cmb_amod_rotor_anti_torque_system";
			cmb_amod_rotor_anti_torque_system.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_amod_rotor_anti_torque_system.Size = new System.Drawing.Size(137, 21);
			cmb_amod_rotor_anti_torque_system.Sorted = false;
			cmb_amod_rotor_anti_torque_system.TabIndex = 290;
			cmb_amod_rotor_anti_torque_system.TabStop = true;
			cmb_amod_rotor_anti_torque_system.Visible = true;
			cmb_amod_rotor_anti_torque_system.SelectionChangeCommitted += new System.EventHandler(cmb_amod_rotor_anti_torque_system_SelectionChangeCommitted);
			// 
			// _lbl_specs_38
			// 
			_lbl_specs_38.AllowDrop = true;
			_lbl_specs_38.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_38.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_38.Location = new System.Drawing.Point(9, 50);
			_lbl_specs_38.MinimumSize = new System.Drawing.Size(81, 17);
			_lbl_specs_38.Name = "_lbl_specs_38";
			_lbl_specs_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_38.Size = new System.Drawing.Size(81, 17);
			_lbl_specs_38.TabIndex = 302;
			_lbl_specs_38.Text = "Main Rotor #1:";
			_lbl_specs_38.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_38.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_39
			// 
			_lbl_specs_39.AllowDrop = true;
			_lbl_specs_39.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_39.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_39.Location = new System.Drawing.Point(85, 21);
			_lbl_specs_39.MinimumSize = new System.Drawing.Size(59, 29);
			_lbl_specs_39.Name = "_lbl_specs_39";
			_lbl_specs_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_39.Size = new System.Drawing.Size(59, 29);
			_lbl_specs_39.TabIndex = 301;
			_lbl_specs_39.Text = "Number of Blades";
			_lbl_specs_39.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_39.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_48
			// 
			_lbl_specs_48.AllowDrop = true;
			_lbl_specs_48.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_48.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_48.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_48.Location = new System.Drawing.Point(9, 99);
			_lbl_specs_48.MinimumSize = new System.Drawing.Size(59, 17);
			_lbl_specs_48.Name = "_lbl_specs_48";
			_lbl_specs_48.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_48.Size = new System.Drawing.Size(59, 17);
			_lbl_specs_48.TabIndex = 300;
			_lbl_specs_48.Text = "Tail Rotor:";
			_lbl_specs_48.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_48.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_49
			// 
			_lbl_specs_49.AllowDrop = true;
			_lbl_specs_49.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_49.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_49.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_49.Location = new System.Drawing.Point(149, 21);
			_lbl_specs_49.MinimumSize = new System.Drawing.Size(52, 28);
			_lbl_specs_49.Name = "_lbl_specs_49";
			_lbl_specs_49.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_49.Size = new System.Drawing.Size(52, 28);
			_lbl_specs_49.TabIndex = 299;
			_lbl_specs_49.Text = "Blade Diameter";
			_lbl_specs_49.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_49.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_54
			// 
			_lbl_specs_54.AllowDrop = true;
			_lbl_specs_54.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_54.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_54.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_54.Location = new System.Drawing.Point(8, 75);
			_lbl_specs_54.MinimumSize = new System.Drawing.Size(82, 17);
			_lbl_specs_54.Name = "_lbl_specs_54";
			_lbl_specs_54.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_54.Size = new System.Drawing.Size(82, 17);
			_lbl_specs_54.TabIndex = 298;
			_lbl_specs_54.Text = "Main Rotor #2:";
			_lbl_specs_54.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_54.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_56
			// 
			_lbl_specs_56.AllowDrop = true;
			_lbl_specs_56.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_56.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_56.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_56.Location = new System.Drawing.Point(10, 129);
			_lbl_specs_56.MinimumSize = new System.Drawing.Size(102, 17);
			_lbl_specs_56.Name = "_lbl_specs_56";
			_lbl_specs_56.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_56.Size = new System.Drawing.Size(102, 17);
			_lbl_specs_56.TabIndex = 297;
			_lbl_specs_56.Text = "Anti Torque System:";
			_lbl_specs_56.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_56.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// pnl_Climb
			// 
			pnl_Climb.AllowDrop = true;
			pnl_Climb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Climb.Controls.Add(txt_amod_climb_engout_feet);
			pnl_Climb.Controls.Add(txt_amod_climb_normal_feet);
			pnl_Climb.Controls.Add(txt_amod_ceiling_feet);
			pnl_Climb.Controls.Add(txt_amod_climb_hoge);
			pnl_Climb.Controls.Add(txt_amod_climb_hige);
			pnl_Climb.Controls.Add(_lbl_specs_14);
			pnl_Climb.Controls.Add(_lbl_specs_13);
			pnl_Climb.Controls.Add(_lbl_specs_59);
			pnl_Climb.Controls.Add(_lbl_specs_62);
			pnl_Climb.Controls.Add(_lbl_specs_61);
			pnl_Climb.Controls.Add(_lbl_specs_60);
			pnl_Climb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Climb.Location = new System.Drawing.Point(734, 6);
			pnl_Climb.Name = "pnl_Climb";
			pnl_Climb.Size = new System.Drawing.Size(238, 85);
			pnl_Climb.TabIndex = 350;
			// 
			// txt_amod_climb_engout_feet
			// 
			txt_amod_climb_engout_feet.AcceptsReturn = true;
			txt_amod_climb_engout_feet.AllowDrop = true;
			txt_amod_climb_engout_feet.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_climb_engout_feet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_climb_engout_feet.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_climb_engout_feet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_climb_engout_feet.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_climb_engout_feet.Location = new System.Drawing.Point(84, 39);
			txt_amod_climb_engout_feet.MaxLength = 0;
			txt_amod_climb_engout_feet.Name = "txt_amod_climb_engout_feet";
			txt_amod_climb_engout_feet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_climb_engout_feet.Size = new System.Drawing.Size(49, 19);
			txt_amod_climb_engout_feet.TabIndex = 355;
			txt_amod_climb_engout_feet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_climb_normal_feet
			// 
			txt_amod_climb_normal_feet.AcceptsReturn = true;
			txt_amod_climb_normal_feet.AllowDrop = true;
			txt_amod_climb_normal_feet.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_climb_normal_feet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_climb_normal_feet.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_climb_normal_feet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_climb_normal_feet.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_climb_normal_feet.Location = new System.Drawing.Point(84, 17);
			txt_amod_climb_normal_feet.MaxLength = 0;
			txt_amod_climb_normal_feet.Name = "txt_amod_climb_normal_feet";
			txt_amod_climb_normal_feet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_climb_normal_feet.Size = new System.Drawing.Size(49, 19);
			txt_amod_climb_normal_feet.TabIndex = 354;
			txt_amod_climb_normal_feet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_ceiling_feet
			// 
			txt_amod_ceiling_feet.AcceptsReturn = true;
			txt_amod_ceiling_feet.AllowDrop = true;
			txt_amod_ceiling_feet.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_ceiling_feet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_ceiling_feet.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_ceiling_feet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_ceiling_feet.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_ceiling_feet.Location = new System.Drawing.Point(84, 60);
			txt_amod_ceiling_feet.MaxLength = 0;
			txt_amod_ceiling_feet.Name = "txt_amod_ceiling_feet";
			txt_amod_ceiling_feet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_ceiling_feet.Size = new System.Drawing.Size(49, 19);
			txt_amod_ceiling_feet.TabIndex = 353;
			txt_amod_ceiling_feet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_climb_hoge
			// 
			txt_amod_climb_hoge.AcceptsReturn = true;
			txt_amod_climb_hoge.AllowDrop = true;
			txt_amod_climb_hoge.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_climb_hoge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_climb_hoge.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_climb_hoge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_climb_hoge.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_climb_hoge.Location = new System.Drawing.Point(173, 32);
			txt_amod_climb_hoge.MaxLength = 0;
			txt_amod_climb_hoge.Name = "txt_amod_climb_hoge";
			txt_amod_climb_hoge.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_climb_hoge.Size = new System.Drawing.Size(58, 20);
			txt_amod_climb_hoge.TabIndex = 352;
			txt_amod_climb_hoge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_climb_hige
			// 
			txt_amod_climb_hige.AcceptsReturn = true;
			txt_amod_climb_hige.AllowDrop = true;
			txt_amod_climb_hige.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_climb_hige.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_climb_hige.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_climb_hige.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_climb_hige.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_climb_hige.Location = new System.Drawing.Point(173, 55);
			txt_amod_climb_hige.MaxLength = 0;
			txt_amod_climb_hige.Name = "txt_amod_climb_hige";
			txt_amod_climb_hige.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_climb_hige.Size = new System.Drawing.Size(58, 20);
			txt_amod_climb_hige.TabIndex = 351;
			txt_amod_climb_hige.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _lbl_specs_14
			// 
			_lbl_specs_14.AllowDrop = true;
			_lbl_specs_14.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_14.Location = new System.Drawing.Point(3, 39);
			_lbl_specs_14.MinimumSize = new System.Drawing.Size(86, 17);
			_lbl_specs_14.Name = "_lbl_specs_14";
			_lbl_specs_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_14.Size = new System.Drawing.Size(86, 17);
			_lbl_specs_14.TabIndex = 361;
			_lbl_specs_14.Text = "Engine Out (fpm):";
			_lbl_specs_14.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_14.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_13
			// 
			_lbl_specs_13.AllowDrop = true;
			_lbl_specs_13.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_13.Location = new System.Drawing.Point(3, 19);
			_lbl_specs_13.MinimumSize = new System.Drawing.Size(65, 17);
			_lbl_specs_13.Name = "_lbl_specs_13";
			_lbl_specs_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_13.Size = new System.Drawing.Size(65, 17);
			_lbl_specs_13.TabIndex = 360;
			_lbl_specs_13.Text = "Normal (fpm):";
			_lbl_specs_13.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_13.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_59
			// 
			_lbl_specs_59.AllowDrop = true;
			_lbl_specs_59.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_59.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_59.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_59.Location = new System.Drawing.Point(3, 60);
			_lbl_specs_59.MinimumSize = new System.Drawing.Size(60, 17);
			_lbl_specs_59.Name = "_lbl_specs_59";
			_lbl_specs_59.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_59.Size = new System.Drawing.Size(60, 17);
			_lbl_specs_59.TabIndex = 359;
			_lbl_specs_59.Text = "Ceiling:";
			_lbl_specs_59.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_59.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_62
			// 
			_lbl_specs_62.AllowDrop = true;
			_lbl_specs_62.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_62.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_62.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_62.Location = new System.Drawing.Point(135, 15);
			_lbl_specs_62.MinimumSize = new System.Drawing.Size(99, 20);
			_lbl_specs_62.Name = "_lbl_specs_62";
			_lbl_specs_62.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_62.Size = new System.Drawing.Size(99, 20);
			_lbl_specs_62.TabIndex = 358;
			_lbl_specs_62.Text = "Hover Ground Effect";
			_lbl_specs_62.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_62.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_61
			// 
			_lbl_specs_61.AllowDrop = true;
			_lbl_specs_61.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_61.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_61.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_61.Location = new System.Drawing.Point(136, 36);
			_lbl_specs_61.MinimumSize = new System.Drawing.Size(33, 14);
			_lbl_specs_61.Name = "_lbl_specs_61";
			_lbl_specs_61.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_61.Size = new System.Drawing.Size(33, 14);
			_lbl_specs_61.TabIndex = 357;
			_lbl_specs_61.Text = "HOGE ";
			_lbl_specs_61.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_61.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_60
			// 
			_lbl_specs_60.AllowDrop = true;
			_lbl_specs_60.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_60.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_60.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_60.Location = new System.Drawing.Point(138, 58);
			_lbl_specs_60.MinimumSize = new System.Drawing.Size(31, 14);
			_lbl_specs_60.Name = "_lbl_specs_60";
			_lbl_specs_60.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_60.Size = new System.Drawing.Size(31, 14);
			_lbl_specs_60.TabIndex = 356;
			_lbl_specs_60.Text = "HIGE";
			_lbl_specs_60.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_60.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// pnl_Speed
			// 
			pnl_Speed.AllowDrop = true;
			pnl_Speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Speed.Controls.Add(_txt_amod_speed_7);
			pnl_Speed.Controls.Add(_txt_amod_speed_6);
			pnl_Speed.Controls.Add(_txt_amod_speed_5);
			pnl_Speed.Controls.Add(_txt_amod_speed_4);
			pnl_Speed.Controls.Add(_txt_amod_speed_0);
			pnl_Speed.Controls.Add(_txt_amod_speed_1);
			pnl_Speed.Controls.Add(_txt_amod_speed_2);
			pnl_Speed.Controls.Add(_txt_amod_speed_3);
			pnl_Speed.Controls.Add(_lbl_specs_92);
			pnl_Speed.Controls.Add(_lbl_specs_91);
			pnl_Speed.Controls.Add(_lbl_specs_90);
			pnl_Speed.Controls.Add(_lbl_specs_89);
			pnl_Speed.Controls.Add(_lbl_specs_40);
			pnl_Speed.Controls.Add(_lbl_specs_41);
			pnl_Speed.Controls.Add(_lbl_specs_42);
			pnl_Speed.Controls.Add(_lbl_specs_43);
			pnl_Speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Speed.Location = new System.Drawing.Point(740, 92);
			pnl_Speed.Name = "pnl_Speed";
			pnl_Speed.Size = new System.Drawing.Size(259, 145);
			pnl_Speed.TabIndex = 337;
			// 
			// _txt_amod_speed_7
			// 
			_txt_amod_speed_7.AcceptsReturn = true;
			_txt_amod_speed_7.AllowDrop = true;
			_txt_amod_speed_7.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_speed_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_speed_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_speed_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_speed_7.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_speed_7.Location = new System.Drawing.Point(206, 57);
			_txt_amod_speed_7.MaxLength = 0;
			_txt_amod_speed_7.Name = "_txt_amod_speed_7";
			_txt_amod_speed_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_speed_7.Size = new System.Drawing.Size(49, 19);
			_txt_amod_speed_7.TabIndex = 342;
			_txt_amod_speed_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_amod_speed_6
			// 
			_txt_amod_speed_6.AcceptsReturn = true;
			_txt_amod_speed_6.AllowDrop = true;
			_txt_amod_speed_6.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_speed_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_speed_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_speed_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_speed_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_speed_6.Location = new System.Drawing.Point(126, 122);
			_txt_amod_speed_6.MaxLength = 0;
			_txt_amod_speed_6.Name = "_txt_amod_speed_6";
			_txt_amod_speed_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_speed_6.Size = new System.Drawing.Size(49, 19);
			_txt_amod_speed_6.TabIndex = 345;
			_txt_amod_speed_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_amod_speed_5
			// 
			_txt_amod_speed_5.AcceptsReturn = true;
			_txt_amod_speed_5.AllowDrop = true;
			_txt_amod_speed_5.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_speed_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_speed_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_speed_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_speed_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_speed_5.Location = new System.Drawing.Point(126, 100);
			_txt_amod_speed_5.MaxLength = 0;
			_txt_amod_speed_5.Name = "_txt_amod_speed_5";
			_txt_amod_speed_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_speed_5.Size = new System.Drawing.Size(49, 19);
			_txt_amod_speed_5.TabIndex = 344;
			_txt_amod_speed_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_amod_speed_4
			// 
			_txt_amod_speed_4.AcceptsReturn = true;
			_txt_amod_speed_4.AllowDrop = true;
			_txt_amod_speed_4.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_speed_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_speed_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_speed_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_speed_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_speed_4.Location = new System.Drawing.Point(126, 78);
			_txt_amod_speed_4.MaxLength = 0;
			_txt_amod_speed_4.Name = "_txt_amod_speed_4";
			_txt_amod_speed_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_speed_4.Size = new System.Drawing.Size(49, 19);
			_txt_amod_speed_4.TabIndex = 343;
			_txt_amod_speed_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_amod_speed_0
			// 
			_txt_amod_speed_0.AcceptsReturn = true;
			_txt_amod_speed_0.AllowDrop = true;
			_txt_amod_speed_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_speed_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_speed_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_speed_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_speed_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_speed_0.Location = new System.Drawing.Point(62, 18);
			_txt_amod_speed_0.MaxLength = 0;
			_txt_amod_speed_0.Name = "_txt_amod_speed_0";
			_txt_amod_speed_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_speed_0.Size = new System.Drawing.Size(49, 19);
			_txt_amod_speed_0.TabIndex = 338;
			_txt_amod_speed_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_amod_speed_1
			// 
			_txt_amod_speed_1.AcceptsReturn = true;
			_txt_amod_speed_1.AllowDrop = true;
			_txt_amod_speed_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_speed_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_speed_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_speed_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_speed_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_speed_1.Location = new System.Drawing.Point(206, 18);
			_txt_amod_speed_1.MaxLength = 0;
			_txt_amod_speed_1.Name = "_txt_amod_speed_1";
			_txt_amod_speed_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_speed_1.Size = new System.Drawing.Size(49, 19);
			_txt_amod_speed_1.TabIndex = 339;
			_txt_amod_speed_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_amod_speed_2
			// 
			_txt_amod_speed_2.AcceptsReturn = true;
			_txt_amod_speed_2.AllowDrop = true;
			_txt_amod_speed_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_speed_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_speed_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_speed_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_speed_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_speed_2.Location = new System.Drawing.Point(126, 36);
			_txt_amod_speed_2.MaxLength = 0;
			_txt_amod_speed_2.Name = "_txt_amod_speed_2";
			_txt_amod_speed_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_speed_2.Size = new System.Drawing.Size(49, 19);
			_txt_amod_speed_2.TabIndex = 340;
			_txt_amod_speed_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_amod_speed_3
			// 
			_txt_amod_speed_3.AcceptsReturn = true;
			_txt_amod_speed_3.AllowDrop = true;
			_txt_amod_speed_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_speed_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_speed_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_speed_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_speed_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_speed_3.Location = new System.Drawing.Point(126, 57);
			_txt_amod_speed_3.MaxLength = 0;
			_txt_amod_speed_3.Name = "_txt_amod_speed_3";
			_txt_amod_speed_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_speed_3.Size = new System.Drawing.Size(49, 19);
			_txt_amod_speed_3.TabIndex = 341;
			_txt_amod_speed_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _lbl_specs_92
			// 
			_lbl_specs_92.AllowDrop = true;
			_lbl_specs_92.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_92.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_92.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_92.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_92.Location = new System.Drawing.Point(182, 61);
			_lbl_specs_92.MinimumSize = new System.Drawing.Size(25, 17);
			_lbl_specs_92.Name = "_lbl_specs_92";
			_lbl_specs_92.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_92.Size = new System.Drawing.Size(25, 17);
			_lbl_specs_92.TabIndex = 446;
			_lbl_specs_92.Text = "Vne";
			_lbl_specs_92.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_92.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_91
			// 
			_lbl_specs_91.AllowDrop = true;
			_lbl_specs_91.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_91.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_91.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_91.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_91.Location = new System.Drawing.Point(6, 124);
			_lbl_specs_91.MinimumSize = new System.Drawing.Size(115, 17);
			_lbl_specs_91.Name = "_lbl_specs_91";
			_lbl_specs_91.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_91.Size = new System.Drawing.Size(115, 17);
			_lbl_specs_91.TabIndex = 445;
			_lbl_specs_91.Text = "VLE Max Land Gear Ext";
			_lbl_specs_91.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_91.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_90
			// 
			_lbl_specs_90.AllowDrop = true;
			_lbl_specs_90.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_90.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_90.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_90.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_90.Location = new System.Drawing.Point(6, 104);
			_lbl_specs_90.MinimumSize = new System.Drawing.Size(87, 17);
			_lbl_specs_90.Name = "_lbl_specs_90";
			_lbl_specs_90.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_90.Size = new System.Drawing.Size(87, 17);
			_lbl_specs_90.TabIndex = 444;
			_lbl_specs_90.Text = "VFE Max Flap Ext";
			_lbl_specs_90.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_90.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_89
			// 
			_lbl_specs_89.AllowDrop = true;
			_lbl_specs_89.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_89.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_89.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_89.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_89.Location = new System.Drawing.Point(6, 84);
			_lbl_specs_89.MinimumSize = new System.Drawing.Size(61, 17);
			_lbl_specs_89.Name = "_lbl_specs_89";
			_lbl_specs_89.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_89.Size = new System.Drawing.Size(61, 17);
			_lbl_specs_89.TabIndex = 443;
			_lbl_specs_89.Text = "V1 Takeoff";
			_lbl_specs_89.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_89.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_40
			// 
			_lbl_specs_40.AllowDrop = true;
			_lbl_specs_40.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_40.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_40.Location = new System.Drawing.Point(6, 20);
			_lbl_specs_40.MinimumSize = new System.Drawing.Size(47, 17);
			_lbl_specs_40.Name = "_lbl_specs_40";
			_lbl_specs_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_40.Size = new System.Drawing.Size(47, 17);
			_lbl_specs_40.TabIndex = 349;
			_lbl_specs_40.Text = "Vs Clean:";
			_lbl_specs_40.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_40.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_41
			// 
			_lbl_specs_41.AllowDrop = true;
			_lbl_specs_41.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_41.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_41.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_41.Location = new System.Drawing.Point(128, 20);
			_lbl_specs_41.MinimumSize = new System.Drawing.Size(63, 17);
			_lbl_specs_41.Name = "_lbl_specs_41";
			_lbl_specs_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_41.Size = new System.Drawing.Size(63, 17);
			_lbl_specs_41.TabIndex = 348;
			_lbl_specs_41.Text = "Vso Landing:";
			_lbl_specs_41.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_41.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_42
			// 
			_lbl_specs_42.AllowDrop = true;
			_lbl_specs_42.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_42.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_42.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_42.Location = new System.Drawing.Point(6, 42);
			_lbl_specs_42.MinimumSize = new System.Drawing.Size(93, 17);
			_lbl_specs_42.Name = "_lbl_specs_42";
			_lbl_specs_42.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_42.Size = new System.Drawing.Size(93, 17);
			_lbl_specs_42.TabIndex = 347;
			_lbl_specs_42.Text = "Normal Cruise TAS:";
			_lbl_specs_42.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_42.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_43
			// 
			_lbl_specs_43.AllowDrop = true;
			_lbl_specs_43.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_43.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_43.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_43.Location = new System.Drawing.Point(6, 61);
			_lbl_specs_43.MinimumSize = new System.Drawing.Size(111, 17);
			_lbl_specs_43.Name = "_lbl_specs_43";
			_lbl_specs_43.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_43.Size = new System.Drawing.Size(111, 17);
			_lbl_specs_43.TabIndex = 346;
			_lbl_specs_43.Text = "(Max Op) IAS:       Vmo";
			_lbl_specs_43.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_43.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// pnl_OtherSpecs
			// 
			pnl_OtherSpecs.AllowDrop = true;
			pnl_OtherSpecs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_OtherSpecs.Controls.Add(txt_amod_range_8_passenger);
			pnl_OtherSpecs.Controls.Add(txt_amod_range_4_passenger);
			pnl_OtherSpecs.Controls.Add(txt_amod_field_length);
			pnl_OtherSpecs.Controls.Add(txt_amod_takeoff_500);
			pnl_OtherSpecs.Controls.Add(txt_amod_takeoff_ali);
			pnl_OtherSpecs.Controls.Add(txt_amod_max_range_miles);
			pnl_OtherSpecs.Controls.Add(txt_amod_range_tanks_full);
			pnl_OtherSpecs.Controls.Add(txt_amod_range_seats_full);
			pnl_OtherSpecs.Controls.Add(cmb_amod_ifr_certification);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_88);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_87);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_53);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_51);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_73);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_37);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_15);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_3);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_50);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_52);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_64);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_65);
			pnl_OtherSpecs.Controls.Add(_lbl_specs_66);
			pnl_OtherSpecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_OtherSpecs.Location = new System.Drawing.Point(759, 238);
			pnl_OtherSpecs.Name = "pnl_OtherSpecs";
			pnl_OtherSpecs.Size = new System.Drawing.Size(193, 260);
			pnl_OtherSpecs.TabIndex = 316;
			// 
			// txt_amod_range_8_passenger
			// 
			txt_amod_range_8_passenger.AcceptsReturn = true;
			txt_amod_range_8_passenger.AllowDrop = true;
			txt_amod_range_8_passenger.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_range_8_passenger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_range_8_passenger.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_range_8_passenger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_range_8_passenger.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_range_8_passenger.Location = new System.Drawing.Point(128, 212);
			txt_amod_range_8_passenger.MaxLength = 0;
			txt_amod_range_8_passenger.Name = "txt_amod_range_8_passenger";
			txt_amod_range_8_passenger.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_range_8_passenger.Size = new System.Drawing.Size(51, 19);
			txt_amod_range_8_passenger.TabIndex = 319;
			txt_amod_range_8_passenger.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_range_4_passenger
			// 
			txt_amod_range_4_passenger.AcceptsReturn = true;
			txt_amod_range_4_passenger.AllowDrop = true;
			txt_amod_range_4_passenger.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_range_4_passenger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_range_4_passenger.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_range_4_passenger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_range_4_passenger.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_range_4_passenger.Location = new System.Drawing.Point(128, 192);
			txt_amod_range_4_passenger.MaxLength = 0;
			txt_amod_range_4_passenger.Name = "txt_amod_range_4_passenger";
			txt_amod_range_4_passenger.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_range_4_passenger.Size = new System.Drawing.Size(51, 19);
			txt_amod_range_4_passenger.TabIndex = 318;
			txt_amod_range_4_passenger.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_field_length
			// 
			txt_amod_field_length.AcceptsReturn = true;
			txt_amod_field_length.AllowDrop = true;
			txt_amod_field_length.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_field_length.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_field_length.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_field_length.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_field_length.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_field_length.Location = new System.Drawing.Point(127, 88);
			txt_amod_field_length.MaxLength = 0;
			txt_amod_field_length.Name = "txt_amod_field_length";
			txt_amod_field_length.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_field_length.Size = new System.Drawing.Size(49, 19);
			txt_amod_field_length.TabIndex = 325;
			txt_amod_field_length.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_takeoff_500
			// 
			txt_amod_takeoff_500.AcceptsReturn = true;
			txt_amod_takeoff_500.AllowDrop = true;
			txt_amod_takeoff_500.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_takeoff_500.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_takeoff_500.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_takeoff_500.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_takeoff_500.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_takeoff_500.Location = new System.Drawing.Point(96, 44);
			txt_amod_takeoff_500.MaxLength = 0;
			txt_amod_takeoff_500.Name = "txt_amod_takeoff_500";
			txt_amod_takeoff_500.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_takeoff_500.Size = new System.Drawing.Size(49, 19);
			txt_amod_takeoff_500.TabIndex = 324;
			txt_amod_takeoff_500.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_takeoff_ali
			// 
			txt_amod_takeoff_ali.AcceptsReturn = true;
			txt_amod_takeoff_ali.AllowDrop = true;
			txt_amod_takeoff_ali.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_takeoff_ali.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_takeoff_ali.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_takeoff_ali.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_takeoff_ali.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_takeoff_ali.Location = new System.Drawing.Point(96, 24);
			txt_amod_takeoff_ali.MaxLength = 0;
			txt_amod_takeoff_ali.Name = "txt_amod_takeoff_ali";
			txt_amod_takeoff_ali.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_takeoff_ali.Size = new System.Drawing.Size(49, 19);
			txt_amod_takeoff_ali.TabIndex = 323;
			txt_amod_takeoff_ali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_max_range_miles
			// 
			txt_amod_max_range_miles.AcceptsReturn = true;
			txt_amod_max_range_miles.AllowDrop = true;
			txt_amod_max_range_miles.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_max_range_miles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_max_range_miles.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_max_range_miles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_max_range_miles.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_max_range_miles.Location = new System.Drawing.Point(128, 131);
			txt_amod_max_range_miles.MaxLength = 0;
			txt_amod_max_range_miles.Name = "txt_amod_max_range_miles";
			txt_amod_max_range_miles.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_max_range_miles.Size = new System.Drawing.Size(51, 19);
			txt_amod_max_range_miles.TabIndex = 322;
			txt_amod_max_range_miles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_range_tanks_full
			// 
			txt_amod_range_tanks_full.AcceptsReturn = true;
			txt_amod_range_tanks_full.AllowDrop = true;
			txt_amod_range_tanks_full.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_range_tanks_full.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_range_tanks_full.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_range_tanks_full.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_range_tanks_full.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_range_tanks_full.Location = new System.Drawing.Point(128, 152);
			txt_amod_range_tanks_full.MaxLength = 0;
			txt_amod_range_tanks_full.Name = "txt_amod_range_tanks_full";
			txt_amod_range_tanks_full.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_range_tanks_full.Size = new System.Drawing.Size(51, 19);
			txt_amod_range_tanks_full.TabIndex = 320;
			txt_amod_range_tanks_full.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_range_seats_full
			// 
			txt_amod_range_seats_full.AcceptsReturn = true;
			txt_amod_range_seats_full.AllowDrop = true;
			txt_amod_range_seats_full.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_range_seats_full.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_range_seats_full.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_range_seats_full.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_range_seats_full.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_range_seats_full.Location = new System.Drawing.Point(128, 172);
			txt_amod_range_seats_full.MaxLength = 0;
			txt_amod_range_seats_full.Name = "txt_amod_range_seats_full";
			txt_amod_range_seats_full.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_range_seats_full.Size = new System.Drawing.Size(51, 19);
			txt_amod_range_seats_full.TabIndex = 317;
			txt_amod_range_seats_full.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmb_amod_ifr_certification
			// 
			cmb_amod_ifr_certification.AllowDrop = true;
			cmb_amod_ifr_certification.BackColor = System.Drawing.SystemColors.Window;
			cmb_amod_ifr_certification.CausesValidation = true;
			cmb_amod_ifr_certification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmb_amod_ifr_certification.Enabled = true;
			cmb_amod_ifr_certification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_amod_ifr_certification.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_amod_ifr_certification.IntegralHeight = true;
			cmb_amod_ifr_certification.Location = new System.Drawing.Point(79, 232);
			cmb_amod_ifr_certification.Name = "cmb_amod_ifr_certification";
			cmb_amod_ifr_certification.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_amod_ifr_certification.Size = new System.Drawing.Size(107, 21);
			cmb_amod_ifr_certification.Sorted = false;
			cmb_amod_ifr_certification.TabIndex = 321;
			cmb_amod_ifr_certification.TabStop = true;
			cmb_amod_ifr_certification.Visible = true;
			cmb_amod_ifr_certification.SelectionChangeCommitted += new System.EventHandler(cmb_amod_ifr_certification_SelectionChangeCommitted);
			// 
			// _lbl_specs_88
			// 
			_lbl_specs_88.AllowDrop = true;
			_lbl_specs_88.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_88.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_88.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_88.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_88.Location = new System.Drawing.Point(46, 214);
			_lbl_specs_88.MinimumSize = new System.Drawing.Size(65, 17);
			_lbl_specs_88.Name = "_lbl_specs_88";
			_lbl_specs_88.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_88.Size = new System.Drawing.Size(65, 17);
			_lbl_specs_88.TabIndex = 442;
			_lbl_specs_88.Text = "8 Passenger";
			_lbl_specs_88.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_88.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_87
			// 
			_lbl_specs_87.AllowDrop = true;
			_lbl_specs_87.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_87.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_87.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_87.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_87.Location = new System.Drawing.Point(47, 194);
			_lbl_specs_87.MinimumSize = new System.Drawing.Size(65, 17);
			_lbl_specs_87.Name = "_lbl_specs_87";
			_lbl_specs_87.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_87.Size = new System.Drawing.Size(65, 17);
			_lbl_specs_87.TabIndex = 441;
			_lbl_specs_87.Text = "4 Passenger";
			_lbl_specs_87.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_87.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_53
			// 
			_lbl_specs_53.AllowDrop = true;
			_lbl_specs_53.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_53.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_53.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_53.Location = new System.Drawing.Point(5, 135);
			_lbl_specs_53.MinimumSize = new System.Drawing.Size(121, 17);
			_lbl_specs_53.Name = "_lbl_specs_53";
			_lbl_specs_53.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_53.Size = new System.Drawing.Size(121, 17);
			_lbl_specs_53.TabIndex = 336;
			_lbl_specs_53.Text = "Max Range (NBAA IFR):";
			_lbl_specs_53.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_53.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_51
			// 
			_lbl_specs_51.AllowDrop = true;
			_lbl_specs_51.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_51.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_51.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_51.Location = new System.Drawing.Point(8, 91);
			_lbl_specs_51.MinimumSize = new System.Drawing.Size(89, 17);
			_lbl_specs_51.Name = "_lbl_specs_51";
			_lbl_specs_51.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_51.Size = new System.Drawing.Size(89, 17);
			_lbl_specs_51.TabIndex = 335;
			_lbl_specs_51.Text = "FAA Field Length:";
			_lbl_specs_51.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_51.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_73
			// 
			_lbl_specs_73.AllowDrop = true;
			_lbl_specs_73.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_73.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_73.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_73.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_73.Location = new System.Drawing.Point(152, 44);
			_lbl_specs_73.MinimumSize = new System.Drawing.Size(25, 17);
			_lbl_specs_73.Name = "_lbl_specs_73";
			_lbl_specs_73.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_73.Size = new System.Drawing.Size(25, 17);
			_lbl_specs_73.TabIndex = 334;
			_lbl_specs_73.Text = "ft.";
			_lbl_specs_73.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_73.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_37
			// 
			_lbl_specs_37.AllowDrop = true;
			_lbl_specs_37.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_37.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_37.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_37.Location = new System.Drawing.Point(152, 24);
			_lbl_specs_37.MinimumSize = new System.Drawing.Size(25, 17);
			_lbl_specs_37.Name = "_lbl_specs_37";
			_lbl_specs_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_37.Size = new System.Drawing.Size(25, 17);
			_lbl_specs_37.TabIndex = 333;
			_lbl_specs_37.Text = "ft.";
			_lbl_specs_37.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_37.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_15
			// 
			_lbl_specs_15.AllowDrop = true;
			_lbl_specs_15.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_15.Location = new System.Drawing.Point(8, 44);
			_lbl_specs_15.MinimumSize = new System.Drawing.Size(84, 17);
			_lbl_specs_15.Name = "_lbl_specs_15";
			_lbl_specs_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_15.Size = new System.Drawing.Size(84, 17);
			_lbl_specs_15.TabIndex = 332;
			_lbl_specs_15.Text = "5000 +25C BFL:";
			_lbl_specs_15.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_15.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_3
			// 
			_lbl_specs_3.AllowDrop = true;
			_lbl_specs_3.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_3.Location = new System.Drawing.Point(8, 25);
			_lbl_specs_3.MinimumSize = new System.Drawing.Size(65, 17);
			_lbl_specs_3.Name = "_lbl_specs_3";
			_lbl_specs_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_3.Size = new System.Drawing.Size(65, 17);
			_lbl_specs_3.TabIndex = 331;
			_lbl_specs_3.Text = "SL ISA BFL:";
			_lbl_specs_3.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_3.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_50
			// 
			_lbl_specs_50.AllowDrop = true;
			_lbl_specs_50.BackColor = System.Drawing.Color.Transparent;
			_lbl_specs_50.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_50.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_50.Location = new System.Drawing.Point(11, 69);
			_lbl_specs_50.MinimumSize = new System.Drawing.Size(161, 33);
			_lbl_specs_50.Name = "_lbl_specs_50";
			_lbl_specs_50.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_50.Size = new System.Drawing.Size(161, 33);
			_lbl_specs_50.TabIndex = 330;
			_lbl_specs_50.Text = "Landing Performance";
			_lbl_specs_50.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_50.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_52
			// 
			_lbl_specs_52.AllowDrop = true;
			_lbl_specs_52.BackColor = System.Drawing.Color.Transparent;
			_lbl_specs_52.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_52.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_52.Location = new System.Drawing.Point(6, 113);
			_lbl_specs_52.MinimumSize = new System.Drawing.Size(149, 17);
			_lbl_specs_52.Name = "_lbl_specs_52";
			_lbl_specs_52.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_52.Size = new System.Drawing.Size(149, 17);
			_lbl_specs_52.TabIndex = 329;
			_lbl_specs_52.Text = "Range (Nautical Miles)";
			_lbl_specs_52.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_52.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_64
			// 
			_lbl_specs_64.AllowDrop = true;
			_lbl_specs_64.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_64.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_64.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_64.Location = new System.Drawing.Point(46, 154);
			_lbl_specs_64.MinimumSize = new System.Drawing.Size(61, 17);
			_lbl_specs_64.Name = "_lbl_specs_64";
			_lbl_specs_64.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_64.Size = new System.Drawing.Size(61, 17);
			_lbl_specs_64.TabIndex = 328;
			_lbl_specs_64.Text = "Tanks Full:";
			_lbl_specs_64.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_64.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_65
			// 
			_lbl_specs_65.AllowDrop = true;
			_lbl_specs_65.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_65.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_65.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_65.Location = new System.Drawing.Point(47, 174);
			_lbl_specs_65.MinimumSize = new System.Drawing.Size(57, 17);
			_lbl_specs_65.Name = "_lbl_specs_65";
			_lbl_specs_65.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_65.Size = new System.Drawing.Size(57, 17);
			_lbl_specs_65.TabIndex = 327;
			_lbl_specs_65.Text = "Seats Full:";
			_lbl_specs_65.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_65.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_66
			// 
			_lbl_specs_66.AllowDrop = true;
			_lbl_specs_66.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_66.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_66.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_66.Location = new System.Drawing.Point(5, 226);
			_lbl_specs_66.MinimumSize = new System.Drawing.Size(61, 28);
			_lbl_specs_66.Name = "_lbl_specs_66";
			_lbl_specs_66.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_66.Size = new System.Drawing.Size(61, 28);
			_lbl_specs_66.TabIndex = 326;
			_lbl_specs_66.Text = "IFR Certification:";
			_lbl_specs_66.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_66.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// pnl_Props
			// 
			pnl_Props.AllowDrop = true;
			pnl_Props.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Props.Controls.Add(txt_amod_number_of_props);
			pnl_Props.Controls.Add(txt_amod_prop_model_name);
			pnl_Props.Controls.Add(txt_amod_prop_mfr_name);
			pnl_Props.Controls.Add(txt_amod_prop_com_tbo_hrs);
			pnl_Props.Controls.Add(txt_amod_prop_shaft);
			pnl_Props.Controls.Add(txt_amod_prop_hsi);
			pnl_Props.Controls.Add(_lbl_Prop_number_16);
			pnl_Props.Controls.Add(_lbl_specs_45);
			pnl_Props.Controls.Add(_lbl_specs_44);
			pnl_Props.Controls.Add(_lbl_specs_46);
			pnl_Props.Controls.Add(_lbl_specs_47);
			pnl_Props.Controls.Add(_lbl_specs_36);
			pnl_Props.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Props.Location = new System.Drawing.Point(276, 5);
			pnl_Props.Name = "pnl_Props";
			pnl_Props.Size = new System.Drawing.Size(281, 120);
			pnl_Props.TabIndex = 303;
			// 
			// txt_amod_number_of_props
			// 
			txt_amod_number_of_props.AcceptsReturn = true;
			txt_amod_number_of_props.AllowDrop = true;
			txt_amod_number_of_props.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_number_of_props.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_number_of_props.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_number_of_props.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_number_of_props.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_number_of_props.Location = new System.Drawing.Point(112, 19);
			txt_amod_number_of_props.MaxLength = 0;
			txt_amod_number_of_props.Name = "txt_amod_number_of_props";
			txt_amod_number_of_props.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_number_of_props.Size = new System.Drawing.Size(25, 20);
			txt_amod_number_of_props.TabIndex = 309;
			txt_amod_number_of_props.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_prop_model_name
			// 
			txt_amod_prop_model_name.AcceptsReturn = true;
			txt_amod_prop_model_name.AllowDrop = true;
			txt_amod_prop_model_name.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_prop_model_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_prop_model_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_prop_model_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_prop_model_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_prop_model_name.Location = new System.Drawing.Point(16, 53);
			txt_amod_prop_model_name.MaxLength = 0;
			txt_amod_prop_model_name.Name = "txt_amod_prop_model_name";
			txt_amod_prop_model_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_prop_model_name.Size = new System.Drawing.Size(121, 19);
			txt_amod_prop_model_name.TabIndex = 308;
			txt_amod_prop_model_name.Click += new System.EventHandler(txt_amod_prop_model_name_Click);
			// 
			// txt_amod_prop_mfr_name
			// 
			txt_amod_prop_mfr_name.AcceptsReturn = true;
			txt_amod_prop_mfr_name.AllowDrop = true;
			txt_amod_prop_mfr_name.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_prop_mfr_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_prop_mfr_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_prop_mfr_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_prop_mfr_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_prop_mfr_name.Location = new System.Drawing.Point(142, 53);
			txt_amod_prop_mfr_name.MaxLength = 0;
			txt_amod_prop_mfr_name.Name = "txt_amod_prop_mfr_name";
			txt_amod_prop_mfr_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_prop_mfr_name.Size = new System.Drawing.Size(137, 19);
			txt_amod_prop_mfr_name.TabIndex = 307;
			txt_amod_prop_mfr_name.Click += new System.EventHandler(txt_amod_prop_mfr_name_Click);
			// 
			// txt_amod_prop_com_tbo_hrs
			// 
			txt_amod_prop_com_tbo_hrs.AcceptsReturn = true;
			txt_amod_prop_com_tbo_hrs.AllowDrop = true;
			txt_amod_prop_com_tbo_hrs.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_prop_com_tbo_hrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_prop_com_tbo_hrs.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_prop_com_tbo_hrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_prop_com_tbo_hrs.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_prop_com_tbo_hrs.Location = new System.Drawing.Point(25, 93);
			txt_amod_prop_com_tbo_hrs.MaxLength = 0;
			txt_amod_prop_com_tbo_hrs.Name = "txt_amod_prop_com_tbo_hrs";
			txt_amod_prop_com_tbo_hrs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_prop_com_tbo_hrs.Size = new System.Drawing.Size(49, 20);
			txt_amod_prop_com_tbo_hrs.TabIndex = 306;
			txt_amod_prop_com_tbo_hrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_prop_shaft
			// 
			txt_amod_prop_shaft.AcceptsReturn = true;
			txt_amod_prop_shaft.AllowDrop = true;
			txt_amod_prop_shaft.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_prop_shaft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_prop_shaft.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_prop_shaft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_prop_shaft.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_prop_shaft.Location = new System.Drawing.Point(146, 93);
			txt_amod_prop_shaft.MaxLength = 0;
			txt_amod_prop_shaft.Name = "txt_amod_prop_shaft";
			txt_amod_prop_shaft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_prop_shaft.Size = new System.Drawing.Size(49, 20);
			txt_amod_prop_shaft.TabIndex = 305;
			txt_amod_prop_shaft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_prop_shaft.Visible = false;
			// 
			// txt_amod_prop_hsi
			// 
			txt_amod_prop_hsi.AcceptsReturn = true;
			txt_amod_prop_hsi.AllowDrop = true;
			txt_amod_prop_hsi.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_prop_hsi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_prop_hsi.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_prop_hsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_prop_hsi.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_prop_hsi.Location = new System.Drawing.Point(205, 93);
			txt_amod_prop_hsi.MaxLength = 0;
			txt_amod_prop_hsi.Name = "txt_amod_prop_hsi";
			txt_amod_prop_hsi.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_prop_hsi.Size = new System.Drawing.Size(49, 20);
			txt_amod_prop_hsi.TabIndex = 304;
			txt_amod_prop_hsi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_amod_prop_hsi.Visible = false;
			// 
			// _lbl_Prop_number_16
			// 
			_lbl_Prop_number_16.AllowDrop = true;
			_lbl_Prop_number_16.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Prop_number_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Prop_number_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Prop_number_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Prop_number_16.Location = new System.Drawing.Point(16, 21);
			_lbl_Prop_number_16.MinimumSize = new System.Drawing.Size(88, 16);
			_lbl_Prop_number_16.Name = "_lbl_Prop_number_16";
			_lbl_Prop_number_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Prop_number_16.Size = new System.Drawing.Size(88, 16);
			_lbl_Prop_number_16.TabIndex = 315;
			_lbl_Prop_number_16.Text = "Number of Props:";
			// 
			// _lbl_specs_45
			// 
			_lbl_specs_45.AllowDrop = true;
			_lbl_specs_45.AutoSize = true;
			_lbl_specs_45.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_45.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_45.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_45.Location = new System.Drawing.Point(16, 40);
			_lbl_specs_45.MinimumSize = new System.Drawing.Size(63, 13);
			_lbl_specs_45.Name = "_lbl_specs_45";
			_lbl_specs_45.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_45.Size = new System.Drawing.Size(63, 13);
			_lbl_specs_45.TabIndex = 314;
			_lbl_specs_45.Text = "Model Name:";
			_lbl_specs_45.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_45.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_44
			// 
			_lbl_specs_44.AllowDrop = true;
			_lbl_specs_44.AutoSize = true;
			_lbl_specs_44.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_44.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_44.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_44.Location = new System.Drawing.Point(152, 40);
			_lbl_specs_44.MinimumSize = new System.Drawing.Size(58, 13);
			_lbl_specs_44.Name = "_lbl_specs_44";
			_lbl_specs_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_44.Size = new System.Drawing.Size(58, 13);
			_lbl_specs_44.TabIndex = 313;
			_lbl_specs_44.Text = "Mfgr. Name:";
			_lbl_specs_44.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_44.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_46
			// 
			_lbl_specs_46.AllowDrop = true;
			_lbl_specs_46.AutoSize = true;
			_lbl_specs_46.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_46.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_46.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_46.Location = new System.Drawing.Point(16, 76);
			_lbl_specs_46.MinimumSize = new System.Drawing.Size(82, 14);
			_lbl_specs_46.Name = "_lbl_specs_46";
			_lbl_specs_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_46.Size = new System.Drawing.Size(82, 14);
			_lbl_specs_46.TabIndex = 312;
			_lbl_specs_46.Text = "COM TBO Hrs:";
			_lbl_specs_46.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_specs_46.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_46.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_47
			// 
			_lbl_specs_47.AllowDrop = true;
			_lbl_specs_47.AutoSize = true;
			_lbl_specs_47.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_47.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_47.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_47.Location = new System.Drawing.Point(155, 77);
			_lbl_specs_47.MinimumSize = new System.Drawing.Size(28, 13);
			_lbl_specs_47.Name = "_lbl_specs_47";
			_lbl_specs_47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_47.Size = new System.Drawing.Size(28, 13);
			_lbl_specs_47.TabIndex = 311;
			_lbl_specs_47.Text = "Shaft:";
			_lbl_specs_47.Visible = false;
			_lbl_specs_47.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_47.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_36
			// 
			_lbl_specs_36.AllowDrop = true;
			_lbl_specs_36.AutoSize = true;
			_lbl_specs_36.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_36.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_36.Location = new System.Drawing.Point(217, 77);
			_lbl_specs_36.MinimumSize = new System.Drawing.Size(21, 13);
			_lbl_specs_36.Name = "_lbl_specs_36";
			_lbl_specs_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_36.Size = new System.Drawing.Size(21, 13);
			_lbl_specs_36.TabIndex = 310;
			_lbl_specs_36.Text = "HSI:";
			_lbl_specs_36.Visible = false;
			_lbl_specs_36.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_36.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// pnl_FuselageDimensions
			// 
			pnl_FuselageDimensions.AllowDrop = true;
			pnl_FuselageDimensions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_FuselageDimensions.Controls.Add(txt_amod_fuselage_wingspan);
			pnl_FuselageDimensions.Controls.Add(txt_amod_fuselage_height);
			pnl_FuselageDimensions.Controls.Add(_txt_amod_fuselage_length_0);
			pnl_FuselageDimensions.Controls.Add(txt_amod_fuselage_width);
			pnl_FuselageDimensions.Controls.Add(_lbl_specs_71);
			pnl_FuselageDimensions.Controls.Add(_lbl_specs_72);
			pnl_FuselageDimensions.Controls.Add(_lbl_specs_70);
			pnl_FuselageDimensions.Controls.Add(_lbl_specs_2);
			pnl_FuselageDimensions.Controls.Add(_lbl_specs_1);
			pnl_FuselageDimensions.Controls.Add(_lbl_specs_0);
			pnl_FuselageDimensions.Controls.Add(_lbl_specs_57);
			pnl_FuselageDimensions.Controls.Add(_lbl_specs_58);
			pnl_FuselageDimensions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_FuselageDimensions.Location = new System.Drawing.Point(571, 10);
			pnl_FuselageDimensions.Name = "pnl_FuselageDimensions";
			pnl_FuselageDimensions.Size = new System.Drawing.Size(157, 104);
			pnl_FuselageDimensions.TabIndex = 276;
			// 
			// txt_amod_fuselage_wingspan
			// 
			txt_amod_fuselage_wingspan.AcceptsReturn = true;
			txt_amod_fuselage_wingspan.AllowDrop = true;
			txt_amod_fuselage_wingspan.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_fuselage_wingspan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_fuselage_wingspan.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_fuselage_wingspan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_fuselage_wingspan.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_fuselage_wingspan.Location = new System.Drawing.Point(66, 78);
			txt_amod_fuselage_wingspan.MaxLength = 0;
			txt_amod_fuselage_wingspan.Name = "txt_amod_fuselage_wingspan";
			txt_amod_fuselage_wingspan.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_fuselage_wingspan.Size = new System.Drawing.Size(49, 19);
			txt_amod_fuselage_wingspan.TabIndex = 280;
			txt_amod_fuselage_wingspan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_fuselage_height
			// 
			txt_amod_fuselage_height.AcceptsReturn = true;
			txt_amod_fuselage_height.AllowDrop = true;
			txt_amod_fuselage_height.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_fuselage_height.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_fuselage_height.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_fuselage_height.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_fuselage_height.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_fuselage_height.Location = new System.Drawing.Point(66, 37);
			txt_amod_fuselage_height.MaxLength = 0;
			txt_amod_fuselage_height.Name = "txt_amod_fuselage_height";
			txt_amod_fuselage_height.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_fuselage_height.Size = new System.Drawing.Size(49, 19);
			txt_amod_fuselage_height.TabIndex = 279;
			txt_amod_fuselage_height.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_amod_fuselage_length_0
			// 
			_txt_amod_fuselage_length_0.AcceptsReturn = true;
			_txt_amod_fuselage_length_0.AllowDrop = true;
			_txt_amod_fuselage_length_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_fuselage_length_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_fuselage_length_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_fuselage_length_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_fuselage_length_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_fuselage_length_0.Location = new System.Drawing.Point(66, 16);
			_txt_amod_fuselage_length_0.MaxLength = 0;
			_txt_amod_fuselage_length_0.Name = "_txt_amod_fuselage_length_0";
			_txt_amod_fuselage_length_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_fuselage_length_0.Size = new System.Drawing.Size(49, 19);
			_txt_amod_fuselage_length_0.TabIndex = 278;
			_txt_amod_fuselage_length_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_amod_fuselage_length_0.Leave += new System.EventHandler(txt_amod_fuselage_length_Leave);
			// 
			// txt_amod_fuselage_width
			// 
			txt_amod_fuselage_width.AcceptsReturn = true;
			txt_amod_fuselage_width.AllowDrop = true;
			txt_amod_fuselage_width.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_fuselage_width.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_fuselage_width.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_fuselage_width.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_fuselage_width.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_fuselage_width.Location = new System.Drawing.Point(66, 57);
			txt_amod_fuselage_width.MaxLength = 0;
			txt_amod_fuselage_width.Name = "txt_amod_fuselage_width";
			txt_amod_fuselage_width.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_fuselage_width.Size = new System.Drawing.Size(49, 19);
			txt_amod_fuselage_width.TabIndex = 277;
			txt_amod_fuselage_width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _lbl_specs_71
			// 
			_lbl_specs_71.AllowDrop = true;
			_lbl_specs_71.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_71.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_71.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_71.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_71.Location = new System.Drawing.Point(122, 37);
			_lbl_specs_71.MinimumSize = new System.Drawing.Size(25, 17);
			_lbl_specs_71.Name = "_lbl_specs_71";
			_lbl_specs_71.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_71.Size = new System.Drawing.Size(25, 17);
			_lbl_specs_71.TabIndex = 288;
			_lbl_specs_71.Text = "ft.";
			_lbl_specs_71.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_71.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_72
			// 
			_lbl_specs_72.AllowDrop = true;
			_lbl_specs_72.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_72.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_72.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_72.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_72.Location = new System.Drawing.Point(121, 78);
			_lbl_specs_72.MinimumSize = new System.Drawing.Size(25, 17);
			_lbl_specs_72.Name = "_lbl_specs_72";
			_lbl_specs_72.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_72.Size = new System.Drawing.Size(25, 17);
			_lbl_specs_72.TabIndex = 287;
			_lbl_specs_72.Text = "ft.";
			_lbl_specs_72.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_72.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_70
			// 
			_lbl_specs_70.AllowDrop = true;
			_lbl_specs_70.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_70.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_70.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_70.Location = new System.Drawing.Point(122, 17);
			_lbl_specs_70.MinimumSize = new System.Drawing.Size(25, 17);
			_lbl_specs_70.Name = "_lbl_specs_70";
			_lbl_specs_70.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_70.Size = new System.Drawing.Size(25, 17);
			_lbl_specs_70.TabIndex = 286;
			_lbl_specs_70.Text = "ft.";
			_lbl_specs_70.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_70.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_2
			// 
			_lbl_specs_2.AllowDrop = true;
			_lbl_specs_2.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_2.Location = new System.Drawing.Point(3, 80);
			_lbl_specs_2.MinimumSize = new System.Drawing.Size(70, 17);
			_lbl_specs_2.Name = "_lbl_specs_2";
			_lbl_specs_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_2.Size = new System.Drawing.Size(70, 17);
			_lbl_specs_2.TabIndex = 285;
			_lbl_specs_2.Text = "Wing Span:";
			_lbl_specs_2.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_2.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_1
			// 
			_lbl_specs_1.AllowDrop = true;
			_lbl_specs_1.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_1.Location = new System.Drawing.Point(9, 37);
			_lbl_specs_1.MinimumSize = new System.Drawing.Size(49, 17);
			_lbl_specs_1.Name = "_lbl_specs_1";
			_lbl_specs_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_1.Size = new System.Drawing.Size(49, 17);
			_lbl_specs_1.TabIndex = 284;
			_lbl_specs_1.Text = "Height:";
			_lbl_specs_1.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_1.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_0
			// 
			_lbl_specs_0.AllowDrop = true;
			_lbl_specs_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_0.Location = new System.Drawing.Point(8, 19);
			_lbl_specs_0.MinimumSize = new System.Drawing.Size(49, 17);
			_lbl_specs_0.Name = "_lbl_specs_0";
			_lbl_specs_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_0.Size = new System.Drawing.Size(49, 17);
			_lbl_specs_0.TabIndex = 283;
			_lbl_specs_0.Text = "Length:";
			_lbl_specs_0.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_0.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_57
			// 
			_lbl_specs_57.AllowDrop = true;
			_lbl_specs_57.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_57.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_57.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_57.Location = new System.Drawing.Point(9, 58);
			_lbl_specs_57.MinimumSize = new System.Drawing.Size(49, 17);
			_lbl_specs_57.Name = "_lbl_specs_57";
			_lbl_specs_57.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_57.Size = new System.Drawing.Size(49, 17);
			_lbl_specs_57.TabIndex = 282;
			_lbl_specs_57.Text = "Width:";
			_lbl_specs_57.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_57.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_58
			// 
			_lbl_specs_58.AllowDrop = true;
			_lbl_specs_58.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_58.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_58.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_58.Location = new System.Drawing.Point(122, 58);
			_lbl_specs_58.MinimumSize = new System.Drawing.Size(13, 17);
			_lbl_specs_58.Name = "_lbl_specs_58";
			_lbl_specs_58.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_58.Size = new System.Drawing.Size(13, 17);
			_lbl_specs_58.TabIndex = 281;
			_lbl_specs_58.Text = "ft.";
			_lbl_specs_58.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_58.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// pnl_Config
			// 
			pnl_Config.AllowDrop = true;
			pnl_Config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Config.Controls.Add(txt_amod_pressure);
			pnl_Config.Controls.Add(txt_amod_number_of_passengers);
			pnl_Config.Controls.Add(txt_amod_number_of_crew);
			pnl_Config.Controls.Add(_lbl_specs_6);
			pnl_Config.Controls.Add(_lbl_specs_5);
			pnl_Config.Controls.Add(_lbl_specs_4);
			pnl_Config.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Config.Location = new System.Drawing.Point(561, 271);
			pnl_Config.Name = "pnl_Config";
			pnl_Config.Size = new System.Drawing.Size(177, 97);
			pnl_Config.TabIndex = 269;
			// 
			// txt_amod_pressure
			// 
			txt_amod_pressure.AcceptsReturn = true;
			txt_amod_pressure.AllowDrop = true;
			txt_amod_pressure.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_pressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_pressure.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_pressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_pressure.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_pressure.Location = new System.Drawing.Point(112, 72);
			txt_amod_pressure.MaxLength = 0;
			txt_amod_pressure.Name = "txt_amod_pressure";
			txt_amod_pressure.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_pressure.Size = new System.Drawing.Size(49, 19);
			txt_amod_pressure.TabIndex = 272;
			txt_amod_pressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_number_of_passengers
			// 
			txt_amod_number_of_passengers.AcceptsReturn = true;
			txt_amod_number_of_passengers.AllowDrop = true;
			txt_amod_number_of_passengers.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_number_of_passengers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_number_of_passengers.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_number_of_passengers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_number_of_passengers.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_number_of_passengers.Location = new System.Drawing.Point(112, 48);
			txt_amod_number_of_passengers.MaxLength = 0;
			txt_amod_number_of_passengers.Name = "txt_amod_number_of_passengers";
			txt_amod_number_of_passengers.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_number_of_passengers.Size = new System.Drawing.Size(49, 19);
			txt_amod_number_of_passengers.TabIndex = 271;
			txt_amod_number_of_passengers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_number_of_crew
			// 
			txt_amod_number_of_crew.AcceptsReturn = true;
			txt_amod_number_of_crew.AllowDrop = true;
			txt_amod_number_of_crew.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_number_of_crew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_number_of_crew.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_number_of_crew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_number_of_crew.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_number_of_crew.Location = new System.Drawing.Point(112, 24);
			txt_amod_number_of_crew.MaxLength = 0;
			txt_amod_number_of_crew.Name = "txt_amod_number_of_crew";
			txt_amod_number_of_crew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_number_of_crew.Size = new System.Drawing.Size(49, 19);
			txt_amod_number_of_crew.TabIndex = 270;
			txt_amod_number_of_crew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _lbl_specs_6
			// 
			_lbl_specs_6.AllowDrop = true;
			_lbl_specs_6.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_6.Location = new System.Drawing.Point(17, 71);
			_lbl_specs_6.MinimumSize = new System.Drawing.Size(97, 17);
			_lbl_specs_6.Name = "_lbl_specs_6";
			_lbl_specs_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_6.Size = new System.Drawing.Size(97, 17);
			_lbl_specs_6.TabIndex = 275;
			_lbl_specs_6.Text = "Pressurization (psi):";
			_lbl_specs_6.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_6.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_5
			// 
			_lbl_specs_5.AllowDrop = true;
			_lbl_specs_5.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_5.Location = new System.Drawing.Point(16, 47);
			_lbl_specs_5.MinimumSize = new System.Drawing.Size(65, 17);
			_lbl_specs_5.Name = "_lbl_specs_5";
			_lbl_specs_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_5.Size = new System.Drawing.Size(65, 17);
			_lbl_specs_5.TabIndex = 274;
			_lbl_specs_5.Text = "Passengers:";
			_lbl_specs_5.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_5.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_4
			// 
			_lbl_specs_4.AllowDrop = true;
			_lbl_specs_4.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_4.Location = new System.Drawing.Point(16, 24);
			_lbl_specs_4.MinimumSize = new System.Drawing.Size(49, 17);
			_lbl_specs_4.Name = "_lbl_specs_4";
			_lbl_specs_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_4.Size = new System.Drawing.Size(49, 17);
			_lbl_specs_4.TabIndex = 273;
			_lbl_specs_4.Text = "Crew:";
			_lbl_specs_4.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_4.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// pnl_Weight
			// 
			pnl_Weight.AllowDrop = true;
			pnl_Weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Weight.Controls.Add(txt_amod_max_landing_weight);
			pnl_Weight.Controls.Add(txt_amod_basic_op_weight);
			pnl_Weight.Controls.Add(txt_amod_zero_fuel_weight);
			pnl_Weight.Controls.Add(txt_amod_max_takeoff_weight);
			pnl_Weight.Controls.Add(txt_amod_max_ramp_weight);
			pnl_Weight.Controls.Add(txt_amod_weight_eow);
			pnl_Weight.Controls.Add(_lbl_specs_31);
			pnl_Weight.Controls.Add(_lbl_specs_30);
			pnl_Weight.Controls.Add(_lbl_specs_29);
			pnl_Weight.Controls.Add(_lbl_specs_28);
			pnl_Weight.Controls.Add(_lbl_specs_27);
			pnl_Weight.Controls.Add(_lbl_specs_63);
			pnl_Weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Weight.Location = new System.Drawing.Point(562, 116);
			pnl_Weight.Name = "pnl_Weight";
			pnl_Weight.Size = new System.Drawing.Size(177, 150);
			pnl_Weight.TabIndex = 256;
			// 
			// txt_amod_max_landing_weight
			// 
			txt_amod_max_landing_weight.AcceptsReturn = true;
			txt_amod_max_landing_weight.AllowDrop = true;
			txt_amod_max_landing_weight.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_max_landing_weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_max_landing_weight.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_max_landing_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_max_landing_weight.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_max_landing_weight.Location = new System.Drawing.Point(119, 106);
			txt_amod_max_landing_weight.MaxLength = 0;
			txt_amod_max_landing_weight.Name = "txt_amod_max_landing_weight";
			txt_amod_max_landing_weight.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_max_landing_weight.Size = new System.Drawing.Size(49, 20);
			txt_amod_max_landing_weight.TabIndex = 262;
			txt_amod_max_landing_weight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_basic_op_weight
			// 
			txt_amod_basic_op_weight.AcceptsReturn = true;
			txt_amod_basic_op_weight.AllowDrop = true;
			txt_amod_basic_op_weight.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_basic_op_weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_basic_op_weight.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_basic_op_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_basic_op_weight.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_basic_op_weight.Location = new System.Drawing.Point(119, 84);
			txt_amod_basic_op_weight.MaxLength = 0;
			txt_amod_basic_op_weight.Name = "txt_amod_basic_op_weight";
			txt_amod_basic_op_weight.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_basic_op_weight.Size = new System.Drawing.Size(49, 20);
			txt_amod_basic_op_weight.TabIndex = 261;
			txt_amod_basic_op_weight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_zero_fuel_weight
			// 
			txt_amod_zero_fuel_weight.AcceptsReturn = true;
			txt_amod_zero_fuel_weight.AllowDrop = true;
			txt_amod_zero_fuel_weight.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_zero_fuel_weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_zero_fuel_weight.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_zero_fuel_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_zero_fuel_weight.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_zero_fuel_weight.Location = new System.Drawing.Point(119, 62);
			txt_amod_zero_fuel_weight.MaxLength = 0;
			txt_amod_zero_fuel_weight.Name = "txt_amod_zero_fuel_weight";
			txt_amod_zero_fuel_weight.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_zero_fuel_weight.Size = new System.Drawing.Size(49, 19);
			txt_amod_zero_fuel_weight.TabIndex = 260;
			txt_amod_zero_fuel_weight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_max_takeoff_weight
			// 
			txt_amod_max_takeoff_weight.AcceptsReturn = true;
			txt_amod_max_takeoff_weight.AllowDrop = true;
			txt_amod_max_takeoff_weight.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_max_takeoff_weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_max_takeoff_weight.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_max_takeoff_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_max_takeoff_weight.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_max_takeoff_weight.Location = new System.Drawing.Point(119, 40);
			txt_amod_max_takeoff_weight.MaxLength = 0;
			txt_amod_max_takeoff_weight.Name = "txt_amod_max_takeoff_weight";
			txt_amod_max_takeoff_weight.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_max_takeoff_weight.Size = new System.Drawing.Size(49, 19);
			txt_amod_max_takeoff_weight.TabIndex = 259;
			txt_amod_max_takeoff_weight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_max_ramp_weight
			// 
			txt_amod_max_ramp_weight.AcceptsReturn = true;
			txt_amod_max_ramp_weight.AllowDrop = true;
			txt_amod_max_ramp_weight.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_max_ramp_weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_max_ramp_weight.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_max_ramp_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_max_ramp_weight.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_max_ramp_weight.Location = new System.Drawing.Point(119, 17);
			txt_amod_max_ramp_weight.MaxLength = 0;
			txt_amod_max_ramp_weight.Name = "txt_amod_max_ramp_weight";
			txt_amod_max_ramp_weight.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_max_ramp_weight.Size = new System.Drawing.Size(49, 20);
			txt_amod_max_ramp_weight.TabIndex = 258;
			txt_amod_max_ramp_weight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_weight_eow
			// 
			txt_amod_weight_eow.AcceptsReturn = true;
			txt_amod_weight_eow.AllowDrop = true;
			txt_amod_weight_eow.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_weight_eow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_weight_eow.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_weight_eow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_weight_eow.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_weight_eow.Location = new System.Drawing.Point(119, 127);
			txt_amod_weight_eow.MaxLength = 0;
			txt_amod_weight_eow.Name = "txt_amod_weight_eow";
			txt_amod_weight_eow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_weight_eow.Size = new System.Drawing.Size(49, 20);
			txt_amod_weight_eow.TabIndex = 257;
			txt_amod_weight_eow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _lbl_specs_31
			// 
			_lbl_specs_31.AllowDrop = true;
			_lbl_specs_31.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_31.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_31.Location = new System.Drawing.Point(32, 107);
			_lbl_specs_31.MinimumSize = new System.Drawing.Size(76, 17);
			_lbl_specs_31.Name = "_lbl_specs_31";
			_lbl_specs_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_31.Size = new System.Drawing.Size(76, 17);
			_lbl_specs_31.TabIndex = 268;
			_lbl_specs_31.Text = "Max Landing:";
			_lbl_specs_31.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_31.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_30
			// 
			_lbl_specs_30.AllowDrop = true;
			_lbl_specs_30.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_30.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_30.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_30.Location = new System.Drawing.Point(32, 87);
			_lbl_specs_30.MinimumSize = new System.Drawing.Size(83, 17);
			_lbl_specs_30.Name = "_lbl_specs_30";
			_lbl_specs_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_30.Size = new System.Drawing.Size(83, 17);
			_lbl_specs_30.TabIndex = 267;
			_lbl_specs_30.Text = "Basic Operating:";
			_lbl_specs_30.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_30.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_29
			// 
			_lbl_specs_29.AllowDrop = true;
			_lbl_specs_29.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_29.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_29.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_29.Location = new System.Drawing.Point(32, 64);
			_lbl_specs_29.MinimumSize = new System.Drawing.Size(63, 17);
			_lbl_specs_29.Name = "_lbl_specs_29";
			_lbl_specs_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_29.Size = new System.Drawing.Size(63, 17);
			_lbl_specs_29.TabIndex = 266;
			_lbl_specs_29.Text = "Zero Fuel:";
			_lbl_specs_29.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_29.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_28
			// 
			_lbl_specs_28.AllowDrop = true;
			_lbl_specs_28.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_28.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_28.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_28.Location = new System.Drawing.Point(32, 43);
			_lbl_specs_28.MinimumSize = new System.Drawing.Size(73, 17);
			_lbl_specs_28.Name = "_lbl_specs_28";
			_lbl_specs_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_28.Size = new System.Drawing.Size(73, 17);
			_lbl_specs_28.TabIndex = 265;
			_lbl_specs_28.Text = "Max Takeoff:";
			_lbl_specs_28.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_28.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_27
			// 
			_lbl_specs_27.AllowDrop = true;
			_lbl_specs_27.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_27.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_27.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_27.Location = new System.Drawing.Point(32, 18);
			_lbl_specs_27.MinimumSize = new System.Drawing.Size(65, 17);
			_lbl_specs_27.Name = "_lbl_specs_27";
			_lbl_specs_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_27.Size = new System.Drawing.Size(65, 17);
			_lbl_specs_27.TabIndex = 264;
			_lbl_specs_27.Text = "Max Ramp:";
			_lbl_specs_27.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_27.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_63
			// 
			_lbl_specs_63.AllowDrop = true;
			_lbl_specs_63.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_63.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_63.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_63.Location = new System.Drawing.Point(5, 130);
			_lbl_specs_63.MinimumSize = new System.Drawing.Size(118, 17);
			_lbl_specs_63.Name = "_lbl_specs_63";
			_lbl_specs_63.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_63.Size = new System.Drawing.Size(118, 17);
			_lbl_specs_63.TabIndex = 263;
			_lbl_specs_63.Text = "Empty Operating(EOW):";
			_lbl_specs_63.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_63.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// pnl_FuelCapacity
			// 
			pnl_FuelCapacity.AllowDrop = true;
			pnl_FuelCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_FuelCapacity.Controls.Add(txt_amod_fuel_cap_opt_gal);
			pnl_FuelCapacity.Controls.Add(txt_amod_fuel_cap_std_gal);
			pnl_FuelCapacity.Controls.Add(txt_amod_fuel_cap_opt_weight);
			pnl_FuelCapacity.Controls.Add(txt_amod_fuel_cap_std_weight);
			pnl_FuelCapacity.Controls.Add(_lbl_specs_12);
			pnl_FuelCapacity.Controls.Add(_lbl_specs_10);
			pnl_FuelCapacity.Controls.Add(_lbl_specs_11);
			pnl_FuelCapacity.Controls.Add(_lbl_specs_9);
			pnl_FuelCapacity.Controls.Add(_lbl_specs_8);
			pnl_FuelCapacity.Controls.Add(_lbl_specs_7);
			pnl_FuelCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_FuelCapacity.Location = new System.Drawing.Point(544, 374);
			pnl_FuelCapacity.Name = "pnl_FuelCapacity";
			pnl_FuelCapacity.Size = new System.Drawing.Size(209, 77);
			pnl_FuelCapacity.TabIndex = 245;
			// 
			// txt_amod_fuel_cap_opt_gal
			// 
			txt_amod_fuel_cap_opt_gal.AcceptsReturn = true;
			txt_amod_fuel_cap_opt_gal.AllowDrop = true;
			txt_amod_fuel_cap_opt_gal.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_fuel_cap_opt_gal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_fuel_cap_opt_gal.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_fuel_cap_opt_gal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_fuel_cap_opt_gal.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_fuel_cap_opt_gal.Location = new System.Drawing.Point(130, 46);
			txt_amod_fuel_cap_opt_gal.MaxLength = 0;
			txt_amod_fuel_cap_opt_gal.Name = "txt_amod_fuel_cap_opt_gal";
			txt_amod_fuel_cap_opt_gal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_fuel_cap_opt_gal.Size = new System.Drawing.Size(49, 19);
			txt_amod_fuel_cap_opt_gal.TabIndex = 249;
			txt_amod_fuel_cap_opt_gal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_fuel_cap_std_gal
			// 
			txt_amod_fuel_cap_std_gal.AcceptsReturn = true;
			txt_amod_fuel_cap_std_gal.AllowDrop = true;
			txt_amod_fuel_cap_std_gal.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_fuel_cap_std_gal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_fuel_cap_std_gal.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_fuel_cap_std_gal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_fuel_cap_std_gal.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_fuel_cap_std_gal.Location = new System.Drawing.Point(130, 24);
			txt_amod_fuel_cap_std_gal.MaxLength = 0;
			txt_amod_fuel_cap_std_gal.Name = "txt_amod_fuel_cap_std_gal";
			txt_amod_fuel_cap_std_gal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_fuel_cap_std_gal.Size = new System.Drawing.Size(49, 19);
			txt_amod_fuel_cap_std_gal.TabIndex = 248;
			txt_amod_fuel_cap_std_gal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_fuel_cap_opt_weight
			// 
			txt_amod_fuel_cap_opt_weight.AcceptsReturn = true;
			txt_amod_fuel_cap_opt_weight.AllowDrop = true;
			txt_amod_fuel_cap_opt_weight.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_fuel_cap_opt_weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_fuel_cap_opt_weight.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_fuel_cap_opt_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_fuel_cap_opt_weight.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_fuel_cap_opt_weight.Location = new System.Drawing.Point(58, 46);
			txt_amod_fuel_cap_opt_weight.MaxLength = 0;
			txt_amod_fuel_cap_opt_weight.Name = "txt_amod_fuel_cap_opt_weight";
			txt_amod_fuel_cap_opt_weight.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_fuel_cap_opt_weight.Size = new System.Drawing.Size(49, 19);
			txt_amod_fuel_cap_opt_weight.TabIndex = 247;
			txt_amod_fuel_cap_opt_weight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_fuel_cap_std_weight
			// 
			txt_amod_fuel_cap_std_weight.AcceptsReturn = true;
			txt_amod_fuel_cap_std_weight.AllowDrop = true;
			txt_amod_fuel_cap_std_weight.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_fuel_cap_std_weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_fuel_cap_std_weight.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_fuel_cap_std_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_fuel_cap_std_weight.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_fuel_cap_std_weight.Location = new System.Drawing.Point(58, 24);
			txt_amod_fuel_cap_std_weight.MaxLength = 0;
			txt_amod_fuel_cap_std_weight.Name = "txt_amod_fuel_cap_std_weight";
			txt_amod_fuel_cap_std_weight.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_fuel_cap_std_weight.Size = new System.Drawing.Size(49, 19);
			txt_amod_fuel_cap_std_weight.TabIndex = 246;
			txt_amod_fuel_cap_std_weight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _lbl_specs_12
			// 
			_lbl_specs_12.AllowDrop = true;
			_lbl_specs_12.AutoSize = true;
			_lbl_specs_12.BackColor = System.Drawing.Color.Transparent;
			_lbl_specs_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_12.Location = new System.Drawing.Point(184, 49);
			_lbl_specs_12.MinimumSize = new System.Drawing.Size(14, 13);
			_lbl_specs_12.Name = "_lbl_specs_12";
			_lbl_specs_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_12.Size = new System.Drawing.Size(14, 13);
			_lbl_specs_12.TabIndex = 255;
			_lbl_specs_12.Text = "gal";
			_lbl_specs_12.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_12.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_10
			// 
			_lbl_specs_10.AllowDrop = true;
			_lbl_specs_10.AutoSize = true;
			_lbl_specs_10.BackColor = System.Drawing.Color.Transparent;
			_lbl_specs_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_10.Location = new System.Drawing.Point(112, 49);
			_lbl_specs_10.MinimumSize = new System.Drawing.Size(13, 13);
			_lbl_specs_10.Name = "_lbl_specs_10";
			_lbl_specs_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_10.Size = new System.Drawing.Size(13, 13);
			_lbl_specs_10.TabIndex = 254;
			_lbl_specs_10.Text = "lbs";
			_lbl_specs_10.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_10.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_11
			// 
			_lbl_specs_11.AllowDrop = true;
			_lbl_specs_11.AutoSize = true;
			_lbl_specs_11.BackColor = System.Drawing.Color.Transparent;
			_lbl_specs_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_11.Location = new System.Drawing.Point(184, 27);
			_lbl_specs_11.MinimumSize = new System.Drawing.Size(14, 13);
			_lbl_specs_11.Name = "_lbl_specs_11";
			_lbl_specs_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_11.Size = new System.Drawing.Size(14, 13);
			_lbl_specs_11.TabIndex = 253;
			_lbl_specs_11.Text = "gal";
			_lbl_specs_11.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_11.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_9
			// 
			_lbl_specs_9.AllowDrop = true;
			_lbl_specs_9.AutoSize = true;
			_lbl_specs_9.BackColor = System.Drawing.Color.Transparent;
			_lbl_specs_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_9.Location = new System.Drawing.Point(112, 27);
			_lbl_specs_9.MinimumSize = new System.Drawing.Size(13, 13);
			_lbl_specs_9.Name = "_lbl_specs_9";
			_lbl_specs_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_9.Size = new System.Drawing.Size(13, 13);
			_lbl_specs_9.TabIndex = 252;
			_lbl_specs_9.Text = "lbs";
			_lbl_specs_9.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_9.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_8
			// 
			_lbl_specs_8.AllowDrop = true;
			_lbl_specs_8.AutoSize = true;
			_lbl_specs_8.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_8.Location = new System.Drawing.Point(10, 49);
			_lbl_specs_8.MinimumSize = new System.Drawing.Size(42, 13);
			_lbl_specs_8.Name = "_lbl_specs_8";
			_lbl_specs_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_8.Size = new System.Drawing.Size(42, 13);
			_lbl_specs_8.TabIndex = 251;
			_lbl_specs_8.Text = "Optional:";
			_lbl_specs_8.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_8.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_7
			// 
			_lbl_specs_7.AllowDrop = true;
			_lbl_specs_7.AutoSize = true;
			_lbl_specs_7.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_7.Location = new System.Drawing.Point(6, 27);
			_lbl_specs_7.MinimumSize = new System.Drawing.Size(46, 13);
			_lbl_specs_7.Name = "_lbl_specs_7";
			_lbl_specs_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_7.Size = new System.Drawing.Size(46, 13);
			_lbl_specs_7.TabIndex = 250;
			_lbl_specs_7.Text = "Standard:";
			_lbl_specs_7.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_7.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// pnl_EngineData
			// 
			pnl_EngineData.AllowDrop = true;
			pnl_EngineData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_EngineData.Controls.Add(_cmd_button_0);
			pnl_EngineData.Controls.Add(cbo_tbo_list);
			pnl_EngineData.Controls.Add(chk_oncondtbox);
			pnl_EngineData.Controls.Add(txt_amod_engine_hsi);
			pnl_EngineData.Controls.Add(txt_amod_engine_shaft);
			pnl_EngineData.Controls.Add(txt_amod_engine_thrust_lbs);
			pnl_EngineData.Controls.Add(txt_amod_number_of_engines);
			pnl_EngineData.Controls.Add(lst_Spec_Engines);
			pnl_EngineData.Controls.Add(cmd_Add_Engine);
			pnl_EngineData.Controls.Add(cmd_Remove_Engine);
			pnl_EngineData.Controls.Add(_lbl_specs_34);
			pnl_EngineData.Controls.Add(_lbl_specs_21);
			pnl_EngineData.Controls.Add(_lbl_specs_19);
			pnl_EngineData.Controls.Add(_lbl_specs_18);
			pnl_EngineData.Controls.Add(_lbl_specs_17);
			pnl_EngineData.Controls.Add(_lbl_specs_16);
			pnl_EngineData.Controls.Add(_lbl_specs_35);
			pnl_EngineData.Controls.Add(Label22);
			pnl_EngineData.Controls.Add(Label21);
			pnl_EngineData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_EngineData.Location = new System.Drawing.Point(6, 6);
			pnl_EngineData.Name = "pnl_EngineData";
			pnl_EngineData.Size = new System.Drawing.Size(269, 209);
			pnl_EngineData.TabIndex = 190;
			// 
			// _cmd_button_0
			// 
			_cmd_button_0.AllowDrop = true;
			_cmd_button_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_button_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_button_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_button_0.Location = new System.Drawing.Point(160, 164);
			_cmd_button_0.Name = "_cmd_button_0";
			_cmd_button_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_button_0.Size = new System.Drawing.Size(93, 40);
			_cmd_button_0.TabIndex = 417;
			_cmd_button_0.Text = "Show Cabin Dimensions";
			_cmd_button_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_button_0.UseVisualStyleBackColor = false;
			_cmd_button_0.Click += new System.EventHandler(cmd_button_Click);
			// 
			// cbo_tbo_list
			// 
			cbo_tbo_list.AllowDrop = true;
			cbo_tbo_list.BackColor = System.Drawing.SystemColors.Window;
			cbo_tbo_list.CausesValidation = true;
			cbo_tbo_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_tbo_list.Enabled = true;
			cbo_tbo_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_tbo_list.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_tbo_list.IntegralHeight = true;
			cbo_tbo_list.Location = new System.Drawing.Point(107, 142);
			cbo_tbo_list.Name = "cbo_tbo_list";
			cbo_tbo_list.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_tbo_list.Size = new System.Drawing.Size(64, 21);
			cbo_tbo_list.Sorted = false;
			cbo_tbo_list.TabIndex = 197;
			cbo_tbo_list.TabStop = true;
			cbo_tbo_list.Visible = false;
			cbo_tbo_list.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cbo_tbo_list_KeyPress);
			// 
			// chk_oncondtbox
			// 
			chk_oncondtbox.AllowDrop = true;
			chk_oncondtbox.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_oncondtbox.BackColor = System.Drawing.SystemColors.Control;
			chk_oncondtbox.CausesValidation = true;
			chk_oncondtbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_oncondtbox.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_oncondtbox.Enabled = true;
			chk_oncondtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_oncondtbox.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_oncondtbox.Location = new System.Drawing.Point(152, 120);
			chk_oncondtbox.Name = "chk_oncondtbox";
			chk_oncondtbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_oncondtbox.Size = new System.Drawing.Size(116, 19);
			chk_oncondtbox.TabIndex = 196;
			chk_oncondtbox.TabStop = true;
			chk_oncondtbox.Text = "On Condition TBO?";
			chk_oncondtbox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_oncondtbox.Visible = true;
			chk_oncondtbox.CheckStateChanged += new System.EventHandler(chk_oncondtbox_CheckStateChanged);
			// 
			// txt_amod_engine_hsi
			// 
			txt_amod_engine_hsi.AcceptsReturn = true;
			txt_amod_engine_hsi.AllowDrop = true;
			txt_amod_engine_hsi.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_engine_hsi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_engine_hsi.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_engine_hsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_engine_hsi.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_engine_hsi.Location = new System.Drawing.Point(107, 187);
			txt_amod_engine_hsi.MaxLength = 0;
			txt_amod_engine_hsi.Name = "txt_amod_engine_hsi";
			txt_amod_engine_hsi.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_engine_hsi.Size = new System.Drawing.Size(41, 19);
			txt_amod_engine_hsi.TabIndex = 199;
			txt_amod_engine_hsi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_engine_shaft
			// 
			txt_amod_engine_shaft.AcceptsReturn = true;
			txt_amod_engine_shaft.AllowDrop = true;
			txt_amod_engine_shaft.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_engine_shaft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_engine_shaft.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_engine_shaft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_engine_shaft.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_engine_shaft.Location = new System.Drawing.Point(107, 166);
			txt_amod_engine_shaft.MaxLength = 0;
			txt_amod_engine_shaft.Name = "txt_amod_engine_shaft";
			txt_amod_engine_shaft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_engine_shaft.Size = new System.Drawing.Size(41, 19);
			txt_amod_engine_shaft.TabIndex = 198;
			txt_amod_engine_shaft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_engine_thrust_lbs
			// 
			txt_amod_engine_thrust_lbs.AcceptsReturn = true;
			txt_amod_engine_thrust_lbs.AllowDrop = true;
			txt_amod_engine_thrust_lbs.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_engine_thrust_lbs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_engine_thrust_lbs.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_engine_thrust_lbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_engine_thrust_lbs.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_engine_thrust_lbs.Location = new System.Drawing.Point(107, 120);
			txt_amod_engine_thrust_lbs.MaxLength = 0;
			txt_amod_engine_thrust_lbs.Name = "txt_amod_engine_thrust_lbs";
			txt_amod_engine_thrust_lbs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_engine_thrust_lbs.Size = new System.Drawing.Size(41, 19);
			txt_amod_engine_thrust_lbs.TabIndex = 195;
			txt_amod_engine_thrust_lbs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_number_of_engines
			// 
			txt_amod_number_of_engines.AcceptsReturn = true;
			txt_amod_number_of_engines.AllowDrop = true;
			txt_amod_number_of_engines.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_number_of_engines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_number_of_engines.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_number_of_engines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_number_of_engines.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_number_of_engines.Location = new System.Drawing.Point(54, 21);
			txt_amod_number_of_engines.MaxLength = 0;
			txt_amod_number_of_engines.Name = "txt_amod_number_of_engines";
			txt_amod_number_of_engines.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_number_of_engines.Size = new System.Drawing.Size(33, 19);
			txt_amod_number_of_engines.TabIndex = 194;
			txt_amod_number_of_engines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lst_Spec_Engines
			// 
			lst_Spec_Engines.AllowDrop = true;
			lst_Spec_Engines.BackColor = System.Drawing.SystemColors.Window;
			lst_Spec_Engines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Spec_Engines.CausesValidation = true;
			lst_Spec_Engines.Enabled = true;
			lst_Spec_Engines.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Spec_Engines.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Spec_Engines.IntegralHeight = true;
			lst_Spec_Engines.Location = new System.Drawing.Point(4, 59);
			lst_Spec_Engines.MultiColumn = false;
			lst_Spec_Engines.Name = "lst_Spec_Engines";
			lst_Spec_Engines.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Spec_Engines.Size = new System.Drawing.Size(261, 61);
			lst_Spec_Engines.Sorted = false;
			lst_Spec_Engines.TabIndex = 193;
			lst_Spec_Engines.TabStop = true;
			lst_Spec_Engines.Visible = true;
			lst_Spec_Engines.DoubleClick += new System.EventHandler(lst_Spec_Engines_DoubleClick);
			lst_Spec_Engines.SelectedIndexChanged += new System.EventHandler(lst_Spec_Engines_SelectedIndexChanged);
			// 
			// cmd_Add_Engine
			// 
			cmd_Add_Engine.AllowDrop = true;
			cmd_Add_Engine.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Engine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Engine.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Engine.Location = new System.Drawing.Point(96, 20);
			cmd_Add_Engine.Name = "cmd_Add_Engine";
			cmd_Add_Engine.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Engine.Size = new System.Drawing.Size(65, 21);
			cmd_Add_Engine.TabIndex = 192;
			cmd_Add_Engine.Text = "&Add ";
			cmd_Add_Engine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Engine.UseVisualStyleBackColor = false;
			cmd_Add_Engine.Click += new System.EventHandler(cmd_Add_Engine_Click);
			// 
			// cmd_Remove_Engine
			// 
			cmd_Remove_Engine.AllowDrop = true;
			cmd_Remove_Engine.BackColor = System.Drawing.SystemColors.Control;
			cmd_Remove_Engine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Remove_Engine.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Remove_Engine.Location = new System.Drawing.Point(167, 20);
			cmd_Remove_Engine.Name = "cmd_Remove_Engine";
			cmd_Remove_Engine.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Remove_Engine.Size = new System.Drawing.Size(65, 21);
			cmd_Remove_Engine.TabIndex = 191;
			cmd_Remove_Engine.Text = "&Remove";
			cmd_Remove_Engine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Remove_Engine.UseVisualStyleBackColor = false;
			cmd_Remove_Engine.Click += new System.EventHandler(cmd_Remove_Engine_Click);
			// 
			// _lbl_specs_34
			// 
			_lbl_specs_34.AllowDrop = true;
			_lbl_specs_34.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_34.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_34.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_34.Location = new System.Drawing.Point(214, 44);
			_lbl_specs_34.MinimumSize = new System.Drawing.Size(39, 14);
			_lbl_specs_34.Name = "_lbl_specs_34";
			_lbl_specs_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_34.Size = new System.Drawing.Size(39, 14);
			_lbl_specs_34.TabIndex = 200;
			_lbl_specs_34.Text = "Mfg:";
			_lbl_specs_34.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_specs_34.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_34.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_21
			// 
			_lbl_specs_21.AllowDrop = true;
			_lbl_specs_21.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_21.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_21.Location = new System.Drawing.Point(4, 188);
			_lbl_specs_21.MinimumSize = new System.Drawing.Size(105, 17);
			_lbl_specs_21.Name = "_lbl_specs_21";
			_lbl_specs_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_21.Size = new System.Drawing.Size(105, 17);
			_lbl_specs_21.TabIndex = 208;
			_lbl_specs_21.Text = "HSI:";
			_lbl_specs_21.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_21.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_19
			// 
			_lbl_specs_19.AllowDrop = true;
			_lbl_specs_19.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_19.Location = new System.Drawing.Point(4, 167);
			_lbl_specs_19.MinimumSize = new System.Drawing.Size(105, 17);
			_lbl_specs_19.Name = "_lbl_specs_19";
			_lbl_specs_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_19.Size = new System.Drawing.Size(105, 17);
			_lbl_specs_19.TabIndex = 207;
			_lbl_specs_19.Text = "Shaft HP Per Engine:";
			_lbl_specs_19.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_19.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_18
			// 
			_lbl_specs_18.AllowDrop = true;
			_lbl_specs_18.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_18.Location = new System.Drawing.Point(4, 145);
			_lbl_specs_18.MinimumSize = new System.Drawing.Size(111, 17);
			_lbl_specs_18.Name = "_lbl_specs_18";
			_lbl_specs_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_18.Size = new System.Drawing.Size(111, 17);
			_lbl_specs_18.TabIndex = 206;
			_lbl_specs_18.Text = "Common (TBO) Hrs:";
			_lbl_specs_18.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_18.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_17
			// 
			_lbl_specs_17.AllowDrop = true;
			_lbl_specs_17.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_17.Location = new System.Drawing.Point(4, 120);
			_lbl_specs_17.MinimumSize = new System.Drawing.Size(89, 17);
			_lbl_specs_17.Name = "_lbl_specs_17";
			_lbl_specs_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_17.Size = new System.Drawing.Size(89, 17);
			_lbl_specs_17.TabIndex = 205;
			_lbl_specs_17.Text = "Thrust Per Engine:";
			_lbl_specs_17.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_17.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_16
			// 
			_lbl_specs_16.AllowDrop = true;
			_lbl_specs_16.AutoSize = true;
			_lbl_specs_16.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_16.Location = new System.Drawing.Point(4, 24);
			_lbl_specs_16.MinimumSize = new System.Drawing.Size(40, 13);
			_lbl_specs_16.Name = "_lbl_specs_16";
			_lbl_specs_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_16.Size = new System.Drawing.Size(40, 13);
			_lbl_specs_16.TabIndex = 204;
			_lbl_specs_16.Text = "Number:";
			_lbl_specs_16.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_16.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_35
			// 
			_lbl_specs_35.AllowDrop = true;
			_lbl_specs_35.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_35.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_35.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_35.Location = new System.Drawing.Point(4, 44);
			_lbl_specs_35.MinimumSize = new System.Drawing.Size(73, 14);
			_lbl_specs_35.Name = "_lbl_specs_35";
			_lbl_specs_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_35.Size = new System.Drawing.Size(73, 14);
			_lbl_specs_35.TabIndex = 203;
			_lbl_specs_35.Text = "Engines:";
			_lbl_specs_35.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_35.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// Label22
			// 
			Label22.AllowDrop = true;
			Label22.BackColor = System.Drawing.SystemColors.Control;
			Label22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label22.ForeColor = System.Drawing.SystemColors.ControlText;
			Label22.Location = new System.Drawing.Point(152, 56);
			Label22.MinimumSize = new System.Drawing.Size(49, 1);
			Label22.Name = "Label22";
			Label22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label22.Size = new System.Drawing.Size(49, 1);
			Label22.TabIndex = 202;
			Label22.Text = "Label10";
			// 
			// Label21
			// 
			Label21.AllowDrop = true;
			Label21.BackColor = System.Drawing.SystemColors.Control;
			Label21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label21.ForeColor = System.Drawing.SystemColors.ControlText;
			Label21.Location = new System.Drawing.Point(128, 56);
			Label21.MinimumSize = new System.Drawing.Size(17, 1);
			Label21.Name = "Label21";
			Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label21.Size = new System.Drawing.Size(17, 1);
			Label21.TabIndex = 201;
			Label21.Text = "Label13";
			// 
			// pnl_ConfigNote
			// 
			pnl_ConfigNote.AllowDrop = true;
			pnl_ConfigNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_ConfigNote.Controls.Add(txt_amod_other_config_note);
			pnl_ConfigNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_ConfigNote.Location = new System.Drawing.Point(6, 359);
			pnl_ConfigNote.Name = "pnl_ConfigNote";
			pnl_ConfigNote.Size = new System.Drawing.Size(518, 129);
			pnl_ConfigNote.TabIndex = 156;
			// 
			// txt_amod_other_config_note
			// 
			txt_amod_other_config_note.AcceptsReturn = true;
			txt_amod_other_config_note.AllowDrop = true;
			txt_amod_other_config_note.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_other_config_note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_other_config_note.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_other_config_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_other_config_note.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_other_config_note.Location = new System.Drawing.Point(8, 24);
			txt_amod_other_config_note.MaxLength = 500;
			txt_amod_other_config_note.Multiline = true;
			txt_amod_other_config_note.Name = "txt_amod_other_config_note";
			txt_amod_other_config_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_other_config_note.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txt_amod_other_config_note.Size = new System.Drawing.Size(500, 97);
			txt_amod_other_config_note.TabIndex = 157;
			// 
			// pnl_Aircraft_Model_Engine_Add
			// 
			pnl_Aircraft_Model_Engine_Add.AllowDrop = true;
			pnl_Aircraft_Model_Engine_Add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Aircraft_Model_Engine_Add.Controls.Add(cmdFindEngineModel);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(txt_ameng_mfr_name_short);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(txt_ameng_mfr_CompID);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(txt_ameng_seq_no);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(txt_ameng_max_continuous_power);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(txt_ameng_takeoff_power);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(Chk_ameng_active_flag);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(cmd_Engine_Cancel);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(txt_ameng_mfr_name);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(txt_ameng_engine_prefix);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(txt_ameng_engine_core);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(txt_ameng_engine_suffix1);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(txt_ameng_engine_suffix2);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(cmd_Engine_Save);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(_lbl_specs_93);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(_Label6_25);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(_lbl_specs_68);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(_lbl_specs_67);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(_lbl_specs_33);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(_lbl_specs_32);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(_lbl_specs_26);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(_lbl_specs_20);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(_lbl_specs_22);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(_lbl_specs_23);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(_lbl_specs_24);
			pnl_Aircraft_Model_Engine_Add.Controls.Add(_lbl_specs_25);
			pnl_Aircraft_Model_Engine_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Aircraft_Model_Engine_Add.Location = new System.Drawing.Point(6, 239);
			pnl_Aircraft_Model_Engine_Add.Name = "pnl_Aircraft_Model_Engine_Add";
			pnl_Aircraft_Model_Engine_Add.Size = new System.Drawing.Size(490, 113);
			pnl_Aircraft_Model_Engine_Add.TabIndex = 144;
			pnl_Aircraft_Model_Engine_Add.Visible = false;
			// 
			// cmdFindEngineModel
			// 
			cmdFindEngineModel.AllowDrop = true;
			cmdFindEngineModel.BackColor = System.Drawing.SystemColors.Control;
			cmdFindEngineModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFindEngineModel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFindEngineModel.Location = new System.Drawing.Point(88, 20);
			cmdFindEngineModel.Name = "cmdFindEngineModel";
			cmdFindEngineModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFindEngineModel.Size = new System.Drawing.Size(113, 21);
			cmdFindEngineModel.TabIndex = 434;
			cmdFindEngineModel.Text = "Find Engine Model";
			cmdFindEngineModel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFindEngineModel.UseVisualStyleBackColor = false;
			cmdFindEngineModel.Click += new System.EventHandler(cmdFindEngineModel_Click);
			// 
			// txt_ameng_mfr_name_short
			// 
			txt_ameng_mfr_name_short.AcceptsReturn = true;
			txt_ameng_mfr_name_short.AllowDrop = true;
			txt_ameng_mfr_name_short.BackColor = System.Drawing.SystemColors.Window;
			txt_ameng_mfr_name_short.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ameng_mfr_name_short.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ameng_mfr_name_short.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ameng_mfr_name_short.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ameng_mfr_name_short.Location = new System.Drawing.Point(259, 43);
			txt_ameng_mfr_name_short.MaxLength = 4;
			txt_ameng_mfr_name_short.Name = "txt_ameng_mfr_name_short";
			txt_ameng_mfr_name_short.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ameng_mfr_name_short.Size = new System.Drawing.Size(53, 19);
			txt_ameng_mfr_name_short.TabIndex = 364;
			// 
			// txt_ameng_mfr_CompID
			// 
			txt_ameng_mfr_CompID.AcceptsReturn = true;
			txt_ameng_mfr_CompID.AllowDrop = true;
			txt_ameng_mfr_CompID.BackColor = System.Drawing.SystemColors.Window;
			txt_ameng_mfr_CompID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ameng_mfr_CompID.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ameng_mfr_CompID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ameng_mfr_CompID.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ameng_mfr_CompID.Location = new System.Drawing.Point(251, 11);
			txt_ameng_mfr_CompID.MaxLength = 0;
			txt_ameng_mfr_CompID.Name = "txt_ameng_mfr_CompID";
			txt_ameng_mfr_CompID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ameng_mfr_CompID.Size = new System.Drawing.Size(64, 19);
			txt_ameng_mfr_CompID.TabIndex = 362;
			txt_ameng_mfr_CompID.Text = "0";
			txt_ameng_mfr_CompID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_ameng_seq_no
			// 
			txt_ameng_seq_no.AcceptsReturn = true;
			txt_ameng_seq_no.AllowDrop = true;
			txt_ameng_seq_no.BackColor = System.Drawing.SystemColors.Window;
			txt_ameng_seq_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ameng_seq_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ameng_seq_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ameng_seq_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ameng_seq_no.Location = new System.Drawing.Point(439, 89);
			txt_ameng_seq_no.MaxLength = 0;
			txt_ameng_seq_no.Name = "txt_ameng_seq_no";
			txt_ameng_seq_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ameng_seq_no.Size = new System.Drawing.Size(35, 19);
			txt_ameng_seq_no.TabIndex = 233;
			// 
			// txt_ameng_max_continuous_power
			// 
			txt_ameng_max_continuous_power.AcceptsReturn = true;
			txt_ameng_max_continuous_power.AllowDrop = true;
			txt_ameng_max_continuous_power.BackColor = System.Drawing.SystemColors.Window;
			txt_ameng_max_continuous_power.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ameng_max_continuous_power.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ameng_max_continuous_power.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ameng_max_continuous_power.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ameng_max_continuous_power.Location = new System.Drawing.Point(381, 89);
			txt_ameng_max_continuous_power.MaxLength = 0;
			txt_ameng_max_continuous_power.Name = "txt_ameng_max_continuous_power";
			txt_ameng_max_continuous_power.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ameng_max_continuous_power.Size = new System.Drawing.Size(48, 19);
			txt_ameng_max_continuous_power.TabIndex = 231;
			txt_ameng_max_continuous_power.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_ameng_takeoff_power
			// 
			txt_ameng_takeoff_power.AcceptsReturn = true;
			txt_ameng_takeoff_power.AllowDrop = true;
			txt_ameng_takeoff_power.BackColor = System.Drawing.SystemColors.Window;
			txt_ameng_takeoff_power.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ameng_takeoff_power.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ameng_takeoff_power.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ameng_takeoff_power.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ameng_takeoff_power.Location = new System.Drawing.Point(327, 89);
			txt_ameng_takeoff_power.MaxLength = 0;
			txt_ameng_takeoff_power.Name = "txt_ameng_takeoff_power";
			txt_ameng_takeoff_power.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ameng_takeoff_power.Size = new System.Drawing.Size(44, 19);
			txt_ameng_takeoff_power.TabIndex = 230;
			txt_ameng_takeoff_power.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Chk_ameng_active_flag
			// 
			Chk_ameng_active_flag.AllowDrop = true;
			Chk_ameng_active_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			Chk_ameng_active_flag.BackColor = System.Drawing.SystemColors.Control;
			Chk_ameng_active_flag.CausesValidation = true;
			Chk_ameng_active_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			Chk_ameng_active_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			Chk_ameng_active_flag.Enabled = true;
			Chk_ameng_active_flag.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Chk_ameng_active_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			Chk_ameng_active_flag.Location = new System.Drawing.Point(291, 91);
			Chk_ameng_active_flag.Name = "Chk_ameng_active_flag";
			Chk_ameng_active_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Chk_ameng_active_flag.Size = new System.Drawing.Size(16, 15);
			Chk_ameng_active_flag.TabIndex = 225;
			Chk_ameng_active_flag.TabStop = true;
			Chk_ameng_active_flag.Text = "Active?";
			Chk_ameng_active_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_ameng_active_flag.Visible = true;
			// 
			// cmd_Engine_Cancel
			// 
			cmd_Engine_Cancel.AllowDrop = true;
			cmd_Engine_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Engine_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Engine_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Engine_Cancel.Location = new System.Drawing.Point(429, 5);
			cmd_Engine_Cancel.Name = "cmd_Engine_Cancel";
			cmd_Engine_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Engine_Cancel.Size = new System.Drawing.Size(52, 25);
			cmd_Engine_Cancel.TabIndex = 159;
			cmd_Engine_Cancel.Text = "&Cancel";
			cmd_Engine_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Engine_Cancel.UseVisualStyleBackColor = false;
			cmd_Engine_Cancel.Click += new System.EventHandler(cmd_Engine_Cancel_Click);
			// 
			// txt_ameng_mfr_name
			// 
			txt_ameng_mfr_name.AcceptsReturn = true;
			txt_ameng_mfr_name.AllowDrop = true;
			txt_ameng_mfr_name.BackColor = System.Drawing.SystemColors.Window;
			txt_ameng_mfr_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ameng_mfr_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ameng_mfr_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ameng_mfr_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ameng_mfr_name.Location = new System.Drawing.Point(8, 43);
			txt_ameng_mfr_name.MaxLength = 100;
			txt_ameng_mfr_name.Name = "txt_ameng_mfr_name";
			txt_ameng_mfr_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ameng_mfr_name.Size = new System.Drawing.Size(194, 19);
			txt_ameng_mfr_name.TabIndex = 146;
			txt_ameng_mfr_name.Click += new System.EventHandler(txt_ameng_mfr_name_Click);
			// 
			// txt_ameng_engine_prefix
			// 
			txt_ameng_engine_prefix.AcceptsReturn = true;
			txt_ameng_engine_prefix.AllowDrop = true;
			txt_ameng_engine_prefix.BackColor = System.Drawing.SystemColors.Window;
			txt_ameng_engine_prefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ameng_engine_prefix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ameng_engine_prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ameng_engine_prefix.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ameng_engine_prefix.Location = new System.Drawing.Point(7, 89);
			txt_ameng_engine_prefix.MaxLength = 30;
			txt_ameng_engine_prefix.Name = "txt_ameng_engine_prefix";
			txt_ameng_engine_prefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ameng_engine_prefix.Size = new System.Drawing.Size(56, 19);
			txt_ameng_engine_prefix.TabIndex = 148;
			txt_ameng_engine_prefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_ameng_engine_prefix.Click += new System.EventHandler(txt_ameng_engine_prefix_Click);
			// 
			// txt_ameng_engine_core
			// 
			txt_ameng_engine_core.AcceptsReturn = true;
			txt_ameng_engine_core.AllowDrop = true;
			txt_ameng_engine_core.BackColor = System.Drawing.SystemColors.Window;
			txt_ameng_engine_core.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ameng_engine_core.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ameng_engine_core.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ameng_engine_core.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ameng_engine_core.Location = new System.Drawing.Point(67, 89);
			txt_ameng_engine_core.MaxLength = 30;
			txt_ameng_engine_core.Name = "txt_ameng_engine_core";
			txt_ameng_engine_core.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ameng_engine_core.Size = new System.Drawing.Size(101, 19);
			txt_ameng_engine_core.TabIndex = 150;
			txt_ameng_engine_core.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_ameng_engine_core.Click += new System.EventHandler(txt_ameng_engine_core_Click);
			// 
			// txt_ameng_engine_suffix1
			// 
			txt_ameng_engine_suffix1.AcceptsReturn = true;
			txt_ameng_engine_suffix1.AllowDrop = true;
			txt_ameng_engine_suffix1.BackColor = System.Drawing.SystemColors.Window;
			txt_ameng_engine_suffix1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ameng_engine_suffix1.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ameng_engine_suffix1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ameng_engine_suffix1.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ameng_engine_suffix1.Location = new System.Drawing.Point(173, 89);
			txt_ameng_engine_suffix1.MaxLength = 10;
			txt_ameng_engine_suffix1.Name = "txt_ameng_engine_suffix1";
			txt_ameng_engine_suffix1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ameng_engine_suffix1.Size = new System.Drawing.Size(49, 19);
			txt_ameng_engine_suffix1.TabIndex = 152;
			txt_ameng_engine_suffix1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_ameng_engine_suffix1.Click += new System.EventHandler(txt_ameng_engine_suffix1_Click);
			// 
			// txt_ameng_engine_suffix2
			// 
			txt_ameng_engine_suffix2.AcceptsReturn = true;
			txt_ameng_engine_suffix2.AllowDrop = true;
			txt_ameng_engine_suffix2.BackColor = System.Drawing.SystemColors.Window;
			txt_ameng_engine_suffix2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ameng_engine_suffix2.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ameng_engine_suffix2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ameng_engine_suffix2.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ameng_engine_suffix2.Location = new System.Drawing.Point(227, 89);
			txt_ameng_engine_suffix2.MaxLength = 10;
			txt_ameng_engine_suffix2.Name = "txt_ameng_engine_suffix2";
			txt_ameng_engine_suffix2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ameng_engine_suffix2.Size = new System.Drawing.Size(49, 19);
			txt_ameng_engine_suffix2.TabIndex = 154;
			txt_ameng_engine_suffix2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_ameng_engine_suffix2.Click += new System.EventHandler(txt_ameng_engine_suffix2_Click);
			// 
			// cmd_Engine_Save
			// 
			cmd_Engine_Save.AllowDrop = true;
			cmd_Engine_Save.BackColor = System.Drawing.SystemColors.Control;
			cmd_Engine_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Engine_Save.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Engine_Save.Location = new System.Drawing.Point(327, 2);
			cmd_Engine_Save.Name = "cmd_Engine_Save";
			cmd_Engine_Save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Engine_Save.Size = new System.Drawing.Size(52, 25);
			cmd_Engine_Save.TabIndex = 145;
			cmd_Engine_Save.Text = "&Save";
			cmd_Engine_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Engine_Save.UseVisualStyleBackColor = false;
			cmd_Engine_Save.Click += new System.EventHandler(cmd_Engine_Save_Click);
			// 
			// _lbl_specs_93
			// 
			_lbl_specs_93.AllowDrop = true;
			_lbl_specs_93.AutoSize = true;
			_lbl_specs_93.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_93.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_93.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_93.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_93.Location = new System.Drawing.Point(109, 2);
			_lbl_specs_93.MinimumSize = new System.Drawing.Size(113, 13);
			_lbl_specs_93.Name = "_lbl_specs_93";
			_lbl_specs_93.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_93.Size = new System.Drawing.Size(113, 13);
			_lbl_specs_93.TabIndex = 447;
			_lbl_specs_93.Text = "Engine Model Id: 0";
			_lbl_specs_93.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_93.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _Label6_25
			// 
			_Label6_25.AllowDrop = true;
			_Label6_25.AutoSize = true;
			_Label6_25.BackColor = System.Drawing.Color.Transparent;
			_Label6_25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_25.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_25.Location = new System.Drawing.Point(217, 46);
			_Label6_25.MinimumSize = new System.Drawing.Size(37, 13);
			_Label6_25.Name = "_Label6_25";
			_Label6_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_25.Size = new System.Drawing.Size(37, 13);
			_Label6_25.TabIndex = 365;
			_Label6_25.Text = "Abbrev:";
			// 
			// _lbl_specs_68
			// 
			_lbl_specs_68.AllowDrop = true;
			_lbl_specs_68.AutoSize = true;
			_lbl_specs_68.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_68.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_68.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_68.Location = new System.Drawing.Point(215, 14);
			_lbl_specs_68.MinimumSize = new System.Drawing.Size(32, 13);
			_lbl_specs_68.Name = "_lbl_specs_68";
			_lbl_specs_68.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_68.Size = new System.Drawing.Size(32, 13);
			_lbl_specs_68.TabIndex = 363;
			_lbl_specs_68.Text = "Mfr ID:";
			_lbl_specs_68.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_specs_68.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_68.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_67
			// 
			_lbl_specs_67.AllowDrop = true;
			_lbl_specs_67.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_67.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_67.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_67.Location = new System.Drawing.Point(430, 60);
			_lbl_specs_67.MinimumSize = new System.Drawing.Size(53, 26);
			_lbl_specs_67.Name = "_lbl_specs_67";
			_lbl_specs_67.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_67.Size = new System.Drawing.Size(53, 26);
			_lbl_specs_67.TabIndex = 232;
			_lbl_specs_67.Text = "Seq Number";
			_lbl_specs_67.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_specs_67.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_67.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_33
			// 
			_lbl_specs_33.AllowDrop = true;
			_lbl_specs_33.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_33.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_33.Location = new System.Drawing.Point(323, 47);
			_lbl_specs_33.MinimumSize = new System.Drawing.Size(52, 39);
			_lbl_specs_33.Name = "_lbl_specs_33";
			_lbl_specs_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_33.Size = new System.Drawing.Size(52, 39);
			_lbl_specs_33.TabIndex = 229;
			_lbl_specs_33.Text = "Takeoff Power (SHP):";
			_lbl_specs_33.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_specs_33.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_33.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_32
			// 
			_lbl_specs_32.AllowDrop = true;
			_lbl_specs_32.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_32.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_32.Location = new System.Drawing.Point(377, 32);
			_lbl_specs_32.MinimumSize = new System.Drawing.Size(56, 54);
			_lbl_specs_32.Name = "_lbl_specs_32";
			_lbl_specs_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_32.Size = new System.Drawing.Size(56, 54);
			_lbl_specs_32.TabIndex = 228;
			_lbl_specs_32.Text = "Max Continuous Power (SHP):";
			_lbl_specs_32.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_specs_32.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_32.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_26
			// 
			_lbl_specs_26.AllowDrop = true;
			_lbl_specs_26.AutoSize = true;
			_lbl_specs_26.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_26.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_26.Location = new System.Drawing.Point(282, 73);
			_lbl_specs_26.MinimumSize = new System.Drawing.Size(36, 13);
			_lbl_specs_26.Name = "_lbl_specs_26";
			_lbl_specs_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_26.Size = new System.Drawing.Size(36, 13);
			_lbl_specs_26.TabIndex = 226;
			_lbl_specs_26.Text = "Active?";
			_lbl_specs_26.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_26.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_20
			// 
			_lbl_specs_20.AllowDrop = true;
			_lbl_specs_20.AutoSize = true;
			_lbl_specs_20.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_20.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			_lbl_specs_20.Location = new System.Drawing.Point(8, 25);
			_lbl_specs_20.MinimumSize = new System.Drawing.Size(64, 13);
			_lbl_specs_20.Name = "_lbl_specs_20";
			_lbl_specs_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_20.Size = new System.Drawing.Size(64, 13);
			_lbl_specs_20.TabIndex = 155;
			_lbl_specs_20.Text = "Manufacturer";
			_lbl_specs_20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_specs_20.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_20.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_22
			// 
			_lbl_specs_22.AllowDrop = true;
			_lbl_specs_22.AutoSize = true;
			_lbl_specs_22.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_22.Location = new System.Drawing.Point(7, 73);
			_lbl_specs_22.MinimumSize = new System.Drawing.Size(29, 13);
			_lbl_specs_22.Name = "_lbl_specs_22";
			_lbl_specs_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_22.Size = new System.Drawing.Size(29, 13);
			_lbl_specs_22.TabIndex = 153;
			_lbl_specs_22.Text = "Prefix:";
			_lbl_specs_22.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_22.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_23
			// 
			_lbl_specs_23.AllowDrop = true;
			_lbl_specs_23.AutoSize = true;
			_lbl_specs_23.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_23.Location = new System.Drawing.Point(105, 73);
			_lbl_specs_23.MinimumSize = new System.Drawing.Size(25, 13);
			_lbl_specs_23.Name = "_lbl_specs_23";
			_lbl_specs_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_23.Size = new System.Drawing.Size(25, 13);
			_lbl_specs_23.TabIndex = 151;
			_lbl_specs_23.Text = "Core:";
			_lbl_specs_23.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_23.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_24
			// 
			_lbl_specs_24.AllowDrop = true;
			_lbl_specs_24.AutoSize = true;
			_lbl_specs_24.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_24.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_24.Location = new System.Drawing.Point(179, 73);
			_lbl_specs_24.MinimumSize = new System.Drawing.Size(38, 13);
			_lbl_specs_24.Name = "_lbl_specs_24";
			_lbl_specs_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_24.Size = new System.Drawing.Size(38, 13);
			_lbl_specs_24.TabIndex = 149;
			_lbl_specs_24.Text = "Suffix 1:";
			_lbl_specs_24.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_24.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _lbl_specs_25
			// 
			_lbl_specs_25.AllowDrop = true;
			_lbl_specs_25.AutoSize = true;
			_lbl_specs_25.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_25.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_25.Location = new System.Drawing.Point(233, 73);
			_lbl_specs_25.MinimumSize = new System.Drawing.Size(38, 13);
			_lbl_specs_25.Name = "_lbl_specs_25";
			_lbl_specs_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_25.Size = new System.Drawing.Size(38, 13);
			_lbl_specs_25.TabIndex = 147;
			_lbl_specs_25.Text = "Suffix 2:";
			_lbl_specs_25.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_25.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _tab_Aircraft_Model_TabPage6
			// 
			_tab_Aircraft_Model_TabPage6.Controls.Add(txt_amod_maint_note);
			_tab_Aircraft_Model_TabPage6.Controls.Add(txt_amod_inspection_note);
			_tab_Aircraft_Model_TabPage6.Controls.Add(_Label6_16);
			_tab_Aircraft_Model_TabPage6.Controls.Add(_Label6_17);
			_tab_Aircraft_Model_TabPage6.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage6.Text = "Maintenance";
			// 
			// txt_amod_maint_note
			// 
			txt_amod_maint_note.AcceptsReturn = true;
			txt_amod_maint_note.AllowDrop = true;
			txt_amod_maint_note.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_maint_note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_maint_note.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_maint_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_maint_note.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_maint_note.Location = new System.Drawing.Point(126, 33);
			txt_amod_maint_note.MaxLength = 0;
			txt_amod_maint_note.Multiline = true;
			txt_amod_maint_note.Name = "txt_amod_maint_note";
			txt_amod_maint_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_maint_note.Size = new System.Drawing.Size(537, 21);
			txt_amod_maint_note.TabIndex = 370;
			// 
			// txt_amod_inspection_note
			// 
			txt_amod_inspection_note.AcceptsReturn = true;
			txt_amod_inspection_note.AllowDrop = true;
			txt_amod_inspection_note.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_inspection_note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_inspection_note.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_inspection_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_inspection_note.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_inspection_note.Location = new System.Drawing.Point(126, 65);
			txt_amod_inspection_note.MaxLength = 750;
			txt_amod_inspection_note.Multiline = true;
			txt_amod_inspection_note.Name = "txt_amod_inspection_note";
			txt_amod_inspection_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_inspection_note.Size = new System.Drawing.Size(537, 69);
			txt_amod_inspection_note.TabIndex = 369;
			// 
			// _Label6_16
			// 
			_Label6_16.AllowDrop = true;
			_Label6_16.BackColor = System.Drawing.SystemColors.Control;
			_Label6_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_16.Location = new System.Drawing.Point(6, 33);
			_Label6_16.MinimumSize = new System.Drawing.Size(116, 17);
			_Label6_16.Name = "_Label6_16";
			_Label6_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_16.Size = new System.Drawing.Size(116, 17);
			_Label6_16.TabIndex = 372;
			_Label6_16.Text = "Maintenance Programs:";
			// 
			// _Label6_17
			// 
			_Label6_17.AllowDrop = true;
			_Label6_17.BackColor = System.Drawing.SystemColors.Control;
			_Label6_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_17.Location = new System.Drawing.Point(5, 65);
			_Label6_17.MinimumSize = new System.Drawing.Size(153, 17);
			_Label6_17.Name = "_Label6_17";
			_Label6_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_17.Size = new System.Drawing.Size(153, 17);
			_Label6_17.TabIndex = 371;
			_Label6_17.Text = "Inspections:";
			// 
			// _tab_Aircraft_Model_TabPage7
			// 
			_tab_Aircraft_Model_TabPage7.Controls.Add(txt_amod_upd_user_id);
			_tab_Aircraft_Model_TabPage7.Controls.Add(txt_amod_ent_user_id);
			_tab_Aircraft_Model_TabPage7.Controls.Add(txt_amod_ent_date);
			_tab_Aircraft_Model_TabPage7.Controls.Add(txt_amod_upd_date);
			_tab_Aircraft_Model_TabPage7.Controls.Add(txt_amod_sale_verify_days);
			_tab_Aircraft_Model_TabPage7.Controls.Add(txt_amod_common_verify_days);
			_tab_Aircraft_Model_TabPage7.Controls.Add(chk_amod_customer_flag);
			_tab_Aircraft_Model_TabPage7.Controls.Add(_Label6_21);
			_tab_Aircraft_Model_TabPage7.Controls.Add(_Label6_20);
			_tab_Aircraft_Model_TabPage7.Controls.Add(_Label6_18);
			_tab_Aircraft_Model_TabPage7.Controls.Add(_Label6_19);
			_tab_Aircraft_Model_TabPage7.Controls.Add(_Label6_22);
			_tab_Aircraft_Model_TabPage7.Controls.Add(_Label6_23);
			_tab_Aircraft_Model_TabPage7.Controls.Add(_Label6_24);
			_tab_Aircraft_Model_TabPage7.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage7.Text = "Admin";
			// 
			// txt_amod_upd_user_id
			// 
			txt_amod_upd_user_id.AcceptsReturn = true;
			txt_amod_upd_user_id.AllowDrop = true;
			txt_amod_upd_user_id.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_upd_user_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_upd_user_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_upd_user_id.Enabled = false;
			txt_amod_upd_user_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_upd_user_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_upd_user_id.Location = new System.Drawing.Point(76, 132);
			txt_amod_upd_user_id.MaxLength = 0;
			txt_amod_upd_user_id.Multiline = true;
			txt_amod_upd_user_id.Name = "txt_amod_upd_user_id";
			txt_amod_upd_user_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_upd_user_id.Size = new System.Drawing.Size(33, 23);
			txt_amod_upd_user_id.TabIndex = 379;
			// 
			// txt_amod_ent_user_id
			// 
			txt_amod_ent_user_id.AcceptsReturn = true;
			txt_amod_ent_user_id.AllowDrop = true;
			txt_amod_ent_user_id.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_ent_user_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_ent_user_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_ent_user_id.Enabled = false;
			txt_amod_ent_user_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_ent_user_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_ent_user_id.Location = new System.Drawing.Point(76, 100);
			txt_amod_ent_user_id.MaxLength = 0;
			txt_amod_ent_user_id.Multiline = true;
			txt_amod_ent_user_id.Name = "txt_amod_ent_user_id";
			txt_amod_ent_user_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_ent_user_id.Size = new System.Drawing.Size(33, 23);
			txt_amod_ent_user_id.TabIndex = 378;
			txt_amod_ent_user_id.TextChanged += new System.EventHandler(txt_amod_ent_user_id_TextChanged);
			// 
			// txt_amod_ent_date
			// 
			txt_amod_ent_date.AcceptsReturn = true;
			txt_amod_ent_date.AllowDrop = true;
			txt_amod_ent_date.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_ent_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_ent_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_ent_date.Enabled = false;
			txt_amod_ent_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_ent_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_ent_date.Location = new System.Drawing.Point(148, 100);
			txt_amod_ent_date.MaxLength = 0;
			txt_amod_ent_date.Name = "txt_amod_ent_date";
			txt_amod_ent_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_ent_date.Size = new System.Drawing.Size(127, 21);
			txt_amod_ent_date.TabIndex = 377;
			// 
			// txt_amod_upd_date
			// 
			txt_amod_upd_date.AcceptsReturn = true;
			txt_amod_upd_date.AllowDrop = true;
			txt_amod_upd_date.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_upd_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_upd_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_upd_date.Enabled = false;
			txt_amod_upd_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_upd_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_upd_date.Location = new System.Drawing.Point(148, 132);
			txt_amod_upd_date.MaxLength = 0;
			txt_amod_upd_date.Name = "txt_amod_upd_date";
			txt_amod_upd_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_upd_date.Size = new System.Drawing.Size(127, 21);
			txt_amod_upd_date.TabIndex = 376;
			// 
			// txt_amod_sale_verify_days
			// 
			txt_amod_sale_verify_days.AcceptsReturn = true;
			txt_amod_sale_verify_days.AllowDrop = true;
			txt_amod_sale_verify_days.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_sale_verify_days.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_sale_verify_days.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_sale_verify_days.Enabled = false;
			txt_amod_sale_verify_days.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_sale_verify_days.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_sale_verify_days.Location = new System.Drawing.Point(148, 220);
			txt_amod_sale_verify_days.MaxLength = 0;
			txt_amod_sale_verify_days.Name = "txt_amod_sale_verify_days";
			txt_amod_sale_verify_days.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_sale_verify_days.Size = new System.Drawing.Size(25, 25);
			txt_amod_sale_verify_days.TabIndex = 375;
			txt_amod_sale_verify_days.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_amod_common_verify_days
			// 
			txt_amod_common_verify_days.AcceptsReturn = true;
			txt_amod_common_verify_days.AllowDrop = true;
			txt_amod_common_verify_days.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_common_verify_days.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_common_verify_days.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_common_verify_days.Enabled = false;
			txt_amod_common_verify_days.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_common_verify_days.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_common_verify_days.Location = new System.Drawing.Point(148, 188);
			txt_amod_common_verify_days.MaxLength = 0;
			txt_amod_common_verify_days.Name = "txt_amod_common_verify_days";
			txt_amod_common_verify_days.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_common_verify_days.Size = new System.Drawing.Size(25, 25);
			txt_amod_common_verify_days.TabIndex = 374;
			txt_amod_common_verify_days.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chk_amod_customer_flag
			// 
			chk_amod_customer_flag.AllowDrop = true;
			chk_amod_customer_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_amod_customer_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_amod_customer_flag.CausesValidation = true;
			chk_amod_customer_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_amod_customer_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_amod_customer_flag.Enabled = true;
			chk_amod_customer_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_amod_customer_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_amod_customer_flag.Location = new System.Drawing.Point(93, 36);
			chk_amod_customer_flag.Name = "chk_amod_customer_flag";
			chk_amod_customer_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_amod_customer_flag.Size = new System.Drawing.Size(89, 23);
			chk_amod_customer_flag.TabIndex = 373;
			chk_amod_customer_flag.TabStop = true;
			chk_amod_customer_flag.Text = "Releaseable?";
			chk_amod_customer_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_amod_customer_flag.Visible = true;
			// 
			// _Label6_21
			// 
			_Label6_21.AllowDrop = true;
			_Label6_21.AutoSize = true;
			_Label6_21.BackColor = System.Drawing.Color.Transparent;
			_Label6_21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_21.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_21.Location = new System.Drawing.Point(28, 132);
			_Label6_21.MinimumSize = new System.Drawing.Size(38, 13);
			_Label6_21.Name = "_Label6_21";
			_Label6_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_21.Size = new System.Drawing.Size(38, 13);
			_Label6_21.TabIndex = 386;
			_Label6_21.Text = "Update:";
			// 
			// _Label6_20
			// 
			_Label6_20.AllowDrop = true;
			_Label6_20.AutoSize = true;
			_Label6_20.BackColor = System.Drawing.Color.Transparent;
			_Label6_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_20.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_20.Location = new System.Drawing.Point(28, 100);
			_Label6_20.MinimumSize = new System.Drawing.Size(27, 13);
			_Label6_20.Name = "_Label6_20";
			_Label6_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_20.Size = new System.Drawing.Size(27, 13);
			_Label6_20.TabIndex = 385;
			_Label6_20.Text = "Entry:";
			// 
			// _Label6_18
			// 
			_Label6_18.AllowDrop = true;
			_Label6_18.AutoSize = true;
			_Label6_18.BackColor = System.Drawing.Color.Transparent;
			_Label6_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_18.Location = new System.Drawing.Point(89, 68);
			_Label6_18.MinimumSize = new System.Drawing.Size(23, 13);
			_Label6_18.Name = "_Label6_18";
			_Label6_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_18.Size = new System.Drawing.Size(23, 13);
			_Label6_18.TabIndex = 384;
			_Label6_18.Text = "User";
			_Label6_18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _Label6_19
			// 
			_Label6_19.AllowDrop = true;
			_Label6_19.AutoSize = true;
			_Label6_19.BackColor = System.Drawing.Color.Transparent;
			_Label6_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_19.Location = new System.Drawing.Point(164, 68);
			_Label6_19.MinimumSize = new System.Drawing.Size(25, 13);
			_Label6_19.Name = "_Label6_19";
			_Label6_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_19.Size = new System.Drawing.Size(25, 13);
			_Label6_19.TabIndex = 383;
			_Label6_19.Text = "Date";
			_Label6_19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _Label6_22
			// 
			_Label6_22.AllowDrop = true;
			_Label6_22.AutoSize = true;
			_Label6_22.BackColor = System.Drawing.Color.Transparent;
			_Label6_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_22.Location = new System.Drawing.Point(109, 168);
			_Label6_22.MinimumSize = new System.Drawing.Size(112, 13);
			_Label6_22.Name = "_Label6_22";
			_Label6_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_22.Size = new System.Drawing.Size(112, 13);
			_Label6_22.TabIndex = 382;
			_Label6_22.Text = "Callback Interval (Days)";
			// 
			// _Label6_23
			// 
			_Label6_23.AllowDrop = true;
			_Label6_23.AutoSize = true;
			_Label6_23.BackColor = System.Drawing.Color.Transparent;
			_Label6_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_23.Location = new System.Drawing.Point(44, 196);
			_Label6_23.MinimumSize = new System.Drawing.Size(91, 13);
			_Label6_23.Name = "_Label6_23";
			_Label6_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_23.Size = new System.Drawing.Size(91, 13);
			_Label6_23.TabIndex = 381;
			_Label6_23.Text = "Not For Sale Verify:";
			// 
			// _Label6_24
			// 
			_Label6_24.AllowDrop = true;
			_Label6_24.AutoSize = true;
			_Label6_24.BackColor = System.Drawing.Color.Transparent;
			_Label6_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_24.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_24.Location = new System.Drawing.Point(45, 228);
			_Label6_24.MinimumSize = new System.Drawing.Size(71, 13);
			_Label6_24.Name = "_Label6_24";
			_Label6_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_24.Size = new System.Drawing.Size(71, 13);
			_Label6_24.TabIndex = 380;
			_Label6_24.Text = "For Sale Verify:";
			// 
			// _tab_Aircraft_Model_TabPage8
			// 
			_tab_Aircraft_Model_TabPage8.Controls.Add(_cmdUseage_0);
			_tab_Aircraft_Model_TabPage8.Controls.Add(_cmdUseage_1);
			_tab_Aircraft_Model_TabPage8.Controls.Add(UsageList);
			_tab_Aircraft_Model_TabPage8.Controls.Add(_cmdUseage_4);
			_tab_Aircraft_Model_TabPage8.Controls.Add(pnl_Useage_Add);
			_tab_Aircraft_Model_TabPage8.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage8.Text = "Usage";
			// 
			// _cmdUseage_0
			// 
			_cmdUseage_0.AllowDrop = true;
			_cmdUseage_0.BackColor = System.Drawing.SystemColors.Control;
			_cmdUseage_0.Enabled = false;
			_cmdUseage_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdUseage_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdUseage_0.Location = new System.Drawing.Point(36, 35);
			_cmdUseage_0.Name = "_cmdUseage_0";
			_cmdUseage_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdUseage_0.Size = new System.Drawing.Size(65, 21);
			_cmdUseage_0.TabIndex = 391;
			_cmdUseage_0.Text = "Add";
			_cmdUseage_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdUseage_0.Click += new System.EventHandler(cmdUseage_Click);
			// 
			// _cmdUseage_1
			// 
			_cmdUseage_1.AllowDrop = true;
			_cmdUseage_1.BackColor = System.Drawing.SystemColors.Control;
			_cmdUseage_1.Enabled = false;
			_cmdUseage_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdUseage_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdUseage_1.Location = new System.Drawing.Point(203, 37);
			_cmdUseage_1.Name = "_cmdUseage_1";
			_cmdUseage_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdUseage_1.Size = new System.Drawing.Size(65, 21);
			_cmdUseage_1.TabIndex = 390;
			_cmdUseage_1.Text = "Remove";
			_cmdUseage_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdUseage_1.Click += new System.EventHandler(cmdUseage_Click);
			// 
			// UsageList
			// 
			UsageList.AllowDrop = true;
			UsageList.BackColor = System.Drawing.SystemColors.Window;
			UsageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			UsageList.CausesValidation = true;
			UsageList.Enabled = true;
			UsageList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			UsageList.ForeColor = System.Drawing.SystemColors.WindowText;
			UsageList.IntegralHeight = true;
			UsageList.Location = new System.Drawing.Point(37, 72);
			UsageList.MultiColumn = false;
			UsageList.Name = "UsageList";
			UsageList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			UsageList.Size = new System.Drawing.Size(235, 161);
			UsageList.Sorted = false;
			UsageList.TabIndex = 389;
			UsageList.TabStop = true;
			UsageList.Visible = true;
			// 
			// _cmdUseage_4
			// 
			_cmdUseage_4.AllowDrop = true;
			_cmdUseage_4.BackColor = System.Drawing.SystemColors.Control;
			_cmdUseage_4.Enabled = false;
			_cmdUseage_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdUseage_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdUseage_4.Location = new System.Drawing.Point(101, 249);
			_cmdUseage_4.Name = "_cmdUseage_4";
			_cmdUseage_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdUseage_4.Size = new System.Drawing.Size(77, 20);
			_cmdUseage_4.TabIndex = 388;
			_cmdUseage_4.Text = "Refresh";
			_cmdUseage_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdUseage_4.Click += new System.EventHandler(cmdUseage_Click);
			// 
			// pnl_Useage_Add
			// 
			pnl_Useage_Add.AllowDrop = true;
			pnl_Useage_Add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Useage_Add.Controls.Add(cmbUsage);
			pnl_Useage_Add.Controls.Add(_cmdUseage_3);
			pnl_Useage_Add.Controls.Add(_cmdUseage_2);
			pnl_Useage_Add.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Useage_Add.Location = new System.Drawing.Point(309, 101);
			pnl_Useage_Add.Name = "pnl_Useage_Add";
			pnl_Useage_Add.Size = new System.Drawing.Size(294, 100);
			pnl_Useage_Add.TabIndex = 224;
			// 
			// cmbUsage
			// 
			cmbUsage.AllowDrop = true;
			cmbUsage.BackColor = System.Drawing.SystemColors.Window;
			cmbUsage.CausesValidation = true;
			cmbUsage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbUsage.Enabled = true;
			cmbUsage.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbUsage.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbUsage.IntegralHeight = true;
			cmbUsage.Location = new System.Drawing.Point(35, 54);
			cmbUsage.Name = "cmbUsage";
			cmbUsage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbUsage.Size = new System.Drawing.Size(223, 23);
			cmbUsage.Sorted = false;
			cmbUsage.TabIndex = 394;
			cmbUsage.TabStop = true;
			cmbUsage.Visible = true;
			// 
			// _cmdUseage_3
			// 
			_cmdUseage_3.AllowDrop = true;
			_cmdUseage_3.BackColor = System.Drawing.SystemColors.Control;
			_cmdUseage_3.Enabled = false;
			_cmdUseage_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdUseage_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdUseage_3.Location = new System.Drawing.Point(166, 25);
			_cmdUseage_3.Name = "_cmdUseage_3";
			_cmdUseage_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdUseage_3.Size = new System.Drawing.Size(65, 21);
			_cmdUseage_3.TabIndex = 393;
			_cmdUseage_3.Text = "Cancel";
			_cmdUseage_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdUseage_3.Click += new System.EventHandler(cmdUseage_Click);
			// 
			// _cmdUseage_2
			// 
			_cmdUseage_2.AllowDrop = true;
			_cmdUseage_2.BackColor = System.Drawing.SystemColors.Control;
			_cmdUseage_2.Enabled = false;
			_cmdUseage_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdUseage_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdUseage_2.Location = new System.Drawing.Point(65, 24);
			_cmdUseage_2.Name = "_cmdUseage_2";
			_cmdUseage_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdUseage_2.Size = new System.Drawing.Size(65, 21);
			_cmdUseage_2.TabIndex = 392;
			_cmdUseage_2.Text = "Save";
			_cmdUseage_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdUseage_2.Click += new System.EventHandler(cmdUseage_Click);
			// 
			// _tab_Aircraft_Model_TabPage9
			// 
			_tab_Aircraft_Model_TabPage9.Controls.Add(_cmd_Make_Move1_2);
			_tab_Aircraft_Model_TabPage9.Controls.Add(_cmd_Make_Move1_1);
			_tab_Aircraft_Model_TabPage9.Controls.Add(_cmd_Make_Move1_0);
			_tab_Aircraft_Model_TabPage9.Controls.Add(cbo_MakeSelect);
			_tab_Aircraft_Model_TabPage9.Controls.Add(grd_MakeSort);
			_tab_Aircraft_Model_TabPage9.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage9.Text = "Make Sort";
			// 
			// _cmd_Make_Move1_2
			// 
			_cmd_Make_Move1_2.AllowDrop = true;
			_cmd_Make_Move1_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_Make_Move1_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_Make_Move1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_Make_Move1_2.Location = new System.Drawing.Point(120, 276);
			_cmd_Make_Move1_2.Name = "_cmd_Make_Move1_2";
			_cmd_Make_Move1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_Make_Move1_2.Size = new System.Drawing.Size(103, 23);
			_cmd_Make_Move1_2.TabIndex = 453;
			_cmd_Make_Move1_2.Text = "Save Changes";
			_cmd_Make_Move1_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_Make_Move1_2.UseVisualStyleBackColor = false;
			_cmd_Make_Move1_2.Click += new System.EventHandler(cmd_Make_Move1_Click);
			// 
			// _cmd_Make_Move1_1
			// 
			_cmd_Make_Move1_1.AllowDrop = true;
			_cmd_Make_Move1_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_Make_Move1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_Make_Move1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_Make_Move1_1.Location = new System.Drawing.Point(234, 276);
			_cmd_Make_Move1_1.Name = "_cmd_Make_Move1_1";
			_cmd_Make_Move1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_Make_Move1_1.Size = new System.Drawing.Size(103, 23);
			_cmd_Make_Move1_1.TabIndex = 452;
			_cmd_Make_Move1_1.Text = "Move Model Down";
			_cmd_Make_Move1_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_Make_Move1_1.UseVisualStyleBackColor = false;
			_cmd_Make_Move1_1.Click += new System.EventHandler(cmd_Make_Move1_Click);
			// 
			// _cmd_Make_Move1_0
			// 
			_cmd_Make_Move1_0.AllowDrop = true;
			_cmd_Make_Move1_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_Make_Move1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_Make_Move1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_Make_Move1_0.Location = new System.Drawing.Point(16, 276);
			_cmd_Make_Move1_0.Name = "_cmd_Make_Move1_0";
			_cmd_Make_Move1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_Make_Move1_0.Size = new System.Drawing.Size(103, 23);
			_cmd_Make_Move1_0.TabIndex = 236;
			_cmd_Make_Move1_0.Text = "Move Model Up";
			_cmd_Make_Move1_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_Make_Move1_0.UseVisualStyleBackColor = false;
			_cmd_Make_Move1_0.Click += new System.EventHandler(cmd_Make_Move1_Click);
			// 
			// cbo_MakeSelect
			// 
			cbo_MakeSelect.AllowDrop = true;
			cbo_MakeSelect.BackColor = System.Drawing.SystemColors.Window;
			cbo_MakeSelect.CausesValidation = true;
			cbo_MakeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_MakeSelect.Enabled = true;
			cbo_MakeSelect.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_MakeSelect.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_MakeSelect.IntegralHeight = true;
			cbo_MakeSelect.Location = new System.Drawing.Point(15, 26);
			cbo_MakeSelect.Name = "cbo_MakeSelect";
			cbo_MakeSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_MakeSelect.Size = new System.Drawing.Size(325, 23);
			cbo_MakeSelect.Sorted = false;
			cbo_MakeSelect.TabIndex = 234;
			cbo_MakeSelect.TabStop = true;
			cbo_MakeSelect.Visible = true;
			cbo_MakeSelect.SelectionChangeCommitted += new System.EventHandler(cbo_MakeSelect_SelectionChangeCommitted);
			// 
			// grd_MakeSort
			// 
			grd_MakeSort.AllowDrop = true;
			grd_MakeSort.AllowUserToAddRows = false;
			grd_MakeSort.AllowUserToDeleteRows = false;
			grd_MakeSort.AllowUserToResizeColumns = false;
			grd_MakeSort.AllowUserToResizeColumns = grd_MakeSort.ColumnHeadersVisible;
			grd_MakeSort.AllowUserToResizeRows = false;
			grd_MakeSort.AllowUserToResizeRows = false;
			grd_MakeSort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_MakeSort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_MakeSort.ColumnsCount = 2;
			grd_MakeSort.FixedColumns = 1;
			grd_MakeSort.FixedRows = 1;
			grd_MakeSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grd_MakeSort.Location = new System.Drawing.Point(16, 52);
			grd_MakeSort.Name = "grd_MakeSort";
			grd_MakeSort.ReadOnly = true;
			grd_MakeSort.RowsCount = 2;
			grd_MakeSort.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_MakeSort.ShowCellToolTips = false;
			grd_MakeSort.Size = new System.Drawing.Size(321, 216);
			grd_MakeSort.StandardTab = true;
			grd_MakeSort.TabIndex = 235;
			grd_MakeSort.Click += new System.EventHandler(grd_MakeSort_Click);
			// 
			// _tab_Aircraft_Model_TabPage10
			// 
			_tab_Aircraft_Model_TabPage10.Controls.Add(frmodelMap);
			_tab_Aircraft_Model_TabPage10.Controls.Add(grdModelMap);
			_tab_Aircraft_Model_TabPage10.Controls.Add(grdAircraftMap);
			_tab_Aircraft_Model_TabPage10.Controls.Add(_lbl_spec_3);
			_tab_Aircraft_Model_TabPage10.Controls.Add(_lbl_spec_0);
			_tab_Aircraft_Model_TabPage10.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage10.Text = "Model Map";
			// 
			// frmodelMap
			// 
			frmodelMap.AllowDrop = true;
			frmodelMap.BackColor = System.Drawing.SystemColors.Control;
			frmodelMap.Controls.Add(_CMDModelMap_2);
			frmodelMap.Controls.Add(_CMDModelMap_1);
			frmodelMap.Controls.Add(_CMDModelMap_0);
			frmodelMap.Controls.Add(cmbHbaseModels);
			frmodelMap.Controls.Add(_lbl_spec_2);
			frmodelMap.Controls.Add(_lbl_spec_1);
			frmodelMap.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmodelMap.Enabled = true;
			frmodelMap.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmodelMap.ForeColor = System.Drawing.SystemColors.ControlText;
			frmodelMap.Location = new System.Drawing.Point(8, 364);
			frmodelMap.Name = "frmodelMap";
			frmodelMap.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmodelMap.Size = new System.Drawing.Size(699, 125);
			frmodelMap.TabIndex = 239;
			frmodelMap.Visible = false;
			// 
			// _CMDModelMap_2
			// 
			_CMDModelMap_2.AllowDrop = true;
			_CMDModelMap_2.BackColor = System.Drawing.SystemColors.Control;
			_CMDModelMap_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_CMDModelMap_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_CMDModelMap_2.Location = new System.Drawing.Point(273, 63);
			_CMDModelMap_2.Name = "_CMDModelMap_2";
			_CMDModelMap_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_CMDModelMap_2.Size = new System.Drawing.Size(80, 25);
			_CMDModelMap_2.TabIndex = 419;
			_CMDModelMap_2.Text = "Refresh";
			_CMDModelMap_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_CMDModelMap_2.UseVisualStyleBackColor = false;
			_CMDModelMap_2.Click += new System.EventHandler(CMDModelMap_Click);
			// 
			// _CMDModelMap_1
			// 
			_CMDModelMap_1.AllowDrop = true;
			_CMDModelMap_1.BackColor = System.Drawing.SystemColors.Control;
			_CMDModelMap_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_CMDModelMap_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_CMDModelMap_1.Location = new System.Drawing.Point(368, 62);
			_CMDModelMap_1.Name = "_CMDModelMap_1";
			_CMDModelMap_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_CMDModelMap_1.Size = new System.Drawing.Size(130, 33);
			_CMDModelMap_1.TabIndex = 418;
			_CMDModelMap_1.Text = "View Aircraft Mapping (Homebase)";
			_CMDModelMap_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_CMDModelMap_1.UseVisualStyleBackColor = false;
			_CMDModelMap_1.Click += new System.EventHandler(CMDModelMap_Click);
			// 
			// _CMDModelMap_0
			// 
			_CMDModelMap_0.AllowDrop = true;
			_CMDModelMap_0.BackColor = System.Drawing.SystemColors.Control;
			_CMDModelMap_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_CMDModelMap_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_CMDModelMap_0.Location = new System.Drawing.Point(154, 61);
			_CMDModelMap_0.Name = "_CMDModelMap_0";
			_CMDModelMap_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_CMDModelMap_0.Size = new System.Drawing.Size(112, 25);
			_CMDModelMap_0.TabIndex = 242;
			_CMDModelMap_0.Text = "Save";
			_CMDModelMap_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_CMDModelMap_0.UseVisualStyleBackColor = false;
			_CMDModelMap_0.Click += new System.EventHandler(CMDModelMap_Click);
			// 
			// cmbHbaseModels
			// 
			cmbHbaseModels.AllowDrop = true;
			cmbHbaseModels.BackColor = System.Drawing.SystemColors.Window;
			cmbHbaseModels.CausesValidation = true;
			cmbHbaseModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbHbaseModels.Enabled = true;
			cmbHbaseModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbHbaseModels.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbHbaseModels.IntegralHeight = true;
			cmbHbaseModels.Location = new System.Drawing.Point(334, 32);
			cmbHbaseModels.Name = "cmbHbaseModels";
			cmbHbaseModels.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbHbaseModels.Size = new System.Drawing.Size(357, 21);
			cmbHbaseModels.Sorted = false;
			cmbHbaseModels.TabIndex = 240;
			cmbHbaseModels.TabStop = true;
			cmbHbaseModels.Text = "cmbHbaseModels";
			cmbHbaseModels.Visible = true;
			// 
			// _lbl_spec_2
			// 
			_lbl_spec_2.AllowDrop = true;
			_lbl_spec_2.BackColor = System.Drawing.SystemColors.Control;
			_lbl_spec_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_spec_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_spec_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_spec_2.Location = new System.Drawing.Point(13, 28);
			_lbl_spec_2.MinimumSize = new System.Drawing.Size(311, 29);
			_lbl_spec_2.Name = "_lbl_spec_2";
			_lbl_spec_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_spec_2.Size = new System.Drawing.Size(311, 29);
			_lbl_spec_2.TabIndex = 243;
			_lbl_spec_2.Text = "x";
			// 
			// _lbl_spec_1
			// 
			_lbl_spec_1.AllowDrop = true;
			_lbl_spec_1.BackColor = System.Drawing.SystemColors.Control;
			_lbl_spec_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_spec_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_spec_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_spec_1.Location = new System.Drawing.Point(334, 14);
			_lbl_spec_1.MinimumSize = new System.Drawing.Size(281, 17);
			_lbl_spec_1.Name = "_lbl_spec_1";
			_lbl_spec_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_spec_1.Size = new System.Drawing.Size(281, 17);
			_lbl_spec_1.TabIndex = 241;
			_lbl_spec_1.Text = "Homebase Model List";
			// 
			// grdModelMap
			// 
			grdModelMap.AllowDrop = true;
			grdModelMap.AllowUserToAddRows = false;
			grdModelMap.AllowUserToDeleteRows = false;
			grdModelMap.AllowUserToResizeColumns = false;
			grdModelMap.AllowUserToResizeColumns = grdModelMap.ColumnHeadersVisible;
			grdModelMap.AllowUserToResizeRows = false;
			grdModelMap.AllowUserToResizeRows = false;
			grdModelMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdModelMap.ColumnsCount = 2;
			grdModelMap.FixedColumns = 0;
			grdModelMap.FixedRows = 1;
			grdModelMap.Location = new System.Drawing.Point(8, 63);
			grdModelMap.Name = "grdModelMap";
			grdModelMap.ReadOnly = true;
			grdModelMap.RowsCount = 2;
			grdModelMap.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			grdModelMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdModelMap.ShowCellToolTips = false;
			grdModelMap.Size = new System.Drawing.Size(471, 297);
			grdModelMap.StandardTab = true;
			grdModelMap.TabIndex = 238;
			grdModelMap.Click += new System.EventHandler(grdModelMap_Click);
			// 
			// grdAircraftMap
			// 
			grdAircraftMap.AllowDrop = true;
			grdAircraftMap.AllowUserToAddRows = false;
			grdAircraftMap.AllowUserToDeleteRows = false;
			grdAircraftMap.AllowUserToResizeColumns = false;
			grdAircraftMap.AllowUserToResizeColumns = grdAircraftMap.ColumnHeadersVisible;
			grdAircraftMap.AllowUserToResizeRows = false;
			grdAircraftMap.AllowUserToResizeRows = false;
			grdAircraftMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdAircraftMap.ColumnsCount = 2;
			grdAircraftMap.FixedColumns = 0;
			grdAircraftMap.FixedRows = 1;
			grdAircraftMap.Location = new System.Drawing.Point(480, 64);
			grdAircraftMap.Name = "grdAircraftMap";
			grdAircraftMap.ReadOnly = true;
			grdAircraftMap.RowsCount = 2;
			grdAircraftMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdAircraftMap.ShowCellToolTips = false;
			grdAircraftMap.Size = new System.Drawing.Size(511, 297);
			grdAircraftMap.StandardTab = true;
			grdAircraftMap.TabIndex = 420;
			grdAircraftMap.DoubleClick += new System.EventHandler(grdAircraftMap_DoubleClick);
			// 
			// _lbl_spec_3
			// 
			_lbl_spec_3.AllowDrop = true;
			_lbl_spec_3.BackColor = System.Drawing.SystemColors.Control;
			_lbl_spec_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_spec_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_spec_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_spec_3.Location = new System.Drawing.Point(238, 39);
			_lbl_spec_3.MinimumSize = new System.Drawing.Size(141, 17);
			_lbl_spec_3.Name = "_lbl_spec_3";
			_lbl_spec_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_spec_3.Size = new System.Drawing.Size(141, 17);
			_lbl_spec_3.TabIndex = 397;
			_lbl_spec_3.Text = "loading";
			// 
			// _lbl_spec_0
			// 
			_lbl_spec_0.AllowDrop = true;
			_lbl_spec_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_spec_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_spec_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_spec_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_spec_0.Location = new System.Drawing.Point(8, 39);
			_lbl_spec_0.MinimumSize = new System.Drawing.Size(281, 17);
			_lbl_spec_0.Name = "_lbl_spec_0";
			_lbl_spec_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_spec_0.Size = new System.Drawing.Size(281, 17);
			_lbl_spec_0.TabIndex = 237;
			_lbl_spec_0.Text = "Commercial Models Versus Homebase Models";
			// 
			// _tab_Aircraft_Model_TabPage11
			// 
			_tab_Aircraft_Model_TabPage11.Controls.Add(txt_intel);
			_tab_Aircraft_Model_TabPage11.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage11.Text = "Intelligence";
			// 
			// txt_intel
			// 
			txt_intel.AcceptsReturn = true;
			txt_intel.AllowDrop = true;
			txt_intel.BackColor = System.Drawing.SystemColors.Window;
			txt_intel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_intel.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_intel.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_intel.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_intel.Location = new System.Drawing.Point(22, 24);
			txt_intel.MaxLength = 0;
			txt_intel.Multiline = true;
			txt_intel.Name = "txt_intel";
			txt_intel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_intel.Size = new System.Drawing.Size(609, 349);
			txt_intel.TabIndex = 432;
			// 
			// _tab_Aircraft_Model_TabPage12
			// 
			_tab_Aircraft_Model_TabPage12.Controls.Add(grd_eventlog);
			_tab_Aircraft_Model_TabPage12.Controls.Add(cmd_new);
			_tab_Aircraft_Model_TabPage12.Controls.Add(grd_amod_journal);
			_tab_Aircraft_Model_TabPage12.Controls.Add(_Label6_36);
			_tab_Aircraft_Model_TabPage12.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage12.Text = "Notes";
			// 
			// grd_eventlog
			// 
			grd_eventlog.AllowDrop = true;
			grd_eventlog.AllowUserToAddRows = false;
			grd_eventlog.AllowUserToDeleteRows = false;
			grd_eventlog.AllowUserToResizeColumns = false;
			grd_eventlog.AllowUserToResizeRows = false;
			grd_eventlog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_eventlog.ColumnsCount = 2;
			grd_eventlog.FixedColumns = 1;
			grd_eventlog.FixedRows = 1;
			grd_eventlog.Location = new System.Drawing.Point(16, 332);
			grd_eventlog.Name = "grd_eventlog";
			grd_eventlog.ReadOnly = true;
			grd_eventlog.RowsCount = 2;
			grd_eventlog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_eventlog.ShowCellToolTips = false;
			grd_eventlog.Size = new System.Drawing.Size(625, 161);
			grd_eventlog.StandardTab = true;
			grd_eventlog.TabIndex = 451;
			// 
			// cmd_new
			// 
			cmd_new.AllowDrop = true;
			cmd_new.BackColor = System.Drawing.SystemColors.Control;
			cmd_new.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_new.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_new.Location = new System.Drawing.Point(928, 300);
			cmd_new.Name = "cmd_new";
			cmd_new.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_new.Size = new System.Drawing.Size(65, 25);
			cmd_new.TabIndex = 450;
			cmd_new.Text = "Add Note";
			cmd_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_new.UseVisualStyleBackColor = false;
			cmd_new.Click += new System.EventHandler(cmd_new_Click);
			// 
			// grd_amod_journal
			// 
			grd_amod_journal.AllowDrop = true;
			grd_amod_journal.AllowUserToAddRows = false;
			grd_amod_journal.AllowUserToDeleteRows = false;
			grd_amod_journal.AllowUserToResizeColumns = false;
			grd_amod_journal.AllowUserToResizeRows = false;
			grd_amod_journal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_amod_journal.ColumnsCount = 2;
			grd_amod_journal.FixedColumns = 1;
			grd_amod_journal.FixedRows = 1;
			grd_amod_journal.Location = new System.Drawing.Point(16, 20);
			grd_amod_journal.Name = "grd_amod_journal";
			grd_amod_journal.ReadOnly = true;
			grd_amod_journal.RowsCount = 2;
			grd_amod_journal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_amod_journal.ShowCellToolTips = false;
			grd_amod_journal.Size = new System.Drawing.Size(977, 281);
			grd_amod_journal.StandardTab = true;
			grd_amod_journal.TabIndex = 449;
			grd_amod_journal.DoubleClick += new System.EventHandler(grd_amod_journal_DoubleClick);
			// 
			// _Label6_36
			// 
			_Label6_36.AllowDrop = true;
			_Label6_36.AutoSize = true;
			_Label6_36.BackColor = System.Drawing.Color.Transparent;
			_Label6_36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_36.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_36.Location = new System.Drawing.Point(24, 316);
			_Label6_36.MinimumSize = new System.Drawing.Size(101, 13);
			_Label6_36.Name = "_Label6_36";
			_Label6_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_36.Size = new System.Drawing.Size(101, 13);
			_Label6_36.TabIndex = 460;
			_Label6_36.Text = "Fuel Price Event Log";
			_Label6_36.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _tab_Aircraft_Model_TabPage13
			// 
			_tab_Aircraft_Model_TabPage13.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Aircraft_Model_TabPage13.Text = "Equip";
			// 
			// pnl_ModelMain
			// 
			pnl_ModelMain.AllowDrop = true;
			pnl_ModelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_ModelMain.Controls.Add(txt_amod_icao);
			pnl_ModelMain.Controls.Add(cboJIQSize);
			pnl_ModelMain.Controls.Add(_txt_amod_fuselage_length_7);
			pnl_ModelMain.Controls.Add(cbo_amod_Airframe_Type_Code);
			pnl_ModelMain.Controls.Add(_txt_amod_manufacturer_2);
			pnl_ModelMain.Controls.Add(_txt_amod_manufacturer_1);
			pnl_ModelMain.Controls.Add(_txt_amod_manufacturer_0);
			pnl_ModelMain.Controls.Add(txt_amod_make_abbrev);
			pnl_ModelMain.Controls.Add(txt_amod_model_abbrev);
			pnl_ModelMain.Controls.Add(cboWeightClass);
			pnl_ModelMain.Controls.Add(cbo_amod_type_code);
			pnl_ModelMain.Controls.Add(txt_amod_make_name);
			pnl_ModelMain.Controls.Add(txt_amod_model_name);
			pnl_ModelMain.Controls.Add(cbo_amod_class);
			pnl_ModelMain.Controls.Add(pnl_Model_Top);
			pnl_ModelMain.Controls.Add(_Label6_35);
			pnl_ModelMain.Controls.Add(_Label6_34);
			pnl_ModelMain.Controls.Add(_Label6_29);
			pnl_ModelMain.Controls.Add(_Label6_1);
			pnl_ModelMain.Controls.Add(_Label6_32);
			pnl_ModelMain.Controls.Add(_Label6_28);
			pnl_ModelMain.Controls.Add(_Label6_27);
			pnl_ModelMain.Controls.Add(_Label6_6);
			pnl_ModelMain.Controls.Add(_Label6_4);
			pnl_ModelMain.Controls.Add(_Label6_3);
			pnl_ModelMain.Controls.Add(_Label2_0);
			pnl_ModelMain.Controls.Add(_Label6_7);
			pnl_ModelMain.Controls.Add(_Label6_0);
			pnl_ModelMain.Controls.Add(_Label6_2);
			pnl_ModelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_ModelMain.Location = new System.Drawing.Point(3, 52);
			pnl_ModelMain.Name = "pnl_ModelMain";
			pnl_ModelMain.Size = new System.Drawing.Size(604, 122);
			pnl_ModelMain.TabIndex = 135;
			// 
			// txt_amod_icao
			// 
			txt_amod_icao.AcceptsReturn = true;
			txt_amod_icao.AllowDrop = true;
			txt_amod_icao.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_icao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_icao.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_icao.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_icao.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_icao.Location = new System.Drawing.Point(560, 96);
			txt_amod_icao.MaxLength = 0;
			txt_amod_icao.Name = "txt_amod_icao";
			txt_amod_icao.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_icao.Size = new System.Drawing.Size(41, 22);
			txt_amod_icao.TabIndex = 454;
			txt_amod_icao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cboJIQSize
			// 
			cboJIQSize.AllowDrop = true;
			cboJIQSize.BackColor = System.Drawing.SystemColors.Window;
			cboJIQSize.CausesValidation = true;
			cboJIQSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboJIQSize.Enabled = true;
			cboJIQSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboJIQSize.ForeColor = System.Drawing.SystemColors.WindowText;
			cboJIQSize.IntegralHeight = true;
			cboJIQSize.Location = new System.Drawing.Point(440, 72);
			cboJIQSize.Name = "cboJIQSize";
			cboJIQSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboJIQSize.Size = new System.Drawing.Size(157, 21);
			cboJIQSize.Sorted = false;
			cboJIQSize.TabIndex = 15;
			cboJIQSize.TabStop = true;
			cboJIQSize.Visible = true;
			// 
			// _txt_amod_fuselage_length_7
			// 
			_txt_amod_fuselage_length_7.AcceptsReturn = true;
			_txt_amod_fuselage_length_7.AllowDrop = true;
			_txt_amod_fuselage_length_7.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_fuselage_length_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_fuselage_length_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_fuselage_length_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_fuselage_length_7.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_fuselage_length_7.Location = new System.Drawing.Point(301, 77);
			_txt_amod_fuselage_length_7.MaxLength = 40;
			_txt_amod_fuselage_length_7.Name = "_txt_amod_fuselage_length_7";
			_txt_amod_fuselage_length_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_fuselage_length_7.Size = new System.Drawing.Size(80, 19);
			_txt_amod_fuselage_length_7.TabIndex = 14;
			_txt_amod_fuselage_length_7.Leave += new System.EventHandler(txt_amod_fuselage_length_Leave);
			// 
			// cbo_amod_Airframe_Type_Code
			// 
			cbo_amod_Airframe_Type_Code.AllowDrop = true;
			cbo_amod_Airframe_Type_Code.BackColor = System.Drawing.SystemColors.Window;
			cbo_amod_Airframe_Type_Code.CausesValidation = true;
			cbo_amod_Airframe_Type_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_amod_Airframe_Type_Code.Enabled = true;
			cbo_amod_Airframe_Type_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_amod_Airframe_Type_Code.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_amod_Airframe_Type_Code.IntegralHeight = true;
			cbo_amod_Airframe_Type_Code.Location = new System.Drawing.Point(297, 45);
			cbo_amod_Airframe_Type_Code.Name = "cbo_amod_Airframe_Type_Code";
			cbo_amod_Airframe_Type_Code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_amod_Airframe_Type_Code.Size = new System.Drawing.Size(79, 21);
			cbo_amod_Airframe_Type_Code.Sorted = false;
			cbo_amod_Airframe_Type_Code.TabIndex = 8;
			cbo_amod_Airframe_Type_Code.TabStop = true;
			cbo_amod_Airframe_Type_Code.Visible = true;
			cbo_amod_Airframe_Type_Code.SelectedIndexChanged += new System.EventHandler(cbo_amod_Airframe_Type_Code_SelectedIndexChanged);
			// 
			// _txt_amod_manufacturer_2
			// 
			_txt_amod_manufacturer_2.AcceptsReturn = true;
			_txt_amod_manufacturer_2.AllowDrop = true;
			_txt_amod_manufacturer_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_manufacturer_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_manufacturer_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_manufacturer_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_manufacturer_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_manufacturer_2.Location = new System.Drawing.Point(472, 96);
			_txt_amod_manufacturer_2.MaxLength = 50;
			_txt_amod_manufacturer_2.Name = "_txt_amod_manufacturer_2";
			_txt_amod_manufacturer_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_manufacturer_2.Size = new System.Drawing.Size(53, 21);
			_txt_amod_manufacturer_2.TabIndex = 18;
			_txt_amod_manufacturer_2.Text = "0";
			_txt_amod_manufacturer_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_txt_amod_manufacturer_2.TextChanged += new System.EventHandler(txt_amod_manufacturer_TextChanged);
			// 
			// _txt_amod_manufacturer_1
			// 
			_txt_amod_manufacturer_1.AcceptsReturn = true;
			_txt_amod_manufacturer_1.AllowDrop = true;
			_txt_amod_manufacturer_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_manufacturer_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_manufacturer_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_manufacturer_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_manufacturer_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_manufacturer_1.Location = new System.Drawing.Point(240, 96);
			_txt_amod_manufacturer_1.MaxLength = 50;
			_txt_amod_manufacturer_1.Name = "_txt_amod_manufacturer_1";
			_txt_amod_manufacturer_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_manufacturer_1.Size = new System.Drawing.Size(160, 21);
			_txt_amod_manufacturer_1.TabIndex = 17;
			_txt_amod_manufacturer_1.TextChanged += new System.EventHandler(txt_amod_manufacturer_TextChanged);
			// 
			// _txt_amod_manufacturer_0
			// 
			_txt_amod_manufacturer_0.AcceptsReturn = true;
			_txt_amod_manufacturer_0.AllowDrop = true;
			_txt_amod_manufacturer_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_amod_manufacturer_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_amod_manufacturer_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_amod_manufacturer_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_amod_manufacturer_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_amod_manufacturer_0.Location = new System.Drawing.Point(24, 96);
			_txt_amod_manufacturer_0.MaxLength = 50;
			_txt_amod_manufacturer_0.Name = "_txt_amod_manufacturer_0";
			_txt_amod_manufacturer_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_amod_manufacturer_0.Size = new System.Drawing.Size(160, 21);
			_txt_amod_manufacturer_0.TabIndex = 16;
			_txt_amod_manufacturer_0.TextChanged += new System.EventHandler(txt_amod_manufacturer_TextChanged);
			// 
			// txt_amod_make_abbrev
			// 
			txt_amod_make_abbrev.AcceptsReturn = true;
			txt_amod_make_abbrev.AllowDrop = true;
			txt_amod_make_abbrev.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_make_abbrev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_make_abbrev.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_make_abbrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_make_abbrev.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_make_abbrev.Location = new System.Drawing.Point(260, 46);
			txt_amod_make_abbrev.MaxLength = 2;
			txt_amod_make_abbrev.Name = "txt_amod_make_abbrev";
			txt_amod_make_abbrev.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_make_abbrev.Size = new System.Drawing.Size(33, 22);
			txt_amod_make_abbrev.TabIndex = 7;
			txt_amod_make_abbrev.Click += new System.EventHandler(txt_amod_make_abbrev_Click);
			txt_amod_make_abbrev.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_amod_make_abbrev_KeyPress);
			// 
			// txt_amod_model_abbrev
			// 
			txt_amod_model_abbrev.AcceptsReturn = true;
			txt_amod_model_abbrev.AllowDrop = true;
			txt_amod_model_abbrev.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_model_abbrev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_model_abbrev.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_model_abbrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_model_abbrev.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_model_abbrev.Location = new System.Drawing.Point(212, 73);
			txt_amod_model_abbrev.MaxLength = 0;
			txt_amod_model_abbrev.Name = "txt_amod_model_abbrev";
			txt_amod_model_abbrev.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_model_abbrev.Size = new System.Drawing.Size(81, 21);
			txt_amod_model_abbrev.TabIndex = 13;
			txt_amod_model_abbrev.Click += new System.EventHandler(txt_amod_model_abbrev_Click);
			txt_amod_model_abbrev.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_amod_model_abbrev_KeyPress);
			// 
			// cboWeightClass
			// 
			cboWeightClass.AllowDrop = true;
			cboWeightClass.BackColor = System.Drawing.SystemColors.Window;
			cboWeightClass.CausesValidation = true;
			cboWeightClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboWeightClass.Enabled = true;
			cboWeightClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboWeightClass.ForeColor = System.Drawing.SystemColors.WindowText;
			cboWeightClass.IntegralHeight = true;
			cboWeightClass.Location = new System.Drawing.Point(493, 45);
			cboWeightClass.Name = "cboWeightClass";
			cboWeightClass.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboWeightClass.Size = new System.Drawing.Size(107, 21);
			cboWeightClass.Sorted = false;
			cboWeightClass.TabIndex = 11;
			cboWeightClass.TabStop = true;
			cboWeightClass.Visible = true;
			// 
			// cbo_amod_type_code
			// 
			cbo_amod_type_code.AllowDrop = true;
			cbo_amod_type_code.BackColor = System.Drawing.SystemColors.Window;
			cbo_amod_type_code.CausesValidation = true;
			cbo_amod_type_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_amod_type_code.Enabled = true;
			cbo_amod_type_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_amod_type_code.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_amod_type_code.IntegralHeight = true;
			cbo_amod_type_code.Location = new System.Drawing.Point(386, 45);
			cbo_amod_type_code.Name = "cbo_amod_type_code";
			cbo_amod_type_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_amod_type_code.Size = new System.Drawing.Size(41, 21);
			cbo_amod_type_code.Sorted = false;
			cbo_amod_type_code.TabIndex = 9;
			cbo_amod_type_code.TabStop = true;
			cbo_amod_type_code.Visible = true;
			cbo_amod_type_code.SelectedIndexChanged += new System.EventHandler(cbo_amod_type_code_SelectedIndexChanged);
			// 
			// txt_amod_make_name
			// 
			txt_amod_make_name.AcceptsReturn = true;
			txt_amod_make_name.AllowDrop = true;
			txt_amod_make_name.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_make_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_make_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_make_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_make_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_make_name.Location = new System.Drawing.Point(41, 48);
			txt_amod_make_name.MaxLength = 0;
			txt_amod_make_name.Name = "txt_amod_make_name";
			txt_amod_make_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_make_name.Size = new System.Drawing.Size(168, 21);
			txt_amod_make_name.TabIndex = 6;
			txt_amod_make_name.Click += new System.EventHandler(txt_amod_make_name_Click);
			txt_amod_make_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_amod_make_name_KeyPress);
			txt_amod_make_name.Leave += new System.EventHandler(txt_amod_make_name_Leave);
			// 
			// txt_amod_model_name
			// 
			txt_amod_model_name.AcceptsReturn = true;
			txt_amod_model_name.AllowDrop = true;
			txt_amod_model_name.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_model_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_model_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_model_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_model_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_model_name.Location = new System.Drawing.Point(41, 73);
			txt_amod_model_name.MaxLength = 0;
			txt_amod_model_name.Name = "txt_amod_model_name";
			txt_amod_model_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_model_name.Size = new System.Drawing.Size(168, 21);
			txt_amod_model_name.TabIndex = 12;
			txt_amod_model_name.Click += new System.EventHandler(txt_amod_model_name_Click);
			txt_amod_model_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_amod_model_name_KeyPress);
			txt_amod_model_name.Leave += new System.EventHandler(txt_amod_model_name_Leave);
			txt_amod_model_name.TextChanged += new System.EventHandler(txt_amod_model_name_TextChanged);
			// 
			// cbo_amod_class
			// 
			cbo_amod_class.AllowDrop = true;
			cbo_amod_class.BackColor = System.Drawing.SystemColors.Window;
			cbo_amod_class.CausesValidation = true;
			cbo_amod_class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_amod_class.Enabled = true;
			cbo_amod_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_amod_class.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_amod_class.IntegralHeight = true;
			cbo_amod_class.Location = new System.Drawing.Point(437, 45);
			cbo_amod_class.Name = "cbo_amod_class";
			cbo_amod_class.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_amod_class.Size = new System.Drawing.Size(41, 21);
			cbo_amod_class.Sorted = false;
			cbo_amod_class.TabIndex = 10;
			cbo_amod_class.TabStop = true;
			cbo_amod_class.Visible = true;
			// 
			// pnl_Model_Top
			// 
			pnl_Model_Top.AllowDrop = true;
			pnl_Model_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Model_Top.Controls.Add(CmbResearchType);
			pnl_Model_Top.Controls.Add(txt_amod_id);
			pnl_Model_Top.Controls.Add(scr_Models);
			pnl_Model_Top.Controls.Add(txt_model_number);
			pnl_Model_Top.Controls.Add(txt_model_total);
			pnl_Model_Top.Controls.Add(cbo_Model);
			pnl_Model_Top.Controls.Add(SSPanel3);
			pnl_Model_Top.Controls.Add(_Label6_9);
			pnl_Model_Top.Controls.Add(_Label6_10);
			pnl_Model_Top.Font = new System.Drawing.Font("Arial", 272.36f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Model_Top.Location = new System.Drawing.Point(0, 0);
			pnl_Model_Top.Name = "pnl_Model_Top";
			pnl_Model_Top.Size = new System.Drawing.Size(604, 32);
			pnl_Model_Top.TabIndex = 180;
			// 
			// CmbResearchType
			// 
			CmbResearchType.AllowDrop = true;
			CmbResearchType.BackColor = System.Drawing.SystemColors.Window;
			CmbResearchType.CausesValidation = true;
			CmbResearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			CmbResearchType.Enabled = true;
			CmbResearchType.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			CmbResearchType.ForeColor = System.Drawing.SystemColors.WindowText;
			CmbResearchType.IntegralHeight = true;
			CmbResearchType.Location = new System.Drawing.Point(10, 5);
			CmbResearchType.Name = "CmbResearchType";
			CmbResearchType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			CmbResearchType.Size = new System.Drawing.Size(45, 23);
			CmbResearchType.Sorted = false;
			CmbResearchType.TabIndex = 1;
			CmbResearchType.TabStop = true;
			CmbResearchType.Visible = true;
			CmbResearchType.SelectionChangeCommitted += new System.EventHandler(cmbResearchType_SelectionChangeCommitted);
			// 
			// txt_amod_id
			// 
			txt_amod_id.AcceptsReturn = true;
			txt_amod_id.AllowDrop = true;
			txt_amod_id.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_id.Location = new System.Drawing.Point(74, 6);
			txt_amod_id.MaxLength = 0;
			txt_amod_id.Name = "txt_amod_id";
			txt_amod_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_id.Size = new System.Drawing.Size(35, 21);
			txt_amod_id.TabIndex = 181;
			txt_amod_id.Text = "75";
			// 
			// scr_Models
			// 
			scr_Models.AllowDrop = true;
			scr_Models.CausesValidation = true;
			scr_Models.Enabled = true;
			scr_Models.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			scr_Models.LargeChange = 1;
			scr_Models.Location = new System.Drawing.Point(403, 6);
			scr_Models.Maximum = 32767;
			scr_Models.Minimum = 0;
			scr_Models.Name = "scr_Models";
			scr_Models.RightToLeft = System.Windows.Forms.RightToLeft.No;
			scr_Models.Size = new System.Drawing.Size(63, 21);
			scr_Models.SmallChange = 1;
			scr_Models.TabIndex = 3;
			scr_Models.TabStop = true;
			scr_Models.Value = 0;
			scr_Models.Visible = true;
			// 
			// txt_model_number
			// 
			txt_model_number.AcceptsReturn = true;
			txt_model_number.AllowDrop = true;
			txt_model_number.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_model_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_model_number.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_model_number.Enabled = false;
			txt_model_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_model_number.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_model_number.Location = new System.Drawing.Point(505, 6);
			txt_model_number.MaxLength = 4;
			txt_model_number.Name = "txt_model_number";
			txt_model_number.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_model_number.Size = new System.Drawing.Size(33, 21);
			txt_model_number.TabIndex = 4;
			txt_model_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_model_total
			// 
			txt_model_total.AcceptsReturn = true;
			txt_model_total.AllowDrop = true;
			txt_model_total.BackColor = System.Drawing.SystemColors.Menu;
			txt_model_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_model_total.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_model_total.Enabled = false;
			txt_model_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_model_total.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_model_total.Location = new System.Drawing.Point(560, 6);
			txt_model_total.MaxLength = 4;
			txt_model_total.Name = "txt_model_total";
			txt_model_total.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_model_total.Size = new System.Drawing.Size(33, 21);
			txt_model_total.TabIndex = 5;
			txt_model_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cbo_Model
			// 
			cbo_Model.AllowDrop = true;
			cbo_Model.BackColor = System.Drawing.SystemColors.Window;
			cbo_Model.CausesValidation = true;
			cbo_Model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_Model.Enabled = true;
			cbo_Model.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Model.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Model.IntegralHeight = true;
			cbo_Model.Location = new System.Drawing.Point(112, 8);
			cbo_Model.Name = "cbo_Model";
			cbo_Model.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Model.Size = new System.Drawing.Size(284, 21);
			cbo_Model.Sorted = false;
			cbo_Model.TabIndex = 2;
			cbo_Model.TabStop = true;
			cbo_Model.Text = "cbo_Model";
			cbo_Model.Visible = true;
			cbo_Model.SelectionChangeCommitted += new System.EventHandler(cbo_Model_SelectionChangeCommitted);
			// 
			// SSPanel3
			// 
			SSPanel3.AllowDrop = true;
			SSPanel3.BackColor = System.Drawing.Color.Silver;
			SSPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel3.Location = new System.Drawing.Point(0, 64);
			SSPanel3.Name = "SSPanel3";
			SSPanel3.Size = new System.Drawing.Size(577, 25);
			SSPanel3.TabIndex = 182;
			// 
			// _Label6_9
			// 
			_Label6_9.AllowDrop = true;
			_Label6_9.AutoSize = true;
			_Label6_9.BackColor = System.Drawing.Color.Transparent;
			_Label6_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_9.Location = new System.Drawing.Point(471, 10);
			_Label6_9.MinimumSize = new System.Drawing.Size(29, 13);
			_Label6_9.Name = "_Label6_9";
			_Label6_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_9.Size = new System.Drawing.Size(29, 13);
			_Label6_9.TabIndex = 184;
			_Label6_9.Tag = "lbl_Make_number_Of";
			_Label6_9.Text = "Model";
			// 
			// _Label6_10
			// 
			_Label6_10.AllowDrop = true;
			_Label6_10.AutoSize = true;
			_Label6_10.BackColor = System.Drawing.Color.Transparent;
			_Label6_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_10.Location = new System.Drawing.Point(544, 10);
			_Label6_10.MinimumSize = new System.Drawing.Size(9, 13);
			_Label6_10.Name = "_Label6_10";
			_Label6_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_10.Size = new System.Drawing.Size(9, 13);
			_Label6_10.TabIndex = 183;
			_Label6_10.Tag = "lbl_MakeOf";
			_Label6_10.Text = "of";
			// 
			// _Label6_35
			// 
			_Label6_35.AllowDrop = true;
			_Label6_35.AutoSize = true;
			_Label6_35.BackColor = System.Drawing.Color.Transparent;
			_Label6_35.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_35.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_35.Location = new System.Drawing.Point(528, 102);
			_Label6_35.MinimumSize = new System.Drawing.Size(30, 13);
			_Label6_35.Name = "_Label6_35";
			_Label6_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_35.Size = new System.Drawing.Size(30, 13);
			_Label6_35.TabIndex = 455;
			_Label6_35.Text = "Icao:";
			// 
			// _Label6_34
			// 
			_Label6_34.AllowDrop = true;
			_Label6_34.AutoSize = true;
			_Label6_34.BackColor = System.Drawing.Color.Transparent;
			_Label6_34.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_34.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_34.Location = new System.Drawing.Point(390, 80);
			_Label6_34.MinimumSize = new System.Drawing.Size(47, 13);
			_Label6_34.Name = "_Label6_34";
			_Label6_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_34.Size = new System.Drawing.Size(47, 13);
			_Label6_34.TabIndex = 435;
			_Label6_34.Text = "JiQ Size";
			// 
			// _Label6_29
			// 
			_Label6_29.AllowDrop = true;
			_Label6_29.AutoSize = true;
			_Label6_29.BackColor = System.Drawing.SystemColors.Control;
			_Label6_29.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_29.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_29.Location = new System.Drawing.Point(300, 65);
			_Label6_29.MinimumSize = new System.Drawing.Size(83, 13);
			_Label6_29.Name = "_Label6_29";
			_Label6_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_29.Size = new System.Drawing.Size(83, 13);
			_Label6_29.TabIndex = 421;
			_Label6_29.Text = "FAA Model ID:";
			// 
			// _Label6_1
			// 
			_Label6_1.AllowDrop = true;
			_Label6_1.AutoSize = true;
			_Label6_1.BackColor = System.Drawing.SystemColors.Control;
			_Label6_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_1.Location = new System.Drawing.Point(311, 32);
			_Label6_1.MinimumSize = new System.Drawing.Size(51, 13);
			_Label6_1.Name = "_Label6_1";
			_Label6_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_1.Size = new System.Drawing.Size(51, 13);
			_Label6_1.TabIndex = 395;
			_Label6_1.Text = "Airframe:";
			// 
			// _Label6_32
			// 
			_Label6_32.AllowDrop = true;
			_Label6_32.AutoSize = true;
			_Label6_32.BackColor = System.Drawing.Color.Transparent;
			_Label6_32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_32.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_32.Location = new System.Drawing.Point(400, 102);
			_Label6_32.MinimumSize = new System.Drawing.Size(69, 13);
			_Label6_32.Name = "_Label6_32";
			_Label6_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_32.Size = new System.Drawing.Size(69, 13);
			_Label6_32.TabIndex = 368;
			_Label6_32.Text = "Mfr CompId:";
			// 
			// _Label6_28
			// 
			_Label6_28.AllowDrop = true;
			_Label6_28.AutoSize = true;
			_Label6_28.BackColor = System.Drawing.Color.Transparent;
			_Label6_28.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_28.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_28.Location = new System.Drawing.Point(9, -33);
			_Label6_28.MinimumSize = new System.Drawing.Size(606, 13);
			_Label6_28.Name = "_Label6_28";
			_Label6_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_28.Size = new System.Drawing.Size(606, 13);
			_Label6_28.TabIndex = 367;
			_Label6_28.Text = "Manufacturer:";
			// 
			// _Label6_27
			// 
			_Label6_27.AllowDrop = true;
			_Label6_27.AutoSize = true;
			_Label6_27.BackColor = System.Drawing.Color.Transparent;
			_Label6_27.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_27.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_27.Location = new System.Drawing.Point(184, 102);
			_Label6_27.MinimumSize = new System.Drawing.Size(52, 13);
			_Label6_27.Name = "_Label6_27";
			_Label6_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_27.Size = new System.Drawing.Size(52, 13);
			_Label6_27.TabIndex = 366;
			_Label6_27.Text = "Common:";
			// 
			// _Label6_6
			// 
			_Label6_6.AllowDrop = true;
			_Label6_6.AutoSize = true;
			_Label6_6.BackColor = System.Drawing.Color.Transparent;
			_Label6_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_6.Location = new System.Drawing.Point(2, 102);
			_Label6_6.MinimumSize = new System.Drawing.Size(23, 13);
			_Label6_6.Name = "_Label6_6";
			_Label6_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_6.Size = new System.Drawing.Size(23, 13);
			_Label6_6.TabIndex = 244;
			_Label6_6.Text = "Mfr:";
			// 
			// _Label6_4
			// 
			_Label6_4.AllowDrop = true;
			_Label6_4.AutoSize = true;
			_Label6_4.BackColor = System.Drawing.Color.Transparent;
			_Label6_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_4.Location = new System.Drawing.Point(212, 51);
			_Label6_4.MinimumSize = new System.Drawing.Size(45, 13);
			_Label6_4.Name = "_Label6_4";
			_Label6_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_4.Size = new System.Drawing.Size(45, 13);
			_Label6_4.TabIndex = 223;
			_Label6_4.Text = "Abbrev:";
			// 
			// _Label6_3
			// 
			_Label6_3.AllowDrop = true;
			_Label6_3.AutoSize = true;
			_Label6_3.BackColor = System.Drawing.Color.Transparent;
			_Label6_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_3.Location = new System.Drawing.Point(507, 31);
			_Label6_3.MinimumSize = new System.Drawing.Size(79, 13);
			_Label6_3.Name = "_Label6_3";
			_Label6_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_3.Size = new System.Drawing.Size(79, 13);
			_Label6_3.TabIndex = 209;
			_Label6_3.Text = "Weight Class:";
			// 
			// _Label2_0
			// 
			_Label2_0.AllowDrop = true;
			_Label2_0.AutoSize = true;
			_Label2_0.BackColor = System.Drawing.Color.Transparent;
			_Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label2_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label2_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label2_0.Location = new System.Drawing.Point(2, 77);
			_Label2_0.MinimumSize = new System.Drawing.Size(39, 13);
			_Label2_0.Name = "_Label2_0";
			_Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label2_0.Size = new System.Drawing.Size(39, 13);
			_Label2_0.TabIndex = 139;
			_Label2_0.Text = "Model:";
			// 
			// _Label6_7
			// 
			_Label6_7.AllowDrop = true;
			_Label6_7.AutoSize = true;
			_Label6_7.BackColor = System.Drawing.Color.Transparent;
			_Label6_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_7.Location = new System.Drawing.Point(2, 52);
			_Label6_7.MinimumSize = new System.Drawing.Size(36, 13);
			_Label6_7.Name = "_Label6_7";
			_Label6_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_7.Size = new System.Drawing.Size(36, 13);
			_Label6_7.TabIndex = 138;
			_Label6_7.Text = "Make:";
			// 
			// _Label6_0
			// 
			_Label6_0.AllowDrop = true;
			_Label6_0.AutoSize = true;
			_Label6_0.BackColor = System.Drawing.Color.Transparent;
			_Label6_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_0.Location = new System.Drawing.Point(388, 31);
			_Label6_0.MinimumSize = new System.Drawing.Size(37, 13);
			_Label6_0.Name = "_Label6_0";
			_Label6_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_0.Size = new System.Drawing.Size(37, 13);
			_Label6_0.TabIndex = 137;
			_Label6_0.Text = "Type: ";
			// 
			// _Label6_2
			// 
			_Label6_2.AllowDrop = true;
			_Label6_2.AutoSize = true;
			_Label6_2.BackColor = System.Drawing.Color.Transparent;
			_Label6_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_2.Location = new System.Drawing.Point(439, 31);
			_Label6_2.MinimumSize = new System.Drawing.Size(35, 13);
			_Label6_2.Name = "_Label6_2";
			_Label6_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_2.Size = new System.Drawing.Size(35, 13);
			_Label6_2.TabIndex = 136;
			_Label6_2.Text = "Class:";
			// 
			// frame_Status
			// 
			frame_Status.AllowDrop = true;
			frame_Status.BackColor = System.Drawing.SystemColors.Control;
			frame_Status.Controls.Add(lbl_Status);
			frame_Status.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_Status.Enabled = true;
			frame_Status.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_Status.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_Status.Location = new System.Drawing.Point(187, 327);
			frame_Status.Name = "frame_Status";
			frame_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_Status.Size = new System.Drawing.Size(625, 81);
			frame_Status.TabIndex = 221;
			frame_Status.Visible = true;
			// 
			// lbl_Status
			// 
			lbl_Status.AllowDrop = true;
			lbl_Status.BackColor = System.Drawing.SystemColors.Control;
			lbl_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Status.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Status.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Status.Location = new System.Drawing.Point(12, 25);
			lbl_Status.MinimumSize = new System.Drawing.Size(593, 33);
			lbl_Status.Name = "lbl_Status";
			lbl_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Status.Size = new System.Drawing.Size(593, 33);
			lbl_Status.TabIndex = 222;
			lbl_Status.Text = "Loading";
			// 
			// _lbl_specs_77
			// 
			_lbl_specs_77.AllowDrop = true;
			_lbl_specs_77.BackColor = System.Drawing.SystemColors.Control;
			_lbl_specs_77.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_specs_77.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_specs_77.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_specs_77.Location = new System.Drawing.Point(0, 24);
			_lbl_specs_77.MinimumSize = new System.Drawing.Size(14, 17);
			_lbl_specs_77.Name = "_lbl_specs_77";
			_lbl_specs_77.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_specs_77.Size = new System.Drawing.Size(14, 17);
			_lbl_specs_77.TabIndex = 411;
			_lbl_specs_77.Text = "ft:";
			_lbl_specs_77.Click += new System.EventHandler(lbl_specs_Click);
			_lbl_specs_77.DoubleClick += new System.EventHandler(lbl_specs_DoubleClick);
			// 
			// _Label13_2
			// 
			_Label13_2.AllowDrop = true;
			_Label13_2.BackColor = System.Drawing.SystemColors.Control;
			_Label13_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label13_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label13_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label13_2.Location = new System.Drawing.Point(0, 24);
			_Label13_2.MinimumSize = new System.Drawing.Size(65, 17);
			_Label13_2.Name = "_Label13_2";
			_Label13_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label13_2.Size = new System.Drawing.Size(65, 17);
			_Label13_2.TabIndex = 165;
			_Label13_2.Text = "Start Year";
			// 
			// frm_Aircraft_Model
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 15);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(1014, 704);
			ControlBox = false;
			Controls.Add(pnl_PriceRange);
			Controls.Add(SSPanel1);
			Controls.Add(ponl_YearsBuilt);
			Controls.Add(tbr_ToolBar);
			Controls.Add(tab_Aircraft_Model);
			Controls.Add(pnl_ModelMain);
			Controls.Add(frame_Status);
			Controls.Add(_lbl_specs_77);
			Controls.Add(_Label13_2);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(2613, 175);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Aircraft_Model";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Make & Model ";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(cmd_Update, 0);
			commandButtonHelper1.SetStyle(cmdStop, 0);
			commandButtonHelper1.SetStyle(cmdTemp, 0);
			commandButtonHelper1.SetStyle(_cmd_button_array_2, 0);
			commandButtonHelper1.SetStyle(_cmd_button_array_5, 0);
			commandButtonHelper1.SetStyle(_cmd_button_array_1, 0);
			commandButtonHelper1.SetStyle(_cmd_button_array_0, 0);
			commandButtonHelper1.SetStyle(_cmd_button_array_4, 0);
			commandButtonHelper1.SetStyle(_cmd_button_array_3, 0);
			commandButtonHelper1.SetStyle(_cmd_button_array_8, 0);
			commandButtonHelper1.SetStyle(_cmd_button_array_7, 0);
			commandButtonHelper1.SetStyle(_cmd_button_array_6, 0);
			commandButtonHelper1.SetStyle(_cmd_button_0, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Engine, 0);
			commandButtonHelper1.SetStyle(cmd_Remove_Engine, 0);
			commandButtonHelper1.SetStyle(cmdFindEngineModel, 0);
			commandButtonHelper1.SetStyle(cmd_Engine_Cancel, 0);
			commandButtonHelper1.SetStyle(cmd_Engine_Save, 0);
			commandButtonHelper1.SetStyle(_cmdUseage_0, 0);
			commandButtonHelper1.SetStyle(_cmdUseage_1, 0);
			commandButtonHelper1.SetStyle(_cmdUseage_4, 0);
			commandButtonHelper1.SetStyle(_cmdUseage_3, 0);
			commandButtonHelper1.SetStyle(_cmdUseage_2, 0);
			commandButtonHelper1.SetStyle(_cmd_Make_Move1_2, 0);
			commandButtonHelper1.SetStyle(_cmd_Make_Move1_1, 0);
			commandButtonHelper1.SetStyle(_cmd_Make_Move1_0, 0);
			commandButtonHelper1.SetStyle(_CMDModelMap_2, 0);
			commandButtonHelper1.SetStyle(_CMDModelMap_1, 0);
			commandButtonHelper1.SetStyle(_CMDModelMap_0, 0);
			commandButtonHelper1.SetStyle(cmd_new, 0);
			listBoxHelper1.SetSelectionMode(lst_MasterKeyFeature, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_aircraft_wanted, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Spec_Engines, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(UsageList, System.Windows.Forms.SelectionMode.One);
			ToolTipMain.SetToolTip(txt_amod_tot_variable_cost, "Equals (Fuel Costs + (Tot Maint Cost - Engine OH) + Parts + Landing + Crew + Supplies) * Annual Hours)");
			ToolTipMain.SetToolTip(_txt_amod_speed_7, "Vne (MaxOp) IAS");
			ToolTipMain.SetToolTip(_txt_amod_speed_3, "Vmo (MaxOp) IAS");
			ToolTipMain.SetToolTip(cmdFindEngineModel, "Click To Search Engine Model Table");
			ToolTipMain.SetToolTip(_lbl_specs_20, "Click to list Aircraft with selected engine");
			ToolTipMain.SetToolTip(chk_amod_customer_flag, "Check If This Model Is Releaseable To Customers");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grd_Aircraft).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Keyfeature).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_ModelTrend).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_MakeSort).EndInit();
			((System.ComponentModel.ISupportInitialize) grdModelMap).EndInit();
			((System.ComponentModel.ISupportInitialize) grdAircraftMap).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_eventlog).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_amod_journal).EndInit();
			pnl_PriceRange.ResumeLayout(false);
			pnl_PriceRange.PerformLayout();
			SSPanel1.ResumeLayout(false);
			SSPanel1.PerformLayout();
			ponl_YearsBuilt.ResumeLayout(false);
			ponl_YearsBuilt.PerformLayout();
			tbr_ToolBar.ResumeLayout(false);
			tbr_ToolBar.PerformLayout();
			tab_Aircraft_Model.ResumeLayout(false);
			tab_Aircraft_Model.PerformLayout();
			_tab_Aircraft_Model_TabPage0.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage0.PerformLayout();
			_tab_Aircraft_Model_TabPage1.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage1.PerformLayout();
			pnl_ModelFeatures.ResumeLayout(false);
			pnl_ModelFeatures.PerformLayout();
			pnl_MasterKeyFeatures.ResumeLayout(false);
			pnl_MasterKeyFeatures.PerformLayout();
			pnl_FeatureDisplay.ResumeLayout(false);
			pnl_FeatureDisplay.PerformLayout();
			_tab_Aircraft_Model_TabPage2.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage2.PerformLayout();
			_tab_Aircraft_Model_TabPage3.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage3.PerformLayout();
			_tab_Aircraft_Model_TabPage4.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage4.PerformLayout();
			pnl_AnnualBudget.ResumeLayout(false);
			pnl_AnnualBudget.PerformLayout();
			pnl_FixedCosts.ResumeLayout(false);
			pnl_FixedCosts.PerformLayout();
			pnl_DirectCost.ResumeLayout(false);
			pnl_DirectCost.PerformLayout();
			_tab_Aircraft_Model_TabPage5.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage5.PerformLayout();
			pnl_Rotors.ResumeLayout(false);
			pnl_Rotors.PerformLayout();
			pnlCabinDimension.ResumeLayout(false);
			pnlCabinDimension.PerformLayout();
			pnl_Climb.ResumeLayout(false);
			pnl_Climb.PerformLayout();
			pnl_Speed.ResumeLayout(false);
			pnl_Speed.PerformLayout();
			pnl_OtherSpecs.ResumeLayout(false);
			pnl_OtherSpecs.PerformLayout();
			pnl_Props.ResumeLayout(false);
			pnl_Props.PerformLayout();
			pnl_FuselageDimensions.ResumeLayout(false);
			pnl_FuselageDimensions.PerformLayout();
			pnl_Config.ResumeLayout(false);
			pnl_Config.PerformLayout();
			pnl_Weight.ResumeLayout(false);
			pnl_Weight.PerformLayout();
			pnl_FuelCapacity.ResumeLayout(false);
			pnl_FuelCapacity.PerformLayout();
			pnl_EngineData.ResumeLayout(false);
			pnl_EngineData.PerformLayout();
			pnl_ConfigNote.ResumeLayout(false);
			pnl_ConfigNote.PerformLayout();
			pnl_Aircraft_Model_Engine_Add.ResumeLayout(false);
			pnl_Aircraft_Model_Engine_Add.PerformLayout();
			_tab_Aircraft_Model_TabPage6.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage6.PerformLayout();
			_tab_Aircraft_Model_TabPage7.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage7.PerformLayout();
			_tab_Aircraft_Model_TabPage8.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage8.PerformLayout();
			pnl_Useage_Add.ResumeLayout(false);
			pnl_Useage_Add.PerformLayout();
			_tab_Aircraft_Model_TabPage9.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage9.PerformLayout();
			_tab_Aircraft_Model_TabPage10.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage10.PerformLayout();
			frmodelMap.ResumeLayout(false);
			frmodelMap.PerformLayout();
			_tab_Aircraft_Model_TabPage11.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage11.PerformLayout();
			_tab_Aircraft_Model_TabPage12.ResumeLayout(false);
			_tab_Aircraft_Model_TabPage12.PerformLayout();
			pnl_ModelMain.ResumeLayout(false);
			pnl_ModelMain.PerformLayout();
			pnl_Model_Top.ResumeLayout(false);
			pnl_Model_Top.PerformLayout();
			frame_Status.ResumeLayout(false);
			frame_Status.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializetxt_amod_speed();
			Initializetxt_amod_manufacturer();
			Initializetxt_amod_fuselage_length();
			Initializelbl_specs();
			Initializelbl_spec();
			Initializelbl_Prop_number();
			Initializecmd_button_array();
			Initializecmd_button();
			Initializecmd_Make_Move1();
			InitializecmdUseage();
			Initializechk_amod_product();
			InitializeText1();
			InitializeLable13();
			InitializeLabel6();
			InitializeLabel28();
			InitializeLabel20();
			InitializeLabel2();
			InitializeLabel19();
			InitializeLabel18();
			InitializeLabel17();
			InitializeLabel16();
			InitializeLabel13();
			InitializeCMDModelMap();
			tab_Aircraft_ModelPreviousTab = tab_Aircraft_Model.SelectedIndex;
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = JETNET_Homebase.mdi_ResearchAssistant.DefInstance;
			JETNET_Homebase.mdi_ResearchAssistant.DefInstance.Show();
		}
		void Initializetxt_amod_speed()
		{
			txt_amod_speed = new System.Windows.Forms.TextBox[8];
			txt_amod_speed[7] = _txt_amod_speed_7;
			txt_amod_speed[6] = _txt_amod_speed_6;
			txt_amod_speed[5] = _txt_amod_speed_5;
			txt_amod_speed[4] = _txt_amod_speed_4;
			txt_amod_speed[0] = _txt_amod_speed_0;
			txt_amod_speed[1] = _txt_amod_speed_1;
			txt_amod_speed[2] = _txt_amod_speed_2;
			txt_amod_speed[3] = _txt_amod_speed_3;
		}
		void Initializetxt_amod_manufacturer()
		{
			txt_amod_manufacturer = new System.Windows.Forms.TextBox[3];
			txt_amod_manufacturer[2] = _txt_amod_manufacturer_2;
			txt_amod_manufacturer[1] = _txt_amod_manufacturer_1;
			txt_amod_manufacturer[0] = _txt_amod_manufacturer_0;
		}
		void Initializetxt_amod_fuselage_length()
		{
			txt_amod_fuselage_length = new System.Windows.Forms.TextBox[10];
			txt_amod_fuselage_length[0] = _txt_amod_fuselage_length_0;
			txt_amod_fuselage_length[9] = _txt_amod_fuselage_length_9;
			txt_amod_fuselage_length[8] = _txt_amod_fuselage_length_8;
			txt_amod_fuselage_length[6] = _txt_amod_fuselage_length_6;
			txt_amod_fuselage_length[5] = _txt_amod_fuselage_length_5;
			txt_amod_fuselage_length[4] = _txt_amod_fuselage_length_4;
			txt_amod_fuselage_length[3] = _txt_amod_fuselage_length_3;
			txt_amod_fuselage_length[2] = _txt_amod_fuselage_length_2;
			txt_amod_fuselage_length[1] = _txt_amod_fuselage_length_1;
			txt_amod_fuselage_length[7] = _txt_amod_fuselage_length_7;
		}
		void Initializelbl_specs()
		{
			lbl_specs = new System.Windows.Forms.Label[94];
			lbl_specs[93] = _lbl_specs_93;
			lbl_specs[68] = _lbl_specs_68;
			lbl_specs[67] = _lbl_specs_67;
			lbl_specs[33] = _lbl_specs_33;
			lbl_specs[32] = _lbl_specs_32;
			lbl_specs[26] = _lbl_specs_26;
			lbl_specs[20] = _lbl_specs_20;
			lbl_specs[22] = _lbl_specs_22;
			lbl_specs[23] = _lbl_specs_23;
			lbl_specs[24] = _lbl_specs_24;
			lbl_specs[25] = _lbl_specs_25;
			lbl_specs[34] = _lbl_specs_34;
			lbl_specs[21] = _lbl_specs_21;
			lbl_specs[19] = _lbl_specs_19;
			lbl_specs[18] = _lbl_specs_18;
			lbl_specs[17] = _lbl_specs_17;
			lbl_specs[16] = _lbl_specs_16;
			lbl_specs[35] = _lbl_specs_35;
			lbl_specs[12] = _lbl_specs_12;
			lbl_specs[10] = _lbl_specs_10;
			lbl_specs[11] = _lbl_specs_11;
			lbl_specs[9] = _lbl_specs_9;
			lbl_specs[8] = _lbl_specs_8;
			lbl_specs[7] = _lbl_specs_7;
			lbl_specs[31] = _lbl_specs_31;
			lbl_specs[30] = _lbl_specs_30;
			lbl_specs[29] = _lbl_specs_29;
			lbl_specs[28] = _lbl_specs_28;
			lbl_specs[27] = _lbl_specs_27;
			lbl_specs[63] = _lbl_specs_63;
			lbl_specs[6] = _lbl_specs_6;
			lbl_specs[5] = _lbl_specs_5;
			lbl_specs[4] = _lbl_specs_4;
			lbl_specs[71] = _lbl_specs_71;
			lbl_specs[72] = _lbl_specs_72;
			lbl_specs[70] = _lbl_specs_70;
			lbl_specs[2] = _lbl_specs_2;
			lbl_specs[1] = _lbl_specs_1;
			lbl_specs[0] = _lbl_specs_0;
			lbl_specs[57] = _lbl_specs_57;
			lbl_specs[58] = _lbl_specs_58;
			lbl_specs[45] = _lbl_specs_45;
			lbl_specs[44] = _lbl_specs_44;
			lbl_specs[46] = _lbl_specs_46;
			lbl_specs[47] = _lbl_specs_47;
			lbl_specs[36] = _lbl_specs_36;
			lbl_specs[88] = _lbl_specs_88;
			lbl_specs[87] = _lbl_specs_87;
			lbl_specs[53] = _lbl_specs_53;
			lbl_specs[51] = _lbl_specs_51;
			lbl_specs[73] = _lbl_specs_73;
			lbl_specs[37] = _lbl_specs_37;
			lbl_specs[15] = _lbl_specs_15;
			lbl_specs[3] = _lbl_specs_3;
			lbl_specs[50] = _lbl_specs_50;
			lbl_specs[52] = _lbl_specs_52;
			lbl_specs[64] = _lbl_specs_64;
			lbl_specs[65] = _lbl_specs_65;
			lbl_specs[66] = _lbl_specs_66;
			lbl_specs[92] = _lbl_specs_92;
			lbl_specs[91] = _lbl_specs_91;
			lbl_specs[90] = _lbl_specs_90;
			lbl_specs[89] = _lbl_specs_89;
			lbl_specs[40] = _lbl_specs_40;
			lbl_specs[41] = _lbl_specs_41;
			lbl_specs[42] = _lbl_specs_42;
			lbl_specs[43] = _lbl_specs_43;
			lbl_specs[14] = _lbl_specs_14;
			lbl_specs[13] = _lbl_specs_13;
			lbl_specs[59] = _lbl_specs_59;
			lbl_specs[62] = _lbl_specs_62;
			lbl_specs[61] = _lbl_specs_61;
			lbl_specs[60] = _lbl_specs_60;
			lbl_specs[86] = _lbl_specs_86;
			lbl_specs[85] = _lbl_specs_85;
			lbl_specs[84] = _lbl_specs_84;
			lbl_specs[83] = _lbl_specs_83;
			lbl_specs[82] = _lbl_specs_82;
			lbl_specs[81] = _lbl_specs_81;
			lbl_specs[80] = _lbl_specs_80;
			lbl_specs[79] = _lbl_specs_79;
			lbl_specs[78] = _lbl_specs_78;
			lbl_specs[76] = _lbl_specs_76;
			lbl_specs[75] = _lbl_specs_75;
			lbl_specs[74] = _lbl_specs_74;
			lbl_specs[69] = _lbl_specs_69;
			lbl_specs[38] = _lbl_specs_38;
			lbl_specs[39] = _lbl_specs_39;
			lbl_specs[48] = _lbl_specs_48;
			lbl_specs[49] = _lbl_specs_49;
			lbl_specs[54] = _lbl_specs_54;
			lbl_specs[56] = _lbl_specs_56;
			lbl_specs[55] = _lbl_specs_55;
			lbl_specs[77] = _lbl_specs_77;
		}
		void Initializelbl_spec()
		{
			lbl_spec = new System.Windows.Forms.Label[9];
			lbl_spec[2] = _lbl_spec_2;
			lbl_spec[1] = _lbl_spec_1;
			lbl_spec[3] = _lbl_spec_3;
			lbl_spec[0] = _lbl_spec_0;
			lbl_spec[8] = _lbl_spec_8;
		}
		void Initializelbl_Prop_number()
		{
			lbl_Prop_number = new System.Windows.Forms.Label[17];
			lbl_Prop_number[16] = _lbl_Prop_number_16;
		}
		void Initializecmd_button_array()
		{
			cmd_button_array = new System.Windows.Forms.Button[9];
			cmd_button_array[2] = _cmd_button_array_2;
			cmd_button_array[5] = _cmd_button_array_5;
			cmd_button_array[1] = _cmd_button_array_1;
			cmd_button_array[0] = _cmd_button_array_0;
			cmd_button_array[4] = _cmd_button_array_4;
			cmd_button_array[3] = _cmd_button_array_3;
			cmd_button_array[8] = _cmd_button_array_8;
			cmd_button_array[7] = _cmd_button_array_7;
			cmd_button_array[6] = _cmd_button_array_6;
		}
		void Initializecmd_button()
		{
			cmd_button = new System.Windows.Forms.Button[1];
			cmd_button[0] = _cmd_button_0;
		}
		void Initializecmd_Make_Move1()
		{
			cmd_Make_Move1 = new System.Windows.Forms.Button[3];
			cmd_Make_Move1[2] = _cmd_Make_Move1_2;
			cmd_Make_Move1[1] = _cmd_Make_Move1_1;
			cmd_Make_Move1[0] = _cmd_Make_Move1_0;
		}
		void InitializecmdUseage()
		{
			cmdUseage = new System.Windows.Forms.Button[5];
			cmdUseage[0] = _cmdUseage_0;
			cmdUseage[1] = _cmdUseage_1;
			cmdUseage[4] = _cmdUseage_4;
			cmdUseage[3] = _cmdUseage_3;
			cmdUseage[2] = _cmdUseage_2;
		}
		void Initializechk_amod_product()
		{
			chk_amod_product = new System.Windows.Forms.CheckBox[6];
			chk_amod_product[5] = _chk_amod_product_5;
			chk_amod_product[3] = _chk_amod_product_3;
			chk_amod_product[4] = _chk_amod_product_4;
			chk_amod_product[2] = _chk_amod_product_2;
			chk_amod_product[1] = _chk_amod_product_1;
			chk_amod_product[0] = _chk_amod_product_0;
		}
		void InitializeText1()
		{
			Text1 = new System.Windows.Forms.TextBox[3];
			Text1[2] = _Text1_2;
			Text1[0] = _Text1_0;
			Text1[1] = _Text1_1;
		}
		void InitializeLable13()
		{
			Lable13 = new System.Windows.Forms.Label[3];
			Lable13[2] = _Lable13_2;
		}
		void InitializeLabel6()
		{
			Label6 = new System.Windows.Forms.Label[37];
			Label6[33] = _Label6_33;
			Label6[15] = _Label6_15;
			Label6[14] = _Label6_14;
			Label6[13] = _Label6_13;
			Label6[12] = _Label6_12;
			Label6[8] = _Label6_8;
			Label6[26] = _Label6_26;
			Label6[5] = _Label6_5;
			Label6[25] = _Label6_25;
			Label6[31] = _Label6_31;
			Label6[30] = _Label6_30;
			Label6[36] = _Label6_36;
			Label6[21] = _Label6_21;
			Label6[20] = _Label6_20;
			Label6[18] = _Label6_18;
			Label6[19] = _Label6_19;
			Label6[22] = _Label6_22;
			Label6[23] = _Label6_23;
			Label6[24] = _Label6_24;
			Label6[16] = _Label6_16;
			Label6[17] = _Label6_17;
			Label6[11] = _Label6_11;
			Label6[9] = _Label6_9;
			Label6[10] = _Label6_10;
			Label6[35] = _Label6_35;
			Label6[34] = _Label6_34;
			Label6[29] = _Label6_29;
			Label6[1] = _Label6_1;
			Label6[32] = _Label6_32;
			Label6[28] = _Label6_28;
			Label6[27] = _Label6_27;
			Label6[6] = _Label6_6;
			Label6[4] = _Label6_4;
			Label6[3] = _Label6_3;
			Label6[7] = _Label6_7;
			Label6[0] = _Label6_0;
			Label6[2] = _Label6_2;
		}
		void InitializeLabel28()
		{
			Label28 = new System.Windows.Forms.Label[9];
			Label28[6] = _Label28_6;
			Label28[1] = _Label28_1;
			Label28[2] = _Label28_2;
			Label28[3] = _Label28_3;
			Label28[5] = _Label28_5;
			Label28[7] = _Label28_7;
			Label28[8] = _Label28_8;
		}
		void InitializeLabel20()
		{
			Label20 = new System.Windows.Forms.Label[6];
			Label20[4] = _Label20_4;
			Label20[5] = _Label20_5;
			Label20[0] = _Label20_0;
			Label20[1] = _Label20_1;
			Label20[2] = _Label20_2;
			Label20[3] = _Label20_3;
		}
		void InitializeLabel2()
		{
			Label2 = new System.Windows.Forms.Label[1];
			Label2[0] = _Label2_0;
		}
		void InitializeLabel19()
		{
			Label19 = new System.Windows.Forms.Label[7];
			Label19[6] = _Label19_6;
			Label19[0] = _Label19_0;
			Label19[4] = _Label19_4;
			Label19[5] = _Label19_5;
			Label19[1] = _Label19_1;
			Label19[2] = _Label19_2;
			Label19[3] = _Label19_3;
		}
		void InitializeLabel18()
		{
			Label18 = new System.Windows.Forms.Label[9];
			Label18[6] = _Label18_6;
			Label18[7] = _Label18_7;
			Label18[8] = _Label18_8;
			Label18[2] = _Label18_2;
			Label18[3] = _Label18_3;
			Label18[4] = _Label18_4;
			Label18[5] = _Label18_5;
			Label18[0] = _Label18_0;
		}
		void InitializeLabel17()
		{
			Label17 = new System.Windows.Forms.Label[7];
			Label17[4] = _Label17_4;
			Label17[5] = _Label17_5;
			Label17[6] = _Label17_6;
			Label17[2] = _Label17_2;
			Label17[3] = _Label17_3;
		}
		void InitializeLabel16()
		{
			Label16 = new System.Windows.Forms.Label[14];
			Label16[7] = _Label16_7;
			Label16[8] = _Label16_8;
			Label16[9] = _Label16_9;
			Label16[10] = _Label16_10;
			Label16[11] = _Label16_11;
			Label16[12] = _Label16_12;
			Label16[13] = _Label16_13;
			Label16[3] = _Label16_3;
			Label16[4] = _Label16_4;
			Label16[5] = _Label16_5;
			Label16[6] = _Label16_6;
			Label16[0] = _Label16_0;
			Label16[1] = _Label16_1;
			Label16[2] = _Label16_2;
		}
		void InitializeLabel13()
		{
			Label13 = new System.Windows.Forms.Label[9];
			Label13[8] = _Label13_8;
			Label13[7] = _Label13_7;
			Label13[6] = _Label13_6;
			Label13[5] = _Label13_5;
			Label13[4] = _Label13_4;
			Label13[1] = _Label13_1;
			Label13[0] = _Label13_0;
			Label13[2] = _Label13_2;
		}
		void InitializeCMDModelMap()
		{
			CMDModelMap = new System.Windows.Forms.Button[3];
			CMDModelMap[2] = _CMDModelMap_2;
			CMDModelMap[1] = _CMDModelMap_1;
			CMDModelMap[0] = _CMDModelMap_0;
		}
		#endregion
	}
}