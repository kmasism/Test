using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
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

namespace JETNET_Homebase
{
	public partial class frm_CompanyAdd //gap-note Manual change to fix Inconsistent accessibility error
		: System.Windows.Forms.Form
	{


		//indicies for lables
		const int lbl_company_name = 0;
		const int LBL_COMPANY_PTYPE1 = 13;
		const int LBL_COMPANY_PTYPE2 = 14;
		const int LBL_COMPANY_AGENCY = 6;
		const int LBL_COMPANY_PRODUCTCD = 7;
		const int LBL_COMPANY_BUSTYPE = 8;
		const int LBL_COMPANY_LANGUAGE = 9;
		const int LBL_COMPANY_ACCTTYPE = 11;
		const int LBL_COMPANY_ACCTREP = 12;

		const int LBL_CONTACT_PTYPE1 = 24;
		const int LBL_CONTACT_PTYPE2 = 23;

		const int LBL_JOURNAL_SUBJECT = 47;
		const int LBL_CONTACT_FIRST_NAME = 37;
		const int LBL_CONTACT_LAST_NAME = 35;
		//indicies for text boxes
		const int COMPANY_NAME = 0;
		const int company_address1 = 1;
		const int company_address2 = 2;
		const int COMPANY_CITY = 3;
		const int COMPANY_POSTALCODE = 4;

		const int COMPANY_WEBSITE = 26;
		const int COMPANY_EMAIL = 27;

		const int COMPANY_ID = 25;
		const int COMPANY_ALT_NAME = 31;

		//indicies for Contact Name Information
		const int contact_id = 32;
		const int CONTACT_FIRST = 22;
		const int CONTACT_MIDDLE = 23;
		const int CONTACT_LAST = 24;

		const int CONTACT_ACPROSEQNO = 21;
		const int contact_email = 28;

		const int Journal_ID = 33;
		const int JOURNAL_SUBJECT = 29;
		const int JOURNAL_INTERNAL_NOTES = 30;

		//indicies for Company Phone #1
		const int COMPANY_PTYPE1 = 0;
		const int COMPANY_PCONTRY1 = 5;
		const int COMPANY_PNUMBER1 = 8;

		//indicies for Company Phone #2
		const int COMPANY_PTYPE2 = 1;
		const int COMPANY_PCONTRY2 = 9;
		const int COMPANY_PNUMBER2 = 12;

		//indicies for Contact Phone #1
		const int CONTACT_PTYPE1 = 2;
		const int CONTACT_PCONTRY1 = 13;
		const int CONTACT_PNUMBER1 = 16;

		//indicies for Contact Phone #2
		const int CONTACT_PTYPE2 = 3;
		const int CONTACT_PCONTRY2 = 17;
		const int CONTACT_PNUMBER2 = 20;

		private int n_nextCompanyID = 0;
		private int n_nextContactID = 0;
		private bool b_updateFlag = false;
		private bool b_AutoAssignFlag = false;
		public bool state_clicked = false;
		private bool bFormLoaded = false;

		public string ca_company_address1 = "";
		public string ca_company_address2 = "";
		public string ca_comp_zip = "";
		public string ca_comp_email = "";
		public string ca_comp_city = "";
		public string ca_comp_state = "";
		public string ca_comp_country = "";
		public string ca_comp_agency = "";
		public string ca_comp_business_type = "";
		public string ca_comp_language = "";
		public string ca_comp_account_rep = "";
		public string ca_comp_product = "";
		public string ca_comp_account_type = "";
		public frm_CompanyAdd()
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
			ReLoadForm(false);
		}






