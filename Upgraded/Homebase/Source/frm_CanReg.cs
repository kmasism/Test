using IWshRuntimeLibrary;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;
using CompareMethod = Microsoft.VisualBasic.CompareMethod;
using File = System.IO.File;

namespace JETNET_Homebase
{
	internal partial class frm_CanReg
		: System.Windows.Forms.Form
	{

		public frm_CanReg()
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


		private void frm_CanReg_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private Object _gfso = null;
		private Object gfso
		{
			get
			{
				if (_gfso is null)
				{
					_gfso = new Object();
				}
				return _gfso;
			}
			set => _gfso = value;
		}

		private string gstrCanRegZipFileName = "";

		// Application Configuration Table for where to put the files
		private string gstrCanRegPath = ""; // \\jetnet4\canreg\
		private string gstrCanRegMstrPath = ""; // \\jetnet4\canreg\masters\
		private string gstrCanRegWorkOnPath = ""; // \\jetnet4\canreg\workon\
		private string gstrCanRegWorkOnPathLocal = ""; // C:\CANREG\WORKON\
		private string gstrCanRegLogPath = ""; // \\jetnet4\canreg\log\
		private string gstrCanRegEMailPath = ""; // \\jetnet4\canreg\email\
		private bool bStopProcess = false;
		private string gstrMsg = "";
		private string gstrErrMsg = "";

		private void EnableButtons()
		{

			cmdBrowse.Enabled = true;
			cmdDownload.Enabled = true;
			cmdUnZip.Enabled = true;
			cmdImport.Enabled = true;
			cmdCompare.Enabled = true;

		} // EnableButtons

		private void DisableButtons(string strExcept)
		{

			cmdBrowse.Enabled = false;
			cmdDownload.Enabled = false;
			cmdUnZip.Enabled = false;
			cmdImport.Enabled = false;
			cmdCompare.Enabled = false;

			strExcept = strExcept.Trim().ToUpper();

			switch(strExcept)
			{
				case "BROWSE" : 
					cmdBrowse.Enabled = true; 
					break;
				case "DOWNLOAD" : 
					cmdDownload.Enabled = true; 
					break;
				case "UNZIP" : 
					cmdUnZip.Enabled = true; 
					break;
				case "IMPORT" : 
					cmdImport.Enabled = true; 
					break;
				case "COMPARE" : 
					cmdCompare.Enabled = true; 
					break;
				case "ALL" : 
					EnableButtons(); 
					break;
			} // Case strExcept

		} // DisableButtons

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/18/2013
		// Modified   : 04/18/2013
		// Procedure  : AddItemToLogFile
		// Parameters : ByVal strText As String
		//              ByRef strErrorMsg As String
		//
		// Returns    : BOOLEAN
		//
		// Notes      : Append entry to the logfile.  Returns TRUE if there are no errors.
		//
		// ====================================================================================

		private bool AddItemToLogFile(string strText, ref string strErrorMsg)
		{
			bool result = false;
			StreamWriter tsFileWriter = null;

			FileStream tsFile = null; // Text Stream File Object for Writting to the Log File
			bool bResults = false;
			string strFileName = "";
			string strDate = "";
			string strPath = "";
			string strLocalFile = "";

			string strDT = ""; // Date/Time

			try
			{

				bResults = false;

				//--------------------------------------------
				// Add Date/Time Stamp and Listener Name
				// Date Formatting
				// https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.90).aspx

				strDT = $"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} - ";

				strDate = DateTime.Now.ToString("yyyyMMdd");
				strFileName = $"{strDate}.LOG";
				strText = ($"{strText} ").Trim();

				if (modCommon.MakeSureDirectoryExists(gstrCanRegLogPath))
				{

					strLocalFile = $"{gstrCanRegLogPath}{strFileName}";
					tsFile = new FileStream(strLocalFile, FileMode.Append, FileAccess.Write);
					tsFileWriter = new StreamWriter(tsFile);
					tsFileWriter.WriteLine($"{strDT}{strText}"); // Write String
					tsFileWriter.Close(); // Close File

					tsFile = null; // Release Memory

				} // If MakeSureDirectoryExists(gstrCanRegLogPath) = True Then

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strErrorMsg = $"AddItemToLogFile_Error: {excep.Message}";

				result = false;
			}
			return result;
		} // AddItemToLogFile

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 02/16/2006
		// Modified   : 02/16/2006
		// Procedure  : AddItemToCanRegListBox
		// Parameters : ByVal strMsg As String
		//
		// Returns    : None
		//
		// Notes      : Adds a Single Item To the List Box StatusList
		//
		// ====================================================================================

		private void AddItemToCanRegListBox(string strMsg)
		{

			string strErrMsg = "";

			StatusList.AddItem($"{StringsHelper.Format(DateTime.Now, "mm/dd/yyyy hh:MM:ss AM/PM")} - {strMsg}");
			ListBoxHelper.SetSelectedIndex(StatusList, StatusList.Items.Count - 1);

			if (!AddItemToLogFile(strMsg, ref strErrMsg))
			{
				MessageBox.Show($"Error Add Item To Log File: {Information.Err().Description}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // AddItemToCanRegListBox

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 02/16/2006
		// Modified   : 02/16/2006
		// Function   : ReturnCanadianRegistryDirectory
		// Parameters : None
		//
		// Returns    : String
		//
		// Notes      : Reads the Application Configuration table and returns the Canadian
		// Registration Base Directory to Store the files.
		//
		// ====================================================================================

		private string ReturnCanadianRegistryDirectory()
		{


			string strResults = modCommon.DLookUp("aconfig_canadian_reg_dir", "Application_Configuration");

			return strResults;

		} // ReturnCanadianRegistryDirectory

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 02/16/2006
		// Modified   : 02/16/2006
		// Function   : ReturnCanadianRegistryWebSiteFile
		// Parameters : None
		//
		// Returns    : String
		//
		// Notes      : Reads the Application Configuration table and returns the Canadian
		// Registration Website file name that needs to be downloaded.
		//
		// ====================================================================================

		private string ReturnCanadianRegistryWebSiteFile()
		{


			string strResults = modCommon.DLookUp("aconfig_canadian_reg_website", "Application_Configuration");

			return strResults;

		} // ReturnCanadianRegistryWebSiteFile

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 05/01/2013
		// Modified   : 05/01/2013
		// Function   : Copy_CanReg_Text_Files_To_Local_Workon_Directory
		// Parameters : None
		//
		// Returns    : Boolean
		//
		// Notes      : Copies the newly download CanReg Text Files To The Local C:\CANREG\WORKON
		// directory.
		//
		// ====================================================================================

		//UPGRADE_NOTE: (7001) The following declaration (Copy_CanReg_Text_Files_To_Local_Workon_Directory) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private bool Copy_CanReg_Text_Files_To_Local_Workon_Directory()
		//{
			//
			//bool result = false;
			//bool bResults = false;
			//
			//try
			//{
				//
				//bResults = false;
				//
				////-------------------------
				//// Delete Local Files
				//
				//if (File.Exists($"{gstrCanRegWorkOnPathLocal}carscurr.txt"))
				//{
					//AddItemToCanRegListBox("  !-Deleting Old Local CARSCURR.TXT");
					////UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					//File.Delete($"{gstrCanRegWorkOnPathLocal}carscurr.txt");
				//}
				//
				//if (File.Exists($"{gstrCanRegWorkOnPathLocal}carsownr.txt"))
				//{
					//AddItemToCanRegListBox("  !-Deleting Old Local CARSOWNR.TXT");
					////UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					//File.Delete($"{gstrCanRegWorkOnPathLocal}carsownr.txt");
				//}
				//
				////----------------------------------------------------------------
				//// Copy Server Files To The Local C:\CANREG\WORKON Directory
				//// Check To Make Sure Files Are There
				//
				//File.Copy($"{gstrCanRegWorkOnPath}carscurr.txt", gstrCanRegWorkOnPathLocal);
				//
				//if (File.Exists($"{gstrCanRegWorkOnPathLocal}carscurr.txt"))
				//{
					//
					//File.Copy($"{gstrCanRegWorkOnPath}carsownr.txt", gstrCanRegWorkOnPathLocal);
					//
					//if (File.Exists($"{gstrCanRegWorkOnPathLocal}carsownr.txt"))
					//{
						//bResults = true;
					//}
					//else
					//{
						//AddItemToCanRegListBox("Error - Could Not Find Local CARSOWNR.TXT File");
					//}
					//
				//}
				//else
				//{
					//AddItemToCanRegListBox("Error - Could Not Find Local CARSCURR.TXT File");
				//}
				//
				//
				//return bResults;
			//}
			//catch (System.Exception excep)
			//{
				//
				//gstrErrMsg = excep.Message;
				//gstrMsg = "CanReg - Copy_CanReg_Text_Files_To_Local_Workon_Directory_Error";
				//AddItemToCanRegListBox(gstrMsg);
				//AddItemToCanRegListBox(gstrErrMsg);
				//modAdminCommon.Report_Error($"{gstrMsg}: {gstrErrMsg}");
				//MessageBox.Show($"{gstrMsg}{Environment.NewLine}{gstrErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				//
				//result = false;
			//}
			//return result;
		//} // Copy_CanReg_Text_Files_To_Local_Workon_Directory

		private void cmdBrowse_Click(Object eventSender, EventArgs eventArgs)
		{

			string strFromFileName = "";
			string strToFileName = "";
			string strToFolderName = "";

			try
			{

				DisableButtons("");

				lbl_Status.Text = "";
				strToFolderName = txtDocumentDir.Text;

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.InitDir was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.DialogTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Title = "Canadian Registry";
				//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property mdi_ResearchAssistant.CommonDialog1.Flags was upgraded to mdi_ResearchAssistant.CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
				//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowReadOnly = false;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Filter = "Zip Files (*.zip)|*.zip|All Files (*.*)|*.*";
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName = "";
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowDialog();

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName != "")
				{

					//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					strFromFileName = mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName;

					if (File.Exists(strFromFileName))
					{

						if (Directory.Exists(strToFolderName))
						{

							// Date Formatting
							// https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.90).aspx
							strToFileName = $"{strToFolderName}{StringsHelper.Format(DateTime.Now, "yyyyMMdd_hhmmss")}.zip";

							if (File.Exists(strToFolderName))
							{
								//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								File.Delete(strToFolderName);
							}

							File.Copy(strFromFileName, strToFileName, true);

							//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							File.Delete(strFromFileName);

							lbl_Status.Text = "Copy Completed";

							lblFileName_Click(lblFileName, new EventArgs());

						}
						else
						{
							MessageBox.Show($"Unable To Find Document Folder{Environment.NewLine}{strToFolderName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If gfso.FolderExists(strToFolderName) = True Then

					}
					else
					{
						MessageBox.Show($"Unable To Find File{Environment.NewLine}{strFromFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If gfso.FileExists(strFromFileName) = True Then

				} // If mdi_ResearchAssistant.CommonDialog1.FileName <> "" Then

				EnableButtons();
			}
			catch
			{

				modAdminCommon.Report_Error($"cmdBrowse_Click_Error: {gstrErrMsg}");
			}

		} // cmdBrowse_Click

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/18/2013
		// Modified   : 04/18/2013
		// Procedure  : cmdDownload_Click
		// Parameters : None
		//
		// Returns    : None
		//
		// Notes      : Downloads the newest Canadian Registry zip file.  Unzips it, imports the
		// two files CARSCURR.TXT and CARSOWNR.TXT.
		//
		// Then runs a compare on the CARSCURR.TXT vs the Canadian_Registry table.
		//
		// 04/18/2013 - By David D. Cruger; Per Jackie; no need to process the Owner file. However
		// the import is already in process so I'm leaving that.
		//
		// ====================================================================================

		private void cmdDownload_Click(Object eventSender, EventArgs eventArgs)
		{

			string strURL = "";
			string strFileName = "";
			string strLocalFile = "";
			int iFileHandle = 0;
			byte[] bBuffer = null;

			try
			{

				if (cmdDownload.Enabled)
				{

					DisableButtons("");

					lbl_Status.Text = "";
					StatusList.Items.Clear();
					bStopProcess = false;

					// http://wwwapps2.tc.gc.ca/Saf-Sec-Sur/2/ccarcs/download/ccarcsdb.zip
					// http://wwwapps.tc.gc.ca/Saf-Sec-Sur/2/CCARCS-RIACC/DDZip.aspx

					strURL = txtWebsite.Text;

					AddItemToCanRegListBox("Retrieving Canadian Registry Files");

					// Date Formatting
					// https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.90).aspx
					strFileName = $"{StringsHelper.Format(DateTime.Now, "yyyyMMdd_hhmmss")}.zip";
					strLocalFile = $"{gstrCanRegMstrPath}{strFileName}";

					gstrCanRegZipFileName = $"{gstrCanRegMstrPath}{strFileName}";

					if (File.Exists(gstrCanRegZipFileName))
					{
						//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						File.Delete(gstrCanRegZipFileName);
					}
					Application.DoEvents();

					/*
					  gap-note axInetTran must be checked during Blazor stabilization.
					axInetTran.RequestTimeout = 480000; 
					axInetTran.AccessType = InetCtlsObjects.AccessConstants.icUseDefault;
					axInetTran.Protocol = InetCtlsObjects.ProtocolConstants.icHTTP;
					axInetTran.URL = strURL;

					//UPGRADE_WARNING: (1068) axInetTran.OpenURL() of type Variant is being forced to Array(byte). More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					bBuffer = (byte[]) axInetTran.OpenURL(axInetTran.URL, (int) InetCtlsObjects.DataTypeConstants.icByteArray);
					*/
					do
					{
						Application.DoEvents();
					}
					while(axInetTran.StillExecuting);

					iFileHandle = FileSystem.FreeFile();

					// Create a file from the retrieved data.
					// m_StrFile = \\jetnet4\canreg\masters\20060214.zip

					AddItemToCanRegListBox("Saving Canadian Registry Files");

					FileSystem.FileOpen(iFileHandle, gstrCanRegZipFileName, OpenMode.Binary, OpenAccess.Write, OpenShare.Default, -1);
					//UPGRADE_WARNING: (2080) Put was upgraded to FilePutObject and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
					FileSystem.FilePutObject(iFileHandle, bBuffer, 0);
					FileSystem.FileClose(iFileHandle);

					AddItemToCanRegListBox("Canadian Registry Files Have Been Downloaded");

					if (!cmdUnZip.Visible && !bStopProcess)
					{
						AddItemToCanRegListBox("UnZipping Canadian Registry Files");
						cmdUnZip_Click(cmdUnZip, new EventArgs());
						if (!bStopProcess)
						{
							//AddItemToCanRegListBox "Copy New Canadian Registry Files To The Local Drive C:\CANREG\WORKON\"
							//If Copy_CanReg_Text_Files_To_Local_Workon_Directory() = False Then
							//  bStopProcess = True
							//End If
						}
					}

					Application.DoEvents();

					if (!cmdImport.Visible && !bStopProcess)
					{
						AddItemToCanRegListBox("Importing Canadian Registry Files");
						cmdImport_Click(cmdImport, new EventArgs());
					}

					Application.DoEvents();

					if (!cmdCompare.Visible && !bStopProcess)
					{
						AddItemToCanRegListBox("Comparing Canadian Registry files");
						cmdCompare_Click(cmdCompare, new EventArgs());
					}

					if (!cmdCompare.Visible && !bStopProcess)
					{
						gstrMsg = "Canadian Registry - Download and Process Completed";
						AddItemToCanRegListBox(gstrMsg);
						lbl_Status.Text = gstrMsg;
					}

					EnableButtons();

				} // If cmdDownload.Enabled = True Then
			}
			catch (System.Exception excep)
			{

				gstrErrMsg = excep.Message;
				gstrMsg = "CanReg - cmdDownload_Click_Error";
				AddItemToCanRegListBox(gstrMsg);
				AddItemToCanRegListBox(gstrErrMsg);
				modAdminCommon.Report_Error($"{gstrMsg}: {gstrErrMsg}");
				MessageBox.Show($"{gstrMsg}{Environment.NewLine}{gstrErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				bStopProcess = true;
			}

		} // cmdDownload_Click

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/17/2013
		// Modified   : 04/17/2013
		// Function   : Import_CarsCurr
		// Parameters : ByVal strFileName As String
		//              ByRef lTotalCnt As Long
		//              ByRef dtMaxEffectiveDate As Date
		//
		// Returns    : Boolean
		//
		// Notes      : Reads the CARSCURR.TXT File and Imports the Data into the table
		// Canadian_Registry_Master_CarsCurr
		//
		// ====================================================================================

		private bool Import_CarsCurr(string strFileName, ref int lTotalCnt, ref System.DateTime dtMaxEffectiveDate)
		{

			bool result = false;
			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();

			string strQuery1 = "";
			string strAdd1 = "";

			int iField = 0;

			string strDate = "";
			System.DateTime dtDate = DateTime.FromOADate(0);

			bool bResults = false;

			try
			{

				bStopProcess = false;
				bResults = false;
				pbCanReg.Visible = true;
				lTotalCnt = 0;
				dtMaxEffectiveDate = DateTime.FromOADate(0);

				//UPGRADE_WARNING: (1068) gfso.GetFile().size of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				if (Convert.ToDouble((new FileInfo(strFileName)).Length) > 10000)
				{

					strConn = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={gstrCanRegWorkOnPath};Extended Properties='text;HDR=NO;FMT=Delimited'";
					//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					cntConn.setConnectionTimeout(30);
					//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					cntConn.setCursorLocation(CursorLocationEnum.adUseClient);
					//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
					cntConn.ConnectionString = strConn;
					cntConn.Open();

					AddItemToCanRegListBox("  !-Reading CARSCURR -- Please Wait");

					strQuery1 = $"SELECT * FROM {strFileName}";
					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						rstRec1.ActiveConnection = null; // Disconnected

						lTotalCnt = rstRec1.RecordCount;
						pbCanReg.Maximum = lTotalCnt + 1;
						pbCanReg.Minimum = 1;
						pbCanReg.Value = 1;

						AddItemToCanRegListBox($"  !-Records Found: {StringsHelper.Format(rstRec1.RecordCount, "#,###")}");

						strAdd1 = "SELECT * FROM Canadian_Registry_Master_CarsCurr WHERE (crmcc_id = -1) ";
						rstAdd1.Open(strAdd1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

						do 
						{ // Loop Until rstRec1.EOF = True

							pbCanReg.Value = Convert.ToInt32(pbCanReg.Value + 1);

							if (($"{Convert.ToString(rstRec1[0])} ").Trim() != "")
							{

								if ((($"{Convert.ToString(rstRec1[0])} ").Trim().IndexOf("rows selected") + 1) == 0)
								{

									rstAdd1.AddNew();

									rstAdd1["crmcc_ac_id"] = 0;
									rstAdd1["crmcc_journ_id"] = 0;

									iField = -1;

									iField++;
									rstAdd1["crmcc_mark"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_registration_sub_type_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_registration_sub_type_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_common_name"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_model_name"] = StringsHelper.Replace(($"{Convert.ToString(rstRec1[iField])} ").Trim(), "'", "", 1, -1, CompareMethod.Binary);

									iField++;
									rstAdd1["crmcc_mfr_serial_nbr"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_mfr_serial_nbr_compressed"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_id_plate_mfr_name"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_basis_for_registration"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_basis_for_registration_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_aircraft_category_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_aircraft_category_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++; // DATE
									strDate = ($"{Convert.ToString(rstRec1[iField])} ").Trim();
									strDate = $"{strDate.Substring(Math.Min(5, strDate.Length), Math.Min(2, Math.Max(0, strDate.Length - 5)))}/{strDate.Substring(Math.Min(8, strDate.Length), Math.Min(2, Math.Max(0, strDate.Length - 8)))}/{strDate.Substring(Math.Min(0, strDate.Length), Math.Min(4, Math.Max(0, strDate.Length)))}";
									dtDate = DateTime.FromOADate(0);
									if (Information.IsDate(strDate))
									{
										dtDate = DateTime.Parse(strDate);
										rstAdd1["crmcc_date_of_import"] = dtDate;
									}

									iField++;
									rstAdd1["crmcc_engine_mfr"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_powderglider_flag"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim().Substring(0, Math.Min(1, ($"{Convert.ToString(rstRec1[iField])} ").Trim().Length));

									iField++;
									rstAdd1["crmcc_engine_category_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_engine_category_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_number_of_engines"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_number_of_seats"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_air_weight_kilos"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_sale_reported"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim().Substring(0, Math.Min(1, ($"{Convert.ToString(rstRec1[iField])} ").Trim().Length));

									iField++; // DATE
									strDate = ($"{Convert.ToString(rstRec1[iField])} ").Trim();
									strDate = $"{strDate.Substring(Math.Min(5, strDate.Length), Math.Min(2, Math.Max(0, strDate.Length - 5)))}/{strDate.Substring(Math.Min(8, strDate.Length), Math.Min(2, Math.Max(0, strDate.Length - 8)))}/{strDate.Substring(Math.Min(0, strDate.Length), Math.Min(4, Math.Max(0, strDate.Length)))}";
									dtDate = DateTime.FromOADate(0);
									if (Information.IsDate(strDate))
									{
										dtDate = DateTime.Parse(strDate);
										rstAdd1["crmcc_issue_date"] = dtDate;
									}

									iField++; // DATE
									strDate = ($"{Convert.ToString(rstRec1[iField])} ").Trim();
									strDate = $"{strDate.Substring(Math.Min(5, strDate.Length), Math.Min(2, Math.Max(0, strDate.Length - 5)))}/{strDate.Substring(Math.Min(8, strDate.Length), Math.Min(2, Math.Max(0, strDate.Length - 8)))}/{strDate.Substring(Math.Min(0, strDate.Length), Math.Min(4, Math.Max(0, strDate.Length)))}";
									dtDate = DateTime.FromOADate(0);
									if (Information.IsDate(strDate))
									{
										dtDate = DateTime.Parse(strDate);
										rstAdd1["crmcc_effective_date"] = dtDate;
										if (dtDate > dtMaxEffectiveDate)
										{
											dtMaxEffectiveDate = dtDate;
										}
									}

									iField++; // DATE
									strDate = ($"{Convert.ToString(rstRec1[iField])} ").Trim();
									strDate = $"{strDate.Substring(Math.Min(5, strDate.Length), Math.Min(2, Math.Max(0, strDate.Length - 5)))}/{strDate.Substring(Math.Min(8, strDate.Length), Math.Min(2, Math.Max(0, strDate.Length - 8)))}/{strDate.Substring(Math.Min(0, strDate.Length), Math.Min(4, Math.Max(0, strDate.Length)))}";
									dtDate = DateTime.FromOADate(0);
									if (Information.IsDate(strDate))
									{
										dtDate = DateTime.Parse(strDate);
										rstAdd1["crmcc_ineffective_date"] = dtDate;
									}

									iField++;
									rstAdd1["crmcc_registered_purpose_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_registered_purpose_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_flight_authority_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_flight_authority_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_manufacture_or_assembly"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim().Substring(0, Math.Min(1, ($"{Convert.ToString(rstRec1[iField])} ").Trim().Length));

									iField++;
									rstAdd1["crmcc_country_mfr_assembly_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_country_mfr_assembly_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++; // DATE
									strDate = ($"{Convert.ToString(rstRec1[iField])} ").Trim();
									strDate = $"{strDate.Substring(Math.Min(5, strDate.Length), Math.Min(2, Math.Max(0, strDate.Length - 5)))}/{strDate.Substring(Math.Min(8, strDate.Length), Math.Min(2, Math.Max(0, strDate.Length - 8)))}/{strDate.Substring(Math.Min(0, strDate.Length), Math.Min(4, Math.Max(0, strDate.Length)))}";
									dtDate = DateTime.FromOADate(0);
									if (Information.IsDate(strDate))
									{
										dtDate = DateTime.Parse(strDate);
										rstAdd1["crmcc_date_mfr_assembly"] = dtDate;
									}

									iField++;
									rstAdd1["crmcc_base_of_operations_ctry_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;

									rstAdd1["crmcc_base_of_operations_ctry_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_base_province_or_state_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_base_province_or_state_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_city_airport"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_type_certification_number"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_registration_auth_status_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_registration_auth_status_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_multiple_owner_flag"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim().Substring(0, Math.Min(1, ($"{Convert.ToString(rstRec1[iField])} ").Trim().Length));

									iField++; // DATE
									strDate = ($"{Convert.ToString(rstRec1[iField])} ").Trim();
									strDate = $"{strDate.Substring(Math.Min(5, strDate.Length), Math.Min(2, Math.Max(0, strDate.Length - 5)))}/{strDate.Substring(Math.Min(8, strDate.Length), Math.Min(2, Math.Max(0, strDate.Length - 8)))}/{strDate.Substring(Math.Min(0, strDate.Length), Math.Min(4, Math.Max(0, strDate.Length)))}";
									dtDate = DateTime.FromOADate(0);
									if (Information.IsDate(strDate))
									{
										dtDate = DateTime.Parse(strDate);
										rstAdd1["crmcc_modified_date"] = dtDate;
									}

									iField++;
									rstAdd1["crmcc_mode_s_transponder_binary"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_physical_file_region_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_physical_file_region_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_ex_military_mark"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmcc_trimmed_mark"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									rstAdd1.UpdateBatch();

								} // If InStr(1, Trim(rstRec1.fields(0).Value & " "), "rows selected") = 0 Then

							} // If Trim(rstRec1.fields(0).Value & " ") <> "" Then

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

						AddItemToCanRegListBox("  !-Import CARSCURR - Completed");
						bResults = true;

						rstAdd1.Close();

					}
					else
					{
						AddItemToCanRegListBox("ERROR - CARSCURR Is EMPTY");
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();
					UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
					cntConn.Close();

				}
				else
				{
					AddItemToCanRegListBox("ERROR - CARSCURR File is Invalid.  Too small or empty");
				} // If gfso.GetFile(strFileName).Size > 10000 Then

				pbCanReg.Visible = false;

				rstAdd1 = null;

				rstRec1 = null;
				cntConn = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				gstrErrMsg = excep.Message;
				gstrMsg = "CanReg - Import_CarsCurr_Error";
				AddItemToCanRegListBox(gstrMsg);
				AddItemToCanRegListBox(gstrErrMsg);
				modAdminCommon.Report_Error($"{gstrMsg}: {gstrErrMsg}");
				MessageBox.Show($"{gstrMsg}{Environment.NewLine}{gstrErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				bStopProcess = true;
				result = false;
			}
			return result;
		} // Import_CarsCurr

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/17/2013
		// Modified   : 04/17/2013
		// Function   : Import_CarsOwnr
		// Parameters : ByVal strFileName As String
		//              ByRef lTotalCnt As Long
		//
		// Returns    : Boolean
		//
		// Notes      : Reads the CARSOWNR.TXT File and Imports the Data into the table
		// Canadian_Registry_Master_CarsOwnr
		//
		// ====================================================================================

		private bool Import_CarsOwnr(string strFileName, ref int lTotalCnt)
		{

			bool result = false;
			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();

			string strQuery1 = "";
			string strAdd1 = "";

			int iField = 0;

			string strDate = "";
			System.DateTime dtDate = DateTime.FromOADate(0);

			bool bResults = false;

			try
			{

				bStopProcess = false;
				bResults = false;
				pbCanReg.Visible = true;
				lTotalCnt = 0;

				//UPGRADE_WARNING: (1068) gfso.GetFile().size of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				if (Convert.ToDouble((new FileInfo(strFileName)).Length) > 10000)
				{

					strConn = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={gstrCanRegWorkOnPath};Extended Properties='text;HDR=NO;FMT=Delimited'";
					//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					cntConn.setConnectionTimeout(30);
					//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					cntConn.setCursorLocation(CursorLocationEnum.adUseClient);
					//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
					cntConn.ConnectionString = strConn;
					cntConn.Open();

					AddItemToCanRegListBox("  !-Reading CARSOWNR -- Please Wait");

					strQuery1 = $"SELECT * FROM {strFileName}";
					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						rstRec1.ActiveConnection = null; // Disconnected

						lTotalCnt = rstRec1.RecordCount + 1;
						pbCanReg.Maximum = lTotalCnt;
						pbCanReg.Minimum = 1;
						pbCanReg.Value = 1;

						AddItemToCanRegListBox($"  !-Records Found: {StringsHelper.Format(rstRec1.RecordCount, "#,###")}");

						strAdd1 = "SELECT * FROM Canadian_Registry_Master_CarsOwnr WHERE (crmco_id = -1) ";
						rstAdd1.Open(strAdd1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

						do 
						{ // Loop Until rstRec1.EOF = True Or Trim(rstRec1.fields(0).Value & " ") = ""

							pbCanReg.Value = Convert.ToInt32(pbCanReg.Value + 1);

							if (($"{Convert.ToString(rstRec1[0])} ").Trim() != "")
							{

								if ((($"{Convert.ToString(rstRec1[0])} ").Trim().IndexOf("rows selected") + 1) == 0)
								{

									rstAdd1.AddNew();

									rstAdd1["crmco_comp_id"] = 0;
									rstAdd1["crmco_journ_id"] = 0;

									iField = -1;

									iField++;
									rstAdd1["crmco_mark_line"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_full_name"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_trade_name"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_street_name1"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_street_name2"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_city"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_province_or_state_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_province_or_state_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_postal_code"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_country_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_country_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_type_of_owner_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_type_of_owner_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_active_flag"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_care_of"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_region_e"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_region_f"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_owner_name_old_format"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_mail_recipient"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									iField++;
									rstAdd1["crmco_trimmed_mark"] = ($"{Convert.ToString(rstRec1[iField])} ").Trim();

									rstAdd1.UpdateBatch();

								} // If InStr(1, Trim(rstRec1.fields(0).Value & " "), "rows selected") = 0 Then

							} // If Trim(rstRec1.fields(0).Value & " ") <> "" Then

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

						AddItemToCanRegListBox("  !-Import CARSOWNR - Completed");
						bResults = true;

						rstAdd1.Close();

					}
					else
					{
						AddItemToCanRegListBox("ERROR - CARSOWNR Is EMPTY");
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();
					UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
					cntConn.Close();

				}
				else
				{
					AddItemToCanRegListBox("ERROR - CARSOWNR File is Invalid.  Too small or empty");
				} // If gfso.GetFile(strFileName).Size > 10000 Then

				pbCanReg.Visible = false;

				rstAdd1 = null;

				rstRec1 = null;
				cntConn = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				gstrErrMsg = excep.Message;
				gstrMsg = "CanReg - Import_CarsOwnr_Error";
				AddItemToCanRegListBox(gstrMsg);
				AddItemToCanRegListBox(gstrErrMsg);
				modAdminCommon.Report_Error($"{gstrMsg}: {gstrErrMsg}");
				MessageBox.Show($"{gstrMsg}{Environment.NewLine}{gstrErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				bStopProcess = true;
				result = false;
			}
			return result;
		} // Import_CarsOwnr

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/17/2013
		// Modified   : 04/17/2013
		// Procedure  : cmdImport_Click
		// Parameters : None
		//
		// Returns    : None
		//
		// Notes      : Imports CARSCURR.TXT and CARSOWNR.TXT Files
		//
		// ====================================================================================

		private void cmdImport_Click(Object eventSender, EventArgs eventArgs)
		{

			System.DateTime dtEffectiveDate = DateTime.FromOADate(0);
			string strEffectiveDate = "";
			System.DateTime dtSelectedDate = DateTime.FromOADate(0);
			string strSelectedDate = "";
			string strTruncate = "";

			string strCarsCurrFileName = "";
			string strCarsOwnrFileName = "";
			int lTotalACCnt = 0;
			int lTotalOwrCnt = 0;
			string strMsg = "";

			try
			{

				DisableButtons("");

				strMsg = "";

				AddItemToCanRegListBox("Import Started");

				AddItemToCanRegListBox("Deleting Work Files");

				AddItemToCanRegListBox("  !-Truncate Master CarsCurr");
				strTruncate = "TRUNCATE TABLE Canadian_Registry_Master_CarsCurr";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strTruncate;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				AddItemToCanRegListBox("  !-Truncate Master CarsOwnr");
				strTruncate = "TRUNCATE TABLE Canadian_Registry_Master_CarsOwnr";
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = strTruncate;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				AddItemToCanRegListBox("Check for files: CARSCURR.TXT");
				strCarsCurrFileName = $"{gstrCanRegWorkOnPathLocal}CARSCURR.TXT";

				if (File.Exists(strCarsCurrFileName))
				{

					AddItemToCanRegListBox("Check for files: CARSOWNR.TXT");
					strCarsOwnrFileName = $"{gstrCanRegWorkOnPathLocal}CARSOWNR.TXT";

					if (File.Exists(strCarsOwnrFileName))
					{

						AddItemToCanRegListBox("Importing CARSCURR");

						//----------------------------------
						// Import CARSCURR.TXT

						if (Import_CarsCurr(strCarsCurrFileName, ref lTotalACCnt, ref dtEffectiveDate))
						{

							if (!bStopProcess)
							{

								lblTotalImported[1].Text = StringsHelper.Format(lTotalACCnt, "#,##0");

								AddItemToCanRegListBox("Importing CARSOWNR");

								//----------------------------------
								// Import CARSOWNR.TXT

								if (Import_CarsOwnr(strCarsOwnrFileName, ref lTotalOwrCnt))
								{

									if (!bStopProcess)
									{

										AddItemToCanRegListBox($"Imported Owner file has: {StringsHelper.Format(lTotalOwrCnt, "#,##0")} records");

										//-----------------------------------------------------------------------
										// Check The Effective Date If Less Than Selected Date Use The E-Date

										if (dtEffectiveDate > DateTime.FromOADate(0))
										{

											strEffectiveDate = dtEffectiveDate.ToString("MM/dd/yyyy");
											//UPGRADE_WARNING: (1068) DTSelect.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											strSelectedDate = Convert.ToString(DTSelect.GetValue());

											if (Information.IsDate(strSelectedDate))
											{

												dtSelectedDate = DateTime.Parse(strSelectedDate);

												if (((int) DateAndTime.DateDiff("D", dtSelectedDate, dtEffectiveDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) < 0)
												{
													DTSelect.SetValue(strEffectiveDate);
												}

											} // If IsDate(strSelectedDate) = True Then

										} // If dtEffectiveDate > 0 Then

										lblTotalImported[1].Text = StringsHelper.Format(lTotalACCnt, "#,##0");
										lblTotalImported[3].Text = StringsHelper.Format(lTotalOwrCnt, "#,##0");
										lblTotalImported[5].Text = strEffectiveDate;

										AddItemToCanRegListBox("Import Complete");
										AddItemToCanRegListBox($"Imported AC Registry has: {StringsHelper.Format(lTotalACCnt, "#,##0")} records");
										AddItemToCanRegListBox($"Imported Owner file has: {StringsHelper.Format(lTotalOwrCnt, "#,##0")} records");
										AddItemToCanRegListBox($"Highest AC Registry Date: {strEffectiveDate}");

									}
									else
									{
										AddItemToCanRegListBox("  !- Stop Process = True After Importing CARSOWNR");
									} // If bStopProcess = False Then

								}
								else
								{
									strMsg = "Error Importing - CARSOWNR.TXT";
									AddItemToCanRegListBox(strMsg);
									MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If Import_CarsOwnr(strCarsOwnrFileName, lTotalOwrCnt) = True Then

							}
							else
							{
								AddItemToCanRegListBox("  !- Stop Process = True After Importing CARSCURR");
							} // If bStopProcess = False Then

						}
						else
						{
							strMsg = "Error Importing - CARSCURR.TXT";
							AddItemToCanRegListBox(strMsg);
							MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If Import_CarsCurr(strCarsCurrFileName, lTotalACCnt, dtEffectiveDate) = True Then

					}
					else
					{
						strMsg = "Corrupted Zip File - CARSOWNR.TXT is Missing";
						AddItemToCanRegListBox(strMsg);
						MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If gfso.FileExists(strCarsOwnrFileName) = True Then

				}
				else
				{
					strMsg = "Corrupted Zip File - CARSCURR.TXT is Missing";
					AddItemToCanRegListBox(strMsg);
					MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If gfso.FileExists(strCarsCurrFileName) = True Then

				EnableButtons();
			}
			catch (System.Exception excep)
			{

				gstrErrMsg = excep.Message;
				gstrMsg = "CanReg - cmdImport_Error";
				AddItemToCanRegListBox(gstrMsg);
				AddItemToCanRegListBox(gstrErrMsg);
				modAdminCommon.Report_Error($"{gstrMsg}: {gstrErrMsg}");
				MessageBox.Show($"{gstrMsg}{Environment.NewLine}{gstrErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				bStopProcess = true;
			}

		} // cmdImport_Click

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/17/2013
		// Modified   : 04/17/2013
		// Procedure  : Return_Aircraft_Information
		// Parameters : ByVal strRegNbr As String
		//              ByVal strSerNbr As String
		//              ByVal strHBModelId As String
		//              ByRef lACId As Long
		//              ByRef lHBAModId As Long
		//              ByRef strHBAirframeType As String
		//              ByRef strHBMakeType As String
		//              ByRef strHBMake As String
		//              ByRef strHBModel As String
		//              ByRef strHBSerNbr As String
		//              ByRef strStatus As String
		//
		// Returns    : None
		//
		// Notes      : Tries to find the Homebase Aircraft Record By the RegNbr and the
		// Canadian AmodId List.  If it finds more than one record filter by SerNbr.
		// If it finds one use that record.
		//
		// ====================================================================================

		private void Return_Aircraft_Information(string strRegNbr, string strSerNbr, string strHBModelId, ref int lACId, ref int lHBAModId, ref string strHBAirframeType, ref string strHBMakeType, ref string strHBMake, ref string strHBModel, ref string strHBSerNbr, ref string strStatus)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			bool bFound = false;

			try
			{

				lACId = 0;
				lHBAModId = 0;
				strHBAirframeType = "";
				strHBMakeType = "";
				strHBMake = "";
				strHBModel = "";
				strHBSerNbr = "";
				strStatus = "";
				bFound = false;

				if (strRegNbr != "" && strHBModelId != "")
				{

					strQuery1 = "SELECT amod_id, amod_airframe_type_code, amod_type_code, amod_make_name, amod_model_name, ac_id, ac_ser_no_full ";
					strQuery1 = $"{strQuery1}FROM Aircraft_Model WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Aircraft WITH (NOLOCK) ON amod_id = ac_amod_id ";
					strQuery1 = $"{strQuery1}WHERE (amod_id IN ({strHBModelId})) ";
					strQuery1 = $"{strQuery1}AND (ac_journ_id = 0) ";
					strQuery1 = $"{strQuery1}AND (ac_reg_no = '{strRegNbr}' ";
					strQuery1 = $"{strQuery1}  OR ac_reg_no = 'C-{strRegNbr}' ";
					strQuery1 = $"{strQuery1}  OR ac_reg_no = '{strRegNbr.Substring(0, Math.Min(1, strRegNbr.Length))}-{strRegNbr.Substring(Math.Min(1, strRegNbr.Length))}' ";
					strQuery1 = $"{strQuery1}    ) ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						if (rstRec1.RecordCount > 1)
						{
							rstRec1.Filter = $"(ac_ser_no_full = '{strSerNbr}') ";
							if (!rstRec1.BOF && !rstRec1.EOF)
							{
								bFound = true;
							}
							else
							{
								strStatus = "More Than 1 HB RegNbr. Filter By SerNbr Did Not Work";
							}
						}
						else
						{
							bFound = true;
						} // If rstRec1.RecordCount > 1 Then

						if (bFound)
						{
							lHBAModId = Convert.ToInt32(rstRec1["amod_ID"]);
							strHBAirframeType = Convert.ToString(rstRec1["amod_airframe_type_code"]);
							strHBMakeType = Convert.ToString(rstRec1["amod_type_code"]);
							strHBMake = Convert.ToString(rstRec1["amod_make_name"]);
							strHBModel = Convert.ToString(rstRec1["amod_model_name"]);
							strHBSerNbr = Convert.ToString(rstRec1["ac_ser_no_full"]);
							strStatus = "Found";
						}

						rstRec1.Filter = "";

					}
					else
					{
						strStatus = "Could Not Find HB Aircraft By RegNbr";
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strRegNbr <> "" And strHBModelId <> "" Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				gstrErrMsg = excep.Message;
				gstrMsg = "CanReg - Return_Aircraft_Information_Error";
				AddItemToCanRegListBox(gstrMsg);
				AddItemToCanRegListBox(gstrErrMsg);
				modAdminCommon.Report_Error($"{gstrMsg}: {gstrErrMsg}");
				MessageBox.Show($"{gstrMsg}{Environment.NewLine}{gstrErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				bStopProcess = true;
			}

		} // Return_Aircraft_Information

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 02/16/2006
		// Modified   : 02/16/2006
		// Function   : Add_New_Or_Update_Aircraft_Registry_Records
		// Parameters : ByRef rstHBCurr As ADODB.Recordset      ' Homebase Canadian_Registry
		//              ByRef rstHBCRModels As ADODB.Recordset  ' Homebase Conadian_Registry_Models
		//              ByRef rstCRCurr As ADODB.Recordset      ' New Canadian_Registry_Master_CarsCurr
		//              ByRef strEMail As String                ' Continue To Build EMail
		//
		// Returns    : Boolean
		//
		// Notes      : Finds New Records in The CARSCURR.TXT File And Adds Or Updates
		// The Canadian_Registry Table
		//
		// Find The New Imported Data By The Issue or Effective Date and either add the new
		// record or update the existing one.
		//
		// ====================================================================================

		private bool Add_New_Or_Update_Aircraft_Registry_Records(ADORecordSetHelper rstHBCurr, ADORecordSetHelper rstHBCRModels, ADORecordSetHelper rstCRCurr, ref string strEMail)
		{

			bool result = false;
			int lTot1 = 0;
			int lCnt1 = 0;
			int lChg1 = 0;
			int lAdd1 = 0;

			int lACId = 0;
			string strACId = "";
			int lJournId = 0;
			string strJournId = "";

			string strACCTRep = "";
			string strLastedChange = "";
			int lAModId = 0;
			string strAModId = "";
			string strStatus = "";
			string strStatus1 = "";

			string strMake = "";
			string strModel = "";
			string strRegNbr = "";
			string strSerNbr = "";

			int lHBAModId = 0;
			string strHBModelId = "";
			string strHBAirframeType = "";
			string strHBMakeType = "";
			string strHBMake = "";
			string strHBModel = "";
			string strHBSerNbr = "";
			string strHBAcctRep = "";

			bool bResults = false;

			try
			{

				bResults = false;

				AddItemToCanRegListBox("Add New/Update Aircraft Registry Records");

				lJournId = 0;
				strJournId = "0";

				lbl_Status.Text = "";

				//----------------------------------------
				// Find Issue Date Or Effective Date

				lCnt1 = 0;
				lAdd1 = 0;
				lChg1 = 0;

				pbCanReg.Visible = true;
				pbCanReg.Maximum = rstCRCurr.RecordCount;
				pbCanReg.Minimum = 1;
				pbCanReg.Value = 1;

				AddItemToCanRegListBox($"  !-Records Found: {StringsHelper.Format(rstCRCurr.RecordCount, "#,###")}");

				do 
				{ // Loop Until rstCRCurr.EOF = True Or bStopProcess = True

					lCnt1++;

					strMake = ($"{Convert.ToString(rstCRCurr["crmcc_common_name"])} ").Trim();
					strModel = ($"{Convert.ToString(rstCRCurr["crmcc_model_name"])} ").Trim();
					strRegNbr = ($"{Convert.ToString(rstCRCurr["crmcc_mark"])} ").Trim();
					strSerNbr = ($"{Convert.ToString(rstCRCurr["crmcc_mfr_serial_nbr"])} ").Trim();

					lbl_Status.Text = $"Record #: {StringsHelper.Format(lCnt1, "#,###")}" +
					                  $" RegNbr: {strRegNbr}" +
					                  $"  A/C: {strMake} {strModel}";

					strEMail = $"{strEMail}<tr>{Environment.NewLine}";
					strEMail = $"{strEMail}<td>{strMake} {strModel}</td>{Environment.NewLine}";
					strEMail = $"{strEMail}<td>{strRegNbr}</td>{Environment.NewLine}";
					strEMail = $"{strEMail}<td>{strSerNbr}</td>{Environment.NewLine}";

					//--------------------------------------
					// Now Find Canadian Model Record

					strHBModelId = "";

					rstHBCRModels.Filter = $"(crm_make_name= '{StringsHelper.Replace(strMake, "'", "''", 1, -1, CompareMethod.Binary)}') AND (crm_model_name = '{StringsHelper.Replace(strModel, "'", "''", 1, -1, CompareMethod.Binary)}') ";

					if (!rstHBCRModels.BOF && !rstHBCRModels.EOF)
					{

						strHBModelId = ($"{Convert.ToString(rstHBCRModels["crm_amod_list"])} ").Trim();

						//---------------------------------------------------------------------------
						// Now Find The Current Canadian Aircraft Registry Record (If Exists)

						rstHBCurr.Filter = $"(cr_regno = '{($"{Convert.ToString(rstCRCurr["crmcc_mark"])} ").Trim()}') ";

						strStatus1 = "";
						lACId = 0;
						strACId = "0";

						if (!rstHBCurr.BOF && !rstHBCurr.EOF)
						{

							//------------------------
							// Update Record

							lChg1++;
							strStatus = "Update Canadian_Registry Table";

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstHBCurr["cr_ac_id"]))
							{
								lACId = Convert.ToInt32(rstHBCurr["cr_ac_id"]);
								strACId = lACId.ToString();
							}
							else
							{
								rstHBCurr["cr_ac_id"] = 0;
							}

						}
						else
						{
							// Add It In To the Canadian_Registry Table

							//-------------------------
							// Add - New Record
							lAdd1++;
							strStatus = "Added To Registry Table";

							rstHBCurr.AddNew();

						} // If rstHBCurr.BOF = False And rstHBCurr.EOF = False Then

						//-----------------------------------------------
						// If Not ACID Try To Find Homebase Record

						if (lACId == 0)
						{

							Return_Aircraft_Information(strRegNbr, strSerNbr, strHBModelId, ref lACId, ref lHBAModId, ref strHBAirframeType, ref strHBMakeType, ref strHBMake, ref strHBModel, ref strHBSerNbr, ref strStatus1);

							if (strStatus1 == "Found")
							{
								rstHBCurr["cr_airframe_type"] = strHBAirframeType;
								rstHBCurr["cr_aircraft_type"] = strHBMakeType;
								rstHBCurr["cr_ac_id"] = lACId;
								rstHBCurr["cr_amod_id"] = lHBAModId;
							}
							else
							{
								strStatus = $"{strStatus} - {strStatus1}";
							} // If strStatus1 = "Found" Then

						} // If lACId = 0 Then

						rstHBCurr["cr_journ_id"] = lJournId;
						rstHBCurr["cr_regno"] = ($"{Convert.ToString(rstCRCurr["crmcc_mark"])} ").Trim();
						rstHBCurr["cr_make_name"] = ($"{Convert.ToString(rstCRCurr["crmcc_common_name"])} ").Trim();
						rstHBCurr["cr_model_name"] = ($"{Convert.ToString(rstCRCurr["crmcc_model_name"])} ").Trim();
						rstHBCurr["cr_serial"] = ($"{Convert.ToString(rstCRCurr["crmcc_mfr_serial_nbr"])} ").Trim();
						rstHBCurr["cr_manufacturer"] = ($"{Convert.ToString(rstCRCurr["crmcc_id_plate_mfr_name"])} ").Trim();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstCRCurr["crmcc_issue_date"]))
						{
							if (Information.IsDate(rstCRCurr["crmcc_issue_date"]))
							{
								rstHBCurr["cr_issue_date"] = DateTime.Parse(($"{Convert.ToString(rstCRCurr["crmcc_issue_date"])} ").Trim());
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstCRCurr["crmcc_sale_reported"]))
						{
							if (Information.IsDate(rstCRCurr["crmcc_sale_reported"]))
							{
								rstHBCurr["cr_sale_reported"] = DateTime.Parse(($"{Convert.ToString(rstCRCurr["crmcc_sale_reported"])} ").Trim());
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstCRCurr["crmcc_effective_date"]))
						{
							if (Information.IsDate(rstCRCurr["crmcc_effective_date"]))
							{
								rstHBCurr["cr_effective_date"] = DateTime.Parse(($"{Convert.ToString(rstCRCurr["crmcc_effective_date"])} ").Trim());
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstCRCurr["crmcc_ineffective_date"]))
						{
							if (Information.IsDate(rstCRCurr["crmcc_ineffective_date"]))
							{
								rstHBCurr["cr_ineffective_date"] = DateTime.Parse(($"{Convert.ToString(rstCRCurr["crmcc_ineffective_date"])} ").Trim());
							}
						}

						rstHBCurr["cr_base_country"] = ($"{Convert.ToString(rstCRCurr["crmcc_base_of_operations_ctry_e"])} ").Trim();
						rstHBCurr["cr_base_state"] = ($"{Convert.ToString(rstCRCurr["crmcc_base_province_or_state_e"])} ").Trim();
						rstHBCurr["cr_base_city"] = ($"{Convert.ToString(rstCRCurr["crmcc_city_airport"])} ").Trim();
						rstHBCurr["cr_reg_status"] = ($"{Convert.ToString(rstCRCurr["crmcc_registration_auth_status_e"])} ").Trim();
						rstHBCurr["cr_multiple_owner"] = ($"{Convert.ToString(rstCRCurr["crmcc_multiple_owner_flag"])} ").Trim();

						rstHBCurr["cr_update_date"] = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
						rstHBCurr["cr_latest_change"] = StringsHelper.Replace(strStatus, "<br/>", " ", 1, -1, Microsoft.VisualBasic.CompareMethod.Binary);

						rstHBCurr.UpdateBatch();

						rstHBCurr.Filter = ""; // Clear Filter

					}
					else
					{
						strStatus = "Model Not Researched";
					} // If rstHBCRModels.BOF = False And rstHBCRModels.EOF = False Then

					rstHBCRModels.Filter = ""; // Clear Filter

					strEMail = $"{strEMail}<td>{strStatus}</td>{Environment.NewLine}";
					strEMail = $"{strEMail}</tr>{Environment.NewLine}";

					rstCRCurr.MoveNext();
					Application.DoEvents();

					pbCanReg.Value = lCnt1;

				}
				while(!(rstCRCurr.EOF || bStopProcess));

				AddItemToCanRegListBox($"  !-Records Processed: {StringsHelper.Format(lCnt1, "#,###")} Added: {StringsHelper.Format(lAdd1, "#,###")}  Changed: {StringsHelper.Format(lChg1, "#,###")}");

				bResults = true;
				pbCanReg.Visible = false;
				rstCRCurr.Filter = ""; // Clear Filter


				return bResults;
			}
			catch (System.Exception excep)
			{

				gstrErrMsg = excep.Message;
				gstrMsg = "CanReg - Add_New_Or_Update_Aircraft_Registry_Records_Error";
				AddItemToCanRegListBox(gstrMsg);
				AddItemToCanRegListBox(gstrErrMsg);
				modAdminCommon.Report_Error($"{gstrMsg}: {gstrErrMsg}");
				MessageBox.Show($"{gstrMsg}{Environment.NewLine}{gstrErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				bStopProcess = true;
				result = false;
			}
			return result;
		} // Add_New_Or_Update_Aircraft_Registry_Records

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/18/2013
		// Modified   : 04/18/2013
		// Procedure  : Save_EMail_To_Log_File
		// Parameters : ByVal strEMail As String
		//
		// Returns    : None
		//
		// Notes      : Writes EMail HTML file to disk
		//
		// ====================================================================================

		private void Save_EMail_To_Log_File(string strEMail)
		{
			StreamWriter tsFileWriter = null;

			Object fso = new Object();
			FileStream tsFile = null; // Text Stream File Object for Writting to the Log File
			bool bResults = false;
			string strFileName = "";
			string strLocalFile = "";

			string strDT = ""; // Date/Time

			try
			{

				// Date Formatting
				// https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.90).aspx
				strFileName = $"EMail_{StringsHelper.Format(DateTime.Now, "yyyyMMdd_hhmmss")}.html";

				if (modCommon.MakeSureDirectoryExists(gstrCanRegEMailPath))
				{

					strLocalFile = $"{gstrCanRegEMailPath}{strFileName}";
					tsFile = new FileStream(strLocalFile, FileMode.Append, FileAccess.Write);
					tsFileWriter = new StreamWriter(tsFile);
					tsFileWriter.WriteLine(strEMail);
					tsFileWriter.Close(); // Close File

					tsFile = null; // Release Memory

				} // If MakeSureDirectoryExists(gstrCanRegEMailPath) = True Then
			}
			catch (System.Exception excep)
			{

				gstrErrMsg = excep.Message;
				gstrMsg = "CanReg - Save_EMail_To_Log_File_Error";
				AddItemToCanRegListBox(gstrMsg);
				AddItemToCanRegListBox(gstrErrMsg);
				modAdminCommon.Report_Error($"{gstrMsg}: {gstrErrMsg}");
				MessageBox.Show($"{gstrMsg}{Environment.NewLine}{gstrErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // Save_EMail_To_Log_File

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/18/2013
		// Modified   : 04/18/2013
		// Procedure  : cmdCompare_Click
		// Parameters : None
		//
		// Returns    : None
		//
		// Notes      : Compares the new CARSCURR.TXT import file to the Canadian_Registry table
		//
		// 04/19/2013 - By David D. Cruger; Per Jackie no need to process the CARSOWNR.TXT
		//
		// ====================================================================================

		private void cmdCompare_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstHBCurr = new ADORecordSetHelper(); // Homebase Canadian Registry Aircraft
			ADORecordSetHelper rstCRCurr = new ADORecordSetHelper(); // CARSCURR.TXT - Aircraft
			ADORecordSetHelper rstHBCRModels = new ADORecordSetHelper(); // Homebase Canadian Registry Aircraft Models

			string strQuery1 = "";
			string strQuery2 = "";
			string strQuery3 = "";

			string strSelectedDate = "";

			bool bResults = false;
			string strStatus = "";
			string errMsg = "";

			string strSubject = "";
			string strEMail = "";
			string strHTMLLine = "";

			try
			{

				if (cmdCompare.Enabled)
				{

					DisableButtons("");
					bResults = false;

					errMsg = "start";
					modAdminCommon.Record_Event("CANREG", "Start Registry Compare");

					//UPGRADE_WARNING: (1068) DTSelect.Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					strSelectedDate = Convert.ToString(DTSelect.GetValue()); //get selected date
					strSubject = $"Canadian Registry Processing Report For {strSelectedDate} Processed On {DateTime.Now.ToString("MM/dd/yyyy")} ";

					//Set up email header
					strEMail = $"<HTML>{Environment.NewLine}";
					strEMail = $"{strEMail}<BODY>{Environment.NewLine}";
					strEMail = $"{strEMail}<h2>{Environment.NewLine}";
					strEMail = $"{strEMail}Date: {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}<br/>{Environment.NewLine}";
					strEMail = $"{strEMail}To: {txt_EMailAddress.Text}</br>{Environment.NewLine}";
					strEMail = $"{strEMail}</h2>{Environment.NewLine}";

					strEMail = $"{strEMail}<TABLE width='750' cellpadding='2' cellspacing='0' border='1'>{Environment.NewLine}";
					strEMail = $"{strEMail}<TR><TH colspan='4'>{strSubject}</TH></TR>{Environment.NewLine}{Environment.NewLine}";

					//PUT IN THE DATA HEADER
					strEMail = $"{strEMail}<TR align='center'>{Environment.NewLine}";
					strEMail = $"{strEMail}<TH>MAKE-MODEL#</TH>{Environment.NewLine}";
					strEMail = $"{strEMail}<TH>REG NO</TH>{Environment.NewLine}";
					strEMail = $"{strEMail}<TH>SERIAL#</TH>{Environment.NewLine}";
					strEMail = $"{strEMail}<TH>STATUS</TH>{Environment.NewLine}";
					strEMail = $"{strEMail}</TR>{Environment.NewLine}{Environment.NewLine}";

					//-------------------------------
					// Open All Recordset
					//-------------------------------

					AddItemToCanRegListBox("Opening HB - Canadian Registry Aircraft");

					strQuery1 = "SELECT * FROM Canadian_Registry ORDER BY cr_make_name, cr_model_name, cr_serial ";
					rstHBCurr.CursorLocation = CursorLocationEnum.adUseClient;
					rstHBCurr.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					if (!rstHBCurr.BOF && !rstHBCurr.EOF)
					{

						//-------------------------------

						AddItemToCanRegListBox("Opening - CARSCURR.TXT");

						strQuery2 = "SELECT * FROM Canadian_Registry_Master_CarsCurr ";
						strQuery2 = $"{strQuery2}WHERE (crmcc_issue_date = '{strSelectedDate}') ";
						strQuery2 = $"{strQuery2}OR (crmcc_effective_date = '{strSelectedDate}') ";
						strQuery2 = $"{strQuery2}ORDER BY crmcc_model_name, crmcc_mfr_serial_nbr ";

						rstCRCurr.CursorLocation = CursorLocationEnum.adUseClient;
						rstCRCurr.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

						if (!rstCRCurr.BOF && !rstCRCurr.EOF)
						{

							//-------------------------------

							AddItemToCanRegListBox("Opening HB - Canadian Registry Aircraft Models ");
							strQuery3 = "SELECT * FROM Canadian_Registry_Models WITH (NOLOCK) ORDER BY crm_make_name, crm_model_name";

							rstHBCRModels.CursorLocation = CursorLocationEnum.adUseClient;
							rstHBCRModels.Open(strQuery3, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							if (!rstHBCRModels.BOF && !rstHBCRModels.EOF)
							{

								//--------------------------------------------
								// Main Work Load Is Here

								if (Add_New_Or_Update_Aircraft_Registry_Records(rstHBCurr, rstHBCRModels, rstCRCurr, ref strEMail))
								{

									bResults = true;

								}
								else
								{
									AddItemToCanRegListBox("Error - Could NOT Add New/Update Aircraft Registry_Records");
								} // If Add_New_Or_Update_Aircraft_Registry_Records(rstHBCurr, rstHBCRModels, rstCRCurr, strEMail) = True Then

							}
							else
							{
								strStatus = "No Records Found In Homebase Canadian_Registry_Models Table";
								AddItemToCanRegListBox($"Error - {strStatus}");
								strEMail = $"{strEMail}<TR><TH colspan='4'>{strStatus}</TH></TR>{Environment.NewLine}{Environment.NewLine}";
								bStopProcess = true;
							} // If rstHBCRModels.BOF = False And rstHBCRModels.EOF = False Then

							rstHBCRModels.Close();

						}
						else
						{
							strStatus = $"No Records Found In CARSCURR.TXT For Selected Date: [{strSelectedDate}]";
							AddItemToCanRegListBox(strStatus);
							strEMail = $"{strEMail}<TR><TH colspan='4'>{strStatus}</TH></TR>{Environment.NewLine}{Environment.NewLine}";
							bStopProcess = true;
						} // If rstCRCurr.BOF = False And rstCRCurr.EOF = False Then

						rstCRCurr.Close();

					}
					else
					{
						strStatus = "No Records In Homebase Canadian_Registry Table";
						AddItemToCanRegListBox($"Error - {strStatus}");
						strEMail = $"{strEMail}<TR><TH colspan='4'>{strStatus}</TH></TR>{Environment.NewLine}{Environment.NewLine}";
						bStopProcess = true;
					} // If rstHBCurr.BOF = False And rstHBCurr.EOF = False Then

					rstHBCurr.Close();

					strEMail = $"{strEMail}</TABLE>{Environment.NewLine}{Environment.NewLine}";
					strEMail = $"{strEMail}</BODY>{Environment.NewLine}{Environment.NewLine}";
					strEMail = $"{strEMail}</HTML>{Environment.NewLine}{Environment.NewLine}";

					//--------------------------------------------------------------------
					// Now Check To See If Process Stopped And Results Are Still Good

					if (!bStopProcess && bResults)
					{

						Save_EMail_To_Log_File(strEMail);

						modEmail.EMail_Message("Homebase CanReg", "service@jetnet.com", txt_EMailAddress.Text, "", "", strSubject, strEMail, "", true);

					} // If bStopProcess = False Then

					EnableButtons();

				} // If cmdCompare.Enabled = True Then

				rstHBCRModels = null;
				rstCRCurr = null;
				rstHBCurr = null;
			}
			catch (System.Exception excep)
			{

				gstrErrMsg = excep.Message;
				gstrMsg = "CanReg - cmdCompare_Error";
				AddItemToCanRegListBox(gstrMsg);
				AddItemToCanRegListBox(gstrErrMsg);
				modAdminCommon.Report_Error($"{gstrMsg}: {gstrErrMsg}");
				MessageBox.Show($"{gstrMsg}{Environment.NewLine}{gstrErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				bStopProcess = true;
			}

		} // cmdCompare

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/18/2013
		// Modified   : 04/18/2013
		// Procedure  : cmdUnZip_Click
		// Parameters : None
		//
		// Returns    : None
		//
		// Notes      : Compares the new CARSCURR.TXT import file to the Canadian_Registry table
		//
		// 04/19/2013 - By David D. Cruger; Per Jackie no need to process the CARSOWNR.TXT
		//
		// ====================================================================================

		private void cmdUnZip_Click(Object eventSender, EventArgs eventArgs)
		{

			//unzip downloaded file
			string strLocalFile = "";
			string strMsg = "";
			string strErrMsg = "";

			try
			{

				DisableButtons("");

				AddItemToCanRegListBox("Unzip Started");

				gstrCanRegZipFileName = $"{txtDocumentDir.Text}{txtFileName.Text}";

				strLocalFile = $"{gstrCanRegWorkOnPathLocal}CARSCURR.TXT";
				if (File.Exists(strLocalFile))
				{
					//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					File.Delete(strLocalFile);
				}

				strLocalFile = $"{gstrCanRegWorkOnPathLocal}CARSOWNR.TXT";
				if (File.Exists(strLocalFile))
				{
					//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					File.Delete(strLocalFile);
				}

				strLocalFile = $"{gstrCanRegWorkOnPathLocal}CARSLAY.OUT";
				if (File.Exists(strLocalFile))
				{
					//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					File.Delete(strLocalFile);
				}

				if (File.Exists(gstrCanRegZipFileName))
				{

					// 03/01/2018 - By David D. Cruger
					// Replace XCeed with Chilkat To UnZip

					if (modZip.UnZipToFolder_Chilkat(gstrCanRegZipFileName, gstrCanRegWorkOnPathLocal, false, ref strErrMsg))
					{
						bStopProcess = true;
						AddItemToCanRegListBox("UnZip Completed");
					}
					else
					{
						bStopProcess = false;
						lbl_Status.Text = "UnZip Error";
						MessageBox.Show($"Unable To UnZip CANREG File{Environment.NewLine}{Environment.NewLine}{strErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

				}
				else
				{
					MessageBox.Show($"Unable To Find Zip File{Environment.NewLine}{Environment.NewLine}{gstrCanRegZipFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} //If gfso.FileExists(gstrCanRegZipFileName) = True Then

				AddItemToCanRegListBox("Unzip Ended");

				EnableButtons();
			}
			catch (System.Exception excep)
			{

				gstrErrMsg = excep.Message;
				gstrMsg = "CanReg - cmdUnZip_Click_Error";
				AddItemToCanRegListBox(gstrMsg);
				AddItemToCanRegListBox(gstrErrMsg);
				modAdminCommon.Report_Error($"{gstrMsg}: {gstrErrMsg}");
				MessageBox.Show($"{gstrMsg}{Environment.NewLine}{gstrErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				bStopProcess = true;
			}

		} // cmdUnZip_Click

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/18/2013
		// Modified   : 04/18/2013
		// Procedure  : Form_Load
		// Parameters : None
		//
		// Returns    : None
		//
		// Notes      : Standard Form Load. Sets the Selected Date.  Set the global path variables
		// and checks to see if user is allowed to download and process these files.
		//
		// ====================================================================================

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			System.DateTime vSelectedDate = DateTime.FromOADate(0);
			string strCanUserProcess = "";

			cmdDownload.Enabled = false;

			lblTotalImported[1].Text = "#,##0";
			lblTotalImported[3].Text = "#,##0";
			lblTotalImported[5].Text = "ccyymmdd";

			int iDOW = Convert.ToInt32(Double.Parse(StringsHelper.Format(DateTime.Now, "W"))); //1=Sunday
			if (iDOW == 1)
			{
				vSelectedDate = DateTime.Today.AddDays(-2);
			}
			else if (iDOW == 2)
			{  //2=Monday
				vSelectedDate = DateTime.Today.AddDays(-3);
			}
			else
			{
				// WeekDay
				vSelectedDate = DateTime.Today.AddDays(-1);
			}

			lbl_Status.Text = "";
			bStopProcess = false;

			DTSelect.SetValue(vSelectedDate);

			// \\jetnet4\canreg\
			gstrCanRegPath = ReturnCanadianRegistryDirectory();
			if (gstrCanRegPath.Substring(Math.Max(gstrCanRegPath.Length - 1, 0)) != "\\")
			{
				gstrCanRegPath = $"{gstrCanRegPath}\\";
			}

			//----------------------------------------------
			// Now Make Sure All The Directories Exists

			gstrCanRegMstrPath = $"{gstrCanRegPath}masters\\"; // \\jetnet4\canreg\masters\
			if (modCommon.MakeSureDirectoryExists(gstrCanRegMstrPath))
			{

				txtDocumentDir.Text = $"{gstrCanRegPath}MASTERS\\";
				txtWebsite.Text = ReturnCanadianRegistryWebSiteFile();

				gstrCanRegWorkOnPath = $"{gstrCanRegPath}workon\\"; // \\jetnet4\canreg\workon\
				if (modCommon.MakeSureDirectoryExists(gstrCanRegWorkOnPath))
				{

					gstrCanRegWorkOnPathLocal = "C:\\CANREG\\WORKON\\"; // C:\CANREG\WORKON\
					if (modCommon.MakeSureDirectoryExists(gstrCanRegWorkOnPathLocal))
					{

						gstrCanRegLogPath = $"{gstrCanRegPath}log\\"; // \\jetnet4\canreg\log\
						if (modCommon.MakeSureDirectoryExists(gstrCanRegLogPath))
						{

							gstrCanRegEMailPath = $"{gstrCanRegPath}email\\"; // \\jetnet4\canreg\email\"
							if (modCommon.MakeSureDirectoryExists(gstrCanRegEMailPath))
							{

								// ONLY ALLOW SPECIFIC USERS TO SEE THE PROCESSING TAB
								strCanUserProcess = $"{modCommon.DLookUp("user_process_canadian_reg_flag", "[User]", $"User_id='{modAdminCommon.gbl_User_ID}'")}";

								if (strCanUserProcess == "Y")
								{
									cmdDownload.Enabled = true;
								}

								if (modAdminCommon.gbl_User_ID.ToLower() == "dcr" || modAdminCommon.gbl_User_ID.ToLower() == "mvit")
								{
									txt_EMailAddress.Text = modCommon.DLookUp("user_email_address", "[User]", $"user_id='{modAdminCommon.gbl_User_ID.ToLower()}'").Trim();
								}
								else
								{
									txt_EMailAddress.Text = ($"{modCommon.DLookUp("aconfig_email_canadian_reg", "Application_Configuration")}").Trim();
								}

							}
							else
							{
								MessageBox.Show($"Error - Directory Does Not Exists{Environment.NewLine}{gstrCanRegEMailPath}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If MakeSureDirectoryExists(gstrCanRegEMailPath) = True Then

						}
						else
						{
							MessageBox.Show($"Error - Directory Does Not Exists{Environment.NewLine}{gstrCanRegLogPath}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If MakeSureDirectoryExists(gstrCanRegLogPath) = True Then

					}
					else
					{
						MessageBox.Show($"Error - Directory Does Not Exists{Environment.NewLine}{gstrCanRegWorkOnPathLocal}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If MakeSureDirectoryExists(gstrCanRegWorkOnPathLocal) = True Then

				}
				else
				{
					MessageBox.Show($"Error - Directory Does Not Exists{Environment.NewLine}{gstrCanRegWorkOnPath}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If MakeSureDirectoryExists(gstrCanRegWorkOnPath) = True Then

			}
			else
			{
				MessageBox.Show($"Error - Directory Does Not Exists{Environment.NewLine}{gstrCanRegMstrPath}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If MakeSureDirectoryExists(gstrCanRegMstrPath) = True Then

		} // Form_Load

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/18/2013
		// Modified   : 04/18/2013
		// Procedure  : Form_QueryUnload
		// Parameters : Cancel As Integer, UnloadMode As Integer
		//
		// Returns    : None
		//
		// Notes      : Checks to see if proces is running.  If it is ask user to close.
		//
		// ====================================================================================

		private void Form_FormClosing(Object eventSender, FormClosingEventArgs eventArgs)
		{
			int Cancel = (eventArgs.Cancel) ? 1 : 0;
			int UnloadMode = (int) eventArgs.CloseReason;
			try
			{

				string strMsg = "";

				if (!cmdDownload.Enabled)
				{

					if ((UnloadMode != ((int) CloseReason.WindowsShutDown)) && (UnloadMode != ((int) CloseReason.TaskManagerClosing)))
					{

						AddItemToCanRegListBox("Download/Import In Process");
						AddItemToCanRegListBox("You Should Wait For This To Complete");

						strMsg = $"Download/Import In Process{Environment.NewLine}You Should Wait For This To Complete{Environment.NewLine}FORCE Close (Not Recommended)";
						if (MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{
							bStopProcess = true;
							MessageBox.Show("Process Has Been Stopped!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							AddItemToCanRegListBox("User Forced Unload");
						}
						else
						{
							AddItemToCanRegListBox("Cancelled Unload");
							Cancel = 1;
						}

					}
					else
					{
						bStopProcess = true;
						AddItemToCanRegListBox("Windows Forced Unload");
					} // If (UnloadMode <> vbAppWindows) And (UnloadMode <> vbAppTaskManager) Then

				} // If cmdDownload.Enabled = False Then
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}

		} // Form_QueryUnload

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/18/2013
		// Modified   : 04/18/2013
		// Procedure  : Form_Unload
		// Parameters : None
		//
		// Returns    : None
		//
		// Notes      : Stops the Process.
		//
		// ====================================================================================

		private void Form_Closed(Object eventSender, EventArgs eventArgs) => this.Close();
		 // Form_Unload

		private void frmDragDrop_DoubleClick(Object eventSender, EventArgs eventArgs) => cmdBrowse_Click(cmdBrowse, new EventArgs());


		//UPGRADE_WARNING: (2050) Frame Event frmDragDrop.OLEDragDrop was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void frmDragDrop_OLEDragDrop(DataObject Data, int Effect, int Button, int Shift, float X, float Y)
		{

			string strFromFileName = "";
			string strToFileName = "";
			string strToFolderName = "";

			try
			{

				lbl_Status.Text = "";
				//UPGRADE_ISSUE: (2064) DataObjectFiles property Files.Item was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				strFromFileName = null; //strFromFileName = Data.Files.Item(1); //gap-note This line must be checked during Blazor stabilization since looks like is using drag/drop mechanism. An equivalent must be defined.
				strToFolderName = txtDocumentDir.Text;

				if (System.IO.File.Exists(strFromFileName))
				{

					if (Directory.Exists(strToFolderName))
					{

						// Date Formatting
						// https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.90).aspx
						strToFileName = $"{strToFolderName}{StringsHelper.Format(DateTime.Now, "yyyyMMdd_hhmmss")}.zip";

						if (File.Exists(strToFolderName))
						{
							//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							File.Delete(strToFolderName);
						}

						File.Copy(strFromFileName, strToFileName, true);

						//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						File.Delete(strFromFileName);

						lbl_Status.Text = "Copy Completed";

						lblFileName_Click(lblFileName, new EventArgs());

					}
					else
					{
						MessageBox.Show($"Unable To Find Document Folder{Environment.NewLine}{strToFolderName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If gfso.FolderExists(strToFolderName) = True Then

				}
				else
				{
					MessageBox.Show($"Unable To Find File{Environment.NewLine}{strFromFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If gfso.FileExists(strFromFileName) = True Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("CanReg - frmDragDrop_OLEDragDrop_Error", excep.Message);
			}

		} // frmDragDrop_OLEDragDrop

		private void lblDocumentDir_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();

			string strFolderName = "";

			try
			{

				strFolderName = txtDocumentDir.Text;

				if (Directory.Exists(strFolderName))
				{

					//--------------------------------------------------
					// 11/05/2013 - By David D. Cruger
					// Force Folders Into Internet Explorer
					// The other browsers will not open a Folder

					modCommon.ShellOpenURLInBrowser("I", $"file://{strFolderName}");

				}
				else
				{
					MessageBox.Show($"Unable To Find Canadan Registry Document Directory {Environment.NewLine}{strFolderName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If fso.FolderExists(strMainDir) = True Then

				fso = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("lblDocumentDir_Click_Error: ", excep.Message);
			}

		} // lblDocumentDir_Click

		private void lblFileName_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();
			FileInfo fFile = null;
			string strDocDir = "";

			try
			{

				strDocDir = txtDocumentDir.Text;

				if (Directory.Exists(strDocDir))
				{

					txtFileName.Visible = false;

					foreach (FileInfo fFileIterator in (new DirectoryInfo(strDocDir)).GetFiles())
					{
						fFile = fFileIterator;
						txtFileName.Text = fFile.Name;
						//fFile
						fFile = default(FileInfo);
					}

					txtFileName.Visible = true;

				}
				else
				{
					MessageBox.Show($"Document Directory Can NOT Be Found{Environment.NewLine}{Environment.NewLine}{strDocDir}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If fso.FolderExists(strDocDir) = True Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("lblFileName_Click_Error: ", excep.Message);
			}

		} // lblFileName_Click

		private void lblWebsite_Click(Object eventSender, EventArgs eventArgs)
		{

			string strWebPage = "";

			try
			{

				strWebPage = txtWebsite.Text;

				modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strWebPage);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("lblWebsite_Click_Error: ", excep.Message);
			}

		} // lblWebsite_Click
	}
}