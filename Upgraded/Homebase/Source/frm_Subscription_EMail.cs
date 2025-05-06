using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_Subscription_EMail
		: System.Windows.Forms.Form
	{



		private int glSubId = 0;
		private int giNbrInstalls = 0;
		private string gstrLogin = "";
		private string gstrPassword = "";
		private string gstrCompany = "";
		private string gstrContact = "";
		private int glCompanyID = 0;
		private int glContactID = 0;
		private string gstrProduct = "";
		private string gstrService = "";
		private string gstrFrequency = "";
		private bool gbDemo = false;

		private string gstrSMTPReplyEMail = "";
		private string gstrSMTPReplyName = "";
		private string gstrSMTPServerName = "";
		private int glSMTPPort = 0;
		private string gstrSMTPUserName = "";
		private string gstrSMTPPassWord = "";
		public frm_Subscription_EMail()
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




		public void SetEMailNew() => optEMailNew.Checked = true;


		public void SetEMailResend() => optEMailReSend.Checked = true;


		public void SetEMailDemo() => optEMailDemo.Checked = true;


		public void SetTherese() => optTherese.Checked = true;



		public void SetJason() => optJason.Checked = true;


		public void SetPaul() => optPaul.Checked = true;



		public void SetKen() => optKen.Checked = true;



		public void SetKarim() => optKarim.Checked = true;


		public void SetStephanie() => optStephanie.Checked = true;



		public void SetGeneric() => optGeneric.Checked = true;



		public void SetSubId(int lSubId)
		{
			glSubId = lSubId;
			lblSubIdData.Text = lSubId.ToString();
			lblSubIdData.Refresh();
		}

		public void SetCompanyId(int lCompanyId) => glCompanyID = lCompanyId;


		public int GetCompanyID() => glCompanyID;


		public void SetContactID(int lContactId) => glContactID = lContactId;



		public void SetNbrInstalls(int iNbrInstalls) => giNbrInstalls = iNbrInstalls;



		public void SetLoginName(string strLogin)
		{
			gstrLogin = strLogin;
			lblLoginData.Text = strLogin;
			lblLoginData.Refresh();
		}


		public void SetPassword(string strPassword)
		{
			gstrPassword = strPassword;
			lblPasswordData.Text = strPassword;
			lblPasswordData.Refresh();
		}


		public void SetCompany(string strCompany)
		{
			gstrCompany = strCompany;
			lblCompanyData.Text = strCompany;
			lblCompanyData.Refresh();
		}


		public void SetService(string strService)
		{
			gstrService = strService;
			lblServiceData.Text = $"{gstrProduct}, {strService}, {gstrFrequency}";
			lblServiceData.Refresh();
		}


		public void SetProduct(string strProduct)
		{
			gstrProduct = strProduct;
			lblServiceData.Text = $"{strProduct}, {gstrService}, {gstrFrequency}";
			lblServiceData.Refresh();
		}


		public void SetFrequency(string strFrequency)
		{
			gstrFrequency = strFrequency;
			lblServiceData.Text = $"{gstrProduct}, {gstrService}, {strFrequency}";
			lblServiceData.Refresh();
		}

		public int GetContactID() => glContactID;



		private void cmdCancelEMail_Click(Object eventSender, EventArgs eventArgs) => this.Hide();


		private string ReturnCompanyContactInformationHTML(int lCompId, int lContactId, int lJournId)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strResults = "";
			string strBody = "";

			try
			{

				strResults = "";
				strBody = "";
				gstrContact = "";

				if (lCompId > 0)
				{

					if (lContactId > 0)
					{

						if (lJournId < 0)
						{
							lJournId = 0;
						}

						strQuery1 = "SELECT TOP 1 C1.*, dbo.CreateContactFullNameTitle(contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, '') As ContactName ";
						strQuery1 = $"{strQuery1}FROM Company AS C1 WITH (NOLOCK)  INNER JOIN Contact AS CT1 WITH (NOLOCK) ON CT1.contact_comp_id = C1.comp_id AND CT1.contact_journ_id = C1.comp_journ_id ";
						strQuery1 = $"{strQuery1}WHERE (comp_id = {lCompId.ToString()}) ";
						strQuery1 = $"{strQuery1}AND (contact_id = {lContactId.ToString()})  AND (comp_journ_id = {lJournId.ToString()}) ";

						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							gstrContact = txtEMailName.Text;

							strBody = $"{strBody}{gstrContact}<br/>{Environment.NewLine}";
							strBody = $"{strBody}{($"{Convert.ToString(rstRec1["comp_name"])} ").Trim()}<br/>{Environment.NewLine}";

							if (($"{Convert.ToString(rstRec1["comp_name_alt"])} ").Trim() != "")
							{
								strBody = $"{strBody}{($"{Convert.ToString(rstRec1["comp_name_alt_type"])} ").Trim()} {($"{Convert.ToString(rstRec1["comp_name_alt"])} ").Trim()}<br/>{Environment.NewLine}";
							}

							if (($"{Convert.ToString(rstRec1["comp_address1"])} ").Trim() != "")
							{
								strBody = $"{strBody}{($"{Convert.ToString(rstRec1["comp_address1"])} ").Trim()}<br/>{Environment.NewLine}";
							}

							if (($"{Convert.ToString(rstRec1["Comp_address2"])} ").Trim() != "")
							{
								strBody = $"{strBody}{($"{Convert.ToString(rstRec1["Comp_address2"])} ").Trim()}<br/>{Environment.NewLine}";
							}

							if (($"{Convert.ToString(rstRec1["Comp_city"])} ").Trim() != "" || ($"{Convert.ToString(rstRec1["comp_state"])} ").Trim() != "" || ($"{Convert.ToString(rstRec1["Comp_zip_code"])} ").Trim() != "")
							{
								strBody = $"{strBody}{($"{Convert.ToString(rstRec1["Comp_city"])} ").Trim()}, {($"{Convert.ToString(rstRec1["comp_state"])} ").Trim()} {($"{Convert.ToString(rstRec1["Comp_zip_code"])} ").Trim()}<br/>{Environment.NewLine}";
							}

							if (($"{Convert.ToString(rstRec1["Comp_country"])} ").Trim() != "")
							{
								strBody = $"{strBody}{($"{Convert.ToString(rstRec1["Comp_country"])} ").Trim()}<br/>{Environment.NewLine}";
							}

						}
						else
						{
							gstrContact = txtEMailName.Text;
						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

						rstRec1.Close();

					}
					else
					{
						gstrContact = txtEMailName.Text;
					} // If lContactId > 0 Then

				} // If lCompId > 0 Then

				rstRec1 = null;

				strResults = strBody;


				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("ReturnCompanyContactInformationHTML_Error", excep.Message);

				result = "";
			}
			return result;
		} // ReturnCompanyContactInformationHTML


		private bool EMail_Subscriber_HTML_Message(string strSMTPServer, int lSMTPPort, string strSMTPUserName, string strSMTPPassWord, string strFromName, string strFromEMail, string strTo, string strCC, string strBCC, string strSubject, string strBody, string strAttachment, ref string strErrorMsg)
		{
			bool result = false;
			Chilkat_v9_5_0.ChilkatMailMan EMailMan = new Chilkat_v9_5_0.ChilkatMailMan();
			Chilkat_v9_5_0.ChilkatEmail EMail2 = new Chilkat_v9_5_0.ChilkatEmail();
			int lSMTPTImeOut = 0;
			int lResults = 0;
			string[] aEMail = null;

			bool bResults = false;
			int iErrCnt = 0;

			try
			{

				bResults = false; // Default
				strErrorMsg = "";

				if ((strTo != "") && (strSubject != "") && (strFromEMail != "") && (strSMTPServer != ""))
				{

					strTo = StringsHelper.Replace(strTo, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's
					strCC = StringsHelper.Replace(strCC, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's
					strBCC = StringsHelper.Replace(strBCC, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's

					lResults = EMailMan.UnlockComponent(modGlobalVars.gstrChilkatUnlockCode); // 10/24/2017

					if (lResults == 1)
					{

						lSMTPTImeOut = 30000;

						EMailMan.ConnectTimeout = lSMTPTImeOut;
						EMailMan.SmtpHost = strSMTPServer;
						EMailMan.SmtpPort = lSMTPPort;
						EMailMan.SmtpUsername = strSMTPUserName;
						EMailMan.SmtpPassword = strSMTPPassWord;

						// MSW - 8/24/2020 ---
						modCommon.gbUseTLS = true;
						if (modCommon.gbUseTLS)
						{
							EMailMan.SmtpSsl = 1; //
							EMailMan.SslProtocol = "TLS 1.2 or higher";
							EMailMan.StartTls = 1;
							EMailMan.PreferIpv6 = 1;
							EMailMan.RequireSslCertVerify = 1;
						}

						//---------------------------------------

						EMail2.fromName = strFromName;
						EMail2.FromAddress = strFromEMail;


						if (strTo.IndexOf(',') >= 0)
						{
							aEMail = strTo.Split(',');
							int tempForEndVar = aEMail.GetUpperBound(0);
							for (int lCnt1 = 0; lCnt1 <= tempForEndVar; lCnt1++)
							{
								EMail2.AddTo("", aEMail[lCnt1]);
							}
						}
						else
						{
							EMail2.AddTo("", strTo);
						}

						if (strCC.IndexOf(',') >= 0)
						{
							aEMail = strCC.Split(',');
							int tempForEndVar2 = aEMail.GetUpperBound(0);
							for (int lCnt1 = 0; lCnt1 <= tempForEndVar2; lCnt1++)
							{
								EMail2.AddCC("", aEMail[lCnt1]);
							}
						}
						else
						{
							EMail2.AddCC("", strCC);
						}

						//-----------------------------------
						//  Process All BCC EMail Addresses

						if (strBCC.IndexOf(',') >= 0)
						{
							aEMail = strBCC.Split(',');
							int tempForEndVar3 = aEMail.GetUpperBound(0);
							for (int lCnt1 = 0; lCnt1 <= tempForEndVar3; lCnt1++)
							{
								EMail2.AddBcc("", aEMail[lCnt1]);
							}
						}
						else
						{
							EMail2.AddBcc("", strBCC);
						}

						EMail2.subject = strSubject;

						EMail2.SetHtmlBody(strBody);

						if (strAttachment != "")
						{
							if (File.Exists(strAttachment))
							{
								EMail2.AddFileAttachment(strAttachment);
							}
						}

						lResults = EMailMan.SendEmail(EMail2);

						if (lResults == 1)
						{
							bResults = true;
						}
						else
						{
							modAdminCommon.Record_Error("EMail_Subscriber_HTML_Message", "Error Sending EMail");
						}

						EMailMan.CloseSmtpConnection();

					}
					else
					{
						modAdminCommon.Record_Error("EMail_Subscriber_HTML_Message", "Unable To Unlock SMTP Control");
					} // If lResults = 1 Then

				}
				else
				{
					strErrorMsg = "To, Subject, From EMail or SMTP Server are blank";
				} // If (strTo <> "") And (strSubject <> "") And (strFromEMail <> "") And (strSMTPServer <> "") Then

				EMail2 = null;
				EMailMan = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strErrorMsg = $"EMail_Subscriber_HTML_Message_Error: {excep.Message}";
				modAdminCommon.Report_Error(strErrorMsg);

				bResults = false; // Failed
				result = bResults;
			}
			return result;
		} // End Function EMail_Subscriber_HTML_Message


		private void Send_All_EMail_In_Queue(ref string strErrorMsg)
		{

			Object fso = new Object();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lCnt1 = 0;

			int lEMailqId = 0;
			int lErrorCnt = 0;

			string strService = "";
			string strReplyName = "";
			string strReplyEMail = "";
			string strSMTPServer = "";
			int lSMTPPort = 0;
			string strSMTPUserName = "";
			string strSMTPPassWord = "";

			string strFrom = "";
			string strTo = "";
			string strCC = "";
			string strBCC = "";
			string strSubject = "";
			string strBody = "";
			string strAttachment = "";

			string strStatus = "";
			string strOnHoldFlag = "";
			string strHTMLFlag = "";

			StringBuilder strMsg = new StringBuilder();
			bool bResults = false;

			try
			{

				strService = "CustService";

				strQuery1 = $"SELECT * FROM EMail_Queue  WHERE (emailq_service = '{strService}') ";
				strQuery1 = $"{strQuery1}AND (emailq_status = 'Open') AND (emailq_onhold_flag = 'N') ";
				strQuery1 = $"{strQuery1}ORDER BY emailq_id";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lCnt1 = 0;

					do 
					{ // Loop Until (rstRec1.EOF = True)

						strErrorMsg = "";
						strFrom = "";

						lEMailqId = Convert.ToInt32(rstRec1["emailq_id"]);
						lErrorCnt = Convert.ToInt32(rstRec1["emailq_errorcnt"]);

						strService = ($"{Convert.ToString(rstRec1["emailq_service"])} ").Trim();
						strReplyName = ($"{Convert.ToString(rstRec1["emailq_replyname"])} ").Trim();
						strReplyEMail = ($"{Convert.ToString(rstRec1["emailq_replyemail"])} ").Trim();
						strSMTPServer = ($"{Convert.ToString(rstRec1["emailq_smtp_server"])} ").Trim();
						lSMTPPort = Convert.ToInt32(rstRec1["emailq_smtp_port"]);
						strSMTPUserName = ($"{Convert.ToString(rstRec1["emailq_smtp_username"])} ").Trim();
						strSMTPPassWord = ($"{Convert.ToString(rstRec1["emailq_smtp_password"])} ").Trim();

						strFrom = strReplyEMail;

						strTo = ($"{Convert.ToString(rstRec1["emailq_to"])} ").Trim();
						strCC = ($"{Convert.ToString(rstRec1["emailq_cc"])} ").Trim();
						strBCC = ($"{Convert.ToString(rstRec1["emailq_bcc"])} ").Trim();

						strTo = StringsHelper.Replace(strTo, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's
						strCC = StringsHelper.Replace(strCC, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's
						strBCC = StringsHelper.Replace(strBCC, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's

						strSubject = ($"{Convert.ToString(rstRec1["emailq_subject"])} ").Trim();
						strBody = ($"{Convert.ToString(rstRec1["emailq_body"])} ").Trim();
						strAttachment = ($"{Convert.ToString(rstRec1["emailq_attachment"])} ").Trim();

						strStatus = ($"{Convert.ToString(rstRec1["emailq_status"])} ").Trim();
						strOnHoldFlag = ($"{Convert.ToString(rstRec1["emailq_onhold_flag"])} ").Trim();
						strHTMLFlag = ($"{Convert.ToString(rstRec1["emailq_html_flag"])} ").Trim();

						bResults = false;

						if (strAttachment != "")
						{
							if (!File.Exists(strAttachment))
							{
								bResults = false;
								strErrorMsg = "Attachment Does NOT Exist";
							}
						}

						if (strErrorMsg == "")
						{ //Still ok to Send EMail

							if (EMail_Subscriber_HTML_Message(strSMTPServer, lSMTPPort, strSMTPUserName, strSMTPPassWord, strReplyName, strReplyEMail, strTo, strCC, strBCC, strSubject, strBody, strAttachment, ref strErrorMsg))
							{
								bResults = true;
							}

						} // If strErrorMsg = "" Then 'Still ok to Send EMail

						if (bResults)
						{
							strStatus = "Completed";
							strErrorMsg = "";
							lErrorCnt = 0;
							strOnHoldFlag = "N";
						}
						else
						{
							strStatus = "Failed";
							lErrorCnt++;
							if (lErrorCnt >= 5)
							{
								strOnHoldFlag = "Y";
							}
						}

						strMsg = new StringBuilder($"   !-{strStatus}");
						if (strErrorMsg != "")
						{
							strMsg.Append($" : {strErrorMsg}");
						}

						rstRec1["emailq_update_date"] = DateTime.Now;
						rstRec1["emailq_status"] = strStatus;
						rstRec1["emailq_errormsg"] = strErrorMsg;
						rstRec1["emailq_errorcnt"] = lErrorCnt;
						rstRec1["emailq_onhold_flag"] = strOnHoldFlag;

						rstRec1.Update();

						lCnt1++;
						rstRec1.MoveNext();

					}
					while(!(rstRec1.EOF));

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
				fso = null;
			}
			catch (System.Exception excep)
			{

				strErrorMsg = $"Send_All_EMail_In_Queue_Error: {excep.Message}";
				modAdminCommon.Record_Error("EMAIL", strErrorMsg);
				MessageBox.Show(strErrorMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		} // End Procedure Send_All_EMail_In_Queue

		private string ReturnEMailLogo()
		{


			string strHTML = "";
			strHTML = "<p align='left'><img width='500' src='http://www.jetnet.com/images/jetnet_logo_with_address.png'/></p>";

			return strHTML;

		} // ReturnEMailLogo

		private string ReturnEMailFooter()
		{


			string strHTML = "";
			strHTML = "<p align='right'><img width='150' src='http://www.jetnet.com/images/know_more.png'/></p>";

			return strHTML;

		} // ReturnEMailFooter

		//UPGRADE_NOTE: (7001) The following declaration (ReturnEMailWebSiteHRef) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private string ReturnEMailWebSiteHRef()
		//{
			//
			//
			//string strHTML = "";
			//
			//if (optEvoDotNet.Checked)
			//{
				//strHTML = $"{strHTML}<a target='_blank' href='http://www.jetnetevolution.com'>www.jetnetevolution.com</a>";
				//
			//}
			//
			//if (optYachtSpot.Checked)
			//{
				//// strHTML = strHTML & "<a target='_blank' href='http://www.yacht-spotonline.com'>www.yacht-spotonline.com</a>"
				//if (frm_Subscription.DefInstance.chkProductType[modSubscription.ProductBusinessAC].CheckState == CheckState.Checked || frm_Subscription.DefInstance.chkProductType[modSubscription.ProductHelicopters].CheckState == CheckState.Checked || frm_Subscription.DefInstance.chkProductType[modSubscription.ProductCommercial].CheckState == CheckState.Checked)
				//{
					//strHTML = $"{strHTML} Or <a target='_blank' href='http://www.jetnetevolution.com'>www.jetnetevolution.com</a>";
				//}
			//}
			//
			//return strHTML;
			//
		//} // ReturnEMailWebSiteHRef


		private string AddFromToBodyOfEMail()
		{

			string strLinks = "";
			string strAddress = "";

			string strBody = $"<p>{Environment.NewLine}";
			strBody = $"{strBody}<span style='font-family:Arial;color:#616E7D;font-size:12.0pt'>{Environment.NewLine}";

			string strExt = "";

			if (optTherese.Checked)
			{
				strBody = $"{strBody}<b>Therese M. Trondsen</b> >> Customer Technical Support | Trade Show Director<br>{Environment.NewLine}";
				strExt = modCommon.DLookUp("user_phone_no_ext", "[User]", "([user_id] = 'tmt') AND (user_password <> 'inactive')");
			}

			if (optJason.Checked)
			{
				strBody = $"{strBody}<b>Jason A. Lorraine</b> >> Customer Technical Support & Sales<br>{Environment.NewLine}";
				strExt = modCommon.DLookUp("user_phone_no_ext", "[User]", "([user_id] = 'jal') AND (user_password <> 'inactive')");
			}

			if (optPaul.Checked)
			{
				strBody = $"{strBody}<b>Paul Cardarelli</b> >> Director of Sales & Marketing<br>{Environment.NewLine}";
				strExt = modCommon.DLookUp("user_phone_no_ext", "[User]", "([user_id] = 'pec') AND (user_password <> 'inactive')");
			}

			if (optKen.Checked)
			{
				strBody = $"{strBody}<b>Ken Green</b> >> AvData Systems Data Analyst<br>{Environment.NewLine}";
				strExt = modCommon.DLookUp("user_phone_no_ext", "[User]", "([user_id] = 'kg') AND (user_password <> 'inactive')");
			}

			if (optKarim.Checked)
			{
				strBody = $"{strBody}<b>Karim Derbala</b> >> Managing Director of Global Sales<br>{Environment.NewLine}";
				strExt = modCommon.DLookUp("user_phone_no_ext", "[User]", "([user_id] = 'khd') AND (user_password <> 'inactive')");
			}

			if (optStephanie.Checked)
			{
				strBody = $"{strBody}<b>Stephanie Hryb</b> >> Customer Technical Support<br>{Environment.NewLine}";
				strExt = modCommon.DLookUp("user_phone_no_ext", "[User]", "([user_id] = 'slh') AND (user_password <> 'inactive')");
			}

			if (optGeneric.Checked)
			{
				if (optEMailDemo.Checked)
				{
					strBody = $"{strBody}<b>Marketing and Sales Support</b><br>{Environment.NewLine}";
				}
				else
				{
					strBody = $"{strBody}<b>Customer Technical Support</b><br>{Environment.NewLine}";
				}

			} // If optGeneric.Value = True Then

			strBody = $"{strBody}</span>{Environment.NewLine}";

			strBody = $"{strBody}<b><span style='font-family:Arial;color:#616E7D;font-size:12.0pt'>{Environment.NewLine}";
			strBody = $"{strBody}<a href='http://www.jetnet.com'>jetnet.com</a>{Environment.NewLine}";
			strBody = $"{strBody}<br/></span></b>{Environment.NewLine}";

			strBody = $"{strBody}<span style='font-family:Arial;color:black;font-size:10.0pt'>{Environment.NewLine}";
			if (optKarim.Checked)
			{
				strBody = $"{strBody}41-43-243-7056 Zurich<br/>{Environment.NewLine}";
				strBody = $"{strBody}315-797-4420 x845 New York<br/>{Environment.NewLine}";
			}
			else
			{
				strBody = $"{strBody}800-553-8638<br/>{Environment.NewLine}";
				strBody = $"{strBody}315-797-4420";
				if (strExt != "")
				{
					strBody = $"{strBody} x{strExt}";
				}
				strBody = $"{strBody}<br/>{Environment.NewLine}";
			}
			strBody = $"{strBody}</span>{Environment.NewLine}";

			strBody = $"{strBody}<span style='font-family:Arial;color:#8D9AB1;font-size:10.0pt'>{Environment.NewLine}";
			strBody = $"{strBody}Worldwide leader in aviation market intelligence.{Environment.NewLine}";
			strBody = $"{strBody}</span>{Environment.NewLine}";

			if (optGeneric.Checked)
			{
				strBody = $"{strBody}<br/>{Environment.NewLine}";
				strBody = $"{strBody}<font face='Arial' size='3'>{Environment.NewLine}";
				strBody = $"{strBody}EMail: <a href='mailto:customerservice@jetnet.com'>customerservice@jetnet.com</a><br/>{Environment.NewLine}";
				strBody = $"{strBody}</font>{Environment.NewLine}";
			}

			strBody = $"{strBody}</p>{Environment.NewLine}";

			return strBody;

		} // AddFromToBodyOfEMail

		private string Create_Reset_Password_And_Create_URL_Link(int lCompId, int lContactId, int lSubId, string strLogin, string strEMail)
		{

			DbConnection cntConn1 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn1 = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strUpdate1 = "";

			string strToken = "";
			string strBase64Token = "";

			string strCompId = "";
			string strContactId = "";
			string strSubId = "";
			string strMsg = "";

			rstRec1 = null;
			cntConn1 = null;

			string strResults = "";
			string strDate = StringsHelper.Format(DateTime.Now, "mm/dd/yyyy hh:MM:ss AMPM");
			string strGUID = modCommon.GetGUID(true);
			string strURL = "";

			if (lCompId > 0)
			{

				strCompId = lCompId.ToString();

				if (lContactId > 0)
				{

					strContactId = lContactId.ToString();

					if (lSubId > 0)
					{

						strSubId = lSubId.ToString();

						if (strLogin != "")
						{

							if (strEMail != "")
							{

								strToken = $"{strGUID},{strDate},{strCompId},{strContactId},{strSubId},{strEMail},{strLogin}";
								strBase64Token = modSubscription.SQL_Base64_Encode(strToken);

								strURL = "https://www.jetnetevolution.com/forgotPasswordVerify.aspx?forgotToken={token}&newUser=true";
								strURL = StringsHelper.Replace(strURL, "{token}", strBase64Token, 1, -1, CompareMethod.Binary);

								if (modSubscription.OpenRemoteDatabase())
								{

									strQuery1 = $"SELECT * FROM Subscription_Login WHERE (sublogin_sub_id = {strSubId}) ";
									strQuery1 = $"{strQuery1}AND (sublogin_login = '{strLogin}')  AND (sublogin_active_flag = 'Y') ";

									//-- Is Subscription Active
									strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM Subscription WITH (NOLOCK) ";
									strQuery1 = $"{strQuery1}             WHERE (sub_id = {strSubId}) ";
									strQuery1 = $"{strQuery1}             AND (sub_start_date <= GETDATE()) ";
									strQuery1 = $"{strQuery1}             AND (sub_end_date IS NULL OR sub_end_date > GETDATE()) ";
									strQuery1 = $"{strQuery1}            ) ";
									strQuery1 = $"{strQuery1}    ) ";

									//-- Is Subscription_Install Active
									strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM Subscription_Install WITH (NOLOCK) ";
									strQuery1 = $"{strQuery1}             WHERE (subins_sub_id = {strSubId}) ";
									strQuery1 = $"{strQuery1}             AND (subins_login = '{strLogin}') ";
									strQuery1 = $"{strQuery1}             AND (subins_active_flag = 'Y') ";
									strQuery1 = $"{strQuery1}             AND (subins_contact_id = {strContactId}) ";
									strQuery1 = $"{strQuery1}            ) ";
									strQuery1 = $"{strQuery1}    ) ";

									//-- Company Active
									strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM Company WITH (NOLOCK) ";
									strQuery1 = $"{strQuery1}             WHERE (comp_id = {strCompId}) ";
									strQuery1 = $"{strQuery1}             AND (comp_journ_id = 0) ";
									strQuery1 = $"{strQuery1}             AND (comp_active_flag = 'Y') ";
									strQuery1 = $"{strQuery1}             ) ";
									strQuery1 = $"{strQuery1}    ) ";

									//-- Contact Active And EMail Address
									strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM Contact WITH (NOLOCK) ";
									strQuery1 = $"{strQuery1}             WHERE (contact_id = {strContactId}) ";
									strQuery1 = $"{strQuery1}             AND (contact_journ_id = 0) ";
									strQuery1 = $"{strQuery1}             AND (contact_comp_id = {strCompId}) ";
									strQuery1 = $"{strQuery1}             AND (contact_email_address = '{strEMail}') ";
									strQuery1 = $"{strQuery1}             AND (contact_active_flag = 'Y') ";
									strQuery1 = $"{strQuery1}             ) ";
									strQuery1 = $"{strQuery1}    ) ";

									rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
									rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

									if (!rstRec1.BOF && !rstRec1.EOF)
									{

										if (rstRec1.RecordCount == 1)
										{
											rstRec1["sublogin_forgot_password_token"] = strGUID;
											rstRec1["sublogin_forgot_password_token_date"] = strDate;
											//rstRec1!sublogin_web_action_date = Null
											//rstRec1!sublogin_web_action_date = CDate("1/1/1900")
											rstRec1.UpdateBatch();

											// 05/19/2020 - By David D. Cruger
											// Update HB-Live with New Guild and Token Date
											// I don't believe this is required but just making sure
											// everything is in sync

											strUpdate1 = $"UPDATE Subscription_Login SET sublogin_forgot_password_token = '{strGUID}', ";
											strUpdate1 = $"{strUpdate1} sublogin_action_date = NULL, "; // clear the action date - MSW - 11/3/24
											strUpdate1 = $"{strUpdate1}sublogin_forgot_password_token_date = '{strDate}' ";
											strUpdate1 = $"{strUpdate1}WHERE (sublogin_sub_id = {strSubId}) ";
											strUpdate1 = $"{strUpdate1}AND (sublogin_login = '{strLogin}') AND (sublogin_active_flag = 'Y') ";

											DbCommand TempCommand = null;
											TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
											UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
											TempCommand.CommandText = strUpdate1;
											//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
											TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
											UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
											TempCommand.ExecuteNonQuery();

											strResults = strURL;

										}
										else
										{
											lblStatus.Text = "Can NOT Update - Returned More Than 1";
											MessageBox.Show(lblStatus.Text, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										} // If rstRec1.RecordCount = 1 Then

									}
									else
									{

										strMsg = $"Unable To Find Subscription/Login/Install or Contact On Evolution{Environment.NewLine}" +
										         $"  CompId: {strCompId}{Environment.NewLine}" +
										         $"  ContactId: {strContactId}{Environment.NewLine}" +
										         $"  SubId: {strSubId}{Environment.NewLine}" +
										         $"  Login: {strLogin}{Environment.NewLine}" +
										         $"  To EMail: {strEMail}";

										modAdminCommon.Record_Event("Sent Sub Notice EMail Failed", StringsHelper.Replace(strMsg, Environment.NewLine, " - ", 1, -1, CompareMethod.Binary), 0, 0, glCompanyID, false, 0, Convert.ToInt32(Double.Parse(strContactId)));

										MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

									} // If rstRec1.BOF = False And rstRec1.EOF = False Then

									rstRec1.Close();

									modSubscription.CloseRemoteDatabase();

								}
								else
								{
									MessageBox.Show("Unable To Open Evolution SQL Database", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If OpenRemoteData() = True Then

							} // If strEMail <> "" Then

						} // If strLogin <> "" Then

					} // If lSubId > 0 Then

				} // If lContactId > 0 Then

			} // If lCompId > 0 Then

			rstRec1 = null;

			return strResults;

		} // Create_Reset_Password_And_Create_URL_Link


		private string CreateEMailMessageForNewSubscriberNonActiveX(string strSubject)
		{

			string strTemp = "";

			string strBody = "";
			string strURL = Create_Reset_Password_And_Create_URL_Link(glCompanyID, glContactID, glSubId, gstrLogin, txtEMailAddressTo.Text);

			if (strURL != "")
			{

				strBody = $"<html><head><title>{strSubject}</title>{Environment.NewLine}";
				strBody = $"{strBody}</head>{Environment.NewLine}{Environment.NewLine}";
				strBody = $"{strBody}<body>{Environment.NewLine}";

				strBody = $"{strBody}{ReturnEMailLogo()}";

				strBody = $"{strBody}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}<font face='Arial' size='3'>{Environment.NewLine}";

				strBody = $"{strBody}{DateTime.Now.ToString("MMMM d, yyyy")}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}{ReturnCompanyContactInformationHTML(glCompanyID, glContactID, 0)}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}Dear {gstrContact}:<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}Thank you for subscribing to {gstrProduct}, {gstrService}, {gstrFrequency}. Your account has been activated to a permanent status as of {DateTime.Now.ToString("MMMM d, yyyy")}. Below are your login credentials for access to the website and Evolution platform.<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				if (optEvoDotNet.Checked)
				{
					// strBody = strBody & "Website: <a href='http://www.jetnetevolution.com'>www.jetnetevolution.com</a> or <a href='https://www.jetnetevomobile.com'>www.jetnetevomobile.com</a> from any mobile device.<br/><br/>" & vbCrLf & vbCrLf
					strBody = $"{strBody}Desktop/laptop access: <a href='http://www.jetnetevolution.com'>www.jetnetevolution.com</a><br/>";
					strBody = $"{strBody}Mobile device access: <a href='https://www.jetnetevomobile.com'>www.jetnetevomobile.com</a><br/><br/>{Environment.NewLine}{Environment.NewLine}";

				}

				strBody = $"{strBody}Login Email Address: {($"{txtEMailAddressTo.Text} ").Trim()}<br/>{Environment.NewLine}";
				strBody = $"{strBody}Click this link to set your password:<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}<table border='1'>{Environment.NewLine}";
				strBody = $"{strBody}<tr><th><a title='Set Password' href='{strURL}'>Set Password</a></th></tr>";
				strBody = $"{strBody}</table>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}<br/>{Environment.NewLine}"; // changed to 307 - msw - 6/10/21
				strBody = $"{strBody}If you have any questions, please contact JETNET's customer service team at 800-553-8638 Ext. 307 or email <a href='mailto:customerservice@jetnet.com'>customerservice@jetnet.com</a>. For your convenience, after logging into the program, click the Resource Center '?' icon at the top right to access JETNET's knowledge base, links to live training, product release notes, announcements, and additional ways to contact us.<br/><br/>";


				strBody = $"{strBody}Best regards,<br><br>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}{AddFromToBodyOfEMail()}";

				strBody = $"{strBody}</font>{Environment.NewLine}";

				strBody = $"{strBody}{ReturnEMailFooter()}";

				strBody = $"{strBody}</body></html>{Environment.NewLine}";

			}
			else
			{
				MessageBox.Show("Unable To Create Reset Password Token", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If strURL <> "" Then

			return strBody;

		} // CreateEMailMessageForNewSubscriberNonActiveX

		private string CreateEMailMessageForResendingNonActiveX(string strSubject)
		{

			string strTemp = "";

			string strBody = "";

			string strURL = Create_Reset_Password_And_Create_URL_Link(glCompanyID, glContactID, glSubId, gstrLogin, txtEMailAddressTo.Text);

			if (strURL != "")
			{

				strBody = $"<html><head><title>{strSubject}</title>{Environment.NewLine}";
				strBody = $"{strBody}</head><body>{Environment.NewLine}";

				strBody = $"{strBody}{ReturnEMailLogo()}";

				strBody = $"{strBody}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}<font face='Arial' size='3'>{Environment.NewLine}";

				strBody = $"{strBody}{DateTime.Now.ToString("MMMM d, yyyy")}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}{ReturnCompanyContactInformationHTML(glCompanyID, glContactID, 0)}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}Dear {gstrContact}:<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}Your request for your license information was received.  Below are your login credentials that will provide you access to the website and Evolution platform. Your current subscription provides you with access to {gstrProduct}, {gstrService}, {gstrFrequency}.<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				if (optEvoDotNet.Checked)
				{
					//strBody = strBody & "Website: <a href='http://www.jetnetevolution.com'>www.jetnetevolution.com</a> or <a href='https://www.jetnetevomobile.com'>www.jetnetevomobile.com</a> from any mobile device.<br/><br/>" & vbCrLf & vbCrLf
					strBody = $"{strBody}Desktop/laptop access: <a href='http://www.jetnetevolution.com'>www.jetnetevolution.com</a><br/>";
					strBody = $"{strBody}Mobile device access: <a href='https://www.jetnetevomobile.com'>www.jetnetevomobile.com</a><br/><br/>{Environment.NewLine}{Environment.NewLine}";

				}

				strBody = $"{strBody}Login Email Address: {($"{txtEMailAddressTo.Text} ").Trim()}<br/>{Environment.NewLine}";

				strBody = $"{strBody}Please Click the link below to set your password to begin accessing JETNET's Evolution website.<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}<table border='1'>{Environment.NewLine}";
				strBody = $"{strBody}<tr><th><a title='Set Password' href='{strURL}'>Set Password</a></th></tr>";
				strBody = $"{strBody}</table>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}<br/>{Environment.NewLine}";
				strBody = $"{strBody}If you have any questions, please contact JETNET's customer service team at 800-553-8638 Ext. 307 or email <a href='mailto:customerservice@jetnet.com'>customerservice@jetnet.com</a>. For your convenience, after logging into the program, click the Resource Center '?' icon at the top right to access JETNET's knowledge base, links to live training, product release notes, announcements, and additional ways to contact us.<br/><br/>";

				strBody = $"{strBody}Thank you for your continued support.<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}Best regards,<br><br>{Environment.NewLine}";

				strBody = $"{strBody}{AddFromToBodyOfEMail()}";

				strBody = $"{strBody}</font>{Environment.NewLine}";

				strBody = $"{strBody}{ReturnEMailFooter()}";

				strBody = $"{strBody}</body>{Environment.NewLine}";
				strBody = $"{strBody}</html>{Environment.NewLine}";

			}
			else
			{
				MessageBox.Show("Unable To Create Reset Password Token", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If strURL <> "" Then

			return strBody;

		} // CreateEMailMessageForResendingNonActiveX


		//UPGRADE_NOTE: (7001) The following declaration (CreateEMailMessageForRequestedPasswordNonActiveX) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private string CreateEMailMessageForRequestedPasswordNonActiveX(string strSubject)
		//{
			//
			//string strTemp = "";
			//
			//string strBody = "";
			//string strURL = Create_Reset_Password_And_Create_URL_Link(glCompanyID, glContactID, glSubId, gstrLogin, txtEMailAddressTo.Text);
			//
			//if (strURL != "")
			//{
				//
				//strBody = $"<html><head><title>{strSubject}</title>{Environment.NewLine}";
				//strBody = $"{strBody}</head><body>{Environment.NewLine}";
				//
				//strBody = $"{strBody}{ReturnEMailLogo()}";
				//
				//strBody = $"{strBody}<br/><br/>{Environment.NewLine}{Environment.NewLine}";
				//
				//strBody = $"{strBody}<font face='Arial' size='3'>{Environment.NewLine}";
				//
				//strBody = $"{strBody}{DateTime.Now.ToString("MMMM d, yyyy")}<br/><br/>{Environment.NewLine}{Environment.NewLine}";
				//
				//strBody = $"{strBody}{ReturnCompanyContactInformationHTML(glCompanyID, glContactID, 0)}<br/><br/>{Environment.NewLine}{Environment.NewLine}";
				//
				//
				//strBody = $"{strBody}Dear {gstrContact}:<br/><br/>{Environment.NewLine}{Environment.NewLine}";
				//
				//strBody = $"{strBody}You activated the request to have your password re-sent<br/><br/>{Environment.NewLine}{Environment.NewLine}";
				//
				//strBody = $"{strBody}Listed below is the updated license information for access to the website and Evolution platform for your subscription of {gstrProduct}, {gstrService}, {gstrFrequency}.<br/><br/>{Environment.NewLine}{Environment.NewLine}";
				//
				//if (optEvoDotNet.Checked)
				//{
					//strBody = $"{strBody}Website: <a href='http://www.jetnetevolution.com'>www.jetnetevolution.com</a> or <a href='https://www.jetnetevomobile.com'>www.jetnetevomobile.com</a> from any mobile device.<br/><br/>{Environment.NewLine}{Environment.NewLine}";
				//}
				//
				//strBody = $"{strBody}Login Email Address: {($"{txtEMailAddressTo.Text} ").Trim()}<br/>{Environment.NewLine}";
				////strBody = strBody & "Password: " & gstrPassword & "<br/><br/>" & vbCrLf & vbCrLf
				//strBody = $"{strBody}Please Click the link below to set your password to begin accessing JETNET's Evolution website.<br/><br/>{Environment.NewLine}{Environment.NewLine}";
				//
				//strBody = $"{strBody}<table border='1'>{Environment.NewLine}";
				//strBody = $"{strBody}<tr><th><a title='Set Password' href='{strURL}'>Set Password</a></th></tr>";
				//strBody = $"{strBody}</table>{Environment.NewLine}{Environment.NewLine}";
				//
				//strBody = $"{strBody}<br/>{Environment.NewLine}";
				//
				//strBody = $"{strBody}If you didn't request a 'forgot password', please contact the JETNET technical support team immediately.<br/><br/>";
				//
				//strBody = $"{strBody}Please do not hesitate to call 800-553-8638 Ext. 307 for any of your questions or program needs.<br/><br/>";
				//
				//strBody = $"{strBody}Best regards,<br><br>{Environment.NewLine}";
				//
				//strBody = $"{strBody}{AddFromToBodyOfEMail()}";
				//
				//strBody = $"{strBody}</font>{Environment.NewLine}";
				//
				//strBody = $"{strBody}{ReturnEMailFooter()}";
				//
				//strBody = $"{strBody}</body>{Environment.NewLine}";
				//strBody = $"{strBody}</html>{Environment.NewLine}";
				//
			//}
			//else
			//{
				//MessageBox.Show("Unable To Create Reset Password Token", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			//} // If strURL <> "" Then
			//
			//return strBody;
			//
		//} // CreateEMailMessageForRequestedPasswordNonActiveX


		private string CreateEMailMessageForDemoNonActiveX(string strSubject)
		{

			string strTemp = "";

			string strBody = $"<html>{Environment.NewLine}";
			strBody = $"{strBody}<head>{Environment.NewLine}";
			strBody = $"{strBody}<title>{strSubject}</title>{Environment.NewLine}";
			strBody = $"{strBody}</head>{Environment.NewLine}{Environment.NewLine}";
			strBody = $"{strBody}<body>{Environment.NewLine}";

			strBody = $"{strBody}{ReturnEMailLogo()}";

			strBody = $"{strBody}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

			strBody = $"{strBody}<font face='Arial' size='3'>{Environment.NewLine}";

			strBody = $"{strBody}{DateTime.Now.ToString("MMMM d, yyyy")}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

			strBody = $"{strBody}{ReturnCompanyContactInformationHTML(glCompanyID, glContactID, 0)}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

			strBody = $"{strBody}Dear {gstrContact}:<br/><br/>{Environment.NewLine}{Environment.NewLine}";

			strBody = $"{strBody}Thank you for your interest in {gstrProduct}, {gstrService}, {gstrFrequency}. You have been issued a temporary {gstrProduct} license for demonstration purpose of that program.  The login details are below with instructions on how to access the website and Evolution platform.<br><br>{Environment.NewLine}{Environment.NewLine}";

			if (optEvoDotNet.Checked)
			{
				//strBody = strBody & "Website: <a href='http://www.jetnetevolution.com'>www.jetnetevolution.com</a> or <a href='https://www.jetnetevomobile.com'>www.jetnetevomobile.com</a> from any mobile device.<br/><br/>" & vbCrLf & vbCrLf
				strBody = $"{strBody}Desktop/laptop access: <a href='http://www.jetnetevolution.com'>www.jetnetevolution.com</a><br/>";
				strBody = $"{strBody}Mobile device access: <a href='https://www.jetnetevomobile.com'>www.jetnetevomobile.com</a><br/><br/>{Environment.NewLine}{Environment.NewLine}";

			}
			strBody = $"{strBody}Login Email Address: demo@jetnet.com<br/>{Environment.NewLine}";
			strBody = $"{strBody}Password: {gstrPassword}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

			strBody = $"{strBody}<b>Click: <font color='blue'>LOG IN</font></b><br><br>{Environment.NewLine}{Environment.NewLine}";

			strBody = $"{strBody}<b><font color='blue'>Accept the License Agreement.</font></b><br><br>{Environment.NewLine}{Environment.NewLine}";

			strBody = $"{strBody}May we point you to several instructional videos and documents on the program by choosing Help from the Resources tab after you log in.  Please note that all export capabilities are turned off for demo accounts.<br/><br/>{Environment.NewLine}{Environment.NewLine}";

			strBody = $"{strBody}Do not hesitate to call with any questions regarding the {gstrProduct} program.  JETNET is looking forward to showing you all the unique features and tools the program can offer its subscribers.<br/><br/>{Environment.NewLine}{Environment.NewLine}";

			strBody = $"{strBody}Best regards,<br><br>{Environment.NewLine}{Environment.NewLine}";

			strBody = $"{strBody}{AddFromToBodyOfEMail()}";

			strBody = $"{strBody}</font>{Environment.NewLine}";

			strBody = $"{strBody}{ReturnEMailFooter()}";

			strBody = $"{strBody}</body>{Environment.NewLine}";
			strBody = $"{strBody}</html>{Environment.NewLine}";

			return strBody;

		} // CreateEMailMessageForDemoNonActiveX

		private string CreateEMailMessageForAddlLocationNonActiveX(string strSubject)
		{

			string strTemp = "";

			string strBody = "";
			string strURL = Create_Reset_Password_And_Create_URL_Link(glCompanyID, glContactID, glSubId, gstrLogin, txtEMailAddressTo.Text);

			if (strURL != "")
			{

				strBody = $"<html><head><title>{strSubject}</title>{Environment.NewLine}";
				strBody = $"{strBody}</head><body>{Environment.NewLine}";

				strBody = $"{strBody}{ReturnEMailLogo()}";

				strBody = $"{strBody}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}<font face='Arial' size='3'>{Environment.NewLine}";

				strBody = $"{strBody}{DateTime.Now.ToString("MMMM d, yyyy")}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}{ReturnCompanyContactInformationHTML(glCompanyID, glContactID, 0)}<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}Dear {gstrContact}:<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}JETNET has been advised by your company administrator to issue you a license for access to {gstrProduct}, {gstrService}, {gstrFrequency}. Your license has been activated and your login credentials to the website and Evolution platform are as follows:<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				if (optEvoDotNet.Checked)
				{
					// strBody = strBody & "Website: <a href='http://www.jetnetevolution.com'>www.jetnetevolution.com</a> or <a href='https://www.jetnetevomobile.com'>www.jetnetevomobile.com</a> from any mobile device.<br/><br/>" & vbCrLf & vbCrLf
					strBody = $"{strBody}Desktop/laptop access: <a href='http://www.jetnetevolution.com'>www.jetnetevolution.com</a><br/>";
					strBody = $"{strBody}Mobile device access: <a href='https://www.jetnetevomobile.com'>www.jetnetevomobile.com</a><br/><br/>{Environment.NewLine}{Environment.NewLine}";

				}

				strBody = $"{strBody}Login Email Address: {($"{txtEMailAddressTo.Text} ").Trim()}<br/>{Environment.NewLine}";

				strBody = $"{strBody}Please Click the link below to set your password to begin accessing JETNET's Evolution website.<br/><br/>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}<table border='1'>{Environment.NewLine}";
				strBody = $"{strBody}<tr><th><a title='Set Password' href='{strURL}'>Set Password</a></th></tr>";
				strBody = $"{strBody}</table>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}<br/>{Environment.NewLine}";

				strBody = $"{strBody}If you have any questions, please contact JETNET's customer service team at 800-553-8638 Ext. 307 or email <a href='mailto:customerservice@jetnet.com'>customerservice@jetnet.com</a>. For your convenience, after logging into the program, click the Resource Center '?' icon at the top right to access JETNET's knowledge base, links to live training, product release notes, announcements, and additional ways to contact us.<br/><br/>";

				strBody = $"{strBody}Best regards,<br><br>{Environment.NewLine}{Environment.NewLine}";

				strBody = $"{strBody}{AddFromToBodyOfEMail()}";

				strBody = $"{strBody}</font>{Environment.NewLine}";

				strBody = $"{strBody}{ReturnEMailFooter()}";

				strBody = $"{strBody}</body>{Environment.NewLine}";
				strBody = $"{strBody}</html>{Environment.NewLine}";

			}
			else
			{
				MessageBox.Show("Unable To Create Reset Password Token", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If strURL <> "" Then

			return strBody;

		} // CreateEMailMessageForAddlLocationNonActiveX

		private bool Insert_EMail_Queue_Record(string strTo, string strCC, string strBCC, string strSubject, string strBody, string strAttachment, string strHTMLFlag, string strStatus, ref string strErrorMsg)
		{

			bool result = false;
			string strService = "";
			string strReplyName = "";
			string strReplyEMail = "";
			string strSMTPServer = "";
			int lSMTPPort = 0;
			string strSMTPUserName = "";
			string strSMTPPassWord = "";

			string strInsert = "";
			bool bResults = false;

			try
			{

				strService = "CustService";

				strReplyName = gstrSMTPReplyName;
				strReplyEMail = gstrSMTPReplyEMail;
				strSMTPServer = gstrSMTPServerName;
				lSMTPPort = glSMTPPort;
				strSMTPUserName = gstrSMTPUserName;
				strSMTPPassWord = gstrSMTPPassWord;

				if ((strTo != "") && (strSubject != ""))
				{

					// 09/30/2020 - By David D. Cruger
					// Leave this alone for now
					//If strSMTPUserName = "service@jetnet.com" And (strReplyEMail = "jetnet@jetnet.com") Then
					//  strReplyEMail = strSMTPUserName
					//End If

					strTo = StringsHelper.Replace(strTo, "'", "''", 1, -1, CompareMethod.Binary);
					strCC = StringsHelper.Replace(strCC, "'", "''", 1, -1, CompareMethod.Binary);
					strBCC = StringsHelper.Replace(strBCC, "'", "''", 1, -1, CompareMethod.Binary);

					strTo = StringsHelper.Replace(strTo, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's
					strCC = StringsHelper.Replace(strCC, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's
					strBCC = StringsHelper.Replace(strBCC, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's

					strSubject = StringsHelper.Replace(strSubject, "'", "''", 1, -1, CompareMethod.Binary);
					strBody = StringsHelper.Replace(strBody, "'", "''", 1, -1, CompareMethod.Binary);
					strAttachment = StringsHelper.Replace(strAttachment, "'", "''", 1, -1, CompareMethod.Binary);
					strStatus = StringsHelper.Replace(strStatus, "'", "''", 1, -1, CompareMethod.Binary);
					strErrorMsg = StringsHelper.Replace(strErrorMsg, "'", "''", 1, -1, CompareMethod.Binary);

					strInsert = "INSERT INTO EMail_Queue (emailq_service, ";
					strInsert = $"{strInsert}emailq_replyname,emailq_replyemail, emailq_smtp_server, ";
					strInsert = $"{strInsert}emailq_smtp_port,emailq_smtp_username, emailq_smtp_password, ";
					strInsert = $"{strInsert}emailq_to,emailq_cc, emailq_bcc, emailq_subject,emailq_body, ";
					strInsert = $"{strInsert}emailq_attachment,emailq_status,emailq_errormsg, ";

					if (glCompanyID > 0)
					{
						strInsert = $"{strInsert}emailq_comp_id, ";
					}
					if (glContactID > 0)
					{
						strInsert = $"{strInsert}emailq_contact_id, ";
					}
					if (glSubId > 0)
					{
						strInsert = $"{strInsert}emailq_sub_id, ";
					}

					strInsert = $"{strInsert}emailq_html_flag) VALUES ('{strService}', ";
					strInsert = $"{strInsert}'{strReplyName}','{strReplyEMail}', ";
					strInsert = $"{strInsert}'{strSMTPServer}', ";
					strInsert = $"{strInsert}{lSMTPPort.ToString()}, '{strSMTPUserName}', ";
					strInsert = $"{strInsert}'{strSMTPPassWord}', ";
					strInsert = $"{strInsert}'{strTo}', '{strCC}',  '{strBCC}', ";
					strInsert = $"{strInsert}'{strSubject}', '{strBody}', ";
					strInsert = $"{strInsert}'{strAttachment}', '{strStatus}', ";
					strInsert = $"{strInsert}'{strErrorMsg}', ";

					if (glCompanyID > 0)
					{
						strInsert = $"{strInsert}{glCompanyID.ToString()}, ";
					}
					if (glContactID > 0)
					{
						strInsert = $"{strInsert}{glContactID.ToString()}, ";
					}
					if (glSubId > 0)
					{
						strInsert = $"{strInsert}{glSubId.ToString()}, ";
					}

					strInsert = $"{strInsert}'{strHTMLFlag}')";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strInsert;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					bResults = true;

				}
				else
				{
					strErrorMsg = "To or Subject Blank";
				} // If (strTo <> "") And (strSubject <> "") Then


				return bResults;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"Insert_EMail_Queue_Record_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

				bResults = false;
				result = bResults;
			}
			return result;
		} // Insert_EMail_Queue_Record



		private void cmdSendEMail_Click(Object eventSender, EventArgs eventArgs)
		{


			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			string strFrom = "";
			string strTo = "";
			string strCC = "";
			string strBCC = "";
			string strSubject = "";
			string strBody = "";
			string strAttachment = "";
			string strHTMLFlag = "";
			string strTemp = "";

			string strStatus = "";
			string strErrorMsg = "";
			string strReason = "";

			string strLogin = "";

			try
			{

				cmdSendEMail.Enabled = false;

				lblStatus.Text = "";

				gstrSMTPServerName = modCommon.DLookUp("aconfig_email_smtp_server", "Application_Configuration");
				glSMTPPort = Convert.ToInt32(Double.Parse(modCommon.DLookUp("aconfig_smtp_port", "Application_Configuration")));
				gstrSMTPUserName = modCommon.DLookUp("aconfig_email_username", "Application_Configuration");
				gstrSMTPPassWord = modCommon.DLookUp("aconfig_email_password", "Application_Configuration");

				if ((txtEMailName.Text != "") && (txtEMailAddressTo.Text != ""))
				{

					if (optTherese.Checked)
					{
						gstrSMTPReplyName = "Therese Trondsen";
						gstrSMTPReplyEMail = "therese@jetnet.com";
					}

					if (optJason.Checked)
					{
						gstrSMTPReplyName = "Jason Lorraine";
						gstrSMTPReplyEMail = "jason@jetnet.com";
					}

					if (optPaul.Checked)
					{
						gstrSMTPReplyName = "Paul Cardarelli";
						gstrSMTPReplyEMail = "paul@jetnet.com";
					}


					if (optKarim.Checked)
					{
						gstrSMTPReplyName = "Karim Derbala";
						gstrSMTPReplyEMail = "karim@jetnet.com";
					}

					if (optStephanie.Checked)
					{
						gstrSMTPReplyName = "Stephanie Hryb";
						gstrSMTPReplyEMail = "stephanie@jetnet.com";
					}

					if (optGeneric.Checked)
					{
						gstrSMTPReplyName = "Customer Service";
						gstrSMTPReplyEMail = "customerservice@jetnet.com";
					}

					strTo = txtEMailAddressTo.Text;
					strCC = txtEMailAddressCC.Text;
					strBCC = txtEMailAddressBCC.Text;

					if (strBCC == "")
					{
						strBCC = "jetnet@jetnet.com";
					}
					else
					{
						if ((strBCC.IndexOf("jetnet@jetnet.com") + 1) == 0)
						{
							strBCC = $"{strBCC},jetnet@jetnet.com";
						}
					}

					strSubject = $"JETNET - {gstrProduct} Setup License Info";

					strAttachment = "";
					strHTMLFlag = "Y";

					strBody = "";

					// changed areas here per greg - msw - 3/5/24
					if (optEMailNew.Checked)
					{
						lblStatus.Text = "Creating New Subscriber EMail";
						strBody = CreateEMailMessageForNewSubscriberNonActiveX(strSubject);
					}

					if (optEMailReSend.Checked)
					{
						lblStatus.Text = "Creating Resend Subscriber EMail";
						strBody = CreateEMailMessageForResendingNonActiveX(strSubject);
					}

					if (optEMailDemo.Checked)
					{
						lblStatus.Text = "Creating Demo Subscriber EMail";
						strBody = CreateEMailMessageForDemoNonActiveX(strSubject);
					}

					if (optEMailAddlLoc.Checked)
					{
						lblStatus.Text = "Creating Add'l Location Subscriber EMail";
						strBody = CreateEMailMessageForAddlLocationNonActiveX(strSubject);
					}

					if (strBody != "")
					{

						strErrorMsg = "";
						strStatus = "Open";

						// 05/28/2020 - By David D. Cruger Add Check To Make Sure Tokens Match

						if (!optEMailDemo.Checked)
						{

							lblStatus.Text = "Checking HB and Evo Token";
							lblStatus.Refresh();

							if (!modSubscription.DoesForgotPasswordTokenExistsOnHomebaseAndEvolution(glSubId, gstrLogin, ref strReason))
							{
								strMsg = $"Homebase and Evolution Reset Tokens Do NOT Match - CANCELLING EMAIL{Environment.NewLine}{Environment.NewLine}{strReason}";
								modAdminCommon.Record_Event("Sent Sub Notice EMail ERROR", strMsg, 0, 0, glCompanyID);
								MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								strBody = "";
							}

						} // If optEMailDemo.Value = False Then

						if (strBody != "")
						{

							lblStatus.Text = "Adding Message to EMail Queue";
							lblStatus.Refresh();

							if (Insert_EMail_Queue_Record(strTo, strCC, strBCC, strSubject, strBody, strAttachment, strHTMLFlag, strStatus, ref strErrorMsg))
							{

								lblStatus.Text = "Sending Messages in EMail Queue";
								lblStatus.Refresh();

								modCommon.Start_Activity_Monitor_Message("Send Subscription EMail", ref strMsg, ref dtStartDate, ref dtEndDate);

								Send_All_EMail_In_Queue(ref strErrorMsg);

								strTemp = $"SubId: {glSubId.ToString()}  Login: {gstrLogin}  Password: {gstrPassword}  To: {strTo}";
								strMsg = strTemp;

								if (strErrorMsg == "")
								{
									modAdminCommon.Record_Event("Sent Sub Notice EMail", strTemp, 0, 0, glCompanyID);
								}

								modCommon.End_Activity_Monitor_Message("Send Subscription EMail", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, glCompanyID, 0, 0);

								lblStatus.Text = "EMail Message Sent - OK";
								MessageBox.Show("EMail Message Sent - OK", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								this.Hide();

							}
							else
							{
								lblStatus.Text = "Adding Message to EMail Queue FAILED!!";
								MessageBox.Show("Adding Message to EMail Queue FAILED!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							}

						} // If strBody <> "" Then

					}
					else
					{
						lblStatus.Text = "Body of EMail Is Blank!!";
						MessageBox.Show("Body of EMail Is Blank!!  ERROR", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If strBody <> "" Then

				}
				else
				{
					lblStatus.Text = "EMail Name and/or Address Is Blank!!";
					MessageBox.Show("EMail Name and/or Address is Blank!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (txtEMailName.Text <> "") And (txtEMailAddressTo.Text <> "") Then

				cmdSendEMail.Enabled = true;
				lblStatus.Refresh();
			}
			catch (System.Exception excep)
			{

				lblStatus.Text = $"cmdSendEMail_Click_Error: {excep.Message}";
				MessageBox.Show($"cmdSendEMail_Click_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		} // End Function cmdSendEMail_Click


		private void Load_Contact_List_Box()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int lCnt1 = 0;

			try
			{

				lstbContactName.Items.Clear();

				strQuery1 = "SELECT contact_id, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix ";
				strQuery1 = $"{strQuery1}FROM Contact WITH (NOLOCK) WHERE (contact_comp_id = {glCompanyID.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (contact_journ_id = 0) AND (contact_active_flag = 'Y') ";
				strQuery1 = $"{strQuery1}AND (contact_email_address IS NOT NULL) AND (contact_email_address <> '') ";
				strQuery1 = $"{strQuery1}ORDER BY contact_first_name, contact_last_name ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lstbContactName.Enabled = true;
					lstbContactName.Visible = true;
					lblNoContactsOnFile.Visible = false;

					lCnt1 = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						lstbContactName.AddItem($"{($"{Convert.ToString(rstRec1["contact_sirname"])} ").Trim()} " +
						                        $"{($"{Convert.ToString(rstRec1["contact_first_name"])} ").Trim()} " +
						                        $"{($"{Convert.ToString(rstRec1["contact_middle_initial"])} ").Trim()} " +
						                        $"{($"{Convert.ToString(rstRec1["contact_last_name"])} ").Trim()} " +
						                        $"{($"{Convert.ToString(rstRec1["contact_suffix"])} ").Trim()}");

						lstbContactName.SetItemData(lCnt1, Convert.ToInt32(rstRec1["contact_id"]));

						rstRec1.MoveNext();

						if (!rstRec1.EOF)
						{
							lCnt1++;
						}

					}
					while(!rstRec1.EOF);

				}
				else
				{
					lstbContactName.Enabled = false;
					lstbContactName.Visible = false;
					lblNoContactsOnFile.Visible = true;
				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				lblStatus.Text = $"Load_Contact_List_Box_Error: {excep.Message}";
				MessageBox.Show(lblStatus.Text, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		} // Load_Contact_List_Box


		private void lstbContactName_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int lContactId = 0;

			string strContact = "";
			string strEMail = "";
			int lCnt1 = 0;

			try
			{

				txtEMailAddressCC.Text = "";

				if (lstbContactName.CheckedIndices.Count > 0)
				{

					strContact = ($"{lstbContactName.GetListItem(ListBoxHelper.GetSelectedIndex(lstbContactName))} ").Trim();

					if (strContact == txtEMailName.Text)
					{
						txtEMailName.Text = "";
						txtEMailAddressTo.Text = "";
						txtEMailAddressTo.Tag = "0";
					}

					lCnt1 = 0;

					do 
					{ // Loop Until lCnt1 >= lstbContactName.ListCount - 1

						if (lstbContactName.GetItemChecked(lCnt1))
						{

							strContact = ($"{lstbContactName.GetListItem(lCnt1)} ").Trim();
							lContactId = lstbContactName.GetItemData(lCnt1);

							if (lstbContactName.CheckedIndices.Count == 1)
							{
								glContactID = lContactId;
							}

							if (lContactId > 0 && strContact != "")
							{

								strQuery1 = "SELECT contact_email_address FROM Contact WITH (NOLOCK) ";
								strQuery1 = $"{strQuery1}WHERE (contact_comp_id = {glCompanyID.ToString()}) ";
								strQuery1 = $"{strQuery1}AND (contact_id = {lContactId.ToString()}) ";
								strQuery1 = $"{strQuery1}AND (contact_journ_id = 0)  AND (contact_active_flag = 'Y') ";
								strQuery1 = $"{strQuery1}AND (contact_email_address IS NOT NULL)  AND (contact_email_address <> '') ";

								rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								if ((!rstRec1.BOF) && (!rstRec1.EOF))
								{
									strEMail = ($"{Convert.ToString(rstRec1["contact_email_address"])} ").Trim();
									if (txtEMailAddressTo.Text == "")
									{
										txtEMailName.Text = $"{txtEMailName.Text}{strContact}";
										txtEMailAddressTo.Text = strEMail;
										txtEMailAddressTo.Tag = lContactId.ToString();
										glContactID = lContactId;
									}
									else
									{
										if (txtEMailAddressTo.Text != strEMail)
										{
											if ((txtEMailAddressCC.Text.IndexOf(strEMail) + 1) == 0)
											{
												txtEMailAddressCC.Text = $"{txtEMailAddressCC.Text}{strEMail};";
											}
										}
									}
									cmdSendEMail.Enabled = true;
								} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

								rstRec1.Close();

							} // If lContactId > 0 And strContact <> "" Then

						} // If lstbContactName.Selected(lCnt1) = True Then

						lCnt1++;

					}
					while(lCnt1 < lstbContactName.Items.Count);

					if (Strings.Len(txtEMailName.Text) > 0)
					{
						if (txtEMailAddressCC.Text != "")
						{
							if (txtEMailAddressCC.Text.Substring(Math.Max(txtEMailAddressCC.Text.Length - 1, 0)) == ";" || txtEMailAddressCC.Text.Substring(Math.Max(txtEMailAddressCC.Text.Length - 1, 0)) == ",")
							{
								txtEMailAddressCC.Text = txtEMailAddressCC.Text.Substring(0, Math.Min(Strings.Len(txtEMailAddressCC.Text) - 1, txtEMailAddressCC.Text.Length));
							}
						}
						if (txtEMailAddressBCC.Text != "")
						{
							if (txtEMailAddressBCC.Text.Substring(Math.Max(txtEMailAddressBCC.Text.Length - 1, 0)) == ";" || txtEMailAddressBCC.Text.Substring(Math.Max(txtEMailAddressBCC.Text.Length - 1, 0)) == ",")
							{
								txtEMailAddressBCC.Text = txtEMailAddressCC.Text.Substring(0, Math.Min(Strings.Len(txtEMailAddressBCC.Text) - 1, txtEMailAddressCC.Text.Length));
							}
						}
					}

				}
				else
				{
					txtEMailName.Text = "";
					txtEMailAddressTo.Text = "";
					txtEMailAddressTo.Tag = "0";
					txtEMailAddressCC.Text = "";
					cmdSendEMail.Enabled = false;
				} // If lstbContactName.SelCount > 0 Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				lblStatus.Text = $"lstbContactName_Click: {excep.Message}";
				MessageBox.Show(lblStatus.Text, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		} // lstbContactName_Click

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				Load_Contact_List_Box();
				this.Refresh();
			}
		}

		private void Form_Initialize()
		{

			glSubId = 0;
			giNbrInstalls = 0;
			gstrLogin = "";
			gstrPassword = "";
			gstrCompany = "";

			gstrProduct = "";
			gstrService = "";
			gstrFrequency = "";

			glCompanyID = 0;
			glContactID = 0;

			txtEMailName.Text = "";
			txtEMailAddressTo.Text = "";
			txtEMailAddressCC.Text = "";
			txtEMailAddressBCC.Text = "";

			cmdSendEMail.Enabled = false;

			gbDemo = false;
			if (frm_Subscription.DefInstance.chkProductType[modSubscription.ProductMarketing].CheckState == CheckState.Checked || frm_Subscription.DefInstance.chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState == CheckState.Checked)
			{
				lblStatus.Text = "Demo: demo@jetnet.com";
				gbDemo = true;
			} // frm_Subscription

			modCommon.CenterFormOnHomebaseMainForm(this);

		} // Form_Initialize

		private void txtEMailAddressTo_TextChanged(Object eventSender, EventArgs eventArgs) => cmdSendEMail.Enabled = !(($"{txtEMailName.Text} ").Trim() == "" || ($"{txtEMailAddressTo.Text} ").Trim() == "");
		 // txtEMailAddressTo_Change

		private void txtEMailName_TextChanged(Object eventSender, EventArgs eventArgs) => cmdSendEMail.Enabled = !(($"{txtEMailName.Text} ").Trim() == "" || ($"{txtEMailAddressTo.Text} ").Trim() == "");
		 // txtEMailName_Change
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}