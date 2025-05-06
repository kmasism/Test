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
	internal static class modEMailNotice
	{



		private static string ReturnContactName(int lContactId, int lJournId, bool bIncludeTitle = false)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strResults = "";

			try
			{

				strResults = "";

				if (lContactId > 0)
				{

					if (lJournId < 0)
					{
						lJournId = 0;
					}

					strQuery1 = "SELECT TOP 1 ";
					strQuery1 = $"{strQuery1}dbo.CreateContactFullNameTitle(contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, ";
					if (bIncludeTitle)
					{
						strQuery1 = $"{strQuery1}contact_title";
					}
					else
					{
						strQuery1 = $"{strQuery1}''";
					}
					strQuery1 = $"{strQuery1}) As Contact ";

					strQuery1 = $"{strQuery1}FROM Contact WITH (NOLOCK) WHERE (contact_id = {lContactId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (contact_journ_id = {lJournId.ToString()}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						strResults = ($"{Convert.ToString(rstRec1["CONTACT"])} ").Trim();
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lContactId > 0 Then

				rstRec1 = null;

				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("ReturnContactName_Error", excep.Message);
				result = "";
			}
			return result;
		} // ReturnContactName

		private static string ReturnContactEMailAddress(int lContactId, int lJournId)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strResults = "";

			try
			{

				strResults = "";

				if (lContactId > 0)
				{

					if (lJournId < 0)
					{
						lJournId = 0;
					}

					strQuery1 = "SELECT TOP 1 contact_email_address FROM Contact WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (contact_id = {lContactId.ToString()}) AND (contact_journ_id = {lJournId.ToString()}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						strResults = ($"{Convert.ToString(rstRec1["contact_email_address"])} ").Trim();
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lContactId > 0 Then

				rstRec1 = null;

				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("ReturnContactEMailAddress_Error", excep.Message);
				result = "";
			}
			return result;
		} // ReturnContactEMailAddress

		private static string ReturnContactSalLastName(int lContactId, int lJournId)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strResults = "";

			try
			{

				strResults = "";

				if (lContactId > 0)
				{

					if (lJournId < 0)
					{
						lJournId = 0;
					}

					strQuery1 = "SELECT TOP 1  dbo.CreateContactFullNameTitle(contact_sirname, '', '', contact_last_name, '', '') As Contact ";
					strQuery1 = $"{strQuery1}FROM Contact WITH (NOLOCK) WHERE (contact_id = {lContactId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (contact_journ_id = {lJournId.ToString()}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						strResults = ($"{Convert.ToString(rstRec1["CONTACT"])} ").Trim();
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lContactId > 0 Then

				rstRec1 = null;

				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("ReturnContactSalLastName_Error", excep.Message);
				result = "";
			}
			return result;
		} // ReturnContactSalLastName

		private static void ReturnCurrentUserInformation(ref string strUserName, ref string strUserPhoneNbr, ref string strUserExt, ref string strUserEMail)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				strUserName = "";
				strUserPhoneNbr = "";
				strUserExt = "";
				strUserEMail = "";

				strQuery1 = "SELECT user_id, user_first_name, user_last_name, user_phone_no, user_phone_no_ext, user_email_address";
				strQuery1 = $"{strQuery1} FROM [User] WITH (NOLOCK)  WHERE (user_id = '{modAdminCommon.gbl_User_ID}')";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					strUserName = $"{($"{Convert.ToString(rstRec1["user_first_name"])} ").Trim()} {($"{Convert.ToString(rstRec1["user_last_name"])} ").Trim()}";
					strUserPhoneNbr = ($"{Convert.ToString(rstRec1["user_phone_no"])} ").Trim();
					strUserExt = ($"{Convert.ToString(rstRec1["user_phone_no_ext"])} ").Trim();
					strUserEMail = ($"{Convert.ToString(rstRec1["user_email_address"])} ").Trim();

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("ReturnCurrentUserInformation_Error", excep.Message);
			}

		} // ReturnCurrentUserInformation

		private static string ReturnCompanyInformationHTML(int lCompId, int lJournId)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strQuery2 = "";
			string strResults = "";
			StringBuilder strBody = new StringBuilder();

			try
			{

				strResults = "";
				strBody = new StringBuilder("");

				if (lCompId > 0)
				{

					if (lJournId < 0)
					{
						lJournId = 0;
					}

					strQuery1 = $"SELECT TOP 1 * FROM Company WITH (NOLOCK) WHERE (comp_id = {lCompId.ToString()})  AND (comp_journ_id = {lJournId.ToString()}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						strBody.Append($"<pre>{Environment.NewLine}");
						strBody.Append($"<font face='Courier New'>{Environment.NewLine}");
						strBody.Append($"{new string('=', 60)}{Environment.NewLine}{Environment.NewLine}");
						strBody.Append($"Company Id     : ({lCompId.ToString()}){Environment.NewLine}");
						strBody.Append($"Company Name   : {($"{Convert.ToString(rstRec1["comp_name"])} ").Trim()}{Environment.NewLine}");
						strBody.Append($"Alt-Name (DBA) : {($"{Convert.ToString(rstRec1["comp_name_alt_type"])} ").Trim()} {($"{Convert.ToString(rstRec1["comp_name_alt"])} ").Trim()}{Environment.NewLine}");
						strBody.Append($"Address 1      : {($"{Convert.ToString(rstRec1["comp_address1"])} ").Trim()}{Environment.NewLine}");
						strBody.Append($"Address 2      : {($"{Convert.ToString(rstRec1["Comp_address2"])} ").Trim()}{Environment.NewLine}");
						strBody.Append($"City           : {($"{Convert.ToString(rstRec1["comp_city"])} ").Trim()}{Environment.NewLine}");
						strBody.Append($"State          : {($"{Convert.ToString(rstRec1["comp_state"])} ").Trim()}{Environment.NewLine}");
						strBody.Append($"Zip Code       : {($"{Convert.ToString(rstRec1["Comp_zip_code"])} ").Trim()}{Environment.NewLine}");
						strBody.Append($"Country        : {($"{Convert.ToString(rstRec1["Comp_country"])} ").Trim()}{Environment.NewLine}");
						strBody.Append($"WebSite        : {($"{Convert.ToString(rstRec1["comp_web_address"])} ").Trim()}{Environment.NewLine}");
						strBody.Append($"EMail Address  : {($"{Convert.ToString(rstRec1["comp_email_address"])} ").Trim()}{Environment.NewLine}{Environment.NewLine}");
						strBody.Append($"Company Phone Numbers{Environment.NewLine}");

						strQuery2 = "SELECT * FROM Phone_Numbers WITH (NOLOCK) INNER JOIN Phone_Type WITH (NOLOCK) ON ptype_name = pnum_type ";
						strQuery2 = $"{strQuery2}WHERE (pnum_comp_id = {lCompId.ToString()}) ";
						strQuery2 = $"{strQuery2}AND (pnum_journ_id = {lJournId.ToString()}) AND (pnum_contact_id = 0) ";
						strQuery2 = $"{strQuery2}AND (pnum_number_full IS NOT NULL) AND (pnum_number_full <> '') ORDER BY ptype_seq_no ";

						rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec2.BOF && !rstRec2.EOF)
						{

							do 
							{ // Loop Until rstRec2.EOF = True

								strBody.Append($"{($"{Convert.ToString(rstRec2["pnum_type"])} ").Trim()}{new string(' ', 15 - Strings.Len(($"{Convert.ToString(rstRec2["pnum_type"])} ").Trim()))}: {($"{Convert.ToString(rstRec2["pnum_number_full"])} ").Trim()}{Environment.NewLine}");
								rstRec2.MoveNext();

							}
							while(!rstRec2.EOF);

						}
						else
						{
							strBody.Append($"No Phone Numbers On File{Environment.NewLine}");
						} // If rstRec2.BOF = False And rstRec2.EOF = False Then

						strBody.Append($"</font>{Environment.NewLine}");
						strBody.Append($"</pre>{Environment.NewLine}");

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lContactId > 0 Then

				rstRec1 = null;
				rstRec2 = null;

				strResults = strBody.ToString();

				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("ReturnCompanyInformationHTML_Error", excep.Message);
				result = "";
			}
			return result;
		} // ReturnCompanyInformationHTML


		private static string ReturnAllContactInformationHTML(int lCompId, int lJournId, bool bIncludeHiddenContacts)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strQuery2 = "";
			string strResults = "";
			StringBuilder strBody = new StringBuilder();
			int lContactId = 0;

			try
			{

				strResults = "";
				strBody = new StringBuilder("");

				if (lCompId > 0)
				{

					if (lJournId < 0)
					{
						lJournId = 0;
					}

					strQuery1 = $"SELECT * FROM Contact WITH (NOLOCK) WHERE (contact_comp_id = {lCompId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (contact_journ_id = {lJournId.ToString()}) AND (contact_active_flag = 'Y') ";
					if (!bIncludeHiddenContacts)
					{
						strQuery1 = $"{strQuery1}AND (contact_hide_flag = 'N') ";
					}
					strQuery1 = $"{strQuery1}ORDER BY contact_acpros_seq_no ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						strBody.Append($"Company Contact Names{Environment.NewLine}{Environment.NewLine}");

						do 
						{ // Loop Until rstRec1.EOF = True

							lContactId = Convert.ToInt32(rstRec1["contact_id"]);

							strBody.Append($"<pre>{Environment.NewLine}");
							strBody.Append($"<font face='Courier New'>{Environment.NewLine}");
							strBody.Append($"Sir Name       : {($"{Convert.ToString(rstRec1["contact_sirname"])} ").Trim()}{Environment.NewLine}");
							strBody.Append($"First Name     : {($"{Convert.ToString(rstRec1["contact_first_name"])} ").Trim()}{Environment.NewLine}");
							strBody.Append($"Middle Init    : {($"{Convert.ToString(rstRec1["contact_middle_initial"])} ").Trim()}{Environment.NewLine}");
							strBody.Append($"Last Name      : {($"{Convert.ToString(rstRec1["contact_last_name"])} ").Trim()}{Environment.NewLine}");
							strBody.Append($"Sufix          : {($"{Convert.ToString(rstRec1["contact_suffix"])} ").Trim()}{Environment.NewLine}");
							strBody.Append($"Title          : {($"{Convert.ToString(rstRec1["contact_title"])} ").Trim()}{Environment.NewLine}");
							strBody.Append($"EMail Address  : {($"{Convert.ToString(rstRec1["contact_email_address"])} ").Trim()}{Environment.NewLine}");

							strQuery2 = "SELECT * FROM Phone_Numbers WITH (NOLOCK) INNER JOIN Phone_Type WITH (NOLOCK) ON ptype_name = pnum_type ";
							strQuery2 = $"{strQuery2}WHERE (pnum_comp_id = {lCompId.ToString()}) ";
							strQuery2 = $"{strQuery2}AND (pnum_journ_id = {lJournId.ToString()})  AND (pnum_contact_id = {lContactId.ToString()}) ";
							strQuery2 = $"{strQuery2}AND (pnum_number_full IS NOT NULL) AND (pnum_number_full <> '') ORDER BY ptype_seq_no ";

							rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							if (!rstRec2.BOF && !rstRec2.EOF)
							{

								strBody.Append($"Phone Number(s){Environment.NewLine}");

								do 
								{ // Loop Until rstRec2.EOF = True

									strBody.Append($"{($"{Convert.ToString(rstRec2["pnum_type"])} ").Trim()}{new string(' ', 15 - Strings.Len(($"{Convert.ToString(rstRec2["pnum_type"])} ").Trim()))}: {($"{Convert.ToString(rstRec2["pnum_number_full"])} ").Trim()}{Environment.NewLine}");
									rstRec2.MoveNext();

								}
								while(!rstRec2.EOF);

							}
							else
							{
								strBody.Append($"No Contact Phone Numbers On File{Environment.NewLine}");
							} // If rstRec2.BOF = False And rstRec2.EOF = False Then

							rstRec2.Close();

							strBody.Append(Environment.NewLine);

							rstRec1.MoveNext();

						}
						while(!rstRec1.EOF);

						strBody.Append($"</font>{Environment.NewLine}");
						strBody.Append($"</pre>{Environment.NewLine}");
					}
					else
					{
						strBody.Append($"No Contacts On File{Environment.NewLine}");
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lContactId > 0 Then

				rstRec1 = null;
				rstRec2 = null;

				strResults = strBody.ToString();

				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("ReturnAllContactInformationHTML_Error", excep.Message);
				result = "";
			}
			return result;
		} // ReturnAllContactInformationHTML

		private static string ReturnUserSignature(bool bHTML = true)
		{


			string strResults = "";

			if (bHTML)
			{
				strResults = modCommon.ReturnUsersHTMLSignature();
			}
			else
			{
				strResults = modCommon.ReturnUsersTextSignature();
			} //

			return strResults;

		} // ReturnUserSignature

		private static string ReturnAvDataPassword(string lCompId)
		{


			string strResults = modCommon.DLookUp("comp_avdata_id", "Company WITH (NOLOCK)", $"(comp_id = {lCompId}) AND (comp_journ_id = 0) ");

			return strResults;

		} // ReturnAvDataPassword


		internal static void ReturnEMailNotices(int lCompId, int lContactId, int lACId, int lYachtId, int lNoticeId, ref string strName, ref string strDesc, ref string strESubject, ref string strJSubCat, ref string strJSubject, ref string strBody)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strCompId = "";
			string strContactId = "";

			string strContact = "";
			string strSALLASTNAME = "";
			string strRESEARCHER = "";
			string strYEAR = "";
			string strINIT = "";
			string strSIGNATURE = "";
			string strCOMPANYINFORMATION = "";
			string strCONTACTINFORMATION = "";
			string strAVDATAPASSWORD = "";

			string strUserPhoneNbr = "";
			string strUserExt = "";
			string strUserEMail = "";

			try
			{

				ReturnCurrentUserInformation(ref strRESEARCHER, ref strUserPhoneNbr, ref strUserExt, ref strUserEMail);

				strYEAR = DateTime.Now.ToString("yyyy");
				strINIT = modAdminCommon.gbl_User_ID.ToUpper();
				strCompId = lCompId.ToString();
				strContactId = lContactId.ToString();

				strContact = "";
				strSALLASTNAME = "";
				strSIGNATURE = "";
				strCOMPANYINFORMATION = "";
				strCONTACTINFORMATION = "";
				strAVDATAPASSWORD = "";

				strName = "";
				strDesc = "";
				strESubject = "";
				strJSubCat = "";
				strJSubject = "";
				strBody = "";

				if (lNoticeId > 0)
				{

					strQuery1 = "SELECT TOP 1 * FROM EMail_Notices WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (em_id = {lNoticeId.ToString()}) AND (em_active_flag = 'Y') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						strName = ($"{Convert.ToString(rstRec1["em_name"])} ").Trim();
						strDesc = ($"{Convert.ToString(rstRec1["em_description"])} ").Trim();
						strESubject = ($"{Convert.ToString(rstRec1["em_email_subject"])} ").Trim();
						strJSubCat = ($"{Convert.ToString(rstRec1["em_journ_subcat_code"])} ").Trim();
						strJSubject = ($"{Convert.ToString(rstRec1["em_journ_subject"])} ").Trim();
						strBody = ($"{Convert.ToString(rstRec1["em_body"])} ").Trim();

						if (strJSubject.IndexOf("{EMAILSUBJECT}") >= 0)
						{
							strJSubject = StringsHelper.Replace(strJSubject, "{EMAILSUBJECT}", strESubject, 1, -1, CompareMethod.Binary);
						}

						//----------------------
						// Variables Used Body

						if (strBody.IndexOf("{CONTACT}") >= 0)
						{
							strContact = ReturnContactName(lContactId, 0, false);
							strBody = StringsHelper.Replace(strBody, "{CONTACT}", strContact, 1, -1, CompareMethod.Binary);
						}

						if (strBody.IndexOf("{SALLASTNAME}") >= 0)
						{
							strSALLASTNAME = ReturnContactSalLastName(lContactId, 0);
							strBody = StringsHelper.Replace(strBody, "{SALLASTNAME}", strSALLASTNAME, 1, -1, CompareMethod.Binary);
						}

						if (strBody.IndexOf("{EMAILSUBJECT}") >= 0)
						{
							strBody = StringsHelper.Replace(strBody, "{EMAILSUBJECT}", strESubject, 1, -1, CompareMethod.Binary);
						}

						if (strBody.IndexOf("{RESEARCHER}") >= 0)
						{
							strBody = StringsHelper.Replace(strBody, "{RESEARCHER}", strRESEARCHER, 1, -1, CompareMethod.Binary);
						}

						if (strBody.IndexOf("{YEAR}") >= 0)
						{
							strBody = StringsHelper.Replace(strBody, "{YEAR}", strYEAR, 1, -1, CompareMethod.Binary);
						}

						if (strBody.IndexOf("{INIT}") >= 0)
						{
							strBody = StringsHelper.Replace(strBody, "{INIT}", strINIT, 1, -1, CompareMethod.Binary);
						}

						if (strBody.IndexOf("{COMPID}") >= 0)
						{
							strBody = StringsHelper.Replace(strBody, "{COMPID}", lCompId.ToString(), 1, -1, CompareMethod.Binary);
						}

						if (strBody.IndexOf("{CONTACTID}") >= 0)
						{
							strBody = StringsHelper.Replace(strBody, "{CONTACTID}", lContactId.ToString(), 1, -1, CompareMethod.Binary);
						}

						if (strBody.IndexOf("{SIGNATUREHTML}") >= 0)
						{
							strSIGNATURE = ReturnUserSignature(true);
							strBody = StringsHelper.Replace(strBody, "{SIGNATUREHTML}", strSIGNATURE, 1, -1, CompareMethod.Binary);
						}

						if (strBody.IndexOf("{SIGNATURETEXT}") >= 0)
						{
							strSIGNATURE = ReturnUserSignature(false);
							strBody = StringsHelper.Replace(strBody, "{SIGNATURETEXT}", strSIGNATURE, 1, -1, CompareMethod.Binary);
						}

						if (strBody.IndexOf("{COMPANYINFORMATION}") >= 0)
						{
							strCOMPANYINFORMATION = ReturnCompanyInformationHTML(lCompId, 0);
							strBody = StringsHelper.Replace(strBody, "{COMPANYINFORMATION}", strCOMPANYINFORMATION, 1, -1, CompareMethod.Binary);
						}

						if (strBody.IndexOf("{CONTACTINFORMATION}") >= 0)
						{
							if ((strJSubject.ToUpper().IndexOf("INCLUDE HIDDEN CONTACTS") + 1) == 0)
							{
								strCONTACTINFORMATION = ReturnAllContactInformationHTML(lCompId, 0, false);
							}
							else
							{
								strCONTACTINFORMATION = ReturnAllContactInformationHTML(lCompId, 0, true);
							}
							strBody = StringsHelper.Replace(strBody, "{CONTACTINFORMATION}", strCONTACTINFORMATION, 1, -1, CompareMethod.Binary);
						}

						if (strBody.IndexOf("{AVDATAPASSWORD}") >= 0)
						{
							strAVDATAPASSWORD = ReturnAvDataPassword(lCompId.ToString());
							strBody = StringsHelper.Replace(strBody, "{AVDATAPASSWORD}", strAVDATAPASSWORD, 1, -1, CompareMethod.Binary);
						}

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lNoticeId > 0 Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("ReturnEMailNotices_Error", excep.Message);
			}

		} // ReturnEMailNotices


		internal static void Send_EMail_Notice(int lEMId, int lCompId, int lContactId, int lAircraftId, int lYachtId, string force_send_to_email = "")
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strInsert1 = "";

			string strErrDesc = "";
			string strMsg = "";
			string strType = "";

			string strEMDesc = "";

			string strToContact = "";

			string strTo = "";
			string strCC = "";
			string strBCC = "";
			string strSendTo = "";
			string strEMailSubject = "";
			string strBody = "";
			string strAttachment = "";
			string strHTMLFlag = "";
			string strStatus = "";
			string strReplyName = "";
			string strReplyEMail = "";
			string strSMTPServer = "";
			int lSMTPPort = 0;
			string strSMTPUserName = "";
			string strSMTPPassWord = "";
			string strErrorMsg = "";
			string strErrMsg = "";
			string strJournalSubCatCode = "";
			string strJournalSubject = "";

			string strUserName = "";
			string strUserEMail = "";

			string strDateTime = "";

			string strNoticeName = "";
			string strNoticeDesc = "";
			bool bTrans = false;
			string[] contact_Array = null;
			int temp_comp_id = 0;
			int temp_contact_id = 0;
			string contact_id_list = "";
			int number_of_contacts = 0;

			try
			{

				bTrans = false;
				strErrorMsg = "";
				strErrMsg = "";

				if (lEMId > 0)
				{

					if (lCompId > 0)
					{

						if (lContactId > 0)
						{

							// ADDED IN MSW - 6/5/18
							string tempRefParam = "";
							contact_id_list = modCompany.Confirm_Matching_Contacts(lContactId, ref number_of_contacts, "", ref tempRefParam, lCompId, true);

							strQuery1 = "SELECT user_id, user_first_name, user_last_name, user_phone_no, user_phone_no_ext, user_email_address";
							strQuery1 = $"{strQuery1} FROM [User] WITH (NOLOCK)  WHERE (user_id = '{modAdminCommon.gbl_User_ID}')";

							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							if (!rstRec1.BOF && !rstRec1.EOF)
							{

								strUserName = $"{($"{Convert.ToString(rstRec1["user_first_name"])} ").Trim()} {($"{Convert.ToString(rstRec1["user_last_name"])} ").Trim()}";

								strUserEMail = ($"{Convert.ToString(rstRec1["user_email_address"])} ").Trim();

								if (strUserEMail != "")
								{

									ReturnEMailNotices(lCompId, lContactId, 0, 0, lEMId, ref strNoticeName, ref strNoticeDesc, ref strEMailSubject, ref strJournalSubCatCode, ref strJournalSubject, ref strBody);

									if (strNoticeName != "")
									{

										if (strBody != "" && strBody != "External")
										{

											strToContact = ReturnContactName(lContactId, 0, false);

											if (strToContact != "")
											{


												// added MSW - 12/18/2020---------------
												if (force_send_to_email.Trim() != "")
												{
													strTo = force_send_to_email;
												}
												else
												{
													strTo = ReturnContactEMailAddress(lContactId, 0);
												}


												if (strTo != "")
												{

													if (MessageBox.Show($"Send {strNoticeName}{Environment.NewLine}{Environment.NewLine}{strEMailSubject} EMail.{Environment.NewLine}{Environment.NewLine}To: {strToContact}{Environment.NewLine}{Environment.NewLine}Are You Sure?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
													{


														strCC = "";
														strBCC = "";
														strStatus = "Open";
														strAttachment = "";
														strHTMLFlag = "Y";

														strReplyName = strUserName;
														strReplyEMail = strUserEMail;

														strSMTPServer = modCommon.DLookUp("aconfig_email_smtp_server", "Application_Configuration");
														lSMTPPort = Convert.ToInt32(Double.Parse(modCommon.DLookUp("aconfig_smtp_port", "Application_Configuration")));
														strSMTPUserName = modCommon.DLookUp("aconfig_email_username", "Application_Configuration");
														strSMTPPassWord = modCommon.DLookUp("aconfig_email_password", "Application_Configuration");

														if (modEmail.Insert_EMail_Queue_Record(strTo, strCC, strBCC, strEMailSubject, strBody, strAttachment, strHTMLFlag, strStatus, strReplyName, strReplyEMail, strSMTPServer, lSMTPPort, strSMTPUserName, strSMTPPassWord, ref strErrorMsg, lCompId, lContactId))
														{

															modEmail.Send_All_EMail_In_Queue(ref strErrorMsg, lCompId);

															if (strErrorMsg.Trim() == "")
															{

																strDateTime = DateTimeHelper.ToString(DateTime.Now);
																strInsert1 = "INSERT INTO Journal ( journ_subcategory_code, journ_subject, journ_contact_id, ";
																strInsert1 = $"{strInsert1}journ_comp_id, journ_user_id, journ_status,  journ_entry_date, journ_entry_time, ";
																strInsert1 = $"{strInsert1}journ_action_date, journ_date ) VALUES (";
																strInsert1 = $"{strInsert1}'{strJournalSubCatCode}',  '{strJournalSubject}', ";
																strInsert1 = $"{strInsert1}{lContactId.ToString()}, {lCompId.ToString()}, '{modAdminCommon.gbl_User_ID}', 'A', ";
																strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}', ";
																strInsert1 = $"{strInsert1}'{Strings.FormatDateTime(DateTime.Parse(strDateTime), DateFormat.ShortTime)}', ";
																strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString()}', ";
																strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}') ";

																bTrans = true;
																modAdminCommon.ADO_Transaction("BeginTrans");
																DbCommand TempCommand = null;
																TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
																UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
																TempCommand.CommandText = strInsert1;
																//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
																//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
																TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
																UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
																TempCommand.ExecuteNonQuery();
																modAdminCommon.ADO_Transaction("CommitTrans");
																bTrans = false;

																// ADDED IN MSW - 6/5/18
																if (contact_id_list.Trim() != "")
																{

																	contact_Array = contact_id_list.Split(',');

																	int tempForEndVar = number_of_contacts - 1;
																	for (int i = 0; i <= tempForEndVar; i++)
																	{

																		temp_contact_id = Convert.ToInt32(Double.Parse(StringsHelper.Replace(contact_Array[i], "'", "", 1, -1, CompareMethod.Binary)));
																		temp_comp_id = modCompany.Get_Company_ID(temp_contact_id);

																		modAdminCommon.Rec_Journal_Info.journ_subject = strJournalSubject;
																		modAdminCommon.Rec_Journal_Info.journ_description = $"Original EMail Sent To: CompId ({lCompId.ToString()})  ContactId ({lContactId.ToString()})  EMail ({strTo}) ";
																		modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
																		modAdminCommon.Rec_Journal_Info.journ_subcategory_code = strJournalSubCatCode;
																		modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(strDateTime);
																		modAdminCommon.Rec_Journal_Info.journ_comp_id = temp_comp_id;
																		modAdminCommon.Rec_Journal_Info.journ_contact_id = temp_contact_id;
																		modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
																		modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
																		modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
																		modAdminCommon.Rec_Journal_Info.journ_status = "A";

																		frm_Journal.DefInstance.Commit_Journal_Entry();
																	}

																}

															}
															else
															{
																strErrMsg = $"Send EMail Notice ERROR- {strErrorMsg}";
															} // If Trim(strErrorMsg) = "" Then

														}
														else
														{
															strErrMsg = "Unable To Insert EMail InTo Queue";
														} // If Insert_EMail_Queue_Record(strTo, strCC, strBCC, strSubject, strBody, strAttachment, strHTMLFlag

													}
													else
													{
														modAdminCommon.Record_Event("Send EMail Notice", "MsgBox To Send User Clicked NO", 0, 0, lCompId, false, 0, lContactId);
													} // If MsgBox("Send " & strNoticeName & vbCrLf & vbCrLf & strEMailSubject & " EMail." & vbCrLf & vbCrLf & "To: " & strToContact & vbCrLf & vbCrLf & "Are You Sure?", vbYesNo) = vbYes Then

												}
												else
												{
													strErrMsg = $"Unable To Find To Contact EMail Address For [{strToContact}]";
												} //If strTo <> "" Then

											}
											else
											{
												strErrMsg = $"Unable To Find To Contact Name For Contact Id [{lContactId.ToString()}]";
											} // If strToContact <> "" Then

										}
										else
										{
											strErrMsg = $"EMail Body Is Blank Or External For [{strNoticeName}]";
										} // If strBody <> "" And strBody <> "External" Then

									}
									else
									{
										strErrMsg = $"Unable To Find EMail_Notices Record For lEMId [{lEMId.ToString()}]";
									} // If strNoticeName <> "" Then

								}
								else
								{
									strErrMsg = "User Does Not Have An EMail Adress Associated With This Account";
								} // If strUserEMail <> "" Then

							}
							else
							{
								strErrMsg = "Unable To Find User Account Record";
							} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

							rstRec1.Close();

						}
						else
						{
							strErrMsg = "lContactId Is Blank Or Zero";
						} // If lContactId > 0 Then

					}
					else
					{
						strErrMsg = "lCompId Is Blank Or Zero";
					} // If lCompId > 0 Then

				}
				else
				{
					strErrMsg = "lEMId Is Blank Or Zero";
				} // If lEMId > 0 Then

				if (strErrMsg != "")
				{
					modAdminCommon.Record_Event("Send EMail Notice", strErrMsg, 0, 0, lCompId, false, 0, lContactId);
					MessageBox.Show(strErrMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error | MessageBoxIcon.Error);
				}

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;
				if (bTrans)
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
				}

				modAdminCommon.Report_Error("Send_EMail_Notice_Error", strErrDesc);
			}

		} // Send_EMail_Notice
	}
}