		public bool check_blanks(ref bool bValidCo)
		{



			if (Text1[COMPANY_NAME].Text == modGlobalVars.cEmptyString)
			{ // company name
				MessageBox.Show("Company Name is blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				set_lbl_error(Label1[lbl_company_name], true);
				bValidCo = false;
			}
			else
			{
				set_lbl_error(Label1[lbl_company_name], false);
			}

			if (cmb_agency_type.Text.Trim() == modGlobalVars.cEmptyString)
			{
				MessageBox.Show("Agency Type is blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				set_lbl_error(Label1[LBL_COMPANY_AGENCY], true);
				bValidCo = false;
			}
			else
			{
				set_lbl_error(Label1[LBL_COMPANY_AGENCY], false);
			}

			if (cmb_product_code.Text.Trim() == modGlobalVars.cEmptyString)
			{
				MessageBox.Show("Product Code is blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				set_lbl_error(Label1[LBL_COMPANY_PRODUCTCD], true);
				bValidCo = false;
			}
			else
			{
				set_lbl_error(Label1[LBL_COMPANY_PRODUCTCD], false);
			}

			if (cmb_business_type.Text.Trim() == modGlobalVars.cEmptyString)
			{
				MessageBox.Show("Business Type is blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				set_lbl_error(Label1[LBL_COMPANY_BUSTYPE], true);
				bValidCo = false;
			}
			else
			{
				set_lbl_error(Label1[LBL_COMPANY_BUSTYPE], false);
			}

			if (cmb_language.Text.Trim() == modGlobalVars.cEmptyString)
			{
				MessageBox.Show("Language is blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				set_lbl_error(Label1[LBL_COMPANY_LANGUAGE], true);
				bValidCo = false;
			}
			else
			{
				set_lbl_error(Label1[LBL_COMPANY_LANGUAGE], false);
			}

			if (cmb_account_type.Text.Trim() == modGlobalVars.cEmptyString)
			{
				MessageBox.Show("Account Type is blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				set_lbl_error(Label1[LBL_COMPANY_ACCTTYPE], true);
				bValidCo = false;
			}
			else
			{
				set_lbl_error(Label1[LBL_COMPANY_ACCTTYPE], false);
			}

			if (cmb_account_id.Text.Trim() == modGlobalVars.cEmptyString)
			{
				MessageBox.Show("Account Rep is blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				set_lbl_error(Label1[LBL_COMPANY_ACCTREP], true);
				bValidCo = false;
			}
			else
			{
				set_lbl_error(Label1[LBL_COMPANY_ACCTREP], false);
			}

			return bValidCo;
		}

		private int GetNextCompanyID()
		{
			int result = 0;
			string Query = modGlobalVars.cEmptyString;
			ADORecordSetHelper snp_NextCompanyID = null;

			try
			{

				Query = "SELECT MAX(comp_id) AS max_company_id FROM Company WITH(NOLOCK)";

				snp_NextCompanyID = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_NextCompanyID.Fields) && !(snp_NextCompanyID.EOF && snp_NextCompanyID.BOF))
				{

					if (Convert.ToDouble(snp_NextCompanyID["max_company_id"]) > 0)
					{
						result = Convert.ToInt32(Convert.ToDouble(snp_NextCompanyID["max_company_id"]) + 1);
					}
					else
					{
						result = 1;
					}

				}

				snp_NextCompanyID = null;
			}
			catch
			{
			}




			return result;
		}



		private int GetNextContactID()
		{
			int result = 0;
			string Query = modGlobalVars.cEmptyString;
			ADORecordSetHelper snp_NextContactid = null;

			try
			{

				Query = "SELECT MAX(contact_id) AS max_contact_id FROM Contact WITH(NOLOCK)";

				snp_NextContactid = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_NextContactid.Fields) && !(snp_NextContactid.EOF && snp_NextContactid.BOF))
				{

					if (Convert.ToDouble(snp_NextContactid["max_contact_id"]) > 0)
					{
						result = Convert.ToInt32(Convert.ToDouble(snp_NextContactid["max_contact_id"]) + 1);
					}
					else
					{
						result = 1;
					}

				}

				snp_NextContactid = null;
			}
			catch
			{
			}




			return result;
		}

		public void run_sp_phone_numbers_company(int comp_id)
		{

			string tupdate = "";


			if (!modCommon.Is_Phone_Number_Field_Visible_Non_Numeric($"{Text1[5].Text}{Text1[6].Text}{Text1[7].Text}{Text1[8].Text}"))
			{
				//   Call MsgBox("Company Phone Number is not numeric, please fix before saving!", vbExclamation + vbOKOnly, "Company : Save Company Phone Number")
				if (Text1[8].Text.Trim() != "")
				{

					tupdate = "";

					tupdate = " exec sp_AddUpdatePhoneNumber ";

					tupdate = $"{tupdate}{build_sp_string("@inCompanyID", comp_id.ToString())}";
					tupdate = $"{tupdate}{build_sp_string("@inContactID", "0")}";
					tupdate = $"{tupdate}{build_sp_string("@inPhoneID", "0")}";
					tupdate = $"{tupdate}{build_sp_string("@inUserID", modAdminCommon.gbl_User_ID)}";
					tupdate = $"{tupdate}{build_sp_string("@inType", cmb_phone_type[0].Text)}";
					tupdate = $"{tupdate}{build_sp_string("@inCountryCode", Text1[5].Text)}";
					tupdate = $"{tupdate}{build_sp_string("@inAreaCode", Text1[6].Text)}";
					tupdate = $"{tupdate}{build_sp_string("@inPrefix", Text1[7].Text)}";
					tupdate = $"{tupdate}{build_sp_string("@inNumber", Text1[8].Text)}";
					tupdate = $"{tupdate}{build_sp_string("@inExtension", "")}";

					// if the company is hidden, also hide the company phone number - 12/6/23
					if (chk_hide_company.CheckState == CheckState.Checked)
					{
						tupdate = $"{tupdate}{build_sp_string("@inHide", "Y")}";
					}
					else
					{
						tupdate = $"{tupdate}{build_sp_string("@inHide", "N")}";
					}

					tupdate = $"{tupdate}{build_sp_string("@inSource", "Homebase")}";
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
			}


			if (!modCommon.Is_Phone_Number_Field_Visible_Non_Numeric($"{Text1[9].Text}{Text1[10].Text}{Text1[11].Text}{Text1[12].Text}"))
			{
				// Call MsgBox("Company Phone Number is not numeric, please fix before saving!", vbExclamation + vbOKOnly, "Company : Save Company Phone Number")
				if (Text1[9].Text.Trim() != "" || Text1[10].Text != "" || Text1[11].Text != "")
				{
					tupdate = "";

					tupdate = " exec sp_AddUpdatePhoneNumber ";

					tupdate = $"{tupdate}{build_sp_string("@inCompanyID", comp_id.ToString())}";
					tupdate = $"{tupdate}{build_sp_string("@inContactID", "0")}";
					tupdate = $"{tupdate}{build_sp_string("@inPhoneID", "0")}";
					tupdate = $"{tupdate}{build_sp_string("@inUserID", modAdminCommon.gbl_User_ID)}";
					tupdate = $"{tupdate}{build_sp_string("@inType", cmb_phone_type[1].Text)}";
					tupdate = $"{tupdate}{build_sp_string("@inCountryCode", Text1[9].Text)}";
					tupdate = $"{tupdate}{build_sp_string("@inAreaCode", Text1[10].Text)}";
					tupdate = $"{tupdate}{build_sp_string("@inPrefix", Text1[11].Text)}";
					tupdate = $"{tupdate}{build_sp_string("@inNumber", Text1[12].Text)}";
					tupdate = $"{tupdate}{build_sp_string("@inExtension", "")}";
					tupdate = $"{tupdate}{build_sp_string("@inHide", "N")}";

					tupdate = $"{tupdate}{build_sp_string("@inSource", "Homebase")}";
					tupdate = tupdate;
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = tupdate;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
				}
			}






		}

		public void run_sp_phone_numbers_contact(int comp_id, int contact_id)
		{


			//  Current_Account_Type = ""
			string tupdate = "";

			if (Text1[16].Text.Trim() != "")
			{
				tupdate = " exec sp_AddUpdatePhoneNumber ";

				tupdate = $"{tupdate}{build_sp_string("@inCompanyID", comp_id.ToString())}";
				tupdate = $"{tupdate}{build_sp_string("@inContactID", contact_id.ToString())}";
				tupdate = $"{tupdate}{build_sp_string("@inPhoneID", "0")}";
				tupdate = $"{tupdate}{build_sp_string("@inUserID", modAdminCommon.gbl_User_ID)}";
				tupdate = $"{tupdate}{build_sp_string("@inType", cmb_phone_type[2].Text)}";
				tupdate = $"{tupdate}{build_sp_string("@inCountryCode", Text1[13].Text)}";
				tupdate = $"{tupdate}{build_sp_string("@inAreaCode", Text1[14].Text)}";
				tupdate = $"{tupdate}{build_sp_string("@inPrefix", Text1[15].Text)}";
				tupdate = $"{tupdate}{build_sp_string("@inNumber", Text1[16].Text)}";
				tupdate = $"{tupdate}{build_sp_string("@inExtension", "")}";

				if (chk_hide_from_customer.CheckState == CheckState.Checked)
				{
					tupdate = $"{tupdate}{build_sp_string("@inHide", "Y")}";
				}
				else
				{
					tupdate = $"{tupdate}{build_sp_string("@inHide", "N")}";
				}


				tupdate = $"{tupdate}{build_sp_string("@inSource", "Homebase")}";
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

			// 2nd phone number
			if (Text1[20].Text.Trim() != "")
			{
				tupdate = " exec sp_AddUpdatePhoneNumber ";

				tupdate = $"{tupdate}{build_sp_string("@inCompanyID", comp_id.ToString())}";
				tupdate = $"{tupdate}{build_sp_string("@inContactID", contact_id.ToString())}";
				tupdate = $"{tupdate}{build_sp_string("@inPhoneID", "0")}";
				tupdate = $"{tupdate}{build_sp_string("@inUserID", modAdminCommon.gbl_User_ID)}";
				tupdate = $"{tupdate}{build_sp_string("@inType", cmb_phone_type[3].Text)}";
				tupdate = $"{tupdate}{build_sp_string("@inCountryCode", Text1[17].Text)}";
				tupdate = $"{tupdate}{build_sp_string("@inAreaCode", Text1[18].Text)}";
				tupdate = $"{tupdate}{build_sp_string("@inPrefix", Text1[19].Text)}";
				tupdate = $"{tupdate}{build_sp_string("@inNumber", Text1[20].Text)}";
				tupdate = $"{tupdate}{build_sp_string("@inExtension", "")}";

				if (chk_hide_from_customer.CheckState == CheckState.Checked)
				{
					tupdate = $"{tupdate}{build_sp_string("@inHide", "Y")}";
				}
				else
				{
					tupdate = $"{tupdate}{build_sp_string("@inHide", "N")}";
				}


				tupdate = $"{tupdate}{build_sp_string("@inSource", "Homebase")}";
				tupdate = tupdate;
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = tupdate;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

			}

		}

		private void chk_auto_account_rep_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (!b_updateFlag)
				{

					if (chk_auto_account_rep.CheckState == CheckState.Checked && !b_AutoAssignFlag)
					{
						modFillCompConControls.assign_account_rep(Text1[COMPANY_NAME].Text, cmb_account_type, cmb_account_id);
						b_AutoAssignFlag = true;
					}
					else if (chk_auto_account_rep.CheckState == CheckState.Unchecked && b_AutoAssignFlag)
					{ 
						b_AutoAssignFlag = false;
					}

				}
			}
			catch
			{
			}




		}

		private void cmb_account_id_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (!b_updateFlag)
				{
					ToolTipMain.SetToolTip(cmb_account_id, cmb_account_id.Text);
				}
			}
			catch
			{
			}




		}

		private void cmb_account_type_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (!b_updateFlag)
				{
					if (chk_auto_account_rep.CheckState == CheckState.Checked)
					{
						modFillCompConControls.assign_account_rep(Text1[COMPANY_NAME].Text, cmb_account_type, cmb_account_id);
					}
					ToolTipMain.SetToolTip(cmb_account_type, cmb_account_type.Text);
				}
			}
			catch
			{
			}




		}

		private void cmb_agency_type_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (!b_updateFlag)
				{
					ToolTipMain.SetToolTip(cmb_agency_type, cmb_agency_type.Text);
				}
			}
			catch
			{
			}




		}

		private void cmb_business_type_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				string sBusinessType = "";
				sBusinessType = modGlobalVars.cEmptyString;
				string sAccountType = "";
				sAccountType = modGlobalVars.cEmptyString;
				int i = 0;
				i = 0;

				if (!b_updateFlag)
				{

					if (cmb_business_type.Text != modGlobalVars.cEmptyString)
					{

						sBusinessType = cmb_business_type.Text.Substring(Math.Min(0, cmb_business_type.Text.Length), Math.Min(2, Math.Max(0, cmb_business_type.Text.Length))).ToUpper();


						switch(sBusinessType.ToUpper())
						{
							case "RE" : case "DB" : case "MF" : case "DS" : case "FY" : case "LS" : case "FS" : case "PH" : case "PM" : case "PN" : 
								sAccountType = "Dealer Broker";  // "DB" 
								 
								break;
							case "UI" : 
								sAccountType = "Unidentified";  // "UI" 
								 
								break;
							default:
								sAccountType = "End User";  // "EU" 
								 
								break;
						}

						int tempForEndVar = cmb_account_type.Items.Count - 1;
						for (i = 0; i <= tempForEndVar; i++)
						{
							if (cmb_account_type.GetListItem(i).ToUpper() == sAccountType.Trim().ToUpper())
							{
								cmb_account_type.SelectedIndex = i;
							}
						}

					}

					ToolTipMain.SetToolTip(cmb_business_type, cmb_business_type.Text);

				}
			}
			catch
			{
			}




		}

		private void cmb_comp_name_alt_type_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (!b_updateFlag)
				{
					ToolTipMain.SetToolTip(cmb_comp_name_alt_type, cmb_comp_name_alt_type.Text);
				}


				if (Text1[31].Text.Trim() == "")
				{
					if (cmb_comp_name_alt_type.Text.Trim() == "UNID")
					{
						Text1[31].Text = "Unidentified Owner";
					}
					else if (cmb_comp_name_alt_type.Text.Trim() == "UDO")
					{ 
						Text1[31].Text = "Undisclosed Owner";
					}
				}
			}
			catch
			{
			}




		}

		private void cmb_contact_title_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (!b_updateFlag)
				{
					ToolTipMain.SetToolTip(cmb_contact_title, cmb_contact_title.Text);
				}
			}
			catch
			{
			}




		}

		private void cmb_country_code_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (!b_updateFlag)
				{

					ToolTipMain.SetToolTip(cmb_country_code, cmb_country_code.Text);

					if ((cmb_country_code.Text.ToLower() != ("United States").ToLower() && cmb_country_code.Text.ToLower() != ("Canada").ToLower()) || cmb_country_code.Text == modGlobalVars.cEmptyString)
					{

						b_updateFlag = true;

						if (frm_CompanyAdd.DefInstance.state_clicked)
						{
						}
						else
						{
							if (cmb_state_code.Items.Count > 0)
							{
								cmb_state_code.SelectedIndex = 0;
							}
						}
						b_updateFlag = false;

					}
				}
			}
			catch
			{
			}




		}

		private void cmb_country_code_Leave(Object eventSender, EventArgs eventArgs)
		{

			string strText = ($"{cmb_country_code.Text} ").Trim();

			if (strText != "")
			{
				if (!modCommon.IsComboTextInList(cmb_country_code, strText))
				{
					MessageBox.Show($"Company Country Value [{strText}] Is NOT In Pull Down", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					cmb_country_code.Text = "";
					cmb_country_code.Focus();
				}
			}

		}

		private void cmb_language_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (!b_updateFlag)
				{
					ToolTipMain.SetToolTip(cmb_language, cmb_language.Text);
				}
			}
			catch
			{
			}




		}

		private void cmb_phone_type_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmb_phone_type, eventSender);

			try
			{

				if (!b_updateFlag)
				{
					ToolTipMain.SetToolTip(cmb_phone_type[Index], cmb_phone_type[Index].Text);
				}
			}
			catch
			{
			}




		}

		private void cmb_product_code_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				string s_RememberBusinessType = "";
				s_RememberBusinessType = modGlobalVars.cEmptyString;

				if (!b_updateFlag)
				{

					if (cmb_product_code.Text != modGlobalVars.cEmptyString)
					{

						s_RememberBusinessType = cmb_business_type.Text.Substring(Math.Min(0, cmb_business_type.Text.Length), Math.Min(2, Math.Max(0, cmb_business_type.Text.Length))).Trim();

						modFillCompConControls.fill_businesstype_FromArray(cmb_business_type, cmb_product_code);

						if (s_RememberBusinessType != modGlobalVars.cEmptyString)
						{
							int tempForEndVar = cmb_business_type.Items.Count - 1;
							for (int i = 0; i <= tempForEndVar; i++)
							{
								if (cmb_business_type.GetListItem(i).Substring(Math.Min(0, cmb_business_type.GetListItem(i).Length), Math.Min(2, Math.Max(0, cmb_business_type.GetListItem(i).Length))).Trim().ToUpper() == s_RememberBusinessType.Trim().ToUpper())
								{
									cmb_business_type.SelectedIndex = i;
								}
							}
						}

					}

					ToolTipMain.SetToolTip(cmb_product_code, cmb_product_code.Text);

				}
			}
			catch
			{
			}




		}

		private void cmb_sirname_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (!b_updateFlag)
				{
					ToolTipMain.SetToolTip(cmb_sirname, cmb_sirname.Text);
				}
			}
			catch
			{
			}




		}

		private void cmb_sirname_Leave(Object eventSender, EventArgs eventArgs)
		{

			string strText = ($"{cmb_sirname.Text} ").Trim();

			if (strText != "")
			{
				if (!modCommon.IsComboTextInList(cmb_sirname, strText))
				{
					MessageBox.Show($"Contact Salutation Value [{strText}] Is NOT In Pull Down", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					cmb_sirname.Text = "";
					cmb_sirname.Focus();
				}
			}

		}

		private void cmb_state_code_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			try
			{


				if (!b_updateFlag)
				{
					modFillCompConControls.Select_Unknown_Country_By_ID(cmb_state_code, cmb_country_code);
					ToolTipMain.SetToolTip(cmb_state_code, cmb_state_code.Text);
				}
			}
			catch
			{
			}






		}

		private void cmb_suffix_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (!b_updateFlag)
				{
					ToolTipMain.SetToolTip(cmb_suffix, cmb_suffix.Text);
				}
			}
			catch
			{
			}




		}

		//UPGRADE_NOTE: (7001) The following declaration (HighlightIfTooLong) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private int HighlightIfTooLong(Control in_ctrl, Color in_Color)
		//{
			//
			//try
			//{
				//
				//int tmpLength = 0;
				//tmpLength = 0;
				//
				//if (in_Color == ColorTranslator.FromOle(0xB9FFFF))
				//{
					//in_Color = Color.White;
				//}
				//
				//TextBox in_ctrlTyped = null;
				//ComboBox in_ctrlTyped2 = null;
				//if (in_ctrl is TextBox)
				//{
					//in_ctrlTyped = (TextBox) in_ctrl;
					//
					//switch(ControlArrayHelper.GetControlIndex(in_ctrlTyped))
					//{
						//case COMPANY_NAME : case company_address1 : 
							//tmpLength = 36; 
							// 
							//break;
						//case company_address2 : case COMPANY_ALT_NAME : 
							//tmpLength = 0; 
							// 
							//break;
						//case COMPANY_CITY : 
							//tmpLength = 20; 
							// 
							//break;
						//case COMPANY_EMAIL : case contact_email : 
							//tmpLength = 60; 
							// 
							//break;
						//case CONTACT_FIRST : 
							//tmpLength = 12; 
							// 
							//break;
						//case CONTACT_LAST : 
							//tmpLength = 14; 
							// 
							//break;
					//}
					//
				//}
				//else if (in_ctrl is ComboBox)
				//{ 
					//in_ctrlTyped2 = (ComboBox) in_ctrl;
					//
					//
					//switch(in_ctrlTyped2.Name.ToLower())
					//{
						//case "cmb_country_code" : 
							//tmpLength = 20; 
							// 
							//break;
						//case "cmb_sirname" : 
							//tmpLength = 4; 
							// 
							//break;
						//case "cmb_contact_title" : 
							//tmpLength = 24; 
							// 
							//break;
						//case "cmb_comp_name_alt_type" : 
							//tmpLength = 0; 
							// 
							//break;
					//}
				//}
			//}
			//catch
			//{
			//}
			//
			//
			//
			//return 0;
			//
		//}

		private bool FormatInputText(int Index)
		{

			bool result = false;
			try
			{

				string sTmp = "";
				sTmp = modGlobalVars.cEmptyString;
				StringBuilder sTmp1 = new StringBuilder();
				sTmp1 = new StringBuilder(modGlobalVars.cEmptyString);
				int K = 0;
				K = 0;

				result = false;

				if (Text1[Index].Text.Trim() != modGlobalVars.cEmptyString)
				{


					switch(Index)
					{
						case COMPANY_NAME : case COMPANY_ALT_NAME : 
							 
							//allow only one space to separate words 
							sTmp = $"{Text1[Index].Text.Trim()}{modGlobalVars.cSingleSpace}"; 
							K = (sTmp.IndexOf(modGlobalVars.cSingleSpace) + 1); 
							 
							while (K > 0)
							{
								sTmp1.Append($" {sTmp.Substring(Math.Min(0, sTmp.Length), Math.Min(K, Math.Max(0, sTmp.Length))).Trim()}");
								sTmp = $"{sTmp.Substring(Math.Min(K - 1, sTmp.Length)).Trim()}{modGlobalVars.cSingleSpace}";
								K = (sTmp.IndexOf(modGlobalVars.cSingleSpace) + 1);
								if (Strings.Len(sTmp) == 1)
								{
									K = 0;
								}
							} 
							 
							Text1[Index].Text = sTmp1.ToString().Trim(); 
							 
							break;
						case COMPANY_CITY : 
							 
							// take the text from the text box and put in temp string 
							sTmp = $"{Text1[Index].Text.Trim()}{modGlobalVars.cSingleSpace}"; 
							 
							// logic - if in the first gcCITY_FORT_STR characters is there a gcCITY_FORT_STR in here 
							// if so change it to gcCITY_FT_STR 
							 
							if (sTmp.Substring(Math.Min(0, sTmp.Length), Math.Min(Strings.Len(modGlobalVars.gcCITY_FORT_STR), Math.Max(0, sTmp.Length))).ToLower() == modGlobalVars.gcCITY_FORT_STR.ToLower())
							{
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_FORT_STR, modGlobalVars.gcCITY_FT_STR, 1, 1, CompareMethod.Binary);
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_FORT_STR.ToLower(), modGlobalVars.gcCITY_FT_STR, 1, 1, CompareMethod.Binary);
							}
							else if (sTmp.Substring(Math.Min(0, sTmp.Length), Math.Min(Strings.Len(modGlobalVars.gcCITY_MOUNT_STR), Math.Max(0, sTmp.Length))).ToLower() == modGlobalVars.gcCITY_MOUNT_STR.ToLower())
							{ 
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_MOUNT_STR, modGlobalVars.gcCITY_MT_STR, 1, 1, CompareMethod.Binary);
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_MOUNT_STR.ToLower(), modGlobalVars.gcCITY_MT_STR, 1, 1, CompareMethod.Binary);
							}
							else if (sTmp.Substring(Math.Min(0, sTmp.Length), Math.Min(Strings.Len(modGlobalVars.gcCITY_SAINT_STR), Math.Max(0, sTmp.Length))).ToLower() == modGlobalVars.gcCITY_SAINT_STR.ToLower())
							{ 
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_SAINT_STR, modGlobalVars.gcCITY_ST_STR, 1, 1, CompareMethod.Binary);
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_SAINT_STR.ToLower(), modGlobalVars.gcCITY_ST_STR, 1, 1, CompareMethod.Binary);
							}
							else if (sTmp.Substring(Math.Min(0, sTmp.Length), Math.Min(Strings.Len(modGlobalVars.gcCITY_SAINTE_STR), Math.Max(0, sTmp.Length))).ToLower() == modGlobalVars.gcCITY_SAINTE_STR.ToLower())
							{ 
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_SAINTE_STR, modGlobalVars.gcCITY_ST_STR, 1, 1, CompareMethod.Binary);
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_SAINTE_STR.ToLower(), modGlobalVars.gcCITY_ST_STR, 1, 1, CompareMethod.Binary);
							}
							else if (sTmp.Substring(Math.Min(0, sTmp.Length), Math.Min(Strings.Len(modGlobalVars.gcCITY_FORT_STR_SHORT), Math.Max(0, sTmp.Length))).ToLower() == modGlobalVars.gcCITY_FORT_STR_SHORT.ToLower())
							{ 
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_FORT_STR_SHORT, modGlobalVars.gcCITY_FT_STR, 1, 1, CompareMethod.Binary);
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_FORT_STR_SHORT.ToLower(), modGlobalVars.gcCITY_FT_STR, 1, 1, CompareMethod.Binary);
							}
							else if (sTmp.Substring(Math.Min(0, sTmp.Length), Math.Min(Strings.Len(modGlobalVars.gcCITY_MOUNT_STR_SHORT), Math.Max(0, sTmp.Length))).ToLower() == modGlobalVars.gcCITY_MOUNT_STR_SHORT.ToLower())
							{ 
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_MOUNT_STR_SHORT, modGlobalVars.gcCITY_MT_STR, 1, 1, CompareMethod.Binary);
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_MOUNT_STR_SHORT.ToLower(), modGlobalVars.gcCITY_MT_STR, 1, 1, CompareMethod.Binary);
							}
							else if (sTmp.Substring(Math.Min(0, sTmp.Length), Math.Min(Strings.Len(modGlobalVars.gcCITY_SAINT_STR_SHORT), Math.Max(0, sTmp.Length))).ToLower() == modGlobalVars.gcCITY_SAINT_STR_SHORT.ToLower())
							{ 
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_SAINT_STR_SHORT, modGlobalVars.gcCITY_ST_STR, 1, 1, CompareMethod.Binary);
								sTmp = StringsHelper.Replace(sTmp, modGlobalVars.gcCITY_SAINT_STR_SHORT.ToLower(), modGlobalVars.gcCITY_ST_STR, 1, 1, CompareMethod.Binary);
							} 
							 
							Text1[Index].Text = sTmp.Trim(); 
							 
							break;
					}

				}


				switch(Index)
				{
					case COMPANY_NAME : 
						 
						if (Text1[Index].Text.Trim() != modGlobalVars.cEmptyString)
						{
							if (chk_auto_account_rep.CheckState == CheckState.Checked)
							{
								modFillCompConControls.assign_account_rep(Text1[Index].Text, cmb_account_type, cmb_account_id);
							}
						}
						else
						{
							cmb_account_id.SelectedIndex = -1;
						} 
						 
						break;
				}

				result = true;
			}
			catch
			{
			}



			return result;

		}

		private void cmb_suffix_Leave(Object eventSender, EventArgs eventArgs)
		{

			string strText = ($"{cmb_suffix.Text} ").Trim();

			if (strText != "")
			{
				if (!modCommon.IsComboTextInList(cmb_suffix, strText))
				{
					MessageBox.Show($"Contact Suffix Value [{strText}] Is NOT In Pull Down", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					cmb_suffix.Text = "";
					cmb_suffix.Focus();
				}
			}

		}

		private void cmd_copy_company_Click(Object eventSender, EventArgs eventArgs)
		{


			//re-done section
			Text1[0].Text = "";
			cmb_account_id.SelectedIndex = 0;

			if (ca_company_address1.Trim() != "")
			{

				Text1[1].Text = modGlobalVars.new_frm_CompanyAdd.ca_company_address1;
				Text1[2].Text = modGlobalVars.new_frm_CompanyAdd.ca_company_address2;
				Text1[4].Text = modGlobalVars.new_frm_CompanyAdd.ca_comp_zip;
				Text1[27].Text = modGlobalVars.new_frm_CompanyAdd.ca_comp_email;
				Text1[3].Text = modGlobalVars.new_frm_CompanyAdd.ca_comp_city;


				cmb_agency_type.Text = modGlobalVars.new_frm_CompanyAdd.ca_comp_agency;
				cmb_account_id.Text = modGlobalVars.new_frm_CompanyAdd.ca_comp_account_rep;
				cmb_language.Text = modGlobalVars.new_frm_CompanyAdd.ca_comp_language;
				cmb_state_code.SelectedIndex = Convert.ToInt32(Double.Parse(modGlobalVars.new_frm_CompanyAdd.ca_comp_state));
				cmb_country_code.SelectedIndex = Convert.ToInt32(Double.Parse(modGlobalVars.new_frm_CompanyAdd.ca_comp_country));
				cmb_product_code.SelectedIndex = Convert.ToInt32(Double.Parse(modGlobalVars.new_frm_CompanyAdd.ca_comp_product));
				cmb_account_type.Text = modGlobalVars.new_frm_CompanyAdd.ca_comp_account_type;

				if (cmb_business_type.Items.Count > 0)
				{

					int tempForEndVar = cmb_business_type.Items.Count;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						cmb_business_type.SelectedIndex = i;
						if (cmb_business_type.Text.StartsWith(modGlobalVars.new_frm_CompanyAdd.ca_comp_business_type.Substring(0, Math.Min(3, modGlobalVars.new_frm_CompanyAdd.ca_comp_business_type.Length)), StringComparison.Ordinal))
						{
							break;
						}
					}

				}
			}


			cmd_CompanyAction[0].Enabled = true;

		}

		private void Text1_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.Text1, eventSender);

			try
			{

				if (!FormatInputText(Index))
				{
					return;
				}
			}
			catch
			{
			}




		}

		private bool set_lbl_error(Label in_label, bool bIsError)
		{
			bool result = false;
			try
			{

				if (bIsError)
				{
					in_label.Font = in_label.Font.Change(bold:true);
				}
				else
				{
					in_label.Font = in_label.Font.Change(bold:false);
				}

				result = true;
			}
			catch
			{
			}



			return result;

		}

		private void cmd_CompanyAction_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_CompanyAction, eventSender);

			try
			{

				int x = 0;
				x = 0;
				bool bValidCo = false;
				bValidCo = true;
				bool bHavePhoneNumber = false;
				bHavePhoneNumber = false;
				string strMsg = "";
				System.DateTime dtStartDate = DateTime.FromOADate(0);
				System.DateTime dtEndDate = DateTime.FromOADate(0);
				int lCompId = 0;
				int lContactId = 0;
				string temp_subject = "";
				string temp_desc = "";






				switch(Index)
				{
					case 0 :  // add company 

						 
						bool tempRefParam = true; 
						if (modCommon.Is_Phone_Number_Field_Visible_Non_Numeric($"{Text1[5].Text}{Text1[6].Text}{Text1[7].Text}{Text1[8].Text}"))
						{
							MessageBox.Show("Company Phone Number is not numeric, please fix before saving!", "Company : Save Company Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else if (modCommon.Is_Phone_Number_Field_Visible_Non_Numeric($"{Text1[9].Text}{Text1[10].Text}{Text1[11].Text}{Text1[12].Text}"))
						{ 
							MessageBox.Show("Company Phone Number is not numeric, please fix before saving!", "Company : Save Company Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else if (modCommon.Is_Phone_Number_Field_Visible_Non_Numeric($"{Text1[13].Text}{Text1[14].Text}{Text1[15].Text}{Text1[16].Text}"))
						{ 
							MessageBox.Show("Contact Phone Number is not numeric, please fix before saving!", "Company : Save Company Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else if (modCommon.Is_Phone_Number_Field_Visible_Non_Numeric($"{Text1[17].Text}{Text1[18].Text}{Text1[19].Text}{Text1[20].Text}"))
						{ 
							MessageBox.Show("Contact Phone Number is not numeric, please fix before saving!", "Company : Save Company Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

							// added MSW - 3/5/24 - per task
						}
						else if (cmb_business_type.Text.Trim() == "")
						{ 
							MessageBox.Show("Business Type Cannot Be Blank, please fix before saving!", "Company : Save Company Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else if (Text1[0].Text.Trim() == "")
						{ 
							MessageBox.Show("Company Name Cannot Be Blank, please fix before saving!", "Company : Save Company Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else if (!check_blanks(ref tempRefParam))
						{ 
							// popups occur seperately
						}
						else
						{

							// make sure you clean all of the invisible or leftover characters
							for (int i = 5; i <= 20; i++)
							{
								Text1[i].Text = modCommon.RemoveNonNumbers(Text1[i].Text).Trim();
							}

							// If InStr(LOCAL_ADO_DB, "jetnet_ra_test") > 0 And gbl_User_ID = "mvit" And gbl_User_ID = "DONT GO" Then    '    so for now it doesnt go in
							if (modAdminCommon.LOCAL_ADO_DB.ConnectionString.IndexOf("jetnet_ra_test") >= 0)
							{ //    will go on test every time now

								run_company_add_sp();


								lCompId = GetNextCompanyID();
								lCompId--;
								Text1[COMPANY_ID].Text = lCompId.ToString();
								Text1[COMPANY_ID].Enabled = false;

								run_sp_phone_numbers_company(lCompId);


								// 11/2/23 - MSW --
								if (Text1[CONTACT_FIRST].Text.Trim() != "" && Text1[CONTACT_LAST].Text.Trim() != "")
								{
									// NOT FULLY DONE YET
									if (Text1[16].Text.Trim() != "" || Text1[20].Text.Trim() != "")
									{
										run_contact_add_sp(lCompId, "Y");
									}
									else
									{
										run_contact_add_sp(lCompId, "N");
									}

									lContactId = GetNextContactID();
									lContactId--;
									lContactId = lContactId;
									Text1[contact_id].Text = lContactId.ToString();
									Text1[contact_id].Enabled = false;

									run_sp_phone_numbers_contact(lCompId, lContactId);
								}
								else
								{
									// THERE IS NO CONTACT RECORD
								}

								// add journal note - 11/22/23 - MSW
								if (Text1[JOURNAL_SUBJECT].Text != modGlobalVars.cEmptyString)
								{ // Check first Name
									if (!Quick_Insert_Research_Note(lCompId, lContactId))
									{
										modAdminCommon.ADO_Transaction("RollbackTrans");
										MessageBox.Show("Error Saving Research Note", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
										return;
									}
								}



								modAdminCommon.ADO_Transaction("CommitTrans");

								cmd_CompanyAction[0].Enabled = false;
								lbl_status_display.Text = "Adding New Company, Completed...";
								lbl_status_display.Refresh();

							}
							else
							{
								// moved into function - MSW - 3/5/24
								check_blanks(ref bValidCo);



								for (x = COMPANY_PCONTRY1; x <= COMPANY_PNUMBER1; x++)
								{

									if (Text1[x].Text != modGlobalVars.cEmptyString)
									{
										bHavePhoneNumber = true;
										break;
									}

								}

								if (cmb_phone_type[COMPANY_PTYPE1].Text == modGlobalVars.cEmptyString && bHavePhoneNumber)
								{
									MessageBox.Show("Company Phone Type1 is blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
									set_lbl_error(Label1[LBL_COMPANY_PTYPE1], true);
									bValidCo = false;
								}
								else
								{
									set_lbl_error(Label1[LBL_COMPANY_PTYPE1], false);
								}

								bHavePhoneNumber = false;

								for (x = COMPANY_PCONTRY2; x <= COMPANY_PNUMBER2; x++)
								{

									if (Text1[x].Text != modGlobalVars.cEmptyString)
									{
										bHavePhoneNumber = true;
										break;
									}

								}

								if (cmb_phone_type[COMPANY_PTYPE2].Text == modGlobalVars.cEmptyString && bHavePhoneNumber)
								{
									MessageBox.Show("Company Phone Type2 is blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
									set_lbl_error(Label1[LBL_COMPANY_PTYPE2], true);
									bValidCo = false;
								}
								else
								{
									set_lbl_error(Label1[LBL_COMPANY_PTYPE2], false);
								}

								// Check for Contact Info if there is check phone number(s)
								if (Text1[CONTACT_FIRST].Text != modGlobalVars.cEmptyString)
								{ // Check first Name
									if (Text1[CONTACT_LAST].Text != modGlobalVars.cEmptyString)
									{ // Check last Name

										bHavePhoneNumber = false;

										for (x = CONTACT_PCONTRY1; x <= CONTACT_PNUMBER1; x++)
										{

											if (Text1[x].Text != modGlobalVars.cEmptyString)
											{
												bHavePhoneNumber = true;
												break;
											}

										}

										if (cmb_phone_type[CONTACT_PTYPE1].Text == modGlobalVars.cEmptyString && bHavePhoneNumber)
										{
											MessageBox.Show("Contact Phone Type1 is blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
											set_lbl_error(Label1[LBL_CONTACT_PTYPE1], true);
											bValidCo = false;
										}
										else
										{
											set_lbl_error(Label1[LBL_CONTACT_PTYPE1], false);
										}

										bHavePhoneNumber = false;

										for (x = CONTACT_PCONTRY2; x <= CONTACT_PNUMBER2; x++)
										{

											if (Text1[x].Text != modGlobalVars.cEmptyString)
											{
												bHavePhoneNumber = true;
												break;
											}

										}

										if (cmb_phone_type[CONTACT_PTYPE2].Text == modGlobalVars.cEmptyString && bHavePhoneNumber)
										{
											MessageBox.Show("Contact Phone Type2 is blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
											set_lbl_error(Label1[LBL_CONTACT_PTYPE2], true);
											bValidCo = false;
										}
										else
										{
											set_lbl_error(Label1[LBL_CONTACT_PTYPE2], false);
										}

									}
								}

								// 08/28/2007 - By David D. Cruger
								// ONLY If Internal Notes are Entered MUST there be a Journal Subject
								if (Text1[JOURNAL_INTERNAL_NOTES].Text != modGlobalVars.cEmptyString)
								{ // Subject MUST be filled In

									if (Text1[JOURNAL_SUBJECT].Text == modGlobalVars.cEmptyString)
									{ // journal subject
										MessageBox.Show("Journal Subject is blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
										set_lbl_error(Label1[LBL_JOURNAL_SUBJECT], true);
										bValidCo = false;
									}
									else
									{
										set_lbl_error(Label1[LBL_JOURNAL_SUBJECT], false);
									}

								}
								else
								{
									set_lbl_error(Label1[LBL_JOURNAL_SUBJECT], false);
								}

								if (bValidCo)
								{

									Quick_Insert_Company();
									// cmd_CompanyAction.Item(0).Visible = False  ' TEMP HOLD MSW ADD IN

									if (Text1[COMPANY_ID].Text != "" && Text1[COMPANY_ID].Text != "0")
									{

										cmd_CompanyAction[0].Enabled = false;

										lCompId = Convert.ToInt32(Double.Parse(Text1[COMPANY_ID].Text));
										lContactId = 0;
										if (Information.IsNumeric(Text1[contact_id].Text))
										{
											lContactId = Convert.ToInt32(Double.Parse(Text1[contact_id].Text));
										}



										// added MSW - 9/24/2021
										if (lCompId > 0)
										{
											if (chk_hide_company.CheckState == CheckState.Checked)
											{ // added MSW - 9/28/23
												// then do not add the events
											}
											else
											{
												temp_subject = "New Company Added";
												temp_desc = $"{modAdminCommon.Fix_Quote(Text1[COMPANY_NAME].Text).Trim()}";
												modCommon.InsertPriorityEvent("NCA", 0, 0, temp_desc, lCompId, lContactId, "N");

												temp_subject = "Company Business Type Added";
												temp_desc = $"{cmb_business_type.Text}";
												modCommon.InsertPriorityEvent("CBTA", 0, 0, temp_desc, lCompId, 0, "N"); // MSW - removed contact id - never related to business type - lContactId

												if (Text1[1].Text.Trim() != "")
												{ // company address added
													temp_desc = Text1[1].Text;
													modCommon.InsertPriorityEvent("CAA", 0, 0, temp_desc, lCompId, 0, "N");
												}

											}
										}



										modCommon.Start_Activity_Monitor_Message("Company Added", ref strMsg, ref dtStartDate, ref dtEndDate);
										strMsg = $" - {Text1[COMPANY_NAME].Text}";
										modCommon.End_Activity_Monitor_Message("Company Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, lCompId, 0, 0);

										if (Text1[CONTACT_FIRST].Text != "" || Text1[CONTACT_LAST].Text != "")
										{
											modCommon.Start_Activity_Monitor_Message("Contact Added", ref strMsg, ref dtStartDate, ref dtEndDate);
											strMsg = $" - {Text1[CONTACT_FIRST].Text} {Text1[CONTACT_LAST].Text}";
											modCommon.End_Activity_Monitor_Message("Contact Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, lCompId, 0, lContactId);
										}

										if (Text1[COMPANY_WEBSITE].Text != "")
										{ // WebSite
											modCommon.Start_Activity_Monitor_Message("Company WebSite Added", ref strMsg, ref dtStartDate, ref dtEndDate);
											strMsg = $" - {Text1[COMPANY_WEBSITE].Text}";
											modCommon.End_Activity_Monitor_Message("Company WebSite Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, lCompId, 0, 0);
										}

										if (Text1[COMPANY_EMAIL].Text != "")
										{ // Company EMail
											modCommon.Start_Activity_Monitor_Message("Company EMail Added", ref strMsg, ref dtStartDate, ref dtEndDate);
											strMsg = $" - {Text1[COMPANY_EMAIL].Text}";
											modCommon.End_Activity_Monitor_Message("Company EMail Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, lCompId, 0, 0);
										}

										if (Text1[contact_email].Text != "")
										{ // Contact EMail
											modCommon.Start_Activity_Monitor_Message("Contact EMail Added", ref strMsg, ref dtStartDate, ref dtEndDate);
											strMsg = $" - {Text1[contact_email].Text}";
											modCommon.End_Activity_Monitor_Message("Contact EMail Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, lCompId, 0, lContactId);
										}

									} // If Text1(COMPANY_ID).Text <> "" And Text1(COMPANY_ID).Text <> "0" Then

								} // If bValidCo = True Then


							}

						} 

						 
						break;
					case 1 :  // clear form 
						 
						for (x = 0; x <= 33; x++)
						{
							Text1[x].Text = modGlobalVars.cEmptyString;
							Text1[x].BackColor = Color.White;
						} 
						 
						for (x = 0; x <= 52; x++)
						{
							if (x != 34 && x != 33 && x != 49)
							{
								set_lbl_error(Label1[x], false);
							}
						} 
						 
						cmb_country_code.SelectedIndex = -1; 
						cmb_country_code.BackColor = Color.White; 
						 
						cmb_comp_name_alt_type.SelectedIndex = -1; 
						cmb_comp_name_alt_type.BackColor = Color.White; 
						 
						cmb_state_code.SelectedIndex = -1; 
						cmb_agency_type.SelectedIndex = -1; 
						cmb_product_code.SelectedIndex = -1; 
						cmb_business_type.SelectedIndex = -1; 
						cmb_language.SelectedIndex = -1; 
						cmb_account_type.SelectedIndex = -1; 
						cmb_account_id.SelectedIndex = -1; 
						cmb_sirname.SelectedIndex = -1; 
						cmb_suffix.SelectedIndex = -1; 
						cmb_suffix.BackColor = Color.White; 
						 
						cmb_contact_title.SelectedIndex = -1; 
						cmb_contact_title.BackColor = Color.White; 
						 
						for (x = 0; x <= 3; x++)
						{
							cmb_phone_type[x].SelectedIndex = -1;
						} 
						 
						chk_auto_account_rep.CheckState = CheckState.Checked; 
						chkCompContactAddressFlag.CheckState = CheckState.Unchecked; 
						chk_hide_from_customer.CheckState = CheckState.Unchecked; 
						chk_attach_to_contact.CheckState = CheckState.Unchecked; 
						 
						b_AutoAssignFlag = true; 
						 
						break;
					case 2 :  // exit form 
						this.Close(); 
						 
						break;
					default:
						this.Refresh(); 
						 
						break;
				}
			}
			catch
			{
			}




		}

		public void run_company_add_sp()
		{

			string temp_Comp_name = "";
			string Current_Account_Type = "";
			string tupdate = "";
			// tupdate = " exec sp_UpdateCompany "
			tupdate = " exec sp_AddCompany ";


			temp_Comp_name = modCompany.strip_spaces_from_companyname(modAdminCommon.Fix_Quote(Text1[COMPANY_NAME].Text).Trim());

			tupdate = $"{tupdate}{build_sp_string("@inName", modAdminCommon.Fix_Quote(Text1[COMPANY_NAME].Text).Trim())}";
			tupdate = $"{tupdate}{build_sp_string("@inAddress1", modAdminCommon.Fix_Quote(Text1[company_address1].Text).Trim())}";
			tupdate = $"{tupdate}{build_sp_string("@inAddress2", modAdminCommon.Fix_Quote(Text1[company_address2].Text).Trim())}";
			tupdate = $"{tupdate}{build_sp_string("@inCity", modAdminCommon.Fix_Quote(Text1[COMPANY_CITY].Text).Trim())}";


			string temp_state = "";
			if (cmb_state_code.Text.Trim().ToUpper() != modGlobalVars.cEmptyString)
			{
				temp_state = cmb_state_code.Text.ToUpper().Substring(0, Math.Min(3, cmb_state_code.Text.ToUpper().Length)).Trim();
				temp_state = StringsHelper.Replace(temp_state, ",", "", 1, -1, CompareMethod.Binary);
				tupdate = $"{tupdate}{build_sp_string("@inState", temp_state)}"; // changed to 3 - msw - 12/6/23
			}
			else
			{
				tupdate = $"{tupdate}{build_sp_string("@inState", "")}";
			}


			tupdate = $"{tupdate}{build_sp_string("@inPostalCode", Text1[COMPANY_POSTALCODE].Text.Trim())}";
			tupdate = $"{tupdate}{build_sp_string("@inCountry", modAdminCommon.Fix_Quote(cmb_country_code.Text).Trim())}";


			tupdate = $"{tupdate}{build_sp_string("@inWebAddress", Text1[26].Text)}";
			tupdate = $"{tupdate}{build_sp_string("@inEmailAddress", modAdminCommon.Fix_Quote(Text1[COMPANY_EMAIL].Text).Trim())}";
			tupdate = $"{tupdate}{build_sp_string("@inUserID", modAdminCommon.gbl_User_ID)}";



			if (cmb_product_code.Text.Trim() != modGlobalVars.cEmptyString)
			{
				switch((cmb_product_code.Text.Substring(0, Math.Min(1, cmb_product_code.Text.Length))))
				{
					case "B" : 
						tupdate = $"{tupdate}{build_sp_string("@inBusinessFlag", "Y")}"; 
						tupdate = $"{tupdate}{build_sp_string("@inHelicopterFlag", "N")}"; 
						tupdate = $"{tupdate}{build_sp_string("@inCommercialFlag", "N")}"; 
						break;
					case "H" : 
						tupdate = $"{tupdate}{build_sp_string("@inBusinessFlag", "N")}"; 
						tupdate = $"{tupdate}{build_sp_string("@inHelicopterFlag", "Y")}"; 
						tupdate = $"{tupdate}{build_sp_string("@inCommercialFlag", "N")}"; 
						break;
					case "C" : 
						tupdate = $"{tupdate}{build_sp_string("@inBusinessFlag", "N")}"; 
						tupdate = $"{tupdate}{build_sp_string("@inHelicopterFlag", "N")}"; 
						tupdate = $"{tupdate}{build_sp_string("@inCommercialFlag", "Y")}"; 
						break;
					case "R" : case "A" : case "P" : case "Y" : 
						tupdate = $"{tupdate}{build_sp_string("@inBusinessFlag", "N")}"; 
						tupdate = $"{tupdate}{build_sp_string("@inHelicopterFlag", "N")}"; 
						tupdate = $"{tupdate}{build_sp_string("@inCommercialFlag", "N")}"; 
						break;
					default:
						tupdate = $"{tupdate}{build_sp_string("@inBusinessFlag", "Y")}"; 
						tupdate = $"{tupdate}{build_sp_string("@inHelicopterFlag", "N")}"; 
						tupdate = $"{tupdate}{build_sp_string("@inCommercialFlag", "N")}"; 
						break;
				}
			}
			else
			{
				tupdate = $"{tupdate}{build_sp_string("@inBusinessFlag", "Y")}";
				tupdate = $"{tupdate}{build_sp_string("@inHelicopterFlag", "N")}";
				tupdate = $"{tupdate}{build_sp_string("@inCommercialFlag", "N")}";
			}



			// added MSW - 11/15/23
			tupdate = $"{tupdate}{build_sp_string("@inLanguage", cmb_language.Text)}";

			tupdate = $"{tupdate}{build_sp_string("@inActiveFlag", "Y")}";

			// added MSW - 9/28/23
			if (chk_hide_company.CheckState == CheckState.Checked)
			{
				tupdate = $"{tupdate}{build_sp_string("@inHideFlag", "Y")}";
			}
			else
			{
				tupdate = $"{tupdate}{build_sp_string("@inHideFlag", "N")}";
			}

			tupdate = $"{tupdate}{build_sp_string("@inAgencyType", cmb_agency_type.Text.Substring(Math.Min(0, cmb_agency_type.Text.Length), Math.Min(1, Math.Max(0, cmb_agency_type.Text.Length))).Trim())}";


			if (chk_auto_account_rep.CheckState == CheckState.Checked)
			{
				tupdate = $"{tupdate}{build_sp_string("@inManualAccountFlag", "N")}";
			}
			else
			{
				tupdate = $"{tupdate}{build_sp_string("@inManualAccountFlag", "Y")}"; // not checked "auto assign"
			}


			if (cmb_account_type.Text.Trim() != modGlobalVars.cEmptyString)
			{
				switch(cmb_account_type.Text.Trim())
				{
					case "End User" : 
						Current_Account_Type = "EU"; 
						break;
					case "Dealer Broker" : 
						Current_Account_Type = "DB"; 
						break;
					case "Unidentified" : 
						Current_Account_Type = "UI"; 
						break;
					case "Fractional Owner" : 
						Current_Account_Type = "FO"; 
						break;
					case "Non-Aviation" : 
						Current_Account_Type = "NA"; 
						break;
					default:
						Current_Account_Type = "null"; 
						break;
				}

				tupdate = $"{tupdate}{build_sp_string("@inAccountType", Current_Account_Type)}";
			}
			else
			{
				tupdate = $"{tupdate}{build_sp_string("@inAccountType", "")}";
			}


			tupdate = $"{tupdate}{build_sp_string("@inAccountRep", cmb_account_id.Text.Trim())}";
			tupdate = $"{tupdate}{build_sp_string("@inAltName", modAdminCommon.Fix_Quote(cmb_comp_name_alt_type.Text).Trim())}";
			tupdate = $"{tupdate}{build_sp_string("@inAltType", cmb_comp_name_alt_type.Text)}";
			tupdate = $"{tupdate}{build_sp_string("@inPrimaryBusinessType", cmb_business_type.Text)}";
			tupdate = $"{tupdate}{build_sp_string("@inBusinessTypeList", "")}";
			tupdate = $"{tupdate}{build_sp_string("@inDescription", "")}"; // dont see it available

			// leave this one for last, so it goes in without a comma
			tupdate = $"{tupdate}{build_sp_string("@inSource", "Homebase")}";
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


		public void run_contact_add_sp(int comp_id, string contact_has_phone)
		{

			int in_CompanyID = 0;
			string IQuery = "";
			string temp_Comp_name = "";
			string Current_Account_Type = "";
			string tupdate = "";
			// tupdate = " exec sp_UpdateCompany "

			// should get the comp for the company we just added ... plus 1


			tupdate = " exec sp_AddContact ";



			tupdate = $"{tupdate}{build_sp_string("@inCompID", comp_id.ToString())}";
			tupdate = $"{tupdate}{build_sp_string("@inSurname", modAdminCommon.Fix_Quote(cmb_sirname.Text).Trim())}";
			tupdate = $"{tupdate}{build_sp_string("@inFirstName", modAdminCommon.Fix_Quote(Text1[CONTACT_FIRST].Text).Trim())}";
			tupdate = $"{tupdate}{build_sp_string("@inMiddleInitial", modAdminCommon.Fix_Quote(Text1[CONTACT_MIDDLE].Text).Trim())}";
			tupdate = $"{tupdate}{build_sp_string("@inLastName", modAdminCommon.Fix_Quote(Text1[CONTACT_LAST].Text).Trim())}";

			tupdate = $"{tupdate}{build_sp_string("@inSuffix", modAdminCommon.Fix_Quote(cmb_suffix.Text).Trim())}";

			if (cmb_contact_title.Text.Trim() != modGlobalVars.cEmptyString)
			{
				tupdate = $"{tupdate}{build_sp_string("@inTitle", modAdminCommon.Fix_Quote(cmb_contact_title.Text).Trim())}";
			}
			else
			{
				tupdate = $"{tupdate}{build_sp_string("@inTitle", "")}";
			}

			if (Text1[contact_email].Text != modGlobalVars.cEmptyString)
			{
				tupdate = $"{tupdate}{build_sp_string("@inEmailAddress", modAdminCommon.Fix_Quote(Text1[contact_email].Text).Trim())}";
			}
			else
			{
				tupdate = $"{tupdate}{build_sp_string("@inEmailAddress", "")}";
			}

			tupdate = $"{tupdate}{build_sp_string("@inUserID", modAdminCommon.gbl_User_ID)}";

			if (chk_hide_from_customer.CheckState == CheckState.Checked)
			{ // contact_hide_flag
				tupdate = $"{tupdate}{build_sp_string("@inHideFlag", "Y")}";
			}
			else
			{
				tupdate = $"{tupdate}{build_sp_string("@inHideFlag", "N")}";
			}

			if (contact_has_phone.Trim() == "Y")
			{
				tupdate = $"{tupdate}{build_sp_string("@inHasPhone", "Y")}";
			}
			else
			{
				tupdate = $"{tupdate}{build_sp_string("@inHasPhone", "N")}";
			}


			tupdate = $"{tupdate}{build_sp_string("@inDescription", "")}";
			// leave this one for last, so it goes in without a comma
			tupdate = $"{tupdate}{build_sp_string("@inSource", "HB")}";
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

		public string build_sp_string(string string_field_name, string string_field_value)
		{

			string result = "";
			result = $"{string_field_name} = '{modAdminCommon.Fix_Quote(modCommon.CleanSpecial(string_field_value)).Trim()}'";

			// leave source last
			if (string_field_name.Trim() != "@inSource")
			{
				result = $"{result},";
			}

			return result;
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				try
				{

					// activate
					this.BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes
					this.Activate();
					if (!bFormLoaded)
					{
						modCommon.CenterFormOnHomebaseMainForm(this);
					}

					Text1[COMPANY_ID].Enabled = false; // Company ID
					Text1[contact_id].Enabled = false; // Contact ID
					Text1[Journal_ID].Enabled = false; // Journal ID
					state_clicked = false;

					bFormLoaded = true;
				}
				catch
				{
				}



				return;

			}
		}

		private void Form_Initialize()
		{
			// init
			try
			{

				n_nextCompanyID = 0;
				n_nextContactID = 0;
				b_updateFlag = false;
				b_AutoAssignFlag = true;
			}
			catch
			{
			}




		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			try
			{

				int x = 0;
				x = 0;

				// load
				b_updateFlag = true;
				bFormLoaded = false;

				modFillCompConControls.fill_agencytype_FromArray(cmb_agency_type);
				modFillCompConControls.fill_product_Codes(cmb_product_code);


				modFillCompConControls.fill_country_FromArray(cmb_country_code);
				//Call modFillCompConControls.fill_state_FromArray(cmb_state_code, False, False, True)
				modFillCompConControls.fill_state_FromArray_With_ID(cmb_state_code, false, false, true);
				modFillCompConControls.Fill_Language_FromArray(cmb_language);
				modFillCompConControls.fill_accounttype_FromArray(cmb_account_type);
				modFillCompConControls.Fill_AccountRep_FromArray(cmb_account_id, false, false);
				modFillCompConControls.fill_contactsirname_FromArray(cmb_sirname);
				modFillCompConControls.fill_contactsuffix_FromArray(cmb_suffix);
				modFillCompConControls.Fill_Contact_Title(cmb_contact_title);


				// COULD NOT FIND WHERE THIS IS INITIALLY BEING ADDED
				if (cmb_comp_name_alt_type.Items.Count < 4)
				{
					cmb_comp_name_alt_type.AddItem("AKA");
					cmb_comp_name_alt_type.AddItem("UNID");
					cmb_comp_name_alt_type.AddItem("UDO");
				}

				for (x = 0; x <= 3; x++)
				{
					modFillCompConControls.fill_phonetype_FromArray(cmb_phone_type[x]);
				}

				if (b_AutoAssignFlag)
				{
					chk_auto_account_rep.CheckState = CheckState.Checked;
				}

				b_updateFlag = false;
			}
			catch
			{
			}




		}

		private void Form_Terminate()
		{
			// terminate
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1069
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				// unload
				n_nextCompanyID = 0;
				n_nextContactID = 0;
				b_updateFlag = false;
				b_AutoAssignFlag = true;
			}
			catch
			{
			}



			return;

		}

		// 08/20/2019 - By David D. Cruger; Not Using this routine.  No Unverified Record will be added.
		public bool Quick_Insert_Company_Services_Used_Record(int lCompId)
		{

			bool result = false;
			string strDelete1 = "";
			string strInsert1 = "";

			bool bResults = false;

			try
			{

				bResults = false;

				strDelete1 = $"DELETE FROM Company_Services_Used WHERE (csu_comp_id = {lCompId.ToString()}) ";

				// Just To Make Sure Nothing Is Already There
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strDelete1;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				// Insert Type 34 = 'U' - Unverified
				strInsert1 = "INSERT INTO Company_Services_Used (csu_comp_id, csu_journ_id, csu_svud_id, csu_user_id)";
				strInsert1 = $"{strInsert1} VALUES ({lCompId.ToString()}, 0, 34, '{modAdminCommon.gbl_User_ID}') ";

				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = strInsert1;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lbl_status_display.Text = $"Adding New Company Services Used Info Error ** {Information.Err().Number.ToString()} {excep.Message}";
				lbl_status_display.Refresh();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Quick_Insert_Company_Services_Used_Record_Error: {Information.Err().Number.ToString()} {excep.Message}", "Add Company");

				result = false;
			}
			return result;
		} // Quick_Insert_Company_Services_Used_Record

		public void Quick_Insert_Company()
		{

			// LAST UPDATE - 12/27/2010 - RTW - MODIFIED TO REMOVE REFERENCE TO OLD PRODUCT CODE TABLE

			string Query = modGlobalVars.cEmptyString;
			ADORecordSetHelper snpHistRecInfo = new ADORecordSetHelper();
			string sMsg = modGlobalVars.cEmptyString;
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			DialogResult nResponse = (DialogResult) 0;
			bool bNeedHistory = false;
			string Current_Account_Type = modGlobalVars.cEmptyString;
			bool inDeleteLog = false;
			int DeleteCheckCount = 0;
			string strAVDataId = "";
			string temp_query = "";
			string strDelete1 = "";
			string strInsert1 = "";

			string[] l_tempAry = null;

			try
			{

				strAVDataId = modCommon.CreateNewAVDataId();

				modAdminCommon.ADO_Transaction("BeginTrans");

				// Per Vin 5-10-2002
				// Don't allow users to enter duplicate companies
				lbl_status_display.Text = "Check For Duplicate Company...";
				lbl_status_display.Refresh();

				//check to see if company aleady exists as current (active) (not historical)

				temp_query = $"SELECT * FROM Company WHERE comp_name_search = '{modCommon.LeaveOnlyAlphaAndNumeric(Text1[COMPANY_NAME].Text).ToUpper()}' AND comp_address1_search = '{modCommon.LeaveOnlyAlphaAndNumeric(Text1[company_address1].Text).ToUpper()}' AND comp_city = '{modAdminCommon.Fix_Quote(Text1[COMPANY_CITY].Text)}' AND comp_country = '{modAdminCommon.Fix_Quote(cmb_country_code.Text)}' AND comp_journ_id = 0";

				if (cmb_state_code.Text.Trim() != "")
				{
					temp_query = $"{temp_query} AND comp_state = '{cmb_state_code.Text.Substring(Math.Min(0, cmb_state_code.Text.Length), Math.Min(cmb_state_code.Text.IndexOf(", "), Math.Max(0, cmb_state_code.Text.Length)))}'";
				}
				else
				{
					temp_query = $"{temp_query} AND comp_state = '' ";
				}


				if (modAdminCommon.Exist(temp_query))
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
					MessageBox.Show($"A Company with the Same Name, Address, City, State, and Country Already Exists.{Environment.NewLine}Company has NOT been added.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}
				else
				{
					bNeedHistory = true;
				}

				if (bNeedHistory)
				{
					lbl_status_display.Text = "Check For Company in History...";
					lbl_status_display.Refresh();

					//if the company doesn't exist as current, check to see if historical records are present.
					Query = $"SELECT * FROM Company WITH(NOLOCK) WHERE comp_name = '{modAdminCommon.Fix_Quote(Text1[COMPANY_NAME])}'";
					Query = $"{Query} AND comp_city = '{modAdminCommon.Fix_Quote(Text1[COMPANY_CITY])}'";

					if (cmb_state_code.Text.Trim() != "")
					{
						Query = $"{Query} AND comp_state = '{cmb_state_code.Text.Substring(Math.Min(0, cmb_state_code.Text.Length), Math.Min(cmb_state_code.Text.IndexOf(", "), Math.Max(0, cmb_state_code.Text.Length)))}'";
					}
					else
					{
						temp_query = $"{temp_query} AND comp_state = '' ";
					}

					Query = $"{Query} AND comp_journ_id > 0";

					snpHistRecInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					//if a record or records exist for the comp_name, comp_state, comp_city, journid > 0 then
					//ask if they want to save the new company as the current(active) for the historical records.
					if (!(snpHistRecInfo.BOF && snpHistRecInfo.EOF))
					{

						if (!modAdminCommon.Exist($"SELECT * FROM company WITH(NOLOCK) WHERE comp_id = {Convert.ToString(snpHistRecInfo["Comp_id"])} AND comp_journ_id = 0"))
						{

							sMsg = $"The new company entered '{Text1[COMPANY_NAME].Text}' does not exist as a";
							sMsg = $"{sMsg} current company but a historical record does exist for this company.{Environment.NewLine}";

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snpHistRecInfo["Comp_Name"]))
							{
								if (Convert.ToString(snpHistRecInfo["Comp_Name"]) != modGlobalVars.cEmptyString)
								{
									sMsg = $"{sMsg}Company Name:  {Convert.ToString(snpHistRecInfo["Comp_Name"]).Trim()}{Environment.NewLine}";
								}
								else
								{
									sMsg = $"{sMsg}Company Name:  (None){Environment.NewLine}";
								}
							}

							sMsg = $"{sMsg}ID:  {Convert.ToString(snpHistRecInfo["Comp_id"]).Trim()}{Environment.NewLine}";

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snpHistRecInfo["comp_address1"]))
							{
								if (Convert.ToString(snpHistRecInfo["comp_address1"]) != modGlobalVars.cEmptyString)
								{
									sMsg = $"{sMsg}Address:  {Convert.ToString(snpHistRecInfo["comp_address1"]).Trim()}{Environment.NewLine}";
								}
								else
								{
									sMsg = $"{sMsg}Address:  (None){Environment.NewLine}";
								}
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (Convert.IsDBNull(snpHistRecInfo["comp_address2"]))
							{
								if (Convert.ToString(snpHistRecInfo["comp_address2"]) != modGlobalVars.cEmptyString)
								{
									sMsg = $"{sMsg}          {Convert.ToString(snpHistRecInfo["comp_address2"]).Trim()}{Environment.NewLine}";
								}
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snpHistRecInfo["comp_city"]))
							{
								if (Convert.ToString(snpHistRecInfo["comp_city"]) != modGlobalVars.cEmptyString)
								{
									sMsg = $"{sMsg}City:  {Convert.ToString(snpHistRecInfo["comp_city"]).Trim()}{Environment.NewLine}";
								}
								else
								{
									sMsg = $"{sMsg}City:  (None){Environment.NewLine}";
								}
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snpHistRecInfo["comp_state"]))
							{
								if (Convert.ToString(snpHistRecInfo["comp_state"]) != modGlobalVars.cEmptyString)
								{
									sMsg = $"{sMsg}State:  {Convert.ToString(snpHistRecInfo["comp_state"]).Trim()}{Environment.NewLine}";
								}
								else
								{
									sMsg = $"{sMsg}State:  (None){Environment.NewLine}";
								}
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snpHistRecInfo["comp_business_type"]))
							{
								if (Convert.ToString(snpHistRecInfo["comp_business_type"]) != modGlobalVars.cEmptyString)
								{
									sMsg = $"{sMsg}Business Type:  {Convert.ToString(snpHistRecInfo["comp_business_type"]).Trim()}{Environment.NewLine}";
								}
								else
								{
									sMsg = $"{sMsg}Business Type:  (None){Environment.NewLine}";
								}
							}

							sMsg = $"{sMsg}Would you like to make the new company, the current(active) company";
							sMsg = $"{sMsg} for this historical record?";

							nResponse = MessageBox.Show(sMsg, "Historical Company Records Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

							if (nResponse == System.Windows.Forms.DialogResult.Yes)
							{
								//use the company id from the historical record as the company id for the current.
								// ** note this might fail because of comp_id
								n_nextCompanyID = Convert.ToInt32(snpHistRecInfo["comp_id"]);

								lbl_status_display.Text = $"Historical Company Found, Use This Company ID({n_nextCompanyID.ToString()})...";
								lbl_status_display.Refresh();

							}
						}
					}
				}

				if (n_nextCompanyID == 0)
				{ // i didn't get a company id from the history
					n_nextCompanyID = GetNextCompanyID();
					lbl_status_display.Text = $"No Historical Company ID Found, Get New Company ID({n_nextCompanyID.ToString()})...";
					lbl_status_display.Refresh();
				}

				// RTW - 4/5/2011
				// ADDED CODE TO VERIFY THAT THE COMPANY ID TO BE USED IS NOT ALREADY IN THE DELETE LOG
				// SINCE WE HAD FOUND OUT THAT FOR AWAITING DOC COMPANIES THEY ADD THEM AND QUICKLY REMOVE THEM
				// WHICH FREED UP COMPANY ID FOR REUSE
				inDeleteLog = true;
				DeleteCheckCount = 0;

				while(inDeleteLog && DeleteCheckCount < 10)
				{
					// check to see if company is in the delete log or the combine company queue
					Query = $"Select dlog_key from delete_log where dlog_comp_id={n_nextCompanyID.ToString()}";
					DeleteCheckCount++;
					if (modAdminCommon.Exist(Query))
					{
						// since this company was in the delete log - increment the company id and try again
						n_nextCompanyID++;
					}
					else
					{
						Query = $"Select ccq_id from Company_Combined_Queue where ccq_combine_comp_id={n_nextCompanyID.ToString()}";
						if (modAdminCommon.Exist(Query))
						{
							n_nextCompanyID++;
						}
						else
						{
							// not in either of the delete logs - ok to add
							inDeleteLog = false;
						}
					}
				};
				// show the company ID for this new company
				Text1[COMPANY_ID].Enabled = true;
				Text1[COMPANY_ID].Text = n_nextCompanyID.ToString();
				Text1[COMPANY_ID].Enabled = false;

				if (cmb_state_code.Text != modGlobalVars.cEmptyString)
				{
					l_tempAry = cmb_state_code.Text.Split(new string[]{", "}, StringSplitOptions.None);
				}
				else
				{
					l_tempAry = (", , ").Split(new string[]{", "}, StringSplitOptions.None); // empty state code
				}

				//insert new record into table
				Query = "INSERT INTO Company (";
				Query = $"{Query}comp_id, comp_journ_id, comp_name, comp_name_search, comp_name_alt_type, comp_name_alt, comp_altname_search, ";
				Query = $"{Query}comp_address1, comp_address1_search, comp_address2, comp_address2_search, comp_city, comp_state, comp_country, ";
				Query = $"{Query}comp_zip_code, comp_timezone, comp_agency_type, comp_government_id, comp_language, ";
				Query = $"{Query}comp_account_callback_date, comp_business_type, comp_account_type, ";
				Query = $"{Query}comp_ent_user_id, comp_active_flag, comp_hide_flag, comp_acpros_flag, ";
				Query = $"{Query}comp_assign_flag, comp_contact_address_flag, comp_account_id, comp_email_address, comp_email_confirm_date, ";
				Query = $"{Query}comp_web_address, comp_web_confirm_date, comp_address_confirm_date, ";
				Query = $"{Query}comp_avdata_id, comp_service, comp_action_date, ";
				Query = $"{Query}comp_product_business_flag, comp_product_commercial_flag, comp_product_helicopter_flag, comp_product_airbp_flag, comp_product_abi_flag, comp_product_yacht_flag ";
				Query = $"{Query})";

				Query = $"{Query} VALUES ({n_nextCompanyID.ToString()},"; // Company ID
				Query = $"{Query}0,"; // journal ID
				Query = $"{Query}'{modAdminCommon.Fix_Quote(Text1[COMPANY_NAME].Text).Trim()}',"; // Company name
				Query = $"{Query}'{modCommon.Get_Name_Search_String(Text1[COMPANY_NAME].Text)}',"; // Company name (for Searching)

				if (cmb_comp_name_alt_type.Text != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}'{modAdminCommon.Fix_Quote(cmb_comp_name_alt_type.Text).Trim()}',"; // Company name Alt Type (c/o DBA)
				}
				else
				{
					Query = $"{Query}null,";
				}

				if (Text1[COMPANY_ALT_NAME].Text != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}'{modAdminCommon.Fix_Quote(Text1[COMPANY_ALT_NAME].Text).Trim()}', "; // Company Alt Name
					Query = $"{Query}'{modCommon.LeaveOnlyAlphaAndNumeric(Text1[COMPANY_ALT_NAME].Text).ToUpper()}', "; // Company Alt Name Search
				}
				else
				{
					Query = $"{Query}null, null, ";
				}

				Query = $"{Query}'{modAdminCommon.Fix_Quote(Text1[company_address1].Text).Trim()}', "; // address 1
				Query = $"{Query}'{modCommon.LeaveOnlyAlphaAndNumeric(Text1[company_address1].Text).ToUpper()}', "; // address 1 search

				//  Query = Query & "dbo.LeaveAlphaAndNumeric('" & Text1(company_address1).Text & "'), "      ' address 1 search


				Query = $"{Query}'{modAdminCommon.Fix_Quote(Text1[company_address2].Text).Trim()}', "; // address 2
				Query = $"{Query}'{modCommon.LeaveOnlyAlphaAndNumeric(Text1[company_address2].Text).ToUpper()}', "; // address 2 search

				Query = $"{Query}'{modAdminCommon.Fix_Quote(Text1[COMPANY_CITY].Text).Trim()}',"; // city
				if (l_tempAry[0].Trim().ToUpper() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}'{l_tempAry[0].Trim().ToUpper()}',"; // state
				}
				else
				{
					Query = $"{Query}null,"; // state
				}

				Query = $"{Query}'{modAdminCommon.Fix_Quote(cmb_country_code.Text).Trim()}',"; // country
				Query = $"{Query}'{Text1[COMPANY_POSTALCODE].Text.Trim()}',"; // postal code
				Query = $"{Query}'{l_tempAry[2].Trim()}',"; // timezone

				Query = $"{Query}'{cmb_agency_type.Text.Substring(Math.Min(0, cmb_agency_type.Text.Length), Math.Min(1, Math.Max(0, cmb_agency_type.Text.Length))).Trim()}',"; // agency

				if (cmb_agency_type.Text.Substring(Math.Min(0, cmb_agency_type.Text.Length), Math.Min(1, Math.Max(0, cmb_agency_type.Text.Length))).Trim().ToUpper() == "G")
				{ // if this a Gov't Marking default comp_government_id = 2
					Query = $"{Query}2,";
				}
				else
				{
					Query = $"{Query}0,";
				}

				Query = $"{Query}'{cmb_language.Text.Trim()}',"; // language

				Query = $"{Query}'{DateTime.Parse(modAdminCommon.DateToday).AddDays(1).ToString("d")}',"; // Callback Date

				if (cmb_business_type.Text != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}'{cmb_business_type.Text.Substring(Math.Min(0, cmb_business_type.Text.Length), Math.Min(2, Math.Max(0, cmb_business_type.Text.Length))).Trim()}',";
				}
				else
				{
					Query = $"{Query}null,";
				}

				if (cmb_account_type.Text.Trim() != modGlobalVars.cEmptyString)
				{
					switch(cmb_account_type.Text.Trim())
					{
						case "End User" : 
							Current_Account_Type = "EU"; 
							break;
						case "Dealer Broker" : 
							Current_Account_Type = "DB"; 
							break;
						case "Unidentified" : 
							Current_Account_Type = "UI"; 
							break;
						case "Fractional Owner" : 
							Current_Account_Type = "FO"; 
							break;
						default:
							Current_Account_Type = "null"; 
							break;
					}

					Query = $"{Query}'{Current_Account_Type}',";
				}
				else
				{
					Query = $"{Query}null,";
				}

				Query = $"{Query}'{modAdminCommon.gbl_User_ID.Trim()}',";

				Query = $"{Query}'Y',"; // company active flag

				// added MSW - 9/28/23
				if (chk_hide_company.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y',"; // company hide flag
				}
				else
				{
					Query = $"{Query}'N',"; // company hide flag
				}


				Query = $"{Query}'N',"; // AC Pros Flag

				if (chk_auto_account_rep.CheckState == CheckState.Checked)
				{
					modFillCompConControls.assign_account_rep(Text1[COMPANY_NAME].Text, cmb_account_type, cmb_account_id);
					Query = $"{Query}'A',"; // (A)uto Assign Company Rep Flag
				}
				else
				{
					Query = $"{Query}'M',"; // (M)anual Assign Company Rep Flag
				}

				// 02/19/2016 - By David D. Cruger; Added
				if (chkCompContactAddressFlag.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y',";
				}
				else
				{
					Query = $"{Query}'N',";
				}

				if (cmb_account_id.Text.Trim() == modGlobalVars.cEmptyString)
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
					MessageBox.Show("Company must have an Account Rep ID", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				Query = $"{Query}'{cmb_account_id.Text.Trim()}',"; // company account rep ID

				if (Text1[COMPANY_EMAIL].Text != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}'{modAdminCommon.Fix_Quote(Text1[COMPANY_EMAIL].Text).Trim()}',"; // e-mail address
					Query = $"{Query}'{DateTime.Parse(modAdminCommon.DateToday).ToString("d").Trim()}',"; // comp_email_confirm_date
				}
				else
				{
					Query = $"{Query}null,";
					Query = $"{Query}null,";
				}

				if (Text1[COMPANY_WEBSITE].Text != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}'{modAdminCommon.Fix_Quote(Text1[COMPANY_WEBSITE].Text).Trim()}',"; // web site address
					Query = $"{Query}'{DateTime.Parse(modAdminCommon.DateToday).ToString("d").Trim()}',"; // comp_web_confirm_date
				}
				else
				{
					Query = $"{Query}null,";
					Query = $"{Query}null,";
				}

				Query = $"{Query}'{DateTime.Parse(modAdminCommon.DateToday).ToString("d").Trim()}',"; // comp_address_confirm_date

				Query = $"{Query}'{strAVDataId}', "; // 02/09/2016 - By David D. Cruger; Added
				Query = $"{Query}'U', "; // 08/19/2019 - By David D. Cruger; Added

				Query = $"{Query}'1/1/1900', "; // 08/30/2019 - By David D. Cruger; Added - Action Date

				//-------------------------------------------------------
				// Keep Product Flags The Last Fields To Process

				if (cmb_product_code.Text.Trim() != modGlobalVars.cEmptyString)
				{
					switch((cmb_product_code.Text.Substring(0, Math.Min(1, cmb_product_code.Text.Length))))
					{
						case "B" : 
							Query = $"{Query}'Y','N','N','N','N', 'N')";  // comp_product_business_flag 
							 
							break;
						case "H" : 
							Query = $"{Query}'N','N','Y','N','N', 'N')";  // comp_product_helicopter_flag 
							 
							break;
						case "C" : 
							Query = $"{Query}'N','Y','N','N','N', 'N')";  // comp_product_commercial_flag 
							 
							break;
						case "R" : 
							Query = $"{Query}'N','N','N','N','N', 'N')";  // comp_product_regional_flag 
							 
							break;
						case "A" : 
							Query = $"{Query}'N','N','N','N','Y', 'N')";  // comp_product_abi_flag 
							 
							break;
						case "P" : 
							Query = $"{Query}'N','N','N','Y','N', 'N')";  // comp_product_airbp_flag 
							 
							break;
						case "Y" : 
							Query = $"{Query}'N','N','N','N','N', 'Y')";  // comp_product_airbp_flag 
							 
							break;
						default:
							Query = $"{Query}'Y','N','N','N','N', 'N')";  // default to comp_product_business_flag 
							 
							break;
					}
				}

				lbl_status_display.Text = "Adding New Company Record...";
				lbl_status_display.Refresh();


				DbCommand TempCommand = null;
				ErrorHandlingHelper.ResumeNext(
					() => {TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();}, 
					() => {UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);}, 
					() => {TempCommand.CommandText = Query;}, 
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					() => {TempCommand.CommandType = CommandType.Text;}, // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					() => {UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);}, 
					() => {TempCommand.ExecuteNonQuery();});


				if (cmb_business_type.Text.Trim() != modGlobalVars.cEmptyString)
				{

					Query = "INSERT INTO Business_Type_Reference (";
					Query = $"{Query}bustypref_comp_id, bustypref_journ_id, bustypref_type, bustypref_seq_no";
					Query = $"{Query}) VALUES ({n_nextCompanyID.ToString()},0,'{cmb_business_type.Text.Substring(Math.Min(0, cmb_business_type.Text.Length), Math.Min(2, Math.Max(0, cmb_business_type.Text.Length)))}', 1)";

					lbl_status_display.Text = "Adding New Business Type Reference...";
					lbl_status_display.Refresh();


					DbCommand TempCommand_2 = null;
					ErrorHandlingHelper.ResumeNext(
						() => {TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();}, 
						() => {UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);}, 
						() => {TempCommand_2.CommandText = Query;}, 
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						() => {TempCommand_2.CommandType = CommandType.Text;}, // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						() => {UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);}, 
						() => {TempCommand_2.ExecuteNonQuery();});


				}
				else
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
					MessageBox.Show("Company must have a Business Type Reference", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				lbl_status_display.Text = "Adding Company Phone Numbers...";
				lbl_status_display.Refresh();

				if (!Save_CompanyContact_Phone_Info(n_nextCompanyID, 0, true))
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
					MessageBox.Show("Error Saving Company Phone Number(s)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				// Check for Contact Info
				if (Text1[CONTACT_FIRST].Text != modGlobalVars.cEmptyString)
				{ // Check first Name
					if (Text1[CONTACT_LAST].Text != modGlobalVars.cEmptyString)
					{ // Check last Name
						if (!Quick_Insert_Company_Contact(n_nextCompanyID))
						{
							modAdminCommon.ADO_Transaction("RollbackTrans");
							MessageBox.Show("Error Saving Company Contact", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							return;
						}
					}
					else
					{
						if (MessageBox.Show("Contact Last Name is blank.  Do you still want to add company info?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						{
							set_lbl_error(Label1[LBL_CONTACT_LAST_NAME], true);
							modAdminCommon.ADO_Transaction("RollbackTrans");
							lbl_status_display.Text = "Adding New Company, Stopped";
							return;
						}
						else
						{
							if (!Quick_Insert_Company_Contact(n_nextCompanyID))
							{
								modAdminCommon.ADO_Transaction("RollbackTrans");
								MessageBox.Show("Error Saving Company Contact", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								lbl_status_display.Text = "Error Saving Company Contact";
								return;
							}
						}
					}
				}
				else
				{
					if (MessageBox.Show("Contact First Name is blank.  Do you still want to add company info?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
					{
						set_lbl_error(Label1[LBL_CONTACT_FIRST_NAME], true);
						modAdminCommon.ADO_Transaction("RollbackTrans");
						lbl_status_display.Text = "Adding New Company, Stopped";
						return;
					}
				}

				// Check for Contact Info
				if (Text1[JOURNAL_SUBJECT].Text != modGlobalVars.cEmptyString)
				{ // Check first Name
					if (!Quick_Insert_Research_Note(n_nextCompanyID, n_nextContactID))
					{
						modAdminCommon.ADO_Transaction("RollbackTrans");
						MessageBox.Show("Error Saving Research Note", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						return;
					}
				}

				modAdminCommon.ADO_Transaction("CommitTrans");

				lbl_status_display.Text = "Adding New Company, Completed...";
				lbl_status_display.Refresh();

				modCommon.Company_Stats_Update(n_nextCompanyID);

				n_nextCompanyID = 0;
				n_nextContactID = 0;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lbl_status_display.Text = $"Adding New Company Error ** {Information.Err().Number.ToString()} {excep.Message}";
				lbl_status_display.Refresh();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Quick_Insert_Company_Error: {Information.Err().Number.ToString()} {excep.Message}");

				modAdminCommon.ADO_Transaction("RollbackTrans");
			}

		}

		private bool Save_CompanyContact_Phone_Info(int in_CompanyID, int in_ContactID, bool bIsCompany)
		{

			bool result = false;
			string Query = modGlobalVars.cEmptyString;
			StringBuilder IQuery = new StringBuilder();
			IQuery.Append(modGlobalVars.cEmptyString);
			string sPhoneNumber1 = modGlobalVars.cEmptyString;
			string sPhoneNumber2 = modGlobalVars.cEmptyString;
			string sPhoneType1 = modGlobalVars.cEmptyString;
			string sPhoneType2 = modGlobalVars.cEmptyString;
			int lDel = 0;
			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);
			bool phone_exists = false;

			try
			{

				sPhoneNumber1 = "";
				sPhoneNumber2 = "";
				phone_exists = false;

				if (bIsCompany)
				{

					// make sure we clean-up phone numbers (in case we are re-activating a company/contact)
					Query = "DELETE FROM Phone_Numbers";
					Query = $"{Query} WHERE pnum_comp_id = {in_CompanyID.ToString()}";
					Query = $"{Query} AND pnum_journ_id = 0 AND pnum_contact_id = 0";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					lDel = TempCommand.ExecuteNonQuery();

					for (int x = COMPANY_PTYPE1; x <= COMPANY_PTYPE2; x++)
					{

						switch((x))
						{
							case COMPANY_PTYPE1 : 
								 
								sPhoneType1 = cmb_phone_type[COMPANY_PTYPE1].Text.Trim(); 
								 
								if (sPhoneType1 != modGlobalVars.cEmptyString)
								{
									IQuery = new StringBuilder("INSERT INTO Phone_Numbers (");
									IQuery.Append("pnum_comp_id, pnum_journ_id, pnum_contact_id, ");
									IQuery.Append("pnum_type, pnum_cntry_code, pnum_area_code, pnum_prefix, ");
									IQuery.Append("pnum_number, pnum_number_full, ");
									IQuery.Append("pnum_confirm_date, pnum_hide_customer, pnum_number_full_search)");
									IQuery.Append($" VALUES ({in_CompanyID.ToString()},"); // company ID
									IQuery.Append("0,"); // journal ID
									IQuery.Append("0,"); // contact ID
									IQuery.Append($"'{sPhoneType1}',"); // Phone Type

									for (int Y = COMPANY_PCONTRY1; Y <= COMPANY_PNUMBER1; Y++)
									{
										if (Text1[Y].Text.Trim() != modGlobalVars.cEmptyString)
										{
											sPhoneNumber1 = $"{sPhoneNumber1}{Text1[Y].Text.Trim()}{modGlobalVars.cHyphen}";
											IQuery.Append($"'{Text1[Y].Text.Trim()}',"); // Phone (Country,Area,Prefix,Number)
											phone_exists = true;
										}
										else
										{
											IQuery.Append($"'{Text1[Y].Text.Trim()}',"); // Phone (Country,Area,Prefix,Number)
										}
									}

									sPhoneNumber1 = sPhoneNumber1.Substring(Math.Min(0, sPhoneNumber1.Length), Math.Min(Strings.Len(sPhoneNumber1) - 1, Math.Max(0, sPhoneNumber1.Length))).Trim(); // strip off trailing dash
									IQuery.Append($"'{sPhoneNumber1}',"); // Phone Number Full (with Dashes)
									IQuery.Append($"'{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}',"); // Phone Number Confirm Date
									IQuery.Append("'N',"); // Phone Number hide flag
									IQuery.Append($"'{StringsHelper.Replace(StringsHelper.Replace(sPhoneNumber1, modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary)}')"); // Phone Number Full Search (without Dashes or Spaces)

									if (!phone_exists)
									{
										IQuery = new StringBuilder("");
									}

								}  // sPhoneType1 <> cEmptyString 
								 
								break;
							case COMPANY_PTYPE2 : 
								 
								sPhoneType2 = cmb_phone_type[COMPANY_PTYPE2].Text.Trim(); 
								phone_exists = false; 
								 
								if (sPhoneType2 != modGlobalVars.cEmptyString)
								{
									IQuery = new StringBuilder("INSERT INTO Phone_Numbers (");
									IQuery.Append("pnum_comp_id, pnum_journ_id, pnum_contact_id, ");
									IQuery.Append("pnum_type, pnum_cntry_code, pnum_area_code, pnum_prefix, ");
									IQuery.Append("pnum_number, pnum_number_full, ");
									IQuery.Append("pnum_confirm_date, pnum_hide_customer, pnum_number_full_search)");
									IQuery.Append($" VALUES ({in_CompanyID.ToString()},"); // company ID
									IQuery.Append("0,"); // journal ID
									IQuery.Append("0,"); // contact ID
									IQuery.Append($"'{sPhoneType2}',"); // Phone Type

									for (int Y = COMPANY_PCONTRY2; Y <= COMPANY_PNUMBER2; Y++)
									{
										if (Text1[Y].Text.Trim() != modGlobalVars.cEmptyString)
										{
											sPhoneNumber2 = $"{sPhoneNumber2}{Text1[Y].Text.Trim()}{modGlobalVars.cHyphen}";
											IQuery.Append($"'{Text1[Y].Text.Trim()}',"); // Phone (Country,Area,Prefix,Number)
											phone_exists = true;
										}
										else
										{
											IQuery.Append($"'{Text1[Y].Text.Trim()}',"); // Phone (Country,Area,Prefix,Number)
										}
									}

									sPhoneNumber2 = sPhoneNumber2.Substring(Math.Min(0, sPhoneNumber2.Length), Math.Min(Strings.Len(sPhoneNumber2) - 1, Math.Max(0, sPhoneNumber2.Length))).Trim(); // strip off trailing dash
									IQuery.Append($"'{sPhoneNumber2}',"); // Phone Number Full (with Dashes)
									IQuery.Append($"'{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}',"); // Phone Number Confirm Date
									IQuery.Append("'N',"); // Phone Number hide flag
									IQuery.Append($"'{StringsHelper.Replace(StringsHelper.Replace(sPhoneNumber2, modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary)}')"); // Phone Number Full Search (without Dashes or Spaces)

									if (!phone_exists)
									{
										IQuery = new StringBuilder("");
									}

								}  // sPhoneType2 <> cEmptyString 
								 
								break;
						}

						lbl_status_display.Text = $"Adding New {((bIsCompany) ? "Company" : "Contact")} Phone Number(s)...";
						lbl_status_display.Refresh();


						if (IQuery.ToString() != modGlobalVars.cEmptyString)
						{
							DbCommand TempCommand_2 = null;
							ErrorHandlingHelper.ResumeNext(

								() => {TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();}, 
								() => {UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);}, 
								() => {TempCommand_2.CommandText = IQuery.ToString();}, 
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								() => {TempCommand_2.CommandType = CommandType.Text;}, // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								() => {UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);}, 
								() => {TempCommand_2.ExecuteNonQuery();});

							if (x == COMPANY_PTYPE1)
							{
								if (sPhoneNumber1 != "")
								{
									ErrorHandlingHelper.ResumeNext(
										() => {modCommon.Start_Activity_Monitor_Message("Company Phone Added", ref strMsg, ref dtStartDate, ref dtEndDate);}, 
										() => {strMsg = $" - {sPhoneType1} - {sPhoneNumber1}";}, 
										() => {modCommon.End_Activity_Monitor_Message("Company Phone Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, in_CompanyID, 0, 0);});
								}
							}

							if (x == COMPANY_PTYPE2)
							{
								if (sPhoneNumber2 != "")
								{
									ErrorHandlingHelper.ResumeNext(
										() => {modCommon.Start_Activity_Monitor_Message("Company Phone Added", ref strMsg, ref dtStartDate, ref dtEndDate);}, 
										() => {strMsg = $" - {sPhoneType2} - {sPhoneNumber2}";}, 
										() => {modCommon.End_Activity_Monitor_Message("Company Phone Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, in_CompanyID, 0, 0);});
								}
							}


						}

						IQuery = new StringBuilder(modGlobalVars.cEmptyString);

					}

				}
				else
				{
					// Insert Contact Phone Numbers

					// make sure we clean-up phone numbers (in case we are re-activating a company/contact)
					Query = "DELETE FROM Phone_Numbers";
					Query = $"{Query} WHERE pnum_comp_id = {in_CompanyID.ToString()}";
					Query = $"{Query} AND pnum_journ_id = 0 AND pnum_contact_id = {in_ContactID.ToString()}";

					DbCommand TempCommand_3 = null;
					TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
					TempCommand_3.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
					TempCommand_3.ExecuteNonQuery();

					for (int x = CONTACT_PTYPE1; x <= CONTACT_PTYPE2; x++)
					{


						switch((x))
						{
							case CONTACT_PTYPE1 : 
								 
								sPhoneType1 = cmb_phone_type[CONTACT_PTYPE1].Text; 
								 
								if (sPhoneType1 != modGlobalVars.cEmptyString)
								{
									IQuery = new StringBuilder("INSERT INTO Phone_Numbers (");
									IQuery.Append("pnum_comp_id, pnum_journ_id, pnum_contact_id, ");
									IQuery.Append("pnum_type, pnum_cntry_code, pnum_area_code, pnum_prefix, ");
									IQuery.Append("pnum_number, pnum_number_full, ");
									IQuery.Append("pnum_confirm_date, pnum_hide_customer, pnum_number_full_search)");
									IQuery.Append($" VALUES ({in_CompanyID.ToString()},"); // company ID
									IQuery.Append("0,"); // journal ID
									IQuery.Append($"{in_ContactID.ToString()},"); // contact ID
									IQuery.Append($"'{sPhoneType1}',"); // Phone Type

									for (int Y = CONTACT_PCONTRY1; Y <= CONTACT_PNUMBER1; Y++)
									{
										if (Text1[Y].Text.Trim() != modGlobalVars.cEmptyString)
										{
											sPhoneNumber1 = $"{sPhoneNumber1}{Text1[Y].Text.Trim()}{modGlobalVars.cHyphen}";
											IQuery.Append($"'{Text1[Y].Text.Trim()}',"); // Phone (Country,Area,Prefix,Number)
										}
										else
										{
											IQuery.Append($"'{Text1[Y].Text.Trim()}',"); // Phone (Country,Area,Prefix,Number)
										}
									}

									sPhoneNumber1 = sPhoneNumber1.Substring(Math.Min(0, sPhoneNumber1.Length), Math.Min(Strings.Len(sPhoneNumber1) - 1, Math.Max(0, sPhoneNumber1.Length))).Trim(); // strip off trailing dash
									IQuery.Append($"'{sPhoneNumber1}',"); // Phone Number Full (with Dashes)
									IQuery.Append($"'{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}',"); // Phone Number Confirm Date
									IQuery.Append("'N',"); // Phone Number hide flag
									IQuery.Append($"'{StringsHelper.Replace(StringsHelper.Replace(sPhoneNumber1, modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary)}')"); // Phone Number Full Search (without Dashes or Spaces)
								}  // sPhoneType1 <> cEmptyString 
								 
								break;
							case CONTACT_PTYPE2 : 
								 
								sPhoneType2 = cmb_phone_type[CONTACT_PTYPE2].Text; 
								 
								if (sPhoneType2 != modGlobalVars.cEmptyString)
								{
									IQuery = new StringBuilder("INSERT INTO Phone_Numbers (");
									IQuery.Append("pnum_comp_id, pnum_journ_id, pnum_contact_id, ");
									IQuery.Append("pnum_type, pnum_cntry_code, pnum_area_code, pnum_prefix, ");
									IQuery.Append("pnum_number, pnum_number_full, ");
									IQuery.Append("pnum_confirm_date, pnum_hide_customer, pnum_number_full_search)");
									IQuery.Append($" VALUES ({in_CompanyID.ToString()},"); // company ID
									IQuery.Append("0,"); // journal ID
									IQuery.Append($"{in_ContactID.ToString()},"); // contact ID
									IQuery.Append($"'{sPhoneType2}',"); // Phone Type

									for (int Y = CONTACT_PCONTRY2; Y <= CONTACT_PNUMBER2; Y++)
									{

										if (Text1[Y].Text.Trim() != modGlobalVars.cEmptyString)
										{
											sPhoneNumber2 = $"{sPhoneNumber2}{Text1[Y].Text.Trim()}{modGlobalVars.cHyphen}";
											IQuery.Append($"'{Text1[Y].Text.Trim()}',"); // Phone (Country,Area,Prefix,Number)
										}
										else
										{
											IQuery.Append($"'{Text1[Y].Text.Trim()}',"); // Phone (Country,Area,Prefix,Number)
										}

									}

									sPhoneNumber2 = sPhoneNumber2.Substring(Math.Min(0, sPhoneNumber2.Length), Math.Min(Strings.Len(sPhoneNumber2) - 1, Math.Max(0, sPhoneNumber2.Length))).Trim(); // strip off trailing dash
									IQuery.Append($"'{sPhoneNumber2}',"); // Phone Number Full (with Dashes)
									IQuery.Append($"'{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}',"); // Phone Number Confirm Date
									IQuery.Append("'N',"); // Phone Number hide flag
									IQuery.Append($"'{StringsHelper.Replace(StringsHelper.Replace(sPhoneNumber2, modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary)}')"); // Phone Number Full Search (without Dashes or Spaces)

								}  //sPhoneType2 <> cEmptyString 
								 
								break;
						}

						lbl_status_display.Text = $"Adding New {((bIsCompany) ? "Company" : "Contact")} Phone Number(s)...";
						lbl_status_display.Refresh();


						if (IQuery.ToString() != modGlobalVars.cEmptyString)
						{
							DbCommand TempCommand_4 = null;
							ErrorHandlingHelper.ResumeNext(

								() => {TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();}, 
								() => {UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);}, 
								() => {TempCommand_4.CommandText = IQuery.ToString();}, 
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								() => {TempCommand_4.CommandType = CommandType.Text;}, // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								() => {UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);}, 
								() => {TempCommand_4.ExecuteNonQuery();});

							if (x == CONTACT_PTYPE1)
							{
								if (sPhoneNumber1 != "")
								{
									ErrorHandlingHelper.ResumeNext(
										() => {modCommon.Start_Activity_Monitor_Message("Contact Phone Added", ref strMsg, ref dtStartDate, ref dtEndDate);}, 
										() => {strMsg = $" - {sPhoneType1} - {sPhoneNumber1}";}, 
										() => {modCommon.End_Activity_Monitor_Message("Contact Phone Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, in_CompanyID, 0, in_ContactID);});
								}
							}

							if (x == CONTACT_PTYPE2)
							{
								if (sPhoneNumber2 != "")
								{
									ErrorHandlingHelper.ResumeNext(
										() => {modCommon.Start_Activity_Monitor_Message("Contact Phone Added", ref strMsg, ref dtStartDate, ref dtEndDate);}, 
										() => {strMsg = $" - {sPhoneType2} - {sPhoneNumber2}";}, 
										() => {modCommon.End_Activity_Monitor_Message("Contact Phone Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, in_CompanyID, 0, in_ContactID);});
								}
							}


						}

						IQuery = new StringBuilder(modGlobalVars.cEmptyString);

					}

				} // bIsCompany

				result = true;

				lbl_status_display.Text = $"Adding New {((bIsCompany) ? "Company" : "Contact")} Phone Number(s), Completed...";
				lbl_status_display.Refresh();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lbl_status_display.Text = $"Adding New {((bIsCompany) ? "Company" : "Contact")} Phone Info Error ** {Information.Err().Number.ToString()} {excep.Message}";
				lbl_status_display.Refresh();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Quick_Insert_Company_Error:(Save_CompanyContact_Phone_Info_Error) {Information.Err().Number.ToString()} {excep.Message}");
			}

			return result;
		}

		private bool Quick_Insert_Company_Contact(int in_CompanyID)
		{

			bool result = false;
			string Query = modGlobalVars.cEmptyString;
			string IQuery = modGlobalVars.cEmptyString;

			try
			{

				// MAKE SURE THAT WE DO NOT HAVE A DUPLICATE FOR THIS CONTACT
				Query = $"SELECT * FROM Contact WHERE contact_comp_id = {in_CompanyID.ToString()}";
				Query = $"{Query} AND contact_journ_id = 0";

				if (Text1[CONTACT_FIRST].Text.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query} AND contact_first_name='{modAdminCommon.Fix_Quote(Text1[CONTACT_FIRST].Text)}'";
				}
				else
				{
					Query = $"{Query} AND (isnull(contact_first_name,'') = '') ";
				}

				if (Text1[CONTACT_MIDDLE].Text.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query} AND contact_middle_initial='{modAdminCommon.Fix_Quote(Text1[CONTACT_MIDDLE].Text)}'";
				}
				else
				{
					Query = $"{Query} AND (isnull(contact_middle_initial,'') = '') ";
				}

				if (Text1[CONTACT_LAST].Text.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query} AND contact_last_name='{modAdminCommon.Fix_Quote(Text1[CONTACT_LAST].Text)}'";
				}
				else
				{
					Query = $"{Query} AND (isnull(contact_last_name,'') = '') ";
				}

				if (cmb_suffix.Text.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query} AND contact_suffix='{modAdminCommon.Fix_Quote(cmb_suffix.Text.Trim())}'";
				}
				else
				{
					Query = $"{Query} AND (isnull(contact_suffix,'') = '') ";
				}

				if (cmb_contact_title.Text.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query} AND contact_title='{modAdminCommon.Fix_Quote(cmb_contact_title.Text.Trim())}'";
				}
				else
				{
					Query = $"{Query} AND (isnull(contact_title,'') = '') ";
				}

				if (modAdminCommon.Exist(Query))
				{
					MessageBox.Show($"This Contact Already Exists for This Company. Contact Save Aborted.{Environment.NewLine}There may be a duplicate inactive contact.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return result;
				}

				// *********************************************************************
				// DISPLAY ERROR MESSAGE IF TITLE, LAST NAME, AND FIRST NAME ARE BLANK
				if (cmb_contact_title.Text.Trim() == modGlobalVars.cEmptyString && Text1[CONTACT_FIRST].Text.Trim() == modGlobalVars.cEmptyString && Text1[CONTACT_LAST].Text.Trim() == modGlobalVars.cEmptyString)
				{

					MessageBox.Show("Contact must have a TITLE AND NAME. Contact Save Aborted.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return result;

				}

				// if we have no dups get the next contact ID
				n_nextContactID = GetNextContactID();

				// show the contact ID for this new company
				Text1[contact_id].Enabled = true;
				Text1[contact_id].Text = n_nextContactID.ToString();
				Text1[contact_id].Enabled = false;

				// insert contact
				IQuery = "INSERT INTO Contact (";
				IQuery = $"{IQuery}contact_id, contact_journ_id, contact_comp_id, ";
				IQuery = $"{IQuery}contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, ";
				IQuery = $"{IQuery}contact_suffix, contact_title, contact_title_confirm_date, contact_email_address, contact_email_confirm_date, ";
				IQuery = $"{IQuery}contact_active_flag, contact_hide_flag, contact_research_flag, contact_acpros_seq_no, ";
				IQuery = $"{IQuery}contact_name_confirm_date, contact_phone_confirm_date, contact_user_id";

				IQuery = $"{IQuery}) VALUES (";
				IQuery = $"{IQuery}{n_nextContactID.ToString()},"; // contact_id
				IQuery = $"{IQuery}0, "; // contact_journ_id
				IQuery = $"{IQuery}{in_CompanyID.ToString()},"; // contact_comp_id

				IQuery = $"{IQuery}'{modAdminCommon.Fix_Quote(cmb_sirname.Text).Trim()}', "; // contact_sirname
				IQuery = $"{IQuery}'{modAdminCommon.Fix_Quote(Text1[CONTACT_FIRST].Text).Trim()}',"; // contact_first_name
				IQuery = $"{IQuery}'{modAdminCommon.Fix_Quote(Text1[CONTACT_MIDDLE].Text).Trim()}',"; // contact_middle_initial
				IQuery = $"{IQuery}'{modAdminCommon.Fix_Quote(Text1[CONTACT_LAST].Text).Trim()}',"; // contact_last_name
				IQuery = $"{IQuery}'{modAdminCommon.Fix_Quote(cmb_suffix.Text).Trim()}',"; // contact_suffix

				if (cmb_contact_title.Text.Trim() != modGlobalVars.cEmptyString)
				{
					IQuery = $"{IQuery}'{modAdminCommon.Fix_Quote(cmb_contact_title.Text).Trim()}',"; // contact_title
					IQuery = $"{IQuery}'{DateTime.Parse(modAdminCommon.DateToday).ToString("d").Trim()}',"; // contact_title_confirm_date
				}
				else
				{
					IQuery = $"{IQuery}null,";
					IQuery = $"{IQuery}null,";
				}

				if (Text1[contact_email].Text != modGlobalVars.cEmptyString)
				{
					IQuery = $"{IQuery}'{modAdminCommon.Fix_Quote(Text1[contact_email].Text).Trim()}',"; // e-mail address
					IQuery = $"{IQuery}'{DateTime.Parse(modAdminCommon.DateToday).ToString("d").Trim()}',"; // contact_email_confirm_date
				}
				else
				{
					IQuery = $"{IQuery}null,";
					IQuery = $"{IQuery}null,";
				}

				IQuery = $"{IQuery}'Y',"; // contact_active_flag
				if (chk_hide_from_customer.CheckState == CheckState.Checked)
				{ // contact_hide_flag
					IQuery = $"{IQuery}'Y',";
				}
				else
				{
					IQuery = $"{IQuery}'N',";
				}

				if (chk_hide_from_customer.CheckState == CheckState.Checked)
				{ // contact_research_flag
					IQuery = $"{IQuery}'Y',";
				}
				else
				{
					IQuery = $"{IQuery}'N',";
				}

				if (Text1[CONTACT_ACPROSEQNO].Text.Trim() == modGlobalVars.cEmptyString)
				{
					IQuery = $"{IQuery}0,"; // contact_acpros_seq_no
				}
				else
				{
					if (Convert.ToInt32(Conversion.Val(Text1[CONTACT_ACPROSEQNO].Text)) > 0 && Convert.ToInt32(Conversion.Val(Text1[CONTACT_ACPROSEQNO].Text)) < 100)
					{
						IQuery = $"{IQuery}{Text1[CONTACT_ACPROSEQNO].Text},"; // contact_acpros_seq_no
					}
					else
					{
						IQuery = $"{IQuery}0,"; // contact_acpros_seq_no
					}
				}

				IQuery = $"{IQuery}'{DateTime.Parse(modAdminCommon.DateToday).ToString("d").Trim()}',"; // contact_name_confirm_date

				if (!Save_CompanyContact_Phone_Info(in_CompanyID, n_nextContactID, false))
				{
					MessageBox.Show("Error Saving Contact Phone Number(s)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					IQuery = $"{IQuery}'null',"; // contact_phone_confirm_date
					return result;
				}
				else
				{
					IQuery = $"{IQuery}'{DateTime.Parse(modAdminCommon.DateToday).ToString("d").Trim()}',"; // contact_phone_confirm_date
				}

				// 05/25/2018 - By David D. Cruger; Added
				IQuery = $"{IQuery}'{modAdminCommon.gbl_User_ID}') ";

				lbl_status_display.Text = "Adding New Company Contact...";
				lbl_status_display.Refresh();


				DbCommand TempCommand = null;
				ErrorHandlingHelper.ResumeNext(
					() => {TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();}, 
					() => {UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);}, 
					() => {TempCommand.CommandText = IQuery;}, 
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					() => {TempCommand.CommandType = CommandType.Text;}, // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					() => {UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);}, 
					() => {TempCommand.ExecuteNonQuery();});


				result = true;

				lbl_status_display.Text = "Adding New Company Contact, Completed...";
				lbl_status_display.Refresh();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lbl_status_display.Text = $"Adding New Company Contact Error ** {Information.Err().Number.ToString()} {excep.Message}";
				lbl_status_display.Refresh();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Quick_Insert_Company_Error:(Quick_Insert_Company_Contact_Error) {Information.Err().Number.ToString()} {excep.Message}");
			}

			return result;
		}

		private bool Quick_Insert_Research_Note(int in_CompanyID, int in_ContactID)
		{

			bool result = false;
			try
			{

				result = false;

				modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
				modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
				modAdminCommon.Rec_Journal_Info.journ_subject = Text1[JOURNAL_SUBJECT].Text;
				modAdminCommon.Rec_Journal_Info.journ_description = Text1[JOURNAL_INTERNAL_NOTES].Text;
				modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
				modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;

				if (in_ContactID > 0 && chk_attach_to_contact.CheckState == CheckState.Checked)
				{
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
				}
				else
				{
					modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
				}

				modAdminCommon.Rec_Journal_Info.journ_account_id = cmb_account_id.Text.Trim();
				modAdminCommon.Rec_Journal_Info.journ_prior_account_id = " ";
				modAdminCommon.Rec_Journal_Info.journ_status = "A";

				// show the contact ID for this new company
				Text1[Journal_ID].Enabled = true;
				Text1[Journal_ID].Text = frm_Journal.DefInstance.Commit_Journal_Entry().ToString();
				Text1[Journal_ID].Enabled = false;

				result = true;

				lbl_status_display.Text = $"Adding New {((in_ContactID > 0 && chk_attach_to_contact.CheckState == CheckState.Checked) ? "Company" : "Contact")} Research Note, Completed...";
				lbl_status_display.Refresh();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Quick_Insert_Company_Error:(Quick_Insert_Research_Note_Error) {Information.Err().Number.ToString()} {excep.Message}");

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lbl_status_display.Text = $"Adding {((in_ContactID > 0 && chk_attach_to_contact.CheckState == CheckState.Checked) ? "Company" : "Contact")} Research Note Error ** {Information.Err().Number.ToString()} {excep.Message}";
				lbl_status_display.Refresh();
			}

			return result;
		}
	}
}