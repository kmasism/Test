using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal static class modFillCommonArrays
	{


		internal static bool Fill_Currency_Type_Array()
		{

			bool result = false;
			string Query = "";
			ADORecordSetHelper snpCurrency = new ADORecordSetHelper(); //aey 6/10/04
			int nCounter = 0; // msw 3/15/12
			int nRecCount = 0;
			try
			{


				Query = "SELECT currency_name FROM Currency WITH(NOLOCK) ORDER BY currency_name";

				snpCurrency.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpCurrency.BOF && snpCurrency.EOF))
				{

					nRecCount = snpCurrency.RecordCount;

					modGlobalVars.Currency_Array = ArraysHelper.InitializeArray<string>(nRecCount);


					while(!snpCurrency.EOF)
					{
						modGlobalVars.Currency_Array[nCounter] = ($"{Convert.ToString(snpCurrency["currency_name"])}").Trim();
						nCounter++;
						snpCurrency.MoveNext();
					};

					result = true;

				}



				snpCurrency.Close();
				snpCurrency = null;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Currency_Type_Array_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return result;
		}

		internal static bool Fill_Airframe_Maintenance_Program_CBO_Array_History()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int lTot1 = 0;
			int lCnt1 = 0;

			try
			{

				lTot1 = 0;
				lCnt1 = 0;

				strQuery1 = "SELECT * FROM Airframe_Maintenance_Program WITH (NOLOCK) ORDER BY amp_provider_name, amp_program_name";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				lTot1 = rstRec1.RecordCount;

				modGlobalVars.Airframe_Maint_Prog_History = ArraysHelper.InitializeArray<string>(lTot1);
				modGlobalVars.Airframe_Maint_Prog_Data_History = ArraysHelper.InitializeArray<string>(lTot1);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						modGlobalVars.Airframe_Maint_Prog_History[lCnt1] = $"{($"{Convert.ToString(rstRec1["amp_provider_name"])}").Trim()} - {($"{Convert.ToString(rstRec1["amp_program_name"])}").Trim()}";
						modGlobalVars.Airframe_Maint_Prog_Data_History[lCnt1] = Double.Parse($"0{($"{Convert.ToString(rstRec1["amp_id"])}").Trim()}").ToString();
						lCnt1++;

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Airframe_Maintenance_Program_CBO_Array_History_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}
			return false;
		} // Fill_Airframe_Maintenance_Program_CBO_Array_History

		internal static bool Fill_Airframe_Maintenance_Program_CBO_Array()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int lTot1 = 0;
			int lCnt1 = 0;

			try
			{

				lTot1 = 0;
				lCnt1 = 0;

				strQuery1 = "SELECT * FROM Airframe_Maintenance_Program WITH (NOLOCK) WHERE (amp_active_flag = 'Y')  ORDER BY amp_provider_name, amp_program_name";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				lTot1 = rstRec1.RecordCount;

				modGlobalVars.Airframe_Maint_Prog = ArraysHelper.InitializeArray<string>(lTot1);
				modGlobalVars.Airframe_Maint_Prog_Data = ArraysHelper.InitializeArray<string>(lTot1);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						modGlobalVars.Airframe_Maint_Prog[lCnt1] = $"{($"{Convert.ToString(rstRec1["amp_provider_name"])}").Trim()} - {($"{Convert.ToString(rstRec1["amp_program_name"])}").Trim()}";
						modGlobalVars.Airframe_Maint_Prog_Data[lCnt1] = Double.Parse($"0{($"{Convert.ToString(rstRec1["amp_id"])}").Trim()}").ToString();
						lCnt1++;

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Airframe_Maintenance_Program_CBO_Array_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}
			return false;
		} // Fill_Airframe_Maintenance_Program_CBO_Array_Error

		internal static bool Fill_Airframe_Tracking_CBO_Array()
		{

			string Query = "";
			ADORecordSetHelper snpTracking = new ADORecordSetHelper(); //aey 6/10/04
			int nCounter = 0;
			int nRecCount = 0;
			try
			{


				Query = "SELECT * FROM Airframe_Maintenance_Tracking_Program WITH(NOLOCK) ORDER BY amtp_provider_name, amtp_program_name";

				snpTracking.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);


				if (!(snpTracking.BOF && snpTracking.EOF))
				{

					nRecCount = snpTracking.RecordCount;

					modGlobalVars.Airframe_Maint_Track_Prog = ArraysHelper.InitializeArray<string>(nRecCount);
					modGlobalVars.Airframe_Maint_Track_Prog_Data = ArraysHelper.InitializeArray<string>(nRecCount);



					while(!snpTracking.EOF)
					{
						modGlobalVars.Airframe_Maint_Track_Prog[nCounter] = $"{($"{Convert.ToString(snpTracking["amtp_provider_name"])}").Trim()} - {($"{Convert.ToString(snpTracking["amtp_program_name"])}").Trim()}";
						modGlobalVars.Airframe_Maint_Track_Prog_Data[nCounter] = Double.Parse($"0{($"{Convert.ToString(snpTracking["amtp_id"])}").Trim()}").ToString();

						nCounter++;
						snpTracking.MoveNext();
					};
				}

				snpTracking.Close();
				snpTracking = null;


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Airframe_Tracking_CBO_Array_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}
			return false;
		}


		internal static bool Fill_Engine_Management_CBO_Array()
		{

			string Query = "";
			ADORecordSetHelper snpEng = new ADORecordSetHelper(); //aey 6/10/04
			int nRecCount = 0;
			int nCounter = 0;
			try
			{

				Query = "SELECT * FROM Engine_Management_Program WITH(NOLOCK) ORDER BY emgp_provider_name, emgp_program_name";

				snpEng.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);


				if (!(snpEng.BOF && snpEng.EOF))
				{



					nRecCount = snpEng.RecordCount;
					modGlobalVars.Engine_Array1 = ArraysHelper.InitializeArray<string>(nRecCount);
					modGlobalVars.Engine_ArrayData = ArraysHelper.InitializeArray<string>(nRecCount);


					while(!snpEng.EOF)
					{
						modGlobalVars.Engine_Array1[nCounter] = $"{($"{Convert.ToString(snpEng["emgp_provider_name"])}").Trim()} - {($"{Convert.ToString(snpEng["emgp_program_name"])}").Trim()}";
						modGlobalVars.Engine_ArrayData[nCounter] = Double.Parse($"0{($"{Convert.ToString(snpEng["emgp_id"])}").Trim()}").ToString();
						nCounter++;
						snpEng.MoveNext();
					};
				}

				snpEng.Close();
				snpEng = null;


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Engine_Management_CBO_Array_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}
			return false;
		}
		internal static bool Fill_State_Array()
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_State = new ADORecordSetHelper();

				Query = "SELECT * FROM State WITH(NOLOCK) WHERE state_active_flag = 'Y'  ORDER BY state_code";
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

				ado_State.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_State.BOF && ado_State.EOF))
				{
					nRecCount = ado_State.RecordCount;

					modGlobalVars.State_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!ado_State.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_State["State_code"]))
						{
							if (Convert.ToString(ado_State["State_code"]).Trim() != "")
							{
								modGlobalVars.State_Array[nCounter] = $"{($"{Convert.ToString(ado_State["State_code"]).Trim()}, {Convert.ToString(ado_State["state_country"]).Trim()}")}, {Convert.ToString(ado_State["state_timezone"]).Trim()}, {Convert.ToString(ado_State["state_name"]).Trim()}";
								nCounter++;
							}
						}

						ado_State.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_State.Close();
				ado_State = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_State_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(STATE)");
				return result;
			}
		}

		internal static bool Fill_AccountRep_Array()
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_AccountRep = new ADORecordSetHelper();

				Query = "SELECT accrep_account_id FROM Account_Rep WITH(NOLOCK) ORDER BY accrep_account_id ";
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

				ado_AccountRep.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_AccountRep.BOF && ado_AccountRep.EOF))
				{
					nRecCount = ado_AccountRep.RecordCount;

					modGlobalVars.AccountRep_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!ado_AccountRep.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_AccountRep["accrep_account_id"]))
						{
							if (Convert.ToString(ado_AccountRep["accrep_account_id"]).Trim() != "")
							{
								modGlobalVars.AccountRep_Array[nCounter] = Convert.ToString(ado_AccountRep["accrep_account_id"]).Trim();
								nCounter++;
							}
						}

						ado_AccountRep.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_AccountRep.Close();
				ado_AccountRep = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_AccountRep_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(ACCTREP)");
				return result;
			}
		}

		internal static bool Fill_CompanyProduct_Array()
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper snp_ProductList = new ADORecordSetHelper();

				Query = "SELECT * FROM product_codes WITH(NOLOCK) ORDER by prod_code";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				snp_ProductList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_ProductList.BOF && snp_ProductList.EOF))
				{
					nRecCount = snp_ProductList.RecordCount;

					modGlobalVars.CompanyProduct_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!snp_ProductList.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_ProductList["Prod_code"]))
						{
							if (Convert.ToString(snp_ProductList["Prod_code"]).Trim() != "")
							{
								modGlobalVars.CompanyProduct_Array[nCounter] = $"{Convert.ToString(snp_ProductList["Prod_code"]).Trim()} {Convert.ToString(snp_ProductList["Prod_description"]).Trim()}";
								nCounter++;
							}
						}

						snp_ProductList.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				snp_ProductList.Close();
				snp_ProductList = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_CompanyProduct_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(COMPPRODUCT)");
				return result;
			}
		}

		internal static bool Fill_ContactSuffix_Array()
		{


			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper snp_Suffix = new ADORecordSetHelper();

				Query = "SELECT * FROM Contact_Suffix WITH(NOLOCK) ORDER BY csuffix_name";
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

				snp_Suffix.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Suffix.BOF && snp_Suffix.EOF))
				{
					nRecCount = snp_Suffix.RecordCount;

					modGlobalVars.ContactSuffix_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!snp_Suffix.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_Suffix["csuffix_name"]))
						{
							if (Convert.ToString(snp_Suffix["csuffix_name"]).Trim() != "")
							{
								modGlobalVars.ContactSuffix_Array[nCounter] = Convert.ToString(snp_Suffix["csuffix_name"]).Trim();
								nCounter++;
							}
						}

						snp_Suffix.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				snp_Suffix.Close();
				snp_Suffix = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_ContactSuffix_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(SUFFIX)");
				return result;
			}
		}

		internal static bool Fill_ContactSurname_Array()
		{


			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper snp_Sirname = new ADORecordSetHelper();

				Query = "SELECT * FROM Contact_Sirname WITH(NOLOCK) ORDER BY csir_name";
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

				snp_Sirname.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Sirname.BOF && snp_Sirname.EOF))
				{

					nRecCount = snp_Sirname.RecordCount;

					modGlobalVars.ContactSirname_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!snp_Sirname.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_Sirname["csir_name"]))
						{
							if (Convert.ToString(snp_Sirname["csir_name"]).Trim() != "")
							{
								modGlobalVars.ContactSirname_Array[nCounter] = Convert.ToString(snp_Sirname["csir_name"]).Trim();
								nCounter++;
							}
						}

						snp_Sirname.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				snp_Sirname.Close();
				snp_Sirname = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_ContactSurname_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(SURNAME)");
				return result;
			}
		}

		internal static bool Fill_TitleGroup_Array()
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper snpGroup = new ADORecordSetHelper();

				Query = "SELECT * FROM Contact_Title_Group WITH(NOLOCK) ORDER BY ctitleg_group_name";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				snpGroup.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpGroup.BOF && snpGroup.EOF))
				{

					nRecCount = snpGroup.RecordCount;

					modGlobalVars.TitleGroup_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!snpGroup.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpGroup["ctitleg_group_name"]))
						{
							if (Convert.ToString(snpGroup["ctitleg_group_name"]).Trim() != "")
							{
								modGlobalVars.TitleGroup_Array[nCounter] = Convert.ToString(snpGroup["ctitleg_group_name"]).Trim();
								nCounter++;
							}
						}

						snpGroup.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				snpGroup.Close();
				snpGroup = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_TitleGroup_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(TITLEGROUP)");
				return result;
			}
		}

		internal static bool Fill_AccountType_Array()
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_AccountType = new ADORecordSetHelper();

				Query = "SELECT * FROM Company_Account_Type WITH(NOLOCK) ORDER BY cacctype_name";
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

				ado_AccountType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_AccountType.BOF && ado_AccountType.EOF))
				{

					nRecCount = ado_AccountType.RecordCount;

					modGlobalVars.AccountType_Array = ArraysHelper.InitializeArray<string[, ]>(new int[]{nRecCount, modGlobalVars.MAX_ACCT_DIMENSIONS + 1}, new int[]{0, 0});

					nCounter = 0;


					while(!ado_AccountType.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_AccountType["cacctype_name"]) && !Convert.IsDBNull(ado_AccountType["cacctype_code"]))
						{

							if (Convert.ToString(ado_AccountType["cacctype_name"]).Trim() != "" && Convert.ToString(ado_AccountType["cacctype_code"]).Trim() != "")
							{
								modGlobalVars.AccountType_Array[nCounter, modGlobalVars.ACCTTYPE_CODE] = Convert.ToString(ado_AccountType["cacctype_code"]).Trim();
								modGlobalVars.AccountType_Array[nCounter, modGlobalVars.ACCTTYPE_NAME] = Convert.ToString(ado_AccountType["cacctype_name"]).Trim();
								nCounter++;
							}

						}

						ado_AccountType.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_AccountType.Close();
				ado_AccountType = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_AccountType_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(ACCTTYPE)");
				return result;
			}
		}

		internal static bool Fill_AgencyType_Array()
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_AgencyType = new ADORecordSetHelper();

				Query = "SELECT cagtype_name FROM Company_Agency_Type WITH(NOLOCK) ORDER BY cagtype_name";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				ado_AgencyType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_AgencyType.BOF && ado_AgencyType.EOF))
				{

					nRecCount = ado_AgencyType.RecordCount;

					modGlobalVars.AgencyType_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!ado_AgencyType.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_AgencyType["cagtype_name"]))
						{
							if (Convert.ToString(ado_AgencyType["cagtype_name"]).Trim() != "")
							{
								modGlobalVars.AgencyType_Array[nCounter] = Convert.ToString(ado_AgencyType["cagtype_name"]).Trim();
								nCounter++;
							}
						}

						ado_AgencyType.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_AgencyType.Close();
				ado_AgencyType = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_AgencyType_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(AGENCY)");
				return result;
			}
		}

		internal static bool Fill_BusinessType_Array(bool ignore_yacht = false)
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_BusinessType = new ADORecordSetHelper();



				if (ignore_yacht)
				{
					Query = "SELECT * FROM Company_Business_Type WITH(NOLOCK) where cbus_aircraft_flag = 'Y' ORDER BY cbus_abi_flag, cbus_name";
				}
				else
				{
					Query = "SELECT * FROM Company_Business_Type WITH(NOLOCK) ORDER BY cbus_abi_flag, cbus_name";
				}


				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

				ado_BusinessType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_BusinessType.BOF && ado_BusinessType.EOF))
				{

					nRecCount = ado_BusinessType.RecordCount;

					// 2 Dimensions ( first is name, second is abi flag )
					modGlobalVars.BusinessType_Array = ArraysHelper.InitializeArray<string[, ]>(new int[]{nRecCount, modGlobalVars.MAX_CBUS_DIMENSIONS + 1}, new int[]{0, 0});
					nCounter = 0;


					while(!ado_BusinessType.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_BusinessType["cbus_name"]))
						{

							if (Convert.ToString(ado_BusinessType["cbus_abi_flag"]).ToUpper() == "Y")
							{
								modGlobalVars.BusinessType_Array[nCounter, modGlobalVars.CBUS_TYPENAME] = $"{Convert.ToString(ado_BusinessType["cbus_type"]).Trim()} - * {Convert.ToString(ado_BusinessType["cbus_name"]).Trim()} - (ABI)";
								modGlobalVars.BusinessType_Array[nCounter, modGlobalVars.CBUS_ABIFLAG] = Convert.ToString(ado_BusinessType["cbus_abi_flag"]).Trim();
								modGlobalVars.BusinessType_Array[nCounter, modGlobalVars.CBUS_YACHTFLAG] = Convert.ToString(ado_BusinessType["cbus_yacht_flag"]).Trim();
							}
							else if (Convert.ToString(ado_BusinessType["cbus_yacht_flag"]).ToUpper() == "Y")
							{ 
								modGlobalVars.BusinessType_Array[nCounter, modGlobalVars.CBUS_TYPENAME] = $"{Convert.ToString(ado_BusinessType["cbus_type"]).Trim()} - {Convert.ToString(ado_BusinessType["cbus_name"]).Trim()}";
								modGlobalVars.BusinessType_Array[nCounter, modGlobalVars.CBUS_ABIFLAG] = Convert.ToString(ado_BusinessType["cbus_abi_flag"]).Trim();
								modGlobalVars.BusinessType_Array[nCounter, modGlobalVars.CBUS_YACHTFLAG] = Convert.ToString(ado_BusinessType["cbus_yacht_flag"]).Trim();
							}
							else
							{
								modGlobalVars.BusinessType_Array[nCounter, modGlobalVars.CBUS_TYPENAME] = $"{Convert.ToString(ado_BusinessType["cbus_type"]).Trim()} - {Convert.ToString(ado_BusinessType["cbus_name"]).Trim()}";
								modGlobalVars.BusinessType_Array[nCounter, modGlobalVars.CBUS_ABIFLAG] = Convert.ToString(ado_BusinessType["cbus_abi_flag"]).Trim();
								modGlobalVars.BusinessType_Array[nCounter, modGlobalVars.CBUS_YACHTFLAG] = Convert.ToString(ado_BusinessType["cbus_yacht_flag"]).Trim();
							}

							nCounter++;

						}

						ado_BusinessType.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_BusinessType.Close();
				ado_BusinessType = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_BusinessType_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(BUSTYPE)");
				return result;
			}
		}

		internal static bool Fill_Language_Array()
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_Language = new ADORecordSetHelper();

				Query = "SELECT language_name FROM Language WITH(NOLOCK) ORDER BY language_name";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				ado_Language.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_Language.BOF && ado_Language.EOF))
				{

					nRecCount = ado_Language.RecordCount;

					modGlobalVars.Language_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!ado_Language.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_Language["language_name"]))
						{
							if (Convert.ToString(ado_Language["language_name"]).Trim() != "")
							{
								modGlobalVars.Language_Array[nCounter] = Convert.ToString(ado_Language["language_name"]).Trim();
								nCounter++;
							}
						}

						ado_Language.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_Language.Close();
				ado_Language = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Language_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(LANGUAGE)");
				return result;
			}
		}

		internal static bool Fill_PhoneType_Array()
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_PhoneType = new ADORecordSetHelper();

				Query = "SELECT ptype_name FROM Phone_Type WITH(NOLOCK) ORDER BY ptype_seq_no";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				ado_PhoneType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_PhoneType.BOF && ado_PhoneType.EOF))
				{
					nRecCount = ado_PhoneType.RecordCount;

					modGlobalVars.PhoneType_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!ado_PhoneType.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_PhoneType["ptype_name"]))
						{
							if (Convert.ToString(ado_PhoneType["ptype_name"]).Trim() != "")
							{
								modGlobalVars.PhoneType_Array[nCounter] = Convert.ToString(ado_PhoneType["ptype_name"]).Trim();
								nCounter++;
							}
						}

						ado_PhoneType.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_PhoneType.Close();
				ado_PhoneType = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_PhoneType_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(PHONETYPE)");
				return result;
			}
		}

		internal static bool Fill_TimeZone_Array()
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_TimeZone = new ADORecordSetHelper();

				Query = "SELECT * FROM Timezone WITH(NOLOCK) ORDER BY tzone_name";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				ado_TimeZone.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_TimeZone.BOF && ado_TimeZone.EOF))
				{
					nRecCount = ado_TimeZone.RecordCount;

					modGlobalVars.TimeZone_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!ado_TimeZone.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_TimeZone["TZONE_name"]))
						{
							if (Convert.ToString(ado_TimeZone["TZONE_name"]) != "")
							{
								modGlobalVars.TimeZone_Array[nCounter] = Convert.ToString(ado_TimeZone["TZONE_name"]).Trim();
								nCounter++;
							}
						}

						ado_TimeZone.MoveNext();

					};


				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_TimeZone.Close();
				ado_TimeZone = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_TimeZone_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(TIMEZONE)");
				return result;
			}
		}

		internal static bool Fill_Country_Array()
		{

			bool result = false;
			try
			{
				result = false;

				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_Country = new ADORecordSetHelper();

				Query = "SELECT * FROM Country WITH(NOLOCK) WHERE country_active_flag = 'Y' ORDER BY country_name";
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

				ado_Country.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_Country.BOF && ado_Country.EOF))
				{

					nRecCount = ado_Country.RecordCount;

					modGlobalVars.Country_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!ado_Country.EOF)
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_Country["country_name"]))
						{
							if (Convert.ToString(ado_Country["country_name"]) != "")
							{
								modGlobalVars.Country_Array[nCounter] = Convert.ToString(ado_Country["country_name"]).Trim();
								nCounter++;
							}
						}

						ado_Country.MoveNext();

					};
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_Country.Close();
				ado_Country = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Country_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(COUNTRY)");
				return result;
			}
		}

		internal static bool Fill_Services_Used(bool bFillCombo, ComboBox cboLocalServicesUsed = null)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int iRec1 = 0;
			int iCnt1 = 0;


			try
			{

				if (bFillCombo)
				{
					if (cboLocalServicesUsed.Text != "")
					{
						return result;
					}
				}

				strQuery1 = "SELECT * FROM Services_Used WITH(NOLOCK) ORDER BY svud_desc ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(rstRec1.BOF && rstRec1.EOF))
				{
					iRec1 = rstRec1.RecordCount;

					if (iRec1 > 0)
					{

						if (bFillCombo)
						{
							cboLocalServicesUsed.Items.Clear();
						}

						modGlobalVars.ServicesUsed_Array = Array.CreateInstance(typeof(string), new int[]{iRec1, modGlobalVars.MAX_SERVICE_DIMENSIONS + 1}, new int[]{1, 0});
						iCnt1 = 0;

						do 
						{ // Loop Until (rstRec1.EOF = True) Or (iCnt1 >= iRec1)

							iCnt1++;
							modGlobalVars.ServicesUsed_Array.SetValue(Convert.ToString(rstRec1["svud_code"]).Trim(), iCnt1, modGlobalVars.SERVICE_CODE);
							modGlobalVars.ServicesUsed_Array.SetValue(Convert.ToString(rstRec1["svud_desc"]).Trim(), iCnt1, modGlobalVars.SERVICE_DESCRIPTION);

							if (bFillCombo)
							{
								cboLocalServicesUsed.AddItem(Convert.ToString(rstRec1["svud_desc"]).Trim());
							}

							rstRec1.MoveNext();

						}
						while(!((rstRec1.EOF) || (iCnt1 >= iRec1)));

						if (bFillCombo)
						{
							cboLocalServicesUsed.SelectedIndex = -1;
						}

						result = true;

					} // If iRec1 > 0 Then

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;

				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Services_Used_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(SERVICESUSED)");

				return result;
			}
		}


		internal static string Fill_Company_Services_Used(int Comp_id, ref string abbrev_string)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int iRec1 = 0;
			int iCnt1 = 0;
			string temp_sp = "     ";
			int temp_length = 0;
			int i = 0;
			string temp_string = "";
			string temp_sp40 = "              ";


			abbrev_string = "";

			try
			{

				strQuery1 = " select svud_desc, csu_verified_date, csu_end_date, csu_notes  from company_services_used with (NOLOCK) ";
				strQuery1 = $"{strQuery1} inner join services_used with (NOLOCK) on svud_id = csu_svud_id inner Join company with (NOLOCK) on csu_comp_id = comp_id And comp_journ_id = 0 ";
				strQuery1 = $"{strQuery1}  where  csu_comp_id = {Comp_id.ToString()}  order by svud_desc desc  ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				result = "";
				result = $"{result}Service{temp_sp40}Verified{temp_sp}End Date{temp_sp}Notes     ";
				result = $"{result}{Environment.NewLine}";

				if (!(rstRec1.BOF && rstRec1.EOF))
				{
					iRec1 = rstRec1.RecordCount;


					while(!rstRec1.EOF)
					{


						iCnt1++;


						result = $"{result}{Convert.ToString(rstRec1["svud_desc"]).Trim().ToUpper()}";

						if (abbrev_string.Trim() != "")
						{
							abbrev_string = $"{abbrev_string}, ";
						}
						abbrev_string = $"{abbrev_string}{Convert.ToString(rstRec1["svud_desc"]).Trim().ToUpper()}";

						result = $"{result}{check_size_return_spaces(Convert.ToString(rstRec1["svud_desc"]).Trim(), 20)}";

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(Convert.ToString(rstRec1["csu_verified_date"]).Trim()))
						{
							result = $"{result}{Convert.ToString(rstRec1["csu_verified_date"]).Trim().Substring(0, Math.Min(10, Convert.ToString(rstRec1["csu_verified_date"]).Trim().Length))}";
							result = $"{result}{check_size_return_spaces(Convert.ToString(rstRec1["csu_verified_date"]).Trim().Substring(0, Math.Min(10, Convert.ToString(rstRec1["csu_verified_date"]).Trim().Length)), 12)}";
						}
						else
						{
							result = $"{result}{temp_sp}";
							result = $"{result}{check_size_return_spaces(temp_sp, 12)}";
						}


						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(Convert.ToString(rstRec1["csu_end_date"]).Trim()))
						{
							result = $"{result}{Convert.ToString(rstRec1["csu_end_date"]).Trim().Substring(0, Math.Min(10, Convert.ToString(rstRec1["csu_end_date"]).Trim().Length))}";
							result = $"{result}{check_size_return_spaces(Convert.ToString(rstRec1["csu_end_date"]).Trim().Substring(0, Math.Min(10, Convert.ToString(rstRec1["csu_end_date"]).Trim().Length)), 12)}";
						}
						else
						{
							result = $"{result}{temp_sp}";
							result = $"{result}{check_size_return_spaces(temp_sp, 12)}";
						}


						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(Convert.ToString(rstRec1["csu_notes"]).Trim()))
						{
							result = $"{result}{Convert.ToString(rstRec1["csu_notes"]).Trim().Substring(0, Math.Min(25, Convert.ToString(rstRec1["csu_notes"]).Trim().Length))}";
						}
						else
						{
							result = $"{result}{temp_sp}";
						}



						result = $"{result}{Environment.NewLine}";

						rstRec1.MoveNext();
					};

					result = $"{result} ";
				}
				else
				{
					result = $"{result}NONE REPORTED - DOUBLE CLICK TO ADD";
				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;

				return result;
			}
			catch (System.Exception excep)
			{

				result = (false).ToString();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Company_Services_Used_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(SERVICESUSED)");

				return result;
			}
		}
		internal static string check_size_return_spaces(string string_in, int size)
		{

			string result = "";

			int temp_length = 0;
			temp_length = Strings.Len(string_in.Trim());

			if (temp_length > 0)
			{
				int tempForEndVar = size;
				for (int i = temp_length; i <= tempForEndVar; i++)
				{
					result = $"{result} ";
				}
			}


			return result;
		}




		internal static bool Fill_ContactType_Array()
		{

			bool result = false;
			string sQuery = "";
			int nRecCount = 0;
			int nCounter = 0;
			ADORecordSetHelper ado_ContactType = new ADORecordSetHelper();

			try
			{

				result = false;

				sQuery = "SELECT * FROM Aircraft_Contact_Type WITH (NOLOCK) WHERE (actype_active_flag = 'Y') ORDER BY actype_name, actype_code";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

				ado_ContactType.Open(sQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_ContactType.BOF && ado_ContactType.EOF))
				{

					nRecCount = ado_ContactType.RecordCount;

					modGlobalVars.ContactType_Array = ArraysHelper.InitializeArray<string[, ]>(new int[]{nRecCount, modGlobalVars.MAX_AIRCONT_DIMENSIONS + 1}, new int[]{0, 0});
					nCounter = 0;


					while(!ado_ContactType.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_ContactType["actype_name"]))
						{

							modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_INDEX] = nCounter.ToString();

							modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_NAME] = Convert.ToString(ado_ContactType["actype_name"]).Trim();

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ContactType["actype_code"]))
							{
								modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_TYPE] = Convert.ToString(ado_ContactType["actype_code"]).Trim();
							}
							else
							{
								modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_TYPE] = "";
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ContactType["actype_use_flag"]))
							{
								modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_USE] = Convert.ToString(ado_ContactType["actype_use_flag"]).Trim();
							}
							else
							{
								modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_USE] = "";
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ContactType["actype_compref_flag"]))
							{
								modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_COMP] = Convert.ToString(ado_ContactType["actype_compref_flag"]).Trim();
							}
							else
							{
								modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_COMP] = "";
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ContactType["actype_shareref_flag"]))
							{
								modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_SHARE] = Convert.ToString(ado_ContactType["actype_shareref_flag"]).Trim();
							}
							else
							{
								modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_SHARE] = "";
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ContactType["actype_compref_name2"]))
							{
								modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_NAMEREF] = Convert.ToString(ado_ContactType["actype_compref_name2"]).Trim();
							}
							else
							{
								modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_NAMEREF] = "";
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ContactType["actype_compref_internal_flag"]))
							{
								modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_INTERNAL] = Convert.ToString(ado_ContactType["actype_compref_internal_flag"]).Trim();
							}
							else
							{
								modGlobalVars.ContactType_Array[nCounter, modGlobalVars.AIRCONT_INTERNAL] = "";
							}

							nCounter++;
						}

						ado_ContactType.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_ContactType.Close();
				ado_ContactType = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_ContactType_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(CONTACTTYPE)");
				return result;
			}
		} // Fill_ContactType_Array

		internal static bool Fill_Purchase_Question_Array()
		{

			bool result = false;
			try
			{
				result = false;

				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_Question = new ADORecordSetHelper();

				Query = "SELECT * FROM Aircraft_Purchased_Question WITH(NOLOCK) ORDER BY acpq_question";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				ado_Question.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_Question.BOF && ado_Question.EOF))
				{

					nRecCount = ado_Question.RecordCount;

					modGlobalVars.PurchaseQuestion_Array = ArraysHelper.InitializeArray<string[, ]>(new int[]{nRecCount, modGlobalVars.MAX_PURQUEST_DIMENSIONS + 1}, new int[]{0, 0});
					nCounter = 0;


					while(!ado_Question.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_Question["acpq_question"]))
						{
							if (Convert.ToString(ado_Question["acpq_question"]).Trim() != "")
							{
								modGlobalVars.PurchaseQuestion_Array[nCounter, modGlobalVars.PURQUEST_ID] = Convert.ToString(ado_Question["acpq_id"]).Trim();
								modGlobalVars.PurchaseQuestion_Array[nCounter, modGlobalVars.PURQUEST_NAME] = Convert.ToString(ado_Question["acpq_question"]).Trim();
								nCounter++;
							}
						}

						ado_Question.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_Question.Close();
				ado_Question = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Purchase_Question_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(QUESTION)");
				return result;
			}
		}

		internal static bool Fill_WantedModel_Array(bool bIncludeAll = false)
		{

			bool result = false;
			string sQuery = "";
			int nRecCount = 0;
			int nCounter = 0;
			ADORecordSetHelper ado_WantedModel = new ADORecordSetHelper();

			try
			{

				result = false;

				sQuery = "SELECT DISTINCT amod_make_name, amod_model_name, amod_id, amod_start_year, amod_end_year, amod_class_code ";
				sQuery = $"{sQuery}FROM Aircraft_Model WITH (NOLOCK) ";
				if (!bIncludeAll)
				{
					sQuery = $"{sQuery}WHERE (amod_customer_flag = 'Y') ";
				}
				sQuery = $"{sQuery}ORDER BY amod_make_name, amod_model_name, amod_id ";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

				ado_WantedModel.Open(sQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_WantedModel.BOF && ado_WantedModel.EOF))
				{

					nRecCount = ado_WantedModel.RecordCount;

					// 4 Dimensions ( first is index, make, model, start, end, etc )
					modGlobalVars.WantedModel_Array = ArraysHelper.InitializeArray<string[, ]>(new int[]{nRecCount, modGlobalVars.MAX_WANTED_DIMENSIONS + 1}, new int[]{0, 0});
					nCounter = 0;


					while(!ado_WantedModel.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_WantedModel["amod_id"]))
						{

							modGlobalVars.WantedModel_Array[nCounter, modGlobalVars.WANTED_ID] = Convert.ToString(ado_WantedModel["amod_id"]);

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_WantedModel["amod_make_name"]))
							{
								modGlobalVars.WantedModel_Array[nCounter, modGlobalVars.WANTED_MAKE] = Convert.ToString(ado_WantedModel["amod_make_name"]).Trim();
							}
							else
							{
								modGlobalVars.WantedModel_Array[nCounter, modGlobalVars.WANTED_MAKE] = "";
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_WantedModel["amod_model_name"]))
							{
								modGlobalVars.WantedModel_Array[nCounter, modGlobalVars.WANTED_MODEL] = Convert.ToString(ado_WantedModel["amod_model_name"]).Trim();
							}
							else
							{
								modGlobalVars.WantedModel_Array[nCounter, modGlobalVars.WANTED_MODEL] = "";
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_WantedModel["amod_start_year"]))
							{
								modGlobalVars.WantedModel_Array[nCounter, modGlobalVars.WANTED_START] = Convert.ToString(ado_WantedModel["amod_start_year"]).Trim();
							}
							else
							{
								modGlobalVars.WantedModel_Array[nCounter, modGlobalVars.WANTED_START] = "";
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_WantedModel["amod_end_year"]))
							{
								modGlobalVars.WantedModel_Array[nCounter, modGlobalVars.WANTED_END] = Convert.ToString(ado_WantedModel["amod_end_year"]).Trim();
							}
							else
							{
								modGlobalVars.WantedModel_Array[nCounter, modGlobalVars.WANTED_END] = "";
							}

							nCounter++;
						}

						ado_WantedModel.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_WantedModel.Close();
				ado_WantedModel = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_WantedModel_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(WANTEDMOD)");
				return result;
			}
		}



		internal static bool Fill_Contact_Title_Array()
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_Contact_Title = new ADORecordSetHelper();

				Query = "SELECT DISTINCT ctitle_name FROM Contact_Title WITH(NOLOCK) order by ctitle_name asc ";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				ado_Contact_Title.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_Contact_Title.BOF && ado_Contact_Title.EOF))
				{

					nRecCount = ado_Contact_Title.RecordCount;

					modGlobalVars.ContactTitle_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!ado_Contact_Title.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_Contact_Title["ctitle_name"]))
						{
							if (Convert.ToString(ado_Contact_Title["ctitle_name"]).Trim() != "")
							{
								modGlobalVars.ContactTitle_Array[nCounter] = Convert.ToString(ado_Contact_Title["ctitle_name"]).Trim();
								nCounter++;
							}
						}

						ado_Contact_Title.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_Contact_Title.Close();
				ado_Contact_Title = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Contact_Title_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(AGENCY)");
				return result;
			}
		}

		internal static bool Fill_Continent_Array()
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_Continent = new ADORecordSetHelper();

				Query = "SELECT continent_name FROM Continent WITH(NOLOCK) ORDER BY continent_name";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				ado_Continent.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_Continent.BOF && ado_Continent.EOF))
				{

					nRecCount = ado_Continent.RecordCount;

					modGlobalVars.Continent_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;


					while(!ado_Continent.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_Continent["continent_name"]))
						{
							if (Convert.ToString(ado_Continent["continent_name"]).Trim() != "")
							{
								modGlobalVars.Continent_Array[nCounter] = Convert.ToString(ado_Continent["continent_name"]).Trim();
								nCounter++;
							}
						}

						ado_Continent.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_Continent.Close();
				ado_Continent = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Continent_ArrayError ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(LANGUAGE)");
				return result;
			}
		}

		internal static bool Fill_Mail_Lists_Array()
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_MailList = new ADORecordSetHelper();

				Query = "select jcat_subcategory_code,jcat_subcategory_name from journal_category ";
				Query = $"{Query}where jcat_category_code='ML'  order by jcat_subcategory_name ";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				ado_MailList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_MailList.BOF && ado_MailList.EOF))
				{

					nRecCount = ado_MailList.RecordCount;

					modGlobalVars.MailList_Array = ArraysHelper.InitializeArray<string>(nRecCount);
					nCounter = 0;

					while(!ado_MailList.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_MailList["jcat_subcategory_name"]))
						{
							if (Convert.ToString(ado_MailList["jcat_subcategory_name"]).Trim() != "")
							{
								modGlobalVars.MailList_Array[nCounter] = $"{Convert.ToString(ado_MailList["jcat_subcategory_code"]).Trim()}-{Convert.ToString(ado_MailList["jcat_subcategory_name"]).Trim()}";
								nCounter++;
							}
						}

						ado_MailList.MoveNext();

					};

				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_MailList.Close();
				ado_MailList = null;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Mail_Lists_Array_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modFillCommonArrays(LANGUAGE)");
				return result;
			}
		}
	}
}