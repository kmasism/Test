using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;
using JetNetSupport.Excel;

namespace JETNET_Homebase
{
	internal partial class frm_Subscription
		: System.Windows.Forms.Form
	{



		public DbConnection REMOTE_ADO_DB = null;
		public bool AlreadyOpen = false;


		const int gridCellActiveColor = unchecked((int) 0x80000005); // White = -2147483643
		const int gridCellInActiveColor = 0xE0E0E0; // Grey  =  14737632

		const int SaveSSCNotes = 0;
		const int ExportSSCNotes = 1;

		const int SaveCloudNotes = 2;
		const int ExportCloudNotes = 3;

		const int StopImportEvoLocalNotesToCloudNotes = 4;
		const int BrowseEvoLocalNotes = 5;
		const int StopImportCRMSSNotesToCloudNotes = 6;
		const int StopImportCloudNotesToCRMSSNotes = 7;

		const int ImportEvoLocalNotesToCloudNotes = 8;
		const int ImportSSNToCN = 9;
		const int ImportCNToSSN = 10;

		const int iSAVESUBSCRIPTION = 0;
		const int iREMOVESUBSCRIPTION = 1;
		const int iNEWSUBSCRIPTION = 2;
		const int iMOVESUBSCRIPTION = 3;

		const int iNbrInstalls = 0;
		const int iNBRVALUEINSTALLS = 1;
		const int iNBRMPMINSTALLS = 2;

		const int iSUBSCRIPTIONID = 0;
		const int iEVOLASTAPPNAME = 8;
		const int iDOCUMENTDATE = 41;
		const int iEXPIRATIONDATE = 48;
		const int iCALENDARDOCUMENTDATE = 49;
		const int iVIEWMPMUSERS = 51;
		const int iNOTESLOADING = 52;
		const int iSTOPLOADING = 53;
		const int iCOPYLOGINS = 54;

		private string tmpLoginName = "";
		private bool CalendarGotFocus = false;
		private string RecordStat = ""; //"Add", "Delete", etc...

		private string Mode = "";
		private int RememberLoginPosition = 0;
		private string LoginsOrderBy = "";
		private string InstallationsOrderBy = "";
		private bool FormLoaded = false;
		private string[] serv_code = null;

		// RTW ADDED MPMACTIVE VARIABLE ON 1/14/2022
		public bool MPMActive = false;

		// 03/12/2003 - By David D. Cruger; Added these three global variables
		private CheckState iLOGINACTIVE = CheckState.Unchecked;
		private CheckState iLOGINDEMO = CheckState.Unchecked;
		private CheckState iInstallationActive = CheckState.Unchecked;

		// 05/02/2008 - By David D. Cruger; Added these flags
		private CheckState iLOGINEXPORT = CheckState.Unchecked;
		private CheckState iLOGINLOCALNOTES = CheckState.Unchecked;
		private CheckState iLOGINPROJECTS = CheckState.Unchecked;
		private CheckState iLOGINEMAILREQUEST = CheckState.Unchecked;
		private CheckState iLOGINEVENTREQUEST = CheckState.Unchecked;
		private CheckState iLOGINTEXTMSG = CheckState.Unchecked;
		private CheckState iLOGINVALUES = CheckState.Unchecked;
		private CheckState iLOGINMPM = CheckState.Unchecked;

		// 02/10/2010 - By David D. Cruger
		private string strSMSTextActiveFlag = "";

		// 01/18/2010 - By David D. Cruger
		private CheckState iByPassActiveXReg = CheckState.Unchecked;

		// 10/30/2003 - By David D. Cruger; Added this global variable to track Subscription TimeOut Changes
		private string gstrTimeOut = "";

		private bool mvHasFocus = false;
		private string strAddChgHasHappened = "";
		private bool bAutoCreateCloudNotesFlag = false;
		private bool gbMPM = false; // Does This Company Have A CRM/MPM Subscription
		public bool is_dealer_broker = false;
		string password_changed = "";
		int has_mpm = 0;
		string has_mpm_db_name = "";
		int has_mpm_connection = 0;
		int mpm_sub_id = 0;
		int possible_mpm_evo_id = 0;
		public frm_Subscription()
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




		public void change_install_Status(bool active_yes)
		{



			int lCompId = modSubscription.Entered_Company_ID;
			int lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));
			string strLogin = txtLoginName.Text.Trim();


			string Query = "Update Subscription_Install set ";

			Query = $"{Query} subins_action_date = NULL, "; // clear the action date - MSW - 11/3/24

			if (active_yes)
			{ // then it was activated
				Query = $"{Query}subins_active_flag = 'Y' ";
			}
			else
			{
				// then it was inactivated
				Query = $"{Query}subins_active_flag = 'N' ";
			}

			Query = $"{Query}WHERE (subins_login = '{modAdminCommon.Fix_Quote(Convert.ToString(grd_Installations.Tag)).Trim()}') ";
			Query = $"{Query}AND (subins_sub_id = {modSubscription.gbl_SubID.ToString()}) AND (subins_seq_no = 1) ";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();


		}



		private void Load_Subscription_Grid_Headers()
		{

			grd_Subscriptions.Clear();
			grd_Subscriptions.RowsCount = 2;
			grd_Subscriptions.FixedRows = 1;
			grd_Subscriptions.FixedColumns = 0;
			grd_Subscriptions.ColumnsCount = 5;
			grd_Subscriptions.CurrentRowIndex = 0;

			grd_Subscriptions.CurrentColumnIndex = 0;
			grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Subscriptions.SetColumnWidth(0, 40);
			grd_Subscriptions.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = "Sub ID";

			grd_Subscriptions.CurrentColumnIndex = 1;
			grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Subscriptions.SetColumnWidth(1, 0);
			grd_Subscriptions.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = "Serv Code";

			grd_Subscriptions.CurrentColumnIndex = 2;
			grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Subscriptions.SetColumnWidth(2, 343);
			grd_Subscriptions.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = "Service";
			grd_Subscriptions.CurrentColumnIndex = 3;

			grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Subscriptions.SetColumnWidth(3, 0);
			grd_Subscriptions.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = "Start Date";
			grd_Subscriptions.CurrentColumnIndex = 4;

			grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Subscriptions.SetColumnWidth(4, 0);
			grd_Subscriptions.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = "End Date";

			grd_Subscriptions.CurrentRowIndex = 1;

		} // Load_Subscription_Grid_Headers

		private void Load_Login_Grid_Headers()
		{

			grd_Logins.Clear();
			grd_Logins.RowsCount = 2;
			grd_Logins.FixedRows = 1;
			grd_Logins.FixedColumns = 0;
			grd_Logins.ColumnsCount = 17;
			grd_Logins.CurrentRowIndex = 0;

			grd_Logins.CurrentColumnIndex = 0;
			grd_Logins.SetColumnWidth(0, 117);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Login";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;

			grd_Logins.CurrentColumnIndex = 1;
			grd_Logins.SetColumnWidth(1, 117);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Password";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;

			grd_Logins.CurrentColumnIndex = 2;
			grd_Logins.SetColumnWidth(2, 42);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Active";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;

			grd_Logins.CurrentColumnIndex = 3;
			grd_Logins.SetColumnWidth(3, 42);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Demo";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;

			grd_Logins.CurrentColumnIndex = 4;
			grd_Logins.SetColumnWidth(4, 0);

			grd_Logins.CurrentColumnIndex = 5;
			grd_Logins.SetColumnWidth(5, 42);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Notes";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;

			grd_Logins.CurrentColumnIndex = 6;
			grd_Logins.SetColumnWidth(6, 0);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Projects";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;

			grd_Logins.CurrentColumnIndex = 7;
			grd_Logins.SetColumnWidth(7, 42);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "EMail";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;

			grd_Logins.CurrentColumnIndex = 8;
			grd_Logins.SetColumnWidth(8, 42);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Event";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;
			grd_Logins.CurrentColumnIndex = 9;
			grd_Logins.SetColumnWidth(9, 0);

			grd_Logins.CurrentColumnIndex = 10;
			if (($"{Convert.ToString(modAdminCommon.snp_User["user_subscription_contract_amount"])} ").Trim() == "Y")
			{
				grd_Logins.SetColumnWidth(10, 47);
			}
			else
			{
				grd_Logins.SetColumnWidth(10, 0);
			}
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Amount";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;

			// 06/03/2009 - By David D. Cruger; Added
			grd_Logins.CurrentColumnIndex = 11;
			grd_Logins.SetColumnWidth(11, 52);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Text Msg";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;

			// 01/18/2010 - By David D. Cruger; Added
			grd_Logins.CurrentColumnIndex = 12;
			grd_Logins.SetColumnWidth(12, 0);

			grd_Logins.CurrentColumnIndex = 13;
			grd_Logins.SetColumnWidth(13, 53);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Values";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;

			// 09/20/2019 - By David D. Cruger; Added
			grd_Logins.CurrentColumnIndex = 14;
			grd_Logins.SetColumnWidth(14, 42);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "MPM";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;
			Application.DoEvents();

			grd_Logins.CurrentColumnIndex = 15;
			grd_Logins.SetColumnWidth(15, 53);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Billed";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;


			grd_Logins.CurrentColumnIndex = 16;
			grd_Logins.SetColumnWidth(15, 0);
			grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Build";
			grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Logins.CellBackColor = grd_Logins.BackColorFixed;

			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();


			grd_Logins.CurrentRowIndex = 1;

		} // Load_Login_Grid_Headers

		private void Load_Installation_Grid_Headers()
		{

			fra_Add_Installation.Text = "Installation";
			grd_Installations.Clear();
			grd_Installations.RowsCount = 2;
			grd_Installations.FixedRows = 1;
			grd_Installations.FixedColumns = 0;
			grd_Installations.ColumnsCount = 36;
			grd_Installations.CurrentRowIndex = 0;

			grd_Installations.CurrentColumnIndex = 0;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(0, 27);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Seq";

			grd_Installations.CurrentColumnIndex = 1;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(1, 150);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Platform";

			grd_Installations.CurrentColumnIndex = 2;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(2, 133);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Operating System";

			grd_Installations.CurrentColumnIndex = 3;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(3, 67);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Install Date";

			grd_Installations.CurrentColumnIndex = 4;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(4, 127);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Last Access";

			grd_Installations.CurrentColumnIndex = 5;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(5, 37);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Active";

			grd_Installations.CurrentColumnIndex = 6;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(6, 67);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Local Notes";

			grd_Installations.CurrentColumnIndex = 7;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(7, 67);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Display Tag";

			grd_Installations.CurrentColumnIndex = 8;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(8, 100);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Local Notes Path";

			grd_Installations.CurrentColumnIndex = 9;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(9, 73);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "WebTimeOut";

			grd_Installations.CurrentColumnIndex = 10;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(10, 47);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Active X";

			grd_Installations.CurrentColumnIndex = 11;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(11, 67);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "AutoChk TS";

			grd_Installations.CurrentColumnIndex = 12;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(12, 53);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "T-Service";

			grd_Installations.CurrentColumnIndex = 13;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(13, 117);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Reply Name";

			grd_Installations.CurrentColumnIndex = 14;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(14, 150);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Reply EMail";

			grd_Installations.CurrentColumnIndex = 15;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(15, 43);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Format";

			// 11/26/2007 - By David D. Cruger - Added
			grd_Installations.CurrentColumnIndex = 16;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			if (($"{Convert.ToString(modAdminCommon.snp_User["user_subscription_contract_amount"])} ").Trim() == "Y")
			{
				grd_Installations.SetColumnWidth(16, 47);
			}
			else
			{
				grd_Installations.SetColumnWidth(16, 0);
			}
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Amount";

			// 06/03/2009 - By David D. Cruger; Added
			grd_Installations.CurrentColumnIndex = 17;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(17, 83);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Cell Nbr";

			grd_Installations.CurrentColumnIndex = 18;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(18, 133);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Cell Srv";

			grd_Installations.CurrentColumnIndex = 19;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations.SetColumnWidth(19, 133);
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "TxtMdls";

			grd_Installations.CurrentColumnIndex = 20;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(20, 67);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "SMS Active";

			grd_Installations.CurrentColumnIndex = 21;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(21, 133);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Mobile Active";

			grd_Installations.CurrentColumnIndex = 22;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(22, 83);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Default AModId";

			// 02/19/2010 - By David D. Cruger; Added
			grd_Installations.CurrentColumnIndex = 23;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(23, 67);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Evo-Mobile";

			// 03/08/2011 - By David D. Cruger; Added
			grd_Installations.CurrentColumnIndex = 24;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(24, 83);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "SMS Events";

			// 07/11/2011 - By David D. Cruger; Added
			grd_Installations.CurrentColumnIndex = 25;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(25, 67);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "ContactId";

			grd_Installations.CurrentColumnIndex = 26;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(26, 150);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Contact Name";

			grd_Installations.CurrentColumnIndex = 27;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(27, 127);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Last Login";

			grd_Installations.CurrentColumnIndex = 28;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(28, 127);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Last Logout";

			grd_Installations.CurrentColumnIndex = 29;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(29, 127);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Last Session";

			// 11/06/2012 - By David D. Cruger; Added
			grd_Installations.CurrentColumnIndex = 30;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(30, 87);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "BGImageId";

			// 11/06/2012 - By David D. Cruger; Added
			grd_Installations.CurrentColumnIndex = 31;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(31, 67);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "#Rec/Pg";

			// 07/12/2013 - By David D. Cruger; Added
			grd_Installations.CurrentColumnIndex = 32;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(32, 67);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Admin Flag";

			// 08/22/2014 - By David D. Cruger; Added
			grd_Installations.CurrentColumnIndex = 33;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(33, 67);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Chat Flag";

			// 08/22/2014 - By David D. Cruger; Added
			grd_Installations.CurrentColumnIndex = 34;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(34, 67);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "BType";

			// 08/14/2017 - By David D. Cruger; Added
			grd_Installations.CurrentColumnIndex = 35;
			grd_Installations.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_Installations.SetColumnWidth(35, 83);
			grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Analysis Mths";

			grd_Installations.CurrentRowIndex = 1;

		} // Load_Installation_Grid_Headers

		private void CheckPermision()
		{

			Control tmpCommandButtons = null;
			Button tmpCommandButtonsTyped = null;
			if ((Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Researcher") && (Convert.ToString(modAdminCommon.snp_User["user_id"]).ToUpper() != "MMC") && (Convert.ToString(modAdminCommon.snp_User["user_id"]).ToUpper() != "KCB"))
			{
				//UPGRADE_WARNING: (2065) Form property frm_Subscription.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				foreach (Control tmpCommandButtonsIterator in ContainerHelper.Controls(this))
				{
					tmpCommandButtons = tmpCommandButtonsIterator;
					if (tmpCommandButtons is Button)
					{
						tmpCommandButtonsTyped = (Button) tmpCommandButtons;
						tmpCommandButtonsTyped.Visible = false;
					}
					//tmpCommandButtons
					tmpCommandButtons = default(Control);
				}

				cmd_Close.Visible = true;
				cmdCancelLoginFrame.Visible = true;
				cmd_InstallCancel.Visible = true;
			}

		} // CheckPermision

		// 03/27/2014 - By David D. Cruger; Created

		private void ClearSavedProjectsFolders(int lSubId, string strLogin, int lSeqNbr, bool bQuite)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			string strDelete1 = "";

			try
			{

				if (lSubId > 0)
				{

					strLogin = strLogin.Trim();

					if (modSubscription.OpenRemoteDatabase())
					{

						//-----------------------------------------------------------------------------

						if (!bQuite)
						{
							modSubscription.search_on("Clearing Saved Projects", "Remote Database");
						}

						strDelete1 = "DELETE FROM Subscription_Install_Saved_Search_Criteria ";
						strDelete1 = $"{strDelete1}WHERE (sissc_sub_id = {lSubId.ToString()}) ";

						if (strLogin != "")
						{
							strDelete1 = $"{strDelete1}AND (sissc_login = '{strLogin}') ";
						}

						if (lSeqNbr >= 0)
						{
							strDelete1 = $"{strDelete1}AND (sissc_seq_no = {lSeqNbr.ToString()}) ";
						}

						DbCommand TempCommand = null;
						TempCommand = REMOTE_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strDelete1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						//-----------------------------------------------------------------------------

						if (!bQuite)
						{
							modSubscription.search_on("Clearing Saved Projects", "Local Database");
						}

						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = strDelete1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();

						//-----------------------------------------------------------------------------

						if (!bQuite)
						{
							modSubscription.search_on("Clearing Folders", "Remote Database");
						}

						strQuery1 = $"SELECT * FROM Client_Folder WITH (NOLOCK) WHERE (cfolder_sub_id = {lSubId.ToString()}) ";

						if (strLogin != "")
						{
							strQuery1 = $"{strQuery1}AND (cfolder_login = '{strLogin}') ";
						}

						if (lSeqNbr > 0)
						{
							strQuery1 = $"{strQuery1}AND (cfolder_seq_no = {lSeqNbr.ToString()}) ";
						}

						rstRec1.Open(strQuery1, REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							do 
							{ // Loop Until rstRec1.EOF = True

								strDelete1 = $"DELETE FROM Client_Folder_Index WHERE (cfoldind_cfolder_id = {Convert.ToString(rstRec1["cfolder_id"])}) ";

								DbCommand TempCommand_3 = null;
								TempCommand_3 = REMOTE_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
								TempCommand_3.CommandText = strDelete1;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_3.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
								TempCommand_3.ExecuteNonQuery();

								rstRec1.MoveNext();

							}
							while(!rstRec1.EOF);

						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

						rstRec1.Close();

						strDelete1 = $"DELETE FROM Client_Folder WHERE (cfolder_sub_id = {lSubId.ToString()}) ";

						if (strLogin != "")
						{
							strDelete1 = $"{strDelete1}AND (cfolder_login = '{strLogin}') ";
						}

						if (lSeqNbr > 0)
						{
							strDelete1 = $"{strDelete1}AND (cfolder_seq_no = {lSeqNbr.ToString()}) ";
						}

						DbCommand TempCommand_4 = null;
						TempCommand_4 = REMOTE_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
						TempCommand_4.CommandText = strDelete1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_4.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
						TempCommand_4.ExecuteNonQuery();

						//-----------------------------------------------------------------------------

						if (!bQuite)
						{
							modSubscription.search_on("Clearing Folders", "Local Database");
						}

						strQuery1 = $"SELECT * FROM Client_Folder WITH (NOLOCK) WHERE (cfolder_sub_id = {lSubId.ToString()}) ";

						if (strLogin != "")
						{
							strQuery1 = $"{strQuery1}AND (cfolder_login = '{strLogin}') ";
						}

						if (lSeqNbr > 0)
						{
							strQuery1 = $"{strQuery1}AND (cfolder_seq_no = {lSeqNbr.ToString()}) ";
						}

						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							do 
							{ // Loop Until rstRec1.EOF = True

								strDelete1 = $"DELETE FROM Client_Folder_Index WHERE (cfoldind_cfolder_id = {Convert.ToString(rstRec1["cfolder_id"])}) ";

								DbCommand TempCommand_5 = null;
								TempCommand_5 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
								TempCommand_5.CommandText = strDelete1;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_5.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
								TempCommand_5.ExecuteNonQuery();

								rstRec1.MoveNext();

							}
							while(!rstRec1.EOF);

						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

						rstRec1.Close();

						strDelete1 = $"DELETE FROM Client_Folder WHERE (cfolder_sub_id = {lSubId.ToString()}) ";

						if (strLogin != "")
						{
							strDelete1 = $"{strDelete1}AND (cfolder_login = '{strLogin}') ";
						}

						if (lSeqNbr > 0)
						{
							strDelete1 = $"{strDelete1}AND (cfolder_seq_no = {lSeqNbr.ToString()}) ";
						}

						DbCommand TempCommand_6 = null;
						TempCommand_6 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
						TempCommand_6.CommandText = strDelete1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_6.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
						TempCommand_6.ExecuteNonQuery();

						//-----------------------------------------------------------------------------

						modSubscription.CloseRemoteDatabase();

					} // If OpenRemoteDatabase() = True Then

				} // If lSubId > 0 Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				modAdminCommon.Report_Error($"ClearSavedProjectsFolders_Error: {strErrDesc}");
				MessageBox.Show($"ClearSavedProjectsFolders_Error{Environment.NewLine}{strErrDesc}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // ClearSavedProjectsFolders

		private void ClearInstallDate(bool ClearNotes = false)
		{

			string Query = "";


			modSubscription.search_on("Clearing Install Date");

			grd_Installations.CurrentColumnIndex = 0;
			int iSeqNo = Convert.ToInt32(Double.Parse(grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()));

			grd_Installations.CurrentColumnIndex = 3; // Install Date
			string strInstallDate = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();

			grd_Installations.CurrentColumnIndex = 4; // Access Date
			string strAccessDate = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();

			grd_Installations.CurrentColumnIndex = 27; // Last Login Date
			string strLastLoginDate = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();

			grd_Installations.CurrentColumnIndex = 28; // Last Logout Date
			string strLastLogoutDate = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();

			grd_Installations.CurrentColumnIndex = 29; // Last Session Date
			string strLastSessionDate = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();

			grd_Installations.ColSel = grd_Installations.ColumnsCount - 1;

			string strTemp = $"SubId: {modSubscription.gbl_SubID.ToString()} " +
			                 $"Login: {txtLoginName.Text} " +
			                 $"Seq Nbr: {iSeqNo.ToString()} " +
			                 $"(Dates) " +
			                 $"Install: {strInstallDate} " +
			                 $"Access: {strAccessDate} " +
			                 $"Login: {strLastLoginDate} " +
			                 $"Logout: {strLastLogoutDate} " +
			                 $"Session: {strLastSessionDate} ";

			modSubscription.search_on("Clearing Install Date", $"SubId: {modSubscription.gbl_SubID.ToString()} - {txtLoginName.Text} - {iSeqNo.ToString()}");

			modAdminCommon.Record_Event("Clear Install Date", strTemp, 0, 0, modSubscription.Entered_Company_ID);

			string strUpdate1 = "UPDATE Subscription_Install SET subins_install_date = NULL, subins_access_date = NULL, ";

			strUpdate1 = $"{strUpdate1}subins_last_login_date = NULL, subins_last_logout_date = NULL, subins_last_session_date = NULL ";

			if (ClearNotes)
			{
				strUpdate1 = $"{strUpdate1}, subins_local_db_flag = 'N', subins_display_note_tag_on_aclist_flag = 'N', ";
				strUpdate1 = $"{strUpdate1}subins_local_db_file = NULL ";
			}

			strUpdate1 = $"{strUpdate1}WHERE subins_sub_id = {modSubscription.gbl_SubID.ToString()} AND subins_login = '{($"{txtLoginName.Text} ").Trim()}' ";
			strUpdate1 = $"{strUpdate1}AND subins_seq_no = {iSeqNo.ToString()}";

			if (modSubscription.gbl_SubID != 1266)
			{ // This is IN-HOUSE Research do NOT update WebServer

				if (frm_Main_Menu.DefInstance.lbl_DatabaseType.Text == "LIVE SYSTEM")
				{

					if (modSubscription.OpenRemoteDatabase())
					{

						modSubscription.search_on("Clearing Install Date", "Executing SQL Update Command - Remote Database");

						DbCommand TempCommand = null;
						TempCommand = REMOTE_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						modSubscription.CloseRemoteDatabase();

					} // If OpenRemoteDatabase Then

				} // If frm_Main_Menu.lbl_DatabaseType = "LIVE SYSTEM" Then

			} // If gbl_SubID <> 1266 Then ' This is IN-HOUSE Research do NOT update WebServer

			modSubscription.search_on("Clearing Install Date", "Executing SQL Update Command - Local Database");
			DbCommand TempCommand_2 = null;
			TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
			TempCommand_2.CommandText = strUpdate1;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
			TempCommand_2.ExecuteNonQuery(); //6/21/04 aey

			modCommon.DelaySeconds(1);

			modSubscription.search_off();

		} // ClearInstallDate

		private void DeleteLogin()
		{



			int lCommandTimeOut = 0;

			int lSubId = modSubscription.gbl_SubID;
			string strLogin = ($"{tmpLoginName} ").Trim();

			modSubscription.search_on("Deleting Login/Installations ...");

			string strDelete1 = $"DELETE FROM Subscription_Login  WHERE sublogin_sub_id = {lSubId.ToString()} AND sublogin_login = '{strLogin}'"; // Subscription_Login

			// 09/25/2002 - By David D. Cruger; Added SubId it was deleting 'All' installations by UserName
			string strDelete2 = $"DELETE FROM Subscription_Install WHERE subins_sub_id = {lSubId.ToString()} AND subins_login = '{strLogin}'"; // Subscription_Install

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = strDelete1;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();
			DbCommand TempCommand_2 = null;
			TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
			TempCommand_2.CommandText = strDelete2;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
			TempCommand_2.ExecuteNonQuery();

			// -------------------------------
			// Delete Remote Data
			// -------------------------------
			if (frm_Main_Menu.DefInstance.lbl_DatabaseType.Text == "LIVE SYSTEM")
			{

				if (modSubscription.OpenRemoteDatabase())
				{


					DbCommand TempCommand_3 = null;
					DbCommand TempCommand_4 = null;
					ErrorHandlingHelper.ResumeNext(
						() => {modSubscription.search_on("Deleting Login/Installations (WebSite)...");}, 

						() => {lCommandTimeOut = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(REMOTE_ADO_DB);}, 
						() => {UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(REMOTE_ADO_DB, 10);}, 
						() => {UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(REMOTE_ADO_DB, lCommandTimeOut);}, 

						() => {TempCommand_3 = REMOTE_ADO_DB.CreateCommand();}, 
						() => {UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);}, 
						() => {TempCommand_3.CommandText = strDelete1;}, 
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						() => {TempCommand_3.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));}, 
						() => {UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);}, 
						() => {TempCommand_3.ExecuteNonQuery();}, 
						() => {TempCommand_4 = REMOTE_ADO_DB.CreateCommand();}, 
						() => {UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);}, 
						() => {TempCommand_4.CommandText = strDelete2;}, 
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						() => {TempCommand_4.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));}, 
						() => {UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);}, 
						() => {TempCommand_4.ExecuteNonQuery();}, 

						() => {modSubscription.CloseRemoteDatabase();});

				} // If OpenRemoteDatabase() = True Then

			} // If frm_Main_Menu.lbl_DatabaseType = "LIVE SYSTEM" Then

			ClearSavedProjectsFolders(lSubId, strLogin, -1, true);

			UpdateActionDate();

			modSubscription.search_off();

		} // DeleteLogin

		private void DisableAllButtons()
		{

			Control tmpCommandButtons = null;

			Button tmpCommandButtonsTyped = null;
			//UPGRADE_WARNING: (2065) Form property frm_Subscription.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			foreach (Control tmpCommandButtonsIterator in ContainerHelper.Controls(this))
			{
				tmpCommandButtons = tmpCommandButtonsIterator;
				if (tmpCommandButtons is Button)
				{
					tmpCommandButtonsTyped = (Button) tmpCommandButtons;
					tmpCommandButtonsTyped.Enabled = false;
				}
				//tmpCommandButtons
				tmpCommandButtons = default(Control);
			}

		}

		private void EnableAllButtons()
		{

			Control tmpCommandButtons = null;

			Button tmpCommandButtonsTyped = null;
			//UPGRADE_WARNING: (2065) Form property frm_Subscription.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			foreach (Control tmpCommandButtonsIterator in ContainerHelper.Controls(this))
			{
				tmpCommandButtons = tmpCommandButtonsIterator;
				if (tmpCommandButtons is Button)
				{
					tmpCommandButtonsTyped = (Button) tmpCommandButtons;
					tmpCommandButtonsTyped.Enabled = true;
				}
				//tmpCommandButtons
				tmpCommandButtons = default(Control);
			}

		}

		// 08/04/2005 - By David D. Cruger; Converted DAO to ADO
		public void Fill_CBO_Contact(int incompid, string comp_name, string contact_email, string contact_first_name, string contact_last_name)
		{

			string Query = "";
			ADORecordSetHelper snpContact = new ADORecordSetHelper();

			try
			{

				cboChooseContact.Items.Clear();

				Query = "SELECT contact_id, contact_first_name, contact_last_name, contact_suffix ";
				Query = $"{Query}FROM Contact (NOLOCK) ";

				if (contact_email.IndexOf('@') >= 0)
				{
					Query = $"{Query} WHERE (contact_email_address like '{contact_email}%') ";
				}
				else if (comp_name.Trim() != "" && incompid == 0)
				{ 
					Query = $"{Query} inner join company with (NOLOCK) on contact_comp_id = comp_id and comp_journ_id = 0 ";
					Query = $"{Query} WHERE (comp_name like '{comp_name}%') ";
				}
				else if (incompid > 0)
				{ 
					Query = $"{Query}WHERE (contact_comp_id = {incompid.ToString()}) ";
				}
				else
				{
					Query = $"{Query}WHERE contact_comp_id > 0 ";
				}

				if (contact_first_name.Trim() != "")
				{
					Query = $"{Query} and contact_first_name like '{contact_first_name}%' ";
				}

				if (contact_last_name.Trim() != "")
				{
					Query = $"{Query} and contact_last_name like '{contact_last_name}%' ";
				}


				Query = $"{Query}AND (contact_journ_id = 0)  AND (contact_active_flag = 'Y') order by contact_last_name asc, contact_first_name asc ";

				snpContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!snpContact.BOF) && (!snpContact.EOF))
				{

					do 
					{ // Loop Until snpContact.EOF = True

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpContact["contact_suffix"]))
						{
							cboChooseContact.AddItem($"{($"{Convert.ToString(snpContact["contact_first_name"])}").Trim()} {($"{Convert.ToString(snpContact["contact_last_name"])} {Convert.ToString(snpContact["contact_suffix"])}").Trim()}");
						}
						else
						{
							cboChooseContact.AddItem($"{($"{Convert.ToString(snpContact["contact_first_name"])}").Trim()} {($"{Convert.ToString(snpContact["contact_last_name"])}").Trim()}");
						}



						cboChooseContact.SetItemData(cboChooseContact.Items.Count - 1, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpContact["contact_id"])}").Trim())));

						snpContact.MoveNext();

					}
					while(!snpContact.EOF);

				} // If (snpContact.BOF = False) And (snpContact.EOF = False) Then

				snpContact.Close();
				snpContact = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_CBO_Contact_Error: {excep.Message}");
			}

		}

		private void Fill_Subscription_Install_Contact_Combo_Box(int lCompId, bool bActiveContatsOnly)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strSirName = "";
			string strFName = "";
			string strMInit = "";
			string strLName = "";
			string strSuffix = "";
			string strContact = "";

			try
			{

				cmbSubInsContact.Items.Clear();

				cmbSubInsContact.AddItem("");
				cmbSubInsContact.SetItemData(cmbSubInsContact.Items.Count - 1, 0);

				strQuery1 = "SELECT contact_id, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, contact_active_flag ";
				strQuery1 = $"{strQuery1}FROM Contact WITH (NOLOCK) WHERE (contact_comp_id = {lCompId.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (contact_journ_id = 0)  AND (contact_first_name IS NOT NULL) ";
				strQuery1 = $"{strQuery1}AND (contact_first_name <> '')  AND (contact_last_name IS NOT NULL) ";
				strQuery1 = $"{strQuery1}AND (contact_last_name <> '')  AND (contact_email_address IS NOT NULL) ";
				strQuery1 = $"{strQuery1}AND (contact_email_address <> '') ";

				if (bActiveContatsOnly)
				{
					strQuery1 = $"{strQuery1}AND (contact_active_flag = 'Y') ";
				}

				strQuery1 = $"{strQuery1}ORDER BY contact_first_name, contact_last_name, contact_suffix ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						strSirName = ($"{Convert.ToString(rstRec1["contact_sirname"])} ").Trim();
						strFName = ($"{Convert.ToString(rstRec1["contact_first_name"])} ").Trim();
						strMInit = ($"{Convert.ToString(rstRec1["contact_middle_initial"])} ").Trim();
						strLName = ($"{Convert.ToString(rstRec1["contact_last_name"])} ").Trim();
						strSuffix = ($"{Convert.ToString(rstRec1["contact_suffix"])} ").Trim();

						strContact = modSubscription.FormatContactName(strSirName, strFName, strMInit, strLName, strSuffix);

						if (($"{Convert.ToString(rstRec1["contact_active_flag"])} ").Trim() == "N")
						{
							strContact = $"{strContact}(Inactive)";
						}
						cmbSubInsContact.AddItem(strContact);
						cmbSubInsContact.SetItemData(cmbSubInsContact.Items.Count - 1, Convert.ToInt32(Double.Parse(Convert.ToString(rstRec1["contact_id"]))));

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_Subscription_Install_Contact_Combo_Box_Error: {excep.Message}");
			}

		} // Fill_Subscription_Install_Contact_Combo_Box

		private void Fill_Company_Info_Panel(int incompid) => modCommon.Build_Company_NameAddress(lst_Company, incompid, 0);


		public void Fill_grd_Subscriptions(int incompid)
		{

			string Query = "";
			ADORecordSetHelper snp_SUB = new ADORecordSetHelper();
			ADORecordSetHelper snp_C = new ADORecordSetHelper();

			int lCurrentSubIdRow = 0;
			string strUserId = "";
			string strSubIdsAllowed = "";
			string strIgnoreSubIdFlag = "";
			int lActive = 0;
			int lInActive = 0;
			object lColor = null;
			int lRows = 0;
			bool bActive = false;

			try
			{


				strUserId = Convert.ToString(modAdminCommon.snp_User["user_id"]).ToUpper(); // Current User
				strSubIdsAllowed = ($"{Convert.ToString(modAdminCommon.snp_User["user_marketing_subids_allowed"])} ").Trim();
				strIgnoreSubIdFlag = ($"{Convert.ToString(modAdminCommon.snp_User["user_ignore_marketing_subids_flag"])} ").Trim();

				cbo_Service.Enabled = false;
				cmbTierLevel.Enabled = false;
				gbMPM = false;

				lblSubLabel[iNOTESLOADING].Text = "Total InActive: 0";

				Set_Count_For_Inactive_Subscriptions();

				Load_Subscription_Grid_Headers();

				Query = "SELECT top 1 sub_start_date FROM Subscription WITH (NOLOCK) ";
				Query = $"{Query}WHERE (sub_comp_id = {incompid.ToString()}) order by sub_start_date asc ";
				snp_SUB.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!snp_SUB.BOF) && (!snp_SUB.EOF))
				{
					do 
					{
						lblSubLabel[5].Text = $"Customer Since: {Convert.ToDateTime(snp_SUB["sub_start_date"]).ToString("MM/dd/yyyy")}";
						snp_SUB.MoveNext();

					}
					while(!snp_SUB.EOF);
				}
				snp_SUB.Close();

				Query = $"SELECT * FROM Subscription WITH (NOLOCK) WHERE (sub_comp_id = {incompid.ToString()}) ";

				if (modSubscription.Entered_Company_ID.ToString() == "135887")
				{ //JETNET LLC account

					switch(strSubIdsAllowed)
					{
						case "NONE" : 
							Query = $"{Query}AND (sub_id = 0) ";  // Will Never Find These 
							break;
						case "ALL" : 
							 
							break;
						default:
							if (strIgnoreSubIdFlag == "N")
							{
								Query = $"{Query}AND (sub_id IN({strSubIdsAllowed})) ";
							} 
							break;
					}

				} // If CStr(Entered_Company_ID) = "135887" Then 'JETNET LLC account

				Query = $"{Query}ORDER BY sub_id";

				snp_SUB.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!snp_SUB.BOF) && (!snp_SUB.EOF))
				{

					fra_Bottom.Visible = true;
					lCurrentSubIdRow = 1;

					lActive = 0;
					lInActive = 0;
					lRows = 0;

					do 
					{ // Loop Until snp_SUB.EOF = True

						lColor = gridCellActiveColor;

						bActive = true;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_SUB["sub_end_date"]))
						{
							if (Convert.ToDateTime(snp_SUB["sub_end_date"]) > DateTime.Now)
							{
								lActive++;
								bActive = true;
							}
							else
							{
								lInActive++;
								lColor = gridCellInActiveColor;
								bActive = false;
							}

						}
						else
						{
							lActive++;
							bActive = true;
						}

						if ((bActive) || (chkIncludeInactive.CheckState == CheckState.Checked && !bActive))
						{

							lRows++;
							grd_Subscriptions.RowsCount = lRows + 1;
							grd_Subscriptions.CurrentRowIndex = lRows;

							grd_Subscriptions.CurrentColumnIndex = 0;
							grd_Subscriptions.CellAlignment = DataGridViewContentAlignment.MiddleRight;
							//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
							grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["sub_id"])}").Trim();

							grd_Subscriptions.CurrentColumnIndex = 1;
							grd_Subscriptions.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
							grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["sub_serv_code"])}").Trim();

							if (($"{Convert.ToString(snp_SUB["sub_serv_code"])} ").Trim() == "CRM" && bActive)
							{
								gbMPM = true;
							}

							grd_Subscriptions.CurrentColumnIndex = 2;
							grd_Subscriptions.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
							grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = ($"{StringsHelper.Replace(Convert.ToString(snp_SUB["sub_service_name"]), "Evolution", "Evo", 1, -1, CompareMethod.Binary)}").Trim();


							grd_Subscriptions.CurrentColumnIndex = 3;
							grd_Subscriptions.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_SUB["sub_start_date"]))
							{
								grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = Convert.ToDateTime(snp_SUB["sub_start_date"]).ToString("MM/dd/yyyy");
							}

							grd_Subscriptions.CurrentColumnIndex = 4;
							grd_Subscriptions.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_SUB["sub_end_date"]))
							{
								grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = Convert.ToDateTime(snp_SUB["sub_end_date"]).ToString("MM/dd/yyyy");
							}

							if (txt_sub_id.Text != "" && Convert.ToInt32(Double.Parse(txt_sub_id.Text)) != 0)
							{
								if (txt_sub_id.Text == Convert.ToString(snp_SUB["sub_id"]))
								{
									lCurrentSubIdRow = grd_Subscriptions.CurrentRowIndex;
								}
							}

						} // If (bActive = True) Or (chkIncludeInactive.Value = vbChecked And bActive = False) Then

						snp_SUB.MoveNext();

					}
					while(!snp_SUB.EOF);

					lblSubLabel[iNOTESLOADING].Text = $"Total InActive: {StringsHelper.Format(lInActive, "#,##0")}";

					grd_Subscriptions.CurrentRowIndex = lCurrentSubIdRow;
					grd_Subscriptions.FirstDisplayedScrollingRowIndex = lCurrentSubIdRow;
					grd_Subscriptions_Click(grd_Subscriptions, new EventArgs());

					Set_WebBrowser_Company_Subscription_Summary();

				}
				else
				{

					grd_Subscriptions.FixedRows = 0;
					grd_Subscriptions.RemoveItem(1);
					grd_Subscriptions.RowsCount = 1;
					fra_Bottom.Visible = false;

					wbSubBrowser1[4].Navigate(new Uri("about:blank")); // Subscription Summary

				} // If (snp_SUB.BOF = False) And (snp_SUB.EOF = False) Then

				snp_SUB.Close();

				snp_C = null;
				snp_SUB = null;

				txt_sub_id.Enabled = false;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_grd_Subscriptions_Error: {excep.Message}");
			}




		} // Fill_grd_Subscriptions

		// 08/04/2005 - By David D. Cruger; Converted DAO to ADO
		public void Fill_grd_Installations(string inLogin)
		{

			string Query = "";
			ADORecordSetHelper snp_SUB = new ADORecordSetHelper();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strSirName = "";
			string strFName = "";
			string strMInit = "";
			string strLName = "";
			string strSuffix = "";
			string strContact = "";

			try
			{

				grd_Installations.Tag = inLogin.Trim();

				Load_Installation_Grid_Headers();

				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				if (modSubscription.gbl_SubID > 0)
				{

					cmd_New_Installation.Enabled = true;
					lblSubAddInstall.Enabled = true;

					strQuery1 = $"SELECT * FROM Subscription_Install WITH (NOLOCK)  WHERE (subins_sub_id = {modSubscription.gbl_SubID.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (subins_login = '{StringsHelper.Replace(inLogin, "'", "''", 1, -1, CompareMethod.Binary)}') ";

					if (InstallationsOrderBy != "")
					{
						strQuery1 = $"{strQuery1}{InstallationsOrderBy}";
					}
					else
					{
						strQuery1 = $"{strQuery1}ORDER BY subins_seq_no ";
					}

					snp_SUB.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!snp_SUB.BOF) && (!snp_SUB.EOF))
					{

						do 
						{ // Loop Until snp_SUB.EOF = True

							grd_Installations.CurrentColumnIndex = 0;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleRight;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["subins_seq_no"])}").Trim();

							grd_Installations.CurrentColumnIndex = 1;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["subins_platform_name"])}").Trim();

							grd_Installations.CurrentColumnIndex = 2;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["subins_platform_os"])}").Trim();

							grd_Installations.CurrentColumnIndex = 3;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_SUB["subins_install_date"]))
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = Convert.ToDateTime(snp_SUB["subins_install_date"]).ToString("MM/dd/yyyy");
							}

							grd_Installations.CurrentColumnIndex = 4;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_SUB["subins_install_date"]))
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = Convert.ToDateTime(snp_SUB["subins_access_date"]).ToString("MM/dd/yyyy HH:mm:ss");
							}

							grd_Installations.CurrentColumnIndex = 5;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							if (($"{Convert.ToString(snp_SUB["subins_active_flag"])}").Trim().ToUpper() == "Y")
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Yes";
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "No";
							}

							grd_Installations.CurrentColumnIndex = 6;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							if (($"{Convert.ToString(snp_SUB["subins_local_db_flag"])}").Trim().ToUpper() == "Y")
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Yes";
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "No";
							}

							// 03/17/2009 - By David D. Cruger; Added
							grd_Installations.CurrentColumnIndex = 7;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							if (($"{Convert.ToString(snp_SUB["subins_display_note_tag_on_aclist_flag"])} ").Trim().ToUpper() == "Y")
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Yes";
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "No";
							}

							grd_Installations.CurrentColumnIndex = 8;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["subins_local_db_file"])}").Trim();

							// 12/03/2002 - By David D. Cruger; Added this field
							grd_Installations.CurrentColumnIndex = 9;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["subins_webpage_timeout"])}").Trim();

							// 03/27/2003 - By David D. Cruger; Added this field
							grd_Installations.CurrentColumnIndex = 10;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							if (($"{Convert.ToString(snp_SUB["subins_activex_flag"])}").Trim().ToUpper() == "Y")
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Yes";
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "No";
							}

							// 11/15/2004 - By David D. Cruger; Added this field
							grd_Installations.CurrentColumnIndex = 11;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							if (($"{Convert.ToString(snp_SUB["subins_autocheck_tservice"])}").Trim().ToUpper() == "Y")
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Yes";
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "No";
							}

							// 11/15/2004 - By David D. Cruger; Added this field
							grd_Installations.CurrentColumnIndex = 12;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							if (($"{Convert.ToString(snp_SUB["subins_terminal_service"])}").Trim().ToUpper() == "Y")
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Yes";
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "No";
							}

							// 03/07/2005 - By David D. Cruger; Added this field
							grd_Installations.CurrentColumnIndex = 13;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["subins_email_replyname"])} ").Trim();

							// 03/07/2005 - By David D. Cruger; Added this field
							grd_Installations.CurrentColumnIndex = 14;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["subins_email_replyaddress"])} ").Trim();

							// 03/07/2005 - By David D. Cruger; Added this field
							grd_Installations.CurrentColumnIndex = 15;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["subins_email_default_format"])} ").Trim();

							// 11/26/2007 - By David D. Cruger - Added
							grd_Installations.CurrentColumnIndex = 16;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleRight;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = StringsHelper.Format(snp_SUB["subins_contract_amount"], "#,###");

							// 06/03/2009 - By David D. Cruger; Added
							grd_Installations.CurrentColumnIndex = 17;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["subins_cell_number"])} ").Trim();

							grd_Installations.CurrentColumnIndex = 18;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "";

							if (Convert.ToDouble(snp_SUB["subins_cell_carrier_id"]) > 0)
							{

								strQuery1 = $"SELECT * FROM SMS_Text_Message_Carrier WITH (NOLOCK) WHERE (smstxtcar_id = {Convert.ToString(snp_SUB["subins_cell_carrier_id"])}) ";

								rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								if ((!rstRec1.BOF) && (!rstRec1.EOF))
								{
									grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = $"{StringsHelper.Format(rstRec1["smstxtcar_id"], "0000")} - {($"{Convert.ToString(rstRec1["smstxtcar_country"])} ").Trim()} - {($"{Convert.ToString(rstRec1["smstxtcar_carrier"])} ").Trim()}";
								}

								rstRec1.Close();

							} // If snp_SUB!subins_cell_carrier_id > 0 Then

							grd_Installations.CurrentColumnIndex = 19;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["subins_smstxt_models"])} ").Trim();

							// 02/10/2010 - By David D. Cruger; Added
							grd_Installations.CurrentColumnIndex = 20;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							switch(($"{Convert.ToString(snp_SUB["subins_smstxt_active_flag"])} ").Trim())
							{
								case "Y" : 
									grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Yes"; 
									break;
								case "N" : 
									grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "No"; 
									break;
								case "A" : 
									grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Activate"; 
									break;
								case "W" : 
									grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Waiting"; 
									break;
								default:
									grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "No"; 
									break;
							}


							grd_Installations.CurrentColumnIndex = 21;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_SUB["subins_mobile_active_date"]))
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = Convert.ToDateTime(snp_SUB["subins_mobile_active_date"]).ToString();
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "";
							}

							// 02/16/2010 - By David D. Cruger;
							grd_Installations.CurrentColumnIndex = 22;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_SUB["subins_default_amod_id"]))
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = Convert.ToString(snp_SUB["subins_default_amod_id"]);
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "0";
							}

							// 02/19/2010 - By David D. Cruger; Added
							grd_Installations.CurrentColumnIndex = 23;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							if (($"{Convert.ToString(snp_SUB["subins_evo_mobile_flag"])} ").Trim().ToUpper() == "Y")
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Yes";
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "No";
							}

							// 03/08/2011 - By David D. Cruger; Added
							grd_Installations.CurrentColumnIndex = 24;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["subins_sms_events"])} ").Trim().ToUpper();

							grd_Installations.CurrentColumnIndex = 25; // Contact Id
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleRight;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "0";

							grd_Installations.CurrentColumnIndex = 26; // Contact Name
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "";

							if (Convert.ToDouble(snp_SUB["subins_contact_id"]) > 0)
							{

								strQuery1 = "SELECT contact_id, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix ";
								strQuery1 = $"{strQuery1}FROM Contact WITH (NOLOCK) WHERE (contact_comp_id = {modSubscription.Entered_Company_ID.ToString()}) ";
								strQuery1 = $"{strQuery1}AND (contact_id = {Convert.ToString(snp_SUB["subins_contact_id"])}) AND (contact_journ_id = 0) ";

								rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								if ((!rstRec1.BOF) && (!rstRec1.EOF))
								{

									strSirName = ($"{Convert.ToString(rstRec1["contact_sirname"])} ").Trim();
									strFName = ($"{Convert.ToString(rstRec1["contact_first_name"])} ").Trim();
									strMInit = ($"{Convert.ToString(rstRec1["contact_middle_initial"])} ").Trim();
									strLName = ($"{Convert.ToString(rstRec1["contact_last_name"])} ").Trim();
									strSuffix = ($"{Convert.ToString(rstRec1["contact_suffix"])} ").Trim();

									strContact = modSubscription.FormatContactName(strSirName, strFName, strMInit, strLName, strSuffix);

									grd_Installations.CurrentColumnIndex = 25; // Contact Id
									grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleRight;
									grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = Convert.ToString(snp_SUB["subins_contact_id"]);

									grd_Installations.CurrentColumnIndex = 26; // Contact Name
									grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
									grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = strContact;

								}
								rstRec1.Close();
							} // If snp_SUB!subins_cell_carrier_id > 0 Then

							grd_Installations.CurrentColumnIndex = 27;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_SUB["subins_last_login_date"]))
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = Convert.ToDateTime(snp_SUB["subins_last_login_date"]).ToString("MM/dd/yyyy HH:mm:ss");
							}

							grd_Installations.CurrentColumnIndex = 28;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_SUB["subins_last_logout_date"]))
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = Convert.ToDateTime(snp_SUB["subins_last_logout_date"]).ToString("MM/dd/yyyy HH:mm:ss");
							}

							grd_Installations.CurrentColumnIndex = 29;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_SUB["subins_last_session_date"]))
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = Convert.ToDateTime(snp_SUB["subins_last_session_date"]).ToString("MM/dd/yyyy HH:mm:ss");
							}

							// 11/06/2012 - By David D. Cruger; Added
							grd_Installations.CurrentColumnIndex = 30;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_SUB["subins_background_image_id"]))
							{
								switch(Convert.ToInt32(snp_SUB["subins_background_image_id"]))
								{
									case 0 :  // Random 
										grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "0 - Random"; 
										break;
									case 17 :  // White 
										grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "17 - White"; 
										break;
									case 18 :  // Light Gray 
										grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "18 - Light Gray"; 
										break;
									case 19 :  // Light Brown 
										grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "19 - Light Brown"; 
										break;
									case 20 :  // Light Blue 
										grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "20 - Light Blue"; 
										break;
									default: // Default 
										grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "0 - Random"; 
										break;
								}
							} // If IsNull(snp_SUB!subins_background_image_id) = False Then

							// 11/08/2012 - By David D. Cruger; Added
							grd_Installations.CurrentColumnIndex = 31;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_SUB["subins_nbr_rec_per_page"]))
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = Convert.ToString(snp_SUB["subins_nbr_rec_per_page"]);
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "10";
							}

							// 07/12/2013 - By David D. Cruger; Added
							grd_Installations.CurrentColumnIndex = 32;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							if (($"{Convert.ToString(snp_SUB["subins_admin_flag"])} ").Trim().ToUpper() == "Y")
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Yes";
								grd_Installations.CurrentColumnIndex = 1;
								grd_Installations.CellForeColor = Color.Red;
								ToolTipMain.SetToolTip(grd_Installations, "SubId Administrator");
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "No";
								grd_Installations.CurrentColumnIndex = 1;
								grd_Installations.CellForeColor = Color.Black;
								ToolTipMain.SetToolTip(grd_Installations, "");
							}

							// 08/22/2014 - By David D. Cruger; Added
							grd_Installations.CurrentColumnIndex = 33;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							if (($"{Convert.ToString(snp_SUB["subins_chat_flag"])} ").Trim().ToUpper() == "Y")
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "Yes";
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "No";
							}

							// 09/22/2015 - By David D. Cruger; Added
							grd_Installations.CurrentColumnIndex = 34;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["subins_business_type_code"])} ").Trim();
							if (grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString() == "")
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "DB";
							}

							// 08/14/2017 - By David D. Cruger; Added
							grd_Installations.CurrentColumnIndex = 35;
							grd_Installations.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_SUB["subins_default_analysis_months"]))
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = Convert.ToString(snp_SUB["subins_default_analysis_months"]);
							}
							else
							{
								grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = "6";
							}


							cmd_New_Installation.Enabled = false; // if there is an install, dont allow them to make another
							lblSubAddInstall.Enabled = false;

							snp_SUB.MoveNext();

							if (!snp_SUB.EOF)
							{
								grd_Installations.RowsCount++;
								grd_Installations.CurrentRowIndex++;
							}

						}
						while(!snp_SUB.EOF);

						grd_Installations.CurrentRowIndex = 1;
						grd_Installations.CurrentColumnIndex = 0;

					}
					else
					{
						grd_Installations.FixedRows = 0;
						grd_Installations.RemoveItem(1);
						grd_Installations.RowsCount = 1;
					} // If (snp_SUB.BOF = False) And (snp_SUB.EOF = False) Then

					snp_SUB.Close();

				} // If gbl_SubID > 0 Then

				rstRec1 = null;
				snp_SUB = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_grd_Installations_Error: {excep.Message}");
			}

		} // Fill_grd_Installations

		// 08/04/2005 - By David D. Cruger; Converted DAO to ADO
		private void Fill_Logins_Grid(string selected_login = "")
		{

			string Query = "";
			ADORecordSetHelper snpLogins = new ADORecordSetHelper();
			string strCurrentLoginName = "";
			int lCurrentRow = 0;
			object lColor = null;
			bool bActive = false;

			try
			{

				strCurrentLoginName = ($"{txtLoginName.Text} ").Trim();
				lCurrentRow = 1;

				cmdIdentifyContact.Enabled = false;
				cmdClearContact.Enabled = false;

				cmdNewLogin.Enabled = true;
				Mode = "";

				Load_Login_Grid_Headers();
				Load_Installation_Grid_Headers();

				Query = "SELECT Subscription_Login.*, (SELECT TOP 1 subins_admin_flag  FROM Subscription_Install WITH (NOLOCK) ";
				Query = $"{Query} WHERE (subins_sub_id = sublogin_sub_id)   AND (subins_login = sublogin_login )  AND (subins_admin_flag = 'Y') ) As AdminFlag ";
				Query = $"{Query}FROM Subscription_Login WITH (NOLOCK) WHERE (sublogin_sub_id = {modSubscription.gbl_SubID.ToString()}) ";

				if (selected_login.Trim() != "")
				{
					Query = $"{Query} and sublogin_login = '{selected_login}' ";
				}

				// 04/25/2018 - By David D. Cruger
				if (chkIncludeInactive.CheckState == CheckState.Unchecked)
				{
					Query = $"{Query}AND (sublogin_active_flag = 'Y') ";
				}

				if (LoginsOrderBy != "")
				{
					Query = $"{Query}{LoginsOrderBy}";
				}
				else
				{
					Query = $"{Query}ORDER BY sublogin_login ";
				}

				snpLogins.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!snpLogins.BOF) && (!snpLogins.EOF))
				{

					do 
					{ // Loop Until snpLogins.EOF = True

						lColor = gridCellActiveColor;
						if (($"{Convert.ToString(snpLogins["sublogin_active_flag"])} ").Trim() == "N")
						{
							lColor = gridCellInActiveColor;
						}

						grd_Logins.CurrentColumnIndex = 0;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = ($"{Convert.ToString(snpLogins["sublogin_login"])}").Trim();

						if (($"{Convert.ToString(snpLogins["AdminFlag"])} ").Trim() == "Y")
						{
							grd_Logins.CellForeColor = Color.Red;
							ToolTipMain.SetToolTip(grd_Logins, "SubId Administrator");
						}
						else
						{
							grd_Logins.CellForeColor = Color.Black;
							ToolTipMain.SetToolTip(grd_Logins, "");
						}

						if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == strCurrentLoginName)
						{
							lCurrentRow = grd_Logins.CurrentRowIndex;
						}

						grd_Logins.CurrentColumnIndex = 1;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = ($"{Convert.ToString(snpLogins["sublogin_password"])}").Trim();
						grd_Logins.CellFontName = "Courier";
						grd_Logins.CellFontBold = true;

						grd_Logins.CurrentColumnIndex = 2;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						if (($"{Convert.ToString(snpLogins["sublogin_active_flag"])}").Trim().ToUpper() == "Y")
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Yes";
						}
						else
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "No";
						}

						grd_Logins.CurrentColumnIndex = 3;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						if (($"{Convert.ToString(snpLogins["sublogin_demo_flag"])}").Trim().ToUpper() == "Y")
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Yes";
						}
						else
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "No";
						}

						grd_Logins.CurrentColumnIndex = 5;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						if (($"{Convert.ToString(snpLogins["sublogin_allow_local_notes_flag"])}").Trim().ToUpper() == "Y")
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Yes";
						}
						else
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "No";
						}

						grd_Logins.CurrentColumnIndex = 6;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						if (($"{Convert.ToString(snpLogins["sublogin_allow_projects_flag"])}").Trim().ToUpper() == "Y")
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Yes";
						}
						else
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "No";
						}

						grd_Logins.CurrentColumnIndex = 7;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						if (($"{Convert.ToString(snpLogins["sublogin_allow_email_request_flag"])}").Trim().ToUpper() == "Y")
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Yes";
						}
						else
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "No";
						}

						grd_Logins.CurrentColumnIndex = 8;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						if (($"{Convert.ToString(snpLogins["sublogin_allow_event_request_flag"])}").Trim().ToUpper() == "Y")
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Yes";
						}
						else
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "No";
						}


						// 11/27/2007 - By David D. Cruger - Added
						grd_Logins.CurrentColumnIndex = 10;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = StringsHelper.Format(snpLogins["sublogin_contract_amount"], "#,###");
						if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "")
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "0";
						}

						// 06/03/2009 - By David D. Cruger; Added
						grd_Logins.CurrentColumnIndex = 11;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						if (($"{Convert.ToString(snpLogins["sublogin_allow_text_message_flag"])}").Trim().ToUpper() == "Y")
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Yes";
						}
						else
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "No";
						}


						// 09/20/2019 - By David D. Cruger; Added
						grd_Logins.CurrentColumnIndex = 13;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						if (($"{Convert.ToString(snpLogins["sublogin_values_flag"])}").Trim().ToUpper() == "Y")
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Yes";
						}
						else
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "No";
						}

						// 09/20/2019 - By David D. Cruger; Added
						grd_Logins.CurrentColumnIndex = 14;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						if (($"{Convert.ToString(snpLogins["sublogin_mpm_flag"])}").Trim().ToUpper() == "Y")
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "Yes";
						}
						else
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "No";
						}

						// added MSW - 9/14/21
						grd_Logins.CurrentColumnIndex = 15;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = StringsHelper.Format(snpLogins["sublogin_billed_amount"], "#,###");
						if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "")
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "0";
						}

						// added MSW - 12/4/23
						grd_Logins.CurrentColumnIndex = 16;
						grd_Logins.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Logins.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
						grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = StringsHelper.Format(snpLogins["sublogin_build"], "#,###");
						if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "")
						{
							grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].Value = "0";
						}


						grd_Logins.set_RowData(grd_Logins.CurrentRowIndex, Convert.ToInt32(Double.Parse(($"0{Convert.ToString(snpLogins["sublogin_contact_id"])}").Trim())));

						snpLogins.MoveNext();

						if (!snpLogins.EOF)
						{
							grd_Logins.RowsCount++;
							grd_Logins.CurrentRowIndex++;
						}

					}
					while(!snpLogins.EOF);

					grd_Logins.CurrentRowIndex = lCurrentRow;
					grd_Logins.FirstDisplayedScrollingRowIndex = lCurrentRow;
					grd_Logins.CurrentColumnIndex = 0;
					grd_Logins.ColSel = grd_Logins.ColumnsCount - 1;

				}
				else
				{

					grd_Logins.FixedRows = 0;
					grd_Logins.RemoveItem(1);
					grd_Logins.RowsCount = 1;

					grd_Installations.FixedRows = 0;
					grd_Installations.RemoveItem(1);
					grd_Installations.RowsCount = 1;

				} // If (snpLogins.BOF = False) And (snpLogins.EOF = False) Then

				snpLogins.Close();
				snpLogins = null;

				grd_Logins_Click(grd_Logins, new EventArgs());

				RememberLoginPosition = 0;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_Logins_Grid_Error: {excep.Message}");
			}

		} // Fill_Logins_Grid

		// 08/04/2005 - By David D. Cruger; Converted DAO to ADO
		private void Check_Logins_Grid(DbConnection cntConn, int incompid, int sub_id, ref int lCnt1_ext)
		{

			string Query = "";
			ADORecordSetHelper snpLogins = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();

			string strCurrentLoginName = "";
			int lCurrentRow = 0;
			int lColor = 0;
			bool bActive = false;
			string temp_user_email = "";
			string strEMail = "";
			string strQuery2 = "";
			int lCnt1 = 0;
			string sublogin_mpm_flag = "N";
			string sublogin_login = "";
			string temp_update_string = "";

			try
			{

				strCurrentLoginName = ($"{txtLoginName.Text} ").Trim();
				lCurrentRow = 1;

				cmdIdentifyContact.Enabled = false;
				cmdClearContact.Enabled = false;

				cmdNewLogin.Enabled = true;
				Mode = "";
				lCnt1 = 0;


				Query = "SELECT distinct Subscription_Login.*, sublogin_email as contact_email_address, (SELECT TOP 1 subins_admin_flag ";
				Query = $"{Query} FROM Subscription_Install WITH (NOLOCK)  WHERE (subins_sub_id = sublogin_sub_id) ";
				Query = $"{Query} AND (subins_login = sublogin_login )   AND (subins_admin_flag = 'Y') ) As AdminFlag ";
				Query = $"{Query} FROM Subscription_Login WITH (NOLOCK)  inner join Subscription_Install with (NOLOCK) on subins_login = sublogin_login  and subins_sub_id = sublogin_sub_id  ";
				//Query = Query & " inner join contact with(NOLOCK) on contact_journ_id = 0 and contact_id = subins_contact_id and contact_active_flag = 'Y' "

				if (incompid > 0 && sub_id > 0)
				{
					Query = $"{Query}WHERE (sublogin_sub_id = {sub_id.ToString()}) "; // (contact_comp_id = " & incompid & ") and
				}
				else if (incompid > 0 && sub_id == 0)
				{ 
					Query = $"{Query}WHERE (sublogin_comp_id = {incompid.ToString()}) ";
				}
				else
				{
					Query = $"{Query}WHERE (sublogin_sub_id = {sub_id.ToString()}) ";
				}


				Query = $"{Query}AND (sublogin_active_flag = 'Y') ";

				if (LoginsOrderBy != "")
				{
					Query = $"{Query}{LoginsOrderBy}";
				}
				else
				{
					Query = $"{Query}ORDER BY sublogin_login ";
				}

				snpLogins.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!snpLogins.BOF) && (!snpLogins.EOF))
				{

					do 
					{ // Loop Until snpLogins.EOF = True


						//grd_Logins.Text = Trim("" & snpLogins!sublogin_login)

						//      grd_Logins_Click
						temp_user_email = Convert.ToString(snpLogins["contact_email_address"]);
						sublogin_mpm_flag = Convert.ToString(snpLogins["sublogin_mpm_flag"]);
						sublogin_login = Convert.ToString(snpLogins["sublogin_login"]);
						strEMail = "";

						strQuery2 = "SELECT cliuser_password, cliuser_active_flag ,cliuser_first_name , cliuser_last_name, cliuser_email_address  ";
						strQuery2 = $"{strQuery2} From client_user  where cliuser_email_address = '{temp_user_email}' ";
						strQuery2 = $"{strQuery2} and cliuser_password <> '' and cliuser_active_flag = 'Y' ";

						rstRec2.CursorLocation = CursorLocationEnum.adUseClient;
						rstRec2.Open(strQuery2, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);
						if ((!rstRec2.BOF) && (!rstRec2.EOF))
						{

							do 
							{

								lCnt1++;

								strEMail = ($"{Convert.ToString(rstRec2["cliuser_email_address"])} ").Trim();


								rstRec2.MoveNext();
								Application.DoEvents();

							}
							while(!rstRec2.EOF);
						}
						rstRec2.Close();

						if (sublogin_mpm_flag.Trim() == "Y")
						{
							lCnt1_ext = lCnt1;
						}

						// if we have mpm and dont find it - then popup
						if (sublogin_mpm_flag.Trim() == "Y" && strEMail.Trim() == "")
						{
							//MsgBox ("User '" & Trim(temp_user_email) & "' Is Turned on, But Should not be.")
							Application.DoEvents();
							temp_update_string = $"Update Subscription_Login set sublogin_mpm_flag = 'N', sublogin_action_date = NULL where sublogin_sub_id = {sub_id.ToString()} and sublogin_login ='{sublogin_login.Trim()}' AND sublogin_active_flag = 'Y' ";

							run_subscription_updater(temp_update_string, -5, sub_id);

							// if we find a valid email and it is a no then we should turn on
						}
						else if (strEMail.Trim() != "" && sublogin_mpm_flag.Trim() == "N")
						{ 
							Application.DoEvents();

							temp_update_string = $"Update Subscription_Login set sublogin_mpm_flag = 'Y', sublogin_action_date = NULL where sublogin_sub_id = {sub_id.ToString()} and sublogin_login ='{sublogin_login.Trim()}' AND sublogin_active_flag = 'Y' ";


							run_subscription_updater(temp_update_string, -5, sub_id);
						}

						snpLogins.MoveNext();

					}
					while(!snpLogins.EOF);


				}
				else
				{


				} // If (snpLogins.BOF = False) And (snpLogins.EOF = False) Then

				snpLogins.Close();
				snpLogins = null;

				// if sub_id = gbl_sub_id , then we need to see if its different, to update

				if (sub_id == modSubscription.gbl_SubID)
				{ //if its the record we clicked on, or mpm record, then only update if changed
					if (txt_SubNbrOfInstalls[2].Text.Trim() != lCnt1.ToString().Trim())
					{ //else 'if its changed ,then
						temp_update_string = $"Update subscription set sub_mpm_nbr_installs = {lCnt1.ToString()}, sub_action_date = '1/1/1900' where sub_id = {sub_id.ToString()} ";
						// MsgBox (temp_update_string)
						run_subscription_updater(temp_update_string, lCnt1, sub_id);
					}
				}
				else
				{
					temp_update_string = $"Update subscription set sub_mpm_nbr_installs = {lCnt1.ToString()}, sub_action_date = '1/1/1900' where sub_id = {sub_id.ToString()} ";
					// MsgBox (temp_update_string)
					run_subscription_updater(temp_update_string, lCnt1, sub_id);
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_Logins_Grid_Error: {excep.Message}");
			}


		} // Fill_Logins_Grid


		// 08/04/2005 - By David D. Cruger; Converted DAO to ADO
		private int GetNextSeqNo(string inLogin)
		{

			int result = 0;
			string Query = "";
			ADORecordSetHelper snpNextSeq = new ADORecordSetHelper();

			try
			{

				result = 1;

				Query = "SELECT Max(subins_seq_no) AS maxSeqNo FROM Subscription_Install WITH (NOLOCK) ";
				Query = $"{Query}WHERE (subins_sub_id = {modSubscription.gbl_SubID.ToString()}) AND (subins_login = '{modAdminCommon.Fix_Quote(inLogin).Trim()}') ";

				snpNextSeq.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!snpNextSeq.BOF) && (!snpNextSeq.EOF))
				{
					result = Convert.ToInt32(Conversion.Val(($"{Convert.ToString(snpNextSeq["maxSeqNo"])}").Trim()) + 1);
				}

				snpNextSeq.Close();
				snpNextSeq = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"GetNextSeqNo_Error: {excep.Message}");
			}

			return result;
		}

		// 08/04/2005 - By David D. Cruger; Converted DAO to ADO
		//UPGRADE_NOTE: (7001) The following declaration (GetNextSubID) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private int GetNextSubID()
		//{
			//
			//int result = 0;
			//string Query = "";
			//ADORecordSetHelper snpNextID = new ADORecordSetHelper();
			//
			//try
			//{
				//
				//result = 1;
				//
				//Query = "SELECT Max(sub_id) as MaxID  FROM Subscription WITH (NOLOCK) ";
				//
				//snpNextID.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				//
				//if ((!snpNextID.BOF) && (!snpNextID.EOF))
				//{
					//result = Convert.ToInt32(Conversion.Val(($"{Convert.ToString(snpNextID["MaxId"])}").Trim()) + 1);
				//}
				//
				//snpNextID.Close();
				//snpNextID = null;
			//}
			//catch (System.Exception excep)
			//{
				//
				//modAdminCommon.Report_Error($"GetNextSubId_Error: {excep.Message}");
			//}
			//
			//return result;
		//}

		public void run_subscription_updater(string temp_query, int num_installs, int sub_id)
		{

			string temp_string = "";
			bool continue_insert = false;

			if (temp_query.ToLower().Trim().IndexOf("update subscription set") >= 0)
			{
				// temp_string = right(Trim(LCase(temp_query)), Len(Trim(LCase(temp_query))) - InStr(Trim(LCase(temp_query)), "where") + 1)

				if (num_installs == -5)
				{ // then its a mpm flag update
					continue_insert = true;
				}
				else
				{
					if (modAdminCommon.Exist($"select top 1 * from subscription where sub_id = {sub_id.ToString()} and sub_mpm_nbr_installs = {num_installs.ToString()} "))
					{
						//   then the subscription record already exists as is
						continue_insert = false;
					}
					else
					{
						continue_insert = true;
					}
				}

			}
			else if (temp_query.ToLower().Trim().IndexOf("update subscription_login set") >= 0)
			{ 
				// temp_string = right(Trim(LCase(temp_query)), Len(Trim(LCase(temp_query))) - InStr(Trim(LCase(temp_query)), "where") + 1)
				continue_insert = true;
			}


			if (!continue_insert)
			{

			}
			else
			{
				// if its on test, then actually run the update
				if (modAdminCommon.LOCAL_ADO_DB.ConnectionString.IndexOf(".56") >= 0)
				{
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = temp_query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = temp_query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
				}
				chkProductType[12].ForeColor = Color.Red; // updated to turn red when an update is run
			}



		}

		public void turn_on_off_items_frontegg()
		{

			//      If chkProductType(13).Value = vbChecked Then
			//         txt_sub_password.Enabled = False
			//         txtLoginName.Enabled = False
			//          cmdEMailSubNotice.Enabled = False
			//         cmdGeneratePassword.Enabled = False
			//      Else
			//         txt_sub_password.Enabled = True
			//         txtLoginName.Enabled = True
			//         cmdEMailSubNotice.Enabled = True
			//        cmdGeneratePassword.Enabled = True
			//      End If

		}

		private void UpdateActionDate()
		{


			string Query = $"UPDATE Subscription  SET sub_action_date = '01/01/1900' WHERE (sub_id = {modSubscription.gbl_SubID.ToString()})";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery(); //aey 6/21/04

		}


		private void UploadSubscription()
		{

			string strQuery1 = "";
			StringBuilder strUpdate1 = new StringBuilder();
			string strDelete1 = "";
			string strAdd1 = "";

			ADORecordSetHelper adoSub = new ADORecordSetHelper();
			ADORecordSetHelper adoEvo = new ADORecordSetHelper();
			ADORecordSetHelper adoInstall = new ADORecordSetHelper();
			ADORecordSetHelper adoLogin = new ADORecordSetHelper();
			ADORecordSetHelper adoRemote = new ADORecordSetHelper();
			ADORecordSetHelper adoTemp = new ADORecordSetHelper();

			ADORecordSetHelper rstAddSub = new ADORecordSetHelper();
			ADORecordSetHelper rstAddLogin = new ADORecordSetHelper();
			ADORecordSetHelper rstAddInstall = new ADORecordSetHelper();

			string strSubId = "";
			string strCloudNotesFlag1 = "";
			string strCloudNotesFlag2 = "";
			string strCloudNotesDatabase1 = "";
			string strCloudNotesDatabase2 = "";
			string strCellNbr = "";

			int iPos1 = 0;
			int lSubId = 0;
			string strErrDesc = "";

			//Dim Num_Embedded As Long  'aey 6/20/05 project global

			System.DateTime dtMobileActiveDate1 = DateTime.FromOADate(0);
			System.DateTime dtMobileActiveDate2 = DateTime.FromOADate(0);

			try
			{

				modSubscription.search_on("Updating Website...", "Opening Remote Database");

				if (modSubscription.OpenRemoteDatabase())
				{

					modSubscription.search_on("Updating Website...", "Reading All Subscriptions To Transmit");

					strQuery1 = "SELECT * FROM Subscription WHERE (sub_action_date IS NULL OR sub_action_date = '01/01/1900')  ORDER BY sub_id ";


					adoSub.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					if ((!adoSub.BOF) && (!adoSub.EOF))
					{

						modSubscription.search_on("Creating Remote Add Recordsets", "Subscription");

						strAdd1 = "SELECT * FROM Subscription WHERE (sub_id = -1)";
						rstAddSub.Open(strAdd1, REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

						modSubscription.search_on("Creating Remote Add Recordsets", "Subscription Login");

						strAdd1 = "SELECT * FROM Subscription_Login WHERE (sublogin_sub_id = -1)";
						rstAddLogin.Open(strAdd1, REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

						modSubscription.search_on("Creating Remote Add Recordsets", "Subscription Install");

						strAdd1 = "SELECT * FROM Subscription_Install WHERE (subins_sub_id = -1)";
						rstAddInstall.Open(strAdd1, REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);


						do 
						{ // Loop Until adoSub.EOF = True

							lSubId = Convert.ToInt32(Double.Parse(($"{Convert.ToString(adoSub["sub_id"])}").Trim()));
							strSubId = lSubId.ToString();

							strCloudNotesFlag1 = ($"{Convert.ToString(adoSub["sub_cloud_notes_flag"])} ").Trim();
							strCloudNotesDatabase1 = ($"{Convert.ToString(adoSub["sub_cloud_notes_database"])} ").Trim();

							//        strQuery1 = "SELECT * FROM Subscription WITH (NOLOCK) WHERE (sub_id = " & strSubId & ") "
							//        strQuery1 = strQuery1 & "AND (sub_web_action_date IS NULL OR sub_web_action_date = '01/01/1900') "
							//
							//        adoEvo.Open strQuery1, REMOTE_ADO_DB, adOpenStatic, adLockReadOnly, adCmdText
							//
							//        If (adoEvo.BOF = False) And (adoEvo.EOF = False) Then
							//
							//          strCloudNotesFlag2 = Trim(adoEvo!sub_cloud_notes_flag & " ")
							//          strCloudNotesDatabase2 = Trim(adoEvo!sub_cloud_notes_database & " ")
							//
							//          If (strCloudNotesFlag1 <> strCloudNotesFlag2) Or (strCloudNotesDatabase1 <> strCloudNotesDatabase2) Then
							//            If InStr(1, strCloudNotesDatabase2, "<script") = 0 Then
							//              adoSub!sub_cloud_notes_flag = left(strCloudNotesFlag2, 1)
							//              iPos1 = InStr(1, strCloudNotesDatabase2, " - ")
							//              If iPos1 > 0 Then
							//                strCloudNotesDatabase2 = Trim(left(strCloudNotesDatabase2, iPos1)) ' Removes Company Name
							//              End If
							//              adoSub!sub_cloud_notes_database = strCloudNotesDatabase2
							//              adoSub!sub_web_action_date = Date
							//              adoSub.UpdateBatch
							//            End If
							//          End If
							//
							//        End If ' If (adoEvo.BOF = False) And (adoEvo.EOF = False) Then
							//
							//        adoEvo.Close

							//'''--------------------------------------------------
							//' DELETING AND RE_ENTERING SUBSCRIPTION ON THE REMOTE - MSW  - 10/9/24
							//        search_on "Deleting Remote Subscription Information", "SubId: " & CStr(lSubId)
							//
							//        strDelete1 = "DELETE FROM Subscription WHERE (sub_id = " & CStr(lSubId) & ") "
							//        REMOTE_ADO_DB.Execute strDelete1, , adCmdText + adExecuteNoRecords
							//
							//        search_on "Adding Remote Subscription", "SubId: " & CStr(lSubId)
							//
							//        rstAddSub.AddNew
							//
							//        For i = 0 To adoSub.fields.Count - 1
							//          rstAddSub.fields(i).Value = adoSub.fields(i).Value
							//        Next i
							//
							//        rstAddSub!sub_action_date = Now()
							//        rstAddSub.UpdateBatch
							//'''-----------------------------------------




							modSubscription.search_on("Finding Local Login Information", $"SubId: {lSubId.ToString()}");

							strQuery1 = $"SELECT * FROM Subscription_Login WITH (NOLOCK) WHERE (sublogin_sub_id = {lSubId.ToString()}) ";

							adoLogin.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							modSubscription.search_on("Deleting Remote Login Information", $"SubId: {lSubId.ToString()}");

							strDelete1 = $"DELETE FROM Subscription_Login WHERE (sublogin_sub_id = {lSubId.ToString()}) ";
							DbCommand TempCommand = null;
							TempCommand = REMOTE_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strDelete1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

							if ((!adoLogin.BOF) && (!adoLogin.EOF))
							{

								do 
								{ // Loop Until adoLogin.EOF = True

									modSubscription.search_on("Adding Remote Login", $"SubId: {lSubId.ToString()} - {($"{Convert.ToString(adoLogin["sublogin_login"])} ").Trim()}");

									rstAddLogin.AddNew();

									int tempForEndVar = adoLogin.FieldsMetadata.Count - 1;
									for (int I = 0; I <= tempForEndVar; I++)
									{
										rstAddLogin[I] = adoLogin[I];
									}

									rstAddLogin.UpdateBatch();

									adoLogin.MoveNext();
									Application.DoEvents();

								}
								while(!adoLogin.EOF);

							} // If (adoLogin.BOF = False) And (adoLogin.EOF = False) Then

							adoLogin.Close();

							modSubscription.search_on("Finding Remote Install and Last Access Date", $"SubId: {lSubId.ToString()}");

							strQuery1 = "SELECT * FROM Subscription_Install ";
							strQuery1 = $"{strQuery1}WHERE (subins_sub_id = {lSubId.ToString()}) ";

							adoTemp.Open(strQuery1, REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

							if ((!adoTemp.BOF) && (!adoTemp.EOF))
							{

								do 
								{ // Loop Until adoTemp.EOF = True

									modSubscription.search_on("Updating Local Install and Last Access Date", $"SubId: {lSubId.ToString()} - {($"{Convert.ToString(adoTemp["subins_login"])}").Trim()} - {Convert.ToString(adoTemp["subins_seq_no"])} - {($"{Convert.ToString(adoTemp["subins_platform_name"])} ").Trim()}");

									strUpdate1 = new StringBuilder("UPDATE Subscription_Install SET subins_install_date = ");
									if (($"{Convert.ToString(adoTemp["subins_install_date"])}").Trim() == "")
									{
										strUpdate1.Append("NULL, ");
									}
									else
									{
										strUpdate1.Append($"'{($"{Convert.ToString(adoTemp["subins_install_date"])}").Trim()}', ");
									}

									strUpdate1.Append("subins_access_date = ");
									if (($"{Convert.ToString(adoTemp["subins_access_date"])}").Trim() == "")
									{
										strUpdate1.Append("NULL, ");
									}
									else
									{
										strUpdate1.Append($"'{($"{Convert.ToString(adoTemp["subins_access_date"])}").Trim()}', ");
									}


									strUpdate1.Append("subins_last_login_date = ");
									if (($"{Convert.ToString(adoTemp["subins_last_login_date"])}").Trim() == "")
									{
										strUpdate1.Append("NULL, ");
									}
									else
									{
										strUpdate1.Append($"'{($"{Convert.ToString(adoTemp["subins_last_login_date"])}").Trim()}', ");
									}

									strUpdate1.Append("subins_last_logout_date = ");
									if (($"{Convert.ToString(adoTemp["subins_last_logout_date"])}").Trim() == "")
									{
										strUpdate1.Append("NULL, ");
									}
									else
									{
										strUpdate1.Append($"'{($"{Convert.ToString(adoTemp["subins_last_logout_date"])}").Trim()}', ");
									}

									strUpdate1.Append("subins_last_session_date = ");
									if (($"{Convert.ToString(adoTemp["subins_last_session_date"])}").Trim() == "")
									{
										strUpdate1.Append("NULL ");
									}
									else
									{
										strUpdate1.Append($"'{($"{Convert.ToString(adoTemp["subins_last_session_date"])}").Trim()}' ");
									}

									strUpdate1.Append($"WHERE (subins_sub_id = {lSubId.ToString()}) ");
									strUpdate1.Append($"AND (subins_login = '{modAdminCommon.Fix_Quote(($"{Convert.ToString(adoTemp["subins_login"])}").Trim())}') ");
									strUpdate1.Append($"AND (subins_seq_no = {Convert.ToString(adoTemp["subins_seq_no"])}) ");

									// 07/10/2003 - By David D. Cruger
									// Added more protection so this account does NOT get updated
									if (Convert.ToDouble(adoSub["sub_id"]) != 1266)
									{ // Research In-House Only
										DbCommand TempCommand_2 = null;
										TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
										TempCommand_2.CommandText = strUpdate1.ToString();
										//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
										//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
										TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
										TempCommand_2.ExecuteNonQuery(); //aey 6/21/04
									}

									adoTemp.MoveNext();
									Application.DoEvents();

								}
								while(!adoTemp.EOF);

							} // If (adoTemp.BOF = False) And (adoTemp.EOF = False) Then

							adoTemp.Close();


							modSubscription.search_on("Finding Local Install Information", $"SubId: {lSubId.ToString()}");

							strQuery1 = $"SELECT * FROM Subscription_Install WHERE (subins_sub_id = {lSubId.ToString()}) ";

							adoInstall.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

							modSubscription.search_on("Deleting Remote Install Information", $"SubId: {lSubId.ToString()}");

							strDelete1 = $"DELETE FROM Subscription_Install WHERE (subins_sub_id = {lSubId.ToString()}) ";
							DbCommand TempCommand_3 = null;
							TempCommand_3 = REMOTE_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
							TempCommand_3.CommandText = strDelete1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_3.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
							TempCommand_3.ExecuteNonQuery();

							if ((!adoInstall.BOF) && (!adoInstall.EOF))
							{

								do 
								{ // Loop Until adoInstall.EOF = True

									modSubscription.search_on("Adding Remote Installation", $"SubId: {lSubId.ToString()} - {($"{Convert.ToString(adoInstall["subins_login"])}").Trim()} - {Convert.ToString(adoInstall["subins_seq_no"])} - {($"{Convert.ToString(adoInstall["subins_platform_name"])} ").Trim()}");

									rstAddInstall.AddNew();

									int tempForEndVar2 = adoInstall.FieldsMetadata.Count - 1;
									for (int I = 0; I <= tempForEndVar2; I++)
									{
										rstAddInstall[I] = adoInstall[I];
									}

									strCellNbr = ($"{Convert.ToString(adoInstall["subins_cell_number"])} ").Trim();
									if (strCellNbr != "")
									{
										strCellNbr = modCommon.CleanUpCellNumber(strCellNbr);
										if (strCellNbr != ($"{Convert.ToString(adoInstall["subins_cell_number"])} ").Trim())
										{
											rstAddInstall["subins_cell_number"] = strCellNbr;
											adoInstall["subins_cell_number"] = strCellNbr;
											adoInstall.UpdateBatch();
										}
									}

									rstAddInstall.UpdateBatch();

									adoInstall.MoveNext();
									Application.DoEvents();

								}
								while(!adoInstall.EOF);

							} // If adoInstall.BOF = False And adoInstall.EOF = False Then

							adoInstall.Close();

							//======================================================================
							// Update Both - HB-Live and Evo-Live
							strUpdate1 = new StringBuilder($"UPDATE Subscription SET sub_action_date = GETDATE() WHERE (sub_id = {lSubId.ToString()}) ");
							DbCommand TempCommand_4 = null;
							TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
							TempCommand_4.CommandText = strUpdate1.ToString();
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_4.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
							TempCommand_4.ExecuteNonQuery();
							DbCommand TempCommand_5 = null;
							TempCommand_5 = REMOTE_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
							TempCommand_5.CommandText = strUpdate1.ToString();
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_5.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
							TempCommand_5.ExecuteNonQuery();

							adoSub.MoveNext();

						}
						while(!adoSub.EOF);

						rstAddInstall.Close();
						rstAddLogin.Close();
						rstAddSub.Close();

						modSubscription.CloseRemoteDatabase();

					} // If (adoSub.BOF = False) And (adoSub.EOF = False) Then

					adoSub.Close();

					modSubscription.search_off();

				} // If OpenRemoteDatabase Then

				modSubscription.CloseRemoteDatabase();

				rstAddInstall = null;
				rstAddLogin = null;
				rstAddSub = null;

				adoEvo = null;
				adoSub = null;
				adoInstall = null;
				adoLogin = null;
				adoRemote = null;
				adoTemp = null;
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;

				modSubscription.CloseRemoteDatabase();

				modSubscription.search_off();

				modAdminCommon.Report_Error($"UploadSubscription_Error: SubId: {lSubId.ToString()}", strErrDesc);

				MessageBox.Show($"UploadSubscription_Error: SubId: {lSubId.ToString()}{Environment.NewLine}{Environment.NewLine}{strErrDesc}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // UploadSubscription_Error

		private bool VerifyLoginAdd()
		{


			bool result = false;
			result = true;

			if (txtLoginName.Text.Trim() == "")
			{
				result = false;
				MessageBox.Show("Login Name Cannot Be Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txtLoginName.Focus();
				return result;
			}

			if (txt_sub_password.Text.Trim() == "")
			{
				result = false;
				MessageBox.Show("Password Cannot Be Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_sub_password.Focus();
				return result;
			}

			string Query = $"SELECT * FROM Subscription_Login WITH (NOLOCK) WHERE (sublogin_sub_id = {modSubscription.gbl_SubID.ToString()}) ";
			Query = $"{Query}AND (sublogin_login = '{modAdminCommon.Fix_Quote(txtLoginName.Text.Trim())}') ";

			if (modAdminCommon.Exist(Query))
			{
				result = false;
				MessageBox.Show("Login Already Exists For This Subscription", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return result;
			}

			return result;
		}

		private bool VerifySubscription()
		{


			bool bResults = true;

			string strMsg = "";

			string strDate = txt_sub_start_date.Text.Trim();
			if (strDate == "" || !Information.IsDate(strDate))
			{
				strMsg = $"Start Date Is Invalid Or Blank{Environment.NewLine}";
				bResults = false;
			}

			if (cbo_Service.SelectedIndex == -1)
			{
				strMsg = $"{strMsg}Service Code must be supplied{Environment.NewLine}";
				bResults = false;
			}

			strDate = txt_sub_end_date.Text.Trim();
			if (strDate != "" && !Information.IsDate(strDate))
			{
				strMsg = $"End Date Is Invalid{Environment.NewLine}";
				bResults = false;
			}

			if (!bResults)
			{
				MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return bResults;

		} // VerifySubscription

		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event cal_sub_end_date.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void cal_sub_end_date_DateClick(System.DateTime DateClicked)
		{

			string strTemp1 = "";

			// 03/12/2003 - By David D. Cruger
			// If someone changes the subscription end date log an event entry
			if (txt_sub_end_date.Text != DateTimeHelper.ToString(cal_sub_end_date.SelectionRange.Start))
			{

				strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] ";
				strTemp1 = $"{strTemp1}SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
				if (txt_sub_end_date.Text == "")
				{
					strTemp1 = $"{strTemp1}From:=[blank]  ";
				}
				else
				{
					strTemp1 = $"{strTemp1}From:=[{txt_sub_end_date.Text}]  ";
				}

				if (DateTimeHelper.ToString(cal_sub_end_date.SelectionRange.Start) == "")
				{
					strTemp1 = $"{strTemp1}To:=[blank]  ";
				}
				else
				{
					strTemp1 = $"{strTemp1}To:=[{DateTimeHelper.ToString(cal_sub_end_date.SelectionRange.Start)}]  ";
				}

				modAdminCommon.Record_Event("Subscription End Date Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);

				txt_sub_end_date.Text = DateTimeHelper.ToString(cal_sub_end_date.SelectionRange.Start);

			}

		}

		private void cal_sub_end_date_Enter(Object eventSender, EventArgs eventArgs) => mvHasFocus = true;


		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event calCallBackDate.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void calCallBackDate_DateClick(System.DateTime DateClicked) => txtCallBackDate.Text = DateTimeHelper.ToString(calCallBackDate.SelectionRange.Start);


		private void calCallBackDate_Enter(Object eventSender, EventArgs eventArgs) => mvHasFocus = true;


		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event cal_sub_start_date.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void cal_sub_start_date_DateClick(System.DateTime DateClicked) => txt_sub_start_date.Text = DateTimeHelper.ToString(cal_sub_start_date.SelectionRange.Start);


		private void cal_sub_start_date_Enter(Object eventSender, EventArgs eventArgs) => mvHasFocus = true;


		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event calSubDocumentDate.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void calSubDocumentDate_DateClick(System.DateTime DateClicked) => txtSubDocumentDate.Text = calSubDocumentDate.SelectionRange.Start.ToString("MM/dd/yyyy");


		private void Set_Expiration_Date_Color()
		{


			txtSubExpirationDate.BackColor = Color.FromArgb(224, 224, 224);
			txtSubExpirationDate.ForeColor = SystemColors.WindowText;
			txtSubExpirationDate.Font = txtSubExpirationDate.Font.Change(bold:false);

			string strDate = txtSubExpirationDate.Text.Trim();

			if (strDate != "")
			{

				if (Information.IsDate(strDate))
				{

					if (DateTime.Parse(strDate) <= DateTime.Now)
					{

						if (DateTime.Parse(strDate) > DateTime.Parse("1/1/1960"))
						{
							txtSubExpirationDate.BackColor = Color.Red;
							txtSubExpirationDate.ForeColor = Color.White;
							txtSubExpirationDate.Font = txtSubExpirationDate.Font.Change(bold:true);
						}

					} // If CDate(strDate) <= Now() Then

				} // If IsDate(strDate) = True Then

			} // If strDate <> "" Then

		} // Set_Expiration_Date_Color

		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event calSubExpirationDate.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void calSubExpirationDate_DateClick(System.DateTime DateClicked)
		{

			txtSubExpirationDate.Text = calSubExpirationDate.SelectionRange.Start.ToString("MM/dd/yyyy");

			Set_Expiration_Date_Color();

		} // calSubExpirationDate_DateClick

		//UPGRADE_WARNING: (2074) ComboBox event cbo_Service.Change was upgraded to cbo_Service.TextChanged which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
		private bool isInitializingComponent;
		private void cbo_Service_TextChanged(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			if (!DoesUserHaveAccess())
			{
				return; // Jump Out
			}
		}

		private void cbo_Service_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			string sub_serv_code = "";

			string strUserId = modAdminCommon.gbl_User_ID.ToUpper();
			string strService = cbo_Service.Text; // OW3J

			if (strService.Trim() != "")
			{
				sub_serv_code = strService.Substring(Math.Max(strService.Length - (Strings.Len(strService) - (strService.IndexOf(" - ") + 1) - 2), 0));
				strService = sub_serv_code;
			}


			string strPart1 = strService.Substring(Math.Min(0, strService.Length), Math.Min(2, Math.Max(0, strService.Length))); // OW // OW
			string strPart2 = strService.Substring(Math.Min(2, strService.Length), Math.Min(1, Math.Max(0, strService.Length - 2))); // 3 // 3
			string strPart3 = strService.Substring(Math.Min(3, strService.Length), Math.Min(1, Math.Max(0, strService.Length - 3))); // J // J

			if (cbo_Service.Enabled)
			{

				// 05/19/2005 - By David D. Cruger
				// Need to Make Sure Service Is Not Blank
				if (cbo_Service.Text != "")
				{

					if (strPart2 == "1")
					{
						cmbTierLevel.Text = "Jets - 1";
					}
					else if ((strPart2 == "2"))
					{ 
						cmbTierLevel.Text = "Turboprops - 2";
					}
					else if ((strPart2 == "3"))
					{ 
						cmbTierLevel.Text = "Jets & Turbos - 3";
					}


					if (strPart3 == "J")
					{
						chkProductType[modSubscription.ProductBusinessAC].CheckState = CheckState.Checked;
						chkProductType[modSubscription.ProductAerodex].CheckState = CheckState.Unchecked;
					}

					if (strPart3 == "H")
					{
						chkProductType[modSubscription.ProductHelicopters].CheckState = CheckState.Checked;
					}

					if (cbo_Service.Text == "STAR")
					{
						chkProductType[modSubscription.ProductStarReports].CheckState = CheckState.Checked;
					}

					if (strPart3 == "C" || strPart3 == "X")
					{
						chkProductType[modSubscription.ProductCommercial].CheckState = CheckState.Checked;
					}

					if (strService != "STAR" && strService != "AVFA")
					{
						if (strPart2 == "A" || strPart3 == "A")
						{
							chkProductType[modSubscription.ProductAerodex].CheckState = CheckState.Checked;
						}
					}

					if (strService == "CRM")
					{
						chkProductType[modSubscription.ProductMPM].CheckState = CheckState.Checked;
					}

					switch(strPart1)
					{
						case "OW" : 
							cmbFrequency.Text = "Live"; 
							break;
						case "DI" : 
							cmbFrequency.Text = "Daily"; 
							break;
						case "WW" : 
							cmbFrequency.Text = "Weekly"; 
							break;
						case "BW" : 
							cmbFrequency.Text = "BiWeekly"; 
							break;
						case "MW" : 
							cmbFrequency.Text = "Monthly"; 
							break;
						case "WB" :  // Web Service 
							cmbFrequency.Text = "Live"; 
							break;
					}

					// Copy Logins Label
					lblSubLabel[iCOPYLOGINS].Visible = false;
					if (modSubscription.IsSubscriptionServiceCodeForSalesForce(strService))
					{
						if (strUserId == "DCR" || strUserId == "AJA" || strUserId == "MVIT")
						{
							lblSubLabel[iCOPYLOGINS].Visible = true;
							lblSubLabel[iCOPYLOGINS].Enabled = true;
						}
					}

				} // If cbo_Service.Text <> "" Then

			} // If cbo_Service.Enabled = True Then

		} // cbo_Service_Click

		private void cboWebReports_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			object objIE = null;
			string strWebSite = "";
			string strCompId = "";
			string strSubId = "";
			string strContactId = "";
			int lCnt1 = 0;
			System.DateTime dtStartTime = DateTime.FromOADate(0);
			int lElapsedTime = 0;
			string strSWRId = "";
			string strFromDate = "";
			string strToDate = "";
			string strLogin = "";
			string strSeqNbr = "";


			if (cboWebReports.Enabled)
			{
				ErrorHandlingHelper.ResumeNext(

					() => {cboWebReports.Enabled = false;}, 
					() => {lblWebReportProcessing.Visible = true;}, 

					() => {Application.DoEvents();}, 

					() => {strCompId = modSubscription.Entered_Company_ID.ToString();}, 
					() => {strSubId = txt_sub_id.Text;}, 
					() => {strContactId = "0";}, 
					() => {strFromDate = DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy");}, 
					() => {strToDate = DateTime.Now.ToString("MM/dd/yyyy");}, 
					() => {strLogin = ($"{txtLoginName.Text} ").Trim();});
				strSeqNbr = "";
				if (txt_Platform_Name.Text != "")
				{
					grd_Installations.CurrentColumnIndex = 0;
					try
					{
						strSeqNbr = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();
					}
					catch
					{
					}
				}

				if ((strCompId != "") && (strCompId != "0"))
				{
					ErrorHandlingHelper.ResumeNext(

						() => {strSWRId = cboWebReports.SelectedIndex.ToString();}, 

						() => {strWebSite = modCommon.DLookUp("swr_url", "Subscription_WebReports", $"(swr_id = {strSWRId})");}, 
						() => {strWebSite = StringsHelper.Replace(strWebSite, "{CompId}", strCompId, 1, -1, CompareMethod.Binary);}, 
						() => {strWebSite = StringsHelper.Replace(strWebSite, "{SubId}", strSubId, 1, -1, CompareMethod.Binary);}, 
						() => {strWebSite = StringsHelper.Replace(strWebSite, "{ContactId}", strContactId, 1, -1, CompareMethod.Binary);}, 
						() => {strWebSite = StringsHelper.Replace(strWebSite, "{FromDate}", strFromDate, 1, -1, CompareMethod.Binary);}, 
						() => {strWebSite = StringsHelper.Replace(strWebSite, "{ToDate}", strToDate, 1, -1, CompareMethod.Binary);}, 
						() => {strWebSite = StringsHelper.Replace(strWebSite, "{Login}", strLogin, 1, -1, CompareMethod.Binary);}, 
						() => {strWebSite = StringsHelper.Replace(strWebSite, "{SeqNbr}", strSeqNbr, 1, -1, CompareMethod.Binary);});

					if (strWebSite == "")
					{
						strWebSite = "about:blank";
					}
					ErrorHandlingHelper.ResumeNext(

						() => {lblWebReportsURL.Tag = strWebSite;}, 
						() => {wbSubBrowser1[2].Navigate(new Uri(strWebSite));}, 

						() => {dtStartTime = DateTime.Now;});
					do 
					{
						ErrorHandlingHelper.ResumeNext(
							() => {lElapsedTime = (int) DateAndTime.DateDiff("s", dtStartTime, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);}, 
							() => {Application.DoEvents();});
					}
					while(!(!wbSubBrowser1[2].IsBusy || lElapsedTime >= 60));

				}
				ErrorHandlingHelper.ResumeNext( // If (strCompId <> "") And (strCompId <> "0") Then

					() => {cboWebReports.Enabled = true;}, 
					() => {lblWebReportProcessing.Visible = false;});

			} // If cboWebReports.Enabled = True Then

		} // cboWebReports_Click

		private void chkAutoCheckTS_CheckStateChanged(Object eventSender, EventArgs eventArgs) => chkTerminalService.Enabled = chkAutoCheckTS.CheckState != CheckState.Checked;


		private void chkCloudNotesFlag_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strQuery2 = "";

			string strEXEC1 = "";
			string strDatabaseName = "";
			string strCNSQLServer = "";
			string strCNSQLUser = "";
			string strCNSQLPassword = "";
			bool bFound = false;
			string strErrMsg = "";
			string strCompId = "";
			string strCompName = "";
			string strTableName = "";

			try
			{

				if (chkCloudNotesFlag.Enabled)
				{

					if (chkServerSideNotes.CheckState == CheckState.Unchecked)
					{

						if (chkCloudNotesFlag.CheckState == CheckState.Checked)
						{

							if (modCommon.Open_Cloud_Notes_Database_Connection(ref cntConn, ref strErrMsg))
							{

								strDatabaseName = $"cloud_notes_{modSubscription.Entered_Company_ID.ToString()}";

								strQuery1 = "SELECT TABLE_NAME  FROM INFORMATION_SCHEMA.TABLES ";
								strQuery1 = $"{strQuery1}WHERE (TABLE_TYPE = 'BASE TABLE') AND (TABLE_NAME LIKE 'cloud_notes_%') ORDER BY TABLE_NAME ";

								rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								bFound = false;
								cmbCloudNotesDatabaseName.Items.Clear();
								cmbCloudNotesDatabaseName.AddItem("");
								rbEvoLocalNotesOverrideCloudNotes.Text = "Overwrite All Cloud Notes";
								rbEvoLocalNotesAppendCloudNotes.Text = "Append Cloud Notes";

								if (!rstRec1.BOF && !rstRec1.EOF)
								{

									do 
									{ // Loop Until rstRec1.EOF = True

										strTableName = ($"{Convert.ToString(rstRec1["TABLE_NAME"])} ").Trim();

										strCompId = StringsHelper.Replace(strTableName, "cloud_notes_", "", 1, -1, CompareMethod.Binary);
										strCompName = modCommon.DLookUp("comp_name", "Company", $"(comp_id = {strCompId}) AND (comp_journ_id = 0)");

										cmbCloudNotesDatabaseName.AddItem($"{strTableName} - {strCompName}");
										if (strDatabaseName == strTableName)
										{
											bFound = true;
											cmbCloudNotesDatabaseName.Text = $"{strTableName} - {strCompName}";
										}

										rstRec1.MoveNext();

									}
									while(!rstRec1.EOF);

								} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

								if (!bFound)
								{

									if (bAutoCreateCloudNotesFlag)
									{
										cmbCloudNotesDatabaseName.Text = strDatabaseName;
										cmbCloudNotesDatabaseName.AddItem(strDatabaseName);
										strEXEC1 = $"EXEC Create_Company_Cloud_Notes_Table '{modSubscription.Entered_Company_ID.ToString()}'";
										DbCommand TempCommand = null;
										TempCommand = cntConn.CreateCommand();
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
										TempCommand.CommandText = strEXEC1;
										//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
										//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
										TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
										TempCommand.ExecuteNonQuery();
										modAdminCommon.Record_Event("Subscription", "Created Cloud Notes Table", 0, 0, modSubscription.Entered_Company_ID);
									}
									else
									{

										if (MessageBox.Show("Evolution Cloud Notes Table Does Not Exist. Create It?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
										{
											cmbCloudNotesDatabaseName.Text = strDatabaseName;
											cmbCloudNotesDatabaseName.AddItem(strDatabaseName);
											strEXEC1 = $"EXEC Create_Company_Cloud_Notes_Table '{modSubscription.Entered_Company_ID.ToString()}'";
											DbCommand TempCommand_2 = null;
											TempCommand_2 = cntConn.CreateCommand();
											UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
											TempCommand_2.CommandText = strEXEC1;
											//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
											TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
											UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
											TempCommand_2.ExecuteNonQuery();
											modAdminCommon.Record_Event("Subscription", "Created Cloud Notes Table", 0, 0, modSubscription.Entered_Company_ID);
											MessageBox.Show("Created Cloud Notes Table", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
										}
										else
										{
											modAdminCommon.Record_Event("Subscription", "Cancelled Creation Of Cloud Notes Table", 0, 0, modSubscription.Entered_Company_ID);
											chkCloudNotesFlag.Enabled = false;
											cmbCloudNotesDatabaseName.Items.Clear();
											cmbCloudNotesDatabaseName.Text = "";
										} // If MsgBox("Cloud Notes Table Does Not Exist.  Create It?", vbYesNo) = vbYes Then

									} // If bAutoCreateCloudNotesFlag = True Then

								} // If (rstRec1.BOF = True Or rstRec1.EOF = True) Then

								rstRec1.Close();

								modCommon.Close_Cloud_Notes_Database_Connection(cntConn, ref strErrMsg);

							}
							else
							{
								MessageBox.Show($"Unable To Open Cloud Notes Database{Environment.NewLine}{strErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If Open_Cloud_Notes_Database_Connection(cntConn, strErrMsg) = True Then

						}
						else
						{
							//cmbCloudNotesDatabaseName.Clear
							//cmbCloudNotesDatabaseName.Text = ""
						} // If chkCloudNotesFlag.Value = vbChecked Then

					}
					else
					{
						chkCloudNotesFlag.Enabled = false;
						chkCloudNotesFlag.CheckState = CheckState.Unchecked;
						chkCloudNotesFlag.Enabled = true;
						MessageBox.Show("Can NOT Turn On Cloud Notes With SSCN Notes Already Checked", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					} // If chkServerSideNotes.Value = vbUnchecked Then

				} // If chkCloudNotesFlag.Enabled = True Then

				//Turn_On_Notes_Import_Panel
				bAutoCreateCloudNotesFlag = false;

				rstRec1 = null;
				cntConn = null;
			}
			catch
			{

				modAdminCommon.Report_Error("chkCloudNotesFlag_Click_Error:");
			}

		} // chkCloudNotesFlag_Click

		private void chkIncludeInactive_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			Load_Service_Combo_Box(cbo_Service);
			Fill_grd_Subscriptions(modSubscription.Entered_Company_ID);

		}

		private void chkInstallAdministrator_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			grd_Logins.CurrentColumnIndex = 0;
			grd_Installations.CurrentColumnIndex = 1;

			if (chkInstallAdministrator.CheckState == CheckState.Checked)
			{
				grd_Logins.CellForeColor = Color.Red;
				grd_Installations.CellForeColor = Color.Red;
				lblSubInsContact.ForeColor = Color.Red; // Red
			}
			else
			{
				grd_Logins.CellForeColor = Color.Black;
				grd_Installations.CellForeColor = Color.Black;
				lblSubInsContact.ForeColor = SystemColors.ControlText; // Black
			} // If chkInstallAdministrator.Value = vbChecked Then

			grd_Logins.CurrentColumnIndex = 0;
			grd_Installations.CurrentColumnIndex = 0;

		}

		private void chkInstallationUseLocalNotes_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkInstallationUseLocalNotes.CheckState == CheckState.Checked)
			{
				txtInstallationPathToLocalDB.Enabled = true;
			}
			else
			{
				txtInstallationPathToLocalDB.Text = "";
				txtInstallationPathToLocalDB.Enabled = false;
				chkInstallationDisplayNoteTag.CheckState = CheckState.Unchecked;
			}

		}



		private void chkLoginFlag_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chkLoginFlag, eventSender);

			if (Index == ((int) modSubscription.iCHKLOGINACTIVE))
			{

			}
			else if (Index == ((int) modSubscription.iCHKLOGINDEMO))
			{ 

				// If Demo is checked then uncheck all other options.
				if (chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState == CheckState.Checked)
				{

					chkLoginFlag[(int) modSubscription.iCHKLOGINEXPORT].CheckState = CheckState.Unchecked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINLOCALNOTES].CheckState = CheckState.Unchecked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINPROJECTS].CheckState = CheckState.Unchecked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINEMAILREQUEST].CheckState = CheckState.Unchecked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].CheckState = CheckState.Unchecked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].Enabled = false;
					chkLoginFlag[(int) modSubscription.iCHKLOGINTEXTMSG].CheckState = CheckState.Unchecked;
					cmdResetDemoLogin.Visible = true;

				}
				else
				{
					cmdResetDemoLogin.Visible = false;
				}

			}
			else if (Index == ((int) modSubscription.iCHKLOGINEXPORT))
			{ 
			}
			else if (Index == ((int) modSubscription.iCHKLOGINLOCALNOTES))
			{ 

				// If Projects is unchecked then uncheck Event Request. It relies on projects.
			}
			else if (Index == ((int) modSubscription.iCHKLOGINPROJECTS))
			{ 
				if (chkLoginFlag[(int) modSubscription.iCHKLOGINPROJECTS].CheckState == CheckState.Checked)
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].Enabled = true;
				}
				else
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].Enabled = false;
					chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].CheckState = CheckState.Unchecked;
				}

			}
			else if (Index == ((int) modSubscription.iCHKLOGINEMAILREQUEST))
			{ 
			}
			else if (Index == ((int) modSubscription.iCHKLOGINEVENTREQUEST))
			{ 
			}
			else if (Index == ((int) modSubscription.iCHKLOGINTEXTMSG))
			{ 
			}
			else if (Index == ((int) modSubscription.iCHKLOGINBYPASSACTIVEX))
			{ 
			}
			else if (Index == ((int) modSubscription.iCHKLOGINVALUES))
			{ 


			}
			else if (Index == ((int) modSubscription.iCHKLOGINMPM))
			{ 
			} // Case Index

		} // chkLoginFlag_Click

		private void chkLoginFlag_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chkLoginFlag, eventSender);
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			// if its the values checkbox
			if (Index == ((int) modSubscription.iCHKLOGINVALUES))
			{
				if (chkProductType[7].CheckState == CheckState.Checked)
				{
				}
				else if (chkLoginFlag[(int) modSubscription.iCHKLOGINVALUES].CheckState == CheckState.Unchecked)
				{  // 0 means that it was unchecked
					// then we cannot add a value to the login
					MessageBox.Show("You cannot add Values to a login where the Subscription Does Not Have Values.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
					chkLoginFlag[(int) modSubscription.iCHKLOGINVALUES].CheckState = CheckState.Unchecked;
				}
			}




		}



		private void chkProductType_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chkProductType, eventSender);


			switch(Index)
			{
				case modSubscription.ProductBusinessAC :  // 0 
					break;
				case modSubscription.ProductHelicopters :  // 1 
					break;
				case modSubscription.ProductABIListing :  // 3 
					break;
				case modSubscription.ProductCommercial :  // 4 
					 
					cmbTierLevel_comm.Visible = chkProductType[4].CheckState == CheckState.Checked; 
					// lblSubLabel(72).Visible = False 
					 
					break;
				case modSubscription.ProductAerodex :  // 5 
					break;
				case modSubscription.ProductStarReports :  // 6 
					break;
				case modSubscription.ProductSPI :  // 7 
					break;
				case modSubscription.ProductMarketing :  // 8 
					 
					if (chkProductType[modSubscription.ProductMarketing].CheckState == CheckState.Checked)
					{
						lblNbrDaysExpire.Visible = true;
						txtNbrDaysExpire.Visible = true;
						txtNbrDaysExpire.Text = "12";
					}
					else
					{
						lblNbrDaysExpire.Visible = false;
						txtNbrDaysExpire.Visible = false;
						txtNbrDaysExpire.Text = "0";
					} 
					 
					break;
				case modSubscription.ShareByCompId :  // 9 
					 
					if (chkProductType[modSubscription.ShareByCompId].CheckState == CheckState.Checked)
					{
						chkProductType[modSubscription.ShareByParentId].CheckState = CheckState.Unchecked;
					} 
					 
					break;
				case modSubscription.ShareByParentId :  // 10 
					 
					if (chkProductType[modSubscription.ShareByParentId].CheckState == CheckState.Checked)
					{
						chkProductType[modSubscription.ShareByCompId].CheckState = CheckState.Unchecked;
					} 
					 
					break;
				case modSubscription.ProductHistory :  // 11 
					 
					break;
				case modSubscription.ProductMPM :  // 12 
					 
					break;
				case 13 :  //- frontegg 
					Application.DoEvents(); 
					 
					turn_on_off_items_frontegg(); 
					 
					break;
			} // Case Index

		} // chkProductType_Click

		private void chkProductType_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chkProductType, eventSender);
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (Index == 7)
			{
				if (chkProductType[7].CheckState == CheckState.Unchecked)
				{
					// then we are picking values, so check to make sure that there is no aerodex
					// if its aerodex, then uncheck values, we cannot have both - 11/1/21
					if (chkProductType[5].CheckState == CheckState.Checked)
					{
						MessageBox.Show("You Cannot Select Values on an Aerodex Subscription", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
						chkProductType[7].CheckState = CheckState.Unchecked;
					}
				}
			}


		}


		private void chkServerSideNotes_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			int lErrNbr = 0;
			string strErrDesc = "";

			DbConnection CRMConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string[] aSubCode = null;
			string[] aToken = null;
			int lCnt1 = 0;

			int lRegId = 0;
			string strRegId = "";
			int lCompId = 0;
			string strCompId = "";
			string strClientName = "";
			string strSubscriptionCode = "";
			string strSubscriptionCodeDecoded = "";
			string strSecurityToken = "";
			string strSecurityTokenDecoded = "";
			string strWebHostName = "";
			string strDBHost = "";
			string strDatabase = "";
			string strUserId = "";
			string strPassword = "";
			int iPos1 = 0;

			try
			{

				strDatabase = ($"{cmbCRMDatabaseName.Text} ").Trim();
				iPos1 = (strDatabase.IndexOf('|') + 1);
				if (iPos1 > 0)
				{
					strDatabase = strDatabase.Substring(Math.Min(iPos1, strDatabase.Length)).Trim(); // Removes Company Name
				}

				strRegId = ($"{txtCRMRegId.Text} ").Trim();
				lRegId = 0;
				if (strRegId != "")
				{
					lRegId = Convert.ToInt32(Double.Parse(strRegId));
				}

				if (chkServerSideNotes.Enabled)
				{

					if (chkCloudNotesFlag.CheckState == CheckState.Unchecked)
					{

						if (chkServerSideNotes.CheckState == CheckState.Checked)
						{

							chkServerSideNotes.Enabled = false;
							cmbCRMDatabaseName.Enabled = false;
							cmbCRMDatabaseName.Items.Clear();

							lblCRMMessage.Text = "Connecting to CRM MySQL Database";

							rbEvoLocalNotesOverrideCloudNotes.Text = "Overwrite All SSCN Notes";
							rbEvoLocalNotesAppendCloudNotes.Text = "Append SSCN Notes";

							if (modCommon.OpenCRMDatabase(ref CRMConn))
							{

								lblCRMMessage.Text = "Getting List Of Client CRM Databases";

								strQuery1 = "SELECT * FROM client_register_master ORDER BY client_regName, client_dbDatabase ";
								rstRec1.Open(strQuery1, CRMConn);

								if ((!rstRec1.BOF) && (!rstRec1.EOF))
								{

									lCnt1 = 0;
									//rstRec1.Open strQuery1, CRMConn, adOpenStatic, adLockReadOnly, adCmdText
									do 
									{ // Loop Until rstRec1.EOF = True

										//---------------------------------------------
										// 11/05/2010 - By David D. Cruger
										// Currently Not Using the SubscriptionCode Or The SecurityToken

										strSubscriptionCode = ($"{Convert.ToString(rstRec1["client_regSubscriptionCode"])} ").Trim();
										strSubscriptionCodeDecoded = modSubscription.Base64_Decode(strSubscriptionCode);
										strSubscriptionCodeDecoded = StringsHelper.Replace(strSubscriptionCodeDecoded, "Subscription Code - ", "", 1, -1, CompareMethod.Binary);
										aSubCode = strSubscriptionCodeDecoded.Split(',');

										strSecurityToken = ($"{Convert.ToString(rstRec1["client_regSecurityToken"])} ").Trim();

										strCompId = "";
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(rstRec1["client_regJetnetCompanyID"]))
										{
											if (Convert.ToDouble(rstRec1["client_regJetnetCompanyID"]) > 0)
											{
												strCompId = Convert.ToString(rstRec1["client_regJetnetCompanyID"]);
											}
										}

										lCnt1++;
										cmbCRMDatabaseName.AddItem($"{($"{Convert.ToString(rstRec1["client_regName"])} ").Trim()} | {($"{Convert.ToString(rstRec1["client_dbDatabase"])} ").Trim()}");
										cmbCRMDatabaseName.SetItemData(lCnt1 - 1, Convert.ToInt32(rstRec1["client_regid"]));

										if (lRegId == Convert.ToDouble(rstRec1["client_regid"]))
										{
											strDatabase = $"{($"{Convert.ToString(rstRec1["client_regName"])} ").Trim()} | {($"{Convert.ToString(rstRec1["client_dbDatabase"])} ").Trim()}";
										}

										rstRec1.MoveNext();

									}
									while(!rstRec1.EOF);

								} // If (rstRec1.BOF=False) And (rstREc1.EOF=False) Then

								rstRec1.Close();

								modCommon.CloseCRMDatabase(ref CRMConn);

								if (strDatabase != "")
								{
									cmbCRMDatabaseName.Text = strDatabase;
								}

							} // If OpenCRMDatabase(CRMConn1) = True Then

							cmbCRMDatabaseName.Enabled = true;
							chkServerSideNotes.Enabled = true;

						} // If chkServerSideNotes.Value = vbChecked Then

					}
					else
					{
						chkServerSideNotes.Enabled = false;
						chkServerSideNotes.CheckState = CheckState.Unchecked;
						chkServerSideNotes.Enabled = true;
						MessageBox.Show("Can NOT Turn On SSCN Notes With Cloud Notes Already Turned On", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					} // If chkCloudNotesFlag.Value = vbUnchecked Then

				} // If chkServerSideNotes.Enabled = True Then

				//Turn_On_Notes_Import_Panel

				lblCRMMessage.Text = "";

				rstRec1 = null;
				CRMConn = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				modAdminCommon.Report_Error($"chkServerSideNotes_Click_Error: {strErrDesc}");

				MessageBox.Show($"Error Server Side Notes{Environment.NewLine}{strErrDesc}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // chkServerSideNotes_Click

		private void cmbCloudNotesDatabaseName_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{


				string strHold = cmbCloudNotesDatabaseName.Text;
				MessageBox.Show($"You Can Not Edit This Combo Box{Environment.NewLine}{Environment.NewLine}You Must Select From The List", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				cmbCloudNotesDatabaseName.Text = strHold;
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

		} // cmbCloudNotesDatabaseName_KeyPress

		private void cmbCloudNotesDatabaseName_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{


				string strHold = cmbCloudNotesDatabaseName.Text;
				MessageBox.Show($"You Can Not Edit This Combo Box{Environment.NewLine}{Environment.NewLine}You Must Select From The List", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				cmbCloudNotesDatabaseName.Text = strHold;
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}

		private void cmbCRMDatabaseName_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{


				string strHold = cmbCRMDatabaseName.Text;
				MessageBox.Show($"You Can Not Edit This Combo Box{Environment.NewLine}{Environment.NewLine}You Must Select From The List", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				cmbCRMDatabaseName.Text = strHold;
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

		private void cmbCRMDatabaseName_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{


				string strHold = cmbCRMDatabaseName.Text;
				MessageBox.Show($"You Can Not Edit This Combo Box{Environment.NewLine}{Environment.NewLine}You Must Select From The List", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				cmbCRMDatabaseName.Text = strHold;
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}

		//UPGRADE_NOTE: (7001) The following declaration (Turn_On_Notes_Import_Panel) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Turn_On_Notes_Import_Panel()
		//{
			//
			//frmImportCloudNotesToCRMSSN.Visible = false;
			//frmImportCRMSSNToCloudNotes.Visible = false;
			//frmImportEvoLocalNotesToCloudNotes.Visible = false;
			//
			////---------------------------------------------------------
			//// Turn On Import Evolution Local Notes To Cloud Notes
			//
			//if (chkCloudNotesFlag.CheckState == CheckState.Checked)
			//{
				//if (cmbCloudNotesDatabaseName.Text != "")
				//{
					//if (chkServerSideNotes.CheckState == CheckState.Unchecked)
					//{
						//if (cmbCRMDatabaseName.Text == "")
						//{
							//if (txtCRMRegId.Text == "0" || txtCRMRegId.Text == "")
							//{
								//frmImportEvoLocalNotesToCloudNotes.Visible = true;
							//}
						//}
					//}
				//}
			//}
			//
			////----------------------------------------------------------
			//// Turn On Import Cloud Notes To Server Side Notes
			//
			//if (chkServerSideNotes.CheckState == CheckState.Checked)
			//{
				//if (cmbCRMDatabaseName.Text != "")
				//{
					//if (txtCRMRegId.Text != "0" && txtCRMRegId.Text != "")
					//{
						//if (chkCloudNotesFlag.CheckState == CheckState.Unchecked)
						//{
							//if (cmbCloudNotesDatabaseName.Text != "")
							//{
								//frmImportCloudNotesToCRMSSN.Visible = true;
							//}
						//}
					//}
				//}
			//}
			//
			////-----------------------------------------------------------
			//// Turn On Import Cloud Notes To CRM Server Side Notes
			//
			//if (chkCloudNotesFlag.CheckState == CheckState.Checked)
			//{
				//if (cmbCloudNotesDatabaseName.Text != "")
				//{
					//if (chkServerSideNotes.CheckState == CheckState.Unchecked)
					//{
						//if (cmbCRMDatabaseName.Text != "")
						//{
							//if (txtCRMRegId.Text != "0" && txtCRMRegId.Text != "")
							//{
								//frmImportCRMSSNToCloudNotes.Visible = true;
							//}
						//}
					//}
				//}
			//}
			//
		//} // Turn_On_Notes_Import_Panel

		private void cmbCRMDatabaseName_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			string strTemp = "";
			string strRegName = "";
			string strDatabase = "";
			string strRegId = "";
			int iPos1 = 0;

			if (($"{cmbCRMDatabaseName.Text} ").Trim() != "")
			{

				if (cmbCRMDatabaseName.Enabled)
				{

					cmbCRMDatabaseName.Enabled = false;

					strTemp = ($"{cmbCRMDatabaseName.Text} ").Trim();
					iPos1 = (strTemp.IndexOf('|') + 1);

					strRegName = ($"{strTemp.Substring(0, Math.Min(iPos1 - 1, strTemp.Length))} ").Trim();
					strDatabase = ($"{strTemp.Substring(Math.Min(iPos1, strTemp.Length))} ").Trim();

					strRegId = cmbCRMDatabaseName.GetItemData(cmbCRMDatabaseName.SelectedIndex).ToString();
					txtCRMRegId.Text = strRegId;

					cmbCRMDatabaseName.Enabled = true;

				} // If cmbCRMDatabaseName.Enabled = True Then

			} // If Trim(cmbCRMDatabaseName.Text & " ") <> "" Then

			//Turn_On_Notes_Import_Panel

		} // cmbCRMDatabaseName_Click

		private void cmbSubDocumentType_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => cmbSubDocumentType.Tag = cmbSubDocumentType.Text.Substring(0, Math.Min(3, cmbSubDocumentType.Text.Length));



		private void cmd_auth_btn_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_auth_btn, eventSender);


			string strUpdate = "";
			if (Index == 0)
			{
				// THIS IS THE SAVE

				if (StringsHelper.ToDoubleSafe(Convert.ToString(chk_auth_status.Tag)) == 1)
				{ // then we had a record

					strUpdate = "Update [EVO_LIVE].jetnet_ra.dbo.Subscription_Login_MFA  set ";

					// status
					if (chk_auth_status.CheckState == CheckState.Checked)
					{
						strUpdate = $"{strUpdate} sublogmfa_authenticate_flag = 'Y', ";
					}
					else
					{
						strUpdate = $"{strUpdate} sublogmfa_authenticate_flag = 'N', ";
					}

					// added MSW - 7/8/22
					strUpdate = $"{strUpdate} sublogmfa_contact_phone = '{txt_auth_phone.Text}', ";

					strUpdate = $"{strUpdate} sublogmfa_authenticate_channel = '{cbo_auth_type.Text}', ";

					strUpdate = $"{strUpdate} sublogmfa_authenticate_last_attempt = NULL,  sublogmfa_authenticate_cycle = '{cbo_auth_cycle.Text}' ";

					strUpdate = $"{strUpdate} WHERE sublogmfa_sub_id = {modSubscription.gbl_SubID.ToString()}  AND sublogmfa_login = '{grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString()}'";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strUpdate;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					lblSubLabel[9].Text = "Authentication Record Updated";

				}
				else
				{
					strUpdate = "insert into [EVO_LIVE].jetnet_ra.dbo.Subscription_Login_MFA ";
					strUpdate = $"{strUpdate}(sublogmfa_authenticate_flag, sublogmfa_authenticate_channel, ";
					strUpdate = $"{strUpdate} sublogmfa_authenticate_last_attempt, sublogmfa_authenticate_cycle, ";
					strUpdate = $"{strUpdate}  sublogmfa_contact_phone,  sublogmfa_sub_id, sublogmfa_login,  sublogmfa_contact_id  ";
					strUpdate = $"{strUpdate}) VALUES (";

					if (chk_auth_status.CheckState == CheckState.Checked)
					{
						strUpdate = $"{strUpdate}'Y', ";
					}
					else
					{
						strUpdate = $"{strUpdate}'N', ";
					}

					strUpdate = $"{strUpdate}'{cbo_auth_type.Text}',   NULL, '{cbo_auth_cycle.Text}', ";


					strUpdate = $"{strUpdate}'{txt_auth_phone.Text}', {modSubscription.gbl_SubID.ToString()}, ";
					strUpdate = $"{strUpdate}'{grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString()}', ";
					if (Information.IsNumeric(cmbSubInsContact.GetItemData(cmbSubInsContact.SelectedIndex).ToString()))
					{
						strUpdate = $"{strUpdate}'{cmbSubInsContact.GetItemData(cmbSubInsContact.SelectedIndex).ToString()}'";
					}
					else
					{
						strUpdate = $"{strUpdate}'0'";
					}


					strUpdate = $"{strUpdate}) ";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = strUpdate;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

					lblSubLabel[9].Text = "Authentication Record Created";
				}


			}
			else if (Index == 1)
			{ 

				//CLEAR BUTTON -------
				strUpdate = "Update [EVO_LIVE].jetnet_ra.dbo.Subscription_Login_MFA  set ";

				strUpdate = $"{strUpdate} sublogmfa_contact_phone = NULL, sublogmfa_authenticate_last_result = NULL, ";
				strUpdate = $"{strUpdate} sublogmfa_authenticate_last_attempt = NULL ";

				strUpdate = $"{strUpdate} WHERE sublogmfa_sub_id = {modSubscription.gbl_SubID.ToString()}  AND sublogmfa_login = '{grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString()}'";

				DbCommand TempCommand_3 = null;
				TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
				TempCommand_3.CommandText = strUpdate;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_3.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
				TempCommand_3.ExecuteNonQuery();

				Get_User_Authentication_Info(grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString(), Convert.ToInt32(Double.Parse(modSubscription.gbl_SubID.ToString())));

				lblSubLabel[9].Text = "Authentication Reset/Cleared";
			}


		}



		private void cmd_find_contact_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_find_contact, eventSender);

			int temp_comp_id = 0;
			string temp_Company_name = "";
			string temp_contact_email = "";
			string temp_contact_first = "";
			string temp_contact_last = "";
			if (Index == 0)
			{

				frm_Subscription.DefInstance.Hide();

				//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].Clear_Search_Criteria(true, true, true);
				//UPGRADE_TODO: (1067) Member cmd_add_to_pub is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].cmd_add_to_pub.Visible = true;
				//UPGRADE_TODO: (1067) Member cmd_Add_contact_trial is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].cmd_Add_contact_trial.Visible = true;
				//UPGRADE_TODO: (1067) Member cmd_Add_contact_trial is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].cmd_Add_contact_trial.Tag = "1";
				//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].Show();
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes
				//UPGRADE_TODO: (1067) Member SetFocus is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].Focus();

			}
			else if (Index == 1)
			{ 

				temp_comp_id = 0;
				temp_Company_name = "";
				temp_contact_email = "";
				temp_contact_first = "";
				temp_contact_last = "";



				if (txt_find_sub[1].Text.IndexOf('@') >= 0)
				{
					temp_contact_email = txt_find_sub[1].Text.Trim();
					temp_contact_first = txt_find_sub[0].Text.Trim();
					temp_contact_last = txt_find_sub[2].Text.Trim();
					Fill_CBO_Contact(0, "", temp_contact_email, temp_contact_first, temp_contact_last);

				}
				else if (Information.IsNumeric(txt_find_sub[1].Text))
				{ 
					temp_comp_id = Convert.ToInt32(Double.Parse(txt_find_sub[1].Text.Trim()));
					temp_contact_first = txt_find_sub[0].Text.Trim();
					temp_contact_last = txt_find_sub[2].Text.Trim();
					Fill_CBO_Contact(temp_comp_id, "", "", temp_contact_first, temp_contact_last);
				}
				else
				{
					temp_contact_first = txt_find_sub[0].Text.Trim();
					temp_contact_last = txt_find_sub[2].Text.Trim();
					temp_Company_name = txt_find_sub[1].Text.Trim();

					Fill_CBO_Contact(0, temp_Company_name, "", temp_contact_first, temp_contact_last);

				}




			}



		}


		private void cmd_InstallCancel_Click(Object eventSender, EventArgs eventArgs)
		{


			// Turn On Frames And Grids
			fra_Add_Installation.Visible = false;
			fra_Add_Installation.Enabled = false;

			frm_Sub_Command.Visible = true;
			frm_Sub_Command.Enabled = true;

			grd_Installations.Enabled = true;
			grd_Installations.Visible = true;
			grd_Installations.BringToFront();

			cmd_New_Installation.Enabled = true;

			string strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();
			// 03/16/2004 - By David D. Cruger allow all
			cmdDeleteInstallation.Enabled = true;

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		//UPGRADE_NOTE: (7001) The following declaration (cmd_Cancel_MouseUp) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmd_Cancel_MouseUp(int Button, int Shift, float X, float Y)
		//{
			//
			//if (mvHasFocus)
			//{
				//mvHasFocus = false;
				//cmd_InstallCancel_Click(cmd_InstallCancel, new EventArgs());
			//}
			//
		//}

		private void cmd_Close_Click(Object eventSender, EventArgs eventArgs)
		{

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

			this.Close();

		}

		private void cmd_Close_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Close_Click(cmd_Close, new EventArgs());
			}

		}

		private void cmd_DeleteLogin_Click(Object eventSender, EventArgs eventArgs)
		{

			string strTemp1 = "";

			int lSavedProjects = 0;
			bool bContinue = false;


			string strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();

			if (MessageBox.Show("Are you sure you want to DELETE this login?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{

				bContinue = true;
				if (modSubscription.Does_User_Install_Have_Any_Saved_Projects(Convert.ToInt32(Double.Parse(txt_sub_id.Text)), tmpLoginName, -1, ref lSavedProjects))
				{
					bContinue = false;
					if (MessageBox.Show($"This Login Has Saved Projects And/Or Folders ({lSavedProjects.ToString()}).{Environment.NewLine}Are You Sure You Want To Delete It?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						bContinue = true;
					}
				}

				if (bContinue)
				{

					// 03/12/2003 - By David D. Cruger
					// If someone removes a subscription login log an event entry
					strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] ";
					strTemp1 = $"{strTemp1}SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
					strTemp1 = $"{strTemp1}Login:=[{tmpLoginName}]  ";

					modAdminCommon.Record_Event("Subscription Login Removed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);

					modSubscription.search_on("Deleting Login and Related Installs...");
					DeleteLogin();
					cmdCancelLoginFrame_Click(cmdCancelLoginFrame, new EventArgs());
					Fill_Logins_Grid();
					UpdateActionDate();

					strAddChgHasHappened = $"{strAddChgHasHappened}A Login Has Been Deleted On SubId: {modSubscription.gbl_SubID.ToString()}{Environment.NewLine}";

				} // If bContinue=True Then

			} // If MsgBox("Are you sure you want to DELETE this login?", vbYesNo) = vbYes Then

			modSubscription.search_off();

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		} // cmd_DeleteLogin_Click

		private void cmd_DeleteLogin_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_DeleteLogin_Click(cmd_DeleteLogin, new EventArgs());
			}

		}

		private void cmd_Move_Subscription_Click()
		{

			DbConnection cntCustConn = null;
			string strErrMsg = "";

			string strSubId = "";
			int lSubId = 0;

			string strCompIdCurr = "";
			int lCompIdCurr = 0;

			string strCompIdNew = "";
			int lCompIdNew = 0;

			string strMatchingContacts = "";
			string strMissingContacts = "";

			string strCompanyNameNew = "";
			string strUpdate1 = "";

			bool bCompleted = false;
			string strCompLockedBy = "";

			int X = 0;
			int Y = 0;

			int lHBNbrChg = 0;
			int lEvoNbrChg = 0;

			string strMsg = "";

			if (MessageBox.Show("Move Subscription To Anther Company Record.  Are You Sure?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{

				strSubId = "0";
				lSubId = 0;
				strCompIdCurr = "0";
				lCompIdCurr = 0;

				lHBNbrChg = 0;
				lEvoNbrChg = 0;

				strSubId = ($"{txt_sub_id.Text} ").Trim();
				if (Information.IsNumeric(strSubId))
				{
					lSubId = Convert.ToInt32(Double.Parse(strSubId));
				}

				lCompIdCurr = modSubscription.Entered_Company_ID;
				strCompIdCurr = lCompIdCurr.ToString();

				if (modSubscription.OpenRemoteDatabase())
				{

					if (modCommon.OpenCustomerSQLDatabase(ref cntCustConn))
					{

						if (modSubscription.Validate_Subscription_Can_Be_Moved(lCompIdCurr, lSubId))
						{

							X = frm_Subscription.DefInstance.Left * 15 + (frm_Subscription.DefInstance.Width * 15 / 2);
							Y = frm_Subscription.DefInstance.Top * 15 + (frm_Subscription.DefInstance.Height * 15 / 2) - 200;
							//strCompIdNew = InputBox("Enter CompId To Move Subscriptions To", "Move To CompId", 0, X, y)
							strCompIdNew = InputBoxHelper.InputBox("Enter CompId To Move Subscriptions To", "Move To CompId", "0", 0, Y / 15);

							if (Information.IsNumeric(strCompIdNew))
							{

								lCompIdNew = Convert.ToInt32(Double.Parse(strCompIdNew));

								//--------------------------------
								strCompanyNameNew = modCommon.DLookUp("comp_name+' - '+COALESCE(comp_city,'')+', '+COALESCE(comp_state,'')+' '+COALESCE(comp_country,'')", "Company", $"(comp_id = {strCompIdNew}) AND (comp_journ_id = 0) AND (comp_active_flag = 'Y')");

								if (strCompanyNameNew != "")
								{

									if (MessageBox.Show($"Is This The Correct New Company?{Environment.NewLine}{strCompanyNameNew}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
									{

										strCompLockedBy = modCommon.DLookUp("complock_user_id", "Company_Lock", $"(complock_comp_id = {lCompIdNew.ToString()})");

										if (strCompLockedBy == "")
										{

											modAdminCommon.Record_Event("Subscription Move", $"Moving SubId:=[{lSubId.ToString()}] From CompIdCurr:=[{lCompIdCurr.ToString()}]  To CompIdNew:=[{lCompIdNew.ToString()}]", 0, 0, lCompIdNew);

											if (modSubscription.Do_All_Subscription_Contacts_Exist_In_New_Company_Record(lCompIdCurr, lCompIdNew, lSubId, ref strMatchingContacts, ref strMissingContacts))
											{

												//------------------------------------------------------
												// This MUST Be Wrapped In A Transaction To Work

												bCompleted = false;

												strErrMsg = "";

												//-- EventLog
												if (modSubscription.Move_All_Subscription_Event_Logs("Homebase", lCompIdCurr, lCompIdNew, lSubId, ref lHBNbrChg, ref strErrMsg))
												{

													//-- EventLog
													if (modSubscription.Move_All_Subscription_Event_Logs("Evolution", lCompIdCurr, lCompIdNew, lSubId, ref lEvoNbrChg, ref strErrMsg))
													{

														//-- Subscription_Install_Log
														if (modSubscription.Move_All_Subscription_Install_Logs("Homebase", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, ref lHBNbrChg, ref strErrMsg))
														{

															//-- Subscription_Install_Log
															if (modSubscription.Move_All_Subscription_Install_Logs("Evolution", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, ref lEvoNbrChg, ref strErrMsg))
															{

																//-- Aircraft Value
																if (modSubscription.Move_All_Aircraft_Value_Records("Homebase", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, ref lHBNbrChg, ref strErrMsg))
																{

																	//-- Aircraft Value
																	if (modSubscription.Move_All_Aircraft_Value_Records("Evolution", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, ref lEvoNbrChg, ref strErrMsg))
																	{

																		//-- Report_Request_DotNet
																		if (modSubscription.Move_All_Subscription_Request_Report_DotNet("Homebase", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, ref lHBNbrChg, ref strErrMsg))
																		{

																			//-- Report_Request_DotNet
																			if (modSubscription.Move_All_Subscription_Request_Report_DotNet("Evolution", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, ref lEvoNbrChg, ref strErrMsg))
																			{

																				//-- Service_Interruption
																				if (modSubscription.Move_All_Service_Interruption_Record("Homebase", lCompIdCurr, lCompIdNew, lSubId, ref lHBNbrChg, ref strErrMsg))
																				{

																					//-- Service_Interruption
																					if (modSubscription.Move_All_SMS_Text_Message_Queue_Records("Homebase", lCompIdCurr, lCompIdNew, lSubId, ref lHBNbrChg, ref strErrMsg))
																					{

																						//-- SMS_Text_Message_Queue
																						if (modSubscription.Move_All_SMS_Text_Message_Queue_Records("Evolution", lCompIdCurr, lCompIdNew, lSubId, ref lEvoNbrChg, ref strErrMsg))
																						{

																							//-- SMS_Text_Message_Queue
																							if (modSubscription.Move_All_SMS_Text_Message_Received_Records("Homebase", lCompIdCurr, lCompIdNew, lSubId, ref lHBNbrChg, ref strErrMsg))
																							{

																								//-- SMS_Text_Message_Received
																								if (modSubscription.Move_All_SMS_Text_Message_Received_Records("Evolution", lCompIdCurr, lCompIdNew, lSubId, ref lEvoNbrChg, ref strErrMsg))
																								{

																									//-- SMS_Text_Message_Received
																									if (modSubscription.Move_All_EMail_Queue_Records("Homebase", lCompIdCurr, lCompIdNew, lSubId, ref lHBNbrChg, ref strErrMsg))
																									{

																										//-- EMail_Queue
																										if (modSubscription.Move_All_EMail_Queue_Records("Evolution", lCompIdCurr, lCompIdNew, lSubId, ref lEvoNbrChg, ref strErrMsg))
																										{

																											//-- EMail_Request
																											if (modSubscription.Move_All_EMail_Request_Records("Homebase", lCompIdCurr, lCompIdNew, lSubId, ref lHBNbrChg, ref strErrMsg))
																											{

																												//-- EMail_Request
																												if (modSubscription.Move_All_EMail_Request_Records("Evolution", lCompIdCurr, lCompIdNew, lSubId, ref lEvoNbrChg, ref strErrMsg))
																												{

																													//-- Subscription_Install
																													if (modSubscription.Move_All_Subscription_Install_With_New_Contact_Id("Homebase", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, ref lHBNbrChg, ref strErrMsg))
																													{

																														//-- Subscription_Install
																														if (modSubscription.Move_All_Subscription_Install_With_New_Contact_Id("Evolution", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, ref lEvoNbrChg, ref strErrMsg))
																														{

																															//-- Subscription
																															if (modSubscription.Move_All_Subscription_Record("Homebase", lCompIdCurr, lCompIdNew, lSubId, ref lHBNbrChg, ref strErrMsg))
																															{

																																//-- Subscription
																																if (modSubscription.Move_All_Subscription_Record("Evolution", lCompIdCurr, lCompIdNew, lSubId, ref lEvoNbrChg, ref strErrMsg))
																																{

																																	//-- Customer_Main and Customer_Contact
																																	if (modSubscription.Update_Customer_Main_And_Contact_Record(cntCustConn, lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, ref strErrMsg))
																																	{

																																		strMsg = $"SubId:=[{lSubId.ToString()}] From CompIdCurr:=[{lCompIdCurr.ToString()}]  To CompIdNew:=[{lCompIdNew.ToString()}] Company Name:={strCompanyNameNew}";

																																		modSubscription.AddSubscriptionNote(lCompIdNew, lSubId, "Move Subscription", strMsg);
																																		modSubscription.AddCustomerActivityRecord(lSubId, $"Move Subscription {strMsg}");

																																		New_Subscription(); // Clears Form
																																		Fill_grd_Subscriptions(lCompIdCurr);
																																		bCompleted = true;

																																	} // If Update_Customer_Main_And_Contact_Record(cntCustConn, lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, strErrMsg) = True Then

																																} // If Move_All_Subscription_Record("Evolution", lCompIdCurr, lCompIdNew, lSubId, lEvoNbrChg, strErrMsg) = True Then

																															} // If Move_All_Subscription_Record("Evolution", lCompIdCurr, lCompIdNew, lSubId, lEvoNbrChg, strErrMsg) = True Then

																														} // If Move_All_Subscription_Install_With_New_Contact_Id("Evolution", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, lEvoNbrChg, strErrMsg) = True Then

																													} //If Move_All_Subscription_Install_With_New_Contact_Id("Homebase", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, lHBNbrChg, strErrMsg) = True Then

																												} // If Move_All_EMail_Request_Records("Evolution", lCompIdCurr, lCompIdNew, lSubId, lEvoNbrChg, strErrMsg) = True Then

																											} // If Move_All_EMail_Requset_Records("Homebase", lCompIdCurr, lCompIdNew, lSubId, lEvoNbrChg, strErrMsg) = True Then

																										} // If Move_All_EMail_Queue_Records("Evolution", lCompIdCurr, lCompIdNew, lSubId, lEvoNbrChg, strErrMsg) = True Then

																									} // If Move_All_EMail_Queue_Records("Homebase", lCompIdCurr, lCompIdNew, lSubId, lEvoNbrChg, strErrMsg) = True Then

																								} // If Move_All_SMS_Text_Message_Received_Records("Evolution", lCompIdCurr, lCompIdNew, lSubId, lEvoNbrChg, strErrMsg) = True Then

																							} // If Move_All_SMS_Text_Message_Received_Records("Homebase", lCompIdCurr, lCompIdNew, lSubId, lEvoNbrChg, strErrMsg) = True Then

																						} // If Move_All_SMS_Text_Message_Queue_Records("Evolution", lCompIdCurr, lCompIdNew, lSubId, lEvoNbrChg, strErrMsg) = True Then

																					} // If Move_All_SMS_Text_Message_Queue_Records("Homebase", lCompIdCurr, lCompIdNew, lSubId, lEvoNbrChg, strErrMsg) = True Then

																				} // If Move_All_Subscription_Request_Report_DotNet("Evolution", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, lEvoNbrChg, strErrMsg) = True Then

																			} // If Move_All_Service_Interruption_Record("Homebase", lCompIdCurr, lCompIdNew, lSubId, lEvoNbrChg, strErrMsg) = True Then

																		} // If Move_All_Subscription_Request_Report_DotNet("Homebase", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, lHBNbrChg, strErrMsg) = True Then

																	} // If Move_All_Aircraft_Value_Records("Evolution", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, lEvoNbrChg, strErrMsg) = True Then

																} // If Move_All_Aircraft_Value_Records("Homebase", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, lHBNbrChg, strErrMsg) = True Then

															} // If Move_All_Subscription_Install_Logs("Evolution", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, lEvoNbrChg, strErrMsg) = True Then

														} // If Move_All_Subscription_Install_Logs("Homebase", lCompIdCurr, lCompIdNew, lSubId, strMatchingContacts, lHBNbrChg, strErrMsg) = True Then

													} // If Move_All_Subscription_Event_Logs("Evolution", lCompIdCurr, lCompIdNew, lSubId, lEvoNbrChg, strErrMsg) = True Then

												} // If Move_All_Subscription_Event_Logs("Homebase", lCompIdCurr, lCompIdNew, lSubId, lHBNbrChg, strErrMsg) = True Then

												if (bCompleted)
												{
													modAdminCommon.Record_Event("Subscription Move", $"Completed{strErrMsg}", 0, 0, lCompIdNew);
													MessageBox.Show($"Process Completed{Environment.NewLine}Subscription Has Been Moved", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
												}
												else
												{
													modAdminCommon.Record_Event("Subscription Move", $"Failed: {strErrMsg}", 0, 0, lCompIdNew);
													MessageBox.Show(strErrMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												}

											}
											else
											{
												MessageBox.Show($"Not All Subscription Contacts Exist In The New Company Record{Environment.NewLine}Can NOT Move{Environment.NewLine}{Environment.NewLine}{strMissingContacts}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											} // If Do_All_Subscription_Contacts_Exist_In_New_Company_Record(lCompIdCurr, lSubId, strMatchingContacts, strMissingContacts) = True Then

										}
										else
										{
											MessageBox.Show($"New Company Record Is Currently Locked By: {strCompLockedBy}{Environment.NewLine}Can NOT Move", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										} // If strCompLockedBy = "" Then

									}
									else
									{
										MessageBox.Show("Wrong Company.  Move Cancelled", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									} // If MsgBox("Is This The Correct New Company?" & vbCrLf & strCompanyNameNew, vbYesNo) = vbYes Then

								}
								else
								{
									MessageBox.Show($"Could NOT Find Active Company Record For New Company Id [{strCompIdNew}]{Environment.NewLine}Can NOT Move", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If Does_New_CompId_Have_A_Valid_Company_Record(lCompIdNew, strCompanyNameNew) = True Then

							}
							else
							{
								MessageBox.Show($"Value Entered For New Company Id Is Not Numeric{Environment.NewLine}Can NOT Move", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If IsNumeric(strCompIdNew) = True Then

						} // If Validate_Subscription_Can_Be_Moved(lCompIdCurr, lSubId) = True Then

						UpgradeHelpers.DB.TransactionManager.DeEnlist(cntCustConn);
						cntCustConn.Close();

					} // If OpenCustomerSQLDatabase(cntCustConn) = True Then

					modSubscription.CloseRemoteDatabase();

				}
				else
				{
					MessageBox.Show($"Unable To Open Connection To Evolution{Environment.NewLine}Can NOT Move", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If OpenRemoteDatabase = True Then

			} // If MsgBox("Move Subscription To Anther Company Record.  Are You Sure?", vbYesNo) = vbYes Then

			cntCustConn = null;

			return;



			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			int lErrNbr = Information.Err().Number;
			string strErrDesc = Information.Err().Description;

			ErrorHandlingHelper.ResumeNext(
				() => {modAdminCommon.ADO_Transaction("RollbackTrans");}, 

				() => {modAdminCommon.Report_Error($"cmd_Move_Subscription_Click_Error: {strErrDesc}");}, 

				() => {MessageBox.Show($"cmd_Move_Subscription_Click_Error: {Information.Err().Description}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);});

		} // cmd_Move_Subscription_Click

		private void cmd_New_Installation_Click(Object eventSender, EventArgs eventArgs)
		{


			if (!DoesUserHaveAccess())
			{
				return; // Jump Out
			}

			frm_Sub_Command.Enabled = false;
			frm_Sub_Command.Visible = false;

			grd_Installations.Enabled = false;
			grd_Installations.Visible = false;
			fra_Add_Installation.Enabled = true;
			fra_Add_Installation.Visible = true;
			fra_Add_Installation.BringToFront();
			Application.DoEvents();

			cmd_New_Installation.Enabled = false;

			txt_Platform_Name.Text = "";
			txt_Platform_OS.Text = "";

			// 12/03/2002 - By David D. Cruger; Added WebPageTimeOut
			txtWebPageTimeOut.Text = "30"; // 11/28/2006 - By David D. Cruger; Per Vin; Default 30 minues
			gstrTimeOut = txtWebPageTimeOut.Text;

			// 10/24/2002 - By David D. Cruger; Added Clear for Local Notes
			chkInstallationUseLocalNotes.CheckState = CheckState.Unchecked; // Unchecked
			chkInstallationDisplayNoteTag.CheckState = CheckState.Unchecked;
			txtInstallationPathToLocalDB.Text = ""; // No Directory
			txtInstallationPathToLocalDB.Enabled = false;
			chkInstallationActive.CheckState = CheckState.Checked; // Checked

			// 03/27/2003 - By David D. Cruger; Added Active X Flag
			chkActiveXFlag.CheckState = CheckState.Checked;

			// 11/15/2004 - By David D. Cruger; Added Auto Check Terminal Service and Terminal Service Flag
			chkAutoCheckTS.CheckState = CheckState.Checked;
			chkTerminalService.CheckState = CheckState.Unchecked;

			// 03/05/2005 - By David D. Cruger; Added Reply Name, EMail and Default EMail Type
			txtReplyName.Text = "";
			txtReplyEMail.Text = "";
			chkDefaultHTMLEMail.CheckState = CheckState.Unchecked;

			// 06/03/2009 - By David D. Cruger; Added
			txtCellNumber.Text = "";
			cboCellCarrier.SelectedIndex = -1;
			txtTextMsgModels.Text = "";

			txtSMSTextActiveFlag.Text = "No";

			txt_SubInsContractAmount.Text = "0.00";

			txtSubDefaultAModId.Text = "0";

			txtSubInsNbrRecPerPage.Text = "10";

			// 08/14/2017 - By David D. Cruger; Added
			txtSubInsDefaultAnalysisMths.Text = "6";

			chkInstallEvoMobile.CheckState = CheckState.Checked;
			txtSMSEvents.Text = "MA"; // Default

			// 07/14/2011 - By David D. Cruger; Added
			cmbSubInsContact.Text = "";
			cmbSubInsContact.Tag = "0";

			// 11/15/2011 - By David D. Cruger; Added
			// This is a JETNET Demo Account
			if (modSubscription.Entered_Company_ID == 135887)
			{
				if (chkProductType[modSubscription.ProductMarketing].CheckState == CheckState.Checked)
				{
					cmbSubInsContact.Text = "Demo Account";
					cmbSubInsContact.Tag = "419946";
				}
			}

			// 08/22/2014 - By David D. Cruger; Added
			chkInstallationChatFlag.CheckState = CheckState.Unchecked;

			chkInstallAdministrator.CheckState = CheckState.Unchecked;

			// 09/22/2015 - By David D. Cruger; Added
			cboSubBType.SelectedIndex = -1;
			int tempForEndVar = cboSubBType.Items.Count - 1;
			for (int iCnt1 = 0; iCnt1 <= tempForEndVar; iCnt1++)
			{
				if (($"{cboSubBType.GetListItem(iCnt1).Substring(0, Math.Min(2, cboSubBType.GetListItem(iCnt1).Length))} ").Trim() == "DB")
				{
					cboSubBType.SelectedIndex = iCnt1;
				}
			}

			// 08/14/2017 - By David D. Cruger; Added
			txtSubInsDefaultAnalysisMths.Text = "6";

			cbo_Service_SelectionChangeCommitted(cbo_Service, new EventArgs());

			fra_Add_Installation.Visible = true;
			fra_Add_Installation.BringToFront();
			cmdDeleteInstallation.Enabled = false;

			Mode = "Install Insert";

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_New_Installation_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_New_Installation_Click(cmd_New_Installation, new EventArgs());
			}

		}

		private void cmd_New_Subscription_Click()
		{

			int NEW_SUB_ID = 0;
			if (modAdminCommon.gbl_User_Create_Sub == "Y")
			{

				if (MessageBox.Show("Are You Sure You Want To Create a New Subscription?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{


					//UPGRADE_WARNING: (1068) Find_Highest_Subscriptions of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					NEW_SUB_ID = Convert.ToInt32(Find_Highest_Subscriptions());

					Mode = "AddSubscription";

					New_Subscription(); // previous function, clears fields for a new subscription on the form

					txt_sub_id.Text = NEW_SUB_ID.ToString();
					txt_SubContractAmount.Text = "0";

					txtSubMaxExport.Text = "2000";

					Application.DoEvents();
					Load_Service_Combo_Box(cbo_Service);
					Application.DoEvents();
					Application.DoEvents();
					cbo_Service.Enabled = false;
					int tempForEndVar = cbo_Service.Items.Count - 1;
					for (int I = 0; I <= tempForEndVar; I++)
					{
						if (serv_code[I].Substring(Math.Max(serv_code[I].Length - 4, 0)) == "OW3J")
						{
							cbo_Service.SelectedIndex = I;
						}
					}
					cbo_Service.Enabled = true;
					Application.DoEvents();
					Application.DoEvents();

					chkProductType[modSubscription.ProductBusinessAC].CheckState = CheckState.Checked;
					txtCallBackDate.Text = "";
					txtCallbackComments.Text = "";
					txt_SubNbrOfInstalls[iNbrInstalls].Text = "3";
					txt_SubNbrOfInstalls[iNBRVALUEINSTALLS].Text = "0";
					txt_SubNbrOfInstalls[iNBRMPMINSTALLS].Text = "0";
					chkProductType[modSubscription.ShareByCompId].CheckState = CheckState.Unchecked;
					chkProductType[modSubscription.ShareByParentId].CheckState = CheckState.Unchecked;
					cmbFrequency.Text = "Live";

					Save_Subscription_Data(NEW_SUB_ID);

					EnableAllButtons();
				}
				else
				{
					New_Subscription(); // previous function, clears fields for a new subscription on the form

					txt_sub_id.Focus();
				}

			}
			else
			{
				New_Subscription(); // previous function, clears fields for a new subscription on the form


				txt_sub_id.Focus();
			}



		}

		private void cmd_Remove_Subscription_Click()
		{

			string strMsg = "";
			string strTemp1 = "";

			bool bContinue = false;
			int lSavedProjects = 0;

			string strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();

			if ((Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Administrator") || (Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Technical"))
			{

				strMsg = $"This will REMOVE the Subscription from the Database.{"\r"}{"\r"}";
				strMsg = $"{strMsg}Do you wish to perform this REMOVE operation at this time?";
				if (MessageBox.Show(strMsg, "REMOVE SUBSCRIPTION", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
				{

					bContinue = true;
					if (modSubscription.Does_User_Install_Have_Any_Saved_Projects(Convert.ToInt32(Double.Parse(txt_sub_id.Text)), "", -1, ref lSavedProjects))
					{
						bContinue = false;
						if (MessageBox.Show($"This SubId/Login/Install Has Saved Projects And/Or Folders ({lSavedProjects.ToString()}).{Environment.NewLine}Are You Sure You Want To Delete It?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{
							bContinue = true;
						}
					}

					if (bContinue)
					{

						// 03/12/2003 - By David D. Cruger
						// If someone removes a subscription log an event entry
						strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] ";
						strTemp1 = $"{strTemp1}SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
						strTemp1 = $"{strTemp1}Service:=[{cbo_Service.Text}]";

						modAdminCommon.Record_Event("Subscription Removed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);

						Remove_Subscription();

						Set_WebBrowser_Company_Subscription_Summary();

					} // If bContinue = True Then

				}
				else
				{
					strMsg = "User has aborted the DELETE process.";
					MessageBox.Show(strMsg, "REMOVE ABORTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

			}
			else
			{
				strMsg = "User does NOT have access to Delete Subscriptions.";
				MessageBox.Show(strMsg, "RESTRICTED ACCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
			} // If (snp_User!user_type = "Administrator") Or (snp_User!user_type = "Technical") Then

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_Save_Subscription_Click()
		{

			int SubRow = 0;

			if (!DoesUserHaveAccess())
			{
				return; // Jump Out
			}

			// added MSW - 12/7/22
			if (txt_sub_start_date.Text.Trim() != "" && txt_sub_end_date.Text.Trim() != "")
			{
				if (Information.IsDate(txt_sub_start_date.Text.Trim()) && Information.IsDate(txt_sub_end_date.Text.Trim()))
				{
					if (DateTime.Parse(txt_sub_start_date.Text.Trim()) > DateTime.Parse(txt_sub_end_date.Text.Trim()))
					{
						MessageBox.Show("Start Date Can't Be Greater Then End Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
						return;
					}
				}
			}

			if (chkCloudNotesFlag.CheckState == CheckState.Unchecked && chkServerSideNotes.CheckState == CheckState.Unchecked)
			{
				MessageBox.Show("Either Server Side Notes, Cloud Notes, or MPM Should be Turned On!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
			}



			string strSubId = ($"{txt_sub_id.Text} ").Trim();
			int lSubId = Convert.ToInt32(Double.Parse(strSubId));
			if (lSubId > 0)
			{

				if (lSubId < 32767)
				{

					if ((chkProductType[modSubscription.ProductBusinessAC].CheckState == CheckState.Checked) || (chkProductType[modSubscription.ProductHelicopters].CheckState == CheckState.Checked) || (chkProductType[modSubscription.ProductCommercial].CheckState == CheckState.Checked) || (chkProductType[modSubscription.ProductABIListing].CheckState == CheckState.Checked) || (chkProductType[modSubscription.ProductStarReports].CheckState == CheckState.Checked) || (chkProductType[modSubscription.ProductSPI].CheckState == CheckState.Checked) || (chkProductType[modSubscription.ProductMPM].CheckState == CheckState.Checked))
					{

						// 03/16/2004 - By David D. Cruger; Added Marketing Flag and Nbr of Days Expire
						if (chkProductType[modSubscription.ProductMarketing].CheckState == CheckState.Checked)
						{
							if (Convert.ToInt32(Double.Parse(txtNbrDaysExpire.Text)) <= 0)
							{
								MessageBox.Show("A Marketing Account MUST have a Nbr Days To Expired Value!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
						}

						modSubscription.search_on("Saving Subscription Information...");

						SubRow = grd_Subscriptions.CurrentRowIndex;

						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						// Write the Subscription/Installation data to the database
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						Save_Subscription_Data(Convert.ToInt32(Double.Parse(txt_sub_id.Text)));

						EnableAllButtons();

						cmdUpdateCRMSite.Enabled = cbo_Service.Text.ToUpper().IndexOf("CRM") >= 0 && txtCRMRegId.Text != "" && txtCRMRegId.Text != "0";

						// 09/10/2013 - By David D. Cruger
						//Update_Subscription_Parent_Sub_Id

						//ADDED MSW - 11/11/16  - if we are on a crm subscription, then update the crm subsription
						if (cmdUpdateCRMSite.Enabled)
						{
							cmdUpdateCRMSite_Click(cmdUpdateCRMSite, new EventArgs());
						}

						modSubscription.search_off();

					}
					else
					{
						MessageBox.Show($"At Least One Service Types Must Be Checked{Environment.NewLine}Business Aircraft, Helicopters, Commerical, Regional", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If (chkProductType(BusinessAC).Value = vbChecked) Or ...etc

				}
				else
				{
					MessageBox.Show("SubId Value Must Be Of Integer Value.  Less Then 32,767", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If lSubId < 32000 Then

			}
			else
			{
				MessageBox.Show("Subscription ID cannot be blank and must be numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If (lSubId > 0) Then

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		} // cmd_Save_Subscription_Click

		private void cmd_SaveUser_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			string query1 = "";
			string Query2 = "";
			string Query3 = "";
			string Query4 = "";
			string Query5 = "";
			string Query6 = "";
			string Query7 = "";
			string strTemp1 = "";

			string strPassword = "";
			string strStatus = "";
			string strService = "";

			// 05/19/2003 - By David D. Cruger;
			// Added Error Checking
			try
			{

				modSubscription.search_on("Saving Login Information...");

				strService = cbo_Service.Text;

				string update_q = "";

				switch(Mode)
				{
					case "LoginUpdate" : 
						 
						// 05/19/2003 - By David D. Cruger; 
						// Check to See if Login Name has Changed. 
						// If YES Make sure the new name does NOT already exist. 
						if (tmpLoginName != txtLoginName.Text)
						{
							// Check to Make Sure the New Name does NOT Exists
							Query = "SELECT sublogin_login ";
							Query = $"{Query}FROM Subscription_Login WITH (NOLOCK) ";
							Query = $"{Query}WHERE (sublogin_login = '{txtLoginName.Text}') ";
							Query = $"{Query}AND (sublogin_sub_id = {modSubscription.gbl_SubID.ToString()}) ";

							if (modAdminCommon.Exist(Query))
							{
								modSubscription.search_off();
								MessageBox.Show($"NEW Login Name: [{txtLoginName.Text}] Already Exists {Environment.NewLine}{Environment.NewLine}" +
								                $"Record Has NOT Been Saved", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							} // If Exist(Query) = True Then
						}  // If tmpLoginName <> txtLoginName.Text Then 
						 
						Query = $"UPDATE Subscription_Login SET sublogin_login = '{modAdminCommon.Fix_Quote(txtLoginName.Text.Trim())}', "; 
						Query = $"{Query}sublogin_password = '{modAdminCommon.Fix_Quote(txt_sub_password.Text.Trim())}', "; 
						Query = $"{Query} sublogin_action_date = NULL,  ";  // clear the action date - MSW - 11/3/24 
						 
						password_changed = ""; 
						if (txt_sub_password.Text.Trim() != Convert.ToString(txt_sub_password.Tag).Trim())
						{
							//password_changed = "Password Changed From " & Trim(txt_sub_password.Tag) & " to " & Trim(txt_sub_password.Text)
							password_changed = Convert.ToString(txt_sub_password.Tag).Trim();
						} 


						 
						if (chkLoginFlag[(int) modSubscription.iCHKLOGINACTIVE].CheckState == CheckState.Checked)
						{
							Query = $"{Query}sublogin_active_flag = 'Y', ";
						}
						else
						{
							Query = $"{Query}sublogin_active_flag = 'N', ";
						} 
						 
						// 01/27/2003 - By David D. Cruger; 
						// Added Demo Flag Field 
						if (chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState == CheckState.Checked)
						{
							Query = $"{Query}sublogin_demo_flag = 'Y', ";
						}
						else
						{
							Query = $"{Query}sublogin_demo_flag = 'N', ";
						} 
						 
						Query = $"{Query}sublogin_allow_export_flag = 'Y', "; 
						 
						// changed to always be y - done by msw - 7/7/22 - told to by RTW 
						//  If chkLoginFlag(iCHKLOGINLOCALNOTES).Value = vbChecked Then 
						Query = $"{Query}sublogin_allow_local_notes_flag = 'Y', "; 
						// Else 
						//   Query = Query & "sublogin_allow_local_notes_flag = 'N', " 
						//  End If 
						 
						if (chkLoginFlag[(int) modSubscription.iCHKLOGINPROJECTS].CheckState == CheckState.Checked)
						{
							Query = $"{Query}sublogin_allow_projects_flag = 'Y', ";
						}
						else
						{
							Query = $"{Query}sublogin_allow_projects_flag = 'N', ";
						} 
						 
						if (chkLoginFlag[(int) modSubscription.iCHKLOGINEMAILREQUEST].CheckState == CheckState.Checked)
						{
							Query = $"{Query}sublogin_allow_email_request_flag = 'Y', ";
						}
						else
						{
							Query = $"{Query}sublogin_allow_email_request_flag = 'N', ";
						} 
						 
						if (chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].CheckState == CheckState.Checked)
						{
							Query = $"{Query}sublogin_allow_event_request_flag = 'Y', ";
						}
						else
						{
							Query = $"{Query}sublogin_allow_event_request_flag = 'N', ";
						} 
						 
						//added MSW - 12/4/232 
						if (cbo_build.Text.Trim() != "")
						{
							Query = $"{Query}sublogin_build = '{cbo_build.Text.Trim()}', ";
						}
						else
						{
							Query = $"{Query}sublogin_build = 'B', "; // changed from P to B per request - MSW - 1/10/23
						} 

						 
						// 09/20/2019 - By David D. Cruger; Added 
						if (chkLoginFlag[(int) modSubscription.iCHKLOGINVALUES].CheckState == CheckState.Checked)
						{
							Query = $"{Query}sublogin_values_flag = 'Y', ";
						}
						else
						{
							Query = $"{Query}sublogin_values_flag = 'N', ";
						} 
						 
						// 09/20/2019 - By David D. Cruger; Added 
						if (chkLoginFlag[(int) modSubscription.iCHKLOGINMPM].CheckState == CheckState.Checked)
						{
							Query = $"{Query}sublogin_mpm_flag = 'Y', ";
						}
						else
						{
							Query = $"{Query}sublogin_mpm_flag = 'N', ";
						} 
						 
						// 11/26/2007 - By David D. Cruger - Added 
						strTemp1 = ($"{txt_SubLoginNbrOfInstalls.Text} ").Trim(); 
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary); 
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								Query = $"{Query}sublogin_nbr_of_installs = {strTemp1}, ";
							}
						} 
						 
						// 11/26/2007 - By David D. Cruger - Added 
						Query = $"{Query}sublogin_contract_amount = "; 
						strTemp1 = ($"{txt_SubLoginContractAmount.Text} ").Trim(); 
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary); 
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								Query = $"{Query}{strTemp1}, ";
							}
							else
							{
								Query = $"{Query}0.00, ";
							}
						}
						else
						{
							Query = $"{Query}0.00, ";
						} 

						 
						// 9/14/21 - added MSW - 
						Query = $"{Query}sublogin_billed_amount  = "; 
						strTemp1 = ($"{txt_sublogin_billed_amount.Text} ").Trim(); 
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary); 
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								Query = $"{Query}{strTemp1}, ";
							}
							else
							{
								Query = $"{Query}0.00, ";
							}
						}
						else
						{
							Query = $"{Query}0.00, ";
						} 

						 
						// 06/03/2009 - By David D. Cruger; Added 
						if (chkLoginFlag[(int) modSubscription.iCHKLOGINTEXTMSG].CheckState == CheckState.Checked)
						{
							Query = $"{Query}sublogin_allow_text_message_flag = 'Y', ";
						}
						else
						{
							Query = $"{Query}sublogin_allow_text_message_flag = 'N', ";
						} 
						 
						// 01/18/2010 - By David D. Cruger; Added 
						if (chkLoginFlag[(int) modSubscription.iCHKLOGINBYPASSACTIVEX].CheckState == CheckState.Checked)
						{
							Query = $"{Query}sublogin_bypass_active_x_registry_flag = 'Y', ";
						}
						else
						{
							Query = $"{Query}sublogin_bypass_active_x_registry_flag = 'N', ";
						} 
						 
						Query = $"{Query}sublogin_upd_date = '{DateTime.Today.ToString("MM/dd/yyyy")}' "; 
						 
						Query = $"{Query}WHERE sublogin_sub_id = {modSubscription.gbl_SubID.ToString()} AND sublogin_login = '{modAdminCommon.Fix_Quote(tmpLoginName)}'"; 
						 
						DbCommand TempCommand = null; 
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand); 
						TempCommand.CommandText = Query; 
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
						TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords())); 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand); 
						TempCommand.ExecuteNonQuery();  //aey 6/21/04 
						 
						if (tmpLoginName != txtLoginName.Text)
						{

							query1 = $"UPDATE Subscription_Install SET subins_login = '{modAdminCommon.Fix_Quote(($"{txtLoginName.Text} ").Trim())}' ";
							query1 = $"{query1}WHERE (subins_sub_id = {modSubscription.gbl_SubID.ToString()})  AND (subins_login = '{modAdminCommon.Fix_Quote(tmpLoginName)}') ";

							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = query1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery(); //aey 6/21/04

							Query2 = $"UPDATE Subscription_Install_Saved_Search_Criteria SET sissc_login = '{modAdminCommon.Fix_Quote(($"{txtLoginName.Text} ").Trim())}' ";
							Query2 = $"{Query2}WHERE (sissc_sub_id = {modSubscription.gbl_SubID.ToString()}) AND (sissc_login = '{modAdminCommon.Fix_Quote(tmpLoginName)}') ";

							DbCommand TempCommand_3 = null;
							TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
							TempCommand_3.CommandText = Query2;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_3.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
							TempCommand_3.ExecuteNonQuery();

							// 11/14/2019 - By David D. Cruger
							// Update Client_Folder (Evo and Local)
							Query3 = $"UPDATE Client_Folder SET cfolder_login = '{modAdminCommon.Fix_Quote(($"{txtLoginName.Text} ").Trim())}' ";
							Query3 = $"{Query3}WHERE (cfolder_sub_id = {modSubscription.gbl_SubID.ToString()}) AND (cfolder_login = '{modAdminCommon.Fix_Quote(tmpLoginName)}') ";

							DbCommand TempCommand_4 = null;
							TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
							TempCommand_4.CommandText = Query3;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_4.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
							TempCommand_4.ExecuteNonQuery();

							// 11/14/2019 - By David D. Cruger
							Query4 = $"UPDATE Subscription_Install_Saved_Exports  SET sise_login = '{modAdminCommon.Fix_Quote(($"{txtLoginName.Text} ").Trim())}' ";
							Query4 = $"{Query4}WHERE (sise_sub_id = {modSubscription.gbl_SubID.ToString()})  AND (sise_login = '{modAdminCommon.Fix_Quote(tmpLoginName)}') ";

							DbCommand TempCommand_5 = null;
							TempCommand_5 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
							TempCommand_5.CommandText = Query4;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_5.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
							TempCommand_5.ExecuteNonQuery();

							// 11/14/2019 - By David D. Cruger
							Query5 = $"UPDATE Subscription_Notifications  SET subnot_login = '{modAdminCommon.Fix_Quote(($"{txtLoginName.Text} ").Trim())}' ";
							Query5 = $"{Query5}WHERE (subnot_sub_id = {modSubscription.gbl_SubID.ToString()}) AND (subnot_login = '{modAdminCommon.Fix_Quote(tmpLoginName)}') ";

							DbCommand TempCommand_6 = null;
							TempCommand_6 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
							TempCommand_6.CommandText = Query5;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_6.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
							TempCommand_6.ExecuteNonQuery();

							Query6 = $"UPDATE Subscription_EULA_Log  SET seulal_login = '{modAdminCommon.Fix_Quote(($"{txtLoginName.Text} ").Trim())}' ";
							Query6 = $"{Query6}WHERE (seulal_sub_id = {modSubscription.gbl_SubID.ToString()}) AND (seulal_login = '{modAdminCommon.Fix_Quote(tmpLoginName)}') ";

							DbCommand TempCommand_7 = null;
							TempCommand_7 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_7);
							TempCommand_7.CommandText = Query6;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_7.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_7);
							TempCommand_7.ExecuteNonQuery();

							if (frm_Main_Menu.DefInstance.lbl_DatabaseType.Text == "LIVE SYSTEM")
							{
								if (modSubscription.OpenRemoteDatabase())
								{
									DbCommand TempCommand_8 = null;
									TempCommand_8 = REMOTE_ADO_DB.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_8);
									TempCommand_8.CommandText = query1;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_8.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_8);
									TempCommand_8.ExecuteNonQuery(); // Subscription_Install
									DbCommand TempCommand_9 = null;
									TempCommand_9 = REMOTE_ADO_DB.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_9);
									TempCommand_9.CommandText = Query2;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_9.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_9);
									TempCommand_9.ExecuteNonQuery(); // Subscription_Install_Saved_Search_Criteria
									DbCommand TempCommand_10 = null;
									TempCommand_10 = REMOTE_ADO_DB.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_10);
									TempCommand_10.CommandText = Query3;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_10.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_10);
									TempCommand_10.ExecuteNonQuery(); // Client_Folder
									DbCommand TempCommand_11 = null;
									TempCommand_11 = REMOTE_ADO_DB.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_11);
									TempCommand_11.CommandText = Query4;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_11.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_11);
									TempCommand_11.ExecuteNonQuery(); // Subscription_Install_Saved_Exports
									DbCommand TempCommand_12 = null;
									TempCommand_12 = REMOTE_ADO_DB.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_12);
									TempCommand_12.CommandText = Query5;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_12.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_12);
									TempCommand_12.ExecuteNonQuery(); // Subscription_Notifications
									DbCommand TempCommand_13 = null;
									TempCommand_13 = REMOTE_ADO_DB.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_13);
									TempCommand_13.CommandText = Query6;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_13.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_13);
									TempCommand_13.ExecuteNonQuery(); // Subscription_EULA_Log
									modSubscription.CloseRemoteDatabase();
								}
							}

							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] ";
							strTemp1 = $"{strTemp1}SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login Name Changed From: [{tmpLoginName}] To: [{txtLoginName.Text}] ";
							modAdminCommon.Record_Event("Subscription Login Name Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);

						}  // If tmpLoginName <> txtLoginName.Text Then 
						 
						UpdateActionDate(); 
						 
						// 03/12/2003 - By David D. Cruger 
						// Check to See if an event log needs to be entered 
						if (iLOGINACTIVE != chkLoginFlag[(int) modSubscription.iCHKLOGINACTIVE].CheckState)
						{
							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] ";
							strTemp1 = $"{strTemp1}SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Active Status Changed To:=[";
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINACTIVE].CheckState == CheckState.Checked)
							{
								strTemp1 = $"{strTemp1}Active]";
							}
							else
							{
								strTemp1 = $"{strTemp1}InActive]";
							}
							modAdminCommon.Record_Event("Subscription Login Active Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);

							// if login is actived or inactivated, then update the installation as well
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINACTIVE].CheckState == CheckState.Checked)
							{
								change_install_Status(true);
							}
							else
							{
								change_install_Status(false);
							}
						}  // If iLoginActive <> chkLoginFlag(iCHKLOGINACTIVE).Value Then 
						 
						if (iLOGINDEMO != chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState)
						{
							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] ";
							strTemp1 = $"{strTemp1}SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Demo Status Changed To:=[";
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState == CheckState.Checked)
							{
								strTemp1 = $"{strTemp1}Demo]";
							}
							else
							{
								strTemp1 = $"{strTemp1}Full]";
							}
							modAdminCommon.Record_Event("Subscription Login Demo Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);
						}  // If iLoginDemo <> chkLoginFlag(iCHKLOGINDEMO).Value Then 
						 
						// 05/02/2008 - By David D. Cruger 
						// Addex Export, LocalNotes, Projects, EMail Request and Event Request 
						 
						if (iLOGINEXPORT != chkLoginFlag[(int) modSubscription.iCHKLOGINEXPORT].CheckState)
						{
							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] ";
							strTemp1 = $"{strTemp1}SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Allow Export Status Changed To:=[";
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINEXPORT].CheckState == CheckState.Checked)
							{
								strTemp1 = $"{strTemp1}Allow Export]";
							}
							else
							{
								strTemp1 = $"{strTemp1}Do Not Allow Export]";
							}
							modAdminCommon.Record_Event("Subscription Login Export Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);
						}  // If iLoginExport <> chkLoginFlag(iCHKLOGINEXPORT).Value Then 
						 
						if (iLOGINLOCALNOTES != chkLoginFlag[(int) modSubscription.iCHKLOGINLOCALNOTES].CheckState)
						{
							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] ";
							strTemp1 = $"{strTemp1}SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Allow Local Notes Status Changed To:=[";
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINLOCALNOTES].CheckState == CheckState.Checked)
							{
								strTemp1 = $"{strTemp1}Allow Notes]";
							}
							else
							{
								strTemp1 = $"{strTemp1}Do Not Allow Notes]";
							}
							modAdminCommon.Record_Event("Subscription Login Local Notes Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);
						}  // If iLoginLocalNotes <> chkLoginFlag(iCHKLOGINLOCALNOTES).Value Then 
						 
						if (iLOGINPROJECTS != chkLoginFlag[(int) modSubscription.iCHKLOGINPROJECTS].CheckState)
						{
							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] ";
							strTemp1 = $"{strTemp1}SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Allow Projects Status Changed To:=[";
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINPROJECTS].CheckState == CheckState.Checked)
							{
								strTemp1 = $"{strTemp1}Allow Projects]";
							}
							else
							{
								strTemp1 = $"{strTemp1}Do Not Allow Projects]";
							}
							modAdminCommon.Record_Event("Subscription Login Projects Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);
						}  // If iLoginProjects <> chkLoginFlag(iCHKLOGINPROJECTS).Value Then 
						 
						if (iLOGINEMAILREQUEST != chkLoginFlag[(int) modSubscription.iCHKLOGINEMAILREQUEST].CheckState)
						{
							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Allow EMail Requests Status Changed To:=[";
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINEMAILREQUEST].CheckState == CheckState.Checked)
							{
								strTemp1 = $"{strTemp1}Allow EMail Requests]";
							}
							else
							{
								strTemp1 = $"{strTemp1}Do Not Allow EMail Requests]";
							}
							modAdminCommon.Record_Event("Subscription Login EMail Request Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);
						}  // If iLoginEMailRequest <> chkLoginFlag(iCHKLOGINEMAILREQUEST).Value Then 
						 
						if (iLOGINEVENTREQUEST != chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].CheckState)
						{
							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Allow Event Requests Status Changed To:=[";
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].CheckState == CheckState.Checked)
							{
								strTemp1 = $"{strTemp1}Allow Event Requests]";
							}
							else
							{
								strTemp1 = $"{strTemp1}Do Not Allow Event Requests]";
							}
							modAdminCommon.Record_Event("Subscription Login Event Request Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);
						}  // If iLoginEventRequest <> chkLoginFlag(iCHKLOGINEVENTREQUEST).Value Then 
						 
						// 06/03/2009 - By David D. Cruger; Added 
						if (iLOGINTEXTMSG != chkLoginFlag[(int) modSubscription.iCHKLOGINTEXTMSG].CheckState)
						{
							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] ";
							strTemp1 = $"{strTemp1}SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Allow Text Msg Changed To:=[";
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINTEXTMSG].CheckState == CheckState.Checked)
							{
								strTemp1 = $"{strTemp1}Allow Text Msg]";
							}
							else
							{
								strTemp1 = $"{strTemp1}Do Not Allow Text Msg]";
							}
							modAdminCommon.Record_Event("Subscription Login Export Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);
						}  // If iLoginExport <> chkLoginFlag(iCHKLOGINEXPORT).Value Then 
						 
						// 01/18/2010 - By David D. Cruger; Added 
						if (iByPassActiveXReg != chkLoginFlag[(int) modSubscription.iCHKLOGINBYPASSACTIVEX].CheckState)
						{
							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}ByPass Active X Reg Ctrl Changed To:=[";
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINBYPASSACTIVEX].CheckState == CheckState.Checked)
							{
								strTemp1 = $"{strTemp1}ByPass Reg Ctrl=Yes]";
							}
							else
							{
								strTemp1 = $"{strTemp1}ByPass Reg Ctrl=No]";
							}
							modAdminCommon.Record_Event("Subscription Login ByPass Active X Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);
						}  // If iByPassActiveXReg <> chkLoginFlag(iCHKLOGINBYPASSACTIVEX).Value Then 
						 
						// 09/20/2019 - By David D. Cruger; Added 
						if (iLOGINVALUES != chkLoginFlag[(int) modSubscription.iCHKLOGINVALUES].CheckState)
						{
							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Allow Values Changed To:=[";
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINVALUES].CheckState == CheckState.Checked)
							{
								strTemp1 = $"{strTemp1}Allow Values = Yes]";
							}
							else
							{
								strTemp1 = $"{strTemp1}Allow Values = No]";
							}
							modAdminCommon.Record_Event("Subscription Login Allow Values Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);
						}  // If iLOGINVALUES <> chkLoginFlag(iCHKLOGINVALUES).Value Then 
						 
						// 09/20/2019 - By David D. Cruger; Added 
						if (iLOGINVALUES != chkLoginFlag[(int) modSubscription.iCHKLOGINMPM].CheckState)
						{
							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Allow MPM Changed To:=[";
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINMPM].CheckState == CheckState.Checked)
							{
								strTemp1 = $"{strTemp1}Allow MPM = Yes]";
							}
							else
							{
								strTemp1 = $"{strTemp1}Allow MPM = No]";
							}
							modAdminCommon.Record_Event("Subscription Login Allow MPM Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);
						}  // If iLOGINMPM <> chkLoginFlag(iCHKLOGINMPM).Value Then 

						 
						// MSW - 9/28/21 
						if (password_changed.Trim() != "")
						{
							update_q = $" exec [EVO_LIVE_RW].jetnet_ra.dbo.PW_Insert_History_Record '{txt_sub_id.Text}', '{txtLoginName.Text}', '{password_changed}' ";
							update_q = update_q;
							DbCommand TempCommand_14 = null;
							TempCommand_14 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_14);
							TempCommand_14.CommandText = update_q;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_14.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_14);
							TempCommand_14.ExecuteNonQuery();

						} 


						 
						cmdCancelLoginFrame_Click(cmdCancelLoginFrame, new EventArgs()); 
						Fill_Logins_Grid(); 
						 
						break;
					case "LoginAdd" : 
						 
						if (VerifyLoginAdd())
						{

							Query = "INSERT INTO Subscription_Login (sublogin_sub_id, sublogin_login, ";
							Query = $"{Query}sublogin_password, sublogin_contact_id, sublogin_entry_date, sublogin_active_flag, ";

							Query = $"{Query}sublogin_nbr_of_installs,  sublogin_contract_amount, sublogin_allow_export_flag, ";
							Query = $"{Query}sublogin_allow_local_notes_flag, sublogin_allow_projects_flag, sublogin_allow_email_request_flag, ";
							Query = $"{Query}sublogin_allow_event_request_flag, sublogin_allow_text_message_flag, sublogin_bypass_active_x_registry_flag, ";

							Query = $"{Query}sublogin_values_flag, sublogin_mpm_flag,  sublogin_build, "; // added MSW - 1/16/24

							Query = $"{Query}sublogin_demo_flag ) VALUES ({modSubscription.gbl_SubID.ToString()}, ";
							Query = $"{Query}'{modAdminCommon.Fix_Quote(txtLoginName.Text.Trim())}', ";
							Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_sub_password.Text.Trim())}', ";
							Query = $"{Query}0,  '{DateTime.Today.ToString("MM/dd/yyyy")}', ";

							if (chkLoginFlag[(int) modSubscription.iCHKLOGINACTIVE].CheckState == CheckState.Checked)
							{
								Query = $"{Query}'Y', ";
							}
							else
							{
								Query = $"{Query}'N', ";
							}

							// 11/26/2007 - By David D. Cruger - Added
							strTemp1 = ($"{txt_SubLoginNbrOfInstalls.Text} ").Trim();
							strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
							if (Information.IsNumeric(strTemp1))
							{
								if (Conversion.Val(strTemp1) >= 0)
								{
									Query = $"{Query}{strTemp1}, ";
								}
								else
								{
									Query = $"{Query}0, ";
								}
							}
							else
							{
								Query = $"{Query}0, ";
							}

							// 11/26/2007 - By David D. Cruger - Added
							strTemp1 = ($"{txt_SubLoginContractAmount.Text} ").Trim();
							strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
							if (Information.IsNumeric(strTemp1))
							{
								if (Conversion.Val(strTemp1) >= 0)
								{
									Query = $"{Query}{strTemp1}, ";
								}
								else
								{
									Query = $"{Query}0.00, ";
								}
							}
							else
							{
								Query = $"{Query}0.00, ";
							}

							// Added Export, Local Notes, Projects, EMail Request and Event Request Flags
							Query = $"{Query}'Y', ";

							// changed to be always y- MSW - 7/7/22 - told by RTW
							Query = $"{Query}'Y', ";

							if (chkLoginFlag[(int) modSubscription.iCHKLOGINPROJECTS].CheckState == CheckState.Checked)
							{
								Query = $"{Query}'Y', ";
							}
							else
							{
								Query = $"{Query}'N', ";
							}

							if (chkLoginFlag[(int) modSubscription.iCHKLOGINEMAILREQUEST].CheckState == CheckState.Checked)
							{
								Query = $"{Query}'Y', ";
							}
							else
							{
								Query = $"{Query}'N', ";
							}

							if (chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].CheckState == CheckState.Checked)
							{
								Query = $"{Query}'Y', ";
							}
							else
							{
								Query = $"{Query}'N', ";
							}

							// 06/03/2009 - By David D. Cruger; Added
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINTEXTMSG].CheckState == CheckState.Checked)
							{
								Query = $"{Query}'Y', ";
							}
							else
							{
								Query = $"{Query}'N', ";
							}

							// 01/18/2010 - By David D. Cruger; Added
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINBYPASSACTIVEX].CheckState == CheckState.Checked)
							{
								Query = $"{Query}'Y', ";
							}
							else
							{
								Query = $"{Query}'N', ";
							}

							// 09/20/2019 - By David D. Cruger; Added
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINVALUES].CheckState == CheckState.Checked)
							{
								Query = $"{Query}'Y', ";
							}
							else
							{
								Query = $"{Query}'N', ";
							}

							// 09/20/2019 - By David D. Cruger; Added
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINMPM].CheckState == CheckState.Checked)
							{
								Query = $"{Query}'Y', ";
							}
							else
							{
								Query = $"{Query}'N', ";
							}

							// Added MSW - 1/16/24
							if (cbo_build.Text.Trim() != "")
							{
								Query = $"{Query}'{cbo_build.Text.Trim()}', ";
							}
							else
							{
								Query = $"{Query}'B', ";
							}

							// 01/27/2003 - By David D. Cruger
							// Added Demo Flag
							// Keep This As The Last Field
							if (chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState == CheckState.Checked)
							{
								Query = $"{Query}'Y') ";
							}
							else
							{
								Query = $"{Query}'N') ";
							}

							DbCommand TempCommand_15 = null;
							TempCommand_15 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_15);
							TempCommand_15.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_15.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_15);
							TempCommand_15.ExecuteNonQuery(); //aey 6/21/04
							UpdateActionDate();

							// If someone adds a subscription login log an event entry
							strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] ";
							strTemp1 = $"{strTemp1}SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
							strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";

							modAdminCommon.Record_Event("Subscription Login Added", strTemp1, 0, 0, modSubscription.Entered_Company_ID);

							cmdCancelLoginFrame_Click(cmdCancelLoginFrame, new EventArgs());
							Fill_Logins_Grid(modAdminCommon.Fix_Quote(txtLoginName.Text.Trim()));


							cmd_New_Installation_Click(cmd_New_Installation, new EventArgs());
							cmdUpdateInstallation_Click(cmdUpdateInstallation, new EventArgs());

							Fill_Logins_Grid();



							// 09/07/2011 - By David D. Cruger
							cmdNewLogin.Enabled = true;
							cmd_DeleteLogin.Enabled = true;
							cmdEMailSubNotice.Enabled = true;
							lblSubAddInstall.Enabled = true;
							cmd_New_Installation.Enabled = true;

							strAddChgHasHappened = $"{strAddChgHasHappened}A New Login Has Been Added On SubId: {modSubscription.gbl_SubID.ToString()}{Environment.NewLine}";

						}  // If VerifyLoginAdd Then 
						 
						break;
				}

				// Check To See If Password Is Used More Than One

				strPassword = txt_sub_password.Text;
				strStatus = "";
				if (modSubscription.IsPasswordAndEMailUsedMoreThanOnce(strPassword, strService, ref strStatus))
				{
					MessageBox.Show($"Password: [{strPassword}] {Environment.NewLine}{Environment.NewLine}Is Used More Than Once{Environment.NewLine}{Environment.NewLine}{strStatus}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				// 09/10/2013 - By David D. Cruger
				// Update_Subscription_Parent_Sub_Id

				modSubscription.search_off();

				if (mvHasFocus)
				{
					mvHasFocus = false;
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"cmd_SaveUser_Click_Error: {excep.Message}");

				if (mvHasFocus)
				{
					mvHasFocus = false;
				}
			}

		} // End Sub cmd_SaveUser_Click


		private void cmd_SaveUser_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_SaveUser_Click(cmd_SaveUser, new EventArgs());
			}

		}

		private void cmdBrowseEvoLocalNotes_Click()
		{

			Object fso = new Object();
			FileInfo fFile = null;

			string strDir = "";
			string strEvoLocalNotesMDBFileName = "";

			string strFullPathFileName = "";
			string strDrive = "";
			string strPath = "";
			string strFullFileName = "";
			string strFileName = "";
			string strExtension = "";

			JetNetSupport.PInvoke.UnsafeNative.Structures.OPENFILENAME OpenFile = JetNetSupport.PInvoke.UnsafeNative.Structures.OPENFILENAME.CreateInstance();
			int iPos1 = 0;

			//UPGRADE_WARNING: (2081) Len has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			OpenFile.lStructSize = Marshal.SizeOf(OpenFile);
			OpenFile.hwndOwner = frm_Main_Menu.DefInstance.Handle.ToInt32();
			OpenFile.hInstance = Support.GetHInstance().ToInt32();
			string sFilter = $"EVOLUTION_LOCAL.MDB (*.mdb){Strings.Chr(0).ToString()}EVOLUTION_LOCAL.MDB{Strings.Chr(0).ToString()}";
			OpenFile.lpstrFilter = sFilter;
			OpenFile.nFilterIndex = 1;
			OpenFile.lpstrFile = new string((char) 0, 257);
			OpenFile.nMaxFile = Strings.Len(OpenFile.lpstrFile) - 1;
			OpenFile.lpstrFileTitle = OpenFile.lpstrFile;
			OpenFile.nMaxFileTitle = OpenFile.nMaxFile;
			OpenFile.lpstrInitialDir = txtPathToEvoLocalNotes.Text;
			OpenFile.lpstrTitle = "Browse for EVOLUTION_LOCAL.MDB File";
			OpenFile.flags = 0;
			int lReturn = JetNetSupport.PInvoke.SafeNative.comdlg32.GetOpenFileName(ref OpenFile);

			if (lReturn > 0)
			{

				strFullPathFileName = OpenFile.lpstrFile.Trim().ToUpper();

				if (File.Exists(strFullPathFileName))
				{

					fFile = new FileInfo(strFullPathFileName);
					strDrive = new DriveInfo(fFile.Directory.Root.FullName).Name; //gap-note manual change to get Drive letter, removed stub method also
					strPath = fFile.Directory.FullName;
					if (strPath.Substring(Math.Max(strPath.Length - 1, 0)) != "\\")
					{
						strPath = $"{strPath}\\";
					}
					strFullFileName = fFile.Name;
					iPos1 = (strFullFileName.IndexOf('.') + 1);
					strExtension = ".mdb";
					if (iPos1 > 0)
					{
						strExtension = strFullFileName.Substring(Math.Min(iPos1 - 1, strFullFileName.Length));
					}
					strFileName = StringsHelper.Replace(strFullFileName, strExtension, "", 1, -1, CompareMethod.Binary);

					if (strPath != "")
					{
						txtPathToEvoLocalNotes.Text = strPath;
						Application.DoEvents();
					}

				} // If fso.FileExists(strFullPathFileName) = True Then

			} // If lReturn > 0 Then


		}

		private void cmdCancelLoginFrame_Click(Object eventSender, EventArgs eventArgs)
		{

			// Turn On Frames And Grids
			frm_Sub_Command.Visible = true;
			frm_Sub_Command.Enabled = true;

			frmLoginFlags.Visible = false;
			frmLoginFlags.Enabled = false;

			fraLogin.Visible = false;
			fraLogin.Enabled = false;

			grd_Logins.Visible = true;
			grd_Logins.Enabled = true;
			grd_Logins.BringToFront();

			fra_Add_Installation.Visible = false;
			fra_Add_Installation.Enabled = false;

			grd_Installations.Enabled = true;
			grd_Installations.Visible = true;
			grd_Installations.BringToFront();

			cmdNewLogin.Enabled = true;
			cmd_DeleteLogin.Enabled = true;
			cmdEMailSubNotice.Enabled = true;
			lblSubAddInstall.Enabled = true;
			cmd_New_Installation.Enabled = true;

			cmdNewLogin.Enabled = true;
			Mode = "";

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		} // cmdCancelLoginFrame_Click

		private void cmdCancelLoginFrame_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdCancelLoginFrame_Click(cmdCancelLoginFrame, new EventArgs());
			}

		}

		private void cmdChooseContactCancel_Click(Object eventSender, EventArgs eventArgs)
		{

			fra_ChooseContact.Visible = false;
			lst_Contact.Visible = true;

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdChooseContactCancel_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdChooseContactCancel_Click(cmdChooseContactCancel, new EventArgs());
			}

		}

		public void Add_Contact_Subscription_Note(int contact_id)
		{

			int temp_company = 0;

			temp_company = modCompany.Get_Company_ID(contact_id);

			Insert_Journal_Note(temp_company, contact_id);

		}


		private void Insert_Journal_Note(int comp_id, int contact_id)
		{

			try
			{
				string strMsg = "";
				int InsertJournID = 0;
				string HotQuery = "";
				string temp_desc = "";

				frm_Journal.DefInstance.Reference_Subject = modGlobalVars.cEmptyString;

				modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
				modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "SN";
				modAdminCommon.Rec_Journal_Info.journ_subject = "Demo Login Activated";

				grd_Subscriptions.CurrentColumnIndex = 2;
				temp_desc = grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].FormattedValue.ToString();

				temp_desc = $"Demo login created for {StringsHelper.Replace(StringsHelper.Replace(cboChooseContact.Text, "'", "", 1, -1, CompareMethod.Binary), "`", "", 1, -1, CompareMethod.Binary)} for {Convert.ToString(lbl_Service.Tag)} service - Demo expires {txtNbrDaysExpire.Text} from first login.";

				modAdminCommon.Rec_Journal_Info.journ_description = temp_desc;
				modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;

				modAdminCommon.Rec_Journal_Info.journ_comp_id = comp_id;
				modAdminCommon.Rec_Journal_Info.journ_contact_id = contact_id;

				modAdminCommon.Rec_Journal_Info.journ_account_id = "";
				modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
				modAdminCommon.Rec_Journal_Info.journ_status = "A";

				modAdminCommon.ADO_Transaction("BeginTrans");

				InsertJournID = frm_Journal.DefInstance.Commit_Journal_Entry();
				if (InsertJournID > 0)
				{
					modAdminCommon.ADO_Transaction("CommitTrans");
				}
				else
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
					strMsg = "The journal entry was not inserted.";
					MessageBox.Show(strMsg, "Insert Not Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			catch
			{

				MessageBox.Show("Insert_Journal_Note_Error:", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}


		}
		private void cmdChooseContactSave_Click(Object eventSender, EventArgs eventArgs)
		{


			grd_Logins.CurrentColumnIndex = 0;

			string Query = $"UPDATE Subscription_Login SET sublogin_contact_id = {cboChooseContact.GetItemData(cboChooseContact.SelectedIndex).ToString()}, sublogin_action_date = NULL ";
			Query = $"{Query}WHERE (sublogin_sub_id = {modSubscription.gbl_SubID.ToString()}) AND (sublogin_login = '{grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString()}') ";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery(); //aey 6/21/04
			UpdateActionDate();

			if (modSubscription.Entered_Company_ID == 135887 && txtNbrDaysExpire.Visible && lblNbrDaysExpire.Visible)
			{
				// add contact marketing notes - 5/1/24
				Add_Contact_Subscription_Note(cboChooseContact.GetItemData(cboChooseContact.SelectedIndex));
			}

			RememberLoginPosition = grd_Logins.CurrentRowIndex;

			fra_ChooseContact.Visible = false;
			lst_Contact.Visible = true;

			Fill_Logins_Grid();

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdChooseContactSave_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdChooseContactSave_Click(cmdChooseContactSave, new EventArgs());
			}

		}

		private void cmdClearContact_Click(Object eventSender, EventArgs eventArgs)
		{


			RememberLoginPosition = grd_Logins.CurrentRowIndex;

			string Query = "UPDATE Subscription_Login SET sublogin_contact_id = 0, sublogin_action_date = NULL ";
			Query = $"{Query}WHERE (sublogin_sub_id = {modSubscription.gbl_SubID.ToString()})  AND (sublogin_login = '{grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString().Trim()}') ";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery(); //aey 6/21/04
			UpdateActionDate();

			Fill_Logins_Grid();

			grd_Logins_Click(grd_Logins, new EventArgs());

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdClearContact_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdClearContact_Click(cmdClearContact, new EventArgs());
			}

		}

		private void cmdClearInstallDate_Click(Object eventSender, EventArgs eventArgs)
		{

			DialogResult Result = (DialogResult) 0;

			bool bClearNotes = false;

			if (MessageBox.Show("Are you sure you want to clear the install date for this installation?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{

				if (txtInstallationPathToLocalDB.Text != "" && txtInstallationPathToLocalDB.Text.IndexOf("mdb") >= 0)
				{
					Result = MessageBox.Show("Do you want to clear the Local Notes path as well?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel);
					if (Result == System.Windows.Forms.DialogResult.Yes)
					{
						bClearNotes = true;
					}
					else if (Result == System.Windows.Forms.DialogResult.Cancel)
					{ 
						return;
					}
				}

				ClearInstallDate(bClearNotes);

				cmd_InstallCancel_Click(cmd_InstallCancel, new EventArgs());
				Fill_grd_Installations(Convert.ToString(grd_Installations.Tag));

				modSubscription.search_off();

			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdClearInstallDate_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdClearInstallDate_Click(cmdClearInstallDate, new EventArgs());
			}

		}

		private bool Import_CRM_Server_Side_Notes_To_Cloud_Notes(DbConnection cntMySQL, DbConnection cntEvoCN, int lCompId, int lSubId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); // CRM Server Side Notes
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper(); // Client User Name
			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper(); // Cloud Notes

			string strQuery1 = "";
			string strQuery2 = "";
			string strQuery3 = "";
			string strAdd1 = "";

			string strDatabase = "";

			string strUserId = "";
			string strUserName = "";

			string strLogin = "";
			string strEMail = "";
			string strNote = "";

			string strDel1 = "";

			int lTot1 = 0;
			int lCnt1 = 0;
			int lCnt2 = 0;

			bool bResults = false;

			try
			{

				bResults = false;

				strDatabase = $"cloud_notes_{lCompId.ToString()}";

				txtTotalImportedFromSSNToCloudNotes.Text = "0";
				txtTotalRecordsInSSNotes.Text = "0";
				pbImportSSNotes.Maximum = 1;
				pbImportSSNotes.Minimum = 0;
				pbImportSSNotes.Value = 1;

				strAdd1 = $"SELECT * FROM {strDatabase} WHERE (cn_id = -1) ";

				rstAdd1.CursorLocation = CursorLocationEnum.adUseClient;
				rstAdd1.Open(strAdd1, cntEvoCN, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

				strQuery1 = "SELECT * FROM local_notes  WHERE (lnote_jetnet_ac_id > 0) ";
				strQuery1 = $"{strQuery1}AND (lnote_note IS NOT NULL)  AND (lnote_note <> '') ";


				strQuery1 = $"{strQuery1}ORDER BY lnote_id";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, cntMySQL, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lTot1 = rstRec1.RecordCount;
					lCnt1 = 0;

					txtTotalRecordsInSSNotes.Text = StringsHelper.Format(lTot1, "#,##0");
					pbImportSSNotes.Maximum = lTot1;

					strQuery2 = "SELECT cliuser_id, cliuser_first_name, cliuser_last_name, cliuser_email_address FROM client_user ORDER BY cliuser_id ";
					rstRec2.Open(strQuery2, cntMySQL, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					do 
					{ // Loop Until rstRec1.EOF = True Or cmdStopImportCRMSSNotesToCloudNotes.Enabled = False

						lCnt1++;
						txtTotalImportedFromSSNToCloudNotes.Text = StringsHelper.Format(lCnt1, "#,##0");
						pbImportSSNotes.Value = lCnt1;

						strUserName = ($"{Convert.ToString(rstRec1["lnote_user_name"])} ").Trim();
						strUserId = Convert.ToString(rstRec1["lnote_user_login"]);

						strEMail = "Imported";
						strLogin = "Imported";

						if (!rstRec2.BOF && !rstRec2.EOF)
						{
							rstRec2.MoveFirst();
							rstRec2.Filter = $"(cliuser_id = {Convert.ToString(rstRec1["lnote_user_id"])})";
							if (!rstRec2.BOF && !rstRec2.EOF)
							{
								if (($"{Convert.ToString(rstRec2["cliuser_email_address"])} ").Trim() != "")
								{
									strEMail = ($"{Convert.ToString(rstRec2["cliuser_email_address"])} ").Trim();
									strLogin = strEMail;
								}
							}
							rstRec2.Filter = "";
							rstRec2.MoveFirst();
						} // If rstRec2.BOF = False And rstRec2.EOF = False Then

						strUserName = ($"{Convert.ToString(rstRec1["lnote_user_name"])} ").Trim();
						strNote = ($"{Convert.ToString(rstRec1["lnote_note"])} ").Trim();

						rstAdd1.AddNew();

						rstAdd1["cn_ac_id"] = rstRec1["lnote_jetnet_ac_id"];
						rstAdd1["cn_comp_id"] = rstRec1["lnote_jetnet_comp_id"];
						rstAdd1["cn_contact_id"] = rstRec1["lnote_jetnet_contact_id"];


						try
						{
							rstAdd1["cn_notes"] = strNote;
							//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						}
						catch
						{
						}
						if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217887))
						{
							try
							{
								rstAdd1["cn_notes"] = modCommon.FilterNoteInformation(strNote);
							}
							catch
							{
							}
						}

						if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.IsDate(rstRec1["lnote_entry_date"])))
						{
							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Convert.ToDateTime(rstRec1["lnote_entry_date"]) >= DateTime.Parse("1/1/1988")))
							{
								try
								{
									rstAdd1["cn_entry_date"] = rstRec1["lnote_entry_date"];
								}
								catch
								{
								}
							}
							else
							{
								try
								{
									rstAdd1["cn_entry_date"] = DateTime.Now;
								}
								catch
								{
								}
							}
						}
						else
						{
							try
							{
								rstAdd1["cn_entry_date"] = DateTime.Now;
							}
							catch
							{
							}
						}
						ErrorHandlingHelper.ResumeNext(
							() => {rstAdd1["cn_user_sub_id"] = lSubId;}, 
							() => {rstAdd1["cn_user_login"] = strLogin;}, 
							() => {rstAdd1["cn_user_email"] = strEMail;}, 
							() => {rstAdd1["cn_user_contact_id"] = 0;}, 
							() => {rstAdd1["cn_user_name"] = strUserName;}, 
							() => {rstAdd1["cn_status"] = rstRec1["lnote_status"];}, 
							() => {rstAdd1["cn_amod_id"] = rstRec1["lnote_jetnet_amod_id"];});

						if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Convert.ToString(rstRec1["lnote_status"]) == "P"))
						{

							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.IsDate(rstRec1["lnote_schedule_start_date"])))
							{
								if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Convert.ToDateTime(rstRec1["lnote_schedule_start_date"]) >= DateTime.Parse("1/1/1988")))
								{
									try
									{
										rstAdd1["cn_schedule_start_date"] = rstRec1["lnote_schedule_start_date"];
									}
									catch
									{
									}
								}
							}

							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.IsDate(rstRec1["lnote_schedule_end_date"])))
							{
								if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Convert.ToDateTime(rstRec1["lnote_schedule_end_date"]) >= DateTime.Parse("1/1/1988")))
								{
									try
									{
										rstAdd1["cn_schedule_end_date"] = rstRec1["lnote_schedule_end_date"];
									}
									catch
									{
									}
								}
							}

						}
						ErrorHandlingHelper.ResumeNext( // If rstRec1!lnote_status = "P" Then

							() => {rstAdd1.UpdateBatch();}, 
							() => {rstRec1.MoveNext();}, 
							() => {Application.DoEvents();});

					}
					while(!(rstRec1.EOF || !cmdSubNotesButton[StopImportCRMSSNotesToCloudNotes].Enabled));

					rstRec2.Close();

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();
				rstAdd1.Close();

				rstAdd1 = null;
				rstRec2 = null;
				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"Import_CRM_Server_Side_Notes_To_Cloud_Notes_Error - {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return false;
		} // Import_CRM_Server_Side_Notes_To_Cloud_Notes

		private bool Import_Cloud_Notes_To_CRM_Server_Side_Notes(DbConnection cntMySQL, DbConnection cntEvoCN, int lCompId, int lSubId, string strFromDate)
		{

			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper(); // CRM Server Side Notest
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); // Cloud Notes
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper(); // CRM Users
			ADORecordSetHelper rstRec3 = new ADORecordSetHelper(); // Contacts

			string strQuery1 = "";
			string strQuery2 = "";
			string strQuery3 = "";

			string strAdd1 = "";

			string strCloudNotesTable = "";

			string strCompId = "";
			string strLogin = "";
			string strDel1 = "";

			int lTot1 = 0;
			int lCnt1 = 0;

			int lUserId = 0;
			string strUserId = "";
			string strEMail = "";
			int lContactId = 0;
			string strUserName = "";
			string strFName = "";
			string strLName = "";
			string strActiveFlag = "";
			string strNote = "";

			bool bResults = false;

			try
			{

				bResults = false;
				cmdSubNotesButton[StopImportCloudNotesToCRMSSNotes].Enabled = true;

				strCompId = lCompId.ToString();

				txtTotalImportedFromCloudNotesToSSNotes.Text = "0";
				txtTotalRecordsInCloudNotes.Text = "0";

				pbImportCNotesToCRMNotes.Maximum = 1;
				pbImportCNotesToCRMNotes.Minimum = 0;
				pbImportCNotesToCRMNotes.Value = 1;

				strCloudNotesTable = $"cloud_notes_{strCompId}";
				strQuery1 = $"SELECT * FROM {strCloudNotesTable} WITH (NOLOCK) ";
				if (strFromDate != "")
				{
					strQuery1 = $"{strQuery1}WHERE (cn_entry_date >= '{strFromDate}') ";
				}
				strQuery1 = $"{strQuery1}ORDER BY cn_id";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, cntEvoCN, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lTot1 = rstRec1.RecordCount;
					lCnt1 = 0;

					txtTotalRecordsInCloudNotes.Text = StringsHelper.Format(lTot1, "#,##0");
					pbImportCNotesToCRMNotes.Maximum = lTot1;

					strAdd1 = "SELECT * FROM local_notes WHERE (lnote_id = -1) ";
					rstAdd1.CursorLocation = CursorLocationEnum.adUseClient;
					rstAdd1.Open(strAdd1, cntMySQL, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);


					strQuery2 = "SELECT * FROM client_user ";
					rstRec2.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec2.Open(strQuery2, cntMySQL, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					do 
					{ // Loop Until rstRec1.EOF = True Or cmdStopImportCloudNotesToCRMSSNotes.Enabled = False

						lCnt1++;
						txtTotalImportedFromCloudNotesToSSNotes.Text = StringsHelper.Format(lCnt1, "#,##0");
						pbImportCNotesToCRMNotes.Value = lCnt1;

						strActiveFlag = "Y";
						strEMail = ($"{Convert.ToString(rstRec1["cn_user_email"])} ").Trim();
						strNote = ($"{Convert.ToString(rstRec1["cn_notes"])} ").Trim();

						if (strNote != "")
						{

							//--------------------------
							// Find User Id

							lUserId = 0;
							rstRec2.MoveFirst();
							do 
							{

								if (strEMail.ToLower() == ($"{Convert.ToString(rstRec2["cliuser_login"])} ").Trim().ToLower())
								{
									lUserId = Convert.ToInt32(rstRec2["cliuser_id"]);
								}

								rstRec2.MoveNext();

							}
							while(!(rstRec2.EOF || lUserId > 0));

							//--------------------------------
							// Did NOT Find - Add New User

							if (lUserId == 0)
							{

								strFName = "Imported";
								strLName = "Imported";

								lContactId = Convert.ToInt32(rstRec1["cn_user_contact_id"]);

								if (lContactId > 0)
								{

									strQuery3 = $"SELECT * FROM Contact WITH (NOLOCK) WHERE (contact_id = {lContactId.ToString()}) ";
									strQuery3 = $"{strQuery3}AND (contact_journ_id = 0) ";

									rstRec3.Open(strQuery3, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

									if (!rstRec3.BOF && !rstRec3.EOF)
									{
										strFName = ($"{Convert.ToString(rstRec3["contact_first_name"])} ").Trim();
										strFName = ($"{Convert.ToString(rstRec3["contact_last_name"])} ").Trim();
									}

									rstRec3.Close();

								} // If lContactId > 0 Then

								rstRec2.AddNew();

								rstRec2["cliuser_first_name"] = strFName;
								rstRec2["cliuser_last_name"] = strLName;
								rstRec2["cliuser_login"] = strEMail;
								rstRec2["cliuser_password"] = "xxxxxxxxxxxxx";
								rstRec2["cliuser_admin_flag"] = "N";
								rstRec2["cliuser_email_address"] = strEMail;
								rstRec2["cliuser_action_date"] = DateTime.Now;
								rstRec2["cliuser_user_id"] = 0;
								rstRec2["cliuser_loggedin_flag"] = "N";
								rstRec2["cliuser_active_flag"] = "N";
								rstRec2["cliuser_recs_per_page"] = 25;
								rstRec2["cliuser_timezone"] = 2;

								rstRec2.UpdateBatch();

								lUserId = Convert.ToInt32(rstRec2["cliuser_id"]);

								rstRec2["cliuser_user_id"] = lUserId;

								rstRec2.UpdateBatch();

							} // If lUserId = 0 Then

							//====================================================================

							rstAdd1.AddNew();

							rstAdd1["lnote_jetnet_ac_id"] = rstRec1["cn_ac_id"];
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["cn_comp_id"]))
							{
								rstAdd1["lnote_jetnet_comp_id"] = rstRec1["cn_comp_id"];
							}
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["cn_contact_id"]))
							{
								rstAdd1["lnote_jetnet_contact_id"] = rstRec1["cn_contact_id"];
							}
							rstAdd1["lnote_note"] = ($"{Convert.ToString(rstRec1["cn_notes"])} ").Trim();
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["cn_entry_date"]))
							{
								rstAdd1["lnote_entry_date"] = Convert.ToDateTime(rstRec1["cn_entry_date"]);
							}
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["cn_action_date"]))
							{
								rstAdd1["lnote_action_date"] = Convert.ToDateTime(rstRec1["cn_action_date"]);
							}
							else
							{
								rstAdd1["lnote_action_date"] = Convert.ToDateTime(rstRec1["cn_entry_date"]);
							}
							rstAdd1["lnote_user_login"] = lUserId;
							rstAdd1["lnote_user_name"] = ($"{Convert.ToString(rstRec1["cn_user_name"])} ").Trim();
							rstAdd1["lnote_notecat_key"] = 23; // General
							rstAdd1["lnote_status"] = ($"{Convert.ToString(rstRec1["cn_status"])} ").Trim();
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["cn_schedule_start_date"]))
							{
								rstAdd1["lnote_schedule_start_date"] = rstRec1["cn_schedule_start_date"];
							}
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["cn_schedule_end_date"]))
							{
								rstAdd1["lnote_schedule_end_date"] = rstRec1["cn_schedule_end_date"];
							}

							rstAdd1["lnote_user_id"] = lUserId;

							rstAdd1["lnote_clipri_ID"] = 5;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["cn_amod_id"]))
							{
								rstAdd1["lnote_jetnet_amod_id"] = rstRec1["cn_amod_id"];
							}

							rstAdd1.UpdateBatch();

						} // If strNote <> "" Then

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!(rstRec1.EOF || !cmdSubNotesButton[StopImportCloudNotesToCRMSSNotes].Enabled));

					rstRec2.Close();
					rstAdd1.Close();

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();

				cmdSubNotesButton[StopImportCloudNotesToCRMSSNotes].Enabled = false;

				rstAdd1 = null;
				rstRec3 = null;
				rstRec2 = null;
				rstRec1 = null;

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"Import_Cloud_Notes_To_CRM_Server_Side_Notes_Error - {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return false;
		} // Import_Cloud_Notes_To_CRM_Server_Side_Notes

		private void cmdImportCNToSSN_Click()
		{

			DbConnection cntEvoCN = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			DbConnection cntMySQL = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

			int lCompId = 0;
			string strCompId = "";

			int lSubId = 0;
			string strSubId = "";

			int lCRegId = 0;
			string strCRegId = "";
			string strDatabase = "";

			string strFromDate = "";

			string strMsg = "";
			string strErrMsg = "";

			try
			{

				lCompId = modSubscription.Entered_Company_ID;
				strCompId = lCompId.ToString();

				lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));
				strSubId = lSubId.ToString();

				lCRegId = Convert.ToInt32(Double.Parse(txtCRMRegId.Text));
				strCRegId = lCRegId.ToString();

				txtTotalImportedFromCloudNotesToSSNotes.Text = "0";

				cmdSubNotesButton[ImportCNToSSN].Enabled = false;

				if (chkServerSideNotes.CheckState == CheckState.Checked)
				{

					if (chkCloudNotesFlag.CheckState == CheckState.Unchecked)
					{

						if (cmbCRMDatabaseName.Text != "")
						{

							if (txtCRMRegId.Text != "0" && txtCRMRegId.Text != "")
							{

								strFromDate = txtImportCloudNotesFromDate.Text.ToUpper();
								if (strFromDate != "MM/DD/CCYY" && strFromDate != "")
								{
									if (!Information.IsDate(strFromDate))
									{
										MessageBox.Show($"From Date Is Invalid [{strFromDate}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										strFromDate = "Invalid";
									}
								}
								else
								{
									strFromDate = "";
								}

								if (strFromDate != "Invalid")
								{

									strMsg = "Import Cloud Notes To CRM Server Notes";

									if (strFromDate != "")
									{
										strMsg = $"{strMsg}{Environment.NewLine}From Date: [{strFromDate}]";
									}

									if (MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
									{

										strMsg = StringsHelper.Replace(strMsg, Environment.NewLine, ". ", 1, -1, CompareMethod.Binary);
										modAdminCommon.Record_Event("CRM Server Notes", strMsg, 0, 0, lCompId);

										if (modCommon.Open_Cloud_Notes_Database_Connection(ref cntEvoCN, ref strErrMsg))
										{

											if (modCommon.Does_Company_Cloud_Notes_Table_Exist(cntEvoCN, lCompId, ref strErrMsg))
											{

												strDatabase = $"cloud_notes_{strCompId}";

												if (modCommon.Open_CRM_Server_Side_Notes_Database_Connection(ref cntMySQL, lCRegId, ref strErrMsg))
												{

													if (Import_Cloud_Notes_To_CRM_Server_Side_Notes(cntMySQL, cntEvoCN, lCompId, lSubId, strFromDate))
													{
														Application.DoEvents();
													}

													modCommon.CloseCRMServerSideNotesDatabase(ref cntMySQL);

												}
												else
												{
													strMsg = $"Unable To Open CRM Server Side Notes Database - {strErrMsg}";
													modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);
													MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												} // If Open_CRM_Server_Side_Notes_Database_Connection(cntMySQL, lCRegId, strErrMsg) = True Then

											}
											else
											{
												strMsg = "Cloud Notes Table Does NOT Exists";
												modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);
												MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											} // If Does_Company_Cloud_Notes_Table_Exist(cntEvoCN, lCompId, strErrMsg) = True Then

											modCommon.Close_Cloud_Notes_Database_Connection(cntEvoCN, ref strErrMsg);

										}
										else
										{
											strMsg = "Unable To Open Cloud Notes Database";
											modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);
											modAdminCommon.Record_Event("Cloud Notes", strErrMsg, 0, 0, lCompId);
											MessageBox.Show($"{strMsg}{Environment.NewLine}{strErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error | MessageBoxIcon.Error);
										} // If Open_Cloud_Notes_Database_Connection(cntEvoCN, strErrMsg) = True Then

									} // If MsgBox(strMsg, vbYesNo) = vbYes Then

								} // If strFromDate <> "Invalid" Then

							}
							else
							{
								MessageBox.Show("CRM RegId Is Blank Or Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If txtCRMRegId.Text <> "0" And txtCRMRegId.Text <> "" Then

						}
						else
						{
							MessageBox.Show("CRM Database Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If cmbCRMDatabaseName.Text <> "" Then

					}
					else
					{
						MessageBox.Show("Cloud Notes Is Still Enabled", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If chkCloudNotesFlag.Value = vbUnchecked Then

				}
				else
				{
					MessageBox.Show("CRM Server Notes Is Not Enabled", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If chkServerSideNotes.Value = vbchecked Then

				cmdSubNotesButton[StopImportCloudNotesToCRMSSNotes].Enabled = false;
				cmdSubNotesButton[ImportCNToSSN].Enabled = true;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"cmdImportCNToSSN_Click_Error - {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // cmdImportCNToSSN_Click

		private void cmdImportSSNToCN_Click()
		{

			DbConnection cntEvoCN = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			DbConnection cntMySQL = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

			string strDelete1 = "";

			int lCompId = 0;
			string strCompId = "";

			int lSubId = 0;
			string strSubId = "";

			int lCRegId = 0;
			string strCRegId = "";
			string strDatabase = "";

			string strMsg = "";
			string strErrMsg = "";

			try
			{

				lCompId = modSubscription.Entered_Company_ID;
				strCompId = lCompId.ToString();

				lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));
				strSubId = lSubId.ToString();

				lCRegId = Convert.ToInt32(Double.Parse(txtCRMRegId.Text));
				strCRegId = lCRegId.ToString();

				if (cmdSubNotesButton[ImportSSNToCN].Enabled)
				{

					cmdSubNotesButton[ImportSSNToCN].Enabled = false;
					cmdSubNotesButton[StopImportCRMSSNotesToCloudNotes].Enabled = true;

					if (chkServerSideNotes.CheckState == CheckState.Unchecked)
					{

						if (chkCloudNotesFlag.CheckState == CheckState.Checked)
						{

							if (cmbCRMDatabaseName.Text != "")
							{

								if (txtCRMRegId.Text != "0" && txtCRMRegId.Text != "")
								{

									strMsg = "Import Server Side Notes To Cloud Notes";

									if (rbCopySSNToCNOverwriteCloudNotes.Checked)
									{
										strMsg = $"{strMsg}{Environment.NewLine}And OVERWRITE Cloud Notes";
									}

									if (rbCopySSNToCNAppendCloudNotes.Checked)
									{
										strMsg = $"{strMsg}{Environment.NewLine}And Append To Cloud Notes";
									}

									if (MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
									{

										strMsg = StringsHelper.Replace(strMsg, Environment.NewLine, ". ", 1, -1, CompareMethod.Binary);
										modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);

										if (modCommon.Open_Cloud_Notes_Database_Connection(ref cntEvoCN, ref strErrMsg))
										{

											if (modCommon.Does_Company_Cloud_Notes_Table_Exist(cntEvoCN, lCompId, ref strErrMsg))
											{

												strDatabase = $"cloud_notes_{strCompId}";

												if (rbCopySSNToCNOverwriteCloudNotes.Checked)
												{
													strDelete1 = $"TRUNCATE TABLE {strDatabase}";
													DbCommand TempCommand = null;
													TempCommand = cntEvoCN.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
													TempCommand.CommandText = strDelete1;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
													TempCommand.ExecuteNonQuery();
												}

												if (modCommon.Open_CRM_Server_Side_Notes_Database_Connection(ref cntMySQL, lCRegId, ref strErrMsg))
												{

													if (Import_CRM_Server_Side_Notes_To_Cloud_Notes(cntMySQL, cntEvoCN, lCompId, lSubId))
													{
														Application.DoEvents();
													}

													modCommon.CloseCRMServerSideNotesDatabase(ref cntMySQL);

												}
												else
												{
													strMsg = $"Unable To Open CRM Server Side Notes Database - {strErrMsg}";
													modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);
													MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												} // If Open_CRM_Server_Side_Notes_Database_Connection(cntMySQL, lCRegId) = True Then

											}
											else
											{
												strMsg = "Cloud Notes Table Does NOT Exists";
												modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);
												MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											} // If Does_Company_Cloud_Notes_Table_Exist(cntEvoCN, lCompId, strErrMsg) = True Then

											modCommon.Close_Cloud_Notes_Database_Connection(cntEvoCN, ref strErrMsg);

										}
										else
										{
											strMsg = "Unable To Open Cloud Notes Database";
											modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);
											modAdminCommon.Record_Event("Cloud Notes", strErrMsg, 0, 0, lCompId);
											MessageBox.Show($"{strMsg}{Environment.NewLine}{strErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error | MessageBoxIcon.Error);
										} // If Open_Cloud_Notes_Database_Connection(cntEvoCN, strErrMsg) = True Then

									} // If MsgBox(strMsg, vbYesNo) = vbYes Then

								}
								else
								{
									MessageBox.Show("CRM RegId Is Blank Or Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If txtCRMRegId.Text <> "0" And txtCRMRegId.Text <> "" Then

							}
							else
							{
								MessageBox.Show("CRM Database Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If cmbCRMDatabaseName.Text <> "" Then

						}
						else
						{
							MessageBox.Show("Cloud Notes Is NOT Enabled", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If chkCloudNotesFlag.Value = vbChecked Then

					}
					else
					{
						MessageBox.Show("CRM Server Notes Is Still Enabled", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If chkServerSideNotes.Value = vbUnchecked Then

					cmdSubNotesButton[StopImportCRMSSNotesToCloudNotes].Enabled = false;
					cmdSubNotesButton[ImportSSNToCN].Enabled = true;

				} // If cmdCopySSNToCN.Enabled = True Then

				cntMySQL = null;
				cntEvoCN = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"cmdImportSSNToCN_Click_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error | MessageBoxIcon.Error);
			}

		} // cmdImportSSNToCN_Click

		private void cmdDeleteInstallation_Click(Object eventSender, EventArgs eventArgs)
		{

			string strQuery1 = "";
			string strDelete1 = "";

			string strTemp1 = "";

			bool bContinue = false;
			int lSavedProjects = 0;
			int lCommandTimeOut = 0;

			int lCompId = 0;
			int lSubId = 0;
			string strLogin = "";
			int lSeqNbr = 0;

			string strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();

			if (MessageBox.Show("Are you sure you want to DELETE this installation?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{

				lCompId = modSubscription.Entered_Company_ID;
				lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));
				strLogin = tmpLoginName;
				grd_Installations.CurrentColumnIndex = 0;
				if (Information.IsNumeric(grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()))
				{
					lSeqNbr = Convert.ToInt32(Double.Parse(grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()));
				}
				else
				{
					lSeqNbr = 1;
				}



				bContinue = true;
				if (modSubscription.Does_User_Install_Have_Any_Saved_Projects(lSubId, strLogin, lSeqNbr, ref lSavedProjects))
				{
					bContinue = false;
					if (MessageBox.Show($"This Login/Install Has Saved Projects And/Or Folders ({lSavedProjects.ToString()}).{Environment.NewLine}Are You Sure You Want To Delete It?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						bContinue = true;
					}
				}

				if (bContinue)
				{

					strTemp1 = $"CompId:=[{lCompId.ToString()}] SubId:=[{lSubId.ToString()}]  ";
					strTemp1 = $"{strTemp1}Login:=[{strLogin}]  Install SeqNo:=[{lSeqNbr.ToString()}]  ";

					modAdminCommon.Record_Event("Subscription Install Removed", strTemp1, 0, 0, lCompId);

					modSubscription.search_on("Deleting Installations...");

					strDelete1 = $"DELETE FROM Subscription_Install WHERE (subins_sub_id = {lSubId.ToString()}) ";
					strDelete1 = $"{strDelete1}AND (subins_login = '{strLogin}') AND (subins_seq_no = {lSeqNbr.ToString()}) ";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strDelete1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					modSubscription.search_on("Deleting Installations (WebSite)...");
					// -------------------------------
					// Delete Remote Data
					// -------------------------------
					if (frm_Main_Menu.DefInstance.lbl_DatabaseType.Text == "LIVE SYSTEM")
					{

						if (modSubscription.OpenRemoteDatabase())
						{


							DbCommand TempCommand_2 = null;
							ErrorHandlingHelper.ResumeNext(
								() => {lCommandTimeOut = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(REMOTE_ADO_DB);}, 
								() => {UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(REMOTE_ADO_DB, 10);}, 
								() => {UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(REMOTE_ADO_DB, lCommandTimeOut);}, 

								() => {TempCommand_2 = REMOTE_ADO_DB.CreateCommand();}, 
								() => {UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);}, 
								() => {TempCommand_2.CommandText = strDelete1;}, 
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								() => {TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));}, 
								() => {UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);}, 
								() => {TempCommand_2.ExecuteNonQuery();}, 

								() => {modSubscription.CloseRemoteDatabase();});

						} // If OpenRemoteDatabase() = True Then

						ClearSavedProjectsFolders(lSubId, strLogin, lSeqNbr, true);

					} // If frm_Main_Menu.lbl_DatabaseType = "LIVE SYSTEM" Then

					cmd_InstallCancel_Click(cmd_InstallCancel, new EventArgs());

					Fill_grd_Installations(Convert.ToString(grd_Installations.Tag));
					UpdateActionDate();

					strAddChgHasHappened = $"{strAddChgHasHappened}An Install Has Been Deleted On SubId: {lSubId.ToString()}{Environment.NewLine}";

				} // If bContinue = True Then

				modSubscription.search_off();

			} // MsgBox

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdDeleteInstallation_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdDeleteInstallation_Click(cmdDeleteInstallation, new EventArgs());
			}

		}


		private void cmdEMailSubNotice_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";


			frm_Subscription_EMail local_new_email_form = null;
			bool bContinue = false;
			System.DateTime dtEndDate = DateTime.FromOADate(0);
			bool bMPM = false;

			string strCompany = "";
			string strCity = "";
			string strState = "";
			string strCOUNTRY = "";
			int iNbrInstalls = 0;
			string strProduct = "";
			string strService = "";
			string strFrequency = "";

			if (cmdEMailSubNotice.Enabled)
			{

				cmdEMailSubNotice.Enabled = false;

				bContinue = false;
				if (txt_sub_end_date.Text == "")
				{
					bContinue = true;
				}
				else
				{
					if (Information.IsDate(txt_sub_end_date.Text))
					{
						dtEndDate = DateTime.Parse(txt_sub_end_date.Text);
						if (dtEndDate > DateTime.Now)
						{
							bContinue = true;
						}
					}
				}

				if (bContinue)
				{

					strQuery1 = "SELECT comp_name, comp_city, comp_state, comp_country FROM Company WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (comp_id = {modSubscription.Entered_Company_ID.ToString()})  AND (comp_journ_id = 0) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{
						strCompany = ($"{Convert.ToString(rstRec1["comp_name"])} ").Trim();
						strCity = ($"{Convert.ToString(rstRec1["Comp_city"])} ").Trim();
						strState = ($"{Convert.ToString(rstRec1["comp_state"])} ").Trim();
						strCOUNTRY = ($"{Convert.ToString(rstRec1["Comp_country"])} ").Trim();
					} //
					rstRec1.Close();

					strQuery1 = "SELECT subins_sub_id, subins_login, subins_seq_no FROM Subscription_Install WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (subins_sub_id = {txt_sub_id.Text}) ";
					strQuery1 = $"{strQuery1}AND (subins_login = '{txtLoginName.Text}') AND (subins_active_flag = 'Y') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{
						iNbrInstalls = rstRec1.RecordCount;
					}
					rstRec1.Close();

					local_new_email_form = frm_Subscription_EMail.CreateInstance();

					local_new_email_form.SetSubId(Convert.ToInt32(Double.Parse(txt_sub_id.Text)));
					local_new_email_form.SetNbrInstalls(iNbrInstalls);
					local_new_email_form.SetCompany($"{strCompany}<br>{strCity}, {strState}  {strCOUNTRY}");
					local_new_email_form.SetLoginName(txtLoginName.Text);
					local_new_email_form.SetPassword(txt_sub_password.Text);
					local_new_email_form.SetCompanyId(modSubscription.Entered_Company_ID);

					strProduct = "";
					if (chkProductType[modSubscription.ProductAerodex].CheckState == CheckState.Checked)
					{
						strProduct = $"{strProduct}Aerodex, ";
					}

					if (chkProductType[modSubscription.ProductAerodex].CheckState == CheckState.Unchecked)
					{

						if (chkProductType[modSubscription.ProductBusinessAC].CheckState == CheckState.Checked || chkProductType[modSubscription.ProductHelicopters].CheckState == CheckState.Checked || chkProductType[modSubscription.ProductCommercial].CheckState == CheckState.Checked)
						{

							strProduct = $"{strProduct}MarketPlace, ";
							if (gbMPM)
							{

								// changed to look at user side - MSW - 6/19/23
								if (chkLoginFlag[10].CheckState == CheckState.Checked)
								{
									strProduct = $"{strProduct}MarketPlace Manager, ";
								}

							}

						}
						else if (cbo_Service.Text == "CRM" || chkProductType[modSubscription.ProductMPM].CheckState == CheckState.Checked)
						{ 

							if (chkLoginFlag[10].CheckState == CheckState.Checked)
							{
								strProduct = $"{strProduct}MarketPlace Manager, ";
							}

						}


					}
					else if (cbo_Service.Text == "CRM" || chkProductType[modSubscription.ProductMPM].CheckState == CheckState.Checked)
					{ 
						if (chkLoginFlag[10].CheckState == CheckState.Checked)
						{
							strProduct = $"{strProduct}MarketPlace Manager, ";
						}
					} // If chkProductType(ProductAerodex).Value = vbUnchecked Then

					if (chkLoginFlag[9].CheckState == CheckState.Checked)
					{
						strProduct = $"{strProduct}Values, ";
					}


					// changed to include the word business - MSW - 6/19/23
					strService = "";
					if (chkProductType[modSubscription.ProductBusinessAC].CheckState == CheckState.Checked)
					{
						strService = $"{strService}Business ";
						strService = $"{strService}{StringsHelper.Replace(StringsHelper.Replace(StringsHelper.Replace(cmbTierLevel.Text, " - 1", "", 1, -1, CompareMethod.Binary), " - 2", "", 1, -1, CompareMethod.Binary), " - 3", "", 1, -1, CompareMethod.Binary)}, ";

					}

					if (chkProductType[modSubscription.ProductHelicopters].CheckState == CheckState.Checked)
					{
						strService = $"{strService}Helicopters, ";
					}

					if (chkProductType[modSubscription.ProductCommercial].CheckState == CheckState.Checked)
					{
						strService = $"{strService}Commercial ";
						strService = $"{strService}{cmbTierLevel_comm.Text}";

					}

					// to replace both of the strings from tier levels - business and comm
					strService = $"{StringsHelper.Replace(StringsHelper.Replace(StringsHelper.Replace(strService, " - 1", "", 1, -1, CompareMethod.Binary), " - 2", "", 1, -1, CompareMethod.Binary), " - 3", "", 1, -1, CompareMethod.Binary)}, ";

					strFrequency = $"{($"{cmbFrequency.Text} ").Trim()} Updates";

					strProduct = strProduct.Trim();
					if (strProduct.Substring(Math.Max(strProduct.Length - 1, 0)) == ",")
					{
						strProduct = strProduct.Substring(0, Math.Min(Strings.Len(strProduct) - 1, strProduct.Length));
					}

					strService = strService.Trim();
					if (strService.Substring(Math.Max(strService.Length - 1, 0)) == ",")
					{
						strService = strService.Substring(0, Math.Min(Strings.Len(strService) - 1, strService.Length));
					}

					local_new_email_form.SetProduct(strProduct);
					local_new_email_form.SetService(strService);
					local_new_email_form.SetFrequency(strFrequency);

					switch(Convert.ToString(modAdminCommon.snp_User["user_id"]).ToLower())
					{
						case "jal" : 
							local_new_email_form.SetJason(); 
							break;
						case "tmt" : 
							local_new_email_form.SetTherese(); 
							break;
						case "pec" : 
							local_new_email_form.SetPaul(); 
							break;
						case "kg" : 
							local_new_email_form.SetKen(); 
							break;
						case "khd" : 
							local_new_email_form.SetKarim(); 
							break;
						case "slh" : 
							local_new_email_form.SetStephanie(); 
							break;
						default:
							local_new_email_form.SetGeneric(); 
							break;
					}

					if (chkProductType[modSubscription.ProductMarketing].CheckState == CheckState.Checked)
					{
						local_new_email_form.SetEMailDemo();
					}
					else
					{
						if (((int) DateAndTime.DateDiff("d", DateTime.Parse(txt_sub_start_date.Text), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 7)
						{
							local_new_email_form.SetEMailResend();
						}
						else
						{
							local_new_email_form.SetEMailNew();
						}
					}

					local_new_email_form.ShowDialog(this);

				}
				else
				{
					MessageBox.Show("This is a Cancelled Account.  Can NOT Send EMail Notice", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If bContinue = True Then

			} // If cmdEMailSubNotice.Enabled = True Then

			cmdEMailSubNotice.Enabled = true;

			local_new_email_form = null;
			rstRec1 = null;

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		} // End Sub cmdEMailSubNotice_Click

		private void cmdEMailSubNotice_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdEMailSubNotice_Click(cmdEMailSubNotice, new EventArgs());
			}

		}


		private void cmdGeneratePassword_Click(Object eventSender, EventArgs eventArgs)
		{



			string strNewPassword = ""; // Clear The Password

			string strUserId = Convert.ToString(modAdminCommon.snp_User["user_id"]).ToUpper();
			int lCompId = modSubscription.Entered_Company_ID;
			int lSubId = modSubscription.gbl_SubID;
			int lTechId = modSubscription.gbl_SubID;
			string strLogin = txtLoginName.Text.ToLower();

			string strOldPassword = txt_sub_password.Text.Trim();
			strNewPassword = modCommon.GenerateNewPassword(lTechId);

			string strTmp1 = $"TechId: [{lTechId.ToString()}]  UserId: [{strUserId}]  " +
			                 $"LoginName: [{strLogin}]   Old Password: {strOldPassword}   " +
			                 $"New Password: {strNewPassword} ";

			txt_sub_password.Text = strNewPassword;

			modAdminCommon.Record_Event("Generated Password", strTmp1, 0, 0, lCompId);

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		} // cmdGeneratePassword_Click

		private void cmdGeneratePassword_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdGeneratePassword_Click(cmdGeneratePassword, new EventArgs());
			}

		}

		private void cmdIdentifyContact_Click(Object eventSender, EventArgs eventArgs)
		{

			lst_Contact.Visible = false;

			cboChooseContact.SelectedIndex = 0;
			fra_ChooseContact.Visible = true;

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdIdentifyContact_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdIdentifyContact_Click(cmdIdentifyContact, new EventArgs());
			}

		}

		private void cmdImportEvoLocalNotesToCloudNotes_Click()
		{

			DbConnection cntMDB = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConnMDB = "";

			DbConnection cntEvoCN = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();
			string strAdd1 = "";

			Object fso = new Object();
			string strTable = "";
			string strFileName = "";
			string strErrMsg = "";
			string strTruncate1 = "";
			string strDelete1 = "";

			bool bContinue = false;

			int lCompId = 0;
			int lSubId = 0;
			int lACId = 0;
			int lAModId = 0;

			string strLogin = "";
			string strUser = "";
			string strEMail = "";

			int lTot1 = 0;
			int lAdd1 = 0;
			string strMsg = "";

			try
			{

				if (chkCloudNotesFlag.CheckState == CheckState.Checked)
				{

					if (cmdSubNotesButton[ImportEvoLocalNotesToCloudNotes].Enabled)
					{

						lCompId = modSubscription.Entered_Company_ID;
						lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));

						modAdminCommon.Record_Event("Cloud Notes", "Import Evo-Local Notes Into Cloud Notes", 0, 0, lCompId);

						cmdSubNotesButton[ImportEvoLocalNotesToCloudNotes].Enabled = false;
						cmdSubNotesButton[StopImportEvoLocalNotesToCloudNotes].Enabled = false;

						if (txtPathToEvoLocalNotes.Text.Substring(Math.Max(txtPathToEvoLocalNotes.Text.Length - 1, 0)) != "\\")
						{
							txtPathToEvoLocalNotes.Text = $"{txtPathToEvoLocalNotes.Text}\\";
						}

						strFileName = $"{txtPathToEvoLocalNotes.Text}evolution_local.mdb";

						if (File.Exists(strFileName))
						{

							strConnMDB = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={strFileName};Persist Security Info=False";
							//UPGRADE_ISSUE: (2064) ADODB.Connection property cntMDB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							cntMDB.setCursorLocation(CursorLocationEnum.adUseClient);
							//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
							cntMDB.ConnectionString = strConnMDB;
							cntMDB.Open();
							UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntMDB, 600);

							if (modCommon.Open_Cloud_Notes_Database_Connection(ref cntEvoCN, ref strErrMsg))
							{

								if (modCommon.Does_Company_Cloud_Notes_Table_Exist(cntEvoCN, lCompId, ref strErrMsg))
								{

									lTot1 = 0;
									lAdd1 = 0;
									strTable = $"cloud_notes_{lCompId.ToString()}";
									bContinue = true;

									if (rbEvoLocalNotesOverrideCloudNotes.Checked)
									{

										bContinue = false;

										if (MessageBox.Show("Delete ALL Records In Customers Cloud Notes Database", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
										{

											strMsg = "Truncate (Delete All) Cloud Note Records For Import Of Evo Local Notes";
											modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);

											strTruncate1 = $"TRUNCATE TABLE [dbo].[{strTable}]";
											DbCommand TempCommand = null;
											TempCommand = cntEvoCN.CreateCommand();
											UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
											TempCommand.CommandText = strTruncate1;
											//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
											TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
											UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
											TempCommand.ExecuteNonQuery();
											bContinue = true;

										}
										else
										{
											strMsg = "Import Evo-Local Notes To Cloud Notes Process ABORTED";
											modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);
											MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										}

									}
									else
									{

										if (rbEvoLocalNotesPurgeImportCloudNotes.Checked)
										{

											strMsg = "Purge All Imported Evo Local Notes From The Cloud Notes Table";
											modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);

											strDelete1 = $"DELETE FROM {strTable} WHERE (cn_user_name = 'Imported') AND (cn_user_email = 'Imported') ";
											DbCommand TempCommand_2 = null;
											TempCommand_2 = cntEvoCN.CreateCommand();
											UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
											TempCommand_2.CommandText = strDelete1;
											//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
											TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
											UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
											TempCommand_2.ExecuteNonQuery();

											bContinue = true;

										} // If rbEvoLocalNotesPurgeImportCloudNotes.Value = True Then

										if (rbEvoLocalNotesAppendCloudNotes.Checked)
										{
											strMsg = "Append All Evo Local Notes To Cloud Notes Table";
											modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);
											bContinue = true;
										}

									} // If rbEvoLocalNotesOverrideCloudNotes.Value = True Then

									if (bContinue)
									{

										// Get All Local Notes
										strQuery1 = "SELECT * FROM Local_Notes";
										rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
										rstRec1.Open(strQuery1, cntMDB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

										if (!rstRec1.BOF && !rstRec1.EOF)
										{

											// Open Add Recordset
											strAdd1 = $"SELECT * FROM {strTable} WHERE (cn_id = -1)";
											rstAdd1.Open(strAdd1, cntEvoCN, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

											cmdSubNotesButton[StopImportEvoLocalNotesToCloudNotes].Enabled = true;

											lTot1 = rstRec1.RecordCount;
											txtTotalRecordsInEvoLocalNotes.Text = StringsHelper.Format(lTot1, "#,###");

											pbImportEvoLocalNotes.Visible = true;
											pbImportEvoLocalNotes.Minimum = 0;
											pbImportEvoLocalNotes.Maximum = lTot1;
											pbImportEvoLocalNotes.Value = 0;

											do 
											{ // Loop Until rstRec1.EOF = True Or cmdStopImportEvoLocalNotesToCloudNotes.Enabled = False

												if (Convert.ToString(rstRec1["lnote_note"]).Trim() != "")
												{

													lACId = Convert.ToInt32(rstRec1["lnote_ac_id"]);
													lAModId = modCommon.Return_Aircraft_Model_id(lACId, 0);

													lAdd1++;
													txtTotalImportedFromLocalNotesToEvoCloudNotes.Text = StringsHelper.Format(lAdd1, "#,###");
													Application.DoEvents();

													rstAdd1.AddNew();
													rstAdd1["cn_ac_id"] = lACId;
													rstAdd1["cn_notes"] = rstRec1["lnote_note"];
													//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
													if (!Convert.IsDBNull(rstRec1["lnote_entry_date"]))
													{
														if (Information.IsDate(rstRec1["lnote_entry_date"]))
														{
															if (Convert.ToDateTime(rstRec1["lnote_entry_date"]).Year > 1990)
															{
																rstAdd1["cn_entry_date"] = rstRec1["lnote_entry_date"];
															}
															else
															{
																rstAdd1["cn_entry_date"] = 0;
															}
														}
														else
														{
															rstAdd1["cn_entry_date"] = 0;
														}
													}
													else
													{
														rstAdd1["cn_entry_date"] = 0;
													}

													rstAdd1["cn_user_comp_id"] = lCompId;
													rstAdd1["cn_user_sub_id"] = lSubId;
													rstAdd1["cn_user_contact_id"] = 0;

													strLogin = ($"{Convert.ToString(rstRec1["lnote_user_login"])} ").Trim();
													if (strLogin == "" || strLogin == "Import")
													{
														strLogin = "Imported";
													}

													strUser = ($"{Convert.ToString(rstRec1["lnote_user_login"])} ").Trim();
													if (strUser == "" || strUser == "Import")
													{
														strUser = "Imported";
													}

													strEMail = "Imported";

													rstAdd1["cn_user_login"] = strLogin;
													rstAdd1["cn_user_name"] = strUser;
													rstAdd1["cn_user_email"] = strEMail;

													rstAdd1["cn_status"] = "A";
													rstAdd1["cn_amod_id"] = lAModId;

													rstAdd1.UpdateBatch();

													pbImportEvoLocalNotes.Value = Convert.ToInt32(pbImportEvoLocalNotes.Value + 1);

												} // If Trim(rstRec1!lnote_note) <> "" Then

												rstRec1.MoveNext();
												Application.DoEvents();

											}
											while(!(rstRec1.EOF || !cmdSubNotesButton[StopImportEvoLocalNotesToCloudNotes].Enabled));

											rstAdd1.Close();

											if (cmdSubNotesButton[StopImportEvoLocalNotesToCloudNotes].Enabled)
											{
												strMsg = $"Cloud Notes - Import Evo Local Notes Completed - {StringsHelper.Format(lAdd1, "#,###")} Records Imported";
											}
											else
											{
												strMsg = $"Cloud Notes - Import Evo Local Notes ABORTED BY User - {StringsHelper.Format(lAdd1, "#,###")} Records Imported";
											}

											modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);

										}
										else
										{
											strMsg = "Evo Local Notes MDB File Is Empty";
											modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);
											MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										} // If rstRec1.BOF = False And rstRec1.EOF = False Then

										cmdSubNotesButton[StopImportEvoLocalNotesToCloudNotes].Enabled = false;

										rstRec1.Close();

									} // If bContinue = True Then

								}
								else
								{
									strMsg = "Cloud Notes Table Does NOT Exists";
									modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);
									MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If Does_Company_Cloud_Notes_Table_Exist(cntEvoCN, lCompId, strErrMsg) = True Then

								modCommon.Close_Cloud_Notes_Database_Connection(cntEvoCN, ref strErrMsg);

							}
							else
							{
								strMsg = "Unable To Open Cloud Notes Database";
								modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);
								modAdminCommon.Record_Event("Cloud Notes", strErrMsg, 0, 0, lCompId);
								MessageBox.Show($"{strMsg}{Environment.NewLine}{strErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error | MessageBoxIcon.Error);
							} // ' If Open_Cloud_Notes_Database_Connection(cntEvoCN, strErrMsg) = True Then

							UpgradeHelpers.DB.TransactionManager.DeEnlist(cntMDB);
							cntMDB.Close();

						}
						else
						{
							strMsg = "Unable To Find Evolution Local Notes MDB";
							modAdminCommon.Record_Event("Cloud Notes", strMsg, 0, 0, lCompId);
							MessageBox.Show($"{strMsg}{Environment.NewLine}{strFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If fso.FileExists(strFileName) = True Then

						cmdSubNotesButton[StopImportEvoLocalNotesToCloudNotes].Enabled = false;
						cmdSubNotesButton[ImportEvoLocalNotesToCloudNotes].Enabled = true;
						pbImportEvoLocalNotes.Visible = false;

					} // If cmdImportEvoLocalNotesToCloudNotes.Enabled = True Then

				}
				else
				{
					MessageBox.Show("Cloud Notes Must Be Checked Before Import Can Begin", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				} // If chkCloudNotesFlag.Value = vbChecked Then

				rstAdd1 = null;
				rstRec1 = null;
				cntEvoCN = null;
				cntMDB = null;
				fso = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"cmdImportEvoLocalNotesToCloudNotes_Click_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error | MessageBoxIcon.Error);
			}

		} // cmdImportEvoLocalNotesToCloudNotes_Click


		private void cmdInstallValidateSMSTxtMsg_Click(Object eventSender, EventArgs eventArgs)
		{
			StreamWriter tsFileWriter = null;

			FileStream tsFile = null;

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bHomebaseOK = false;
			bool bEvolutionOK = false;

			int lCompId = 0;
			int lSubId = 0;
			string strLogin = "";
			int lSeqNbr = 0;
			string strCellNbr = "";
			string strMobileActiveDate = "";

			string strReportHB = "";
			string strReportEvo = "";
			string strSMSEvoMobileLink = "";
			string strReportLastSMSTextSent = "";
			string strReportLastSMSTextRecv = "";

			string strDir = "";
			string strFileName = "";
			string strHTML = "";
			int lTop = 0;

			try
			{

				if (cmdInstallValidateSMSTxtMsg.Enabled)
				{

					cmdInstallValidateSMSTxtMsg.Enabled = false;

					lTop = 5; // Last 5 SMS Text Messages Sent and Received

					modSubscription.search_on("Validation Report For Homebase SMS Txt Msg/Evo Mobile");
					Application.DoEvents();

					bHomebaseOK = true;
					bEvolutionOK = true;

					strHTML = "";
					strReportHB = "";
					strReportEvo = "";
					strSMSEvoMobileLink = "";

					//------------------------------------
					// Load Parameters For Reports

					lCompId = modSubscription.Entered_Company_ID;
					lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));
					strLogin = ($"{txtLoginName.Text} ").Trim();
					strCellNbr = ($"{txtCellNumber.Text} ").Trim();
					strMobileActiveDate = ($"{txtMobileActiveDate.Text} ").Trim();

					grd_Installations.CurrentColumnIndex = 0;
					lSeqNbr = Convert.ToInt32(Double.Parse(grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()));

					strReportHB = modSubscription.Return_SMS_Text_Message_Validation_Report(modAdminCommon.LOCAL_ADO_DB, lCompId, lSubId, strLogin, lSeqNbr, "HOMEBASE", ref bHomebaseOK);

					modSubscription.search_on("Getting Last 5 SMS Text Messages Sent");
					Application.DoEvents();

					strReportLastSMSTextSent = modSubscription.Return_Last_SMS_Text_Message_Sent(modAdminCommon.LOCAL_ADO_DB, lCompId, lSubId, strLogin, lSeqNbr, strCellNbr, lTop);

					modSubscription.search_on("Validation Report For Evolution SMS Txt Msg/Evo Mobile");
					Application.DoEvents();

					if (modSubscription.OpenRemoteDatabase())
					{

						strReportEvo = modSubscription.Return_SMS_Text_Message_Validation_Report(REMOTE_ADO_DB, lCompId, lSubId, strLogin, lSeqNbr, "EVOLUTION", ref bEvolutionOK);

						modSubscription.search_on("Getting Last 5 SMS Text Messages Received");
						Application.DoEvents();

						strReportLastSMSTextRecv = modSubscription.Return_Last_SMS_Text_Message_Received(REMOTE_ADO_DB, lCompId, lSubId, strLogin, lSeqNbr, strCellNbr, lTop);
						Application.DoEvents();

						strSMSEvoMobileLink = modSubscription.Return_SMS_Text_Message_Link(strCellNbr, strMobileActiveDate);

						Application.DoEvents();

						modSubscription.CloseRemoteDatabase();

					} // If OpenRemoteDatabase Then

					//----------------------------------

					strHTML = $"<html>{Environment.NewLine}<head>{Environment.NewLine}";
					strHTML = $"{strHTML}<title>JETNET LLC - Company Subscription/Install SMS Text Msg/Evo-Mobile Validation Report</title>{Environment.NewLine}";
					strHTML = $"{strHTML}</head>{Environment.NewLine}{Environment.NewLine}";

					strHTML = $"{strHTML}<body>{Environment.NewLine}<center>{Environment.NewLine}{strReportHB}{Environment.NewLine}";

					strHTML = $"{strHTML}<BR/><BR/>{Environment.NewLine}{strReportEvo}{Environment.NewLine}<BR/><BR/>{Environment.NewLine}";

					strHTML = $"{strHTML}{strSMSEvoMobileLink}{Environment.NewLine}<BR/><BR/>{Environment.NewLine}";

					strHTML = $"{strHTML}{strReportLastSMSTextRecv}{Environment.NewLine}<BR/><BR/>{Environment.NewLine}";

					strHTML = $"{strHTML}{strReportLastSMSTextSent}{Environment.NewLine}";

					strHTML = $"{strHTML}</center></body></html>{Environment.NewLine}";

					strDir = "C:\\TEMP\\";
					if (!Directory.Exists(strDir))
					{
						Directory.CreateDirectory(strDir);
					}

					strDir = $"{strDir}SMSTxtReport\\";

					if (!Directory.Exists(strDir))
					{
						Directory.CreateDirectory(strDir);
					}

					strFileName = $"{strDir}SMSTxtValidation-{lSubId.ToString()}-Report.html";
					tsFile = new FileStream(strFileName, FileMode.OpenOrCreate, FileAccess.Write);
					tsFileWriter = new StreamWriter(tsFile);
					tsFileWriter.WriteLine(strHTML); // Write String
					tsFileWriter.Close(); // Close File
					tsFile = null; // Release Memory


					if (File.Exists(strFileName))
					{
						modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strFileName);
					}
					else
					{
						MessageBox.Show($"Unable To Find Report HTML File{Environment.NewLine}{Environment.NewLine}{strFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					modSubscription.search_off();

					cmdInstallValidateSMSTxtMsg.Enabled = true;

				} // If cmdInstallValidateSMSTxtMsg.Enabled = True Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"cmdInstallValidateSMSTxtMsg_Click_Error: {Environment.NewLine}{excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				modSubscription.search_off();
				cmdInstallValidateSMSTxtMsg.Enabled = true;
			}

		} // cmdInstallValidateSMSTxtMsg_Click

		private void cmdMoveLoginFrame_Click(Object eventSender, EventArgs eventArgs)
		{

			DbConnection cntCustConn = null;

			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";
			string strErrMsg = "";

			string strCompId = "";
			int lCompId = 0;

			string strCurrSubId = "";
			int lCurrSubId = 0;

			string strNewSubId = "";
			int lNewSubId = 0;

			string strLogin = "";
			int lSeqNbr = 0;
			string strSeqNbr = "";

			int lCompIdTest = 0;
			string strCompIdTest = "";

			int lSubIdTest = 0;
			string strSubIdTest = "";

			string strLoginTest = "";

			int lContactId = 0;
			string strContactId = "";
			string strContactEMail = "";

			int X1 = 0;
			int Y1 = 0;

			bool bCompleted = false;

			string strMsg = "";

			int lHBNbrChg = 0;
			int lEvoNbrChg = 0;

			try
			{

				strCurrSubId = "0";
				lCurrSubId = 0;

				strNewSubId = "0";
				lNewSubId = 0;

				if (MessageBox.Show("Move Login To Anther SubId Within This Company Record.  Are You Sure?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{

					lCompId = modSubscription.Entered_Company_ID;
					strCompId = lCompId.ToString();

					strCurrSubId = txt_sub_id.Text;
					lCurrSubId = Convert.ToInt32(Double.Parse(strCurrSubId));
					strLogin = txtLoginName.Text.Trim();

					lHBNbrChg = 0;
					lEvoNbrChg = 0;

					if (modSubscription.OpenRemoteDatabase())
					{

						if (modCommon.OpenCustomerSQLDatabase(ref cntCustConn))
						{

							if (modSubscription.Validate_Subscription_Login_Can_Be_Moved(lCompId, lCurrSubId, strLogin))
							{

								X1 = frm_Subscription.DefInstance.Left * 15 + (frm_Subscription.DefInstance.Width * 15 / 2);
								Y1 = frm_Subscription.DefInstance.Top * 15 + (frm_Subscription.DefInstance.Height * 15 / 2) - 200;

								strNewSubId = InputBoxHelper.InputBox("Enter SubId To Move Login To", "Move To SubId", "0", X1 / 15, Y1 / 15);

								if (Information.IsNumeric(strNewSubId))
								{

									lNewSubId = Convert.ToInt32(Double.Parse(strNewSubId));

									if (lCurrSubId != lNewSubId)
									{

										//----------------------------------------------------------------------
										// Test To Make Sur The New SubId Is Under This Company Record

										strQuery1 = $"(sub_id = {strNewSubId})";
										strCompIdTest = modCommon.DLookUp("sub_comp_id", "Subscription", strQuery1);

										lCompIdTest = 0;
										if (Information.IsNumeric(strCompIdTest))
										{
											lCompIdTest = Convert.ToInt32(Double.Parse(strCompIdTest));
										}

										if (lCompId == lCompIdTest)
										{

											//----------------------------------------------------------------------------------
											// Test To Make Sure That Login Name Does NOT Already Exist Under The New SubId

											strQuery1 = $"(sublogin_sub_id = {strNewSubId}) AND (sublogin_login = '{strLogin}')";
											strLoginTest = modCommon.DLookUp("sublogin_login", "Subscription_Login", strQuery1);

											if (strLoginTest == "")
											{

												if (MessageBox.Show($"Move Login [{strLogin}] From SubId [{strCurrSubId}] To SubId [{strNewSubId}]{Environment.NewLine}{Environment.NewLine}Are You Sure?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
												{

													lContactId = 0;
													strContactEMail = "";

													strQuery1 = $"(subins_sub_id = {strCurrSubId}) AND (subins_login = '{strLogin}')";
													strContactId = modCommon.DLookUp("subins_contact_id", "Subscription_Install", strQuery1);

													if (Information.IsNumeric(strContactId))
													{
														lContactId = Convert.ToInt32(Double.Parse(strContactId));
														strQuery1 = $"(contact_id = {strContactId}) AND (contact_journ_id = 0)";
														strContactEMail = modCommon.DLookUp("contact_email_address", "Contact", strQuery1);
													} // If IsNumeric(strContactId) = True Then

													//------------------------------------------------------
													// This MUST Be Wrapped In A Transaction To Work

													bCompleted = false;
													strErrMsg = "";

													//-- EventLog
													modSubscription.search_on("Changing EventLog - Homebase", "Processing.....");
													if (modSubscription.Move_All_Subscription_Login_Event_Logs("Homebase", lCompId, lContactId, strLogin, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
													{

														//-- EventLog
														modSubscription.search_on("Changing EventLog - Evolution", "Processing.....");
														if (modSubscription.Move_All_Subscription_Login_Event_Logs("Evolution", lCompId, lContactId, strLogin, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
														{

															//-- Subscription_Install_Log
															modSubscription.search_on("Changing Subscription Install Log - Homebase", "Processing.....");
															if (modSubscription.Move_All_Subscription_Login_Install_Logs("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
															{

																//-- Subscription_Install_Log
																modSubscription.search_on("Changing Subscription Install Log - Evolution", "Processing.....");
																if (modSubscription.Move_All_Subscription_Login_Install_Logs("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																{

																	//-- Report_Request_DotNet
																	modSubscription.search_on("Changing Request Report DotNet - Homebase", "Processing.....");
																	if (modSubscription.Move_All_Subscription_Login_Request_Report_DotNet("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																	{

																		//-- Report_Request_DotNet
																		modSubscription.search_on("Changing Request Report DotNet - Evolution", "Processing.....");
																		if (modSubscription.Move_All_Subscription_Login_Request_Report_DotNet("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																		{


																			//-- SMS_Text_Message_Queue
																			modSubscription.search_on("Changing SMS Text Message Queue - Homebase", "Processing.....");
																			if (modSubscription.Move_All_Login_SMS_Text_Message_Queue_Records("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																			{

																				//-- SMS_Text_Message_Queue
																				modSubscription.search_on("Changing SMS Text Message Queue - Evolution", "Processing.....");
																				if (modSubscription.Move_All_Login_SMS_Text_Message_Queue_Records("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																				{

																					//-- SMS_Text_Message_Received
																					modSubscription.search_on("Changing SMS Text Message Received - Homebase", "Processing.....");
																					if (modSubscription.Move_All_Login_SMS_Text_Message_Received_Records("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																					{

																						//-- SMS_Text_Message_Received
																						modSubscription.search_on("Changing SMS Text Message Received - Evolution", "Processing.....");
																						if (modSubscription.Move_All_Login_SMS_Text_Message_Received_Records("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																						{

																							//-- EMail_Queue
																							modSubscription.search_on("Changing EMail Queue - Homebase", "Processing.....");
																							if (modSubscription.Move_All_Login_EMail_Queue_Records("Homebase", lCompId, strLogin, lContactId, strContactEMail, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																							{

																								//-- EMail_Queue
																								modSubscription.search_on("Changing EMail Queue - Evolution", "Processing.....");
																								if (modSubscription.Move_All_Login_EMail_Queue_Records("Evolution", lCompId, strLogin, lContactId, strContactEMail, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																								{

																									//-- EMail_Request
																									modSubscription.search_on("Changing EMail Request - Homebase", "Processing.....");
																									if (modSubscription.Move_All_Login_EMail_Request_Records("Homebase", lCompId, strLogin, lContactId, strContactEMail, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																									{

																										//-- EMail_Request
																										modSubscription.search_on("Changing EMail Request - Evolution", "Processing.....");
																										if (modSubscription.Move_All_Login_EMail_Request_Records("Evolution", lCompId, strLogin, lContactId, strContactEMail, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																										{

																											//-- Subscription_Install
																											modSubscription.search_on("Changing Subscription Install - Homebase", "Processing.....");
																											if (modSubscription.Move_All_Login_Subscription_Installs("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																											{

																												//-- Subscription_Install
																												modSubscription.search_on("Changing Subscription Install - Evolution", "Processing.....");
																												if (modSubscription.Move_All_Login_Subscription_Installs("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																												{

																													//-- Subscription_Login
																													modSubscription.search_on("Changing Subscription Login - Homebase", "Processing.....");
																													if (modSubscription.Move_All_Login_Subscription_Login("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																													{

																														//-- Subscription_Login
																														modSubscription.search_on("Changing Subscription Login - Evolution", "Processing.....");
																														if (modSubscription.Move_All_Login_Subscription_Login("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																														{

																															//-- Subscription_Install_Saved_Search_Criteria
																															modSubscription.search_on("Changing Subscription Saved Projects - Homebase", "Processing.....");
																															if (modSubscription.Move_All_Login_Subscription_Saved_Projects("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																															{

																																//-- Subscription_Install_Saved_Search_Criteria
																																modSubscription.search_on("Changing Subscription Saved Projects - Evolution", "Processing.....");
																																if (modSubscription.Move_All_Login_Subscription_Saved_Projects("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																																{

																																	//-- Client_Folder
																																	modSubscription.search_on("Changing Subscription Saved Folders - Homebase", "Processing.....");
																																	if (modSubscription.Move_All_Login_Subscription_Saved_Folders("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																																	{

																																		//-- Client_Folder
																																		modSubscription.search_on("Changing Subscription Saved Folders - Evolution", "Processing.....");
																																		if (modSubscription.Move_All_Login_Subscription_Saved_Folders("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																																		{

																																			//-- Subscription_Install_Saved_Exports
																																			modSubscription.search_on("Changing Subscription Saved Custom Export - Homebase", "Processing.....");
																																			if (modSubscription.Move_All_Login_Subscription_Saved_Custom_Export("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																																			{

																																				//-- Subscription_Install_Saved_Exports
																																				modSubscription.search_on("Changing Subscription Saved Custom Export - Evolution", "Processing.....");
																																				if (modSubscription.Move_All_Login_Subscription_Saved_Custom_Export("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																																				{

																																					//-- Subscription_User_Agent_String
																																					modSubscription.search_on("Changing Subscription User Agent String - Homebase", "Processing.....");
																																					if (modSubscription.Move_All_Login_Subscription_User_Agent_String("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																																					{

																																						//-- Subscription_User_Agent_String
																																						modSubscription.search_on("Changing Subscription User Agent String - Evolution", "Processing.....");
																																						if (modSubscription.Move_All_Login_Subscription_User_Agent_String("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																																						{

																																							//-- Subscription_Notifications
																																							modSubscription.search_on("Changing Subscription Notifications - Homebase", "Processing.....");
																																							if (modSubscription.Move_All_Login_Subscription_Notifications("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																																							{

																																								//-- Subscription_Notifications
																																								modSubscription.search_on("Changing Subscription Notifications - Evolution", "Processing.....");
																																								if (modSubscription.Move_All_Login_Subscription_Notifications("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																																								{

																																									//-- Subscription_Install_Models
																																									modSubscription.search_on("Changing Subscription Install Models - Homebase", "Processing.....");
																																									if (modSubscription.Move_All_Login_Subscription_Install_Models("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																																									{

																																										//-- Subscription_Install_Models
																																										modSubscription.search_on("Changing Subscription Install Models - Evolution", "Processing.....");
																																										if (modSubscription.Move_All_Login_Subscription_Install_Models("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																																										{

																																											//-- Subscription_EULA_Log
																																											modSubscription.search_on("Changing Subscription EULA - Homebase", "Processing.....");
																																											if (modSubscription.Move_All_Login_Subscription_EULA_Log("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																																											{

																																												//-- Subscription_EULA_Log
																																												modSubscription.search_on("Changing Subscription EULA - Evolution", "Processing.....");
																																												if (modSubscription.Move_All_Login_Subscription_EULA_Log("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																																												{

																																													//-- SQL_Report
																																													modSubscription.search_on("Changing SQL Report - Homebase", "Processing.....");
																																													if (modSubscription.Move_All_Login_Subscription_SQL_Report("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																																													{

																																														//-- SQL_Report
																																														modSubscription.search_on("Changing SQL Report - Evolution", "Processing.....");
																																														if (modSubscription.Move_All_Login_Subscription_SQL_Report("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																																														{

																																															//-- Evolution_SessionVars
																																															modSubscription.search_on("Changing Evolution SessionVars - Homebase", "Processing.....");
																																															if (modSubscription.Move_All_Login_Subscription_Evolution_SessionVars("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																																															{

																																																//-- Evolution_SessionVars
																																																modSubscription.search_on("Changing Evolution SessionVars - Evolution", "Processing.....");
																																																if (modSubscription.Move_All_Login_Subscription_Evolution_SessionVars("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																																																{

																																																	//-- Evolution_Content_Stats
																																																	modSubscription.search_on("Changing Evolution Content Stats - Homebase", "Processing.....");
																																																	if (modSubscription.Move_All_Login_Subscription_Evolution_Content_Stats("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																																																	{

																																																		//-- Evolution_Content_Stats
																																																		modSubscription.search_on("Changing Evolution Content Stats - Evolution", "Processing.....");
																																																		if (modSubscription.Move_All_Login_Subscription_Evolution_Content_Stats("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																																																		{

																																																			//-- Chat_Message
																																																			//search_on "Changing Chat Message - Homebase", "Processing....."
																																																			//If Move_All_Login_Subscription_Chat_Message("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																																			//-- Chat_Message
																																																			//search_on "Changing Chat Message - Evolution", "Processing....."
																																																			//If Move_All_Login_Subscription_Chat_Message("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																																			//-- Chat_Log
																																																			//search_on "Changing Chat Log - Homebase", "Processing....."
																																																			//If Move_All_Login_Subscription_Chat_Log("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																																			//-- Chat_Log
																																																			//search_on "Changing Chat Log - Evolution", "Processing....."
																																																			//If Move_All_Login_Subscription_Chat_Log("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																																			//-- Aircraft_Value
																																																			modSubscription.search_on("Changing Aircraft Value - Homebase", "Processing.....");
																																																			if (modSubscription.Move_All_Login_Subscription_Aircraft_Value("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lHBNbrChg, ref strErrMsg))
																																																			{

																																																				//-- Aircraft_Value
																																																				modSubscription.search_on("Changing Aircraft Value - Evolution", "Processing.....");
																																																				if (modSubscription.Move_All_Login_Subscription_Aircraft_Value("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, ref lEvoNbrChg, ref strErrMsg))
																																																				{

																																																					modAdminCommon.Record_Event("Subscription Login Moved", $"Moved Login:=[{strLogin}] From SubId:=[{strCurrSubId}] To New SubId:=[{strNewSubId}] - Completed ", 0, 0, lCompId, false, 0, lContactId);

																																																					strMsg = $"Completed - Login:=[{strLogin}] Moved From SubId:=[{lCurrSubId.ToString()}] To SubId:=[{lNewSubId.ToString()}]";

																																																					modSubscription.AddSubscriptionNote(lCompId, lNewSubId, "Moved Subscription Login", strMsg);
																																																					modSubscription.AddCustomerActivityRecord(lNewSubId, $"Moved Subscription Login {strMsg}");

																																																					modSubscription.search_off();

																																																					Fill_grd_Subscriptions(lCompId);
																																																					bCompleted = true;

																																																				} // If Move_All_Login_Subscription_Aircraft_Value("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																																			} // If Move_All_Login_Subscription_Aircraft_Value("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																																			//End If  ' If Move_All_Login_Subscription_Chat_Log("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																																			//End If ' If Move_All_Login_Subscription_Chat_Log("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																																			//End If ' If Move_All_Login_Subscription_Chat_Message("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																																			//End If ' If Move_All_Login_Subscription_Chat_Message("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																																		} // If Move_All_Login_Subscription_Evolution_Content_Stats("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																																	} // If Move_All_Login_Subscription_Evolution_Content_Stats("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																																} //If Move_All_Login_Subscription_Evolution_SessionVars("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																															} // If Move_All_Login_Subscription_Evolution_SessionVars("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																														} // If Move_All_Login_Subscription_SQL_Report("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																													} // If Move_All_Login_Subscription_SQL_Report("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																												} // If Move_All_Login_Subscription_EULA_Log("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																											} // If Move_All_Login_Subscription_EULA_Log("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																										} // If Move_All_Login_Subscription_Install_Models("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																									} // If Move_All_Login_Subscription_Install_Models("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																								} // If Move_All_Login_Subscription_Notifications("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																							} // If Move_All_Login_Subscription_Notifications("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																						} // If Move_All_Login_Subscription_User_Agent_String("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																					} // If Move_All_Login_Subscription_User_Agent_String("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																				} // If Move_All_Login_Subscription_Saved_Custom_Export("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																			} // If Move_All_Login_Subscription_Saved_Custom_Export("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																		} // If Move_All_Login_Subscription_Saved_Folders("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																																	} // If Move_All_Login_Subscription_Saved_Folders("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																																} // If Move_All_Login_Subscription_Saved_Projects("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																															} // If Move_All_Login_Subscription_Saved_Projects("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																														} // If Move_All_Login_Subscription_Login("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																													} // If Move_All_Login_Subscription_Login("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																												} // If Move_All_Login_Subscription_Installs("Evolution", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																											} // If Move_All_Login_Subscription_Installs("Homebase", lCompId, strLogin, lContactId, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then


																										} // If Move_All_Login_EMail_Request_Records("Evolution", lCompId, strLogin, lContactId, strContactEMail, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																									} // If Move_All_Login_EMail_Request_Records("Homebase", lCompId, strLogin, lContactId, strContactEMail, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																								} // If Move_All_Login_EMail_Queue_Records("Evolution", lCompId, strLogin, lContactId, strContactEMail, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																							} // If Move_All_Login_EMail_Queue_Records("Homebase", lCompId, strLogin, lContactId, strContactEMail, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																						} // If Move_All_Login_SMS_Text_Message_Received_Records("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																					} // If Move_All_Login_SMS_Text_Message_Received_Records("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																				} // If Move_All_Login_SMS_Text_Message_Queue_Records("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																			} // If Move_All_Login_SMS_Text_Message_Queue_Records("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then


																		} // If Move_All_Subscription_Login_Request_Report_DotNet("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

																	} // If Move_All_Subscription_Login_Request_Report_DotNet("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

																} // If Move_All_Subscription_Login_Install_Logs("Evolution", lCompId, strLogin, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

															} // If Move_All_Subscription_Login_Install_Logs("Homebase", lCompId, strLogin, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

														} // If Move_All_Subscription_Login_Event_Logs("Evolution", lCompId, lContactId, strLogin, lCurrSubId, lNewSubId, lEvoNbrChg, strErrMsg) = True Then

													} // If Move_All_Subscription_Login_Event_Logs("Homebase", lCompId, lContactId, strLogin, lCurrSubId, lNewSubId, lHBNbrChg, strErrMsg) = True Then

													if (bCompleted)
													{
														modAdminCommon.Record_Event("Subscription Login Move", $"Completed{strErrMsg}", 0, 0, lCompId, false, 0, lContactId);
														MessageBox.Show($"Process Completed{Environment.NewLine}Subscription Login Has Been Moved", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
													}
													else
													{
														modAdminCommon.Record_Event("Subscription Logion Move", $"Failed: {strErrMsg}", 0, 0, lCompId, false, 0, lContactId);
														MessageBox.Show(strErrMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
													}

												}
												else
												{
													MessageBox.Show("Move Cancelled", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												} // If MsgBox("Move Login [" & strLogin & "] From SubId [" & strCurrSubId & "] To SubId [" & strNewSubId & "]" & vbCrLf & vbCrLf & "Are You Sure?", vbYesNo) = vbYes Then

											}
											else
											{
												MessageBox.Show($"Login [{strLogin}] Already Exists For The New SubId [{strNewSubId}]{Environment.NewLine}{Environment.NewLine}Can NOT Move", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											} // If strLoginTest = "" Then

										}
										else
										{

											if (lCompIdTest == 0)
											{
												MessageBox.Show($"New SubId Entered Is Does NOT Exist{Environment.NewLine}Can NOT Move", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											}
											else
											{
												MessageBox.Show($"New SubId Entered Is NOT Under This Company Record{Environment.NewLine}Can NOT Move", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											}

										} // If lCompId = lCompIdTest Then

									}
									else
									{
										MessageBox.Show($"Current SubId And New SubId Are One And The Same{Environment.NewLine}Can NOT Move", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If lCurrSubId <> lNewSubId Then

								}
								else
								{
									MessageBox.Show($"Value Entered For New SubId Is Not Numeric{Environment.NewLine}Can NOT Move", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If IsNumeric(strNewSubId) = True Then

							} // If Validate_Subscription_Login_Can_Be_Moved(lCompId, lCurrSubId, strLogin) = True Then

							UpgradeHelpers.DB.TransactionManager.DeEnlist(cntCustConn);
							cntCustConn.Close();

						} // If OpenCustomerSQLDatabase(cntCustConn) = True Then

						modSubscription.CloseRemoteDatabase();

					}
					else
					{
						MessageBox.Show($"Unable To Open Connection To Evolution{Environment.NewLine}Can NOT Move", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If OpenRemoteDatabase = True Then

				} // If MsgBox("Move Login To Anther SubId Within This Company Record.  Are You Sure?", vbYesNo) = vbYes Then

				cntCustConn = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				ErrorHandlingHelper.ResumeNext(
					() => {modAdminCommon.ADO_Transaction("RollbackTrans");}, 

					() => {modAdminCommon.Report_Error($"cmdMoveLoginFrame_Click_Error: {strErrDesc}");}, 

					() => {MessageBox.Show($"cmdMoveLoginFrame_Click_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);});
			}

		} // cmdMoveLoginFrame_Click

		private void cmdNewLogin_Click(Object eventSender, EventArgs eventArgs)
		{

			if (!DoesUserHaveAccess())
			{
				return; // Jump Out
			}

			txtLoginName.Text = "";
			txt_sub_password.Text = "";

			frm_authentication.Visible = false;

			// 11/26/2007 - By David D. Cruger; Added
			txt_SubLoginNbrOfInstalls.Text = "0";
			txt_SubLoginContractAmount.Text = "0.00";

			chkLoginFlag[(int) modSubscription.iCHKLOGINACTIVE].CheckState = CheckState.Checked;
			chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState = CheckState.Unchecked; // 01/27/2003 - By David D. Cruger; New

			// 05/02/2008 - By David D. Cruger
			chkLoginFlag[(int) modSubscription.iCHKLOGINEXPORT].CheckState = CheckState.Checked;
			chkLoginFlag[(int) modSubscription.iCHKLOGINLOCALNOTES].CheckState = CheckState.Checked;
			chkLoginFlag[(int) modSubscription.iCHKLOGINPROJECTS].CheckState = CheckState.Checked;
			chkLoginFlag[(int) modSubscription.iCHKLOGINEMAILREQUEST].CheckState = CheckState.Checked;
			chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].CheckState = CheckState.Checked;

			// 06/09/2009 - By David D. Cruger
			chkLoginFlag[(int) modSubscription.iCHKLOGINTEXTMSG].CheckState = CheckState.Checked;

			// 01/18/2010 - By David D. Cruger
			chkLoginFlag[(int) modSubscription.iCHKLOGINBYPASSACTIVEX].CheckState = CheckState.Unchecked;

			// 09/20/2019 - By David D. Cruger
			chkLoginFlag[(int) modSubscription.iCHKLOGINVALUES].CheckState = CheckState.Unchecked;
			chkLoginFlag[(int) modSubscription.iCHKLOGINMPM].CheckState = CheckState.Unchecked;

			grd_Logins.Enabled = false;
			grd_Logins.Visible = false;
			fraLogin.Enabled = true;
			fraLogin.Visible = true;
			fraLogin.BringToFront();
			cbo_build.Text = "B"; // want to default any new build to be "B" for now

			cmdNewLogin.Enabled = false;
			cmd_DeleteLogin.Enabled = false;
			cmdEMailSubNotice.Enabled = false;
			lblSubAddInstall.Enabled = false;
			cmd_New_Installation.Enabled = false;

			string strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();
			string strSubId = ($"{txt_sub_id.Text} ").Trim();

			// 03/16/2004 - By David D. Cruger; Use the chkMarketingFlag
			if (chkProductType[modSubscription.ProductMarketing].CheckState == CheckState.Checked)
			{
				chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState = CheckState.Checked;
				cmdResetDemoLogin.Visible = true;
			}
			else
			{
				cmdResetDemoLogin.Visible = false;
			}

			Mode = "LoginAdd";

			if (chkProductType[13].CheckState == CheckState.Unchecked)
			{
				txtLoginName.Focus();
			}


			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdNewLogin_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdNewLogin_Click(cmdNewLogin, new EventArgs());
			}

		}

		private void cmdResetDemoLogin_Click(Object eventSender, EventArgs eventArgs)
		{

			string strErrDesc = "";
			int lErrNbr = 0;
			string strMsg = "";

			int lCompId = 0;
			int lSubId = 0;
			string strLogin = "";

			try
			{

				if (chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState == CheckState.Checked)
				{

					if (MessageBox.Show($"Reset Demo Account?{Environment.NewLine}This Will Reset The Password{Environment.NewLine}Clear The Install Date{Environment.NewLine}And Delete All Saved Projects/Folders{Environment.NewLine}{Environment.NewLine}Are you Sure?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
					{

						lCompId = modSubscription.Entered_Company_ID;
						lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));
						strLogin = txtLoginName.Text.Trim();

						strMsg = $"Reset Demo Account. SubId:=[{lSubId.ToString()}  Login:=[{strLogin}]";

						modAdminCommon.Record_Event("Subscription", strMsg, 0, 0, lCompId);

						modSubscription.search_on("Resetting Demo Account...", "Generating New Password");

						cmdGeneratePassword_Click(cmdGeneratePassword, new EventArgs());

						modCommon.DelaySeconds(2);

						modSubscription.search_on("Resetting Demo Account...", "Clearing Install Date");

						ClearInstallDate(true);

						modSubscription.search_on("Resetting Demo Account...", "Clearing Saved Projects/Folders");

						ClearSavedProjectsFolders(lSubId, strLogin, -1, true);

						chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState = CheckState.Checked;
						chkLoginFlag_CheckStateChanged(chkLoginFlag[(int) iLOGINDEMO], new EventArgs());

						modCommon.DelaySeconds(2);

						//-------------------------------
						// Upload Changes To Website

						cmdUpload_Click(cmdUpload, new EventArgs());

						cmdCancelLoginFrame_Click(cmdCancelLoginFrame, new EventArgs());

						grd_Logins_Click(grd_Logins, new EventArgs());

						modSubscription.search_off();

					} // If MsgBox("Reset Demo Account?" & vbCrLf & "This will reset the password" & vbCrLf & "Clear the Install Date" & vbCrLf & "And Delete all Saved Projects/Folders" & vbCrLf & vbCrLf & "Continue? Are you Sure?", vbYesNo + vbCritical) = vbYes Then

				}
				else
				{
					MessageBox.Show($"This is NOT a Demo Account{Environment.NewLine}{Environment.NewLine}Reset Will NOT Work", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If chkLoginFlag(iCHKLOGINDEMO).Value = vbChecked Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				modAdminCommon.Report_Error($"cmdUpdateCRMSite_Click_Error: {strErrDesc}");
				MessageBox.Show($"cmdUpdateCRMSite_Click_Error{Environment.NewLine}{strErrDesc}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // cmdResetDemoLogin_Click

		private void cmdSaveSSCNotes_Click()
		{

			string strUpdate1 = "";
			string strRegId = "";
			string strMsg = "";
			string strDatabase = "";
			int iPos1 = 0;

			string strSubId = txt_sub_id.Text;
			string strCompId = modSubscription.Entered_Company_ID.ToString();
			int lCompId = Convert.ToInt32(Double.Parse(strCompId));

			if (strSubId != "" && strSubId != "0")
			{

				strMsg = "Saving Server Side Notes Subscription Information ";
				modSubscription.search_on(strMsg, "Don't Forget To Update Website");

				strUpdate1 = "UPDATE Subscription SET  sub_server_side_notes_flag = ";

				// if it isnt checked, then clear- SMW - 7/27/21
				if (chkServerSideNotes.CheckState == CheckState.Checked)
				{
					strUpdate1 = $"{strUpdate1}'Y', ";
					strMsg = $"{strMsg}[ON]";


					strDatabase = ($"{cmbCRMDatabaseName.Text} ").Trim();

					iPos1 = (strDatabase.IndexOf('|') + 1);
					if (iPos1 > 0)
					{
						strDatabase = strDatabase.Substring(Math.Min(iPos1, strDatabase.Length)).Trim(); // Removes Company Name
					}

					strUpdate1 = $"{strUpdate1}sub_server_side_dbase_name = ";
					if (strDatabase != "")
					{
						strUpdate1 = $"{strUpdate1}'{strDatabase}', ";
					}
					else
					{
						strUpdate1 = $"{strUpdate1}NULL, ";
					}

					strUpdate1 = $"{strUpdate1}sub_server_side_crm_regid = ";
					strRegId = ($"{txtCRMRegId.Text} ").Trim();
					strRegId = StringsHelper.Replace(strRegId, ",", "", 1, -1, CompareMethod.Binary);
					if (Information.IsNumeric(strRegId))
					{
						strUpdate1 = $"{strUpdate1}{strRegId}, ";
					}
					else
					{
						strUpdate1 = $"{strUpdate1}0, ";
					}



				}
				else
				{
					strUpdate1 = $"{strUpdate1}'N', ";
					strMsg = $"{strMsg}[OFF]";
					strUpdate1 = $"{strUpdate1}sub_server_side_dbase_name = NULL, ";

					strUpdate1 = $"{strUpdate1}sub_server_side_crm_regid = 0, ";
				}



				strUpdate1 = $"{strUpdate1}sub_action_date = '01/01/1900' WHERE (sub_id = {strSubId}) ";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strUpdate1;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				modAdminCommon.Record_Event("Subscription", strMsg, 0, 0, lCompId);

				modCommon.DelaySeconds(3);

				modSubscription.search_off();

			}
			else
			{
				MessageBox.Show("SubId Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If strSubId <> "" And strSubId <> "0" Then

		} // cmdSaveSSCNotes_Click

		private void cmdExportSSCNotes_Click()
		{

			DbConnection cntMySQL = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();

			string strQuery1 = "";
			string strQuery2 = "";

            ExcelApplication objExcel = null; //gap-note Review excel type during stabilization
            ExcelApplication objExcelWB = null; //gap-note Review excel type during stabilization
            ExcelApplication objExcelWS = null; //gap-note Review excel type during stabilization




			string strMsg = "";




			string lACId = "";
			string strMake = "";
			string strModel = "";
			string strSerNbr = "";

			string strCompany = "";
			string strCity = "";
			string strState = "";
			string strCOUNTRY = "";

			string strUser = "";
			string strDate = "";
			string strNote = "";

			string strErrMsg = "";

			cmdSubNotesButton[ExportSSCNotes].Enabled = false;

			int lCompId = 0;
			int lSubId = 0;
			int lCRegId = 0;

			int lExcelRow = 0;
			int lExcelCol = 0;

			int lTot1 = 0;
			int lCnt1 = 0;

			lCompId = modSubscription.Entered_Company_ID;
			string strCompId = lCompId.ToString();

			string strSubId = txt_sub_id.Text;
			if (Information.IsNumeric(strSubId))
			{
				lSubId = Convert.ToInt32(Double.Parse(strSubId));
			}

			string strCRegId = txtCRMRegId.Text;
			if (Information.IsNumeric(strCRegId))
			{
				lCRegId = Convert.ToInt32(Double.Parse(strCRegId));
			}

			string strDatabase = ($"{cmbCRMDatabaseName.Text} ").Trim();
			int iPos1 = (strDatabase.IndexOf('|') + 1);
			if (iPos1 > 0)
			{
				strDatabase = strDatabase.Substring(Math.Min(iPos1, strDatabase.Length)).Trim(); // Removes Company Name
			}

			if (lCompId > 0)
			{

				if (lSubId > 0)
				{

					if (chkServerSideNotes.CheckState == CheckState.Checked)
					{

						if (strDatabase != "")
						{

							if (lCRegId > 0)
							{

								strMsg = "Exporting Server Side Notes To Excel";
								modSubscription.search_on(strMsg, "Total Record(s) Found: 0    Exporting: 0");

								strMsg = $"{strMsg} - CRegId: {strCRegId} Database: {strDatabase}";

								modAdminCommon.Record_Event("Subscription", strMsg, 0, 0, lCompId);

								if (modCommon.Open_CRM_Server_Side_Notes_Database_Connection(ref cntMySQL, lCRegId, ref strErrMsg))
								{

									modExcel.OpenExcel(ref objExcel, ref objExcelWB, ref objExcelWS, false);

									//-----------------------------------
									// Create Worksheet Aircraft Notes

									//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWB.Worksheets("Sheet1").Activate();
									//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS = objExcelWB.Worksheets("Sheet1");
									//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Name = "Aircraft Notes";

									//-----------------------------------
									// Headers

									lExcelRow++;
									lExcelCol = 0;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "MAKE";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 30;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "MODEL";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 30;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "SERNBR";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 25;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "USER";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 20;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "DATE";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 20;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "NOTE";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 150;

									strQuery1 = "SELECT * FROM local_notes WHERE (lnote_jetnet_ac_id > 0) AND (lnote_note IS NOT NULL) ";
									strQuery1 = $"{strQuery1}AND (lnote_note <> '') ORDER BY lnote_jetnet_ac_id, lnote_id";

									rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
									rstRec1.Open(strQuery1, cntMySQL, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

									if (!rstRec1.BOF && !rstRec1.EOF)
									{

										lTot1 = rstRec1.RecordCount;
										lCnt1 = 0;

										do 
										{ // Loop Until rstRec1.EOF = True

											lCnt1++;

											strMsg = "Exporting Server Side Notes To Excel";
											modSubscription.search_on(strMsg, $"Total Aircraft Record(s) Found: {StringsHelper.Format(lTot1, "#,##0")}   Exporting: {StringsHelper.Format(lCnt1, "#,##0")}");

											lACId = Convert.ToString(rstRec1["lnote_jetnet_ac_id"]);

											strDate = "";
											if (Information.IsDate(rstRec1["lnote_entry_date"]))
											{
												if (Convert.ToDateTime(rstRec1["lnote_entry_date"]) >= DateTime.Parse("1/1/1988"))
												{
													strDate = StringsHelper.Format(rstRec1["lnote_entry_date"], "mm/dd/yyyy hh:MM:ss AMPM");
												}
											}

											strUser = ($"{Convert.ToString(rstRec1["lnote_user_name"])} ").Trim();
											strNote = ($"{Convert.ToString(rstRec1["lnote_note"])} ").Trim();
											strNote = StringsHelper.Replace(strNote, "&#13;&#10;", Environment.NewLine, 1, -1, CompareMethod.Binary);

											strMake = "Unknown";
											strModel = "Unknown";
											strSerNbr = "Unknown";

											if (StringsHelper.ToDoubleSafe(lACId) > 0)
											{

												strQuery2 = "SELECT amod_make_name, amod_model_name, ac_ser_no_full  FROM Aircraft_Model WITH (NOLOCK) ";
												strQuery2 = $"{strQuery2}INNER JOIN Aircraft WITH (NOLOCK) ON ac_amod_id = amod_id ";
												strQuery2 = $"{strQuery2}WHERE (ac_id = {lACId}) AND (ac_journ_id = 0) ";

												rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

												if (!rstRec2.BOF && !rstRec2.EOF)
												{
													strMake = ($"{Convert.ToString(rstRec2["amod_make_name"])} ").Trim();
													strModel = ($"{Convert.ToString(rstRec2["amod_model_name"])} ").Trim();
													strSerNbr = ($"{Convert.ToString(rstRec2["ac_ser_no_full"])} ").Trim();
												} // If (rstRec2.BOF = False And rstRec2.EOF = False) Then
												rstRec2.Close();

											} // If lACId > 0 Then

											lExcelRow++;
											lExcelCol = 0;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strMake;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strModel;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strSerNbr;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strUser;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strDate;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strNote;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											rstRec1.MoveNext();
											Application.DoEvents();

										}
										while(!rstRec1.EOF);

									}
									else
									{
										MessageBox.Show("No Aircraft Records Found In Server Side Notes Table", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

									rstRec1.Close();

									//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS = objExcel.Worksheets().Add;
									//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Name = "Company Notes";
									//UPGRADE_WARNING: (7006) The Named argument After was not resolved and corresponds to the following expression objExcelWB.Sheets() More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
									//UPGRADE_TODO: (1067) Member Sheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									//UPGRADE_TODO: (1067) Member Move is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Move(objExcelWB.Sheets("Aircraft Notes"));

									lExcelRow = 0;

									lExcelRow++;
									lExcelCol = 0;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "COMPANY";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 30;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "CITY";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 30;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "STATE";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 10;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "COUNTRY";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 25;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "USER";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 20;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "DATE";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 20;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "NOTE";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 150;

									strQuery1 = "SELECT * FROM local_notes WHERE (lnote_jetnet_comp_id > 0) AND (lnote_note IS NOT NULL)  AND (lnote_note <> '') ";
									strQuery1 = $"{strQuery1}ORDER BY lnote_jetnet_comp_id, lnote_id";

									rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
									rstRec1.Open(strQuery1, cntMySQL, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

									if (!rstRec1.BOF && !rstRec1.EOF)
									{

										lTot1 = rstRec1.RecordCount;
										lCnt1 = 0;

										do 
										{ // Loop Until rstRec1.EOF = True

											lCnt1++;

											strMsg = "Exporting Server Side Notes To Excel";
											modSubscription.search_on(strMsg, $"Total Company Record(s) Found: {StringsHelper.Format(lTot1, "#,##0")}   Exporting: {StringsHelper.Format(lCnt1, "#,##0")}");

											lCompId = Convert.ToInt32(rstRec1["lnote_jetnet_comp_id"]);

											strDate = "";
											if (Information.IsDate(rstRec1["lnote_entry_date"]))
											{
												if (Convert.ToDateTime(rstRec1["lnote_entry_date"]) >= DateTime.Parse("1/1/1988"))
												{
													strDate = StringsHelper.Format(rstRec1["lnote_entry_date"], "mm/dd/yyyy hh:MM:ss AMPM");
												}
											}

											strUser = ($"{Convert.ToString(rstRec1["lnote_user_name"])} ").Trim();
											strNote = ($"{Convert.ToString(rstRec1["lnote_note"])} ").Trim();
											strNote = StringsHelper.Replace(strNote, "&#13;&#10;", Environment.NewLine, 1, -1, CompareMethod.Binary);

											strCompany = "Unknown";
											strCity = "";
											strState = "";
											strCOUNTRY = "";

											if (lCompId > 0)
											{

												strQuery2 = "SELECT comp_name, comp_city, comp_state, comp_country  FROM Company WITH (NOLOCK) ";
												strQuery2 = $"{strQuery2}WHERE (comp_id = {lCompId.ToString()}) AND (comp_journ_id = 0) ";

												rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

												if (!rstRec2.BOF && !rstRec2.EOF)
												{
													strCompany = ($"{Convert.ToString(rstRec2["comp_name"])} ").Trim();
													strCity = ($"{Convert.ToString(rstRec2["Comp_city"])} ").Trim();
													strState = ($"{Convert.ToString(rstRec2["comp_state"])} ").Trim();
													strCOUNTRY = ($"{Convert.ToString(rstRec2["Comp_country"])} ").Trim();
												} // If (rstRec2.BOF = False And rstRec2.EOF = False) Then
												rstRec2.Close();

											} // If lCompId > 0 Then

											lExcelRow++;
											lExcelCol = 0;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strCompany;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strCity;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strState;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strCOUNTRY;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strUser;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strDate;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strNote;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											rstRec1.MoveNext();
											Application.DoEvents();

										}
										while(!rstRec1.EOF);

									}
									else
									{
										MessageBox.Show("No Company Records Found In Server Side Notes Table", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

									rstRec1.Close();

									//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS = objExcelWB.Worksheets("Aircraft Notes");
									//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWB.Worksheets("Aircraft Notes").Activate();

									modCommon.CloseCRMServerSideNotesDatabase(ref cntMySQL);

								}
								else
								{
									MessageBox.Show("Unable To Open Server Side Notes Database", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If Open_CRM_Server_Side_Notes_Database_Connection(cntMySQL, lCRegId, strErrMsg) = True Then

							}
							else
							{
								MessageBox.Show("Server Side Notes CRegId Is Blank Or Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If lCRegId > 0 Then

						}
						else
						{
							MessageBox.Show("Server Side Notes Database Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If strDatabase <> "" Then

					}
					else
					{
						MessageBox.Show("Server Side Notes Is NOT Checked", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If chkServerSideNotes.Value = vbChecked Then

				}
				else
				{
					MessageBox.Show("SubId Is Blank Or Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If lSubId > 0 Then

			}
			else
			{
				MessageBox.Show("CompId Is Blank Or Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If lCompId > 0 Then

			cmdSubNotesButton[ExportSSCNotes].Enabled = true;

			modExcel.DisposeExcel(ref objExcel, ref objExcelWB, ref objExcelWS);

			rstRec2 = null;
			rstRec1 = null;
			cntMySQL = null;

			modSubscription.search_off();

		} // cmdExportSSCNotes_Click

		private void cmdSaveCloudNotes_Click()
		{

			string strUpdate1 = "";
			string strMsg = "";
			int iPos1 = 0;
			string strDatabase = "";

			string strSubId = txt_sub_id.Text;
			string strCompId = modSubscription.Entered_Company_ID.ToString();
			int lCompId = Convert.ToInt32(Double.Parse(strCompId));

			if (strSubId != "" && strSubId != "0")
			{

				strDatabase = ($"{cmbCloudNotesDatabaseName.Text} ").Trim();

				if ((chkCloudNotesFlag.CheckState == CheckState.Unchecked) || (chkCloudNotesFlag.CheckState == CheckState.Checked && strDatabase != ""))
				{

					strMsg = "Saving Evolution Cloud Notes Subscription Information - Status ";
					modSubscription.search_on(strMsg, "Don't Forget To Update Website");

					strUpdate1 = "UPDATE Subscription SET sub_cloud_notes_flag  = ";
					if (chkCloudNotesFlag.CheckState == CheckState.Checked)
					{
						strUpdate1 = $"{strUpdate1}'Y', ";
						strMsg = $"{strMsg}[ON] - Database: [{($"{cmbCloudNotesDatabaseName.Text} ").Trim()}]";
					}
					else
					{
						strUpdate1 = $"{strUpdate1}'N', ";
						strMsg = $"{strMsg}[OFF]";
					}

					iPos1 = (strDatabase.IndexOf(" - ") + 1);
					if (iPos1 > 0)
					{
						strDatabase = strDatabase.Substring(0, Math.Min(iPos1, strDatabase.Length)).Trim(); // Removes Company Name
					}

					strUpdate1 = $"{strUpdate1}sub_cloud_notes_database = ";
					if (strDatabase != "")
					{
						strUpdate1 = $"{strUpdate1}'{strDatabase}', ";
					}
					else
					{
						strUpdate1 = $"{strUpdate1}NULL, ";
					}

					strUpdate1 = $"{strUpdate1}sub_action_date = '01/01/1900' ";

					strUpdate1 = $"{strUpdate1}WHERE (sub_id = {strSubId}) ";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strUpdate1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					modAdminCommon.Record_Event("Subscription", strMsg, 0, 0, lCompId);

					modCommon.DelaySeconds(3);

					modSubscription.search_off();

				}
				else
				{
					MessageBox.Show("Cloud Notes Database Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (chkCloudNotesFlag.Value = vbUnchecked) Or (chkCloudNotesFlag.Value = vbChecked And strDatabase <> "") Then

			}
			else
			{
				MessageBox.Show("SubId Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If strSubId <> "" And strSubId <> "0" Then

		} // cmdSaveCloudNotes_Click

		private void cmdExportCloudNotes_Click()
		{

			DbConnection cntEvoCN = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();

			string strQuery1 = "";
			string strQuery2 = "";

            ExcelApplication objExcel = null; //gap-note Review excel type during stabilization
            ExcelApplication objExcelWB = null; //gap-note Review excel type during stabilization
            ExcelApplication objExcelWS = null; //gap-note Review excel type during stabilization



			string strMsg = "";




			string lACId = "";
			string strMake = "";
			string strModel = "";
			string strSerNbr = "";

			string strUser = "";
			string strDate = "";
			string strNote = "";

			string strErrMsg = "";

			cmdSubNotesButton[ExportCloudNotes].Enabled = false;

			int lCompId = 0;
			int lSubId = 0;

			int lExcelRow = 0;
			int lExcelCol = 0;

			int lTot1 = 0;
			int lCnt1 = 0;

			lCompId = modSubscription.Entered_Company_ID;
			string strCompId = lCompId.ToString();

			string strSubId = txt_sub_id.Text;
			if (Information.IsNumeric(strSubId))
			{
				lSubId = Convert.ToInt32(Double.Parse(strSubId));
			}

			string strTableName = ($"{cmbCloudNotesDatabaseName.Text} ").Trim();

			if (lCompId > 0)
			{

				if (lSubId > 0)
				{

					if (chkCloudNotesFlag.CheckState == CheckState.Checked)
					{

						if (strTableName != "")
						{

							strMsg = "Exporting Cloud Notes To Excel";
							modSubscription.search_on(strMsg, "Total Record(s) Found: 0    Exporting: 0");

							strMsg = $"{strMsg} - Table Name: {strTableName}";

							modAdminCommon.Record_Event("Subscription", strMsg, 0, 0, lCompId);

							if (modCommon.Open_Cloud_Notes_Database_Connection(ref cntEvoCN, ref strErrMsg))
							{

								if (modCommon.Does_Company_Cloud_Notes_Table_Exist(cntEvoCN, lCompId, ref strErrMsg))
								{

									modExcel.OpenExcel(ref objExcel, ref objExcelWB, ref objExcelWS, false);

									//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWB.Worksheets("Sheet1").Activate();
									//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS = objExcelWB.Worksheets("Sheet1");
									//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Name = "Aircraft Notes";

									lExcelRow++;
									lExcelCol = 0;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "MAKE";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 30;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "MODEL";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 30;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "SERNBR";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 25;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "USER";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 20;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "DATE";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 20;

									lExcelCol++;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = "NOTE";
									//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Columns(lExcelCol).ColumnWidth = 150;

									strQuery1 = $"SELECT * FROM {strTableName} WHERE (cn_ac_id > 0) ";
									strQuery1 = $"{strQuery1}AND (cn_notes IS NOT NULL) ORDER BY cn_ac_id, cn_id";

									rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
									rstRec1.Open(strQuery1, cntEvoCN, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

									if (!rstRec1.BOF && !rstRec1.EOF)
									{

										lTot1 = rstRec1.RecordCount;
										lCnt1 = 0;

										do 
										{ // Loop Until rstRec1.EOF = True

											lCnt1++;

											strMsg = "Exporting Cloud Notes To Excel";
											modSubscription.search_on(strMsg, $"Total Aircraft Record(s) Found: {StringsHelper.Format(lTot1, "#,##0")}   Exporting: {StringsHelper.Format(lCnt1, "#,##0")}");

											lACId = Convert.ToString(rstRec1["cn_ac_id"]);

											strDate = "";
											if (Information.IsDate(rstRec1["cn_entry_date"]))
											{
												if (Convert.ToDateTime(rstRec1["cn_entry_date"]) >= DateTime.Parse("1/1/1988"))
												{
													strDate = StringsHelper.Format(rstRec1["cn_entry_date"], "mm/dd/yyyy hh:MM:ss AMPM");
												}
											}

											strUser = ($"{Convert.ToString(rstRec1["cn_user_name"])} ").Trim();
											strNote = ($"{Convert.ToString(rstRec1["cn_notes"])} ").Trim();
											strNote = StringsHelper.Replace(strNote, "&#13;&#10;", Environment.NewLine, 1, -1, CompareMethod.Binary);

											strMake = "Unknown";
											strModel = "Unknown";
											strSerNbr = "Unknown";

											if (StringsHelper.ToDoubleSafe(lACId) > 0)
											{

												strQuery2 = "SELECT amod_make_name, amod_model_name, ac_ser_no_full ";
												strQuery2 = $"{strQuery2}FROM Aircraft_Model WITH (NOLOCK) ";
												strQuery2 = $"{strQuery2}INNER JOIN Aircraft WITH (NOLOCK) ON ac_amod_id = amod_id ";
												strQuery2 = $"{strQuery2}WHERE (ac_id = {lACId}) AND (ac_journ_id = 0) ";

												rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

												if (!rstRec2.BOF && !rstRec2.EOF)
												{
													strMake = ($"{Convert.ToString(rstRec2["amod_make_name"])} ").Trim();
													strModel = ($"{Convert.ToString(rstRec2["amod_model_name"])} ").Trim();
													strSerNbr = ($"{Convert.ToString(rstRec2["ac_ser_no_full"])} ").Trim();
												} // If (rstRec2.BOF = False And rstRec2.EOF = False) Then
												rstRec2.Close();

											} // If lACId > 0 Then

											lExcelRow++;
											lExcelCol = 0;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strMake;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strModel;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strSerNbr;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strUser;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strDate;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											lExcelCol++;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).Value = strNote;
											//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
											objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;

											rstRec1.MoveNext();
											Application.DoEvents();

										}
										while(!rstRec1.EOF);

									}
									else
									{
										MessageBox.Show("No Aircraft Records Found In Cloud Notes Table", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

									rstRec1.Close();

									modCommon.Close_Cloud_Notes_Database_Connection(cntEvoCN, ref strErrMsg);

								}
								else
								{
									MessageBox.Show("Cloud Notes Table Does Not Exist", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If Does_Company_Cloud_Notes_Table_Exist(cntEvoCN, lCompId, strErrMsg) = True Then

							}
							else
							{
								MessageBox.Show("Unable To Open Cloud Notes Database", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If Open_Cloud_Notes_Database_Connection(cntEvoCN, strErrMsg) = True Then

						}
						else
						{
							MessageBox.Show("Cloud Notes Database Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If strTableName <> "" Then

					}
					else
					{
						MessageBox.Show("Cloud Notes Is NOT Checked", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If chkCloudNotesFlag.Value = vbChecked Then

				}
				else
				{
					MessageBox.Show("SubId Is Blank Or Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If lSubId > 0 Then

			}
			else
			{
				MessageBox.Show("CompId Is Blank Or Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If lCompId > 0 Then

			cmdSubNotesButton[ExportCloudNotes].Enabled = true;

			modExcel.DisposeExcel(ref objExcel, ref objExcelWB, ref objExcelWS);

			rstRec2 = null;
			rstRec1 = null;
			cntEvoCN = null;

			modSubscription.search_off();

		} // cmdExportCloudNotes_Click

		private void cmdStopImportCloudNotesToCRMSSNotes_Click() => cmdSubNotesButton[StopImportCloudNotesToCRMSSNotes].Enabled = false;


		private void cmdStopImportCRMSSNotesToCloudNotes_Click() => cmdSubNotesButton[StopImportCRMSSNotesToCloudNotes].Enabled = false;


		private void cmdStopImportEvoLocalNotesToCloudNotes_Click() => cmdSubNotesButton[StopImportEvoLocalNotesToCloudNotes].Enabled = false;


		private void cmdSubDocumentDelete_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();
			string strDelete1 = "";
			string strDocumentId = "";
			string strCompId = "";
			int lCompId = 0;

			string strDocFileName = "";
			string strFileName = "";

			try
			{

				if (cmdSubDocumentDelete.Enabled)
				{

					// Disable Delete Button
					cmdSubDocumentDelete.Enabled = false;

					// Get Document Id and CompId
					strDocumentId = ($"{txtSubDocumentId.Text} ").Trim();
					strCompId = modSubscription.Entered_Company_ID.ToString();
					lCompId = Convert.ToInt32(Double.Parse(strCompId));

					if (Convert.ToString(txtSubDragDocument.Tag) != "")
					{

						// Clear The WebBrowser
						wbSubBrowser1[0].Navigate(new Uri("about:blank")); // Make Sure It's Not Open
						modCommon.DelaySeconds(1);

						strDocFileName = ($"{Convert.ToString(txtSubDragDocument.Tag)} ").Trim();
						strFileName = "";

						//------------------------------
						// If File Exists Delete It
						//------------------------------
						if (File.Exists(strDocFileName))
						{
							//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2099
							strFileName = FileSystem.Dir(strDocFileName); // Returns Just The File Name No Path
							//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							File.Delete(strDocFileName);
						} // If fso.FileExists(strDocFileName) = True Then

						strDelete1 = $"DELETE Company_Documents WHERE (compdoc_id = {strDocumentId}) ";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strDelete1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						modAdminCommon.Record_Event("User Action", $"Delete Contract Document: {strFileName}", 0, 0, lCompId);

					} // If txtSubDragDocument.Tag <> "" Then

					Load_Subscription_Documents_Grid();

					cmdSubDocumentNew_Click(cmdSubDocumentNew, new EventArgs());

				} // If cmdSubDocumentDelete.Enabled = True Then

				fso = null;
			}
			catch
			{
			}


		} // cmdSubDocumentDelete_Click

		private void cmdSubDocumentMove_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strQuery2 = "";

			string strUpdate1 = "";
			string strDocumentId = "";
			string strCompId = "";
			int lCompId = 0;

			string strNewCompId = "";
			int lNewCompId = 0;

			string strDocDir = "";

			string strDocFileName = "";
			string strFileName = "";

			string strNewDocFileName = "";
			string strNewFileName = "";

			string strCompany = "";
			string strCity = "";

			try
			{

				if (cmdSubDocumentMove.Enabled)
				{

					// Disable Move Button
					cmdSubDocumentMove.Enabled = false;

					// Get Document Id and CompId
					strDocumentId = ($"{txtSubDocumentId.Text} ").Trim();
					strCompId = modSubscription.Entered_Company_ID.ToString();
					lCompId = Convert.ToInt32(Double.Parse(strCompId));

					if (Convert.ToString(txtSubDragDocument.Tag) != "")
					{

						strNewCompId = InputBoxHelper.InputBox("Enter New Company Id", "Move Contract");

						if (strNewCompId != "")
						{

							lNewCompId = 0;
							if (Information.IsNumeric(strNewCompId))
							{
								lNewCompId = Convert.ToInt32(Double.Parse(strNewCompId));
							}

							if (lNewCompId > 0)
							{

								if (strCompId != strNewCompId)
								{

									strQuery1 = "SELECT comp_id, comp_name, comp_city FROM Company WITH (NOLOCK) ";
									strQuery1 = $"{strQuery1}WHERE (comp_id = {lNewCompId.ToString()}) AND (comp_journ_id = 0) ";

									rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

									if ((!rstRec1.BOF) && (!rstRec1.EOF))
									{

										strCompany = ($"{Convert.ToString(rstRec1["comp_name"])} ").Trim();
										strCity = ($"{Convert.ToString(rstRec1["Comp_city"])} ").Trim();

										if (MessageBox.Show($"Move To Company: [{strNewCompId}]{Environment.NewLine}{strCompany}, {strCity}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
										{

											//--------------------------------------
											// Clear The WebBrowser
											wbSubBrowser1[0].Navigate(new Uri("about:blank")); // Make Sure It's Not Open
											modCommon.DelaySeconds(1);

											strQuery2 = $"SELECT * FROM Company_Documents WHERE (compdoc_id = {strDocumentId}) ";

											rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

											if ((!rstRec2.BOF) && (!rstRec2.EOF))
											{

												strDocDir = modCommon.DLookUp("aconfig_customer_contract_dir", "Application_Configuration");

												strFileName = ($"{Convert.ToString(rstRec2["compdoc_filename"])} ").Trim();
												strDocFileName = $"{strDocDir}\\{strFileName}";

												strNewFileName = StringsHelper.Replace(strFileName, $"{strCompId}-", $"{strNewCompId}-", 1, -1, CompareMethod.Binary);
												strNewDocFileName = $"{strDocDir}\\{strNewFileName}";

												if (!File.Exists(strNewDocFileName))
												{

													if (File.Exists(strDocFileName))
													{

														File.Move(strDocFileName, strNewDocFileName);

														strUpdate1 = $"UPDATE Company_Documents SET compdoc_comp_id = {strNewCompId}, ";
														strUpdate1 = $"{strUpdate1}compdoc_filename = '{strNewFileName}', ";
														strUpdate1 = $"{strUpdate1}compdoc_backup_date = NULL WHERE (compdoc_id = {strDocumentId}) ";

														DbCommand TempCommand = null;
														TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
														UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
														TempCommand.CommandText = strUpdate1;
														//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
														//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
														TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
														UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
														TempCommand.ExecuteNonQuery();

														modAdminCommon.Record_Event("User Action", $"Moved Contract Document: {strFileName} To {strNewFileName}", 0, 0, lCompId);

													}
													else
													{
														MessageBox.Show($"ERROR: Old Document File Does NOT Exist [{strFileName}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
													} // If fso.FileExists(strDocFileName) = True Then

												}
												else
												{
													MessageBox.Show($"ERROR: New Document File Already Exists [{strNewFileName}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												} // If fso.FileExists(strNewDocFileName) = False Then

											}
											else
											{
												MessageBox.Show($"ERROR: Could NOT Find Document Record [{strDocumentId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											} // If (rstRec2.BOF = False) And (rstRec2.EOF = False) Then

											rstRec2.Close();

										} // If MsgBox("Move To Company" & vbCrLf & strCompany & ", " & strCity, vbYesNo) = vbYes Then

									}
									else
									{
										MessageBox.Show($"New CompId Is Not On File [{strNewCompId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

									rstRec1.Close();

								}
								else
								{
									MessageBox.Show($"New CompId Equals Old CompId [{strCompId}]=[{strNewCompId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If strCompId <> strNewCompId Then

							}
							else
							{
								MessageBox.Show($"New CompId Is Invalid [{strNewCompId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If lNewCompId > 0 Then

						} // If strNewCompId <> "" Then

					} // If txtSubDragDocument.Tag <> "" Then

					Load_Subscription_Documents_Grid();

					cmdSubDocumentNew_Click(cmdSubDocumentNew, new EventArgs());

				} // If cmdSubDocumentDelete.Enabled = True Then

				fso = null;
				rstRec2 = null;
				rstRec1 = null;
			}
			catch
			{
			}


		} // cmdSubDocumentMove_Click

		private void cmdSubDocumentNew_Click(Object eventSender, EventArgs eventArgs)
		{

			txtSubDocumentId.Text = "0";
			cmbSubDocumentType.Text = "";
			cmbSubDocumentType.Tag = "";
			txtSubDocumentSubject.Text = "";
			txtSubDocumentDescription.Text = "";
			txtSubDocumentId.Text = "0";
			calSubDocumentDate.SetDate(DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")));
			txtSubDocumentDate.Text = "";

			txtSubExpirationDate.Text = "";
			Set_Expiration_Date_Color();

			txtSubDragDocument.Text = "Drag Document Here";
			txtSubDragDocument.Tag = ""; // This Holds The Path To The File To Add Or On File
			wbSubBrowser1[0].Navigate(new Uri("about:blank"));
			cmdSubDocumentNew.Enabled = false;
			cmdSubDocumentSave.Enabled = true;
			cmdSubDocumentView.Enabled = false;
			cmdSubDocumentDelete.Enabled = false;
			cmdSubDocumentMove.Enabled = false;

			calSubDocumentDate.Visible = true;
			calSubDocumentDate.SetDate(DateTime.Now);
			calSubExpirationDate.Visible = false;
			calSubExpirationDate.SetDate(DateTime.Now);

			lblSubLabel[iCALENDARDOCUMENTDATE].Text = "Calendar - Document Date";

			if (SSTabHelper.GetSelectedIndex(SSTab_Subscription) == 2)
			{
				cmbSubDocumentType.Focus();
			}

		} // cmdSubDocumentNew_Click

		private void cmdSubDocumentSave_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUpdate1 = "";

			string strDocumentId = "";
			string strCompId = "";

			string strDocumentTypeName = "";
			string strDocumentTypeCode = "";
			string strSubject = "";
			string strDescription = "";
			string strExt = "";
			string strFileName = "";
			string strLocalFileName = "";
			string strToFileName = "";
			string strDocDate = "";
			string strExpDate = "";
			string strDocDir = "";
			int iPos1 = 0;
			bool bContinue = false;
			string strUserId = "";

			try
			{

				strDocumentId = ($"{txtSubDocumentId.Text} ").Trim();
				strCompId = modSubscription.Entered_Company_ID.ToString();
				strSubject = ($"{txtSubDocumentSubject.Text} ").Trim();
				strDescription = ($"{txtSubDocumentDescription.Text} ").Trim();
				strDocumentTypeName = ($"{cmbSubDocumentType.Text} ").Trim();
				strDocDate = ($"{txtSubDocumentDate.Text} ").Trim();
				strExpDate = ($"{txtSubExpirationDate.Text} ").Trim();
				strUserId = modAdminCommon.gbl_User_ID;

				if (!Information.IsDate(strDocDate))
				{
					strDocDate = "";
					txtSubDocumentDate.Text = "";
				}
				else
				{
					System.DateTime TempDate2 = DateTime.FromOADate(0);
					strDocDate = (DateTime.TryParse(strDocDate, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : strDocDate;
				}

				if (!Information.IsDate(strExpDate))
				{
					strExpDate = "";
					txtSubExpirationDate.Text = "";
				}
				else
				{
					System.DateTime TempDate3 = DateTime.FromOADate(0);
					strExpDate = (DateTime.TryParse(strExpDate, out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy") : strExpDate;
				}

				Set_Expiration_Date_Color();

				if (cmdSubDocumentSave.Enabled)
				{

					cmdSubDocumentSave.Enabled = false;
					frmSubDocumentControl.Enabled = false;

					// Validate Fields
					if (strDocumentTypeName != "")
					{

						strDocumentTypeCode = Convert.ToString(cmbSubDocumentType.Tag);

						if (strSubject != "")
						{

							if (Convert.ToString(txtSubDragDocument.Tag) != "")
							{

								strLocalFileName = ($"{Convert.ToString(txtSubDragDocument.Tag)} ").Trim();

								if (File.Exists(strLocalFileName))
								{

									// Now Find Document On File Or If Document Id = 0 Then Add New One
									strQuery1 = $"SELECT * FROM Company_Documents WHERE (compdoc_id = {strDocumentId}) ";
									rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
									rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

									bContinue = false;

									if (strDocumentId == "0")
									{
										rstRec1.AddNew();
										bContinue = true;
									}
									else
									{

										if ((!rstRec1.BOF) && (!rstRec1.EOF))
										{
											bContinue = true;
											wbSubBrowser1[0].Navigate(new Uri("about:blank")); // Make Sure It's Not Open
											modCommon.DelaySeconds(1);
										}
										else
										{
											MessageBox.Show("Unable To Find Existing Record To Save Update!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

									} // If strDocumentId = "0" Then

									if (bContinue)
									{ // Ok To Update/Add

										rstRec1["compdoc_comp_id"] = Convert.ToInt32(Double.Parse(strCompId));
										rstRec1["compdoc_journ_id"] = 0;
										rstRec1["compdoc_doc_type_code"] = strDocumentTypeCode;
										rstRec1["compdoc_subject"] = strSubject;
										rstRec1["compdoc_description"] = strDescription;
										rstRec1["compdoc_user_id"] = strUserId;

										if (Information.IsDate(strDocDate))
										{
											System.DateTime TempDate4 = DateTime.FromOADate(0);
											rstRec1["compdoc_doc_date"] = DateTime.Parse((DateTime.TryParse(strDocDate, out TempDate4)) ? TempDate4.ToString("MM/dd/yyyy") : strDocDate);
										}
										else
										{
											rstRec1["compdoc_doc_date"] = 0;
										}

										if (Information.IsDate(strExpDate))
										{
											System.DateTime TempDate5 = DateTime.FromOADate(0);
											rstRec1["compdoc_expiration_date"] = DateTime.Parse((DateTime.TryParse(strExpDate, out TempDate5)) ? TempDate5.ToString("MM/dd/yyyy") : strExpDate);
										}
										else
										{
											rstRec1["compdoc_expiration_date"] = 0;
										}

										rstRec1["compdoc_backup_date"] = DateTime.Parse("1/1/1900");

										rstRec1.UpdateBatch();

										if ((strDocumentId == "0") || (strLocalFileName != ""))
										{

											strDocumentId = Convert.ToString(rstRec1["compdoc_id"]);
											txtSubDocumentId.Text = strDocumentId;

											//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2099
											strFileName = FileSystem.Dir(strLocalFileName);
											iPos1 = (strFileName.IndexOf('.') + 1);
											strExt = strFileName.Substring(Math.Min(iPos1 - 1, strFileName.Length));

											strDocDir = modCommon.DLookUp("aconfig_customer_contract_dir", "Application_Configuration");
											strToFileName = $"{strDocDir}\\{strCompId}-{strDocumentId}{strExt}";

											if (strLocalFileName != strToFileName)
											{

												File.Copy(strLocalFileName, strToFileName, true);
												txtSubDragDocument.Text = $"Drag Document Here{Environment.NewLine}{strFileName}";

												// Now Add In The File Name Once We Know The Document Id
												//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2099
												strFileName = FileSystem.Dir(strToFileName);
												strUpdate1 = $"UPDATE Company_Documents Set compdoc_filename = '{strFileName}' ";
												strUpdate1 = $"{strUpdate1}WHERE (compdoc_id = {strDocumentId}) ";

												DbCommand TempCommand = null;
												TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
												UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
												TempCommand.CommandText = strUpdate1;
												//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
												//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
												TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
												UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
												TempCommand.ExecuteNonQuery();

											} // If strLocalFileName <> strToFileName Then

										} // If strDocumentId = "0" Then

										Load_Subscription_Documents_Grid();
										cmdSubDocumentNew_Click(cmdSubDocumentNew, new EventArgs());

									} // If bContinue = True Then ' Ok To Update

									rstRec1.Close();
									//cntConn.Close

								}
								else
								{
									MessageBox.Show($"Unable To Find Local Document File!{Environment.NewLine}{strLocalFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If fso.FileExists(strLocalFileName) = True Then

							}
							else
							{
								MessageBox.Show("Document Has Not Been Added.  Please Drag a Document To The Document Area!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If txtSubDragDocument.Tag <> "" Then
						}
						else
						{
							MessageBox.Show("Document Subject Is Blank!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If strSubject <> "" Then

					}
					else
					{
						MessageBox.Show("Document Type Has Not Been Selected!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If strDocumentTypeName <> "" Then

					frmSubDocumentControl.Enabled = true;
					cmdSubDocumentSave.Enabled = true;

				} // If cmdSubDocumentSave.Enabled = True Then

				rstRec1 = null;
				fso = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"Save Document Error!{Environment.NewLine}{excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // cmdSubDocumentSave_Click

		private void cmdSubDocumentView_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();
			string strURL = "";


			if (cmdSubDocumentView.Enabled)
			{
				try
				{

					cmdSubDocumentView.Enabled = false;
				}
				catch
				{
				}
				if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => (Convert.ToString(txtSubDragDocument.Tag) != "")))
				{

					if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => File.Exists(Convert.ToString(txtSubDragDocument.Tag))))
					{
						ErrorHandlingHelper.ResumeNext(

							() => {strURL = $"http:{StringsHelper.Replace(Convert.ToString(txtSubDragDocument.Tag), "\\", "/", 1, -1, CompareMethod.Binary)}";}, 

								//-----------------------------------------------
								// 11/05/2013 - By David D. Cruger
								// This routine will use the correct browser

							() => {modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strURL);});

					}
					else
					{
						ErrorHandlingHelper.ResumeNext(
							() => {wbSubBrowser1[0].Navigate(new Uri("about:blank"));}, 
							() => {MessageBox.Show($"Can Not Find Attached File{Environment.NewLine}{Convert.ToString(txtSubDragDocument.Tag)}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);});
					} // If fso.FileExists(txtSubDragDocument.Tag) = True Then

				}
				else
				{
					ErrorHandlingHelper.ResumeNext(
						() => {wbSubBrowser1[0].Navigate(new Uri("about:blank"));}, 
						() => {MessageBox.Show("No Document On File", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);});
				}
				try
				{

					cmdSubDocumentView.Enabled = true;
				}
				catch
				{
				}

			} // If cmdSubDocumentView.Enabled = True Then

			fso = null;

		} // cmdSubDocumentView_Click



		private void cmdSubInsValidate_Click(Object eventSender, EventArgs eventArgs)
		{
			StreamWriter tsFileWriter = null;

			FileStream tsFile = null;

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bHomebaseOK = false;
			bool bEvolutionOK = false;

			int lCompId = 0;
			int lContactId = 0;
			int lSubId = 0;
			string strLogin = "";
			int lSeqNbr = 0;

			string strReportHB = "";
			string strReportEvo = "";

			string strDir = "";
			string strFileName = "";
			string strHTML = "";

			try
			{

				if (cmdSubInsValidate.Enabled)
				{

					cmdSubInsValidate.Enabled = false;

					bHomebaseOK = true;
					bEvolutionOK = true;

					strHTML = "";
					strReportHB = "";
					strReportEvo = "";

					//------------------------------------
					// Load Parameters For Reports

					lCompId = 0;
					lContactId = 0;
					lSubId = 0;
					strLogin = "";
					lSeqNbr = 0;

					lCompId = modSubscription.Entered_Company_ID;

					if (cmbSubInsContact.Text != "" && cmbSubInsContact.Text != "0")
					{
						lContactId = cmbSubInsContact.GetItemData(cmbSubInsContact.SelectedIndex);
					}

					lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));

					strLogin = ($"{txtLoginName.Text} ").Trim();

					grd_Installations.CurrentColumnIndex = 0;
					lSeqNbr = Convert.ToInt32(Double.Parse(grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()));

					modSubscription.search_on("Validation Report For Homebase Install");
					Application.DoEvents();

					strReportHB = modSubscription.Return_Subscription_Install_Validation_Report(modAdminCommon.LOCAL_ADO_DB, lCompId, lContactId, lSubId, strLogin, lSeqNbr, "HOMEBASE", ref bHomebaseOK);

					if (modSubscription.OpenRemoteDatabase())
					{

						modSubscription.search_on("Validation Report For Evolution Install");
						Application.DoEvents();

						strReportEvo = modSubscription.Return_Subscription_Install_Validation_Report(REMOTE_ADO_DB, lCompId, lContactId, lSubId, strLogin, lSeqNbr, "EVOLUTION", ref bHomebaseOK);

						modSubscription.CloseRemoteDatabase();

					} // If OpenRemoteDatabase Then

					//----------------------------------

					strHTML = $"<html>{Environment.NewLine}<head>{Environment.NewLine}";
					strHTML = $"{strHTML}<title>JETNET LLC - Company Subscription/Install Validation Report</title>{Environment.NewLine}";
					strHTML = $"{strHTML}</head>{Environment.NewLine}{Environment.NewLine}";

					strHTML = $"{strHTML}<body>{Environment.NewLine}<center>{Environment.NewLine}";

					strHTML = $"{strHTML}{strReportHB}{Environment.NewLine}<BR/><BR/>{Environment.NewLine}{strReportEvo}{Environment.NewLine}";

					strHTML = $"{strHTML}</center></body></html>{Environment.NewLine}";

					//----------------------------------
					// Create Report HTML File
					//----------------------------------
					strDir = "C:\\TEMP\\";
					if (!Directory.Exists(strDir))
					{
						Directory.CreateDirectory(strDir);
					}

					strDir = $"{strDir}SubInstallValidationReport\\";
					if (!Directory.Exists(strDir))
					{
						Directory.CreateDirectory(strDir);
					}

					strFileName = $"{strDir}SubInstallValidationReport-{lCompId.ToString()}-{lContactId.ToString()}-{lSubId.ToString()}-{lSeqNbr.ToString()}Report.html";
					tsFile = new FileStream(strFileName, FileMode.OpenOrCreate, FileAccess.Write);

					tsFileWriter = new StreamWriter(tsFile);
					tsFileWriter.WriteLine(strHTML); // Write String

					tsFileWriter.Close(); // Close File
					tsFile = null; // Release Memory

					if (File.Exists(strFileName))
					{
						modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strFileName);
					}
					else
					{
						MessageBox.Show($"Unable To Find Report HTML File{Environment.NewLine}{Environment.NewLine}{strFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					modSubscription.search_off();

					cmdSubInsValidate.Enabled = true;

				} // If cmdSubInsValidate.Enabled = True Then
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"cmdSubInsValidate_Click_Error: {Environment.NewLine}{excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				modSubscription.search_off();
				cmdSubInsValidate.Enabled = true;
			}

		} // cmdSubInsValidate_Click

		private void cmdSubNoteNew_Click(Object eventSender, EventArgs eventArgs)
		{

			cmbSubDocumentType.Text = "";
			cmbSubDocumentType.SelectedIndex = 0;

			txt_SubJournalSubject.Text = "";
			txt_SubJournalDescription.Text = "";
			txt_SubJournalId.Text = "0";
			cmdSubNoteNew.Enabled = false;

		} // cmdSubNoteNew_Click

		private void cmdSubNoteSave_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strInsert1 = "";

			string strDateTime = "";
			string strSubId = "";
			string strSubject = "";
			string strDescription = "";
			string strJournId = "";
			string strCompId = "";
			string strContactId = "";
			string strUserId = "";

			try
			{

				strDateTime = modAdminCommon.GetSystemDateTime();

				strSubId = ($"{txt_sub_id.Text} ").Trim();
				strSubject = ($"{txt_SubJournalSubject.Text} ").Trim();
				strDescription = ($"{txt_SubJournalDescription.Text} ").Trim();
				strJournId = ($"{txt_SubJournalId.Text} ").Trim();
				strCompId = modSubscription.Entered_Company_ID.ToString();
				strContactId = "0";
				if (cboChooseContact.Text != "")
				{
					strContactId = ($"{cboChooseContact.GetItemData(cboChooseContact.SelectedIndex).ToString()} ").Trim();
				}

				if (strContactId == "")
				{
					strContactId = "0";
				}
				strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();

				if (strSubId != "0")
				{

					if (strSubject != "")
					{

						// Add or Save
						if ((strJournId == "0") || (strJournId == ""))
						{

							strSubject = StringsHelper.Replace(txt_SubJournalSubject.Text, "'", "''", 1, -1, CompareMethod.Binary);
							strDescription = StringsHelper.Replace(txt_SubJournalDescription.Text, "'", "''", 1, -1, CompareMethod.Binary);

							strInsert1 = "INSERT INTO Journal (journ_subcategory_code, journ_subject, journ_description, ";
							strInsert1 = $"{strInsert1}journ_contact_id, journ_comp_id, journ_user_id, journ_entry_date, ";
							strInsert1 = $"{strInsert1}journ_entry_time, journ_action_date ";
							strInsert1 = $"{strInsert1}) VALUES ('SN','{strSubject}',";
							strInsert1 = $"{strInsert1}'{strDescription}',{strContactId},";
							strInsert1 = $"{strInsert1}{strCompId},'{strUserId}',";
							System.DateTime TempDate2 = DateTime.FromOADate(0);
							strInsert1 = $"{strInsert1}'{((DateTime.TryParse(strDateTime, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : strDateTime)}',";
							strInsert1 = $"{strInsert1}'{StringsHelper.Format(strDateTime, "hh:mm:ss AM/PM")}',";
							strInsert1 = $"{strInsert1}'{strDateTime}')";

							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strInsert1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

						}
						else
						{
							// Update An Existing Note

							strQuery1 = $"SELECT * FROM Journal WHERE (journ_id = {strJournId})";
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

							if ((!rstRec1.BOF) && (!rstRec1.EOF))
							{

								rstRec1["journ_subject"] = strSubject;
								rstRec1["journ_description"] = strDescription;
								rstRec1.UpdateBatch();

							}
							else
							{
								MessageBox.Show("Unable To Find Existing Subscription Note", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

							rstRec1.Close();

						} // If (strJournId = "0") Or (strJournId = "") Then

						Load_Subscription_Journal_Notes_Grid();

						// Clear Form
						cmdSubNoteNew_Click(cmdSubNoteNew, new EventArgs());

					}
					else
					{
						MessageBox.Show("Subscription Note Subject Is Blank!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // strSubject <> "" Then

				}
				else
				{
					MessageBox.Show("Subscription Id Is Blank or Zero!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If strSubId <> "0" Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"cmdSubNoteSave_Click_Error, Note Not Saved{Environment.NewLine}{excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // cmdSubNoteSave_Click

		private void cmdSubNotesButton_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmdSubNotesButton, eventSender);


			switch(Index)
			{
				case SaveSSCNotes :  // 0 - Save Server Side Client Notes Subscription Information 
					cmdSaveSSCNotes_Click(); 
					cmdSaveCloudNotes_Click(); 
					 
					break;
				case ExportSSCNotes :  // 1 - Export Server Side Notes (Aircraft & Company) 
					cmdExportSSCNotes_Click(); 
					 
					break;
				case SaveCloudNotes :  // 2 - Save Evolution Cloud Notes Subscription Information 
					cmdSaveCloudNotes_Click(); 
					cmdSaveSSCNotes_Click(); 
					 
					break;
				case ExportCloudNotes :  // 3 -  Export Cloud Notes To Excel (Aircraft) 
					cmdExportCloudNotes_Click(); 
					 
					break;
				case StopImportEvoLocalNotesToCloudNotes :  // 4 - Stop Import Of Evo Local Notes To Clound Notes 
					cmdStopImportEvoLocalNotesToCloudNotes_Click(); 
					 
					break;
				case BrowseEvoLocalNotes :  // 5 - Browse For Dir Evo Local Notes MDB 
					cmdBrowseEvoLocalNotes_Click(); 
					 
					break;
				case StopImportCRMSSNotesToCloudNotes :  // 6 - Stop Import Of CRM SS Notes To Cloud Notes 
					cmdStopImportCRMSSNotesToCloudNotes_Click(); 
					 
					break;
				case StopImportCloudNotesToCRMSSNotes :  // 7 - Stop Import Of Cloud Notes To CRM SS Notes 
					cmdStopImportCloudNotesToCRMSSNotes_Click(); 
					 
					break;
				case ImportEvoLocalNotesToCloudNotes :  // 8 - Import Evolution Local Notes To Cloud Notes 
					cmdImportEvoLocalNotesToCloudNotes_Click(); 
					 
					break;
				case ImportSSNToCN :  // 9 - Import  CRM Server Side Notes To Cloud Notes 
					cmdImportSSNToCN_Click(); 
					 
					break;
				case ImportCNToSSN :  // 10 - Import Cloud Notes To CRM Server Side Notes 
					cmdImportCNToSSN_Click(); 
					 
					break;
			} // Case Index

		} // cmdSubNotesButton_Click

		private void cmdSubscription_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmdSubscription, eventSender);


			switch(Index)
			{
				case iSAVESUBSCRIPTION : 
					cmd_Save_Subscription_Click(); 
					 
					break;
				case iREMOVESUBSCRIPTION : 
					cmd_Remove_Subscription_Click(); 
					 
					break;
				case iNEWSUBSCRIPTION : 
					cmd_New_Subscription_Click(); 



					 
					break;
				case iMOVESUBSCRIPTION : 
					cmd_Move_Subscription_Click(); 

					 
					break;
			} // Case Index

		} // cmdSubscription_Click

		private void cmdSubSIDocView_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();


			if (cmdSubSIDocView.Enabled)
			{
				try
				{

					cmdSubSIDocView.Enabled = false;
				}
				catch
				{
				}
				if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => (Convert.ToString(cmdSubSIDocView.Tag) != "")))
				{

					if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => File.Exists(Convert.ToString(cmdSubSIDocView.Tag))))
					{
						try
						{


							modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, Convert.ToString(cmdSubSIDocView.Tag));
						}
						catch
						{
						}

					}
					else
					{
						ErrorHandlingHelper.ResumeNext(
							() => {wbSubBrowser1[1].Navigate(new Uri("about:blank"));}, 
							() => {MessageBox.Show($"Can Not Find Service Interruption File{Environment.NewLine}{Convert.ToString(cmdSubSIDocView.Tag)}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);});
					} // If fso.FileExists(cmdSubSIDocView.Tag) = True Then

				}
				else
				{
					ErrorHandlingHelper.ResumeNext(
						() => {wbSubBrowser1[1].Navigate(new Uri("about:blank"));}, 
						() => {MessageBox.Show("No Document On File", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);});
				}
				try
				{

					cmdSubSIDocView.Enabled = true;
				}
				catch
				{
				}

			} // If cmdSubSIDocView.Enabled = True Then

			fso = null;

		} // cmdSubSIDocView_Click

		private void cmdUpdateCRMSite_Click(Object eventSender, EventArgs eventArgs)
		{

			int lErrNbr = 0;
			string strErrDesc = "";

			DbConnection cntCRMConn1 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			DbConnection cntCRMConn2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strCRMConn1 = "";
			string strCRMConn2 = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();

			string strQuery1 = "";
			string strQuery2 = "";

			string strUpdate1 = "";
			string strUpdate2 = "";

			string strSubId = "";
			string strLogin = "";
			string strSeqNbr = "";

			string strProductCode = "";
			string strTierLevel = "";
			string strAerodex = "";
			string strFrequency = "";
			string strNbrInstalls = "";
			string strNbrSPIInstalls = "";
			string strStatus = "";

			string strInstallDate = "";
			System.DateTime dtInstallDate = DateTime.FromOADate(0);

			string strAccessDate = "";
			System.DateTime dtAccessDate = DateTime.FromOADate(0);

			string strCRegId = "";
			int lCRegId = 0;
			bool bOkUpdate = false;
			bool install_numbers_match = false;
			string client_connection_string = "";
			string strErrMsg = "";

			try
			{

				install_numbers_match = false;
				bOkUpdate = false;
				strUpdate1 = "";
				strUpdate2 = "";

				if (cmdUpdateCRMSite.Enabled)
				{

					if (!DoesUserHaveAccess())
					{
						return; // Jump Out
					}

					cmdUpdateCRMSite.Enabled = false;

					strSubId = txt_sub_id.Text;
					strCRegId = txtCRMRegId.Text;
					lCRegId = 0;
					if (Information.IsNumeric(strCRegId) && strCRegId != "0")
					{
						lCRegId = Convert.ToInt32(Double.Parse(strCRegId));
					}

					//----------------------------------------
					// Must Have A CRM Register Id On File

					if (lCRegId > 0)
					{

						modSubscription.search_on("Updating CRM Site...", "Finding CRM Subscription To Send");
						Application.DoEvents();

						strQuery1 = "SELECT * FROM Subscription WITH (NOLOCK)  INNER JOIN Subscription_Login WITH (NOLOCK) ON sub_id = sublogin_sub_id ";
						strQuery1 = $"{strQuery1}INNER JOIN Subscription_Install WITH (NOLOCK) ON sublogin_sub_id = subins_sub_id AND sublogin_login = subins_login ";
						strQuery1 = $"{strQuery1}WHERE (sub_id = {strSubId}) AND (sub_serv_code LIKE 'CRM') ";
						strQuery1 = $"{strQuery1}AND (sub_server_side_crm_regid IS NOT NULL) AND (sub_server_side_crm_regid > 0) ";

						// ADDED ACTIVE FLAG - SO THAT THE 1 LOGIN RECORD IT GOES THOUGH, SHOULD BE ACTIVE IF THERE IS ONE
						strQuery1 = $"{strQuery1} order by Subscription_Login.sublogin_active_flag desc ";

						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if ((!rstRec1.BOF) && (!rstRec1.EOF))
						{

							modSubscription.search_on("Updating CRM Site...", "Opening Connection To CRM Central Database");
							Application.DoEvents();

							if (modCommon.OpenCRMDatabase(ref cntCRMConn1))
							{

								strSubId = Convert.ToString(rstRec1["sub_id"]);
								strLogin = ($"{Convert.ToString(rstRec1["sublogin_login"])} ").Trim();
								strSeqNbr = Convert.ToString(rstRec1["subins_seq_no"]);

								modSubscription.search_on("Updating CRM Site...", $"Processing SubId: {strSubId}");
								Application.DoEvents();

								strProductCode = "";
								if (($"{Convert.ToString(rstRec1["sub_helicopters_flag"])} ").Trim() == "Y")
								{
									strProductCode = $"{strProductCode}H,";
								}
								if (($"{Convert.ToString(rstRec1["sub_business_aircraft_flag"])} ").Trim() == "Y")
								{
									strProductCode = $"{strProductCode}B,";
								}
								if (($"{Convert.ToString(rstRec1["sub_commerical_flag"])} ").Trim() == "Y")
								{
									strProductCode = $"{strProductCode}C,";
								}
								if (strProductCode.Substring(Math.Max(strProductCode.Length - 1, 0)) == ",")
								{
									strProductCode = strProductCode.Substring(0, Math.Min(Strings.Len(strProductCode) - 1, strProductCode.Length));
								}

								strTierLevel = "ALL";
								if (($"{Convert.ToString(rstRec1["sub_busair_tier_level"])} ").Trim() == "2")
								{
									strTierLevel = "T, P";
								}
								if (($"{Convert.ToString(rstRec1["sub_busair_tier_level"])} ").Trim() == "1")
								{
									strTierLevel = "J, E";
								}

								strAerodex = "N";
								if (($"{Convert.ToString(rstRec1["sub_aerodex_flag"])} ").Trim() == "Y")
								{
									strAerodex = "Y";
								}

								strFrequency = ($"{Convert.ToString(rstRec1["sub_frequency"])} ").Trim();
								strNbrInstalls = Convert.ToString(rstRec1["sub_nbr_of_installs"]);
								strNbrSPIInstalls = Convert.ToString(rstRec1["sub_nbr_of_spi_installs"]);

								if (strNbrInstalls == strNbrSPIInstalls)
								{
									install_numbers_match = true;
								}

								strStatus = "Y";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (Convert.IsDBNull(rstRec1["sub_start_date"]))
								{
									strStatus = "N";
								}
								else
								{
									if (Convert.ToDateTime(rstRec1["sub_start_date"]) > DateTime.Now)
									{
										strStatus = "N";
									}
								}

								if (($"{Convert.ToString(rstRec1["sublogin_active_flag"])} ").Trim() == "N")
								{
									strStatus = "N";
								}

								if (($"{Convert.ToString(rstRec1["subins_active_flag"])} ").Trim() == "N")
								{
									strStatus = "N";
								}

								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(rstRec1["sub_end_date"]))
								{
									if (Convert.ToDateTime(rstRec1["sub_end_date"]) <= DateTime.Now)
									{
										strStatus = "N";
									}
								}

								strQuery2 = $"SELECT * FROM client_register_master WHERE (client_regID = {strCRegId}) ";

								rstRec2.Open(strQuery2, cntCRMConn1, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								if ((!rstRec2.BOF) && (!rstRec2.EOF))
								{

									client_connection_string = "";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(rstRec2["client_dbHost"]))
									{
										client_connection_string = $"{client_connection_string}Server={Convert.ToString(rstRec2["client_dbHost"])};";
									}

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(rstRec2["client_dbDatabase"]))
									{
										client_connection_string = $"{client_connection_string}Database={Convert.ToString(rstRec2["client_dbDatabase"])};";
									}

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(rstRec2["client_dbUID"]))
									{
										client_connection_string = $"{client_connection_string}Uid={Convert.ToString(rstRec2["client_dbUID"])};";
									}

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(rstRec2["client_dbPWD"]))
									{
										client_connection_string = $"{client_connection_string}Pwd={Convert.ToString(rstRec2["client_dbPWD"])};";
									}

									strInstallDate = ($"{Convert.ToString(rstRec2["client_regInstalLDate"])} ").Trim();
									strAccessDate = ($"{Convert.ToString(rstRec2["client_regAccessDate"])} ").Trim();

									strInstallDate = modSubscription.Base64_Decode(strInstallDate);
									strAccessDate = modSubscription.Base64_Decode(strAccessDate);

									dtInstallDate = DateTime.FromOADate(0);
									if (Information.IsDate(strInstallDate))
									{
										dtInstallDate = DateTime.Parse(strInstallDate);
									}

									dtAccessDate = DateTime.FromOADate(0);
									if (Information.IsDate(strAccessDate))
									{
										dtAccessDate = DateTime.Parse(strAccessDate);
									}

									strUpdate1 = $"UPDATE client_register_master SET client_regStatus = '{strStatus}', ";
									strUpdate1 = $"{strUpdate1}client_regProductCode = '{strProductCode}', client_regTierLevel = '{strTierLevel}', ";
									strUpdate1 = $"{strUpdate1}client_regAerodexFlag = '{strAerodex}', client_regFrequency = '{strFrequency}', ";
									strUpdate1 = $"{strUpdate1}client_webUserLimit = {strNbrInstalls}, ";

									// 10/28/2016 - By David D. Cruger; Temp Hold - Rick Needs To Add This Field to the CRM
									strUpdate1 = $"{strUpdate1}client_reg_sale_price_limit = {strNbrSPIInstalls}, ";

									if (chkProductType[modSubscription.ProductSPI].CheckState == CheckState.Checked)
									{
										strUpdate1 = $"{strUpdate1}client_reg_sale_price_flag = 'Y' ";
									}
									else
									{
										strUpdate1 = $"{strUpdate1}client_reg_sale_price_flag = 'N' ";
									}

									strUpdate1 = $"{strUpdate1}WHERE (client_regID = {strCRegId}) ";

									UpgradeHelpers.DB.TransactionManager.Enlist(cntCRMConn1.BeginTransaction());
									DbCommand TempCommand = null;
									TempCommand = cntCRMConn1.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
									TempCommand.CommandText = strUpdate1;
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
									TempCommand.ExecuteNonQuery();
									UpgradeHelpers.DB.TransactionManager.Commit(cntCRMConn1);

									strUpdate2 = "UPDATE Subscription_Install SET ";

									strUpdate2 = $"{strUpdate2} subins_action_date = NULL, "; // clear the action date - MSW - 11/3/24

									if (dtInstallDate > DateTime.FromOADate(0))
									{
										strUpdate2 = $"{strUpdate2}subins_install_date = '{dtInstallDate.ToString()}', ";
									}
									else
									{
										strUpdate2 = $"{strUpdate2}subins_install_date = NULL, ";
									}

									if (dtAccessDate > DateTime.FromOADate(0))
									{
										strUpdate2 = $"{strUpdate2}subins_access_date = '{dtAccessDate.ToString()}' ";
									}
									else
									{
										strUpdate2 = $"{strUpdate2}subins_access_date = NULL ";
									}

									strUpdate2 = $"{strUpdate2}WHERE (subins_sub_id = {strSubId}) AND (subins_login = '{strLogin}') ";
									strUpdate2 = $"{strUpdate2}AND (subins_seq_no = {strSeqNbr}) ";

									bOkUpdate = true;

									modAdminCommon.ADO_Transaction("BeginTrans");
									DbCommand TempCommand_2 = null;
									TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
									TempCommand_2.CommandText = strUpdate2;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
									TempCommand_2.ExecuteNonQuery();
									modAdminCommon.ADO_Transaction("CommitTrans");

								} // If (rstRec2.BOF = False) And (rstRec2.EOF = False) Then

								rstRec2.Close();

								// ADDED MSW - CONNECT TO THEIR CRM DATABASE AND UPDATE THE USERS

								if (install_numbers_match && StringsHelper.ToDoubleSafe(strNbrSPIInstalls) > 0)
								{

									if (modCommon.Open_CRM_Server_Side_Notes_Database_Connection(ref cntCRMConn2, Convert.ToInt32(Double.Parse(strCRegId)), ref strErrMsg))
									{

										strUpdate2 = "Update client_user set cliuser_spi_flag = 'Y' where cliuser_active_flag = 'Y' ";

										UpgradeHelpers.DB.TransactionManager.Enlist(cntCRMConn2.BeginTransaction());
										DbCommand TempCommand_3 = null;
										TempCommand_3 = cntCRMConn2.CreateCommand();
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
										TempCommand_3.CommandText = strUpdate2;
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
										TempCommand_3.ExecuteNonQuery();
										UpgradeHelpers.DB.TransactionManager.Commit(cntCRMConn2);

										modCommon.CloseCRMServerSideNotesDatabase(ref cntCRMConn2);

									}
									else
									{
										MessageBox.Show($"Unable To Connect To Client MPM Database lCRegId: {strCRegId}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If Open_CRM_Server_Side_Notes_Database_Connection(cntCRMConn2, CLng(strCRegId), strErrMsg) = True Then

								} // If install_numbers_match = True And strNbrSPIInstalls > 0 Then

								modCommon.CloseCRMDatabase(ref cntCRMConn1);

							}
							else
							{
								MessageBox.Show("Unable To Connect to CRM Central", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If OpenCRMDatabase(cntCRMConn) = True Then

						} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

						rstRec1.Close();

						modSubscription.search_on("Updating CRM Site...", "Process Complete");

						modCommon.DelaySeconds(1);

						grd_Subscriptions_Click(grd_Subscriptions, new EventArgs());

						modSubscription.search_off();

					}
					else
					{
						MessageBox.Show("CRM Registration Id Is Blank Or Zero!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If lCRegId > 0 Then

					cmdUpdateCRMSite.Enabled = true;

				} // If cmdUpdateCRMSite.Enabled = True Then

				rstRec2 = null;
				rstRec1 = null;
				cntCRMConn2 = null;
				cntCRMConn1 = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				modAdminCommon.Report_Error($"cmdUpdateCRMSite_Click_Error: {strErrDesc}");
			}

		} // cmdUpdateCRMSite_Click

		private void cmdUpdateInstallation_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			int lSeqNo = 0;
			string strTemp1 = "";
			string[] aService = null;
			int lContactId = 0;
			string strContactId = "";
			int iBGImageId = 0;
			int iNbr = 0;

			string strCellNbr = "";

			modSubscription.search_on("Saving Installation Information...");

			int lCompId = modSubscription.Entered_Company_ID;
			int lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));
			string strLogin = txtLoginName.Text.Trim();

			// if we are updating or adding in for first time, this needs to be set - 7/21/22
			if (Mode == "Install Update")
			{
				txt_Platform_Name.Text = cmbSubInsContact.Text; // added MSW - 7/21/22
			}

			// ADDED msw  8/8/22
			if (Mode == "LoginUpdate")
			{
				txt_Platform_Name.Text = $"Install #1 for {cmbSubInsContact.Text}"; // added MSW - 7/21/22
			}


			string strPlatform = txt_Platform_Name.Text.Trim();
			string strService = cbo_Service.Text;

			if (strPlatform.Trim() == "")
			{
				strPlatform = "unassigned";
			}

			// 12/03/2002 - By David D. Cruger; Added this field
			txtWebPageTimeOut.Text = ($"{txtWebPageTimeOut.Text} ").Trim();
			if ((txtWebPageTimeOut.Text == "") || (!Information.IsNumeric(txtWebPageTimeOut.Text)) || (Conversion.Val(txtWebPageTimeOut.Text) < 15) || (Conversion.Val(txtWebPageTimeOut.Text) > 60))
			{
				txtWebPageTimeOut.Text = "30"; // Default ' 11/28/2006 - By David D. Cruger; Per Vin; Default 30 minues
			}

			// then we are doing an install udpate not a login update
			if (Mode == "LoginUpdate")
			{
				Mode = "Install Update";
			}

			bool is_frontegg = false;
			if (Mode == "Install Update")
			{




				Query = $"UPDATE Subscription_Install SET subins_platform_name = '{modAdminCommon.Fix_Quote(txt_Platform_Name.Text.Trim())}', ";
				Query = $"{Query}subins_platform_os = '{modAdminCommon.Fix_Quote(txt_Platform_OS.Text.Trim())}', ";
				Query = $"{Query} subins_action_date = NULL, "; // clear the action date - MSW - 11/3/24

				// 1/19/2009 - By David D. Cruger
				// Allow edit/saving of local notes mdb path
				if (chkInstallationUseLocalNotes.CheckState == CheckState.Checked)
				{
					if (txtInstallationPathToLocalDB.Text != "")
					{
						Query = $"{Query}subins_local_db_file = '{modAdminCommon.Fix_Quote(($"{txtInstallationPathToLocalDB.Text} ").Trim())}', ";
						Query = $"{Query}subins_local_db_flag = 'Y', ";
						if (chkInstallationDisplayNoteTag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}subins_display_note_tag_on_aclist_flag = 'Y', ";
						}
					}
					else
					{
						Query = $"{Query}subins_local_db_file = NULL, subins_local_db_flag = 'N', ";
						Query = $"{Query}subins_display_note_tag_on_aclist_flag = 'N', ";
						chkInstallationUseLocalNotes.CheckState = CheckState.Unchecked;
						chkInstallationDisplayNoteTag.CheckState = CheckState.Unchecked;
						txtInstallationPathToLocalDB.Text = "";
					}
				}
				else
				{
					Query = $"{Query}subins_local_db_file = NULL, subins_local_db_flag = 'N', ";
					Query = $"{Query}subins_display_note_tag_on_aclist_flag = 'N', ";
					chkInstallationUseLocalNotes.CheckState = CheckState.Unchecked;
					chkInstallationDisplayNoteTag.CheckState = CheckState.Unchecked;
					txtInstallationPathToLocalDB.Text = "";
				}

				// 12/03/2002 - By David D. Cruger; Added this field
				Query = $"{Query}subins_webpage_timeout = {($"{txtWebPageTimeOut.Text} ").Trim()}, ";

				if (chkActiveXFlag.CheckState == CheckState.Checked)
				{
					Query = $"{Query}subins_activex_flag = 'Y', ";
				}
				else
				{
					Query = $"{Query}subins_activex_flag = 'N', ";
				}

				// 11/15/2004 - By David D. Cruger; Added
				if (chkAutoCheckTS.CheckState == CheckState.Checked)
				{
					Query = $"{Query}subins_autocheck_tservice = 'Y', ";
				}
				else
				{
					Query = $"{Query}subins_autocheck_tservice = 'N', ";
				}

				// 11/15/2004 - By David D. Cruger; Added
				if (chkTerminalService.CheckState == CheckState.Checked)
				{
					Query = $"{Query}subins_terminal_service = 'Y', ";
				}
				else
				{
					Query = $"{Query}subins_terminal_service = 'N', ";
				}

				// 11/06/2012 - By David D. Cruger; Added
				strTemp1 = cmbSubInsBGImageId.Text.Substring(0, Math.Min(2, cmbSubInsBGImageId.Text.Length)).Trim();
				if (Information.IsNumeric(strTemp1))
				{
					iBGImageId = Convert.ToInt32(Double.Parse(strTemp1));
					Query = $"{Query}subins_background_image_id = {iBGImageId.ToString()}, ";
				}
				else
				{
					Query = $"{Query}subins_background_image_id = 0, ";
				}

				// 11/08/2012 - By David D. Cruger; Added
				strTemp1 = StringsHelper.Replace(txtSubInsNbrRecPerPage.Text.Trim(), ",", "", 1, -1, CompareMethod.Binary);
				if (Information.IsNumeric(strTemp1))
				{
					iNbr = Convert.ToInt32(Double.Parse(strTemp1));
					Query = $"{Query}subins_nbr_rec_per_page = {iNbr.ToString()}, ";
				}
				else
				{
					Query = $"{Query}subins_nbr_rec_per_page = 10, ";
				}

				// 08/14/2017 - By David D. Cruger; Added
				strTemp1 = StringsHelper.Replace(txtSubInsDefaultAnalysisMths.Text.Trim(), ",", "", 1, -1, CompareMethod.Binary);
				if (Information.IsNumeric(strTemp1))
				{
					iNbr = Convert.ToInt32(Double.Parse(strTemp1));
					Query = $"{Query}subins_default_analysis_months = {iNbr.ToString()}, ";
				}
				else
				{
					Query = $"{Query}subins_default_analysis_months = 6, ";
				}

				// 03/07/2005 - By David D. Cruger; Added Reply Name
				if (txtReplyName.Text == "")
				{
					Query = $"{Query}subins_email_replyname = Null, ";
				}
				else
				{
					Query = $"{Query}subins_email_replyname = '{txtReplyName.Text}', ";
				}

				// 03/07/2005 - By David D. Cruger; Added Reply EMail
				if (txtReplyEMail.Text == "")
				{
					Query = $"{Query}subins_email_replyaddress = Null, ";
				}
				else
				{
					Query = $"{Query}subins_email_replyaddress = '{txtReplyEMail.Text}', ";
				}

				// 03/07/2005 - By David D. Cruger; Added  Default Format
				if (chkDefaultHTMLEMail.CheckState == CheckState.Checked)
				{
					Query = $"{Query}subins_email_default_format = 'HTML', ";
				}
				else
				{
					Query = $"{Query}subins_email_default_format = 'TEXT', ";
				}

				// 11/26/2007 - By David D. Cruger - Added
				Query = $"{Query}subins_contract_amount = ";
				strTemp1 = ($"{txt_SubInsContractAmount.Text} ").Trim();
				strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
				if (Information.IsNumeric(strTemp1))
				{
					if (Conversion.Val(strTemp1) >= 0)
					{
						Query = $"{Query}{strTemp1}, ";
					}
					else
					{
						Query = $"{Query}0.00, ";
					}
				}
				else
				{
					Query = $"{Query}0.00, ";
				}

				// 06/03/2009 - By David D. Cruger; Added
				if (txtCellNumber.Text == "")
				{
					Query = $"{Query}subins_cell_number = Null, ";
				}
				else
				{
					strCellNbr = modCommon.CleanUpCellNumber(txtCellNumber.Text);
					txtCellNumber.Text = strCellNbr;
					Query = $"{Query}subins_cell_number = '{strCellNbr}', ";
				}

				// 06/03/2009 - By David D. Cruger; Added
				if (cboCellCarrier.SelectedIndex <= 0)
				{
					Query = $"{Query}subins_cell_service = Null, subins_cell_carrier_id = 0, ";
				}
				else
				{
					//----------------------------------------------------
					// Format: United States - Verizon Wireless
					// Index         0                1
					//----------------------------------------------------
					aService = cboCellCarrier.Text.Split(new string[]{" - "}, StringSplitOptions.None);
					Query = $"{Query}subins_cell_service = '{StringsHelper.Replace(($"{aService[1]} ").Trim(), "'", "''", 1, -1, CompareMethod.Binary)}', ";
					Query = $"{Query}subins_cell_carrier_id = {cboCellCarrier.GetItemData(cboCellCarrier.SelectedIndex).ToString()}, ";
				} // If cboCellCarrier.ListIndex > 0 Then

				// 06/03/2009 - By David D. Cruger; Added
				if (txtTextMsgModels.Text == "")
				{
					Query = $"{Query}subins_smstxt_models = Null, ";
				}
				else
				{
					Query = $"{Query}subins_smstxt_models = '{txtTextMsgModels.Text}', ";
				}

				// 06/23/2009 - By David D. Cruger; Added
				if (txtSMSTextActiveFlag.Text == "Yes")
				{
					Query = $"{Query}subins_smstxt_active_flag = 'Y', "; // Yes
				}
				else if (txtSMSTextActiveFlag.Text == "No")
				{ 
					Query = $"{Query}subins_smstxt_active_flag = 'N', "; // No
				}
				else if (txtSMSTextActiveFlag.Text == "Waiting")
				{ 
					Query = $"{Query}subins_smstxt_active_flag = 'W', "; // Waiting To Receive OK
				}
				else if (txtSMSTextActiveFlag.Text == "Activate")
				{ 
					Query = $"{Query}subins_smstxt_active_flag = 'A', "; // Activate Msg Needs To Be Sent
				}

				// 02/16/2010 - By David D. Cruger
				if (txtSubDefaultAModId.Text != "")
				{
					if (Information.IsNumeric(txtSubDefaultAModId.Text))
					{
						Query = $"{Query}subins_default_amod_id = {($"{txtSubDefaultAModId.Text} ").Trim()}, ";
					}
				}

				// 02/19/2010 - By David D. Cruger
				if (chkInstallEvoMobile.CheckState == CheckState.Checked)
				{
					Query = $"{Query}subins_evo_mobile_flag = 'Y', ";
				}
				else
				{
					Query = $"{Query}subins_evo_mobile_flag = 'N', ";
				}

				// 03/08/2011 - By David D. Cruger; Added
				if (txtSMSEvents.Text == "")
				{
					Query = $"{Query}subins_sms_events = 'MA', "; // Default
				}
				else
				{
					Query = $"{Query}subins_sms_events = '{txtSMSEvents.Text}', ";
				}

				// 07/11/2011 - By David D. Cruger; Added
				if (cmbSubInsContact.Text == "" || cmbSubInsContact.Text == "0")
				{
					Query = $"{Query}subins_contact_id = 0, "; // Default
				}
				else
				{
					Query = $"{Query}subins_contact_id = {cmbSubInsContact.GetItemData(cmbSubInsContact.SelectedIndex).ToString()}, ";
				}

				// 07/12/2013 - By David D. Cruger
				if (chkInstallAdministrator.CheckState == CheckState.Checked)
				{
					Query = $"{Query}subins_admin_flag = 'Y', ";
				}
				else
				{
					Query = $"{Query}subins_admin_flag = 'N', ";
				}

				// 08/22/2004 - By David D. Cruger; Added
				if (chkInstallationChatFlag.CheckState == CheckState.Checked)
				{
					Query = $"{Query}subins_chat_flag = 'Y', ";
				}
				else
				{
					Query = $"{Query}subins_chat_flag = 'N', ";
				}

				if (cboSubBType.Text == "")
				{
					Query = $"{Query}subins_business_type_code = 'UI', ";
				}
				else
				{
					Query = $"{Query}subins_business_type_code = '{($"{cboSubBType.Text.Substring(0, Math.Min(2, cboSubBType.Text.Length))} ").Trim()}', ";
				}

				//-------------------------------------------------------
				// Keep This The Last Field
				//-------------------------------------------------------
				if (chkInstallationActive.CheckState == CheckState.Checked)
				{
					Query = $"{Query}subins_active_flag = 'Y' ";
				}
				else
				{
					Query = $"{Query}subins_active_flag = 'N' ";
				}

				grd_Installations.CurrentColumnIndex = 0;
				Query = $"{Query}WHERE (subins_login = '{modAdminCommon.Fix_Quote(Convert.ToString(grd_Installations.Tag)).Trim()}') ";
				Query = $"{Query}AND (subins_sub_id = {modSubscription.gbl_SubID.ToString()}) AND (subins_seq_no = 1) ";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //aey 6/21/04

				UpdateActionDate();

				// added MSW
				int tempRefParam = Convert.ToInt32(Double.Parse(txt_sub_id.Text));
				int tempRefParam2 = 0;
				if (modCommon.Does_Contact_Have_An_Active_Subscription(cmbSubInsContact.GetItemData(cmbSubInsContact.SelectedIndex), ref tempRefParam, ref tempRefParam2, false))
				{ //if we have a login
					//If Does_Contact_Have_An_Active_Subscription(cmbSubInsContact.ItemData(cmbSubInsContact.ListIndex), txt_sub_id.Text, 0, True) = False Then ' but its not frontegg
					int tempRefParam3 = Convert.ToInt32(Double.Parse(txt_sub_id.Text));
					int tempRefParam4 = 0;
					is_frontegg = modCommon.Does_Contact_Have_An_Active_Subscription(cmbSubInsContact.GetItemData(cmbSubInsContact.SelectedIndex), ref tempRefParam3, ref tempRefParam4, true);

					modCommon.UpdateLogin_Fields(cmbSubInsContact.GetItemData(cmbSubInsContact.SelectedIndex), Convert.ToInt32(Double.Parse(txt_sub_id.Text)), Convert.ToString(grd_Installations.Tag).Trim(), is_frontegg); // then update it
					//End If
				}

				// 03/12/2003 - By David D. Cruger
				// Check to See if an event log needs to be entered
				if (iInstallationActive != chkInstallationActive.CheckState)
				{
					strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
					strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  Install SeqNo:=[{Convert.ToString(grd_Installations.Tag)}]  ";
					strTemp1 = $"{strTemp1}Active Status Changed To:=[";
					if (chkInstallationActive.CheckState == CheckState.Checked)
					{
						strTemp1 = $"{strTemp1}Active]";
					}
					else
					{
						strTemp1 = $"{strTemp1}InActive]";
					}
					modAdminCommon.Record_Event("Subscription Install Active Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);
				} // If iInstallationActive <> chkInstallationActive.Value Then


				// 06/23/2009 - By David D. Cruger
				// Check To See If SMS Text Message Active Flag Was Changed
				if (strSMSTextActiveFlag != txtSMSTextActiveFlag.Text)
				{
					strTemp1 = $"CompId:=[{modSubscription.Entered_Company_ID.ToString()}] SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
					strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  ";
					strTemp1 = $"{strTemp1}Install SeqNo:=[{Convert.ToString(grd_Installations.Tag)}]  ";
					strTemp1 = $"{strTemp1}SMS Text Msg Active Changed To:=[{($"{txtSMSTextActiveFlag.Text} ").Trim()}]";

					modAdminCommon.Record_Event("Subscription SMS Text Msg Active Changed", strTemp1, 0, 0, modSubscription.Entered_Company_ID);
				} // If strSMSTextActiveFlag <> txtSMSTextActiveFlag.Text Then

			}
			else if (Mode == "Install Insert")
			{ 

				lSeqNo = GetNextSeqNo(Convert.ToString(grd_Installations.Tag));

				Query = "INSERT INTO Subscription_Install (subins_sub_id, ";
				Query = $"{Query}subins_login, subins_seq_no, subins_platform_os, ";
				Query = $"{Query}subins_local_db_flag, subins_display_note_tag_on_aclist_flag, subins_local_db_file, ";

				// 12/03/2002 - By David D. Cruger; Added this field
				Query = $"{Query}subins_webpage_timeout, subins_activex_flag,  subins_autocheck_tservice, ";
				Query = $"{Query}subins_terminal_service, subins_background_image_id, subins_nbr_rec_per_page, ";

				// 08/14/2017 - By David D. Cruger; Added
				Query = $"{Query}subins_default_analysis_months, subins_email_replyname, subins_email_replyaddress, ";
				Query = $"{Query}subins_email_default_format, subins_contract_amount,  subins_cell_number, ";
				Query = $"{Query}subins_cell_service, subins_cell_carrier_id, subins_smstxt_models, ";

				// 06/23/2009 - By David D. Cruger; Added
				Query = $"{Query}subins_smstxt_active_flag, subins_default_amod_id, subins_evo_mobile_flag, ";

				// 03/08/2011 - By David D. Cruger; Added
				Query = $"{Query}subins_sms_events, subins_contact_id, subins_platform_name, ";

				// 07/25/2013 - By David D. Cruger; Added
				Query = $"{Query}subins_admin_flag, subins_chat_flag, subins_business_type_code, ";

				Query = $"{Query}subins_active_flag) "; // Keep This the Last Field

				// Start Of Values
				Query = $"{Query}VALUES ({modSubscription.gbl_SubID.ToString()}, '{Convert.ToString(grd_Installations.Tag)}', ";
				Query = $"{Query}{lSeqNo.ToString()}, ";

				Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_Platform_OS.Text.Trim())}', ";

				// subins_local_db_flag - subins_local_db_flag
				if (chkInstallationUseLocalNotes.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y', ";
				}
				else
				{
					Query = $"{Query}'N', ";
				}

				// 03/17/2009 - By David D. Cruger Added Display Note Tab
				if (chkInstallationDisplayNoteTag.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y', ";
				}
				else
				{
					Query = $"{Query}'N', ";
				}

				//subins_local_db_file - subins_local_db_file
				Query = $"{Query}'{modAdminCommon.Fix_Quote(txtInstallationPathToLocalDB.Text.Trim())}', ";

				// 12/03/2002 - By David D. Cruger; Added this field - subins_webpage_timeout
				Query = $"{Query}{($"{txtWebPageTimeOut.Text} ").Trim()}, ";

				// 03/27/2003 - By David D. Cruger; Added this field - subins_activex_flag
				if (chkActiveXFlag.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y', ";
				}
				else
				{
					Query = $"{Query}'N', ";
				}

				// 11/15/2004 - By David D. Cruger; Added this field - subins_autocheck_tservice
				if (chkAutoCheckTS.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y', ";
				}
				else
				{
					Query = $"{Query}'N', ";
				}

				// 11/15/2004 - By David D. Cruger; Added this field - subins_terminal_service
				if (chkTerminalService.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y', ";
				}
				else
				{
					Query = $"{Query}'N', ";
				}

				// 11/06/2012 - By David D. Cruger; Added
				strTemp1 = cmbSubInsBGImageId.Text.Substring(0, Math.Min(2, cmbSubInsBGImageId.Text.Length)).Trim();
				if (Information.IsNumeric(strTemp1))
				{
					iBGImageId = Convert.ToInt32(Double.Parse(strTemp1));
					Query = $"{Query}{iBGImageId.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				// 11/08/2012 - By David D. Cruger; Added
				strTemp1 = StringsHelper.Replace(txtSubInsNbrRecPerPage.Text.Trim(), ",", "", 1, -1, CompareMethod.Binary);
				if (Information.IsNumeric(strTemp1))
				{
					iNbr = Convert.ToInt32(Double.Parse(strTemp1));
					Query = $"{Query}{iNbr.ToString()}, ";
				}
				else
				{
					Query = $"{Query}10, ";
				}

				// 08/14/2017 - By David D. Cruger; Added
				strTemp1 = StringsHelper.Replace(txtSubInsDefaultAnalysisMths.Text.Trim(), ",", "", 1, -1, CompareMethod.Binary);
				if (Information.IsNumeric(strTemp1))
				{
					iNbr = Convert.ToInt32(Double.Parse(strTemp1));
					Query = $"{Query}{iNbr.ToString()}, ";
				}
				else
				{
					Query = $"{Query}6, ";
				}

				// 03/07/2005 - By David D. Cruger; Added Reply Name
				if (txtReplyName.Text == "")
				{
					Query = $"{Query}Null, ";
				}
				else
				{
					Query = $"{Query}'{txtReplyName.Text}', ";
				}

				// 03/07/2005 - By David D. Cruger; Added Reply EMail
				if (txtReplyEMail.Text == "")
				{
					Query = $"{Query}Null, ";
				}
				else
				{
					Query = $"{Query}'{txtReplyEMail.Text}', ";
				}

				// 03/07/2005 - By David D. Cruger; Added  Default Format
				if (chkDefaultHTMLEMail.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'HTML', ";
				}
				else
				{
					Query = $"{Query}'TEXT', ";
				}

				// 11/26/2007 - By David D. Cruger - Added
				strTemp1 = ($"{txt_SubInsContractAmount.Text} ").Trim();
				strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
				if (Information.IsNumeric(strTemp1))
				{
					if (Conversion.Val(strTemp1) >= 0)
					{
						Query = $"{Query}{strTemp1}, ";
					}
					else
					{
						Query = $"{Query}0.00,";
					}
				}
				else
				{
					Query = $"{Query}0.00,";
				}

				// 06/03/2009 - By David D. Cruger; Added
				if (txtCellNumber.Text == "")
				{
					Query = $"{Query}Null, ";
				}
				else
				{
					strCellNbr = modCommon.CleanUpCellNumber(txtCellNumber.Text);
					Query = $"{Query}'{strCellNbr}', ";
				}

				// 06/03/2009 - By David D. Cruger; Added
				if (cboCellCarrier.SelectedIndex <= 0)
				{
					Query = $"{Query}Null, 0, ";
				}
				else
				{
					aService = cboCellCarrier.Text.Split(new string[]{" - "}, StringSplitOptions.None);
					Query = $"{Query}'{StringsHelper.Replace(($"{aService[1]} ").Trim(), "'", "''", 1, -1, CompareMethod.Binary)}', ";
					Query = $"{Query}{cboCellCarrier.GetItemData(cboCellCarrier.SelectedIndex).ToString()}, ";
				}

				// 06/03/2009 - By David D. Cruger; Added
				if (txtTextMsgModels.Text == "")
				{
					Query = $"{Query}Null, ";
				}
				else
				{
					Query = $"{Query}'{txtTextMsgModels.Text}', ";
				}

				//------------------------------------------------------
				// 02/10/2010 - By David D. Cruger; Added
				// SMS Text Messaging Active Flag

				switch(($"{txtSMSTextActiveFlag.Text} ").Trim())
				{
					case "Yes" : 
						Query = $"{Query}'Y', "; 
						break;
					case "No" : 
						Query = $"{Query}'N', "; 
						break;
					case "Activate" : 
						Query = $"{Query}'A', "; 
						break;
					case "Waiting" : 
						Query = $"{Query}'W', "; 
						break;
					default:
						Query = $"{Query}'N', "; 
						break;
				}

				if (txtSubDefaultAModId.Text != "")
				{
					if (Information.IsNumeric(txtSubDefaultAModId.Text))
					{
						Query = $"{Query}{($"{txtSubDefaultAModId.Text} ").Trim()}, ";
					}
					else
					{
						Query = $"{Query}0, ";
					}
				}
				else
				{
					Query = $"{Query}0, ";
				}


				if (chkInstallEvoMobile.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y', ";
				}
				else
				{
					Query = $"{Query}'N', ";
				}

				if (($"{txtSMSEvents.Text} ").Trim() == "")
				{
					txtSMSEvents.Text = "MA"; // Default
				}
				Query = $"{Query}'{($"{txtSMSEvents.Text} ").Trim()}', ";


				if (cmbSubInsContact.Text == "" || cmbSubInsContact.Text == "0")
				{
					Query = $"{Query}0, 'unassigned', ";
				}
				else
				{
					//Query = Query & CStr(cmbSubInsContact.Tag) & ", "
					if (cmbSubInsContact.Text != "Demo Account")
					{
						Query = $"{Query}{cmbSubInsContact.GetItemData(cmbSubInsContact.SelectedIndex).ToString()}, ";
						Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_Platform_Name.Text.Trim())} ', ";
					}
					else
					{
						Query = $"{Query}419946, "; // Force Demo Account
						Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_Platform_Name.Text.Trim())} ', ";
					}

				}


				if (chkInstallAdministrator.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y', ";
				}
				else
				{
					Query = $"{Query}'N', ";
				}


				if (chkInstallationChatFlag.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y', ";
				}
				else
				{
					Query = $"{Query}'N', ";
				}

				// 09/22/2015 - By David D. Cruger; Added
				if (cboSubBType.Text == "")
				{
					Query = $"{Query}'UI', ";
				}
				else
				{
					Query = $"{Query}'{($"{cboSubBType.Text.Substring(0, Math.Min(2, cboSubBType.Text.Length))} ").Trim()}', ";
				}

				if (chkInstallationActive.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y')";
				}
				else
				{
					Query = $"{Query}'N')";
				}

				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery(); //aey 6/21/04

				UpdateActionDate();

				if (cmbSubInsContact.Text == "Demo Account")
				{
					modCommon.UpdateLogin_Fields(419946, Convert.ToInt32(Double.Parse(txt_sub_id.Text)), Convert.ToString(grd_Installations.Tag).Trim(), false); // then update it
				}

				// 03/12/2003 - By David D. Cruger
				// If someone adds a subscription login log an event entry
				strTemp1 = $"CompId:=[{lCompId.ToString()}] SubId:=[{lSubId.ToString()}]  ";
				strTemp1 = $"{strTemp1}Login:=[{strLogin}]  Install SeqNo:=[{lSeqNo.ToString()}]  ";

				modAdminCommon.Record_Event("Subscription Install Added", strTemp1, 0, 0, lCompId);

				modSubscription.AddSubscriptionNote(lCompId, lSubId, $"New Install Added For Login:=[{strLogin}]  Platform:=[{strPlatform}]", "");

				strAddChgHasHappened = $"{strAddChgHasHappened}A New Install Has Been Added On SubId: {lSubId.ToString()}{Environment.NewLine}";

			} // ElseIf Mode = "Install Insert" Then

			// 10/30/2003 - By David D. Cruger; If Weg Page Timeout has been changed record and Event
			if (gstrTimeOut != txtWebPageTimeOut.Text)
			{

				strTemp1 = $"WebPage TimeOut From [{gstrTimeOut}] to [{txtWebPageTimeOut.Text}] - ";
				strTemp1 = $"{strTemp1}CompId:=[{lCompId.ToString()}] SubId:=[{lSubId.ToString()}]  ";
				strTemp1 = $"{strTemp1}Login:=[{strLogin}]  Install SeqNo:=[{lSeqNo.ToString()}]  ";

				modAdminCommon.Record_Event("Subscription WebPage TimeOut Changed", strTemp1, 0, 0, lCompId);
				gstrTimeOut = txtWebPageTimeOut.Text;

			} // If gstrTimeOut <> txtWebPageTimeOut.Text Then

			cmd_InstallCancel_Click(cmd_InstallCancel, new EventArgs());

			Fill_grd_Installations(Convert.ToString(grd_Installations.Tag));

			// 09/10/2013 - By David D. Cruger
			// Update_Subscription_Parent_Sub_Id

			modSubscription.search_off();

			string strPassword = txt_sub_password.Text;
			string strStatus = "";
			if (modSubscription.IsPasswordAndEMailUsedMoreThanOnce(strPassword, strService, ref strStatus))
			{
				MessageBox.Show($"Password: [{strPassword}] {Environment.NewLine}{Environment.NewLine}Is Used More Than Once{Environment.NewLine}{Environment.NewLine}{strStatus}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdUpdateInstallation_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdUpdateInstallation_Click(cmdUpdateInstallation, new EventArgs());
			}

		}

		private void cmdUpload_Click(Object eventSender, EventArgs eventArgs)
		{

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			if (!DoesUserHaveAccess())
			{
				return; // Jump Out
			}

			if (txt_sub_id.Text == "1266")
			{
				MessageBox.Show("Update Web Site is NOT Allowed for Id: 1266", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			modCommon.Start_Activity_Monitor_Message("Update Web Site", ref strMsg, ref dtStartDate, ref dtEndDate);


			UploadSubscription();

			Fill_Subscription_Panel(modSubscription.gbl_SubID);

			modCommon.End_Activity_Monitor_Message("Update Web Site", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, modSubscription.Entered_Company_ID, 0, 0);

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdUpload_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdUpload_Click(cmdUpload, new EventArgs());
			}

		}

		private void Set_WebBrowser_Company_Subscription_Summary()
		{


			string strWebReport = modCommon.DLookUp("swr_url", "Subscription_WebReports", "(swr_desc='Customer Summary Report')");
			if (strWebReport != "")
			{
				// http://jetnet14/help/listcompanysubscriptionsummary.asp?CompId={CompId}&dBase={Live}
				strWebReport = StringsHelper.Replace(strWebReport, "{CompId}", modSubscription.Entered_Company_ID.ToString(), 1, -1, CompareMethod.Binary);
				if (modAdminCommon.gbl_Live_flag)
				{
					strWebReport = StringsHelper.Replace(strWebReport, "{Live}", "LIVE", 1, -1, CompareMethod.Binary);
				}
				else
				{
					strWebReport = StringsHelper.Replace(strWebReport, "{Live}", "TEST", 1, -1, CompareMethod.Binary);
				}
				wbSubBrowser1[4].Tag = strWebReport;
				wbSubBrowser1[4].Navigate(new Uri(strWebReport));
			}

		} // Set_WebBrowser_Company_Subscription_Summary

		//UPGRADE_NOTE: (7001) The following declaration (Command1_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Command1_Click()
		//{
			//
			//
			//
		//}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

			}
		}

		private void Load_Service_Combo_Box(ComboBox cmbBox)
		{

			ADORecordSetHelper rstRec1 = null;
			string strQuery1 = "";

			try
			{

				rstRec1 = new ADORecordSetHelper();

				serv_code = new string[]{""};
				cbo_Service.Items.Clear();
				lblSubLabel[iCOPYLOGINS].Visible = false; // Copy Login Label
				lblSubLabel[iCOPYLOGINS].Enabled = true;

				// 12/5/2008 - By David D. Cruger; Added serv_active_flag check
				strQuery1 = "SELECT * FROM Service (NOLOCK) ";

				// 01/20/2020 - By David D. Cruger; Use the check box Inactive to use the active_flag
				if (chkIncludeInactive.CheckState == CheckState.Unchecked)
				{
					strQuery1 = $"{strQuery1}WHERE (serv_active_flag = 'Y') ";
				}
				strQuery1 = $"{strQuery1}ORDER BY serv_name";
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					do 
					{ // Loop Until rstRec1.EOF = True
						cbo_Service.AddItem(($"{Convert.ToString(rstRec1["serv_name"])} - {Convert.ToString(rstRec1["serv_code"])} ").Trim());
						serv_code = ArraysHelper.RedimPreserve(serv_code, new int[]{cbo_Service.Items.Count + 1});
						serv_code[cbo_Service.Items.Count - 1] = ($"{Convert.ToString(rstRec1["serv_name"])} - {Convert.ToString(rstRec1["serv_code"])}").Trim();
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Load_Service_Combo_Box_Error: {excep.Message}");
			}

		} // Load_Service_Combo_Box

		private void Set_Count_For_Inactive_Subscriptions()
		{

			int lCount = 0;

			int lCompId = modSubscription.Entered_Company_ID;

			chkIncludeInactive.Text = "Include Inactive";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "SELECT COUNT(*) As lTotInactive FROM Subscription WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}WHERE (sub_comp_id = {lCompId.ToString()})  AND (sub_end_date IS NOT NULL AND sub_end_date <= GETDATE()) ";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if ((!rstRec1.BOF) && (!rstRec1.EOF))
			{
				if (Convert.ToDouble(rstRec1["lTotInactive"]) > 0)
				{
					chkIncludeInactive.Text = $"Include Inactive - Total Inactive:  {Convert.ToString(rstRec1["lTotInactive"])} ";
				}
			}

			rstRec1.Close();

		} // Set_Count_For_Inactive_Subscriptions

		private object Find_Highest_Subscriptions()
		{

			object result = null;
			int lCount = 0;
			int lCompId = 0;

			result = 0;

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "SELECT top 1 sub_id FROM Subscription WITH (NOLOCK) ";
			// WE ARE GOING TO START at 10,000 and GO UP FROM THERE FROM JASONS 9999
			//'strQuery1 = strQuery1 & " where sub_id not in(9999.9998,9997,9996) "
			strQuery1 = $"{strQuery1} order by sub_id desc ";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if ((!rstRec1.BOF) && (!rstRec1.EOF))
			{
				result = rstRec1["sub_id"];
				//UPGRADE_WARNING: (1068) Find_Highest_Subscriptions of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				result = Convert.ToDouble(result) + 1;
			}

			rstRec1.Close();

			return result;
		}
		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			string Query = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strUserId = "";
			int I = 0;

			string strSirName = "";
			string strFName = "";
			string strMInit = "";
			string strLName = "";
			string strSuffix = "";


			try
			{

				modCommon.Start_Activity_Monitor_Message("Open Subscription", ref strMsg, ref dtStartDate, ref dtEndDate);

				FormLoaded = false;
				gbMPM = false;
				modAdminCommon.Num_Embedded = 0;

				fra_Bottom.Visible = false;
				frmLoginFlags.Visible = false;
				cmdUpload.Visible = false;

				fraLogin.Visible = false;
				grd_Logins.Visible = true;

				fra_Add_Installation.Visible = false;
				grd_Installations.Visible = true;

				has_mpm = 0; // added MSW - 4/19/22
				has_mpm_db_name = "";
				has_mpm_connection = 0;
				mpm_sub_id = 0;
				possible_mpm_evo_id = 0;

				wbSubBrowser1[0].Navigate(new Uri("about:blank")); // Contracts
				wbSubBrowser1[1].Navigate(new Uri("about:blank")); // Service Interruptions
				wbSubBrowser1[2].Navigate(new Uri("about:blank")); // WebReports
				wbSubBrowser1[3].Navigate(new Uri("about:blank")); // Execution Forms
				wbSubBrowser1[4].Navigate(new Uri("about:blank")); // Subscription Summary
				wbSubBrowser1[4].Tag = "about:blank";

				cal_sub_start_date.SetDate(DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)));
				cal_sub_end_date.SetDate(DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)));
				calCallBackDate.SetDate(DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)));

				if (cbo_auth_cycle.Items.Count == 0)
				{
					cbo_auth_cycle.Items.Clear();
					for (int K = 1; K <= 90; K++)
					{
						cbo_auth_cycle.AddItem(K.ToString());
					}
					cbo_auth_cycle.Text = "30";
				}

				if (cbo_auth_type.Items.Count == 0)
				{
					cbo_auth_type.AddItem("SMS");
					cbo_auth_type.AddItem("Email");
					cbo_auth_type.Text = "SMS";
				}

				// 03/02/2017 - By David D. Cruger
				// Per Therese/Patty defaul this to Only Active Subscriptions

				chkIncludeInactive.CheckState = CheckState.Unchecked;

				Load_Service_Combo_Box(cbo_Service);

				// Load Frequency Pull Down
				cmbFrequency.Items.Clear();
				//Query = "SELECT * FROM Service_Frequency (NOLOCK) WHERE (serfreq_database_name <> 'NA')"
				Query = " SELECT * , CASE WHEN serfreq_frequency = 'Live' THEN 1 ";
				Query = $"{Query}WHEN serfreq_frequency = 'Weekly' THEN 2 WHEN serfreq_frequency = 'Monthly' THEN 3 ";
				Query = $"{Query}WHEN serfreq_frequency = 'Quarterly' THEN 4 WHEN serfreq_frequency = 'Annual' THEN 5 ";
				Query = $"{Query}ELSE 99 END As serfreq_sort ";
				Query = $"{Query}From Service_Frequency  WHERE  (serfreq_database_name <> 'NA') and CASE ";
				Query = $"{Query}WHEN serfreq_frequency = 'Live' THEN 1 WHEN serfreq_frequency = 'Weekly' THEN 2 ";
				Query = $"{Query}WHEN serfreq_frequency = 'Monthly' THEN 3  WHEN serfreq_frequency = 'Quarterly' THEN 4 ";
				Query = $"{Query}WHEN serfreq_frequency = 'Annual' THEN 5 ELSE 99 ";
				Query = $"{Query}END <> 99 ORDER BY serfreq_sort";

				rstRec1.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{
					do 
					{ // Loop Until rstRec1.EOF = True
						cmbFrequency.AddItem(($"{Convert.ToString(rstRec1["serfreq_frequency"])} ").Trim());
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);
				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then
				rstRec1.Close();

				// Load Build Types
				cbo_build.Items.Clear();
				Query = " select distinct sublogin_build  from Subscription_Login order by sublogin_build asc ";
				rstRec1.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{
					do 
					{ // Loop Until rstRec1.EOF = True
						cbo_build.AddItem(($"{Convert.ToString(rstRec1["sublogin_build"])} ").Trim());
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);
				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then
				rstRec1.Close();

				// Load Document Type
				cmbSubDocumentType.Items.Clear();
				Query = "SELECT doctype_code, doctype_description FROM Document_Type WITH (NOLOCK) ";
				Query = $"{Query}WHERE (doctype_contract_doc_view = 'Y') ORDER BY doctype_description ";
				rstRec1.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{
					do 
					{ // Loop Until rstRec1.EOF = True
						cmbSubDocumentType.AddItem($"{($"{Convert.ToString(rstRec1["doctype_code"])} ").Trim()} - {($"{Convert.ToString(rstRec1["doctype_description"])} ").Trim()}");
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);
				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then
				rstRec1.Close();

				cmbTierLevel.Items.Clear();
				cmbTierLevel.AddItem("Jets & Turbos - 3");
				cmbTierLevel.AddItem("Turboprops - 2");
				cmbTierLevel.AddItem("Jets - 1");
				cmbTierLevel.Text = "Jets & Turbos - 3";


				cmbTierLevel_comm.Items.Clear();
				cmbTierLevel_comm.AddItem("Jets & Turbos - 3");
				cmbTierLevel_comm.AddItem("Turboprops - 2");
				cmbTierLevel_comm.AddItem("Jets - 1");
				cmbTierLevel_comm.Text = "";



				// 04/23/2009 - By David D. Cruger
				// This would be better served by a table

				// 04/11/2017 - By David D. Cruger
				// Per Therese; The first 4 are high priority

				cboCallBackStatus.Items.Clear();
				cboCallBackStatus.AddItem("");
				cboCallBackStatus.AddItem("AD = Auto Disable");
				cboCallBackStatus.AddItem("CX = Cancelled");
				cboCallBackStatus.AddItem("NW = New Customer");
				cboCallBackStatus.AddItem("RS = Resumed Service");

				cboCallBackStatus.AddItem("AL = Additional Location");
				cboCallBackStatus.AddItem("BT = Beta Tester");
				cboCallBackStatus.AddItem("CP = Coupon Service");
				cboCallBackStatus.AddItem("CS = Change in Service");
				cboCallBackStatus.AddItem("DG = DownGrade");
				cboCallBackStatus.AddItem("DM = Demo Customer");
				cboCallBackStatus.AddItem("IN = Interrupt");
				cboCallBackStatus.AddItem("NC = New Contract");
				cboCallBackStatus.AddItem("NK = Nuke");
				cboCallBackStatus.AddItem("TC = Trial Customer");
				cboCallBackStatus.AddItem("TD = Temp Disk Service");
				cboCallBackStatus.AddItem("UG = UpGrade");

				cmbSubInsBGImageId.Items.Clear();
				cmbSubInsBGImageId.AddItem("0 - Random");
				cmbSubInsBGImageId.AddItem("17 - White");
				cmbSubInsBGImageId.AddItem("18 - Light Gray");
				cmbSubInsBGImageId.AddItem("19 - Light Brown");
				cmbSubInsBGImageId.AddItem("20 - Light Blue");

				cboCellCarrier.Items.Clear();
				cboCellCarrier.AddItem(""); // First Record Blank

				Query = "SELECT smstxtcar_id, smstxtcar_country, smstxtcar_carrier FROM SMS_Text_Message_Carrier (NOLOCK) ";
				Query = $"{Query}WHERE (smstxtcar_active_flag = 'Y') ORDER BY smstxtcar_country, smstxtcar_carrier ";

				rstRec1.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{
					I = 0;

					//------------------------
					// United States First
					//------------------------
					rstRec1.Filter = "(smstxtcar_country = 'United States') ";
					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{
						do 
						{ // Loop Until rstRec1.EOF = True
							I++;
							cboCellCarrier.AddItem($"{($"{Convert.ToString(rstRec1["smstxtcar_country"])} ").Trim()} - {($"{Convert.ToString(rstRec1["smstxtcar_carrier"])} ").Trim()}");
							cboCellCarrier.SetItemData(I, Convert.ToInt32(rstRec1["smstxtcar_id"]));
							rstRec1.MoveNext();
						}
						while(!rstRec1.EOF);
					}
					//---------------------------
					// Now All Other Countries
					//---------------------------
					rstRec1.Filter = "";
					rstRec1.Filter = "(smstxtcar_country <> 'United States') ";
					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{
						do 
						{ // Loop Until rstRec1.EOF = True
							I++;
							cboCellCarrier.AddItem($"{($"{Convert.ToString(rstRec1["smstxtcar_country"])} ").Trim()} - {($"{Convert.ToString(rstRec1["smstxtcar_carrier"])} ").Trim()}");
							cboCellCarrier.SetItemData(I, Convert.ToInt32(rstRec1["smstxtcar_id"]));
							rstRec1.MoveNext();
						}
						while(!rstRec1.EOF);
					}
				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then
				rstRec1.Close();

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Retrieve the Company/Contact Information
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				if (modSubscription.Entered_Contact_ID > 0)
				{
					Fill_Contact_Info_Panel(modSubscription.Entered_Contact_ID);
				}
				if (modSubscription.Entered_Company_ID > 0)
				{
					Fill_Company_Info_Panel(modSubscription.Entered_Company_ID);
					Fill_CBO_Contact(modSubscription.Entered_Company_ID, "", "", "", "");
				}

				// added MSW - for new subscription created method.7/1/24
				cmdSubscription[2].Enabled = modAdminCommon.gbl_User_Create_Sub == "Y";

				cboSubBType.Items.Clear();
				cboSubBType.AddItem("DB - Dealer Broker");
				cboSubBType.AddItem("FB - Fixed Base Operator");
				cboSubBType.AddItem("UI - Unidentified");

				chkProductType[modSubscription.ProductABIListing].Enabled = false;
				if (modCommon.DLookUp("bustypref_type", "Business_Type_Reference", $"(bustypref_comp_id = {modSubscription.Entered_Company_ID.ToString()}) AND (bustypref_journ_id = 0) AND (bustypref_type = 'DB')") != "")
				{
					chkProductType[modSubscription.ProductABIListing].Enabled = true;
				}

				Fill_Subscription_Install_Contact_Combo_Box(modSubscription.Entered_Company_ID, false);

				Fill_grd_Subscriptions(modSubscription.Entered_Company_ID);

				// then we have an mpm in a row
				if (has_mpm > 0)
				{
					if (chkIncludeInactive.CheckState == CheckState.Checked)
					{

					}
					else
					{
						grd_Subscriptions.CurrentRowIndex = has_mpm;
						grd_Subscriptions.CurrentColumnIndex = 1;
						grd_Subscriptions_Click(grd_Subscriptions, new EventArgs());
					}
				}
				else if (has_mpm_connection > 0)
				{ 
					if (chkIncludeInactive.CheckState == CheckState.Checked)
					{

					}
					else
					{
						Check_For_Active_MPM_View(0, 0, has_mpm_db_name.Trim());
					}
				}

				if (grd_Subscriptions.RowsCount == 1)
				{
					if (chkIncludeInactive.CheckState == CheckState.Unchecked)
					{
						chkIncludeInactive.CheckState = CheckState.Checked;
						Fill_grd_Subscriptions(modSubscription.Entered_Company_ID);
					}
				}


				Fill_grd_Installations("");

				// 01/16/2004 - By David D. Cruger; Added 'Technical' to be able to remove subscriptions
				cmdSubscription[iREMOVESUBSCRIPTION].Enabled = (Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Administrator") || (Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Technical");

				strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();

				// 12/03/2007 - By David D. Cruger
				// Per Vin; Limit Access To This Information
				if (($"{Convert.ToString(modAdminCommon.snp_User["user_subscription_contract_amount"])} ").Trim() == "N")
				{

					lbl_SubLoginContractAmount.Visible = false;
					txt_SubLoginContractAmount.Visible = false;

					//----------------------------------------------------

				} // If Trim(snp_User!user_subscription_contract_amount & " ") = "N" Then

				cmdSubscription[iMOVESUBSCRIPTION].Enabled = false;
				cmdMoveLoginFrame.Enabled = false;
				if (($"{Convert.ToString(modAdminCommon.snp_User["user_move_subid_login_flag"])} ").Trim() == "Y")
				{
					cmdSubscription[iMOVESUBSCRIPTION].Enabled = true;
					cmdMoveLoginFrame.Enabled = true;
				}

				// 07/28/2015 - By David D. Cruger
				// Does User Have Access To Export Cloud Notes or Server Side Notes
				cmdSubNotesButton[ExportSSCNotes].Enabled = false;
				cmdSubNotesButton[ExportCloudNotes].Enabled = false;
				if (strUserId == "DCR" || strUserId == "AJA" || strUserId == "MVIT")
				{
					cmdSubNotesButton[ExportSSCNotes].Enabled = true;
					cmdSubNotesButton[ExportCloudNotes].Enabled = true;
				}

				cmd_DeleteLogin.Enabled = true;
				cmdDeleteInstallation.Enabled = true;


				if (modSubscription.Entered_Subscription_ID == 0)
				{
					grd_Subscriptions.CurrentColumnIndex = 0;
				}

				if ((grd_Subscriptions.RowsCount > 1) && (grd_Subscriptions.ColumnsCount > 2))
				{
					grd_Subscriptions.CurrentRowIndex = 1;
					grd_Subscriptions.CurrentColumnIndex = 0;
					grd_Subscriptions_Click(grd_Subscriptions, new EventArgs());
				}


				if ((grd_Logins.RowsCount > 1) && (grd_Logins.ColumnsCount > 2))
				{
					grd_Logins.CurrentRowIndex = 1;
					grd_Logins.CurrentColumnIndex = 0;
					grd_Logins_Click(grd_Logins, new EventArgs());
				}

				// 01/28/2014 - By David D. Cruger
				strAddChgHasHappened = "";

				CheckPermision();

				FormLoaded = true;
				this.Cursor = CursorHelper.CursorDefault;

				rstRec1 = null;

				modCommon.End_Activity_Monitor_Message("Open Subscription", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, modSubscription.Entered_Company_ID, 0, 0);

				SSTabHelper.SetSelectedIndex(SSTab_Subscription, 0); // Make Sure The Subscription Tab Is Always First
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Subscription Form Load Error: {excep.Message}");
			}

		} // Form_Load

		private void Update_Subscription_Service_Name(int lSubId)
		{

			string strUpdate1 = "";

			try
			{

				strUpdate1 = "UPDATE Subscription SET sub_action_date = '1/1/1900', ";
				strUpdate1 = $"{strUpdate1}sub_service_name = (SELECT * FROM ReturnServiceFullName({lSubId.ToString()})) ";
				strUpdate1 = $"{strUpdate1}WHERE (sub_id = {lSubId.ToString()}) ";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strUpdate1;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //aey 6/21/04
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Update_Subscription_Service_Name_Error: {excep.Message}");
			}

		} // Update_Subscription_Service_Name

		private void Save_Subscription_Data(int sub_code)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lCompId = 0;
			int lSubId = 0;
			int lParentId = 0;

			string Query = "";
			string FLDS = "";
			string VALS = "";
			string M = "";
			string strTemp1 = "";
			string strTemp2 = "";

			string strDate1 = "";
			string strDate2 = "";

			string strEMailTo = "";
			string strSubject = "";
			string strBody = "";
			string strReplyName = "";
			bool bResults = false;

			string strNbr1 = "";
			string strNbr2 = "";
			string strEType = "";
			string strMsg = "";
			string strDatabase = "";
			int iPos1 = 0;
			string strErrorMsg = "";
			string strServiceName = "";
			string temp_serve = "";


			try
			{


				this.Cursor = Cursors.WaitCursor;

				if (VerifySubscription())
				{

					lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));
					lCompId = modSubscription.Entered_Company_ID;
					lParentId = 0;

					//If (Len(Trim(txt_sub_start_date)) > 0) Then
					if (Mode == "AddSubscription")
					{

						if (modAdminCommon.Exist($"SELECT sub_id FROM Subscription WITH (NOLOCK) WHERE (sub_id = {lSubId.ToString()})"))
						{
							MessageBox.Show($"Subscription ID {lSubId.ToString()} Already Exists!{Environment.NewLine}{Environment.NewLine}Add Cancelled", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							return;
						}


						if (chkServerSideNotes.CheckState == CheckState.Unchecked)
						{
							if (cmbCRMDatabaseName.Text == "")
							{
								if (txtCRMRegId.Text == "" || txtCRMRegId.Text == "0")
								{
									if (chkCloudNotesFlag.CheckState == CheckState.Unchecked)
									{
										if (cmbCloudNotesDatabaseName.Text.Trim() == "")
										{
											bAutoCreateCloudNotesFlag = true;
											// Temp Hold
											//chkCloudNotesFlag.Value = vbChecked
											if (cmbCloudNotesDatabaseName.Text.IndexOf(" - ") >= 0)
											{
												//cmdSaveCloudNotes_Click
											}
										}
									}
								}
							}
						}

						FLDS = "INSERT INTO Subscription (";
						VALS = ") VALUES (";
						FLDS = $"{FLDS}sub_id";
						VALS = $"{VALS}{lSubId.ToString()}";

						// added in MSW - 7/17/24
						FLDS = $"{FLDS}, sub_parent_sub_id";
						VALS = $"{VALS}, {lSubId.ToString()}";


						FLDS = $"{FLDS}, sub_comp_id";
						VALS = $"{VALS}, {lCompId.ToString()}";



						temp_serve = serv_code[cbo_Service.SelectedIndex];
						temp_serve = temp_serve.Substring(Math.Max(temp_serve.Length - (Strings.Len(temp_serve) - (temp_serve.IndexOf(" - ") + 1)), 0));
						temp_serve = StringsHelper.Replace(temp_serve, "- ", "", 1, -1, CompareMethod.Binary);

						FLDS = $"{FLDS}, sub_serv_code";
						VALS = $"{VALS}, '{temp_serve}'";

						// 03/16/2004 - By David D. Cruger; Added Marketing Flag and Nbr of Days Expire
						FLDS = $"{FLDS}, sub_marketing_flag ";
						if (chkProductType[modSubscription.ProductMarketing].CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						// added MSW - 1/19/23
						FLDS = $"{FLDS}, sub_api_flights_flag ";
						if (chk_sub_api_flag.CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y' ";
						}
						else
						{
							VALS = $"{VALS}, 'N' ";
						}


						FLDS = $"{FLDS}, sub_nbr_days_expire ";
						VALS = $"{VALS}, {txtNbrDaysExpire.Text} ";

						FLDS = $"{FLDS}, sub_start_date";
						VALS = $"{VALS}, '{txt_sub_start_date.Text.Trim()}'";
						if (Strings.Len(txt_sub_end_date.Text.Trim()) > 0)
						{
							FLDS = $"{FLDS}, sub_end_date";
							VALS = $"{VALS}, '{txt_sub_end_date.Text.Trim()}'";
						}
						FLDS = $"{FLDS}, sub_entry_date";
						VALS = $"{VALS}, '{DateTime.Today.ToString("MM/dd/yyyy")}'";

						// 04/23/2009 - By David D. Cruger
						// Added Callback Fields

						if (Information.IsDate(txtCallBackDate.Text))
						{
							FLDS = $"{FLDS}, sub_callback_date ";
							VALS = $"{VALS}, '{txtCallBackDate.Text.Trim()}'";
						}

						if (cboCallBackStatus.Text != "")
						{
							FLDS = $"{FLDS}, sub_callback_status ";
							VALS = $"{VALS}, '{cboCallBackStatus.Text.Substring(Math.Min(0, cboCallBackStatus.Text.Length), Math.Min(2, Math.Max(0, cboCallBackStatus.Text.Length)))}'";
						}

						if (txtCallbackComments.Text != "")
						{
							FLDS = $"{FLDS}, sub_callback_comment ";
							VALS = $"{VALS}, '{StringsHelper.Replace(txtCallbackComments.Text, "'", "''", 1, -1, CompareMethod.Binary)}'";
						}

						//------------------------------------------------

						FLDS = $"{FLDS}, sub_entry_user_id";
						VALS = $"{VALS}, '{modAdminCommon.gbl_User_ID}'";

						// 04/20/2005 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_business_aircraft_flag ";
						if (chkProductType[modSubscription.ProductBusinessAC].CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						// added in new field to update- for front egg
						FLDS = $"{FLDS}, sub_frontegg_flag ";
						if (chkProductType[13].CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, '1'";
						}
						else
						{
							VALS = $"{VALS}, '0'";
						}


						// 04/20/2005 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_busair_tier_level ";
						VALS = $"{VALS}, '{cmbTierLevel.Text.Substring(Math.Max(cmbTierLevel.Text.Length - 1, 0))}'";


						// 5/15/23  - MSW
						FLDS = $"{FLDS}, sub_commair_tier_level ";
						VALS = $"{VALS}, '{cmbTierLevel_comm.Text.Substring(Math.Max(cmbTierLevel_comm.Text.Length - 1, 0))}'";


						// 04/20/2005 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_helicopters_flag ";
						if (chkProductType[modSubscription.ProductHelicopters].CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						// 04/23/2009 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_starreports_flag ";
						if (chkProductType[modSubscription.ProductStarReports].CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						// 11/12/2010 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_sale_price_flag ";
						if (chkProductType[modSubscription.ProductSPI].CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						// 04/20/2005 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_commerical_flag ";
						if (chkProductType[modSubscription.ProductCommercial].CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						FLDS = $"{FLDS}, sub_yacht_flag ";
						VALS = $"{VALS}, 'N'";

						// 04/20/2005 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_aerodex_flag ";
						if (chkProductType[modSubscription.ProductAerodex].CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						// 02/06/2008 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_abi_flag ";
						if (chkProductType[modSubscription.ProductABIListing].CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						// 09/20/2019 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_mpm_flag ";
						if (chkProductType[modSubscription.ProductMPM].CheckState == CheckState.Checked)
						{ // changed here from 2 to 12 - 2 did not exist
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						// 05/20/2015 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_share_by_comp_id_flag ";
						if (chkProductType[modSubscription.ShareByCompId].CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						// 05/20/2015 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_share_by_parent_sub_id_flag ";
						if (chkProductType[modSubscription.ShareByParentId].CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						// 07/31/2019 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_history_flag ";
						if (chkProductType[modSubscription.ProductHistory].CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						// 04/20/2005 - By David D. Cruger; Added
						FLDS = $"{FLDS}, sub_frequency ";
						VALS = $"{VALS}, '{cmbFrequency.Text}'";

						// 11/26/2007 - By David D. Cruger - Added
						FLDS = $"{FLDS}, sub_nbr_of_installs ";
						strTemp1 = ($"{txt_SubNbrOfInstalls[iNbrInstalls].Text} ").Trim(); // Nbr Installs
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								VALS = $"{VALS}, {strTemp1}";
							}
							else
							{
								VALS = $"{VALS},0 ";
							}
						}
						else
						{
							VALS = $"{VALS},0 ";
						}

						// 10/28/2016- By David D. Cruger - Added
						FLDS = $"{FLDS}, sub_nbr_of_spi_installs ";
						strTemp1 = ($"{txt_SubNbrOfInstalls[iNBRVALUEINSTALLS].Text} ").Trim(); // Nbr SPI/Values Installs
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								VALS = $"{VALS}, {strTemp1}";
							}
							else
							{
								VALS = $"{VALS},0 ";
							}
						}
						else
						{
							VALS = $"{VALS},0 ";
						}

						// 09/20/2019- By David D. Cruger - Added
						FLDS = $"{FLDS}, sub_mpm_nbr_installs ";
						strTemp1 = ($"{txt_SubNbrOfInstalls[iNBRMPMINSTALLS].Text} ").Trim(); // Nbr MPM Installs
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								VALS = $"{VALS}, {strTemp1}";
							}
							else
							{
								VALS = $"{VALS},0 ";
							}
						}
						else
						{
							VALS = $"{VALS},0 ";
						}

						// 11/26/2007 - By David D. Cruger - Added
						FLDS = $"{FLDS}, sub_contract_amount ";
						strTemp1 = ($"{txt_SubContractAmount.Text} ").Trim();
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								VALS = $"{VALS}, {strTemp1}";
							}
							else
							{
								VALS = $"{VALS},0.00 ";
							}
						}
						else
						{
							VALS = $"{VALS},0.00 ";
						}

						// ADDED MSW - 9/14/21 ---- bill amount save
						FLDS = $"{FLDS}, sub_billed_amount ";
						strTemp1 = ($"{txt_sub_billed_amount.Text} ").Trim();
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								VALS = $"{VALS}, {strTemp1}";
							}
							else
							{
								VALS = $"{VALS},0.00 ";
							}
						}
						else
						{
							VALS = $"{VALS},0.00 ";
						}


						FLDS = $"{FLDS}, sub_server_side_notes_flag ";
						if (chkServerSideNotes.CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						FLDS = $"{FLDS}, sub_server_side_dbase_name ";

						strDatabase = ($"{cmbCRMDatabaseName.Text} ").Trim();
						iPos1 = (strDatabase.IndexOf('|') + 1);
						if (iPos1 > 0)
						{
							strDatabase = strDatabase.Substring(Math.Min(iPos1, strDatabase.Length)).Trim(); // Removes Company Name
						}

						if (strDatabase != "")
						{
							VALS = $"{VALS}, '{strDatabase}'";
						}
						else
						{
							VALS = $"{VALS}, NULL";
						}

						FLDS = $"{FLDS}, sub_server_side_crm_regid ";
						strTemp1 = ($"{txtCRMRegId.Text} ").Trim();
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							VALS = $"{VALS}, {strTemp1}";
						}
						else
						{
							VALS = $"{VALS}, 0";
						}

						//---------------------------------------------
						// 09/05/2013 - By David D. Cruger
						// Cloud Notes

						FLDS = $"{FLDS}, sub_cloud_notes_flag ";
						if (chkCloudNotesFlag.CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						FLDS = $"{FLDS}, sub_cloud_notes_database ";

						strDatabase = ($"{cmbCloudNotesDatabaseName.Text} ").Trim();
						iPos1 = (strDatabase.IndexOf(" - ") + 1);
						if (iPos1 > 0)
						{
							strDatabase = strDatabase.Substring(0, Math.Min(iPos1, strDatabase.Length)).Trim(); // Removes Company Name
						}

						if (strDatabase != "")
						{
							VALS = $"{VALS}, '{strDatabase}'";
						}
						else
						{
							VALS = $"{VALS}, NULL";
						}

						FLDS = $"{FLDS}, sub_max_allowed_custom_export ";

						txtSubMaxExport.Text = StringsHelper.Replace(txtSubMaxExport.Text, ",", "", 1, -1, CompareMethod.Binary);

						if (txtSubMaxExport.Text != "")
						{
							if (Information.IsNumeric(txtSubMaxExport.Text))
							{
								VALS = $"{VALS}, {txtSubMaxExport.Text}";
							}
							else
							{
								VALS = $"{VALS}, 2000";
							}
						}
						else
						{
							VALS = $"{VALS}, 2000";
						}

						Query = $"{FLDS}{VALS})";


						// DOUBLE MAKE SURE THAT IT IS NOT DUPLICATED
						//UPGRADE_WARNING: (1068) Find_Highest_Subscriptions of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						if (Convert.ToDouble(Find_Highest_Subscriptions()) != lSubId)
						{

							MessageBox.Show("Your Subscription has ALREADY BEEN CREATED, PLEASE START OVER AND TRY AGAIN", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
							strTemp1 = strTemp1;
						}
						else
						{
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery(); //aey 6/21/04


							M = "Add Successfully Completed.";
							//         Call MsgBox(M, vbApplicationModal + vbExclamation + vbOKOnly, "ADD COMPLETE")

							// 03/12/2003 - By David D. Cruger
							// If someone adds a subscription log an event entry
							strTemp1 = $"CompId:=[{lCompId.ToString()}] SubId:=[{lSubId.ToString()}] ";
							strTemp1 = $"{strTemp1}Service:=[{cbo_Service.Text}] Freq:=[{cmbFrequency.Text}] ";
							strTemp1 = $"{strTemp1}TierLevel:=[{cmbTierLevel.Text}] ";

							modAdminCommon.Record_Event("Subscription Added", strTemp1, 0, 0, lCompId);

							modSubscription.AddSubscriptionNote(lCompId, lSubId, "Subscription Added", strTemp1);

							strAddChgHasHappened = $"{strAddChgHasHappened}A New Subscription Has Been Added On SubId: {lSubId.ToString()}{Environment.NewLine}";

						}


						//-----------------------------------------
					}
					else
					{
						// If Mode = "AddSubscription" Then

						if (chkServerSideNotes.CheckState == CheckState.Unchecked)
						{
							if (cmbCRMDatabaseName.Text == "")
							{
								if (txtCRMRegId.Text == "" || txtCRMRegId.Text == "0")
								{
									if (chkCloudNotesFlag.CheckState == CheckState.Unchecked)
									{
										if (cmbCloudNotesDatabaseName.Text.Trim() == "")
										{
											bAutoCreateCloudNotesFlag = true;
											// Temp Hold
											//chkCloudNotesFlag.Value = vbChecked
											if (cmbCloudNotesDatabaseName.Text.IndexOf(" - ") >= 0)
											{
												//cmdSaveCloudNotes_Click
											}
										}
									}
								}
							}
						}

						// 03/15/2012 - By David D. Cruger
						// Check For Changes
						strQuery1 = $"SELECT * FROM Subscription WITH (NOLOCK) WHERE (sub_id = {lSubId.ToString()}) ";
						strQuery1 = $"{strQuery1}AND (sub_comp_id = {lCompId.ToString()}) ";

						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if ((!rstRec1.BOF) && (!rstRec1.EOF))
						{

							lParentId = 0;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["sub_parent_sub_id"]))
							{
								lParentId = Convert.ToInt32(rstRec1["sub_parent_sub_id"]);
							}

							// Base Message
							strTemp1 = $"CompId:=[{lCompId.ToString()}] ";
							strTemp1 = $"{strTemp1}SubId:=[{lSubId.ToString()}] ";
							strMsg = "";

							//------------------------------
							// Has Business Flag Changed

							strTemp2 = "";
							strEType = "Subscription Business Flag Changed";
							if (chkProductType[modSubscription.ProductBusinessAC].CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_business_aircraft_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: No to Yes";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (chkProductType[modSubscription.ProductBusinessAC].CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_business_aircraft_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Yes to No";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//------------------------------
							// Has Helicopter Flag Changed

							strTemp2 = "";
							strEType = "Subscription Helicopter Flag Changed";
							if (chkProductType[modSubscription.ProductHelicopters].CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_helicopters_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: No to Yes";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (chkProductType[modSubscription.ProductHelicopters].CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_helicopters_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Yes to No";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//------------------------------
							// Has Commercial Flag Changed

							strTemp2 = "";
							strEType = "Subscription Commercial Flag Changed";
							if (chkProductType[modSubscription.ProductCommercial].CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_commerical_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: No to Yes";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (chkProductType[modSubscription.ProductCommercial].CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_commerical_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Yes to No";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}



							strTemp2 = "";
							strEType = "Subscription JETNET Global Flag Changed";
							if (chkProductType[modSubscription.ProductABIListing].CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_abi_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: No to Yes";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (chkProductType[modSubscription.ProductABIListing].CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_abi_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Yes to No";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//---------------------------------------
							// Has Star Reports Flag Changed

							strTemp2 = "";
							strEType = "Subscription Star Reports Flag Changed";
							if (chkProductType[modSubscription.ProductStarReports].CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_starreports_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: No to Yes";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (chkProductType[modSubscription.ProductStarReports].CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_starreports_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Yes to No";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//------------------------------
							// Has SPI Flag Changed

							strTemp2 = "";
							strEType = "Subscription SPI Flag Changed";
							if (chkProductType[modSubscription.ProductSPI].CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_sale_price_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: No to Yes";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (chkProductType[modSubscription.ProductSPI].CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_sale_price_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Yes to No";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//------------------------------
							// Has Aerodex Flag Changed

							strTemp2 = "";
							strEType = "Subscription Aerodex Flag Changed";
							if (chkProductType[modSubscription.ProductAerodex].CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_aerodex_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: No to Yes";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (chkProductType[modSubscription.ProductAerodex].CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_aerodex_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Yes to No";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//------------------------------
							// Has MPM Flag Changed

							strTemp2 = "";
							strEType = "Subscription MPM Flag Changed";
							if (chkProductType[modSubscription.ProductMPM].CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_mpm_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: No to Yes";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (chkProductType[modSubscription.ProductMPM].CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_mpm_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Yes to No";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//----------------------------------
							// Has Share by CompId Flag Changed

							strTemp2 = "";
							strEType = "Subscription Share By CompId Flag Changed";
							if (chkProductType[modSubscription.ShareByCompId].CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_share_by_comp_id_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: No to Yes";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (chkProductType[modSubscription.ShareByCompId].CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_share_by_comp_id_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Yes to No";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//----------------------------------
							// Has Share by ParentId Flag Changed

							strTemp2 = "";
							strEType = "Subscription Share By ParentId Flag Changed";
							if (chkProductType[modSubscription.ShareByParentId].CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_share_by_parent_sub_id_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: No to Yes";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (chkProductType[modSubscription.ShareByParentId].CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_share_by_parent_sub_id_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Yes to No";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//----------------------------------
							// Has History Flag Changed

							strTemp2 = "";
							strEType = "Subscription History Flag Changed";
							if (chkProductType[modSubscription.ProductHistory].CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_history_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: No to Yes";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (chkProductType[modSubscription.ProductHistory].CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_history_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Yes to No";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//----------------------------------
							// Has Marketing Flag Changed





							strTemp2 = "";
							strEType = "Subscription Marketing Flag Changed";
							if (chkProductType[modSubscription.ProductMarketing].CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_marketing_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: No to Yes";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (chkProductType[modSubscription.ProductMarketing].CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_marketing_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Yes to No";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//------------------------------------
							// Number of Days to Expire Changed

							strNbr1 = "";
							strNbr2 = "";
							strTemp2 = "";
							strEType = "Subscription Nbr of Days To Expire Changed";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["sub_nbr_days_expire"]))
							{
								strNbr1 = StringsHelper.Format(rstRec1["sub_nbr_days_expire"], "#,##0");
							}
							if (($"{txtNbrDaysExpire.Text} ").Trim() != "")
							{
								strNbr2 = StringsHelper.Format(($"{txtNbrDaysExpire.Text} ").Trim(), "#,##0");
							}

							if (strNbr1 != strNbr2)
							{
								strTemp2 = $"Changed From: {strNbr1} to {strNbr2}";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//------------------------------
							// Has Start Date Changed

							strDate1 = "blank";
							strDate2 = "blank";
							strTemp2 = "";
							strEType = "Subscription Start Date Changed";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["sub_start_date"]))
							{
								strDate1 = Convert.ToDateTime(rstRec1["sub_start_date"]).ToString("MM/dd/yyyy");
							}
							if (($"{txt_sub_start_date.Text} ").Trim() != "")
							{
								strDate2 = DateTime.Parse(txt_sub_start_date.Text).ToString("MM/dd/yyyy");
							}

							if (strDate1 != strDate2)
							{
								strTemp2 = $"Changed From: {strDate1} to {strDate2}";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							strDate1 = "blank";
							strDate2 = "blank";
							strTemp2 = "";
							strEType = "Subscription End Date Changed";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["sub_end_date"]))
							{
								strDate1 = Convert.ToDateTime(rstRec1["sub_end_date"]).ToString("MM/dd/yyyy");
							}
							if (($"{txt_sub_end_date.Text} ").Trim() != "")
							{
								strDate2 = DateTime.Parse(txt_sub_end_date.Text).ToString("MM/dd/yyyy");
							}

							if (strDate1 != strDate2)
							{
								strTemp2 = $"Changed From: {strDate1} to {strDate2}";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
								if (strDate2 != "blank")
								{
									modSubscription.AddSubscriptionNote(lCompId, lSubId, $"Entered Subscription End Date of {strDate2}", "");
								}
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//------------------------------
							// Contract Amount $ Changed

							strNbr1 = "blank";
							strNbr2 = "blank";
							strTemp2 = "";
							strEType = "Subscription Contract Amt $ Changed";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["sub_contract_amount"]))
							{
								strNbr1 = StringsHelper.Format(rstRec1["sub_contract_amount"], "#,##0.00");
							}
							if (($"{txt_SubContractAmount.Text} ").Trim() != "")
							{
								strNbr2 = StringsHelper.Format(($"{txt_SubContractAmount.Text} ").Trim(), "#,##0.00");
							}

							if (strNbr1 != strNbr2)
							{
								strTemp2 = $"Changed From: {strNbr1} to {strNbr2}";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
								modSubscription.AddSubscriptionNote(lCompId, lSubId, $"Contract Amount $ Changed To {strNbr2}", "");
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//------------------------------
							// Number of Installs Changed

							strNbr1 = "";
							strNbr2 = "";
							strTemp2 = "";
							strEType = "Subscription Nbr Installs Changed";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["sub_nbr_of_installs"]))
							{
								strNbr1 = StringsHelper.Format(rstRec1["sub_nbr_of_installs"], "#,##0");
							}
							if (($"{txt_SubNbrOfInstalls[iNbrInstalls].Text} ").Trim() != "")
							{
								strNbr2 = StringsHelper.Format(($"{txt_SubNbrOfInstalls[iNbrInstalls].Text} ").Trim(), "#,##0");
							}

							if (strNbr1 != strNbr2)
							{
								strTemp2 = $"Changed From: {strNbr1} to {strNbr2}";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}


							strNbr1 = "";
							strNbr2 = "";
							strTemp2 = "";
							strEType = "Subscription Nbr Value Installs Changed";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["sub_nbr_of_spi_installs"]))
							{
								strNbr1 = StringsHelper.Format(rstRec1["sub_nbr_of_spi_installs"], "#,##0");
							}
							if (($"{txt_SubNbrOfInstalls[iNBRVALUEINSTALLS].Text} ").Trim() != "")
							{
								strNbr2 = StringsHelper.Format(($"{txt_SubNbrOfInstalls[iNBRVALUEINSTALLS].Text} ").Trim(), "#,##0");
							}

							if (strNbr1 != strNbr2)
							{
								strTemp2 = $"Changed From: {strNbr1} to {strNbr2}";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//-------------------------------------------
							// 09/20/2019 - By David D. Cruger; Added
							// Number of MPM Installs Changed

							strNbr1 = "";
							strNbr2 = "";
							strTemp2 = "";
							strEType = "Subscription Nbr MPM Installs Changed";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["sub_mpm_nbr_installs"]))
							{
								strNbr1 = StringsHelper.Format(rstRec1["sub_mpm_nbr_installs"], "#,##0");
							}
							if (($"{txt_SubNbrOfInstalls[iNBRMPMINSTALLS].Text} ").Trim() != "")
							{
								strNbr2 = StringsHelper.Format(($"{txt_SubNbrOfInstalls[iNBRMPMINSTALLS].Text} ").Trim(), "#,##0");
							}

							if (strNbr1 != strNbr2)
							{
								strTemp2 = $"Changed From: {strNbr1} to {strNbr2}";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//------------------------------
							// Service Changed

							strTemp2 = "";
							strEType = "Subscription Service Changed";
							if (($"{cbo_Service.Text} ").Trim() != ($"{Convert.ToString(rstRec1["sub_serv_code"])} ").Trim())
							{
								strTemp2 = $"Changed From: {($"{Convert.ToString(rstRec1["sub_serv_code"])} ").Trim()} to {($"{cbo_Service.Text} ").Trim()}";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
								modSubscription.AddSubscriptionNote(lCompId, lSubId, $"Service {strTemp2}", "");
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}


							strTemp2 = "";
							strEType = "Subscription Frequency Changed";
							if (($"{cmbFrequency.Text} ").Trim() != ($"{Convert.ToString(rstRec1["sub_frequency"])} ").Trim())
							{
								strTemp2 = $"Changed From: {($"{Convert.ToString(rstRec1["sub_frequency"])} ").Trim()} to {($"{cmbFrequency.Text} ").Trim()}";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
								modSubscription.AddSubscriptionNote(lCompId, lSubId, $"Frequency {strTemp2}", "");
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//------------------------------
							// Tier Level Changed

							strTemp2 = "";
							strEType = "Subscription TierLevel Changed";

							if (cmbTierLevel.Text.Substring(Math.Max(cmbTierLevel.Text.Length - 1, 0)) != ($"{Convert.ToString(rstRec1["sub_busair_tier_level"])} ").Trim())
							{
								strTemp2 = $"Changed From: T{($"{Convert.ToString(rstRec1["sub_busair_tier_level"])} ").Trim()} to T{cmbTierLevel.Text.Substring(Math.Max(cmbTierLevel.Text.Length - 1, 0))}";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
								modSubscription.AddSubscriptionNote(lCompId, lSubId, $"Tier Level {strTemp2}", "");
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}


							// added MSW - 5/15/23 for subscription tier level per request
							strTemp2 = "";
							strEType = "Subscription Commercial TierLevel Changed";
							if (cmbTierLevel_comm.Text.Substring(Math.Max(cmbTierLevel_comm.Text.Length - 1, 0)) != ($"{Convert.ToString(rstRec1["sub_commair_tier_level"])} ").Trim())
							{
								strTemp2 = $"Changed From: T{($"{Convert.ToString(rstRec1["sub_commair_tier_level"])} ").Trim()} to T{cmbTierLevel_comm.Text.Substring(Math.Max(cmbTierLevel_comm.Text.Length - 1, 0))}";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
								modSubscription.AddSubscriptionNote(lCompId, lSubId, $"Tier Level {strTemp2}", "");
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}




							strTemp2 = "";
							strEType = "Subscription Server Side Notes Changed";
							if (chkServerSideNotes.CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_server_side_notes_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: Server Side Notes To YES ";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							strTemp2 = "";
							if (chkServerSideNotes.CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_server_side_notes_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Server Side Notes To NO ";
								modAdminCommon.Record_Event("Subscription Server Side Notes Changed", $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}


							strTemp2 = "";
							strEType = "Subscription Cloud Notes Changed";
							if (chkCloudNotesFlag.CheckState == CheckState.Checked && ($"{Convert.ToString(rstRec1["sub_cloud_notes_flag"])} ").Trim() == "N")
							{
								strTemp2 = "Changed From: Cloud Notes To YES ";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
								modSubscription.AddSubscriptionNote(lCompId, lSubId, $"Cloud Notes {strTemp2}", "");
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							strTemp2 = "";
							strEType = "Subscription Cloud Notes Changed";
							if (chkCloudNotesFlag.CheckState == CheckState.Unchecked && ($"{Convert.ToString(rstRec1["sub_cloud_notes_flag"])} ").Trim() == "Y")
							{
								strTemp2 = "Changed From: Cloud Notes To NO ";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
								modSubscription.AddSubscriptionNote(lCompId, lSubId, $"Cloud Notes {strTemp2}", "");
							}
							if (strTemp2 != "")
							{
								strMsg = $"{strMsg}{strEType} {strTemp2}{Environment.NewLine}";
							}

							//-----------------------------------
							// 11/05/2013 - By David D. Cruger
							// Max Allowed Custom Export

							strNbr1 = "";
							strNbr2 = "";
							strTemp2 = "";
							strEType = "Subscription Max Allowed Custom Export Changed";
							txtSubMaxExport.Text = StringsHelper.Replace(txtSubMaxExport.Text, ",", "", 1, -1, CompareMethod.Binary);
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["sub_max_allowed_custom_export"]))
							{
								strNbr1 = Convert.ToString(rstRec1["sub_max_allowed_custom_export"]);
							}
							if (($"{txtSubMaxExport.Text} ").Trim() != "")
							{
								strNbr2 = ($"{txtSubMaxExport.Text} ").Trim();
							}

							if (strNbr1 != strNbr2)
							{

								strTemp2 = $"Changed From: {strNbr1} to {strNbr2}";
								modAdminCommon.Record_Event(strEType, $"{strTemp1}{strTemp2}", 0, 0, modSubscription.Entered_Company_ID);
								modSubscription.AddSubscriptionNote(lCompId, lSubId, $"Max Export {strTemp2}", "");

								strEMailTo = modCommon.DLookUp("aconfig_max_export_change_email", "Application_Configuration");

								if (strEMailTo != "")
								{

									// Temp Hold - For Testing
									//strEMailTo = "david@jetnet.com"

									strReplyName = "Homebase Max Export Changed";
									strSubject = $"Homebase - {strEType}";
									strBody = $"{strSubject}{Environment.NewLine}" +
									          $"UserId: {modAdminCommon.gbl_User_ID} - {modAdminCommon.gbl_User_Name}{Environment.NewLine}{Environment.NewLine}" +
									          $"CompId: {modSubscription.Entered_Company_ID.ToString()}{Environment.NewLine}" +
									          $"SubId : {lSubId.ToString()}{Environment.NewLine}{Environment.NewLine}" +
									          $"{modCommon.GetCompanyInfo(modSubscription.Entered_Company_ID)}{Environment.NewLine}{Environment.NewLine}" +
									          $"{strTemp2}";

									bResults = modEmail.Simple_Insert_EMail_Queue_Record(strEMailTo, "", "", strSubject, strBody, "", "N", "Open", strReplyName, "service@jetnet.com", modSubscription.Entered_Company_ID, 0, lSubId);

									if (modAdminCommon.gbl_Live_flag)
									{
										modEmail.Send_All_EMail_In_Queue(ref strErrorMsg, modSubscription.Entered_Company_ID);
									}

								} // If strEMailTo <> "" Then

							} // If strNbr1 <> strNbr2 Then

							//If strTemp2 <> "" Then strMsg = strMsg & strEType & " " & strTemp2 & vbCrLf

						} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

						rstRec1.Close();

						//------------------------------------
						// Now Update Scription Record

						Query = $"UPDATE Subscription SET  sub_id = {lSubId.ToString()}";
						Query = $"{Query}, sub_comp_id = {lCompId.ToString()}";


						temp_serve = serv_code[cbo_Service.SelectedIndex];
						temp_serve = temp_serve.Substring(Math.Max(temp_serve.Length - (Strings.Len(temp_serve) - (temp_serve.IndexOf(" - ") + 1)), 0));
						temp_serve = StringsHelper.Replace(temp_serve, "- ", "", 1, -1, CompareMethod.Binary);

						Query = $"{Query}, sub_serv_code = '{temp_serve}'";


						Query = $"{Query}, sub_start_date = '{txt_sub_start_date.Text.Trim()}'";
						if (txt_sub_end_date.Text.Trim() != "")
						{
							Query = $"{Query}, sub_end_date = '{txt_sub_end_date.Text.Trim()}'";
						}
						else
						{
							Query = $"{Query}, sub_end_date = NULL";
						}

						// 04/23/2009 - By David D. Cruger
						// Added Callback Fields

						if (Information.IsDate(txtCallBackDate.Text))
						{
							Query = $"{Query}, sub_callback_date = '{($"{txtCallBackDate.Text} ").Trim()}' ";
						}
						else
						{
							Query = $"{Query}, sub_callback_date = NULL";
						}

						if (cboCallBackStatus.Text != "")
						{
							Query = $"{Query}, sub_callback_status = '{cboCallBackStatus.Text.Substring(Math.Min(0, cboCallBackStatus.Text.Length), Math.Min(2, Math.Max(0, cboCallBackStatus.Text.Length)))}'";
						}
						else
						{
							Query = $"{Query}, sub_callback_status = ''";
						}

						if (txtCallbackComments.Text != "")
						{
							Query = $"{Query}, sub_callback_comment = '{StringsHelper.Replace(txtCallbackComments.Text, "'", "''", 1, -1, CompareMethod.Binary)}'";
						}
						else
						{
							Query = $"{Query}, sub_callback_comment = ''";
						}

						//-----------------------------------------------

						// added MSW - 1/19/23
						if (chk_sub_api_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_api_flights_flag = 'Y' ";
						}
						else
						{
							Query = $"{Query}, sub_api_flights_flag = 'N' ";
						}

						// added in new field to update- for front egg
						if (chkProductType[13].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_frontegg_flag = '1' ";
						}
						else
						{
							Query = $"{Query}, sub_frontegg_flag = '0' ";
						}


						// 03/16/2004 - By David D. Cruger; Added Marketing Flag and Nbr of Days Expire
						if (chkProductType[modSubscription.ProductMarketing].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_marketing_flag = 'Y' ";
						}
						else
						{
							Query = $"{Query}, sub_marketing_flag = 'N' ";
						}

						Query = $"{Query}, sub_nbr_days_expire = {txtNbrDaysExpire.Text} ";

						Query = $"{Query}, sub_upd_date = GetDate()  , sub_upd_user_id = '{modAdminCommon.gbl_User_ID}'";
						Query = $"{Query}, sub_action_date = '01/01/1900' ";

						// 04/20/2005 - By David D. Cruger; Added
						if (chkProductType[modSubscription.ProductBusinessAC].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_business_aircraft_flag ='Y' ";
						}
						else
						{
							Query = $"{Query}, sub_business_aircraft_flag ='N' ";
						}

						// 04/20/2005 - By David D. Cruger; Added
						Query = $"{Query}, sub_busair_tier_level = '{cmbTierLevel.Text.Substring(Math.Max(cmbTierLevel.Text.Length - 1, 0))}' ";

						// add subscription - 5/15/23
						Query = $"{Query}, sub_commair_tier_level = '{cmbTierLevel_comm.Text.Substring(Math.Max(cmbTierLevel_comm.Text.Length - 1, 0))}' ";

						// 04/20/2005 - By David D. Cruger; Added
						if (chkProductType[modSubscription.ProductHelicopters].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_helicopters_flag ='Y' ";
						}
						else
						{
							Query = $"{Query}, sub_helicopters_flag ='N' ";
						}

						// 04/23/2009 - By David D. Cruger; Added
						if (chkProductType[modSubscription.ProductStarReports].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_starreports_flag ='Y' ";
						}
						else
						{
							Query = $"{Query}, sub_starreports_flag ='N' ";
						}

						// 11/12/2010 - By David D. Cruger; Added
						if (chkProductType[modSubscription.ProductSPI].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_sale_price_flag ='Y' ";
						}
						else
						{
							Query = $"{Query}, sub_sale_price_flag ='N' ";
						}

						// 04/20/2005 - By David D. Cruger; Added
						if (chkProductType[modSubscription.ProductCommercial].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_commerical_flag ='Y' ";
						}
						else
						{
							Query = $"{Query}, sub_commerical_flag ='N' ";
						}

						Query = $"{Query}, sub_yacht_flag ='N' ";

						// 04/20/2005 - By David D. Cruger; Added
						if (chkProductType[modSubscription.ProductAerodex].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_aerodex_flag ='Y' ";
						}
						else
						{
							Query = $"{Query}, sub_aerodex_flag ='N' ";
						}

						// 02/06/2008 - By David D. Cruger; Added
						if (chkProductType[modSubscription.ProductABIListing].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_abi_flag ='Y' ";
						}
						else
						{
							Query = $"{Query}, sub_abi_flag ='N' ";
						}

						// 09/20/2019 - By David D. Cruger; Added
						if (chkProductType[modSubscription.ProductMPM].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_mpm_flag ='Y' ";
						}
						else
						{
							Query = $"{Query}, sub_mpm_flag ='N' ";
						}

						// 05/20/2015 - By David D. Cruger; Added
						if (chkProductType[modSubscription.ShareByCompId].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_share_by_comp_id_flag ='Y' ";
						}
						else
						{
							Query = $"{Query}, sub_share_by_comp_id_flag ='N' ";
						}

						// 05/20/2015 - By David D. Cruger; Added
						if (chkProductType[modSubscription.ShareByParentId].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_share_by_parent_sub_id_flag ='Y' ";
						}
						else
						{
							Query = $"{Query}, sub_share_by_parent_sub_id_flag ='N' ";
						}

						// 07/31/2019 - By David D. Cruger; Added
						if (chkProductType[modSubscription.ProductHistory].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, sub_history_flag ='Y' ";
						}
						else
						{
							Query = $"{Query}, sub_history_flag ='N' ";
						}

						// 04/20/2005 - By David D. Cruger; Added
						Query = $"{Query}, sub_frequency = '{cmbFrequency.Text}' ";

						// 11/26/2007 - By David D. Cruger - Added
						Query = $"{Query}, sub_nbr_of_installs = ";
						strTemp1 = ($"{txt_SubNbrOfInstalls[iNbrInstalls].Text} ").Trim();
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								Query = $"{Query}{strTemp1}";
							}
							else
							{
								Query = $"{Query}0 ";
							}
						}
						else
						{
							Query = $"{Query}0 ";
						}

						// 10/28/2016 - By David D. Cruger - Added
						Query = $"{Query}, sub_nbr_of_spi_installs = ";
						strTemp1 = ($"{txt_SubNbrOfInstalls[iNBRVALUEINSTALLS].Text} ").Trim();
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								Query = $"{Query}{strTemp1}";
							}
							else
							{
								Query = $"{Query}0 ";
							}
						}
						else
						{
							Query = $"{Query}0 ";
						}

						// 09/20/2019 - By David D. Cruger - Added
						Query = $"{Query}, sub_mpm_nbr_installs = ";
						strTemp1 = ($"{txt_SubNbrOfInstalls[iNBRMPMINSTALLS].Text} ").Trim();
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								Query = $"{Query}{strTemp1}";
							}
							else
							{
								Query = $"{Query}0 ";
							}
						}
						else
						{
							Query = $"{Query}0 ";
						}

						// 11/26/2007 - By David D. Cruger - Added
						Query = $"{Query}, sub_contract_amount = ";
						strTemp1 = ($"{txt_SubContractAmount.Text} ").Trim();
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								Query = $"{Query}{strTemp1}";
							}
							else
							{
								Query = $"{Query}0.00 ";
							}
						}
						else
						{
							Query = $"{Query}0.00 ";
						}


						Query = $"{Query}, sub_billed_amount  = ";
						strTemp1 = ($"{txt_sub_billed_amount.Text} ").Trim();
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							if (Conversion.Val(strTemp1) >= 0)
							{
								Query = $"{Query}{strTemp1}";
							}
							else
							{
								Query = $"{Query}0.00 ";
							}
						}
						else
						{
							Query = $"{Query}0.00 ";
						}


						Query = $"{Query}, sub_server_side_notes_flag = ";
						if (chkServerSideNotes.CheckState == CheckState.Checked)
						{
							Query = $"{Query}'Y' ";
						}
						else
						{
							Query = $"{Query}'N' ";
						}

						strDatabase = ($"{cmbCRMDatabaseName.Text} ").Trim();
						iPos1 = (strDatabase.IndexOf('|') + 1);
						if (iPos1 > 0)
						{
							strDatabase = strDatabase.Substring(Math.Min(iPos1, strDatabase.Length)).Trim(); // Removes Company Name
						}

						Query = $"{Query}, sub_server_side_dbase_name = ";
						if (strDatabase != "")
						{
							Query = $"{Query}'{strDatabase}' ";
						}
						else
						{
							Query = $"{Query}NULL ";
						}

						Query = $"{Query}, sub_server_side_crm_regid = ";
						strTemp1 = ($"{txtCRMRegId.Text} ").Trim();
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							Query = $"{Query}{strTemp1} ";
						}
						else
						{
							Query = $"{Query}0 ";
						}

						Query = $"{Query}, sub_cloud_notes_flag = ";
						if (chkCloudNotesFlag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}'Y' ";
						}
						else
						{
							Query = $"{Query}'N' ";
						}

						Query = $"{Query}, sub_cloud_notes_database = ";

						if (($"{cmbCloudNotesDatabaseName.Text} ").Trim() != "")
						{
							strDatabase = ($"{cmbCloudNotesDatabaseName.Text} ").Trim();
							iPos1 = (strDatabase.IndexOf(" - ") + 1);
							if (iPos1 > 0)
							{
								strDatabase = strDatabase.Substring(0, Math.Min(iPos1, strDatabase.Length)).Trim(); // Removes Company Name
							}
							Query = $"{Query}'{strDatabase}' ";
						}
						else
						{
							Query = $"{Query}NULL ";
						}

						//-------------------------------------
						// 11/05/2013 - By David D. Cruger
						// 04/28/2015 - By David D. Cruger; Per Tony increase default to 10,000

						Query = $"{Query}, sub_max_allowed_custom_export = ";
						strTemp1 = ($"{txtSubMaxExport.Text} ").Trim();
						strTemp1 = StringsHelper.Replace(strTemp1, ",", "", 1, -1, CompareMethod.Binary);
						if (Information.IsNumeric(strTemp1))
						{
							if (Convert.ToInt32(Double.Parse(strTemp1)) >= 0)
							{
								Query = $"{Query}{strTemp1}";
							}
							else
							{
								Query = $"{Query}10000 ";
							}
						}
						else
						{
							Query = $"{Query}10000 ";
						}

						Query = $"{Query} WHERE (sub_id = '{txt_sub_id.Text.Trim()}') ";

						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery(); //aey 6/21/04

						modSubscription.gbl_SubID = Convert.ToInt32(Double.Parse(txt_sub_id.Text.Trim()));
						UpdateActionDate();
						M = "Update Successfully Completed.";

						if (StringsHelper.Replace(strMsg, Environment.NewLine, "", 1, -1, CompareMethod.Binary).Trim() != "")
						{
							// Send To Everyone
							modCommon.Enter_Customer_Program_Message_Note("", "", strMsg, modSubscription.gbl_SubID, lParentId, lCompId, 0);
						}

					} // <>  If Mode = "AddSubscription" Then

					modSubscription.gstrService = serv_code[cbo_Service.SelectedIndex];

					Update_Subscription_Service_Name(lSubId);

					Fill_grd_Subscriptions(modSubscription.Entered_Company_ID);

					if (grd_Subscriptions.RowsCount == 1)
					{
						if (chkIncludeInactive.CheckState == CheckState.Unchecked)
						{
							chkIncludeInactive.CheckState = CheckState.Checked;
							Fill_grd_Subscriptions(modSubscription.Entered_Company_ID);
						}
					}

				} // If VerifySubscription() = True Then

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Save_Subscription_Data_Error: {excep.Message}");
			}

		} // Save_Subscription_Data

		// 08/04/2005 - By David D. Cruger; Converted DAO to ADO
		private void Fill_Subscription_Panel(int inSubID)
		{

			string strUserId = "";
			string Query = "";
			ADORecordSetHelper snp_S = new ADORecordSetHelper();
			int temp_col = 0;

			try
			{

				frm_Sub_Id.Text = "Subscriptions for this Company";
				strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();

				Query = $"SELECT * FROM Subscription WITH (NOLOCK) WHERE (sub_id = {inSubID.ToString()}) ";

				snp_S.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!snp_S.BOF) && (!snp_S.EOF))
				{

					frm_Sub_Id.Text = $"Subscriptions for this Company (Parent SubId [{StringsHelper.Format(snp_S["sub_parent_sub_id"], "0000")}])";

					txt_sub_id.Text = ($"{Convert.ToString(snp_S["sub_id"])} ").Trim();
					txt_sub_start_date.Text = ($"{Convert.ToString(snp_S["sub_start_date"])} ").Trim();
					txt_sub_end_date.Text = ($"{Convert.ToString(snp_S["sub_end_date"])} ").Trim();
					cal_sub_start_date.SetDate(DateTime.Parse(($"{txt_sub_start_date.Text} ").Trim()));

					lbl_Service.Tag = "";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_S["sub_service_name"]))
					{
						lbl_Service.Tag = ($"{Convert.ToString(snp_S["sub_service_name"])} ").Trim();
					}

					// 04/23/2009 - By David D. Cruger
					// Added Callback Fields
					txtCallBackDate.Text = ($"{Convert.ToString(snp_S["sub_callback_date"])} ").Trim();
					if (Information.IsDate(txtCallBackDate.Text))
					{
						calCallBackDate.SetDate(DateTime.Parse(($"{txtCallBackDate.Text} ").Trim()));
					}
					else
					{
						calCallBackDate.SetDate(DateTime.Today);
					}
					txtCallbackComments.Text = ($"{Convert.ToString(snp_S["sub_callback_comment"])} ").Trim();

					if (($"{Convert.ToString(snp_S["sub_callback_status"])} ").Trim() != "")
					{

						// Find Status
						int tempForEndVar = cboCallBackStatus.Items.Count - 1;
						for (int I = 0; I <= tempForEndVar; I++)
						{
							if (($"{Convert.ToString(snp_S["sub_callback_status"])} ").Trim() == cboCallBackStatus.GetListItem(I).Substring(Math.Min(0, cboCallBackStatus.GetListItem(I).Length), Math.Min(2, Math.Max(0, cboCallBackStatus.GetListItem(I).Length))))
							{
								cboCallBackStatus.SelectedIndex = I;
							}
						}

					}
					else
					{
						cboCallBackStatus.SelectedIndex = 0;
					}

					if (txt_sub_end_date.Text != "")
					{
						cal_sub_end_date.SetDate(DateTime.Parse(txt_sub_end_date.Text));
					}
					else
					{
						cal_sub_end_date.SetDate(DateTime.Today);
					}

					if (($"{Convert.ToString(snp_S["sub_business_aircraft_flag"])} ").Trim() == "Y")
					{
						chkProductType[modSubscription.ProductBusinessAC].CheckState = CheckState.Checked;
					}
					else
					{
						chkProductType[modSubscription.ProductBusinessAC].CheckState = CheckState.Unchecked;
					}

					int tempForEndVar2 = cmbTierLevel.Items.Count - 1;
					for (int I = 0; I <= tempForEndVar2; I++)
					{
						if (cmbTierLevel.GetListItem(I).Substring(Math.Max(cmbTierLevel.GetListItem(I).Length - 1, 0)) == ($"{Convert.ToString(snp_S["sub_busair_tier_level"])} ").Trim())
						{
							cmbTierLevel.SelectedIndex = I;
						}
					}

					// added MSW - 5/15/23
					int tempForEndVar3 = cmbTierLevel_comm.Items.Count - 1;
					for (int I = 0; I <= tempForEndVar3; I++)
					{
						if (cmbTierLevel_comm.GetListItem(I).Substring(Math.Max(cmbTierLevel_comm.GetListItem(I).Length - 1, 0)) == ($"{Convert.ToString(snp_S["sub_commair_tier_level"])} ").Trim())
						{
							cmbTierLevel_comm.SelectedIndex = I;
						}
					}

					if (($"{Convert.ToString(snp_S["sub_helicopters_flag"])} ").Trim() == "Y")
					{
						chkProductType[modSubscription.ProductHelicopters].CheckState = CheckState.Checked;
					}
					else
					{
						chkProductType[modSubscription.ProductHelicopters].CheckState = CheckState.Unchecked;
					}

					// 13 is the tag for frontegg - 7/26/24
					bool tempBool = false;
					string auxVar = Convert.ToString(snp_S["sub_frontegg_flag"]).Trim();
					if ((Boolean.TryParse(auxVar, out tempBool)) ? tempBool : Convert.ToBoolean(Double.Parse(auxVar)))
					{
						chkProductType[13].CheckState = CheckState.Checked;
					}
					else
					{
						chkProductType[13].CheckState = CheckState.Unchecked;
					}


					if (($"{Convert.ToString(snp_S["sub_starreports_flag"])} ").Trim() == "Y")
					{
						chkProductType[modSubscription.ProductStarReports].CheckState = CheckState.Checked;
					}
					else
					{
						chkProductType[modSubscription.ProductStarReports].CheckState = CheckState.Unchecked;
					}

					// 11/12/2010 - By David D. Cruger; Added
					if (($"{Convert.ToString(snp_S["sub_sale_price_flag"])} ").Trim() == "Y")
					{
						chkProductType[modSubscription.ProductSPI].CheckState = CheckState.Checked;
					}
					else
					{
						chkProductType[modSubscription.ProductSPI].CheckState = CheckState.Unchecked;
					}

					if (($"{Convert.ToString(snp_S["sub_commerical_flag"])} ").Trim() == "Y")
					{
						chkProductType[modSubscription.ProductCommercial].CheckState = CheckState.Checked;
						cmbTierLevel_comm.Visible = true;
					}
					else
					{
						chkProductType[modSubscription.ProductCommercial].CheckState = CheckState.Unchecked;
						cmbTierLevel_comm.Visible = false;
					}

					if (($"{Convert.ToString(snp_S["sub_aerodex_flag"])} ").Trim() == "Y")
					{
						chkProductType[modSubscription.ProductAerodex].CheckState = CheckState.Checked;
					}
					else
					{
						chkProductType[modSubscription.ProductAerodex].CheckState = CheckState.Unchecked;
					}

					// 02/06/2008 - By David D. Cruger; Added
					if (($"{Convert.ToString(snp_S["sub_abi_flag"])} ").Trim() == "Y")
					{
						chkProductType[modSubscription.ProductABIListing].CheckState = CheckState.Checked;
					}
					else
					{
						chkProductType[modSubscription.ProductABIListing].CheckState = CheckState.Unchecked;
					}

					// 09/20/20198 - By David D. Cruger; Added
					if (($"{Convert.ToString(snp_S["sub_mpm_flag"])} ").Trim() == "Y")
					{
						chkProductType[modSubscription.ProductMPM].CheckState = CheckState.Checked;
					}
					else
					{
						chkProductType[modSubscription.ProductMPM].CheckState = CheckState.Unchecked;
					}

					// 05/20/2015 - By David D. Cruger; Added
					if (($"{Convert.ToString(snp_S["sub_share_by_comp_id_flag"])} ").Trim() == "Y")
					{
						chkProductType[modSubscription.ShareByCompId].CheckState = CheckState.Checked;
					}
					else
					{
						chkProductType[modSubscription.ShareByCompId].CheckState = CheckState.Unchecked;
					}

					// 05/20/2015 - By David D. Cruger; Added
					if (($"{Convert.ToString(snp_S["sub_share_by_parent_sub_id_flag"])} ").Trim() == "Y")
					{
						chkProductType[modSubscription.ShareByParentId].CheckState = CheckState.Checked;
					}
					else
					{
						chkProductType[modSubscription.ShareByParentId].CheckState = CheckState.Unchecked;
					}

					// 07/31/2019 - By David D. Cruger; Added
					if (($"{Convert.ToString(snp_S["sub_history_flag"])} ").Trim() == "Y")
					{
						chkProductType[modSubscription.ProductHistory].CheckState = CheckState.Checked;
					}
					else
					{
						chkProductType[modSubscription.ProductHistory].CheckState = CheckState.Unchecked;
					}

					if (($"{Convert.ToString(snp_S["sub_api_flights_flag"])} ").Trim() == "Y")
					{
						chk_sub_api_flag.CheckState = CheckState.Checked;
					}
					else
					{
						chk_sub_api_flag.CheckState = CheckState.Unchecked;
					}


					int tempForEndVar4 = cmbFrequency.Items.Count - 1;
					for (int I = 0; I <= tempForEndVar4; I++)
					{
						if (cmbFrequency.GetListItem(I) == ($"{Convert.ToString(snp_S["sub_frequency"])} ").Trim())
						{
							cmbFrequency.SelectedIndex = I;
						}
					}

					modSubscription.gstrService = ($"{Convert.ToString(snp_S["sub_serv_code"])} ").Trim(); // Hold On To This To See If Service Changed

					cbo_Service.Enabled = false;
					int tempForEndVar5 = cbo_Service.Items.Count - 1;
					for (int I = 0; I <= tempForEndVar5; I++)
					{
						if (serv_code[I].Substring(Math.Max(serv_code[I].Length - (Strings.Len(modSubscription.gstrService.Trim()) + 2), 0)) == $"- {modSubscription.gstrService.Trim()}")
						{
							cbo_Service.SelectedIndex = I;
						}
					}
					cbo_Service.Enabled = true;


					// in case the column is being set for a reason, put it back
					temp_col = grd_Subscriptions.CurrentColumnIndex;
					grd_Subscriptions.CurrentColumnIndex = 2;

					//added MSW - 9/8/22
					if (cbo_Service.Text.Trim().IndexOf("API") >= 0 || grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].FormattedValue.ToString().Trim().IndexOf(" API ") >= 0)
					{
						chkProductType[modSubscription.ProductHistory].Visible = true;
						chk_sub_api_flag.Visible = true;
					}
					else
					{
						chkProductType[modSubscription.ProductHistory].Visible = false;
						chkProductType[modSubscription.ProductHistory].CheckState = CheckState.Unchecked; // default to "unchecked" for non api
						chk_sub_api_flag.Visible = false;
						chk_sub_api_flag.CheckState = CheckState.Unchecked;
					}

					grd_Subscriptions.CurrentColumnIndex = temp_col;


					// Copy Logins Label
					lblSubLabel[iCOPYLOGINS].Visible = false;
					if (modSubscription.IsSubscriptionServiceCodeForSalesForce(modSubscription.gstrService))
					{
						if (strUserId == "DCR" || strUserId == "AJA" || strUserId == "MVIT")
						{
							lblSubLabel[iCOPYLOGINS].Visible = true;
							lblSubLabel[iCOPYLOGINS].Enabled = true;
						}
					}

					// 03/16/2004 - By David D. Cruger; Added Marketing Flag and Nbr of Days Expire
					if (Convert.ToString(snp_S["sub_marketing_flag"]) == "Y")
					{
						chkProductType[modSubscription.ProductMarketing].CheckState = CheckState.Checked;
						lblNbrDaysExpire.Visible = true;
						txtNbrDaysExpire.Visible = true;
						txtNbrDaysExpire.Text = Convert.ToString(snp_S["sub_nbr_days_expire"]);
					}
					else
					{
						chkProductType[modSubscription.ProductMarketing].CheckState = CheckState.Unchecked;
						lblNbrDaysExpire.Visible = false;
						txtNbrDaysExpire.Visible = false;
						txtNbrDaysExpire.Text = "0";
					}

					// 11/26/2007 - By David D. Cruger - Added
					txt_SubNbrOfInstalls[iNbrInstalls].Text = ($"{Convert.ToString(snp_S["sub_nbr_of_installs"])} ").Trim();
					if (txt_SubNbrOfInstalls[iNbrInstalls].Text == "")
					{
						txt_SubNbrOfInstalls[iNbrInstalls].Text = "0";
					}

					// 10/28/2016 - By David D. Cruger - Added
					txt_SubNbrOfInstalls[iNBRVALUEINSTALLS].Text = ($"{Convert.ToString(snp_S["sub_nbr_of_spi_installs"])} ").Trim();
					if (txt_SubNbrOfInstalls[iNBRVALUEINSTALLS].Text == "")
					{
						txt_SubNbrOfInstalls[iNBRVALUEINSTALLS].Text = "0";
					}

					// 09/20/2019 - By David D. Cruger - Added
					txt_SubNbrOfInstalls[iNBRMPMINSTALLS].Text = ($"{Convert.ToString(snp_S["sub_mpm_nbr_installs"])} ").Trim();
					if (txt_SubNbrOfInstalls[iNBRMPMINSTALLS].Text == "")
					{
						txt_SubNbrOfInstalls[iNBRMPMINSTALLS].Text = "0";
					}

					// 11/26/2007 - By David D. Cruger - Added
					txt_SubContractAmount.Text = StringsHelper.Format(snp_S["sub_contract_amount"], "#,##0.00");
					if (txt_SubContractAmount.Text == "")
					{
						txt_SubContractAmount.Text = "0.00";
					}


					//9/14/2021 -
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_S["sub_billed_amount"]))
					{
						txt_sub_billed_amount.Text = StringsHelper.Format(snp_S["sub_billed_amount"], "#,##0.00");
					}
					if (txt_sub_billed_amount.Text == "")
					{
						txt_sub_billed_amount.Text = "0.00";
					}
					// 10/29/2010 - By David D. Cruger
					// Server Side Notes Fields

					chkServerSideNotes.Enabled = false;
					chkServerSideNotes.CheckState = CheckState.Unchecked;

					cmbCRMDatabaseName.Enabled = false;
					cmbCRMDatabaseName.Items.Clear();
					cmbCRMDatabaseName.Text = "";

					if (($"{Convert.ToString(snp_S["sub_server_side_notes_flag"])} ").Trim() == "Y")
					{

						chkServerSideNotes.CheckState = CheckState.Checked; // So Check Doesn't Trigger Event
						cmbCRMDatabaseName.Text = ($"{Convert.ToString(snp_S["sub_server_side_dbase_name"])} ").Trim();

					} // If Trim(snp_S!sub_server_side_notes_flag & " ") = "Y" Then

					chkServerSideNotes.Enabled = true;
					cmbCRMDatabaseName.Enabled = true;

					txtCRMRegId.Text = "0";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_S["sub_server_side_crm_regid"]))
					{
						txtCRMRegId.Text = Convert.ToString(snp_S["sub_server_side_crm_regid"]);

						if (($"{Convert.ToString(snp_S["sub_server_side_notes_flag"])} ").Trim() == "N" && txtCRMRegId.Text.Trim() != "0")
						{
							MessageBox.Show("This Subscription has no Server Side Notes Flag, But a CRM Reg ID. Please Re-Save.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
						}
					}

					// 09/05/2013 - By David D. Cruger
					chkCloudNotesFlag.Enabled = false;
					chkCloudNotesFlag.CheckState = CheckState.Unchecked;

					cmbCloudNotesDatabaseName.Enabled = false;
					cmbCloudNotesDatabaseName.Items.Clear();
					cmbCloudNotesDatabaseName.Text = "";

					if (($"{Convert.ToString(snp_S["sub_server_side_notes_flag"])} ").Trim() == "N")
					{

						if (($"{Convert.ToString(snp_S["sub_cloud_notes_flag"])} ").Trim() == "Y")
						{

							chkCloudNotesFlag.CheckState = CheckState.Checked;

							if (($"{Convert.ToString(snp_S["sub_cloud_notes_database"])} ").Trim() != "")
							{
								cmbCloudNotesDatabaseName.Text = ($"{Convert.ToString(snp_S["sub_cloud_notes_database"])} ").Trim();
							}

						} // If Trim(snp_S!sub_cloud_notes_flag & " ") = "Y" Then

					} // If Trim(snp_S!sub_server_side_notes_flag & " ") = "N" Then

					cmbCloudNotesDatabaseName.Enabled = true;
					chkCloudNotesFlag.Enabled = true;

					// 11/05/2013 - By David D. Cruger
					// 04/28/2015 - By David D. Cruger; Per Tony default increase to 10,000

					txtSubMaxExport.Text = "2000";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_S["sub_max_allowed_custom_export"]))
					{
						if (Convert.ToDouble(snp_S["sub_max_allowed_custom_export"]) >= 0)
						{
							txtSubMaxExport.Text = Convert.ToString(snp_S["sub_max_allowed_custom_export"]);
						}
					}

					lblSubLabel[iVIEWMPMUSERS].Tag = "0";
					lblSubLabel[iVIEWMPMUSERS].Visible = false;

					if (modSubscription.gstrService == "CRM")
					{
						if (txtCRMRegId.Text != "" && txtCRMRegId.Text != "0")
						{
							lblSubLabel[iVIEWMPMUSERS].Tag = Convert.ToInt32(Double.Parse(txtCRMRegId.Text)).ToString();
							lblSubLabel[iVIEWMPMUSERS].Visible = true;
						}
					}

					RecordStat = "Update";

				} // If (snp_S.BOF = False) And (snp_S.EOF = False) Then

				snp_S.Close();
				snp_S = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_Subscription_Panel_Error: {excep.Message}");
			}



		}


		private bool DoesUserHaveAccess()
		{

			string strUserId = "";
			string strSubId = "";
			string strErrMsg = "";

			bool bAccess = false;


			if (modSubscription.Entered_Company_ID.ToString() == "135887")
			{ //JETNET LLC account

				strErrMsg = "";
				strUserId = Convert.ToString(modAdminCommon.snp_User["user_id"]).ToUpper(); // Current User
				strSubId = txt_sub_id.Text; // Highlighted Subscriber Id

				// Check for David, Therese, Jason, Ken; Stephanie Hryb, Barb Stone, Andrew, Josiah
				if (strSubId == "777")
				{

					if ((strUserId != "DCR") && (strUserId != "TMT") && (strUserId != "JAL") && (strUserId != "KG") && (strUserId != "MVIT") && (strUserId != "BJS") && (strUserId != "AJA") && (strUserId != "SLH") && (strUserId != "PLS") && (strUserId != "JAS"))
					{

						if (Convert.ToString(modAdminCommon.snp_User["user_type"]) != "Technical" || Convert.ToString(modAdminCommon.snp_User["user_default_account_id"]) != "TECH" || Convert.ToString(modAdminCommon.snp_User["user_marketing_subids_allowed"]) != "ALL" || Convert.ToString(modAdminCommon.snp_User["user_edit_subscriptions"]) != "Y")
						{
							strErrMsg = "USER does NOT have access to this account. ";
						}

					} // <> DCR, TMT, JAL, KG, MVIT, BJS, SLH, JAS

				} // If (strSubId = "777") Then

				if (strErrMsg != "")
				{
					MessageBox.Show(strErrMsg, "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					bAccess = false;
				}
				else
				{
					bAccess = true;
				}

			}
			else
			{
				bAccess = true;
			} // If CStr(Entered_Company_ID) = "135887" Then 'JETNET LLC account

			return bAccess;

		} // End Function DoesUserHaveAccess

		private void Form_FormClosing(Object eventSender, FormClosingEventArgs eventArgs)
		{
			int Cancel = (eventArgs.Cancel) ? 1 : 0;
			int UnloadMode = (int) eventArgs.CloseReason;
			try
			{

				//--------------------------------------------------
				// No Need To Test for the JETNET Company Record

				if (modSubscription.Entered_Company_ID == 135887)
				{
					strAddChgHasHappened = "";
				}

				if (strAddChgHasHappened != "")
				{
					//UPGRADE_WARNING: (2065) QueryUnloadConstants property QueryUnloadConstants.vbFormCode has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					//UPGRADE_WARNING: (2065) QueryUnloadConstants property QueryUnloadConstants.vbFormControlMenu has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					if (UnloadMode == ((int) CloseReason.UserClosing) || UnloadMode == ((int) CloseReason.UserClosing))
					{
						if (MessageBox.Show($"{strAddChgHasHappened}{Environment.NewLine}Please Update Nbr Of Installs On The Subscription Record{Environment.NewLine}{Environment.NewLine}Do You Want To Exit Anyway", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						{
							Cancel = 1; // Cancel Unload
						}
						else
						{
							modAdminCommon.Record_Event("Subscription Modified", "User Exit Without Updating Nbr Of Installs", 0, 0, modSubscription.Entered_Company_ID);
						}
					}
					else
					{
						modAdminCommon.Record_Event("Subscription Modified", "System OS Closed Application", 0, 0, modSubscription.Entered_Company_ID);
					}
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}

		} // Form_QueryUnload

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			REMOTE_ADO_DB = null;
			AlreadyOpen = false;

			wbSubBrowser1[0].Navigate(new Uri("about:blank")); // Contracts
			wbSubBrowser1[1].Navigate(new Uri("about:blank")); // Service Interruptions
			wbSubBrowser1[2].Navigate(new Uri("about:blank")); // WebReports
			wbSubBrowser1[3].Navigate(new Uri("about:blank")); // Execution Forms
			wbSubBrowser1[4].Navigate(new Uri("about:blank")); // Subscription Summary

			JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(500); // Delay 1/2 Second

		} // Form_Unload

		private void frm_Sub_Id_Click(Object eventSender, EventArgs eventArgs)
		{

			string strUpdate1 = "";
			int lNewPSubId = 0;

			int lCurPSubId = 0;
			string strCurPSubId = "";

			string strSubId = "";
			int lSubId = 0;

			string strMsg = "";

			string strNewPSubId = InputBoxHelper.InputBox("Enter New Parent SubId");

			if (strNewPSubId != "" && strNewPSubId != "0")
			{

				if (Information.IsNumeric(strNewPSubId))
				{

					lNewPSubId = Convert.ToInt32(Double.Parse(strNewPSubId));

					if (lNewPSubId > 0)
					{

						strSubId = txt_sub_id.Text;
						lSubId = Convert.ToInt32(Double.Parse(strSubId));

						lCurPSubId = Convert.ToInt32(Double.Parse(modCommon.DLookUp("sub_parent_sub_id", "Subscription", $"(sub_id = {strSubId})")));

						if (lCurPSubId >= 0)
						{

							if (lCurPSubId != lNewPSubId)
							{

								strCurPSubId = lCurPSubId.ToString();

								strUpdate1 = $"UPDATE Subscription SET sub_parent_sub_id = {strNewPSubId}, ";
								strUpdate1 = $"{strUpdate1}sub_action_date = '01/01/1900' WHERE (sub_id = {strSubId}) ";

								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = strUpdate1;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();

								strMsg = $"Updated Parent SubId From [{strCurPSubId}] To [{strNewPSubId}] On SubId [{strSubId}]";

								modAdminCommon.Record_Event("Subscription", strMsg, 0, 0, modSubscription.Entered_Company_ID);

								grd_Subscriptions_Click(grd_Subscriptions, new EventArgs());

							}
							else
							{
								MessageBox.Show("Current Parent SubId Already Equals New Parent SubId", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If lCurPSubId <> lNewPSubId Then

						}
						else
						{
							MessageBox.Show("Current Parent SubId Can NOT Be Found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If lCurPSubId > 0 Then

					}
					else
					{
						MessageBox.Show("New Parent SubId Is Less Than Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If lNewPSubId > 0 Then

				}
				else
				{
					MessageBox.Show("New Parent SubId Is Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If IsNumeric(strNewPSubId) = True Then

			} // If strNewPSubId <> "" And strNewPSubId <> "0" Then

		} // frm_Sub_Id_Click

		private void frm_SubExecutionFormsGrid_Click(Object eventSender, EventArgs eventArgs)
		{

			frm_SubExecutionFormsGrid.Enabled = false;
			modExcel.ExportMSHFlexGrid(grd_SubExecutionForms);
			frm_SubExecutionFormsGrid.Enabled = true;

		}

		private void grd_Subscriptions_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			string strSubId = "";
			string strService = "";

			int lRow1 = grd_Subscriptions.MouseRow;
			int lCol1 = grd_Subscriptions.MouseCol;

			if (grd_Subscriptions.CurrentRowIndex > 0)
			{

				if (Button == UpgradeHelpers.Utils.WinForms.MouseButtonsHelper.GetVB6ShortValue(MouseButtons.Right))
				{

					if (grd_Subscriptions.CurrentRowIndex != lRow1)
					{
						grd_Subscriptions.CurrentRowIndex = lRow1;
						grd_Subscriptions_Click(grd_Subscriptions, new EventArgs());
					}

					mnuMPMManagement.Available = true;

					modCommon.Highlight_Grid_Row(grd_Subscriptions);

					strSubId = Convert.ToString(grd_Subscriptions[lRow1, 0].Value);
					strService = Convert.ToString(grd_Subscriptions[lRow1, 1].Value);

					if (strService == "CRM")
					{
						//UPGRADE_WARNING: (6024) Default menues are not supported for Context Menues (Popup) More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6024
						Ctx_mnuRightClick.Show(this, PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y);
						grd_Subscriptions.Redraw = true;
					}

				} // If Button = vbRightButton Then

			} // If grd_Subscriptions.Row > 0 Then

		} // grd_Subscriptions_MouseDown

		private void grd_SubSIDocument_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strDocId = "";
			string strDocDir = "";
			string strFileName = "";

			try
			{

				if (grd_SubSIDocument.Enabled)
				{

					grd_SubSIDocument.Enabled = false;

					strFileName = "about:blank";
					wbSubBrowser1[1].Navigate(new Uri(strFileName));
					cmdSubSIDocView.Tag = "";
					cmdSubSIDocView.Enabled = false;

					modCommon.DelaySeconds(1);

					grd_SubSIDocument.CurrentColumnIndex = 0;
					strDocId = grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].FormattedValue.ToString();

					strDocDir = modCommon.DLookUp("aconfig_service_interruption_email_directory", "Application_Configuration");

					strQuery1 = $"SELECT * FROM Service_Interruption WITH (NOLOCK) WHERE (serint_id = {strDocId})";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						txtSubSIDocId.Text = Convert.ToString(rstRec1["serint_id"]);
						txtSubSISubId.Text = Convert.ToString(rstRec1["serint_sub_id"]);

						txtSubSIDocRequestedDate.Text = "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["serint_requested_date"]))
						{
							if (Information.IsDate(rstRec1["serint_requested_date"]))
							{
								txtSubSIDocRequestedDate.Text = Convert.ToDateTime(rstRec1["serint_requested_date"]).ToString("MM/dd/yyyy HH:mm:ss");
							}
						}

						txtSubSIDocInterruptDate.Text = "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["serint_interrupt_date"]))
						{
							if (Information.IsDate(rstRec1["serint_interrupt_date"]))
							{
								txtSubSIDocInterruptDate.Text = Convert.ToDateTime(rstRec1["serint_interrupt_date"]).ToString("MM/dd/yyyy");
							}
						}

						txtSubSIAutoDisableDate.Text = "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["serint_auto_disable_date"]))
						{
							if (Information.IsDate(rstRec1["serint_auto_disable_date"]))
							{
								txtSubSIAutoDisableDate.Text = Convert.ToDateTime(rstRec1["serint_auto_disable_date"]).ToString("MM/dd/yyyy");
							}
						}

						chkSubSIStopEvolution.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["serint_stop_evolution"])} ").Trim() == "Y")
						{
							chkSubSIStopEvolution.CheckState = CheckState.Checked;
						}

						chkSubSICancellation.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["serint_cancellation"])} ").Trim() == "Y")
						{
							chkSubSICancellation.CheckState = CheckState.Checked;
						}

						chkSubSIAccoutingIssues.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["serint_accounting_issues"])} ").Trim() == "Y")
						{
							chkSubSIAccoutingIssues.CheckState = CheckState.Checked;
						}

						chkSubSIChangeAutoDisable.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["serint_change_auto_disable"])} ").Trim() == "Y")
						{
							chkSubSIChangeAutoDisable.CheckState = CheckState.Checked;
						}

						txtSubSIApprovedBy.Text = ($"{Convert.ToString(rstRec1["serint_approvedby"])} ").Trim();

						strFileName = $"{strDocDir}\\{($"{Convert.ToString(rstRec1["serint_tech_id"])} ").Trim()}-{Convert.ToDateTime(rstRec1["serint_requested_date"]).ToString("yyyyMMdd-HHmmss")}.html";

						grd_SubSIDocument.CurrentColumnIndex = 11;
						grd_SubSIDocument.ColSel = 0;

						lblSubSIViewOnly.Visible = true;

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

					if (strFileName != "about:blank")
					{
						if (File.Exists(strFileName))
						{
							wbSubBrowser1[1].Navigate(new Uri(strFileName));
							cmdSubSIDocView.Tag = strFileName;
							cmdSubSIDocView.Enabled = true;
							modCommon.DelaySeconds(1);
						}
					}

					grd_SubSIDocument.Enabled = true;

				} // If grd_SubDocument.Enabled = True Then

				rstRec1 = null;
				fso = null;
			}
			catch
			{

				modAdminCommon.Report_Error("grd_SubSIDocument_Click_Error: ");
			}

		} // grd_SubSIDocument_Click_Error

		private void InstallLinkLabel_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.InstallLinkLabel, eventSender);

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strUserId = "";
			string strCompId = "";
			string strCompany = "";
			string strSubIdOld = "";
			string strLoginOld = "";
			string strSeqNbrOld = "";

			frm_Subscription_CopyMoveSavedProjects frmCopyMoveProjects = null;


			switch(Index)
			{
				case 0 :  // View ASP Logs 
					 
					frmSMSTextMsg.Visible = false; 
					InstallLinkLabel[1].Text = "View SMS Txt Msg"; 
					 
					if (InstallLinkLabel[0].Text == "View ASP Logs")
					{
						InstallLinkLabel[0].Text = "Hide ASP Logs";
						frmInstallASPLogs.Visible = true;
						frmInstallASPLogs.BringToFront();

					}
					else
					{
						InstallLinkLabel[0].Text = "View ASP Logs";
						frmInstallASPLogs.Visible = false;
						frmInstallASPLogs.BringToFront();
					} 
					 
					break;
				case 1 :  // View SMS Txt Msg 
					 
					InstallLinkLabel[1].Text = "View ASP Logs"; 
					frmInstallASPLogs.Visible = false; 
					 
					if (frmSMSTextMsg.Visible)
					{
						frmSMSTextMsg.Visible = false;
						InstallLinkLabel[1].Text = "View SMS Txt Msg";
					}
					else
					{
						frmSMSTextMsg.Visible = true;
						frmSMSTextMsg.BringToFront();
						// RTW - HOLD - 6/27/2022
						//fraLogin.Visible = False
						InstallLinkLabel[1].Text = "Hide SMS Txt Msg";
					} 
					 
					break;
				case 2 :  // Copy/Move Projects 
					 
					frmCopyMoveProjects = frm_Subscription_CopyMoveSavedProjects.CreateInstance(); 
					 
					strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper(); 
					strCompId = modSubscription.Entered_Company_ID.ToString(); 
					strCompany = ""; 
					 
					strQuery1 = "SELECT comp_name  FROM Company WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}WHERE (comp_id = {strCompId}) AND (comp_journ_id = 0) "; 
					 
					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly); 
					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{
						strCompany = ($"{Convert.ToString(rstRec1["comp_name"])} ").Trim();
					} 
					rstRec1.Close(); 
					 
					strSubIdOld = txt_sub_id.Text; 
					grd_Logins.CurrentColumnIndex = 0; 
					strLoginOld = grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString().Trim(); 
					grd_Installations.CurrentColumnIndex = 0; 
					strSeqNbrOld = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Trim(); 
					 
					frmCopyMoveProjects.SetCompId(strCompId); 
					frmCopyMoveProjects.SetCompany(strCompany); 
					frmCopyMoveProjects.SetSubId(strSubIdOld); 
					frmCopyMoveProjects.SetLogin(strLoginOld); 
					frmCopyMoveProjects.SetSeqNbr(strSeqNbrOld); 
					 
					frmCopyMoveProjects.ShowDialog(this); 
					 
					frmCopyMoveProjects = null; 
					 
					break;
			} // Select Case Index

			rstRec1 = null;

		}

		private void lbl_Service_Click(Object eventSender, EventArgs eventArgs)
		{

			string strWebSite = "";


			if (lbl_Service.Enabled)
			{
				ErrorHandlingHelper.ResumeNext(

					() => {lbl_Service.Enabled = false;}, 
					() => {Application.DoEvents();}, 

					() => {strWebSite = $"{modAdminCommon.gbl_WebSite}help/listjetnetservices.asp";}, 

					() => {modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strWebSite);}, 

					() => {lbl_Service.Enabled = true;});

			} // If lbl_Service.Enabled = True Then

		} // lbl_Service_Click

		private void grd_Installations_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int iCarrierId = 0;
			string strTemp = "";
			string strMake = "";
			string strEMail = "";
			string strContactActiveFlag = "";

			string strContactId = "";


			if (grd_Installations.Enabled)
			{

				grd_Installations.Enabled = false;
				grd_Installations.Visible = false;
				fra_Add_Installation.Enabled = true;
				fra_Add_Installation.Visible = true;
				fra_Add_Installation.BringToFront();

				if (DoesUserHaveAccess())
				{

					if ((grd_Installations.RowsCount > 1) && (grd_Installations.ColumnsCount > 2))
					{

						if (fraLogin.Visible)
						{
							cmdCancelLoginFrame_Click(cmdCancelLoginFrame, new EventArgs());
						}

						lblSubLabel[iEVOLASTAPPNAME].Text = "Last App";
						ToolTipMain.SetToolTip(lblSendTxtMsg, "");
						lblSendTextMsgOK.Enabled = false;
						lblSendTextMsgEvoMobileLink.Enabled = false;


						cmd_New_Installation.Enabled = false;


						grd_Installations.CurrentColumnIndex = 2;
						txt_Platform_OS.Text = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Trim();

						// added MSW - 5/3/22
						grd_Installations.CurrentColumnIndex = 22;
						if (grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Trim() != "0" && grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{
							lblSubDefaultAModId.Text = $"Model: {modCompany.get_make_model(Convert.ToInt32(Double.Parse(grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Trim())))}";
						}

						grd_Installations.CurrentColumnIndex = 5;

						if (grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
						{
							chkInstallationActive.CheckState = CheckState.Checked;
						}
						else
						{
							chkInstallationActive.CheckState = CheckState.Unchecked;
						}

						grd_Installations.CurrentColumnIndex = 6;
						if (grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
						{
							chkInstallationUseLocalNotes.CheckState = CheckState.Checked;
							txtInstallationPathToLocalDB.Enabled = true;
						}
						else
						{
							chkInstallationUseLocalNotes.CheckState = CheckState.Unchecked;
							txtInstallationPathToLocalDB.Enabled = false;
						}

						// 03/17/2009 - By David D. Cruger; Added
						grd_Installations.CurrentColumnIndex = 7;
						if (grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
						{
							chkInstallationDisplayNoteTag.CheckState = CheckState.Checked;
						}
						else
						{
							chkInstallationDisplayNoteTag.CheckState = CheckState.Unchecked;
						}

						grd_Installations.CurrentColumnIndex = 8;
						txtInstallationPathToLocalDB.Text = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Trim();

						// 12/03/2002 - By David D. Cruger; Added This Field
						grd_Installations.CurrentColumnIndex = 9;
						txtWebPageTimeOut.Text = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Trim();
						gstrTimeOut = txtWebPageTimeOut.Text;

						// 03/27/2003 - By David D. Cruger; Added This Field
						grd_Installations.CurrentColumnIndex = 10;
						if (grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
						{
							chkActiveXFlag.CheckState = CheckState.Checked;
						}
						else
						{
							chkActiveXFlag.CheckState = CheckState.Unchecked;
						}

						// 11/15/2004 - By David D. Cruger; Added This Field
						grd_Installations.CurrentColumnIndex = 11;
						if (grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
						{
							chkAutoCheckTS.CheckState = CheckState.Checked;
							chkTerminalService.Enabled = false;
						}
						else
						{
							chkAutoCheckTS.CheckState = CheckState.Unchecked;
							chkTerminalService.Enabled = true;
						}

						// 11/15/2004 - By David D. Cruger; Added This Field
						grd_Installations.CurrentColumnIndex = 12;
						if (grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
						{
							chkTerminalService.CheckState = CheckState.Checked;
						}
						else
						{
							chkTerminalService.CheckState = CheckState.Unchecked;
						}

						// 03/07/2005 - By David D. Cruger; Added This Field
						grd_Installations.CurrentColumnIndex = 13;
						txtReplyName.Text = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Trim();

						// added MSW - 5/13/22
						grd_Installations.CurrentColumnIndex = 4;
						lblSubLabel[69].Text = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Trim();


						// 03/07/2005 - By David D. Cruger; Added This Field
						grd_Installations.CurrentColumnIndex = 14;
						txtReplyEMail.Text = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Trim();

						// 03/07/2005 - By David D. Cruger; Added This Field
						grd_Installations.CurrentColumnIndex = 15;
						if (grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString() == "HTML")
						{
							chkDefaultHTMLEMail.CheckState = CheckState.Checked;
						}
						else
						{
							chkDefaultHTMLEMail.CheckState = CheckState.Unchecked;
						}

						// 11/26/2007 - By David D. Cruger; Added
						grd_Installations.CurrentColumnIndex = 16;
						txt_SubInsContractAmount.Text = StringsHelper.Format(grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString(), "#,##0.00");
						if (txt_SubInsContractAmount.Text == "")
						{
							txt_SubInsContractAmount.Text = "0.00";
						}

						// 06/03/2009 - By David D. Cruger; Added
						grd_Installations.CurrentColumnIndex = 17;
						txtCellNumber.Text = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Trim();

						grd_Installations.CurrentColumnIndex = 18;

						if (grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString() != "")
						{
							int tempForEndVar = cboCellCarrier.Items.Count - 1;
							for (int I = 0; I <= tempForEndVar; I++)
							{
								iCarrierId = Convert.ToInt32(Double.Parse(grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(4, grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString().Length))));
								if (cboCellCarrier.GetItemData(I) == iCarrierId)
								{
									cboCellCarrier.SelectedIndex = I;
								}
							}
						}

						// 06/03/2009 - By David D. Cruger; Added
						grd_Installations.CurrentColumnIndex = 19;
						txtTextMsgModels.Text = ($"{grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

						//----------------------------------------------------
						// Load Model ToolTipText With Make/Models Selected
						//----------------------------------------------------
						ToolTipMain.SetToolTip(txtTextMsgModels, "");
						if ((txtTextMsgModels.Text != "") && (txtTextMsgModels.Text != "ALL"))
						{

							strQuery1 = "SELECT amod_make_name, amod_model_name FROM Aircraft_Model WITH (NOLOCK) ";
							strQuery1 = $"{strQuery1}WHERE (amod_id IN ({txtTextMsgModels.Text})) ";
							strQuery1 = $"{strQuery1}AND (amod_customer_flag = 'Y') ORDER BY amod_make_name, amod_model_name ";

							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							if ((!rstRec1.BOF) && (!rstRec1.EOF))
							{

								strMake = "";
								strTemp = "";
								do 
								{ // Loop Until rstRec1.EOF=True
									if (strMake != ($"{Convert.ToString(rstRec1["amod_make_name"])} ").Trim())
									{
										strMake = ($"{Convert.ToString(rstRec1["amod_make_name"])} ").Trim();
										strTemp = $"{strTemp}{strMake} {($"{Convert.ToString(rstRec1["amod_model_name"])} ").Trim()}";
									}
									else
									{
										strTemp = $"{strTemp}{($"{Convert.ToString(rstRec1["amod_model_name"])} ").Trim()}";
									}
									rstRec1.MoveNext();
									if (!rstRec1.EOF)
									{
										strTemp = $"{strTemp}, ";
									}

								}
								while(!rstRec1.EOF);

								ToolTipMain.SetToolTip(txtTextMsgModels, strTemp);

							} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

							rstRec1.Close();

						} // If (txtTextMsgModels.Text <> "") And (txtTextMsgModels.Text <> "ALL") Then

						// 02/10/2010 - By David D. Cruger; Added
						grd_Installations.CurrentColumnIndex = 20;
						txtSMSTextActiveFlag.Text = ($"{grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();
						strSMSTextActiveFlag = txtSMSTextActiveFlag.Text; // Save Original Value

						// 11/13/2009 - By David D. Cruger; Added
						grd_Installations.CurrentColumnIndex = 21;
						txtMobileActiveDate.Text = ($"{grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

						// 02/16/2010 - By David D. Cruger; Added
						grd_Installations.CurrentColumnIndex = 22;
						txtSubDefaultAModId.Text = ($"{grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

						// 02/19/2010 - By David D. Cruger; Added
						grd_Installations.CurrentColumnIndex = 23;
						if (($"{grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()} ").Trim() == "Yes")
						{
							chkInstallEvoMobile.CheckState = CheckState.Checked;
							//InstallLinkLabel(0).Enabled = True
						}
						else
						{
							chkInstallEvoMobile.CheckState = CheckState.Unchecked;
						}

						// 03/08/2011 - By David D. Cruger; Added
						InstallLinkLabel[1].Text = "View SMS Txt Msg";
						frmSMSTextMsg.Visible = false;
						grd_Installations.CurrentColumnIndex = 24;
						txtSMSEvents.Text = ($"{grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

						// 07/11/2011 - By David D. Cruger; Added
						grd_Installations.CurrentColumnIndex = 25; // Contact Id
						strContactId = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();

						strContactActiveFlag = modCommon.DLookUp("contact_active_flag", "Contact", $"(contact_id = {strContactId}) AND (contact_journ_id = 0)");

						if (strContactActiveFlag == "Y" || strContactActiveFlag == "")
						{
							Fill_Subscription_Install_Contact_Combo_Box(modSubscription.Entered_Company_ID, true);
						}
						else
						{
							Fill_Subscription_Install_Contact_Combo_Box(modSubscription.Entered_Company_ID, false);
						}

						cmbSubInsContact.Text = "";
						cmbSubInsContact.SelectedIndex = -1;

						// See If Contact Id Is In List Box
						if (cmbSubInsContact.Items.Count > 0)
						{
							int tempForEndVar2 = cmbSubInsContact.Items.Count - 1;
							for (int iCnt1 = 0; iCnt1 <= tempForEndVar2; iCnt1++)
							{
								if (strContactId.Trim() != "")
								{ // added MSW - to make sure it doesnt error out
									if (cmbSubInsContact.GetItemData(iCnt1) == StringsHelper.ToDoubleSafe(strContactId))
									{
										grd_Installations.CurrentColumnIndex = 26; // Contact Name
										cmbSubInsContact.SelectedIndex = iCnt1;
										//cmbSubInsContact.Text = grd_Installations.Text
									}
								}
							}
						}

						txt_Platform_Name.Text = cmbSubInsContact.Text; // added MSW - 5/5/22

						// 11/06/2012 - By David D. Cruger
						grd_Installations.CurrentColumnIndex = 30; // Background Image Id
						cmbSubInsBGImageId.Text = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();

						// 11/08/2012 - By David D. Cruger
						grd_Installations.CurrentColumnIndex = 31; // Nbr of Records Per Page
						txtSubInsNbrRecPerPage.Text = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();

						// 07/12/2013 - By David D. Cruger; Added
						grd_Installations.CurrentColumnIndex = 32;
						if (($"{grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()} ").Trim() == "Yes")
						{
							chkInstallAdministrator.CheckState = CheckState.Checked;
							lblSubInsContact.ForeColor = Color.Red; // Red
							ToolTipMain.SetToolTip(lblSubInsContact, "SubId Administrator");
						}
						else
						{
							chkInstallAdministrator.CheckState = CheckState.Unchecked;
							lblSubInsContact.ForeColor = SystemColors.ControlText; // Black
							ToolTipMain.SetToolTip(lblSubInsContact, "");
						}

						// 08/22/2014 - By David D. Cruger; Added
						grd_Installations.CurrentColumnIndex = 33;
						if (($"{grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()} ").Trim() == "Yes")
						{
							chkInstallationChatFlag.CheckState = CheckState.Checked;
						}
						else
						{
							chkInstallationChatFlag.CheckState = CheckState.Unchecked;
						}

						// 09/22/2015 - By David D. Cruger; Added
						grd_Installations.CurrentColumnIndex = 34;
						int tempForEndVar3 = cboSubBType.Items.Count - 1;
						for (int iCnt1 = 0; iCnt1 <= tempForEndVar3; iCnt1++)
						{
							if (($"{cboSubBType.GetListItem(iCnt1).Substring(0, Math.Min(2, cboSubBType.GetListItem(iCnt1).Length))} ").Trim() == grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString())
							{
								cboSubBType.SelectedIndex = iCnt1;
							}
						}

						// 08/14/2017 - By David D. Cruger
						grd_Installations.CurrentColumnIndex = 35; // Default Analysis Months
						txtSubInsDefaultAnalysisMths.Text = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();

						// 03/23/2012 - By David D. Cruger
						// Display Install EMail Address in Frame Caption

						if (strContactId != "" && strContactId != "0")
						{
							strEMail = modCommon.DLookUp("contact_email_address", "Contact WITH (NOLOCK) ", $"(contact_id = {strContactId}) AND (contact_journ_id = 0) ");
							if (strEMail != "")
							{
								fra_Add_Installation.Text = $"Installation ({strEMail})";
							}
							else
							{
								fra_Add_Installation.Text = "Installation";
							}
						}

						Mode = "Install Update";

						// 03/12/2003 - By David D. Cruger
						// Save This Value for Later use.  To determine if the active status has changed
						iInstallationActive = chkInstallationActive.CheckState;

						if (txtCellNumber.Text != "" && chkLoginFlag[(int) modSubscription.iCHKLOGINTEXTMSG].CheckState == CheckState.Checked && cmbFrequency.Text == "Live")
						{
							lblSendTextMsgOK.Enabled = true;
							if (txtSMSTextActiveFlag.Text == "Yes")
							{
								lblSendTextMsgEvoMobileLink.Enabled = true;
							}
						}
						else
						{
							ToolTipMain.SetToolTip(lblSendTxtMsg, "Cell Nbr Blank or Login Allow Text Msg Not Checked Or Frequency Not Live");
						}

					}
					else
					{
						// If grd_Installations.MouseRow > 0 Then


						switch(grd_Installations.MouseCol)
						{
							case 0 : 
								InstallationsOrderBy = " ORDER BY subins_seq_no"; 
								 
								break;
							case 1 : 
								InstallationsOrderBy = " ORDER BY subins_platform_name"; 
								 
								break;
							case 2 : 
								InstallationsOrderBy = " ORDER BY subins_platform_os"; 
								 
								break;
							case 3 : 
								InstallationsOrderBy = " ORDER BY subins_install_date"; 
								 
								break;
							case 4 : 
								InstallationsOrderBy = " ORDER BY subins_access_date"; 
								 
								break;
							case 5 : 
								InstallationsOrderBy = " ORDER BY subins_active_flag"; 
								 
								break;
						} // Select Case grd_Installations.MouseCol

						Fill_grd_Installations(Convert.ToString(grd_Installations.Tag));

						//   End If ' If grd_Installations.MouseRow > 0 Then

					} // If (grd_Installations.Rows > 1) And (grd_Installations.Cols > 2) Then

				} // End If ' If DoesUserHaveAccess = True Then

			} // If grd_Installations.Enabled = True Then

			rstRec1 = null;

		} // grd_Installations_DblClick

		private void grd_Logins_Click(Object eventSender, EventArgs eventArgs)
		{


			string strUserId = "";

			if (grd_Logins.Enabled)
			{

				grd_Logins.Enabled = false;

				//--------------------------
				// Turn On Frames And Grids

				frm_Sub_Command.Visible = true;
				frm_Sub_Command.Enabled = true;

				cmdNewLogin.Enabled = true;
				cmd_DeleteLogin.Enabled = true;
				cmdEMailSubNotice.Enabled = true;
				lblSubAddInstall.Enabled = true;
				lblSubAddInstall.Visible = true;
				cmd_New_Installation.Enabled = true;

				fra_Add_Installation.Visible = false;
				fra_Add_Installation.Enabled = false;
				grd_Installations.Visible = true;
				grd_Installations.Enabled = true;
				fra_Add_Installation.BringToFront();

				// show flags - auto clicked
				lblLoginShowFlags_Click(lblLoginShowFlags, new EventArgs());


				if (grd_Logins.CurrentRowIndex > 0 || !FormLoaded)
				{

					if (fra_Add_Installation.Visible)
					{
						cmd_InstallCancel_Click(cmd_InstallCancel, new EventArgs());
					}

					Load_Login_Dialog_With_Grid_Data();

					Fill_grd_Installations(grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString());

					Fill_Contact_Info_Panel(grd_Logins.get_RowData(grd_Logins.CurrentRowIndex));

					Get_User_Authentication_Info(grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString(), modSubscription.gbl_SubID);
					frm_authentication.Visible = true;

					grd_Installations.Enabled = true;
					grd_Installations.Visible = true;
					fra_Add_Installation.Enabled = true;
					fra_Add_Installation.Visible = true;

					grd_Installations_DoubleClick(grd_Installations, new EventArgs());
					grd_Installations.Enabled = true;
					grd_Installations.Visible = true;

					grd_Logins.ColSel = grd_Logins.ColumnsCount - 1;

					strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();
					cmd_DeleteLogin.Enabled = true;

					Mode = "LoginUpdate";
					cmdIdentifyContact.Enabled = true;
					cmdClearContact.Enabled = true;


				}

				grd_Logins.Enabled = true;

			} // If grd_Logins.Enabled = True Then

		} // grd_Logins

		private void Load_Login_Dialog_With_Grid_Data()
		{

			try
			{

				RememberLoginPosition = grd_Logins.CurrentRowIndex;

				grd_Logins.CurrentColumnIndex = 0;
				txtLoginName.Text = grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString().Trim();
				tmpLoginName = txtLoginName.Text.Trim();

				grd_Logins.CurrentColumnIndex = 1;
				txt_sub_password.Text = grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString();
				txt_sub_password.Tag = txt_sub_password.Text; // added MSW - 9/28/21

				// added MSW - un-enable the password to be changed
				turn_on_off_items_frontegg();


				grd_Logins.CurrentColumnIndex = 2;
				if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINACTIVE].CheckState = CheckState.Checked;
				}
				else
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINACTIVE].CheckState = CheckState.Unchecked;
				}

				grd_Logins.CurrentColumnIndex = 3;
				if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState = CheckState.Checked;
					cmdResetDemoLogin.Visible = true;
				}
				else
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState = CheckState.Unchecked;
					cmdResetDemoLogin.Visible = false;
				}

				chkLoginFlag[(int) modSubscription.iCHKLOGINEXPORT].CheckState = CheckState.Checked;

				grd_Logins.CurrentColumnIndex = 5;
				if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINLOCALNOTES].CheckState = CheckState.Checked;
				}
				else
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINLOCALNOTES].CheckState = CheckState.Unchecked;
				}

				grd_Logins.CurrentColumnIndex = 6;
				if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINPROJECTS].CheckState = CheckState.Checked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].Enabled = true;
				}
				else
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINPROJECTS].CheckState = CheckState.Unchecked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].CheckState = CheckState.Unchecked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].Enabled = false;
				}

				grd_Logins.CurrentColumnIndex = 7;
				if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINEMAILREQUEST].CheckState = CheckState.Checked;
				}
				else
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINEMAILREQUEST].CheckState = CheckState.Unchecked;
				}

				grd_Logins.CurrentColumnIndex = 8;
				if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].CheckState = CheckState.Checked;
				}
				else
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].CheckState = CheckState.Unchecked;
				}

				// 11/26/2007 - By David D. Cruger - Added
				grd_Logins.CurrentColumnIndex = 9;
				txt_SubLoginNbrOfInstalls.Text = StringsHelper.Format(grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString(), "#");
				if (txt_SubLoginNbrOfInstalls.Text == "")
				{
					txt_SubLoginNbrOfInstalls.Text = "0";
				}

				// 11/26/2007 - By David D. Cruger - Added
				grd_Logins.CurrentColumnIndex = 10;
				txt_SubLoginContractAmount.Text = StringsHelper.Format(grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString(), "#,##0.00");
				if (txt_SubLoginContractAmount.Text == "")
				{
					txt_SubLoginContractAmount.Text = "0.00";
				}

				// 06/03/2009 - By David D. Cruger - Added
				grd_Logins.CurrentColumnIndex = 11;
				if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINTEXTMSG].CheckState = CheckState.Checked;
				}
				else
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINTEXTMSG].CheckState = CheckState.Unchecked;
				}

				// 01/18/2010 - By David D. Cruger - Added
				grd_Logins.CurrentColumnIndex = 12;
				if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINBYPASSACTIVEX].CheckState = CheckState.Checked;
				}
				else
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINBYPASSACTIVEX].CheckState = CheckState.Unchecked;
				}

				// 09/20/2019 - By David D. Cruger - Added
				grd_Logins.CurrentColumnIndex = 13;
				if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINVALUES].CheckState = CheckState.Checked;
				}
				else
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINVALUES].CheckState = CheckState.Unchecked;
				}

				// 09/20/2019 - By David D. Cruger - Added
				grd_Logins.CurrentColumnIndex = 14;
				if (grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString() == "Yes")
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINMPM].CheckState = CheckState.Checked;
				}
				else
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINMPM].CheckState = CheckState.Unchecked;
				}

				//added MSW - 9/14/21
				grd_Logins.CurrentColumnIndex = 15;
				txt_sublogin_billed_amount.Text = StringsHelper.Format(grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString(), "#,##0.00");
				if (txt_sublogin_billed_amount.Text == "")
				{
					txt_sublogin_billed_amount.Text = "0.00";
				}

				//added MSW - 12/4/23
				grd_Logins.CurrentColumnIndex = 16;
				cbo_build.Text = grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString();
				if (cbo_build.Text == "")
				{
					cbo_build.Text = "B"; // changed to B - MSW - 1/26/24
				}


				grd_Logins.CurrentColumnIndex = 0;
				grd_Logins.ColSel = grd_Logins.ColumnsCount - 1;


				iLOGINACTIVE = chkLoginFlag[(int) modSubscription.iCHKLOGINACTIVE].CheckState;
				iLOGINDEMO = chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState;

				// 05/02/2008 - By David D. Cruger
				// Added; Save these values
				iLOGINEXPORT = chkLoginFlag[(int) modSubscription.iCHKLOGINEXPORT].CheckState;
				iLOGINLOCALNOTES = chkLoginFlag[(int) modSubscription.iCHKLOGINLOCALNOTES].CheckState;
				iLOGINPROJECTS = chkLoginFlag[(int) modSubscription.iCHKLOGINPROJECTS].CheckState;
				iLOGINEMAILREQUEST = chkLoginFlag[(int) modSubscription.iCHKLOGINEMAILREQUEST].CheckState;
				iLOGINEVENTREQUEST = chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].CheckState;
				iLOGINTEXTMSG = chkLoginFlag[(int) modSubscription.iCHKLOGINTEXTMSG].CheckState;
				iLOGINVALUES = chkLoginFlag[(int) modSubscription.iCHKLOGINVALUES].CheckState;
				iLOGINMPM = chkLoginFlag[(int) modSubscription.iCHKLOGINMPM].CheckState;

				// 01/18/2010 - By David D. Cruger
				iByPassActiveXReg = chkLoginFlag[(int) modSubscription.iCHKLOGINBYPASSACTIVEX].CheckState;

				// 03/23/2009 - By David D. Cruger
				// If Demo is checked uncheck all other flags
				if (chkLoginFlag[(int) modSubscription.iCHKLOGINDEMO].CheckState == CheckState.Checked)
				{
					chkLoginFlag[(int) modSubscription.iCHKLOGINEXPORT].CheckState = CheckState.Unchecked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINLOCALNOTES].CheckState = CheckState.Unchecked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINPROJECTS].CheckState = CheckState.Unchecked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINEMAILREQUEST].CheckState = CheckState.Unchecked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].CheckState = CheckState.Unchecked;
					chkLoginFlag[(int) modSubscription.iCHKLOGINEVENTREQUEST].Enabled = false;
					chkLoginFlag[(int) modSubscription.iCHKLOGINTEXTMSG].CheckState = CheckState.Unchecked;
					cmdResetDemoLogin.Visible = true;
				}
				else
				{
					cmdResetDemoLogin.Visible = false;
				}
			}
			catch
			{

				modAdminCommon.Report_Error("Load_Login_Dialog_With_Grid_Data_Error: ");
			}

		}

		private void grd_Logins_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			if (grd_Logins.Enabled)
			{

				if (DoesUserHaveAccess())
				{

					grd_Logins.Visible = false;
					grd_Logins.Enabled = false;
					frmLoginFlags.Visible = false;
					frmLoginFlags.Enabled = false;
					fraLogin.Visible = true;
					fraLogin.Enabled = true;

					// show flags - auto clicked
					lblLoginShowFlags_Click(lblLoginShowFlags, new EventArgs());

					if (grd_Logins.MouseRow > 0)
					{

						Load_Login_Dialog_With_Grid_Data();


						cmdNewLogin.Enabled = false;

					}
					else
					{
						// If grd_Logins.MouseRow > 0 Then


						switch(grd_Logins.MouseCol)
						{
							case 0 : 
								LoginsOrderBy = " ORDER BY sublogin_login"; 
								 
								break;
							case 1 : 
								LoginsOrderBy = " ORDER BY sublogin_password"; 
								 
								break;
							case 2 : 
								LoginsOrderBy = " ORDER BY sublogin_active_flag"; 
								 
								break;
						} // Select Case grd_Logins.MouseCol

					} // If grd_Logins.MouseRow > 0 Then

				} // End If ' If DoesUserHaveAccess = True Then

				grd_Logins.Enabled = true;

			} // If grd_Logins.Enabled = True Then

		} // grd_Logins_DblClick

		private void grd_SubDocument_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strDocId = "";
			string strDocDir = "";

			try
			{

				if (grd_SubDocument.Enabled)
				{

					grd_SubDocument.Enabled = false;

					cmdSubDocumentNew_Click(cmdSubDocumentNew, new EventArgs());

					grd_SubDocument.CurrentColumnIndex = 0;
					strDocId = grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].FormattedValue.ToString();

					strQuery1 = "SELECT * FROM Company_Documents WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Document_Type ON compdoc_doc_type_code = doctype_code ";
					strQuery1 = $"{strQuery1}WHERE (compdoc_id = {strDocId}) AND (doctype_contract_doc_view = 'Y') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						txtSubDocumentId.Text = strDocId;
						cmbSubDocumentType.Text = $"{($"{Convert.ToString(rstRec1["compdoc_doc_type_code"])} ").Trim()} - {($"{Convert.ToString(rstRec1["doctype_description"])} ").Trim()}";
						cmbSubDocumentType.Tag = ($"{Convert.ToString(rstRec1["compdoc_doc_type_code"])} ").Trim();
						txtSubDocumentSubject.Text = ($"{Convert.ToString(rstRec1["compdoc_subject"])} ").Trim();
						txtSubDocumentDescription.Text = ($"{Convert.ToString(rstRec1["compdoc_description"])} ").Trim();

						calSubDocumentDate.SetDate(DateTime.Now);
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["compdoc_doc_date"]))
						{
							if (Information.IsDate(rstRec1["compdoc_doc_date"]))
							{
								if (Convert.ToDouble(rstRec1["compdoc_doc_date"]) > 0)
								{
									calSubDocumentDate.SetDate(Convert.ToDateTime(rstRec1["compdoc_doc_date"]));
									txtSubDocumentDate.Text = Convert.ToDateTime(rstRec1["compdoc_doc_date"]).ToString("MM/dd/yyyy");
								}
							}
						}

						calSubExpirationDate.SetDate(DateTime.Now);
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["compdoc_expiration_date"]))
						{
							if (Information.IsDate(rstRec1["compdoc_expiration_date"]))
							{
								if (Convert.ToDouble(rstRec1["compdoc_expiration_date"]) > 0)
								{
									calSubExpirationDate.SetDate(Convert.ToDateTime(rstRec1["compdoc_expiration_date"]));
									txtSubExpirationDate.Text = Convert.ToDateTime(rstRec1["compdoc_expiration_date"]).ToString("MM/dd/yyyy");
								}
							}
						}

						Set_Expiration_Date_Color();

						txtSubDragDocument.Text = $"Drag Document Here{Environment.NewLine}{($"{Convert.ToString(rstRec1["compdoc_filename"])} ").Trim()}";
						strDocDir = modCommon.DLookUp("aconfig_customer_contract_dir", "Application_Configuration");
						txtSubDragDocument.Tag = $"{strDocDir}\\{($"{Convert.ToString(rstRec1["compdoc_filename"])} ").Trim()}"; // This Holds The Path To The File To Add Or On File

						wbSubBrowser1[0].Navigate(new Uri($"http:{StringsHelper.Replace(Convert.ToString(txtSubDragDocument.Tag), "\\", "/", 1, -1, CompareMethod.Binary)}"));
						cmdSubDocumentView.Enabled = true;
						cmdSubDocumentNew.Enabled = true;
						cmdSubDocumentDelete.Enabled = true;
						cmdSubDocumentMove.Enabled = true;

						grd_SubDocument.CurrentColumnIndex = 6;
						grd_SubDocument.ColSel = 0;

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

					grd_SubDocument.Enabled = true;

				} // If grd_SubDocument.Enabled = True Then

				rstRec1 = null;
			}
			catch
			{

				modAdminCommon.Report_Error("grd_SubDocument_Click_Error: ");
			}

		} // grd_SubDocument_Click

		private void grd_SubExecutionForms_Click(Object eventSender, EventArgs eventArgs)
		{
			StreamWriter tsFileWriter = null;

			FileStream tsFile = null;
			string strPath = "";
			string strFileName = "";
			string strURL = "";
			string strData = "";
			string[] aData = null;

			try
			{

				grd_SubExecutionForms.CurrentColumnIndex = 1; // SubId
				txtSubExc_SubId.Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 3; // Execution Date
				txtSubExc_ExcDate.Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 5; // Status
				txtSubExc_Status.Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 6; // Contract Nbr
				txtSubExc_ContractNbr.Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 7; // Contract Date
				txtSubExc_ContractDate.Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 8; // Service
				txtSubExc_Service.Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 9; // Monthly List Fee
				txtSubExc_MonthlyAmt[1].Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 10; // Monthly Billed Fee
				txtSubExc_MonthlyAmt[0].Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 11; // Monthly Net Changed Fee
				txtSubExc_MonthlyAmt[2].Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 12; // CLetter Date
				txtSubExc_CLetterDate.Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 14; // Service Change Date
				txtSubExc_SrvChgDate.Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 15; // Auto Disable
				txtSubExc_ADisableDate.Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 16; // Execution Type
				txtSubExc_Type[0].Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 17; // Action Name
				txtSubExc_Type[1].Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 18; // Notes
				txtSubExc_Notes.Text = ($"{grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				grd_SubExecutionForms.CurrentColumnIndex = 13; // Data
				lstb_SubExecutionFormsDisplay.Items.Clear();

				wbSubBrowser1[3].Visible = false;
				wbSubBrowser1[3].Navigate(new Uri("about:blank")); // Make Sure It's Not Open
				lstb_SubExecutionFormsDisplay.Visible = false;
				lstb_SubExecutionFormsDisplay.Items.Clear();

				strData = grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].FormattedValue.ToString();
				if ((strData.IndexOf("<html>") + 1) == 0)
				{

					aData = strData.Split(Environment.NewLine[0]);

					if (aData.GetUpperBound(0) > 0)
					{

						int tempForEndVar = aData.GetUpperBound(0) - 1;
						for (int iCnt1 = 0; iCnt1 <= tempForEndVar; iCnt1++)
						{
							lstb_SubExecutionFormsDisplay.AddItem(($"{aData[iCnt1]} ").Trim());
						}

					} // If UBound(aData) > 0 Then

					lstb_SubExecutionFormsDisplay.Visible = true;

				}
				else
				{
					// Create HTML File And Save

					strPath = "C:\\TEMP\\";
					if (!Directory.Exists(strPath))
					{
						Directory.CreateDirectory(strPath);
					}

					strPath = $"{strPath}Working\\";

					if (!Directory.Exists(strPath))
					{
						Directory.CreateDirectory(strPath);
					}

					strFileName = $"{strPath}{($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper()}_{StringsHelper.Format(DateTime.Now, "yyyymmdd_HHMMss")}.html";
					if (File.Exists(strFileName))
					{
						//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						File.Delete(strFileName);
					}

					strURL = strFileName;

					//---------------------------------------------
					// Save File To \Working\ Directory

					tsFile = new FileStream(strFileName, FileMode.Create);
					tsFileWriter = new StreamWriter(tsFile);
					tsFileWriter.Write(strData.ToCharArray());
					tsFileWriter.Close();
					tsFile = null;

					if (File.Exists(strFileName))
					{
						wbSubBrowser1[3].Navigate(new Uri(strURL));
						modCommon.DelaySeconds(1);
						wbSubBrowser1[3].Visible = true;
					}
					else
					{
						MessageBox.Show($"Unable To Find Report HTML File{Environment.NewLine}{Environment.NewLine}{strFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

				} // If InStr(1, strData, "<html>") = 0 Then

				grd_SubExecutionForms.CurrentColumnIndex = 16;
				grd_SubExecutionForms.ColSel = 0;
			}
			catch
			{

				modAdminCommon.Report_Error("grd_SubExecutionForms_Click_Error: ");
			}

		} // grd_SubExecutionForms_Click

		private void grd_SubJournalNotes_Click(Object eventSender, EventArgs eventArgs)
		{

			if (grd_SubJournalNotes.Enabled)
			{

				grd_SubJournalNotes.Enabled = false;

				grd_SubJournalNotes.CurrentColumnIndex = 0;
				txt_SubJournalId.Text = grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].FormattedValue.ToString();

				grd_SubJournalNotes.CurrentColumnIndex = 4;
				txt_SubJournalSubject.Text = grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].FormattedValue.ToString();

				grd_SubJournalNotes.CurrentColumnIndex = 5;
				txt_SubJournalDescription.Text = grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].FormattedValue.ToString();

				grd_SubJournalNotes.CurrentColumnIndex = 6;
				grd_SubJournalNotes.ColSel = 0;

				cmdSubNoteNew.Enabled = true;
				grd_SubJournalNotes.Enabled = true;

			} // If grd_SubJournalNotes.Enabled = True Then

		} // grd_SubJournalNotes_Click

		private void grd_Subscriptions_Click(Object eventSender, EventArgs eventArgs)
		{

			int lRow1 = 0;
			int lCol1 = 0;
			string temp_update_string = "";

			if (grd_Subscriptions.Enabled)
			{

				grd_Subscriptions.Enabled = false;

				if ((grd_Subscriptions.RowsCount > 1) && (grd_Subscriptions.ColumnsCount > 2))
				{

					lRow1 = grd_Subscriptions.CurrentRowIndex;
					lCol1 = grd_Subscriptions.CurrentColumnIndex;

					if (Convert.ToString(grd_Subscriptions[1, 1].Value) != "")
					{

						EnableAllButtons();

						cbo_Service.Enabled = true;
						cmbTierLevel.Enabled = true;

						modSubscription.gbl_SubID = Convert.ToInt32(Double.Parse(Convert.ToString(grd_Subscriptions[lRow1, 0].Value)));

						// added MSW - for new subscription created method.7/1/24
						cmdSubscription[2].Enabled = modAdminCommon.gbl_User_Create_Sub == "Y";


						// Turn On Frames And Grids
						frm_Sub_Command.Visible = true;
						frm_Sub_Command.Enabled = true;

						fraLogin.Visible = false;
						fraLogin.Enabled = false;
						grd_Logins.Visible = true;
						grd_Logins.Enabled = true;
						grd_Logins.BringToFront();

						fra_Add_Installation.Visible = false;
						fra_Add_Installation.Enabled = false;
						grd_Installations.Visible = true;
						grd_Installations.Enabled = true;
						fra_Add_Installation.BringToFront();

						Fill_Logins_Grid();
						Fill_Subscription_Panel(modSubscription.gbl_SubID);

						cmdNewLogin.Enabled = true;

						grd_Subscriptions.ColSel = grd_Subscriptions.ColumnsCount - 1;
						//fra_Add_Installation.Visible = False  ' commented out MSW to make it show up

						lblServerSideNotes.Text = "View Server Notes";
						frmStartEndDate.Visible = false;
						lblCalendars.Text = "<< View Calendars >>";

						cmdUpdateCRMSite.Enabled = cbo_Service.Text.Substring(0, Math.Min(3, cbo_Service.Text.Length)).ToUpper() == "CRM" && txtCRMRegId.Text != "" && txtCRMRegId.Text != "0";


						cmdNewLogin.Visible = chkProductType[13].CheckState != CheckState.Checked;

					}
					else
					{
						New_Subscription();
						Load_Login_Grid_Headers();
						Load_Installation_Grid_Headers();
					} // If grd_Subscriptions.TextMatrix(1, 1) <> "" Then

				} // If (grd_Subscriptions.Rows > 1) And (grd_Subscriptions.Cols > 2) Then


				// i load them all , and then i remember the row of the CRM record, if there is one
				// check this row and column - 4/18/22
				lblSubUpdateNbrInstalls.Visible = true;
				if (Convert.ToString(grd_Subscriptions[lRow1, 1].Value) != "")
				{
					grd_Subscriptions.CurrentColumnIndex = 1;

					if (has_mpm_db_name.Trim() != "" && has_mpm > 0)
					{ // do this for the mpm, get all of the other crm possible subs
						Check_For_Active_MPM_View(0, 0, has_mpm_db_name.Trim());

						if (lRow1 == has_mpm)
						{
							lblSubUpdateNbrInstalls.Visible = false;
						}

						// make sure we update the mpm_flag
						if (grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].FormattedValue.ToString().Trim() == "CRM")
						{
							temp_update_string = $"Update Subscription set sub_mpm_flag = 'Y', sub_action_date = '1/1/1900' where sub_id = {modSubscription.gbl_SubID.ToString()} ";
							run_subscription_updater(temp_update_string, -5, modSubscription.gbl_SubID);
						}


					}
					else if (grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].FormattedValue.ToString().Trim() == "CRM")
					{  // current un used i believe
						Check_For_Active_MPM_View(modSubscription.Entered_Company_ID, 0, "");

						if (lRow1 == has_mpm)
						{
							lblSubUpdateNbrInstalls.Visible = false;
						}
					}
					else
					{
						Check_For_Active_MPM_View(modSubscription.Entered_Company_ID, modSubscription.gbl_SubID, "");
					}
					grd_Subscriptions.CurrentColumnIndex = 2; //reset it so this row is selected
				}
				else
				{
					Check_For_Active_MPM_View(modSubscription.Entered_Company_ID, modSubscription.gbl_SubID, "");
				}


				grd_Subscriptions.Enabled = true;

			} // If grd_Subscriptions.Enabled= True Then

		}

		private void Fill_Contact_Info_Panel(int contact_id)
		{

			try
			{

				if (contact_id > 0)
				{
					modCommon.Build_Contact_Info(lst_Contact, contact_id, 0, false);
				}
				else
				{
					lst_Contact.Items.Clear();
					lst_Contact.BackColor = Color.FromArgb(224, 224, 224);
				}
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Fill_Contact_Info_Panel_Error: ");
			}

		}

		public void Get_User_Authentication_Info(string login, int sub_id)
		{


			try
			{
				string Query = "";
				ADORecordSetHelper snp_auth = new ADORecordSetHelper(); //8/11/05 aey dao.Recordset


				Query = " select status,cycle, channel, lastattempt, lastresult, emailaddress, phone, subid, login, contactid, * ";
				Query = $"{Query} From [EVO_LIVE].jetnet_ra.dbo.View_Customer_Authentication where source <> '' ";

				if (login.Trim() != "")
				{
					Query = $"{Query} and login = '{login}' ";
				}

				if (sub_id > 0)
				{
					Query = $"{Query} and subid = {sub_id.ToString()} ";
				}


				Query = $"{Query} order by AUTHENTICATIONS DESC, IPS DESC, LOCATIONS DESC ";



				chk_auth_status.Tag = "0";
				chk_auth_status.CheckState = CheckState.Unchecked;
				cbo_auth_cycle.Text = "30";
				cbo_auth_type.Text = "SMS";
				lblSubLabel[9].Text = "";
				lblSubLabel[65].Text = "";
				txt_auth_phone.Text = "";
				lblSubLabel[68].Text = "";
				cmd_auth_btn[1].Visible = true;
				txt_auth_last_action.Text = "";
				txt_auth_last_action.Text = "";

				//added in MSW - 1/25/23
				frm_authentication.Visible = false;

				snp_auth = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_auth.Fields) && !(snp_auth.BOF && snp_auth.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_auth.Fields))
					{

						frm_authentication.Visible = true;

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_auth["status"]))
						{
							if (Convert.ToString(snp_auth["status"]).Trim() == "ON")
							{
								chk_auth_status.CheckState = CheckState.Checked;
							}
							else if (Convert.ToString(snp_auth["status"]).Trim() == "OFF")
							{ 
								chk_auth_status.CheckState = CheckState.Unchecked;
							}
							else if (Convert.ToString(snp_auth["status"]) == "Y")
							{ 
								chk_auth_status.CheckState = CheckState.Checked;
							}
							else
							{
								chk_auth_status.CheckState = CheckState.Unchecked;
							}
						}
						chk_auth_status.Tag = "1";

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_auth["cycle"]))
						{
							cbo_auth_cycle.Text = Convert.ToString(snp_auth["cycle"]).Trim();
						}
						else
						{

						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_auth["channel"]))
						{
							cbo_auth_type.Text = Convert.ToString(snp_auth["channel"]).Trim();
						}
						else
						{
							cbo_auth_type.Text = "";
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_auth["lastattempt"]))
						{
							lblSubLabel[65].Text = Convert.ToString(snp_auth["lastattempt"]).Trim();

							lblSubLabel[65].Text = StringsHelper.Replace(lblSubLabel[65].Text, "2021", "21", 1, -1, CompareMethod.Binary);
							lblSubLabel[65].Text = StringsHelper.Replace(lblSubLabel[65].Text, "2022", "22", 1, -1, CompareMethod.Binary);
							lblSubLabel[65].Text = StringsHelper.Replace(lblSubLabel[65].Text, "2023", "23", 1, -1, CompareMethod.Binary);
							lblSubLabel[65].Text = StringsHelper.Replace(lblSubLabel[65].Text, "2024", "24", 1, -1, CompareMethod.Binary);
							lblSubLabel[65].Text = StringsHelper.Replace(lblSubLabel[65].Text, "2025", "25", 1, -1, CompareMethod.Binary);
							lblSubLabel[65].Text = StringsHelper.Replace(lblSubLabel[65].Text, "2026", "26", 1, -1, CompareMethod.Binary);
							lblSubLabel[65].Text = StringsHelper.Replace(lblSubLabel[65].Text, "2027", "27", 1, -1, CompareMethod.Binary);
							lblSubLabel[65].Text = StringsHelper.Replace(lblSubLabel[65].Text, "2028", "28", 1, -1, CompareMethod.Binary);
							lblSubLabel[65].Text = StringsHelper.Replace(lblSubLabel[65].Text, "2029", "29", 1, -1, CompareMethod.Binary);
							lblSubLabel[65].Text = StringsHelper.Replace(lblSubLabel[65].Text, "2030", "30", 1, -1, CompareMethod.Binary);
							lblSubLabel[65].Text = StringsHelper.Replace(lblSubLabel[65].Text, "2031", "31", 1, -1, CompareMethod.Binary);
						}
						else
						{
							lblSubLabel[65].Text = "";
							// cmd_auth_btn(1).Visible = False
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_auth["lastresult"]))
						{
							txt_auth_last_action.Text = Convert.ToString(snp_auth["lastresult"]).Trim();
						}
						else
						{
							txt_auth_last_action.Text = "";
						}

						txt_auth_phone.Text = "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_auth["phone"]))
						{
							txt_auth_phone.Text = Convert.ToString(snp_auth["phone"]).Trim();
							//lblSubLabel(67).Caption = Trim(snp_auth("phone"))   ' used to be a label - now editable
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_auth["emailaddress"]))
						{
							lblSubLabel[68].Text = Convert.ToString(snp_auth["emailaddress"]).Trim();
						}
						else
						{
							lblSubLabel[68].Text = "";
						}


					}
				}

				snp_auth = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Get_User_Authentication_Info_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon(FRACTOWN)");
				return;
			}

		}


		private void New_Subscription()
		{

			try
			{

				int NEW_SUB_ID = 0;
				string strUserId = "";
				string strSubId = "";

				this.Cursor = Cursors.WaitCursor;

				strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();
				strSubId = ($"{txt_sub_id.Text} ").Trim();

				// 03/16/2004 - By David D. Cruger; User the Marketing Flag for this
				if (chkProductType[modSubscription.ProductMarketing].CheckState == CheckState.Checked)
				{
					txt_sub_end_date.Text = DateTime.Parse(DateTime.Today.ToString("MM-dd-yyyy")).AddDays(12).ToString("MM/dd/yyyy");
					//UPGRADE_ISSUE: (2064) MSComCtl2.MonthView property cal_sub_end_date._Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					cal_sub_end_date.set_Value(DateTime.Parse(DateTime.Today.ToString("MM-dd-yyyy")).AddDays(12));
				}
				else
				{
					txt_sub_end_date.Text = "";
					//UPGRADE_ISSUE: (2064) MSComCtl2.MonthView property cal_sub_end_date._Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					cal_sub_end_date.set_Value(DateTime.Parse(DateTime.Today.ToString("MM-dd-yyyy")));
				}

				//UPGRADE_ISSUE: (2064) MSComCtl2.MonthView property cal_sub_start_date._Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cal_sub_start_date.set_Value(DateTime.Parse(DateTime.Today.ToString("MM-dd-yyyy")));
				txt_sub_start_date.Text = DateTimeHelper.ToString(cal_sub_start_date.SelectionRange.Start);

				cbo_Service.Enabled = false;
				modCommon.SetComboText(cbo_Service, "");
				cbo_Service.Enabled = true;

				cmbFrequency.Enabled = false;
				modCommon.SetComboText(cmbFrequency, "");
				cmbFrequency.Enabled = true;

				cmbTierLevel.Enabled = false;
				modCommon.SetComboText(cmbTierLevel, "");
				cmbTierLevel.Enabled = true;


				cmbTierLevel_comm.Enabled = false;
				modCommon.SetComboText(cmbTierLevel_comm, "");
				cmbTierLevel_comm.Enabled = true;

				txt_sub_id.Enabled = true;
				cbo_Service.SelectedIndex = -1;

				// 03/16/2004 - By David D. Cruger; Added Marketing Flag and Nbr of Days Expire
				chkProductType[modSubscription.ProductBusinessAC].CheckState = CheckState.Unchecked;
				chkProductType[modSubscription.ProductHelicopters].CheckState = CheckState.Unchecked;

				// CHANGED MSW - 7/3/2018
				if (is_dealer_broker)
				{
					chkProductType[modSubscription.ProductABIListing].CheckState = CheckState.Checked;
				}
				else
				{
					chkProductType[modSubscription.ProductABIListing].CheckState = CheckState.Unchecked;
				}

				chkProductType[modSubscription.ProductCommercial].CheckState = CheckState.Unchecked;
				chkProductType[modSubscription.ProductAerodex].CheckState = CheckState.Unchecked;
				chkProductType[modSubscription.ProductStarReports].CheckState = CheckState.Unchecked;
				chkProductType[modSubscription.ProductSPI].CheckState = CheckState.Unchecked;
				chkProductType[modSubscription.ProductMarketing].CheckState = CheckState.Unchecked;
				chkProductType[modSubscription.ShareByCompId].CheckState = CheckState.Unchecked;
				chkProductType[modSubscription.ShareByParentId].CheckState = CheckState.Unchecked;
				chkProductType[modSubscription.ProductHistory].CheckState = CheckState.Checked;
				chkProductType[modSubscription.ProductMPM].CheckState = CheckState.Unchecked;
				chk_sub_api_flag.CheckState = CheckState.Unchecked;

				lblNbrDaysExpire.Visible = false;
				txtNbrDaysExpire.Visible = false;
				txtNbrDaysExpire.Text = "0";


				txt_sub_id.Text = "0";


				// 11/26/2007 - By David D. Cruger - Added
				txt_SubNbrOfInstalls[iNbrInstalls].Text = "0"; // Nbr of Installs

				// 09/20/2019 - By David D. Cruger - Added
				txt_SubNbrOfInstalls[iNBRVALUEINSTALLS].Text = "0"; // Nbr SPI/Values Installs
				txt_SubNbrOfInstalls[iNBRMPMINSTALLS].Text = "0"; // Nbr MPM Installs

				txt_SubContractAmount.Text = "0.00";
				txt_sub_billed_amount.Text = "0.00";
				txtCallBackDate.Text = "";
				cboCallBackStatus.SelectedIndex = 0;
				txtCallbackComments.Text = "";

				txtSubMaxExport.Text = "2000";

				Mode = "AddSubscription";
				DisableAllButtons();
				cmdSubscription[iSAVESUBSCRIPTION].Enabled = true;
				cmd_Close.Enabled = true;

				cmdSubscription[2].Enabled = modAdminCommon.gbl_User_Create_Sub == "Y";

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("New_Subscription_Error: ");
			}

		}

		private void Remove_Subscription()
		{

			string Query = "";
			string M = "";

			int lCompId = 0;
			int lSubId = 0;

			try
			{

				M = "Subscription Removed";

				lCompId = modSubscription.Entered_Company_ID;
				lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));

				modAdminCommon.ADO_Transaction("BeginTrans");

				modSubscription.search_on("Deleting Subscription Information...");

				Query = $"DELETE FROM Subscription WHERE (sub_id = {modSubscription.gbl_SubID.ToString()}) ";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //aey 6/21/04

				modSubscription.search_on("Deleting Login Information...");

				Query = $"DELETE FROM Subscription_Login WHERE (sublogin_sub_id = {modSubscription.gbl_SubID.ToString()}) ";

				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery(); //aey 6/21/04

				modSubscription.search_on("Deleting Install Information...");

				Query = $"DELETE FROM Subscription_Install  WHERE (subins_sub_id = {modSubscription.gbl_SubID.ToString()}) ";
				DbCommand TempCommand_3 = null;
				TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
				TempCommand_3.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_3.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
				TempCommand_3.ExecuteNonQuery(); //aey 6/21/04


				ClearSavedProjectsFolders(lSubId, "", -1, false);

				modAdminCommon.Record_Delete_Log_Entry("Subscription", modSubscription.gbl_SubID, 0, 0);

				modAdminCommon.ADO_Transaction("CommitTrans");

				Fill_grd_Subscriptions(modSubscription.Entered_Company_ID);

				if (grd_Subscriptions.RowsCount == 1)
				{
					if (chkIncludeInactive.CheckState == CheckState.Unchecked)
					{
						chkIncludeInactive.CheckState = CheckState.Checked;
						Fill_grd_Subscriptions(modSubscription.Entered_Company_ID);
					}
				}



				modSubscription.search_off();

				strAddChgHasHappened = $"{strAddChgHasHappened}A Subscription Has Been Deleted On SubId: {modSubscription.gbl_SubID.ToString()}{Environment.NewLine}";

				MessageBox.Show(M, "SUBSCRIPTION REMOVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Remove_Subscription_Error: ");
			}

		}

		private void Load_Subscription_Journal_Notes_Grid()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strCompId = "";
			int lTot1 = 0;
			int lCnt1 = 0;

			try
			{

				strCompId = modSubscription.Entered_Company_ID.ToString();

				lblSubLabel[iNOTESLOADING].Text = "Loading Subscription Notes -  #,### of #,### Total Records";
				lblSubLabel[iSTOPLOADING].Visible = false;
				lblSubLabel[iSTOPLOADING].Enabled = false;

				if ((strCompId != "0") && (strCompId != ""))
				{

					grd_SubJournalNotes.Clear();
					grd_SubJournalNotes.RowsCount = 2;
					grd_SubJournalNotes.FixedRows = 1;
					grd_SubJournalNotes.FixedColumns = 0;

					grd_SubJournalNotes.ColumnsCount = 7;
					grd_SubJournalNotes.CurrentRowIndex = 0;

					grd_SubJournalNotes.CurrentColumnIndex = 0;
					grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = "JournId";
					grd_SubJournalNotes.SetColumnWidth(0, 67);
					grd_SubJournalNotes.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					grd_SubJournalNotes.CellBackColor = grd_SubJournalNotes.BackColorFixed;

					grd_SubJournalNotes.CurrentColumnIndex = 1;
					grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = "Date";
					grd_SubJournalNotes.SetColumnWidth(1, 67);
					grd_SubJournalNotes.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					grd_SubJournalNotes.CellBackColor = grd_SubJournalNotes.BackColorFixed;

					grd_SubJournalNotes.CurrentColumnIndex = 2;
					grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = "Time";
					grd_SubJournalNotes.SetColumnWidth(2, 80);
					grd_SubJournalNotes.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					grd_SubJournalNotes.CellBackColor = grd_SubJournalNotes.BackColorFixed;

					grd_SubJournalNotes.CurrentColumnIndex = 3;
					grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = "User";
					grd_SubJournalNotes.SetColumnWidth(3, 50);
					grd_SubJournalNotes.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					grd_SubJournalNotes.CellBackColor = grd_SubJournalNotes.BackColorFixed;

					grd_SubJournalNotes.CurrentColumnIndex = 4;
					grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = "Subject";
					grd_SubJournalNotes.SetColumnWidth(4, 300);
					grd_SubJournalNotes.CellBackColor = grd_SubJournalNotes.BackColorFixed;

					grd_SubJournalNotes.CurrentColumnIndex = 5;
					grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = "Description";
					grd_SubJournalNotes.SetColumnWidth(5, 350);
					grd_SubJournalNotes.CellBackColor = grd_SubJournalNotes.BackColorFixed;

					grd_SubJournalNotes.CurrentColumnIndex = 6;
					grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = "";
					grd_SubJournalNotes.SetColumnWidth(6, 0);
					grd_SubJournalNotes.CellBackColor = grd_SubJournalNotes.BackColorFixed;

					grd_SubJournalNotes.CurrentRowIndex = 1;

					strQuery1 = $"SELECT * FROM Journal WITH (NOLOCK) WHERE (journ_comp_id = {strCompId}) ";
					strQuery1 = $"{strQuery1}AND (journ_subcategory_code = 'SN') ORDER BY journ_id DESC";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						lblSubLabel[iSTOPLOADING].Visible = true;
						lblSubLabel[iSTOPLOADING].Enabled = true;

						lTot1 = rstRec1.RecordCount;
						lCnt1 = 0;

						grd_SubJournalNotes.Redraw = false;

						do 
						{ // Loop Until rstRec1.EOF = True Or lblSubLabel(iSTOPLOADING ).Enabled = False

							grd_SubJournalNotes.CurrentColumnIndex = 0;
							grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = Convert.ToString(rstRec1["journ_id"]);
							grd_SubJournalNotes.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SubJournalNotes.CurrentColumnIndex = 1;
							grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = Convert.ToDateTime(rstRec1["journ_entry_date"]).ToString("MM/dd/yyyy");
							grd_SubJournalNotes.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SubJournalNotes.CurrentColumnIndex = 2;
							grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["journ_entry_time"], "hh:mm:ss AM/PM");
							grd_SubJournalNotes.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SubJournalNotes.CurrentColumnIndex = 3;
							grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["journ_user_id"])} ").Trim();
							grd_SubJournalNotes.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SubJournalNotes.CurrentColumnIndex = 4;
							grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["journ_subject"])} ").Trim();

							grd_SubJournalNotes.CurrentColumnIndex = 5;
							grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["journ_description"])} ").Trim();

							grd_SubJournalNotes.CurrentColumnIndex = 6;
							grd_SubJournalNotes[grd_SubJournalNotes.CurrentRowIndex, grd_SubJournalNotes.CurrentColumnIndex].Value = ""; // Blank

							lCnt1++;
							lblSubLabel[iNOTESLOADING].Text = $"Loading Subscription Notes -  {StringsHelper.Format(lCnt1, "#,##0")} of {StringsHelper.Format(lTot1, "#,##0")} Total Records";

							if (lCnt1 == 23)
							{
								grd_SubJournalNotes.Redraw = true;
								grd_SubJournalNotes.Refresh();
								Application.DoEvents();
								grd_SubJournalNotes.Redraw = false;
							}

							rstRec1.MoveNext();
							Application.DoEvents();

							if (!rstRec1.EOF)
							{
								grd_SubJournalNotes.RowsCount++;
								grd_SubJournalNotes.CurrentRowIndex++;
							}

						}
						while(!(rstRec1.EOF || !lblSubLabel[iSTOPLOADING].Enabled));

						grd_SubJournalNotes.Visible = true;
						grd_SubJournalNotes.Redraw = true;

						lblSubLabel[iSTOPLOADING].Visible = false;
						lblSubLabel[iSTOPLOADING].Enabled = false;

						grd_SubJournalNotes.CurrentRowIndex = 1; // Set to first Row

					}
					else
					{
						grd_SubJournalNotes.FixedRows = 0;
						grd_SubJournalNotes.RemoveItem(1);
						grd_SubJournalNotes.RowsCount = 0;
					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

				}
				else
				{
					MessageBox.Show("Company Id Is Blank Or Zero!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (strCompId <> "0") And (strCompId <> "") Then

				rstRec1 = null;
			}
			catch
			{

				modAdminCommon.Report_Error("Load_Subscription_Journal_Notes_Grid_Error: ");
			}

		} // End Load_Subscription_Journal_Notes_Grid

		private void Load_Execution_Form_Grid()
		{

			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strCompId = "";
			string strTechId = ""; // All Associated With This CompId
			string strCustomerServer = "";
			int lCnt1 = 0;
			int lCol1 = 0;

			try
			{

				if (grd_SubExecutionForms.Enabled)
				{

					grd_SubExecutionForms.Enabled = false;

					strCompId = modSubscription.Entered_Company_ID.ToString();

					if ((strCompId != "0") && (strCompId != ""))
					{

						wbSubBrowser1[3].Visible = false;
						wbSubBrowser1[3].Navigate(new Uri("about:blank")); // Make Sure It's Not Open
						lstb_SubExecutionFormsDisplay.Visible = true;
						lstb_SubExecutionFormsDisplay.Items.Clear();

						modCommon.DelaySeconds(1);

						grd_SubExecutionForms.Clear();
						grd_SubExecutionForms.RowsCount = 2;
						grd_SubExecutionForms.FixedRows = 1;
						grd_SubExecutionForms.FixedColumns = 0;

						grd_SubExecutionForms.ColumnsCount = 21;
						grd_SubExecutionForms.CurrentRowIndex = 0;

						lCol1 = 0;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "ExcId";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 0);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "SubId";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 53);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "ExcNbr";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 0);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "ExcDate";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 67);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "CName";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 0);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "Status";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 43);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "Contract #";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 67);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "Contract Date";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 83);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "Service";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 50);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "Mth List";
						grd_SubExecutionForms.SetColumnWidth(10, 83);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "Mth Billed";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 83);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "Mth Net Chg";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 83);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "CLetter Date";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 67);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "Data";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 0);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "SrvChg Date";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 67);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "Auto Disable";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 67);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "Type";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 100);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "Action Name";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 150);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "Notes";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 467);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol1++;
						grd_SubExecutionForms.CurrentColumnIndex = lCol1;
						grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "";
						grd_SubExecutionForms.SetColumnWidth(lCol1, 0);
						grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						//---------------------------------------------------------
						// Add Grid Data
						//---------------------------------------------------------

						strTechId = "";
						lCnt1 = 1;

						if (grd_Subscriptions.RowsCount > 1)
						{ // They MUST Have Some Subscriptions

							do 
							{ // Loop Until lCnt1 >= grd_Subscriptions.Rows - 1

								grd_Subscriptions.CurrentRowIndex = lCnt1;
								grd_Subscriptions.CurrentColumnIndex = 0;
								strTechId = $"{strTechId}'{StringsHelper.Format(grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].FormattedValue.ToString(), "000000")}',";

								lCnt1++;

							}
							while(lCnt1 < grd_Subscriptions.RowsCount);

							strTechId = strTechId.Substring(0, Math.Min(Strings.Len(strTechId) - 1, strTechId.Length)); // Remove Last Comma

							strCustomerServer = modCommon.DLookUp("aconfig_customer_program_server", "Application_Configuration");

							strConn = $"Provider=SQLNCLI10;Data Source={strCustomerServer};Initial Catalog=Customer;UID=sa;PWD=moejive;";
							cntConn.ConnectionString = strConn;
							//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							cntConn.setCursorLocation(CursorLocationEnum.adUseServer);
							//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							cntConn.setConnectionTimeout(30);
							//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
							cntConn.Open();

							// -- Now Retrieve All The Execution Forms for This (These) TechId's
							strQuery1 = $"SELECT * FROM Customer_Execution WITH (NOLOCK) WHERE (cstexcform_techId IN ({strTechId})) ";
							strQuery1 = $"{strQuery1}ORDER BY cstexcform_techid, cstexcform_exc_date DESC ";

							rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							if ((!rstRec1.BOF) && (!rstRec1.EOF))
							{

								grd_SubExecutionForms.CurrentRowIndex = 1;

								do 
								{ // Loop Until rstRec1.EOF = True

									//---------------------------------------------------------

									lCol1 = 0;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = Convert.ToString(rstRec1["cstexcform_id"]);
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleRight;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = StringsHelper.Format(($"{Convert.ToString(rstRec1["cstexcform_techid"])} ").Trim(), "000000");
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = StringsHelper.Format(($"{Convert.ToString(rstRec1["cstexcform_exc_nbr"])} ").Trim(), "0000");
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(rstRec1["cstexcform_exc_date"]))
									{
										if (Information.IsDate(rstRec1["cstexcform_exc_date"]))
										{
											System.DateTime TempDate2 = DateTime.FromOADate(0);
											grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = (DateTime.TryParse(($"{Convert.ToString(rstRec1["cstexcform_exc_date"])} ").Trim(), out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : ($"{Convert.ToString(rstRec1["cstexcform_exc_date"])} ").Trim();
										}
									}
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["cstexcform_cname"])} ").Trim();
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["cstexcform_status"])} ").Trim();
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["cstexcform_contract_nbr"])} ").Trim();
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(rstRec1["cstexcform_contract_date"]))
									{
										if (Information.IsDate(rstRec1["cstexcform_contract_date"]))
										{
											System.DateTime TempDate3 = DateTime.FromOADate(0);
											grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = (DateTime.TryParse(($"{Convert.ToString(rstRec1["cstexcform_contract_date"])} ").Trim(), out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy") : ($"{Convert.ToString(rstRec1["cstexcform_contract_date"])} ").Trim();
										}
									}
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["cstexcform_service"])} ").Trim();
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

									//---------------------------------------------------------
									// Monthly List Fee

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms.CellForeColor = modExcel.gridCellDefaultForeColor;
									grd_SubExecutionForms.CellBackColor = modExcel.gridCellDefaultBackColor;
									grd_SubExecutionForms.CellFontBold = false;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["cstexcform_monthly_list_fee"], "$#,##0.00");
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleRight;

									//---------------------------------------------------------
									// Monthly Billed Fee

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;

									grd_SubExecutionForms.CellForeColor = modExcel.gridCellDefaultForeColor;
									grd_SubExecutionForms.CellBackColor = modExcel.gridCellDefaultBackColor;
									grd_SubExecutionForms.CellFontBold = false;

									if (Convert.ToDouble(rstRec1["cstexcform_monthly_net_fee"]) < 0)
									{
										grd_SubExecutionForms.CellForeColor = Color.White;
										grd_SubExecutionForms.CellBackColor = Color.Red;
										grd_SubExecutionForms.CellFontBold = true;
									}

									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["cstexcform_monthly_fee"], "$#,##0.00");
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleRight;

									//---------------------------------------------------------
									// Monthly Net Changed Fee

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms.CellForeColor = modExcel.gridCellDefaultForeColor;
									grd_SubExecutionForms.CellBackColor = modExcel.gridCellDefaultBackColor;
									grd_SubExecutionForms.CellFontBold = false;

									if (Convert.ToDouble(rstRec1["cstexcform_monthly_net_fee"]) < 0)
									{
										grd_SubExecutionForms.CellForeColor = Color.White;
										grd_SubExecutionForms.CellBackColor = Color.Red;
										grd_SubExecutionForms.CellFontBold = true;
									}

									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["cstexcform_monthly_net_fee"], "$#,##0.00");
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleRight;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(rstRec1["cstexcform_cletter_date"]))
									{
										if (Information.IsDate(rstRec1["cstexcform_cletter_date"]))
										{
											System.DateTime TempDate4 = DateTime.FromOADate(0);
											grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = (DateTime.TryParse(($"{Convert.ToString(rstRec1["cstexcform_cletter_date"])} ").Trim(), out TempDate4)) ? TempDate4.ToString("MM/dd/yyyy") : ($"{Convert.ToString(rstRec1["cstexcform_cletter_date"])} ").Trim();
										}
									}
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["cstexcform_data"])} ").Trim();
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(rstRec1["cstexcform_service_change_date"]))
									{
										if (Information.IsDate(rstRec1["cstexcform_service_change_date"]))
										{
											System.DateTime TempDate5 = DateTime.FromOADate(0);
											grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = (DateTime.TryParse(($"{Convert.ToString(rstRec1["cstexcform_service_change_date"])} ").Trim(), out TempDate5)) ? TempDate5.ToString("MM/dd/yyyy") : ($"{Convert.ToString(rstRec1["cstexcform_service_change_date"])} ").Trim();
										}
									}
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = "";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(rstRec1["cstexcform_auto_disable_date"]))
									{
										if (Information.IsDate(rstRec1["cstexcform_auto_disable_date"]))
										{
											System.DateTime TempDate6 = DateTime.FromOADate(0);
											grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = (DateTime.TryParse(($"{Convert.ToString(rstRec1["cstexcform_auto_disable_date"])} ").Trim(), out TempDate6)) ? TempDate6.ToString("MM/dd/yyyy") : ($"{Convert.ToString(rstRec1["cstexcform_auto_disable_date"])} ").Trim();
										}
									}
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["cstexcform_type"])} ").Trim();
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["cstexcform_action_name"])} ").Trim();
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["cstexcform_notes"])} ").Trim();
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

									//---------------------------------------------------------

									lCol1++;
									grd_SubExecutionForms.CurrentColumnIndex = lCol1;
									grd_SubExecutionForms[grd_SubExecutionForms.CurrentRowIndex, grd_SubExecutionForms.CurrentColumnIndex].Value = ""; // Blank
									grd_SubExecutionForms.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

									rstRec1.MoveNext();

									if (!rstRec1.EOF)
									{
										grd_SubExecutionForms.RowsCount++;
										grd_SubExecutionForms.CurrentRowIndex++;
									}

								}
								while(!rstRec1.EOF);

							}
							else
							{
								grd_SubExecutionForms.FixedRows = 0;
								grd_SubExecutionForms.RemoveItem(1);
								grd_SubExecutionForms.RowsCount = 0;
							} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

							rstRec1.Close();

							UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
							cntConn.Close();

						}
						else
						{
							grd_SubExecutionForms.FixedRows = 0;
							grd_SubExecutionForms.RemoveItem(1);
							grd_SubExecutionForms.RowsCount = 0;
						} // If grd_Subscriptions.Rows > 1 Then

					} // If (strCompId <> "0") And (strCompId <> "") Then

					grd_SubExecutionForms.Enabled = true;

				} // If (grd_SubExecutionForms.Enabled = True) Then

				rstRec1 = null;
				cntConn = null;
			}
			catch
			{

				modAdminCommon.Report_Error("Load_Execution_Form_Grid_Error: ");
			}

		} // Load_Execution_Form_Grid

		private void Load_Subscription_Documents_Grid()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strCompId = "";
			int lCol = 0;
			object lColor = null;

			try
			{

				strCompId = modSubscription.Entered_Company_ID.ToString();

				if ((strCompId != "0") && (strCompId != ""))
				{

					grd_SubDocument.Clear();
					grd_SubDocument.RowsCount = 2;
					grd_SubDocument.FixedRows = 1;
					grd_SubDocument.FixedColumns = 0;

					grd_SubDocument.ColumnsCount = 7;
					grd_SubDocument.CurrentRowIndex = 0;

					lCol = 0;
					grd_SubDocument.CurrentColumnIndex = lCol;
					grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = "DocId";
					grd_SubDocument.SetColumnWidth(lCol, 67);
					grd_SubDocument.CellAlignment = DataGridViewContentAlignment.MiddleRight;
					grd_SubDocument.CellBackColor = grd_SubDocument.BackColorFixed;

					lCol++;
					grd_SubDocument.CurrentColumnIndex = lCol;
					grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = "Type"; // Evolution Contract
					grd_SubDocument.SetColumnWidth(lCol, 200);
					grd_SubDocument.CellBackColor = grd_SubDocument.BackColorFixed;

					lCol++;
					grd_SubDocument.CurrentColumnIndex = lCol;
					grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = "Doc Date";
					grd_SubDocument.SetColumnWidth(lCol, 67);
					grd_SubDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					grd_SubDocument.CellBackColor = grd_SubDocument.BackColorFixed;

					lCol++;
					grd_SubDocument.CurrentColumnIndex = lCol;
					grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = "Entry Date";
					grd_SubDocument.SetColumnWidth(lCol, 67);
					grd_SubDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					grd_SubDocument.CellBackColor = grd_SubDocument.BackColorFixed;

					lCol++;
					grd_SubDocument.CurrentColumnIndex = lCol;
					grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = "User Id";
					grd_SubDocument.SetColumnWidth(lCol, 47);
					grd_SubDocument.CellBackColor = grd_SubDocument.BackColorFixed;

					lCol++;
					grd_SubDocument.CurrentColumnIndex = lCol;
					grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = "Subject";
					grd_SubDocument.SetColumnWidth(lCol, 467);
					grd_SubDocument.CellBackColor = grd_SubDocument.BackColorFixed;

					lCol++;
					grd_SubDocument.CurrentColumnIndex = lCol;
					grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = "";
					grd_SubDocument.SetColumnWidth(lCol, 0);
					grd_SubDocument.CellBackColor = grd_SubDocument.BackColorFixed;

					grd_SubDocument.CurrentRowIndex = 1;

					strQuery1 = "SELECT * FROM Company_Documents WITH (NOLOCK)  INNER JOIN Document_Type on compdoc_doc_type_code = doctype_code ";
					strQuery1 = $"{strQuery1}WHERE (compdoc_comp_id = {strCompId}) ";
					strQuery1 = $"{strQuery1}AND (compdoc_journ_id = 0) AND (doctype_contract_doc_view = 'Y') ";
					strQuery1 = $"{strQuery1}ORDER BY compdoc_id DESC ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						do 
						{ // Loop Until rstRec1.EOF = True

							lColor = gridCellActiveColor;

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["compdoc_expiration_date"]))
							{
								if (Information.IsDate(rstRec1["compdoc_expiration_date"]))
								{
									if (Convert.ToDateTime(rstRec1["compdoc_expiration_date"]) > DateTime.Parse("1/1/1960"))
									{
										if (Convert.ToDateTime(rstRec1["compdoc_expiration_date"]) <= DateTime.Now)
										{
											lColor = gridCellInActiveColor;
										}
									}
								}
							}

							lCol = 0;
							grd_SubDocument.CurrentColumnIndex = lCol;
							//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grd_SubDocument.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
							grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = Convert.ToString(rstRec1["compdoc_id"]);
							grd_SubDocument.CellAlignment = DataGridViewContentAlignment.MiddleRight;

							lCol++;
							grd_SubDocument.CurrentColumnIndex = lCol;
							//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grd_SubDocument.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
							grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = $"{($"{Convert.ToString(rstRec1["compdoc_doc_type_code"])} ").Trim()} - {($"{Convert.ToString(rstRec1["doctype_description"])} ").Trim()}";

							lCol++;
							grd_SubDocument.CurrentColumnIndex = lCol;
							//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grd_SubDocument.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
							grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["compdoc_doc_date"]))
							{
								if (Information.IsDate(rstRec1["compdoc_doc_date"]))
								{
									if (Convert.ToDouble(rstRec1["compdoc_doc_date"]) > 0)
									{
										grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = Convert.ToDateTime(rstRec1["compdoc_doc_date"]).ToString("MM/dd/yyyy");
									}
								}
							}
							grd_SubDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							lCol++;
							grd_SubDocument.CurrentColumnIndex = lCol;
							//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grd_SubDocument.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
							grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["compdoc_entry_date"]))
							{
								if (Information.IsDate(rstRec1["compdoc_entry_date"]))
								{
									if (Convert.ToDouble(rstRec1["compdoc_entry_date"]) > 0)
									{
										grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = Convert.ToDateTime(rstRec1["compdoc_entry_date"]).ToString("MM/dd/yyyy");
									}
								}
							}
							grd_SubDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							lCol++;
							grd_SubDocument.CurrentColumnIndex = lCol;
							//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grd_SubDocument.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
							grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["compdoc_user_id"])} ").Trim();

							lCol++;
							grd_SubDocument.CurrentColumnIndex = lCol;
							//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grd_SubDocument.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
							grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["compdoc_subject"])} ").Trim();

							lCol++;
							grd_SubDocument.CurrentColumnIndex = lCol;
							//UPGRADE_WARNING: (1068) lColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grd_SubDocument.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lColor));
							grd_SubDocument[grd_SubDocument.CurrentRowIndex, grd_SubDocument.CurrentColumnIndex].Value = ""; // Blank

							rstRec1.MoveNext();

							if (!rstRec1.EOF)
							{
								grd_SubDocument.RowsCount++;
								grd_SubDocument.CurrentRowIndex++;
							}

						}
						while(!rstRec1.EOF);

						grd_SubDocument.CurrentRowIndex = 1; // Set to first Row

					}
					else
					{
						grd_SubDocument.FixedRows = 0;
						grd_SubDocument.RemoveItem(1);
						grd_SubDocument.RowsCount = 0;
					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

				}
				else
				{
					MessageBox.Show("Company Id Is Blank Or Zero!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (strCompId <> "0") And (strCompId <> "") Then

				rstRec1 = null;
			}
			catch
			{

				modAdminCommon.Report_Error("Load_Subscription_Journal_Notes_Grid_Error: ");
			}

		} // Load_Subscription_Documents_Grid

		private void Load_Service_Interruption_Grid()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strCompId = "";

			try
			{

				strCompId = modSubscription.Entered_Company_ID.ToString();

				grd_SubSIDocument.Clear();

				if ((strCompId != "0") && (strCompId != ""))
				{

					strQuery1 = "SELECT Service_Interruption.* FROM Service_Interruption WITH (NOLOCK) INNER JOIN Subscription WITH (NOLOCK) ON serint_sub_id = sub_id ";
					strQuery1 = $"{strQuery1}WHERE (sub_comp_id = {strCompId}) ORDER BY serint_id DESC ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						grd_SubSIDocument.Clear();
						grd_SubSIDocument.RowsCount = 2;
						grd_SubSIDocument.FixedRows = 1;
						grd_SubSIDocument.FixedColumns = 0;

						grd_SubSIDocument.ColumnsCount = 12;
						grd_SubSIDocument.CurrentRowIndex = 0;

						grd_SubSIDocument.CurrentColumnIndex = 0;
						grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "DocId";
						grd_SubSIDocument.SetColumnWidth(0, 50);
						grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						grd_SubSIDocument.CellBackColor = grd_SubSIDocument.BackColorFixed;

						grd_SubSIDocument.CurrentColumnIndex = 1;
						grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "SubId";
						grd_SubSIDocument.SetColumnWidth(1, 50);
						grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						grd_SubSIDocument.CellBackColor = grd_SubSIDocument.BackColorFixed;

						grd_SubSIDocument.CurrentColumnIndex = 2;
						grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "Requested Date"; // Requested Date
						grd_SubSIDocument.SetColumnWidth(2, 127);
						grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						grd_SubSIDocument.CellBackColor = grd_SubSIDocument.BackColorFixed;

						grd_SubSIDocument.CurrentColumnIndex = 3;
						grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "Interrupt Date";
						grd_SubSIDocument.SetColumnWidth(3, 93);
						grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						grd_SubSIDocument.CellBackColor = grd_SubSIDocument.BackColorFixed;

						grd_SubSIDocument.CurrentColumnIndex = 4;
						grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "ADisable Date";
						grd_SubSIDocument.SetColumnWidth(4, 93);
						grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						grd_SubSIDocument.CellBackColor = grd_SubSIDocument.BackColorFixed;

						grd_SubSIDocument.CurrentColumnIndex = 5;
						grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "Stop Evo";
						grd_SubSIDocument.SetColumnWidth(5, 50);
						grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						grd_SubSIDocument.CellBackColor = grd_SubSIDocument.BackColorFixed;

						grd_SubSIDocument.CurrentColumnIndex = 6;
						grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "Stop Updates";
						grd_SubSIDocument.SetColumnWidth(6, 80);
						grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						grd_SubSIDocument.CellBackColor = grd_SubSIDocument.BackColorFixed;

						grd_SubSIDocument.CurrentColumnIndex = 7;
						grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "Cancel";
						grd_SubSIDocument.SetColumnWidth(7, 50);
						grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						grd_SubSIDocument.CellBackColor = grd_SubSIDocument.BackColorFixed;

						grd_SubSIDocument.CurrentColumnIndex = 8;
						grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "Acct Issues";
						grd_SubSIDocument.SetColumnWidth(8, 67);
						grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						grd_SubSIDocument.CellBackColor = grd_SubSIDocument.BackColorFixed;

						grd_SubSIDocument.CurrentColumnIndex = 9;
						grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "Chg ADisable";
						grd_SubSIDocument.SetColumnWidth(9, 73);
						grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						grd_SubSIDocument.CellBackColor = grd_SubSIDocument.BackColorFixed;

						grd_SubSIDocument.CurrentColumnIndex = 10;
						grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "Approved By";
						grd_SubSIDocument.SetColumnWidth(10, 157);
						grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_SubSIDocument.CellBackColor = grd_SubSIDocument.BackColorFixed;

						grd_SubSIDocument.CurrentColumnIndex = 11;
						grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "";
						grd_SubSIDocument.SetColumnWidth(11, 0);

						grd_SubSIDocument.CurrentRowIndex = 1;

						do 
						{ // Loop Until rstRec1.EOF = True

							grd_SubSIDocument.CurrentColumnIndex = 0;
							grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = Convert.ToString(rstRec1["serint_id"]);
							grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleRight;

							grd_SubSIDocument.CurrentColumnIndex = 1;
							grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = Convert.ToString(rstRec1["serint_sub_id"]);
							grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleRight;

							grd_SubSIDocument.CurrentColumnIndex = 2;
							grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["serint_requested_date"]))
							{
								if (Information.IsDate(rstRec1["serint_requested_date"]))
								{
									grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["serint_requested_date"], "mm/dd/yyyy hh:mm:ss AM/PM");
								}
							}
							grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SubSIDocument.CurrentColumnIndex = 3;
							grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["serint_interrupt_date"]))
							{
								if (Information.IsDate(rstRec1["serint_interrupt_date"]))
								{
									grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = Convert.ToDateTime(rstRec1["serint_interrupt_date"]).ToString("MM/dd/yyyy");
								}
							}
							grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SubSIDocument.CurrentColumnIndex = 4;
							grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["serint_auto_disable_date"]))
							{
								if (Information.IsDate(rstRec1["serint_auto_disable_date"]))
								{
									grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = Convert.ToDateTime(rstRec1["serint_auto_disable_date"]).ToString("MM/dd/yyyy");
								}
							}
							grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SubSIDocument.CurrentColumnIndex = 5;
							grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["serint_stop_evolution"])} ").Trim();
							grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SubSIDocument.CurrentColumnIndex = 6;
							grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["serint_stop_updates"])} ").Trim();
							grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SubSIDocument.CurrentColumnIndex = 7;
							grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["serint_cancellation"])} ").Trim();
							grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SubSIDocument.CurrentColumnIndex = 8;
							grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["serint_accounting_issues"])} ").Trim();
							grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SubSIDocument.CurrentColumnIndex = 9;
							grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["serint_change_auto_disable"])} ").Trim();
							grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SubSIDocument.CurrentColumnIndex = 10;
							grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["serint_approvedby"])} ").Trim();
							grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							grd_SubSIDocument.CurrentColumnIndex = 11;
							grd_SubSIDocument[grd_SubSIDocument.CurrentRowIndex, grd_SubSIDocument.CurrentColumnIndex].Value = ""; // Blank
							grd_SubSIDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							rstRec1.MoveNext();

							if (!rstRec1.EOF)
							{
								grd_SubSIDocument.RowsCount++;
								grd_SubSIDocument.CurrentRowIndex++;
							}

						}
						while(!rstRec1.EOF);

						grd_SubSIDocument.CurrentRowIndex = 1; // Set to first Row

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

				}
				else
				{
					MessageBox.Show("Company Id Is Blank Or Zero!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (strCompId <> "0") And (strCompId <> "") Then

				rstRec1 = null;
			}
			catch
			{

				modAdminCommon.Report_Error("Load_Service_Interruption_Grid_Error: ");
			}

		} // Load_Service_Interruption_Grid

		private void lbl_SubNbrOfInstalls_Click(Object eventSender, EventArgs eventArgs)
		{


			string strService = ($"{cbo_Service.Text} ").Trim().ToUpper();

			if (strService.StartsWith("CRM", StringComparison.Ordinal) || strService.StartsWith("WBSV", StringComparison.Ordinal))
			{
				MessageBox.Show("Automatic Updating Installs on a CRM Or WBSV Serivce is NOT Allowed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void lblCalendars_Click(Object eventSender, EventArgs eventArgs)
		{
			if (!frmStartEndDate.Visible)
			{
				frmStartEndDate.Visible = true;
				lblCalendars.Text = "<< Hide Calendars >>";
				frmStartEndDate.BringToFront();
			}
			else
			{
				frmStartEndDate.Visible = false;
				lblCalendars.Text = "<< View Calendars >>";
				frmCallbackStatus.BringToFront();
			}
		}

		private void lblLoginFlagsHide_Click(Object eventSender, EventArgs eventArgs)
		{
			frmLoginFlags.Visible = false;
			frmLoginFlags.Enabled = false;
		}

		private void lblLoginShowFlags_Click(Object eventSender, EventArgs eventArgs)
		{
			frmLoginFlags.Visible = true;
			frmLoginFlags.Enabled = true;
			frmLoginFlags.BringToFront();
		}

		//UPGRADE_NOTE: (7001) The following declaration (lblMobileActiveDate_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void lblMobileActiveDate_Click()
		//{
			//
			//string strMsg = "";
			//
			//if (txtCellNumber.Text != "")
			//{
				//if (txtMobileActiveDate.Text != "")
				//{
					//strMsg = $"http://www.jetnetevomobile.com/login.asp?ENbr={modSubscription.Base64_Encode($"{txtCellNumber.Text}|{txtMobileActiveDate.Text}")}";
					//MessageBox.Show($"Evolution Mobile Login{Environment.NewLine}{strMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
				//}
				//else
				//{
					//MessageBox.Show("Mobile Active Date Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				//}
			//}
			//else
			//{
				//MessageBox.Show("Cell Number Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
			//
		//}

		private void lblSendTextMsgOK_Click(Object eventSender, EventArgs eventArgs)
		{

			modSubscription.TextMsg_Customer_Record tmRec = modSubscription.TextMsg_Customer_Record.CreateInstance();
			string strUpdate1 = "";

			string strMsg = "";

			try
			{

				if (lblSendTextMsgOK.Enabled)
				{

					lblSendTextMsgOK.Enabled = false;
					lblSendTextMsgEvoMobileLink.Enabled = false;

					if (MessageBox.Show("Ok To Send Text Message", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{

						modSubscription.FillBasicTextMessageRecord(ref tmRec, strMsg);

						txtSMSTextActiveFlag.Text = "Activate";

						grd_Installations.CurrentColumnIndex = 20;
						grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].Value = txtSMSTextActiveFlag.Text;

						strUpdate1 = "UPDATE Subscription_Install  SET subins_smstxt_active_flag = 'A', subins_web_action_date = NULL ";
						strUpdate1 = $"{strUpdate1}WHERE (subins_sub_id = {tmRec.lSubId.ToString()}) AND (subins_login = '{tmRec.strLogin}') ";
						strUpdate1 = $"{strUpdate1}AND (subins_seq_no = {tmRec.lSeqNbr.ToString()})  AND (subins_cell_number = '{tmRec.strCellNumber}') ";

						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						if (modSubscription.OpenRemoteDatabase())
						{
							DbCommand TempCommand_2 = null;
							TempCommand_2 = REMOTE_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = strUpdate1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();
							modSubscription.CloseRemoteDatabase();
						}

						MessageBox.Show("Text Message Queued", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

					} // If MsgBox("Ok To Send Text Message", vbYesNo + vbApplicationModal) = vbYes Then

					lblSendTextMsgOK.Enabled = true;
					lblSendTextMsgEvoMobileLink.Enabled = true;

				} // If lblSendTextMsgOK.Enabled = True Then
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"lblSendTextMsgOK_Click_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				lblSendTextMsgOK.Enabled = true;

				if (txtSMSTextActiveFlag.Text == "Yes")
				{
					lblSendTextMsgEvoMobileLink.Enabled = true;
				}
			}

		} // lblSendTextMsgOK_Click

		private void lblSendTextMsgEvoMobileLink_Click(Object eventSender, EventArgs eventArgs)
		{

			modSubscription.TextMsg_Customer_Record tmRec = modSubscription.TextMsg_Customer_Record.CreateInstance();

			string strMsg = "";

			try
			{

				if (lblSendTextMsgEvoMobileLink.Enabled)
				{

					lblSendTextMsgOK.Enabled = false;
					lblSendTextMsgEvoMobileLink.Enabled = false;

					if (MessageBox.Show($"Ok To Send Text Message{Environment.NewLine}This does NOT set the Mobile Active Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{

						strMsg = $"JETNET LLC - 7 Day Access: www.jetnetevomobile.com/login.asp?ENbr={modSubscription.Base64_Encode($"{($"{txtCellNumber.Text} ").Trim()}|{($"{txtMobileActiveDate.Text} ").Trim()}")}";

						modSubscription.FillBasicTextMessageRecord(ref tmRec, strMsg);

						if (modSubscription.Add_Text_Message_To_Queue(ref tmRec))
						{
							Application.DoEvents();
						}

						MessageBox.Show("Text Message Queued", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

					} // If MsgBox("Ok To Send Text Message", vbYesNo + vbApplicationModal) = vbYes Then

					lblSendTextMsgOK.Enabled = true;
					lblSendTextMsgEvoMobileLink.Enabled = true;

				} // If lblSendTextMsgOK.Enabled = True Then
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"lblSendTextMsgEvoMobileLink_Click_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				lblSendTextMsgOK.Enabled = true;
				lblSendTextMsgEvoMobileLink.Enabled = true;
			}

		} // lblSendTextMsgEvoMobileLink_Click

		private void lblSubAddInstall_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			StringBuilder strInsert1 = new StringBuilder();
			int lMaxSeqNbr = 0;
			int iNbrToAdd = 0;
			string strNbrToAdd = "";
			string strUnAssigned = "";
			DialogResult iMsgBox = (DialogResult) 0;
			string strTemp1 = "";
			string strContactId = "";

			try
			{

				if (lblSubAddInstall.Enabled)
				{

					lblSubAddInstall.Enabled = false;
					Application.DoEvents();

					strNbrToAdd = InputBoxHelper.InputBox("Enter Number of Installs to Add (Max=25)", "Add Installs", "1");

					if (strNbrToAdd != "")
					{

						if (Information.IsNumeric(strNbrToAdd))
						{

							iNbrToAdd = Convert.ToInt32(Double.Parse(strNbrToAdd));

							if (iNbrToAdd >= 1 || iNbrToAdd <= 25)
							{

								iMsgBox = MessageBox.Show("Use UNASSIGNED Wordage?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel);

								if (iMsgBox != System.Windows.Forms.DialogResult.Cancel)
								{

									strUnAssigned = "NO";
									if (iMsgBox == System.Windows.Forms.DialogResult.Yes)
									{
										strUnAssigned = "YES";
									}

									// Find Existing Installs
									strQuery1 = "SELECT MAX(subins_seq_no) AS MaxSeqNbr FROM Subscription_Install WITH (NOLOCK) ";
									strQuery1 = $"{strQuery1}WHERE (subins_sub_id = {modSubscription.gbl_SubID.ToString()}) AND (subins_login = '{($"{txtLoginName.Text} ").Trim()}') ";

									rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

									lMaxSeqNbr = 0;
									if ((!rstRec1.BOF) && (!rstRec1.EOF))
									{
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(rstRec1["MaxSeqNbr"]))
										{
											lMaxSeqNbr = Convert.ToInt32(rstRec1["MaxSeqNbr"]);
										}
									}
									rstRec1.Close();

									int tempForEndVar = iNbrToAdd;
									for (int iCnt1 = 1; iCnt1 <= tempForEndVar; iCnt1++)
									{

										lMaxSeqNbr++; // Increament Max Seq Number

										strInsert1 = new StringBuilder("INSERT INTO Subscription_Install ( subins_sub_id,  subins_login, subins_seq_no, ");
										strInsert1.Append("subins_platform_name, subins_platform_os,  subins_install_date, ");
										strInsert1.Append("subins_access_date, subins_active_flag, subins_web_action_date, ");
										strInsert1.Append("subins_local_db_flag, subins_display_note_tag_on_aclist_flag, "); // 03/17/2009 - By David D. Cruger; Added
										strInsert1.Append("subins_local_db_file,  subins_webpage_timeout, subins_activex_flag, ");
										strInsert1.Append("subins_autocheck_tservice, subins_terminal_service, subins_email_replyname, ");
										strInsert1.Append("subins_email_replyaddress, subins_email_default_format, ");
										strInsert1.Append("subins_aircraft_tab_relationship_to_ac_default, subins_contract_amount, ");
										strInsert1.Append("subins_use_cookie_flag, subins_evo_mobile_flag,  subins_admin_flag, ");
										strInsert1.Append($"subins_contact_id ) VALUES ({modSubscription.gbl_SubID.ToString()}, "); // Sub Id
										strInsert1.Append($"'{($"{txtLoginName.Text} ").Trim()}', "); // Login
										strInsert1.Append($"{lMaxSeqNbr.ToString()}, "); // SeqNbr
										if (strUnAssigned == "YES")
										{
											strInsert1.Append($"'Install #{lMaxSeqNbr.ToString()} - UNASSIGNED', "); // Platform Name
											strInsert1.Append("'', "); // Platform OS
										}
										else
										{
											strInsert1.Append($"'Install #{lMaxSeqNbr.ToString()}', "); // Platform Name
											strInsert1.Append($"'Install #{lMaxSeqNbr.ToString()}', "); // Platform OS
										}
										strInsert1.Append("NULL, NULL,  'Y', NULL,  'N',  'N', NULL, 30, "); // Webpage Timeout
										strInsert1.Append("'Y', 'Y', 'N', NULL, NULL, 'TEXT', NULL, "); // Relationship To AC
										strInsert1.Append("0, 'N', "); // Use Cookie Flag

										if (chkProductType[modSubscription.ProductAerodex].CheckState == CheckState.Unchecked)
										{
											strInsert1.Append("'Y', "); // Yes=Evolution Mobile Flag
										}
										else
										{
											strInsert1.Append("'Y', "); // Yes=Evolution Mobile Flag
										}

										strInsert1.Append("'N', "); // No=Admin Flag

										// 11/15/2011 - By David D. Cruger; Added
										// This is a JETNET Demo Account
										strContactId = "0";
										if (modSubscription.Entered_Company_ID == 135887)
										{ // Contract Id
											if (chkProductType[modSubscription.ProductMarketing].CheckState == CheckState.Checked)
											{
												strContactId = "419946";
											}
										}
										strInsert1.Append(strContactId);
										strInsert1.Append(") ");

										DbCommand TempCommand = null;
										TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
										TempCommand.CommandText = strInsert1.ToString();
										//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
										//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
										TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
										TempCommand.ExecuteNonQuery();

									}

									// 03/12/2003 - By David D. Cruger
									// If someone adds a subscription login log an event entry
									strTemp1 = $"Mass Add Install CompId:=[{modSubscription.Entered_Company_ID.ToString()}] SubId:=[{($"{txt_sub_id.Text} ").Trim()}]  ";
									strTemp1 = $"{strTemp1}Login:=[{($"{txtLoginName.Text} ").Trim()}]  Total Added:=[{iNbrToAdd.ToString()}]  ";

									modAdminCommon.Record_Event("Subscription Install Added", strTemp1, 0, 0, modSubscription.Entered_Company_ID);

									Fill_grd_Installations(grd_Logins[grd_Logins.CurrentRowIndex, grd_Logins.CurrentColumnIndex].FormattedValue.ToString());


									MessageBox.Show($"{lMaxSeqNbr.ToString()} Installs Have Been Added", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

								} // If iMsgBox <> vbCancel Then

							}
							else
							{
								MessageBox.Show("Input Must Be With In Range (1-25)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If (iNbrToAdd >= 1 Or iNbrToAdd <= 25) Then

						}
						else
						{
							MessageBox.Show("Input Must Be Numeric (1-25)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} //

					} // If strNbrToAdd <> "" Then

					rstRec1 = null;

					lblSubAddInstall.Enabled = true;

				} // If lblSubAddInstall.Enabled = True Then
			}
			catch
			{

				modAdminCommon.Report_Error("lblSubAddInstall_Click_Error: ");

				lblSubAddInstall.Enabled = true;
			}

		} // lblSubAddInstall_Click

		private void lblSubDocumentId_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();
			FileInfo fFile = null;

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();

			string strQuery1 = "";
			string strQuery2 = "";
			string strUpdate1 = "";

			string strDocumentId = "";

			string strCompIdCurr = "";
			string strCompIdNew = "";
			string strCompNameNew = "";

			string strDocDir = "";
			string strFileNameCurr = ""; // Format - CompId-DocId.PDF
			string strFileNameNew = ""; // Format - CompId-DocId.PDF
			string strExt = "";
			int iPos1 = 0;

			string strMsg = "";
			bool bMoved = false;
			string strUserId = "";

			try
			{


				bMoved = false;
				strDocumentId = ($"{txtSubDocumentId.Text} ").Trim();
				strCompIdCurr = modSubscription.Entered_Company_ID.ToString();
				strCompIdNew = "0";
				strCompNameNew = "";

				strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();

				//------------------------------------------
				// Check - Only DCR Can Move Contracts

				if (strUserId == "DCR" || strUserId == "AJA" || strUserId == "MVIT")
				{

					if (strDocumentId != "" && strDocumentId != "0")
					{

						strDocDir = modCommon.DLookUp("aconfig_customer_contract_dir", "Application_Configuration");
						if (strDocDir.Substring(Math.Max(strDocDir.Length - 1, 0)) != "\\")
						{
							strDocDir = $"{strDocDir}\\";
						}

						strQuery1 = $"SELECT * FROM Company_Documents WITH (NOLOCK) WHERE (compdoc_id = {strDocumentId}) ";

						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if ((!rstRec1.BOF) && (!rstRec1.EOF))
						{

							strFileNameCurr = ($"{Convert.ToString(rstRec1["compdoc_filename"])} ").Trim();
							if (File.Exists($"{strDocDir}{strFileNameCurr}"))
							{

								fFile = new FileInfo($"{strDocDir}{strFileNameCurr}");
								iPos1 = (fFile.Name.IndexOf('.') + 1);
								strExt = fFile.Name.Substring(Math.Min(iPos1, fFile.Name.Length));

								strCompIdNew = InputBoxHelper.InputBox("Enter New CompId", "Move Contract");

								if (strCompIdNew != "" && strCompIdNew != "0")
								{

									//-------------------------
									// Does New CompId Exist
									strQuery2 = "SELECT comp_name FROM Company WITH (NOLOCK) ";
									strQuery2 = $"{strQuery2}WHERE (comp_id = {strCompIdNew}) AND (comp_journ_id = 0) ";

									rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

									if ((!rstRec2.BOF) && (!rstRec2.EOF))
									{

										strFileNameNew = $"{strCompIdNew}-{strDocumentId}.{strExt}";

										if (!File.Exists($"{strDocDir}{strFileNameNew}"))
										{

											File.Move($"{strDocDir}{strFileNameCurr}", $"{strDocDir}{strFileNameNew}");

											strUpdate1 = $"UPDATE Company_Documents SET compdoc_filename = '{strFileNameNew}', ";
											strUpdate1 = $"{strUpdate1}compdoc_comp_id = {strCompIdNew} WHERE (compdoc_id = {strDocumentId}) ";

											modAdminCommon.ADO_Transaction("BeginTrans");
											DbCommand TempCommand = null;
											TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
											UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
											TempCommand.CommandText = strUpdate1;
											//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
											TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
											UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
											TempCommand.ExecuteNonQuery();
											modAdminCommon.ADO_Transaction("CommitTrans");

											bMoved = true;

										}
										else
										{
											MessageBox.Show($"New File Name Already Exists{Environment.NewLine}{strFileNameNew}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										} // If fso.FileExists(strDocDir & strFileNameNew) = False Then

									}
									else
									{
										MessageBox.Show($"New CompId Does NOT Exists {strCompIdNew}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If (rstRec2.BOF = False) And (rstRec2.EOF = False) Then

									rstRec2.Close();

								} // If strCompIdNew <> "" And strCompIdNew <> "0" Then

								fFile = null;

							}
							else
							{
								MessageBox.Show($"Could Not Find Contract File{Environment.NewLine}{strFileNameCurr}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If fso.FileExists(strDocDir & strFileNameCurr) = True Then

						} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

						rstRec1.Close();

						if (bMoved)
						{

							strMsg = $"Moved Company Contract - DocId {strDocumentId} From CompIdCurr {strCompIdCurr} To CompId {strCompIdNew} - {strCompNameNew}";
							modAdminCommon.Record_Event("Moved Contract", strMsg, 0, 0, Convert.ToInt32(Double.Parse(strCompIdCurr)));

							cmdSubDocumentNew_Click(cmdSubDocumentNew, new EventArgs());
							Load_Subscription_Journal_Notes_Grid();
							Load_Subscription_Documents_Grid();

							//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1046
							//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1046
							Interaction.MsgBox($"Contract Has Been Moved To CompId {strCompIdNew} - {strCompNameNew}", MsgBoxStyle.OkCancel, "");

						} // If bMoved = True Then

					}
					else
					{
						MessageBox.Show("Document Id Is Blank.  Can NOT Move Document", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If strDocumentId <> "" And strDocumentId <> "0" Then

				} // If strUserId = "dcr" Then

				rstRec2 = null;
				rstRec1 = null;
				fso = null;
			}
			catch
			{

				modAdminCommon.Report_Error("lblSubDocumentId_Click_Error: ");
			}

		} // lblSubDocumentId_Click

		private void lblSubInsContact_Click(Object eventSender, EventArgs eventArgs)
		{
			//If MsgBox("Reload Contact ComboBox?", vbYesNo) = vbYes Then
			lblSubInsContact.Text = "Loading..";
			lblSubInsContact.Enabled = false;
			Application.DoEvents();
			Fill_Subscription_Install_Contact_Combo_Box(modSubscription.Entered_Company_ID, false);
			lblSubInsContact.Enabled = true;
			lblSubInsContact.Text = "Contact";
			Application.DoEvents();
			//End If
		}

		private void lblSubInsViewEvoMobileLogs_Click(Object eventSender, EventArgs eventArgs)
		{

			string strWebSite = "";
			string strCompId = "";
			string strSubId = "";
			string strLogin = "";
			string strCellNbr = "";
			string strSeqNbr = "";


			if (lblSubInsViewEvoMobileLogs.Enabled)
			{
				ErrorHandlingHelper.ResumeNext(

					() => {lblSubInsViewEvoMobileLogs.Enabled = false;}, 
					() => {Application.DoEvents();}, 

					() => {strCompId = modSubscription.Entered_Company_ID.ToString();}, 
					() => {strSubId = txt_sub_id.Text;}, 
					() => {strLogin = txtLoginName.Text;}, 
					() => {strCellNbr = txtCellNumber.Text;}, 
					() => {grd_Installations.CurrentColumnIndex = 0;}, 
					() => {strSeqNbr = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();});

				if ((strCompId != "") && (strCompId != "0"))
				{

					if ((strSubId != "") && (strSubId != "0"))
					{

						if ((strSeqNbr != "") && (strLogin != ""))
						{
							ErrorHandlingHelper.ResumeNext(

								() => {strWebSite = $"{modAdminCommon.gbl_WebSite}help/listmobilesubinstalllog.asp?CompId={strCompId}" +
									                   $"&SubId={strSubId}" +
									                   $"&Login={strLogin}" +
									                   $"&SeqNbr={strSeqNbr}";}, 


								() => {modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strWebSite);});

						}
						else
						{
							try
							{
								MessageBox.Show("Invalid SeqNbr", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							catch
							{
							}
						} // If (strSeqNbr <> "") And (strLogin <> "") Then

					}
					else
					{
						try
						{
							MessageBox.Show("Invalid SubId", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						catch
						{
						}
					} // If (strSubId <> "") And (strSubId <> "0") Then

				}
				else
				{
					try
					{
						MessageBox.Show("Invalid CompId", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					catch
					{
					}
				}
				try
				{ // If (strCompId <> "") And (strCompId <> "0") Then

					lblSubInsViewEvoMobileLogs.Enabled = true;
				}
				catch
				{
				}

			} // If lblSubInsViewEvoMobileLogs.Enabled = True Then

		}

		private void lblSubInsViewSMSTextMsgsReceived_Click(Object eventSender, EventArgs eventArgs)
		{

			string strWebSite = "";
			string strCompId = "";
			string strSubId = "";
			string strLogin = "";
			string strCellNbr = "";
			string strSeqNbr = "";


			if (lblSubInsViewSMSTextMsgsReceived.Enabled)
			{
				ErrorHandlingHelper.ResumeNext(

					() => {lblSubInsViewSMSTextMsgsReceived.Enabled = false;}, 
					() => {Application.DoEvents();}, 

					() => {strCompId = modSubscription.Entered_Company_ID.ToString();}, 
					() => {strSubId = txt_sub_id.Text;}, 
					() => {strLogin = txtLoginName.Text;}, 
					() => {strCellNbr = txtCellNumber.Text;}, 
					() => {grd_Installations.CurrentColumnIndex = 0;}, 
					() => {strSeqNbr = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();});

				if ((strCompId != "") && (strCompId != "0"))
				{

					if ((strSubId != "") && (strSubId != "0"))
					{

						if ((strSeqNbr != "") && (strLogin != ""))
						{
							ErrorHandlingHelper.ResumeNext(

								() => {strWebSite = $"{modAdminCommon.gbl_WebSite}help/listsmstextmessagesreceived.asp?CellNbr={strCellNbr}";}, 

								() => {modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strWebSite);});

						}
						else
						{
							try
							{
								MessageBox.Show("Invalid SeqNbr", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							catch
							{
							}
						} // If (strSeqNbr <> "") And (strLogin <> "") Then

					}
					else
					{
						try
						{
							MessageBox.Show("Invalid SubId", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						catch
						{
						}
					} // If (strSubId <> "") And (strSubId <> "0") Then

				}
				else
				{
					try
					{
						MessageBox.Show("Invalid CompId", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					catch
					{
					}
				}
				try
				{ // If (strCompId <> "") And (strCompId <> "0") Then

					lblSubInsViewSMSTextMsgsReceived.Enabled = true;
				}
				catch
				{
				}

			} // If lblSubInsViewSMSTextMsgsReceived.Enabled = True Then

		}

		private void lblSubInsViewSMSTextMsgsSent_Click(Object eventSender, EventArgs eventArgs)
		{

			string strWebSite = "";
			string strCompId = "";
			string strSubId = "";
			string strLogin = "";
			string strCellNbr = "";
			string strSeqNbr = "";


			if (lblSubInsViewSMSTextMsgsSent.Enabled)
			{
				ErrorHandlingHelper.ResumeNext(

					() => {lblSubInsViewSMSTextMsgsSent.Enabled = false;}, 
					() => {Application.DoEvents();}, 

					() => {strCompId = modSubscription.Entered_Company_ID.ToString();}, 
					() => {strSubId = txt_sub_id.Text;}, 
					() => {strLogin = txtLoginName.Text;}, 
					() => {strCellNbr = txtCellNumber.Text;}, 
					() => {grd_Installations.CurrentColumnIndex = 0;}, 
					() => {strSeqNbr = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();});

				if ((strCompId != "") && (strCompId != "0"))
				{

					if ((strSubId != "") && (strSubId != "0"))
					{

						if ((strSeqNbr != "") && (strLogin != ""))
						{
							ErrorHandlingHelper.ResumeNext(

								() => {strWebSite = $"{modAdminCommon.gbl_WebSite}help/listsmstextmessagessent.asp?CellNbr={strCellNbr}";}, 

									//-----------------------------------------------
									// 11/05/2013 - By David D. Cruger
									// This routine will use the correct browser

								() => {modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strWebSite);});

						}
						else
						{
							try
							{
								MessageBox.Show("Invalid SeqNbr", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							catch
							{
							}
						} // If (strSeqNbr <> "") And (strLogin <> "") Then

					}
					else
					{
						try
						{
							MessageBox.Show("Invalid SubId", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						catch
						{
						}
					} // If (strSubId <> "") And (strSubId <> "0") Then

				}
				else
				{
					try
					{
						MessageBox.Show("Invalid CompId", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					catch
					{
					}
				}
				try
				{ // If (strCompId <> "") And (strCompId <> "0") Then

					lblSubInsViewSMSTextMsgsSent.Enabled = true;
				}
				catch
				{
				}

			} // If lblSubInsViewSMSTextMsgsSent.Enabled = True Then

		} // lblSubInsViewSMSTextMsgsSent_Click

		private void lblSubLabel_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.lblSubLabel, eventSender);


			int lCompId = modSubscription.Entered_Company_ID;
			int lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));
			string strLogin = tmpLoginName;


			switch(Index)
			{
				case iSUBSCRIPTIONID :  // Subscription Id 
					 
					Load_Subscription_Information_From_Customer_Program(); 
					 
					break;
				case iCOPYLOGINS :  // Copy All Logins From Another SubId 
					 
					lblSubLabel[iCOPYLOGINS].Enabled = false; 
					modSubscription.Copy_Logins_From_Another_SubId(lCompId, lSubId); 
					Fill_Logins_Grid(); 
					lblSubLabel[iCOPYLOGINS].Enabled = true; 
					 
					break;
			} // Case Index

		} // lblSubLabel_DblClick

		private void lblSubLabel_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.lblSubLabel, eventSender);

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lSeqNbr = 0;
			string strLastAccessDate = "";
			int lRow = 0;
			int lCol = 0;

			int lCompId = modSubscription.Entered_Company_ID;
			int lSubId = Convert.ToInt32(Double.Parse(txt_sub_id.Text));
			string strLogin = tmpLoginName;


			switch(Index)
			{
				case iEVOLASTAPPNAME :  // Evo Last App Name 
					 
					// This Routine Will Attemp to Find the last AppName the 
					// Use Logged In Under for Evolution 
					 
					if (modSubscription.OpenRemoteDatabase())
					{

						grd_Installations.CurrentColumnIndex = 0;
						lSeqNbr = Convert.ToInt32(Double.Parse(grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString()));

						lRow = grd_Installations.CurrentRowIndex;
						lCol = 4;

						strLastAccessDate = Convert.ToString(grd_Installations[lRow, lCol].Value);

						if (Information.IsDate(strLastAccessDate))
						{
							System.DateTime TempDate2 = DateTime.FromOADate(0);
							strLastAccessDate = (DateTime.TryParse(strLastAccessDate, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : strLastAccessDate;
						}
						else
						{
							strLastAccessDate = "";
						}

						strQuery1 = "SELECT TOP 1 subislog_app_name As AppName  FROM Subscription_Install_Log WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}WHERE (subislog_subid = {lSubId.ToString()}) AND (subislog_login = '{strLogin}') ";
						strQuery1 = $"{strQuery1}AND (subislog_seq_no = {lSeqNbr.ToString()}) AND (subislog_app_name IS NOT NULL) ";
						strQuery1 = $"{strQuery1}AND (subislog_app_name <> '') ORDER BY subislog_id DESC ";

						rstRec1.Open(strQuery1, REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{
							lblSubLabel[iEVOLASTAPPNAME].Text = ($"{Convert.ToString(rstRec1["AppName"])} ").Trim();
						}
						else
						{
							lblSubLabel[iEVOLASTAPPNAME].Text = "None Found";
						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

						rstRec1.Close();

						modSubscription.CloseRemoteDatabase();

					}  // If OpenRemoteDatabase() = True Then 
					 
					break;
				case iDOCUMENTDATE :  // Document Date 
					 
					lblSubLabel[iCALENDARDOCUMENTDATE].Text = "Calendar - Document Date"; 
					 
					calSubDocumentDate.Visible = true; 
					calSubDocumentDate.Enabled = true; 
					calSubDocumentDate.BringToFront(); 
					 
					calSubExpirationDate.Visible = false; 
					 
					break;
				case iEXPIRATIONDATE :  // Expiration Date 
					 
					lblSubLabel[iCALENDARDOCUMENTDATE].Text = "Calendar - Expiration Date"; 
					 
					calSubExpirationDate.Visible = true; 
					calSubExpirationDate.Enabled = true; 
					calSubExpirationDate.BringToFront(); 
					 
					calSubDocumentDate.Visible = false; 
					 
					break;
				case iVIEWMPMUSERS : 
					 
					mnuMPMManagement_Click(mnuMPMManagement, new EventArgs()); 
					 
					break;
				case iSTOPLOADING :  // Stop Loading Subscription Notes 
					 
					lblSubLabel[iSTOPLOADING].Visible = false; 
					lblSubLabel[iSTOPLOADING].Enabled = false; 
					 
					break;
			} // Case Index

			rstRec1 = null;

		} // lblSubLabel_Click

		private void Set_Subscription_Start_Date_By_Recordset(ADORecordSetHelper rstRec1)
		{

			string strService = "";
			string strStartDate = "";

			if (rstRec1 != null)
			{

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					rstRec1.Filter = "";
					rstRec1.MoveFirst();

					strStartDate = "";

					do 
					{ // Loop Until rstRec1.EOF = True Or strStartDate <> ""

						strService = ($"{Convert.ToString(rstRec1["cstmain_service"])} ").Trim();

						cbo_Service.Enabled = false;
						int tempForEndVar = cbo_Service.Items.Count - 1;
						for (int iCnt1 = 0; iCnt1 <= tempForEndVar; iCnt1++)
						{

							if (cbo_Service.GetListItem(iCnt1) == strService)
							{
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(rstRec1["cstservicerec_software"]))
								{
									if (Information.IsDate(rstRec1["cstservicerec_software"]))
									{
										strStartDate = ($"{Convert.ToString(rstRec1["cstservicerec_software"])} ").Trim();
										txt_sub_start_date.Text = strStartDate;
									}
								}
							}

						}

						cbo_Service.Enabled = true;

						rstRec1.MoveNext();

					}
					while(!(rstRec1.EOF || strStartDate != ""));

					rstRec1.MoveFirst();

					if (strStartDate == "")
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["cstservice_installed_date"]))
						{
							txt_sub_start_date.Text = Convert.ToDateTime(rstRec1["cstservice_installed_date"]).ToString("MM/dd/yyyy");
						}
					}

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

			} // If (rstRec1 Is Nothing) = False Then

		} // Set_Subscription_Start_Date_By_Recordset

		private void Set_Subscription_Service_By_Recordset(ADORecordSetHelper rstRec1)
		{

			int iCnt1 = 0;
			string strService = "";

			if (rstRec1 != null)
			{

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					rstRec1.Filter = "";
					rstRec1.MoveFirst();

					strService = ($"{Convert.ToString(rstRec1["cstmain_service"])} ").Trim();

					cbo_Service.Enabled = false;
					modCommon.SetComboText(cbo_Service, strService);
					cbo_Service.Enabled = true;

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

			} // If (rstRec1 Is Nothing) = False Then

		} // Set_Subscription_Service_By_Recordset

		private void Set_Subscription_Updates_By_Recordset(ADORecordSetHelper rstRec1)
		{

			int iCnt1 = 0;
			string strDatabase = "";
			string strFreq = "";

			if (rstRec1 != null)
			{

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					rstRec1.Filter = "";
					rstRec1.MoveFirst();

					strFreq = ($"{Convert.ToString(rstRec1["cstservicerec_frequency"])} ").Trim();
					strDatabase = ($"{Convert.ToString(rstRec1["serv_database_name"])} ").Trim();

					cmbFrequency.Enabled = false;
					modCommon.SetComboText(cmbFrequency, strFreq);
					cmbFrequency.Enabled = true;

					rstRec1.MoveFirst();

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

			} // If (rstRec1 Is Nothing) = False Then

		} // Set_Subscription_Updates_By_Recordset

		private void Set_Subscription_Tier_Level_By_Recordset(ADORecordSetHelper rstRec1)
		{

			string strTLevel = "";
			int iCnt1 = 0;

			if (rstRec1 != null)
			{

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					rstRec1.Filter = "";
					rstRec1.MoveFirst();

					strTLevel = ($"{Convert.ToString(rstRec1["cstmain_service"])} ").Trim().Substring(Math.Min(2, ($"{Convert.ToString(rstRec1["cstmain_service"])} ").Trim().Length), Math.Min(1, Math.Max(0, ($"{Convert.ToString(rstRec1["cstmain_service"])} ").Trim().Length - 2)));

					if (strTLevel != "1" && strTLevel != "2" && strTLevel != "3")
					{
						strTLevel = "3";
					}
					strTLevel = $"Tier {strTLevel}";

					cmbTierLevel.Enabled = false;
					modCommon.SetComboText(cmbTierLevel, strTLevel);
					cmbTierLevel.Enabled = true;

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

			} // If (rstRec1 Is Nothing) = False Then

		} // Set_Subscription_Tier_Level_By_Recordset

		private void Set_Subscription_Product_Codes_By_Recordset(ADORecordSetHelper rstRec1)
		{

			string strFlag1 = "";
			string strFlag2 = "";
			string strFlag3 = "";
			string strFlag4 = "";

			string strService = "";
			string strName = "";

			if (rstRec1 != null)
			{

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					rstRec1.Filter = "";
					rstRec1.MoveFirst();

					do 
					{ // Loop Until rstRec1.EOF = True

						strService = ($"{Convert.ToString(rstRec1["cstservicerec_service"])} ").Trim();
						strName = ($"{Convert.ToString(rstRec1["serv_name"])} ").Trim().ToUpper();

						if (strName.IndexOf("EVOLUTION JETNET") >= 0)
						{
							chkProductType[modSubscription.ProductBusinessAC].CheckState = CheckState.Checked;
						}

						if (strName.IndexOf("AERODEX") >= 0)
						{
							chkProductType[modSubscription.ProductAerodex].CheckState = CheckState.Checked;
						}

						if (strName.IndexOf("EVOLUTION AERODEX TIER") >= 0)
						{
							chkProductType[modSubscription.ProductBusinessAC].CheckState = CheckState.Checked;
						}

						if (strName.IndexOf("COMMERCIAL") >= 0)
						{
							chkProductType[modSubscription.ProductCommercial].CheckState = CheckState.Checked;
						}

						if (strName.IndexOf("HELICOPTERS") >= 0)
						{
							chkProductType[modSubscription.ProductHelicopters].CheckState = CheckState.Checked;
						}

						if (strName.IndexOf("SALE PRICE INDEX") >= 0)
						{
							chkProductType[modSubscription.ProductSPI].CheckState = CheckState.Checked;
						}

						if (strName.IndexOf("STAR REPORTS") >= 0)
						{
							chkProductType[modSubscription.ProductStarReports].CheckState = CheckState.Checked;
						}

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

					rstRec1.MoveFirst();

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

			} // If (rstRec1 Is Nothing) = False Then

		} // Set_Subscription_Product_Codes_By_Recordset

		private void Load_Subscription_Information_From_Customer_Program()
		{

			DbConnection cntCustConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strSubId = "";
			int lSubId = 0;

			string strContactAmt = "";
			string strMaxExport = "";
			string strCallbackDate = "";
			string strCallbackStatus = "";
			string strComments = "";
			string strNbrInstalls = "";
			string strNbrSPIInstalls = "";
			string strNbrMPMInstalls = "";
			CheckState iShareByCompId = CheckState.Unchecked;
			CheckState iShareByParentId = CheckState.Unchecked;
			bool bExisting = false;

			try
			{

				lSubId = 0;
				strSubId = "0";
				bExisting = true;

				if (MessageBox.Show("Load Subscription Information From Customer Program", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{

					strSubId = txt_sub_id.Text.Trim();

					strContactAmt = txt_SubContractAmount.Text;
					strMaxExport = txtSubMaxExport.Text;
					strCallbackDate = txtCallBackDate.Text;
					strCallbackStatus = cboCallBackStatus.Text;
					strComments = txtCallbackComments.Text;
					strNbrInstalls = txt_SubNbrOfInstalls[iNbrInstalls].Text;
					strNbrSPIInstalls = txt_SubNbrOfInstalls[iNBRVALUEINSTALLS].Text;
					strNbrMPMInstalls = txt_SubNbrOfInstalls[iNBRMPMINSTALLS].Text;
					iShareByCompId = chkProductType[modSubscription.ShareByCompId].CheckState;
					iShareByParentId = chkProductType[modSubscription.ShareByParentId].CheckState;

					if (strSubId == "" || strSubId == "0")
					{

						strSubId = InputBoxHelper.InputBox("Please Enter SubId");

						if (strSubId != "" && strSubId != "0")
						{

							if (Information.IsNumeric(strSubId))
							{

								lSubId = Convert.ToInt32(Double.Parse(strSubId));

								strSubId = modCommon.DLookUp("sub_id", "Subscription", $"(sub_id = {strSubId}) ");

								if (strSubId != "")
								{
									MessageBox.Show($"SubId: {strSubId} Already Exists", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									lSubId = 0;
									strSubId = "0";
								}
								else
								{
									strSubId = lSubId.ToString();
									bExisting = false;
								} // If lSubId > 0 Then

							}
							else
							{
								MessageBox.Show($"SubId Entered Is Non-Numeric [{strSubId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								lSubId = 0;
								strSubId = "0";
							} // If IsNumeric(strSubId) = True Then

						} // If strSubId <> "" And strSubId <> "0" Then

					}
					else
					{
						bExisting = true;
					} // If strSubId = "" Or strSubId = "0" Then

					//-----------------------------------------------
					// Check To See If We Need To Continue

					if (strSubId != "" && strSubId != "0")
					{

						modAdminCommon.Record_Event("Subscription Updated", $"Subscription Record Updated From Customer Program = SubId: [{strSubId}]", 0, 0, modSubscription.Entered_Company_ID);

						if (modCommon.OpenCustomerSQLDatabase(ref cntCustConn))
						{

							strQuery1 = "SELECT * FROM Customer_Main WITH (NOLOCK)  INNER JOIN Customer_Service WITH (NOLOCK) ON cstservice_techid_value  = cstmain_techid_value ";
							strQuery1 = $"{strQuery1}INNER JOIN Customer_Service_Record WITH (NOLOCK) ON cstservicerec_techid_value = cstservice_techid_value ";
							strQuery1 = $"{strQuery1}INNER JOIN Customer_Service_Category WITH (NOLOCK) ON serv_code = cstservicerec_service ";
							strQuery1 = $"{strQuery1}WHERE (cstmain_techid_value = {strSubId}) ";
							strQuery1 = $"{strQuery1}AND (cstmain_tcode NOT LIKE 'X%') AND (cstmain_tcode NOT LIKE 'Z%') ";
							strQuery1 = $"{strQuery1}AND (cstmain_status <> 'CX') AND (cstmain_status <> 'IN') ";
							strQuery1 = $"{strQuery1}AND (cstservice_cancelled_date IS NULL OR cstservice_cancelled_date < '1/1/1960') ";
							strQuery1 = $"{strQuery1}AND (cstservicerec_active = 'Y') AND (serv_active_flag = 'Y') ";

							strQuery1 = $"{strQuery1}AND (cstservicerec_version LIKE '%EVOL%') ";

							rstRec1.Open(strQuery1, cntCustConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							if (!rstRec1.BOF && !rstRec1.EOF)
							{


								New_Subscription(); // Clears All Values

								if (bExisting)
								{
									txt_SubContractAmount.Text = strContactAmt;
									txtSubMaxExport.Text = strMaxExport;
									txtCallBackDate.Text = strCallbackDate;
									modCommon.SetComboText(cboCallBackStatus, strCallbackStatus);
									txtCallbackComments.Text = strComments;
									txt_SubNbrOfInstalls[iNbrInstalls].Text = strNbrInstalls;
									txt_SubNbrOfInstalls[iNBRVALUEINSTALLS].Text = strNbrSPIInstalls;
									txt_SubNbrOfInstalls[iNBRMPMINSTALLS].Text = strNbrMPMInstalls;
									chkProductType[modSubscription.ShareByCompId].CheckState = iShareByCompId;
									chkProductType[modSubscription.ShareByParentId].CheckState = iShareByParentId;
								}

								txt_sub_id.Text = strSubId;

								Set_Subscription_Start_Date_By_Recordset(rstRec1);

								Set_Subscription_Service_By_Recordset(rstRec1);

								Set_Subscription_Updates_By_Recordset(rstRec1);

								Set_Subscription_Tier_Level_By_Recordset(rstRec1);

								Set_Subscription_Product_Codes_By_Recordset(rstRec1);

							}
							else
							{
								MessageBox.Show($"No Active Evolution Service Records For The SubId: [{strSubId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If rstRec1.BOF = False And rstRec1.EOF = False Then

							rstRec1.Close();

							UpgradeHelpers.DB.TransactionManager.DeEnlist(cntCustConn);
							cntCustConn.Close();

						} // If OpenCustomerSQLDatabase(cntCustConn) = True Then

					} // If strSubId <> "" And strSubId <> "0" Then

				} // If MsgBox("Load Subscription Information From Customer Program", vbYesNo + vbApplicationModal) = vbYes Then

				rstRec1 = null;
				cntCustConn = null;
			}
			catch
			{

				modAdminCommon.Report_Error("Load_Subscription_Information_From_Customer_Program_Error: ");
			}

		} // Load_Subscription_Information_From_Customer_Program

		private void lblSubUpdateNbrInstalls_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); // Number Of Sub For This CompId
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper(); // Number Of Installs For This SubId

			ADORecordSetHelper rstRec3 = new ADORecordSetHelper(); // Number Of Logins For Each SubId
			ADORecordSetHelper rstRec4 = new ADORecordSetHelper(); // Number Of Installs For This Login

			string strQuery1 = "";
			string strQuery2 = "";
			string strQuery3 = "";
			string strQuery4 = "";

			string strCompId = "";
			string strUserId = "";
			string strCurrSubId = "";
			string strSubId = "";
			string strLogin = "";
			string strService = "";
			string strService2 = "";
			string strTemp = "";

			int lTotCnt = 0;

			try
			{

				if (lblSubUpdateNbrInstalls.Enabled)
				{

					strService = ($"{cbo_Service.Text} ").Trim().ToUpper();
					if (!strService.StartsWith("CRM", StringComparison.Ordinal) && !strService.StartsWith("WBSV", StringComparison.Ordinal))
					{

						strCompId = modSubscription.Entered_Company_ID.ToString();
						strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();
						strCurrSubId = ($"{txt_sub_id.Text} ").Trim();

						strTemp = $"Auto Update Nbr Of Installs CompId: {strCompId} SubId: {strCurrSubId} User Id: {strUserId}";
						modAdminCommon.Record_Event("Auto Update Nbr Of Installs", strTemp, 0, 0, modSubscription.Entered_Company_ID);

						lblSubUpdateNbrInstalls.Enabled = false;
						Application.DoEvents();

						if ((strCompId != "") && (strCompId != "0"))
						{

							//--------------------------------------------
							// Get All Active SubId's For This CompId
							//--------------------------------------------
							strQuery1 = "SELECT sub_id, sub_comp_id, sub_nbr_of_installs, sub_upd_date, sub_serv_code ";
							strQuery1 = $"{strQuery1}FROM Subscription WHERE (sub_comp_id = {strCompId}) ";
							strQuery1 = $"{strQuery1}AND (sub_end_date IS NULL OR sub_end_date > '{DateTime.Now.ToString("MM/dd/yyyy")}') ";
							strQuery1 = $"{strQuery1}AND (sub_serv_code NOT LIKE 'CRM%') AND (sub_serv_code NOT LIKE 'WBSV%') ";
							strQuery1 = $"{strQuery1}AND (sub_id = {strCurrSubId}) ";

							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

							if ((!rstRec1.BOF) && (!rstRec1.EOF))
							{

								do 
								{ // Loop Until rstRec1.EOF = True

									strSubId = Convert.ToString(rstRec1["sub_id"]);
									strService2 = ($"{Convert.ToString(rstRec1["sub_serv_code"])} ").Trim().ToUpper();

									if (!strService2.StartsWith("CRM", StringComparison.Ordinal) && !strService2.StartsWith("WBSV", StringComparison.Ordinal))
									{

										strQuery2 = "SELECT Count(subins_sub_id) As TotCnt FROM Subscription_Install WITH (NOLOCK) ";
										strQuery2 = $"{strQuery2}INNER JOIN Subscription_Login WITH (NOLOCK) ON sublogin_sub_id = subins_sub_id AND sublogin_login = subins_login ";
										strQuery2 = $"{strQuery2}WHERE (subins_sub_id = {strSubId}) AND (subins_active_flag = 'Y') ";
										strQuery2 = $"{strQuery2}AND (sublogin_active_flag = 'Y') ";

										rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

										if ((!rstRec2.BOF) && (!rstRec2.EOF))
										{
											rstRec1["sub_nbr_of_installs"] = rstRec2["TotCnt"];
											rstRec1["sub_upd_date"] = DateTime.Now.ToString("MM/dd/yyyy");
											rstRec1.Update();
										} // If (rstRec2.BOF = False) And (rstRec2.EOF = False) Then

										rstRec2.Close();


										strQuery3 = "SELECT sublogin_sub_id, sublogin_login, sublogin_nbr_of_installs, sublogin_upd_date ";
										strQuery3 = $"{strQuery3}FROM Subscription_Login WHERE (sublogin_sub_id = {strSubId}) ";
										strQuery3 = $"{strQuery3}AND (sublogin_active_flag = 'Y') ";

										rstRec3.Open(strQuery3, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

										if ((!rstRec3.BOF) && (!rstRec3.EOF))
										{

											do 
											{ // Loop Until rstRec3.EOF = True

												strLogin = ($"{Convert.ToString(rstRec3["sublogin_login"])} ").Trim();

												if (strLogin != "")
												{


													strQuery4 = "SELECT Count(subins_sub_id) As TotCnt FROM Subscription_Install WITH (NOLOCK) ";
													strQuery4 = $"{strQuery4}WHERE (subins_sub_id = {strSubId})";
													strQuery4 = $"{strQuery4}AND (subins_login = '{strLogin}') AND (subins_active_flag = 'Y') ";

													rstRec4.Open(strQuery4, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

													if ((!rstRec4.BOF) && (!rstRec4.EOF))
													{
														rstRec3["sublogin_nbr_of_installs"] = rstRec4["TotCnt"];
														rstRec3["sublogin_upd_date"] = DateTime.Now.ToString("MM/dd/yyyy");
														rstRec3.Update();
													} // If (rstRec4.BOF = False) And (rstRec4.EOF = False) Then

													rstRec4.Close();

												} // If (strLogin <> "") Then

												rstRec3.MoveNext();

											}
											while(!rstRec3.EOF);

										} // If (rstRec3.BOF = False) And (rstRec3.EOF = False) Then

										rstRec3.Close();

									} // If left(strService2, 3) <> "CRM" And left(strService2, 4) <> "WBSV" Then

									rstRec1.MoveNext();

								}
								while(!rstRec1.EOF);

								UpdateActionDate();

								grd_Subscriptions_Click(grd_Subscriptions, new EventArgs()); // ReFresh Everything

							} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

							rstRec1.Close();

							strAddChgHasHappened = ""; // Update Has Happened

						}
						else
						{
							MessageBox.Show("CompId Is Blank/Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If (strCompId <> "") And (strCompId <> "0") Then

						lblSubUpdateNbrInstalls.Enabled = true;

					}
					else
					{
						MessageBox.Show("Automatic Updating Installs on a CRM Or WBSV Serivce is NOT Allowed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If left(strService, 3) <> "CRM" And left(strService, 4) <> "WBSV" Then

				} // If lblSubUpdateNbrInstalls.Enabled = True Then

				rstRec4 = null;
				rstRec3 = null;
				rstRec2 = null;
				rstRec1 = null;
			}
			catch
			{

				modAdminCommon.Report_Error("lblSubUpdateNbrInstalls_Click_Error: ");

				lblSubUpdateNbrInstalls.Enabled = true;
			}

		} // lblSubUpdateNbrInstalls_Click

		private void lblSubInsViewWebReport_Click(Object eventSender, EventArgs eventArgs)
		{

			string strWebSite = "";
			string strCompId = "";
			string strSubId = "";
			string strLogin = "";
			string strSeqNbr = "";


			if (lblSubInsViewWebReport.Enabled)
			{
				ErrorHandlingHelper.ResumeNext(

					() => {lblSubInsViewWebReport.Enabled = false;}, 
					() => {Application.DoEvents();}, 

					() => {strCompId = modSubscription.Entered_Company_ID.ToString();}, 
					() => {strSubId = txt_sub_id.Text;}, 
					() => {strLogin = txtLoginName.Text;}, 
					() => {grd_Installations.CurrentColumnIndex = 0;}, 
					() => {strSeqNbr = grd_Installations[grd_Installations.CurrentRowIndex, grd_Installations.CurrentColumnIndex].FormattedValue.ToString();});

				if ((strCompId != "") && (strCompId != "0"))
				{

					if ((strSubId != "") && (strSubId != "0"))
					{

						if ((strSeqNbr != "") && (strLogin != ""))
						{
							ErrorHandlingHelper.ResumeNext(

								() => {strWebSite = $"{modAdminCommon.gbl_WebSite}/help/ListSubscriptionInstallSavedSearchCriteria.asp" +
									                   $"?CompId={strCompId}" +
									                   $"&SubId={strSubId}" +
									                   $"&Login={strLogin}" +
									                   $"&SeqNbr={strSeqNbr}";}, 


								() => {modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strWebSite);});

						}
						else
						{
							try
							{
								MessageBox.Show("Invalid SeqNbr", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							catch
							{
							}
						} // If (strSeqNbr <> "") And (strLogin <> "") Then

					}
					else
					{
						try
						{
							MessageBox.Show("Invalid SubId", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						catch
						{
						}
					} // If (strSubId <> "") And (strSubId <> "0") Then

				}
				else
				{
					try
					{
						MessageBox.Show("Invalid CompId", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					catch
					{
					}
				}
				try
				{ // If (strCompId <> "") And (strCompId <> "0") Then

					lblSubInsViewWebReport.Enabled = true;
				}
				catch
				{
				}

			} // If lblSubInsViewWebReport.Enabled = True Then

		} // End lblSubInsViewWebReport_Click

		private void lblWebReportsURL_Click(Object eventSender, EventArgs eventArgs)
		{

			if (Convert.ToString(lblWebReportsURL.Tag) != "" && Convert.ToString(lblWebReportsURL.Tag) != "about:blank")
			{

				modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, Convert.ToString(lblWebReportsURL.Tag));

			}

		} // lblWebReportsURL_Click

		public void mnuMPMManagement_Click(Object eventSender, EventArgs eventArgs)
		{


			string strCompId = "";
			string strSubId = "";
			string strService = "";
			string strCRMRegId = "";

			int lRow1 = grd_Subscriptions.CurrentRowIndex;
			int lCol1 = grd_Subscriptions.CurrentColumnIndex;

			if (lRow1 > 0)
			{

				strCompId = modSubscription.Entered_Company_ID.ToString();
				strSubId = Convert.ToString(grd_Subscriptions[lRow1, 0].Value);
				strService = Convert.ToString(grd_Subscriptions[lRow1, 1].Value);
				strCRMRegId = txtCRMRegId.Text;

				if (strService == "CRM")
				{

					MessageBox.Show($"Run MPM Management Page For {strService} Service{Environment.NewLine}{Environment.NewLine}" +
					                $"CompId: [{strCompId}]{Environment.NewLine}" +
					                $"MPMRegID: [{strCRMRegId}]{Environment.NewLine}" +
					                $"SubId: [{strSubId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

					frm_WebReport.DefInstance.MPM_ID = Convert.ToInt32(Double.Parse(strCRMRegId));
					if (frm_WebReport.DefInstance.MPM_ID > 0)
					{
						frm_Subscription.DefInstance.Hide();
						frm_WebReport.DefInstance.WhichReport = "MPM Management";
						frm_WebReport.DefInstance.Show();
						frm_Subscription.DefInstance.Show();
					}
					else
					{
						MessageBox.Show("Need to Connect CRM ID", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
					}

				} // If strService = "CRM" Then

			} // If lRow1 > 0 Then

		} // mnuMPMManagement_Click

		private void SSTab_Subscription_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			if (SSTabHelper.GetSelectedIndex(SSTab_Subscription) != 2)
			{
				cmdSubDocumentNew_Click(cmdSubDocumentNew, new EventArgs());
			}


			switch(SSTabHelper.GetSelectedIndex(SSTab_Subscription))
			{
				case 1 :  // Subscription Notes 
					 
					if (($"{Convert.ToString(modAdminCommon.snp_User["user_subscription_contract_amount"])} ").Trim() == "Y")
					{
						Load_Subscription_Journal_Notes_Grid();
					}
					else
					{
						SSTabHelper.SetSelectedIndex(SSTab_Subscription, 0); // Do Not Show This Tab
						MessageBox.Show("User Does NOT Have Access To This Tab", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}  // If Trim(snp_User!user_subscription_contract_amount & " ") = "Y" Then 
					 
					break;
				case 2 :  // Contracts 
					 
					if (($"{Convert.ToString(modAdminCommon.snp_User["user_subscription_contract_amount"])} ").Trim() == "Y")
					{

						frmSubDocumentControl.Enabled = true;
						cmdSubDocumentSave.Enabled = true;
						cmdSubDocumentNew_Click(cmdSubDocumentNew, new EventArgs());

						// 1/2/2008 - By David D. Cruger
						// Moved out of Form_Load and put on Tab Control
						Load_Subscription_Journal_Notes_Grid();
						Load_Subscription_Documents_Grid();

					}
					else
					{
						SSTabHelper.SetSelectedIndex(SSTab_Subscription, 0); // Do Not Show This Tab
						MessageBox.Show("User Does NOT Have Access To This Tab", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}  // If Trim(snp_User!user_subscription_contract_amount & " ") = "Y" Then 
					 
					break;
				case 3 :  // Execution Forms 
					 
					if (($"{Convert.ToString(modAdminCommon.snp_User["user_subscription_contract_amount"])} ").Trim() == "Y")
					{

						Load_Execution_Form_Grid();

					}
					else
					{
						SSTabHelper.SetSelectedIndex(SSTab_Subscription, 0); // Do Not Show This Tab
						MessageBox.Show("User Does NOT Have Access To This Tab", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}  // If Trim(snp_User!user_subscription_contract_amount & " ") = "Y" Then 
					 
					break;
				case 4 :  // Service Interruption 
					 
					if (($"{Convert.ToString(modAdminCommon.snp_User["user_subscription_contract_amount"])} ").Trim() == "Y")
					{

						lblSubSIViewOnly.Visible = false;
						cmdSubSIDocView.Enabled = false;
						cmdSubSIDocView.Tag = "";
						wbSubBrowser1[1].Navigate(new Uri("about:blank"));

						Load_Service_Interruption_Grid();

					}
					else
					{
						SSTabHelper.SetSelectedIndex(SSTab_Subscription, 0); // Do Not Show This Tab
						MessageBox.Show("User Does NOT Have Access To This Tab", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}  // If Trim(snp_User!user_subscription_contract_amount & " ") = "Y" Then 
					 
					break;
				case 5 :  // Web Reports 
					 
					strQuery1 = "SELECT swr_id, swr_type, swr_desc FROM Subscription_WebReports WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}WHERE (swr_active_flag = 'Y') ORDER BY swr_id "; 
					 
					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly); 
					 
					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						cboWebReports.Enabled = false;
						cboWebReports.Items.Clear();

						do 
						{

							cboWebReports.AddItem($"{($"{Convert.ToString(rstRec1["swr_type"])} ").Trim()} - {($"{Convert.ToString(rstRec1["swr_desc"])} ").Trim()}", Convert.ToInt32(rstRec1["swr_id"]));

							rstRec1.MoveNext();

						}
						while(!rstRec1.EOF);

						cboWebReports.SelectedIndex = 0;
						cboWebReports.Enabled = true;

						lblWebReportProcessing.Visible = false;
						lblWebReportsURL.Tag = "about:blank";
						wbSubBrowser1[2].Navigate(new Uri("about:blank"));

					}  // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then 
					 
					rstRec1.Close(); 
					 
					break;
				case 6 :  // CRM/Cloud Notes 
					 
					bAutoCreateCloudNotesFlag = false; 
					rbEvoLocalNotesOverrideCloudNotes.Checked = true; 
					txtPathToEvoLocalNotes.Text = "C:\\TEMP\\"; 
					txtTotalImportedFromLocalNotesToEvoCloudNotes.Text = "0"; 
					txtTotalRecordsInEvoLocalNotes.Text = "0"; 
					 
					rbEvoLocalNotesOverrideCloudNotes.Text = "Overwrite All Cloud Notes"; 
					rbEvoLocalNotesAppendCloudNotes.Text = "Append Cloud Notes"; 
					 
					txtTotalImportedFromSSNToCloudNotes.Text = "0"; 
					txtTotalRecordsInSSNotes.Text = "0"; 
					 
					txtImportCloudNotesFromDate.Text = "mm/dd/ccyy"; 
					txtTotalImportedFromCloudNotesToSSNotes.Text = "0"; 
					txtTotalRecordsInCloudNotes.Text = "0"; 
					 
					if (chkServerSideNotes.CheckState == CheckState.Checked)
					{
						rbEvoLocalNotesOverrideCloudNotes.Text = "Overwrite All SSCN Notes";
						rbEvoLocalNotesAppendCloudNotes.Text = "Append SSCN Notes";
					} 
					 
					//Turn_On_Notes_Import_Panel 
					 
					break;
			} // Select Case SSTab_Subscription.Tab

			rstRec1 = null;

			SSTab_SubscriptionPreviousTab = SSTab_Subscription.SelectedIndex;
		} // SSTab_Subscription_Click

		private void txt_sub_password_Leave(Object eventSender, EventArgs eventArgs)
		{


			string strPassword = txt_sub_password.Text;
			string strService = cbo_Service.Text;

			strPassword = StringsHelper.Replace(strPassword, "'", "", 1, -1, CompareMethod.Binary); // Single Quote
			strPassword = StringsHelper.Replace(strPassword, "\"", "", 1, -1, CompareMethod.Binary); // Double Quote

			txt_sub_password.Text = strPassword;

		} // txt_sub_password_LostFocus

		private void txt_SubContractAmount_Leave(Object eventSender, EventArgs eventArgs)
		{


			if (txt_SubContractAmount.Text.Trim() != "" && txt_SubContractAmount.Text.Trim() != "0.0")
			{
				if (txt_sub_billed_amount.Text.Trim() != "" && txt_sub_billed_amount.Text.Trim() == "0.00")
				{
					txt_sub_billed_amount.Text = txt_SubContractAmount.Text;
				}
			}

		}

		private void txtLoginName_Leave(Object eventSender, EventArgs eventArgs)
		{


			string strLoginName = modCommon.LeaveOnlyAlphaAndNumeric(txtLoginName.Text);
			txtLoginName.Text = strLoginName;

		} // txtLoginName_LostFocus

		private void txtNbrDaysExpire_TextChanged(Object eventSender, EventArgs eventArgs)
		{

		}

		private void txtPathToEvoLocalNotes_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (txtPathToEvoLocalNotes.Text.Trim() != "")
			{
				if (txtPathToEvoLocalNotes.Text.Substring(Math.Max(txtPathToEvoLocalNotes.Text.Length - 1, 0)) != "\\")
				{
					txtPathToEvoLocalNotes.Text = $"{txtPathToEvoLocalNotes.Text}\\";
				}
			}

		}

		private void txtSubDocumentDate_Enter(Object eventSender, EventArgs eventArgs)
		{

			lblSubLabel[iCALENDARDOCUMENTDATE].Text = "Calendar - Document Date";

			calSubDocumentDate.Visible = true;
			calSubDocumentDate.Enabled = true;
			calSubDocumentDate.BringToFront();

			calSubExpirationDate.Visible = false;

		} // txtSubDocumentDate_GotFocus

		private void txtSubDocumentDate_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				if (KeyAscii == 32)
				{ // Space Bar

					calSubDocumentDate.SetDate(DateTime.Now);

					if (txtSubDocumentDate.Text == "")
					{
						txtSubDocumentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
						calSubDocumentDate.SetDate(DateTime.Parse(txtSubDocumentDate.Text));
					}
					else
					{
						txtSubDocumentDate.Text = "";
						calSubDocumentDate.SetDate(DateTime.Now);
					}

					KeyAscii = 0;

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

		} // txtSubDocumentDate_KeyPress

		private void txtSubDragDocument_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string strFromFileName = "";

			string strPath = modCommon.GetSpecialfolder(modCommon.CSIDLPERSONAL);

			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.InitDir was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.InitialDirectory = strPath;
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.DialogTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Title = "Attach Customer Contract Document";
			//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property mdi_ResearchAssistant.CommonDialog1.Flags was upgraded to mdi_ResearchAssistant.CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
			//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowReadOnly = false;
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Filter = "PDF Files|*.pdf";
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

					if (strFromFileName.ToLower().Substring(Math.Max(strFromFileName.ToLower().Length - 4, 0)) == ".pdf")
					{
						txtSubDragDocument.Tag = strFromFileName;
						txtSubDragDocument.Text = $"Drag Document Here{Environment.NewLine}{(new FileInfo(strFromFileName)).Name}";
					}
					else
					{
						MessageBox.Show($"Filename Does NOT have a .PDF extension.{Environment.NewLine}File MUST be a PDF!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If (Right(LCase(strFromFileName), 4) = ".pdf") Then

				}
				else
				{
					MessageBox.Show($"Unable To Find File{Environment.NewLine}{strFromFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If gfso.FileExists(strFromFileName) = True Then

			} // If mdi_ResearchAssistant.CommonDialog1.FileName <> "" Then

		} // txtSubDragDocument_DblClick

		private void txtSubExpirationDate_Enter(Object eventSender, EventArgs eventArgs)
		{

			lblSubLabel[iCALENDARDOCUMENTDATE].Text = "Calendar - Expiration Date";

			calSubExpirationDate.Visible = true;
			calSubExpirationDate.Enabled = true;
			calSubExpirationDate.BringToFront();

			calSubDocumentDate.Visible = false;

		} // txtSubExpirationDate_GotFocus

		private void txtSubExpirationDate_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				if (KeyAscii == 32)
				{ // Space Bar

					calSubExpirationDate.SetDate(DateTime.Now);

					if (txtSubExpirationDate.Text == "")
					{
						txtSubExpirationDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
						if (Information.IsDate(txtSubDocumentDate.Text))
						{
							txtSubExpirationDate.Text = DateTime.Parse(txtSubDocumentDate.Text).AddYears(1).ToString("MM/dd/yyyy");
							calSubExpirationDate.SetDate(DateTime.Parse(txtSubExpirationDate.Text));
						}
					}
					else
					{
						txtSubExpirationDate.Text = "";
						calSubExpirationDate.SetDate(DateTime.Now);
					}

					KeyAscii = 0;

					Set_Expiration_Date_Color();

				} // If KeyAscii = 32 Then ' Space Bar
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

		} // txtSubExpirationDate_KeyPress

		//UPGRADE_WARNING: (2050) TextBox Event txtSubDragDocument.OLEDragDrop was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void txtSubDragDocument_OLEDragDrop(DataObject Data, int Effect, int Button, int Shift, float X, float Y)
		{

			Object fso = new Object();
			string strFromFileName = "";
			string strToFileName = "";
			string strFileName = "";
			bool bContinue = false;
			string strToPath = "";

			try
			{

				//UPGRADE_ISSUE: (2064) DataObjectFiles property Files.Item was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//strFromFileName = Data.Files.Item(1); gap-note this line must be checked during Blazor stabilization

				if (File.Exists(strFromFileName))
				{

					if (strFromFileName.ToLower().Substring(Math.Max(strFromFileName.ToLower().Length - 4, 0)) == ".pdf")
					{
						//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2099
						strFileName = FileSystem.Dir(strFromFileName);
						txtSubDragDocument.Tag = strFromFileName;
						txtSubDragDocument.Text = $"Drag Document Here{Environment.NewLine}{strFileName}";
					}
					else
					{
						MessageBox.Show($"Filename Does NOT have a .PDF extension.{Environment.NewLine}File MUST be a PDF!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

				}
				else
				{
					MessageBox.Show($"Unable To Find File{Environment.NewLine}{strFromFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If fso.FileExists(strFromFileName) = True Then

				fso = null;
			}
			catch
			{

				modAdminCommon.Report_Error("txtSubDragDocument_OLEDragDrop_Error: ");
			}

		} // txtSubDragDocument_OLEDragDrop

		private void txtSubExpirationDate_Leave(Object eventSender, EventArgs eventArgs) => Set_Expiration_Date_Color();



		public object Check_For_Active_MPM(int incompid)
		{

			// CREATED BY RTW
			// 1/14/2022
			// THE PURPOSE IS TO SELECT FROM THE DATABASE TO DETERMINE IF THIS COMPANY MAY HAVE ANY ACTIVE
			// MPM SUBSCRIPTIONS TO DETERMINE OTHER POTENTIAL FEATURES ON THE FORM.


			MPMActive = false;

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "SELECT COUNT(*) As lTotactive FROM Subscription WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}WHERE (sub_comp_id = {incompid.ToString()}) ";
			strQuery1 = $"{strQuery1}AND (sub_serv_code = 'CRM') ";
			strQuery1 = $"{strQuery1}AND (sub_end_date IS NULL OR sub_end_date >= GETDATE()) ";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if ((!rstRec1.BOF) && (!rstRec1.EOF))
			{
				// IF THEY HAVE AN ACTIVE MPM SUBSCRIPTION AND AS REGISTRATION ID THEN THE CURRENT SUBSCRIPTION IS LIKELY MPM
				if (Convert.ToDouble(rstRec1["lTotactive"]) > 0 && Strings.Len(($"{txtCRMRegId.Text} ").Trim()) > 0 && ($"{txtCRMRegId.Text} ").Trim() != "" && ($"{txtCRMRegId.Text} ").Trim() != "0")
				{
					MPMActive = true;
				}
			}

			rstRec1.Close();
			return null;
		}



		public object Check_For_Active_MPM_View(int incompid, int sub_id, string comp_db_name)
		{

			// CREATED BY RTW
			// 1/14/2022
			// THE PURPOSE IS TO SELECT FROM THE DATABASE TO DETERMINE IF THIS COMPANY MAY HAVE ANY ACTIVE
			// MPM SUBSCRIPTIONS TO DETERMINE OTHER POTENTIAL FEATURES ON THE FORM.

			string strQuery1 = "";
			string strConn = "";
			string strDBHost = "";
			string strDatabase = "";
			string strUserId = "";
			string strPassword = "";
			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			int lCnt1 = 0;
			int lCnt1_Total = 0;
			string last_sub = "";
			string temp_update_string = "";
			StringBuilder sub_id_list = new StringBuilder();

			MPMActive = false;

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			if (comp_db_name.Trim() != "" && incompid == 0)
			{
				strQuery1 = $" select *   from view_jetnet_mpm_subscriptions  Where client_dbDatabase = '{comp_db_name}' ";
				strQuery1 = $"{strQuery1} and sub_serv_code <> 'CRM' order by sub_id asc ";
			}
			else if (incompid > 0 && sub_id == 0)
			{ 
				//------------------------ NOT CURRENTLY BEING HIT---------------------
				strQuery1 = $" select *  from view_jetnet_mpm_subscriptions  Where sub_comp_id = {incompid.ToString()}";
				strQuery1 = $"{strQuery1} and sub_serv_code <> 'CRM' order by sub_id asc ";
			}
			else
			{
				strQuery1 = $" select * from view_jetnet_mpm_subscriptions  Where sub_id = {sub_id.ToString()}";
			}



			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if ((!rstRec1.BOF) && (!rstRec1.EOF))
			{
				MPMActive = true;
				strDBHost = Convert.ToString(rstRec1["client_dbHost"]);
				strDatabase = Convert.ToString(rstRec1["client_dbDatabase"]);
				strUserId = Convert.ToString(rstRec1["client_dbUID"]);
				strPassword = Convert.ToString(rstRec1["client_dbPWD"]);
			}



			if (MPMActive)
			{

				strConn = $"Driver={{MySQL ODBC 3.51 Driver}};Server={strDBHost};Port=3306;";
				strConn = $"{strConn}Database={strDatabase.Trim()};Uid={strUserId};";
				strConn = $"{strConn}Pwd={strPassword};OPTION=3;";

				cntConn.ConnectionString = strConn;
				//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cntConn.setCursorLocation(CursorLocationEnum.adUseClient);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, 120);
				//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cntConn.setConnectionTimeout(60);

				//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
				cntConn.Open();


				if (comp_db_name.Trim() != "" && incompid == 0)
				{
					if (!(rstRec1.BOF && rstRec1.EOF))
					{
						rstRec1.MoveFirst();

						while(!rstRec1.EOF)
						{

							if (Convert.ToString(rstRec1["sub_mpm_flag"]).Trim() == "N")
							{
								temp_update_string = $"Update Subscription set sub_mpm_flag = 'Y', sub_action_date = '1/1/1900' where sub_id = {Convert.ToString(rstRec1["sub_id"])} ";
								run_subscription_updater(temp_update_string, -5, Convert.ToInt32(rstRec1["sub_id"]));
							}

							if (sub_id_list.ToString().Trim() != "")
							{
								sub_id_list.Append(", ");
							}

							sub_id_list.Append(Convert.ToString(rstRec1["sub_id"]));

							if (Convert.ToString(rstRec1["sub_id"]).Trim() != last_sub.Trim())
							{
								lCnt1 = -1; // clear every time
								Check_Logins_Grid(cntConn, Convert.ToInt32(rstRec1["sub_comp_id"]), Convert.ToInt32(rstRec1["sub_id"]), ref lCnt1);
								if (lCnt1 > 0)
								{
									lCnt1_Total += lCnt1;
								}
							}

							last_sub = Convert.ToString(rstRec1["sub_id"]).Trim();
							rstRec1.MoveNext();
						};
					}

					if (lCnt1_Total < 0)
					{
						lCnt1_Total = 0;
					}
					if ((txt_SubNbrOfInstalls[2].Text.Trim() != lCnt1_Total.ToString().Trim()) && (modSubscription.gbl_SubID == mpm_sub_id))
					{ // and this sub id is the mpm sub id
						txt_SubNbrOfInstalls[2].Text = lCnt1_Total.ToString();
						temp_update_string = $"Update subscription set sub_mpm_flag = 'Y', sub_mpm_nbr_installs = {lCnt1_Total.ToString()}, sub_action_date = '1/1/1900' where sub_id = {modSubscription.gbl_SubID.ToString()} ";

						run_subscription_updater(temp_update_string, lCnt1_Total, modSubscription.gbl_SubID);
					}
				}
				else if (incompid > 0 && sub_id == 0)
				{ 
					if (!(rstRec1.BOF && rstRec1.EOF))
					{
						rstRec1.MoveFirst();

						while(!rstRec1.EOF)
						{

							temp_update_string = $"Update Subscription set sub_mpm_flag = 'Y', sub_action_date = '1/1/1900' where sub_id = {Convert.ToString(rstRec1["sub_id"])} ";
							run_subscription_updater(temp_update_string, -5, Convert.ToInt32(rstRec1["sub_id"]));

							if (sub_id_list.ToString().Trim() != "")
							{
								sub_id_list.Append(", ");
							}

							sub_id_list.Append(Convert.ToString(rstRec1["sub_id"]));

							if (Convert.ToString(rstRec1["sub_id"]).Trim() != last_sub.Trim())
							{
								lCnt1 = -1; // clear every time
								Check_Logins_Grid(cntConn, incompid, Convert.ToInt32(rstRec1["sub_id"]), ref lCnt1);
								lCnt1_Total += lCnt1;
							}

							last_sub = Convert.ToString(rstRec1["sub_id"]).Trim();
							rstRec1.MoveNext();
						};
					}

					// this updates the CRM record
					if (lCnt1_Total == -1)
					{
						lCnt1_Total = 0;
					}
					if (txt_SubNbrOfInstalls[2].Text.Trim() != lCnt1_Total.ToString().Trim())
					{
						txt_SubNbrOfInstalls[2].Text = lCnt1_Total.ToString();
						temp_update_string = $"Update subscription set sub_mpm_nbr_installs = {lCnt1_Total.ToString()}, sub_action_date = '1/1/1900' where sub_id = {modSubscription.gbl_SubID.ToString()} ";
						// MsgBox (temp_update_string)
						run_subscription_updater(temp_update_string, lCnt1_Total, modSubscription.gbl_SubID);
					}
				}
				else
				{

					// if we have an open/valid connection, then check it
					if (chkProductType[12].CheckState == CheckState.Unchecked)
					{
						chkProductType[12].CheckState = CheckState.Checked;
						//MsgBox ("Update Subscription MPM Flag")
						temp_update_string = $"Update Subscription set sub_mpm_flag = 'Y', sub_action_date = '1/1/1900' where sub_id = {sub_id.ToString()} ";
						//MsgBox (temp_update_string)
						run_subscription_updater(temp_update_string, -5, sub_id);
					}

					int tempRefParam = 0;
					Check_Logins_Grid(cntConn, incompid, sub_id, ref tempRefParam);
				}




				UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
				cntConn.Close();
			}
			else
			{

				chkProductType[12].ForeColor = SystemColors.ControlText;

				// then we need to shut it off
				if (sub_id > 0)
				{
					if (chkProductType[12].CheckState == CheckState.Checked)
					{
						Application.DoEvents();
						temp_update_string = $"Update Subscription set sub_mpm_flag = 'N', sub_mpm_nbr_installs = 0, sub_action_date = '1/1/1900' where sub_id = {sub_id.ToString()} ";
						// MsgBox (temp_update_string)
						run_subscription_updater(temp_update_string, -5, sub_id);

						Application.DoEvents();
						//set all of the flags = 'N' for all of the logins
						temp_update_string = $"Update Subscription_login set sublogin_mpm_flag = 'N', sublogin_action_date = NULL where sublogin_sub_id = {sub_id.ToString()} ";
						// MsgBox (temp_update_string)
						run_subscription_updater(temp_update_string, -5, sub_id);
						Application.DoEvents();
					}
				}
				else if (sub_id == 0 && !MPMActive && modSubscription.gbl_SubID > 0)
				{  // then this is an mpm account with no other accounts
					temp_update_string = $"Update Subscription set sub_mpm_flag = 'Y', sub_mpm_nbr_installs = 0, sub_action_date = '1/1/1900' where sub_id = {modSubscription.gbl_SubID.ToString()} ";
					run_subscription_updater(temp_update_string, -5, modSubscription.gbl_SubID);
				}
			}


			rstRec1.Close();

			return null;
		}
	}
}