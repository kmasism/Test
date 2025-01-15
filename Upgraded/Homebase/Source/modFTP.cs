using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;

namespace JETNET_Homebase
{
	internal static class modFTP
	{


		internal static bool FTP_File_To_Site_Chilkat(string strFTPServerName, string strFTPServerTCPIP, int lFTPPort, string strFTPLoginName, string strFTPPassword, string strFTPPassiveFlag, string strFTPDir, string strFTPFileName, string strLocalDir, string strLocalFileName)
		{

			bool result = false;
			Chilkat_v9_5_0.ChilkatFtp2 cFTP2 = new Chilkat_v9_5_0.ChilkatFtp2();

			bool bResults = false;

			int iErrNbr = 0;
			string strErrDesc = "";

			string strQuery1 = "";
			string strErrorMsg = "";
			string strMsg = "";

			int iMsgBox = 0;
			int iRetryMax = 0;
			int iRetryCnt = 0;
			int iRetryDelay = 0;

			int lResults = 0;

			try
			{

				bResults = false;
				strErrorMsg = "";

				iRetryMax = 5;
				iRetryCnt = 0;
				iRetryDelay = 300;

				if (File.Exists($"{strLocalDir}{strLocalFileName}"))
				{

					//lResults = cFTP2.UnlockComponent("JETNETFTP_ThXcxBNKpFnu")
					lResults = cFTP2.UnlockComponent(modGlobalVars.gstrChilkatUnlockCode); // 10/24/2017

					if (lResults == 1)
					{

						if (Convert.ToString(modAdminCommon.snp_User["user_chilkat_logging_flag"]) == "Y")
						{

							if (!Directory.Exists($"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\"))
							{
								Directory.CreateDirectory($"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\");
							}

							cFTP2.DebugLogFilePath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\Chilkat_FTP_LastError.txt";
							cFTP2.VerboseLogging = -1;

						} // If snp_User!user_chilkat_logging_flag = "Y" Then

						if (strLocalDir.Substring(Math.Max(strLocalDir.Length - 1, 0)) != "\\")
						{
							strLocalDir = $"{strLocalDir}\\";
						}
						if (strFTPDir.Substring(Math.Max(strFTPDir.Length - 1, 0)) != "/")
						{
							strFTPDir = $"{strFTPDir}/";
						}

						cFTP2.KeepSessionLog = 1;
						cFTP2.IdleTimeoutMs = 15000;
						cFTP2.hostname = strFTPServerName;
						cFTP2.port = lFTPPort;
						cFTP2.username = strFTPLoginName;
						cFTP2.password = strFTPPassword;

						if (strFTPPassiveFlag == "Y")
						{
							cFTP2.Passive = 1;
						}
						else
						{
							cFTP2.Passive = 0;
						}

						cFTP2.hostname = strFTPServerTCPIP;
						lResults = cFTP2.Connect();
						if (lResults != 1)
						{
							cFTP2.hostname = strFTPServerName;
							lResults = cFTP2.Connect();
						}

						if (lResults == 1)
						{

							lResults = cFTP2.DeleteRemoteFile($"{strFTPDir}{strFTPFileName}");

							lResults = cFTP2.PutFile($"{strLocalDir}{strLocalFileName}", $"{strFTPDir}{strFTPFileName}");

							if (lResults == 1)
							{
								bResults = true;
							}
							else
							{
								strErrorMsg = $"Upload Failed - {cFTP2.LastErrorText}";
								modAdminCommon.Record_Error("Chilkat cFTP2", strErrorMsg);
								bResults = false;
							}

							cFTP2.Disconnect();

						}
						else
						{
							strErrorMsg = $"Unable To Connect To FTP Server - {cFTP2.LastErrorText}";
							modAdminCommon.Record_Error("Chilkat cFTP2", strErrorMsg);
						} // If lResults = 1 Then

					}
					else
					{
						strErrorMsg = $"Unable To Unlock Chilkat Object - {cFTP2.LastErrorText}";
						modAdminCommon.Record_Error("Chilkat cFTP2", strErrorMsg);
					} // If lResults = 1 Then

				}
				else
				{
					strErrorMsg = "Local File Does NOT Exist";
					modAdminCommon.Record_Error("Chilkat cFTP2", strErrorMsg);
				} // If gfso.FileExists(strLocalDir & strLocalFileName) = True Then

				if (!bResults)
				{
					strMsg = $"FTP Failed - {strErrorMsg}";
				}

				// Dispose of Memory
				cFTP2 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				iErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				strMsg = "FTP Upload Failed";

				iRetryCnt++;
				if (iRetryCnt <= 3)
				{
					strErrDesc = $"{strMsg}: Retry # {iRetryCnt.ToString()}";
					//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
					UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Statement");
				} // If iRetryCnt <= iRetryMax Then

				modAdminCommon.Record_Error("Chilkat cFTP2", $"LocFTP_File_To_Site_Chilkat_Error - {strErrDesc}");

				bResults = false;
				result = bResults;
			}
			return result;
		} // FTP_File_To_Site_Chilkat



		internal static bool FTP_File_From_Site_Chilkat(string strFTPServerName, int lFTPPort, string strFTPLoginName, string strFTPPassword, string strFTPPassiveFlag, string strFTPDir, string strFTPFileName, string strLocalDir, string strLocalFileName, bool bDeleteFTPFile)
		{

			bool result = false;
			Chilkat_v9_5_0.ChilkatFtp2 cFTP3 = new Chilkat_v9_5_0.ChilkatFtp2();

			int iErrNbr = 0;
			string strErrDesc = "";
			string strErrorMsg = "";

			string strFileExt = "";

			string strMsg = "";
			int iMsgBox = 0;
			int iRetryMax = 0;
			int iRetryCnt = 0;
			int iRetryDelay = 0;
			int lSize = 0;

			int lResults = 0;

			string strRatingLocalFileName = "";

			bool bFileExists = false;
			bool bResults = false;

			try
			{

				bResults = false;
				strErrDesc = "";

				strMsg = $"FTP File Download From: {strFTPServerName} File: {strFTPFileName}";

				iRetryMax = 5;
				iRetryCnt = 0;
				iRetryDelay = 300;

				strFileExt = strFTPFileName.Substring(Math.Min(strFTPFileName.IndexOf('.'), strFTPFileName.Length));

				if (File.Exists($"{strLocalDir}{strLocalFileName}"))
				{
					//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					File.Delete($"{strLocalDir}{strLocalFileName}");
				}

				lResults = cFTP3.UnlockComponent("JETNETFTP_ThXcxBNKpFnu");

				if (lResults == 1)
				{

					cFTP3.KeepSessionLog = 1;
					cFTP3.IdleTimeoutMs = 15000;
					cFTP3.hostname = strFTPServerName;
					cFTP3.port = lFTPPort;
					cFTP3.username = strFTPLoginName;
					cFTP3.password = strFTPPassword;

					if (strFTPPassiveFlag == "Y")
					{
						cFTP3.Passive = 1;
					}
					else
					{
						cFTP3.Passive = 0;
					}

					lResults = cFTP3.Connect();

					if (lResults == 1)
					{

						bFileExists = false;

						if (strFTPDir != "")
						{
							lResults = cFTP3.ChangeRemoteDir(strFTPDir);
						}

						if (lResults == 1)
						{

							lSize = cFTP3.GetSizeByName(strFTPFileName);
							if (lSize >= 0)
							{
								bFileExists = true;
							}

							if (bFileExists)
							{

								lResults = cFTP3.GetFile(strFTPFileName, $"{strLocalDir}{strLocalFileName}");

								if (lResults == 1)
								{

									if (File.Exists($"{strLocalDir}{strLocalFileName}"))
									{

										if (bDeleteFTPFile)
										{
											lResults = cFTP3.DeleteRemoteFile(strFTPFileName);
										}

										strMsg = "FTP Download Completed";
										bResults = true;

									}
									else
									{
										strErrorMsg = "Unable To Find File That Was Just Downloaded";
										modAdminCommon.Record_Error("Chilkat cFTP3", strErrorMsg);
									} // If gfso.FileExists(strLocalDir & strLocalFileName) = True Then
								}
								else
								{
									strErrorMsg = $"Unable To Downloaded File - {cFTP3.LastErrorText}";
									modAdminCommon.Record_Error("Chilkat cFTP3", strErrorMsg);
								} // If lResults = 1 Then

							}
							else
							{
								strErrorMsg = "FTP File Does NOT Exist";
								modAdminCommon.Record_Error("Chilkat cFTP3", strErrorMsg);
							} // If bFileExists = True Then

						}
						else
						{
							strErrDesc = $"Unable To Change To FTP Directory - {cFTP3.LastErrorText}";
							modAdminCommon.Record_Error("Chilkat cFTP3", strErrorMsg);
						} // If lResults = 1 Then

						cFTP3.Disconnect();

					}
					else
					{
						strErrorMsg = $"Unable To Connect To FTP Server - {cFTP3.LastErrorText}";
						modAdminCommon.Record_Error("Chilkat cFTP3", strErrorMsg);
					} // If lResults = 1 Then

				}
				else
				{
					strErrorMsg = $"Unable To Unlock Chilkat Object {cFTP3.LastErrorText}";
					modAdminCommon.Record_Error("Chilkat cFTP3", strErrorMsg);
				} // If lResults = 1 Then

				if (!bResults)
				{
					strMsg = $"FTP Failed - {strErrorMsg}";
				}

				// Dispose of Memory
				cFTP3 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				iErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				strMsg = "FTP Download Failed";

				iRetryCnt++;
				if (iRetryCnt <= iRetryMax)
				{
					strErrDesc = $"{strMsg}: Retry # {iRetryCnt.ToString()}";
					//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
					UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Statement");
				} // If iRetryCnt <= iRetryMax Then

				modAdminCommon.Record_Error("Chilkat cFTP3", $"FTP_File_From_Site_Chilkat_Error - {strErrDesc}");

				result = false;
			}
			return result;
		} // FTP_File_From_Site_Chilkat
	}
}