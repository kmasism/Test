using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace HomebaseAdministrator
{
	internal static class modAdminCommon
	{

		// this module is shared with homebase administration application

		[Serializable]
		public struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}

		public const int REG_SZ = 1;
		public const int HKEY_CLASSES_ROOT = unchecked((int) 0x80000000);
		public const int HKEY_CURRENT_USER = unchecked((int) 0x80000001);
		public const int HKEY_LOCAL_MACHINE = unchecked((int) 0x80000002);
		public const int HKEY_USERS = unchecked((int) 0x80000003);
		public const int KEY_ALL_ACCESS = 0x3F;

		//-- Tab Control Tab Values
		public const int iTabCompanyAccountType = 0;
		public const int iTabCompanyAgencyType = 1;
		public const int iTabCompanyBusinessType = 2;
		public const int iTabCountry = 3;
		public const int iTabLanguage = 4;
		public const int iTabCurrency = 5;
		public const int iTabContactSirname = 6;
		public const int iTabContactSuffix = 7;
		public const int iTabContactTitle = 8;
		public const int iTabPhoneType = 9;
		public const int iTabState = 10;
		public const int iTabTimeZone = 11;
		public const int iTabFractionalPrograms = 12;
		public const int iTabFracProgramMembers = 13;
		public const int iTabFinancialGroups = 14;
		public const int iTabCompanyIndustryCodes = 15;
		public const int iTabRegion = 16;

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static void Sleep(int dwMilliseconds);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("advapi32.dll", EntryPoint = "RegOpenKeyExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int RegOpenKeyEx(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpSubKey, int ulOptions, int samDesired, ref int phkResult);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("advapi32.dll", EntryPoint = "RegQueryValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int RegQueryValueExString(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, int lpReserved, ref int lpType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpData, ref int lpcbData);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int RegCloseKey(int hKey);

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("Kernel32.dll", EntryPoint = "GetComputerNameA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int GetComputerName([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpBuffer, ref int nSize);


		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("shell32.dll", EntryPoint = "ShellExecuteA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int ShellExecute(int hwnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpOperation, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFile, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpParameters, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpDirectory, int nShowCmd);
		public const int SW_SHOWNORMAL = 1;

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("user32.dll", EntryPoint = "SystemParametersInfoA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int SystemParametersInfo(int uAction, int uParam, System.IntPtr lpvParam, int fuWinIni);

		public const int SPI_GETWORKAREA = 48;
		public static bool bolTRACE_ON = false; //BOOLEAN
		public static bool TRACE_ON = false; //BOOLEAN
		static int fD = 0; //TRACE File Descriptor

		public static int SB = 0; //Status Bar handle


		public static int[] arr_Saved_Company_IDs = null; // array of companies saved - currently not used
		public static string[] arr_Saved_Contact_IDs = null;

		// USED FOR TRANSMITS
		private static int[] arrHighlightCodes = null;

		const int intLowGroup = 1;
		const int intHighGroup = 19;
		const int intLowField = 1;
		const int intHighField = 13;

		[Serializable]
		public struct Rec_Journal
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
		public static int gbl_Company_ID = 0; // Global for Passing Company ID
		public static int gbl_Aircraft_ID = 0; // Global for Passing Aircraft ID
		public static int gbl_Aircraft_Journal_ID = 0; // Global for Passing Aircraft Journal ID
		public static string gbl_User_ID = ""; // Global for User ID
		public static string gbl_User_Browser = ""; // RTW - 2/17/2011 - Global for identifying the users browser as I or M
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
		public static string ClassAColor = "";
		public static string ClassBColor = "";
		public static string ClassCColor = "";
		public static string ClassDColor = "";
		public static bool ClickMe = false;
		public static bool gbl_bHomeClicked = false;
		public static string[] arrCurrentKeyACContacts = null; // array of key contacts for an aircraft
		public static string[] arrPriorKeyACContacts = null; // Used to remember the Key Contacts before an aircraft record changes
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

		public static string[, ] BusTypeArry = null;
		public static bool BusTypeArryFilled = false;
		private static Object _gfso = null;
		internal static Object gfso
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

		public static bool gIsRegionDirty = false;

		internal static int Convert_Meters_To_Feet(double dMeters)
		{


			int lResults = 0;

			if (dMeters > 0)
			{
				lResults = Convert.ToInt32(dMeters * 3.2808d);
			} // If dMeters > 0 Then

			return lResults;

		} // Convert_Meters_To_Feet

		internal static int Convert_Kilo_Meters_To_Feet(double dKilo)
		{


			int lResults = 0;

			if (dKilo > 0)
			{
				lResults = Convert.ToInt32(dKilo * 3280.84d);
			} // If dKilo > 0 Then

			return lResults;

		} // Convert_Kilo_Meters_To_Feet

		internal static int Convert_Miles_To_Feet(double dMiles)
		{


			int lResults = 0;

			if (dMiles > 0)
			{
				lResults = Convert.ToInt32(dMiles * 5280);
			} // If dMiles > 0 Then

			return lResults;

		} // Convert_Miles_To_Feet

		internal static void Convert_Decimal_To_Dir_Degree_Minute_Seconds(double dLatDecimal, double dLongDecimal, ref string strLatFull, ref string strLatDir, ref int lLatDegree, ref int lLatMinute, ref int lLatSecond, ref string strLongFull, ref string strLongDir, ref int lLongDegree, ref int lLongMinute, ref int lLongSecond)
		{




			strLatFull = "";
			strLatDir = "";
			lLatDegree = 0;
			lLatMinute = 0;
			lLatSecond = 0;

			strLongFull = "";
			strLongDir = "";
			lLongDegree = 0;
			lLongMinute = 0;
			lLongSecond = 0;

			string strLat = StringsHelper.Format(dLatDecimal, "#0.00000000");
			string strLong = StringsHelper.Format(dLongDecimal, "#0.00000000");

			//-------------------------
			// Latitude
			strLatDir = "N";
			if (strLat.StartsWith("-", StringComparison.Ordinal))
			{
				strLatDir = "S";
				strLat = strLat.Substring(Math.Min(1, strLat.Length));
			}

			string iPos1 = (strLat.IndexOf('.') + 1).ToString();
			string strDegree = strLat.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(iPos1) - 1), strLat.Length));
			lLatDegree = Convert.ToInt32(Double.Parse(strDegree));
			strLat = strLat.Substring(Math.Min(Convert.ToInt32(Double.Parse(iPos1)) - 1, strLat.Length));

			double dMinute = Double.Parse(strLat) * 60;
			strLat = StringsHelper.Format(dMinute, "#0.00000000");
			iPos1 = (strLat.IndexOf('.') + 1).ToString();
			string strMinute = strLat.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(iPos1) - 1), strLat.Length));
			lLatMinute = Convert.ToInt32(Double.Parse(strMinute));
			strLat = strLat.Substring(Math.Min(Convert.ToInt32(Double.Parse(iPos1)) - 1, strLat.Length));

			double dSecond = Double.Parse(strLat) * 60;
			strLat = StringsHelper.Format(dSecond, "#0.00000000");
			iPos1 = (strLat.IndexOf('.') + 1).ToString();
			string strSecond = strLat.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(iPos1) - 1), strLat.Length));
			lLatSecond = Convert.ToInt32(Double.Parse(strSecond));

			//-------------------------
			// Latitude
			strLongDir = "E";
			if (strLong.StartsWith("-", StringComparison.Ordinal))
			{
				strLongDir = "W";
				strLong = strLong.Substring(Math.Min(1, strLong.Length));
			}

			iPos1 = (strLong.IndexOf('.') + 1).ToString();
			strDegree = strLong.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(iPos1) - 1), strLong.Length));
			lLongDegree = Convert.ToInt32(Double.Parse(strDegree));
			strLong = strLong.Substring(Math.Min(Convert.ToInt32(Double.Parse(iPos1)) - 1, strLong.Length));

			dMinute = Double.Parse(strLong) * 60;
			strLong = StringsHelper.Format(dMinute, "#0.00000000");
			iPos1 = (strLong.IndexOf('.') + 1).ToString();
			strMinute = strLong.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(iPos1) - 1), strLong.Length));
			lLongMinute = Convert.ToInt32(Double.Parse(strMinute));
			strLong = strLong.Substring(Math.Min(Convert.ToInt32(Double.Parse(iPos1)) - 1, strLong.Length));

			dSecond = Double.Parse(strLong) * 60;
			strLong = StringsHelper.Format(dSecond, "#0.00000000");
			iPos1 = (strLong.IndexOf('.') + 1).ToString();
			strSecond = strLong.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(iPos1) - 1), strLong.Length));
			lLongSecond = Convert.ToInt32(Double.Parse(strSecond));

		} // Convert_Decimal_To_Dir_Degree_Minute_Seconds

		//=============================================================================================

		internal static void Convert_Dir_Degree_Minute_Seconds_To_Decimal(ref double dLatDecimal, ref double dLongDecimal, string strLatFull, string strLatDir, int lLatDegree, int lLatMinute, int lLatSecond, string strLongFull, string strLongDir, int lLongDegree, int lLongMinute, int lLongSecond)
		{

			string strCoordinates = "";
			string iPos1 = "";



			if (strLongDir == "U")
			{
				strLongDir = "W";
			}

			//-----------------
			// Latitude
			int lDegree = lLatDegree;
			int lMinute = lLatMinute;
			int lSecond = lLatSecond;
			double dLat = (lDegree) + (lMinute / 60d) + (lSecond / 3600d);
			if (strLatDir == "S")
			{
				dLat *= -1;
			}
			string strLat = StringsHelper.Format(dLat, "#0.00000000");
			dLatDecimal = Double.Parse(strLat);

			//-----------------
			// Longitude
			lDegree = lLongDegree;
			lMinute = lLongMinute;
			lSecond = lLongSecond;
			double dLong = (lDegree) + (lMinute / 60d) + (lSecond / 3600d);
			if (strLongDir == "W")
			{
				dLong *= -1;
			}
			string strLong = StringsHelper.Format(dLong, "#0.00000000");
			dLongDecimal = Double.Parse(strLong);

		} // Convert_Dir_Degree_Minute_Seconds_To_Decimal

		// Format Can Be  N29 12.06
		//                29'12.06'N

		internal static double Convert_GPS_To_Decimal(string strGPS)
		{

			string strDirection = "";
			string strDeg = "";
			string strMin = "";

			int lDeg = 0;
			double dMin = 0;

			int lDDD = 0;
			int lMM = 0;
			int lSS = 0;

			int iPos2 = 0;


			double dResults = 0d;

			strGPS = strGPS.ToUpper();
			if (strGPS.IndexOf('N') >= 0)
			{
				strDirection = "N";
			}
			if (strGPS.IndexOf('S') >= 0)
			{
				strDirection = "S";
			}
			if (strGPS.IndexOf('W') >= 0)
			{
				strDirection = "W";
			}
			if (strGPS.IndexOf('E') >= 0)
			{
				strDirection = "E";
			}
			strGPS = StringsHelper.Replace(strGPS, strDirection, "", 1, -1, CompareMethod.Binary);
			strGPS = StringsHelper.Replace(strGPS, "'", " ", 1, -1, CompareMethod.Binary);

			int iPos1 = (strGPS.IndexOf(' ') + 1);
			if (iPos1 > 0)
			{

				strDeg = strGPS.Substring(0, Math.Min(iPos1 - 1, strGPS.Length)).Trim();
				strMin = strGPS.Substring(Math.Min(iPos1, strGPS.Length)).Trim();

				if (Information.IsNumeric(strDeg) && Information.IsNumeric(strMin))
				{

					lDeg = Convert.ToInt32(Double.Parse(strDeg));
					dMin = Double.Parse(strMin);

					dResults = (lDeg * 1) + (dMin / 60d);
					lDDD = lDeg;
					lMM = Convert.ToInt32(dMin) * 1;
					lSS = Convert.ToInt32((dMin - (lMM * 1)) * 60);

					switch(strDirection)
					{
						case "N" :  // North 
							break;
						case "S" :  // South 
							dResults *= (-1d); 
							break;
						case "W" :  // West 
							dResults *= (-1d); 
							break;
						case "E" :  // East 
							break;
					} // Case strDirection

				} // If IsNumeric(strDeg) = True And IsNumeric(strMin) = True Then

			} // If iPos1 > 0 Then

			return dResults;

		} // Convert_GPS_To_Decimal

		internal static bool Exist(string in_Query)
		{

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
				for (int I = 1; I <= tempForEndVar; I++)
				{
					Temp_Fld.Append(" ");
				}
			}
			return Temp_Fld.ToString();
		}

		internal static string gbl_RightAdjust(object FLD, string FMT)
		{



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
				for (int I = 1; I <= tempForEndVar; I++)
				{
					Temp_Fld.Append(" ");
				}
				Temp_Fld.Append(loc_Fld);
			}
			return Temp_Fld.ToString();
		}

		internal static string DeleteCarriageReturnsAndExtraSpaces(string inData)
		{
			//remove unwanted characters
			// this function is not used by homebase, but it is
			// shared and used by homebase administrator

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

		internal static int CountACFeatures(int inWhichModelID, string inWhichFeature, string inWhichValue)
		{
			//used to count aircraft features

			int result = 0;
			try
			{

				string Query = "";
				ADORecordSetHelper snpFeat = new ADORecordSetHelper();

				Query = "SELECT count(*) AS theCount FROM Aircraft_Key_Feature WITH(NOLOCK) ";
				Query = $"{Query}WHERE afeat_feature_code = '{inWhichFeature.Trim()}' ";
				Query = $"{Query}AND afeat_status_flag = '{inWhichValue}' AND afeat_journ_id = 0 ";
				if (Double.Parse($"0{inWhichModelID.ToString()}") > 0)
				{
					Query = $"{Query}AND afeat_ac_id IN  (SELECT ac_id  FROM Aircraft WITH(NOLOCK) ";
					Query = $"{Query}WHERE ac_journ_id = 0  AND ac_amod_id = {inWhichModelID.ToString()}) ";
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

		internal static void ReturnUserIdAndName(ref string strUserId, ref string strUserName)
		{

			try
			{

				strUserId = frm_Admin_Menu.DefInstance.txt_login_ID.Text;
				strUserName = "";

				if (snp_User != null)
				{
					if (snp_User.State == ConnectionState.Open)
					{
						snp_User.Requery();
						if ((!snp_User.BOF) && (!snp_User.EOF))
						{
							strUserId = ($"{Convert.ToString(snp_User["user_id"])} ").Trim();
							strUserName = $"{($"{Convert.ToString(snp_User["user_first_name"])} ").Trim()} {($"{Convert.ToString(snp_User["user_last_name"])} ").Trim()}";
						}
					}
				}
			}
			catch (System.Exception excep)
			{

				Record_Error("Update_FAA_Flight_Data_Clear_Action_Date_For_By_Action_Date_In_Batch_Mode_Error", excep.Message);
			}

		}

		internal static string GetDateTime()
		{
			//concatinate server date with local time
			//aey 9/22/04

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
			//turns any input into a number
			//aey 6/7/2004


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

		internal static bool CenterForm32(mdi_AdminAssistant Frm)
		{
			bool result = false;
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
				result = false;
			}
			return result;
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
				ADODB_Connect = $"Provider=SQLOLEDB;Data Source={inIPAddress.Trim()},1433" +
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

				frm_Admin_Menu.DefInstance.lblServer.Text = StringsHelper.Replace(inIPAddress, "tcp:", "", 1, -1, CompareMethod.Binary);

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
			string Query = "";
			ADORecordSetHelper snpSystem = null;

			try
			{

				result = DateTime.Now.ToString();

				Query = "EXEC GetSystemDateTime";

				snpSystem = ADORecordSetHelper.Open(Query, LOCAL_ADO_DB, "");

				if (!(snpSystem.BOF && snpSystem.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpSystem["CurrentDateTime"]))
					{
						result = DateTime.Parse(Convert.ToString(snpSystem["CurrentDateTime"]).Trim()).ToString();
					}
					else
					{
						result = DateTime.Now.ToString();
					}
				}

				snpSystem = null;
			}
			catch
			{

				try
				{
					result = DateTime.Now.ToString();
				}
				catch
				{
				}
			}

			return result;
		}

		internal static void Get_Application_Configuration()
		{
			ADORecordSetHelper snp_Config = new ADORecordSetHelper();

			string Query = "SELECT * FROM Application_Configuration";
			try
			{
				Cursor.Current = Cursors.WaitCursor;
			}
			catch
			{
			}


			if (gbl_Live_flag)
			{
				try
				{
					Query = $"{Query} where aconfig_config_category ='LIVE' ";
				}
				catch
				{
				}
			}
			else
			{
				try
				{
					Query = $"{Query} where aconfig_config_category ='TEST'";
				}
				catch
				{
				}
			}
			try
			{

				snp_Config.Open(Query, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			}
			catch
			{
			}

			if (!(snp_Config.BOF && snp_Config.EOF))
			{
				ErrorHandlingHelper.ResumeNext(
					() => {snp_Config.MoveFirst();}, 
					() => {gbl_WebSite = ($"{Convert.ToString(snp_Config["aconfig_website"])}").Trim();}, 
					() => {gbl_Fileserver = ($"{Convert.ToString(snp_Config["aconfig_fileserver"])}").Trim();}, 
					() => {gbl_ColorConfirmDays = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_Config["aconfig_color_confirm_days"])}").Trim()));}, 
					() => {gbl_ModelPictures = ($"{Convert.ToString(snp_Config["aconfig_model"])}").Trim();}, 
					() => {gbl_AircraftPictures = ($"{Convert.ToString(snp_Config["aconfig_aircraft_pictures"])}").Trim();}, 
					() => {gbl_Documents = ($"{Convert.ToString(snp_Config["aconfig_documents"])}").Trim();}, 
					() => {gbl_Processing = ($"{Convert.ToString(snp_Config["aconfig_processing"])}").Trim();}, 
					() => {gbl_NTSB_Email_Address = ($"{Convert.ToString(snp_Config["aconfig_ntsb_email_address"])}").Trim();}, 
					() => {gbl_337_Email_Address = ($"{Convert.ToString(snp_Config["aconfig_337_email_address"])}").Trim();}, 
					() => {gbl_logging_flag = ($"{Convert.ToString(snp_Config["aconfig_internal_logging_flag"])}").Trim();});
			}
			try
			{

				Cursor.Current = CursorHelper.CursorDefault;
			}
			catch
			{
			}

		}

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

		internal static void Record_Event(string inType, string inText, int inAC_ID = 0, int inJourn_ID = 0, int inComp_ID = 0, bool inUse_AutoLog = false, int inlYachtId = 0, int inlContactId = 0)
		{

			string strUserId = "";
			string strUserName = "";


			if (gbl_logging_flag.Trim().ToUpper() == "N" && inUse_AutoLog)
			{
				return;
			}

			if (Strings.Len(inText) > 2000)
			{ //Too Big
				inText = $"{inText.Substring(0, Math.Min(1990, inText.Length))}**TO BIG**";
			}

			ReturnUserIdAndName(ref strUserId, ref strUserName);

			string Query = "INSERT into EventLog (evtl_date, evtl_user_id, evtl_type, evtl_message, evtl_ac_id, evtl_journ_id, evtl_comp_id, evtl_yacht_id, evtl_contact_id) ";
			Query = $"{Query}VALUES ('{StringsHelper.Format(GetDateTime(), "General Date")}', ";
			Query = $"{Query}'{strUserId}', '{inType}', ";
			Query = $"{Query}'{Fix_Quote(inText)}', ";
			Query = $"{Query}{inAC_ID.ToString()},{inJourn_ID.ToString()},{inComp_ID.ToString()},";
			Query = $"{Query}{inlYachtId.ToString()},{inlContactId.ToString()})";

			DbCommand TempCommand = null;
			TempCommand = LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

		}

		internal static void Record_Error(string inType, string inText)
		{

			string strErrDesc1 = "";
			int lErrNbr2 = 0;
			string strErrDesc2 = "";
			try
			{

				string Query = "";
				int lErrNbr1 = 0;
				string strUserId = "";
				string strUserName = "";

				//-------------------------------------------------------------
				// 10/08/2002 - By David D. Cruger
				// When the function 'GetSystemDateTime was added it cleared
				// the err.number, description.  Save these first before
				// building the query string
				//-------------------------------------------------------------
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr1 = Information.Err().Number;
				strErrDesc1 = Information.Err().Description.Substring(0, Math.Min(255, Information.Err().Description.Length)); //7/7/04 aey

				//-------------------------------------------------------------
				// 10/17/2002 - kth
				// We now put the error information into the users clipboard so
				// they can just hit "Paste" in an e-mail to us, rather than
				// sending a screen capture
				//-------------------------------------------------------------
				Clipboard.Clear();
				//UPGRADE_WARNING: (2081) Clipboard.SetText has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				Clipboard.SetText($"{lErrNbr1.ToString()} - {strErrDesc1}");

				if (Strings.Len(inText) > 2000)
				{ //Too Big
					inText = $"{inText.Substring(0, Math.Min(1990, inText.Length))}**TO BIG**";
				}

				//--------------------------------------------------------------------------
				// 07/12/2011 - By David D. Cruger
				// If Login Has Failed Then snp_User does not have any records
				// Default To Use Main Menu Field

				ReturnUserIdAndName(ref strUserId, ref strUserName);

				Query = "INSERT into ErrorLog (elog_date, elog_user_id, elog_number, elog_type, elog_description, elog_message) ";
				Query = $"{Query}VALUES (";
				Query = $"{Query}'{StringsHelper.Format(GetSystemDateTime(), "General Date")}', ";
				Query = $"{Query}'{strUserId}', ";
				Query = $"{Query}{lErrNbr1.ToString()}, ";
				Query = $"{Query}'{Fix_Quote(inType.Trim()).Substring(0, Math.Min(20, Fix_Quote(inType.Trim()).Length))}', ";
				Query = $"{Query}'{Fix_Quote(strErrDesc1)}', ";
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

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr2 = Information.Err().Number;
				strErrDesc2 = excep.Message;

				AddItemToLogFile($"{ReturnUserName()} - {strErrDesc1}");
				AddItemToLogFile($"Record_Error_Error - {strErrDesc2}");

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
				Query = "INSERT INTO Transmit (transmit_download_type, transmit_trans_type,  transmit_customer_flag, ";
				Query = $"{Query}transmit_download_flag,  transmit_ac_id, transmit_ac_ser_no_full, transmit_amwant_id, ";
				Query = $"{Query}transmit_amod_id, transmit_comp_id, transmit_journ_id, transmit_highlight_code_1, ";
				Query = $"{Query}transmit_highlight_code_2, transmit_highlight_code_3,  transmit_highlight_code_4, ";
				Query = $"{Query}transmit_highlight_code_5, transmit_highlight_code_6, transmit_highlight_code_7, ";
				Query = $"{Query}transmit_highlight_code_8,  transmit_highlight_code_9, transmit_highlight_code_10, ";
				Query = $"{Query}transmit_highlight_code_11, transmit_highlight_code_12,  transmit_highlight_code_13, ";
				Query = $"{Query}transmit_highlight_code_14, transmit_highlight_code_15, transmit_highlight_code_16, ";
				Query = $"{Query}transmit_highlight_code_17,  transmit_highlight_code_18, transmit_highlight_code_19, ";
				Query = $"{Query}transmit_change_datetime, transmit_change_user) VALUES (";
				Query = $"{Query}{($" {Record_Type}").Trim()}, "; // Type or record being written
				Query = $"{Query}'{($" {Record_Action}").Trim()}', "; // A=Add, C=Change, D=Delete
				Query = $"{Query}1, '     ', "; // unknown
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
				for (int I = 1; I <= 19; I++)
				{
					highlightall.Append(arrHighlightCodes[I].ToString());
				}
				if ((Record_Type == "1" || Record_Type == "9") && Record_Action == "Change" && Strings.Len(highlightall.ToString().Trim()) == 0)
				{
					return;
				}
				Query = $"{Query}{Aircraft_Journal_ID.ToString()}, '{arrHighlightCodes[1].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[2].ToString()}',  '{arrHighlightCodes[3].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[4].ToString()}',  '{arrHighlightCodes[5].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[6].ToString()}', '{arrHighlightCodes[7].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[8].ToString()}',  '{arrHighlightCodes[9].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[10].ToString()}', '{arrHighlightCodes[11].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[12].ToString()}', '{arrHighlightCodes[13].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[14].ToString()}', '{arrHighlightCodes[15].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[16].ToString()}',  '{arrHighlightCodes[17].ToString()}', ";
				Query = $"{Query}'{arrHighlightCodes[18].ToString()}',  '{arrHighlightCodes[19].ToString()}', ";
				Query = $"{Query}'{GetSystemDateTime()}',  '{gbl_User_ID}')";

				strError = "exec";
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
				Query = "INSERT INTO Delete_Log (dlog_type, dlog_ac_id, dlog_journ_id, dlog_comp_id, dlog_contact_id, ";
				Query = $"{Query}dlog_wanted_id, dlog_amod_id,  dlog_seq_no, dlog_priorev_id,  dlog_entry_date, ";
				Query = $"{Query}dlog_entry_user, dlog_acpic_id, dlog_feature_code)  VALUES ('";
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

				Query = $"{Query}'{GetSystemDateTime()}',  '{Convert.ToString(snp_User["user_id"])}', ";

				if (Strings.Len(inPictureID.ToString().Trim()) > 0)
				{ // acpic_id
					Query = $"{Query}{inPictureID.ToString()}, ";
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
			catch
			{

				result = false;
			}
			return result;
		}

		private static void ComputeHighlightCodes(ref string[] arrHighlightNames)
		{

			int intIndex = 0;
			string strFieldName = "";
			string strQuery = "";
			ADORecordSetHelper snpHighlight = null; //aey 8/11/05
			Array arrHighlightCodeMatrix = null;//gap-note type set manually

			try
			{

				arrHighlightCodeMatrix = Array.CreateInstance(typeof(int), new int[]{intHighGroup - intLowGroup + 1, intHighField - intLowField + 1}, new int[]{intLowGroup, intLowField});
				arrHighlightCodes = new int[intHighGroup + 1];

				intIndex = 0;


				while(intIndex <= arrHighlightNames.GetUpperBound(0))
				{
					strFieldName = arrHighlightNames[intIndex];

					strQuery = $"SELECT * FROM Transmit_highlight_codes WITH(NOLOCK) WHERE hc_name = '{strFieldName}'";

					snpHighlight = new ADORecordSetHelper();
					snpHighlight.Open(strQuery, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpHighlight.BOF && snpHighlight.EOF))
					{
						arrHighlightCodeMatrix.SetValue(Convert.ToInt32(snpHighlight["hc_value"]), Convert.ToInt32(snpHighlight["hc_group"]) - 1, Convert.ToInt32(snpHighlight["hc_field"]) - 1);//gap-note assignment set manually
					}
					intIndex++;
				};

				for (int intGroupNumber = intLowGroup; intGroupNumber <= intHighGroup; intGroupNumber++)
				{
					for (int intFieldNumber = intLowField; intFieldNumber <= intHighField; intFieldNumber++)
					{
						arrHighlightCodes[intGroupNumber] += Convert.ToInt32(arrHighlightCodeMatrix.GetValue(intGroupNumber - 1, intFieldNumber - 1)); //gap-note assignment set manually
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


		internal static void ClearAllLocksForCurrentUser(string inUserID)
		{

			bool bTrans = false;
			string strErrDesc = "";
			int lErrNbr = 0;
			string sQuery = "";

			try
			{

				if (inUserID.Trim() != "")
				{

					bTrans = true;
					UpgradeHelpers.DB.TransactionManager.Enlist(LOCAL_ADO_DB.BeginTransaction());

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

					UpgradeHelpers.DB.TransactionManager.Commit(LOCAL_ADO_DB);
					bTrans = false;

				}
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;

				if (bTrans)
				{
					UpgradeHelpers.DB.TransactionManager.Rollback(LOCAL_ADO_DB);
				}

				modAdminCommon.ADO_Transaction("RollbackTrans");
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"ClearAllLocksForCurrentUser_Error ({Information.Err().Number.ToString()}) {strErrDesc}", "modAdminCommon(CLEARLOCK)");
			}

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
				Query = $"{Query} where ac_id = {inACID.ToString()} and ac_amod_id = amfeat_amod_id";
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
				if (RuleQuery.Trim() != "")
				{

					// AUTOMATICALLY UPDATE THE FEATURE FOR THE AIRCRAFT
					Query = RuleQuery;
					Query = $"{Query} and ac_id = {inACID.ToString()}";
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
					// CLOSE RECORSET
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
				Query = $"{Query} WHERE kfeat_code = '{inFeature}' AND kfeat_auto_generate_flag = 'Y'";

				snp_FeatureCheck.Open(Query, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(snp_FeatureCheck.BOF && snp_FeatureCheck.EOF))
				{
					// THE KEY FEATURE IS AUTO GENERATE - RETURN THE QUERY FOUND
					result = ($"{Convert.ToString(snp_FeatureCheck["kfeat_query"])}").Trim();
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

			string strQuery1 = "";
			string strInsert1 = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			try
			{

				strQuery1 = "SELECT tact_table_name FROM Table_Action_Log WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (tact_table_name = '{Passed_Table_Name}') AND (tact_action_date IS NULL) ";

				rstRec1.Open(strQuery1, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (rstRec1.EOF || rstRec1.BOF)
				{

					strInsert1 = "INSERT INTO Table_Action_Log (tact_table_name,tact_action_date)";
					strInsert1 = $"{strInsert1} VALUES ('{Passed_Table_Name}',NULL)";

					DbCommand TempCommand = null;
					TempCommand = LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strInsert1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

				} // If (rstRec1.EOF = True Or rstRec1.BOF = True) Then

				rstRec1.Close();
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				Report_Error($"Table_Action_Log_Error: {excep.Message}");
			}

			return null;
		}

		internal static string DLookUp(string FldName, string RSName, string RSCriteria = "")
		{



			string result = "";
			string strQuery = "";
			ADORecordSetHelper adoData = new ADORecordSetHelper();
			string string_for_app_flag = "";

			try
			{

				result = "";

				strQuery = $"SELECT TOP 1 {FldName} FROM {RSName}";

				if (Strings.Len(($"{RSCriteria}").Trim()) > 0)
				{
					strQuery = $"{strQuery} WHERE {RSCriteria}";
				}

				// ADDED 6/14/2011 MSW - make sure that if it is an app config lookup that it checks to see which one it looks up
				if (RSName == "Application_Configuration")
				{ // if its app config look up

					if (gbl_Live_flag)
					{
						string_for_app_flag = "LIVE";
					}
					else
					{
						string_for_app_flag = "TEST";
					}


					if (Strings.Len(($"{RSCriteria}").Trim()) > 0)
					{
						strQuery = $"{strQuery} and aconfig_config_category = '{string_for_app_flag}'";
					}
					else if (Strings.Len(($"{RSCriteria}").Trim()) == 0)
					{ 
						strQuery = $"{strQuery} where aconfig_config_category = '{string_for_app_flag}'";
					}

				}

				adoData.Open(strQuery, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!adoData.BOF) && (!adoData.EOF))
				{
					result = $"{Convert.ToString(adoData[0])}";
				}

				adoData.Close();
				adoData = null;
			}
			catch
			{

				result = "";
			}

			return result;
		} // DLookUp

		internal static string ReadRegistryKeyString(int lHive, string strRegKey, string strRegKeyField)
		{

			int Zero = 0;
			int hKey = 0;
			string OrigKeyNam = "";
			object vRegKeyValue = null;

			if (lHive == 0)
			{
				lHive = HKEY_LOCAL_MACHINE;
			}

			string strResults = new string(Strings.Chr(0), 255);

			int IRetVal = JetNetSupport.PInvoke.SafeNative.advapi32.RegOpenKeyEx(lHive, ref strRegKey, Zero, KEY_ALL_ACCESS, ref hKey);
			int tempRefParam = REG_SZ;
			int tempRefParam2 = 255;
			IRetVal = JetNetSupport.PInvoke.SafeNative.advapi32.RegQueryValueExString(hKey, ref strRegKeyField, 0, ref tempRefParam, ref strResults, ref tempRefParam2);
			JetNetSupport.PInvoke.SafeNative.advapi32.RegCloseKey(hKey);

			strResults = strResults;
			int iPos1 = (strResults.IndexOf(Strings.Chr(0).ToString()) + 1);
			strResults = strResults.Substring(0, Math.Min(iPos1 - 1, strResults.Length));

			return strResults;

		} // End Function ReadRegistryKeyString

		internal static void OpenURLInInternetExplorerObject(string strURL)
		{

			dynamic objIE = null;//gap-note type must be defined in during Blazor app stabilization


			if (strURL != "")
			{
				ErrorHandlingHelper.ResumeNext(
						//UPGRADE_WARNING: (7008) The ProgId could not be found on computer where this application was migrated More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7008
					() => {objIE = Activator.CreateInstance(Type.GetTypeFromProgID("internetexplorer.application"));}, 
						//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					() => {objIE.Visible = true;}, 
						//UPGRADE_TODO: (1067) Member Navigate is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					() => {objIE.Navigate(strURL);});
			}

		} // OpenURLInInternetExplorerObject


		internal static void OpenURLInInternetExplorer(string strURL)
		{

			dynamic objIE = null;//gap-note type must be defined in during Blazor app stabilization
			string strIE = "";


			if (strURL != "")
			{
				try
				{

					strIE = ReadRegistryKeyString(HKEY_CLASSES_ROOT, "Applications\\iexplore.exe\\shell\\open\\command", "");
				}
				catch
				{
				}
				if (strIE != "")
				{
					ProcessStartInfo startInfo = default(System.Diagnostics.ProcessStartInfo);
					ErrorHandlingHelper.ResumeNext(
						() => {strIE = StringsHelper.Replace(strIE, "\"", "", 1, -1, CompareMethod.Binary);}, 
						() => {strIE = StringsHelper.Replace(strIE, "%1", strURL, 1, -1, CompareMethod.Binary);}, 
							//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
						() => {startInfo = new ProcessStartInfo(strIE);}, 
						() => {startInfo.WindowStyle = ProcessWindowStyle.Normal;}, 
						() => {Process.Start(startInfo);});
				}
				else
				{
					ErrorHandlingHelper.ResumeNext(
							//UPGRADE_WARNING: (7008) The ProgId could not be found on computer where this application was migrated More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7008
						() => {objIE = Activator.CreateInstance(Type.GetTypeFromProgID("internetexplorer.application"));}, 
							//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						() => {objIE.Visible = true;}, 
							//UPGRADE_TODO: (1067) Member Navigate is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						() => {objIE.Navigate(strURL);});
				}

			} // If strURL <> "" Then

		} // OpenURLInInternetExplorer

		internal static void OpenURLInChrome(string strURL)
		{

			string strChrome = "";


			if (strURL != "")
			{
				try
				{

					strChrome = ReadRegistryKeyString(HKEY_CLASSES_ROOT, "Applications\\chrome.exe\\shell\\open\\command", "");
				}
				catch
				{
				}
				if (strChrome == "")
				{
					try
					{
						strChrome = ReadRegistryKeyString(HKEY_CLASSES_ROOT, "ChromeHTML\\shell\\open\\command", "");
					}
					catch
					{
					}
				}
				if (strChrome != "")
				{
					ProcessStartInfo startInfo = default(System.Diagnostics.ProcessStartInfo);
					ErrorHandlingHelper.ResumeNext(
						() => {strChrome = StringsHelper.Replace(strChrome, "\"", "", 1, -1, CompareMethod.Binary);}, 
						() => {strChrome = StringsHelper.Replace(strChrome, "-- %1", strURL, 1, -1, CompareMethod.Binary);}, 
							//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
						() => {startInfo = new ProcessStartInfo(strChrome);}, 
						() => {startInfo.WindowStyle = ProcessWindowStyle.Normal;}, 
						() => {Process.Start(startInfo);});
				}
				else
				{
					try
					{
						MessageBox.Show("Unable To Find Google Chrome", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					catch
					{
					}
				}

			} // If strURL <> "" Then

		} // OpenURLInChrome



		internal static void OpenURLInFireFox(string strURL)
		{

			string strFirefox = "";


			if (strURL != "")
			{
				try
				{

					strFirefox = ReadRegistryKeyString(HKEY_CLASSES_ROOT, "FirefoxHTML\\shell\\open\\command", "");
				}
				catch
				{
				}
				if (strFirefox != "")
				{
					ProcessStartInfo startInfo = default(System.Diagnostics.ProcessStartInfo);
					ErrorHandlingHelper.ResumeNext(
						() => {strFirefox = StringsHelper.Replace(strFirefox, "\"", "", 1, -1, CompareMethod.Binary);}, 
						() => {strFirefox = StringsHelper.Replace(strFirefox, "%1", strURL, 1, -1, CompareMethod.Binary);}, 
							//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
						() => {startInfo = new ProcessStartInfo(strFirefox);}, 
						() => {startInfo.WindowStyle = ProcessWindowStyle.Normal;}, 
						() => {Process.Start(startInfo);});
				}
				else
				{
					try
					{
						MessageBox.Show("Unable To Find Morzilla Firefox", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					catch
					{
					}
				}

			} // If strURL <> "" Then

		} // OpenURLInFireFox

		internal static void OpenURLInBrowser(string strURL) => ShellOpenURLInBrowser(gbl_User_Browser, strURL);
		 // OpenURLInBrowser


		internal static void ShellOpenURLInBrowser(string strBrowser, string strURL)
		{

			object objIE = null; // If All Else Fails
			string strBrowserCmd = "";
			string strBrowserName = "";
			string strMozilla = "";
			string strChrome = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			try
			{

				if (strBrowser == "")
				{
					strBrowser = "I";
				}

				if (strURL != "")
				{


					switch(strBrowser)
					{
						case "D" : case "Default" : 
							 
							strBrowserName = "Default"; 
							strBrowserCmd = ""; 
							 
							break;
						case "I" : case "Explorer" : case "Internet Explorer" : case "IE" :  // Internet Explorer 
							 
							// Default: "C:\Program Files\Internet Explorer\IEXPLORE.EXE" %1 
							strBrowserName = "Internet Explorer"; 
							 
							strBrowserCmd = ReadRegistryKeyString(HKEY_CLASSES_ROOT, "Applications\\iexplore.exe\\shell\\open\\command", ""); 
							strBrowserCmd = StringsHelper.Replace(strBrowserCmd, "%1", strURL, 1, -1, CompareMethod.Binary); 
							 
							break;
						case "M" : case "Firefox" : case "Mozilla" : case "Mozilla Firefox" :  // Mozilla 
							 
							// Default: "C:\Program Files\Mozilla Firefox\firefox.exe" -osint -url "%1" 
							strBrowserName = "Mozilla Firefox"; 
							 
							strBrowserCmd = ReadRegistryKeyString(HKEY_CLASSES_ROOT, "FirefoxHTML\\shell\\open\\command", ""); 
							 
							if (strBrowserCmd != "")
							{
								strURL = StringsHelper.Replace(strURL, "\"", "", 1, -1, CompareMethod.Binary);
								strBrowserCmd = StringsHelper.Replace(strBrowserCmd, "%1", strURL, 1, -1, CompareMethod.Binary);
							} 
							 
							break;
						case "C" : case "Chrome" : case "Google Chrome" :  // Chrome 
							 
							// Default: "C:\Documents and Settings\TECHPC03\Local Settings\Application Data\Google\Chrome\Application\chrome.exe" -- "%1" 
							strBrowserName = "Google Chrome"; 
							strBrowserCmd = ReadRegistryKeyString(HKEY_CLASSES_ROOT, "Applications\\chrome.exe\\shell\\open\\command", ""); 
							if (strBrowserCmd == "")
							{
								strBrowserCmd = ReadRegistryKeyString(HKEY_CLASSES_ROOT, "ChromeHTML\\shell\\open\\command", "");
							} 
							 
							if (strBrowserCmd != "")
							{
								strURL = StringsHelper.Replace(strURL, "\"", "", 1, -1, CompareMethod.Binary);
								strBrowserCmd = StringsHelper.Replace(strBrowserCmd, " -- ", " --new-window --app=", 1, -1, CompareMethod.Binary);
								strBrowserCmd = StringsHelper.Replace(strBrowserCmd, "%1", strURL, 1, -1, CompareMethod.Binary);
							} 
							 
							break;
					} // Case strBrowser

					if (strBrowserCmd != "")
					{

						// Constant         Value  Description
						// vbHide             0    Window is hidden and focus is passed to the hidden window.
						// vbNormalFocus      1    Window has focus and is restored to its original size and position.
						// vbMinimizedFocus   2    Window is displayed as an icon with focus.
						// vbMaximizedFocus   3    Window is maximized with focus.
						// vbNormalNoFocus    4    Window is restored to its most recent size and position. The currently active window remains active.
						// vbMinimizedNoFocus 6

						//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
						ProcessStartInfo startInfo = new ProcessStartInfo(strBrowserCmd);
						startInfo.WindowStyle = ProcessWindowStyle.Normal;
						Process.Start(startInfo);

					}
					else
					{

						if ((strURL.IndexOf("http") + 1) == 0 && strURL.StartsWith("www", StringComparison.Ordinal))
						{
							strURL = $"http://{strURL}";
						}
						//UPGRADE_WARNING: (2081) ShellExecuteA has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						ProcessStartInfo startInfo2 = new ProcessStartInfo();
						startInfo2.UseShellExecute = true;
						startInfo2.CreateNoWindow = false;
						startInfo2.Verb = "open";
						startInfo2.FileName = strURL;
						startInfo2.Arguments = "";
						startInfo2.WorkingDirectory = "";
						startInfo2.WindowStyle = ProcessWindowStyle.Normal;
						Process shellExecuteProcess = Process.Start(startInfo2);
						int tempAuxVar = shellExecuteProcess.ExitCode;

					}

				} // If strURL <> "" Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				Report_Error($"ShellOpenURLInBrowser_Error: {strErrDesc}");
			}

		} // ShellOpenURLInBrowser

		internal static void BuildLatLongFull(ref string strFull, string strDirection, string strDegrees, string strMinutes, string strSeconds)
		{

			// http://boulter.com/gps

			strFull = "";
			if (strDirection != "")
			{
				if (strDirection == "U")
				{
					strDirection = "W";
				}
				strFull = strDirection;
			}

			if (strDegrees != "")
			{
				strFull = $"{strFull}{StringsHelper.Format(strDegrees, "000")} ";
			}

			if (strMinutes != "")
			{
				strFull = $"{strFull}{StringsHelper.Format(strMinutes, "000")}.";
			}

			if (strSeconds != "")
			{
				strFull = $"{strFull}{StringsHelper.Format(strSeconds, "000")}";
			}

		} // BuildLatLongFull

		internal static string ReturnYesNo(string strYN)
		{

			strYN = strYN.Substring(0, Math.Min(1, strYN.Length)).ToUpper();

			switch(strYN)
			{
				case "Y" : 
					strYN = "Yes"; 
					break;
				case "N" : 
					strYN = "No"; 
					break;
			}

			return strYN;

		} // ReturnYesNo

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

		internal static string Get_Name_Search_String(string strTemp)
		{

			StringBuilder strResults = new StringBuilder();
			string strWork = strTemp;
			int iTest = 0;

			if (Strings.Len(strTemp) > 0)
			{
				strWork = strTemp.ToUpper();
				int tempForEndVar = Strings.Len(strTemp);
				for (int iZ1 = 1; iZ1 <= tempForEndVar; iZ1++)
				{
					iTest = Strings.Asc(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1))))[0]);
					if (((iTest >= 65) && (iTest <= 90)) || ((iTest >= 48) && (iTest <= 57)))
					{
						strResults.Append(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1)))));
					}
				}
			} // Len(strTemp) > 0

			return strResults.ToString();

		}

		internal static void CenterFormOnMainForm(Form frmMain, Form frmForm)
		{

			frmForm.Top = Convert.ToInt32(frmMain.Top + ((frmMain.Height - frmForm.Height) / 2d));
			frmForm.Left = Convert.ToInt32(frmMain.Left + ((frmMain.Width - frmForm.Width) / 2d));

		}

		internal static void BuildPhoneNumberFull(string strCountryCode, string strAreaCode, string strPrefix, string strPhoneNumber, ref string strPhoneFull, ref string strPhoneSearch)
		{

			strPhoneFull = "";
			strPhoneSearch = "";

			if (strCountryCode.Trim() != "")
			{
				strPhoneFull = $"{strPhoneFull}{strCountryCode.Trim()}-";
			}
			if (strAreaCode.Trim() != "")
			{
				strPhoneFull = $"{strPhoneFull}{strAreaCode.Trim()}-";
			}
			if (strPrefix.Trim() != "")
			{
				strPhoneFull = $"{strPhoneFull}{strPrefix.Trim()}-";
			}
			if (strPhoneNumber.Trim() != "")
			{
				strPhoneFull = $"{strPhoneFull}{strPhoneNumber.Trim()}-";
			}

			if (strPhoneFull.Substring(Math.Max(strPhoneFull.Length - 1, 0)) == "-")
			{
				strPhoneFull = strPhoneFull.Substring(0, Math.Min(Strings.Len(strPhoneFull) - 1, strPhoneFull.Length));
			}

			strPhoneSearch = StringsHelper.Replace(strPhoneFull, " ", "", 1, -1, CompareMethod.Binary);
			strPhoneSearch = StringsHelper.Replace(strPhoneSearch, "-", "", 1, -1, CompareMethod.Binary);

		} // BuildPhoneNumberFull

		internal static void SetComboBox(ComboBox cmbBox, string strValue)
		{


			cmbBox.Text = "";
			cmbBox.SelectedIndex = 0;

			int lCnt1 = -1;
			do 
			{

				lCnt1++;

				if (cmbBox.GetListItem(lCnt1) == strValue)
				{
					cmbBox.Text = cmbBox.GetListItem(lCnt1);
					cmbBox.SelectedIndex = lCnt1;
				}

			}
			while(!(lCnt1 >= cmbBox.Items.Count - 1 || cmbBox.SelectedIndex > 0));

		} // SetComboBox

		internal static void SetComboBoxByItemData(ComboBox cmbBox, int lItemData)
		{


			//cmbBox.Text = ""
			cmbBox.SelectedIndex = 0;

			int lCnt1 = -1;
			do 
			{

				lCnt1++;

				if (cmbBox.GetItemData(lCnt1) == lItemData)
				{
					//cmbBox.Text = cmbBox.List(lCnt1)
					cmbBox.SelectedIndex = lCnt1;
				}

			}
			while(!(lCnt1 >= cmbBox.Items.Count - 1 || cmbBox.SelectedIndex > 0));

		} // SetComboBoxByItemData

		internal static string LeaveOnlyAlphaAndNumeric(string strKey)
		{

			string strChar = "";
			int iTest = 0;
			int iPos1 = 0;
			int iLen1 = 0;

			strKey = ($"{strKey} ").Trim();
			string strResults = "";
			StringBuilder strTemp = new StringBuilder();

			if (Strings.Len(strKey) > 0)
			{

				iPos1 = 0;
				iLen1 = Strings.Len(strKey);

				do 
				{
					iPos1++;
					strChar = strKey.Substring(Math.Min(iPos1 - 1, strKey.Length), Math.Min(1, Math.Max(0, strKey.Length - (iPos1 - 1))));
					if ((String.CompareOrdinal(strChar, "a") >= 0 && String.CompareOrdinal(strChar, "z") <= 0) || (String.CompareOrdinal(strChar, "A") >= 0 && String.CompareOrdinal(strChar, "Z") <= 0) || (Information.IsNumeric(strChar)))
					{
						strTemp.Append(strChar);
					}
				}
				while(iPos1 < iLen1);

				strResults = strTemp.ToString();

			} // Len(strKey) > 0

			return strResults;

		} // LeaveOnlyAlphaAndNumeric


		internal static string CreateNewAVDataId()
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lAVDataId = 0;
			string strResults = "";

			try
			{

				strResults = "";

				strQuery1 = "EXEC HomebaseQueryGetNextAVDataKey";
				rstRec1.Open(strQuery1, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{
					lAVDataId = Convert.ToInt32(rstRec1["next_avdatakey"]);
					strResults = $"ADS{lAVDataId.ToString()}";
				}

				rstRec1.Close();
				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				Report_Error($"CreateNewAVDataId_Error: {Information.Err().Number.ToString()} {excep.Message}");

				result = "";
			}
			return result;
		} // CreateNewAVDataId

		internal static void Start_Activity_Monitor_Message(string strType, ref string strMsg, ref System.DateTime dtStartDate, ref System.DateTime dtEndDate)
		{

			// This routine just sets all the values to a default state

			strMsg = "";
			dtStartDate = DateTime.Now;
			dtEndDate = DateTime.FromOADate(0);

		} // Start_Activity_Monitor_Message

		internal static void End_Activity_Monitor_Message(string strType, ref string strMsg, System.DateTime dtStartDate, ref System.DateTime dtEndDate, int lACId, int lJournId, int lCompId, int lYachtId, int lContactId)
		{

			string strInsert1 = "";
			string strUserId = "";

			if (lACId < 0)
			{
				lACId = 0;
			}
			if (lJournId < 0)
			{
				lJournId = 0;
			}
			if (lCompId < 0)
			{
				lCompId = 0;
			}
			if (lYachtId < 0)
			{
				lYachtId = 0;
			}
			if (lContactId < 0)
			{
				lContactId = 0;
			}

			dtEndDate = DateTime.Now;
			int lElapsedTime = (int) DateAndTime.DateDiff("s", dtStartDate, dtEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1); // Seconds

			strMsg = $"{strType}: " +
			         $"Start Time: {dtStartDate.ToString("HH:mm:ss")} " +
			         $"End Time: {dtEndDate.ToString("HH:mm:ss")} " +
			         $"Elapsed Time: {StringsHelper.Format(lElapsedTime, "#,##0")} seconds " +
			         $"({gbl_User_ID})-({gbl_Account_ID}) " +
			         $"{strMsg}";

			if (($"{Convert.ToString(snp_User["user_monitor_activity_flag"])} ").Trim() == "Y")
			{
				Record_Event("Monitor Activity", strMsg, lACId, lJournId, lCompId, false, lYachtId, lContactId);
			}

		} // End_Activity_Monitor_Message

		internal static void Clear_Grid_Row(UpgradeHelpers.DataGridViewFlex gGrid)
		{

			gGrid.CurrentRowIndex = gGrid.FixedRows;
			gGrid.CurrentColumnIndex = gGrid.FixedColumns;
			gGrid.HighLight = UpgradeHelpers.HighLightSettings.HighlightNever;

		} // Clear_Grid_Row

		internal static void Highlight_Grid_Row(UpgradeHelpers.DataGridViewFlex gGrid, int lStartingColumn = 0)
		{

			try
			{

				gGrid.HighLight = UpgradeHelpers.HighLightSettings.HighlightAlways;
				if (gGrid.FixedColumns > 0)
				{
					if (lStartingColumn == 0)
					{
						gGrid.CurrentColumnIndex = gGrid.FixedColumns - 1;
					}
					else
					{
						gGrid.CurrentColumnIndex = lStartingColumn;
					}
				}
				else
				{
					if (lStartingColumn == 0)
					{
						gGrid.CurrentColumnIndex = gGrid.FixedColumns;
					}
					else
					{
						gGrid.CurrentColumnIndex = lStartingColumn;
					}
				}
				gGrid.ColSel = gGrid.ColumnsCount - 1;
			}
			catch (System.Exception excep)
			{

				Report_Error("Highlight_Grid_Row_Error", excep.Message);
			}

		} // Highlight_Grid_Row

		internal static void SetColorVariables()
		{

			NormalColor = (0x80000008).ToString();
			PrimaryColor = (0xC0FFFF).ToString();
			ConfirmColor = (0xC0C0FF).ToString();
			ForSaleColor = (0xC0FFC0).ToString();
			InactiveColor = (0xE0E0E0).ToString();
			NoColor = (0xFFFFFF).ToString();
			HeadingColor = (0x8000000F).ToString();
			ExclusiveColor = (0xFFC0C0).ToString();
			LeaseColor = (0x5BADFF).ToString();
			HiddenColor = (0xFF).ToString();

			ClassAColor = ColorTranslator.ToOle(Color.Cyan).ToString();
			ClassBColor = ColorTranslator.ToOle(Color.Magenta).ToString();
			ClassCColor = ColorTranslator.ToOle(SystemColors.GrayText).ToString();
			ClassDColor = ColorTranslator.ToOle(Color.Red).ToString();

		} // SetColorVariables

		internal static void Return_Company_Name(int lCompId, ref string strCompany)
		{

			strCompany = "";
			if (lCompId > 0)
			{
				strCompany = DLookUp("comp_name", "Company", $"(comp_id = {lCompId.ToString()}) AND (comp_journ_id = 0) ");
			}

		} // Return_Company_Name

		internal static void Test_TextBox_For_Numeric(TextBox txtBox, string strLabel)
		{

			int lTextBox = 0;

			string strTextBox = txtBox.Text.Trim();

			if (strTextBox != "")
			{

				if (Information.IsNumeric(strTextBox))
				{

					lTextBox = Convert.ToInt32(Double.Parse(strTextBox));

					if (lTextBox < 0)
					{
						MessageBox.Show($"{strTextBox} Must Be Greater or Equal To Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						txtBox.Text = "0";
					} // If lTextBox < 0 Then

				}
				else
				{
					MessageBox.Show($"{strTextBox} Must Be Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtBox.Text = "0";
				} // If IsNumeric(strTextBox) = True Then

			}
			else
			{
				MessageBox.Show($"{strTextBox} Cannot Be Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtBox.Text = "0";
			} // If strTextBox <> "" Then

		} // Test_TextBox_For_Numeric

		internal static string BuildEngineModelName(string strPrefix, string strCore, string strSuffix1, string strSuffix2)
		{


			string strResults = "";

			strResults = ($"{strPrefix.Trim()}{strCore.Trim()}{strSuffix1.Trim()}{strSuffix2.Trim()}").Substring(0, Math.Min(20, ($"{strPrefix.Trim()}{strCore.Trim()}{strSuffix1.Trim()}{strSuffix2.Trim()}").Length));

			return strResults;

		} // BuildEngineModelName

		internal static bool Is_Engine_Model_A_Duplicate(string strEngineName)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTotCnt = 0;
			bool bResults = false;

			try
			{

				bResults = false;

				strEngineName = strEngineName.Trim();

				if (strEngineName != "")
				{

					strQuery1 = "SELECT COUNT(em_id) As TotCnt FROM Engine_Models WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (em_engine_name = '{StringsHelper.Replace(strEngineName, "'", "''", 1, -1, CompareMethod.Binary)}') ";

					rstRec1.Open(strQuery1, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					lTotCnt = 0;
					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

					if (lTotCnt > 1)
					{
						bResults = true;
					}

				} // If strEngineName <> "" Then

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				Record_Error("Is_Engine_Model_A_Duplicate_Error", excep.Message);

				result = false;
			}
			return result;
		} // Is_Engine_Model_A_Duplicate

		internal static string Return_User_Names_By_User_Id_List(string strUserIdList)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strResults = "";

			try
			{

				strResults = "";

				strUserIdList = strUserIdList.Trim();

				if (strUserIdList != "")
				{

					strUserIdList = $"'{StringsHelper.Replace(strUserIdList, ",", "','", 1, -1, CompareMethod.Binary)}'";

					strQuery1 = "SELECT user_first_name, user_last_name FROM [User] WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (user_id IN ({strUserIdList})) AND (user_password <> 'Inactive') ";
					strQuery1 = $"{strQuery1}ORDER BY user_first_name, user_last_name ";

					rstRec1.Open(strQuery1, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						do 
						{ // Loop Until rstRec1.EOF = True

							strResults = $"{strResults}{($"{Convert.ToString(rstRec1["user_first_name"])} ").Trim()} {($"{Convert.ToString(rstRec1["user_last_name"])} ").Trim()}, ";
							rstRec1.MoveNext();

						}
						while(!rstRec1.EOF);

						strResults = strResults.Substring(0, Math.Min(Strings.Len(strResults) - 2, strResults.Length)); // Remove Last Comma/Space

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strUserIdList <> "" Then

				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				Record_Error("Return_User_Names_By_User_Id_List_Error", excep.Message);

				result = "";
			}
			return result;
		} // Return_User_Names_By_User_Id_List

		internal static void Load_Team_Leaders_Report_Combo(ComboBox cmbBox)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbBox.Items.Clear();
				cmbBox.AddItem("");

				strQuery1 = "SELECT DISTINCT ur_report_name FROM User_Reports WITH (NOLOCK) ORDER BY ur_report_name ";

				rstRec1.Open(strQuery1, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbBox.AddItem(($"{Convert.ToString(rstRec1["ur_report_name"])} ").Trim());
						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				Record_Error("Load_Team_Leaders_Report_Combo_Error", excep.Message);
			}

		} // Load_Team_Leaders_Report_Combo

		internal static string ReturnTeamUserIdsByTeamLeaderAndReportName(string strUserId, string strReport, ref bool bActive)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strResults = "";

			try
			{

				strResults = "";
				bActive = false;

				if (strUserId != "" && strReport != "")
				{

					strQuery1 = "SELECT ur_team_leader_team, ur_active_flag FROM User_Reports WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (ur_user_id = '{strUserId}') AND (ur_report_name = '{strReport}') ";

					rstRec1.Open(strQuery1, LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						strResults = ($"{Convert.ToString(rstRec1["ur_team_leader_team"])} ").Trim();
						if (($"{Convert.ToString(rstRec1["ur_active_flag"])} ").Trim() == "Y")
						{
							bActive = true;
						}
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strUserId <> "" And strReport <> "" Then

				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				Record_Error("ReturnTeamUserIdsByTeamLeaderAndReportName_Error", excep.Message);

				result = "";
			}
			return result;
		} // ReturnTeamUserIdsByTeamLeaderAndReportName

		internal static bool Open_FAA_FLightData_Database(ref DbConnection cntConn)
		{

			bool result = false;
			string strConn = "";

			string strServer = "";
			string strDatabase = "";
			string strUserName = "";
			string strPassword = "";

			bool bResults = false;

			try
			{

				bResults = false;

				strServer = DLookUp("aconfig_faaflight_server", "Application_Configuration");
				strDatabase = DLookUp("aconfig_faaflight_database", "Application_Configuration");
				strUserName = DLookUp("aconfig_faaflight_username", "Application_Configuration");
				strPassword = DLookUp("aconfig_faaflight_password", "Application_Configuration");

				strConn = $"Provider=SQLOLEDB;Data Source={strServer}INITIAL CATALOG={strDatabase};UID={strUserName};PWD={strPassword}";

				// If Connection Is Already Open Close It

				if (cntConn != null)
				{
					if (cntConn.State == ConnectionState.Open)
					{
						UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
						cntConn.Close();
					}
					cntConn = null;
				}

				cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
				//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cntConn.setCursorLocation(CursorLocationEnum.adUseServer);
				cntConn.ConnectionString = strConn;
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, 300);
				//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
				cntConn.Open();

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				Record_Error("Open_FAA_FLightData_Database_Error", excep.Message);

				result = false;
			}
			return result;
		} // Open_FAA_FLightData_Database

		internal static bool Close_FAA_FLightData_Database(ref DbConnection cntConn)
		{

			bool result = false;
			bool bResults = false;

			try
			{

				bResults = false;

				if (cntConn != null)
				{
					if (cntConn.State == ConnectionState.Open)
					{
						UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
						cntConn.Close();
					}
					cntConn = null;
				}

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				Record_Error("Close_FAA_FLightData_Database_Error", excep.Message);

				result = false;
			}
			return result;
		} // Close_FAA_FLightData_Database

		internal static int Update_FAA_Flight_Data_Clear_APort_Id_Distance_In_Batch_Mode(DbConnection cntConn, Label lLabel, int lAPortId, bool bOriginAPort, ref int lTop, ref int lLoopMax)
		{

			int result = 0;
			string strUpdate1 = "";

			int lLoop1 = 0;
			int lCnt1 = 0;
			int lTot1 = 0;
			int lCTimeout = 0;
			bool bTrans = false;
			string strErrDesc = "";
			int lResults = 0;

			try
			{

				lResults = 0;
				lLoop1 = 0;
				lTot1 = 0;
				lCnt1 = 0;

				if (lAPortId > 0)
				{

					lCTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(cntConn);
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, 300);

					if (lTop <= 0)
					{
						lTop = 15000;
					}
					if (lLoopMax <= 0)
					{
						lLoopMax = 5000;
					}

					strUpdate1 = $"UPDATE TOP ({lTop.ToString()}) FAA_Flight_Data  SET ffd_distance = 0, ";

					if (bOriginAPort)
					{
						strUpdate1 = $"{strUpdate1}ffd_action_date = '1/1/1911',  ffd_origin_aport_id = 0 ";
						strUpdate1 = $"{strUpdate1}WHERE (ffd_origin_aport_id = {lAPortId.ToString()} OR ffd_dest_aport_id = {lAPortId.ToString()}) ";
						strUpdate1 = $"{strUpdate1}AND (ffd_action_date <> '1/1/1911') ";
					}
					else
					{
						strUpdate1 = $"{strUpdate1}ffd_action_date = '1/2/1911',  ffd_dest_aport_id = 0 ";
						strUpdate1 = $"{strUpdate1}WHERE (ffd_dest_aport_id = {lAPortId.ToString()}) ";
						strUpdate1 = $"{strUpdate1}AND (ffd_action_date <> '1/2/1911') ";
					}

					do 
					{ // Loop Until lCnt1 <= 0

						bTrans = true;
						UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());
						DbCommand TempCommand = null;
						TempCommand = cntConn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						lCnt1 = TempCommand.ExecuteNonQuery();
						UpgradeHelpers.DB.TransactionManager.Commit(cntConn);
						bTrans = false;

						lTot1 += lCnt1;
						if (lCnt1 > 0)
						{
							JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(500);
						}

						lLoop1++;
						lLabel.Text = $"Updating APortId: {lAPortId.ToString()} - Records: {StringsHelper.Format(lTot1, "#,##0")}";
						Application.DoEvents();

					}
					while(!(lCnt1 <= 0 || lCnt1 < lTop || lLoop1 >= lLoopMax));

					lResults = lTot1;

					if (lLoop1 >= lLoopMax)
					{
						lResults = -1;
						lLabel.Text = $"Updating APortId: {lAPortId.ToString()} - Records: {StringsHelper.Format(lTot1, "#,##0")} - Failed MaxLoop Exceeded: {StringsHelper.Format(lLoop1, "#,##0")}";
					}
					else
					{
						lLabel.Text = $"Updating APortId: {lAPortId.ToString()} - Records: {StringsHelper.Format(lTot1, "#,##0")} - Completed";
					}

					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, lCTimeout);

				} // If lAPortId > 0 Then


				return lResults;
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;

				if (bTrans)
				{
					UpgradeHelpers.DB.TransactionManager.Rollback(cntConn);
				}

				Record_Error("Update_FAA_Flight_Data_Clear_APort_Id_Distance_In_Batch_Mode_Error", strErrDesc);

				result = -1;
			}
			return result;
		}

		internal static int Update_FAA_Flight_Data_Clear_APort_Id_Distance_In_Batch_Mode(DbConnection cntConn, Label lLabel, int lAPortId, bool bOriginAPort, ref int lTop)
		{
			int tempRefParam = 5000;
			return Update_FAA_Flight_Data_Clear_APort_Id_Distance_In_Batch_Mode(cntConn, lLabel, lAPortId, bOriginAPort, ref lTop, ref tempRefParam);
		}

		internal static int Update_FAA_Flight_Data_Clear_APort_Id_Distance_In_Batch_Mode(DbConnection cntConn, Label lLabel, int lAPortId, bool bOriginAPort)
		{
			int tempRefParam2 = 5000;
			int tempRefParam3 = 5000;
			return Update_FAA_Flight_Data_Clear_APort_Id_Distance_In_Batch_Mode(cntConn, lLabel, lAPortId, bOriginAPort, ref tempRefParam2, ref tempRefParam3);
		} // Update_FAA_Flight_Data_Clear_APort_Id_Distance_In_Batch_Mode

		internal static int Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode(DbConnection cntConn, Label lLabel, int lAPortId, string strAPortCode, bool bOriginAPort, ref int lTop, ref int lLoopMax)
		{

			int result = 0;
			string strUpdate1 = "";

			int lLoop1 = 0;
			int lCnt1 = 0;
			int lTot1 = 0;
			int lCTimeout = 0;
			bool bTrans = false;
			string strErrDesc = "";
			int lResults = 0;

			try
			{

				lResults = 0;
				lLoop1 = 0;
				lTot1 = 0;
				lCnt1 = 0;

				if (lAPortId > 0 && strAPortCode != "")
				{

					lCTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(cntConn);
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, 300);

					if (lTop <= 0)
					{
						lTop = 15000;
					}
					if (lLoopMax <= 0)
					{
						lLoopMax = 5000;
					}

					strUpdate1 = $"UPDATE TOP ({lTop.ToString()}) FAA_Flight_Data ";

					if (bOriginAPort)
					{
						strUpdate1 = $"{strUpdate1}SET ffd_action_date = '1/1/1911', ";
					}
					else
					{
						strUpdate1 = $"{strUpdate1}SET ffd_action_date = '1/2/1911', ";
					}

					if (bOriginAPort)
					{
						strUpdate1 = $"{strUpdate1}ffd_origin_aport_id = {lAPortId.ToString()} ";
						strUpdate1 = $"{strUpdate1}WHERE (ffd_origin_aport = '{strAPortCode}') AND (ffd_origin_aport_id = 0) ";
					}
					else
					{
						strUpdate1 = $"{strUpdate1}ffd_dest_aport_id = {lAPortId.ToString()} ";
						strUpdate1 = $"{strUpdate1}WHERE (ffd_dest_aport = '{strAPortCode}') AND (ffd_dest_aport_id = 0) ";
					}

					do 
					{ // Loop Until lCnt1 <= 0

						bTrans = true;
						UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());
						DbCommand TempCommand = null;
						TempCommand = cntConn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						lCnt1 = TempCommand.ExecuteNonQuery();
						UpgradeHelpers.DB.TransactionManager.Commit(cntConn);
						bTrans = false;

						lTot1 += lCnt1;
						if (lCnt1 > 0)
						{
							JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(500);
						}

						lLoop1++;
						lLabel.Text = $"Updating APortCode: {strAPortCode} - APortId: {lAPortId.ToString()} - Records: {StringsHelper.Format(lTot1, "#,##0")}";
						Application.DoEvents();

					}
					while(!(lCnt1 <= 0 || lCnt1 < lTop || lLoop1 >= lLoopMax));

					lResults = lTot1;

					if (lLoop1 >= lLoopMax)
					{
						lResults = -1;
						lLabel.Text = $"Updating APortCode: {strAPortCode} - APortId: {lAPortId.ToString()} - Records: {StringsHelper.Format(lTot1, "#,##0")} - Failed MaxLoop Exceeded: {StringsHelper.Format(lLoop1, "#,##0")}";
					}
					else
					{
						lLabel.Text = $"Updating APortCode: {strAPortCode} - APortId: {lAPortId.ToString()} - Records: {StringsHelper.Format(lTot1, "#,##0")} - Completed";
					}

					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, lCTimeout);

				} // If lAPortId > 0 Then


				return lResults;
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;

				if (bTrans)
				{
					UpgradeHelpers.DB.TransactionManager.Rollback(cntConn);
				}

				Record_Error("Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode_Error", strErrDesc);

				result = -1;
			}
			return result;
		}

		internal static int Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode(DbConnection cntConn, Label lLabel, int lAPortId, string strAPortCode, bool bOriginAPort, ref int lTop)
		{
			int tempRefParam4 = 5000;
			return Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode(cntConn, lLabel, lAPortId, strAPortCode, bOriginAPort, ref lTop, ref tempRefParam4);
		}

		internal static int Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode(DbConnection cntConn, Label lLabel, int lAPortId, string strAPortCode, bool bOriginAPort)
		{
			int tempRefParam5 = 5000;
			int tempRefParam6 = 5000;
			return Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode(cntConn, lLabel, lAPortId, strAPortCode, bOriginAPort, ref tempRefParam5, ref tempRefParam6);
		} // Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode

		internal static int Update_FAA_Flight_Data_Distance_By_APort_Id_In_Batch_Mode(DbConnection cntConn, Label lLabel, int lAPortId, bool bOriginAPort, ref int lTop, ref int lLoopMax)
		{

			int result = 0;
			string strUpdate1 = "";

			int lLoop1 = 0;
			int lCnt1 = 0;
			int lTot1 = 0;
			int lCTimeout = 0;
			bool bTrans = false;
			string strErrDesc = "";
			int lResults = 0;

			try
			{

				lResults = 0;
				lLoop1 = 0;
				lTot1 = 0;
				lCnt1 = 0;

				if (lAPortId > 0)
				{

					lCTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(cntConn);
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, 300);

					if (lTop <= 0)
					{
						lTop = 15000;
					}
					if (lLoopMax <= 0)
					{
						lLoopMax = 5000;
					}

					strUpdate1 = $"UPDATE TOP ({lTop.ToString()}) FAA_Flight_Data ";

					if (bOriginAPort)
					{
						strUpdate1 = $"{strUpdate1}SET ffd_action_date = '1/1/1911', ";
					}
					else
					{
						strUpdate1 = $"{strUpdate1}SET ffd_action_date = '1/2/1911', ";
					}

					strUpdate1 = $"{strUpdate1}ffd_distance = CAST(dbo.ConvertLatitudeLongitudeToMiles( ";
					strUpdate1 = $"{strUpdate1}(SELECT TOP 1 aport_latitude_decimal FROM Airport WITH (NOLOCK) WHERE (aport_id = ffd_origin_aport_id)), ";
					strUpdate1 = $"{strUpdate1}(SELECT TOP 1 aport_longitude_decimal FROM Airport WITH (NOLOCK) WHERE (aport_id = ffd_origin_aport_id)), ";
					strUpdate1 = $"{strUpdate1}(SELECT TOP 1 aport_latitude_decimal FROM Airport WITH (NOLOCK) WHERE (aport_id = ffd_dest_aport_id)), ";
					strUpdate1 = $"{strUpdate1}(SELECT TOP 1 aport_longitude_decimal FROM Airport WITH (NOLOCK) WHERE (aport_id = ffd_dest_aport_id)) ";
					strUpdate1 = $"{strUpdate1}) AS INT) ";

					if (bOriginAPort)
					{
						strUpdate1 = $"{strUpdate1}WHERE (ffd_origin_aport_id = '{lAPortId.ToString()}') AND (ffd_distance = 0) ";
					}
					else
					{
						strUpdate1 = $"{strUpdate1}WHERE (ffd_dest_aport_id = '{lAPortId.ToString()}') AND (ffd_distance = 0) ";
					}

					do 
					{ // Loop Until lCnt1 <= 0

						bTrans = true;
						UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());
						DbCommand TempCommand = null;
						TempCommand = cntConn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						lCnt1 = TempCommand.ExecuteNonQuery();
						UpgradeHelpers.DB.TransactionManager.Commit(cntConn);
						bTrans = false;

						lTot1 += lCnt1;
						if (lCnt1 > 0)
						{
							JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(500);
						}

						lLoop1++;
						lLabel.Text = $"Updating Flight Distance: - APortId: {lAPortId.ToString()} - Records: {StringsHelper.Format(lTot1, "#,##0")}";
						Application.DoEvents();

					}
					while(!(lCnt1 <= 0 || lCnt1 < lTop || lLoop1 >= lLoopMax));

					lResults = lTot1;

					if (lLoop1 >= lLoopMax)
					{
						lResults = -1;
						lLabel.Text = $"Updating Flight Distance: - APortId: {lAPortId.ToString()} - Records: {StringsHelper.Format(lTot1, "#,##0")} - Failed MaxLoop Exceeded: {StringsHelper.Format(lLoop1, "#,##0")}";
					}
					else
					{
						lLabel.Text = $"Updating Flight Distance: - APortId: {lAPortId.ToString()} - Records: {StringsHelper.Format(lTot1, "#,##0")} - Completed";
					}

					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, lCTimeout);

				} // If lAPortId > 0 Then


				return lResults;
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;

				if (bTrans)
				{
					UpgradeHelpers.DB.TransactionManager.Rollback(cntConn);
				}

				Record_Error("Update_FAA_Flight_Data_Distance_By_APort_Id_In_Batch_Mode_Error", strErrDesc);

				result = -1;
			}
			return result;
		}

		internal static int Update_FAA_Flight_Data_Distance_By_APort_Id_In_Batch_Mode(DbConnection cntConn, Label lLabel, int lAPortId, bool bOriginAPort, ref int lTop)
		{
			int tempRefParam7 = 5000;
			return Update_FAA_Flight_Data_Distance_By_APort_Id_In_Batch_Mode(cntConn, lLabel, lAPortId, bOriginAPort, ref lTop, ref tempRefParam7);
		}

		internal static int Update_FAA_Flight_Data_Distance_By_APort_Id_In_Batch_Mode(DbConnection cntConn, Label lLabel, int lAPortId, bool bOriginAPort)
		{
			int tempRefParam8 = 5000;
			int tempRefParam9 = 5000;
			return Update_FAA_Flight_Data_Distance_By_APort_Id_In_Batch_Mode(cntConn, lLabel, lAPortId, bOriginAPort, ref tempRefParam8, ref tempRefParam9);
		} // Update_FAA_Flight_Data_Distance_By_APort_Id_In_Batch_Mode

		internal static int Update_FAA_Flight_Data_Clear_Action_Date_For_By_Action_Date_In_Batch_Mode(DbConnection cntConn, Label lLabel, System.DateTime dtActionDate, ref int lTop, ref int lLoopMax)
		{

			int result = 0;
			string strUpdate1 = "";

			int lLoop1 = 0;
			int lCnt1 = 0;
			int lTot1 = 0;
			int lCTimeout = 0;
			string strActionDate = "";
			bool bTrans = false;
			string strErrDesc = "";
			int lResults = 0;

			try
			{

				lResults = 0;
				lLoop1 = 0;
				lTot1 = 0;
				lCnt1 = 0;

				if (Information.IsDate(dtActionDate))
				{

					strActionDate = dtActionDate.ToString("MM/dd/yyyy");

					lCTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(cntConn);
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, 300);

					if (lTop <= 0)
					{
						lTop = 15000;
					}
					if (lLoopMax <= 0)
					{
						lLoopMax = 5000;
					}

					strUpdate1 = $"UPDATE TOP ({lTop.ToString()}) FAA_Flight_Data SET ffd_action_date = '1/1/1900' ";

					strUpdate1 = $"{strUpdate1}WHERE (ffd_action_date = '{strActionDate}')";

					do 
					{ // Loop Until lCnt1 <= 0

						bTrans = true;
						UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());
						DbCommand TempCommand = null;
						TempCommand = cntConn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						lCnt1 = TempCommand.ExecuteNonQuery();
						UpgradeHelpers.DB.TransactionManager.Commit(cntConn);
						bTrans = false;

						lTot1 += lCnt1;
						if (lCnt1 > 0)
						{
							JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(500);
						}

						lLoop1++;
						lLabel.Text = $"Updating Action Date: - {strActionDate} - Records: {StringsHelper.Format(lTot1, "#,##0")}";
						Application.DoEvents();

					}
					while(!(lCnt1 <= 0 || lCnt1 < lTop || lLoop1 >= lLoopMax));

					lResults = lTot1;

					if (lLoop1 >= lLoopMax)
					{
						lResults = -1;
						lLabel.Text = $"Updating Action Date: - {strActionDate} - Records: {StringsHelper.Format(lTot1, "#,##0")} - Failed MaxLoop Exceeded: {StringsHelper.Format(lLoop1, "#,##0")}";
					}
					else
					{
						lLabel.Text = $"Updating Action Date: - {strActionDate} - Records: {StringsHelper.Format(lTot1, "#,##0")} - Completed";
					}

					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, lCTimeout);

				} // If IsDate(dtActionDate) = True Then


				return lResults;
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;

				if (bTrans)
				{
					UpgradeHelpers.DB.TransactionManager.Rollback(cntConn);
				}

				Record_Error("Update_FAA_Flight_Data_Clear_Action_Date_For_By_Action_Date_In_Batch_Mode_Error", strErrDesc);

				result = -1;
			}
			return result;
		}

		internal static int Update_FAA_Flight_Data_Clear_Action_Date_For_By_Action_Date_In_Batch_Mode(DbConnection cntConn, Label lLabel, System.DateTime dtActionDate, ref int lTop)
		{
			int tempRefParam10 = 5000;
			return Update_FAA_Flight_Data_Clear_Action_Date_For_By_Action_Date_In_Batch_Mode(cntConn, lLabel, dtActionDate, ref lTop, ref tempRefParam10);
		}

		internal static int Update_FAA_Flight_Data_Clear_Action_Date_For_By_Action_Date_In_Batch_Mode(DbConnection cntConn, Label lLabel, System.DateTime dtActionDate)
		{
			int tempRefParam11 = 5000;
			int tempRefParam12 = 5000;
			return Update_FAA_Flight_Data_Clear_Action_Date_For_By_Action_Date_In_Batch_Mode(cntConn, lLabel, dtActionDate, ref tempRefParam11, ref tempRefParam12);
		} // Update_FAA_Flight_Data_Clear_Action_Date_For_By_Action_Date_In_Batch_Mode

		internal static int DelaySeconds(int iDelaySec)
		{

			System.DateTime dtStartTime = DateTime.FromOADate(0);
			int lElapsedTime = 0;
			int lSleep = 0;

			if (iDelaySec > 0 && iDelaySec < 3600)
			{ // Max 60 minutes

				dtStartTime = DateTime.Now;
				lElapsedTime = 0;
				lSleep = 1000;

				do 
				{ // Loop Until (iElapsedTime >= iDelaySec) Or (Left(Time(), 7) = "00:00:0")

					lElapsedTime = (int) DateAndTime.DateDiff("s", dtStartTime, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);

					JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(lSleep);
					Application.DoEvents();
					Application.DoEvents();

				}
				while(!((lElapsedTime >= iDelaySec) || (DateTimeHelper.ToString(DateTimeHelper.Time).StartsWith("00:00:0", StringComparison.Ordinal))));

			} // If iDelaySec > 0 And iDelaySec < 3600 Then ' Max 60 minutes

			return lElapsedTime;

		} // DelaySeconds


		internal static void AddItemToLogFile(string strText)
		{
			StreamWriter tsFileWriter = null;




			string strDT = $"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} - {gbl_User_ID.ToUpper()} - Homebase - "; // Date/Time

			string strDate = DateTime.Now.ToString("yyyyMMdd");
			string strFileName = $"{strDate}.LOG";
			strText = ($"{strText} ").Trim();

			string strPath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\";
			if (!Directory.Exists(strPath))
			{
				Directory.CreateDirectory(strPath);
			}

			strPath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\LogFiles\\{DateTime.Now.ToString("yyyyMM")}\\";
			if (!Directory.Exists(strPath))
			{
				Directory.CreateDirectory(strPath);
			}

			FileStream tsFile = new FileStream($"{strPath}{strFileName}", FileMode.Append, FileAccess.Write); // Text Stream File Object for Writting to the Log File

			tsFileWriter = new StreamWriter(tsFile);
			tsFileWriter.WriteLine($"{strDT}{strText}"); // Write String

			tsFileWriter.Close(); // Close File
			 // Release Memory

		} // AddItemToLogFile
	}
}