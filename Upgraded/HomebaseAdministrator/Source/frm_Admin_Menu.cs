using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;

namespace HomebaseAdministrator
{
	internal partial class frm_Admin_Menu
		: System.Windows.Forms.Form
	{


		private string CMDLine = "";
		public frm_Admin_Menu()
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



		private void ProcessCommandLine()
		{


			CMDLine = string.Join(" ", Environment.GetCommandLineArgs().Skip(1).ToArray()).Trim();

			if (Strings.Len(CMDLine) == 0)
			{
				return;
			}

			//MsgBox CMDLine
			string tmp = ParseLine("IP=", CMDLine);
			if (Strings.Len(tmp) > 0)
			{
				this.txt_ip_address.Text = tmp;
			}

			tmp = ParseLine("DB=", CMDLine);
			if (Strings.Len(tmp) > 0)
			{
				this.txt_database_name.Text = tmp;
			}

			tmp = ParseLine("USR=", CMDLine);
			if (Strings.Len(tmp) > 0)
			{
				this.txt_login_ID.Text = tmp;
				modAdminCommon.gbl_User_ID = tmp;
			}

			tmp = ParseLine("USRPWD=", CMDLine);
			if (Strings.Len(tmp) > 0)
			{
				this.txt_login_password.Text = tmp;
			}

			tmp = ParseLine("UID=", CMDLine);
			if (Strings.Len(tmp) > 0)
			{
				this.txt_db_login.Text = tmp;
			}

			tmp = ParseLine("PSW=", CMDLine);
			if (Strings.Len(tmp) > 0)
			{
				this.txt_db_password.Text = tmp;
			}

		}

		public string ParseLine(string Str1, string Str2)
		{


			int K = (Str2.IndexOf(Str1, StringComparison.CurrentCultureIgnoreCase) + 1);
			if (K == 0)
			{
				return "";
			}

			string tmp = $"{Str2.Substring(Math.Min(K + Strings.Len(Str1) - 1, Str2.Length))} "; //add space to end in case we are at end-of-line
			int J = (tmp.IndexOf(' ') + 1);
			tmp = tmp.Substring(Math.Min(0, tmp.Length), Math.Min(J - 1, Math.Max(0, tmp.Length)));
			return tmp;


		}

		private void cmd_Cancel_Click(Object eventSender, EventArgs eventArgs) => Environment.Exit(0);


		private void cmd_db_cancel_Click(Object eventSender, EventArgs eventArgs) => pnl_Database.Visible = false;


		private void cmd_login_Click(Object eventSender, EventArgs eventArgs)
		{

			string Latest_EXE_Path = "";
			string latest_exe_date = "";
			string current_exe_path = "";
			string current_exe_date = "";
			string Query = "";
			string M = "";
			double RetVal = 0;

			if (txt_database_name.Text.ToLower().Trim() == "jetnet_ra_test")
			{
			}
			else
			{
				if (Strings.Len(CMDLine) > 0)
				{
					ProcessCommandLine();
				}
			}

			if (txt_database_name.Text.ToLower().Trim() == "jetnet_ra_test")
			{
				txt_ip_address.Text = "tcp:10.10.254.56"; // VM-SQL02
				//txt_ip_address = "tcp:10.10.254.57" ' VM-SQL03
			}
			else
			{
				txt_database_name.Text = "jetnet_ra";
				if (txt_ip_address.Text.ToLower().Trim() != "tcp:localhost")
				{
					txt_ip_address.Text = "tcp:10.10.254.54";
				} // VM-SQL01
			}
			if (modAdminCommon.Open_Database(txt_database_name.Text.Trim(), txt_ip_address.Text.Trim(), txt_db_password.Text.Trim()))
			{

				if (Valid_User())
				{

					modAdminCommon.gbl_Live_flag = false;

					if (txt_database_name.Text.Trim().ToLower() == "jetnet_ra")
					{
						lbl_DatabaseType.Text = "LIVE SYSTEM";
						if (txt_ip_address.Text.Trim().ToLower() == "tcp:localhost")
						{
							lbl_DatabaseType.Text = "LOCAL TESTING ONLY";
						}
						mdi_AdminAssistant.DefInstance.lbl_WhichDatabase.Text = "Live System";
						mdi_AdminAssistant.DefInstance.lbl_WhichDatabase.Visible = true;
						modAdminCommon.gbl_Live_flag = true;
					}
					else if (txt_database_name.Text.Trim().ToLower() == "jetnet_ra_backup")
					{ 
						lbl_DatabaseType.Text = "BACKUP SYSTEM";
						mdi_AdminAssistant.DefInstance.lbl_WhichDatabase.Text = "Backup System";
						mdi_AdminAssistant.DefInstance.lbl_WhichDatabase.Visible = true;
					}
					else if (txt_database_name.Text.Trim().ToLower() == "jetnet_ra_test")
					{ 
						lbl_DatabaseType.Text = "TEST SYSTEM";
						mdi_AdminAssistant.DefInstance.lbl_WhichDatabase.Text = "Test System";
						mdi_AdminAssistant.DefInstance.lbl_WhichDatabase.Visible = true;
					}
					else
					{
						lbl_DatabaseType.Text = "TEST SYSTEM";
						mdi_AdminAssistant.DefInstance.lbl_WhichDatabase.Text = "Test System";
						mdi_AdminAssistant.DefInstance.lbl_WhichDatabase.Visible = true;
					}

					mdi_AdminAssistant.DefInstance.Text = $"Welcome {Convert.ToString(modMyAdmin.MYSNP_USER["user_first_name"])}";
					lbl_Welcome.Text = $"Welcome {Convert.ToString(modMyAdmin.MYSNP_USER["user_first_name"])}";
					lbl_Welcome.Visible = true;

					modAdminCommon.Get_Application_Configuration();

					// 03/06/2008 - By David D. Cruger All Users Can See These
					mnuInstall.Enabled = true;
					mnuNewRelease.Available = true;
					mnuTomorrow.Available = true;

					this.Cursor = Cursors.WaitCursor;

					if (Strings.Len(modAdminCommon.gbl_Fileserver.Trim()) > 0)
					{
						//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2099
						if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => (FileSystem.Dir($"{modAdminCommon.gbl_Fileserver}\\JETNETADMIN_Setup.exe") != "")))
						{
							ErrorHandlingHelper.ResumeNext( //aey 4/12/04
								() => {current_exe_path = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\HomebaseAdmin.exe";},  //aey 4/12/04
								() => {current_exe_date = "2004/04/12 00:00:00";}); //default date
							//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2099
							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => (FileSystem.Dir(current_exe_path) != "")))
							{
								try
								{
									current_exe_date = (new FileInfo(current_exe_path)).LastWriteTime.AddMinutes(2).ToString("yyyy/MM/dd HH:mm:ss");
								}
								catch
								{
								}
							}
							ErrorHandlingHelper.ResumeNext(
								() => {Latest_EXE_Path = $"{modAdminCommon.gbl_Fileserver}\\JETNETADMIN_Setup.exe";}, 
								() => {latest_exe_date = (new FileInfo(Latest_EXE_Path)).LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss");});

							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => String.CompareOrdinal(latest_exe_date, current_exe_date) > 0))
							{
								M = $"There is a more recent version of the 'Jetnet HomebaseAdmin.exe' on the server.{"\r"}{"\r"}";
								try
								{
									M = $"{M}Do you wish to install the more recent version at this time?";
								}
								catch
								{
								}
								if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => MessageBox.Show(M, "Version Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
								{
									ErrorHandlingHelper.ResumeNext(
											//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
										() => {RetVal = Process.Start(Latest_EXE_Path).Id;}, 
										() => {Environment.Exit(0);});
								}
							}
						}
					}

					modAdminCommon.DateToday = modAdminCommon.GetSystemDateTime();
					modAdminCommon.DateToday = DateTime.Parse(modAdminCommon.DateToday).ToString("d");

					Query = "Delete FROM Aircraft_Lock";
					Query = $"{Query} WHERE alock_user_id = '{Convert.ToString(modMyAdmin.MYSNP_USER["user_id"])}'";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					Query = "Delete FROM Company_Lock";
					Query = $"{Query} WHERE complock_user_id = '{Convert.ToString(modMyAdmin.MYSNP_USER["user_id"])}'";
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

					Query = "Delete FROM Contact_Lock";
					Query = $"{Query} WHERE contlock_user_id = '{Convert.ToString(modMyAdmin.MYSNP_USER["user_id"])}'";
					DbCommand TempCommand_3 = null;
					TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
					TempCommand_3.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
					TempCommand_3.ExecuteNonQuery();

					Display_Menu_Labels();

				}
				else
				{
					Clear_Menu_Labels();
					MessageBox.Show("Login not found. Please try again", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			else
			{
				MessageBox.Show($"{("Cannot find database. Please try again")} db: {txt_database_name.Text.ToLower()} ip:{this.txt_ip_address.Text} cmd: {Strings.Len(CMDLine.Trim()).ToString()}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				this.Cursor = CursorHelper.CursorDefault;

			}

			mnuJunk.Available = txt_login_ID.Text.ToLower() == "mvit" || txt_login_ID.Text.ToLower() == "dcr";

			modAdminCommon.BusTypeArryFilled = false;

			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_Logout_Click(Object eventSender, EventArgs eventArgs) => Environment.Exit(0);


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

				Form Form = null;
				string Query = "";
				string tmp = ""; //temp variable

				modAdminCommon.gbl_bHomeClicked = false;

				modAdminCommon.gbl_Form = frm_Admin_Menu.DefInstance;
				pnl_Database.Visible = false;
				modAdminCommon.gbl_FormLoop = 0;
				lbl_Message.Text = "";

				if (modAdminCommon.gbl_User_ID != "")
				{
					pnl_Database.Visible = false;
					txt_database_name.Text = "jetnet_ra";

					txt_db_login.Text = "sa";
					txt_db_password.Text = "moejive";

					opt_Server.Checked = false;

				}

				foreach (Form FormIterator in Application.OpenForms)
				{
					Form = FormIterator;
					if (Form.Name != "frm_Admin_Menu" && Form.Name != "mdi_AdminAssistant")
					{
						Form.Close();
						//UPGRADE_NOTE: (1029) Object Form may not be destroyed until it is garbage collected. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-1029
						Form = null;
					}
					//Form
					Form = default(Form);
				}

			}
		}

		private void Form_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{


				switch(KeyAscii)
				{
					case 10 : 
						// TEST DATABASE - CONTROL J 
						txt_database_name.Text = "jetnet_ra_test"; 
						txt_login_ID.Text = "mvit"; 
						txt_db_password.Text = "moejive"; 
						txt_login_password.Text = "becareful"; 
						 
						cmd_login_Click(cmd_login, new EventArgs()); 
						 
						break;
					case 11 : 
						 
						//test commericial database - control K 
						txt_database_name.Text = "jetnet_ra_commercial"; 
						txt_db_password.Text = "moejive"; 
						txt_login_ID.Text = "mvit"; 
						txt_login_password.Text = "becareful"; 
						 
						cmd_login_Click(cmd_login, new EventArgs()); 
						 
						break;
					case 12 : 
						 
						//local database - control L 
						pnl_Database.Visible = true; 
						txt_ip_address.Text = "tcp:localhost"; 
						txt_database_name.Text = "jetnet_ra"; 
						 
						txt_db_login.Text = "sa"; 
						txt_db_password.Text = "krw32n89"; 
						 
						txt_login_ID.Text = "mvit"; 
						txt_login_password.Text = "becareful"; 
						 
						cmd_login_Click(cmd_login, new EventArgs()); 
						 
						break;
					case 20 : 
						 
						//test commericial database - control T 
						pnl_Database.Visible = true; 
						txt_database_name.Text = "jetnet_ra_commercial_test"; 
						txt_db_password.Text = "moejive"; 
						txt_login_ID.Text = "mvit"; 
						txt_login_password.Text = "becareful"; 
						 
						cmd_login_Click(cmd_login, new EventArgs()); 
						 
						break;
					case 4 : 
						// DAVE'S SQL - CONTROL-T 
						pnl_Database.Visible = true; 
						txt_ip_address.Text = "techpc04"; 
						txt_db_login.Text = "sa"; 
						txt_db_password.Text = ""; 
						 
						txt_login_ID.Text = "mvit"; 
						txt_login_password.Text = "becareful"; 
						 
						cmd_login_Click(cmd_login, new EventArgs()); 
						 
						break;
				}
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{


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

				() => {lbl_DatabaseType.Text = "";}, 
				() => {modAdminCommon.gbl_ConfirmDays = 90;});

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

				CMDLine = string.Join(" ", Environment.GetCommandLineArgs().Skip(1).ToArray()).Trim();
			}
			catch
			{
			}

			if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Strings.Len(CMDLine) > 0))
			{
				ErrorHandlingHelper.ResumeNext(
					() => {ProcessCommandLine();}, 
					() => {cmd_login_Click(cmd_login, new EventArgs());});
			}

		}

		public bool Valid_User()
		{

			bool result = false;
			bool HadPassword = false;
			modAdminCommon.gbl_User_Browser = "I";

			this.Cursor = Cursors.WaitCursor;
			string Query = $"SELECT * FROM [User] WHERE user_id ='{($"{txt_login_ID.Text} ").Trim()}' ";
			if (txt_login_password.Text.Trim() != "")
			{
				Query = $"{Query}and user_password='{modAdminCommon.Fix_Quote(($"{txt_login_password.Text} ").Trim())}'";
				HadPassword = true;
			}

			modMyAdmin.MYSNP_USER = new ADORecordSetHelper(); //AEY 4/12/04
			modMyAdmin.MYSNP_USER.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			modAdminCommon.snp_User = modMyAdmin.MYSNP_USER;

			if (!(modMyAdmin.MYSNP_USER.BOF && modMyAdmin.MYSNP_USER.EOF))
			{
				if (!HadPassword)
				{
					if (($"{Convert.ToString(modMyAdmin.MYSNP_USER["user_password"])}").Trim() != "")
					{
						return false;
					}
				}
				modAdminCommon.gbl_User_ID = txt_login_ID.Text.Trim().ToLower();
				modAdminCommon.gbl_User_Browser = ($"{Convert.ToString(modMyAdmin.MYSNP_USER["user_browser_type"])} ").Trim().ToUpper();
				result = true;
			}

			this.Cursor = CursorHelper.CursorDefault;

			return result;
		}

		public void Clear_Menu_Labels()
		{
			lbl_login_message.Text = "Welcome to Homebase.  Please enter your login.";
			lbl_Message.Text = "";
			this.lb_aircraft.Visible = false;
			this.Lb_Common.Visible = false;
			this.lb_contact.Visible = false;

			lbl_user_id.Text = "";
			lbl_User_Name.Text = "";
			lbl_user_type.Text = "";
			lblDatabase.Text = "";

			pnl_Login.Visible = true;
			pnl_Status.Visible = false;

		}

		public void Display_Menu_Labels()
		{

			this.lb_aircraft.Visible = true;

			this.lb_contact.Visible = true;

			this.Lb_Common.Visible = txt_login_ID.Text.ToLower() == "dcr" || txt_login_ID.Text.ToLower() == "mvit" || txt_login_ID.Text.ToLower() == "lmc" || txt_login_ID.Text.ToLower() == "pls" || txt_login_ID.Text.ToLower() == "kkf" || txt_login_ID.Text.ToLower() == "abr" || txt_login_ID.Text.ToLower() == "hus" || txt_login_ID.Text.ToLower() == "ms" || txt_login_ID.Text.ToLower() == "jal" || txt_login_ID.Text.ToLower() == "aja" || txt_login_ID.Text.ToLower() == "slh" || txt_login_ID.Text.ToLower() == "djl" || txt_login_ID.Text.ToLower() == "jas" || txt_login_ID.Text.ToLower() == "alo";



			pnl_Login.Visible = false;
			pnl_Status.Visible = true;

			lbl_Message.Text = "";
			lbl_user_id.Text = $"LOGIN: {Convert.ToString(modMyAdmin.MYSNP_USER["user_id"]).Trim()}";
			lbl_User_Name.Text = $"NAME: {($"{Convert.ToString(modMyAdmin.MYSNP_USER["user_first_name"])} ").Trim()} {($"{Convert.ToString(modMyAdmin.MYSNP_USER["user_last_name"])} ").Trim()}";
			lbl_user_type.Text = $"ROLE: {($"{Convert.ToString(modMyAdmin.MYSNP_USER["user_type"])} ").Trim()}";
			lblDatabase.Text = $"DATABASE: {txt_database_name.Text.Trim()}";

		}

		private void lb_aircraft_Click(Object eventSender, EventArgs eventArgs)
		{
			lbl_Message.Text = "Loading Aircraft Tables Administration Form ...";
			frm_AircraftLookup.DefInstance.Show();
		}

		private void Lb_Common_Click(Object eventSender, EventArgs eventArgs)
		{
			lbl_Message.Text = "Loading Common Tables Administration Form ...";
			frm_CommonLookup.DefInstance.Show();
		}

		private void lb_contact_Click(Object eventSender, EventArgs eventArgs)
		{
			lbl_Message.Text = "Loading Company/Contact Tables Administration Form ...";
			frm_CompanyContactLookup.DefInstance.Show();
		}



		public void mnuFileDatabase_Click(Object eventSender, EventArgs eventArgs) => pnl_Database.Visible = true;


		public void mnuFileLogout_Click(Object eventSender, EventArgs eventArgs) => Environment.Exit(0);


		public void mnuHelp_Click(Object eventSender, EventArgs eventArgs)
		{

			if (modAdminCommon.gbl_User_ID.Trim() != "")
			{
				MessageBox.Show("Help is forecomming", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			else
			{
				MessageBox.Show("You must log in before clicking 'Help'", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		public void mnuInstall_Click(Object eventSender, EventArgs eventArgs)
		{


			string Query = $"UPDATE [User] SET user_newest_software = 'Y WHERE user_id = '{Convert.ToString(modMyAdmin.MYSNP_USER["user_id"])}'";

			string Latest_EXE_Path = $"{modAdminCommon.gbl_Fileserver}\\JetnetAdmin_setup.exe";
			//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
			Process.Start(Latest_EXE_Path);
			Environment.Exit(0);

		}

		public void mnuNewRelease_Click(Object eventSender, EventArgs eventArgs)
		{

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = "UPDATE [User] SET user_newest_software = 'N'";
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			MessageBox.Show("User Table Updated.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

		}

		public void mnuReLogin_Click(Object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			Form_Activated(this, new EventArgs());
			Clear_Menu_Labels();

			txt_login_ID.Text = "";
			txt_login_password.Text = "";
			txt_database_name.Text = "jetnet_ra"; //aey 6/9/2004

			txt_login_ID.Focus();

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1069
		}

		public void mnuTomorrow_Click(Object eventSender, EventArgs eventArgs)
		{


			string Query = $"UPDATE [User] SET user_newest_software = 'Y WHERE user_id = '{Convert.ToString(modMyAdmin.MYSNP_USER["user_id"])}'";

			string Latest_EXE_Path = $"{modAdminCommon.gbl_Fileserver}\\NextRelease\\JetnetAdmin_setup.exe";
			//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
			Process.Start(Latest_EXE_Path);
			Environment.Exit(0);

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
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}