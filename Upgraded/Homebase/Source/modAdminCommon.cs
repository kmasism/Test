using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal static class modAdminCommon
	{


		// this module is shared with homebase administration application
		// Last Updated 12/20/2011 - By David D. Cruger

		[Serializable]
		public struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("Kernel32.dll", EntryPoint = "GetComputerNameA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int GetComputerName([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpBuffer, ref int nSize);


		//==================
		// Private Declares
		//==================
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("user32.dll", EntryPoint = "SystemParametersInfoA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int SystemParametersInfo(int uAction, int uParam, System.IntPtr lpvParam, int fuWinIni);

		public const int SPI_GETWORKAREA = 48;
		// USED FOR REPORTING ERRORS
		public static bool bolTRACE_ON = false; //BOOLEAN
		public static bool TRACE_ON = false; //BOOLEAN
		static int fD = 0; //TRACE File Descriptor

		public static int SB = 0; //Status Bar handle


		// USED FOR TRANSACTION PROCEDURES AND FUNCTIONS
		public static int[] arr_Saved_Company_IDs = null; // array of companies saved - currently not used
		public static string[] arr_Saved_Contact_IDs = null;

		// USED FOR TRANSMITS
		private static int[] arrHighlightCodes = null;

		const int intLowGroup = 1;
		const int intHighGroup = 19;
		const int intLowField = 1;
		const int intHighField = 13;

		//==================
		// Public Type Defs
		//==================
		[Serializable]
		public class Rec_Journal //gap-note Struct changed to class. VBUC feature.
		{
			public System.DateTime journ_date;
			public string journ_category_code;
			public string journ_subcategory_code;
			public string journ_subject;
			public string journ_description;
			public string journ_customer_note;
			public int journ_ac_id;
			public int journ_contact_id;
			public int journ_comp_id;
			public string journ_user_id;
			public System.DateTime journ_entry_date;
			public string journ_account_id;
			public int journ_pcreckey;
			public string journ_prior_account_id;
			public string journ_status;
			public int journ_yacht_id; // added msw 11/14/12
			public int journ_amod_id; // added msw 3/21/19
			public static Rec_Journal CreateInstance()
			{
				Rec_Journal result = new Rec_Journal();
				result.journ_category_code = String.Empty;
				result.journ_subcategory_code = String.Empty;
				result.journ_subject = String.Empty;
				result.journ_description = String.Empty;
				result.journ_customer_note = String.Empty;
				result.journ_user_id = String.Empty;
				result.journ_account_id = String.Empty;
				result.journ_prior_account_id = String.Empty;
				result.journ_status = String.Empty;
				return result;
			}
		}


		//==================
		// Public Variables
		//==================
		public static DbConnection ADODB_Trans_conn = null;
		public static string ADODB_Connect = ""; //Initialized in the 'frm_Main_Menu.Open_Database' routine
		public static DbConnection LOCAL_ADO_DB = null; // Local Database handle
		public static DbConnection CLIENT_ADO_DB = null; // Client Database handle
		public static string DateToday = ""; // Today's date in MM/DD/YYYY format

		public static string Registration_no = ""; //Used in the 'Aircraft_Change' form
		public static int gbl_ConfirmDays = 0; // Number of days used to confirm company and contact information

		public static string[] arr_SellerBusTypes = null;
		public static string[] arr_BuyerBusTypes = null;
		public static Rec_Journal Rec_Journal_Info = Rec_Journal.CreateInstance();
		public static int gbl_Yacht_ID = 0; // Global Yacht Id
		public static int gbl_Yacht_Journal_ID = 0;
		public static int gbl_Company_ID = 0; // Global for Passing Company ID
		public static int gbl_Company_Journal_ID = 0;
		public static int gbl_Aircraft_ID = 0; // Global for Passing Aircraft ID
		public static int gbl_Aircraft_Journal_ID = 0; // Global for Passing Aircraft Journal ID
		public static string gbl_User_ID = ""; // Global for User ID
		public static string gbl_User_Name = "";
		public static string gbl_User_Admin = ""; // Global for Admin - On Login - MSW 7/24/13 - user_edit_subscriptions
		public static string gbl_User_Browser = ""; // RTW - 2/17/2011 - Global for identifying the users browser as I or M
		public static string gbl_User_Create_Sub = ""; // MSW - added 7/1/24 - to use the create subscrption flag
		// **************************************************************************************************
		// NEW FIELDS FOR EVOLUTION/HOMEBASE.COM INTEGRATION - CURRENTLY FILLED FROM 777 SUBSCRIPTION ONLY
		// RTW - 12/3/2019
		public static string gbl_Evo_Email_Address = ""; // USERS EVOLUTION EMAIL ADDRESS - ENTERED BY RTW ON 12/3/2019 FOR HOMEBASE.COM INTEGRATION
		public static string gbl_Evo_Password = ""; // USERS EVOLUTION PASSWORD

		public static Form gbl_Form = null; // Global Form Name
		public static string gbl_Account_ID = ""; // Global Account ID
		public static int gbl_journ_ID = 0; // Global Account ID
		public static string Transaction_Subject = "";
		public static ADORecordSetHelper snp_User = null; //8/11/05 aey   ' User Account Recordset
		// RTW - 4/8/2004 - MOVED INTO MODEL FORM - NO NEED FOR GLOBAL
		//Public snp_Model As Recordset   ' Aircraft Model Recordset
		public static ADORecordSetHelper snp_Account_Rep = null; //8/11/05 aey Snapshot   ' Account Representative
		public static string gbl_Search = "";
		// RTW - 4/8/2004 - MOVED INTO CONTACT_FIND FORM - NO NEED FOR GLOBAL
		// Public snp_Duplicates As Snapshot
		public static System.DateTime tempdate = DateTime.FromOADate(0);
		public static string NormalColor = "";
		public static string PrimaryColor = "";
		public static string ConfirmColor = "";
		public static string ForSaleColor = "";
		public static string InactiveColor = "";
		public static string NoColor = "";
		public static string HeadingColor = "";
		public static string ExclusiveColor = "";
		public static string LeaseColor = "";
		public static string HiddenColor = "";
		public static bool ClickMe = false;
		public static bool gbl_bHomeClicked = false;
		public static string[, ] arrCurrentKeyACContacts = null; // array of key contacts for an aircraft
		public static string[, ] arrPriorKeyACContacts = null; // Used to remember the Key Contacts before an aircraft record changes
		public static string gbl_WebSite = ""; // Used to store primary web site location
		public static string gbl_Fileserver = ""; // Used to store primary fileserver (for automatic updates etc...)
		public static int gbl_ColorConfirmDays = 0; // Used to store the number of days in the future for the color confirm callbacks
		public static string gbl_ModelPictures = "";
		public static string gbl_AircraftPictures = "";
		public static string gbl_Documents = "";
		public static string gbl_Processing = "";
		public static string gbl_NTSB_Email_Address = ""; // USED IN PROCESSING NTSB REPORTS
		public static string gbl_337_Email_Address = ""; // USED IN PROCESSING FAA 337 REPORTS
		public static int gbl_FormLoop = 0;
		public static string gbl_logging_flag = "";
		public static bool gbl_Live_flag = false; // RTW/MSW - used to identify if we are talking to live site for using app config functions
		public static bool gbl_Backup_flag = false;

		public static Color ClassAColor = System.Drawing.Color.Black;
		public static Color ClassBColor = System.Drawing.Color.Black;
		public static Color ClassCColor = System.Drawing.Color.Black;
		public static Color ClassDColor = System.Drawing.Color.Black;

		public static bool TRANS_ACTIVE = false;
		public static string gbl_Database_Type = "";
		public static string DB_Name = "";
		public static string EventTempCompName = "";
		public static string EventTempAskingPrice = "";
		public static int EventTempCompID = 0;
		public static int EventTempContactID = 0;

		public static bool HasWanteds = false;
		public static int Num_Embedded = 0; //aey 3/28/05 used by ado_trans

		public static string gDatabaseName = "";
		public static string gIPAddress = "";

		public static string[] BusTypeArry = null;
		public static bool BusTypeArryFilled = false;

		internal static string Create_Confirm_Verify_Subject(string subject, string temp_code, int AC_ID, int comp_id, int contact_id = 0)
		{

			string result = "";


			string temp_select = $"select top 1 journ_comp_id from journal with (NOLOCK) where journ_subcategory_code = '{temp_code}' ";

			if (AC_ID > 0)
			{
				temp_select = $"{temp_select} and journ_ac_id = {AC_ID.ToString()}";
			}

			if (comp_id > 0)
			{
				temp_select = $"{temp_select} and journ_comp_id = {comp_id.ToString()}";
			}

			if (contact_id > 0)
			{
				temp_select = $"{temp_select} and journ_contact_id = {contact_id.ToString()}";
			}

			// if its confirm company field, make sure its the same field
			if (temp_code.Trim() == "CPCFM" || temp_code.Trim() == "CNCFM")
			{
				temp_select = $"{temp_select} and journ_subject like '{subject}%' ";
			}


			temp_select = $"{temp_select} and journ_date >= (getdate() - 30) ";
			temp_select = $"{temp_select} and journ_subject not like '%Before Due%' ";

			// ADDED MSW - 2/2/21 - to make sure reg number hasnt been changed since
			if (temp_code.Trim() == "VAR")
			{
				temp_select = $"{temp_select} and not exists( select top 1 * from journal j2 with (NOLOCK) where j2.journ_id > journal.journ_id and j2.journ_subject like 'Changed Registration Number%') ";
			}

			if (Exist(temp_select))
			{
				// if there is a subject existing in the last 30 days then we should put in another before due
				return $"{subject} - Before Due";
			}
			else
			{
				return subject;
			}



		}

		internal static bool Exist(string in_Query)
		{
			//
			// PURPOSE: THE PURPOSE OF THIS FUNCTION IS TO CHECK TO SEE IF THE RESULTS OF
			//          A PASSED QUERY STATEMENT RETURN ANY DATA FROM THE DATABASE.
			//          IF YES, RETURN A TRUE
			//          IF NO OR A FAILURE, THEN RETURN A FALSE
			// ****************************************************************************
			bool result = false;
			try
			{
				int cmdTimeOut = 0;
				cmdTimeOut = 0;

				ADORecordSetHelper snp_Exist = new ADORecordSetHelper();

				result = false;

				cmdTimeOut = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(LOCAL_ADO_DB);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(LOCAL_ADO_DB, 5000);

				snp_Exist.Open(in_Query, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Exist.BOF && snp_Exist.EOF))
				{
					result = true;
				}

				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(LOCAL_ADO_DB, cmdTimeOut);

				snp_Exist.Close();
				snp_Exist = null;
			}
			catch (System.Exception excep)
			{

				// ERROR OCCURRED WHEN RUNNING QUERY
				Cursor.Current = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				Report_Error($"Exist_Error: {Information.Err().Number.ToString()} {excep.Message} {in_Query}");
				modStatusBar.Clear_Status_Bar(SB);
				result = false;
			}
			return result;
		}


		internal static string gbl_LeftAdjust(object FLD, string FMT)
		{
			//
			// This function will accept a field and a
			// FORMAT string, and will return a FORMATed
			// STRING left-adjusted in a field whose width is
			// described by the FORMAT string.
			//
			//    Print_Field$ = LeftAdjust(value, "########0.000")
			//    Print_Field$ = LeftAdjust(field, "@@@@@@@@")


			StringBuilder Temp_Fld = new StringBuilder();

			int Fmt_Len = Strings.Len(FMT);
			//UPGRADE_WARNING: (1068) FLD of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
			string loc_Fld = StringsHelper.Format(FLD, FMT).Trim();
			int Fld_Len = Strings.Len(loc_Fld);
			if (Fld_Len >= Fmt_Len)
			{
				Temp_Fld = new StringBuilder(loc_Fld);
			}
			else
			{
				Temp_Fld = new StringBuilder(loc_Fld);
				int tempForEndVar = Fmt_Len - Fld_Len;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					Temp_Fld.Append(" ");
				}
			}
			return Temp_Fld.ToString();
		}
		internal static string gbl_RightAdjust(object FLD, string FMT)
		{

			// This function will accept a field and a
			// FORMAT string, and will return a FORMATed
			// STRING right-adjusted in a field whose width is
			// described by the FORMAT string.
			//    Print_Field$ = RightAdjust(value, "########0.000")
			//                       or
			//    Print_Field$ = RightAdjust(field, "@@@@@@@@")



			int Fmt_Len = Strings.Len(FMT);
			//UPGRADE_WARNING: (1068) FLD of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
			string loc_Fld = StringsHelper.Format(FLD, FMT).Trim();
			int Fld_Len = Strings.Len(loc_Fld);
			StringBuilder Temp_Fld = new StringBuilder();
			if (Fld_Len >= Fmt_Len)
			{
				Temp_Fld = new StringBuilder(loc_Fld);
			}
			else
			{
				int tempForEndVar = Fmt_Len - Fld_Len;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					Temp_Fld.Append(" ");
				}
				Temp_Fld.Append(loc_Fld);
			}
			return Temp_Fld.ToString();
		}

		internal static string DeleteCarriageReturnsAndExtraSpaces(string inData)
		{
			string tmpResult = "";

			if (($"{inData}").Trim() == "")
			{
				tmpResult = inData.Trim();
			}
			else
			{
				tmpResult = inData;

				tmpResult = StringsHelper.Replace(tmpResult, Environment.NewLine, " ", 1, -1, CompareMethod.Binary);
				tmpResult = StringsHelper.Replace(tmpResult, "\r", " ", 1, -1, CompareMethod.Binary);


				while(tmpResult.IndexOf("  ") >= 0)
				{
					tmpResult = StringsHelper.Replace(tmpResult, "  ", " ", 1, -1, CompareMethod.Binary);
				};

			}

			return tmpResult;

		}
		internal static string return_top1_alt_account(string account_id)
		{
			//used to count aircraft features

			string result = "";
			try
			{

				string Query = "";
				ADORecordSetHelper snpFeat = new ADORecordSetHelper();

				Query = $"select top 1 accrep_alt_account_id from account_rep with (NOLOCK) where accrep_account_id = '{account_id}' ";
				snpFeat.Open(Query, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpFeat.BOF && snpFeat.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpFeat["accrep_alt_account_id"]))
					{
						result = ($"{Convert.ToString(snpFeat["accrep_alt_account_id"])}").Trim();
					}
					else
					{
						result = "";
					}
				}
				else
				{
					result = "";
				}

				snpFeat.Close();
				snpFeat = null;
			}
			catch (System.Exception excep)
			{

				Report_Error($"return_top1_alt_account_Error: {excep.Message}");
			}

			return result;
		}
		internal static int CountACFeatures(int inWhichModelID, string inWhichFeature, string inWhichValue)
		{
			//used to count aircraft features

			int result = 0;
			try
			{

				string Query = "";
				ADORecordSetHelper snpFeat = new ADORecordSetHelper();

				Query = "SELECT count(*) AS theCount ";
				Query = $"{Query}FROM Aircraft_Key_Feature WITH(NOLOCK) ";
				Query = $"{Query}WHERE afeat_feature_code = '{inWhichFeature.Trim()}' ";
				Query = $"{Query}AND afeat_status_flag = '{inWhichValue}' ";
				Query = $"{Query}AND afeat_journ_id = 0 ";
				if (Double.Parse($"0{inWhichModelID.ToString()}") > 0)
				{
					Query = $"{Query}AND afeat_ac_id IN ";
					Query = $"{Query}(SELECT ac_id FROM Aircraft WITH(NOLOCK) WHERE ac_journ_id = 0 ";
					Query = $"{Query}AND ac_amod_id = {inWhichModelID.ToString()}) ";
				}

				snpFeat.Open(Query, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpFeat.BOF && snpFeat.EOF))
				{
					result = Convert.ToInt32(Double.Parse($"0{($"{Convert.ToString(snpFeat["theCount"])}").Trim()}"));
				}
				else
				{
					result = 0;
				}

				snpFeat.Close();
				snpFeat = null;
			}
			catch (System.Exception excep)
			{

				Report_Error($"CountACFeatures_Error: {excep.Message}");
			}

			return result;
		}

		// 07/12/2011 - By David D. Cruger
		// Checks to make sure the snp_user recordset is available
		// Returns login id and first/last name

		internal static void ReturnUserIdAndName(ref string strUserId, ref string strUserName)
		{

			strUserId = frm_Main_Menu.DefInstance.txt_login_ID.Text;
			strUserName = "";

			if (snp_User != null)
			{
				if (snp_User.State == ConnectionState.Open)
				{
					if ((!snp_User.BOF) && (!snp_User.EOF))
					{
						strUserId = ($"{Convert.ToString(snp_User["user_id"])} ").Trim();
						strUserName = $"{($"{Convert.ToString(snp_User["user_first_name"])} ").Trim()} {($"{Convert.ToString(snp_User["user_last_name"])} ").Trim()}";
					}
				}
			}

		}

		internal static string GetDateTime()
		{
			string result = "";
			try
			{

				if (Strings.Len(($"{DateToday}").Trim()) == 0)
				{
					DateToday = DateTime.Parse(GetSystemDateTime()).ToString("MM/dd/yyyy");
				}

				System.DateTime TempDate2 = DateTime.FromOADate(0);
				return $"{((DateTime.TryParse(DateToday, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : DateToday)} {StringsHelper.Format(DateTime.Now.ToString("HH:mm:ss"), "h:mm:ss AM/PM")}";
			}
			catch
			{

				//aey 3/28/05
				result = $"{DateTime.Now.ToString("MM/dd/yyyy")} {StringsHelper.Format(DateTime.Now.ToString("HH:mm:ss"), "h:mm:ss AM/PM")}";
			}
			return result;
		}

		internal static double MakeNumeric(string Expression)
		{


			double result = 0;
			string tempvar = "";
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Convert.IsDBNull(Expression)))
			{
				try
				{
					return result;
				}
				catch
				{
				}
			}
			ErrorHandlingHelper.ResumeNext(
				() => {tempvar = $"{Expression}";}, 
				() => {tempvar = StringsHelper.Replace(tempvar, ",", "", 1, -1, CompareMethod.Binary);},  //drop commas
				() => {result = Conversion.Val(tempvar);});

			return result;
		}

		internal static string ReturnUserName()
		{

			string CurUser = "";
			int cnt = 199;
			string S = new string((char) 0, 200);
			int dl = JetNetSupport.PInvoke.SafeNative.kernel32.GetComputerName(ref S, ref cnt);
			if (dl != 0)
			{
				CurUser = S.Substring(0, Math.Min(cnt, S.Length));
			}
			else
			{
				CurUser = "";
			}
			return CurUser;

		}

		internal static bool CenterForm32(mdi_ResearchAssistant Frm)
		{
			try
			{

				int ScreenLeft = 0, ScreenWidth = 0, ScreenHeight = 0, ScreenTop = 0;
				RECT DesktopArea = new RECT();

				JetNetSupport.PInvoke.SafeNative.user32.SystemParametersInfo(SPI_GETWORKAREA, 0, ref DesktopArea, 0);

				ScreenHeight = (DesktopArea.bottom - DesktopArea.top) * 15;
				ScreenWidth = (DesktopArea.right - DesktopArea.left) * 15;
				ScreenLeft = DesktopArea.left * 15;
				ScreenTop = DesktopArea.top * 15;

				Frm.SetBounds(((ScreenWidth - Frm.Width * 15) / 2 + ScreenLeft) / 15, ((ScreenHeight - Frm.Height * 15) / 2 + ScreenTop) / 15, 0, 0, BoundsSpecified.X | BoundsSpecified.Y);

				return true;
			}
			catch
			{

				Report_Error("CenterForm32_Error: ");
				return false;
			}
		}

		internal static bool Open_Database(string inDatabase, string inIPAddress, string inPassword)
		{

			bool result = false;
			try
			{

				string DB_User_ID = "";
				string DB_Password = "";

				result = false;

				Cursor.Current = Cursors.WaitCursor;

				gbl_Database_Type = "Remote";

				DB_User_ID = "sa";

				gDatabaseName = inDatabase;
				gIPAddress = inIPAddress;

				if (inPassword.Trim() == "")
				{
					inPassword = "moejive";
				}

				//new connection string from Dave 9/12/05

				ADODB_Connect = $"Provider=SQLOLEDB;Data Source={inIPAddress.Trim()}" +
				                $";INITIAL CATALOG={inDatabase.Trim()}" +
				                $";UID={DB_User_ID};PWD={inPassword}";

				// CREATE CONNECTION OBJECT
				LOCAL_ADO_DB = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);
				LOCAL_ADO_DB.ConnectionString = ADODB_Connect;
				//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
				LOCAL_ADO_DB.Open();
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(LOCAL_ADO_DB, 120);

				CLIENT_ADO_DB = null;

				result = true;

				Cursor.Current = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				MessageBox.Show($"ERROR: {excep.Message} {Information.Err().Number.ToString()} {excep.Source}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				//  MsgBox ("Connection was bad to database")
			}
			return result;
		}

		internal static void Open_Client_Connection()
		{
			//open connection, if it is closed aey 7/25/05

			try
			{

				if (CLIENT_ADO_DB == null)
				{

					CLIENT_ADO_DB = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
					//UPGRADE_ISSUE: (2064) ADODB.Connection property CLIENT_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					CLIENT_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
					//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
					CLIENT_ADO_DB.ConnectionString = ADODB_Connect;
					CLIENT_ADO_DB.Open();
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(CLIENT_ADO_DB, 120);

				}
			}
			catch (System.Exception excep)
			{
				CLIENT_ADO_DB = null;
				Report_Error($"Open_Client_Connection_Error: {excep.Message}", "Connection");
			}

		}

		internal static string GetSystemDateTime()
		{

			string result = "";
			string strQuery1 = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strResults = "";

			try
			{

				strResults = DateTime.Now.ToString();

				strQuery1 = "EXEC GetSystemDateTime";

				if (LOCAL_ADO_DB != null)
				{

					if (LOCAL_ADO_DB.State == ConnectionState.Open)
					{

						rstRec1.Open(strQuery1, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{
							result = Convert.ToDateTime(rstRec1["CurrentDateTime"]).ToString();
						}

					} // If LOCAL_ADO_DB.State = adStateOpen Then

				} // If (LOCAL_ADO_DB Is Nothing) = False Then

				rstRec1 = null;


				return strResults;
			}
			catch
			{

				result = DateTime.Now.ToString();
			}
			return result;
		} // GetSystemDateTime

		internal static void Get_Application_Configuration()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();


			string strCCat = "TEST";
			string strQuery1 = "SELECT * FROM Application_Configuration ";
			try
			{
				Cursor.Current = Cursors.WaitCursor;
			}
			catch
			{
			}

			if (gbl_Live_flag)
			{
				strCCat = "LIVE";
			}
			if (gbl_Backup_flag)
			{
				strCCat = "BACKUP";
			}
			ErrorHandlingHelper.ResumeNext(

				() => {strQuery1 = $"{strQuery1}WHERE (aconfig_config_category = '{strCCat}') ";}, 

				() => {rstRec1.Open(strQuery1, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);});

			if (!rstRec1.BOF && !rstRec1.EOF)
			{
				ErrorHandlingHelper.ResumeNext(

					() => {gbl_WebSite = ($"{Convert.ToString(rstRec1["aconfig_website"])} ").Trim();}, 
					() => {gbl_Fileserver = ($"{Convert.ToString(rstRec1["aconfig_fileserver"])} ").Trim();}, 
					() => {gbl_ColorConfirmDays = Convert.ToInt32(Double.Parse(($"{Convert.ToString(rstRec1["aconfig_color_confirm_days"])} ").Trim()));}, 
					() => {gbl_ModelPictures = ($"{Convert.ToString(rstRec1["aconfig_model"])} ").Trim();}, 
					() => {gbl_AircraftPictures = ($"{Convert.ToString(rstRec1["aconfig_aircraft_pictures"])} ").Trim();}, 
					() => {gbl_Documents = ($"{Convert.ToString(rstRec1["aconfig_documents"])} ").Trim();}, 
					() => {gbl_Processing = ($"{Convert.ToString(rstRec1["aconfig_processing"])} ").Trim();}, 
					() => {gbl_NTSB_Email_Address = ($"{Convert.ToString(rstRec1["aconfig_ntsb_email_address"])} ").Trim();}, 
					() => {gbl_337_Email_Address = ($"{Convert.ToString(rstRec1["aconfig_337_email_address"])} ").Trim();}, 
					() => {gbl_logging_flag = ($"{Convert.ToString(rstRec1["aconfig_internal_logging_flag"])} ").Trim();});

			}
			ErrorHandlingHelper.ResumeNext( // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				() => {rstRec1.Close();}, 
				() => {rstRec1 = null;}, 

				() => {Cursor.Current = CursorHelper.CursorDefault;});

		} // Get_Application_Configuration

		internal static string Fix_Quote(object varInput)
		{
			//UPGRADE_WARNING: (1068) varInput of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
			string result = "";
			if (Convert.ToString(varInput).Trim() != "")
			{
				//UPGRADE_WARNING: (1068) varInput of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				result = StringsHelper.Replace(Convert.ToString(varInput), "'", "''", 1, -1, CompareMethod.Binary);
			}

			return result;
		}

		internal static string Run_Company_Rules(string item_to_run_thro, string area, string block_string)
		{

			ADORecordSetHelper ado_company_rules = new ADORecordSetHelper();
			string Query = "";


			Query = "select  ccrule_area, ccrule_block, ccrule_type, ccrule_find,  ccrule_action,  ccrule_order ";
			Query = $"{Query} from CompanyContact_Rules with (NOLOCK) ";
			Query = $"{Query} where ccrule_area = '{area}' ";

			if (block_string.Trim() != "")
			{
				Query = $"{Query} and ccrule_block = '{block_string}' ";
			}


			ado_company_rules.Open(Query, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(ado_company_rules.BOF && ado_company_rules.EOF))
			{

				while(!ado_company_rules.EOF)
				{

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_company_rules["ccrule_type"]) && !Convert.IsDBNull(ado_company_rules["ccrule_type"]) && !Convert.IsDBNull(ado_company_rules["ccrule_action"]))
					{
						if (Convert.ToString(ado_company_rules["ccrule_type"]).Trim() == "REPLACE")
						{
							item_to_run_thro = StringsHelper.Replace(item_to_run_thro, Convert.ToString(ado_company_rules["ccrule_find"]), Convert.ToString(ado_company_rules["ccrule_action"]), 1, -1, CompareMethod.Binary);
							item_to_run_thro = StringsHelper.Replace(item_to_run_thro, Convert.ToString(ado_company_rules["ccrule_find"]).ToUpper(), Convert.ToString(ado_company_rules["ccrule_action"]), 1, -1, CompareMethod.Binary);
							item_to_run_thro = StringsHelper.Replace(item_to_run_thro, Convert.ToString(ado_company_rules["ccrule_find"]).ToLower(), Convert.ToString(ado_company_rules["ccrule_action"]), 1, -1, CompareMethod.Binary);
						}
					}

					ado_company_rules.MoveNext();
				};
				ado_company_rules.Close();

			}

			return item_to_run_thro;


		}


		internal static void Report_Error(string inText, string inType = "")
		{
			string M = "";
			try
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				if (Information.Err().Number != 11)
				{
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					M = $"{inText}Error Number '{Conversion.Str(Information.Err().Number)}', {Information.Err().Description}";
					if (Strings.Len(inType.Trim()) == 0)
					{
						inType = "Common";
					}
					Record_Error(inType, inText);

					Clipboard.Clear();
					//UPGRADE_WARNING: (2081) Clipboard.SetText has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					Clipboard.SetText(M);

					MessageBox.Show(M, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					if (TRACE_ON)
					{
						Trace(M);
					}
				}
			}
			catch (System.Exception excep)
			{
				if (Num_Embedded == 0)
				{ //aey 3/28/05 protect transactions
					MessageBox.Show($"Report_Error_Error: {excep.Message} : Trying to report {M}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}

		}


		internal static void Display_Error(string inText, string inType = "")
		{
			string M = "";
			try
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				if (Information.Err().Number != 11)
				{
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					M = $"{inText}Error Number '{Conversion.Str(Information.Err().Number)}', {Information.Err().Description}";
					if (Strings.Len(inType.Trim()) == 0)
					{
						inType = "Common";
					}
					//Call Record_Error(inType, inText)

					Clipboard.Clear();
					//UPGRADE_WARNING: (2081) Clipboard.SetText has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					Clipboard.SetText(M);

					MessageBox.Show(M, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					if (TRACE_ON)
					{
						Trace(M);
					}
				}
			}
			catch (System.Exception excep)
			{
				if (Num_Embedded == 0)
				{ //protect transactions
					MessageBox.Show($"Display_Error_Error: {excep.Message} : Trying to report {M}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}

		}


		internal static void Trace(string strLN)
		{
			try
			{

				if (bolTRACE_ON)
				{
					FileSystem.PrintLine(fD, strLN);
				}
			}
			catch
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				MessageBox.Show($"Trace_Error: Error Number '{Conversion.Str(Information.Err().Number)}', {Conversion.ErrorToString()}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}

		}

		internal static int ADO_Transaction(string inTransState, int inAC_ID = 0, int inJourn_ID = 0, int inComp_ID = 0, string inMsg = "")
		{
			//
			// THE PURPOSE OF THIS PROCEDURE IS TO HANDLE CREATION, COMMITTING,
			// AND ROLLBACK OF TRANSACTIONS.
			//
			// 7/9/03 - RTW - ADDED ERROR LOGGING
			int result = 0;
			try
			{

				switch(inTransState)
				{
					case "BeginTrans" : 
						 
						if (Conversion.Val(Num_Embedded.ToString()) == 0)
						{

							ADODB_Trans_conn = null;
							ADODB_Trans_conn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

							//UPGRADE_ISSUE: (2064) ADODB.Connection property ADODB_Trans_conn.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							ADODB_Trans_conn.setConnectionTimeout(30); // Regulates how long a connection will try to connect
							//UPGRADE_ISSUE: (2064) ADODB.Connection property ADODB_Trans_conn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							ADODB_Trans_conn.setCursorLocation(CursorLocationEnum.adUseServer);
							//UPGRADE_ISSUE: (2070) Constant adModeShareDenyNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2070
							//UPGRADE_ISSUE: (2064) ADODB.Connection property ADODB_Trans_conn.Mode was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							ADODB_Trans_conn.setMode(UpgradeStubs.System_Data_CommandType.getadModeShareDenyNone());

							//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
							ADODB_Trans_conn.ConnectionString = ADODB_Connect;
							ADODB_Trans_conn.Open();
							UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(ADODB_Trans_conn, 120); // regulates how long commands run on the connection object

							Num_Embedded = UpgradeHelpers.DB.TransactionManager.Enlist(ADODB_Trans_conn.BeginTransaction());
							Num_Embedded = 1;

						}
						else
						{
							Record_Event("BeginTrans", $"Called Begin Trans While In Transaction {inMsg}", inAC_ID, inJourn_ID, inComp_ID);
						} 
						 
						break;
					case "CommitTrans" : 
						 
						if (Num_Embedded > 0)
						{
							UpgradeHelpers.DB.TransactionManager.Commit(ADODB_Trans_conn);
							UpgradeHelpers.DB.TransactionManager.DeEnlist(ADODB_Trans_conn);
							ADODB_Trans_conn.Close();
							ADODB_Trans_conn = null;
							Num_Embedded = 0;
						} 

						 
						break;
					case "RollbackTrans" : 
						 
						if (Num_Embedded > 0)
						{
							UpgradeHelpers.DB.TransactionManager.Rollback(ADODB_Trans_conn);
							UpgradeHelpers.DB.TransactionManager.DeEnlist(ADODB_Trans_conn);
							ADODB_Trans_conn.Close();
							ADODB_Trans_conn = null;
							Num_Embedded = 0;
						} 
						 
						break;
					case "CheckStatus" : 
						result = Num_Embedded; 
						 
						break;
					default:
						Report_Error($"modAdminCommon.ADO_Transaction_Error: (INTERNAL ERROR) st:[{inTransState.Trim()}]"); 
						 
						break;
				}

				if (Num_Embedded < 0)
				{
					Num_Embedded = 0;
				}


				return Num_Embedded;
			}
			catch (System.Exception excep)
			{

				result = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				Report_Error($"modAdminCommon.ADO_Transaction_Error: [{excep.Source}] - ({Information.Err().Number.ToString()}) - {excep.Message} st:[{inTransState.Trim()}]");
				return result;
			}
		}

		internal static void Record_Event(string inType, string inText, int inAC_ID = 0, int inJourn_ID = 0, int inComp_ID = 0, bool inUse_AutoLog = false, int inYacht_ID = 0, int inContact_ID = 0)
		{

			string strUserId = "";
			string strUserName = "";

			if (gbl_logging_flag.Trim().ToUpper() == "N")
			{
				if (inType.ToUpper() == "MONITOR ACTIVITY")
				{
					return;
				}
			}

			if (Strings.Len(inText) > 2500)
			{ //Too Big
				inText = $"{inText.Substring(0, Math.Min(2490, inText.Length))}**TO BIG**";
			}

			ReturnUserIdAndName(ref strUserId, ref strUserName);

			string Query = "INSERT into EventLog (evtl_user_id, evtl_type, evtl_message,evtl_ac_id, evtl_journ_id, ";
			Query = $"{Query}evtl_comp_id, evtl_yacht_id, evtl_contact_id) VALUES (";
			Query = $"{Query}'{strUserId}', ";
			Query = $"{Query}'{inType}', ";
			Query = $"{Query}'{Fix_Quote(inText)}', ";
			Query = $"{Query}{inAC_ID.ToString()},";
			Query = $"{Query}{inJourn_ID.ToString()},";
			Query = $"{Query}{inComp_ID.ToString()},";
			Query = $"{Query}{inYacht_ID.ToString()},";
			Query = $"{Query}{inContact_ID.ToString()}";
			Query = $"{Query})";

			DbCommand TempCommand = null;
			TempCommand = LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

		}


		internal static void Insert_Job(string inType, int inAC_ID)
		{

			string strUserId = "";
			string strUserName = "";

			ReturnUserIdAndName(ref strUserId, ref strUserName);

			string Query = "INSERT into Job_Log (";
			Query = $"{Query} jlog_title, jlog_job, jlog_entry_date, jlog_param1, jlog_param2 ";
			Query = $"{Query}) VALUES (";
			Query = $"{Query}'{inType}','{inType}', getdate(), {inAC_ID.ToString()}, 0";
			Query = $"{Query})";

			DbCommand TempCommand = null;
			TempCommand = LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

		}

		internal static void Record_Error(string inType, string inText)
		{
			try
			{
				string Query = "";
				int lErrNbr = 0;
				string strErrDesc = "";
				string strUserId = "";
				string strUserName = "";

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = Information.Err().Description.Substring(0, Math.Min(255, Information.Err().Description.Length)); //7/7/04 aey

				Clipboard.Clear();
				//UPGRADE_WARNING: (2081) Clipboard.SetText has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				Clipboard.SetText($"{lErrNbr.ToString()} - {strErrDesc}");

				if (Strings.Len(inText) > 2000)
				{ //Too Big
					inText = $"{inText.Substring(0, Math.Min(1990, inText.Length))}**TO BIG**";
				}

				ReturnUserIdAndName(ref strUserId, ref strUserName);

				Query = "INSERT into ErrorLog (elog_date, elog_user_id, elog_number, elog_type, elog_description, elog_message) ";
				Query = $"{Query}VALUES (";
				Query = $"{Query}'{StringsHelper.Format(GetSystemDateTime(), "General Date")}', ";
				Query = $"{Query}'{strUserId}', ";
				Query = $"{Query}{lErrNbr.ToString()}, ";
				Query = $"{Query}'{Fix_Quote(inType.Trim()).Substring(0, Math.Min(50, Fix_Quote(inType.Trim()).Length))}', ";
				Query = $"{Query}'{Fix_Quote(strErrDesc)}', ";
				Query = $"{Query}'{Fix_Quote(inText.Trim())}')";

				DbCommand TempCommand = null;
				TempCommand = LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				TempCommand.CommandType = CommandType.Text;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //7/2/04 aey
			}
			catch (System.Exception excep)
			{
				if (Num_Embedded == 0)
				{ //protect transactions
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					MessageBox.Show($"Record_Error_Error: {Information.Err().Number.ToString()} {excep.Message} : Trying to record {inType}-{inText}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}

		}

		internal static void Record_Transmit(string Aircraft_Ser_No_Full, int Record_ID, int Aircraft_Journal_ID, int model_id, string Record_Type, string Record_Action, ref string[] arrHighlightNames, int inComp_ID = 0)
		{

			string strError = "";
			try
			{
				StringBuilder highlightall = new StringBuilder();
				string Query = ""; //aey 7/1/04



				strError = "init";
				switch(Record_Type)
				{ // translate the type of record in english to the code anticipated
					case "Available" : 
						Record_Type = "1"; 
						 
						break;
					case "Transaction" : 
						Record_Type = "2"; 
						 
						break;
					case "Wanted" : 
						Record_Type = "3"; 
						 
						break;
					case "Fractional Owner" : 
						Record_Type = "17"; 
						 
						break;
					case "Fractional Sold" : 
						Record_Type = "18"; 
						 
						break;
					case "Aircraft" : 
						Record_Type = "9"; 
						break;
				}
				// *************************************************
				// NEW CODE FOR PROTECTING AGAINST HELO TRANSMITS
				// RTW - 6/15/2005
				//
				if (Record_Type == "9" || Record_Type == "2" || Record_Type == "1" || Record_Type == "18")
				{
					Query = "select ac_id from aircraft WITH(NOLOCK), aircraft_model WITH(NOLOCK)";
					Query = $"{Query}where ac_amod_id = amod_id and ac_id ={Record_ID.ToString()} and ac_journ_id=0 and amod_airframe_type_code='R'";
					if (Exist(Query))
					{
						return;
					}

				}
				switch(Record_Action)
				{ // translate the record action in english to the code anticipated
					case "Add" : 
						Record_Action = "A"; 
						break;
					case "Change" : 
						Record_Action = "C"; 
						break;
					case "Delete" : 
						Record_Action = "D"; 
						break;
				}

				strError = "highlight";
				// call a routine to assign highlight codes to each name identified as a change
				ComputeHighlightCodes(ref arrHighlightNames);

				strError = "query";
				Query = "INSERT INTO Transmit ";
				Query = $"{Query}(transmit_download_type, ";
				Query = $"{Query}transmit_trans_type, transmit_customer_flag,transmit_download_flag, ";
				Query = $"{Query}transmit_ac_id,transmit_ac_ser_no_full, transmit_amwant_id, ";
				Query = $"{Query}transmit_amod_id, transmit_comp_id, transmit_journ_id, ";
				Query = $"{Query}transmit_highlight_code_1, transmit_highlight_code_2, transmit_highlight_code_3, ";
				Query = $"{Query}transmit_highlight_code_4, transmit_highlight_code_5, transmit_highlight_code_6, ";
				Query = $"{Query}transmit_highlight_code_7, transmit_highlight_code_8, ";
				Query = $"{Query}transmit_highlight_code_9, transmit_highlight_code_10, ";
				Query = $"{Query}transmit_highlight_code_11, transmit_highlight_code_12, ";
				Query = $"{Query}transmit_highlight_code_13,transmit_highlight_code_14, ";
				Query = $"{Query}transmit_highlight_code_15, transmit_highlight_code_16, ";
				Query = $"{Query}transmit_highlight_code_17, transmit_highlight_code_18, ";
				Query = $"{Query}transmit_highlight_code_19, transmit_change_datetime, ";
				Query = $"{Query}transmit_change_user) VALUES (";
				Query = $"{Query}{($" {Record_Type}").Trim()}, "; // Type or record being written
				Query = $"{Query}'{($" {Record_Action}").Trim()}', "; // A=Add, C=Change, D=Delete
				Query = $"{Query}1, "; // unknown
				Query = $"{Query}'     ', "; // unknown
				// handle aircraft id for available, sold, aircraft, or fractional sales
				if (Record_Type == "9" || Record_Type == "2" || Record_Type == "1" || Record_Type == "18")
				{
					Query = $"{Query}{Record_ID.ToString()}, "; // aircraft id number
				}
				else
				{
					Query = $"{Query}0, "; // aircraft id number
				}
				Query = $"{Query}'{Aircraft_Ser_No_Full}', "; // aircraft serial number full
				if (Record_Type == "3")
				{
					Query = $"{Query}{Record_ID.ToString()}, "; // wanted id number
				}
				else
				{
					Query = $"{Query}0, "; // wanted id
				}
				Query = $"{Query}{model_id.ToString()}, "; // aircraft model id number

				// store the company id for fractional owners , fractional solds and wanteds
				if (Record_Type == "17" || Record_Type == "18" || Record_Type == "3")
				{
					Query = $"{Query}{inComp_ID.ToString()}, "; // fractional owner id number
				}
				else
				{
					Query = $"{Query}0, "; //
				}
				//============================================================================
				// IF NO HIGHLIGHT CODES HAVE BEEN RECORDED FOR A CHANGE TO AVAILABLES OR AIRCRAFT (OWNER)
				// RECORDS THEN DON'T RECORD A TRANSMIT
				strError = "highlight";
				highlightall = new StringBuilder("");
				for (int i = 1; i <= 19; i++)
				{
					highlightall.Append(arrHighlightCodes[i].ToString());
				}
				if ((Record_Type == "1" || Record_Type == "9") && Record_Action == "Change" && Strings.Len(highlightall.ToString().Trim()) == 0)
				{
					return;
				}
				Query = $"{Query}{Aircraft_Journal_ID.ToString()}, ";
				Query = $"{Query}'{arrHighlightCodes[1].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[2].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[3].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[4].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[5].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[6].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[7].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[8].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[9].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[10].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[11].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[12].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[13].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[14].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[15].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[16].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[17].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[18].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[19].ToString()}', ";
				Query = $"{Query}'{GetSystemDateTime()}', ";
				//Query = Query & "'" & Date & " " & Time & "', "
				Query = $"{Query}'{Convert.ToString(snp_User["user_id"])}')";

				//Debug.Print "About to execute query: " & Aircraft_Journal_ID
				strError = "exec";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //aey 7/13/04
				//LOCAL_DB.Execute Query
			}
			catch (System.Exception excep)
			{

				Cursor.Current = CursorHelper.CursorDefault;
				Report_Error($"Record_Transmit_Error: {excep.Message} {Aircraft_Ser_No_Full} rt:{Record_Type} ra:{Record_Action} {strError}");
			}

		}

		internal static bool Record_Delete_Log_Entry(string inRecord_Type, int inRecord_Id, int inJourn_ID, int inSeq_No = 0, int inEventID = 0, string inFeature = "", int inPictureID = 0)
		{

			bool result = false;
			try
			{

				string Query = "";

				result = false;

				Query = "INSERT INTO Delete_Log ";
				Query = $"{Query}(dlog_type,dlog_ac_id, dlog_journ_id, ";
				Query = $"{Query}dlog_comp_id, dlog_contact_id, dlog_wanted_id, ";
				Query = $"{Query}dlog_amod_id, dlog_seq_no, dlog_priorev_id, ";
				Query = $"{Query}dlog_entry_user, dlog_acpic_id, dlog_yacht_id, ";
				Query = $"{Query}dlog_feature_code) ";
				Query = $"{Query}VALUES ('";
				Query = $"{Query}{($" {inRecord_Type}").Trim()}', "; // Type or record being written

				// 06/21/2005 - By David D. Cruger; Added AircraftPictures
				if (inRecord_Type == "Transaction" || inRecord_Type == "Key_Feature" || inRecord_Type == "Document" || inRecord_Type == "Installation" || inRecord_Type == "WebUser" || inRecord_Type == "Subscription" || inRecord_Type == "AircraftPicture" || inRecord_Type == "Aircraft" || inRecord_Type == "AircraftPictures")
				{ // handle the AC ID
					Query = $"{Query}{inRecord_Id.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				Query = $"{Query}{inJourn_ID.ToString()}, "; // handle the journal id

				if (inRecord_Type == "Company")
				{ // handle the Company ID
					Query = $"{Query}{inRecord_Id.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}


				if (inRecord_Type == "Contact")
				{ // handle the Contact ID
					Query = $"{Query}{inRecord_Id.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				if (inRecord_Type == "Wanted")
				{ // handle the Wanted ID
					Query = $"{Query}{inRecord_Id.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				if (inRecord_Type == "Model")
				{ // handle the Model ID
					Query = $"{Query}{inRecord_Id.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				if (Strings.Len(inSeq_No.ToString().Trim()) > 0)
				{ // handle sequence number
					Query = $"{Query}{inSeq_No.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				if (Strings.Len(inEventID.ToString().Trim()) > 0)
				{
					Query = $"{Query}{inEventID.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				Query = $"{Query}'{Convert.ToString(snp_User["user_id"])}', ";

				if (Strings.Len(inPictureID.ToString().Trim()) > 0)
				{ // acpic_id
					Query = $"{Query}{inPictureID.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}


				if (inRecord_Type == "Yacht")
				{ // handle the Yacht ID
					Query = $"{Query}{inRecord_Id.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				if (inRecord_Type == "Key_Feature")
				{ // HANDLE KEY FEATURE
					Query = $"{Query}'{inFeature}') ";
				}
				else
				{
					Query = $"{Query}'') ";
				}


				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				Report_Error($"Record_Delete_Log_Entry ({Information.Err().Number.ToString()}) {excep.Message}");
				result = false;
			}
			return result;
		} // Record_Delete_Log_Entry

		private static void ComputeHighlightCodes(ref string[] arrHighlightNames)
		{

			int intIndex = 0;
			string strFieldName = "";
			string strQuery = "";
			ADORecordSetHelper snpHighlight = null; //aey 8/11/05
			Array arrHighlightCodeMatrix = null;

			try
			{

				arrHighlightCodeMatrix = Array.CreateInstance(typeof(int), new int[]{intHighGroup - intLowGroup + 1, intHighField - intLowField + 1}, new int[]{intLowGroup, intLowField});
				arrHighlightCodes = new int[intHighGroup + 1];

				intIndex = 0;


				while(intIndex <= arrHighlightNames.GetUpperBound(0))
				{
					strFieldName = arrHighlightNames[intIndex];

					strQuery = "SELECT * FROM Transmit_highlight_codes WITH(NOLOCK) ";
					strQuery = $"{strQuery}WHERE hc_name = '{strFieldName}'";

					snpHighlight = new ADORecordSetHelper();
					snpHighlight.Open(strQuery, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpHighlight.BOF && snpHighlight.EOF))
					{
						arrHighlightCodeMatrix.SetValue(Convert.ToInt32(snpHighlight["hc_value"]), Convert.ToInt32(snpHighlight["hc_group"]) - 1, Convert.ToInt32(snpHighlight["hc_field"]) - 1);  //gap-note validate this line in runtime
					}
					intIndex++;
				};

				for (int intGroupNumber = intLowGroup; intGroupNumber <= intHighGroup; intGroupNumber++)
				{
					for (int intFieldNumber = intLowField; intFieldNumber <= intHighField; intFieldNumber++)
					{
						arrHighlightCodes[intGroupNumber] += Convert.ToInt32(arrHighlightCodeMatrix.GetValue(intGroupNumber - 1, intFieldNumber - 1));//gap-note validate this line in runtime
					}
				}

				snpHighlight.Close();
				snpHighlight = null;
			}
			catch (Exception e)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				if (Information.Err().Number == 9)
				{ //Subscript Out of range
					arrHighlightNames = new string[]{""};
					//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
					UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				}
				else
				{
					MessageBox.Show($"Compute Highlight Codes Error: {e.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					Cursor.Current = CursorHelper.CursorDefault;
					modStatusBar.Clear_Status_Bar(SB);
				}
				return;

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

		}

		internal static void UnloadAllForms()
		{
			Form Frm = null;
			foreach (Form FrmIterator in Application.OpenForms)
			{
				Frm = FrmIterator;
				Frm.Close();
				//UPGRADE_NOTE: (1029) Object Frm may not be destroyed until it is garbage collected. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-1029
				Frm = null;
				//Frm
				Frm = default(Form);
			}
		}

		internal static object ClearAllLocksForCurrentUser(string inUserID)
		{

			string sQuery = "";
			string strErrDesc = "";

			try
			{

				sQuery = "";
				if (inUserID.Trim() != "")
				{

					sQuery = $"DELETE FROM Aircraft_Lock WHERE alock_user_id = '{inUserID.Trim()}'";
					DbCommand TempCommand = null;
					TempCommand = LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = sQuery;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					sQuery = $"DELETE FROM Company_Lock WHERE complock_user_id = '{inUserID.Trim()}'";
					DbCommand TempCommand_2 = null;
					TempCommand_2 = LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = sQuery;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

					sQuery = $"DELETE FROM Contact_Lock WHERE contlock_user_id = '{inUserID.Trim()}'";
					DbCommand TempCommand_3 = null;
					TempCommand_3 = LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
					TempCommand_3.CommandText = sQuery;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
					TempCommand_3.ExecuteNonQuery();

					// 01/28/2014 - By David D. Cruger; Added Clear Yacht Lock
					sQuery = $"DELETE FROM Yacht_Lock WHERE yl_user_id = '{inUserID.Trim()}'";
					DbCommand TempCommand_4 = null;
					TempCommand_4 = LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = sQuery;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery();

				}
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"ClearAllLocksForCurrentUser_Error ({Information.Err().Number.ToString()}) {strErrDesc}", "modAdminCommon(CLEARLOCK)");
			}

			return null;
		}

		internal static bool Key_Feature_Standard(int inACID, string inFeature)
		{

			bool result = false;
			string strError = "";
			try
			{

				string Query = ""; // String used to store query
				ADORecordSetHelper ado_FeatureCheck = new ADORecordSetHelper(); //7/7/04 aey

				strError = "init";
				result = false;

				// AUTOMATICALLY UPDATE THE FEATURE FOR THE AIRCRAFT
				Query = "select ac_id, ac_ser_no_value, Aircraft_Model_Key_Feature.* from Aircraft WITH(NOLOCK), Aircraft_Model_Key_Feature WITH(NOLOCK)";
				Query = $"{Query} where ac_id = {inACID.ToString()}";
				Query = $"{Query} and ac_amod_id = amfeat_amod_id";
				Query = $"{Query} and amfeat_feature_code='{inFeature.Trim()}'";

				ado_FeatureCheck.Open(Query, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_FeatureCheck.BOF && ado_FeatureCheck.EOF))
				{

					if (($" {Convert.ToString(ado_FeatureCheck["amfeat_standard_equip"])}").Trim() == "Y")
					{
						// AUTOMATICALLY UPDATE THE FEATURE FOR THE AIRCRAFT IN THE GRID
						result = true;
						strError = "val check"; //nz replaced with val() aey 9/14/04
						if (Conversion.Val($"{Convert.ToString(ado_FeatureCheck["amfeat_stdeq_start_ser_no_value"])}") > 0 && Conversion.Val($"{Convert.ToString(ado_FeatureCheck["ac_ser_no_value"])}") < Conversion.Val($"{Convert.ToString(ado_FeatureCheck["amfeat_stdeq_start_ser_no_value"])}"))
						{
							result = false;
						}

						if (Conversion.Val($"{Convert.ToString(ado_FeatureCheck["amfeat_stdeq_end_ser_no_value"])}") > 0 && Conversion.Val($"{Convert.ToString(ado_FeatureCheck["ac_ser_no_value"])}") > Conversion.Val($"{Convert.ToString(ado_FeatureCheck["amfeat_stdeq_end_ser_no_value"])}"))
						{
							result = false;
						}
					}
					else
					{
						result = false;
					}

					ado_FeatureCheck.Close();

				}

				ado_FeatureCheck = null;
			}
			catch (System.Exception excep)
			{

				// CLOSE RECORSET
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				strError = $"{strError} -{excep.Message} {Information.Err().Number.ToString()} {inFeature} {inACID.ToString()}";
				result = false;
				Report_Error($"Key_Feature_Standard_Error: {strError}");
			}

			return result;
		}

		internal static bool Key_Feature_Auto_Set(int inACID, string inFeature, string inRule = "")
		{

			bool result = false;
			try
			{
				ADORecordSetHelper snp_FeatureCheck = new ADORecordSetHelper();
				string Query = ""; // String used to store query
				string RuleQuery = "";
				result = false;

				// IF THE QUERY RULE IS PASSED INTO THE FUNCTION, THEN NO NEED TO GET IT
				if (inRule.Trim() == "")
				{
					RuleQuery = Key_Feature_Get_Rule(inFeature.Trim());
				}
				else
				{
					RuleQuery = inRule;
				}
				// ********************************************
				// IF THE AUTOMATIC RULES APPLY TO THIS FEATURE CODE
				if (RuleQuery.Trim() != "")
				{

					// AUTOMATICALLY UPDATE THE FEATURE FOR THE AIRCRAFT
					Query = RuleQuery;
					Query = $"{Query} and ac_id = {inACID.ToString()}";

					if (Query.IndexOf("from Aircraft_Details where") >= 0)
					{
						Query = StringsHelper.Replace(Query, "from Aircraft_Details where", "from Aircraft_Details where adet_data_name <> 'Provisions' and ", 1, -1, CompareMethod.Binary);
					}
					else if (Query.IndexOf("adet_journ_id = 0") >= 0)
					{ 
						Query = StringsHelper.Replace(Query, "adet_journ_id = 0", "adet_journ_id = 0 and adet_data_name <> 'Provisions' ", 1, -1, CompareMethod.Binary);
					}
					else if (Query.IndexOf("inner join Aircraft_Details") >= 0)
					{ 
						Query = $"{Query} and adet_data_name <> 'Provisions' ";
					}
					else if (Query.IndexOf("Aircraft_Details") >= 0)
					{ 
						//Query = Replace(Query, "adet_journ_id = 0", "adet_journ_id = 0 and adet_data_name <> 'Provisions' ")
						Query = $"{Query} and adet_data_name <> 'Provisions' ";
					} // added MSW - 6/18/19


					snp_FeatureCheck.Open(Query, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(snp_FeatureCheck.BOF && snp_FeatureCheck.EOF))
					{
						if (Double.Parse($"0{Convert.ToString(snp_FeatureCheck[0])}") > 0)
						{
							// THE RULE APPLIES AND DATA WAS FOUND
							result = true;
						}
						else
						{
							// THE RULE APPLIES AND DATA WAS NOT FOUND
							result = false;
						}
					}
					snp_FeatureCheck.Close();

				}
				else
				{
					result = false;
				}

				snp_FeatureCheck = null;
			}
			catch (System.Exception excep)
			{

				// CLOSE RECORSET
				result = false;
				Report_Error($"Key_Feature_Auto_Set_Error: {excep.Message}");
			}

			return result;
		}

		internal static string Key_Feature_Get_Rule(string inFeature)
		{
			string result = "";
			try
			{
				ADORecordSetHelper snp_FeatureCheck = new ADORecordSetHelper();
				string Query = ""; // String used to store query

				result = "";

				// SELECT THE KEY FEATURE IF IT HAS AN AUTO GENERATE FLAG
				Query = "SELECT kfeat_query FROM Key_Feature WITH(NOLOCK)";
				Query = $"{Query} WHERE kfeat_code = '{inFeature}'";
				Query = $"{Query} AND kfeat_auto_generate_flag = 'Y'";

				snp_FeatureCheck.Open(Query, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(snp_FeatureCheck.BOF && snp_FeatureCheck.EOF))
				{
					// THE KEY FEATURE IS AUTO GENERATE - RETURN THE QUERY FOUND
					result = ($"{Convert.ToString(snp_FeatureCheck["kfeat_query"])}").Trim();
					// CLOSE RECORSET
					snp_FeatureCheck.Close();
				}
				else
				{
					result = "";
				}

				snp_FeatureCheck = null;
			}
			catch (System.Exception excep)
			{

				result = "";
				Report_Error($"Key_Feature_Get_Rule_Error: {excep.Message}");
			}

			return result;
		}

		internal static int Key_Feature_Auto_Count(string inFeatureCode, int inModelID)
		{

			int result = 0;
			try
			{


				string Query = "";
				string FeatureQuery = "";
				ADORecordSetHelper snpGetQuery = new ADORecordSetHelper();

				Query = $"SELECT kfeat_query FROM Key_Feature WITH(NOLOCK) WHERE kfeat_code = '{inFeatureCode}'";

				snpGetQuery.Open(Query, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(snpGetQuery.BOF && snpGetQuery.EOF))
				{
					FeatureQuery = ($"{Convert.ToString(snpGetQuery["kfeat_query"])}").Trim();
				}
				else
				{
					FeatureQuery = "";
				}

				snpGetQuery.Close();
				snpGetQuery = null;

				if (FeatureQuery.Trim() != "")
				{
					Query = FeatureQuery;
					// IF THE MODEL ID IS PASSED THEN ADD IT TO THE AUTOMATIC QUERY
					if (Double.Parse($"0{inModelID.ToString()}") > 0)
					{
						Query = $"{Query} and ac_amod_id = {inModelID.ToString()}";
					}

					snpGetQuery.Open(Query, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(snpGetQuery.BOF && snpGetQuery.EOF))
					{
						result = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpGetQuery[0])}").Trim()));
					}
					else
					{
						result = 0;
					}

					snpGetQuery.Close();
				}
				else
				{
					//If Trim(FeatureQuery) <> "" Then
					result = -1;
				} //If Trim(FeatureQuery) <> "" Then

				snpGetQuery = null;
			}
			catch (System.Exception excep)
			{

				result = 0;
				Report_Error($"Key_Feature_Auto_Count_Error: {excep.Message}");
			}

			return result;
		}

		internal static object Table_Action_Log(string Passed_Table_Name)
		{
			try
			{

				string Query = "";
				ADORecordSetHelper adoResult = null;

				Query = "SELECT tact_table_name FROM Table_Action_Log";
				Query = $"{Query} WHERE tact_table_name = '{Passed_Table_Name}'";
				Query = $"{Query} AND tact_action_date IS NULL";

				adoResult = ADORecordSetHelper.Open(Query, LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(adoResult.Fields) && !(adoResult is null))
				{

					if (adoResult.EOF && adoResult.BOF)
					{
						adoResult = null;

						Query = "INSERT INTO Table_Action_Log (tact_table_name,tact_action_date)";
						Query = $"{Query} VALUES ('{Passed_Table_Name}',NULL)";

						DbCommand TempCommand = null;
						TempCommand = LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

					}
					else
					{

						adoResult.Close();
						adoResult = null;

					}

				}
			}
			catch
			{
				Report_Error("Table_Action_Log_Error:");
			}

			return null;
		}

		internal static double ConvertLatitudeLongitudeToMiles(double dLatFrom, double dLongFrom, double dLatTo, double dLongTo)
		{

			double dX = 0;
			double dY = 0;
			double dMiles = 0d;
			if (dLatFrom != 0d && dLongFrom != 0d && dLatTo != 0d && dLongTo != 0d)
			{
				dX = 69.1d * (dLatTo - dLatFrom);
				dY = 69.1d * (dLongTo - dLongFrom) * Math.Cos(dLatFrom / 57.3d);
				dMiles = Math.Sqrt((dX * dX) + (dY * dY));
			}

			return dMiles;

		} // ConvertLatitudeLongitudeToMiles

		internal static int CalulateDistanceBetweenAirports(int lAPortIdFrom, int lAPortIdTo)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			double dLatFrom = 0;
			double dLongFrom = 0;
			double dLatTo = 0;
			double dLongTo = 0;

			int lResults = 0;

			try
			{

				lResults = 0;
				dLatFrom = 0d;
				dLongFrom = 0d;
				dLatTo = 0d;
				dLongTo = 0d;

				if (lAPortIdFrom > 0 && lAPortIdTo > 0)
				{

					strQuery1 = "SELECT aport_latitude_decimal As dLat,aport_longitude_decimal As dLong ";
					strQuery1 = $"{strQuery1}FROM Airport WITH (NOLOCK) WHERE (aport_id = {lAPortIdFrom.ToString()}) ";

					rstRec1.Open(strQuery1, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["dLat"]))
						{
							dLatFrom = Convert.ToDouble(rstRec1["dLat"]);
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["dLong"]))
						{
							dLongFrom = Convert.ToDouble(rstRec1["dLong"]);
						}
					}

					rstRec1.Close();

					strQuery1 = "SELECT aport_latitude_decimal As dLat,aport_longitude_decimal As dLong ";
					strQuery1 = $"{strQuery1}FROM Airport WITH (NOLOCK)  WHERE (aport_id = {lAPortIdTo.ToString()}) ";

					rstRec1.Open(strQuery1, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["dLat"]))
						{
							dLatTo = Convert.ToDouble(rstRec1["dLat"]);
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["dLong"]))
						{
							dLongTo = Convert.ToDouble(rstRec1["dLong"]);
						}
					}

					rstRec1.Close();

					if ((dLatFrom != 0d || dLongFrom != 0d) && (dLatTo != 0d || dLongTo != 0d))
					{
						lResults = Convert.ToInt32(ConvertLatitudeLongitudeToMiles(dLatFrom, dLongFrom, dLatTo, dLongTo));
					}

				} // If lAPortIdFrom > 0 And lAPortIdTo > 0 Then

				rstRec1 = null;


				return lResults;
			}
			catch (System.Exception excep)
			{

				Report_Error($"CalulateDistanceBetweenAirports_Error: {excep.Message}");
			}
			return 0;
		} // CalulateDistanceBetweenAirports
	}
}