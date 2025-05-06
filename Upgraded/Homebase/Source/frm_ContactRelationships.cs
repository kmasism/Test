using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_ContactRelationships
		: System.Windows.Forms.Form
	{

		public frm_ContactRelationships()
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
			InitializeComponent();
		}


		private void frm_ContactRelationships_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private string gstrSal = "";
		private string gstrFName = "";
		private string gstrMName = "";
		private string gstrLName = "";
		private string gstrSuffix = "";
		private string gstrTitle = "";
		private string gstrCellNbr = "";
		private string gstrCellNbrSch = "";

		private string BuildContact(string strSal, string strFName, string strMName, string strLName, string strSuffix)
		{


			string strResults = "";

			if (strSal != "")
			{
				strResults = $"{strResults}{strSal} ";
			}

			if (strFName != "")
			{
				strResults = $"{strResults}{strFName} ";
			}

			if (strMName != "")
			{
				strResults = $"{strResults}{strMName}. ";
			}

			if (strLName != "")
			{
				strResults = $"{strResults}{strLName}";
			}

			if (strSuffix != "")
			{
				strResults = $"{strResults}, {strSuffix}";
			}
			strResults = strResults;

			return strResults;

		} // BuildContact

		public bool Load_Main_Contact_Information(int lContactId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strContact = "";
			bool bClose = false;

			string strCompany = "";

			string strContactId = "";
			int lCompId = 0;
			string strCompId = "";

			bool bResults = false;

			try
			{

				bResults = false;
				bClose = true;

				if (lContactId > 0)
				{

					strContactId = lContactId.ToString();

					strQuery1 = "SELECT comp_id, comp_name, comp_address1, comp_address2, comp_city, comp_state, comp_zip_code, comp_country, ";
					strQuery1 = $"{strQuery1}contact_id, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, contact_title, ";
					strQuery1 = $"{strQuery1}(SELECT TOP 1 pnum_number_full ";
					strQuery1 = $"{strQuery1}FROM Phone_Numbers WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (pnum_contact_id = contact_id) ";
					strQuery1 = $"{strQuery1}AND (pnum_comp_id = comp_id) ";
					strQuery1 = $"{strQuery1}AND (pnum_journ_id = contact_journ_id) ";
					strQuery1 = $"{strQuery1}AND (pnum_type = 'Mobile') ";
					strQuery1 = $"{strQuery1}ORDER BY pnum_hide_customer ";
					strQuery1 = $"{strQuery1}) AS CellNbr, ";
					strQuery1 = $"{strQuery1}(SELECT TOP 1 pnum_number_full_search ";
					strQuery1 = $"{strQuery1}FROM Phone_Numbers WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (pnum_contact_id = contact_id) ";
					strQuery1 = $"{strQuery1}AND (pnum_comp_id = comp_id) ";
					strQuery1 = $"{strQuery1}AND (pnum_journ_id = contact_journ_id) ";
					strQuery1 = $"{strQuery1}AND (pnum_type = 'Mobile') ";
					strQuery1 = $"{strQuery1}ORDER BY pnum_hide_customer ";
					strQuery1 = $"{strQuery1}) AS CellNbrSch ";
					strQuery1 = $"{strQuery1}FROM Company WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Contact WITH (NOLOCK) ON comp_id = contact_comp_id AND comp_journ_id = contact_journ_id ";
					strQuery1 = $"{strQuery1}WHERE (contact_id = {strContactId}) ";
					strQuery1 = $"{strQuery1}AND (contact_journ_id = 0) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lCompId = Convert.ToInt32(rstRec1["comp_id"]);
						strCompId = lCompId.ToString();

						gstrSal = ($"{Convert.ToString(rstRec1["contact_sirname"])} ").Trim();
						gstrFName = ($"{Convert.ToString(rstRec1["contact_first_name"])} ").Trim();
						gstrMName = ($"{Convert.ToString(rstRec1["contact_middle_initial"])} ").Trim();
						gstrLName = ($"{Convert.ToString(rstRec1["contact_last_name"])} ").Trim();
						gstrSuffix = ($"{Convert.ToString(rstRec1["contact_suffix"])} ").Trim();

						strContact = $"{BuildContact(gstrSal, gstrFName, gstrMName, gstrLName, gstrSuffix)}{Environment.NewLine}";

						gstrTitle = ($"{Convert.ToString(rstRec1["contact_title"])} ").Trim();
						if (gstrTitle != "")
						{
							strContact = $"{strContact}{gstrTitle}{Environment.NewLine}";
						}

						gstrCellNbr = $"Mobile: {{None}}{Environment.NewLine}";
						if (($"{Convert.ToString(rstRec1["CellNbr"])} ").Trim() != "")
						{
							gstrCellNbr = $"Mobile: {($"{Convert.ToString(rstRec1["CellNbr"])} ").Trim()}{Environment.NewLine}";
						}
						gstrCellNbrSch = ($"{Convert.ToString(rstRec1["CellNbrSch"])} ").Trim();

						chkSearchCellNbrOnly.Enabled = true;
						if (gstrCellNbrSch == "")
						{
							chkSearchCellNbrOnly.Enabled = false;
						}

						strCompany = $"{($"{Convert.ToString(rstRec1["comp_name"])} ").Trim()}{Environment.NewLine}";
						if (($"{Convert.ToString(rstRec1["comp_address1"])} ").Trim() != "")
						{
							strCompany = $"{strCompany}{($"{Convert.ToString(rstRec1["comp_address1"])} ").Trim()}{Environment.NewLine}";
						}
						if (($"{Convert.ToString(rstRec1["Comp_address2"])} ").Trim() != "")
						{
							strCompany = $"{strCompany}{($"{Convert.ToString(rstRec1["Comp_address2"])} ").Trim()}{Environment.NewLine}";
						}
						if (($"{Convert.ToString(rstRec1["comp_city"])} ").Trim() != "")
						{
							strCompany = $"{strCompany}{($"{Convert.ToString(rstRec1["comp_city"])} ").Trim()}, ";
						}
						if (($"{Convert.ToString(rstRec1["comp_state"])} ").Trim() != "")
						{
							strCompany = $"{strCompany}{($"{Convert.ToString(rstRec1["comp_state"])} ").Trim()} ";
						}
						if (($"{Convert.ToString(rstRec1["Comp_zip_code"])} ").Trim() != "")
						{
							strCompany = $"{strCompany}{($"{Convert.ToString(rstRec1["Comp_zip_code"])} ").Trim()} ";
						}

						if (($"{Convert.ToString(rstRec1["comp_city"])} ").Trim() != "" || ($"{Convert.ToString(rstRec1["comp_state"])} ").Trim() != "" || ($"{Convert.ToString(rstRec1["Comp_zip_code"])} ").Trim() != "")
						{
							strCompany = $"{strCompany}{Environment.NewLine}";
						}

						if (($"{Convert.ToString(rstRec1["Comp_country"])} ").Trim() != "")
						{
							strCompany = $"{strCompany}{($"{Convert.ToString(rstRec1["Comp_country"])} ").Trim()}";
						}

						lblMainContactName.Text = $"{strContact}{gstrCellNbr}{strCompany}";
						txtMainContactId.Text = strContactId;
						txtMainCompId.Text = strCompId;

						Load_Possible_Contacts(lCompId, lContactId, gstrSal, gstrFName, gstrMName, gstrLName, gstrSuffix, gstrTitle);

						Load_Related_Contacts(lCompId, lContactId);

						bResults = true;
						bClose = false;

					}
					else
					{
						MessageBox.Show($"Could NOT Find Main Contact Id: [{lContactId.ToString()})", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				}
				else
				{
					MessageBox.Show("Main Contact Id Is Blank Or Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If lContactId > 0 Then

				rstRec1 = null;

				if (bClose)
				{
					this.Close();
				}


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Load_Main_Contact_Information_Error: ({lContactId.ToString()}) - ({Information.Err().Number.ToString()}) {excep.Message}", "frm_ContactRelationships");
			}
			return false;
		} // Load_Main_Contact_Information

		private void chkSearchLNameOnly_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkSearchLNameOnly.CheckState == CheckState.Checked)
			{
				chkSearchFNameOnly.CheckState = CheckState.Unchecked;
				chkSearchCellNbrOnly.CheckState = CheckState.Unchecked;
			}

		}

		private void chkSearchFNameOnly_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkSearchFNameOnly.CheckState == CheckState.Checked)
			{
				chkSearchLNameOnly.CheckState = CheckState.Unchecked;
				chkSearchCellNbrOnly.CheckState = CheckState.Unchecked;
			}

		}

		private void chkSearchCellNbrOnly_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkSearchCellNbrOnly.CheckState == CheckState.Checked)
			{
				chkSearchFNameOnly.CheckState = CheckState.Unchecked;
				chkSearchLNameOnly.CheckState = CheckState.Unchecked;
			}

		}

		private void cmdAdd_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lContactId1 = 0;
			int lCompId1 = 0;

			int lContactId2 = 0;
			int lCompId2 = 0;
			string strRelationship = "";

			bool bUpdate = false;
			string Query = "";
			string contact_email_1 = "";
			string contact_email_2 = "";


			try
			{

				string temp_sub = "";
				if (($"{txtRelationship.Text} ").Trim() != "")
				{

					lContactId1 = Convert.ToInt32(Double.Parse(txtMainContactId.Text));
					lCompId1 = Convert.ToInt32(Double.Parse(txtMainCompId.Text));

					lContactId2 = Convert.ToInt32(Double.Parse(Convert.ToString(mfgPossibleContacts[mfgPossibleContacts.CurrentRowIndex, 0].Value)));
					lCompId2 = Convert.ToInt32(Double.Parse(Convert.ToString(mfgPossibleContacts[mfgPossibleContacts.CurrentRowIndex, 2].Value)));

					strRelationship = ($"{txtRelationship.Text} ").Trim();

					if (lContactId2 > 0 && lCompId2 > 0)
					{

						//------------------------------
						// See If It Already Exists

						strQuery1 = "SELECT * FROM Contact_Reference ";
						strQuery1 = $"{strQuery1}WHERE (cr_journ_id = 0) ";

						strQuery1 = $"{strQuery1}AND ( ";
						strQuery1 = $"{strQuery1}      (cr_contact_id = {lContactId1.ToString()}AND cr_comp_id = {lCompId1.ToString()}) ";
						strQuery1 = $"{strQuery1}   OR (cr_contact_rel_id = {lContactId1.ToString()}AND cr_comp_rel_id = {lCompId1.ToString()}) ";
						strQuery1 = $"{strQuery1}     ) ";

						strQuery1 = $"{strQuery1}AND ( ";
						strQuery1 = $"{strQuery1}      (cr_contact_id = {lContactId2.ToString()}AND cr_comp_id = {lCompId2.ToString()}) ";
						strQuery1 = $"{strQuery1}   OR (cr_contact_rel_id = {lContactId2.ToString()}AND cr_comp_rel_id = {lCompId2.ToString()}) ";
						strQuery1 = $"{strQuery1}     ) ";

						rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

						bUpdate = false;

						if ((!rstRec1.BOF) && (!rstRec1.EOF))
						{

							if (MessageBox.Show($"A Relationship Already Exists!{Environment.NewLine}Update Relationship?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
							{
								bUpdate = true;
							}
						}
						else
						{

							rstRec1.AddNew();
							bUpdate = true;

						} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then



						if (bUpdate)
						{

							rstRec1["cr_contact_id"] = lContactId1;
							rstRec1["cr_comp_id"] = lCompId1;
							rstRec1["cr_contact_rel_id"] = lContactId2;
							rstRec1["cr_comp_rel_id"] = lCompId2;
							rstRec1["cr_relation_desc"] = strRelationship;

							rstRec1.UpdateBatch();

							modCommon.ClearContactActionDate(lContactId1, 0);


							temp_sub = $"Add Contact Relation: CRId: {Convert.ToString(rstRec1["cr_id"])} CompId1: {lCompId1.ToString()} ContactId1: {lContactId1.ToString()} Relation: {strRelationship} CompId2: {lCompId2.ToString()} ContactId2: {lContactId2.ToString()}";

							modAdminCommon.Record_Event("Contact Relation", temp_sub, 0, 0, lCompId1);

							// ADDED MSW - 6/15/20
							modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
							modAdminCommon.Rec_Journal_Info.journ_subject = temp_sub;
							modAdminCommon.Rec_Journal_Info.journ_description = " ";
							modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_comp_id = lCompId1;
							modAdminCommon.Rec_Journal_Info.journ_contact_id = lContactId1;

							modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
							modAdminCommon.Rec_Journal_Info.journ_prior_account_id = " ";
							modAdminCommon.Rec_Journal_Info.journ_status = "P";

							frm_Journal.DefInstance.Commit_Journal_Entry();


							Load_Possible_Contacts(lCompId1, lContactId1, gstrSal, gstrFName, gstrMName, gstrLName, gstrSuffix, gstrTitle);

							Load_Related_Contacts(lCompId1, lContactId1);

						} // If bUpdate = True Then

						rstRec1.Close();


						strQuery1 = " select contact_id, contact_email_address ";
						strQuery1 = $"{strQuery1} from contact with (NOLOCK) ";
						//strQuery1 = strQuery1 & " left outer join phone numbers with (NOLOCK) on pnum_contact_id = contact_id and pnum_journ_id = 0 and pnum "
						strQuery1 = $"{strQuery1} where contact_journ_id = 0  ";
						strQuery1 = $"{strQuery1} and contact_id = {lContactId1.ToString()}";
						strQuery1 = $"{strQuery1} and contact_comp_id = {lCompId1.ToString()}";

						rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);


						if ((!rstRec1.BOF) && (!rstRec1.EOF))
						{

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["contact_email_address"]))
							{
								if (Convert.ToString(rstRec1["contact_email_address"]).Trim() != "")
								{
									contact_email_1 = Convert.ToString(rstRec1["contact_email_address"]).Trim();
								}
							}
						}
						rstRec1.Close();


						strQuery1 = " select contact_id, contact_email_address ";
						strQuery1 = $"{strQuery1} from contact with (NOLOCK) ";
						strQuery1 = $"{strQuery1} where contact_journ_id = 0  ";
						strQuery1 = $"{strQuery1} and contact_id = {lContactId1.ToString()}";
						strQuery1 = $"{strQuery1} and contact_comp_id = {lCompId1.ToString()}";

						rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

						if ((!rstRec1.BOF) && (!rstRec1.EOF))
						{

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["contact_email_address"]))
							{
								if (Convert.ToString(rstRec1["contact_email_address"]).Trim() != "")
								{
									contact_email_1 = Convert.ToString(rstRec1["contact_email_address"]).Trim();
								}
							}
						}
						rstRec1.Close();

						strQuery1 = " select contact_id, contact_email_address ";
						strQuery1 = $"{strQuery1} from contact with (NOLOCK) ";
						strQuery1 = $"{strQuery1} where contact_journ_id = 0  ";
						strQuery1 = $"{strQuery1} and contact_id = {lContactId2.ToString()}";
						strQuery1 = $"{strQuery1} and contact_comp_id = {lCompId2.ToString()}";

						rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

						if ((!rstRec1.BOF) && (!rstRec1.EOF))
						{

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["contact_email_address"]))
							{
								if (Convert.ToString(rstRec1["contact_email_address"]).Trim() != "")
								{
									contact_email_2 = Convert.ToString(rstRec1["contact_email_address"]).Trim();
								}
							}
						}
						rstRec1.Close();



						if (contact_email_1.Trim() != "" && contact_email_2.Trim() == "")
						{

							if (MessageBox.Show("Would you Like to Add the Contact Email Address? It is Currently Blank.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
							{
								Query = $"UPDATE Contact SET contact_email_address = '{contact_email_1.Trim()}' ";
								Query = $"{Query}WHERE contact_journ_id = 0 ";
								Query = $"{Query} and contact_id = {lContactId2.ToString()}";
								Query = $"{Query} and contact_comp_id = {lCompId2.ToString()}";
								Query = $"{Query} and contact_email_address = '' ";
								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = Query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();
							}
						}
						else if (contact_email_2.Trim() != "" && contact_email_1.Trim() == "")
						{ 

							if (MessageBox.Show("Would you Like to Add the Contact Email Address? It is Currently Blank.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
							{
								// then update contact 1 - it is currently blank
								Query = $"UPDATE Contact SET contact_email_address = '{contact_email_2.Trim()}' ";
								Query = $"{Query}WHERE contact_journ_id = 0 ";
								Query = $"{Query} and contact_id = {lContactId1.ToString()}";
								Query = $"{Query} and contact_comp_id = {lCompId1.ToString()}";
								Query = $"{Query} and contact_email_address = '' ";
								DbCommand TempCommand_2 = null;
								TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
								TempCommand_2.CommandText = Query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
								TempCommand_2.ExecuteNonQuery();
							}
						}



					}
					else
					{
						MessageBox.Show("Selected Row - ContactId Or CompId Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If lContactId2 > 0 And lCompId2 > 0 Then

				}
				else
				{
					MessageBox.Show("Relationship Text Box Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If Trim(txtRelationship.Text & " ") <> "" Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmdAdd_Click_Error: ({Information.Err().Number.ToString()}) {excep.Message}", "frm_ContactRelationships");
			}

		}

		private void cmdRefresh_Click(Object eventSender, EventArgs eventArgs)
		{


			int lCompId = Convert.ToInt32(Double.Parse(txtMainCompId.Text));
			int lContactId = Convert.ToInt32(Double.Parse(txtMainContactId.Text));

			lblStatus.Text = "Status: Refreshing";
			Load_Possible_Contacts(lCompId, lContactId, gstrSal, gstrFName, gstrMName, gstrLName, gstrSuffix, gstrTitle);

			Load_Related_Contacts(lCompId, lContactId);

		}

		private void cmdStop_Click(Object eventSender, EventArgs eventArgs) => cmdStop.Enabled = false;


		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			// Nothing At This Time

		} // Form_Unload

		private void Load_Possible_Contacts(int lCompId, int lContactId, string strSal, string strFName, string strMName, string strLName, string strSuffix, string strTitle)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			StringBuilder strContact = new StringBuilder();
			string strCompany = "";
			StringBuilder strCityStateCountry = new StringBuilder();

			string strSearchFName = "";
			string strSearchLName = "";
			string strSearchCellNbr = "";

			int lRows = 0;
			int iCol = 0;

			try
			{


				cmdAdd.Enabled = false;
				txtRelationship.Enabled = false;

				//----------------------------------------------------------------
				// Grid Headers
				// Contact Id, Contact Name, CompId, Company Name, City/State/Country

				mfgPossibleContacts.Clear();
				mfgPossibleContacts.RowsCount = 2;
				mfgPossibleContacts.ColumnsCount = 5;

				mfgPossibleContacts.CurrentRowIndex = 0;
				mfgPossibleContacts.CurrentColumnIndex = 0;

				mfgPossibleContacts.CurrentColumnIndex = 0;
				mfgPossibleContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgPossibleContacts.SetColumnWidth(mfgPossibleContacts.CurrentColumnIndex, 67);
				mfgPossibleContacts[mfgPossibleContacts.CurrentRowIndex, mfgPossibleContacts.CurrentColumnIndex].Value = "Contact Id";

				mfgPossibleContacts.CurrentColumnIndex = 1;
				mfgPossibleContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgPossibleContacts.SetColumnWidth(mfgPossibleContacts.CurrentColumnIndex, 217);
				mfgPossibleContacts[mfgPossibleContacts.CurrentRowIndex, mfgPossibleContacts.CurrentColumnIndex].Value = "Contact Name";

				mfgPossibleContacts.CurrentColumnIndex = 2;
				mfgPossibleContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgPossibleContacts.SetColumnWidth(mfgPossibleContacts.CurrentColumnIndex, 67);
				mfgPossibleContacts[mfgPossibleContacts.CurrentRowIndex, mfgPossibleContacts.CurrentColumnIndex].Value = "Comp Id";

				mfgPossibleContacts.CurrentColumnIndex = 3;
				mfgPossibleContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgPossibleContacts.SetColumnWidth(mfgPossibleContacts.CurrentColumnIndex, 217);
				mfgPossibleContacts[mfgPossibleContacts.CurrentRowIndex, mfgPossibleContacts.CurrentColumnIndex].Value = "Company Name";

				mfgPossibleContacts.CurrentColumnIndex = 4;
				mfgPossibleContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgPossibleContacts.SetColumnWidth(mfgPossibleContacts.CurrentColumnIndex, 200);
				mfgPossibleContacts[mfgPossibleContacts.CurrentRowIndex, mfgPossibleContacts.CurrentColumnIndex].Value = "City/State/Country";

				mfgPossibleContacts.FixedRows = 1;
				mfgPossibleContacts.FixedColumns = 0;
				mfgPossibleContacts.CurrentRowIndex = 1;

				//-------------------------------------------------------
				// Now Fill Grid With Data

				strSearchFName = strFName;
				strSearchLName = strLName;

				if (txtSearchDifferentFName.Text != "")
				{
					strSearchFName = txtSearchDifferentFName.Text;
				}

				if (txtSearchDifferentLName.Text != "")
				{
					strSearchLName = txtSearchDifferentLName.Text;
				}

				strSearchCellNbr = gstrCellNbrSch;

				strQuery1 = "SELECT TOP 500 * FROM Company WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Contact WITH (NOLOCK) ON comp_id = contact_comp_id AND comp_journ_id = contact_journ_id ";
				strQuery1 = $"{strQuery1}WHERE (comp_id <> {lCompId.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (comp_journ_id = 0) ";
				strQuery1 = $"{strQuery1}AND (comp_active_flag = 'Y') ";
				strQuery1 = $"{strQuery1}AND (contact_journ_id = 0) ";
				strQuery1 = $"{strQuery1}AND (contact_active_flag = 'Y') ";

				//----------------------------------------------
				//-- Do NOT Display Yourself In This Grid
				strQuery1 = $"{strQuery1}AND (contact_id <> {lContactId.ToString()}) ";

				//--------------------------------------------
				// Make Sure They Are Not Already Related

				strQuery1 = $"{strQuery1}AND (NOT EXISTS (SELECT NULL FROM Contact_Reference WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}                 WHERE ( ";
				strQuery1 = $"{strQuery1}                         (cr_comp_id = comp_id AND cr_contact_id = contact_id) ";
				strQuery1 = $"{strQuery1}                      OR (cr_comp_rel_id = comp_id AND cr_contact_rel_id = contact_id) ";
				strQuery1 = $"{strQuery1}                       ) ";
				strQuery1 = $"{strQuery1}                 and  (cr_comp_id = {lCompId.ToString()} OR cr_comp_rel_id = {lCompId.ToString()}) ";
				strQuery1 = $"{strQuery1}                 AND (cr_journ_id = comp_journ_id) ";
				strQuery1 = $"{strQuery1}            ) ";
				strQuery1 = $"{strQuery1}    ) ";

				//--------------------------------
				// First and Last Name Searching

				if (chkSearchFNameOnly.CheckState == CheckState.Checked)
				{

					strQuery1 = $"{strQuery1}AND (contact_first_name LIKE '{StringsHelper.Replace(strSearchFName, "'", "''", 1, -1, CompareMethod.Binary)}%') ";

				}
				else if (chkSearchLNameOnly.CheckState == CheckState.Checked)
				{ 

					strQuery1 = $"{strQuery1}AND (contact_last_name LIKE '{StringsHelper.Replace(strSearchLName, "'", "''", 1, -1, CompareMethod.Binary)}%') ";

				}
				else if (chkSearchCellNbrOnly.CheckState == CheckState.Checked)
				{ 

					strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM Phone_Numbers WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}             WHERE (pnum_number_full_search = '{strSearchCellNbr}') ";
					strQuery1 = $"{strQuery1}             AND (pnum_contact_id = contact_id) ";
					strQuery1 = $"{strQuery1}             AND (pnum_comp_id = comp_id) ";
					strQuery1 = $"{strQuery1}             AND (pnum_type = 'Mobile') ";
					strQuery1 = $"{strQuery1}            ) ";
					strQuery1 = $"{strQuery1}    ) ";
				}
				else
				{
					strQuery1 = $"{strQuery1}AND (contact_first_name LIKE '{StringsHelper.Replace(strSearchFName, "'", "''", 1, -1, CompareMethod.Binary)}%') ";
					strQuery1 = $"{strQuery1}AND (contact_last_name LIKE '{StringsHelper.Replace(strSearchLName, "'", "''", 1, -1, CompareMethod.Binary)}%') ";
				}

				strQuery1 = $"{strQuery1}ORDER BY comp_name, comp_id, contact_last_name, contact_first_name ";

				lblStatus.Text = "Status: Searching For Possible Related Contacts";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					cmdStop.Enabled = true;
					cmdStop.Visible = true;

					lblStatus.Text = $"Status: Found: {StringsHelper.Format(rstRec1.RecordCount, "#,##0")}";

					if (rstRec1.RecordCount > 100)
					{
						mfgPossibleContacts.Visible = false;
					}

					lRows = 1;

					do 
					{ // Loop Until rstRec1.EOF = True Or cmdStop.Enabled = False

						strContact = new StringBuilder("");

						strSal = ($"{Convert.ToString(rstRec1["contact_sirname"])} ").Trim();
						strFName = ($"{Convert.ToString(rstRec1["contact_first_name"])} ").Trim();
						strMName = ($"{Convert.ToString(rstRec1["contact_middle_initial"])} ").Trim();
						strLName = ($"{Convert.ToString(rstRec1["contact_last_name"])} ").Trim();
						strSuffix = ($"{Convert.ToString(rstRec1["contact_suffix"])} ").Trim();
						strTitle = ($"{Convert.ToString(rstRec1["contact_title"])} ").Trim();

						strContact = new StringBuilder(BuildContact(strSal, strFName, strMName, strLName, strSuffix));

						if (strTitle != "")
						{
							strContact.Append($", {strTitle}");
						}

						strCompany = ($"{Convert.ToString(rstRec1["comp_name"])} ").Trim();

						strCityStateCountry = new StringBuilder("");
						if (($"{Convert.ToString(rstRec1["comp_city"])} ").Trim() != "")
						{
							strCityStateCountry.Append($"{($"{Convert.ToString(rstRec1["comp_city"])} ").Trim()}, ");
						}

						if (($"{Convert.ToString(rstRec1["comp_state"])} ").Trim() != "")
						{
							strCityStateCountry.Append($"{($"{Convert.ToString(rstRec1["comp_state"])} ").Trim()} ");
						}

						if (($"{Convert.ToString(rstRec1["Comp_country"])} ").Trim() != "")
						{
							strCityStateCountry.Append(($"{Convert.ToString(rstRec1["Comp_country"])} ").Trim());
						}

						lRows++;
						mfgPossibleContacts.RowsCount = lRows;
						mfgPossibleContacts.CurrentRowIndex = lRows - 1;

						lblStatus.Text = $"Status: Found: {StringsHelper.Format(rstRec1.RecordCount, "#,##0")} Working: {StringsHelper.Format(lRows - 1, "#,##0")}";

						mfgPossibleContacts.set_RowData(mfgPossibleContacts.CurrentRowIndex,Convert.ToInt32( rstRec1.GetField("contact_id"))); // Save This

						//-----------------
						// Contact Id
						iCol = 0;
						mfgPossibleContacts.CurrentColumnIndex = iCol;
						mfgPossibleContacts[mfgPossibleContacts.CurrentRowIndex, mfgPossibleContacts.CurrentColumnIndex].Value = Convert.ToString(rstRec1["contact_id"]);
						mfgPossibleContacts.CellAlignment = DataGridViewContentAlignment.MiddleRight;

						//-----------------
						// Contact Name
						iCol++;
						mfgPossibleContacts.CurrentColumnIndex = iCol;
						mfgPossibleContacts[mfgPossibleContacts.CurrentRowIndex, mfgPossibleContacts.CurrentColumnIndex].Value = strContact.ToString();
						mfgPossibleContacts.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						//-----------------
						// CompId
						iCol++;
						mfgPossibleContacts.CurrentColumnIndex = iCol;
						mfgPossibleContacts[mfgPossibleContacts.CurrentRowIndex, mfgPossibleContacts.CurrentColumnIndex].Value = Convert.ToString(rstRec1["comp_id"]);
						mfgPossibleContacts.CellAlignment = DataGridViewContentAlignment.MiddleRight;

						//-----------------
						// Company Name
						iCol++;
						mfgPossibleContacts.CurrentColumnIndex = iCol;
						mfgPossibleContacts[mfgPossibleContacts.CurrentRowIndex, mfgPossibleContacts.CurrentColumnIndex].Value = strCompany;
						mfgPossibleContacts.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						//-------------------------
						// City, State, Country
						iCol++;
						mfgPossibleContacts.CurrentColumnIndex = iCol;
						mfgPossibleContacts[mfgPossibleContacts.CurrentRowIndex, mfgPossibleContacts.CurrentColumnIndex].Value = strCityStateCountry.ToString();
						mfgPossibleContacts.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!(rstRec1.EOF || !cmdStop.Enabled));

					lblStatus.Text = $"Status: Found: {StringsHelper.Format(rstRec1.RecordCount, "#,##0")}";

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				mfgPossibleContacts.CurrentRowIndex = 1;
				mfgPossibleContacts.FirstDisplayedScrollingRowIndex = 1;
				mfgPossibleContacts.CurrentColumnIndex = 0;
				//.ColSel = .Cols - 1
				mfgPossibleContacts.Visible = true;

				rstRec1.Close();
				 // mfgPossibleContacts

				cmdStop.Visible = false;
				cmdStop.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Load_Possible_Contacts_Error: ( {lCompId.ToString()})-({lContactId.ToString()} ({Information.Err().Number.ToString()}) {excep.Message}", "frm_ContactRelationships");
			}

		} // Load_Possible_Contacts

		private void mfgPossibleContacts_Click(Object eventSender, EventArgs eventArgs)
		{

			cmdAdd.Enabled = true;
			txtRelationship.Enabled = true;

		}

		private void Load_Related_Contacts(int lCompId, int lContactId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strRelatedTo = "";
			string strContact = "";
			string strSal = "";
			string strFName = "";
			string strMName = "";
			string strLName = "";
			string strSuffix = "";
			string strTitle = "";

			string strCompany = "";
			string strCityStateCountry = "";

			int lCompId1 = 0;
			int lCompId2 = 0;

			int lContactId1 = 0;
			int lContactId2 = 0;

			int lRows = 0;
			int iCol = 0;

			try
			{


				cmdDelete.Enabled = false;

				//----------------------------------------------------------------
				// Grid Headers
				// CompId1, ContactId1, Company1, Contact1, Relationship, Contact Id 2, Contact Name 2 , CompId 2, Company Name 2
				// Relationship
				// Contact Id 2, Contact Name 2 , CompId 2, Company Name 2

				mfgRelatedContacts.Clear();
				mfgRelatedContacts.RowsCount = 2;
				mfgRelatedContacts.ColumnsCount = 9;

				mfgRelatedContacts.CurrentRowIndex = 0;
				mfgRelatedContacts.CurrentColumnIndex = 0;
				iCol = -1;

				iCol++;
				mfgRelatedContacts.CurrentColumnIndex = iCol;
				mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgRelatedContacts.SetColumnWidth(mfgRelatedContacts.CurrentColumnIndex, 47);
				mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = "Comp Id";

				iCol++;
				mfgRelatedContacts.CurrentColumnIndex = iCol;
				mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgRelatedContacts.SetColumnWidth(mfgRelatedContacts.CurrentColumnIndex, 150);
				mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = "Company Name";

				iCol++;
				mfgRelatedContacts.CurrentColumnIndex = iCol;
				mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgRelatedContacts.SetColumnWidth(mfgRelatedContacts.CurrentColumnIndex, 60);
				mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = "Contact Id";

				iCol++;
				mfgRelatedContacts.CurrentColumnIndex = iCol;
				mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgRelatedContacts.SetColumnWidth(mfgRelatedContacts.CurrentColumnIndex, 167);
				mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = "Contact Name";

				//-----------------------------------------
				//-- Company 2

				iCol++;
				mfgRelatedContacts.CurrentColumnIndex = iCol;
				mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgRelatedContacts.SetColumnWidth(mfgRelatedContacts.CurrentColumnIndex, 100);
				mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = "Relationship To";

				iCol++;
				mfgRelatedContacts.CurrentColumnIndex = iCol;
				mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgRelatedContacts.SetColumnWidth(mfgRelatedContacts.CurrentColumnIndex, 60);
				mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = "Contact Id";

				iCol++;
				mfgRelatedContacts.CurrentColumnIndex = iCol;
				mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgRelatedContacts.SetColumnWidth(mfgRelatedContacts.CurrentColumnIndex, 167);
				mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = "Contact Name";

				iCol++;
				mfgRelatedContacts.CurrentColumnIndex = iCol;
				mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgRelatedContacts.SetColumnWidth(mfgRelatedContacts.CurrentColumnIndex, 47);
				mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = "Comp Id";

				iCol++;
				mfgRelatedContacts.CurrentColumnIndex = iCol;
				mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				mfgRelatedContacts.SetColumnWidth(mfgRelatedContacts.CurrentColumnIndex, 150);
				mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = "Company Name";

				mfgRelatedContacts.FixedRows = 1;
				mfgRelatedContacts.FixedColumns = 0;
				mfgRelatedContacts.CurrentRowIndex = 1;

				//-------------------------------------------------------
				// Now Fill Grid With Data

				strQuery1 = "SELECT Contact_Reference.*, ";
				strQuery1 = $"{strQuery1}(SELECT TOP 1 ";
				strQuery1 = $"{strQuery1}dbo.CreateContactFullNameTitle(contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, contact_title) ";
				strQuery1 = $"{strQuery1} FROM Contact WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1} WHERE (contact_id = cr_contact_id) ";
				strQuery1 = $"{strQuery1} AND (contact_journ_id = cr_journ_id) ";
				strQuery1 = $"{strQuery1}) As Contact1, ";

				strQuery1 = $"{strQuery1}(SELECT TOP 1 comp_name ";
				strQuery1 = $"{strQuery1} FROM Company WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1} WHERE (comp_id = cr_comp_id) ";
				strQuery1 = $"{strQuery1} AND (comp_journ_id = cr_journ_id) ";
				strQuery1 = $"{strQuery1}) As Company1, ";

				strQuery1 = $"{strQuery1}(SELECT TOP 1 ";
				strQuery1 = $"{strQuery1}dbo.CreateContactFullNameTitle(contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, contact_title) ";
				strQuery1 = $"{strQuery1} FROM Contact WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1} WHERE (contact_id = cr_contact_rel_id) ";
				strQuery1 = $"{strQuery1} AND (contact_journ_id = cr_journ_id) ";
				strQuery1 = $"{strQuery1}) As Contact2, ";

				strQuery1 = $"{strQuery1}(SELECT TOP 1 comp_name ";
				strQuery1 = $"{strQuery1} FROM Company WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1} WHERE (comp_id = cr_comp_rel_id) ";
				strQuery1 = $"{strQuery1} AND (comp_journ_id = cr_journ_id) ";
				strQuery1 = $"{strQuery1}) As Company2 ";

				strQuery1 = $"{strQuery1}";
				strQuery1 = $"{strQuery1}FROM Contact_Reference WITH (NOLOCK) ";


				strQuery1 = $"{strQuery1}WHERE ( ";
				strQuery1 = $"{strQuery1}       cr_comp_id IN (SELECT CR1.cr_comp_id FROM Contact_Reference AS CR1 ";
				strQuery1 = $"{strQuery1}                      WHERE (CR1.cr_comp_id = {lCompId.ToString()} OR CR1.cr_comp_rel_id = {lCompId.ToString()}) ";
				strQuery1 = $"{strQuery1}                      AND (CR1.cr_contact_id = {lContactId.ToString()} OR CR1.cr_contact_rel_id = {lContactId.ToString()}) ";
				strQuery1 = $"{strQuery1}                      ) ";
				strQuery1 = $"{strQuery1}  AND  cr_contact_id IN (SELECT CR1.cr_contact_id FROM Contact_Reference AS CR1 ";
				strQuery1 = $"{strQuery1}                         WHERE (CR1.cr_comp_id = {lCompId.ToString()} OR CR1.cr_comp_rel_id = {lCompId.ToString()}) ";
				strQuery1 = $"{strQuery1}                         AND (CR1.cr_contact_id = {lContactId.ToString()} OR CR1.cr_contact_rel_id = {lContactId.ToString()}) ";
				strQuery1 = $"{strQuery1}                         ) ";
				strQuery1 = $"{strQuery1}       )";
				strQuery1 = $"{strQuery1} OR   (";
				strQuery1 = $"{strQuery1}       cr_comp_rel_id IN (SELECT CR2.cr_comp_id FROM Contact_Reference AS CR2 ";
				strQuery1 = $"{strQuery1}                          WHERE (CR2.cr_comp_id = {lCompId.ToString()} OR CR2.cr_comp_rel_id = {lCompId.ToString()}) ";
				strQuery1 = $"{strQuery1}                          AND (CR2.cr_contact_id = {lContactId.ToString()} OR CR2.cr_contact_rel_id = {lContactId.ToString()}) ";
				strQuery1 = $"{strQuery1}                          ) ";
				strQuery1 = $"{strQuery1}   AND cr_contact_rel_id IN (SELECT CR2.cr_contact_id FROM Contact_Reference AS CR2 ";
				strQuery1 = $"{strQuery1}                          WHERE (CR2.cr_comp_id = {lCompId.ToString()} OR CR2.cr_comp_rel_id = {lCompId.ToString()}) ";
				strQuery1 = $"{strQuery1}                          AND (CR2.cr_contact_id = {lContactId.ToString()} OR CR2.cr_contact_rel_id = {lContactId.ToString()}) ";
				strQuery1 = $"{strQuery1}                          ) ";
				strQuery1 = $"{strQuery1}       ) ";

				strQuery1 = $"{strQuery1}AND (cr_journ_id = 0) ";

				strQuery1 = $"{strQuery1}ORDER BY cr_comp_rel_id, cr_contact_rel_id ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lRows = 1;

					do 
					{ // Loop Until rstRec1.EOF = True

						lRows++;
						mfgRelatedContacts.RowsCount = lRows;
						mfgRelatedContacts.CurrentRowIndex = lRows - 1;

						mfgRelatedContacts.set_RowData(mfgRelatedContacts.CurrentRowIndex,Convert.ToInt32( rstRec1.GetField("cr_id"))); // Save This

						//-----------------
						// Contact Id
						mfgRelatedContacts.CurrentColumnIndex = 0;
						iCol = -1;

						//-----------------
						// Company 1

						//-----------------
						// CompId
						iCol++;
						mfgRelatedContacts.CurrentColumnIndex = iCol;
						mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = Convert.ToString(rstRec1["cr_comp_id"]);
						mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleRight;

						//-----------------
						// Company Name
						iCol++;
						mfgRelatedContacts.CurrentColumnIndex = iCol;
						mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Company1"])} ").Trim();
						mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						//-----------------
						// Contact Id
						iCol++;
						mfgRelatedContacts.CurrentColumnIndex = iCol;
						mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = Convert.ToString(rstRec1["cr_contact_id"]);
						mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleRight;

						//-----------------
						// Contact Name
						iCol++;
						mfgRelatedContacts.CurrentColumnIndex = iCol;
						mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Contact1"])} ").Trim();
						mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						//-----------------
						// Company 2

						//-------------------------
						// Relationship
						iCol++;
						mfgRelatedContacts.CurrentColumnIndex = iCol;
						mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["cr_relation_desc"])} ").Trim();
						mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						//-----------------
						// Contact Id
						iCol++;
						mfgRelatedContacts.CurrentColumnIndex = iCol;
						mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = Convert.ToString(rstRec1["cr_contact_rel_id"]);
						mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleRight;

						//-----------------
						// Contact Name
						iCol++;
						mfgRelatedContacts.CurrentColumnIndex = iCol;
						mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Contact2"])} ").Trim();
						mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						//-----------------
						// CompId
						iCol++;
						mfgRelatedContacts.CurrentColumnIndex = iCol;
						mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = Convert.ToString(rstRec1["cr_comp_rel_id"]);
						mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleRight;

						//-----------------
						// Company Name
						iCol++;
						mfgRelatedContacts.CurrentColumnIndex = iCol;
						mfgRelatedContacts[mfgRelatedContacts.CurrentRowIndex, mfgRelatedContacts.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Company2"])} ").Trim();
						mfgRelatedContacts.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!rstRec1.EOF);

				}
				else
				{
					lblStatus.Text = "Status: No Related Contacts Found";
				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				mfgRelatedContacts.CurrentRowIndex = 1;
				mfgRelatedContacts.FirstDisplayedScrollingRowIndex = 1;
				mfgRelatedContacts.CurrentColumnIndex = 0;
				//.ColSel = .Cols - 1
				mfgRelatedContacts.Visible = true;

				rstRec1.Close();
				 // mfgRelatedContacts

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Load_Related_Contacts_Error: ( {lCompId.ToString()})-({lContactId.ToString()} ({Information.Err().Number.ToString()}) {excep.Message}", "frm_ContactRelationships");
			}

		} // Load_Related_Contacts

		private void mfgRelatedContacts_Click(Object eventSender, EventArgs eventArgs) => cmdDelete.Enabled = true;


		private void cmdDelete_Click(Object eventSender, EventArgs eventArgs)
		{

			string strDelete1 = "";
			int lCRId = 0;

			int lCompId1 = 0;
			int lContactId1 = 0;
			int lCompId2 = 0;
			int lContactId2 = 0;
			string strRelationship = "";

			int lRow = 0;

			try
			{

				string temp_sub = "";
				string temp_desc = "";
				if (MessageBox.Show("Delete Contact Relationship? Are You Sure?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{

					lRow = mfgRelatedContacts.CurrentRowIndex;
					lCRId = mfgRelatedContacts.get_RowData(lRow);

					if (lCRId > 0)
					{

						lCompId1 = Convert.ToInt32(Double.Parse(txtMainCompId.Text));
						lContactId1 = Convert.ToInt32(Double.Parse(txtMainContactId.Text));

						strRelationship = Convert.ToString(mfgRelatedContacts[lRow, 4].Value);
						lContactId2 = Convert.ToInt32(Double.Parse(Convert.ToString(mfgRelatedContacts[lRow, 5].Value)));
						lCompId2 = Convert.ToInt32(Double.Parse(Convert.ToString(mfgRelatedContacts[lRow, 7].Value)));

						strDelete1 = $"DELETE FROM Contact_Reference WHERE (cr_id = {lCRId.ToString()}) ";

						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strDelete1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						modCommon.ClearContactActionDate(Convert.ToInt32(Double.Parse(txtMainContactId.Text)), 0);

						modAdminCommon.Record_Event("Contact Relation", $"Delete Contact Relation: CRId: {lCRId.ToString()} CompId1: {lCompId1.ToString()} ContactId1: {lContactId1.ToString()} Relation: {strRelationship} CompId2: {lCompId2.ToString()} ContactId2: {lContactId2.ToString()}", 0, 0, lCompId1);


						// ADDED PER TASK  MSW - 7/28/2020 ------------------------------------------------

						temp_sub = "Deleted Contact Relation";
						temp_desc = $"Deleted Contact Relation: CRId: {lCRId.ToString()} CompId1: {lCompId1.ToString()} ContactId1: {lContactId1.ToString()} Relation: {strRelationship} CompId2: {lCompId2.ToString()} ContactId2: {lContactId2.ToString()}";

						// ADDED MSW - 6/15/20
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
						modAdminCommon.Rec_Journal_Info.journ_subject = temp_sub;
						modAdminCommon.Rec_Journal_Info.journ_description = temp_desc;
						modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_comp_id = lCompId1;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = lContactId1;

						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = " ";
						modAdminCommon.Rec_Journal_Info.journ_status = "P";

						frm_Journal.DefInstance.Commit_Journal_Entry();
						// ADDED PER TASK  MSW - 7/28/2020 ------------------------------------------------


						Load_Main_Contact_Information(lContactId1);

					} // If lCRId > 0 Then

				} // If MsgBox("Delete Contact Relationship? Are You Sure?", vbYesNo) = vbYes Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Load_Related_Contacts_Error: ( {lCRId.ToString()}) ({Information.Err().Number.ToString()}) {excep.Message}", "frm_ContactRelationships");
			}

		} // cmdDelete_Click
	}
}