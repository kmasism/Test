using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal static class modUserHoursWorked
	{


		//---------------------------------------------------------------------------------
		// Modified Date: 10/11/2019 - By David D. Cruger


		private static string gstrExcludeUsers = "";
		private static string gstrTempTableName = "";
		private static string gstrGroup = "";
		private static string gstrFieldCode = "";
		private static string gstrFieldName = "";
		private static int glFieldCount = 0;
		private static string gstrStartDate = "";
		private static string gstrEndDate = "";
		private static string gstrTimeRange = "";
		private static string gstrUserId = "";
		private static string gstrACCTRep = "";
		private static string gstrUserName = "";
		private static string gstrUserFName = "";
		private static string gstrUserLName = "";
		private static string gstrTeamLeaderUserId = "";
		private static string gstrTeamLeaderTeam = "";
		private static string gstrReportName = "";

		private static int glStartRowGoals = 0;
		private static int glEndRowGoals = 0;
		private static int glStartRowAvg = 0;
		private static int glEndRowAvg = 0;

		//=========================================================================================================
		//=========================================================================================================

		internal static void Clear_UserHoursWorked_Private_Variables()
		{

			gstrTempTableName = "";
			gstrStartDate = "";
			gstrEndDate = "";
			gstrTeamLeaderUserId = "";
			gstrTeamLeaderTeam = "";
			gstrReportName = "";


			gstrGroup = "";
			gstrFieldCode = "";
			gstrFieldName = "";
			glFieldCount = 0;
			gstrUserId = "";
			gstrACCTRep = "";
			gstrUserName = "";
			gstrUserFName = "";
			gstrUserLName = "";

			glStartRowGoals = 0;
			glEndRowGoals = 0;
			glStartRowAvg = 0;
			glEndRowAvg = 0;

			if (gstrExcludeUsers == "")
			{
				gstrExcludeUsers = modCommon.DLookUp("aconfig_exclude_users", "Application_Configuration");
			}

		} // Clear_UserHoursWorked_Private_Variables


		internal static string Get_UserHoursWorked_Private_Start_Date() => gstrStartDate;
		 // Get_UserHoursWorked_Private_Start_Date


		internal static string Get_UserHoursWorked_Private_End_Date() => gstrEndDate;
		 // Get_UserHoursWorked_Private_End_Date


		internal static void Set_UserHoursWorked_Private_Start_End_Dates(string strStartDate, string strEndDate)
		{

			gstrStartDate = strStartDate;
			gstrEndDate = strEndDate;

		} // Set_UserHoursWorked_Private_Variables


		internal static void Set_UserHoursWorked_Private_Variables(string strTempTableName, string strStartDate, string strEndDate, string strTimeRange, string strTeamLeaderUserId, string strTeamLeaderTeam, string strReportName)
		{

			gstrTempTableName = strTempTableName;
			gstrStartDate = strStartDate;
			gstrEndDate = strEndDate;
			gstrTimeRange = strTimeRange;
			gstrTeamLeaderUserId = strTeamLeaderUserId;
			gstrTeamLeaderTeam = strTeamLeaderTeam;
			gstrReportName = strReportName;

			if (gstrExcludeUsers == "")
			{
				gstrExcludeUsers = modCommon.DLookUp("aconfig_exclude_users", "Application_Configuration");
			}

		} // Set_UserHoursWorked_Private_Variables

		//=========================================================================================================

		internal static string FormatPercentage(double dTotal, double dRec)
		{


			double dResults = dRec / dTotal * 100;
			string strResults = $"{Strings.FormatNumber(dResults, 2, TriState.True, TriState.UseDefault, TriState.UseDefault)}%";

			return strResults;

		} // FormatPercentage

		internal static void Load_Report_Combo_Box(ComboBox cmbBox, string strUserId = "")
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbBox.Items.Clear();
				cmbBox.AddItem("");

				strQuery1 = "SELECT DISTINCT ur_report_name FROM User_Reports WITH (NOLOCK) WHERE (ur_active_flag = 'Y') ";

				if (strUserId != "")
				{
					strQuery1 = $"{strQuery1}AND (ur_user_id = '{strUserId.ToLower()}') ";
				}

				strQuery1 = $"{strQuery1}ORDER BY ur_report_name ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{

						cmbBox.AddItem(($"{Convert.ToString(rstRec1["ur_report_name"])} ").Trim());
						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

					cmbBox.SelectedIndex = 0;

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_Report_Combo_Box_Error", excep.Message);
			}

		} // Load_Report_Combo_Box

		internal static void Load_Team_Leader_Combo_Box(ComboBox cmbBox)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbBox.Items.Clear();
				strQuery1 = "SELECT user_id, user_first_name, user_last_name FROM [USER] WITH( NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (user_team_leader_flag = 'Y') AND (user_password <> 'Inactive') ";
				strQuery1 = $"{strQuery1}ORDER BY user_first_name, user_last_name ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					cmbBox.AddItem("");

					do 
					{

						cmbBox.AddItem($"{($"{Convert.ToString(rstRec1["user_id"])} ").Trim().ToUpper()} - {($"{Convert.ToString(rstRec1["user_first_name"])} ").Trim().ToUpper()} {($"{Convert.ToString(rstRec1["user_last_name"])} ").Trim().ToUpper()}");
						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

					cmbBox.SelectedIndex = 0;

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Load_Team_Leader_Combo_Box_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

		} // Load_Team_Leader_Combo_Box


		internal static string Return_Team_Leaders_Team(string strTeamLeader, string strReportName = "")
		{

			string strTeam = "";

			string strResults = "";

			strTeamLeader = strTeamLeader.Trim();

			if (strTeamLeader != "")
			{

				if (strReportName == "")
				{
					strTeam = modCommon.DLookUp("ur_team_leader_team", "[User_Reports]", $"(ur_active_flag = 'Y') AND (ur_user_id = '{strTeamLeader}') AND (ur_report_name = '{gstrReportName}')");
				}
				else
				{
					strTeam = modCommon.DLookUp("ur_team_leader_team", "[User_Reports]", $"(ur_active_flag = 'Y') AND (ur_user_id = '{strTeamLeader}') AND (ur_report_name = '{strReportName}')");
				}

				if (strTeam == "")
				{
					strTeam = strTeamLeader;
				}
				else
				{
					strTeam = $"{strTeam},{strTeamLeader}";
				}

				strTeam = StringsHelper.Replace(strTeam, " ", "", 1, -1, CompareMethod.Binary);
				strTeam = $"'{StringsHelper.Replace(strTeam, ",", "','", 1, -1, CompareMethod.Binary)}'";

				strResults = strTeam.ToLower();

			} // If strTeamLeader <> "" Then

			return strResults;

		} // Return_Team_Leaders_Team

		//=========================================================================================================
		//=========================================================================================================

		internal static string Return_Field_Codes_For_Report(DbConnection cntConn, string strReportName)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strResults = "";

			try
			{

				strResults = "";

				strQuery1 = "SELECT DISTINCT uar_report_code As FieldCode,uar_report_name As ReportName ";
				strQuery1 = $"{strQuery1}FROM User_Activity_Reports WITH (NOLOCK) WHERE (uar_productivity_report = '{strReportName}')";
				strQuery1 = $"{strQuery1}ORDER BY uar_report_name ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					strResults = "";
					do 
					{ // Loop Until rstRec1.EOF = True
						strResults = $"{strResults}{($"{Convert.ToString(rstRec1["FieldCode"])} ").Trim()},";
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);

					strResults = strResults.Substring(0, Math.Min(Strings.Len(strResults) - 1, strResults.Length)); // Remove Last Comma
					strResults = $"'{StringsHelper.Replace(strResults, ",", "','", 1, -1, CompareMethod.Binary)}'";

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Return_Field_Codes_For_Report_Error", excep.Message);

				result = "";
			}
			return result;
		} // Return_Field_Codes_For_Report


		private static void Add_Account_Rep_Activity_Record_To_Temp_Table(DbConnection cntConn, string strUserId, int lFieldCount)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strAcctRep = "";
			string strUserName = "";
			string strFName = "";
			string strLName = "";

			string strInsert1 = "";

			try
			{

				strQuery1 = $"SELECT * FROM [User] WHERE (user_id = '{strUserId}') ";
				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					strInsert1 = $"INSERT INTO {gstrTempTableName} ";
					strInsert1 = $"{strInsert1}( ara_startdate, ara_enddate, ara_acctrep, ";
					strInsert1 = $"{strInsert1}ara_acctrep_user_id, ara_acctrep_name,  ara_acctrep_fname, ";
					strInsert1 = $"{strInsert1}ara_acctrep_lname, ara_field_group, ara_field_code,  ara_field_name, ";
					strInsert1 = $"{strInsert1}ara_field_count ) VALUES ( ";

					if (gstrStartDate != "")
					{
						if (Information.IsDate(gstrStartDate))
						{
							strInsert1 = $"{strInsert1}'{gstrStartDate}', ";
						}
						else
						{
							strInsert1 = $"{strInsert1}NULL, ";
						}
					}
					else
					{
						strInsert1 = $"{strInsert1}NULL, ";
					}

					if (gstrEndDate != "")
					{
						if (Information.IsDate(gstrEndDate))
						{
							strInsert1 = $"{strInsert1}'{gstrEndDate}', ";
						}
						else
						{
							strInsert1 = $"{strInsert1}NULL, ";
						}
					}
					else
					{
						strInsert1 = $"{strInsert1}NULL, ";
					}

					strAcctRep = ($"{Convert.ToString(rstRec1["user_default_account_id"])} ").Trim();
					strFName = ($"{Convert.ToString(rstRec1["user_first_name"])} ").Trim();
					strLName = ($"{Convert.ToString(rstRec1["user_last_name"])} ").Trim();
					strUserName = $"{strFName} {strLName}";

					strInsert1 = $"{strInsert1}'{strAcctRep}', ";
					strInsert1 = $"{strInsert1}'{strUserId}', ";
					strInsert1 = $"{strInsert1}'{StringsHelper.Replace(strUserName, "'", "''", 1, -1, CompareMethod.Binary)}', ";
					strInsert1 = $"{strInsert1}'{StringsHelper.Replace(strFName, "'", "''", 1, -1, CompareMethod.Binary)}', ";
					strInsert1 = $"{strInsert1}'{StringsHelper.Replace(strLName, "'", "''", 1, -1, CompareMethod.Binary)}', ";
					strInsert1 = $"{strInsert1}'{gstrGroup}', ";
					strInsert1 = $"{strInsert1}'{gstrFieldCode}', ";
					strInsert1 = $"{strInsert1}'{gstrFieldName}', ";
					strInsert1 = $"{strInsert1}{lFieldCount.ToString()} ";
					strInsert1 = $"{strInsert1}) ";

					if (strUserId != "")
					{
						DbCommand TempCommand = null;
						TempCommand = cntConn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
					}

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Add_Account_Rep_Activity_Record_To_Temp_Table_Error", excep.Message);
			}

		} // Add_Account_Rep_Activity_Record_To_Temp_Table

		//=========================================================================================================
		//=========================================================================================================

		private static bool Create_Account_Rep_Activity_Report_Temp_Table(DbConnection cntConn)
		{


			bool bResults = false;


			string strCreate1 = $"CREATE TABLE {gstrTempTableName}  (";
			strCreate1 = $"{strCreate1}ara_id INT IDENTITY(1,1) NOT NULL, ";
			strCreate1 = $"{strCreate1}ara_startdate DATE NULL, ";
			strCreate1 = $"{strCreate1}ara_starttime TIME NULL,  ara_enddate DATE NULL, ";
			strCreate1 = $"{strCreate1}ara_endtime TIME NULL, ara_acctrep VARCHAR(4) NULL, ";
			strCreate1 = $"{strCreate1}ara_acctrep_user_id VARCHAR(4) NULL, ";
			strCreate1 = $"{strCreate1}ara_acctrep_name VARCHAR(75) NULL, ";
			strCreate1 = $"{strCreate1}ara_acctrep_fname VARCHAR(50) NULL, ";
			strCreate1 = $"{strCreate1}ara_acctrep_lname VARCHAR(50) NULL, ";
			strCreate1 = $"{strCreate1}ara_field_group VARCHAR(30) NULL, ";
			strCreate1 = $"{strCreate1}ara_field_code VARCHAR(20) NULL, ";
			strCreate1 = $"{strCreate1}ara_field_name VARCHAR(75) NULL, ";
			strCreate1 = $"{strCreate1}ara_field_count INT DEFAULT(0) ";
			strCreate1 = $"{strCreate1})";

			UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());
			DbCommand TempCommand = null;
			TempCommand = cntConn.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = strCreate1;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();
			UpgradeHelpers.DB.TransactionManager.Commit(cntConn);

			//--------------------------
			//-- Create Index

			strCreate1 = $"CREATE NONCLUSTERED INDEX [ix_{StringsHelper.Replace(gstrTempTableName, "#", "", 1, -1, CompareMethod.Binary)}_key] ON {gstrTempTableName}";
			strCreate1 = $"{strCreate1}(";
			strCreate1 = $"{strCreate1}  [ara_id] ASC";
			strCreate1 = $"{strCreate1}) ON [PRIMARY]";

			UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());
			DbCommand TempCommand_2 = null;
			TempCommand_2 = cntConn.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
			TempCommand_2.CommandText = strCreate1;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
			TempCommand_2.ExecuteNonQuery();
			UpgradeHelpers.DB.TransactionManager.Commit(cntConn);

			bResults = true;

			return bResults;

		} // Create_Account_Rep_Activity_Report_Temp_Table

		//=========================================================================================================
		//=========================================================================================================

		internal static void Drop_Account_Rep_Activity_Report_Temp_Table(DbConnection cntConn)
		{



			string strDrop1 = "";
			try
			{
				strDrop1 = $"DROP TABLE {gstrTempTableName} ";
			}
			catch
			{
			}

			if (gstrTempTableName != "")
			{
				DbCommand TempCommand = null;
				ErrorHandlingHelper.ResumeNext(
					() => {TempCommand = cntConn.CreateCommand();}, 
					() => {UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);}, 
					() => {TempCommand.CommandText = strDrop1;}, 
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					() => {TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));}, 
					() => {UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);}, 
					() => {TempCommand.ExecuteNonQuery();});
			}

		} // Drop_Account_Rep_Activity_Report_Temp_Table

		private static bool Does_User_Activity_Report_Record_Exists(DbConnection cntConn, string strFieldCode)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			bool bResults = false;

			try
			{

				bResults = false;

				strQuery1 = "SELECT uar_id FROM User_Activity_Reports WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (uar_report_code = '{strFieldCode}') ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					bResults = true;
				}

				rstRec1.Close();
				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Does_User_Activity_Report_Record_Exists_Error", excep.Message);
			}
			return false;
		} // Does_User_Activity_Report_Record_Exists


		private static void Add_User_Activity_Report_Record(DbConnection cntConn, string strFieldCode, string strGroup, string strFieldName)
		{

			string strInsert1 = "";

			try
			{

				strInsert1 = "INSERT INTO User_Activity_Reports ";
				strInsert1 = $"{strInsert1}(uar_report_code, uar_report_group, uar_report_name, uar_report_goals) ";
				strInsert1 = $"{strInsert1}VALUES (";
				strInsert1 = $"{strInsert1}'{strFieldCode}', ";
				strInsert1 = $"{strInsert1}'{strGroup}', ";
				strInsert1 = $"{strInsert1}'{StringsHelper.Replace(strFieldName, "'", "''", 1, -1, CompareMethod.Binary)}', ";
				strInsert1 = $"{strInsert1}0 )";

				DbCommand TempCommand = null;
				TempCommand = cntConn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strInsert1;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Add_User_Activity_Report_Record_Error", excep.Message);
			}

		} // Add_User_Activity_Report_Record


		internal static void DisplayGeneralCounts(DbConnection cntConn, string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTotCnt = 0;
			int lTotalActivity = 0;
			int iPos1 = 0;

			try
			{

				glFieldCount = 0;

				if (gstrExcludeUsers == "")
				{
					gstrExcludeUsers = modCommon.DLookUp("aconfig_exclude_users", "Application_Configuration");
				}

				strQuery1 = "SELECT DISTINCT journ_subcategory_code As JCatCode, ";
				strQuery1 = $"{strQuery1}jcat_subcategory_name As JCatName, ";
				strQuery1 = $"{strQuery1}COUNT(journ_id) AS TotCnt ";
				strQuery1 = $"{strQuery1}FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Journal_Category WITH (NOLOCK) ON journ_subcategory_code = jcat_subcategory_code ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) AND (journ_user_id IN ('{strUserId}')) ";

				// 11/28/2018 - By David D. Cruger
				// Per Lee; Need to filter out those related contacts that the
				// journal record was added to but wasn't the contact who received it
				strQuery1 = $"{strQuery1}AND (journ_description NOT LIKE '%Original EMail Sent To%' OR journ_description = '' OR journ_description IS NULL)  ";

				strQuery1 = $"{strQuery1}GROUP BY journ_subcategory_code, jcat_subcategory_name ORDER BY jcat_subcategory_name ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;
					lTotCnt = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Category";
						gstrFieldCode = ($"{Convert.ToString(rstRec1["JCatCode"])} ").Trim();
						gstrFieldName = ($"{Convert.ToString(rstRec1["JCatName"])} ").Trim();
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, glFieldCount);

						if (!Does_User_Activity_Report_Record_Exists(cntConn, gstrFieldCode))
						{
							Add_User_Activity_Report_Record(cntConn, gstrFieldCode, "Category", gstrFieldName);
						} //

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayGeneralCounts_Error", excep.Message);
			}

		} // DisplayGeneralCounts

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftAccessed(DbConnection cntConn, string strUserId)
		{

			int lTotalAdded = 0;
			int lTotalSearch = 0;
			int lTotalOpen = 0;
			int lTotalRegNbrAdded = 0;
			int lTotalOperAdded = 0;
			int lTotalChpAdded = 0;
			int lTotalPubsCleared = 0;
			int lTotalPubsAdded = 0;
			int lTotalPubsUpdated = 0;
			int lTotalPicAdded = 0;
			int lTotalMaintAdded = 0;
			int lTotalMaintUpdated = 0;
			int lTotalUsageUpdated = 0;
			int lTotalRegDateAdded = 0;
			int lTotalRegDateUpdated = 0;
			int lTotalKFeatUpdated = 0;
			int lTotalFAADocsAttached = 0;
			int lTotalDocsAttached = 0;
			int lTotalDocsRemoved = 0;
			int lTotalAirportsAdded = 0;
			int lTotalVerifyExclusive = 0;
			int lTotalMgCompRefAdded = 0;
			int lTotalChtCompRefAdded = 0;
			int lTotalACBaseChanged = 0;
			int lTotalSalesContactsAdded = 0;
			int lTotalSalesContactsDeleted = 0;
			int lTotalSpecsAdded = 0;
			int lTotalTimesCurrentUpdated = 0;
			int lTotalAskedForSoldPriceRefused = 0;
			int lTotalAskedForSoldPrice = 0;
			int lTotalVerifiedStatus = 0;
			int lTotalDocInProcReAssigned = 0;
			int lTotalSalePriceAdded = 0;
			int lTotalSalePriceAddedRefused = 0;
			int lTotalReassignAttempted = 0;
			int lTotalDocAttempted = 0;
			int lTotalAModUpdated = 0;
			int lTotalACBaseVerified = 0;
			int lTotalACDocsAttemptedConfirmed = 0;
			int lTotalACRVExclAttemptedConfirmed = 0;
			int lTotalACRAAttemptedConfirmed = 0;
			int lTotalACRAClearedDoneAttempted = 0;
			int lTotalACRegNbrVerifiedChangedAdded = 0;
			int lTotalFAADocsAttachedCompDocsAdded = 0;
			int lTotalIDNotesAddedRegistryChecked = 0;


			DisplayAircraftAdded(cntConn, strUserId, ref lTotalAdded);
			DisplayAircraftSearchCounts(cntConn, strUserId, ref lTotalSearch);
			DisplayAircraftOpenCounts(cntConn, strUserId, ref lTotalOpen);
			DisplayAircraftRegNbrAdded(cntConn, strUserId, ref lTotalRegNbrAdded);
			DisplayAircraftOperatorAdded(cntConn, strUserId, ref lTotalOperAdded);
			DisplayAircraftChiefPilotAdded(cntConn, strUserId, ref lTotalChpAdded);
			DisplayAircraftPubsCleared(cntConn, strUserId, ref lTotalPubsCleared);
			DisplayAircraftPubsAdded(cntConn, strUserId, ref lTotalPubsAdded);
			DisplayAircraftPubsUpdated(cntConn, strUserId, ref lTotalPubsUpdated);
			DisplayAircraftPicturesAdded(cntConn, strUserId, ref lTotalPicAdded);
			DisplayAircraftPicturesDeleted(cntConn, strUserId, ref lTotalPicAdded);
			DisplayAircraftMaintainedAdded(cntConn, strUserId, ref lTotalMaintAdded);
			DisplayAircraftMaintainedUpdated(cntConn, strUserId, ref lTotalMaintUpdated);
			DisplayAircraftUsageUpdated(cntConn, strUserId, ref lTotalUsageUpdated);
			DisplayAircraftRegDateAdded(cntConn, strUserId, ref lTotalRegDateAdded);
			DisplayAircraftRegDateUpdated(cntConn, strUserId, ref lTotalRegDateUpdated);
			DisplayAircraftKeyFeaturesUpdated(cntConn, strUserId, ref lTotalKFeatUpdated);
			DisplayAircraftFAADocsAttached(cntConn, strUserId, ref lTotalFAADocsAttached);
			DisplayAircraftDocumentsAttached(cntConn, strUserId, ref lTotalDocsAttached);
			DisplayAircraftDocumentsRemoved(cntConn, strUserId, ref lTotalDocsRemoved);
			DisplayAirportsAdded(cntConn, strUserId, ref lTotalAirportsAdded);
			DisplayAircraftVerifyExclusive(cntConn, strUserId, ref lTotalVerifyExclusive);
			DisplayAircraftRefManagementCompanyAdded(cntConn, strUserId, ref lTotalMgCompRefAdded);
			DisplayAircraftRefCharterCompanyAdded(cntConn, strUserId, ref lTotalChtCompRefAdded);
			DisplayAircraftBaseChanged(cntConn, strUserId, ref lTotalACBaseChanged);
			DisplayAircraftSalesContactsAdded(cntConn, strUserId, ref lTotalSalesContactsAdded);
			DisplayAircraftSalesContactsDeleted(cntConn, strUserId, ref lTotalSalesContactsDeleted);
			DisplayAircraftSpecsAdded(cntConn, strUserId, ref lTotalSpecsAdded);
			DisplayAircraftTimesCurrentUpdated(cntConn, strUserId, ref lTotalTimesCurrentUpdated);
			DisplayAircraftAskedForSoldPriceRefused(cntConn, strUserId, ref lTotalAskedForSoldPriceRefused);
			DisplayAircraftAskedForSoldPrice(cntConn, strUserId, ref lTotalAskedForSoldPrice);
			DisplayAircraftVerifiedStatus(cntConn, strUserId, ref lTotalVerifiedStatus);
			DisplayAircraftDocInProcessesReassigned(cntConn, strUserId, ref lTotalDocInProcReAssigned);
			DisplayAircraftSalePriceAdded(cntConn, strUserId, ref lTotalSalePriceAdded);
			DisplayAircraftSalePriceAddedRefused(cntConn, strUserId, ref lTotalSalePriceAddedRefused);
			DisplayAircraftReassignAttempted(cntConn, strUserId, ref lTotalReassignAttempted);
			DisplayAircraftDocAttempted(cntConn, strUserId, ref lTotalDocAttempted);
			DisplayAircraftModelsUpdated(cntConn, strUserId, ref lTotalAModUpdated);
			DisplayAircraftBaseVerified(cntConn, strUserId, ref lTotalACBaseVerified);
			DisplayAircraftDocAttemptedConfirmed(cntConn, strUserId, ref lTotalACDocsAttemptedConfirmed);
			DisplayAircraftReverifyExclusivesAttemptedConfirmed(cntConn, strUserId, ref lTotalACRVExclAttemptedConfirmed);
			DisplayAircraftReAssignsAttemptedConfirmed(cntConn, strUserId, ref lTotalACRAAttemptedConfirmed);
			DisplayAircraftReAssignsClearedDoneAttempted(cntConn, strUserId, ref lTotalACRAAttemptedConfirmed);
			DisplayAircraftRegNbrVerifiedChangedAdded(cntConn, strUserId, ref lTotalACRegNbrVerifiedChangedAdded);
			DisplayAircraftFAADocsAttachedCompanyDocsAdded(cntConn, strUserId, ref lTotalFAADocsAttachedCompDocsAdded);
			DisplayAircraftIDNotesRegistryCheckedAdded(cntConn, strUserId, ref lTotalIDNotesAddedRegistryChecked);

			int lTotal = lTotalAdded + lTotalSearch + lTotalOpen + lTotalRegNbrAdded + lTotalOperAdded + lTotalChpAdded + lTotalPubsCleared + lTotalPubsAdded + lTotalPubsUpdated + lTotalPicAdded + lTotalMaintAdded + lTotalMaintUpdated + lTotalUsageUpdated + lTotalRegDateAdded + lTotalRegDateUpdated + lTotalKFeatUpdated + lTotalFAADocsAttached + lTotalDocsAttached + lTotalDocsRemoved + lTotalVerifyExclusive + lTotalMgCompRefAdded + lTotalChtCompRefAdded + lTotalACBaseChanged + lTotalSalesContactsAdded + lTotalSalesContactsDeleted + lTotalSpecsAdded + lTotalTimesCurrentUpdated + lTotalAskedForSoldPriceRefused + lTotalAskedForSoldPrice + lTotalVerifiedStatus + lTotalDocInProcReAssigned + lTotalSalePriceAdded + lTotalSalePriceAddedRefused + lTotalReassignAttempted + lTotalDocAttempted + lTotalAModUpdated + lTotalACBaseVerified + lTotalACDocsAttemptedConfirmed + lTotalACRVExclAttemptedConfirmed + lTotalACRAAttemptedConfirmed + lTotalACRAClearedDoneAttempted + lTotalACRegNbrVerifiedChangedAdded + lTotalFAADocsAttachedCompDocsAdded + lTotalIDNotesAddedRegistryChecked;

		} // DisplayAircraftAccessed

		private static void DisplayYachtAccessed(DbConnection cntConn, string strUserId)
		{

			// removed yacht counts - MSW - 9/19/24

		} // DisplayYachtAccessed

		private static void DisplayCompaniesAccessed(DbConnection cntConn, string strUserId)
		{

			int lTotalSearch = 0;
			int lTotalOpen = 0;
			int lTotalCompAdded = 0;
			int lTotalEMailsAdded = 0;
			int lTotalEMailsRemoved = 0;
			int lTotalWebSitesAdded = 0;
			int lTotalJICsAdded = 0;
			int lTotalPhonesAdded = 0;
			int lTotalCertsAdded = 0;
			int lTotalDocAdded = 0;
			int lTotalDocRemoved = 0;
			int lTotalConfirmedInfo = 0;
			int lTotalStillHasShares = 0;
			int lTotalLogoAdded = 0;
			int lTotalLogoDeleted = 0;
			int lTotalIDNotesAdded = 0;
			int lTotalIDNotesAddedIDdLeadAttempt = 0;
			int lTotalReassignsDone = 0;
			int lTotalRevExcAttempted = 0;
			int lTotalAutoDialed = 0;
			int lTotalJNIQSurveySent = 0;
			int lTotalJNIQSurveyFollowUp = 0;
			int lTotalConfirmedInfoStillHasShares = 0;
			int lTotalProjectNotes = 0;


			DisplayCompanySearchCounts(cntConn, strUserId, ref lTotalSearch);
			DisplayCompanyOpenCounts(cntConn, strUserId, ref lTotalOpen);
			DisplayCompanysAdded(cntConn, strUserId, ref lTotalCompAdded);
			DisplayCompanyEMailsAdded(cntConn, strUserId, ref lTotalEMailsAdded);
			DisplayCompanyEMailsRemoved(cntConn, strUserId, ref lTotalEMailsRemoved);
			DisplayCompanyWebSitesAdded(cntConn, strUserId, ref lTotalWebSitesAdded);
			DisplayCompanyJICsAdded(cntConn, strUserId, ref lTotalJICsAdded);
			DisplayCompanyPhonesAdded(cntConn, strUserId, ref lTotalPhonesAdded);
			DisplayCompanyPhonesRemoved(cntConn, strUserId, ref lTotalPhonesAdded);
			DisplayCompanyCertificationsAdded(cntConn, strUserId, ref lTotalCertsAdded);
			DisplayCompanyDocumentsAdded(cntConn, strUserId, ref lTotalDocAdded);
			DisplayCompanyDocumentsRemoved(cntConn, strUserId, ref lTotalDocRemoved);
			DisplayCompanyConfirmedInfo(cntConn, strUserId, ref lTotalConfirmedInfo);
			DisplayCompanyStillHasShares(cntConn, strUserId, ref lTotalStillHasShares);
			DisplayCompanyLogoAdded(cntConn, strUserId, ref lTotalLogoAdded);
			DisplayCompanyLogoDeleted(cntConn, strUserId, ref lTotalLogoDeleted);
			DisplayCompanyIDNotesAdded(cntConn, strUserId, ref lTotalIDNotesAdded);
			DisplayCompanyIDNotesIDdLeadAttemptAdded(cntConn, strUserId, ref lTotalIDNotesAddedIDdLeadAttempt);
			DisplayCompanyReassignProceduresDone(cntConn, strUserId, ref lTotalReassignsDone);
			DisplayCompanyReverifyExclusiveAttempted(cntConn, strUserId, ref lTotalRevExcAttempted);
			DisplayCompanyAutoDialed(cntConn, strUserId, ref lTotalAutoDialed);
			DisplayCompanyJNiQSurveySent(cntConn, strUserId, ref lTotalJNIQSurveySent);
			DisplayCompanyJNiQSurveyFollowUp(cntConn, strUserId, ref lTotalJNIQSurveyFollowUp);
			DisplayCompanyConfirmedInfoStillHasShares(cntConn, strUserId, ref lTotalConfirmedInfoStillHasShares);
			DisplayCompanyProjectNotes(cntConn, strUserId, ref lTotalProjectNotes);

			int lTotal = lTotalSearch + lTotalOpen + lTotalCompAdded + lTotalEMailsAdded + lTotalEMailsRemoved + lTotalWebSitesAdded + lTotalJICsAdded + lTotalPhonesAdded + lTotalDocAdded + lTotalDocRemoved + lTotalConfirmedInfo + lTotalStillHasShares + lTotalLogoAdded + lTotalLogoDeleted + lTotalIDNotesAdded + lTotalIDNotesAddedIDdLeadAttempt + lTotalReassignsDone + lTotalRevExcAttempted + lTotalAutoDialed + lTotalJNIQSurveySent + lTotalJNIQSurveyFollowUp + lTotalConfirmedInfoStillHasShares + lTotalProjectNotes;

		} // DisplayCompaniesAccessed

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayContactsAccessed(DbConnection cntConn, string strUserId)
		{

			int lTotalSearch = 0;
			int lTotalOpen = 0;
			int lTotalContactsAdded = 0;
			int lTotalEMailsAdded = 0;
			int lTotalEMailsRemoved = 0;
			int lTotalPhonesAdded = 0;


			DisplayContactsViewedCounts(cntConn, strUserId, ref lTotalSearch);
			DisplayContactsOpenCounts(cntConn, strUserId, ref lTotalOpen);
			DisplayContactsAdded(cntConn, strUserId, ref lTotalContactsAdded);
			DisplayContactsInactive(cntConn, strUserId, ref lTotalContactsAdded);
			DisplayContactEMailsAdded(cntConn, strUserId, ref lTotalEMailsAdded);
			DisplayContactEMailsRemoved(cntConn, strUserId, ref lTotalEMailsRemoved);
			DisplayContactPhonesAdded(cntConn, strUserId, ref lTotalPhonesAdded);
			DisplayContactPhonesRemoved(cntConn, strUserId, ref lTotalPhonesAdded);

			int lTotal = lTotalSearch + lTotalOpen + lTotalContactsAdded + lTotalEMailsAdded + lTotalEMailsRemoved + lTotalPhonesAdded;

		} // DisplayContactsAccessed

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayWantedsAccessed(DbConnection cntConn, string strUserId)
		{

			int lTotalAdded = 0;
			int lTotalDeleted = 0;


			DisplayWantedsAdded(cntConn, strUserId, ref lTotalAdded);
			DisplayWantedDeletes(cntConn, strUserId, ref lTotalDeleted);

			int lTotal = lTotalAdded + lTotalDeleted;

		} // DisplayWantedsAccessed

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftPriorityEventsOpenCounts(DbConnection cntConn, string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); // Priority Events
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper(); // Hidden
			string strQuery1 = "";
			string strQuery2 = "";

			int lTotCnt = 0;
			int lTotalActivity = 0;
			int lTotalHidden = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(priorev_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM Priority_Events WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(priorev_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(priorev_entry_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (priorev_ac_id > 0) AND (priorev_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id IN ('{strUserId}')) ";

				// This Query Finds Hidden Prority Events
				strQuery2 = $"{strQuery1}AND (priorev_hide_flag = 'Y') ";

				//-------------------------------------------------------------------
				// Priority Events




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Priority Events";
						gstrFieldCode = "PEVENTS";
						gstrFieldName = "Aircraft Priority Events";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();


				rstRec2.Open(strQuery2, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec2.BOF) && (!rstRec2.EOF))
				{

					lTotalHidden = 0;

					do 
					{ // Loop Until rstRec2.EOF = True

						lTotCnt = Convert.ToInt32(rstRec2["TotCnt"]);
						lTotalHidden += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "A/C Hidden Priority Events";
						gstrFieldCode = "HPEVENTS";
						gstrFieldName = "A/C Hidden Priority Events";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec2.MoveNext();

					}
					while(!rstRec2.EOF);

				} // If (rstRec2.BOF = False) And (rstRec2.EOF = False) Then

				rstRec2.Close();

				rstRec2 = null;
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftPriorityEventsOpenCounts_Error", excep.Message);
			}

		} // DisplayAircraftPriorityEventsOpenCounts

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayYachtPriorityEventsOpenCounts(DbConnection cntConn, string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); // Priority Events
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper(); // Hidden
			string strQuery1 = "";
			string strQuery2 = "";

			int lTotCnt = 0;
			int lTotalActivity = 0;
			int lTotalHidden = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(ype_id) As TotCnt FROM Yacht_Priority_Events WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(ype_entered_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(ype_entered_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}


				strQuery1 = $"{strQuery1}AND (ype_user_id NOT IN ({gstrExcludeUsers})) AND (ype_user_id IN ('{strUserId}')) ";

				// This Query Finds Hidden Prority Events
				strQuery2 = $"{strQuery1}AND (ype_hide_flag = 'Y') ";


				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Yacht Priority Events";
						gstrFieldCode = "YPEVENTS";
						gstrFieldName = "Yacht Priority Events";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();


				rstRec2.Open(strQuery2, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec2.BOF) && (!rstRec2.EOF))
				{

					lTotalHidden = 0;

					do 
					{ // Loop Until rstRec2.EOF = True

						lTotCnt = Convert.ToInt32(rstRec2["TotCnt"]);
						lTotalHidden += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Yacht Hidden Priority Events";
						gstrFieldCode = "HYPEVENTS";
						gstrFieldName = "Yacht Hidden Priority Events";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec2.MoveNext();

					}
					while(!rstRec2.EOF);

				} // If (rstRec2.BOF = False) And (rstRec2.EOF = False) Then

				rstRec2.Close();

				rstRec2 = null;
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayYachtPriorityEventsOpenCounts_Error", excep.Message);
			}

		} // DisplayYachtPriorityEventsOpenCounts

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanyVerifiedAircraftCounts(DbConnection cntConn, string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTotCnt = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_comp_id) AS TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Journal_Category WITH (NOLOCK) ON journ_subcategory_code = jcat_subcategory_code ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'VS') AND (journ_comp_id > 0) ";
				strQuery1 = $"{strQuery1}AND (journ_ac_id > 0 OR journ_yacht_id = 0) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotCnt = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);

						// Account Rep Activity Temp Table Record
						gstrGroup = "Category Verified";
						gstrFieldCode = "CVACS";
						gstrFieldName = "Companies Verified Aircraft Status";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyVerifiedAircraftCounts_Error", excep.Message);
			}

		} // DisplayCompanyVerifiedAircraftCounts

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanyVerifiedYachtCounts(DbConnection cntConn, string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTotCnt = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_comp_id) AS TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Journal_Category WITH (NOLOCK) ON journ_subcategory_code = jcat_subcategory_code ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'VS') AND (journ_comp_id > 0) ";
				strQuery1 = $"{strQuery1}AND (journ_yacht_id > 0) AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotCnt = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);

						// Account Rep Activity Temp Table Record
						gstrGroup = "Category Verified";
						gstrFieldCode = "CVYTS";
						gstrFieldName = "Companies Verified Yacht Status";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyVerifiedYachtCounts_Error", excep.Message);
			}

		} // DisplayCompanyVerifiedYachtCounts

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanyUnableToVerifyCounts(DbConnection cntConn, string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTotCnt = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) AS TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RN') ";
				strQuery1 = $"{strQuery1}AND (journ_subject = 'Called. Not able to verify status' OR journ_subject LIKE 'Attempted to Contact%') ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotCnt = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);

						// Account Rep Activity Temp Table Record
						gstrGroup = "Category Verified";
						gstrFieldCode = "CUTVS";
						gstrFieldName = "Called Unable To Verify Status";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyUnableToVerifyCounts_Error", excep.Message);
			}

		} // DisplayCompanyUnableToVerifyCounts

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanyVerifiedInfoCounts(DbConnection cntConn, string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTotCnt = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) AS TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code IN ('CPCFM','CNCFM')) ";
				strQuery1 = $"{strQuery1}AND (journ_subject LIKE 'Confirmed Company%') ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotCnt = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);

						// Account Rep Activity Temp Table Record
						gstrGroup = "Category Verified";
						gstrFieldCode = "CVI";
						gstrFieldName = "Companies Verified Information";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyVerifiedInfoCounts_Error", excep.Message);
			}

		} // DisplayCompanyVerifiedInfoCounts

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanyContactFieldConfirmation(DbConnection cntConn, string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTotCnt = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) AS TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1}AND (";

				//-- CPCFM - Company Field Confirmation
				strQuery1 = $"{strQuery1}       ( ";
				strQuery1 = $"{strQuery1}             (journ_subcategory_code = 'CPCFM') ";
				strQuery1 = $"{strQuery1}        ) ";

				strQuery1 = $"{strQuery1}        OR ";

				// CNCFM - Contact Field Confirmation
				strQuery1 = $"{strQuery1}       ( ";
				strQuery1 = $"{strQuery1}             (journ_subcategory_code = 'CNCFM') ";
				strQuery1 = $"{strQuery1}        ) ";

				strQuery1 = $"{strQuery1}     ) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotCnt = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);

						// Account Rep Activity Temp Table Record
						gstrGroup = "Category Verified";
						gstrFieldCode = "CCFC";
						gstrFieldName = "Company/Contact Field Confirmation";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyContactFieldConfirmation_Error", excep.Message);
			}

		} // DisplayCompanyContactFieldConfirmation

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayMonitorUserCursorMovementCounts(DbConnection cntConn, string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTotCnt = 0;
			int lMaxPause = 0;
			int lTotalPaused = 0;
			int lTotalActivity = 0;
			double dAvgPause = 0;

			try
			{

				strQuery1 = "SELECT COUNT(mucm_id) As lTotCnt, SUM(mucm_elapsedtime) As lTotalPaused, ";
				strQuery1 = $"{strQuery1}MAX(mucm_elapsedtime) As lMaxPause, ";
				strQuery1 = $"{strQuery1}AVG(mucm_elapsedtime) As dAvgPause ";
				strQuery1 = $"{strQuery1}FROM Monitor_User_Cursor_Movement WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(mucm_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(mucm_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (mucm_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (mucm_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = 0;
						lMaxPause = 0;
						lTotalPaused = 0;
						dAvgPause = 0d;

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["lTotCnt"]))
						{
							lTotCnt = Convert.ToInt32(rstRec1["lTotCnt"]);
							lTotalActivity = lTotCnt;
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["lMaxPause"]))
						{
							lMaxPause = Convert.ToInt32(rstRec1["lMaxPause"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["lTotalPaused"]))
						{
							lTotalPaused = Convert.ToInt32(rstRec1["lTotalPaused"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["dAvgPause"]))
						{
							dAvgPause = Convert.ToDouble(rstRec1["dAvgPause"]);
						}

						// Account Rep Activity Temp Table Record

						gstrGroup = "Count Mouse Pauses";
						gstrFieldCode = "PAUSES";
						gstrFieldName = "User Mouse Movement";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayMonitorUserCursorMovementCounts_Error", excep.Message);
			}

		} // DisplayMonitorUserCursorMovementCounts

		//=========================================================================================================
		//=========================================================================================================
		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RN') AND (journ_subject LIKE '%Aircraft Added To System%') ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACADD";
						gstrFieldName = "Aircraft Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error("DisplayAircraftAdded_Error", excep.Message);
			}

		} // DisplayAircraftAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftSearchCounts(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%Aircraft Search%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACSRH";
						gstrFieldName = "Aircraft Searches";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftSearchCounts_Error", excep.Message);
			}

		} // DisplayAircraftSearchCounts

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftOpenCounts(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%Open Aircraft%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "OPENAC";
						gstrFieldName = "Aircraft Opened";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftOpenCounts_Error", excep.Message);
			}

		} // DisplayAircraftOpenCounts

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftRegNbrAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(priorev_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM Priority_Events WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(priorev_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(priorev_entry_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (priorev_category_code = 'CREG') ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "CREG";
						gstrFieldName = "RegNbr Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftRegNbrAdded_Error", excep.Message);
			}

		} // DisplayAircraftRegNbrAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftOperatorAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(priorev_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM Priority_Events WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(priorev_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(priorev_entry_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (priorev_category_code = 'NOPR') ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "NOPR";
						gstrFieldName = "Operators Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftOperatorAdded_Error", excep.Message);
			}

		} // DisplayAircraftOperatorAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftChiefPilotAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(priorev_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM Priority_Events WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(priorev_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(priorev_entry_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (priorev_category_code = 'NCHP') AND (priorev_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "NCHP";
						gstrFieldName = "Chief Pilots Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftChiefPilotAdded_Error", excep.Message);
			}

		} // DisplayAircraftChiefPilotAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftPubsCleared(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RN') AND (journ_subject LIKE 'Cleared %') ";
				strQuery1 = $"{strQuery1}AND (journ_subject LIKE '% Pub')  AND (journ_ac_id > 0) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers}))  AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "CPUB";
						gstrFieldName = "A/C Pubs Cleared";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftPubsCleared_Error", excep.Message);
			}

		} // DisplayAircraftPubsCleared

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftPubsAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RN') AND (journ_subject LIKE 'Add %') ";
				strQuery1 = $"{strQuery1}AND (journ_subject LIKE '% Pub')  AND (journ_ac_id > 0) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) AND (journ_user_id IN ('{strUserId}')) ";


				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "APUB";
						gstrFieldName = "A/C Pubs Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Event("DisplayAircraftPubsAdded_Error", excep.Message);
			}

		} // DisplayAircraftPubsAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftPubsUpdated(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Pub') AND (evtl_message Like '%Updated Pub%') ";
				strQuery1 = $"{strQuery1}AND (evtl_ac_id > 0)  AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";


				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "UPUB";
						gstrFieldName = "A/C Pubs Updated";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftPubsUpdated_Error", excep.Message);
			}

		} // DisplayAircraftPubsUpdated

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftPicturesAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Aircraft Pictures') AND (evtl_message Like '%Added Aircraft Picture%') ";
				strQuery1 = $"{strQuery1}AND (evtl_ac_id > 0)  AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "APIC";
						gstrFieldName = "A/C Pictures Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftPicturesAdded_Error", excep.Message);
			}

		} // DisplayAircraftPicturesAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftPicturesDeleted(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Aircraft Pictures') AND (evtl_message Like '%Deleted Aircraft Picture%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "DPIC";
						gstrFieldName = "A/C Pictures Deleted";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftPicturesDeleted_Error", excep.Message);
			}

		} // DisplayAircraftPicturesDeleted

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftMaintainedAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt  FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') ";
				strQuery1 = $"{strQuery1}AND (evtl_message Like '%Maintained Added%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";


				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "MNTA";
						gstrFieldName = "Maintained Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftMaintainedAdded_Error", excep.Message);
			}

		} // DisplayAircraftMaintainedAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftMaintainedUpdated(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%Maintained Updated%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) AND (evtl_user_id IN ('{strUserId}')) ";


				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "MNTU";
						gstrFieldName = "Maintained Updated";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftMaintainedUpdated_Error", excep.Message);
			}

		} // DisplayAircraftMaintainedUpdated

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftUsageUpdated(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%Usage Updated%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers}))  AND (evtl_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "USEU";
						gstrFieldName = "Usage Updated";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftUsageUpdated_Error", excep.Message);
			}

		} // DisplayAircraftUsageUpdated

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftRegDateAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%RegDate Added%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) AND (evtl_user_id IN ('{strUserId}')) ";


				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "RGDA";
						gstrFieldName = "RegNbr Date Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftRegDateAdded_Error", excep.Message);
			}

		} // DisplayAircraftRegDateAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftRegDateUpdated(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity')  AND (evtl_message Like '%RegDate Updated%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "RGDU";
						gstrFieldName = "RegNbr Date Updated";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftRegDateUpdated_Error", excep.Message);
			}

		} // DisplayAircraftRegDateUpdated

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftKeyFeaturesUpdated(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity')  AND (evtl_message Like '%Key Feature Updated%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "KFTU";
						gstrFieldName = "Key Features Updated";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftKeyFeaturesUpdated_Error", excep.Message);
			}

		} // DisplayAircraftKeyFeaturesUpdated


		private static void DisplayAircraftFAADocsAttached(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RN') AND (journ_subject Like 'Attached%') ";
				strQuery1 = $"{strQuery1}AND (journ_description Like '%; per tape%') ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) AND (journ_ac_id > 0) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "FAADOCS";
						gstrFieldName = "FAA Docs Attached (PDF)";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftFAADocsAttached_Error", excep.Message);
			}

		} // DisplayAircraftFAADocsAttached


		private static void DisplayAircraftDocumentsAttached(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Aircraft Spec')  AND (evtl_message Like '%Added Aircraft Spec:%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ATDOC";
						gstrFieldName = "Attached Documents (PDF)";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftDocumentsAttached_Error", excep.Message);
			}

		} // DisplayAircraftDocumentsAttached


		private static void DisplayAircraftDocumentsRemoved(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt  FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Aircraft Spec') AND (evtl_message Like '%Deleted Aircraft Spec:%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "RMDOC";
						gstrFieldName = "Removed Documents";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftDocumentsRemoved_Error", excep.Message);
			}

		} // DisplayAircraftDocumentsRemoved


		private static void DisplayAirportsAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt  FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Airport')  AND (evtl_message Like '%Airport Added:%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "APORTA";
						gstrFieldName = "Airports Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAirportsAdded_Error", excep.Message);
			}

		} // DisplayAirportsAdded


		private static void DisplayAircraftVerifyExclusive(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'VS') AND (journ_subject LIKE '%Verified Exclusive Status%') ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACVES";
						gstrFieldName = "Verified Exclusive Status";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftVerifyExclusive_Error", excep.Message);
			}

		} // DisplayAircraftVerifyExclusive

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftRefManagementCompanyAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Aircraft Reference') AND (evtl_message Like '%Added Aircraft Reference%') ";
				strQuery1 = $"{strQuery1}AND (evtl_message Like '%31=Aircraft Management Company%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACREF31";
						gstrFieldName = "A/C Management Companies Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftRefManagementCompanyAdded_Error", excep.Message);
			}

		} // DisplayAircraftRefManagementCompanyAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftRefCharterCompanyAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt  FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Aircraft Reference')  AND (evtl_message Like '%Added Aircraft Reference%') ";
				strQuery1 = $"{strQuery1}AND (evtl_message Like '%94=Charter Company%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACREF94";
						gstrFieldName = "Charter Companies Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftRefCharterCompanyAdded_Error", excep.Message);
			}

		} // DisplayAircraftRefCharterCompanyAdded


		private static void DisplayAircraftBaseChanged(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(priorev_id) As TotCnt FROM Priority_Events WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(priorev_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(priorev_entry_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (priorev_category_code = 'CBASE')  AND (priorev_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id IN ('{strUserId}')) ";


				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "CBASE";
						gstrFieldName = "A/C Base Changed";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftBaseChanged_Error", excep.Message);
			}

		} // DisplayAircraftBaseChanged


		private static void DisplayAircraftSalesContactsAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(priorev_id) As TotCnt FROM Priority_Events WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(priorev_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(priorev_entry_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (priorev_category_code = 'NSCPCT')  AND (priorev_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "NSCPCT";
						gstrFieldName = "Sales Contact Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftSalesContactsAdded_Error", excep.Message);
			}

		} // DisplayAircraftSalesContactsAdded


		private static void DisplayAircraftSalesContactsDeleted(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(priorev_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM Priority_Events WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(priorev_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(priorev_entry_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (priorev_category_code = 'RSCPCT')  AND (priorev_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "RSCPCT";
						gstrFieldName = "Sales Contact Deleted";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftSalesContactsDeleted_Error", excep.Message);
			}

		} // DisplayAircraftSalesContactsDeleted

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftSpecsAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RN') AND (journ_subject LIKE '%e/s%') ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "SPECA";
						gstrFieldName = "Specs Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftSpecsAdded_Error", excep.Message);
			}

		} // DisplayAircraftSpecsAdded


		private static void DisplayAircraftTimesCurrentUpdated(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Aircraft Times Current')  AND (evtl_message Like 'Times Current Has Changed To%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ATCU";
						gstrFieldName = "Times Current Updated";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftTimesCurrentUpdated_Error", excep.Message);
			}

		} // DisplayAircraftTimesCurrentUpdated


		private static void DisplayAircraftAskedForSoldPriceRefused(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Sold Price Refused') AND (evtl_message Like 'Asked For Sold Price - Refused%') ";
				strQuery1 = $"{strQuery1}AND (evtl_ac_id > 0) AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "AFSPR";
						gstrFieldName = "Aircraft Sold Price Refused";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftAskedForSoldPriceRefused_Error", excep.Message);
			}

		} // DisplayAircraftAskedForSoldPriceRefused


		private static void DisplayAircraftAskedForSoldPrice(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt  FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Asked For Sold Price') ";
				strQuery1 = $"{strQuery1}AND (evtl_message Like 'Asked For Sold Price%')  AND (evtl_ac_id > 0) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "AFSP";
						gstrFieldName = "Aircraft Asked For Sold Price";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftAskedForSoldPrice_Error", excep.Message);
			}

		} // DisplayAircraftAskedForSoldPrice


		private static void DisplayAircraftVerifiedStatus(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'VS') ";
				strQuery1 = $"{strQuery1}AND (journ_subject LIKE '%Verified Status%') AND (journ_ac_id > 0) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACVS";
						gstrFieldName = "Aircraft Verified Status";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftVerifiedStatus_Error", excep.Message);
			}

		} // DisplayAircraftVerifiedStatus


		private static void DisplayAircraftDocInProcessesReassigned(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'HBFAADocLog') AND (evtl_message Like 'Doc In Process Reassigned From AcctRep%') ";
				strQuery1 = $"{strQuery1}AND (evtl_ac_id > 0)  AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "DOCREASG";
						gstrFieldName = "Doc In Proc-Reassign";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftDocInProcessesReassigned_Error", excep.Message);
			}

		} // DisplayAircraftDocInProcessesReassigned


		private static void DisplayAircraftSalePriceAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND ( ";
				strQuery1 = $"{strQuery1}       (journ_subcategory_code = 'RN' AND journ_subject LIKE 'Sale Price Entered%') ";
				strQuery1 = $"{strQuery1}    OR (journ_subcategory_code = 'SP' AND journ_subject LIKE 'A/C Value Added Sale Price%') ";
				strQuery1 = $"{strQuery1}    ) ";
				strQuery1 = $"{strQuery1}AND (journ_ac_id > 0) AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";


				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACSPA";
						gstrFieldName = "Aircraft Sale Price Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftSalePriceAdded_Error", excep.Message);
			}

		} // DisplayAircraftSalePriceAdded


		private static void DisplayAircraftSalePriceAddedRefused(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT  (SELECT COUNT(journ_id) ";
				strQuery1 = $"{strQuery1} FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1} WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1} AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1} AND (journ_ac_id > 0) ";
				strQuery1 = $"{strQuery1} AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1} AND (journ_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1} AND ( ";
				strQuery1 = $"{strQuery1}        (journ_subcategory_code = 'RN' AND journ_subject LIKE 'Sale Price Entered%') ";
				strQuery1 = $"{strQuery1}     OR (journ_subcategory_code = 'SP' AND journ_subject LIKE 'A/C Value Added Sale Price%') ";
				strQuery1 = $"{strQuery1}     ) ";

				strQuery1 = $"{strQuery1} ) + ";

				//----------------------------------------------
				//-- AFSPR - Aircraft Sold Price Refused
				//----------------------------------------------

				strQuery1 = $"{strQuery1}(SELECT COUNT(evtl_id) ";
				strQuery1 = $"{strQuery1} FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1} WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1} AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1} AND (evtl_ac_id > 0) ";
				strQuery1 = $"{strQuery1} AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1} AND (evtl_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1} AND (evtl_type = 'Sold Price Refused') ";
				strQuery1 = $"{strQuery1} AND (evtl_message Like 'Asked For Sold Price - Refused%') ";

				strQuery1 = $"{strQuery1}) As TotCnt ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACSPAF";
						gstrFieldName = "Aircraft Sale Price Added/Refused";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftSalePriceAddedRefused_Error", excep.Message);
			}

		} // DisplayAircraftSalePriceAddedRefused

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftReassignAttempted(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt ";
				strQuery1 = $"{strQuery1}FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RAAT') AND (journ_subject LIKE '%Reassign Attempted%') ";
				strQuery1 = $"{strQuery1}AND (journ_ac_id > 0)  AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";


				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "RAAT2";
						gstrFieldName = "Aircraft Reassign Attempted";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftReassignAttempted_Error", excep.Message);
			}

		} // DisplayAircraftReassignAttempted

		private static void DisplayAircraftDocAttempted(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'DOCAT')  AND (journ_subject LIKE '%Doc Attempted%') ";
				strQuery1 = $"{strQuery1}AND (journ_ac_id > 0)  AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACDOCAT";
						gstrFieldName = "Aircraft Doc Attempted";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftDocAttempted_Error", excep.Message);
			}

		} // DisplayAircraftDocAttempted

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftModelsUpdated(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Update Aircraft Model')  AND (evtl_message Like 'Updating Aircraft Model%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "AMODU";
						gstrFieldName = "Aircraft Models Updated";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftModelsUpdated_Error", excep.Message);
			}

		} // DisplayAircraftModelsUpdated


		private static void DisplayAircraftBaseVerified(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT  (SELECT COUNT(priorev_id) ";
				strQuery1 = $"{strQuery1}FROM Priority_Events WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(priorev_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(priorev_entry_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				// 04/01/2019 - Per Michele H to Include Both Verified and Changed
				strQuery1 = $"{strQuery1}AND (priorev_category_code = 'CBASE') AND (priorev_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1}) + ";

				//-------------------------------------------
				//-- Now Count Journal Records
				//-------------------------------------------

				strQuery1 = $"{strQuery1}(SELECT COUNT(journ_id) ";
				strQuery1 = $"{strQuery1}FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'VAB') ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1}) As TotCnt ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "BASEV";
						gstrFieldName = "A/C Base Verified/Chg/Add";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftBaseVerified_Error", excep.Message);
			}

		} // DisplayAircraftBaseVerified

		private static void DisplayAircraftDocAttemptedConfirmed(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1}AND ( ";

				//------------------------------
				// Docs Attemped
				//------------------------------
				strQuery1 = $"{strQuery1}       ( ";
				strQuery1 = $"{strQuery1}          (journ_subcategory_code = 'DOCAT') ";
				strQuery1 = $"{strQuery1}      AND (journ_subject LIKE '%Doc Attempted%') ";
				strQuery1 = $"{strQuery1}       ) ";

				strQuery1 = $"{strQuery1}    OR ";

				//------------------------------
				// FAA Docs Attached
				//------------------------------
				strQuery1 = $"{strQuery1}       ( ";
				strQuery1 = $"{strQuery1}             (journ_subcategory_code = 'RN') ";
				strQuery1 = $"{strQuery1}         AND (journ_subject Like 'Attached%') ";
				strQuery1 = $"{strQuery1}         AND (journ_description Like '%; per tape%') ";
				strQuery1 = $"{strQuery1}       ) ";

				strQuery1 = $"{strQuery1}    ) ";
				strQuery1 = $"{strQuery1}AND (journ_ac_id > 0) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACDOCAC";
						gstrFieldName = "A/C Docs Attempted/Confirmed";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftDocAttemptedConfirmed_Error", excep.Message);
			}

		} // DisplayAircraftDocAttemptedConfirmed


		private static void DisplayAircraftReverifyExclusivesAttemptedConfirmed(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1}AND ( ";

				//------------------------------------------
				// Verify Exclusive Confirmed (ACVES)
				//------------------------------------------
				strQuery1 = $"{strQuery1}       ( ";
				strQuery1 = $"{strQuery1}            (journ_subcategory_code = 'VS') ";
				strQuery1 = $"{strQuery1}        AND (journ_subject LIKE '%Verified Exclusive Status%') ";
				strQuery1 = $"{strQuery1}       ) ";

				strQuery1 = $"{strQuery1}    OR ";

				//------------------------------------------
				// Reverify Exclusive Attempted (RVEAT)
				//------------------------------------------
				strQuery1 = $"{strQuery1}       ( ";
				strQuery1 = $"{strQuery1}             (journ_subcategory_code = 'RVEAT') ";
				strQuery1 = $"{strQuery1}         AND (journ_comp_id > 0) ";
				strQuery1 = $"{strQuery1}       ) ";

				strQuery1 = $"{strQuery1}    ) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACRVEAC";
						gstrFieldName = "R/V Exclusives Attempted/Confirmed";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftReverifyExclusivesAttemptedConfirmed_Error", excep.Message);
			}

		} // DisplayAircraftReverifyExclusivesAttemptedConfirmed

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftReAssignsAttemptedConfirmed(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1}AND ( ";

				//------------------------------------------
				// Aircraft Reassigned - Cleared (AAC)
				//------------------------------------------
				strQuery1 = $"{strQuery1}       ( ";
				strQuery1 = $"{strQuery1}             (journ_subcategory_code = 'AAC') ";
				strQuery1 = $"{strQuery1}         AND (journ_ac_id > 0) ";
				strQuery1 = $"{strQuery1}       ) ";

				strQuery1 = $"{strQuery1}    OR ";

				//------------------------------------------
				// Aircraft Reassign Attempted (RAAT)
				//------------------------------------------
				strQuery1 = $"{strQuery1}       ( ";
				strQuery1 = $"{strQuery1}             (journ_subcategory_code = 'RAAT') ";
				strQuery1 = $"{strQuery1}         AND (journ_subject LIKE '%Reassign Attempted%') ";
				strQuery1 = $"{strQuery1}       ) ";

				strQuery1 = $"{strQuery1}    OR ";

				//------------------------------------------
				// Reassign Procedures Done (RADN)
				//------------------------------------------
				strQuery1 = $"{strQuery1}       ( ";
				strQuery1 = $"{strQuery1}             (journ_subcategory_code = 'RADN') ";
				strQuery1 = $"{strQuery1}         AND (journ_comp_id > 0) ";
				strQuery1 = $"{strQuery1}       ) ";

				strQuery1 = $"{strQuery1}    ) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACRAAC";
						gstrFieldName = "R/A Attempted/Confirmed";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftReAssignsAttemptedConfirmed_Error", excep.Message);
			}

		} // DisplayAircraftReAssignsAttemptedConfirmed


		private static void DisplayAircraftReAssignsClearedDoneAttempted(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1}AND ( ";

				//------------------------------------------
				// Aircraft Reassigned - Cleared (AAC)
				strQuery1 = $"{strQuery1}       ( ";
				strQuery1 = $"{strQuery1}         (journ_subcategory_code = 'AAC') ";
				strQuery1 = $"{strQuery1}         AND (journ_ac_id > 0) ";
				strQuery1 = $"{strQuery1}       ) ";

				strQuery1 = $"{strQuery1}    OR ";

				strQuery1 = $"{strQuery1}       ( ";
				strQuery1 = $"{strQuery1}             (journ_subcategory_code = 'RAAT') ";
				strQuery1 = $"{strQuery1}         AND (journ_subject LIKE '%Reassign Attempted%') ";
				strQuery1 = $"{strQuery1}         AND (journ_ac_id > 0) ";
				strQuery1 = $"{strQuery1}       ) ";

				strQuery1 = $"{strQuery1}    OR ";

				strQuery1 = $"{strQuery1}       ( ";
				strQuery1 = $"{strQuery1}             (journ_subcategory_code = 'RADN') ";
				strQuery1 = $"{strQuery1}         AND (journ_comp_id > 0) ";
				strQuery1 = $"{strQuery1}       ) ";

				strQuery1 = $"{strQuery1}    ) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACRACDA";
						gstrFieldName = "A/C Reassigned - Cleared, Done, Attempted";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftReAssignsClearedDoneAttempted_Error", excep.Message);
			}

		} // DisplayAircraftReAssignsClearedDoneAttempted

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftRegNbrVerifiedChangedAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT  (SELECT COUNT(priorev_id) ";
				strQuery1 = $"{strQuery1}FROM Priority_Events WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(priorev_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(priorev_entry_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (priorev_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1}AND (priorev_ac_id > 0) ";
				strQuery1 = $"{strQuery1}AND (priorev_category_code = 'CREG') ";

				strQuery1 = $"{strQuery1}) + ";

				//---------------------------
				strQuery1 = $"{strQuery1}(SELECT COUNT(journ_id) ";
				strQuery1 = $"{strQuery1}FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1}AND (journ_ac_id > 0) ";
				strQuery1 = $"{strQuery1}AND (journ_description NOT LIKE '%Original EMail Sent To%' OR journ_description = '' OR journ_description IS NULL) ";
				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'VAR') ";

				strQuery1 = $"{strQuery1}) As TotCnt ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACRNVA";
						gstrFieldName = "RegNbr Verified/Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftRegNbrVerifiedChangedAdded_Error", excep.Message);
			}

		} // DisplayAircraftRegNbrVerifiedChangedAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftFAADocsAttachedCompanyDocsAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT  (SELECT COUNT(journ_id) ";
				strQuery1 = $"{strQuery1}FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers}))  AND (journ_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1}AND (journ_ac_id > 0)  AND (journ_subcategory_code = 'RN') ";
				strQuery1 = $"{strQuery1}AND (journ_subject Like 'Attached%') AND (journ_description Like '%; per tape%') ";

				strQuery1 = $"{strQuery1}) + ";

				//-----------------------------------------------------------------------------
				// CDOCA = Company Docs Added (PDF)

				strQuery1 = $"{strQuery1}(SELECT COUNT(evtl_id) ";
				strQuery1 = $"{strQuery1} FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1} WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1} AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1} AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1} AND (evtl_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Company') AND (evtl_message Like '%Added Company Document:%') ";

				strQuery1 = $"{strQuery1}) As TotCnt ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "ACFAACDOCA";
						gstrFieldName = "FAA Docs Attached/Docs Added (PDF)";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftFAADocsAttachedCompanyDocsAdded_Error", excep.Message);
			}

		} // DisplayAircraftFAADocsAttachedCompanyDocsAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayAircraftIDNotesRegistryCheckedAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'IDNOTE') AND (journ_subject LIKE '%Registry Checked%') ";
				strQuery1 = $"{strQuery1}AND (journ_ac_id > 0) AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Aircraft Accessed";
						gstrFieldCode = "AIDNOTE1";
						gstrFieldName = "ID Notes/Registry Checked";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayAircraftIDNotesRegistryCheckedAdded_Error", excep.Message);
			}

		} // DisplayAircraftIDNotesRegistryCheckedAdded


		private static void DisplayCompanySearchCounts(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') ";
				strQuery1 = $"{strQuery1}AND (evtl_message Like '%Company Search%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CSRCH";
						gstrFieldName = "Company Searches";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanySearchCounts_Error", excep.Message);
			}

		} // DisplayCompanySearchCounts

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanyOpenCounts(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity')  AND (evtl_message Like '%Open Company%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "OPENCOMP";
						gstrFieldName = "Companies Opened";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyOpenCounts_Error", excep.Message);
			}

		} // DisplayCompanyOpenCounts

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanysAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity')  AND (evtl_message Like '%Company Added%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "COMPA";
						gstrFieldName = "Companies Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanysAdded_Error", excep.Message);
			}

		} // DisplayCompanysAdded


		private static void DisplayCompanyEMailsAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt  FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity')  AND (evtl_message Like '%Company EMail Added%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CEMA";
						gstrFieldName = "EMails Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyEMailsAdded_Error", excep.Message);
			}

		} // DisplayCompanyEMailsAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanyEMailsRemoved(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity')  AND (evtl_message Like '%Company EMail Deleted%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CEMR";
						gstrFieldName = "EMails Removed";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyEMailsRemoved_Error", excep.Message);
			}

		} // DisplayCompanyEMailsRemoved

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanyWebSitesAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt  FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity')  AND (evtl_message Like '%Company WebSite Added%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CWSA";
						gstrFieldName = "WebSites Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyWebSitesAdded_Error", excep.Message);
			}

		} // DisplayCompanyWebSitesAdded

		private static void DisplayCompanyJICsAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt  FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%Company JIC Added%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CJIC";
						gstrFieldName = "JIC Codes Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyJICsAdded_Error", excep.Message);
			}

		} // DisplayCompanyJICsAdded

		private static void DisplayCompanyPhonesAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%Company Phone Added%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CMPA";
						gstrFieldName = "Phone Nbrs Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyPhonesAdded_Error", excep.Message);
			}

		} // DisplayCompanyPhonesAdded


		private static void DisplayCompanyPhonesRemoved(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subject LIKE '%Removed Company Phone Number%') ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CMPR";
						gstrFieldName = "Phone Nbrs Removed";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyPhonesRemoved_Error", excep.Message);
			}

		} // DisplayCompanyPhonesRemoved


		private static void DisplayCompanyCertificationsAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%Company Certification Added%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CCTA";
						gstrFieldName = "Certifications Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyCertificationsAdded_Error", excep.Message);
			}

		} // DisplayCompanyCertificationsAdded


		private static void DisplayCompanyDocumentsAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Company') AND (evtl_message Like '%Added Company Document:%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CDOCA";
						gstrFieldName = "Documents Added (PDF)";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyDocumentsAdded_Error", excep.Message);
			}

		} // DisplayCompanyDocumentsAdded


		private static void DisplayCompanyDocumentsRemoved(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Company')  AND (evtl_message Like '%Delete Company Document:%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CDOCR";
						gstrFieldName = "Documents Deleted (PDF)";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyDocumentsRemoved_Error", excep.Message);
			}

		} // DisplayCompanyDocumentsRemoved


		private static void DisplayCompanyConfirmedInfo(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RN')  AND (journ_subject LIKE '%Confirmed info per%') ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CCIP";
						gstrFieldName = "Confirmed Info Per";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyConfirmedInfo_Error", excep.Message);
			}

		} // DisplayCompanyConfirmedInfo


		private static void DisplayCompanyStillHasShares(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RN') AND (journ_subject LIKE '%Still has Shares Per%') ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CSHSP";
						gstrFieldName = "Still Has Shares Per";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyStillHasShares_Error", excep.Message);
			}

		} // DisplayCompanyStillHasShares


		private static void DisplayCompanyLogoAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt  FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Company') AND (evtl_message Like '%Attach Company Logo%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "ALOGO";
						gstrFieldName = "Logo Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyLogoAdded_Error", excep.Message);
			}

		} // DisplayCompanyLogoAdded

		private static void DisplayCompanyLogoDeleted(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Company') AND (evtl_message Like '%Delete Company Logo%') ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "DLOGO";
						gstrFieldName = "Logo Deleted";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyLogoDeleted_Error", excep.Message);
			}

		} // DisplayCompanyLogoDeleted

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanyIDNotesAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'IDNOTE') AND (journ_comp_id > 0) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CIDNOTE";
						gstrFieldName = "ID Notes Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyIDNotesAdded_Error", excep.Message);
			}

		} // DisplayCompanyIDNotesAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanyIDNotesIDdLeadAttemptAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'IDNOTE') ";
				strQuery1 = $"{strQuery1}AND (journ_subject LIKE '%IDd%' OR journ_subject LIKE '%ID Lead Sent%' OR journ_subject LIKE '%Attempted to ID%') ";
				strQuery1 = $"{strQuery1}AND (journ_comp_id > 0)  AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CIDNOTE2";
						gstrFieldName = "ID Notes/IDd/Lead/Attempt";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyIDNotesIDdLeadAttemptAdded_Error", excep.Message);
			}

		} // DisplayCompanyIDNotesIDdLeadAttemptAdded


		private static void DisplayCompanyReassignProceduresDone(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RADN') ";
				strQuery1 = $"{strQuery1}AND (journ_comp_id > 0)  AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "RADN";
						gstrFieldName = "Reassign Procedures Done";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyReassignProceduresDone_Error", excep.Message);
			}

		} // DisplayCompanyReassignProceduresDone

		private static void DisplayCompanyReverifyExclusiveAttempted(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RVEAT')  AND (journ_comp_id > 0) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "RVEAT";
						gstrFieldName = "Reverify Exclusive Attempted";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyReverifyExclusiveAttempted_Error", excep.Message);
			}

		} // DisplayCompanyReverifyExclusiveAttempted


		private static void DisplayCompanyAutoDialed(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RN')  AND (journ_subject LIKE '%Auto Dialed%') ";
				strQuery1 = $"{strQuery1}AND (journ_comp_id > 0) AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "ADIAL";
						gstrFieldName = "Phone Nbr - Auto Dial";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyAutoDialed_Error", excep.Message);
			}

		} // DisplayCompanyAutoDialed

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanyJNiQSurveySent(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'IQ') AND (journ_subject LIKE '%Sent %') ";
				strQuery1 = $"{strQuery1}AND (journ_subject LIKE '%iQ Survey %') ";
				strQuery1 = $"{strQuery1}AND (journ_description NOT LIKE '%Original EMail Sent To%' OR journ_description = '' OR journ_description IS NULL) ";
				strQuery1 = $"{strQuery1}AND (journ_comp_id > 0) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "JNIQS";
						gstrFieldName = "JNiQ Survey Sent";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyJNiQSurveySent_Error", excep.Message);
			}

		} // DisplayCompanyJNiQSurveySent

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayCompanyJNiQSurveyFollowUp(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_description NOT LIKE '%Original EMail Sent To%' OR journ_description = '' OR journ_description IS NULL) ";
				strQuery1 = $"{strQuery1}AND (journ_comp_id > 0) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'IQ') ";
				strQuery1 = $"{strQuery1}AND (journ_subject LIKE '%JNiQ - %') ";
				strQuery1 = $"{strQuery1}AND (    journ_subject LIKE '%Permission Email Sent%' ";
				strQuery1 = $"{strQuery1}      OR journ_subject LIKE '%Promotional Email Sent%' ";
				strQuery1 = $"{strQuery1}      OR journ_subject LIKE '%Declined Survey%' ";
				strQuery1 = $"{strQuery1}      OR journ_subject LIKE '%Invitation Email Sent%' ";
				strQuery1 = $"{strQuery1}      OR journ_subject LIKE '%Follow Up Email Sent%' ";
				strQuery1 = $"{strQuery1}      OR journ_subject LIKE '%Custom EMail Sent%' ";
				strQuery1 = $"{strQuery1}      OR journ_subject LIKE '%EMail Sent%' ";
				strQuery1 = $"{strQuery1}      OR journ_subject LIKE '%Follow up Email/Call%' ";
				strQuery1 = $"{strQuery1}      OR journ_subject LIKE '%Follow Up Phone Call%' ";
				strQuery1 = $"{strQuery1}    ) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "JNIQF";
						gstrFieldName = "JNiQ Survey Follow Up";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyJNiQSurveyFollowUp_Error", excep.Message);
			}

		} // DisplayCompanyJNiQSurveyFollowUp


		private static void DisplayCompanyConfirmedInfoStillHasShares(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'RN') AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";
				strQuery1 = $"{strQuery1}AND ( ";
				strQuery1 = $"{strQuery1}       (journ_subject LIKE '%Confirmed info per%') ";
				strQuery1 = $"{strQuery1}    OR (journ_subject LIKE '%Still has Shares Per%') ";
				strQuery1 = $"{strQuery1}     ) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CIPHSP";
						gstrFieldName = "Confirm Info Per/Still Has Shares Per";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyConfirmedInfoStillHasShares_Error", excep.Message);
			}

		} // DisplayCompanyConfirmedInfoStillHasShares

		private static void DisplayCompanyProjectNotes(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'PROJ') AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}'))  AND (journ_comp_id > 0) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Companies Accessed";
						gstrFieldCode = "CPROJ";
						gstrFieldName = "Company Project Notes";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayCompanyProjectNotes_Error", excep.Message);
			}

		} // DisplayCompanyProjectNotes


		private static void DisplayContactsViewedCounts(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt  FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%View Contact%') ";
				strQuery1 = $"{strQuery1}AND (evtl_contact_id > 0) AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";


				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Contacts Accessed";
						gstrFieldCode = "VIEWCONTACT";
						gstrFieldName = "Contacts Viewed";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayContactsViewedCounts_Error", excep.Message);
			}

		} // DisplayContactsViewedCounts

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayContactsOpenCounts(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%Open Contact%') ";
				strQuery1 = $"{strQuery1}AND (evtl_contact_id > 0) AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Contacts Accessed";
						gstrFieldCode = "OPENCONTACT";
						gstrFieldName = "Contacts Opened";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayContactsOpenCounts_Error", excep.Message);
			}

		} // DisplayContactsOpenCounts

		private static void DisplayContactsAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%Contact Added%') ";
				strQuery1 = $"{strQuery1}AND (evtl_contact_id > 0)  AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Contacts Accessed";
						gstrFieldCode = "CTAD";
						gstrFieldName = "Contacts Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayContactsAdded_Error", excep.Message);
			}

		} // DisplayContactsAdded

		private static void DisplayContactsInactive(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subject LIKE '%Contact Inactivated%') AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";


				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Contacts Accessed";
						gstrFieldCode = "CTIA";
						gstrFieldName = "Contacts Inactivated";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayContactsInactive_Error", excep.Message);
			}

		} // DisplayContactsInactive

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayContactEMailsAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%Contact EMail Added%') ";
				strQuery1 = $"{strQuery1}AND (evtl_contact_id > 0) AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Contacts Accessed";
						gstrFieldCode = "CTEMA";
						gstrFieldName = "EMails Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayContactEMailsAdded_Error", excep.Message);
			}

		} // DisplayContactEMailsAdded

		private static void DisplayContactEMailsRemoved(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%Contact EMail Deleted%') ";
				strQuery1 = $"{strQuery1}AND (evtl_contact_id > 0) AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Contacts Accessed";
						gstrFieldCode = "CTEMR";
						gstrFieldName = "EMails Removed";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayContactEMailsRemoved_Error", excep.Message);
			}

		} // DisplayContactEMailsRemoved

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayContactPhonesAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(evtl_id) As TotCnt FROM EventLog WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(evtl_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(evtl_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message Like '%Contact Phone Added%') ";
				strQuery1 = $"{strQuery1}AND (evtl_contact_id > 0) AND (evtl_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (evtl_user_id IN ('{strUserId}')) ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Contacts Accessed";
						gstrFieldCode = "CTPA";
						gstrFieldName = "Phone Nbrs Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayContactPhonesAdded_Error", excep.Message);
			}

		} // DisplayContactPhonesAdded

		private static void DisplayContactPhonesRemoved(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(journ_id) As TotCnt FROM Journal WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(journ_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(journ_entry_time AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (journ_subject Like '%Removed Contact Phone Number%') ";
				strQuery1 = $"{strQuery1}AND (journ_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (journ_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Contacts Accessed";
						gstrFieldCode = "CTPR";
						gstrFieldName = "Phone Nbrs Removed";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayContactPhonesRemoved_Error", excep.Message);
			}

		} // DisplayContactPhonesRemoved

		private static void DisplayWantedsAdded(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(priorev_id) As TotCnt FROM Priority_Events WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(priorev_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(priorev_entry_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (priorev_category_code = 'NEWWA') ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (priorev_user_id IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Wanteds Accessed";
						gstrFieldCode = "NEWWA";
						gstrFieldName = "Wanteds Added";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayWantedsAdded_Error", excep.Message);
			}

		} // DisplayWantedsAdded

		//=========================================================================================================
		//=========================================================================================================

		private static void DisplayWantedDeletes(DbConnection cntConn, string strUserId, ref int lTotalActivity)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strJCatCode = "";
			string strJCatName = "";
			int lTotCnt = 0;
			int iPos1 = 0;

			try
			{

				strQuery1 = "SELECT COUNT(dlog_key) As TotCnt  FROM Delete_Log WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (CAST(dlog_entry_date AS DATE) BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				if (gstrTimeRange != "")
				{
					strQuery1 = $"{strQuery1}AND (CAST(dlog_entry_date AS TIME) BETWEEN {gstrTimeRange}) ";
				}

				strQuery1 = $"{strQuery1}AND (dlog_type = 'Wanted') ";
				strQuery1 = $"{strQuery1}AND (dlog_entry_user NOT IN ({gstrExcludeUsers})) ";
				strQuery1 = $"{strQuery1}AND (dlog_entry_user IN ('{strUserId}')) ";




				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTotalActivity = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
						lTotalActivity += lTotCnt;

						// Account Rep Activity Temp Table Record
						gstrGroup = "Wanteds Accessed";
						gstrFieldCode = "DELWA";
						gstrFieldName = "Wanted Deletes";
						glFieldCount = lTotCnt;

						Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DisplayWantedDeletes_Error", excep.Message);
			}

		} // DisplayWantedDeletes

		//=========================================================================================================
		//=========================================================================================================

		internal static void CreateTotalRecordBasedOnType(DbConnection cntConn, string strUserId, string strGroup, string strFieldCode, string strFieldName, string strTypeCodes)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int lTotCnt = 0;

			try
			{

				strQuery1 = $"SELECT SUM(ara_field_count) As TotCnt FROM {gstrTempTableName} ";
				strQuery1 = $"{strQuery1}WHERE (ara_acctrep_user_id = '{strUserId}') ";
				strQuery1 = $"{strQuery1}AND (ara_field_code IN ({strTypeCodes})) ";

				lTotCnt = 0;

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
				} //

				rstRec1.Close();

				// Account Rep Activity Temp Table Record
				gstrGroup = strGroup;
				gstrFieldCode = strFieldCode;
				gstrFieldName = strFieldName;
				glFieldCount = lTotCnt;

				Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("CreateTotalRecordBasedOnType_Error", excep.Message);
			}

		} // CreateTotalRecordBasedOnType

		//=========================================================================================================
		//=========================================================================================================

		internal static void CreateTotalRecordBasedOnGroup(DbConnection cntConn, string strUserId, string strGroup, string strFieldCode, string strFieldName, string strSearchGroup)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int lTotCnt = 0;

			try
			{

				strQuery1 = $"SELECT SUM(ara_field_count) As TotCnt FROM {gstrTempTableName} ";
				strQuery1 = $"{strQuery1}WHERE (ara_acctrep_user_id = '{strUserId}') ";
				strQuery1 = $"{strQuery1}AND (ara_field_group = '{strSearchGroup}') ";

				lTotCnt = 0;

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["TotCnt"]))
					{
						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
					}
				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				// Account Rep Activity Temp Table Record
				gstrGroup = strGroup;
				gstrFieldCode = strFieldCode;
				gstrFieldName = strFieldName;
				glFieldCount = lTotCnt;

				Add_Account_Rep_Activity_Record_To_Temp_Table(cntConn, strUserId, lTotCnt);

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("CreateTotalRecordBasedOnGroup_Error", excep.Message);
			}

		} // CreateTotalRecordBasedOnGroup

		private static void DisplayReportsPerAccountRep(DbConnection cntConn, string strUserId, ProgressBar pBar)
		{

			object strDateTime = null;
			object strStartDateTime = null;
			object strEndDateTime = null;

			DisplayGeneralCounts(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 1);

			DisplayAircraftAccessed(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 38);

			DisplayYachtAccessed(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 37);

			DisplayCompaniesAccessed(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 20);

			DisplayContactsAccessed(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 6);

			DisplayWantedsAccessed(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 1);

			DisplayAircraftPriorityEventsOpenCounts(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 1);

			DisplayYachtPriorityEventsOpenCounts(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 1);

			DisplayCompanyVerifiedAircraftCounts(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 1);

			DisplayCompanyVerifiedYachtCounts(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 1);

			DisplayCompanyUnableToVerifyCounts(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 1);

			DisplayCompanyVerifiedInfoCounts(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 1);

			DisplayCompanyContactFieldConfirmation(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 1);

			DisplayMonitorUserCursorMovementCounts(cntConn, strUserId);
			modCommon.IncProgressBar(pBar, 1);

			// A/C Pics, Logos and Yacht Pics Added/Deleted
			// APLYPAD
			// APIC      = Aircraft Pictures Added
			// DPIC      = A/C Pictures Deleted
			// ALOGO     = Attach Company Logo
			// YAPIC     = Yacht Pictures Added
			// YDPIC     = Yacht Pictures Deleted

			CreateTotalRecordBasedOnType(cntConn, strUserId, "Pubs Pics", "APLYPAD", "A/C Pics, Logos and Yacht Pics Added/Deleted", "'APIC','DPIC','ALOGO','YAPIC','YDPIC'");

			// A/C Pubs and Yacht News Add/Updates
			// AYPNAU
			// APUB      = A/C Pubs Added
			// UPUB      = A/C Pubs Updated
			// PBNOTE    = Pub Note
			// YNADDED   = Yacht News Added
			// YNUPDATED = Yacht News Updated

			CreateTotalRecordBasedOnType(cntConn, strUserId, "Pubs Pics", "AYPNAU", "A/C Pubs and Yacht News Add/Updates", "'APUB','UPUB','PBNOTE','YNADDED','YNUPDATED'");

			CreateTotalRecordBasedOnGroup(cntConn, strUserId, "Total Activity A/C Accessed", "TAAIRCRAFT", "Total Activity A/C Accessed", "Aircraft Accessed");

			CreateTotalRecordBasedOnGroup(cntConn, strUserId, "Total Activity A/C Category", "TACATEGORY", "Total Activity A/C Category", "Category");

		} // DisplayReportsPerAccountRep

		//=========================================================================================================
		//=========================================================================================================

		internal static void Create_UserHoursWorked_General_User_Counts(DbConnection cntConn, ProgressBar pBar, Label lblStatus)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUserId = "";

			if (gstrTempTableName != "")
			{

				if (gstrTeamLeaderUserId != "")
				{

					if (gstrExcludeUsers == "")
					{
						gstrExcludeUsers = modCommon.DLookUp("aconfig_exclude_users", "Application_Configuration");
					}

					Create_Account_Rep_Activity_Report_Temp_Table(cntConn);

					//-------------------------------------------
					// Get User Init From [User] Table

					strQuery1 = "SELECT user_id As UserId,  user_default_account_id As ACCTRep, ";
					strQuery1 = $"{strQuery1}user_first_name As FName, user_last_name As LName ";

					strQuery1 = $"{strQuery1}FROM [User] WITH (NOLOCK) ";
					if (gstrTeamLeaderTeam != "ALL USERS")
					{
						strQuery1 = $"{strQuery1}WHERE (user_id IN ({gstrTeamLeaderTeam})) ";
					}
					else
					{
						strQuery1 = $"{strQuery1}WHERE ([user_id] IS NOT NULL) ";
						strQuery1 = $"{strQuery1}AND ([user_id] NOT IN ({gstrExcludeUsers})) ";
					}

					strQuery1 = $"{strQuery1}AND (user_password <> 'inactive' OR user_password = '' OR user_password IS NULL) ";
					strQuery1 = $"{strQuery1}AND (user_default_account_id IS NOT NULL) ";
					strQuery1 = $"{strQuery1}ORDER BY FName, LName ";

					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						modCommon.SetProgressBar(pBar, (110 * rstRec1.RecordCount) + 4, 0, 0);

						do 
						{ // Loop Until rstRec1.EOF = True

							gstrUserId = ($"{Convert.ToString(rstRec1["UserId"])} ").Trim().ToUpper();
							gstrACCTRep = ($"{Convert.ToString(rstRec1["AcctRep"])} ").Trim().ToUpper();
							gstrUserFName = ($"{Convert.ToString(rstRec1["FName"])} ").Trim().ToUpper();
							gstrUserLName = ($"{Convert.ToString(rstRec1["LName"])} ").Trim().ToUpper();
							gstrUserName = ($"{gstrUserFName} {gstrUserLName}").ToUpper();

							lblStatus.Text = $"Working On - UserId: [{gstrUserId}] - AcctRep: [{gstrACCTRep}] - User Name: [{gstrUserName}]";
							Application.DoEvents();

							DisplayReportsPerAccountRep(cntConn, gstrUserId.ToLower(), pBar);

							rstRec1.MoveNext();

						}
						while(!rstRec1.EOF);

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

				} // If gstrTeamLeaderUserId <> "" Then

			} // If gstrTempTableName <> "" Then


		} // Create_UserHoursWorked_General_User_Counts

		private static int Return_Temp_Table_Report_Count(DbConnection cntConn, string strFieldCode, string strUserId)
		{

			int result = 0;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int lTotCnt = 0;

			int lResults = 0;

			try
			{

				lResults = 0;
				lTotCnt = 0;

				strQuery1 = $"SELECT * FROM {gstrTempTableName} ";
				strQuery1 = $"{strQuery1}WHERE (ara_field_code = '{strFieldCode}') ";
				strQuery1 = $"{strQuery1}AND (ara_acctrep_user_id = '{strUserId}') ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["ara_field_count"]))
					{
						lTotCnt = Convert.ToInt32(rstRec1["ara_field_count"]);
					}
				}

				rstRec1.Close();

				lResults = lTotCnt;

				rstRec1 = null;


				return lResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Return_Temp_Table_Report_Count_Error", excep.Message);

				result = 0;
			}
			return result;
		} // Return_Temp_Table_Report_Count

		//UPGRADE_NOTE: (7001) The following declaration (Return_Hours_Worked_Count) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private double Return_Hours_Worked_Count(DbConnection cntConn, string strUserId)
		//{
			//
			//double result = 0;
			//ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			//string strQuery1 = "";
			//double dHoursWorked = 0;
			//double dResults = 0;
			//
			//try
			//{
				//
				//dResults = 0d;
				//dHoursWorked = 0d;
				//
				//strQuery1 = "SELECT SUM(uh_hours_total_worked) As HoursWorked ";
				//strQuery1 = $"{strQuery1}FROM User_Hours WITH (NOLOCK)  WHERE (uh_user_id = '{strUserId}') ";
				//strQuery1 = $"{strQuery1}AND (uh_hours_date BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";
				//
				//rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				//
				//if (!rstRec1.BOF && !rstRec1.EOF)
				//{
					////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					//if (!Convert.IsDBNull(rstRec1["HoursWorked"]))
					//{
						//dHoursWorked = Convert.ToDouble(rstRec1["HoursWorked"]);
					//}
				//}
				//
				//rstRec1.Close();
				//
				//rstRec1 = null;
				//
				//dResults = dHoursWorked;
				//
				//
				//return dResults;
			//}
			//catch (System.Exception excep)
			//{
				//
				//modAdminCommon.Record_Error("Return_Hours_Worked_Count_Error", excep.Message);
				//
				//result = 0;
			//}
			//return result;
		//} // Return_Hours_Worked_Count

		//UPGRADE_NOTE: (7001) The following declaration (Return_RSCH_Hours_Count) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private double Return_RSCH_Hours_Count(DbConnection cntConn, string strUserId)
		//{
			//
			//double result = 0;
			//ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			//string strQuery1 = "";
			//double dHoursWorked = 0;
			//double dResults = 0;
			//
			//try
			//{
				//
				//dResults = 0d;
				//dHoursWorked = 0d;
				//
				//strQuery1 = "SELECT SUM(uh_hours_research) As RSCHHours ";
				//strQuery1 = $"{strQuery1}FROM User_Hours WITH (NOLOCK) ";
				//strQuery1 = $"{strQuery1}WHERE (uh_user_id = '{strUserId}') ";
				//strQuery1 = $"{strQuery1}AND (uh_hours_date BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";
				//
				//rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				//
				//if (!rstRec1.BOF && !rstRec1.EOF)
				//{
					////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					//if (!Convert.IsDBNull(rstRec1["RSCHHours"]))
					//{
						//dHoursWorked = Convert.ToDouble(rstRec1["RSCHHours"]);
					//}
				//}
				//
				//rstRec1.Close();
				//
				//rstRec1 = null;
				//
				//dResults = dHoursWorked;
				//
				//
				//return dResults;
			//}
			//catch (System.Exception excep)
			//{
				//
				//modAdminCommon.Record_Error("Return_RSCH_Hours_Count_Error", excep.Message);
				//
				//result = 0;
			//}
			//return result;
		//} // Return_RSCH_Hours_Count

		private static double Return_Hours_Worked_By_Report_Name(DbConnection cntConn, string strUserId, string strReportName)
		{

			double result = 0;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strFieldName = "";
			string strReportHours = "";
			double dHoursWorked = 0;
			double dResults = 0;

			try
			{

				dResults = 0d;
				dHoursWorked = 0d;

				strFieldName = "uh_hours_research";
				strFieldName = modCommon.DLookUp("urn_report_hours", "User_Report_Names", $"(urn_report_name = '{strReportName}' AND urn_active_flag = 'Y')");
				if (strFieldName == "")
				{
					strFieldName = "uh_hours_research";
				}

				strQuery1 = $"SELECT SUM({strFieldName}) As HoursWorked ";
				strQuery1 = $"{strQuery1}FROM User_Hours WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (uh_user_id = '{strUserId}') ";
				strQuery1 = $"{strQuery1}AND (uh_hours_date BETWEEN '{gstrStartDate}' AND '{gstrEndDate}') ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["HoursWorked"]))
					{
						dHoursWorked = Convert.ToDouble(rstRec1["HoursWorked"]);
					}
				}

				rstRec1.Close();

				rstRec1 = null;

				dResults = dHoursWorked;


				return dResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Return_Hours_Worked_By_Report_Name_Error", excep.Message);

				result = 0;
			}
			return result;
		} // Return_Hours_Worked_By_Report_Name

		private static void Create_UserHoursWorked_Excel_Headers_And_Data_Part1(DbConnection cntConn, ADORecordSetHelper rstRec1, ADORecordSetHelper rstRec2, dynamic oExcel, dynamic oExcelWB, dynamic oExcelWS, ref int lExcelRow, ref int lExcelCol)
		{

			int lCnt1 = 0;
			int lCnt2 = 0;

			int lCount = 0;

			rstRec2.MoveFirst();

			//-----------------------------------------
			// AcctRep Row

			lExcelRow = 1;
			lExcelCol = 1;

			int lStartRow = lExcelRow;
			int lStartCol = lExcelCol;

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Columns(lExcelCol).ColumnWidth = 40;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells[lExcelRow, lExcelCol] = gstrReportName;

			rstRec1.MoveFirst();
			do 
			{ // Loop Until rstRec1.EOF = True
				lExcelCol++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlYellow27;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Columns(lExcelCol).ColumnWidth = 15;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = ($"{Convert.ToString(rstRec1["AcctRep"])} ").Trim();
				rstRec1.MoveNext();
			}
			while(!rstRec1.EOF);

			int lMaxCol = lExcelCol;

			//-----------------------------------------
			// First Name Row

			lExcelRow++;
			lExcelCol = 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells[lExcelRow, lExcelCol] = $"Start Date: {gstrStartDate}";

			rstRec1.MoveFirst();
			do 
			{ // Loop Until rstRec1.EOF = True
				lExcelCol++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlYellow27;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = ($"{Convert.ToString(rstRec1["FName"])} ").Trim();
				rstRec1.MoveNext();
			}
			while(!rstRec1.EOF);

			//-----------------------------------------
			// Last Name Row

			lExcelRow++;
			lExcelCol = 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells[lExcelRow, lExcelCol] = $"End Date: {gstrEndDate}";

			rstRec1.MoveFirst();
			do 
			{ // Loop Until rstRec1.EOF = True
				lExcelCol++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlYellow27;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = ($"{Convert.ToString(rstRec1["LName"])} ").Trim();
				rstRec1.MoveNext();
			}
			while(!rstRec1.EOF);

			//-----------------------------------------
			// Cateogory/Count Row

			lExcelRow++;
			lExcelCol = 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells[lExcelRow, lExcelCol] = "Category";

			rstRec1.MoveFirst();
			do 
			{ // Loop Until rstRec1.EOF = True
				lExcelCol++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = "Count";
				rstRec1.MoveNext();
			}
			while(!rstRec1.EOF);

			modExcel.SetExcelDisplayOn(oExcel);
			Application.DoEvents();
			modExcel.SetExcelDisplayOff(oExcel);

			rstRec2.MoveFirst();
			do 
			{ // Loop Until rstRec2.EOF = True

				lExcelCol = 1;
				lExcelRow++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlCyan;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = ($"{Convert.ToString(rstRec2["uar_report_name"])} ").Trim();

				rstRec1.MoveFirst();
				do 
				{ // Loop Until rstRec1.EOF = True

					lExcelCol++;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlCream;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlRight;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
					lCount = Return_Temp_Table_Report_Count(cntConn, ($"{Convert.ToString(rstRec2["uar_report_code"])} ").Trim(), ($"{Convert.ToString(rstRec1["UserId"])} ").Trim());
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).NumberFormat = "#0";
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells[lExcelRow, lExcelCol] = StringsHelper.Format(lCount, "0");

					rstRec1.MoveNext();

				}
				while(!rstRec1.EOF);

				rstRec2.MoveNext();

			}
			while(!rstRec2.EOF);

			int lMaxRow = lExcelRow;

			string strRange = modExcel.ConvertRowColumnToExcelRange(lStartRow, lStartCol, lMaxRow, lMaxCol);

			modExcel.DrawGrid(oExcel, strRange);

			rstRec1.MoveFirst();
			rstRec2.MoveFirst();

			lExcelCol = lMaxCol;

			lExcelRow += 2;

			modExcel.SetExcelDisplayOn(oExcel);
			Application.DoEvents();
			modExcel.SetExcelDisplayOff(oExcel);

		} // Create_UserHoursWorked_Excel_Headers_And_Data_Part1

		private static void Create_UserHoursWorked_Excel_Headers_And_Data_Part2(DbConnection cntConn, ADORecordSetHelper rstRec1, ADORecordSetHelper rstRec2, dynamic oExcel, dynamic oExcelWB, dynamic oExcelWS, ref int lExcelRow, ref int lExcelCol)
		{

			int lCnt1 = 0;
			int lCnt2 = 0;

			int lStartRow = lExcelRow + 1;
			int lMaxCol = lExcelCol;

			lExcelCol = 1;
			int lStartCol = lExcelCol;
			glStartRowGoals = lExcelRow + 1;

			rstRec2.MoveFirst();
			do 
			{ // Loop Until rstRec2.EOF = True

				lExcelCol = 1;
				lExcelRow++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlCyan;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = ($"{Convert.ToString(rstRec2["uar_report_name"])} ").Trim();

				rstRec1.MoveFirst();
				do 
				{ // Loop Until rstRec1.EOF = True

					lExcelCol++;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlLtOrange;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec2["uar_report_goals"]))
					{
						//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						oExcelWS.Cells(lExcelRow, lExcelCol).NumberFormat = "#0.0##";
						//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						oExcelWS.Cells[lExcelRow, lExcelCol] = StringsHelper.Format(rstRec2["uar_report_goals"], "#0.0##");
					}

					rstRec1.MoveNext();

				}
				while(!rstRec1.EOF);

				rstRec2.MoveNext();

			}
			while(!rstRec2.EOF);

			int lMaxRow = lExcelRow;
			glEndRowGoals = lExcelRow;

			string strRange = modExcel.ConvertRowColumnToExcelRange(lStartRow, lStartCol, lMaxRow, lMaxCol);

			modExcel.DrawGrid(oExcel, strRange);

			rstRec1.MoveFirst();
			rstRec2.MoveFirst();

			lExcelCol = lMaxCol;
			lExcelRow += 2;

			modExcel.SetExcelDisplayOn(oExcel);
			Application.DoEvents();
			modExcel.SetExcelDisplayOff(oExcel);

		} // Create_UserHoursWorked_Excel_Headers_And_Data_Part2

		private static void Create_UserHoursWorked_Excel_Headers_And_Data_Part3(DbConnection cntConn, ADORecordSetHelper rstRec1, ADORecordSetHelper rstRec2, dynamic oExcel, dynamic oExcelWB, dynamic oExcelWS, ref int lExcelRow, ref int lExcelCol, bool bNormalize)
		{

			int lCnt1 = 0;
			int lCnt2 = 0;

			int iIColor = 0; // Interior Color - .Interior.ColorIndex
			int iFColor = 0; // Font Color - .Font.ColorIndex = xlBlack

			string strFieldCode = "";
			string strUserId = "";
			int lCount = 0;
			double dHoursWorked = 0;
			double dAvg = 0;
			double dGoal = 0;
			double dScore = 0;
			double dPercent = 0;
			string strSUMGoals = "";
			string strSUMAvg = "";
			string strFormula = "";

			rstRec2.MoveFirst();

			//-----------------------------------------
			// AcctRep Row

			if (bNormalize)
			{
				lExcelRow++;
				lExcelCol = 1;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlRed;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Font.ColorIndex = modExcel.xlWhite;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = "Normalized To Goal";
			}

			lExcelRow++;
			int lStartRow = lExcelRow;

			lExcelCol = 1;
			int lStartCol = lExcelCol;

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Columns(lExcelCol).ColumnWidth = 35;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells[lExcelRow, lExcelCol] = gstrReportName;

			rstRec1.MoveFirst();
			do 
			{ // Loop Until rstRec1.EOF = True
				lExcelCol++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlLtOrange;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Columns(lExcelCol).ColumnWidth = 15;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = ($"{Convert.ToString(rstRec1["AcctRep"])} ").Trim();
				rstRec1.MoveNext();
			}
			while(!rstRec1.EOF);

			int lMaxCol = lExcelCol;

			//-----------------------------------------
			// First Name Row

			lExcelRow++;
			lExcelCol = 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells[lExcelRow, lExcelCol] = $"Start Date: {gstrStartDate}";

			rstRec1.MoveFirst();
			do 
			{ // Loop Until rstRec1.EOF = True
				lExcelCol++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlLtOrange;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = ($"{Convert.ToString(rstRec1["FName"])} ").Trim();
				rstRec1.MoveNext();
			}
			while(!rstRec1.EOF);

			//-----------------------------------------
			// Last Name Row

			lExcelRow++;
			lExcelCol = 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells[lExcelRow, lExcelCol] = $"End Date: {gstrEndDate}";

			rstRec1.MoveFirst();
			do 
			{ // Loop Until rstRec1.EOF = True
				lExcelCol++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlLtOrange;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = ($"{Convert.ToString(rstRec1["LName"])} ").Trim();
				rstRec1.MoveNext();
			}
			while(!rstRec1.EOF);

			//-----------------------------------------
			// Cateogory/Count Row

			lExcelRow++;
			lExcelCol = 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells[lExcelRow, lExcelCol] = "Category";

			rstRec1.MoveFirst();
			do 
			{ // Loop Until rstRec1.EOF = True
				lExcelCol++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = "Count";
				rstRec1.MoveNext();
			}
			while(!rstRec1.EOF);

			modExcel.SetExcelDisplayOn(oExcel);
			Application.DoEvents();
			modExcel.SetExcelDisplayOff(oExcel);

			//----------------------------------------------
			// Now List The Report Names and Averages

			glStartRowAvg = lExcelRow + 1;

			rstRec2.MoveFirst();
			do 
			{ // Loop Until rstRec2.EOF = True

				lExcelCol = 1;
				lExcelRow++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlCyan;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = ($"{Convert.ToString(rstRec2["uar_report_name"])} ").Trim();

				rstRec1.MoveFirst();

				do 
				{ // Loop Until rstRec1.EOF = True

					lExcelCol++;
					iIColor = modExcel.xlCream; // Interior Color
					iFColor = modExcel.xlBlack; // Font Color

					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;

					strFieldCode = ($"{Convert.ToString(rstRec2["uar_report_code"])} ").Trim();
					strUserId = ($"{Convert.ToString(rstRec1["UserId"])} ").Trim();

					dGoal = 0d;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec2["uar_report_goals"]))
					{
						dGoal = Convert.ToDouble(rstRec2["uar_report_goals"]);
					}

					lCount = Return_Temp_Table_Report_Count(cntConn, strFieldCode, strUserId);
					//dHoursWorked = Return_Hours_Worked_Count(cntConn, strUserId)
					dHoursWorked = Return_Hours_Worked_By_Report_Name(cntConn, strUserId, gstrReportName);

					dAvg = 0d;
					if (lCount > 0 && dHoursWorked > 0)
					{
						dAvg = lCount / dHoursWorked;
					}

					if (dGoal > 0)
					{
						if (dAvg > 0)
						{
							if (dAvg >= dGoal)
							{
								iIColor = modExcel.xlLtGreen;
								if (bNormalize)
								{
									dAvg = dGoal;
								}
							}
							else
							{
								dPercent = 100 - (dAvg / dGoal * 100);
								if (dPercent <= 10)
								{
									iIColor = modExcel.xlYellow; // Almost Reached Goal
								}
								else
								{
									iIColor = modExcel.xlRed; // Feel Short of Goal
									//iFColor = xlWhite
								}
							}
						} // If dAvg > 0 Then
					} // If dGoal > 0 Then

					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = iIColor;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).Font.ColorIndex = iFColor;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).NumberFormat = "#0.00";
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells[lExcelRow, lExcelCol] = StringsHelper.Format(dAvg, "0.00");

					rstRec1.MoveNext();

				}
				while(!rstRec1.EOF);

				rstRec2.MoveNext();

			}
			while(!rstRec2.EOF);

			glEndRowAvg = lExcelRow;

			//------------------------------------------------------
			// Hours Researched

			lExcelRow++;
			lExcelCol = 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlCream;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells[lExcelRow, lExcelCol] = "Hours Researched";

			rstRec1.MoveFirst();
			do 
			{ // Loop Until rstRec1.EOF = True

				lExcelCol++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlCream;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;

				strUserId = ($"{Convert.ToString(rstRec1["UserId"])} ").Trim();
				//dHoursWorked = Return_Hours_Worked_Count(cntConn, strUserId)
				dHoursWorked = Return_Hours_Worked_By_Report_Name(cntConn, strUserId, gstrReportName);
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).NumberFormat = "#0.0";
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = StringsHelper.Format(dHoursWorked, "0.0");

				rstRec1.MoveNext();

			}
			while(!rstRec1.EOF);

			//------------------------------------------------------
			// Scores

			lExcelRow++;
			lExcelCol = 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlLtOrange;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlRight;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Font.Bold = true;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells[lExcelRow, lExcelCol] = "Scores";

			rstRec1.MoveFirst();

			do 
			{ // Loop Until rstRec1.EOF = True

				lExcelCol++;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlLtOrange;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;

				dScore = 0d;
				strSUMGoals = modExcel.ConvertRowColumnToExcelRange(glStartRowGoals, lExcelCol, glEndRowGoals, lExcelCol);
				strSUMAvg = modExcel.ConvertRowColumnToExcelRange(glStartRowAvg, lExcelCol, glEndRowAvg, lExcelCol);
				strFormula = $"=SUM({strSUMAvg})/SUM({strSUMGoals})";
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).NumberFormat = "#0.0%";
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells[lExcelRow, lExcelCol] = strFormula;

				rstRec1.MoveNext();

			}
			while(!rstRec1.EOF);

			int lMaxRow = lExcelRow;

			string strRange = modExcel.ConvertRowColumnToExcelRange(lStartRow, lStartCol, lMaxRow, lMaxCol);

			modExcel.DrawGrid(oExcel, strRange);

			rstRec1.MoveFirst();
			rstRec2.MoveFirst();

			lExcelCol = lMaxCol;

			lExcelRow += 2;

			// Move To The Top Of The Excel File
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Range("A1:A1", "A1:A1").Select();

			modExcel.SetExcelDisplayOn(oExcel);
			Application.DoEvents();
			modExcel.SetExcelDisplayOff(oExcel);

		} // Create_UserHoursWOrked_Excel_Headers_And_Data_Part3

		private static void Create_UserHoursWorked_Excel_Headers_And_Data(DbConnection cntConn, ADORecordSetHelper rstRec1, ProgressBar pBar, dynamic oExcel, dynamic oExcelWB, dynamic oExcelWS, ref int lExcelRow, ref int lExcelCol, string strFieldCodes)
		{

			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strQuery2 = "";

			try
			{

				if (strFieldCodes != "")
				{

					rstRec1.MoveFirst();

					strQuery2 = "SELECT * FROM User_Activity_Reports WITH (NOLOCK) ";
					strQuery2 = $"{strQuery2}WHERE (uar_report_code IN ({strFieldCodes})) ";
					strQuery2 = $"{strQuery2}AND (uar_productivity_report = '{gstrReportName}') ";
					strQuery2 = $"{strQuery2}ORDER BY uar_report_name ";

					rstRec2.Open(strQuery2, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec2.BOF && !rstRec2.EOF)
					{

						lExcelRow = 0;
						lExcelCol = 0;

						Create_UserHoursWorked_Excel_Headers_And_Data_Part1(cntConn, rstRec1, rstRec2, oExcel, oExcelWB, oExcelWS, ref lExcelRow, ref lExcelCol);
						modCommon.IncProgressBar(pBar, 1);

						Create_UserHoursWorked_Excel_Headers_And_Data_Part2(cntConn, rstRec1, rstRec2, oExcel, oExcelWB, oExcelWS, ref lExcelRow, ref lExcelCol);
						modCommon.IncProgressBar(pBar, 1);

						Create_UserHoursWorked_Excel_Headers_And_Data_Part3(cntConn, rstRec1, rstRec2, oExcel, oExcelWB, oExcelWS, ref lExcelRow, ref lExcelCol, false);
						modCommon.IncProgressBar(pBar, 1);

						Create_UserHoursWorked_Excel_Headers_And_Data_Part3(cntConn, rstRec1, rstRec2, oExcel, oExcelWB, oExcelWS, ref lExcelRow, ref lExcelCol, true);
						modCommon.IncProgressBar(pBar, 1);

					} // If rstRec2.BOF = False And rstRec2.EOF = False Then

					rstRec2.Close();

				} // If strFieldCodes <> "" Then

				rstRec2 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Create_UserHoursWorked_Excel_Headers_And_Data_Error", excep.Message);
			}

		} // Create_UserHoursWorked_Excel_Headers_And_Data

		//=========================================================================================================
		//=========================================================================================================

		internal static void Create_UserHoursWorked_Report(DbConnection cntConn, ProgressBar pBar, Label lblStatus)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strQuery2 = "";
			string strUserId = "";

			ExcelApplication objExcel = null; //gap-note Review excel type during stabilization
            ExcelApplication objExcelWB = null; //gap-note Review excel type during stabilization
            ExcelApplication objExcelWS = null; //gap-note Review excel type during stabilization

			int lExcelRow = 0;
			int lExcelCol = 0;

			string strExcelDir = "";
			string strFileName = "";
			string strFullFileName = "";

			string strFieldCodes = "";

			object strMsg = null;

			try
			{

				strMsg = $"Started Report {gstrReportName} To Excel - Dates: {gstrStartDate} to {gstrEndDate}";
				//UPGRADE_WARNING: (1068) strMsg of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				lblStatus.Text = Convert.ToString(strMsg);
				Application.DoEvents();

				//UPGRADE_WARNING: (1068) strMsg of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				modAdminCommon.Record_Event("User Hours", Convert.ToString(strMsg), 0, 0, 0, false, 0, 0);

				strExcelDir = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\ExcelFiles";
				if (!Directory.Exists(strExcelDir))
				{
					Directory.CreateDirectory(strExcelDir);
				}

				if (gstrTempTableName != "")
				{

					if (gstrTeamLeaderUserId != "")
					{

						if (gstrExcludeUsers == "")
						{
							gstrExcludeUsers = modCommon.DLookUp("aconfig_exclude_users", "Application_Configuration");
						}

						strFieldCodes = Return_Field_Codes_For_Report(cntConn, gstrReportName);

						if (strFieldCodes != "")
						{

							strFileName = gstrReportName.ToLower();
							strFileName = StringsHelper.Replace(strFileName, " ", "_", 1, -1, CompareMethod.Binary);
							strFileName = StringsHelper.Replace(strFileName, "/", "_", 1, -1, CompareMethod.Binary);
							strFileName = StringsHelper.Replace(strFileName, "-", "_", 1, -1, CompareMethod.Binary);

							System.DateTime TempDate3 = DateTime.FromOADate(0);
							System.DateTime TempDate2 = DateTime.FromOADate(0);
							strFileName = $"research_{strFileName}_{((DateTime.TryParse(gstrStartDate, out TempDate2)) ? TempDate2.ToString("yyyyMMdd") : gstrStartDate)}_{((DateTime.TryParse(gstrEndDate, out TempDate3)) ? TempDate3.ToString("yyyyMMdd") : gstrEndDate)}.xls";
							strFullFileName = $"{strExcelDir}\\{strFileName}";

							if (File.Exists(strFullFileName))
							{

								if (MessageBox.Show($"Report File Already Exits.{Environment.NewLine}{Environment.NewLine}{strFileName}{Environment.NewLine}{Environment.NewLine}Overwrite?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
								{
									//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
									File.Delete(strFullFileName);
								}

							} // If gfso.FileExists(strFullFileName) = True Then

							if (!File.Exists(strFullFileName))
							{

								//-------------------------------------------
								// Get User Init From [User] Table

								strQuery1 = "SELECT user_id As UserId, ";
								strQuery1 = $"{strQuery1}user_default_account_id As ACCTRep, ";
								strQuery1 = $"{strQuery1}user_first_name As FName, ";
								strQuery1 = $"{strQuery1}user_last_name As LName ";

								strQuery1 = $"{strQuery1}FROM [User] WITH (NOLOCK) ";
								if (gstrTeamLeaderTeam != "ALL USERS")
								{
									strQuery1 = $"{strQuery1}WHERE (user_id IN ({gstrTeamLeaderTeam})) ";
								}
								else
								{
									strQuery1 = $"{strQuery1}WHERE ([user_id] IS NOT NULL) ";
									strQuery1 = $"{strQuery1}AND ([user_id] NOT IN ({gstrExcludeUsers})) ";
								}

								strQuery1 = $"{strQuery1}AND (user_password <> 'inactive' OR user_password = '' OR user_password IS NULL) ";
								strQuery1 = $"{strQuery1}AND (user_default_account_id IS NOT NULL) ";
								strQuery1 = $"{strQuery1}ORDER BY ACCTRep, FName, LName ";

								rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								if ((!rstRec1.BOF) && (!rstRec1.EOF))
								{

									if (modExcel.Create_Excel_File(ref objExcel, ref objExcelWB, ref objExcelWS, strFullFileName))
									{

										lExcelRow = 0;
										lExcelCol = 0;

										modExcel.SetExcelDisplayOff(objExcel);

										Create_UserHoursWorked_Excel_Headers_And_Data(cntConn, rstRec1, pBar, objExcel, objExcelWB, objExcelWS, ref lExcelRow, ref lExcelCol, strFieldCodes);

										modExcel.SetExcelDisplayOn(objExcel);

										modExcel.Save_Excel_File(objExcel, objExcelWB, objExcelWS, strFullFileName);

										Application.DoEvents();

									} // If Create_Excel_File(objExcel, objExcelWB, objExcelWS, strFullFileName) = True Then

								} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

								rstRec1.Close();

							} // If gfso.FileExists(strFullFileName) = False Then

						}
						else
						{
							lblStatus.Text = "Unable To Get Field Codes For Report Name";
						} // If strFieldCodes <> "" Then

					}
					else
					{
						lblStatus.Text = "Unable To Get Team Leader User Id";
					} // If gstrTeamLeaderUserId <> "" Then

				}
				else
				{
					lblStatus.Text = "Unable To Get Temp Table Name";
				} // If gstrTempTableName <> "" Then

				objExcelWS = null;
				objExcelWB = null;
				objExcel = null;
				rstRec2 = null;
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Create_UserHoursWorked_Report_Error", excep.Message);

				modExcel.SetExcelDisplayOn(objExcel);
			}

		} // Create_UserHoursWorked_Report
	}
}