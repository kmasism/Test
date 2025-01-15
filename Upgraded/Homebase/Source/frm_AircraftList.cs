using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_AircraftList
		: System.Windows.Forms.Form
	{

		//******************************************************************************************
		//***** VB Compress Pro 6.11.32 generated this copy of frm_AircraftList.frm on Mon 6/17/02 @
		//***** Mode: AutoSelect Standard Mode (Internal References Only)***************************
		//******************************************************************************************
		//* Note: VBC id'd the following unreferenced items and handled them as described:         *
		//*                                                                                        *
		//* Private Procedures (Removed)                                                           *
		//*  GetContactName                lbl_Make_Click                lbl_Serial_Number_Click   *
		//*  lbl_Year_Click                                                                        *
		//******************************************************************************************



		//===================
		// Private Variables
		//===================
		private bool ExactSerial = false;
		private bool Stopped = false;
		private bool HadHourglass = false;
		private bool ComingBack = false;
		private int RememberWhichRow = 0;
		private string[, ] UsageField = null;
		private string[, ] UsageFormat = null;
		private string[] UsageFld = new string[]{"", "", "", "", "", "", ""}; //aey 3/21/05
		private string[] UsageFmt = new string[]{"", "", "", "", "", "", ""}; //aey 3/21/05
		private string[] CompanyType = null;
		private bool AlreadyLoadedList = false;
		private bool SomethingSelected = false;
		private bool SerialNumberSelected = false;
		private ADORecordSetHelper snp_AircraftList = null;
		private string str_Orderby = "";
		private object Control = null;
		private int colMake = 0;
		private int colModel = 0;
		private int colSerial = 0;
		private int colRegistration = 0;
		private int colYear = 0;
		private int colStatus = 0;
		private int colACLocation = 0;
		private int colCompany = 0;
		private int colNewUsed = 0;
		private bool Selected = false;

		public string ComingFrom = "";

		string Continentlist = "";
		string Regionlist = "";
		string Countrylist = "";
		string Statelist = "";

		string CompanyContinentlist = "";
		string CompanyRegionlist = "";
		string CompanyCountrylist = "";
		string CompanyStatelist = "";

		private string tmpStart = "";
		private int tmpHowLong = 0;
		private bool bFormLoad = false;
		private bool bFormInitialize = false;
		private bool bFormActivate = false;
		public bool is_from_company = false;
		public frm_AircraftList()
			: base()
		{
			if (m_vb6FormDefInstance is null)
			{
				if (m_InitializingDefInstance)
				{
					m_vb6FormDefInstance = this;
				}
				else
				{
					try
					{
						//For the start-up form, the first instance created is the default instance.
						if (!(System.Reflection.Assembly.GetExecutingAssembly().EntryPoint is null) && System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType == this.GetType())
						{
							m_vb6FormDefInstance = this;
						}
					}
					catch
					{
					}
				}
			}
			//This call is required by the Windows Form Designer.
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			ReLoadForm(false);
		}



		private void Fill_Journal_Category()
		{
			//aey 4/17/2006

			string strQuery1 = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			try
			{

				cbo_JournalCategory.Items.Clear();
				cbo_JournalCategory.AddItem("Not Specified");

				strQuery1 = "SELECT jcat_subcategory_code, jcat_subcategory_name ";
				strQuery1 = $"{strQuery1}FROM Journal_Category WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (jcat_category_code ='AH') ";
				strQuery1 = $"{strQuery1}ORDER BY jcat_subcategory_code ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					do 
					{
						cbo_JournalCategory.AddItem(($"{Convert.ToString(rstRec1["jcat_subcategory_code"])}-{Convert.ToString(rstRec1["jcat_subcategory_name"])} ").Trim());
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);
				}

				cbo_JournalCategory.SelectedIndex = 0;

				rstRec1.Close();
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				search_off();
				modAdminCommon.Report_Error($"Fill_Journal_Category_Error: {excep.Message}");
			}

		}

		private void Fill_ContactType()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cbo_ContactType.Items.Clear();
				cbo_ContactType.AddItem("Not Specified");

				// 08/22/2019 - By David D. Cruger;
				// Per Tasker #4902 - Remove Fixed Base Operator
				// Needed to add an Active Flag on this Table
				strQuery1 = "SELECT actype_code, actype_name ";
				strQuery1 = $"{strQuery1}FROM Aircraft_Contact_Type WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (actype_active_flag = 'Y') ";
				strQuery1 = $"{strQuery1}ORDER BY actype_code ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{
						cbo_ContactType.AddItem($"{($"{Convert.ToString(rstRec1["actype_code"])} ").Trim()}-{($"{Convert.ToString(rstRec1["actype_name"])} ").Trim()}");
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				cbo_ContactType.SelectedIndex = 0;

				rstRec1.Close();
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				search_off();
				modAdminCommon.Report_Error($"Fill_ContactType_Error: {excep.Message}");
			}

		} // Fill_ContactType

		public void Fill_Engine_Noise_Rating()
		{

			cmb_engine_noise_rating.Items.Clear();
			cmb_engine_noise_rating.AddItem("Not Specified");
			cmb_engine_noise_rating.AddItem("Yes");
			cmb_engine_noise_rating.AddItem("No");

			cmb_engine_noise_rating.SelectedIndex = 0;

		}

		public void Fill_Model_Config()
		{

			cmb_model_config.Items.Clear();
			cmb_model_config.AddItem("Not Specified");
			cmb_model_config.AddItem("Yes");
			cmb_model_config.AddItem("No");

			cmb_model_config.SelectedIndex = 0;

		}

		public void FillAirframeType()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int FixedRow = 0;

			try
			{

				FixedRow = 0;
				cboAirframeTypeCode.Items.Clear();
				cboAirframeTypeCode.AddItem("Not Specified");

				strQuery1 = "SELECT * FROM Airframe_Type WITH (NOLOCK) ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cboAirframeTypeCode.AddItem($"{($"{Convert.ToString(rstRec1["aftype_code"])} ").Trim()}-{($"{Convert.ToString(rstRec1["aftype_name"])} ").Trim()}");
						if (rstRec1["aftype_code"] == modAdminCommon.snp_User["user_default_airframe"])
						{
							FixedRow = cboAirframeTypeCode.GetNewIndex();
						}
						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // rstRec1.Open strQueryq, LOCAL_ADO_DB, adOpenStatic, adLockReadOnly, adCmdText

				rstRec1.Close();
				cboAirframeTypeCode.Enabled = false;
				cboAirframeTypeCode.SelectedIndex = FixedRow;
				cboAirframeTypeCode.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"FillAirframeType_Error: {excep.Message}");
			}

		} // FillAirframeType

		// 11/13/2012 - By David D. Cruger; Added
		public void FillInteriorConfig()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cbo_ac_interior_config_search.Items.Clear();
				cbo_ac_interior_config_search.AddItem("Not Specified");

				strQuery1 = "SELECT intconfig_name FROM Interior_Configuration ORDER BY intconfig_name ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{
						cbo_ac_interior_config_search.AddItem(($"{Convert.ToString(rstRec1["intconfig_name"])} ").Trim());
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				cbo_ac_interior_config_search.SelectedIndex = 0;

				rstRec1.Close();
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				search_off();
				modAdminCommon.Report_Error($"FillInteriorConfig_Error: {excep.Message}");
			}

		} // FillInteriorConfig

		private void FillAsking()
		{

			try
			{
				string Query = "";
				ADORecordSetHelper snp_acasking = new ADORecordSetHelper(); //7/26/05 aey

				cbo_ac_asking.Items.Clear();
				cbo_ac_asking.AddItem("Not Specified");

				Query = "SELECT * FROM Aircraft_Asking";

				snp_acasking.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_acasking.BOF && snp_acasking.EOF))
				{

					while(!snp_acasking.EOF)
					{
						cbo_ac_asking.AddItem(($"{Convert.ToString(snp_acasking["aask_name"])} ").Trim());
						snp_acasking.MoveNext();
					};
				}

				cbo_ac_asking.SelectedIndex = 0;

				snp_acasking.Close();
				snp_acasking = null;
			}
			catch (System.Exception excep)
			{

				search_off();
				modAdminCommon.Report_Error($"Fill_Aircraft_Asking_List_Error: {excep.Message}");
			}

		}

		private void FillClass()
		{
			try
			{
				string Query = "";
				ADORecordSetHelper snp_Class = new ADORecordSetHelper(); //7.26.05 aey

				cbo_ac_class.Items.Clear();
				Query = "select * from Aircraft_Class";
				snp_Class.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Class.BOF && snp_Class.EOF))
				{
					cbo_ac_class.AddItem("Not Specified");

					while(!snp_Class.EOF)
					{
						cbo_ac_class.AddItem($"{($"{Convert.ToString(snp_Class["aclass_code"])}").Trim()} - {($"{Convert.ToString(snp_Class["aclass_name"])}").Trim()}");
						snp_Class.MoveNext();
					};
					cbo_ac_class.SelectedIndex = 0;
				}
				snp_Class.Close();
				snp_Class = null;
			}
			catch (System.Exception excep)
			{

				search_off();
				modAdminCommon.Report_Error($"FillClass_Error: {excep.Message}");
			}

		}

		private void Fill_Company_Country_List()
		{

			//******************************************************
			//
			// THE PROCEDURE FILLS A LIST BOX WITH A MASTER LIST OF COUNTRIES
			//
			// LAST CHANGED BY RICK WANNER ON 3/21/03
			//
			// *****************************************************
			try
			{

				string Query = "";
				string M = "";
				ADORecordSetHelper snp_CompanyCountryList = new ADORecordSetHelper(); //7/26/05 aey

				lstCompanyCountry.Items.Clear();
				lstCompanyCountry.AddItem("All");
				Query = "SELECT distinct country_name FROM Country, Geographic WHERE country_name = geographic_country_name ";

				if (Strings.Len(CompanyContinentlist.Trim()) > 0 && !ListBoxHelper.GetSelected(lst_CompanyArea, 0))
				{
					Query = $"{Query}and country_continent_name in ({CompanyContinentlist})";
				}
				else
				{
					if (Strings.Len(CompanyRegionlist.Trim()) > 0)
					{
						Query = $"{Query}and geographic_region_name in ({CompanyRegionlist})";
					}
				}

				Query = $"{Query}order by country_name";

				snp_CompanyCountryList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_CompanyCountryList.BOF && snp_CompanyCountryList.EOF))
				{


					while(!snp_CompanyCountryList.EOF)
					{
						M = ($"{Convert.ToString(snp_CompanyCountryList["country_name"])}").Trim();
						lstCompanyCountry.AddItem(M);
						snp_CompanyCountryList.MoveNext();
					};
				}

				snp_CompanyCountryList.Close();
				snp_CompanyCountryList = null;
				ListBoxHelper.SetSelected(lstCompanyCountry, 0, true);
			}
			catch (System.Exception excep)
			{

				search_off();
				modAdminCommon.Report_Error($"Fill_Company_Country_List_Error: {excep.Message}");
			}

		}

		private void Fill_Company_State_List()
		{

			try
			{

				string Query = "";
				string M = "";
				ADORecordSetHelper snp_StateList = new ADORecordSetHelper(); //7/26/05 aey

				lstCompanyState.Items.Clear();
				lstCompanyState.AddItem("All");

				if (Strings.Len(CompanyCountrylist.Trim()) > 0 && !ListBoxHelper.GetSelected(lstCompanyCountry, 0))
				{
					Query = "SELECT state_code, state_name FROM State ";
					if (Strings.Len(CompanyRegionlist.Trim()) > 0)
					{
						Query = $"{Query}, Geographic ";
					}
					Query = $"{Query}where state_country in ({CompanyCountrylist}) ";
					if (Strings.Len(CompanyRegionlist.Trim()) > 0)
					{
						Query = $"{Query}AND state_code=geographic_state_code and state_country=geographic_country_name and geographic_region_name in ({CompanyRegionlist}) ";
					}
				}
				else
				{

					if (Strings.Len(CompanyRegionlist.Trim()) > 0 && opt_CompanyRegion.Checked && !ListBoxHelper.GetSelected(lst_CompanyArea, 0))
					{
						Query = "SELECT state_code, state_name ";
						Query = $"{Query}FROM State,Geographic ";
						Query = $"{Query}where state_code=geographic_state_code and state_country=geographic_country_name and geographic_region_name in ({CompanyRegionlist}) ";
					}
					if (Strings.Len(CompanyContinentlist.Trim()) > 0 && opt_CompanyContinent.Checked && !ListBoxHelper.GetSelected(lst_CompanyArea, 0))
					{
						Query = "SELECT state_code, state_name ";
						Query = $"{Query}FROM State,Country ";
						Query = $"{Query}where state_country=country_name and country_continent_name in ({CompanyContinentlist}) ";
					}
				}
				if (Query == "")
				{
					Query = "SELECT state_code, state_name ";
					Query = $"{Query}FROM State ";
				}
				Query = $"{Query}order by state_code";

				snp_StateList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_StateList.BOF && snp_StateList.EOF))
				{

					while(!snp_StateList.EOF)
					{
						M = $"{($"{Convert.ToString(snp_StateList["State_code"])}").Trim()} - {($"{Convert.ToString(snp_StateList["State_name"])}").Trim()}";
						lstCompanyState.AddItem(M);
						snp_StateList.MoveNext();
					};
				}

				snp_StateList.Close();
				snp_StateList = null;
				ListBoxHelper.SetSelected(lstCompanyState, 0, true);
			}
			catch (System.Exception excep)
			{

				search_off();
				modAdminCommon.Report_Error($"Fill_Company_State_List_Error: {excep.Message}");
			}
		}

		private void FillCompanyType()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int iCnt1 = 0;

			try
			{

				lstCompanyType.Items.Clear();
				lstCompanyType.AddItem("All");

				iCnt1 = 1;

				// 08/22/2019 - By David D. Cruger
				// Per Tasker #4902 - need to add an active flag to this table
				strQuery1 = "SELECT actype_code, actype_name ";
				strQuery1 = $"{strQuery1}FROM Aircraft_Contact_Type WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (actype_compref_flag = 'N') ";
				strQuery1 = $"{strQuery1}AND (actype_active_flag = 'Y') ";
				strQuery1 = $"{strQuery1}ORDER BY actype_name";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					CompanyType = ArraysHelper.RedimPreserve(CompanyType, new int[]{rstRec1.RecordCount + 4});

					do 
					{
						lstCompanyType.AddItem(($"{Convert.ToString(rstRec1["actype_name"])} ").Trim());
						CompanyType[iCnt1] = ($"{Convert.ToString(rstRec1["actype_code"])}").Trim();
						rstRec1.MoveNext();
						iCnt1++;
					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				lstCompanyType.AddItem("All Owners");
				CompanyType[iCnt1] = "00,50,97";
				iCnt1++;
				lstCompanyType.AddItem("Exclusive Owners/Operators");
				CompanyType[iCnt1] = "00,50";
				iCnt1++;
				lstCompanyType.AddItem("All Dealers/Brokers");
				CompanyType[iCnt1] = "98,99";

				rstRec1.Close();
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				search_off();
				modAdminCommon.Report_Error($"Fill_Company_State_List_Error: {excep.Message}");
			}

		} // FillCompanyType

		private void FillEMP()
		{

			string Query = "";
			ADORecordSetHelper snpEMP = new ADORecordSetHelper(); //7/26/05 aey

			try
			{

				cboEMP.Items.Clear();
				cboEMP.AddItem("Not Specified");

				Query = "SELECT DISTINCT emp_code, emp_name FROM Engine_Maintenance_Program ORDER BY emp_code";

				snpEMP.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpEMP.BOF && snpEMP.EOF))
				{

					while(!snpEMP.EOF)
					{
						cboEMP.AddItem($"{($"{Convert.ToString(snpEMP["emp_code"])}").Trim()} - {($"{Convert.ToString(snpEMP["emp_name"])}").Trim()}");
						snpEMP.MoveNext();
					};
				}

				snpEMP.Close();
				snpEMP = null;

				cboEMP.SelectedIndex = 0;
			}
			catch
			{

				search_off();
				modAdminCommon.Report_Error("FillEMP_Error: ");
			}

		}

		private void FillEngineModel(string inMake = "", string inModel = "")
		{

			string strQuery1 = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); //7/26/05 aey
			string RememberEng = "";

			try
			{

				if (cboEngineModel.Text != "Not Specified")
				{
					RememberEng = cboEngineModel.Text;
				}

				cboEngineModel.Items.Clear();
				cboEngineModel.AddItem("Not Specified");

				strQuery1 = "SELECT DISTINCT ameng_engine_name ";
				strQuery1 = $"{strQuery1}FROM Aircraft_Model_Engine WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Model WITH (NOLOCK) ON amod_id = ameng_amod_id ";
				strQuery1 = $"{strQuery1}WHERE (amod_customer_flag = 'Y') ";

				if (inMake != "" && inMake != "All")
				{
					strQuery1 = $"{strQuery1}AND (amod_make_name = '{StringsHelper.Replace(inMake, "'", "''", 1, -1, CompareMethod.Binary)}') ";
				}
				if (inModel != "" && inModel != "All")
				{
					strQuery1 = $"{strQuery1}AND (amod_model_name = '{StringsHelper.Replace(inModel, "'", "''", 1, -1, CompareMethod.Binary)}') ";
				}

				strQuery1 = $"{strQuery1}ORDER BY ameng_engine_name";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{
						cboEngineModel.AddItem(($"{Convert.ToString(rstRec1["ameng_engine_name"])} ").Trim());
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;

				cboEngineModel.SelectedIndex = 0;

				if (RememberEng != "")
				{
					int tempForEndVar = cboEngineModel.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						if (cboEngineModel.GetListItem(i) == RememberEng)
						{
							cboEngineModel.SelectedIndex = i;
							break;
						}
					}
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"FillEngineModel_Error: {excep.Message}");
			}

		}

		private void FillMaintained()
		{

			string Query = "";
			ADORecordSetHelper snpMaintained = new ADORecordSetHelper(); //7/26/05 aey

			try
			{

				cboMaintained.Items.Clear();
				cboMaintained.AddItem("Not Specified");

				Query = "SELECT * FROM Certification ORDER BY certification_name";

				snpMaintained.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpMaintained.BOF && snpMaintained.EOF))
				{

					while(!snpMaintained.EOF)
					{
						cboMaintained.AddItem(($"{Convert.ToString(snpMaintained["certification_name"])}").Trim());
						snpMaintained.MoveNext();
					};
				}

				snpMaintained.Close();
				snpMaintained = null;

				cboMaintained.SelectedIndex = 0;
			}
			catch
			{

				search_off();
				modAdminCommon.Report_Error("FillMaintained_Error: ");
			}

		}

		private void FillWeightClass(string inType = "")
		{

			string strQuery1 = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); //aey 6/15/04
			string tmpType = "";

			try
			{

				cboWeightClass.Items.Clear();
				cboWeightClass.AddItem("Not Specified");

				inType = ($"{inType} ").Trim();

				if (inType != "")
				{
					strQuery1 = "SELECT acwgtcls_code, acwgtcls_name ";
					strQuery1 = $"{strQuery1}FROM Aircraft_Weight_Class WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE acwgtcls_maketype = '{inType}'";
				}
				else
				{
					strQuery1 = "SELECT acwgtcls_code, acwgtcls_name, acwgtcls_maketype, atype_name ";
					strQuery1 = $"{strQuery1}FROM Aircraft_Weight_Class WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Type WITH (NOLOCK) ON atype_code = acwgtcls_maketype ";
					strQuery1 = $"{strQuery1}ORDER BY acwgtcls_maketype";
				}

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						if (inType != "")
						{
							cboWeightClass.AddItem(($"{Convert.ToString(rstRec1["acwgtcls_name"])} ").Trim());
						}
						else
						{
							cboWeightClass.AddItem($"{($"{Convert.ToString(rstRec1["atype_name"])} ").Trim()} - {($"{Convert.ToString(rstRec1["acwgtcls_name"])} ").Trim()}");
						}

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;

				cboWeightClass.SelectedIndex = 0;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FillWeightClassError: {Information.Err().Number.ToString()} {excep.Message} {excep.Source} in:{inType}");
			}

		}

		private string GetStatusInfo(int PassedID)
		{

			string result = "";
			result = ($"{Convert.ToString(snp_AircraftList["ac_status"])}").Trim();

			if (($"{Convert.ToString(snp_AircraftList["ac_forsale_flag"])}").Trim() != "N")
			{
				if (($"{Convert.ToString(snp_AircraftList["ac_asking"])}").Trim() == "Price")
				{
					result = $"{result} (${StringsHelper.Format(($"{Convert.ToString(snp_AircraftList["ac_asking_price"])}").Trim(), "###,###0")})";
				}
				else
				{
					result = $"{result} ({($"{Convert.ToString(snp_AircraftList["ac_asking"])}").Trim()})";
				}

				if (($"{Convert.ToString(snp_AircraftList["ac_delivery"])}").Trim() == "Date")
				{
					result = $"{result} - Delivery: {($"{Convert.ToString(snp_AircraftList["ac_delivery_date"])}").Trim()}";
					if (chkCompanyFlag.CheckState == CheckState.Checked && ($"{Convert.ToString(snp_AircraftList["ac_forsale_flag"])}").Trim() == "Y")
					{
						grdAircraft.SetRowHeight(grdAircraft.CurrentRowIndex, 40);
					}
				}
				else if (($"{Convert.ToString(snp_AircraftList["ac_delivery"])}").Trim() != "")
				{ 
					result = $"{result} - Delivery: {($"{Convert.ToString(snp_AircraftList["ac_delivery"])}").Trim()}";
					if (chkCompanyFlag.CheckState == CheckState.Checked && ($"{Convert.ToString(snp_AircraftList["ac_forsale_flag"])}").Trim() == "Y")
					{
						grdAircraft.SetRowHeight(grdAircraft.CurrentRowIndex, 40);
					}
				}
				if (($"{Convert.ToString(snp_AircraftList["ac_list_date"])}").Trim() != "")
				{
					result = $"{result} - Listed: {($"{Convert.ToString(snp_AircraftList["ac_list_date"])}").Trim()}";
				}

			}

			return result;
		}

		private void InsertGridHeadings()
		{
			//***************************************************
			//
			// THE PURPOSE OF THIS PROCEDURE IS TO SET THE HEADINGS FOR THE
			// AIRCRAFT LIST
			//
			grdAircraft.RowsCount = 2;
			grdAircraft.FixedRows = 1;
			grdAircraft.FixedColumns = 0;
			grdAircraft.CurrentColumnIndex = 0;

			// IF COMPANY INFORMATION IS CHECKED THEN ADD A COLUMN
			if (chkCompanyFlag.CheckState == CheckState.Checked)
			{
				grdAircraft.ColumnsCount = 12;
			}
			else
			{
				grdAircraft.ColumnsCount = 11;
			}

			// DEFINE HEADING COLUMNS
			colMake = 0; // MAKE
			colModel = 1; // MODEL
			colSerial = 2; // SERIAL #
			colRegistration = 3; // REGISTRATION #
			colYear = 4; // YEAR
			colStatus = 5; // STATUS
			if (chkCompanyFlag.CheckState == CheckState.Checked)
			{
				colCompany = 6; // COMPANY IF COMPANY CHECKED
				colACLocation = 10;
				colNewUsed = 11;
			}
			else
			{
				colACLocation = 9; // AIRCRAFT LOCATION
				colNewUsed = 10;
			}
			grdAircraft.CurrentRowIndex = 0;

			// MAKE
			grdAircraft.CurrentColumnIndex = colMake;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "Make";
			grdAircraft.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grdAircraft.SetColumnWidth(colMake, 153); //was 2000 aey 6/28/05

			// MODEL
			grdAircraft.CurrentColumnIndex = colModel;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "Model";
			grdAircraft.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grdAircraft.SetColumnWidth(colModel, 67);

			// SERIAL #
			grdAircraft.CurrentColumnIndex = colSerial;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "Serial #";
			grdAircraft.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grdAircraft.SetColumnWidth(colSerial, 80);

			// REGISTRATION NUMBER
			grdAircraft.CurrentColumnIndex = colRegistration;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "Registration";
			grdAircraft.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grdAircraft.SetColumnWidth(colRegistration, 73);

			// YEAR
			grdAircraft.CurrentColumnIndex = colYear;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "Year";
			grdAircraft.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grdAircraft.SetColumnWidth(colYear, 33);

			// STATUS
			grdAircraft.CurrentColumnIndex = colStatus;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "Status";
			grdAircraft.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			if (chkCompanyFlag.CheckState == CheckState.Checked)
			{
				grdAircraft.SetColumnWidth(colStatus, 173);
			}
			else
			{
				grdAircraft.SetColumnWidth(colStatus, 440);
			}

			// COMPANY INFORMATION
			if (chkCompanyFlag.CheckState == CheckState.Checked)
			{
				grdAircraft.CurrentColumnIndex = colCompany;
				grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "Company (City, State)";
				grdAircraft.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grdAircraft.SetColumnWidth(colCompany, 273);
			}

			// *****************************
			// AIRCRAFT LOCATION
			grdAircraft.CurrentColumnIndex = colACLocation;
			grdAircraft.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "Aircraft Location";
			grdAircraft.SetColumnWidth(colACLocation, 167);

			grdAircraft.CurrentColumnIndex = colNewUsed;
			grdAircraft.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "Used";
			grdAircraft.SetColumnWidth(colNewUsed, 33);

		}

		public bool IsNumber(string inString)
		{


			bool result = false;
			result = true;

			int tempForEndVar = Strings.Len(inString) - 1;
			for (int i = 0; i <= tempForEndVar; i++)
			{
				if (!Information.IsNumeric(inString.Substring(Math.Min(i, inString.Length), Math.Min(1, Math.Max(0, inString.Length - i)))))
				{
					return false;
				}
			}


			return result;
		}

		public void Select_Company()
		{

			try
			{

				frm_Company o_Local_Show_Company = null;

				if (snp_AircraftList.State == ConnectionState.Open)
				{

					snp_AircraftList.MoveFirst();
					int tempForEndVar = grdAircraft.CurrentRowIndex - 1;
					for (int i = 1; i <= tempForEndVar; i++)
					{
						snp_AircraftList.MoveNext();
					}
				}
				else
				{
					return;
				}

				//unload any extaneous contact forms that may exist
				modCommon.Unload_Form("frm_Company");

				o_Local_Show_Company = frm_Company.CreateInstance();
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(o_Local_Show_Company);
				o_Local_Show_Company.Form_Initialize();
				o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
				o_Local_Show_Company.Reference_CompanyID = Convert.ToInt32(snp_AircraftList["Comp_id"]);
				if (chkTransactions.CheckState == CheckState.Checked)
				{
					o_Local_Show_Company.Reference_CompanyJID = Convert.ToInt32(snp_AircraftList["AC_Journ_id"]);
				}
				else
				{
					o_Local_Show_Company.Reference_CompanyJID = 0;
				}
				o_Local_Show_Company.Show();
				//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				o_Local_Show_Company.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				o_Local_Show_Company.Form_Activated(null, new EventArgs());
			}
			catch
			{

				modAdminCommon.Report_Error("Select_Company_Error: ");
				search_off();
				return;
			}

		}

		private void search_on(string inMessage)
		{

			try
			{

				this.Cursor = Cursors.WaitCursor;
				pnl_SearchWait.Visible = true;
				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_SearchWait.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_SearchWait.setCaption(inMessage.Trim());
				pnl_SearchWait.Refresh();
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, inMessage, Color.Blue);
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("Aircraft (frm_AircraftList)", $"Search_On: {Information.Err().Number.ToString()} - {excep.Message}");
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

		}

		private void search_off()
		{

			this.Cursor = CursorHelper.CursorDefault;
			pnl_SearchWait.Visible = false;
			//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_SearchWait.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			pnl_SearchWait.setCaption(" ");
			pnl_SearchWait.Refresh();
			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			Application.DoEvents();

		}

		private void cbo_ContactType_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(cbo_ContactType, cbo_ContactType.Text);


		private void cbo_JournalCategory_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(cbo_JournalCategory, cbo_JournalCategory.Text);


		private void cboAirframeTypeCode_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (cboAirframeTypeCode.Enabled)
			{
				FillTypeList();
				FillMakeList();
				FillModelList();
			} // If cboAirframeTypeCode.Enabled = True Then

		}

		private void cboUsage_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cboUsage, eventSender);

			if (cboUsage[Index].SelectedIndex > -1)
			{

				cboUsageCondition[Index].Visible = true;

				if (lblUsageFormat[Index].Visible)
				{
					MakeLabelVisible(Index);
				}

				if (Index < cboUsage.ControlCount() - 1)
				{
					if (cboUsage[Index + 1].Visible)
					{
						cboUsage[Index + 1].Items.Clear();
						FillUsageCombos();
					}
				}

			}

		}

		private void cboUsageCondition_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cboUsageCondition, eventSender);

			if (cboUsageCondition[Index].SelectedIndex > -1)
			{
				txtUsageValue[Index].Visible = true;
				MakeLabelVisible(Index);
				FillUsageCombos();
			}

		}

		private void MakeLabelVisible(int PassedIndex)
		{

			lblUsageFormat[PassedIndex].Text = UsageFormat[cboUsage[PassedIndex].GetItemData(cboUsage[PassedIndex].SelectedIndex), cboUsageCondition[PassedIndex].SelectedIndex];
			lblUsageFormat[PassedIndex].Visible = true;

		}

		private void chkCompanyFlag_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkCompanyFlag.CheckState == CheckState.Checked)
			{
				fraCompanyDemographics.Visible = true;
				chkTransactions.Visible = true;
			}
			else
			{
				fraCompanyDemographics.Visible = false;
				chkTransactions.Visible = false;
			}

		}

		private void chkTransactions_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkTransactions.CheckState == CheckState.Checked)
			{
				frm_Transactions.Visible = true;
				optNewUsed[3].Visible = true;
				//optNewUsed(2).Visible = False
			}
			else
			{
				frm_Transactions.Visible = false;
				optNewUsed[3].Visible = false;
				//optNewUsed(2).Visible = True
			}



		}

		private void cmd_cancel_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		private void cmd_pick_Ac_Click(Object eventSender, EventArgs eventArgs)
		{

			int temp_ac_id = 0;

			frm_AircraftList.DefInstance.is_from_company = false;
			cmd_pick_Ac.Visible = false;

			temp_ac_id = grdAircraft.get_RowData(grdAircraft.CurrentRowIndex);

			frm_aircraft.DefInstance.txtDocNotes[2].Text = temp_ac_id.ToString();

			this.Hide();
			frm_aircraft.DefInstance.Show();

		}

		private void cmd_SelectAircraft_Click(Object eventSender, EventArgs eventArgs)
		{
			if (!Selected)
			{
				Select_Aircraft();
			}
		}

		private void cmdAircraftListExcelExport_Click(Object eventSender, EventArgs eventArgs)
		{

			cmdAircraftListExcelExport.Enabled = false;
			modExcel.ExportMSHFlexGrid(grdAircraft);
			cmdAircraftListExcelExport.Enabled = true;

		}

		private void cmdClear_Click(Object eventSender, EventArgs eventArgs)
		{

			Control Control = null;


			//UPGRADE_WARNING: (2065) Form property frm_AircraftList.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			foreach (Control ControlIterator in ContainerHelper.Controls(this))
			{
				Control = ControlIterator;
				if (Control is ComboBox)
				{
					//UPGRADE_TODO: (1067) Member List is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					if (Convert.ToString((Control as ComboBox).Items[0]) == "Not Specified")
					{
						//UPGRADE_TODO: (1067) Member ListIndex is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(Control as ComboBox).SelectedIndex = 0;
					}
					else
					{
						//UPGRADE_TODO: (1067) Member ListIndex is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(Control as ComboBox).SelectedIndex = (-1);
					}
				}
				if (Control is ListBox)
				{
					//UPGRADE_TODO: (1067) Member ListCount is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					double tempForEndVar = Convert.ToDouble((Control as ListBox).Items.Count) - 1;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						//UPGRADE_TODO: (1067) Member Selected is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(Control as ListBox).SelectedItems[i] = false;
					}
				}
				if ((Control is TextBox) && (Control.Name != "txt_gen"))
				{
					Control.Text = "";
				}
				if (Control is CheckBox)
				{
					//UPGRADE_TODO: (1067) Member Value is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					(Control as CheckBox).Checked = false;
				}
				//Control
				Control = default(Control);
			}

			ListBoxHelper.SetSelected(lstType, 0, true);
			optAll.Checked = true;
			optNewUsed[0].Checked = true;

			int tempForEndVar2 = cboUsageCondition.ControlCount() - 1;
			for (int i = 0; i <= tempForEndVar2; i++)
			{
				cboUsageCondition[i].Visible = false;
				txtUsageValue[i].Visible = false;
				lblUsageFormat[i].Visible = false;
				if (i > 0)
				{
					cboUsage[i].Visible = false;
					cboUsage[i].Items.Clear();
				}
			}

		}

		private void cmdHideTrans_Click(Object eventSender, EventArgs eventArgs)
		{
			frm_Transactions.Visible = false;
			Application.DoEvents();
		}

		private void cmdStop_Click(Object eventSender, EventArgs eventArgs)
		{

			Stopped = true;
			Application.DoEvents();

		}

		private void cmdStop_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) System.Windows.Forms.Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			HadHourglass = this.Cursor == Cursors.WaitCursor || HadHourglass;
			this.Cursor = CursorHelper.CursorDefault;
			Application.DoEvents();

		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcAIRCRAFT);

				Selected = false;
				if (modAdminCommon.gbl_bHomeClicked)
				{
					this.Close();
				}
				else
				{
					if (modAdminCommon.gbl_User_ID.ToUpper() == "DCR")
					{
						txt_ac_id.Focus();
					}
					else
					{
						txtSerialNoFrom.Focus();
					}
				}

				bFormActivate = true;

			}
		}

		private void Form_Enter(Object eventSender, EventArgs eventArgs)
		{

			if (SSTabHelper.GetSelectedIndex(Tabs1) == 1 && chkDontRefreshList.CheckState == CheckState.Unchecked)
			{
				ComingBack = true;
				ExactSerial = true;
				BuildQuery();
				if (SomethingSelected || SerialNumberSelected)
				{
					txt_gen[0].Visible = chkCompanyFlag.CheckState == CheckState.Checked;
					Fill_Aircraft_Grid();
					Selected = false;
				}
			}

		}

		private void Form_Initialize() => bFormInitialize = true;


		private void Form_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				System.DateTime dtStart = DateTime.FromOADate(0);
				int lElapsed = 0;

				if (SSTabHelper.GetSelectedIndex(Tabs1) == 0)
				{
					if ((KeyCode == ((int) Keys.F1)) || (KeyCode == ((int) Keys.Return)))
					{
						dtStart = DateTime.Now;
						do 
						{
							lElapsed = (int) DateAndTime.DateDiff("s", dtStart, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
						}
						while(!((bFormLoad && bFormActivate) || lElapsed >= 10));
						SSTabHelper.SetSelectedIndex(Tabs1, 1);
					}
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			bFormLoad = false;
			bFormInitialize = false;
			bFormActivate = false;

			AlreadyLoadedList = false;

			FillAirframeType();
			Fill_Aircraft_Usage_List();
			FillInteriorConfig();

			FillTypeList();
			FillMakeList();
			FillModelList();

			FillStage();
			FillClass();
			FillCompanyType();

			modFillAircraftControls.Fill_TimeZoneList_FromArray(lstCompanyTimeZone);
			FillExclusive();
			FillOwnershipType();
			FillLeaseStatus();
			FillBusinessType();
			FillAsking();
			FillMaintained();
			// 11/14/2019 By David D. Cruger
			// Do Not Auto Fill In
			// If the User Needs It They Double Click The Label To Fill
			// FillEngineModel
			FillEMP();

			modFillAircraftControls.Fill_Aircraft_Status_List(txt_ac_status, 11);

			modFillCompConControls.fill_agencytype_FromArray(cbo_agency_type);
			Fill_Model_Config();
			Fill_Engine_Noise_Rating();
			Fill_ContactType();

			// 11/14/2019 By David D. Cruger
			// Do Not Auto Fill In
			// If the User Needs It They Double Click The Label To Fill
			// Fill_Journal_Category

			cbo_engCompare.Items.Clear();
			cbo_engCompare.AddItem("");
			cbo_engCompare.AddItem("=");
			cbo_engCompare.AddItem(">");
			cbo_engCompare.AddItem("<");
			cbo_engCompare.SelectedIndex = 0;

			cbo_ac_delivery.Items.Clear();
			cbo_ac_delivery.AddItem("Not Specified");
			cbo_ac_delivery.AddItem("Immediate");
			cbo_ac_delivery.AddItem("Date");

			//Display_Account_Rep_List
			modFillCompConControls.Fill_AccountRep_FromArray(cbo_Acc_Rep, false, false);
			snp_AircraftList = null;

			lbl_Search_Heading.Text = "Aircraft Selection List";
			str_Orderby = " ORDER BY amod_type_code,amod_make_name,amod_model_name,ac_ser_no_sort";

			FillUsageCombos();
			FillWeightClass();

			opt_Continent.Enabled = false;
			opt_CompanyContinent.Enabled = false;

			opt_Continent.Checked = true;
			opt_CompanyContinent.Checked = true;

			opt_Continent.Enabled = true;
			opt_CompanyContinent.Enabled = true;

			Fill_Demographics();
			Fill_Company_Demographics();

			SSTabHelper.SetSelectedIndex(Tabs1, 0);

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Initialize the ToolBar
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			ToolbarSetup();
			ToolbarButtonsSetup();

			bFormLoad = true;

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

		} // Form_Load

		private void FillBusinessType()
		{

			ADORecordSetHelper snpBusType = new ADORecordSetHelper(); //aey 6/15/04

			cboBusinessType.Items.Clear();
			cboBusinessType.AddItem("Not Specified");

			string Query = "SELECT cbus_type, cbus_name FROM Company_Business_Type WITH (NOLOCK) ORDER BY cbus_name";

			snpBusType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snpBusType.BOF && snpBusType.EOF))
			{

				while(!snpBusType.EOF)
				{
					cboBusinessType.AddItem($"{($"{Convert.ToString(snpBusType["cbus_type"])}").Trim()} - {($"{Convert.ToString(snpBusType["cbus_name"])}").Trim()}");
					snpBusType.MoveNext();
				};

			}

			cboBusinessType.SelectedIndex = 0;

			snpBusType.Close();

		}

		private void FillLeaseStatus()
		{

			cboLeaseStatus.Items.Clear();
			cboLeaseStatus.AddItem("Not Specified");
			cboLeaseStatus.AddItem("Yes");
			cboLeaseStatus.AddItem("No");

			cboLeaseStatus.SelectedIndex = 0;

		}

		private void FillOwnershipType()
		{

			cboOwnType.Items.Clear();
			cboOwnType.AddItem("Not Specified");
			cboOwnType.AddItem("Whole");
			cboOwnType.AddItem("Shared");
			cboOwnType.AddItem("Fractional");

			cboOwnType.SelectedIndex = 0;

		}

		private void FillExclusive()
		{

			cboExclusive.Items.Clear();
			cboExclusive.AddItem("Not Specified");
			cboExclusive.AddItem("Yes");
			cboExclusive.AddItem("No");

			cboExclusive.SelectedIndex = 0;

		}

		private void FillUsageCombos()
		{


			int tempForEndVar = cboUsage.ControlCount() - 1;
			for (int i = 0; i <= tempForEndVar; i++)
			{
				if (cboUsage[i].Items.Count == 0)
				{

					cboUsage[i].Items.Clear();

					UsageField = ArraysHelper.InitializeArray<string[, ]>(new int[]{7, 5}, new int[]{0, 0}); // cboUsage.Count)
					UsageFormat = ArraysHelper.InitializeArray<string[, ]>(new int[]{7, 5}, new int[]{0, 0});

					cboUsage[i].AddItem("Last Update Date");
					cboUsage[i].SetItemData(cboUsage[i].Items.Count - 1, 0);

					cboUsage[i].AddItem("Next Followup Date");
					cboUsage[i].SetItemData(cboUsage[i].Items.Count - 1, 1);

					cboUsage[i].AddItem("Date Listed");
					cboUsage[i].SetItemData(cboUsage[i].Items.Count - 1, 2);

					cboUsage[i].AddItem("Asking Price");
					cboUsage[i].SetItemData(cboUsage[i].Items.Count - 1, 3);

					cboUsage[i].AddItem("Airframe Total Time");
					cboUsage[i].SetItemData(cboUsage[i].Items.Count - 1, 4);

					cboUsage[i].AddItem("Landings");
					cboUsage[i].SetItemData(cboUsage[i].Items.Count - 1, 5);


					UsageField[0, 0] = "ac_last_verified_date";
					UsageField[1, i] = "ac_next_verified_date";
					UsageField[2, i] = "ac_list_date";
					UsageField[3, i] = "ac_asking_price";
					UsageField[4, i] = "ac_airframe_tot_hrs";
					UsageField[5, i] = "ac_airframe_tot_landings";

					UsageFld[0] = "ac_last_verified_date"; //aey 3/21/05
					UsageFld[1] = "ac_next_verified_date";
					UsageFld[2] = "ac_list_date";
					UsageFld[3] = "ac_asking_price";
					UsageFld[4] = "ac_airframe_tot_hrs";
					UsageFld[5] = "ac_airframe_tot_landings";
					UsageFmt[0] = "(MM/DD/YYCC)";
					UsageFmt[1] = "(MM/DD/YYCC)";
					UsageFmt[2] = "(MM/DD/YYCC)";
					UsageFmt[3] = "(NNNNNN)";
					UsageFmt[4] = "(NNNNNN)";
					UsageFmt[5] = "(NNNNNN)";

					UsageFormat[0, 0] = "(MM/DD/YYCC)";
					UsageFormat[0, 1] = "(MM/DD/YYCC)";
					UsageFormat[0, 2] = "(MM/DD/YYCC)";
					UsageFormat[0, 3] = "(MM/DD/YYCC:MM/DD/YYCC)";

					UsageFormat[1, 0] = "(MM/DD/YYCC)";
					UsageFormat[1, 1] = "(MM/DD/YYCC)";
					UsageFormat[1, 2] = "(MM/DD/YYCC)";
					UsageFormat[1, 3] = "(MM/DD/YYCC:MM/DD/YYCC)";

					UsageFormat[2, 0] = "(MM/DD/YYCC)";
					UsageFormat[2, 1] = "(MM/DD/YYCC)";
					UsageFormat[2, 2] = "(MM/DD/YYCC)";
					UsageFormat[2, 3] = "(MM/DD/YYCC:MM/DD/YYCC)";

					UsageFormat[3, 0] = "(NNNNNN)";
					UsageFormat[3, 1] = "(NNNNNN)";
					UsageFormat[3, 2] = "(NNNNNN)";
					UsageFormat[3, 3] = "(NNNNNN:NNNNNN)";

					UsageFormat[4, 0] = "(NNNNNN)";
					UsageFormat[4, 1] = "(NNNNNN)";
					UsageFormat[4, 2] = "(NNNNNN)";
					UsageFormat[4, 3] = "(NNNNNN:NNNNNN)";

					UsageFormat[5, 0] = "(NNNNNN)";
					UsageFormat[5, 1] = "(NNNNNN)";
					UsageFormat[5, 2] = "(NNNNNN)";
					UsageFormat[5, 3] = "(NNNNNN:NNNNNN)";

					if (cboUsageCondition[i].Items.Count == 0)
					{
						cboUsageCondition[i].AddItem("=");
						cboUsageCondition[i].AddItem("<");
						cboUsageCondition[i].AddItem(">");
						cboUsageCondition[i].AddItem("Between");
					}

					cboUsage[i].Visible = true;

					break;
				}
				else
				{
					if (cboUsage[i].SelectedIndex == -1)
					{
						break;
					}
				}
			}

		}

		private void FillMakeList()
		{

			string Query = "";
			ADORecordSetHelper snpMake = new ADORecordSetHelper(); //aey 6/15/04
			string tmp = ""; //aey 3/24/05
			int K = 0;
			int K2 = 0;
			int K3 = 0;
			string tmp2 = "";
			StringBuilder FList = new StringBuilder();

			try
			{
				lstMake.Items.Clear();
				lstMake.AddItem("All");
				FList = new StringBuilder("");

				if (lstType.SelectedItems.Count > 0)
				{

					Query = "SELECT DISTINCT amod_make_name, amod_type_code,amod_make_abbrev,amod_airframe_type_code ";
					Query = $"{Query}FROM Aircraft_Model ";

					if (!ListBoxHelper.GetSelected(lstType, 0))
					{
						Query = $"{Query}WHERE (";
						int tempForEndVar = lstType.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar; i++)
						{
							if (ListBoxHelper.GetSelected(lstType, i))
							{
								tmp = "";
								tmp2 = "";
								K = lstType.GetItemData(i);
								if (K > 0)
								{
									K2 = Convert.ToInt32(Math.Floor(K / 100d) * 100);
									tmp = Strings.Chr(Convert.ToInt32(Math.Floor(K / 100d))).ToString();
									tmp2 = Strings.Chr(K - K2).ToString();
								}
								FList.Append(tmp);
								Query = $"{Query}( amod_type_code ='{tmp2}' ";
								Query = $"{Query} and amod_airframe_type_code ='{tmp}') or ";
							}
						}
						Query = $"{Query.Substring(0, Math.Min(Strings.Len(Query) - 3, Query.Length))})";
					}

					if (cboAirframeTypeCode.Text != "Not Specified")
					{
						if ((Query.IndexOf(" WHERE ") + 1) == 0)
						{
							Query = $"{Query} where amod_airframe_type_code='{cboAirframeTypeCode.Text.Substring(0, Math.Min(1, cboAirframeTypeCode.Text.Length))}' ";
						}
						else
						{
							Query = $"{Query} and amod_airframe_type_code='{cboAirframeTypeCode.Text.Substring(0, Math.Min(1, cboAirframeTypeCode.Text.Length))}' ";
						}
					}

					// added MSw - 1/19/21
					if (Query.IndexOf("WHERE") >= 0)
					{
						Query = $"{Query} and amod_id not in (1297,1295,1296) ";
					}
					else
					{
						Query = $"{Query} where amod_id not in (1297,1295,1307) ";
					}

					//    If chk_include_not_researched.Value = 0 Then  ' then
					//        If InStr(Query, "WHERE") > 0 Then
					//            Query = Query & " and amod_research_priority < 50 "
					//        Else
					//            Query = Query & " where amod_research_priority < 50 "
					//        End If
					//    End If




					Query = $"{Query}ORDER BY amod_make_name";

					snpMake.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					if (!(snpMake.BOF && snpMake.EOF))
					{

						while(!snpMake.EOF)
						{
							if (cboAirframeTypeCode.SelectedIndex == 0)
							{
								lstMake.AddItem(($"[{Convert.ToString(snpMake["amod_airframe_type_code"])}{Convert.ToString(snpMake["amod_type_code"])}] - {Convert.ToString(snpMake["amod_make_name"])}").Trim());
							}
							else
							{
								lstMake.AddItem(($"[{Convert.ToString(snpMake["amod_type_code"])}] - {Convert.ToString(snpMake["amod_make_name"])}").Trim());
							}

							tmp = ($"{($"{Convert.ToString(snpMake["amod_make_abbrev"])}").ToUpper()}  ").Substring(0, Math.Min(2, ($"{($"{Convert.ToString(snpMake["amod_make_abbrev"])}").ToUpper()}  ").Length));

							lstMake.SetItemData(lstMake.GetNewIndex(), (100 * Strings.Asc(tmp.Substring(Math.Min(0, tmp.Length), Math.Min(1, Math.Max(0, tmp.Length)))[0])) + Strings.Asc(tmp.Substring(Math.Min(1, tmp.Length), Math.Min(1, Math.Max(0, tmp.Length - 1)))[0]));

							snpMake.MoveNext();
						};
					}
				}

				if (snpMake.State == ConnectionState.Open)
				{
					snpMake.Close();
				}

				snpMake = null;

				lstMake.Enabled = false;
				ListBoxHelper.SetSelected(lstMake, 0, true);
				lstMake.Enabled = true;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"FillMakeList_Error: {excep.Message}");
			}

		}

		private void FillModelList()
		{

			string Query = "";
			ADORecordSetHelper snpModel = new ADORecordSetHelper(); //aey 6/15/04
			StringBuilder tmp = new StringBuilder(); //aey 3/24/05
			string tmp2 = "";
			int K = 0;
			int K2 = 0;
			int K3 = 0;
			string tmp3 = "";

			try
			{

				lstModel.Items.Clear();
				lstModel.AddItem("All");

				if (lstMake.SelectedItems.Count > 0)
				{

					Query = "SELECT DISTINCT amod_model_name, amod_make_abbrev, amod_id ";
					Query = $"{Query}FROM Aircraft_Model ";

					if (!ListBoxHelper.GetSelected(lstMake, 0))
					{

						//aey 3/24/05  decode make abbrev
						Query = $"{Query}WHERE ";
						int tempForEndVar = lstMake.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar; i++)
						{
							if (ListBoxHelper.GetSelected(lstMake, i))
							{
								K = lstMake.GetItemData(i);
								if (K > 0)
								{
									K2 = Convert.ToInt32(Math.Floor(K / 100d) * 100);
									tmp = new StringBuilder(Strings.Chr(Convert.ToInt32(Math.Floor(K / 100d))).ToString());
									tmp.Append(Strings.Chr(K - K2).ToString());
									Query = $"{Query}(amod_make_abbrev = '{tmp.ToString()}'  ";
									if (cboAirframeTypeCode.SelectedIndex == 0)
									{
										Query = $"{Query}and amod_type_code ='{lstMake.GetListItem(i).Substring(Math.Min(2, lstMake.GetListItem(i).Length), Math.Min(1, Math.Max(0, lstMake.GetListItem(i).Length - 2)))}') or ";
									}
									else
									{
										Query = $"{Query}and amod_type_code ='{lstMake.GetListItem(i).Substring(Math.Min(1, lstMake.GetListItem(i).Length), Math.Min(1, Math.Max(0, lstMake.GetListItem(i).Length - 1)))}') or ";
									}
								}
							}
						}

						Query = $"{Query.Substring(0, Math.Min(Strings.Len(Query) - 4, Query.Length))} ";

					}

					if (!ListBoxHelper.GetSelected(lstType, 0) && lstType.SelectedItems.Count > 0)
					{
						if (!ListBoxHelper.GetSelected(lstMake, 0))
						{
							Query = $"{Query} AND (";
						}
						else
						{
							Query = $"{Query} WHERE (";
						}
						int tempForEndVar2 = lstType.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar2; i++)
						{
							if (ListBoxHelper.GetSelected(lstType, i))
							{
								K = lstType.GetItemData(i);
								tmp = new StringBuilder("");
								tmp2 = "";
								if (K > 0)
								{
									K2 = Convert.ToInt32(Math.Floor(K / 100d) * 100);
									tmp = new StringBuilder(Strings.Chr(Convert.ToInt32(Math.Floor(K / 100d))).ToString()); //F or R
									tmp2 = Strings.Chr(K - K2).ToString();
								}

								Query = $"{Query}( amod_type_code = '{tmp2}' ";
								Query = $"{Query} and amod_airframe_type_code = '{tmp.ToString()}') or ";

							}
						}
						Query = $"{Query.Substring(0, Math.Min(Strings.Len(Query) - 3, Query.Length))})";
					}

					//select by airframe type
					if (cboAirframeTypeCode.Text != "Not Specified" || cboAirframeTypeCode.Text.Trim() == "")
					{
						if ((Query.IndexOf(" WHERE") + 1) == 0)
						{
							Query = $"{Query} where amod_airframe_type_code='{cboAirframeTypeCode.Text.Substring(0, Math.Min(1, cboAirframeTypeCode.Text.Length))}' ";

						}
						else
						{
							Query = $"{Query} and amod_airframe_type_code='{cboAirframeTypeCode.Text.Substring(0, Math.Min(1, cboAirframeTypeCode.Text.Length))}' ";
						}
					}


					if ((Query.IndexOf(" WHERE") + 1) == 0)
					{
						Query = $"{Query} where amod_id not in (1297,1295,1307) ";
					}
					else
					{
						Query = $"{Query} and amod_id not in (1297,1295,1296) ";
					}


					Query = $"{Query} ORDER BY amod_make_abbrev ,amod_model_name";

					snpModel.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					if (!(snpModel.BOF && snpModel.EOF))
					{

						while(!snpModel.EOF)
						{
							lstModel.AddItem(($"[{Convert.ToString(snpModel["amod_make_abbrev"])}] - {Convert.ToString(snpModel["amod_model_name"])}").Trim()); //aey 3/24/05
							lstModel.SetItemData(lstModel.GetNewIndex(), Convert.ToInt32(snpModel["amod_id"])); //aey 3/24/05
							snpModel.MoveNext();
						};
					}
				}

				if (snpModel.State == ConnectionState.Open)
				{
					snpModel.Close();
				}

				snpModel = null;
				lstModel.Enabled = false;
				ListBoxHelper.SetSelected(lstModel, 0, true);
				lstModel.Enabled = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FillModelList_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}
		} // FillModelList

		private void FillTypeList()
		{

			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  ListData                                                                              *
			//******************************************************************************************


			ADORecordSetHelper snpType = new ADORecordSetHelper(); //aey 6/15/04
			string tmp = "";
			string tmp2 = "";
			int K = 0;

			lstType.Items.Clear();
			lstType.AddItem("All");

			string Query = "select distinct afmt_code,afmt_description from airframe_make_type ";
			if (cboAirframeTypeCode.Text != "Not Specified")
			{
				Query = $"{Query}where afmt_code like  '{cboAirframeTypeCode.Text.Substring(0, Math.Min(1, cboAirframeTypeCode.Text.Length))}%' ";
			}

			Query = $"{Query}ORDER BY afmt_description";

			snpType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snpType.BOF && snpType.EOF))
			{

				while(!snpType.EOF)
				{
					tmp = ($"{Convert.ToString(snpType["afmt_code"])}").Trim();
					if (Strings.Len(tmp) == 2)
					{
						tmp2 = $"{Convert.ToString(snpType["afmt_description"])}";
						K = (tmp2.IndexOf("] - ") + 1);
						if (K > 0)
						{
							tmp2 = tmp2.Substring(Math.Min(K + 2, tmp2.Length)).Trim();
						}

						if (cboAirframeTypeCode.Text.StartsWith("N", StringComparison.Ordinal))
						{
							lstType.AddItem(($"[{Convert.ToString(snpType["afmt_code"])}] - {tmp2}").Trim());
						}
						else
						{
							K = (tmp2.IndexOf('-') + 1);
							if (K > 0)
							{
								tmp2 = tmp2.Substring(Math.Min(K, tmp2.Length)).Trim();
							}
							lstType.AddItem($"[{tmp.Substring(Math.Min(1, tmp.Length), Math.Min(1, Math.Max(0, tmp.Length - 1)))}] - {tmp2}");
						}

						//encode 2-digit airframe make type
						lstType.SetItemData(lstType.Items.Count - 1, (100 * Strings.Asc(tmp.Substring(Math.Min(0, tmp.Length), Math.Min(1, Math.Max(0, tmp.Length)))[0])) + Strings.Asc(tmp.Substring(Math.Min(1, tmp.Length), Math.Min(1, Math.Max(0, tmp.Length - 1)))[0]));

					}

					snpType.MoveNext();
				};
			}

			snpType.Close();
			snpType = null;

			lstType.Enabled = false;
			ListBoxHelper.SetSelected(lstType, 0, true);
			lstType.Enabled = true;

		}

		public void Fill_Aircraft_Grid()
		{
			bool FillAircraftError = false;

			// 02/02/2012 - By David D. Cruger
			// For Monitoring

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			string Query = "";
			string cellcolor = "";
			string CompanyCellColor = "";
			StringBuilder CompAddress = new StringBuilder();
			int GotTotal = 0;
			string AltSerial = "";
			string AltRegNo = "";
			StringBuilder strLocation = new StringBuilder();
			int lCnt1 = 0;

			this.Cursor = Cursors.WaitCursor;

			grdAircraft.Visible = false;
			grdAircraft.Enabled = false;
			grdAircraft.Redraw = false;

			lbl_Totfound.Text = "";
			int TotFound = 0;

			string TempACID = "";

			//   'start time tracking aey 4/28/05
			//   Call Record_Event("AircraftSearch", snp_User!user_id & " Started ")
			//   tmpStart = Format(Now, "hh:mm:ss")

			try
			{
				if (modAdminCommon.gbl_Search.Trim() != "")
				{

					modCommon.Start_Activity_Monitor_Message("Aircraft Search", ref strMsg, ref dtStartDate, ref dtEndDate);

					Stopped = false;
					cmdStop.Visible = true;
					cmdAircraftListExcelExport.Visible = false;

					// Temp Hold - I don't think this is needed
					//Tabs1.Tab = 1

					Query = $"{modAdminCommon.gbl_Search}{str_Orderby}";

					FillAircraftError = true;

					snp_AircraftList = new ADORecordSetHelper();
					snp_AircraftList.CursorLocation = CursorLocationEnum.adUseClient;
					snp_AircraftList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snp_AircraftList.BOF && snp_AircraftList.EOF))
					{

						GotTotal = snp_AircraftList.RecordCount;

						mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Maximum = GotTotal;
						mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value = 0;
						mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Visible = true;

						AlreadyLoadedList = true;
						grdAircraft.RowsCount = 1;
						InsertGridHeadings();
						grdAircraft.CurrentColumnIndex = 0;
						grdAircraft.RowsCount++;
						grdAircraft.CurrentRowIndex = 1;

						lCnt1 = 0;

						while(!snp_AircraftList.EOF)
						{

							if (Stopped)
							{
								break;
							}

							if (Convert.ToString(snp_AircraftList["ac_forsale_flag"]).ToUpper() == "Y")
							{
								cellcolor = modAdminCommon.ForSaleColor;
							}
							else
							{
								cellcolor = modAdminCommon.NoColor;
							}

							if (Query.IndexOf("Company") >= 0)
							{
								if (($"{Convert.ToString(snp_AircraftList["cref_primary_poc_flag"])}").Trim().ToUpper() == "Y")
								{
									CompanyCellColor = modAdminCommon.PrimaryColor;
								}
								else if (($"{Convert.ToString(snp_AircraftList["cref_primary_poc_flag"])}").Trim().ToUpper() == "X")
								{ 
									CompanyCellColor = modAdminCommon.ExclusiveColor;
								}
								else
								{
									CompanyCellColor = modAdminCommon.NoColor;
								}
							}

							if ((chkCompanyFlag.CheckState == CheckState.Unchecked) || (chkCompanyFlag.CheckState == CheckState.Checked && TempACID != ($"{Convert.ToString(snp_AircraftList["AC_ID"])}").Trim()))
							{

								grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								//grdAircraft.CellAlignment = flexAlignLeftTop
								grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_AircraftList["amod_make_name"])}").Trim()}";
								grdAircraft.CurrentColumnIndex++;

								grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								//grdAircraft.CellAlignment = flexAlignLeftTop
								grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_AircraftList["amod_model_name"])}").Trim()}";
								grdAircraft.CurrentColumnIndex++;

								grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								AltSerial = ($"{Convert.ToString(snp_AircraftList["ac_alt_ser_no_full"])}").Trim();
								if (Strings.Len(AltSerial.Trim()) > 0)
								{
									AltSerial = $" / {AltSerial}";
								}
								grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_AircraftList["ac_ser_no_full"])}").Trim()}{AltSerial}";
								grdAircraft.CurrentColumnIndex++;

								grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								AltRegNo = ($"{Convert.ToString(snp_AircraftList["ac_prev_reg_no"])}").Trim();
								if (Strings.Len(AltRegNo.Trim()) > 0)
								{
									AltRegNo = $" / {AltRegNo}";
								}

								grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_AircraftList["ac_reg_no"])}").Trim()}{AltRegNo} ";
								grdAircraft.CurrentColumnIndex++;


								grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_AircraftList["ac_year"])}").Trim()}";

								grdAircraft.CurrentColumnIndex++;

								grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grdAircraft.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
								grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = GetStatusInfo(Convert.ToInt32(snp_AircraftList["AC_ID"]));


								if (chkCompanyFlag.CheckState == CheckState.Unchecked)
								{
									grdAircraft.CurrentColumnIndex++;
									grdAircraft.SetColumnWidth(grdAircraft.CurrentColumnIndex, 27);
									if (($"{Convert.ToString(snp_AircraftList["ac_exclusive_flag"])}").Trim() == "Y")
									{
										grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ExclusiveColor)));
									}
									else
									{
										grdAircraft.CellBackColor = Color.White;
									}

									if (grdAircraft.ColumnsCount - 1 == grdAircraft.CurrentColumnIndex)
									{
										grdAircraft.ColumnsCount++;
									}

									grdAircraft.CurrentColumnIndex++;
									grdAircraft.SetColumnWidth(grdAircraft.CurrentColumnIndex, 27);
									if (($"{Convert.ToString(snp_AircraftList["ac_lease_flag"])}").Trim() == "Y")
									{
										grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.LeaseColor)));
									}
									else
									{
										grdAircraft.CellBackColor = Color.White;
									}

									cellcolor = modAdminCommon.NoColor;
									switch(Convert.ToString(snp_AircraftList["amod_class_code"]))
									{
										case "A" : 
											cellcolor = ColorTranslator.ToOle(modAdminCommon.ClassAColor).ToString(); 
											break;
										case "B" : 
											cellcolor = ColorTranslator.ToOle(modAdminCommon.ClassBColor).ToString(); 
											break;
										case "C" : 
											cellcolor = ColorTranslator.ToOle(modAdminCommon.ClassCColor).ToString(); 
											break;
										case "D" : 
											cellcolor = ColorTranslator.ToOle(modAdminCommon.ClassDColor).ToString(); 
											break;
									}

									// 03/11/2015 - By David D. Cruger
									// Per Jackie no need to show class color anymore.
									// I left the code inplace just incase they want it back.
									// The form color key has been turned invisible so it
									// doesn't show.  The grid cell is still in place too

									cellcolor = modAdminCommon.NoColor;

									grdAircraft.CurrentColumnIndex++;
									grdAircraft.SetColumnWidth(grdAircraft.CurrentColumnIndex, 27);
									grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));

								}
								TotFound++;

							}
							else
							{

								grdAircraft.CellBackColor = SystemColors.Control;
								for (int i = 1; i <= 5; i++)
								{
									grdAircraft.CurrentColumnIndex++;
									grdAircraft.CellBackColor = SystemColors.Control;
								}

							}

							TempACID = ($"{Convert.ToString(snp_AircraftList["AC_ID"])}").Trim();
							if (chkCompanyFlag.CheckState == CheckState.Checked)
							{

								grdAircraft.CurrentColumnIndex++;
								grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(CompanyCellColor)));

								CompAddress = new StringBuilder($"{($"{Convert.ToString(snp_AircraftList["actype_name"])}").Trim()}: {($"{Convert.ToString(snp_AircraftList["comp_name"])}").Trim()}");
								if (Strings.Len(($"{Convert.ToString(snp_AircraftList["Comp_city"])}").Trim()) > 0)
								{
									CompAddress.Append($" - {($"{Convert.ToString(snp_AircraftList["Comp_city"])}").Trim()}");
								}
								if (Strings.Len(($"{Convert.ToString(snp_AircraftList["comp_state"])}").Trim()) > 0)
								{
									CompAddress.Append($", {($"{Convert.ToString(snp_AircraftList["comp_state"])}").Trim()}");
								}
								grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = CompAddress.ToString();

								if (Strings.Len(grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].FormattedValue.ToString()) > 55)
								{
									grdAircraft.SetRowHeight(grdAircraft.CurrentRowIndex, 40);
								}

								if (($"{Convert.ToString(snp_AircraftList["ac_exclusive_flag"])}").Trim() == "Y")
								{
									cellcolor = modAdminCommon.ExclusiveColor;
								}
								else
								{
									cellcolor = modAdminCommon.NoColor;
								}
								grdAircraft.CurrentColumnIndex++;
								grdAircraft.SetColumnWidth(grdAircraft.CurrentColumnIndex, 27);
								grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));

								if (($"{Convert.ToString(snp_AircraftList["ac_lease_flag"])}").Trim() == "Y")
								{
									cellcolor = modAdminCommon.LeaseColor;
								}
								else
								{
									cellcolor = modAdminCommon.NoColor;
								}
								grdAircraft.CurrentColumnIndex++;
								grdAircraft.SetColumnWidth(grdAircraft.CurrentColumnIndex, 27);
								grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));

								if (($"{Convert.ToString(snp_AircraftList["amod_class_code"])}").Trim() == "A")
								{
									cellcolor = (0xFFFFC0).ToString();
								}
								else
								{
									cellcolor = modAdminCommon.NoColor;
									if (Convert.ToString(snp_AircraftList["amod_airframe_type_code"]) == "R" && Convert.ToString(snp_AircraftList["amod_class_code"]) == "C")
									{
										cellcolor = (0x8000000F).ToString(); //grey
									}
									if (Convert.ToString(snp_AircraftList["amod_airframe_type_code"]) == "R" && Convert.ToString(snp_AircraftList["amod_class_code"]) == "B")
									{
										cellcolor = (0xFF80FF).ToString(); //purple
									}
								}
								grdAircraft.CurrentColumnIndex++;
								grdAircraft.SetColumnWidth(grdAircraft.CurrentColumnIndex, 27);
								grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));

							} // If chkCompanyFlag = vbChecked Then

							// ***********************************
							// DISPLAY AIRCRAFT LOCATION


							strLocation = new StringBuilder(($"{Convert.ToString(snp_AircraftList["ac_aport_country"])}").Trim());
							if (Strings.Len(strLocation.ToString().Trim()) > 0)
							{
								strLocation.Append($",{($"{Convert.ToString(snp_AircraftList["ac_aport_state"])}").Trim()}");
							}
							else
							{
								strLocation = new StringBuilder(($"{Convert.ToString(snp_AircraftList["ac_aport_state"])}").Trim());
							}
							grdAircraft.CurrentColumnIndex++;
							grdAircraft.SetColumnWidth(grdAircraft.CurrentColumnIndex, 160);
							grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = strLocation.ToString();

							grdAircraft.CurrentColumnIndex++;
							grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							if (($"{Convert.ToString(snp_AircraftList["ac_previously_owned_flag"])}").Trim() == "Y")
							{
								grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "Y";
							}
							else
							{
								grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "N";
							}

							grdAircraft.set_RowData(grdAircraft.CurrentRowIndex, Convert.ToInt32(snp_AircraftList["ac_id"]));

							if (chkTransactions.CheckState == CheckState.Checked || Conversion.Val(txt_Journ_id.Text.Trim()) > 0)
							{
								//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grdAircraft.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								grdAircraft.setBandData(Convert.ToInt32(snp_AircraftList["ac_journ_id"]), grdAircraft.CurrentRowIndex);
							}
							else
							{
								//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grdAircraft.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								grdAircraft.setBandData(0, grdAircraft.CurrentRowIndex);
							}

							grdAircraft.RowsCount++;
							grdAircraft.CurrentRowIndex++;
							grdAircraft.CurrentColumnIndex = 0;
							lbl_Totfound.Text = $"{StringsHelper.Format(TotFound, "##,##0")} Aircraft Found";

							if (mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value + 1 <= mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Maximum)
							{
								mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value = Convert.ToInt32(mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value + 1);
							}

							snp_AircraftList.MoveNext();
							Application.DoEvents();

							// 11/06/2013 - By David D. Cruger
							// When the Grid first page fills up
							// Display results to this point, refresh
							// but then disable redraw until grid has
							// completely finished loading

							lCnt1++;
							if (lCnt1 == 28)
							{
								grdAircraft.Visible = true;
								grdAircraft.Enabled = true;
								grdAircraft.Redraw = true;
								Application.DoEvents();
								grdAircraft.Enabled = false;
								grdAircraft.Redraw = false;
							}

						}; // Do While Not snp_AircraftList.EOF

						cmdStop.Visible = false;
						cmdAircraftListExcelExport.Visible = true;

						if (grdAircraft.RowsCount > 3)
						{
							grdAircraft.RemoveItem(grdAircraft.RowsCount - 1);
							grdAircraft.RemoveItem(grdAircraft.RowsCount - 1);
						}
						else if (grdAircraft.RowsCount > 2)
						{ 
							grdAircraft.RemoveItem(grdAircraft.RowsCount - 1);
						}

						grdAircraft.Enabled = true;

					}

					lbl_Totfound.Text = $"{StringsHelper.Format(TotFound, "##,##0")} Aircraft Found";
					strMsg = $"{strMsg} - {lbl_Totfound.Text}";

					if (TotFound == 0 && !Stopped)
					{
						MessageBox.Show($"No Records Found with the Current Search Criteria.{Environment.NewLine}{Environment.NewLine}Please reduce the criteria and try again.", "Find Aircraft", MessageBoxButtons.OK, MessageBoxIcon.Information);
						SSTabHelper.SetSelectedIndex(Tabs1, 0);
					}

				}
				else
				{
					SSTabHelper.SetSelectedIndex(Tabs1, 0);
					grdAircraft.Enabled = false;
				} // If Not (snp_AircraftList.BOF And snp_AircraftList.EOF) Then

				grdAircraft.CurrentRowIndex = 0;
				grdAircraft.CurrentColumnIndex = 0;

				grdAircraft.Visible = true;
				grdAircraft.Redraw = true;

				cmd_SelectAircraft.Visible = false;
				mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Visible = false;

				modCommon.End_Activity_Monitor_Message("Aircraft Search", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

				frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

				if ((!ComingBack) && (ComingFrom.ToLower() != "newpub"))
				{
					if (GotTotal == 1 && chkDontJumpToAircraft.CheckState == CheckState.Unchecked && !is_from_company)
					{
						if (!Selected)
						{
							this.Cursor = Cursors.WaitCursor;
							grdAircraft.CurrentColumnIndex = 1;
							grdAircraft.CurrentRowIndex = 1;
							modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Aircraft Record, Please Wait", Color.Blue);
							Select_Aircraft();
						}
					}

					if (grdAircraft.RowsCount > 1)
					{
						grdAircraft.CurrentColumnIndex = 0;
						grdAircraft.CurrentRowIndex = 1;
					}

				}
				else
				{
					if (RememberWhichRow < grdAircraft.RowsCount && RememberWhichRow != 0)
					{
						grdAircraft.CurrentRowIndex = RememberWhichRow;
						grdAircraft.FirstDisplayedScrollingRowIndex = RememberWhichRow;
						grdAircraft.CurrentColumnIndex = 0;
						grdAircraft.ColSel = grdAircraft.ColumnsCount - 1;

					}
					else
					{
						if (grdAircraft.RowsCount > 1)
						{
							grdAircraft.CurrentColumnIndex = 0;
							grdAircraft.CurrentRowIndex = 1;
						}
					}
					ComingBack = false;
				}

				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
			}
			catch (Exception excep)
			{
				if (!FillAircraftError)
				{
					throw excep;
				}

				if (FillAircraftError)
				{


					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					if (Information.Err().Number == 3146)
					{
						MessageBox.Show($"There are too many records to display.{Environment.NewLine}{Environment.NewLine}Please refine your search criteria and try again.", "Find Aircraft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						SSTabHelper.SetSelectedIndex(Tabs1, 0);
						this.Cursor = CursorHelper.CursorDefault;
						HadHourglass = false;
						return;
					}
					else
					{
						//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						MessageBox.Show($"Fill Aircraft Grid Error List ({Information.Err().Number.ToString()}) {excep.Message}", "Find Aircraft", MessageBoxButtons.OK, MessageBoxIcon.Error);
						this.Cursor = CursorHelper.CursorDefault;
						HadHourglass = false;
						return;
					}


				}
			}

		}

		public object Select_Aircraft()
		{

			try
			{

				Selected = true;

				modAdminCommon.gbl_Aircraft_ID = grdAircraft.get_RowData(grdAircraft.CurrentRowIndex);
				modAdminCommon.gbl_Aircraft_Journal_ID = 0;

				//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grdAircraft.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (grdAircraft.BandData(grdAircraft.CurrentRowIndex) > 0)
				{
					//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grdAircraft.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					modAdminCommon.gbl_Aircraft_Journal_ID = grdAircraft.BandData(grdAircraft.CurrentRowIndex);
				}

				//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grdAircraft.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (chkTransactions.CheckState == CheckState.Checked && grdAircraft.BandData(grdAircraft.CurrentRowIndex) > 0)
				{
					//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grdAircraft.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					modAdminCommon.gbl_Aircraft_Journal_ID = grdAircraft.BandData(grdAircraft.CurrentRowIndex);
				}

				frm_aircraft.DefInstance.Form_Initialize();
				frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
				frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
				frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
				frm_aircraft.DefInstance.Reference_Company_ID = 0;
				frm_aircraft.DefInstance.Show();
				//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

				Selected = false;
			}
			catch (System.Exception excep)
			{

				Selected = false;
				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Select_Aircraft_From_List_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_AircraftList(SELECT)");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return null;
			}

			return null;
		}

		private void Form_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) System.Windows.Forms.Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (HadHourglass)
			{
				this.Cursor = Cursors.WaitCursor;
			}

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			ComingFrom = "";
			snp_AircraftList = null;

		}

		private void grdAircraft_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			this.Cursor = Cursors.WaitCursor;

			RememberWhichRow = grdAircraft.CurrentRowIndex;

			if (grdAircraft.MouseRow > 0)
			{


				if (is_from_company)
				{


				}
				else if (grdAircraft.CurrentColumnIndex < colCompany || chkCompanyFlag.CheckState == CheckState.Unchecked)
				{  //   If grdAircraft.row > 0 Then
					if (!Selected)
					{
						Select_Aircraft();
					}
				}
				else
				{
					Select_Company();
				}

				grdAircraft.CurrentColumnIndex = 0;
				grdAircraft.ColSel = grdAircraft.ColumnsCount - 1;

			}
			else
			{

				int switchVar = grdAircraft.MouseCol;
				if (switchVar == colMake)
				{

					str_Orderby = " ORDER BY amod_make_name,amod_model_name,ac_ser_no_sort";

				}
				else if (switchVar == colModel)
				{ 

					str_Orderby = " ORDER BY amod_model_name,ac_ser_no_sort";

				}
				else if (switchVar == colSerial)
				{ 

					str_Orderby = " ORDER BY ac_ser_no_sort";

				}
				else if (switchVar == colRegistration)
				{ 

					str_Orderby = " ORDER BY ac_reg_no,ac_ser_no_sort";

				}
				else if (switchVar == colYear)
				{ 

					str_Orderby = " ORDER BY ac_year,ac_ser_no_sort";

				}
				else if (switchVar == colCompany)
				{ 
					str_Orderby = " ORDER BY comp_name";

				}
				else if (switchVar == colACLocation)
				{ 
					str_Orderby = " ORDER BY ac_aport_country,ac_aport_state";
				}

				Fill_Aircraft_Grid();

			}

			this.Cursor = CursorHelper.CursorDefault;
			HadHourglass = false;

		}

		private void grdAircraft_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) System.Windows.Forms.Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (is_from_company)
			{
				cmd_pick_Ac.Visible = true;
			}
		}


		private void grdAircraft_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) System.Windows.Forms.Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (HadHourglass)
			{
				this.Cursor = Cursors.WaitCursor;
			}

		}

		private void lblEngineModel_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			lblEngineModel.Enabled = false;
			FillEngineModel();
			lblEngineModel.Enabled = true;
		}

		private void lblJournalCategory_Click(Object eventSender, EventArgs eventArgs)
		{
			lblJournalCategory.Enabled = false;
			Fill_Journal_Category();
			lblJournalCategory.Enabled = true;
		}

		private void lst_Area_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			Set_DemographicList();
			Fill_AC_Country_List();
		}

		private void lst_CompanyArea_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			Set_Company_Demographics();
			Fill_Company_Country_List();
			if (!ListBoxHelper.GetSelected(lst_CompanyArea, 0))
			{
				Clear_TimeZone();
			}
			else
			{
				modFillAircraftControls.Fill_TimeZoneList_FromArray(lstCompanyTimeZone);
			}
		}

		private void lst_Country_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			Set_DemographicList();
			Fill_AC_State_List();
		}

		private void lst_State_SelectedIndexChanged(Object eventSender, EventArgs eventArgs) => Set_DemographicList();


		private void lstCompanyCountry_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			Set_Company_Demographics();
			Fill_Company_State_List();

			if (!ListBoxHelper.GetSelected(lstCompanyCountry, 0))
			{
				Clear_TimeZone();
			}
			else
			{
				modFillAircraftControls.Fill_TimeZoneList_FromArray(lstCompanyTimeZone);
			}

		}

		private void lstCompanyState_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (!ListBoxHelper.GetSelected(lstCompanyState, 0))
			{
				Clear_TimeZone();
			}
			else
			{
				modFillAircraftControls.Fill_TimeZoneList_FromArray(lstCompanyTimeZone);
			}

			Set_Company_Demographics();
		}

		private void lstMake_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (lstMake.Enabled)
			{

				FillModelList();
				FillEngineModel(lstMake.Text);

				ToolTipMain.SetToolTip(lstMake, lstMake.Text); //aey 2/25/05

			} // If lstMake.Enabled = True Then

		}

		private void lstModel_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (lstModel.Enabled)
			{

				if (lstMake.Text != "All")
				{
					FillEngineModel(lstMake.Text, lstModel.Text);
				}
				else
				{
					FillEngineModel("", lstModel.Text);
				}

				ToolTipMain.SetToolTip(lstModel, lstModel.Text); //aey 2/25/05

			} // If lstModel.Enabled = True Then

		}

		private void lstType_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			int K = 0;
			int K2 = 0;
			string tmp = "";
			string tmp2 = "";

			if (lstType.Enabled)
			{

				ToolTipMain.SetToolTip(lstType, lstType.Text);

				lstModel.Items.Clear();
				FillMakeList();
				FillModelList();

				if (ListBoxHelper.GetSelectedIndex(lstType) > 0)
				{
					K = lstType.GetItemData(ListBoxHelper.GetSelectedIndex(lstType));
					if (K > 0)
					{
						K2 = Convert.ToInt32(Math.Floor(K / 100d) * 100);
						tmp = Strings.Chr(Convert.ToInt32(Math.Floor(K / 100d))).ToString();
						tmp2 = Strings.Chr(K - K2).ToString();
					}
					FillWeightClass(tmp2);
				}
				else
				{
					FillWeightClass();
				}

				ToolTipMain.SetToolTip(lstType, lstType.Text); //aey 2/25/05

			} // If lstType.Enabled = True Then

		} // lstType_Click

		public void mnuAircraftListShowUserHistory_Click(Object eventSender, EventArgs eventArgs)
		{

			if (frm_Main_Menu.DefInstance.mnuShowUserHistory.Text == "Show User History")
			{
				frm_UserHistory.DefInstance.Refresh_User_History_Grids("All");
				mnuAircraftListShowUserHistory.Text = "Hide User History";
				frm_Main_Menu.DefInstance.mnuShowUserHistory.Text = "Hide User History";
				modCommon.CenterFormOnHomebaseMainForm(frm_UserHistory.DefInstance);
				frm_UserHistory.DefInstance.Show();
			}
			else
			{
				frm_UserHistory.DefInstance.TimerOff();
				mnuAircraftListShowUserHistory.Text = "Show User History";
				frm_Main_Menu.DefInstance.mnuShowUserHistory.Text = "Show User History";
				frm_UserHistory.DefInstance.Hide();
			}

		}

		public void mnuFileClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		public void mnuFileLogout_Click(Object eventSender, EventArgs eventArgs) => frm_Main_Menu.DefInstance.Close();


		public void mnuFractional_Click(Object eventSender, EventArgs eventArgs) => frm_Fractional.DefInstance.Show();


		public void mnureport_Click(Object eventSender, EventArgs eventArgs)
		{


			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_WebReport.DefInstance);

			BuildQuery();
			string NewQuery = $"AND {modAdminCommon.gbl_Search.Substring(Math.Max(modAdminCommon.gbl_Search.Length - (Strings.Len(modAdminCommon.gbl_Search) - (modAdminCommon.gbl_Search.ToUpper().IndexOf("WHERE") + 1) - 5), 0))}";

			frm_WebReport.DefInstance.WhichReport = "Aircraft List";
			frm_WebReport.DefInstance.PassedWhereClause = NewQuery;
			frm_WebReport.DefInstance.Show();

		}

		private bool isInitializingComponent;
		private void opt_CompanyContinent_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				if (opt_CompanyContinent.Enabled)
				{
					Fill_Company_Demographics();
				}
			}
		}

		private void opt_CompanyRegion_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				if (opt_CompanyRegion.Enabled)
				{
					Fill_Company_Demographics();
				}
			}
		}

		private void opt_Continent_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				if (opt_Continent.Enabled)
				{
					Fill_Demographics();
				}
			}
		}

		private void opt_Region_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				if (opt_Region.Enabled)
				{
					Fill_Demographics();
				}
			}
		}

		private void optAll_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				cbo_ac_asking.Visible = false;
				lbl_asking.Visible = false;


				modFillAircraftControls.Fill_Aircraft_Status_List(txt_ac_status, 11);




				cbo_ac_delivery.Visible = false;
				lbl_delivery.Visible = false;

			}
		}

		private void optForSale_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				cbo_ac_asking.SelectedIndex = 0;
				cbo_ac_asking.Visible = true;
				lbl_asking.Visible = true;

				cbo_ac_delivery.SelectedIndex = 0;
				cbo_ac_delivery.Visible = true;
				lbl_delivery.Visible = true;

				if (optForSale.Checked)
				{
					modFillAircraftControls.Fill_Aircraft_Status_List(txt_ac_status, 1);
					txt_ac_status.AddItem("");
					txt_ac_status.Text = "";
				}



			}
		}

		//UPGRADE_NOTE: (7001) The following declaration (Option2_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Option2_Click()
		//{
			//
		//}

		private void optNotForSale_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				cbo_ac_asking.Visible = false;
				lbl_asking.Visible = false;

				cbo_ac_delivery.Visible = false;
				lbl_delivery.Visible = false;

				if (optNotForSale.Checked)
				{
					modFillAircraftControls.Fill_Aircraft_Status_List(txt_ac_status, 0);
					txt_ac_status.AddItem("");
					txt_ac_status.Text = "";
				}

			}
		}

		private void pnl_Clst_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) System.Windows.Forms.Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (HadHourglass)
			{
				this.Cursor = Cursors.WaitCursor;
			}

		}

		private void Tabs1_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (Tabs1PreviousTab == 0)
			{

				// always clear and hide the search grid as soon as entering the tab
				cmdAircraftListExcelExport.PerformClick();
				grdAircraft.Enabled = false;
				grdAircraft.Clear();

				if (!AlreadyLoadedList)
				{
					ExactSerial = true;
					Set_DemographicList();
					BuildQuery();

					if (SomethingSelected || SerialNumberSelected)
					{

						txt_gen[0].Visible = chkCompanyFlag.CheckState == CheckState.Checked;

						search_on("Aircraft Search In Progress ....");
						Fill_Aircraft_Grid();

					}
					else
					{
						MessageBox.Show("This Search would return too many records. You must select something to search for.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						SSTabHelper.SetSelectedIndex(Tabs1, 0);
					}

				}
				else
				{

					AlreadyLoadedList = false;
					grdAircraft.Redraw = true;

				}
			}
			else
			{
				AlreadyLoadedList = false;
				Stopped = true; //aey 9/8/04
			}

			search_off();

			Tabs1PreviousTab = Tabs1.SelectedIndex;
		}

		private void BuildQuery()
		{

			string[] ArrEng = null;
			string tmpSerialSort = "";
			string[] serArray = null;
			StringBuilder tmp = new StringBuilder(); //aey 3/24/05
			string tmp2 = "";
			int K = 0;
			int K2 = 0;
			string strSerArrayI = "";

			SomethingSelected = false;
			string ModelsSelected = "";
			bool MakeSelected = false;
			string TempString = "";
			string Separator = "";

			modAdminCommon.gbl_Search = "SELECT ac_status, ac_forsale_flag, ac_asking, ac_asking_price, ac_delivery, ac_delivery_date, ac_list_date, ac_ser_no,ac_ser_no_full, ac_ser_no_sort, ac_reg_no, ac_year,ac_id, ac_exclusive_flag, ac_lease_flag, amod_make_name, amod_model_name, ac_aport_state, ac_aport_country,amod_class_code,ac_previously_owned_flag, ac_alt_ser_no_full , ac_prev_reg_no, amod_airframe_type_code ";
			if (chkCompanyFlag.CheckState == CheckState.Checked)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}, Company.*, Aircraft_Reference.*, Aircraft_Contact_Type.*";
			}

			if (chkTransactions.CheckState == CheckState.Checked || Conversion.Val($"{txt_Journ_id.Text}") > 0)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}, ac_journ_id ";
			}

			modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} FROM Aircraft WITH(NOLOCK), Aircraft_Model WITH(NOLOCK)";

			if (chkCompanyFlag.CheckState == CheckState.Checked)
			{
				if (cboBusinessType.SelectedIndex > 0)
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}, Company WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK), Aircraft_Contact_Type WITH(NOLOCK), Business_Type_Reference WITH(NOLOCK)";
				}
				else
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}, Company WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK), Aircraft_Contact_Type WITH(NOLOCK)";
				}
				if (chkTransactions.CheckState == CheckState.Checked)
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}, Journal WITH(NOLOCK)";
				}
			}

			if (chkTransactions.CheckState == CheckState.Checked && Conversion.Val($"{txt_Journ_id.Text}") == 0)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} WHERE amod_id = ac_amod_id AND ac_journ_id >= 0 ";
			}
			else
			{
				if (Conversion.Val($"{txt_Journ_id.Text}") == 0)
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} WHERE amod_id = ac_amod_id AND ac_journ_id = 0 ";
				}
				else
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} WHERE amod_id = ac_amod_id AND ac_journ_id ={Conversion.Val($"{txt_Journ_id.Text}").ToString()} ";
				}
			}

			if (chkCompanyFlag.CheckState == CheckState.Checked)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND (ac_id = cref_ac_id and ac_journ_id = cref_journ_id) "; // join aircraft to aircrafgt reference
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND (cref_comp_id = comp_id and cref_journ_id = comp_journ_id) "; //join aircraft reference to company
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND cref_contact_type = actype_code "; //join aircraft reference to aircraft contact type
				if (cboBusinessType.SelectedIndex > 0)
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND bustypref_comp_id = comp_id AND bustypref_journ_id = comp_journ_id ";
				}
				if (chkTransactions.CheckState == CheckState.Checked)
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND journ_id=cref_journ_id "; //join journal table
				}

			}
			//'''''''''''''''''''''''''''''''''''''
			// Product Code Info
			//'''''''''''''''''''''''''''''''''''''
			// business
			if (chk_bx_product_codes[0].Checked)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_product_business_flag = 'Y'";
			}
			// Helicopters
			if (chk_bx_product_codes[3].Checked)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_product_helicopter_flag = 'Y'";
			}
			//Commercial
			if (chk_bx_product_codes[2].Checked)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_product_commercial_flag = 'Y'";
			}
			if (lstModel.SelectedItems.Count > 0)
			{ //aey 3/24/05

				if (!ListBoxHelper.GetSelected(lstModel, 0))
				{

					//         gbl_Search = gbl_Search & "and amod_model_name IN ("
					//         For I = 0 To lstModel.ListCount - 1
					//            If lstModel.Selected(I) Then
					//               gbl_Search = gbl_Search & "'" & lstModel.List(I) & "',"
					//               SomethingSelected = True
					//            End If
					//         Next I
					//aey 3/24/05
					//         gbl_Search = gbl_Search & "and (amod_id IN ("
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}and ( ";
					int tempForEndVar = lstModel.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						if (ListBoxHelper.GetSelected(lstModel, i))
						{
							ModelsSelected = $"{ModelsSelected}{lstModel.GetListItem(i).Substring(Math.Min(1, lstModel.GetListItem(i).Length), Math.Min(2, Math.Max(0, lstModel.GetListItem(i).Length - 1)))},";
							// gbl_Search = gbl_Search & "" & lstModel.ItemData(I) & ","
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} (amod_id = {lstModel.GetItemData(i).ToString()} ";
							//tmp = Mid(lstModel.List(I), 6, 1) 'use code
							//If tmp <> "]" Then
							//  gbl_Search = gbl_Search & " and ac_use_code ='" & tmp & "') or "
							//Else
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}) or ";
							//End If
							//amod_id IN ("
							SomethingSelected = true;
							// ModelSelected = True
						}
					}

					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search.Substring(0, Math.Min(Strings.Len(modAdminCommon.gbl_Search) - 3, modAdminCommon.gbl_Search.Length))} ) ";
				}
			}

			if (lstMake.SelectedItems.Count > 0)
			{

				if (!ListBoxHelper.GetSelected(lstMake, 0))
				{

					//         gbl_Search = gbl_Search & "AND amod_make_name IN ("
					//         For I = 0 To lstMake.ListCount - 1
					//            If lstMake.Selected(I) Then
					//               gbl_Search = gbl_Search & "'" & lstMake.List(I) & "',"
					//               SomethingSelected = True
					//            End If
					//         Next I
					//aey 3/24/05
					//            gbl_Search = gbl_Search & "AND amod_make_abbrev IN ("
					//            For I = 0 To lstMake.ListCount - 1
					//               If lstMake.Selected(I) Then
					//                  K = lstMake.ItemData(I)
					//                  If K > 0 Then
					//                     K2 = Int(K / 100) * 100
					//                     tmp = Chr(Int(K / 100))
					//                     tmp = tmp & Chr(K - K2)
					//                     gbl_Search = gbl_Search & "'" & tmp & "',"
					//                     SomethingSelected = True
					//                     MakeSelected = True
					//                  End If
					//               End If
					//            Next I
					//gbl_Search = gbl_Search & "AND amod_make_abbrev IN ("
					if (Strings.Len(ModelsSelected) > 0)
					{
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} or ( ";
					}
					else
					{
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} and ( ";
					}

					int tempForEndVar2 = lstMake.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar2; i++)
					{
						if (ListBoxHelper.GetSelected(lstMake, i))
						{
							K = lstMake.GetItemData(i);
							if (K > 0)
							{
								K2 = Convert.ToInt32(Math.Floor(K / 100d) * 100);
								tmp = new StringBuilder(Strings.Chr(Convert.ToInt32(Math.Floor(K / 100d))).ToString());
								tmp.Append(Strings.Chr(K - K2).ToString());
								//has model been selected for this make?
								if ((ModelsSelected.IndexOf($"{tmp.ToString()},") + 1) == 0)
								{
									MakeSelected = true;
									modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} (amod_make_abbrev = '{tmp.ToString()}' ";
									if (cboAirframeTypeCode.SelectedIndex == 0)
									{
										modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}and  amod_type_code='{lstMake.GetListItem(i).Substring(Math.Min(2, lstMake.GetListItem(i).Length), Math.Min(1, Math.Max(0, lstMake.GetListItem(i).Length - 2)))}')   or ";
									}
									else
									{
										modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}and  amod_type_code='{lstMake.GetListItem(i).Substring(Math.Min(1, lstMake.GetListItem(i).Length), Math.Min(1, Math.Max(0, lstMake.GetListItem(i).Length - 1)))}')   or ";
									}
									SomethingSelected = true;
								}

								// MakeSelected = True
							}
						}
					}
					//         gbl_Search = left$(gbl_Search, Len(gbl_Search) - 1) & ") "
					if (!MakeSelected)
					{
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search.Substring(0, Math.Min(Strings.Len(modAdminCommon.gbl_Search) - 5, modAdminCommon.gbl_Search.Length))}  ";
					}
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search.Substring(0, Math.Min(Strings.Len(modAdminCommon.gbl_Search) - 3, modAdminCommon.gbl_Search.Length))}  ";
					if (MakeSelected)
					{
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}) ";
					}
				}

			}

			//    If lstModel.SelCount > 0 And lstModel.Selected(0) = False Then
			//         gbl_Search = gbl_Search & ") "
			//    End If

			if (lstType.SelectedItems.Count > 0)
			{
				//And ModelSelected = False And MakeSelected = False Then

				if (!ListBoxHelper.GetSelected(lstType, 0))
				{

					//   gbl_Search = gbl_Search & "AND amod_type_code IN ("
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND (";
					int tempForEndVar3 = lstType.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar3; i++)
					{
						if (ListBoxHelper.GetSelected(lstType, i))
						{
							tmp = new StringBuilder("");
							K = lstType.GetItemData(i);
							if (K > 0)
							{
								K2 = Convert.ToInt32(Math.Floor(K / 100d) * 100);
								tmp = new StringBuilder(Strings.Chr(Convert.ToInt32(Math.Floor(K / 100d))).ToString());
								tmp2 = Strings.Chr(K - K2).ToString();
							}
							//              gbl_Search = gbl_Search & "'" & Chr(lstType.ItemData(I)) & "',"
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} (amod_type_code = '{tmp2}' ";
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} and amod_airframe_type_code ='{tmp.ToString()}') or ";

							SomethingSelected = true;
						}
					}
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search.Substring(0, Math.Min(Strings.Len(modAdminCommon.gbl_Search) - 3, modAdminCommon.gbl_Search.Length))}) ";

				}

			}


			if (chk_prev.CheckState == CheckState.Unchecked && Strings.Len(txtRegNo.Text.Trim()) > 0)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND (ac_reg_no LIKE '{StringsHelper.Replace(txtRegNo.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%') ";
				SomethingSelected = true;
			}
			else if (chk_prev.CheckState == CheckState.Checked && Strings.Len(txtRegNo.Text.Trim()) > 0)
			{ 
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND (ac_reg_no LIKE '{StringsHelper.Replace(txtRegNo.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%' OR ac_prev_reg_no LIKE '{StringsHelper.Replace(txtRegNo.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%') ";
				SomethingSelected = true;
			}

			SerialNumberSelected = false;
			string tmpSerialNo = "";
			StringBuilder tmpSerialFront = new StringBuilder();
			string tmpSerialBack = "";
			StringBuilder tmpSerialSuffix = new StringBuilder();

			if (chkSerNbrExact.CheckState == CheckState.Unchecked)
			{

				SerialNumberSelected = true;

				if (Strings.Len(txtSerialNoFrom.Text.Trim()) > 0 && Strings.Len(txtSerialNoTo.Text.Trim()) > 0)
				{

					if (Information.IsNumeric(txtSerialNoFrom.Text.Trim()) && Information.IsNumeric(txtSerialNoTo.Text.Trim()))
					{

						// 04/02/2004 - By David D. Cruger; Added ac_alt_ser_no_value
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ((ac_ser_no_value BETWEEN {txtSerialNoFrom.Text.Trim()} AND {txtSerialNoTo.Text.Trim()}) ";
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (ac_alt_ser_no_value BETWEEN {txtSerialNoFrom.Text.Trim()} AND {txtSerialNoTo.Text.Trim()})) ";

					}
					else
					{
						// Do an Alpha Search

						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ((ac_ser_no BETWEEN '{txtSerialNoFrom.Text.Trim()}' AND '{txtSerialNoTo.Text.Trim()}') ";
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (ac_ser_no_full BETWEEN '{txtSerialNoFrom.Text.Trim()}' AND '{txtSerialNoTo.Text.Trim()}') ";
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (ac_alt_ser_no BETWEEN '{txtSerialNoFrom.Text.Trim()}' AND '{txtSerialNoTo.Text.Trim()}') ";
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (ac_alt_ser_no_full BETWEEN '{txtSerialNoFrom.Text.Trim()}' AND '{txtSerialNoTo.Text.Trim()}')) ";

					}

				}
				else if (txtSerialNoFrom.Text.Trim() != "")
				{ 
					tmpSerialNo = txtSerialNoFrom.Text.Trim();
				}
				else if (txtSerialNoTo.Text.Trim() != "")
				{ 
					tmpSerialNo = txtSerialNoTo.Text.Trim();
				} // If Len(Trim(txtSerialNoFrom)) > 0 And Len(Trim(txtSerialNoTo)) > 0 Then

				if (tmpSerialNo != "")
				{

					K = (tmpSerialNo.IndexOf(':') + 1) + (tmpSerialNo.IndexOf(';') + 1);

					//if not range, parse into prefix-number-suffix : Alpha-Num-Alpha pattern
					if (K == 0)
					{ //not valid for ANAN or N-N or N-A pattern
						if (!IsNumber(tmpSerialNo.Substring(Math.Min(0, tmpSerialNo.Length), Math.Min(1, Math.Max(0, tmpSerialNo.Length)))))
						{ //starts with non-number
							int tempForEndVar4 = Strings.Len(tmpSerialNo);
							for (int i = 1; i <= tempForEndVar4; i++)
							{
								if (!IsNumber(tmpSerialNo.Substring(Math.Min(i - 1, tmpSerialNo.Length), Math.Min(1, Math.Max(0, tmpSerialNo.Length - (i - 1))))) && Strings.Len(tmpSerialBack) == 0)
								{
									tmpSerialFront.Append(tmpSerialNo.Substring(Math.Min(i - 1, tmpSerialNo.Length), Math.Min(1, Math.Max(0, tmpSerialNo.Length - (i - 1)))));
								}
								else if (!IsNumber(tmpSerialNo.Substring(Math.Min(i - 1, tmpSerialNo.Length), Math.Min(1, Math.Max(0, tmpSerialNo.Length - (i - 1))))) && Strings.Len(tmpSerialBack) > 0)
								{ 
									tmpSerialSuffix.Append(tmpSerialNo.Substring(Math.Min(i - 1, tmpSerialNo.Length), Math.Min(1, Math.Max(0, tmpSerialNo.Length - (i - 1)))));
								}
								else if (IsNumber(tmpSerialNo.Substring(Math.Min(i - 1, tmpSerialNo.Length), Math.Min(1, Math.Max(0, tmpSerialNo.Length - (i - 1))))))
								{ 
									tmpSerialBack = $"{tmpSerialBack}{tmpSerialNo.Substring(Math.Min(i - 1, tmpSerialNo.Length), Math.Min(1, Math.Max(0, tmpSerialNo.Length - (i - 1))))}";
								}
							}
						}
						else
						{
							K = (tmpSerialNo.IndexOf('-') + 1);
							if (K > 0)
							{
								tmpSerialFront = new StringBuilder(tmpSerialNo.Substring(Math.Min(0, tmpSerialNo.Length), Math.Min(K - 1, Math.Max(0, tmpSerialNo.Length))));
								tmpSerialBack = tmpSerialNo.Substring(Math.Min(K, tmpSerialNo.Length));
							}
						}
					}
					tmpSerialNo = StringsHelper.Replace(tmpSerialNo, ";", ",", 1, -1, CompareMethod.Binary);
					tmpSerialNo = StringsHelper.Replace(tmpSerialNo, ":", ",", 1, -1, CompareMethod.Binary);

					serArray = tmpSerialNo.Split(',');
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND (";
					Separator = "";

					// 04/02/2004 - By David D. Cruger
					// Added the ac_alt_ser_no_value searching

					int tempForEndVar5 = serArray.GetUpperBound(0);
					for (int i = 0; i <= tempForEndVar5; i++)
					{

						strSerArrayI = ($"{serArray[i]} ").Trim();

						// 04/05/2004 - By David D. Cruger
						// Must use IsNumber instead of IsNumeric
						// 25D-279 will return TRUE with IsNumeric
						if (IsNumber(strSerArrayI))
						{
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}{Separator} (ac_ser_no_full = '{strSerArrayI}') ";
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (ac_ser_no = '{strSerArrayI}') ";
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (ac_ser_no_value = {strSerArrayI}) ";

							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (ac_alt_ser_no_full = '{strSerArrayI}') ";
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (ac_alt_ser_no = '{strSerArrayI}') ";
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (ac_alt_ser_no_value = {strSerArrayI}) ";
						}
						else
						{
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}{Separator} (ac_ser_no_full = '{strSerArrayI}') ";
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (dbo.LeaveAlphaAndNumeric(ac_ser_no_full) = '{modCommon.LeaveOnlyAlphaAndNumeric(strSerArrayI)} ') ";
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (ac_ser_no = '{strSerArrayI}') ";

							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (ac_alt_ser_no_full = '{strSerArrayI}') ";
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (dbo.LeaveAlphaAndNumeric(ac_alt_ser_no_full) = '{modCommon.LeaveOnlyAlphaAndNumeric(strSerArrayI)} ') ";
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}OR (ac_alt_ser_no = '{strSerArrayI}') ";
						}

						//simulate a serialSearch field 8/18/05 aey
						if (Strings.Len($"{tmpSerialFront.ToString()}") > 0 && Strings.Len($"{tmpSerialBack}") > 0)
						{
							tmpSerialSort = modCommon.Format_Ser_No_Sort(tmpSerialFront.ToString().ToUpper(), tmpSerialBack, tmpSerialSuffix.ToString().ToUpper(), cboAirframeTypeCode.Text);
							//gbl_Search = gbl_Search & " or (ac_ser_no_sort = '" & tmpSerialSort & "' or ac_alt_ser_no_sort = '" & tmpSerialSort & "' ) "
						}

						Separator = " OR ";

					} // I

					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}) ";

				} // If Len(Trim(txtSerialNoFrom)) > 0 And Len(Trim(txtSerialNoTo)) > 0 Then

			}
			else
			{
				// 02/06/2012 - By David D. Cruger; Exact Match
				if (($"{txtSerialNoFrom.Text} ").Trim() != "")
				{
					SerialNumberSelected = true;
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ( ";
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}        (ac_ser_no_full = '{($"{txtSerialNoFrom.Text} ").Trim()}') ";
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}     OR (ac_alt_ser_no_full = '{($"{txtSerialNoFrom.Text} ").Trim()}') ";
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}    ) ";
				}
			} // If chkSerNbrExact.Value = vbUnchecked Then

			if (Strings.Len(txtYear.Text.Trim()) > 0)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_year >= '{txtYear.Text.Trim()}' ";
				SomethingSelected = true;
			}
			if (Strings.Len(txtYear2.Text.Trim()) > 0)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_year <= '{txtYear2.Text.Trim()}' ";
				SomethingSelected = true;
			}

			if (optForSale.Checked)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_forsale_flag = 'Y' ";
				SomethingSelected = true;
			}
			else if (optNotForSale.Checked)
			{ 
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_forsale_flag <> 'Y' ";
				SomethingSelected = true;
			}

			//====================================================
			// Keith Humpf 2/18/2004
			// Added search for New/Used Aircraft
			//
			// Note: The data shows "Y" for previously owned
			//       and "N" OR NULL for NOT previously owned
			//       therefore we must search for "Y" or NOT "Y"
			//====================================================
			if (optNewUsed[1].Checked)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_previously_owned_flag <> 'Y' ";
			}
			else if (optNewUsed[2].Checked)
			{ 
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_previously_owned_flag = 'Y' ";

			}
			else if (optNewUsed[3].Checked)
			{ 
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} and journ_newac_flag = 'N' ";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} and ( ";

				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} (journ_date > ";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} (select top 1 jr2.journ_date from Aircraft af2 with (NOLOCK) inner join Journal jr2 WITH(NOLOCK) on af2.ac_journ_id = jr2.journ_id ";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} Where af2.ac_id = Aircraft.ac_id ";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} and (jr2.journ_newac_flag = 'Y' or af2.ac_previously_owned_flag = 'Y')  ";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} order by jr2.journ_date asc))";

				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} or  ";

				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} (journ_date = ";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} (select top 1 jr2.journ_date from Aircraft af2 with (NOLOCK) inner join Journal jr2 WITH(NOLOCK) on af2.ac_journ_id = jr2.journ_id  ";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} Where af2.ac_id = Aircraft.ac_id and Aircraft.ac_journ_id  >  af2.ac_journ_id ";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} and (jr2.journ_newac_flag = 'Y' or af2.ac_previously_owned_flag = 'Y')  ";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} order by jr2.journ_date asc))";

				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} ) ";

			}

			if (cmb_engine_noise_rating.Text == "Yes")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_engine_noise_rating > 0 ";
			}

			if (cmb_engine_noise_rating.Text == "No")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_engine_noise_rating = 0 ";
			}

			// 09/28/2012 - By David D. Cruger; Added Usage
			// 11/14/2012 - BY David D. Cruger; Did not change the search field
			if (cbo_ac_use_code.SelectedIndex > 0)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND (ac_use_code = '{cbo_ac_use_code.Text.Substring(0, Math.Min(1, cbo_ac_use_code.Text.Length))}') ";
			}

			if (cmb_model_config.Text == "Yes")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_model_config <> '' ";
			}

			if (cmb_model_config.Text == "No")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_model_config = '' ";
			}

			if (cboExclusive.Text == "Yes")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_exclusive_flag = 'Y' ";
				SomethingSelected = true;
			}
			if (cboExclusive.Text == "No")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_exclusive_flag = 'N' ";
				SomethingSelected = true;
			}

			if (cboOwnType.Text == "Whole")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_ownership_type = 'W' ";
				SomethingSelected = true;
			}
			if (cboOwnType.Text == "Shared")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_ownership_type = 'S' ";
				SomethingSelected = true;
			}
			if (cboOwnType.Text == "Fractional")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_ownership_type = 'F' ";
				SomethingSelected = true;
			}

			if (cbo_ac_asking.SelectedIndex > 0)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_asking = '{cbo_ac_asking.Text.Trim()}' ";
				SomethingSelected = true;
			}

			if (cbo_ac_delivery.SelectedIndex > 0)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_delivery = '{cbo_ac_delivery.Text.Trim()}' ";
				SomethingSelected = true;
			}

			if (cboLeaseStatus.Text == "Yes")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_lease_flag  = 'Y' ";
				SomethingSelected = true;
			}
			if (cboLeaseStatus.Text == "No")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND (ac_lease_flag = 'N' or ac_lease_flag IS NULL) ";
				SomethingSelected = true;
			}
			//Start rje 5/8/2001
			if (cbo_ac_class.SelectedIndex > 0)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND amod_class_code = '{cbo_ac_class.Text.Substring(0, Math.Min(2, cbo_ac_class.Text.Length)).Trim()}' ";
				SomethingSelected = true;
			}
			else
			{
				// it was blank, so exclude class E AC
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND amod_class_code <> 'E' ";
			}

			if (cbo_ac_lifecycle_stage.SelectedIndex > 0)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_lifecycle_stage = {cbo_ac_lifecycle_stage.GetItemData(cbo_ac_lifecycle_stage.SelectedIndex).ToString()} ";
				SomethingSelected = true;
			}

			int tempForEndVar6 = cboUsage.ControlCount() - 1;
			for (int i = 0; i <= tempForEndVar6; i++)
			{
				if (txtUsageValue[i].Text.Trim() != "" && cboUsage[i].SelectedIndex > -1 && cboUsageCondition[i].SelectedIndex > -1)
				{
					//    gbl_Search = gbl_Search & "AND " & UsageField(cboUsage(I).ListIndex, 2) & " " & cboUsageCondition(I) & " " & Replace(txtUsageValue(I), ":", " AND ") & " "
					if (UsageFmt[cboUsage[i].SelectedIndex] == "(MM/DD/YYCC)")
					{ //aey 3/21/05
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND {UsageFld[cboUsage[i].SelectedIndex]} {cboUsageCondition[i].Text} '{StringsHelper.Replace(txtUsageValue[i].Text, ":", "' AND '", 1, -1, CompareMethod.Binary)}' ";
					}
					else
					{
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND {UsageFld[cboUsage[i].SelectedIndex]} {cboUsageCondition[i].Text} {StringsHelper.Replace(txtUsageValue[i].Text, ":", " AND ", 1, -1, CompareMethod.Binary)} ";
					}
					SomethingSelected = true;
				}
			}

			string tmpquery = "";
			if (chkCompanyFlag.CheckState == CheckState.Checked)
			{
				// *********** START OF NEW CODE
				if (Strings.Len(CompanyStatelist.Trim()) > 0)
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND comp_state in ({CompanyStatelist}) ";
					// Separator = " AND "
					SomethingSelected = true;
				}
				else
				{
					if (Strings.Len(CompanyCountrylist.Trim()) > 0)
					{
						// *****************************************
						// SEARCH FOR COUNTRY BASED ON LIST SELECTED
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND comp_country in  ({CompanyCountrylist}) ";
						// Separator = " AND "
						SomethingSelected = true;
					}
					else
					{
						// *****************************************
						// SEARCH FOR CONINENT BASED ON LIST SELECTED
						if (Strings.Len(CompanyContinentlist.Trim()) > 0 && opt_CompanyContinent.Checked)
						{
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND comp_country in  (select distinct country_name from country where country_continent_name in ({CompanyContinentlist})) ";
							SomethingSelected = true;
						}
						// *****************************************
						// SEARCH FOR REGION BASED ON LIST SELECTED
						if (Strings.Len(CompanyRegionlist.Trim()) > 0 && opt_CompanyRegion.Checked)
						{
							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND comp_country in (select distinct geographic_country_name from geographic where geographic_region_name in ({CompanyRegionlist})) ";
							tmpquery = $"select distinct geographic_state_code from geographic where geographic_region_name in ({CompanyRegionlist}) and (geographic_state_code is not null and geographic_state_code <>'')";
							if (modAdminCommon.Exist(tmpquery))
							{

								modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND comp_state in (select distinct geographic_state_code from geographic where geographic_region_name in ({CompanyRegionlist})) ";
								// Separator = " AND "

							}
							SomethingSelected = true;
						}
						// END IF ON CONTRY LIST
					}
					// END IF ON STATE LIST
				}
				//************************* END OF NEW CODE


				if (lstCompanyType.SelectedItems.Count > 0 && !ListBoxHelper.GetSelected(lstCompanyType, 0))
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND cref_contact_type IN ( ";

					int tempForEndVar7 = lstCompanyType.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar7; i++)
					{
						if (ListBoxHelper.GetSelected(lstCompanyType, i))
						{
							TempString = $"{TempString}{Separator}{CompanyType[i]}";
							SomethingSelected = true;
							Separator = ",";
						}
					}
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}'{StringsHelper.Replace(TempString, ",", "','", 1, -1, CompareMethod.Binary)}') ";
				}
			}

			Separator = "";
			TempString = "";

			if (chkCompanyFlag.CheckState == CheckState.Checked)
			{
				if (lstCompanyTimeZone.SelectedItems.Count > 0 && !ListBoxHelper.GetSelected(lstCompanyTimeZone, 0))
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND comp_timezone IN ( ";

					int tempForEndVar8 = lstCompanyTimeZone.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar8; i++)
					{
						if (ListBoxHelper.GetSelected(lstCompanyTimeZone, i))
						{
							TempString = $"{TempString}{Separator}{lstCompanyTimeZone.GetListItem(i)}";
							SomethingSelected = true;
							Separator = ",";
						}
					}
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}'{StringsHelper.Replace(TempString, ",", "','", 1, -1, CompareMethod.Binary)}') ";
				}
			}

			if (chkCompanyFlag.CheckState == CheckState.Checked)
			{
				if (txtCompanyCity.Text.Trim() != "")
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND comp_city like '%{StringsHelper.Replace(txtCompanyCity.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%' ";
					SomethingSelected = true;
				}
				if (txtCompanyName.Text.Trim() != "")
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND comp_name like '%{StringsHelper.Replace(txtCompanyName.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%' ";
					SomethingSelected = true;
				}
				if (txtCompanyZip.Text.Trim() != "")
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND comp_zip_code = '{txtCompanyZip.Text.Trim()}' ";
					SomethingSelected = true;
				}
				if (cboBusinessType.SelectedIndex > 0)
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND bustypref_type = '{cboBusinessType.Text.Substring(0, Math.Min(2, cboBusinessType.Text.Length)).Trim()}' ";
					SomethingSelected = true;
				}

				if (cbo_Acc_Rep.SelectedIndex > 0)
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND comp_account_id = '{cbo_Acc_Rep.Text.Trim()}'";
					SomethingSelected = true;
				}

				if (cbo_agency_type.SelectedIndex > 0)
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND comp_agency_type = '{($"{cbo_agency_type.Text}").Trim().Substring(0, Math.Min(1, ($"{cbo_agency_type.Text}").Trim().Length))}' ";
					SomethingSelected = true;
				}

				//transaction stuff
				if (cbo_ContactType.SelectedIndex > 0)
				{ //aey 4/17/06
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND cref_contact_type='{($"{cbo_ContactType.Text}").Trim().Substring(0, Math.Min(2, ($"{cbo_ContactType.Text}").Trim().Length))}' ";
					SomethingSelected = true;
				}

				if (cbo_JournalCategory.SelectedIndex > 0)
				{ //aey 4/17/06
					tmp = new StringBuilder(($"{cbo_JournalCategory.Text}").Trim());
					K2 = (tmp.ToString().IndexOf('-') + 1);
					if (K2 > 0)
					{
						tmp = new StringBuilder(tmp.ToString().Substring(Math.Min(0, tmp.ToString().Length), Math.Min(K2 - 1, Math.Max(0, tmp.ToString().Length))).Trim());

						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND journ_subcategory_code like '{tmp.ToString()}%' ";
						SomethingSelected = true;

					}
					else
					{
					}
				}

			}

			if (txt_ac_aport_iata_code.Text.Trim() != "")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND (ac_aport_iata_code = '{txt_ac_aport_iata_code.Text.Trim()}') ";
				SomethingSelected = true;
			}

			if (txt_ac_aport_icao_code.Text.Trim() != "")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND (ac_aport_icao_code = '{txt_ac_aport_icao_code.Text.Trim()}') ";
				SomethingSelected = true;
			}



			// make sure these 3 cirrus models dont show
			modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} and amod_id not in (1297,1295,1296) ";



			if (txt_ac_aport_faaid_code.Text.Trim() != "")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND (ac_aport_faaid_code = '{txt_ac_aport_faaid_code.Text.Trim()}') ";
				SomethingSelected = true;
			}

			if (txt_ac_aport_city.Text.Trim() != "")
			{ //aey 6/4/04
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_aport_city like '%{StringsHelper.Replace(txt_ac_aport_city.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%' ";
				SomethingSelected = true;
			}

			if (txt_ac_aport_name.Text.Trim() != "")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_aport_name like '%{StringsHelper.Replace(txt_ac_aport_name.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%' ";
				SomethingSelected = true;
			}

			if (txt_ac_status.Text.Trim() != "")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}AND ac_status like '%{StringsHelper.Replace(txt_ac_status.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%' ";
				SomethingSelected = true;
			}


			if (Strings.Len(Statelist.Trim()) > 0)
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_aport_state in ({Statelist}) ";
				Separator = " AND ";
				SomethingSelected = true;
			}
			else
			{
				if (Strings.Len(Countrylist.Trim()) > 0)
				{
					// *****************************************
					// SEARCH FOR COUNTRY BASED ON LIST SELECTED
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_aport_country in  ({Countrylist}) ";
					Separator = " AND ";
					SomethingSelected = true;
				}
				else
				{
					// *****************************************
					// SEARCH FOR CONINENT BASED ON LIST SELECTED
					if (Strings.Len(Continentlist.Trim()) > 0 && opt_Continent.Checked)
					{
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_aport_country in  (select distinct country_name from country where country_continent_name in ({Continentlist})) ";
						Separator = " AND ";
						SomethingSelected = true;
					}
					// *****************************************
					// SEARCH FOR REGION BASED ON LIST SELECTED
					if (Strings.Len(Regionlist.Trim()) > 0 && opt_Region.Checked)
					{
						modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_aport_country in (select distinct geographic_country_name from geographic where geographic_region_name in ({Regionlist})) ";
						//Dim tmpquery As String
						tmpquery = $"select distinct geographic_state_code from geographic where geographic_region_name in ({Regionlist}) and (geographic_state_code is not null and geographic_state_code <>'')";
						if (modAdminCommon.Exist(tmpquery))
						{

							modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_aport_state in (select distinct geographic_state_code from geographic where geographic_region_name in ({Regionlist})) ";
							Separator = " AND ";

						}
						SomethingSelected = true;
					}
					// END IF ON CONTRY LIST
				}
				// END IF ON STATE LIST
			}

			//MsgBox (gbl_Search)
			// *************************
			if (txt_ac_id.Text.Trim() != "")
			{
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_id = {txt_ac_id.Text.Trim()} ";
				SomethingSelected = true;
			}

			if (cboWeightClass.SelectedIndex > 0)
			{
				SomethingSelected = true;
				if (cboWeightClass.Text.IndexOf('-') >= 0)
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND amod_type_code = '{cboWeightClass.Text.Substring(0, Math.Min(1, cboWeightClass.Text.Length))}' ";
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND amod_weight_class = '{cboWeightClass.Text.Substring(Math.Min(cboWeightClass.Text.IndexOf('-') + 2, cboWeightClass.Text.Length), Math.Min(1, Math.Max(0, cboWeightClass.Text.Length - (cboWeightClass.Text.IndexOf('-') + 2))))}' ";
				}
				else
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND amod_weight_class = '{cboWeightClass.Text.Substring(0, Math.Min(1, cboWeightClass.Text.Length))}' ";
				}
			}

			if (cboAirframeTypeCode.SelectedIndex > 0)
			{
				SomethingSelected = true;
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND amod_airframe_type_code = '{cboAirframeTypeCode.Text.Substring(0, Math.Min(1, cboAirframeTypeCode.Text.Length))}' ";
			}

			if (cbo_engCompare.SelectedIndex > 0 && Strings.Len(($"{txt_amod_number_of_engines.Text}").Trim()) > 0)
			{
				SomethingSelected = true;
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND amod_number_of_engines {cbo_engCompare.Text} {txt_amod_number_of_engines.Text} ";
			}

			if (cbo_ac_use_code.SelectedIndex > 0)
			{
				SomethingSelected = true;
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_use_code = '{cbo_ac_use_code.Text.Substring(0, Math.Min(1, cbo_ac_use_code.Text.Length))}' ";
			}

			// 11/13/2012 - By David D. Cruger; Added
			if (cbo_ac_interior_config_search.SelectedIndex > 0)
			{
				SomethingSelected = true;
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_interior_config_name = '{($"{cbo_ac_interior_config_search.Text} ").Trim()}' ";
			}

			if (cboMaintained.SelectedIndex > 0)
			{
				SomethingSelected = true;
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_maintained = '{cboMaintained.Text}' ";
			}

			if (cboEngineModel.SelectedIndex > 0)
			{
				SomethingSelected = true;
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_engine_name_search = '{StringsHelper.Replace(cboEngineModel.Text.Trim(), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary)}' ";
			}

			if (txtEngineModel.Text != "")
			{
				SomethingSelected = true;

				ArrEng = txtEngineModel.Text.Split(',');
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND (";
				Separator = "";

				int tempForEndVar9 = ArrEng.GetUpperBound(0);
				for (int i = 0; i <= tempForEndVar9; i++)
				{
					modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search}{Separator}ac_engine_name_search LIKE '{StringsHelper.Replace(ArrEng[i].Trim(), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary)}%' ";
					Separator = " OR ";
				}

				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search})";
			}

			if (cboEMP.SelectedIndex > 0)
			{
				SomethingSelected = true;
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND ac_engine_maint_prog = '{cboEMP.Text.Substring(0, Math.Min(1, cboEMP.Text.Length))}' ";
			}

			if (txtEngSerNoFrom.Text != "" && txtEngSerNoTo.Text != "")
			{
				SomethingSelected = true;

				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND (ac_engine_1_ser_no BETWEEN '{txtEngSerNoFrom.Text.Trim()}' AND '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_engine_2_ser_no BETWEEN '{txtEngSerNoFrom.Text.Trim()}' AND '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_engine_3_ser_no BETWEEN '{txtEngSerNoFrom.Text.Trim()}' AND '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_engine_4_ser_no BETWEEN '{txtEngSerNoFrom.Text.Trim()}' AND '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_prop_1_ser_no BETWEEN '{txtEngSerNoFrom.Text.Trim()}' AND '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_prop_2_ser_no BETWEEN '{txtEngSerNoFrom.Text.Trim()}' AND '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_prop_3_ser_no BETWEEN '{txtEngSerNoFrom.Text.Trim()}' AND '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_prop_4_ser_no BETWEEN '{txtEngSerNoFrom.Text.Trim()}' AND '{txtEngSerNoTo.Text.Trim()}')";

			}
			else if (txtEngSerNoFrom.Text != "")
			{ 
				SomethingSelected = true;

				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND (ac_engine_1_ser_no = '{txtEngSerNoFrom.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_engine_2_ser_no = '{txtEngSerNoFrom.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_engine_3_ser_no = '{txtEngSerNoFrom.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_engine_4_ser_no = '{txtEngSerNoFrom.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_prop_1_ser_no = '{txtEngSerNoFrom.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_prop_2_ser_no = '{txtEngSerNoFrom.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_prop_3_ser_no = '{txtEngSerNoFrom.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_prop_4_ser_no = '{txtEngSerNoFrom.Text.Trim()}')";

			}
			else if (txtEngSerNoTo.Text != "")
			{ 
				SomethingSelected = true;

				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} AND (ac_engine_1_ser_no = '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_engine_2_ser_no = '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_engine_3_ser_no = '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_engine_4_ser_no = '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_prop_1_ser_no = '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_prop_2_ser_no = '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_prop_3_ser_no = '{txtEngSerNoTo.Text.Trim()}'";
				modAdminCommon.gbl_Search = $"{modAdminCommon.gbl_Search} OR ac_prop_4_ser_no = '{txtEngSerNoTo.Text.Trim()}')";
			}
			//MsgBox gbl_Search
		}

		private void Tabs1_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) System.Windows.Forms.Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (HadHourglass)
			{
				this.Cursor = Cursors.WaitCursor;
			}

		}

		private void tbr_ToolBar_ButtonClick(Object eventSender, EventArgs eventArgs)
		{
			ToolStripItem Button = (ToolStripItem) eventSender;
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  RESP                                                                                  *
			//******************************************************************************************

			try
			{


				switch(Button.Name)
				{
					case "Home" : 
						modAdminCommon.gbl_bHomeClicked = true; 
						//frm_Main_Menu.Show 
						//frm_Main_Menu.ZOrder 0 
						modCommon.Hide_All_Forms_Except("frm_Main_Menu"); 
						this.Close(); 
						 
						break;
					case "Back" : 
						if (SSTabHelper.GetSelectedIndex(Tabs1) == 1)
						{
							cmdStop_Click(cmdStop, new EventArgs());
							SSTabHelper.SetSelectedIndex(Tabs1, 0);
						}
						else
						{
							mnuFileClose_Click(mnuFileClose, new EventArgs());
						} 
						break;
					case "Save" : 
						MessageBox.Show("There is nothing to Save", "Aircraft List", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
					case "Help" : 
						MessageBox.Show("Help is forthcoming", "Aircraft List", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
					default:
						//RESP = MsgBox("ToolBar Error", vbInformation, "Unrecognized Toolbar Reference") 
						break;
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"tbr_ToolBar_Error: AC_List {Button.Name} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private void ToolbarButtonsSetup()
		{


			ToolStrip tbr = tbr_ToolBar; //gap-note ToolStrip instead of Control

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].Visible = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].Visible = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].Visible = false;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].Visible = true;

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].Enabled = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].Enabled = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].Enabled = false;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].Enabled = true;

		}

		private void ToolbarSetup()
		{


			ToolStrip tbr = tbr_ToolBar; //gap-note ToolStrip instead of Control

			//UPGRADE_TODO: (1067) Member ImageList is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.ImageList = mdi_ResearchAssistant.DefInstance.imgNormal;

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[2] as ToolStripButton).Image = (Image) resources.GetObject( "Home");
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[4] as ToolStripButton).Image = (Image) resources.GetObject( "Back");
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[6] as ToolStripButton).Image = (Image) resources.GetObject( "Save");
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[8] as ToolStripButton).Image = (Image) resources.GetObject( "Help");

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].Text = "Home";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].Text = "Back";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].Text = "Save";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].Text = "Help";

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].ToolTipText = "Go to Main Menu";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].ToolTipText = "Go to Previous Screen";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].ToolTipText = "Save screen data";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].ToolTipText = "Online Help";

		}

		public void FillStage()
		{
			ADORecordSetHelper snp_Stage = new ADORecordSetHelper(); //6/15/04 aey


			cbo_ac_lifecycle_stage.Items.Clear();
			string Query = "select * from Aircraft_Stage ";
			snp_Stage.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snp_Stage.BOF && snp_Stage.EOF))
			{
				cbo_ac_lifecycle_stage.AddItem("Not Specified");

				while(!snp_Stage.EOF)
				{
					cbo_ac_lifecycle_stage.AddItem($"{($"{Convert.ToString(snp_Stage["acs_code"])}").Trim()} - {($"{Convert.ToString(snp_Stage["acs_name"])}").Trim()}");
					cbo_ac_lifecycle_stage.SetItemData(cbo_ac_lifecycle_stage.Items.Count - 1, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_Stage["acs_code"])}").Trim())));
					snp_Stage.MoveNext();
				};
				cbo_ac_lifecycle_stage.SelectedIndex = 0;
			}

			snp_Stage.Close();

		}

		private void txt_ac_aport_iata_code_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.Asc(Strings.Chr(KeyAscii).ToString().ToUpper()[0]);
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		private void txt_ac_aport_icao_code_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.Asc(Strings.Chr(KeyAscii).ToString().ToUpper()[0]);
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		private void txt_ac_aport_faaid_code_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.Asc(Strings.Chr(KeyAscii).ToString().ToUpper()[0]);
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		//UPGRADE_NOTE: (7001) The following declaration (txt_ac_aport_state_KeyPress) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void txt_ac_aport_state_KeyPress(ref int KeyAscii) => KeyAscii = Strings.Asc(Strings.Chr(KeyAscii).ToString().ToUpper()[0]);
		//

		private void Fill_AC_Region_List()
		{
			//******************************************************
			//
			// THE PROCEDURE FILLS A LIST BOX WITH A MASTER LIST OF REGIONS
			//
			// LAST CHANGED BY RICK WANNER ON 3/21/03
			//
			// *****************************************************
			try
			{

				string Query = "";
				string M = "";
				ADORecordSetHelper snp_RegionList = new ADORecordSetHelper(); //aey 6/15/04

				lst_Area.Items.Clear();
				lst_Area.AddItem("All");
				Query = "SELECT region_name FROM Region WITH (NOLOCK) ORDER BY region_name";
				snp_RegionList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_RegionList.BOF && snp_RegionList.EOF))
				{

					while(!snp_RegionList.EOF)
					{
						M = ($"{Convert.ToString(snp_RegionList["region_name"])}").Trim();
						lst_Area.AddItem(M);
						snp_RegionList.MoveNext();
					};
				}
				snp_RegionList.Close();
				snp_RegionList = null;
				ListBoxHelper.SetSelected(lst_Area, 0, true);
			}
			catch (System.Exception excep)
			{

				//Working_Off
				modAdminCommon.Report_Error($"Fill_AC_Region_List_Error: {excep.Message}");
				return;
			}
		}
		private void Fill_AC_State_List()
		{
			try
			{

				string Query = "";
				string M = "";
				ADORecordSetHelper snp_StateList = new ADORecordSetHelper(); //aey 6/28/04 convert to ado

				lst_State.Items.Clear();
				lst_State.AddItem("All");
				if (Strings.Len(Countrylist.Trim()) > 0 && !ListBoxHelper.GetSelected(lst_Country, 0))
				{

					Query = "SELECT state_code, state_name FROM State";

					if (Strings.Len(Regionlist.Trim()) > 0)
					{
						Query = $"{Query}, Geographic";
					}

					// if we only have one country or region then we dont need the in clause ' mjm 8/2/07
					if (Countrylist.IndexOf("','") >= 0)
					{
						Query = $"{Query} WHERE state_country IN ({Countrylist})";
					}
					else
					{
						Query = $"{Query} WHERE state_country = {Countrylist}";
					}

					if (Strings.Len(Regionlist.Trim()) > 0)
					{
						// if we only have one country or region then we dont need the in clause ' mjm 8/2/07
						if (Regionlist.IndexOf("','") >= 0)
						{
							Query = $"{Query} AND state_code = geographic_state_code and state_country = geographic_country_name and geographic_region_name in ({Regionlist})";
						}
						else
						{
							Query = $"{Query} AND state_code = geographic_state_code and state_country = geographic_country_name and geographic_region_name = {Regionlist}";
						}
					}

					Query = $"{Query} AND state_active_flag ='Y'"; //aey 6/28/04

				}
				else
				{

					if (Strings.Len(Regionlist.Trim()) > 0 && opt_Region.Checked && !ListBoxHelper.GetSelected(lst_Area, 0))
					{
						Query = "SELECT state_code, state_name FROM State, Geographic";
						// if we only have one country or region then we dont need the in clause ' mjm 8/2/07
						if (Regionlist.IndexOf("','") >= 0)
						{
							Query = $"{Query} WHERE state_code=geographic_state_code and state_country=geographic_country_name and geographic_region_name in ({Regionlist}) ";
						}
						else
						{
							Query = $"{Query} WHERE state_code=geographic_state_code and state_country=geographic_country_name and geographic_region_name = {Regionlist}";
						}

						Query = $"{Query} AND state_active_flag ='Y'"; //aey 6/28/04

					}

					if (Strings.Len(Continentlist.Trim()) > 0 && opt_Continent.Checked && !ListBoxHelper.GetSelected(lst_Area, 0))
					{
						Query = "SELECT state_code, state_name FROM State,Country ";
						// if we only have one country or region then we dont need the in clause ' mjm 8/2/07
						if (Continentlist.IndexOf("','") >= 0)
						{
							Query = $"{Query} WHERE state_country=country_name and country_continent_name in ({Continentlist})";
						}
						else
						{
							Query = $"{Query} WHERE state_country=country_name and country_continent_name = {Continentlist}";
						}

						Query = $"{Query} AND state_active_flag ='Y'"; //aey 6/28/04

					}

				}

				if (Query == "")
				{
					Query = "SELECT state_code, state_name FROM State where state_active_flag ='Y'"; //aey 6/28/04
				}

				Query = $"{Query} ORDER BY state_code";

				snp_StateList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_StateList.BOF && snp_StateList.EOF))
				{

					while(!snp_StateList.EOF)
					{
						M = $"{($"{Convert.ToString(snp_StateList["State_code"])}").Trim()} - {($"{Convert.ToString(snp_StateList["State_name"])}").Trim()}";
						lst_State.AddItem(M);
						snp_StateList.MoveNext();
					};
				}
				snp_StateList.Close();
				snp_StateList = null;
				ListBoxHelper.SetSelected(lst_State, 0, true);
			}
			catch (System.Exception excep)
			{
				//Working_Off
				modAdminCommon.Report_Error($"Fill_AC_State_List_Error: {excep.Message}");
				return;
			}
		}

		private void Fill_Aircraft_Usage_List()
		{
			string Query = "";
			ADORecordSetHelper ado_Usage = new ADORecordSetHelper();

			try
			{

				cbo_ac_use_code.Items.Clear();
				cbo_ac_use_code.Tag = "";
				cbo_ac_use_code.AddItem("Not Specified");

				Query = "Select * from aircraft_useage order by acuse_name ";
				ado_Usage.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_Usage.BOF && ado_Usage.EOF))
				{

					while(!ado_Usage.EOF)
					{
						cbo_ac_use_code.AddItem(($"{Convert.ToString(ado_Usage["acuse_code"])} - {Convert.ToString(ado_Usage["acuse_name"])}").Trim());
						ado_Usage.MoveNext();
					};
				}

				cbo_ac_use_code.SelectedIndex = 0;
				ado_Usage.Close();
				ado_Usage = null;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Fill_Aircraft_Usage_List_Errorx: {excep.Message}");
				return;
			}

		}

		private void Fill_AC_Country_List()
		{
			//******************************************************
			//
			// THE PROCEDURE FILLS A LIST BOX WITH A MASTER LIST OF COUNTRIES
			//
			// LAST CHANGED BY RICK WANNER ON 3/21/03
			//
			// *****************************************************
			try
			{

				string Query = "";
				string M = "";
				ADORecordSetHelper snp_CountryList = new ADORecordSetHelper(); //7/26/05 aey

				lst_Country.Items.Clear();
				lst_Country.AddItem("All");
				Query = "SELECT distinct country_name FROM Country,Geographic ";
				Query = $"{Query}WHERE country_name=geographic_country_name ";
				//Query = Query & " and country_active_flag='Y' "
				if (Strings.Len(Continentlist.Trim()) > 0 && !ListBoxHelper.GetSelected(lst_Area, 0))
				{
					Query = $"{Query}and country_continent_name in ({Continentlist})";
				}
				else
				{
					if (Strings.Len(Regionlist.Trim()) > 0)
					{
						Query = $"{Query}and geographic_region_name in ({Regionlist})";
					}
				}
				Query = $"{Query}order by country_name";

				snp_CountryList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_CountryList.BOF && snp_CountryList.EOF))
				{

					while(!snp_CountryList.EOF)
					{
						M = ($"{Convert.ToString(snp_CountryList["country_name"])}").Trim();
						lst_Country.AddItem(M);
						snp_CountryList.MoveNext();
					};
				}
				snp_CountryList.Close();
				snp_CountryList = null;
				ListBoxHelper.SetSelected(lst_Country, 0, true);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_AC_Country_List_Error: {excep.Message}");
				return;
			}
		}

		private void Set_DemographicList()
		{


			Continentlist = "";
			Regionlist = "";
			Countrylist = "";
			Statelist = "";

			string Seperator = "";
			if (opt_Continent.Checked)
			{
				int tempForEndVar = lst_Area.Items.Count - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					if (ListBoxHelper.GetSelected(lst_Area, i))
					{
						Continentlist = $"{Continentlist}{Seperator}{lst_Area.GetListItem(i)}";
						Seperator = ",";
					}
				}
			}

			Seperator = "";
			int tempForEndVar2 = lst_Country.Items.Count - 1;
			for (int i = 1; i <= tempForEndVar2; i++)
			{
				if (ListBoxHelper.GetSelected(lst_Country, i))
				{
					Countrylist = $"{Countrylist}{Seperator}{modAdminCommon.Fix_Quote(lst_Country.GetListItem(i))}";
					Seperator = ",";
				}
			}

			Seperator = "";
			int tempForEndVar3 = lst_State.Items.Count - 1;
			for (int i = 1; i <= tempForEndVar3; i++)
			{
				if (ListBoxHelper.GetSelected(lst_State, i))
				{
					Statelist = $"{Statelist}{Seperator}{lst_State.GetListItem(i).Substring(0, Math.Min(2, lst_State.GetListItem(i).Length))}";
					Seperator = ",";
				}
			}

			Seperator = "";
			if (opt_Region.Checked)
			{
				int tempForEndVar4 = lst_Area.Items.Count - 1;
				for (int i = 1; i <= tempForEndVar4; i++)
				{
					if (ListBoxHelper.GetSelected(lst_Area, i))
					{
						Regionlist = $"{Regionlist}{Seperator}{lst_Area.GetListItem(i)}";
						Seperator = ",";
					}
				}
			}

			if (Countrylist != "")
			{
				Countrylist = $"'{StringsHelper.Replace(Countrylist, ",", "','", 1, -1, CompareMethod.Binary)}'";
			}
			if (Continentlist != "")
			{
				Continentlist = $"'{StringsHelper.Replace(Continentlist, ",", "','", 1, -1, CompareMethod.Binary)}'";
			}

			if (Statelist != "")
			{
				Statelist = $"'{StringsHelper.Replace(Statelist, ",", "','", 1, -1, CompareMethod.Binary)}'";
			}
			if (Regionlist != "")
			{
				Regionlist = $"'{StringsHelper.Replace(Regionlist, ",", "','", 1, -1, CompareMethod.Binary)}'";
			}

			//MsgBox (Countrylist)

		}

		private void Fill_Demographics()
		{

			if (opt_Continent.Checked)
			{
				Fill_AC_Continent_List();
			}
			else
			{
				Fill_AC_Region_List();
			}

		} // Fill_Demographics

		private void Fill_AC_Continent_List()
		{
			//******************************************************
			//
			// THE PROCEDURE FILLS A LIST BOX WITH A MASTER LIST OF CONTINENTS
			//
			// LAST CHANGED BY RICK WANNER ON 3/21/03
			//
			// *****************************************************
			try
			{

				string Query = "";
				string M = "";
				ADORecordSetHelper snp_ContinentList = new ADORecordSetHelper(); //7/26/05 aey

				lst_Area.Items.Clear();
				lst_Area.AddItem("All");
				Query = "SELECT continent_name FROM Continent WITH (NOLOCK) ORDER BY continent_name";

				snp_ContinentList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_ContinentList.BOF && snp_ContinentList.EOF))
				{

					while(!snp_ContinentList.EOF)
					{
						M = ($"{Convert.ToString(snp_ContinentList["continent_name"])}").Trim();
						lst_Area.AddItem(M);
						snp_ContinentList.MoveNext();
					};
				}

				snp_ContinentList.Close();
				snp_ContinentList = null;
				ListBoxHelper.SetSelected(lst_Area, 0, true);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_AC_Continent_List_Error: {excep.Message}");
				return;
			}
		}

		public void Fill_Company_Continent_List()
		{
			//******************************************************
			//
			// THE PROCEDURE FILLS A LIST BOX WITH A MASTER LIST OF CONTINENTS
			//
			// LAST CHANGED BY RICK WANNER ON 3/21/03
			//
			// *****************************************************
			try
			{

				string Query = "";
				string M = "";
				ADORecordSetHelper snp_CompContinentList = new ADORecordSetHelper(); //7/26/05 aey

				lst_CompanyArea.Items.Clear();
				lst_CompanyArea.AddItem("All");
				Query = "SELECT continent_name FROM Continent WITH (NOLOCK) ORDER BY continent_name";
				snp_CompContinentList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_CompContinentList.BOF && snp_CompContinentList.EOF))
				{

					while(!snp_CompContinentList.EOF)
					{
						M = ($"{Convert.ToString(snp_CompContinentList["continent_name"])}").Trim();
						lst_CompanyArea.AddItem(M);
						snp_CompContinentList.MoveNext();
					};
				}
				snp_CompContinentList.Close();
				snp_CompContinentList = null;
				ListBoxHelper.SetSelected(lst_CompanyArea, 0, true);
			}
			catch (System.Exception excep)
			{
				//Working_Off
				modAdminCommon.Report_Error($"Fill_Company_Continent_List_Error: {excep.Message}");
				return;
			}
		}

		private void Fill_Company_Region_List()
		{
			//******************************************************
			//
			// THE PROCEDURE FILLS A LIST BOX WITH A MASTER LIST OF REGIONS
			//
			// LAST CHANGED BY RICK WANNER ON 3/21/03
			//
			// *****************************************************
			try
			{

				string Query = "";
				string M = "";
				ADORecordSetHelper snp_CompRegionList = new ADORecordSetHelper(); //7/26/05 aey

				lst_CompanyArea.Items.Clear();
				lst_CompanyArea.AddItem("All");
				Query = "SELECT region_name FROM Region WITH (NOLOCK) ORDER BY region_name";

				snp_CompRegionList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_CompRegionList.BOF && snp_CompRegionList.EOF))
				{

					while(!snp_CompRegionList.EOF)
					{
						M = ($"{Convert.ToString(snp_CompRegionList["region_name"])}").Trim();
						lst_CompanyArea.AddItem(M);
						snp_CompRegionList.MoveNext();
					};
				}
				snp_CompRegionList.Close();
				snp_CompRegionList = null;
				ListBoxHelper.SetSelected(lst_CompanyArea, 0, true);
			}
			catch (System.Exception excep)
			{

				//Working_Off
				modAdminCommon.Report_Error($"Fill_Company_Region_List_Error: {excep.Message}");
				return;
			}
		}

		private void Set_Company_Demographics()
		{
			CompanyContinentlist = "";
			CompanyRegionlist = "";
			CompanyCountrylist = "";
			CompanyStatelist = "";
			string Seperator = "";
			if (opt_CompanyContinent.Checked)
			{
				int tempForEndVar = lst_CompanyArea.Items.Count - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{

					if (ListBoxHelper.GetSelected(lst_CompanyArea, i))
					{
						CompanyContinentlist = $"{CompanyContinentlist}{Seperator}{lst_CompanyArea.GetListItem(i)}";
						Seperator = ",";
					}
				}
			}
			Seperator = "";
			int tempForEndVar2 = lstCompanyCountry.Items.Count - 1;
			for (int i = 1; i <= tempForEndVar2; i++)
			{
				if (ListBoxHelper.GetSelected(lstCompanyCountry, i))
				{
					CompanyCountrylist = $"{CompanyCountrylist}{Seperator}{lstCompanyCountry.GetListItem(i)}";
					Seperator = ",";
				}
			}
			Seperator = "";
			int tempForEndVar3 = lstCompanyState.Items.Count - 1;
			for (int i = 1; i <= tempForEndVar3; i++)
			{
				if (ListBoxHelper.GetSelected(lstCompanyState, i))
				{
					CompanyStatelist = $"{CompanyStatelist}{Seperator}{lstCompanyState.GetListItem(i).Substring(0, Math.Min(2, lstCompanyState.GetListItem(i).Length))}";
					Seperator = ",";
				}
			}
			Seperator = "";
			if (opt_CompanyRegion.Checked)
			{
				int tempForEndVar4 = lst_CompanyArea.Items.Count - 1;
				for (int i = 1; i <= tempForEndVar4; i++)
				{
					if (ListBoxHelper.GetSelected(lst_CompanyArea, i))
					{
						CompanyRegionlist = $"{CompanyRegionlist}{Seperator}{lst_CompanyArea.GetListItem(i)}";
						Seperator = ",";
					}
				}
			}
			if (CompanyCountrylist != "")
			{
				CompanyCountrylist = $"'{StringsHelper.Replace(CompanyCountrylist, ",", "','", 1, -1, CompareMethod.Binary)}'";
			}
			if (CompanyContinentlist != "")
			{
				CompanyContinentlist = $"'{StringsHelper.Replace(CompanyContinentlist, ",", "','", 1, -1, CompareMethod.Binary)}'";
			}
			if (CompanyStatelist != "")
			{
				CompanyStatelist = $"'{StringsHelper.Replace(CompanyStatelist, ",", "','", 1, -1, CompareMethod.Binary)}'";
			}
			if (CompanyRegionlist != "")
			{
				CompanyRegionlist = $"'{StringsHelper.Replace(CompanyRegionlist, ",", "','", 1, -1, CompareMethod.Binary)}'";
			}
		}

		private void Fill_Company_Demographics()
		{
			if (opt_CompanyContinent.Checked)
			{
				Fill_Company_Continent_List();
			}
			else
			{
				Fill_Company_Region_List();
			}
		}

		private void Clear_TimeZone()
		{
			lstCompanyTimeZone.Items.Clear();
			lstCompanyTimeZone.AddItem("All");
			ListBoxHelper.SetSelected(lstCompanyTimeZone, 0, true);
		}

		// 08/14/2012 - By David D. Cruger
		// This routine was stopping the Ctrl-V, Ctrl-C
		// Re-wrote to only accept numeric values

		private void txt_ac_id_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				//-----------------------------
				// Numeric Only
				// 31 and Below Are Ctrl-Keys

				if (KeyAscii > 31)
				{
					if (KeyAscii < 48 || KeyAscii > 57)
					{
						KeyAscii = 0;
					}
				}
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

		}

		private void txt_Journ_id_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				//-----------------------------
				// Numeric Only
				// 31 and Below Are Ctrl-Keys

				if (KeyAscii > 31)
				{
					if (KeyAscii < 48 || KeyAscii > 57)
					{
						KeyAscii = 0;
					}
				}
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

		}

		private void txtEngineModel_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txtEngineModel, txtEngineModel.Text);



		private void txtEngSerNoFrom_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txtEngSerNoFrom, txtEngSerNoFrom.Text);



		private void txtEngSerNoTo_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txtEngSerNoTo, txtEngSerNoTo.Text);



		private void txtSerialNoFrom_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txtSerialNoFrom, txtSerialNoFrom.Text);



		private void txtSerialNoTo_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txtSerialNoTo, txtSerialNoTo.Text);

	}
}