using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;

namespace JETNET_Homebase
{
	internal static class modHTTP
	{


		// Chilkat HTTP: JETNETHttp_LgfuBOUOZLpH

		internal static bool HTTPGetFile_Chilkat(string strURL, string strLocalFileName)
		{

			bool result = false;
			Chilkat_v9_5_0.ChilkatHttp cHTTP2 = new Chilkat_v9_5_0.ChilkatHttp();
			int lResults = 0;
			int lErrNbr = 0;
			string strErrDesc = "";
			int iErrCnt = 0;
			bool bResults = false;

			try
			{

				bResults = false;
				iErrCnt = 0;

				if (File.Exists(strLocalFileName))
				{
					//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					File.Delete(strLocalFileName);
				}

				//lResults = cHTTP.UnlockComponent("JETNETHttp_LgfuBOUOZLpH")
				lResults = cHTTP2.UnlockComponent(modGlobalVars.gstrChilkatUnlockCode); // 10/24/2017

				if (lResults == 1)
				{

					if (Convert.ToString(modAdminCommon.snp_User["user_chilkat_logging_flag"]) == "Y")
					{

						if (!Directory.Exists($"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\"))
						{
							Directory.CreateDirectory($"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\");
						}

						cHTTP2.DebugLogFilePath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\Chilkat_HTTP_LastError.txt";
						cHTTP2.VerboseLogging = -1;

					} // If snp_User!user_chilkat_logging_flag = "Y" Then

					lResults = cHTTP2.Download(strURL, strLocalFileName);

					if (lResults == 1)
					{
						bResults = true;
					}
					else
					{
						modAdminCommon.Record_Error("Chilkat cHTTP2", $"HTTPGetFile -Download Error - {cHTTP2.LastErrorText}");
					} // If lResults = 1 Then

				}
				else
				{
					modAdminCommon.Record_Error("Chilkat cHTTP2", $"HTTPGetFile - Unlock Error - {cHTTP2.LastErrorText}");
				}

				cHTTP2 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;
				iErrCnt++;

				if (iErrCnt >= 3)
				{
					modCommon.DelaySeconds(60);
					//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
					UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Statement");
				}

				modAdminCommon.Record_Error("Chilkat HTTPGetFile Error", strErrDesc);

				result = false;
			}
			return result;
		} // HTTPGetFile_Chilkat
	}
}