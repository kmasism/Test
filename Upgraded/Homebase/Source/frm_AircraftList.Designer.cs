
namespace JETNET_Homebase
{
	partial class frm_AircraftList
	{

		#region "Upgrade Support "
		private static frm_AircraftList m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_AircraftList DefInstance
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
		public static frm_AircraftList CreateInstance()
		{
			frm_AircraftList theInstance = new frm_AircraftList();
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
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileClose", "mnuFileLogout", "mnuFile", "mnuFractional", "mnuEdit", "mnuReport", "mnuAircraftListShowUserHistory", "mnuTools", "MainMenu1", "_Label2_0", "_Label2_1", "chk_prev", "_optNewUsed_3", "cboAirframeTypeCode", "cbo_ac_use_code", "cbo_ac_interior_config_search", "chkSerNbrExact", "txt_amod_number_of_engines", "cbo_engCompare", "_optNewUsed_2", "_optNewUsed_1", "_optNewUsed_0", "txtSerialNoTo", "txtEngSerNoTo", "txtEngSerNoFrom", "cboEMP", "cboMaintained", "cboWeightClass", "txtRegNo", "txtSerialNoFrom", "txtYear", "txtYear2", "cbo_ac_class", "lstMake", "lstType", "lstModel", "txtEngineModel", "cboEngineModel", "_chk_bx_product_codes_0", "_chk_bx_product_codes_3", "_chk_bx_product_codes_2", "_lbl_Class_3", "_lbl_Class_2", "_lbl_Class_1", "Line1", "Label8", "lblSerialTo", "lblTo", "lblFrom", "lblEngSerNo", "Label4", "lblEngineModel", "lblMaintained", "Label3", "lblRegNo", "lblSerialNo", "lblYears", "lblYearsTo", "_lbl_Class_0", "lblType", "lblMake", "lblModel", "fraClassification", "cbo_JournalCategory", "cbo_ContactType", "cmdHideTrans", "lblJournalCategory", "lblcontacttype", "frm_Transactions", "cbo_agency_type", "opt_CompanyContinent", "opt_CompanyRegion", "lst_CompanyArea", "cbo_Acc_Rep", "txtCompanyCity", "txtCompanyZip", "txtCompanyPhone", "cboBusinessType", "txtCompanyName", "lstCompanyTimeZone", "lstCompanyState", "lstCompanyCountry", "lstCompanyType", "_lblBusinessType_1", "lbl_AccRep", "lblCompanyCity", "lblCompanyZip", "lblCompanyPhone", "_lblBusinessType_0", "lblCompanyName", "lblCompanyTimeZone", "lblCompanyState", "lblCompanyCountry", "lblCompanyType", "fraCompanyDemographics", "txt_ac_status", "cmb_engine_noise_rating", "cmb_model_config", "cbo_ac_lifecycle_stage", "cboOwnType", "cboExclusive", "cboLeaseStatus", "cbo_ac_delivery", "cbo_ac_asking", "optNotForSale", "optForSale", "optAll", "_Label7_0", "Label6", "lbl_Stage", "lblOwnershipType", "lblExclusive", "lblLeaseStatus", "lbl_delivery", "lbl_asking", "lbl_ac_status", "fraStatus", "_cboUsage_4", "_cboUsageCondition_4", "_txtUsageValue_4", "_txtUsageValue_3", "_cboUsageCondition_3", "_cboUsage_3", "_cboUsage_0", "_cboUsageCondition_0", "_txtUsageValue_0", "_cboUsage_1", "_cboUsageCondition_1", "_txtUsageValue_1", "_txtUsageValue_2", "_cboUsageCondition_2", "_cboUsage_2", "_lblUsageFormat_4", "_lblUsageFormat_3", "_lblUsageFormat_2", "_lblUsageFormat_1", "_lblUsageFormat_0", "fraUsage", "chkCompanyFlag", "cmdClear", "txt_ac_id", "chkDontJumpToAircraft", "txt_ac_aport_faaid_code", "lst_State", "txt_ac_aport_city", "txt_ac_aport_iata_code", "txt_ac_aport_icao_code", "txt_ac_aport_name", "lst_Country", "lst_Area", "opt_Region", "opt_Continent", "lbl_FAAID", "Label20", "Label5", "lbl_IATA", "lbl_ICAO", "lbl_airport", "Label15", "frame_demographics", "txt_Journ_id", "chkTransactions", "chkDontRefreshList", "chk_include_not_researched", "_Tabs1_TabPage0", "lbl_Totfound", "_txt_gen_7", "_txt_gen_6", "_txt_gen_5", "_txt_gen_4", "cmdAircraftListExcelExport", "_txt_gen_0", "_txt_gen_3", "_txt_gen_2", "_txt_gen_1", "grdAircraft", "cmdStop", "cmd_SelectAircraft", "cmd_Cancel", "_lbl_gen_0", "_lbl_gen_16", "pnl_Clst", "cmd_pick_Ac", "_Tabs1_TabPage1", "Tabs1", "tbr_ToolBar_Buttons_Button1", "tbr_ToolBar_Buttons_Button2", "tbr_ToolBar_Buttons_Button3", "tbr_ToolBar_Buttons_Button4", "tbr_ToolBar_Buttons_Button5", "tbr_ToolBar_Buttons_Button6", "tbr_ToolBar_Buttons_Button7", "tbr_ToolBar_Buttons_Button8", "tbr_ToolBar", "Label1", "pnl_SearchWait", "lbl_Search_Heading", "Label2", "Label7", "cboUsage", "cboUsageCondition", "chk_bx_product_codes", "lblBusinessType", "lblUsageFormat", "lbl_Class", "lbl_gen", "optNewUsed", "txtUsageValue", "txt_gen", "commandButtonHelper1", "listBoxHelper1", "optionButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFileLogout;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.ToolStripMenuItem mnuFractional;
		public System.Windows.Forms.ToolStripMenuItem mnuEdit;
		public System.Windows.Forms.ToolStripMenuItem mnuReport;
		public System.Windows.Forms.ToolStripMenuItem mnuAircraftListShowUserHistory;
		public System.Windows.Forms.ToolStripMenuItem mnuTools;
		public System.Windows.Forms.MenuStrip MainMenu1;
		private System.Windows.Forms.Label _Label2_0;
		private System.Windows.Forms.Label _Label2_1;
		public System.Windows.Forms.CheckBox chk_prev;
		private System.Windows.Forms.RadioButton _optNewUsed_3;
		public System.Windows.Forms.ComboBox cboAirframeTypeCode;
		public System.Windows.Forms.ComboBox cbo_ac_use_code;
		public System.Windows.Forms.ComboBox cbo_ac_interior_config_search;
		public System.Windows.Forms.CheckBox chkSerNbrExact;
		public System.Windows.Forms.TextBox txt_amod_number_of_engines;
		public System.Windows.Forms.ComboBox cbo_engCompare;
		private System.Windows.Forms.RadioButton _optNewUsed_2;
		private System.Windows.Forms.RadioButton _optNewUsed_1;
		private System.Windows.Forms.RadioButton _optNewUsed_0;
		public System.Windows.Forms.TextBox txtSerialNoTo;
		public System.Windows.Forms.TextBox txtEngSerNoTo;
		public System.Windows.Forms.TextBox txtEngSerNoFrom;
		public System.Windows.Forms.ComboBox cboEMP;
		public System.Windows.Forms.ComboBox cboMaintained;
		public System.Windows.Forms.ComboBox cboWeightClass;
		public System.Windows.Forms.TextBox txtRegNo;
		public System.Windows.Forms.TextBox txtSerialNoFrom;
		public System.Windows.Forms.TextBox txtYear;
		public System.Windows.Forms.TextBox txtYear2;
		public System.Windows.Forms.ComboBox cbo_ac_class;
		public System.Windows.Forms.ListBox lstMake;
		public System.Windows.Forms.ListBox lstType;
		public System.Windows.Forms.ListBox lstModel;
		public System.Windows.Forms.TextBox txtEngineModel;
		public System.Windows.Forms.ComboBox cboEngineModel;
		private System.Windows.Forms.CheckBox _chk_bx_product_codes_0;
		private System.Windows.Forms.CheckBox _chk_bx_product_codes_3;
		private System.Windows.Forms.CheckBox _chk_bx_product_codes_2;
		private System.Windows.Forms.Label _lbl_Class_3;
		private System.Windows.Forms.Label _lbl_Class_2;
		private System.Windows.Forms.Label _lbl_Class_1;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label lblSerialTo;
		public System.Windows.Forms.Label lblTo;
		public System.Windows.Forms.Label lblFrom;
		public System.Windows.Forms.Label lblEngSerNo;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label lblEngineModel;
		public System.Windows.Forms.Label lblMaintained;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label lblRegNo;
		public System.Windows.Forms.Label lblSerialNo;
		public System.Windows.Forms.Label lblYears;
		public System.Windows.Forms.Label lblYearsTo;
		private System.Windows.Forms.Label _lbl_Class_0;
		public System.Windows.Forms.Label lblType;
		public System.Windows.Forms.Label lblMake;
		public System.Windows.Forms.Label lblModel;
		public System.Windows.Forms.GroupBox fraClassification;
		public System.Windows.Forms.ComboBox cbo_JournalCategory;
		public System.Windows.Forms.ComboBox cbo_ContactType;
		public System.Windows.Forms.Button cmdHideTrans;
		public System.Windows.Forms.Label lblJournalCategory;
		public System.Windows.Forms.Label lblcontacttype;
		public System.Windows.Forms.GroupBox frm_Transactions;
		public System.Windows.Forms.ComboBox cbo_agency_type;
		public System.Windows.Forms.RadioButton opt_CompanyContinent;
		public System.Windows.Forms.RadioButton opt_CompanyRegion;
		public System.Windows.Forms.ListBox lst_CompanyArea;
		public System.Windows.Forms.ComboBox cbo_Acc_Rep;
		public System.Windows.Forms.TextBox txtCompanyCity;
		public System.Windows.Forms.TextBox txtCompanyZip;
		public System.Windows.Forms.TextBox txtCompanyPhone;
		public System.Windows.Forms.ComboBox cboBusinessType;
		public System.Windows.Forms.TextBox txtCompanyName;
		public System.Windows.Forms.ListBox lstCompanyTimeZone;
		public System.Windows.Forms.ListBox lstCompanyState;
		public System.Windows.Forms.ListBox lstCompanyCountry;
		public System.Windows.Forms.ListBox lstCompanyType;
		private System.Windows.Forms.Label _lblBusinessType_1;
		public System.Windows.Forms.Label lbl_AccRep;
		public System.Windows.Forms.Label lblCompanyCity;
		public System.Windows.Forms.Label lblCompanyZip;
		public System.Windows.Forms.Label lblCompanyPhone;
		private System.Windows.Forms.Label _lblBusinessType_0;
		public System.Windows.Forms.Label lblCompanyName;
		public System.Windows.Forms.Label lblCompanyTimeZone;
		public System.Windows.Forms.Label lblCompanyState;
		public System.Windows.Forms.Label lblCompanyCountry;
		public System.Windows.Forms.Label lblCompanyType;
		public System.Windows.Forms.GroupBox fraCompanyDemographics;
		public System.Windows.Forms.ComboBox txt_ac_status;
		public System.Windows.Forms.ComboBox cmb_engine_noise_rating;
		public System.Windows.Forms.ComboBox cmb_model_config;
		public System.Windows.Forms.ComboBox cbo_ac_lifecycle_stage;
		public System.Windows.Forms.ComboBox cboOwnType;
		public System.Windows.Forms.ComboBox cboExclusive;
		public System.Windows.Forms.ComboBox cboLeaseStatus;
		public System.Windows.Forms.ComboBox cbo_ac_delivery;
		public System.Windows.Forms.ComboBox cbo_ac_asking;
		public System.Windows.Forms.RadioButton optNotForSale;
		public System.Windows.Forms.RadioButton optForSale;
		public System.Windows.Forms.RadioButton optAll;
		private System.Windows.Forms.Label _Label7_0;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label lbl_Stage;
		public System.Windows.Forms.Label lblOwnershipType;
		public System.Windows.Forms.Label lblExclusive;
		public System.Windows.Forms.Label lblLeaseStatus;
		public System.Windows.Forms.Label lbl_delivery;
		public System.Windows.Forms.Label lbl_asking;
		public System.Windows.Forms.Label lbl_ac_status;
		public System.Windows.Forms.GroupBox fraStatus;
		private System.Windows.Forms.ComboBox _cboUsage_4;
		private System.Windows.Forms.ComboBox _cboUsageCondition_4;
		private System.Windows.Forms.TextBox _txtUsageValue_4;
		private System.Windows.Forms.TextBox _txtUsageValue_3;
		private System.Windows.Forms.ComboBox _cboUsageCondition_3;
		private System.Windows.Forms.ComboBox _cboUsage_3;
		private System.Windows.Forms.ComboBox _cboUsage_0;
		private System.Windows.Forms.ComboBox _cboUsageCondition_0;
		private System.Windows.Forms.TextBox _txtUsageValue_0;
		private System.Windows.Forms.ComboBox _cboUsage_1;
		private System.Windows.Forms.ComboBox _cboUsageCondition_1;
		private System.Windows.Forms.TextBox _txtUsageValue_1;
		private System.Windows.Forms.TextBox _txtUsageValue_2;
		private System.Windows.Forms.ComboBox _cboUsageCondition_2;
		private System.Windows.Forms.ComboBox _cboUsage_2;
		private System.Windows.Forms.Label _lblUsageFormat_4;
		private System.Windows.Forms.Label _lblUsageFormat_3;
		private System.Windows.Forms.Label _lblUsageFormat_2;
		private System.Windows.Forms.Label _lblUsageFormat_1;
		private System.Windows.Forms.Label _lblUsageFormat_0;
		public System.Windows.Forms.GroupBox fraUsage;
		public System.Windows.Forms.CheckBox chkCompanyFlag;
		public System.Windows.Forms.Button cmdClear;
		public System.Windows.Forms.TextBox txt_ac_id;
		public System.Windows.Forms.CheckBox chkDontJumpToAircraft;
		public System.Windows.Forms.TextBox txt_ac_aport_faaid_code;
		public System.Windows.Forms.ListBox lst_State;
		public System.Windows.Forms.TextBox txt_ac_aport_city;
		public System.Windows.Forms.TextBox txt_ac_aport_iata_code;
		public System.Windows.Forms.TextBox txt_ac_aport_icao_code;
		public System.Windows.Forms.TextBox txt_ac_aport_name;
		public System.Windows.Forms.ListBox lst_Country;
		public System.Windows.Forms.ListBox lst_Area;
		public System.Windows.Forms.RadioButton opt_Region;
		public System.Windows.Forms.RadioButton opt_Continent;
		public System.Windows.Forms.Label lbl_FAAID;
		public System.Windows.Forms.Label Label20;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label lbl_IATA;
		public System.Windows.Forms.Label lbl_ICAO;
		public System.Windows.Forms.Label lbl_airport;
		public System.Windows.Forms.Label Label15;
		public System.Windows.Forms.GroupBox frame_demographics;
		public System.Windows.Forms.TextBox txt_Journ_id;
		public System.Windows.Forms.CheckBox chkTransactions;
		public System.Windows.Forms.CheckBox chkDontRefreshList;
		public System.Windows.Forms.CheckBox chk_include_not_researched;
		private System.Windows.Forms.TabPage _Tabs1_TabPage0;
		public System.Windows.Forms.Label lbl_Totfound;
		private System.Windows.Forms.TextBox _txt_gen_7;
		private System.Windows.Forms.TextBox _txt_gen_6;
		private System.Windows.Forms.TextBox _txt_gen_5;
		private System.Windows.Forms.TextBox _txt_gen_4;
		public System.Windows.Forms.Button cmdAircraftListExcelExport;
		private System.Windows.Forms.TextBox _txt_gen_0;
		private System.Windows.Forms.TextBox _txt_gen_3;
		private System.Windows.Forms.TextBox _txt_gen_2;
		private System.Windows.Forms.TextBox _txt_gen_1;
		public UpgradeHelpers.DataGridViewFlex grdAircraft;
		public System.Windows.Forms.Button cmdStop;
		public System.Windows.Forms.Button cmd_SelectAircraft;
		public System.Windows.Forms.Button cmd_Cancel;
		private System.Windows.Forms.Label _lbl_gen_0;
		private System.Windows.Forms.Label _lbl_gen_16;
		public System.Windows.Forms.Panel pnl_Clst;
		public System.Windows.Forms.Button cmd_pick_Ac;
		private System.Windows.Forms.TabPage _Tabs1_TabPage1;
		public UpgradeHelpers.Gui.Controls.TabControlExtension Tabs1;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button1;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button2;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button3;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button4;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button5;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button6;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button7;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button8;
		public System.Windows.Forms.ToolStrip tbr_ToolBar;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Panel pnl_SearchWait;
		public System.Windows.Forms.Label lbl_Search_Heading;
		public System.Windows.Forms.Label[] Label2 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] Label7 = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.ComboBox[] cboUsage = new System.Windows.Forms.ComboBox[5];
		public System.Windows.Forms.ComboBox[] cboUsageCondition = new System.Windows.Forms.ComboBox[5];
		public System.Windows.Forms.CheckBox[] chk_bx_product_codes = new System.Windows.Forms.CheckBox[4];
		public System.Windows.Forms.Label[] lblBusinessType = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] lblUsageFormat = new System.Windows.Forms.Label[5];
		public System.Windows.Forms.Label[] lbl_Class = new System.Windows.Forms.Label[4];
		public System.Windows.Forms.Label[] lbl_gen = new System.Windows.Forms.Label[17];
		public System.Windows.Forms.RadioButton[] optNewUsed = new System.Windows.Forms.RadioButton[4];
		public System.Windows.Forms.TextBox[] txtUsageValue = new System.Windows.Forms.TextBox[5];
		public System.Windows.Forms.TextBox[] txt_gen = new System.Windows.Forms.TextBox[8];
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		private int Tabs1PreviousTab;
		public System.ComponentModel.ComponentResourceManager resources;
        //NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AircraftList));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileLogout = new System.Windows.Forms.ToolStripMenuItem();
			mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
			mnuFractional = new System.Windows.Forms.ToolStripMenuItem();
			mnuReport = new System.Windows.Forms.ToolStripMenuItem();
			mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			mnuAircraftListShowUserHistory = new System.Windows.Forms.ToolStripMenuItem();
			Tabs1 = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_Tabs1_TabPage0 = new System.Windows.Forms.TabPage();
			_Label2_0 = new System.Windows.Forms.Label();
			_Label2_1 = new System.Windows.Forms.Label();
			fraClassification = new System.Windows.Forms.GroupBox();
			chk_prev = new System.Windows.Forms.CheckBox();
			_optNewUsed_3 = new System.Windows.Forms.RadioButton();
			cboAirframeTypeCode = new System.Windows.Forms.ComboBox();
			cbo_ac_use_code = new System.Windows.Forms.ComboBox();
			cbo_ac_interior_config_search = new System.Windows.Forms.ComboBox();
			chkSerNbrExact = new System.Windows.Forms.CheckBox();
			txt_amod_number_of_engines = new System.Windows.Forms.TextBox();
			cbo_engCompare = new System.Windows.Forms.ComboBox();
			_optNewUsed_2 = new System.Windows.Forms.RadioButton();
			_optNewUsed_1 = new System.Windows.Forms.RadioButton();
			_optNewUsed_0 = new System.Windows.Forms.RadioButton();
			txtSerialNoTo = new System.Windows.Forms.TextBox();
			txtEngSerNoTo = new System.Windows.Forms.TextBox();
			txtEngSerNoFrom = new System.Windows.Forms.TextBox();
			cboEMP = new System.Windows.Forms.ComboBox();
			cboMaintained = new System.Windows.Forms.ComboBox();
			cboWeightClass = new System.Windows.Forms.ComboBox();
			txtRegNo = new System.Windows.Forms.TextBox();
			txtSerialNoFrom = new System.Windows.Forms.TextBox();
			txtYear = new System.Windows.Forms.TextBox();
			txtYear2 = new System.Windows.Forms.TextBox();
			cbo_ac_class = new System.Windows.Forms.ComboBox();
			lstMake = new System.Windows.Forms.ListBox();
			lstType = new System.Windows.Forms.ListBox();
			lstModel = new System.Windows.Forms.ListBox();
			txtEngineModel = new System.Windows.Forms.TextBox();
			cboEngineModel = new System.Windows.Forms.ComboBox();
			_chk_bx_product_codes_0 = new System.Windows.Forms.CheckBox();
			_chk_bx_product_codes_3 = new System.Windows.Forms.CheckBox();
			_chk_bx_product_codes_2 = new System.Windows.Forms.CheckBox();
			_lbl_Class_3 = new System.Windows.Forms.Label();
			_lbl_Class_2 = new System.Windows.Forms.Label();
			_lbl_Class_1 = new System.Windows.Forms.Label();
			Line1 = new System.Windows.Forms.Label();
			Label8 = new System.Windows.Forms.Label();
			lblSerialTo = new System.Windows.Forms.Label();
			lblTo = new System.Windows.Forms.Label();
			lblFrom = new System.Windows.Forms.Label();
			lblEngSerNo = new System.Windows.Forms.Label();
			Label4 = new System.Windows.Forms.Label();
			lblEngineModel = new System.Windows.Forms.Label();
			lblMaintained = new System.Windows.Forms.Label();
			Label3 = new System.Windows.Forms.Label();
			lblRegNo = new System.Windows.Forms.Label();
			lblSerialNo = new System.Windows.Forms.Label();
			lblYears = new System.Windows.Forms.Label();
			lblYearsTo = new System.Windows.Forms.Label();
			_lbl_Class_0 = new System.Windows.Forms.Label();
			lblType = new System.Windows.Forms.Label();
			lblMake = new System.Windows.Forms.Label();
			lblModel = new System.Windows.Forms.Label();
			fraCompanyDemographics = new System.Windows.Forms.GroupBox();
			frm_Transactions = new System.Windows.Forms.GroupBox();
			cbo_JournalCategory = new System.Windows.Forms.ComboBox();
			cbo_ContactType = new System.Windows.Forms.ComboBox();
			cmdHideTrans = new System.Windows.Forms.Button();
			lblJournalCategory = new System.Windows.Forms.Label();
			lblcontacttype = new System.Windows.Forms.Label();
			cbo_agency_type = new System.Windows.Forms.ComboBox();
			opt_CompanyContinent = new System.Windows.Forms.RadioButton();
			opt_CompanyRegion = new System.Windows.Forms.RadioButton();
			lst_CompanyArea = new System.Windows.Forms.ListBox();
			cbo_Acc_Rep = new System.Windows.Forms.ComboBox();
			txtCompanyCity = new System.Windows.Forms.TextBox();
			txtCompanyZip = new System.Windows.Forms.TextBox();
			txtCompanyPhone = new System.Windows.Forms.TextBox();
			cboBusinessType = new System.Windows.Forms.ComboBox();
			txtCompanyName = new System.Windows.Forms.TextBox();
			lstCompanyTimeZone = new System.Windows.Forms.ListBox();
			lstCompanyState = new System.Windows.Forms.ListBox();
			lstCompanyCountry = new System.Windows.Forms.ListBox();
			lstCompanyType = new System.Windows.Forms.ListBox();
			_lblBusinessType_1 = new System.Windows.Forms.Label();
			lbl_AccRep = new System.Windows.Forms.Label();
			lblCompanyCity = new System.Windows.Forms.Label();
			lblCompanyZip = new System.Windows.Forms.Label();
			lblCompanyPhone = new System.Windows.Forms.Label();
			_lblBusinessType_0 = new System.Windows.Forms.Label();
			lblCompanyName = new System.Windows.Forms.Label();
			lblCompanyTimeZone = new System.Windows.Forms.Label();
			lblCompanyState = new System.Windows.Forms.Label();
			lblCompanyCountry = new System.Windows.Forms.Label();
			lblCompanyType = new System.Windows.Forms.Label();
			fraStatus = new System.Windows.Forms.GroupBox();
			txt_ac_status = new System.Windows.Forms.ComboBox();
			cmb_engine_noise_rating = new System.Windows.Forms.ComboBox();
			cmb_model_config = new System.Windows.Forms.ComboBox();
			cbo_ac_lifecycle_stage = new System.Windows.Forms.ComboBox();
			cboOwnType = new System.Windows.Forms.ComboBox();
			cboExclusive = new System.Windows.Forms.ComboBox();
			cboLeaseStatus = new System.Windows.Forms.ComboBox();
			cbo_ac_delivery = new System.Windows.Forms.ComboBox();
			cbo_ac_asking = new System.Windows.Forms.ComboBox();
			optNotForSale = new System.Windows.Forms.RadioButton();
			optForSale = new System.Windows.Forms.RadioButton();
			optAll = new System.Windows.Forms.RadioButton();
			_Label7_0 = new System.Windows.Forms.Label();
			Label6 = new System.Windows.Forms.Label();
			lbl_Stage = new System.Windows.Forms.Label();
			lblOwnershipType = new System.Windows.Forms.Label();
			lblExclusive = new System.Windows.Forms.Label();
			lblLeaseStatus = new System.Windows.Forms.Label();
			lbl_delivery = new System.Windows.Forms.Label();
			lbl_asking = new System.Windows.Forms.Label();
			lbl_ac_status = new System.Windows.Forms.Label();
			fraUsage = new System.Windows.Forms.GroupBox();
			_cboUsage_4 = new System.Windows.Forms.ComboBox();
			_cboUsageCondition_4 = new System.Windows.Forms.ComboBox();
			_txtUsageValue_4 = new System.Windows.Forms.TextBox();
			_txtUsageValue_3 = new System.Windows.Forms.TextBox();
			_cboUsageCondition_3 = new System.Windows.Forms.ComboBox();
			_cboUsage_3 = new System.Windows.Forms.ComboBox();
			_cboUsage_0 = new System.Windows.Forms.ComboBox();
			_cboUsageCondition_0 = new System.Windows.Forms.ComboBox();
			_txtUsageValue_0 = new System.Windows.Forms.TextBox();
			_cboUsage_1 = new System.Windows.Forms.ComboBox();
			_cboUsageCondition_1 = new System.Windows.Forms.ComboBox();
			_txtUsageValue_1 = new System.Windows.Forms.TextBox();
			_txtUsageValue_2 = new System.Windows.Forms.TextBox();
			_cboUsageCondition_2 = new System.Windows.Forms.ComboBox();
			_cboUsage_2 = new System.Windows.Forms.ComboBox();
			_lblUsageFormat_4 = new System.Windows.Forms.Label();
			_lblUsageFormat_3 = new System.Windows.Forms.Label();
			_lblUsageFormat_2 = new System.Windows.Forms.Label();
			_lblUsageFormat_1 = new System.Windows.Forms.Label();
			_lblUsageFormat_0 = new System.Windows.Forms.Label();
			chkCompanyFlag = new System.Windows.Forms.CheckBox();
			cmdClear = new System.Windows.Forms.Button();
			txt_ac_id = new System.Windows.Forms.TextBox();
			chkDontJumpToAircraft = new System.Windows.Forms.CheckBox();
			frame_demographics = new System.Windows.Forms.GroupBox();
			txt_ac_aport_faaid_code = new System.Windows.Forms.TextBox();
			lst_State = new System.Windows.Forms.ListBox();
			txt_ac_aport_city = new System.Windows.Forms.TextBox();
			txt_ac_aport_iata_code = new System.Windows.Forms.TextBox();
			txt_ac_aport_icao_code = new System.Windows.Forms.TextBox();
			txt_ac_aport_name = new System.Windows.Forms.TextBox();
			lst_Country = new System.Windows.Forms.ListBox();
			lst_Area = new System.Windows.Forms.ListBox();
			opt_Region = new System.Windows.Forms.RadioButton();
			opt_Continent = new System.Windows.Forms.RadioButton();
			lbl_FAAID = new System.Windows.Forms.Label();
			Label20 = new System.Windows.Forms.Label();
			Label5 = new System.Windows.Forms.Label();
			lbl_IATA = new System.Windows.Forms.Label();
			lbl_ICAO = new System.Windows.Forms.Label();
			lbl_airport = new System.Windows.Forms.Label();
			Label15 = new System.Windows.Forms.Label();
			txt_Journ_id = new System.Windows.Forms.TextBox();
			chkTransactions = new System.Windows.Forms.CheckBox();
			chkDontRefreshList = new System.Windows.Forms.CheckBox();
			chk_include_not_researched = new System.Windows.Forms.CheckBox();
			_Tabs1_TabPage1 = new System.Windows.Forms.TabPage();
			lbl_Totfound = new System.Windows.Forms.Label();
			pnl_Clst = new System.Windows.Forms.Panel();
			_txt_gen_7 = new System.Windows.Forms.TextBox();
			_txt_gen_6 = new System.Windows.Forms.TextBox();
			_txt_gen_5 = new System.Windows.Forms.TextBox();
			_txt_gen_4 = new System.Windows.Forms.TextBox();
			cmdAircraftListExcelExport = new System.Windows.Forms.Button();
			_txt_gen_0 = new System.Windows.Forms.TextBox();
			_txt_gen_3 = new System.Windows.Forms.TextBox();
			_txt_gen_2 = new System.Windows.Forms.TextBox();
			_txt_gen_1 = new System.Windows.Forms.TextBox();
			grdAircraft = new UpgradeHelpers.DataGridViewFlex(components);
			cmdStop = new System.Windows.Forms.Button();
			cmd_SelectAircraft = new System.Windows.Forms.Button();
			cmd_Cancel = new System.Windows.Forms.Button();
			_lbl_gen_0 = new System.Windows.Forms.Label();
			_lbl_gen_16 = new System.Windows.Forms.Label();
			cmd_pick_Ac = new System.Windows.Forms.Button();
			tbr_ToolBar = new System.Windows.Forms.ToolStrip();
			tbr_ToolBar_Buttons_Button1 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button2 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button3 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button4 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button5 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button6 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button7 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button8 = new System.Windows.Forms.ToolStripButton();
			pnl_SearchWait = new System.Windows.Forms.Panel();
			Label1 = new System.Windows.Forms.Label();
			lbl_Search_Heading = new System.Windows.Forms.Label();
			Tabs1.SuspendLayout();
			_Tabs1_TabPage0.SuspendLayout();
			fraClassification.SuspendLayout();
			fraCompanyDemographics.SuspendLayout();
			frm_Transactions.SuspendLayout();
			fraStatus.SuspendLayout();
			fraUsage.SuspendLayout();
			frame_demographics.SuspendLayout();
			_Tabs1_TabPage1.SuspendLayout();
			pnl_Clst.SuspendLayout();
			tbr_ToolBar.SuspendLayout();
			pnl_SearchWait.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grdAircraft).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFile, mnuEdit, mnuReport, mnuTools});
			// 
			// mnuFile
			// 
			mnuFile.Available = true;
			mnuFile.Checked = false;
			mnuFile.Enabled = true;
			mnuFile.Name = "mnuFile";
			mnuFile.Text = "File";
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
			mnuEdit.Text = "Edit";
			mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFractional});
			// 
			// mnuFractional
			// 
			mnuFractional.Available = true;
			mnuFractional.Checked = false;
			mnuFractional.Enabled = true;
			mnuFractional.Name = "mnuFractional";
			mnuFractional.Text = "Fractional Programs";
			mnuFractional.Click += new System.EventHandler(mnuFractional_Click);
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
			mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuAircraftListShowUserHistory});
			// 
			// mnuAircraftListShowUserHistory
			// 
			mnuAircraftListShowUserHistory.Available = true;
			mnuAircraftListShowUserHistory.Checked = false;
			mnuAircraftListShowUserHistory.Enabled = true;
			mnuAircraftListShowUserHistory.Name = "mnuAircraftListShowUserHistory";
			mnuAircraftListShowUserHistory.Text = "Show User History";
			mnuAircraftListShowUserHistory.Click += new System.EventHandler(mnuAircraftListShowUserHistory_Click);
			// 
			// Tabs1
			// 
			Tabs1.Alignment = System.Windows.Forms.TabAlignment.Top;
			Tabs1.AllowDrop = true;
			Tabs1.Controls.Add(_Tabs1_TabPage0);
			Tabs1.Controls.Add(_Tabs1_TabPage1);
			Tabs1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Tabs1.ItemSize = new System.Drawing.Size(490, 18);
			Tabs1.Location = new System.Drawing.Point(3, 78);
			Tabs1.Multiline = true;
			Tabs1.Name = "Tabs1";
			Tabs1.Size = new System.Drawing.Size(986, 606);
			Tabs1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			Tabs1.TabIndex = 20;
			Tabs1.MouseMove += new System.Windows.Forms.MouseEventHandler(Tabs1_MouseMove);
			Tabs1.SelectedIndexChanged += new System.EventHandler(Tabs1_SelectedIndexChanged);
			// 
			// _Tabs1_TabPage0
			// 
			_Tabs1_TabPage0.Controls.Add(_Label2_0);
			_Tabs1_TabPage0.Controls.Add(_Label2_1);
			_Tabs1_TabPage0.Controls.Add(fraClassification);
			_Tabs1_TabPage0.Controls.Add(fraCompanyDemographics);
			_Tabs1_TabPage0.Controls.Add(fraStatus);
			_Tabs1_TabPage0.Controls.Add(fraUsage);
			_Tabs1_TabPage0.Controls.Add(chkCompanyFlag);
			_Tabs1_TabPage0.Controls.Add(cmdClear);
			_Tabs1_TabPage0.Controls.Add(txt_ac_id);
			_Tabs1_TabPage0.Controls.Add(chkDontJumpToAircraft);
			_Tabs1_TabPage0.Controls.Add(frame_demographics);
			_Tabs1_TabPage0.Controls.Add(txt_Journ_id);
			_Tabs1_TabPage0.Controls.Add(chkTransactions);
			_Tabs1_TabPage0.Controls.Add(chkDontRefreshList);
			_Tabs1_TabPage0.Controls.Add(chk_include_not_researched);
			_Tabs1_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Tabs1_TabPage0.Text = "Criteria";
			// 
			// _Label2_0
			// 
			_Label2_0.AllowDrop = true;
			_Label2_0.AutoSize = true;
			_Label2_0.BackColor = System.Drawing.Color.Transparent;
			_Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label2_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label2_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label2_0.Location = new System.Drawing.Point(28, -6);
			_Label2_0.MinimumSize = new System.Drawing.Size(47, 13);
			_Label2_0.Name = "_Label2_0";
			_Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label2_0.Size = new System.Drawing.Size(47, 13);
			_Label2_0.TabIndex = 83;
			_Label2_0.Text = "Aircraft ID";
			// 
			// _Label2_1
			// 
			_Label2_1.AllowDrop = true;
			_Label2_1.AutoSize = true;
			_Label2_1.BackColor = System.Drawing.Color.Transparent;
			_Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label2_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label2_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label2_1.Location = new System.Drawing.Point(131, -6);
			_Label2_1.MinimumSize = new System.Drawing.Size(48, 13);
			_Label2_1.Name = "_Label2_1";
			_Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label2_1.Size = new System.Drawing.Size(48, 13);
			_Label2_1.TabIndex = 144;
			_Label2_1.Text = "Journal ID";
			// 
			// fraClassification
			// 
			fraClassification.AllowDrop = true;
			fraClassification.Controls.Add(chk_prev);
			fraClassification.Controls.Add(_optNewUsed_3);
			fraClassification.Controls.Add(cboAirframeTypeCode);
			fraClassification.Controls.Add(cbo_ac_use_code);
			fraClassification.Controls.Add(cbo_ac_interior_config_search);
			fraClassification.Controls.Add(chkSerNbrExact);
			fraClassification.Controls.Add(txt_amod_number_of_engines);
			fraClassification.Controls.Add(cbo_engCompare);
			fraClassification.Controls.Add(_optNewUsed_2);
			fraClassification.Controls.Add(_optNewUsed_1);
			fraClassification.Controls.Add(_optNewUsed_0);
			fraClassification.Controls.Add(txtSerialNoTo);
			fraClassification.Controls.Add(txtEngSerNoTo);
			fraClassification.Controls.Add(txtEngSerNoFrom);
			fraClassification.Controls.Add(cboEMP);
			fraClassification.Controls.Add(cboMaintained);
			fraClassification.Controls.Add(cboWeightClass);
			fraClassification.Controls.Add(txtRegNo);
			fraClassification.Controls.Add(txtSerialNoFrom);
			fraClassification.Controls.Add(txtYear);
			fraClassification.Controls.Add(txtYear2);
			fraClassification.Controls.Add(cbo_ac_class);
			fraClassification.Controls.Add(lstMake);
			fraClassification.Controls.Add(lstType);
			fraClassification.Controls.Add(lstModel);
			fraClassification.Controls.Add(txtEngineModel);
			fraClassification.Controls.Add(cboEngineModel);
			fraClassification.Controls.Add(_chk_bx_product_codes_0);
			fraClassification.Controls.Add(_chk_bx_product_codes_3);
			fraClassification.Controls.Add(_chk_bx_product_codes_2);
			fraClassification.Controls.Add(_lbl_Class_3);
			fraClassification.Controls.Add(_lbl_Class_2);
			fraClassification.Controls.Add(_lbl_Class_1);
			fraClassification.Controls.Add(Line1);
			fraClassification.Controls.Add(Label8);
			fraClassification.Controls.Add(lblSerialTo);
			fraClassification.Controls.Add(lblTo);
			fraClassification.Controls.Add(lblFrom);
			fraClassification.Controls.Add(lblEngSerNo);
			fraClassification.Controls.Add(Label4);
			fraClassification.Controls.Add(lblEngineModel);
			fraClassification.Controls.Add(lblMaintained);
			fraClassification.Controls.Add(Label3);
			fraClassification.Controls.Add(lblRegNo);
			fraClassification.Controls.Add(lblSerialNo);
			fraClassification.Controls.Add(lblYears);
			fraClassification.Controls.Add(lblYearsTo);
			fraClassification.Controls.Add(_lbl_Class_0);
			fraClassification.Controls.Add(lblType);
			fraClassification.Controls.Add(lblMake);
			fraClassification.Controls.Add(lblModel);
			fraClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fraClassification.ForeColor = System.Drawing.Color.Navy;
			fraClassification.Location = new System.Drawing.Point(5, 34);
			fraClassification.Name = "fraClassification";
			fraClassification.Size = new System.Drawing.Size(488, 332);
			fraClassification.TabIndex = 29;
			fraClassification.Text = "Classification";
			// 
			// chk_prev
			// 
			chk_prev.AllowDrop = true;
			chk_prev.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_prev.BackColor = System.Drawing.SystemColors.Control;
			chk_prev.CausesValidation = true;
			chk_prev.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_prev.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_prev.Enabled = true;
			chk_prev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_prev.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_prev.Location = new System.Drawing.Point(284, 16);
			chk_prev.Name = "chk_prev";
			chk_prev.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_prev.Size = new System.Drawing.Size(49, 13);
			chk_prev.TabIndex = 174;
			chk_prev.TabStop = true;
			chk_prev.Text = "Prev";
			chk_prev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_prev.Visible = true;
			// 
			// _optNewUsed_3
			// 
			_optNewUsed_3.AllowDrop = true;
			_optNewUsed_3.BackColor = System.Drawing.SystemColors.Control;
			_optNewUsed_3.CausesValidation = true;
			_optNewUsed_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optNewUsed_3.Checked = false;
			_optNewUsed_3.Enabled = true;
			_optNewUsed_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_optNewUsed_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_optNewUsed_3.Location = new System.Drawing.Point(432, 204);
			_optNewUsed_3.Name = "_optNewUsed_3";
			_optNewUsed_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_optNewUsed_3.Size = new System.Drawing.Size(52, 13);
			_optNewUsed_3.TabIndex = 172;
			_optNewUsed_3.TabStop = true;
			_optNewUsed_3.Text = "Used";
			_optNewUsed_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optNewUsed_3.Visible = false;
			// 
			// cboAirframeTypeCode
			// 
			cboAirframeTypeCode.AllowDrop = true;
			cboAirframeTypeCode.BackColor = System.Drawing.SystemColors.Window;
			cboAirframeTypeCode.CausesValidation = true;
			cboAirframeTypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboAirframeTypeCode.Enabled = true;
			cboAirframeTypeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboAirframeTypeCode.ForeColor = System.Drawing.SystemColors.WindowText;
			cboAirframeTypeCode.IntegralHeight = true;
			cboAirframeTypeCode.Location = new System.Drawing.Point(54, 56);
			cboAirframeTypeCode.Name = "cboAirframeTypeCode";
			cboAirframeTypeCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboAirframeTypeCode.Size = new System.Drawing.Size(102, 21);
			cboAirframeTypeCode.Sorted = false;
			cboAirframeTypeCode.TabIndex = 6;
			cboAirframeTypeCode.TabStop = true;
			cboAirframeTypeCode.Visible = true;
			cboAirframeTypeCode.SelectedIndexChanged += new System.EventHandler(cboAirframeTypeCode_SelectedIndexChanged);
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
			cbo_ac_use_code.Location = new System.Drawing.Point(198, 56);
			cbo_ac_use_code.Name = "cbo_ac_use_code";
			cbo_ac_use_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_use_code.Size = new System.Drawing.Size(106, 21);
			cbo_ac_use_code.Sorted = false;
			cbo_ac_use_code.TabIndex = 7;
			cbo_ac_use_code.TabStop = true;
			cbo_ac_use_code.Visible = true;
			// 
			// cbo_ac_interior_config_search
			// 
			cbo_ac_interior_config_search.AllowDrop = true;
			cbo_ac_interior_config_search.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_interior_config_search.CausesValidation = true;
			cbo_ac_interior_config_search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_ac_interior_config_search.Enabled = true;
			cbo_ac_interior_config_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_interior_config_search.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_interior_config_search.IntegralHeight = true;
			cbo_ac_interior_config_search.Location = new System.Drawing.Point(366, 56);
			cbo_ac_interior_config_search.Name = "cbo_ac_interior_config_search";
			cbo_ac_interior_config_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_interior_config_search.Size = new System.Drawing.Size(114, 21);
			cbo_ac_interior_config_search.Sorted = false;
			cbo_ac_interior_config_search.TabIndex = 8;
			cbo_ac_interior_config_search.TabStop = true;
			cbo_ac_interior_config_search.Visible = true;
			// 
			// chkSerNbrExact
			// 
			chkSerNbrExact.AllowDrop = true;
			chkSerNbrExact.Appearance = System.Windows.Forms.Appearance.Normal;
			chkSerNbrExact.BackColor = System.Drawing.SystemColors.Control;
			chkSerNbrExact.CausesValidation = true;
			chkSerNbrExact.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSerNbrExact.CheckState = System.Windows.Forms.CheckState.Checked;
			chkSerNbrExact.Enabled = true;
			chkSerNbrExact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkSerNbrExact.ForeColor = System.Drawing.SystemColors.ControlText;
			chkSerNbrExact.Location = new System.Drawing.Point(156, 12);
			chkSerNbrExact.Name = "chkSerNbrExact";
			chkSerNbrExact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkSerNbrExact.Size = new System.Drawing.Size(91, 17);
			chkSerNbrExact.TabIndex = 163;
			chkSerNbrExact.TabStop = true;
			chkSerNbrExact.Text = "&Exact Match";
			chkSerNbrExact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSerNbrExact.Visible = true;
			// 
			// txt_amod_number_of_engines
			// 
			txt_amod_number_of_engines.AcceptsReturn = true;
			txt_amod_number_of_engines.AllowDrop = true;
			txt_amod_number_of_engines.BackColor = System.Drawing.SystemColors.Window;
			txt_amod_number_of_engines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_amod_number_of_engines.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_number_of_engines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_number_of_engines.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_number_of_engines.Location = new System.Drawing.Point(412, 278);
			txt_amod_number_of_engines.MaxLength = 0;
			txt_amod_number_of_engines.Name = "txt_amod_number_of_engines";
			txt_amod_number_of_engines.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_number_of_engines.Size = new System.Drawing.Size(39, 19);
			txt_amod_number_of_engines.TabIndex = 138;
			// 
			// cbo_engCompare
			// 
			cbo_engCompare.AllowDrop = true;
			cbo_engCompare.BackColor = System.Drawing.SystemColors.Window;
			cbo_engCompare.CausesValidation = true;
			cbo_engCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_engCompare.Enabled = true;
			cbo_engCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_engCompare.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_engCompare.IntegralHeight = true;
			cbo_engCompare.Location = new System.Drawing.Point(351, 278);
			cbo_engCompare.Name = "cbo_engCompare";
			cbo_engCompare.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_engCompare.Size = new System.Drawing.Size(51, 21);
			cbo_engCompare.Sorted = false;
			cbo_engCompare.TabIndex = 137;
			cbo_engCompare.TabStop = true;
			cbo_engCompare.Visible = true;
			// 
			// _optNewUsed_2
			// 
			_optNewUsed_2.AllowDrop = true;
			_optNewUsed_2.BackColor = System.Drawing.SystemColors.Control;
			_optNewUsed_2.CausesValidation = true;
			_optNewUsed_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optNewUsed_2.Checked = false;
			_optNewUsed_2.Enabled = true;
			_optNewUsed_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_optNewUsed_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_optNewUsed_2.Location = new System.Drawing.Point(378, 204);
			_optNewUsed_2.Name = "_optNewUsed_2";
			_optNewUsed_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_optNewUsed_2.Size = new System.Drawing.Size(49, 13);
			_optNewUsed_2.TabIndex = 135;
			_optNewUsed_2.TabStop = true;
			_optNewUsed_2.Text = "Used";
			_optNewUsed_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optNewUsed_2.Visible = true;
			// 
			// _optNewUsed_1
			// 
			_optNewUsed_1.AllowDrop = true;
			_optNewUsed_1.BackColor = System.Drawing.SystemColors.Control;
			_optNewUsed_1.CausesValidation = true;
			_optNewUsed_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optNewUsed_1.Checked = false;
			_optNewUsed_1.Enabled = true;
			_optNewUsed_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_optNewUsed_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_optNewUsed_1.Location = new System.Drawing.Point(325, 204);
			_optNewUsed_1.Name = "_optNewUsed_1";
			_optNewUsed_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_optNewUsed_1.Size = new System.Drawing.Size(48, 13);
			_optNewUsed_1.TabIndex = 134;
			_optNewUsed_1.TabStop = true;
			_optNewUsed_1.Text = "New";
			_optNewUsed_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optNewUsed_1.Visible = true;
			// 
			// _optNewUsed_0
			// 
			_optNewUsed_0.AllowDrop = true;
			_optNewUsed_0.BackColor = System.Drawing.SystemColors.Control;
			_optNewUsed_0.CausesValidation = true;
			_optNewUsed_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optNewUsed_0.Checked = true;
			_optNewUsed_0.Enabled = true;
			_optNewUsed_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_optNewUsed_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_optNewUsed_0.Location = new System.Drawing.Point(284, 204);
			_optNewUsed_0.Name = "_optNewUsed_0";
			_optNewUsed_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_optNewUsed_0.Size = new System.Drawing.Size(36, 13);
			_optNewUsed_0.TabIndex = 133;
			_optNewUsed_0.TabStop = true;
			_optNewUsed_0.Text = "All";
			_optNewUsed_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optNewUsed_0.Visible = true;
			// 
			// txtSerialNoTo
			// 
			txtSerialNoTo.AcceptsReturn = true;
			txtSerialNoTo.AllowDrop = true;
			txtSerialNoTo.BackColor = System.Drawing.SystemColors.Window;
			txtSerialNoTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSerialNoTo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSerialNoTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSerialNoTo.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSerialNoTo.Location = new System.Drawing.Point(187, 29);
			txtSerialNoTo.MaxLength = 0;
			txtSerialNoTo.Name = "txtSerialNoTo";
			txtSerialNoTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSerialNoTo.Size = new System.Drawing.Size(63, 21);
			txtSerialNoTo.TabIndex = 1;
			txtSerialNoTo.Click += new System.EventHandler(txtSerialNoTo_Click);
			// 
			// txtEngSerNoTo
			// 
			txtEngSerNoTo.AcceptsReturn = true;
			txtEngSerNoTo.AllowDrop = true;
			txtEngSerNoTo.BackColor = System.Drawing.SystemColors.Window;
			txtEngSerNoTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtEngSerNoTo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEngSerNoTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEngSerNoTo.ForeColor = System.Drawing.SystemColors.WindowText;
			txtEngSerNoTo.Location = new System.Drawing.Point(266, 277);
			txtEngSerNoTo.MaxLength = 0;
			txtEngSerNoTo.Name = "txtEngSerNoTo";
			txtEngSerNoTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtEngSerNoTo.Size = new System.Drawing.Size(61, 19);
			txtEngSerNoTo.TabIndex = 126;
			txtEngSerNoTo.Click += new System.EventHandler(txtEngSerNoTo_Click);
			// 
			// txtEngSerNoFrom
			// 
			txtEngSerNoFrom.AcceptsReturn = true;
			txtEngSerNoFrom.AllowDrop = true;
			txtEngSerNoFrom.BackColor = System.Drawing.SystemColors.Window;
			txtEngSerNoFrom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtEngSerNoFrom.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEngSerNoFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEngSerNoFrom.ForeColor = System.Drawing.SystemColors.WindowText;
			txtEngSerNoFrom.Location = new System.Drawing.Point(187, 277);
			txtEngSerNoFrom.MaxLength = 0;
			txtEngSerNoFrom.Name = "txtEngSerNoFrom";
			txtEngSerNoFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtEngSerNoFrom.Size = new System.Drawing.Size(61, 19);
			txtEngSerNoFrom.TabIndex = 94;
			txtEngSerNoFrom.Click += new System.EventHandler(txtEngSerNoFrom_Click);
			// 
			// cboEMP
			// 
			cboEMP.AllowDrop = true;
			cboEMP.BackColor = System.Drawing.SystemColors.Window;
			cboEMP.CausesValidation = true;
			cboEMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboEMP.Enabled = true;
			cboEMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboEMP.ForeColor = System.Drawing.SystemColors.WindowText;
			cboEMP.IntegralHeight = true;
			cboEMP.Location = new System.Drawing.Point(146, 299);
			cboEMP.Name = "cboEMP";
			cboEMP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboEMP.Size = new System.Drawing.Size(321, 21);
			cboEMP.Sorted = false;
			cboEMP.TabIndex = 92;
			cboEMP.TabStop = true;
			cboEMP.Visible = true;
			// 
			// cboMaintained
			// 
			cboMaintained.AllowDrop = true;
			cboMaintained.BackColor = System.Drawing.SystemColors.Window;
			cboMaintained.CausesValidation = true;
			cboMaintained.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboMaintained.Enabled = true;
			cboMaintained.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboMaintained.ForeColor = System.Drawing.SystemColors.WindowText;
			cboMaintained.IntegralHeight = true;
			cboMaintained.Location = new System.Drawing.Point(161, 225);
			cboMaintained.Name = "cboMaintained";
			cboMaintained.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboMaintained.Size = new System.Drawing.Size(144, 21);
			cboMaintained.Sorted = false;
			cboMaintained.TabIndex = 87;
			cboMaintained.TabStop = true;
			cboMaintained.Visible = true;
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
			cboWeightClass.Location = new System.Drawing.Point(7, 225);
			cboWeightClass.Name = "cboWeightClass";
			cboWeightClass.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboWeightClass.Size = new System.Drawing.Size(144, 21);
			cboWeightClass.Sorted = false;
			cboWeightClass.TabIndex = 85;
			cboWeightClass.TabStop = true;
			cboWeightClass.Visible = true;
			// 
			// txtRegNo
			// 
			txtRegNo.AcceptsReturn = true;
			txtRegNo.AllowDrop = true;
			txtRegNo.BackColor = System.Drawing.SystemColors.Window;
			txtRegNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtRegNo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtRegNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtRegNo.ForeColor = System.Drawing.SystemColors.WindowText;
			txtRegNo.Location = new System.Drawing.Point(252, 29);
			txtRegNo.MaxLength = 0;
			txtRegNo.Name = "txtRegNo";
			txtRegNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtRegNo.Size = new System.Drawing.Size(76, 21);
			txtRegNo.TabIndex = 2;
			// 
			// txtSerialNoFrom
			// 
			txtSerialNoFrom.AcceptsReturn = true;
			txtSerialNoFrom.AllowDrop = true;
			txtSerialNoFrom.BackColor = System.Drawing.SystemColors.Window;
			txtSerialNoFrom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSerialNoFrom.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSerialNoFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSerialNoFrom.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSerialNoFrom.Location = new System.Drawing.Point(111, 29);
			txtSerialNoFrom.MaxLength = 0;
			txtSerialNoFrom.Name = "txtSerialNoFrom";
			txtSerialNoFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSerialNoFrom.Size = new System.Drawing.Size(63, 21);
			txtSerialNoFrom.TabIndex = 0;
			txtSerialNoFrom.Click += new System.EventHandler(txtSerialNoFrom_Click);
			// 
			// txtYear
			// 
			txtYear.AcceptsReturn = true;
			txtYear.AllowDrop = true;
			txtYear.BackColor = System.Drawing.SystemColors.Window;
			txtYear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtYear.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtYear.ForeColor = System.Drawing.SystemColors.WindowText;
			txtYear.Location = new System.Drawing.Point(329, 29);
			txtYear.MaxLength = 0;
			txtYear.Name = "txtYear";
			txtYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtYear.Size = new System.Drawing.Size(64, 21);
			txtYear.TabIndex = 3;
			// 
			// txtYear2
			// 
			txtYear2.AcceptsReturn = true;
			txtYear2.AllowDrop = true;
			txtYear2.BackColor = System.Drawing.SystemColors.Window;
			txtYear2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtYear2.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtYear2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtYear2.ForeColor = System.Drawing.SystemColors.WindowText;
			txtYear2.Location = new System.Drawing.Point(406, 29);
			txtYear2.MaxLength = 0;
			txtYear2.Name = "txtYear2";
			txtYear2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtYear2.Size = new System.Drawing.Size(64, 21);
			txtYear2.TabIndex = 4;
			// 
			// cbo_ac_class
			// 
			cbo_ac_class.AllowDrop = true;
			cbo_ac_class.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_class.CausesValidation = true;
			cbo_ac_class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_class.Enabled = true;
			cbo_ac_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_class.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_class.IntegralHeight = true;
			cbo_ac_class.Location = new System.Drawing.Point(7, 29);
			cbo_ac_class.Name = "cbo_ac_class";
			cbo_ac_class.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_class.Size = new System.Drawing.Size(102, 21);
			cbo_ac_class.Sorted = false;
			cbo_ac_class.TabIndex = 5;
			cbo_ac_class.TabStop = true;
			cbo_ac_class.Visible = true;
			// 
			// lstMake
			// 
			lstMake.AllowDrop = true;
			lstMake.BackColor = System.Drawing.SystemColors.Window;
			lstMake.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstMake.CausesValidation = true;
			lstMake.Enabled = true;
			lstMake.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstMake.ForeColor = System.Drawing.SystemColors.WindowText;
			lstMake.IntegralHeight = true;
			lstMake.Location = new System.Drawing.Point(123, 95);
			lstMake.MultiColumn = false;
			lstMake.Name = "lstMake";
			lstMake.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstMake.Size = new System.Drawing.Size(177, 109);
			lstMake.Sorted = false;
			lstMake.TabIndex = 10;
			lstMake.TabStop = true;
			lstMake.Visible = true;
			lstMake.SelectedIndexChanged += new System.EventHandler(lstMake_SelectedIndexChanged);
			// 
			// lstType
			// 
			lstType.AllowDrop = true;
			lstType.BackColor = System.Drawing.SystemColors.Window;
			lstType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstType.CausesValidation = true;
			lstType.Enabled = true;
			lstType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstType.ForeColor = System.Drawing.SystemColors.WindowText;
			lstType.IntegralHeight = true;
			lstType.Location = new System.Drawing.Point(7, 95);
			lstType.MultiColumn = false;
			lstType.Name = "lstType";
			lstType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstType.Size = new System.Drawing.Size(108, 109);
			lstType.Sorted = false;
			lstType.TabIndex = 9;
			lstType.TabStop = true;
			lstType.Visible = true;
			lstType.SelectedIndexChanged += new System.EventHandler(lstType_SelectedIndexChanged);
			// 
			// lstModel
			// 
			lstModel.AllowDrop = true;
			lstModel.BackColor = System.Drawing.SystemColors.Window;
			lstModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstModel.CausesValidation = true;
			lstModel.Enabled = true;
			lstModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstModel.ForeColor = System.Drawing.SystemColors.WindowText;
			lstModel.IntegralHeight = true;
			lstModel.Location = new System.Drawing.Point(307, 95);
			lstModel.MultiColumn = false;
			lstModel.Name = "lstModel";
			lstModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstModel.Size = new System.Drawing.Size(161, 109);
			lstModel.Sorted = false;
			lstModel.TabIndex = 11;
			lstModel.TabStop = true;
			lstModel.Visible = true;
			lstModel.SelectedIndexChanged += new System.EventHandler(lstModel_SelectedIndexChanged);
			// 
			// txtEngineModel
			// 
			txtEngineModel.AcceptsReturn = true;
			txtEngineModel.AllowDrop = true;
			txtEngineModel.BackColor = System.Drawing.SystemColors.Window;
			txtEngineModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtEngineModel.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEngineModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEngineModel.ForeColor = System.Drawing.SystemColors.WindowText;
			txtEngineModel.Location = new System.Drawing.Point(8, 277);
			txtEngineModel.MaxLength = 0;
			txtEngineModel.Name = "txtEngineModel";
			txtEngineModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtEngineModel.Size = new System.Drawing.Size(144, 19);
			txtEngineModel.TabIndex = 91;
			txtEngineModel.Click += new System.EventHandler(txtEngineModel_Click);
			// 
			// cboEngineModel
			// 
			cboEngineModel.AllowDrop = true;
			cboEngineModel.BackColor = System.Drawing.SystemColors.Window;
			cboEngineModel.CausesValidation = true;
			cboEngineModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboEngineModel.Enabled = true;
			cboEngineModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboEngineModel.ForeColor = System.Drawing.SystemColors.WindowText;
			cboEngineModel.IntegralHeight = true;
			cboEngineModel.Location = new System.Drawing.Point(8, 276);
			cboEngineModel.Name = "cboEngineModel";
			cboEngineModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboEngineModel.Size = new System.Drawing.Size(145, 21);
			cboEngineModel.Sorted = false;
			cboEngineModel.TabIndex = 89;
			cboEngineModel.TabStop = true;
			cboEngineModel.Visible = false;
			// 
			// _chk_bx_product_codes_0
			// 
			_chk_bx_product_codes_0.AllowDrop = true;
			_chk_bx_product_codes_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_bx_product_codes_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_bx_product_codes_0.Location = new System.Drawing.Point(319, 226);
			_chk_bx_product_codes_0.Name = "_chk_bx_product_codes_0";
			_chk_bx_product_codes_0.Size = new System.Drawing.Size(62, 11);
			_chk_bx_product_codes_0.TabIndex = 160;
			_chk_bx_product_codes_0.Text = "Business";
			// 
			// _chk_bx_product_codes_3
			// 
			_chk_bx_product_codes_3.AllowDrop = true;
			_chk_bx_product_codes_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_bx_product_codes_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_bx_product_codes_3.Location = new System.Drawing.Point(346, 238);
			_chk_bx_product_codes_3.Name = "_chk_bx_product_codes_3";
			_chk_bx_product_codes_3.Size = new System.Drawing.Size(70, 20);
			_chk_bx_product_codes_3.TabIndex = 161;
			_chk_bx_product_codes_3.Text = "Helicopters";
			// 
			// _chk_bx_product_codes_2
			// 
			_chk_bx_product_codes_2.AllowDrop = true;
			_chk_bx_product_codes_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chk_bx_product_codes_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_bx_product_codes_2.Location = new System.Drawing.Point(386, 226);
			_chk_bx_product_codes_2.Name = "_chk_bx_product_codes_2";
			_chk_bx_product_codes_2.Size = new System.Drawing.Size(71, 11);
			_chk_bx_product_codes_2.TabIndex = 162;
			_chk_bx_product_codes_2.Text = "Commercial";
			// 
			// _lbl_Class_3
			// 
			_lbl_Class_3.AllowDrop = true;
			_lbl_Class_3.AutoSize = true;
			_lbl_Class_3.BackColor = System.Drawing.Color.Transparent;
			_lbl_Class_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Class_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Class_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Class_3.Location = new System.Drawing.Point(312, 60);
			_lbl_Class_3.MinimumSize = new System.Drawing.Size(47, 13);
			_lbl_Class_3.Name = "_lbl_Class_3";
			_lbl_Class_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Class_3.Size = new System.Drawing.Size(47, 13);
			_lbl_Class_3.TabIndex = 165;
			_lbl_Class_3.Text = "Int/Config";
			// 
			// _lbl_Class_2
			// 
			_lbl_Class_2.AllowDrop = true;
			_lbl_Class_2.AutoSize = true;
			_lbl_Class_2.BackColor = System.Drawing.Color.Transparent;
			_lbl_Class_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Class_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Class_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Class_2.Location = new System.Drawing.Point(162, 60);
			_lbl_Class_2.MinimumSize = new System.Drawing.Size(34, 13);
			_lbl_Class_2.Name = "_lbl_Class_2";
			_lbl_Class_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Class_2.Size = new System.Drawing.Size(34, 13);
			_lbl_Class_2.TabIndex = 141;
			_lbl_Class_2.Text = "Usage:";
			// 
			// _lbl_Class_1
			// 
			_lbl_Class_1.AllowDrop = true;
			_lbl_Class_1.AutoSize = true;
			_lbl_Class_1.BackColor = System.Drawing.Color.Transparent;
			_lbl_Class_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Class_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Class_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Class_1.Location = new System.Drawing.Point(7, 60);
			_lbl_Class_1.MinimumSize = new System.Drawing.Size(41, 13);
			_lbl_Class_1.Name = "_lbl_Class_1";
			_lbl_Class_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Class_1.Size = new System.Drawing.Size(41, 13);
			_lbl_Class_1.TabIndex = 140;
			_lbl_Class_1.Text = "Airframe:";
			// 
			// Line1
			// 
			Line1.AllowDrop = true;
			Line1.BackColor = System.Drawing.SystemColors.WindowText;
			Line1.Enabled = false;
			Line1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Line1.Location = new System.Drawing.Point(350, 273);
			Line1.Name = "Line1";
			Line1.Size = new System.Drawing.Size(109, 1);
			Line1.Visible = true;
			// 
			// Label8
			// 
			Label8.AllowDrop = true;
			Label8.BackColor = System.Drawing.SystemColors.Control;
			Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			Label8.Location = new System.Drawing.Point(351, 256);
			Label8.MinimumSize = new System.Drawing.Size(105, 16);
			Label8.Name = "Label8";
			Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label8.Size = new System.Drawing.Size(105, 16);
			Label8.TabIndex = 139;
			Label8.Text = "Number of Engines";
			// 
			// lblSerialTo
			// 
			lblSerialTo.AllowDrop = true;
			lblSerialTo.AutoSize = true;
			lblSerialTo.BackColor = System.Drawing.Color.Transparent;
			lblSerialTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSerialTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSerialTo.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSerialTo.Location = new System.Drawing.Point(176, 33);
			lblSerialTo.MinimumSize = new System.Drawing.Size(9, 13);
			lblSerialTo.Name = "lblSerialTo";
			lblSerialTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSerialTo.Size = new System.Drawing.Size(9, 13);
			lblSerialTo.TabIndex = 132;
			lblSerialTo.Text = "to";
			// 
			// lblTo
			// 
			lblTo.AllowDrop = true;
			lblTo.AutoSize = true;
			lblTo.BackColor = System.Drawing.Color.Transparent;
			lblTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTo.ForeColor = System.Drawing.SystemColors.ControlText;
			lblTo.Location = new System.Drawing.Point(250, 280);
			lblTo.MinimumSize = new System.Drawing.Size(13, 13);
			lblTo.Name = "lblTo";
			lblTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblTo.Size = new System.Drawing.Size(13, 13);
			lblTo.TabIndex = 128;
			lblTo.Text = "To";
			// 
			// lblFrom
			// 
			lblFrom.AllowDrop = true;
			lblFrom.AutoSize = true;
			lblFrom.BackColor = System.Drawing.Color.Transparent;
			lblFrom.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFrom.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFrom.Location = new System.Drawing.Point(161, 280);
			lblFrom.MinimumSize = new System.Drawing.Size(23, 13);
			lblFrom.Name = "lblFrom";
			lblFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFrom.Size = new System.Drawing.Size(23, 13);
			lblFrom.TabIndex = 127;
			lblFrom.Text = "From";
			// 
			// lblEngSerNo
			// 
			lblEngSerNo.AllowDrop = true;
			lblEngSerNo.AutoSize = true;
			lblEngSerNo.BackColor = System.Drawing.Color.Transparent;
			lblEngSerNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblEngSerNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblEngSerNo.ForeColor = System.Drawing.SystemColors.ControlText;
			lblEngSerNo.Location = new System.Drawing.Point(162, 262);
			lblEngSerNo.MinimumSize = new System.Drawing.Size(106, 13);
			lblEngSerNo.Name = "lblEngSerNo";
			lblEngSerNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblEngSerNo.Size = new System.Drawing.Size(106, 13);
			lblEngSerNo.TabIndex = 95;
			lblEngSerNo.Text = "Engine/Prop Serial No";
			// 
			// Label4
			// 
			Label4.AllowDrop = true;
			Label4.AutoSize = true;
			Label4.BackColor = System.Drawing.Color.Transparent;
			Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			Label4.Location = new System.Drawing.Point(4, 304);
			Label4.MinimumSize = new System.Drawing.Size(136, 13);
			Label4.Name = "Label4";
			Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label4.Size = new System.Drawing.Size(136, 13);
			Label4.TabIndex = 93;
			Label4.Text = "Engine Maint Program (EMP)";
			// 
			// lblEngineModel
			// 
			lblEngineModel.AllowDrop = true;
			lblEngineModel.AutoSize = true;
			lblEngineModel.BackColor = System.Drawing.Color.Transparent;
			lblEngineModel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblEngineModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblEngineModel.ForeColor = System.Drawing.SystemColors.ControlText;
			lblEngineModel.Location = new System.Drawing.Point(14, 256);
			lblEngineModel.MinimumSize = new System.Drawing.Size(65, 13);
			lblEngineModel.Name = "lblEngineModel";
			lblEngineModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblEngineModel.Size = new System.Drawing.Size(65, 13);
			lblEngineModel.TabIndex = 90;
			lblEngineModel.Text = "Engine Model";
			lblEngineModel.DoubleClick += new System.EventHandler(lblEngineModel_DoubleClick);
			// 
			// lblMaintained
			// 
			lblMaintained.AllowDrop = true;
			lblMaintained.AutoSize = true;
			lblMaintained.BackColor = System.Drawing.Color.Transparent;
			lblMaintained.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblMaintained.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblMaintained.ForeColor = System.Drawing.SystemColors.ControlText;
			lblMaintained.Location = new System.Drawing.Point(161, 210);
			lblMaintained.MinimumSize = new System.Drawing.Size(116, 13);
			lblMaintained.Name = "lblMaintained";
			lblMaintained.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblMaintained.Size = new System.Drawing.Size(116, 13);
			lblMaintained.TabIndex = 88;
			lblMaintained.Text = "Maintenance Regulation";
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.AutoSize = true;
			Label3.BackColor = System.Drawing.Color.Transparent;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(7, 210);
			Label3.MinimumSize = new System.Drawing.Size(62, 13);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(62, 13);
			Label3.TabIndex = 86;
			Label3.Text = "Weight Class";
			// 
			// lblRegNo
			// 
			lblRegNo.AllowDrop = true;
			lblRegNo.AutoSize = true;
			lblRegNo.BackColor = System.Drawing.Color.Transparent;
			lblRegNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblRegNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblRegNo.ForeColor = System.Drawing.SystemColors.ControlText;
			lblRegNo.Location = new System.Drawing.Point(252, 15);
			lblRegNo.MinimumSize = new System.Drawing.Size(30, 13);
			lblRegNo.Name = "lblRegNo";
			lblRegNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblRegNo.Size = new System.Drawing.Size(30, 13);
			lblRegNo.TabIndex = 67;
			lblRegNo.Text = "Reg #";
			// 
			// lblSerialNo
			// 
			lblSerialNo.AllowDrop = true;
			lblSerialNo.AutoSize = true;
			lblSerialNo.BackColor = System.Drawing.Color.Transparent;
			lblSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSerialNo.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSerialNo.Location = new System.Drawing.Point(112, 15);
			lblSerialNo.MinimumSize = new System.Drawing.Size(36, 13);
			lblSerialNo.Name = "lblSerialNo";
			lblSerialNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSerialNo.Size = new System.Drawing.Size(36, 13);
			lblSerialNo.TabIndex = 65;
			lblSerialNo.Text = "Serial #";
			// 
			// lblYears
			// 
			lblYears.AllowDrop = true;
			lblYears.AutoSize = true;
			lblYears.BackColor = System.Drawing.Color.Transparent;
			lblYears.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblYears.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblYears.ForeColor = System.Drawing.SystemColors.ControlText;
			lblYears.Location = new System.Drawing.Point(348, 15);
			lblYears.MinimumSize = new System.Drawing.Size(27, 13);
			lblYears.Name = "lblYears";
			lblYears.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblYears.Size = new System.Drawing.Size(27, 13);
			lblYears.TabIndex = 63;
			lblYears.Text = "Years";
			// 
			// lblYearsTo
			// 
			lblYearsTo.AllowDrop = true;
			lblYearsTo.AutoSize = true;
			lblYearsTo.BackColor = System.Drawing.Color.Transparent;
			lblYearsTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblYearsTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblYearsTo.ForeColor = System.Drawing.SystemColors.ControlText;
			lblYearsTo.Location = new System.Drawing.Point(395, 33);
			lblYearsTo.MinimumSize = new System.Drawing.Size(9, 13);
			lblYearsTo.Name = "lblYearsTo";
			lblYearsTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblYearsTo.Size = new System.Drawing.Size(9, 13);
			lblYearsTo.TabIndex = 61;
			lblYearsTo.Text = "to";
			// 
			// _lbl_Class_0
			// 
			_lbl_Class_0.AllowDrop = true;
			_lbl_Class_0.AutoSize = true;
			_lbl_Class_0.BackColor = System.Drawing.Color.Transparent;
			_lbl_Class_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Class_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Class_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Class_0.Location = new System.Drawing.Point(46, 15);
			_lbl_Class_0.MinimumSize = new System.Drawing.Size(25, 13);
			_lbl_Class_0.Name = "_lbl_Class_0";
			_lbl_Class_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Class_0.Size = new System.Drawing.Size(25, 13);
			_lbl_Class_0.TabIndex = 51;
			_lbl_Class_0.Text = "Class";
			// 
			// lblType
			// 
			lblType.AllowDrop = true;
			lblType.AutoSize = true;
			lblType.BackColor = System.Drawing.Color.Transparent;
			lblType.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblType.ForeColor = System.Drawing.SystemColors.ControlText;
			lblType.Location = new System.Drawing.Point(7, 80);
			lblType.MinimumSize = new System.Drawing.Size(54, 13);
			lblType.Name = "lblType";
			lblType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblType.Size = new System.Drawing.Size(54, 13);
			lblType.TabIndex = 32;
			lblType.Text = "Make Type";
			// 
			// lblMake
			// 
			lblMake.AllowDrop = true;
			lblMake.AutoSize = true;
			lblMake.BackColor = System.Drawing.Color.Transparent;
			lblMake.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblMake.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblMake.ForeColor = System.Drawing.SystemColors.ControlText;
			lblMake.Location = new System.Drawing.Point(123, 80);
			lblMake.MinimumSize = new System.Drawing.Size(27, 13);
			lblMake.Name = "lblMake";
			lblMake.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblMake.Size = new System.Drawing.Size(27, 13);
			lblMake.TabIndex = 31;
			lblMake.Text = "Make";
			// 
			// lblModel
			// 
			lblModel.AllowDrop = true;
			lblModel.AutoSize = true;
			lblModel.BackColor = System.Drawing.Color.Transparent;
			lblModel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblModel.ForeColor = System.Drawing.SystemColors.ControlText;
			lblModel.Location = new System.Drawing.Point(307, 80);
			lblModel.MinimumSize = new System.Drawing.Size(29, 13);
			lblModel.Name = "lblModel";
			lblModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblModel.Size = new System.Drawing.Size(29, 13);
			lblModel.TabIndex = 30;
			lblModel.Text = "Model";
			// 
			// fraCompanyDemographics
			// 
			fraCompanyDemographics.AllowDrop = true;
			fraCompanyDemographics.Controls.Add(frm_Transactions);
			fraCompanyDemographics.Controls.Add(cbo_agency_type);
			fraCompanyDemographics.Controls.Add(opt_CompanyContinent);
			fraCompanyDemographics.Controls.Add(opt_CompanyRegion);
			fraCompanyDemographics.Controls.Add(lst_CompanyArea);
			fraCompanyDemographics.Controls.Add(cbo_Acc_Rep);
			fraCompanyDemographics.Controls.Add(txtCompanyCity);
			fraCompanyDemographics.Controls.Add(txtCompanyZip);
			fraCompanyDemographics.Controls.Add(txtCompanyPhone);
			fraCompanyDemographics.Controls.Add(cboBusinessType);
			fraCompanyDemographics.Controls.Add(txtCompanyName);
			fraCompanyDemographics.Controls.Add(lstCompanyTimeZone);
			fraCompanyDemographics.Controls.Add(lstCompanyState);
			fraCompanyDemographics.Controls.Add(lstCompanyCountry);
			fraCompanyDemographics.Controls.Add(lstCompanyType);
			fraCompanyDemographics.Controls.Add(_lblBusinessType_1);
			fraCompanyDemographics.Controls.Add(lbl_AccRep);
			fraCompanyDemographics.Controls.Add(lblCompanyCity);
			fraCompanyDemographics.Controls.Add(lblCompanyZip);
			fraCompanyDemographics.Controls.Add(lblCompanyPhone);
			fraCompanyDemographics.Controls.Add(_lblBusinessType_0);
			fraCompanyDemographics.Controls.Add(lblCompanyName);
			fraCompanyDemographics.Controls.Add(lblCompanyTimeZone);
			fraCompanyDemographics.Controls.Add(lblCompanyState);
			fraCompanyDemographics.Controls.Add(lblCompanyCountry);
			fraCompanyDemographics.Controls.Add(lblCompanyType);
			fraCompanyDemographics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fraCompanyDemographics.ForeColor = System.Drawing.Color.Navy;
			fraCompanyDemographics.Location = new System.Drawing.Point(496, 273);
			fraCompanyDemographics.Name = "fraCompanyDemographics";
			fraCompanyDemographics.Size = new System.Drawing.Size(481, 302);
			fraCompanyDemographics.TabIndex = 42;
			fraCompanyDemographics.Text = "Company Demographics";
			fraCompanyDemographics.Visible = false;
			// 
			// frm_Transactions
			// 
			frm_Transactions.AllowDrop = true;
			frm_Transactions.BackColor = System.Drawing.SystemColors.Control;
			frm_Transactions.Controls.Add(cbo_JournalCategory);
			frm_Transactions.Controls.Add(cbo_ContactType);
			frm_Transactions.Controls.Add(cmdHideTrans);
			frm_Transactions.Controls.Add(lblJournalCategory);
			frm_Transactions.Controls.Add(lblcontacttype);
			frm_Transactions.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_Transactions.Enabled = true;
			frm_Transactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_Transactions.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_Transactions.Location = new System.Drawing.Point(171, 101);
			frm_Transactions.Name = "frm_Transactions";
			frm_Transactions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_Transactions.Size = new System.Drawing.Size(300, 100);
			frm_Transactions.TabIndex = 147;
			frm_Transactions.Text = "Transactions";
			frm_Transactions.Visible = false;
			// 
			// cbo_JournalCategory
			// 
			cbo_JournalCategory.AllowDrop = true;
			cbo_JournalCategory.BackColor = System.Drawing.SystemColors.Window;
			cbo_JournalCategory.CausesValidation = true;
			cbo_JournalCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_JournalCategory.Enabled = true;
			cbo_JournalCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_JournalCategory.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_JournalCategory.IntegralHeight = true;
			cbo_JournalCategory.Location = new System.Drawing.Point(96, 48);
			cbo_JournalCategory.Name = "cbo_JournalCategory";
			cbo_JournalCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_JournalCategory.Size = new System.Drawing.Size(195, 21);
			cbo_JournalCategory.Sorted = false;
			cbo_JournalCategory.TabIndex = 152;
			cbo_JournalCategory.TabStop = true;
			cbo_JournalCategory.Visible = true;
			cbo_JournalCategory.SelectionChangeCommitted += new System.EventHandler(cbo_JournalCategory_SelectionChangeCommitted);
			// 
			// cbo_ContactType
			// 
			cbo_ContactType.AllowDrop = true;
			cbo_ContactType.BackColor = System.Drawing.SystemColors.Window;
			cbo_ContactType.CausesValidation = true;
			cbo_ContactType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ContactType.Enabled = true;
			cbo_ContactType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ContactType.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ContactType.IntegralHeight = true;
			cbo_ContactType.Location = new System.Drawing.Point(96, 16);
			cbo_ContactType.Name = "cbo_ContactType";
			cbo_ContactType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ContactType.Size = new System.Drawing.Size(195, 21);
			cbo_ContactType.Sorted = false;
			cbo_ContactType.TabIndex = 149;
			cbo_ContactType.TabStop = true;
			cbo_ContactType.Visible = true;
			cbo_ContactType.SelectionChangeCommitted += new System.EventHandler(cbo_ContactType_SelectionChangeCommitted);
			// 
			// cmdHideTrans
			// 
			cmdHideTrans.AllowDrop = true;
			cmdHideTrans.BackColor = System.Drawing.SystemColors.Control;
			cmdHideTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdHideTrans.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdHideTrans.Location = new System.Drawing.Point(120, 74);
			cmdHideTrans.Name = "cmdHideTrans";
			cmdHideTrans.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdHideTrans.Size = new System.Drawing.Size(33, 17);
			cmdHideTrans.TabIndex = 148;
			cmdHideTrans.Text = "Hide";
			cmdHideTrans.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdHideTrans.UseVisualStyleBackColor = false;
			cmdHideTrans.Click += new System.EventHandler(cmdHideTrans_Click);
			// 
			// lblJournalCategory
			// 
			lblJournalCategory.AllowDrop = true;
			lblJournalCategory.BackColor = System.Drawing.SystemColors.Control;
			lblJournalCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblJournalCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblJournalCategory.ForeColor = System.Drawing.Color.Blue;
			lblJournalCategory.Location = new System.Drawing.Point(8, 48);
			lblJournalCategory.MinimumSize = new System.Drawing.Size(83, 17);
			lblJournalCategory.Name = "lblJournalCategory";
			lblJournalCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblJournalCategory.Size = new System.Drawing.Size(83, 17);
			lblJournalCategory.TabIndex = 151;
			lblJournalCategory.Text = "Journal Category";
			lblJournalCategory.Click += new System.EventHandler(lblJournalCategory_Click);
			// 
			// lblcontacttype
			// 
			lblcontacttype.AllowDrop = true;
			lblcontacttype.BackColor = System.Drawing.SystemColors.Control;
			lblcontacttype.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblcontacttype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblcontacttype.ForeColor = System.Drawing.SystemColors.ControlText;
			lblcontacttype.Location = new System.Drawing.Point(8, 24);
			lblcontacttype.MinimumSize = new System.Drawing.Size(73, 17);
			lblcontacttype.Name = "lblcontacttype";
			lblcontacttype.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblcontacttype.Size = new System.Drawing.Size(73, 17);
			lblcontacttype.TabIndex = 150;
			lblcontacttype.Text = "Contact Type:";
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
			cbo_agency_type.Location = new System.Drawing.Point(360, 64);
			cbo_agency_type.Name = "cbo_agency_type";
			cbo_agency_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_agency_type.Size = new System.Drawing.Size(104, 21);
			cbo_agency_type.Sorted = false;
			cbo_agency_type.TabIndex = 143;
			cbo_agency_type.TabStop = true;
			cbo_agency_type.Visible = true;
			// 
			// opt_CompanyContinent
			// 
			opt_CompanyContinent.AllowDrop = true;
			opt_CompanyContinent.BackColor = System.Drawing.SystemColors.Control;
			opt_CompanyContinent.CausesValidation = true;
			opt_CompanyContinent.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_CompanyContinent.Checked = false;
			opt_CompanyContinent.Enabled = true;
			opt_CompanyContinent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_CompanyContinent.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_CompanyContinent.Location = new System.Drawing.Point(14, 101);
			opt_CompanyContinent.Name = "opt_CompanyContinent";
			opt_CompanyContinent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_CompanyContinent.Size = new System.Drawing.Size(68, 14);
			opt_CompanyContinent.TabIndex = 131;
			opt_CompanyContinent.TabStop = true;
			opt_CompanyContinent.Text = "Continent";
			opt_CompanyContinent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_CompanyContinent.Visible = true;
			opt_CompanyContinent.CheckedChanged += new System.EventHandler(opt_CompanyContinent_CheckedChanged);
			// 
			// opt_CompanyRegion
			// 
			opt_CompanyRegion.AllowDrop = true;
			opt_CompanyRegion.BackColor = System.Drawing.SystemColors.Control;
			opt_CompanyRegion.CausesValidation = true;
			opt_CompanyRegion.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_CompanyRegion.Checked = false;
			opt_CompanyRegion.Enabled = true;
			opt_CompanyRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_CompanyRegion.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_CompanyRegion.Location = new System.Drawing.Point(81, 102);
			opt_CompanyRegion.Name = "opt_CompanyRegion";
			opt_CompanyRegion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_CompanyRegion.Size = new System.Drawing.Size(68, 14);
			opt_CompanyRegion.TabIndex = 130;
			opt_CompanyRegion.TabStop = true;
			opt_CompanyRegion.Text = "Region";
			opt_CompanyRegion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_CompanyRegion.Visible = true;
			opt_CompanyRegion.CheckedChanged += new System.EventHandler(opt_CompanyRegion_CheckedChanged);
			// 
			// lst_CompanyArea
			// 
			lst_CompanyArea.AllowDrop = true;
			lst_CompanyArea.BackColor = System.Drawing.SystemColors.Window;
			lst_CompanyArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_CompanyArea.CausesValidation = true;
			lst_CompanyArea.Enabled = true;
			lst_CompanyArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_CompanyArea.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_CompanyArea.IntegralHeight = true;
			lst_CompanyArea.Location = new System.Drawing.Point(14, 117);
			lst_CompanyArea.MultiColumn = false;
			lst_CompanyArea.Name = "lst_CompanyArea";
			lst_CompanyArea.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_CompanyArea.Size = new System.Drawing.Size(156, 70);
			lst_CompanyArea.Sorted = false;
			lst_CompanyArea.TabIndex = 129;
			lst_CompanyArea.TabStop = true;
			lst_CompanyArea.Visible = true;
			lst_CompanyArea.SelectedIndexChanged += new System.EventHandler(lst_CompanyArea_SelectedIndexChanged);
			// 
			// cbo_Acc_Rep
			// 
			cbo_Acc_Rep.AllowDrop = true;
			cbo_Acc_Rep.BackColor = System.Drawing.SystemColors.Window;
			cbo_Acc_Rep.CausesValidation = true;
			cbo_Acc_Rep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_Acc_Rep.Enabled = true;
			cbo_Acc_Rep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Acc_Rep.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Acc_Rep.IntegralHeight = true;
			cbo_Acc_Rep.Location = new System.Drawing.Point(360, 32);
			cbo_Acc_Rep.Name = "cbo_Acc_Rep";
			cbo_Acc_Rep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Acc_Rep.Size = new System.Drawing.Size(104, 21);
			cbo_Acc_Rep.Sorted = false;
			cbo_Acc_Rep.TabIndex = 15;
			cbo_Acc_Rep.TabStop = true;
			cbo_Acc_Rep.Visible = true;
			// 
			// txtCompanyCity
			// 
			txtCompanyCity.AcceptsReturn = true;
			txtCompanyCity.AllowDrop = true;
			txtCompanyCity.BackColor = System.Drawing.SystemColors.Window;
			txtCompanyCity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompanyCity.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompanyCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompanyCity.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompanyCity.Location = new System.Drawing.Point(14, 237);
			txtCompanyCity.MaxLength = 0;
			txtCompanyCity.Name = "txtCompanyCity";
			txtCompanyCity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompanyCity.Size = new System.Drawing.Size(161, 19);
			txtCompanyCity.TabIndex = 22;
			// 
			// txtCompanyZip
			// 
			txtCompanyZip.AcceptsReturn = true;
			txtCompanyZip.AllowDrop = true;
			txtCompanyZip.BackColor = System.Drawing.SystemColors.Window;
			txtCompanyZip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompanyZip.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompanyZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompanyZip.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompanyZip.Location = new System.Drawing.Point(179, 237);
			txtCompanyZip.MaxLength = 0;
			txtCompanyZip.Name = "txtCompanyZip";
			txtCompanyZip.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompanyZip.Size = new System.Drawing.Size(54, 19);
			txtCompanyZip.TabIndex = 23;
			// 
			// txtCompanyPhone
			// 
			txtCompanyPhone.AcceptsReturn = true;
			txtCompanyPhone.AllowDrop = true;
			txtCompanyPhone.BackColor = System.Drawing.SystemColors.Window;
			txtCompanyPhone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompanyPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompanyPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompanyPhone.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompanyPhone.Location = new System.Drawing.Point(14, 272);
			txtCompanyPhone.MaxLength = 0;
			txtCompanyPhone.Name = "txtCompanyPhone";
			txtCompanyPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompanyPhone.Size = new System.Drawing.Size(161, 19);
			txtCompanyPhone.TabIndex = 24;
			txtCompanyPhone.Visible = false;
			// 
			// cboBusinessType
			// 
			cboBusinessType.AllowDrop = true;
			cboBusinessType.BackColor = System.Drawing.SystemColors.Window;
			cboBusinessType.CausesValidation = true;
			cboBusinessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboBusinessType.Enabled = true;
			cboBusinessType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboBusinessType.ForeColor = System.Drawing.SystemColors.WindowText;
			cboBusinessType.IntegralHeight = true;
			cboBusinessType.Location = new System.Drawing.Point(179, 271);
			cboBusinessType.Name = "cboBusinessType";
			cboBusinessType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboBusinessType.Size = new System.Drawing.Size(226, 21);
			cboBusinessType.Sorted = false;
			cboBusinessType.TabIndex = 25;
			cboBusinessType.TabStop = true;
			cboBusinessType.Visible = true;
			// 
			// txtCompanyName
			// 
			txtCompanyName.AcceptsReturn = true;
			txtCompanyName.AllowDrop = true;
			txtCompanyName.BackColor = System.Drawing.SystemColors.Window;
			txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompanyName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompanyName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompanyName.Location = new System.Drawing.Point(14, 203);
			txtCompanyName.MaxLength = 0;
			txtCompanyName.Name = "txtCompanyName";
			txtCompanyName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompanyName.Size = new System.Drawing.Size(439, 19);
			txtCompanyName.TabIndex = 21;
			// 
			// lstCompanyTimeZone
			// 
			lstCompanyTimeZone.AllowDrop = true;
			lstCompanyTimeZone.BackColor = System.Drawing.SystemColors.Window;
			lstCompanyTimeZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstCompanyTimeZone.CausesValidation = true;
			lstCompanyTimeZone.Enabled = true;
			lstCompanyTimeZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstCompanyTimeZone.ForeColor = System.Drawing.SystemColors.WindowText;
			lstCompanyTimeZone.IntegralHeight = true;
			lstCompanyTimeZone.Location = new System.Drawing.Point(182, 29);
			lstCompanyTimeZone.MultiColumn = false;
			lstCompanyTimeZone.Name = "lstCompanyTimeZone";
			lstCompanyTimeZone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstCompanyTimeZone.Size = new System.Drawing.Size(119, 70);
			lstCompanyTimeZone.Sorted = false;
			lstCompanyTimeZone.TabIndex = 14;
			lstCompanyTimeZone.TabStop = true;
			lstCompanyTimeZone.Visible = true;
			// 
			// lstCompanyState
			// 
			lstCompanyState.AllowDrop = true;
			lstCompanyState.BackColor = System.Drawing.SystemColors.Window;
			lstCompanyState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lstCompanyState.CausesValidation = true;
			lstCompanyState.Enabled = true;
			lstCompanyState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstCompanyState.ForeColor = System.Drawing.SystemColors.WindowText;
			lstCompanyState.IntegralHeight = true;
			lstCompanyState.Location = new System.Drawing.Point(295, 117);
			lstCompanyState.MultiColumn = false;
			lstCompanyState.Name = "lstCompanyState";
			lstCompanyState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstCompanyState.Size = new System.Drawing.Size(141, 72);
			lstCompanyState.Sorted = false;
			lstCompanyState.TabIndex = 17;
			lstCompanyState.TabStop = true;
			lstCompanyState.Visible = true;
			lstCompanyState.SelectedIndexChanged += new System.EventHandler(lstCompanyState_SelectedIndexChanged);
			// 
			// lstCompanyCountry
			// 
			lstCompanyCountry.AllowDrop = true;
			lstCompanyCountry.BackColor = System.Drawing.SystemColors.Window;
			lstCompanyCountry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lstCompanyCountry.CausesValidation = true;
			lstCompanyCountry.Enabled = true;
			lstCompanyCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstCompanyCountry.ForeColor = System.Drawing.SystemColors.WindowText;
			lstCompanyCountry.IntegralHeight = true;
			lstCompanyCountry.Location = new System.Drawing.Point(171, 117);
			lstCompanyCountry.MultiColumn = false;
			lstCompanyCountry.Name = "lstCompanyCountry";
			lstCompanyCountry.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstCompanyCountry.Size = new System.Drawing.Size(124, 72);
			lstCompanyCountry.Sorted = false;
			lstCompanyCountry.TabIndex = 19;
			lstCompanyCountry.TabStop = true;
			lstCompanyCountry.Visible = true;
			lstCompanyCountry.SelectedIndexChanged += new System.EventHandler(lstCompanyCountry_SelectedIndexChanged);
			// 
			// lstCompanyType
			// 
			lstCompanyType.AllowDrop = true;
			lstCompanyType.BackColor = System.Drawing.SystemColors.Window;
			lstCompanyType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstCompanyType.CausesValidation = true;
			lstCompanyType.Enabled = true;
			lstCompanyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstCompanyType.ForeColor = System.Drawing.SystemColors.WindowText;
			lstCompanyType.IntegralHeight = true;
			lstCompanyType.Location = new System.Drawing.Point(14, 29);
			lstCompanyType.MultiColumn = false;
			lstCompanyType.Name = "lstCompanyType";
			lstCompanyType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstCompanyType.Size = new System.Drawing.Size(163, 70);
			lstCompanyType.Sorted = false;
			lstCompanyType.TabIndex = 13;
			lstCompanyType.TabStop = true;
			lstCompanyType.Visible = true;
			// 
			// _lblBusinessType_1
			// 
			_lblBusinessType_1.AllowDrop = true;
			_lblBusinessType_1.AutoSize = true;
			_lblBusinessType_1.BackColor = System.Drawing.Color.Transparent;
			_lblBusinessType_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblBusinessType_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblBusinessType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblBusinessType_1.Location = new System.Drawing.Point(304, 62);
			_lblBusinessType_1.MinimumSize = new System.Drawing.Size(42, 26);
			_lblBusinessType_1.Name = "_lblBusinessType_1";
			_lblBusinessType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblBusinessType_1.Size = new System.Drawing.Size(42, 26);
			_lblBusinessType_1.TabIndex = 142;
			_lblBusinessType_1.Text = "Agency Type:";
			// 
			// lbl_AccRep
			// 
			lbl_AccRep.AllowDrop = true;
			lbl_AccRep.BackColor = System.Drawing.SystemColors.Control;
			lbl_AccRep.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_AccRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_AccRep.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_AccRep.Location = new System.Drawing.Point(304, 27);
			lbl_AccRep.MinimumSize = new System.Drawing.Size(46, 31);
			lbl_AccRep.Name = "lbl_AccRep";
			lbl_AccRep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_AccRep.Size = new System.Drawing.Size(46, 31);
			lbl_AccRep.TabIndex = 59;
			lbl_AccRep.Text = "Account Rep";
			// 
			// lblCompanyCity
			// 
			lblCompanyCity.AllowDrop = true;
			lblCompanyCity.AutoSize = true;
			lblCompanyCity.BackColor = System.Drawing.Color.Transparent;
			lblCompanyCity.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompanyCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompanyCity.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompanyCity.Location = new System.Drawing.Point(14, 223);
			lblCompanyCity.MinimumSize = new System.Drawing.Size(17, 13);
			lblCompanyCity.Name = "lblCompanyCity";
			lblCompanyCity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompanyCity.Size = new System.Drawing.Size(17, 13);
			lblCompanyCity.TabIndex = 56;
			lblCompanyCity.Text = "City";
			// 
			// lblCompanyZip
			// 
			lblCompanyZip.AllowDrop = true;
			lblCompanyZip.AutoSize = true;
			lblCompanyZip.BackColor = System.Drawing.Color.Transparent;
			lblCompanyZip.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompanyZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompanyZip.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompanyZip.Location = new System.Drawing.Point(179, 223);
			lblCompanyZip.MinimumSize = new System.Drawing.Size(15, 13);
			lblCompanyZip.Name = "lblCompanyZip";
			lblCompanyZip.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompanyZip.Size = new System.Drawing.Size(15, 13);
			lblCompanyZip.TabIndex = 54;
			lblCompanyZip.Text = "Zip";
			// 
			// lblCompanyPhone
			// 
			lblCompanyPhone.AllowDrop = true;
			lblCompanyPhone.AutoSize = true;
			lblCompanyPhone.BackColor = System.Drawing.Color.Transparent;
			lblCompanyPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompanyPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompanyPhone.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompanyPhone.Location = new System.Drawing.Point(14, 256);
			lblCompanyPhone.MinimumSize = new System.Drawing.Size(31, 13);
			lblCompanyPhone.Name = "lblCompanyPhone";
			lblCompanyPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompanyPhone.Size = new System.Drawing.Size(31, 13);
			lblCompanyPhone.TabIndex = 53;
			lblCompanyPhone.Text = "Phone";
			lblCompanyPhone.Visible = false;
			// 
			// _lblBusinessType_0
			// 
			_lblBusinessType_0.AllowDrop = true;
			_lblBusinessType_0.AutoSize = true;
			_lblBusinessType_0.BackColor = System.Drawing.Color.Transparent;
			_lblBusinessType_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblBusinessType_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblBusinessType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblBusinessType_0.Location = new System.Drawing.Point(179, 256);
			_lblBusinessType_0.MinimumSize = new System.Drawing.Size(69, 13);
			_lblBusinessType_0.Name = "_lblBusinessType_0";
			_lblBusinessType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblBusinessType_0.Size = new System.Drawing.Size(69, 13);
			_lblBusinessType_0.TabIndex = 52;
			_lblBusinessType_0.Text = "Business Type";
			// 
			// lblCompanyName
			// 
			lblCompanyName.AllowDrop = true;
			lblCompanyName.AutoSize = true;
			lblCompanyName.BackColor = System.Drawing.Color.Transparent;
			lblCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompanyName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompanyName.Location = new System.Drawing.Point(14, 188);
			lblCompanyName.MinimumSize = new System.Drawing.Size(75, 13);
			lblCompanyName.Name = "lblCompanyName";
			lblCompanyName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompanyName.Size = new System.Drawing.Size(75, 13);
			lblCompanyName.TabIndex = 47;
			lblCompanyName.Text = "Company Name";
			// 
			// lblCompanyTimeZone
			// 
			lblCompanyTimeZone.AllowDrop = true;
			lblCompanyTimeZone.AutoSize = true;
			lblCompanyTimeZone.BackColor = System.Drawing.Color.Transparent;
			lblCompanyTimeZone.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompanyTimeZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompanyTimeZone.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompanyTimeZone.Location = new System.Drawing.Point(182, 15);
			lblCompanyTimeZone.MinimumSize = new System.Drawing.Size(51, 13);
			lblCompanyTimeZone.Name = "lblCompanyTimeZone";
			lblCompanyTimeZone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompanyTimeZone.Size = new System.Drawing.Size(51, 13);
			lblCompanyTimeZone.TabIndex = 46;
			lblCompanyTimeZone.Text = "Time Zone";
			// 
			// lblCompanyState
			// 
			lblCompanyState.AllowDrop = true;
			lblCompanyState.AutoSize = true;
			lblCompanyState.BackColor = System.Drawing.Color.Transparent;
			lblCompanyState.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompanyState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompanyState.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompanyState.Location = new System.Drawing.Point(297, 104);
			lblCompanyState.MinimumSize = new System.Drawing.Size(28, 13);
			lblCompanyState.Name = "lblCompanyState";
			lblCompanyState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompanyState.Size = new System.Drawing.Size(28, 13);
			lblCompanyState.TabIndex = 45;
			lblCompanyState.Text = "State:";
			// 
			// lblCompanyCountry
			// 
			lblCompanyCountry.AllowDrop = true;
			lblCompanyCountry.AutoSize = true;
			lblCompanyCountry.BackColor = System.Drawing.Color.Transparent;
			lblCompanyCountry.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompanyCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompanyCountry.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompanyCountry.Location = new System.Drawing.Point(174, 104);
			lblCompanyCountry.MinimumSize = new System.Drawing.Size(39, 13);
			lblCompanyCountry.Name = "lblCompanyCountry";
			lblCompanyCountry.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompanyCountry.Size = new System.Drawing.Size(39, 13);
			lblCompanyCountry.TabIndex = 44;
			lblCompanyCountry.Text = "Country:";
			// 
			// lblCompanyType
			// 
			lblCompanyType.AllowDrop = true;
			lblCompanyType.AutoSize = true;
			lblCompanyType.BackColor = System.Drawing.Color.Transparent;
			lblCompanyType.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompanyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompanyType.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompanyType.Location = new System.Drawing.Point(14, 16);
			lblCompanyType.MinimumSize = new System.Drawing.Size(64, 13);
			lblCompanyType.Name = "lblCompanyType";
			lblCompanyType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompanyType.Size = new System.Drawing.Size(64, 13);
			lblCompanyType.TabIndex = 43;
			lblCompanyType.Text = "Contact Type";
			// 
			// fraStatus
			// 
			fraStatus.AllowDrop = true;
			fraStatus.Controls.Add(txt_ac_status);
			fraStatus.Controls.Add(cmb_engine_noise_rating);
			fraStatus.Controls.Add(cmb_model_config);
			fraStatus.Controls.Add(cbo_ac_lifecycle_stage);
			fraStatus.Controls.Add(cboOwnType);
			fraStatus.Controls.Add(cboExclusive);
			fraStatus.Controls.Add(cboLeaseStatus);
			fraStatus.Controls.Add(cbo_ac_delivery);
			fraStatus.Controls.Add(cbo_ac_asking);
			fraStatus.Controls.Add(optNotForSale);
			fraStatus.Controls.Add(optForSale);
			fraStatus.Controls.Add(optAll);
			fraStatus.Controls.Add(_Label7_0);
			fraStatus.Controls.Add(Label6);
			fraStatus.Controls.Add(lbl_Stage);
			fraStatus.Controls.Add(lblOwnershipType);
			fraStatus.Controls.Add(lblExclusive);
			fraStatus.Controls.Add(lblLeaseStatus);
			fraStatus.Controls.Add(lbl_delivery);
			fraStatus.Controls.Add(lbl_asking);
			fraStatus.Controls.Add(lbl_ac_status);
			fraStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fraStatus.ForeColor = System.Drawing.Color.Navy;
			fraStatus.Location = new System.Drawing.Point(496, 132);
			fraStatus.Name = "fraStatus";
			fraStatus.Size = new System.Drawing.Size(481, 142);
			fraStatus.TabIndex = 33;
			fraStatus.Text = "Status Information";
			// 
			// txt_ac_status
			// 
			txt_ac_status.AllowDrop = true;
			txt_ac_status.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_status.CausesValidation = true;
			txt_ac_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			txt_ac_status.Enabled = true;
			txt_ac_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_status.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_status.IntegralHeight = true;
			txt_ac_status.Location = new System.Drawing.Point(322, 56);
			txt_ac_status.Name = "txt_ac_status";
			txt_ac_status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_status.Size = new System.Drawing.Size(157, 21);
			txt_ac_status.Sorted = false;
			txt_ac_status.TabIndex = 175;
			txt_ac_status.TabStop = true;
			txt_ac_status.Visible = true;
			// 
			// cmb_engine_noise_rating
			// 
			cmb_engine_noise_rating.AllowDrop = true;
			cmb_engine_noise_rating.BackColor = System.Drawing.SystemColors.Window;
			cmb_engine_noise_rating.CausesValidation = true;
			cmb_engine_noise_rating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmb_engine_noise_rating.Enabled = true;
			cmb_engine_noise_rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_engine_noise_rating.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_engine_noise_rating.IntegralHeight = true;
			cmb_engine_noise_rating.Location = new System.Drawing.Point(366, 107);
			cmb_engine_noise_rating.Name = "cmb_engine_noise_rating";
			cmb_engine_noise_rating.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_engine_noise_rating.Size = new System.Drawing.Size(113, 21);
			cmb_engine_noise_rating.Sorted = false;
			cmb_engine_noise_rating.TabIndex = 124;
			cmb_engine_noise_rating.TabStop = true;
			cmb_engine_noise_rating.Visible = true;
			// 
			// cmb_model_config
			// 
			cmb_model_config.AllowDrop = true;
			cmb_model_config.BackColor = System.Drawing.SystemColors.Window;
			cmb_model_config.CausesValidation = true;
			cmb_model_config.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmb_model_config.Enabled = true;
			cmb_model_config.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_model_config.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_model_config.IntegralHeight = true;
			cmb_model_config.Location = new System.Drawing.Point(88, 105);
			cmb_model_config.Name = "cmb_model_config";
			cmb_model_config.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_model_config.Size = new System.Drawing.Size(131, 21);
			cmb_model_config.Sorted = false;
			cmb_model_config.TabIndex = 123;
			cmb_model_config.TabStop = true;
			cmb_model_config.Visible = true;
			// 
			// cbo_ac_lifecycle_stage
			// 
			cbo_ac_lifecycle_stage.AllowDrop = true;
			cbo_ac_lifecycle_stage.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_lifecycle_stage.CausesValidation = true;
			cbo_ac_lifecycle_stage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_lifecycle_stage.Enabled = true;
			cbo_ac_lifecycle_stage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_lifecycle_stage.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_lifecycle_stage.IntegralHeight = true;
			cbo_ac_lifecycle_stage.Location = new System.Drawing.Point(4, 31);
			cbo_ac_lifecycle_stage.Name = "cbo_ac_lifecycle_stage";
			cbo_ac_lifecycle_stage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_lifecycle_stage.Size = new System.Drawing.Size(185, 21);
			cbo_ac_lifecycle_stage.Sorted = false;
			cbo_ac_lifecycle_stage.TabIndex = 114;
			cbo_ac_lifecycle_stage.TabStop = true;
			cbo_ac_lifecycle_stage.Visible = true;
			// 
			// cboOwnType
			// 
			cboOwnType.AllowDrop = true;
			cboOwnType.BackColor = System.Drawing.SystemColors.Window;
			cboOwnType.CausesValidation = true;
			cboOwnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboOwnType.Enabled = true;
			cboOwnType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboOwnType.ForeColor = System.Drawing.SystemColors.WindowText;
			cboOwnType.IntegralHeight = true;
			cboOwnType.Location = new System.Drawing.Point(191, 29);
			cboOwnType.Name = "cboOwnType";
			cboOwnType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboOwnType.Size = new System.Drawing.Size(99, 21);
			cboOwnType.Sorted = false;
			cboOwnType.TabIndex = 115;
			cboOwnType.TabStop = true;
			cboOwnType.Visible = true;
			// 
			// cboExclusive
			// 
			cboExclusive.AllowDrop = true;
			cboExclusive.BackColor = System.Drawing.SystemColors.Window;
			cboExclusive.CausesValidation = true;
			cboExclusive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboExclusive.Enabled = true;
			cboExclusive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboExclusive.ForeColor = System.Drawing.SystemColors.WindowText;
			cboExclusive.IntegralHeight = true;
			cboExclusive.Location = new System.Drawing.Point(390, 29);
			cboExclusive.Name = "cboExclusive";
			cboExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboExclusive.Size = new System.Drawing.Size(89, 21);
			cboExclusive.Sorted = false;
			cboExclusive.TabIndex = 117;
			cboExclusive.TabStop = true;
			cboExclusive.Visible = true;
			// 
			// cboLeaseStatus
			// 
			cboLeaseStatus.AllowDrop = true;
			cboLeaseStatus.BackColor = System.Drawing.SystemColors.Window;
			cboLeaseStatus.CausesValidation = true;
			cboLeaseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboLeaseStatus.Enabled = true;
			cboLeaseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboLeaseStatus.ForeColor = System.Drawing.SystemColors.WindowText;
			cboLeaseStatus.IntegralHeight = true;
			cboLeaseStatus.Location = new System.Drawing.Point(292, 29);
			cboLeaseStatus.Name = "cboLeaseStatus";
			cboLeaseStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboLeaseStatus.Size = new System.Drawing.Size(96, 21);
			cboLeaseStatus.Sorted = false;
			cboLeaseStatus.TabIndex = 116;
			cboLeaseStatus.TabStop = true;
			cboLeaseStatus.Visible = true;
			// 
			// cbo_ac_delivery
			// 
			cbo_ac_delivery.AllowDrop = true;
			cbo_ac_delivery.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_delivery.CausesValidation = true;
			cbo_ac_delivery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_delivery.Enabled = true;
			cbo_ac_delivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_delivery.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_delivery.IntegralHeight = true;
			cbo_ac_delivery.Location = new System.Drawing.Point(322, 81);
			cbo_ac_delivery.Name = "cbo_ac_delivery";
			cbo_ac_delivery.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_delivery.Size = new System.Drawing.Size(157, 21);
			cbo_ac_delivery.Sorted = false;
			cbo_ac_delivery.TabIndex = 122;
			cbo_ac_delivery.TabStop = true;
			cbo_ac_delivery.Visible = false;
			// 
			// cbo_ac_asking
			// 
			cbo_ac_asking.AllowDrop = true;
			cbo_ac_asking.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_asking.CausesValidation = true;
			cbo_ac_asking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_asking.Enabled = true;
			cbo_ac_asking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_asking.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_asking.IntegralHeight = true;
			cbo_ac_asking.Location = new System.Drawing.Point(87, 79);
			cbo_ac_asking.Name = "cbo_ac_asking";
			cbo_ac_asking.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_asking.Size = new System.Drawing.Size(132, 21);
			cbo_ac_asking.Sorted = false;
			cbo_ac_asking.TabIndex = 121;
			cbo_ac_asking.TabStop = true;
			cbo_ac_asking.Visible = false;
			// 
			// optNotForSale
			// 
			optNotForSale.AllowDrop = true;
			optNotForSale.BackColor = System.Drawing.SystemColors.Control;
			optNotForSale.CausesValidation = true;
			optNotForSale.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optNotForSale.Checked = false;
			optNotForSale.Enabled = true;
			optNotForSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optNotForSale.ForeColor = System.Drawing.SystemColors.ControlText;
			optNotForSale.Location = new System.Drawing.Point(139, 58);
			optNotForSale.Name = "optNotForSale";
			optNotForSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optNotForSale.Size = new System.Drawing.Size(82, 13);
			optNotForSale.TabIndex = 120;
			optNotForSale.TabStop = true;
			optNotForSale.Text = "Unavailable";
			optNotForSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optNotForSale.Visible = true;
			optNotForSale.CheckedChanged += new System.EventHandler(optNotForSale_CheckedChanged);
			// 
			// optForSale
			// 
			optForSale.AllowDrop = true;
			optForSale.BackColor = System.Drawing.SystemColors.Control;
			optForSale.CausesValidation = true;
			optForSale.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optForSale.Checked = false;
			optForSale.Enabled = true;
			optForSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optForSale.ForeColor = System.Drawing.SystemColors.ControlText;
			optForSale.Location = new System.Drawing.Point(67, 58);
			optForSale.Name = "optForSale";
			optForSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optForSale.Size = new System.Drawing.Size(68, 13);
			optForSale.TabIndex = 119;
			optForSale.TabStop = true;
			optForSale.Text = "Available";
			optForSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optForSale.Visible = true;
			optForSale.CheckedChanged += new System.EventHandler(optForSale_CheckedChanged);
			// 
			// optAll
			// 
			optAll.AllowDrop = true;
			optAll.BackColor = System.Drawing.SystemColors.Control;
			optAll.CausesValidation = true;
			optAll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optAll.Checked = true;
			optAll.Enabled = true;
			optAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optAll.ForeColor = System.Drawing.SystemColors.ControlText;
			optAll.Location = new System.Drawing.Point(12, 58);
			optAll.Name = "optAll";
			optAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optAll.Size = new System.Drawing.Size(52, 13);
			optAll.TabIndex = 118;
			optAll.TabStop = true;
			optAll.Text = "All";
			optAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optAll.Visible = true;
			optAll.CheckedChanged += new System.EventHandler(optAll_CheckedChanged);
			// 
			// _Label7_0
			// 
			_Label7_0.AllowDrop = true;
			_Label7_0.BackColor = System.Drawing.SystemColors.Control;
			_Label7_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label7_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label7_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label7_0.Location = new System.Drawing.Point(257, 111);
			_Label7_0.MinimumSize = new System.Drawing.Size(105, 17);
			_Label7_0.Name = "_Label7_0";
			_Label7_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label7_0.Size = new System.Drawing.Size(105, 17);
			_Label7_0.TabIndex = 146;
			_Label7_0.Text = "Engine Noise Rating:";
			// 
			// Label6
			// 
			Label6.AllowDrop = true;
			Label6.BackColor = System.Drawing.SystemColors.Control;
			Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			Label6.Location = new System.Drawing.Point(14, 107);
			Label6.MinimumSize = new System.Drawing.Size(67, 17);
			Label6.Name = "Label6";
			Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label6.Size = new System.Drawing.Size(67, 17);
			Label6.TabIndex = 145;
			Label6.Text = "Model Config:";
			// 
			// lbl_Stage
			// 
			lbl_Stage.AllowDrop = true;
			lbl_Stage.AutoSize = true;
			lbl_Stage.BackColor = System.Drawing.Color.Transparent;
			lbl_Stage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Stage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Stage.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Stage.Location = new System.Drawing.Point(4, 17);
			lbl_Stage.MinimumSize = new System.Drawing.Size(77, 13);
			lbl_Stage.Name = "lbl_Stage";
			lbl_Stage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Stage.Size = new System.Drawing.Size(77, 13);
			lbl_Stage.TabIndex = 125;
			lbl_Stage.Text = "Life Cycle Stage";
			// 
			// lblOwnershipType
			// 
			lblOwnershipType.AllowDrop = true;
			lblOwnershipType.AutoSize = true;
			lblOwnershipType.BackColor = System.Drawing.Color.Transparent;
			lblOwnershipType.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblOwnershipType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblOwnershipType.ForeColor = System.Drawing.SystemColors.ControlText;
			lblOwnershipType.Location = new System.Drawing.Point(191, 15);
			lblOwnershipType.MinimumSize = new System.Drawing.Size(77, 13);
			lblOwnershipType.Name = "lblOwnershipType";
			lblOwnershipType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblOwnershipType.Size = new System.Drawing.Size(77, 13);
			lblOwnershipType.TabIndex = 113;
			lblOwnershipType.Text = "Ownership Type";
			// 
			// lblExclusive
			// 
			lblExclusive.AllowDrop = true;
			lblExclusive.AutoSize = true;
			lblExclusive.BackColor = System.Drawing.Color.Transparent;
			lblExclusive.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblExclusive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblExclusive.ForeColor = System.Drawing.SystemColors.ControlText;
			lblExclusive.Location = new System.Drawing.Point(388, 15);
			lblExclusive.MinimumSize = new System.Drawing.Size(45, 13);
			lblExclusive.Name = "lblExclusive";
			lblExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblExclusive.Size = new System.Drawing.Size(45, 13);
			lblExclusive.TabIndex = 112;
			lblExclusive.Text = "Exclusive";
			// 
			// lblLeaseStatus
			// 
			lblLeaseStatus.AllowDrop = true;
			lblLeaseStatus.AutoSize = true;
			lblLeaseStatus.BackColor = System.Drawing.Color.Transparent;
			lblLeaseStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblLeaseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLeaseStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			lblLeaseStatus.Location = new System.Drawing.Point(290, 15);
			lblLeaseStatus.MinimumSize = new System.Drawing.Size(62, 13);
			lblLeaseStatus.Name = "lblLeaseStatus";
			lblLeaseStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLeaseStatus.Size = new System.Drawing.Size(62, 13);
			lblLeaseStatus.TabIndex = 109;
			lblLeaseStatus.Text = "Lease Status";
			// 
			// lbl_delivery
			// 
			lbl_delivery.AllowDrop = true;
			lbl_delivery.AutoSize = true;
			lbl_delivery.BackColor = System.Drawing.SystemColors.Control;
			lbl_delivery.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_delivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_delivery.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_delivery.Location = new System.Drawing.Point(257, 85);
			lbl_delivery.MinimumSize = new System.Drawing.Size(41, 13);
			lbl_delivery.Name = "lbl_delivery";
			lbl_delivery.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_delivery.Size = new System.Drawing.Size(41, 13);
			lbl_delivery.TabIndex = 80;
			lbl_delivery.Text = "Delivery:";
			lbl_delivery.Visible = false;
			// 
			// lbl_asking
			// 
			lbl_asking.AllowDrop = true;
			lbl_asking.AutoSize = true;
			lbl_asking.BackColor = System.Drawing.SystemColors.Control;
			lbl_asking.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_asking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_asking.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_asking.Location = new System.Drawing.Point(14, 83);
			lbl_asking.MinimumSize = new System.Drawing.Size(35, 13);
			lbl_asking.Name = "lbl_asking";
			lbl_asking.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_asking.Size = new System.Drawing.Size(35, 13);
			lbl_asking.TabIndex = 79;
			lbl_asking.Text = "Asking:";
			lbl_asking.Visible = false;
			// 
			// lbl_ac_status
			// 
			lbl_ac_status.AllowDrop = true;
			lbl_ac_status.BackColor = System.Drawing.SystemColors.Control;
			lbl_ac_status.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_ac_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_ac_status.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_ac_status.Location = new System.Drawing.Point(257, 58);
			lbl_ac_status.MinimumSize = new System.Drawing.Size(32, 14);
			lbl_ac_status.Name = "lbl_ac_status";
			lbl_ac_status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_ac_status.Size = new System.Drawing.Size(32, 14);
			lbl_ac_status.TabIndex = 78;
			lbl_ac_status.Text = "Status:";
			// 
			// fraUsage
			// 
			fraUsage.AllowDrop = true;
			fraUsage.Controls.Add(_cboUsage_4);
			fraUsage.Controls.Add(_cboUsageCondition_4);
			fraUsage.Controls.Add(_txtUsageValue_4);
			fraUsage.Controls.Add(_txtUsageValue_3);
			fraUsage.Controls.Add(_cboUsageCondition_3);
			fraUsage.Controls.Add(_cboUsage_3);
			fraUsage.Controls.Add(_cboUsage_0);
			fraUsage.Controls.Add(_cboUsageCondition_0);
			fraUsage.Controls.Add(_txtUsageValue_0);
			fraUsage.Controls.Add(_cboUsage_1);
			fraUsage.Controls.Add(_cboUsageCondition_1);
			fraUsage.Controls.Add(_txtUsageValue_1);
			fraUsage.Controls.Add(_txtUsageValue_2);
			fraUsage.Controls.Add(_cboUsageCondition_2);
			fraUsage.Controls.Add(_cboUsage_2);
			fraUsage.Controls.Add(_lblUsageFormat_4);
			fraUsage.Controls.Add(_lblUsageFormat_3);
			fraUsage.Controls.Add(_lblUsageFormat_2);
			fraUsage.Controls.Add(_lblUsageFormat_1);
			fraUsage.Controls.Add(_lblUsageFormat_0);
			fraUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fraUsage.ForeColor = System.Drawing.Color.Navy;
			fraUsage.Location = new System.Drawing.Point(6, 370);
			fraUsage.Name = "fraUsage";
			fraUsage.Size = new System.Drawing.Size(488, 152);
			fraUsage.TabIndex = 35;
			fraUsage.Text = "Usage/Specifications";
			// 
			// _cboUsage_4
			// 
			_cboUsage_4.AllowDrop = true;
			_cboUsage_4.BackColor = System.Drawing.SystemColors.Window;
			_cboUsage_4.CausesValidation = true;
			_cboUsage_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboUsage_4.Enabled = true;
			_cboUsage_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboUsage_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboUsage_4.IntegralHeight = true;
			_cboUsage_4.Location = new System.Drawing.Point(9, 119);
			_cboUsage_4.Name = "_cboUsage_4";
			_cboUsage_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboUsage_4.Size = new System.Drawing.Size(125, 21);
			_cboUsage_4.Sorted = false;
			_cboUsage_4.TabIndex = 73;
			_cboUsage_4.TabStop = true;
			_cboUsage_4.Visible = false;
			_cboUsage_4.SelectionChangeCommitted += new System.EventHandler(cboUsage_SelectionChangeCommitted);
			// 
			// _cboUsageCondition_4
			// 
			_cboUsageCondition_4.AllowDrop = true;
			_cboUsageCondition_4.BackColor = System.Drawing.SystemColors.Window;
			_cboUsageCondition_4.CausesValidation = true;
			_cboUsageCondition_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboUsageCondition_4.Enabled = true;
			_cboUsageCondition_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboUsageCondition_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboUsageCondition_4.IntegralHeight = true;
			_cboUsageCondition_4.Location = new System.Drawing.Point(142, 119);
			_cboUsageCondition_4.Name = "_cboUsageCondition_4";
			_cboUsageCondition_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboUsageCondition_4.Size = new System.Drawing.Size(67, 21);
			_cboUsageCondition_4.Sorted = false;
			_cboUsageCondition_4.TabIndex = 74;
			_cboUsageCondition_4.TabStop = true;
			_cboUsageCondition_4.Visible = false;
			_cboUsageCondition_4.SelectionChangeCommitted += new System.EventHandler(cboUsageCondition_SelectionChangeCommitted);
			// 
			// _txtUsageValue_4
			// 
			_txtUsageValue_4.AcceptsReturn = true;
			_txtUsageValue_4.AllowDrop = true;
			_txtUsageValue_4.BackColor = System.Drawing.SystemColors.Window;
			_txtUsageValue_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtUsageValue_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtUsageValue_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtUsageValue_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtUsageValue_4.Location = new System.Drawing.Point(214, 119);
			_txtUsageValue_4.MaxLength = 0;
			_txtUsageValue_4.Name = "_txtUsageValue_4";
			_txtUsageValue_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtUsageValue_4.Size = new System.Drawing.Size(94, 19);
			_txtUsageValue_4.TabIndex = 75;
			_txtUsageValue_4.Visible = false;
			// 
			// _txtUsageValue_3
			// 
			_txtUsageValue_3.AcceptsReturn = true;
			_txtUsageValue_3.AllowDrop = true;
			_txtUsageValue_3.BackColor = System.Drawing.SystemColors.Window;
			_txtUsageValue_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtUsageValue_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtUsageValue_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtUsageValue_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtUsageValue_3.Location = new System.Drawing.Point(214, 96);
			_txtUsageValue_3.MaxLength = 0;
			_txtUsageValue_3.Name = "_txtUsageValue_3";
			_txtUsageValue_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtUsageValue_3.Size = new System.Drawing.Size(94, 19);
			_txtUsageValue_3.TabIndex = 72;
			_txtUsageValue_3.Visible = false;
			// 
			// _cboUsageCondition_3
			// 
			_cboUsageCondition_3.AllowDrop = true;
			_cboUsageCondition_3.BackColor = System.Drawing.SystemColors.Window;
			_cboUsageCondition_3.CausesValidation = true;
			_cboUsageCondition_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboUsageCondition_3.Enabled = true;
			_cboUsageCondition_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboUsageCondition_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboUsageCondition_3.IntegralHeight = true;
			_cboUsageCondition_3.Location = new System.Drawing.Point(142, 96);
			_cboUsageCondition_3.Name = "_cboUsageCondition_3";
			_cboUsageCondition_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboUsageCondition_3.Size = new System.Drawing.Size(67, 21);
			_cboUsageCondition_3.Sorted = false;
			_cboUsageCondition_3.TabIndex = 71;
			_cboUsageCondition_3.TabStop = true;
			_cboUsageCondition_3.Visible = false;
			_cboUsageCondition_3.SelectionChangeCommitted += new System.EventHandler(cboUsageCondition_SelectionChangeCommitted);
			// 
			// _cboUsage_3
			// 
			_cboUsage_3.AllowDrop = true;
			_cboUsage_3.BackColor = System.Drawing.SystemColors.Window;
			_cboUsage_3.CausesValidation = true;
			_cboUsage_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboUsage_3.Enabled = true;
			_cboUsage_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboUsage_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboUsage_3.IntegralHeight = true;
			_cboUsage_3.Location = new System.Drawing.Point(9, 96);
			_cboUsage_3.Name = "_cboUsage_3";
			_cboUsage_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboUsage_3.Size = new System.Drawing.Size(125, 21);
			_cboUsage_3.Sorted = false;
			_cboUsage_3.TabIndex = 70;
			_cboUsage_3.TabStop = true;
			_cboUsage_3.Visible = false;
			_cboUsage_3.SelectionChangeCommitted += new System.EventHandler(cboUsage_SelectionChangeCommitted);
			// 
			// _cboUsage_0
			// 
			_cboUsage_0.AllowDrop = true;
			_cboUsage_0.BackColor = System.Drawing.SystemColors.Window;
			_cboUsage_0.CausesValidation = true;
			_cboUsage_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboUsage_0.Enabled = true;
			_cboUsage_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboUsage_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboUsage_0.IntegralHeight = true;
			_cboUsage_0.Location = new System.Drawing.Point(9, 25);
			_cboUsage_0.Name = "_cboUsage_0";
			_cboUsage_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboUsage_0.Size = new System.Drawing.Size(125, 21);
			_cboUsage_0.Sorted = false;
			_cboUsage_0.TabIndex = 55;
			_cboUsage_0.TabStop = true;
			_cboUsage_0.Visible = true;
			_cboUsage_0.SelectionChangeCommitted += new System.EventHandler(cboUsage_SelectionChangeCommitted);
			// 
			// _cboUsageCondition_0
			// 
			_cboUsageCondition_0.AllowDrop = true;
			_cboUsageCondition_0.BackColor = System.Drawing.SystemColors.Window;
			_cboUsageCondition_0.CausesValidation = true;
			_cboUsageCondition_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboUsageCondition_0.Enabled = true;
			_cboUsageCondition_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboUsageCondition_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboUsageCondition_0.IntegralHeight = true;
			_cboUsageCondition_0.Location = new System.Drawing.Point(142, 26);
			_cboUsageCondition_0.Name = "_cboUsageCondition_0";
			_cboUsageCondition_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboUsageCondition_0.Size = new System.Drawing.Size(67, 21);
			_cboUsageCondition_0.Sorted = false;
			_cboUsageCondition_0.TabIndex = 57;
			_cboUsageCondition_0.TabStop = true;
			_cboUsageCondition_0.Visible = false;
			_cboUsageCondition_0.SelectionChangeCommitted += new System.EventHandler(cboUsageCondition_SelectionChangeCommitted);
			// 
			// _txtUsageValue_0
			// 
			_txtUsageValue_0.AcceptsReturn = true;
			_txtUsageValue_0.AllowDrop = true;
			_txtUsageValue_0.BackColor = System.Drawing.SystemColors.Window;
			_txtUsageValue_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtUsageValue_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtUsageValue_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtUsageValue_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtUsageValue_0.Location = new System.Drawing.Point(214, 26);
			_txtUsageValue_0.MaxLength = 0;
			_txtUsageValue_0.Name = "_txtUsageValue_0";
			_txtUsageValue_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtUsageValue_0.Size = new System.Drawing.Size(94, 19);
			_txtUsageValue_0.TabIndex = 58;
			_txtUsageValue_0.Visible = false;
			// 
			// _cboUsage_1
			// 
			_cboUsage_1.AllowDrop = true;
			_cboUsage_1.BackColor = System.Drawing.SystemColors.Window;
			_cboUsage_1.CausesValidation = true;
			_cboUsage_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboUsage_1.Enabled = true;
			_cboUsage_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboUsage_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboUsage_1.IntegralHeight = true;
			_cboUsage_1.Location = new System.Drawing.Point(9, 49);
			_cboUsage_1.Name = "_cboUsage_1";
			_cboUsage_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboUsage_1.Size = new System.Drawing.Size(125, 21);
			_cboUsage_1.Sorted = false;
			_cboUsage_1.TabIndex = 60;
			_cboUsage_1.TabStop = true;
			_cboUsage_1.Visible = false;
			_cboUsage_1.SelectionChangeCommitted += new System.EventHandler(cboUsage_SelectionChangeCommitted);
			// 
			// _cboUsageCondition_1
			// 
			_cboUsageCondition_1.AllowDrop = true;
			_cboUsageCondition_1.BackColor = System.Drawing.SystemColors.Window;
			_cboUsageCondition_1.CausesValidation = true;
			_cboUsageCondition_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboUsageCondition_1.Enabled = true;
			_cboUsageCondition_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboUsageCondition_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboUsageCondition_1.IntegralHeight = true;
			_cboUsageCondition_1.Location = new System.Drawing.Point(142, 49);
			_cboUsageCondition_1.Name = "_cboUsageCondition_1";
			_cboUsageCondition_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboUsageCondition_1.Size = new System.Drawing.Size(67, 21);
			_cboUsageCondition_1.Sorted = false;
			_cboUsageCondition_1.TabIndex = 62;
			_cboUsageCondition_1.TabStop = true;
			_cboUsageCondition_1.Visible = false;
			_cboUsageCondition_1.SelectionChangeCommitted += new System.EventHandler(cboUsageCondition_SelectionChangeCommitted);
			// 
			// _txtUsageValue_1
			// 
			_txtUsageValue_1.AcceptsReturn = true;
			_txtUsageValue_1.AllowDrop = true;
			_txtUsageValue_1.BackColor = System.Drawing.SystemColors.Window;
			_txtUsageValue_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtUsageValue_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtUsageValue_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtUsageValue_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtUsageValue_1.Location = new System.Drawing.Point(214, 49);
			_txtUsageValue_1.MaxLength = 0;
			_txtUsageValue_1.Name = "_txtUsageValue_1";
			_txtUsageValue_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtUsageValue_1.Size = new System.Drawing.Size(94, 19);
			_txtUsageValue_1.TabIndex = 64;
			_txtUsageValue_1.Visible = false;
			// 
			// _txtUsageValue_2
			// 
			_txtUsageValue_2.AcceptsReturn = true;
			_txtUsageValue_2.AllowDrop = true;
			_txtUsageValue_2.BackColor = System.Drawing.SystemColors.Window;
			_txtUsageValue_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtUsageValue_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtUsageValue_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtUsageValue_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtUsageValue_2.Location = new System.Drawing.Point(214, 72);
			_txtUsageValue_2.MaxLength = 0;
			_txtUsageValue_2.Name = "_txtUsageValue_2";
			_txtUsageValue_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtUsageValue_2.Size = new System.Drawing.Size(94, 19);
			_txtUsageValue_2.TabIndex = 69;
			_txtUsageValue_2.Visible = false;
			// 
			// _cboUsageCondition_2
			// 
			_cboUsageCondition_2.AllowDrop = true;
			_cboUsageCondition_2.BackColor = System.Drawing.SystemColors.Window;
			_cboUsageCondition_2.CausesValidation = true;
			_cboUsageCondition_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboUsageCondition_2.Enabled = true;
			_cboUsageCondition_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboUsageCondition_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboUsageCondition_2.IntegralHeight = true;
			_cboUsageCondition_2.Location = new System.Drawing.Point(142, 72);
			_cboUsageCondition_2.Name = "_cboUsageCondition_2";
			_cboUsageCondition_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboUsageCondition_2.Size = new System.Drawing.Size(67, 21);
			_cboUsageCondition_2.Sorted = false;
			_cboUsageCondition_2.TabIndex = 68;
			_cboUsageCondition_2.TabStop = true;
			_cboUsageCondition_2.Visible = false;
			_cboUsageCondition_2.SelectionChangeCommitted += new System.EventHandler(cboUsageCondition_SelectionChangeCommitted);
			// 
			// _cboUsage_2
			// 
			_cboUsage_2.AllowDrop = true;
			_cboUsage_2.BackColor = System.Drawing.SystemColors.Window;
			_cboUsage_2.CausesValidation = true;
			_cboUsage_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cboUsage_2.Enabled = true;
			_cboUsage_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cboUsage_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_cboUsage_2.IntegralHeight = true;
			_cboUsage_2.Location = new System.Drawing.Point(9, 72);
			_cboUsage_2.Name = "_cboUsage_2";
			_cboUsage_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cboUsage_2.Size = new System.Drawing.Size(125, 21);
			_cboUsage_2.Sorted = false;
			_cboUsage_2.TabIndex = 66;
			_cboUsage_2.TabStop = true;
			_cboUsage_2.Visible = false;
			_cboUsage_2.SelectionChangeCommitted += new System.EventHandler(cboUsage_SelectionChangeCommitted);
			// 
			// _lblUsageFormat_4
			// 
			_lblUsageFormat_4.AllowDrop = true;
			_lblUsageFormat_4.AutoSize = true;
			_lblUsageFormat_4.BackColor = System.Drawing.Color.Transparent;
			_lblUsageFormat_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblUsageFormat_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblUsageFormat_4.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
			_lblUsageFormat_4.Location = new System.Drawing.Point(313, 125);
			_lblUsageFormat_4.MinimumSize = new System.Drawing.Size(36, 13);
			_lblUsageFormat_4.Name = "_lblUsageFormat_4";
			_lblUsageFormat_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblUsageFormat_4.Size = new System.Drawing.Size(36, 13);
			_lblUsageFormat_4.TabIndex = 41;
			_lblUsageFormat_4.Text = "nnnnnn";
			_lblUsageFormat_4.Visible = false;
			// 
			// _lblUsageFormat_3
			// 
			_lblUsageFormat_3.AllowDrop = true;
			_lblUsageFormat_3.AutoSize = true;
			_lblUsageFormat_3.BackColor = System.Drawing.Color.Transparent;
			_lblUsageFormat_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblUsageFormat_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblUsageFormat_3.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
			_lblUsageFormat_3.Location = new System.Drawing.Point(313, 100);
			_lblUsageFormat_3.MinimumSize = new System.Drawing.Size(36, 13);
			_lblUsageFormat_3.Name = "_lblUsageFormat_3";
			_lblUsageFormat_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblUsageFormat_3.Size = new System.Drawing.Size(36, 13);
			_lblUsageFormat_3.TabIndex = 40;
			_lblUsageFormat_3.Text = "nnnnnn";
			_lblUsageFormat_3.Visible = false;
			// 
			// _lblUsageFormat_2
			// 
			_lblUsageFormat_2.AllowDrop = true;
			_lblUsageFormat_2.AutoSize = true;
			_lblUsageFormat_2.BackColor = System.Drawing.Color.Transparent;
			_lblUsageFormat_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblUsageFormat_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblUsageFormat_2.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
			_lblUsageFormat_2.Location = new System.Drawing.Point(313, 78);
			_lblUsageFormat_2.MinimumSize = new System.Drawing.Size(36, 13);
			_lblUsageFormat_2.Name = "_lblUsageFormat_2";
			_lblUsageFormat_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblUsageFormat_2.Size = new System.Drawing.Size(36, 13);
			_lblUsageFormat_2.TabIndex = 39;
			_lblUsageFormat_2.Text = "nnnnnn";
			_lblUsageFormat_2.Visible = false;
			// 
			// _lblUsageFormat_1
			// 
			_lblUsageFormat_1.AllowDrop = true;
			_lblUsageFormat_1.AutoSize = true;
			_lblUsageFormat_1.BackColor = System.Drawing.Color.Transparent;
			_lblUsageFormat_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblUsageFormat_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblUsageFormat_1.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
			_lblUsageFormat_1.Location = new System.Drawing.Point(313, 54);
			_lblUsageFormat_1.MinimumSize = new System.Drawing.Size(36, 13);
			_lblUsageFormat_1.Name = "_lblUsageFormat_1";
			_lblUsageFormat_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblUsageFormat_1.Size = new System.Drawing.Size(36, 13);
			_lblUsageFormat_1.TabIndex = 38;
			_lblUsageFormat_1.Text = "nnnnnn";
			_lblUsageFormat_1.Visible = false;
			// 
			// _lblUsageFormat_0
			// 
			_lblUsageFormat_0.AllowDrop = true;
			_lblUsageFormat_0.AutoSize = true;
			_lblUsageFormat_0.BackColor = System.Drawing.Color.Transparent;
			_lblUsageFormat_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblUsageFormat_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblUsageFormat_0.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
			_lblUsageFormat_0.Location = new System.Drawing.Point(313, 29);
			_lblUsageFormat_0.MinimumSize = new System.Drawing.Size(36, 13);
			_lblUsageFormat_0.Name = "_lblUsageFormat_0";
			_lblUsageFormat_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblUsageFormat_0.Size = new System.Drawing.Size(36, 13);
			_lblUsageFormat_0.TabIndex = 37;
			_lblUsageFormat_0.Text = "nnnnnn";
			_lblUsageFormat_0.Visible = false;
			// 
			// chkCompanyFlag
			// 
			chkCompanyFlag.AllowDrop = true;
			chkCompanyFlag.Appearance = System.Windows.Forms.Appearance.Normal;
			chkCompanyFlag.BackColor = System.Drawing.SystemColors.Control;
			chkCompanyFlag.CausesValidation = true;
			chkCompanyFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCompanyFlag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkCompanyFlag.Enabled = true;
			chkCompanyFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkCompanyFlag.ForeColor = System.Drawing.SystemColors.ControlText;
			chkCompanyFlag.Location = new System.Drawing.Point(32, 548);
			chkCompanyFlag.Name = "chkCompanyFlag";
			chkCompanyFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkCompanyFlag.Size = new System.Drawing.Size(114, 13);
			chkCompanyFlag.TabIndex = 12;
			chkCompanyFlag.TabStop = true;
			chkCompanyFlag.Text = "Company Search";
			chkCompanyFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCompanyFlag.Visible = true;
			chkCompanyFlag.CheckStateChanged += new System.EventHandler(chkCompanyFlag_CheckStateChanged);
			// 
			// cmdClear
			// 
			cmdClear.AllowDrop = true;
			cmdClear.BackColor = System.Drawing.SystemColors.Control;
			cmdClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClear.Location = new System.Drawing.Point(311, 544);
			cmdClear.Name = "cmdClear";
			cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClear.Size = new System.Drawing.Size(99, 22);
			cmdClear.TabIndex = 49;
			cmdClear.Text = "Clear All Criteria";
			cmdClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClear.UseVisualStyleBackColor = false;
			cmdClear.Click += new System.EventHandler(cmdClear_Click);
			// 
			// txt_ac_id
			// 
			txt_ac_id.AcceptsReturn = true;
			txt_ac_id.AllowDrop = true;
			txt_ac_id.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_id.Location = new System.Drawing.Point(28, 8);
			txt_ac_id.MaxLength = 0;
			txt_ac_id.Name = "txt_ac_id";
			txt_ac_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_id.Size = new System.Drawing.Size(94, 19);
			txt_ac_id.TabIndex = 81;
			txt_ac_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_ac_id_KeyPress);
			// 
			// chkDontJumpToAircraft
			// 
			chkDontJumpToAircraft.AllowDrop = true;
			chkDontJumpToAircraft.Appearance = System.Windows.Forms.Appearance.Normal;
			chkDontJumpToAircraft.BackColor = System.Drawing.SystemColors.Control;
			chkDontJumpToAircraft.CausesValidation = true;
			chkDontJumpToAircraft.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkDontJumpToAircraft.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkDontJumpToAircraft.Enabled = true;
			chkDontJumpToAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkDontJumpToAircraft.ForeColor = System.Drawing.SystemColors.ControlText;
			chkDontJumpToAircraft.Location = new System.Drawing.Point(240, 4);
			chkDontJumpToAircraft.Name = "chkDontJumpToAircraft";
			chkDontJumpToAircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkDontJumpToAircraft.Size = new System.Drawing.Size(201, 13);
			chkDontJumpToAircraft.TabIndex = 84;
			chkDontJumpToAircraft.TabStop = true;
			chkDontJumpToAircraft.Text = "Do not automatically jump to Aircraft";
			chkDontJumpToAircraft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkDontJumpToAircraft.Visible = true;
			// 
			// frame_demographics
			// 
			frame_demographics.AllowDrop = true;
			frame_demographics.BackColor = System.Drawing.SystemColors.Control;
			frame_demographics.Controls.Add(txt_ac_aport_faaid_code);
			frame_demographics.Controls.Add(lst_State);
			frame_demographics.Controls.Add(txt_ac_aport_city);
			frame_demographics.Controls.Add(txt_ac_aport_iata_code);
			frame_demographics.Controls.Add(txt_ac_aport_icao_code);
			frame_demographics.Controls.Add(txt_ac_aport_name);
			frame_demographics.Controls.Add(lst_Country);
			frame_demographics.Controls.Add(lst_Area);
			frame_demographics.Controls.Add(opt_Region);
			frame_demographics.Controls.Add(opt_Continent);
			frame_demographics.Controls.Add(lbl_FAAID);
			frame_demographics.Controls.Add(Label20);
			frame_demographics.Controls.Add(Label5);
			frame_demographics.Controls.Add(lbl_IATA);
			frame_demographics.Controls.Add(lbl_ICAO);
			frame_demographics.Controls.Add(lbl_airport);
			frame_demographics.Controls.Add(Label15);
			frame_demographics.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_demographics.Enabled = true;
			frame_demographics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_demographics.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_demographics.Location = new System.Drawing.Point(496, 8);
			frame_demographics.Name = "frame_demographics";
			frame_demographics.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_demographics.Size = new System.Drawing.Size(481, 124);
			frame_demographics.TabIndex = 96;
			frame_demographics.Text = "Aircraft Demographics";
			frame_demographics.Visible = true;
			// 
			// txt_ac_aport_faaid_code
			// 
			txt_ac_aport_faaid_code.AcceptsReturn = true;
			txt_ac_aport_faaid_code.AllowDrop = true;
			txt_ac_aport_faaid_code.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_aport_faaid_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_aport_faaid_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_aport_faaid_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_aport_faaid_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_aport_faaid_code.Location = new System.Drawing.Point(183, 16);
			txt_ac_aport_faaid_code.MaxLength = 4;
			txt_ac_aport_faaid_code.Name = "txt_ac_aport_faaid_code";
			txt_ac_aport_faaid_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_aport_faaid_code.Size = new System.Drawing.Size(36, 19);
			txt_ac_aport_faaid_code.TabIndex = 100;
			txt_ac_aport_faaid_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_ac_aport_faaid_code_KeyPress);
			// 
			// lst_State
			// 
			lst_State.AllowDrop = true;
			lst_State.BackColor = System.Drawing.SystemColors.Window;
			lst_State.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_State.CausesValidation = true;
			lst_State.Enabled = true;
			lst_State.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_State.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_State.IntegralHeight = true;
			lst_State.Location = new System.Drawing.Point(317, 49);
			lst_State.MultiColumn = false;
			lst_State.Name = "lst_State";
			lst_State.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_State.Size = new System.Drawing.Size(149, 70);
			lst_State.Sorted = false;
			lst_State.TabIndex = 111;
			lst_State.TabStop = true;
			lst_State.Visible = true;
			lst_State.SelectedIndexChanged += new System.EventHandler(lst_State_SelectedIndexChanged);
			// 
			// txt_ac_aport_city
			// 
			txt_ac_aport_city.AcceptsReturn = true;
			txt_ac_aport_city.AllowDrop = true;
			txt_ac_aport_city.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_aport_city.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_aport_city.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_aport_city.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_aport_city.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_aport_city.Location = new System.Drawing.Point(403, 15);
			txt_ac_aport_city.MaxLength = 0;
			txt_ac_aport_city.Name = "txt_ac_aport_city";
			txt_ac_aport_city.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_aport_city.Size = new System.Drawing.Size(75, 19);
			txt_ac_aport_city.TabIndex = 102;
			// 
			// txt_ac_aport_iata_code
			// 
			txt_ac_aport_iata_code.AcceptsReturn = true;
			txt_ac_aport_iata_code.AllowDrop = true;
			txt_ac_aport_iata_code.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_aport_iata_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_aport_iata_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_aport_iata_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_aport_iata_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_aport_iata_code.Location = new System.Drawing.Point(37, 15);
			txt_ac_aport_iata_code.MaxLength = 4;
			txt_ac_aport_iata_code.Name = "txt_ac_aport_iata_code";
			txt_ac_aport_iata_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_aport_iata_code.Size = new System.Drawing.Size(36, 19);
			txt_ac_aport_iata_code.TabIndex = 98;
			txt_ac_aport_iata_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_ac_aport_iata_code_KeyPress);
			// 
			// txt_ac_aport_icao_code
			// 
			txt_ac_aport_icao_code.AcceptsReturn = true;
			txt_ac_aport_icao_code.AllowDrop = true;
			txt_ac_aport_icao_code.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_aport_icao_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_aport_icao_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_aport_icao_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_aport_icao_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_aport_icao_code.Location = new System.Drawing.Point(106, 15);
			txt_ac_aport_icao_code.MaxLength = 4;
			txt_ac_aport_icao_code.Name = "txt_ac_aport_icao_code";
			txt_ac_aport_icao_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_aport_icao_code.Size = new System.Drawing.Size(36, 19);
			txt_ac_aport_icao_code.TabIndex = 99;
			txt_ac_aport_icao_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_ac_aport_icao_code_KeyPress);
			// 
			// txt_ac_aport_name
			// 
			txt_ac_aport_name.AcceptsReturn = true;
			txt_ac_aport_name.AllowDrop = true;
			txt_ac_aport_name.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_aport_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_aport_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_aport_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_aport_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_aport_name.Location = new System.Drawing.Point(257, 15);
			txt_ac_aport_name.MaxLength = 100;
			txt_ac_aport_name.Name = "txt_ac_aport_name";
			txt_ac_aport_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_aport_name.Size = new System.Drawing.Size(120, 19);
			txt_ac_aport_name.TabIndex = 101;
			// 
			// lst_Country
			// 
			lst_Country.AllowDrop = true;
			lst_Country.BackColor = System.Drawing.SystemColors.Window;
			lst_Country.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Country.CausesValidation = true;
			lst_Country.Enabled = true;
			lst_Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Country.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Country.IntegralHeight = true;
			lst_Country.Location = new System.Drawing.Point(165, 49);
			lst_Country.MultiColumn = false;
			lst_Country.Name = "lst_Country";
			lst_Country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Country.Size = new System.Drawing.Size(137, 70);
			lst_Country.Sorted = false;
			lst_Country.TabIndex = 110;
			lst_Country.TabStop = true;
			lst_Country.Visible = true;
			lst_Country.SelectedIndexChanged += new System.EventHandler(lst_Country_SelectedIndexChanged);
			// 
			// lst_Area
			// 
			lst_Area.AllowDrop = true;
			lst_Area.BackColor = System.Drawing.SystemColors.Window;
			lst_Area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Area.CausesValidation = true;
			lst_Area.Enabled = true;
			lst_Area.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Area.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Area.IntegralHeight = true;
			lst_Area.Location = new System.Drawing.Point(16, 49);
			lst_Area.MultiColumn = false;
			lst_Area.Name = "lst_Area";
			lst_Area.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Area.Size = new System.Drawing.Size(135, 70);
			lst_Area.Sorted = false;
			lst_Area.TabIndex = 108;
			lst_Area.TabStop = true;
			lst_Area.Visible = true;
			lst_Area.SelectedIndexChanged += new System.EventHandler(lst_Area_SelectedIndexChanged);
			// 
			// opt_Region
			// 
			opt_Region.AllowDrop = true;
			opt_Region.BackColor = System.Drawing.SystemColors.Control;
			opt_Region.CausesValidation = true;
			opt_Region.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Region.Checked = false;
			opt_Region.Enabled = true;
			opt_Region.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_Region.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_Region.Location = new System.Drawing.Point(82, 35);
			opt_Region.Name = "opt_Region";
			opt_Region.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_Region.Size = new System.Drawing.Size(68, 14);
			opt_Region.TabIndex = 106;
			opt_Region.TabStop = true;
			opt_Region.Text = "Region";
			opt_Region.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Region.Visible = true;
			opt_Region.CheckedChanged += new System.EventHandler(opt_Region_CheckedChanged);
			// 
			// opt_Continent
			// 
			opt_Continent.AllowDrop = true;
			opt_Continent.BackColor = System.Drawing.SystemColors.Control;
			opt_Continent.CausesValidation = true;
			opt_Continent.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Continent.Checked = false;
			opt_Continent.Enabled = true;
			opt_Continent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_Continent.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_Continent.Location = new System.Drawing.Point(15, 35);
			opt_Continent.Name = "opt_Continent";
			opt_Continent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_Continent.Size = new System.Drawing.Size(68, 14);
			opt_Continent.TabIndex = 104;
			opt_Continent.TabStop = true;
			opt_Continent.Text = "Continent";
			opt_Continent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Continent.Visible = true;
			opt_Continent.CheckedChanged += new System.EventHandler(opt_Continent_CheckedChanged);
			// 
			// lbl_FAAID
			// 
			lbl_FAAID.AllowDrop = true;
			lbl_FAAID.BackColor = System.Drawing.SystemColors.Control;
			lbl_FAAID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_FAAID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_FAAID.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_FAAID.Location = new System.Drawing.Point(148, 19);
			lbl_FAAID.MinimumSize = new System.Drawing.Size(30, 13);
			lbl_FAAID.Name = "lbl_FAAID";
			lbl_FAAID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_FAAID.Size = new System.Drawing.Size(30, 13);
			lbl_FAAID.TabIndex = 166;
			lbl_FAAID.Text = "FAAID";
			// 
			// Label20
			// 
			Label20.AllowDrop = true;
			Label20.BackColor = System.Drawing.SystemColors.Control;
			Label20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label20.ForeColor = System.Drawing.SystemColors.ControlText;
			Label20.Location = new System.Drawing.Point(317, 35);
			Label20.MinimumSize = new System.Drawing.Size(51, 14);
			Label20.Name = "Label20";
			Label20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label20.Size = new System.Drawing.Size(51, 14);
			Label20.TabIndex = 159;
			Label20.Text = "State:";
			// 
			// Label5
			// 
			Label5.AllowDrop = true;
			Label5.BackColor = System.Drawing.SystemColors.Control;
			Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			Label5.Location = new System.Drawing.Point(379, 16);
			Label5.MinimumSize = new System.Drawing.Size(30, 16);
			Label5.Name = "Label5";
			Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label5.Size = new System.Drawing.Size(30, 16);
			Label5.TabIndex = 136;
			Label5.Text = "City:";
			// 
			// lbl_IATA
			// 
			lbl_IATA.AllowDrop = true;
			lbl_IATA.BackColor = System.Drawing.SystemColors.Control;
			lbl_IATA.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_IATA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_IATA.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_IATA.Location = new System.Drawing.Point(6, 17);
			lbl_IATA.MinimumSize = new System.Drawing.Size(24, 14);
			lbl_IATA.Name = "lbl_IATA";
			lbl_IATA.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_IATA.Size = new System.Drawing.Size(24, 14);
			lbl_IATA.TabIndex = 107;
			lbl_IATA.Text = "IATA";
			// 
			// lbl_ICAO
			// 
			lbl_ICAO.AllowDrop = true;
			lbl_ICAO.BackColor = System.Drawing.SystemColors.Control;
			lbl_ICAO.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_ICAO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_ICAO.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_ICAO.Location = new System.Drawing.Point(79, 18);
			lbl_ICAO.MinimumSize = new System.Drawing.Size(24, 13);
			lbl_ICAO.Name = "lbl_ICAO";
			lbl_ICAO.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_ICAO.Size = new System.Drawing.Size(24, 13);
			lbl_ICAO.TabIndex = 105;
			lbl_ICAO.Text = "ICAO";
			// 
			// lbl_airport
			// 
			lbl_airport.AllowDrop = true;
			lbl_airport.AutoSize = true;
			lbl_airport.BackColor = System.Drawing.SystemColors.Control;
			lbl_airport.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_airport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_airport.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_airport.Location = new System.Drawing.Point(222, 18);
			lbl_airport.MinimumSize = new System.Drawing.Size(33, 13);
			lbl_airport.Name = "lbl_airport";
			lbl_airport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_airport.Size = new System.Drawing.Size(33, 13);
			lbl_airport.TabIndex = 103;
			lbl_airport.Text = "Airport:";
			// 
			// Label15
			// 
			Label15.AllowDrop = true;
			Label15.BackColor = System.Drawing.SystemColors.Control;
			Label15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label15.ForeColor = System.Drawing.SystemColors.ControlText;
			Label15.Location = new System.Drawing.Point(165, 35);
			Label15.MinimumSize = new System.Drawing.Size(51, 14);
			Label15.Name = "Label15";
			Label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label15.Size = new System.Drawing.Size(51, 14);
			Label15.TabIndex = 97;
			Label15.Text = "Country:";
			// 
			// txt_Journ_id
			// 
			txt_Journ_id.AcceptsReturn = true;
			txt_Journ_id.AllowDrop = true;
			txt_Journ_id.BackColor = System.Drawing.SystemColors.Window;
			txt_Journ_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Journ_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Journ_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Journ_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Journ_id.Location = new System.Drawing.Point(128, 8);
			txt_Journ_id.MaxLength = 0;
			txt_Journ_id.Name = "txt_Journ_id";
			txt_Journ_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Journ_id.Size = new System.Drawing.Size(94, 19);
			txt_Journ_id.TabIndex = 82;
			txt_Journ_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_Journ_id_KeyPress);
			// 
			// chkTransactions
			// 
			chkTransactions.AllowDrop = true;
			chkTransactions.Appearance = System.Windows.Forms.Appearance.Normal;
			chkTransactions.BackColor = System.Drawing.SystemColors.Control;
			chkTransactions.CausesValidation = true;
			chkTransactions.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkTransactions.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkTransactions.Enabled = true;
			chkTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkTransactions.ForeColor = System.Drawing.SystemColors.ControlText;
			chkTransactions.Location = new System.Drawing.Point(176, 548);
			chkTransactions.Name = "chkTransactions";
			chkTransactions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkTransactions.Size = new System.Drawing.Size(81, 17);
			chkTransactions.TabIndex = 153;
			chkTransactions.TabStop = true;
			chkTransactions.Text = "Transactions";
			chkTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkTransactions.Visible = false;
			chkTransactions.CheckStateChanged += new System.EventHandler(chkTransactions_CheckStateChanged);
			// 
			// chkDontRefreshList
			// 
			chkDontRefreshList.AllowDrop = true;
			chkDontRefreshList.Appearance = System.Windows.Forms.Appearance.Normal;
			chkDontRefreshList.BackColor = System.Drawing.SystemColors.Control;
			chkDontRefreshList.CausesValidation = true;
			chkDontRefreshList.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkDontRefreshList.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkDontRefreshList.Enabled = true;
			chkDontRefreshList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkDontRefreshList.ForeColor = System.Drawing.SystemColors.ControlText;
			chkDontRefreshList.Location = new System.Drawing.Point(240, 20);
			chkDontRefreshList.Name = "chkDontRefreshList";
			chkDontRefreshList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkDontRefreshList.Size = new System.Drawing.Size(217, 17);
			chkDontRefreshList.TabIndex = 154;
			chkDontRefreshList.TabStop = true;
			chkDontRefreshList.Text = "Do not automatically refresh Aircraft List";
			chkDontRefreshList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkDontRefreshList.Visible = true;
			// 
			// chk_include_not_researched
			// 
			chk_include_not_researched.AllowDrop = true;
			chk_include_not_researched.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_include_not_researched.BackColor = System.Drawing.SystemColors.Control;
			chk_include_not_researched.CausesValidation = true;
			chk_include_not_researched.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_include_not_researched.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_include_not_researched.Enabled = true;
			chk_include_not_researched.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_include_not_researched.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_include_not_researched.Location = new System.Drawing.Point(288, -12);
			chk_include_not_researched.Name = "chk_include_not_researched";
			chk_include_not_researched.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_include_not_researched.Size = new System.Drawing.Size(201, 13);
			chk_include_not_researched.TabIndex = 176;
			chk_include_not_researched.TabStop = true;
			chk_include_not_researched.Text = "Include Models Not Researched";
			chk_include_not_researched.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_include_not_researched.Visible = true;
			// 
			// _Tabs1_TabPage1
			// 
			_Tabs1_TabPage1.Controls.Add(lbl_Totfound);
			_Tabs1_TabPage1.Controls.Add(pnl_Clst);
			_Tabs1_TabPage1.Controls.Add(cmd_pick_Ac);
			_Tabs1_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Tabs1_TabPage1.Text = "Results";
			// 
			// lbl_Totfound
			// 
			lbl_Totfound.AllowDrop = true;
			lbl_Totfound.AutoSize = true;
			lbl_Totfound.BackColor = System.Drawing.SystemColors.Control;
			lbl_Totfound.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Totfound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Totfound.ForeColor = System.Drawing.Color.Navy;
			lbl_Totfound.Location = new System.Drawing.Point(70, 546);
			lbl_Totfound.MinimumSize = new System.Drawing.Size(84, 16);
			lbl_Totfound.Name = "lbl_Totfound";
			lbl_Totfound.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Totfound.Size = new System.Drawing.Size(84, 16);
			lbl_Totfound.TabIndex = 34;
			lbl_Totfound.Text = "Total Found";
			lbl_Totfound.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// pnl_Clst
			// 
			pnl_Clst.AllowDrop = true;
			pnl_Clst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Clst.Controls.Add(_txt_gen_7);
			pnl_Clst.Controls.Add(_txt_gen_6);
			pnl_Clst.Controls.Add(_txt_gen_5);
			pnl_Clst.Controls.Add(_txt_gen_4);
			pnl_Clst.Controls.Add(cmdAircraftListExcelExport);
			pnl_Clst.Controls.Add(_txt_gen_0);
			pnl_Clst.Controls.Add(_txt_gen_3);
			pnl_Clst.Controls.Add(_txt_gen_2);
			pnl_Clst.Controls.Add(_txt_gen_1);
			pnl_Clst.Controls.Add(grdAircraft);
			pnl_Clst.Controls.Add(cmdStop);
			pnl_Clst.Controls.Add(cmd_SelectAircraft);
			pnl_Clst.Controls.Add(cmd_Cancel);
			pnl_Clst.Controls.Add(_lbl_gen_0);
			pnl_Clst.Controls.Add(_lbl_gen_16);
			pnl_Clst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Clst.Location = new System.Drawing.Point(12, 6);
			pnl_Clst.Name = "pnl_Clst";
			pnl_Clst.Size = new System.Drawing.Size(958, 525);
			pnl_Clst.TabIndex = 26;
			pnl_Clst.MouseMove += new System.Windows.Forms.MouseEventHandler(pnl_Clst_MouseMove);
			// 
			// _txt_gen_7
			// 
			_txt_gen_7.AcceptsReturn = true;
			_txt_gen_7.AllowDrop = true;
			_txt_gen_7.BackColor = System.Drawing.Color.Red;
			_txt_gen_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_7.ForeColor = System.Drawing.Color.White;
			_txt_gen_7.Location = new System.Drawing.Point(782, 8);
			_txt_gen_7.MaxLength = 0;
			_txt_gen_7.Name = "_txt_gen_7";
			_txt_gen_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_7.Size = new System.Drawing.Size(37, 14);
			_txt_gen_7.TabIndex = 171;
			_txt_gen_7.Text = "D";
			_txt_gen_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			_txt_gen_7.Visible = false;
			// 
			// _txt_gen_6
			// 
			_txt_gen_6.AcceptsReturn = true;
			_txt_gen_6.AllowDrop = true;
			_txt_gen_6.BackColor = System.Drawing.SystemColors.GrayText;
			_txt_gen_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_6.ForeColor = System.Drawing.Color.White;
			_txt_gen_6.Location = new System.Drawing.Point(744, 8);
			_txt_gen_6.MaxLength = 0;
			_txt_gen_6.Name = "_txt_gen_6";
			_txt_gen_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_6.Size = new System.Drawing.Size(37, 14);
			_txt_gen_6.TabIndex = 170;
			_txt_gen_6.Text = "C";
			_txt_gen_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			_txt_gen_6.Visible = false;
			// 
			// _txt_gen_5
			// 
			_txt_gen_5.AcceptsReturn = true;
			_txt_gen_5.AllowDrop = true;
			_txt_gen_5.BackColor = System.Drawing.Color.Fuchsia;
			_txt_gen_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_gen_5.Location = new System.Drawing.Point(706, 8);
			_txt_gen_5.MaxLength = 0;
			_txt_gen_5.Name = "_txt_gen_5";
			_txt_gen_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_5.Size = new System.Drawing.Size(37, 14);
			_txt_gen_5.TabIndex = 169;
			_txt_gen_5.Text = "B";
			_txt_gen_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			_txt_gen_5.Visible = false;
			// 
			// _txt_gen_4
			// 
			_txt_gen_4.AcceptsReturn = true;
			_txt_gen_4.AllowDrop = true;
			_txt_gen_4.BackColor = System.Drawing.Color.Aqua;
			_txt_gen_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_gen_4.Location = new System.Drawing.Point(668, 8);
			_txt_gen_4.MaxLength = 0;
			_txt_gen_4.Name = "_txt_gen_4";
			_txt_gen_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_4.Size = new System.Drawing.Size(37, 14);
			_txt_gen_4.TabIndex = 168;
			_txt_gen_4.Text = "A";
			_txt_gen_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			_txt_gen_4.Visible = false;
			// 
			// cmdAircraftListExcelExport
			// 
			cmdAircraftListExcelExport.AllowDrop = true;
			cmdAircraftListExcelExport.BackColor = System.Drawing.SystemColors.Control;
			cmdAircraftListExcelExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAircraftListExcelExport.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAircraftListExcelExport.Location = new System.Drawing.Point(74, 502);
			cmdAircraftListExcelExport.Name = "cmdAircraftListExcelExport";
			cmdAircraftListExcelExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAircraftListExcelExport.Size = new System.Drawing.Size(60, 20);
			cmdAircraftListExcelExport.TabIndex = 164;
			cmdAircraftListExcelExport.Text = "Export";
			cmdAircraftListExcelExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAircraftListExcelExport.UseVisualStyleBackColor = false;
			cmdAircraftListExcelExport.Visible = false;
			cmdAircraftListExcelExport.Click += new System.EventHandler(cmdAircraftListExcelExport_Click);
			// 
			// _txt_gen_0
			// 
			_txt_gen_0.AcceptsReturn = true;
			_txt_gen_0.AllowDrop = true;
			_txt_gen_0.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			_txt_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_gen_0.Location = new System.Drawing.Point(425, 6);
			_txt_gen_0.MaxLength = 0;
			_txt_gen_0.Name = "_txt_gen_0";
			_txt_gen_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_0.Size = new System.Drawing.Size(132, 14);
			_txt_gen_0.TabIndex = 158;
			_txt_gen_0.Text = "Yellow = Primary Company";
			_txt_gen_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _txt_gen_3
			// 
			_txt_gen_3.AcceptsReturn = true;
			_txt_gen_3.AllowDrop = true;
			_txt_gen_3.BackColor = System.Drawing.Color.FromArgb(255, 173, 91);
			_txt_gen_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_gen_3.Location = new System.Drawing.Point(294, 6);
			_txt_gen_3.MaxLength = 0;
			_txt_gen_3.Name = "_txt_gen_3";
			_txt_gen_3.ReadOnly = true;
			_txt_gen_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_3.Size = new System.Drawing.Size(132, 14);
			_txt_gen_3.TabIndex = 157;
			_txt_gen_3.Text = "Orange = Lease";
			_txt_gen_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _txt_gen_2
			// 
			_txt_gen_2.AcceptsReturn = true;
			_txt_gen_2.AllowDrop = true;
			_txt_gen_2.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			_txt_gen_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_gen_2.Location = new System.Drawing.Point(30, 6);
			_txt_gen_2.MaxLength = 0;
			_txt_gen_2.Name = "_txt_gen_2";
			_txt_gen_2.ReadOnly = true;
			_txt_gen_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_2.Size = new System.Drawing.Size(132, 14);
			_txt_gen_2.TabIndex = 156;
			_txt_gen_2.Text = "Green = Available";
			_txt_gen_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _txt_gen_1
			// 
			_txt_gen_1.AcceptsReturn = true;
			_txt_gen_1.AllowDrop = true;
			_txt_gen_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			_txt_gen_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_txt_gen_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_gen_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_gen_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_gen_1.Location = new System.Drawing.Point(162, 6);
			_txt_gen_1.MaxLength = 0;
			_txt_gen_1.Name = "_txt_gen_1";
			_txt_gen_1.ReadOnly = true;
			_txt_gen_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_gen_1.Size = new System.Drawing.Size(132, 14);
			_txt_gen_1.TabIndex = 155;
			_txt_gen_1.Text = "Purple = On Exclusive";
			_txt_gen_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// grdAircraft
			// 
			grdAircraft.AllowDrop = true;
			grdAircraft.AllowUserToAddRows = false;
			grdAircraft.AllowUserToDeleteRows = false;
			grdAircraft.AllowUserToResizeColumns = false;
			grdAircraft.AllowUserToResizeColumns = grdAircraft.ColumnHeadersVisible;
			grdAircraft.AllowUserToResizeRows = false;
			grdAircraft.AllowUserToResizeRows = false;
			grdAircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdAircraft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdAircraft.ColumnsCount = 2;
			grdAircraft.FixedColumns = 1;
			grdAircraft.FixedRows = 1;
			grdAircraft.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grdAircraft.Location = new System.Drawing.Point(6, 27);
			grdAircraft.Name = "grdAircraft";
			grdAircraft.ReadOnly = true;
			grdAircraft.RowsCount = 2;
			grdAircraft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdAircraft.ShowCellToolTips = false;
			grdAircraft.Size = new System.Drawing.Size(942, 473);
			grdAircraft.StandardTab = true;
			grdAircraft.TabIndex = 36;
			grdAircraft.DoubleClick += new System.EventHandler(grdAircraft_DoubleClick);
			grdAircraft.MouseDown += new System.Windows.Forms.MouseEventHandler(grdAircraft_MouseDown);
			grdAircraft.MouseMove += new System.Windows.Forms.MouseEventHandler(grdAircraft_MouseMove);
			// 
			// cmdStop
			// 
			cmdStop.AllowDrop = true;
			cmdStop.BackColor = System.Drawing.SystemColors.Control;
			cmdStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdStop.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdStop.Location = new System.Drawing.Point(7, 502);
			cmdStop.Name = "cmdStop";
			cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdStop.Size = new System.Drawing.Size(60, 20);
			cmdStop.TabIndex = 50;
			cmdStop.Text = "Stop";
			cmdStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdStop.UseVisualStyleBackColor = false;
			cmdStop.Visible = false;
			cmdStop.Click += new System.EventHandler(cmdStop_Click);
			cmdStop.MouseMove += new System.Windows.Forms.MouseEventHandler(cmdStop_MouseMove);
			// 
			// cmd_SelectAircraft
			// 
			cmd_SelectAircraft.AllowDrop = true;
			cmd_SelectAircraft.BackColor = System.Drawing.SystemColors.Control;
			cmd_SelectAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_SelectAircraft.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_SelectAircraft.Location = new System.Drawing.Point(624, 536);
			cmd_SelectAircraft.Name = "cmd_SelectAircraft";
			cmd_SelectAircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_SelectAircraft.Size = new System.Drawing.Size(89, 25);
			cmd_SelectAircraft.TabIndex = 28;
			cmd_SelectAircraft.Text = "Select Aircraft";
			cmd_SelectAircraft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_SelectAircraft.UseVisualStyleBackColor = false;
			cmd_SelectAircraft.Click += new System.EventHandler(cmd_SelectAircraft_Click);
			// 
			// cmd_Cancel
			// 
			cmd_Cancel.AllowDrop = true;
			cmd_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel.Location = new System.Drawing.Point(720, 536);
			cmd_Cancel.Name = "cmd_Cancel";
			cmd_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel.Size = new System.Drawing.Size(81, 25);
			cmd_Cancel.TabIndex = 27;
			cmd_Cancel.Text = "Cancel";
			cmd_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel.UseVisualStyleBackColor = false;
			cmd_Cancel.Click += new System.EventHandler(cmd_cancel_Click);
			// 
			// _lbl_gen_0
			// 
			_lbl_gen_0.AllowDrop = true;
			_lbl_gen_0.AutoSize = true;
			_lbl_gen_0.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_0.Location = new System.Drawing.Point(599, 8);
			_lbl_gen_0.MinimumSize = new System.Drawing.Size(61, 13);
			_lbl_gen_0.Name = "_lbl_gen_0";
			_lbl_gen_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_0.Size = new System.Drawing.Size(61, 13);
			_lbl_gen_0.TabIndex = 167;
			_lbl_gen_0.Text = "Class Colors ";
			_lbl_gen_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_0.Visible = false;
			// 
			// _lbl_gen_16
			// 
			_lbl_gen_16.AllowDrop = true;
			_lbl_gen_16.AutoSize = true;
			_lbl_gen_16.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_16.Location = new System.Drawing.Point(7, 7);
			_lbl_gen_16.MinimumSize = new System.Drawing.Size(23, 13);
			_lbl_gen_16.Name = "_lbl_gen_16";
			_lbl_gen_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_16.Size = new System.Drawing.Size(23, 13);
			_lbl_gen_16.TabIndex = 48;
			_lbl_gen_16.Text = "Key:";
			_lbl_gen_16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// cmd_pick_Ac
			// 
			cmd_pick_Ac.AllowDrop = true;
			cmd_pick_Ac.BackColor = System.Drawing.SystemColors.Control;
			cmd_pick_Ac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_pick_Ac.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_pick_Ac.Location = new System.Drawing.Point(872, 548);
			cmd_pick_Ac.Name = "cmd_pick_Ac";
			cmd_pick_Ac.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_pick_Ac.Size = new System.Drawing.Size(81, 25);
			cmd_pick_Ac.TabIndex = 173;
			cmd_pick_Ac.Text = "Select Aircraft";
			cmd_pick_Ac.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_pick_Ac.UseVisualStyleBackColor = false;
			cmd_pick_Ac.Visible = false;
			cmd_pick_Ac.Click += new System.EventHandler(cmd_pick_Ac_Click);
			// 
			// tbr_ToolBar
			// 
			tbr_ToolBar.AllowDrop = true;
			tbr_ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
			tbr_ToolBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tbr_ToolBar.Location = new System.Drawing.Point(0, 24);
			tbr_ToolBar.Name = "tbr_ToolBar";
			tbr_ToolBar.ShowItemToolTips = true;
			tbr_ToolBar.Size = new System.Drawing.Size(990, 28);
			tbr_ToolBar.TabIndex = 18;
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
			// pnl_SearchWait
			// 
			pnl_SearchWait.AllowDrop = true;
			pnl_SearchWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_SearchWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_SearchWait.Controls.Add(Label1);
			pnl_SearchWait.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_SearchWait.Location = new System.Drawing.Point(249, 276);
			pnl_SearchWait.Name = "pnl_SearchWait";
			pnl_SearchWait.Size = new System.Drawing.Size(521, 118);
			pnl_SearchWait.TabIndex = 76;
			pnl_SearchWait.Visible = false;
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.AutoSize = true;
			Label1.BackColor = System.Drawing.Color.Transparent;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.Color.Maroon;
			Label1.Location = new System.Drawing.Point(196, 53);
			Label1.MinimumSize = new System.Drawing.Size(141, 23);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(141, 23);
			Label1.TabIndex = 77;
			Label1.Text = "PLEASE WAIT!";
			Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_Search_Heading
			// 
			lbl_Search_Heading.AllowDrop = true;
			lbl_Search_Heading.AutoSize = true;
			lbl_Search_Heading.BackColor = System.Drawing.Color.Transparent;
			lbl_Search_Heading.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Search_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Search_Heading.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Search_Heading.Location = new System.Drawing.Point(421, 50);
			lbl_Search_Heading.MinimumSize = new System.Drawing.Size(153, 24);
			lbl_Search_Heading.Name = "lbl_Search_Heading";
			lbl_Search_Heading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Search_Heading.Size = new System.Drawing.Size(153, 24);
			lbl_Search_Heading.TabIndex = 16;
			lbl_Search_Heading.Text = "Search Heading";
			lbl_Search_Heading.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frm_AircraftList
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(990, 711);
			ControlBox = false;
			Controls.Add(Tabs1);
			Controls.Add(tbr_ToolBar);
			Controls.Add(pnl_SearchWait);
			Controls.Add(lbl_Search_Heading);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			KeyPreview = true;
			Location = new System.Drawing.Point(55, 117);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_AircraftList";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Select Aircraft";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(cmdHideTrans, 0);
			commandButtonHelper1.SetStyle(cmdClear, 0);
			commandButtonHelper1.SetStyle(cmdAircraftListExcelExport, 0);
			commandButtonHelper1.SetStyle(cmdStop, 0);
			commandButtonHelper1.SetStyle(cmd_SelectAircraft, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel, 0);
			commandButtonHelper1.SetStyle(cmd_pick_Ac, 0);
			listBoxHelper1.SetSelectionMode(lstMake, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lstType, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lstModel, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lst_CompanyArea, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lstCompanyTimeZone, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lstCompanyState, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lstCompanyCountry, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lstCompanyType, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lst_State, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lst_Country, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lst_Area, System.Windows.Forms.SelectionMode.MultiExtended);
			optionButtonHelper1.SetStyle(_optNewUsed_3, 0);
			optionButtonHelper1.SetStyle(_optNewUsed_2, 0);
			optionButtonHelper1.SetStyle(_optNewUsed_1, 0);
			optionButtonHelper1.SetStyle(_optNewUsed_0, 0);
			optionButtonHelper1.SetStyle(opt_CompanyContinent, 0);
			optionButtonHelper1.SetStyle(opt_CompanyRegion, 0);
			optionButtonHelper1.SetStyle(optNotForSale, 0);
			optionButtonHelper1.SetStyle(optForSale, 0);
			optionButtonHelper1.SetStyle(optAll, 0);
			optionButtonHelper1.SetStyle(opt_Region, 0);
			optionButtonHelper1.SetStyle(opt_Continent, 0);
			ToolTipMain.SetToolTip(chkSerNbrExact, "Unchecked The Search Will Perform a wider match but will be slower");
			ToolTipMain.SetToolTip(cbo_JournalCategory, "Double Click Label - Journal Category - To Load Combo Box");
			ToolTipMain.SetToolTip(lblJournalCategory, "Double Click Label - Journal Category - To Load Combo Box");
			ToolTipMain.SetToolTip(cmdAircraftListExcelExport, "Click To Export Aircraft Grid Data To Excel");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			Enter += new System.EventHandler(Form_Enter);
			KeyUp += new System.Windows.Forms.KeyEventHandler(Form_KeyUp);
			MouseMove += new System.Windows.Forms.MouseEventHandler(Form_MouseMove);
			((System.ComponentModel.ISupportInitialize) grdAircraft).EndInit();
			Tabs1.ResumeLayout(false);
			Tabs1.PerformLayout();
			_Tabs1_TabPage0.ResumeLayout(false);
			_Tabs1_TabPage0.PerformLayout();
			fraClassification.ResumeLayout(false);
			fraClassification.PerformLayout();
			fraCompanyDemographics.ResumeLayout(false);
			fraCompanyDemographics.PerformLayout();
			frm_Transactions.ResumeLayout(false);
			frm_Transactions.PerformLayout();
			fraStatus.ResumeLayout(false);
			fraStatus.PerformLayout();
			fraUsage.ResumeLayout(false);
			fraUsage.PerformLayout();
			frame_demographics.ResumeLayout(false);
			frame_demographics.PerformLayout();
			_Tabs1_TabPage1.ResumeLayout(false);
			_Tabs1_TabPage1.PerformLayout();
			pnl_Clst.ResumeLayout(false);
			pnl_Clst.PerformLayout();
			tbr_ToolBar.ResumeLayout(false);
			tbr_ToolBar.PerformLayout();
			pnl_SearchWait.ResumeLayout(false);
			pnl_SearchWait.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializetxt_gen();
			InitializetxtUsageValue();
			InitializeoptNewUsed();
			Initializelbl_gen();
			Initializelbl_Class();
			InitializelblUsageFormat();
			InitializelblBusinessType();
			Initializechk_bx_product_codes();
			InitializecboUsageCondition();
			InitializecboUsage();
			InitializeLabel7();
			InitializeLabel2();
			Tabs1PreviousTab = Tabs1.SelectedIndex;
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
			txt_gen = new System.Windows.Forms.TextBox[8];
			txt_gen[7] = _txt_gen_7;
			txt_gen[6] = _txt_gen_6;
			txt_gen[5] = _txt_gen_5;
			txt_gen[4] = _txt_gen_4;
			txt_gen[0] = _txt_gen_0;
			txt_gen[3] = _txt_gen_3;
			txt_gen[2] = _txt_gen_2;
			txt_gen[1] = _txt_gen_1;
		}
		void InitializetxtUsageValue()
		{
			txtUsageValue = new System.Windows.Forms.TextBox[5];
			txtUsageValue[4] = _txtUsageValue_4;
			txtUsageValue[3] = _txtUsageValue_3;
			txtUsageValue[0] = _txtUsageValue_0;
			txtUsageValue[1] = _txtUsageValue_1;
			txtUsageValue[2] = _txtUsageValue_2;
		}
		void InitializeoptNewUsed()
		{
			optNewUsed = new System.Windows.Forms.RadioButton[4];
			optNewUsed[3] = _optNewUsed_3;
			optNewUsed[2] = _optNewUsed_2;
			optNewUsed[1] = _optNewUsed_1;
			optNewUsed[0] = _optNewUsed_0;
		}
		void Initializelbl_gen()
		{
			lbl_gen = new System.Windows.Forms.Label[17];
			lbl_gen[0] = _lbl_gen_0;
			lbl_gen[16] = _lbl_gen_16;
		}
		void Initializelbl_Class()
		{
			lbl_Class = new System.Windows.Forms.Label[4];
			lbl_Class[3] = _lbl_Class_3;
			lbl_Class[2] = _lbl_Class_2;
			lbl_Class[1] = _lbl_Class_1;
			lbl_Class[0] = _lbl_Class_0;
		}
		void InitializelblUsageFormat()
		{
			lblUsageFormat = new System.Windows.Forms.Label[5];
			lblUsageFormat[4] = _lblUsageFormat_4;
			lblUsageFormat[3] = _lblUsageFormat_3;
			lblUsageFormat[2] = _lblUsageFormat_2;
			lblUsageFormat[1] = _lblUsageFormat_1;
			lblUsageFormat[0] = _lblUsageFormat_0;
		}
		void InitializelblBusinessType()
		{
			lblBusinessType = new System.Windows.Forms.Label[2];
			lblBusinessType[1] = _lblBusinessType_1;
			lblBusinessType[0] = _lblBusinessType_0;
		}
		void Initializechk_bx_product_codes()
		{
			chk_bx_product_codes = new System.Windows.Forms.CheckBox[4];
			chk_bx_product_codes[0] = _chk_bx_product_codes_0;
			chk_bx_product_codes[3] = _chk_bx_product_codes_3;
			chk_bx_product_codes[2] = _chk_bx_product_codes_2;
		}
		void InitializecboUsageCondition()
		{
			cboUsageCondition = new System.Windows.Forms.ComboBox[5];
			cboUsageCondition[4] = _cboUsageCondition_4;
			cboUsageCondition[3] = _cboUsageCondition_3;
			cboUsageCondition[0] = _cboUsageCondition_0;
			cboUsageCondition[1] = _cboUsageCondition_1;
			cboUsageCondition[2] = _cboUsageCondition_2;
		}
		void InitializecboUsage()
		{
			cboUsage = new System.Windows.Forms.ComboBox[5];
			cboUsage[4] = _cboUsage_4;
			cboUsage[3] = _cboUsage_3;
			cboUsage[0] = _cboUsage_0;
			cboUsage[1] = _cboUsage_1;
			cboUsage[2] = _cboUsage_2;
		}
		void InitializeLabel7()
		{
			Label7 = new System.Windows.Forms.Label[1];
			Label7[0] = _Label7_0;
		}
		void InitializeLabel2()
		{
			Label2 = new System.Windows.Forms.Label[2];
			Label2[1] = _Label2_1;
			Label2[0] = _Label2_0;
		}
		#endregion
	}
}