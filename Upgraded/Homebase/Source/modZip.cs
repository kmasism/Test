using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal static class modZip
	{


		internal static bool WinZip_UnZip(string strZipFileName, string strToDir, string strFileMask)
		{

			Object fso = new Object();
			FileInfo fFile = null;
			string strShellCmd = "";

			bool bResults = false;

			try
			{

				bResults = false;

				if (strZipFileName != "")
				{

					if (File.Exists(strZipFileName))
					{

						fFile = new FileInfo(strZipFileName);

						if (strToDir == "")
						{
							strToDir = fFile.FullName;
						}
						if (strToDir.Substring(Math.Max(strToDir.Length - 1, 0)) != "\\")
						{
							strToDir = $"{strToDir}\\";
						}

						if (Directory.Exists(strToDir))
						{

							strShellCmd = $"{"\""}C:\\Program Files\\WinZip\\Wzunzip.exe{"\""} -e -o {strZipFileName} {"\""}{strToDir}{"\""} {strFileMask}";

							//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
							ProcessStartInfo startInfo = new ProcessStartInfo(strShellCmd);
							startInfo.WindowStyle = ProcessWindowStyle.Normal;
							Process.Start(startInfo);

							bResults = true;

						}
						else
						{
							MessageBox.Show($"To Directory Does Not Exist{Environment.NewLine}{strToDir}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If fso.FolderExists(strToDir) = True Then

					}
					else
					{
						MessageBox.Show("Zip File Does Not Exist", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If fso.FileExists(strZipFileName) = True Then

				}
				else
				{
					MessageBox.Show("Zip File Name Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If strZipFileName <> "" Then

				fso = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"WinZip_UnZip_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return false;
		} // WinZip_UnZip

		internal static bool WinZip_Zip(string strZipFileName, string strFromDir, string strFileMask, bool bOverwriteZip = true)
		{


			Object fso = new Object();
			FileInfo fFile = null;
			string strShellCmd = "";

			bool bResults = false;

			try
			{

				bResults = false;

				if (strZipFileName != "")
				{

					if (File.Exists(strZipFileName))
					{
						if (bOverwriteZip)
						{
							File.Delete(strZipFileName);
						}
					}

					if (strFromDir == "")
					{
						strFromDir = Path.GetDirectoryName(Application.ExecutablePath);
					}
					if (strFromDir.Substring(Math.Max(strFromDir.Length - 1, 0)) != "\\")
					{
						strFromDir = $"{strFromDir}\\";
					}

					if (Directory.Exists(strFromDir))
					{

						strShellCmd = $"{"\""}C:\\Program Files\\WinZip\\Wzzip.exe{"\""} -a {strZipFileName} {"\""}{strFromDir}{strFileMask}{"\""}";

						//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
						ProcessStartInfo startInfo = new ProcessStartInfo(strShellCmd);
						startInfo.WindowStyle = ProcessWindowStyle.Normal;
						Process.Start(startInfo);

						bResults = true;

					}
					else
					{
						MessageBox.Show($"From Directory Does Not Exist{Environment.NewLine}{strFromDir}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If fso.FolderExists(strFromDir) = True Then

				}
				else
				{
					MessageBox.Show("Zip File Name Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If strZipFileName <> "" Then

				fso = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"WinZip_Zip_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return false;
		} // WinZip_Zip



		internal static bool UnZipToFolder_Chilkat(string strZipFileName, string strUnZipToPath, bool bDeleteFolderContent, ref string strErrMsg)
		{

			// Zipping Objects
			bool result = false;
			Chilkat_v9_5_0.ChilkatZip cZip2 = new Chilkat_v9_5_0.ChilkatZip(); //gap-note review this control during stabilization
			int lResults = 0;
			int lNbrFiles = 0;
			int lErrNbr = 0;
			string strErrDesc = "";
			int iErrCnt = 0;

			string strFileName = ""; // Name of File to Extract
			bool bResults = false;

			try
			{

				strErrMsg = "";
				bResults = false;

				if (strUnZipToPath.Substring(Math.Max(strUnZipToPath.Length - 1, 0)) != "\\")
				{
					strUnZipToPath = $"{strUnZipToPath}\\";
				}

				if (Directory.Exists(strUnZipToPath))
				{

					if (File.Exists(strZipFileName))
					{

						if (bDeleteFolderContent)
						{
							//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							File.Delete($"{strUnZipToPath}*.*");
						}

						//lResults = cZip2.UnlockComponent("JETNETZIP_hdT6ZnvgmGxJ")
						lResults = cZip2.UnlockComponent(modGlobalVars.gstrChilkatUnlockCode); // 10/24/2017

						if (lResults == 1)
						{

							lResults = cZip2.OpenZip(strZipFileName);

							if (lResults == 1)
							{

								if (Convert.ToString(modAdminCommon.snp_User["user_chilkat_logging_flag"]) == "Y")
								{

									if (!Directory.Exists($"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\"))
									{
										Directory.CreateDirectory($"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\");
									}

									cZip2.DebugLogFilePath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\Chilkat_Zip_LastError.txt";
									cZip2.VerboseLogging = -1;

								} // If snp_User!user_chilkat_logging_flag = "Y" Then

								lNbrFiles = cZip2.Unzip(strUnZipToPath);

								if (lNbrFiles > 0)
								{
									bResults = true;
								}
								else
								{
									modAdminCommon.Record_Error("Chilkat cZip2", $"Unable To UnZip File Error - {cZip2.LastErrorText}");
								} // If lNbrFiles > 0 Then

							}
							else
							{
								modAdminCommon.Record_Error("Chilkat cZip2", $"Unable To Open Zip File Error - {cZip2.LastErrorText}");
							} // If lResults = 1 Then

						}
						else
						{
							modAdminCommon.Record_Error("Chilkat cZip2", $"Unlock Component Error - {cZip2.LastErrorText}");
						} // If lResults = 1 Then

					} // If gfso.FileExists(strZipFileName) = True Then

				} // If gfso.FolderExists(strUnZipToPath) = True Then

				cZip2 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;
				iErrCnt++;

				if (iErrCnt <= 3)
				{
					modCommon.DelaySeconds(10);
					//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
					UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Statement");
				}

				modAdminCommon.Record_Error("Chilkat UnZipToFolder Error", strErrDesc);

				result = false;
			}
			return result;
		} // UnZipToFolder_Chilkat


		internal static bool ZipDirFiles_Chilkat(string strDirName, string strFileMask, string strZipFileName, string strZipPassword, bool bDeleteFile, int lTotRecDwn)
		{


			bool result = false;
			Chilkat_v9_5_0.ChilkatZip cZip3 = new Chilkat_v9_5_0.ChilkatZip();

			bool bResults = false;
			string strMsg = "";
			int lResults = 0;

			try
			{

				bResults = false;
				lTotRecDwn = 0;


				if (Directory.Exists(strDirName))
				{

					if (strFileMask == "")
					{
						strFileMask = "*.*";
					}
					if (strDirName != "")
					{
						if (strDirName.Substring(Math.Max(strDirName.Length - 1, 0)) != "\\")
						{
							strDirName = $"{strDirName}\\";
						}
					}

					if (bDeleteFile)
					{
						if (File.Exists(strZipFileName))
						{ // If File Exists Delete It
							File.Delete(strZipFileName);
						}
					}

					//lResults = cZip3.UnlockComponent("JETNETZIP_hdT6ZnvgmGxJ")
					lResults = cZip3.UnlockComponent(modGlobalVars.gstrChilkatUnlockCode); // 10/24/2017

					if (lResults == 1)
					{

						if (Convert.ToString(modAdminCommon.snp_User["user_chilkat_logging_flag"]) == "Y")
						{

							if (!Directory.Exists($"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\"))
							{
								Directory.CreateDirectory($"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\");
							}

							cZip3.DebugLogFilePath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\Chilkat_Zip_LastError.txt";
							cZip3.VerboseLogging = -1;

						} // If snp_User!user_chilkat_logging_flag = "Y" Then

						if (File.Exists(strZipFileName))
						{
							lResults = cZip3.OpenZip(strZipFileName);
						}
						else
						{
							lResults = cZip3.NewZip(strZipFileName);
						}

						if (lResults == 1)
						{

							lResults = cZip3.AppendFiles($"{strDirName}{strFileMask}", 0);

							if (lResults == 1)
							{

								cZip3.PasswordProtect = 0;
								if (strZipPassword != "")
								{
									cZip3.PasswordProtect = 1;
									cZip3.SetPassword(strZipPassword);
								}

								lResults = cZip3.WriteZip();

								if (lResults == 1)
								{

									if (cZip3.NumEntries > 0)
									{
										lTotRecDwn = cZip3.NumEntries;
										bResults = true;
									}
									else
									{
										bResults = false;
										modAdminCommon.Record_Error("Chilkat cZip3", $"No Files Added To Zip - {cZip3.LastErrorText}");
									}

									cZip3.CloseZip();

								}
								else
								{
									modAdminCommon.Record_Error("Chilkat cZip3", $"Write Zip Failed - {cZip3.LastErrorText}");
								}

							}
							else
							{
								modAdminCommon.Record_Error("Chilkat cZip3", $"Append Files Error - {cZip3.LastErrorText}");
							} // If lResults = 1 Then

						}
						else
						{
							modAdminCommon.Record_Error("Chilkat cZip3", $"New Zip Error - {cZip3.LastErrorText}");
						} // If lResults = 1 Then

					}
					else
					{
						modAdminCommon.Record_Error("Chilkat cZip3", $"Unlock Component Error - {cZip3.LastErrorText}");
					} // If lResults = 1 Then

				}
				else
				{
					modAdminCommon.Record_Error("Chilkat cZip3", "Directory Does Not Exist");
				} // If gfso.FolderExists(strDirName) = True Then

				cZip3 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Chilkat ZipDirFiles Error", excep.Message);

				result = bResults;
			}
			return result;
		} // ZipDirFiles_Chilkat
	}
}