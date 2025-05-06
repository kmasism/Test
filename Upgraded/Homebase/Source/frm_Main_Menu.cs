using Microsoft.VisualBasic;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_Main_Menu
		: System.Windows.Forms.Form
	{


		// Development Language : Visual Basic 6.0 (SP5)
		//
		// Project Reference    : [x] Visual Basic For Applications
		//                        [x] Visual Basic runtime objects and procedures
		//                        [x] Virusal Basic objects and procedures
		//                        [x] OLE Automation
		//                        [x] Microsoft Scripting Runtime
		//                        [x] Microsoft Internet Controls
		//                        [x] Microsoft HTML Object Library
		// Added 05/30/2009       [x] PhotoTrue v2
		// Added 03/01/2018       [x] Chilkat ActiveX v9.5.0
		//
		// Project Components   : [x] Microsoft Internet controls
		//                        [x] Microsoft Internet Transfer Controls 6.0 (SP4)
		//
		// Project Late Binding : None
		//
		// 02/27/2020 - By David D. Cruger; This form is NOT used
		// 337 PDF Documents are treated like all other FAA PDF
		//
		// ====================================================================================

		private bool gbHTTPTransferCompleted = false;
		private string gbHTTPLocalFileName = "";
		private bool bWasLoggedOn = false;
		private bool bDoNotLoadArrays = false;
		public frm_Main_Menu()
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



		private void cmd_cancel_Click(Object eventSender, EventArgs eventArgs) => Environment.Exit(0);


		private void cmd_db_cancel_Click(Object eventSender, EventArgs eventArgs) => pnl_Database.Visible = false;



		private void cmd_login_Click(Object eventSender, EventArgs eventArgs)
		{

			string Latest_EXE_Path = "";
			string latest_exe_date = "";
			string current_exe_path = "";
			string current_exe_date = "";
			string Query = "";
			string M = "";
			frm_ActionList o_Local_CallBack_Form = null;
			string strUserId = "";
			string strUserPassword = "";
			string strUserName = "";

			string strServer = "";
			string strDatabase = "";
			string strDBUser = "";
			string strPassword = "";
			string strFileName = "";
			FileInfo fFile = null;
			string strMsg = "";

			try
			{

				modAdminCommon.gbl_bHomeClicked = false;
				modAdminCommon.gbl_Live_flag = true;
				modAdminCommon.gbl_Backup_flag = false;
				modGlobalVars.b_InCommercialDB = false;
				lbl_DatabaseType.Text = "LIVE";
				mdi_ResearchAssistant.DefInstance.MouseTimer.Enabled = false;


				// Open the appropriate database.
				M = ($"{string.Join(" ", Environment.GetCommandLineArgs().Skip(1).ToArray())}").Trim();


				switch(M)
				{
					case "B" : 
						txt_ip_address.Text = "tcp:10.10.254.56";  // VM-SQL02 
						txt_database_name.Text = "jetnet_ra_backup"; 
						txt_db_password.Text = "moejive"; 
						 
						break;
					case "D" : 
						txt_ip_address.Text = "tcp:128.1.18.24"; 
						txt_database_name.Text = "jetnet_ra_test"; 
						txt_db_password.Text = "moejive"; 
						 
						break;
					case "E" : 
						txt_ip_address.Text = "tcp:172.30.5.58";  // JETSQLHA 
						txt_database_name.Text = "jetnet_ra"; 
						txt_db_password.Text = "h\\SOGP$Uj9ya"; 
						 
						break;
					case "J" : case "T" : 
						txt_ip_address.Text = "tcp:10.10.254.56";  // VM-SQL02 
						txt_database_name.Text = "jetnet_ra_test"; 
						txt_db_password.Text = "moejive"; 
						 
						break;
					case "L" : 
						txt_ip_address.Text = "localhost"; 
						txt_database_name.Text = "jetnet_ra"; 
						txt_db_password.Text = "moejive"; 
						 
						break;
				} // Case M


				strServer = ($"{txt_ip_address.Text} ").Trim();
				strServer = StringsHelper.Replace(strServer, "tcp:", "", 1, -1, CompareMethod.Binary);
				strServer = StringsHelper.Replace(strServer, ",1433", "", 1, -1, CompareMethod.Binary);

				strDatabase = ($"{txt_database_name.Text} ").Trim().ToLower();

				strDBUser = ($"{txt_db_login.Text} ").Trim();
				strPassword = ($"{txt_db_password.Text} ").Trim();

				strUserId = ($"{txt_login_ID.Text} ").Trim();
				strUserPassword = ($"{txt_login_password.Text} ").Trim();


				// "JETNET-VM-SQL07"

				switch(strServer)
				{
					case "JETNET-VM-SQL07" :  // NEW SQL2019 SERVER FOR TESTING 
						lbl_DatabaseType.Text = "LIVE NEW SERVER (TEST)"; 
						 
						break;
					case "10.10.254.54" :  // VM-SQL01 
						 
						 
						switch(strDatabase)
						{
							case "jetnet_ra" : 
								modAdminCommon.gbl_Live_flag = true; 
								lbl_DatabaseType.Text = "LIVE SYSTEM"; 

								 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text = "VM-SQL01 Live System"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Visible = true; 
								 
								break;
							case "jetnet_ra_test" : 
								 
								strServer = "10.10.254.56";  // VM-SQL02 
								txt_ip_address.Text = $"tcp:{strServer},1433"; 
								modAdminCommon.gbl_Live_flag = false; 
								modAdminCommon.gbl_Backup_flag = false; 
								lbl_DatabaseType.Text = "VM-SQL02 TEST"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text = "VM-SQL02 Test"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Visible = true; 
								mdi_ResearchAssistant.DefInstance.lbl_test_omg.Visible = true; 
								 
								break;
						}  // strDatabase 
						 
						break;
					case "10.10.254.56" :  // VM-SQL02 
						 
						 
						switch(strDatabase)
						{
							case "jetnet_ra" : 
								 
								strServer = "10.10.254.54"; 
								txt_ip_address.Text = $"tcp:{strServer},1433"; 
								modAdminCommon.gbl_Live_flag = true; 
								lbl_DatabaseType.Text = "LIVE SYSTEM"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text = "VM-SQL01 Live System"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Visible = true; 
								 
								break;
							case "jetnet_ra_test" : 
								modAdminCommon.gbl_Live_flag = false; 
								modAdminCommon.gbl_Backup_flag = false; 
								lbl_DatabaseType.Text = "VM-SQL02 TEST"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text = "VM-SQL02 Test"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Visible = true; 
								 
								mdi_ResearchAssistant.DefInstance.lbl_test_omg.Visible = true; 

								 
								break;
							case "jetnet_ra_backup" : 
								modAdminCommon.gbl_Live_flag = false; 
								modAdminCommon.gbl_Backup_flag = true; 
								lbl_DatabaseType.Text = "VM-SQL02 BACKUP"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text = "VM-SQL02 Backup"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Visible = true; 
								 
								break;
						}  // strDatabase 


						 
						break;
					case "128.1.18.24" :  // TECHPC24 
						 
						 
						switch(strDatabase)
						{
							case "jetnet_ra_test" : 
								modAdminCommon.gbl_Live_flag = false; 
								modAdminCommon.gbl_Backup_flag = false; 
								lbl_DatabaseType.Text = "TECHPC24 TEST"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text = "TECHPC24 Test"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Visible = true; 
								 
								break;
							case "jetnet_ra_backup" : 
								modAdminCommon.gbl_Live_flag = false; 
								modAdminCommon.gbl_Backup_flag = true; 
								lbl_DatabaseType.Text = "TECHPC24 BACKUP"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text = "TECHPC24 Backup"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Visible = true; 
								 
								break;
						}  // strDatabase 
						 
						break;
					case "172.30.5.39" : case "172.30.5.42" : case "172.30.5.58" :  // MAPolce/Evolution - JETSQL1/JETSQL2 and JETSQLHA 
						 
						 
						switch(strDatabase)
						{
							case "jetnet_ra" : 
								modAdminCommon.gbl_Live_flag = false; 
								modAdminCommon.gbl_Backup_flag = false; 
								lbl_DatabaseType.Text = "EVOLUTION LIVE"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text = "Evolution Live"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Visible = true; 
								 
								break;
							case "jetnet_ra_test" : 
								modAdminCommon.gbl_Live_flag = false; 
								modAdminCommon.gbl_Backup_flag = false; 
								lbl_DatabaseType.Text = "EVOLUTION TEST"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text = "Evolution Test"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Visible = true; 
								 
								break;
							case "jetnet_ra_backup" : 
								modAdminCommon.gbl_Live_flag = false; 
								modAdminCommon.gbl_Backup_flag = true; 
								lbl_DatabaseType.Text = "EVOLUTION BACKUP"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text = "Evolution Backup"; 
								mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Visible = true; 
								 
								break;
						}  // strDatabase 
						 
						break;
					case "localhost" : 
						 
						modAdminCommon.gbl_Live_flag = false; 
						modAdminCommon.gbl_Backup_flag = false; 
						lbl_DatabaseType.Text = "LOCAL TESTING ONLY"; 
						mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text = "Local Host"; 
						mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Visible = true; 
						 
						break;
				} // Select Case strServer

				lblServer.Text = strServer;

				modAdminCommon.Num_Embedded = 0; //aey 3/28/05

				if (modAdminCommon.Open_Database(strDatabase, strServer, strPassword))
				{

					if (Valid_User(strUserId, strUserPassword))
					{

						mdi_ResearchAssistant.DefInstance.Text = $"Welcome {Convert.ToString(modAdminCommon.snp_User["user_first_name"]).Trim()}";
						lbl_Welcome.Text = $"Welcome {Convert.ToString(modAdminCommon.snp_User["user_first_name"]).Trim()}";
						lbl_Welcome.Visible = true;

						// set field on main menu so we know whether he is an evolution user or not
						// rtw - 12/3/2019
						if (modAdminCommon.gbl_Evo_Email_Address != " ")
						{
							lbl_Email_Address.Text = $"Email: {modAdminCommon.gbl_Evo_Email_Address}";
						}
						else
						{
							lbl_Email_Address.Text = " ";
						}

						// Retrieve the Web Address (gbl_WebSite) and File Server Address (gbl_Fileserver)
						modAdminCommon.Get_Application_Configuration();

						// 03/06/2008 - By David D. Cruger
						mnuInstall.Enabled = true;
						mnuNewRelease.Available = true;
						mnuTomorrow.Available = true;
						mnuToolsEnterHoursWorked.Enabled = true;

						this.Cursor = Cursors.WaitCursor;

						if (Strings.Len(modAdminCommon.gbl_Fileserver.Trim()) > 0)
						{


							try
							{
								strFileName = $"{modAdminCommon.gbl_Fileserver}\\JETNET_Setup.exe";
							}
							catch
							{
							}
							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => File.Exists(strFileName)))
							{
								try
								{

									current_exe_path = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\JetnetHomebase.exe";
								}
								catch
								{
								}

								if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => File.Exists(current_exe_path)))
								{
									try
									{
										current_exe_date = (new FileInfo(current_exe_path)).LastWriteTime.AddMinutes(2).ToString();
									}
									catch
									{
									}
								}
								else
								{
									try
									{
										current_exe_date = DateTime.Now.ToString();
									}
									catch
									{
									}
								}
								ErrorHandlingHelper.ResumeNext(

									() => {Latest_EXE_Path = $"{modAdminCommon.gbl_Fileserver}\\JETNET_Setup.exe";}, 
									() => {latest_exe_date = (new FileInfo(Latest_EXE_Path)).LastWriteTime.ToString();});

								if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => latest_exe_date.Trim() != ""))
								{

									if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => (DateTime.Parse(latest_exe_date) > DateTime.Parse(current_exe_date)) && (Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().ToLower() != "mvit")))
									{
										ErrorHandlingHelper.ResumeNext(

											() => {M = $"There is a more recent version of the 'JetnetHomebase.exe' on the server.{"\r"}{"\r"}";}, 
											() => {M = $"{M}Do you wish to install the more recent version at this time?";});

										if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => MessageBox.Show(M, "Version Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
										{
											DbCommand TempCommand = null;
											ErrorHandlingHelper.ResumeNext(

												() => {Query = "UPDATE [User] SET user_newest_software = 'Y' ";}, 
												() => {Query = $"{Query}WHERE user_id = '{Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim()}'";}, 
												() => {TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();}, 
												() => {UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);}, 
												() => {TempCommand.CommandText = Query;}, 
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
												() => {TempCommand.CommandType = CommandType.Text;}, // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
												() => {UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);}, 
												() => {TempCommand.ExecuteNonQuery();}, 

													//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
												() => {Process.Start(Latest_EXE_Path);}, 
												() => {Environment.Exit(0);});

										} // If MsgBox(M, vbApplicationModal + vbQuestion + vbYesNo, "Version Control") = vbYes Then

									} // If (CDate(latest_exe_date) > CDate(current_exe_date)) And (LCase$(Trim$(snp_User("user_id").Value)) <> "mvit") Then

								} // If Trim$(CStr(latest_exe_date)) <> "" Then

							} // If gfso.FileExists(strFileName) = True Then

						} // If Len(Trim(gbl_Fileserver)) > 0 Then

						// Capture today's date for use throughout the project.
						modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();

						// TURN ON THE NTSB DOWNLOAD MENU FOR THOSE AUTHORIZED
						mnutoolsNTSBDownload.Enabled = Convert.ToString(modAdminCommon.snp_User["user_process_ntsb_reports_flag"]).Trim().ToUpper() == "Y";

						// TURN ON THE FAA 337 DOWNLOAD MENU FOR THOSE AUTHORIZED
						mnuTools337.Enabled = txt_login_ID.Text.Trim().ToLower() == "lr" || txt_login_ID.Text.Trim().ToLower() == "lf" || txt_login_ID.Text.Trim().ToLower() == "mvit";

						// 09/29/2020 - By David D. Cruger
						// If User Is Technical or Administrator Turn On Send All EMail Queue - HomebaseEMail
						mnuSendEMailQueueHomebaseEMail.Available = false;
						mnuSendEMailQueueHomebaseEMail.Enabled = false;
						if (($"{Convert.ToString(modAdminCommon.snp_User["user_type"])} ").Trim() == "Administrator" || ($"{Convert.ToString(modAdminCommon.snp_User["user_type"])} ").Trim() == "Technical")
						{
							mnuSendEMailQueueHomebaseEMail.Available = true;
							mnuSendEMailQueueHomebaseEMail.Enabled = true;
						}

						// LOAD NEW ARRAYS FOR COMMONLY USED RECORDSETS

						if (!bDoNotLoadArrays)
						{

							modGlobalVars.bAccountRep_IsLoaded = modFillCommonArrays.Fill_AccountRep_Array();
							modGlobalVars.bPhoneType_IsLoaded = modFillCommonArrays.Fill_PhoneType_Array();
							modGlobalVars.bTimeZone_IsLoaded = modFillCommonArrays.Fill_TimeZone_Array();
							modGlobalVars.bCountry_IsLoaded = modFillCommonArrays.Fill_Country_Array();
							modGlobalVars.bState_IsLoaded = modFillCommonArrays.Fill_State_Array();
							modGlobalVars.bAccountType_IsLoaded = modFillCommonArrays.Fill_AccountType_Array();
							modGlobalVars.bAgencyType_IsLoaded = modFillCommonArrays.Fill_AgencyType_Array();
							modGlobalVars.bBusinessType_IsLoaded = modFillCommonArrays.Fill_BusinessType_Array();
							modGlobalVars.bContactType_IsLoaded = modFillCommonArrays.Fill_ContactType_Array();
							modGlobalVars.bLanguage_IsLoaded = modFillCommonArrays.Fill_Language_Array();
							modGlobalVars.bContactSirname_IsLoaded = modFillCommonArrays.Fill_ContactSurname_Array();
							modGlobalVars.bContactSuffix_IsLoaded = modFillCommonArrays.Fill_ContactSuffix_Array();
							modGlobalVars.bTitleGroup_IsLoaded = modFillCommonArrays.Fill_TitleGroup_Array();
							modGlobalVars.bCompanyProduct_IsLoaded = modFillCommonArrays.Fill_CompanyProduct_Array();
							modGlobalVars.bPurchaseQuestion_IsLoaded = modFillCommonArrays.Fill_Purchase_Question_Array();
							modGlobalVars.bWantedModel_IsLoaded = modFillCommonArrays.Fill_WantedModel_Array(false);
							modGlobalVars.bServicesUsed_IsLoaded = modFillCommonArrays.Fill_Services_Used(false);
							// RTW - ADDED ON 4/26/2011
							modGlobalVars.bMailLists_IsLoaded = modFillCommonArrays.Fill_Mail_Lists_Array();
							modGlobalVars.bCurrency_IsLoaded = modFillCommonArrays.Fill_Currency_Type_Array();
							modGlobalVars.bEngine1_IsLoaded = modFillCommonArrays.Fill_Engine_Management_CBO_Array();
							modGlobalVars.bAirframeMaintProg_IsLoaded = modFillCommonArrays.Fill_Airframe_Maintenance_Program_CBO_Array();
							modGlobalVars.bAirframeMaintProgHistory_IsLoaded = modFillCommonArrays.Fill_Airframe_Maintenance_Program_CBO_Array_History();
							modGlobalVars.bAirframeMaintTrackProg_IsLoaded = modFillCommonArrays.Fill_Airframe_Tracking_CBO_Array();

							// RTW - ADDED THESE 2 AS ARRAYS ON 9/17/2010
							modGlobalVars.bContactTitle_IsLoaded = modFillCommonArrays.Fill_Contact_Title_Array();
							modGlobalVars.bContinent_IsLoaded = modFillCommonArrays.Fill_Continent_Array();

							// moved from slightly below next if block - msw - 9/20/20
							modAdminCommon.gbl_Account_ID = Convert.ToString(modAdminCommon.snp_User["user_default_account_id"]).Trim();

							if (!modGlobalVars.bCallShowAndLoadOnlyOnce)
							{
								modGlobalVars.bCallShowAndLoadOnlyOnce = LoadCompanyFindCollection();
								modCommon.Hide_Form("frm_UserAccounts");
								modCommon.Hide_Form("frm_Find_Company");
							}



							if (modAdminCommon.gbl_User_ID.Trim() != modGlobalVars.cEmptyString)
							{
								modAdminCommon.ClearAllLocksForCurrentUser(modAdminCommon.gbl_User_ID);
							}

							Display_Menu_Labels();

							// 07/12/2011 - By David D. Cruger
							// Record Event For User Login
							modAdminCommon.ReturnUserIdAndName(ref strUserId, ref strUserName);
							modAdminCommon.gbl_User_Name = strUserName;

							modAdminCommon.Record_Event("Login", $"User {strUserName} ({strUserId.ToUpper()}) - Has Logged In", 0, 0, 0, false);

							strMsg = $"Login - User: {strUserName} ({strUserId.ToUpper()}) - PCName: {modAdminCommon.ReturnUserName()} - Server: {txt_ip_address.Text} - Database: {txt_database_name.Text} - Database Type: {mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text}";
							modCommon.AddItemToLogFile(strMsg);

							// We now have a new field in the user table to tell us
							// if they should automatically jump to their callback list
							if (Convert.ToString(modAdminCommon.snp_User["user_auto_callback"]).Trim().ToUpper() == "Y")
							{
								modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Callbacks...", Color.Blue);

								modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();
								o_Local_CallBack_Form = frm_ActionList.CreateInstance();
								o_Local_CallBack_Form.StartForm = modCommon.pubf_DecodeStartForm(modGlobalVars.gcCALLBACKS);
								o_Local_CallBack_Form.Show();
								bWasLoggedOn = true;

							}

							//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//VB.Global.Load(frm_UserHistory.DefInstance);
							mnuShowUserHistory.Enabled = true;

							bWasLoggedOn = true;

							modCommon.Clear_Monitor_Cursor_Movement();
							mdi_ResearchAssistant.DefInstance.MouseTimer.Enabled = true;

							modCommon.Set_JETNET_API_Record();

							if (txt_login_ID.Text.Trim().ToLower() == "mvit" || txt_login_ID.Text.Trim().ToLower() == "dcr")
							{
								mnuJunk.Available = true;
								mnuJunk1.Available = true;
								txt_database_name.Enabled = true;
							}
							else
							{
								mnuJunk.Available = false;
								mnuJunk1.Available = false;
							}

							if (Convert.ToString(modAdminCommon.snp_User["user_auto_callback"]).Trim().ToUpper() != "Y")
							{
								this.Activate();
								cmd_Logout.Focus();
							}

						} // If bDoNotLoadArrays = False Then

					}
					else
					{
						Clear_Menu_Labels();
					} // If Valid_User(strUserId, strUserPassword) Then

				}
				else
				{
					MessageBox.Show($"Can not find database, check the spelling. Please try again. ({txt_login_ID.Text.Trim()})", "Homebase : Database Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					throw new Exception();
				} // If Open_Database(strDatabase, strServer, strPassword) Then

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmdLogin_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_main_menu(Logon)");
				// changed from end function to end sub - MSW 3/18/12 - it is a sub not a funciton
			}

		}

		private void cmd_Logout_Click(Object eventSender, EventArgs eventArgs)
		{
			modAdminCommon.gbl_bHomeClicked = true;
			Form_Closed(this, new CancelEventArgs());
			Environment.Exit(0);
		}

		public void Cmd_Prospect_Click(Object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_WebReport.DefInstance);
			frm_WebReport.DefInstance.WhichReport = "Prospect Manager";
			frm_WebReport.DefInstance.Show();

		}

		private void cmd_Set_JETNET_Click(Object eventSender, EventArgs eventArgs)
		{

			txt_ip_address.Text = "tcp:10.10.254.54"; // VM-SQL01
			txt_database_name.Text = "jetnet_ra";

			txt_db_login.Text = "sa";
			txt_db_password.Text = "moejive";

			opt_Server.Checked = true;

		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				string Query = "";
				string M = "";
				Form Frm = null;

				// used to keep the focus to the proper form
				modGlobalVars.bKeepAircraftFocus = false;
				modGlobalVars.bKeepCompanyFocus = false;
				modGlobalVars.bKeepTransactionFocus = false;

				modGlobalVars.RefreshACFromJournal = false;

				modAdminCommon.gbl_Form = frm_Main_Menu.DefInstance;

				if (modAdminCommon.gbl_User_ID.Trim() == modGlobalVars.cEmptyString)
				{

					pnl_Database.Visible = false;
					modAdminCommon.gbl_FormLoop = 0;
					lbl_Message.Text = "";
					txt_database_name.Text = "jetnet_ra";

					txt_db_login.Text = "sa";
					txt_db_password.Text = "moejive";

					opt_Server.Checked = false;

				}
				else
				{

					modCommon.Close_All_Midi_Open_Forms();

					modAdminCommon.Num_Embedded = 0;

					foreach (Form FrmIterator in Application.OpenForms)
					{
						Frm = FrmIterator;

						if (Frm.Name == "frm_WebCrawl")
						{
							//UPGRADE_WARNING: (2065) Form method frm_WebCrawl.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							frm_WebCrawl.DefInstance.BringToFront();
							break;
						}
						else if (Frm.Name == "frm_NTSB")
						{
							//UPGRADE_WARNING: (2065) Form method frm_NTSB_New.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							frm_NTSB_New.DefInstance.BringToFront();
							break;
						}

						//Frm
						Frm = default(Form);
					}

				}

			}
		}


		private void Form_Initialize()
		{

			modGlobalVars.bCallShowAndLoadOnlyOnce = false;

			modGlobalVars.find_frm_collection = new System.Collections.Generic.List<frm_Find_Company>();//gap-note Type changed to List of frm_Find_Company
			modGlobalVars.new_frm_CompanyAdd = frm_CompanyAdd.CreateInstance();
			modGlobalVars.new_frm_Company = frm_Company.CreateInstance();

			modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcMAINPAGE);

			modGlobalVars.bPhoneType_IsLoaded = false;
			modGlobalVars.bTimeZone_IsLoaded = false;
			modGlobalVars.bState_IsLoaded = false;
			modGlobalVars.bCountry_IsLoaded = false;
			modGlobalVars.bAccountType_IsLoaded = false;
			modGlobalVars.bAgencyType_IsLoaded = false;
			modGlobalVars.bBusinessType_IsLoaded = false;
			modGlobalVars.bContactType_IsLoaded = false;
			modGlobalVars.bLanguage_IsLoaded = false;
			modGlobalVars.bAccountRep_IsLoaded = false;
			modGlobalVars.bServicesUsed_IsLoaded = false;
			modGlobalVars.bContactSirname_IsLoaded = false;
			modGlobalVars.bContactSuffix_IsLoaded = false;
			modGlobalVars.bTitleGroup_IsLoaded = false;
			modGlobalVars.bCompanyProduct_IsLoaded = false;
			modGlobalVars.bPurchaseQuestion_IsLoaded = false;
			modGlobalVars.bWantedModel_IsLoaded = false;
			modGlobalVars.bContactTitle_IsLoaded = false;
			modGlobalVars.bMailLists_IsLoaded = false;
			modAdminCommon.gbl_bHomeClicked = false;

		}

		private void Form_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				//MsgBox KeyAscii
				modAdminCommon.gbl_bHomeClicked = false;


				switch(KeyAscii)
				{
					case 2 :  // Ctrl-B - Backup 
						 
						txt_ip_address.Text = "10.10.254.56";  // VM-SQL02 
						txt_database_name.Text = "jetnet_ra_backup"; 
						txt_db_password.Text = "moejive"; 
						 
						txt_login_ID.Text = "mvit"; 
						txt_login_password.Text = "becareful"; 
						 
						cmd_login_Click(cmd_login, new EventArgs()); 
						 
						break;
					case 7 :  //-- control G - logs you into new system - MSW - 3/24/21 
						 
						txt_ip_address.Text = "JETNET-VM-SQL07"; 
						txt_database_name.Text = "jetnet_ra_test"; 
						txt_db_password.Text = "moejive"; 
						 
						txt_login_ID.Text = "mvit"; 
						txt_login_password.Text = "becareful"; 
						 
						cmd_login_Click(cmd_login, new EventArgs()); 
						 
						break;
					case 4 :  // Ctrl-D - TECHPC24 / David 's SQL 
						 
						txt_ip_address.Text = "128.1.18.24"; 
						txt_database_name.Text = "jetnet_ra_test"; 
						txt_db_password.Text = "moejive"; 
						 
						txt_login_ID.Text = "dcr"; 
						txt_login_password.Text = "453590"; 
						 
						cmd_login_Click(cmd_login, new EventArgs()); 
						 
						break;
					case 5 :  // Ctrl-E - Evolution 
						 
						txt_ip_address.Text = "172.30.5.58";  // JETSQLHA 
						txt_database_name.Text = "jetnet_ra"; 
						txt_db_password.Text = "h\\SOGP$Uj9ya"; 
						 
						txt_login_ID.Text = "mvit"; 
						txt_login_password.Text = "becareful"; 
						 
						cmd_login_Click(cmd_login, new EventArgs()); 
						 
						break;
					case 10 :  // Ctrl-J - Test 
						 
						txt_ip_address.Text = "10.10.254.56";  // VM-SQL02 
						txt_database_name.Text = "jetnet_ra_test"; 
						txt_db_password.Text = "moejive"; 
						 
						txt_login_ID.Text = "mvit"; 
						txt_login_password.Text = "becareful"; 
						 
						cmd_login_Click(cmd_login, new EventArgs()); 
						 
						break;
					case 12 :  // - Ctrl-L - Local 
						 
						txt_ip_address.Text = "localhost"; 
						txt_database_name.Text = "jetnet_ra"; 
						txt_db_password.Text = "moejive"; 
						 
						txt_login_ID.Text = "mvit"; 
						txt_login_password.Text = "becareful"; 
						 
						cmd_login_Click(cmd_login, new EventArgs()); 

						 
						break;
					case 20 :  // - Ctrl-T - Test/Get Tomorrows Release 
						 
						txt_ip_address.Text = "10.10.254.56";  // VM-SQL02 
						txt_database_name.Text = "jetnet_ra_test"; 
						txt_db_password.Text = "moejive"; 
						 
						txt_login_ID.Text = "mvit"; 
						txt_login_password.Text = "becareful"; 
						 
						bDoNotLoadArrays = true; 
						 
						cmd_login_Click(cmd_login, new EventArgs()); 
						 
						mnuTomorrow_Click(mnuTomorrow, new EventArgs()); 

						 
						break;
				} // Select Case KeyAscii
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

		} // Form_KeyPress

		private void Form_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				//MsgBox "FORM - KEYUP" & CStr(KeyCode) & "-" & CStr(Shift), vbOKOnly

				if (Shift == 0)
				{


					switch(KeyCode)
					{
						case 112 :  // F1 
							 
							if (img_Callbacks.Visible)
							{
								img_Callbacks_Click(img_Callbacks, new EventArgs());
							}  // If img_Callbacks.Visible = True Then 
							 
							break;
						case 113 :  // F2 
							 
							if (img_Aircraft.Visible)
							{
								img_Aircraft_Click(img_Aircraft, new EventArgs());
							}  // If img_Aircraft.Visible = True Then 
							 
							break;
						case 114 :  // F3 
							 
							if (img_Aircraft_Model.Visible)
							{
								img_Aircraft_Model_Click(img_Aircraft_Model, new EventArgs());
							}  // If img_Aircraft_Model.Visible = True Then 
							 
							break;
						case 115 :  // F4 
							 
							if (img_Company.Visible)
							{
								ShowAndLoadCompanyFind();
							}  // If img_Company.Visible = True Then 
							 
							break;
						case 116 :  // F5 
							 
							if (img_Accounts.Visible)
							{
								img_Accounts_Click(img_Accounts, new EventArgs());
							}  // If img_Accounts.Visible = True Then 
							 
							break;
						case 117 :  // F6 
							 
							if (img_Administration.Visible)
							{
								img_Administration_Click(img_Administration, new EventArgs());
							}  // If img_Administration.Visible = True Then 

							 
							break;
					}
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{


			bDoNotLoadArrays = false;
			try
			{

				lblDate.Text = (new FileInfo($"{Path.GetDirectoryName(Application.ExecutablePath)}\\{Path.GetFileNameWithoutExtension(Application.ExecutablePath)}.exe")).LastWriteTime.ToString();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			}
			catch
			{
			}
			if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == 53))
			{
				ErrorHandlingHelper.ResumeNext(
					() => {Information.Err().Clear();}, 
					() => {lblDate.Text = DateTime.Now.ToString();});
			}
			ErrorHandlingHelper.ResumeNext(

				() => {lblVersion.Text = $"{FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileMajorPart.ToString()}.{FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileMinorPart.ToString()}.{FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FilePrivatePart.ToString()}";}, 
				() => {lblServer.Text = "Server";}, 

				() => {lbl_DatabaseType.Text = "";}, 
				() => {modAdminCommon.gbl_ConfirmDays = 180;}, 
					// gbl_ConfirmDays = 90 ' changed MSW - 5/27/15

				() => {bWasLoggedOn = false;}, 
				() => {modGlobalVars.b_InCommercialDB = false;}, 

				() => {mnuToolsEnterHoursWorked.Enabled = false;}, 
				() => {mnuSendEMailQueueHomebaseEMail.Available = false;},  // 09/29/2020 - By David D. Cruger Added
				() => {mnuSendEMailQueueHomebaseEMail.Enabled = false;});

			if (modAdminCommon.gbl_User_ID != "")
			{
				try
				{
					Display_Menu_Labels();
				}
				catch
				{
				}

			}
			else
			{
				try
				{
					Clear_Menu_Labels();
				}
				catch
				{
				}
			}
			try
			{


				// 06/22/2006 - By David D. Cruger
				// Creates Async Connection Array
				modAsync.InitializeAsyncConnectionArray();
			}
			catch
			{
			}

		} // Form_Load

		private void Form_Terminate()
		{

			// 02/23/2012 - By David D. Cruger
			// Make Sure All Connections Are Closed

			if (modAdminCommon.LOCAL_ADO_DB != null)
			{
				if (modAdminCommon.LOCAL_ADO_DB.State == ConnectionState.Open)
				{
					UpgradeHelpers.DB.TransactionManager.DeEnlist(modAdminCommon.LOCAL_ADO_DB);
					modAdminCommon.LOCAL_ADO_DB.Close();
				}
				modAdminCommon.LOCAL_ADO_DB = null;
			}

			if (modAdminCommon.ADODB_Trans_conn != null)
			{
				if (modAdminCommon.ADODB_Trans_conn.State == ConnectionState.Open)
				{
					UpgradeHelpers.DB.TransactionManager.DeEnlist(modAdminCommon.ADODB_Trans_conn);
					modAdminCommon.ADODB_Trans_conn.Close();
				}
				modAdminCommon.ADODB_Trans_conn = null;
			}

			if (modAdminCommon.CLIENT_ADO_DB != null)
			{
				if (modAdminCommon.CLIENT_ADO_DB.State == ConnectionState.Open)
				{
					UpgradeHelpers.DB.TransactionManager.DeEnlist(modAdminCommon.CLIENT_ADO_DB);
					modAdminCommon.CLIENT_ADO_DB.Close();
				}
				modAdminCommon.CLIENT_ADO_DB = null;
			}

			modAdminCommon.gbl_bHomeClicked = true;

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			string strUserId = "";
			string strUserName = "";
			string strUpdate1 = "";
			string strMsg = "";


			if (bWasLoggedOn)
			{

				modAdminCommon.gbl_bHomeClicked = true;

				mdi_ResearchAssistant.DefInstance.MouseTimer.Enabled = false;

				//-------------------------------------
				// Clear All Local For Current User

				modAdminCommon.ClearAllLocksForCurrentUser(modAdminCommon.gbl_User_ID);

				strUpdate1 = $"UPDATE [User] SET user_logged_in = 'N' WHERE user_id = '{modAdminCommon.gbl_User_ID}'";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strUpdate1;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				modAdminCommon.ReturnUserIdAndName(ref strUserId, ref strUserName);
				modAdminCommon.Record_Event("Logout", $"User {strUserName} ({strUserId.ToUpper()}) - Has Logged Out", 0, 0, 0, false);


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Cleaning Up All Async Connections", Color.Blue);
				modAsync.CloseAllAsyncConnections();


				modCommon.Unload_All_Forms_In_Collection();

				strMsg = $"Logout - User: {strUserName} ({strUserId.ToUpper()}) - PCName: {modAdminCommon.ReturnUserName()} - Server: {txt_ip_address.Text} - Database: {txt_database_name.Text} - Database Type: {mdi_ResearchAssistant.DefInstance.lbl_WhichDatabase.Text}";
				modCommon.AddItemToLogFile(strMsg);

			} // If bWasLoggedOn = True Then

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

			modGlobalVars.find_frm_collection = null;
			modGlobalVars.new_frm_CompanyAdd = null;
			modGlobalVars.new_frm_Company = null;

			Environment.Exit(0);

		} // Form_Unload

		private void img_Administration_Click(Object eventSender, EventArgs eventArgs)
		{

			double lAppId = 0;

			string APath = "";
			string Parm = "";

			lbl_Message.Text = "Loading Administration Form ...";
			lbl_Message.Refresh();

			modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Loading Administration Form...", Color.Blue);

			modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcADMIN);

			modAdminCommon.gbl_bHomeClicked = false;

			modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();

			// 2/29/2008 - By David D. Cruger
			// Changed to Use a configuration flag
			if (Convert.ToString(modAdminCommon.snp_User["user_manage_accounts_flag"]).Trim().ToUpper() == "Y")
			{

				APath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\HomebaseAdmin.exe";
				if (File.Exists(APath))
				{

					Parm = $" USR={txt_login_ID.Text.Trim()}" +
					       $" USRPWD={txt_login_password.Text.Trim()}" +
					       $" DB={txt_database_name.Text.Trim()}" +
					       $" UID={txt_db_login.Text.Trim()}" +
					       $" PSW={txt_db_password.Text.Trim()}" +
					       $" IP={txt_ip_address.Text.Trim()}";
					//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
					ProcessStartInfo startInfo = new ProcessStartInfo($"{APath}{Parm}");
					startInfo.WindowStyle = ProcessWindowStyle.Normal;
					lAppId = Process.Start(startInfo).Id;
					lbl_Message.Text = "";

				}
				else
				{
					MessageBox.Show("Unable to Find Admin Program - HomebaseAdmin.exe", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If gfso.FileExists(APath) = True Then

			}
			else
			{
				lbl_Message.Text = "Not Authorized ...";
				lbl_Message.Refresh();
			} // If UCase(Trim(snp_User("user_manage_accounts_flag").Value)) = "Y" Then

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

		}

		private void img_Accounts_Click(Object eventSender, EventArgs eventArgs)
		{

			lbl_Message.Text = "Loading Account Management Form ...";
			lbl_Message.Refresh();

			modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Loading Account Management Form...", Color.Blue);
			Application.DoEvents();
			Application.DoEvents();
			modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcACCOUNT);

			modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();
			Application.DoEvents();
			Application.DoEvents();

			// 2/29/2008 - By David D. Cruger
			// Changed to Use a configuration flag
			if (($"{Convert.ToString(modAdminCommon.snp_User["user_manage_accounts_flag"])}").Trim().ToUpper() == "Y")
			{
				Application.DoEvents();
				this.Cursor = Cursors.WaitCursor;
				Application.DoEvents();
				Application.DoEvents();
				modAdminCommon.gbl_bHomeClicked = false; // added MSW - for some reason this was getting stuck 9/20
				Application.DoEvents();
				Application.DoEvents();
				frm_UserAccounts.DefInstance.Show();
				Application.DoEvents();
				Application.DoEvents();
				Application.DoEvents();
				lbl_Message.Text = "";
				this.Cursor = CursorHelper.CursorDefault;
			}
			else
			{
				lbl_Message.Text = "Not Authorized ...";
				lbl_Message.Refresh();
			}

		}

		private void img_Aircraft_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();

			lbl_Message.Text = "Loading Aircraft Search Form ...";
			lbl_Message.Refresh();

			modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Loading Aircraft Search Form...", Color.Blue);

			modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcAIRCRAFT);

			modAdminCommon.gbl_bHomeClicked = false;

			modAdminCommon.gbl_Aircraft_ID = 0;

			this.Cursor = Cursors.WaitCursor;
			frm_AircraftList.DefInstance.is_from_company = false;
			frm_AircraftList.DefInstance.Show();
			lbl_Message.Text = "";
			this.Cursor = CursorHelper.CursorDefault;

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

		}

		private void img_Aircraft_Model_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();

			lbl_Message.Text = "Loading Aircraft Model Form ...";
			lbl_Message.Refresh();

			modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Loading Aircraft Model Form...", Color.Blue);

			modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcMODEL);

			modAdminCommon.gbl_bHomeClicked = false;

			this.Cursor = Cursors.WaitCursor;
			frm_Aircraft_Model.DefInstance.Show();
			lbl_Message.Text = "";
			this.Cursor = CursorHelper.CursorDefault;

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

		}

		private void img_Callbacks_Click(Object eventSender, EventArgs eventArgs)
		{


			modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();

			lbl_Message.Text = "Loading Callback Form ...";
			lbl_Message.Refresh();

			modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Loading Callback Form...", Color.Blue);

			modAdminCommon.gbl_bHomeClicked = false;
			modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcCALLBACKS);

			frm_ActionList o_Local_CallBack_Form = frm_ActionList.CreateInstance();
			o_Local_CallBack_Form.StartForm = modGlobalVars.tStart_Form;

			this.Cursor = Cursors.WaitCursor;
			o_Local_CallBack_Form.Show();
			lbl_Message.Text = "";
			this.Cursor = CursorHelper.CursorDefault;

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

		}

		private void img_Company_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();

			lbl_Message.Text = "Loading Company Search Form ...";
			lbl_Message.Refresh();

			modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Loading Company Search Form...", Color.Blue);

			modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcCOMPANY);

			modAdminCommon.gbl_bHomeClicked = false;

			this.Cursor = Cursors.WaitCursor;
			ShowAndLoadCompanyFind();
			lbl_Message.Text = "";
			this.Cursor = CursorHelper.CursorDefault;

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

		}


		public void mnuActionItems_Click(Object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_WebReport.DefInstance);
			frm_WebReport.DefInstance.WhichReport = "Action Items";
			frm_WebReport.DefInstance.Show();

		}

		public void mnuCanRegistry_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();

			lbl_Message.Text = "Loading Canadian Registry Form ...";
			lbl_Message.Refresh();

			modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Loading Canadian Registry Form...", Color.Blue);

			modAdminCommon.gbl_bHomeClicked = false;

			modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcCANREG);

			// 04/17/2013 - By David D. Cruger

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_CanReg.DefInstance);
			modCommon.CenterFormOnHomebaseMainForm(frm_CanReg.DefInstance);
			frm_CanReg.DefInstance.Show();

			lbl_Message.Text = "";


			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

		}

		public void mnuFileDatabase_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;

			modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();

			pnl_Database.Visible = true;

		}

		public void mnuFileLogout_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;
			Form_Closed(this, new CancelEventArgs());
			Environment.Exit(0);

		}

		public void mnuHelpHomebase_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;

			if (modAdminCommon.gbl_User_ID.Trim() != "")
			{
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(frm_WebReport.DefInstance);
				frm_WebReport.DefInstance.WhichReport = "Main Help";
				frm_WebReport.DefInstance.Show();
			}
			else
			{
				MessageBox.Show("You must log in before clicking 'Help'", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		public void mnuHelpHomebaseRelease_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;
			if (modAdminCommon.gbl_User_ID.Trim() != "")
			{
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(frm_WebReport.DefInstance);
				frm_WebReport.DefInstance.WhichReport = "Homebase Release";
				frm_WebReport.DefInstance.Show();
			}
			else
			{
				MessageBox.Show("You must log in before clicking 'Help'", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		public void mnuhomebaselogin_Click(Object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_WebReport.DefInstance);
			frm_WebReport.DefInstance.WhichReport = "Homebase Login";
			frm_WebReport.DefInstance.Show();

		}

		public void mnuInstall_Click(Object eventSender, EventArgs eventArgs)
		{


			modAdminCommon.gbl_bHomeClicked = false;
			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = $"UPDATE [User] SET user_newest_software = 'Y' WHERE user_id = '{Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim()}'";
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			string Latest_EXE_Path = $"{modAdminCommon.gbl_Fileserver}\\JETNET_Setup.exe";
			//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
			Process.Start(Latest_EXE_Path);
			Environment.Exit(0);

		}

		public void mnuJunk_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;

			modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();

			frm_CompanyAdd new_company_add_form = frm_CompanyAdd.CreateInstance();

			new_company_add_form.Show();

		}

		public void mnuJunk1_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;

			modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();

			modGlobalVars.new_frm_Company.Reference_CompanyID = 9730; //1100 '
			modGlobalVars.new_frm_Company.Reference_CompanyJID = 0;

			modGlobalVars.new_frm_Company.Show();

		}

		public void mnuLoadJETNETiQSurveyResults_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;
			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_JETNETiQLoadSurveyResults.DefInstance);
			modCommon.CenterFormOnHomebaseMainForm(frm_JETNETiQLoadSurveyResults.DefInstance);
			frm_JETNETiQLoadSurveyResults.DefInstance.Show();

		} // mnuLoadJETNETiQSurveyResults_Click

		public void mnuMissingPrices_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;
			frm_Missing_Solds.DefInstance.Height = 440;
			frm_Missing_Solds.DefInstance.Show();

		}

		public void mnuNewRelease_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = "UPDATE [User] SET user_newest_software = 'N'";
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			MessageBox.Show("User Table Updated.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

		}

		public void mnuSalePrices_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;
			frm_Sale_Prices.DefInstance.is_remove = 0;
			frm_Sale_Prices.DefInstance.journ_remove = 0;
			frm_Sale_Prices.DefInstance.Show();

		}

		//-------------------------------------------------------
		// 09/29/2020 - By David D. Cruger - Added
		// Only for Administrator or Technical User Types
		//-------------------------------------------------------

		public void mnuSendEMailQueueHomebaseEMail_Click(Object eventSender, EventArgs eventArgs)
		{

			string strErrMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			if (MessageBox.Show("Manually Send Open EMail Queue - HomebaseEMail", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Sending Open EMail Queue - HomebaseEMail", Color.Blue);

				string tempRefParam = "Manually Sending Open EMail Queue - HomebaseEMail";
				modCommon.Start_Activity_Monitor_Message("HomebaseEMail", ref tempRefParam, ref dtStartDate, ref dtEndDate);

				modEmail.Send_All_EMail_In_Queue(ref strErrMsg, 0, true);

				if (strErrMsg != "")
				{
					string tempRefParam2 = $"Manually Sending Open EMail Queue - HomebaseEMail - Failed - {strErrMsg}";
					modCommon.End_Activity_Monitor_Message("HomebaseEMail", ref tempRefParam2, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);
					MessageBox.Show($"Sending EMail Queue Error {Environment.NewLine}{Environment.NewLine}{strErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					string tempRefParam3 = "Manually Sending Open EMail Queue - HomebaseEMail - Completed";
					modCommon.End_Activity_Monitor_Message("HomebaseEMail", ref tempRefParam3, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);
				}

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Sending Open EMail Queue - HomebaseEMail - Completed", Color.Blue);

			} // If MsgBox("Manually Send EMail Queue - HomebaseEMail", vbYesNo) = vbYes Then

		} // mnuSendEMailQueueHomebaseEMail_Click

		public void mnuShowUserHistory_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;
			if (mnuShowUserHistory.Text == "Show User History")
			{
				frm_UserHistory.DefInstance.Refresh_User_History_Grids("All");
				frm_UserHistory.DefInstance.TimerOn();
				mnuShowUserHistory.Text = "Hide User History";
				modCommon.CenterFormOnHomebaseMainForm(frm_UserHistory.DefInstance);
				frm_UserHistory.DefInstance.Show();
			}
			else
			{
				frm_UserHistory.DefInstance.TimerOff();
				mnuShowUserHistory.Text = "Show User History";
				frm_UserHistory.DefInstance.Hide();
			}

		} // mnuShowUserHistory

		public void mnuReLogin_Click(Object eventSender, EventArgs eventArgs)
		{

			mnuToolsEnterHoursWorked.Enabled = false;
			modAdminCommon.gbl_bHomeClicked = false;
			frm_UserHistory.DefInstance.TimerOff();

			modCommon.Unload_All_Open_Forms();

			//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			Form_Activated(this, new EventArgs());
			Clear_Menu_Labels();

			txt_login_ID.Text = "";
			txt_login_password.Text = "";

			txt_login_ID.Focus();


			modAdminCommon.CLIENT_ADO_DB = null;
			modAdminCommon.LOCAL_ADO_DB = null;
			try
			{

				mdi_ResearchAssistant.DefInstance.lbl_test_omg.Visible = false; // MSW  - 3/30/23 . make sure this clears
			}
			catch
			{
			}

		}

		public void mnuTomorrow_Click(Object eventSender, EventArgs eventArgs)
		{


			modAdminCommon.gbl_bHomeClicked = false;

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = $"UPDATE [User] SET user_newest_software = 'Y' WHERE user_id = '{Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim()}'";
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			string Latest_EXE_Path = $"{modAdminCommon.gbl_Fileserver}\\NextRelease\\JETNET_Setup.exe";

			//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
			Process.Start(Latest_EXE_Path);

			Environment.Exit(0);

		}


		public void mnuToolsEnterHoursWorked_Click(Object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_UserHoursWorked.DefInstance);
			modCommon.CenterFormOnHomebaseMainForm(frm_UserHoursWorked.DefInstance);
			frm_UserHoursWorked.DefInstance.ShowDialog(); // vbModeless

		}

		public void mnuToolsNewAvail_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;

			modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();

			modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcPUBS);

			frm_WebCrawl.DefInstance.Show();

		}

		public void mnutoolsNTSBDownload_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.gbl_bHomeClicked = false;

			modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();

			modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcNTSB);

			// 04/09/2013 - By David D. Cruger
			// Use The frm_NTSB_New Form

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_NTSB_New.DefInstance);

			modCommon.CenterFormOnHomebaseMainForm(frm_NTSB_New.DefInstance);

			frm_NTSB_New.DefInstance.Show();

		}

		private bool isInitializingComponent;
		private void OptDatabase_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				txt_login_password.Text = "";

				if (OptDatabase[1].Checked)
				{ //1/11/05 aey
					txt_database_name.Text = "jetnet_ra_commercial";
				}
				else
				{
					txt_database_name.Text = "jetnet_ra";
				}

			}
		}

		private void txt_login_ID_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (txt_login_ID.Text.ToLower() == "dcr" || txt_login_ID.Text.ToLower() == "mvit")
			{

				txt_login_password.Visible = true;
				lbl_login_password.Visible = true;
				txt_database_name.Enabled = true;

				if (txt_login_password.Visible)
				{
					txt_login_password.Focus();
				}

			}

		}

		private bool LoadCompanyFindCollection()
		{

			bool result = false;
			frm_Find_Company o_Local_Find_Company = null;


			try
			{

				for (int X = 0; X <= modGlobalVars.MAX_FIND_FORMS - 1; X++)
				{

					o_Local_Find_Company = frm_Find_Company.CreateInstance();

					switch(X)
					{
						case modGlobalVars.FIND_FORM_NEW : 
							// create empty find form 
							o_Local_Find_Company.EntryPoint = modGlobalVars.e_find_form_entry_points.geNoEntryPoint; 
							o_Local_Find_Company.SetFormCaptionAndKey(modGlobalVars.e_find_form_entry_points.geNoEntryPoint); 
							 
							break;
						case modGlobalVars.FIND_FORM_TX : 
							// create find form for transactions 
							o_Local_Find_Company.EntryPoint = modGlobalVars.e_find_form_entry_points.geAircraftChange; 
							o_Local_Find_Company.SetFormCaptionAndKey(modGlobalVars.e_find_form_entry_points.geAircraftChange); 
							 
							break;
						case modGlobalVars.FIND_FORM_DOCS : 
							// create find form for documents 
							o_Local_Find_Company.EntryPoint = modGlobalVars.e_find_form_entry_points.geAircraftDocument; 
							if (modAdminCommon.gbl_Account_ID.Trim() == "TECH")
							{ // added MSW -- 9/20/20
							}
							else
							{
								o_Local_Find_Company.SetFormCaptionAndKey(modGlobalVars.e_find_form_entry_points.geAircraftDocument);
							} 
							break;
						case modGlobalVars.FIND_FORM_AC : 
							// create find form for aircraft 
							o_Local_Find_Company.EntryPoint = modGlobalVars.e_find_form_entry_points.geAssociateToAircraft; 
							o_Local_Find_Company.SetFormCaptionAndKey(modGlobalVars.e_find_form_entry_points.geAssociateToAircraft); 
							 
							break;
						case modGlobalVars.FIND_FORM_CON : 
							// create find form for contact 
							o_Local_Find_Company.EntryPoint = modGlobalVars.e_find_form_entry_points.geAddCompanyRelation; 
							o_Local_Find_Company.SetFormCaptionAndKey(modGlobalVars.e_find_form_entry_points.geAddCompanyRelation); 
							 
							break;
						case modGlobalVars.FIND_FORM_MISC : 
							// create empty find form pre-load with geAccountCallback to make it unique 
							o_Local_Find_Company.EntryPoint = modGlobalVars.e_find_form_entry_points.geAccountCallback; 
							o_Local_Find_Company.SetFormCaptionAndKey(modGlobalVars.e_find_form_entry_points.geAccountCallback); 
							 
							break;
					}

					modGlobalVars.find_frm_collection.Add(o_Local_Find_Company);//gap-note The type was to set to frm_Find_Company. Check in runtime if it is correct

					o_Local_Find_Company.Hide();

					o_Local_Find_Company = null;

				}

				modCommon.DelaySeconds(1); // Make Sure All Forms Are Loaded


				return true;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"LoadCompanyFindCollection_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_main_menu(LoadFindFrms)");
			}
			return result;
		}

		private object ShowAndLoadCompanyFind()
		{

			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].Clear_Search_Criteria(true, true, true);
				//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].Show();
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes
				//UPGRADE_TODO: (1067) Member SetFocus is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].Focus();

			}

			return null;
		}

		// 02/07/2012 - By David D. Cruger
		// Completely Rewored this login process

		private bool Valid_User(string strUserId, string strUserPassword)
		{

			bool result = false;
			string strQuery = "";
			string strUpdate = "";
			bool HadPassword = false;
			bool bResults = false;
			string strAllowMultipleHomebase = "";

			try
			{

				bResults = false;

				// SET EVO USER VARIABLES TO BLANK
				modAdminCommon.gbl_Evo_Email_Address = "";
				modAdminCommon.gbl_Evo_Password = "";

				//----------------------------------------------
				// If User Recordset Is Already Open Close It

				if (modAdminCommon.snp_User != null)
				{
					if (modAdminCommon.snp_User.State == ConnectionState.Open)
					{
						modAdminCommon.snp_User.Close();
					}
					modAdminCommon.snp_User = null;
				}

				modAdminCommon.snp_User = new ADORecordSetHelper();

				strUserId = ($"{strUserId} ").Trim().ToLower();
				strUserPassword = ($"{strUserPassword} ").Trim();
				strAllowMultipleHomebase = "N";

				if (strUserId != modGlobalVars.cEmptyString)
				{

					strQuery = "SELECT TOP 1 * FROM [User] left outer join view_jetnet_customers with (NOLOCK) on sub_id in (777,1484) and user_email_address=contact_email_address ";
					strQuery = $"{strQuery}WHERE user_id = '{strUserId}'";

					modAdminCommon.snp_User.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!modAdminCommon.snp_User.BOF && !modAdminCommon.snp_User.EOF)
					{

						strAllowMultipleHomebase = ($"{Convert.ToString(modAdminCommon.snp_User["user_open_multiple_homebase"])} ").Trim().ToUpper();

						if (strUserPassword == ($"{Convert.ToString(modAdminCommon.snp_User["user_password"])} ").Trim().ToLower())
						{

							bResults = true;

							Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
							if (processes.Length > 1 && Process.GetCurrentProcess().StartTime != processes[0].StartTime)
							{

								if (strAllowMultipleHomebase == "Y")
								{
									if (($"{Convert.ToString(modAdminCommon.snp_User["user_logged_in"])} ").Trim().ToUpper() == "Y")
									{
										bResults = false;
										MessageBox.Show($"Homebase Is Already Running{Environment.NewLine}User Is Already Logged In To This Database", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									}
								}
								else
								{
									bResults = false;
									MessageBox.Show($"Homebase Is Already Running{Environment.NewLine}User Is Not Allowed To Open More Than One Homebase", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								}

							} // If App.PrevInstance = True Then

							if (bResults)
							{

								modAdminCommon.gbl_User_ID = strUserId;
								modAdminCommon.gbl_User_Admin = ($"{Convert.ToString(modAdminCommon.snp_User["user_manage_accounts_flag"])} ").Trim().ToUpper();
								modAdminCommon.gbl_User_Browser = ($"{Convert.ToString(modAdminCommon.snp_User["user_browser_type"])} ").Trim().ToUpper();
								// added MSW - 7/1/24
								modAdminCommon.gbl_User_Create_Sub = ($"{Convert.ToString(modAdminCommon.snp_User["user_create_subscription"])} ").Trim().ToUpper();

								if (($"{Convert.ToString(modAdminCommon.snp_User["contact_email_address"])} ").Trim() != "")
								{
									modAdminCommon.gbl_Evo_Email_Address = ($"{Convert.ToString(modAdminCommon.snp_User["contact_email_address"])} ").Trim();
									modAdminCommon.gbl_Evo_Password = ($"{Convert.ToString(modAdminCommon.snp_User["sublogin_password"])} ").Trim();
								}

								// FILL IN EVOLUTION LOGIN FIELDS IF FOUND IN RESULTS

								strUpdate = "UPDATE [User] SET user_logged_in = 'Y', ";
								strUpdate = $"{strUpdate}user_pcname = '{modAdminCommon.ReturnUserName().ToUpper()}',  user_homebase_version_nbr = '{lblVersion.Text}', ";
								strUpdate = $"{strUpdate}user_homebase_version_date = '{lblDate.Text}' ";
								strUpdate = $"{strUpdate}WHERE (user_id = '{modAdminCommon.gbl_User_ID}')";

								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = strUpdate;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();

							} // If bResults = True Then

						}
						else
						{
							MessageBox.Show("Invalid Password", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If strUserPassword = LCase(Trim(snp_User!user_password & " ")) Then

					}
					else
					{
						MessageBox.Show("Unable To Find User Id", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If (snp_User.BOF = False And snp_User.EOF = False) Then

					if (!bResults)
					{
						modAdminCommon.snp_User.Close();
						modAdminCommon.snp_User = null;
					}

				}
				else
				{
					MessageBox.Show("User Id Field Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If strUserId <> cEmptyString Then


				return bResults;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"valid_user_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_main_menu(user)");
			}
			return result;
		} // Valid_User

		private void Clear_Menu_Labels()
		{

			img_Accounts.Visible = false;
			lbl_login_message.Text = $"Welcome to Homebase.{Environment.NewLine}Please enter your login.";
			img_Aircraft_Model.Visible = false;
			img_Aircraft.Visible = false;
			img_Administration.Visible = false;
			img_Callbacks.Visible = false;
			img_Company.Visible = false;
			lbl_Message.Text = "";
			pnl_Login.Visible = true;
			pnl_Status.Visible = false;

		}

		private void Display_Menu_Labels()
		{

			img_Aircraft_Model.Visible = true;
			img_Aircraft.Visible = true;
			img_Callbacks.Visible = true;
			img_Company.Visible = true;
			pnl_Login.Visible = false;
			lbl_Message.Text = "";

			if (!(modAdminCommon.snp_User.EOF && modAdminCommon.snp_User.BOF))
			{

				lbl_user_id.Text = $"LOGIN: {Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().Trim()}";
				lbl_User_Name.Text = $"NAME: {Convert.ToString(modAdminCommon.snp_User["user_first_name"]).Trim()} {Convert.ToString(modAdminCommon.snp_User["user_last_name"]).Trim()}";
				lbl_user_type.Text = $"ROLE: {Convert.ToString(modAdminCommon.snp_User["user_type"]).Trim()}";
				lblDatabase.Text = $"DATABASE: {txt_database_name.Text.Trim()}";

				pnl_Status.Visible = true;

				if (Convert.ToString(modAdminCommon.snp_User["user_manage_accounts_flag"]).Trim().ToUpper() == "Y")
				{
					img_Administration.Visible = true;
					img_Accounts.Visible = true;
				}

			}

		}
		[STAThread]
		static void Main() => Application.Run(CreateInstance());

	}
}