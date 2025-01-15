
namespace HomebaseAdministrator
{
	partial class frm_CompanyContactLookup
	{

		#region "Upgrade Support "
		private static frm_CompanyContactLookup m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_CompanyContactLookup DefInstance
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
		public static frm_CompanyContactLookup CreateInstance()
		{
			frm_CompanyContactLookup theInstance = new frm_CompanyContactLookup();
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
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileClose", "mnuFileLogout", "mnuFile", "MainMenu1", "tbr_ToolBar_Buttons_Button1", "tbr_ToolBar_Buttons_Button2", "tbr_ToolBar_Buttons_Button3", "tbr_ToolBar_Buttons_Button4", "tbr_ToolBar_Buttons_Button5", "tbr_ToolBar_Buttons_Button6", "tbr_ToolBar_Buttons_Button7", "tbr_ToolBar_Buttons_Button8", "lblLoading", "tbr_ToolBar", "cmd_Save_CAT", "cmd_Cancel_CAT", "cmd_Delete_CAT", "txt_cacctype_code", "txt_cacctype_Name", "lbl_CAT_Code", "lbl_CAT_Name", "pnl_CAT_AddUpdate", "FG_Cat_List", "cmd_Add_CAT", "_tab_Lookup_TabPage0", "cmd_Add_GAT", "FG_CompAgency", "txt_cagtype_Name", "txt_cagtype_code", "cmd_Delete_GAT", "cmd_Cancel_GAT", "cmd_Save_GAT", "_Label1_40", "_Label1_39", "pnl_GAT_AddUpdate", "_tab_Lookup_TabPage1", "btn_search_bus_type_flags", "combo_bus_type_dropdown", "cmd_Add_CBT", "FG_CBTList", "chkYachtOnly", "chkACOnly", "txt_cbus_keywords", "txt_cbus_Desc", "txt_cbus_type", "txt_cbus_Name", "chkBusIdxOnly", "cmd_Delete_CBT", "cmd_Cancel_CBT", "cmd_Save_CBT", "_Label1_36", "_Label1_35", "_Label1_34", "_Label1_33", "pnl_CBT_AddUpdate", "cmdRemoveBusGroup", "cmdAddBusGroup", "lstBusType", "lstAllBusType", "_Label1_37", "_Label1_38", "pnl_BusGroup", "_tab_Lookup_TabPage2", "cmbDialLineAccessCode", "txt_county_grid_row", "txt_country_name_old", "cmdRegNoUpdate", "cmdRegNoChange", "cmdRegNoDelete", "cmdAddRegno", "RegNoList", "Chk_Company_active", "txt_country_name", "txt_country_code", "cmd_Delete_Country", "cmd_Cancel_Country", "cmd_Save_Country", "txt_country_language", "txt_country_time_vs_eastern", "txt_country_currency", "txt_country_int_access_code", "txt_Abbrev", "txt_regnbr_prefix", "txt_CityCode", "txt_Continent_Name", "_lblDialLineAccessCode_46", "_Shape1_0", "_Line2_1", "_Label7_1", "_Label1_24", "_Label1_25", "_Label1_27", "_Label1_28", "_Label1_29", "_Label1_30", "_Label1_26", "_Label7_0", "_Label1_32", "_Label1_31", "pnl_Country_AddUpdate", "FG_Country", "cmd_Add_Country", "_tab_Lookup_TabPage3", "txt_language_name", "cmd_Delete_Language", "cmd_Cancel_Language", "cmd_Save_Language", "_Label1_22", "pnl_Language_AddUpdate", "FG_Language", "cmd_Add_Language", "_tab_Lookup_TabPage4", "_txt_currency_name_5", "_txt_currency_name_4", "_txt_currency_name_3", "_txt_currency_name_2", "_txt_currency_name_1", "_txt_currency_name_0", "cmd_Save_Currency", "cmd_Cancel_Currency", "cmd_Delete_Currency", "_Label1_45", "_Label1_44", "_Label1_43", "_Label1_42", "_Label1_41", "_Label1_23", "pnl_Currency_Change", "FG_Currency", "cmd_Add_Currency", "_tab_Lookup_TabPage5", "FG_Contact_SirName", "cmd_Add_CSN", "txt_csir_name", "cmd_Delete_CSN", "cmd_Cancel_CSN", "cmd_Save_CSN", "_Label1_15", "pnl_CSN_AddUpdate", "_tab_Lookup_TabPage6", "cmd_Add_CS", "FG_Contact_Suffix", "cmd_Save_CS", "cmd_Cancel_CS", "cmd_Delete_CS", "txt_csuffix_name", "_Label1_14", "pnl_CS_AddUpdate", "_tab_Lookup_TabPage7", "Label2", "_Label1_47", "_Label1_46", "_lblTotTitles_2", "_lblStopTitleLoad_1", "FG_Contact_Title", "_cmd_contact_button_4", "_cmd_contact_button_3", "lstTitleGroup", "lstAllTitleGroups", "_Label1_11", "_Label1_12", "pnl_ContactTitleGroup", "_cmd_contact_button_2", "chk_ctitle_active_flag", "cmd_Save_CT", "cmd_Delete_CT", "txt_ctitle_name", "_Label1_13", "pnl_CT_AddUpdate", "cboSearchTitleGroup", "chkTitlesNotMapped", "chkPilotsNotInPilotsGroup", "chkChairmanCEONotInChairmanCEOGroup", "chkCFONotInCFOGroup", "chkTitleNotInGroup", "cboTitleNotInGroup", "frmTitleSearchOptions", "txt_title_search", "_cmd_contact_button_5", "_cmd_contact_button_6", "_tab_contact_title_TabPage0", "_Label1_50", "_Label1_51", "_Label1_54", "_Label1_53", "_lblStopTitleLoad_0", "_lblTotTitles_0", "_lblTotTitles_1", "_txt_contact_title_search_4", "_txt_contact_title_search_0", "FG_Contact_Title_New", "_cmd_contact_button_0", "_cmd_contact_button_1", "_txt_contact_title_search_1", "frm_update_frame", "cbo_contact_title", "grd_titles_in_group", "_chk_contact_title_0", "_cmd_contact_button_8", "_cmd_contact_button_9", "_cmd_contact_button_7", "_txt_contact_title_search_3", "_txt_contact_title_search_2", "_Label1_52", "frm_update_group", "_opt_contact_title_0", "_opt_contact_title_1", "_opt_contact_title_2", "_tab_contact_title_TabPage1", "tab_contact_title", "_tab_Lookup_TabPage8", "FG_Phone_Type", "cmd_Add_PT", "_vbCheck_0", "txt_ptype_abbrev", "txt_ptype_seq_no", "cmd_Save_PT", "cmd_Cancel_PT", "cmd_Delete_PT", "txt_ptype_name", "_Label1_2", "_Label1_0", "_Label1_1", "pnl_PT_AddUpdate", "_tab_Lookup_TabPage9", "state_active_flag", "CMB_State_TimeZone", "cmb_state_country", "cmd_Save_State", "cmd_Cancel_State", "cmd_Delete_State", "txt_state_code", "txt_state_name", "txt_state_loc", "_Label1_7", "_Label1_3", "_Label1_4", "_Label1_5", "_Label1_6", "pnl_State_AddUpdate", "cmd_Add_State", "FG_State", "_tab_Lookup_TabPage10", "txt_tzone_sort_num", "txt_tzone_name", "txt_tzone_time_vs_eastern", "cmd_Delete_TZ", "cmd_Cancel_TZ", "cmd_Save_TZ", "_Label1_9", "_Label1_8", "_Label1_10", "pnl_TZ_AddUpdate", "cmd_Add_TZ", "FG_TimeZone", "_tab_Lookup_TabPage11", "FG_FracPrograms", "txt_FracProgramProvider", "txt_FracCompID", "txtFracProg_id", "txt_fracPG_code", "txt_fracPG_desc", "txt_FracPG_name", "chk_major_fracPG", "chk_active_fracpg", "cmd_save_frac_PG", "cmd_cancel_FracPG", "cmd_delete_fracPG", "_Label17_7", "_Label17_4", "_Label17_3", "_Label17_2", "_Label17_1", "_Label17_0", "pnl_add_frac_Program", "cmd_add_fracPG", "cmdFracRefresh", "cmdFracMerge", "cboFracToRemove", "cboFracToKeep", "cmdCancelMerge", "cmdMergeFractionals", "_Label17_6", "_Label17_5", "pnl_Merge_Frac_Programs", "_tab_Lookup_TabPage12", "cmd_FindProgram", "txt_find_Comp_id", "chk_FracHistory", "txtmSearchNumber", "cmdStopFrac", "cmdFracMemSearchCancel", "txtmsearchname", "cmdMemSearch", "grdMemSearch", "_Label1_17", "_Label1_16", "pnl_new_FracMember", "txtRefid", "txtfracProgramID", "cmdFracMemDelete", "cmdCancelFracMem", "cmdSaveFracMember", "txtfracMemberID", "txtfracMemberName", "_Label1_20", "_Label1_18", "_Label1_19", "pnl_add_fracMember", "cmdAddFracMember", "cmdFracProgram", "FG_ProgCompany", "_Label43_1", "_Shape1_1", "_Label43_0", "Label40", "_tab_Lookup_TabPage13", "chk_SortTotal", "cmd_Add_Parent_pnlEFIG_NIOL", "cmdFG_Home", "_txtViewOther_1", "cmdNewSearch_pnlEFIG_NIOL", "FG_EFIG_NIOL", "cboNIOL_Associate", "_lblNIOL_CompanyData_25", "_lblNIOL_CompanyData_7", "_lblNIOL_CompanyData_18", "_lblNIOL_CompanyData_17", "_lblNIOL_CompanyData_16", "_lblNIOL_CompanyData_15", "_lblNIOL_CompanyData_14", "_lblNIOL_CompanyData_13", "_lblNIOL_CompanyData_12", "_lblNIOL_CompanyData_8", "_lblNIOL_CompanyData_4", "_lblNIOL_CompanyData_3", "_lblNIOL_CompanyData_2", "_lblNIOL_CompanyData_1", "_lblNIOL_CompanyData_0", "pnlEFIG_NIOL", "_txtViewOther_2", "cboAdd_Comp_Ref", "cmdAdd_CompRef", "_lblNIOL_CompanyData_24", "_lblNIOL_CompanyData_22", "_lblNIOL_CompanyData_23", "pnl_AddFinGroup", "cmd_ASP_dot_Net", "_txtDateRange_pnlEFIG_0", "_cmdSearch_Compy_wDate_0", "_txtViewOther_0", "cmdViewNIOL", "_cboEFIG_SelectGroup_0", "cmdAddEFIG", "FG_EFIG_MC", "_tab_Lists_TabPage0", "lbl_UnRel_Docs", "lbl_UnRel_Comps", "grd_RelatedCompanies", "_tab_Lists_TabPage1", "tab_Lists", "Label3", "_lblNIOL_CompanyData_5", "_lblNIOL_CompanyData_19", "_lblNIOL_CompanyData_9", "_lblNIOL_CompanyData_6", "pnl_EFIG", "cmdDelete_EFIG", "cmdExit_pnlEFIG_Delete", "_lblCompanyData_5", "_lblCompanyData_2", "_lblCompanyData_11", "_lblCompanyData_10", "_lblCompanyData_7", "_lblCompanyData_6", "_lblCompanyData_1", "_lblCompanyData_0", "pnlEFIG_Delete", "txtFG_PID", "txtFIG_Name", "cmdExit_AddFG", "cmdAdd_FG", "_Label1_21", "_lblFIName_0", "pnlEFIG_Add_Group", "_tab_Lookup_TabPage14", "_Label43_2", "_Label43_3", "_Label43_4", "_Label43_6", "_Label43_5", "_FG_Array_0", "_cmd_CIC_0", "_cmd_CIC_1", "_cmd_CIC_2", "_cboEFIG_SelectGroup_1", "_txtCIC_0", "_txtCIC_2", "_cboEFIG_SelectGroup_2", "_cmd_CIC_3", "_txtCIC_1", "_cmd_CIC_4", "_tab_Lookup_TabPage15", "FG_Region", "_frmRegion_0", "txtRegionSourceURL", "txtRegionName", "_cmdSaveNew_1", "_cmdSaveNew_0", "lblLoadingRegion", "_Label1_49", "_Label1_48", "_frmRegion_1", "_tab_Lookup_TabPage16", "tab_Lookup", "FG_Array", "Label1", "Label17", "Label43", "Label7", "Line2", "Shape1", "cboEFIG_SelectGroup", "chk_contact_title", "cmdSaveNew", "cmdSearch_Compy_wDate", "cmd_CIC", "cmd_contact_button", "frmRegion", "lblCompanyData", "lblDialLineAccessCode", "lblFIName", "lblNIOL_CompanyData", "lblStopTitleLoad", "lblTotTitles", "opt_contact_title", "txtCIC", "txtDateRange_pnlEFIG", "txtViewOther", "txt_contact_title_search", "txt_currency_name", "vbCheck", "optionButtonHelper1", "listBoxComboBoxHelper1", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFileLogout;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button1;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button2;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button3;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button4;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button5;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button6;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button7;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button8;
		public System.Windows.Forms.Label lblLoading;
		public System.Windows.Forms.ToolStrip tbr_ToolBar;
		public System.Windows.Forms.Button cmd_Save_CAT;
		public System.Windows.Forms.Button cmd_Cancel_CAT;
		public System.Windows.Forms.Button cmd_Delete_CAT;
		public System.Windows.Forms.TextBox txt_cacctype_code;
		public System.Windows.Forms.TextBox txt_cacctype_Name;
		public System.Windows.Forms.Label lbl_CAT_Code;
		public System.Windows.Forms.Label lbl_CAT_Name;
		public System.Windows.Forms.Panel pnl_CAT_AddUpdate;
		public UpgradeHelpers.DataGridViewFlex FG_Cat_List;
		public System.Windows.Forms.Button cmd_Add_CAT;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage0;
		public System.Windows.Forms.Button cmd_Add_GAT;
		public UpgradeHelpers.DataGridViewFlex FG_CompAgency;
		public System.Windows.Forms.TextBox txt_cagtype_Name;
		public System.Windows.Forms.TextBox txt_cagtype_code;
		public System.Windows.Forms.Button cmd_Delete_GAT;
		public System.Windows.Forms.Button cmd_Cancel_GAT;
		public System.Windows.Forms.Button cmd_Save_GAT;
		private System.Windows.Forms.Label _Label1_40;
		private System.Windows.Forms.Label _Label1_39;
		public System.Windows.Forms.Panel pnl_GAT_AddUpdate;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage1;
		public System.Windows.Forms.Button btn_search_bus_type_flags;
		public System.Windows.Forms.ComboBox combo_bus_type_dropdown;
		public System.Windows.Forms.Button cmd_Add_CBT;
		public UpgradeHelpers.DataGridViewFlex FG_CBTList;
		public System.Windows.Forms.CheckBox chkYachtOnly;
		public System.Windows.Forms.CheckBox chkACOnly;
		public System.Windows.Forms.TextBox txt_cbus_keywords;
		public System.Windows.Forms.TextBox txt_cbus_Desc;
		public System.Windows.Forms.TextBox txt_cbus_type;
		public System.Windows.Forms.TextBox txt_cbus_Name;
		public System.Windows.Forms.CheckBox chkBusIdxOnly;
		public System.Windows.Forms.Button cmd_Delete_CBT;
		public System.Windows.Forms.Button cmd_Cancel_CBT;
		public System.Windows.Forms.Button cmd_Save_CBT;
		private System.Windows.Forms.Label _Label1_36;
		private System.Windows.Forms.Label _Label1_35;
		private System.Windows.Forms.Label _Label1_34;
		private System.Windows.Forms.Label _Label1_33;
		public System.Windows.Forms.Panel pnl_CBT_AddUpdate;
		public System.Windows.Forms.Button cmdRemoveBusGroup;
		public System.Windows.Forms.Button cmdAddBusGroup;
		public System.Windows.Forms.ListBox lstBusType;
		public System.Windows.Forms.ListBox lstAllBusType;
		private System.Windows.Forms.Label _Label1_37;
		private System.Windows.Forms.Label _Label1_38;
		public System.Windows.Forms.Panel pnl_BusGroup;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage2;
		public System.Windows.Forms.ComboBox cmbDialLineAccessCode;
		public System.Windows.Forms.TextBox txt_county_grid_row;
		public System.Windows.Forms.TextBox txt_country_name_old;
		public System.Windows.Forms.Button cmdRegNoUpdate;
		public System.Windows.Forms.Button cmdRegNoChange;
		public System.Windows.Forms.Button cmdRegNoDelete;
		public System.Windows.Forms.Button cmdAddRegno;
		public System.Windows.Forms.ListBox RegNoList;
		public System.Windows.Forms.CheckBox Chk_Company_active;
		public System.Windows.Forms.TextBox txt_country_name;
		public System.Windows.Forms.TextBox txt_country_code;
		public System.Windows.Forms.Button cmd_Delete_Country;
		public System.Windows.Forms.Button cmd_Cancel_Country;
		public System.Windows.Forms.Button cmd_Save_Country;
		public System.Windows.Forms.TextBox txt_country_language;
		public System.Windows.Forms.TextBox txt_country_time_vs_eastern;
		public System.Windows.Forms.TextBox txt_country_currency;
		public System.Windows.Forms.TextBox txt_country_int_access_code;
		public System.Windows.Forms.TextBox txt_Abbrev;
		public System.Windows.Forms.TextBox txt_regnbr_prefix;
		public System.Windows.Forms.TextBox txt_CityCode;
		public System.Windows.Forms.TextBox txt_Continent_Name;
		private System.Windows.Forms.Label _lblDialLineAccessCode_46;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_0;
		private System.Windows.Forms.Label _Line2_1;
		private System.Windows.Forms.Label _Label7_1;
		private System.Windows.Forms.Label _Label1_24;
		private System.Windows.Forms.Label _Label1_25;
		private System.Windows.Forms.Label _Label1_27;
		private System.Windows.Forms.Label _Label1_28;
		private System.Windows.Forms.Label _Label1_29;
		private System.Windows.Forms.Label _Label1_30;
		private System.Windows.Forms.Label _Label1_26;
		private System.Windows.Forms.Label _Label7_0;
		private System.Windows.Forms.Label _Label1_32;
		private System.Windows.Forms.Label _Label1_31;
		public System.Windows.Forms.Panel pnl_Country_AddUpdate;
		public UpgradeHelpers.DataGridViewFlex FG_Country;
		public System.Windows.Forms.Button cmd_Add_Country;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage3;
		public System.Windows.Forms.TextBox txt_language_name;
		public System.Windows.Forms.Button cmd_Delete_Language;
		public System.Windows.Forms.Button cmd_Cancel_Language;
		public System.Windows.Forms.Button cmd_Save_Language;
		private System.Windows.Forms.Label _Label1_22;
		public System.Windows.Forms.Panel pnl_Language_AddUpdate;
		public UpgradeHelpers.DataGridViewFlex FG_Language;
		public System.Windows.Forms.Button cmd_Add_Language;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage4;
		private System.Windows.Forms.TextBox _txt_currency_name_5;
		private System.Windows.Forms.TextBox _txt_currency_name_4;
		private System.Windows.Forms.TextBox _txt_currency_name_3;
		private System.Windows.Forms.TextBox _txt_currency_name_2;
		private System.Windows.Forms.TextBox _txt_currency_name_1;
		private System.Windows.Forms.TextBox _txt_currency_name_0;
		public System.Windows.Forms.Button cmd_Save_Currency;
		public System.Windows.Forms.Button cmd_Cancel_Currency;
		public System.Windows.Forms.Button cmd_Delete_Currency;
		private System.Windows.Forms.Label _Label1_45;
		private System.Windows.Forms.Label _Label1_44;
		private System.Windows.Forms.Label _Label1_43;
		private System.Windows.Forms.Label _Label1_42;
		private System.Windows.Forms.Label _Label1_41;
		private System.Windows.Forms.Label _Label1_23;
		public System.Windows.Forms.Panel pnl_Currency_Change;
		public UpgradeHelpers.DataGridViewFlex FG_Currency;
		public System.Windows.Forms.Button cmd_Add_Currency;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage5;
		public UpgradeHelpers.DataGridViewFlex FG_Contact_SirName;
		public System.Windows.Forms.Button cmd_Add_CSN;
		public System.Windows.Forms.TextBox txt_csir_name;
		public System.Windows.Forms.Button cmd_Delete_CSN;
		public System.Windows.Forms.Button cmd_Cancel_CSN;
		public System.Windows.Forms.Button cmd_Save_CSN;
		private System.Windows.Forms.Label _Label1_15;
		public System.Windows.Forms.Panel pnl_CSN_AddUpdate;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage6;
		public System.Windows.Forms.Button cmd_Add_CS;
		public UpgradeHelpers.DataGridViewFlex FG_Contact_Suffix;
		public System.Windows.Forms.Button cmd_Save_CS;
		public System.Windows.Forms.Button cmd_Cancel_CS;
		public System.Windows.Forms.Button cmd_Delete_CS;
		public System.Windows.Forms.TextBox txt_csuffix_name;
		private System.Windows.Forms.Label _Label1_14;
		public System.Windows.Forms.Panel pnl_CS_AddUpdate;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage7;
		public System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label _Label1_47;
		private System.Windows.Forms.Label _Label1_46;
		private System.Windows.Forms.Label _lblTotTitles_2;
		private System.Windows.Forms.Label _lblStopTitleLoad_1;
		public UpgradeHelpers.DataGridViewFlex FG_Contact_Title;
		private System.Windows.Forms.Button _cmd_contact_button_4;
		private System.Windows.Forms.Button _cmd_contact_button_3;
		public System.Windows.Forms.ListBox lstTitleGroup;
		public System.Windows.Forms.ListBox lstAllTitleGroups;
		private System.Windows.Forms.Label _Label1_11;
		private System.Windows.Forms.Label _Label1_12;
		public System.Windows.Forms.Panel pnl_ContactTitleGroup;
		private System.Windows.Forms.Button _cmd_contact_button_2;
		public System.Windows.Forms.CheckBox chk_ctitle_active_flag;
		public System.Windows.Forms.Button cmd_Save_CT;
		public System.Windows.Forms.Button cmd_Delete_CT;
		public System.Windows.Forms.TextBox txt_ctitle_name;
		private System.Windows.Forms.Label _Label1_13;
		public System.Windows.Forms.Panel pnl_CT_AddUpdate;
		public System.Windows.Forms.ComboBox cboSearchTitleGroup;
		public System.Windows.Forms.CheckBox chkTitlesNotMapped;
		public System.Windows.Forms.CheckBox chkPilotsNotInPilotsGroup;
		public System.Windows.Forms.CheckBox chkChairmanCEONotInChairmanCEOGroup;
		public System.Windows.Forms.CheckBox chkCFONotInCFOGroup;
		public System.Windows.Forms.CheckBox chkTitleNotInGroup;
		public System.Windows.Forms.ComboBox cboTitleNotInGroup;
		public System.Windows.Forms.GroupBox frmTitleSearchOptions;
		public System.Windows.Forms.TextBox txt_title_search;
		private System.Windows.Forms.Button _cmd_contact_button_5;
		private System.Windows.Forms.Button _cmd_contact_button_6;
		private System.Windows.Forms.TabPage _tab_contact_title_TabPage0;
		private System.Windows.Forms.Label _Label1_50;
		private System.Windows.Forms.Label _Label1_51;
		private System.Windows.Forms.Label _Label1_54;
		private System.Windows.Forms.Label _Label1_53;
		private System.Windows.Forms.Label _lblStopTitleLoad_0;
		private System.Windows.Forms.Label _lblTotTitles_0;
		private System.Windows.Forms.Label _lblTotTitles_1;
		private System.Windows.Forms.TextBox _txt_contact_title_search_4;
		private System.Windows.Forms.TextBox _txt_contact_title_search_0;
		public UpgradeHelpers.DataGridViewFlex FG_Contact_Title_New;
		private System.Windows.Forms.Button _cmd_contact_button_0;
		private System.Windows.Forms.Button _cmd_contact_button_1;
		private System.Windows.Forms.TextBox _txt_contact_title_search_1;
		public System.Windows.Forms.GroupBox frm_update_frame;
		public System.Windows.Forms.ComboBox cbo_contact_title;
		public UpgradeHelpers.DataGridViewFlex grd_titles_in_group;
		private System.Windows.Forms.CheckBox _chk_contact_title_0;
		private System.Windows.Forms.Button _cmd_contact_button_8;
		private System.Windows.Forms.Button _cmd_contact_button_9;
		private System.Windows.Forms.Button _cmd_contact_button_7;
		private System.Windows.Forms.TextBox _txt_contact_title_search_3;
		private System.Windows.Forms.TextBox _txt_contact_title_search_2;
		private System.Windows.Forms.Label _Label1_52;
		public System.Windows.Forms.GroupBox frm_update_group;
		private System.Windows.Forms.RadioButton _opt_contact_title_0;
		private System.Windows.Forms.RadioButton _opt_contact_title_1;
		private System.Windows.Forms.RadioButton _opt_contact_title_2;
		private System.Windows.Forms.TabPage _tab_contact_title_TabPage1;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_contact_title;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage8;
		public UpgradeHelpers.DataGridViewFlex FG_Phone_Type;
		public System.Windows.Forms.Button cmd_Add_PT;
		private System.Windows.Forms.CheckBox _vbCheck_0;
		public System.Windows.Forms.TextBox txt_ptype_abbrev;
		public System.Windows.Forms.TextBox txt_ptype_seq_no;
		public System.Windows.Forms.Button cmd_Save_PT;
		public System.Windows.Forms.Button cmd_Cancel_PT;
		public System.Windows.Forms.Button cmd_Delete_PT;
		public System.Windows.Forms.TextBox txt_ptype_name;
		private System.Windows.Forms.Label _Label1_2;
		private System.Windows.Forms.Label _Label1_0;
		private System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.Panel pnl_PT_AddUpdate;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage9;
		public System.Windows.Forms.CheckBox state_active_flag;
		public System.Windows.Forms.ComboBox CMB_State_TimeZone;
		public System.Windows.Forms.ComboBox cmb_state_country;
		public System.Windows.Forms.Button cmd_Save_State;
		public System.Windows.Forms.Button cmd_Cancel_State;
		public System.Windows.Forms.Button cmd_Delete_State;
		public System.Windows.Forms.TextBox txt_state_code;
		public System.Windows.Forms.TextBox txt_state_name;
		public System.Windows.Forms.TextBox txt_state_loc;
		private System.Windows.Forms.Label _Label1_7;
		private System.Windows.Forms.Label _Label1_3;
		private System.Windows.Forms.Label _Label1_4;
		private System.Windows.Forms.Label _Label1_5;
		private System.Windows.Forms.Label _Label1_6;
		public System.Windows.Forms.Panel pnl_State_AddUpdate;
		public System.Windows.Forms.Button cmd_Add_State;
		public UpgradeHelpers.DataGridViewFlex FG_State;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage10;
		public System.Windows.Forms.TextBox txt_tzone_sort_num;
		public System.Windows.Forms.TextBox txt_tzone_name;
		public System.Windows.Forms.TextBox txt_tzone_time_vs_eastern;
		public System.Windows.Forms.Button cmd_Delete_TZ;
		public System.Windows.Forms.Button cmd_Cancel_TZ;
		public System.Windows.Forms.Button cmd_Save_TZ;
		private System.Windows.Forms.Label _Label1_9;
		private System.Windows.Forms.Label _Label1_8;
		private System.Windows.Forms.Label _Label1_10;
		public System.Windows.Forms.Panel pnl_TZ_AddUpdate;
		public System.Windows.Forms.Button cmd_Add_TZ;
		public UpgradeHelpers.DataGridViewFlex FG_TimeZone;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage11;
		public UpgradeHelpers.DataGridViewFlex FG_FracPrograms;
		public System.Windows.Forms.TextBox txt_FracProgramProvider;
		public System.Windows.Forms.TextBox txt_FracCompID;
		public System.Windows.Forms.TextBox txtFracProg_id;
		public System.Windows.Forms.TextBox txt_fracPG_code;
		public System.Windows.Forms.TextBox txt_fracPG_desc;
		public System.Windows.Forms.TextBox txt_FracPG_name;
		public System.Windows.Forms.CheckBox chk_major_fracPG;
		public System.Windows.Forms.CheckBox chk_active_fracpg;
		public System.Windows.Forms.Button cmd_save_frac_PG;
		public System.Windows.Forms.Button cmd_cancel_FracPG;
		public System.Windows.Forms.Button cmd_delete_fracPG;
		private System.Windows.Forms.Label _Label17_7;
		private System.Windows.Forms.Label _Label17_4;
		private System.Windows.Forms.Label _Label17_3;
		private System.Windows.Forms.Label _Label17_2;
		private System.Windows.Forms.Label _Label17_1;
		private System.Windows.Forms.Label _Label17_0;
		public System.Windows.Forms.GroupBox pnl_add_frac_Program;
		public System.Windows.Forms.Button cmd_add_fracPG;
		public System.Windows.Forms.Button cmdFracRefresh;
		public System.Windows.Forms.Button cmdFracMerge;
		public System.Windows.Forms.ComboBox cboFracToRemove;
		public System.Windows.Forms.ComboBox cboFracToKeep;
		public System.Windows.Forms.Button cmdCancelMerge;
		public System.Windows.Forms.Button cmdMergeFractionals;
		private System.Windows.Forms.Label _Label17_6;
		private System.Windows.Forms.Label _Label17_5;
		public System.Windows.Forms.GroupBox pnl_Merge_Frac_Programs;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage12;
		public System.Windows.Forms.Button cmd_FindProgram;
		public System.Windows.Forms.TextBox txt_find_Comp_id;
		public System.Windows.Forms.CheckBox chk_FracHistory;
		public System.Windows.Forms.TextBox txtmSearchNumber;
		public System.Windows.Forms.Button cmdStopFrac;
		public System.Windows.Forms.Button cmdFracMemSearchCancel;
		public System.Windows.Forms.TextBox txtmsearchname;
		public System.Windows.Forms.Button cmdMemSearch;
		public UpgradeHelpers.DataGridViewFlex grdMemSearch;
		private System.Windows.Forms.Label _Label1_17;
		private System.Windows.Forms.Label _Label1_16;
		public System.Windows.Forms.GroupBox pnl_new_FracMember;
		public System.Windows.Forms.TextBox txtRefid;
		public System.Windows.Forms.TextBox txtfracProgramID;
		public System.Windows.Forms.Button cmdFracMemDelete;
		public System.Windows.Forms.Button cmdCancelFracMem;
		public System.Windows.Forms.Button cmdSaveFracMember;
		public System.Windows.Forms.TextBox txtfracMemberID;
		public System.Windows.Forms.TextBox txtfracMemberName;
		private System.Windows.Forms.Label _Label1_20;
		private System.Windows.Forms.Label _Label1_18;
		private System.Windows.Forms.Label _Label1_19;
		public System.Windows.Forms.GroupBox pnl_add_fracMember;
		public System.Windows.Forms.Button cmdAddFracMember;
		public System.Windows.Forms.ComboBox cmdFracProgram;
		public UpgradeHelpers.DataGridViewFlex FG_ProgCompany;
		private System.Windows.Forms.Label _Label43_1;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_1;
		private System.Windows.Forms.Label _Label43_0;
		public System.Windows.Forms.Label Label40;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage13;
		public System.Windows.Forms.CheckBox chk_SortTotal;
		public System.Windows.Forms.Button cmd_Add_Parent_pnlEFIG_NIOL;
		public System.Windows.Forms.Button cmdFG_Home;
		private System.Windows.Forms.TextBox _txtViewOther_1;
		public System.Windows.Forms.Button cmdNewSearch_pnlEFIG_NIOL;
		public UpgradeHelpers.DataGridViewFlex FG_EFIG_NIOL;
		public System.Windows.Forms.ComboBox cboNIOL_Associate;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_25;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_7;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_18;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_17;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_16;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_15;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_14;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_13;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_12;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_8;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_4;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_3;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_2;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_1;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_0;
		public System.Windows.Forms.GroupBox pnlEFIG_NIOL;
		private System.Windows.Forms.TextBox _txtViewOther_2;
		public System.Windows.Forms.ComboBox cboAdd_Comp_Ref;
		public System.Windows.Forms.Button cmdAdd_CompRef;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_24;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_22;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_23;
		public System.Windows.Forms.Panel pnl_AddFinGroup;
		public System.Windows.Forms.Button cmd_ASP_dot_Net;
		private System.Windows.Forms.TextBox _txtDateRange_pnlEFIG_0;
		private System.Windows.Forms.Button _cmdSearch_Compy_wDate_0;
		private System.Windows.Forms.TextBox _txtViewOther_0;
		public System.Windows.Forms.Button cmdViewNIOL;
		private System.Windows.Forms.ComboBox _cboEFIG_SelectGroup_0;
		public System.Windows.Forms.Button cmdAddEFIG;
		public UpgradeHelpers.DataGridViewFlex FG_EFIG_MC;
		private System.Windows.Forms.TabPage _tab_Lists_TabPage0;
		public System.Windows.Forms.Label lbl_UnRel_Docs;
		public System.Windows.Forms.Label lbl_UnRel_Comps;
		public UpgradeHelpers.DataGridViewFlex grd_RelatedCompanies;
		private System.Windows.Forms.TabPage _tab_Lists_TabPage1;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_Lists;
		public System.Windows.Forms.Label Label3;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_5;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_19;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_9;
		private System.Windows.Forms.Label _lblNIOL_CompanyData_6;
		public System.Windows.Forms.GroupBox pnl_EFIG;
		public System.Windows.Forms.Button cmdDelete_EFIG;
		public System.Windows.Forms.Button cmdExit_pnlEFIG_Delete;
		private System.Windows.Forms.Label _lblCompanyData_5;
		private System.Windows.Forms.Label _lblCompanyData_2;
		private System.Windows.Forms.Label _lblCompanyData_11;
		private System.Windows.Forms.Label _lblCompanyData_10;
		private System.Windows.Forms.Label _lblCompanyData_7;
		private System.Windows.Forms.Label _lblCompanyData_6;
		private System.Windows.Forms.Label _lblCompanyData_1;
		private System.Windows.Forms.Label _lblCompanyData_0;
		public System.Windows.Forms.GroupBox pnlEFIG_Delete;
		public System.Windows.Forms.TextBox txtFG_PID;
		public System.Windows.Forms.TextBox txtFIG_Name;
		public System.Windows.Forms.Button cmdExit_AddFG;
		public System.Windows.Forms.Button cmdAdd_FG;
		private System.Windows.Forms.Label _Label1_21;
		private System.Windows.Forms.Label _lblFIName_0;
		public System.Windows.Forms.GroupBox pnlEFIG_Add_Group;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage14;
		private System.Windows.Forms.Label _Label43_2;
		private System.Windows.Forms.Label _Label43_3;
		private System.Windows.Forms.Label _Label43_4;
		private System.Windows.Forms.Label _Label43_6;
		private System.Windows.Forms.Label _Label43_5;
		private UpgradeHelpers.DataGridViewFlex _FG_Array_0;
		private System.Windows.Forms.Button _cmd_CIC_0;
		private System.Windows.Forms.Button _cmd_CIC_1;
		private System.Windows.Forms.Button _cmd_CIC_2;
		private System.Windows.Forms.ComboBox _cboEFIG_SelectGroup_1;
		private System.Windows.Forms.TextBox _txtCIC_0;
		private System.Windows.Forms.TextBox _txtCIC_2;
		private System.Windows.Forms.ComboBox _cboEFIG_SelectGroup_2;
		private System.Windows.Forms.Button _cmd_CIC_3;
		private System.Windows.Forms.TextBox _txtCIC_1;
		private System.Windows.Forms.Button _cmd_CIC_4;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage15;
		public UpgradeHelpers.DataGridViewFlex FG_Region;
		private System.Windows.Forms.GroupBox _frmRegion_0;
		public System.Windows.Forms.TextBox txtRegionSourceURL;
		public System.Windows.Forms.TextBox txtRegionName;
		private System.Windows.Forms.Button _cmdSaveNew_1;
		private System.Windows.Forms.Button _cmdSaveNew_0;
		public System.Windows.Forms.Label lblLoadingRegion;
		private System.Windows.Forms.Label _Label1_49;
		private System.Windows.Forms.Label _Label1_48;
		private System.Windows.Forms.GroupBox _frmRegion_1;
		private System.Windows.Forms.TabPage _tab_Lookup_TabPage16;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_Lookup;
		public UpgradeHelpers.DataGridViewFlex[] FG_Array = new UpgradeHelpers.DataGridViewFlex[1];
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[55];
		public System.Windows.Forms.Label[] Label17 = new System.Windows.Forms.Label[8];
		public System.Windows.Forms.Label[] Label43 = new System.Windows.Forms.Label[7];
		public System.Windows.Forms.Label[] Label7 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] Line2 = new System.Windows.Forms.Label[2];
		public UpgradeHelpers.Gui.ShapeHelper[] Shape1 = new UpgradeHelpers.Gui.ShapeHelper[2];
		public System.Windows.Forms.ComboBox[] cboEFIG_SelectGroup = new System.Windows.Forms.ComboBox[3];
		public System.Windows.Forms.CheckBox[] chk_contact_title = new System.Windows.Forms.CheckBox[1];
		public System.Windows.Forms.Button[] cmdSaveNew = new System.Windows.Forms.Button[2];
		public System.Windows.Forms.Button[] cmdSearch_Compy_wDate = new System.Windows.Forms.Button[1];
		public System.Windows.Forms.Button[] cmd_CIC = new System.Windows.Forms.Button[5];
		public System.Windows.Forms.Button[] cmd_contact_button = new System.Windows.Forms.Button[10];
		public System.Windows.Forms.GroupBox[] frmRegion = new System.Windows.Forms.GroupBox[2];
		public System.Windows.Forms.Label[] lblCompanyData = new System.Windows.Forms.Label[12];
		public System.Windows.Forms.Label[] lblDialLineAccessCode = new System.Windows.Forms.Label[47];
		public System.Windows.Forms.Label[] lblFIName = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.Label[] lblNIOL_CompanyData = new System.Windows.Forms.Label[26];
		public System.Windows.Forms.Label[] lblStopTitleLoad = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] lblTotTitles = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.RadioButton[] opt_contact_title = new System.Windows.Forms.RadioButton[3];
		public System.Windows.Forms.TextBox[] txtCIC = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] txtDateRange_pnlEFIG = new System.Windows.Forms.TextBox[1];
		public System.Windows.Forms.TextBox[] txtViewOther = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] txt_contact_title_search = new System.Windows.Forms.TextBox[5];
		public System.Windows.Forms.TextBox[] txt_currency_name = new System.Windows.Forms.TextBox[6];
		public System.Windows.Forms.CheckBox[] vbCheck = new System.Windows.Forms.CheckBox[1];
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public UpgradeHelpers.Gui.Controls.ListControlHelper listBoxComboBoxHelper1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		private int tab_LookupPreviousTab;
		private int tab_ListsPreviousTab;
		public System.ComponentModel.ComponentResourceManager resources; //gap-note manual change to assign the toolbar images
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CompanyContactLookup));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileLogout = new System.Windows.Forms.ToolStripMenuItem();
			tbr_ToolBar = new System.Windows.Forms.ToolStrip();
			tbr_ToolBar_Buttons_Button1 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button2 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button3 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button4 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button5 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button6 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button7 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button8 = new System.Windows.Forms.ToolStripButton();
			lblLoading = new System.Windows.Forms.Label();
			tab_Lookup = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_Lookup_TabPage0 = new System.Windows.Forms.TabPage();
			pnl_CAT_AddUpdate = new System.Windows.Forms.Panel();
			cmd_Save_CAT = new System.Windows.Forms.Button();
			cmd_Cancel_CAT = new System.Windows.Forms.Button();
			cmd_Delete_CAT = new System.Windows.Forms.Button();
			txt_cacctype_code = new System.Windows.Forms.TextBox();
			txt_cacctype_Name = new System.Windows.Forms.TextBox();
			lbl_CAT_Code = new System.Windows.Forms.Label();
			lbl_CAT_Name = new System.Windows.Forms.Label();
			FG_Cat_List = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_CAT = new System.Windows.Forms.Button();
			_tab_Lookup_TabPage1 = new System.Windows.Forms.TabPage();
			cmd_Add_GAT = new System.Windows.Forms.Button();
			FG_CompAgency = new UpgradeHelpers.DataGridViewFlex(components);
			pnl_GAT_AddUpdate = new System.Windows.Forms.Panel();
			txt_cagtype_Name = new System.Windows.Forms.TextBox();
			txt_cagtype_code = new System.Windows.Forms.TextBox();
			cmd_Delete_GAT = new System.Windows.Forms.Button();
			cmd_Cancel_GAT = new System.Windows.Forms.Button();
			cmd_Save_GAT = new System.Windows.Forms.Button();
			_Label1_40 = new System.Windows.Forms.Label();
			_Label1_39 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage2 = new System.Windows.Forms.TabPage();
			btn_search_bus_type_flags = new System.Windows.Forms.Button();
			combo_bus_type_dropdown = new System.Windows.Forms.ComboBox();
			cmd_Add_CBT = new System.Windows.Forms.Button();
			FG_CBTList = new UpgradeHelpers.DataGridViewFlex(components);
			pnl_CBT_AddUpdate = new System.Windows.Forms.Panel();
			chkYachtOnly = new System.Windows.Forms.CheckBox();
			chkACOnly = new System.Windows.Forms.CheckBox();
			txt_cbus_keywords = new System.Windows.Forms.TextBox();
			txt_cbus_Desc = new System.Windows.Forms.TextBox();
			txt_cbus_type = new System.Windows.Forms.TextBox();
			txt_cbus_Name = new System.Windows.Forms.TextBox();
			chkBusIdxOnly = new System.Windows.Forms.CheckBox();
			cmd_Delete_CBT = new System.Windows.Forms.Button();
			cmd_Cancel_CBT = new System.Windows.Forms.Button();
			cmd_Save_CBT = new System.Windows.Forms.Button();
			_Label1_36 = new System.Windows.Forms.Label();
			_Label1_35 = new System.Windows.Forms.Label();
			_Label1_34 = new System.Windows.Forms.Label();
			_Label1_33 = new System.Windows.Forms.Label();
			pnl_BusGroup = new System.Windows.Forms.Panel();
			cmdRemoveBusGroup = new System.Windows.Forms.Button();
			cmdAddBusGroup = new System.Windows.Forms.Button();
			lstBusType = new System.Windows.Forms.ListBox();
			lstAllBusType = new System.Windows.Forms.ListBox();
			_Label1_37 = new System.Windows.Forms.Label();
			_Label1_38 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage3 = new System.Windows.Forms.TabPage();
			pnl_Country_AddUpdate = new System.Windows.Forms.Panel();
			cmbDialLineAccessCode = new System.Windows.Forms.ComboBox();
			txt_county_grid_row = new System.Windows.Forms.TextBox();
			txt_country_name_old = new System.Windows.Forms.TextBox();
			cmdRegNoUpdate = new System.Windows.Forms.Button();
			cmdRegNoChange = new System.Windows.Forms.Button();
			cmdRegNoDelete = new System.Windows.Forms.Button();
			cmdAddRegno = new System.Windows.Forms.Button();
			RegNoList = new System.Windows.Forms.ListBox();
			Chk_Company_active = new System.Windows.Forms.CheckBox();
			txt_country_name = new System.Windows.Forms.TextBox();
			txt_country_code = new System.Windows.Forms.TextBox();
			cmd_Delete_Country = new System.Windows.Forms.Button();
			cmd_Cancel_Country = new System.Windows.Forms.Button();
			cmd_Save_Country = new System.Windows.Forms.Button();
			txt_country_language = new System.Windows.Forms.TextBox();
			txt_country_time_vs_eastern = new System.Windows.Forms.TextBox();
			txt_country_currency = new System.Windows.Forms.TextBox();
			txt_country_int_access_code = new System.Windows.Forms.TextBox();
			txt_Abbrev = new System.Windows.Forms.TextBox();
			txt_regnbr_prefix = new System.Windows.Forms.TextBox();
			txt_CityCode = new System.Windows.Forms.TextBox();
			txt_Continent_Name = new System.Windows.Forms.TextBox();
			_lblDialLineAccessCode_46 = new System.Windows.Forms.Label();
			_Shape1_0 = new UpgradeHelpers.Gui.ShapeHelper();
			_Line2_1 = new System.Windows.Forms.Label();
			_Label7_1 = new System.Windows.Forms.Label();
			_Label1_24 = new System.Windows.Forms.Label();
			_Label1_25 = new System.Windows.Forms.Label();
			_Label1_27 = new System.Windows.Forms.Label();
			_Label1_28 = new System.Windows.Forms.Label();
			_Label1_29 = new System.Windows.Forms.Label();
			_Label1_30 = new System.Windows.Forms.Label();
			_Label1_26 = new System.Windows.Forms.Label();
			_Label7_0 = new System.Windows.Forms.Label();
			_Label1_32 = new System.Windows.Forms.Label();
			_Label1_31 = new System.Windows.Forms.Label();
			FG_Country = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_Country = new System.Windows.Forms.Button();
			_tab_Lookup_TabPage4 = new System.Windows.Forms.TabPage();
			pnl_Language_AddUpdate = new System.Windows.Forms.Panel();
			txt_language_name = new System.Windows.Forms.TextBox();
			cmd_Delete_Language = new System.Windows.Forms.Button();
			cmd_Cancel_Language = new System.Windows.Forms.Button();
			cmd_Save_Language = new System.Windows.Forms.Button();
			_Label1_22 = new System.Windows.Forms.Label();
			FG_Language = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_Language = new System.Windows.Forms.Button();
			_tab_Lookup_TabPage5 = new System.Windows.Forms.TabPage();
			pnl_Currency_Change = new System.Windows.Forms.Panel();
			_txt_currency_name_5 = new System.Windows.Forms.TextBox();
			_txt_currency_name_4 = new System.Windows.Forms.TextBox();
			_txt_currency_name_3 = new System.Windows.Forms.TextBox();
			_txt_currency_name_2 = new System.Windows.Forms.TextBox();
			_txt_currency_name_1 = new System.Windows.Forms.TextBox();
			_txt_currency_name_0 = new System.Windows.Forms.TextBox();
			cmd_Save_Currency = new System.Windows.Forms.Button();
			cmd_Cancel_Currency = new System.Windows.Forms.Button();
			cmd_Delete_Currency = new System.Windows.Forms.Button();
			_Label1_45 = new System.Windows.Forms.Label();
			_Label1_44 = new System.Windows.Forms.Label();
			_Label1_43 = new System.Windows.Forms.Label();
			_Label1_42 = new System.Windows.Forms.Label();
			_Label1_41 = new System.Windows.Forms.Label();
			_Label1_23 = new System.Windows.Forms.Label();
			FG_Currency = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_Currency = new System.Windows.Forms.Button();
			_tab_Lookup_TabPage6 = new System.Windows.Forms.TabPage();
			FG_Contact_SirName = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_CSN = new System.Windows.Forms.Button();
			pnl_CSN_AddUpdate = new System.Windows.Forms.Panel();
			txt_csir_name = new System.Windows.Forms.TextBox();
			cmd_Delete_CSN = new System.Windows.Forms.Button();
			cmd_Cancel_CSN = new System.Windows.Forms.Button();
			cmd_Save_CSN = new System.Windows.Forms.Button();
			_Label1_15 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage7 = new System.Windows.Forms.TabPage();
			cmd_Add_CS = new System.Windows.Forms.Button();
			FG_Contact_Suffix = new UpgradeHelpers.DataGridViewFlex(components);
			pnl_CS_AddUpdate = new System.Windows.Forms.Panel();
			cmd_Save_CS = new System.Windows.Forms.Button();
			cmd_Cancel_CS = new System.Windows.Forms.Button();
			cmd_Delete_CS = new System.Windows.Forms.Button();
			txt_csuffix_name = new System.Windows.Forms.TextBox();
			_Label1_14 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage8 = new System.Windows.Forms.TabPage();
			Label2 = new System.Windows.Forms.Label();
			tab_contact_title = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_contact_title_TabPage0 = new System.Windows.Forms.TabPage();
			_Label1_47 = new System.Windows.Forms.Label();
			_Label1_46 = new System.Windows.Forms.Label();
			_lblTotTitles_2 = new System.Windows.Forms.Label();
			_lblStopTitleLoad_1 = new System.Windows.Forms.Label();
			FG_Contact_Title = new UpgradeHelpers.DataGridViewFlex(components);
			pnl_ContactTitleGroup = new System.Windows.Forms.Panel();
			_cmd_contact_button_4 = new System.Windows.Forms.Button();
			_cmd_contact_button_3 = new System.Windows.Forms.Button();
			lstTitleGroup = new System.Windows.Forms.ListBox();
			lstAllTitleGroups = new System.Windows.Forms.ListBox();
			_Label1_11 = new System.Windows.Forms.Label();
			_Label1_12 = new System.Windows.Forms.Label();
			pnl_CT_AddUpdate = new System.Windows.Forms.Panel();
			_cmd_contact_button_2 = new System.Windows.Forms.Button();
			chk_ctitle_active_flag = new System.Windows.Forms.CheckBox();
			cmd_Save_CT = new System.Windows.Forms.Button();
			cmd_Delete_CT = new System.Windows.Forms.Button();
			txt_ctitle_name = new System.Windows.Forms.TextBox();
			_Label1_13 = new System.Windows.Forms.Label();
			cboSearchTitleGroup = new System.Windows.Forms.ComboBox();
			frmTitleSearchOptions = new System.Windows.Forms.GroupBox();
			chkTitlesNotMapped = new System.Windows.Forms.CheckBox();
			chkPilotsNotInPilotsGroup = new System.Windows.Forms.CheckBox();
			chkChairmanCEONotInChairmanCEOGroup = new System.Windows.Forms.CheckBox();
			chkCFONotInCFOGroup = new System.Windows.Forms.CheckBox();
			chkTitleNotInGroup = new System.Windows.Forms.CheckBox();
			cboTitleNotInGroup = new System.Windows.Forms.ComboBox();
			txt_title_search = new System.Windows.Forms.TextBox();
			_cmd_contact_button_5 = new System.Windows.Forms.Button();
			_cmd_contact_button_6 = new System.Windows.Forms.Button();
			_tab_contact_title_TabPage1 = new System.Windows.Forms.TabPage();
			_Label1_50 = new System.Windows.Forms.Label();
			_Label1_51 = new System.Windows.Forms.Label();
			_Label1_54 = new System.Windows.Forms.Label();
			_Label1_53 = new System.Windows.Forms.Label();
			_lblStopTitleLoad_0 = new System.Windows.Forms.Label();
			_lblTotTitles_0 = new System.Windows.Forms.Label();
			_lblTotTitles_1 = new System.Windows.Forms.Label();
			_txt_contact_title_search_4 = new System.Windows.Forms.TextBox();
			_txt_contact_title_search_0 = new System.Windows.Forms.TextBox();
			FG_Contact_Title_New = new UpgradeHelpers.DataGridViewFlex(components);
			_cmd_contact_button_0 = new System.Windows.Forms.Button();
			frm_update_frame = new System.Windows.Forms.GroupBox();
			_cmd_contact_button_1 = new System.Windows.Forms.Button();
			_txt_contact_title_search_1 = new System.Windows.Forms.TextBox();
			cbo_contact_title = new System.Windows.Forms.ComboBox();
			grd_titles_in_group = new UpgradeHelpers.DataGridViewFlex(components);
			_chk_contact_title_0 = new System.Windows.Forms.CheckBox();
			_cmd_contact_button_8 = new System.Windows.Forms.Button();
			frm_update_group = new System.Windows.Forms.GroupBox();
			_cmd_contact_button_9 = new System.Windows.Forms.Button();
			_cmd_contact_button_7 = new System.Windows.Forms.Button();
			_txt_contact_title_search_3 = new System.Windows.Forms.TextBox();
			_txt_contact_title_search_2 = new System.Windows.Forms.TextBox();
			_Label1_52 = new System.Windows.Forms.Label();
			_opt_contact_title_0 = new System.Windows.Forms.RadioButton();
			_opt_contact_title_1 = new System.Windows.Forms.RadioButton();
			_opt_contact_title_2 = new System.Windows.Forms.RadioButton();
			_tab_Lookup_TabPage9 = new System.Windows.Forms.TabPage();
			FG_Phone_Type = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Add_PT = new System.Windows.Forms.Button();
			pnl_PT_AddUpdate = new System.Windows.Forms.Panel();
			_vbCheck_0 = new System.Windows.Forms.CheckBox();
			txt_ptype_abbrev = new System.Windows.Forms.TextBox();
			txt_ptype_seq_no = new System.Windows.Forms.TextBox();
			cmd_Save_PT = new System.Windows.Forms.Button();
			cmd_Cancel_PT = new System.Windows.Forms.Button();
			cmd_Delete_PT = new System.Windows.Forms.Button();
			txt_ptype_name = new System.Windows.Forms.TextBox();
			_Label1_2 = new System.Windows.Forms.Label();
			_Label1_0 = new System.Windows.Forms.Label();
			_Label1_1 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage10 = new System.Windows.Forms.TabPage();
			pnl_State_AddUpdate = new System.Windows.Forms.Panel();
			state_active_flag = new System.Windows.Forms.CheckBox();
			CMB_State_TimeZone = new System.Windows.Forms.ComboBox();
			cmb_state_country = new System.Windows.Forms.ComboBox();
			cmd_Save_State = new System.Windows.Forms.Button();
			cmd_Cancel_State = new System.Windows.Forms.Button();
			cmd_Delete_State = new System.Windows.Forms.Button();
			txt_state_code = new System.Windows.Forms.TextBox();
			txt_state_name = new System.Windows.Forms.TextBox();
			txt_state_loc = new System.Windows.Forms.TextBox();
			_Label1_7 = new System.Windows.Forms.Label();
			_Label1_3 = new System.Windows.Forms.Label();
			_Label1_4 = new System.Windows.Forms.Label();
			_Label1_5 = new System.Windows.Forms.Label();
			_Label1_6 = new System.Windows.Forms.Label();
			cmd_Add_State = new System.Windows.Forms.Button();
			FG_State = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_Lookup_TabPage11 = new System.Windows.Forms.TabPage();
			pnl_TZ_AddUpdate = new System.Windows.Forms.Panel();
			txt_tzone_sort_num = new System.Windows.Forms.TextBox();
			txt_tzone_name = new System.Windows.Forms.TextBox();
			txt_tzone_time_vs_eastern = new System.Windows.Forms.TextBox();
			cmd_Delete_TZ = new System.Windows.Forms.Button();
			cmd_Cancel_TZ = new System.Windows.Forms.Button();
			cmd_Save_TZ = new System.Windows.Forms.Button();
			_Label1_9 = new System.Windows.Forms.Label();
			_Label1_8 = new System.Windows.Forms.Label();
			_Label1_10 = new System.Windows.Forms.Label();
			cmd_Add_TZ = new System.Windows.Forms.Button();
			FG_TimeZone = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_Lookup_TabPage12 = new System.Windows.Forms.TabPage();
			FG_FracPrograms = new UpgradeHelpers.DataGridViewFlex(components);
			pnl_add_frac_Program = new System.Windows.Forms.GroupBox();
			txt_FracProgramProvider = new System.Windows.Forms.TextBox();
			txt_FracCompID = new System.Windows.Forms.TextBox();
			txtFracProg_id = new System.Windows.Forms.TextBox();
			txt_fracPG_code = new System.Windows.Forms.TextBox();
			txt_fracPG_desc = new System.Windows.Forms.TextBox();
			txt_FracPG_name = new System.Windows.Forms.TextBox();
			chk_major_fracPG = new System.Windows.Forms.CheckBox();
			chk_active_fracpg = new System.Windows.Forms.CheckBox();
			cmd_save_frac_PG = new System.Windows.Forms.Button();
			cmd_cancel_FracPG = new System.Windows.Forms.Button();
			cmd_delete_fracPG = new System.Windows.Forms.Button();
			_Label17_7 = new System.Windows.Forms.Label();
			_Label17_4 = new System.Windows.Forms.Label();
			_Label17_3 = new System.Windows.Forms.Label();
			_Label17_2 = new System.Windows.Forms.Label();
			_Label17_1 = new System.Windows.Forms.Label();
			_Label17_0 = new System.Windows.Forms.Label();
			cmd_add_fracPG = new System.Windows.Forms.Button();
			cmdFracRefresh = new System.Windows.Forms.Button();
			cmdFracMerge = new System.Windows.Forms.Button();
			pnl_Merge_Frac_Programs = new System.Windows.Forms.GroupBox();
			cboFracToRemove = new System.Windows.Forms.ComboBox();
			cboFracToKeep = new System.Windows.Forms.ComboBox();
			cmdCancelMerge = new System.Windows.Forms.Button();
			cmdMergeFractionals = new System.Windows.Forms.Button();
			_Label17_6 = new System.Windows.Forms.Label();
			_Label17_5 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage13 = new System.Windows.Forms.TabPage();
			cmd_FindProgram = new System.Windows.Forms.Button();
			txt_find_Comp_id = new System.Windows.Forms.TextBox();
			pnl_new_FracMember = new System.Windows.Forms.GroupBox();
			chk_FracHistory = new System.Windows.Forms.CheckBox();
			txtmSearchNumber = new System.Windows.Forms.TextBox();
			cmdStopFrac = new System.Windows.Forms.Button();
			cmdFracMemSearchCancel = new System.Windows.Forms.Button();
			txtmsearchname = new System.Windows.Forms.TextBox();
			cmdMemSearch = new System.Windows.Forms.Button();
			grdMemSearch = new UpgradeHelpers.DataGridViewFlex(components);
			_Label1_17 = new System.Windows.Forms.Label();
			_Label1_16 = new System.Windows.Forms.Label();
			pnl_add_fracMember = new System.Windows.Forms.GroupBox();
			txtRefid = new System.Windows.Forms.TextBox();
			txtfracProgramID = new System.Windows.Forms.TextBox();
			cmdFracMemDelete = new System.Windows.Forms.Button();
			cmdCancelFracMem = new System.Windows.Forms.Button();
			cmdSaveFracMember = new System.Windows.Forms.Button();
			txtfracMemberID = new System.Windows.Forms.TextBox();
			txtfracMemberName = new System.Windows.Forms.TextBox();
			_Label1_20 = new System.Windows.Forms.Label();
			_Label1_18 = new System.Windows.Forms.Label();
			_Label1_19 = new System.Windows.Forms.Label();
			cmdAddFracMember = new System.Windows.Forms.Button();
			cmdFracProgram = new System.Windows.Forms.ComboBox();
			FG_ProgCompany = new UpgradeHelpers.DataGridViewFlex(components);
			_Label43_1 = new System.Windows.Forms.Label();
			_Shape1_1 = new UpgradeHelpers.Gui.ShapeHelper();
			_Label43_0 = new System.Windows.Forms.Label();
			Label40 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage14 = new System.Windows.Forms.TabPage();
			pnlEFIG_NIOL = new System.Windows.Forms.GroupBox();
			chk_SortTotal = new System.Windows.Forms.CheckBox();
			cmd_Add_Parent_pnlEFIG_NIOL = new System.Windows.Forms.Button();
			cmdFG_Home = new System.Windows.Forms.Button();
			_txtViewOther_1 = new System.Windows.Forms.TextBox();
			cmdNewSearch_pnlEFIG_NIOL = new System.Windows.Forms.Button();
			FG_EFIG_NIOL = new UpgradeHelpers.DataGridViewFlex(components);
			cboNIOL_Associate = new System.Windows.Forms.ComboBox();
			_lblNIOL_CompanyData_25 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_7 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_18 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_17 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_16 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_15 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_14 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_13 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_12 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_8 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_4 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_3 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_2 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_1 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_0 = new System.Windows.Forms.Label();
			pnl_EFIG = new System.Windows.Forms.GroupBox();
			pnl_AddFinGroup = new System.Windows.Forms.Panel();
			_txtViewOther_2 = new System.Windows.Forms.TextBox();
			cboAdd_Comp_Ref = new System.Windows.Forms.ComboBox();
			cmdAdd_CompRef = new System.Windows.Forms.Button();
			_lblNIOL_CompanyData_24 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_22 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_23 = new System.Windows.Forms.Label();
			cmd_ASP_dot_Net = new System.Windows.Forms.Button();
			_txtDateRange_pnlEFIG_0 = new System.Windows.Forms.TextBox();
			_cmdSearch_Compy_wDate_0 = new System.Windows.Forms.Button();
			_txtViewOther_0 = new System.Windows.Forms.TextBox();
			cmdViewNIOL = new System.Windows.Forms.Button();
			_cboEFIG_SelectGroup_0 = new System.Windows.Forms.ComboBox();
			cmdAddEFIG = new System.Windows.Forms.Button();
			tab_Lists = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_Lists_TabPage0 = new System.Windows.Forms.TabPage();
			FG_EFIG_MC = new UpgradeHelpers.DataGridViewFlex(components);
			_tab_Lists_TabPage1 = new System.Windows.Forms.TabPage();
			lbl_UnRel_Docs = new System.Windows.Forms.Label();
			lbl_UnRel_Comps = new System.Windows.Forms.Label();
			grd_RelatedCompanies = new UpgradeHelpers.DataGridViewFlex(components);
			Label3 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_5 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_19 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_9 = new System.Windows.Forms.Label();
			_lblNIOL_CompanyData_6 = new System.Windows.Forms.Label();
			pnlEFIG_Delete = new System.Windows.Forms.GroupBox();
			cmdDelete_EFIG = new System.Windows.Forms.Button();
			cmdExit_pnlEFIG_Delete = new System.Windows.Forms.Button();
			_lblCompanyData_5 = new System.Windows.Forms.Label();
			_lblCompanyData_2 = new System.Windows.Forms.Label();
			_lblCompanyData_11 = new System.Windows.Forms.Label();
			_lblCompanyData_10 = new System.Windows.Forms.Label();
			_lblCompanyData_7 = new System.Windows.Forms.Label();
			_lblCompanyData_6 = new System.Windows.Forms.Label();
			_lblCompanyData_1 = new System.Windows.Forms.Label();
			_lblCompanyData_0 = new System.Windows.Forms.Label();
			pnlEFIG_Add_Group = new System.Windows.Forms.GroupBox();
			txtFG_PID = new System.Windows.Forms.TextBox();
			txtFIG_Name = new System.Windows.Forms.TextBox();
			cmdExit_AddFG = new System.Windows.Forms.Button();
			cmdAdd_FG = new System.Windows.Forms.Button();
			_Label1_21 = new System.Windows.Forms.Label();
			_lblFIName_0 = new System.Windows.Forms.Label();
			_tab_Lookup_TabPage15 = new System.Windows.Forms.TabPage();
			_Label43_2 = new System.Windows.Forms.Label();
			_Label43_3 = new System.Windows.Forms.Label();
			_Label43_4 = new System.Windows.Forms.Label();
			_Label43_6 = new System.Windows.Forms.Label();
			_Label43_5 = new System.Windows.Forms.Label();
			_FG_Array_0 = new UpgradeHelpers.DataGridViewFlex(components);
			_cmd_CIC_0 = new System.Windows.Forms.Button();
			_cmd_CIC_1 = new System.Windows.Forms.Button();
			_cmd_CIC_2 = new System.Windows.Forms.Button();
			_cboEFIG_SelectGroup_1 = new System.Windows.Forms.ComboBox();
			_txtCIC_0 = new System.Windows.Forms.TextBox();
			_txtCIC_2 = new System.Windows.Forms.TextBox();
			_cboEFIG_SelectGroup_2 = new System.Windows.Forms.ComboBox();
			_cmd_CIC_3 = new System.Windows.Forms.Button();
			_txtCIC_1 = new System.Windows.Forms.TextBox();
			_cmd_CIC_4 = new System.Windows.Forms.Button();
			_tab_Lookup_TabPage16 = new System.Windows.Forms.TabPage();
			_frmRegion_0 = new System.Windows.Forms.GroupBox();
			FG_Region = new UpgradeHelpers.DataGridViewFlex(components);
			_frmRegion_1 = new System.Windows.Forms.GroupBox();
			txtRegionSourceURL = new System.Windows.Forms.TextBox();
			txtRegionName = new System.Windows.Forms.TextBox();
			_cmdSaveNew_1 = new System.Windows.Forms.Button();
			_cmdSaveNew_0 = new System.Windows.Forms.Button();
			lblLoadingRegion = new System.Windows.Forms.Label();
			_Label1_49 = new System.Windows.Forms.Label();
			_Label1_48 = new System.Windows.Forms.Label();
			tbr_ToolBar.SuspendLayout();
			tab_Lookup.SuspendLayout();
			_tab_Lookup_TabPage0.SuspendLayout();
			pnl_CAT_AddUpdate.SuspendLayout();
			_tab_Lookup_TabPage1.SuspendLayout();
			pnl_GAT_AddUpdate.SuspendLayout();
			_tab_Lookup_TabPage2.SuspendLayout();
			pnl_CBT_AddUpdate.SuspendLayout();
			pnl_BusGroup.SuspendLayout();
			_tab_Lookup_TabPage3.SuspendLayout();
			pnl_Country_AddUpdate.SuspendLayout();
			_tab_Lookup_TabPage4.SuspendLayout();
			pnl_Language_AddUpdate.SuspendLayout();
			_tab_Lookup_TabPage5.SuspendLayout();
			pnl_Currency_Change.SuspendLayout();
			_tab_Lookup_TabPage6.SuspendLayout();
			pnl_CSN_AddUpdate.SuspendLayout();
			_tab_Lookup_TabPage7.SuspendLayout();
			pnl_CS_AddUpdate.SuspendLayout();
			_tab_Lookup_TabPage8.SuspendLayout();
			tab_contact_title.SuspendLayout();
			_tab_contact_title_TabPage0.SuspendLayout();
			pnl_ContactTitleGroup.SuspendLayout();
			pnl_CT_AddUpdate.SuspendLayout();
			frmTitleSearchOptions.SuspendLayout();
			_tab_contact_title_TabPage1.SuspendLayout();
			frm_update_frame.SuspendLayout();
			frm_update_group.SuspendLayout();
			_tab_Lookup_TabPage9.SuspendLayout();
			pnl_PT_AddUpdate.SuspendLayout();
			_tab_Lookup_TabPage10.SuspendLayout();
			pnl_State_AddUpdate.SuspendLayout();
			_tab_Lookup_TabPage11.SuspendLayout();
			pnl_TZ_AddUpdate.SuspendLayout();
			_tab_Lookup_TabPage12.SuspendLayout();
			pnl_add_frac_Program.SuspendLayout();
			pnl_Merge_Frac_Programs.SuspendLayout();
			_tab_Lookup_TabPage13.SuspendLayout();
			pnl_new_FracMember.SuspendLayout();
			pnl_add_fracMember.SuspendLayout();
			_tab_Lookup_TabPage14.SuspendLayout();
			pnlEFIG_NIOL.SuspendLayout();
			pnl_EFIG.SuspendLayout();
			pnl_AddFinGroup.SuspendLayout();
			tab_Lists.SuspendLayout();
			_tab_Lists_TabPage0.SuspendLayout();
			_tab_Lists_TabPage1.SuspendLayout();
			pnlEFIG_Delete.SuspendLayout();
			pnlEFIG_Add_Group.SuspendLayout();
			_tab_Lookup_TabPage15.SuspendLayout();
			_tab_Lookup_TabPage16.SuspendLayout();
			_frmRegion_0.SuspendLayout();
			_frmRegion_1.SuspendLayout();
			SuspendLayout();
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			listBoxComboBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListControlHelper(components);
			((System.ComponentModel.ISupportInitialize) listBoxComboBoxHelper1).BeginInit();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) FG_Cat_List).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_CompAgency).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_CBTList).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Country).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Language).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Currency).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Contact_SirName).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Contact_Suffix).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Contact_Title).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Contact_Title_New).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_titles_in_group).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Phone_Type).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_State).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_TimeZone).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_FracPrograms).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdMemSearch).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_ProgCompany).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_EFIG_NIOL).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_EFIG_MC).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_RelatedCompanies).BeginInit();
			((System.ComponentModel.ISupportInitialize) _FG_Array_0).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_Region).BeginInit();
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
			mnuFileClose.Text = "&close";
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
			// lblLoading
			// 
			lblLoading.AllowDrop = true;
			lblLoading.BackColor = System.Drawing.SystemColors.Control;
			lblLoading.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLoading.ForeColor = System.Drawing.SystemColors.ControlText;
			lblLoading.Location = new System.Drawing.Point(576, 594);
			lblLoading.MinimumSize = new System.Drawing.Size(253, 15);
			lblLoading.Name = "lblLoading";
			lblLoading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLoading.Size = new System.Drawing.Size(253, 15);
			lblLoading.TabIndex = 318;
			lblLoading.Text = "Loading ##,### of ##,### Records";
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
			tab_Lookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_Lookup.ItemSize = new System.Drawing.Size(162, 18);
			tab_Lookup.Location = new System.Drawing.Point(8, 56);
			tab_Lookup.Multiline = true;
			tab_Lookup.Name = "tab_Lookup";
			tab_Lookup.Size = new System.Drawing.Size(985, 647);
			tab_Lookup.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_Lookup.TabIndex = 1;
			tab_Lookup.SelectedIndexChanged += new System.EventHandler(tab_Lookup_SelectedIndexChanged);
			// 
			// _tab_Lookup_TabPage0
			// 
			_tab_Lookup_TabPage0.Controls.Add(pnl_CAT_AddUpdate);
			_tab_Lookup_TabPage0.Controls.Add(FG_Cat_List);
			_tab_Lookup_TabPage0.Controls.Add(cmd_Add_CAT);
			_tab_Lookup_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage0.Text = "Company Account Type";
			// 
			// pnl_CAT_AddUpdate
			// 
			pnl_CAT_AddUpdate.AllowDrop = true;
			pnl_CAT_AddUpdate.BackColor = System.Drawing.SystemColors.ScrollBar;
			pnl_CAT_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_CAT_AddUpdate.Controls.Add(cmd_Save_CAT);
			pnl_CAT_AddUpdate.Controls.Add(cmd_Cancel_CAT);
			pnl_CAT_AddUpdate.Controls.Add(cmd_Delete_CAT);
			pnl_CAT_AddUpdate.Controls.Add(txt_cacctype_code);
			pnl_CAT_AddUpdate.Controls.Add(txt_cacctype_Name);
			pnl_CAT_AddUpdate.Controls.Add(lbl_CAT_Code);
			pnl_CAT_AddUpdate.Controls.Add(lbl_CAT_Name);
			pnl_CAT_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_CAT_AddUpdate.Location = new System.Drawing.Point(324, 74);
			pnl_CAT_AddUpdate.Name = "pnl_CAT_AddUpdate";
			pnl_CAT_AddUpdate.Size = new System.Drawing.Size(345, 199);
			pnl_CAT_AddUpdate.TabIndex = 16;
			pnl_CAT_AddUpdate.Visible = false;
			// 
			// cmd_Save_CAT
			// 
			cmd_Save_CAT.AllowDrop = true;
			cmd_Save_CAT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_CAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_CAT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_CAT.Location = new System.Drawing.Point(11, 8);
			cmd_Save_CAT.Name = "cmd_Save_CAT";
			cmd_Save_CAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_CAT.Size = new System.Drawing.Size(57, 25);
			cmd_Save_CAT.TabIndex = 21;
			cmd_Save_CAT.Text = "&Save";
			cmd_Save_CAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_CAT.UseVisualStyleBackColor = false;
			cmd_Save_CAT.Click += new System.EventHandler(cmd_Save_CAT_Click);
			// 
			// cmd_Cancel_CAT
			// 
			cmd_Cancel_CAT.AllowDrop = true;
			cmd_Cancel_CAT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_CAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_CAT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_CAT.Location = new System.Drawing.Point(95, 8);
			cmd_Cancel_CAT.Name = "cmd_Cancel_CAT";
			cmd_Cancel_CAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_CAT.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_CAT.TabIndex = 20;
			cmd_Cancel_CAT.Text = "&Cancel";
			cmd_Cancel_CAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_CAT.UseVisualStyleBackColor = false;
			cmd_Cancel_CAT.Click += new System.EventHandler(cmd_Cancel_CAT_Click);
			// 
			// cmd_Delete_CAT
			// 
			cmd_Delete_CAT.AllowDrop = true;
			cmd_Delete_CAT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_CAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_CAT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_CAT.Location = new System.Drawing.Point(186, 8);
			cmd_Delete_CAT.Name = "cmd_Delete_CAT";
			cmd_Delete_CAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_CAT.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_CAT.TabIndex = 19;
			cmd_Delete_CAT.Text = "&Delete";
			cmd_Delete_CAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_CAT.UseVisualStyleBackColor = false;
			cmd_Delete_CAT.Click += new System.EventHandler(cmd_Delete_CAT_Click);
			// 
			// txt_cacctype_code
			// 
			txt_cacctype_code.AcceptsReturn = true;
			txt_cacctype_code.AllowDrop = true;
			txt_cacctype_code.BackColor = System.Drawing.SystemColors.Window;
			txt_cacctype_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cacctype_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cacctype_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cacctype_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cacctype_code.Location = new System.Drawing.Point(17, 82);
			txt_cacctype_code.MaxLength = 2;
			txt_cacctype_code.Name = "txt_cacctype_code";
			txt_cacctype_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cacctype_code.Size = new System.Drawing.Size(27, 19);
			txt_cacctype_code.TabIndex = 18;
			// 
			// txt_cacctype_Name
			// 
			txt_cacctype_Name.AcceptsReturn = true;
			txt_cacctype_Name.AllowDrop = true;
			txt_cacctype_Name.BackColor = System.Drawing.SystemColors.Window;
			txt_cacctype_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cacctype_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cacctype_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cacctype_Name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cacctype_Name.Location = new System.Drawing.Point(18, 139);
			txt_cacctype_Name.MaxLength = 15;
			txt_cacctype_Name.Name = "txt_cacctype_Name";
			txt_cacctype_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cacctype_Name.Size = new System.Drawing.Size(315, 19);
			txt_cacctype_Name.TabIndex = 17;
			// 
			// lbl_CAT_Code
			// 
			lbl_CAT_Code.AllowDrop = true;
			lbl_CAT_Code.BackColor = System.Drawing.SystemColors.Control;
			lbl_CAT_Code.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_CAT_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_CAT_Code.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_CAT_Code.Location = new System.Drawing.Point(16, 57);
			lbl_CAT_Code.MinimumSize = new System.Drawing.Size(41, 17);
			lbl_CAT_Code.Name = "lbl_CAT_Code";
			lbl_CAT_Code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_CAT_Code.Size = new System.Drawing.Size(41, 17);
			lbl_CAT_Code.TabIndex = 23;
			lbl_CAT_Code.Text = "Code";
			// 
			// lbl_CAT_Name
			// 
			lbl_CAT_Name.AllowDrop = true;
			lbl_CAT_Name.BackColor = System.Drawing.SystemColors.Control;
			lbl_CAT_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_CAT_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_CAT_Name.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_CAT_Name.Location = new System.Drawing.Point(17, 113);
			lbl_CAT_Name.MinimumSize = new System.Drawing.Size(33, 17);
			lbl_CAT_Name.Name = "lbl_CAT_Name";
			lbl_CAT_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_CAT_Name.Size = new System.Drawing.Size(33, 17);
			lbl_CAT_Name.TabIndex = 22;
			lbl_CAT_Name.Text = "Name";
			// 
			// FG_Cat_List
			// 
			FG_Cat_List.AllowDrop = true;
			FG_Cat_List.AllowUserToAddRows = false;
			FG_Cat_List.AllowUserToDeleteRows = false;
			FG_Cat_List.AllowUserToResizeColumns = false;
			FG_Cat_List.AllowUserToResizeRows = false;
			FG_Cat_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Cat_List.ColumnsCount = 2;
			FG_Cat_List.FixedColumns = 0;
			FG_Cat_List.FixedRows = 1;
			FG_Cat_List.Location = new System.Drawing.Point(18, 36);
			FG_Cat_List.Name = "FG_Cat_List";
			FG_Cat_List.ReadOnly = true;
			FG_Cat_List.RowsCount = 2;
			FG_Cat_List.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Cat_List.ShowCellToolTips = false;
			FG_Cat_List.Size = new System.Drawing.Size(289, 370);
			FG_Cat_List.StandardTab = true;
			FG_Cat_List.TabIndex = 14;
			FG_Cat_List.Click += new System.EventHandler(FG_Cat_List_Click);
			// 
			// cmd_Add_CAT
			// 
			cmd_Add_CAT.AllowDrop = true;
			cmd_Add_CAT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_CAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_CAT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_CAT.Location = new System.Drawing.Point(325, 38);
			cmd_Add_CAT.Name = "cmd_Add_CAT";
			cmd_Add_CAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_CAT.Size = new System.Drawing.Size(57, 25);
			cmd_Add_CAT.TabIndex = 15;
			cmd_Add_CAT.Text = "&Add";
			cmd_Add_CAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_CAT.UseVisualStyleBackColor = false;
			cmd_Add_CAT.Click += new System.EventHandler(cmd_Add_CAT_Click);
			// 
			// _tab_Lookup_TabPage1
			// 
			_tab_Lookup_TabPage1.Controls.Add(cmd_Add_GAT);
			_tab_Lookup_TabPage1.Controls.Add(FG_CompAgency);
			_tab_Lookup_TabPage1.Controls.Add(pnl_GAT_AddUpdate);
			_tab_Lookup_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage1.Text = "Company Agency Type";
			// 
			// cmd_Add_GAT
			// 
			cmd_Add_GAT.AllowDrop = true;
			cmd_Add_GAT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_GAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_GAT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_GAT.Location = new System.Drawing.Point(291, 46);
			cmd_Add_GAT.Name = "cmd_Add_GAT";
			cmd_Add_GAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_GAT.Size = new System.Drawing.Size(57, 25);
			cmd_Add_GAT.TabIndex = 13;
			cmd_Add_GAT.Text = "&Add";
			cmd_Add_GAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_GAT.UseVisualStyleBackColor = false;
			cmd_Add_GAT.Click += new System.EventHandler(cmd_Add_GAT_Click);
			// 
			// FG_CompAgency
			// 
			FG_CompAgency.AllowDrop = true;
			FG_CompAgency.AllowUserToAddRows = false;
			FG_CompAgency.AllowUserToDeleteRows = false;
			FG_CompAgency.AllowUserToResizeColumns = false;
			FG_CompAgency.AllowUserToResizeRows = false;
			FG_CompAgency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_CompAgency.ColumnsCount = 2;
			FG_CompAgency.FixedColumns = 0;
			FG_CompAgency.FixedRows = 1;
			FG_CompAgency.Location = new System.Drawing.Point(27, 44);
			FG_CompAgency.Name = "FG_CompAgency";
			FG_CompAgency.ReadOnly = true;
			FG_CompAgency.RowsCount = 2;
			FG_CompAgency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_CompAgency.ShowCellToolTips = false;
			FG_CompAgency.Size = new System.Drawing.Size(253, 380);
			FG_CompAgency.StandardTab = true;
			FG_CompAgency.TabIndex = 12;
			FG_CompAgency.Click += new System.EventHandler(FG_CompAgency_Click);
			// 
			// pnl_GAT_AddUpdate
			// 
			pnl_GAT_AddUpdate.AllowDrop = true;
			pnl_GAT_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_GAT_AddUpdate.Controls.Add(txt_cagtype_Name);
			pnl_GAT_AddUpdate.Controls.Add(txt_cagtype_code);
			pnl_GAT_AddUpdate.Controls.Add(cmd_Delete_GAT);
			pnl_GAT_AddUpdate.Controls.Add(cmd_Cancel_GAT);
			pnl_GAT_AddUpdate.Controls.Add(cmd_Save_GAT);
			pnl_GAT_AddUpdate.Controls.Add(_Label1_40);
			pnl_GAT_AddUpdate.Controls.Add(_Label1_39);
			pnl_GAT_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_GAT_AddUpdate.Location = new System.Drawing.Point(290, 78);
			pnl_GAT_AddUpdate.Name = "pnl_GAT_AddUpdate";
			pnl_GAT_AddUpdate.Size = new System.Drawing.Size(345, 225);
			pnl_GAT_AddUpdate.TabIndex = 24;
			pnl_GAT_AddUpdate.Visible = false;
			// 
			// txt_cagtype_Name
			// 
			txt_cagtype_Name.AcceptsReturn = true;
			txt_cagtype_Name.AllowDrop = true;
			txt_cagtype_Name.BackColor = System.Drawing.SystemColors.Window;
			txt_cagtype_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cagtype_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cagtype_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cagtype_Name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cagtype_Name.Location = new System.Drawing.Point(16, 184);
			txt_cagtype_Name.MaxLength = 15;
			txt_cagtype_Name.Name = "txt_cagtype_Name";
			txt_cagtype_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cagtype_Name.Size = new System.Drawing.Size(315, 19);
			txt_cagtype_Name.TabIndex = 29;
			// 
			// txt_cagtype_code
			// 
			txt_cagtype_code.AcceptsReturn = true;
			txt_cagtype_code.AllowDrop = true;
			txt_cagtype_code.BackColor = System.Drawing.SystemColors.Window;
			txt_cagtype_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cagtype_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cagtype_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cagtype_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cagtype_code.Location = new System.Drawing.Point(16, 104);
			txt_cagtype_code.MaxLength = 1;
			txt_cagtype_code.Name = "txt_cagtype_code";
			txt_cagtype_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cagtype_code.Size = new System.Drawing.Size(27, 19);
			txt_cagtype_code.TabIndex = 28;
			// 
			// cmd_Delete_GAT
			// 
			cmd_Delete_GAT.AllowDrop = true;
			cmd_Delete_GAT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_GAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_GAT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_GAT.Location = new System.Drawing.Point(171, 8);
			cmd_Delete_GAT.Name = "cmd_Delete_GAT";
			cmd_Delete_GAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_GAT.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_GAT.TabIndex = 27;
			cmd_Delete_GAT.Text = "&Delete";
			cmd_Delete_GAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_GAT.UseVisualStyleBackColor = false;
			cmd_Delete_GAT.Click += new System.EventHandler(cmd_Delete_GAT_Click);
			// 
			// cmd_Cancel_GAT
			// 
			cmd_Cancel_GAT.AllowDrop = true;
			cmd_Cancel_GAT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_GAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_GAT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_GAT.Location = new System.Drawing.Point(90, 8);
			cmd_Cancel_GAT.Name = "cmd_Cancel_GAT";
			cmd_Cancel_GAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_GAT.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_GAT.TabIndex = 26;
			cmd_Cancel_GAT.Text = "&Cancel";
			cmd_Cancel_GAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_GAT.UseVisualStyleBackColor = false;
			cmd_Cancel_GAT.Click += new System.EventHandler(cmd_Cancel_GAT_Click);
			// 
			// cmd_Save_GAT
			// 
			cmd_Save_GAT.AllowDrop = true;
			cmd_Save_GAT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_GAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_GAT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_GAT.Location = new System.Drawing.Point(13, 8);
			cmd_Save_GAT.Name = "cmd_Save_GAT";
			cmd_Save_GAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_GAT.Size = new System.Drawing.Size(57, 25);
			cmd_Save_GAT.TabIndex = 25;
			cmd_Save_GAT.Text = "&Save";
			cmd_Save_GAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_GAT.UseVisualStyleBackColor = false;
			cmd_Save_GAT.Click += new System.EventHandler(cmd_Save_GAT_Click);
			// 
			// _Label1_40
			// 
			_Label1_40.AllowDrop = true;
			_Label1_40.BackColor = System.Drawing.SystemColors.Control;
			_Label1_40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_40.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_40.Location = new System.Drawing.Point(16, 160);
			_Label1_40.MinimumSize = new System.Drawing.Size(33, 17);
			_Label1_40.Name = "_Label1_40";
			_Label1_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_40.Size = new System.Drawing.Size(33, 17);
			_Label1_40.TabIndex = 31;
			_Label1_40.Text = "Name";
			_Label1_40.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_39
			// 
			_Label1_39.AllowDrop = true;
			_Label1_39.BackColor = System.Drawing.SystemColors.Control;
			_Label1_39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_39.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_39.Location = new System.Drawing.Point(16, 80);
			_Label1_39.MinimumSize = new System.Drawing.Size(41, 17);
			_Label1_39.Name = "_Label1_39";
			_Label1_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_39.Size = new System.Drawing.Size(41, 17);
			_Label1_39.TabIndex = 30;
			_Label1_39.Text = "Code";
			_Label1_39.Click += new System.EventHandler(Label1_Click);
			// 
			// _tab_Lookup_TabPage2
			// 
			_tab_Lookup_TabPage2.Controls.Add(btn_search_bus_type_flags);
			_tab_Lookup_TabPage2.Controls.Add(combo_bus_type_dropdown);
			_tab_Lookup_TabPage2.Controls.Add(cmd_Add_CBT);
			_tab_Lookup_TabPage2.Controls.Add(FG_CBTList);
			_tab_Lookup_TabPage2.Controls.Add(pnl_CBT_AddUpdate);
			_tab_Lookup_TabPage2.Controls.Add(pnl_BusGroup);
			_tab_Lookup_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage2.Text = "Company Business Type";
			// 
			// btn_search_bus_type_flags
			// 
			btn_search_bus_type_flags.AllowDrop = true;
			btn_search_bus_type_flags.BackColor = System.Drawing.SystemColors.Control;
			btn_search_bus_type_flags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_search_bus_type_flags.ForeColor = System.Drawing.SystemColors.ControlText;
			btn_search_bus_type_flags.Location = new System.Drawing.Point(304, 12);
			btn_search_bus_type_flags.Name = "btn_search_bus_type_flags";
			btn_search_bus_type_flags.RightToLeft = System.Windows.Forms.RightToLeft.No;
			btn_search_bus_type_flags.Size = new System.Drawing.Size(65, 25);
			btn_search_bus_type_flags.TabIndex = 292;
			btn_search_bus_type_flags.Text = "Search";
			btn_search_bus_type_flags.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			btn_search_bus_type_flags.UseVisualStyleBackColor = false;
			btn_search_bus_type_flags.Click += new System.EventHandler(btn_search_bus_type_flags_Click);
			// 
			// combo_bus_type_dropdown
			// 
			combo_bus_type_dropdown.AllowDrop = true;
			combo_bus_type_dropdown.BackColor = System.Drawing.SystemColors.Window;
			combo_bus_type_dropdown.CausesValidation = true;
			combo_bus_type_dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			combo_bus_type_dropdown.Enabled = true;
			combo_bus_type_dropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			combo_bus_type_dropdown.ForeColor = System.Drawing.SystemColors.WindowText;
			combo_bus_type_dropdown.IntegralHeight = true;
			combo_bus_type_dropdown.Location = new System.Drawing.Point(192, 12);
			combo_bus_type_dropdown.Name = "combo_bus_type_dropdown";
			combo_bus_type_dropdown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			combo_bus_type_dropdown.Size = new System.Drawing.Size(105, 21);
			combo_bus_type_dropdown.Sorted = false;
			combo_bus_type_dropdown.TabIndex = 291;
			combo_bus_type_dropdown.TabStop = true;
			combo_bus_type_dropdown.Visible = true;
			// 
			// cmd_Add_CBT
			// 
			cmd_Add_CBT.AllowDrop = true;
			cmd_Add_CBT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_CBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_CBT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_CBT.Location = new System.Drawing.Point(432, 36);
			cmd_Add_CBT.Name = "cmd_Add_CBT";
			cmd_Add_CBT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_CBT.Size = new System.Drawing.Size(57, 25);
			cmd_Add_CBT.TabIndex = 11;
			cmd_Add_CBT.Text = "&Add";
			cmd_Add_CBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_CBT.UseVisualStyleBackColor = false;
			cmd_Add_CBT.Click += new System.EventHandler(cmd_Add_CBT_Click);
			// 
			// FG_CBTList
			// 
			FG_CBTList.AllowDrop = true;
			FG_CBTList.AllowUserToAddRows = false;
			FG_CBTList.AllowUserToDeleteRows = false;
			FG_CBTList.AllowUserToResizeColumns = false;
			FG_CBTList.AllowUserToResizeRows = false;
			FG_CBTList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_CBTList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_CBTList.ColumnsCount = 5;
			FG_CBTList.FixedColumns = 0;
			FG_CBTList.FixedRows = 1;
			FG_CBTList.Location = new System.Drawing.Point(16, 40);
			FG_CBTList.Name = "FG_CBTList";
			FG_CBTList.ReadOnly = true;
			FG_CBTList.RowsCount = 2;
			FG_CBTList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_CBTList.ShowCellToolTips = false;
			FG_CBTList.Size = new System.Drawing.Size(408, 400);
			FG_CBTList.StandardTab = true;
			FG_CBTList.TabIndex = 10;
			FG_CBTList.Click += new System.EventHandler(FG_CBTList_Click);
			// 
			// pnl_CBT_AddUpdate
			// 
			pnl_CBT_AddUpdate.AllowDrop = true;
			pnl_CBT_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_CBT_AddUpdate.Controls.Add(chkYachtOnly);
			pnl_CBT_AddUpdate.Controls.Add(chkACOnly);
			pnl_CBT_AddUpdate.Controls.Add(txt_cbus_keywords);
			pnl_CBT_AddUpdate.Controls.Add(txt_cbus_Desc);
			pnl_CBT_AddUpdate.Controls.Add(txt_cbus_type);
			pnl_CBT_AddUpdate.Controls.Add(txt_cbus_Name);
			pnl_CBT_AddUpdate.Controls.Add(chkBusIdxOnly);
			pnl_CBT_AddUpdate.Controls.Add(cmd_Delete_CBT);
			pnl_CBT_AddUpdate.Controls.Add(cmd_Cancel_CBT);
			pnl_CBT_AddUpdate.Controls.Add(cmd_Save_CBT);
			pnl_CBT_AddUpdate.Controls.Add(_Label1_36);
			pnl_CBT_AddUpdate.Controls.Add(_Label1_35);
			pnl_CBT_AddUpdate.Controls.Add(_Label1_34);
			pnl_CBT_AddUpdate.Controls.Add(_Label1_33);
			pnl_CBT_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_CBT_AddUpdate.Location = new System.Drawing.Point(432, 68);
			pnl_CBT_AddUpdate.Name = "pnl_CBT_AddUpdate";
			pnl_CBT_AddUpdate.Size = new System.Drawing.Size(515, 188);
			pnl_CBT_AddUpdate.TabIndex = 32;
			pnl_CBT_AddUpdate.Visible = false;
			// 
			// chkYachtOnly
			// 
			chkYachtOnly.AllowDrop = true;
			chkYachtOnly.Appearance = System.Windows.Forms.Appearance.Normal;
			chkYachtOnly.BackColor = System.Drawing.SystemColors.Control;
			chkYachtOnly.CausesValidation = true;
			chkYachtOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkYachtOnly.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkYachtOnly.Enabled = true;
			chkYachtOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkYachtOnly.ForeColor = System.Drawing.SystemColors.ControlText;
			chkYachtOnly.Location = new System.Drawing.Point(408, 48);
			chkYachtOnly.Name = "chkYachtOnly";
			chkYachtOnly.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkYachtOnly.Size = new System.Drawing.Size(105, 13);
			chkYachtOnly.TabIndex = 290;
			chkYachtOnly.TabStop = true;
			chkYachtOnly.Text = "Use for Yachts?";
			chkYachtOnly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkYachtOnly.Visible = true;
			// 
			// chkACOnly
			// 
			chkACOnly.AllowDrop = true;
			chkACOnly.Appearance = System.Windows.Forms.Appearance.Normal;
			chkACOnly.BackColor = System.Drawing.SystemColors.Control;
			chkACOnly.CausesValidation = true;
			chkACOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkACOnly.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkACOnly.Enabled = true;
			chkACOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkACOnly.ForeColor = System.Drawing.SystemColors.ControlText;
			chkACOnly.Location = new System.Drawing.Point(296, 48);
			chkACOnly.Name = "chkACOnly";
			chkACOnly.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkACOnly.Size = new System.Drawing.Size(105, 13);
			chkACOnly.TabIndex = 289;
			chkACOnly.TabStop = true;
			chkACOnly.Text = "Use for Aircraft?";
			chkACOnly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkACOnly.Visible = true;
			// 
			// txt_cbus_keywords
			// 
			txt_cbus_keywords.AcceptsReturn = true;
			txt_cbus_keywords.AllowDrop = true;
			txt_cbus_keywords.BackColor = System.Drawing.SystemColors.Window;
			txt_cbus_keywords.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cbus_keywords.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cbus_keywords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cbus_keywords.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cbus_keywords.Location = new System.Drawing.Point(70, 141);
			txt_cbus_keywords.MaxLength = 200;
			txt_cbus_keywords.Name = "txt_cbus_keywords";
			txt_cbus_keywords.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cbus_keywords.Size = new System.Drawing.Size(437, 41);
			txt_cbus_keywords.TabIndex = 209;
			// 
			// txt_cbus_Desc
			// 
			txt_cbus_Desc.AcceptsReturn = true;
			txt_cbus_Desc.AllowDrop = true;
			txt_cbus_Desc.BackColor = System.Drawing.SystemColors.Window;
			txt_cbus_Desc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cbus_Desc.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cbus_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cbus_Desc.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cbus_Desc.Location = new System.Drawing.Point(70, 97);
			txt_cbus_Desc.MaxLength = 200;
			txt_cbus_Desc.Name = "txt_cbus_Desc";
			txt_cbus_Desc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cbus_Desc.Size = new System.Drawing.Size(437, 41);
			txt_cbus_Desc.TabIndex = 208;
			// 
			// txt_cbus_type
			// 
			txt_cbus_type.AcceptsReturn = true;
			txt_cbus_type.AllowDrop = true;
			txt_cbus_type.BackColor = System.Drawing.SystemColors.Window;
			txt_cbus_type.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cbus_type.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cbus_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cbus_type.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cbus_type.Location = new System.Drawing.Point(69, 45);
			txt_cbus_type.MaxLength = 2;
			txt_cbus_type.Name = "txt_cbus_type";
			txt_cbus_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cbus_type.Size = new System.Drawing.Size(27, 21);
			txt_cbus_type.TabIndex = 205;
			// 
			// txt_cbus_Name
			// 
			txt_cbus_Name.AcceptsReturn = true;
			txt_cbus_Name.AllowDrop = true;
			txt_cbus_Name.BackColor = System.Drawing.SystemColors.Window;
			txt_cbus_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cbus_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cbus_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cbus_Name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cbus_Name.Location = new System.Drawing.Point(69, 72);
			txt_cbus_Name.MaxLength = 30;
			txt_cbus_Name.Name = "txt_cbus_Name";
			txt_cbus_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cbus_Name.Size = new System.Drawing.Size(289, 21);
			txt_cbus_Name.TabIndex = 204;
			// 
			// chkBusIdxOnly
			// 
			chkBusIdxOnly.AllowDrop = true;
			chkBusIdxOnly.Appearance = System.Windows.Forms.Appearance.Normal;
			chkBusIdxOnly.BackColor = System.Drawing.SystemColors.Control;
			chkBusIdxOnly.CausesValidation = true;
			chkBusIdxOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkBusIdxOnly.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkBusIdxOnly.Enabled = true;
			chkBusIdxOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkBusIdxOnly.ForeColor = System.Drawing.SystemColors.ControlText;
			chkBusIdxOnly.Location = new System.Drawing.Point(176, 48);
			chkBusIdxOnly.Name = "chkBusIdxOnly";
			chkBusIdxOnly.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkBusIdxOnly.Size = new System.Drawing.Size(109, 13);
			chkBusIdxOnly.TabIndex = 203;
			chkBusIdxOnly.TabStop = true;
			chkBusIdxOnly.Text = "Use for ABI Only?";
			chkBusIdxOnly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkBusIdxOnly.Visible = true;
			// 
			// cmd_Delete_CBT
			// 
			cmd_Delete_CBT.AllowDrop = true;
			cmd_Delete_CBT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_CBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_CBT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_CBT.Location = new System.Drawing.Point(176, 9);
			cmd_Delete_CBT.Name = "cmd_Delete_CBT";
			cmd_Delete_CBT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_CBT.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_CBT.TabIndex = 35;
			cmd_Delete_CBT.Text = "&Delete";
			cmd_Delete_CBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_CBT.UseVisualStyleBackColor = false;
			cmd_Delete_CBT.Click += new System.EventHandler(cmd_Delete_CBT_Click);
			// 
			// cmd_Cancel_CBT
			// 
			cmd_Cancel_CBT.AllowDrop = true;
			cmd_Cancel_CBT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_CBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_CBT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_CBT.Location = new System.Drawing.Point(91, 9);
			cmd_Cancel_CBT.Name = "cmd_Cancel_CBT";
			cmd_Cancel_CBT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_CBT.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_CBT.TabIndex = 34;
			cmd_Cancel_CBT.Text = "&Cancel";
			cmd_Cancel_CBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_CBT.UseVisualStyleBackColor = false;
			cmd_Cancel_CBT.Click += new System.EventHandler(cmd_Cancel_CBT_Click);
			// 
			// cmd_Save_CBT
			// 
			cmd_Save_CBT.AllowDrop = true;
			cmd_Save_CBT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_CBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_CBT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_CBT.Location = new System.Drawing.Point(8, 9);
			cmd_Save_CBT.Name = "cmd_Save_CBT";
			cmd_Save_CBT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_CBT.Size = new System.Drawing.Size(57, 25);
			cmd_Save_CBT.TabIndex = 33;
			cmd_Save_CBT.Text = "&Save";
			cmd_Save_CBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_CBT.UseVisualStyleBackColor = false;
			cmd_Save_CBT.Click += new System.EventHandler(cmd_Save_CBT_Click);
			// 
			// _Label1_36
			// 
			_Label1_36.AllowDrop = true;
			_Label1_36.AutoSize = true;
			_Label1_36.BackColor = System.Drawing.SystemColors.Control;
			_Label1_36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_36.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_36.Location = new System.Drawing.Point(14, 146);
			_Label1_36.MinimumSize = new System.Drawing.Size(52, 13);
			_Label1_36.Name = "_Label1_36";
			_Label1_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_36.Size = new System.Drawing.Size(52, 13);
			_Label1_36.TabIndex = 207;
			_Label1_36.Text = "Keywords :";
			_Label1_36.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_Label1_36.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_35
			// 
			_Label1_35.AllowDrop = true;
			_Label1_35.AutoSize = true;
			_Label1_35.BackColor = System.Drawing.SystemColors.Control;
			_Label1_35.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_35.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_35.Location = new System.Drawing.Point(8, 100);
			_Label1_35.MinimumSize = new System.Drawing.Size(59, 13);
			_Label1_35.Name = "_Label1_35";
			_Label1_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_35.Size = new System.Drawing.Size(59, 13);
			_Label1_35.TabIndex = 206;
			_Label1_35.Text = "Description :";
			_Label1_35.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_Label1_35.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_34
			// 
			_Label1_34.AllowDrop = true;
			_Label1_34.AutoSize = true;
			_Label1_34.BackColor = System.Drawing.SystemColors.Control;
			_Label1_34.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_34.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_34.Location = new System.Drawing.Point(32, 76);
			_Label1_34.MinimumSize = new System.Drawing.Size(34, 13);
			_Label1_34.Name = "_Label1_34";
			_Label1_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_34.Size = new System.Drawing.Size(34, 13);
			_Label1_34.TabIndex = 37;
			_Label1_34.Text = "Name :";
			_Label1_34.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_Label1_34.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_33
			// 
			_Label1_33.AllowDrop = true;
			_Label1_33.AutoSize = true;
			_Label1_33.BackColor = System.Drawing.SystemColors.Control;
			_Label1_33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_33.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_33.Location = new System.Drawing.Point(35, 49);
			_Label1_33.MinimumSize = new System.Drawing.Size(31, 13);
			_Label1_33.Name = "_Label1_33";
			_Label1_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_33.Size = new System.Drawing.Size(31, 13);
			_Label1_33.TabIndex = 36;
			_Label1_33.Text = "Code :";
			_Label1_33.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_Label1_33.Click += new System.EventHandler(Label1_Click);
			// 
			// pnl_BusGroup
			// 
			pnl_BusGroup.AllowDrop = true;
			pnl_BusGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_BusGroup.Controls.Add(cmdRemoveBusGroup);
			pnl_BusGroup.Controls.Add(cmdAddBusGroup);
			pnl_BusGroup.Controls.Add(lstBusType);
			pnl_BusGroup.Controls.Add(lstAllBusType);
			pnl_BusGroup.Controls.Add(_Label1_37);
			pnl_BusGroup.Controls.Add(_Label1_38);
			pnl_BusGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_BusGroup.Location = new System.Drawing.Point(456, 272);
			pnl_BusGroup.Name = "pnl_BusGroup";
			pnl_BusGroup.Size = new System.Drawing.Size(490, 146);
			pnl_BusGroup.TabIndex = 196;
			pnl_BusGroup.Visible = false;
			// 
			// cmdRemoveBusGroup
			// 
			cmdRemoveBusGroup.AllowDrop = true;
			cmdRemoveBusGroup.BackColor = System.Drawing.SystemColors.Control;
			cmdRemoveBusGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRemoveBusGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRemoveBusGroup.Location = new System.Drawing.Point(221, 83);
			cmdRemoveBusGroup.Name = "cmdRemoveBusGroup";
			cmdRemoveBusGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRemoveBusGroup.Size = new System.Drawing.Size(42, 23);
			cmdRemoveBusGroup.TabIndex = 200;
			cmdRemoveBusGroup.Text = "<--";
			cmdRemoveBusGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRemoveBusGroup.UseVisualStyleBackColor = false;
			cmdRemoveBusGroup.Click += new System.EventHandler(cmdRemoveBusGroup_Click);
			// 
			// cmdAddBusGroup
			// 
			cmdAddBusGroup.AllowDrop = true;
			cmdAddBusGroup.BackColor = System.Drawing.SystemColors.Control;
			cmdAddBusGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAddBusGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAddBusGroup.Location = new System.Drawing.Point(221, 40);
			cmdAddBusGroup.Name = "cmdAddBusGroup";
			cmdAddBusGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAddBusGroup.Size = new System.Drawing.Size(42, 23);
			cmdAddBusGroup.TabIndex = 199;
			cmdAddBusGroup.Text = "-->";
			cmdAddBusGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAddBusGroup.UseVisualStyleBackColor = false;
			cmdAddBusGroup.Click += new System.EventHandler(cmdAddBusGroup_Click);
			// 
			// lstBusType
			// 
			lstBusType.AllowDrop = true;
			lstBusType.BackColor = System.Drawing.SystemColors.Window;
			lstBusType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lstBusType.CausesValidation = true;
			lstBusType.Enabled = true;
			lstBusType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstBusType.ForeColor = System.Drawing.SystemColors.WindowText;
			lstBusType.IntegralHeight = true;
			lstBusType.Location = new System.Drawing.Point(267, 20);
			lstBusType.MultiColumn = false;
			lstBusType.Name = "lstBusType";
			lstBusType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstBusType.Size = new System.Drawing.Size(208, 124);
			lstBusType.Sorted = false;
			lstBusType.TabIndex = 198;
			lstBusType.TabStop = true;
			lstBusType.Visible = true;
			lstBusType.SelectedIndexChanged += new System.EventHandler(lstBusType_SelectedIndexChanged);
			// 
			// lstAllBusType
			// 
			lstAllBusType.AllowDrop = true;
			lstAllBusType.BackColor = System.Drawing.SystemColors.Window;
			lstAllBusType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lstAllBusType.CausesValidation = true;
			lstAllBusType.Enabled = true;
			lstAllBusType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstAllBusType.ForeColor = System.Drawing.SystemColors.WindowText;
			lstAllBusType.IntegralHeight = true;
			lstAllBusType.Location = new System.Drawing.Point(6, 16);
			lstAllBusType.MultiColumn = false;
			lstAllBusType.Name = "lstAllBusType";
			lstAllBusType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstAllBusType.Size = new System.Drawing.Size(208, 124);
			lstAllBusType.Sorted = false;
			lstAllBusType.TabIndex = 197;
			lstAllBusType.TabStop = true;
			lstAllBusType.Visible = true;
			lstAllBusType.SelectedIndexChanged += new System.EventHandler(lstAllBusType_SelectedIndexChanged);
			// 
			// _Label1_37
			// 
			_Label1_37.AllowDrop = true;
			_Label1_37.AutoSize = true;
			_Label1_37.BackColor = System.Drawing.SystemColors.Control;
			_Label1_37.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_37.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_37.Location = new System.Drawing.Point(6, 4);
			_Label1_37.MinimumSize = new System.Drawing.Size(86, 13);
			_Label1_37.Name = "_Label1_37";
			_Label1_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_37.Size = new System.Drawing.Size(86, 13);
			_Label1_37.TabIndex = 202;
			_Label1_37.Text = "Master Group List:";
			_Label1_37.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_38
			// 
			_Label1_38.AllowDrop = true;
			_Label1_38.AutoSize = true;
			_Label1_38.BackColor = System.Drawing.SystemColors.Control;
			_Label1_38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_38.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_38.Location = new System.Drawing.Point(267, 4);
			_Label1_38.MinimumSize = new System.Drawing.Size(156, 13);
			_Label1_38.Name = "_Label1_38";
			_Label1_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_38.Size = new System.Drawing.Size(156, 13);
			_Label1_38.TabIndex = 201;
			_Label1_38.Text = "This Business is a memberber Of:";
			_Label1_38.Click += new System.EventHandler(Label1_Click);
			// 
			// _tab_Lookup_TabPage3
			// 
			_tab_Lookup_TabPage3.Controls.Add(pnl_Country_AddUpdate);
			_tab_Lookup_TabPage3.Controls.Add(FG_Country);
			_tab_Lookup_TabPage3.Controls.Add(cmd_Add_Country);
			_tab_Lookup_TabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage3.Text = "Country";
			// 
			// pnl_Country_AddUpdate
			// 
			pnl_Country_AddUpdate.AllowDrop = true;
			pnl_Country_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Country_AddUpdate.Controls.Add(cmbDialLineAccessCode);
			pnl_Country_AddUpdate.Controls.Add(txt_county_grid_row);
			pnl_Country_AddUpdate.Controls.Add(txt_country_name_old);
			pnl_Country_AddUpdate.Controls.Add(cmdRegNoUpdate);
			pnl_Country_AddUpdate.Controls.Add(cmdRegNoChange);
			pnl_Country_AddUpdate.Controls.Add(cmdRegNoDelete);
			pnl_Country_AddUpdate.Controls.Add(cmdAddRegno);
			pnl_Country_AddUpdate.Controls.Add(RegNoList);
			pnl_Country_AddUpdate.Controls.Add(Chk_Company_active);
			pnl_Country_AddUpdate.Controls.Add(txt_country_name);
			pnl_Country_AddUpdate.Controls.Add(txt_country_code);
			pnl_Country_AddUpdate.Controls.Add(cmd_Delete_Country);
			pnl_Country_AddUpdate.Controls.Add(cmd_Cancel_Country);
			pnl_Country_AddUpdate.Controls.Add(cmd_Save_Country);
			pnl_Country_AddUpdate.Controls.Add(txt_country_language);
			pnl_Country_AddUpdate.Controls.Add(txt_country_time_vs_eastern);
			pnl_Country_AddUpdate.Controls.Add(txt_country_currency);
			pnl_Country_AddUpdate.Controls.Add(txt_country_int_access_code);
			pnl_Country_AddUpdate.Controls.Add(txt_Abbrev);
			pnl_Country_AddUpdate.Controls.Add(txt_regnbr_prefix);
			pnl_Country_AddUpdate.Controls.Add(txt_CityCode);
			pnl_Country_AddUpdate.Controls.Add(txt_Continent_Name);
			pnl_Country_AddUpdate.Controls.Add(_lblDialLineAccessCode_46);
			pnl_Country_AddUpdate.Controls.Add(_Shape1_0);
			pnl_Country_AddUpdate.Controls.Add(_Line2_1);
			pnl_Country_AddUpdate.Controls.Add(_Label7_1);
			pnl_Country_AddUpdate.Controls.Add(_Label1_24);
			pnl_Country_AddUpdate.Controls.Add(_Label1_25);
			pnl_Country_AddUpdate.Controls.Add(_Label1_27);
			pnl_Country_AddUpdate.Controls.Add(_Label1_28);
			pnl_Country_AddUpdate.Controls.Add(_Label1_29);
			pnl_Country_AddUpdate.Controls.Add(_Label1_30);
			pnl_Country_AddUpdate.Controls.Add(_Label1_26);
			pnl_Country_AddUpdate.Controls.Add(_Label7_0);
			pnl_Country_AddUpdate.Controls.Add(_Label1_32);
			pnl_Country_AddUpdate.Controls.Add(_Label1_31);
			pnl_Country_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Country_AddUpdate.Location = new System.Drawing.Point(522, 51);
			pnl_Country_AddUpdate.Name = "pnl_Country_AddUpdate";
			pnl_Country_AddUpdate.Size = new System.Drawing.Size(345, 407);
			pnl_Country_AddUpdate.TabIndex = 38;
			pnl_Country_AddUpdate.Visible = false;
			// 
			// cmbDialLineAccessCode
			// 
			cmbDialLineAccessCode.AllowDrop = true;
			cmbDialLineAccessCode.BackColor = System.Drawing.SystemColors.Window;
			cmbDialLineAccessCode.CausesValidation = true;
			cmbDialLineAccessCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbDialLineAccessCode.Enabled = true;
			cmbDialLineAccessCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbDialLineAccessCode.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbDialLineAccessCode.IntegralHeight = true;
			cmbDialLineAccessCode.Location = new System.Drawing.Point(152, 217);
			cmbDialLineAccessCode.Name = "cmbDialLineAccessCode";
			cmbDialLineAccessCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbDialLineAccessCode.Size = new System.Drawing.Size(182, 21);
			cmbDialLineAccessCode.Sorted = false;
			cmbDialLineAccessCode.TabIndex = 44;
			cmbDialLineAccessCode.TabStop = true;
			cmbDialLineAccessCode.Visible = true;
			cmbDialLineAccessCode.Items.AddRange(new object[]{"7 - Long Distance No Caller Id", "5 - Long Distance With Caller Id"});
			// 
			// txt_county_grid_row
			// 
			txt_county_grid_row.AcceptsReturn = true;
			txt_county_grid_row.AllowDrop = true;
			txt_county_grid_row.BackColor = System.Drawing.SystemColors.Window;
			txt_county_grid_row.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_county_grid_row.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_county_grid_row.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_county_grid_row.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_county_grid_row.Location = new System.Drawing.Point(217, 151);
			txt_county_grid_row.MaxLength = 0;
			txt_county_grid_row.Name = "txt_county_grid_row";
			txt_county_grid_row.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_county_grid_row.Size = new System.Drawing.Size(23, 20);
			txt_county_grid_row.TabIndex = 195;
			txt_county_grid_row.Visible = false;
			// 
			// txt_country_name_old
			// 
			txt_country_name_old.AcceptsReturn = true;
			txt_country_name_old.AllowDrop = true;
			txt_country_name_old.BackColor = System.Drawing.SystemColors.Window;
			txt_country_name_old.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_country_name_old.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_country_name_old.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_country_name_old.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_country_name_old.Location = new System.Drawing.Point(170, 150);
			txt_country_name_old.MaxLength = 0;
			txt_country_name_old.Name = "txt_country_name_old";
			txt_country_name_old.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_country_name_old.Size = new System.Drawing.Size(21, 19);
			txt_country_name_old.TabIndex = 194;
			txt_country_name_old.Visible = false;
			// 
			// cmdRegNoUpdate
			// 
			cmdRegNoUpdate.AllowDrop = true;
			cmdRegNoUpdate.BackColor = System.Drawing.SystemColors.Control;
			cmdRegNoUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRegNoUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRegNoUpdate.Location = new System.Drawing.Point(235, 288);
			cmdRegNoUpdate.Name = "cmdRegNoUpdate";
			cmdRegNoUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRegNoUpdate.Size = new System.Drawing.Size(50, 15);
			cmdRegNoUpdate.TabIndex = 193;
			cmdRegNoUpdate.Text = "Update";
			cmdRegNoUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRegNoUpdate.UseVisualStyleBackColor = false;
			cmdRegNoUpdate.Visible = false;
			cmdRegNoUpdate.Click += new System.EventHandler(cmdRegNoUpdate_Click);
			// 
			// cmdRegNoChange
			// 
			cmdRegNoChange.AllowDrop = true;
			cmdRegNoChange.BackColor = System.Drawing.SystemColors.Control;
			cmdRegNoChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRegNoChange.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRegNoChange.Location = new System.Drawing.Point(128, 268);
			cmdRegNoChange.Name = "cmdRegNoChange";
			cmdRegNoChange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRegNoChange.Size = new System.Drawing.Size(56, 17);
			cmdRegNoChange.TabIndex = 191;
			cmdRegNoChange.Text = "Change";
			cmdRegNoChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRegNoChange.UseVisualStyleBackColor = false;
			cmdRegNoChange.Click += new System.EventHandler(cmdRegNoChange_Click);
			// 
			// cmdRegNoDelete
			// 
			cmdRegNoDelete.AllowDrop = true;
			cmdRegNoDelete.BackColor = System.Drawing.SystemColors.Control;
			cmdRegNoDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRegNoDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRegNoDelete.Location = new System.Drawing.Point(129, 289);
			cmdRegNoDelete.Name = "cmdRegNoDelete";
			cmdRegNoDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRegNoDelete.Size = new System.Drawing.Size(47, 16);
			cmdRegNoDelete.TabIndex = 190;
			cmdRegNoDelete.Text = "Delete";
			cmdRegNoDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRegNoDelete.UseVisualStyleBackColor = false;
			cmdRegNoDelete.Click += new System.EventHandler(cmdRegNoDelete_Click);
			// 
			// cmdAddRegno
			// 
			cmdAddRegno.AllowDrop = true;
			cmdAddRegno.BackColor = System.Drawing.SystemColors.Control;
			cmdAddRegno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAddRegno.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAddRegno.Location = new System.Drawing.Point(125, 248);
			cmdAddRegno.Name = "cmdAddRegno";
			cmdAddRegno.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAddRegno.Size = new System.Drawing.Size(39, 17);
			cmdAddRegno.TabIndex = 189;
			cmdAddRegno.Text = "Add";
			cmdAddRegno.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAddRegno.UseVisualStyleBackColor = false;
			cmdAddRegno.Click += new System.EventHandler(cmdAddRegno_Click);
			// 
			// RegNoList
			// 
			RegNoList.AllowDrop = true;
			RegNoList.BackColor = System.Drawing.SystemColors.Window;
			RegNoList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			RegNoList.CausesValidation = true;
			RegNoList.Enabled = true;
			RegNoList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			RegNoList.ForeColor = System.Drawing.SystemColors.WindowText;
			RegNoList.IntegralHeight = true;
			RegNoList.Location = new System.Drawing.Point(18, 259);
			RegNoList.MultiColumn = false;
			RegNoList.Name = "RegNoList";
			RegNoList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			RegNoList.Size = new System.Drawing.Size(93, 46);
			RegNoList.Sorted = false;
			RegNoList.TabIndex = 188;
			RegNoList.TabStop = true;
			RegNoList.Visible = true;
			// 
			// Chk_Company_active
			// 
			Chk_Company_active.AllowDrop = true;
			Chk_Company_active.Appearance = System.Windows.Forms.Appearance.Normal;
			Chk_Company_active.BackColor = System.Drawing.SystemColors.Control;
			Chk_Company_active.CausesValidation = true;
			Chk_Company_active.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_Company_active.CheckState = System.Windows.Forms.CheckState.Unchecked;
			Chk_Company_active.Enabled = true;
			Chk_Company_active.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Chk_Company_active.ForeColor = System.Drawing.SystemColors.ControlText;
			Chk_Company_active.Location = new System.Drawing.Point(91, 86);
			Chk_Company_active.Name = "Chk_Company_active";
			Chk_Company_active.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Chk_Company_active.Size = new System.Drawing.Size(63, 18);
			Chk_Company_active.TabIndex = 187;
			Chk_Company_active.TabStop = true;
			Chk_Company_active.Text = "Active";
			Chk_Company_active.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_Company_active.Visible = true;
			// 
			// txt_country_name
			// 
			txt_country_name.AcceptsReturn = true;
			txt_country_name.AllowDrop = true;
			txt_country_name.BackColor = System.Drawing.SystemColors.Window;
			txt_country_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_country_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_country_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_country_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_country_name.Location = new System.Drawing.Point(16, 47);
			txt_country_name.MaxLength = 25;
			txt_country_name.Name = "txt_country_name";
			txt_country_name.ReadOnly = true;
			txt_country_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_country_name.Size = new System.Drawing.Size(315, 19);
			txt_country_name.TabIndex = 52;
			// 
			// txt_country_code
			// 
			txt_country_code.AcceptsReturn = true;
			txt_country_code.AllowDrop = true;
			txt_country_code.BackColor = System.Drawing.SystemColors.Window;
			txt_country_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_country_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_country_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_country_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_country_code.Location = new System.Drawing.Point(14, 83);
			txt_country_code.MaxLength = 5;
			txt_country_code.Name = "txt_country_code";
			txt_country_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_country_code.Size = new System.Drawing.Size(69, 19);
			txt_country_code.TabIndex = 51;
			// 
			// cmd_Delete_Country
			// 
			cmd_Delete_Country.AllowDrop = true;
			cmd_Delete_Country.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Country.Enabled = false;
			cmd_Delete_Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Country.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Country.Location = new System.Drawing.Point(238, 5);
			cmd_Delete_Country.Name = "cmd_Delete_Country";
			cmd_Delete_Country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Country.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Country.TabIndex = 50;
			cmd_Delete_Country.Text = "&Delete";
			cmd_Delete_Country.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Country.Click += new System.EventHandler(cmd_Delete_Country_Click);
			// 
			// cmd_Cancel_Country
			// 
			cmd_Cancel_Country.AllowDrop = true;
			cmd_Cancel_Country.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Country.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Country.Location = new System.Drawing.Point(156, 5);
			cmd_Cancel_Country.Name = "cmd_Cancel_Country";
			cmd_Cancel_Country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Country.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_Country.TabIndex = 49;
			cmd_Cancel_Country.Text = "&Cancel";
			cmd_Cancel_Country.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Country.UseVisualStyleBackColor = false;
			cmd_Cancel_Country.Click += new System.EventHandler(cmd_Cancel_Country_Click);
			// 
			// cmd_Save_Country
			// 
			cmd_Save_Country.AllowDrop = true;
			cmd_Save_Country.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Country.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Country.Location = new System.Drawing.Point(74, 5);
			cmd_Save_Country.Name = "cmd_Save_Country";
			cmd_Save_Country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Country.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Country.TabIndex = 48;
			cmd_Save_Country.Text = "&Save";
			cmd_Save_Country.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Country.UseVisualStyleBackColor = false;
			cmd_Save_Country.Click += new System.EventHandler(cmd_Save_Country_Click);
			// 
			// txt_country_language
			// 
			txt_country_language.AcceptsReturn = true;
			txt_country_language.AllowDrop = true;
			txt_country_language.BackColor = System.Drawing.SystemColors.Window;
			txt_country_language.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_country_language.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_country_language.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_country_language.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_country_language.Location = new System.Drawing.Point(13, 116);
			txt_country_language.MaxLength = 15;
			txt_country_language.Name = "txt_country_language";
			txt_country_language.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_country_language.Size = new System.Drawing.Size(315, 19);
			txt_country_language.TabIndex = 47;
			// 
			// txt_country_time_vs_eastern
			// 
			txt_country_time_vs_eastern.AcceptsReturn = true;
			txt_country_time_vs_eastern.AllowDrop = true;
			txt_country_time_vs_eastern.BackColor = System.Drawing.SystemColors.Window;
			txt_country_time_vs_eastern.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_country_time_vs_eastern.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_country_time_vs_eastern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_country_time_vs_eastern.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_country_time_vs_eastern.Location = new System.Drawing.Point(14, 150);
			txt_country_time_vs_eastern.MaxLength = 8;
			txt_country_time_vs_eastern.Name = "txt_country_time_vs_eastern";
			txt_country_time_vs_eastern.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_country_time_vs_eastern.Size = new System.Drawing.Size(99, 19);
			txt_country_time_vs_eastern.TabIndex = 46;
			// 
			// txt_country_currency
			// 
			txt_country_currency.AcceptsReturn = true;
			txt_country_currency.AllowDrop = true;
			txt_country_currency.BackColor = System.Drawing.SystemColors.Window;
			txt_country_currency.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_country_currency.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_country_currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_country_currency.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_country_currency.Location = new System.Drawing.Point(14, 182);
			txt_country_currency.MaxLength = 15;
			txt_country_currency.Name = "txt_country_currency";
			txt_country_currency.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_country_currency.Size = new System.Drawing.Size(311, 19);
			txt_country_currency.TabIndex = 45;
			// 
			// txt_country_int_access_code
			// 
			txt_country_int_access_code.AcceptsReturn = true;
			txt_country_int_access_code.AllowDrop = true;
			txt_country_int_access_code.BackColor = System.Drawing.SystemColors.Window;
			txt_country_int_access_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_country_int_access_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_country_int_access_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_country_int_access_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_country_int_access_code.Location = new System.Drawing.Point(13, 219);
			txt_country_int_access_code.MaxLength = 3;
			txt_country_int_access_code.Name = "txt_country_int_access_code";
			txt_country_int_access_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_country_int_access_code.Size = new System.Drawing.Size(123, 19);
			txt_country_int_access_code.TabIndex = 43;
			// 
			// txt_Abbrev
			// 
			txt_Abbrev.AcceptsReturn = true;
			txt_Abbrev.AllowDrop = true;
			txt_Abbrev.BackColor = System.Drawing.SystemColors.Window;
			txt_Abbrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Abbrev.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Abbrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Abbrev.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Abbrev.Location = new System.Drawing.Point(264, 87);
			txt_Abbrev.MaxLength = 4;
			txt_Abbrev.Name = "txt_Abbrev";
			txt_Abbrev.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Abbrev.Size = new System.Drawing.Size(63, 19);
			txt_Abbrev.TabIndex = 42;
			// 
			// txt_regnbr_prefix
			// 
			txt_regnbr_prefix.AcceptsReturn = true;
			txt_regnbr_prefix.AllowDrop = true;
			txt_regnbr_prefix.BackColor = System.Drawing.SystemColors.Window;
			txt_regnbr_prefix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_regnbr_prefix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_regnbr_prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_regnbr_prefix.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_regnbr_prefix.Location = new System.Drawing.Point(237, 266);
			txt_regnbr_prefix.MaxLength = 0;
			txt_regnbr_prefix.Name = "txt_regnbr_prefix";
			txt_regnbr_prefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_regnbr_prefix.Size = new System.Drawing.Size(47, 19);
			txt_regnbr_prefix.TabIndex = 41;
			txt_regnbr_prefix.Visible = false;
			// 
			// txt_CityCode
			// 
			txt_CityCode.AcceptsReturn = true;
			txt_CityCode.AllowDrop = true;
			txt_CityCode.BackColor = System.Drawing.SystemColors.Window;
			txt_CityCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_CityCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_CityCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_CityCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_CityCode.Location = new System.Drawing.Point(14, 366);
			txt_CityCode.MaxLength = 0;
			txt_CityCode.Name = "txt_CityCode";
			txt_CityCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_CityCode.Size = new System.Drawing.Size(320, 20);
			txt_CityCode.TabIndex = 40;
			// 
			// txt_Continent_Name
			// 
			txt_Continent_Name.AcceptsReturn = true;
			txt_Continent_Name.AllowDrop = true;
			txt_Continent_Name.BackColor = System.Drawing.SystemColors.Window;
			txt_Continent_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Continent_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Continent_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Continent_Name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Continent_Name.Location = new System.Drawing.Point(14, 326);
			txt_Continent_Name.MaxLength = 0;
			txt_Continent_Name.Name = "txt_Continent_Name";
			txt_Continent_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Continent_Name.Size = new System.Drawing.Size(290, 19);
			txt_Continent_Name.TabIndex = 39;
			// 
			// _lblDialLineAccessCode_46
			// 
			_lblDialLineAccessCode_46.AllowDrop = true;
			_lblDialLineAccessCode_46.BackColor = System.Drawing.SystemColors.Control;
			_lblDialLineAccessCode_46.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblDialLineAccessCode_46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblDialLineAccessCode_46.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblDialLineAccessCode_46.Location = new System.Drawing.Point(152, 203);
			_lblDialLineAccessCode_46.MinimumSize = new System.Drawing.Size(130, 17);
			_lblDialLineAccessCode_46.Name = "_lblDialLineAccessCode_46";
			_lblDialLineAccessCode_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblDialLineAccessCode_46.Size = new System.Drawing.Size(130, 17);
			_lblDialLineAccessCode_46.TabIndex = 307;
			_lblDialLineAccessCode_46.Text = "Dialing Line Access Code";
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
			_Shape1_0.Location = new System.Drawing.Point(12, 241);
			_Shape1_0.Name = "_Shape1_0";
			_Shape1_0.Size = new System.Drawing.Size(307, 70);
			_Shape1_0.Visible = true;
			// 
			// _Line2_1
			// 
			_Line2_1.AllowDrop = true;
			_Line2_1.BackColor = System.Drawing.SystemColors.WindowText;
			_Line2_1.Enabled = false;
			_Line2_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Line2_1.Location = new System.Drawing.Point(-5, 0);
			_Line2_1.Name = "_Line2_1";
			_Line2_1.Size = new System.Drawing.Size(1, 66);
			_Line2_1.Visible = true;
			// 
			// _Label7_1
			// 
			_Label7_1.AllowDrop = true;
			_Label7_1.BackColor = System.Drawing.SystemColors.Control;
			_Label7_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label7_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label7_1.ForeColor = System.Drawing.Color.Blue;
			_Label7_1.Location = new System.Drawing.Point(205, 268);
			_Label7_1.MinimumSize = new System.Drawing.Size(35, 17);
			_Label7_1.Name = "_Label7_1";
			_Label7_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label7_1.Size = new System.Drawing.Size(35, 17);
			_Label7_1.TabIndex = 192;
			_Label7_1.Text = "Prefix";
			_Label7_1.Visible = false;
			// 
			// _Label1_24
			// 
			_Label1_24.AllowDrop = true;
			_Label1_24.BackColor = System.Drawing.SystemColors.Control;
			_Label1_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_24.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_24.Location = new System.Drawing.Point(14, 29);
			_Label1_24.MinimumSize = new System.Drawing.Size(33, 17);
			_Label1_24.Name = "_Label1_24";
			_Label1_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_24.Size = new System.Drawing.Size(33, 17);
			_Label1_24.TabIndex = 62;
			_Label1_24.Text = "Name";
			_Label1_24.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_25
			// 
			_Label1_25.AllowDrop = true;
			_Label1_25.BackColor = System.Drawing.SystemColors.Control;
			_Label1_25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_25.ForeColor = System.Drawing.Color.Black;
			_Label1_25.Location = new System.Drawing.Point(15, 69);
			_Label1_25.MinimumSize = new System.Drawing.Size(41, 17);
			_Label1_25.Name = "_Label1_25";
			_Label1_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_25.Size = new System.Drawing.Size(41, 17);
			_Label1_25.TabIndex = 61;
			_Label1_25.Text = "Code";
			_Label1_25.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_27
			// 
			_Label1_27.AllowDrop = true;
			_Label1_27.BackColor = System.Drawing.SystemColors.Control;
			_Label1_27.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_27.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_27.Location = new System.Drawing.Point(14, 102);
			_Label1_27.MinimumSize = new System.Drawing.Size(71, 17);
			_Label1_27.Name = "_Label1_27";
			_Label1_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_27.Size = new System.Drawing.Size(71, 17);
			_Label1_27.TabIndex = 60;
			_Label1_27.Text = "Language";
			_Label1_27.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_28
			// 
			_Label1_28.AllowDrop = true;
			_Label1_28.BackColor = System.Drawing.SystemColors.Control;
			_Label1_28.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_28.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_28.Location = new System.Drawing.Point(14, 137);
			_Label1_28.MinimumSize = new System.Drawing.Size(123, 17);
			_Label1_28.Name = "_Label1_28";
			_Label1_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_28.Size = new System.Drawing.Size(123, 17);
			_Label1_28.TabIndex = 59;
			_Label1_28.Text = "Time vs Eastern";
			_Label1_28.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_29
			// 
			_Label1_29.AllowDrop = true;
			_Label1_29.BackColor = System.Drawing.SystemColors.Control;
			_Label1_29.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_29.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_29.Location = new System.Drawing.Point(16, 169);
			_Label1_29.MinimumSize = new System.Drawing.Size(121, 17);
			_Label1_29.Name = "_Label1_29";
			_Label1_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_29.Size = new System.Drawing.Size(121, 17);
			_Label1_29.TabIndex = 58;
			_Label1_29.Text = "Currency";
			_Label1_29.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_30
			// 
			_Label1_30.AllowDrop = true;
			_Label1_30.BackColor = System.Drawing.SystemColors.Control;
			_Label1_30.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_30.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_30.Location = new System.Drawing.Point(12, 203);
			_Label1_30.MinimumSize = new System.Drawing.Size(128, 17);
			_Label1_30.Name = "_Label1_30";
			_Label1_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_30.Size = new System.Drawing.Size(128, 17);
			_Label1_30.TabIndex = 57;
			_Label1_30.Text = "International Access Code";
			_Label1_30.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_26
			// 
			_Label1_26.AllowDrop = true;
			_Label1_26.BackColor = System.Drawing.SystemColors.Control;
			_Label1_26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_26.ForeColor = System.Drawing.Color.Blue;
			_Label1_26.Location = new System.Drawing.Point(154, 87);
			_Label1_26.MinimumSize = new System.Drawing.Size(102, 17);
			_Label1_26.Name = "_Label1_26";
			_Label1_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_26.Size = new System.Drawing.Size(102, 17);
			_Label1_26.TabIndex = 56;
			_Label1_26.Text = "Country Abbreviation";
			_Label1_26.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label7_0
			// 
			_Label7_0.AllowDrop = true;
			_Label7_0.BackColor = System.Drawing.SystemColors.Control;
			_Label7_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label7_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label7_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label7_0.Location = new System.Drawing.Point(16, 244);
			_Label7_0.MinimumSize = new System.Drawing.Size(116, 17);
			_Label7_0.Name = "_Label7_0";
			_Label7_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label7_0.Size = new System.Drawing.Size(116, 17);
			_Label7_0.TabIndex = 55;
			_Label7_0.Text = "Region Number Prefix";
			// 
			// _Label1_32
			// 
			_Label1_32.AllowDrop = true;
			_Label1_32.BackColor = System.Drawing.SystemColors.Control;
			_Label1_32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_32.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_32.Location = new System.Drawing.Point(14, 346);
			_Label1_32.MinimumSize = new System.Drawing.Size(90, 19);
			_Label1_32.Name = "_Label1_32";
			_Label1_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_32.Size = new System.Drawing.Size(90, 19);
			_Label1_32.TabIndex = 54;
			_Label1_32.Text = "City Code";
			_Label1_32.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_31
			// 
			_Label1_31.AllowDrop = true;
			_Label1_31.BackColor = System.Drawing.SystemColors.Control;
			_Label1_31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_31.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_31.Location = new System.Drawing.Point(14, 312);
			_Label1_31.MinimumSize = new System.Drawing.Size(112, 16);
			_Label1_31.Name = "_Label1_31";
			_Label1_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_31.Size = new System.Drawing.Size(112, 16);
			_Label1_31.TabIndex = 53;
			_Label1_31.Text = "Continent Name";
			_Label1_31.Click += new System.EventHandler(Label1_Click);
			// 
			// FG_Country
			// 
			FG_Country.AllowDrop = true;
			FG_Country.AllowUserToAddRows = false;
			FG_Country.AllowUserToDeleteRows = false;
			FG_Country.AllowUserToResizeColumns = false;
			FG_Country.AllowUserToResizeRows = false;
			FG_Country.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Country.ColumnsCount = 10;
			FG_Country.FixedColumns = 0;
			FG_Country.FixedRows = 1;
			FG_Country.Location = new System.Drawing.Point(16, 36);
			FG_Country.Name = "FG_Country";
			FG_Country.ReadOnly = true;
			FG_Country.RowsCount = 2;
			FG_Country.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Country.ShowCellToolTips = false;
			FG_Country.Size = new System.Drawing.Size(477, 423);
			FG_Country.StandardTab = true;
			FG_Country.TabIndex = 4;
			FG_Country.Click += new System.EventHandler(FG_Country_Click);
			// 
			// cmd_Add_Country
			// 
			cmd_Add_Country.AllowDrop = true;
			cmd_Add_Country.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Country.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Country.Location = new System.Drawing.Point(524, 18);
			cmd_Add_Country.Name = "cmd_Add_Country";
			cmd_Add_Country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Country.Size = new System.Drawing.Size(57, 25);
			cmd_Add_Country.TabIndex = 8;
			cmd_Add_Country.Text = "&Add";
			cmd_Add_Country.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Country.UseVisualStyleBackColor = false;
			cmd_Add_Country.Click += new System.EventHandler(cmd_Add_Country_Click);
			// 
			// _tab_Lookup_TabPage4
			// 
			_tab_Lookup_TabPage4.Controls.Add(pnl_Language_AddUpdate);
			_tab_Lookup_TabPage4.Controls.Add(FG_Language);
			_tab_Lookup_TabPage4.Controls.Add(cmd_Add_Language);
			_tab_Lookup_TabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage4.Text = "Language";
			// 
			// pnl_Language_AddUpdate
			// 
			pnl_Language_AddUpdate.AllowDrop = true;
			pnl_Language_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Language_AddUpdate.Controls.Add(txt_language_name);
			pnl_Language_AddUpdate.Controls.Add(cmd_Delete_Language);
			pnl_Language_AddUpdate.Controls.Add(cmd_Cancel_Language);
			pnl_Language_AddUpdate.Controls.Add(cmd_Save_Language);
			pnl_Language_AddUpdate.Controls.Add(_Label1_22);
			pnl_Language_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Language_AddUpdate.Location = new System.Drawing.Point(243, 42);
			pnl_Language_AddUpdate.Name = "pnl_Language_AddUpdate";
			pnl_Language_AddUpdate.Size = new System.Drawing.Size(269, 149);
			pnl_Language_AddUpdate.TabIndex = 63;
			pnl_Language_AddUpdate.Visible = false;
			// 
			// txt_language_name
			// 
			txt_language_name.AcceptsReturn = true;
			txt_language_name.AllowDrop = true;
			txt_language_name.BackColor = System.Drawing.SystemColors.Window;
			txt_language_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_language_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_language_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_language_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_language_name.Location = new System.Drawing.Point(17, 81);
			txt_language_name.MaxLength = 15;
			txt_language_name.Name = "txt_language_name";
			txt_language_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_language_name.Size = new System.Drawing.Size(149, 19);
			txt_language_name.TabIndex = 67;
			// 
			// cmd_Delete_Language
			// 
			cmd_Delete_Language.AllowDrop = true;
			cmd_Delete_Language.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Language.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Language.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Language.Location = new System.Drawing.Point(179, 12);
			cmd_Delete_Language.Name = "cmd_Delete_Language";
			cmd_Delete_Language.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Language.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Language.TabIndex = 66;
			cmd_Delete_Language.Text = "&Delete";
			cmd_Delete_Language.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Language.UseVisualStyleBackColor = false;
			cmd_Delete_Language.Click += new System.EventHandler(cmd_Delete_Language_Click);
			// 
			// cmd_Cancel_Language
			// 
			cmd_Cancel_Language.AllowDrop = true;
			cmd_Cancel_Language.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Language.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Language.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Language.Location = new System.Drawing.Point(93, 13);
			cmd_Cancel_Language.Name = "cmd_Cancel_Language";
			cmd_Cancel_Language.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Language.Size = new System.Drawing.Size(60, 25);
			cmd_Cancel_Language.TabIndex = 65;
			cmd_Cancel_Language.Text = "&Cancel";
			cmd_Cancel_Language.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Language.UseVisualStyleBackColor = false;
			cmd_Cancel_Language.Click += new System.EventHandler(cmd_Cancel_Language_Click);
			// 
			// cmd_Save_Language
			// 
			cmd_Save_Language.AllowDrop = true;
			cmd_Save_Language.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Language.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Language.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Language.Location = new System.Drawing.Point(13, 13);
			cmd_Save_Language.Name = "cmd_Save_Language";
			cmd_Save_Language.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Language.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Language.TabIndex = 64;
			cmd_Save_Language.Text = "&Save";
			cmd_Save_Language.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Language.UseVisualStyleBackColor = false;
			cmd_Save_Language.Click += new System.EventHandler(cmd_Save_Language_Click);
			// 
			// _Label1_22
			// 
			_Label1_22.AllowDrop = true;
			_Label1_22.BackColor = System.Drawing.SystemColors.Control;
			_Label1_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_22.Location = new System.Drawing.Point(19, 56);
			_Label1_22.MinimumSize = new System.Drawing.Size(86, 17);
			_Label1_22.Name = "_Label1_22";
			_Label1_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_22.Size = new System.Drawing.Size(86, 17);
			_Label1_22.TabIndex = 68;
			_Label1_22.Text = "Language Name:";
			_Label1_22.Click += new System.EventHandler(Label1_Click);
			// 
			// FG_Language
			// 
			FG_Language.AllowDrop = true;
			FG_Language.AllowUserToAddRows = false;
			FG_Language.AllowUserToDeleteRows = false;
			FG_Language.AllowUserToResizeColumns = false;
			FG_Language.AllowUserToResizeRows = false;
			FG_Language.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Language.ColumnsCount = 1;
			FG_Language.FixedColumns = 0;
			FG_Language.FixedRows = 1;
			FG_Language.Location = new System.Drawing.Point(27, 23);
			FG_Language.Name = "FG_Language";
			FG_Language.ReadOnly = true;
			FG_Language.RowsCount = 2;
			FG_Language.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			FG_Language.ShowCellToolTips = false;
			FG_Language.Size = new System.Drawing.Size(195, 391);
			FG_Language.StandardTab = true;
			FG_Language.TabIndex = 3;
			FG_Language.Click += new System.EventHandler(FG_Language_Click);
			// 
			// cmd_Add_Language
			// 
			cmd_Add_Language.AllowDrop = true;
			cmd_Add_Language.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Language.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Language.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Language.Location = new System.Drawing.Point(245, 13);
			cmd_Add_Language.Name = "cmd_Add_Language";
			cmd_Add_Language.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Language.Size = new System.Drawing.Size(57, 25);
			cmd_Add_Language.TabIndex = 9;
			cmd_Add_Language.Text = "&Add";
			cmd_Add_Language.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Language.UseVisualStyleBackColor = false;
			cmd_Add_Language.Click += new System.EventHandler(cmd_Add_Language_Click);
			// 
			// _tab_Lookup_TabPage5
			// 
			_tab_Lookup_TabPage5.Controls.Add(pnl_Currency_Change);
			_tab_Lookup_TabPage5.Controls.Add(FG_Currency);
			_tab_Lookup_TabPage5.Controls.Add(cmd_Add_Currency);
			_tab_Lookup_TabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage5.Text = "Currency";
			// 
			// pnl_Currency_Change
			// 
			pnl_Currency_Change.AllowDrop = true;
			pnl_Currency_Change.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Currency_Change.Controls.Add(_txt_currency_name_5);
			pnl_Currency_Change.Controls.Add(_txt_currency_name_4);
			pnl_Currency_Change.Controls.Add(_txt_currency_name_3);
			pnl_Currency_Change.Controls.Add(_txt_currency_name_2);
			pnl_Currency_Change.Controls.Add(_txt_currency_name_1);
			pnl_Currency_Change.Controls.Add(_txt_currency_name_0);
			pnl_Currency_Change.Controls.Add(cmd_Save_Currency);
			pnl_Currency_Change.Controls.Add(cmd_Cancel_Currency);
			pnl_Currency_Change.Controls.Add(cmd_Delete_Currency);
			pnl_Currency_Change.Controls.Add(_Label1_45);
			pnl_Currency_Change.Controls.Add(_Label1_44);
			pnl_Currency_Change.Controls.Add(_Label1_43);
			pnl_Currency_Change.Controls.Add(_Label1_42);
			pnl_Currency_Change.Controls.Add(_Label1_41);
			pnl_Currency_Change.Controls.Add(_Label1_23);
			pnl_Currency_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Currency_Change.Location = new System.Drawing.Point(721, 64);
			pnl_Currency_Change.Name = "pnl_Currency_Change";
			pnl_Currency_Change.Size = new System.Drawing.Size(235, 414);
			pnl_Currency_Change.TabIndex = 111;
			pnl_Currency_Change.Visible = false;
			// 
			// _txt_currency_name_5
			// 
			_txt_currency_name_5.AcceptsReturn = true;
			_txt_currency_name_5.AllowDrop = true;
			_txt_currency_name_5.BackColor = System.Drawing.SystemColors.Window;
			_txt_currency_name_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_currency_name_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_currency_name_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_currency_name_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_currency_name_5.Location = new System.Drawing.Point(11, 250);
			_txt_currency_name_5.MaxLength = 3;
			_txt_currency_name_5.Name = "_txt_currency_name_5";
			_txt_currency_name_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_currency_name_5.Size = new System.Drawing.Size(141, 19);
			_txt_currency_name_5.TabIndex = 119;
			// 
			// _txt_currency_name_4
			// 
			_txt_currency_name_4.AcceptsReturn = true;
			_txt_currency_name_4.AllowDrop = true;
			_txt_currency_name_4.BackColor = System.Drawing.SystemColors.Window;
			_txt_currency_name_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_currency_name_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_currency_name_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_currency_name_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_currency_name_4.Location = new System.Drawing.Point(10, 206);
			_txt_currency_name_4.MaxLength = 50;
			_txt_currency_name_4.Name = "_txt_currency_name_4";
			_txt_currency_name_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_currency_name_4.Size = new System.Drawing.Size(141, 19);
			_txt_currency_name_4.TabIndex = 118;
			// 
			// _txt_currency_name_3
			// 
			_txt_currency_name_3.AcceptsReturn = true;
			_txt_currency_name_3.AllowDrop = true;
			_txt_currency_name_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_currency_name_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_currency_name_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_currency_name_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_currency_name_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_currency_name_3.Location = new System.Drawing.Point(8, 286);
			_txt_currency_name_3.MaxLength = 250;
			_txt_currency_name_3.Multiline = true;
			_txt_currency_name_3.Name = "_txt_currency_name_3";
			_txt_currency_name_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_currency_name_3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			_txt_currency_name_3.Size = new System.Drawing.Size(222, 110);
			_txt_currency_name_3.TabIndex = 120;
			// 
			// _txt_currency_name_2
			// 
			_txt_currency_name_2.AcceptsReturn = true;
			_txt_currency_name_2.AllowDrop = true;
			_txt_currency_name_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_currency_name_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_currency_name_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_currency_name_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_currency_name_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_currency_name_2.Location = new System.Drawing.Point(8, 164);
			_txt_currency_name_2.MaxLength = 50;
			_txt_currency_name_2.Name = "_txt_currency_name_2";
			_txt_currency_name_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_currency_name_2.Size = new System.Drawing.Size(141, 19);
			_txt_currency_name_2.TabIndex = 117;
			// 
			// _txt_currency_name_1
			// 
			_txt_currency_name_1.AcceptsReturn = true;
			_txt_currency_name_1.AllowDrop = true;
			_txt_currency_name_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_currency_name_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_currency_name_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_currency_name_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_currency_name_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_currency_name_1.Location = new System.Drawing.Point(9, 119);
			_txt_currency_name_1.MaxLength = 50;
			_txt_currency_name_1.Name = "_txt_currency_name_1";
			_txt_currency_name_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_currency_name_1.Size = new System.Drawing.Size(141, 19);
			_txt_currency_name_1.TabIndex = 116;
			// 
			// _txt_currency_name_0
			// 
			_txt_currency_name_0.AcceptsReturn = true;
			_txt_currency_name_0.AllowDrop = true;
			_txt_currency_name_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_currency_name_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_currency_name_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_currency_name_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_currency_name_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_currency_name_0.Location = new System.Drawing.Point(8, 77);
			_txt_currency_name_0.MaxLength = 15;
			_txt_currency_name_0.Name = "_txt_currency_name_0";
			_txt_currency_name_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_currency_name_0.Size = new System.Drawing.Size(141, 19);
			_txt_currency_name_0.TabIndex = 115;
			// 
			// cmd_Save_Currency
			// 
			cmd_Save_Currency.AllowDrop = true;
			cmd_Save_Currency.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Currency.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Currency.Location = new System.Drawing.Point(10, 14);
			cmd_Save_Currency.Name = "cmd_Save_Currency";
			cmd_Save_Currency.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Currency.Size = new System.Drawing.Size(57, 25);
			cmd_Save_Currency.TabIndex = 114;
			cmd_Save_Currency.Text = "&Save";
			cmd_Save_Currency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Currency.UseVisualStyleBackColor = false;
			cmd_Save_Currency.Click += new System.EventHandler(cmd_Save_Currency_Click);
			// 
			// cmd_Cancel_Currency
			// 
			cmd_Cancel_Currency.AllowDrop = true;
			cmd_Cancel_Currency.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_Currency.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_Currency.Location = new System.Drawing.Point(89, 14);
			cmd_Cancel_Currency.Name = "cmd_Cancel_Currency";
			cmd_Cancel_Currency.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_Currency.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_Currency.TabIndex = 113;
			cmd_Cancel_Currency.Text = "&Cancel";
			cmd_Cancel_Currency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_Currency.UseVisualStyleBackColor = false;
			cmd_Cancel_Currency.Click += new System.EventHandler(cmd_Cancel_Currency_Click);
			// 
			// cmd_Delete_Currency
			// 
			cmd_Delete_Currency.AllowDrop = true;
			cmd_Delete_Currency.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_Currency.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_Currency.Location = new System.Drawing.Point(170, 14);
			cmd_Delete_Currency.Name = "cmd_Delete_Currency";
			cmd_Delete_Currency.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_Currency.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_Currency.TabIndex = 112;
			cmd_Delete_Currency.Text = "&Delete";
			cmd_Delete_Currency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_Currency.UseVisualStyleBackColor = false;
			cmd_Delete_Currency.Click += new System.EventHandler(cmd_Delete_Currency_Click);
			// 
			// _Label1_45
			// 
			_Label1_45.AllowDrop = true;
			_Label1_45.BackColor = System.Drawing.SystemColors.Control;
			_Label1_45.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_45.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_45.Location = new System.Drawing.Point(10, 230);
			_Label1_45.MinimumSize = new System.Drawing.Size(148, 16);
			_Label1_45.Name = "_Label1_45";
			_Label1_45.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_45.Size = new System.Drawing.Size(148, 16);
			_Label1_45.TabIndex = 287;
			_Label1_45.Text = "Currency ISO:";
			_Label1_45.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_44
			// 
			_Label1_44.AllowDrop = true;
			_Label1_44.BackColor = System.Drawing.SystemColors.Control;
			_Label1_44.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_44.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_44.Location = new System.Drawing.Point(10, 186);
			_Label1_44.MinimumSize = new System.Drawing.Size(148, 16);
			_Label1_44.Name = "_Label1_44";
			_Label1_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_44.Size = new System.Drawing.Size(148, 16);
			_Label1_44.TabIndex = 286;
			_Label1_44.Text = "Currency Country:";
			_Label1_44.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_43
			// 
			_Label1_43.AllowDrop = true;
			_Label1_43.BackColor = System.Drawing.SystemColors.Control;
			_Label1_43.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_43.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_43.Location = new System.Drawing.Point(8, 272);
			_Label1_43.MinimumSize = new System.Drawing.Size(163, 16);
			_Label1_43.Name = "_Label1_43";
			_Label1_43.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_43.Size = new System.Drawing.Size(163, 16);
			_Label1_43.TabIndex = 285;
			_Label1_43.Text = "Currency Exchange Rate Source:";
			_Label1_43.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_42
			// 
			_Label1_42.AllowDrop = true;
			_Label1_42.BackColor = System.Drawing.SystemColors.Control;
			_Label1_42.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_42.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_42.Location = new System.Drawing.Point(8, 143);
			_Label1_42.MinimumSize = new System.Drawing.Size(148, 16);
			_Label1_42.Name = "_Label1_42";
			_Label1_42.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_42.Size = new System.Drawing.Size(148, 16);
			_Label1_42.TabIndex = 284;
			_Label1_42.Text = "Currency Exchange Rate Date:";
			_Label1_42.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_41
			// 
			_Label1_41.AllowDrop = true;
			_Label1_41.BackColor = System.Drawing.SystemColors.Control;
			_Label1_41.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_41.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_41.Location = new System.Drawing.Point(8, 100);
			_Label1_41.MinimumSize = new System.Drawing.Size(122, 16);
			_Label1_41.Name = "_Label1_41";
			_Label1_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_41.Size = new System.Drawing.Size(122, 16);
			_Label1_41.TabIndex = 283;
			_Label1_41.Text = "Currency Exchange Rate:";
			_Label1_41.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_23
			// 
			_Label1_23.AllowDrop = true;
			_Label1_23.BackColor = System.Drawing.SystemColors.Control;
			_Label1_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_23.Location = new System.Drawing.Point(8, 58);
			_Label1_23.MinimumSize = new System.Drawing.Size(99, 16);
			_Label1_23.Name = "_Label1_23";
			_Label1_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_23.Size = new System.Drawing.Size(99, 16);
			_Label1_23.TabIndex = 121;
			_Label1_23.Text = "Currency Name:";
			_Label1_23.Click += new System.EventHandler(Label1_Click);
			// 
			// FG_Currency
			// 
			FG_Currency.AllowDrop = true;
			FG_Currency.AllowUserToAddRows = false;
			FG_Currency.AllowUserToDeleteRows = false;
			FG_Currency.AllowUserToResizeColumns = false;
			FG_Currency.AllowUserToResizeRows = false;
			FG_Currency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Currency.ColumnsCount = 6;
			FG_Currency.FixedColumns = 0;
			FG_Currency.FixedRows = 1;
			FG_Currency.Location = new System.Drawing.Point(19, 33);
			FG_Currency.Name = "FG_Currency";
			FG_Currency.ReadOnly = true;
			FG_Currency.RowsCount = 2;
			FG_Currency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Currency.ShowCellToolTips = false;
			FG_Currency.Size = new System.Drawing.Size(694, 446);
			FG_Currency.StandardTab = true;
			FG_Currency.TabIndex = 122;
			FG_Currency.Click += new System.EventHandler(FG_Currency_Click);
			// 
			// cmd_Add_Currency
			// 
			cmd_Add_Currency.AllowDrop = true;
			cmd_Add_Currency.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Currency.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Currency.Location = new System.Drawing.Point(719, 32);
			cmd_Add_Currency.Name = "cmd_Add_Currency";
			cmd_Add_Currency.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Currency.Size = new System.Drawing.Size(57, 25);
			cmd_Add_Currency.TabIndex = 2;
			cmd_Add_Currency.Text = "&Add";
			cmd_Add_Currency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Currency.UseVisualStyleBackColor = false;
			cmd_Add_Currency.Click += new System.EventHandler(cmd_Add_Currency_Click);
			// 
			// _tab_Lookup_TabPage6
			// 
			_tab_Lookup_TabPage6.Controls.Add(FG_Contact_SirName);
			_tab_Lookup_TabPage6.Controls.Add(cmd_Add_CSN);
			_tab_Lookup_TabPage6.Controls.Add(pnl_CSN_AddUpdate);
			_tab_Lookup_TabPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage6.Text = "Contact Sirname";
			// 
			// FG_Contact_SirName
			// 
			FG_Contact_SirName.AllowDrop = true;
			FG_Contact_SirName.AllowUserToAddRows = false;
			FG_Contact_SirName.AllowUserToDeleteRows = false;
			FG_Contact_SirName.AllowUserToResizeColumns = false;
			FG_Contact_SirName.AllowUserToResizeRows = false;
			FG_Contact_SirName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Contact_SirName.ColumnsCount = 1;
			FG_Contact_SirName.FixedColumns = 0;
			FG_Contact_SirName.FixedRows = 1;
			FG_Contact_SirName.Location = new System.Drawing.Point(37, 43);
			FG_Contact_SirName.Name = "FG_Contact_SirName";
			FG_Contact_SirName.ReadOnly = true;
			FG_Contact_SirName.RowsCount = 2;
			FG_Contact_SirName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			FG_Contact_SirName.ShowCellToolTips = false;
			FG_Contact_SirName.Size = new System.Drawing.Size(180, 381);
			FG_Contact_SirName.StandardTab = true;
			FG_Contact_SirName.TabIndex = 123;
			FG_Contact_SirName.Click += new System.EventHandler(FG_Contact_SirName_Click);
			// 
			// cmd_Add_CSN
			// 
			cmd_Add_CSN.AllowDrop = true;
			cmd_Add_CSN.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_CSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_CSN.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_CSN.Location = new System.Drawing.Point(245, 43);
			cmd_Add_CSN.Name = "cmd_Add_CSN";
			cmd_Add_CSN.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_CSN.Size = new System.Drawing.Size(57, 25);
			cmd_Add_CSN.TabIndex = 7;
			cmd_Add_CSN.Text = "&Add";
			cmd_Add_CSN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_CSN.UseVisualStyleBackColor = false;
			cmd_Add_CSN.Click += new System.EventHandler(cmd_Add_CSN_Click);
			// 
			// pnl_CSN_AddUpdate
			// 
			pnl_CSN_AddUpdate.AllowDrop = true;
			pnl_CSN_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_CSN_AddUpdate.Controls.Add(txt_csir_name);
			pnl_CSN_AddUpdate.Controls.Add(cmd_Delete_CSN);
			pnl_CSN_AddUpdate.Controls.Add(cmd_Cancel_CSN);
			pnl_CSN_AddUpdate.Controls.Add(cmd_Save_CSN);
			pnl_CSN_AddUpdate.Controls.Add(_Label1_15);
			pnl_CSN_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_CSN_AddUpdate.Location = new System.Drawing.Point(243, 73);
			pnl_CSN_AddUpdate.Name = "pnl_CSN_AddUpdate";
			pnl_CSN_AddUpdate.Size = new System.Drawing.Size(258, 136);
			pnl_CSN_AddUpdate.TabIndex = 69;
			pnl_CSN_AddUpdate.Visible = false;
			// 
			// txt_csir_name
			// 
			txt_csir_name.AcceptsReturn = true;
			txt_csir_name.AllowDrop = true;
			txt_csir_name.BackColor = System.Drawing.SystemColors.Window;
			txt_csir_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_csir_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_csir_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_csir_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_csir_name.Location = new System.Drawing.Point(12, 67);
			txt_csir_name.MaxLength = 15;
			txt_csir_name.Name = "txt_csir_name";
			txt_csir_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_csir_name.Size = new System.Drawing.Size(149, 19);
			txt_csir_name.TabIndex = 73;
			txt_csir_name.Leave += new System.EventHandler(txt_csir_name_Leave);
			// 
			// cmd_Delete_CSN
			// 
			cmd_Delete_CSN.AllowDrop = true;
			cmd_Delete_CSN.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_CSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_CSN.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_CSN.Location = new System.Drawing.Point(150, 8);
			cmd_Delete_CSN.Name = "cmd_Delete_CSN";
			cmd_Delete_CSN.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_CSN.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_CSN.TabIndex = 72;
			cmd_Delete_CSN.Text = "&Delete";
			cmd_Delete_CSN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_CSN.UseVisualStyleBackColor = false;
			cmd_Delete_CSN.Click += new System.EventHandler(cmd_Delete_CSN_Click);
			// 
			// cmd_Cancel_CSN
			// 
			cmd_Cancel_CSN.AllowDrop = true;
			cmd_Cancel_CSN.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_CSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_CSN.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_CSN.Location = new System.Drawing.Point(79, 9);
			cmd_Cancel_CSN.Name = "cmd_Cancel_CSN";
			cmd_Cancel_CSN.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_CSN.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_CSN.TabIndex = 71;
			cmd_Cancel_CSN.Text = "&Cancel";
			cmd_Cancel_CSN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_CSN.UseVisualStyleBackColor = false;
			cmd_Cancel_CSN.Click += new System.EventHandler(cmd_Cancel_CSN_Click);
			// 
			// cmd_Save_CSN
			// 
			cmd_Save_CSN.AllowDrop = true;
			cmd_Save_CSN.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_CSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_CSN.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_CSN.Location = new System.Drawing.Point(5, 6);
			cmd_Save_CSN.Name = "cmd_Save_CSN";
			cmd_Save_CSN.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_CSN.Size = new System.Drawing.Size(57, 25);
			cmd_Save_CSN.TabIndex = 70;
			cmd_Save_CSN.Text = "&Save";
			cmd_Save_CSN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_CSN.UseVisualStyleBackColor = false;
			cmd_Save_CSN.Click += new System.EventHandler(cmd_Save_CSN_Click);
			// 
			// _Label1_15
			// 
			_Label1_15.AllowDrop = true;
			_Label1_15.BackColor = System.Drawing.SystemColors.Control;
			_Label1_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_15.Location = new System.Drawing.Point(13, 46);
			_Label1_15.MinimumSize = new System.Drawing.Size(141, 17);
			_Label1_15.Name = "_Label1_15";
			_Label1_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_15.Size = new System.Drawing.Size(141, 17);
			_Label1_15.TabIndex = 74;
			_Label1_15.Text = "Sirname";
			_Label1_15.Click += new System.EventHandler(Label1_Click);
			// 
			// _tab_Lookup_TabPage7
			// 
			_tab_Lookup_TabPage7.Controls.Add(cmd_Add_CS);
			_tab_Lookup_TabPage7.Controls.Add(FG_Contact_Suffix);
			_tab_Lookup_TabPage7.Controls.Add(pnl_CS_AddUpdate);
			_tab_Lookup_TabPage7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage7.Text = "Contact Suffix";
			// 
			// cmd_Add_CS
			// 
			cmd_Add_CS.AllowDrop = true;
			cmd_Add_CS.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_CS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_CS.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_CS.Location = new System.Drawing.Point(233, 39);
			cmd_Add_CS.Name = "cmd_Add_CS";
			cmd_Add_CS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_CS.Size = new System.Drawing.Size(57, 25);
			cmd_Add_CS.TabIndex = 125;
			cmd_Add_CS.Text = "&Add";
			cmd_Add_CS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_CS.UseVisualStyleBackColor = false;
			cmd_Add_CS.Click += new System.EventHandler(cmd_Add_CS_Click);
			// 
			// FG_Contact_Suffix
			// 
			FG_Contact_Suffix.AllowDrop = true;
			FG_Contact_Suffix.AllowUserToAddRows = false;
			FG_Contact_Suffix.AllowUserToDeleteRows = false;
			FG_Contact_Suffix.AllowUserToResizeColumns = false;
			FG_Contact_Suffix.AllowUserToResizeRows = false;
			FG_Contact_Suffix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Contact_Suffix.ColumnsCount = 1;
			FG_Contact_Suffix.FixedColumns = 0;
			FG_Contact_Suffix.FixedRows = 1;
			FG_Contact_Suffix.Location = new System.Drawing.Point(38, 35);
			FG_Contact_Suffix.Name = "FG_Contact_Suffix";
			FG_Contact_Suffix.ReadOnly = true;
			FG_Contact_Suffix.RowsCount = 2;
			FG_Contact_Suffix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			FG_Contact_Suffix.ShowCellToolTips = false;
			FG_Contact_Suffix.Size = new System.Drawing.Size(168, 363);
			FG_Contact_Suffix.StandardTab = true;
			FG_Contact_Suffix.TabIndex = 124;
			FG_Contact_Suffix.Click += new System.EventHandler(FG_Contact_Suffix_Click);
			// 
			// pnl_CS_AddUpdate
			// 
			pnl_CS_AddUpdate.AllowDrop = true;
			pnl_CS_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_CS_AddUpdate.Controls.Add(cmd_Save_CS);
			pnl_CS_AddUpdate.Controls.Add(cmd_Cancel_CS);
			pnl_CS_AddUpdate.Controls.Add(cmd_Delete_CS);
			pnl_CS_AddUpdate.Controls.Add(txt_csuffix_name);
			pnl_CS_AddUpdate.Controls.Add(_Label1_14);
			pnl_CS_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_CS_AddUpdate.Location = new System.Drawing.Point(230, 70);
			pnl_CS_AddUpdate.Name = "pnl_CS_AddUpdate";
			pnl_CS_AddUpdate.Size = new System.Drawing.Size(259, 132);
			pnl_CS_AddUpdate.TabIndex = 75;
			pnl_CS_AddUpdate.Visible = false;
			// 
			// cmd_Save_CS
			// 
			cmd_Save_CS.AllowDrop = true;
			cmd_Save_CS.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_CS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_CS.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_CS.Location = new System.Drawing.Point(7, 10);
			cmd_Save_CS.Name = "cmd_Save_CS";
			cmd_Save_CS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_CS.Size = new System.Drawing.Size(57, 25);
			cmd_Save_CS.TabIndex = 79;
			cmd_Save_CS.Text = "&Save";
			cmd_Save_CS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_CS.UseVisualStyleBackColor = false;
			cmd_Save_CS.Click += new System.EventHandler(cmd_Save_CS_Click);
			// 
			// cmd_Cancel_CS
			// 
			cmd_Cancel_CS.AllowDrop = true;
			cmd_Cancel_CS.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_CS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_CS.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_CS.Location = new System.Drawing.Point(81, 12);
			cmd_Cancel_CS.Name = "cmd_Cancel_CS";
			cmd_Cancel_CS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_CS.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_CS.TabIndex = 78;
			cmd_Cancel_CS.Text = "&Cancel";
			cmd_Cancel_CS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_CS.UseVisualStyleBackColor = false;
			cmd_Cancel_CS.Click += new System.EventHandler(cmd_Cancel_CS_Click);
			// 
			// cmd_Delete_CS
			// 
			cmd_Delete_CS.AllowDrop = true;
			cmd_Delete_CS.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_CS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_CS.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_CS.Location = new System.Drawing.Point(159, 12);
			cmd_Delete_CS.Name = "cmd_Delete_CS";
			cmd_Delete_CS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_CS.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_CS.TabIndex = 77;
			cmd_Delete_CS.Text = "&Delete";
			cmd_Delete_CS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_CS.UseVisualStyleBackColor = false;
			cmd_Delete_CS.Click += new System.EventHandler(cmd_Delete_CS_Click);
			// 
			// txt_csuffix_name
			// 
			txt_csuffix_name.AcceptsReturn = true;
			txt_csuffix_name.AllowDrop = true;
			txt_csuffix_name.BackColor = System.Drawing.SystemColors.Window;
			txt_csuffix_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_csuffix_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_csuffix_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_csuffix_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_csuffix_name.Location = new System.Drawing.Point(9, 79);
			txt_csuffix_name.MaxLength = 15;
			txt_csuffix_name.Name = "txt_csuffix_name";
			txt_csuffix_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_csuffix_name.Size = new System.Drawing.Size(220, 19);
			txt_csuffix_name.TabIndex = 76;
			// 
			// _Label1_14
			// 
			_Label1_14.AllowDrop = true;
			_Label1_14.BackColor = System.Drawing.Color.Transparent;
			_Label1_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_14.Location = new System.Drawing.Point(11, 56);
			_Label1_14.MinimumSize = new System.Drawing.Size(141, 17);
			_Label1_14.Name = "_Label1_14";
			_Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_14.Size = new System.Drawing.Size(141, 17);
			_Label1_14.TabIndex = 80;
			_Label1_14.Text = "Name Suffix";
			_Label1_14.Click += new System.EventHandler(Label1_Click);
			// 
			// _tab_Lookup_TabPage8
			// 
			_tab_Lookup_TabPage8.Controls.Add(Label2);
			_tab_Lookup_TabPage8.Controls.Add(tab_contact_title);
			_tab_Lookup_TabPage8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage8.Text = "Contact Title";
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.BackColor = System.Drawing.SystemColors.Control;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			Label2.Location = new System.Drawing.Point(362, 242);
			Label2.MinimumSize = new System.Drawing.Size(2, 2);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(2, 2);
			Label2.TabIndex = 308;
			Label2.Text = "Label2";
			// 
			// tab_contact_title
			// 
			tab_contact_title.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_contact_title.AllowDrop = true;
			tab_contact_title.Controls.Add(_tab_contact_title_TabPage0);
			tab_contact_title.Controls.Add(_tab_contact_title_TabPage1);
			tab_contact_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_contact_title.ItemSize = new System.Drawing.Size(471, 18);
			tab_contact_title.Location = new System.Drawing.Point(8, 4);
			tab_contact_title.Multiline = true;
			tab_contact_title.Name = "tab_contact_title";
			tab_contact_title.Size = new System.Drawing.Size(949, 581);
			tab_contact_title.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_contact_title.TabIndex = 321;
			// 
			// _tab_contact_title_TabPage0
			// 
			_tab_contact_title_TabPage0.Controls.Add(_Label1_47);
			_tab_contact_title_TabPage0.Controls.Add(_Label1_46);
			_tab_contact_title_TabPage0.Controls.Add(_lblTotTitles_2);
			_tab_contact_title_TabPage0.Controls.Add(_lblStopTitleLoad_1);
			_tab_contact_title_TabPage0.Controls.Add(FG_Contact_Title);
			_tab_contact_title_TabPage0.Controls.Add(pnl_ContactTitleGroup);
			_tab_contact_title_TabPage0.Controls.Add(pnl_CT_AddUpdate);
			_tab_contact_title_TabPage0.Controls.Add(cboSearchTitleGroup);
			_tab_contact_title_TabPage0.Controls.Add(frmTitleSearchOptions);
			_tab_contact_title_TabPage0.Controls.Add(txt_title_search);
			_tab_contact_title_TabPage0.Controls.Add(_cmd_contact_button_5);
			_tab_contact_title_TabPage0.Controls.Add(_cmd_contact_button_6);
			_tab_contact_title_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_contact_title_TabPage0.Text = "Contact Title Group";
			// 
			// _Label1_47
			// 
			_Label1_47.AllowDrop = true;
			_Label1_47.BackColor = System.Drawing.SystemColors.Control;
			_Label1_47.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_47.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_47.Location = new System.Drawing.Point(254, 48);
			_Label1_47.MinimumSize = new System.Drawing.Size(115, 17);
			_Label1_47.Name = "_Label1_47";
			_Label1_47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_47.Size = new System.Drawing.Size(115, 17);
			_Label1_47.TabIndex = 343;
			_Label1_47.Text = "Search By Title Group";
			_Label1_47.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_46
			// 
			_Label1_46.AllowDrop = true;
			_Label1_46.BackColor = System.Drawing.SystemColors.Control;
			_Label1_46.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_46.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_46.Location = new System.Drawing.Point(254, 26);
			_Label1_46.MinimumSize = new System.Drawing.Size(115, 17);
			_Label1_46.Name = "_Label1_46";
			_Label1_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_46.Size = new System.Drawing.Size(115, 17);
			_Label1_46.TabIndex = 344;
			_Label1_46.Text = "Search By Title Name";
			_Label1_46.Click += new System.EventHandler(Label1_Click);
			// 
			// _lblTotTitles_2
			// 
			_lblTotTitles_2.AllowDrop = true;
			_lblTotTitles_2.BackColor = System.Drawing.SystemColors.Control;
			_lblTotTitles_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblTotTitles_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblTotTitles_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblTotTitles_2.Location = new System.Drawing.Point(8, 524);
			_lblTotTitles_2.MinimumSize = new System.Drawing.Size(213, 13);
			_lblTotTitles_2.Name = "_lblTotTitles_2";
			_lblTotTitles_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblTotTitles_2.Size = new System.Drawing.Size(213, 13);
			_lblTotTitles_2.TabIndex = 372;
			_lblTotTitles_2.Text = "Total Records Loaded:";
			// 
			// _lblStopTitleLoad_1
			// 
			_lblStopTitleLoad_1.AllowDrop = true;
			_lblStopTitleLoad_1.BackColor = System.Drawing.SystemColors.Control;
			_lblStopTitleLoad_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblStopTitleLoad_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblStopTitleLoad_1.ForeColor = System.Drawing.Color.Blue;
			_lblStopTitleLoad_1.Location = new System.Drawing.Point(424, 524);
			_lblStopTitleLoad_1.MinimumSize = new System.Drawing.Size(77, 15);
			_lblStopTitleLoad_1.Name = "_lblStopTitleLoad_1";
			_lblStopTitleLoad_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblStopTitleLoad_1.Size = new System.Drawing.Size(77, 15);
			_lblStopTitleLoad_1.TabIndex = 373;
			_lblStopTitleLoad_1.Text = "Stop Loading";
			_lblStopTitleLoad_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblStopTitleLoad_1.Visible = false;
			_lblStopTitleLoad_1.Click += new System.EventHandler(lblStopTitleLoad_Click);
			// 
			// FG_Contact_Title
			// 
			FG_Contact_Title.AllowDrop = true;
			FG_Contact_Title.AllowUserToAddRows = false;
			FG_Contact_Title.AllowUserToDeleteRows = false;
			FG_Contact_Title.AllowUserToResizeColumns = false;
			FG_Contact_Title.AllowUserToResizeRows = false;
			FG_Contact_Title.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Contact_Title.ColumnsCount = 2;
			FG_Contact_Title.FixedColumns = 0;
			FG_Contact_Title.FixedRows = 1;
			FG_Contact_Title.Location = new System.Drawing.Point(8, 76);
			FG_Contact_Title.Name = "FG_Contact_Title";
			FG_Contact_Title.ReadOnly = true;
			FG_Contact_Title.RowsCount = 2;
			FG_Contact_Title.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Contact_Title.ShowCellToolTips = false;
			FG_Contact_Title.Size = new System.Drawing.Size(497, 438);
			FG_Contact_Title.StandardTab = true;
			FG_Contact_Title.TabIndex = 342;
			FG_Contact_Title.Click += new System.EventHandler(FG_Contact_Title_Click);
			// 
			// pnl_ContactTitleGroup
			// 
			pnl_ContactTitleGroup.AllowDrop = true;
			pnl_ContactTitleGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_ContactTitleGroup.Controls.Add(_cmd_contact_button_4);
			pnl_ContactTitleGroup.Controls.Add(_cmd_contact_button_3);
			pnl_ContactTitleGroup.Controls.Add(lstTitleGroup);
			pnl_ContactTitleGroup.Controls.Add(lstAllTitleGroups);
			pnl_ContactTitleGroup.Controls.Add(_Label1_11);
			pnl_ContactTitleGroup.Controls.Add(_Label1_12);
			pnl_ContactTitleGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_ContactTitleGroup.Location = new System.Drawing.Point(512, 107);
			pnl_ContactTitleGroup.Name = "pnl_ContactTitleGroup";
			pnl_ContactTitleGroup.Size = new System.Drawing.Size(418, 146);
			pnl_ContactTitleGroup.TabIndex = 337;
			pnl_ContactTitleGroup.Visible = false;
			// 
			// _cmd_contact_button_4
			// 
			_cmd_contact_button_4.AllowDrop = true;
			_cmd_contact_button_4.BackColor = System.Drawing.SystemColors.Control;
			_cmd_contact_button_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_contact_button_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_contact_button_4.Location = new System.Drawing.Point(184, 80);
			_cmd_contact_button_4.Name = "_cmd_contact_button_4";
			_cmd_contact_button_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_contact_button_4.Size = new System.Drawing.Size(41, 25);
			_cmd_contact_button_4.TabIndex = 354;
			_cmd_contact_button_4.Text = "<----";
			_cmd_contact_button_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_contact_button_4.UseVisualStyleBackColor = false;
			_cmd_contact_button_4.Click += new System.EventHandler(cmd_contact_button_Click);
			// 
			// _cmd_contact_button_3
			// 
			_cmd_contact_button_3.AllowDrop = true;
			_cmd_contact_button_3.BackColor = System.Drawing.SystemColors.Control;
			_cmd_contact_button_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_contact_button_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_contact_button_3.Location = new System.Drawing.Point(184, 32);
			_cmd_contact_button_3.Name = "_cmd_contact_button_3";
			_cmd_contact_button_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_contact_button_3.Size = new System.Drawing.Size(41, 25);
			_cmd_contact_button_3.TabIndex = 353;
			_cmd_contact_button_3.Text = "---->";
			_cmd_contact_button_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_contact_button_3.UseVisualStyleBackColor = false;
			_cmd_contact_button_3.Click += new System.EventHandler(cmd_contact_button_Click);
			// 
			// lstTitleGroup
			// 
			lstTitleGroup.AllowDrop = true;
			lstTitleGroup.BackColor = System.Drawing.SystemColors.Window;
			lstTitleGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lstTitleGroup.CausesValidation = true;
			lstTitleGroup.Enabled = true;
			lstTitleGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstTitleGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			lstTitleGroup.IntegralHeight = true;
			lstTitleGroup.Location = new System.Drawing.Point(227, 20);
			lstTitleGroup.MultiColumn = false;
			lstTitleGroup.Name = "lstTitleGroup";
			lstTitleGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstTitleGroup.Size = new System.Drawing.Size(184, 124);
			lstTitleGroup.Sorted = false;
			lstTitleGroup.TabIndex = 339;
			lstTitleGroup.TabStop = true;
			lstTitleGroup.Visible = true;
			lstTitleGroup.DoubleClick += new System.EventHandler(lstTitleGroup_DoubleClick);
			// 
			// lstAllTitleGroups
			// 
			lstAllTitleGroups.AllowDrop = true;
			lstAllTitleGroups.BackColor = System.Drawing.SystemColors.Window;
			lstAllTitleGroups.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lstAllTitleGroups.CausesValidation = true;
			lstAllTitleGroups.Enabled = true;
			lstAllTitleGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstAllTitleGroups.ForeColor = System.Drawing.SystemColors.WindowText;
			lstAllTitleGroups.IntegralHeight = true;
			lstAllTitleGroups.Location = new System.Drawing.Point(6, 19);
			lstAllTitleGroups.MultiColumn = false;
			lstAllTitleGroups.Name = "lstAllTitleGroups";
			lstAllTitleGroups.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstAllTitleGroups.Size = new System.Drawing.Size(170, 124);
			lstAllTitleGroups.Sorted = false;
			lstAllTitleGroups.TabIndex = 338;
			lstAllTitleGroups.TabStop = true;
			lstAllTitleGroups.Visible = true;
			// 
			// _Label1_11
			// 
			_Label1_11.AllowDrop = true;
			_Label1_11.AutoSize = true;
			_Label1_11.BackColor = System.Drawing.SystemColors.Control;
			_Label1_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_11.Location = new System.Drawing.Point(6, 4);
			_Label1_11.MinimumSize = new System.Drawing.Size(86, 13);
			_Label1_11.Name = "_Label1_11";
			_Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_11.Size = new System.Drawing.Size(86, 13);
			_Label1_11.TabIndex = 341;
			_Label1_11.Text = "Master Group List:";
			_Label1_11.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_12
			// 
			_Label1_12.AllowDrop = true;
			_Label1_12.AutoSize = true;
			_Label1_12.BackColor = System.Drawing.SystemColors.Control;
			_Label1_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_12.Location = new System.Drawing.Point(227, 4);
			_Label1_12.MinimumSize = new System.Drawing.Size(120, 13);
			_Label1_12.Name = "_Label1_12";
			_Label1_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_12.Size = new System.Drawing.Size(120, 13);
			_Label1_12.TabIndex = 340;
			_Label1_12.Text = "This Title is a Member Of:";
			_Label1_12.Click += new System.EventHandler(Label1_Click);
			// 
			// pnl_CT_AddUpdate
			// 
			pnl_CT_AddUpdate.AllowDrop = true;
			pnl_CT_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_CT_AddUpdate.Controls.Add(_cmd_contact_button_2);
			pnl_CT_AddUpdate.Controls.Add(chk_ctitle_active_flag);
			pnl_CT_AddUpdate.Controls.Add(cmd_Save_CT);
			pnl_CT_AddUpdate.Controls.Add(cmd_Delete_CT);
			pnl_CT_AddUpdate.Controls.Add(txt_ctitle_name);
			pnl_CT_AddUpdate.Controls.Add(_Label1_13);
			pnl_CT_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_CT_AddUpdate.Location = new System.Drawing.Point(560, 16);
			pnl_CT_AddUpdate.Name = "pnl_CT_AddUpdate";
			pnl_CT_AddUpdate.Size = new System.Drawing.Size(325, 85);
			pnl_CT_AddUpdate.TabIndex = 331;
			pnl_CT_AddUpdate.Visible = false;
			// 
			// _cmd_contact_button_2
			// 
			_cmd_contact_button_2.AllowDrop = true;
			_cmd_contact_button_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_contact_button_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_contact_button_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_contact_button_2.Location = new System.Drawing.Point(88, 8);
			_cmd_contact_button_2.Name = "_cmd_contact_button_2";
			_cmd_contact_button_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_contact_button_2.Size = new System.Drawing.Size(73, 25);
			_cmd_contact_button_2.TabIndex = 352;
			_cmd_contact_button_2.Text = "Cancel";
			_cmd_contact_button_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_contact_button_2.UseVisualStyleBackColor = false;
			_cmd_contact_button_2.Click += new System.EventHandler(cmd_contact_button_Click);
			// 
			// chk_ctitle_active_flag
			// 
			chk_ctitle_active_flag.AllowDrop = true;
			chk_ctitle_active_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_ctitle_active_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_ctitle_active_flag.CausesValidation = true;
			chk_ctitle_active_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_ctitle_active_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_ctitle_active_flag.Enabled = true;
			chk_ctitle_active_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_ctitle_active_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_ctitle_active_flag.Location = new System.Drawing.Point(248, 62);
			chk_ctitle_active_flag.Name = "chk_ctitle_active_flag";
			chk_ctitle_active_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_ctitle_active_flag.Size = new System.Drawing.Size(65, 13);
			chk_ctitle_active_flag.TabIndex = 335;
			chk_ctitle_active_flag.TabStop = true;
			chk_ctitle_active_flag.Text = "Active";
			chk_ctitle_active_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_ctitle_active_flag.Visible = true;
			// 
			// cmd_Save_CT
			// 
			cmd_Save_CT.AllowDrop = true;
			cmd_Save_CT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_CT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_CT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_CT.Location = new System.Drawing.Point(10, 7);
			cmd_Save_CT.Name = "cmd_Save_CT";
			cmd_Save_CT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_CT.Size = new System.Drawing.Size(57, 25);
			cmd_Save_CT.TabIndex = 334;
			cmd_Save_CT.Text = "&Save";
			cmd_Save_CT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_CT.UseVisualStyleBackColor = false;
			cmd_Save_CT.Click += new System.EventHandler(cmd_Save_CT_Click);
			// 
			// cmd_Delete_CT
			// 
			cmd_Delete_CT.AllowDrop = true;
			cmd_Delete_CT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_CT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_CT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_CT.Location = new System.Drawing.Point(200, 8);
			cmd_Delete_CT.Name = "cmd_Delete_CT";
			cmd_Delete_CT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_CT.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_CT.TabIndex = 333;
			cmd_Delete_CT.Text = "&Delete";
			cmd_Delete_CT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_CT.UseVisualStyleBackColor = false;
			cmd_Delete_CT.Click += new System.EventHandler(cmd_Delete_CT_Click);
			// 
			// txt_ctitle_name
			// 
			txt_ctitle_name.AcceptsReturn = true;
			txt_ctitle_name.AllowDrop = true;
			txt_ctitle_name.BackColor = System.Drawing.SystemColors.Window;
			txt_ctitle_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ctitle_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ctitle_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ctitle_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ctitle_name.Location = new System.Drawing.Point(2, 58);
			txt_ctitle_name.MaxLength = 80;
			txt_ctitle_name.Name = "txt_ctitle_name";
			txt_ctitle_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ctitle_name.Size = new System.Drawing.Size(231, 19);
			txt_ctitle_name.TabIndex = 332;
			// 
			// _Label1_13
			// 
			_Label1_13.AllowDrop = true;
			_Label1_13.AutoSize = true;
			_Label1_13.BackColor = System.Drawing.SystemColors.Control;
			_Label1_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_13.Location = new System.Drawing.Point(3, 43);
			_Label1_13.MinimumSize = new System.Drawing.Size(28, 13);
			_Label1_13.Name = "_Label1_13";
			_Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_13.Size = new System.Drawing.Size(28, 13);
			_Label1_13.TabIndex = 336;
			_Label1_13.Text = "Name";
			_Label1_13.Click += new System.EventHandler(Label1_Click);
			// 
			// cboSearchTitleGroup
			// 
			cboSearchTitleGroup.AllowDrop = true;
			cboSearchTitleGroup.BackColor = System.Drawing.SystemColors.Window;
			cboSearchTitleGroup.CausesValidation = true;
			cboSearchTitleGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboSearchTitleGroup.Enabled = true;
			cboSearchTitleGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboSearchTitleGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			cboSearchTitleGroup.IntegralHeight = true;
			cboSearchTitleGroup.Location = new System.Drawing.Point(8, 46);
			cboSearchTitleGroup.Name = "cboSearchTitleGroup";
			cboSearchTitleGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboSearchTitleGroup.Size = new System.Drawing.Size(235, 21);
			cboSearchTitleGroup.Sorted = false;
			cboSearchTitleGroup.TabIndex = 322;
			cboSearchTitleGroup.TabStop = true;
			cboSearchTitleGroup.Visible = true;
			// 
			// frmTitleSearchOptions
			// 
			frmTitleSearchOptions.AllowDrop = true;
			frmTitleSearchOptions.BackColor = System.Drawing.SystemColors.Control;
			frmTitleSearchOptions.Controls.Add(chkTitlesNotMapped);
			frmTitleSearchOptions.Controls.Add(chkPilotsNotInPilotsGroup);
			frmTitleSearchOptions.Controls.Add(chkChairmanCEONotInChairmanCEOGroup);
			frmTitleSearchOptions.Controls.Add(chkCFONotInCFOGroup);
			frmTitleSearchOptions.Controls.Add(chkTitleNotInGroup);
			frmTitleSearchOptions.Controls.Add(cboTitleNotInGroup);
			frmTitleSearchOptions.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmTitleSearchOptions.Enabled = true;
			frmTitleSearchOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmTitleSearchOptions.ForeColor = System.Drawing.SystemColors.ControlText;
			frmTitleSearchOptions.Location = new System.Drawing.Point(512, 276);
			frmTitleSearchOptions.Name = "frmTitleSearchOptions";
			frmTitleSearchOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmTitleSearchOptions.Size = new System.Drawing.Size(415, 165);
			frmTitleSearchOptions.TabIndex = 323;
			frmTitleSearchOptions.Text = "Title Search Options";
			frmTitleSearchOptions.Visible = true;
			// 
			// chkTitlesNotMapped
			// 
			chkTitlesNotMapped.AllowDrop = true;
			chkTitlesNotMapped.Appearance = System.Windows.Forms.Appearance.Normal;
			chkTitlesNotMapped.BackColor = System.Drawing.SystemColors.Control;
			chkTitlesNotMapped.CausesValidation = true;
			chkTitlesNotMapped.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkTitlesNotMapped.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkTitlesNotMapped.Enabled = true;
			chkTitlesNotMapped.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkTitlesNotMapped.ForeColor = System.Drawing.SystemColors.ControlText;
			chkTitlesNotMapped.Location = new System.Drawing.Point(14, 32);
			chkTitlesNotMapped.Name = "chkTitlesNotMapped";
			chkTitlesNotMapped.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkTitlesNotMapped.Size = new System.Drawing.Size(169, 15);
			chkTitlesNotMapped.TabIndex = 329;
			chkTitlesNotMapped.TabStop = true;
			chkTitlesNotMapped.Text = "Titles Not Mapped To A Group";
			chkTitlesNotMapped.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkTitlesNotMapped.Visible = true;
			// 
			// chkPilotsNotInPilotsGroup
			// 
			chkPilotsNotInPilotsGroup.AllowDrop = true;
			chkPilotsNotInPilotsGroup.Appearance = System.Windows.Forms.Appearance.Normal;
			chkPilotsNotInPilotsGroup.BackColor = System.Drawing.SystemColors.Control;
			chkPilotsNotInPilotsGroup.CausesValidation = true;
			chkPilotsNotInPilotsGroup.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkPilotsNotInPilotsGroup.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkPilotsNotInPilotsGroup.Enabled = true;
			chkPilotsNotInPilotsGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkPilotsNotInPilotsGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			chkPilotsNotInPilotsGroup.Location = new System.Drawing.Point(14, 50);
			chkPilotsNotInPilotsGroup.Name = "chkPilotsNotInPilotsGroup";
			chkPilotsNotInPilotsGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkPilotsNotInPilotsGroup.Size = new System.Drawing.Size(169, 15);
			chkPilotsNotInPilotsGroup.TabIndex = 328;
			chkPilotsNotInPilotsGroup.TabStop = true;
			chkPilotsNotInPilotsGroup.Text = "Pilot Titles Not In Pilot Group";
			chkPilotsNotInPilotsGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkPilotsNotInPilotsGroup.Visible = true;
			// 
			// chkChairmanCEONotInChairmanCEOGroup
			// 
			chkChairmanCEONotInChairmanCEOGroup.AllowDrop = true;
			chkChairmanCEONotInChairmanCEOGroup.Appearance = System.Windows.Forms.Appearance.Normal;
			chkChairmanCEONotInChairmanCEOGroup.BackColor = System.Drawing.SystemColors.Control;
			chkChairmanCEONotInChairmanCEOGroup.CausesValidation = true;
			chkChairmanCEONotInChairmanCEOGroup.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkChairmanCEONotInChairmanCEOGroup.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkChairmanCEONotInChairmanCEOGroup.Enabled = true;
			chkChairmanCEONotInChairmanCEOGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkChairmanCEONotInChairmanCEOGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			chkChairmanCEONotInChairmanCEOGroup.Location = new System.Drawing.Point(14, 68);
			chkChairmanCEONotInChairmanCEOGroup.Name = "chkChairmanCEONotInChairmanCEOGroup";
			chkChairmanCEONotInChairmanCEOGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkChairmanCEONotInChairmanCEOGroup.Size = new System.Drawing.Size(245, 15);
			chkChairmanCEONotInChairmanCEOGroup.TabIndex = 327;
			chkChairmanCEONotInChairmanCEOGroup.TabStop = true;
			chkChairmanCEONotInChairmanCEOGroup.Text = "Chairman or CEO Not In Chairman/CEO Group";
			chkChairmanCEONotInChairmanCEOGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkChairmanCEONotInChairmanCEOGroup.Visible = true;
			// 
			// chkCFONotInCFOGroup
			// 
			chkCFONotInCFOGroup.AllowDrop = true;
			chkCFONotInCFOGroup.Appearance = System.Windows.Forms.Appearance.Normal;
			chkCFONotInCFOGroup.BackColor = System.Drawing.SystemColors.Control;
			chkCFONotInCFOGroup.CausesValidation = true;
			chkCFONotInCFOGroup.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCFONotInCFOGroup.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkCFONotInCFOGroup.Enabled = true;
			chkCFONotInCFOGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkCFONotInCFOGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			chkCFONotInCFOGroup.Location = new System.Drawing.Point(14, 86);
			chkCFONotInCFOGroup.Name = "chkCFONotInCFOGroup";
			chkCFONotInCFOGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkCFONotInCFOGroup.Size = new System.Drawing.Size(239, 15);
			chkCFONotInCFOGroup.TabIndex = 326;
			chkCFONotInCFOGroup.TabStop = true;
			chkCFONotInCFOGroup.Text = "CFO Not In CFO or Finance Group";
			chkCFONotInCFOGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCFONotInCFOGroup.Visible = true;
			// 
			// chkTitleNotInGroup
			// 
			chkTitleNotInGroup.AllowDrop = true;
			chkTitleNotInGroup.Appearance = System.Windows.Forms.Appearance.Normal;
			chkTitleNotInGroup.BackColor = System.Drawing.SystemColors.Control;
			chkTitleNotInGroup.CausesValidation = true;
			chkTitleNotInGroup.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkTitleNotInGroup.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkTitleNotInGroup.Enabled = true;
			chkTitleNotInGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkTitleNotInGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			chkTitleNotInGroup.Location = new System.Drawing.Point(14, 104);
			chkTitleNotInGroup.Name = "chkTitleNotInGroup";
			chkTitleNotInGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkTitleNotInGroup.Size = new System.Drawing.Size(147, 15);
			chkTitleNotInGroup.TabIndex = 325;
			chkTitleNotInGroup.TabStop = true;
			chkTitleNotInGroup.Text = "Title Not In Specific Group";
			chkTitleNotInGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkTitleNotInGroup.Visible = true;
			chkTitleNotInGroup.CheckStateChanged += new System.EventHandler(chkTitleNotInGroup_CheckStateChanged);
			// 
			// cboTitleNotInGroup
			// 
			cboTitleNotInGroup.AllowDrop = true;
			cboTitleNotInGroup.BackColor = System.Drawing.SystemColors.Window;
			cboTitleNotInGroup.CausesValidation = true;
			cboTitleNotInGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboTitleNotInGroup.Enabled = true;
			cboTitleNotInGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboTitleNotInGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			cboTitleNotInGroup.IntegralHeight = true;
			cboTitleNotInGroup.Location = new System.Drawing.Point(174, 102);
			cboTitleNotInGroup.Name = "cboTitleNotInGroup";
			cboTitleNotInGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboTitleNotInGroup.Size = new System.Drawing.Size(235, 21);
			cboTitleNotInGroup.Sorted = false;
			cboTitleNotInGroup.TabIndex = 324;
			cboTitleNotInGroup.TabStop = true;
			cboTitleNotInGroup.Visible = false;
			// 
			// txt_title_search
			// 
			txt_title_search.AcceptsReturn = true;
			txt_title_search.AllowDrop = true;
			txt_title_search.BackColor = System.Drawing.SystemColors.Window;
			txt_title_search.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_title_search.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_title_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_title_search.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_title_search.Location = new System.Drawing.Point(8, 24);
			txt_title_search.MaxLength = 80;
			txt_title_search.Name = "txt_title_search";
			txt_title_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_title_search.Size = new System.Drawing.Size(235, 19);
			txt_title_search.TabIndex = 330;
			// 
			// _cmd_contact_button_5
			// 
			_cmd_contact_button_5.AllowDrop = true;
			_cmd_contact_button_5.BackColor = System.Drawing.SystemColors.Control;
			_cmd_contact_button_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_contact_button_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_contact_button_5.Location = new System.Drawing.Point(472, 20);
			_cmd_contact_button_5.Name = "_cmd_contact_button_5";
			_cmd_contact_button_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_contact_button_5.Size = new System.Drawing.Size(57, 25);
			_cmd_contact_button_5.TabIndex = 355;
			_cmd_contact_button_5.Text = "Add";
			_cmd_contact_button_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_contact_button_5.UseVisualStyleBackColor = false;
			_cmd_contact_button_5.Click += new System.EventHandler(cmd_contact_button_Click);
			// 
			// _cmd_contact_button_6
			// 
			_cmd_contact_button_6.AllowDrop = true;
			_cmd_contact_button_6.BackColor = System.Drawing.SystemColors.Control;
			_cmd_contact_button_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_contact_button_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_contact_button_6.Location = new System.Drawing.Point(392, 20);
			_cmd_contact_button_6.Name = "_cmd_contact_button_6";
			_cmd_contact_button_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_contact_button_6.Size = new System.Drawing.Size(57, 25);
			_cmd_contact_button_6.TabIndex = 356;
			_cmd_contact_button_6.Text = "Search";
			_cmd_contact_button_6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_contact_button_6.UseVisualStyleBackColor = false;
			_cmd_contact_button_6.Click += new System.EventHandler(cmd_contact_button_Click);
			// 
			// _tab_contact_title_TabPage1
			// 
			_tab_contact_title_TabPage1.Controls.Add(_Label1_50);
			_tab_contact_title_TabPage1.Controls.Add(_Label1_51);
			_tab_contact_title_TabPage1.Controls.Add(_Label1_54);
			_tab_contact_title_TabPage1.Controls.Add(_Label1_53);
			_tab_contact_title_TabPage1.Controls.Add(_lblStopTitleLoad_0);
			_tab_contact_title_TabPage1.Controls.Add(_lblTotTitles_0);
			_tab_contact_title_TabPage1.Controls.Add(_lblTotTitles_1);
			_tab_contact_title_TabPage1.Controls.Add(_txt_contact_title_search_4);
			_tab_contact_title_TabPage1.Controls.Add(_txt_contact_title_search_0);
			_tab_contact_title_TabPage1.Controls.Add(FG_Contact_Title_New);
			_tab_contact_title_TabPage1.Controls.Add(_cmd_contact_button_0);
			_tab_contact_title_TabPage1.Controls.Add(frm_update_frame);
			_tab_contact_title_TabPage1.Controls.Add(cbo_contact_title);
			_tab_contact_title_TabPage1.Controls.Add(grd_titles_in_group);
			_tab_contact_title_TabPage1.Controls.Add(_chk_contact_title_0);
			_tab_contact_title_TabPage1.Controls.Add(_cmd_contact_button_8);
			_tab_contact_title_TabPage1.Controls.Add(frm_update_group);
			_tab_contact_title_TabPage1.Controls.Add(_opt_contact_title_0);
			_tab_contact_title_TabPage1.Controls.Add(_opt_contact_title_1);
			_tab_contact_title_TabPage1.Controls.Add(_opt_contact_title_2);
			_tab_contact_title_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_contact_title_TabPage1.Text = "Contact Title (Automated Index)";
			// 
			// _Label1_50
			// 
			_Label1_50.AllowDrop = true;
			_Label1_50.BackColor = System.Drawing.SystemColors.Control;
			_Label1_50.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_50.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_50.Location = new System.Drawing.Point(24, 12);
			_Label1_50.MinimumSize = new System.Drawing.Size(171, 25);
			_Label1_50.Name = "_Label1_50";
			_Label1_50.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_50.Size = new System.Drawing.Size(171, 25);
			_Label1_50.TabIndex = 358;
			_Label1_50.Text = "Raw Contact Title Search";
			_Label1_50.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_51
			// 
			_Label1_51.AllowDrop = true;
			_Label1_51.BackColor = System.Drawing.SystemColors.Control;
			_Label1_51.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_51.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_51.Location = new System.Drawing.Point(512, 28);
			_Label1_51.MinimumSize = new System.Drawing.Size(91, 17);
			_Label1_51.Name = "_Label1_51";
			_Label1_51.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_51.Size = new System.Drawing.Size(91, 17);
			_Label1_51.TabIndex = 359;
			_Label1_51.Text = "Title Group";
			_Label1_51.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_54
			// 
			_Label1_54.AllowDrop = true;
			_Label1_54.BackColor = System.Drawing.SystemColors.Control;
			_Label1_54.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_54.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_54.Location = new System.Drawing.Point(768, 388);
			_Label1_54.MinimumSize = new System.Drawing.Size(131, 17);
			_Label1_54.Name = "_Label1_54";
			_Label1_54.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_54.Size = new System.Drawing.Size(131, 17);
			_Label1_54.TabIndex = 367;
			_Label1_54.Text = "Contact Counts";
			_Label1_54.Visible = false;
			_Label1_54.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_53
			// 
			_Label1_53.AllowDrop = true;
			_Label1_53.BackColor = System.Drawing.SystemColors.Control;
			_Label1_53.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_53.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_53.Location = new System.Drawing.Point(296, 388);
			_Label1_53.MinimumSize = new System.Drawing.Size(147, 17);
			_Label1_53.Name = "_Label1_53";
			_Label1_53.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_53.Size = new System.Drawing.Size(147, 17);
			_Label1_53.TabIndex = 368;
			_Label1_53.Text = "Contact Counts: ";
			_Label1_53.Visible = false;
			_Label1_53.Click += new System.EventHandler(Label1_Click);
			// 
			// _lblStopTitleLoad_0
			// 
			_lblStopTitleLoad_0.AllowDrop = true;
			_lblStopTitleLoad_0.BackColor = System.Drawing.SystemColors.Control;
			_lblStopTitleLoad_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblStopTitleLoad_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblStopTitleLoad_0.ForeColor = System.Drawing.Color.Blue;
			_lblStopTitleLoad_0.Location = new System.Drawing.Point(440, 404);
			_lblStopTitleLoad_0.MinimumSize = new System.Drawing.Size(77, 15);
			_lblStopTitleLoad_0.Name = "_lblStopTitleLoad_0";
			_lblStopTitleLoad_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblStopTitleLoad_0.Size = new System.Drawing.Size(77, 15);
			_lblStopTitleLoad_0.TabIndex = 369;
			_lblStopTitleLoad_0.Text = "Stop Loading";
			_lblStopTitleLoad_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblStopTitleLoad_0.Visible = false;
			_lblStopTitleLoad_0.Click += new System.EventHandler(lblStopTitleLoad_Click);
			// 
			// _lblTotTitles_0
			// 
			_lblTotTitles_0.AllowDrop = true;
			_lblTotTitles_0.BackColor = System.Drawing.SystemColors.Control;
			_lblTotTitles_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblTotTitles_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblTotTitles_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblTotTitles_0.Location = new System.Drawing.Point(24, 388);
			_lblTotTitles_0.MinimumSize = new System.Drawing.Size(213, 13);
			_lblTotTitles_0.Name = "_lblTotTitles_0";
			_lblTotTitles_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblTotTitles_0.Size = new System.Drawing.Size(213, 13);
			_lblTotTitles_0.TabIndex = 370;
			_lblTotTitles_0.Text = "Unique Contact Titles:";
			_lblTotTitles_0.Visible = false;
			// 
			// _lblTotTitles_1
			// 
			_lblTotTitles_1.AllowDrop = true;
			_lblTotTitles_1.BackColor = System.Drawing.SystemColors.Control;
			_lblTotTitles_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblTotTitles_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblTotTitles_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblTotTitles_1.Location = new System.Drawing.Point(512, 388);
			_lblTotTitles_1.MinimumSize = new System.Drawing.Size(213, 13);
			_lblTotTitles_1.Name = "_lblTotTitles_1";
			_lblTotTitles_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblTotTitles_1.Size = new System.Drawing.Size(213, 13);
			_lblTotTitles_1.TabIndex = 371;
			_lblTotTitles_1.Text = "Unique Contact Titles:";
			_lblTotTitles_1.Visible = false;
			// 
			// _txt_contact_title_search_4
			// 
			_txt_contact_title_search_4.AcceptsReturn = true;
			_txt_contact_title_search_4.AllowDrop = true;
			_txt_contact_title_search_4.BackColor = System.Drawing.SystemColors.Window;
			_txt_contact_title_search_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_contact_title_search_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_contact_title_search_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_contact_title_search_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_contact_title_search_4.Location = new System.Drawing.Point(464, 52);
			_txt_contact_title_search_4.MaxLength = 0;
			_txt_contact_title_search_4.Multiline = true;
			_txt_contact_title_search_4.Name = "_txt_contact_title_search_4";
			_txt_contact_title_search_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_contact_title_search_4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			_txt_contact_title_search_4.Size = new System.Drawing.Size(473, 337);
			_txt_contact_title_search_4.TabIndex = 378;
			_txt_contact_title_search_4.Visible = false;
			// 
			// _txt_contact_title_search_0
			// 
			_txt_contact_title_search_0.AcceptsReturn = true;
			_txt_contact_title_search_0.AllowDrop = true;
			_txt_contact_title_search_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_contact_title_search_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_contact_title_search_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_contact_title_search_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_contact_title_search_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_contact_title_search_0.Location = new System.Drawing.Point(24, 28);
			_txt_contact_title_search_0.MaxLength = 0;
			_txt_contact_title_search_0.Name = "_txt_contact_title_search_0";
			_txt_contact_title_search_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_contact_title_search_0.Size = new System.Drawing.Size(257, 25);
			_txt_contact_title_search_0.TabIndex = 345;
			// 
			// FG_Contact_Title_New
			// 
			FG_Contact_Title_New.AllowDrop = true;
			FG_Contact_Title_New.AllowUserToAddRows = false;
			FG_Contact_Title_New.AllowUserToDeleteRows = false;
			FG_Contact_Title_New.AllowUserToResizeColumns = false;
			FG_Contact_Title_New.AllowUserToResizeRows = false;
			FG_Contact_Title_New.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Contact_Title_New.ColumnsCount = 2;
			FG_Contact_Title_New.FixedColumns = 1;
			FG_Contact_Title_New.FixedRows = 1;
			FG_Contact_Title_New.Location = new System.Drawing.Point(24, 60);
			FG_Contact_Title_New.Name = "FG_Contact_Title_New";
			FG_Contact_Title_New.ReadOnly = true;
			FG_Contact_Title_New.RowsCount = 2;
			FG_Contact_Title_New.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			FG_Contact_Title_New.ShowCellToolTips = false;
			FG_Contact_Title_New.Size = new System.Drawing.Size(425, 321);
			FG_Contact_Title_New.StandardTab = true;
			FG_Contact_Title_New.TabIndex = 346;
			FG_Contact_Title_New.Visible = false;
			FG_Contact_Title_New.Click += new System.EventHandler(FG_Contact_Title_New_Click);
			// 
			// _cmd_contact_button_0
			// 
			_cmd_contact_button_0.AllowDrop = true;
			_cmd_contact_button_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_contact_button_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_contact_button_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_contact_button_0.Location = new System.Drawing.Point(288, 28);
			_cmd_contact_button_0.Name = "_cmd_contact_button_0";
			_cmd_contact_button_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_contact_button_0.Size = new System.Drawing.Size(73, 25);
			_cmd_contact_button_0.TabIndex = 347;
			_cmd_contact_button_0.Text = "Search";
			_cmd_contact_button_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_contact_button_0.UseVisualStyleBackColor = false;
			_cmd_contact_button_0.Click += new System.EventHandler(cmd_contact_button_Click);
			// 
			// frm_update_frame
			// 
			frm_update_frame.AllowDrop = true;
			frm_update_frame.BackColor = System.Drawing.SystemColors.Control;
			frm_update_frame.Controls.Add(_cmd_contact_button_1);
			frm_update_frame.Controls.Add(_txt_contact_title_search_1);
			frm_update_frame.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_update_frame.Enabled = true;
			frm_update_frame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_update_frame.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_update_frame.Location = new System.Drawing.Point(32, 420);
			frm_update_frame.Name = "frm_update_frame";
			frm_update_frame.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_update_frame.Size = new System.Drawing.Size(321, 89);
			frm_update_frame.TabIndex = 348;
			frm_update_frame.Text = "Update";
			frm_update_frame.Visible = false;
			// 
			// _cmd_contact_button_1
			// 
			_cmd_contact_button_1.AllowDrop = true;
			_cmd_contact_button_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_contact_button_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_contact_button_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_contact_button_1.Location = new System.Drawing.Point(208, 16);
			_cmd_contact_button_1.Name = "_cmd_contact_button_1";
			_cmd_contact_button_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_contact_button_1.Size = new System.Drawing.Size(97, 25);
			_cmd_contact_button_1.TabIndex = 350;
			_cmd_contact_button_1.Text = "Update Contacts";
			_cmd_contact_button_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_contact_button_1.UseVisualStyleBackColor = false;
			_cmd_contact_button_1.Click += new System.EventHandler(cmd_contact_button_Click);
			// 
			// _txt_contact_title_search_1
			// 
			_txt_contact_title_search_1.AcceptsReturn = true;
			_txt_contact_title_search_1.AllowDrop = true;
			_txt_contact_title_search_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_contact_title_search_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_contact_title_search_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_contact_title_search_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_contact_title_search_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_contact_title_search_1.Location = new System.Drawing.Point(8, 48);
			_txt_contact_title_search_1.MaxLength = 0;
			_txt_contact_title_search_1.Name = "_txt_contact_title_search_1";
			_txt_contact_title_search_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_contact_title_search_1.Size = new System.Drawing.Size(297, 25);
			_txt_contact_title_search_1.TabIndex = 349;
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
			cbo_contact_title.Location = new System.Drawing.Point(584, 28);
			cbo_contact_title.Name = "cbo_contact_title";
			cbo_contact_title.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact_title.Size = new System.Drawing.Size(313, 21);
			cbo_contact_title.Sorted = false;
			cbo_contact_title.TabIndex = 351;
			cbo_contact_title.TabStop = true;
			cbo_contact_title.Visible = true;
			cbo_contact_title.SelectionChangeCommitted += new System.EventHandler(cbo_contact_title_SelectionChangeCommitted);
			// 
			// grd_titles_in_group
			// 
			grd_titles_in_group.AllowDrop = true;
			grd_titles_in_group.AllowUserToAddRows = false;
			grd_titles_in_group.AllowUserToDeleteRows = false;
			grd_titles_in_group.AllowUserToResizeColumns = false;
			grd_titles_in_group.AllowUserToResizeRows = false;
			grd_titles_in_group.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_titles_in_group.ColumnsCount = 2;
			grd_titles_in_group.FixedColumns = 1;
			grd_titles_in_group.FixedRows = 1;
			grd_titles_in_group.Location = new System.Drawing.Point(512, 60);
			grd_titles_in_group.Name = "grd_titles_in_group";
			grd_titles_in_group.ReadOnly = true;
			grd_titles_in_group.RowsCount = 2;
			grd_titles_in_group.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_titles_in_group.ShowCellToolTips = false;
			grd_titles_in_group.Size = new System.Drawing.Size(385, 321);
			grd_titles_in_group.StandardTab = true;
			grd_titles_in_group.TabIndex = 357;
			grd_titles_in_group.Visible = false;
			grd_titles_in_group.Click += new System.EventHandler(grd_titles_in_group_Click);
			grd_titles_in_group.DoubleClick += new System.EventHandler(grd_titles_in_group_DoubleClick);
			// 
			// _chk_contact_title_0
			// 
			_chk_contact_title_0.AllowDrop = true;
			_chk_contact_title_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_contact_title_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_contact_title_0.CausesValidation = true;
			_chk_contact_title_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_contact_title_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_contact_title_0.Enabled = true;
			_chk_contact_title_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_contact_title_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_contact_title_0.Location = new System.Drawing.Point(368, 28);
			_chk_contact_title_0.Name = "_chk_contact_title_0";
			_chk_contact_title_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_contact_title_0.Size = new System.Drawing.Size(81, 13);
			_chk_contact_title_0.TabIndex = 360;
			_chk_contact_title_0.TabStop = true;
			_chk_contact_title_0.Text = "Not Indexed";
			_chk_contact_title_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_contact_title_0.Visible = true;
			_chk_contact_title_0.CheckStateChanged += new System.EventHandler(chk_contact_title_CheckStateChanged);
			// 
			// _cmd_contact_button_8
			// 
			_cmd_contact_button_8.AllowDrop = true;
			_cmd_contact_button_8.BackColor = System.Drawing.SystemColors.Control;
			_cmd_contact_button_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_contact_button_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_contact_button_8.Location = new System.Drawing.Point(824, 428);
			_cmd_contact_button_8.Name = "_cmd_contact_button_8";
			_cmd_contact_button_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_contact_button_8.Size = new System.Drawing.Size(97, 25);
			_cmd_contact_button_8.TabIndex = 366;
			_cmd_contact_button_8.Text = "Edit Group";
			_cmd_contact_button_8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_contact_button_8.UseVisualStyleBackColor = false;
			_cmd_contact_button_8.Click += new System.EventHandler(cmd_contact_button_Click);
			// 
			// frm_update_group
			// 
			frm_update_group.AllowDrop = true;
			frm_update_group.BackColor = System.Drawing.SystemColors.Control;
			frm_update_group.Controls.Add(_cmd_contact_button_9);
			frm_update_group.Controls.Add(_cmd_contact_button_7);
			frm_update_group.Controls.Add(_txt_contact_title_search_3);
			frm_update_group.Controls.Add(_txt_contact_title_search_2);
			frm_update_group.Controls.Add(_Label1_52);
			frm_update_group.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_update_group.Enabled = true;
			frm_update_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_update_group.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_update_group.Location = new System.Drawing.Point(360, 420);
			frm_update_group.Name = "frm_update_group";
			frm_update_group.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_update_group.Size = new System.Drawing.Size(569, 129);
			frm_update_group.TabIndex = 361;
			frm_update_group.Text = "Update Group";
			frm_update_group.Visible = false;
			// 
			// _cmd_contact_button_9
			// 
			_cmd_contact_button_9.AllowDrop = true;
			_cmd_contact_button_9.BackColor = System.Drawing.SystemColors.Control;
			_cmd_contact_button_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_contact_button_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_contact_button_9.Location = new System.Drawing.Point(352, 16);
			_cmd_contact_button_9.Name = "_cmd_contact_button_9";
			_cmd_contact_button_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_contact_button_9.Size = new System.Drawing.Size(97, 25);
			_cmd_contact_button_9.TabIndex = 377;
			_cmd_contact_button_9.Text = "Expand Group";
			_cmd_contact_button_9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_contact_button_9.UseVisualStyleBackColor = false;
			_cmd_contact_button_9.Click += new System.EventHandler(cmd_contact_button_Click);
			// 
			// _cmd_contact_button_7
			// 
			_cmd_contact_button_7.AllowDrop = true;
			_cmd_contact_button_7.BackColor = System.Drawing.SystemColors.Control;
			_cmd_contact_button_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_contact_button_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_contact_button_7.Location = new System.Drawing.Point(464, 16);
			_cmd_contact_button_7.Name = "_cmd_contact_button_7";
			_cmd_contact_button_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_contact_button_7.Size = new System.Drawing.Size(97, 25);
			_cmd_contact_button_7.TabIndex = 365;
			_cmd_contact_button_7.Text = "Update Group";
			_cmd_contact_button_7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_contact_button_7.UseVisualStyleBackColor = false;
			_cmd_contact_button_7.Click += new System.EventHandler(cmd_contact_button_Click);
			// 
			// _txt_contact_title_search_3
			// 
			_txt_contact_title_search_3.AcceptsReturn = true;
			_txt_contact_title_search_3.AllowDrop = true;
			_txt_contact_title_search_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_contact_title_search_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_contact_title_search_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_contact_title_search_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_contact_title_search_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_contact_title_search_3.Location = new System.Drawing.Point(8, 48);
			_txt_contact_title_search_3.MaxLength = 0;
			_txt_contact_title_search_3.Multiline = true;
			_txt_contact_title_search_3.Name = "_txt_contact_title_search_3";
			_txt_contact_title_search_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_contact_title_search_3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			_txt_contact_title_search_3.Size = new System.Drawing.Size(553, 73);
			_txt_contact_title_search_3.TabIndex = 364;
			// 
			// _txt_contact_title_search_2
			// 
			_txt_contact_title_search_2.AcceptsReturn = true;
			_txt_contact_title_search_2.AllowDrop = true;
			_txt_contact_title_search_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_contact_title_search_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_contact_title_search_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_contact_title_search_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_contact_title_search_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_contact_title_search_2.Location = new System.Drawing.Point(64, 16);
			_txt_contact_title_search_2.MaxLength = 0;
			_txt_contact_title_search_2.Name = "_txt_contact_title_search_2";
			_txt_contact_title_search_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_contact_title_search_2.Size = new System.Drawing.Size(257, 25);
			_txt_contact_title_search_2.TabIndex = 362;
			// 
			// _Label1_52
			// 
			_Label1_52.AllowDrop = true;
			_Label1_52.BackColor = System.Drawing.SystemColors.Control;
			_Label1_52.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_52.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_52.Location = new System.Drawing.Point(8, 24);
			_Label1_52.MinimumSize = new System.Drawing.Size(91, 17);
			_Label1_52.Name = "_Label1_52";
			_Label1_52.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_52.Size = new System.Drawing.Size(91, 17);
			_Label1_52.TabIndex = 363;
			_Label1_52.Text = "Title Group";
			_Label1_52.Click += new System.EventHandler(Label1_Click);
			// 
			// _opt_contact_title_0
			// 
			_opt_contact_title_0.AllowDrop = true;
			_opt_contact_title_0.BackColor = System.Drawing.SystemColors.Control;
			_opt_contact_title_0.CausesValidation = true;
			_opt_contact_title_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_contact_title_0.Checked = true;
			_opt_contact_title_0.Enabled = true;
			_opt_contact_title_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_contact_title_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_contact_title_0.Location = new System.Drawing.Point(512, 4);
			_opt_contact_title_0.Name = "_opt_contact_title_0";
			_opt_contact_title_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_contact_title_0.Size = new System.Drawing.Size(89, 13);
			_opt_contact_title_0.TabIndex = 374;
			_opt_contact_title_0.TabStop = true;
			_opt_contact_title_0.Text = "Indexed";
			_opt_contact_title_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_contact_title_0.Visible = true;
			_opt_contact_title_0.CheckedChanged += new System.EventHandler(opt_contact_title_CheckedChanged);
			// 
			// _opt_contact_title_1
			// 
			_opt_contact_title_1.AllowDrop = true;
			_opt_contact_title_1.BackColor = System.Drawing.SystemColors.Control;
			_opt_contact_title_1.CausesValidation = true;
			_opt_contact_title_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_contact_title_1.Checked = false;
			_opt_contact_title_1.Enabled = true;
			_opt_contact_title_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_contact_title_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_contact_title_1.Location = new System.Drawing.Point(616, 4);
			_opt_contact_title_1.Name = "_opt_contact_title_1";
			_opt_contact_title_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_contact_title_1.Size = new System.Drawing.Size(121, 13);
			_opt_contact_title_1.TabIndex = 375;
			_opt_contact_title_1.TabStop = true;
			_opt_contact_title_1.Text = "In Old Not New";
			_opt_contact_title_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_contact_title_1.Visible = true;
			_opt_contact_title_1.CheckedChanged += new System.EventHandler(opt_contact_title_CheckedChanged);
			// 
			// _opt_contact_title_2
			// 
			_opt_contact_title_2.AllowDrop = true;
			_opt_contact_title_2.BackColor = System.Drawing.SystemColors.Control;
			_opt_contact_title_2.CausesValidation = true;
			_opt_contact_title_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_contact_title_2.Checked = false;
			_opt_contact_title_2.Enabled = true;
			_opt_contact_title_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_contact_title_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_contact_title_2.Location = new System.Drawing.Point(752, 4);
			_opt_contact_title_2.Name = "_opt_contact_title_2";
			_opt_contact_title_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_contact_title_2.Size = new System.Drawing.Size(97, 13);
			_opt_contact_title_2.TabIndex = 376;
			_opt_contact_title_2.TabStop = true;
			_opt_contact_title_2.Text = "In New Not Old";
			_opt_contact_title_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_contact_title_2.Visible = true;
			_opt_contact_title_2.CheckedChanged += new System.EventHandler(opt_contact_title_CheckedChanged);
			// 
			// _tab_Lookup_TabPage9
			// 
			_tab_Lookup_TabPage9.Controls.Add(FG_Phone_Type);
			_tab_Lookup_TabPage9.Controls.Add(cmd_Add_PT);
			_tab_Lookup_TabPage9.Controls.Add(pnl_PT_AddUpdate);
			_tab_Lookup_TabPage9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage9.Text = "Phone Type";
			// 
			// FG_Phone_Type
			// 
			FG_Phone_Type.AllowDrop = true;
			FG_Phone_Type.AllowUserToAddRows = false;
			FG_Phone_Type.AllowUserToDeleteRows = false;
			FG_Phone_Type.AllowUserToResizeColumns = false;
			FG_Phone_Type.AllowUserToResizeRows = false;
			FG_Phone_Type.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Phone_Type.ColumnsCount = 3;
			FG_Phone_Type.FixedColumns = 0;
			FG_Phone_Type.FixedRows = 1;
			FG_Phone_Type.Location = new System.Drawing.Point(31, 26);
			FG_Phone_Type.Name = "FG_Phone_Type";
			FG_Phone_Type.ReadOnly = true;
			FG_Phone_Type.RowsCount = 2;
			FG_Phone_Type.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			FG_Phone_Type.ShowCellToolTips = false;
			FG_Phone_Type.Size = new System.Drawing.Size(277, 388);
			FG_Phone_Type.StandardTab = true;
			FG_Phone_Type.TabIndex = 126;
			FG_Phone_Type.Click += new System.EventHandler(FG_Phone_Type_Click);
			// 
			// cmd_Add_PT
			// 
			cmd_Add_PT.AllowDrop = true;
			cmd_Add_PT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_PT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_PT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_PT.Location = new System.Drawing.Point(339, 27);
			cmd_Add_PT.Name = "cmd_Add_PT";
			cmd_Add_PT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_PT.Size = new System.Drawing.Size(57, 25);
			cmd_Add_PT.TabIndex = 6;
			cmd_Add_PT.Text = "&Add";
			cmd_Add_PT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_PT.UseVisualStyleBackColor = false;
			cmd_Add_PT.Click += new System.EventHandler(cmd_Add_PT_Click);
			// 
			// pnl_PT_AddUpdate
			// 
			pnl_PT_AddUpdate.AllowDrop = true;
			pnl_PT_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_PT_AddUpdate.Controls.Add(_vbCheck_0);
			pnl_PT_AddUpdate.Controls.Add(txt_ptype_abbrev);
			pnl_PT_AddUpdate.Controls.Add(txt_ptype_seq_no);
			pnl_PT_AddUpdate.Controls.Add(cmd_Save_PT);
			pnl_PT_AddUpdate.Controls.Add(cmd_Cancel_PT);
			pnl_PT_AddUpdate.Controls.Add(cmd_Delete_PT);
			pnl_PT_AddUpdate.Controls.Add(txt_ptype_name);
			pnl_PT_AddUpdate.Controls.Add(_Label1_2);
			pnl_PT_AddUpdate.Controls.Add(_Label1_0);
			pnl_PT_AddUpdate.Controls.Add(_Label1_1);
			pnl_PT_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_PT_AddUpdate.Location = new System.Drawing.Point(339, 59);
			pnl_PT_AddUpdate.Name = "pnl_PT_AddUpdate";
			pnl_PT_AddUpdate.Size = new System.Drawing.Size(239, 212);
			pnl_PT_AddUpdate.TabIndex = 81;
			pnl_PT_AddUpdate.Visible = false;
			// 
			// _vbCheck_0
			// 
			_vbCheck_0.AllowDrop = true;
			_vbCheck_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_vbCheck_0.BackColor = System.Drawing.SystemColors.Control;
			_vbCheck_0.CausesValidation = true;
			_vbCheck_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_vbCheck_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_vbCheck_0.Enabled = true;
			_vbCheck_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_vbCheck_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_vbCheck_0.Location = new System.Drawing.Point(75, 118);
			_vbCheck_0.Name = "_vbCheck_0";
			_vbCheck_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_vbCheck_0.Size = new System.Drawing.Size(123, 14);
			_vbCheck_0.TabIndex = 288;
			_vbCheck_0.TabStop = true;
			_vbCheck_0.Text = "Sort By Sequence #";
			_vbCheck_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_vbCheck_0.Visible = true;
			_vbCheck_0.CheckStateChanged += new System.EventHandler(vbCheck_CheckStateChanged);
			// 
			// txt_ptype_abbrev
			// 
			txt_ptype_abbrev.AcceptsReturn = true;
			txt_ptype_abbrev.AllowDrop = true;
			txt_ptype_abbrev.BackColor = System.Drawing.SystemColors.Window;
			txt_ptype_abbrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ptype_abbrev.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ptype_abbrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ptype_abbrev.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ptype_abbrev.Location = new System.Drawing.Point(12, 159);
			txt_ptype_abbrev.MaxLength = 3;
			txt_ptype_abbrev.Name = "txt_ptype_abbrev";
			txt_ptype_abbrev.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ptype_abbrev.Size = new System.Drawing.Size(61, 21);
			txt_ptype_abbrev.TabIndex = 84;
			// 
			// txt_ptype_seq_no
			// 
			txt_ptype_seq_no.AcceptsReturn = true;
			txt_ptype_seq_no.AllowDrop = true;
			txt_ptype_seq_no.BackColor = System.Drawing.SystemColors.Window;
			txt_ptype_seq_no.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ptype_seq_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ptype_seq_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ptype_seq_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ptype_seq_no.Location = new System.Drawing.Point(11, 115);
			txt_ptype_seq_no.MaxLength = 0;
			txt_ptype_seq_no.Name = "txt_ptype_seq_no";
			txt_ptype_seq_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ptype_seq_no.Size = new System.Drawing.Size(59, 19);
			txt_ptype_seq_no.TabIndex = 83;
			// 
			// cmd_Save_PT
			// 
			cmd_Save_PT.AllowDrop = true;
			cmd_Save_PT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_PT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_PT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_PT.Location = new System.Drawing.Point(7, 11);
			cmd_Save_PT.Name = "cmd_Save_PT";
			cmd_Save_PT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_PT.Size = new System.Drawing.Size(57, 25);
			cmd_Save_PT.TabIndex = 87;
			cmd_Save_PT.Text = "&Save";
			cmd_Save_PT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_PT.UseVisualStyleBackColor = false;
			cmd_Save_PT.Click += new System.EventHandler(cmd_Save_PT_Click);
			// 
			// cmd_Cancel_PT
			// 
			cmd_Cancel_PT.AllowDrop = true;
			cmd_Cancel_PT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_PT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_PT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_PT.Location = new System.Drawing.Point(84, 11);
			cmd_Cancel_PT.Name = "cmd_Cancel_PT";
			cmd_Cancel_PT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_PT.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_PT.TabIndex = 86;
			cmd_Cancel_PT.Text = "&Cancel";
			cmd_Cancel_PT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_PT.UseVisualStyleBackColor = false;
			cmd_Cancel_PT.Click += new System.EventHandler(cmd_Cancel_PT_Click);
			// 
			// cmd_Delete_PT
			// 
			cmd_Delete_PT.AllowDrop = true;
			cmd_Delete_PT.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_PT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_PT.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_PT.Location = new System.Drawing.Point(156, 11);
			cmd_Delete_PT.Name = "cmd_Delete_PT";
			cmd_Delete_PT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_PT.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_PT.TabIndex = 85;
			cmd_Delete_PT.Text = "&Delete";
			cmd_Delete_PT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_PT.UseVisualStyleBackColor = false;
			cmd_Delete_PT.Click += new System.EventHandler(cmd_Delete_PT_Click);
			// 
			// txt_ptype_name
			// 
			txt_ptype_name.AcceptsReturn = true;
			txt_ptype_name.AllowDrop = true;
			txt_ptype_name.BackColor = System.Drawing.SystemColors.Window;
			txt_ptype_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ptype_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ptype_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ptype_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ptype_name.Location = new System.Drawing.Point(10, 76);
			txt_ptype_name.MaxLength = 15;
			txt_ptype_name.Name = "txt_ptype_name";
			txt_ptype_name.ReadOnly = true;
			txt_ptype_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ptype_name.Size = new System.Drawing.Size(142, 19);
			txt_ptype_name.TabIndex = 82;
			// 
			// _Label1_2
			// 
			_Label1_2.AllowDrop = true;
			_Label1_2.BackColor = System.Drawing.SystemColors.Control;
			_Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_2.Location = new System.Drawing.Point(10, 139);
			_Label1_2.MinimumSize = new System.Drawing.Size(136, 13);
			_Label1_2.Name = "_Label1_2";
			_Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_2.Size = new System.Drawing.Size(136, 13);
			_Label1_2.TabIndex = 128;
			_Label1_2.Text = "Phone Type Abbreviation";
			_Label1_2.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_0
			// 
			_Label1_0.AllowDrop = true;
			_Label1_0.BackColor = System.Drawing.SystemColors.Control;
			_Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_0.Location = new System.Drawing.Point(11, 97);
			_Label1_0.MinimumSize = new System.Drawing.Size(122, 16);
			_Label1_0.Name = "_Label1_0";
			_Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_0.Size = new System.Drawing.Size(122, 16);
			_Label1_0.TabIndex = 127;
			_Label1_0.Text = "Sequence Number";
			_Label1_0.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_1
			// 
			_Label1_1.AllowDrop = true;
			_Label1_1.BackColor = System.Drawing.SystemColors.Control;
			_Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_1.Location = new System.Drawing.Point(11, 55);
			_Label1_1.MinimumSize = new System.Drawing.Size(141, 17);
			_Label1_1.Name = "_Label1_1";
			_Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_1.Size = new System.Drawing.Size(141, 17);
			_Label1_1.TabIndex = 88;
			_Label1_1.Text = "Phone Type Name";
			_Label1_1.Click += new System.EventHandler(Label1_Click);
			// 
			// _tab_Lookup_TabPage10
			// 
			_tab_Lookup_TabPage10.Controls.Add(pnl_State_AddUpdate);
			_tab_Lookup_TabPage10.Controls.Add(cmd_Add_State);
			_tab_Lookup_TabPage10.Controls.Add(FG_State);
			_tab_Lookup_TabPage10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage10.Text = "State";
			// 
			// pnl_State_AddUpdate
			// 
			pnl_State_AddUpdate.AllowDrop = true;
			pnl_State_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_State_AddUpdate.Controls.Add(state_active_flag);
			pnl_State_AddUpdate.Controls.Add(CMB_State_TimeZone);
			pnl_State_AddUpdate.Controls.Add(cmb_state_country);
			pnl_State_AddUpdate.Controls.Add(cmd_Save_State);
			pnl_State_AddUpdate.Controls.Add(cmd_Cancel_State);
			pnl_State_AddUpdate.Controls.Add(cmd_Delete_State);
			pnl_State_AddUpdate.Controls.Add(txt_state_code);
			pnl_State_AddUpdate.Controls.Add(txt_state_name);
			pnl_State_AddUpdate.Controls.Add(txt_state_loc);
			pnl_State_AddUpdate.Controls.Add(_Label1_7);
			pnl_State_AddUpdate.Controls.Add(_Label1_3);
			pnl_State_AddUpdate.Controls.Add(_Label1_4);
			pnl_State_AddUpdate.Controls.Add(_Label1_5);
			pnl_State_AddUpdate.Controls.Add(_Label1_6);
			pnl_State_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_State_AddUpdate.Location = new System.Drawing.Point(550, 60);
			pnl_State_AddUpdate.Name = "pnl_State_AddUpdate";
			pnl_State_AddUpdate.Size = new System.Drawing.Size(345, 292);
			pnl_State_AddUpdate.TabIndex = 89;
			pnl_State_AddUpdate.Visible = false;
			// 
			// state_active_flag
			// 
			state_active_flag.AllowDrop = true;
			state_active_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			state_active_flag.BackColor = System.Drawing.SystemColors.Control;
			state_active_flag.CausesValidation = true;
			state_active_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			state_active_flag.CheckState = System.Windows.Forms.CheckState.Checked;
			state_active_flag.Enabled = true;
			state_active_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			state_active_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			state_active_flag.Location = new System.Drawing.Point(259, 49);
			state_active_flag.Name = "state_active_flag";
			state_active_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			state_active_flag.Size = new System.Drawing.Size(61, 19);
			state_active_flag.TabIndex = 134;
			state_active_flag.TabStop = true;
			state_active_flag.Text = "Active?";
			state_active_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			state_active_flag.Visible = true;
			state_active_flag.Validating += new System.ComponentModel.CancelEventHandler(state_active_flag_Validating);
			// 
			// CMB_State_TimeZone
			// 
			CMB_State_TimeZone.AllowDrop = true;
			CMB_State_TimeZone.BackColor = System.Drawing.SystemColors.Window;
			CMB_State_TimeZone.CausesValidation = true;
			CMB_State_TimeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			CMB_State_TimeZone.Enabled = true;
			CMB_State_TimeZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			CMB_State_TimeZone.ForeColor = System.Drawing.SystemColors.WindowText;
			CMB_State_TimeZone.IntegralHeight = true;
			CMB_State_TimeZone.Location = new System.Drawing.Point(9, 179);
			CMB_State_TimeZone.Name = "CMB_State_TimeZone";
			CMB_State_TimeZone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			CMB_State_TimeZone.Size = new System.Drawing.Size(223, 21);
			CMB_State_TimeZone.Sorted = false;
			CMB_State_TimeZone.TabIndex = 131;
			CMB_State_TimeZone.TabStop = true;
			CMB_State_TimeZone.Visible = true;
			// 
			// cmb_state_country
			// 
			cmb_state_country.AllowDrop = true;
			cmb_state_country.BackColor = System.Drawing.SystemColors.Window;
			cmb_state_country.CausesValidation = true;
			cmb_state_country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmb_state_country.Enabled = true;
			cmb_state_country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_state_country.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_state_country.IntegralHeight = true;
			cmb_state_country.Location = new System.Drawing.Point(9, 222);
			cmb_state_country.Name = "cmb_state_country";
			cmb_state_country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_state_country.Size = new System.Drawing.Size(154, 21);
			cmb_state_country.Sorted = false;
			cmb_state_country.TabIndex = 96;
			cmb_state_country.TabStop = true;
			cmb_state_country.Visible = true;
			// 
			// cmd_Save_State
			// 
			cmd_Save_State.AllowDrop = true;
			cmd_Save_State.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_State.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_State.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_State.Location = new System.Drawing.Point(19, 4);
			cmd_Save_State.Name = "cmd_Save_State";
			cmd_Save_State.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_State.Size = new System.Drawing.Size(57, 25);
			cmd_Save_State.TabIndex = 95;
			cmd_Save_State.Text = "&Save";
			cmd_Save_State.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_State.UseVisualStyleBackColor = false;
			cmd_Save_State.Click += new System.EventHandler(cmd_Save_State_Click);
			// 
			// cmd_Cancel_State
			// 
			cmd_Cancel_State.AllowDrop = true;
			cmd_Cancel_State.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_State.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_State.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_State.Location = new System.Drawing.Point(94, 6);
			cmd_Cancel_State.Name = "cmd_Cancel_State";
			cmd_Cancel_State.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_State.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_State.TabIndex = 93;
			cmd_Cancel_State.Text = "&Cancel";
			cmd_Cancel_State.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_State.UseVisualStyleBackColor = false;
			cmd_Cancel_State.Click += new System.EventHandler(cmd_Cancel_State_Click);
			// 
			// cmd_Delete_State
			// 
			cmd_Delete_State.AllowDrop = true;
			cmd_Delete_State.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_State.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_State.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_State.Location = new System.Drawing.Point(166, 7);
			cmd_Delete_State.Name = "cmd_Delete_State";
			cmd_Delete_State.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_State.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_State.TabIndex = 91;
			cmd_Delete_State.Text = "&Delete";
			cmd_Delete_State.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_State.UseVisualStyleBackColor = false;
			cmd_Delete_State.Click += new System.EventHandler(cmd_Delete_State_Click);
			// 
			// txt_state_code
			// 
			txt_state_code.AcceptsReturn = true;
			txt_state_code.AllowDrop = true;
			txt_state_code.BackColor = System.Drawing.SystemColors.Window;
			txt_state_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_state_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_state_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_state_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_state_code.Location = new System.Drawing.Point(9, 62);
			txt_state_code.MaxLength = 4;
			txt_state_code.Name = "txt_state_code";
			txt_state_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_state_code.Size = new System.Drawing.Size(41, 19);
			txt_state_code.TabIndex = 90;
			txt_state_code.Leave += new System.EventHandler(txt_state_code_Leave);
			// 
			// txt_state_name
			// 
			txt_state_name.AcceptsReturn = true;
			txt_state_name.AllowDrop = true;
			txt_state_name.BackColor = System.Drawing.SystemColors.Window;
			txt_state_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_state_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_state_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_state_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_state_name.Location = new System.Drawing.Point(9, 102);
			txt_state_name.MaxLength = 30;
			txt_state_name.Name = "txt_state_name";
			txt_state_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_state_name.Size = new System.Drawing.Size(315, 19);
			txt_state_name.TabIndex = 92;
			// 
			// txt_state_loc
			// 
			txt_state_loc.AcceptsReturn = true;
			txt_state_loc.AllowDrop = true;
			txt_state_loc.BackColor = System.Drawing.SystemColors.Window;
			txt_state_loc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_state_loc.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_state_loc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_state_loc.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_state_loc.Location = new System.Drawing.Point(9, 140);
			txt_state_loc.MaxLength = 2;
			txt_state_loc.Name = "txt_state_loc";
			txt_state_loc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_state_loc.Size = new System.Drawing.Size(31, 19);
			txt_state_loc.TabIndex = 94;
			// 
			// _Label1_7
			// 
			_Label1_7.AllowDrop = true;
			_Label1_7.BackColor = System.Drawing.SystemColors.Control;
			_Label1_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_7.Location = new System.Drawing.Point(9, 203);
			_Label1_7.MinimumSize = new System.Drawing.Size(74, 17);
			_Label1_7.Name = "_Label1_7";
			_Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_7.Size = new System.Drawing.Size(74, 17);
			_Label1_7.TabIndex = 130;
			_Label1_7.Text = "Country";
			_Label1_7.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_3
			// 
			_Label1_3.AllowDrop = true;
			_Label1_3.BackColor = System.Drawing.SystemColors.Control;
			_Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_3.Location = new System.Drawing.Point(8, 43);
			_Label1_3.MinimumSize = new System.Drawing.Size(41, 17);
			_Label1_3.Name = "_Label1_3";
			_Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_3.Size = new System.Drawing.Size(41, 17);
			_Label1_3.TabIndex = 100;
			_Label1_3.Text = "Code";
			_Label1_3.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_4
			// 
			_Label1_4.AllowDrop = true;
			_Label1_4.BackColor = System.Drawing.SystemColors.Control;
			_Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_4.Location = new System.Drawing.Point(9, 85);
			_Label1_4.MinimumSize = new System.Drawing.Size(180, 17);
			_Label1_4.Name = "_Label1_4";
			_Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_4.Size = new System.Drawing.Size(180, 17);
			_Label1_4.TabIndex = 99;
			_Label1_4.Text = "Name of State, Province or Region";
			_Label1_4.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_5
			// 
			_Label1_5.AllowDrop = true;
			_Label1_5.BackColor = System.Drawing.SystemColors.Control;
			_Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_5.Location = new System.Drawing.Point(8, 124);
			_Label1_5.MinimumSize = new System.Drawing.Size(55, 17);
			_Label1_5.Name = "_Label1_5";
			_Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_5.Size = new System.Drawing.Size(55, 17);
			_Label1_5.TabIndex = 98;
			_Label1_5.Text = "Location";
			_Label1_5.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_6
			// 
			_Label1_6.AllowDrop = true;
			_Label1_6.BackColor = System.Drawing.SystemColors.Control;
			_Label1_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_6.Location = new System.Drawing.Point(9, 164);
			_Label1_6.MinimumSize = new System.Drawing.Size(65, 17);
			_Label1_6.Name = "_Label1_6";
			_Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_6.Size = new System.Drawing.Size(65, 17);
			_Label1_6.TabIndex = 97;
			_Label1_6.Text = "Time Zone";
			_Label1_6.Click += new System.EventHandler(Label1_Click);
			// 
			// cmd_Add_State
			// 
			cmd_Add_State.AllowDrop = true;
			cmd_Add_State.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_State.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_State.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_State.Location = new System.Drawing.Point(551, 25);
			cmd_Add_State.Name = "cmd_Add_State";
			cmd_Add_State.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_State.Size = new System.Drawing.Size(57, 25);
			cmd_Add_State.TabIndex = 5;
			cmd_Add_State.Text = "&Add";
			cmd_Add_State.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_State.UseVisualStyleBackColor = false;
			cmd_Add_State.Click += new System.EventHandler(cmd_Add_State_Click);
			// 
			// FG_State
			// 
			FG_State.AllowDrop = true;
			FG_State.AllowUserToAddRows = false;
			FG_State.AllowUserToDeleteRows = false;
			FG_State.AllowUserToResizeColumns = false;
			FG_State.AllowUserToResizeRows = false;
			FG_State.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_State.ColumnsCount = 6;
			FG_State.FixedColumns = 0;
			FG_State.FixedRows = 1;
			FG_State.Location = new System.Drawing.Point(23, 33);
			FG_State.Name = "FG_State";
			FG_State.ReadOnly = true;
			FG_State.RowsCount = 2;
			FG_State.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_State.ShowCellToolTips = false;
			FG_State.Size = new System.Drawing.Size(517, 390);
			FG_State.StandardTab = true;
			FG_State.TabIndex = 129;
			FG_State.Click += new System.EventHandler(FG_State_Click);
			// 
			// _tab_Lookup_TabPage11
			// 
			_tab_Lookup_TabPage11.Controls.Add(pnl_TZ_AddUpdate);
			_tab_Lookup_TabPage11.Controls.Add(cmd_Add_TZ);
			_tab_Lookup_TabPage11.Controls.Add(FG_TimeZone);
			_tab_Lookup_TabPage11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage11.Text = "Time Zone";
			// 
			// pnl_TZ_AddUpdate
			// 
			pnl_TZ_AddUpdate.AllowDrop = true;
			pnl_TZ_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_TZ_AddUpdate.Controls.Add(txt_tzone_sort_num);
			pnl_TZ_AddUpdate.Controls.Add(txt_tzone_name);
			pnl_TZ_AddUpdate.Controls.Add(txt_tzone_time_vs_eastern);
			pnl_TZ_AddUpdate.Controls.Add(cmd_Delete_TZ);
			pnl_TZ_AddUpdate.Controls.Add(cmd_Cancel_TZ);
			pnl_TZ_AddUpdate.Controls.Add(cmd_Save_TZ);
			pnl_TZ_AddUpdate.Controls.Add(_Label1_9);
			pnl_TZ_AddUpdate.Controls.Add(_Label1_8);
			pnl_TZ_AddUpdate.Controls.Add(_Label1_10);
			pnl_TZ_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_TZ_AddUpdate.Location = new System.Drawing.Point(332, 68);
			pnl_TZ_AddUpdate.Name = "pnl_TZ_AddUpdate";
			pnl_TZ_AddUpdate.Size = new System.Drawing.Size(257, 208);
			pnl_TZ_AddUpdate.TabIndex = 101;
			pnl_TZ_AddUpdate.Visible = false;
			// 
			// txt_tzone_sort_num
			// 
			txt_tzone_sort_num.AcceptsReturn = true;
			txt_tzone_sort_num.AllowDrop = true;
			txt_tzone_sort_num.BackColor = System.Drawing.SystemColors.Window;
			txt_tzone_sort_num.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tzone_sort_num.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tzone_sort_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tzone_sort_num.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tzone_sort_num.Location = new System.Drawing.Point(12, 112);
			txt_tzone_sort_num.MaxLength = 2;
			txt_tzone_sort_num.Name = "txt_tzone_sort_num";
			txt_tzone_sort_num.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tzone_sort_num.Size = new System.Drawing.Size(31, 19);
			txt_tzone_sort_num.TabIndex = 107;
			// 
			// txt_tzone_name
			// 
			txt_tzone_name.AcceptsReturn = true;
			txt_tzone_name.AllowDrop = true;
			txt_tzone_name.BackColor = System.Drawing.SystemColors.Window;
			txt_tzone_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tzone_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tzone_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tzone_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tzone_name.Location = new System.Drawing.Point(12, 70);
			txt_tzone_name.MaxLength = 10;
			txt_tzone_name.Name = "txt_tzone_name";
			txt_tzone_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tzone_name.Size = new System.Drawing.Size(107, 19);
			txt_tzone_name.TabIndex = 106;
			// 
			// txt_tzone_time_vs_eastern
			// 
			txt_tzone_time_vs_eastern.AcceptsReturn = true;
			txt_tzone_time_vs_eastern.AllowDrop = true;
			txt_tzone_time_vs_eastern.BackColor = System.Drawing.SystemColors.Window;
			txt_tzone_time_vs_eastern.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_tzone_time_vs_eastern.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_tzone_time_vs_eastern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_tzone_time_vs_eastern.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_tzone_time_vs_eastern.Location = new System.Drawing.Point(12, 157);
			txt_tzone_time_vs_eastern.MaxLength = 2;
			txt_tzone_time_vs_eastern.Name = "txt_tzone_time_vs_eastern";
			txt_tzone_time_vs_eastern.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_tzone_time_vs_eastern.Size = new System.Drawing.Size(31, 19);
			txt_tzone_time_vs_eastern.TabIndex = 105;
			// 
			// cmd_Delete_TZ
			// 
			cmd_Delete_TZ.AllowDrop = true;
			cmd_Delete_TZ.BackColor = System.Drawing.SystemColors.Control;
			cmd_Delete_TZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Delete_TZ.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Delete_TZ.Location = new System.Drawing.Point(170, 10);
			cmd_Delete_TZ.Name = "cmd_Delete_TZ";
			cmd_Delete_TZ.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Delete_TZ.Size = new System.Drawing.Size(57, 25);
			cmd_Delete_TZ.TabIndex = 104;
			cmd_Delete_TZ.Text = "&Delete";
			cmd_Delete_TZ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Delete_TZ.UseVisualStyleBackColor = false;
			cmd_Delete_TZ.Click += new System.EventHandler(cmd_Delete_TZ_Click);
			// 
			// cmd_Cancel_TZ
			// 
			cmd_Cancel_TZ.AllowDrop = true;
			cmd_Cancel_TZ.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel_TZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel_TZ.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel_TZ.Location = new System.Drawing.Point(91, 9);
			cmd_Cancel_TZ.Name = "cmd_Cancel_TZ";
			cmd_Cancel_TZ.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel_TZ.Size = new System.Drawing.Size(57, 25);
			cmd_Cancel_TZ.TabIndex = 103;
			cmd_Cancel_TZ.Text = "&Cancel";
			cmd_Cancel_TZ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel_TZ.UseVisualStyleBackColor = false;
			cmd_Cancel_TZ.Click += new System.EventHandler(cmd_Cancel_TZ_Click);
			// 
			// cmd_Save_TZ
			// 
			cmd_Save_TZ.AllowDrop = true;
			cmd_Save_TZ.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_TZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_TZ.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_TZ.Location = new System.Drawing.Point(16, 9);
			cmd_Save_TZ.Name = "cmd_Save_TZ";
			cmd_Save_TZ.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_TZ.Size = new System.Drawing.Size(57, 25);
			cmd_Save_TZ.TabIndex = 102;
			cmd_Save_TZ.Text = "&Save";
			cmd_Save_TZ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_TZ.UseVisualStyleBackColor = false;
			cmd_Save_TZ.Click += new System.EventHandler(cmd_Save_TZ_Click);
			// 
			// _Label1_9
			// 
			_Label1_9.AllowDrop = true;
			_Label1_9.BackColor = System.Drawing.SystemColors.Control;
			_Label1_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_9.Location = new System.Drawing.Point(13, 93);
			_Label1_9.MinimumSize = new System.Drawing.Size(55, 17);
			_Label1_9.Name = "_Label1_9";
			_Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_9.Size = new System.Drawing.Size(55, 17);
			_Label1_9.TabIndex = 110;
			_Label1_9.Text = "Sort Num";
			_Label1_9.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_8
			// 
			_Label1_8.AllowDrop = true;
			_Label1_8.BackColor = System.Drawing.SystemColors.Control;
			_Label1_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_8.Location = new System.Drawing.Point(11, 50);
			_Label1_8.MinimumSize = new System.Drawing.Size(103, 17);
			_Label1_8.Name = "_Label1_8";
			_Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_8.Size = new System.Drawing.Size(103, 17);
			_Label1_8.TabIndex = 109;
			_Label1_8.Text = "Timezone Name";
			_Label1_8.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_10
			// 
			_Label1_10.AllowDrop = true;
			_Label1_10.BackColor = System.Drawing.SystemColors.Control;
			_Label1_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_10.Location = new System.Drawing.Point(12, 137);
			_Label1_10.MinimumSize = new System.Drawing.Size(97, 17);
			_Label1_10.Name = "_Label1_10";
			_Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_10.Size = new System.Drawing.Size(97, 17);
			_Label1_10.TabIndex = 108;
			_Label1_10.Text = "Time vs Eastern";
			_Label1_10.Click += new System.EventHandler(Label1_Click);
			// 
			// cmd_Add_TZ
			// 
			cmd_Add_TZ.AllowDrop = true;
			cmd_Add_TZ.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_TZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_TZ.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_TZ.Location = new System.Drawing.Point(334, 35);
			cmd_Add_TZ.Name = "cmd_Add_TZ";
			cmd_Add_TZ.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_TZ.Size = new System.Drawing.Size(57, 25);
			cmd_Add_TZ.TabIndex = 132;
			cmd_Add_TZ.Text = "&Add";
			cmd_Add_TZ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_TZ.UseVisualStyleBackColor = false;
			cmd_Add_TZ.Click += new System.EventHandler(cmd_Add_TZ_Click);
			// 
			// FG_TimeZone
			// 
			FG_TimeZone.AllowDrop = true;
			FG_TimeZone.AllowUserToAddRows = false;
			FG_TimeZone.AllowUserToDeleteRows = false;
			FG_TimeZone.AllowUserToResizeColumns = false;
			FG_TimeZone.AllowUserToResizeRows = false;
			FG_TimeZone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_TimeZone.ColumnsCount = 3;
			FG_TimeZone.FixedColumns = 0;
			FG_TimeZone.FixedRows = 1;
			FG_TimeZone.Location = new System.Drawing.Point(32, 31);
			FG_TimeZone.Name = "FG_TimeZone";
			FG_TimeZone.ReadOnly = true;
			FG_TimeZone.RowsCount = 2;
			FG_TimeZone.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			FG_TimeZone.ShowCellToolTips = false;
			FG_TimeZone.Size = new System.Drawing.Size(281, 383);
			FG_TimeZone.StandardTab = true;
			FG_TimeZone.TabIndex = 133;
			FG_TimeZone.Click += new System.EventHandler(FG_TimeZone_Click);
			// 
			// _tab_Lookup_TabPage12
			// 
			_tab_Lookup_TabPage12.Controls.Add(FG_FracPrograms);
			_tab_Lookup_TabPage12.Controls.Add(pnl_add_frac_Program);
			_tab_Lookup_TabPage12.Controls.Add(cmd_add_fracPG);
			_tab_Lookup_TabPage12.Controls.Add(cmdFracRefresh);
			_tab_Lookup_TabPage12.Controls.Add(cmdFracMerge);
			_tab_Lookup_TabPage12.Controls.Add(pnl_Merge_Frac_Programs);
			_tab_Lookup_TabPage12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage12.Text = "Fractional Programs";
			// 
			// FG_FracPrograms
			// 
			FG_FracPrograms.AllowDrop = true;
			FG_FracPrograms.AllowUserToAddRows = false;
			FG_FracPrograms.AllowUserToDeleteRows = false;
			FG_FracPrograms.AllowUserToResizeColumns = false;
			FG_FracPrograms.AllowUserToResizeColumns = FG_FracPrograms.ColumnHeadersVisible;
			FG_FracPrograms.AllowUserToResizeRows = false;
			FG_FracPrograms.AllowUserToResizeRows = false;
			FG_FracPrograms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_FracPrograms.ColumnsCount = 8;
			FG_FracPrograms.FixedColumns = 0;
			FG_FracPrograms.FixedRows = 1;
			FG_FracPrograms.Location = new System.Drawing.Point(16, 28);
			FG_FracPrograms.Name = "FG_FracPrograms";
			FG_FracPrograms.ReadOnly = true;
			FG_FracPrograms.RowsCount = 2;
			FG_FracPrograms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_FracPrograms.ShowCellToolTips = false;
			FG_FracPrograms.Size = new System.Drawing.Size(601, 355);
			FG_FracPrograms.StandardTab = true;
			FG_FracPrograms.TabIndex = 135;
			FG_FracPrograms.Click += new System.EventHandler(FG_FracPrograms_Click);
			// 
			// pnl_add_frac_Program
			// 
			pnl_add_frac_Program.AllowDrop = true;
			pnl_add_frac_Program.BackColor = System.Drawing.SystemColors.Control;
			pnl_add_frac_Program.Controls.Add(txt_FracProgramProvider);
			pnl_add_frac_Program.Controls.Add(txt_FracCompID);
			pnl_add_frac_Program.Controls.Add(txtFracProg_id);
			pnl_add_frac_Program.Controls.Add(txt_fracPG_code);
			pnl_add_frac_Program.Controls.Add(txt_fracPG_desc);
			pnl_add_frac_Program.Controls.Add(txt_FracPG_name);
			pnl_add_frac_Program.Controls.Add(chk_major_fracPG);
			pnl_add_frac_Program.Controls.Add(chk_active_fracpg);
			pnl_add_frac_Program.Controls.Add(cmd_save_frac_PG);
			pnl_add_frac_Program.Controls.Add(cmd_cancel_FracPG);
			pnl_add_frac_Program.Controls.Add(cmd_delete_fracPG);
			pnl_add_frac_Program.Controls.Add(_Label17_7);
			pnl_add_frac_Program.Controls.Add(_Label17_4);
			pnl_add_frac_Program.Controls.Add(_Label17_3);
			pnl_add_frac_Program.Controls.Add(_Label17_2);
			pnl_add_frac_Program.Controls.Add(_Label17_1);
			pnl_add_frac_Program.Controls.Add(_Label17_0);
			pnl_add_frac_Program.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			pnl_add_frac_Program.Enabled = true;
			pnl_add_frac_Program.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_add_frac_Program.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_add_frac_Program.Location = new System.Drawing.Point(624, 52);
			pnl_add_frac_Program.Name = "pnl_add_frac_Program";
			pnl_add_frac_Program.RightToLeft = System.Windows.Forms.RightToLeft.No;
			pnl_add_frac_Program.Size = new System.Drawing.Size(331, 218);
			pnl_add_frac_Program.TabIndex = 136;
			pnl_add_frac_Program.Visible = true;
			// 
			// txt_FracProgramProvider
			// 
			txt_FracProgramProvider.AcceptsReturn = true;
			txt_FracProgramProvider.AllowDrop = true;
			txt_FracProgramProvider.BackColor = System.Drawing.SystemColors.Window;
			txt_FracProgramProvider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_FracProgramProvider.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_FracProgramProvider.Enabled = false;
			txt_FracProgramProvider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_FracProgramProvider.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_FracProgramProvider.Location = new System.Drawing.Point(176, 168);
			txt_FracProgramProvider.MaxLength = 0;
			txt_FracProgramProvider.Name = "txt_FracProgramProvider";
			txt_FracProgramProvider.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_FracProgramProvider.Size = new System.Drawing.Size(145, 19);
			txt_FracProgramProvider.TabIndex = 259;
			// 
			// txt_FracCompID
			// 
			txt_FracCompID.AcceptsReturn = true;
			txt_FracCompID.AllowDrop = true;
			txt_FracCompID.BackColor = System.Drawing.SystemColors.Window;
			txt_FracCompID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_FracCompID.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_FracCompID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_FracCompID.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_FracCompID.Location = new System.Drawing.Point(176, 143);
			txt_FracCompID.MaxLength = 0;
			txt_FracCompID.Name = "txt_FracCompID";
			txt_FracCompID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_FracCompID.Size = new System.Drawing.Size(65, 19);
			txt_FracCompID.TabIndex = 176;
			// 
			// txtFracProg_id
			// 
			txtFracProg_id.AcceptsReturn = true;
			txtFracProg_id.AllowDrop = true;
			txtFracProg_id.BackColor = System.Drawing.SystemColors.Window;
			txtFracProg_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtFracProg_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtFracProg_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtFracProg_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txtFracProg_id.Location = new System.Drawing.Point(245, 109);
			txtFracProg_id.MaxLength = 0;
			txtFracProg_id.Name = "txtFracProg_id";
			txtFracProg_id.ReadOnly = true;
			txtFracProg_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtFracProg_id.Size = new System.Drawing.Size(65, 21);
			txtFracProg_id.TabIndex = 167;
			// 
			// txt_fracPG_code
			// 
			txt_fracPG_code.AcceptsReturn = true;
			txt_fracPG_code.AllowDrop = true;
			txt_fracPG_code.BackColor = System.Drawing.SystemColors.Window;
			txt_fracPG_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_fracPG_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_fracPG_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_fracPG_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_fracPG_code.Location = new System.Drawing.Point(98, 112);
			txt_fracPG_code.MaxLength = 0;
			txt_fracPG_code.Name = "txt_fracPG_code";
			txt_fracPG_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_fracPG_code.Size = new System.Drawing.Size(60, 19);
			txt_fracPG_code.TabIndex = 148;
			// 
			// txt_fracPG_desc
			// 
			txt_fracPG_desc.AcceptsReturn = true;
			txt_fracPG_desc.AllowDrop = true;
			txt_fracPG_desc.BackColor = System.Drawing.SystemColors.Window;
			txt_fracPG_desc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_fracPG_desc.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_fracPG_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_fracPG_desc.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_fracPG_desc.Location = new System.Drawing.Point(104, 85);
			txt_fracPG_desc.MaxLength = 0;
			txt_fracPG_desc.Name = "txt_fracPG_desc";
			txt_fracPG_desc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_fracPG_desc.Size = new System.Drawing.Size(222, 19);
			txt_fracPG_desc.TabIndex = 147;
			// 
			// txt_FracPG_name
			// 
			txt_FracPG_name.AcceptsReturn = true;
			txt_FracPG_name.AllowDrop = true;
			txt_FracPG_name.BackColor = System.Drawing.SystemColors.Window;
			txt_FracPG_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_FracPG_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_FracPG_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_FracPG_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_FracPG_name.Location = new System.Drawing.Point(104, 56);
			txt_FracPG_name.MaxLength = 0;
			txt_FracPG_name.Name = "txt_FracPG_name";
			txt_FracPG_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_FracPG_name.Size = new System.Drawing.Size(223, 22);
			txt_FracPG_name.TabIndex = 146;
			txt_FracPG_name.Leave += new System.EventHandler(txt_FracPG_name_Leave);
			// 
			// chk_major_fracPG
			// 
			chk_major_fracPG.AllowDrop = true;
			chk_major_fracPG.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_major_fracPG.BackColor = System.Drawing.SystemColors.Control;
			chk_major_fracPG.CausesValidation = true;
			chk_major_fracPG.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_major_fracPG.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_major_fracPG.Enabled = true;
			chk_major_fracPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_major_fracPG.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_major_fracPG.Location = new System.Drawing.Point(78, 191);
			chk_major_fracPG.Name = "chk_major_fracPG";
			chk_major_fracPG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_major_fracPG.Size = new System.Drawing.Size(112, 21);
			chk_major_fracPG.TabIndex = 145;
			chk_major_fracPG.TabStop = true;
			chk_major_fracPG.Text = "Major Program?";
			chk_major_fracPG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_major_fracPG.Visible = true;
			// 
			// chk_active_fracpg
			// 
			chk_active_fracpg.AllowDrop = true;
			chk_active_fracpg.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_active_fracpg.BackColor = System.Drawing.SystemColors.Control;
			chk_active_fracpg.CausesValidation = true;
			chk_active_fracpg.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_active_fracpg.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_active_fracpg.Enabled = true;
			chk_active_fracpg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_active_fracpg.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_active_fracpg.Location = new System.Drawing.Point(10, 191);
			chk_active_fracpg.Name = "chk_active_fracpg";
			chk_active_fracpg.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_active_fracpg.Size = new System.Drawing.Size(65, 21);
			chk_active_fracpg.TabIndex = 144;
			chk_active_fracpg.TabStop = true;
			chk_active_fracpg.Text = "Active?";
			chk_active_fracpg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_active_fracpg.Visible = true;
			// 
			// cmd_save_frac_PG
			// 
			cmd_save_frac_PG.AllowDrop = true;
			cmd_save_frac_PG.BackColor = System.Drawing.SystemColors.Control;
			cmd_save_frac_PG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_save_frac_PG.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_save_frac_PG.Location = new System.Drawing.Point(12, 16);
			cmd_save_frac_PG.Name = "cmd_save_frac_PG";
			cmd_save_frac_PG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_save_frac_PG.Size = new System.Drawing.Size(57, 25);
			cmd_save_frac_PG.TabIndex = 139;
			cmd_save_frac_PG.Text = "&Save";
			cmd_save_frac_PG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_save_frac_PG.UseVisualStyleBackColor = false;
			cmd_save_frac_PG.Click += new System.EventHandler(cmd_save_frac_PG_Click);
			// 
			// cmd_cancel_FracPG
			// 
			cmd_cancel_FracPG.AllowDrop = true;
			cmd_cancel_FracPG.BackColor = System.Drawing.SystemColors.Control;
			cmd_cancel_FracPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_cancel_FracPG.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_cancel_FracPG.Location = new System.Drawing.Point(86, 17);
			cmd_cancel_FracPG.Name = "cmd_cancel_FracPG";
			cmd_cancel_FracPG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_cancel_FracPG.Size = new System.Drawing.Size(57, 25);
			cmd_cancel_FracPG.TabIndex = 138;
			cmd_cancel_FracPG.Text = "&Cancel";
			cmd_cancel_FracPG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_cancel_FracPG.UseVisualStyleBackColor = false;
			cmd_cancel_FracPG.Click += new System.EventHandler(cmd_cancel_FracPG_Click);
			// 
			// cmd_delete_fracPG
			// 
			cmd_delete_fracPG.AllowDrop = true;
			cmd_delete_fracPG.BackColor = System.Drawing.SystemColors.Control;
			cmd_delete_fracPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_delete_fracPG.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_delete_fracPG.Location = new System.Drawing.Point(160, 15);
			cmd_delete_fracPG.Name = "cmd_delete_fracPG";
			cmd_delete_fracPG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_delete_fracPG.Size = new System.Drawing.Size(57, 25);
			cmd_delete_fracPG.TabIndex = 137;
			cmd_delete_fracPG.Text = "&Delete";
			cmd_delete_fracPG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_delete_fracPG.UseVisualStyleBackColor = false;
			cmd_delete_fracPG.Click += new System.EventHandler(cmd_delete_fracPG_Click);
			// 
			// _Label17_7
			// 
			_Label17_7.AllowDrop = true;
			_Label17_7.BackColor = System.Drawing.SystemColors.Control;
			_Label17_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_7.Location = new System.Drawing.Point(8, 168);
			_Label17_7.MinimumSize = new System.Drawing.Size(157, 20);
			_Label17_7.Name = "_Label17_7";
			_Label17_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_7.Size = new System.Drawing.Size(157, 20);
			_Label17_7.TabIndex = 258;
			_Label17_7.Text = "Program Provider:";
			// 
			// _Label17_4
			// 
			_Label17_4.AllowDrop = true;
			_Label17_4.BackColor = System.Drawing.SystemColors.Control;
			_Label17_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_4.Location = new System.Drawing.Point(9, 144);
			_Label17_4.MinimumSize = new System.Drawing.Size(157, 20);
			_Label17_4.Name = "_Label17_4";
			_Label17_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_4.Size = new System.Drawing.Size(157, 20);
			_Label17_4.TabIndex = 175;
			_Label17_4.Text = "Company ID of Primary Company:";
			// 
			// _Label17_3
			// 
			_Label17_3.AllowDrop = true;
			_Label17_3.BackColor = System.Drawing.SystemColors.Control;
			_Label17_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_3.Location = new System.Drawing.Point(170, 113);
			_Label17_3.MinimumSize = new System.Drawing.Size(65, 18);
			_Label17_3.Name = "_Label17_3";
			_Label17_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_3.Size = new System.Drawing.Size(65, 18);
			_Label17_3.TabIndex = 168;
			_Label17_3.Text = "Program ID";
			// 
			// _Label17_2
			// 
			_Label17_2.AllowDrop = true;
			_Label17_2.BackColor = System.Drawing.SystemColors.Control;
			_Label17_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_2.Location = new System.Drawing.Point(11, 113);
			_Label17_2.MinimumSize = new System.Drawing.Size(89, 21);
			_Label17_2.Name = "_Label17_2";
			_Label17_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_2.Size = new System.Drawing.Size(89, 21);
			_Label17_2.TabIndex = 143;
			_Label17_2.Text = "Program Code";
			// 
			// _Label17_1
			// 
			_Label17_1.AllowDrop = true;
			_Label17_1.BackColor = System.Drawing.SystemColors.Control;
			_Label17_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_1.Location = new System.Drawing.Point(9, 83);
			_Label17_1.MinimumSize = new System.Drawing.Size(120, 17);
			_Label17_1.Name = "_Label17_1";
			_Label17_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_1.Size = new System.Drawing.Size(120, 17);
			_Label17_1.TabIndex = 142;
			_Label17_1.Text = "Description";
			// 
			// _Label17_0
			// 
			_Label17_0.AllowDrop = true;
			_Label17_0.BackColor = System.Drawing.SystemColors.Control;
			_Label17_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_0.Location = new System.Drawing.Point(8, 55);
			_Label17_0.MinimumSize = new System.Drawing.Size(93, 19);
			_Label17_0.Name = "_Label17_0";
			_Label17_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_0.Size = new System.Drawing.Size(93, 19);
			_Label17_0.TabIndex = 141;
			_Label17_0.Text = "Fractional Program";
			// 
			// cmd_add_fracPG
			// 
			cmd_add_fracPG.AllowDrop = true;
			cmd_add_fracPG.BackColor = System.Drawing.SystemColors.Control;
			cmd_add_fracPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_add_fracPG.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_add_fracPG.Location = new System.Drawing.Point(632, 19);
			cmd_add_fracPG.Name = "cmd_add_fracPG";
			cmd_add_fracPG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_add_fracPG.Size = new System.Drawing.Size(57, 25);
			cmd_add_fracPG.TabIndex = 140;
			cmd_add_fracPG.Text = "&Add";
			cmd_add_fracPG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_add_fracPG.UseVisualStyleBackColor = false;
			cmd_add_fracPG.Click += new System.EventHandler(cmd_add_fracPG_Click);
			// 
			// cmdFracRefresh
			// 
			cmdFracRefresh.AllowDrop = true;
			cmdFracRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdFracRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFracRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFracRefresh.Location = new System.Drawing.Point(744, 20);
			cmdFracRefresh.Name = "cmdFracRefresh";
			cmdFracRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFracRefresh.Size = new System.Drawing.Size(53, 23);
			cmdFracRefresh.TabIndex = 177;
			cmdFracRefresh.Text = "Refresh";
			cmdFracRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFracRefresh.UseVisualStyleBackColor = false;
			cmdFracRefresh.Click += new System.EventHandler(cmdFracRefresh_Click);
			// 
			// cmdFracMerge
			// 
			cmdFracMerge.AllowDrop = true;
			cmdFracMerge.BackColor = System.Drawing.SystemColors.Control;
			cmdFracMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFracMerge.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFracMerge.Location = new System.Drawing.Point(840, 21);
			cmdFracMerge.Name = "cmdFracMerge";
			cmdFracMerge.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFracMerge.Size = new System.Drawing.Size(56, 22);
			cmdFracMerge.TabIndex = 179;
			cmdFracMerge.Text = "Merge";
			cmdFracMerge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFracMerge.UseVisualStyleBackColor = false;
			cmdFracMerge.Click += new System.EventHandler(cmdFracMerge_Click);
			// 
			// pnl_Merge_Frac_Programs
			// 
			pnl_Merge_Frac_Programs.AllowDrop = true;
			pnl_Merge_Frac_Programs.BackColor = System.Drawing.SystemColors.Control;
			pnl_Merge_Frac_Programs.Controls.Add(cboFracToRemove);
			pnl_Merge_Frac_Programs.Controls.Add(cboFracToKeep);
			pnl_Merge_Frac_Programs.Controls.Add(cmdCancelMerge);
			pnl_Merge_Frac_Programs.Controls.Add(cmdMergeFractionals);
			pnl_Merge_Frac_Programs.Controls.Add(_Label17_6);
			pnl_Merge_Frac_Programs.Controls.Add(_Label17_5);
			pnl_Merge_Frac_Programs.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			pnl_Merge_Frac_Programs.Enabled = true;
			pnl_Merge_Frac_Programs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Merge_Frac_Programs.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_Merge_Frac_Programs.Location = new System.Drawing.Point(627, 276);
			pnl_Merge_Frac_Programs.Name = "pnl_Merge_Frac_Programs";
			pnl_Merge_Frac_Programs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			pnl_Merge_Frac_Programs.Size = new System.Drawing.Size(323, 143);
			pnl_Merge_Frac_Programs.TabIndex = 180;
			pnl_Merge_Frac_Programs.Text = "Merge Fractional Programs";
			pnl_Merge_Frac_Programs.Visible = false;
			// 
			// cboFracToRemove
			// 
			cboFracToRemove.AllowDrop = true;
			cboFracToRemove.BackColor = System.Drawing.SystemColors.Window;
			cboFracToRemove.CausesValidation = true;
			cboFracToRemove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboFracToRemove.Enabled = true;
			cboFracToRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboFracToRemove.ForeColor = System.Drawing.SystemColors.WindowText;
			cboFracToRemove.IntegralHeight = true;
			cboFracToRemove.Location = new System.Drawing.Point(11, 82);
			cboFracToRemove.Name = "cboFracToRemove";
			cboFracToRemove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboFracToRemove.Size = new System.Drawing.Size(264, 21);
			cboFracToRemove.Sorted = false;
			cboFracToRemove.TabIndex = 186;
			cboFracToRemove.TabStop = true;
			cboFracToRemove.Visible = true;
			// 
			// cboFracToKeep
			// 
			cboFracToKeep.AllowDrop = true;
			cboFracToKeep.BackColor = System.Drawing.SystemColors.Window;
			cboFracToKeep.CausesValidation = true;
			cboFracToKeep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboFracToKeep.Enabled = true;
			cboFracToKeep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboFracToKeep.ForeColor = System.Drawing.SystemColors.WindowText;
			cboFracToKeep.IntegralHeight = true;
			cboFracToKeep.Location = new System.Drawing.Point(10, 43);
			cboFracToKeep.Name = "cboFracToKeep";
			cboFracToKeep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboFracToKeep.Size = new System.Drawing.Size(268, 21);
			cboFracToKeep.Sorted = false;
			cboFracToKeep.TabIndex = 185;
			cboFracToKeep.TabStop = true;
			cboFracToKeep.Visible = true;
			// 
			// cmdCancelMerge
			// 
			cmdCancelMerge.AllowDrop = true;
			cmdCancelMerge.BackColor = System.Drawing.SystemColors.Control;
			cmdCancelMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancelMerge.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancelMerge.Location = new System.Drawing.Point(117, 112);
			cmdCancelMerge.Name = "cmdCancelMerge";
			cmdCancelMerge.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancelMerge.Size = new System.Drawing.Size(50, 22);
			cmdCancelMerge.TabIndex = 184;
			cmdCancelMerge.Text = "Cancel";
			cmdCancelMerge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancelMerge.UseVisualStyleBackColor = false;
			cmdCancelMerge.Click += new System.EventHandler(cmdCancelMerge_Click);
			// 
			// cmdMergeFractionals
			// 
			cmdMergeFractionals.AllowDrop = true;
			cmdMergeFractionals.BackColor = System.Drawing.SystemColors.Control;
			cmdMergeFractionals.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdMergeFractionals.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdMergeFractionals.Location = new System.Drawing.Point(25, 111);
			cmdMergeFractionals.Name = "cmdMergeFractionals";
			cmdMergeFractionals.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdMergeFractionals.Size = new System.Drawing.Size(55, 21);
			cmdMergeFractionals.TabIndex = 183;
			cmdMergeFractionals.Text = "Merge";
			cmdMergeFractionals.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdMergeFractionals.UseVisualStyleBackColor = false;
			cmdMergeFractionals.Click += new System.EventHandler(cmdMergeFractionals_Click);
			// 
			// _Label17_6
			// 
			_Label17_6.AllowDrop = true;
			_Label17_6.BackColor = System.Drawing.SystemColors.Control;
			_Label17_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_6.Location = new System.Drawing.Point(10, 66);
			_Label17_6.MinimumSize = new System.Drawing.Size(115, 19);
			_Label17_6.Name = "_Label17_6";
			_Label17_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_6.Size = new System.Drawing.Size(115, 19);
			_Label17_6.TabIndex = 182;
			_Label17_6.Text = "Program to Remove:";
			// 
			// _Label17_5
			// 
			_Label17_5.AllowDrop = true;
			_Label17_5.BackColor = System.Drawing.SystemColors.Control;
			_Label17_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label17_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label17_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label17_5.Location = new System.Drawing.Point(10, 25);
			_Label17_5.MinimumSize = new System.Drawing.Size(144, 19);
			_Label17_5.Name = "_Label17_5";
			_Label17_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label17_5.Size = new System.Drawing.Size(144, 19);
			_Label17_5.TabIndex = 181;
			_Label17_5.Text = "Program Name to Keep:";
			// 
			// _tab_Lookup_TabPage13
			// 
			_tab_Lookup_TabPage13.Controls.Add(cmd_FindProgram);
			_tab_Lookup_TabPage13.Controls.Add(txt_find_Comp_id);
			_tab_Lookup_TabPage13.Controls.Add(pnl_new_FracMember);
			_tab_Lookup_TabPage13.Controls.Add(pnl_add_fracMember);
			_tab_Lookup_TabPage13.Controls.Add(cmdAddFracMember);
			_tab_Lookup_TabPage13.Controls.Add(cmdFracProgram);
			_tab_Lookup_TabPage13.Controls.Add(FG_ProgCompany);
			_tab_Lookup_TabPage13.Controls.Add(_Label43_1);
			_tab_Lookup_TabPage13.Controls.Add(_Shape1_1);
			_tab_Lookup_TabPage13.Controls.Add(_Label43_0);
			_tab_Lookup_TabPage13.Controls.Add(Label40);
			_tab_Lookup_TabPage13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage13.Text = "Frac Program Members";
			// 
			// cmd_FindProgram
			// 
			cmd_FindProgram.AllowDrop = true;
			cmd_FindProgram.BackColor = System.Drawing.SystemColors.Control;
			cmd_FindProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_FindProgram.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_FindProgram.Location = new System.Drawing.Point(735, 33);
			cmd_FindProgram.Name = "cmd_FindProgram";
			cmd_FindProgram.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_FindProgram.Size = new System.Drawing.Size(73, 20);
			cmd_FindProgram.TabIndex = 264;
			cmd_FindProgram.Text = "Find Progam";
			cmd_FindProgram.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_FindProgram.UseVisualStyleBackColor = false;
			cmd_FindProgram.Click += new System.EventHandler(cmd_FindProgram_Click);
			// 
			// txt_find_Comp_id
			// 
			txt_find_Comp_id.AcceptsReturn = true;
			txt_find_Comp_id.AllowDrop = true;
			txt_find_Comp_id.BackColor = System.Drawing.SystemColors.Window;
			txt_find_Comp_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_find_Comp_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_find_Comp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_find_Comp_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_find_Comp_id.Location = new System.Drawing.Point(668, 32);
			txt_find_Comp_id.MaxLength = 0;
			txt_find_Comp_id.Name = "txt_find_Comp_id";
			txt_find_Comp_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_find_Comp_id.Size = new System.Drawing.Size(63, 21);
			txt_find_Comp_id.TabIndex = 263;
			// 
			// pnl_new_FracMember
			// 
			pnl_new_FracMember.AllowDrop = true;
			pnl_new_FracMember.BackColor = System.Drawing.SystemColors.Control;
			pnl_new_FracMember.Controls.Add(chk_FracHistory);
			pnl_new_FracMember.Controls.Add(txtmSearchNumber);
			pnl_new_FracMember.Controls.Add(cmdStopFrac);
			pnl_new_FracMember.Controls.Add(cmdFracMemSearchCancel);
			pnl_new_FracMember.Controls.Add(txtmsearchname);
			pnl_new_FracMember.Controls.Add(cmdMemSearch);
			pnl_new_FracMember.Controls.Add(grdMemSearch);
			pnl_new_FracMember.Controls.Add(_Label1_17);
			pnl_new_FracMember.Controls.Add(_Label1_16);
			pnl_new_FracMember.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			pnl_new_FracMember.Enabled = true;
			pnl_new_FracMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_new_FracMember.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_new_FracMember.Location = new System.Drawing.Point(377, 59);
			pnl_new_FracMember.Name = "pnl_new_FracMember";
			pnl_new_FracMember.RightToLeft = System.Windows.Forms.RightToLeft.No;
			pnl_new_FracMember.Size = new System.Drawing.Size(576, 224);
			pnl_new_FracMember.TabIndex = 161;
			pnl_new_FracMember.Text = "New Member Search";
			pnl_new_FracMember.Visible = false;
			// 
			// chk_FracHistory
			// 
			chk_FracHistory.AllowDrop = true;
			chk_FracHistory.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_FracHistory.BackColor = System.Drawing.SystemColors.Control;
			chk_FracHistory.CausesValidation = true;
			chk_FracHistory.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_FracHistory.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_FracHistory.Enabled = true;
			chk_FracHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_FracHistory.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_FracHistory.Location = new System.Drawing.Point(270, 41);
			chk_FracHistory.Name = "chk_FracHistory";
			chk_FracHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_FracHistory.Size = new System.Drawing.Size(125, 17);
			chk_FracHistory.TabIndex = 178;
			chk_FracHistory.TabStop = true;
			chk_FracHistory.Text = "Search Historical?";
			chk_FracHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_FracHistory.Visible = true;
			// 
			// txtmSearchNumber
			// 
			txtmSearchNumber.AcceptsReturn = true;
			txtmSearchNumber.AllowDrop = true;
			txtmSearchNumber.BackColor = System.Drawing.SystemColors.Window;
			txtmSearchNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtmSearchNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtmSearchNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtmSearchNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			txtmSearchNumber.Location = new System.Drawing.Point(136, 39);
			txtmSearchNumber.MaxLength = 0;
			txtmSearchNumber.Name = "txtmSearchNumber";
			txtmSearchNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtmSearchNumber.Size = new System.Drawing.Size(117, 20);
			txtmSearchNumber.TabIndex = 174;
			txtmSearchNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtmSearchNumber_KeyPress);
			// 
			// cmdStopFrac
			// 
			cmdStopFrac.AllowDrop = true;
			cmdStopFrac.BackColor = System.Drawing.SystemColors.Control;
			cmdStopFrac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdStopFrac.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdStopFrac.Location = new System.Drawing.Point(394, 15);
			cmdStopFrac.Name = "cmdStopFrac";
			cmdStopFrac.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdStopFrac.Size = new System.Drawing.Size(47, 20);
			cmdStopFrac.TabIndex = 171;
			cmdStopFrac.Text = "Stop";
			cmdStopFrac.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdStopFrac.UseVisualStyleBackColor = false;
			cmdStopFrac.Click += new System.EventHandler(cmdStopFrac_Click);
			// 
			// cmdFracMemSearchCancel
			// 
			cmdFracMemSearchCancel.AllowDrop = true;
			cmdFracMemSearchCancel.BackColor = System.Drawing.SystemColors.Control;
			cmdFracMemSearchCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFracMemSearchCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFracMemSearchCancel.Location = new System.Drawing.Point(13, 13);
			cmdFracMemSearchCancel.Name = "cmdFracMemSearchCancel";
			cmdFracMemSearchCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFracMemSearchCancel.Size = new System.Drawing.Size(57, 22);
			cmdFracMemSearchCancel.TabIndex = 166;
			cmdFracMemSearchCancel.Text = "&Cancel";
			cmdFracMemSearchCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFracMemSearchCancel.UseVisualStyleBackColor = false;
			cmdFracMemSearchCancel.Click += new System.EventHandler(cmdFracMemSearchCancel_Click);
			// 
			// txtmsearchname
			// 
			txtmsearchname.AcceptsReturn = true;
			txtmsearchname.AllowDrop = true;
			txtmsearchname.BackColor = System.Drawing.SystemColors.Window;
			txtmsearchname.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtmsearchname.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtmsearchname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtmsearchname.ForeColor = System.Drawing.SystemColors.WindowText;
			txtmsearchname.Location = new System.Drawing.Point(136, 14);
			txtmsearchname.MaxLength = 0;
			txtmsearchname.Name = "txtmsearchname";
			txtmsearchname.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtmsearchname.Size = new System.Drawing.Size(189, 23);
			txtmsearchname.TabIndex = 164;
			txtmsearchname.KeyDown += new System.Windows.Forms.KeyEventHandler(txtmsearchname_KeyDown);
			// 
			// cmdMemSearch
			// 
			cmdMemSearch.AllowDrop = true;
			cmdMemSearch.BackColor = System.Drawing.SystemColors.Control;
			cmdMemSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdMemSearch.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdMemSearch.Location = new System.Drawing.Point(333, 15);
			cmdMemSearch.Name = "cmdMemSearch";
			cmdMemSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdMemSearch.Size = new System.Drawing.Size(33, 20);
			cmdMemSearch.TabIndex = 163;
			cmdMemSearch.Text = "GO";
			cmdMemSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdMemSearch.UseVisualStyleBackColor = false;
			cmdMemSearch.Click += new System.EventHandler(cmdMemSearch_Click);
			// 
			// grdMemSearch
			// 
			grdMemSearch.AllowDrop = true;
			grdMemSearch.AllowUserToAddRows = false;
			grdMemSearch.AllowUserToDeleteRows = false;
			grdMemSearch.AllowUserToResizeColumns = false;
			grdMemSearch.AllowUserToResizeColumns = grdMemSearch.ColumnHeadersVisible;
			grdMemSearch.AllowUserToResizeRows = false;
			grdMemSearch.AllowUserToResizeRows = false;
			grdMemSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdMemSearch.ColumnsCount = 5;
			grdMemSearch.FixedColumns = 0;
			grdMemSearch.FixedRows = 1;
			grdMemSearch.Location = new System.Drawing.Point(11, 61);
			grdMemSearch.Name = "grdMemSearch";
			grdMemSearch.ReadOnly = true;
			grdMemSearch.RowsCount = 2;
			grdMemSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdMemSearch.ShowCellToolTips = false;
			grdMemSearch.Size = new System.Drawing.Size(556, 158);
			grdMemSearch.StandardTab = true;
			grdMemSearch.TabIndex = 162;
			grdMemSearch.Visible = false;
			grdMemSearch.Click += new System.EventHandler(grdMemSearch_Click);
			// 
			// _Label1_17
			// 
			_Label1_17.AllowDrop = true;
			_Label1_17.BackColor = System.Drawing.SystemColors.Control;
			_Label1_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_17.Location = new System.Drawing.Point(72, 40);
			_Label1_17.MinimumSize = new System.Drawing.Size(63, 19);
			_Label1_17.Name = "_Label1_17";
			_Label1_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_17.Size = new System.Drawing.Size(63, 19);
			_Label1_17.TabIndex = 173;
			_Label1_17.Text = "Company#";
			_Label1_17.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_16
			// 
			_Label1_16.AllowDrop = true;
			_Label1_16.BackColor = System.Drawing.SystemColors.Control;
			_Label1_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_16.Location = new System.Drawing.Point(90, 16);
			_Label1_16.MinimumSize = new System.Drawing.Size(43, 17);
			_Label1_16.Name = "_Label1_16";
			_Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_16.Size = new System.Drawing.Size(43, 17);
			_Label1_16.TabIndex = 165;
			_Label1_16.Text = "Name";
			_Label1_16.Click += new System.EventHandler(Label1_Click);
			// 
			// pnl_add_fracMember
			// 
			pnl_add_fracMember.AllowDrop = true;
			pnl_add_fracMember.BackColor = System.Drawing.SystemColors.Control;
			pnl_add_fracMember.Controls.Add(txtRefid);
			pnl_add_fracMember.Controls.Add(txtfracProgramID);
			pnl_add_fracMember.Controls.Add(cmdFracMemDelete);
			pnl_add_fracMember.Controls.Add(cmdCancelFracMem);
			pnl_add_fracMember.Controls.Add(cmdSaveFracMember);
			pnl_add_fracMember.Controls.Add(txtfracMemberID);
			pnl_add_fracMember.Controls.Add(txtfracMemberName);
			pnl_add_fracMember.Controls.Add(_Label1_20);
			pnl_add_fracMember.Controls.Add(_Label1_18);
			pnl_add_fracMember.Controls.Add(_Label1_19);
			pnl_add_fracMember.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			pnl_add_fracMember.Enabled = true;
			pnl_add_fracMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_add_fracMember.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_add_fracMember.Location = new System.Drawing.Point(385, 286);
			pnl_add_fracMember.Name = "pnl_add_fracMember";
			pnl_add_fracMember.RightToLeft = System.Windows.Forms.RightToLeft.No;
			pnl_add_fracMember.Size = new System.Drawing.Size(318, 153);
			pnl_add_fracMember.TabIndex = 152;
			pnl_add_fracMember.Text = "Program Members";
			pnl_add_fracMember.Visible = false;
			// 
			// txtRefid
			// 
			txtRefid.AcceptsReturn = true;
			txtRefid.AllowDrop = true;
			txtRefid.BackColor = System.Drawing.SystemColors.Window;
			txtRefid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtRefid.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtRefid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtRefid.ForeColor = System.Drawing.SystemColors.WindowText;
			txtRefid.Location = new System.Drawing.Point(263, 24);
			txtRefid.MaxLength = 0;
			txtRefid.Name = "txtRefid";
			txtRefid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtRefid.Size = new System.Drawing.Size(10, 19);
			txtRefid.TabIndex = 172;
			txtRefid.Visible = false;
			// 
			// txtfracProgramID
			// 
			txtfracProgramID.AcceptsReturn = true;
			txtfracProgramID.AllowDrop = true;
			txtfracProgramID.BackColor = System.Drawing.SystemColors.Window;
			txtfracProgramID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtfracProgramID.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtfracProgramID.Enabled = false;
			txtfracProgramID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtfracProgramID.ForeColor = System.Drawing.SystemColors.WindowText;
			txtfracProgramID.Location = new System.Drawing.Point(251, 47);
			txtfracProgramID.MaxLength = 0;
			txtfracProgramID.Name = "txtfracProgramID";
			txtfracProgramID.ReadOnly = true;
			txtfracProgramID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtfracProgramID.Size = new System.Drawing.Size(44, 20);
			txtfracProgramID.TabIndex = 170;
			// 
			// cmdFracMemDelete
			// 
			cmdFracMemDelete.AllowDrop = true;
			cmdFracMemDelete.BackColor = System.Drawing.SystemColors.Control;
			cmdFracMemDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFracMemDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFracMemDelete.Location = new System.Drawing.Point(152, 17);
			cmdFracMemDelete.Name = "cmdFracMemDelete";
			cmdFracMemDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFracMemDelete.Size = new System.Drawing.Size(57, 25);
			cmdFracMemDelete.TabIndex = 157;
			cmdFracMemDelete.Text = "&Delete";
			cmdFracMemDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFracMemDelete.UseVisualStyleBackColor = false;
			cmdFracMemDelete.Click += new System.EventHandler(cmdFracMemDelete_Click);
			// 
			// cmdCancelFracMem
			// 
			cmdCancelFracMem.AllowDrop = true;
			cmdCancelFracMem.BackColor = System.Drawing.SystemColors.Control;
			cmdCancelFracMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancelFracMem.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancelFracMem.Location = new System.Drawing.Point(88, 18);
			cmdCancelFracMem.Name = "cmdCancelFracMem";
			cmdCancelFracMem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancelFracMem.Size = new System.Drawing.Size(57, 25);
			cmdCancelFracMem.TabIndex = 156;
			cmdCancelFracMem.Text = "&Cancel";
			cmdCancelFracMem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancelFracMem.UseVisualStyleBackColor = false;
			cmdCancelFracMem.Click += new System.EventHandler(cmdCancelFracMem_Click);
			// 
			// cmdSaveFracMember
			// 
			cmdSaveFracMember.AllowDrop = true;
			cmdSaveFracMember.BackColor = System.Drawing.SystemColors.Control;
			cmdSaveFracMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSaveFracMember.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSaveFracMember.Location = new System.Drawing.Point(16, 17);
			cmdSaveFracMember.Name = "cmdSaveFracMember";
			cmdSaveFracMember.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSaveFracMember.Size = new System.Drawing.Size(57, 25);
			cmdSaveFracMember.TabIndex = 155;
			cmdSaveFracMember.Text = "&Save";
			cmdSaveFracMember.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSaveFracMember.UseVisualStyleBackColor = false;
			cmdSaveFracMember.Click += new System.EventHandler(cmdSaveFracMember_Click);
			// 
			// txtfracMemberID
			// 
			txtfracMemberID.AcceptsReturn = true;
			txtfracMemberID.AllowDrop = true;
			txtfracMemberID.BackColor = System.Drawing.SystemColors.Window;
			txtfracMemberID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtfracMemberID.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtfracMemberID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtfracMemberID.ForeColor = System.Drawing.SystemColors.WindowText;
			txtfracMemberID.Location = new System.Drawing.Point(96, 52);
			txtfracMemberID.MaxLength = 0;
			txtfracMemberID.Name = "txtfracMemberID";
			txtfracMemberID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtfracMemberID.Size = new System.Drawing.Size(80, 21);
			txtfracMemberID.TabIndex = 154;
			// 
			// txtfracMemberName
			// 
			txtfracMemberName.AcceptsReturn = true;
			txtfracMemberName.AllowDrop = true;
			txtfracMemberName.BackColor = System.Drawing.SystemColors.Window;
			txtfracMemberName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtfracMemberName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtfracMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtfracMemberName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtfracMemberName.Location = new System.Drawing.Point(96, 76);
			txtfracMemberName.MaxLength = 0;
			txtfracMemberName.Name = "txtfracMemberName";
			txtfracMemberName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtfracMemberName.Size = new System.Drawing.Size(210, 25);
			txtfracMemberName.TabIndex = 153;
			// 
			// _Label1_20
			// 
			_Label1_20.AllowDrop = true;
			_Label1_20.BackColor = System.Drawing.SystemColors.Control;
			_Label1_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_20.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_20.Location = new System.Drawing.Point(194, 51);
			_Label1_20.MinimumSize = new System.Drawing.Size(53, 19);
			_Label1_20.Name = "_Label1_20";
			_Label1_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_20.Size = new System.Drawing.Size(53, 19);
			_Label1_20.TabIndex = 169;
			_Label1_20.Text = "Program ID";
			_Label1_20.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_18
			// 
			_Label1_18.AllowDrop = true;
			_Label1_18.BackColor = System.Drawing.SystemColors.Control;
			_Label1_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_18.Location = new System.Drawing.Point(14, 52);
			_Label1_18.MinimumSize = new System.Drawing.Size(81, 19);
			_Label1_18.Name = "_Label1_18";
			_Label1_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_18.Size = new System.Drawing.Size(81, 19);
			_Label1_18.TabIndex = 159;
			_Label1_18.Text = "Company ID";
			_Label1_18.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_19
			// 
			_Label1_19.AllowDrop = true;
			_Label1_19.BackColor = System.Drawing.SystemColors.Control;
			_Label1_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_19.Location = new System.Drawing.Point(12, 81);
			_Label1_19.MinimumSize = new System.Drawing.Size(92, 22);
			_Label1_19.Name = "_Label1_19";
			_Label1_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_19.Size = new System.Drawing.Size(92, 22);
			_Label1_19.TabIndex = 158;
			_Label1_19.Text = "Company Name";
			_Label1_19.Click += new System.EventHandler(Label1_Click);
			// 
			// cmdAddFracMember
			// 
			cmdAddFracMember.AllowDrop = true;
			cmdAddFracMember.BackColor = System.Drawing.SystemColors.Control;
			cmdAddFracMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAddFracMember.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAddFracMember.Location = new System.Drawing.Point(435, 24);
			cmdAddFracMember.Name = "cmdAddFracMember";
			cmdAddFracMember.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAddFracMember.Size = new System.Drawing.Size(123, 21);
			cmdAddFracMember.TabIndex = 160;
			cmdAddFracMember.Text = "&Search for Members";
			cmdAddFracMember.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAddFracMember.UseVisualStyleBackColor = false;
			cmdAddFracMember.Visible = false;
			cmdAddFracMember.Click += new System.EventHandler(cmdAddFracMember_Click);
			// 
			// cmdFracProgram
			// 
			cmdFracProgram.AllowDrop = true;
			cmdFracProgram.BackColor = System.Drawing.SystemColors.Window;
			cmdFracProgram.CausesValidation = true;
			cmdFracProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmdFracProgram.Enabled = true;
			cmdFracProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFracProgram.ForeColor = System.Drawing.SystemColors.WindowText;
			cmdFracProgram.IntegralHeight = true;
			cmdFracProgram.Location = new System.Drawing.Point(93, 20);
			cmdFracProgram.Name = "cmdFracProgram";
			cmdFracProgram.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFracProgram.Size = new System.Drawing.Size(217, 21);
			cmdFracProgram.Sorted = false;
			cmdFracProgram.TabIndex = 149;
			cmdFracProgram.TabStop = true;
			cmdFracProgram.Visible = true;
			cmdFracProgram.SelectedIndexChanged += new System.EventHandler(cmdFracProgram_SelectedIndexChanged);
			// 
			// FG_ProgCompany
			// 
			FG_ProgCompany.AllowDrop = true;
			FG_ProgCompany.AllowUserToAddRows = false;
			FG_ProgCompany.AllowUserToDeleteRows = false;
			FG_ProgCompany.AllowUserToResizeColumns = false;
			FG_ProgCompany.AllowUserToResizeColumns = FG_ProgCompany.ColumnHeadersVisible;
			FG_ProgCompany.AllowUserToResizeRows = false;
			FG_ProgCompany.AllowUserToResizeRows = false;
			FG_ProgCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_ProgCompany.ColumnsCount = 4;
			FG_ProgCompany.FixedColumns = 0;
			FG_ProgCompany.FixedRows = 1;
			FG_ProgCompany.Location = new System.Drawing.Point(13, 52);
			FG_ProgCompany.Name = "FG_ProgCompany";
			FG_ProgCompany.ReadOnly = true;
			FG_ProgCompany.RowsCount = 2;
			FG_ProgCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_ProgCompany.ShowCellToolTips = false;
			FG_ProgCompany.Size = new System.Drawing.Size(358, 391);
			FG_ProgCompany.StandardTab = true;
			FG_ProgCompany.TabIndex = 151;
			FG_ProgCompany.Visible = false;
			FG_ProgCompany.Click += new System.EventHandler(FG_ProgCompany_Click);
			// 
			// _Label43_1
			// 
			_Label43_1.AllowDrop = true;
			_Label43_1.BackColor = System.Drawing.SystemColors.Control;
			_Label43_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label43_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label43_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label43_1.Location = new System.Drawing.Point(600, 13);
			_Label43_1.MinimumSize = new System.Drawing.Size(146, 13);
			_Label43_1.Name = "_Label43_1";
			_Label43_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label43_1.Size = new System.Drawing.Size(146, 13);
			_Label43_1.TabIndex = 266;
			_Label43_1.Text = "Find Program With Company";
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
			_Shape1_1.Location = new System.Drawing.Point(600, 27);
			_Shape1_1.Name = "_Shape1_1";
			_Shape1_1.Size = new System.Drawing.Size(214, 31);
			_Shape1_1.Visible = true;
			// 
			// _Label43_0
			// 
			_Label43_0.AllowDrop = true;
			_Label43_0.BackColor = System.Drawing.SystemColors.Control;
			_Label43_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label43_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label43_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label43_0.Location = new System.Drawing.Point(603, 36);
			_Label43_0.MinimumSize = new System.Drawing.Size(69, 13);
			_Label43_0.Name = "_Label43_0";
			_Label43_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label43_0.Size = new System.Drawing.Size(69, 13);
			_Label43_0.TabIndex = 265;
			_Label43_0.Text = "Company_ID:";
			// 
			// Label40
			// 
			Label40.AllowDrop = true;
			Label40.BackColor = System.Drawing.SystemColors.Control;
			Label40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label40.ForeColor = System.Drawing.SystemColors.ControlText;
			Label40.Location = new System.Drawing.Point(16, 13);
			Label40.MinimumSize = new System.Drawing.Size(103, 33);
			Label40.Name = "Label40";
			Label40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label40.Size = new System.Drawing.Size(103, 33);
			Label40.TabIndex = 150;
			Label40.Text = "Fractional Program";
			// 
			// _tab_Lookup_TabPage14
			// 
			_tab_Lookup_TabPage14.Controls.Add(pnlEFIG_NIOL);
			_tab_Lookup_TabPage14.Controls.Add(pnl_EFIG);
			_tab_Lookup_TabPage14.Controls.Add(pnlEFIG_Delete);
			_tab_Lookup_TabPage14.Controls.Add(pnlEFIG_Add_Group);
			_tab_Lookup_TabPage14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage14.Text = "Financial Groups";
			// 
			// pnlEFIG_NIOL
			// 
			pnlEFIG_NIOL.AllowDrop = true;
			pnlEFIG_NIOL.Controls.Add(chk_SortTotal);
			pnlEFIG_NIOL.Controls.Add(cmd_Add_Parent_pnlEFIG_NIOL);
			pnlEFIG_NIOL.Controls.Add(cmdFG_Home);
			pnlEFIG_NIOL.Controls.Add(_txtViewOther_1);
			pnlEFIG_NIOL.Controls.Add(cmdNewSearch_pnlEFIG_NIOL);
			pnlEFIG_NIOL.Controls.Add(FG_EFIG_NIOL);
			pnlEFIG_NIOL.Controls.Add(cboNIOL_Associate);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_25);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_7);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_18);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_17);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_16);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_15);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_14);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_13);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_12);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_8);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_4);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_3);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_2);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_1);
			pnlEFIG_NIOL.Controls.Add(_lblNIOL_CompanyData_0);
			pnlEFIG_NIOL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlEFIG_NIOL.Location = new System.Drawing.Point(8, 3);
			pnlEFIG_NIOL.Name = "pnlEFIG_NIOL";
			pnlEFIG_NIOL.Size = new System.Drawing.Size(945, 577);
			pnlEFIG_NIOL.TabIndex = 217;
			// 
			// chk_SortTotal
			// 
			chk_SortTotal.AllowDrop = true;
			chk_SortTotal.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_SortTotal.BackColor = System.Drawing.SystemColors.Control;
			chk_SortTotal.CausesValidation = true;
			chk_SortTotal.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_SortTotal.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_SortTotal.Enabled = true;
			chk_SortTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_SortTotal.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_SortTotal.Location = new System.Drawing.Point(648, 24);
			chk_SortTotal.Name = "chk_SortTotal";
			chk_SortTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_SortTotal.Size = new System.Drawing.Size(145, 25);
			chk_SortTotal.TabIndex = 306;
			chk_SortTotal.TabStop = true;
			chk_SortTotal.Text = "Sort by Total Documents";
			chk_SortTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_SortTotal.Visible = true;
			// 
			// cmd_Add_Parent_pnlEFIG_NIOL
			// 
			cmd_Add_Parent_pnlEFIG_NIOL.AllowDrop = true;
			cmd_Add_Parent_pnlEFIG_NIOL.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Parent_pnlEFIG_NIOL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Parent_pnlEFIG_NIOL.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Parent_pnlEFIG_NIOL.Location = new System.Drawing.Point(576, 272);
			cmd_Add_Parent_pnlEFIG_NIOL.Name = "cmd_Add_Parent_pnlEFIG_NIOL";
			cmd_Add_Parent_pnlEFIG_NIOL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Parent_pnlEFIG_NIOL.Size = new System.Drawing.Size(73, 25);
			cmd_Add_Parent_pnlEFIG_NIOL.TabIndex = 257;
			cmd_Add_Parent_pnlEFIG_NIOL.Text = "Add Parent";
			cmd_Add_Parent_pnlEFIG_NIOL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Parent_pnlEFIG_NIOL.UseVisualStyleBackColor = false;
			cmd_Add_Parent_pnlEFIG_NIOL.Click += new System.EventHandler(cmd_Add_Parent_pnlEFIG_NIOL_Click);
			// 
			// cmdFG_Home
			// 
			cmdFG_Home.AllowDrop = true;
			cmdFG_Home.BackColor = System.Drawing.SystemColors.Control;
			cmdFG_Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFG_Home.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFG_Home.Location = new System.Drawing.Point(904, 8);
			cmdFG_Home.Name = "cmdFG_Home";
			cmdFG_Home.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFG_Home.Size = new System.Drawing.Size(33, 21);
			cmdFG_Home.TabIndex = 239;
			cmdFG_Home.Text = "Go";
			cmdFG_Home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFG_Home.UseVisualStyleBackColor = false;
			cmdFG_Home.Click += new System.EventHandler(cmdFG_Home_Click);
			// 
			// _txtViewOther_1
			// 
			_txtViewOther_1.AcceptsReturn = true;
			_txtViewOther_1.AllowDrop = true;
			_txtViewOther_1.BackColor = System.Drawing.SystemColors.Window;
			_txtViewOther_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtViewOther_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtViewOther_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtViewOther_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtViewOther_1.Location = new System.Drawing.Point(96, 32);
			_txtViewOther_1.MaxLength = 0;
			_txtViewOther_1.Name = "_txtViewOther_1";
			_txtViewOther_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtViewOther_1.Size = new System.Drawing.Size(117, 20);
			_txtViewOther_1.TabIndex = 238;
			// 
			// cmdNewSearch_pnlEFIG_NIOL
			// 
			cmdNewSearch_pnlEFIG_NIOL.AllowDrop = true;
			cmdNewSearch_pnlEFIG_NIOL.BackColor = System.Drawing.SystemColors.Control;
			cmdNewSearch_pnlEFIG_NIOL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdNewSearch_pnlEFIG_NIOL.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdNewSearch_pnlEFIG_NIOL.Location = new System.Drawing.Point(8, 32);
			cmdNewSearch_pnlEFIG_NIOL.Name = "cmdNewSearch_pnlEFIG_NIOL";
			cmdNewSearch_pnlEFIG_NIOL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdNewSearch_pnlEFIG_NIOL.Size = new System.Drawing.Size(81, 21);
			cmdNewSearch_pnlEFIG_NIOL.TabIndex = 237;
			cmdNewSearch_pnlEFIG_NIOL.Text = "New Search";
			cmdNewSearch_pnlEFIG_NIOL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdNewSearch_pnlEFIG_NIOL.UseVisualStyleBackColor = false;
			cmdNewSearch_pnlEFIG_NIOL.Click += new System.EventHandler(cmdNewSearch_pnlEFIG_NIOL_Click);
			// 
			// FG_EFIG_NIOL
			// 
			FG_EFIG_NIOL.AllowDrop = true;
			FG_EFIG_NIOL.AllowUserToAddRows = false;
			FG_EFIG_NIOL.AllowUserToDeleteRows = false;
			FG_EFIG_NIOL.AllowUserToResizeColumns = false;
			FG_EFIG_NIOL.AllowUserToResizeRows = false;
			FG_EFIG_NIOL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_EFIG_NIOL.ColumnsCount = 2;
			FG_EFIG_NIOL.FixedColumns = 1;
			FG_EFIG_NIOL.FixedRows = 1;
			FG_EFIG_NIOL.Location = new System.Drawing.Point(16, 56);
			FG_EFIG_NIOL.Name = "FG_EFIG_NIOL";
			FG_EFIG_NIOL.ReadOnly = true;
			FG_EFIG_NIOL.RowsCount = 2;
			FG_EFIG_NIOL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			FG_EFIG_NIOL.ShowCellToolTips = false;
			FG_EFIG_NIOL.Size = new System.Drawing.Size(561, 513);
			FG_EFIG_NIOL.StandardTab = true;
			FG_EFIG_NIOL.TabIndex = 218;
			FG_EFIG_NIOL.Click += new System.EventHandler(FG_EFIG_NIOL_Click);
			// 
			// cboNIOL_Associate
			// 
			cboNIOL_Associate.AllowDrop = true;
			cboNIOL_Associate.BackColor = System.Drawing.SystemColors.Window;
			cboNIOL_Associate.CausesValidation = true;
			cboNIOL_Associate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboNIOL_Associate.Enabled = true;
			cboNIOL_Associate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboNIOL_Associate.ForeColor = System.Drawing.SystemColors.WindowText;
			cboNIOL_Associate.IntegralHeight = true;
			cboNIOL_Associate.Location = new System.Drawing.Point(576, 200);
			cboNIOL_Associate.Name = "cboNIOL_Associate";
			cboNIOL_Associate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboNIOL_Associate.Size = new System.Drawing.Size(217, 21);
			cboNIOL_Associate.Sorted = false;
			cboNIOL_Associate.TabIndex = 220;
			cboNIOL_Associate.TabStop = true;
			cboNIOL_Associate.Visible = true;
			cboNIOL_Associate.SelectionChangeCommitted += new System.EventHandler(cboNIOL_Associate_SelectionChangeCommitted);
			// 
			// _lblNIOL_CompanyData_25
			// 
			_lblNIOL_CompanyData_25.AllowDrop = true;
			_lblNIOL_CompanyData_25.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_25.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_25.Location = new System.Drawing.Point(576, 232);
			_lblNIOL_CompanyData_25.MinimumSize = new System.Drawing.Size(161, 41);
			_lblNIOL_CompanyData_25.Name = "_lblNIOL_CompanyData_25";
			_lblNIOL_CompanyData_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_25.Size = new System.Drawing.Size(161, 41);
			_lblNIOL_CompanyData_25.TabIndex = 256;
			_lblNIOL_CompanyData_25.Text = "If the company you have selected is not in this list click the add button below:";
			// 
			// _lblNIOL_CompanyData_7
			// 
			_lblNIOL_CompanyData_7.AllowDrop = true;
			_lblNIOL_CompanyData_7.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_7.Location = new System.Drawing.Point(432, 40);
			_lblNIOL_CompanyData_7.MinimumSize = new System.Drawing.Size(193, 17);
			_lblNIOL_CompanyData_7.Name = "_lblNIOL_CompanyData_7";
			_lblNIOL_CompanyData_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_7.Size = new System.Drawing.Size(193, 17);
			_lblNIOL_CompanyData_7.TabIndex = 241;
			_lblNIOL_CompanyData_7.Text = "lblNIOL_#Companies";
			// 
			// _lblNIOL_CompanyData_18
			// 
			_lblNIOL_CompanyData_18.AllowDrop = true;
			_lblNIOL_CompanyData_18.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_18.Location = new System.Drawing.Point(576, 71);
			_lblNIOL_CompanyData_18.MinimumSize = new System.Drawing.Size(33, 17);
			_lblNIOL_CompanyData_18.Name = "_lblNIOL_CompanyData_18";
			_lblNIOL_CompanyData_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_18.Size = new System.Drawing.Size(33, 17);
			_lblNIOL_CompanyData_18.TabIndex = 250;
			_lblNIOL_CompanyData_18.Text = "Name:";
			// 
			// _lblNIOL_CompanyData_17
			// 
			_lblNIOL_CompanyData_17.AllowDrop = true;
			_lblNIOL_CompanyData_17.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_17.Location = new System.Drawing.Point(576, 104);
			_lblNIOL_CompanyData_17.MinimumSize = new System.Drawing.Size(33, 17);
			_lblNIOL_CompanyData_17.Name = "_lblNIOL_CompanyData_17";
			_lblNIOL_CompanyData_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_17.Size = new System.Drawing.Size(33, 17);
			_lblNIOL_CompanyData_17.TabIndex = 249;
			_lblNIOL_CompanyData_17.Text = "City:";
			// 
			// _lblNIOL_CompanyData_16
			// 
			_lblNIOL_CompanyData_16.AllowDrop = true;
			_lblNIOL_CompanyData_16.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_16.Location = new System.Drawing.Point(576, 128);
			_lblNIOL_CompanyData_16.MinimumSize = new System.Drawing.Size(33, 17);
			_lblNIOL_CompanyData_16.Name = "_lblNIOL_CompanyData_16";
			_lblNIOL_CompanyData_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_16.Size = new System.Drawing.Size(33, 17);
			_lblNIOL_CompanyData_16.TabIndex = 248;
			_lblNIOL_CompanyData_16.Text = "State:";
			// 
			// _lblNIOL_CompanyData_15
			// 
			_lblNIOL_CompanyData_15.AllowDrop = true;
			_lblNIOL_CompanyData_15.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_15.Location = new System.Drawing.Point(576, 152);
			_lblNIOL_CompanyData_15.MinimumSize = new System.Drawing.Size(17, 17);
			_lblNIOL_CompanyData_15.Name = "_lblNIOL_CompanyData_15";
			_lblNIOL_CompanyData_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_15.Size = new System.Drawing.Size(17, 17);
			_lblNIOL_CompanyData_15.TabIndex = 247;
			_lblNIOL_CompanyData_15.Text = "ID:";
			// 
			// _lblNIOL_CompanyData_14
			// 
			_lblNIOL_CompanyData_14.AllowDrop = true;
			_lblNIOL_CompanyData_14.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_14.Location = new System.Drawing.Point(576, 176);
			_lblNIOL_CompanyData_14.MinimumSize = new System.Drawing.Size(57, 17);
			_lblNIOL_CompanyData_14.Name = "_lblNIOL_CompanyData_14";
			_lblNIOL_CompanyData_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_14.Size = new System.Drawing.Size(57, 17);
			_lblNIOL_CompanyData_14.TabIndex = 246;
			_lblNIOL_CompanyData_14.Text = "# of Docs:";
			// 
			// _lblNIOL_CompanyData_13
			// 
			_lblNIOL_CompanyData_13.AllowDrop = true;
			_lblNIOL_CompanyData_13.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_13.Location = new System.Drawing.Point(648, 8);
			_lblNIOL_CompanyData_13.MinimumSize = new System.Drawing.Size(257, 25);
			_lblNIOL_CompanyData_13.Name = "_lblNIOL_CompanyData_13";
			_lblNIOL_CompanyData_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_13.Size = new System.Drawing.Size(257, 25);
			_lblNIOL_CompanyData_13.TabIndex = 245;
			_lblNIOL_CompanyData_13.Text = "Return To Existing Financial Groups:";
			// 
			// _lblNIOL_CompanyData_12
			// 
			_lblNIOL_CompanyData_12.AllowDrop = true;
			_lblNIOL_CompanyData_12.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_12.Location = new System.Drawing.Point(8, 8);
			_lblNIOL_CompanyData_12.MinimumSize = new System.Drawing.Size(417, 25);
			_lblNIOL_CompanyData_12.Name = "_lblNIOL_CompanyData_12";
			_lblNIOL_CompanyData_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_12.Size = new System.Drawing.Size(417, 25);
			_lblNIOL_CompanyData_12.TabIndex = 244;
			_lblNIOL_CompanyData_12.Text = "Companies with documents not in financial groups:";
			// 
			// _lblNIOL_CompanyData_8
			// 
			_lblNIOL_CompanyData_8.AllowDrop = true;
			_lblNIOL_CompanyData_8.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_8.Location = new System.Drawing.Point(216, 40);
			_lblNIOL_CompanyData_8.MinimumSize = new System.Drawing.Size(201, 17);
			_lblNIOL_CompanyData_8.Name = "_lblNIOL_CompanyData_8";
			_lblNIOL_CompanyData_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_8.Size = new System.Drawing.Size(201, 17);
			_lblNIOL_CompanyData_8.TabIndex = 242;
			_lblNIOL_CompanyData_8.Text = "lblNIOL_#Docs";
			// 
			// _lblNIOL_CompanyData_4
			// 
			_lblNIOL_CompanyData_4.AllowDrop = true;
			_lblNIOL_CompanyData_4.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_4.Location = new System.Drawing.Point(640, 176);
			_lblNIOL_CompanyData_4.MinimumSize = new System.Drawing.Size(161, 17);
			_lblNIOL_CompanyData_4.Name = "_lblNIOL_CompanyData_4";
			_lblNIOL_CompanyData_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_4.Size = new System.Drawing.Size(161, 17);
			_lblNIOL_CompanyData_4.TabIndex = 235;
			_lblNIOL_CompanyData_4.Text = "lblNIOL_tcount";
			// 
			// _lblNIOL_CompanyData_3
			// 
			_lblNIOL_CompanyData_3.AllowDrop = true;
			_lblNIOL_CompanyData_3.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_3.Location = new System.Drawing.Point(640, 152);
			_lblNIOL_CompanyData_3.MinimumSize = new System.Drawing.Size(161, 17);
			_lblNIOL_CompanyData_3.Name = "_lblNIOL_CompanyData_3";
			_lblNIOL_CompanyData_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_3.Size = new System.Drawing.Size(161, 17);
			_lblNIOL_CompanyData_3.TabIndex = 234;
			_lblNIOL_CompanyData_3.Text = "lblNIOL_compID";
			// 
			// _lblNIOL_CompanyData_2
			// 
			_lblNIOL_CompanyData_2.AllowDrop = true;
			_lblNIOL_CompanyData_2.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_2.Location = new System.Drawing.Point(640, 128);
			_lblNIOL_CompanyData_2.MinimumSize = new System.Drawing.Size(161, 17);
			_lblNIOL_CompanyData_2.Name = "_lblNIOL_CompanyData_2";
			_lblNIOL_CompanyData_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_2.Size = new System.Drawing.Size(161, 17);
			_lblNIOL_CompanyData_2.TabIndex = 233;
			_lblNIOL_CompanyData_2.Text = "lblNIOL_comp_state";
			// 
			// _lblNIOL_CompanyData_1
			// 
			_lblNIOL_CompanyData_1.AllowDrop = true;
			_lblNIOL_CompanyData_1.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_1.Location = new System.Drawing.Point(640, 104);
			_lblNIOL_CompanyData_1.MinimumSize = new System.Drawing.Size(161, 17);
			_lblNIOL_CompanyData_1.Name = "_lblNIOL_CompanyData_1";
			_lblNIOL_CompanyData_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_1.Size = new System.Drawing.Size(161, 17);
			_lblNIOL_CompanyData_1.TabIndex = 232;
			_lblNIOL_CompanyData_1.Text = "lblNIOL_compCity";
			// 
			// _lblNIOL_CompanyData_0
			// 
			_lblNIOL_CompanyData_0.AllowDrop = true;
			_lblNIOL_CompanyData_0.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_0.Location = new System.Drawing.Point(640, 72);
			_lblNIOL_CompanyData_0.MinimumSize = new System.Drawing.Size(297, 33);
			_lblNIOL_CompanyData_0.Name = "_lblNIOL_CompanyData_0";
			_lblNIOL_CompanyData_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_0.Size = new System.Drawing.Size(297, 33);
			_lblNIOL_CompanyData_0.TabIndex = 219;
			_lblNIOL_CompanyData_0.Text = "lblNIOL_compName";
			// 
			// pnl_EFIG
			// 
			pnl_EFIG.AllowDrop = true;
			pnl_EFIG.BackColor = System.Drawing.SystemColors.Control;
			pnl_EFIG.Controls.Add(pnl_AddFinGroup);
			pnl_EFIG.Controls.Add(cmd_ASP_dot_Net);
			pnl_EFIG.Controls.Add(_txtDateRange_pnlEFIG_0);
			pnl_EFIG.Controls.Add(_cmdSearch_Compy_wDate_0);
			pnl_EFIG.Controls.Add(_txtViewOther_0);
			pnl_EFIG.Controls.Add(cmdViewNIOL);
			pnl_EFIG.Controls.Add(_cboEFIG_SelectGroup_0);
			pnl_EFIG.Controls.Add(cmdAddEFIG);
			pnl_EFIG.Controls.Add(tab_Lists);
			pnl_EFIG.Controls.Add(Label3);
			pnl_EFIG.Controls.Add(_lblNIOL_CompanyData_5);
			pnl_EFIG.Controls.Add(_lblNIOL_CompanyData_19);
			pnl_EFIG.Controls.Add(_lblNIOL_CompanyData_9);
			pnl_EFIG.Controls.Add(_lblNIOL_CompanyData_6);
			pnl_EFIG.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			pnl_EFIG.Enabled = true;
			pnl_EFIG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_EFIG.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_EFIG.Location = new System.Drawing.Point(16, 4);
			pnl_EFIG.Name = "pnl_EFIG";
			pnl_EFIG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			pnl_EFIG.Size = new System.Drawing.Size(945, 577);
			pnl_EFIG.TabIndex = 221;
			pnl_EFIG.Visible = true;
			// 
			// pnl_AddFinGroup
			// 
			pnl_AddFinGroup.AllowDrop = true;
			pnl_AddFinGroup.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			pnl_AddFinGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_AddFinGroup.Controls.Add(_txtViewOther_2);
			pnl_AddFinGroup.Controls.Add(cboAdd_Comp_Ref);
			pnl_AddFinGroup.Controls.Add(cmdAdd_CompRef);
			pnl_AddFinGroup.Controls.Add(_lblNIOL_CompanyData_24);
			pnl_AddFinGroup.Controls.Add(_lblNIOL_CompanyData_22);
			pnl_AddFinGroup.Controls.Add(_lblNIOL_CompanyData_23);
			pnl_AddFinGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_AddFinGroup.Location = new System.Drawing.Point(744, 48);
			pnl_AddFinGroup.Name = "pnl_AddFinGroup";
			pnl_AddFinGroup.Size = new System.Drawing.Size(193, 137);
			pnl_AddFinGroup.TabIndex = 299;
			// 
			// _txtViewOther_2
			// 
			_txtViewOther_2.AcceptsReturn = true;
			_txtViewOther_2.AllowDrop = true;
			_txtViewOther_2.BackColor = System.Drawing.SystemColors.Window;
			_txtViewOther_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtViewOther_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtViewOther_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtViewOther_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtViewOther_2.Location = new System.Drawing.Point(48, 32);
			_txtViewOther_2.MaxLength = 0;
			_txtViewOther_2.Name = "_txtViewOther_2";
			_txtViewOther_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtViewOther_2.Size = new System.Drawing.Size(61, 20);
			_txtViewOther_2.TabIndex = 302;
			// 
			// cboAdd_Comp_Ref
			// 
			cboAdd_Comp_Ref.AllowDrop = true;
			cboAdd_Comp_Ref.BackColor = System.Drawing.SystemColors.Window;
			cboAdd_Comp_Ref.CausesValidation = true;
			cboAdd_Comp_Ref.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboAdd_Comp_Ref.Enabled = true;
			cboAdd_Comp_Ref.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboAdd_Comp_Ref.ForeColor = System.Drawing.SystemColors.WindowText;
			cboAdd_Comp_Ref.IntegralHeight = true;
			cboAdd_Comp_Ref.Location = new System.Drawing.Point(48, 64);
			cboAdd_Comp_Ref.Name = "cboAdd_Comp_Ref";
			cboAdd_Comp_Ref.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboAdd_Comp_Ref.Size = new System.Drawing.Size(137, 21);
			cboAdd_Comp_Ref.Sorted = false;
			cboAdd_Comp_Ref.TabIndex = 301;
			cboAdd_Comp_Ref.TabStop = true;
			cboAdd_Comp_Ref.Visible = true;
			// 
			// cmdAdd_CompRef
			// 
			cmdAdd_CompRef.AllowDrop = true;
			cmdAdd_CompRef.BackColor = System.Drawing.SystemColors.Control;
			cmdAdd_CompRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAdd_CompRef.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAdd_CompRef.Location = new System.Drawing.Point(48, 96);
			cmdAdd_CompRef.Name = "cmdAdd_CompRef";
			cmdAdd_CompRef.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAdd_CompRef.Size = new System.Drawing.Size(137, 25);
			cmdAdd_CompRef.TabIndex = 300;
			cmdAdd_CompRef.Text = "Add financial reference";
			cmdAdd_CompRef.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAdd_CompRef.UseVisualStyleBackColor = false;
			cmdAdd_CompRef.Click += new System.EventHandler(cmdAdd_CompRef_Click);
			// 
			// _lblNIOL_CompanyData_24
			// 
			_lblNIOL_CompanyData_24.AllowDrop = true;
			_lblNIOL_CompanyData_24.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_24.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_24.Location = new System.Drawing.Point(8, 64);
			_lblNIOL_CompanyData_24.MinimumSize = new System.Drawing.Size(41, 17);
			_lblNIOL_CompanyData_24.Name = "_lblNIOL_CompanyData_24";
			_lblNIOL_CompanyData_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_24.Size = new System.Drawing.Size(41, 17);
			_lblNIOL_CompanyData_24.TabIndex = 305;
			_lblNIOL_CompanyData_24.Text = "Name:";
			// 
			// _lblNIOL_CompanyData_22
			// 
			_lblNIOL_CompanyData_22.AllowDrop = true;
			_lblNIOL_CompanyData_22.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_22.Location = new System.Drawing.Point(24, 8);
			_lblNIOL_CompanyData_22.MinimumSize = new System.Drawing.Size(145, 25);
			_lblNIOL_CompanyData_22.Name = "_lblNIOL_CompanyData_22";
			_lblNIOL_CompanyData_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_22.Size = new System.Drawing.Size(145, 25);
			_lblNIOL_CompanyData_22.TabIndex = 304;
			_lblNIOL_CompanyData_22.Text = "Add company reference:";
			// 
			// _lblNIOL_CompanyData_23
			// 
			_lblNIOL_CompanyData_23.AllowDrop = true;
			_lblNIOL_CompanyData_23.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_23.Location = new System.Drawing.Point(8, 32);
			_lblNIOL_CompanyData_23.MinimumSize = new System.Drawing.Size(17, 17);
			_lblNIOL_CompanyData_23.Name = "_lblNIOL_CompanyData_23";
			_lblNIOL_CompanyData_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_23.Size = new System.Drawing.Size(17, 17);
			_lblNIOL_CompanyData_23.TabIndex = 303;
			_lblNIOL_CompanyData_23.Text = "ID:";
			// 
			// cmd_ASP_dot_Net
			// 
			cmd_ASP_dot_Net.AllowDrop = true;
			cmd_ASP_dot_Net.BackColor = System.Drawing.SystemColors.Control;
			cmd_ASP_dot_Net.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_ASP_dot_Net.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_ASP_dot_Net.Location = new System.Drawing.Point(384, 16);
			cmd_ASP_dot_Net.Name = "cmd_ASP_dot_Net";
			cmd_ASP_dot_Net.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_ASP_dot_Net.Size = new System.Drawing.Size(73, 17);
			cmd_ASP_dot_Net.TabIndex = 262;
			cmd_ASP_dot_Net.Text = "ASP";
			cmd_ASP_dot_Net.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_ASP_dot_Net.UseVisualStyleBackColor = false;
			cmd_ASP_dot_Net.Click += new System.EventHandler(cmd_ASP_dot_Net_Click);
			// 
			// _txtDateRange_pnlEFIG_0
			// 
			_txtDateRange_pnlEFIG_0.AcceptsReturn = true;
			_txtDateRange_pnlEFIG_0.AllowDrop = true;
			_txtDateRange_pnlEFIG_0.BackColor = System.Drawing.SystemColors.Window;
			_txtDateRange_pnlEFIG_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtDateRange_pnlEFIG_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtDateRange_pnlEFIG_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtDateRange_pnlEFIG_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtDateRange_pnlEFIG_0.Location = new System.Drawing.Point(624, 64);
			_txtDateRange_pnlEFIG_0.MaxLength = 0;
			_txtDateRange_pnlEFIG_0.Name = "_txtDateRange_pnlEFIG_0";
			_txtDateRange_pnlEFIG_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtDateRange_pnlEFIG_0.Size = new System.Drawing.Size(97, 19);
			_txtDateRange_pnlEFIG_0.TabIndex = 261;
			// 
			// _cmdSearch_Compy_wDate_0
			// 
			_cmdSearch_Compy_wDate_0.AllowDrop = true;
			_cmdSearch_Compy_wDate_0.BackColor = System.Drawing.SystemColors.Control;
			_cmdSearch_Compy_wDate_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSearch_Compy_wDate_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSearch_Compy_wDate_0.Location = new System.Drawing.Point(552, 64);
			_cmdSearch_Compy_wDate_0.Name = "_cmdSearch_Compy_wDate_0";
			_cmdSearch_Compy_wDate_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSearch_Compy_wDate_0.Size = new System.Drawing.Size(57, 17);
			_cmdSearch_Compy_wDate_0.TabIndex = 260;
			_cmdSearch_Compy_wDate_0.Text = "Search";
			_cmdSearch_Compy_wDate_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSearch_Compy_wDate_0.UseVisualStyleBackColor = false;
			_cmdSearch_Compy_wDate_0.Click += new System.EventHandler(cmdSearch_Compy_wDate_Click);
			// 
			// _txtViewOther_0
			// 
			_txtViewOther_0.AcceptsReturn = true;
			_txtViewOther_0.AllowDrop = true;
			_txtViewOther_0.BackColor = System.Drawing.SystemColors.Window;
			_txtViewOther_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtViewOther_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtViewOther_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtViewOther_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtViewOther_0.Location = new System.Drawing.Point(816, 24);
			_txtViewOther_0.MaxLength = 0;
			_txtViewOther_0.Name = "_txtViewOther_0";
			_txtViewOther_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtViewOther_0.Size = new System.Drawing.Size(117, 20);
			_txtViewOther_0.TabIndex = 236;
			// 
			// cmdViewNIOL
			// 
			cmdViewNIOL.AllowDrop = true;
			cmdViewNIOL.BackColor = System.Drawing.SystemColors.Control;
			cmdViewNIOL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdViewNIOL.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdViewNIOL.Location = new System.Drawing.Point(761, 24);
			cmdViewNIOL.Name = "cmdViewNIOL";
			cmdViewNIOL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdViewNIOL.Size = new System.Drawing.Size(49, 17);
			cmdViewNIOL.TabIndex = 224;
			cmdViewNIOL.Text = "View";
			cmdViewNIOL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdViewNIOL.UseVisualStyleBackColor = false;
			cmdViewNIOL.Click += new System.EventHandler(cmdViewNIOL_Click);
			// 
			// _cboEFIG_SelectGroup_0
			// 
			_cboEFIG_SelectGroup_0.AllowDrop = true;
			_cboEFIG_SelectGroup_0.BackColor = System.Drawing.SystemColors.Window;
			_cboEFIG_SelectGroup_0.CausesValidation = true;
			_cboEFIG_SelectGroup_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboEFIG_SelectGroup_0.Enabled = true;
			_cboEFIG_SelectGroup_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboEFIG_SelectGroup_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboEFIG_SelectGroup_0.IntegralHeight = true;
			_cboEFIG_SelectGroup_0.Location = new System.Drawing.Point(8, 31);
			_cboEFIG_SelectGroup_0.Name = "_cboEFIG_SelectGroup_0";
			_cboEFIG_SelectGroup_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboEFIG_SelectGroup_0.Size = new System.Drawing.Size(201, 21);
			_cboEFIG_SelectGroup_0.Sorted = false;
			_cboEFIG_SelectGroup_0.TabIndex = 223;
			_cboEFIG_SelectGroup_0.TabStop = true;
			_cboEFIG_SelectGroup_0.Visible = true;
			_cboEFIG_SelectGroup_0.SelectionChangeCommitted += new System.EventHandler(cboEFIG_SelectGroup_SelectionChangeCommitted);
			// 
			// cmdAddEFIG
			// 
			cmdAddEFIG.AllowDrop = true;
			cmdAddEFIG.BackColor = System.Drawing.SystemColors.Control;
			cmdAddEFIG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAddEFIG.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAddEFIG.Location = new System.Drawing.Point(224, 32);
			cmdAddEFIG.Name = "cmdAddEFIG";
			cmdAddEFIG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAddEFIG.Size = new System.Drawing.Size(105, 17);
			cmdAddEFIG.TabIndex = 222;
			cmdAddEFIG.Text = "Add financial group";
			cmdAddEFIG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAddEFIG.UseVisualStyleBackColor = false;
			cmdAddEFIG.Click += new System.EventHandler(cmdAddEFIG_Click);
			// 
			// tab_Lists
			// 
			tab_Lists.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_Lists.AllowDrop = true;
			tab_Lists.Controls.Add(_tab_Lists_TabPage0);
			tab_Lists.Controls.Add(_tab_Lists_TabPage1);
			tab_Lists.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_Lists.ItemSize = new System.Drawing.Size(367, 18);
			tab_Lists.Location = new System.Drawing.Point(8, 88);
			tab_Lists.Multiline = true;
			tab_Lists.Name = "tab_Lists";
			tab_Lists.Size = new System.Drawing.Size(741, 485);
			tab_Lists.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_Lists.TabIndex = 293;
			tab_Lists.SelectedIndexChanged += new System.EventHandler(tab_Lists_SelectedIndexChanged);
			// 
			// _tab_Lists_TabPage0
			// 
			_tab_Lists_TabPage0.Controls.Add(FG_EFIG_MC);
			_tab_Lists_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lists_TabPage0.Text = "Group Companies";
			// 
			// FG_EFIG_MC
			// 
			FG_EFIG_MC.AllowDrop = true;
			FG_EFIG_MC.AllowUserToAddRows = false;
			FG_EFIG_MC.AllowUserToDeleteRows = false;
			FG_EFIG_MC.AllowUserToResizeColumns = false;
			FG_EFIG_MC.AllowUserToResizeRows = false;
			FG_EFIG_MC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_EFIG_MC.ColumnsCount = 2;
			FG_EFIG_MC.FixedColumns = 0;
			FG_EFIG_MC.FixedRows = 1;
			FG_EFIG_MC.Location = new System.Drawing.Point(8, 4);
			FG_EFIG_MC.Name = "FG_EFIG_MC";
			FG_EFIG_MC.ReadOnly = true;
			FG_EFIG_MC.RowsCount = 2;
			FG_EFIG_MC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_EFIG_MC.ShowCellToolTips = false;
			FG_EFIG_MC.Size = new System.Drawing.Size(721, 449);
			FG_EFIG_MC.StandardTab = true;
			FG_EFIG_MC.TabIndex = 294;
			FG_EFIG_MC.Click += new System.EventHandler(FG_EFIG_MC_Click);
			// 
			// _tab_Lists_TabPage1
			// 
			_tab_Lists_TabPage1.Controls.Add(lbl_UnRel_Docs);
			_tab_Lists_TabPage1.Controls.Add(lbl_UnRel_Comps);
			_tab_Lists_TabPage1.Controls.Add(grd_RelatedCompanies);
			_tab_Lists_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lists_TabPage1.Text = "Related Companies";
			// 
			// lbl_UnRel_Docs
			// 
			lbl_UnRel_Docs.AllowDrop = true;
			lbl_UnRel_Docs.BackColor = System.Drawing.SystemColors.Control;
			lbl_UnRel_Docs.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_UnRel_Docs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_UnRel_Docs.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_UnRel_Docs.Location = new System.Drawing.Point(8, 12);
			lbl_UnRel_Docs.MinimumSize = new System.Drawing.Size(201, 17);
			lbl_UnRel_Docs.Name = "lbl_UnRel_Docs";
			lbl_UnRel_Docs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_UnRel_Docs.Size = new System.Drawing.Size(201, 17);
			lbl_UnRel_Docs.TabIndex = 297;
			lbl_UnRel_Docs.Text = "Documents Not Attached:";
			// 
			// lbl_UnRel_Comps
			// 
			lbl_UnRel_Comps.AllowDrop = true;
			lbl_UnRel_Comps.BackColor = System.Drawing.SystemColors.Control;
			lbl_UnRel_Comps.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_UnRel_Comps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_UnRel_Comps.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_UnRel_Comps.Location = new System.Drawing.Point(296, 12);
			lbl_UnRel_Comps.MinimumSize = new System.Drawing.Size(217, 17);
			lbl_UnRel_Comps.Name = "lbl_UnRel_Comps";
			lbl_UnRel_Comps.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_UnRel_Comps.Size = new System.Drawing.Size(217, 17);
			lbl_UnRel_Comps.TabIndex = 298;
			lbl_UnRel_Comps.Text = "Companies Not Attached:";
			// 
			// grd_RelatedCompanies
			// 
			grd_RelatedCompanies.AllowDrop = true;
			grd_RelatedCompanies.AllowUserToAddRows = false;
			grd_RelatedCompanies.AllowUserToDeleteRows = false;
			grd_RelatedCompanies.AllowUserToResizeColumns = false;
			grd_RelatedCompanies.AllowUserToResizeRows = false;
			grd_RelatedCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_RelatedCompanies.ColumnsCount = 2;
			grd_RelatedCompanies.FixedColumns = 0;
			grd_RelatedCompanies.FixedRows = 1;
			grd_RelatedCompanies.Location = new System.Drawing.Point(8, 36);
			grd_RelatedCompanies.Name = "grd_RelatedCompanies";
			grd_RelatedCompanies.ReadOnly = true;
			grd_RelatedCompanies.RowsCount = 2;
			grd_RelatedCompanies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_RelatedCompanies.ShowCellToolTips = false;
			grd_RelatedCompanies.Size = new System.Drawing.Size(721, 409);
			grd_RelatedCompanies.StandardTab = true;
			grd_RelatedCompanies.TabIndex = 296;
			grd_RelatedCompanies.Click += new System.EventHandler(grd_RelatedCompanies_Click);
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.BackColor = System.Drawing.SystemColors.Control;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(632, 48);
			Label3.MinimumSize = new System.Drawing.Size(89, 25);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(89, 25);
			Label3.TabIndex = 320;
			Label3.Text = "Document Date";
			Label3.Visible = false;
			// 
			// _lblNIOL_CompanyData_5
			// 
			_lblNIOL_CompanyData_5.AllowDrop = true;
			_lblNIOL_CompanyData_5.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_5.Location = new System.Drawing.Point(8, 64);
			_lblNIOL_CompanyData_5.MinimumSize = new System.Drawing.Size(201, 17);
			_lblNIOL_CompanyData_5.Name = "_lblNIOL_CompanyData_5";
			_lblNIOL_CompanyData_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_5.Size = new System.Drawing.Size(201, 17);
			_lblNIOL_CompanyData_5.TabIndex = 295;
			_lblNIOL_CompanyData_5.Text = "lblNIOL_#Docs";
			// 
			// _lblNIOL_CompanyData_19
			// 
			_lblNIOL_CompanyData_19.AllowDrop = true;
			_lblNIOL_CompanyData_19.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_19.Location = new System.Drawing.Point(552, 8);
			_lblNIOL_CompanyData_19.MinimumSize = new System.Drawing.Size(385, 25);
			_lblNIOL_CompanyData_19.Name = "_lblNIOL_CompanyData_19";
			_lblNIOL_CompanyData_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_19.Size = new System.Drawing.Size(385, 25);
			_lblNIOL_CompanyData_19.TabIndex = 251;
			_lblNIOL_CompanyData_19.Text = "View companies with documents not in financial groups:";
			// 
			// _lblNIOL_CompanyData_9
			// 
			_lblNIOL_CompanyData_9.AllowDrop = true;
			_lblNIOL_CompanyData_9.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_9.Location = new System.Drawing.Point(8, 8);
			_lblNIOL_CompanyData_9.MinimumSize = new System.Drawing.Size(385, 25);
			_lblNIOL_CompanyData_9.Name = "_lblNIOL_CompanyData_9";
			_lblNIOL_CompanyData_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_9.Size = new System.Drawing.Size(385, 25);
			_lblNIOL_CompanyData_9.TabIndex = 243;
			_lblNIOL_CompanyData_9.Text = "Companies with documents in financial groups:";
			// 
			// _lblNIOL_CompanyData_6
			// 
			_lblNIOL_CompanyData_6.AllowDrop = true;
			_lblNIOL_CompanyData_6.BackColor = System.Drawing.SystemColors.Control;
			_lblNIOL_CompanyData_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblNIOL_CompanyData_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblNIOL_CompanyData_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblNIOL_CompanyData_6.Location = new System.Drawing.Point(224, 64);
			_lblNIOL_CompanyData_6.MinimumSize = new System.Drawing.Size(193, 17);
			_lblNIOL_CompanyData_6.Name = "_lblNIOL_CompanyData_6";
			_lblNIOL_CompanyData_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblNIOL_CompanyData_6.Size = new System.Drawing.Size(193, 17);
			_lblNIOL_CompanyData_6.TabIndex = 240;
			_lblNIOL_CompanyData_6.Text = "lblNIOL_#Companies";
			// 
			// pnlEFIG_Delete
			// 
			pnlEFIG_Delete.AllowDrop = true;
			pnlEFIG_Delete.Controls.Add(cmdDelete_EFIG);
			pnlEFIG_Delete.Controls.Add(cmdExit_pnlEFIG_Delete);
			pnlEFIG_Delete.Controls.Add(_lblCompanyData_5);
			pnlEFIG_Delete.Controls.Add(_lblCompanyData_2);
			pnlEFIG_Delete.Controls.Add(_lblCompanyData_11);
			pnlEFIG_Delete.Controls.Add(_lblCompanyData_10);
			pnlEFIG_Delete.Controls.Add(_lblCompanyData_7);
			pnlEFIG_Delete.Controls.Add(_lblCompanyData_6);
			pnlEFIG_Delete.Controls.Add(_lblCompanyData_1);
			pnlEFIG_Delete.Controls.Add(_lblCompanyData_0);
			pnlEFIG_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlEFIG_Delete.Location = new System.Drawing.Point(760, 308);
			pnlEFIG_Delete.Name = "pnlEFIG_Delete";
			pnlEFIG_Delete.Size = new System.Drawing.Size(193, 249);
			pnlEFIG_Delete.TabIndex = 225;
			pnlEFIG_Delete.Text = "Delete Financial Info";
			// 
			// cmdDelete_EFIG
			// 
			cmdDelete_EFIG.AllowDrop = true;
			cmdDelete_EFIG.BackColor = System.Drawing.SystemColors.Control;
			cmdDelete_EFIG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDelete_EFIG.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDelete_EFIG.Location = new System.Drawing.Point(8, 200);
			cmdDelete_EFIG.Name = "cmdDelete_EFIG";
			cmdDelete_EFIG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDelete_EFIG.Size = new System.Drawing.Size(65, 25);
			cmdDelete_EFIG.TabIndex = 227;
			cmdDelete_EFIG.Text = "Delete";
			cmdDelete_EFIG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDelete_EFIG.UseVisualStyleBackColor = false;
			cmdDelete_EFIG.Click += new System.EventHandler(cmdDelete_EFIG_Click);
			// 
			// cmdExit_pnlEFIG_Delete
			// 
			cmdExit_pnlEFIG_Delete.AllowDrop = true;
			cmdExit_pnlEFIG_Delete.BackColor = System.Drawing.SystemColors.Control;
			cmdExit_pnlEFIG_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdExit_pnlEFIG_Delete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdExit_pnlEFIG_Delete.Location = new System.Drawing.Point(80, 200);
			cmdExit_pnlEFIG_Delete.Name = "cmdExit_pnlEFIG_Delete";
			cmdExit_pnlEFIG_Delete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdExit_pnlEFIG_Delete.Size = new System.Drawing.Size(65, 25);
			cmdExit_pnlEFIG_Delete.TabIndex = 226;
			cmdExit_pnlEFIG_Delete.Text = "Cancel";
			cmdExit_pnlEFIG_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdExit_pnlEFIG_Delete.UseVisualStyleBackColor = false;
			cmdExit_pnlEFIG_Delete.Click += new System.EventHandler(cmdExit_pnlEFIG_Delete_Click);
			// 
			// _lblCompanyData_5
			// 
			_lblCompanyData_5.AllowDrop = true;
			_lblCompanyData_5.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyData_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyData_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyData_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyData_5.Location = new System.Drawing.Point(56, 176);
			_lblCompanyData_5.MinimumSize = new System.Drawing.Size(377, 17);
			_lblCompanyData_5.Name = "_lblCompanyData_5";
			_lblCompanyData_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyData_5.Size = new System.Drawing.Size(377, 17);
			_lblCompanyData_5.TabIndex = 231;
			_lblCompanyData_5.Text = "CompID";
			// 
			// _lblCompanyData_2
			// 
			_lblCompanyData_2.AllowDrop = true;
			_lblCompanyData_2.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyData_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyData_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyData_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyData_2.Location = new System.Drawing.Point(40, 88);
			_lblCompanyData_2.MinimumSize = new System.Drawing.Size(145, 65);
			_lblCompanyData_2.Name = "_lblCompanyData_2";
			_lblCompanyData_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyData_2.Size = new System.Drawing.Size(145, 65);
			_lblCompanyData_2.TabIndex = 230;
			_lblCompanyData_2.Text = "compName";
			// 
			// _lblCompanyData_11
			// 
			_lblCompanyData_11.AllowDrop = true;
			_lblCompanyData_11.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyData_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyData_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyData_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyData_11.Location = new System.Drawing.Point(8, 64);
			_lblCompanyData_11.MinimumSize = new System.Drawing.Size(49, 17);
			_lblCompanyData_11.Name = "_lblCompanyData_11";
			_lblCompanyData_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyData_11.Size = new System.Drawing.Size(49, 17);
			_lblCompanyData_11.TabIndex = 255;
			_lblCompanyData_11.Text = "Main ID:";
			// 
			// _lblCompanyData_10
			// 
			_lblCompanyData_10.AllowDrop = true;
			_lblCompanyData_10.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyData_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyData_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyData_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyData_10.Location = new System.Drawing.Point(8, 88);
			_lblCompanyData_10.MinimumSize = new System.Drawing.Size(41, 17);
			_lblCompanyData_10.Name = "_lblCompanyData_10";
			_lblCompanyData_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyData_10.Size = new System.Drawing.Size(41, 17);
			_lblCompanyData_10.TabIndex = 254;
			_lblCompanyData_10.Text = "Name:";
			// 
			// _lblCompanyData_7
			// 
			_lblCompanyData_7.AllowDrop = true;
			_lblCompanyData_7.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyData_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyData_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyData_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyData_7.Location = new System.Drawing.Point(8, 176);
			_lblCompanyData_7.MinimumSize = new System.Drawing.Size(25, 17);
			_lblCompanyData_7.Name = "_lblCompanyData_7";
			_lblCompanyData_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyData_7.Size = new System.Drawing.Size(25, 17);
			_lblCompanyData_7.TabIndex = 253;
			_lblCompanyData_7.Text = "ID:";
			// 
			// _lblCompanyData_6
			// 
			_lblCompanyData_6.AllowDrop = true;
			_lblCompanyData_6.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyData_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyData_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyData_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyData_6.Location = new System.Drawing.Point(8, 32);
			_lblCompanyData_6.MinimumSize = new System.Drawing.Size(33, 17);
			_lblCompanyData_6.Name = "_lblCompanyData_6";
			_lblCompanyData_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyData_6.Size = new System.Drawing.Size(33, 17);
			_lblCompanyData_6.TabIndex = 252;
			_lblCompanyData_6.Text = "Name:";
			// 
			// _lblCompanyData_1
			// 
			_lblCompanyData_1.AllowDrop = true;
			_lblCompanyData_1.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyData_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyData_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyData_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyData_1.Location = new System.Drawing.Point(56, 64);
			_lblCompanyData_1.MinimumSize = new System.Drawing.Size(345, 17);
			_lblCompanyData_1.Name = "_lblCompanyData_1";
			_lblCompanyData_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyData_1.Size = new System.Drawing.Size(345, 17);
			_lblCompanyData_1.TabIndex = 229;
			_lblCompanyData_1.Text = "MainCompID";
			// 
			// _lblCompanyData_0
			// 
			_lblCompanyData_0.AllowDrop = true;
			_lblCompanyData_0.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyData_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyData_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyData_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyData_0.Location = new System.Drawing.Point(56, 32);
			_lblCompanyData_0.MinimumSize = new System.Drawing.Size(137, 33);
			_lblCompanyData_0.Name = "_lblCompanyData_0";
			_lblCompanyData_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyData_0.Size = new System.Drawing.Size(137, 33);
			_lblCompanyData_0.TabIndex = 228;
			_lblCompanyData_0.Text = "compName";
			// 
			// pnlEFIG_Add_Group
			// 
			pnlEFIG_Add_Group.AllowDrop = true;
			pnlEFIG_Add_Group.Controls.Add(txtFG_PID);
			pnlEFIG_Add_Group.Controls.Add(txtFIG_Name);
			pnlEFIG_Add_Group.Controls.Add(cmdExit_AddFG);
			pnlEFIG_Add_Group.Controls.Add(cmdAdd_FG);
			pnlEFIG_Add_Group.Controls.Add(_Label1_21);
			pnlEFIG_Add_Group.Controls.Add(_lblFIName_0);
			pnlEFIG_Add_Group.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlEFIG_Add_Group.Location = new System.Drawing.Point(760, 236);
			pnlEFIG_Add_Group.Name = "pnlEFIG_Add_Group";
			pnlEFIG_Add_Group.Size = new System.Drawing.Size(193, 129);
			pnlEFIG_Add_Group.TabIndex = 210;
			pnlEFIG_Add_Group.Text = "Add Company Info";
			// 
			// txtFG_PID
			// 
			txtFG_PID.AcceptsReturn = true;
			txtFG_PID.AllowDrop = true;
			txtFG_PID.BackColor = System.Drawing.SystemColors.Window;
			txtFG_PID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtFG_PID.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtFG_PID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtFG_PID.ForeColor = System.Drawing.SystemColors.WindowText;
			txtFG_PID.Location = new System.Drawing.Point(64, 56);
			txtFG_PID.MaxLength = 0;
			txtFG_PID.Name = "txtFG_PID";
			txtFG_PID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtFG_PID.Size = new System.Drawing.Size(117, 20);
			txtFG_PID.TabIndex = 214;
			txtFG_PID.TextChanged += new System.EventHandler(txtFG_PID_TextChanged);
			// 
			// txtFIG_Name
			// 
			txtFIG_Name.AcceptsReturn = true;
			txtFIG_Name.AllowDrop = true;
			txtFIG_Name.BackColor = System.Drawing.SystemColors.Window;
			txtFIG_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtFIG_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtFIG_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtFIG_Name.ForeColor = System.Drawing.SystemColors.WindowText;
			txtFIG_Name.Location = new System.Drawing.Point(64, 32);
			txtFIG_Name.MaxLength = 0;
			txtFIG_Name.Name = "txtFIG_Name";
			txtFIG_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtFIG_Name.Size = new System.Drawing.Size(117, 20);
			txtFIG_Name.TabIndex = 213;
			// 
			// cmdExit_AddFG
			// 
			cmdExit_AddFG.AllowDrop = true;
			cmdExit_AddFG.BackColor = System.Drawing.SystemColors.Control;
			cmdExit_AddFG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdExit_AddFG.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdExit_AddFG.Location = new System.Drawing.Point(80, 80);
			cmdExit_AddFG.Name = "cmdExit_AddFG";
			cmdExit_AddFG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdExit_AddFG.Size = new System.Drawing.Size(65, 25);
			cmdExit_AddFG.TabIndex = 212;
			cmdExit_AddFG.Text = "Cancel";
			cmdExit_AddFG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdExit_AddFG.UseVisualStyleBackColor = false;
			cmdExit_AddFG.Click += new System.EventHandler(cmdExit_AddFG_Click);
			// 
			// cmdAdd_FG
			// 
			cmdAdd_FG.AllowDrop = true;
			cmdAdd_FG.BackColor = System.Drawing.SystemColors.Control;
			cmdAdd_FG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAdd_FG.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAdd_FG.Location = new System.Drawing.Point(8, 80);
			cmdAdd_FG.Name = "cmdAdd_FG";
			cmdAdd_FG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAdd_FG.Size = new System.Drawing.Size(65, 25);
			cmdAdd_FG.TabIndex = 211;
			cmdAdd_FG.Text = "Add";
			cmdAdd_FG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAdd_FG.UseVisualStyleBackColor = false;
			cmdAdd_FG.Click += new System.EventHandler(cmdAdd_FG_Click);
			// 
			// _Label1_21
			// 
			_Label1_21.AllowDrop = true;
			_Label1_21.BackColor = System.Drawing.SystemColors.Control;
			_Label1_21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_21.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_21.Location = new System.Drawing.Point(8, 56);
			_Label1_21.MinimumSize = new System.Drawing.Size(57, 17);
			_Label1_21.Name = "_Label1_21";
			_Label1_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_21.Size = new System.Drawing.Size(57, 17);
			_Label1_21.TabIndex = 216;
			_Label1_21.Text = "Primary ID:";
			_Label1_21.Click += new System.EventHandler(Label1_Click);
			// 
			// _lblFIName_0
			// 
			_lblFIName_0.AllowDrop = true;
			_lblFIName_0.BackColor = System.Drawing.SystemColors.Control;
			_lblFIName_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblFIName_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblFIName_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblFIName_0.Location = new System.Drawing.Point(7, 32);
			_lblFIName_0.MinimumSize = new System.Drawing.Size(81, 17);
			_lblFIName_0.Name = "_lblFIName_0";
			_lblFIName_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblFIName_0.Size = new System.Drawing.Size(81, 17);
			_lblFIName_0.TabIndex = 215;
			_lblFIName_0.Text = "Name:";
			// 
			// _tab_Lookup_TabPage15
			// 
			_tab_Lookup_TabPage15.Controls.Add(_Label43_2);
			_tab_Lookup_TabPage15.Controls.Add(_Label43_3);
			_tab_Lookup_TabPage15.Controls.Add(_Label43_4);
			_tab_Lookup_TabPage15.Controls.Add(_Label43_6);
			_tab_Lookup_TabPage15.Controls.Add(_Label43_5);
			_tab_Lookup_TabPage15.Controls.Add(_FG_Array_0);
			_tab_Lookup_TabPage15.Controls.Add(_cmd_CIC_0);
			_tab_Lookup_TabPage15.Controls.Add(_cmd_CIC_1);
			_tab_Lookup_TabPage15.Controls.Add(_cmd_CIC_2);
			_tab_Lookup_TabPage15.Controls.Add(_cboEFIG_SelectGroup_1);
			_tab_Lookup_TabPage15.Controls.Add(_txtCIC_0);
			_tab_Lookup_TabPage15.Controls.Add(_txtCIC_2);
			_tab_Lookup_TabPage15.Controls.Add(_cboEFIG_SelectGroup_2);
			_tab_Lookup_TabPage15.Controls.Add(_cmd_CIC_3);
			_tab_Lookup_TabPage15.Controls.Add(_txtCIC_1);
			_tab_Lookup_TabPage15.Controls.Add(_cmd_CIC_4);
			_tab_Lookup_TabPage15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage15.Text = "Company Industry Codes";
			// 
			// _Label43_2
			// 
			_Label43_2.AllowDrop = true;
			_Label43_2.BackColor = System.Drawing.SystemColors.Control;
			_Label43_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label43_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label43_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label43_2.Location = new System.Drawing.Point(677, 66);
			_Label43_2.MinimumSize = new System.Drawing.Size(89, 13);
			_Label43_2.Name = "_Label43_2";
			_Label43_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label43_2.Size = new System.Drawing.Size(89, 13);
			_Label43_2.TabIndex = 267;
			_Label43_2.Text = "Add A New Group:";
			// 
			// _Label43_3
			// 
			_Label43_3.AllowDrop = true;
			_Label43_3.BackColor = System.Drawing.SystemColors.Control;
			_Label43_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label43_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label43_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label43_3.Location = new System.Drawing.Point(674, 116);
			_Label43_3.MinimumSize = new System.Drawing.Size(27, 13);
			_Label43_3.Name = "_Label43_3";
			_Label43_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label43_3.Size = new System.Drawing.Size(27, 13);
			_Label43_3.TabIndex = 269;
			_Label43_3.Text = "Code:";
			// 
			// _Label43_4
			// 
			_Label43_4.AllowDrop = true;
			_Label43_4.BackColor = System.Drawing.SystemColors.Control;
			_Label43_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label43_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label43_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label43_4.Location = new System.Drawing.Point(675, 90);
			_Label43_4.MinimumSize = new System.Drawing.Size(31, 13);
			_Label43_4.Name = "_Label43_4";
			_Label43_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label43_4.Size = new System.Drawing.Size(31, 13);
			_Label43_4.TabIndex = 270;
			_Label43_4.Text = "Group:";
			// 
			// _Label43_6
			// 
			_Label43_6.AllowDrop = true;
			_Label43_6.BackColor = System.Drawing.SystemColors.Control;
			_Label43_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label43_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label43_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label43_6.Location = new System.Drawing.Point(673, 163);
			_Label43_6.MinimumSize = new System.Drawing.Size(56, 13);
			_Label43_6.Name = "_Label43_6";
			_Label43_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label43_6.Size = new System.Drawing.Size(56, 13);
			_Label43_6.TabIndex = 271;
			_Label43_6.Text = "Description:";
			// 
			// _Label43_5
			// 
			_Label43_5.AllowDrop = true;
			_Label43_5.BackColor = System.Drawing.SystemColors.Control;
			_Label43_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label43_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label43_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label43_5.Location = new System.Drawing.Point(674, 140);
			_Label43_5.MinimumSize = new System.Drawing.Size(56, 13);
			_Label43_5.Name = "_Label43_5";
			_Label43_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label43_5.Size = new System.Drawing.Size(56, 13);
			_Label43_5.TabIndex = 281;
			_Label43_5.Text = "Name:";
			// 
			// _FG_Array_0
			// 
			_FG_Array_0.AllowDrop = true;
			_FG_Array_0.AllowUserToAddRows = false;
			_FG_Array_0.AllowUserToDeleteRows = false;
			_FG_Array_0.AllowUserToResizeColumns = false;
			_FG_Array_0.AllowUserToResizeRows = false;
			_FG_Array_0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			_FG_Array_0.ColumnsCount = 2;
			_FG_Array_0.FixedColumns = 0;
			_FG_Array_0.FixedRows = 1;
			_FG_Array_0.Location = new System.Drawing.Point(16, 66);
			_FG_Array_0.Name = "_FG_Array_0";
			_FG_Array_0.ReadOnly = true;
			_FG_Array_0.RowsCount = 2;
			_FG_Array_0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			_FG_Array_0.ShowCellToolTips = false;
			_FG_Array_0.Size = new System.Drawing.Size(656, 525);
			_FG_Array_0.StandardTab = true;
			_FG_Array_0.TabIndex = 268;
			_FG_Array_0.Click += new System.EventHandler(FG_Array_Click);
			// 
			// _cmd_CIC_0
			// 
			_cmd_CIC_0.AllowDrop = true;
			_cmd_CIC_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_CIC_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_CIC_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_CIC_0.Location = new System.Drawing.Point(680, 265);
			_cmd_CIC_0.Name = "_cmd_CIC_0";
			_cmd_CIC_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_CIC_0.Size = new System.Drawing.Size(54, 18);
			_cmd_CIC_0.TabIndex = 278;
			_cmd_CIC_0.Text = "Add";
			_cmd_CIC_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_CIC_0.UseVisualStyleBackColor = false;
			_cmd_CIC_0.Click += new System.EventHandler(cmd_CIC_Click);
			// 
			// _cmd_CIC_1
			// 
			_cmd_CIC_1.AllowDrop = true;
			_cmd_CIC_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_CIC_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_CIC_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_CIC_1.Location = new System.Drawing.Point(742, 264);
			_cmd_CIC_1.Name = "_cmd_CIC_1";
			_cmd_CIC_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_CIC_1.Size = new System.Drawing.Size(54, 18);
			_cmd_CIC_1.TabIndex = 279;
			_cmd_CIC_1.Text = "Delete";
			_cmd_CIC_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_CIC_1.UseVisualStyleBackColor = false;
			_cmd_CIC_1.Click += new System.EventHandler(cmd_CIC_Click);
			// 
			// _cmd_CIC_2
			// 
			_cmd_CIC_2.AllowDrop = true;
			_cmd_CIC_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_CIC_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_CIC_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_CIC_2.Location = new System.Drawing.Point(803, 265);
			_cmd_CIC_2.Name = "_cmd_CIC_2";
			_cmd_CIC_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_CIC_2.Size = new System.Drawing.Size(54, 18);
			_cmd_CIC_2.TabIndex = 280;
			_cmd_CIC_2.Text = "Update";
			_cmd_CIC_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_CIC_2.UseVisualStyleBackColor = false;
			_cmd_CIC_2.Click += new System.EventHandler(cmd_CIC_Click);
			// 
			// _cboEFIG_SelectGroup_1
			// 
			_cboEFIG_SelectGroup_1.AllowDrop = true;
			_cboEFIG_SelectGroup_1.BackColor = System.Drawing.SystemColors.Window;
			_cboEFIG_SelectGroup_1.CausesValidation = true;
			_cboEFIG_SelectGroup_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboEFIG_SelectGroup_1.Enabled = true;
			_cboEFIG_SelectGroup_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboEFIG_SelectGroup_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboEFIG_SelectGroup_1.IntegralHeight = true;
			_cboEFIG_SelectGroup_1.Location = new System.Drawing.Point(14, 28);
			_cboEFIG_SelectGroup_1.Name = "_cboEFIG_SelectGroup_1";
			_cboEFIG_SelectGroup_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboEFIG_SelectGroup_1.Size = new System.Drawing.Size(201, 21);
			_cboEFIG_SelectGroup_1.Sorted = false;
			_cboEFIG_SelectGroup_1.TabIndex = 272;
			_cboEFIG_SelectGroup_1.TabStop = true;
			_cboEFIG_SelectGroup_1.Visible = true;
			_cboEFIG_SelectGroup_1.SelectionChangeCommitted += new System.EventHandler(cboEFIG_SelectGroup_SelectionChangeCommitted);
			// 
			// _txtCIC_0
			// 
			_txtCIC_0.AcceptsReturn = true;
			_txtCIC_0.AllowDrop = true;
			_txtCIC_0.BackColor = System.Drawing.SystemColors.Window;
			_txtCIC_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtCIC_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtCIC_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtCIC_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtCIC_0.Location = new System.Drawing.Point(735, 112);
			_txtCIC_0.MaxLength = 0;
			_txtCIC_0.Name = "_txtCIC_0";
			_txtCIC_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtCIC_0.Size = new System.Drawing.Size(39, 19);
			_txtCIC_0.TabIndex = 275;
			// 
			// _txtCIC_2
			// 
			_txtCIC_2.AcceptsReturn = true;
			_txtCIC_2.AllowDrop = true;
			_txtCIC_2.BackColor = System.Drawing.SystemColors.Window;
			_txtCIC_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtCIC_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtCIC_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtCIC_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtCIC_2.Location = new System.Drawing.Point(736, 160);
			_txtCIC_2.MaxLength = 400;
			_txtCIC_2.Multiline = true;
			_txtCIC_2.Name = "_txtCIC_2";
			_txtCIC_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtCIC_2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			_txtCIC_2.Size = new System.Drawing.Size(214, 95);
			_txtCIC_2.TabIndex = 277;
			// 
			// _cboEFIG_SelectGroup_2
			// 
			_cboEFIG_SelectGroup_2.AllowDrop = true;
			_cboEFIG_SelectGroup_2.BackColor = System.Drawing.SystemColors.Window;
			_cboEFIG_SelectGroup_2.CausesValidation = true;
			_cboEFIG_SelectGroup_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboEFIG_SelectGroup_2.Enabled = true;
			_cboEFIG_SelectGroup_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboEFIG_SelectGroup_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboEFIG_SelectGroup_2.IntegralHeight = true;
			_cboEFIG_SelectGroup_2.Location = new System.Drawing.Point(735, 85);
			_cboEFIG_SelectGroup_2.Name = "_cboEFIG_SelectGroup_2";
			_cboEFIG_SelectGroup_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboEFIG_SelectGroup_2.Size = new System.Drawing.Size(214, 21);
			_cboEFIG_SelectGroup_2.Sorted = false;
			_cboEFIG_SelectGroup_2.TabIndex = 274;
			_cboEFIG_SelectGroup_2.TabStop = true;
			_cboEFIG_SelectGroup_2.Visible = true;
			_cboEFIG_SelectGroup_2.SelectionChangeCommitted += new System.EventHandler(cboEFIG_SelectGroup_SelectionChangeCommitted);
			// 
			// _cmd_CIC_3
			// 
			_cmd_CIC_3.AllowDrop = true;
			_cmd_CIC_3.BackColor = System.Drawing.SystemColors.Control;
			_cmd_CIC_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_CIC_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_CIC_3.Location = new System.Drawing.Point(776, 61);
			_cmd_CIC_3.Name = "_cmd_CIC_3";
			_cmd_CIC_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_CIC_3.Size = new System.Drawing.Size(54, 18);
			_cmd_CIC_3.TabIndex = 273;
			_cmd_CIC_3.Text = "New";
			_cmd_CIC_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_CIC_3.UseVisualStyleBackColor = false;
			_cmd_CIC_3.Click += new System.EventHandler(cmd_CIC_Click);
			// 
			// _txtCIC_1
			// 
			_txtCIC_1.AcceptsReturn = true;
			_txtCIC_1.AllowDrop = true;
			_txtCIC_1.BackColor = System.Drawing.SystemColors.Window;
			_txtCIC_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtCIC_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtCIC_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtCIC_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtCIC_1.Location = new System.Drawing.Point(736, 134);
			_txtCIC_1.MaxLength = 0;
			_txtCIC_1.Name = "_txtCIC_1";
			_txtCIC_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtCIC_1.Size = new System.Drawing.Size(211, 19);
			_txtCIC_1.TabIndex = 276;
			// 
			// _cmd_CIC_4
			// 
			_cmd_CIC_4.AllowDrop = true;
			_cmd_CIC_4.BackColor = System.Drawing.SystemColors.Control;
			_cmd_CIC_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_CIC_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_CIC_4.Location = new System.Drawing.Point(840, 61);
			_cmd_CIC_4.Name = "_cmd_CIC_4";
			_cmd_CIC_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_CIC_4.Size = new System.Drawing.Size(54, 18);
			_cmd_CIC_4.TabIndex = 282;
			_cmd_CIC_4.Text = "Cancel";
			_cmd_CIC_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_CIC_4.UseVisualStyleBackColor = false;
			_cmd_CIC_4.Click += new System.EventHandler(cmd_CIC_Click);
			// 
			// _tab_Lookup_TabPage16
			// 
			_tab_Lookup_TabPage16.Controls.Add(_frmRegion_0);
			_tab_Lookup_TabPage16.Controls.Add(_frmRegion_1);
			_tab_Lookup_TabPage16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Lookup_TabPage16.Text = "Region";
			// 
			// _frmRegion_0
			// 
			_frmRegion_0.AllowDrop = true;
			_frmRegion_0.BackColor = System.Drawing.SystemColors.Control;
			_frmRegion_0.Controls.Add(FG_Region);
			_frmRegion_0.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			_frmRegion_0.Enabled = true;
			_frmRegion_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_frmRegion_0.ForeColor = System.Drawing.Color.Blue;
			_frmRegion_0.Location = new System.Drawing.Point(16, 12);
			_frmRegion_0.Name = "_frmRegion_0";
			_frmRegion_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_frmRegion_0.Size = new System.Drawing.Size(931, 481);
			_frmRegion_0.TabIndex = 309;
			_frmRegion_0.Text = "Region";
			_frmRegion_0.Visible = true;
			_frmRegion_0.Click += new System.EventHandler(frmRegion_Click);
			// 
			// FG_Region
			// 
			FG_Region.AllowDrop = true;
			FG_Region.AllowUserToAddRows = false;
			FG_Region.AllowUserToDeleteRows = false;
			FG_Region.AllowUserToResizeColumns = false;
			FG_Region.AllowUserToResizeRows = false;
			FG_Region.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Region.ColumnsCount = 2;
			FG_Region.FixedColumns = 1;
			FG_Region.FixedRows = 1;
			FG_Region.Location = new System.Drawing.Point(10, 20);
			FG_Region.Name = "FG_Region";
			FG_Region.ReadOnly = true;
			FG_Region.RowsCount = 2;
			FG_Region.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			FG_Region.ShowCellToolTips = false;
			FG_Region.Size = new System.Drawing.Size(909, 453);
			FG_Region.StandardTab = true;
			FG_Region.TabIndex = 310;
			FG_Region.Click += new System.EventHandler(FG_Region_Click);
			// 
			// _frmRegion_1
			// 
			_frmRegion_1.AllowDrop = true;
			_frmRegion_1.BackColor = System.Drawing.SystemColors.Control;
			_frmRegion_1.Controls.Add(txtRegionSourceURL);
			_frmRegion_1.Controls.Add(txtRegionName);
			_frmRegion_1.Controls.Add(_cmdSaveNew_1);
			_frmRegion_1.Controls.Add(_cmdSaveNew_0);
			_frmRegion_1.Controls.Add(lblLoadingRegion);
			_frmRegion_1.Controls.Add(_Label1_49);
			_frmRegion_1.Controls.Add(_Label1_48);
			_frmRegion_1.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			_frmRegion_1.Enabled = true;
			_frmRegion_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_frmRegion_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_frmRegion_1.Location = new System.Drawing.Point(16, 498);
			_frmRegion_1.Name = "_frmRegion_1";
			_frmRegion_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_frmRegion_1.Size = new System.Drawing.Size(931, 71);
			_frmRegion_1.TabIndex = 315;
			_frmRegion_1.Visible = true;
			_frmRegion_1.Click += new System.EventHandler(frmRegion_Click);
			// 
			// txtRegionSourceURL
			// 
			txtRegionSourceURL.AcceptsReturn = true;
			txtRegionSourceURL.AllowDrop = true;
			txtRegionSourceURL.BackColor = System.Drawing.SystemColors.Window;
			txtRegionSourceURL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtRegionSourceURL.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtRegionSourceURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtRegionSourceURL.ForeColor = System.Drawing.SystemColors.WindowText;
			txtRegionSourceURL.Location = new System.Drawing.Point(98, 42);
			txtRegionSourceURL.MaxLength = 200;
			txtRegionSourceURL.Name = "txtRegionSourceURL";
			txtRegionSourceURL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtRegionSourceURL.Size = new System.Drawing.Size(669, 23);
			txtRegionSourceURL.TabIndex = 312;
			// 
			// txtRegionName
			// 
			txtRegionName.AcceptsReturn = true;
			txtRegionName.AllowDrop = true;
			txtRegionName.BackColor = System.Drawing.SystemColors.Window;
			txtRegionName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtRegionName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtRegionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtRegionName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtRegionName.Location = new System.Drawing.Point(98, 16);
			txtRegionName.MaxLength = 50;
			txtRegionName.Name = "txtRegionName";
			txtRegionName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtRegionName.Size = new System.Drawing.Size(305, 23);
			txtRegionName.TabIndex = 311;
			// 
			// _cmdSaveNew_1
			// 
			_cmdSaveNew_1.AllowDrop = true;
			_cmdSaveNew_1.BackColor = System.Drawing.SystemColors.Control;
			_cmdSaveNew_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSaveNew_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSaveNew_1.Location = new System.Drawing.Point(866, 42);
			_cmdSaveNew_1.Name = "_cmdSaveNew_1";
			_cmdSaveNew_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSaveNew_1.Size = new System.Drawing.Size(47, 21);
			_cmdSaveNew_1.TabIndex = 314;
			_cmdSaveNew_1.Text = "New";
			_cmdSaveNew_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSaveNew_1.UseVisualStyleBackColor = false;
			_cmdSaveNew_1.Click += new System.EventHandler(cmdSaveNew_Click);
			// 
			// _cmdSaveNew_0
			// 
			_cmdSaveNew_0.AllowDrop = true;
			_cmdSaveNew_0.BackColor = System.Drawing.SystemColors.Control;
			_cmdSaveNew_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSaveNew_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSaveNew_0.Location = new System.Drawing.Point(866, 16);
			_cmdSaveNew_0.Name = "_cmdSaveNew_0";
			_cmdSaveNew_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSaveNew_0.Size = new System.Drawing.Size(47, 21);
			_cmdSaveNew_0.TabIndex = 313;
			_cmdSaveNew_0.Text = "Save";
			_cmdSaveNew_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSaveNew_0.UseVisualStyleBackColor = false;
			_cmdSaveNew_0.Click += new System.EventHandler(cmdSaveNew_Click);
			// 
			// lblLoadingRegion
			// 
			lblLoadingRegion.AllowDrop = true;
			lblLoadingRegion.BackColor = System.Drawing.SystemColors.Control;
			lblLoadingRegion.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblLoadingRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLoadingRegion.ForeColor = System.Drawing.SystemColors.ControlText;
			lblLoadingRegion.Location = new System.Drawing.Point(582, 20);
			lblLoadingRegion.MinimumSize = new System.Drawing.Size(183, 15);
			lblLoadingRegion.Name = "lblLoadingRegion";
			lblLoadingRegion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLoadingRegion.Size = new System.Drawing.Size(183, 15);
			lblLoadingRegion.TabIndex = 319;
			lblLoadingRegion.Text = "Loading ##,### of ##,### Records";
			// 
			// _Label1_49
			// 
			_Label1_49.AllowDrop = true;
			_Label1_49.BackColor = System.Drawing.SystemColors.Control;
			_Label1_49.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_49.ForeColor = System.Drawing.Color.Blue;
			_Label1_49.Location = new System.Drawing.Point(10, 44);
			_Label1_49.MinimumSize = new System.Drawing.Size(71, 17);
			_Label1_49.Name = "_Label1_49";
			_Label1_49.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_49.Size = new System.Drawing.Size(71, 17);
			_Label1_49.TabIndex = 317;
			_Label1_49.Text = "Source URL";
			_Label1_49.Click += new System.EventHandler(Label1_Click);
			// 
			// _Label1_48
			// 
			_Label1_48.AllowDrop = true;
			_Label1_48.BackColor = System.Drawing.SystemColors.Control;
			_Label1_48.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_48.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_48.Location = new System.Drawing.Point(10, 20);
			_Label1_48.MinimumSize = new System.Drawing.Size(71, 17);
			_Label1_48.Name = "_Label1_48";
			_Label1_48.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_48.Size = new System.Drawing.Size(71, 17);
			_Label1_48.TabIndex = 316;
			_Label1_48.Text = "Region Name";
			_Label1_48.Click += new System.EventHandler(Label1_Click);
			// 
			// frm_CompanyContactLookup
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(1086, 704);
			ControlBox = false;
			Controls.Add(tbr_ToolBar);
			Controls.Add(tab_Lookup);
			Controls.Add(lblLoading);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(152, 169);
			MaximizeBox = true;
			MinimizeBox = false;
			Name = "frm_CompanyContactLookup";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Company/Contact Lookup Table Maintenance";
			commandButtonHelper1.SetStyle(cmd_Save_CAT, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_CAT, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_CAT, 0);
			commandButtonHelper1.SetStyle(cmd_Add_CAT, 0);
			commandButtonHelper1.SetStyle(cmd_Add_GAT, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_GAT, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_GAT, 0);
			commandButtonHelper1.SetStyle(cmd_Save_GAT, 0);
			commandButtonHelper1.SetStyle(btn_search_bus_type_flags, 0);
			commandButtonHelper1.SetStyle(cmd_Add_CBT, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_CBT, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_CBT, 0);
			commandButtonHelper1.SetStyle(cmd_Save_CBT, 0);
			commandButtonHelper1.SetStyle(cmdRemoveBusGroup, 0);
			commandButtonHelper1.SetStyle(cmdAddBusGroup, 0);
			commandButtonHelper1.SetStyle(cmdRegNoUpdate, 0);
			commandButtonHelper1.SetStyle(cmdRegNoChange, 0);
			commandButtonHelper1.SetStyle(cmdRegNoDelete, 0);
			commandButtonHelper1.SetStyle(cmdAddRegno, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_Country, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Country, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Country, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Country, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_Language, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Language, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Language, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Language, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Currency, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_Currency, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_Currency, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Currency, 0);
			commandButtonHelper1.SetStyle(cmd_Add_CSN, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_CSN, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_CSN, 0);
			commandButtonHelper1.SetStyle(cmd_Save_CSN, 0);
			commandButtonHelper1.SetStyle(cmd_Add_CS, 0);
			commandButtonHelper1.SetStyle(cmd_Save_CS, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_CS, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_CS, 0);
			commandButtonHelper1.SetStyle(_cmd_contact_button_4, 0);
			commandButtonHelper1.SetStyle(_cmd_contact_button_3, 0);
			commandButtonHelper1.SetStyle(_cmd_contact_button_2, 0);
			commandButtonHelper1.SetStyle(cmd_Save_CT, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_CT, 0);
			commandButtonHelper1.SetStyle(_cmd_contact_button_5, 0);
			commandButtonHelper1.SetStyle(_cmd_contact_button_6, 0);
			commandButtonHelper1.SetStyle(_cmd_contact_button_0, 0);
			commandButtonHelper1.SetStyle(_cmd_contact_button_1, 0);
			commandButtonHelper1.SetStyle(_cmd_contact_button_8, 0);
			commandButtonHelper1.SetStyle(_cmd_contact_button_9, 0);
			commandButtonHelper1.SetStyle(_cmd_contact_button_7, 0);
			commandButtonHelper1.SetStyle(cmd_Add_PT, 0);
			commandButtonHelper1.SetStyle(cmd_Save_PT, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_PT, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_PT, 0);
			commandButtonHelper1.SetStyle(cmd_Save_State, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_State, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_State, 0);
			commandButtonHelper1.SetStyle(cmd_Add_State, 0);
			commandButtonHelper1.SetStyle(cmd_Delete_TZ, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel_TZ, 0);
			commandButtonHelper1.SetStyle(cmd_Save_TZ, 0);
			commandButtonHelper1.SetStyle(cmd_Add_TZ, 0);
			commandButtonHelper1.SetStyle(cmd_save_frac_PG, 0);
			commandButtonHelper1.SetStyle(cmd_cancel_FracPG, 0);
			commandButtonHelper1.SetStyle(cmd_delete_fracPG, 0);
			commandButtonHelper1.SetStyle(cmd_add_fracPG, 0);
			commandButtonHelper1.SetStyle(cmdFracRefresh, 0);
			commandButtonHelper1.SetStyle(cmdFracMerge, 0);
			commandButtonHelper1.SetStyle(cmdCancelMerge, 0);
			commandButtonHelper1.SetStyle(cmdMergeFractionals, 0);
			commandButtonHelper1.SetStyle(cmd_FindProgram, 0);
			commandButtonHelper1.SetStyle(cmdStopFrac, 0);
			commandButtonHelper1.SetStyle(cmdFracMemSearchCancel, 0);
			commandButtonHelper1.SetStyle(cmdMemSearch, 0);
			commandButtonHelper1.SetStyle(cmdFracMemDelete, 0);
			commandButtonHelper1.SetStyle(cmdCancelFracMem, 0);
			commandButtonHelper1.SetStyle(cmdSaveFracMember, 0);
			commandButtonHelper1.SetStyle(cmdAddFracMember, 0);
			commandButtonHelper1.SetStyle(cmd_Add_Parent_pnlEFIG_NIOL, 0);
			commandButtonHelper1.SetStyle(cmdFG_Home, 0);
			commandButtonHelper1.SetStyle(cmdNewSearch_pnlEFIG_NIOL, 0);
			commandButtonHelper1.SetStyle(cmdAdd_CompRef, 0);
			commandButtonHelper1.SetStyle(cmd_ASP_dot_Net, 0);
			commandButtonHelper1.SetStyle(_cmdSearch_Compy_wDate_0, 0);
			commandButtonHelper1.SetStyle(cmdViewNIOL, 0);
			commandButtonHelper1.SetStyle(cmdAddEFIG, 0);
			commandButtonHelper1.SetStyle(cmdDelete_EFIG, 0);
			commandButtonHelper1.SetStyle(cmdExit_pnlEFIG_Delete, 0);
			commandButtonHelper1.SetStyle(cmdExit_AddFG, 0);
			commandButtonHelper1.SetStyle(cmdAdd_FG, 0);
			commandButtonHelper1.SetStyle(_cmd_CIC_0, 0);
			commandButtonHelper1.SetStyle(_cmd_CIC_1, 0);
			commandButtonHelper1.SetStyle(_cmd_CIC_2, 0);
			commandButtonHelper1.SetStyle(_cmd_CIC_3, 0);
			commandButtonHelper1.SetStyle(_cmd_CIC_4, 0);
			commandButtonHelper1.SetStyle(_cmdSaveNew_1, 0);
			commandButtonHelper1.SetStyle(_cmdSaveNew_0, 0);
			listBoxComboBoxHelper1.SetItemData(cmbDialLineAccessCode, new int[]{7, 5});
			listBoxHelper1.SetSelectionMode(lstBusType, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lstAllBusType, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(RegNoList, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lstTitleGroup, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lstAllTitleGroups, System.Windows.Forms.SelectionMode.MultiExtended);
			optionButtonHelper1.SetStyle(_opt_contact_title_0, 0);
			optionButtonHelper1.SetStyle(_opt_contact_title_1, 0);
			optionButtonHelper1.SetStyle(_opt_contact_title_2, 0);
			ToolTipMain.SetToolTip(_Label1_26, "Click To View Website of Country Codes and Abbreviations");
			ToolTipMain.SetToolTip(_frmRegion_0, "Click To Export Grid To Excel");
			ToolTipMain.SetToolTip(_Label1_49, "Click To Open URL In Browser");
			UpgradeHelpers.Gui.Controls.SSTabHelper.SetSelectedIndex(tab_contact_title, 1);
			Activated += new System.EventHandler(frm_CompanyContactLookup_Activated);
			Closed += new System.EventHandler(Form_Closed);
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_FormClosing);
			((System.ComponentModel.ISupportInitialize) FG_Cat_List).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_CompAgency).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_CBTList).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Country).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Language).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Currency).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Contact_SirName).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Contact_Suffix).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Contact_Title).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Contact_Title_New).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_titles_in_group).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Phone_Type).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_State).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_TimeZone).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_FracPrograms).EndInit();
			((System.ComponentModel.ISupportInitialize) grdMemSearch).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_ProgCompany).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_EFIG_NIOL).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_EFIG_MC).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_RelatedCompanies).EndInit();
			((System.ComponentModel.ISupportInitialize) _FG_Array_0).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_Region).EndInit();
			((System.ComponentModel.ISupportInitialize) listBoxComboBoxHelper1).EndInit();
			tbr_ToolBar.ResumeLayout(false);
			tbr_ToolBar.PerformLayout();
			tab_Lookup.ResumeLayout(false);
			tab_Lookup.PerformLayout();
			_tab_Lookup_TabPage0.ResumeLayout(false);
			_tab_Lookup_TabPage0.PerformLayout();
			pnl_CAT_AddUpdate.ResumeLayout(false);
			pnl_CAT_AddUpdate.PerformLayout();
			_tab_Lookup_TabPage1.ResumeLayout(false);
			_tab_Lookup_TabPage1.PerformLayout();
			pnl_GAT_AddUpdate.ResumeLayout(false);
			pnl_GAT_AddUpdate.PerformLayout();
			_tab_Lookup_TabPage2.ResumeLayout(false);
			_tab_Lookup_TabPage2.PerformLayout();
			pnl_CBT_AddUpdate.ResumeLayout(false);
			pnl_CBT_AddUpdate.PerformLayout();
			pnl_BusGroup.ResumeLayout(false);
			pnl_BusGroup.PerformLayout();
			_tab_Lookup_TabPage3.ResumeLayout(false);
			_tab_Lookup_TabPage3.PerformLayout();
			pnl_Country_AddUpdate.ResumeLayout(false);
			pnl_Country_AddUpdate.PerformLayout();
			_tab_Lookup_TabPage4.ResumeLayout(false);
			_tab_Lookup_TabPage4.PerformLayout();
			pnl_Language_AddUpdate.ResumeLayout(false);
			pnl_Language_AddUpdate.PerformLayout();
			_tab_Lookup_TabPage5.ResumeLayout(false);
			_tab_Lookup_TabPage5.PerformLayout();
			pnl_Currency_Change.ResumeLayout(false);
			pnl_Currency_Change.PerformLayout();
			_tab_Lookup_TabPage6.ResumeLayout(false);
			_tab_Lookup_TabPage6.PerformLayout();
			pnl_CSN_AddUpdate.ResumeLayout(false);
			pnl_CSN_AddUpdate.PerformLayout();
			_tab_Lookup_TabPage7.ResumeLayout(false);
			_tab_Lookup_TabPage7.PerformLayout();
			pnl_CS_AddUpdate.ResumeLayout(false);
			pnl_CS_AddUpdate.PerformLayout();
			_tab_Lookup_TabPage8.ResumeLayout(false);
			_tab_Lookup_TabPage8.PerformLayout();
			tab_contact_title.ResumeLayout(false);
			tab_contact_title.PerformLayout();
			_tab_contact_title_TabPage0.ResumeLayout(false);
			_tab_contact_title_TabPage0.PerformLayout();
			pnl_ContactTitleGroup.ResumeLayout(false);
			pnl_ContactTitleGroup.PerformLayout();
			pnl_CT_AddUpdate.ResumeLayout(false);
			pnl_CT_AddUpdate.PerformLayout();
			frmTitleSearchOptions.ResumeLayout(false);
			frmTitleSearchOptions.PerformLayout();
			_tab_contact_title_TabPage1.ResumeLayout(false);
			_tab_contact_title_TabPage1.PerformLayout();
			frm_update_frame.ResumeLayout(false);
			frm_update_frame.PerformLayout();
			frm_update_group.ResumeLayout(false);
			frm_update_group.PerformLayout();
			_tab_Lookup_TabPage9.ResumeLayout(false);
			_tab_Lookup_TabPage9.PerformLayout();
			pnl_PT_AddUpdate.ResumeLayout(false);
			pnl_PT_AddUpdate.PerformLayout();
			_tab_Lookup_TabPage10.ResumeLayout(false);
			_tab_Lookup_TabPage10.PerformLayout();
			pnl_State_AddUpdate.ResumeLayout(false);
			pnl_State_AddUpdate.PerformLayout();
			_tab_Lookup_TabPage11.ResumeLayout(false);
			_tab_Lookup_TabPage11.PerformLayout();
			pnl_TZ_AddUpdate.ResumeLayout(false);
			pnl_TZ_AddUpdate.PerformLayout();
			_tab_Lookup_TabPage12.ResumeLayout(false);
			_tab_Lookup_TabPage12.PerformLayout();
			pnl_add_frac_Program.ResumeLayout(false);
			pnl_add_frac_Program.PerformLayout();
			pnl_Merge_Frac_Programs.ResumeLayout(false);
			pnl_Merge_Frac_Programs.PerformLayout();
			_tab_Lookup_TabPage13.ResumeLayout(false);
			_tab_Lookup_TabPage13.PerformLayout();
			pnl_new_FracMember.ResumeLayout(false);
			pnl_new_FracMember.PerformLayout();
			pnl_add_fracMember.ResumeLayout(false);
			pnl_add_fracMember.PerformLayout();
			_tab_Lookup_TabPage14.ResumeLayout(false);
			_tab_Lookup_TabPage14.PerformLayout();
			pnlEFIG_NIOL.ResumeLayout(false);
			pnlEFIG_NIOL.PerformLayout();
			pnl_EFIG.ResumeLayout(false);
			pnl_EFIG.PerformLayout();
			pnl_AddFinGroup.ResumeLayout(false);
			pnl_AddFinGroup.PerformLayout();
			tab_Lists.ResumeLayout(false);
			tab_Lists.PerformLayout();
			_tab_Lists_TabPage0.ResumeLayout(false);
			_tab_Lists_TabPage0.PerformLayout();
			_tab_Lists_TabPage1.ResumeLayout(false);
			_tab_Lists_TabPage1.PerformLayout();
			pnlEFIG_Delete.ResumeLayout(false);
			pnlEFIG_Delete.PerformLayout();
			pnlEFIG_Add_Group.ResumeLayout(false);
			pnlEFIG_Add_Group.PerformLayout();
			_tab_Lookup_TabPage15.ResumeLayout(false);
			_tab_Lookup_TabPage15.PerformLayout();
			_tab_Lookup_TabPage16.ResumeLayout(false);
			_tab_Lookup_TabPage16.PerformLayout();
			_frmRegion_0.ResumeLayout(false);
			_frmRegion_0.PerformLayout();
			_frmRegion_1.ResumeLayout(false);
			_frmRegion_1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			InitializevbCheck();
			Initializetxt_currency_name();
			Initializetxt_contact_title_search();
			InitializetxtViewOther();
			InitializetxtDateRange_pnlEFIG();
			InitializetxtCIC();
			Initializeopt_contact_title();
			InitializelblTotTitles();
			InitializelblStopTitleLoad();
			InitializelblNIOL_CompanyData();
			InitializelblFIName();
			InitializelblDialLineAccessCode();
			InitializelblCompanyData();
			InitializefrmRegion();
			Initializecmd_contact_button();
			Initializecmd_CIC();
			InitializecmdSearch_Compy_wDate();
			InitializecmdSaveNew();
			Initializechk_contact_title();
			InitializecboEFIG_SelectGroup();
			InitializeShape1();
			InitializeLine2();
			InitializeLabel7();
			InitializeLabel43();
			InitializeLabel17();
			InitializeLabel1();
			InitializeFG_Array();
			tab_LookupPreviousTab = tab_Lookup.SelectedIndex;
			tab_ListsPreviousTab = tab_Lists.SelectedIndex;
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = HomebaseAdministrator.mdi_AdminAssistant.DefInstance;
			HomebaseAdministrator.mdi_AdminAssistant.DefInstance.Show();
		}
		void InitializevbCheck()
		{
			vbCheck = new System.Windows.Forms.CheckBox[1];
			vbCheck[0] = _vbCheck_0;
		}
		void Initializetxt_currency_name()
		{
			txt_currency_name = new System.Windows.Forms.TextBox[6];
			txt_currency_name[5] = _txt_currency_name_5;
			txt_currency_name[4] = _txt_currency_name_4;
			txt_currency_name[3] = _txt_currency_name_3;
			txt_currency_name[2] = _txt_currency_name_2;
			txt_currency_name[1] = _txt_currency_name_1;
			txt_currency_name[0] = _txt_currency_name_0;
		}
		void Initializetxt_contact_title_search()
		{
			txt_contact_title_search = new System.Windows.Forms.TextBox[5];
			txt_contact_title_search[3] = _txt_contact_title_search_3;
			txt_contact_title_search[2] = _txt_contact_title_search_2;
			txt_contact_title_search[1] = _txt_contact_title_search_1;
			txt_contact_title_search[0] = _txt_contact_title_search_0;
			txt_contact_title_search[4] = _txt_contact_title_search_4;
		}
		void InitializetxtViewOther()
		{
			txtViewOther = new System.Windows.Forms.TextBox[3];
			txtViewOther[2] = _txtViewOther_2;
			txtViewOther[0] = _txtViewOther_0;
			txtViewOther[1] = _txtViewOther_1;
		}
		void InitializetxtDateRange_pnlEFIG()
		{
			txtDateRange_pnlEFIG = new System.Windows.Forms.TextBox[1];
			txtDateRange_pnlEFIG[0] = _txtDateRange_pnlEFIG_0;
		}
		void InitializetxtCIC()
		{
			txtCIC = new System.Windows.Forms.TextBox[3];
			txtCIC[1] = _txtCIC_1;
			txtCIC[2] = _txtCIC_2;
			txtCIC[0] = _txtCIC_0;
		}
		void Initializeopt_contact_title()
		{
			opt_contact_title = new System.Windows.Forms.RadioButton[3];
			opt_contact_title[2] = _opt_contact_title_2;
			opt_contact_title[1] = _opt_contact_title_1;
			opt_contact_title[0] = _opt_contact_title_0;
		}
		void InitializelblTotTitles()
		{
			lblTotTitles = new System.Windows.Forms.Label[3];
			lblTotTitles[2] = _lblTotTitles_2;
			lblTotTitles[1] = _lblTotTitles_1;
			lblTotTitles[0] = _lblTotTitles_0;
		}
		void InitializelblStopTitleLoad()
		{
			lblStopTitleLoad = new System.Windows.Forms.Label[2];
			lblStopTitleLoad[1] = _lblStopTitleLoad_1;
			lblStopTitleLoad[0] = _lblStopTitleLoad_0;
		}
		void InitializelblNIOL_CompanyData()
		{
			lblNIOL_CompanyData = new System.Windows.Forms.Label[26];
			lblNIOL_CompanyData[24] = _lblNIOL_CompanyData_24;
			lblNIOL_CompanyData[22] = _lblNIOL_CompanyData_22;
			lblNIOL_CompanyData[23] = _lblNIOL_CompanyData_23;
			lblNIOL_CompanyData[5] = _lblNIOL_CompanyData_5;
			lblNIOL_CompanyData[19] = _lblNIOL_CompanyData_19;
			lblNIOL_CompanyData[9] = _lblNIOL_CompanyData_9;
			lblNIOL_CompanyData[6] = _lblNIOL_CompanyData_6;
			lblNIOL_CompanyData[25] = _lblNIOL_CompanyData_25;
			lblNIOL_CompanyData[7] = _lblNIOL_CompanyData_7;
			lblNIOL_CompanyData[18] = _lblNIOL_CompanyData_18;
			lblNIOL_CompanyData[17] = _lblNIOL_CompanyData_17;
			lblNIOL_CompanyData[16] = _lblNIOL_CompanyData_16;
			lblNIOL_CompanyData[15] = _lblNIOL_CompanyData_15;
			lblNIOL_CompanyData[14] = _lblNIOL_CompanyData_14;
			lblNIOL_CompanyData[13] = _lblNIOL_CompanyData_13;
			lblNIOL_CompanyData[12] = _lblNIOL_CompanyData_12;
			lblNIOL_CompanyData[8] = _lblNIOL_CompanyData_8;
			lblNIOL_CompanyData[4] = _lblNIOL_CompanyData_4;
			lblNIOL_CompanyData[3] = _lblNIOL_CompanyData_3;
			lblNIOL_CompanyData[2] = _lblNIOL_CompanyData_2;
			lblNIOL_CompanyData[1] = _lblNIOL_CompanyData_1;
			lblNIOL_CompanyData[0] = _lblNIOL_CompanyData_0;
		}
		void InitializelblFIName()
		{
			lblFIName = new System.Windows.Forms.Label[1];
			lblFIName[0] = _lblFIName_0;
		}
		void InitializelblDialLineAccessCode()
		{
			lblDialLineAccessCode = new System.Windows.Forms.Label[47];
			lblDialLineAccessCode[46] = _lblDialLineAccessCode_46;
		}
		void InitializelblCompanyData()
		{
			lblCompanyData = new System.Windows.Forms.Label[12];
			lblCompanyData[5] = _lblCompanyData_5;
			lblCompanyData[2] = _lblCompanyData_2;
			lblCompanyData[11] = _lblCompanyData_11;
			lblCompanyData[10] = _lblCompanyData_10;
			lblCompanyData[7] = _lblCompanyData_7;
			lblCompanyData[6] = _lblCompanyData_6;
			lblCompanyData[1] = _lblCompanyData_1;
			lblCompanyData[0] = _lblCompanyData_0;
		}
		void InitializefrmRegion()
		{
			frmRegion = new System.Windows.Forms.GroupBox[2];
			frmRegion[1] = _frmRegion_1;
			frmRegion[0] = _frmRegion_0;
		}
		void Initializecmd_contact_button()
		{
			cmd_contact_button = new System.Windows.Forms.Button[10];
			cmd_contact_button[9] = _cmd_contact_button_9;
			cmd_contact_button[7] = _cmd_contact_button_7;
			cmd_contact_button[8] = _cmd_contact_button_8;
			cmd_contact_button[6] = _cmd_contact_button_6;
			cmd_contact_button[5] = _cmd_contact_button_5;
			cmd_contact_button[1] = _cmd_contact_button_1;
			cmd_contact_button[0] = _cmd_contact_button_0;
			cmd_contact_button[2] = _cmd_contact_button_2;
			cmd_contact_button[4] = _cmd_contact_button_4;
			cmd_contact_button[3] = _cmd_contact_button_3;
		}
		void Initializecmd_CIC()
		{
			cmd_CIC = new System.Windows.Forms.Button[5];
			cmd_CIC[4] = _cmd_CIC_4;
			cmd_CIC[3] = _cmd_CIC_3;
			cmd_CIC[2] = _cmd_CIC_2;
			cmd_CIC[1] = _cmd_CIC_1;
			cmd_CIC[0] = _cmd_CIC_0;
		}
		void InitializecmdSearch_Compy_wDate()
		{
			cmdSearch_Compy_wDate = new System.Windows.Forms.Button[1];
			cmdSearch_Compy_wDate[0] = _cmdSearch_Compy_wDate_0;
		}
		void InitializecmdSaveNew()
		{
			cmdSaveNew = new System.Windows.Forms.Button[2];
			cmdSaveNew[1] = _cmdSaveNew_1;
			cmdSaveNew[0] = _cmdSaveNew_0;
		}
		void Initializechk_contact_title()
		{
			chk_contact_title = new System.Windows.Forms.CheckBox[1];
			chk_contact_title[0] = _chk_contact_title_0;
		}
		void InitializecboEFIG_SelectGroup()
		{
			cboEFIG_SelectGroup = new System.Windows.Forms.ComboBox[3];
			cboEFIG_SelectGroup[2] = _cboEFIG_SelectGroup_2;
			cboEFIG_SelectGroup[1] = _cboEFIG_SelectGroup_1;
			cboEFIG_SelectGroup[0] = _cboEFIG_SelectGroup_0;
		}
		void InitializeShape1()
		{
			Shape1 = new UpgradeHelpers.Gui.ShapeHelper[2];
			Shape1[0] = _Shape1_0;
			Shape1[1] = _Shape1_1;
		}
		void InitializeLine2()
		{
			Line2 = new System.Windows.Forms.Label[2];
			Line2[1] = _Line2_1;
		}
		void InitializeLabel7()
		{
			Label7 = new System.Windows.Forms.Label[2];
			Label7[1] = _Label7_1;
			Label7[0] = _Label7_0;
		}
		void InitializeLabel43()
		{
			Label43 = new System.Windows.Forms.Label[7];
			Label43[5] = _Label43_5;
			Label43[6] = _Label43_6;
			Label43[4] = _Label43_4;
			Label43[3] = _Label43_3;
			Label43[2] = _Label43_2;
			Label43[1] = _Label43_1;
			Label43[0] = _Label43_0;
		}
		void InitializeLabel17()
		{
			Label17 = new System.Windows.Forms.Label[8];
			Label17[6] = _Label17_6;
			Label17[5] = _Label17_5;
			Label17[7] = _Label17_7;
			Label17[4] = _Label17_4;
			Label17[3] = _Label17_3;
			Label17[2] = _Label17_2;
			Label17[1] = _Label17_1;
			Label17[0] = _Label17_0;
		}
		void InitializeLabel1()
		{
			Label1 = new System.Windows.Forms.Label[55];
			Label1[52] = _Label1_52;
			Label1[13] = _Label1_13;
			Label1[11] = _Label1_11;
			Label1[12] = _Label1_12;
			Label1[53] = _Label1_53;
			Label1[54] = _Label1_54;
			Label1[51] = _Label1_51;
			Label1[50] = _Label1_50;
			Label1[46] = _Label1_46;
			Label1[47] = _Label1_47;
			Label1[49] = _Label1_49;
			Label1[48] = _Label1_48;
			Label1[45] = _Label1_45;
			Label1[44] = _Label1_44;
			Label1[43] = _Label1_43;
			Label1[42] = _Label1_42;
			Label1[41] = _Label1_41;
			Label1[23] = _Label1_23;
			Label1[17] = _Label1_17;
			Label1[16] = _Label1_16;
			Label1[20] = _Label1_20;
			Label1[18] = _Label1_18;
			Label1[19] = _Label1_19;
			Label1[40] = _Label1_40;
			Label1[39] = _Label1_39;
			Label1[36] = _Label1_36;
			Label1[35] = _Label1_35;
			Label1[34] = _Label1_34;
			Label1[33] = _Label1_33;
			Label1[24] = _Label1_24;
			Label1[25] = _Label1_25;
			Label1[27] = _Label1_27;
			Label1[28] = _Label1_28;
			Label1[29] = _Label1_29;
			Label1[30] = _Label1_30;
			Label1[26] = _Label1_26;
			Label1[32] = _Label1_32;
			Label1[31] = _Label1_31;
			Label1[22] = _Label1_22;
			Label1[15] = _Label1_15;
			Label1[14] = _Label1_14;
			Label1[2] = _Label1_2;
			Label1[0] = _Label1_0;
			Label1[1] = _Label1_1;
			Label1[7] = _Label1_7;
			Label1[3] = _Label1_3;
			Label1[4] = _Label1_4;
			Label1[5] = _Label1_5;
			Label1[6] = _Label1_6;
			Label1[9] = _Label1_9;
			Label1[8] = _Label1_8;
			Label1[10] = _Label1_10;
			Label1[37] = _Label1_37;
			Label1[38] = _Label1_38;
			Label1[21] = _Label1_21;
		}
		void InitializeFG_Array()
		{
			FG_Array = new UpgradeHelpers.DataGridViewFlex[1];
			FG_Array[0] = _FG_Array_0;
		}
		#endregion
	}
}