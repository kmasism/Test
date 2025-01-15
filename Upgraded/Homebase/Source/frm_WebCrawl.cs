using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_WebCrawl
		: System.Windows.Forms.Form
	{

		public int New_Pub_AC_ID = 0; // GLOBAL FOR IDENTIFICATION OF A NEW AIRCRAFT FOR A PUBLICATION
		public string WhichAcctRep = ""; // GLOBAL FOR KNOWING WHICH ACCT REP'S LIST THE USER WANTS TO SEE

		ADORecordSetHelper NewRecs = null; // RECORDSET FOR LOADING NEW AVAILABLES
		string Edit_Status = "";

		bool gblCleared = false;
		string gblOrderBy = "";
		string RememberAcctRep = "";
		bool StopStatus = false;

		int[] ac_list = null;
		string Airframe_Type = "";
		int[] PubsToClear = null;
		string HowMatched = "";
		bool b_updateFlag = false;
		bool bFormFilling = false;
		bool bGridFilling = false;
		bool bTryinToUnload = false;
		public int pub_id = 0;
		public string account_rep = "";
		public string from_spot = "";
		public int last_tab = 0;


		int category_id = 0;
		int first_attempt = 0;
		int second_attempt = 0;
		int third_attempt = 0;
		int hold_review = 0;
		int completed = 0;
		int open_check = 0;
		int in_progress = 0;
		int blind = 0;
		int cleared_check = 0;
		int no_action = 0;

		int status_drop = 0;
		int comp_text = 0;
		int date_range1 = 0;
		int date_range2 = 0;

		int count_label = 0;
		public frm_WebCrawl()
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






		private void AlignNewAvailRecordset(int inRow)
		{

			try
			{


				if (!(NewRecs.BOF && NewRecs.EOF))
				{
					NewRecs.MoveFirst();

					int tempForEndVar = inRow - 1;
					for (int i = 1; i <= tempForEndVar; i++)
					{
						NewRecs.MoveNext();
					}

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"AlignNewAvailRecordset_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_webCrawl(ALIGN)");
			}

		}

		public void assign_correct_account_rep()
		{
			string strAssignSort = "";
			// if there is a company id, then add it in automatically - 10/12/21
			string Query = "";
			ADORecordSetHelper snp_Assign = null;
			if (txt_pub[6].Text.Trim() != "" && Information.IsNumeric(txt_pub[6].Text.Trim()))
			{

				// added MSW - dont auto do it for pub
				if (cbo_pub[6].Text.Trim() == "Pub")
				{
					fill_account_rep(cbo_pub[0]);
				}
				else
				{
					Query = "select assign_db_account_id, assign_eu_account_id, comp_account_type from Account_Rep_Assignment with (NOLOCK) ";

					Query = $"{Query} inner join company with (NOLOCK) on comp_id = {txt_pub[6].Text.Trim()} and comp_journ_id = 0 and comp_active_flag = 'Y'";

					Query = $"{Query} and left(comp_name, 1) = assign_character ";
					Query = $"{Query} Where left(comp_name, 1) = assign_character ";

					Query = $"{Query}{strAssignSort}";
					snp_Assign = new ADORecordSetHelper();
					snp_Assign.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snp_Assign.BOF && snp_Assign.EOF))
					{

						while(!snp_Assign.EOF)
						{

							if (Convert.ToString(snp_Assign["COMP_ACCOUNT_TYPE"]).Trim() == "EU")
							{
								cbo_pub[0].Text = (Convert.ToString(snp_Assign["assign_eu_account_id"]).Trim());
							}
							else
							{
								cbo_pub[0].Text = (Convert.ToString(snp_Assign["assign_db_account_id"]).Trim());
							}

							snp_Assign.MoveNext();
						};
					}
					snp_Assign.Close();
				}

			}

		}

		public void check_clear_close_form()
		{

			if (from_spot.Trim() == "AC" || from_spot.Trim() == "COMP")
			{


				from_spot = "";
				this.Close();
			}
			from_spot = "";

		}

		private void ClearPub(int inPubID, int inACID, string inSource, bool inNoChangeFlag = false)
		{

			string Query = "";

			if (inNoChangeFlag)
			{
				modAdminCommon.Rec_Journal_Info.journ_subject = $"Cleared {inSource.Trim()} Pub - No Change";
			}
			else
			{
				modAdminCommon.Rec_Journal_Info.journ_subject = $"Cleared {inSource.Trim()} Pub";
			}
			modAdminCommon.Rec_Journal_Info.journ_description = " ";
			modAdminCommon.Rec_Journal_Info.journ_ac_id = inACID;
			modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
			modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
			modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
			modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
			modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
			modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
			modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
			modAdminCommon.Rec_Journal_Info.journ_status = "A";

			int PubJournID = frm_Journal.DefInstance.Commit_Journal_Entry();

			if (PubJournID > 0)
			{

				Query = $"UPDATE Publication_Log  SET publog_status = 'C', publog_clear_date = '{modAdminCommon.GetSystemDateTime()}', ";
				Query = $"{Query}publog_journ_id = {PubJournID.ToString()}  WHERE publog_id = {inPubID.ToString()}";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				if (!inNoChangeFlag)
				{
					frm_Journal.DefInstance.Reference_Journal_ID = PubJournID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					frm_Journal.DefInstance.ShowDialog();
				}
			}
			else
			{

				MessageBox.Show($"Error Trying to Clear Pub!{Environment.NewLine}Pub NOT CLEARED", "PUBS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			}

		}

		public void complete_csd_click()
		{


			int lSubISId = 0;
			int lCol = 0;
			string strUpdate1 = "";

			//  On Error GoTo cmd_in_progress_Click_Error

			int lRow = fgrdFindCustSubData.CurrentRowIndex;

			if (lRow > 0)
			{

				// cmd_in_progress.Enabled = False

				lSubISId = fgrdFindCustSubData.get_RowData(lRow);
				if (lSubISId > 0)
				{

					if (cmd_pub[16].Text == "Change to: No Longer In Process")
					{
						strUpdate1 = "UPDATE Subscription_Install_Log SET subislog_msg_type = 'Submitted Data' ";
					}
					else
					{
						strUpdate1 = "UPDATE Subscription_Install_Log SET subislog_msg_type = 'Submitted Data In Progress' ";
					}

					strUpdate1 = $"{strUpdate1}WHERE (subislog_id = {lSubISId.ToString()}) ";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strUpdate1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();


					Fill_Find_Customer_Submitted_Data_Grid();

				} // If lSubISId > 0 Then

				cmd_pub[16].Enabled = true;

			} // If lRow > 0 Then


		}

		public bool double_check_comp_ids()
		{

			bool result = false;
			result = true;


			string Query1 = $"select top 1 comp_id from company with (NOLOCK) where comp_journ_id = 0 and comp_id = {txt_pub[6].Text}";

			if (!modAdminCommon.Exist(Query1))
			{
				result = false;
			}


			return result;
		}

		public bool double_check_ac_ids()
		{

			bool result = false;
			result = true;


			string Query1 = $"select top 1 ac_id from aircraft with (NOLOCK) where ac_journ_id = 0 and ac_id = {txt_pub[1].Text}";

			if (!modAdminCommon.Exist(Query1))
			{
				result = false;
			}


			return result;
		}


		public object find_select_status_index(string type_of, string type_status)
		{



			if (type_of.Trim() == "Pub")
			{

				//If gbl_User_ID = "mvit" Or gbl_User_ID = "pls" Or gbl_User_ID = "jkc" Or gbl_User_ID = "avl" Or gbl_User_ID = "cs" Or gbl_User_ID = "njh" Or gbl_User_ID = "llp" Or gbl_User_ID = "has" Or gbl_User_ID = "cjb" Or gbl_User_ID = "cjb2" Or LCase(gbl_User_ID) = "kkf" Or LCase(gbl_User_ID) = "ead" Or LCase(gbl_User_ID) = "edpb" Or LCase(gbl_User_ID) = "alpb" Or LCase(gbl_User_ID) = "alsp" Or LCase(gbl_User_ID) = "cbpb" Or LCase(gbl_User_ID) = "jdsp" Or LCase(gbl_User_ID) = "jjd" Or LCase(gbl_User_ID) = "jlf" Then
				if (modAdminCommon.gbl_User_ID == "mvit" || modAdminCommon.gbl_User_ID == "pls" || modAdminCommon.gbl_User_ID == "jkc" || modAdminCommon.gbl_User_ID == "avl" || modAdminCommon.gbl_User_ID == "cs" || modAdminCommon.gbl_User_ID == "llp" || modAdminCommon.gbl_User_ID == "has" || modAdminCommon.gbl_User_ID == "cbqc" || modAdminCommon.gbl_User_ID == "cjb" || modAdminCommon.gbl_User_ID == "cjb2" || modAdminCommon.gbl_User_ID.ToLower() == "kkf" || modAdminCommon.gbl_User_ID.ToLower() == "ead" || modAdminCommon.gbl_User_ID.ToLower() == "edpb" || modAdminCommon.gbl_User_ID.ToLower() == "alpb" || modAdminCommon.gbl_User_ID.ToLower() == "alsp" || modAdminCommon.gbl_User_ID.ToLower() == "cbpb" || modAdminCommon.gbl_User_ID.ToLower() == "tpb" || modAdminCommon.gbl_User_ID.ToLower() == "jmm" || modAdminCommon.gbl_User_ID.ToLower() == "kvl" || modAdminCommon.gbl_User_ID.ToLower() == "nad")
				{ // commented out with njh -  Or LCase(gbl_User_ID) = "jdsp" Or LCase(gbl_User_ID) = "jjd" Or LCase(gbl_User_ID) = "jlf"   ' removed Or LCase(gbl_User_ID) = "mcil"
					if (type_status.Trim() == "C")
					{
						cbo_pub[1].SelectedIndex = 0;
						cbo_pub[1].Tag = "C";
					}
					else if (type_status.Trim() == "N")
					{ 
						cbo_pub[1].SelectedIndex = 1;
						cbo_pub[1].Tag = "N";
					}
					else if (type_status.Trim() == "O")
					{ 
						cbo_pub[1].SelectedIndex = 2;
						cbo_pub[1].Tag = "O";
					}
					else if (type_status.Trim() == "I")
					{ 
						cbo_pub[1].SelectedIndex = 3;
						cbo_pub[1].Tag = "I";
					}
				}
				else
				{
					if (type_status.Trim() == "N")
					{
						cbo_pub[1].SelectedIndex = 0;
						cbo_pub[1].Tag = "N";
					}
					else if (type_status.Trim() == "O")
					{ 
						cbo_pub[1].SelectedIndex = 1;
						cbo_pub[1].Tag = "O";
					}
					else if (type_status.Trim() == "I")
					{ 
						cbo_pub[1].SelectedIndex = 2;
						cbo_pub[1].Tag = "I";
					}
				}





			}
			else if (type_of.Trim() == "Memo")
			{ 

				if (type_status.Trim() == "O")
				{
					cbo_pub[1].SelectedIndex = 0;
					cbo_pub[1].Tag = "O";
				}
				else if (type_status.Trim() == "1")
				{ 
					cbo_pub[1].SelectedIndex = 1;
					cbo_pub[1].Tag = "1";
				}
				else if (type_status.Trim() == "2")
				{ 
					cbo_pub[1].SelectedIndex = 2;
					cbo_pub[1].Tag = "2";
				}
				else if (type_status.Trim() == "3")
				{ 
					cbo_pub[1].SelectedIndex = 3;
					cbo_pub[1].Tag = "3";
				}
				else if (type_status.Trim() == "Z")
				{ 
					cbo_pub[1].SelectedIndex = 4;
					cbo_pub[1].Tag = "Z";
				}
				else if (type_status.Trim() == "H")
				{ 
					cbo_pub[1].SelectedIndex = 5;
					cbo_pub[1].Tag = "H";
				}

			}
			else if (type_of.Trim() == "Doc Request")
			{ 

				if (type_status.Trim() == "O")
				{
					cbo_pub[1].SelectedIndex = 0;
					cbo_pub[1].Tag = "O";
				}
				else if (type_status.Trim() == "H")
				{ 
					cbo_pub[1].SelectedIndex = 1;
					cbo_pub[1].Tag = "H";
				}
				else if (type_status.Trim() == "Z")
				{ 
					cbo_pub[1].SelectedIndex = 2;
					cbo_pub[1].Tag = "Z";
				}

			}

			return null;
		}

		private string GetACCTRep(int inACID)
		{


			string result = "";
			try
			{

				string Query = "";
				ADORecordSetHelper snpAcct = new ADORecordSetHelper();

				result = "";

				Query = "SELECT comp_account_id  FROM Company  INNER JOIN Aircraft_Reference ON cref_comp_id = comp_id ";
				Query = $"{Query}AND cref_journ_id = comp_journ_id  WHERE cref_ac_id = {inACID.ToString()} ";
				Query = $"{Query}AND cref_primary_poc_flag = 'Y'  AND cref_journ_id = 0";

				snpAcct.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpAcct.BOF && snpAcct.EOF))
				{
					snpAcct.MoveFirst();
					result = ($"{Convert.ToString(snpAcct["comp_account_id"])}").Trim();
				}

				snpAcct.Close();
				snpAcct = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"GetACCTRep_Error: {excep.Message}");
			}

			return result;
		}

		//UPGRADE_NOTE: (7001) The following declaration (GetAFTT) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private string GetAFTT(int inACID, int inJournID)
		//{
			//
			//string result = "";
			//ADORecordSetHelper snpAFTT = new ADORecordSetHelper();
			//
			//
			//string Query = "SELECT ac_airframe_tot_hrs  FROM Aircraft ";
			//Query = $"{Query}WHERE ac_id = {inACID.ToString()} AND ac_journ_id = {inJournID.ToString()}";
			//
			//snpAFTT.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			//
			//if (!(snpAFTT.BOF && snpAFTT.EOF))
			//{
				//snpAFTT.MoveFirst();
				//if (($"{Convert.ToString(snpAFTT["ac_airframe_tot_hrs"])}").Trim() != "")
				//{
					//result = Strings.FormatNumber(($"{Convert.ToString(snpAFTT["ac_airframe_tot_hrs"])}").Trim(), 0, TriState.False, TriState.False, TriState.True);
				//}
			//}
			//
			//snpAFTT.Close();
			//
			//return result;
		//}

		private string GetEmailAddress(string inSite)
		{

			string result = "";
			try
			{

				string Query = "";
				ADORecordSetHelper snpEmail = new ADORecordSetHelper();

				result = "";

				if (cbo_WebSite.Text.Trim() != "")
				{
					Query = "SELECT pub_email_address FROM Publications ";
					Query = $"{Query}WHERE (pub_abbrev = '{inSite}')  AND (pub_email_address IS NOT NULL) ";
					Query = $"{Query}AND (pub_email_address <> '') ";

					snpEmail.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpEmail.BOF && snpEmail.EOF))
					{
						result = ($"{Convert.ToString(snpEmail["pub_email_address"])}").Trim();
					}

					snpEmail.Close();
					snpEmail = null;

				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"GetEmailAddress_Error: {excep.Message}");
			}

			return result;
		}

		public void load_correct_statuses(string status_type)
		{



			cbo_pub[1].Items.Clear();

			if (status_type.Trim() == "")
			{


				if (modAdminCommon.gbl_User_ID == "mvit" || modAdminCommon.gbl_User_ID == "pls" || modAdminCommon.gbl_User_ID == "jkc" || modAdminCommon.gbl_User_ID == "avl" || modAdminCommon.gbl_User_ID == "cs" || modAdminCommon.gbl_User_ID == "njh" || modAdminCommon.gbl_User_ID == "llp" || modAdminCommon.gbl_User_ID == "has" || modAdminCommon.gbl_User_ID == "cbqc" || modAdminCommon.gbl_User_ID == "cjb" || modAdminCommon.gbl_User_ID == "cjb2" || modAdminCommon.gbl_User_ID.ToLower() == "kkf" || modAdminCommon.gbl_User_ID.ToLower() == "ead" || modAdminCommon.gbl_User_ID.ToLower() == "edpb" || modAdminCommon.gbl_User_ID.ToLower() == "alpb" || modAdminCommon.gbl_User_ID.ToLower() == "alsp" || modAdminCommon.gbl_User_ID.ToLower() == "cbpb" || modAdminCommon.gbl_User_ID.ToLower() == "jdsp" || modAdminCommon.gbl_User_ID.ToLower() == "jjd" || modAdminCommon.gbl_User_ID.ToLower() == "jlf" || modAdminCommon.gbl_User_ID.ToLower() == "tpb" || modAdminCommon.gbl_User_ID.ToLower() == "jmm" || modAdminCommon.gbl_User_ID.ToLower() == "kvl" || modAdminCommon.gbl_User_ID.ToLower() == "nad")
				{
					cbo_pub[1].AddItem("C - Cleared");
					cbo_pub[1].AddItem("N - No Action Required");
					cbo_pub[1].AddItem("O - Open");
					cbo_pub[1].AddItem("I - In Progress");

					cbo_pub[1].AddItem("1st Attempt");
					cbo_pub[1].AddItem("2nd Attempt");
					cbo_pub[1].AddItem("3rd Attempt");

					cbo_pub[1].AddItem("H - Hold");
					cbo_pub[1].AddItem("Z - Completed");
				}
				else
				{
					// cbo_pub(1).AddItem ("C - Cleared") ' then they cant clear
					cbo_pub[1].AddItem("N - No Action Required");
					cbo_pub[1].AddItem("O - Open");
					cbo_pub[1].AddItem("I - In Progress");

					cbo_pub[1].AddItem("1st Attempt");
					cbo_pub[1].AddItem("2nd Attempt");
					cbo_pub[1].AddItem("3rd Attempt");

					cbo_pub[1].AddItem("H - Hold");
					cbo_pub[1].AddItem("Z - Completed");
				}



			}
			else if (status_type.Trim() == "Memo")
			{ 

				cbo_pub[1].AddItem("O - Open");
				cbo_pub[1].AddItem("1st Attempt");
				cbo_pub[1].AddItem("2nd Attempt");
				cbo_pub[1].AddItem("3rd Attempt");
				cbo_pub[1].AddItem("Z - Completed");
				cbo_pub[1].AddItem("H - HOLD/Review");


			}
			else if (status_type.Trim() == "Pub")
			{ 


				if (modAdminCommon.gbl_User_ID == "mvit" || modAdminCommon.gbl_User_ID == "pls" || modAdminCommon.gbl_User_ID == "jkc" || modAdminCommon.gbl_User_ID == "avl" || modAdminCommon.gbl_User_ID == "cs" || modAdminCommon.gbl_User_ID == "njh" || modAdminCommon.gbl_User_ID == "llp" || modAdminCommon.gbl_User_ID == "has" || modAdminCommon.gbl_User_ID == "cbqc" || modAdminCommon.gbl_User_ID == "cjb" || modAdminCommon.gbl_User_ID == "cjb2" || modAdminCommon.gbl_User_ID.ToLower() == "kkf" || modAdminCommon.gbl_User_ID.ToLower() == "ead" || modAdminCommon.gbl_User_ID.ToLower() == "edpb" || modAdminCommon.gbl_User_ID.ToLower() == "alpb" || modAdminCommon.gbl_User_ID.ToLower() == "alsp" || modAdminCommon.gbl_User_ID.ToLower() == "cbpb" || modAdminCommon.gbl_User_ID.ToLower() == "jdsp" || modAdminCommon.gbl_User_ID.ToLower() == "jjd" || modAdminCommon.gbl_User_ID.ToLower() == "jlf" || modAdminCommon.gbl_User_ID.ToLower() == "tpb" || modAdminCommon.gbl_User_ID.ToLower() == "jmm" || modAdminCommon.gbl_User_ID.ToLower() == "kvl" || modAdminCommon.gbl_User_ID.ToLower() == "nad")
				{ // removed Or LCase(gbl_User_ID) = "mcil"
					cbo_pub[1].AddItem("C - Cleared");
				}
				else
				{

				}

				cbo_pub[1].AddItem("N - No Action Required");
				cbo_pub[1].AddItem("O - Open");
				cbo_pub[1].AddItem("I - In Progress");

			}
			else if (status_type.Trim() == "Doc Request")
			{ 

				cbo_pub[1].AddItem("O - Open");
				cbo_pub[1].AddItem("H - Hold");
				cbo_pub[1].AddItem("Z - Completed");

			}




		}

		public void pub_single_click_code(int temp_pub_id, int temp_row_id, string temp_cat = "")
		{
			MouseButtons Button = (MouseButtons) 0;



			int lCol1 = 0;
			string Query = "";
			string bgcolor = "";
			int lRow1 = grd_NewAvail.CurrentRowIndex;

			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			//cbo_pub 6 is the current one - cat is the changed one
			// if the type has changed 8/18/22
			if (temp_cat != cbo_pub[6].Text)
			{
				if (temp_cat.Trim() == "Memo")
				{
					load_pub_sources(false, temp_cat);
				}
				else if (temp_cat.Trim() == "Doc Request")
				{ 
					load_pub_sources(false, temp_cat);
				}
				else
				{
					load_pub_sources(false, temp_cat);
				}
			}
			else
			{
				if (cbo_pub[3].Items.Count == 0)
				{ // commented out MSW 9/14/23
					load_pub_sources(false, temp_cat);
				}
			}
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();




			if (temp_pub_id > 0)
			{
			}
			else
			{
				temp_pub_id = Convert.ToInt32(Double.Parse(grd_pub.get_RowData(grd_pub.MouseRow).ToString().Trim()));
			}

			if (temp_row_id > 0)
			{

			}
			else
			{
				temp_row_id = grd_pub.MouseRow;
			}

			cmd_pub[1].Text = "Update";

			pnl_add_pub.Visible = false;

			if (lRow1 > 0)
			{
				cmd_pub[9].Visible = true;
			}

			if (cbo_pub[5].Items.Count < 1)
			{
				Fill_AC_Status_Drop_Down(cbo_pub[5], "");
			}



			if (Button == MouseButtons.Right)
			{

			}
			else
			{
				find_pub_item(temp_pub_id, temp_row_id);
			}



			if (modAdminCommon.gbl_User_ID == "mvit" || modAdminCommon.gbl_User_ID == "pls" || modAdminCommon.gbl_User_ID == "jkc" || modAdminCommon.gbl_User_ID == "avl" || modAdminCommon.gbl_User_ID == "cs" || modAdminCommon.gbl_User_ID == "njh" || modAdminCommon.gbl_User_ID == "bs" || modAdminCommon.gbl_User_ID == "llp" || modAdminCommon.gbl_User_ID == "has" || modAdminCommon.gbl_User_ID == "cbqc" || modAdminCommon.gbl_User_ID == "cjb" || modAdminCommon.gbl_User_ID == "cjb2" || modAdminCommon.gbl_User_ID.ToLower() == "kkf" || modAdminCommon.gbl_User_ID.ToLower() == "ead" || modAdminCommon.gbl_User_ID.ToLower() == "edpb" || modAdminCommon.gbl_User_ID.ToLower() == "alpb" || modAdminCommon.gbl_User_ID.ToLower() == "alsp" || modAdminCommon.gbl_User_ID.ToLower() == "cbpb" || modAdminCommon.gbl_User_ID.ToLower() == "jdsp" || modAdminCommon.gbl_User_ID.ToLower() == "jjd" || modAdminCommon.gbl_User_ID.ToLower() == "jlf" || modAdminCommon.gbl_User_ID.ToLower() == "tpb" || modAdminCommon.gbl_User_ID.ToLower() == "jmm" || modAdminCommon.gbl_User_ID.ToLower() == "kvl" || modAdminCommon.gbl_User_ID.ToLower() == "nad")
			{

			}
			else
			{
				cmd_pub[5].Visible = false;
			}



		}

		public void reset_notes_boxes()
		{

			//reset it to where it was
			txt_pub[3].Left = 784;
			txt_pub[3].Top = 20;
			txt_pub[3].Width = 185;
			frm_WebCrawl.DefInstance.lbl_gen[47].Left = 782; //notes label

			frm_WebCrawl.DefInstance.txt_pub[0].Visible = true;
			frm_WebCrawl.DefInstance.lbl_gen[44].Visible = true;
			frm_WebCrawl.DefInstance.lbl_gen[43].Visible = true;
			frm_WebCrawl.DefInstance.txt_pub[2].Visible = true;

		}

		private void send_verify_email(string from_spot)
		{

			string strInsert1 = "";

			int lPubId = 0;
			int lACId = 0;

			string strPub = "";
			string strPubName = "";
			string strDesc = "";
			string strRegNbr = "";
			string strSerNbr = "";
			string strPubPrice = "";
			string strHBPrice = "";
			string strPubAFTT = "";
			string strHBAFTT = "";

			string strToEMail = "";
			string strToName = "";
			string strFromEMail = "";
			string strFromName = "";
			string strSubject = "";
			string strBody = "";
			string strStatus = "";
			string strErrorMsg = "";

			string strJSubject = "";

			string strSMTPServer = "";
			int lSMTPPort = 0;
			string strSMTPUserName = "";
			string strSMTPPassWord = "";

			int lCompId = 0;
			int lContactId = 0;
			System.DateTime dtSystemDateTime = DateTime.FromOADate(0);

			string strMsg = "";

			int lRow1 = 0;
			int lCol1 = 0;

			if (cmdSendVerifyEMail.Enabled || from_spot.Trim() == "NewPub")
			{

				if (NewRecs.RecordCount > 0 || from_spot.Trim() == "NewPub")
				{

					cmdSendVerifyEMail.Enabled = false;

					if (from_spot.Trim() == "NewPub")
					{
						lRow1 = grd_pub.RowSel;
						grd_pub.CurrentRowIndex = lRow1;
					}
					else
					{
						lRow1 = grd_NewAvail.RowSel;
					}


					if (lRow1 >= 1)
					{

						if (from_spot.Trim() == "NewPub")
						{
							grd_pub.CurrentColumnIndex = 0;
							lPubId = Convert.ToInt32(Double.Parse(grd_pub[grd_pub.CurrentRowIndex, grd_pub.CurrentColumnIndex].FormattedValue.ToString()));

							grd_pub.CurrentColumnIndex = 4;
							lACId = Convert.ToInt32(Double.Parse(grd_pub[grd_pub.CurrentRowIndex, grd_pub.CurrentColumnIndex].FormattedValue.ToString()));
						}
						else
						{
							lPubId = grd_NewAvail.get_RowData(lRow1);
							//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_NewAvail.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							lACId = grd_NewAvail.BandData(lRow1);
						}
						if (lACId > 0)
						{

							modCommon.GetAircraftPrimaryContactNameEMailAddress(lACId, ref lCompId, ref lContactId, ref strToEMail, ref strToName);

							if (strToEMail != "" && lCompId > 0 && lContactId > 0)
							{

								strFromEMail = modCommon.GetUserEMailAddress(modAdminCommon.gbl_User_ID);
								strFromName = modCommon.GetFullUserName(modAdminCommon.gbl_User_ID);


								if (from_spot.Trim() == "NewPub")
								{
									strToEMail = "Patty@jetnet.com";
									strPub = Convert.ToString(grd_pub[lRow1, 10].Value).Trim();
									//   strPubName = Trim(DLookUp("pub_name", "Publications", "(pub_abbrev = '" & strPub & "')"))
									strPubName = strPub;
									strDesc = Convert.ToString(grd_pub[lRow1, 3].Value).Trim();
									strRegNbr = Convert.ToString(grd_pub[lRow1, 5].Value).Trim();
									strSerNbr = Convert.ToString(grd_pub[lRow1, 6].Value).Trim();

									// thes
									strHBPrice = "";
									strPubPrice = Convert.ToString(grd_pub[lRow1, 15].Value).Trim();
									if (strPubPrice.IndexOf("Asking Price: ") >= 0)
									{
										strPubPrice = strPubPrice.Trim().Substring(Math.Max(strPubPrice.Trim().Length - (Strings.Len(strPubPrice.Trim()) - (strPubPrice.Trim().IndexOf("Asking Price: ") + 1) - 13), 0));
										if (strPubPrice.IndexOf(' ') >= 0)
										{
											strPubPrice = strPubPrice.Trim().Substring(0, Math.Min(strPubPrice.Trim().IndexOf(' '), strPubPrice.Trim().Length));
										}
										else
										{
											strPubPrice = strPubPrice;
										}


										strHBPrice = ""; // get homebase asking number
									}
									else
									{
										strPubPrice = "";
									}

									strHBPrice = "";
									strPubAFTT = Convert.ToString(grd_pub[lRow1, 15].Value).Trim();
									if (strPubAFTT.IndexOf("AFTT Difference: ") >= 0)
									{
										strPubAFTT = strPubAFTT.Trim().Substring(Math.Max(strPubAFTT.Trim().Length - (Strings.Len(strPubAFTT.Trim()) - (strPubAFTT.Trim().IndexOf("AFTT Difference: ") + 1) - 16), 0));
										if (strPubAFTT.IndexOf(' ') >= 0)
										{
											strPubAFTT = strPubAFTT.Trim().Substring(0, Math.Min(strPubAFTT.Trim().IndexOf(' '), strPubAFTT.Trim().Length));
										}
										else
										{
											strPubAFTT = strPubAFTT;
										}
										strHBAFTT = ""; // get homebase aftt
									}
									else
									{
										strPubAFTT = "";
									}
									strHBAFTT = "";

								}
								else
								{
									// if its from the button click
									strPub = Convert.ToString(grd_NewAvail[lRow1, 0].Value).Trim();
									strPubName = modCommon.DLookUp("pub_name", "Publications", $"(pub_abbrev = '{strPub}')").Trim();
									strDesc = Convert.ToString(grd_NewAvail[lRow1, 6].Value).Trim();
									strRegNbr = Convert.ToString(grd_NewAvail[lRow1, 8].Value).Trim();
									strSerNbr = Convert.ToString(grd_NewAvail[lRow1, 10].Value).Trim();
									strPubPrice = Convert.ToString(grd_NewAvail[lRow1, 11].Value).Trim();
									strHBPrice = Convert.ToString(grd_NewAvail[lRow1, 12].Value).Trim();
								}


								if (strPubPrice != "" || strPubAFTT.Trim() != "")
								{ // added the strPubAFTT MSW - 12/28/18

									strSubject = $"{strDesc} / {strRegNbr} / {strSerNbr}";

									find_jetnet_asking_aftt(lACId, ref strHBPrice, ref strHBAFTT);

									if (strPubPrice.Trim() != "")
									{
										if (from_spot.Trim() == "NewPub")
										{
											strBody = $"I see you've posted a price of {strPubPrice} in {strPubName}.%0D%0D";
										}
										else
										{
											strBody = $"I see you've posted a price of {strPubPrice} in {strPubName}.%0D%0D";
										}

										if (strHBPrice == "")
										{
											strBody = $"{strBody}JETNET currently has not been given a price for this listing.%0D%0D";
											strBody = $"{strBody}Please advise if you would like your advertised price to be shown on JETNET.%0D%0D";
										}
										else
										{
											strBody = $"{strBody}JETNET currently shows a price of {strHBPrice}.%0D%0D";
											strBody = $"{strBody}Please advise what price you would like shown on JETNET.%0D%0D";
										}
									}


									if (from_spot.Trim() == "NewPub" && strPubAFTT.Trim() != "")
									{

										strBody = $"{strBody}I see you've posted an aftt of {strPubAFTT} in {strPubName}.%0D%0D";

										if (strHBAFTT == "")
										{
											strBody = $"{strBody}JETNET currently has not been given an aftt for this listing.%0D%0D";
											strBody = $"{strBody}Please advise if you would like your advertised aftt to be shown on JETNET.%0D%0D";
										}
										else
										{
											strBody = $"{strBody}JETNET currently shows an aftt of {strHBAFTT}.%0D%0D";
											strBody = $"{strBody}Please advise what aftt you would like shown on JETNET.%0D%0D";
										}
									}



									if (from_spot.Trim() == "NewPub")
									{
										strPubAFTT = "";
										strHBAFTT = "";
									}

									strBody = $"{strBody}Kind regards,%0D%0D";
									strBody = $"{strBody}{strFromName}%0D";

									strJSubject = $"Sent email for confirmation of price change per {strPubName} ({strPub}) PUB";
									strStatus = "Open";
									strErrorMsg = "";


									if (strToEMail != "" && strSubject != "" && strBody != "")
									{
										JetNetSupport.PInvoke.SafeNative.shell32.ShellExecute(Support.GetHInstance().ToInt32(), "open", $"mailto:{strToEMail}?subject={strSubject}&body={strBody}", null, null, 0);
									}

									dtSystemDateTime = DateTime.Parse(modAdminCommon.GetSystemDateTime());

									strInsert1 = "INSERT INTO Journal ( journ_date, ";
									strInsert1 = $"{strInsert1}journ_subcategory_code,  journ_subject, ";
									strInsert1 = $"{strInsert1}journ_description,  journ_ac_id, ";
									strInsert1 = $"{strInsert1}journ_comp_id, journ_contact_id, ";
									strInsert1 = $"{strInsert1}journ_user_id, journ_entry_date,  journ_entry_time, ";
									strInsert1 = $"{strInsert1}journ_account_id, journ_prior_account_id, journ_status, ";
									strInsert1 = $"{strInsert1}journ_customer_note,  journ_action_date ";

									strInsert1 = $"{strInsert1}) VALUES ('{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
									strInsert1 = $"{strInsert1}'RN', ";
									strInsert1 = $"{strInsert1}'{($"{strJSubject} ").Trim()}', ";
									strInsert1 = $"{strInsert1}'', ";
									strInsert1 = $"{strInsert1}{lACId.ToString()}, ";
									strInsert1 = $"{strInsert1}{lCompId.ToString()}, ";
									strInsert1 = $"{strInsert1}{lContactId.ToString()}, ";
									strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}', ";
									strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
									strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("HH:mm:ss")}', ";
									strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_Account_ID}', ";
									strInsert1 = $"{strInsert1}'', ";
									strInsert1 = $"{strInsert1}'A', ";
									strInsert1 = $"{strInsert1}'', ";
									strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy HH:mm:ss")}'";
									strInsert1 = $"{strInsert1})";

									DbCommand TempCommand = null;
									TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
									TempCommand.CommandText = strInsert1;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
									TempCommand.ExecuteNonQuery();

									strMsg = $"Publication Price Change EMail Verification Sent To {Environment.NewLine}{Environment.NewLine}";
									strMsg = $"{strMsg}{strToName} at {strToEMail}{Environment.NewLine}{Environment.NewLine}";
									strMsg = $"{strMsg}For Aircraft {strDesc} {strRegNbr} {strSerNbr}";

									MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

								}
								else
								{
									MessageBox.Show($"PUBS Asking Price Is Blank{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								} // If strPubPrice <> "" Then

							}
							else
							{
								MessageBox.Show($"No EMail Address Associated To Primary Contact{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							} // If strToEMail <> "" And lCompId > 0 And lContactId > 0 Then

						}
						else
						{
							MessageBox.Show($"Pub Row Selected Does NOT Have An Aircraft Id{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						} // If lACId > 0 Then

					}
					else
					{
						MessageBox.Show($"Pub Grid Must Have A Row Selected{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					} // If lRow1 >= 1 Then

					cmdSendVerifyEMail.Enabled = true;

				}
				else
				{
					MessageBox.Show("No Pub Records Found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				} // If NewRecs.RecordCount > 0 Then

			} // If cmdSendVerifyEMail.Enabled = True Then

		}

		public void find_jetnet_asking_aftt(int AC_ID, ref string asking, ref string aftt)
		{

			ADORecordSetHelper ado_Yacht = new ADORecordSetHelper();


			string Query = "SELECT  distinct ac_asking, ac_asking_price, ac_airframe_tot_hrs  ";
			Query = $"{Query} from Aircraft with (NOLOCK)  where ac_journ_id = 0 and ac_id ={AC_ID.ToString()} ";


			string search_string = Query;

			ado_Yacht = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(ado_Yacht.Fields) && !(ado_Yacht.BOF && ado_Yacht.EOF))
			{

				while(!ado_Yacht.EOF)
				{

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["ac_asking"]))
					{
						if (Convert.ToString(ado_Yacht["ac_asking"]) == "Price")
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_Yacht["ac_asking_price"]))
							{
								asking = Convert.ToString(ado_Yacht["ac_asking_price"]);
							}
							else
							{
								asking = Convert.ToString(ado_Yacht["ac_asking"]);
							}
						}
						else
						{
							asking = Convert.ToString(ado_Yacht["ac_asking"]);
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["ac_airframe_tot_hrs"]))
					{
						aftt = Convert.ToString(ado_Yacht["ac_airframe_tot_hrs"]);
					}


					ado_Yacht.MoveNext();
				};

			}

			ado_Yacht.Close();
		}
		public void set_default_checks(string type_string)
		{



			// set here MSW - 10/26/23 as long as we are only using 1
			// make sure they are all set, since we are only using one now
			Application.DoEvents();
			Application.DoEvents();
			//        chk_include(first_attempt) = chk_include(22)  ' 1st attempt
			first_attempt = 11;
			//        chk_include(second_attempt) = chk_include(12)  ' 2nd attempt
			second_attempt = 3;
			//        chk_include(third_attempt) = chk_include(20)  ' 3nd attempt
			third_attempt = 9;
			//        chk_include(hold_review) = chk_include(21)  ' hold/review
			hold_review = 10;
			//        chk_include(completed) = chk_include(13)  ' completed
			completed = 2;
			//        chk_include(open_check) = chk_include(14)  ' open
			open_check = 0;
			//        chk_include(in_progress) = chk_include(17)  ' in progress
			in_progress = 5;
			//        chk_include(blind) = chk_include(19)  ' blind
			blind = 8;
			//        chk_include(cleared_check) = chk_include(15)  ' cleared
			cleared_check = 1;
			//        chk_include(no_action) = chk_include(18)  ' no action required
			no_action = 7;
			//        cbo_pub(status_drop) = cbo_pub(8) ' status
			status_drop = 2;
			//        txt_pub(comp_text) = txt_pub(15) ' company name
			comp_text = 7;

			//        txt_pub(date_range1) = txt_pub(17) ' date range
			//        txt_pub(date_range2) = txt_pub(18) ' date range
			date_range1 = 12;
			date_range2 = 13;
			category_id = 7;
			count_label = 45;
			Application.DoEvents();
			Application.DoEvents();



			if (type_string.Trim() == "Pub")
			{
				chk_include[open_check].CheckState = CheckState.Checked;
				chk_include[cleared_check].CheckState = CheckState.Unchecked;
				chk_include[completed].CheckState = CheckState.Unchecked;
				chk_include[second_attempt].CheckState = CheckState.Unchecked;
				chk_include[in_progress].CheckState = CheckState.Checked;
				chk_include[no_action].CheckState = CheckState.Unchecked;
				chk_include[blind].CheckState = CheckState.Unchecked;
				chk_include[third_attempt].CheckState = CheckState.Unchecked;
				chk_include[hold_review].CheckState = CheckState.Unchecked;
				// MSW - 10/27/2023 - turned off the checkboxes
			}
			else if (type_string.Trim() == "Memo")
			{ 
				chk_include[open_check].CheckState = CheckState.Checked; // changed to 1 - msw - 6/1/21
				chk_include[cleared_check].CheckState = CheckState.Unchecked;
				chk_include[completed].CheckState = CheckState.Unchecked;
				chk_include[second_attempt].CheckState = CheckState.Unchecked;
				chk_include[in_progress].CheckState = CheckState.Unchecked;
				chk_include[no_action].CheckState = CheckState.Unchecked;
				chk_include[blind].CheckState = CheckState.Unchecked;
				chk_include[third_attempt].CheckState = CheckState.Unchecked;
				chk_include[hold_review].CheckState = CheckState.Unchecked;
			}
			else if (type_string.Trim() == "Doc Request")
			{ 
				chk_include[open_check].CheckState = CheckState.Checked; // changed to 1 - msw - 6/1/21
				chk_include[cleared_check].CheckState = CheckState.Unchecked;
				chk_include[completed].CheckState = CheckState.Unchecked;
				chk_include[second_attempt].CheckState = CheckState.Unchecked;
				chk_include[in_progress].CheckState = CheckState.Unchecked;
				chk_include[no_action].CheckState = CheckState.Unchecked;
				chk_include[blind].CheckState = CheckState.Unchecked;
				chk_include[third_attempt].CheckState = CheckState.Unchecked;
				chk_include[hold_review].CheckState = CheckState.Unchecked;
			}






		}

		public void setup_add_new()
		{




			cbo_pub[3].Enabled = true; // added MSW - to make sure that it is enabled on add  - 2/14/24
			pnl_update_pub.Visible = true;
			cmd_pub[1].Text = "Save";
			txt_pub[0].Text = "";
			txt_pub[1].Text = "0";
			txt_pub[2].Text = "";
			txt_pub[3].Text = "";
			cbo_pub[1].Text = "Open";
			lbl_gen[42].Text = "0";
			pnl_pub_listing.Visible = false;
			pnl_update_pub.Top = 67;
			pnl_add_pub.Visible = true;
			cmd_pub[5].Visible = false;
			txt_pub[4].Text = "";
			txt_pub[6].Text = "0";
			chk_include[6].CheckState = CheckState.Unchecked;
			txt_pub[5].Text = "";
			txt_pub[10].Text = "";
			cbo_pub[3].Text = "";

			// add new - make it todays date - MSW - 3/25/21
			txt_pub[14].Text = DateTimeHelper.ToString(DateTime.Today);


			reset_notes_boxes();



			if (cbo_pub[3].Items.Count == 0)
			{
				load_pub_sources();
			}

			if (cbo_pub[4].Items.Count == 0)
			{
				cbo_pub[4].Items.Clear();
				cbo_pub[4].AddItem("Aircraft");
				cbo_pub[4].Text = "Aircraft";
			}

			Fill_AC_Status_Drop_Down(cbo_pub[5], "");

			cbo_pub_TextChanged(cbo_pub[6], new EventArgs());

		}

		private void UnClearPub(int inPubID, int inACID, string inSource)
		{

			string Query = "";

			modAdminCommon.Rec_Journal_Info.journ_subject = $"UnCleared {inSource.Trim()} Pub";
			modAdminCommon.Rec_Journal_Info.journ_description = " ";
			modAdminCommon.Rec_Journal_Info.journ_ac_id = inACID;
			modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
			modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
			modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
			modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
			modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
			modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
			modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
			modAdminCommon.Rec_Journal_Info.journ_status = "A";

			int PubJournID = frm_Journal.DefInstance.Commit_Journal_Entry();

			if (PubJournID > 0)
			{

				Query = "UPDATE Publication_Log SET publog_status = 'N', ";
				Query = $"{Query}publog_clear_date = NULL, publog_journ_id = NULL ";
				Query = $"{Query}WHERE publog_id = {inPubID.ToString()}";

				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); // gap-note check this line during blazor stabilization

				frm_Journal.DefInstance.Reference_Journal_ID = PubJournID;
				modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
				frm_Journal.DefInstance.ShowDialog();

			}
			else
			{

				MessageBox.Show($"Error Trying to UnClear Pub!{Environment.NewLine}Pub NOT UN-CLEARED", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

			}

		}

		private void cbo_ACREP_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{


			if (chk_include[23].CheckState == CheckState.Checked)
			{
				lbl_gen[22].Text = modAdminCommon.return_top1_alt_account(cbo_ACREP.Text);
			}
			else
			{
				lbl_gen[22].Text = "";
			}


			pnl_update_pub.Visible = false; // added MSW - 1/17/18

			//If tab_NewAvail.Tab <> 2 Then
			if (!b_updateFlag)
			{
				Get_New_Pubs(Convert.ToString(grd_NewAvail.Tag));
				Fill_Find_Customer_Submitted_Data_Grid();
			}
			//End If

		}

		//UPGRADE_WARNING: (2074) ComboBox event cbo_pub.Change was upgraded to cbo_pub.TextChanged which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
		private bool isInitializingComponent;
		private void cbo_pub_TextChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cbo_pub, eventSender);
			if (isInitializingComponent)
			{
				return;
			}


			if (Index == 6)
			{

				if (cbo_pub[6].Text == "Memo" || cbo_pub[6].Text == "Doc Request")
				{
					move_notes_over();
				}
				else
				{
					reset_notes_boxes();
				}

				// added in MSW - 7/2/21
				load_correct_statuses(cbo_pub[6].Text);


			}



		}

		public void move_notes_over()
		{

			frm_WebCrawl.DefInstance.txt_pub[3].Left = 400;
			frm_WebCrawl.DefInstance.txt_pub[3].Width = 367;
			frm_WebCrawl.DefInstance.lbl_gen[47].Left = 400;

			frm_WebCrawl.DefInstance.txt_pub[0].Visible = false;
			frm_WebCrawl.DefInstance.lbl_gen[44].Visible = false;
			frm_WebCrawl.DefInstance.lbl_gen[43].Visible = false;
			frm_WebCrawl.DefInstance.txt_pub[2].Visible = false;


		}
		private void cbo_pub_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cbo_pub, eventSender);

			if (Index == 7)
			{
				// Call set_default_checks(cbo_pub(7).Text) ' commented out 10/27/23
				fill_ac_new_pub_search("", grd_pub); // added in instead - 10/27/23
			}


			if (Index == 6)
			{
				if (cbo_pub[6].Text == "Memo" || cbo_pub[6].Text == "Doc Request")
				{
					move_notes_over();
				}
				else
				{
					reset_notes_boxes();
				}

				// added in MSW - 7/2/21
				load_correct_statuses(cbo_pub[6].Text);

				// if we are changing the status - msw - 8/18/22
				if (Convert.ToString(cbo_pub[3].Tag) != cbo_pub[6].Text)
				{
					load_pub_sources();
					cbo_pub[3].Tag = cbo_pub[6].Text;
				}


			}


			if (cbo_pub[10].Items.Count == 0)
			{
				Fill_Timezones();
				Fill_AC_Status_Drop_Down(cbo_pub[2], "");
				Fill_AC_Status_Drop_Down(cbo_pub[8], "");
			}



		}

		private void cbo_pub_Enter(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cbo_pub, eventSender);



			if (Index == 0)
			{
				assign_correct_account_rep();
			}


		}


		private void cbo_WebSite_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			if (cbo_WebSite.Text.Trim() != "" && txt_EMailAddress.Text == "")
			{
				txt_EMailAddress.Text = GetEmailAddress(cbo_WebSite.Text.Substring(0, Math.Min(3, cbo_WebSite.Text.Length)));
				//   Else
				//      txt_EMailAddress.Text = ""
			}

		}


		private void chk_include_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chk_include, eventSender);


			if (Index != 6 && Index != 1 && Index != 7)
			{
				fill_ac_new_pub_search("", grd_pub);
			}
			//
			// the use alt rep check box was checked
			if (Index == 23)
			{
				//added MSW - 8/4/22
				if (chk_include[23].CheckState == CheckState.Checked)
				{
					lbl_gen[22].Text = modAdminCommon.return_top1_alt_account(cbo_ACREP.Text);
				}
				else
				{
					lbl_gen[22].Text = "";
				}

				fill_ac_new_pub_search("", grd_pub);
				// commented out msw - 10/27/23
				//Call fill_ac_new_pub_search("", grd_pub2)
			}

		}

		private void cmd_cancel_Click(Object eventSender, EventArgs eventArgs) => frame_Details.Visible = false;


		private void cmd_clear_pub_Click(Object eventSender, EventArgs eventArgs)
		{
			pub_id = 0;
			cmd_clear_pub.Visible = false;
		}

		private void cmd_ClearLeave_Click(Object eventSender, EventArgs eventArgs)
		{
			int i = 0;
			try
			{

				if (grd_NewAvail.CurrentRowIndex > 0)
				{
					if (MessageBox.Show("Are You Sure You Want To Clear The Selected Pub", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_NewAvail.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						ClearPub(grd_NewAvail.get_RowData(grd_NewAvail.CurrentRowIndex), grd_NewAvail.BandData(grd_NewAvail.CurrentRowIndex), Convert.ToString(grd_NewAvail[grd_NewAvail.CurrentRowIndex, 0].Value));
						//grd_NewAvail.Col = 0 ' commented out - MSW - 3/3/16, keeps it highlited
						grd_NewAvail.CellFontBold = true;
					}
				}
				else
				{
					MessageBox.Show("You must select a Pub", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"cmdclearleave_error: {excep.Message}", "webcrawler");
			}
		}

		private void cmd_ClearNoChange_Click(Object eventSender, EventArgs eventArgs) => Clear_Pubs_With_No_Changes(PubsToClear);

		private void cmd_GetAvail_Click(Object eventSender, EventArgs eventArgs)
		{

			// DEFAULT TO 1 DAY OF INFORMATION IF NO DAYS ARE SPECIFIED


			if (!Information.IsNumeric(txt_NumDays.Text))
			{
				txt_NumDays.Text = "1";
			}

			if (txt_EMailAddress.Text.Trim() == "")
			{
				MessageBox.Show("You Must Provide An Email Address", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_EMailAddress.Focus();
				return;
			}

			switch(cbo_WebSite.Text.Substring(0, Math.Min(3, cbo_WebSite.Text.Length)))
			{
				case "ASO" : 
					Browse_ASO_New(); 
					break;
				case "CON" : 
					//Call Browse_CONTROLLER 
					Browse_Controller_New(); 
					break;
				case "TAP" : 
					MessageBox.Show("This Feature is Not Available Yet", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
					// Browse_TAP 
					break;
				default:
					MessageBox.Show("You Must Select A Website", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
					cbo_WebSite.Focus(); 
					 
					break;
			}

			cmd_GetAvail.Enabled = true;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_Identify_AC_Click(Object eventSender, EventArgs eventArgs)
		{

			if (Information.IsNumeric(txt_publog_Ac_id.Text.Trim()))
			{
				Get_New_Aircraft_Info(Convert.ToInt32(Double.Parse(txt_publog_Ac_id.Text)));
			}

		}


		public void cmd_pub_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_pub, eventSender);
			object inJournal_ID = null;

			string Query = "";
			string Query2 = "";
			ADORecordSetHelper snpJourn = new ADORecordSetHelper();
			string temp_journ_id = "";
			ADORecordSetHelper ado_Primary = new ADORecordSetHelper();
			bool time_different = false;
			string temp_pubnote_type = "PBNOTE";



			// add this in  - MSW - 10/27/23 - make sure we set the right status
			if (Index == 4)
			{
				if (cbo_pub[7].Text.Trim() != "All")
				{
					cbo_pub[6].Text = cbo_pub[7].Text;
					if (cbo_pub[6].Text == "Memo" || cbo_pub[6].Text == "Doc Request")
					{
						move_notes_over();
					}
					else
					{
						reset_notes_boxes();
					}

					// added in MSW - 7/2/21
					load_correct_statuses(cbo_pub[6].Text);
				}
			}




			if (txt_pub[1].Text.Trim() == "")
			{
				txt_pub[1].Text = "0";
			}
			//cbo_pub(6).Text = "Memo"

			// added to skip if status was blank - 7/2/21
			string task_type = "";
			int temp_mouse = 0;
			if (cbo_pub[1].Text == "" && Index == 1)
			{
				MessageBox.Show("You need to pick a Status", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
			}
			else
			{

				if (Index == 2)
				{
					grd_pub2.Visible = true;
				}



				if (Index == 0)
				{
					pnl_update_pub.Visible = false;
					pnl_update_pub.Top = 498;
					pnl_pub_listing.Visible = true;

					txt_pub[3].Left = 784;
					txt_pub[3].Top = 20;
					txt_pub[3].Width = 185;
				}
				else if (Index == 1)
				{ 

					// added in MSW - 10/13/23 -------------
					if (txt_pub[6].Text.Trim() == "0")
					{

					}
					else if (!double_check_comp_ids())
					{ 
						MessageBox.Show("The Company ID You Inputed was Incorrect. Please Correct.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
						return;
					}

					if (txt_pub[1].Text.Trim() == "0")
					{

					}
					else if (!double_check_ac_ids())
					{ 
						MessageBox.Show("The AC ID You Inputed was Incorrect. Please Correct.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
						return;
					}
					//------------------ per jetdev 483

					if (cbo_pub[0].Text.Trim() == "All")
					{
						MessageBox.Show("You Must Enter an Account Rep!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
					}
					else if (cbo_pub[3].Text.Trim() == "" && cbo_pub[6].Text.Trim() != "Doc Request")
					{  // added doc request to ignore-  MSW - 10/12/23
						MessageBox.Show("You Must Enter a Source!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
					}
					else if (cbo_pub[3].Text.Trim() == "General" && txt_pub[4].Text.Trim() != "")
					{ 
						MessageBox.Show("Source Cannot Be General when we have a URL! Please Correct", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
					}
					else if (cmd_pub[1].Text == "Update")
					{ 
						Query = $"UPDATE Publication_Listing set  publist_status = '{cbo_pub[1].Text.Substring(0, Math.Min(1, cbo_pub[1].Text.Length))}', ";
						Query = $"{Query} publist_acct_rep = '{cbo_pub[0].Text}', ";
						Query = $"{Query} publist_research_note = '{StringsHelper.Replace(txt_pub[3].Text, "'", "''", 1, -1, CompareMethod.Binary)}', ";
						Query = $"{Query} publist_user_id = '{modAdminCommon.gbl_User_ID}',  publist_clear_date = '{DateTimeHelper.ToString(DateTime.Today)}', ";
						Query = $"{Query} publist_ac_id = '{txt_pub[1].Text}',  publist_url = '{txt_pub[4].Text}', ";


						Query = $"{Query} publist_source = ";
						if (cbo_pub[3].Text.Trim() != "")
						{
							Query = $"{Query} '{cbo_pub[3].GetItemData(cbo_pub[3].SelectedIndex).ToString()}', "; // source
						}
						else
						{
							Query = $"{Query} '0', "; // source
						}


						Query = $"{Query} publist_category = '{cbo_pub[6].Text}', "; // added MSW - 3/25/21

						if (cbo_pub[6].Text.Trim() == "Memo" || cbo_pub[6].Text.Trim() == "Doc Request")
						{
							Query = $"{Query} publist_entry_date = '{txt_pub[14].Text}', "; // added MSW - 3/25/21


							Query = $"{Query} publist_update_date = '{DateTime.Now.ToString("d")} {Strings.FormatDateTime(DateTime.Now, DateFormat.ShortTime)}', "; // added MSW - 5/3/21
						}


						if ((txt_pub[2].Text.IndexOf("Pictures Found") + 1) == 0)
						{
							if (chk_include[6].CheckState == CheckState.Checked)
							{
								Query = $"{Query} publist_description = '{StringsHelper.Replace(txt_pub[2].Text, "'", "''", 1, -1, CompareMethod.Binary)}, Pictures Found', ";
							}
						}

						if (cbo_pub[5].Text.Trim() != "All" && cbo_pub[5].Text.Trim() != "")
						{
							Query = $"{Query} publist_process_status = '{cbo_pub[5].Text}', ";
						}
						else
						{
							Query = $"{Query} publist_process_status = '', ";
						}

						Query = $"{Query} publist_original_desc = '{StringsHelper.Replace(txt_pub[5].Text, "'", "''", 1, -1, CompareMethod.Binary)}', ";
						Query = $"{Query} publist_comp_id = '{txt_pub[6].Text}' ";
						Query = $"{Query} where publist_id = {lbl_gen[42].Text}";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						//Call fill_ac_new_pub_search("")
						pnl_update_pub.Visible = false;




						if (cbo_pub[6].Text.Trim() == "Memo")
						{
							task_type = "Memo";
							temp_pubnote_type = "MEMO";
						}
						else if (cbo_pub[6].Text.Trim() == "Doc Request")
						{ 
							task_type = "Doc Request";
							temp_pubnote_type = "MEMO";
						}
						else
						{
							task_type = "AC Pub";
							temp_pubnote_type = "PBNOTE";
						}

						if (txt_pub[1].Text.Trim() != Convert.ToString(txt_pub[1].Tag).Trim())
						{
							string tempRefParam = $"Added AC ID to Pub: {txt_pub[9].Text} ({lbl_gen[42].Text}) - PubDate:{DateTime.Parse(Convert.ToString(txt_pub[9].Tag)).ToString("d")}";
							insert_research_note(Convert.ToInt32(Double.Parse(txt_pub[6].Text)), Convert.ToInt32(Double.Parse(txt_pub[1].Text)), 0, ref tempRefParam, temp_pubnote_type, 0, 0, "");
						}

						if (cbo_pub[1].Text.Substring(0, Math.Min(1, cbo_pub[1].Text.Length)).Trim() != Convert.ToString(cbo_pub[1].Tag).Trim())
						{
							string tempRefParam2 = $"Changed {task_type} Status to {cbo_pub[1].Text.Trim()}: {txt_pub[9].Text} ({lbl_gen[42].Text}) - PubDate:{DateTime.Parse(Convert.ToString(txt_pub[9].Tag)).ToString("d")}";
							insert_research_note(Convert.ToInt32(Double.Parse(txt_pub[6].Text)), Convert.ToInt32(Double.Parse(txt_pub[1].Text)), 0, ref tempRefParam2, temp_pubnote_type, 0, 0, "");
							if (cbo_pub[1].Text.Substring(0, Math.Min(1, cbo_pub[1].Text.Length)).Trim() == "C")
							{ // now it has been cleared

								Query = " SELECT top 1 journ_id FROM journal WITH(NOLOCK)";
								Query = $"{Query} Where journ_comp_id = {txt_pub[6].Text} and journ_ac_id = {txt_pub[1].Text} and  journ_subject = 'Changed AC Pub Status to {cbo_pub[1].Text.Trim()}: {txt_pub[9].Text} ({lbl_gen[42].Text}) - PubDate:{DateTime.Parse(Convert.ToString(txt_pub[9].Tag)).ToString("d")}' ";
								Query = $"{Query} order by journ_id desc ";

								snpJourn.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								if (!(snpJourn.BOF && snpJourn.EOF))
								{
									if (snpJourn["journ_id"] != inJournal_ID)
									{
										temp_journ_id = Convert.ToString(snpJourn["journ_id"]);
									}
								}

								snpJourn.Close();
								snpJourn = null;
								frm_Journal.DefInstance.Reference_Journal_ID = Convert.ToInt32(Double.Parse(temp_journ_id));
								frm_Journal.DefInstance.Reference_Comp_Id = 0;
								frm_Journal.DefInstance.Reference_Contact_Id = 0;

								frm_Journal.DefInstance.ShowDialog();

								fill_ac_new_pub_search("", grd_pub);
							}
						}




						if (cbo_pub[0].Text.Trim() != Convert.ToString(cbo_pub[0].Tag).Trim())
						{
							string tempRefParam3 = $"Changed ACCT REP from {Convert.ToString(cbo_pub[0].Tag).Trim()} to {cbo_pub[0].Text.Trim()}: {txt_pub[9].Text} ({lbl_gen[42].Text}) - TaskDate:{DateTime.Parse(Convert.ToString(txt_pub[9].Tag)).ToString("d")}";
							insert_research_note(Convert.ToInt32(Double.Parse(txt_pub[6].Text)), Convert.ToInt32(Double.Parse(txt_pub[1].Text)), 0, ref tempRefParam3, temp_pubnote_type, 0, 0, "");
						}
						if (txt_pub[6].Text.Trim() != Convert.ToString(txt_pub[6].Tag).Trim())
						{
							string tempRefParam4 = $"Changed/Added Comp ID to {txt_pub[6].Text.Trim()}: {txt_pub[9].Text} ({lbl_gen[42].Text}) - TaskDate:{DateTime.Parse(Convert.ToString(txt_pub[9].Tag)).ToString("d")}";
							insert_research_note(Convert.ToInt32(Double.Parse(txt_pub[6].Text)), Convert.ToInt32(Double.Parse(txt_pub[1].Text)), 0, ref tempRefParam4, temp_pubnote_type, 0, 0, "");
						}
						if (txt_pub[3].Text.Trim() != Convert.ToString(txt_pub[3].Tag).Trim())
						{ // changed to task_type from  Trim(txt_pub(6).Text) - msw - 6/14/21
							string tempRefParam5 = $"Changed/Added Note to {task_type} - TaskDate:{DateTime.Parse(Convert.ToString(txt_pub[9].Tag)).ToString("d")}|| {txt_pub[3].Text}";
							insert_research_note(Convert.ToInt32(Double.Parse(txt_pub[6].Text)), Convert.ToInt32(Double.Parse(txt_pub[1].Text)), 0, ref tempRefParam5, temp_pubnote_type, 0, 0, "");
						}
						if (cbo_pub[5].Text.Trim() != Convert.ToString(cbo_pub[5].Tag).Trim())
						{
							string tempRefParam6 = $"Changed PUB Rating to {cbo_pub[5].Text.Trim()}: {txt_pub[9].Text} ({lbl_gen[42].Text}) - TaskDate:{DateTime.Parse(Convert.ToString(txt_pub[9].Tag)).ToString("d")}";
							insert_research_note(Convert.ToInt32(Double.Parse(txt_pub[6].Text)), Convert.ToInt32(Double.Parse(txt_pub[1].Text)), 0, ref tempRefParam6, temp_pubnote_type, 0, 0, "");
						}


						pnl_pub_listing.Visible = true;
					}
					else
					{
						Query = "Insert into Publication_Listing ( ";
						Query = $"{Query} publist_status, publist_acct_rep, publist_research_note, publist_user_id, ";
						Query = $"{Query} publist_clear_date, publist_ac_id, publist_url, publist_type, ";
						Query = $"{Query} publist_source, publist_original_desc, publist_seller_info, publist_comp_id, publist_description, publist_process_status";



						if (cbo_pub[6].Text.Trim() == "Memo")
						{
							Query = $"{Query} , publist_category, publist_entry_date ";
						}
						else
						{
							Query = $"{Query} , publist_category ";
						}


						Query = $"{Query} ) VALUES ( '{cbo_pub[1].Text.Substring(0, Math.Min(1, cbo_pub[1].Text.Length))}', "; // status
						Query = $"{Query} '{cbo_pub[0].Text}', "; // acct
						Query = $"{Query} '{StringsHelper.Replace(txt_pub[3].Text, "'", "''", 1, -1, CompareMethod.Binary)}', "; // research note
						Query = $"{Query} '{modAdminCommon.gbl_User_ID}',   '{DateTimeHelper.ToString(DateTime.Today)}', "; // clear date
						Query = $"{Query} '{txt_pub[1].Text}', "; // ac id
						Query = $"{Query} '{txt_pub[4].Text}',   '{cbo_pub[4].Text}', "; // type


						if (cbo_pub[3].Text.Trim() != "")
						{
							Query = $"{Query} '{cbo_pub[3].GetItemData(cbo_pub[3].SelectedIndex).ToString()}', "; // source
						}
						else
						{
							Query = $"{Query} '0', "; // source
						}

						Query = $"{Query} '{StringsHelper.Replace(txt_pub[5].Text, "'", "''", 1, -1, CompareMethod.Binary)}', "; // title/desc
						Query = $"{Query} '{StringsHelper.Replace(txt_pub[0].Text, "'", "''", 1, -1, CompareMethod.Binary)}', ";
						Query = $"{Query} '{StringsHelper.Replace(txt_pub[6].Text, "'", "''", 1, -1, CompareMethod.Binary)}', ";

						Query = $"{Query} '{StringsHelper.Replace(txt_pub[2].Text, "'", "''", 1, -1, CompareMethod.Binary)} ";

						if (txt_pub[10].Text.Trim() != "")
						{
							if (Information.IsNumeric(txt_pub[1].Text.Trim()) && Information.IsNumeric(txt_pub[10].Text.Trim()))
							{

								Query2 = "SELECT ac_airframe_tot_hrs FROM Aircraft WITH (NOLOCK) ";
								Query2 = $"{Query2}WHERE (ac_id = {txt_pub[1].Text.Trim()})  AND (ac_journ_id = 0)  ";

								ado_Primary.Open(Query2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								if (!ado_Primary.BOF && !ado_Primary.EOF)
								{
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(ado_Primary["ac_airframe_tot_hrs"]))
									{
										if (Convert.ToInt32(Double.Parse(txt_pub[10].Text.Trim())) == Convert.ToInt32(ado_Primary["ac_airframe_tot_hrs"]))
										{
											time_different = false;
										}
										else if (Convert.ToInt32(Double.Parse(txt_pub[10].Text.Trim())) < Convert.ToInt32(ado_Primary["ac_airframe_tot_hrs"]))
										{ 
											time_different = false; // if its lower hours, assume we r ok/ dont need to update
										}
										else
										{
											time_different = true;
										}
									}
									else
									{
										time_different = true;
									}
								}

								ado_Primary.Close();

							}

							if (time_different)
							{
								Query = $"{Query} AFTT Difference: {txt_pub[10].Text.Trim()}";
							}
							else
							{

							}


						}

						if (StringsHelper.ToDoubleSafe(((int) chk_include[6].CheckState).ToString().Trim()) == 1)
						{
							Query = $"{Query} Pictures Found ";
						}

						Query = $"{Query}', ";

						Query = $"{Query} '{cbo_pub[5].Text}' ";

						Query = $"{Query}, '{cbo_pub[6].Text}' ";

						if (cbo_pub[6].Text.Trim() == "Memo")
						{
							Query = $"{Query}, '{txt_pub[14].Text}' ";
						}
						Query = $"{Query} ) ";

						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						// Call fill_ac_new_pub_search("")
						pnl_update_pub.Visible = false;

						if (txt_pub[3].Text.Trim() != Convert.ToString(txt_pub[3].Tag).Trim() && Convert.ToString(txt_pub[9].Tag).Trim() != "")
						{
							string tempRefParam7 = $"Changed/Added Note to {txt_pub[6].Text.Trim()} - TaskDate:{DateTime.Parse(Convert.ToString(txt_pub[9].Tag)).ToString("d")}|| {txt_pub[3].Text}";
							insert_research_note(Convert.ToInt32(Double.Parse(txt_pub[6].Text)), Convert.ToInt32(Double.Parse(txt_pub[1].Text)), 0, ref tempRefParam7, temp_pubnote_type, 0, 0, "");
						}



						if (cbo_pub[6].Text.Trim() == "Memo")
						{
							task_type = "Memo";
							temp_pubnote_type = "MEMO";
						}
						else if (cbo_pub[6].Text.Trim() == "Doc Request")
						{ 
							task_type = "Doc Request";
							temp_pubnote_type = "MEMO";
						}
						else
						{
							task_type = "AC Pub";
							temp_pubnote_type = "PBNOTE";
						}

						if (txt_pub[1].Text.Trim() != "")
						{
							if (Convert.ToString(txt_pub[9].Tag).Trim() != "")
							{
								string tempRefParam8 = $"Added {task_type} Record: {txt_pub[9].Text} - TaskDate:{DateTime.Parse(Convert.ToString(txt_pub[9].Tag)).ToString("d")}|| {txt_pub[3].Text}";
								insert_research_note(Convert.ToInt32(Double.Parse(txt_pub[6].Text)), Convert.ToInt32(Double.Parse(txt_pub[1].Text)), 0, ref tempRefParam8, $"{temp_pubnote_type}:{txt_pub[9].Text}", 0, 0, "");
							}
							else
							{
								string tempRefParam9 = $"Added {task_type} Record: {txt_pub[9].Text}|| {txt_pub[3].Text}";
								insert_research_note(Convert.ToInt32(Double.Parse(txt_pub[6].Text)), Convert.ToInt32(Double.Parse(txt_pub[1].Text)), 0, ref tempRefParam9, $"{temp_pubnote_type}:{txt_pub[9].Text}", 0, 0, "");
							}
						}
						else
						{
							string tempRefParam10 = $"Added {task_type} Record: {txt_pub[9].Text} - PubDate:{DateTime.Parse(Convert.ToString(txt_pub[9].Tag)).ToString("d")}|| {txt_pub[3].Text}";
							insert_research_note(Convert.ToInt32(Double.Parse(txt_pub[6].Text)), 0, 0, ref tempRefParam10, temp_pubnote_type, 0, 0, "");
						}



						pnl_pub_listing.Visible = true;
					}




				}
				else if (Index == 2)
				{ 
					fill_ac_new_pub_search("", grd_pub);
					Fill_Find_Customer_Submitted_Data_Grid();
				}
				else if (Index == 14)
				{ 
					fill_ac_new_pub_search("", grd_pub2);


				}
				else if (Index == 3)
				{  // find ac
					frm_PopUp.DefInstance.ComingFrom = "AC Pub";
					frm_PopUp.DefInstance.ShowDialog();
				}
				else if (Index == 4 || Index == 11)
				{ 
					setup_add_new();
				}
				else if (Index == 5)
				{ 

					if (Information.IsNumeric(Convert.ToString(lbl_gen[41].Tag)))
					{
						temp_mouse = Convert.ToInt32(Double.Parse(Convert.ToString(lbl_gen[41].Tag))); // should = the mouse row that was clicked
					}
					else
					{
						temp_mouse = 0;
					}

					if (MessageBox.Show("Are You Sure You Want To Delete This Record?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						Query = "UPDATE Publication_Listing set publist_status = 'D'  ";
						Query = $"{Query} where publist_id = {lbl_gen[42].Text}";
						DbCommand TempCommand_3 = null;
						TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
						TempCommand_3.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
						TempCommand_3.ExecuteNonQuery();

						if (Information.IsNumeric(txt_pub[6].Text))
						{
							string tempRefParam11 = "Deleted AC Pub Record";
							insert_research_note(Convert.ToInt32(Double.Parse(txt_pub[6].Text)), Convert.ToInt32(Double.Parse(txt_pub[1].Text)), 0, ref tempRefParam11, temp_pubnote_type, 0, 0, "");
						}
						else
						{
							string tempRefParam12 = "Deleted AC Pub Record";
							insert_research_note(0, Convert.ToInt32(Double.Parse(txt_pub[1].Text)), 0, ref tempRefParam12, temp_pubnote_type, 0, 0, "");
						}


						Application.DoEvents();
						Application.DoEvents();
						Application.DoEvents();
						if (temp_mouse - 1 > 0)
						{
							fill_ac_new_pub_search("", grd_pub, Convert.ToInt32(Double.Parse(grd_pub.get_RowData(temp_mouse - 1).ToString().Trim())), temp_mouse - 1); // go to the next rows id
							pnl_update_pub.Visible = false;
						}



					}

				}
				else if (Index == 6)
				{ 


					//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].Clear_Search_Criteria(true, true, true);
					//UPGRADE_TODO: (1067) Member cmd_add_to_pub is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].cmd_add_to_pub.Visible = true;
					//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].Show();
					//UPGRADE_TODO: (1067) Member ZOrder is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].ZOrder(0);
					//UPGRADE_TODO: (1067) Member SetFocus is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].Focus();


				}
				else if (Index == 7)
				{ 

					pnl_add_model_exception.Visible = true;

				}
				else if (Index == 8)
				{ 

					Query = "Insert into Publication_Models_Not_Processed (pubnot_phrase) VALUES (   ";
					Query = $"{Query}'{StringsHelper.Replace(txt_pub[8].Text, "'", "''", 1, -1, CompareMethod.Binary)}' ";
					Query = $"{Query}) ";

					DbCommand TempCommand_4 = null;
					TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery();

					lbl_gen[6].Visible = true;
					txt_pub[8].Text = "";
					pnl_add_model_exception.Visible = false;
				}
				else if (Index == 9)
				{ 


					cmdSubDataEMail_Click();

				}
				else if (Index == 10)
				{  // send email


					cmdSubDataEMail_Click_New_Form();
				}
				else if (Index == 16)
				{ 
					// complete it
					cmd_pub[16].Visible = false;

					complete_csd_click();

				}
				else if (Index == 17)
				{ 
					cmdCSDChangeAcctRep_Click();
				}
				else
				{

				}

			}

			// turn these on- make them visible - MSW 0 11/22/23
			// these are update account rep items
			cmd_pub[17].Visible = false;
			cbo_pub[11].Visible = false;
			lbl_gen[23].Visible = false;


		}


		private void cmdCSDChangeAcctRep_Click()
		{
			object dtSystemDateTime = null;

			int lRow = 0;
			int lSubISId = 0;
			string strAcctRepNew = "";
			string strAcctRepOld = "";
			string strUpdate1 = "";

			int lACId = 0;
			int lCompId = 0;
			int lContactId = 0;
			int lJournId = 0;
			string strInsert1 = "";

			try
			{

				lRow = fgrdFindCustSubData.CurrentRowIndex;

				if (lRow > 0)
				{

					if (cmd_pub[17].Enabled)
					{

						cmd_pub[17].Enabled = false;

						lSubISId = fgrdFindCustSubData.get_RowData(lRow);
						strAcctRepNew = cbo_pub[11].Text;
						strAcctRepOld = Convert.ToString(fgrdFindCustSubData[lRow, 14].Value);

						lCompId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 1].Value))); // CompId
						lContactId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 4].Value))); // Contact Id
						lACId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 6].Value))); // ACId
						lJournId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 7].Value))); // JournId

						if (strAcctRepNew != strAcctRepOld)
						{

							strUpdate1 = "UPDATE Subscription_Install_Log ";
							if (strAcctRepNew == "" || strAcctRepNew.ToUpper() == "NO REP SELECTED")
							{
								strUpdate1 = $"{strUpdate1}SET subislog_account_id = '' ";
							}
							else
							{
								strUpdate1 = $"{strUpdate1}SET subislog_account_id = '{strAcctRepNew}' ";
							}

							strUpdate1 = $"{strUpdate1}WHERE (subislog_id = {lSubISId.ToString()}) ";

							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strUpdate1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();


							strInsert1 = "INSERT INTO Journal ( journ_date, ";
							strInsert1 = $"{strInsert1}journ_subcategory_code,  journ_subject,  journ_description, ";
							strInsert1 = $"{strInsert1}journ_ac_id,  journ_comp_id,  journ_contact_id, ";
							strInsert1 = $"{strInsert1}journ_user_id, journ_entry_date, journ_entry_time, ";
							strInsert1 = $"{strInsert1}journ_account_id,  journ_prior_account_id,  journ_status, ";
							strInsert1 = $"{strInsert1}journ_customer_note, journ_action_date ";

							//UPGRADE_WARNING: (1068) dtSystemDateTime of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							strInsert1 = $"{strInsert1}) VALUES ('{Convert.ToDateTime(dtSystemDateTime).ToString("MM/dd/yyyy")}', ";
							strInsert1 = $"{strInsert1}'RN', ";
							strInsert1 = $"{strInsert1}'Submitted Data Account Rep Changed', ";
							strInsert1 = $"{strInsert1}'Changed Account Rep From: [{strAcctRepOld}] To [{strAcctRepNew}] - SubIsLogId=[{lSubISId.ToString()}]', ";
							strInsert1 = $"{strInsert1}{lACId.ToString()}, ";
							strInsert1 = $"{strInsert1}{lCompId.ToString()}, ";
							strInsert1 = $"{strInsert1}{lContactId.ToString()}, ";
							strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}', ";
							//UPGRADE_WARNING: (1068) dtSystemDateTime of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							strInsert1 = $"{strInsert1}'{Convert.ToDateTime(dtSystemDateTime).ToString("MM/dd/yyyy")}', ";
							//UPGRADE_WARNING: (1068) dtSystemDateTime of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							strInsert1 = $"{strInsert1}'{Convert.ToDateTime(dtSystemDateTime).ToString("HH:mm:ss")}', ";
							strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_Account_ID}', ";
							strInsert1 = $"{strInsert1}'', ";
							strInsert1 = $"{strInsert1}'A', '', ";
							//UPGRADE_WARNING: (1068) dtSystemDateTime of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							strInsert1 = $"{strInsert1}'{Convert.ToDateTime(dtSystemDateTime).ToString("MM/dd/yyyy HH:mm:ss")}'";
							strInsert1 = $"{strInsert1})";

							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = strInsert1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();

							modAdminCommon.Record_Event("Submitted Data", $"Changed Account Rep From: [{strAcctRepOld}] To [{strAcctRepNew}] - SubIsLogId=[{lSubISId.ToString()}]", lACId, lJournId, lCompId, false, 0, lContactId);

							// cmdFindCustSubDataRefresh_Click
							Fill_Find_Customer_Submitted_Data_Grid();
							fgrdFindCustSubData.CurrentRowIndex = lRow;
							modCommon.Highlight_Grid_Row(fgrdFindCustSubData);
							cbo_pub[11].Text = strAcctRepNew;

							cmd_pub[17].Enabled = true;

						}
						else
						{
							MessageBox.Show("Account Rep Selected Is Already Assigned To This Record", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If strAcctRepNew <> strAcctRepOld Then

					} // If cmdCSDChangeAcctRep.Enabled = True Then

				} // If lRow > 0 Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmdCSDChangeAcctRep_Click_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_ActionList(Customer Submitted Data)");
			}

		} // cmdCSDChangeAcctRep_Click


		private void Fill_Find_Customer_Submitted_Data_Grid()
		{
			bool bLog = false;
			object lRowColor = null;

			int i = 0;

			//If chk_new_submitted.Value = 1 Then
			DbConnection cntConn = null;
			string strConn = "";
			ADORecordSetHelper rstRec1 = null;
			string strQuery1 = "";
			string strSelect = "";
			string strACCTRep = "";
			string strAcctRepId = "";
			int lCol1 = 0;
			int lRow1 = 0;
			int lTot1 = 0;
			int lCnt1 = 0;
			int lCommandTimeOut = 0;
			int lCellColor = 0;
			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);
			if (i == 1)
			{
				// Fill_Find_Customer_Submitted_Data_Grid_New
			}
			else
			{



				cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

				rstRec1 = new ADORecordSetHelper();



				dtStartDate = DateTime.FromOADate(0);
				dtEndDate = DateTime.FromOADate(0);

				//UPGRADE_TODO: (1065) Error handling statement (On Error Goto) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("On Error Goto Label (Fill_Find_Customer_Submitted_Data_Grid_Error)");

				modCommon.Start_Activity_Monitor_Message("Callback Cust Submit Data", ref strMsg, ref dtStartDate, ref dtEndDate);

				lRow1 = 0;
				lCol1 = 0;


				strACCTRep = cbo_ACREP.Text.Substring(0, Math.Min(2, cbo_ACREP.Text.Length)).ToUpper();
				strAcctRepId = cbo_ACREP.Text.ToUpper();
				//strSelect = left(cmbProductType.Text, 1)
				strSelect = "";


				Fill_Find_Customer_Submitted_Data_Grid_Headers();

				strQuery1 = "SELECT DISTINCT  SIL1.subislog_id As SubISId, ";
				strQuery1 = $"{strQuery1}SIL1.subislog_date As DateEntered, ";
				strQuery1 = $"{strQuery1} SIL1.subislog_login as Login , ";
				strQuery1 = $"{strQuery1}C1.comp_id As CompId,  C1.comp_name As CompName, ";
				strQuery1 = $"{strQuery1}C1.comp_city As City, C1.comp_state As StateAbbrev, ";
				strQuery1 = $"{strQuery1}C1.comp_country As Country, CT1.contact_id As ContactId, ";
				strQuery1 = $"{strQuery1}C1.comp_account_callback_date As Callback_Date, ";

				strQuery1 = $"{strQuery1}dbo.CreateContactFullNameTitle(CT1.contact_sirname, CT1.contact_first_name, CT1.contact_middle_initial, CT1.contact_last_name, CT1.contact_suffix,'') As Contact, ";
				strQuery1 = $"{strQuery1}A1.ac_id As ACId, ";
				strQuery1 = $"{strQuery1}SIL1.subislog_journ_id As JournId,  SIL1.subislog_comp_id As CompId2, ";
				strQuery1 = $"{strQuery1}C2.comp_name As CompName2, ";
				strQuery1 = $"{strQuery1}AM1.amod_make_name As Make,  AM1.amod_model_name As Model, ";
				strQuery1 = $"{strQuery1}A1.ac_ser_no_full As SerNbr, A1.ac_reg_no As RegNbr, ";

				strQuery1 = $"{strQuery1}SIL1.subislog_msg_type As MsgType, ";
				strQuery1 = $"{strQuery1}SIL1.subislog_message As Note, ";

				if (opSubmitAircraft.Checked || opSubmitBoth.Checked)
				{
					strQuery1 = $"{strQuery1}(SELECT C3.comp_account_id ";
					strQuery1 = $"{strQuery1} FROM Aircraft_Reference AS AR3 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1} INNER JOIN Company AS C3 WITH (NOLOCK) ON C3.comp_id = AR3.cref_comp_id AND C3.comp_journ_id = AR3.cref_journ_id ";
					strQuery1 = $"{strQuery1} WHERE (AR3.cref_ac_id = SIL1.subislog_ac_id) ";
					strQuery1 = $"{strQuery1} AND (AR3.cref_journ_id = SIL1.subislog_journ_id) ";
					strQuery1 = $"{strQuery1} AND (AR3.cref_primary_poc_flag = 'Y')) As AcctRep, ";
				}
				else
				{
					strQuery1 = $"{strQuery1}'' As AcctRep, ";
				}

				if (opSubmitCompany.Checked || opSubmitBoth.Checked)
				{
					strQuery1 = $"{strQuery1}(SELECT C4.comp_account_id ";
					strQuery1 = $"{strQuery1} FROM Company AS C4 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1} WHERE (C4.comp_id = c1.comp_id) "; //switched from  SIL1.subislog_comp_id
					strQuery1 = $"{strQuery1} AND (C4.comp_journ_id = SIL1.subislog_journ_id) ";
					strQuery1 = $"{strQuery1}) As AcctRep2, ";
				}
				else
				{
					strQuery1 = $"{strQuery1}'' As AcctRep2, ";
				}

				strQuery1 = $"{strQuery1}SIL1.subislog_account_id  As AcctRep3 ";

				strQuery1 = $"{strQuery1}FROM Subscription_Install_Log AS SIL1 WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription AS S1 WITH (NOLOCK) ON S1.sub_id = SIL1.subislog_subid ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription_Install AS SI1 WITH (NOLOCK) ON SI1.subins_sub_id = SIL1.subislog_subid AND SI1.subins_login = SIL1.subislog_login AND SI1.subins_seq_no = SIL1.subislog_seq_no ";
				strQuery1 = $"{strQuery1}INNER JOIN Company AS C1 WITH (NOLOCK) ON C1.comp_id = S1.sub_comp_id AND C1.comp_journ_id = 0 ";
				strQuery1 = $"{strQuery1}INNER JOIN Contact AS CT1 WITH (NOLOCK) ON CT1.contact_id = SI1.subins_contact_id AND CT1.contact_journ_id = 0 ";
				strQuery1 = $"{strQuery1}LEFT OUTER JOIN Company AS C2 WITH (NOLOCK) ON C2.comp_id = SIL1.subislog_comp_id AND C2.comp_journ_id = SIL1.subislog_journ_id ";
				strQuery1 = $"{strQuery1}LEFT OUTER JOIN Aircraft AS A1 WITH (NOLOCK) ON SIL1.subislog_ac_id = A1.ac_id AND A1.ac_journ_id = SIL1.subislog_journ_id ";
				strQuery1 = $"{strQuery1}LEFT OUTER JOIN Aircraft_Model AS AM1 WITH (NOLOCK) ON AM1.amod_id = A1.ac_amod_id ";
				strQuery1 = $"{strQuery1}WHERE (SIL1.subislog_journ_id = 0) ";

				if (opSubmitAircraft.Checked)
				{
					strQuery1 = $"{strQuery1}AND (SIL1.subislog_ac_id > 0) ";
				}

				strQuery1 = $"{strQuery1}AND (SIL1.subislog_msg_type in ('Submitted Data', 'Submitted Data In Progress') ";


				strQuery1 = $"{strQuery1}) ";


				strQuery1 = $"{strQuery1}AND (SIL1.subislog_message IS NOT NULL AND SIL1.subislog_message <> '') ";

				//---------------------------------------------------------
				// Must Be Primary On Aircraft Or Company AcctRep

				if (strAcctRepId != "" && strAcctRepId != "ALL")
				{

					if (opSubmitBoth.Checked)
					{
						strQuery1 = $"{strQuery1}AND (";

						strQuery1 = $"{strQuery1}     (";
						strQuery1 = $"{strQuery1}        (SIL1.subislog_account_id IS NULL OR SIL1.subislog_account_id = '') ";
						strQuery1 = $"{strQuery1}        AND EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}                    INNER JOIN Company AS C2 WITH (NOLOCK) ON C2.comp_id = AR2.cref_comp_id AND C2.comp_journ_id = AR2.cref_journ_id ";
						strQuery1 = $"{strQuery1}                    WHERE (AR2.cref_ac_id = A1.ac_id) ";
						strQuery1 = $"{strQuery1}                    AND (AR2.cref_journ_id = A1.ac_journ_id)  ";
						strQuery1 = $"{strQuery1}                    AND (AR2.cref_primary_poc_flag = 'Y') ";
						strQuery1 = $"{strQuery1}                    AND  C2.comp_account_id {make_account_rep_answer_string()}";
						strQuery1 = $"{strQuery1}                    ) ";
						strQuery1 = $"{strQuery1}     ) ";

						strQuery1 = $"{strQuery1} OR ";

						strQuery1 = $"{strQuery1}    (";
						strQuery1 = $"{strQuery1}        (SIL1.subislog_account_id IS NULL OR SIL1.subislog_account_id = '') ";
						strQuery1 = $"{strQuery1}         AND EXISTS (SELECT NULL FROM Company AS C3 WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}                     WHERE (C3.comp_id = C1.comp_id) "; // changed from SIL1.subislog_comp_id) - MSW 7/31/19
						strQuery1 = $"{strQuery1}                     AND (C3.comp_journ_id = 0) ";
						strQuery1 = $"{strQuery1}                     AND  C3.comp_account_id {make_account_rep_answer_string()}";
						strQuery1 = $"{strQuery1}                     ) ";
						strQuery1 = $"{strQuery1}     ) ";

						strQuery1 = $"{strQuery1}     OR (SIL1.subislog_account_id IS NOT NULL AND SIL1.subislog_account_id = '{strAcctRepId}') ";

						strQuery1 = $"{strQuery1}    ) "; // AND

					} // If opSubmitBoth.Value = True Then

					if (opSubmitAircraft.Checked)
					{
						strQuery1 = $"{strQuery1}AND (";
						strQuery1 = $"{strQuery1}       (";
						strQuery1 = $"{strQuery1}         (SIL1.subislog_account_id IS NULL OR SIL1.subislog_account_id = '') ";
						strQuery1 = $"{strQuery1}          AND EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}                      INNER JOIN Company AS C2 WITH (NOLOCK) ON C2.comp_id = AR2.cref_comp_id AND C2.comp_journ_id = AR2.cref_journ_id ";
						strQuery1 = $"{strQuery1}                      WHERE (AR2.cref_ac_id = A1.ac_id) ";
						strQuery1 = $"{strQuery1}                      AND (AR2.cref_journ_id = A1.ac_journ_id)  ";
						strQuery1 = $"{strQuery1}                      AND (AR2.cref_primary_poc_flag = 'Y') ";
						strQuery1 = $"{strQuery1}                      AND  C2.comp_account_id  {make_account_rep_answer_string()}";
						strQuery1 = $"{strQuery1}                     ) ";
						strQuery1 = $"{strQuery1}         ) ";
						strQuery1 = $"{strQuery1}     OR (SIL1.subislog_account_id IS NOT NULL AND SIL1.subislog_account_id = '{strAcctRepId}') ";
						strQuery1 = $"{strQuery1}    ) ";
					} // If opSubmitAircraft.Value = True Then

					if (opSubmitCompany.Checked)
					{
						strQuery1 = $"{strQuery1}AND (";
						strQuery1 = $"{strQuery1}        (";
						strQuery1 = $"{strQuery1}          (SIL1.subislog_account_id IS NULL OR SIL1.subislog_account_id = '') ";
						strQuery1 = $"{strQuery1}           AND EXISTS (SELECT NULL FROM Company AS C3 WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}                       WHERE (C3.comp_id = C1.comp_id) ";
						strQuery1 = $"{strQuery1}                       AND (C3.comp_journ_id = 0) ";
						strQuery1 = $"{strQuery1}                       AND ((C3.comp_account_id  {make_account_rep_answer_string()}) or (C3.comp_account_id  {make_account_rep_answer_string()})) ";
						strQuery1 = $"{strQuery1}                      ) ";
						strQuery1 = $"{strQuery1}         ) ";
						strQuery1 = $"{strQuery1}     OR (SIL1.subislog_account_id IS NOT NULL AND SIL1.subislog_account_id {make_account_rep_answer_string()}) ";
						strQuery1 = $"{strQuery1}    ) ";
					} // If opSubmitCompany.Value = True Then

				} // If strACCTRepId <> "" And strACCTRepId <> "NO REP SELECTED" Then

				//-----------------------------------------------
				// Select Aircraft Type

				if (opSubmitAircraft.Checked || opSubmitBoth.Checked)
				{


					switch(strSelect)
					{
						case "A" :  // - Helicopters and Business Aircraft 
							strQuery1 = $"{strQuery1}AND ( "; 
							strQuery1 = $"{strQuery1}        (AM1.amod_airframe_type_code = 'F' "; 
							strQuery1 = $"{strQuery1}         AND AM1.amod_product_business_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}         AND A1.ac_product_business_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}        ) "; 
							strQuery1 = $"{strQuery1}     OR (AM1.amod_airframe_type_code = 'R' "; 
							strQuery1 = $"{strQuery1}         AND AM1.amod_product_helicopter_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}         AND A1.ac_product_helicopter_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}        ) "; 
							strQuery1 = $"{strQuery1}    ) "; 
							 
							break;
						case "B" :  // - Business Aircraft 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'F') AND (AM1.amod_product_business_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_business_flag = 'Y') "; 
							 
							break;
						case "C" :  // - Commercial 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'F') AND (AM1.amod_product_commercial_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_commercial_flag = 'Y') "; 
							 
							break;
						case "H" :  // - Helicopters 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'R') AND (AM1.amod_product_helicopter_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_helicopter_flag = 'Y') "; 
							 
							break;
						case "L" :  // - All 
							 
							break;
						case "Q" :  // JNiQ Eligible 
							 
							strQuery1 = $"{strQuery1}{modCommon.Return_JNiQ_Eligible_Query(strAcctRepId, strQuery1)}"; 
							 
							break;
						case "N" :  // Non-JNiQ Eligible 
							 
							strQuery1 = $"{strQuery1}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
							 
							break;
						case "P" :  // - AirBP 
							 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_airbp_flag = 'Y') "; 
							 
							break;
					} // strSelect

				} // If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then

				strQuery1 = $"{strQuery1}ORDER BY DateEntered, Make, Model, SerNbr ";

				fgrdFindCustSubData.Tag = "DateEntered, Make, Model, SerNbr"; // Save Sort Order

				modAdminCommon.Record_Event("Monitor Activity", $"Customer Submitted Data - Selected AcctRep: {strAcctRepId}");

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{


					lTot1 = rstRec1.RecordCount;
					lCnt1 = 0;
					lRow1 = 0;

					fgrdFindCustSubData.Redraw = false;

					do 
					{ // Loop Until rstRec1.EOF = True '  Or lblFindCustSubDataStop.Enabled = False

						lCnt1++;
						//lblFindCustSubDataRecords.Caption = "Total Records Found: " & Format(lTot1, "00000#") & "  Loading: " & Format(lCnt1, "00000#")

						lRow1++;
						fgrdFindCustSubData.RowsCount = lRow1 + 1;
						fgrdFindCustSubData.CurrentRowIndex = lRow1;

						//---------------------------------------------
						//-- Set Status Field

						fgrdFindCustSubData.set_RowData(lRow1,Convert.ToInt32( rstRec1.GetField("SubISId")));
						fgrdFindCustSubData[lRow1, 17].Value = "No";
						lRowColor = 0x80000005; // White
						lCellColor = unchecked((int) 0x80000008); // Black

						if (($"{Convert.ToString(rstRec1["MsgType"])} ").Trim() == "Submitted Data Completed")
						{
							fgrdFindCustSubData[lRow1, 17].Value = "Yes";
							lRowColor = 0x80000003;
						}

						if (($"{Convert.ToString(rstRec1["MsgType"])} ").Trim() == "Submitted Data In Progress")
						{
							fgrdFindCustSubData[lRow1, 17].Value = "No";
							lRowColor = 0xFFFF00;
						}

						lCol1 = -1;

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["DateEntered"]))
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["DateEntered"], "mm/dd/yyyy hh:MM AMPM");
						}
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["CompID"]);

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["CompName"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = $"{($"{Convert.ToString(rstRec1["country"])} ").Trim()}, {($"{Convert.ToString(rstRec1["StateAbbrev"])} ").Trim()}, {($"{Convert.ToString(rstRec1["city"])} ").Trim()}";

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ContactId"]);
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["CONTACT"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ACID"]))
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ACID"]);
						}
						else
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "0";
						}

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["JournID"]))
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["JournID"]);
						}
						else
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "0";
						}

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["make"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["model"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["SerNbr"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["RegNbr"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["compid2"]))
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["compid2"]);
						}
						else
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "0";
						}

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						fgrdFindCustSubData.CellFontBold = false;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["CompName2"])} ").Trim();

						// ADDED MSW - 3/1/16 to show account rep
						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						if (opSubmitCompany.Checked)
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["AcctRep2"])} ").Trim();
						}
						else
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["AcctRep"]))
							{
								fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["AcctRep"])} ").Trim();
							}
							else
							{
								fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["AcctRep2"])} ").Trim();
							}
						}


						// 11/29/2018 - By David D. Cruger
						// This AcctRep has been manually Assigned To This Record
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["AcctRep3"]) && ($"{Convert.ToString(rstRec1["AcctRep3"])} ").Trim() != "")
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["AcctRep3"])} ").Trim();
							fgrdFindCustSubData.CellBackColor = Color.FromArgb(255, 128, 0); // TAN
							fgrdFindCustSubData.CellForeColor = SystemColors.HighlightText; // WHITE
							fgrdFindCustSubData.CellFontBold = true;
						}

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["NOTE"])} ").Trim(); // Trim(rstRec1!NOTE & " ")

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["MsgType"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						// fgrdFindCustSubData.Text = ""

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Callback_Date"])} ").Trim();


						// ADDED MSW 3/9/2020 FOR MOSTLY DEMO LOGINS
						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["login"])} ").Trim();



						if (lRow1 == 25)
						{
							fgrdFindCustSubData.Redraw = true;
							fgrdFindCustSubData.Refresh();
							fgrdFindCustSubData.Redraw = false;
						}

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!rstRec1.EOF); // Or lblFindCustSubDataStop.Enabled = False


					fgrdFindCustSubData.Height = 129;
					grd_pub.Height = 179;
					fgrdFindCustSubData.Top = 280;

					fgrdFindCustSubData.Redraw = true;
					fgrdFindCustSubData.Refresh();
					fgrdFindCustSubData.Enabled = true;

				}
				else
				{
					fgrdFindCustSubData.CurrentRowIndex = 1;
					fgrdFindCustSubData.CurrentColumnIndex = 2;
					fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "No CSD Records Found";
					//    lblFindCustSubDataRecords.Caption = "No Records Found"


					fgrdFindCustSubData.Height = 57;
					fgrdFindCustSubData.Top = 360;
					grd_pub.Height = 272;
				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				//UPGRADE_TODO: (1067) Member Enabled is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				frm_ActionList.DefInstance.lblFindCustSubDataStop.Enabled = false;
				//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				frm_ActionList.DefInstance.lblFindCustSubDataStop.Visible = false;

				//UPGRADE_TODO: (1067) Member Text is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				strMsg = $"AcctRep: {Convert.ToString(frm_ActionList.DefInstance.cbo_account_id.Text)}";
				//UPGRADE_TODO: (1067) Member Text is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				strMsg = $"{strMsg} Product: {Convert.ToString(frm_ActionList.DefInstance.cmbProductType.Text)}";
				//UPGRADE_TODO: (1067) Member Text is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				if (Convert.ToString(frm_ActionList.DefInstance.txt_ListStartDate.Text) != "")
				{
					//UPGRADE_TODO: (1067) Member Text is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					strMsg = $"{strMsg} Start Date: {Convert.ToString(frm_ActionList.DefInstance.txt_ListStartDate.Text)}";
				}

				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				if (((CheckState) Convert.ToInt32(frm_ActionList.DefInstance.chkCustSubDataIncludeCompleted.Checked)) == CheckState.Checked)
				{
					strMsg = $"{strMsg} [x] Include Completed ";
				}

				if (bLog)
				{

					modCommon.End_Activity_Monitor_Message("Callback Cust Submit Data", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

					frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

				}


				//UPGRADE_TODO: (1067) Member Enabled is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				frm_ActionList.DefInstance.cmdFindCustSubDataRefresh.Enabled = true;
				rstRec1 = null;

				return;

			}

			Fill_Find_Customer_Submitted_Data_Grid_Error:

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			modAdminCommon.Record_Error("Callbacks (Find Customer Submitted Data)", $"Fill_Find_Customer_Submitted_Data_Grid: {Information.Err().Number.ToString()} - {Information.Err().Description}");

		} // Fill_Find_Customer_Submitted_Data_Grid

		public string make_account_rep_answer_string()
		{

			bool use_alt_rep = false;



			return $" = '{($"{cbo_ACREP.Text} ").Trim()}' ";


		}


		private void Fill_Find_Customer_Submitted_Data_Grid_Headers()
		{

			int lRowl = 0;


			fgrdFindCustSubData.Clear();
			fgrdFindCustSubData.RowsCount = 2;
			fgrdFindCustSubData.ColumnsCount = 20;

			fgrdFindCustSubData.CurrentRowIndex = 0;

			//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14       15,   16,        17
			// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, AcctRep, Note, Completed, Status

			int lCol1 = -1;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Date Entered";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 114);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "CompId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Company";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 150);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Country, State, City";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "ContactId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Contact";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 133);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "ACId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "JournId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Make";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			// If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 93);
			// End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Model";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			// If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 83);
			//  End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "SerNbr";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			//  If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 73);
			//  End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "RegNbr";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			// If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 73);
			// End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "CompId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Company Updated";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			//  If opSubmitCompany.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 150);
			//  End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			string strACCTRep = cbo_ACREP.Text.ToUpper();
			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "AcctRep";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			//  If strAcctRep = "NO REP SELECTED" Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 53);
			// End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Note";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 200);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Completed";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Status";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 147);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleCenter;


			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Last Contact Date";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 147);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Login";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 147);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleCenter;


			fgrdFindCustSubData.FixedRows = 1;
			fgrdFindCustSubData.FixedColumns = 0;

			fgrdFindCustSubData.CurrentRowIndex = 1;

		} // Fill_Find_Customer_Submitted_Data_Grid_Headers



		private void cmdSubDataEMail_Click()
		{

			string strInsert1 = "";

			int lSubISId = 0;
			int lACId = 0;
			int lCompId = 0;
			int lCompId2 = 0;
			int lContactId = 0;

			string strToEMail = "";
			string strToName = "";
			string strFromEMail = "";
			string strFromName = "";
			string strSubject = "";
			string strBody = "";
			string strStatus = "";
			string strErrorMsg = "";

			string strMake = "";
			string strModel = "";
			string strSerNbr = "";
			string strRegNbr = "";
			string strNote = "";
			string strCompName = "";
			string journ_user = "";
			string strJSubject = "";

			string strSMTPServer = "";
			int lSMTPPort = 0;
			string strSMTPUserName = "";
			string strSMTPPassWord = "";

			System.DateTime dtSystemDateTime = DateTime.FromOADate(0);

			string strMsg = "";

			int lRow1 = 0;
			int lCol1 = 0;

			try
			{



				lRow1 = grd_pub.RowSel;

				if (lRow1 >= 1)
				{

					// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14     15,   16
					// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, ACREP, Note, Completed

					lCompId = 0;
					lContactId = 0;
					lACId = 0;
					lCompId2 = 0;

					if (Information.IsNumeric(Convert.ToString(grd_pub[lRow1, 18].Value)))
					{
						lCompId = Convert.ToInt32(Double.Parse(Convert.ToString(grd_pub[lRow1, 18].Value)));
					}
					//  If IsNumeric(grd_pub.TextMatrix(lRow1, 4)) = True Then lContactId = CLng(grd_pub.TextMatrix(lRow1, 4))
					if (Information.IsNumeric(Convert.ToString(grd_pub[lRow1, 4].Value)))
					{
						lACId = Convert.ToInt32(Double.Parse(Convert.ToString(grd_pub[lRow1, 4].Value)));
					}
					// If IsNumeric(grd_pub.TextMatrix(lRow1, 12)) = True Then lCompId2 = CLng(grd_pub.TextMatrix(lRow1, 12))
					journ_user = Convert.ToString(grd_pub[lRow1, 19].Value);



					strToEMail = modCommon.GetUserEMailAddress(journ_user);
					strToName = modCommon.GetFullUserName(journ_user);


					if (strToEMail != "")
					{

						//strToEMail = "patty@jetnet.com"  ' to test it
						strFromEMail = modCommon.GetUserEMailAddress(modAdminCommon.gbl_User_ID);
						strFromName = modCommon.GetFullUserName(modAdminCommon.gbl_User_ID);

						strModel = Convert.ToString(grd_pub[lRow1, 17].Value).Trim();
						strSerNbr = Convert.ToString(grd_pub[lRow1, 6].Value).Trim();
						strRegNbr = Convert.ToString(grd_pub[lRow1, 5].Value).Trim();

						strCompName = Convert.ToString(grd_pub[lRow1, 13].Value).Trim();
						strNote = Convert.ToString(grd_pub[lRow1, 16].Value).Trim();

						strBody = "Memo Information.%0D%0D";

						if (strModel != "")
						{
							strSubject = $"Memo feedback on {strModel} {strSerNbr} {strRegNbr}";
							strBody = $"{strBody}On the following aircraft.%0D%0D";
							strBody = $"{strBody}Make: {strMake}%0D";
							strBody = $"{strBody}Model: {strModel}%0D";
							strBody = $"{strBody}SerNbr: {strSerNbr}%0D";
							strBody = $"{strBody}RegNbr: {strRegNbr}%0D%0D";
						}

						if (strCompName != "")
						{
							if (strSubject.Trim() != "")
							{
								strSubject = $"{strSubject}, {strCompName}";
							}
							else
							{
								strSubject = $"Memo {strCompName}";
							}
							strBody = $"{strBody}On the following company.%0D%0D";
							strBody = $"{strBody}Company: {strCompName}%0D";
						}
						strBody = $"{strBody}Memo Information: {StringsHelper.Replace(strNote, "\"", "", 1, -1, CompareMethod.Binary)}%0D%0D";

						strBody = $"{strBody}Kind regards,%0D%0D{strFromName}%0D%0D";

						if (strToEMail != "" && strSubject != "" && strBody != "")
						{
							JetNetSupport.PInvoke.SafeNative.shell32.ShellExecute(Support.GetHInstance().ToInt32(), "open", $"mailto:{strToEMail}?subject={strSubject}&body={strBody}", null, null, 0);
						}

						strJSubject = "Memo email response has been sent";
						strStatus = "Open";
						strErrorMsg = "";

						dtSystemDateTime = DateTime.Parse(modAdminCommon.GetSystemDateTime());

						strInsert1 = "INSERT INTO Journal ( journ_date,  journ_subcategory_code,  journ_subject, ";
						strInsert1 = $"{strInsert1}journ_description, journ_ac_id, journ_comp_id,  journ_contact_id, ";
						strInsert1 = $"{strInsert1}journ_user_id,  journ_entry_date, journ_entry_time, ";
						strInsert1 = $"{strInsert1}journ_account_id,  journ_prior_account_id, journ_status, ";
						strInsert1 = $"{strInsert1}journ_customer_note,  journ_action_date ";
						strInsert1 = $"{strInsert1}) VALUES (";
						strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
						strInsert1 = $"{strInsert1}'RN', ";
						strInsert1 = $"{strInsert1}'{($"{strJSubject} ").Trim()}', ";
						strInsert1 = $"{strInsert1}'{strNote.Substring(0, Math.Min(2000, strNote.Length))}', ";
						strInsert1 = $"{strInsert1}{lACId.ToString()}, ";
						strInsert1 = $"{strInsert1}{lCompId.ToString()}, ";
						strInsert1 = $"{strInsert1}{lContactId.ToString()}, ";
						strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}', ";
						strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
						strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("HH:mm:ss")}', ";
						strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_Account_ID}', ";
						strInsert1 = $"{strInsert1}'', ";
						strInsert1 = $"{strInsert1}'A',  '', ";
						strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy HH:mm:ss")}'";
						strInsert1 = $"{strInsert1})";

						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						strMsg = $"Memo email response has been sent {Environment.NewLine}{Environment.NewLine}";
						strMsg = $"{strMsg}{strToName} at {strToEMail}{Environment.NewLine}{Environment.NewLine}";
						strMsg = $"{strMsg}For Aircraft {strMake} {strModel} {strSerNbr} {strRegNbr}";

						MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

					}
					else
					{
						MessageBox.Show($"Memo Data Row Selected - Contact Does NOT Have An EMail Address{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					} // If strToEMail <> "" Then



				}
				else
				{
					MessageBox.Show($"Memo Data Grid Must Have A Row Selected{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				} // If lRow1 >= 1 Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmdSubDataEMail_Click_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_ActionList(EMAIL SUB DATA)");
			}



		} // cmdSubDataEMail_Click

		private void cmdSubDataEMail_Click_New_Form()
		{

			string strInsert1 = "";

			int lSubISId = 0;
			int lACId = 0;
			int lCompId = 0;
			int lCompId2 = 0;
			int lContactId = 0;

			string strToEMail = "";
			string strToName = "";
			string strFromEMail = "";
			string strFromName = "";
			string strSubject = "";
			string strBody = "";
			string strStatus = "";
			string strErrorMsg = "";

			string strMake = "";
			string strModel = "";
			string strSerNbr = "";
			string strRegNbr = "";
			string strNote = "";
			string strCompName = "";

			string strJSubject = "";

			string strSMTPServer = "";
			int lSMTPPort = 0;
			string strSMTPUserName = "";
			string strSMTPPassWord = "";

			System.DateTime dtSystemDateTime = DateTime.FromOADate(0);

			string strMsg = "";

			int lRow1 = 0;
			int lCol1 = 0;

			try
			{

				if (cmd_pub[10].Enabled)
				{

					cmd_pub[10].Enabled = false;

					lRow1 = fgrdFindCustSubData.RowSel;

					if (lRow1 >= 1)
					{

						lSubISId = fgrdFindCustSubData.get_RowData(lRow1);

						if (lSubISId > 0)
						{

							//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
							// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14     15,   16
							// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, ACREP, Note, Completed

							lCompId = 0;
							lContactId = 0;
							lACId = 0;
							lCompId2 = 0;

							if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow1, 1].Value)))
							{
								lCompId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow1, 1].Value)));
							}
							if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow1, 4].Value)))
							{
								lContactId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow1, 4].Value)));
							}
							if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow1, 6].Value)))
							{
								lACId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow1, 6].Value)));
							}
							if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow1, 12].Value)))
							{
								lCompId2 = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow1, 12].Value)));
							}

							if (lCompId > 0)
							{

								if (lContactId > 0)
								{

									if (lACId > 0 || lCompId2 > 0)
									{

										strToEMail = modCommon.DLookUp("contact_email_address", "Contact", $"(contact_id = {lContactId.ToString()}) AND (contact_email_address IS NOT NULL) AND (contact_email_address <> '') AND (contact_journ_id = 0)");
										strToName = Convert.ToString(fgrdFindCustSubData[lRow1, 5].Value).Trim(); //-- Contact Name

										if (strToEMail != "")
										{

											strFromEMail = modCommon.GetUserEMailAddress(modAdminCommon.gbl_User_ID);
											strFromName = modCommon.GetFullUserName(modAdminCommon.gbl_User_ID);

											strMake = Convert.ToString(fgrdFindCustSubData[lRow1, 8].Value).Trim();
											strModel = Convert.ToString(fgrdFindCustSubData[lRow1, 9].Value).Trim();
											strSerNbr = Convert.ToString(fgrdFindCustSubData[lRow1, 10].Value).Trim();
											strRegNbr = Convert.ToString(fgrdFindCustSubData[lRow1, 11].Value).Trim();

											strCompName = Convert.ToString(fgrdFindCustSubData[lRow1, 13].Value).Trim();
											strNote = Convert.ToString(fgrdFindCustSubData[lRow1, 15].Value).Trim();

											strBody = "JETNET has received your feedback and have updated the information you have provided.%0D%0D";

											if (strMake != "")
											{
												strSubject = $"JETNET has received your feedback on {strMake} {strModel} {strSerNbr} {strRegNbr}";
												strBody = $"{strBody}On the following aircraft.%0D%0D";
												strBody = $"{strBody}Make: {strMake}%0D";
												strBody = $"{strBody}Model: {strModel}%0D";
												strBody = $"{strBody}SerNbr: {strSerNbr}%0D";
												strBody = $"{strBody}RegNbr: {strRegNbr}%0D%0D";
											}

											if (strCompName != "")
											{
												strSubject = $"JETNET has received your feedback on {strCompName}";
												strBody = $"{strBody}On the following company.%0D%0D";
												strBody = $"{strBody}Company: {strCompName}%0D";
											}
											strBody = $"{strBody}Submitted Information: {StringsHelper.Replace(strNote, "\"", "", 1, -1, CompareMethod.Binary)}%0D%0D";

											strBody = $"{strBody}Kind regards,%0D%0D";
											strBody = $"{strBody}{strFromName}%0D%0D";

											if (strToEMail != "" && strSubject != "" && strBody != "")
											{
												JetNetSupport.PInvoke.SafeNative.shell32.ShellExecute(Support.GetHInstance().ToInt32(), "open", $"mailto:{strToEMail}?subject={strSubject}&body={strBody}", null, null, 0);
											}

											strJSubject = "Sent email response to customer submitted data";
											strStatus = "Open";
											strErrorMsg = "";

											dtSystemDateTime = DateTime.Parse(modAdminCommon.GetSystemDateTime());

											strInsert1 = "INSERT INTO Journal ( journ_date, journ_subcategory_code, journ_subject, ";
											strInsert1 = $"{strInsert1}journ_description, journ_ac_id,  journ_comp_id, ";
											strInsert1 = $"{strInsert1}journ_contact_id,  journ_user_id,  journ_entry_date, ";
											strInsert1 = $"{strInsert1}journ_entry_time,  journ_account_id, journ_prior_account_id, ";
											strInsert1 = $"{strInsert1}journ_status,  journ_customer_note,  journ_action_date ";

											strInsert1 = $"{strInsert1}) VALUES (";
											strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
											strInsert1 = $"{strInsert1}'RN', ";
											strInsert1 = $"{strInsert1}'{($"{strJSubject} ").Trim()}', ";
											strInsert1 = $"{strInsert1}'{strNote.Substring(0, Math.Min(2000, strNote.Length))}', ";
											strInsert1 = $"{strInsert1}{lACId.ToString()}, ";
											strInsert1 = $"{strInsert1}{lCompId.ToString()}, ";
											strInsert1 = $"{strInsert1}{lContactId.ToString()}, ";
											strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}', ";
											strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
											strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("HH:mm:ss")}', ";
											strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_Account_ID}', ";
											strInsert1 = $"{strInsert1}'', ";
											strInsert1 = $"{strInsert1}'A', '', ";
											strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy HH:mm:ss")}'";
											strInsert1 = $"{strInsert1})";

											DbCommand TempCommand = null;
											TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
											UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
											TempCommand.CommandText = strInsert1;
											//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
											TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
											UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
											TempCommand.ExecuteNonQuery();

											strMsg = $"Customer Submitted Data EMail Response Has Been Sent To {Environment.NewLine}{Environment.NewLine}";
											strMsg = $"{strMsg}{strToName} at {strToEMail}{Environment.NewLine}{Environment.NewLine}";
											strMsg = $"{strMsg}For Aircraft {strMake} {strModel} {strSerNbr} {strRegNbr}";

											MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

										}
										else
										{
											MessageBox.Show($"Customer Submitted Data Row Selected - Contact Does NOT Have An EMail Address{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
										} // If strToEMail <> "" Then

									}
									else
									{
										MessageBox.Show($"Customer Submitted Data Row Selected Does NOT Have An ACId or CompId2{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									} // If lACId > 0 Or lCompId2 > 0 Then

								}
								else
								{
									MessageBox.Show($"Customer Submitted Data Row Selected Does NOT Have An ContactId{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								} //If lContactId > 0 Then

							}
							else
							{
								MessageBox.Show($"Customer Submitted Data Row Selected Does NOT Have An CompId{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							} // If lCompId > 0 Then

						}
						else
						{
							MessageBox.Show($"Customer Submitted Data Row Selected Does NOT Have An SubISId{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						} // If lSubISId > 0 Then

					}
					else
					{
						MessageBox.Show($"Customer Submitted Data Grid Must Have A Row Selected{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					} // If lRow1 >= 1 Then

					cmd_pub[10].Enabled = true;

				} // If cmdSubDataEMail.Enabled = True Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmdSubDataEMail_Click_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_ActionList(EMAIL SUB DATA)");
				cmd_pub[10].Enabled = true;
			}

		} // cmdSubDataEMail_Click



		public void load_pub_sources(bool only_reset_now = false, string temp_cat = "")
		{
			string search_string = "";

			string Query = "";
			ADORecordSetHelper ado_Yacht = new ADORecordSetHelper();

			Application.DoEvents();

			//if we have changed, then re-load msw - 9/14/23
			if ((SSTabHelper.GetSelectedIndex(tab_NewAvail) != last_tab) && only_reset_now)
			{
				if (SSTabHelper.GetSelectedIndex(tab_NewAvail) == 3)
				{
					cbo_pub[6].Text = "Memo"; //new tab is memo
				}
				else if (SSTabHelper.GetSelectedIndex(tab_NewAvail) == 2)
				{ 
					cbo_pub[6].Text = "Pub";
				}
			}

			if (temp_cat.Trim() == "")
			{
				temp_cat = cbo_pub[6].Text;
			}

			if (temp_cat.Trim() == "Memo")
			{
				cbo_pub[3].Items.Clear();
				cbo_pub[3].AddItem("");
				cbo_pub[3].AddItem("General");
				cbo_pub[3].SetItemData(cbo_pub[3].Items.Count - 1, 901);
				cbo_pub[3].AddItem("Registry");
				cbo_pub[3].SetItemData(cbo_pub[3].Items.Count - 1, 905);
				cbo_pub[3].AddItem("Accident Report");
				cbo_pub[3].SetItemData(cbo_pub[3].Items.Count - 1, 903);
				cbo_pub[3].AddItem("A/C Review");
				cbo_pub[3].SetItemData(cbo_pub[3].Items.Count - 1, 906);
				cbo_pub[3].AddItem("Company/Contact");
				cbo_pub[3].SetItemData(cbo_pub[3].Items.Count - 1, 907);
				cbo_pub[3].AddItem("CSD");
				cbo_pub[3].SetItemData(cbo_pub[3].Items.Count - 1, 908);
				Application.DoEvents();
				Application.DoEvents();
				//cbo_pub(3).Tag = cbo_pub(6).Text
				Application.DoEvents();
				Application.DoEvents();
			}
			else if (temp_cat.Trim() == "Doc Request")
			{ 
				cbo_pub[3].Items.Clear();
				cbo_pub[3].AddItem("");
				Application.DoEvents();
				//  cbo_pub(3).Tag = cbo_pub(6).Text
				Application.DoEvents();
				Application.DoEvents();
			}
			else
			{

				Query = "SELECT  distinct pub_name, publist_source   from Publication_Listing with (NOLOCK)  ";
				Query = $"{Query} left outer join Publications with (NOLOCK) on pub_id = publist_source ";
				Query = $"{Query} where pub_name is not null ";


				search_string = Query;

				ado_Yacht = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_Yacht.Fields) && !(ado_Yacht.BOF && ado_Yacht.EOF))
				{

					cbo_pub[3].Items.Clear();
					cbo_pub[3].AddItem("");

					cbo_pub[3].AddItem("Dealer Website");
					cbo_pub[3].SetItemData(cbo_pub[3].Items.Count - 1, 900);

					cbo_pub[3].AddItem("General");
					cbo_pub[3].SetItemData(cbo_pub[3].Items.Count - 1, 901);


					cbo_pub[3].AddItem("Accident Report");
					cbo_pub[3].SetItemData(cbo_pub[3].Items.Count - 1, 903);

					cbo_pub[3].AddItem("News Article");
					cbo_pub[3].SetItemData(cbo_pub[3].Items.Count - 1, 904);


					cbo_pub[3].AddItem("Registry");
					cbo_pub[3].SetItemData(cbo_pub[3].Items.Count - 1, 905);


					while(!ado_Yacht.EOF)
					{

						if (Convert.ToString(ado_Yacht["pub_name"]).Trim() != "Dealer Website" && Convert.ToString(ado_Yacht["pub_name"]).Trim() != "General" && Convert.ToString(ado_Yacht["pub_name"]).Trim() != "Trade-A-Plane" && Convert.ToString(ado_Yacht["pub_name"]).Trim() != "Accident Report" && Convert.ToString(ado_Yacht["pub_name"]).Trim() != "News Article")
						{
							cbo_pub[3].AddItem(Convert.ToString(ado_Yacht["pub_name"]));
							cbo_pub[3].SetItemData(cbo_pub[3].Items.Count - 1, Convert.ToInt32(ado_Yacht["publist_source"]));
						}

						ado_Yacht.MoveNext();
					};

				}

				ado_Yacht.Close();

				// tag set to what it was last time  8/18/22
				cbo_pub[3].Tag = cbo_pub[6].Text;
				Application.DoEvents();
			}

			Application.DoEvents();




		}


		private bool insert_research_note(int in_CompanyID, int in_AircraftID, int in_ContactID, ref string inJournSubject, string inNoteTypeText, int inSelAircraftOpt, int in_YachtID = 0, string yacht_info = "")
		{

			bool result = false;
			try
			{

				int nPreviousACID = 0;

				DbConnection cntCRM = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
				ADORecordSetHelper ado_CompanyAircaft = new ADORecordSetHelper();
				ADORecordSetHelper ado_Primary = new ADORecordSetHelper();
				ADORecordSetHelper snpCRM = new ADORecordSetHelper();

				ADORecordSetHelper snpcomp_info = new ADORecordSetHelper();
				snpcomp_info = new ADORecordSetHelper();

				string Query = "";

				string user_first_name = "";
				string user_last_name = "";
				string user_email = "";
				string crm_user_login_id = "";
				string insert_string = "";
				string SQL = "";

				string insert_client_company = "";
				StringBuilder insert_client_contact = new StringBuilder();
				StringBuilder insert_client_phone_numbers = new StringBuilder();
				string insert_client_reference = "";
				string insert_client_reference_contact = "";
				int client_company_id = 0;
				string temp_date = "";
				string comp_orig_name = "";
				string comp_orig_city = "";
				string comp_orig_state = "";
				string u_string = "";
				bool client_company_exists = false;
				string marketing_desc = "";
				string JCatPart1 = "";
				result = false;

				nPreviousACID = 0;
				u_string = "";
				marketing_desc = "";
				comp_orig_name = "";
				comp_orig_city = "";
				comp_orig_state = "";

				// || inserted to break out the string
				if (inJournSubject.IndexOf("||") >= 0)
				{
					marketing_desc = inJournSubject.Substring(Math.Max(inJournSubject.Length - (Strings.Len(inJournSubject) - (inJournSubject.IndexOf("||") + 1) - 2), 0));
					inJournSubject = inJournSubject.Substring(0, Math.Min(inJournSubject.IndexOf("||"), inJournSubject.Length));
				}

				client_company_exists = false;
				client_company_id = 0;

				// MSW - 1/14/2013 ----------- IF IT IS A MANAGEMENT NOTE --------- FIND/ADD USER then ADD NOTE INTO MARKETING CRM-----------------
				if (inNoteTypeText.Trim() != "")
				{

					if (inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).Trim() == "MN")
					{

						if (modCommon.OpenMarketingCRMDatabase(ref cntCRM))
						{

							//*******************************************************
							// select user name from homebase for insert into crm

							Query = $"SELECT * FROM [user] WHERE (user_id = '{modAdminCommon.gbl_User_ID}') ";

							ado_Primary.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							if (!ado_Primary.BOF && !ado_Primary.EOF)
							{
								user_first_name = ($"{Convert.ToString(ado_Primary["user_first_name"])} ").Trim();
								user_last_name = ($"{Convert.ToString(ado_Primary["user_last_name"])} ").Trim();
								user_email = ($"{Convert.ToString(ado_Primary["user_email_address"])} ").Trim();
							}

							ado_Primary.Close();

							//*******************************************************
							// select from the crm and see if that user already exists

							Query = "SELECT * FROM client_user WHERE ( ";
							Query = $"{Query}       cliuser_first_name = '{user_first_name}' ";
							Query = $"{Query}   AND cliuser_last_name = '{user_last_name}'";
							Query = $"{Query}      )  OR (cliuser_login = '{user_email}') ";

							snpCRM.Open(Query, cntCRM, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

							crm_user_login_id = "0";
							if (!snpCRM.BOF && !snpCRM.EOF)
							{
								crm_user_login_id = Convert.ToString(snpCRM["cliuser_id"]);
							}
							snpCRM.Close();


							//*******************************************************
							// if user isnt found, then add one in

							if (crm_user_login_id.Trim() == "0")
							{

								insert_string = "INSERT INTO client_user ( cliuser_first_name,  cliuser_last_name, ";
								insert_string = $"{insert_string}cliuser_login, cliuser_active_flag,  cliuser_timezone ";

								insert_string = $"{insert_string} ) VALUES ( '{user_first_name}', ";
								insert_string = $"{insert_string}'{user_last_name}', ";

								if (modAdminCommon.gbl_User_ID.Trim() == "mvit")
								{
									insert_string = $"{insert_string}'matt@mvintech.com',";
								}
								else
								{
									insert_string = $"{insert_string}'{user_email}',";
								}
								insert_string = $"{insert_string}'Y', '2'   ) ";

								DbCommand TempCommand = null;
								TempCommand = cntCRM.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = insert_string;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();

								// insert into client_user - new user
								// select biggest user id from client_user
								Query = "SELECT MAX(cliuser_id) As MaxUserId FROM client_user ";
								snpCRM.Open(Query, cntCRM, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

								if (!snpCRM.BOF && !snpCRM.EOF)
								{
									crm_user_login_id = Convert.ToString(snpCRM["MaxUserId"]);
								}

								snpCRM.Close();

							} // If Trim(crm_user_login_id) = "0" Then

							//*******************************************************
							// find the company id in the crm for client company
							client_company_exists = false;
							client_company_id = 0;

							Query = "SELECT clicomp_id FROM client_company ";
							Query = $"{Query}WHERE (clicomp_jetnet_comp_id = {in_CompanyID.ToString()}) ";

							snpCRM.Open(Query, cntCRM, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

							if (!snpCRM.BOF && !snpCRM.EOF)
							{
								client_company_exists = true;
								client_company_id = Convert.ToInt32(snpCRM["clicomp_id"]);
							}

							snpCRM.Close();

							if (!client_company_exists)
							{

								// find current company name, address, and state
								//***************************************************88
								Query = "SELECT comp_name, comp_city, comp_state FROM Company WITH (NOLOCK) ";
								Query = $"{Query}WHERE (comp_id = {in_CompanyID.ToString()})  AND (comp_journ_id = 0)  ";

								ado_Primary.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								if (!ado_Primary.BOF && !ado_Primary.EOF)
								{

									comp_orig_name = ($"{Convert.ToString(ado_Primary["comp_name"])} ").Trim();
									comp_orig_city = ($"{Convert.ToString(ado_Primary["Comp_city"])} ").Trim();
									comp_orig_state = ($"{Convert.ToString(ado_Primary["comp_state"])} ").Trim();

								}

								ado_Primary.Close();


								comp_orig_name = StringsHelper.Replace(comp_orig_name, "'", "", 1, -1, CompareMethod.Binary);

								Query = $"SELECT clicomp_id  FROM client_company WHERE (clicomp_name= '{comp_orig_name}' ";
								Query = $"{Query}    OR clicomp_name= '{comp_orig_name}  *' ";
								Query = $"{Query}    OR clicomp_name= '{comp_orig_name} *') ";
								Query = $"{Query}AND (clicomp_city = '{comp_orig_city}')  AND (clicomp_state = '{comp_orig_state}') ";

								snpCRM.Open(Query, cntCRM, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

								client_company_exists = false;
								if (!snpCRM.BOF && !snpCRM.EOF)
								{
									client_company_exists = true;
									client_company_id = Convert.ToInt32(snpCRM["clicomp_id"]);
								}
								snpCRM.Close();

							} // If client_company_exists = False Then

							if (client_company_id > 0)
							{

								u_string = $"UPDATE client_company SET clicomp_jetnet_comp_id = {in_CompanyID.ToString()} ";
								u_string = $"{u_string}WHERE (clicomp_id = {client_company_id.ToString()}) ";

								DbCommand TempCommand_2 = null;
								TempCommand_2 = cntCRM.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
								TempCommand_2.CommandText = u_string;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_2.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
								TempCommand_2.ExecuteNonQuery();

							} // If client_company_id > 0 Then

							// --------------- start of if there is no client record----------------
							if (!client_company_exists)
							{

								// select jetnet company data

								Query = $"SELECT * FROM Company WHERE (comp_id = {in_CompanyID.ToString()}) AND (comp_journ_id = 0)";

								snpcomp_info.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

								if (!snpcomp_info.BOF && !snpcomp_info.EOF)
								{

									// insert into client company

									insert_client_company = "INSERT INTO client_company ( clicomp_name, ";
									insert_client_company = $"{insert_client_company}clicomp_alternate_name_type, ";
									insert_client_company = $"{insert_client_company}clicomp_alternate_name, ";
									insert_client_company = $"{insert_client_company}clicomp_address1, ";
									insert_client_company = $"{insert_client_company}clicomp_address2, ";
									insert_client_company = $"{insert_client_company}clicomp_city, clicomp_state,  clicomp_zip_code, ";
									insert_client_company = $"{insert_client_company}clicomp_country,  clicomp_agency_type, ";
									insert_client_company = $"{insert_client_company}clicomp_web_address, clicomp_email_address, ";
									insert_client_company = $"{insert_client_company}clicomp_action_date, clicomp_status, ";
									insert_client_company = $"{insert_client_company}clicomp_jetnet_comp_id, clicomp_user_id, ";
									insert_client_company = $"{insert_client_company}clicomp_description,  clicomp_name_search";

									insert_client_company = $"{insert_client_company} ) VALUES ( ";

									insert_client_company = $"{insert_client_company}'{StringsHelper.Replace(($"{Convert.ToString(snpcomp_info["comp_name"])} ").Trim(), "'", "", 1, -1, CompareMethod.Binary)}', ";
									insert_client_company = $"{insert_client_company}'{StringsHelper.Replace(($"{Convert.ToString(snpcomp_info["comp_name_alt_type"])} ").Trim(), "'", "", 1, -1, CompareMethod.Binary)}', ";
									insert_client_company = $"{insert_client_company}'{($"{Convert.ToString(snpcomp_info["comp_name_alt"])} ").Trim()}', ";
									insert_client_company = $"{insert_client_company}'{StringsHelper.Replace(($"{Convert.ToString(snpcomp_info["comp_address1"])} ").Trim(), "'", "", 1, -1, CompareMethod.Binary)}', ";
									insert_client_company = $"{insert_client_company}'{StringsHelper.Replace(($"{Convert.ToString(snpcomp_info["comp_address2"])} ").Trim(), "'", "", 1, -1, CompareMethod.Binary)}', ";
									insert_client_company = $"{insert_client_company}'{StringsHelper.Replace(($"{Convert.ToString(snpcomp_info["Comp_city"])} ").Trim(), "'", "", 1, -1, CompareMethod.Binary)}', ";
									insert_client_company = $"{insert_client_company}'{($"{Convert.ToString(snpcomp_info["comp_state"])} ").Trim()}', ";
									insert_client_company = $"{insert_client_company}'{($"{Convert.ToString(snpcomp_info["comp_zip_code"])} ").Trim()}', ";
									insert_client_company = $"{insert_client_company}'{StringsHelper.Replace(($"{Convert.ToString(snpcomp_info["Comp_country"])} ").Trim(), "'", "", 1, -1, CompareMethod.Binary)}', ";
									insert_client_company = $"{insert_client_company}'{($"{Convert.ToString(snpcomp_info["comp_agency_type"])} ").Trim()}', ";
									insert_client_company = $"{insert_client_company}'{($"{Convert.ToString(snpcomp_info["comp_web_address"])} ").Trim()}', ";
									insert_client_company = $"{insert_client_company}'{($"{Convert.ToString(snpcomp_info["comp_email_address"])} ").Trim()}', ";
									insert_client_company = $"{insert_client_company}'{DateTime.Now.ToString("yyyy-MM-dd")}', ";
									insert_client_company = $"{insert_client_company}'Y', ";
									insert_client_company = $"{insert_client_company}{Convert.ToString(snpcomp_info["comp_id"])}, ";
									insert_client_company = $"{insert_client_company}'{crm_user_login_id}', ";
									insert_client_company = $"{insert_client_company}'{StringsHelper.Replace(($"{Convert.ToString(snpcomp_info["comp_description"])} ").Trim(), "'", "", 1, -1, CompareMethod.Binary)}', ";
									insert_client_company = $"{insert_client_company}'{($"{Convert.ToString(snpcomp_info["comp_name_search"])} ").Trim()}' ";
									insert_client_company = $"{insert_client_company})";

								} // If (snpcomp_info.BOF = False And snpcomp_info.EOF = False) Then

								snpcomp_info.Close();

								DbCommand TempCommand_3 = null;
								TempCommand_3 = cntCRM.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
								TempCommand_3.CommandText = insert_client_company;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_3.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
								TempCommand_3.ExecuteNonQuery();

								//------------------------------------------
								// find just inserted client company id

								Query = $"SELECT clicomp_id FROM client_company WHERE (clicomp_jetnet_comp_id = {in_CompanyID.ToString()}) ";

								snpCRM.Open(Query, cntCRM, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

								client_company_id = 0;
								if (!snpCRM.BOF && !snpCRM.EOF)
								{
									client_company_id = Convert.ToInt32(Double.Parse(Convert.ToString(snpCRM["clicomp_id"])));
								} // If (snpCRM.BOF = False And snpCRM.EOF = False) Then
								snpCRM.Close();

								//-------------------------------------------
								// select reference data

								SQL = "SELECT cref_id as acref_id, cref_ac_id as acref_ac_id, cref_comp_id as acref_comp_id, cref_contact_id as acref_contact_id, ";
								SQL = $"{SQL}cref_contact_type as acref_contact_type, cref_owner_percent as acref_owner_percentage, ";
								SQL = $"{SQL}cref_fraction_expires_date as acref_date_fraction_purchased, ";
								SQL = $"{SQL}cref_fraction_expires_date as acref_date_fraction_expires, ";
								SQL = $"{SQL}cref_business_type as acref_business_type, cref_operator_flag as acref_operator_flag ";
								SQL = $"{SQL}FROM Aircraft_Reference WITH (NOLOCK) ";
								SQL = $"{SQL}LEFT OUTER JOIN Contact WITH (NOLOCK) ON cref_contact_id = contact_id AND contact_journ_id = cref_journ_id  ";
								SQL = $"{SQL}WHERE (cref_comp_id = {in_CompanyID.ToString()}) AND (cref_contact_id = 0)  AND (cref_journ_id = 0) ";
								SQL = $"{SQL}ORDER BY cref_ac_id ASC, cref_id ASC";

								snpcomp_info.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

								if (!snpcomp_info.BOF && !snpcomp_info.EOF)
								{

									// insert into client reference

									insert_client_reference = "INSERT INTO client_aircraft_reference ( cliacref_cliac_id, ";
									insert_client_reference = $"{insert_client_reference}cliacref_comp_id, cliacref_contact_id, ";
									insert_client_reference = $"{insert_client_reference}cliacref_contact_type, ";
									insert_client_reference = $"{insert_client_reference}cliacref_owner_percentage, cliacref_jetnet_ac_id, ";
									insert_client_reference = $"{insert_client_reference}cliacref_date_fraction_purchased, ";
									insert_client_reference = $"{insert_client_reference}cliacref_date_fraction_expires, cliacref_business_type, ";
									insert_client_reference = $"{insert_client_reference}cliacref_operator_flag,  cliacref_jetnet_contact_type, ";
									insert_client_reference = $"{insert_client_reference}cliacref_contact_priority ";

									insert_client_reference = $"{insert_client_reference}) VALUES (";

									insert_client_reference = $"{insert_client_reference}'0', ";
									insert_client_reference = $"{insert_client_reference}{client_company_id.ToString()}, ";
									insert_client_reference = $"{insert_client_reference}{Convert.ToString(snpcomp_info["acref_contact_id"])}, ";
									insert_client_reference = $"{insert_client_reference}'{($"{Convert.ToString(snpcomp_info["acref_contact_type"])} ").Trim()}', ";
									insert_client_reference = $"{insert_client_reference}{Convert.ToString(snpcomp_info["acref_owner_percentage"])}, ";
									insert_client_reference = $"{insert_client_reference}{Convert.ToString(snpcomp_info["acref_ac_id"])}, ";

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(snpcomp_info["acref_date_fraction_purchased"]))
									{
										temp_date = Convert.ToDateTime(snpcomp_info["acref_date_fraction_purchased"]).ToString("yyyy-MM-dd");
										insert_client_reference = $"{insert_client_reference}'{temp_date}', ";
										insert_client_reference = $"{insert_client_reference}'{temp_date}', ";
									}
									else
									{
										insert_client_reference = $"{insert_client_reference}NULL, ";
										insert_client_reference = $"{insert_client_reference}NULL, ";
									}

									insert_client_reference = $"{insert_client_reference}'{($"{Convert.ToString(snpcomp_info["acref_business_type"])} ").Trim()}', ";
									insert_client_reference = $"{insert_client_reference}'{($"{Convert.ToString(snpcomp_info["acref_operator_flag"])} ").Trim()}', ";
									insert_client_reference = $"{insert_client_reference}'', ";
									insert_client_reference = $"{insert_client_reference}'0'  ); ";

									DbCommand TempCommand_4 = null;
									TempCommand_4 = cntCRM.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
									TempCommand_4.CommandText = insert_client_reference;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_4.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
									TempCommand_4.ExecuteNonQuery();

								} // If (snpcomp_info.BOF = False And snpcomp_info.EOF = False) Then

								snpcomp_info.Close();

								//-----------------------------------
								// select jetnet contact data

								SQL = "SELECT contact_action_date, contact_comp_id, contact_email_address, contact_first_name, ";
								SQL = $"{SQL}contact_id, contact_last_name, contact_middle_initial, contact_sirname, contact_suffix, ";
								SQL = $"{SQL}contact_title, 'JETNET' AS contact_type ";
								SQL = $"{SQL}FROM contact WITH (NOLOCK)  WHERE (contact_comp_id = {in_CompanyID.ToString()}) ";
								SQL = $"{SQL}AND (contact_journ_id = 0) AND (contact_hide_flag = 'N')  AND (contact_active_flag = 'Y')";

								snpcomp_info.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

								if (!snpcomp_info.BOF && !snpcomp_info.EOF)
								{

									do 
									{ // Loop Until snpcomp_info.EOF = True

										// insert into client contact

										insert_client_contact = new StringBuilder("INSERT INTO client_contact ( clicontact_comp_id, ");
										insert_client_contact.Append("clicontact_sirname, ");
										insert_client_contact.Append("clicontact_first_name, clicontact_middle_initial, ");
										insert_client_contact.Append("clicontact_last_name,  clicontact_suffix, ");
										insert_client_contact.Append("clicontact_title,  clicontact_email_address, ");
										insert_client_contact.Append("clicontact_action_date,  clicontact_notes, ");
										insert_client_contact.Append("clicontact_email_list, clicontact_preferred_name, ");
										insert_client_contact.Append("clicontact_status, clicontact_jetnet_contact_id, ");
										insert_client_contact.Append("clicontact_user_id ");

										insert_client_contact.Append(") VALUES ( ");

										insert_client_contact.Append($"{client_company_id.ToString()}, ");
										insert_client_contact.Append($"'{($"{Convert.ToString(snpcomp_info["contact_sirname"])} ").Trim()}', ");
										insert_client_contact.Append($"'{($"{Convert.ToString(snpcomp_info["contact_first_name"])} ").Trim()}', ");
										insert_client_contact.Append($"'{($"{Convert.ToString(snpcomp_info["contact_middle_initial"])} ").Trim()}', ");
										insert_client_contact.Append($"'{($"{Convert.ToString(snpcomp_info["contact_last_name"])} ").Trim()}', ");
										insert_client_contact.Append($"'{($"{Convert.ToString(snpcomp_info["contact_suffix"])} ").Trim()}', ");
										insert_client_contact.Append($"'{($"{Convert.ToString(snpcomp_info["contact_title"])} ").Trim()}', ");
										insert_client_contact.Append($"'{($"{Convert.ToString(snpcomp_info["contact_email_address"])} ").Trim()}', ");

										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(snpcomp_info["contact_action_date"]))
										{
											temp_date = Convert.ToDateTime(snpcomp_info["contact_action_date"]).ToString("yyyy-MM-dd");
											insert_client_contact.Append($"'{temp_date}', ");
										}
										else
										{
											insert_client_contact.Append("NULL, ");
										}

										insert_client_contact.Append("'', ");
										insert_client_contact.Append("'', ");
										insert_client_contact.Append("'', ");
										insert_client_contact.Append("'Y', ");
										insert_client_contact.Append($"{Convert.ToString(snpcomp_info["contact_id"])}, ");
										insert_client_contact.Append($"'{crm_user_login_id}' ");

										insert_client_contact.Append(" ); ");

										DbCommand TempCommand_5 = null;
										TempCommand_5 = cntCRM.CreateCommand();
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
										TempCommand_5.CommandText = insert_client_contact.ToString();
										//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
										//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
										TempCommand_5.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
										TempCommand_5.ExecuteNonQuery();

										snpcomp_info.MoveNext();

									}
									while(!snpcomp_info.EOF);

								} // If (snpcomp_info.BOF = False And snpcomp_info.EOF = False) Then

								snpcomp_info.Close();

								//-----------------------------------------
								// select jetnet phone number data

								SQL = "SELECT pnum_comp_id, pnum_contact_id,  pnum_number_full as pnum_number, pnum_type, ptype_seq_no ";
								SQL = $"{SQL}FROM phone_numbers WITH (NOLOCK) ";
								SQL = $"{SQL}INNER JOIN phone_type with (NOLOCK) ON phone_type.ptype_name = phone_numbers.pnum_type ";
								SQL = $"{SQL}WHERE (pnum_comp_id = {in_CompanyID.ToString()}) ";
								SQL = $"{SQL}AND (pnum_journ_id = 0)  ORDER BY ptype_seq_no";

								snpcomp_info.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

								if (!snpcomp_info.BOF && !snpcomp_info.EOF)
								{

									do 
									{ // Loop Until snpcomp_info.EOF = True

										//-------------------------------------
										// insert into client phone numbers

										insert_client_phone_numbers = new StringBuilder("INSERT INTO Client_Phone_Numbers ( clipnum_comp_id, ");
										insert_client_phone_numbers.Append("clipnum_contact_id, ");
										insert_client_phone_numbers.Append("clipnum_type, ");
										insert_client_phone_numbers.Append("clipnum_number ");
										insert_client_phone_numbers.Append(") VALUES ( ");
										insert_client_phone_numbers.Append($"{client_company_id.ToString()}, ");
										insert_client_phone_numbers.Append($"{Convert.ToString(snpcomp_info["pnum_contact_id"])}, ");
										insert_client_phone_numbers.Append($"'{($"{Convert.ToString(snpcomp_info["pnum_type"])} ").Trim()}', ");
										insert_client_phone_numbers.Append($"'{($"{Convert.ToString(snpcomp_info["pnum_number"])} ").Trim()}' ");
										insert_client_phone_numbers.Append("); ");

										DbCommand TempCommand_6 = null;
										TempCommand_6 = cntCRM.CreateCommand();
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
										TempCommand_6.CommandText = insert_client_phone_numbers.ToString();
										//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
										//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
										TempCommand_6.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
										TempCommand_6.ExecuteNonQuery();

										snpcomp_info.MoveNext();

									}
									while(!snpcomp_info.EOF);

								} // If (snpcomp_info.BOF = False And snpcomp_info.EOF = False) Then

								snpcomp_info.Close();

							} // If client_company_exists = False Then

							if (crm_user_login_id.Trim() != "0")
							{

								temp_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

								insert_string = "INSERT INTO local_notes ( lnote_user_login, ";
								insert_string = $"{insert_string}lnote_user_name, ";
								insert_string = $"{insert_string}lnote_notecat_key, lnote_status, lnote_note, ";
								insert_string = $"{insert_string}lnote_jetnet_comp_id, lnote_client_comp_id,  lnote_entry_date, ";
								insert_string = $"{insert_string}lnote_jetnet_contact_id,  lnote_user_id ";

								insert_string = $"{insert_string}) VALUES (";

								insert_string = $"{insert_string}'{crm_user_login_id}', ";
								insert_string = $"{insert_string}'{user_first_name} {user_last_name}', ";
								insert_string = $"{insert_string}'19', ";
								insert_string = $"{insert_string}'A', ";
								insert_string = $"{insert_string}'{StringsHelper.Replace(inJournSubject, "'", "", 1, -1, CompareMethod.Binary)} - {marketing_desc}', ";
								insert_string = $"{insert_string}{in_CompanyID.ToString()}, ";
								insert_string = $"{insert_string}{client_company_id.ToString()}, ";

								// 12/04/2015 - By David D. Cruger
								// Make Sure Hours, Minutes Seconds Are Included
								// HH=24 Hour

								// MM=Month, mm=minute, HH=24 Hr
								insert_string = $"{insert_string}'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', ";
								insert_string = $"{insert_string}{in_ContactID.ToString()}, ";
								insert_string = $"{insert_string}'{crm_user_login_id}' ); ";

								DbCommand TempCommand_7 = null;
								TempCommand_7 = cntCRM.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_7);
								TempCommand_7.CommandText = insert_string;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_7.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_7);
								TempCommand_7.ExecuteNonQuery();


							} // If Trim(crm_user_login_id) <> "0" Then

							UpgradeHelpers.DB.TransactionManager.DeEnlist(cntCRM);
							cntCRM.Close();
							cntCRM = null;

						} // If OpenMarketingCRMDatabase(cntCRM) = True Then

					} // If Trim(left(inNoteTypeText, 2)) = "MN" Then

				} // If Trim(inNoteTypeText) <> "" Then

				// MSW - 1/14/2013 ----------- IF IT IS A MANAGEMENT NOTE --------- FIND/ADD USER then ADD NOTE INTO MARKETING CRM-----------------

				modAdminCommon.ADO_Transaction("BeginTrans");

				//  create journal entry for one aircraft selected
				if (inSelAircraftOpt == modGlobalVars.opt_verify_ac_ONE && inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "RN")
				{

					modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
					modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";

					frm_Journal.DefInstance.Commit_Journal_Entry();

				}
				else if (in_YachtID > 0 && (inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "RN" || inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "YN"))
				{ 
					// MSW - 11/14/2012 - - FOR YACHT NOTE
					//    The yahct note needed a seperate place to go in.
					// it is put in just like an ac note, but instead the yaxcht id is > 0

					modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject; //& "- " & yacht_info
					modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper();
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";

					frm_Journal.DefInstance.Commit_Journal_Entry();


					// ADDED IN MSW 2/24/2014
				}
				else if ((inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "CN" || inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "FN"))
				{ 

					modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject; //& "- " & yacht_info
					modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper();
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_yacht_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";

					frm_Journal.DefInstance.Commit_Journal_Entry();

				}

				//  create journal entry for all aircraft selected
				if (inSelAircraftOpt == modGlobalVars.opt_verify_ac_ALL && inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "RN")
				{

					Query = $"EXEC HomebaseGetCompanyAircraftList {in_CompanyID.ToString()}, 0";

					ado_CompanyAircaft = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_CompanyAircaft.Fields) && !(ado_CompanyAircaft.BOF && ado_CompanyAircaft.EOF))
					{


						while(!ado_CompanyAircaft.EOF)
						{
							// process each unique aircraft
							if (nPreviousACID != Convert.ToInt32(ado_CompanyAircaft["ac_id"]))
							{

								modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
								modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
								modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));

								modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(ado_CompanyAircaft["ac_id"]);

								modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
								modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
								modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
								modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
								modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
								modAdminCommon.Rec_Journal_Info.journ_status = "A";
								modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

								frm_Journal.DefInstance.Commit_Journal_Entry();
							}

							nPreviousACID = Convert.ToInt32(ado_CompanyAircaft["ac_id"]);
							ado_CompanyAircaft.MoveNext();

						}; // While Not ado_CompanyAircaft.EOF

						ado_CompanyAircaft.Close();

					} // Not (ado_CompanyAircaft.BOF And ado_CompanyAircaft.EOF)

					ado_CompanyAircaft = null;

				}

				//ADDED MSW - 11/15/16
				if (inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "ID")
				{
					modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
					modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(6, inNoteTypeText.Length)).ToUpper();
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";
					modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

					frm_Journal.DefInstance.Commit_Journal_Entry();
				}

				// 03/09/2017 - By David D. Cruger; Added
				if (inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "PB" || inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "MEMO")
				{
					modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
					if (marketing_desc.Trim() == "" && inJournSubject.Trim() != "")
					{
						modAdminCommon.Rec_Journal_Info.journ_description = "";
					}
					else
					{
						modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
					}

					if (inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "PB")
					{
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(6, inNoteTypeText.Length)).ToUpper();
					}
					else if (inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "MEMO")
					{ 
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "MEMO";
					}
					else
					{
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(6, inNoteTypeText.Length)).ToUpper();
					}



					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";

					modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

					frm_Journal.DefInstance.Commit_Journal_Entry();
				}

				// 05/12/2017 - By David D. Cruger; Added
				if (inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "RA")
				{
					modAdminCommon.Rec_Journal_Info.journ_subject = "Reassign Attempted";
					modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";
					modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

					frm_Journal.DefInstance.Commit_Journal_Entry();
				}

				// 05/12/2017 - By David D. Cruger; Added
				if (inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "DO")
				{
					modAdminCommon.Rec_Journal_Info.journ_subject = "Doc Attempted";
					modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";
					modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

					frm_Journal.DefInstance.Commit_Journal_Entry();
				}
				//  create journal entry for no aircraft selected
				JCatPart1 = inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper();
				if (JCatPart1 != "CN" && JCatPart1 != "FN" && JCatPart1 != "ID" && JCatPart1 != "PB" && JCatPart1 != "RA" && JCatPart1 != "DO")
				{
					if (inSelAircraftOpt == modGlobalVars.opt_verify_ac_NONE)
					{

						modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
						modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
						// 01/23/2013 - By David D. Cruger
						// Per Lucia; Added ADN-Aircraft Delivery Note
						if (inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "AN")
						{
							modAdminCommon.Rec_Journal_Info.journ_category_code = "AN";
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "ADN"; // Aircraft Delivery Notes
						}
						else
						{
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper();
						}
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

						frm_Journal.DefInstance.Commit_Journal_Entry();

					}
				}

				//  create journal entry for primary aircraft selected
				if (inSelAircraftOpt == modGlobalVars.opt_verify_ac_PRIMARY && inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "RN")
				{
					Query = $"EXEC HomebaseGetCompanyAircraftList {in_CompanyID.ToString()}, 0";

					ado_CompanyAircaft = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_CompanyAircaft.Fields) && !(ado_CompanyAircaft.BOF && ado_CompanyAircaft.EOF))
					{


						while(!ado_CompanyAircaft.EOF)
						{

							// process each unique aircraft
							if (nPreviousACID != Convert.ToInt32(ado_CompanyAircaft["ac_id"]))
							{

								//create journal entry for primary aircraft selected
								if (Convert.ToString(ado_CompanyAircaft["cref_primary_poc_flag"]).Trim().ToUpper() == "Y" || Convert.ToString(ado_CompanyAircaft["cref_primary_poc_flag"]).Trim().ToUpper() == "X")
								{

									modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
									modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));

									modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(ado_CompanyAircaft["ac_id"]);

									modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
									modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
									modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
									modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";

									frm_Journal.DefInstance.Commit_Journal_Entry();

								}

							}

							nPreviousACID = Convert.ToInt32(ado_CompanyAircaft["ac_id"]);
							ado_CompanyAircaft.MoveNext();

						}; // While Not ado_CompanyAircaft.EOF

						ado_CompanyAircaft.Close();

					} // Not (ado_CompanyAircaft.BOF And ado_CompanyAircaft.EOF)

					ado_CompanyAircaft = null;

				}

				modAdminCommon.ADO_Transaction("CommitTrans");


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"insert_research_note_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
			}
			return result;
		} // insert_research_note

		private void cmd_Save_Click(Object eventSender, EventArgs eventArgs)
		{

			if (cmd_Save.Text == "Save")
			{
				Update_Pub();
			}
			else
			{

				frm_Journal.DefInstance.Reference_Journal_ID = Convert.ToInt32(NewRecs["publog_journ_id"]);
				frm_Journal.DefInstance.Reference_Comp_Id = 0;
				frm_Journal.DefInstance.Reference_Contact_Id = 0;

				frm_Journal.DefInstance.ShowDialog();

			}

		}

		private void cmd_Stop_Click(Object eventSender, EventArgs eventArgs) => StopStatus = true;


		private void cmdAddPub_Click(Object eventSender, EventArgs eventArgs) => mnuEditAdd_Click(mnuEditAdd, new EventArgs());


		private void cmdClear_Click(Object eventSender, EventArgs eventArgs)
		{

			int i = 0;

			try
			{

				if (cmdClear.Text == "Clear Pub")
				{

					if (grd_NewAvail.CurrentRowIndex > 0)
					{
						if (MessageBox.Show("Are You Sure You Want To Clear The Selected Pub", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{
							//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_NewAvail.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							ClearPub(grd_NewAvail.get_RowData(grd_NewAvail.CurrentRowIndex), grd_NewAvail.BandData(grd_NewAvail.CurrentRowIndex), Convert.ToString(grd_NewAvail[grd_NewAvail.CurrentRowIndex, 0].Value));
							Get_New_Pubs(Convert.ToString(grd_NewAvail.Tag));
						}
					}
					else
					{
						MessageBox.Show("You must select a Pub", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}

				}
				else
				{

					if (grd_NewAvail.CurrentRowIndex > 0)
					{
						if (MessageBox.Show("Are You Sure You Want To UnClear The Selected Pub", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{
							//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_NewAvail.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							UnClearPub(grd_NewAvail.get_RowData(grd_NewAvail.CurrentRowIndex), grd_NewAvail.BandData(grd_NewAvail.CurrentRowIndex), Convert.ToString(grd_NewAvail[grd_NewAvail.CurrentRowIndex, 0].Value));
							Get_New_Pubs(Convert.ToString(grd_NewAvail.Tag));
						}
					}
					else
					{
						MessageBox.Show("You must select a Pub", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}

				}
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"cmdClear_Error: {excep.Message}", "webcrawler");
			}
		}

		private void cmdRefresh_Click(Object eventSender, EventArgs eventArgs) => Get_New_Pubs("");


		private void cmdSendVerifyEMail_Click(Object eventSender, EventArgs eventArgs) => send_verify_email("");
		 // cmdSendVerifyEMail_Click


		private void fgrdFindCustSubData_Click(Object eventSender, EventArgs eventArgs)
		{



			string strOrderBy = "";
			string temp_acrep = "";

			int lMouseRow = fgrdFindCustSubData.MouseRow;
			int lMouseCol = fgrdFindCustSubData.MouseCol;
			//  cmdCSDChangeAcctRep.Enabled = False

			if (lMouseRow == 0)
			{ // Header Row

				//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
				// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14       15,   16
				// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, AcctRep, Note, Completed

				switch(lMouseCol)
				{
					case 0 : 
						strOrderBy = "DateEntered, Make, Model, SerNbr "; 
						break;
					case 1 : 
						strOrderBy = "CompId "; 
						break;
					case 2 : 
						strOrderBy = "CompName, Country, State, City "; 
						break;
					case 3 : 
						strOrderBy = "Country, State, City "; 
						break;
					case 5 : 
						strOrderBy = "Contact "; 
						break;
					case 8 : 
						strOrderBy = "Make, Model, SerNbr "; 
						break;
					case 9 : 
						strOrderBy = "Model, Make, SerNbr "; 
						break;
					case 10 : 
						strOrderBy = "SerNbr, Make, Model "; 
						break;
					case 11 : 
						strOrderBy = "RegNbr, SerNbr "; 
						break;
					case 12 : 
						strOrderBy = "CompId2 "; 
						break;
					case 13 : 
						strOrderBy = "CompName2 "; 
						break;
					case 14 : 
						strOrderBy = "AcctRep "; 
						break;
					case 15 : 
						strOrderBy = "Note "; 
						break;
				} // Case lMouseCol

				if (strOrderBy != Convert.ToString(fgrdFindCustSubData.Tag))
				{

					fgrdFindCustSubData.Tag = strOrderBy;
					fgrdFindCustSubData.CurrentColumnIndex = lMouseCol;

					switch(lMouseCol)
					{
						case 1 : case 4 : case 6 : case 7 : case 12 :  // CompId, ContactId, ACId, JournId, CompId2 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							fgrdFindCustSubData.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						default:
							fgrdFindCustSubData.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							break;
					} // Case lMouseCol

				} // If strOrderBy <> fgrdFindACNoBase.Tag Then

			}
			else
			{
				modCommon.Highlight_Grid_Row(fgrdFindCustSubData);
				cbo_pub[11].Text = Convert.ToString(fgrdFindCustSubData[lMouseRow, 14].Value);
				cmd_pub[17].Enabled = true;

				cmd_pub[10].Visible = true; // make the csd send email invisible if a

			} // If lMouseRow = 0 Then ' Header Row

			// Check Completed Status
			if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 16].Value) == "Submitted Data In Progress")
			{
				cmd_pub[16].Text = "Change to: No Longer In Process";
			}
			else
			{
				cmd_pub[16].Text = "Change To: In Progress";
			}

			cmd_pub[16].Visible = true;

			// turn these on- make them visible - MSW 0 11/22/23
			cmd_pub[17].Visible = true;
			cbo_pub[11].Visible = true;
			lbl_gen[23].Visible = true;

			cmd_pub[9].Visible = false; // make the send email for the memo/pubs tab invisible

		}

		private void fgrdFindCustSubData_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lMouseRow = 0;
			int lMouseCol = 0;
			string strOrderBy = "";
			System.DateTime dtDate = DateTime.FromOADate(0);
			int lSubISId = 0;

			frm_Company frmCompany = frm_Company.CreateInstance();
			string strText = "";

			try
			{

				lMouseRow = fgrdFindCustSubData.MouseRow;
				lMouseCol = fgrdFindCustSubData.MouseCol;

				if (lMouseRow > 0)
				{ // Header Row

					//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
					// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14       15,   16,        17
					// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, AcctRep, Note, Completed, Status


					switch(lMouseCol)
					{
						case 1 : case 2 : case 3 : case 4 : case 5 :  // CompId, CompName, Country, State, City, ContactId, Contact 
							 
							//--------------------------------------------------- 
							// Cleanup any Company Forms and Open A New One 
							 
							if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 1].Value) != "")
							{

								modCommon.Unload_Form("frm_Company");
								//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//VB.Global.Load(frmCompany);
								frmCompany.Form_Initialize();
								frmCompany.StartForm = modGlobalVars.tStart_Form;
								frmCompany.Reference_CompanyID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lMouseRow, 1].Value))); // CompId
								frmCompany.Reference_CompanyJID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lMouseRow, 7].Value))); // JournId
								frmCompany.Show();
								//UPGRADE_WARNING: (2065) Form method frmCompany.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
								frmCompany.BringToFront();
								//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
								frmCompany.Form_Activated(null, new EventArgs());

							}  // If fgrdFindCustSubData.TextMatrix(lMouseRow, 1) <> "" Then 
							 
							break;
						case 6 : case 7 : case 8 : case 9 : case 10 : case 11 :  // ACId, JournId, Make, Model, SerNbr, RegNbr 
							 
							if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 6].Value) != "")
							{

								modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lMouseRow, 6].Value))); // ACId
								modAdminCommon.gbl_Aircraft_Journal_ID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lMouseRow, 7].Value))); // JournId

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

							}  // If fgrdFindCustSubData.TextMatrix(lMouseRow, 6) <> "" Then 
							 
							break;
						case 12 : case 13 :  // CompId2, CompName2 
							 
							//--------------------------------------------------- 
							// Cleanup any Company Forms and Open A New One 
							 
							if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 12].Value) != "" && Convert.ToString(fgrdFindCustSubData[lMouseRow, 12].Value) != "0")
							{

								modCommon.Unload_Form("frm_Company");
								//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//VB.Global.Load(frmCompany);
								frmCompany.Form_Initialize();
								frmCompany.StartForm = modGlobalVars.tStart_Form;
								frmCompany.Reference_CompanyID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lMouseRow, 12].Value))); // CompId2
								frmCompany.Reference_CompanyJID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lMouseRow, 7].Value))); // JournId
								frmCompany.Show();
								//UPGRADE_WARNING: (2065) Form method frmCompany.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
								frmCompany.BringToFront();
								//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
								frmCompany.Form_Activated(null, new EventArgs());

							}  // If fgrdFindCustSubData.TextMatrix(lMouseRow, 12) <> "" And fgrdFindCustSubData.TextMatrix(lMouseRow, 12) <> "0" Then 
							 
							break;
						case 15 :  // Note 
							 
							lSubISId = fgrdFindCustSubData.get_RowData(lMouseRow); 
							 
							strText = $"Date Entered: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 0].Value)}{Environment.NewLine}{Environment.NewLine}"; 
							 
							strText = $"{strText}Company Submitted Information{Environment.NewLine}"; 
							strText = $"{strText}CompId: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 1].Value)} - "; 
							strText = $"{strText}{Convert.ToString(fgrdFindCustSubData[lMouseRow, 2].Value)}{Environment.NewLine}";  // Company Name 
							 
							strText = $"{strText}ContactId: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 4].Value)} - "; 
							strText = $"{strText}{Convert.ToString(fgrdFindCustSubData[lMouseRow, 5].Value)}{Environment.NewLine}{Environment.NewLine}";  // Contact Name 
							 
							if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 6].Value) != "" && Convert.ToString(fgrdFindCustSubData[lMouseRow, 6].Value) != "0")
							{
								strText = $"{strText}ACId: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 6].Value)} - ";
								strText = $"{strText}JournId: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 7].Value)}{Environment.NewLine}";
								strText = $"{strText}Make: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 8].Value)}  ";
								strText = $"{strText}Model: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 9].Value)}  ";
								strText = $"{strText}SerNbr: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 10].Value)}  ";
								strText = $"{strText}RegNbr: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 11].Value)}{Environment.NewLine}";
							} 
							 
							if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 12].Value) != "" && Convert.ToString(fgrdFindCustSubData[lMouseRow, 12].Value) != "0")
							{
								strText = $"{strText}Company Updated Information{Environment.NewLine}";
								strText = $"{strText}CompId: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 12].Value)} - ";
								strText = $"{strText}JournId: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 7].Value)}{Environment.NewLine}";
								strText = $"{strText}{Convert.ToString(fgrdFindCustSubData[lMouseRow, 13].Value)}{Environment.NewLine}"; // Company Name
							} 
							 
							// Status 
							if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 17].Value) == "Yes")
							{

								if (lSubISId > 0)
								{

									strQuery1 = "SELECT * FROM EventLog WITH (NOLOCK)  WHERE (evtl_type = 'Submitted Data') ";
									strQuery1 = $"{strQuery1}AND (evtl_message LIKE '%Completed%') AND (evtl_message LIKE '%SubIsLogId%') ";
									strQuery1 = $"{strQuery1}AND (evtl_message LIKE '%[{lSubISId.ToString()}]%') ";

									rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
									if (!rstRec1.BOF && !rstRec1.EOF)
									{
										strText = $"{strText}{Environment.NewLine}";
										strText = $"{strText}Completed By: {($"{Convert.ToString(rstRec1["evtl_user_id"])} ").Trim()} - {modCommon.GetFullUserName(($"{Convert.ToString(rstRec1["evtl_user_id"])} ").Trim())}";
										strText = $"{strText}  On: {StringsHelper.Format(rstRec1["evtl_date"], "mm/dd/yyyy hh:MM:ss AMPM")}{Environment.NewLine}{Environment.NewLine}";
									}
									rstRec1.Close();

								} // If lSubISId > 0 Then

							}  // If fgrdFindCustSubData.TextMatrix(lRow, 17) = "Yes" Then 
							 
							strText = $"{strText}{new string('-', 75)}{Environment.NewLine}"; 
							strText = $"{strText}Note: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 15].Value)}";  // Note 
							 
							if (strText != "")
							{

								if (frm_info2.DefInstance == null)
								{
									//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//VB.Global.Load(frm_info2.DefInstance);
								}

								frm_info2.DefInstance.SetFormCaption("Customer Submitted Data");
								frm_info2.DefInstance.SetText(strText);
								frm_info2.DefInstance.SetTextEnabled(true);
								frm_info2.DefInstance.Show();

							}  // If strText <> "" Then 
							 
							break;
					} // Case lMouseCol

				} // If lMouseRow > 0 Then ' Header Row

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("fgrdFindCustSubData_DblClick_Error", excep.Message);
			}

		}

		private void grd_pub_Click(Object eventSender, EventArgs eventArgs)
		{


			cmd_pub[10].Visible = false; // make the csd send email invisible if a

			if (cbo_pub[6].Text.Trim() == "Pub")
			{
				cmd_pub[9].Visible = false;
			}
			else if (cbo_pub[6].Text.Trim() == "Memo")
			{ 
				cmd_pub[9].Visible = true;
			}
			else if (cbo_pub[6].Text.Trim() == "Doc Request")
			{ 
				cmd_pub[9].Visible = false;
			}

			// turn these on- make them visible - MSW 0 11/22/23
			// these are update account rep items
			cmd_pub[17].Visible = false;
			cbo_pub[11].Visible = false;
			lbl_gen[23].Visible = false;



		}

		public void mnuEditCompletedCustSubData_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUpdate1 = "";

			int lSubISId = 0;
			int lACId = 0;
			int lCompId = 0;
			int lCompId2 = 0;
			int lContactId = 0;
			int lJournId = 0;

			string strNote = "";

			int lRow = 0;
			int lCol = 0;
			int iPos1 = 0;
			string strTempMsg = "";

			string strDateSubmitted = "";
			string strDateCompleted = "";
			string strContactInfo = "";

			try
			{

				if (Convert.ToString(mnuEditCompletedCustSubData.Tag) != "")
				{

					iPos1 = (Convert.ToString(mnuEditCompletedCustSubData.Tag).IndexOf(':') + 1);
					if (iPos1 > 0)
					{

						lRow = Convert.ToInt32(Double.Parse(Convert.ToString(mnuEditCompletedCustSubData.Tag).Substring(Math.Min(0, Convert.ToString(mnuEditCompletedCustSubData.Tag).Length), Math.Min(iPos1 - 1, Math.Max(0, Convert.ToString(mnuEditCompletedCustSubData.Tag).Length)))));
						lCol = Convert.ToInt32(Double.Parse(Convert.ToString(mnuEditCompletedCustSubData.Tag).Substring(Math.Min(iPos1, Convert.ToString(mnuEditCompletedCustSubData.Tag).Length))));

						fgrdFindCustSubData.CurrentRowIndex = lRow;
						modCommon.Highlight_Grid_Row(fgrdFindCustSubData);

						lACId = 0;
						lCompId = 0;
						lCompId2 = 0;
						lContactId = 0;
						lJournId = 0;
						strNote = "";

						lSubISId = fgrdFindCustSubData.get_RowData(lRow);

						if (lSubISId > 0)
						{

							//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
							// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14       15,   16,        17
							// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, AcctRep, Note, Completed, Status

							if (Convert.ToString(fgrdFindCustSubData[lRow, 17].Value) == "No")
							{

								if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow, 6].Value)))
								{
									lACId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 6].Value)));
								}

								if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow, 7].Value)))
								{
									lJournId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 7].Value)));
								}

								if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow, 1].Value)))
								{
									lCompId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 1].Value)));
								}

								if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow, 12].Value)))
								{
									lCompId2 = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 12].Value)));
								}

								if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow, 4].Value)))
								{
									lContactId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 4].Value)));
								}

								strNote = Convert.ToString(fgrdFindCustSubData[lRow, 15].Value);

								strUpdate1 = "UPDATE Subscription_Install_Log SET subislog_msg_type = 'Submitted Data Completed' ";
								strUpdate1 = $"{strUpdate1}WHERE (subislog_id = {lSubISId.ToString()}) ";

								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = strUpdate1;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();

								// --- ADDED MSW - 3/1/16-------------------------

								strQuery1 = "SELECT subislog_message, subislog_date, subislog_subins_contact_id, contact_first_name, contact_last_name, contact_email_address, comp_name ";
								strQuery1 = $"{strQuery1}FROM Subscription_Install_Log WITH (NOLOCK)  ";
								strQuery1 = $"{strQuery1}INNER JOIN Contact WITH(NOLOCK) ON contact_id = subislog_subins_contact_id AND contact_journ_id = 0 ";
								strQuery1 = $"{strQuery1}INNER JOIN Company WITH (NOLOCK) ON comp_id = contact_comp_id AND comp_journ_id = 0 ";
								strQuery1 = $"{strQuery1}WHERE (subislog_id = {lSubISId.ToString()}) ";

								rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								if (!rstRec1.BOF && !rstRec1.EOF)
								{

									strTempMsg = ($"{Convert.ToString(rstRec1["subislog_message"])} ").Trim();

									strDateSubmitted = "";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(rstRec1["subislog_date"]))
									{
										strDateSubmitted = StringsHelper.Format(rstRec1["subislog_date"], "mm/dd/yyyy hh:MM:ss AMPM");
									}
									strDateCompleted = StringsHelper.Format(DateTime.Now, "mm/dd/yyyy hh:MM:ss AMPM");

									strContactInfo = $"{($"{Convert.ToString(rstRec1["comp_name"])} ").Trim()} - " +
									                 $"{($"{Convert.ToString(rstRec1["contact_first_name"])} ").Trim()} " +
									                 $"{($"{Convert.ToString(rstRec1["contact_last_name"])} ").Trim()} (" +
									                 $"{($"{Convert.ToString(rstRec1["contact_email_address"])} ").Trim()}) ";

									strTempMsg = $"{strTempMsg}, Submitted: {strDateSubmitted}, By: {strContactInfo}, Completed: {strDateCompleted}";

								} // If rstRec1.BOF = False And rstRec1.EOF = False Then

								rstRec1.Close();

								// INSERT JOURNAL NOTE FOR COMPLETED RECORD
								// MSW  - 3/1/2016
								InsertJournalNote("Subscriber Feedback Action Completed", strTempMsg, lACId, lCompId2);

								int tempForEndVar = fgrdFindCustSubData.ColumnsCount - 1;
								for (lCol = 0; lCol <= tempForEndVar; lCol++)
								{
									fgrdFindCustSubData.CurrentColumnIndex = lCol;
									fgrdFindCustSubData.CellBackColor = SystemColors.InactiveCaption;
								}

								modCommon.Highlight_Grid_Row(fgrdFindCustSubData);

								modAdminCommon.Record_Event("Submitted Data", $"Completed - SubIsLogId=[{lSubISId.ToString()}] - {strNote.Substring(0, Math.Min(150, strNote.Length))}", lACId, lJournId, lCompId, false, 0, lContactId);

							} // If fgrdFindCustSubData.TextMatrix(lRow, 17) = "No" Then

						} // If lSubISId > 0 Then

					} // If iPos1 > 0 Then

				} // If mnuCopyFindDupsGrid.Tag <> "" Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("mnuEditCompletedCustSubData_Click_Error", excep.Message);
			}

		} // mnuEditCompletedCustSubData_Click


		private void fgrdFindCustSubData_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			int lRow = fgrdFindCustSubData.MouseRow;
			int lCol = fgrdFindCustSubData.MouseCol;

			if (lRow > 0)
			{

				if (Button == UpgradeHelpers.Utils.WinForms.MouseButtonsHelper.GetVB6ShortValue(MouseButtons.Right))
				{

					fgrdFindCustSubData.CurrentRowIndex = lRow;
					modCommon.Highlight_Grid_Row(fgrdFindCustSubData);

					if (fgrdFindCustSubData.get_RowData(lRow) > 0)
					{

						if (Convert.ToString(fgrdFindCustSubData[lRow, 17].Value) == "No")
						{

							mnuEdit.Enabled = true;

							mnuEditCompletedCustSubData.Enabled = true;
							mnuEditCompletedCustSubData.Available = true;
							mnuEditCompletedCustSubData.Tag = $"{lRow.ToString()}:{lCol.ToString()}";

							// mnuCopyFindDupsGrid.Visible = False

							modCommon.Highlight_Grid_Row(fgrdFindCustSubData);

							//UPGRADE_WARNING: (6024) Default menues are not supported for Context Menues (Popup) More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6024
							Ctx_mnuEditCompletedCustSubData1.Show(this, PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y);

						} // If fgrdFindCustSubData.TextMatrix(lRow, 17) = "No" Then

					} // If fgrdFindCustSubData.RowData(lRow) > 0 Then

				} // If Button = vbRightButton Then

			} // If lRow > 0 Then

			mnuEditCompletedCustSubData.Tag = "";

		}

		private void InsertJournalNote(string strSubject, string description, int inACID, int incompid)
		{

			string strInsert1 = "";
			System.DateTime dtSystemDateTime = DateTime.FromOADate(0);

			try
			{

				if (strSubject != "")
				{

					dtSystemDateTime = DateTime.Parse(modAdminCommon.GetSystemDateTime());

					strInsert1 = "INSERT INTO Journal ( journ_date,  journ_subcategory_code, journ_subject, ";
					strInsert1 = $"{strInsert1}journ_description, journ_ac_id, journ_comp_id, journ_contact_id, ";
					strInsert1 = $"{strInsert1}journ_user_id, journ_entry_date,  journ_entry_time, ";
					strInsert1 = $"{strInsert1}journ_account_id, journ_prior_account_id,  journ_status, ";
					strInsert1 = $"{strInsert1}journ_customer_note, journ_action_date ";

					strInsert1 = $"{strInsert1}) VALUES ( '{DateTime.Now.ToString("MM/dd/yyyy")}', ";
					strInsert1 = $"{strInsert1}'RN', ";
					strInsert1 = $"{strInsert1}'{($"{strSubject} ").Trim()}', ";
					strInsert1 = $"{strInsert1}'{StringsHelper.Replace(description, "'", "''", 1, -1, CompareMethod.Binary).Trim()}', ";
					strInsert1 = $"{strInsert1}{inACID.ToString()}, ";
					strInsert1 = $"{strInsert1}{incompid.ToString()}, ";
					strInsert1 = $"{strInsert1}0, ";
					strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}', ";
					strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
					strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("HH:mm:ss")}', ";
					strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_Account_ID}', ";
					strInsert1 = $"{strInsert1}'', ";
					strInsert1 = $"{strInsert1}'A', '', ";
					strInsert1 = $"{strInsert1}'{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}' )";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strInsert1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

				} // If strSubject <> "" Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("InsertJournalNote_Error: ", excep.Message);
			}

		} // InsertJournalNote



		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				// ********************************************************
				// IF THE FORM ACTIVATES AND WE HAVE A NEW PUB AC ID THEN
				// THIS MEANS THAT THE USER HAS IDENTIFIED AN AIRCRAFT

				cmd_ClearNoChange.Visible = false;

				if (New_Pub_AC_ID > 0)
				{
					//txt_publog_description = New_Pub_AC_ID
					Get_New_Aircraft_Info(New_Pub_AC_ID);
				}


				if (modAdminCommon.gbl_User_ID == "mvit" || modAdminCommon.gbl_User_ID == "pls" || modAdminCommon.gbl_User_ID == "jkc" || modAdminCommon.gbl_User_ID == "avl" || modAdminCommon.gbl_User_ID == "cs" || modAdminCommon.gbl_User_ID == "njh" || modAdminCommon.gbl_User_ID == "bs" || modAdminCommon.gbl_User_ID == "llp" || modAdminCommon.gbl_User_ID == "has" || modAdminCommon.gbl_User_ID == "cbqc" || modAdminCommon.gbl_User_ID == "cjb" || modAdminCommon.gbl_User_ID == "cjb2" || modAdminCommon.gbl_User_ID.ToLower() == "kkf" || modAdminCommon.gbl_User_ID.ToLower() == "ead" || modAdminCommon.gbl_User_ID.ToLower() == "edpb" || modAdminCommon.gbl_User_ID.ToLower() == "alpb" || modAdminCommon.gbl_User_ID.ToLower() == "alsp" || modAdminCommon.gbl_User_ID.ToLower() == "cbpb" || modAdminCommon.gbl_User_ID.ToLower() == "tpb" || modAdminCommon.gbl_User_ID.ToLower() == "jmm" || modAdminCommon.gbl_User_ID.ToLower() == "kvl" || modAdminCommon.gbl_User_ID.ToLower() == "nad")
				{

				}
				else
				{
					cmd_pub[5].Visible = false;
					cmd_pub[7].Visible = false;
				}

				SSTabHelper.SetTabVisible(tab_NewAvail, 3, false);




				// set these for when it defaults -- when they are all - 10/30/23
				first_attempt = 11;
				second_attempt = 3;
				third_attempt = 9;
				hold_review = 10;
				completed = 2;
				open_check = 0;
				in_progress = 5;
				blind = 8;
				cleared_check = 1;
				no_action = 7;
				comp_text = 7;
				date_range1 = 12;
				date_range2 = 13;
				category_id = 7;
				count_label = 45;

			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{


			bTryinToUnload = false;

			bFormFilling = true;
			cmd_Stop.Visible = false;

			//Call CenterForm32(Me)
			modCommon.CenterFormOnHomebaseMainForm(this);

			cmd_ClearNoChange.Visible = false;

			// LOAD THE LIST OF ACCOUNT REPS INTO THE CBO
			b_updateFlag = true;

			Load_Account_Rep_List();

			b_updateFlag = false;

			SSTabHelper.SetSelectedIndex(tab_NewAvail, 2);
			SSTabHelper.SetTabVisible(tab_NewAvail, 0, false);
			//  tab_NewAvail.TabVisible(3) = False   ' added MSW - 6/1/21   ' commented out so that it shows - msw - 12/10/21


			// added MSW - 3/25/21
			if (cbo_pub[6].Text.Trim() == "")
			{
				cbo_pub[6].Items.Clear();
				cbo_pub[6].AddItem("Pub");
				cbo_pub[6].AddItem("Memo");
				cbo_pub[6].AddItem("Doc Request");

				cbo_pub[7].Items.Clear();
				cbo_pub[7].AddItem("Pub");
				cbo_pub[7].AddItem("Doc Request");
				cbo_pub[7].AddItem("Memo"); // added back in msw - 10/26/23
				cbo_pub[7].AddItem("All");

				cbo_pub[9].Items.Clear();
				cbo_pub[9].AddItem("Memo");
				cbo_pub[9].Text = "Memo";


				// THIS COULD BE RE_DONE LATEr - MSW - 10/14/21 -
				if (modAdminCommon.gbl_User_ID == "cs" || modAdminCommon.gbl_User_ID == "edpb" || modAdminCommon.gbl_User_ID == "edpb")
				{
					cbo_pub[7].Text = "Pub";

					set_default_checks("Pub");
				}
				else if (modAdminCommon.gbl_User_ID == "brw" || modAdminCommon.gbl_User_ID == "tjr" || modAdminCommon.gbl_User_ID == "mah" || modAdminCommon.gbl_User_ID == "lm" || modAdminCommon.gbl_User_ID == "asb")
				{ 
					cbo_pub[7].Text = "Doc Request";

					set_default_checks("Doc Request");
				}
				else
				{

					cbo_pub[7].Text = "Pub";

					set_default_checks("Pub");
				}





			}



			if (cbo_pub[0].Text.Trim() == "")
			{

				load_correct_statuses("");

				Fill_AC_Status_Drop_Down(cbo_pub[status_drop], "");
				cbo_pub[status_drop].Text = "All";
				//Call fill_account_rep(cbo_pub(3))


				fill_account_rep(cbo_pub[0]);

			}


			// ***************************
			// SETUP THE DETAILS FRAME
			frame_Details.Visible = false;
			txt_publog_description.Enabled = false;
			txt_publog_reg_no.Enabled = false;
			txt_publog_ser_no.Enabled = false;
			txt_publog_Ac_id.Enabled = true;
			txt_publog_days.Text = "2";
			cbo_publog_picture.Items.Clear();
			cbo_publog_picture.AddItem("YES");
			cbo_publog_picture.AddItem("NO");
			cbo_publog_picture.SelectedIndex = 0;
			txt_publog_price.Text = "";
			txt_publog_aftt.Text = "";
			txt_publog_url.Text = "";
			txt_publog_seller_info.Text = "";
			txt_publog_entry_date.Text = "";
			txt_publog_update_date.Text = "";
			//txt_acct_rep = ""
			cbo_publog_acct_rep.SelectedIndex = 0;


			// CLEAR THE AIRCRAFT ID USED FOR IDENTIFICATION OF NEW AIRCRAFT ON LOAD
			New_Pub_AC_ID = 0;

			string CanProcess = $"{modCommon.DLookUp("user_process_pubs_flag", "[User]", $"User_id='{modAdminCommon.gbl_User_ID}'")}";

			if (CanProcess == "Y")
			{
				SSTabHelper.SetTabVisible(tab_NewAvail, 1, true);
			}
			else
			{
				SSTabHelper.SetTabVisible(tab_NewAvail, 1, false);
			}

			cmdClear.Enabled = false;
			cmd_ClearLeave.Enabled = false;

			// ******************************************************
			// FILL THE LIST OF WEB SITES THAT MAY BE SEARCHED
			// rtw - added ALM - ALMAC per lucias request on 9/29/09

			cbo_WebSite.Items.Clear();
			cbo_WebSite.AddItem("ASO - Aircraft Shopper Online");
			cbo_WebSite.AddItem("CON - Controller");
			cbo_WebSite.AddItem("TAP - Trade A Plane");
			cbo_WebSite.AddItem("AHL - Aviatiors Hot Line");
			cbo_WebSite.AddItem("AMP - Aircraft Market Place");
			cbo_WebSite.AddItem("AVB - AvBuyer");
			cbo_WebSite.AddItem("GAR - Global Air");
			cbo_WebSite.AddItem("GPS - Global Plane Search");
			cbo_WebSite.AddItem("TAP - Trade A Plane");
			cbo_WebSite.AddItem("PAR - Private Air");
			cbo_WebSite.AddItem("ALM - ALMAC Aviation.com");

			// added 12/13/2011 MSW - additional requested
			cbo_WebSite.AddItem("PLM - Planemart");
			cbo_WebSite.AddItem("FLM - Flightmarket");
			cbo_WebSite.AddItem("AVI - Avitop");
			cbo_WebSite.AddItem("PLS - Plane Sales");
			cbo_WebSite.AddItem("PLC - Plane Check");
			cbo_WebSite.AddItem("AVS - Aviator Sales");
			cbo_WebSite.AddItem("BUS - Business Air");
			cbo_WebSite.AddItem("TUA - TuAvion");
			cbo_WebSite.AddItem("ACM - Aircraft Mailer");
			cbo_WebSite.AddItem("ARS - Aero Sender");
			cbo_WebSite.AddItem("BPS - Buy Planes for Sale");
			cbo_WebSite.AddItem("CLF - Classifieds Aviation Advertiser");

			cbo_publog_source.Items.Clear();

			cbo_publog_source.AddItem("ACC - AERO Classifieds"); // added in MSW 8/19/14
			cbo_publog_source.AddItem("ACM - Aircraft Mailer");
			cbo_publog_source.AddItem("ALM - ALMAC Aviation.com");
			cbo_publog_source.AddItem("ASW - Aircraft Sales World"); // added in MSW 8/19/14

			cbo_publog_source.AddItem("AES - AERO Sending"); // added in MSW 8/19/14

			cbo_publog_source.AddItem("AHL - Aviatiors Hot Line");
			cbo_publog_source.AddItem("AMP - Aircraft Market Place");


			cbo_publog_source.AddItem("ARO - AERO Controller"); // added in MSW 8/19/14
			cbo_publog_source.AddItem("ART - AERO Trader"); // added in MSW 8/19/14

			cbo_publog_source.AddItem("ASO - Aircraft Shopper Online");

			cbo_publog_source.AddItem("AVB - AvBuyer");
			cbo_publog_source.AddItem("ARS - Aero Sender");
			cbo_publog_source.AddItem("AVC - Aviation Classified"); // added in MSW 8/19/14
			cbo_publog_source.AddItem("AVI - Avitop");
			cbo_publog_source.AddItem("AVS - Aviator Sales");
			cbo_publog_source.AddItem("AD - Aircraft Dealer"); // added in MSW 8/19/14

			cbo_publog_source.AddItem("BPS - Buy Planes for Sale");
			cbo_publog_source.AddItem("BUS - Business Air");
			cbo_publog_source.AddItem("CON - Controller");
			cbo_publog_source.AddItem("CLF - Classifieds Aviation Advertiser");
			cbo_publog_source.AddItem("FIP - Flight Planet"); // added in MSW 8/19/14
			cbo_publog_source.AddItem("FLM - Flightmarket");
			cbo_publog_source.AddItem("GAR - Global Air");
			cbo_publog_source.AddItem("GEN - Generic"); // added in MSW 8/19/14
			cbo_publog_source.AddItem("GPS - Global Plane Search");

			cbo_publog_source.AddItem("LED - Leaders Aviation"); // added in MSW 8/19/14
			cbo_publog_source.AddItem("PAR - Private Air");
			cbo_publog_source.AddItem("PLC - Plane Check");
			cbo_publog_source.AddItem("PLM - Planemart");
			cbo_publog_source.AddItem("PLS - Plane Sales");
			cbo_publog_source.AddItem("TAP - Trade A Plane");
			cbo_publog_source.AddItem("TUA - TuAvion");


			// added 12/13/2011 MSW - additional requested



			// turn these on- make them visible - MSW 0 11/22/23
			// these are update account rep items
			cmd_pub[17].Visible = false;
			cbo_pub[11].Visible = false;
			lbl_gen[23].Visible = false;

			if (cbo_pub[11].Items.Count == 0)
			{
				modFillCompConControls.Fill_AccountRep_FromArray(cbo_pub[11], true, false);
			}


			cbo_publog_source.SelectedIndex = 0;

			// IF THE USER ENTERING THE FORM HAS AN ACCOUNT REP ASSIGNED
			// THEN AUTOMATICALLY SELECT AND LOAD THEIR NEW AVAILABLES

			if (modAdminCommon.gbl_User_ID.Trim().ToLower() == "jac" || modAdminCommon.gbl_User_ID.Trim().ToLower() == "jkc")
			{
				cbo_ACREP.SelectedIndex = 0;
			}
			else if (WhichAcctRep != "")
			{ 
				int tempForEndVar = cbo_ACREP.Items.Count - 1;
				for (int i = 0; i <= tempForEndVar; i++)
				{
					if (cbo_ACREP.GetListItem(i).Trim().ToLower() == WhichAcctRep.Trim().ToLower())
					{
						cbo_ACREP.SelectedIndex = i;
						break;
					}
				}
			}
			else if (Strings.Len(modAdminCommon.gbl_Account_ID.Trim()) > 0)
			{ 
				Select_Rep();
			}

			// added MSW - 10/14/21
			if (cbo_ACREP.Text.Trim().StartsWith("DB", StringComparison.Ordinal))
			{
				cbo_pub[7].Text = "Pub";
			}


			// added MSW - 11/3/23
			Fill_Find_Customer_Submitted_Data_Grid();

			WhichAcctRep = "";

			txt_EMailAddress.Text = ($"{modCommon.DLookUp("aconfig_email_pubs", "Application_Configuration")}").Trim();

			if (modAdminCommon.gbl_User_ID.ToLower() == "mvit")
			{
				txt_EMailAddress.Text = "rick@mvintech.com";
			}

			bFormFilling = false;

		} // Form_Load


		private void Get_New_Pubs_Header()
		{

			grd_NewAvail.Visible = true;
			grd_NewAvail.Enabled = true;
			grd_NewAvail.Redraw = true;

			grd_NewAvail.Clear();

			grd_NewAvail.RowsCount = 2;
			grd_NewAvail.ColumnsCount = 24;

			grd_NewAvail.FixedColumns = 0;
			grd_NewAvail.FixedRows = 0;

			// Key
			// 0=Pub
			// 1=Rep
			// 2=Pub Pic
			// 3=Our Pic
			// 4=AF
			// 5=Pub Desc
			// 6=Our Desc
			// 7=Pub Reg
			// 8=Our Reg
			// 9=Pub Serial
			// 10=Our Serial
			// 11=Pub Price
			// 12=Our Price
			// 13=Pub AFTT
			// 14=Our AFTT
			// 15=Date Added
			// 16=A/C ID
			// 17=To Spec
			// 18=Date Cleared  ' publog_entry_date desc
			// 19=Advertiser
			// 20=Homebase Primary
			// 21=Date Listed
			// 22=UserId
			// 23=Date Updated

			grd_NewAvail.CurrentRowIndex = 0;

			grd_NewAvail.SetColumnWidth(0, 40);
			grd_NewAvail.CurrentColumnIndex = 0;
			grd_NewAvail.ColAlignment[0] = DataGridViewContentAlignment.TopCenter;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Pub";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(1, 47);
			grd_NewAvail.CurrentColumnIndex = 1;
			grd_NewAvail.ColAlignment[1] = DataGridViewContentAlignment.TopCenter;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Rep";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(2, 53);
			grd_NewAvail.CurrentColumnIndex = 2;
			grd_NewAvail.ColAlignment[2] = DataGridViewContentAlignment.TopCenter;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Pub Pic";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(3, 53);
			grd_NewAvail.CurrentColumnIndex = 3;
			grd_NewAvail.ColAlignment[3] = DataGridViewContentAlignment.TopCenter;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Our Pic";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			//airframe type aey 6/27/05
			grd_NewAvail.SetColumnWidth(4, 33);
			grd_NewAvail.CurrentColumnIndex = 4;
			grd_NewAvail.ColAlignment[4] = DataGridViewContentAlignment.TopCenter;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "AF";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(5, 173);
			grd_NewAvail.CurrentColumnIndex = 5;
			grd_NewAvail.ColAlignment[5] = DataGridViewContentAlignment.TopLeft;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Pub Description";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(6, 173);
			grd_NewAvail.CurrentColumnIndex = 6;
			grd_NewAvail.ColAlignment[6] = DataGridViewContentAlignment.TopLeft;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Our Description";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(7, 60);
			grd_NewAvail.CurrentColumnIndex = 7;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Pub Reg";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(8, 60);
			grd_NewAvail.CurrentColumnIndex = 8;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Our Reg";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(9, 73);
			grd_NewAvail.CurrentColumnIndex = 9;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Pub Serial";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(10, 73);
			grd_NewAvail.CurrentColumnIndex = 10;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Our Serial";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(11, 67);
			grd_NewAvail.CurrentColumnIndex = 11;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Pub Price";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(12, 67);
			grd_NewAvail.CurrentColumnIndex = 12;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Our Price";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(13, 63);
			grd_NewAvail.CurrentColumnIndex = 13;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Pub AFTT";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(14, 60);
			grd_NewAvail.CurrentColumnIndex = 14;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Our AFTT";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(15, 107);
			grd_NewAvail.CurrentColumnIndex = 15;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Date Added";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(16, 53);
			grd_NewAvail.CurrentColumnIndex = 16;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "A/C ID";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(17, 73);
			grd_NewAvail.CurrentColumnIndex = 17;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "To Spec";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(18, 83);
			grd_NewAvail.CurrentColumnIndex = 18;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Date Cleared";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(19, 147);
			grd_NewAvail.CurrentColumnIndex = 19;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Advertiser";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(20, 147);
			grd_NewAvail.CurrentColumnIndex = 20;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Homebase Primary";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(21, 73);
			grd_NewAvail.CurrentColumnIndex = 21;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "List Date";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(22, 47);
			grd_NewAvail.CurrentColumnIndex = 22;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "UserId";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.SetColumnWidth(23, 117);
			grd_NewAvail.CurrentColumnIndex = 23;
			grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "Update Date";
			grd_NewAvail.CellFontBold = true;
			grd_NewAvail.CellBackColor = grd_NewAvail.BackColorFixed;

			grd_NewAvail.FixedColumns = 0;
			grd_NewAvail.FixedRows = 1;

			grd_NewAvail.CurrentRowIndex = 1;
			grd_NewAvail.CurrentColumnIndex = 0;

			grd_NewAvail.Refresh();

			Application.DoEvents();

			grd_NewAvail.Enabled = false;
			grd_NewAvail.Redraw = false;

		} // Get_New_Pubs_Header

		private void Get_New_Pubs(string strPub = "")
		{
			string[] arrChanges = null;
			bool bTryingToUnload = false;

			string errMsg = "";
			try
			{

				StopStatus = false;
				cmd_Stop.Visible = true;
				string tmpAdvertiser = ""; // USED TO FORMAT THE ADVERTISER FOR DISPLAY
				string Query = "";
				int Total_Availables = 0;
				string BackColor_Renamed = "";
				string CompareString = "";
				string CompareString2 = "";
				bool AircraftChange_Flag = false; // IDENTIFIES IF THERE IS AN IMPORTANT CHANGE FROM THE LOG TO THE AIRCRAFT IN HOMEBASE

				int loadrecs = 0;
				ADORecordSetHelper ADO_ACDups = new ADORecordSetHelper();

				bool IsDupAcID = false;
				bool IsBadRecord = false;
				bool IsFlaggedSerial = false;
				bool IsFlaggedRegNo = false;
				int TotRecs = 0;
				int iPos1 = 0;
				int lCnt1 = 0;
				int lRow1 = 0;

				bGridFilling = true;

				// If grd_NewAvail.Enabled = True Then

				errMsg = "init";
				gblCleared = false;
				mnuViewSelectedPub.Enabled = false;

				if (chkShowCleared.CheckState == CheckState.Checked)
				{
					errMsg = "cleared";
					gblCleared = true;

					if (!Information.IsNumeric(txt_publog_days.Text.Trim()))
					{
						txt_publog_days.Text = "2";
					}

				}

				errMsg = "frame";
				frame_Details.Visible = false;

				this.Cursor = Cursors.WaitCursor;
				cmdRefresh.Enabled = false;

				Total_Availables = 0;
				cmdClear.Enabled = false;
				cmd_ClearLeave.Enabled = false;
				lbl_Status.Text = "Loading Pubs .....";
				Application.DoEvents();

				errMsg = "grid";

				Get_New_Pubs_Header();




				if (cbo_ACREP.Text.Trim() == "All" || cbo_ACREP.Text.Trim() == "PUB01" || cbo_ACREP.Text.Trim() == "PUB02")
				{
					chk_include[in_progress].CheckState = CheckState.Unchecked;
					fill_ac_new_pub_search("", grd_pub);
				}
				else
				{
					cbo_pub[7].Text = "All";
					fill_ac_new_pub_search("top1", grd_pub);
				}

				// added MSW - 10/14/21
				if (cbo_ACREP.Text.Trim().StartsWith("DB", StringComparison.Ordinal))
				{
					cbo_pub[7].Text = "Pub";
				}


				Query = "SELECT Publication_Log.*, Aircraft.*, Aircraft_Model.*,  (SELECT TOP 1 comp_name FROM Company WITH (NOLOCK) ";
				Query = $"{Query} INNER JOIN Aircraft_Reference WITH (NOLOCK) ON comp_id = cref_comp_id and comp_journ_id = cref_journ_id ";
				Query = $"{Query} WHERE (cref_ac_id = publog_ac_id)  AND (cref_journ_id = 0)  AND (cref_primary_poc_flag='Y') ";
				Query = $"{Query}) As PrimaryPOC ";

				Query = $"{Query}FROM Publication_Log WITH (NOLOCK) ";
				Query = $"{Query}INNER JOIN Aircraft ON ac_id = publog_ac_id and ac_journ_id = 0 ";
				Query = $"{Query}INNER JOIN Aircraft_Model ON ac_amod_id = amod_id ";

				if (chkShowCleared.CheckState == CheckState.Checked)
				{
					// Date Formatting
					// https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.90).aspx
					Query = $"{Query}WHERE (publog_clear_date >= '{DateTime.Today.AddDays(Double.Parse($"-{(Double.Parse($"0{txt_publog_days.Text}") - 1).ToString()}")).ToString("yyyy/MM/dd")}') ";
				}
				else
				{
					Query = $"{Query}WHERE (publog_clear_date IS NULL) ";
				}

				if (cbo_ACREP.Text.Trim().ToUpper() != "ALL")
				{
					Query = $"{Query}AND (publog_acct_rep = '{cbo_ACREP.Text.Trim()}') ";
				}

				if (Strings.Len(txt_Serialno_Search.Text.Trim()) > 0)
				{
					Query = $"{Query}AND (publog_ser_no LIKE '%{txt_Serialno_Search.Text}%') ";
				}

				if (Strings.Len(txt_Regno_Search.Text.Trim()) > 0)
				{
					Query = $"{Query}AND (publog_reg_no LIKE '%{txt_Regno_Search.Text}%') ";
				}

				if (strPub != "")
				{
					Query = $"{Query}AND (publog_source = '{strPub}') ";
				}

				if (gblOrderBy.Trim() != "")
				{
					if (gblOrderBy.Trim() == "ORDER BY publog_entry_date")
					{
						gblOrderBy = "ORDER BY publog_entry_date desc";
					}
					Query = $"{Query} {gblOrderBy}";
				}
				else
				{
					Query = $"{Query} ORDER BY publog_description,publog_source";
				}

				if (NewRecs != null)
				{
					if (NewRecs.State == ConnectionState.Open)
					{
						NewRecs.Close();
					}
					NewRecs = null;
				}

				// SET LIST OF PUBS TO CLEAR TO NOTHING
				PubsToClear = new int[1];
				cmd_ClearNoChange.Visible = false;
				errMsg = "recordset";
				loadrecs = 0;

				NewRecs = new ADORecordSetHelper();
				NewRecs.CursorLocation = CursorLocationEnum.adUseClient;
				NewRecs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!NewRecs.BOF && !NewRecs.EOF)
				{

					grd_NewAvail.Visible = true;
					grd_NewAvail.Enabled = false;
					grd_NewAvail.Redraw = false;

					TotRecs = NewRecs.RecordCount;
					lCnt1 = 0;
					lRow1 = 0;

					do 
					{ // Loop Until NewRecs.EOF = True Or StopStatus = True Or bTryingToUnload = True

						// RTW - ADDED 5/15/07 TO IDENTIFY IF ANY CHANGE IN LINE
						AircraftChange_Flag = false;
						loadrecs++;

						lCnt1++;
						lRow1++;

						grd_NewAvail.RowsCount = lRow1 + 1;
						grd_NewAvail.CurrentRowIndex = lRow1;

						IsFlaggedSerial = false;
						IsFlaggedRegNo = false;
						errMsg = "split";
						arrChanges = ($"{Convert.ToString(NewRecs["publog_latest_change"])}").Trim().Split('~');

						// ************************************************
						// MAKE THE BACKGROUND CELL COLOR WHITE IF THE AIRCRAFT IN
						// HOMEBASE IS NOT FOR SALE
						if (($"{Convert.ToString(NewRecs["ac_forsale_flag"])}").Trim() == "Y")
						{
							BackColor_Renamed = modAdminCommon.ForSaleColor;
						}
						else
						{
							BackColor_Renamed = ColorTranslator.ToOle(Color.White).ToString();
						}

						//SOURCE
						grd_NewAvail.CurrentColumnIndex = 0;
						grd_NewAvail.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = NewRecs.GetField("publog_source");
						if (BackColor_Renamed != ColorTranslator.ToOle(Color.White).ToString() && BackColor_Renamed != modAdminCommon.ForSaleColor)
						{
							MessageBox.Show("WHAT", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));

						// ACCT REP
						grd_NewAvail.CurrentColumnIndex = 1;
						grd_NewAvail.ColAlignment[1] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($"{Convert.ToString(NewRecs["publog_acct_rep"])}").Trim();
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));
						if (($"{Convert.ToString(NewRecs["publog_acct_rep"])}").Trim() == "SPEC")
						{
							//DON'T MARK PUBS ASSIGNED TO SPEC ENTRY FOR REMOVAL
							AircraftChange_Flag = true;
						}

						// PUB PICTURE
						grd_NewAvail.CurrentColumnIndex = 2;
						grd_NewAvail.ColAlignment[2] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($" {Convert.ToString(NewRecs["publog_picture"])}").Trim();
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));
						CompareString = grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString(); // store picture status for compare

						// OUR PICTURE
						grd_NewAvail.CurrentColumnIndex = 3;
						grd_NewAvail.ColAlignment[3] = DataGridViewContentAlignment.TopLeft;
						if (modCommon.HasPictures(Convert.ToInt32(Double.Parse(($"{Convert.ToString(NewRecs["publog_ac_id"])}").Trim())), 0, "N"))
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "YES";
						}
						else
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "NO";
						}
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));

						// IF THE PICTURE STATUS IS DIFFERENT THEN COLOR THE PUB
						// PICTURE COLUMN RED
						if (CompareString != grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString().Trim() && Strings.Len(CompareString.Trim()) > 0)
						{
							grd_NewAvail.CurrentColumnIndex = 2;
							grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
							AircraftChange_Flag = true;
						}

						//airframe type
						grd_NewAvail.CurrentColumnIndex = 4;
						grd_NewAvail.ColAlignment[4] = DataGridViewContentAlignment.TopLeft;
						if (Convert.ToString(NewRecs["amod_airframe_type_code"]) == "F")
						{
							grd_NewAvail.CellPicture = pic_redx[1].Image;
						}
						else
						{
							grd_NewAvail.CellPicture = pic_redx[2].Image;
						}

						// PUB DESCRIPTION
						grd_NewAvail.CurrentColumnIndex = 5;
						grd_NewAvail.ColAlignment[5] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail.CellFontUnderline = true;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($" {Convert.ToString(NewRecs["publog_description"])}").Trim();
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));

						// OUR DESCRIPTION
						grd_NewAvail.CurrentColumnIndex = 6;
						grd_NewAvail.ColAlignment[6] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = $"{($" {Convert.ToString(NewRecs["ac_year"])}").Trim()} {($" {Convert.ToString(NewRecs["amod_make_name"])}").Trim()}-{($" {Convert.ToString(NewRecs["amod_model_name"])}").Trim()}";
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));
						if (Convert.ToString(NewRecs["amod_airframe_type_code"]) == "R" && Convert.ToString(NewRecs["amod_class_code"]) == "C")
						{
							grd_NewAvail.CellBackColor = SystemColors.Control; //grey
						}
						if (Convert.ToString(NewRecs["amod_airframe_type_code"]) == "R" && Convert.ToString(NewRecs["amod_class_code"]) == "B")
						{
							grd_NewAvail.CellBackColor = Color.FromArgb(255, 128, 255); //purple
						}

						// PUB REG_NO
						grd_NewAvail.CurrentColumnIndex = 7;
						grd_NewAvail.ColAlignment[7] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($" {Convert.ToString(NewRecs["publog_reg_no"])}").Trim();
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));
						CompareString = grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString();

						// OUR REG_NO
						grd_NewAvail.CurrentColumnIndex = 8;
						grd_NewAvail.ColAlignment[8] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($" {Convert.ToString(NewRecs["ac_reg_no"])}").Trim();
						// IF THE REG NO IS DIFFERENT THEN COLOR THE PUB
						// REG NO COLUMN RED
						if (CompareString != grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString().Trim() && $"N{CompareString}" != grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString().Trim() && Strings.Len(CompareString.Trim()) > 0)
						{
							grd_NewAvail.CurrentColumnIndex = 7;
							grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
							IsFlaggedRegNo = true;
							AircraftChange_Flag = true;
						}

						// PUB SER_NO
						grd_NewAvail.CurrentColumnIndex = 9;
						grd_NewAvail.ColAlignment[9] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($" {Convert.ToString(NewRecs["publog_ser_no"])}").Trim();
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));
						CompareString = grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString();

						// OUR SER_NO
						grd_NewAvail.CurrentColumnIndex = 10;
						grd_NewAvail.ColAlignment[10] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($" {Convert.ToString(NewRecs["ac_ser_no_full"])}").Trim();
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));
						// IF THE SER NO IS DIFFERENT THEN COLOR THE PUB
						// SER NO COLUMN RED

						if (StringsHelper.Replace(CompareString, "-", "", 1, -1, CompareMethod.Binary) != StringsHelper.Replace(grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString().Trim(), "-", "", 1, -1, CompareMethod.Binary) && Strings.Len(CompareString.Trim()) > 0)
						{
							grd_NewAvail.CurrentColumnIndex = 9;
							grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
							IsFlaggedSerial = true;
							AircraftChange_Flag = true;
						}

						// PUB PRICE
						grd_NewAvail.CurrentColumnIndex = 11;
						grd_NewAvail.ColAlignment[11] = DataGridViewContentAlignment.TopLeft;
						//grd_NewAvail.Text = Trim(" " & NewRecs!publog_price)
						if (Information.IsNumeric(NewRecs["publog_price"]))
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = $"${Strings.FormatNumber(($" {Convert.ToString(NewRecs["publog_price"])}").Trim(), 0, TriState.False, TriState.False, TriState.True)}";
						}
						else
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($" {Convert.ToString(NewRecs["publog_price"])}").Trim();
						}
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));
						CompareString = grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString();


						// OUR PRICE
						grd_NewAvail.CurrentColumnIndex = 12;
						grd_NewAvail.ColAlignment[12] = DataGridViewContentAlignment.TopLeft;
						if (($" {Convert.ToString(NewRecs["ac_asking_price"])}").Trim() != "")
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = $"${Strings.FormatNumber(($" {Convert.ToString(NewRecs["ac_asking_price"])}").Trim(), 0, TriState.False, TriState.False, TriState.True)}";
						}
						else
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = "";
						}
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));
						// IF THE PRICE IS DIFFERENT THEN COLOR THE PUB
						// PRICE COLUMN RED
						if (CompareString != grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString().Trim() && CompareString.Trim() != "CALL" && CompareString.Trim() != "INQUIRE" && Strings.Len(CompareString.Trim()) > 0)
						{
							grd_NewAvail.CurrentColumnIndex = 11;
							grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
							AircraftChange_Flag = true;
						}

						// PUB AFTT
						grd_NewAvail.CurrentColumnIndex = 13;
						grd_NewAvail.ColAlignment[13] = DataGridViewContentAlignment.TopLeft;

						if (Information.IsNumeric(($" {Convert.ToString(NewRecs["publog_aftt"])}").Trim()))
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = Strings.FormatNumber(($"{Convert.ToString(NewRecs["publog_aftt"])}").Trim(), 0, TriState.False, TriState.False, TriState.True);
						}
						else
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($"{Convert.ToString(NewRecs["publog_aftt"])}").Trim();
						}
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));
						CompareString = StringsHelper.Replace(grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString(), ",", "", 1, -1, CompareMethod.Binary);

						// OUR AFTT
						grd_NewAvail.CurrentColumnIndex = 14;
						grd_NewAvail.ColAlignment[14] = DataGridViewContentAlignment.TopLeft;

						if (Information.IsNumeric(($"{Convert.ToString(NewRecs["ac_airframe_tot_hrs"])}").Trim()))
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = Strings.FormatNumber(($"{Convert.ToString(NewRecs["ac_airframe_tot_hrs"])}").Trim(), 0, TriState.False, TriState.False, TriState.True);
						}
						else
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($"{Convert.ToString(NewRecs["ac_airframe_tot_hrs"])}").Trim();
						}

						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));
						// IF THE AFTT IS DIFFERENT THEN COLOR THE PUB
						// AFTT COLUMN RED
						if (CompareString != StringsHelper.Replace(grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString().Trim(), ",", "", 1, -1, CompareMethod.Binary) && Strings.Len(CompareString.Trim()) > 0)
						{

							if (Information.IsNumeric(CompareString) && Information.IsNumeric(StringsHelper.Replace(grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString().Trim(), ",", "", 1, -1, CompareMethod.Binary)))
							{

								if (Math.Abs(Conversion.Val(CompareString) - Conversion.Val(StringsHelper.Replace(grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].FormattedValue.ToString().Trim(), ",", "", 1, -1, CompareMethod.Binary))) <= 10)
								{
									grd_NewAvail.CurrentColumnIndex = 13;
									grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));
								}
								else
								{
									grd_NewAvail.CurrentColumnIndex = 13;
									grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
									AircraftChange_Flag = true;
								}
							}
							else
							{
								grd_NewAvail.CurrentColumnIndex = 13;
								grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
								AircraftChange_Flag = true;
							}

						}

						// DATE ADDED
						grd_NewAvail.CurrentColumnIndex = 15;
						grd_NewAvail.ColAlignment[15] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = StringsHelper.Format(($"{Convert.ToString(NewRecs["publog_entry_date"])}").Trim(), "mm/dd/yy HH:NN AM/PM");
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));

						// AC_ID
						grd_NewAvail.CurrentColumnIndex = 16;
						grd_NewAvail.ColAlignment[16] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = NewRecs.GetField("publog_ac_id");
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));

						// *********************************************
						// LATEST CHANGE DATE - TO SPEC
						grd_NewAvail.CurrentColumnIndex = 17;
						grd_NewAvail.ColAlignment[17] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($"{Convert.ToString(NewRecs["publog_latest_change"])} ").Trim();
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));
						IsBadRecord = false;

						grd_NewAvail.CurrentColumnIndex = 18;
						grd_NewAvail.ColAlignment[18] = DataGridViewContentAlignment.TopLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(NewRecs["publog_entry_date"]))
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = Convert.ToDateTime(NewRecs["publog_entry_date"]).ToString("MM/dd/yyyy");
						}
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));

						tmpAdvertiser = ($"{Convert.ToString(NewRecs["publog_seller_info"])} ").Trim();
						iPos1 = (tmpAdvertiser.IndexOf(Environment.NewLine) + 1);
						if (iPos1 > 0)
						{
							tmpAdvertiser = tmpAdvertiser.Substring(0, Math.Min(iPos1 - 1, tmpAdvertiser.Length));
						}

						grd_NewAvail.CurrentColumnIndex = 19;
						grd_NewAvail.ColAlignment[19] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = tmpAdvertiser;
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));

						grd_NewAvail.CurrentColumnIndex = 20;
						grd_NewAvail.ColAlignment[20] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($"{Convert.ToString(NewRecs["PrimaryPOC"])} ").Trim();
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));

						grd_NewAvail.CurrentColumnIndex = 21;
						grd_NewAvail.ColAlignment[21] = DataGridViewContentAlignment.TopLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(NewRecs["ac_list_date"]))
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = Convert.ToDateTime(NewRecs["ac_list_date"]).ToString("MM/dd/yyyy");
						}
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));

						grd_NewAvail.CurrentColumnIndex = 22;
						grd_NewAvail.ColAlignment[22] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($"{Convert.ToString(NewRecs["publog_user_id"])} ").Trim();
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));

						grd_NewAvail.CurrentColumnIndex = 23;
						grd_NewAvail.ColAlignment[23] = DataGridViewContentAlignment.TopLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(NewRecs["publog_update_date"]))
						{
							grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = StringsHelper.Format(NewRecs["publog_update_date"], "mm/dd/yyyy hh:MM AMPM");
						}
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));

						IsBadRecord = false;

						// ====================================================================
						// RTW - 5/15/07 - IF NOTHING IS CHANGED ON THE LINE THEN MARK THE LINE
						// AND ADD TO THE LIST OF PUBS TO CLEAR IN ARRAY
						if (!AircraftChange_Flag && ($"{Convert.ToString(NewRecs["ac_forsale_flag"])}").Trim() == "Y")
						{
							PubsToClear[PubsToClear.GetUpperBound(0)] = Convert.ToInt32(NewRecs["Publog_id"]);
							PubsToClear = ArraysHelper.RedimPreserve(PubsToClear, new int[]{PubsToClear.GetUpperBound(0) + 2});

							grd_NewAvail.CurrentColumnIndex = 0;
							grd_NewAvail.CellFontBold = true;
							grd_NewAvail.CurrentColumnIndex = 6;
							grd_NewAvail.CellFontBold = true;
						}

						IsDupAcID = false;

						if (!IsBadRecord)
						{

							Query = $"SELECT * FROM Publication_Log WITH (NOLOCK) WHERE (publog_entry_date >= '{DateTimeHelper.ToString(DateTime.Parse(modAdminCommon.DateToday).AddDays(-30))}') ";
							Query = $"{Query}AND (Publog_ac_id ={Convert.ToString(NewRecs["publog_ac_id"])})  AND (publog_source ='{((Convert.ToString(NewRecs["publog_source"]) == "ASO") ? "CON" : "ASO")}') ";
							Query = $"{Query}AND (publog_id <> {Convert.ToString(NewRecs["Publog_id"])}) ";

							ADO_ACDups.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							if (!ADO_ACDups.BOF && !ADO_ACDups.EOF)
							{

								do 
								{ // Loop Until ADO_ACDups.EOF = True Or IsDupAcID = False Or bTryingToUnload = True

									CompareString = ($"{StringsHelper.Replace(StringsHelper.Replace($"{Convert.ToString(NewRecs["publog_price"])}", ",", "", 1, -1, CompareMethod.Binary), "$", "", 1, -1, CompareMethod.Binary)}").Trim();
									CompareString2 = ($"{StringsHelper.Replace(StringsHelper.Replace($"{Convert.ToString(ADO_ACDups["publog_price"])}", ",", "", 1, -1, CompareMethod.Binary), "$", "", 1, -1, CompareMethod.Binary)}").Trim();
									CompareString = ($"{StringsHelper.Replace(StringsHelper.Replace(CompareString, "INQUIRE", "", 1, -1, CompareMethod.Binary), "CALL", "", 1, -1, CompareMethod.Binary)}").Trim();
									CompareString2 = ($"{StringsHelper.Replace(StringsHelper.Replace(CompareString2, "INQUIRE", "", 1, -1, CompareMethod.Binary), "CALL", "", 1, -1, CompareMethod.Binary)}").Trim();

									IsDupAcID = false;
									if (($"{Convert.ToString(NewRecs["publog_picture"])}").Trim() == ($"{Convert.ToString(ADO_ACDups["publog_picture"])}").Trim() && (($"{Convert.ToString(NewRecs["publog_reg_no"])}").Trim() == ($"{Convert.ToString(ADO_ACDups["publog_reg_no"])}").Trim() || ($"N{Convert.ToString(NewRecs["publog_reg_no"])}").Trim() == ($"{Convert.ToString(ADO_ACDups["publog_reg_no"])}").Trim() || ($"{Convert.ToString(NewRecs["publog_reg_no"])}").Trim() == ($"N{Convert.ToString(ADO_ACDups["publog_reg_no"])}").Trim()) && ($"{Convert.ToString(NewRecs["publog_ser_no"])}").Trim() == ($"{Convert.ToString(ADO_ACDups["publog_ser_no"])}").Trim() && ($"{StringsHelper.Replace($"{Convert.ToString(NewRecs["publog_aftt"])}", ",", "", 1, -1, CompareMethod.Binary)}").Trim() == ($"{StringsHelper.Replace($"{Convert.ToString(ADO_ACDups["publog_aftt"])}", ",", "", 1, -1, CompareMethod.Binary)}").Trim() && CompareString == CompareString2)
									{

										IsDupAcID = true;

									}

									ADO_ACDups.MoveNext();
									Application.DoEvents();

								}
								while(!(ADO_ACDups.EOF || !IsDupAcID || bTryingToUnload));

							} // If (ADO_ACDups.BOF = False And ADO_ACDups.EOF = False) Then

							ADO_ACDups.Close();

						} // If IsBadRecord = False Then

						if (IsDupAcID)
						{
							grd_NewAvail.CurrentColumnIndex = 0;
							grd_NewAvail.CellBackColor = SystemColors.AppWorkspace;
						}

						// DATE CLEARED
						grd_NewAvail.CurrentColumnIndex = 18;
						grd_NewAvail.ColAlignment[18] = DataGridViewContentAlignment.TopLeft;
						grd_NewAvail[grd_NewAvail.CurrentRowIndex, grd_NewAvail.CurrentColumnIndex].Value = ($"{Convert.ToString(NewRecs["publog_clear_date"])}").Trim();
						grd_NewAvail.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(BackColor_Renamed)));

						grd_NewAvail.set_RowData(grd_NewAvail.CurrentRowIndex, Convert.ToInt32(NewRecs["Publog_id"].ToString().Trim()));
						//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_NewAvail.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						grd_NewAvail.setBandData(Convert.ToInt32(Double.Parse(($"{Convert.ToString(NewRecs["publog_ac_id"])}").Trim())), grd_NewAvail.CurrentRowIndex);

						lbl_Status.Text = $"Loading Pub {loadrecs.ToString()} of {TotRecs.ToString()} .....";

						if (lCnt1 == 21)
						{
							grd_NewAvail.Enabled = true;
							grd_NewAvail.Redraw = true;
							grd_NewAvail.CurrentColumnIndex = 0;
							grd_NewAvail.ColSel = 0;
							grd_NewAvail.Refresh();
							Application.DoEvents();
							grd_NewAvail.Redraw = false;
							grd_NewAvail.Enabled = false;
						}

						NewRecs.MoveNext();
						Application.DoEvents();

					}
					while(!(NewRecs.EOF || StopStatus || bTryingToUnload));

					grd_NewAvail.Enabled = true;
				}
				else
				{
					grd_NewAvail[1, 5].Value = "No Pub Records Found";
					grd_NewAvail.Enabled = false;
				} // If (NewRecs.BOF = False And NewRecs.EOF = False) Then

				grd_NewAvail.Visible = true;
				grd_NewAvail.Redraw = true;
				grd_NewAvail.Refresh();

				errMsg = "endloop";

				this.Cursor = CursorHelper.CursorDefault;
				cmdRefresh.Enabled = true;
				grd_NewAvail.Enabled = true;

				//added, MSW - no count was showing - 2/29/216
				Total_Availables = loadrecs;

				lbl_Status.Text = $"Total of {Total_Availables.ToString()} Pubs Loaded.";
				cmd_Stop.Visible = false;
				Application.DoEvents();

				grd_NewAvail.Enabled = true;

				//End If ' If grd_NewAvail.Enabled = True Then

				bGridFilling = false;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Get_New_Pubs_Error: {errMsg} col:{grd_NewAvail.CurrentColumnIndex.ToString()} {excep.Message}");
				grd_NewAvail.Enabled = true;
				bGridFilling = false;
			}

		} // Get_New_Pubs

		public string RemoveAllMiscCharsAndUpShift(string strTemp)
		{
			string result = "";
			StringBuilder strResults = new StringBuilder();
			string strWork = strTemp;
			int iTest = 0;


			if (Strings.Len(strTemp) > 0)
			{
				strWork = strTemp.ToUpper();
				int tempForEndVar = Strings.Len(strTemp);
				for (int iZ1 = 1; iZ1 <= tempForEndVar; iZ1++)
				{
					iTest = Strings.Asc(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1))))[0]);
					if (((iTest >= 65) && (iTest <= 90)) || ((iTest >= 48) && (iTest <= 57)))
					{
						strResults.Append(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1)))));
					}
				}
			}
			else
			{
				strResults = new StringBuilder("");
			} // Len(strTemp) > 0

			return strResults.ToString();

		}

		private void Load_Account_Rep_List()
		{
			//----------------------------------------------------------------------------------------------
			//Function used to Display Account Rep List
			//----------------------------------------------------------------------------------------------

			modFillCompConControls.Fill_AccountRep_FromArray(cbo_ACREP, false, true);
			modFillCompConControls.Fill_AccountRep_FromArray(cbo_publog_acct_rep, false, true);

		}

		private void Select_Rep()
		{
			bool HadHourglass = false;
			//----------------------------------------------------------------------------------------------
			//Function used to select account rep
			//----------------------------------------------------------------------------------------------

			try
			{


				if (modAdminCommon.gbl_Account_ID != "")
				{
					int tempForEndVar = cbo_ACREP.Items.Count - 1;
					for (int i = 1; i <= tempForEndVar; i++)
					{
						if (modAdminCommon.gbl_Account_ID.Trim().ToLower() == cbo_ACREP.GetListItem(i).Trim().ToLower())
						{
							cbo_ACREP.SelectedIndex = i;
							break;
						}
					}
				}
				else
				{
					cbo_ACREP.SelectedIndex = 0;
				}
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				modAdminCommon.Report_Error($"Select_Rep_Error: {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private void Form_FormClosing(Object eventSender, FormClosingEventArgs eventArgs)
		{
			int Cancel = (eventArgs.Cancel) ? 1 : 0;
			int UnloadMode = (int) eventArgs.CloseReason;
			try
			{

				System.DateTime dtStartTime = DateTime.FromOADate(0);
				int lElapsedTime = 0;

				bTryinToUnload = true;

				if (bFormFilling || bGridFilling)
				{

					dtStartTime = DateTime.Now;
					lElapsedTime = 0;
					// Loop Until Both Fill Flags Are False Or 20 seconds
					do 
					{
						lElapsedTime = (int) DateAndTime.DateDiff("s", dtStartTime, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
						Application.DoEvents();
					}
					while(!((!bFormFilling && !bGridFilling) || lElapsedTime == 20));

				} // If bFormFilling = True Or bGridFilling = True Then
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}

		} // Form_QueryUnload

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			Form Form = null;

			foreach (Form FormIterator in Application.OpenForms)
			{
				Form = FormIterator;
				if (Form.Name == "frm_ActionList")
				{
					//UPGRADE_TODO: (1067) Member CheckForNewAvailables is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					(Form as frm_ActionList).CheckForNewAvailables();
					break;
				}
				//Form
				Form = default(Form);
			}

			NewRecs = null;

		}

		private void grd_NewAvail_Click(Object eventSender, EventArgs eventArgs)
		{


			string CanProcess = "";
			int lCol1 = 0;
			int lRow1 = 0;

			try
			{

				// msw 8/3/15 added  Or grd_NewAvail.RowData(0) = 0  so that when u click it didnt error
				if (grd_NewAvail.CurrentRowIndex == 0)
				{ //Or (grd_NewAvail.RowData(0) = 0 And grd_NewAvail.Row > 0)
					return;
				}


				if (NewRecs.RecordCount > 0)
				{

					lRow1 = grd_NewAvail.CurrentRowIndex;
					lCol1 = grd_NewAvail.CurrentColumnIndex;

					if (!gblCleared)
					{

						Edit_Status = "Update";

						cmdClear.Text = "Clear Pub";
						cmdClear.Enabled = true;
						cmd_ClearLeave.Enabled = true;
						AlignNewAvailRecordset(grd_NewAvail.CurrentRowIndex);

						txt_publog_description.Text = ($" {Convert.ToString(NewRecs["publog_description"])}").Trim();
						txt_publog_reg_no.Text = ($" {Convert.ToString(NewRecs["publog_reg_no"])}").Trim();
						txt_publog_ser_no.Text = ($" {Convert.ToString(NewRecs["publog_ser_no"])}").Trim();
						if (($" {Convert.ToString(NewRecs["publog_picture"])}").Trim() == "YES")
						{
							cbo_publog_picture.Text = "YES";
						}
						else
						{
							cbo_publog_picture.Text = "NO";
						}
						txt_publog_price.Text = ($" {Convert.ToString(NewRecs["publog_price"])}").Trim();
						txt_publog_aftt.Text = ($" {Convert.ToString(NewRecs["publog_aftt"])}").Trim();
						txt_publog_url.Text = ($" {Convert.ToString(NewRecs["publog_url"])}").Trim();
						txt_publog_Ac_id.Text = ($" {Convert.ToString(NewRecs["publog_ac_id"])}").Trim();
						txt_publog_seller_info.Text = ($" {Convert.ToString(NewRecs["publog_seller_info"])}").Trim();



						//txt_acct_rep.Text = grd_NewAvail.TextMatrix(grd_NewAvail.MouseRow, 1)
						int tempForEndVar = cbo_publog_acct_rep.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar; i++)
						{
							if (cbo_publog_acct_rep.GetListItem(i).Trim().ToLower() == Convert.ToString(grd_NewAvail[grd_NewAvail.MouseRow, 1].Value).Trim().ToLower())
							{
								cbo_publog_acct_rep.SelectedIndex = i;
								break;
							}
						}
						RememberAcctRep = cbo_publog_acct_rep.Text;

						int tempForEndVar2 = cbo_publog_source.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar2; i++)
						{
							if (cbo_publog_source.GetListItem(i).Substring(0, Math.Min(3, cbo_publog_source.GetListItem(i).Length)).ToUpper() == ($"{Convert.ToString(NewRecs["publog_source"])}").Trim().ToUpper())
							{
								cbo_publog_source.SelectedIndex = i;
								break;
							}
						}

						txt_publog_entry_date.Text = DateTime.Parse(($"{Convert.ToString(NewRecs["publog_entry_date"])}").Trim()).ToString("d");
						txt_publog_update_date.Text = DateTime.Parse(($"{Convert.ToString(NewRecs["publog_update_date"])}").Trim()).ToString("d");

						frame_Details.Visible = true;
						cmd_Save.Text = "Save";
						cmd_Save.Visible = true;

					}
					else
					{

						Edit_Status = "Update";

						CanProcess = $"{modCommon.DLookUp("user_process_pubs_flag", "[User]", $"User_id='{modAdminCommon.gbl_User_ID}'")}";

						if (CanProcess == "Y")
						{
							cmdClear.Text = "UnClear Pub";
							cmdClear.Enabled = true;
						}
						else
						{
							cmdClear.Enabled = false;
							cmd_ClearLeave.Enabled = false;
						}

						// ALIGN THE RECORDSET BASED ON THE GRID ROW SELECTED
						AlignNewAvailRecordset(grd_NewAvail.CurrentRowIndex);

						txt_publog_description.Text = ($" {Convert.ToString(NewRecs["publog_description"])}").Trim();
						txt_publog_reg_no.Text = ($" {Convert.ToString(NewRecs["publog_reg_no"])}").Trim();
						txt_publog_ser_no.Text = ($" {Convert.ToString(NewRecs["publog_ser_no"])}").Trim();
						if (($" {Convert.ToString(NewRecs["publog_picture"])}").Trim() == "YES")
						{
							cbo_publog_picture.Text = "YES";
						}
						else
						{
							cbo_publog_picture.Text = "NO";
						}
						txt_publog_price.Text = ($" {Convert.ToString(NewRecs["publog_price"])}").Trim();
						txt_publog_aftt.Text = ($" {Convert.ToString(NewRecs["publog_aftt"])}").Trim();

						txt_publog_url.Text = ($" {Convert.ToString(NewRecs["publog_url"])}").Trim();
						lblPubLink.Enabled = false;
						if (txt_publog_url.Text != "")
						{
							lblPubLink.Enabled = true;
						}

						lblPubLink.Enabled = false;
						if (txt_publog_url.Text != "")
						{
							lblPubLink.Enabled = true;
						}

						txt_publog_Ac_id.Text = ($" {Convert.ToString(NewRecs["publog_ac_id"])}").Trim();

						txt_publog_seller_info.Text = ($" {Convert.ToString(NewRecs["publog_seller_info"])}").Trim();

						//txt_acct_rep.Text = grd_NewAvail.TextMatrix(grd_NewAvail.MouseRow, 1)
						int tempForEndVar3 = cbo_publog_acct_rep.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar3; i++)
						{
							if (cbo_publog_acct_rep.GetListItem(i).Trim().ToLower() == Convert.ToString(grd_NewAvail[grd_NewAvail.MouseRow, 1].Value).Trim().ToLower())
							{
								cbo_publog_acct_rep.SelectedIndex = i;
								break;
							}
						}
						RememberAcctRep = cbo_publog_acct_rep.Text;

						int tempForEndVar4 = cbo_publog_source.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar4; i++)
						{
							if (cbo_publog_source.GetListItem(i).Substring(0, Math.Min(3, cbo_publog_source.GetListItem(i).Length)).ToUpper() == ($"{Convert.ToString(NewRecs["publog_source"])}").Trim().ToUpper())
							{
								cbo_publog_source.SelectedIndex = i;
								break;
							}
						}

						txt_publog_entry_date.Text = DateTime.Parse(($"{Convert.ToString(NewRecs["publog_entry_date"])}").Trim()).ToString("d");
						txt_publog_update_date.Text = DateTime.Parse(($"{Convert.ToString(NewRecs["publog_update_date"])}").Trim()).ToString("d");


						frame_Details.Visible = true;
						cmd_Save.Text = "Journal";
						cmd_Save.Visible = true;

					} // IF CLEARED PUB

					modCommon.Highlight_Grid_Row(grd_NewAvail);
					mnuViewSelectedPub.Enabled = true;

				}
				else
				{
					MessageBox.Show("No Pub Records Found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				} // If NewRecs.RecordCount > 0 Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"grd_NewAvail_Click_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_webCrawl(CLICK)");
			}

		} // grd_NewAvail_Click

		private void grd_NewAvail_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();

			int lRow = grd_NewAvail.MouseRow;
			int lCol = grd_NewAvail.MouseCol;

			if (grd_NewAvail.Enabled)
			{

				if (NewRecs.RecordCount > 0)
				{

					if (lRow > 0)
					{ // And grd_NewAvail.RowData(0) <> 0

						// IF THE USER IS ON THE COLUMN FOR THE MAKE/MODEL FROM THE EXTERNAL WEB SOURCE
						// THEN ALLOW THEM TO LAUNCH TO IT IN A SEPARATE WINDOW
						if (lCol == 5)
						{

							grd_NewAvail.Enabled = false;

							AlignNewAvailRecordset(lRow);

							if (Convert.ToString(NewRecs["publog_url"]).Trim() != "")
							{

								// 11/05/2013 - By David D. Cruger
								// The Form Will Select Which Browser To Use

								//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//VB.Global.Load(frm_WebReport.DefInstance);
								modCommon.CenterFormOnHomebaseMainForm(frm_WebReport.DefInstance);
								frm_WebReport.DefInstance.PassedFileName = Convert.ToString(NewRecs["publog_url"]).Trim();
								frm_WebReport.DefInstance.WhichReport = "View External Document";
								frm_WebReport.DefInstance.Show();

							}

							grd_NewAvail.Enabled = true;

						}
						else
						{

							AlignNewAvailRecordset(lRow);

							modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(($"{Convert.ToString(NewRecs["publog_ac_id"])}").Trim()));
							modAdminCommon.gbl_Aircraft_Journal_ID = 0;

							if (!modCommon.Is_Form_Already_Loaded("frm_Aircraft"))
							{
								//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//VB.Global.Load(frm_aircraft.DefInstance);
							}

							frm_aircraft.DefInstance.Form_Initialize();
							frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
							frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
							frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
							frm_aircraft.DefInstance.Reference_Company_ID = 0;
							frm_aircraft.DefInstance.Show();
							//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							Support.ZOrder(frm_aircraft.DefInstance, 0);
							//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

						}

					}
					else
					{
						// If lRow = 0 Then


						switch(lCol)
						{
							case 0 : 
								gblOrderBy = "ORDER BY publog_source"; 
								 
								break;
							case 1 : 
								gblOrderBy = "ORDER BY publog_acct_rep"; 
								 
								break;
							case 2 : 
								gblOrderBy = "ORDER BY publog_picture"; 
								 
								break;
							case 4 : 
								gblOrderBy = "ORDER BY amod_airframe_type_code"; 
								 
								break;
							case 5 : 
								gblOrderBy = "ORDER BY publog_description"; 
								 
								break;
							case 7 : 
								gblOrderBy = "ORDER BY publog_reg_no"; 
								 
								break;
							case 8 : 
								gblOrderBy = "ORDER BY ac_reg_no"; 
								 
								break;
							case 9 : 
								gblOrderBy = "ORDER BY publog_ser_no"; 
								 
								break;
							case 10 : 
								gblOrderBy = "ORDER BY ac_ser_no_sort"; 
								 
								break;
							case 11 : 
								gblOrderBy = "ORDER BY publog_price"; 
								break;
							case 12 : 
								gblOrderBy = "ORDER BY ac_asking_price"; 
								 
								break;
							case 13 : 
								gblOrderBy = "ORDER BY publog_aftt"; 
								 
								break;
							case 14 : 
								gblOrderBy = "ORDER BY ac_airframe_tot_hrs"; 
								 
								break;
							case 15 : 
								gblOrderBy = "ORDER BY publog_entry_date"; 
								 
								break;
							case 16 : 
								gblOrderBy = "ORDER BY publog_ac_id"; 
								 
								break;
							case 17 : 
								gblOrderBy = "ORDER BY publog_latest_change"; 
								 
								break;
							case 18 : 
								gblOrderBy = "ORDER BY publog_clear_date"; 
								 
								break;
							case 19 : 
								gblOrderBy = "ORDER BY publog_seller_info, ac_ser_no_sort"; 
								 
								break;
							case 20 : 
								gblOrderBy = "ORDER BY PrimaryPOC, ac_ser_no_sort"; 
								 
								break;
							case 21 : 
								gblOrderBy = "ORDER BY ac_list_date, ac_ser_no_sort"; 
								 
								break;
							case 22 : 
								gblOrderBy = "ORDER BY publog_user_id, publog_update_date"; 
								 
								break;
							case 23 : 
								gblOrderBy = "ORDER BY publog_update_date, publog_user_id "; 
								 
								break;
						}

						Get_New_Pubs(Convert.ToString(grd_NewAvail.Tag)); // Filter By Pub

					} // If lRow > 0 Then

				} // If NewRecs.RecordCount > 0 Then

			} // If grd_NewAvail.Enabled = True Then

			fso = null;

		}

		private void Get_New_Aircraft_Info(int inAC_ID)
		{

			try
			{

				ADORecordSetHelper ado_NewAircraft = new ADORecordSetHelper();
				string Query = "";
				string tmpAcctRep = "";

				this.Cursor = Cursors.WaitCursor;

				Query = "SELECT ac_id,ac_year,amod_make_name, amod_model_name,  ac_ser_no_full,ac_reg_no ";
				Query = $"{Query}FROM Aircraft, Aircraft_Model  WHERE ac_id = {inAC_ID.ToString()} ";
				Query = $"{Query}  AND ac_journ_id = 0  AND amod_id = ac_amod_id";
				ado_NewAircraft.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(ado_NewAircraft.BOF && ado_NewAircraft.EOF))
				{
					ado_NewAircraft.MoveFirst();
					txt_publog_description.Text = ($"{Convert.ToString(ado_NewAircraft["ac_year"])} ").Trim();
					txt_publog_description.Text = $"{txt_publog_description.Text} {($"{Convert.ToString(ado_NewAircraft["amod_make_name"])} ").Trim()}";
					txt_publog_description.Text = $"{txt_publog_description.Text} {($"{Convert.ToString(ado_NewAircraft["amod_model_name"])} ").Trim()}";
					txt_publog_reg_no.Text = ($"{Convert.ToString(ado_NewAircraft["ac_reg_no"])} ").Trim();
					txt_publog_ser_no.Text = ($"{Convert.ToString(ado_NewAircraft["ac_ser_no_full"])} ").Trim();
					txt_publog_Ac_id.Text = ($"{Convert.ToString(ado_NewAircraft["AC_ID"])} ").Trim();
				}
				ado_NewAircraft.Close();
				ado_NewAircraft = null;

				tmpAcctRep = GetACCTRep(inAC_ID);
				int tempForEndVar = cbo_publog_acct_rep.Items.Count - 1;
				for (int i = 0; i <= tempForEndVar; i++)
				{
					if (cbo_publog_acct_rep.GetListItem(i).Trim().ToLower() == tmpAcctRep.Trim().ToLower())
					{
						cbo_publog_acct_rep.SelectedIndex = i;
						break;
					}
				}

				Application.DoEvents();
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Get_New_Aircraft_Info_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}
		}

		public void fill_ac_new_pub_search(string order_by, UpgradeHelpers.DataGridViewFlex grid_name, int temp_pub_id = 0, int temp_row = 0)
		{

			string Query = "";
			ADORecordSetHelper ado_acpub = new ADORecordSetHelper();
			string cellcolor = "";
			int temp_count = 0;
			double temp_feet = 0;
			double temp_inches = 0;
			bool is_available = false;
			string use_or = "";
			string top1 = "";
			try
			{

				is_available = false;

				if (order_by.Trim() == "top1")
				{
					order_by = "";
					top1 = " top 25 ";
				}

				cellcolor = modGlobalVars.cEmptyString;
				Query = modGlobalVars.cEmptyString;


				if (grid_name.Name == "grd_pub")
				{
					//        chk_include(first_attempt) = chk_include(22)  ' 1st attempt
					first_attempt = 11;
					//        chk_include(second_attempt) = chk_include(12)  ' 2nd attempt
					second_attempt = 3;
					//        chk_include(third_attempt) = chk_include(20)  ' 3nd attempt
					third_attempt = 9;
					//        chk_include(hold_review) = chk_include(21)  ' hold/review
					hold_review = 10;
					//        chk_include(completed) = chk_include(13)  ' completed
					completed = 2;
					//        chk_include(open_check) = chk_include(14)  ' open
					open_check = 0;
					//        chk_include(in_progress) = chk_include(17)  ' in progress
					in_progress = 5;
					//        chk_include(blind) = chk_include(19)  ' blind
					blind = 8;
					//        chk_include(cleared_check) = chk_include(15)  ' cleared
					cleared_check = 1;
					//        chk_include(no_action) = chk_include(18)  ' no action required
					no_action = 7;
					//        cbo_pub(status_drop) = cbo_pub(8) ' status
					status_drop = 2;
					//        txt_pub(comp_text) = txt_pub(15) ' company name
					comp_text = 7;

					date_range1 = 12;
					date_range2 = 13;
					category_id = 7;
					count_label = 45;
				}
				else if (grid_name.Name == "grd_pub2")
				{  // memo tab
					//        chk_include(first_attempt) = chk_include(22)  ' 1st attempt
					first_attempt = 22;
					//        chk_include(second_attempt) = chk_include(12)  ' 2nd attempt
					second_attempt = 12;
					//        chk_include(third_attempt) = chk_include(20)  ' 3nd attempt
					third_attempt = 20;
					//        chk_include(hold_review) = chk_include(21)  ' hold/review
					hold_review = 21;
					//        chk_include(completed) = chk_include(13)  ' completed
					completed = 13;
					//        chk_include(open_check) = chk_include(14)  ' open
					open_check = 14;
					//        chk_include(in_progress) = chk_include(17)  ' in progress
					in_progress = 17;
					//        chk_include(blind) = chk_include(19)  ' blind
					blind = 19;
					//        chk_include(cleared_check) = chk_include(15)  ' cleared
					cleared_check = 15;
					//        chk_include(no_action) = chk_include(18)  ' no action required
					no_action = 18;
					//        cbo_pub(status_drop) = cbo_pub(8) ' status
					status_drop = 8;
					//        txt_pub(comp_text) = txt_pub(15) ' company name
					comp_text = 15;

					//        txt_pub(date_range1) = txt_pub(17) ' date range
					//        txt_pub(date_range2) = txt_pub(18) ' date range
					date_range1 = 17;
					date_range2 = 18;
					category_id = 9;
					count_label = 20;
				}
				else
				{

				}


				cmd_pub[2].Enabled = false;

				temp_count = 0;

				//extract fields from yacht table
				grid_name.Visible = false;
				grid_name.Enabled = false;

				//Clear the grid.
				grid_name.Clear();

				//Set the number of columns and rows in the grid.
				grid_name.ColumnsCount = 23;
				grid_name.RowsCount = 2;

				grid_name.FixedRows = 1;
				grid_name.FixedColumns = 0;

				//point to the first column and first row.
				grid_name.CurrentRowIndex = 0;




				if (chk_include[blind].CheckState == CheckState.Checked)
				{
					grid_name.CurrentColumnIndex = 1;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 333);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "COMPANY";

					grid_name.CurrentColumnIndex = 2;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CurrentColumnIndex = 3;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CurrentColumnIndex = 4;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CurrentColumnIndex = 5;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CurrentColumnIndex = 6;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CurrentColumnIndex = 7;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CurrentColumnIndex = 8;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CurrentColumnIndex = 9;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CurrentColumnIndex = 10;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CurrentColumnIndex = 11;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);

					grid_name.CurrentColumnIndex = 12;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 400);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "COMPANY";

					grid_name.CurrentColumnIndex = 20;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 133);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "TIMEZONE";

					grid_name.CurrentColumnIndex = 21;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "";

					grid_name.CurrentColumnIndex = 22;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "CATEGORY";

				}
				else
				{
					grid_name.CurrentColumnIndex = 0;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 35);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "ID";

					grid_name.CurrentColumnIndex = 1;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 40);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "REP";

					grid_name.CurrentColumnIndex = 2;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 73);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "Date Added";

					grid_name.CurrentColumnIndex = 3;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 167);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "Title";

					grid_name.CurrentColumnIndex = 4;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 39);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "ACID";

					grid_name.CurrentColumnIndex = 5;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 49);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "REGNO";

					grid_name.CurrentColumnIndex = 6;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 49);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "SERNO";

					grid_name.CurrentColumnIndex = 7;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 37);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "AFTT";


					grid_name.CurrentColumnIndex = 8;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 35);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "PIC?";

					// added MSW -
					if (cbo_pub[category_id].Text.Trim() == "All")
					{
						grid_name.CurrentColumnIndex = 9;
						grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 113);
						grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
						grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "LAST UPDATE";
						grid_name.CellFontSize = 1;
					}
					else if (cbo_pub[category_id].Text.Trim() == "Pub")
					{ 
						grid_name.CurrentColumnIndex = 9;
						grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
						grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
						grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "LAST UPDATE";
					}
					else
					{
						grid_name.CurrentColumnIndex = 9;
						grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 113);
						grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
						grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "LAST UPDATE";
					}

					grid_name.CurrentColumnIndex = 10;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 152);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "Status";

					grid_name.CurrentColumnIndex = 11;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 67);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = " SOURCE";

					grid_name.CurrentColumnIndex = 12;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = " LINK";

					grid_name.CurrentColumnIndex = 13;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 400);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "COMPANY";

					grid_name.CurrentColumnIndex = 14;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "STATUS";

					grid_name.CurrentColumnIndex = 15;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 333);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "ADVERTISER";

					grid_name.CurrentColumnIndex = 16;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 400);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "DETAILS";

					grid_name.CurrentColumnIndex = 17;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 267);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "MAKE/MODEL";

					grid_name.CurrentColumnIndex = 18;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 267);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "COMP ID";

					grid_name.CurrentColumnIndex = 19;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 267);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "USER ID";

					grid_name.CurrentColumnIndex = 20;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 267);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "TIMEZONE";

					grid_name.CurrentColumnIndex = 21;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 47);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "CLASS";


					grid_name.CurrentColumnIndex = 22;
					grid_name.SetColumnWidth(grid_name.CurrentColumnIndex, 0);
					grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "CATEGORY";
				}



				if (chk_include[blind].CheckState == CheckState.Checked)
				{
					Query = $"SELECT distinct {top1}  publist_seller_info, publist_comp_id, comp_name, (select top 1 p2.publist_id from publication_listing p2 with (NOLOCK) where lower(p2.publist_research_note) like '%no blind pubs%'  and p2.publist_entry_date >= (getdate() - 90) and p2.publist_comp_id > 0 and p2.publist_seller_info = Publication_Listing.publist_seller_info order by p2.publist_entry_date desc) as publist_id, publist_update_date, comp_timezone ,  publist_reg_no,publist_ser_no  ";
				}
				else
				{
					Query = $"SELECT distinct {top1} *, case when amod_class_code is null then 'N/A' else amod_class_code end as acc  ";
				}


				Query = $"{Query}  from Publication_Listing with (NOLOCK)  left outer join Publications with (NOLOCK) on pub_id = publist_source ";
				if (txt_Regno_Search.Text.Trim() != "" || txt_Serialno_Search.Text.Trim() != "")
				{
					Query = $"{Query}INNER JOIN Aircraft ON ac_id = publist_ac_id and ac_journ_id = 0 ";
					Query = $"{Query}INNER JOIN Aircraft_Model ON amod_id = ac_amod_id ";
				}
				else
				{
					Query = $"{Query}LEFT OUTER JOIN Aircraft ON ac_id = publist_ac_id and ac_journ_id = 0 ";
					Query = $"{Query}LEFT OUTER JOIN Aircraft_Model ON amod_id = ac_amod_id ";
				}

				if (txt_pub[comp_text].Text.Trim() != "")
				{
					Query = $"{Query} inner join Company with (NOLOCK) on comp_id = publist_comp_id and comp_journ_id = 0 ";
				}
				else
				{
					Query = $"{Query} left outer join Company with (NOLOCK) on comp_id = publist_comp_id and comp_journ_id = 0 ";
				}


				if (pub_id > 0)
				{
					Query = $"{Query} where publist_id =  {pub_id.ToString()}";
				}
				else
				{
					Query = $"{Query} where publist_ac_id >= 0 and publist_type ='Aircraft'   and publist_status <> 'D' ";


					if (Strings.Len(txt_Serialno_Search.Text.Trim()) > 0)
					{
						Query = $"{Query}AND (ac_ser_no_full LIKE '%{txt_Serialno_Search.Text}%') ";
					}

					if (Strings.Len(txt_Regno_Search.Text.Trim()) > 0)
					{
						Query = $"{Query}AND (ac_reg_no LIKE '%{txt_Regno_Search.Text}%') ";
					}


					if (chk_include[23].CheckState == CheckState.Checked && lbl_gen[22].Text.Trim() != "...")
					{
						if (lbl_gen[22].Text.Trim() != "" && lbl_gen[22].Text.Trim() != "...")
						{
							Query = $"{Query} and publist_acct_rep in ('{cbo_ACREP.Text.Trim()}', '{lbl_gen[22].Text.Trim()}')  ";
						}
						else if (cbo_ACREP.Text.Trim() != "" && cbo_ACREP.Text.Trim() != "All")
						{ 
							Query = $"{Query} and publist_acct_rep = '{cbo_ACREP.Text.Trim()}'   ";
						}
					}
					else if (chk_include[4].CheckState == CheckState.Checked)
					{ 
						if (cbo_ACREP.Text.Trim().IndexOf("DB0") >= 0)
						{
							Query = $"{Query} and publist_acct_rep like 'DB0%' ";
						}
						else if (cbo_ACREP.Text.Trim().IndexOf("AC0") >= 0 || cbo_ACREP.Text.Trim().IndexOf("AC10") >= 0 || cbo_ACREP.Text.Trim().IndexOf("AC20") >= 0 || cbo_ACREP.Text.Trim().IndexOf("AC23") >= 0 || cbo_ACREP.Text.Trim().IndexOf("AC24") >= 0)
						{ 
							Query = $"{Query} and (publist_acct_rep like 'AC0%' or publist_acct_rep = 'AC10' or publist_acct_rep = 'AC20' or publist_acct_rep = 'AC23' or publist_acct_rep = 'AC24')  ";
						}
						else if (cbo_ACREP.Text.Trim().IndexOf("AC12") >= 0 || cbo_ACREP.Text.Trim().IndexOf("AC13") >= 0 || cbo_ACREP.Text.Trim().IndexOf("AC17") >= 0 || cbo_ACREP.Text.Trim().IndexOf("AC11") >= 0)
						{ 
							Query = $"{Query} and (publist_acct_rep = 'AC12' or publist_acct_rep = 'AC13' or publist_acct_rep = 'AC17' or publist_acct_rep = 'AC11')  ";
						}
					}
					else if (cbo_ACREP.Text.Trim() != "" && cbo_ACREP.Text.Trim() != "All")
					{ 
						Query = $"{Query} and publist_acct_rep = '{cbo_ACREP.Text.Trim()}'   ";
					}


					if (cbo_pub[category_id].Text != "All" && cbo_pub[category_id].Text != "")
					{
						Query = $"{Query} and publist_category = '{cbo_pub[category_id].Text}'   ";
					}


					if (chk_include[blind].CheckState == CheckState.Checked)
					{
						Query = $"{Query} and lower(publist_research_note) like '%no blind pubs%' ";
						Query = $"{Query} and publist_entry_date >= (getdate() - 90)  and publist_comp_id > 0 ";
					}
					else
					{



						use_or = "";
						if (chk_include[open_check].CheckState == CheckState.Checked || chk_include[cleared_check].CheckState == CheckState.Checked || chk_include[in_progress].CheckState == CheckState.Checked || chk_include[no_action].CheckState == CheckState.Checked || chk_include[completed].CheckState == CheckState.Checked || chk_include[second_attempt].CheckState == CheckState.Checked || chk_include[hold_review].CheckState == CheckState.Checked || chk_include[third_attempt].CheckState == CheckState.Checked || chk_include[first_attempt].CheckState == CheckState.Checked)
						{

							Query = $"{Query} and (";

							if (chk_include[open_check].CheckState == CheckState.Checked)
							{
								Query = $"{Query} publist_status in ('O') ";
								use_or = " or ";
							}

							if (chk_include[cleared_check].CheckState == CheckState.Checked)
							{
								Query = $"{Query}{use_or} publist_status in ('C') ";
								use_or = " or ";
							}

							if (chk_include[in_progress].CheckState == CheckState.Checked)
							{
								Query = $"{Query}{use_or} publist_status in ('I') ";
								use_or = " or ";
							}


							if (chk_include[no_action].CheckState == CheckState.Checked)
							{
								Query = $"{Query}{use_or} publist_status in ('N') ";
								use_or = " or ";
							}

							// added MSW - 4/2/21 ----------
							if (chk_include[second_attempt].CheckState == CheckState.Checked)
							{
								Query = $"{Query}{use_or} publist_status in ('2') ";
								use_or = " or ";
							}

							if (chk_include[third_attempt].CheckState == CheckState.Checked)
							{
								Query = $"{Query}{use_or} publist_status in ('3') ";
								use_or = " or ";
							}

							if (chk_include[completed].CheckState == CheckState.Checked)
							{
								Query = $"{Query}{use_or} publist_status in ('Z') ";
								use_or = " or ";
							}


							if (chk_include[hold_review].CheckState == CheckState.Checked)
							{
								Query = $"{Query}{use_or} publist_status in ('H') ";
								use_or = " or ";
							}

							// 1st attempted - MSW - 7/28/21
							if (chk_include[first_attempt].CheckState == CheckState.Checked)
							{
								Query = $"{Query}{use_or} publist_status in ('1') ";
								use_or = " or ";
							}


							Query = $"{Query} )";
						}
						else
						{

						}
					}


					if (txt_pub[comp_text].Text.Trim() != "")
					{
						Query = $"{Query} and  comp_name like '{txt_pub[comp_text].Text.Trim()}%' ";
					}

					// added - 9/18/23
					if (grid_name.Name == "grd_pub")
					{
						// msw- 9/18/23
						if (chk_include[25].CheckState == CheckState.Checked)
						{
							// then include class E , else dont include class E
							Query = Query;
						}
						else
						{
							Query = $"{Query} and (amod_class_code <> 'E' or amod_class_code is null) ";
						}
					}
					else
					{
						// msw- 9/18/23
						if (chk_include[24].CheckState == CheckState.Checked)
						{
							// then include class E , else dont include class E
							Query = Query;
						}
						else
						{
							Query = $"{Query} and (amod_class_code <> 'E' or amod_class_code is null) ";
						}
					}







					if (txt_pub[date_range1].Text.Trim() != "")
					{
						if (Information.IsDate(txt_pub[date_range1].Text.Trim()))
						{
							Query = $"{Query} and publist_entry_date >=  '{txt_pub[date_range1].Text.Trim()}' ";
						}
					}

					if (txt_pub[date_range2].Text.Trim() != "")
					{
						if (Information.IsDate(txt_pub[date_range2].Text.Trim()))
						{
							Query = $"{Query} and publist_entry_date <=  '{txt_pub[date_range2].Text.Trim()}' ";
						}
					}

					//chk_include 2 and 3 are for aftt and picures
					use_or = "";


					if (cbo_pub[status_drop].Text.Trim() != "" && cbo_pub[status_drop].Text.Trim() != "All")
					{
						Query = $"{Query} and publist_process_status = '{cbo_pub[status_drop].Text.Trim()}'   ";
					}
				}

				// added MSW - 7/5/22
				if (cbo_pub[10].Text.Trim() != "All")
				{
					if (cbo_pub[10].Text.Trim() == "International")
					{
						Query = $"{Query}AND ((comp_timezone is NULL) or (comp_timezone=''))";
					}
					else
					{
						Query = $"{Query}AND (comp_timezone='{cbo_pub[10].Text.Trim()}') ";
					}
				}





				if (txt_pub[11].Text.Trim() != "")
				{
					if (Information.IsNumeric(txt_pub[11].Text.Trim()))
					{
						Query = $"{Query} and publist_id = '{txt_pub[11].Text.Trim()}'   ";
					}
					else
					{
						Query = $"{Query} and publist_original_desc like '{txt_pub[11].Text.Trim()}%'   ";
					}
				}

				int lCol1 = 0;
				if (chk_include[blind].CheckState == CheckState.Checked)
				{
					order_by = ("comp_name");
					Query = $"{Query} ORDER BY {order_by.Trim()} asc ";
				}
				else if (Convert.ToString(lbl_gen[40].Tag).Trim() != "" && order_by.Trim() == "")
				{ 
					lCol1 = Convert.ToInt32(Double.Parse(Convert.ToString(lbl_gen[40].Tag).Trim()));
					if (lCol1 == 0)
					{
						order_by = ("publist_id");
					}
					else if (lCol1 == 2)
					{ 
						order_by = ("publist_entry_date");
					}
					else if (lCol1 == 3)
					{ 
						order_by = ("publist_original_desc");
					}
					else if (lCol1 == 4)
					{ 
						order_by = ("publist_ac_id");
					}
					else if (lCol1 == 5)
					{ 
						order_by = ("ac_reg_no");
					}
					else if (lCol1 == 6)
					{ 
						order_by = ("ac_ser_no_full");
					}
					else if (lCol1 == 10)
					{ 
						order_by = ("publist_process_status");
					}
					else if (lCol1 == 12)
					{ 
						order_by = ("publist_description");
					}
					else if (lCol1 == 13)
					{ 
						order_by = ("comp_name");
					}
					else if (lCol1 == 15)
					{ 
						order_by = ("publist_seller_info");
					}
					else if (lCol1 == 17)
					{ 
						order_by = ("amod_make_name, amod_model_name ");
					}
					else if (lCol1 == 1)
					{ 
						order_by = ("publist_acct_rep");
					}

					if (Convert.ToString(grid_name.Tag).Trim() != "")
					{
						Query = $"{Query} ORDER BY {order_by.Trim()} {Convert.ToString(grid_name.Tag).Trim()}";
					}
					else if (order_by.Trim() != "")
					{ 
						Query = $"{Query} ORDER BY {order_by.Trim()} asc ";
					}
					else
					{
						Query = $"{Query} ORDER BY publist_entry_date desc ";
					}

				}
				else if (order_by.Trim() == "publist_id")
				{ 
					Query = $"{Query} ORDER BY {order_by.Trim()} desc ";
				}
				else if (order_by.Trim() != "")
				{ 
					Query = $"{Query} ORDER BY {order_by.Trim()} {Convert.ToString(grid_name.Tag).Trim()}";
				}
				else
				{
					Query = $"{Query} ORDER BY publist_entry_date desc, case when amod_class_code is null then 'N/A' else amod_class_code end asc  ";
				}



				ado_acpub.CursorLocation = CursorLocationEnum.adUseClient;
				ado_acpub.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (ado_acpub.RecordCount > 10000)
				{
					grid_name.CurrentRowIndex = 1;
					grid_name.CurrentColumnIndex = 2;
					grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $"Search Yielded {ado_acpub.RecordCount.ToString()} Results... Too Many";
					grid_name.Enabled = false;
				}
				else
				{
					//UPGRADE_WARNING: (2065) TabDlg.SSTab property tab_NewAvail.TabCaption has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					SSTabHelper.SetTabCaption(tab_NewAvail, 2, "New Task");

					if (!ado_acpub.BOF && !ado_acpub.EOF)
					{

						grid_name.CurrentRowIndex = 1;



						do 
						{ // Loop Until ado_acpub.Eof = True




							// added MSW - 10/14/21 ---
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_acpub["publist_process_status"]))
							{
								if (Convert.ToString(ado_acpub["publist_process_status"]).Trim() == "Immediate")
								{
									cellcolor = ColorTranslator.ToOle(Color.Magenta).ToString();
								}
								else
								{
									cellcolor = ColorTranslator.ToOle(Color.White).ToString();
								}
							}
							else
							{
								cellcolor = ColorTranslator.ToOle(Color.White).ToString();
							}






							if (chk_include[blind].CheckState == CheckState.Checked)
							{
								grid_name.set_RowData(grid_name.CurrentRowIndex,Convert.ToInt32( ado_acpub.GetField("publist_id")));

								// cellcolor = vbWhite
								grid_name.CurrentColumnIndex = 0;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_id"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = Convert.ToString(ado_acpub["publist_id"]).Trim();
								}

								grid_name.CurrentColumnIndex = 1;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_seller_info"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["publist_seller_info"]).Trim()}";
								}

								grid_name.CurrentColumnIndex = 1300000000;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["0"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["comp_name"]).Trim()} (";
								}
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_comp_id"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $"{grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].FormattedValue.ToString()}{Convert.ToString(ado_acpub["publist_comp_id"]).Trim()}";
								}
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["comp_name"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $"{grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].FormattedValue.ToString()}) ";
								}
							}
							else
							{


								if (cbo_pub[category_id].Text == "Memo")
								{
									if (top1 == " top 25 ")
									{
										//UPGRADE_WARNING: (2065) TabDlg.SSTab property tab_NewAvail.TabCaption has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
										SSTabHelper.SetTabCaption(tab_NewAvail, 3, "!!!NEW MEMOS AVAILABLE...!!!");
									}
									else
									{
										//UPGRADE_WARNING: (2065) TabDlg.SSTab property tab_NewAvail.TabCaption has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
										SSTabHelper.SetTabCaption(tab_NewAvail, 3, "Memo");
									}
								}
								else if (top1 == " top 25 ")
								{ 
									//UPGRADE_WARNING: (2065) TabDlg.SSTab property tab_NewAvail.TabCaption has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
									SSTabHelper.SetTabCaption(tab_NewAvail, 2, "!!!NEW TASKS AVAILABLE!!!");
								}
								else
								{
									//UPGRADE_WARNING: (2065) TabDlg.SSTab property tab_NewAvail.TabCaption has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
									SSTabHelper.SetTabCaption(tab_NewAvail, 2, "New Task");
								}



								if (grid_name.Name == "grd_pub")
								{
									if (cellcolor.Trim() == ColorTranslator.ToOle(Color.Magenta).ToString())
									{
										// then leave it magenta - which is immediate - per task - MSW - 4/5/23
										cellcolor = cellcolor;
									}
									else if (Convert.ToString(ado_acpub["publist_status"]).Trim() == "C")
									{ 
										cellcolor = modAdminCommon.InactiveColor;
									}
									else
									{
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(ado_acpub["ac_forsale_flag"]))
										{
											if (Convert.ToString(ado_acpub["ac_forsale_flag"]) == "Y")
											{
												cellcolor = modAdminCommon.ForSaleColor;
											}
										}
									}
								}
								else
								{
									if (cellcolor.Trim() == ColorTranslator.ToOle(Color.Magenta).ToString())
									{
										// then leave it magenta - which is immediate - per task - MSW - 12/21/21
									}
									else if (Convert.ToString(ado_acpub["publist_status"]).Trim() == "C")
									{ 
										cellcolor = modAdminCommon.InactiveColor;
									}
									else
									{
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(ado_acpub["ac_forsale_flag"]))
										{
											if (Convert.ToString(ado_acpub["ac_forsale_flag"]) == "Y")
											{
												cellcolor = modAdminCommon.ForSaleColor;
											}
										}
									}
								}







								grid_name.set_RowData(grid_name.CurrentRowIndex,Convert.ToInt32( ado_acpub.GetField("publist_id")));

								grid_name.CurrentColumnIndex = 0;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_id"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = Convert.ToString(ado_acpub["publist_id"]).Trim();
								}


								grid_name.CurrentColumnIndex = 1;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_acct_rep"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = Convert.ToString(ado_acpub["publist_acct_rep"]).Trim();
								}


								grid_name.CurrentColumnIndex = 2;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_entry_date"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {DateTime.Parse(Convert.ToString(ado_acpub["publist_entry_date"]).Trim()).ToString("d")}";
								}


								grid_name.CurrentColumnIndex = 3;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_original_desc"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["publist_original_desc"]).Trim()}";
								}


								grid_name.CurrentColumnIndex = 4;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_ac_id"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = Convert.ToString(ado_acpub["publist_ac_id"]).Trim();

									if (Convert.ToDouble(ado_acpub["publist_ac_id"]) > 0)
									{
										grid_name.CurrentColumnIndex = 5;
										grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
										grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(ado_acpub["ac_reg_no"]))
										{
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["ac_reg_no"]).Trim()}";
										}

										grid_name.CurrentColumnIndex = 6;
										grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
										grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(ado_acpub["ac_ser_no_full"]))
										{
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["ac_ser_no_full"]).Trim()}";
										}
									}
									else
									{
										// added so that it can show 7/18/22
										grid_name.CurrentColumnIndex = 5;
										grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
										grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(ado_acpub["publist_reg_no"]))
										{
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["publist_reg_no"]).Trim()}";
										}

										grid_name.CurrentColumnIndex = 6;
										grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
										grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(ado_acpub["publist_ser_no"]))
										{
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["publist_ser_no"]).Trim()}";
										}
									}


								}
								else
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "0";

									grid_name.CurrentColumnIndex = 5;
									grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(ado_acpub["publist_reg_no"]))
									{
										grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["publist_reg_no"]).Trim()}";
									}

									grid_name.CurrentColumnIndex = 6;
									grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(ado_acpub["publist_ser_no"]))
									{
										grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["publist_ser_no"]).Trim()}";
									}
								}






								grid_name.CurrentColumnIndex = 7;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_description"]))
								{
									if (Convert.ToString(ado_acpub["publist_description"]).Trim().IndexOf("AFTT Difference") >= 0)
									{
										grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "AFTT";
									}
								}

								grid_name.CurrentColumnIndex = 8;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_description"]))
								{
									if (Convert.ToString(ado_acpub["publist_description"]).Trim().IndexOf("Pictures Found") >= 0)
									{
										grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "PIC";
									}
								}

								grid_name.CurrentColumnIndex = 9;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_update_date"]))
								{
									if (Convert.ToDateTime(ado_acpub["publist_update_date"]).Year == 1900)
									{
									}
									else
									{
										grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {StringsHelper.Replace(StringsHelper.Replace(StringsHelper.Replace(StringsHelper.Replace(StringsHelper.Replace(Convert.ToString(ado_acpub["publist_update_date"]), "2021", "21", 1, -1, CompareMethod.Binary), "2022", "22", 1, -1, CompareMethod.Binary), "2023", "23", 1, -1, CompareMethod.Binary), "2024", "24", 1, -1, CompareMethod.Binary), "2025", "25", 1, -1, CompareMethod.Binary).Trim()}";
									}
								}

								grid_name.CurrentColumnIndex = 10;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_process_status"]))
								{
									if (Convert.ToString(ado_acpub["publist_process_status"]).Trim() != "")
									{
										grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {StringsHelper.Replace(StringsHelper.Replace(Convert.ToString(ado_acpub["publist_process_status"]), "Not for Sale", "NFS", 1, -1, CompareMethod.Binary), "For Sale", "FS", 1, -1, CompareMethod.Binary)}";
									}
									else
									{
										grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" ";
									}
								}

								grid_name.CurrentColumnIndex = 11;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								grid_name.CellFontUnderline = true;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["pub_name"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["pub_name"]).Trim()}";
								}
								else if (!Convert.IsDBNull(ado_acpub["publist_source"]))
								{ 
									if (Information.IsNumeric(ado_acpub["publist_source"]))
									{
										if (Convert.ToInt32(ado_acpub["publist_source"]) == 900)
										{
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = " Dealer Website";
										}
										else if (Convert.ToInt32(ado_acpub["publist_source"]) == 901)
										{ 
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = " General";
										}
										else if (Convert.ToInt32(ado_acpub["publist_source"]) == 902)
										{ 
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = " Trade-A-Plane";
										}
										else if (Convert.ToInt32(ado_acpub["publist_source"]) == 903)
										{ 
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = " Accident Report";
										}
										else if (Convert.ToInt32(ado_acpub["publist_source"]) == 904)
										{ 
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = " News Article";
										}
										else if (Convert.ToInt32(ado_acpub["publist_source"]) == 905)
										{ 
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = " Registry";
										}
										else if (Convert.ToInt32(ado_acpub["publist_source"]) == 906)
										{ 
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = " A/C Review";
										}
										else if (Convert.ToInt32(ado_acpub["publist_source"]) == 907)
										{ 
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = " Company/Contact";
										}
										else if (Convert.ToInt32(ado_acpub["publist_source"]) == 908)
										{ 
											grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = " CSD";
										}
									}
								}
								else
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = " General";
								}

								grid_name.CurrentColumnIndex = 12;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_url"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $"{Convert.ToString(ado_acpub["publist_url"]).Trim()}";
								}


								grid_name.CurrentColumnIndex = 13;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["comp_name"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["comp_name"]).Trim()} (";
								}
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_comp_id"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $"{grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].FormattedValue.ToString()}{Convert.ToString(ado_acpub["publist_comp_id"]).Trim()}";
								}
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["comp_name"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $"{grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].FormattedValue.ToString()}) ";
								}


								grid_name.CurrentColumnIndex = 14;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_status"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["publist_status"]).Trim()}";
								}

								grid_name.CurrentColumnIndex = 15;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_seller_info"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["publist_seller_info"]).Trim()}";
								}


								grid_name.CurrentColumnIndex = 16;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_description"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["publist_description"]).Trim()}";
								}


								grid_name.CurrentColumnIndex = 17;
								grid_name.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["amod_make_name"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $" {Convert.ToString(ado_acpub["amod_make_name"]).Trim()}";
								}
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["amod_model_name"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $"{grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].FormattedValue.ToString()} {Convert.ToString(ado_acpub["amod_model_name"]).Trim()}";
								}


								grid_name.CurrentColumnIndex = 18;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_comp_id"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $"{Convert.ToString(ado_acpub["publist_comp_id"]).Trim()}";
								}

								grid_name.CurrentColumnIndex = 19;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["publist_user_id"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $"{Convert.ToString(ado_acpub["publist_user_id"]).Trim()}";
								}


								grid_name.CurrentColumnIndex = 20;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["comp_timezone"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $"{Convert.ToString(ado_acpub["comp_timezone"]).Trim()}";
								}

								grid_name.CurrentColumnIndex = 21;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_acpub["acc"]))
								{
									grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $"{Convert.ToString(ado_acpub["acc"]).Trim()}";
								}
							}




							grid_name.CurrentColumnIndex = 22;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_acpub["publist_category"]))
							{
								grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = $"{Convert.ToString(ado_acpub["publist_category"]).Trim()}";
							}





							temp_count++;
							grid_name.RowsCount++;
							grid_name.CurrentRowIndex++;

							ado_acpub.MoveNext();

						}
						while(!ado_acpub.EOF);

						grid_name.RowsCount--;
						grid_name.CurrentRowIndex = 1;
						grid_name.Enabled = true;

					}
					else
					{

						grid_name.CurrentRowIndex = 1;
						grid_name.CurrentColumnIndex = 2;
						grid_name[grid_name.CurrentRowIndex, grid_name.CurrentColumnIndex].Value = "No Pubs Found";
						grid_name.Enabled = false;

					} // If ado_acpub.BOF = False And ado_acpub.EOF = False Then

					ado_acpub.Close();

					lbl_gen[count_label].Text = $"Records Found: {temp_count.ToString()}";

					grid_name.Visible = true;
					grid_name.Redraw = true;
					cmd_pub[2].Enabled = true;

					// this will highlght and select whatever row pub id is passed in
					if (temp_pub_id > 0)
					{
						grid_name.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
						grid_name.CurrentRowIndex = temp_row;
						grid_name.FirstDisplayedScrollingRowIndex = temp_row - 3;
						find_pub_item(temp_pub_id);
						modCommon.Highlight_Grid_Row(grid_name);

					}


					// lbl_count.Caption = temp_count


				} // If cmd_search_search.Enabled = True Then

				ado_acpub = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"fill_ac_new_pub_search_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[] JID:[]", "Company (frm_Company)");
			}

		}



		public void Fill_Timezones()
		{

			ADORecordSetHelper snpTimeZone = new ADORecordSetHelper();

			cbo_pub[10].Items.Clear();
			cbo_pub[10].AddItem("All");

			string Query = "SELECT tzone_name FROM Timezone ";
			Query = $"{Query}ORDER BY tzone_name";

			//Set snpTimeZone = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
			snpTimeZone.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snpTimeZone.BOF && snpTimeZone.EOF))
			{
				snpTimeZone.MoveFirst();

				while(!snpTimeZone.EOF)
				{
					cbo_pub[10].AddItem(($"{Convert.ToString(snpTimeZone["tzone_name"])}").Trim());
					snpTimeZone.MoveNext();
				};
			}
			cbo_pub[10].AddItem("International");

			cbo_pub[10].SelectedIndex = 0;
			snpTimeZone.Close();

		} // Fill_Timezones


		public void Fill_AC_Status_Drop_Down(ComboBox cmbBox, string strTransType)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbBox.Enabled = false;

				cmbBox.Items.Clear();
				cmbBox.AddItem("All");

				strQuery1 = "SELECT distinct publist_process_status FROM Publication_Listing WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1} where publist_process_status <> ''  and publist_process_status not in ('All','Wanted','Auction') ";
				strQuery1 = $"{strQuery1}ORDER BY publist_process_status asc  ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbBox.AddItem(($"{Convert.ToString(rstRec1["publist_process_status"])} ").Trim());

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then


				cmbBox.AddItem(("Wanted").Trim());
				cmbBox.AddItem(("Auction").Trim());


				rstRec1.Close();

				cmbBox.Enabled = true;

				rstRec1 = null;
			}
			catch
			{

				//UPGRADE_TODO: (1067) Member Desc is not defined in type VBA.ErrObject(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modAdminCommon.Record_Error("ACSearch", $"Fill_AC_Status_Drop_Down_Error: {Convert.ToString(Information.Err().Description)}");
			}

		} // Fill_Yacht_Status_Drop_Down_Down

		private void fill_account_rep(ComboBox cbo_account_id)
		{

			ADORecordSetHelper snp_ACSummary = new ADORecordSetHelper();

			cbo_account_id.Items.Clear();
			cbo_account_id.AddItem("All");

			string Query = "SELECT accrep_account_id FROM Account_rep WITH(NOLOCK) ORDER BY accrep_account_id";

			snp_ACSummary = new ADORecordSetHelper();

			snp_ACSummary.CursorLocation = CursorLocationEnum.adUseClient;
			snp_ACSummary.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!snp_ACSummary.BOF && !snp_ACSummary.EOF)
			{


				do 
				{ // Loop Until snp_ACSummary.EOF = True

					cbo_account_id.AddItem(Convert.ToString(snp_ACSummary["accrep_account_id"]));

					snp_ACSummary.MoveNext();

				}
				while(!snp_ACSummary.EOF);

				//      grdACSummary.ListIndex = 0
				cbo_account_id.SelectedIndex = 0;

			} // If (snp_ACSummary.BOF = False And snp_ACSummary.EOF = False) Then




		}

		private void grd_pub_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			frm_Company ofrm_Company = null;
			string Query = "";
			string bgcolor = "";

			int lRow1 = grd_pub.MouseRow;
			int lCol1 = grd_pub.MouseCol;


			int temp_comp_id = 0;
			string tcmop = "";
			if (lRow1 == 0)
			{
				lbl_gen[40].Tag = lCol1.ToString();

				if (Convert.ToString(grd_pub.Tag).Trim() == "asc")
				{
					grd_pub.Tag = "desc";
				}
				else
				{
					grd_pub.Tag = "asc";
				}


				if (lCol1 == 0)
				{
					fill_ac_new_pub_search("publist_id", grd_pub);
				}
				else if (lCol1 == 2)
				{ 
					fill_ac_new_pub_search("publist_entry_date", grd_pub);
				}
				else if (lCol1 == 3)
				{ 
					fill_ac_new_pub_search("publist_original_desc", grd_pub);
				}
				else if (lCol1 == 4)
				{ 
					fill_ac_new_pub_search("publist_ac_id", grd_pub);
				}
				else if (lCol1 == 5)
				{ 
					fill_ac_new_pub_search("ac_reg_no", grd_pub);
				}
				else if (lCol1 == 6)
				{ 
					fill_ac_new_pub_search("ac_ser_no_full", grd_pub);
				}
				else if (lCol1 == 9)
				{ 
					fill_ac_new_pub_search("publist_update_date", grd_pub);
				}
				else if (lCol1 == 10)
				{ 
					fill_ac_new_pub_search("publist_process_status", grd_pub);
				}
				else if (lCol1 == 12)
				{ 
					fill_ac_new_pub_search("publist_description", grd_pub);
				}
				else if (lCol1 == 13)
				{ 
					fill_ac_new_pub_search("comp_name", grd_pub);
				}
				else if (lCol1 == 15)
				{ 
					fill_ac_new_pub_search("publist_seller_info", grd_pub);
				}
				else if (lCol1 == 17)
				{ 
					fill_ac_new_pub_search("amod_make_name, amod_model_name ", grd_pub);
				}
				else if (lCol1 == 1)
				{ 
					fill_ac_new_pub_search("publist_acct_rep", grd_pub);
				}
				else if (lCol1 == 21)
				{ 
					fill_ac_new_pub_search(" case when amod_class_code is null then 'N/A' else amod_class_code end ", grd_pub);
				}
			}
			else if (lCol1 == 4 || lCol1 == 5 || lCol1 == 6)
			{ 

				modAdminCommon.gbl_bHomeClicked = false;
				modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(Convert.ToString(grd_pub[lRow1, 4].Value)));
				modAdminCommon.gbl_Aircraft_Journal_ID = 0;
				if (modAdminCommon.gbl_Aircraft_ID > 0)
				{
					if (!modCommon.Is_Form_Already_Loaded("frm_Aircraft"))
					{
						//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//VB.Global.Load(frm_aircraft.DefInstance);
					}

					frm_aircraft.DefInstance.Form_Initialize();
					frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
					frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
					frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
					frm_aircraft.DefInstance.Reference_Company_ID = 0;
					frm_aircraft.DefInstance.Show();
					//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					Support.ZOrder(frm_aircraft.DefInstance, 0);
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

				}

			}
			else if (lCol1 == 11)
			{ 

				grd_pub.CurrentColumnIndex = 12;
				grd_pub.CurrentRowIndex = lRow1;
				bgcolor = ColorTranslator.ToOle(grd_pub.CellBackColor).ToString();

				if (grd_pub[grd_pub.CurrentRowIndex, grd_pub.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
				{
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(frm_WebReport.DefInstance);

					frm_WebReport.DefInstance.PassedPubLink = grd_pub[grd_pub.CurrentRowIndex, grd_pub.CurrentColumnIndex].FormattedValue.ToString();

					frm_WebReport.DefInstance.WhichReport = "Yacht_Pub";

					frm_WebReport.DefInstance.Show();
				}

			}
			else if (lCol1 == 13)
			{ 

				tcmop = Convert.ToString(grd_pub[lRow1, lCol1].Value);
				tcmop = tcmop.Trim().Substring(Math.Max(tcmop.Trim().Length - (Strings.Len(tcmop.Trim()) - (tcmop.Trim().IndexOf('(') + 1)), 0));
				tcmop = StringsHelper.Replace(tcmop, ")", "", 1, -1, CompareMethod.Binary);

				if (Information.IsNumeric(tcmop.Trim()))
				{
					temp_comp_id = Convert.ToInt32(Double.Parse(tcmop));
				}
				else
				{
					if (tcmop.Trim().IndexOf('(') >= 0)
					{
						tcmop = tcmop.Trim().Substring(Math.Max(tcmop.Trim().Length - (Strings.Len(tcmop.Trim()) - (tcmop.Trim().IndexOf('(') + 1)), 0));
						temp_comp_id = Convert.ToInt32(Double.Parse(tcmop));
					}
				}




				ofrm_Company = frm_Company.CreateInstance();
				modCommon.Unload_Form("frm_Company");

				ofrm_Company = frm_Company.CreateInstance();
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(ofrm_Company);
				ofrm_Company.Form_Initialize();
				ofrm_Company.StartForm = modGlobalVars.tStart_Form;
				ofrm_Company.Reference_CompanyID = temp_comp_id;
				ofrm_Company.Reference_CompanyJID = 0;
				ofrm_Company.Show();
				//UPGRADE_WARNING: (2065) Form method ofrm_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				ofrm_Company.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				ofrm_Company.Form_Activated(null, new EventArgs());

			}

			cmd_pub[5].Visible = true;



			from_spot = "";
		}

		public void find_pub_item(int pub_id, int pub_row = 0)
		{

			pnl_update_pub.Visible = true;

			ADORecordSetHelper ado_Yacht = new ADORecordSetHelper();
			bool found_source = false;
			cmd_pub[5].Visible = true;
			pnl_update_pub.Top = 498;

			if (pub_row > 0)
			{
				lbl_gen[41].Tag = pub_row.ToString();
			}

			string Query = "SELECT *  from Publication_Listing with (NOLOCK)  ";
			Query = $"{Query} left outer join Publications with (NOLOCK) on pub_id = publist_source ";
			Query = $"{Query} where publist_id = {pub_id.ToString()}";

			ado_Yacht.CursorLocation = CursorLocationEnum.adUseClient;
			ado_Yacht.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!ado_Yacht.BOF && !ado_Yacht.EOF)
			{

				do 
				{ // Loop Until ado_Yacht.Eof = True

					lbl_gen[42].Text = Convert.ToString(ado_Yacht["publist_id"]);

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_acct_rep"]))
					{
						cbo_pub[0].Text = Convert.ToString(ado_Yacht["publist_acct_rep"]);
						cbo_pub[0].Tag = Convert.ToString(ado_Yacht["publist_acct_rep"]);
					}
					else
					{
						cbo_pub[0].Text = "";
						cbo_pub[0].Tag = "";
					}


					// added MSW - 3/25/21
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_category"]))
					{
						cbo_pub[6].Text = Convert.ToString(ado_Yacht["publist_category"]);
						cbo_pub[6].Tag = Convert.ToString(ado_Yacht["publist_category"]);
					}
					else
					{
						cbo_pub[6].Text = "";
						cbo_pub[6].Tag = "";
					}



					// added MSW - 7/2/21
					find_select_status_index(cbo_pub[6].Text.Trim(), Convert.ToString(ado_Yacht["publist_status"]).Trim());





					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_research_note"]))
					{
						txt_pub[3].Text = Convert.ToString(ado_Yacht["publist_research_note"]);
						txt_pub[3].Tag = Convert.ToString(ado_Yacht["publist_research_note"]);
					}
					else
					{
						txt_pub[3].Text = "";
						txt_pub[3].Tag = "";
					}


					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_original_desc"]))
					{
						txt_pub[5].Text = Convert.ToString(ado_Yacht["publist_original_desc"]);
					}
					else
					{
						txt_pub[5].Text = "";
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_seller_info"]))
					{
						txt_pub[0].Text = Convert.ToString(ado_Yacht["publist_seller_info"]);
					}
					else
					{
						txt_pub[0].Text = "";
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["pub_name"]))
					{
						txt_pub[9].Text = Convert.ToString(ado_Yacht["pub_name"]);
					}
					else
					{
						txt_pub[9].Text = "";
					}


					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_entry_date"]))
					{
						txt_pub[9].Tag = Convert.ToString(ado_Yacht["publist_entry_date"]);
					}
					else
					{
						txt_pub[9].Tag = "";
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_process_status"]))
					{
						cbo_pub[5].Text = Convert.ToString(ado_Yacht["publist_process_status"]);
					}
					else
					{
						cbo_pub[5].Text = "";
					}
					cbo_pub[5].Tag = cbo_pub[5].Text;


					txt_pub[1].Text = Convert.ToString(ado_Yacht["publist_ac_id"]);
					txt_pub[1].Tag = Convert.ToString(ado_Yacht["publist_ac_id"]);

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_comp_id"]))
					{
						txt_pub[6].Text = Convert.ToString(ado_Yacht["publist_comp_id"]);
						txt_pub[6].Tag = Convert.ToString(ado_Yacht["publist_comp_id"]);
					}
					else
					{
						txt_pub[6].Text = "0";
						txt_pub[6].Tag = "0";
					}


					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_url"]))
					{
						txt_pub[4].Text = Convert.ToString(ado_Yacht["publist_url"]);
					}
					else
					{
						txt_pub[4].Text = "";
					}


					//txt_pub(2).Text = ado_Yacht("publist_original_desc")
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_original_desc"]))
					{
						txt_pub[8].Text = Convert.ToString(ado_Yacht["publist_original_desc"]);
					}
					else
					{
						txt_pub[8].Text = "";
					}

					chk_include[6].CheckState = CheckState.Unchecked;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_description"]))
					{
						txt_pub[2].Text = Convert.ToString(ado_Yacht["publist_description"]);
						if (txt_pub[2].Text.IndexOf("Pictures Found") >= 0)
						{
							chk_include[6].CheckState = CheckState.Checked;
						}
					}
					else
					{
						txt_pub[2].Text = "";
					}

					found_source = false;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_source"]))
					{
						if (Convert.ToString(ado_Yacht["publist_source"]).Trim() != "0")
						{
							int tempForEndVar = cbo_pub[3].Items.Count - 1;
							for (int i = 0; i <= tempForEndVar; i++)
							{
								if (cbo_pub[3].GetItemData(i) == Convert.ToDouble(ado_Yacht["publist_source"]))
								{
									cbo_pub[3].SelectedIndex = i;
									found_source = true;
								}
							}

						}

						if (!found_source)
						{
							cbo_pub[3].SelectedIndex = 0;
						}

						// if we have a pub url, then we should make sure its not general
						if (txt_pub[4].Text.Trim() != "")
						{
							if (cbo_pub[3].Text.Trim() == "General")
							{
								MessageBox.Show("Source is 'General', but we have a URL!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
							}
							else if (cbo_pub[3].Text.Trim() == "")
							{ 
								cbo_pub[3].Enabled = true;
							}
							else if (cbo_pub[3].GetItemData(cbo_pub[3].SelectedIndex) < 900)
							{ 
								cbo_pub[3].Enabled = false; // make this un-editable
							}
						}
						else
						{
							cbo_pub[3].Enabled = true; // url is blank , so we can pick whatever
						}
					}
					else
					{
						cbo_pub[3].Text = "";
					}

					// added MSW - 3/26/21
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Yacht["publist_entry_date"]))
					{
						txt_pub[14].Text = Convert.ToString(ado_Yacht["publist_entry_date"]);
					}
					else
					{
						txt_pub[14].Text = "";
					}



					ado_Yacht.MoveNext();

				}
				while(!ado_Yacht.EOF);

			}
			else
			{

			}

			ado_Yacht.Close();


		}



		private void grd_pub_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;


			string Query = "";
			string bgcolor = "";
			string temp_string = "";


			int lRow1 = grd_pub.MouseRow;


			grd_pub.CurrentColumnIndex = 22;
			string temp_cat = grd_pub[grd_pub.CurrentRowIndex, grd_pub.CurrentColumnIndex].FormattedValue.ToString();

			int lCol1 = 7;


			if (grd_pub[grd_pub.CurrentRowIndex, grd_pub.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
			{
				if (!Information.IsNumeric(grd_pub[grd_pub.CurrentRowIndex, grd_pub.CurrentColumnIndex].FormattedValue.ToString()))
				{
					grd_pub.CurrentColumnIndex = 0;
				}

				pub_single_click_code(Convert.ToInt32(Double.Parse(grd_pub[grd_pub.CurrentRowIndex, grd_pub.CurrentColumnIndex].FormattedValue.ToString())), lRow1, temp_cat);
			}

			// grd_pub.Col = 7


		}

		private void grd_pub2_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			frm_Company ofrm_Company = null;
			string Query = "";
			string bgcolor = "";

			int lRow1 = grd_pub2.MouseRow;
			int lCol1 = grd_pub2.MouseCol;


			int temp_comp_id = 0;
			string tcmop = "";
			if (lRow1 == 0)
			{
				lbl_gen[40].Tag = lCol1.ToString();

				if (Convert.ToString(grd_pub2.Tag).Trim() == "asc")
				{
					grd_pub2.Tag = "desc";
				}
				else
				{
					grd_pub2.Tag = "asc";
				}


				if (lCol1 == 0)
				{
					fill_ac_new_pub_search("publist_id", grd_pub2);
				}
				else if (lCol1 == 2)
				{ 
					fill_ac_new_pub_search("publist_entry_date", grd_pub2);
				}
				else if (lCol1 == 3)
				{ 
					fill_ac_new_pub_search("publist_original_desc", grd_pub2);
				}
				else if (lCol1 == 4)
				{ 
					fill_ac_new_pub_search("publist_ac_id", grd_pub2);
				}
				else if (lCol1 == 5)
				{ 
					fill_ac_new_pub_search("ac_reg_no", grd_pub2);
				}
				else if (lCol1 == 6)
				{ 
					fill_ac_new_pub_search("ac_ser_no_full", grd_pub2);
				}
				else if (lCol1 == 9)
				{ 
					fill_ac_new_pub_search("publist_update_date", grd_pub2);
				}
				else if (lCol1 == 10)
				{ 
					fill_ac_new_pub_search("publist_process_status", grd_pub2);
				}
				else if (lCol1 == 12)
				{ 
					fill_ac_new_pub_search("publist_description", grd_pub2);
				}
				else if (lCol1 == 13)
				{ 
					fill_ac_new_pub_search("comp_name", grd_pub2);
				}
				else if (lCol1 == 15)
				{ 
					fill_ac_new_pub_search("publist_seller_info", grd_pub2);
				}
				else if (lCol1 == 17)
				{ 
					fill_ac_new_pub_search("amod_make_name, amod_model_name ", grd_pub2);
				}
				else if (lCol1 == 1)
				{ 
					fill_ac_new_pub_search("publist_acct_rep", grd_pub2);
				}
				else if (lCol1 == 11)
				{ 
					fill_ac_new_pub_search("publist_source", grd_pub2);
				}
			}
			else if (lCol1 == 4 || lCol1 == 5 || lCol1 == 6)
			{ 

				modAdminCommon.gbl_bHomeClicked = false;
				modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(Convert.ToString(grd_pub2[lRow1, 4].Value)));
				modAdminCommon.gbl_Aircraft_Journal_ID = 0;
				if (modAdminCommon.gbl_Aircraft_ID > 0)
				{
					if (!modCommon.Is_Form_Already_Loaded("frm_Aircraft"))
					{
						//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//VB.Global.Load(frm_aircraft.DefInstance);
					}

					frm_aircraft.DefInstance.Form_Initialize();
					frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
					frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
					frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
					frm_aircraft.DefInstance.Reference_Company_ID = 0;
					frm_aircraft.DefInstance.Show();
					//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					Support.ZOrder(frm_aircraft.DefInstance, 0);
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

				}

			}
			else if (lCol1 == 11)
			{ 

				grd_pub2.CurrentColumnIndex = 12;
				grd_pub2.CurrentRowIndex = lRow1;
				bgcolor = ColorTranslator.ToOle(grd_pub2.CellBackColor).ToString();

				if (grd_pub2[grd_pub2.CurrentRowIndex, grd_pub2.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
				{
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(frm_WebReport.DefInstance);

					frm_WebReport.DefInstance.PassedPubLink = grd_pub2[grd_pub2.CurrentRowIndex, grd_pub2.CurrentColumnIndex].FormattedValue.ToString();

					frm_WebReport.DefInstance.WhichReport = "Yacht_Pub";

					frm_WebReport.DefInstance.Show();
				}

			}
			else if (lCol1 == 13)
			{ 

				tcmop = Convert.ToString(grd_pub2[lRow1, lCol1].Value);
				tcmop = tcmop.Trim().Substring(Math.Max(tcmop.Trim().Length - (Strings.Len(tcmop.Trim()) - (tcmop.Trim().IndexOf('(') + 1)), 0));
				tcmop = StringsHelper.Replace(tcmop, ")", "", 1, -1, CompareMethod.Binary);

				if (Information.IsNumeric(tcmop.Trim()))
				{
					temp_comp_id = Convert.ToInt32(Double.Parse(tcmop));
				}
				else
				{
					if (tcmop.Trim().IndexOf('(') >= 0)
					{
						tcmop = tcmop.Trim().Substring(Math.Max(tcmop.Trim().Length - (Strings.Len(tcmop.Trim()) - (tcmop.Trim().IndexOf('(') + 1)), 0));
						temp_comp_id = Convert.ToInt32(Double.Parse(tcmop));
					}
				}




				ofrm_Company = frm_Company.CreateInstance();
				modCommon.Unload_Form("frm_Company");

				ofrm_Company = frm_Company.CreateInstance();
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(ofrm_Company);
				ofrm_Company.Form_Initialize();
				ofrm_Company.StartForm = modGlobalVars.tStart_Form;
				ofrm_Company.Reference_CompanyID = temp_comp_id;
				ofrm_Company.Reference_CompanyJID = 0;
				ofrm_Company.Show();
				//UPGRADE_WARNING: (2065) Form method ofrm_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				ofrm_Company.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				ofrm_Company.Form_Activated(null, new EventArgs());

			}

			cmd_pub[5].Visible = true;

			from_spot = "";


		}


		private void grd_pub2_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;


			string Query = "";
			string bgcolor = "";
			string temp_string = "";


			int lRow1 = grd_pub2.MouseRow;
			int lCol1 = 7;


			grd_pub.CurrentColumnIndex = 22;
			string temp_cat = grd_pub[grd_pub.CurrentRowIndex, grd_pub.CurrentColumnIndex].FormattedValue.ToString();


			if (grd_pub2[grd_pub2.CurrentRowIndex, grd_pub2.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
			{
				if (!Information.IsNumeric(grd_pub2[grd_pub2.CurrentRowIndex, grd_pub2.CurrentColumnIndex].FormattedValue.ToString()))
				{
					grd_pub2.CurrentColumnIndex = 0;
				}

				pub_single_click_code(Convert.ToInt32(Double.Parse(grd_pub2[grd_pub2.CurrentRowIndex, grd_pub2.CurrentColumnIndex].FormattedValue.ToString())), lRow1, temp_cat);
			}


		}


		private void lbl_gen_DoubleClick(Object eventSender, EventArgs eventArgs)
		{


			string strText = Convert.ToString(txt_pub[3].Tag);

			if (strText != "")
			{

				if (frm_info2.DefInstance == null)
				{
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(frm_info2.DefInstance);
				}

				frm_info2.DefInstance.SetFormCaption("Task Note Data");
				frm_info2.DefInstance.SetText(strText);
				frm_info2.DefInstance.SetTextEnabled(true);
				frm_info2.DefInstance.Show();

			} // If strText <> "" Then


		}


		private void lblPubLink_Click(Object eventSender, EventArgs eventArgs)
		{

			string strURL = "";

			if (lblPubLink.Enabled)
			{

				lblPubLink.Enabled = false;

				strURL = txt_publog_url.Text.Trim();

				if (strURL != "")
				{

					modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strURL);

				} // If strURL <> "" Then

				lblPubLink.Enabled = true;

			} // If lblPubLink.Enabled = True Then

		} // lblPubLink_Click

		public void mnuClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		public void mnuEditAdd_Click(Object eventSender, EventArgs eventArgs)
		{

			SSTabHelper.SetSelectedIndex(tab_NewAvail, 0);
			Edit_Status = "Add";
			frame_Details.Visible = true;
			cmd_Save.Visible = true;
			txt_publog_description.Text = "";
			txt_publog_reg_no.Text = "";
			txt_publog_ser_no.Text = "";
			txt_publog_Ac_id.Text = "";
			txt_publog_price.Text = "";
			txt_publog_aftt.Text = "";
			txt_publog_url.Text = "";
			txt_publog_seller_info.Text = "";
			txt_publog_entry_date.Text = "";
			txt_publog_update_date.Text = "";
			//txt_acct_rep = ""
			cbo_publog_acct_rep.SelectedIndex = 0;

		}

		private void Update_Pub()
		{

			string errMsg = "";
			try
			{

				string Msg = "";
				ADORecordSetHelper NewAvailEntry = new ADORecordSetHelper();
				string Query = "";
				bool AcctRepChanged = false;
				int PubJournID = 0;

				AcctRepChanged = false;

				errMsg = "init";
				// Update Pub Record
				if (Conversion.Val($"{txt_publog_Ac_id.Text}") == 0)
				{

					if (Edit_Status == "Add")
					{
						Msg = "No Aircraft has been Identified. Please identify an aircraft before trying to add a new pub.";
					}
					else
					{
						Msg = "No Aircraft has been Identified. Please identify an aircraft before trying to update a new pub.";
					}

					MessageBox.Show(Msg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

					return;

				}

				errMsg = $"edit {txt_publog_url.Text.Trim()}";
				if (Strings.Len(($"{txt_publog_url.Text}").Trim()) == 0)
				{
					if (Edit_Status == "Add")
					{
						Msg = "New pub entries must have a link to the web site source.";
					}
					else
					{
						Msg = "Pub entries must have a link to the web site source.";
					}

					MessageBox.Show(Msg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

					return;
				}

				if (Strings.Len(($"{cbo_publog_acct_rep.Text}").Trim()) == 0)
				{
					Msg = "Pub Must Have Acct Rep";
					MessageBox.Show(Msg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					cbo_publog_acct_rep.Focus();

					return;
				}


				string temp_pubnote_type = "";
				if (cbo_pub[6].Text.Trim() == "Memo")
				{
					temp_pubnote_type = "MEMO";
				}
				else if (cbo_pub[6].Text.Trim() == "Doc Request")
				{ 
					temp_pubnote_type = "MEMO";
				}
				else
				{
					temp_pubnote_type = "PBNOTE";
				}

				Query = "SELECT * FROM Publication_Log ";
				if (Edit_Status == "Add")
				{
					Query = $"{Query}WHERE (publog_id = -1)";
				}
				else
				{
					Query = $"{Query}WHERE (publog_id = {Convert.ToString(NewRecs["Publog_id"])}) ";
				}

				NewAvailEntry.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (Edit_Status == "Add")
				{
					NewAvailEntry.AddNew();
					NewAvailEntry["publog_user_id"] = modAdminCommon.gbl_User_ID;
				}

				errMsg = "add new";
				NewAvailEntry["publog_source"] = cbo_publog_source.Text.Substring(0, Math.Min(3, cbo_publog_source.Text.Length));
				NewAvailEntry["publog_ac_id"] = Convert.ToInt32(Double.Parse(($"{txt_publog_Ac_id.Text} ").Trim()));

				NewAvailEntry["publog_reg_no"] = $"{txt_publog_reg_no.Text}";
				NewAvailEntry["publog_ser_no"] = $"{txt_publog_ser_no.Text}";

				NewAvailEntry["publog_description"] = $"{txt_publog_description.Text}";
				NewAvailEntry["publog_picture"] = cbo_publog_picture.Text;
				if (Strings.Len(txt_publog_aftt.Text.Trim()) > 0)
				{
					if (Information.IsNumeric(txt_publog_aftt.Text.Trim()))
					{
						NewAvailEntry["publog_aftt"] = Strings.FormatNumber(txt_publog_aftt.Text.Trim(), 0, TriState.False, TriState.False, TriState.True);
					}
					else
					{
						NewAvailEntry["publog_aftt"] = txt_publog_aftt.Text.Trim();
					}
				}
				if (Strings.Len(txt_publog_price.Text.Trim()) > 0)
				{
					if (Information.IsNumeric(txt_publog_price.Text.Trim()))
					{
						NewAvailEntry["publog_price"] = $"${Strings.FormatNumber(txt_publog_price.Text.Trim(), 0, TriState.False, TriState.False, TriState.True)}";
					}
					else
					{
						NewAvailEntry["publog_price"] = txt_publog_price.Text.Trim();
					}
				}
				NewAvailEntry["publog_url"] = $"{txt_publog_url.Text}";
				NewAvailEntry["publog_status"] = "N";

				NewAvailEntry["publog_acct_rep"] = $"{cbo_publog_acct_rep.Text}";

				NewAvailEntry["publog_seller_info"] = $"{txt_publog_seller_info.Text}";

				if (RememberAcctRep.Trim() != cbo_publog_acct_rep.Text.Trim())
				{
					AcctRepChanged = true;

					// RTW - 12/4/07 - PUT IN THE DATE IN THE LATEST CHANGE DATE FIELD IF
					//                 THE ACCOUNT REP WAS CHANGED TO SPEC FOR THIS PUB
					if (cbo_publog_acct_rep.Text.Trim() == "SPEC")
					{
						NewAvailEntry["publog_latest_change"] = DateTime.Parse(modAdminCommon.DateToday).ToString("d");
					}
				}

				if (Edit_Status == "Add")
				{
					NewAvailEntry["publog_entry_date"] = modAdminCommon.GetSystemDateTime();
				}

				NewAvailEntry["publog_update_date"] = modAdminCommon.GetSystemDateTime();
				errMsg = "update";
				NewAvailEntry.Update();

				NewAvailEntry.Close();
				NewAvailEntry = null;

				if (Edit_Status == "Add")
				{

					// 01/29/2016 - By David D. Cruger
					// Per Jackie; add an automatic journal note when added pubs

					frm_Journal.DefInstance.Clear_Journal_Form();
					modAdminCommon.Rec_Journal_Info.journ_subject = $"Add {cbo_publog_source.Text} PUB";
					modAdminCommon.Rec_Journal_Info.journ_description = " ";
					modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(Double.Parse(($"{txt_publog_Ac_id.Text} ").Trim()));
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = temp_pubnote_type;
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
					modAdminCommon.Rec_Journal_Info.journ_status = "A";

					PubJournID = frm_Journal.DefInstance.Commit_Journal_Entry();

					MessageBox.Show("Pub Record Added.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

				}
				else
				{
					modAdminCommon.Record_Event("Pub", $"Updated Pub - {cbo_publog_source.Text} PubId: {Convert.ToString(NewRecs["Publog_id"])}", Convert.ToInt32(Double.Parse(txt_publog_Ac_id.Text)), 0, 0, false, 0, 0);
					MessageBox.Show("Pub Record Updated.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				errMsg = "journ";
				if (AcctRepChanged && (Edit_Status != "Add"))
				{

					modAdminCommon.Rec_Journal_Info.journ_subject = $"Pub Acct Rep Changed From {RememberAcctRep} To {cbo_publog_acct_rep.Text}";
					modAdminCommon.Rec_Journal_Info.journ_description = " ";
					modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(Double.Parse(txt_publog_Ac_id.Text));
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
					modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
					modAdminCommon.Rec_Journal_Info.journ_status = "A";

					PubJournID = frm_Journal.DefInstance.Commit_Journal_Entry();

					if (PubJournID > 0)
					{
						frm_Journal.DefInstance.Reference_Journal_ID = PubJournID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						frm_Journal.DefInstance.ShowDialog();
					}

				}

				errMsg = "new pubs";
				// RTW - 4/19/07 - CHANGE TO NOT REPAINT IF ACCOUNT REP CHANGED
				if (!AcctRepChanged)
				{
					// 01/29/2016 - Only Repaint if Add
					// Do Not Repaint On Save
					if (Edit_Status == "Add")
					{
						Get_New_Pubs(Convert.ToString(grd_NewAvail.Tag));
					}
				}
				else
				{
					// ACCOUNT REP HAS CHANGED
					grd_NewAvail.CurrentColumnIndex = 0;

					grd_NewAvail.CellFontBold = true;

				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Update_Pub_Error: AC_id:{txt_publog_Ac_id.Text.Trim()} {excep.Message} {errMsg}");
			}

		}

		public void mnuViewSelectedPub_Click(Object eventSender, EventArgs eventArgs)
		{

			string strPub = "";

			int lRow1 = grd_NewAvail.CurrentRowIndex;
			int lCol1 = grd_NewAvail.CurrentColumnIndex;
			grd_NewAvail.Tag = "";

			if (lRow1 > 0)
			{

				if (grd_NewAvail.RowSel == lRow1)
				{

					strPub = ($"{Convert.ToString(grd_NewAvail[lRow1, 0].Value)} ").Trim();

					grd_NewAvail.Tag = strPub;

					Get_New_Pubs(Convert.ToString(grd_NewAvail.Tag));

				} // If grd_NewAvail.RowSel = lRow1 Then

			} // If lRow1 > 0 Then

		} // mnuViewSelectedPub_Click

		private void tab_NewAvail_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			pnl_update_pub.Visible = false;

			lbl_gen[40].Tag = "";

			//If Trim(gbl_User_ID) = "mvit" Then
			cmd_pub[10].Visible = true;
			//End If


			if (cbo_pub[10].Items.Count == 0)
			{
				Fill_Timezones();
			}


			if (SSTabHelper.GetSelectedIndex(tab_NewAvail) == 1)
			{
				frame_Details.Visible = false;
			}
			else if (SSTabHelper.GetSelectedIndex(tab_NewAvail) == 2)
			{ 

				if (cbo_pub[0].Text.Trim() == "")
				{
					cbo_pub[1].Items.Clear();
					cbo_pub[1].AddItem("C - Cleared");
					cbo_pub[1].AddItem("N - No Action Required");
					cbo_pub[1].AddItem("O - Open");
					cbo_pub[1].AddItem("I - In Progress");

					cbo_pub[1].AddItem("1st Attempt");
					cbo_pub[1].AddItem("2nd Attempt");
					cbo_pub[1].AddItem("3rd Attempt");

					cbo_pub[1].AddItem("H - Hold");
					cbo_pub[1].AddItem("Z - Completed");

					Fill_AC_Status_Drop_Down(cbo_pub[status_drop], "");
					cbo_pub[status_drop].Text = "All";
					//Call fill_account_rep(cbo_pub(3))
					fill_account_rep(cbo_pub[0]);


				}

				if (modAdminCommon.gbl_User_ID.Trim() == "mvit" || modAdminCommon.gbl_User_ID.Trim() == "jkc")
				{
					cmd_pub[7].Visible = true;
				}

			}
			else if (SSTabHelper.GetSelectedIndex(tab_NewAvail) == 3)
			{ 

				if (!grd_pub2.Visible)
				{
					cmd_pub_Click(cmd_pub[14], new EventArgs());
				}
			}

			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			// added MSw - 9/14/23
			if (SSTabHelper.GetSelectedIndex(tab_NewAvail) != last_tab)
			{ // if we have changed the tab- re do it
				load_pub_sources(true);
			}
			Application.DoEvents();
			last_tab = SSTabHelper.GetSelectedIndex(tab_NewAvail);
			Application.DoEvents();
			Application.DoEvents();
			tab_NewAvailPreviousTab = tab_NewAvail.SelectedIndex;
		}

		private void txt_pub_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txt_pub, eventSender);



			if (Index == 6)
			{
				assign_correct_account_rep();
			}


		}

		private void txt_publog_Ac_id_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (Information.IsNumeric(txt_publog_Ac_id.Text.Trim()))
			{
				Get_New_Aircraft_Info(Convert.ToInt32(Double.Parse(txt_publog_Ac_id.Text)));
			}

		}

		private void Browse_ASO_New()
		{
			string tmp_Year = "";
			// ********************************************************



			ADORecordSetHelper NewAvailEntry = null;
			string PageData = ""; // STRING TO HOLD PAGE BEING PROCESSED
			string tmp_href = ""; // STRING STORING URL LINK TO WEB PAGE FOR A RECORD
			int Marker = 0; // MARKERS FOR FINDING INFORMATION ON WEB PAGE
			int Marker1 = 0;
			int StartMarker = 0;
			string EndMarker = "";
			string Query = ""; // USED TO SPECIFY THE QUERY TO BE RUN
			string tmp_SearchType = ""; // IDENTIFIES THE SPECIFIC TYPE OF SEARCH IF
			// THERE ARE MULTIPLE SEARCH TYPES FOR A GIVE SITE
			string tmp_ChangeField = "";
			string Separator = "";
			DialogResult Dup_Response = (DialogResult) 0; //aey 8/12/04
			string Msg = "";
			string strMake = "";
			int K = 0;
			int Publog_id = 0;
			string pubDate = "";

			string errMsg = "init";
			WbBrowser.Visible = true;
			int new_reports = 0; // COUNTER FOR THE TOTAL NUMBER OF AIRCRAFT LISTINGS THAT ARE CONSIDERED NEW
			int report_counter = 0; // COUNTER FOR TOTAL NUMBER OF AIRCRAFT LISTINGS REVIEWED
			int report_found = 0; // COUNTER FOR THE TOTAL NUMBER OF AIRCRAFT LISTING THAT MATCHED HOMEBASE AIRCRAFT
			cmd_GetAvail.Enabled = false;
			this.Cursor = Cursors.WaitCursor;

			// CREATE THE HEADER FOR THE EMAIL
			string str_Email = "<html><body><TABLE WIDTH='850' CELLPADDING=2 CELLSPACING=0 BORDER=1>"; // STRING STORING EMAIL TO BE SENT
			str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>";
			str_Email = $"{str_Email}ASO PROCESSING REPORT FOR {modAdminCommon.DateToday} LAST {txt_NumDays.Text} DAY(S)<br></TR>";

			txt_status.Text = "Retrieving ASO Reports ....";
			Application.DoEvents();



			string tmp_url = "";

			try
			{

				// PERFORM 4 SEPARATE WEB PAGE SEARCHES
				string tmp_RegNo = "";
				string tmp_RegNoAlt = "";
				string tmp_SerialNo = "";
				string tmp_SerialNoAlt = "";
				string tmp_AFTT = "";
				string tmp_Make = "";
				string tmp_HomeBase_Make = "";
				string tmp_Picture = "";
				string tmp_Price = "";
				string tmp_Description = "";
				string tmp_OriginalDescription = "";
				string tmp_ASO_ID = "";
				string tmp_AC_ID = "";
				string ACREP = "";
				string searchtext = "";
				string[] fields = null;
				StringBuilder TempString = new StringBuilder();
				ADORecordSetHelper ACRecord = null;
				ADORecordSetHelper CheckAvail = null;
				throw new NotImplementedException("GAP-Note: This method must be checked first since some lines of webbrowser.document.all must be analyzed to check the equivalent in Blazor. See gap-notes inside the next for.See typeid, sortid and updatedays");
				for (int webpage = 1; webpage <= 6; webpage++)
				{
					errMsg = $"webpage {webpage.ToString()} ";
					// NAVIGATE TO THE MAIN ASO SEARCH PAGE FIRST
					WbBrowser.Navigate(new Uri("http://www.aso.com/i.aso3/latest.jsp?iaso3sid=1"));

					do 
					{
						Application.DoEvents();
					}
					while(!((!WbBrowser.IsBusy) || bTryinToUnload));

					//UPGRADE_TODO: (1067) Member Title is not defined in type object(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					if (Convert.ToString(WbBrowser.Document.Title).Trim() != "Cannot find server")
					{

						errMsg = $"webpag# {webpage.ToString()} ";
						// SET THE COMBO BOX VALUE FOR THE TYPE OF AIRCRAFT TO SEARCH FOR
						switch(webpage)
						{
							case 1 :  // GET BUSINESS JETS 
								Application.DoEvents(); 
								//UPGRADE_TODO: (1067) Member All is not defined in type object(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
								//WbBrowser.Document.All.typeid.Value = "4";  //gap-note the property typeid must be checked during blazor stabilization
								str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>"; 
								str_Email = $"{str_Email}BUSINESS JETS<br></TR>"; 
								tmp_SearchType = "BUSINESS JETS"; 
								txt_status.Text = $"Retrieving {tmp_SearchType}"; 
								Airframe_Type = "F"; 
								Application.DoEvents(); 
								 
								break;
							case 2 :  // GET BUSINESS TURBO PROPS 
								Application.DoEvents(); 
								//UPGRADE_TODO: (1067) Member All is not defined in type object(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
								//WbBrowser.Document.All.typeid.Value = "3"; //gap-note the property typeid must be checked during blazor stabilization
								str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>"; 
								str_Email = $"{str_Email}BUSINESS TURBO PROPS<br></TR>"; 
								tmp_SearchType = "BUSINESS TURBP PROPS"; 
								txt_status.Text = $"Retrieving {tmp_SearchType}"; 
								Airframe_Type = "F"; 
								Application.DoEvents(); 
								 
								break;
							case 3 :  // GET PROPS 
								Application.DoEvents(); 
								//UPGRADE_TODO: (1067) Member All is not defined in type object(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
								//WbBrowser.Document.All.typeid.Value = "2"; //gap-note the property typeid must be checked during blazor stabilization
								str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>"; 
								str_Email = $"{str_Email}MULTI ENGINE PROP<br></TR>"; 
								tmp_SearchType = "MULTI ENGINE PROP"; 
								txt_status.Text = $"Retrieving {tmp_SearchType}"; 
								Airframe_Type = "F"; 
								Application.DoEvents(); 
								 
								break;
							case 4 :  // GET BUSINESS TURBO PROPS 
								Application.DoEvents();
								//UPGRADE_TODO: (1067) Member All is not defined in type object(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
								//WbBrowser.Document.All.typeid.Value = "10"; //gap-note the property typeid must be checked during blazor stabilization
								str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>"; 
								str_Email = $"{str_Email}LARGE TRANSPORT JET<br></TR>"; 
								tmp_SearchType = "LARGE TRANSPORT JET"; 
								txt_status.Text = $"Retrieving {tmp_SearchType}"; 
								Airframe_Type = "F"; 
								Application.DoEvents(); 
								break;
							case 5 :  // GET Piston Helicopter 
								//aey helicopters added 6/10/05 
								Application.DoEvents(); 
								//UPGRADE_TODO: (1067) Member All is not defined in type object(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
								//WbBrowser.Document.All.typeid.Value = "12"; //gap-note the property typeid must be checked during blazor stabilization
								//http://www.aso.com/i.aso3/search.jsp?iaso3sid=1&searchid=5391698&typeid=12&regionid=-1&typeid=12&mmgid=-1&modelgroup=false 
								str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>"; 
								str_Email = $"{str_Email}PISTON HELICOPTER<br></TR>"; 
								tmp_SearchType = "PISTON HELICOPTER"; 
								txt_status.Text = $"Retrieving {tmp_SearchType}"; 
								Airframe_Type = "R"; 
								Application.DoEvents(); 
								break;
							case 6 :  // GET turbine Helicopter 
								Application.DoEvents();
								//UPGRADE_TODO: (1067) Member All is not defined in type object(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
								//WbBrowser.Document.All.typeid.Value = "6"; //gap-note the property typeid must be checked during blazor stabilization
								str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>"; 
								str_Email = $"{str_Email}TURBINE HELICOPTER<br></TR>"; 
								tmp_SearchType = "TURBINE HELICOPTER"; 
								txt_status.Text = $"Retrieving {tmp_SearchType}"; 
								Airframe_Type = "R"; 
								Application.DoEvents(); 
								break;
						}

						errMsg = "days";
						// HANDLE THE NUMBER OF DAYS FOR THE SEARCH
						// NEW ASO ONLY HANDLES 1 AND 3 IF PRODUCING A RAW LIST OF AIRCRAFT
						if (txt_NumDays.Text == "1")
						{
							//UPGRADE_TODO: (1067) Member All is not defined in type object(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							//WbBrowser.Document.All.update_days.Options(0).Selected = true;//gap-note the property update_days must be checked during blazor stabilization
						}
						if (txt_NumDays.Text == "3")
						{
							//UPGRADE_TODO: (1067) Member All is not defined in type object(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							//WbBrowser.Document.All.update_days.Options(1).Selected = true;//gap-note the property update_days must be checked during blazor stabilization
						}
						if (txt_NumDays.Text == "5")
						{
							//UPGRADE_TODO: (1067) Member All is not defined in type object(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							//WbBrowser.Document.All.update_days.Options(2).Selected = true;//gap-note the property update_days must be checked during blazor stabilization
						}

						if (txt_NumDays.Text != "1" && txt_NumDays.Text != "3" && txt_NumDays.Text != "5")
						{
							MessageBox.Show("Only 1 ,3, or 5 are allowed for ASO. Aborting Process", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							return;
						}
						Application.DoEvents();

						// SET THE SORT APPROACH TO MAKE, MODEL, PRICE (STANDARD)
						//UPGRADE_TODO: (1067) Member All is not defined in type object(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						//WbBrowser.Document.All.sort_id.Value = "1";//gap-note the property sort_id must be checked during blazor stabilization
						Application.DoEvents();

						// NAVIGATE TO THE PAGE
						WbBrowser.Navigate(new Uri("javascript:submitForm()"));
						do 
						{
							Application.DoEvents();
						}
						while(!((!WbBrowser.IsBusy) || bTryinToUnload));

					}

					//UPGRADE_TODO: (1067) Member body is not defined in type object(...). More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					PageData = Convert.ToString(WbBrowser.Document.Body.InnerHtml);
					//MsgBox (vtext)

					// PUT IN THE DATA HEADER
					str_Email = $"{str_Email}<TR align='center'><td><B>AC ID</B></td><td><B>REG NO</B></td>";
					str_Email = $"{str_Email}<td><B>SERIAL#</B></td><td><B>MAKE-MODEL#</B></td><td><B>PRICE</B></td>";
					str_Email = $"{str_Email}<td><B>AFTT</B></td><td><B>Match</B></td></tr>";

					Application.DoEvents();

					// TEMPORARY FIELDS FOR STORING DATA FROM WEB PAGE

					if (!(PageData.IndexOf("No Aircraft Found") >= 0))
					{

						errMsg = "pagedata";
						// PROCESS THE PAGE UNTIL IT IS EMPTY

						while(Strings.Len(PageData.Trim()) >= 0)
						{

							// FIND PICTURE VALUE
							searchtext = $"<TD vAlign=texttop noWrap align=right width={"\""}5%{"\""}>";
							Marker = (PageData.IndexOf(searchtext, StringComparison.CurrentCultureIgnoreCase) + 1);

							if (Marker == 0)
							{
								break;
							}
							PageData = PageData.Substring(Math.Min(Marker + Strings.Len(searchtext) - 1, PageData.Length), Math.Min(Strings.Len(PageData) - (Marker + Strings.Len(searchtext)), Math.Max(0, PageData.Length - (Marker + Strings.Len(searchtext) - 1))));

							// GET A ROW - ASSUMED TO BE AN AIRCRAFT LISTING
							searchtext = "</TR>";
							Marker = (PageData.IndexOf(searchtext, StringComparison.CurrentCultureIgnoreCase) + 1);

							// STORE THE ROW IN A TEMPORARY STRING
							TempString = new StringBuilder(PageData.Substring(0, Math.Min(Marker - 1, PageData.Length)));

							// STRIP THE ROW OFF OF THE CONTENT TO REDUCE THE PAGE SIZE TO LOOK THROUGH
							PageData = PageData.Substring(Math.Min(Marker + 4, PageData.Length), Math.Min(Strings.Len(PageData) - (Marker + 5), Math.Max(0, PageData.Length - (Marker + 4))));

							fields = TempString.ToString().Split(new string[]{"<TD"}, StringSplitOptions.None);

							errMsg = "parse";
							int tempForEndVar2 = fields.GetUpperBound(0);
							for (int i = 0; i <= tempForEndVar2; i++)
							{
								fields[i] = StringsHelper.Replace(fields[i], "</TD>", "", 1, -1, CompareMethod.Binary);
								fields[i] = StringsHelper.Replace(fields[i], "&nbsp;", "", 1, -1, CompareMethod.Binary);
								fields[i] = StringsHelper.Replace(fields[i], Environment.NewLine, "", 1, -1, CompareMethod.Binary);
								fields[i] = StringsHelper.Replace(fields[i], "\r", "", 1, -1, CompareMethod.Binary);
								switch(i)
								{
									case 0 :  // HAVE THE IMAGE 
										if (fields[i].ToUpper().IndexOf(("Photo").ToUpper()) >= 0)
										{
											tmp_Picture = "Photo";
										} 
										if (fields[i].ToUpper().IndexOf(("Brief ad").ToUpper()) >= 0)
										{
											tmp_Picture = "Brief";
										} 
										 
										break;
									case 1 : 
										// ID/AIRCRAFT 
										// GET THE MAKE AND THE YEAR 
										Marker = (fields[i].IndexOf($"-1{"\""}>") + 1); 
										// STORED THE END MARKER SINCE THIS REPRESENTS THE END OF THE 
										// URL FOR THE AIRCRAFT TO BE USED LATER 
										EndMarker = Marker.ToString(); 
										tmp_Make = fields[i].Substring(Math.Min(Marker + 3, fields[i].Length), Math.Min(Strings.Len(fields[i]) - Marker, Math.Max(0, fields[i].Length - (Marker + 3)))).Trim(); 
										tmp_Make = StringsHelper.Replace(tmp_Make, "</A>", "", 1, -1, CompareMethod.Binary); 
										tmp_Year = tmp_Make.Substring(0, Math.Min(4, tmp_Make.Length)); 
										tmp_Make = tmp_Make.Substring(Math.Min(4, tmp_Make.Length), Math.Min(Strings.Len(tmp_Make) - 4, Math.Max(0, tmp_Make.Length - 4))); 

										 
										K = (tmp_Make.IndexOf('\'') + 1); 
										if (K > 1)
										{
											tmp_Make = tmp_Make.Substring(Math.Min(0, tmp_Make.Length), Math.Min(K - 1, Math.Max(0, tmp_Make.Length)));
										} 
										tmp_Make = ($"{StringsHelper.Replace(tmp_Make, "'", "", 1, -1, CompareMethod.Binary)}").Trim(); 
										// GET THE URL LINK TO THE AIRCRAFT 
										Marker = (fields[i].IndexOf("<A href=") + 1); 
										tmp_url = fields[i].Substring(Math.Min(Marker + 8, fields[i].Length), Math.Min(Convert.ToInt32(Double.Parse(EndMarker) - Marker - 4), Math.Max(0, fields[i].Length - (Marker + 8)))); 
										 
										tmp_ASO_ID = ""; 
										break;
									case 2 : 
										// PRICE 
										Marker = (fields[i].IndexOf('>') + 1); 
										tmp_Price = fields[i].Substring(Math.Min(Marker, fields[i].Length), Math.Min(Strings.Len(fields[i]) - Marker, Math.Max(0, fields[i].Length - Marker))).Trim(); 
										if (Information.IsNumeric(tmp_Price.Trim()))
										{
											tmp_Price = $"${Strings.FormatNumber(tmp_Price.Trim(), 0, TriState.False, TriState.False, TriState.True)}";
										}
										else
										{
											tmp_Price = tmp_Price.ToUpper();
										} 
										tmp_Price = ($"{tmp_Price}").Trim(); 
										 
										break;
									case 3 : 
										// TTAF 
										Marker = (fields[i].IndexOf('>') + 1); 
										tmp_AFTT = fields[i].Substring(Math.Min(Marker, fields[i].Length), Math.Min(Strings.Len(fields[i]) - Marker, Math.Max(0, fields[i].Length - Marker))).Trim(); 
										 
										if (Information.IsNumeric(tmp_AFTT.Trim()))
										{
											tmp_AFTT = Strings.FormatNumber(tmp_AFTT.Trim(), 0, TriState.False, TriState.False, TriState.True);
										} 
										tmp_AFTT = ($"{StringsHelper.Replace(tmp_AFTT, ",", "", 1, -1, CompareMethod.Binary)}").Trim(); 
										 
										break;
									case 4 : 
										// STATE / LOCATION 
										break;
									case 5 : 
										// REGISTRATION NUMBER 
										Marker = (fields[i].IndexOf('>') + 1); 
										tmp_RegNo = ($"{fields[i].Substring(Math.Min(Marker, fields[i].Length), Math.Min(Strings.Len(fields[i]) - Marker, Math.Max(0, fields[i].Length - Marker)))}").Trim(); 
										tmp_RegNoAlt = StringsHelper.Replace(tmp_RegNo, "-", "", 1, -1, CompareMethod.Binary).Trim(); 
										//tmp_RegNo = fields(i) 
										 
										// If tmp_RegNo = "N350M" Then 
										// MsgBox "Found it" 
										// End If 
										break;
									case 6 : 
										// SERIAL NUMBER 
										//tmp_SerialNo = fields(i) 
										Marker = (fields[i].IndexOf('>') + 1); 
										tmp_SerialNo = ($"{fields[i].Substring(Math.Min(Marker, fields[i].Length), Math.Min(Strings.Len(fields[i]) - Marker, Math.Max(0, fields[i].Length - Marker)))}").Trim(); 
										 
										tmp_SerialNoAlt = StringsHelper.Replace($"{tmp_SerialNo}", "-", "", 1, -1, CompareMethod.Binary).Trim(); 
										break;
								}
							}

							errMsg = "tmpstring";
							TempString = new StringBuilder($"Price:{tmp_Price}{Environment.NewLine}REG#{tmp_RegNo}{Environment.NewLine}SER#{tmp_SerialNo}");
							TempString.Append($"{Environment.NewLine}Year:{tmp_Year}{Environment.NewLine}Model:{tmp_Make}");
							TempString.Append($"{Environment.NewLine}Price:{tmp_Price}{Environment.NewLine}TTF:{tmp_AFTT}");

							// BUILD THE DESCRIPTION FOR FUTURE REFERENCE
							tmp_OriginalDescription = $"{tmp_RegNo}~{tmp_Year.Trim()}~{tmp_Make.Trim()}~{tmp_AFTT}~{tmp_Price}~{tmp_SerialNo}";

							// DISPLAY THE STATUS TO SCREEN
							txt_status.Text = $"{tmp_SearchType}-REGNO:{tmp_RegNo}  SERIALNO:{tmp_SerialNo}";
							Application.DoEvents();
							HowMatched = "No Match";
							if (Strings.Len(tmp_RegNo.Trim()) > 0)
							{
								//  CHECK TO SEE IF HOMEBASE HAS A AIRCRAFT SPECIFICALLY ASSIGNED TO THIS REG NO
								ACRecord = new ADORecordSetHelper();
								Query = "select ac_id,ac_ser_no_full,amod_make_name,ac_year,ac_reg_no, amod_model_name ";
								Query = $"{Query}from aircraft,Aircraft_Model where ac_amod_id =amod_id ";
								Query = $"{Query}and (ac_reg_no ='N{tmp_RegNo.Trim()}'  or ac_reg_no='{tmp_RegNo.Trim()}'  ";
								Query = $"{Query} or ac_reg_no ='N{tmp_RegNoAlt.Trim()}'  or ac_reg_no='{tmp_RegNoAlt.Trim()}') ";
								Query = $"{Query}and ac_journ_id=0  and amod_airframe_type_code ='{Airframe_Type}' ";


								ACRecord.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
								if (!(ACRecord.BOF && ACRecord.EOF))
								{
									ACRecord.MoveLast();
									if (ACRecord.RecordCount == 1)
									{
										tmp_AC_ID = Convert.ToString(ACRecord["AC_ID"]);
										tmp_HomeBase_Make = $"{($"{Convert.ToString(ACRecord["amod_make_name"])} ").Trim()} {Convert.ToString(ACRecord["ac_ser_no_full"])}";
										report_found++;
										HowMatched = "RegNo 1 Rec";
										Application.DoEvents();
									}
									else
									{
										tmp_AC_ID = "";
										tmp_HomeBase_Make = "";
										if (Chk_Dups.CheckState == CheckState.Checked)
										{ //aey 7/8/05
											// if there are duplicate records, ask someone to choose among the duplicates
											ACRecord.MoveFirst();

											while(!ACRecord.EOF)
											{

												Msg = $"We found duplicate matches using RegNO within the JETNET database---{Environment.NewLine}{Environment.NewLine}";
												Msg = $"{Msg}WEB SITE MAKE: {tmp_Make.Trim()}, Year: {tmp_Year.Trim()}, Reg No: {tmp_RegNo.Trim()}, Serial#: {tmp_SerialNo.Trim()}{Environment.NewLine}{Environment.NewLine}";
												Msg = $"{Msg}HOMEBASE MAKE: {Convert.ToString(ACRecord["amod_make_name"])}, Year: {Convert.ToString(ACRecord["ac_year"])}, Reg No: {Convert.ToString(ACRecord["ac_reg_no"])}, Serial#: {Convert.ToString(ACRecord["ac_ser_no_full"])}, Model: {Convert.ToString(ACRecord["amod_model_name"])}{Environment.NewLine}{Environment.NewLine}";
												Msg = $"{Msg}Click Yes if this is a match, Cancel to stop prompting for duplicates";

												Dup_Response = System.Windows.Forms.DialogResult.No;
												if (Math.Abs(Conversion.Val($"{tmp_Year}") - Conversion.Val($"{Convert.ToString(ACRecord["ac_year"])}")) < Conversion.Val($"{txt_years_diff.Text}"))
												{
													Dup_Response = MessageBox.Show(Msg, "Found Duplicate Matches in Homebase", MessageBoxButtons.YesNoCancel);
												}

												if (Dup_Response == System.Windows.Forms.DialogResult.Yes)
												{ //match selected
													tmp_AC_ID = Convert.ToString(ACRecord["AC_ID"]);
													tmp_HomeBase_Make = $"{($"{Convert.ToString(ACRecord["amod_make_name"])} ").Trim()} {Convert.ToString(ACRecord["ac_ser_no_full"])}";
													report_found++;
													HowMatched = "RegNo User Select";
													break;
												}

												if (Dup_Response == System.Windows.Forms.DialogResult.Cancel)
												{ //quit prompting
													Chk_Dups.CheckState = CheckState.Unchecked;
													break;
												}

												ACRecord.MoveNext();
											};
										}

									}
								}
								else
								{
									tmp_AC_ID = "";
									tmp_HomeBase_Make = "";
								}
								ACRecord.Close();
								ACRecord = null;
							}
							else
							{
								// NO REG NO FOUND
								tmp_AC_ID = "";
								tmp_HomeBase_Make = "";
							} // CHECK FOR REG NO IN DATA

							tmp_Make = ($"{tmp_Make}").Trim(); //aey 8/12/04
							// strmake is used to further qualify the query
							K = (tmp_Make.IndexOf(' ') + 1);
							if (K > 0)
							{
								strMake = tmp_Make.Substring(Math.Min(K - 1, tmp_Make.Length)).Trim();
								K = (strMake.IndexOf(' ') + 1);
								if (K > 0)
								{
									strMake = strMake.Substring(Math.Min(0, strMake.Length), Math.Min(K, Math.Max(0, strMake.Length))).Trim();
								}
							}
							else
							{
								K = (tmp_Make.IndexOf(' ') + 1);
								if (K > 0)
								{
									strMake = tmp_Make.Substring(Math.Min(0, tmp_Make.Length), Math.Min(K, Math.Max(0, tmp_Make.Length))).Trim();
								}
							}

							if (Strings.Len(($"{tmp_SerialNo}").Trim()) > 0 && tmp_AC_ID == "")
							{
								//  CHECK TO SEE IF HOMEBASE HAS A AIRCRAFT SPECIFICALLY ASSIGNED TO THIS SERIAL NO
								Query = "select ac_id,ac_ser_no_full,amod_make_name,ac_year,ac_reg_no, amod_model_name ";
								Query = $"{Query}from aircraft,Aircraft_Model  where ac_amod_id =amod_id ";
								if (Information.IsNumeric($"{tmp_SerialNo}"))
								{
									Query = $"{Query}and (ac_ser_no_full ='{tmp_SerialNo.Trim()}'  or ";
									Query = $"{Query} ac_ser_no_value ={Conversion.Val(tmp_SerialNo).ToString()} or  ";
									Query = $"{Query} ac_ser_no_full ='{tmp_SerialNoAlt.Trim()}'  or ";
									Query = $"{Query} ac_ser_no_value ={Conversion.Val(tmp_SerialNoAlt).ToString()})  ";
								}
								else
								{
									Query = $"{Query}and (ac_ser_no_full ='{tmp_SerialNo.Trim()}'  ";
									Query = $"{Query} or ac_ser_no_full ='{tmp_SerialNoAlt.Trim()}')  ";
								}
								Query = $"{Query} and left(amod_make_name,5) = '{tmp_Make.Substring(0, Math.Min(5, tmp_Make.Length))}' ";
								Query = $"{Query}and ac_journ_id=0 ";
								Query = $"{Query}and amod_airframe_type_code ='{Airframe_Type}' ";

								ACRecord.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
								if (!(ACRecord.BOF && ACRecord.EOF))
								{
									ACRecord.MoveLast();
									if (ACRecord.RecordCount == 1)
									{
										tmp_AC_ID = Convert.ToString(ACRecord["AC_ID"]);
										tmp_HomeBase_Make = $"{($"{Convert.ToString(ACRecord["amod_make_name"])} ").Trim()} {Convert.ToString(ACRecord["ac_ser_no_full"])}";
										report_found++;
										HowMatched = "SerNo 1 Rec";
										Application.DoEvents();
									}
									else
									{
										// FOUND MORE THAN ONE AIRCRAFT WITH THE SERIAL NUMBER
										tmp_AC_ID = "";
										tmp_HomeBase_Make = "";

										if (Chk_Dups.CheckState == CheckState.Checked)
										{ //aey 8/11/04
											// if there are duplicate records, ask someone to choose among the duplicates
											ACRecord.MoveFirst();

											while(!ACRecord.EOF)
											{

												Msg = $"We found duplicate matches using SerNo/Make within the JETNET database---{Environment.NewLine}{Environment.NewLine}";
												Msg = $"{Msg}WEB SITE MAKE: {tmp_Make.Trim()}, Year: {tmp_Year.Trim()}, Reg No: {tmp_RegNo.Trim()}, Serial#: {tmp_SerialNo.Trim()}{Environment.NewLine}{Environment.NewLine}";
												Msg = $"{Msg}HOMEBASE MAKE: {Convert.ToString(ACRecord["amod_make_name"])}, Year: {Convert.ToString(ACRecord["ac_year"])}, Reg No: {Convert.ToString(ACRecord["ac_reg_no"])}, Serial#: {Convert.ToString(ACRecord["ac_ser_no_full"])}, Model: {Convert.ToString(ACRecord["amod_model_name"])}{Environment.NewLine}{Environment.NewLine}";
												Msg = $"{Msg}Click Yes if this is a match, Cancel to stop prompting for duplicates";

												Dup_Response = System.Windows.Forms.DialogResult.No;
												if (Math.Abs(Conversion.Val($"{tmp_Year}") - Conversion.Val($"{Convert.ToString(ACRecord["ac_year"])}")) < Conversion.Val($"{txt_years_diff.Text}"))
												{
													Dup_Response = MessageBox.Show(Msg, "Found Duplicate Matches in Homebase", MessageBoxButtons.YesNoCancel);
												}

												//Dup_Response = MsgBox(Msg, vbYesNoCancel, "Found Duplicate Matches in Homebase")

												if (Dup_Response == System.Windows.Forms.DialogResult.Yes)
												{ //match selected
													tmp_AC_ID = Convert.ToString(ACRecord["AC_ID"]);
													tmp_HomeBase_Make = $"{($"{Convert.ToString(ACRecord["amod_make_name"])} ").Trim()} {Convert.ToString(ACRecord["ac_ser_no_full"])}";
													report_found++;
													HowMatched = "SerNo User Select";
													break;
												}

												if (Dup_Response == System.Windows.Forms.DialogResult.Cancel)
												{ //quit prompting
													Chk_Dups.CheckState = CheckState.Unchecked;
													break;
												}

												ACRecord.MoveNext();
											};
										}
									}
								}
								else
								{
									// NO HOMEBASE AIRCRAFT FOUND
									tmp_AC_ID = "";
									tmp_HomeBase_Make = "";
								} // CHECK FOR MATCHING HOMEBASE AIRCRAFT
								ACRecord.Close();
								ACRecord = null;

							}

							//>>>> if it still does not match, exclude Make and try again
							if (Strings.Len(($"{tmp_SerialNo}").Trim()) > 0 && tmp_AC_ID == "")
							{
								//  CHECK TO SEE IF HOMEBASE HAS A AIRCRAFT SPECIFICALLY ASSIGNED TO THIS SERIAL NO
								Query = "select ac_id,ac_ser_no_full,amod_make_name,ac_year,ac_reg_no, amod_model_name ";
								Query = $"{Query}from aircraft,Aircraft_Model  where ac_amod_id =amod_id ";
								if (Information.IsNumeric($"{tmp_SerialNo}"))
								{
									Query = $"{Query}and (ac_ser_no_full ='{tmp_SerialNo.Trim()}'  or ";
									Query = $"{Query} ac_ser_no_value ={Conversion.Val(tmp_SerialNo).ToString()} or  ";
									Query = $"{Query} ac_ser_no_full ='{tmp_SerialNoAlt.Trim()}'  or ";
									Query = $"{Query} ac_ser_no_value ={Conversion.Val(tmp_SerialNoAlt).ToString()})  ";
								}
								else
								{
									Query = $"{Query}and (ac_ser_no_full ='{tmp_SerialNo.Trim()}'  ";
									Query = $"{Query} or ac_ser_no_full ='{tmp_SerialNoAlt.Trim()}')  ";
								}
								//Query = Query & " and left(amod_make_name,5) = '" & left(tmp_Make, 5) & "' "
								Query = $"{Query}and ac_journ_id=0  and amod_airframe_type_code ='{Airframe_Type}' ";

								ACRecord.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
								if (!(ACRecord.BOF && ACRecord.EOF))
								{
									ACRecord.MoveLast();
									if (ACRecord.RecordCount == 1)
									{
										tmp_AC_ID = Convert.ToString(ACRecord["AC_ID"]);
										tmp_HomeBase_Make = $"{($"{Convert.ToString(ACRecord["amod_make_name"])} ").Trim()} {Convert.ToString(ACRecord["ac_ser_no_full"])}";
										report_found++;
										HowMatched = "SerNo 1 Rec";
										Application.DoEvents();
									}
									else
									{
										// FOUND MORE THAN ONE AIRCRAFT WITH THE SERIAL NUMBER
										tmp_AC_ID = "";
										tmp_HomeBase_Make = "";

										if (Chk_Dups.CheckState == CheckState.Checked)
										{ //aey 8/11/04
											// if there are duplicate records, ask someone to choose among the duplicates
											ACRecord.MoveFirst();

											while(!ACRecord.EOF)
											{

												Msg = $"We found duplicate matches using SerNo within the JETNET database---{Environment.NewLine}{Environment.NewLine}";
												Msg = $"{Msg}WEB SITE MAKE: {tmp_Make.Trim()}, Year: {tmp_Year.Trim()}, Reg No: {tmp_RegNo.Trim()}, Serial#: {tmp_SerialNo.Trim()}{Environment.NewLine}{Environment.NewLine}";
												Msg = $"{Msg}HOMEBASE MAKE: {Convert.ToString(ACRecord["amod_make_name"])}, Year: {Convert.ToString(ACRecord["ac_year"])}, Reg No: {Convert.ToString(ACRecord["ac_reg_no"])}, Serial#: {Convert.ToString(ACRecord["ac_ser_no_full"])}, Model: {Convert.ToString(ACRecord["amod_model_name"])}{Environment.NewLine}{Environment.NewLine}";
												Msg = $"{Msg}Click Yes if this is a match, Cancel to stop prompting for duplicates";

												Dup_Response = System.Windows.Forms.DialogResult.No;
												if (Math.Abs(Conversion.Val($"{tmp_Year}") - Conversion.Val($"{Convert.ToString(ACRecord["ac_year"])}")) < Conversion.Val($"{txt_years_diff.Text}"))
												{
													Dup_Response = MessageBox.Show(Msg, "Found Duplicate Matches in Homebase", MessageBoxButtons.YesNoCancel);
												}

												//Dup_Response = MsgBox(Msg, vbYesNoCancel, "Found Duplicate Matches in Homebase")

												if (Dup_Response == System.Windows.Forms.DialogResult.Yes)
												{ //match selected
													tmp_AC_ID = Convert.ToString(ACRecord["AC_ID"]);
													tmp_HomeBase_Make = $"{($"{Convert.ToString(ACRecord["amod_make_name"])} ").Trim()} {Convert.ToString(ACRecord["ac_ser_no_full"])}";
													report_found++;
													HowMatched = "SerNo User Select";
													break;
												}

												if (Dup_Response == System.Windows.Forms.DialogResult.Cancel)
												{ //quit prompting
													Chk_Dups.CheckState = CheckState.Unchecked;
													break;
												}

												ACRecord.MoveNext();
											};
										}
									}
								}
								else
								{
									// NO HOMEBASE AIRCRAFT FOUND
									tmp_AC_ID = "";
									tmp_HomeBase_Make = "";
								} // CHECK FOR MATCHING HOMEBASE AIRCRAFT
								ACRecord.Close();
								ACRecord = null;

							}

							// INCREMENT TOTAL LISTINGS REVIEWED
							report_counter++;

							errMsg = "select";
							// IF THE AIRCRAFT WAS FOUND IN HOMEBASE THEN SEE IF IT IS ARLEADY
							// IN THE NEW AVAILABLES LOG
							if (Strings.Len(($"{tmp_AC_ID}").Trim()) > 0)
							{
								CheckAvail = new ADORecordSetHelper();


								Query = $"select * from Publication_Log  where publog_source = 'ASO'  and publog_entry_date >= '{DateTimeHelper.ToString(DateTime.Parse(modAdminCommon.DateToday).AddDays(-30))}' ";

								//COMPARE REG NO AND MAKE TO DETERMINE IF WE'VE SEEN THIS PUB BEFORE
								Query = $"{Query}AND publog_original_desc LIKE '{tmp_RegNo.Trim()}~{tmp_Year.Trim()}~{tmp_Make.Trim()}%' ";

								Query = $"{Query}AND (upper(publog_reg_no) ='{tmp_RegNo.ToUpper()}' or upper(publog_reg_no) ='N{tmp_RegNo.ToUpper()}' ";
								Query = $"{Query}or upper(publog_reg_no) ='{tmp_RegNoAlt.ToUpper()}' ";
								Query = $"{Query}or upper(publog_reg_no) ='N{tmp_RegNoAlt.ToUpper()}')  AND publog_price= '{tmp_Price}' ";
								if (Strings.Len(tmp_AFTT.Trim()) > 0 && Information.IsNumeric(tmp_AFTT))
								{
									Query = $"{Query}AND (publog_aftt = '{StringsHelper.Replace(tmp_AFTT, ",", "", 1, -1, CompareMethod.Binary)}'  or replace(publog_aftt,',','') = '{StringsHelper.Replace(tmp_AFTT, ",", "", 1, -1, CompareMethod.Binary)}')  ";
								}
								errMsg = "chk_avail";
								Publog_id = 0;
								if (!modAdminCommon.Exist(Query))
								{

									// NO RECORD IN THE NEWLY AVAILABLE LOG SO ENTER ONE
									errMsg = "no-new avali";
									NewAvailEntry = new ADORecordSetHelper();
									NewAvailEntry.Open("select * from Publication_Log where publog_id = -1", modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
									//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_ISSUE: (2064) ADODB.Recordset method NewAvailEntry.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									if (NewAvailEntry.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
									{
										NewAvailEntry.AddNew();
										NewAvailEntry["publog_source"] = "ASO";
										NewAvailEntry["publog_ac_id"] = Conversion.Val($"{tmp_AC_ID}");
										NewAvailEntry["publog_reg_no"] = ($"{tmp_RegNo}").Trim().Substring(0, Math.Min(15, ($"{tmp_RegNo}").Trim().Length));
										NewAvailEntry["publog_ser_no"] = ($"{tmp_SerialNo}").Trim().Substring(0, Math.Min(25, ($"{tmp_SerialNo}").Trim().Length));
										pubDate = modAdminCommon.GetSystemDateTime();
										NewAvailEntry["publog_entry_date"] = pubDate;
										NewAvailEntry["publog_description"] = $"{tmp_Year.Trim()} {($"{tmp_Make}").Trim()}";
										NewAvailEntry["publog_original_desc"] = ($"{tmp_OriginalDescription}").Substring(0, Math.Min(120, ($"{tmp_OriginalDescription}").Length));
										// IF THERE IS A CAMERA IMAGE OR A SPECS IMAGE THEN THERE ARE LIKELY PICTURES
										if (tmp_Picture.Trim() == "Photo")
										{
											NewAvailEntry["publog_picture"] = "YES";
										}
										if (Strings.Len(($"{tmp_Price}").Trim()) > 0)
										{
											NewAvailEntry["publog_price"] = tmp_Price.Trim();
										}
										if (Strings.Len(($"{tmp_AFTT}").Trim()) > 0)
										{
											NewAvailEntry["publog_aftt"] = StringsHelper.Replace(tmp_AFTT, "'", "", 1, -1, CompareMethod.Binary).Trim();
										}
										tmp_href = $"{tmp_url}";
										//tmp_href = "http://www.aso.com/i.aso/AircraftView.jsp?aircraft_id=" & tmp_ASO_ID
										NewAvailEntry["publog_url"] = tmp_href.Trim();
										NewAvailEntry["publog_status"] = "N";
										NewAvailEntry["publog_acct_rep"] = GetACCTRep(Convert.ToInt32(Double.Parse(tmp_AC_ID)));
										NewAvailEntry.Update();
										// INCREMENT COUNTER FOR NEW REPORT FOUND AND ADDED
										new_reports++;
										Publog_id = Convert.ToInt32(Conversion.Val($"{modCommon.DLookUp("publog_id", "publication_log", $"publog_ac_id={Conversion.Val($"{tmp_AC_ID}").ToString()} and publog_entry_date='{pubDate}'")}"));
									}
									NewAvailEntry.Close();
									NewAvailEntry = null;
									errMsg = "email-2";
									// **************************************************
									// CREATE AN EMAIL LINE FOR FOUND RECORD
									str_Email = $"{str_Email}<tr>";
									str_Email = $"{str_Email}<td>&nbsp;{tmp_AC_ID}</td>";
									str_Email = $"{str_Email}<td>&nbsp;{tmp_RegNo}</td>";
									str_Email = $"{str_Email}<td>&nbsp;{tmp_SerialNo}</td>";

									if (Strings.Len(tmp_HomeBase_Make.Trim()) > 0)
									{
										str_Email = $"{str_Email}<td>&nbsp;<A HREF='{tmp_url}'>{tmp_HomeBase_Make}</a></td>";
									}
									else
									{
										str_Email = $"{str_Email}<td>&nbsp;<A HREF='{tmp_url}'>{tmp_Make}</a></td>";
									}
									str_Email = $"{str_Email}<td>&nbsp;{tmp_Price}</td>";
									str_Email = $"{str_Email}<td>&nbsp;{tmp_AFTT}</td>";
									//last column
									str_Email = $"{str_Email}<td>&nbsp;{HowMatched},pub_id:{Publog_id.ToString()}</td>";

									Application.DoEvents();
									//End If   ' IF WE FOUND A RECORD IN THE NEWLY AVAILABLE LOG
									// CheckAvail.Close
									CheckAvail = null;
								}
								else
								{
									errMsg = "email3";
									// **************************************************
									// CREATE AN EMAIL LINE FOR RECORDS NOT FOUND
									str_Email = $"{str_Email}<tr>";
									str_Email = $"{str_Email}<td>&nbsp;{tmp_AC_ID}</td>";
									str_Email = $"{str_Email}<td>&nbsp;{tmp_RegNo}</td>";
									str_Email = $"{str_Email}<td>&nbsp;{tmp_SerialNo}</td>";

									//tmp_href = "http://www.aso.com/i.aso/AircraftView.jsp?aircraft_id=" & tmp_ASO_ID
									if (Strings.Len(($"{tmp_HomeBase_Make}").Trim()) > 0)
									{
										str_Email = $"{str_Email}<td>&nbsp;<A HREF='{tmp_url}'>{tmp_HomeBase_Make}</a></td>";
									}
									else
									{
										str_Email = $"{str_Email}<td>&nbsp;<A HREF='{tmp_url}'>{tmp_Make}</a></td>";
									}
									str_Email = $"{str_Email}<td>&nbsp;{tmp_Price}</td>";
									str_Email = $"{str_Email}<td>&nbsp;{tmp_AFTT}</td>";
									//last column
									str_Email = $"{str_Email}<td>&nbsp;{HowMatched}</td>";

								} // IF WE HAVE AN AIRCRAFT IF

							}
							Application.DoEvents();
						};

					}


					PageData = "";

				} // GET THE NEXT WEB PAGE
				txt_status.Text = "DONE WITH PROCESSING";
				Application.DoEvents();
				errMsg = "email4";
				// **************************************************************
				// SEND THE EMAIL SUMMARY OF THE PROCESSING
				str_Email = $"{str_Email}<tr><td colspan=7>Total of {report_counter.ToString()} listings processed. Aircraft found {report_found.ToString()}. New Listings {new_reports.ToString()}.</td></tr>";
				str_Email = $"{str_Email}</body>";

				modEmail.EMail_Message("Homebase ASO", "jetnet@jetnet.com", txt_EMailAddress.Text, "", "", $"ASO Report Processing Summary for {modAdminCommon.DateToday}", str_Email, "", true);

				WbBrowser.Visible = false;
				MessageBox.Show($"Processing Complete! Found {report_found.ToString()} out of {report_counter.ToString()} listings.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			catch (Exception e)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				if (Information.Err().Number == 438)
				{
					Application.DoEvents();
					//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
					UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Statement");
				}
				modAdminCommon.Report_Error($"errBrowse_Error: br_aso_new {errMsg} {e.Message}");
				return;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		private void txt_years_diff_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Conversion.Val($"{txt_years_diff.Text}") < 0)
			{
				txt_years_diff.Text = "0";
			}

		}

		public void Browse_Controller_New()
		{
			string findit = "";
			int J = 0;
			string[] pagerows = null;
			int jj = 0;
			string RowData = "";
			string tmp = "";
			string tmp2 = "";
			string tmp_acrep = "";
			string tmp_CON_ID = "";
			string tmp_Description = "";
			string tmp_OriginalDescription = "";


			string errMsg = "";
			try
			{

				ADORecordSetHelper NewAvailEntry = null; // RECORDSET USED FOR ENTRY OF RECORDS INTO THE PUBLICATION LOG
				string PageData = ""; // STRING TO HOLD PAGE BEING PROCESSED
				string tmp_href = ""; // STRING STORING URL LINK TO WEB PAGE FOR A RECORD
				int Marker = 0; // MARKERS FOR FINDING INFORMATION ON WEB PAGE
				int EndMarker = 0; // MARKER USED TO IDENTIFY STRING ENDING POSITION
				string str_Email = ""; // STRING STORING EMAIL TO BE SENT
				string Query = ""; // USED TO SPECIFY THE QUERY TO BE RUN
				string tmp_SearchType = ""; // IDENTIFIES THE SPECIFIC TYPE OF SEARCH IF
				int report_counter = 0; // COUNTER FOR TOTAL NUMBER OF AIRCRAFT LISTINGS REVIEWED
				int report_found = 0; // COUNTER FOR THE TOTAL NUMBER OF AIRCRAFT LISTING THAT MATCHED HOMEBASE AIRCRAFT
				int new_reports = 0; // COUNTER FOR THE TOTAL NUMBER OF AIRCRAFT LISTINGS THAT ARE CONSIDERED NEW
				string tmp_ChangeField = ""; // STRING USED TO IDENTIFY IF SOMETHING HAS CHANGED FROM PREVIOUS ENTRIES IN THE PUB LOG

				string Separator = ""; // STRING USED FOR SEPARATING FIELDS
				bool isCharter = false; // FLAG USED TO INDICATE IF AN AIRCRAFT WAS LISTED AS A CHARTER
				int rowcount = 0; // INTEGER USED TO CYCLE THROUGH THE NUMBER OF ROWS OF LISTINGS ON A PAGE
				DialogResult Dup_Response = (DialogResult) 0; //aey 8/12/04
				string Msg = "";
				string strMake = "";
				int K = 0;
				string ControllerDate = "";

				int webStart = 0;
				int webEnd = 0;
				int Publog_id = 0;
				string pubDate = "";

				int NumPages = 0;


				webStart = 1;
				webEnd = 6;

				new_reports = 0;
				report_counter = 0;
				report_found = 0;
				cmd_GetAvail.Enabled = false;
				this.Cursor = Cursors.WaitCursor;

				// ********************************************************************
				// CREATE THE HEADER FOR THE EMAIL
				str_Email = "<html><body><TABLE WIDTH='850' CELLPADDING=2 CELLSPACING=0 BORDER=1>";
				str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>";
				str_Email = $"{str_Email}CONTROLLER PROCESSING REPORT FOR {modAdminCommon.DateToday} LAST {txt_NumDays.Text} DAY(S)<br></TR>";

				txt_status.Text = "Retrieving CONTROLLER Reports ....";
				Application.DoEvents();
				 // VARIABLE USED TO LOOP THROUGH THE CONTROLLER SEARCHES
				string tmp_url = ""; // STRING USED TO STORE THE URL TO BE RETRIEVED

				NumPages = 1;
				int tempForEndVar = webEnd;
				string tmp_Make = "";
				string tmp_Model = "";
				string tmp_Price = "";
				string tmp_Year = "";
				string tmp_Location = "";
				string tmp_Details = "";
				string tmp_text = "";
				string tmp_Seller = "";
				string tmp_Phone = "";
				string tmp_Fax = "";
				string tmp_RegNo = "";
				string tmp_RegNoAlt = "";
				string tmp_SerialNo = "";
				string tmp_SerialNoAlt = "";
				string tmp_AFTT = "";
				string tmp_Picture = "";
				string tmp_UpdateDate = "";
				string tmp_HomeBase_Make = "";
				string tmp_AC_ID = "";
				string ACREP = "";
				ADORecordSetHelper ACRecord = null;
				ADORecordSetHelper CheckAvail = null;
				string tmpCharterString = ""; // ACCOUNT REP ASSIGNED TO THE AC IN HOMEBASE // ID OF THE AC FOUND IN HOMEBASE // DESCRIPTION OF OF THE AC FOUND IN HOMEBASE // CONTROLLER UPDATE DATE // YES/NO FLAG INDICATING IF PICTURES ARE AVAILABLE
				for (int webpage = webStart; webpage <= tempForEndVar; webpage++)
				{
					errMsg = $"webpage {webpage.ToString()} ";

					switch(webpage)
					{
						case 1 :  // JETS 
							 
							NumPages = 1; 
							tmp_url = $"http://www.controller.com/list/list.aspx?bcatid=13&DidSearch=1&EID=1&LP=CNT&setype=1&ETID=1&catid=3&mdlx=Contains&LS=7&SO=7&btnSearch=Search&PG={NumPages.ToString()}"; 
							str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>"; 
							str_Email = $"{str_Email}JETS<br></TR>"; 
							tmp_SearchType = "JETS"; 
							Airframe_Type = "F"; 
							 
							break;
						case 2 :  // TURBO PROPS 
							 
							NumPages = 1; 
							tmp_url = $"http://www.controller.com/listings/forsale/List.asp?ShowAdvFields=&guid=D108B9AB3DDF4C34B5015285C5131F3E&etid=1&setype=1&catid=8&mantxt=&mdltxt=&MdlX=Contains&PF=&PT=&YF=&YT=&TTF=&TTT=&SN=&RN=&OverhaulTimeStart=&OverhaulTypeStart=&OverhaulTimeStart2=&OverhaulTypeStart2=&OverhaulTimeEnd=&OverhaulTypeEnd=&OverhaulTimeEnd2=&OverhaulTypeEnd2=&HotsectionTimeStart=&HotsectionTimeStart2=&HotsectionTimeEnd=&HotsectionTimeEnd2=&SeatNumber=&FlightRules=&YearPaintedFrom=&YearPaintedTo=&YearInteriorFrom=&YearInteriorTo=&LS=&SO=7&beginsearch=Search&PG={NumPages.ToString()}"; 
							 
							str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>"; 
							str_Email = $"{str_Email}TURBO PROPS<br></TR>"; 
							tmp_SearchType = "TURBO PROPS"; 
							Airframe_Type = "F"; 
							 
							break;
						case 3 :  // PISTON TWIN ENGINE 
							//  tmp_url = "http://www.controller.com/listings/forsale/List.asp?catid=9&LS=" & txt_NumDays & "&PG=1" 
							// tmp_url = "http://www.controller.com/listings/forsale/List.asp?guid=86F90F94FC634A8EB0218091A9738C1F&etid=1&setype=1&catid=9&mantxt=&mdltxt=&MdlX=Contains&PF=&PT=&YF=&YT=&TTF=&TTT=&SN=&RN=&LS=" & txt_NumDays & "&SO=2&beginsearch=Search" 
							NumPages = 1; 
							tmp_url = $"http://www.controller.com/listings/forsale/List.asp?ShowAdvFields=&guid=D108B9AB3DDF4C34B5015285C5131F3E&etid=1&setype=1&catid=9&mantxt=&mdltxt=&MdlX=Contains&PF=&PT=&YF=&YT=&TTF=&TTT=&SN=&RN=&OverhaulTimeStart=&OverhaulTypeStart=&OverhaulTimeStart2=&OverhaulTypeStart2=&OverhaulTimeEnd=&OverhaulTypeEnd=&OverhaulTimeEnd2=&OverhaulTypeEnd2=&HotsectionTimeStart=&HotsectionTimeStart2=&HotsectionTimeEnd=&HotsectionTimeEnd2=&SeatNumber=&FlightRules=&YearPaintedFrom=&YearPaintedTo=&YearInteriorFrom=&YearInteriorTo=&LS=&SO=7&beginsearch=Search&PG={NumPages.ToString()}"; 
							 
							str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>"; 
							str_Email = $"{str_Email}PISTON TWIN ENGINE<br></TR>"; 
							tmp_SearchType = "PISTON TWIN ENGINE"; 
							Airframe_Type = "F"; 
							 
							break;
						case 4 :  // PISTON AMPHIBIOUS 
							 
							NumPages = 1; 
							tmp_url = $"http://www.controller.com/listings/forsale/List.asp?ShowAdvFields=&guid=D108B9AB3DDF4C34B5015285C5131F3E&etid=1&setype=1&catid=1&mantxt=&mdltxt=&MdlX=Contains&PF=&PT=&YF=&YT=&TTF=&TTT=&SN=&RN=&OverhaulTimeStart=&OverhaulTypeStart=&OverhaulTimeStart2=&OverhaulTypeStart2=&OverhaulTimeEnd=&OverhaulTypeEnd=&OverhaulTimeEnd2=&OverhaulTypeEnd2=&HotsectionTimeStart=&HotsectionTimeStart2=&HotsectionTimeEnd=&HotsectionTimeEnd2=&SeatNumber=&FlightRules=&YearPaintedFrom=&YearPaintedTo=&YearInteriorFrom=&YearInteriorTo=&LS=&SO=7&beginsearch=Search&PG={NumPages.ToString()}"; 
							 
							str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>"; 
							str_Email = $"{str_Email}PISTON AMPHIBIOUS<br></TR>"; 
							tmp_SearchType = "PISTON AMPHIBIOUS"; 
							Airframe_Type = "F"; 
							 
							break;
						case 5 :  //turbine helicopter 
							 
							NumPages = 1; 
							tmp_url = $"http://www.controller.com/listings/forsale/List.asp?ShowAdvFields=&guid=D108B9AB3DDF4C34B5015285C5131F3E&etid=1&setype=1&catid=7&mantxt=&mdltxt=&MdlX=Contains&PF=&PT=&YF=&YT=&TTF=&TTT=&SN=&RN=&OverhaulTimeStart=&OverhaulTypeStart=&OverhaulTimeStart2=&OverhaulTypeStart2=&OverhaulTimeEnd=&OverhaulTypeEnd=&OverhaulTimeEnd2=&OverhaulTypeEnd2=&HotsectionTimeStart=&HotsectionTimeStart2=&HotsectionTimeEnd=&HotsectionTimeEnd2=&SeatNumber=&FlightRules=&YearPaintedFrom=&YearPaintedTo=&YearInteriorFrom=&YearInteriorTo=&LS=&SO=7&beginsearch=Search&PG={NumPages.ToString()}"; 
							str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>"; 
							str_Email = $"{str_Email}TURBINE HELICOPTER<br></TR>"; 
							tmp_SearchType = "TURBINE HELICOPTER"; 
							Airframe_Type = "R"; 
							 
							break;
						case 6 :  //piston helicopter 
							 
							NumPages = 1; 
							tmp_url = $"http://www.controller.com/listings/forsale/List.asp?ShowAdvFields=&guid=D108B9AB3DDF4C34B5015285C5131F3E&etid=1&setype=1&catid=5&mantxt=&mdltxt=&MdlX=Contains&PF=&PT=&YF=&YT=&TTF=&TTT=&SN=&RN=&OverhaulTimeStart=&OverhaulTypeStart=&OverhaulTimeStart2=&OverhaulTypeStart2=&OverhaulTimeEnd=&OverhaulTypeEnd=&OverhaulTimeEnd2=&OverhaulTypeEnd2=&HotsectionTimeStart=&HotsectionTimeStart2=&HotsectionTimeEnd=&HotsectionTimeEnd2=&SeatNumber=&FlightRules=&YearPaintedFrom=&YearPaintedTo=&YearInteriorFrom=&YearInteriorTo=&LS=&SO=7&beginsearch=Search&PG={NumPages.ToString()}"; 
							str_Email = $"{str_Email}<TR align='center'><td colspan=7>&nbsp;<B>"; 
							str_Email = $"{str_Email}PISTON HELICOPTER<br></TR>"; 
							tmp_SearchType = "PISTON HELICOPTER"; 
							Airframe_Type = "R"; 
							 
							break;
					}
					txt_status.Text = $"Retrieving CONTROLLER {tmp_SearchType} Reports ...";
					Application.DoEvents();

					// **********************************************************
					// PUT IN THE DATA HEADER
					str_Email = $"{str_Email}<TR align='center'><td><B>AC ID</B></td><td><B>REG NO</B></td>";
					str_Email = $"{str_Email}<td><B>SERIAL#</B></td><td><B>MAKE-MODEL#</B></td>";
					str_Email = $"{str_Email}<td><B>PRICE</B></td><td><B>AFTT</B></td>";
					str_Email = $"{str_Email}<td><B>Match</B></td></tr>";


					WbBrowser.Navigate(new Uri(tmp_url));
					WbBrowser.Visible = true;

					Application.DoEvents();
					// not sure this is used anymore. MSw - was on former frm_NTSB page that it was referencing
					//    frm_NTSB_New.inet_browse.RequestTimeout = 480000
					//    frm_NTSB_New.inet_browse.AccessType = icUseDefault
					//    frm_NTSB_New.inet_browse.Protocol = icHTTP
					//
					//
					//    PageData = frm_NTSB_New.inet_browse.OpenURL(tmp_url)
					//
					//    ' **********************************************************
					//    ' IF AN ERROR IS RETURNED THAT MESSAGE AND EXIT
					//    If frm_NTSB_New.inet_browse.ResponseCode <> 0 Then
					//      MsgBox "Browse_CON: " & frm_NTSB_New.inet_browse.ResponseInfo
					//      Exit Sub
					//    End If
					//    DoEvents

					// ***********************************************************
					// IF THE SEARCH RETURNED NO RECORDS THEN RECORD THAT IN THE EMAIL
					// AND MOVE ON TO THE NEXT PAGE
					if ((PageData.IndexOf("Sorry, your search resulted in no matches", StringComparison.CurrentCultureIgnoreCase) + 1) != 0)
					{
						str_Email = $"{str_Email}<TR align='center'><td><B>&nbsp;</B></td>";
						str_Email = $"{str_Email}<td><B>&nbsp;</B></td><td><B>&nbsp;</B></td>";
						str_Email = $"{str_Email}<td><B>NO RECORDS FOUND</B></td>";
						str_Email = $"{str_Email}<td><B>&nbsp;</B></td><td><B>&nbsp;</B></td>";
						str_Email = $"{str_Email}<td><B>&nbsp;</B></td></tr>";
						goto getnextpage;
					}
					// *********************************************************
					// TEMPORARY FIELDS FOR STORING DATA/COLUMNS FROM WEB PAGE




					// **********************************************************
					// PROCESS THE PAGE UNTIL IT IS EMPTY

					STARTPAGE:
					// SPLIT THE PAGE RETURNED INTO ROWS - RECORDS
					// pagerows = Split(PageData, "<tr>" & vbCrLf & vbTab & vbTab & "  " & vbTab)
					pagerows = PageData.Split(new string[]{$"<td valign={"\""}top{"\""} bgcolor={"\""}#CCCCCC{"\""} colspan={"\""}2{"\""}>"}, StringSplitOptions.None);
					//<td valign="top" bgcolor="#CCCCCC" colspan="2">

					rowcount = 0;

					while(rowcount <= pagerows.GetUpperBound(0))
					{

						RowData = pagerows[rowcount];

						// IF THE FIRST FIELD START THE TABLE THEN GO TO THE NEXT FIELD
						if (((RowData.IndexOf("function") + 1) & ((rowcount == 0) ? -1 : 0)) != 0)
						{
							goto GETNEXTRECORD;
						}

						// SET THE VARIABLES FROM DATA IN THE ROW OR CLEAR THOSE WITH
						// NO CORRESPONDING DATA FIELDS
						//init variables
						tmp_HomeBase_Make = "";
						tmp_Make = "";
						tmp_Model = "";
						tmp_RegNo = "";
						tmp_SerialNo = "";
						tmp_AFTT = "";
						tmp_Price = "";
						tmp_Picture = "";
						tmp_AC_ID = "";
						tmp_CON_ID = "";
						tmp_acrep = "";
						tmp_Description = "";
						tmp_Seller = "";
						tmp_Year = "";
						tmp_Location = ""; //rowfields(5)
						tmp_Details = ""; //rowfields(6)
						tmp_text = ""; // rowfields(7)
						//tmp_Seller = "" ' rowfields(12)
						tmp_Phone = ""; // rowfields(13)
						tmp_Fax = ""; // rowfields(14)
						tmp_UpdateDate = "";

						isCharter = false;
						if (RowData.IndexOf("charter", StringComparison.CurrentCultureIgnoreCase) >= 0)
						{
							isCharter = true;
						}

						//Marker = InStr(1, RowData, "listings/detail.aspx?")
						Marker = (RowData.IndexOf("listings/aircraft-for-sale") + 1);
						if (Marker == 0)
						{
							goto GETNEXTRECORD;
						}
						RowData = RowData.Substring(Math.Min(Marker - 1, RowData.Length));
						Marker = 1;
						EndMarker = (RowData.IndexOf('>') + 1);
						if (Marker > EndMarker)
						{
							goto GETNEXTRECORD;
						}

						//line with year, make, model, price, & location  aey 2/7/05
						tmp = StringsHelper.Replace(RowData.Substring(Math.Min(Marker - 1, RowData.Length), Math.Min(EndMarker - Marker, Math.Max(0, RowData.Length - (Marker - 1)))), Environment.NewLine, "", 1, -1, CompareMethod.Binary).Trim();


						tmp = RowData.Substring(Math.Min(EndMarker - 1, RowData.Length)); //get the remainder of line

						if (Strings.Len(txt_NumDays.Text.Trim()) == 0)
						{
							txt_NumDays.Text = "7";
						}
						Marker = (tmp.IndexOf("Updated:") + 1);
						tmp_UpdateDate = tmp.Substring(Math.Min(Marker + 8, tmp.Length), Math.Min(11, Math.Max(0, tmp.Length - (Marker + 8))));
						System.DateTime TempDate2 = DateTime.FromOADate(0);
						tmp_UpdateDate = (DateTime.TryParse(tmp_UpdateDate, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : tmp_UpdateDate;
						ControllerDate = tmp_UpdateDate;
						//MsgBox (CDate(tmp_UpdateDate) & ">=" & DateAdd("d", -CInt(txt_NumDays), DateToday))
						if (DateTime.Parse(tmp_UpdateDate) >= DateTime.Parse(modAdminCommon.DateToday).AddDays(-Convert.ToInt32(Double.Parse(txt_NumDays.Text))))
						{
						}
						else
						{
							goto getnextpage;
						}

						Marker = (tmp.IndexOf('>') + 1);
						tmp = tmp.Substring(Math.Min(Marker, tmp.Length)).Trim();
						tmp = StringsHelper.Replace(tmp, "&nbsp", "", 1, -1, CompareMethod.Binary);

						//the first position can contain 'New", or a Year or the Model# aey 2/7/05
						Marker = (tmp.IndexOf(';') + 1);
						tmp2 = tmp.Substring(Math.Min(0, tmp.Length), Math.Min(Marker - 1, Math.Max(0, tmp.Length)));
						tmp = tmp.Substring(Math.Min(Marker, tmp.Length)).Trim();

						if (Conversion.Val(tmp2) > 100)
						{
							tmp_Year = tmp2;
							Marker = (tmp.IndexOf(';') + 1);
							if (Marker > 0)
							{
								tmp_Make = tmp.Substring(Math.Min(0, tmp.Length), Math.Min(Marker - 1, Math.Max(0, tmp.Length)));
								tmp = tmp.Substring(Math.Min(Marker, tmp.Length)).Trim();
							}
						}
						else
						{

							if (tmp2.ToLower() == "new")
							{
								//tmp2 = Trim(Mid(tmp, 4))
								tmp_Make = tmp2.Substring(Math.Min(3, tmp2.Length)).Trim();

							}
							else
							{
								tmp_Make = tmp2.Trim();
							}

						}

						tmp_Make = StringsHelper.Replace(tmp_Make, "\t", "", 1, -1, CompareMethod.Binary);
						K = (tmp_Make.IndexOf('\'') + 1);
						if (K > 1)
						{
							tmp_Make = tmp_Make.Substring(Math.Min(0, tmp_Make.Length), Math.Min(K - 1, Math.Max(0, tmp_Make.Length)));
						}
						tmp_Make = StringsHelper.Replace(tmp_Make, "'", "", 1, -1, CompareMethod.Binary).Trim();

						Marker = (tmp.IndexOf('<') + 1);
						if (Marker > 0)
						{
							tmp_Model = tmp.Substring(Math.Min(0, tmp.Length), Math.Min(Marker - 1, Math.Max(0, tmp.Length))).Trim();
							tmp_Model = StringsHelper.Replace(tmp_Model, "\t", "", 1, -1, CompareMethod.Binary);
						}
						K = (tmp_Model.IndexOf('\'') + 1);
						if (K > 1)
						{
							tmp_Model = tmp_Model.Substring(Math.Min(0, tmp_Model.Length), Math.Min(K - 1, Math.Max(0, tmp_Model.Length)));
						}
						tmp_Model = StringsHelper.Replace(tmp_Model, "'", "", 1, -1, CompareMethod.Binary).Trim();

						// *********************************************
						// GET THE AIRCRAFT PRICE
						findit = "BurgSectionHead";
						Marker = (RowData.IndexOf(findit) + 1);
						if (Marker > 0)
						{
							tmp = RowData.Substring(Math.Min(Marker + Strings.Len(findit) - 1, RowData.Length));
							J = (tmp.IndexOf("</b>") + 1);
							if (J >= 0)
							{
								tmp_Price = tmp.Substring(Math.Min(0, tmp.Length), Math.Min(J - 1, Math.Max(0, tmp.Length)));
							}
							tmp_Price = StringsHelper.Replace(tmp_Price, "<b>", "", 1, -1, CompareMethod.Binary);
							tmp_Price = StringsHelper.Replace(tmp_Price, ">", "", 1, -1, CompareMethod.Binary);
							tmp_Price = StringsHelper.Replace(tmp_Price, "\t", "", 1, -1, CompareMethod.Binary);
							tmp_Price = StringsHelper.Replace(tmp_Price, "\"", "", 1, -1, CompareMethod.Binary);
							tmp_Price = StringsHelper.Replace(tmp_Price, "\r", "", 1, -1, CompareMethod.Binary);
							tmp_Price = StringsHelper.Replace(tmp_Price, "\n", "", 1, -1, CompareMethod.Binary);
							tmp_Price = StringsHelper.Replace(tmp_Price, "\t", "", 1, -1, CompareMethod.Binary);
							RowData = RowData.Substring(Math.Min(Marker + Strings.Len(findit) - 1, RowData.Length));
						}

						// RTW - 5/3/07 - IGNORE RECORD IF PRICE = CALL
						tmp_Price = ($"{tmp_Price}").Trim();
						if (tmp_Price.Trim().ToUpper() == "CALL" || tmp_Price.Trim().ToUpper() == "INQUIRE")
						{
							tmp_Price = tmp_Price.ToUpper();
						}

						findit = "bgcolor=#CCCCCC>";
						Marker = (RowData.IndexOf(findit) + 1);
						if (Marker > 0)
						{
							tmp = RowData.Substring(Math.Min(Marker + Strings.Len(findit) - 1, RowData.Length));
							J = (tmp.IndexOf("&nbsp;") + 1);
							if (J > 0)
							{
								tmp_Location = tmp.Substring(Math.Min(0, tmp.Length), Math.Min(J - 1, Math.Max(0, tmp.Length)));
							}
							tmp_Location = StringsHelper.Replace(tmp_Location, "<b>", "", 1, -1, CompareMethod.Binary);
							tmp_Location = StringsHelper.Replace(tmp_Location, "</b>", "", 1, -1, CompareMethod.Binary);
							tmp_Location = StringsHelper.Replace(tmp_Location, "\t", "", 1, -1, CompareMethod.Binary);
						}

						tmp_Location = ($"{tmp_Location}").Trim();

						//get next data line
						tmp2 = "";
						findit = "Updated:";

						Marker = (RowData.IndexOf(findit) + 1);
						if (Marker > 0)
						{

							tmp = RowData.Substring(Math.Min(0, RowData.Length), Math.Min(Marker - 1, Math.Max(0, RowData.Length))).Trim();
							J = (tmp.IndexOf("<br>") + 1);
							if (J > 0)
							{
								tmp_Description = tmp.Substring(Math.Min(0, tmp.Length), Math.Min(J - 4, Math.Max(0, tmp.Length)));
								tmp2 = tmp_Description;
							}
						}

						tmp_Description = StringsHelper.Replace(tmp_Description, "&nbsp", "", 1, -1, CompareMethod.Binary).Trim();
						tmp_Description = StringsHelper.Replace(tmp_Description, "&amp", "&", 1, -1, CompareMethod.Binary).Trim();
						tmp_Description = StringsHelper.Replace(tmp_Description, "\t", "", 1, -1, CompareMethod.Binary).Trim();

						//no preceeding serial number  9/22/05 aey
						findit = $"left{"\""}>";
						Marker = (tmp2.IndexOf(findit) + 1);
						if (Marker > 0)
						{
							tmp2 = tmp2.Substring(Math.Min(Marker + Strings.Len(findit) - 1, tmp2.Length)).Trim();
						}
						tmp2 = StringsHelper.Replace(tmp2, "\r", " ", 1, -1, CompareMethod.Binary);
						tmp2 = StringsHelper.Replace(tmp2, "\n", " ", 1, -1, CompareMethod.Binary);
						tmp2 = StringsHelper.Replace(tmp2, "\t", " ", 1, -1, CompareMethod.Binary);



						findit = "S/N:";
						Marker = (tmp2.IndexOf(findit) + 1);
						if (Marker == 0)
						{
							findit = "S/N";
							Marker = (tmp2.IndexOf(findit) + 1);
						}

						if (Marker > 0)
						{
							tmp = tmp2.Substring(Math.Min(Marker + Strings.Len(findit) - 1, tmp2.Length)).Trim();
							J = (tmp.IndexOf(' ') + 1);
							if (J > 0)
							{
								tmp_SerialNo = tmp.Substring(Math.Min(0, tmp.Length), Math.Min(J - 1, Math.Max(0, tmp.Length)));
								tmp_SerialNo = StringsHelper.Replace(tmp_SerialNo, ",", "", 1, -1, CompareMethod.Binary);
								tmp_SerialNo = StringsHelper.Replace(tmp_SerialNo, "\t", "", 1, -1, CompareMethod.Binary);

							}
						}

						tmp_SerialNo = StringsHelper.Replace(($"{tmp_SerialNo}").Trim(), "'", "", 1, -1, CompareMethod.Binary);

						tmp_SerialNoAlt = $"{tmp_SerialNo}";
						tmp_SerialNoAlt = StringsHelper.Replace(StringsHelper.Replace(tmp_SerialNoAlt, "-", "", 1, -1, CompareMethod.Binary).Trim(), "'", "", 1, -1, CompareMethod.Binary);



						Marker = (tmp2.IndexOf(" N") + 1);
						if (Marker > 0)
						{
							tmp = tmp2.Substring(Math.Min(Marker - 1, tmp2.Length)).Trim();
							J = (tmp.IndexOf(' ') + 1);
							if (J > 0)
							{
								tmp_RegNo = tmp.Substring(Math.Min(0, tmp.Length), Math.Min(J - 1, Math.Max(0, tmp.Length))).Trim();
								tmp_RegNo = StringsHelper.Replace(tmp_RegNo, ",", "", 1, -1, CompareMethod.Binary);
							}

						}


						tmp_RegNo = StringsHelper.Replace(tmp_RegNo, "'", "", 1, -1, CompareMethod.Binary);
						tmp_RegNo = StringsHelper.Replace(tmp_RegNo, "</td", "", 1, -1, CompareMethod.Binary);
						tmp_RegNo = StringsHelper.Replace(tmp_RegNo, "<td", "", 1, -1, CompareMethod.Binary);
						tmp_RegNo = StringsHelper.Replace(tmp_RegNo, "</tr", "", 1, -1, CompareMethod.Binary);
						tmp_RegNo = StringsHelper.Replace(tmp_RegNo, "<tr", "", 1, -1, CompareMethod.Binary);
						tmp_RegNo = StringsHelper.Replace(tmp_RegNo, ">", "", 1, -1, CompareMethod.Binary);
						tmp_RegNo = StringsHelper.Replace(tmp_RegNo, "<", "", 1, -1, CompareMethod.Binary);
						tmp_RegNo = ($"{StringsHelper.Replace(tmp_RegNo, "\t", "", 1, -1, CompareMethod.Binary)}").Trim();

						tmp_RegNoAlt = $"{tmp_RegNo}";
						tmp_RegNoAlt = StringsHelper.Replace(tmp_RegNoAlt, "-", "", 1, -1, CompareMethod.Binary).Trim(); //remove dashes

						// ****************************************
						// GET AFTT
						Marker = (tmp2.IndexOf("TT") + 1);
						if (Marker > 0)
						{
							tmp = tmp2.Substring(Math.Min(0, tmp2.Length), Math.Min(Marker - 1, Math.Max(0, tmp2.Length))).Trim();
							J = tmp.LastIndexOf(",") + 1;

							if (J > 0)
							{
								tmp_AFTT = tmp.Substring(Math.Min(J, tmp.Length)).Trim();
							}

						}

						if (Strings.Len(($"{tmp_AFTT}").Trim()) > 0)
						{
							tmp_AFTT = StringsHelper.Replace(tmp_AFTT, ",", "", 1, -1, CompareMethod.Binary);
							tmp_AFTT = StringsHelper.Replace(tmp_AFTT, "\t", "", 1, -1, CompareMethod.Binary);
							tmp_AFTT = StringsHelper.Replace(tmp_AFTT, "'", "", 1, -1, CompareMethod.Binary).Trim();
						}

						//seller
						findit = $"<td align={"\""}left{"\""} valign={"\""}top";
						Marker = (RowData.IndexOf(findit) + 1);
						if (Marker > 0)
						{
							tmp = RowData.Substring(Math.Min(Marker - 1, RowData.Length));
							J = (tmp.IndexOf("font color=#003399>") + 1);
							if (J > 0)
							{
								tmp = tmp.Substring(Math.Min(J + 18, tmp.Length));
							}
							else
							{
								jj = (tmp.IndexOf("<font color=000000>") + 1);
								if (jj > 0)
								{
									tmp = tmp.Substring(Math.Min(jj + 18, tmp.Length));
								}
							}


							EndMarker = (tmp.IndexOf("</font>") + 1);
							tmp_Seller = tmp.Substring(Math.Min(0, tmp.Length), Math.Min(EndMarker, Math.Max(0, tmp.Length)));
							tmp_Seller = StringsHelper.Replace(tmp_Seller, findit, "", 1, -1, CompareMethod.Binary);
							tmp_Seller = StringsHelper.Replace(tmp_Seller, "<br>", "", 1, -1, CompareMethod.Binary);
							tmp_Seller = StringsHelper.Replace(tmp_Seller, "</font>", "", 1, -1, CompareMethod.Binary);
							tmp_Seller = StringsHelper.Replace(tmp_Seller, "<", "", 1, -1, CompareMethod.Binary);
							tmp_Seller = StringsHelper.Replace(tmp_Seller, "\t", "", 1, -1, CompareMethod.Binary);

						}

						tmp_Seller = ($"{tmp_Seller}").Trim();

						findit = "Phone:";
						Marker = (RowData.IndexOf(findit) + 1);
						if (Marker > 0)
						{
							tmp = RowData.Substring(Math.Min(Marker + Strings.Len(findit) - 1, RowData.Length));
							EndMarker = (tmp.IndexOf("</nobr>") + 1);
							tmp_Phone = tmp.Substring(Math.Min(0, tmp.Length), Math.Min(EndMarker, Math.Max(0, tmp.Length)));
							tmp_Phone = StringsHelper.Replace(tmp_Phone, findit, "", 1, -1, CompareMethod.Binary);
							tmp_Phone = StringsHelper.Replace(tmp_Phone, "<br>", "", 1, -1, CompareMethod.Binary);
							tmp_Phone = StringsHelper.Replace(tmp_Phone, "<", "", 1, -1, CompareMethod.Binary);
							tmp_Phone = StringsHelper.Replace(tmp_Phone, "\t", "", 1, -1, CompareMethod.Binary);

						}

						if (RowData.IndexOf("Details & Photo") >= 0)
						{
							tmp_Picture = "YES";
						}
						else
						{
							tmp_Picture = "";
						}

						//get reference to online listing
						findit = $"<a href={"\""}/listings/aircraft-for-sale";
						Marker = (RowData.IndexOf(findit, StringComparison.CurrentCultureIgnoreCase) + 1) + 9;
						tmp = RowData.Substring(Math.Min(Marker - 1, RowData.Length));
						EndMarker = (tmp.IndexOf('>') + 1);
						if (EndMarker > 0)
						{
							tmp_href = $"http://www.controller.com{tmp.Substring(Math.Min(0, tmp.Length), Math.Min(EndMarker - 2, Math.Max(0, tmp.Length)))}";
						}

						// BUILD THE DESCRIPTION FOR FUTURE REFERENCE
						tmp_OriginalDescription = $"{tmp_RegNo}~{tmp_Make}~{tmp_AFTT}~{tmp_Price}~{tmp_SerialNo}";

						// DISPLAY THE STATUS TO SCREEN
						txt_status.Text = $"{tmp_SearchType}-REGNO:{tmp_RegNo}  SERIALNO:{tmp_SerialNo}";

						Application.DoEvents();

						HowMatched = "No Match";

						if (Strings.Len(tmp_RegNo.Trim()) > 0 && (!isCharter))
						{
							//  CHECK TO SEE IF HOMEBASE HAS A AIRCRAFT SPECIFICALLY ASSIGNED TO THIS REG NO
							ACRecord = new ADORecordSetHelper();
							Query = "select ac_id,ac_ser_no_full,amod_make_name,ac_year, ac_reg_no ";
							Query = $"{Query}from aircraft,Aircraft_Model  where ac_amod_id =amod_id ";
							Query = $"{Query}and (ac_reg_no ='N{tmp_RegNo}' ";
							Query = $"{Query}or ac_reg_no='{tmp_RegNo}' ";
							Query = $"{Query}or ac_reg_no ='N{tmp_RegNoAlt}' ";
							Query = $"{Query}or ac_reg_no='{tmp_RegNoAlt}') ";
							Query = $"{Query}and ac_journ_id=0  and amod_airframe_type_code ='{Airframe_Type}' ";
							ACRecord.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
							if (!(ACRecord.BOF && ACRecord.EOF))
							{
								ACRecord.MoveLast();
								if (ACRecord.RecordCount == 1)
								{

									// AN AIRCRAFT WAS FOUND SO ASSIGN THE AC ID AND DESCRIPTION
									tmp_AC_ID = Convert.ToString(ACRecord["AC_ID"]);
									tmp_HomeBase_Make = $"{($"{Convert.ToString(ACRecord["amod_make_name"])} ").Trim()} {Convert.ToString(ACRecord["ac_ser_no_full"])}";
									report_found++;
									HowMatched = "RegNo 1 Rec";
									Application.DoEvents();

								}
								else
								{
									tmp_AC_ID = "";
									tmp_HomeBase_Make = "";

									if (Chk_Dups.CheckState == CheckState.Checked)
									{ //aey 8/11/04
										// if there are duplicate records, ask someone to choose among the duplicates
										ACRecord.MoveFirst();

										while(!ACRecord.EOF)
										{

											Msg = $"We found duplicate RegNo matches within the JETNET database---{Environment.NewLine}{Environment.NewLine}";
											Msg = $"{Msg}WEB SITE MAKE: {tmp_Make.Trim()}, Year: {tmp_Year.Trim()}, Reg No: {tmp_RegNo.Trim()}, Serial#: {tmp_SerialNo.Trim()},Model: {tmp_Model.Trim()}{Environment.NewLine}{Environment.NewLine}";
											//Msg = Msg & "Description:" & tmp_Text & " mkematch:" & strMake & vbCrLf & vbCrLf
											//Msg = Msg & "Description:" & tmp_Text & vbCrLf & vbCrLf
											Msg = $"{Msg}HOMEBASE MAKE: {Convert.ToString(ACRecord["amod_make_name"])}, Serial#: {Convert.ToString(ACRecord["ac_ser_no_full"])}{Environment.NewLine}";
											Msg = $"{Msg}Click Yes if this is a match, Cancel to stop prompting for duplicates";

											Dup_Response = System.Windows.Forms.DialogResult.No;
											if (Math.Abs(Conversion.Val($"{tmp_Year}") - Conversion.Val($"{Convert.ToString(ACRecord["ac_year"])}")) < Conversion.Val($"{txt_years_diff.Text}"))
											{
												Dup_Response = MessageBox.Show(Msg, "Found Duplicate Matches in Homebase", MessageBoxButtons.YesNoCancel);
											}


											if (Dup_Response == System.Windows.Forms.DialogResult.Yes)
											{ //match selected
												tmp_AC_ID = Convert.ToString(ACRecord["AC_ID"]);
												tmp_HomeBase_Make = $"{($"{Convert.ToString(ACRecord["amod_make_name"])} ").Trim()} {Convert.ToString(ACRecord["ac_ser_no_full"])}";
												report_found++;
												HowMatched = "RegNo User Select";
												break;
											}

											if (Dup_Response == System.Windows.Forms.DialogResult.Cancel)
											{ //quit prompting
												Chk_Dups.CheckState = CheckState.Unchecked;
												break;
											}
											ACRecord.MoveNext();
										};
									}
								}

							}
							else
							{
								tmp_AC_ID = "";
								tmp_HomeBase_Make = "";
							}
							ACRecord.Close();
							ACRecord = null;
						}
						else
						{
							// NO REG NO FOUND SO CLEAR THE AC ID AND MAKE
							tmp_AC_ID = "";
							tmp_HomeBase_Make = "";
						} // CHECK FOR REG NO IN DATA

						tmp_Make = tmp_Make.Trim(); //aey 8/12/04
						strMake = tmp_Make;
						// strmake is used to further qualify the query
						K = (tmp_Make.IndexOf(tmp_Year) + 1);
						if (Strings.Len(tmp_Year.Trim()) > 0 && K > 0)
						{
							strMake = tmp_Make.Substring(Math.Min(K + Strings.Len(tmp_Year), tmp_Make.Length)).Trim();
							K = (strMake.IndexOf(' ') + 1);
							if (K > 0)
							{
								strMake = strMake.Substring(Math.Min(0, strMake.Length), Math.Min(K, Math.Max(0, strMake.Length))).Trim();
							}
						}
						else
						{
							K = (tmp_Make.IndexOf(' ') + 1);
							if (K > 0)
							{
								strMake = tmp_Make.Substring(Math.Min(0, tmp_Make.Length), Math.Min(K, Math.Max(0, tmp_Make.Length))).Trim();
							}
						}
						tmp_OriginalDescription = $"{tmp_RegNo}~{tmp_Make}~{tmp_AFTT}~{tmp_Price}~{tmp_SerialNo}";
						//
						//         ' DISPLAY THE STATUS TO SCREEN
						txt_status.Text = $"{tmp_SearchType}-REGNO:{tmp_RegNo}  SERIALNO:{tmp_SerialNo}";
						Application.DoEvents();
						errMsg = "select";


						if (Strings.Len(tmp_SerialNo.Trim()) > 0 && tmp_AC_ID == "" && (!isCharter))
						{
							//  CHECK TO SEE IF HOMEBASE HAS A AIRCRAFT SPECIFICALLY ASSIGNED TO THIS SERIAL NO
							Query = "select ac_id,ac_ser_no_full,ac_reg_no ,amod_make_name,ac_year,amod_model_name ";
							Query = $"{Query}from aircraft,Aircraft_Model ";
							Query = $"{Query}where ac_amod_id =amod_id ";

							if (modCommon.Is_A_Real_Number(tmp_SerialNo) && modCommon.Is_A_Real_Number(tmp_SerialNoAlt))
							{ //aey 8/12/04
								Query = $"{Query}and (ac_ser_no_full ='{tmp_SerialNo.Trim()}' or ";
								Query = $"{Query} ac_ser_no_value = {Conversion.Val(tmp_SerialNo).ToString()} or ";
								Query = $"{Query} ac_ser_no_full = '{tmp_SerialNoAlt.Trim()}' or ";
								Query = $"{Query} ac_ser_no_value = {Conversion.Val(tmp_SerialNoAlt).ToString()}) ";
							}
							else
							{
								Query = $"{Query}and (ac_ser_no_full = '{tmp_SerialNo.Trim()}' or ac_ser_no_full = '{tmp_SerialNoAlt.Trim()}') ";
							}

							// further limit dups by matching names -- aey 8/12/04
							Query = $"{Query} and left(amod_make_name,5) = '{strMake.Substring(0, Math.Min(5, strMake.Length))}' ";
							Query = $"{Query}and ac_journ_id=0 ";
							Query = $"{Query}and amod_airframe_type_code ='{Airframe_Type}' ";

							ACRecord.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
							if (!(ACRecord.BOF && ACRecord.EOF))
							{
								ACRecord.MoveLast();
								if (ACRecord.RecordCount == 1)
								{
									tmp_AC_ID = Convert.ToString(ACRecord["AC_ID"]);
									tmp_HomeBase_Make = $"{($"{Convert.ToString(ACRecord["amod_make_name"])} ").Trim()} {Convert.ToString(ACRecord["ac_ser_no_full"])}";
									report_found++;
									HowMatched = "SerNo 1 Rec";
									Application.DoEvents();
								}
								else
								{
									// FOUND MORE THAN ONE AIRCRAFT WITH THE SERIAL NUMBER
									tmp_AC_ID = "";
									tmp_HomeBase_Make = "";

									if (Chk_Dups.CheckState == CheckState.Checked)
									{ //aey 8/11/04
										// if there are duplicate records, ask someone to choose among the duplicates
										ACRecord.MoveFirst();

										while(!ACRecord.EOF)
										{

											Msg = $"We found duplicate SerNo/Make matches within the JETNET database---{Environment.NewLine}{Environment.NewLine}";
											Msg = $"{Msg}WEB SITE MAKE: {tmp_Make.Trim()}, Year: {tmp_Year.Trim()}, Reg No: {tmp_RegNo.Trim()}, Serial#: {tmp_SerialNo.Trim()},Model: {tmp_Model.Trim()}{Environment.NewLine}{Environment.NewLine}";

											Msg = $"{Msg}HOMEBASE MAKE: {Convert.ToString(ACRecord["amod_make_name"])}, Year: {Convert.ToString(ACRecord["ac_year"])}, Reg No: {Convert.ToString(ACRecord["ac_reg_no"])}, Serial#: {Convert.ToString(ACRecord["ac_ser_no_full"])}, Model: {Convert.ToString(ACRecord["amod_model_name"])}{Environment.NewLine}{Environment.NewLine}";
											Msg = $"{Msg}Click Yes if this is a match, Cancel to stop prompting for duplicates";

											Dup_Response = System.Windows.Forms.DialogResult.No;
											if (Math.Abs(Conversion.Val($"{tmp_Year}") - Conversion.Val($"{Convert.ToString(ACRecord["ac_year"])}")) < Conversion.Val($"{txt_years_diff.Text}"))
											{
												Dup_Response = MessageBox.Show(Msg, "Found Duplicate Matches in Homebase", MessageBoxButtons.YesNoCancel);
											}

											if (Dup_Response == System.Windows.Forms.DialogResult.Yes)
											{ //match selected
												tmp_AC_ID = Convert.ToString(ACRecord["AC_ID"]);
												tmp_HomeBase_Make = $"{($"{Convert.ToString(ACRecord["amod_make_name"])} ").Trim()} {Convert.ToString(ACRecord["ac_ser_no_full"])}";
												report_found++;
												HowMatched = "SerNo User Select";
												break;
											}

											if (Dup_Response == System.Windows.Forms.DialogResult.Cancel)
											{ //quit prompting
												Chk_Dups.CheckState = CheckState.Unchecked;
												break;
											}

											ACRecord.MoveNext();
										};
									}

								}
							}
							else
							{
								// NO HOMEBASE AIRCRAFT FOUND
								tmp_AC_ID = "";
								tmp_HomeBase_Make = "";
							} // CHECK FOR MATCHING HOMEBASE AIRCRAFT
							ACRecord.Close();
							ACRecord = null;

						}

						//>>>> If No-Match, Try Serial_no again, but without make

						if (Strings.Len(tmp_SerialNo.Trim()) > 0 && tmp_AC_ID == "" && (!isCharter))
						{
							//  CHECK TO SEE IF HOMEBASE HAS A AIRCRAFT SPECIFICALLY ASSIGNED TO THIS SERIAL NO
							Query = "select ac_id,ac_ser_no_full,ac_reg_no ,amod_make_name,ac_year,amod_model_name ";
							Query = $"{Query}from aircraft,Aircraft_Model ";
							Query = $"{Query}where ac_amod_id =amod_id ";

							if (modCommon.Is_A_Real_Number(tmp_SerialNo) && modCommon.Is_A_Real_Number(tmp_SerialNoAlt))
							{ //aey 8/12/04
								Query = $"{Query}and (ac_ser_no_full ='{tmp_SerialNo.Trim()}' or   ac_ser_no_value = {Conversion.Val(tmp_SerialNo).ToString()} or ";
								Query = $"{Query} ac_ser_no_full = '{tmp_SerialNoAlt.Trim()}' or   ac_ser_no_value = {Conversion.Val(tmp_SerialNoAlt).ToString()}) ";
							}
							else
							{
								Query = $"{Query}and (ac_ser_no_full = '{tmp_SerialNo.Trim()}' or ac_ser_no_full = '{tmp_SerialNoAlt.Trim()}') ";
							}

							// further limit dups by matching names -- aey 8/12/04
							// Query = Query & " and left(amod_make_name,5) = '" & left(strMake, 5) & "' "
							Query = $"{Query}and ac_journ_id=0 ";
							Query = $"{Query}and amod_airframe_type_code ='{Airframe_Type}' ";

							ACRecord.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
							if (!(ACRecord.BOF && ACRecord.EOF))
							{
								ACRecord.MoveLast();
								if (ACRecord.RecordCount == 1)
								{
									tmp_AC_ID = Convert.ToString(ACRecord["AC_ID"]);
									tmp_HomeBase_Make = $"{($"{Convert.ToString(ACRecord["amod_make_name"])} ").Trim()} {Convert.ToString(ACRecord["ac_ser_no_full"])}";
									report_found++;
									HowMatched = "SerNo 1 Rec";
									Application.DoEvents();
								}
								else
								{
									// FOUND MORE THAN ONE AIRCRAFT WITH THE SERIAL NUMBER
									tmp_AC_ID = "";
									tmp_HomeBase_Make = "";

									if (Chk_Dups.CheckState == CheckState.Checked)
									{ //aey 8/11/04
										// if there are duplicate records, ask someone to choose among the duplicates
										ACRecord.MoveFirst();

										while(!ACRecord.EOF)
										{

											Msg = $"We found duplicate SerNo matches within the JETNET database---{Environment.NewLine}{Environment.NewLine}";
											Msg = $"{Msg}WEB SITE MAKE: {tmp_Make.Trim()}, Year: {tmp_Year.Trim()}, Reg No: {tmp_RegNo.Trim()}, Serial#: {tmp_SerialNo.Trim()},Model: {tmp_Model.Trim()}{Environment.NewLine}{Environment.NewLine}";
											Msg = $"{Msg}HOMEBASE MAKE: {Convert.ToString(ACRecord["amod_make_name"])}, Year: {Convert.ToString(ACRecord["ac_year"])}, Reg No: {Convert.ToString(ACRecord["ac_reg_no"])}, Serial#: {Convert.ToString(ACRecord["ac_ser_no_full"])}, Model: {Convert.ToString(ACRecord["amod_model_name"])}{Environment.NewLine}{Environment.NewLine}";
											Msg = $"{Msg}Click Yes if this is a match, Cancel to stop prompting for duplicates";

											Dup_Response = System.Windows.Forms.DialogResult.No;
											if (Math.Abs(Conversion.Val($"{tmp_Year}") - Conversion.Val($"{Convert.ToString(ACRecord["ac_year"])}")) < Conversion.Val($"{txt_years_diff.Text}"))
											{
												Dup_Response = MessageBox.Show(Msg, "Found Duplicate Matches in Homebase", MessageBoxButtons.YesNoCancel);
											}

											if (Dup_Response == System.Windows.Forms.DialogResult.Yes)
											{ //match selected
												tmp_AC_ID = Convert.ToString(ACRecord["AC_ID"]);
												tmp_HomeBase_Make = $"{($"{Convert.ToString(ACRecord["amod_make_name"])} ").Trim()} {Convert.ToString(ACRecord["ac_ser_no_full"])}";
												report_found++;
												HowMatched = "SerNo User Select";
												break;
											}

											if (Dup_Response == System.Windows.Forms.DialogResult.Cancel)
											{ //quit prompting
												Chk_Dups.CheckState = CheckState.Unchecked;
												break;
											}

											ACRecord.MoveNext();
										};
									}

								}
							}
							else
							{
								// NO HOMEBASE AIRCRAFT FOUND
								tmp_AC_ID = "";
								tmp_HomeBase_Make = "";
							} // CHECK FOR MATCHING HOMEBASE AIRCRAFT
							ACRecord.Close();
							ACRecord = null;

						}


						// INCREMENT TOTAL LISTINGS REVIEWED
						report_counter++;

						// IF THE AIRCRAFT WAS FOUND IN HOMEBASE THEN SEE IF IT IS ALREADY
						// IN THE NEW AVAILABLES LOG
						if (Strings.Len(tmp_AC_ID.Trim()) > 0)
						{
							// *****************************************************
							// CHECK TO SEE IF THE AVAILABLE IS ALREADY IN THE LOG
							CheckAvail = new ADORecordSetHelper();
							Query = "select publog_id from Publication_Log ";
							Query = $"{Query}where publog_source = 'CON' ";
							Query = $"{Query}and publog_entry_date >= '{DateTimeHelper.ToString(DateTime.Parse(modAdminCommon.DateToday).AddDays(-30))}' ";

							//COMPARE REG NO AND MAKE TO DETERMINE IF WE'VE SEEN THIS PUB BEFORE
							Query = $"{Query}AND publog_original_desc LIKE '{tmp_RegNo}~{tmp_Make}%' ";

							Query = $"{Query}AND (upper(publog_reg_no) ='{tmp_RegNo.ToUpper()}' or upper(publog_reg_no) ='N{tmp_RegNo.ToUpper()}' ";
							Query = $"{Query}or upper(publog_reg_no) ='{tmp_RegNoAlt.ToUpper()}' or upper(publog_reg_no) ='N{tmp_RegNoAlt.ToUpper()}') ";

							if (Strings.Len(tmp_Price.Trim()) > 0 && tmp_Price.Trim().ToUpper() != "INQUIRE" && tmp_Price.Trim().ToUpper() != "CALL")
							{
								Query = $"{Query}AND publog_price= '{tmp_Price}' ";
							}

							if (Strings.Len(tmp_AFTT.Trim()) > 0 && Information.IsNumeric(tmp_AFTT))
							{
								Query = $"{Query}AND (publog_aftt = '{StringsHelper.Replace(tmp_AFTT, ",", "", 1, -1, CompareMethod.Binary)}'  or replace(publog_aftt,',','') = '{StringsHelper.Replace(tmp_AFTT, ",", "", 1, -1, CompareMethod.Binary)}')  ";
							}

							Publog_id = 0;

							// CHECK IF THERE IS ALREADY AN ENTRY IN THE LOG, IF NOT THEN RECORD ONE
							if (!modAdminCommon.Exist(Query))
							{

								// NO RECORD IN THE NEWLY AVAILABLE LOG SO ENTER ONE
								NewAvailEntry = new ADORecordSetHelper();
								NewAvailEntry.Open("select * from Publication_Log where publog_id = -1", modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
								//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_ISSUE: (2064) ADODB.Recordset method NewAvailEntry.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								if (NewAvailEntry.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
								{
									NewAvailEntry.AddNew();
									NewAvailEntry["publog_source"] = "CON";
									NewAvailEntry["publog_ac_id"] = Conversion.Val($"{tmp_AC_ID}");
									NewAvailEntry["publog_reg_no"] = tmp_RegNo.Substring(0, Math.Min(15, tmp_RegNo.Length));
									NewAvailEntry["publog_ser_no"] = tmp_SerialNo.Substring(0, Math.Min(25, tmp_SerialNo.Length));
									//NewAvailEntry!publog_entry_date = GetSystemDateTime
									pubDate = modAdminCommon.GetSystemDateTime();
									NewAvailEntry["publog_entry_date"] = pubDate;
									NewAvailEntry["publog_description"] = tmp_Make.Substring(0, Math.Min(120, tmp_Make.Length));
									NewAvailEntry["publog_original_desc"] = tmp_OriginalDescription.Substring(0, Math.Min(200, tmp_OriginalDescription.Length));

									NewAvailEntry["publog_picture"] = tmp_Picture.Substring(0, Math.Min(10, tmp_Picture.Length));
									if (Strings.Len(($"{tmp_Price}").Trim()) > 0)
									{
										NewAvailEntry["publog_price"] = tmp_Price.Trim();
									}
									if (Strings.Len(($"{tmp_AFTT}").Trim()) > 0)
									{
										if (Information.IsNumeric(tmp_AFTT))
										{
											NewAvailEntry["publog_aftt"] = tmp_AFTT;
										}
										else
										{
											tmp_Seller = $"{tmp_Seller} Notes: {tmp_AFTT}";
										}
									}

									NewAvailEntry["publog_seller_info"] = $"{tmp_Seller}->{ControllerDate}";
									NewAvailEntry["publog_url"] = tmp_href.Trim().Substring(0, Math.Min(500, tmp_href.Trim().Length));
									NewAvailEntry["publog_status"] = "N";
									NewAvailEntry["publog_acct_rep"] = GetACCTRep(Convert.ToInt32(Double.Parse(tmp_AC_ID)));
									NewAvailEntry.Update();
									// INCREMENT COUNTER FOR NEW REPORT FOUND AND ADDED
									new_reports++;
									Publog_id = Convert.ToInt32(Conversion.Val($"{modCommon.DLookUp("publog_id", "publication_log", $"publog_ac_id={Conversion.Val($"{tmp_AC_ID}").ToString()} and publog_entry_date='{pubDate}'")}"));

								}
								NewAvailEntry.Close();
								NewAvailEntry = null;

								// **************************************************
								// CREATE AN EMAIL LINE FOR FOUND RECORD
								str_Email = $"{str_Email}<tr><td>&nbsp;{tmp_AC_ID}</td>";
								str_Email = $"{str_Email}<td>&nbsp;{tmp_RegNo}</td><td>&nbsp;{tmp_SerialNo}</td>";

								if (Strings.Len(($"{tmp_HomeBase_Make}").Trim()) > 0)
								{
									str_Email = $"{str_Email}<td>&nbsp;<A HREF='{tmp_href}'>{tmp_HomeBase_Make}</a></td>";
								}
								else
								{
									str_Email = $"{str_Email}<td>&nbsp;<A HREF='{tmp_href}'>{tmp_Make}</a></td>";
								}
								str_Email = $"{str_Email}<td>&nbsp;{tmp_Price}</td>";
								str_Email = $"{str_Email}<td>&nbsp;{tmp_AFTT}</td>";
								//how matched aey 7/8/05
								str_Email = $"{str_Email}<td>&nbsp;{HowMatched},pub_id:{Publog_id.ToString()}</td>";

								Application.DoEvents();
							} // IF WE FOUND A RECORD IN THE NEWLY AVAILABLE LOG
							//CheckAvail.Close
							//Set CheckAvail = Nothing
						}
						else
						{


							if (isCharter)
							{
								tmpCharterString = " (For Charter)";
							}
							else
							{
								tmpCharterString = "";
							}


							str_Email = $"{str_Email}<tr><td>&nbsp;{tmp_AC_ID}</td>";
							str_Email = $"{str_Email}<td>&nbsp;{tmp_RegNo}</td><td>&nbsp;{tmp_SerialNo}</td>";
							if (Strings.Len(($"{tmp_HomeBase_Make}").Trim()) > 0)
							{
								str_Email = $"{str_Email}<td>&nbsp;<A HREF='{tmp_href}'>{tmp_HomeBase_Make}</a>{tmpCharterString}</td>";
							}
							else
							{
								str_Email = $"{str_Email}<td>&nbsp;<A HREF='{tmp_href}'>{tmp_Make}</a>{tmpCharterString}</td>";
							}
							str_Email = $"{str_Email}<td>&nbsp;{tmp_Price}</td>";
							str_Email = $"{str_Email}<td>&nbsp;{tmp_AFTT}</td>";
							//how matched aey 7/8/05
							str_Email = $"{str_Email}<td>&nbsp;{HowMatched}</td>";

						} // IF WE HAVE AN AIRCRAFT IF
						//GETNEXTAIRCRAFT:
						// REDUCE THE SIZE OF PAGE DATA AND SEE IF THERE IS MORE INFORMATION
						// AND CHECK TO MAKE SURE THAT WE HAVEN'T LOOKED THROUGH THE ENTIRE PAGE
						PageData = PageData.Substring(Math.Max(PageData.Length - (Strings.Len(PageData) - (EndMarker + 2)), 0));
						Application.DoEvents();

						// INCREASE THE ROW COUNTER THROUGH THE ROW ARRAY
						GETNEXTRECORD:
						rowcount++;
					};

					//IF WE HAVE A LINK FOR THE "NEXT PAGE", WE NEED TO FOLLOW
					//THE LINK AND KEEP PROCESSING
					if (PageData.IndexOf("Click here</a> to view the next 25 listings") >= 0)
					{

						Marker = (PageData.IndexOf("You are currently on page") + 1);
						Marker = Strings.InStr(Marker, PageData, $"<a href={"\""}list.asp?", CompareMethod.Text) + 9;

						EndMarker = Strings.InStr(Marker, PageData, ">Click here", CompareMethod.Text) - 1;
						tmp_url = $"http://www.controller.com/listings/forsale/{PageData.Substring(Math.Min(Marker + 3, PageData.Length), Math.Min(EndMarker - Marker, Math.Max(0, PageData.Length - (Marker + 3))))}";
						NumPages++;
						txt_status.Text = $"Retrieving {tmp_SearchType} Page:{NumPages.ToString()}";
						Application.DoEvents();
						tmp_url = $"http://www.controller.com/listings/forsale/list.asp?catid=3&SO=7&etid=1&setype=1&MdlX=Contains&beginsearch=Search&guid=D108B9AB3DDF4C34B5015285C5131F3E&PG={NumPages.ToString()}";
						//http://www.controller.com/listings/forsale/list.asp?catid=3&SO=7&etid=1&setype=1&MdlX=Contains&beginsearch=Search&PG=25&guid=D108B9AB3DDF4C34B5015285C5131F3E

						// ************************************
						// GET THE WEB SITE PAGE   - commented out MSW - 9/16/24
						//      frm_NTSB_New.inet_browse.RequestTimeout = 480000
						//      frm_NTSB_New.inet_browse.AccessType = icUseDefault
						//      frm_NTSB_New.inet_browse.Protocol = icHTTP
						//      PageData = frm_NTSB_New.inet_browse.OpenURL(tmp_url)
						goto STARTPAGE;
					}

					getnextpage:;
				} // GET THE NEXT WEB PAGE
				txt_status.Text = "DONE WITH PROCESSING";
				Application.DoEvents();
				// **************************************************************
				// SEND THE EMAIL SUMMARY OF THE PROCESSING
				str_Email = $"{str_Email}<tr><td colspan=7>Total of {report_counter.ToString()} listings processed. Aircraft found {report_found.ToString()}. New Listings {new_reports.ToString()}.</td></tr>";
				str_Email = $"{str_Email}</body>";

				modEmail.EMail_Message("Homebase CON", "jetnet@jetnet.com", txt_EMailAddress.Text, "", "", $"CON Report Processing Summary for {modAdminCommon.DateToday}", str_Email, "", true);

				MessageBox.Show($"Processing Complete! Found {report_found.ToString()} out of {report_counter.ToString()} listings.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"errBrowse_Error: br_con {errMsg} {excep.Message}");
				return;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void Clear_Pubs_With_No_Changes(int[] inPublist)
		{


			string Query = "";
			ADORecordSetHelper GetPub = new ADORecordSetHelper();


			int tempForEndVar = inPublist.GetUpperBound(0);
			for (int i = 0; i <= tempForEndVar; i++)
			{
				if (inPublist[i] > 0)
				{
					Query = $"select publog_ac_id, publog_source from Publication_Log where publog_id={inPublist[i].ToString()}";
					GetPub.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(GetPub.BOF && GetPub.EOF))
					{
						//MsgBox (inPublist(i))
						ClearPub(inPublist[i], Convert.ToInt32(GetPub["publog_ac_id"]), Convert.ToString(GetPub["publog_source"]), true);
					}
					GetPub.Close();
					GetPub = null;
					//MsgBox (inPublist(i))
				}
			}
			PubsToClear = new int[1];
			cmd_ClearNoChange.Visible = false;
			Get_New_Pubs(Convert.ToString(grd_NewAvail.Tag));

		}

		//UPGRADE_NOTE: (7001) The following declaration (Get_AC_Primary) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private string Get_AC_Primary(int inACID)
		//{
			//string result = "";
			//ADORecordSetHelper snpACPrimary = new ADORecordSetHelper();
			//
			//
			//string Query = "SELECT comp_name from Company inner join Aircraft_Reference on comp_id = cref_comp_id and comp_journ_id = cref_journ_id ";
			//Query = $"{Query}WHERE cref_ac_id = {inACID.ToString()} ";
			//Query = $"{Query}AND cref_journ_id = 0  AND cref_primary_poc_flag='Y' ";
			//
			//snpACPrimary.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			//
			//if (!(snpACPrimary.BOF && snpACPrimary.EOF))
			//{
				//snpACPrimary.MoveFirst();
				//result = ($"{Convert.ToString(snpACPrimary["comp_name"])}").Trim();
			//}
			//
			//snpACPrimary.Close();
			//
			//return result;
		//}
	}
}