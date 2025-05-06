using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_CompanyContact
		: System.Windows.Forms.Form
	{


		//==================
		// Public Variables
		//==================
		public int nContactID = 0;
		public int nJournID = 0;
		public int nCompanyID = 0;

		public bool bIsClearing = false;
		public string CompanyName_Renamed = "";
		public string ServicesUsed = "";
		int tmp_contact_id = 0;

		//===================
		// Private Variables
		//===================

		const int COMP_LINE_ACCESS = 6;

		private string Verified_Fields = "";
		private ADORecordSetHelper snp_CompanyContact = null;
		private bool bNewContact = false; // used to identify whether the current contact is new
		private CheckState temp_contact_active_flag = CheckState.Unchecked;
		private CheckState temp_contact_hide_flag = CheckState.Unchecked;
		private CheckState temp_contact_research_flag = CheckState.Unchecked;
		private string temp_contact_title = "";
		private string temp_contact_sirname = "";
		private string temp_contact_last_name = "";
		private string temp_contact_first_name = "";
		private string temp_contact_middle_initial = "";
		private string temp_contact_suffix = "";
		private string temp_contact_description = "";
		private string temp_contact_email_address = "";
		private string temp_chk_contact_do_not_solicit = "";
		private string temp_contact_research_email_address = "";
		private string temp_contact_acpros_seq_no = "";
		private string temp_contact_iq_email_address = "";
		private string TempContactName = "";
		private string strOwner = "";
		private string[] arrChangedFields = null;
		private string RememberWhatChanged = "";
		private string JetnetService_Used = "";
		private string Journal_List = "";

		private bool gbPGTimer1DoubleClick = false;
		private bool gbPGTimer1SingleClick = false;

		private bool bIsClearPhoneData = false;
		private bool bAdd_Phone_Number = false;
		private string Original_Phone = "";
		private string Original_Phone_Type = "";
		private CheckState Original_Phone_Hide = CheckState.Unchecked;
		private string Original_Phone_ConfirmDate = "";
		private string Original_Email = "";
		private string Original_Research_Email = "";
		private string Original_Phone_Types_Used = "";
		public bool company_contact_has_related = false;
		public bool Add_Office_Number = false;
		private string Original_Phone_No_Ext = "";


		public string country_code = "";
		public string area_code = "";
		public string prefix_code = "";
		public string number_code = "";
		public bool re_load_contact = false;
		public frm_CompanyContact()
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




		private void AddToRememberList(string changed)
		{
			//aey 10/5/2004 Track Data Changes
			int K = (RememberWhatChanged.IndexOf(changed) + 1);
			if (K == 0)
			{
				if (Strings.Len(RememberWhatChanged.Trim()) == 0)
				{
					RememberWhatChanged = changed;
				}
				else
				{
					RememberWhatChanged = $"{RememberWhatChanged},{changed}";
				}
			}
			lblChanges.Text = RememberWhatChanged;
			lblChanges.Visible = true;
		}

		// 03/04/2014 - By David D. Cruger
		// Add Or Remove EMail From Do_No_Not_Send Table
		private void AddRemoveContactEMailFromDoNotSendTable()
		{

			string strInsert1 = "";
			string strDelete1 = "";
			string strEMail = "";

			try
			{

				strEMail = ($"{txt_contact_email_address.Text} ").Trim();

				if (strEMail != "")
				{

					if (nJournID == 0)
					{


						CheckState switchVar = chkContactDoNotSendEMail.CheckState;
						if (switchVar == CheckState.Checked)
						{

							if (modCommon.DLookUp("DNSEMail_Id", "Do_Not_Send_EMail", $"DNSEMail_Address='{strEMail}'") == "")
							{

								strInsert1 = "INSERT INTO Do_Not_Send_EMail";
								strInsert1 = $"{strInsert1}(DNSEMail_Comp_Id,DNSEMail_Contact_Id,DNSEMail_Journ_Id,";
								strInsert1 = $"{strInsert1}DNSEMail_Address,DNSEMail_Description,";
								strInsert1 = $"{strInsert1}DNSEMail_Entered_Date,DNSEMail_Updated_Date,DNSEMail_WebAction_Date) ";
								strInsert1 = $"{strInsert1}VALUES (";
								strInsert1 = $"{strInsert1}{nCompanyID.ToString()},{nContactID.ToString()},{nJournID.ToString()},";
								strInsert1 = $"{strInsert1}'{strEMail}',";
								strInsert1 = $"{strInsert1}'Added By {modCommon.GetFullUserName(modAdminCommon.gbl_User_ID)}',";
								strInsert1 = $"{strInsert1}GetDate(),GetDate(),GetDate()";
								strInsert1 = $"{strInsert1})";

								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = strInsert1;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();

								modAdminCommon.Record_Event("Do_Not_Send_EMail", $"EMail Address [{strEMail}] Has Been Added To The Table", 0, 0, nCompanyID);

								ToolTipMain.SetToolTip(txt_contact_email_address, "This EMail Address Is Currently On The JETNET Do Not Send List");

							} // If DLookUp("DNSEMail_Id") Then

						}
						else if (switchVar == CheckState.Unchecked)
						{ 

							if (modCommon.DLookUp("DNSEMail_Id", "Do_Not_Send_EMail", $"DNSEMail_Address='{strEMail}'") != "")
							{

								strDelete1 = $"DELETE FROM Do_Not_Send_EMail WHERE (DNSEMail_Address = '{strEMail}') ";
								DbCommand TempCommand_2 = null;
								TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
								TempCommand_2.CommandText = strDelete1;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
								TempCommand_2.ExecuteNonQuery();

								modAdminCommon.Record_Event("Do_Not_Send_EMail", $"EMail Address [{strEMail}] Has Been Removed From The Table", 0, 0, nCompanyID);

							} // If DLookUp("DNSEMail_Id") Then

							ToolTipMain.SetToolTip(txt_contact_email_address, "");

						} // Select Case chkContactDoNotSendEMail.Value

					} // If nJournID = 0 Then

				} // If strEMail <> "" Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"AddRemoveContactEMailFromDoNotSendTable ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "Do_Not_Send_EMail");
			}

		} // AddRemoveContactEMailFromDoNotSendTable

		private object confirm_companycontact_field(string vfield)
		{

			// Function used to confirm contact fields
			try
			{

				string Query = "";
				string tmpFields = "";

				//Ask to save changes first.
				if (verify_contact_change())
				{ //aey 8/16/04
					cmd_Save_Contact_Click(cmd_Save_Contact, new EventArgs());
				}
				tmpFields = vfield;


				if (nContactID > -1 && nCompanyID > 0)
				{

					modAdminCommon.ADO_Transaction("BeginTrans");

					if ((Verified_Fields.IndexOf(vfield) + 1) == 0)
					{
						Verified_Fields = $"{Verified_Fields},{vfield}";
						Query = "UPDATE Contact SET ";
						Query = $"{Query}{vfield}_confirm_date = '{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}'";
						Query = $"{Query} WHERE contact_id = {nContactID.ToString()} AND contact_comp_id = {nCompanyID.ToString()}";
						Query = $"{Query} AND contact_journ_id = 0";

						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();


						switch(vfield)
						{
							case "contact_title" : 
								cbo_contact_title.BackColor = Color.White; 
								lblCompanyContact[1].ForeColor = SystemColors.ControlText; 
								tmpFields = StringsHelper.Replace(tmpFields, vfield, "Contact (Title)", 1, -1, CompareMethod.Binary); 
								 
								break;
							case "contact_name" : 
								txt_contact_first_name.BackColor = Color.White; 
								txt_contact_last_name.BackColor = Color.White; 
								txt_contact_middle_initial.BackColor = Color.White; 
								cbo_contact_sirname.BackColor = Color.White; 
								cbo_contact_suffix.BackColor = Color.White; 
								lblCompanyContact[2].ForeColor = SystemColors.ControlText; 
								lblCompanyContact[3].ForeColor = SystemColors.ControlText; 
								lblCompanyContact[4].ForeColor = SystemColors.ControlText; 
								lblCompanyContact[5].ForeColor = SystemColors.ControlText; 
								lblCompanyContact[6].ForeColor = SystemColors.ControlText; 
								tmpFields = StringsHelper.Replace(tmpFields, vfield, "Contact (Name)", 1, -1, CompareMethod.Binary); 
								 
								break;
							case "contact_email" : 
								 
								txt_contact_email_address.BackColor = Color.White; 
								lblCompanyContact[7].ForeColor = SystemColors.ControlText; 
								tmpFields = StringsHelper.Replace(tmpFields, vfield, "Contact (Email)", 1, -1, CompareMethod.Binary); 
								 
								break;
						}

						modAdminCommon.Rec_Journal_Info.journ_subject = modAdminCommon.Create_Confirm_Verify_Subject($"Confirmed Company: {tmpFields}", "CNCFM", 0, nCompanyID, nContactID);

						modAdminCommon.Rec_Journal_Info.journ_description = " ";
						modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CNCFM";
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = nContactID;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

						frm_Journal.DefInstance.Commit_Journal_Entry();

					}

					modAdminCommon.ADO_Transaction("CommitTrans");

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"confirm_companycontact_field_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(CONFIRM)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return null;
			}

			return null;
		}


		public string Confirm_AC_Relationships(string contact_id_list)
		{
			string result = "";
			string contact_phone_add = "";
			int number_of_contacts = 0;
			int temp_comp_id = 0;


			string query_contacts = "";
			query_contacts = $"{query_contacts} select distinct  cref_comp_id ";
			query_contacts = $"{query_contacts} from aircraft_reference with (NOLOCK)";
			query_contacts = $"{query_contacts} where cref_journ_id = 0 and cref_contact_id in ({contact_id_list}) ";


			ADORecordSetHelper snp_Contact = ADORecordSetHelper.Open(query_contacts, modAdminCommon.LOCAL_ADO_DB, "");

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Contact.Fields) && !(snp_Contact.EOF && snp_Contact.BOF))
			{


				while(!snp_Contact.EOF)
				{

					number_of_contacts++;
					if (result.Trim() != "")
					{
						result = $"{result}, ";
					}
					result = $"{result}{Convert.ToString(snp_Contact["cref_comp_id"])}";

					snp_Contact.MoveNext();

				}; // Do While Not snp_ContactPhone.EOF

			}

			snp_Contact.Close();



			return result;
		}

		public bool verify_contact_change()
		{
			//*****************************************************************************************************
			// Function used to verify contact change and return boolean decision
			//**************************************************************************************************

			bool result = false;
			try
			{

				arrChangedFields = new string[]{""};
				result = false;

				//check screen fields versus saved fields to validate if any fields changed
				if (chk_contact_active_flag.CheckState != temp_contact_active_flag)
				{
					result = true;
					AddToRememberList("Active Flag");
				}

				if (chk_HideFromCustomer.CheckState != temp_contact_hide_flag)
				{
					result = true;
					AddToRememberList("Hide Flag");
				}

				if (chk_contact_research_flag.CheckState != temp_contact_research_flag)
				{
					result = true;
					AddToRememberList("Research Only Flag");
				}

				if (cbo_contact_title.Text.Trim() != temp_contact_title.Trim() || cbo_contact_sirname.Text != temp_contact_sirname || txt_contact_last_name.Text != temp_contact_last_name || txt_contact_first_name.Text != temp_contact_first_name || txt_contact_middle_initial.Text != temp_contact_middle_initial || cbo_contact_suffix.Text != temp_contact_suffix)
				{
					Add_To_Contact_Transmit_Fields("contact_name");
					result = true;
				}


				if ((Convert.ToString(chkContactDoNotSendJNiQSurvey.Tag) == "1" && ((int) chkContactDoNotSendJNiQSurvey.CheckState).ToString() == "0") || (Convert.ToString(chkContactDoNotSendJNiQSurvey.Tag) == "0" && ((int) chkContactDoNotSendJNiQSurvey.CheckState).ToString() == "1") || (Convert.ToString(chkContactDoNotSendJNiQSurvey.Tag) == "" && ((int) chkContactDoNotSendJNiQSurvey.CheckState).ToString() == "1"))
				{
					Add_To_Contact_Transmit_Fields("contact_name");
					result = true;
				}

				if (txt_contact_description.Text != temp_contact_description)
				{
					AddToRememberList("Title");
					result = true;
					AddToRememberList("Description");
				}

				if (txt_contact_email_address.Text != temp_contact_email_address)
				{
					Add_To_Contact_Transmit_Fields("contact_email_address");
					result = true;
					AddToRememberList("EMail");
				}

				// added MSW - 2/3/22
				if (txt_iq_email.Text != temp_contact_iq_email_address)
				{
					Add_To_Contact_Transmit_Fields("contact_iq_email_address");
					result = true;
					AddToRememberList("IQEmail");
				}


				// added in msw - 6/24/21 --
				if (((int) chk_contact_do_not_solicit.CheckState).ToString().Trim() != temp_chk_contact_do_not_solicit.Trim())
				{
					Add_To_Contact_Transmit_Fields("contact_do_not_solicit");
					result = true;
					AddToRememberList("Do_No_Solicit");
				}

				if (txt_contact_research_email_address.Text != temp_contact_research_email_address)
				{
					Add_To_Contact_Transmit_Fields("contact_research_email_address");
					result = true;
					AddToRememberList("Research EMail");
				}

				if (Conversion.Val(txt_contact_acpros_seq_no.Text) != Conversion.Val(temp_contact_acpros_seq_no))
				{
					result = true;
					AddToRememberList("AC Pros Seq");
				}

				// added MSW - 4/19/21
				if (Conversion.Val(Convert.ToString(txt_iq_email.Tag)) != Conversion.Val(txt_iq_email.Text))
				{
					result = true;
					AddToRememberList("IQ Email");
				}

				// if we are not checked and N loaded
				if (chk_iq_auto.CheckState == CheckState.Unchecked && Convert.ToString(chk_iq_auto.Tag).Trim() == "N")
				{

				}
				else if (chk_iq_auto.CheckState == CheckState.Checked && Convert.ToString(chk_iq_auto.Tag).Trim() == "Y")
				{ 

				}
				else if (chk_iq_auto.CheckState == CheckState.Unchecked && Convert.ToString(chk_iq_auto.Tag).Trim() == "Y")
				{ 
					result = true;
					AddToRememberList("IQ Auto Removed");
				}
				else
				{
					result = true;
					AddToRememberList("IQ Auto Added");
				}



				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"verify_contact_change_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(VERIFY)");
				return result;
			}
		}

		public object enable_contact()
		{
			// Function used to enable contact text boxes, combo boxes, etc. that were disabled during processing
			try
			{

				txt_contact_id.Enabled = true;
				cbo_contact_title.Enabled = true;
				cbo_contact_sirname.Enabled = true;
				cbo_contact_suffix.Enabled = true;
				txt_contact_last_name.Enabled = true;
				txt_contact_first_name.Enabled = true;
				txt_contact_middle_initial.Enabled = true;
				txt_contact_description.Enabled = true;
				txt_contact_email_address.Enabled = true;
				txt_contact_research_email_address.Enabled = true;
				chkContactDoNotSendEMail.Enabled = true;
				chkContactDoNotSendJNiQSurvey.Enabled = true;
				bIsClearing = true;
				chk_contact_active_flag.Enabled = true;
				bIsClearing = false;
				chk_HideFromCustomer.Enabled = true;
				chk_contact_research_flag.Enabled = true;

				grd_Contact_Phone_Numbers.Enabled = true;

				cmd_Confirm_Contact.Enabled = true;
				cmd_Save_Contact.Enabled = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"enable_contact_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(ENABLE)");
			}

			return null;
		}

		public object disable_contact()
		{
			// Function used to disable contact textboxes, comboboxes, etc.

			try
			{

				txt_contact_id.Enabled = false;
				cbo_contact_title.Enabled = false;
				cbo_contact_sirname.Enabled = false;
				cbo_contact_suffix.Enabled = false;
				txt_contact_last_name.Enabled = false;
				txt_contact_first_name.Enabled = false;
				txt_contact_middle_initial.Enabled = false;
				txt_contact_description.Enabled = false;
				txt_contact_email_address.Enabled = false;
				txt_contact_research_email_address.Enabled = false;
				chkContactDoNotSendEMail.Enabled = false;
				chkContactDoNotSendJNiQSurvey.Enabled = false;
				bIsClearing = true;
				chk_contact_active_flag.Enabled = false;
				bIsClearing = false;
				chk_HideFromCustomer.Enabled = false;
				chk_contact_research_flag.Enabled = false;

				grd_Contact_Phone_Numbers.Enabled = false;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"disable_contact_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(DISABLE)");
				return null;
			}

			return null;
		}

		public object Add_To_Contact_Transmit_Fields(string inFieldName)
		{

			try
			{

				arrChangedFields[arrChangedFields.GetUpperBound(0)] = inFieldName;
				arrChangedFields = ArraysHelper.RedimPreserve(arrChangedFields, new int[]{arrChangedFields.GetUpperBound(0) + 2});
			}
			catch
			{

				arrChangedFields = new string[]{""};
				arrChangedFields[arrChangedFields.GetUpperBound(0)] = inFieldName;
				return null;
			}

			return null;
		}

		public object check_contact_permissions()
		{
			//*****************************************************************************************************
			// Function used for checking permissions per logon
			//*****************************************************************************************************
			try
			{

				if (Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Researcher" || Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Research Manager" || Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Administrator")
				{
					enable_contact();
				}
				else
				{
					//see who has this company record locked - if anyone
					if (nContactID > 0)
					{
						strOwner = modCommon.ContactLocked(nContactID, nJournID);

						//If someone has this locked who is not "me" then say so
						if (strOwner != "False" && strOwner != Convert.ToString(modAdminCommon.snp_User["user_id"]))
						{
							lblLockedBy.Text = $"This contact record is Locked by {strOwner}.";
							lblLockedBy.Visible = true;
							cmd_Save_Contact.Text = $"Locked by {strOwner}.";
							cmd_Save_Contact.Enabled = false;
							//Disable all fields so there can't be any updates.
							disable_contact();
						}
						else
						{
							//Lock the record
							cmd_Save_Contact.Text = "Save Contact";
							cmd_Save_Contact.Enabled = true;
							modCommon.LockContact(nContactID, nJournID, Convert.ToString(modAdminCommon.snp_User["user_id"]));
							enable_contact();
						}
					}
				}
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"check_contact_permissions_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", $"frm_CompanyContact({strOwner.Trim()})");
				return null;
			}

			return null;
		}

		private object Clear_Contact()
		{
			//*****************************************************************************************************
			// Function used for clearing contact screen fields
			//*****************************************************************************************************
			try
			{

				string cellcolor = "";

				bIsClearing = true;

				cellcolor = modAdminCommon.NoColor;

				txt_contact_id.Tag = "";
				cbo_contact_title.BackColor = Color.White;
				cbo_contact_sirname.BackColor = Color.White;
				txt_contact_last_name.BackColor = Color.White;
				txt_contact_first_name.BackColor = Color.White;
				txt_contact_middle_initial.BackColor = Color.White;
				cbo_contact_suffix.BackColor = Color.White;
				txt_contact_description.BackColor = Color.White;
				txt_contact_email_address.BackColor = Color.White;
				txt_contact_research_email_address.BackColor = Color.White;

				bIsClearing = false;
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Clear_Contct_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(CLEAR)");
				return null;
			}

			return null;
		}

		public object save_temp_contact()
		{
			//*****************************************************************************************************
			// Function used to save all contact fields to temporary fields to verify any contact changes
			//**************************************************************************************************

			try
			{

				temp_contact_title = "";
				temp_contact_sirname = "";
				temp_contact_last_name = "";
				temp_contact_first_name = "";
				temp_contact_middle_initial = "";
				temp_contact_suffix = "";
				temp_contact_description = "";
				temp_contact_email_address = "";
				temp_contact_acpros_seq_no = "";

				temp_contact_active_flag = chk_contact_active_flag.CheckState;
				temp_contact_hide_flag = chk_HideFromCustomer.CheckState;
				temp_contact_research_flag = chk_contact_research_flag.CheckState;

				if (snp_CompanyContact == null)
				{
					temp_contact_title = "";
				}
				else
				{
					temp_contact_title = "";
					if (nContactID > 0)
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_CompanyContact["Contact_Title"]))
						{
							temp_contact_title = Convert.ToString(snp_CompanyContact["Contact_Title"]).Trim();
						}
					}
				}

				temp_contact_sirname = cbo_contact_sirname.Text;
				temp_contact_last_name = txt_contact_last_name.Text;
				temp_contact_first_name = txt_contact_first_name.Text;
				temp_contact_middle_initial = txt_contact_middle_initial.Text;
				temp_contact_suffix = cbo_contact_suffix.Text;
				temp_contact_description = txt_contact_description.Text;
				temp_contact_email_address = txt_contact_email_address.Text;
				temp_contact_research_email_address = txt_contact_research_email_address.Text;
				temp_contact_acpros_seq_no = txt_contact_acpros_seq_no.Text;
				temp_chk_contact_do_not_solicit = ((int) chk_contact_do_not_solicit.CheckState).ToString().Trim();

				temp_contact_iq_email_address = txt_iq_email.Text;
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"save_temp_contact_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(SAVETMP)");
				return null; //
			}


			return null;
		}

		private void display_contact()
		{

			try
			{
				string tempconfirmdate = "";
				tempconfirmdate = DateTime.Now.ToString("d");

				Clear_Contact();

				nContactID = -1;

				txt_contact_id.Text = "";
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_id"]))
				{
					if (Convert.ToString(snp_CompanyContact["contact_id"]).Trim() != modGlobalVars.cEmptyString)
					{
						txt_contact_id.Text = Convert.ToString(snp_CompanyContact["contact_id"]);
						nContactID = Convert.ToInt32(snp_CompanyContact["contact_id"]);
					}
				}

				txt_contact_id.Tag = ($"{Convert.ToString(snp_CompanyContact["CONTACT"])} ").Trim();

				//move to the correct title.
				cbo_contact_title.SelectedIndex = -1;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_title"]))
				{

					if (Convert.ToString(snp_CompanyContact["contact_title"]).Trim() != modGlobalVars.cEmptyString)
					{

						int tempForEndVar = cbo_contact_title.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar; i++)
						{
							if (cbo_contact_title.GetListItem(i).Trim().ToLower() == Convert.ToString(snp_CompanyContact["contact_title"]).Trim().ToLower())
							{
								cbo_contact_title.SelectedIndex = i;
								break;
							}
						}

						if (cbo_contact_title.SelectedIndex == -1)
						{
							cbo_contact_title.Text = Convert.ToString(snp_CompanyContact["contact_title"]).Trim();
						}

					} // If Trim$(snp_CompanyContact("contact_title").Value) <> cEmptyString Then

				} // If Not IsNull(snp_CompanyContact("contact_title")) Then

				// added MSW 0 9/24/21 ----------------
				cbo_contact_title.Tag = "";
				if (cbo_contact_title.Text.Trim() != "")
				{
					cbo_contact_title.Tag = cbo_contact_title.Text;
				}

				//move to the correct sirname (prefix).
				cbo_contact_sirname.SelectedIndex = -1;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_sirname"]))
				{
					if (Convert.ToString(snp_CompanyContact["contact_sirname"]).Trim() != modGlobalVars.cEmptyString)
					{
						int tempForEndVar2 = cbo_contact_sirname.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar2; i++)
						{
							if (cbo_contact_sirname.GetListItem(i).Trim().ToLower() == Convert.ToString(snp_CompanyContact["contact_sirname"]).Trim().ToLower())
							{
								cbo_contact_sirname.SelectedIndex = i;
								break;
							}
						}
					}
				}

				//move to the correct suffix.
				cbo_contact_suffix.SelectedIndex = -1;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_suffix"]))
				{
					if (Convert.ToString(snp_CompanyContact["contact_suffix"]).Trim() != modGlobalVars.cEmptyString)
					{
						int tempForEndVar3 = cbo_contact_suffix.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar3; i++)
						{
							if (cbo_contact_suffix.GetListItem(i).Trim().ToLower() == Convert.ToString(snp_CompanyContact["contact_suffix"]).Trim().ToLower())
							{
								cbo_contact_suffix.SelectedIndex = i;
								break;
							}
						}
					}
				}

				//fill the contact boxes.
				txt_contact_first_name.Text = "";
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_first_name"]))
				{
					if (Convert.ToString(snp_CompanyContact["contact_first_name"]).Trim() != modGlobalVars.cEmptyString)
					{
						txt_contact_first_name.Text = Convert.ToString(snp_CompanyContact["contact_first_name"]).Trim();
					}
				}

				txt_contact_middle_initial.Text = "";
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_middle_initial"]))
				{
					if (Convert.ToString(snp_CompanyContact["contact_middle_initial"]).Trim() != modGlobalVars.cEmptyString)
					{
						txt_contact_middle_initial.Text = Convert.ToString(snp_CompanyContact["contact_middle_initial"]).Trim();
					}
				}

				txt_contact_last_name.Text = "";
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_last_name"]))
				{
					if (Convert.ToString(snp_CompanyContact["contact_last_name"]).Trim() != modGlobalVars.cEmptyString)
					{
						txt_contact_last_name.Text = Convert.ToString(snp_CompanyContact["contact_last_name"]).Trim();
					}
				}

				txt_contact_description.Text = "";
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_description"]))
				{
					if (Convert.ToString(snp_CompanyContact["contact_description"]).Trim() != modGlobalVars.cEmptyString)
					{
						txt_contact_description.Text = Convert.ToString(snp_CompanyContact["contact_description"]).Trim();
					}
				}

				txt_contact_email_address.Text = "";
				txt_contact_email_address.Tag = "";

				txt_contact_research_email_address.Text = "";
				txt_contact_research_email_address.Tag = "";

				txt_iq_email.Text = "";
				txt_iq_email.Tag = "";

				// 03/04/2014 - By David D. Cruger
				chkContactDoNotSendEMail.Enabled = false;
				chkContactDoNotSendEMail.CheckState = CheckState.Unchecked;

				// 01/06/2016 - By David D. Cruger
				chkContactDoNotSendJNiQSurvey.Enabled = false;
				chkContactDoNotSendJNiQSurvey.CheckState = CheckState.Unchecked;

				ToolTipMain.SetToolTip(txt_contact_email_address, "");
				ToolTipMain.SetToolTip(txt_contact_research_email_address, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_email_address"]))
				{

					if (Convert.ToString(snp_CompanyContact["contact_email_address"]).Trim() != modGlobalVars.cEmptyString)
					{

						txt_contact_email_address.Text = ($"{Convert.ToString(snp_CompanyContact["contact_email_address"])} ").Trim();
						txt_contact_email_address.Tag = txt_contact_email_address.Text; // Save This Value
						ToolTipMain.SetToolTip(txt_contact_email_address, "");

						// 03/04/2014 - By David D. Cruger
						if (txt_contact_email_address.Text != "")
						{

							if (modCommon.DLookUp("DNSEMail_Id", "Do_Not_Send_EMail", $"DNSEMail_Address='{txt_contact_email_address.Text}'") != "")
							{
								chkContactDoNotSendEMail.CheckState = CheckState.Checked;
								ToolTipMain.SetToolTip(txt_contact_email_address, "This EMail Address Is Currently On The JETNET Do Not Send List");
							}

						} // If txt_contact_email_address.Text <> "" Then

					} // If Trim$(snp_CompanyContact("contact_email_address").Value) <> cEmptyString Then

					chkContactDoNotSendJNiQSurvey.Tag = "0";
					// 01/06/2016 - By David D. Cruger
					if (modCommon.IsContactOnDoNotSendJNiQSurveyList(nCompanyID, nContactID))
					{
						chkContactDoNotSendJNiQSurvey.CheckState = CheckState.Checked;
						chkContactDoNotSendJNiQSurvey.Tag = "1";
						ToolTipMain.SetToolTip(txt_contact_email_address, $"{ToolTipMain.GetToolTip(txt_contact_email_address)} This EMail Address Is Currently On The Do Not Send JNiQ Survey List");
					}



				} // If Not IsNull(snp_CompanyContact("contact_email_address")) Then

				txt_contact_research_email_address.Text = ($"{Convert.ToString(snp_CompanyContact["contact_research_email_address"])} ").Trim();
				txt_contact_research_email_address.Tag = txt_contact_research_email_address.Text; // Save This Value

				chkContactDoNotSendEMail.Enabled = true;
				chkContactDoNotSendJNiQSurvey.Enabled = true;

				cmdDelete.Enabled = true;
				chk_contact_active_flag.CheckState = CheckState.Checked;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_active_flag"]))
				{
					if (Convert.ToString(snp_CompanyContact["contact_active_flag"]).ToUpper() == "N")
					{
						chk_contact_active_flag.CheckState = CheckState.Unchecked;
						cmdDelete.Enabled = false;
					}
				}
				else
				{
					cmdDelete.Enabled = false;
					chk_contact_active_flag.CheckState = CheckState.Unchecked;
				}

				chk_HideFromCustomer.CheckState = CheckState.Unchecked;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_hide_flag"]))
				{
					if (Convert.ToString(snp_CompanyContact["contact_hide_flag"]).ToUpper() == "Y")
					{
						chk_HideFromCustomer.CheckState = CheckState.Checked;
					}
				}

				chk_contact_research_flag.CheckState = CheckState.Unchecked;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_research_flag"]))
				{
					if (Convert.ToString(snp_CompanyContact["contact_research_flag"]).ToUpper() == "Y")
					{
						chk_contact_research_flag.CheckState = CheckState.Checked;
					}
				}

				// added MSW - 4/19/21
				chk_iq_auto.CheckState = CheckState.Unchecked;
				chk_iq_auto.Tag = "N";
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_iq_status"]))
				{
					if (Convert.ToString(snp_CompanyContact["contact_iq_status"]).ToUpper() == "Y")
					{
						chk_iq_auto.CheckState = CheckState.Checked;
						chk_iq_auto.Tag = "Y";
					}
				}


				// added MSW - 6/23/21
				chk_contact_do_not_solicit.CheckState = CheckState.Unchecked;
				chk_contact_do_not_solicit.Tag = "N";
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_do_not_solicit"]))
				{
					if (Convert.ToString(snp_CompanyContact["contact_do_not_solicit"]).ToUpper() == "Y")
					{
						chk_contact_do_not_solicit.CheckState = CheckState.Checked;
						chk_contact_do_not_solicit.Tag = "Y";
					}
				}

				txt_iq_email.Text = ($"{Convert.ToString(snp_CompanyContact["contact_iq_email_address"])} ").Trim();
				txt_iq_email.Tag = txt_iq_email.Text;


				TempContactName = "";
				TempContactName = $"{TempContactName}{cbo_contact_sirname.Text.Trim()} ";
				TempContactName = $"{TempContactName}{txt_contact_first_name.Text.Trim()} ";
				TempContactName = $"{TempContactName}{txt_contact_middle_initial.Text.Trim()} ";
				TempContactName = $"{TempContactName}{txt_contact_last_name.Text.Trim()} ";
				TempContactName = $"{TempContactName}{cbo_contact_suffix.Text.Trim()}";

				TempContactName = TempContactName.Trim();

				fill_contact_phone_Grid();

				// DETERMINE if CONTACT FIELDS REQUIRE CONFIRMATION
				// CHECK CONTACT NAME FIELDS
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_name_confirm_date"]))
				{
					if (Information.IsDate(snp_CompanyContact["contact_name_confirm_date"]))
					{
						tempconfirmdate = DateTimeHelper.ToString(DateTime.Parse(Convert.ToString(snp_CompanyContact["contact_name_confirm_date"])).AddDays(modAdminCommon.gbl_ConfirmDays));
					}
				}

				if (DateTime.Parse(tempconfirmdate) <= DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)) && nJournID == 0)
				{
					txt_contact_first_name.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
					txt_contact_last_name.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
					txt_contact_middle_initial.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
					cbo_contact_sirname.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
					cbo_contact_suffix.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
					lblCompanyContact[2].ForeColor = Color.Black;
					lblCompanyContact[3].ForeColor = Color.Black;
					lblCompanyContact[4].ForeColor = Color.Black;
					lblCompanyContact[5].ForeColor = Color.Black;
					lblCompanyContact[6].ForeColor = Color.Black;
				}
				else
				{
					txt_contact_first_name.BackColor = Color.White;
					txt_contact_last_name.BackColor = Color.White;
					txt_contact_middle_initial.BackColor = Color.White;
					cbo_contact_sirname.BackColor = Color.White;
					cbo_contact_suffix.BackColor = Color.White;
					lblCompanyContact[2].ForeColor = SystemColors.ControlText;
					lblCompanyContact[3].ForeColor = SystemColors.ControlText;
					lblCompanyContact[4].ForeColor = SystemColors.ControlText;
					lblCompanyContact[5].ForeColor = SystemColors.ControlText;
					lblCompanyContact[6].ForeColor = SystemColors.ControlText;
				}


				// CHECK CONTACT TITLE
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_title_confirm_date"]))
				{
					if (Information.IsDate(snp_CompanyContact["contact_title_confirm_date"]))
					{
						tempconfirmdate = DateTimeHelper.ToString(DateTime.Parse(Convert.ToString(snp_CompanyContact["contact_title_confirm_date"])).AddDays(modAdminCommon.gbl_ConfirmDays));
					}
				}

				if (DateTime.Parse(tempconfirmdate) <= DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)) && nJournID == 0)
				{
					cbo_contact_title.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
					lblCompanyContact[1].ForeColor = Color.FromArgb(192, 0, 0);
				}
				else
				{
					cbo_contact_title.BackColor = Color.White;
					lblCompanyContact[1].ForeColor = SystemColors.ControlText;
				}

				// CHECK CONTACT EMAIL
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_email_confirm_date"]))
				{
					if (Information.IsDate(snp_CompanyContact["contact_email_confirm_date"]))
					{
						tempconfirmdate = DateTimeHelper.ToString(DateTime.Parse(Convert.ToString(snp_CompanyContact["contact_email_confirm_date"])).AddDays(modAdminCommon.gbl_ConfirmDays));
					}
				}

				if (DateTime.Parse(tempconfirmdate) <= DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)) && nJournID == 0)
				{
					txt_contact_email_address.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
					lblCompanyContact[7].ForeColor = Color.FromArgb(192, 0, 0);
				}
				else
				{
					txt_contact_email_address.BackColor = Color.White;
					lblCompanyContact[7].ForeColor = SystemColors.ControlText;
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_acpros_seq_no"]))
				{
					if (Convert.ToInt32(snp_CompanyContact["contact_acpros_seq_no"]) > 0)
					{
						txt_contact_acpros_seq_no.Text = Convert.ToString(snp_CompanyContact["contact_acpros_seq_no"]).Trim();
					}
				}

				lbl_contact_entry_date.Text = "";
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_entry_date"]))
				{
					if (Information.IsDate(snp_CompanyContact["contact_entry_date"]))
					{
						lbl_contact_entry_date.Text = Convert.ToDateTime(snp_CompanyContact["contact_entry_date"]).ToString("d");
					}
				}

				lbl_contact_update_date.Text = "";
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_CompanyContact["contact_update_date"]))
				{
					if (Information.IsDate(snp_CompanyContact["contact_update_date"]))
					{
						lbl_contact_update_date.Text = Convert.ToDateTime(snp_CompanyContact["contact_update_date"]).ToString("d");
					}
				}

				save_temp_contact();

				cmd_Confirm_Contact.Visible = true;
				cmd_Subscription.Visible = true;

				if (nCompanyID > 0)
				{
					cmd_Confirm_Contact.Enabled = true;
					grd_Contact_Phone_Numbers.Enabled = true;
					cmd_add_contact_phone.Enabled = true;
					cmd_confirm_contact_Phone.Enabled = true;
					cmd_delete_contact_Phone.Enabled = true;
				}
				else
				{
					cmd_Confirm_Contact.Enabled = false;
					grd_Contact_Phone_Numbers.Enabled = false;
					cmd_add_contact_phone.Enabled = false;
					cmd_confirm_contact_Phone.Enabled = false;
					cmd_delete_contact_Phone.Enabled = false;
				}
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Save_Temp_Contact_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(DISPLAY)");
				return;
			}

		}

		private object select_contact()
		{
			//*****************************************************************************************************
			// Function used to Select contact
			//**************************************************************************************************
			try
			{
				string Query = "";

				Query = "SELECT *, ";
				Query = $"{Query}dbo.CreateContactFullNameTitle(contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, '') As Contact ";
				Query = $"{Query}FROM Contact WITH(NOLOCK) ";
				Query = $"{Query}WHERE (contact_id = {nContactID.ToString()}) ";
				Query = $"{Query}AND (contact_journ_id = {nJournID.ToString()}) ";
				Query = $"{Query}AND (contact_comp_id = {nCompanyID.ToString()}) ";

				snp_CompanyContact = new ADORecordSetHelper();
				snp_CompanyContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_CompanyContact.BOF && snp_CompanyContact.EOF))
				{
					display_contact();
				}

				check_contact_permissions();
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"select_contact_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(SELECT)");
				return null;
			}

			return null;
		}

		private void cbo_contact_sirname_Leave(Object eventSender, EventArgs eventArgs)
		{

			string strText = ($"{cbo_contact_sirname.Text} ").Trim();

			if (strText != "")
			{
				if (!modCommon.IsComboTextInList(cbo_contact_sirname, strText))
				{
					MessageBox.Show($"Contact Prefix Value [{strText}] Is NOT In Pull Down", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					cbo_contact_sirname.Text = "";
					cbo_contact_sirname.Focus();
				}
			}

		} // cbo_contact_sirname_LostFocus

		private void cbo_contact_suffix_Leave(Object eventSender, EventArgs eventArgs)
		{

			string strText = ($"{cbo_contact_suffix.Text} ").Trim();

			if (strText != "")
			{
				if (!modCommon.IsComboTextInList(cbo_contact_suffix, strText))
				{
					MessageBox.Show($"Contact Suffix Value [{strText}] Is NOT In Pull Down", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					cbo_contact_suffix.Text = "";
					cbo_contact_suffix.Focus();
				}
			}

		}

		private void cbo_contact_title_Leave(Object eventSender, EventArgs eventArgs)
		{

			string strText = ($"{cbo_contact_title.Text} ").Trim();

		}

		private void chk_contact_active_flag_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			int lSubId = 0;
			int lParentId = 0;

			if (chk_contact_active_flag.Enabled)
			{

				chk_contact_active_flag.Enabled = false;

				if (chk_contact_active_flag.CheckState == CheckState.Unchecked)
				{

					if (nJournID == 0)
					{

						if (modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId))
						{
							MessageBox.Show($"This Contact Has An Active Subscription{Environment.NewLine}{Environment.NewLine}You Can NOT Inactive This Contact", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							chk_contact_active_flag.CheckState = CheckState.Checked;
						}

					}

				} // If chk_contact_active_flag.Value = vbUnchecked Then

				chk_contact_active_flag.Enabled = true;

			} // If chk_contact_active_flag.Enabled = True Then

		} // chk_contact_active_flag_Click

		private void chk_contact_active_flag_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;


			fill_research_contact_list();

			lblCompanyContact[13].Visible = true;
			cbo_replacement_contact.Visible = true;
			cmd_add_new_contact.Visible = true;



		}

		private void chkContactDoNotSendEMail_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkContactDoNotSendEMail.Enabled)
			{

				chkContactDoNotSendEMail.Enabled = false;


				CheckState switchVar = chkContactDoNotSendEMail.CheckState;
				// Add To Do Not Send EMail Table
				if (switchVar == CheckState.Checked)
				{

					if (MessageBox.Show($"Checking This Will Stop This Contact From Receiving JETNET Mass EMails{Environment.NewLine}Are You Sure?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
					{
						chkContactDoNotSendEMail.CheckState = CheckState.Unchecked;
					}
					else
					{

						//---------------------------------
						// Is Contact On A Mailing List?

						if (modCommon.DLookUp("journ_id", "journal", $"(journ_subcategory_code LIKE 'ML%' AND journ_comp_id = {nCompanyID.ToString()} AND journ_contact_id = {nContactID.ToString()})") != "")
						{
							MessageBox.Show($"This Contact Is Also On A Mailing List{Environment.NewLine}Please Remember To Remove Them", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						}

					}

					// Remove From Do Not Send EMail Table
				}
				else if (switchVar == CheckState.Unchecked)
				{ 

					if (MessageBox.Show($"Unchecking This Will Remove This Contacts EMail From The Do Not Send List{Environment.NewLine}Are You Sure?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
					{
						chkContactDoNotSendEMail.CheckState = CheckState.Checked;
					}

				} // Select Case chkContactDoNotSendEMail.Value

				chkContactDoNotSendEMail.Enabled = true;

			} // If chkContactDoNotSendEMail.Enabled = True Then

		}

		private void chkContactDoNotSendJNiQSurvey_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			string strDelete1 = "";
			string strContact = "";
			string strEMail = "";
			int lDel1 = 0;

			try
			{

				strDelete1 = "DELETE FROM EventLog ";
				strDelete1 = $"{strDelete1}WHERE (evtl_comp_id = {nCompanyID.ToString()}) ";
				strDelete1 = $"{strDelete1}AND (evtl_contact_id = {nContactID.ToString()}) ";
				strDelete1 = $"{strDelete1}AND (evtl_type = 'Do Not Send JNiQ Survey') ";

				if (chkContactDoNotSendJNiQSurvey.Enabled)
				{

					chkContactDoNotSendJNiQSurvey.Enabled = false;

					strContact = modCommon.GetContactName(nContactID, 0);
					strEMail = txt_contact_email_address.Text.Trim();


					CheckState switchVar = chkContactDoNotSendJNiQSurvey.CheckState;
					if (switchVar == CheckState.Checked)
					{

						if (MessageBox.Show($"Checking This Will Stop This Contact From Receiving JNiQ Surveys{Environment.NewLine}Are You Sure?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						{
							chkContactDoNotSendJNiQSurvey.CheckState = CheckState.Unchecked;
						}
						else
						{
							//--------------------------------------------------
							// Delete Just To Make Sure There Is Only One Entry
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strDelete1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							lDel1 = TempCommand.ExecuteNonQuery();
							modAdminCommon.Record_Event("Do Not Send JNiQ Survey", $"Contact: {strContact} EMail: {strEMail}", 0, 0, nCompanyID, false, 0, nContactID);
							modAdminCommon.Record_Event("Contact", $"Added Contact To The Do Not Send JNiQ Survey List - Contact: {strContact} EMail: {strEMail}", 0, 0, nCompanyID, false, 0, nContactID);
						}

					}
					else if (switchVar == CheckState.Unchecked)
					{ 

						if (MessageBox.Show($"Unchecking This Will Remove This Contact From The Do Not Send JNiQ Survey List{Environment.NewLine}Are You Sure?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						{
							chkContactDoNotSendJNiQSurvey.CheckState = CheckState.Checked;
						}
						else
						{
							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = strDelete1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							lDel1 = TempCommand_2.ExecuteNonQuery();
							modAdminCommon.Record_Event("Contact", $"Removed Contact From The Do Not Send JNiQ Survey List - Contact: {strContact} EMail: {strEMail}", 0, 0, nCompanyID, false, 0, nContactID);
						}

					} // Case chkContactDoNotSendJNiQSurvey

					chkContactDoNotSendJNiQSurvey.Enabled = true;

				} // If chkContactDoNotSendJNiQSurvey.Enabled = True Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"chkContactDoNotSendJNiQSurvey_Click_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(chkContactDoNotSendJNiQSurvey_Click)");
			}

		} // chkContactDoNotSendJNiQSurvey_Click

		private void cmd_add_new_contact_Click(Object eventSender, EventArgs eventArgs)
		{
			frm_CompanyContact new_frm_CompanyContact = frm_CompanyContact.CreateInstance();


			new_frm_CompanyContact.nContactID = -1;
			new_frm_CompanyContact.nCompanyID = nCompanyID;
			new_frm_CompanyContact.nJournID = nJournID;
			new_frm_CompanyContact.CompanyName_Renamed = modCommon.GetCompanyName(nCompanyID, nJournID);
			new_frm_CompanyContact.ServicesUsed = modCommon.GetCompanyServiceName(nCompanyID, nJournID, modGlobalVars.ServicesUsed_Array);
			new_frm_CompanyContact.Add_Office_Number = false;

			this.Cursor = Cursors.WaitCursor;

			new_frm_CompanyContact.Top = Convert.ToInt32(mdi_ResearchAssistant.DefInstance.Top + ((mdi_ResearchAssistant.DefInstance.Height - new_frm_CompanyContact.Height) / 2d));
			new_frm_CompanyContact.Left = Convert.ToInt32(mdi_ResearchAssistant.DefInstance.Left + ((mdi_ResearchAssistant.DefInstance.Width - new_frm_CompanyContact.Width) / 2d)); // mdi_ResearchAssistant

			new_frm_CompanyContact.ShowDialog();

			new_frm_CompanyContact.Add_Office_Number = false;


			new_frm_CompanyContact = null;

			this.Activate();


			fill_research_contact_list();

			modSubscription.search_off();

			return;

		}

		private void cmd_Close_Click(Object eventSender, EventArgs eventArgs)
		{

			DialogResult iMsgBox = (DialogResult) 0;
			DialogResult iResponse = (DialogResult) 0;
			string contact_id_list = "";
			int lSubId = 0;
			int lParentId = 0;

			try
			{

				iMsgBox = System.Windows.Forms.DialogResult.Yes;
				iResponse = System.Windows.Forms.DialogResult.Yes;


				if (verify_contact_change())
				{

					iMsgBox = MessageBox.Show("Do You Want to Save Contact Changes?", "Company Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (iMsgBox == System.Windows.Forms.DialogResult.Yes)
					{

						// 02/19/2015 - By David D. Cruger
						// Added Check For Changed EMail With A Contact With An Active Subscription

						if (Original_Email.Trim() != txt_contact_email_address.Text.Trim())
						{
							if (modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId))
							{
								iMsgBox = MessageBox.Show($"The Email Address Has Changed{Environment.NewLine}{Environment.NewLine}This will change the user's Subscription{Environment.NewLine}{Environment.NewLine}Continue?", "Email Change", MessageBoxButtons.YesNo);
								if (iMsgBox == System.Windows.Forms.DialogResult.Yes)
								{
									modAdminCommon.Record_Event("Changed Contact EMail", $"Contact Has Active Subscription - New EMail Address [{txt_contact_email_address.Text.Trim()}]", 0, 0, nCompanyID, false, 0, nContactID);
								}
							}
						}


						if (iMsgBox == System.Windows.Forms.DialogResult.Yes)
						{

							this.Cursor = Cursors.WaitCursor;
							save_contact(ref iResponse);

						} // If iMsgBox = vbYes Then

					}
					else
					{

						// journ for deleted phone #
						if (Journal_List != "")
						{
							MessageBox.Show("Please manually remove the Journal note for deleted contact phone.", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}

					} // If iMsgBox = vbYes Then

				} // If (verify_contact_change) Then

				bIsClearing = true;

				Contact_Message_Off();

				if (iResponse == System.Windows.Forms.DialogResult.Yes)
				{
					this.Close();
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmd_Close_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(CLOSE)");
				Contact_Message_Off();
			}

		}

		private void cmd_Confirm_Contact_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;

				if (verify_contact_change())
				{ //aey 8/16/04
					cmd_Save_Contact_Click(cmd_Save_Contact, new EventArgs());
				}

				confirm_companycontact_field("contact_title");
				confirm_companycontact_field("contact_name");
				confirm_companycontact_field("contact_email");

				confirm_all_contact_phone_numbers();

				select_contact();
				fill_contact_phone_Grid();

				Contact_Message_Off();
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmd_Confirm_Contact_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(CONFIRM)");
			}

		}

		private void cmd_Save_Contact_Click(Object eventSender, EventArgs eventArgs)
		{

			string strMsg = "";
			DialogResult iMsgBox = (DialogResult) 0;
			bool bSubscription = false;
			int lSubId = 0;
			int lParentId = 0;
			bool skip_save = false;
			bool is_front_egg = false;

			try
			{

				Contact_Message_On("Saving Contact ....");


				iMsgBox = System.Windows.Forms.DialogResult.Yes;
				skip_save = false;
				is_front_egg = false;

				bSubscription = modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId);


				if (Original_Email.Trim() != txt_contact_email_address.Text.Trim())
				{
					if (bSubscription)
					{
						iMsgBox = MessageBox.Show($"The Email Address Has Changed{Environment.NewLine}{Environment.NewLine}This will change the user's Subscription{Environment.NewLine}{Environment.NewLine}Continue?", "Email Change", MessageBoxButtons.YesNo);
						if (iMsgBox == System.Windows.Forms.DialogResult.Yes)
						{
							strMsg = $"Contact Has Active Subscription - New EMail Address [{txt_contact_email_address.Text.Trim()}]";
							modAdminCommon.Record_Event("Changed Contact EMail", strMsg, 0, 0, nCompanyID, false, 0, nContactID);
						}
					} // If bSubscription = True Then
				}

				//--------- ADDED MSW - 11/18/19------------
				if (txt_contact_research_email_address.Text.Trim() != "")
				{
					if (!modCommon.QuickCheckEmailAddress(txt_contact_research_email_address.Text.Trim()))
					{
						skip_save = true;
					}
				}

				if (skip_save)
				{ // no need to double check
				}
				else if (txt_contact_email_address.Text.Trim() != "")
				{ 
					if (!modCommon.QuickCheckEmailAddress(txt_contact_email_address.Text.Trim()))
					{
						skip_save = true;
					}
				}
				//--------- ADDED MSW - 11/18/19------------

				string temp_login_name = "";
				int temp_sub_id = 0;
				if (skip_save)
				{
				}
				else if (iMsgBox == System.Windows.Forms.DialogResult.Yes)
				{ 

					re_load_contact = true;

					cmd_Close.Enabled = false;
					save_contact();

					//if its changed
					if (Original_Email.Trim() != txt_contact_email_address.Text.Trim())
					{
						temp_sub_id = lSubId;

						if (modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId, false, ref temp_login_name))
						{
							// this will return true if it is frontegg, so false means no front egg, means update
							//If Does_Contact_Have_An_Active_Subscription(nContactID, lSubId, lParentId, True) = False Then

							is_front_egg = modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId, true);
							// means it is not frontegg
							modCommon.UpdateLogin_Fields(nContactID, temp_sub_id, temp_login_name, is_front_egg);
							//End If
						}
					}

					if (re_load_contact)
					{
						Application.DoEvents();
						select_contact();
					}
					re_load_contact = true;

					Application.DoEvents();
					cmd_Close.Enabled = true;

				}



				Contact_Message_Off();
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmd_Save_Contact_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(SAVE)");
			}


		}

		private void cmd_Subscription_Click(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				modSubscription.Entered_Subscription_ID = 0;
				modSubscription.Entered_Contact_ID = nContactID;

				modCommon.CenterFormOnHomebaseMainForm(frm_Subscription.DefInstance);

				frm_Subscription.DefInstance.ShowDialog();

				frm_Subscription.DefInstance.Close();

				Contact_Message_Off();
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmd_Subscription_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(SUBSCRIPTION)");
				return;
			}

		}

		private void cmdDelete_Click(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				string strDelete1 = "";

				bool bSubscription = false;
				int lSubId = 0;
				int lParentId = 0;
				string strEMailTo = "";
				string strEMailSubject = "";
				string strEMailBody = "";
				bool bResults = false;
				string strErrMsg = "";

				if (chk_contact_active_flag.CheckState == CheckState.Checked)
				{
					MessageBox.Show("Delete is not allowed on an active contact!", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				bSubscription = modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId);

				strDelete1 = $"DELETE Contact WHERE contact_id = {nContactID.ToString()}";

				modAdminCommon.ADO_Transaction("BeginTrans");
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strDelete1;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				//record the removed contact in a journal entry  aey 10/6/04
				modAdminCommon.Rec_Journal_Info.journ_subject = ($"Contact Removed : {cbo_contact_sirname.Text.Trim()} {modAdminCommon.Fix_Quote(txt_contact_first_name.Text).Trim()}{((txt_contact_middle_initial.Text.Trim() != "") ? $"{txt_contact_middle_initial.Text.Trim()}." : "")}{modAdminCommon.Fix_Quote(txt_contact_last_name.Text).Trim()} {cbo_contact_suffix.Text.Trim()}").Trim();
				modAdminCommon.Rec_Journal_Info.journ_description = $"Remove Contact - done by {modAdminCommon.gbl_User_ID}";
				modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
				modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
				modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
				modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
				modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
				modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
				modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
				modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
				modAdminCommon.Rec_Journal_Info.journ_status = "A";
				modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

				frm_Journal.DefInstance.Commit_Journal_Entry();

				modAdminCommon.ADO_Transaction("CommitTrans");

				if (bSubscription)
				{

					if (nJournID == 0)
					{

						strEMailTo = ($"{modCommon.DLookUp("aconfig_email_company_contact_chg", "Application_Configuration")}").Trim();


						strEMailSubject = $"Homebase Contact Deleted for {CompanyName_Renamed} [{nCompanyID.ToString()}] {TempContactName} [{nContactID.ToString()}] ";

						strEMailBody = $"Homebase Contact Deleted{Environment.NewLine}{Environment.NewLine}";
						strEMailBody = $"{strEMailBody}Company: {CompanyName_Renamed} [{nCompanyID.ToString()}] {Environment.NewLine}{Environment.NewLine}";
						strEMailBody = $"{strEMailBody}Contact: {TempContactName} [{nContactID.ToString()}] & vbCrLf & vbCrLf";

						bResults = modEmail.Simple_Insert_EMail_Queue_Record(strEMailTo, "", "", strEMailSubject, strEMailBody, "", "N", "Open", "Homebase Contact Deleted", "jetnet@jetnet.com", nCompanyID, nContactID);

						if (bResults)
						{
							modEmail.Send_All_EMail_In_Queue(ref strErrMsg, nCompanyID);
						}

						modCommon.Enter_Customer_Program_Message_Note("", strEMailTo, $"{strEMailSubject}{Environment.NewLine}{strEMailBody}", lSubId, lParentId, nCompanyID, nContactID);

					} // If nJournID = 0 Then

				} // If bSubscription = True Then

				this.Close();
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmdDelete_Click_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(DELETE)");
				modAdminCommon.ADO_Transaction("RollbackTrans");

				return;
			}

		} // cmdDelete_Click

		private void cmdFindContactMatch_Click(Object eventSender, EventArgs eventArgs)
		{

			if (cmdFindContactMatch.Enabled)
			{

				cmdFindContactMatch.Enabled = false;

				if (nContactID > 0)
				{

					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(frm_ContactRelationships.DefInstance);

					if (frm_ContactRelationships.DefInstance.Load_Main_Contact_Information(nContactID))
					{

						modCommon.CenterFormOnHomebaseMainForm(frm_ContactRelationships.DefInstance);
						frm_ContactRelationships.DefInstance.ShowDialog();

						frm_ContactRelationships.DefInstance.Close();

					} // If frm_ContactRelationships.Load_Main_Contact_Information(nContactID) = True Then

				}
				else
				{
					MessageBox.Show("Contact Id Is Blank Or Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If nContactID > 0 Then

				cmdFindContactMatch.Enabled = true;

			} // If cmdFindContactMatch.Enabled = True Then

		} // cmdFindContactMatch_Click

		//UPGRADE_NOTE: (7001) The following declaration (Command1_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Command1_Click()
		//{
			//
			//
			//
		//}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				string strCRId = "";
				string strMsg = "";
				System.DateTime dtStartDate = DateTime.FromOADate(0);
				System.DateTime dtEndDate = DateTime.FromOADate(0);

				try
				{

					modCommon.Start_Activity_Monitor_Message("Open Contact", ref strMsg, ref dtStartDate, ref dtEndDate);

					RememberWhatChanged = "";

					//if a new contact then default to active.
					if (nContactID == -1)
					{
						bIsClearing = true;
						chk_contact_active_flag.CheckState = CheckState.Checked;
						bIsClearing = false;
						cmd_Confirm_Contact.Visible = false;
						cmd_Subscription.Visible = false;

						fill_contact_phone_Grid();

						grd_Contact_Phone_Numbers.Enabled = false;
						cmd_add_contact_phone.Enabled = false;
						cmd_confirm_contact_Phone.Enabled = false;
						cmd_delete_contact_Phone.Enabled = false;

						save_temp_contact();

						strMsg = $"{strMsg} - New Contact";

					}
					else
					{

						Contact_Message_On("Selecting Contact ...");

						select_contact();

						if (!snp_CompanyContact.BOF && !snp_CompanyContact.EOF)
						{
							strMsg = $"{strMsg} - {($"{Convert.ToString(snp_CompanyContact["CONTACT"])} ").Trim()}";
						}

					}

					Original_Email = txt_contact_email_address.Text;
					Original_Research_Email = txt_contact_research_email_address.Text;

					JetnetService_Used = ServicesUsed.Substring(0, Math.Min(1, ServicesUsed.Length)).ToUpper();
					cmdViewBadContactEmails.Enabled = false;

					if ((tmp_contact_id != nContactID) && (nContactID > 0) && (tmp_contact_id > 0))
					{ //aey 11/24/04
						//if it's not a new contact, then tmp_contact_id & nContactID should agree
						throw new Exception();
					}

					if (nCompanyID == 0)
					{
						throw new Exception();
					}

					lblContactRelationships.Visible = false;

					//-------------------------------------------------------------------------------
					//-- Check To See If There Is A Contact Relationship For This Contact Record

					strCRId = modCommon.DLookUp("cr_id", "Contact_Reference", $"cr_contact_id = {nContactID.ToString()} OR cr_contact_rel_id = {nContactID.ToString()}");
					if (strCRId != "")
					{
						lblContactRelationships.Visible = true;
					}

					modCommon.End_Activity_Monitor_Message("Open Contact", ref strMsg, dtStartDate, ref dtEndDate, 0, nJournID, nCompanyID, 0, nContactID);

					frm_UserHistory.DefInstance.Refresh_User_History_Grids("Contact");


					cmdDelete.Enabled = modAdminCommon.gbl_User_ID.ToLower() == "mvit" || modAdminCommon.gbl_User_ID.ToLower() == "jkc" || modAdminCommon.gbl_User_ID.ToLower() == "pls" || modAdminCommon.gbl_User_ID.ToLower() == "llz" || modAdminCommon.gbl_User_ID.ToLower() == "lmc";


					Contact_Message_Off();

					return;
				}
				catch (System.Exception excep)
				{

					this.Cursor = CursorHelper.CursorDefault;
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					modAdminCommon.Report_Error($"Form_Activate_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(Activate)");
					return;
				}
			}
		}

		private void Form_Initialize()
		{

			try
			{
				int iClickSpeed = 0;

				gbPGTimer1DoubleClick = false;
				gbPGTimer1SingleClick = false;

				iClickSpeed = modCommon.GetDoubleClickSpeed();

				pgTimer1.Enabled = false;
				if (iClickSpeed == 0)
				{
					pgTimer1.Enabled = false;
				}
				else
				{
					pgTimer1.Interval = iClickSpeed;
					pgTimer1.Enabled = true;
				}

				modCommon.CenterFormOnHomebaseMainForm(this);

				bIsClearPhoneData = false;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Form_Initialize_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(Initialize)");
				return;
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			try
			{

				Verified_Fields = "";
				RememberWhatChanged = "";
				lblChanges.Text = "";
				lblChanges.Visible = false;
				lblLockedBy.Text = "";
				lblLockedBy.Visible = false;
				bAdd_Phone_Number = false;

				Journal_List = "";

				modFillCompConControls.fill_contactsirname_FromArray(cbo_contact_sirname);
				modFillCompConControls.fill_contactsuffix_FromArray(cbo_contact_suffix);
				modFillCompConControls.Fill_TitleGroup_FromArray(lstTitleGroup);
				//Call modFillCompConControls.Fill_Contact_Title(cbo_contact_title, lstTitleGroup)
				modFillCompConControls.fill_phonetype_FromArray(cbo_pnum_type);
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Form_Load_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(Load)");
			}

		} // Form_Load

		private void Form_FormClosing(Object eventSender, FormClosingEventArgs eventArgs)
		{
			int Cancel = (eventArgs.Cancel) ? 1 : 0;
			int UnloadMode = (int) eventArgs.CloseReason;
			try
			{

				DialogResult iMsgBox = (DialogResult) 0;
				DialogResult iResponse = (DialogResult) 0;
				int lSubId = 0;
				int lParentId = 0;
				string temp_login_name = "";

				Cancel = 0;
				bool is_front_egg = false;

				if (verify_contact_change())
				{

					iMsgBox = MessageBox.Show("Do You Want to Save Contact Changes?", "Company Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (iMsgBox == System.Windows.Forms.DialogResult.Yes)
					{

						// 02/19/2015 - By David D. Cruger
						// Added Check For Changed EMail With A Contact With An Active Subscription

						if (Original_Email.Trim() != txt_contact_email_address.Text.Trim())
						{

							if (modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId, false, ref temp_login_name))
							{

								iMsgBox = MessageBox.Show($"The Email Address Has Changed{Environment.NewLine}{Environment.NewLine}This will change the user's Subscription{Environment.NewLine}{Environment.NewLine}Continue?", "Email Change", MessageBoxButtons.YesNo);

								// this will return true if it is frontegg, so false means no front egg, means update
								// If Does_Contact_Have_An_Active_Subscription(nContactID, lSubId, lParentId, True) = False Then
								is_front_egg = modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId, true);
								// means it is not frontegg
								modCommon.UpdateLogin_Fields(nContactID, lSubId, temp_login_name, is_front_egg);
								// End If

								if (iMsgBox == System.Windows.Forms.DialogResult.Yes)
								{
									modAdminCommon.Record_Event("Changed Contact EMail", $"Contact Has Active Subscription - New EMail Address [{txt_contact_email_address.Text.Trim()}]", 0, 0, nCompanyID, false, 0, nContactID);
								}
								else
								{
									Cancel = 1; // Do NOT Save And Do NOT Cancel
								} // If iMsgBox = vbYes Then

							} // If Does_Contact_Have_An_Active_Subscription(nContactID, lSubId) = True Then

						} // If Trim(Original_Email) <> Trim(txt_contact_email_address.Text) Then

						// ************************************************
						// USER HAS DECIDED TO SAVE CHANGES

						if (iMsgBox == System.Windows.Forms.DialogResult.Yes)
						{
							DialogResult tempRefParam = iResponse;
							save_contact(ref tempRefParam);
						}

					} // If iMsgBox = vbYes Then

				} // If verify_contact_change() = True Then
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}

		} // Form_QueryUnload

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{


			string strDelete1 = "DELETE FROM Contact_Lock ";
			strDelete1 = $"{strDelete1}WHERE (contlock_contact_id = {nContactID.ToString()}) ";
			strDelete1 = $"{strDelete1}AND (contlock_journ_id = {nJournID.ToString()}) ";
			strDelete1 = $"{strDelete1}AND (contlock_user_id = '{Convert.ToString(modAdminCommon.snp_User["user_id"])}') ";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = strDelete1;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			// Make Sure This Form Is Closed As Well
			if (frm_ContactRelationships.DefInstance != null)
			{
				frm_ContactRelationships.DefInstance.Close();
			}

			snp_CompanyContact = null;

		} // Form_Unload

		public void save_contact(ref DialogResult inSaveQuestion)
		{
			bool Update_Contact_Error = false;
			bool Insert_Contact_Error = false;


			string Query = "";
			ADORecordSetHelper snp_NextContactid = null; // Recordset aey 7/20/04 convert to ado
			int max_contact_id_a = 0;
			ADORecordSetHelper ado_New_Contact = new ADORecordSetHelper(); // RECORDSET FOR ADDING A NEW CONTACT
			string EmailVerifyMessage = "";
			bool ChangesMadeToExisting = false; //aey 8/16/04
			string str_email_message = "";
			string str_EMail = "";
			string dtToDay = DateTimeHelper.ToString(DateTime.Now);
			bool was_inactivated = false;
			bool was_activated = true;

			string phone_number_to_return = "";
			int number_of_contacts = 0;
			string contact_id_list = "";
			string[] contact_Array = null;
			string[] company_array = null;
			int tmp_comp = 0;
			int tmp_contact = 0;

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);
			string query_update = "";

			string strEMailTo = "";
			string strSubject = "";
			string strEMailBody = "";
			bool bSubscription = false;
			int lSubId = 0;
			int lParentId = 0;
			bool bResults = false;
			string strErrMsg = "";
			string temp_rel = "";
			bool check_replacement = false;
			string temp_subject = "";
			string temp_desc = "";


			bNewContact = false;
			string strEMail = StringsHelper.Replace(StringsHelper.Replace(($"{txt_contact_email_address.Text} ").Trim(), ",", "", 1, -1, CompareMethod.Binary), ";", "", 1, -1, CompareMethod.Binary).Substring(0, Math.Min(150, StringsHelper.Replace(StringsHelper.Replace(($"{txt_contact_email_address.Text} ").Trim(), ",", "", 1, -1, CompareMethod.Binary), ";", "", 1, -1, CompareMethod.Binary).Length));
			string strREMail = StringsHelper.Replace(StringsHelper.Replace(($"{txt_contact_research_email_address.Text} ").Trim(), ",", "", 1, -1, CompareMethod.Binary), ";", "", 1, -1, CompareMethod.Binary).Substring(0, Math.Min(150, StringsHelper.Replace(StringsHelper.Replace(($"{txt_contact_research_email_address.Text} ").Trim(), ",", "", 1, -1, CompareMethod.Binary), ";", "", 1, -1, CompareMethod.Binary).Length));

			txt_contact_email_address.Text = strEMail;
			txt_contact_research_email_address.Text = strREMail;

			string intPress = ((int) System.Windows.Forms.DialogResult.Yes).ToString();
			string company_id_list = "";
			string did_connected_update = "N";

			string temp_sirname = cbo_contact_sirname.Text.Trim();

			if (temp_sirname.Trim().ToLower() == "mr")
			{
				temp_sirname = $"{temp_sirname}.";
			}
			else if (temp_sirname.Trim().ToLower() == "mrs")
			{ 
				temp_sirname = $"{temp_sirname}.";
			}
			else if (temp_sirname.Trim().ToLower() == "ms")
			{ 
				temp_sirname = $"{temp_sirname}.";
			}
			else if (temp_sirname.Trim().ToLower() == "col")
			{ 
				temp_sirname = $"{temp_sirname}.";
			}
			else if (temp_sirname.Trim().ToLower() == "dr")
			{ 
				temp_sirname = $"{temp_sirname}.";
			}
			else if (temp_sirname.Trim().ToLower() == "sgt")
			{ 
				temp_sirname = $"{temp_sirname}.";
			}
			else if (temp_sirname.Trim().ToLower() == "gen")
			{ 
				temp_sirname = $"{temp_sirname}.";
			}

			cbo_contact_sirname.Text = temp_sirname;


			string journ_subject = "";
			string strToday = "";
			string journ_subject3 = "";
			string journ_subject2 = "";
			string Msg = "";
			string temp_description = "";
			try
			{
				if (modAdminCommon.LOCAL_ADO_DB.ConnectionString.IndexOf("jetnet_ra_test") >= 0 && modAdminCommon.gbl_User_ID == "mvit" && modAdminCommon.gbl_User_ID == "DONT GO")
				{ //    so for now it doesnt go in

					if (nContactID == -1)
					{
						run_contact_add_sp_only();
					}
					else
					{
						run_sp_updateContact();
					}

				}
				else
				{


					if (nContactID == -1)
					{

						Insert_Contact_Error = true;
						Update_Contact_Error = false;

						// MAKE SURE THAT WE DO NOT HAVE A DUPLICATE FOR THIS CONTACT
						Query = $"SELECT * FROM Contact WITH(NOLOCK) WHERE contact_comp_id = {nCompanyID.ToString()}";
						Query = $"{Query} AND contact_journ_id = {nJournID.ToString()}";

						if (cbo_contact_sirname.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query} AND contact_sirname = '{modAdminCommon.Fix_Quote(cbo_contact_sirname.Text.Trim())}'";
						}
						else
						{
							Query = $"{Query} AND (isnull(contact_sirname,'')='')";
						}

						if (txt_contact_last_name.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query} AND contact_last_name = '{modAdminCommon.Fix_Quote(txt_contact_last_name.Text.Trim())}'";
						}
						else
						{
							Query = $"{Query} AND (isnull(contact_last_name,'')='')";
						}

						if (txt_contact_first_name.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query} AND contact_first_name = '{modAdminCommon.Fix_Quote(txt_contact_first_name.Text.Trim())}'";
						}
						else
						{
							Query = $"{Query} AND (isnull(contact_first_name,'')='')";
						}

						if (txt_contact_middle_initial.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query} AND contact_middle_initial = '{modAdminCommon.Fix_Quote(txt_contact_middle_initial.Text.Trim())}'";
						}
						else
						{
							Query = $"{Query} AND (isnull(contact_middle_initial,'')='')";
						}

						if (cbo_contact_suffix.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query} AND contact_suffix = '{modAdminCommon.Fix_Quote(cbo_contact_suffix.Text.Trim())}'";
						}
						else
						{
							Query = $"{Query} AND (isnull(contact_suffix,'') ='')";
						}

						if (cbo_contact_title.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query} AND contact_title='{modAdminCommon.Fix_Quote(cbo_contact_title.Text.Trim())}'";
						}
						else
						{
							Query = $"{Query} AND (isnull(contact_title,'')='')";
						}

						if (modAdminCommon.Exist(Query))
						{
							MessageBox.Show($"This Contact Already Exists for This Company. Save Aborted.{Environment.NewLine}There may be a duplicate inactive contact.", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
							Contact_Message_Off();
							return;
						}

						// DISPLAY ERROR MESSAGE IF TITLE, LAST NAME, AND FIRST NAME ARE BLANK
						if (cbo_contact_title.Text.Trim() == modGlobalVars.cEmptyString && txt_contact_first_name.Text.Trim() == modGlobalVars.cEmptyString && txt_contact_last_name.Text.Trim() == modGlobalVars.cEmptyString)
						{
							MessageBox.Show("Contact must have a title AND name. Save Aborted.", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
							Contact_Message_Off();
							return;
						}

						// CHECK THE CONTACT EMAIL ADDRESS
						Contact_Message_On("Checking Contact Email Address ...");
						if (!modCommon.QuickCheckEmailAddress(strEMail))
						{
							MessageBox.Show("Contact EMail Address incorrect format. Save Aborted.", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							Contact_Message_Off();
							return;
						}

						// CHECK THE CONTACT RESEARCH EMAIL ADDRESS
						Contact_Message_On("Checking Contact Research Email Address ...");
						if (!modCommon.QuickCheckEmailAddress(strREMail))
						{
							MessageBox.Show("Contact Research EMail Address incorrect format. Save Aborted.", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							Contact_Message_Off();
							return;
						}

						// GET NEW CONTACT ID NUMBER
						Query = "SELECT max(contact_id) AS max_contact_id FROM Contact WITH(NOLOCK)";
						snp_NextContactid = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_NextContactid.Fields) && !(snp_NextContactid.EOF && snp_NextContactid.BOF))
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_NextContactid["max_contact_id"]))
							{
								max_contact_id_a = Convert.ToInt32(snp_NextContactid["max_contact_id"]) + 1;
								snp_NextContactid.Close();
							}
						}

						snp_NextContactid = null;

						if (max_contact_id_a < 0)
						{
							MessageBox.Show("Contact NewID Incorrect. Save Aborted!", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							Contact_Message_Off();
							return;
						}

						Contact_Message_On("Inserting a NEW Contact ...");

						// BEGIN A TRANSACTION
						modAdminCommon.ADO_Transaction("BeginTrans");

						bNewContact = true;
						ado_New_Contact.Open("SELECT * FROM Contact WHERE contact_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_New_Contact.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						if (ado_New_Contact.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
						{

							ado_New_Contact.AddNew();
							ado_New_Contact["contact_id"] = max_contact_id_a;
							ado_New_Contact["contact_journ_id"] = nJournID;
							ado_New_Contact["contact_comp_id"] = nCompanyID;
							ado_New_Contact["contact_sirname"] = cbo_contact_sirname.Text.Trim();
							ado_New_Contact["contact_last_name"] = txt_contact_last_name.Text.Trim();
							ado_New_Contact["contact_first_name"] = txt_contact_first_name.Text.Trim();
							ado_New_Contact["contact_middle_initial"] = txt_contact_middle_initial.Text.Trim().Substring(0, Math.Min(1, txt_contact_middle_initial.Text.Trim().Length));
							ado_New_Contact["contact_suffix"] = cbo_contact_suffix.Text.Trim();
							ado_New_Contact["contact_title"] = modAdminCommon.Run_Company_Rules(cbo_contact_title.Text.Trim(), "Contact", "Title"); // added MSW - 11/1/22
							ado_New_Contact["contact_email_address"] = strEMail;
							ado_New_Contact["contact_research_email_address"] = strREMail;
							ado_New_Contact["contact_description"] = txt_contact_description.Text.Trim();
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_New_Contact["contact_action_date"] = DBNull.Value;

							if (chk_contact_active_flag.CheckState == CheckState.Checked)
							{
								ado_New_Contact["contact_active_flag"] = "Y";
							}
							else
							{
								ado_New_Contact["contact_active_flag"] = "N";
								str_email_message = $"Contact Inactivated: {txt_contact_last_name.Text}";
							}

							if (chk_HideFromCustomer.CheckState == CheckState.Checked)
							{
								ado_New_Contact["Contact_hide_flag"] = "Y";
							}
							else
							{
								ado_New_Contact["Contact_hide_flag"] = "N";
							}

							// added MSW - 4/16/21-----------------------
							if (chk_iq_auto.CheckState == CheckState.Checked)
							{
								ado_New_Contact["contact_iq_status"] = "Y";
							}
							else
							{
								ado_New_Contact["contact_iq_status"] = "N";
							}

							ado_New_Contact["contact_iq_email_address"] = txt_iq_email.Text.Trim();
							//----------------------------


							// added MSW - 6/23/21-----------------------
							if (chk_contact_do_not_solicit.CheckState == CheckState.Checked)
							{
								ado_New_Contact["contact_do_not_solicit"] = "Y";
							}
							else
							{
								ado_New_Contact["contact_do_not_solicit"] = "N";
							}
							//------------------------------




							if (chk_contact_research_flag.CheckState == CheckState.Checked)
							{
								ado_New_Contact["contact_research_flag"] = "Y";
							}
							else
							{
								ado_New_Contact["contact_research_flag"] = "N";
							}

							if (txt_contact_acpros_seq_no.Text.Trim() == modGlobalVars.cEmptyString)
							{
								ado_New_Contact["contact_acpros_seq_no"] = 0;
							}
							else
							{
								if (Convert.ToInt32(Conversion.Val(txt_contact_acpros_seq_no.Text.Trim())) > 0 && Convert.ToInt32(Conversion.Val(txt_contact_acpros_seq_no.Text.Trim())) < 300)
								{
									ado_New_Contact["contact_acpros_seq_no"] = Convert.ToInt32(Conversion.Val(txt_contact_acpros_seq_no.Text.Trim()));
								}
								else
								{
									ado_New_Contact["contact_acpros_seq_no"] = 0;
								}
							}

							ado_New_Contact["contact_name_confirm_date"] = DateTime.Parse(dtToDay).ToString("d");
							ado_New_Contact["contact_title_confirm_date"] = DateTime.Parse(dtToDay).ToString("d");
							ado_New_Contact["contact_email_confirm_date"] = DateTime.Parse(dtToDay).ToString("d");
							ado_New_Contact["contact_phone_confirm_date"] = DateTime.Parse(dtToDay).ToString("d");

							// 05/25/2018 - By David D. Cruger; Added
							ado_New_Contact["contact_user_id"] = modAdminCommon.gbl_User_ID;

							// PERFORM THE UPDATE
							ado_New_Contact.Update();

							modCommon.Start_Activity_Monitor_Message("Contact Added", ref strMsg, ref dtStartDate, ref dtEndDate);
							strMsg = $" - {txt_contact_first_name.Text} {txt_contact_last_name.Text}";
							modCommon.End_Activity_Monitor_Message("Contact Added", ref strMsg, dtStartDate, ref dtEndDate, 0, nJournID, nCompanyID, 0, max_contact_id_a);

							if (strEMail != "")
							{
								modCommon.Start_Activity_Monitor_Message("Contact EMail Added", ref strMsg, ref dtStartDate, ref dtEndDate);
								strMsg = $" - {strEMail}";

								// hidden companies, or hidden contacts, shouldnt create priority events
								if (chk_hidden_comp.CheckState == CheckState.Unchecked && chk_HideFromCustomer.CheckState == CheckState.Unchecked)
								{
									// added MSW - 8/26/21 -------------
									modCommon.InsertPriorityEvent("CEAA", 0, 0, txt_contact_email_address.Text.Trim(), nCompanyID, nContactID, "N");
								}

								modCommon.End_Activity_Monitor_Message("Contact EMail Added", ref strMsg, dtStartDate, ref dtEndDate, 0, nJournID, nCompanyID, 0, max_contact_id_a);
							}

							if (strREMail != "")
							{
								modCommon.Start_Activity_Monitor_Message("Contact Research EMail Added", ref strMsg, ref dtStartDate, ref dtEndDate);
								strMsg = $" - {strEMail}";
								modCommon.End_Activity_Monitor_Message("Contact Research EMail Added", ref strMsg, dtStartDate, ref dtEndDate, 0, nJournID, nCompanyID, 0, max_contact_id_a);
							}

							modAdminCommon.ADO_Transaction("CommitTrans");


							journ_subject = $"Contact Created: {txt_contact_first_name.Text.Trim()} {txt_contact_last_name.Text.Trim()}";
							strToday = DateTime.Now.ToString("d");


							modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(strToday.Trim());
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
							modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";
							modAdminCommon.Rec_Journal_Info.journ_subject = journ_subject;
							modAdminCommon.Rec_Journal_Info.journ_description = "";
							modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
							modAdminCommon.Rec_Journal_Info.journ_contact_id = max_contact_id_a;

							modAdminCommon.Rec_Journal_Info.journ_account_id = ""; // Trim$(cbo_comp_account(COMP_ACCOUNT_REP).Text)
							modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_status = "A";

							frm_Journal.DefInstance.Commit_Journal_Entry();
							//---------------------------------------------------



						}
						else
						{
							modAdminCommon.ADO_Transaction("RollbackTrans");
						} // ado supports add new contact

						grd_Contact_Phone_Numbers.Enabled = false;
						cmd_add_contact_phone.Enabled = false;
						cmd_confirm_contact_Phone.Enabled = false;
						cmd_delete_contact_Phone.Enabled = false;

						txt_contact_id.Text = max_contact_id_a.ToString();
						nContactID = max_contact_id_a;

						MessageBox.Show($"Add New Company Contact Successfully Completed.{Environment.NewLine} Please Enter Phone Numbers if they are available!", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);

						if (Add_Office_Number)
						{
							cmd_add_Contact_phone_Click(cmd_add_contact_phone, new EventArgs());
							Application.DoEvents();
							Application.DoEvents();
							JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(10);
							cbo_pnum_type.Text = "Office";
							txt_pnum_cntry_code.Text = country_code;
							txt_pnum_area_code.Text = area_code;
							txt_pnum_prefix.Text = prefix_code;
							txt_pnum_number.Text = number_code;

							MessageBox.Show("Add New Company Office Number to Contact, Please Hit Add.", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}

						// added MSW - 9/24/2021
						if (Convert.ToString(cbo_contact_title.Tag).Trim() == "" && cbo_contact_title.Text.Trim() != "")
						{
							temp_subject = "Contact Title Added";
							temp_desc = $"{Convert.ToString(cbo_contact_title.Tag).Trim()}";

							if (chk_hidden_comp.CheckState == CheckState.Unchecked && chk_HideFromCustomer.CheckState == CheckState.Unchecked)
							{
								modCommon.InsertPriorityEvent("CTA", 0, 0, $"{cbo_contact_title.Text.Trim()} {temp_desc}", nCompanyID, nContactID, "N");
							}
						}


					}
					else
					{
						// save pre-existing contact

						// USED TO SAVE CHANGES TO AN EXISTING CONTACT
						Update_Contact_Error = true;
						Insert_Contact_Error = false;

						ChangesMadeToExisting = false;

						// MAKE SURE THAT WE DO NOT HAVE A DUPLICATE FOR THIS CONTACT
						Query = $"SELECT * FROM Contact WITH(NOLOCK) WHERE contact_comp_id = {nCompanyID.ToString()}";
						Query = $"{Query} AND contact_journ_id = {nJournID.ToString()}";
						Query = $"{Query} AND contact_id <> {nContactID.ToString()}";

						if (cbo_contact_sirname.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query} AND contact_sirname = '{modAdminCommon.Fix_Quote(cbo_contact_sirname.Text.Trim())}'";
						}
						else
						{
							Query = $"{Query} AND (isnull(contact_sirname,'')='')";
						}

						if (txt_contact_last_name.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query} AND contact_last_name='{modAdminCommon.Fix_Quote(txt_contact_last_name.Text.Trim())}'";
						}
						else
						{
							Query = $"{Query} AND (isnull(contact_last_name,'')='') ";
						}

						if (txt_contact_first_name.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query} AND contact_first_name='{modAdminCommon.Fix_Quote(txt_contact_first_name.Text.Trim())}'";
						}
						else
						{
							Query = $"{Query} AND (isnull(contact_first_name,'')='') ";
						}

						if (txt_contact_middle_initial.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query} AND contact_middle_initial='{modAdminCommon.Fix_Quote(txt_contact_middle_initial.Text.Trim())}'";
						}
						else
						{
							Query = $"{Query} AND (isnull(contact_middle_initial,'')='') ";
						}

						if (cbo_contact_suffix.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query} AND contact_suffix='{modAdminCommon.Fix_Quote(cbo_contact_suffix.Text.Trim())}'";
						}
						else
						{
							Query = $"{Query} AND (isnull(contact_suffix,'') ='') ";
						}

						if (cbo_contact_title.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query} AND contact_title='{modAdminCommon.Fix_Quote(cbo_contact_title.Text.Trim())}'";
						}
						else
						{
							Query = $"{Query} AND (isnull(contact_title,'')='') ";
						}

						if (chk_contact_active_flag.CheckState == CheckState.Checked)
						{
							if (modAdminCommon.Exist(Query))
							{
								MessageBox.Show($"This Contact Already Exists for This Company. Update Aborted.{Environment.NewLine}There may be a duplicate inactive contact.", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
								Contact_Message_Off();
								return;
							}
						}

						if (!modCommon.QuickCheckEmailAddress(txt_contact_email_address.Text.Trim()))
						{
							MessageBox.Show("Contact EMail Address incorrect format. Update Aborted.", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							Contact_Message_Off();
							return;
						}

						if (!modCommon.QuickCheckEmailAddress(txt_contact_research_email_address.Text.Trim()))
						{
							MessageBox.Show("Contact Research EMail Address incorrect format. Update Aborted.", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							Contact_Message_Off();
							return;
						}

						if (cbo_contact_title.Text.Trim() == modGlobalVars.cEmptyString && txt_contact_first_name.Text.Trim() == modGlobalVars.cEmptyString && txt_contact_last_name.Text.Trim() == modGlobalVars.cEmptyString)
						{
							MessageBox.Show("Contact must have a title AND name. Update Aborted.", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
							Contact_Message_Off();
							return;
						}

						if (verify_contact_change())
						{

							ChangesMadeToExisting = true;

							// ADDED 3/19/12 - MSW - To make them not be able to inactivate a contact with a subscription
							if ((chk_contact_active_flag.CheckState == CheckState.Unchecked) && (chk_contact_active_flag.CheckState != temp_contact_active_flag))
							{

								if (modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId))
								{
									MessageBox.Show($"This Contact Has a Subscription Related To It. Save Aborted.{Environment.NewLine}", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
									Contact_Message_Off();
									return;
								}

							} // If (chk_contact_active_flag.Value = vbUnchecked) And (chk_contact_active_flag.Value <> temp_contact_active_flag) Then

							if (inSaveQuestion == System.Windows.Forms.DialogResult.Yes)
							{
								intPress = ((int) inSaveQuestion).ToString();
							}
							else
							{
								intPress = ((int) MessageBox.Show("Do You Want to Save Contact Changes?", "Company Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question)).ToString();
							}

							if (intPress == ((int) System.Windows.Forms.DialogResult.Yes).ToString())
							{

								Contact_Message_On("Updating Contact ...");

								if ((chk_contact_active_flag.CheckState == CheckState.Unchecked) && (chk_contact_active_flag.CheckState != temp_contact_active_flag))
								{
									was_inactivated = true;
								}

								if ((chk_contact_active_flag.CheckState == CheckState.Checked) && (chk_contact_active_flag.CheckState != temp_contact_active_flag))
								{
									was_activated = true;
								}


								check_replacement = false;
								if (cbo_replacement_contact.Visible && was_inactivated)
								{
									if (cbo_replacement_contact.Text.Trim() != "No Contact Replacement Selected")
									{
										if (cbo_replacement_contact.GetItemData(cbo_replacement_contact.SelectedIndex) == 0)
										{
											cbo_replacement_contact.SelectedIndex = 1;
											if (MessageBox.Show("Do You Have a Replacement Contact For This Contact?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
											{
												re_load_contact = false;
												return;
											}
											else
											{
											}
										}
									}
								}


								update_contact(nContactID);



								// added MSW - 9/24/21
								if (($"{Convert.ToString(cbo_contact_title.Tag)} ").Trim() != cbo_contact_title.Text.Trim())
								{
									temp_subject = "Contact Title Updated";
									temp_desc = $"Was previously: {Convert.ToString(cbo_contact_title.Tag).Trim()}{Environment.NewLine}";

									if (chk_hidden_comp.CheckState == CheckState.Unchecked && chk_HideFromCustomer.CheckState == CheckState.Unchecked)
									{
										modCommon.InsertPriorityEvent("CTU", 0, 0, $"{cbo_contact_title.Text.Trim()} {temp_desc}", nCompanyID, nContactID, "N");
									}
								}




								// added in msw - 4/23/21
								if (Convert.ToString(txt_contact_email_address.Tag) != txt_contact_email_address.Text)
								{


									temp_subject = "";
									temp_desc = "";


									if (txt_contact_email_address.Text.Trim() == "" && Convert.ToString(txt_contact_email_address.Tag).Trim() != "")
									{
										temp_subject = "Contact Email Address Removed";
										temp_desc = $"Was previously: {Convert.ToString(txt_contact_email_address.Tag).Trim()}";
									}
									else if (Convert.ToString(txt_contact_email_address.Tag).Trim() == "" && txt_contact_email_address.Text.Trim() != "")
									{ 
										temp_subject = "Contact Email Address Entered";
										temp_desc = txt_contact_email_address.Text.Trim();
										modCommon.InsertPriorityEvent("CEAA", 0, 0, temp_desc, nCompanyID, nContactID, "N");

									}
									else if (Convert.ToString(txt_contact_email_address.Tag).Trim() != txt_contact_email_address.Text.Trim())
									{ 
										temp_subject = "Contact Email Address Updated";
										temp_desc = $"Was previously: {Convert.ToString(txt_contact_email_address.Tag).Trim()}";

										modCommon.InsertPriorityEvent("CEAU", 0, 0, $"{txt_contact_email_address.Text.Trim()} {temp_desc}", nCompanyID, nContactID, "N");
									}

									temp_subject = $"{temp_subject}: {txt_contact_first_name.Text.Trim()} {txt_contact_last_name.Text.Trim()}";

									modAdminCommon.Rec_Journal_Info.journ_subject = temp_subject;
									modAdminCommon.Rec_Journal_Info.journ_description = temp_desc;
									modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
									modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
									modAdminCommon.Rec_Journal_Info.journ_contact_id = nContactID;
									modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
									modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";
									modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";
									frm_Journal.DefInstance.Commit_Journal_Entry();

								}



								//then we unchecked the box - MSW - 4/28/19
								if (Convert.ToString(chkContactDoNotSendJNiQSurvey.Tag) == "1" && ((int) chkContactDoNotSendJNiQSurvey.CheckState).ToString() == "0")
								{

									str_email_message = $"Removed Contact From The Do Not Send JNiQ Survey List - Contact - done by {modAdminCommon.gbl_User_ID}";

									Application.DoEvents();
									modAdminCommon.Rec_Journal_Info.journ_subject = str_email_message;
									modAdminCommon.Rec_Journal_Info.journ_description = $"Removed Contact From The Do Not Send JNiQ Survey List - Contact - done by {modAdminCommon.gbl_User_ID}";
									modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(dtToDay);
									modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
									modAdminCommon.Rec_Journal_Info.journ_contact_id = nContactID;
									modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
									modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";
									modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

									frm_Journal.DefInstance.Commit_Journal_Entry();
								}
								else if ((Convert.ToString(chkContactDoNotSendJNiQSurvey.Tag) == "" && ((int) chkContactDoNotSendJNiQSurvey.CheckState).ToString() == "1") || (Convert.ToString(chkContactDoNotSendJNiQSurvey.Tag) == "0" && ((int) chkContactDoNotSendJNiQSurvey.CheckState).ToString() == "1"))
								{  // then we checked it

									str_email_message = $"Added Contact To The Do Not Send JNiQ Survey List - Contact - done by {modAdminCommon.gbl_User_ID}";

									Application.DoEvents();
									modAdminCommon.Rec_Journal_Info.journ_subject = str_email_message;
									modAdminCommon.Rec_Journal_Info.journ_description = $"Added Contact To The Do Not Send JNiQ Survey List - Contact - done by {modAdminCommon.gbl_User_ID}";
									modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(dtToDay);
									modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
									modAdminCommon.Rec_Journal_Info.journ_contact_id = nContactID;
									modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
									modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";
									modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

									frm_Journal.DefInstance.Commit_Journal_Entry();
								}


								number_of_contacts = 0;
								phone_number_to_return = "";
								// ADDED MSW - 7/27/16 - if it was inactivated, or activated, then ask/check for other contacts
								if ((RememberWhatChanged.IndexOf("Active Flag") >= 0 && was_inactivated) || (RememberWhatChanged.IndexOf("Research EMail") >= 0))
								{
									if (company_contact_has_related)
									{
										Application.DoEvents();
										contact_id_list = "";
										contact_id_list = modCompany.Confirm_Matching_Contacts(Convert.ToInt32(Double.Parse(nContactID.ToString())), ref number_of_contacts, "", ref company_id_list, nCompanyID);
										if (contact_id_list.Trim() != "")
										{


											// MSW - 5/3/19 - ADDED PER TASK --
											if (RememberWhatChanged.IndexOf("Research EMail") >= 0)
											{
												if (MessageBox.Show($"This Contact Has {number_of_contacts.ToString()} Other Contact(s) Connected To It. Would you like to also Change the Research Emails of these Contacts if they are blank or matching?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
												{
													query_update = $" Update Contact set contact_research_email_address = '{($"{txt_contact_research_email_address.Text} ").Trim().Substring(0, Math.Min(150, ($"{txt_contact_research_email_address.Text} ").Trim().Length))}'  ";
													query_update = $"{query_update}, contact_action_date = NULL "; // done MSW - 2/16/22
													query_update = $"{query_update} WHERE contact_id in ({contact_id_list}) and contact_journ_id = 0 ";
													query_update = $"{query_update} and (contact_research_email_address = '' or contact_research_email_address is null or contact_research_email_address = '{Convert.ToString(txt_contact_research_email_address.Tag)}') ";
													query_update = query_update;
													modAdminCommon.ADO_Transaction("BeginTrans");
													DbCommand TempCommand = null;
													TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
													TempCommand.CommandText = query_update;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
													TempCommand.ExecuteNonQuery();
													modAdminCommon.ADO_Transaction("CommitTrans");
												}
											}



											if (RememberWhatChanged.IndexOf("Active Flag") >= 0 && was_inactivated)
											{
												if (MessageBox.Show($"This Contact Has {number_of_contacts.ToString()} Other Contact(s) Connected To It Without Any Having Subscriptions. Would you like to also Inactivate All Related Contact(s)?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
												{
													query_update = " Update Contact set contact_active_flag = 'N'   ";
													query_update = $"{query_update}, contact_action_date = NULL "; // done MSW - 2/16/22
													query_update = $"{query_update} WHERE contact_id in ({contact_id_list}) and contact_journ_id = 0 ";
													query_update = query_update;
													modAdminCommon.ADO_Transaction("BeginTrans");
													DbCommand TempCommand_2 = null;
													TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
													TempCommand_2.CommandText = query_update;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
													TempCommand_2.ExecuteNonQuery();
													modAdminCommon.ADO_Transaction("CommitTrans");


													did_connected_update = "Y";
													query_update = "";

													temp_rel = Confirm_AC_Relationships(contact_id_list);
													if (temp_rel.Trim() != "")
													{
														MessageBox.Show($"This Contact, Through the Match Tool, Is Connected To Aircraft In the Following Companies ({temp_rel}). These Must Be Manually Disconnected and Adjusted.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
													}

													Application.DoEvents();

												}
											}




										}
									}
								}
								else if (RememberWhatChanged.IndexOf("Active Flag") >= 0 && was_activated)
								{ 
									// not currently doing

								}
								else if (RememberWhatChanged.IndexOf("EMail") >= 0)
								{ 

									contact_id_list = modCompany.Confirm_Matching_Contacts(Convert.ToInt32(Double.Parse(nContactID.ToString())), ref number_of_contacts, "", ref company_id_list, nCompanyID, false, Convert.ToString(txt_contact_email_address.Tag), txt_contact_email_address.Text);
									if (contact_id_list.Trim() != "")
									{
										if (MessageBox.Show($"This Contact Has {number_of_contacts.ToString()} Other Contact(s) Connected To It, With The Same Email And Without Any Having Subscriptions. Would you like to Change the Email On All Related Contact(s)?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
										{
											query_update = $" Update Contact set contact_email_address = '{txt_contact_email_address.Text}'   ";
											query_update = $"{query_update}, contact_action_date = NULL "; // done MSW - 2/16/22
											query_update = $"{query_update} WHERE contact_id in ({contact_id_list}) and contact_journ_id = 0 ";
											query_update = $"{query_update} and contact_email_address = '{Convert.ToString(txt_contact_email_address.Tag)}'   ";
											query_update = query_update;
											modAdminCommon.ADO_Transaction("BeginTrans");
											DbCommand TempCommand_3 = null;
											TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
											UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
											TempCommand_3.CommandText = query_update;
											//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
											TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
											UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
											TempCommand_3.ExecuteNonQuery();
											modAdminCommon.ADO_Transaction("CommitTrans");

											did_connected_update = "Y";
											query_update = "";

											//added MSW
											contact_Array = contact_id_list.Split(',');
											company_array = company_id_list.Split(',');


											int tempForEndVar = number_of_contacts - 1;
											for (int i = 0; i <= tempForEndVar; i++)
											{

												tmp_comp = Convert.ToInt32(Double.Parse(StringsHelper.Replace(company_array[i], "'", "", 1, -1, CompareMethod.Binary)));
												tmp_contact = Convert.ToInt32(Double.Parse(StringsHelper.Replace(contact_Array[i], "'", "", 1, -1, CompareMethod.Binary)));

												str_email_message = $"Email Changed From Matched Contact from {Convert.ToString(txt_contact_email_address.Tag)} to {txt_contact_email_address.Text}";
												Application.DoEvents();
												modAdminCommon.Rec_Journal_Info.journ_subject = str_email_message;
												modAdminCommon.Rec_Journal_Info.journ_description = $"Email Change - done by {modAdminCommon.gbl_User_ID}";
												modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
												modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
												modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(dtToDay);
												modAdminCommon.Rec_Journal_Info.journ_comp_id = tmp_comp;
												modAdminCommon.Rec_Journal_Info.journ_contact_id = tmp_contact;
												modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
												modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
												modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
												modAdminCommon.Rec_Journal_Info.journ_status = "A";
												modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

												frm_Journal.DefInstance.Commit_Journal_Entry();
												Application.DoEvents();
											}



											str_email_message = $"Email Changed from {Convert.ToString(txt_contact_email_address.Tag)} to {txt_contact_email_address.Text}";
											Application.DoEvents();
											modAdminCommon.Rec_Journal_Info.journ_subject = str_email_message;
											modAdminCommon.Rec_Journal_Info.journ_description = $"Email Change - done by {modAdminCommon.gbl_User_ID}";
											modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
											modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
											modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(dtToDay);
											modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
											modAdminCommon.Rec_Journal_Info.journ_contact_id = nContactID;
											modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
											modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
											modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
											modAdminCommon.Rec_Journal_Info.journ_status = "A";
											modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

											frm_Journal.DefInstance.Commit_Journal_Entry();

										}
									}


								} // If InStr(RememberWhatChanged, "Active Flag") > 0 And was_inactivated = True Then

								// added MSW - 4/21/21
								if (RememberWhatChanged.IndexOf("IQ Auto Added") >= 0)
								{
									journ_subject3 = $"Contact: {txt_contact_first_name.Text.Trim()} {txt_contact_last_name.Text.Trim()} ";

									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(dtToDay);
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
									modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";
									modAdminCommon.Rec_Journal_Info.journ_subject = journ_subject3;
									modAdminCommon.Rec_Journal_Info.journ_description = "-- (IQ Automated)";
									modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
									modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
									modAdminCommon.Rec_Journal_Info.journ_contact_id = nContactID;

									modAdminCommon.Rec_Journal_Info.journ_account_id = ""; // Trim$(cbo_comp_account(COMP_ACCOUNT_REP).Text)
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";

									frm_Journal.DefInstance.Commit_Journal_Entry();
								}
								else if (RememberWhatChanged.IndexOf("IQ Auto Removed") >= 0)
								{ 
									journ_subject2 = $"Contact: {txt_contact_first_name.Text.Trim()} {txt_contact_last_name.Text.Trim()} ";

									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(dtToDay);
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
									modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";
									modAdminCommon.Rec_Journal_Info.journ_subject = journ_subject2;
									modAdminCommon.Rec_Journal_Info.journ_description = "-- (Removed From iQ Automated List)";
									modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
									modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
									modAdminCommon.Rec_Journal_Info.journ_contact_id = nContactID;

									modAdminCommon.Rec_Journal_Info.journ_account_id = ""; // Trim$(cbo_comp_account(COMP_ACCOUNT_REP).Text)
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";

									frm_Journal.DefInstance.Commit_Journal_Entry();
								}

								// as long as after u try to do the update and its still checked, then put in the inactivate item
								if (was_inactivated && chk_contact_active_flag.CheckState == CheckState.Unchecked)
								{

									Msg = $"Would you like to add anything extra to the Description of the Journal note for all of these contact records?{Environment.NewLine}";
									Msg = $"{Msg}If so, please type and hit enter, if not, then hit cancel.";

									temp_description = InputBoxHelper.InputBox(Msg, "Description");

									str_email_message = ($"Contact Inactivated: {cbo_contact_sirname.Text.Trim()} {modAdminCommon.Fix_Quote(txt_contact_first_name.Text).Trim()}{((txt_contact_middle_initial.Text.Trim() != modGlobalVars.cEmptyString) ? $"{txt_contact_middle_initial.Text.Trim()}." : modGlobalVars.cEmptyString)}{modAdminCommon.Fix_Quote(txt_contact_last_name.Text).Trim()} {cbo_contact_suffix.Text.Trim()}").Trim();
									Application.DoEvents();
									modAdminCommon.Rec_Journal_Info.journ_subject = str_email_message;
									modAdminCommon.Rec_Journal_Info.journ_description = $"Inactivated Contact - done by {modAdminCommon.gbl_User_ID}";
									if (temp_description.Trim() != "")
									{
										modAdminCommon.Rec_Journal_Info.journ_description = $"{modAdminCommon.Rec_Journal_Info.journ_description}, {temp_description}";
									}
									modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(dtToDay);
									modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
									modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
									modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
									modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";
									modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

									frm_Journal.DefInstance.Commit_Journal_Entry();
									Application.DoEvents();

									if (number_of_contacts > 0 && did_connected_update == "Y")
									{
										contact_Array = contact_id_list.Split(',');
										company_array = company_id_list.Split(',');

										int tempForEndVar2 = number_of_contacts - 1;
										for (int i = 0; i <= tempForEndVar2; i++)
										{

											tmp_comp = Convert.ToInt32(Double.Parse(StringsHelper.Replace(company_array[i], "'", "", 1, -1, CompareMethod.Binary)));

											str_email_message = ($"Contact Inactivated: {cbo_contact_sirname.Text.Trim()} {modAdminCommon.Fix_Quote(txt_contact_first_name.Text).Trim()}{((txt_contact_middle_initial.Text.Trim() != modGlobalVars.cEmptyString) ? $"{txt_contact_middle_initial.Text.Trim()}." : modGlobalVars.cEmptyString)}{modAdminCommon.Fix_Quote(txt_contact_last_name.Text).Trim()} {cbo_contact_suffix.Text.Trim()}").Trim();
											Application.DoEvents();
											modAdminCommon.Rec_Journal_Info.journ_subject = str_email_message;
											modAdminCommon.Rec_Journal_Info.journ_description = $"Inactivated Contact - done by {modAdminCommon.gbl_User_ID}";
											if (temp_description.Trim() != "")
											{
												modAdminCommon.Rec_Journal_Info.journ_description = $"{modAdminCommon.Rec_Journal_Info.journ_description}, {temp_description}";
											}
											modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
											modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
											modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(dtToDay);
											modAdminCommon.Rec_Journal_Info.journ_comp_id = tmp_comp;
											modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
											modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
											modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
											modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
											modAdminCommon.Rec_Journal_Info.journ_status = "A";
											modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

											frm_Journal.DefInstance.Commit_Journal_Entry();
											Application.DoEvents();
										}
									}
								}
								else if (was_activated && chk_contact_active_flag.CheckState == CheckState.Checked && RememberWhatChanged.IndexOf("Active Flag") >= 0)
								{ 
									str_email_message = ($"Contact Activated: {cbo_contact_sirname.Text.Trim()} {modAdminCommon.Fix_Quote(txt_contact_first_name.Text).Trim()}{((txt_contact_middle_initial.Text.Trim() != modGlobalVars.cEmptyString) ? $"{txt_contact_middle_initial.Text.Trim()}." : modGlobalVars.cEmptyString)}{modAdminCommon.Fix_Quote(txt_contact_last_name.Text).Trim()} {cbo_contact_suffix.Text.Trim()}").Trim();
									Application.DoEvents();
									modAdminCommon.Rec_Journal_Info.journ_subject = str_email_message;
									modAdminCommon.Rec_Journal_Info.journ_description = $"Activated Contact - done by {modAdminCommon.gbl_User_ID}";
									modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(dtToDay);
									modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
									modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
									modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
									modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";
									modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";
									frm_Journal.DefInstance.Commit_Journal_Entry();
									Application.DoEvents();
								}

								select_contact();

								bSubscription = modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId);

								if ((bSubscription || JetnetService_Used.Trim().ToUpper() == "J") && str_email_message.Trim() != modGlobalVars.cEmptyString && nJournID == 0)
								{

									strEMailTo = modCommon.DLookUp("aconfig_email_company_contact_chg", "Application_Configuration WITH(NOLOCK)").Trim();

									strSubject = $"Homebase Contact Inactivated for {CompanyName_Renamed} [{nCompanyID.ToString()}] ";
									strEMailBody = str_email_message;

									// Temp Hold - May Not Need To Do This With Customer Program Messages
									bResults = modEmail.Simple_Insert_EMail_Queue_Record(strEMailTo, "", "", strSubject, strEMailBody, "", "Y", "Open", "Homebase Contact Change", "jetnet@jetnet.com", nCompanyID, nContactID);

									if (bResults)
									{
										modEmail.Send_All_EMail_In_Queue(ref strErrMsg, nCompanyID);
									}

									modCommon.Enter_Customer_Program_Message_Note("", strEMailTo, $"Contact Changed{Environment.NewLine}{strSubject}{Environment.NewLine}{strEMailBody}", lSubId, lParentId, nCompanyID, nContactID);

								} // If (bSubscription = True Or UCase$(Trim$(JetnetService_Used)) = "J") And Trim$(str_email_message) <> cEmptyString And nJournID = 0 Then

							} // If was_inactivated = True And chk_contact_active_flag.Value = vbUnchecked Then

						}
						else
						{
							lbl_contact_update_date.Text = "No Changes Made to Save";
						} // If intPress = vbYes Then

						modCommon.Start_Activity_Monitor_Message("Contact Saved", ref strMsg, ref dtStartDate, ref dtEndDate);
						strMsg = $" - {txt_contact_first_name.Text} {txt_contact_last_name.Text} {lbl_contact_update_date.Text}";
						modCommon.End_Activity_Monitor_Message("Contact Saved", ref strMsg, dtStartDate, ref dtEndDate, 0, nJournID, nCompanyID, 0, nContactID);

					} // If nContactID = -1 Then

				}





				if (strEMail != "")
				{
					if (nJournID == 0)
					{
						if (intPress == ((int) System.Windows.Forms.DialogResult.Yes).ToString())
						{
							AddRemoveContactEMailFromDoNotSendTable();
						}
					}
				}

				Contact_Message_Off();

				inSaveQuestion = System.Windows.Forms.DialogResult.No;
				RememberWhatChanged = "";
				lblChanges.Visible = false;
			}
			catch (Exception excep)
			{
				if (!Update_Contact_Error && !Insert_Contact_Error)
				{
					throw excep;
				}

				if (Insert_Contact_Error)
				{


					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					modAdminCommon.Report_Error($"Insert_Contact_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(SAVE)");
					modAdminCommon.ADO_Transaction("RollbackTrans");
					Contact_Message_Off();
					return;

				}
				if (Update_Contact_Error || Insert_Contact_Error)
				{


					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					modAdminCommon.Report_Error($"Update_Contact_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(SAVE)");
					modAdminCommon.ADO_Transaction("RollbackTrans");
					Contact_Message_Off();

				}
			}

		}

		public void save_contact() { var value = System.Windows.Forms.DialogResult.No; save_contact(ref value); }


		public void run_contact_add_sp_only()
		{

			int in_CompanyID = 0;
			string IQuery = "";
			string temp_Comp_name = "";
			string Current_Account_Type = "";
			string tupdate = "";

			tupdate = " exec sp_AddContact ";

			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inCompID", nCompanyID.ToString())}";
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inSurname", modAdminCommon.Fix_Quote(cbo_contact_sirname.Text).Trim())}";
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inFirstName", modAdminCommon.Fix_Quote(txt_contact_first_name.Text).Trim())}";
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inMiddleInitial", modAdminCommon.Fix_Quote(txt_contact_middle_initial.Text).Trim())}";
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inLastName", modAdminCommon.Fix_Quote(txt_contact_last_name.Text).Trim())}";
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inSuffix", modAdminCommon.Fix_Quote(cbo_contact_suffix.Text).Trim())}";

			if (cbo_contact_title.Text.Trim() != modGlobalVars.cEmptyString)
			{
				tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inTitle", modAdminCommon.Fix_Quote(cbo_contact_title.Text).Trim())}";
			}
			else
			{
				tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inTitle", "")}";
			}

			if (txt_contact_email_address.Text != modGlobalVars.cEmptyString)
			{
				tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inEmailAddress", modAdminCommon.Fix_Quote(txt_contact_email_address.Text).Trim())}";
			}
			else
			{
				tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inEmailAddress", "")}";
			}

			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inUserID", modAdminCommon.gbl_User_ID)}";

			if (chk_contact_active_flag.CheckState == CheckState.Checked)
			{ // contact_hide_flag
				tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inHideFlag", "Y")}";
			}
			else
			{
				tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inHideFlag", "N")}";
			}


			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inDescription", "")}";
			// leave this one for last, so it goes in without a comma
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inSource", "HB")}";
			tupdate = tupdate;
			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = tupdate;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();


		}


		public void run_sp_updateContact()
		{

			int in_CompanyID = 0;
			string IQuery = "";
			string temp_Comp_name = "";
			string Current_Account_Type = "";

			string tupdate = " exec sp_updateContact ";

			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inContactID", nContactID.ToString())}";
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inCompID", nCompanyID.ToString())}";
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inSurname", modAdminCommon.Fix_Quote(cbo_contact_sirname.Text).Trim())}";
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inFirstName", modAdminCommon.Fix_Quote(txt_contact_first_name.Text).Trim())}";
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inMiddleInitial", modAdminCommon.Fix_Quote(txt_contact_middle_initial.Text).Trim())}";
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inLastName", modAdminCommon.Fix_Quote(txt_contact_last_name.Text).Trim())}";
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inSuffix", modAdminCommon.Fix_Quote(cbo_contact_suffix.Text).Trim())}";


			if (cbo_contact_title.Text.Trim() != modGlobalVars.cEmptyString)
			{
				tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inTitle", modAdminCommon.Fix_Quote(cbo_contact_title.Text).Trim())}";
			}
			else
			{
				tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inTitle", "")}";
			}

			if (txt_contact_email_address.Text != modGlobalVars.cEmptyString)
			{
				tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inEmailAddress", modAdminCommon.Fix_Quote(txt_contact_email_address.Text).Trim())}";
			}
			else
			{
				tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inEmailAddress", "")}";
			}

			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inUserID", modAdminCommon.gbl_User_ID)}";

			if (chk_contact_active_flag.CheckState == CheckState.Checked)
			{
				tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inHideFlag", "Y")}";
			}
			else
			{
				tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inHideFlag", "N")}";
			}

			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inDescription", "")}";
			tupdate = $"{tupdate}{modCommon.build_common_sp_string("@inSource", "HB")}";

			tupdate = tupdate;
			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = tupdate;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();





		}



		public void update_contact(int inContactId)
		{

			string Query = "";
			ADORecordSetHelper ado_UpdateContact = new ADORecordSetHelper();
			bool ACRelated = false;
			bool CompRelated = false;
			string Msg = "";
			string strEMail = "";
			string strREMail = "";

			string strWhatChged = "";
			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);
			bool bEMailAdded = false;
			bool bResearchEMailAdded = false;
			bool bEMailDeleted = false;
			bool bResearchEMailDeleted = false;
			bool bSubscription = false;
			int lSubId = 0;
			int lParentId = 0;
			string strEMailTo = "";
			string strSubject = "";
			string strEMailBody = "";
			bool bResults = false;
			string strErrMsg = "";
			int temp_replacement_contact_id = 0;

			try
			{

				if (nContactID > 0)
				{

					ACRelated = false;
					CompRelated = false;
					bEMailAdded = false;
					bResearchEMailAdded = false;
					bEMailDeleted = false;
					bResearchEMailDeleted = false;
					bSubscription = false;

					if (snp_CompanyContact.State == ConnectionState.Open && inContactId > 0)
					{

						if (chk_contact_active_flag.CheckState == CheckState.Unchecked && Convert.ToString(snp_CompanyContact["contact_active_flag"]).Trim().ToUpper() == "Y")
						{

							Query = $"SELECT compref_key FROM Company_Reference WITH(NOLOCK) WHERE compref_journ_id = {nJournID.ToString()}";
							Query = $"{Query} AND (compref_contact_id = {nContactID.ToString()} OR compref_rel_contact_id = {nContactID.ToString()})";

							if (modAdminCommon.Exist(Query))
							{
								CompRelated = true;
							}

							Query = $"SELECT cref_ac_id FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_contact_id = {nContactID.ToString()}";
							Query = $"{Query} AND cref_journ_id = {nJournID.ToString()}";

							if (modAdminCommon.Exist(Query))
							{
								ACRelated = true;
							}

							if (CompRelated || ACRelated)
							{

								if (ACRelated)
								{
									Msg = $"This specific contact is connected to at least 1 aircraft.{Environment.NewLine}{Environment.NewLine}";
									if (CompRelated)
									{
										Msg = $"{Msg}This specific contact is attached to at least 1 company to company relationship.{Environment.NewLine}{Environment.NewLine}";
									}
								}
								else
								{
									Msg = $"This contact is attached to company to at least 1 company to company relationship.{Environment.NewLine}{Environment.NewLine}";
								}

								Msg = $"{Msg}If you were aware of these relationships and automatically want to remove or replace these associations, Click YES.{Environment.NewLine}{Environment.NewLine}";
								Msg = $"{Msg}>> Please Remember to Add or Choose a Replacement Contact Below, If it Applies. <<";
								Msg = $"{Msg}{Environment.NewLine}{Environment.NewLine}";
								Msg = $"{Msg} If you were unaware of these relationship(s) and would like to go back to make sure you are proceeding correctly, Click NO. ";

								if (MessageBox.Show(Msg, "Company Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
								{

									Add_To_Contact_Transmit_Fields("contact_name");
									Add_To_Contact_Transmit_Fields("contact_email_address");
									Add_To_Contact_Transmit_Fields("contact_phone");

									modAdminCommon.ADO_Transaction("BeginTrans");

									// RTW - MODIFIED - 3/11/2012
									Query = "UPDATE aircraft SET ac_action_date = NULL";
									Query = $"{Query} WHERE ac_id in(select distinct cref_ac_id from aircraft_reference";
									Query = $"{Query} WHERE cref_contact_id = {nContactID.ToString()}";
									Query = $"{Query} AnD cref_comp_id = {nCompanyID.ToString()}";
									Query = $"{Query} AND cref_journ_id = {nJournID.ToString()})";
									Query = $"{Query} AND ac_journ_id = {nJournID.ToString()}";
									DbCommand TempCommand = null;
									TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
									TempCommand.CommandText = Query;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
									TempCommand.ExecuteNonQuery();

									modCommon.ClearContactActionDate(nContactID, nJournID);

									modCommon.Record_CompanyContact_Aircraft_Transmits("Contact", "Change", nCompanyID, nContactID, nJournID, ref arrChangedFields); // process transmits

									Query = "UPDATE Aircraft_Reference SET ";

									// added MSW - 10/21/19
									temp_replacement_contact_id = 0;
									if (cbo_replacement_contact.Visible)
									{
										temp_replacement_contact_id = cbo_replacement_contact.GetItemData(cbo_replacement_contact.SelectedIndex);
									}

									Query = $"{Query} cref_contact_id = {temp_replacement_contact_id.ToString()}"; // added MSW - 10/21/19

									Query = $"{Query} WHERE cref_contact_id = {nContactID.ToString()}";
									Query = $"{Query} AND cref_journ_id = {nJournID.ToString()}";
									DbCommand TempCommand_2 = null;
									TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
									TempCommand_2.CommandText = Query;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
									TempCommand_2.ExecuteNonQuery();

									//also clear up any company references aey 10/6/04

									Query = "UPDATE Company_reference";

									Query = $"{Query} SET compref_Contact_id =  {temp_replacement_contact_id.ToString()}"; // added MSW - 10/21/19


									Query = $"{Query} Where compref_Contact_id = {nContactID.ToString()}";
									Query = $"{Query} AND compref_journ_id = {nJournID.ToString()}";
									DbCommand TempCommand_3 = null;
									TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
									TempCommand_3.CommandText = Query;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
									TempCommand_3.ExecuteNonQuery();

									Query = "UPDATE Company_reference";

									Query = $"{Query} SET compref_rel_contact_id =  {temp_replacement_contact_id.ToString()}"; // added MSW - 10/21/19

									Query = $"{Query} Where compref_rel_contact_id = {nContactID.ToString()}";
									Query = $"{Query} AND compref_journ_id = {nJournID.ToString()}";
									DbCommand TempCommand_4 = null;
									TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
									TempCommand_4.CommandText = Query;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
									TempCommand_4.ExecuteNonQuery();

									modAdminCommon.ADO_Transaction("CommitTrans");

								}
								else
								{
									chk_contact_active_flag.CheckState = CheckState.Checked;
								}

							} // If CompRelated = True Or ACRelated = True Then

						} // If chk_contact_active_flag.Value = vbUnchecked And UCase$(Trim$(snp_CompanyContact("contact_active_flag").Value)) = "Y" Then

						strEMail = ($"{txt_contact_email_address.Text} ").Trim().Substring(0, Math.Min(150, ($"{txt_contact_email_address.Text} ").Trim().Length));
						strREMail = ($"{txt_contact_research_email_address.Text} ").Trim().Substring(0, Math.Min(150, ($"{txt_contact_research_email_address.Text} ").Trim().Length));

						bSubscription = false;
						strWhatChged = "";
						lSubId = 0;
						lParentId = 0;
						if (nJournID == 0)
						{
							bSubscription = modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId);
						}

						modAdminCommon.ADO_Transaction("BeginTrans");

						// OPEN UP THE CONTACT RECORD FOR EDITING
						Query = $"SELECT * FROM Contact WHERE contact_id = {nContactID.ToString()} AND contact_journ_id = {nJournID.ToString()} AND contact_comp_id = {nCompanyID.ToString()}";

						ado_UpdateContact.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						//-------------------------------------------------------
						// A Quick Check To See What Has Changed

						if (bSubscription)
						{
							if (($"{Convert.ToString(ado_UpdateContact["contact_sirname"])} ").Trim() != cbo_contact_sirname.Text.Trim())
							{
								strWhatChged = $"{strWhatChged}SirName Changed: {cbo_contact_sirname.Text.Trim()}{Environment.NewLine}";
							}
							if (($"{Convert.ToString(ado_UpdateContact["contact_last_name"])} ").Trim() != txt_contact_last_name.Text.Trim())
							{
								strWhatChged = $"{strWhatChged}Last Name Changed: {txt_contact_last_name.Text.Trim()}{Environment.NewLine}";
							}
							if (($"{Convert.ToString(ado_UpdateContact["contact_first_name"])} ").Trim() != txt_contact_first_name.Text.Trim())
							{
								strWhatChged = $"{strWhatChged}First Name Changed: {txt_contact_first_name.Text.Trim()}{Environment.NewLine}";
							}
							if (($"{Convert.ToString(ado_UpdateContact["contact_middle_initial"])} ").Trim() != txt_contact_middle_initial.Text.Trim().Substring(0, Math.Min(1, txt_contact_middle_initial.Text.Trim().Length)))
							{
								strWhatChged = $"{strWhatChged}Middle Init Changed: {txt_contact_middle_initial.Text.Trim().Substring(0, Math.Min(1, txt_contact_middle_initial.Text.Trim().Length))}{Environment.NewLine}";
							}
							if (($"{Convert.ToString(ado_UpdateContact["contact_suffix"])} ").Trim() != cbo_contact_suffix.Text.Trim())
							{
								strWhatChged = $"{strWhatChged}Suffix Changed: {cbo_contact_suffix.Text.Trim()}{Environment.NewLine}";
							}
							if (($"{Convert.ToString(ado_UpdateContact["contact_title"])} ").Trim() != cbo_contact_title.Text.Trim())
							{
								strWhatChged = $"{strWhatChged}Title Changed: {cbo_contact_title.Text.Trim()}{Environment.NewLine}";
							}
							if (($"{Convert.ToString(ado_UpdateContact["contact_email_address"])} ").Trim() != txt_contact_email_address.Text.Trim())
							{
								strWhatChged = $"{strWhatChged}Contact EMail Changed: {txt_contact_email_address.Text.Trim()}{Environment.NewLine}";
							}
							if (($"{Convert.ToString(ado_UpdateContact["contact_research_email_address"])} ").Trim() != txt_contact_research_email_address.Text.Trim())
							{
								strWhatChged = $"{strWhatChged}Contact Research EMail Changed: {txt_contact_research_email_address.Text.Trim()}{Environment.NewLine}";
							}
						}

						//------------------------------------------------------
						// Now Updated The Contact Record

						ado_UpdateContact["contact_update_date"] = DateTime.Now.ToString("d");
						ado_UpdateContact["contact_sirname"] = cbo_contact_sirname.Text.Trim();
						ado_UpdateContact["contact_last_name"] = txt_contact_last_name.Text.Trim();
						ado_UpdateContact["contact_first_name"] = txt_contact_first_name.Text.Trim();
						ado_UpdateContact["contact_middle_initial"] = txt_contact_middle_initial.Text.Trim().Substring(0, Math.Min(1, txt_contact_middle_initial.Text.Trim().Length));
						ado_UpdateContact["contact_suffix"] = cbo_contact_suffix.Text.Trim();
						ado_UpdateContact["contact_title"] = modAdminCommon.Run_Company_Rules(cbo_contact_title.Text.Trim(), "Contact", "Title");

						if (($"{Convert.ToString(ado_UpdateContact["contact_email_address"])} ").Trim() == "" && txt_contact_email_address.Text.Trim() != "")
						{
							bEMailAdded = true;
						}

						if (($"{Convert.ToString(ado_UpdateContact["contact_research_email_address"])} ").Trim() == "" && txt_contact_research_email_address.Text.Trim() != "")
						{
							bResearchEMailAdded = true;
						}

						if (($"{Convert.ToString(ado_UpdateContact["contact_email_address"])} ").Trim() != "" && txt_contact_email_address.Text.Trim() == "")
						{
							bEMailDeleted = true;
						}

						if (($"{Convert.ToString(ado_UpdateContact["contact_research_email_address"])} ").Trim() != "" && txt_contact_research_email_address.Text.Trim() == "")
						{
							bResearchEMailDeleted = true;
						}

						if (chk_iq_auto.CheckState == CheckState.Checked)
						{
							ado_UpdateContact["contact_iq_status"] = "Y";
						}
						else
						{
							ado_UpdateContact["contact_iq_status"] = "N";
						}

						ado_UpdateContact["contact_iq_email_address"] = txt_iq_email.Text.Trim();
						//----------------------------

						// added MSW - 6/23/21-----------------------
						if (chk_contact_do_not_solicit.CheckState == CheckState.Checked)
						{
							ado_UpdateContact["contact_do_not_solicit"] = "Y";
						}
						else
						{
							ado_UpdateContact["contact_do_not_solicit"] = "N";
						}
						//------------------------------


						ado_UpdateContact["contact_email_address"] = txt_contact_email_address.Text.Trim().Substring(0, Math.Min(150, txt_contact_email_address.Text.Trim().Length));
						ado_UpdateContact["contact_research_email_address"] = txt_contact_research_email_address.Text.Trim().Substring(0, Math.Min(150, txt_contact_research_email_address.Text.Trim().Length));
						ado_UpdateContact["contact_description"] = txt_contact_description.Text.Trim().Substring(0, Math.Min(250, txt_contact_description.Text.Trim().Length));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_UpdateContact["contact_action_date"] = DBNull.Value;

						if (chk_contact_active_flag.CheckState == CheckState.Checked)
						{
							if (($"{Convert.ToString(ado_UpdateContact["contact_active_flag"])} ").Trim() != "Y")
							{
								strWhatChged = $"{strWhatChged}Active Flag Changed: Y{Environment.NewLine}";
							}
							ado_UpdateContact["contact_active_flag"] = "Y";
						}
						else
						{
							if (($"{Convert.ToString(ado_UpdateContact["contact_active_flag"])} ").Trim() != "N")
							{
								strWhatChged = $"{strWhatChged}Active Flag Changed: N{Environment.NewLine}";
							}
							ado_UpdateContact["contact_active_flag"] = "N";
						}

						if (chk_HideFromCustomer.CheckState == CheckState.Checked)
						{
							ado_UpdateContact["Contact_hide_flag"] = "Y";
						}
						else
						{
							ado_UpdateContact["Contact_hide_flag"] = "N";
						}

						if (Information.IsNumeric(txt_contact_acpros_seq_no.Text.Trim()))
						{
							ado_UpdateContact["contact_acpros_seq_no"] = Convert.ToInt32(Conversion.Val(txt_contact_acpros_seq_no.Text.Trim()));
						}
						else
						{
							ado_UpdateContact["contact_acpros_seq_no"] = 0;
						}

						if (chk_contact_research_flag.CheckState == CheckState.Checked)
						{
							ado_UpdateContact["contact_research_flag"] = "Y";
						}
						else
						{
							ado_UpdateContact["contact_research_flag"] = "N";
						}

						// 05/25/2018 - By David D. Cruger; Added
						ado_UpdateContact["contact_user_id"] = modAdminCommon.gbl_User_ID;

						ado_UpdateContact.Update(); // ** UPDATE THE CONTACT

						if (arrChangedFields.GetUpperBound(0) > 0)
						{
							modCommon.Record_CompanyContact_Aircraft_Transmits("Contact", "Change", nCompanyID, nContactID, nJournID, ref arrChangedFields); // process transmits
						}

						modAdminCommon.ADO_Transaction("CommitTrans");

						if (strWhatChged != "")
						{

							if (bSubscription)
							{

								strEMailTo = modCommon.DLookUp("aconfig_email_company_contact_chg", "Application_Configuration WITH (NOLOCK)").Trim();

								strSubject = $"Homebase Contact Changed for {CompanyName_Renamed} [{nCompanyID.ToString()}] Contact {TempContactName} [{nContactID.ToString()}] ";

								strEMailBody = $"Homebase Contact Changed{Environment.NewLine}{Environment.NewLine}";
								strEMailBody = $"{strEMailBody}Company: {CompanyName_Renamed} [{nCompanyID.ToString()}]{Environment.NewLine}{Environment.NewLine}";
								strEMailBody = $"{strEMailBody}Contact: {TempContactName} [{nContactID.ToString()}]{Environment.NewLine}{Environment.NewLine}";
								strEMailBody = $"{strEMailBody}{strWhatChged}{Environment.NewLine}";

								// Temp Hold - May Not Need To Do This With Customer Program Messages
								bResults = modEmail.Simple_Insert_EMail_Queue_Record(strEMailTo, "", "", strSubject, strEMailBody, "", "Y", "Open", "Homebase Contact Change", "jetnet@jetnet.com", nCompanyID, nContactID);

								if (bResults)
								{
									modEmail.Send_All_EMail_In_Queue(ref strErrMsg, nCompanyID);
								}

								modCommon.Enter_Customer_Program_Message_Note("", strEMailTo, $"Contact Changed{Environment.NewLine}{strEMailBody}", lSubId, lParentId, nCompanyID, nContactID);

							} // If bSubscription = True Then

						} // If strWhatChged <> "" Then

						if (bEMailAdded)
						{
							modCommon.Start_Activity_Monitor_Message("Contact EMail Added", ref strMsg, ref dtStartDate, ref dtEndDate);
							strMsg = $" - {($"{txt_contact_email_address.Text} ").Trim()}";
							modCommon.End_Activity_Monitor_Message("Contact EMail Added", ref strMsg, dtStartDate, ref dtEndDate, 0, nJournID, nCompanyID, 0, nContactID);
						}

						if (bResearchEMailAdded)
						{
							modCommon.Start_Activity_Monitor_Message("Contact Research EMail Added", ref strMsg, ref dtStartDate, ref dtEndDate);
							strMsg = $" - {($"{txt_contact_research_email_address.Text} ").Trim()}";
							modCommon.End_Activity_Monitor_Message("Contact Research EMail Added", ref strMsg, dtStartDate, ref dtEndDate, 0, nJournID, nCompanyID, 0, nContactID);
						}

						if (bEMailDeleted)
						{
							modCommon.Start_Activity_Monitor_Message("Contact EMail Deleted", ref strMsg, ref dtStartDate, ref dtEndDate);
							strMsg = $" - {($"{Convert.ToString(txt_contact_email_address.Tag)} ").Trim()}";
							modCommon.End_Activity_Monitor_Message("Contact EMail Deleted", ref strMsg, dtStartDate, ref dtEndDate, 0, nJournID, nCompanyID, 0, nContactID);
						}

						if (bResearchEMailDeleted)
						{
							modCommon.Start_Activity_Monitor_Message("Contact Research EMail Deleted", ref strMsg, ref dtStartDate, ref dtEndDate);
							strMsg = $" - {($"{Convert.ToString(txt_contact_research_email_address.Tag)} ").Trim()}";
							modCommon.End_Activity_Monitor_Message("Contact Research EMail Deleted", ref strMsg, dtStartDate, ref dtEndDate, 0, nJournID, nCompanyID, 0, nContactID);
						}


						if (strEMail != "")
						{
							if (nJournID == 0)
							{
								AddRemoveContactEMailFromDoNotSendTable();
							}
						}

						Contact_Message_Off();

					} // If snp_CompanyContact.State = adStateOpen And inContactId > 0 Then

				} // If nContactID > 0 Then
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"update_contact_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(Load)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
			}

		} // Update_Contact

		private void fill_research_contact_list()
		{

			// PURPOSE: THE PURPOSE OF THIS PROCEDURE IS TO FILL A LIST/COMBO OF CONTACTS FOR THE SELECTED COMPANY.
			// RTW - MODIFIED ON 9/22/2010 - INCLUDED THE INDEX HINT IN QUERY

			try
			{
				string Query = "";
				Query = "";
				string TempName = "";
				TempName = "";
				string TempTitle = "";
				TempTitle = "";
				ADORecordSetHelper ado_ResearchContact = new ADORecordSetHelper();

				cbo_replacement_contact.Enabled = false;
				cbo_replacement_contact.Items.Clear();
				cbo_replacement_contact.AddItem("", 0);
				cbo_replacement_contact.SetItemData(cbo_replacement_contact.Items.Count - 1, 0);
				cbo_replacement_contact.AddItem("No Contact Replacement Selected", 1);
				cbo_replacement_contact.SetItemData(cbo_replacement_contact.Items.Count - 1, 0);
				cbo_replacement_contact.SelectedIndex = 0;

				//extract fields from contact table
				Query = "SELECT contact_id, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, contact_title ";
				Query = $"{Query}FROM Contact WITH (NOLOCK) ";
				Query = $"{Query}WHERE contact_comp_id = {nCompanyID.ToString()}";
				Query = $"{Query} AND contact_journ_id = {nJournID.ToString()}";
				Query = $"{Query} AND contact_active_flag = 'Y'";
				Query = $"{Query} ORDER BY contact_first_name, contact_last_name";

				ado_ResearchContact = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_ResearchContact.Fields) && !(ado_ResearchContact.BOF && ado_ResearchContact.EOF))
				{

					while(!ado_ResearchContact.EOF)
					{
						TempName = "";
						TempTitle = "";

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_ResearchContact["contact_first_name"]) && !Convert.IsDBNull(ado_ResearchContact["contact_last_name"]))
						{

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ResearchContact["contact_first_name"]))
							{
								if (Convert.ToString(ado_ResearchContact["contact_first_name"]).Trim() != modGlobalVars.cEmptyString)
								{
									TempName = $"{TempName}{Convert.ToString(ado_ResearchContact["contact_first_name"]).Trim()}{modGlobalVars.cSingleSpace}";
								}
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ResearchContact["contact_middle_initial"]))
							{
								if (Convert.ToString(ado_ResearchContact["contact_middle_initial"]).Trim() != modGlobalVars.cEmptyString)
								{
									TempName = $"{TempName}{Convert.ToString(ado_ResearchContact["contact_middle_initial"]).Trim()}.{modGlobalVars.cSingleSpace}";
								}
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ResearchContact["contact_last_name"]))
							{
								if (Convert.ToString(ado_ResearchContact["contact_last_name"]).Trim() != modGlobalVars.cEmptyString)
								{
									TempName = $"{TempName}{Convert.ToString(ado_ResearchContact["contact_last_name"]).Trim()}{modGlobalVars.cSingleSpace}";
								}
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ResearchContact["contact_suffix"]))
							{
								if (Convert.ToString(ado_ResearchContact["contact_suffix"]).Trim() != modGlobalVars.cEmptyString)
								{
									TempName = $"{TempName}{Convert.ToString(ado_ResearchContact["contact_suffix"]).Trim()}";
								}
							}
						}
						else
						{
							TempName = modGlobalVars.cEmptyString;
						}


						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_ResearchContact["contact_sirname"]))
						{
							if (Convert.ToString(ado_ResearchContact["contact_sirname"]).Trim() != modGlobalVars.cEmptyString)
							{
								TempName = $"{TempName} ({Convert.ToString(ado_ResearchContact["contact_sirname"]).Trim()}){modGlobalVars.cSingleSpace}";
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_ResearchContact["Contact_Title"]))
						{
							TempTitle = Convert.ToString(ado_ResearchContact["Contact_Title"]).Trim();
						}
						else
						{
							TempTitle = modGlobalVars.cEmptyString;
						}

						if (TempName.Trim() != modGlobalVars.cEmptyString && TempTitle.Trim() != modGlobalVars.cEmptyString)
						{
							TempName = $"{TempName.Trim()} / {TempTitle.Trim()}";
						}
						else if (TempName.Trim() == modGlobalVars.cEmptyString && TempTitle.Trim() != modGlobalVars.cEmptyString)
						{ 
							TempName = $"[No Contact Name] / {TempTitle.Trim()}";
						}
						else if (TempName.Trim() != modGlobalVars.cEmptyString && TempTitle.Trim() == modGlobalVars.cEmptyString)
						{ 
							TempName = $"{TempName.Trim()} / [No Contact Title]";
						}

						if (TempName.Trim() != "")
						{

							cbo_replacement_contact.AddItem(TempName);
							cbo_replacement_contact.SetItemData(cbo_replacement_contact.Items.Count - 1, Convert.ToInt32(ado_ResearchContact["Contact_ID"]));

						}

						ado_ResearchContact.MoveNext();
					};

					ado_ResearchContact.Close();

				}

				cbo_replacement_contact.Enabled = true;

				ado_ResearchContact = null;


				modSubscription.search_off();
			}
			catch
			{

				modSubscription.search_off();
			}


		}


		private void lbl_comp_Click(Object eventSender, EventArgs eventArgs)
		{

			string strPhoneNbr = "";
			string strHTML = "";
			bool bValid = false;


		} // lbl_comp_Click

		private void lblTransmitContactRecord_Click(Object eventSender, EventArgs eventArgs)
		{

			if (MessageBox.Show("Transmit This Contact Record To Evolution Without Any Changes?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{

				if (nContactID > 0)
				{

					modCommon.ClearContactActionDate(nContactID, nJournID);

					MessageBox.Show($"Transmit Successful{Environment.NewLine}{Environment.NewLine}You Must Exit The Contact Record{Environment.NewLine}{Environment.NewLine}Before It Will Be Transmitted To Evolution", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

				} // If nContactID > 0 Then

			} // MsgBox

		} // lblTransmitContactRecord_Click

		public void mnuContactDialPhoneNumber_Click(Object eventSender, EventArgs eventArgs)
		{
			frm_Company frm_Company = frm_Company.DefInstance;

			string strType = "";
			string strPhoneNbr = "";
			string strMsg = "";
			int lRow1 = grd_Contact_Phone_Numbers.CurrentRowIndex;

			if (lRow1 > 0)
			{

				strType = Convert.ToString(grd_Contact_Phone_Numbers[lRow1, 0].Value);
				if (strType != "")
				{

					//UPGRADE_TODO: (1067) Member cbo_comp_country is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					//UPGRADE_TODO: (1067) Member cbo_comp_account is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					strPhoneNbr = modCommon.Format_Phone_Number_To_Dial(($"{Convert.ToString(frm_Company.cbo_comp_account[COMP_LINE_ACCESS].Text)} ").Trim(), ($"{Convert.ToString(frm_Company.cbo_comp_country.Text)} ").Trim(), Convert.ToString(grd_Contact_Phone_Numbers[lRow1, 1].Value).Trim(), Convert.ToString(grd_Contact_Phone_Numbers[lRow1, 2].Value).Trim(), Convert.ToString(grd_Contact_Phone_Numbers[lRow1, 3].Value).Trim(), Convert.ToString(grd_Contact_Phone_Numbers[lRow1, 4].Value).Trim());

					strMsg = $"Contact: {Convert.ToString(txt_contact_id.Tag).Trim()} - [{strType} - {strPhoneNbr}]";

					modAdminCommon.Record_Event("Dial Phone Number", strMsg, 0, nJournID, nCompanyID, false, 0, nContactID);

					strMsg = $"[{strType} - {strPhoneNbr}]";

					modCommon.EnterStandardJournalNotes($"Auto Dialed - {strMsg}", "", 0, nCompanyID, nContactID, 0);

					// changed MSW - 5/12/22 - per andrew to change to new call one dialer
					//TAPIDialer Replace(strPhoneNbr, "-", "")
					modCallOne.CallOne_Dialer(StringsHelper.Replace(StringsHelper.Replace(strPhoneNbr, "-", "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary));



				} // If strType <> "" Then

			} // If lRow1 > 0 Then

		} // mnuContactDialPhoneNumber_Click

		private void grd_Contact_Phone_Numbers_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			string strType = "";

			int lRow1 = grd_Contact_Phone_Numbers.MouseRow;
			int lCol1 = grd_Contact_Phone_Numbers.MouseCol;

			if (lRow1 > 0)
			{

				if (Button == UpgradeHelpers.Utils.WinForms.MouseButtonsHelper.GetVB6ShortValue(MouseButtons.Right))
				{

					if (grd_Contact_Phone_Numbers.CurrentRowIndex != grd_Contact_Phone_Numbers.MouseRow)
					{
						grd_Contact_Phone_Numbers.CurrentRowIndex = grd_Contact_Phone_Numbers.MouseRow;
					} // If grd_Contact_Phone_Numbers.Row <> grd_Contact_Phone_Numbers.MouseRow Then

					strType = Convert.ToString(grd_Contact_Phone_Numbers[lRow1, 0].Value);

					if (strType != "")
					{

						mnuContactDialPhoneNumber.Available = true;

						modCommon.Highlight_Grid_Row(grd_Contact_Phone_Numbers);

						//UPGRADE_WARNING: (6024) Default menues are not supported for Context Menues (Popup) More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6024
						Ctx_mnuRightClickPhoneNumbers.Show(this, PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y);

						grd_Contact_Phone_Numbers.Redraw = true;

					} // If strType <> "" Then

				} // If Button = vbRightButton Then

			} // If lRow1 > 0 Then

		} // grd_Contact_Phone_Numbers_MouseDown

		private void lblCompanyContact_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.lblCompanyContact, eventSender);
			switch(Index)
			{
				case 1 : 
					confirm_companycontact_field("contact_title"); 
					break;
				case 2 : case 3 : case 4 : case 5 : case 6 : 
					confirm_companycontact_field("contact_name"); 
					break;
				case 7 : 
					confirm_companycontact_field("contact_email"); 
					break;
			}
		}

		private void lstTitleGroup_SelectedIndexChanged(Object eventSender, EventArgs eventArgs) => modFillCompConControls.Fill_Contact_Title(cbo_contact_title, lstTitleGroup);


		private void txt_contact_email_address_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			if (txt_contact_email_address.Text.Trim() != "")
			{
				JetNetSupport.PInvoke.SafeNative.shell32.ShellExecute(Support.GetHInstance().ToInt32(), "open", $"mailto:{txt_contact_email_address.Text.Trim()}", null, null, 0);
			}

		}

		private void txt_contact_research_email_address_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			if (txt_contact_research_email_address.Text.Trim() != "")
			{
				JetNetSupport.PInvoke.SafeNative.shell32.ShellExecute(Support.GetHInstance().ToInt32(), "open", $"mailto:{txt_contact_research_email_address.Text.Trim()}", null, null, 0);
			}

		}

		private void Contact_Message_On(string inMessage)
		{

			try
			{

				this.Cursor = Cursors.WaitCursor;
				pnl_update_Message.Visible = true;
				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_update_Message.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_update_Message.setCaption(inMessage.Trim());
				pnl_update_Message.Refresh();
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, inMessage, Color.Blue);
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("CompanyContact (frm_CompanyContact)", $"Contact_Message_On: {Information.Err().Number.ToString()} - {excep.Message}");
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

		}

		private void Contact_Message_Off()
		{

			this.Cursor = CursorHelper.CursorDefault;
			pnl_update_Message.Visible = false;
			//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_update_Message.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			pnl_update_Message.setCaption(" ");
			pnl_update_Message.Refresh();
			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			Application.DoEvents();

		}

		//----------------------------------------------------------- contact phone number functions
		private void txt_pnum_area_code_TextChanged(Object eventSender, EventArgs eventArgs)
		{

			string ConfirmColor = ColorTranslator.ToOle(Color.White).ToString(); // reset confirm color if changed
			int lastColumn = 0;

			lastColumn = grd_Contact_Phone_Numbers.CurrentColumnIndex;
			grd_Contact_Phone_Numbers.CurrentColumnIndex = 2;

			if (!bIsClearPhoneData)
			{
				if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != txt_pnum_area_code.Text.Trim())
				{
					cbo_pnum_type.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_cntry_code.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_area_code.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_prefix.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_number.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
				}
			}

			grd_Contact_Phone_Numbers.CurrentColumnIndex = lastColumn;

		}

		private void txt_pnum_cntry_code_TextChanged(Object eventSender, EventArgs eventArgs)
		{

			string ConfirmColor = ColorTranslator.ToOle(Color.White).ToString(); // reset confirm color if changed
			int lastColumn = 0;

			lastColumn = grd_Contact_Phone_Numbers.CurrentColumnIndex;
			grd_Contact_Phone_Numbers.CurrentColumnIndex = 1;

			if (!bIsClearPhoneData)
			{
				if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != txt_pnum_cntry_code.Text.Trim())
				{
					cbo_pnum_type.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_cntry_code.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_area_code.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_prefix.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_number.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
				}
			}

			grd_Contact_Phone_Numbers.CurrentColumnIndex = lastColumn;

		}

		private void txt_pnum_number_TextChanged(Object eventSender, EventArgs eventArgs)
		{

			string ConfirmColor = ColorTranslator.ToOle(Color.White).ToString(); // reset confirm color if changed
			int lastColumn = 0;

			lastColumn = grd_Contact_Phone_Numbers.CurrentColumnIndex;
			grd_Contact_Phone_Numbers.CurrentColumnIndex = 4;

			if (!bIsClearPhoneData)
			{
				if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != txt_pnum_number.Text.Trim())
				{
					cbo_pnum_type.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_cntry_code.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_area_code.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_prefix.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_number.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
				}
			}

			grd_Contact_Phone_Numbers.CurrentColumnIndex = lastColumn;

		}

		private void txt_pnum_prefix_TextChanged(Object eventSender, EventArgs eventArgs)
		{

			string ConfirmColor = ColorTranslator.ToOle(Color.White).ToString(); // reset confirm color if changed
			int lastColumn = 0;

			lastColumn = grd_Contact_Phone_Numbers.CurrentColumnIndex;
			grd_Contact_Phone_Numbers.CurrentColumnIndex = 3;

			if (!bIsClearPhoneData)
			{
				if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != txt_pnum_prefix.Text.Trim())
				{
					cbo_pnum_type.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_cntry_code.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_area_code.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_prefix.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_number.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
				}
			}

			grd_Contact_Phone_Numbers.CurrentColumnIndex = lastColumn;

		}

		//UPGRADE_WARNING: (2074) ComboBox event cbo_pnum_type.Change was upgraded to cbo_pnum_type.TextChanged which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
		private bool isInitializingComponent;
		private void cbo_pnum_type_TextChanged(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}

			string ConfirmColor = ColorTranslator.ToOle(Color.White).ToString(); // reset confirm color if changed
			int lastColumn = 0;

			lastColumn = grd_Contact_Phone_Numbers.CurrentColumnIndex;
			grd_Contact_Phone_Numbers.CurrentColumnIndex = 0;

			if (!bIsClearPhoneData)
			{
				if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != cbo_pnum_type.Text.Trim())
				{
					cbo_pnum_type.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_cntry_code.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_area_code.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_prefix.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					txt_pnum_number.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
				}
			}

			grd_Contact_Phone_Numbers.CurrentColumnIndex = lastColumn;

		}

		private void CheckForContactPhoneChange(bool bAddNumber)
		{

			// used to check for changes in the first two rows for
			// transmit to evo for windows

			ADORecordSetHelper snpPhoneCheck = new ADORecordSetHelper(); //aey 6/14/04
			int LastRow = 0;

			bool HasChanged = false;
			// MSW  - 2/28/2012 - CHANGED QUERY TO USE FULL INDEX

			// 10/07/2019 - By David D. Cruger; Removed INDEX HINT
			//Query = "SELECT * FROM Phone_Numbers  WITH(NOLOCK,index(ix_pnum_comp_id_contact_id_journ_id_key)) , Phone_type WITH(NOLOCK) WHERE pnum_comp_id = " & CStr(nCompanyID)
			string Query = "SELECT * FROM Phone_Numbers WITH (NOLOCK) ";
			Query = $"{Query}INNER JOIN Phone_type WITH (NOLOCK) ON ptype_name = pnum_type ";
			Query = $"{Query}WHERE (pnum_comp_id = {nCompanyID.ToString()}) ";
			Query = $"{Query}AND (pnum_contact_id = {nContactID.ToString()}) ";
			Query = $"{Query}AND (pnum_journ_id = {nJournID.ToString()}) ";
			Query = $"{Query}ORDER BY ptype_seq_no, pnum_number_full";

			snpPhoneCheck.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpPhoneCheck.BOF && snpPhoneCheck.EOF))
			{ // if we are doing an update

				LastRow = grd_Contact_Phone_Numbers.CurrentRowIndex;

				int tempForEndVar = grd_Contact_Phone_Numbers.RowsCount - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{

					if (i > 2)
					{
						break;
					}

					grd_Contact_Phone_Numbers.CurrentRowIndex = i;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 0;
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != ($"{Convert.ToString(snpPhoneCheck["pnum_type"])}").Trim())
					{
						HasChanged = true;
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 1;
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != ($"{Convert.ToString(snpPhoneCheck["pnum_cntry_code"])}").Trim())
					{
						HasChanged = true;
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 2;
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != ($"{Convert.ToString(snpPhoneCheck["pnum_area_code"])}").Trim())
					{
						HasChanged = true;
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 3;
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != ($"{Convert.ToString(snpPhoneCheck["pnum_Prefix"])}").Trim())
					{
						HasChanged = true;
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 4;
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != ($"{Convert.ToString(snpPhoneCheck["pnum_number"])}").Trim())
					{
						HasChanged = true;
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 5;
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != ($"{Convert.ToString(snpPhoneCheck["pnum_Ext"])}").Trim())
					{
						HasChanged = true;
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 6;
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim().Substring(Math.Min(0, grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim().Length), Math.Min(1, Math.Max(0, grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim().Length))).ToUpper() != ($"{Convert.ToString(snpPhoneCheck["pnum_hide_customer"])}").Trim())
					{
						if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim().Substring(Math.Min(0, grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim().Length), Math.Min(1, Math.Max(0, grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim().Length))).ToUpper() == "N" && ($"{Convert.ToString(snpPhoneCheck["pnum_hide_customer"])}").Trim() != "")
						{
							HasChanged = true;
						}
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 5;
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != ($"{Convert.ToString(snpPhoneCheck["pnum_confirm_date"])}").Trim())
					{
						HasChanged = true;
					}

					if (HasChanged)
					{

						HasChanged = false;
						Add_To_Contact_Transmit_Fields($"contact_phone{i.ToString()}");
					}

					if (!(i >= snpPhoneCheck.RecordCount))
					{
						snpPhoneCheck.MoveNext();
					}
					else
					{
						break;
					}

				}

				grd_Contact_Phone_Numbers.CurrentRowIndex = LastRow;

			}
			else
			{

				if (grd_Contact_Phone_Numbers.MouseRow == 1)
				{
					Add_To_Contact_Transmit_Fields("contact_phone1");
				}
				else if (grd_Contact_Phone_Numbers.MouseRow == 2)
				{ 
					Add_To_Contact_Transmit_Fields("contact_phone2");
				}

			}


			snpPhoneCheck.Close();

		}

		public string delete_phone_number_contact()
		{

			// Function used to remove contact phone numbers from grid

			string result = "";
			string bad_Fone_Num = "";
			string bad_Fone_Num_type = "";

			int i = 0;
			string Query = "";
			int tmpContactId = 0;
			string ptype = "";
			int journ_id = 0;

			try
			{
				result = "";

				if (grd_Contact_Phone_Numbers.CurrentRowIndex > 0)
				{

					i = grd_Contact_Phone_Numbers.CurrentRowIndex;




					cmd_delete_contact_Phone.Tag = Convert.ToString(grd_Contact_Phone_Numbers[i, 8].Value).Trim();



					bad_Fone_Num_type = Convert.ToString(grd_Contact_Phone_Numbers[i, 0].Value).Trim();

					for (int K = 1; K <= 4; K++)
					{
						if (Convert.ToString(grd_Contact_Phone_Numbers[i, K].Value).Trim() != modGlobalVars.cEmptyString)
						{
							bad_Fone_Num = $"{bad_Fone_Num}{Convert.ToString(grd_Contact_Phone_Numbers[i, K].Value).Trim()}{((K == 4) ? modGlobalVars.cEmptyString : modGlobalVars.cHyphen)}";
						}
					}

					if (bad_Fone_Num.Trim() != modGlobalVars.cEmptyString)
					{
						bad_Fone_Num = bad_Fone_Num.Trim();
					}

					// make sure the phone number is not blank and that its all numeric
					if (bad_Fone_Num == modGlobalVars.cEmptyString || !(Information.IsNumeric(StringsHelper.Replace(StringsHelper.Replace(bad_Fone_Num, " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim())))
					{
						return result;
					}

					grd_Contact_Phone_Numbers.RemoveItem(grd_Contact_Phone_Numbers.CurrentRowIndex);

					//keep 15 rows in the grid, so add a row after deleting.
					grd_Contact_Phone_Numbers.AddItem("");
					grd_Contact_Phone_Numbers.Redraw = true;

					result = $"{bad_Fone_Num_type}:{bad_Fone_Num}";

				}
				else
				{
					MessageBox.Show("Nothing Selected", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Delete_Phone_Number_Contact_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(PHONE)");
				Contact_Message_Off();
				return result;
			}
		}

		public void confirm_all_contact_phone_numbers()
		{
			//*****************************************************************************************************
			// Function used to confirm all contact phone numbers
			//*****************************************************************************************************
			string Full_Phone = "";
			string Query = "";

			int tempForEndVar = grd_Contact_Phone_Numbers.RowsCount - 1;
			for (int i = 1; i <= tempForEndVar; i++)
			{
				grd_Contact_Phone_Numbers.CurrentRowIndex = i;

				Full_Phone = "";

				grd_Contact_Phone_Numbers.CurrentColumnIndex = 1;
				if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
				{
					Full_Phone = $"{Full_Phone}{grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim()}{modGlobalVars.cHyphen}";
				}

				grd_Contact_Phone_Numbers.CurrentColumnIndex = 2;
				if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
				{
					Full_Phone = $"{Full_Phone}{grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim()}{modGlobalVars.cHyphen}";
				}

				grd_Contact_Phone_Numbers.CurrentColumnIndex = 3;
				if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
				{
					Full_Phone = $"{Full_Phone}{grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim()}{modGlobalVars.cHyphen}";
				}

				grd_Contact_Phone_Numbers.CurrentColumnIndex = 4;
				if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
				{
					Full_Phone = $"{Full_Phone}{grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim()}";
				}

				Full_Phone = modAdminCommon.Fix_Quote(Full_Phone);
				if (Full_Phone.Trim() != "")
				{
					string tempRefParam = "";
					Confirm_Contact_Phone_Number(ref tempRefParam);
				}
				Full_Phone = "";
			}

		}

		public void Confirm_Contact_Phone_Number(ref string Full_Phone_return)
		{
			//*****************************************************************************************************
			// Function used to confirm a contact phone number
			//*****************************************************************************************************
			try
			{
				string Query = "";
				string Full_Phone = "";
				Full_Phone = "";
				string Full_Phone_Search = "";
				Full_Phone_Search = "";
				string Full_Phone_Type = "";
				Full_Phone_Type = "";
				int i = 0;
				int K = 0;
				string pnum_Ext = "";

				i = grd_Contact_Phone_Numbers.CurrentRowIndex;
				Full_Phone_Type = ($"{Convert.ToString(grd_Contact_Phone_Numbers[i, 0].Value)}").Trim();

				for (K = 1; K <= 4; K++)
				{
					if (Convert.ToString(grd_Contact_Phone_Numbers[i, K].Value).Trim() != "")
					{
						Full_Phone = $"{Full_Phone}{Convert.ToString(grd_Contact_Phone_Numbers[i, K].Value).Trim()}{((K == 4) ? "" : modGlobalVars.cHyphen)}";
					}
				}

				// added MSW 0 6/14/21
				K = 5;
				if (Convert.ToString(grd_Contact_Phone_Numbers[i, K].Value).Trim() != "")
				{
					pnum_Ext = $" Ext:{Convert.ToString(grd_Contact_Phone_Numbers[i, K].Value).Trim()}";
				}

				Full_Phone = Full_Phone.Trim();
				Full_Phone_Search = modCommon.LeaveOnlyAlphaAndNumeric(Full_Phone);

				Full_Phone_return = Full_Phone_Search;

				if (Full_Phone != "")
				{

					Query = $"UPDATE Phone_Numbers SET pnum_confirm_date = '{DateTime.Now.ToString("d")}'";

					// added to confirm by id  - MSW - 5/25/23
					if (Convert.ToString(cmd_confirm_contact_Phone.Tag).Trim() != "" && Convert.ToString(cmd_confirm_contact_Phone.Tag).Trim() != "0")
					{
						Query = $"{Query} WHERE pnum_id = {Convert.ToString(cmd_confirm_contact_Phone.Tag)}";
					}
					else
					{
						Query = $"{Query} WHERE pnum_comp_id = {nCompanyID.ToString()}";
						Query = $"{Query} AND pnum_journ_id = 0 AND pnum_contact_id = {nContactID.ToString()}";
						Query = $"{Query} AND pnum_type = '{Full_Phone_Type.Trim()}'";
						Query = $"{Query} AND pnum_number_full_search = '{Full_Phone_Search}'";
					}



					modAdminCommon.ADO_Transaction("BeginTrans");

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					modAdminCommon.Rec_Journal_Info.journ_subject = modAdminCommon.Create_Confirm_Verify_Subject($"Confirmed Contact Phone Number ({Full_Phone_Type.Trim()}) {Full_Phone}{pnum_Ext}", "CNCFM", 0, nCompanyID, nContactID);

					modAdminCommon.Rec_Journal_Info.journ_description = " ";
					modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CNCFM";
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = nContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
					modAdminCommon.Rec_Journal_Info.journ_status = "A";
					modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

					frm_Journal.DefInstance.Commit_Journal_Entry();

					modAdminCommon.ADO_Transaction("CommitTrans");

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 0;
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 1;
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 2;
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 3;
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 4;
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 5;
					grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = DateTime.Now.ToString("d");
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 6;
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;

					Full_Phone = "";

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 0;

				}

				fill_contact_phone_Grid();
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Confirm_Contact_Phone_Numbers_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(PHONE)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return;
			}

		}
		public void Confirm_Contact_Phone_Number_For_Related_Contacts(string Related_ID_List, int confirmed_row)
		{
			//*****************************************************************************************************
			// Function used to confirm a contact phone number
			//*****************************************************************************************************
			try
			{
				string Query = "";
				string Full_Phone = "";
				Full_Phone = "";
				string Full_Phone_Type = "";
				Full_Phone_Type = "";
				int i = 0;
				string query_update = "";
				string[] contact_Array = null;
				int contact_count = 0;
				int temp_comp_id = 0;
				contact_count = 0;

				//i = grd_Contact_Phone_Numbers.Row

				i = confirmed_row;
				Full_Phone_Type = ($"{Convert.ToString(grd_Contact_Phone_Numbers[i, 0].Value)}").Trim();

				for (int K = 1; K <= 4; K++)
				{
					if (Convert.ToString(grd_Contact_Phone_Numbers[i, K].Value).Trim() != "")
					{
						Full_Phone = $"{Full_Phone}{Convert.ToString(grd_Contact_Phone_Numbers[i, K].Value).Trim()}{((K == 4) ? "" : modGlobalVars.cHyphen)}";
					}
				}

				// ADDED MSW - 11/20/15
				if (Related_ID_List.Trim() != "")
				{
					query_update = $"UPDATE Phone_Numbers SET pnum_confirm_date = '{DateTime.Now.ToString("d")}'";
					query_update = $"{query_update} WHERE pnum_journ_id = 0 AND pnum_contact_id in ({Related_ID_List}) ";
					query_update = $"{query_update} and pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(Full_Phone, " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}'  ";

					modAdminCommon.ADO_Transaction("BeginTrans");

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = query_update;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					if (Related_ID_List.IndexOf(',') >= 0)
					{
						contact_Array = Related_ID_List.Split(',');
						contact_count = contact_Array.GetUpperBound(0);
					}
					else
					{
						Related_ID_List = $"{Related_ID_List},";
						contact_Array = Related_ID_List.Split(',');
						contact_count = 0;
					}

				}


				if (Full_Phone.Trim() != "")
				{
					Full_Phone = Full_Phone.Trim();
				}

				if (Full_Phone.Trim() != "")
				{

					Query = $"UPDATE Phone_Numbers SET pnum_confirm_date = '{DateTime.Now.ToString("d")}'";
					Query = $"{Query} WHERE pnum_comp_id = {nCompanyID.ToString()}";
					Query = $"{Query} AND pnum_journ_id = 0 AND pnum_contact_id = {nContactID.ToString()}";
					Query = $"{Query} AND pnum_type = '{Full_Phone_Type.Trim()}'";
					Query = $"{Query} AND pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(Full_Phone, " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}'";

					modAdminCommon.ADO_Transaction("BeginTrans");

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();



					int tempForEndVar2 = contact_count;
					for (i = 0; i <= tempForEndVar2; i++)
					{

						contact_Array[i] = StringsHelper.Replace(contact_Array[i], "'", "", 1, -1, CompareMethod.Binary);



						if (nContactID.ToString().Trim() != contact_Array[i].Trim())
						{
							temp_comp_id = 0;
							temp_comp_id = modCompany.Get_Company_ID(Convert.ToInt32(Double.Parse(contact_Array[i])));

							modAdminCommon.Rec_Journal_Info.journ_subject = modAdminCommon.Create_Confirm_Verify_Subject($"Confirmed Contact Phone Number ({Full_Phone_Type.Trim()}) {Full_Phone}", "CNCFM", 0, temp_comp_id, Convert.ToInt32(Double.Parse(contact_Array[i])));

							modAdminCommon.Rec_Journal_Info.journ_description = " ";
							modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CNCFM";
							modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
							modAdminCommon.Rec_Journal_Info.journ_comp_id = temp_comp_id;


							modAdminCommon.Rec_Journal_Info.journ_contact_id = Convert.ToInt32(Double.Parse(contact_Array[i]));
							modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
							modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
							modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
							modAdminCommon.Rec_Journal_Info.journ_status = "A";
							modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

							frm_Journal.DefInstance.Commit_Journal_Entry();

						}

					}


					modAdminCommon.ADO_Transaction("CommitTrans");

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 0;
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 1;
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 2;
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 3;
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 4;
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 5;
					grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = DateTime.Now.ToString("d");
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 6;
					grd_Contact_Phone_Numbers.CellBackColor = Color.White;

					Full_Phone = "";

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 0;

				}

				fill_contact_phone_Grid();
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Confirm_Contact_Phone_Numbers_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(PHONE)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return;
			}

		}

		private bool save_contact_phone(bool bIn_AddPhoneNumber, bool bIn_DeletePhoneNumber, string sIn_Old_PhoneNumber, bool b_OnlyChangeIsHide, string dtOldConfirmDate, string Original_Phone_No_Ext = "")
		{

			bool result = false;
			try
			{

				string Query = "";
				string errString = "";
				string Full_Phone = "";
				Full_Phone = "";
				string Full_Phone_Type = "";
				Full_Phone_Type = "";
				string temp_old_phone = "";
				temp_old_phone = "";
				string temp_val_phone = "";
				temp_val_phone = "";
				string strMsg = "";
				System.DateTime dtStartDate = DateTime.FromOADate(0);
				System.DateTime dtEndDate = DateTime.FromOADate(0);
				string update_phone_start = "";
				string update_q = "";

				bool bSubscription = false;
				int lSubId = 0;
				int lParentId = 0;
				bool bResults = false;
				string strEMailTo = "";
				string strEMailSubject = "";
				string strEMailBody = "";
				string strErrMsg = "";

				result = false;

				bSubscription = false;
				if (nJournID == 0)
				{
					bSubscription = modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId);
				}

				if (!bIn_AddPhoneNumber && !bIn_DeletePhoneNumber)
				{
					Contact_Message_On("Updating Contact Phone Number ...");
				}
				else if (bIn_AddPhoneNumber && !bIn_DeletePhoneNumber)
				{ 
					Contact_Message_On("Adding Contact Phone Numbers ...");
				}
				else if (!bIn_AddPhoneNumber && bIn_DeletePhoneNumber)
				{ 
					Contact_Message_On("Deleting Contact Phone Number ...");
				}

				// REVIEW CHANGES IN THE PHONE GRID AND WRITE TRANSMIT RECORDS IF NECESSARY
				arrChangedFields = new string[]{"", ""};
				arrChangedFields[0] = "";

				CheckForContactPhoneChange(bIn_AddPhoneNumber);

				string contact_id_list = "";
				int number_of_contacts = 0;
				string query_update = "";
				string[] tmpDeleteNumberAry = null;
				int tmpJournal_ID = 0;
				if (snp_CompanyContact.State == ConnectionState.Open && nContactID > 0)
				{

					if (!(bIn_AddPhoneNumber) && !(bIn_DeletePhoneNumber) && sIn_Old_PhoneNumber != "")
					{ // change contact phone number update it

						Full_Phone = "";
						Full_Phone_Type = "";

						if (cbo_pnum_type.Text.Trim() != "")
						{
							Query = $"UPDATE Phone_Numbers SET pnum_type = '{cbo_pnum_type.Text.Trim()}',";
							Full_Phone_Type = cbo_pnum_type.Text.Trim();
						}
						else
						{
							Query = "UPDATE Phone_Numbers SET pnum_type = null,";
						}

						if (txt_pnum_cntry_code.Text.Trim() != "")
						{
							Query = $"{Query}pnum_cntry_code = '{modCommon.RemoveNonNumbers(txt_pnum_cntry_code.Text).Trim()}',";
							Full_Phone = $"{Full_Phone}{txt_pnum_cntry_code.Text.Trim()}{modGlobalVars.cHyphen}";
						}
						else
						{
							Query = $"{Query}pnum_cntry_code = null,";
						}

						if (txt_pnum_area_code.Text.Trim() != "")
						{
							Query = $"{Query}pnum_area_code = '{modCommon.RemoveNonNumbers(txt_pnum_area_code.Text).Trim()}',";
							Full_Phone = $"{Full_Phone}{txt_pnum_area_code.Text.Trim()}{modGlobalVars.cHyphen}";
						}
						else
						{
							Query = $"{Query}pnum_area_code = null,";
						}

						if (txt_pnum_prefix.Text.Trim() != "")
						{
							Query = $"{Query}pnum_prefix = '{modCommon.RemoveNonNumbers(txt_pnum_prefix.Text).Trim()}',";
							Full_Phone = $"{Full_Phone}{txt_pnum_prefix.Text.Trim()}{modGlobalVars.cHyphen}";
						}
						else
						{
							Query = $"{Query}pnum_prefix = null,";
						}

						if (txt_pnum_number.Text.Trim() != "")
						{
							Query = $"{Query}pnum_number = '{modCommon.RemoveNonNumbers(txt_pnum_number.Text).Trim()}',";
							Full_Phone = $"{Full_Phone}{txt_pnum_number.Text.Trim()}{modGlobalVars.cHyphen}";
						}
						else
						{
							Query = $"{Query}pnum_number = null,";
						}


						// added in MSW - 5/13/2020
						if (txt_ext.Text.Trim() != "")
						{
							Query = $"{Query}pnum_ext = '{modCommon.RemoveNonNumbers(txt_ext.Text).Trim()}',";
							// Full_Phone = Full_Phone & Trim$(txt_ext.Text) & cHyphen
						}
						else
						{
							Query = $"{Query}pnum_ext = null,";
						}



						// PHONE NUMBER FULL
						if (Full_Phone.Trim() != "")
						{
							Full_Phone = Full_Phone.Substring(Math.Min(0, Full_Phone.Length), Math.Min(Strings.Len(Full_Phone) - 1, Math.Max(0, Full_Phone.Length))); // strip off the last hyphen
						}

						// PHONE CONFIRM DATE
						if (b_OnlyChangeIsHide)
						{
							if (Information.IsDate(dtOldConfirmDate))
							{
								Query = $"{Query}pnum_confirm_date = '{DateTime.Parse(dtOldConfirmDate).ToString("d")}',"; // dont change if b_OnlyChangeIsHide
							}
							else
							{
								Query = $"{Query}pnum_confirm_date = '{DateTime.Now.ToString("d")}',"; // always set to today for update
							}
						}
						else
						{
							Query = $"{Query}pnum_confirm_date = '{DateTime.Now.ToString("d")}',"; // always set to today for update
						}

						// PHONE HIDE CUSTOMER FLAG
						if (chk_pnum_hide_customer.CheckState == CheckState.Checked)
						{
							Query = $"{Query}pnum_hide_customer = 'Y',";
						}
						else
						{
							Query = $"{Query}pnum_hide_customer = 'N',";
						}

						Query = $"{Query}pnum_number_full = '{StringsHelper.Replace(Full_Phone, " ", "", 1, -1, CompareMethod.Binary).Trim()}',";
						Query = $"{Query}pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(Full_Phone, " ", "", 1, -1, CompareMethod.Binary), modGlobalVars.cHyphen, "", 1, -1, CompareMethod.Binary).Trim()}'";

						update_phone_start = Query;


						// added MSW - 5/25/23
						if (Convert.ToString(cmd_save_contact_phone.Tag).Trim() != "" && Convert.ToString(cmd_save_contact_phone.Tag).Trim() != "0")
						{
							Query = $"{Query} where pnum_id = {Convert.ToString(cmd_save_contact_phone.Tag)}";
						}
						else
						{

							Query = $"{Query} WHERE pnum_comp_id = {nCompanyID.ToString()}";
							Query = $"{Query} AND pnum_journ_id = {nJournID.ToString()}";
							Query = $"{Query} AND pnum_contact_id = {nContactID.ToString()}";
							Query = $"{Query} AND pnum_type = '{Original_Phone_Type.Trim()}'";

							if (sIn_Old_PhoneNumber.IndexOf("Ext") >= 0)
							{
								// put in 10/17/2012 - MSW - to deal with special case for yachts with extensions
								temp_old_phone = sIn_Old_PhoneNumber;
								temp_old_phone = StringsHelper.Replace(temp_old_phone.ToLower(), "ext", "", 1, -1, CompareMethod.Binary);
								if (Strings.Len(temp_old_phone) > 12)
								{
									if (temp_old_phone.IndexOf('-') >= 0)
									{
										temp_val_phone = temp_old_phone.Substring(0, Math.Min(temp_old_phone.IndexOf('-'), temp_old_phone.Length));
										Query = $"{Query} AND pnum_cntry_code = '{temp_val_phone}'";

										temp_old_phone = temp_old_phone.Substring(Math.Max(temp_old_phone.Length - (Strings.Len(temp_old_phone) - (temp_old_phone.IndexOf('-') + 1)), 0));
									}
								}

								if (temp_old_phone.IndexOf('-') >= 0)
								{
									temp_val_phone = temp_old_phone.Substring(0, Math.Min(temp_old_phone.IndexOf('-'), temp_old_phone.Length));
									Query = $"{Query} AND pnum_area_code = '{temp_val_phone}'";

									temp_old_phone = temp_old_phone.Substring(Math.Max(temp_old_phone.Length - (Strings.Len(temp_old_phone) - (temp_old_phone.IndexOf('-') + 1)), 0));
								}

								if (temp_old_phone.IndexOf('-') >= 0)
								{
									temp_val_phone = temp_old_phone.Substring(0, Math.Min(temp_old_phone.IndexOf('-'), temp_old_phone.Length));
									Query = $"{Query} AND pnum_prefix = '{temp_val_phone}'";
								}

							}
							else
							{
								// added MSW -3/15/21 -
								if (Original_Phone_No_Ext.Trim() != "")
								{
									Query = $"{Query} AND pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(Original_Phone_No_Ext, modGlobalVars.cHyphen, "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary).Trim()}'";
								}
								else
								{
									Query = $"{Query} AND pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(sIn_Old_PhoneNumber, modGlobalVars.cHyphen, "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary).Trim()}'";
								}
							}
						}

						if (Full_Phone_Type.Trim() != "" && Full_Phone.Trim() != "")
						{ // only add a phone number if we have a type and some numbers to save

							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();


							contact_id_list = "";
							string tempRefParam = "";
							contact_id_list = modCompany.Confirm_Matching_Contacts(Convert.ToInt32(Double.Parse(nContactID.ToString())), ref number_of_contacts, sIn_Old_PhoneNumber, ref tempRefParam, 0);
							if (contact_id_list.Trim() != "")
							{
								if (MessageBox.Show($"This Contact Has {number_of_contacts.ToString()} Other Contacts Connected To It With the Same Phone Number. Would you like to Update These as Well?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
								{
									if (contact_id_list.Trim() != "" && sIn_Old_PhoneNumber.Trim() != "")
									{

										query_update = update_phone_start;
										query_update = $"{query_update} WHERE pnum_journ_id = 0 AND pnum_contact_id in ({contact_id_list}) ";
										query_update = $"{query_update} and pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(sIn_Old_PhoneNumber, modGlobalVars.cHyphen, "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary).Trim()}' ";
										query_update = query_update;
										modAdminCommon.ADO_Transaction("BeginTrans");

										DbCommand TempCommand_2 = null;
										TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
										TempCommand_2.CommandText = query_update;
										//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
										//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
										TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
										TempCommand_2.ExecuteNonQuery();

									}
								}
							}

							if (!b_OnlyChangeIsHide)
							{

								// INSERT A COMPANY CONFIRMATION JOURNAL ENTRY
								modAdminCommon.Rec_Journal_Info.journ_subject = $"Confirmed Contact Phone Number ({Full_Phone_Type}) {Full_Phone}";
								if (txt_ext.Text.Trim() != "")
								{
									modAdminCommon.Rec_Journal_Info.journ_subject = $"{modAdminCommon.Rec_Journal_Info.journ_subject} Ext:{txt_ext.Text.Trim()}";
								}
								modAdminCommon.Rec_Journal_Info.journ_description = $"Updated Contact Phone Number - done by {modAdminCommon.gbl_User_ID}";
								modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CNCFM";
								modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTime.Parse(modAdminCommon.DateToday).ToString("d").Trim());
								modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
								modAdminCommon.Rec_Journal_Info.journ_contact_id = nContactID;
								modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
								modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
								modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
								modAdminCommon.Rec_Journal_Info.journ_status = "A";
								modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

								frm_Journal.DefInstance.Commit_Journal_Entry();
							}

						}
						else
						{
							Contact_Message_Off();
							return result;
						}

					}
					else if (bIn_AddPhoneNumber && !(bIn_DeletePhoneNumber) && sIn_Old_PhoneNumber == "")
					{  // new company phone number insert it

						Full_Phone = "";
						Full_Phone_Type = "";

						Query = "INSERT INTO Phone_Numbers (pnum_comp_id,pnum_journ_id,pnum_contact_id,pnum_type,";
						Query = $"{Query}pnum_cntry_code,pnum_area_code,pnum_prefix,pnum_number,pnum_ext,pnum_hide_customer,";
						Query = $"{Query}pnum_confirm_date,pnum_number_full,pnum_number_full_search) VALUES (";
						Query = $"{Query}{nCompanyID.ToString()}, "; // company ID
						Query = $"{Query}{nJournID.ToString()}, "; // journal ID
						Query = $"{Query}{nContactID.ToString()}, "; // contact ID

						if (cbo_pnum_type.Text.Trim() != "")
						{
							Query = $"{Query}'{cbo_pnum_type.Text.Trim()}',";
							Full_Phone_Type = cbo_pnum_type.Text.Trim();
						}
						else
						{
							Query = $"{Query}null,";
						}

						if (txt_pnum_cntry_code.Text.Trim() != "")
						{
							Query = $"{Query}'{modCommon.RemoveNonNumbers(txt_pnum_cntry_code.Text).Trim()}',";
							Full_Phone = $"{Full_Phone}{txt_pnum_cntry_code.Text.Trim()}{modGlobalVars.cHyphen}";
						}
						else
						{
							Query = $"{Query}null,";
						}

						if (txt_pnum_area_code.Text.Trim() != "")
						{
							Query = $"{Query}'{modCommon.RemoveNonNumbers(txt_pnum_area_code.Text).Trim()}',";
							Full_Phone = $"{Full_Phone}{txt_pnum_area_code.Text.Trim()}{modGlobalVars.cHyphen}";
						}
						else
						{
							Query = $"{Query}null,";
						}

						if (txt_pnum_prefix.Text.Trim() != "")
						{
							Query = $"{Query}'{modCommon.RemoveNonNumbers(txt_pnum_prefix.Text).Trim()}',";
							Full_Phone = $"{Full_Phone}{txt_pnum_prefix.Text.Trim()}{modGlobalVars.cHyphen}";
						}
						else
						{
							Query = $"{Query}null,";
						}

						if (txt_pnum_number.Text.Trim() != "")
						{
							Query = $"{Query}'{modCommon.RemoveNonNumbers(txt_pnum_number.Text).Trim()}',";
							Full_Phone = $"{Full_Phone}{txt_pnum_number.Text.Trim()}{modGlobalVars.cHyphen}";
						}
						else
						{
							Query = $"{Query}null,";
						}

						// added in MSW - 5/14/20
						if (txt_ext.Text.Trim() != "")
						{
							Query = $"{Query}'{modCommon.RemoveNonNumbers(txt_ext.Text).Trim()}',";
							//  Full_Phone = Full_Phone & Trim$(txt_ext.Text) & cHyphen
						}
						else
						{
							Query = $"{Query}null,";
						}

						// PHONE NUMBER FULL
						if (Full_Phone.Trim() != "")
						{
							Full_Phone = Full_Phone.Substring(Math.Min(0, Full_Phone.Length), Math.Min(Strings.Len(Full_Phone) - 1, Math.Max(0, Full_Phone.Length))); // strip off the last hyphen
						}

						// PHONE HIDE CUSTOMER FLAG
						if (chk_pnum_hide_customer.CheckState == CheckState.Checked)
						{
							Query = $"{Query}'Y',";
						}
						else
						{
							Query = $"{Query}'N',";
						}

						// PHONE CONFIRM DATE
						Query = $"{Query}'{DateTime.Now.ToString("d")}',"; // always set to today for add

						// PHONE NUMBER FULL
						Query = $"{Query}'{StringsHelper.Replace(Full_Phone, " ", "", 1, -1, CompareMethod.Binary).Trim()}',";

						// PHONE NUMBER FULL SEARCH
						Query = $"{Query}'{StringsHelper.Replace(StringsHelper.Replace(Full_Phone, " ", "", 1, -1, CompareMethod.Binary), modGlobalVars.cHyphen, "", 1, -1, CompareMethod.Binary).Trim()}')";

						if (Full_Phone_Type.Trim() != "" && Full_Phone.Trim() != "")
						{ // only add a phone number if we have a type and some numbers to save

							DbCommand TempCommand_3 = null;
							TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
							TempCommand_3.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
							TempCommand_3.ExecuteNonQuery();

							// INSERT A COMPANY CONFIRMATION JOURNAL ENTRY
							modAdminCommon.Rec_Journal_Info.journ_subject = $"Confirmed Contact Phone Number ({Full_Phone_Type}) {Full_Phone}";

							if (txt_ext.Text.Trim() != "")
							{
								modAdminCommon.Rec_Journal_Info.journ_subject = $"{modAdminCommon.Rec_Journal_Info.journ_subject} Ext:{txt_ext.Text.Trim()}";
							}

							modAdminCommon.Rec_Journal_Info.journ_description = $"Added New Contact Phone Number - done by {modAdminCommon.gbl_User_ID}";
							modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CNCFM";
							modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTime.Parse(modAdminCommon.DateToday).ToString("d").Trim());
							modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
							modAdminCommon.Rec_Journal_Info.journ_contact_id = nContactID;
							modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
							modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
							modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
							modAdminCommon.Rec_Journal_Info.journ_status = "A";
							modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

							frm_Journal.DefInstance.Commit_Journal_Entry();

							modCommon.Start_Activity_Monitor_Message("Contact Phone Added", ref strMsg, ref dtStartDate, ref dtEndDate);
							strMsg = $" - {cbo_pnum_type.Text} - {Full_Phone}";
							modCommon.End_Activity_Monitor_Message("Contact Phone Added", ref strMsg, dtStartDate, ref dtEndDate, 0, nJournID, nCompanyID, 0, nContactID);

						}
						else
						{
							Contact_Message_Off();
							return result;
						}

					}
					else if (!(bIn_AddPhoneNumber) && bIn_DeletePhoneNumber && sIn_Old_PhoneNumber != "")
					{  // delete company phone number


						tmpDeleteNumberAry = sIn_Old_PhoneNumber.Split(':');

						if (Convert.ToString(cmd_delete_contact_Phone.Tag).Trim() != "" && Convert.ToString(cmd_delete_contact_Phone.Tag).Trim() != "0")
						{
							Query = $"DELETE from Phone_Numbers WHERE pnum_id = {Convert.ToString(cmd_delete_contact_Phone.Tag)}";
						}
						else
						{
							Query = $"DELETE from Phone_Numbers WHERE pnum_comp_id = {nCompanyID.ToString()}";
							Query = $"{Query} AND pnum_journ_id = {nJournID.ToString()}";
							Query = $"{Query} AND pnum_contact_id = {nContactID.ToString()}";
							Query = $"{Query} AND pnum_type = '{tmpDeleteNumberAry[0].Trim()}'";


							Query = $"{Query} AND pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(tmpDeleteNumberAry[1], modGlobalVars.cHyphen, "", 1, -1, CompareMethod.Binary), " ", "", 1, -1, CompareMethod.Binary).Trim()}'";

						}



						if (tmpDeleteNumberAry[0].Trim() != "" && tmpDeleteNumberAry[1].Trim() != "")
						{ // only add a phone number if we have a type and some numbers to save

							DbCommand TempCommand_4 = null;
							TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
							TempCommand_4.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
							TempCommand_4.ExecuteNonQuery();

							//record the removed number in a journal entry
							modAdminCommon.Rec_Journal_Info.journ_subject = $"Removed Contact Phone Number ({tmpDeleteNumberAry[0].Trim()}) {tmpDeleteNumberAry[1].Trim()}";
							modAdminCommon.Rec_Journal_Info.journ_description = $"Removed Contact Phone Number - done by {modAdminCommon.gbl_User_ID}";
							modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
							modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
							modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
							modAdminCommon.Rec_Journal_Info.journ_contact_id = nContactID;
							modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
							modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
							modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
							modAdminCommon.Rec_Journal_Info.journ_status = "A";
							modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

							tmpJournal_ID = frm_Journal.DefInstance.Commit_Journal_Entry();

							Journal_List = $"{Journal_List},{tmpJournal_ID.ToString()}";

							tmpJournal_ID = 0;

							if (nJournID == 0)
							{

								if (bSubscription)
								{

									strEMailTo = ($"{modCommon.DLookUp("aconfig_email_company_contact_chg", "Application_Configuration")}").Trim();

									//If gbl_User_ID = "mvit" Then
									//  strEMailTo = "david@jetnet.com"
									//End If

									strEMailSubject = $"Homebase Contact Phone Nbr Deleted for {CompanyName_Renamed} [{nCompanyID.ToString()}] {TempContactName} [{nContactID.ToString()}]";

									strEMailBody = $"Homebase Contact Phone Nbr Deleted{Environment.NewLine}{Environment.NewLine}";
									strEMailBody = $"{strEMailBody}Company: {CompanyName_Renamed} [{nCompanyID.ToString()}] {Environment.NewLine}{Environment.NewLine}";
									strEMailBody = $"{strEMailBody}Contact: {TempContactName} [{nContactID.ToString()}]{Environment.NewLine}{Environment.NewLine}";
									strEMailBody = $"{strEMailBody}Phone Nbr: {tmpDeleteNumberAry[0].Trim()} - {tmpDeleteNumberAry[1].Trim()}{Environment.NewLine}{Environment.NewLine}";

									bResults = modEmail.Simple_Insert_EMail_Queue_Record(strEMailTo, "", "", strEMailSubject, strEMailBody, "", "N", "Open", "Homebase Contact Phone Nbr Deleted", "jetnet@jetnet.com", nCompanyID, nContactID);

									if (bResults)
									{
										modEmail.Send_All_EMail_In_Queue(ref strErrMsg, nCompanyID);
									}

									modCommon.Enter_Customer_Program_Message_Note("", strEMailTo, $"{strEMailSubject}{Environment.NewLine}{strEMailBody}", lSubId, lParentId, nCompanyID, nContactID);

								} // If bSubscription = True Then

							} // If nJournID = 0 Then

						}
						else
						{
							Contact_Message_Off();
							return result;
						}

					}

					if (arrChangedFields.GetUpperBound(0) > 0 && !bIn_DeletePhoneNumber)
					{
						modCommon.Record_CompanyContact_Aircraft_Transmits("Contact", "Change", nCompanyID, nContactID, nJournID, ref arrChangedFields); // process transmits
					}

					result = true;

				}


				// ADDED MSW - 1/25/17 - any time a phone number is added, deleted or updated, make sure the contact action date is NULL
				update_q = $"Update Contact set contact_action_date = NULL where contact_journ_id = 0 and  contact_id = {nContactID.ToString()}";

				modAdminCommon.ADO_Transaction("BeginTrans");

				DbCommand TempCommand_5 = null;
				TempCommand_5 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
				TempCommand_5.CommandText = update_q;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_5.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
				TempCommand_5.ExecuteNonQuery();


				Contact_Message_Off();

				return result;
			}
			catch (System.Exception excep)
			{

				// FOUND AN ERROR - REPORT IT
				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"save_contact_phone_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(SAVEPHONE)");
				Contact_Message_Off();
				return result;
			}
		}




		public void fill_contact_phone_Grid()
		{
			//*****************************************************************************************************
			// Function used to fill contact phone grid
			//**************************************************************************************************
			string Query = "";
			string BuildString = "";
			ADORecordSetHelper snp_ContactPhone = null;

			try
			{

				grd_Contact_Phone_Numbers.Enabled = false;
				grd_Contact_Phone_Numbers.Clear();

				grd_Contact_Phone_Numbers.ColumnsCount = 9;
				grd_Contact_Phone_Numbers.RowsCount = 15;

				grd_Contact_Phone_Numbers.FixedRows = 1;
				grd_Contact_Phone_Numbers.FixedColumns = 0;

				grd_Contact_Phone_Numbers.CurrentRowIndex = 0;
				grd_Contact_Phone_Numbers.CurrentColumnIndex = 0;

				grd_Contact_Phone_Numbers.SetColumnWidth(0, 60);
				grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "Type";
				grd_Contact_Phone_Numbers.CurrentColumnIndex = 1;
				grd_Contact_Phone_Numbers.SetColumnWidth(1, 53);
				grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "Country";
				grd_Contact_Phone_Numbers.CurrentColumnIndex = 2;
				grd_Contact_Phone_Numbers.SetColumnWidth(2, 53);
				grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "Area";
				grd_Contact_Phone_Numbers.CurrentColumnIndex = 3;
				grd_Contact_Phone_Numbers.SetColumnWidth(3, 53);
				grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "Prefix";
				grd_Contact_Phone_Numbers.CurrentColumnIndex = 4;
				grd_Contact_Phone_Numbers.SetColumnWidth(4, 80);
				grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "Phone";
				grd_Contact_Phone_Numbers.CurrentColumnIndex = 5;
				grd_Contact_Phone_Numbers.SetColumnWidth(4, 47);
				grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "Ext";
				grd_Contact_Phone_Numbers.CurrentColumnIndex = 6;
				grd_Contact_Phone_Numbers.SetColumnWidth(5, 80);
				grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "Confirmed";
				grd_Contact_Phone_Numbers.CurrentColumnIndex = 7;
				grd_Contact_Phone_Numbers.SetColumnWidth(6, 53);
				grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "Hide";
				grd_Contact_Phone_Numbers.CurrentColumnIndex = 8;
				grd_Contact_Phone_Numbers.SetColumnWidth(8, 0);
				grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "ID";


				if (nContactID != -1)
				{
					Query = "SELECT * FROM Phone_Numbers WITH (NOLOCK) ";
					Query = $"{Query}INNER JOIN Phone_Type WITH(NOLOCK) ON ptype_name = pnum_type ";
					Query = $"{Query}WHERE (pnum_comp_id = {nCompanyID.ToString()}) ";
					Query = $"{Query}AND (pnum_contact_id = {nContactID.ToString()}) ";
					Query = $"{Query}AND (pnum_journ_id = {nJournID.ToString()}) ";
					Query = $"{Query}ORDER BY ptype_seq_no, pnum_number_full";

					snp_ContactPhone = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_ContactPhone.Fields) && !(snp_ContactPhone.EOF && snp_ContactPhone.BOF))
					{
						grd_Contact_Phone_Numbers.CurrentRowIndex = 1;


						while(!snp_ContactPhone.EOF)
						{

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_ContactPhone["pnum_type"]))
							{

								if (Convert.ToString(snp_ContactPhone["pnum_type"]).Trim() != "")
								{

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (Convert.IsDBNull(snp_ContactPhone["pnum_confirm_date"]))
									{
										modAdminCommon.ConfirmColor = (0xC0C0FF).ToString();
									}
									else if (((int) DateAndTime.DateDiff("d", Convert.ToDateTime(snp_ContactPhone["pnum_confirm_date"]), DateTime.Parse(modAdminCommon.DateToday), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > modAdminCommon.gbl_ColorConfirmDays && nJournID == 0)
									{  //aey 8/20/04
										modAdminCommon.ConfirmColor = (0xC0C0FF).ToString();
									}
									else
									{
										modAdminCommon.ConfirmColor = ColorTranslator.ToOle(Color.White).ToString();
									}

									grd_Contact_Phone_Numbers.CurrentColumnIndex = 0;
									grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ContactPhone["pnum_type"])}").Trim();
									grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));

									grd_Contact_Phone_Numbers.CurrentColumnIndex = 1;
									grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ContactPhone["pnum_cntry_code"])}").Trim();
									grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));

									grd_Contact_Phone_Numbers.CurrentColumnIndex = 2;
									grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ContactPhone["pnum_area_code"])}").Trim();
									grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));

									grd_Contact_Phone_Numbers.CurrentColumnIndex = 3;
									grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ContactPhone["pnum_Prefix"])}").Trim();
									grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));

									grd_Contact_Phone_Numbers.CurrentColumnIndex = 4;
									grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ContactPhone["pnum_number"])}").Trim();
									grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));

									grd_Contact_Phone_Numbers.CurrentColumnIndex = 5;
									grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ContactPhone["pnum_Ext"])}").Trim();
									grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));

									grd_Contact_Phone_Numbers.CurrentColumnIndex = 6;
									
									grd_Contact_Phone_Numbers.ColAlignment[6] = DataGridViewContentAlignment.TopCenter;

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(snp_ContactPhone["pnum_confirm_date"]))
									{
										if (Convert.ToDateTime(snp_ContactPhone["pnum_confirm_date"]).ToOADate() != 0)
										{
											grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = DateTime.Parse(Convert.ToString(snp_ContactPhone["pnum_confirm_date"]).Trim()).ToString("d");
										}
										else
										{
											grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "";
										}
									}
									else
									{
										grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "";
									}

									grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));

									grd_Contact_Phone_Numbers.CurrentColumnIndex = 7;
									if (Convert.ToString(snp_ContactPhone["pnum_hide_customer"]).ToUpper() == "Y")
									{
										grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "Yes";
									}
									else
									{
										grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "No";
									}

									grd_Contact_Phone_Numbers.CurrentColumnIndex = 8;
									grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ContactPhone["pnum_id"])}").Trim();


									grd_Contact_Phone_Numbers.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));

									snp_ContactPhone.MoveNext();

									grd_Contact_Phone_Numbers.CurrentRowIndex++;
								}

							}

						}; // Do While Not snp_ContactPhone.EOF

						cmdDelete.Enabled = false;

					}
					else
					{

						if (chk_contact_active_flag.CheckState == CheckState.Unchecked)
						{
							cmdDelete.Enabled = true;
						}

					} // If Not (snp_ContactPhone.BOF And snp_ContactPhone.EOF) Then

					snp_ContactPhone.Close();
					snp_ContactPhone = null;

					grd_Contact_Phone_Numbers.Visible = true;
					grd_Contact_Phone_Numbers.Enabled = true;
					grd_Contact_Phone_Numbers.CurrentRowIndex = 1;
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 0;
					grd_Contact_Phone_Numbers.Redraw = true;

				}
				else
				{

					grd_Contact_Phone_Numbers.Visible = false;

				}
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"fill_contact_phone_Grid_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(GRID)");
				return;
			}

		}

		private void cmd_Confirm_Contact_Phone_Click(Object eventSender, EventArgs eventArgs)
		{
			string Msg = "";
			string Response = "";
			int RememberRow = 0;
			string contact_id_list = "";
			int number_of_contacts = 0;
			string phone_number_to_return = "";
			int Current_Row = 0;



			try
			{


				cmd_confirm_contact_Phone.Tag = "0";

				if (grd_Contact_Phone_Numbers.CurrentRowIndex > 0)
				{
					Current_Row = 0;
					Current_Row = grd_Contact_Phone_Numbers.CurrentRowIndex;

					// should get me the ID i am confirming for this contact phone number
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 8;
					cmd_confirm_contact_Phone.Tag = grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString();

					Confirm_Contact_Phone_Number(ref phone_number_to_return);

					// if its office, then and company has same office, then confirm company as well
					modCompany.Check_Company_Office_Number(phone_number_to_return, nCompanyID);


					contact_id_list = "";
					string tempRefParam = "";
					contact_id_list = modCompany.Confirm_Matching_Contacts(Convert.ToInt32(Double.Parse(nContactID.ToString())), ref number_of_contacts, phone_number_to_return, ref tempRefParam, nCompanyID);
					if (contact_id_list.Trim() != "")
					{
						if (MessageBox.Show($"This Contact Has {number_of_contacts.ToString()} Other Contacts Connected To It With the Same Phone Number. Would you like to also Confirm These?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{
							// RUN THE UPDATE OF ALL OF THE CONTACTS ASSOCIATED
							Confirm_Contact_Phone_Number_For_Related_Contacts(contact_id_list, Current_Row);
						}
					}

					cmd_Confirm_Contact.Visible = true;
				}
				else
				{
					MessageBox.Show("Nothing Selected", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmd_Confirm_Contact_Phone_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(PHONE)");
				return;
			}

		}


		public void cmd_add_Contact_phone_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_Contact_Phone.Visible = true;
			pnl_Contact_Phone.BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes

			clear_contact_phone_add();

			bAdd_Phone_Number = true;
			cmd_save_contact_phone.Text = "&Add to Phone List";

		}

		private object clear_contact_phone_add()
		{
			// Function used for clearing contact phone screen fields

			try
			{

				bIsClearPhoneData = true;

				txt_pnum_cntry_code.Text = "";
				txt_pnum_area_code.Text = "";
				txt_pnum_number.Text = "";
				txt_pnum_prefix.Text = "";
				cbo_pnum_type.SelectedIndex = -1;
				chk_pnum_hide_customer.CheckState = CheckState.Unchecked;

				cbo_pnum_type.BackColor = Color.White; // reset confirm color on add
				txt_pnum_cntry_code.BackColor = Color.White; // reset confirm color on add
				txt_pnum_area_code.BackColor = Color.White; // reset confirm color on add
				txt_pnum_prefix.BackColor = Color.White; // reset confirm color on add
				txt_pnum_number.BackColor = Color.White; // reset confirm color on add
				txt_ext.Text = "";

				bIsClearPhoneData = false;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"clear_contact_phone_add_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(PHONE)");
				return null;
			}
			return null;
		}

		private void cmd_cancel_contact_phone_Click(Object eventSender, EventArgs eventArgs)
		{

			clear_contact_phone_add();

			pnl_Contact_Phone.Visible = false;
			grd_Contact_Phone_Numbers.Enabled = true;
			grd_Contact_Phone_Numbers.Redraw = true;
			bAdd_Phone_Number = false;
			cmd_save_contact_phone.Text = "&Update Phone List";

		}

		public void cmd_save_contact_phone_Click(Object eventSender, EventArgs eventArgs)
		{

			bool bOnlyChangeIsHideFlag = false;
			string New_Phone = "";
			string New_Phone_Type = "";
			string Check_Phone = "";
			string tmpPhoneNumberCheck = "";
			string tmpPhoneNumberCheck2 = "";
			string Query = "";
			string New_Phone_Types_Used = "";
			bool bSubscription = false;
			int lSubId = 0;
			int lParentId = 0;
			string strTemp = "";
			string strEMailBody = "";
			string strEMailTo = "";
			string strSubject = "";
			bool bResults = false;
			string strErrMsg = "";
			string temp_subject = "";
			string temp_desc = "";
			string formated_phone_number = "";

			try
			{


				if (modCommon.Is_Phone_Number_Field_Visible_Non_Numeric($"{txt_pnum_cntry_code.Text}{txt_pnum_area_code.Text}{txt_pnum_prefix.Text}{txt_pnum_number.Text}{txt_ext.Text}"))
				{
					MessageBox.Show("Contact Phone Number is not numeric, please fix before saving!", "Company : Save Company Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{


					// replace all of the characters, if it makes it past the numeric check - msw - 5/23/23
					txt_pnum_cntry_code.Text = modCommon.RemoveNonNumbers(txt_pnum_cntry_code.Text).Trim();
					txt_pnum_area_code.Text = modCommon.RemoveNonNumbers(txt_pnum_area_code.Text).Trim();
					txt_pnum_prefix.Text = modCommon.RemoveNonNumbers(txt_pnum_prefix.Text).Trim();
					txt_pnum_number.Text = modCommon.RemoveNonNumbers(txt_pnum_number.Text).Trim();
					txt_ext.Text = modCommon.RemoveNonNumbers(txt_ext.Text).Trim();


					New_Phone_Types_Used = "";

					if (txt_pnum_cntry_code.Text.Trim() != "")
					{
						New_Phone = $"{txt_pnum_cntry_code.Text.Trim()}{modGlobalVars.cHyphen}";
						New_Phone_Types_Used = $"{New_Phone_Types_Used}1";
						formated_phone_number = $"{txt_pnum_cntry_code.Text.Trim()}{modGlobalVars.cHyphen}";
					}

					if (txt_pnum_area_code.Text.Trim() != "")
					{
						New_Phone = $"{New_Phone}{txt_pnum_area_code.Text.Trim()}{modGlobalVars.cHyphen}";
						New_Phone_Types_Used = $"{New_Phone_Types_Used}2";
						formated_phone_number = $"{formated_phone_number}{txt_pnum_area_code.Text.Trim()}{modGlobalVars.cHyphen}";
					}

					if (txt_pnum_prefix.Text.Trim() != "")
					{
						New_Phone = $"{New_Phone}{txt_pnum_prefix.Text.Trim()}{modGlobalVars.cHyphen}";
						New_Phone_Types_Used = $"{New_Phone_Types_Used}3";
						formated_phone_number = $"{formated_phone_number}{txt_pnum_prefix.Text.Trim()}{modGlobalVars.cHyphen}";
					}

					if (txt_pnum_number.Text.Trim() != "")
					{
						New_Phone = $"{New_Phone}{txt_pnum_number.Text.Trim()}{modGlobalVars.cHyphen}";
						New_Phone_Types_Used = $"{New_Phone_Types_Used}4";
						formated_phone_number = $"{formated_phone_number}{txt_pnum_number.Text.Trim()}";
					}

					if (txt_ext.Text.Trim() != "")
					{
						//  New_Phone = New_Phone & Trim$(txt_ext.Text) & cHyphen
						New_Phone_Types_Used = $"{New_Phone_Types_Used}5";
						formated_phone_number = $"{formated_phone_number} Ext:{txt_ext.Text.Trim()}";
					}

					if (New_Phone.Trim() != "")
					{
						New_Phone = New_Phone.Substring(Math.Min(0, New_Phone.Length), Math.Min(Strings.Len(New_Phone) - 1, Math.Max(0, New_Phone.Length))); // strip off the last hyphen
					}

					New_Phone_Type = cbo_pnum_type.Text.Trim();

					if (txt_pnum_cntry_code.Text.Trim() == "" && txt_pnum_area_code.Text.Trim() == "" && txt_pnum_prefix.Text.Trim() == "" && txt_pnum_number.Text.Trim() == "")
					{
						MessageBox.Show("Phone Number cannot be blank", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}

					Check_Phone = StringsHelper.Replace(New_Phone, modGlobalVars.cHyphen, "", 1, -1, CompareMethod.Binary).Trim(); // clean out hyphens
					Check_Phone = StringsHelper.Replace(Check_Phone, " ", "", 1, -1, CompareMethod.Binary).Trim(); // clean out spaces

					// make sure the phone number is not blank and that its all numeric
					if (Check_Phone == "" || !(Information.IsNumeric(Check_Phone)))
					{
						MessageBox.Show("Phone Number is not numbers, please fix before saving", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					else
					{
						if (txt_ext.Text.Trim() != "")
						{
							if (!Information.IsNumeric(txt_ext.Text))
							{
								MessageBox.Show("Phone Number Ext is not a number, please fix before saving", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								return;
							}
						}
					}



					if (bAdd_Phone_Number)
					{
						Original_Phone = "";
					}
					if (bAdd_Phone_Number)
					{
						Original_Phone_Type = "";
					}

					// DETERMINE IF THE PHONE NUMBER WAS REALLY CHANGED
					if (Original_Phone.Trim() == New_Phone.Trim())
					{
						// if the phone number did not change then check for "hide flag"
						if (Original_Phone_Hide == chk_pnum_hide_customer.CheckState)
						{
							// if hide flag did not change then check to see if only the type changed
							if (Original_Phone_Type.Trim() == New_Phone_Type.Trim())
							{
								if (Original_Phone_Types_Used.Trim() == New_Phone_Types_Used.Trim())
								{
									// commented this out, per instructions, changing to confirm
									//Call MsgBox("No Changes to Save", vbOKOnly + vbInformation, "Company Contact")
									cmd_Confirm_Contact_Phone_Click(cmd_confirm_contact_Phone, new EventArgs());
									return;
								}
							}
						}
						else
						{
							bOnlyChangeIsHideFlag = true;
						}
					}

					if (bAdd_Phone_Number)
					{ // add new number



						tmpPhoneNumberCheck2 = $"{cbo_pnum_type.Text.Trim()}" +
						                       $"{txt_pnum_cntry_code.Text.Trim()}" +
						                       $"{txt_pnum_area_code.Text.Trim()}" +
						                       $"{txt_pnum_prefix.Text.Trim()}" +
						                       $"{txt_pnum_number.Text.Trim()}";

						int tempForEndVar = grd_Contact_Phone_Numbers.RowsCount - 1;
						for (int i = 1; i <= tempForEndVar; i++)
						{

							tmpPhoneNumberCheck = $"{Convert.ToString(grd_Contact_Phone_Numbers[i, 0].Value).Trim()}" +
							                      $"{Convert.ToString(grd_Contact_Phone_Numbers[i, 1].Value).Trim()}" +
							                      $"{Convert.ToString(grd_Contact_Phone_Numbers[i, 2].Value).Trim()}" +
							                      $"{Convert.ToString(grd_Contact_Phone_Numbers[i, 3].Value).Trim()}" +
							                      $"{Convert.ToString(grd_Contact_Phone_Numbers[i, 4].Value).Trim()}";

							if (tmpPhoneNumberCheck.Trim() == tmpPhoneNumberCheck2.Trim())
							{
								MessageBox.Show("Duplicate Phone Number is not allowed", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								Contact_Message_Off();
								return;
							}
						}


						temp_subject = "Contact Phone Number Added";
						temp_desc = cbo_pnum_type.Text.Trim();
						temp_desc = $"{temp_desc} {formated_phone_number}"; // changed to be formatted - MSW - 12/19/22

						//dont do if its hidden
						if (chk_pnum_hide_customer.CheckState == CheckState.Unchecked)
						{
							if (chk_hidden_comp.CheckState == CheckState.Unchecked && chk_HideFromCustomer.CheckState == CheckState.Unchecked)
							{
								modCommon.InsertPriorityEvent("CPNA", 0, 0, temp_desc, nCompanyID, nContactID, "N");
							}
						}
						//---------------------------------

					}
					else
					{

						tmpPhoneNumberCheck2 = $"{cbo_pnum_type.Text.Trim()}" +
						                       $"{txt_pnum_cntry_code.Text.Trim()}" +
						                       $"{txt_pnum_area_code.Text.Trim()}" +
						                       $"{txt_pnum_prefix.Text.Trim()}" +
						                       $"{txt_pnum_number.Text.Trim()}";

						int tempForEndVar2 = grd_Contact_Phone_Numbers.RowsCount - 1;
						for (int i = 1; i <= tempForEndVar2; i++)
						{

							tmpPhoneNumberCheck = $"{Convert.ToString(grd_Contact_Phone_Numbers[i, 0].Value).Trim()}" +
							                      $"{Convert.ToString(grd_Contact_Phone_Numbers[i, 1].Value).Trim()}" +
							                      $"{Convert.ToString(grd_Contact_Phone_Numbers[i, 2].Value).Trim()}" +
							                      $"{Convert.ToString(grd_Contact_Phone_Numbers[i, 3].Value).Trim()}" +
							                      $"{Convert.ToString(grd_Contact_Phone_Numbers[i, 4].Value).Trim()}";

							if (tmpPhoneNumberCheck.Trim() == tmpPhoneNumberCheck2.Trim() && i != grd_Contact_Phone_Numbers.CurrentRowIndex)
							{
								MessageBox.Show("Duplicate Phone Number is not allowed", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								Contact_Message_Off();
								return;
							}
						}

						temp_subject = "Contact Phone Number Updated";
						temp_desc = cbo_pnum_type.Text.Trim();
						temp_desc = $"{temp_desc} {formated_phone_number}"; // changed to be formatted - MSW - 12/19/22

						//dont do if its hidden
						if (chk_pnum_hide_customer.CheckState == CheckState.Unchecked)
						{
							if (chk_hidden_comp.CheckState == CheckState.Unchecked && chk_HideFromCustomer.CheckState == CheckState.Unchecked)
							{
								modCommon.InsertPriorityEvent("CPNU", 0, 0, temp_desc, nCompanyID, nContactID, "N");
							}
						}
						//---------------------------------

					} // if add or update

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 0;
					grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = cbo_pnum_type.Text.Trim();
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 1;
					grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = txt_pnum_cntry_code.Text.Trim();
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 2;
					grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = txt_pnum_area_code.Text.Trim();
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 3;
					grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = txt_pnum_prefix.Text.Trim();
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 4;
					grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = txt_pnum_number.Text.Trim();
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 5;
					grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = txt_ext.Text.Trim();
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 6;
					grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = DateTime.Now.ToString("d").Trim();
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 7;

					if (chk_pnum_hide_customer.CheckState == CheckState.Checked)
					{
						grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "Yes";
					}
					else
					{
						grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].Value = "No";
					}

					modAdminCommon.ADO_Transaction("BeginTrans");

					if (save_contact_phone(bAdd_Phone_Number, false, Original_Phone, bOnlyChangeIsHideFlag, Original_Phone_ConfirmDate, Original_Phone_No_Ext))
					{

						bAdd_Phone_Number = false;
						//cmd_save_contact_phone.Caption = "&Update Phone List"
						cmd_save_contact_phone.Text = "&Confirm/Save";

						modAdminCommon.ADO_Transaction("CommitTrans");

						modCommon.ClearContactActionDate(nContactID, nJournID);

						fill_contact_phone_Grid();

					}
					else
					{

						MessageBox.Show("Error Saving Contact Phone Number!", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
						modAdminCommon.ADO_Transaction("RollbackTrans");

					}

					//------------------------------------------------
					//------------------------------------------------

					if (nJournID == 0)
					{

						bSubscription = modCommon.Does_Contact_Have_An_Active_Subscription(nContactID, ref lSubId, ref lParentId);

						if (bSubscription)
						{

							if (Original_Phone != New_Phone || Original_Phone_Type != New_Phone_Type || (Original_Phone_Hide != chk_pnum_hide_customer.CheckState) == (CheckState.Checked != CheckState.Unchecked))
							{

								strEMailTo = modCommon.DLookUp("aconfig_email_company_contact_chg", "Application_Configuration WITH (NOLOCK)").Trim();

								strTemp = StringsHelper.Replace(cmd_save_contact_phone.Text, "&", "", 1, -1, CompareMethod.Binary);
								if ((strTemp.IndexOf("Update") + 1) == 0)
								{
									strSubject = "Homebase Contact Phone Added for ";
								}
								else
								{
									strSubject = "Homebase Contact Phone Updated for ";
								}

								strSubject = $"{strSubject}{CompanyName_Renamed} [{nCompanyID.ToString()}] Contact {TempContactName} [{nContactID.ToString()}] ";

								strEMailBody = $"Company: {CompanyName_Renamed} [{nCompanyID.ToString()}]{Environment.NewLine}{Environment.NewLine}";
								strEMailBody = $"{strEMailBody}Contact: {TempContactName} [{nContactID.ToString()}]{Environment.NewLine}{Environment.NewLine}";

								if ((strTemp.IndexOf("Update") + 1) == 0)
								{ // Added
									strEMailBody = $"{strEMailBody}Added Phone Nbr: {New_Phone_Type} - {New_Phone} - Hide: {modCommon.ReturnCheckBoxYesNo(chk_pnum_hide_customer)}{Environment.NewLine}{Environment.NewLine}";
								}
								else
								{
									strEMailBody = $"{strEMailBody}Original Phone Nbr: {Original_Phone_Type} - {Original_Phone} - Hide: {modCommon.ReturnCheckBoxValueYesNo(Original_Phone_Hide)}{Environment.NewLine}{Environment.NewLine}";
									strEMailBody = $"{strEMailBody}Updated Phone Nbr: {New_Phone_Type} - {New_Phone} - Hide: {modCommon.ReturnCheckBoxYesNo(chk_pnum_hide_customer)}{Environment.NewLine}";
								}

								bResults = modEmail.Simple_Insert_EMail_Queue_Record(strEMailTo, "", "", strSubject, strEMailBody, "", "N", "Open", "Homebase Contact Phone Change", "jetnet@jetnet.com", nCompanyID, nContactID);

								if (bResults)
								{
									modEmail.Send_All_EMail_In_Queue(ref strErrMsg, nCompanyID);
								}

								// 05/15/2017 - By David D. Cruger; Added Message Queue
								modCommon.Enter_Customer_Program_Message_Note("", strEMailTo, $"{strSubject}{Environment.NewLine}{strEMailBody}", lSubId, lParentId, nCompanyID, nContactID);

							} // If Original_Phone <> Full_Phone Or Originaql_Phone_Type <> Full_Phone_Type Then

						} // If bSubscription = True Then

					} // If nJournID = 0 Then

					pnl_Contact_Phone.Visible = false;
					grd_Contact_Phone_Numbers.Enabled = true;
					grd_Contact_Phone_Numbers.Redraw = true;

					clear_contact_phone_add();

					Contact_Message_Off();


				} // end if for numeric
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmd_save_contact_phone ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(PHONESAVE)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				Contact_Message_Off();
				return;
			}

		}

		private void cmd_delete_contact_phone_Click(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				string slocal_Original_Phone = "";
				slocal_Original_Phone = "";
				string Query = "";
				Query = "";

				// BEGIN A TRANSACTION
				modAdminCommon.ADO_Transaction("BeginTrans");

				cmd_delete_contact_Phone.Tag = "0";

				slocal_Original_Phone = delete_phone_number_contact();

				if (save_contact_phone(false, true, slocal_Original_Phone, false, ""))
				{

					modAdminCommon.ADO_Transaction("CommitTrans");

					modCommon.ClearContactActionDate(nContactID, nJournID);

					fill_contact_phone_Grid();

				}
				else
				{
					MessageBox.Show("Error Deleting Contact Phone Number!", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
					modAdminCommon.ADO_Transaction("RollbackTrans");
				}

				pnl_Contact_Phone.Visible = false;

				grd_Contact_Phone_Numbers.Redraw = true;

				clear_contact_phone_add();

				Contact_Message_Off();
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmd_delete_contact_phone_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(PHONE)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return;
			}

		}

		private void grd_Contact_Phone_Numbers_singleClickBodyCode()
		{

			try
			{

				grd_Contact_Phone_Numbers.RowSel = grd_Contact_Phone_Numbers.CurrentRowIndex;
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"grd_Contact_Phone_Numbers_singleClick_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(GRID)");
				return;
			}

		}

		private void grd_Contact_Phone_Numbers_doubleClickBodyCode()
		{

			string ConfirmColor = "";
			int i = 0;

			try
			{

				if (grd_Contact_Phone_Numbers.CurrentRowIndex > 0 && nContactID > 0)
				{

					Original_Phone = modGlobalVars.cEmptyString;
					Original_Phone_Type = modGlobalVars.cEmptyString;
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					Original_Phone_Hide = (CheckState) (-1);
					Original_Phone_ConfirmDate = modGlobalVars.cEmptyString;

					// do a quick check for empty row
					i = grd_Contact_Phone_Numbers.CurrentRowIndex;
					Original_Phone_Type = Convert.ToString(grd_Contact_Phone_Numbers[i, 0].Value).Trim();
					Original_Phone_Types_Used = "";
					Original_Phone_No_Ext = "";

					for (int K = 1; K <= 5; K++)
					{ // changed to 5 - msw - 5/13/20, then changed back to 4 - 3/15/21 - comapre needed to not use
						if (Convert.ToString(grd_Contact_Phone_Numbers[i, K].Value).Trim() != modGlobalVars.cEmptyString)
						{

							// added MSW - 3/15/21

							if (K == 5)
							{
								// then dont add
							}
							else
							{
								Original_Phone_No_Ext = $"{Original_Phone_No_Ext}{Convert.ToString(grd_Contact_Phone_Numbers[i, K].Value).Trim()}{((K == 4) ? modGlobalVars.cEmptyString : modGlobalVars.cHyphen)}";
							}

							Original_Phone = $"{Original_Phone}{Convert.ToString(grd_Contact_Phone_Numbers[i, K].Value).Trim()}{((K == 4) ? modGlobalVars.cEmptyString : modGlobalVars.cHyphen)}";
							Original_Phone_Types_Used = $"{Original_Phone_Types_Used}{K.ToString()}";

						}
					}

					if (Original_Phone.Trim() != modGlobalVars.cEmptyString)
					{
						Original_Phone = modAdminCommon.Fix_Quote(Original_Phone).Trim();
					}

					Original_Phone_ConfirmDate = Convert.ToString(grd_Contact_Phone_Numbers[i, 5].Value).Trim();

					if (Convert.ToString(grd_Contact_Phone_Numbers[i, 7].Value).Trim().ToUpper() == "Y" || Convert.ToString(grd_Contact_Phone_Numbers[i, 7].Value).Trim().ToUpper() == "YES")
					{
						chk_pnum_hide_customer.CheckState = CheckState.Checked;
					}
					else
					{
						chk_pnum_hide_customer.CheckState = CheckState.Unchecked;
					}

					Original_Phone_Hide = chk_pnum_hide_customer.CheckState;

					if (Original_Phone_Type == modGlobalVars.cEmptyString && Original_Phone == modGlobalVars.cEmptyString)
					{

						clear_contact_phone_add();

						bAdd_Phone_Number = true;
						cmd_save_contact_phone.Text = "&Add to Phone List";

					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 5;
					if (!Information.IsDate(grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString()))
					{
						if (!bAdd_Phone_Number)
						{
							ConfirmColor = (0xC0C0FF).ToString();
						}
						else
						{
							ConfirmColor = ColorTranslator.ToOle(Color.White).ToString();
						}
					}
					else if (((int) DateAndTime.DateDiff("d", DateTime.Parse(grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString()), DateTime.Parse(modAdminCommon.DateToday), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > modAdminCommon.gbl_ColorConfirmDays && nJournID == 0)
					{ 
						ConfirmColor = (0xC0C0FF).ToString();
					}
					else
					{
						ConfirmColor = ColorTranslator.ToOle(Color.White).ToString();
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 0;
					cbo_pnum_type.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));

					cbo_pnum_type.SelectedIndex = -1;
					int tempForEndVar2 = cbo_pnum_type.Items.Count - 1;
					for (i = 0; i <= tempForEndVar2; i++)
					{
						if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() == cbo_pnum_type.GetListItem(i).Trim())
						{
							cbo_pnum_type.SelectedIndex = i;
							break;
						}
					}

					txt_pnum_cntry_code.Text = "";
					txt_pnum_area_code.Text = "";
					txt_pnum_prefix.Text = "";
					txt_pnum_number.Text = "";

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 1;
					txt_pnum_cntry_code.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != modGlobalVars.cEmptyString)
					{
						txt_pnum_cntry_code.Text = grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim();
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 2;
					txt_pnum_area_code.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != modGlobalVars.cEmptyString)
					{
						txt_pnum_area_code.Text = grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim();
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 3;
					txt_pnum_prefix.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != modGlobalVars.cEmptyString)
					{
						txt_pnum_prefix.Text = grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim();
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 4;
					txt_pnum_number.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != modGlobalVars.cEmptyString)
					{
						txt_pnum_number.Text = grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim();
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 5;
					txt_pnum_number.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(ConfirmColor)));
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim() != modGlobalVars.cEmptyString)
					{
						txt_ext.Text = grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim();
					}

					// added MSW - 5/25/23
					grd_Contact_Phone_Numbers.CurrentColumnIndex = 8;
					cmd_save_contact_phone.Tag = grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim();


					grd_Contact_Phone_Numbers.CurrentColumnIndex = 7;
					if (grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim().ToUpper() == "Y" || grd_Contact_Phone_Numbers[grd_Contact_Phone_Numbers.CurrentRowIndex, grd_Contact_Phone_Numbers.CurrentColumnIndex].FormattedValue.ToString().Trim().ToUpper() == "YES")
					{
						chk_pnum_hide_customer.CheckState = CheckState.Checked;
					}
					else
					{
						chk_pnum_hide_customer.CheckState = CheckState.Unchecked;
					}

					grd_Contact_Phone_Numbers.CurrentColumnIndex = 0;

					pnl_Contact_Phone.Visible = true;
					pnl_Contact_Phone.BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes
					grd_Contact_Phone_Numbers.Enabled = false;

				}
				else
				{
					MessageBox.Show("Can't Enter Phone Numbers Until Contact is Saved!", "Company Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (System.Exception excep)
			{

				Contact_Message_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"grd_Contact_Phone_Numbers_doubleClickBodyCode_Error ({Information.Err().Number.ToString()}) {excep.Message} cmpid[{nCompanyID.ToString()}] conid[{nContactID.ToString()}] jid[{nJournID.ToString()}]", "frm_CompanyContact(GRID)");
				return;
			}

		}

		private void grd_contact_phone_numbers_Click(Object eventSender, EventArgs eventArgs) => pgTimer1.Enabled = true; // Turn On Timer


		private void grd_contact_phone_numbers_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			pgTimer1.Enabled = false; // Turn Off Timer So The Single Click Is Never Called

			gbPGTimer1DoubleClick = true;

			if (!gbPGTimer1SingleClick)
			{

				grd_Contact_Phone_Numbers_doubleClickBodyCode();

			} // If gbPGTimer1SingleClick = False Then

			gbPGTimer1DoubleClick = false;

		}

		private void pgTimer1_Tick(Object eventSender, EventArgs eventArgs)
		{

			pgTimer1.Enabled = false; // Turn OFF The Timer

			if (!gbPGTimer1DoubleClick)
			{

				gbPGTimer1SingleClick = true;

				if (grd_Contact_Phone_Numbers.CurrentRowIndex > 0)
				{

					grd_Contact_Phone_Numbers_singleClickBodyCode();

				} // If gbPGTimer1DoubleClick = False Then

				gbPGTimer1SingleClick = false;

			}

		}
	}
}