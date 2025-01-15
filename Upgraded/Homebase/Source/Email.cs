using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal static class modEmail
	{



		internal static void Get_SMTP_Configuration_Information(ref string strSMTPServer, ref string strSMTPUserName, ref string strSMTPPassWord, ref int lSMTPTImeOut, ref int lSMTPPort)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				// Defaults
				strSMTPServer = "";
				strSMTPUserName = "";
				strSMTPPassWord = "";

				lSMTPTImeOut = 30000;
				lSMTPPort = 25000;

				// 06/25/2020 - By David D. Cruger
				modCommon.gbUseTLS = true;
				if (modCommon.gbUseTLS)
				{
					strSMTPServer = "smtp.office365.com";
					strSMTPUserName = "service@jetnet.com";
					strSMTPPassWord = "svc3(*gFzX!";
					lSMTPPort = 587;
				}

				strQuery1 = "SELECT * FROM Application_Configuration WITH (NOLOCK) ";

				if (modAdminCommon.gbl_Live_flag)
				{
					strQuery1 = $"{strQuery1}WHERE (aconfig_config_category = 'LIVE') ";
				}
				else if (modAdminCommon.gbl_Backup_flag)
				{ 
					strQuery1 = $"{strQuery1}WHERE (aconfig_config_category = 'BACKUP') ";
				}
				else
				{
					strQuery1 = $"{strQuery1}WHERE (aconfig_config_category = 'TEST') ";
				}

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					strSMTPServer = ($"{Convert.ToString(rstRec1["aconfig_email_smtp_server"])} ").Trim();
					strSMTPUserName = ($"{Convert.ToString(rstRec1["aconfig_email_username"])} ").Trim();
					strSMTPPassWord = ($"{Convert.ToString(rstRec1["aconfig_email_password"])} ").Trim();
					lSMTPTImeOut = 30000;
					lSMTPPort = Convert.ToInt32(rstRec1["aconfig_smtp_port"]);

					switch(strSMTPServer)
					{
						case "smtp.jetnet.com" : 
							modCommon.gbUseTLS = false; 
							break;
						case "smtp.office365.com" : 
							modCommon.gbUseTLS = true; 
							break;
					}

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Get_SMTP_Configuration_Information_Error", excep.Message);
			}

		} // Get_SMTP_Configuration_Information



		internal static bool EMail_Message(string strFromName, string strFromEMail, string strTo, string strCC, string strBCC, string strSubject, string strBody, string strAttachment, bool bHTMLFlag)
		{

			bool result = false;
			Chilkat_v9_5_0.ChilkatMailMan EMailMan = new Chilkat_v9_5_0.ChilkatMailMan();
			Chilkat_v9_5_0.ChilkatEmail EMail2 = new Chilkat_v9_5_0.ChilkatEmail();

			string strSMTPServer = "";
			string strSMTPUserName = "";
			string strSMTPPassWord = "";

			int lSMTPTImeOut = 0;
			int lSMTPPort = 0;

			int lResults = 0;
			string[] aEMail = null;
			bool bResults = false;
			string strErrMsg = "";

			try
			{

				bResults = false; // Default
				strErrMsg = "";

				if ((strTo != "") && (strSubject != ""))
				{

					strTo = StringsHelper.Replace(strTo, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's
					strCC = StringsHelper.Replace(strCC, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's
					strBCC = StringsHelper.Replace(strBCC, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's

					Get_SMTP_Configuration_Information(ref strSMTPServer, ref strSMTPUserName, ref strSMTPPassWord, ref lSMTPTImeOut, ref lSMTPPort);

					if (strSMTPServer != "")
					{

						//lResults = EMailMan.UnlockComponent("JETNETMAILQ_M9xhBbZa9A0v")
						lResults = EMailMan.UnlockComponent(modGlobalVars.gstrChilkatUnlockCode); // 10/24/2017

						if (lResults == 1)
						{

							if (Convert.ToString(modAdminCommon.snp_User["user_chilkat_logging_flag"]) == "Y")
							{

								if (!Directory.Exists($"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\"))
								{
									Directory.CreateDirectory($"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\");
								}

								EMailMan.DebugLogFilePath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\Chilkat_EMail_LastError.txt";
								EMailMan.VerboseLogging = -1;

							} // If snp_User!user_chilkat_logging_flag = "Y" Then


							EMailMan.ConnectTimeout = lSMTPTImeOut;
							EMailMan.SmtpHost = strSMTPServer;
							EMailMan.SmtpPort = lSMTPPort;
							EMailMan.SmtpUsername = strSMTPUserName;
							EMailMan.SmtpPassword = strSMTPPassWord;

							EMail2.fromName = strFromName;
							EMail2.FromAddress = strFromEMail;

							// 06/25/2020 - By David D. Cruger
							modCommon.gbUseTLS = true;
							if (modCommon.gbUseTLS)
							{
								EMailMan.SmtpSsl = 1; //
								EMailMan.SslProtocol = "TLS 1.2 or higher";
								EMailMan.StartTls = 1;
								EMailMan.PreferIpv6 = 1;
								EMailMan.RequireSslCertVerify = 1;
							}

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

							//-----------------------------------
							//  Process All CC EMail Addresses

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

							if (bHTMLFlag)
							{
								EMail2.SetHtmlBody(strBody);
							}
							else
							{
								EMail2.SetTextBody(strBody, "text");
							}

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
								modAdminCommon.Record_Error("EMail_Message", $"Error Sending EMail - {EMailMan.LastErrorText}");
							}

							EMailMan.CloseSmtpConnection();

						}
						else
						{
							modAdminCommon.Record_Error("EMail_Message", "Unable To Unlock EMail Control");
						} // If lResults = 1 Then

					}
					else
					{
						modAdminCommon.Record_Error("EMail_Message", "SMTP Server Blank");
					} // If strSMTPServer <> "" Then

				}
				else
				{
					modAdminCommon.Record_Error("EMail_Message", "TO Field or Subject Blank");
				} // If (strTo <> "") And (strSubject <> "") Then

				EMail2 = null;
				EMailMan = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("EMail_Message_Error", excep.Message);

				result = false;
			}
			return result;
		} // EMail_Message


		internal static bool Insert_EMail_Queue_Record(string strTo, string strCC, string strBCC, string strSubject, string strBody, string strAttachment, string strHTMLFlag, string strStatus, string strReplyName, string strReplyEMail, string strSMTPServer, int lSMTPPort, string strSMTPUserName, string strSMTPPassWord, ref string strErrorMsg, int lCompId, int lContactId, int lSubId = 0)
		{

			bool result = false;
			string strService = "";
			string strInsert = "";

			try
			{

				result = false;

				strService = "HomebaseEMail";

				if ((strTo != "") && (strSubject != ""))
				{

					if (lCompId < 0)
					{
						lCompId = 0;
					}
					if (lContactId < 0)
					{
						lContactId = 0;
					}


					strTo = StringsHelper.Replace(strTo, "'", "''", 1, -1, CompareMethod.Binary);
					strCC = StringsHelper.Replace(strCC, "'", "''", 1, -1, CompareMethod.Binary);
					strBCC = StringsHelper.Replace(strBCC, "'", "''", 1, -1, CompareMethod.Binary);
					strSubject = StringsHelper.Replace(strSubject, "'", "''", 1, -1, CompareMethod.Binary);
					strBody = StringsHelper.Replace(strBody, "'", "''", 1, -1, CompareMethod.Binary);
					strAttachment = StringsHelper.Replace(strAttachment, "'", "''", 1, -1, CompareMethod.Binary);
					strStatus = StringsHelper.Replace(strStatus, "'", "''", 1, -1, CompareMethod.Binary);
					strErrorMsg = StringsHelper.Replace(strErrorMsg, "'", "''", 1, -1, CompareMethod.Binary);
					strReplyName = StringsHelper.Replace(strReplyName, "'", "''", 1, -1, CompareMethod.Binary);
					strReplyEMail = StringsHelper.Replace(strReplyEMail, "'", "''", 1, -1, CompareMethod.Binary);
					strSMTPServer = StringsHelper.Replace(strSMTPServer, "'", "''", 1, -1, CompareMethod.Binary);
					strSMTPUserName = StringsHelper.Replace(strSMTPUserName, "'", "''", 1, -1, CompareMethod.Binary);
					strSMTPPassWord = StringsHelper.Replace(strSMTPPassWord, "'", "''", 1, -1, CompareMethod.Binary);

					strInsert = "INSERT INTO EMail_Queue ( emailq_service,  emailq_replyname,  emailq_replyemail, ";
					strInsert = $"{strInsert}emailq_smtp_server,  emailq_smtp_port,  emailq_smtp_username, ";
					strInsert = $"{strInsert}emailq_smtp_password,  emailq_to, emailq_cc, ";
					strInsert = $"{strInsert}emailq_bcc, emailq_subject,  emailq_body, ";
					strInsert = $"{strInsert}emailq_attachment, emailq_status, emailq_errormsg, ";
					strInsert = $"{strInsert}emailq_html_flag,  emailq_comp_id,  emailq_contact_id, emailq_sub_id) ";

					strInsert = $"{strInsert}VALUES ('{strService}', ";
					strInsert = $"{strInsert}'{strReplyName}', ";
					strInsert = $"{strInsert}'{strReplyEMail}', ";
					strInsert = $"{strInsert}'{strSMTPServer}', ";
					strInsert = $"{strInsert}{lSMTPPort.ToString()}, ";
					strInsert = $"{strInsert}'{strSMTPUserName}', ";
					strInsert = $"{strInsert}'{strSMTPPassWord}', ";
					strInsert = $"{strInsert}'{strTo}', ";
					strInsert = $"{strInsert}'{strCC}', ";
					strInsert = $"{strInsert}'{strBCC}', ";
					strInsert = $"{strInsert}'{strSubject}', ";
					strInsert = $"{strInsert}'{strBody}', ";
					strInsert = $"{strInsert}'{strAttachment}', ";
					strInsert = $"{strInsert}'{strStatus}', ";
					strInsert = $"{strInsert}'{strErrorMsg}', ";
					strInsert = $"{strInsert}'{strHTMLFlag}',";
					strInsert = $"{strInsert}{lCompId.ToString()},";
					strInsert = $"{strInsert}{lContactId.ToString()}, ";
					strInsert = $"{strInsert}{lSubId.ToString()}) ";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strInsert;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					result = true;

				} // If (strTo <> "") And (strSubject <> "") Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("Insert_EMail_Queue_Record_Error", $"({Information.Err().Number.ToString()}) {excep.Message}");

				result = false;
			}

			return result;
		} // Insert_EMail_Queue_Record



		internal static void Send_All_EMail_In_Queue(ref string strErrorMsg, int lCompId = 0, bool bUpdateMainPanel = false)
		{

			Object fso = new Object();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTot1 = 0;
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
			bool bHTMLFlag = false;

			StringBuilder strMsg = new StringBuilder();
			string strType = "";
			string strPanelMsg = "";
			int iSB = 0;

			bool bResults = false;

			try
			{

				strService = "HomebaseEMail";


				strPanelMsg = "";
				iSB = -1;
				if (bUpdateMainPanel)
				{
					iSB = modStatusBar.Identify_Status_Bar(mdi_ResearchAssistant.DefInstance.pnlStatusBar);
					strPanelMsg = modStatusBar.Return_Status_Bar_Caption(iSB);
				}

				strQuery1 = $"SELECT * FROM EMail_Queue WHERE (emailq_service = '{strService}') ";

				strQuery1 = $"{strQuery1}AND (emailq_status = 'Open') AND (emailq_onhold_flag = 'N') ";

				if (lCompId > 0)
				{
					strQuery1 = $"{strQuery1}AND (emailq_comp_id = {lCompId.ToString()}) ";
				}

				strQuery1 = $"{strQuery1}ORDER BY emailq_id ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					lTot1 = rstRec1.RecordCount;
					lCnt1 = 0;

					do 
					{ // Loop Until (rstRec1.EOF = True)

						lCnt1++;
						if (bUpdateMainPanel)
						{
							modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"{strPanelMsg} - Working {StringsHelper.Format(lCnt1, "#,##0")} of {StringsHelper.Format(lTot1, "#,##0")}", Color.Blue);
						}

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
						strSubject = ($"{Convert.ToString(rstRec1["emailq_subject"])} ").Trim();
						strBody = ($"{Convert.ToString(rstRec1["emailq_body"])} ").Trim();
						strAttachment = ($"{Convert.ToString(rstRec1["emailq_attachment"])} ").Trim();

						strStatus = ($"{Convert.ToString(rstRec1["emailq_status"])} ").Trim();
						strOnHoldFlag = ($"{Convert.ToString(rstRec1["emailq_onhold_flag"])} ").Trim();
						strHTMLFlag = ($"{Convert.ToString(rstRec1["emailq_html_flag"])} ").Trim();

						bHTMLFlag = false;
						if (strHTMLFlag == "Y")
						{
							bHTMLFlag = true;
						}

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

							if (EMail_Company_Message(strSMTPServer, lSMTPPort, strSMTPUserName, strSMTPPassWord, strReplyName, strReplyEMail, strTo, strCC, strBCC, strSubject, strBody, strAttachment, bHTMLFlag, ref strErrorMsg))
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

						rstRec1.MoveNext();

					}
					while(!((rstRec1.EOF) || !bResults));

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
				fso = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("Send All EMail In Queue EMail Confirmation Error", $"({Information.Err().Number.ToString()}) {excep.Message}");
			}

		} // Send_All_EMail_In_Queue


		internal static bool EMail_Company_Message(string strSMTPServer, int lSMTPPort, string strSMTPUserName, string strSMTPPassWord, string strFromName, string strFromEMail, string strTo, string strCC, string strBCC, string strSubject, string strBody, string strAttachment, bool bHTMLFlag, ref string strErrorMsg)
		{

			bool result = false;
			Chilkat_v9_5_0.ChilkatMailMan EMailMan = new Chilkat_v9_5_0.ChilkatMailMan();
			Chilkat_v9_5_0.ChilkatEmail EMail2 = new Chilkat_v9_5_0.ChilkatEmail();
			int iErrCnt = 0;

			int lResults = 0;
			string[] aEMail = null;
			bool bResults = false;
			string strErrMsg = "";
			int lSMTPTImeOut = 0;

			try
			{

				bResults = false; // Default
				strErrorMsg = "";

				if ((strTo != "") && (strSubject != "") && (strFromName != "") && (strFromEMail != ""))
				{

					strTo = StringsHelper.Replace(strTo, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's
					strCC = StringsHelper.Replace(strCC, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's
					strBCC = StringsHelper.Replace(strBCC, ";", ",", 1, -1, CompareMethod.Binary); // Make Sure All Delimiter's are comma's

					if (strSMTPServer != "")
					{

						//lResults = EMailMan.UnlockComponent("JETNETMAILQ_M9xhBbZa9A0v")
						lResults = EMailMan.UnlockComponent(modGlobalVars.gstrChilkatUnlockCode); // 10/24/2017

						if (lResults == 1)
						{

							if (!Directory.Exists($"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\"))
							{
								Directory.CreateDirectory($"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\");
							}

							EMailMan.DebugLogFilePath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\Chilkat_EMail_LastError.txt";
							EMailMan.VerboseLogging = -1;

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

							//---------------------------------------
							// Add Header Parameters
							// Process All To EMail Addresses

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

							//-----------------------------------
							//  Process All CC EMail Addresses

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


							if (bHTMLFlag)
							{
								EMail2.SetHtmlBody(strBody);
							}
							else
							{
								EMail2.SetTextBody(strBody, "text");
							}

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
								modAdminCommon.Record_Error("EMail_Company_Message", $"Error Sending EMail - {EMailMan.LastErrorText}");
								strErrorMsg = "Error Sending EMail";
							}

							EMailMan.CloseSmtpConnection();

						}
						else
						{
							modAdminCommon.Record_Error("EMail_Company_Message", "Unable To Unlock EMail Control");
							strErrorMsg = "Error - Unable to Unlock EMail Control";
						} // If lResults = 1 Then

					}
					else
					{
						modAdminCommon.Record_Error("EMail_Company_Message", "SMTP Server Name Blank");
						strErrorMsg = "Error - SMTP Server Name Blank";
					} // If strSMTPServer <> "" Then

				}
				else
				{
					modAdminCommon.Record_Error("EMail_Company_Message", "To or Subject or From Name or From EMail Blank");
					strErrorMsg = "Error - No To, From Name or Subject";
				} // If (strTo <> "") And (strSubject <> "") And (strFromName <> "") And (strFromEMail <> "") Then

				EMail2 = null;
				EMailMan = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("EMail_Company_Message_Error", $"({Information.Err().Number.ToString()}) {excep.Message}");
				strErrorMsg = "Error - EMail_Company_Message_Error";

				result = false;
			}
			return result;
		} // EMail_Company_Message


		internal static bool Simple_Insert_EMail_Queue_Record(string strTo, string strCC, string strBCC, string strSubject, string strBody, string strAttachment, string strHTMLFlag, string strStatus, string strReplyName, string strReplyEMail, int lCompId, int lContactId, int lSubId = 0)
		{

			bool result = false;
			string strSMTPServer = "";
			int lSMTPPort = 0;
			string strSMTPUserName = "";
			string strSMTPPassWord = "";
			string strErrMsg = "";
			bool bResults = false;

			try
			{

				strSMTPServer = modCommon.DLookUp("aconfig_email_smtp_server", "Application_Configuration");
				lSMTPPort = Convert.ToInt32(Double.Parse(modCommon.DLookUp("aconfig_smtp_port", "Application_Configuration")));
				strSMTPUserName = modCommon.DLookUp("aconfig_email_username", "Application_Configuration");
				strSMTPPassWord = modCommon.DLookUp("aconfig_email_password", "Application_Configuration");

				strErrMsg = "";

				bResults = Insert_EMail_Queue_Record(strTo, strCC, strBCC, strSubject, strBody, strAttachment, strHTMLFlag, strStatus, strReplyName, strReplyEMail, strSMTPServer, lSMTPPort, strSMTPUserName, strSMTPPassWord, ref strErrMsg, lCompId, lContactId, lSubId);


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Simple_Insert_EMail_Queue_Record_Error", excep.Message);

				result = false;
			}
			return result;
		} // Simple_Insert_EMail_Queue_Record
	}
}